using Entidades;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Presentacion.MOD_CXC.Reportes.FormRep
{
    public partial class REP_PLANILLA_DESCUENTO_INFORMATIVA : Form
    {
        public List<planillaDetalleTo> lstpll = new List<planillaDetalleTo>();
        public string institucion { get; set; }
        public string canal_dscto { get; set; }
        public string pto_cob_consolidado { get; set; }
        public string annio { get; set; }
        public string mes { get; set; }
        public REP_PLANILLA_DESCUENTO_INFORMATIVA()
        {
            InitializeComponent();
        }

        private void REP_PLANILLA_DESCUENTO_INFORMATIVA_Load(object sender, EventArgs e)
        {

            reportViewer1.LocalReport.DataSources.Clear();
            ReportParameter[] parameters = new ReportParameter[5];
            parameters[0] = new ReportParameter("par_institucion", institucion);
            parameters[1] = new ReportParameter("par_canal_dscto", canal_dscto);
            parameters[2] = new ReportParameter("par_ptocobconsolidado", pto_cob_consolidado);
            parameters[3] = new ReportParameter("par_annio", annio);
            parameters[4] = new ReportParameter("par_mes", mes);
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("PlanillaCobranzaEnviadaDetalleInformativo", lstpll));
            reportViewer1.LocalReport.SetParameters(parameters);
            this.reportViewer1.RefreshReport();
        }
    }
}
