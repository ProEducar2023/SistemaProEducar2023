using DAL;
using Entidades;
using System.Data;
namespace BLL
{
    public class reporteTelefonicoDetalleBLL
    {
        reporteTelefonicoDetalleDAL rtdDAL = new reporteTelefonicoDetalleDAL();
        public DataTable obtenerReporteTelefonicoDetalleBLL(reporteTelefonicoDetalleTo rtdTo)
        {
            return rtdDAL.obtenerReporteTelefonicoDetalleDAL(rtdTo);
        }
        public bool insertarReporteTelefonicoDetalleDAL(reporteTelefonicoDetalleTo rtdTo, ref string errMensaje)
        {
            bool result = true;
            if (!rtdDAL.insertarReporteTelefonicoDetalleDAL(rtdTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificarReporteTelefonicoDetalleBLL(reporteTelefonicoDetalleTo rtdTo, ref string errMensaje)
        {
            bool result = true;
            if (!rtdDAL.modificarReporteTelefonicoDetalleDAL(rtdTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminarReporteTelefonicoDetalleBLL(reporteTelefonicoDetalleTo rtdTo, ref string errMensaje)
        {
            bool result = true;
            if (!rtdDAL.eliminarReporteTelefonicoDetalleDAL(rtdTo, ref errMensaje))
                return result = false;
            return result;
        }
    }
}
