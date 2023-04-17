using Entidades;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Presentacion.MOD_FACT_VTA.MOD_VTA.Reportes.FormRep
{
    public partial class REP_CONTROL_CALIDAD_X_FECHAS : Form
    {
        public List<precontratoCabeceraTo> lstpcc = new List<precontratoCabeceraTo>();
        public string programacion { get; set; }
        public string titulo { get; set; }
        public string rango_fechas { get; set; }
        public REP_CONTROL_CALIDAD_X_FECHAS()
        {
            InitializeComponent();
        }

        private void REP_CONTROL_CALIDAD_X_FECHAS_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.DataSources.Clear();
            ReportParameter[] parameters = new ReportParameter[3];
            parameters[0] = new ReportParameter("par_programacion", programacion);
            parameters[1] = new ReportParameter("par_titulo", titulo);
            parameters[2] = new ReportParameter("par_rango_fechas", rango_fechas);
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("ContratosControlCalidadxFechas", lstpcc));
            reportViewer1.LocalReport.SetParameters(parameters);
            this.reportViewer1.RefreshReport();
        }
    }
}
