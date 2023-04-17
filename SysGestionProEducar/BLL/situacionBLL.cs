using DAL;
using Entidades;
using System.Data;
namespace BLL
{
    public class situacionBLL
    {
        situacionDAL sitDAL = new situacionDAL();

        public DataTable obtenerSituacionBLL()
        {
            return sitDAL.obtenerSituacionDAL();
        }
        public bool insertarSituacionBLL(situacionTo sitTo, ref string errMensaje)
        {
            bool result = true;
            if (!sitDAL.insertarSituacionDAL(sitTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificarSituacionBLL(situacionTo sitTo, ref string errMensaje)
        {
            bool result = true;
            if (!sitDAL.modificarSituacionDAL(sitTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminarSituacionBLL(situacionTo sitTo, ref string errMensaje)
        {
            bool result = true;
            if (!sitDAL.eliminarSituacionDAL(sitTo, ref errMensaje))
                return result = false;
            return result;
        }
        public int verificaSituacionBLL(situacionTo sitTo)
        {
            return sitDAL.verificaSituacionDAL(sitTo);
        }
    }
}
