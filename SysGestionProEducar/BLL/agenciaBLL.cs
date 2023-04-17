using DAL;
using Entidades;
using System.Data;
namespace BLL
{
    public class agenciaBLL
    {
        agenciaDAL ageDAL = new agenciaDAL();

        public DataTable obtenerAgenciaBLL()
        {
            return ageDAL.obtenerAgenciaDAL();
        }
        public bool insertarAgenciaBLL(agenciaTo ageTo, ref string errMensaje)
        {
            bool result = true;
            if (!ageDAL.insertarAgenciaDAL(ageTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificarAgenciaBLL(agenciaTo ageTo, ref string errMensaje)
        {
            bool result = true;
            if (!ageDAL.modificarAgenciaDAL(ageTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminarAgenciaBLL(agenciaTo ageTo, ref string errMensaje)
        {
            bool result = true;
            if (!ageDAL.eliminarAgenciaDAL(ageTo, ref errMensaje))
                return result = false;
            return result;
        }
        public int verificarAgenciaBLL(agenciaTo ageTo)
        {
            return ageDAL.verificarAgenciaDAL(ageTo);
        }
    }

}
