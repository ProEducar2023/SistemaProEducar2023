using DAL;
using System.Data;
namespace BLL
{
    public class conductorBLL
    {
        transportista_conductorDAL conDAL = new transportista_conductorDAL();//debio ser solo conductorDAL
        public DataTable obtenerConductorBLL()
        {
            return conDAL.obtenerTransportistaConductorDAL();
        }
        public bool deleteEliminaTransportistaConductorBLL(ref string errMensaje)
        {
            bool result = true;
            if (!conDAL.deleteEliminaTransportistaConductorDAL(ref errMensaje))
                return result = false;
            return result;
        }
    }
}
