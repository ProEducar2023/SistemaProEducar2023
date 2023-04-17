using DAL;
using Entidades;
using System;
using System.Data;
using System.Transactions;
namespace BLL
{
    public class progNivelRelacionBLL
    {
        progNivelRelacionDAL prnirDAL = new progNivelRelacionDAL();
        progNivelRelacionTo prnirTo = new progNivelRelacionTo();

        public DataTable obtenerPrograNivelRelacionBLL()
        {
            return prnirDAL.obtenerPrograNivelRelacionDAL();
        }
        public bool adicionaProgNivelRelacionBLL(DataTable dt, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                //ELIMINA LOS REGISTROS DE LAS TABLAS PARA CREARLAS NUEVAMENTE
                if (!eliminarProgNivelRelacionBLL(dt, ref errMensaje))
                    return result = false;
                //INSERTA LOS REGISTROS
                if (!insertarProgNivelRelacionBLL(dt, ref errMensaje))
                    return result = false;

                ts.Complete();
                return result;
            }
        }
        public bool insertarProgNivelRelacionBLL(DataTable dt, ref string errMensaje)
        {
            bool result = true;

            foreach (DataRow rw in dt.Rows)
            {
                prnirTo.COD_PROG = rw["COD_PROG"].ToString();
                prnirTo.COD_VEND = rw["COD_VEND"].ToString();
                prnirTo.COD_SUPERIOR = rw["COD_SUPERIOR"].ToString();
                prnirTo.COD_NIVEL = rw["COD_NIVEL"].ToString();
                prnirTo.COD_ALM = rw["COD_ALM"].ToString();
                //prnirTo.COD_ENC_NUM_CONTRATO = rw["COD_ENC_NUM_CONTRATO"].ToString();
                if (!prnirDAL.insertarProgNivelRelacionDAL(prnirTo, ref errMensaje))
                    return result = false;
            }

            return result;
        }
        public DataTable obtenerRelacionVendSupBLL(progNivelRelacionTo prnirTo)
        {
            return prnirDAL.obtenerRelacionVendSupDAL(prnirTo);
        }
        public bool eliminarProgNivelRelacionBLL(DataTable dt, ref string errMensaje)
        {
            bool result = true;

            foreach (DataRow rw in dt.Rows)
            {
                prnirTo.COD_PROG = rw["COD_PROG"].ToString();
                prnirTo.COD_VEND = rw["COD_VEND"].ToString();
                if (!prnirDAL.eliminarProgNivelRelacionDAL(prnirTo, ref errMensaje))
                    return result = false;
            }

            return result;
        }
        public bool eliminarProgNivelRelacionBLL(progNivelRelacionTo prnirTo, ref string errMensaje)
        {
            bool result = true;
            if (!prnirDAL.eliminarProgNivelRelacion2DAL(prnirTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminarProgNivelCobranzaBLL(progNivelRelacionTo prnirTo, ref string errMensaje)
        {
            bool result = true;
            if (!prnirDAL.eliminarProgNivelCobranzaDAL(prnirTo, ref errMensaje))
                return result = false;
            return result;
        }
        public DataTable obtenerNivelesSuperioresVendedorBLL(progNivelRelacionTo pnrTo)
        {
            return prnirDAL.obtenerNivelesSuperioresVendedorDAL(pnrTo);
        }
        public bool adicionaProgNivelRelacionCobranzaBLL(DataTable dt, string codprog, string codsup, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                //ELIMINA LOS REGISTROS DE LAS TABLAS PARA CREARLAS NUEVAMENTE
                if (!eliminarProgNivelRelacionCobranzaBLL(codprog, codsup, ref errMensaje))
                    return result = false;
                //INSERTA LOS REGISTROS
                if (!insertarProgNivelRelacionCobranzaBLL(dt, ref errMensaje))
                    return result = false;

                ts.Complete();
                return result;
            }
        }
        public bool eliminarProgNivelRelacionCobranzaBLL(string codprog, string codsup, ref string errMensaje)
        {
            bool result = true;
            prnirTo.COD_PROG = codprog;
            prnirTo.COD_SUPERIOR = codsup;
            if (!prnirDAL.eliminarProgNivelRelacionCobranzaDAL(prnirTo, ref errMensaje))
                return result = false;
            //foreach (DataRow rw in dt.Rows)
            //{
            //    prnirTo.COD_PROG = rw["COD_PROG"].ToString();
            //    //prnirTo.COD_VEND = rw["COD_COB"].ToString();
            //    prnirTo.COD_VEND = rw["COD_SUPERIOR"].ToString();
            //    if (!prnirDAL.eliminarProgNivelRelacionCobranzaDAL(prnirTo, ref errMensaje))
            //        return result = false;
            //}

            return result;
        }
        public bool insertarProgNivelRelacionCobranzaBLL(DataTable dt, ref string errMensaje)
        {
            bool result = true;

            foreach (DataRow rw in dt.Rows)
            {
                prnirTo.COD_PROG = rw["COD_PROG"].ToString();
                prnirTo.COD_VEND = rw["COD_COB"].ToString();
                prnirTo.COD_SUPERIOR = rw["COD_SUPERIOR"].ToString();
                prnirTo.COD_NIVEL = rw["COD_NIVEL"].ToString();
                //prnirTo.COD_ALM = rw["COD_ALM"].ToString();
                if (!prnirDAL.insertarProgNivelRelacionCobranzaDAL(prnirTo, ref errMensaje))
                    return result = false;
            }

            return result;
        }
        public DataTable obtenerPrograNivelRelacionCobSupBLL(string codsup)
        {
            return prnirDAL.obtenerPrograNivelRelacionCobSupDAL(codsup);
        }
    }
}
