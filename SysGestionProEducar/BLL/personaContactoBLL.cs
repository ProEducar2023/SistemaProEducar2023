using DAL;
using Entidades;
using System.Data;
namespace BLL
{
    public class personaContactoBLL
    {
        personaContactoDAL percDAL = new personaContactoDAL();

        public DataTable obtenerPersonaContactoBLL(personaContactoTo percTo)
        {
            return percDAL.obtenerPersonaContactoDAL(percTo);
        }
        public bool insertarPersonaContactoBLL(personaContactoTo percTo, ref string errMensaje)
        {
            bool result = true;
            if (!percDAL.insertarPesonaContactoDAL(percTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificarPersonaContactoBLL(personaContactoTo percTo, ref string errMensaje)
        {
            bool result = true;
            if (!percDAL.modificarPesonaContactoDAL(percTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminarPersonaContactoBLL(personaContactoTo percTo, ref string errMensaje)
        {
            bool result = true;
            if (!percDAL.eliminarPesonaContactoDAL(percTo, ref errMensaje))
                return result = false;
            return result;
        }
    }
}