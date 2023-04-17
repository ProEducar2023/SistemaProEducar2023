using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class ReportesBLL
    {
        private readonly ReportesDAL DALReportes = new ReportesDAL();

        public DataTable RptEfectividadComparativa(string codPrograma, string codPtoCob, string codDepartamento, string codInstitucion, 
            string codPais, DateTime fechaInicio, DateTime fechaFin)
        {
            return DALReportes.RptEfectividadComparativa(codPrograma, codPtoCob, codDepartamento, codInstitucion, codPais, fechaInicio, fechaFin);
        }

        public DataTable RptEfectividadComparativaGenEnv(string codPrograma, string codPtoCob, string codDepartamento, string codInstitucion,
            string codPais, DateTime fechaInicio, DateTime fechaFin)
        {
            return DALReportes.RptEfectividadComparativaGenEnv(codPrograma, codPtoCob, codDepartamento, codInstitucion, codPais, fechaInicio, fechaFin);
        }

        public DataTable RptEfectividadComparativaGenEnv2(string codPrograma, string codPtoCob, string codDepartamento, string codInstitucion,
            string codPais, DateTime fechaInicio, DateTime fechaFin)
        {
            return DALReportes.RptEfectividadComparativaGenEnv2(codPrograma, codPtoCob, codDepartamento, codInstitucion, codPais, fechaInicio, fechaFin);
        }
    }
}
