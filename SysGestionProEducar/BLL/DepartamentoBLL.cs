using DAL;
using System;
using System.Data;

namespace BLL
{
    public class DepartamentoBLL
    {
        private readonly DepartamentoDAL DALDepartamento = new DepartamentoDAL();

        public DataTable ListarDepartamentos()
        {
            return DALDepartamento.ListarDepartamentos();
        }

        public DataTable ListarDepartamento(string codPais)
        {
            return DALDepartamento.ListarDepartamento(codPais);
        }
    }
}
