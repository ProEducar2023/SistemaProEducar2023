using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using Entidades;

namespace Presentacion.MOD_CXC.Reportes.FormRep
{
    public partial class REP_DE_COBRANZA_X_UBICACION : Form
    {
        public List<cambioTipoPllaHistoricoTo> lstcph = new List<cambioTipoPllaHistoricoTo>();
        public string nombre_reporte { get; set; }
        public string programa { get; set; }
        public string ubicacion { get; set; }
        public string grupo { get; set; }
        public string sub_ubicacion { get; set; }
        public string fechaAprobacion { get; set; }
        public string fechaCobranzas { get; set; }

        private readonly DataTable dt;
        public REP_DE_COBRANZA_X_UBICACION(DataTable dt)
        {
            InitializeComponent();
            this.dt = dt;
        }

        private void REP_DE_COBRANZA_X_UBICACION_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.DataSources.Clear();
            ReportParameter[] parameters = new ReportParameter[7];
            parameters[0] = new ReportParameter("par_nombre_reporte", nombre_reporte);
            parameters[1] = new ReportParameter("par_programa", programa);
            parameters[2] = new ReportParameter("par_ubicacion", ubicacion);
            parameters[3] = new ReportParameter("par_grupo", grupo);
            parameters[4] = new ReportParameter("par_sub_ubicacion", sub_ubicacion);
            parameters[5] = new ReportParameter("par_fechaAprobacion", fechaAprobacion);
            parameters[6] = new ReportParameter("par_fechaCobranzas", fechaCobranzas);
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("CobranzaxUbicacion", dt));
            reportViewer1.LocalReport.SetParameters(parameters);
            this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            this.reportViewer1.RefreshReport();
        }
    }
}
