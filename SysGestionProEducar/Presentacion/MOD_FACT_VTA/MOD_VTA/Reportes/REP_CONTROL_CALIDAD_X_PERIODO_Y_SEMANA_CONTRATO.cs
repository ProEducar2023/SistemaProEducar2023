using Entidades;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Presentacion.MOD_FACT_VTA.MOD_VTA.Reportes
{
    public partial class REP_CONTROL_CALIDAD_X_PERIODO_Y_SEMANA_CONTRATO : Form
    {
        public List<precontratoCabeceraTo> lstpcc = new List<precontratoCabeceraTo>();
        public string programa { get; set; }
        public string periodo { get; set; }
        public string semana { get; set; }
        public REP_CONTROL_CALIDAD_X_PERIODO_Y_SEMANA_CONTRATO()
        {
            InitializeComponent();
        }

        private void REP_CONTROL_CALIDAD_X_PERIODO_Y_SEMANA_CONTRATO_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.DataSources.Clear();
            ReportParameter[] parameters = new ReportParameter[3];
            parameters[0] = new ReportParameter("par_programa", programa);
            parameters[1] = new ReportParameter("par_periodo", periodo);
            parameters[2] = new ReportParameter("par_semana_contrato", semana);
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("ContratosControlCalidadxPeriodoSemanaContrato", lstpcc));
            reportViewer1.LocalReport.SetParameters(parameters);
            this.reportViewer1.RefreshReport();
        }
    }
}
