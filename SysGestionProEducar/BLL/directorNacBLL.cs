using DAL;
using Entidades;
using System.Data;
namespace BLL
{
    public class directorNacBLL
    {
        directorNacDAL dinDAL = new directorNacDAL();
        directorNacTo dinTo = new directorNacTo();

        public DataTable obtenerDirectorNacBLL()
        {
            return dinDAL.obtenerDirectorNacDAL();
        }
        public bool insertarDirectorNacBLL(directorNacTo dinTo, ref string errMensaje)
        {
            bool result = true;
            if (!dinDAL.insertarDirectorNacDAL(dinTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificarDirectorNacBLL(directorNacTo dinTo, ref string errMensaje)
        {
            bool result = true;
            if (!dinDAL.modificarDirectorNacDAL(dinTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminarDirectorNacBLL(directorNacTo dinTo, ref string errMensaje)
        {
            bool result = true;
            if (!dinDAL.eliminarDirectorNacDAL(dinTo, ref errMensaje))
                return result = false;
            return result;
        }
    }
}
