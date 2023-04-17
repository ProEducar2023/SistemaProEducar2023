using DAL;
using Entidades;
using System;
using System.Data;
using System.Transactions;
namespace BLL
{
    public class descuentoDirectoBLL
    {
        descuentoDirectaDAL ddDAL = new descuentoDirectaDAL();
        public DataTable obtenerDescuentoDirectaBLL()
        {
            return ddDAL.obtenerDescuentoDirectaDAL();
        }
        public bool insertarDescuentoDirectaBLL(descuentoDirectaTo ddTo, ref string errMensaje)
        {
            bool result = true;
            if (!ddDAL.insertarDescuentoDirectaDAL(ddTo, ref errMensaje))
                return result = false;
            return result;
        }
        public DataTable obtenerContratos_x_AsignarBLL(descuentoDirectaTo ddTo)
        {
            return ddDAL.obtenerContratos_x_AsignarDAL(ddTo);
        }
        public DataTable obtenerContratos_x_Asignar_CuotasBLL(descuentoDirectaTo ddTo)
        {
            return ddDAL.obtenerContratos_x_Asignar_CuotasDAL(ddTo);
        }
        public DataTable obtenerKardexContratosDirectosBLL(descuentoDirectaTo ddTo)
        {
            return ddDAL.obtenerKardexContratosDirectosDAL(ddTo);
        }
        public DataTable obtenerSeguimiento_x_NroCotratoBLL(descuentoDirectaTo ddTo)
        {
            return ddDAL.obtenerSeguimiento_x_NroCotratoDAL(ddTo);
        }
        public DataTable obtenerCantidadGestoresporLlamarBLL()
        {
            return ddDAL.obtenerCantidadGestoresporLlamarDAL();
        }
        public bool adiciona_ILlamadas_CobranzaDirectaBLL(descuentoDirectaTo ddTo, DataTable dt, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                //I_Llamadas
                if (!insertarILlamadasBLL(ddTo, dt, ref errMensaje))
                    return result = false;


                ts.Complete();
                return result;
            }
        }
        private bool insertarILlamadasBLL(descuentoDirectaTo ddTo, DataTable dt, ref string errMensaje)
        {
            bool result = true;
            foreach (DataRow rw in dt.Rows)
            {
                ddTo.NRO_CONTRATO = rw["NRO_CONTRATO"].ToString();
                ddTo.COD_PERSONA = rw["COD_PER"].ToString();
                //ddTo.FE_AÑO = rw[""].ToString();
                //ddTo.FE_MES = rw[""].ToString();
                ddTo.FECHA_CONTRATO = Convert.ToDateTime(rw["FE_CONTRATO"]);
                //ddTo.COD_SECTORISTA = rw[""].ToString();
                ddTo.COD_GESTOR = rw["COD_GESTOR"].ToString();
                //ddTo.MESES_MOROSIDAD = rw[""].ToString();
                ddTo.FECHA_LLAMADA = Convert.ToDateTime(rw["FEC_LLAMADA1"]);
                ddTo.FECHA_NUEVA_LLAMADA = null;
                ddTo.COD_SUCURSAL = rw["COD_SUCURSAL"].ToString();
                ddTo.COD_CLASE = rw["COD_CLASE"].ToString();
                //I_Llamadas
                if (!insertarDescuentoDirectaBLL(ddTo, ref errMensaje))
                    return result = false;
                //I_Ctas_Cobrar
                if (!actualizaICtasCobrar(ddTo, ref errMensaje))
                    return result = false;
            }
            return result;
        }
        private bool actualizaICtasCobrar(descuentoDirectaTo ddTo, ref string errMensaje)
        {
            canjeICtasxCobrarBLL ccBLL = new canjeICtasxCobrarBLL();
            canjeICtasxCobrarTo ccTo = new canjeICtasxCobrarTo();
            ccTo.COD_SUCURSAL = ddTo.COD_SUCURSAL;
            ccTo.COD_CLASE = ddTo.COD_CLASE;
            ccTo.NRO_CONTRATO = ddTo.NRO_CONTRATO;
            ccTo.STATUS_TRANSF_DIRECTA = "1";
            bool result = true;
            if (!ccBLL.actualizaICtasCobrarxCobranzaDirectaBLL(ccTo, ref errMensaje))
                return result = false;
            return result;
        }
        public DataTable obtenerContratos_x_LlamarBLL(descuentoDirectaTo ddTo)
        {
            return ddDAL.obtenerContratos_x_LlamarDAL(ddTo);
        }
        public bool cierraDescuentoDirectaBLL(descuentoDirectaTo ddTo, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;

                //DataTable dtContratos = obtenerContratosparaCierrexFechaActivaBLL(ddTo);
                //cierra los registros del dia de I_Llamadas
                if (!modificaDescuentoDirectaporCierreBLL(ddTo, ref errMensaje))//De las llamadas que se registraron ese dia, en su fecha llamada se actualiza con la fecha nueva llamada que puso en el formulario llamadas
                    return result = false;
                //actualiza status_cancelado segun el contrato este pagado en su totalidad
                if (!modificaDescuentoDirectaporStatusCanceladoBLL(ddTo, ref errMensaje))
                    return result = false;
                //actualizacion de la fecha Activa
                if (!actualizaFechaActivaBLL(ddTo, ref errMensaje))
                    return result = false;

                ts.Complete();
                return result;
            }
        }
        public DataTable obtenerContratosparaCierrexFechaActivaBLL(descuentoDirectaTo ddTo)
        {
            return ddDAL.obtenerContratosparaCierrexFechaActivaDAL(ddTo);
        }
        private bool modificaDescuentoDirectaporStatusCanceladoBLL(descuentoDirectaTo ddTo, ref string errMensaje)

        {
            bool result = true;
            if (!ddDAL.modificaDescuentoDirectaporStatusCanceladoDAL(ddTo, ref errMensaje))
                return result;
            return result;
        }
        private bool modificaDescuentoDirectaporCierreBLL(descuentoDirectaTo ddTo, ref string errMensaje)
        {
            bool result = true;
            if (!ddDAL.modificaDescuentoDirectaporCierreDAL(ddTo, ref errMensaje))
                return result = false;
            return result;
        }
        //private bool modificaDescuentoDirectaporCierreBLL(DataTable dt, descuentoDirectaTo ddTo,ref string errMensaje)
        //{
        //    bool result = true;
        //    foreach(DataRow rw in dt.Rows)
        //    {
        //        ddTo.NRO_CONTRATO = rw["NRO_CONTRATO"].ToString();
        //        if (!ddDAL.modificaDescuentoDirectaporCierreDAL(ddTo, ref errMensaje))
        //            return result = false;
        //    }

        //    return result;
        //}
        public bool modificarDescuentoDirectaxLlamadasBLL(descuentoDirectaTo ddTo, ref string errMensaje)
        {
            bool result = true;
            if (!ddDAL.modificarDescuentoDirectaxLlamadasDAL(ddTo, ref errMensaje))
                return result = false;
            return result;
        }
        private bool actualizaFechaActivaBLL(descuentoDirectaTo ddTo, ref string errMensaje)
        {
            bool result = true;
            calendarioBLL calBLL = new calendarioBLL();
            calendarioTo calTo = new calendarioTo();
            DateTime fec = ddTo.FECHA_LLAMADA;//pldTo.FECHA_VEN;
            fec = fec.AddDays(1);
            while (esFeriado(fec, ref errMensaje))
            {
                fec = fec.AddDays(1);
            }
            if (errMensaje == "")
            {
                calTo.FECHA_ACTIVA = fec;
                calTo.COD_MOD = ddTo.COD_USU_MOD; //pldTo.COD_CREACION;
                calTo.FECHA_MOD = ddTo.FECHA_USU_MOD;//pldTo.FECHA_CREACION;
                //pldTo.FECHA_LLAMADA = calTo.FECHA_ACTIVA;//para que cuando cierre la fecha llamada en T_Planilla_Directa sea esa fecha del dia siguiente
                //pldTo.FECHA_NUEVA_LLAMADA = fec;//se  prepara para actualizar las llamadas que no se hicieron en T_Planilla_Directa de la fecha activa actual
                calTo.TIPO = "D";//pldTo.TIPO;
                if (!calBLL.modificarFechaActivaBLL(calTo, ref errMensaje))
                    return result = false;
            }
            else
            {
                return result = false;
            }

            return result;
        }
        public bool esFeriado(DateTime fec, ref string errMensaje)
        {
            bool result = true;
            if (!ddDAL.esFeriadoDAL(fec, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificarDescuentoDirectaxVerificacionBLL(descuentoDirectaTo ddTo, ref string errMensaje)
        {
            bool result = true;
            if (!ddDAL.modificarDescuentoDirectaxVerificacionDAL(ddTo, ref errMensaje))
                return result = false;
            return result;
        }
    }

}
