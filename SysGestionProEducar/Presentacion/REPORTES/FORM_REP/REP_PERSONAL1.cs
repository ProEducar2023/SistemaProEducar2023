using Entidades;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Presentacion.REPORTES.FORM_REP
{
    public partial class REP_PERSONAL1 : Form
    {
        public List<personaTo> lstper = new List<personaTo>();
        public string Empresa { get; set; }
        public string Clase { get; set; }
        public string Categoria { get; set; }

        public REP_PERSONAL1()
        {
            InitializeComponent();
        }

        private void REP_PERSONAL1_Load(object sender, EventArgs e)
        {
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportParameter[] parameters = new ReportParameter[3];
            parameters[0] = new ReportParameter("parEmpresa", Empresa);
            parameters[1] = new ReportParameter("parClase", Clase);
            parameters[2] = new ReportParameter("parCategoria", Categoria);
            ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Detalle", lstper));
            ReportViewer1.LocalReport.SetParameters(parameters);
            this.ReportViewer1.RefreshReport();
        }
    }
}
