using DAL;
using System.Data;
namespace BLL
{
    public class cuotasBLL
    {
        public cuotasDAL cuoDAL = new cuotasDAL();

        public DataTable mostrarCuotasDAL()
        {
            return cuoDAL.mostrarCuotasDAL();
        }
    }
}
