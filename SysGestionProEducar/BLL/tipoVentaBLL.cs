using DAL;
using Entidades;
using System.Data;

namespace BLL
{
    public class tipoVentaBLL
    {
        tipoVentaDAL tvDAL = new tipoVentaDAL();
        public DataTable obtenerTipoVentaBLL()
        {
            return tvDAL.obtenerTipoVentaDAL();
        }
        public bool verificaTipoVentaBLL(tipoVentaTo tvTo, ref string errMensaje)
        {
            bool result = true;
            if (!tvDAL.verificaTipoVentaDAL(tvTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool insertarTipoVentaBLL(tipoVentaTo tvTo, ref string errMensaje)
        {
            bool result = true;
            if (!tvDAL.insertarTipoVentaDAL(tvTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificarTipoVentaBLL(tipoVentaTo tvTo, ref string errMensaje)
        {
            bool result = true;
            if (!tvDAL.modificarTipoVentaDAL(tvTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminarTipoVentaBLL(tipoVentaTo tvTo, ref string errMensaje)
        {
            bool result = true;
            if (!tvDAL.eliminarTipoVentaDAL(tvTo, ref errMensaje))
                return result = false;
            return result;
        }
    }
}
