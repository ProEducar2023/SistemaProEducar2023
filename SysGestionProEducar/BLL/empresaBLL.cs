using DAL;
using Entidades;
using System.Data;
namespace BLL
{
    public class empresaBLL
    {
        empresaDAL empDAL = new empresaDAL();
        public DataTable obtenerTodasEmpresasBLL()
        {
            return empDAL.obtenerTodasEmpresasDAL();
        }
        public DataTable obtenerEmpresa_x_CodBLL(empresaTo empTo)
        {
            return empDAL.obtenerEmpresa_x_CodDAL(empTo);
        }
    }
}
