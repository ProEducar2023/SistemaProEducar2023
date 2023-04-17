using DAL;
using System.Data;

namespace BLL
{
    public class tarjetasBLL
    {
        tarjetasDAL tjDAL = new tarjetasDAL();
        public DataTable obtenerTarjetasBLL()
        {
            return tjDAL.obtenerTarjetasDAL();
        }
    }
}
