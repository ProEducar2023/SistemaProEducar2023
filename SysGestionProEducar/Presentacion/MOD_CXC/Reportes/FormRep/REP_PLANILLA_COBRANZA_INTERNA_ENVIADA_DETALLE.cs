using Entidades;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Presentacion.MOD_CXC.Reportes.FormRep
{
    public partial class REP_PLANILLA_COBRANZA_INTERNA_ENVIADA_DETALLE : Form
    {
        public List<planillaDetalleTo> lstpll = new List<planillaDetalleTo>();
        public REP_PLANILLA_COBRANZA_INTERNA_ENVIADA_DETALLE()
        {
            InitializeComponent();
        }

        private void REP_PLANILLA_COBRANZA_INTERNA_ENVIADA_DETALLE_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("PlanillaCobranzaEnviadaDetalle", lstpll));
            //reportViewer1.LocalReport.SetParameters(parameters);
            this.reportViewer1.RefreshReport();
        }
    }
}
