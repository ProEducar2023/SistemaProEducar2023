using DAL;
using Entidades;
using System;
using System.Data;
using System.Transactions;
namespace BLL
{
    public class devPCtasCobrarBLL
    {
        devPCtasCobrarDAL dpcDAL = new devPCtasCobrarDAL();
        devTCtasCobrarBLL dtcBLL = new devTCtasCobrarBLL();
        devTCtasCobrarTo dtcTo = new devTCtasCobrarTo();

        public DataTable obtenerDevPCtasCobrarBLL(devPCtasCobrarTo dpcTo)
        {
            return dpcDAL.obtenerDevPCtasCobrarDAL(dpcTo);
        }
        public DataTable obtenerDevPCtasCobrarContratosExcesoCuotaBLL(devPCtasCobrarTo dpcTo)
        {
            return dpcDAL.obtenerDevPCtasCobrarContratosExcesoCuotaDAL(dpcTo);
        }
        public bool ingresarDevPctasCobrarOtrasDevolucionesDescuentosBLL(devPCtasCobrarTo dpcTo, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                //DEV_PCTAS_COBRAR
                if (!insertarDevPCtasCobrarBLL(dpcTo, ref errMensaje))
                    return result = false;
                //DEV_TCTAS_COBRAR
                if (!insertarDevTCtasCobrarBLL(dpcTo, ref errMensaje))
                    return result = false;
                //adiciona en uno el contador
                if (!estableceNuevoNumeroContador(dpcTo, ref errMensaje))
                    return result = false;

                ts.Complete();
                return result;
            }
        }
        public bool modificarDevPctasCobrarOtrasDevolucionesDescuentosBLL(devPCtasCobrarTo dpcTo, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                //DEV_PCTAS_COBRAR
                if (!modificarDevPCtasCobrarBLL(dpcTo, ref errMensaje))
                    return result = false;
                //DEV_TCTAS_COBRAR
                if (!actualizarDevTCtasCobrarBLL(dpcTo, ref errMensaje))
                    return result = false;

                ts.Complete();
                return result;
            }
        }
        public bool eliminarDevPctasCobrarOtrasDevolucionesDescuentosBLL(devPCtasCobrarTo dpcTo, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                //DEV_PCTAS_COBRAR
                if (!eliminarDevPCtasCobrarBLL(dpcTo, ref errMensaje))
                    return result = false;
                //DEV_TCTAS_COBRAR
                if (!eliminarDevTCtasCobrarBLL(dpcTo, ref errMensaje))
                    return result = false;

                ts.Complete();
                return result;
            }
        }
        private bool eliminarDevPCtasCobrarBLL(devPCtasCobrarTo dpcTo, ref string errMensaje)
        {
            bool result = true;
            if (!dpcDAL.eliminarDevPCtasCobrarDAL(dpcTo, ref errMensaje))
                return result = false;
            return result;
        }

        public bool eliminarDevPCtasCobrarRetBLL(devPCtasCobrarTo dpcTo, ref string errMensaje)
        {
            bool result = true;
            if (!dpcDAL.eliminarDevPCtasCobrarDAL(dpcTo, ref errMensaje))
                result = false;
            return result;
        }

        private bool eliminarDevTCtasCobrarBLL(devPCtasCobrarTo dpcTo, ref string errMensaje)
        {
            bool result = true;
            dtcTo.NRO_PLANILLA_COB = dpcTo.NRO_PLANILLA_COB;
            dtcTo.COD_SUCURSAL = dpcTo.COD_SUCURSAL;
            dtcTo.COD_CLASE = dpcTo.COD_CLASE;
            dtcTo.NRO_CONTRATO = dpcTo.NRO_CONTRATO;
            dtcTo.FE_AÑO = dpcTo.FE_AÑO;
            dtcTo.FE_MES = dpcTo.FE_MES;
            dtcTo.COD_D_H = dpcTo.COD_D_H;
            dtcTo.NRO_LETRA = dpcTo.NRO_LETRA;
            if (!dtcBLL.eliminarDevTCtasCobrarBLL(dtcTo, ref errMensaje))
                return result = false;
            return result;
        }
        private bool estableceNuevoNumeroContador(devPCtasCobrarTo dpcTo, ref string errMensaje)
        {
            bool result = true;
            serieDocumentoBLL sdBLL = new serieDocumentoBLL();
            serieDocumentosTo sdTo = new serieDocumentosTo();
            sdTo.COD_SUCURSAL = dpcTo.COD_SUCURSAL;
            sdTo.COD_DOC = "60";
            sdTo.STATUS_DOC = "0";
            sdTo.SERIE = dpcTo.SERIE;
            if (!sdBLL.adicionaNroSerieBLL(sdTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool insertarDevPCtasCobrarBLL(devPCtasCobrarTo dpcTo, ref string errMensaje)
        {
            bool result = true;
            if (!dpcDAL.insertarDevPCtasCobrarDAL(dpcTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool actualizarDevTCtasCobrarBLL(devPCtasCobrarTo dpcTo, ref string errMensaje)
        {
            bool result = true;

            dtcTo.NRO_PLANILLA_COB = dpcTo.NRO_PLANILLA_COB;
            dtcTo.COD_SUCURSAL = dpcTo.COD_SUCURSAL;
            dtcTo.COD_CLASE = dpcTo.COD_CLASE;
            dtcTo.NRO_CONTRATO = dpcTo.NRO_CONTRATO;
            dtcTo.FE_AÑO = dpcTo.FE_AÑO;
            dtcTo.FE_MES = dpcTo.FE_MES;
            dtcTo.COD_PER = dpcTo.COD_PER;
            dtcTo.DESC_PER = dpcTo.DESC_PER;
            dtcTo.COD_DOC = dpcTo.COD_DOC;
            dtcTo.NRO_DOC = dpcTo.NRO_DOC;
            dtcTo.FECHA_CONTRATO = dpcTo.FECHA_CONTRATO;
            dtcTo.FECHA_DOC = dpcTo.FECHA_DOC;
            dtcTo.FECHA_VEN = dpcTo.FECHA_VEN;
            dtcTo.COD_P_COBRANZA = "";
            dtcTo.COD_COBRADOR = "";
            dtcTo.NRO_PLANILLA = dtcTo.NRO_PLANILLA_COB;
            dtcTo.FECHA_PLANILLA = dtcTo.FECHA_DOC;
            dtcTo.COD_MOTIVO_NO_DESCONTADO = dpcTo.COD_MOTIVO_NO_DESCONTADO;
            dtcTo.COD_D_H = "D";
            dtcTo.COD_MONEDA = "S";
            dtcTo.TIPO_CAMBIO = 0;
            dtcTo.IMP_DOC = dpcTo.IMP_DOC;
            dtcTo.OBSERVACION = dpcTo.OBSERVACION;
            dtcTo.TIPO_OPE = "GF";
            dtcTo.NRO_LETRA = "000";
            dtcTo.TOTAL_LETRA = "000";
            dtcTo.COD_CONCEPTO = "";
            dtcTo.TIPO_PLA_ORIGEN = dpcTo.TIPO_PLA_ORIGEN;
            dtcTo.TIPO_PLA_COBRANZA = dpcTo.TIPO_PLA_COBRANZA;
            dtcTo.COD_USU_MOD = dpcTo.COD_USU_MOD;
            dtcTo.FECHA_MOD = dpcTo.FECHA_MOD;

            if (!dtcBLL.modificarDevTCtasCobrarBLL(dtcTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool insertarDevTCtasCobrarBLL(devPCtasCobrarTo dpcTo, ref string errMensaje)
        {
            bool result = true;
            devTCtasCobrarBLL dtcBLL = new devTCtasCobrarBLL();
            devTCtasCobrarTo dtcTo = new devTCtasCobrarTo();
            dtcTo.NRO_PLANILLA_COB = dpcTo.NRO_PLANILLA_COB;
            dtcTo.COD_SUCURSAL = dpcTo.COD_SUCURSAL;
            dtcTo.COD_CLASE = dpcTo.COD_CLASE;
            dtcTo.NRO_CONTRATO = dpcTo.NRO_CONTRATO;
            dtcTo.FE_AÑO = dpcTo.FE_AÑO;
            dtcTo.FE_MES = dpcTo.FE_MES;
            dtcTo.COD_PER = dpcTo.COD_PER;
            dtcTo.DESC_PER = dpcTo.DESC_PER;
            dtcTo.COD_DOC = dpcTo.COD_DOC;
            dtcTo.NRO_DOC = dpcTo.NRO_DOC;
            dtcTo.FECHA_CONTRATO = dpcTo.FECHA_CONTRATO;
            dtcTo.FECHA_DOC = dpcTo.FECHA_DOC;
            dtcTo.FECHA_VEN = dpcTo.FECHA_VEN;
            dtcTo.COD_P_COBRANZA = "";
            dtcTo.COD_COBRADOR = "";
            dtcTo.NRO_PLANILLA = dtcTo.NRO_PLANILLA_COB;
            dtcTo.FECHA_PLANILLA = dtcTo.FECHA_DOC;
            dtcTo.COD_MOTIVO_NO_DESCONTADO = dpcTo.COD_MOTIVO_NO_DESCONTADO;
            dtcTo.COD_D_H = "D";
            dtcTo.COD_MONEDA = "S";
            dtcTo.TIPO_CAMBIO = 0;
            dtcTo.IMP_DOC = dpcTo.IMP_DOC;
            dtcTo.OBSERVACION = dpcTo.OBSERVACION;
            dtcTo.TIPO_OPE = "GF";
            dtcTo.NRO_LETRA = "000";
            dtcTo.TOTAL_LETRA = "000";
            dtcTo.COD_CONCEPTO = "";
            dtcTo.TIPO_PLA_ORIGEN = dpcTo.TIPO_PLA_ORIGEN;
            dtcTo.TIPO_PLA_COBRANZA = dpcTo.TIPO_PLA_COBRANZA;
            dtcTo.COD_USU_CREA = dpcTo.COD_USU_CREA;
            dtcTo.FECHA_CREA = dpcTo.FECHA_CREA;

            if (!dtcBLL.insertarDevTCtasCobrarBLL(dtcTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool Verifica_Contratos_Exceso_CuotaBLL(devPCtasCobrarTo dpcTo, ref string errMensaje)
        {
            bool result = true;
            if (!dpcDAL.Verifica_Contratos_Exceso_CuotaDAL(dpcTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificarDevPCtasCobrarBLL(devPCtasCobrarTo dpcTo, ref string errMensaje)
        {
            bool result = true;
            if (!dpcDAL.modificarDevPCtasCobrarDAL(dpcTo, ref errMensaje))
                return result = false;
            return result;
        }
        public decimal mostrar_suma_exceso_contrato_kardexBLL(devPCtasCobrarTo dpcTo, ref string errMensaje)
        {
            return dpcDAL.mostrar_suma_exceso_contrato_kardexDAL(dpcTo, ref errMensaje);
        }
        public DataTable obtenerDevPCtasCobrarTransferenciaBLL(devPCtasCobrarTo dpcTo)
        {
            return dpcDAL.obtenerDevPCtasCobrarTransferenciaDAL(dpcTo);
        }
        public bool Grabar_Transferencia_DevolucionesBLL(devPCtasCobrarTo dpcTo, DataTable dt, ref string errMensaje)
        {
            bool result = true;
            foreach (DataRow rw in dt.Rows)
            {
                dpcTo.NRO_PLANILLA_COB = rw["NRO_PLANILLA_COB_DEV"].ToString();
                dpcTo.COD_SUCURSAL = rw["COD_SUCURSAL_DEV"].ToString();
                dpcTo.COD_CLASE = rw["COD_CLASE_DEV"].ToString();
                dpcTo.NRO_CONTRATO = rw["NRO_CONTRATO_DEV"].ToString();
                dpcTo.FE_AÑO = rw["FE_AÑO_DEV"].ToString();
                dpcTo.FE_MES = rw["FE_MES_DEV"].ToString();
                dpcTo.COD_D_H = rw["COD_D_H_DEV"].ToString();
                dpcTo.NRO_LETRA = rw["NRO_LETRA_DEV"].ToString();
                if (!dpcDAL.Grabar_Transferencia_DevolucionesDAL(dpcTo, ref errMensaje))
                    return result = false;
            }

            return result;
        }
        public DataTable obtenerDevPCtasCobrarIngresoOtrosDevDsctosBLL(devPCtasCobrarTo dpcTo)
        {
            return dpcDAL.obtenerDevPCtasCobrarIngresoOtrosDevDsctosDAL(dpcTo);
        }
        public bool actualizaDevPCtasCobrarOtrasDevDsctosBLL(devPCtasCobrarTo dpcTo, ref string errMensaje)
        {
            bool result = true;
            if (!dpcDAL.actualizaDevPCtasCobrarOtrasDevDsctosDAL(dpcTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool actualizaDevPCtasCobrarOtrasDevDsctosxCierreBLL(devPCtasCobrarTo dpcTo, ref string errMensaje)
        {
            bool result = true;
            if (!dpcDAL.actualizaDevPCtasCobrarOtrasDevDsctosxCierreDAL(dpcTo, ref errMensaje))
                return result = false;
            return result;
        }

        public bool actualizaDevPctasCobrarxEliminacionPllaBLL(devPCtasCobrarTo dpcTo, ref string errMensaje)
        {
            bool result = true;
            if (!dpcDAL.actualizaDevPctasCobrarxEliminacionPllaDAL(dpcTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminarDevTctasCobrarxEliminacionPllaBLL(devPCtasCobrarTo dpcTo, ref string errMensaje)
        {
            bool result = true;
            if (!dpcDAL.eliminarDevTctasCobrarxEliminacionPllaDAL(dpcTo, ref errMensaje))
                return result = false;
            return result;
        }

        public bool ActualizarDevPctasCobrarBLL(devPCtasCobrarTo dpcto, ref string errMensaje)
        {
            if (!dpcDAL.ActualizarDevPctasCobrarDAL(dpcto, ref errMensaje))
                return false;
            return true;
        }
    }
}
