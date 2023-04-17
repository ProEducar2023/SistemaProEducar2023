using DAL;
using Entidades;
using System;
using System.Data;
using System.Transactions;
namespace BLL
{
    public class facturacionVtaCabeceraBLL
    {
        facturacionVtaCabeceraDAL fvtaDAL = new facturacionVtaCabeceraDAL();

        public DataTable obtenerFacturacionCabeceraBLL(facturacionVtaCabeceraTo fvtaTo)
        {
            return fvtaDAL.obtenerFacturacionCabeceraDAL(fvtaTo);
        }
        public bool adicionaFacturacionVentaBLL(facturacionVtaCabeceraTo fvtaTo, DataTable dt, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;

                if (!insertarBulkCopyFactVtaDetBLL(dt, ref errMensaje))
                    return result = false;

                if (!insertarFacturacionCabeceraBLL(fvtaTo, ref errMensaje))
                    return result = false;
                //

                ts.Complete();
                return result;
            }
        }
        public bool adicionaFacturacionVentaDI_BLL(facturacionVtaCabeceraTo fvtaTo, DataTable dt, ref string errMensaje)
        {   //FACTURACION DIRECTA SERVICIO
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;

                if (!insertarBulkCopyFactVtaDetBLL(dt, ref errMensaje))
                    return result = false;

                if (!insertarFacturacionCabeceraDI_BLL(fvtaTo, ref errMensaje))
                    return result = false;

                ts.Complete();
                return result;
            }
        }
        public bool insertarBulkCopyFactVtaDetBLL(DataTable dt, ref string errMensaje)
        {
            bool result = true;
            if (!fvtaDAL.insertarBulkCopyFactVtaDetDAL(dt, ref errMensaje))
                return result = false;
            return result;
        }
        public bool insertarFacturacionCabeceraBLL(facturacionVtaCabeceraTo fvtaTo, ref string errMensaje)
        {
            bool result = true;
            if (!fvtaDAL.insertarFacturacionCabeceraDAL(fvtaTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool insertarFacturacionCabeceraDI_BLL(facturacionVtaCabeceraTo fvtaTo, ref string errMensaje)
        {
            bool result = true;
            if (!fvtaDAL.insertarFacturacionCabeceraDI_DAL(fvtaTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificarFacturacionCabeceraBLL(facturacionVtaCabeceraTo fvtaTo, ref string errMensaje)
        {
            bool result = true;
            if (!fvtaDAL.modificarFacturacionCabeceraBLL(fvtaTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool anularFacturacionCabeceraBLL(facturacionVtaCabeceraTo fvtaTo, ref string errMensaje)
        {
            bool result = true;
            if (!fvtaDAL.anularFacturacionCabeceraDAL(fvtaTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminarFacturacionCabeceraBLL(facturacionVtaCabeceraTo fvtaTo, ref string errMensaje)
        {
            bool result = true;
            if (!fvtaDAL.eliminarFacturacionCabeceraDAL(fvtaTo, ref errMensaje))
                return result = false;
            return result;
        }
        public DataTable obtenerFacturacionCabeceraparaConsultaOrdDevFactBLL(facturacionVtaCabeceraTo fvtaTo)
        {
            return fvtaDAL.obtenerFacturacionCabeceraparaConsultaOrdDevFactDAL(fvtaTo);
        }

        public bool modificarActualizaFacturacionOrdDevVtaBLL(facturacionVtaCabeceraTo fccTo, ref string errMensaje)
        {
            bool result = true;
            if (!fvtaDAL.modificarActualizaFacturacionOrdDevVtaDAL(fccTo, ref errMensaje))
                return result = false;
            return result;
        }
        public DataTable obtenerFacturacionparaCostoTransferenciaBLL(facturacionVtaCabeceraTo fccTo)
        {
            return fvtaDAL.obtenerFacturacionparaCostoTransferenciaDAL(fccTo);
        }
        public DataTable MOSTRAR_IFACT_VTA_SER_BLL(facturacionVtaCabeceraTo fccTo)
        {
            return fvtaDAL.MOSTRAR_IFACT_VTA_SER_DAL(fccTo);
        }
        public DataTable obtenerFacturacionparaNotaCreditoBLL(facturacionVtaCabeceraTo fccTo)
        {
            return fvtaDAL.obtenerFacturacionparaNotaCreditoDAL(fccTo);
        }
        public bool modificaFacturacionVentaDI_BLL(facturacionVtaCabeceraTo fvtaTo, DataTable dt, ref string errMensaje)
        {   //FACTURACION DIRECTA SERVICIO
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;

                if (!insertarBulkCopyFactVtaDetBLL(dt, ref errMensaje))
                    return result = false;

                if (!modificarFacturacionCabeceraDI_BLL(fvtaTo, ref errMensaje))
                    return result = false;

                ts.Complete();
                return result;
            }
        }
        public bool modificarFacturacionCabeceraDI_BLL(facturacionVtaCabeceraTo fvtaTo, ref string errMensaje)
        {
            bool result = true;
            if (!fvtaDAL.modificarFacturacionCabeceraDI_DAL(fvtaTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool validaExisteNroDocumentoFacturacionBLL(facturacionVtaCabeceraTo fvtaTo, ref bool val, ref string errMensaje)
        {
            bool result = true;
            if (!fvtaDAL.validaExisteNroDocumentoFacturacionDAL(fvtaTo, ref val, ref errMensaje))
                return result = false;
            return result;
        }
    }
}
