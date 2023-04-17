using DAL;
using System.Data;

namespace BLL
{
    public class vehiculoBLL
    {
        transportista_vehiculoDAL vehDAL = new transportista_vehiculoDAL();//debio ser vehiculoDAL
        public DataTable obtenerVehiculoBLL()
        {
            return vehDAL.obtenerTransportistaVehiculoDAL();
        }
        public bool deleteEliminaTransportistaVehiculoBLL(ref string errMensaje)
        {
            bool result = true;
            if (!vehDAL.deleteEliminaTransportistaVehiculoDAL(ref errMensaje))
                return result = false;

            return result;
        }
    }
}
