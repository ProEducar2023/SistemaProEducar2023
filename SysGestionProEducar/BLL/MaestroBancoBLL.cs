using DAL;
using System.Data;

namespace BLL
{
    public class MaestroBancoBLL
    {
        private readonly MaestroBancoDAL DALMaestroBanco = new MaestroBancoDAL();

        public DataTable ListarMaestroBanco()
        {
            return DALMaestroBanco.ListarMaestroBanco();
        }

        public DataTable ObtenerMaestroBancoXCodBanco(string codBanco)
        {
            return DALMaestroBanco.ObtenerMaestroBancoXCodBanco(codBanco);
        }
    }
}
