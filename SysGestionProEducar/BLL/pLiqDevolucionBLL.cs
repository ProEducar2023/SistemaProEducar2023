using DAL;
using Entidades;
using System;
using System.Data;
using System.Transactions;
namespace BLL
{
    public class pLiqDevolucionBLL
    {
        pLiqDevolucionDAL pldDAL = new pLiqDevolucionDAL();
        public DataTable obtenerPLiqDevolucionBLL(pLiqDevolucionTo pldTo, ref string errMensaje)
        {
            return pldDAL.obtenerPLiqDevolucionDAL(pldTo);
        }
        public bool insertarPLiqDevolucionBLL(pLiqDevolucionTo pldTo, ref string errMensaje)
        {
            bool result = true;
            if (!pldDAL.insertarPLiqDevolucionDAL(pldTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool LiquidacionDevolucionBLL(pLiqDevolucionTo pldTo, DataTable dtDevLiq, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                foreach (DataRow rw in dtDevLiq.Rows)
                {
                    pldTo.TIPO_VTA = rw["TIPO_VTA"].ToString();
                    pldTo.COD_PROGRAMA = rw["COD_PROGRAMA"].ToString();
                    //pdevTo.COD_PER_SUP = rw["COD_PER_SUP"].ToString();
                    pldTo.COD_VENDEDOR = rw["COD_VENDEDOR"].ToString();
                    pldTo.NRO_CONTRATO = rw["NRO_CONTRATO"].ToString();
                    pldTo.FE_CONTRATO = Convert.ToDateTime(rw["FE_CONTRATO"]);
                    pldTo.COD_PER = rw["COD_PER"].ToString();
                    pldTo.NRO_LETRA = rw["NRO_LETRA"].ToString();
                    pldTo.IMPORTE = Convert.ToDecimal(rw["IMP_INI"]);//es el  importe que se liquidará, puede ser menor o igual al que está a su costado
                    //pldTo.IMPORTE = Convert.ToDecimal(rw["IMP_INI"]);
                    pldTo.COD_NIVEL = rw["COD_NIVEL"].ToString();
                    pldTo.COD_COMISIONANTE = rw["COD_PER_SUP"].ToString();
                    pldTo.STATUS_CANCELADO = "0";
                    pldTo.STATUS_CIERRE = "0";
                    pldTo.NRO_DOC_PAG = "";
                    pldTo.FECHA_DOC_PAG = null;
                    pldTo.COD_CONCEPTO = "";
                    pldTo.COD_BANCO = "";
                    //P_Liq_Devolucion
                    if (!insertarPLiqDevolucionBLL(pldTo, ref errMensaje))
                        return result = false;
                    //P_Devolucion
                    pldTo.OP = "0";
                    if (!modificarPDevolucionBLL(pldTo, ref errMensaje))
                        return result = false;
                    ////T_Devolucion   // ya no hace esto, lo hará desde Tesorería
                    //if (!insertarTDevolucionBLL(pldTo, ref errMensaje))
                    //    return result = false;
                }
                ts.Complete();
                return result;
            }
        }
        public bool modificarPDevolucionBLL(pLiqDevolucionTo pldTo, ref string errMensaje)
        {
            pDevolucionBLL pdevBLL = new pDevolucionBLL();
            pDevolucionTo pdevTo = new pDevolucionTo();
            pdevTo.TIPO_VTA = pldTo.TIPO_VTA;
            pdevTo.COD_PROGRAMA = pldTo.COD_PROGRAMA;
            pdevTo.COD_VENDEDOR = pldTo.COD_VENDEDOR;
            pdevTo.NRO_CONTRATO = pldTo.NRO_CONTRATO;
            pdevTo.NRO_LETRA = pldTo.NRO_LETRA;
            pdevTo.COD_NIVEL = pldTo.COD_NIVEL;
            pdevTo.COD_PER_SUP = pldTo.COD_COMISIONANTE;
            pdevTo.IMPORTE = (-1) * pldTo.IMPORTE;//no se usa pues Tesorería hace la labor
            if (pldTo.OP == "0") pdevTo.STATUS_LIQUIDADO = "1"; else if (pldTo.OP == "1") pdevTo.STATUS_LIQUIDADO = "0";//se va a usar el mismo método pero con OP diferenciamos el valor a usar
            pdevTo.COD_MODIF = pldTo.COD_CREA;
            pdevTo.FECHA_MODIF = pldTo.FECHA_CREA;
            bool result = true;
            if (!pdevBLL.modificarPDevolucionxLiqDevolucionBLL(pdevTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool insertarTDevolucionBLL(pLiqDevolucionTo pldTo, ref string errMensaje)
        {
            tDevolucionBLL tdevBLL = new tDevolucionBLL();
            tDevolucionTo tdevTo = new tDevolucionTo();
            tdevTo.TIPO_VTA = pldTo.TIPO_VTA;
            tdevTo.COD_PROGRAMA = pldTo.COD_PROGRAMA;
            tdevTo.COD_VENDEDOR = pldTo.COD_VENDEDOR;
            tdevTo.NRO_CONTRATO = pldTo.NRO_CONTRATO;
            tdevTo.FE_AÑO = pldTo.FE_AÑO;
            tdevTo.FE_MES = pldTo.FE_MES;
            tdevTo.FE_DOC = pldTo.FE_DOC;
            tdevTo.FE_CANC = null;
            tdevTo.COD_PER = pldTo.COD_PER;
            tdevTo.IMPORTE = pldTo.IMPORTE;
            tdevTo.NRO_LETRA = pldTo.NRO_LETRA;
            tdevTo.COD_NIVEL = pldTo.COD_NIVEL;
            tdevTo.TIPO_OPE = "CC";
            tdevTo.COD_PER_SUP = pldTo.COD_COMISIONANTE;
            tdevTo.COD_D_H = "H";
            tdevTo.COD_CREA = pldTo.COD_CREA;
            tdevTo.FECHA_CREA = pldTo.FECHA_CREA;
            bool result = true;
            if (!tdevBLL.insertarTDevolucionBLL(tdevTo, ref errMensaje))
                return result = false;
            return result;
        }
        public DataTable obtenerDevolucionesLiquidadasBLL(pLiqDevolucionTo pldTo)
        {
            return pldDAL.obtenerDevolucionesLiquidadasDAL(pldTo);
        }
        public DataTable obtenerPLiqDevolucionxPeriodoparaResumenBLL(pLiqDevolucionTo pldTo)
        {
            return pldDAL.obtenerPLiqDevolucionxPeriodoparaResumenDAL(pldTo);
        }
        public decimal sumaDevolucion_Comisiones_X_Periodo_X_ComisionistaBLL(pLiqDevolucionTo pldTo)
        {
            return pldDAL.sumaDevolucion_Comisiones_X_Periodo_X_ComisionistaDAL(pldTo);
        }
        public bool eliminaDevolucionesLiquidadasBLL(pLiqDevolucionTo pldTo, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;

                //P_Liq_Devolucion
                if (!eliminarPLiqDevolucionBLL(pldTo, ref errMensaje))
                    return result = false;
                //P_Devolucion
                pldTo.OP = "1";
                if (!modificarPDevolucionBLL(pldTo, ref errMensaje))
                    return result = false;
                ////T_Devolucion   // ya no hace esto, lo hará desde Tesorería
                //if (!insertarTDevolucionBLL(pldTo, ref errMensaje))
                //    return result = false;

                ts.Complete();
                return result;
            }
        }
        private bool eliminarPLiqDevolucionBLL(pLiqDevolucionTo pldTo, ref string errMensaje)
        {
            bool result = true;
            if (!pldDAL.eliminarPLiqDevolucionDAL(pldTo, ref errMensaje))
                return result = false;
            return result;
        }
        public DataTable obtenerDevolucion_Comisiones_X_Periodo_X_ComisionistaBLL(pLiqDevolucionTo pldTo)
        {
            return pldDAL.obtenerDevolucion_Comisiones_X_Periodo_X_ComisionistaDAL(pldTo);
        }
    }
}
