using DAL;
using Entidades;
using System.Data;
namespace BLL
{
    public class articuloUbicacionBLL
    {
        articuloUbicacionDAL aruDAL = new articuloUbicacionDAL();
        //articuloUbicacionTo aruTo = new articuloUbicacionTo();

        public DataTable obtenerArticuloUbicacionBLL(articuloUbicacionTo aruTo)
        {
            return aruDAL.obtenerArticuloUbicacionDAL(aruTo);
        }
        public bool insertaArticuloUbicacionBLL(articuloUbicacionTo aruTo, ref string errMensaje)
        {
            bool result = true;
            if (!aruDAL.insertaArticuloUbicacionDAL(aruTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminaArticuloUbicacionBLL(string COD_ARTICULO, ref string errMensaje)
        {
            bool result = true;
            if (!aruDAL.eliminaArticuloUbicacionDAL(COD_ARTICULO, ref errMensaje))
                return result = false;
            return result;
        }
        public string obtenerArticuloUbicacionparaInventarioBLL(articuloUbicacionTo aruTo)
        {
            return aruDAL.obtenerArticuloUbicacionparaInventarioDAL(aruTo);
        }
    }
}
