using DAL;
using Entidades;
using System.Data;
namespace BLL
{
    public class tComisionBLL
    {
        tComisonDAL tcomDAL = new tComisonDAL();

        public DataTable obtenerTComisionBLL(tComisionTo tcomTo)
        {
            return tcomDAL.obtenerTComisionDAL(tcomTo);
        }
        public bool insertarTComisionBLL(tComisionTo tcomTo, ref string errMensaje)
        {
            bool result = true;
            if (!tcomDAL.insertarTComisionDAL(tcomTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminarTComisionBLL(tComisionTo tcomTo, ref string errMensaje)
        {
            bool result = true;
            if (!tcomDAL.eliminarTComisionDAL(tcomTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminarTComisionxLiqComisionBLL(tComisionTo tcomTo, ref string errMensaje)
        {
            bool result = true;
            if (!tcomDAL.eliminarTComisionxLiqComisionDAL(tcomTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificarTComisionBLL(tComisionTo tcomTo, ref string errMensaje)
        {
            bool result = true;
            if (!tcomDAL.modificarTComisionDAL(tcomTo, ref errMensaje))
                return result = false;
            return result;
        }
    }
}
