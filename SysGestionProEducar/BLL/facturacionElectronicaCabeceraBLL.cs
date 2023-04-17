using DAL;
using Entidades;
using System.Data;

namespace BLL
{
    public class facturacionElectronicaCabeceraBLL
    {
        facturacionElectronicaCabeceraDAL fecDAL = new facturacionElectronicaCabeceraDAL();
        public DataTable obtenerFacturaCabeceraDBF_BLL(facturacionElectronicaCabeceraTo faeTo, string ruta)
        {
            return fecDAL.obtenerFacturaCabeceraDBF_DAL(faeTo, ruta);
        }
        public DataTable obtenerFacturaDetalleDBF_BLL(facturacionElectronicaCabeceraTo faeTo, string ruta)
        {
            return fecDAL.obtenerFacturaDetalleDBF_DAL(faeTo, ruta);
        }
    }
}
