using DAL;
using System.Data;

namespace BLL
{
    public class motivos_Otros_Dev_DsctosBLL
    {
        motivos_Otros_Dev_DsctosDAL mtdDAL = new motivos_Otros_Dev_DsctosDAL();

        public DataTable obtenerMotivosOtrosDevDsctosBLL()
        {
            return mtdDAL.obtenerMotivosOtrosDevDsctosDAL();
        }
    }
}
