using Entidades;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Presentacion.MOD_FACT_VTA.MOD_VTA.Reportes.FormRep
{
    public partial class REP_CONTROL_CALIDAD : Form
    {
        public List<precontratoCabeceraTo> lstpcc = new List<precontratoCabeceraTo>();
        public string nro_rep { get; set; }
        //public string nro_con { get; set; }
        public string digitado_por { get; set; }
        public string fec_digitador { get; set; }
        public string programacion { get; set; }
        public string fec_reporte { get; set; }
        public string sem_reporte { get; set; }
        public REP_CONTROL_CALIDAD()
        {
            InitializeComponent();
        }

        private void REP_CONTROL_CALIDAD_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.DataSources.Clear();
            ReportParameter[] parameters = new ReportParameter[6];
            parameters[0] = new ReportParameter("par_nro_rep", nro_rep);
            parameters[1] = new ReportParameter("par_digitado_por", digitado_por);
            parameters[2] = new ReportParameter("par_fec_digitador", fec_digitador);
            parameters[3] = new ReportParameter("par_programacion", programacion);
            parameters[4] = new ReportParameter("par_fec_reporte", fec_reporte);
            parameters[5] = new ReportParameter("par_sem_reporte", sem_reporte);
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("ContratosControlCalidad", lstpcc));
            reportViewer1.LocalReport.SetParameters(parameters);
            this.reportViewer1.RefreshReport();
        }
    }
}
