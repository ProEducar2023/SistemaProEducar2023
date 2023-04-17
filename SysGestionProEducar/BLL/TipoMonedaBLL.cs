using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class TipoMonedaBLL
    {
        private readonly TipoMonedaDAL DALTipoMoneda = new TipoMonedaDAL();

        public DataTable ListaMoneda()
        {
            return DALTipoMoneda.ListaMoneda();
        }
    }
}
