using DAL;
using Entidades;
using System.Data;

namespace BLL
{
    public class articuloContenidoBLL
    {
        articuloContenidoDAL atcDAL = new articuloContenidoDAL();
        articuloContenidoTo atcTo = new articuloContenidoTo();
        public DataTable obtenerArticuloContenidoBLL(articuloContenidoTo atcTo)
        {
            return atcDAL.obtenerArticuloContenidoDAL(atcTo);
        }
        public bool insertaArticuloContenidoBLL(articuloContenidoTo atcTo, ref string errMensaje)
        {
            bool result = true;
            if (!atcDAL.insertaArticuloContenidoDAL(atcTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificaArticuloContenidoBLL(articuloContenidoTo atcTo, ref string errMensaje)
        {
            bool result = true;
            if (!atcDAL.modificaArticuloContenidoDAL(atcTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminaArticuloContenidoBLL(string COD_ARTICULO, ref string errMensaje)
        {
            bool result = true;
            atcTo.COD_ARTICULO = COD_ARTICULO;
            if (!atcDAL.eliminaArticuloContenidoDAL(atcTo, ref errMensaje))
                return result = false;
            return result;
        }
    }
}
