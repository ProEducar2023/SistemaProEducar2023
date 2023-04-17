using Entidades;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Presentacion.MOD_FACT_VTA.MOD_VTA.Reportes.FormRep
{
    public partial class REP_CONTROL_CALIDAD_X_PERIODO : Form
    {
        public List<precontratoCabeceraTo> lstpcc = new List<precontratoCabeceraTo>();
        public string MES { get; set; }
        public string ANNIO { get; set; }
        public string TIPO { get; set; }
        public REP_CONTROL_CALIDAD_X_PERIODO()
        {
            InitializeComponent();
        }

        private void REP_CONTROL_CALIDAD_X_PERIODO_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.DataSources.Clear();
            ReportParameter[] parameters = new ReportParameter[3];
            parameters[0] = new ReportParameter("par_MES", MES);
            parameters[1] = new ReportParameter("par_ANNIO", ANNIO);
            parameters[2] = new ReportParameter("par_TIPO", TIPO);
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("ContratosControlCalidadxPeriodo", lstpcc));
            reportViewer1.LocalReport.SetParameters(parameters);
            this.reportViewer1.RefreshReport();
        }
    }
}
