using DAL;
using Entidades;
using System.Data;
namespace BLL
{
    public class contratoDetalleBLL
    {
        contratoDetalleDAL dccDAL = new contratoDetalleDAL();
        //public DataTable obtenerContratoDetalleBLL()
        //{
        //    return dccDAL.obtenerContratoDetalleDAL();
        //}
        public bool insertarContratoDetalleBLL(contratoDetalleTo dccTo, ref string errMensaje)
        {
            bool result = true;
            if (!dccDAL.insertarContratoDetalleDAL(dccTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool insertarContratoDetalle_dbf_BLL(contratoDetalleTo dccTo, ref string errMensaje)
        {
            bool result = true;
            if (!dccDAL.insertarContratoDetalle_dbf_DAL(dccTo, ref errMensaje))
                return result = false;
            return result;
        }
        public DataTable obtenerContratoDetalleContratoBLL(contratoDetalleTo ccdTo)
        {
            return dccDAL.obtenerContratoDetalleContratoDAL(ccdTo);
        }
        public DataTable obtenerContratoDetalleBLL(contratoDetalleTo ccdTo)
        {
            return dccDAL.obtenerContratoDetalleDAL(ccdTo);
        }
        public DataTable CARGAR_PEDIDO_DETALLES_PTE_BLL(contratoDetalleTo ccdTo)
        {
            return dccDAL.CARGAR_PEDIDO_DETALLES_PTE_DAL(ccdTo);
        }
        public DataTable CARGAR_PEDIDO_DETALLES_PTE3_BLL(contratoDetalleTo ccdTo)
        {
            return dccDAL.CARGAR_PEDIDO_DETALLES_PTE3_DAL(ccdTo);
        }
        public DataTable obtenerContratoDetalleporConsultaOrdDevFacVtaBLL(contratoDetalleTo ccdTo)
        {
            return dccDAL.obtenerContratoDetalleporConsultaOrdDevFacVtaDAL(ccdTo);
        }
        public DataTable obtenerOrdenDevVtaDetalleBLL(contratoDetalleTo ccdTo)
        {
            return dccDAL.obtenerOrdenDevVtaDetalleDAL(ccdTo);
        }
        public DataTable obtenerNotaIngresoDevVtaDetalleBLL(contratoDetalleTo ccdTo)
        {
            return dccDAL.obtenerNotaIngresoDevVtaDetalleDAL(ccdTo);
        }
        public DataTable obtenerContratoDetalleporConsultaOrdDevFacVtaporContratoBLL(contratoDetalleTo ccdTo)
        {
            return dccDAL.obtenerContratoDetalleporConsultaOrdDevFacVtaporContratoDAL(ccdTo);
        }
        public bool ELIMINAR_PEDIDO_X_NRO_CONTRATO_BLL(contratoDetalleTo ccdTo, ref string errMensaje)
        {
            bool result = true;
            if (!dccDAL.ELIMINAR_PEDIDO_X_NRO_CONTRATO_DAL(ccdTo, ref errMensaje))
                return result = false;
            return result;
        }
    }
}
