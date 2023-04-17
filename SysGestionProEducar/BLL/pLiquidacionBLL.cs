using DAL;
using Entidades;
using System;
using System.Data;
using System.Transactions;
namespace BLL
{
    public class pLiquidacionBLL
    {
        pLiquidacionDAL lqcDAL = new pLiquidacionDAL();
        public DataTable obtenerPLiquidacionBLL(pLiquidacionTo lqcTo)
        {
            return lqcDAL.obtenerPLiquidacionDAL(lqcTo);
        }
        public bool liquidacionComisionesBLL(pLiquidacionTo lqcTo, DataTable dtComision, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                foreach (DataRow rw in dtComision.Rows)
                {
                    lqcTo.TIPO_VTA = rw["TIPO_VTA"].ToString();
                    lqcTo.COD_PROGRAMA = rw["COD_PROGRAMA"].ToString();
                    lqcTo.COD_COMISIONANTE = rw["COD_PER_SUP"].ToString();
                    lqcTo.COD_VENDEDOR = rw["COD_VENDEDOR"].ToString();
                    lqcTo.NRO_CONTRATO = rw["NRO_CONTRATO"].ToString();
                    lqcTo.FE_CONTRATO = Convert.ToDateTime(rw["FE_CONTRATO"]);
                    lqcTo.FE_AÑO = rw["FE_AÑO"].ToString();
                    lqcTo.FE_MES = rw["FE_MES"].ToString();
                    lqcTo.COD_PER = rw["COD_PER"].ToString();
                    lqcTo.NRO_LETRA = rw["NRO_LETRA"].ToString();
                    lqcTo.IMP_INI = Convert.ToDecimal(rw["IMP_FIN"]);
                    lqcTo.IMPORTE = Convert.ToDecimal(rw["IMP_FIN"]);
                    lqcTo.COD_NIVEL = rw["COD_NIVEL"].ToString();
                    lqcTo.COD_PER_SUP = rw["COD_PER_SUP"].ToString();
                    lqcTo.STATUS_CANCELADO = "0";
                    lqcTo.STATUS_CIERRE = "0";
                    lqcTo.NRO_DOC_PAG = "";
                    lqcTo.FECHA_DOC_PAG = null;
                    lqcTo.COD_CONCEPTO = "";
                    lqcTo.COD_BANCO = "";
                    //P_Liquidacion
                    if (!insertarPLiquidacionBLL(lqcTo, ref errMensaje))
                        return result = false;
                    ////T_Liquidacion  ////NO VA DICE DON MIGUEL
                    //if (!insertarTLiquidacionBLL(lqcTo, ref errMensaje))
                    //    return result = false;
                    //I_Pedido
                    if (rw["STATUS_PRE_APROB"].ToString() == "1")//solo cuando sea PreAprobado va a I_Pedido y actualiza STATUS_APROBADO a 1 y le pone la fecha de Aprobación, pues no los tienen porque no han sido aprobados en la Venta
                    {
                        if (!modificarIPedidoxLiqComisionBLL(lqcTo, ref errMensaje))
                            return result = false;
                    }
                    //P_Comision
                    if (!modificarPComisionxLiqComisionBLL(lqcTo, ref errMensaje)) //YA NO RESTA DICE DON MIGUEL, LO HACE TESORERIA
                        return result = false;
                    ////T_Comision  ////////NO VA DICE DON MIGUEL, LO HACE TESORERIA
                    //if (!insertarTComisionxLiqComisionBLL(lqcTo, ref errMensaje))
                    //    return result = false;
                }
                ts.Complete();
                return result;
            }
        }
        public bool insertarTLiquidacionBLL(pLiquidacionTo lqcTo, ref string errMensaje)
        {
            bool result = true;
            tLiquidacionBLL tliqBLL = new tLiquidacionBLL();
            tLiquidacionTo tliqTo = new tLiquidacionTo();
            tliqTo.TIPO_VTA = lqcTo.TIPO_VTA;
            tliqTo.COD_PROGRAMA = lqcTo.COD_PROGRAMA;
            tliqTo.COD_COMISIONANTE = lqcTo.COD_COMISIONANTE;
            tliqTo.NRO_CONTRATO = lqcTo.NRO_CONTRATO;
            tliqTo.NRO_LETRA = lqcTo.NRO_LETRA;
            tliqTo.COD_NIVEL = lqcTo.COD_NIVEL;
            tliqTo.FE_DOC = lqcTo.FE_DOC;
            tliqTo.FE_PAGO = null;
            tliqTo.IMPORTE = lqcTo.IMPORTE;
            tliqTo.COD_VENDEDOR = lqcTo.COD_VENDEDOR;
            tliqTo.TIPO_OPE = "GD";
            tliqTo.COD_D_H = "D";
            tliqTo.COD_CREA = lqcTo.COD_CREA;
            tliqTo.FECHA_CREA = lqcTo.FECHA_CREA;
            if (!tliqBLL.insertarTLiquidacionBLL(tliqTo, ref errMensaje))
                return result = false;

            return result;
        }
        public bool insertarTComisionxLiqComisionBLL(pLiquidacionTo lqcTo, ref string errMensaje)
        {
            bool result = true;
            tComisionBLL tcomBLL = new tComisionBLL();
            tComisionTo tcomTo = new tComisionTo();
            tcomTo.TIPO_VTA = lqcTo.TIPO_VTA;
            tcomTo.COD_PROGRAMA = lqcTo.COD_PROGRAMA;
            tcomTo.COD_VENDEDOR = lqcTo.COD_VENDEDOR;
            tcomTo.NRO_CONTRATO = lqcTo.NRO_CONTRATO;
            tcomTo.FE_AÑO = lqcTo.FE_AÑO;
            tcomTo.FE_MES = lqcTo.FE_MES;
            tcomTo.TIPO_VTA = lqcTo.TIPO_VTA;
            tcomTo.FE_DOC = lqcTo.FE_DOC;
            tcomTo.FE_CANC = lqcTo.FECHA_CREA;
            tcomTo.FE_APROB = null;
            tcomTo.COD_PER = lqcTo.COD_PER;
            tcomTo.COD_PROGRAMA = lqcTo.COD_PROGRAMA;
            tcomTo.IMPORTE = lqcTo.IMPORTE;//se puso porque ya no se trae de PCTAS_COBRAR
            tcomTo.NRO_LETRA = lqcTo.NRO_LETRA;
            tcomTo.COD_NIVEL = lqcTo.COD_NIVEL;
            tcomTo.TIPO_OPE = "CC";//cancelacion de comision
            tcomTo.COD_PER_SUP = lqcTo.COD_PER_SUP;
            tcomTo.COD_D_H = "H";
            tcomTo.COD_CREA = lqcTo.COD_CREA;
            tcomTo.FECHA_CREA = lqcTo.FECHA_CREA;
            if (!tcomBLL.insertarTComisionBLL(tcomTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificarPComisionxLiqComisionBLL(pLiquidacionTo lqcTo, ref string errMensaje)
        {
            bool result = true;
            pComisionBLL pcomBLL = new pComisionBLL();
            pComisionTo pcomTo = new pComisionTo();
            pcomTo.FE_AÑO = lqcTo.FE_AÑO;
            pcomTo.FE_MES = lqcTo.FE_MES;
            pcomTo.NRO_CONTRATO = lqcTo.NRO_CONTRATO;
            pcomTo.FE_CONTRATO = lqcTo.FE_CONTRATO;
            pcomTo.NRO_LETRA = lqcTo.NRO_LETRA;
            pcomTo.IMP_FIN = lqcTo.IMPORTE;
            pcomTo.COD_NIVEL = lqcTo.COD_NIVEL;
            pcomTo.COD_MODIF = lqcTo.COD_CREA;
            pcomTo.FECHA_MODIF = lqcTo.FECHA_CREA;
            if (!pcomBLL.modificarPComisionxLiqComisionBLL(pcomTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificarPComisionxLiqComision_EliminarBLL(pLiquidacionTo lqcTo, ref string errMensaje)
        {
            bool result = true;
            pComisionBLL pcomBLL = new pComisionBLL();
            pComisionTo pcomTo = new pComisionTo();
            pcomTo.FE_AÑO = lqcTo.FE_AÑO;
            pcomTo.FE_MES = lqcTo.FE_MES;
            pcomTo.NRO_CONTRATO = lqcTo.NRO_CONTRATO;
            //pcomTo.FE_CONTRATO = lqcTo.FE_CONTRATO;
            pcomTo.NRO_LETRA = lqcTo.NRO_LETRA;
            pcomTo.IMP_FIN = lqcTo.IMPORTE;
            pcomTo.COD_NIVEL = lqcTo.COD_NIVEL;
            pcomTo.COD_MODIF = lqcTo.COD_CREA;
            pcomTo.FECHA_MODIF = lqcTo.FECHA_CREA;
            if (!pcomBLL.modificarPComisionxLiqComision_EliminarBLL(pcomTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool insertarPLiquidacionBLL(pLiquidacionTo lqcTo, ref string errMensaje)
        {
            bool result = true;
            if (!lqcDAL.insertarPLiquidacionDAL(lqcTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificarIPedidoxLiqComisionBLL(pLiquidacionTo lqcTo, ref string errMensaje)
        {
            bool result = true;
            contratoCabeceraBLL ccBLL = new contratoCabeceraBLL();
            contratoCabeceraTo ccTo = new contratoCabeceraTo();
            ccTo.FE_AÑO = lqcTo.FE_AÑO;
            ccTo.FE_MES = lqcTo.FE_MES;
            ccTo.NRO_PRESUPUESTO = lqcTo.NRO_CONTRATO;
            ccTo.FECHA_APROB = lqcTo.FE_DOC;//lo dice Don Miguel
            ccTo.STATUS_APROB = "1";
            if (!ccBLL.modificarIPedidoxLiqComisionBLL(ccTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminaLiquidacionxCuotaBLL(pLiquidacionTo lqcTo, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;

                //P_Liquidacion
                if (!eliminarPLiquidacionBLL(lqcTo, ref errMensaje))
                    return result = false;
                ////T_Liquidacion  //ya no existe
                //if (!eliminarTLiquidacionBLL(lqcTo, ref errMensaje))
                //    return result = false;
                //I_Pedido
                if (lqcTo.STATUS_PRE_APROB == "P")
                    if (!modificarIPedidoxLiqComision2BLL(lqcTo, ref errMensaje))
                        return result = false;
                //P_Comision  //solo cambia el STATUS_LIQUIDADO=0, ya no modifica el importe, eso se hará de Tesorería
                if (!modificarPComisionxLiqComision_EliminarBLL(lqcTo, ref errMensaje))
                    return result = false;
                ////T_Comision
                //if (!eliminarTComisionxLiqComisionBLL(lqcTo, ref errMensaje))
                //    return result = false;      

                ts.Complete();
                return result;
            }
        }
        private bool eliminarTComisionxLiqComisionBLL(pLiquidacionTo lqcTo, ref string errMensaje)
        {
            bool result = true;
            tComisionBLL tcomBLL = new tComisionBLL();
            tComisionTo tcomTo = new tComisionTo();
            tcomTo.TIPO_VTA = lqcTo.TIPO_VTA;
            tcomTo.COD_PROGRAMA = lqcTo.COD_PROGRAMA;
            tcomTo.COD_VENDEDOR = lqcTo.COD_VENDEDOR;
            tcomTo.NRO_CONTRATO = lqcTo.NRO_CONTRATO;
            tcomTo.NRO_LETRA = lqcTo.NRO_LETRA;
            tcomTo.COD_NIVEL = lqcTo.COD_NIVEL;
            tcomTo.COD_PER_SUP = lqcTo.COD_PER_SUP;
            tcomTo.TIPO_OPE = "CC";
            if (!tcomBLL.eliminarTComisionxLiqComisionBLL(tcomTo, ref errMensaje))
                return result = false;
            return result;
        }
        private bool modificarIPedidoxLiqComision2BLL(pLiquidacionTo lqcTo, ref string errMensaje)
        {
            bool result = true;
            contratoCabeceraBLL ccBLL = new contratoCabeceraBLL();
            contratoCabeceraTo ccTo = new contratoCabeceraTo();
            ccTo.FE_AÑO = lqcTo.FE_AÑO;
            ccTo.FE_MES = lqcTo.FE_MES;
            ccTo.NRO_PRESUPUESTO = lqcTo.NRO_CONTRATO;
            ccTo.FECHA_APROB = null;//lo dice Don Miguel
            ccTo.STATUS_APROB = "0";
            if (!ccBLL.modificarIPedidoxLiqComisionBLL(ccTo, ref errMensaje))
                return result = false;
            return result;
        }
        private bool eliminarPLiquidacionBLL(pLiquidacionTo lqcTo, ref string errMensaje)
        {
            bool result = true;
            if (!lqcDAL.eliminarPLiquidacionDAL(lqcTo, ref errMensaje))
                return result = false;
            return result;
        }
        private bool eliminarTLiquidacionBLL(pLiquidacionTo lqcTo, ref string errMensaje)
        {
            bool result = true;
            tLiquidacionBLL tlqBLL = new tLiquidacionBLL();
            tLiquidacionTo tlqTo = new tLiquidacionTo();
            tlqTo.TIPO_VTA = lqcTo.TIPO_VTA;
            tlqTo.COD_PROGRAMA = lqcTo.COD_PROGRAMA;
            tlqTo.COD_COMISIONANTE = lqcTo.COD_COMISIONANTE;
            tlqTo.NRO_CONTRATO = lqcTo.NRO_CONTRATO;
            tlqTo.NRO_LETRA = lqcTo.NRO_LETRA;
            if (!tlqBLL.eliminarTLiquidacionBLL(tlqTo, ref errMensaje))
                return result = false;
            return result;
        }
        public DataTable obtenerLiquidacionpara_P_ResumenBLL(pLiquidacionTo lqcTo)
        {
            return lqcDAL.obtenerLiquidacionpara_P_ResumenDAL(lqcTo);
        }
        public decimal sumaComision_Comisiones_X_Periodo_X_ComisionistaBLL(pLiquidacionTo lqcTo)
        {
            return lqcDAL.sumaComision_Comisiones_X_Periodo_X_ComisionistaDAL(lqcTo);
        }
        public bool modificarLiqComisionBLL(pLiquidacionTo lqcTo, ref string errMensaje)
        {
            bool result = true;
            if (!lqcDAL.modificarLiqComisionDAL(lqcTo, ref errMensaje))
                return result = false;
            return result;
        }
        public DataTable obtenerComision_Comisiones_X_Periodo_X_ComisionistaBLL(pLiquidacionTo lqcTo)
        {
            return lqcDAL.obtenerComision_Comisiones_X_Periodo_X_ComisionistaDAL(lqcTo);
        }
    }

}
