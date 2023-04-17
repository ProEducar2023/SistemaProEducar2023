using DAL;
using Entidades;
using System.Data;
namespace BLL
{
    public class supervisorBLL
    {
        supervisorDAL supDAL = new supervisorDAL();
        supervisorTo supTo = new supervisorTo();

        public DataTable obtenerSupervisorBLL()
        {
            return supDAL.obtenerSupervisorDAL();
        }
        public bool insertarSupervisorBLL(supervisorTo supTo, ref string errMensaje)
        {
            bool result = true;
            if (!supDAL.insertarSupervisorDAL(supTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificarSupervisorBLL(supervisorTo supTo, ref string errMensaje)
        {
            bool result = true;
            if (!supDAL.modificarSupervisorDAL(supTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminarSupervisorBLL(supervisorTo supTo, ref string errMensaje)
        {
            bool result = true;
            if (!supDAL.eliminarSupervisorDAL(supTo, ref errMensaje))
                return result = false;
            return result;
        }
    }
}
