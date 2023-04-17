using DAL;
using Entidades;
using System.Data;
namespace BLL
{
    public class semanaContratoBLL
    {
        semanaContratoDAL scDAL = new semanaContratoDAL();

        public DataTable obtenerSemanaContratoBLL()
        {
            return scDAL.obtenerSemanaContratoDAL();
        }
        public DataTable obtenerSemanaContratoparaPreventaBLL(semanaContratoTo scTo)
        {
            return scDAL.obtenerSemanaContratoparaPreventaDAL(scTo);
        }
        public bool insertarSemanaContratoBLL(semanaContratoTo scTo, ref string errMensaje)
        {
            bool result = true;
            if (!scDAL.insertarSemanaContratoDAL(scTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificarSemanaContratoBLL(semanaContratoTo scTo, ref string errMensaje)
        {
            bool result = true;
            if (!scDAL.modificarSemanaContratoDAL(scTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminarSemanaContratoBLL(semanaContratoTo scTo, ref string errMensaje)
        {
            bool result = true;
            if (!scDAL.eliminarSemanaContratoDAL(scTo, ref errMensaje))
                return result = false;
            return result;
        }
    }
}
