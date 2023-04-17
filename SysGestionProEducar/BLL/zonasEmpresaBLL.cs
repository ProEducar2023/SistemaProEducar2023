using DAL;
using Entidades;
using System.Data;

namespace BLL
{
    public class zonasEmpresaBLL
    {
        zonasEmpresaDAL zonDAL = new zonasEmpresaDAL();

        public DataTable obtenerZonasEmpresaBLL(zonasEmpresaTo zonTo)
        {
            return zonDAL.obtenerZonasEmpresaDAL(zonTo);
        }
    }
}
