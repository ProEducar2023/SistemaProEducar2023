using DAL;
using System.Data;
namespace BLL
{
    public class personalBLL
    {
        personalDAL perDAL = new personalDAL();

        public DataTable obtenerPersonalparaUsuariosCargoBLL()
        {
            return perDAL.obtenerPersonalparaUsuariosCargoDAL();
        }
        public DataTable obtenerPersonalparaPreventaBLL()
        {
            return perDAL.obtenerPersonalparaPreventaDAL();
        }
        public DataTable obtenerPersonalAtencionClienteBLL()
        {
            return perDAL.obtenerPersonalAtencionClienteDAL();
        }
        public DataTable obtenerPersonalparaInventarioBLL()
        {
            return perDAL.obtenerPersonalparaInventarioDAL();
        }
    }
}
