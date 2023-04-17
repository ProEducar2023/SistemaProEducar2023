using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using Entidades;
namespace Presentacion.MOD_CXC.Reportes.FormRep
{
    public partial class REP_PROYECCION_COBRANZAS : Form
    {
        public string LocalReport { get; set; }
        public DataTable Data { get; set; }
        public string[] Parameters { get; set; }
        public REP_PROYECCION_COBRANZAS()
        {
            InitializeComponent();
        }

        private void REP_PROYECCION_COBRANZAS_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.ReportEmbeddedResource = LocalReport;
            reportViewer1.LocalReport.DataSources.Clear();
            ReportParameter[] parameters = new ReportParameter[Parameters.Length];
            ReportParameterInfoCollection paramRep = reportViewer1.LocalReport.GetParameters();
            if (paramRep.Count > 0)
            {
                for (int io = 0; io < Parameters.Length; io++)
                {
                    parameters[io] = new ReportParameter(paramRep[io].Name, Parameters[io]);
                }
            }
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", Data));
            reportViewer1.LocalReport.SetParameters(parameters);
            reportViewer1.RefreshReport();
        }
    }
}
