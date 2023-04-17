using DAL;
using Entidades;
using System.Data;
namespace BLL
{
    public class directorBLL
    {
        directorDAL dirDAL = new directorDAL();
        directorTo dirTo = new directorTo();

        public DataTable obtenerDirectorBLL()
        {
            return dirDAL.obtenerDirectorDAL();
        }
        public bool insertarDirectorBLL(directorTo dirTo, ref string errMensaje)
        {
            bool result = true;
            if (!dirDAL.insertarDirectorDAL(dirTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificarDirectorBLL(directorTo dirTo, ref string errMensaje)
        {
            bool result = true;
            if (!dirDAL.modificarDirectorDAL(dirTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminarDirectorBLL(directorTo dirTo, ref string errMensaje)
        {
            bool result = true;
            if (!dirDAL.eliminarDirectorDAL(dirTo, ref errMensaje))
                return result = false;
            return result;
        }
    }
}
