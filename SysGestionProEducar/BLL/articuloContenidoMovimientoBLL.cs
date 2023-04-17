using DAL;
using Entidades;
using System.Data;

namespace BLL
{
    public class articuloContenidoMovimientoBLL
    {
        articuloContenidoMovimientoDAL acmDAL = new articuloContenidoMovimientoDAL();

        public DataTable obtenerArticuloContenidoMovimientoBLL(articuloContenidoMovimientoTo acmTo)
        {
            return acmDAL.obtenerArticuloContenidoMovimientoDAL(acmTo);
        }
        public DataTable obtenerArticuloContenidoMovimientoxNroNotaIngBLL(articuloContenidoMovimientoTo acmTo)
        {
            return acmDAL.obtenerArticuloContenidoMovimientoxNroNotaIngDAL(acmTo);
        }
        public bool insertarArticuloContenidoMovimientoBLL(articuloContenidoMovimientoTo acmTo, ref string errMensaje)
        {
            bool result = true;
            if (!acmDAL.insertarArticuloContenidoMovimientoDAL(acmTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminarArticuloDevolucionContenidoMovimientoDAL(articuloContenidoMovimientoTo acmTo, ref string errMensaje)
        {
            bool result = true;
            if (!acmDAL.eliminarArticuloDevolucionContenidoMovimientoDAL(acmTo, ref errMensaje))
                return result = false;
            return result;
        }
        public DataTable obtenerResumenArticuloContenidoMovimientoBLL(articuloContenidoMovimientoTo acmTo)
        {
            return acmDAL.obtenerResumenArticuloContenidoMovimientoDAL(acmTo);
        }
    }
}
