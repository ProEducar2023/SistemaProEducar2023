using DAL;
using Entidades;
using System;
using System.Data;
using System.Transactions;

namespace BLL
{
    public class planillaDirectaVariosBLL
    {
        planillaDirectaVariosDAL pdvDAL = new planillaDirectaVariosDAL();
        planillaDirectaVariosTo pdvTo = new planillaDirectaVariosTo();
        planillaDirectaVariosDetalleBLL pdvdBLL = new planillaDirectaVariosDetalleBLL();
        planillaDirectaVariosDetalleTo pdvdTo = new planillaDirectaVariosDetalleTo();

        public DataTable obtener_I_Planilla_Directa_Varios_BLL(planillaDirectaVariosTo pdvTo)
        {
            return pdvDAL.obtener_I_Planilla_Directa_Varios_DAL(pdvTo);
        }
        public bool adicionaNuevaPlanillaBLL(planillaDirectaVariosTo pdvTo, DataTable dtDetalle, DataTable dtDevCli, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                //insertar en I_PLANILLA_DIRECTA_VARIOS
                if (!insertar_I_PLANILLA_DIRECTA_VARIOS_BLL(pdvTo, ref errMensaje))
                    return result = false;
                //insertar en T_PLANILLA_DIRECTA_VARIOS
                if (!insertar_T_PLANILLA_DIRECTA_VARIOS_BLL(pdvTo, dtDetalle, ref errMensaje))
                    return result = false;
                //insertar en T_DEV_PLANILLA_DIRECTA_VARIOS
                if (dtDevCli != null)
                {
                    if (dtDevCli.Rows.Count > 0)
                    {
                        if (!insertar_T_DEV_PLANILLA_DIRECTA_VARIOS_BLL(pdvTo, dtDevCli, ref errMensaje))
                            return result = false;
                    }
                }
                //adiciona en uno el contador
                if (!HelpersBLL.estableceNuevoNumeroContador(pdvTo.COD_SUCURSAL, pdvTo.COD_DOC, pdvTo.STATUS_DOC, pdvTo.SERIE, ref errMensaje))
                    return result = false;

                ts.Complete();
                return result;
            }
        }
        private bool insertar_I_PLANILLA_DIRECTA_VARIOS_BLL(planillaDirectaVariosTo pdvTo, ref string errMensaje)
        {
            bool result = true;
            if (!pdvDAL.insertar_I_Planilla_Directa_Varios_DAL(pdvTo, ref errMensaje))
                return result = false;
            return result;
        }
        private bool modificar_I_PLANILLA_DIRECTA_VARIOS_BLL(planillaDirectaVariosTo pdvTo, ref string errMensaje)
        {
            bool result = true;
            if (!pdvDAL.modificar_I_Planilla_Directa_Varios_DAL(pdvTo, ref errMensaje))
                return result = false;
            return result;
        }
        private bool insertar_T_PLANILLA_DIRECTA_VARIOS_BLL(planillaDirectaVariosTo pdvTo, DataTable dt, ref string errMensaje)
        {
            bool result = true;
            foreach (DataRow rw in dt.Rows)
            {
                pdvdTo.NRO_PLANILLA_COB = pdvTo.NRO_PLANILLA_COB;
                pdvdTo.TIPO_PLANILLA = pdvTo.TIPO_PLANILLA;
                pdvdTo.FE_AÑO = pdvTo.FE_AÑO;
                pdvdTo.FE_MES = pdvTo.FE_MES;
                pdvdTo.NRO_CONTRATO = rw["NRO_CONTRATO"].ToString();
                pdvdTo.COD_PER = rw["COD_PER"].ToString();
                pdvdTo.TIPO_TARJETA = rw["TIPO_TARJETA"].ToString();
                pdvdTo.FE_1ER_PROCESO = Convert.ToDateTime(rw["FE_1ER_PROCESO"]);
                pdvdTo.MONTO_CUOTA = Convert.ToDecimal(rw["MONTO_CUOTA"]);
                pdvdTo.DSCTO_TARJETA = Convert.ToDecimal(rw["DSCTO_TARJETA"]);
                pdvdTo.PAGO_RECIBIDO = Convert.ToDecimal(rw["PAGO_VISA"]);
                pdvdTo.COD_CREACION = pdvTo.COD_CREACION;
                pdvdTo.FECHA_CREACION = pdvTo.FECHA_CREACION;

                if (!pdvdBLL.insertar_T_PLANILLA_DIRECTA_VARIOS_BLL(pdvdTo, ref errMensaje))
                    return result = false;
            }

            return result;
        }
        private bool insertar_T_DEV_PLANILLA_DIRECTA_VARIOS_BLL(planillaDirectaVariosTo pdvTo, DataTable dt, ref string errMensaje)
        {
            bool result = true;
            foreach (DataRow rw in dt.Rows)
            {
                pdvdTo.NRO_PLANILLA_COB = pdvTo.NRO_PLANILLA_COB;
                pdvdTo.TIPO_PLANILLA = pdvTo.TIPO_PLANILLA;
                pdvdTo.FE_AÑO = pdvTo.FE_AÑO;
                pdvdTo.FE_MES = pdvTo.FE_MES;
                pdvdTo.NRO_CONTRATO = rw["NRO_CONTRATO"].ToString();
                pdvdTo.COD_PER = rw["COD_PER"].ToString();
                pdvdTo.IMP_DEV = Convert.ToDecimal(rw["MONTO_DEV"]);
                pdvdTo.COD_CREACION = pdvTo.COD_CREACION;
                pdvdTo.FECHA_CREACION = pdvTo.FECHA_CREACION;

                if (!pdvdBLL.insertar_T_DEV_PLANILLA_DIRECTA_VARIOS_BLL(pdvdTo, ref errMensaje))
                    return result = false;
            }

            return result;
        }
        public bool modificaNuevaPlanillaBLL(planillaDirectaVariosTo pdvTo, DataTable dtDetalle, DataTable dtDevCli, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                //modificar en I_PLANILLA_DIRECTA_VARIOS
                if (!modificar_I_PLANILLA_DIRECTA_VARIOS_BLL(pdvTo, ref errMensaje))
                    return result = false;
                //eliminar T_PLANILLA_DIRECTA_VARIOS
                if (!eliminar_T_PLANILLA_DIRECTA_VARIOS_BLL(pdvTo, ref errMensaje))
                    return result = false;
                //insertar en T_PLANILLA_DIRECTA_VARIOS
                if (!insertar_T_PLANILLA_DIRECTA_VARIOS_BLL(pdvTo, dtDetalle, ref errMensaje))
                    return result = false;
                // T_DEV_PLANILLA_DIRECTA_VARIOS
                if (dtDevCli != null)
                {
                    if (dtDevCli.Rows.Count > 0)
                    {
                        //eliminar T_DEV_PLANILLA_DIRECTA_VARIOS
                        if (!eliminar_T_DEV_PLANILLA_DIRECTA_VARIOS_BLL(pdvTo, ref errMensaje))
                            return result = false;
                        //insertar en T_DEV_PLANILLA_DIRECTA_VARIOS
                        if (!insertar_T_DEV_PLANILLA_DIRECTA_VARIOS_BLL(pdvTo, dtDevCli, ref errMensaje))
                            return result = false;
                    }
                }

                ts.Complete();
                return result;
            }
        }
        private bool eliminar_T_PLANILLA_DIRECTA_VARIOS_BLL(planillaDirectaVariosTo pdvTo, ref string errMensaje)
        {
            bool result = true;
            pdvdTo.NRO_PLANILLA_COB = pdvTo.NRO_PLANILLA_COB;
            pdvdTo.TIPO_PLANILLA = pdvTo.TIPO_PLANILLA;
            pdvdTo.FE_AÑO = pdvTo.FE_AÑO;
            pdvdTo.FE_MES = pdvTo.FE_MES;
            if (!pdvdBLL.eliminar_T_PLANILLA_DIRECTA_VARIOS_BLL(pdvdTo, ref errMensaje))
                return result = false;
            return result;
        }
        private bool eliminar_T_DEV_PLANILLA_DIRECTA_VARIOS_BLL(planillaDirectaVariosTo pdvTo, ref string errMensaje)
        {
            bool result = true;
            pdvdTo.NRO_PLANILLA_COB = pdvTo.NRO_PLANILLA_COB;
            pdvdTo.TIPO_PLANILLA = pdvTo.TIPO_PLANILLA;
            pdvdTo.FE_AÑO = pdvTo.FE_AÑO;
            pdvdTo.FE_MES = pdvTo.FE_MES;
            if (!pdvdBLL.eliminar_T_DEV_PLANILLA_DIRECTA_VARIOS_BLL(pdvdTo, ref errMensaje))
                return result = false;
            return result;
        }
        public DataTable obtenerPlanillaDetalleDirectoVariosBLL(planillaDirectaVariosTo pdvTo)
        {
            return pdvDAL.obtenerPlanillaDetalleDirectoVariosDAL(pdvTo);
        }
        public bool aprobarPlanillasDirectaVariosBLL(planillaCabeceraTo pllcTo, planillaDirectaVariosTo pdvTo, DataTable dt, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                planillaCabeceraBLL pllacBLL = new planillaCabeceraBLL();
                //aquí cambié el orden como en descuento I, P y T antes era T, P y I
                //I_CTAS
                if (!pllacBLL.Aprueba_Actualiza_Repciona_I_CTAS_COBRAR_BLL(pllcTo, dt, ref errMensaje))
                    return result = false;
                //PCTAS
                if (!pllacBLL.Aprueba_Actualiza_Repciona_PCTAS_COBRAR_Planilla_Detalle_BLL(pllcTo, dt, ref errMensaje))//
                    return result = false;
                //TCTAS
                if (!pllacBLL.Aprueba_Adiciona_Repciona_T_Planilla_Detalle_BLL(pllcTo, dt, ref errMensaje))//
                    return result = false;
                //I_PLANILLA_DIRECTA_VARIOS
                if (!aprueba_Actualiza_I_PLANILLA_DIRECTA_VARIOS_BLL(pdvTo, ref errMensaje))
                    return result = false;
                // R_PLANILLA y RT_PLANILLA
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (i == 0)
                        dt.Rows[i]["IMP_COB"] = dt.Rows[i]["TOTAL_DEPOSITO"];
                    else
                        dt.Rows[i]["IMP_COB"] = "0.00";
                }
                if (!pllacBLL.Aprueba_Adiciona_Recepciona_R_Planilla_BLL(pllcTo, dt, ref errMensaje))
                    return result = false;
                //DEV_PCTAS_COBRAR y DEV_TCTAS_COBRAR
                if (!pllacBLL.Aprueba_Adiciona_DEV_PCTAS_COBRAR_BLL(pllcTo, dt, ref errMensaje))
                    return result = false;
                ts.Complete();
                return result;
            }
        }
        private bool aprueba_Actualiza_I_PLANILLA_DIRECTA_VARIOS_BLL(planillaDirectaVariosTo pdvTo, ref string errMensaje)
        {
            bool result = true;
            if (!pdvDAL.aprueba_Actualiza_I_PLANILLA_DIRECTA_VARIOS_DAL(pdvTo, ref errMensaje))
                return result = false;

            return result;
        }
    }
}
