using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class TipoDocumentoBLL
    {
        private readonly TipoDocumentoDAL DALTipoDocumento = new TipoDocumentoDAL();

        public DataTable ListarTipoDocumento()
        {
            return DALTipoDocumento.ListarTipoDocumento();
        }
    }
}
