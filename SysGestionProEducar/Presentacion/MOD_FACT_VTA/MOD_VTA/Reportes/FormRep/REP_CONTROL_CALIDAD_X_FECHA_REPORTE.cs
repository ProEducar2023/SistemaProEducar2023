using Entidades;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Presentacion.MOD_FACT_VTA.MOD_VTA.Reportes.FormRep
{
    public partial class REP_CONTROL_CALIDAD_X_FECHA_REPORTE : Form
    {
        public List<precontratoCabeceraTo> lstpcc = new List<precontratoCabeceraTo>();
        public string fec_desde { get; set; }
        public string fec_hasta { get; set; }

        public REP_CONTROL_CALIDAD_X_FECHA_REPORTE()
        {
            InitializeComponent();
        }

        private void REP_CONTROL_CALIDAD_X_FECHA_REPORTE_Load(object sender, EventArgs e)
        {

            reportViewer1.LocalReport.DataSources.Clear();
            ReportParameter[] parameters = new ReportParameter[2];
            parameters[0] = new ReportParameter("par_fec_desde", fec_desde);
            parameters[1] = new ReportParameter("par_fec_hasta", fec_hasta);
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("ContratosControlCalidadxFechaReporte", lstpcc));
            reportViewer1.LocalReport.SetParameters(parameters);
            this.reportViewer1.RefreshReport();
        }
    }
}
