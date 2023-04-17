using DAL;
using Entidades;
using System.Data;
namespace BLL
{
    public class articuloClaseBLL
    {
        articuloClaseDAL arcDAL = new articuloClaseDAL();
        //articuloClaseTo arcTo = new articuloClaseTo();

        public DataTable obtenerArticuloClaseBLL(articuloClaseTo arcTo)
        {
            return arcDAL.obtenerArticuloClaseDAL(arcTo);
        }
        public DataTable obtenerArticuloClaseparaInventarioBLL(articuloClaseTo arcTo)
        {
            return arcDAL.obtenerArticuloClaseparaInventarioDAL(arcTo);
        }
        public bool insertaArticuloClaseBLL(articuloClaseTo arcTo, ref string errMensaje)
        {
            bool result = true;
            if (!arcDAL.insertaArticuloClaseDAL(arcTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminaArticuloClaseBLL(string COD_ARTICULO, ref string errMensaje)
        {
            bool result = true;
            if (!arcDAL.eliminaArticuloClaseDAL(COD_ARTICULO, ref errMensaje))
                return result = false;
            return result;
        }
        public DataTable obtenerDGW_Articulos_ClaseBLL(articuloClaseTo arcTo)
        {
            return arcDAL.obtenerDGW_Articulos_ClaseDAL(arcTo);
        }
        public DataTable MOSTRAR_DGW_ARTICULOS_CLASE_GRUPO_BLL(articuloClaseTo arcTo)
        {
            return arcDAL.MOSTRAR_DGW_ARTICULOS_CLASE_GRUPO_DAL(arcTo);
        }
        public DataTable obtenerArticuloClaseparaCostosBLL(articuloClaseTo arcTo)
        {
            return arcDAL.obtenerArticuloClaseparaCostosDAL(arcTo);
        }
        public DataTable obtenerArticuloClaseparaCostoPromedioBLL()
        {
            return arcDAL.obtenerArticuloClaseparaCostoPromedioDAL();
        }
        public DataTable obtenerArticuloClaseparaCostoPromedioUMBLL(articuloClaseTo arcTo)
        {
            return arcDAL.obtenerArticuloClaseparaCostoPromedioUMDAL(arcTo);
        }
    }
}
