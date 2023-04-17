using DAL;
using Entidades;
using System.Data;
namespace BLL
{
    public class programaBLL
    {
        programaDAL proDAL = new programaDAL();

        public DataTable obtenerProgramaBLL()
        {
            return proDAL.obtenerProgramaDAL();
        }
        public bool insertarProgramaBLL(programaTo proTo, ref string errMensaje)
        {
            bool result = true;
            if (!proDAL.insertarProgramaDAL(proTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificarProgramaBLL(programaTo proTo, ref string errMensaje)
        {
            bool result = true;
            if (!proDAL.modificarProgramaDAL(proTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminarProgramaBLL(programaTo proTo, ref string errMensaje)
        {
            bool result = true;
            if (!proDAL.eliminarProgramaDAL(proTo, ref errMensaje))
                return result = false;
            return result;
        }
    }
}
