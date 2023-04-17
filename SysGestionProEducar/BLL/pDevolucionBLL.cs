using DAL;
using Entidades;
using System;
using System.Data;
using System.Transactions;
namespace BLL
{
    public class pDevolucionBLL
    {
        pDevolucionDAL pdevDAL = new pDevolucionDAL();
        public DataTable obtenerPDevolucionBLL(pDevolucionTo pdevTo)
        {
            return pdevDAL.obtenerPDevolucionDAL(pdevTo);
        }
        public bool insertarPDevolucionBLL(pDevolucionTo pdevTo, ref string errMensaje)
        {
            bool result = true;
            if (!pdevDAL.insertarPDevolucionDAL(pdevTo, ref errMensaje))
                return result;
            return result;
        }
        public bool GeneracionDevolucionBLL(pDevolucionTo pdevTo, DataTable dtDevolucion, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                foreach (DataRow rw in dtDevolucion.Rows)
                {
                    pdevTo.TIPO_VTA = rw["TIPO_PLANILLA"].ToString();
                    pdevTo.COD_PROGRAMA = rw["COD_PROGRAMA"].ToString();
                    //pdevTo.COD_PER_SUP = rw["COD_PER_SUP"].ToString();
                    pdevTo.COD_VENDEDOR = rw["COD_VENDEDOR"].ToString();
                    pdevTo.NRO_CONTRATO = rw["NRO_PRESUPUESTO"].ToString();
                    pdevTo.FE_CONTRATO = Convert.ToDateTime(rw["FECHA_PRE"]);
                    pdevTo.FE_AÑO = pdevTo.FE_AÑO;
                    pdevTo.FE_MES = pdevTo.FE_MES;
                    pdevTo.COD_PER = rw["COD_PER"].ToString();
                    pdevTo.NRO_LETRA = rw["NRO_LETRA"].ToString();
                    pdevTo.IMP_INI = Convert.ToDecimal(rw["IMP_INI"]);
                    pdevTo.IMPORTE = Convert.ToDecimal(rw["IMP_INI"]);
                    pdevTo.COD_NIVEL = rw["COD_NIVEL"].ToString();
                    pdevTo.COD_PER_SUP = rw["COD_COMISIONANTE"].ToString();
                    pdevTo.STATUS_CANCELADO = "0";
                    pdevTo.STATUS_CIERRE = "0";
                    pdevTo.STATUS_LIQUIDADO = "0";
                    pdevTo.NRO_FAC_PRE_UNI = rw["NRO_FAC_PRE_UNI"].ToString();
                    //P_Devolucion
                    if (!insertarPDevolucionBLL(pdevTo, ref errMensaje))
                        return result = false;
                    //T_Devolucion
                    if (!insertarTDevolucionBLL(pdevTo, ref errMensaje))
                        return result = false;
                    //I_Pedido
                    if (!modificarIPedidoxGeneracionDevolucionBLL(pdevTo, ref errMensaje))
                        return result = false;
                }
                ts.Complete();
                return result;
            }
        }
        public bool modificarIPedidoxGeneracionDevolucionBLL(pDevolucionTo pdevTo, ref string errMensaje)
        {
            bool result = true;
            contratoCabeceraBLL ccBLL = new contratoCabeceraBLL();
            contratoCabeceraTo ccTo = new contratoCabeceraTo();
            ccTo.NRO_FAC_PRE_UNI = pdevTo.NRO_FAC_PRE_UNI;
            if (!ccBLL.modificarIPedidoxGeneracionDevolucionBLL(ccTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool insertarTDevolucionBLL(pDevolucionTo pdevTo, ref string errMensaje)
        {
            bool result = true;
            tDevolucionBLL tdevBLL = new tDevolucionBLL();
            tDevolucionTo tdevTo = new tDevolucionTo();
            tdevTo.TIPO_VTA = pdevTo.TIPO_VTA;
            tdevTo.COD_PROGRAMA = pdevTo.COD_PROGRAMA;
            tdevTo.COD_VENDEDOR = pdevTo.COD_VENDEDOR;
            tdevTo.NRO_CONTRATO = pdevTo.NRO_CONTRATO;
            tdevTo.FE_AÑO = pdevTo.FE_AÑO;
            tdevTo.FE_MES = pdevTo.FE_MES;
            tdevTo.FE_DOC = pdevTo.FE_DOC;
            tdevTo.FE_CANC = null;
            tdevTo.COD_PER = pdevTo.COD_PER;
            tdevTo.IMPORTE = pdevTo.IMPORTE;
            tdevTo.NRO_LETRA = pdevTo.NRO_LETRA;
            tdevTo.COD_NIVEL = pdevTo.COD_NIVEL;
            tdevTo.COD_PER_SUP = pdevTo.COD_PER_SUP;
            tdevTo.TIPO_OPE = "GF";
            tdevTo.COD_D_H = "D";
            tdevTo.COD_CREA = pdevTo.COD_CREA;
            tdevTo.FECHA_CREA = pdevTo.FECHA_CREA;

            if (!tdevBLL.insertarTDevolucionBLL(tdevTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminaDevolucionesGeneradasBLL(pDevolucionTo pdevTo, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                //P_Devolucion
                if (!eliminarPDevolucionBLL(pdevTo, ref errMensaje))
                    return result = false;
                //T_Devolucion
                if (!eliminarTDevolucionBLL(pdevTo, ref errMensaje))
                    return result = false;
                //I_Pedido
                if (!modificarIPedidoxDevolucionGeneradaBLL(pdevTo, ref errMensaje))
                    return result = false;

                ts.Complete();
                return result;
            }
        }
        public bool eliminarPDevolucionBLL(pDevolucionTo pdevTo, ref string errMensaje)
        {
            bool result = true;
            if (!pdevDAL.eliminarPDevolucionDAL(pdevTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminarTDevolucionBLL(pDevolucionTo pdevTo, ref string errMensaje)
        {
            bool result = true;
            tDevolucionBLL tdevBLL = new tDevolucionBLL();
            tDevolucionTo tdevTo = new tDevolucionTo();
            tdevTo.NRO_CONTRATO = pdevTo.NRO_CONTRATO;

            if (!tdevBLL.eliminarTDevolucionBLL(tdevTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificarIPedidoxDevolucionGeneradaBLL(pDevolucionTo pdevTo, ref string errMensaje)
        {
            bool result = true;
            contratoCabeceraBLL ccBLL = new contratoCabeceraBLL();
            contratoCabeceraTo ccTo = new contratoCabeceraTo();
            ccTo.NRO_FAC_PRE_UNI = pdevTo.NRO_FAC_PRE_UNI;

            if (!ccBLL.modificarIPedidoxDevolucionGeneradaBLL(ccTo, ref errMensaje))
                return result = false;
            return result;
        }
        public DataTable obtenerDevolucionesPendientesxLiquidarBLL(pDevolucionTo pdevTo)
        {
            return pdevDAL.obtenerDevolucionesPendientesxLiquidarDAL(pdevTo);
        }
        public bool modificarPDevolucionxLiqDevolucionBLL(pDevolucionTo pdevTo, ref string errMensaje)
        {
            bool result = true;
            if (!pdevDAL.modificarPDevolucionxLiqDevolucionDAL(pdevTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool verificaExisteNroContratoLiquidadoBLL(pDevolucionTo pdevTo, ref bool val, ref string errMensaje)
        {
            bool result = true;
            if (!pdevDAL.verificaExisteNroContratoLiquidadoDAL(pdevTo, ref val, ref errMensaje))
                return result = false;
            return result;
        }
        public bool validaCierrePeriodoDevolucionGeneradaBLL(pDevolucionTo pdevTo, ref bool val, ref string errMensaje)
        {
            bool result = true;
            if (!pdevDAL.validaCierrePeriodoDevolucionGeneradaDAL(pdevTo, ref val, ref errMensaje))
                return result = false;
            return result;
        }
        public DataTable obtenerDevxExcesoContratoBLL(pDevolucionTo pdevTo)
        {
            return pdevDAL.obtenerDevxExcesoContratoDAL(pdevTo);
        }
        public DataTable obtenerDevxReclamoBLL(pDevolucionTo pdevTo)
        {
            return pdevDAL.obtenerDevxReclamoDAL(pdevTo);
        }
    }
}
