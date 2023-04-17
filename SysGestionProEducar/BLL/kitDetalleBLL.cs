using DAL;
using Entidades;
using System.Data;
namespace BLL
{
    public class kitDetalleBLL
    {
        kitDetalleDAL dkiDAL = new kitDetalleDAL();
        public DataTable obtenerKitDetalleBLL()
        {
            return dkiDAL.obtenerKitDetalleDAL();
        }
        public DataTable obtenerKitDetalleporCodKitBLL(kitDetalleTo kiTo)
        {
            return dkiDAL.obtenerKitDetalleporCodKitDAL(kiTo);
        }
        public bool insertarKitDetalleBLL(kitDetalleTo dkiTo, ref string errMensaje)
        {
            bool result = true;
            if (!dkiDAL.insertarKitDetalleDAL(dkiTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool insertarListaPreciosBLL(kitDetalleTo dkiTo, ref string errMensaje)
        {
            bool result = true;
            if (!dkiDAL.insertarListaPreciosDAL(dkiTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificarKitDetalleBLL(kitDetalleTo dkiTo, ref string errMensaje)
        {
            bool result = true;
            if (!dkiDAL.modificarKitDetalleDAL(dkiTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminarKitDetalleBLL(kitDetalleTo dkiTo, ref string errMensaje)
        {
            bool result = true;
            if (!dkiDAL.eliminarKitDetalleDAL(dkiTo, ref errMensaje))
                return result = false;
            return result;
        }
        public DataTable obtenerKitDetalleporCodKit_FechaBLL(kitDetalleTo kiTo)
        {
            return dkiDAL.obtenerKitDetalleporCodKit_FechaDAL(kiTo);
        }
        public bool eliminarKitDetalleCompletoBLL(kitDetalleTo dkiTo, ref string errMensaje)
        {
            bool result = true;
            if (!dkiDAL.eliminarKitDetalleCompletoDAL(dkiTo, ref errMensaje))
                return result = false;
            return result;
        }

    }
}