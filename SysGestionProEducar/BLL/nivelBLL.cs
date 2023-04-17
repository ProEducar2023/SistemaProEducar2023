using DAL;
using Entidades;
using System.Data;
namespace BLL
{
    public class nivelBLL
    {
        nivelDAL nivDAL = new nivelDAL();
        nivelTo nivTo = new nivelTo();
        public DataTable obtenerNivelBLL()
        {
            return nivDAL.obtenerNivel();
        }
        public DataTable obtenerNivelCobranzaBLL()
        {
            return nivDAL.obtenerNivelCobranza();
        }
    }
}
