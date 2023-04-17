using DAL;
using Entidades;
using System;
using System.Data;
using System.Transactions;
namespace BLL
{
    public class pComisionBLL
    {
        pComisionDAL pcomDAL = new pComisionDAL();

        public DataTable obtenerPComisionBLL(pComisionTo pcomTo)
        {
            return pcomDAL.obtenerPComisionDAL(pcomTo);
        }
        public bool adicionaNuevaComisionBLL(pComisionTo pcomTo, DataTable dtComision, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;

                if (!ingresarComisionesBLL(pcomTo, dtComision, ref errMensaje))
                    return result = false;
                ts.Complete();
                return result;
            }
        }
        public bool ingresarComisionesBLL(pComisionTo pcomTo, DataTable dt, ref string errMensaje)
        {
            bool result = true;
            foreach (DataRow rw in dt.Rows)
            {
                pcomTo.TIPO_VTA = rw["TIPO_PLANILLA"].ToString();
                pcomTo.COD_PROGRAMA = rw["COD_PROGRAMA"].ToString();
                pcomTo.COD_VENDEDOR = rw["COD_VENDEDOR"].ToString();
                pcomTo.NRO_CONTRATO = rw["NRO_PRESUPUESTO"].ToString();
                pcomTo.FE_CONTRATO = Convert.ToDateTime(rw["FECHA_PRE"]);
                pcomTo.FE_APROB = rw["FECHA_APROB"].ToString() == "" ? (DateTime?)null : Convert.ToDateTime(rw["FECHA_APROB"]);
                pcomTo.FE_DOC = DateTime.Now;
                pcomTo.COD_PER = rw["COD_PER"].ToString();
                pcomTo.NRO_LETRA = rw["CUOTA"].ToString();
                pcomTo.COD_NIVEL = rw["COD_NIVEL"].ToString();
                pcomTo.COD_PER_SUP = rw["COD_PER_SUP"].ToString();
                pcomTo.IMPORTE = Convert.ToDecimal(rw["IMPORTE"]);
                pcomTo.IMP_FIN = Convert.ToDecimal(rw["IMPORTE"]);
                if (rw["STATUS_PRE_APROB"].ToString() == "1" && rw["CUOTA"].ToString() == "001")
                    pcomTo.STATUS_PRE_APROB = "1";
                else
                    pcomTo.STATUS_PRE_APROB = "0";
                //PComision 
                if (!insertarPComisionBLL(pcomTo, ref errMensaje))
                    return result = false;
                //TComision   
                if (!insertarTComisionBLL(pcomTo, ref errMensaje))
                    return result = false;
                //modificar I_Pedido
                if (!modificarIPedidoBLL(pcomTo, ref errMensaje))
                    return result = false;
            }
            return result;
        }
        public bool modificarIPedidoBLL(pComisionTo pcomTo, ref string errMensaje)
        {
            contratoCabeceraBLL conBLL = new contratoCabeceraBLL();
            contratoCabeceraTo conTo = new contratoCabeceraTo();
            bool result = true;
            conTo.NRO_PRESUPUESTO = pcomTo.NRO_CONTRATO;
            if (!conBLL.modificarIPedidoBLL(conTo, ref errMensaje))
                return result = false;
            return result;
        }
        public DataTable obtenerContratosporPeriodoBLL(pComisionTo pcomTo)
        {
            return pcomDAL.obtenerContratosporPeriodoDAL(pcomTo);
        }
        public bool insertarPComisionBLL(pComisionTo pcomTo, ref string errMensaje)
        {
            bool result = true;
            if (!pcomDAL.insertarPComisionDAL(pcomTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool insertarTComisionBLL(pComisionTo pcomTo, ref string errMensaje)
        {
            bool result = true;
            tComisionBLL tcomBLL = new tComisionBLL();
            tComisionTo tcomTo = new tComisionTo();
            tcomTo.TIPO_VTA = pcomTo.TIPO_VTA;
            tcomTo.COD_PROGRAMA = pcomTo.COD_PROGRAMA;
            tcomTo.COD_VENDEDOR = pcomTo.COD_VENDEDOR;
            tcomTo.NRO_CONTRATO = pcomTo.NRO_CONTRATO;
            tcomTo.FE_AÑO = pcomTo.FE_AÑO;
            tcomTo.FE_MES = pcomTo.FE_MES;
            tcomTo.FE_DOC = pcomTo.FE_DOC;
            tcomTo.FE_CANC = null;
            tcomTo.FE_APROB = pcomTo.FE_APROB;
            tcomTo.COD_PER = pcomTo.COD_PER;
            tcomTo.IMPORTE = pcomTo.IMPORTE;
            tcomTo.NRO_LETRA = pcomTo.NRO_LETRA;
            tcomTo.COD_NIVEL = pcomTo.COD_NIVEL;
            tcomTo.COD_PER_SUP = pcomTo.COD_PER_SUP;
            tcomTo.TIPO_OPE = "GD";
            tcomTo.NRO_PLANILLA = "";
            tcomTo.FE_PLANILLA = null;
            tcomTo.COD_D_H = "D";
            tcomTo.COD_CREA = pcomTo.COD_CREA;
            tcomTo.FECHA_CREA = pcomTo.FECHA_CREA;
            if (!tcomBLL.insertarTComisionBLL(tcomTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminaComisionBLL(pComisionTo pcomTo, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;

                //PComision
                if (!eliminarPComisionBLL(pcomTo, ref errMensaje))
                    return result = false; ;
                //TComision
                if (!eliminarTComisionBLL(pcomTo, ref errMensaje))
                    return result = false;
                //IPedido
                if (!modificar_IPedido_por_NroContratoBLL(pcomTo, ref errMensaje))
                    return result = false;
                ts.Complete();
                return result;
            }
        }
        public bool verificaExisteNroContratoLiquidadoBLL(pComisionTo pcomTo, ref bool val, ref string errMensaje)
        {
            bool result = true;
            if (!pcomDAL.verificaExisteNroContratoLiquidadoDAL(pcomTo, ref val, ref errMensaje))
                return result = false;
            return result;
        }
        private bool modificar_IPedido_por_NroContratoBLL(pComisionTo pcomTo, ref string errMensaje)
        {
            bool result = true;
            contratoCabeceraBLL conBLL = new contratoCabeceraBLL();
            contratoCabeceraTo conTo = new contratoCabeceraTo();
            conTo.NRO_PRESUPUESTO = pcomTo.NRO_CONTRATO;
            if (!conBLL.modificar_IPedido_por_NroContratoBLL(conTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminarPComisionBLL(pComisionTo pcomTo, ref string errMensaje)
        {
            bool result = true;
            if (!pcomDAL.eliminarPComisionDAL(pcomTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminarTComisionBLL(pComisionTo pcomTo, ref string errMensaje)
        {
            bool result = true;
            tComisionBLL tcomBLL = new tComisionBLL();
            tComisionTo tcomTo = new tComisionTo();
            tcomTo.NRO_CONTRATO = pcomTo.NRO_CONTRATO;
            if (!tcomBLL.eliminarTComisionBLL(tcomTo, ref errMensaje))
                return result = false;
            return result;
        }
        public DataTable obtenerPComisionPorPeriodoBLL(pComisionTo pcomTo)
        {
            return pcomDAL.obtenerPComisionPorPeriodoDAL(pcomTo);
        }
        public DataTable obtenerPComisionDif000BLL(pComisionTo pcomTo)
        {
            return pcomDAL.obtenerPComisionDif000DAL(pcomTo);
        }
        public bool modificarPComisionxLiqComisionBLL(pComisionTo pcomTo, ref string errMensaje)
        {
            bool result = true;
            if (!pcomDAL.modificarPComisionxLiqComisionDAL(pcomTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificarPComisionxLiqComision_EliminarBLL(pComisionTo pcomTo, ref string errMensaje)
        {
            bool result = true;
            if (!pcomDAL.modificarPComisionxLiqComision_EliminarDAL(pcomTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificarPComisionBLL(pComisionTo pcomTo, ref string errMensaje)
        {
            bool result = true;
            if (!pcomDAL.modificarPComisionDAL(pcomTo, ref errMensaje))
                return result = false;
            return result;
        }
        public DataTable obtenerComisionesPendientesBLL(pComisionTo pcoTo)
        {
            return pcomDAL.obtenerComisionesPendientesDAL(pcoTo);
        }
        public DataTable obtenerComisionesHistoricosBLL(pComisionTo pcoTo)
        {
            return pcomDAL.obtenerComisionesHistoricosDAL(pcoTo);
        }
        public DataTable obtenerComisionesPendientesxContratoBLL(pComisionTo pcoTo)
        {
            return pcomDAL.obtenerComisionesPendientesxContratoDAL(pcoTo);
        }
        public DataTable obtenerPLiquidacionporPeriodoBLL(pComisionTo pcoTo)
        {
            return pcomDAL.obtenerPLiquidacionporPeriodoDAL(pcoTo);
        }
        public bool validaCierrePeriodoComisionGeneradaBLL(pComisionTo pcoTo, ref bool val, ref string errMensaje)
        {
            bool result = true;
            if (!pcomDAL.validaCierrePeriodoComisionGeneradaDAL(pcoTo, ref val, ref errMensaje))
                return result = false;
            return result;
        }
    }
}
