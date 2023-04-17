using DAL;
using Entidades;
using System.Data;
namespace BLL
{
    public class lugarEntregaBLL
    {
        lugarEntregaDAL lgeDAL = new lugarEntregaDAL();

        public DataTable obtenerLugarEntregaBLL()
        {
            return lgeDAL.obtenerLugarEntregaDAL();
        }
        public bool insertarLugarEntregaBLL(lugarEntregaTo lgeTo, ref string errMensaje)
        {
            bool result = true;
            if (!lgeDAL.insertarLugarEntregaDAL(lgeTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificarLugarEntregaBLL(lugarEntregaTo lgeTo, ref string errMensaje)
        {
            bool result = true;
            if (!lgeDAL.modificarLugarEntregaDAL(lgeTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminarLugarEntregaBLL(lugarEntregaTo lgeTo, ref string errMensaje)
        {
            bool result = true;
            if (!lgeDAL.eliminarLugarEntregaDAL(lgeTo, ref errMensaje))
                return result = false;
            return result;
        }
        public int verificarLugarEntregaBLL(lugarEntregaTo lgeTo)
        {
            return lgeDAL.verificarLugarEntregaDAL(lgeTo);
        }
    }
}
