using Entidades;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Presentacion.MOD_CXC.Reportes.FormRep
{
    public partial class REP_PLANILLA_COBRANZA_INTERNA_EJECUTADA_DETALLE : Form
    {
        public List<planillaDetalleTo> lstpll = new List<planillaDetalleTo>();
        //public string mensaje { get; set; }
        public REP_PLANILLA_COBRANZA_INTERNA_EJECUTADA_DETALLE()
        {
            InitializeComponent();
        }

        private void REP_PLANILLA_COBRANZA_INTERNA_EJECUTADA_DETALLE_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.DataSources.Clear();
            //ReportParameter[] parameters = new ReportParameter[1];
            //parameters[0] = new ReportParameter("par_mensaje", mensaje);
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("PlanillaCobranzaEjecutadaDetalle", lstpll));
            //reportViewer1.LocalReport.SetParameters(parameters);
            this.reportViewer1.RefreshReport();
        }
    }
}
