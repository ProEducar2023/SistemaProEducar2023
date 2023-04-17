using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Windows.Forms;
using static Presentacion.HELPERS.GenericUtil;

namespace Presentacion.MOD_FACT_VTA.MOD_VTA.Reportes.ReporteODR
{
    public partial class FrmRptEfectividadComparaticaShow : Form
    {
        private readonly DataTable dt;
        public FrmRptEfectividadComparaticaShow(DataTable dt)
        {
            InitializeComponent();
            this.dt = dt;
        }

        private void FrmRptEfectividadComparaticaShow_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.ReportEmbeddedResource = ObtenerRutaReporteTareaje_MOD_CXC("RptEfectividadComparativa");
            ReportParameter[] parameters = new ReportParameter[1];
            parameters[0] = new ReportParameter("Titulo", "aa");
            reportViewer1.LocalReport.SetParameters(parameters);
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt));
            reportViewer1.RefreshReport();
        }
    }
}
