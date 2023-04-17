using DAL;
using Entidades;
using System;
using System.Data;
using System.Transactions;

namespace BLL
{
    public class descuentoDirectaSeguimientoBLL
    {
        descuentoDirectaSeguimientoDAL dsDAL = new descuentoDirectaSeguimientoDAL();

        public DataTable obtenerDescuentoDirectaSeguimientoBLL(descuentoDirectaSeguimientoTo dsTo)
        {
            return dsDAL.obtenerDescuentoDirectaSeguimientoDAL(dsTo);
        }
        public bool ingresarDescuentoDirectaSeguimientoBLL(descuentoDirectaSeguimientoTo dsTo, ref string errMensaje)
        {
            bool result = true;
            if (!dsDAL.ingresarDescuentoDirectaSeguimientoDAL(dsTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificarDescuentoDirectaSeguimientoBLL(descuentoDirectaSeguimientoTo dsTo, ref string errMensaje)
        {
            bool result = true;
            if (!dsDAL.modificarDescuentoDirectaSeguimientoDAL(dsTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool adicionaLlamadasSeguimientoBLL(descuentoDirectaSeguimientoTo dsTo, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                //I_Llamadas modificar Nueva Llamada
                if (!modificarDescuentoDirectaxLlamadasBLL(dsTo, ref errMensaje))
                    return result = false;
                //I_Llamadas_Seguimiento
                if (!ingresarDescuentoDirectaSeguimientoBLL(dsTo, ref errMensaje))
                    return result = false;

                ts.Complete();
                return result;
            }
        }
        public bool modificarDescuentoDirectaxLlamadasBLL(descuentoDirectaSeguimientoTo dsTo, ref string errMensaje)
        {
            bool result = true;
            descuentoDirectoBLL ddBLL = new descuentoDirectoBLL();
            descuentoDirectaTo ddTo = new descuentoDirectaTo();
            ddTo.NRO_CONTRATO = dsTo.NRO_CONTRATO;
            ddTo.COD_MOTIVO_LLAMADA = dsTo.COD_MOTIVO_LLAMADA;
            ddTo.FECHA_NUEVA_LLAMADA = dsTo.FECHA_COMPROMISO_PAGO;
            ddTo.COD_USU_MOD = dsTo.COD_USU;
            ddTo.FECHA_USU_MOD = dsTo.FEC_COD_USU;
            if (!ddBLL.modificarDescuentoDirectaxLlamadasBLL(ddTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificarLlamadasSeguimientoBLL(descuentoDirectaSeguimientoTo dsTo, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                //I_Llamadas modificar Nueva Llamada
                if (!modificarDescuentoDirectaxLlamadasBLL(dsTo, ref errMensaje))
                    return result = false;
                //eliminar I_Llamadas_Seguimiento
                if (!eliminarDescuentoDirectaxLlamadasBLL(dsTo, ref errMensaje))
                    return result = false;
                //I_Llamadas_Seguimiento
                if (!ingresarDescuentoDirectaSeguimientoBLL(dsTo, ref errMensaje))
                    return result = false;

                ts.Complete();
                return result;
            }
        }
        private bool eliminarDescuentoDirectaxLlamadasBLL(descuentoDirectaSeguimientoTo dsTo, ref string errMensaje)
        {
            bool result = true;
            if (!dsDAL.eliminarDescuentoDirectaxLlamadasDAL(dsTo, ref errMensaje))
                return result = false;
            return result;
        }
        public DataTable obtenerContratosparaVerificarLlamadasBLL(descuentoDirectaSeguimientoTo dsTo)
        {
            return dsDAL.obtenerContratosparaVerificarLlamadasDAL(dsTo);
        }
        public bool adicionaDatosparaValidacionLLamadasBLL(descuentoDirectaSeguimientoTo dsTo, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                if (dsTo.COD_MOTIVO_LLAMADA == "06")//No Abonado
                {
                    //I_Llamadas modificar Fecha_LLamada con la llamada elegida en la verificacion
                    if (!modificarDescuentoDirectaxVerificacionBLL(dsTo, ref errMensaje))
                        return result;
                }
                //else if (dsTo.COD_MOTIVO_LLAMADA == "05" || dsTo.COD_MOTIVO_LLAMADA == "07")
                //{
                //    //I_Llamadas_Seguimiento modifica Status_Confirmacion_Pago
                //    if (!modificarDescuentoDirectaxSeguimientoVerificacionBLL(dsTo, ref errMensaje))
                //        return result;
                //}
                //I_Llamadas_Seguimiento modifica Status_Confirmacion_Pago
                if (!modificarDescuentoDirectaxSeguimientoVerificacionBLL(dsTo, ref errMensaje))
                    return result;
                //I_Llamadas_Seguimiento
                if (!ingresarDescuentoDirectaSeguimientoBLL(dsTo, ref errMensaje))
                    return result = false;

                ts.Complete();
                return result;
            }
        }
        private bool modificarDescuentoDirectaxVerificacionBLL(descuentoDirectaSeguimientoTo dsTo, ref string errMensaje)
        {
            bool result = true;
            descuentoDirectoBLL ddBLL = new descuentoDirectoBLL();
            descuentoDirectaTo ddTo = new descuentoDirectaTo();
            ddTo.NRO_CONTRATO = dsTo.NRO_CONTRATO;
            ddTo.COD_PERSONA = dsTo.COD_PERSONA;
            ddTo.FECHA_LLAMADA = dsTo.FECHA_COMPROMISO_PAGO.Value;
            ddTo.COD_USU_MOD = dsTo.COD_USU;
            ddTo.FECHA_USU_MOD = dsTo.FEC_COD_USU;
            if (!ddBLL.modificarDescuentoDirectaxVerificacionBLL(ddTo, ref errMensaje))
                return result = false;
            return result;
        }
        private bool modificarDescuentoDirectaxSeguimientoVerificacionBLL(descuentoDirectaSeguimientoTo dsTo, ref string errMensaje)
        {
            bool result = true;
            if (!dsDAL.modificarDescuentoDirectaxSeguimientoVerificacionDAL(dsTo, ref errMensaje))
                return result = false;
            return result;
        }
        public DataTable obtener_llamadas_seguimiento_para_R_PlanillaBLL(descuentoDirectaSeguimientoTo dsTo)
        {
            return dsDAL.obtener_llamadas_seguimiento_para_R_PlanillaDAL(dsTo);
        }

    }
}
