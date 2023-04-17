using DAL;
using Entidades;
using System.Data;
namespace BLL
{
    public class personaSustitutoBLL
    {
        personaSustitutoDAL pesDAL = new personaSustitutoDAL();

        public DataTable obtenerPersonaSustitutoBLL(personaSustitutoTo pesTo)
        {
            return pesDAL.obtenerPersonaSustitutoDAL(pesTo);
        }
        public bool insertarPersonaSustitutoBLL(personaSustitutoTo pesTo, ref string errMensaje)
        {
            bool result = true;
            if (!pesDAL.insertarPersonaSustitutoDAL(pesTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificarPersonaSustitutoBLL(personaSustitutoTo pesTo, ref string errMensaje)
        {
            bool result = true;
            if (!pesDAL.modificarPersonaSustitutoDAL(pesTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminarPersonaSustitutoBLL(personaSustitutoTo pesTo, ref string errMensaje)
        {
            bool result = true;
            if (!pesDAL.eliminarPersonaSustitutoDAL(pesTo, ref errMensaje))
                return result = false;
            return result;
        }
    }
}
