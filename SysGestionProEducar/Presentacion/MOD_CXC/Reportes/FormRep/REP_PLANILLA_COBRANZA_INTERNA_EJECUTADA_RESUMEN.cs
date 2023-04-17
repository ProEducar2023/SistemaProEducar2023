using Entidades;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Presentacion.MOD_CXC.Reportes.FormRep
{
    public partial class REP_PLANILLA_COBRANZA_INTERNA_EJECUTADA_RESUMEN : Form
    {
        public List<planillaDetalleTo> lstpll = new List<planillaDetalleTo>();
        public REP_PLANILLA_COBRANZA_INTERNA_EJECUTADA_RESUMEN()
        {
            InitializeComponent();
        }

        private void REP_PLANILLA_COBRANZA_INTERNA_EJECUTADA_RESUMEN_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("PlanillaCobranzaEjecutadaResumen", lstpll));
            //reportViewer1.LocalReport.SetParameters(parameters);
            this.reportViewer1.RefreshReport();
        }
    }
}
