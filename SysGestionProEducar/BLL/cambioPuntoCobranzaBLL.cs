using DAL;
using Entidades;
using System;
using System.Data;
using System.Transactions;

namespace BLL
{
    public class cambioPuntoCobranzaBLL
    {
        cambioPuntoCobranzaDAL cpcDAL = new cambioPuntoCobranzaDAL();
        cambioPuntoCobranzaTo cpcTo = new cambioPuntoCobranzaTo();

        public DataTable obtenerCambioPuntoCobranzaBLL()
        {
            return cpcDAL.obtenerCambioPuntoCobranzaDAL();
        }
        public DataTable obtenerCambioPuntoCobranzaxPersonaBLL(cambioPuntoCobranzaTo cpcTo)
        {
            return cpcDAL.obtenerCambioPuntoCobranzaxPersonaDAL(cpcTo);
        }
        public bool adicionaCambiodePuntoCobranzaBLL(cambioPuntoCobranzaTo cpcTo, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                //cuenta corriente
                if (!insertarCambioPuntoCobranzaBLL(cpcTo, ref errMensaje))
                    return result = false;
                if (!cpcTo.SIN_CAMBIO_PTO_COB)// quiere decir que no cambio el pto de cob 
                {
                    //tabla de registros de puntos de cobranza cambiadas
                    if (!modificarICtasxCambioPtoCobBLL(cpcTo, ref errMensaje))
                        return result = false;
                    if (!modificarPCtasxCambioPtoCobBLL(cpcTo, ref errMensaje))
                        return result = false;
                    if (!modificarTCtasxCambioPtoCobBLL(cpcTo, ref errMensaje))
                        return result = false;
                }
                //tabla de PERSONAS
                if (cpcTo.COD_INSTITUCION == "01")//Ministerio de Educacion
                {
                    if (!modificarMaestroPersonasBLL(cpcTo, ref errMensaje))
                        return result = false;
                }
                ts.Complete();
                return result;
            }
        }
        private bool modificarMaestroPersonasBLL(cambioPuntoCobranzaTo cpcTo, ref string errMensaje)
        {
            bool result = true;
            personaMaestroBLL perBLL = new personaMaestroBLL();
            personaMaestroTo perTo = new personaMaestroTo();
            perTo.COD_PER = cpcTo.COD_PER;
            perTo.DES_PROCESO = cpcTo.COD_DESCUENTO;
            if (!perBLL.modificaMaestroPersonaxCambioPtoCobBLL(perTo, ref errMensaje))
                return result = false;
            return result;
        }
        private bool modificarICtasxCambioPtoCobBLL(cambioPuntoCobranzaTo cpcTo, ref string errMensaje)
        {
            bool result = true;
            canjeICtasxCobrarBLL ictBLL = new canjeICtasxCobrarBLL();
            canjeICtasxCobrarTo ictTo = new canjeICtasxCobrarTo();
            ictTo.COD_PER = cpcTo.COD_PER;
            ictTo.COD_PTO_COB = cpcTo.COD_PTO_COB;
            ictTo.COD_USU_MOD = cpcTo.COD_USU_CREA;
            ictTo.FECHA_MOD = cpcTo.FECHA_USU_CREA;

            if (!ictBLL.modificarICtasxCambioPtoCobBLL(ictTo, ref errMensaje))
                return result = false;
            return result;
        }
        private bool modificarPCtasxCambioPtoCobBLL(cambioPuntoCobranzaTo cpcTo, ref string errMensaje)
        {
            bool result = true;
            canjePCtasxCobrarBLL pctBLL = new canjePCtasxCobrarBLL();
            canjePCtasxCobrarTo pctTo = new canjePCtasxCobrarTo();
            pctTo.COD_PER = cpcTo.COD_PER;
            pctTo.COD_PTO_COB = cpcTo.COD_PTO_COB;
            pctTo.COD_USU_MOD = cpcTo.COD_USU_CREA;
            pctTo.FECHA_MOD = cpcTo.FECHA_USU_CREA;

            if (!pctBLL.modificarPCtasxCambioPtoCobBLL(pctTo, ref errMensaje))
                return result = false;
            return result;
        }
        private bool modificarTCtasxCambioPtoCobBLL(cambioPuntoCobranzaTo cpcTo, ref string errMensaje)
        {
            bool result = true;
            canjeTCtasxCobrarBLL tctBLL = new canjeTCtasxCobrarBLL();
            canjeTCtasxCobrarTo tctTo = new canjeTCtasxCobrarTo();
            tctTo.COD_PER = cpcTo.COD_PER;
            tctTo.COD_USU_MOD = cpcTo.COD_USU_CREA;
            tctTo.FECHA_MOD = cpcTo.FECHA_USU_CREA;

            if (!tctBLL.modificarPCtasxCambioPtoCobBLL(tctTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool insertarCambioPuntoCobranzaBLL(cambioPuntoCobranzaTo cpcTo, ref string errMensaje)
        {
            bool result = true;
            if (!cpcDAL.insertarCambioPuntoCobranzaDAL(cpcTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificarCambioPuntoCobranzaBLL(cambioPuntoCobranzaTo cpcTo, ref string errMensaje)
        {
            bool result = true;
            if (!cpcDAL.modificarCambioPuntoCobranzaDAL(cpcTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminarCambioPuntoCobranzaBLL(cambioPuntoCobranzaTo cpcTo, ref string errMensaje)
        {
            bool result = true;
            if (!cpcDAL.eliminarCambioPuntoCobranzaDAL(cpcTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificaCambiodePuntoCobranzaBLL(cambioPuntoCobranzaTo cpcTo, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                //cuenta corriente
                if (!modificarCambioPuntoCobranzaBLL(cpcTo, ref errMensaje))
                    return result = false;
                //tabla de registros de puntos de cobranza cambiadas
                if (!modificarICtasxCambioPtoCobBLL(cpcTo, ref errMensaje))
                    return result = false;
                if (!modificarPCtasxCambioPtoCobBLL(cpcTo, ref errMensaje))
                    return result = false;
                if (!modificarTCtasxCambioPtoCobBLL(cpcTo, ref errMensaje))
                    return result = false;
                //tabla de PERSONAS
                if (cpcTo.COD_INSTITUCION == "01")//Ministerio de Educacion
                {
                    if (!modificarMaestroPersonasBLL(cpcTo, ref errMensaje))
                        return result = false;
                }
                ts.Complete();
                return result;
            }
        }
    }
}
