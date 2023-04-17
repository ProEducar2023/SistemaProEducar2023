using Entidades;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Presentacion.MOD_CXC.Reportes.FormRep
{
    public partial class REP_COBRANZA_INTERNA_EJECUTADA : Form
    {
        public List<planillaDetalleTo> lstpll = new List<planillaDetalleTo>();
        public string nro_planilla { get; set; }
        public string fec_planilla { get; set; }
        public string pto_cob_consolidado { get; set; }
        public string imp_enviado { get; set; }
        public string imp_no_descontado { get; set; }
        public REP_COBRANZA_INTERNA_EJECUTADA()
        {
            InitializeComponent();
        }

        private void REP_COBRANZA_INTERNA_EJECUTADA_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.DataSources.Clear();
            ReportParameter[] parameters = new ReportParameter[5];
            parameters[0] = new ReportParameter("par_nroplanilla", nro_planilla);
            parameters[1] = new ReportParameter("par_fecplanilla", fec_planilla);
            parameters[2] = new ReportParameter("par_ptocobconsolidado", pto_cob_consolidado);
            parameters[3] = new ReportParameter("par_imp_enviado", imp_enviado);
            parameters[4] = new ReportParameter("par_imp_no_descontado", imp_no_descontado);
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Detalle", lstpll));
            reportViewer1.LocalReport.SetParameters(parameters);
            this.reportViewer1.RefreshReport();
        }
    }
}
