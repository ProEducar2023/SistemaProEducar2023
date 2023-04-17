using DAL;
using Entidades;
using System.Data;
namespace BLL
{
    public class facturacionVtaDetalleBLL
    {
        facturacionVtaDetalleDAL dfvtaDAL = new facturacionVtaDetalleDAL();

        public DataTable obtenerFacturacionVtaDetalleBLL(facturacionVtaDetalleTo dfvtaTo)
        {
            return dfvtaDAL.obtenerFacturacionVtaDetalleDAL(dfvtaTo);
        }
        public DataTable obtenerFacturacionVtaDetalleDI_BLL(facturacionVtaDetalleTo dfvtaTo)
        {
            return dfvtaDAL.obtenerFacturacionVtaDetalleDI_DAL(dfvtaTo);
        }
        public bool insertarFacturacionVtaDetalleBLL(facturacionVtaDetalleTo dfvtaTo, ref string errMensaje)
        {
            bool result = true;
            if (dfvtaDAL.insertarFacturacionVtaDetalleDAL(dfvtaTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificarFacturacionVtaDetalleBLL(facturacionVtaDetalleTo dfvtaTo, ref string errMensaje)
        {
            bool result = true;
            if (dfvtaDAL.insertarFacturacionVtaDetalleDAL(dfvtaTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminarFacturacionVtaDetalleBLL(facturacionVtaDetalleTo dfvtaTo, ref string errMensaje)
        {
            bool result = true;
            if (dfvtaDAL.insertarFacturacionVtaDetalleDAL(dfvtaTo, ref errMensaje))
                return result = false;
            return result;
        }

    }
}
