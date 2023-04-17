using DAL;
using Entidades;
using System.Data;
namespace BLL
{
    public class personaClaseBLL
    {
        personaClaseDAL pecDAL = new personaClaseDAL();

        public DataTable obtenerPersonaClaseBLL(personaClaseTo pecTo)
        {
            return pecDAL.obtenerPersonaClaseDAL(pecTo);
        }
        public bool insertarPersonaClaseBLL(personaClaseTo pecTo, ref string errMensaje)
        {
            bool result = true;
            if (!pecDAL.insertarPersonaClaseDAL(pecTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminarPersonaClaseBLL(personaClaseTo pecTo, ref string errMensaje)
        {
            bool result = true;
            if (!pecDAL.eliminarPersonaClaseDAL(pecTo, ref errMensaje))
                return result = false;
            return result;
        }
    }
}
