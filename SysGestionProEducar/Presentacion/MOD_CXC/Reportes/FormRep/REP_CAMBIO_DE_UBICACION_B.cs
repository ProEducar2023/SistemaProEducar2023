using Entidades;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Presentacion.MOD_CXC.Reportes.FormRep
{
    public partial class REP_CAMBIO_DE_UBICACION_B : Form
    {
        public List<precontratoCabeceraTo> lstpcc = new List<precontratoCabeceraTo>();
        public string nombre_reporte { get; set; }
        public string fecha_desde_hasta { get; set; }
        public string institucion { get; set; }
        public string pto_cobranza { get; set; }
        public string ubicacion { get; set; }
        public REP_CAMBIO_DE_UBICACION_B()
        {
            InitializeComponent();
        }

        private void REP_CAMBIO_DE_UBICACION_B_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.DataSources.Clear();
            ReportParameter[] parameters = new ReportParameter[5];
            parameters[0] = new ReportParameter("par_fecha_desde_hasta", fecha_desde_hasta);
            parameters[1] = new ReportParameter("par_institucion", institucion);
            parameters[2] = new ReportParameter("par_pto_cobranza", pto_cobranza);
            parameters[3] = new ReportParameter("par_ubicacion", ubicacion);
            parameters[4] = new ReportParameter("par_nombre_reporte", nombre_reporte);
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("CambiodeUbicacionB", lstpcc));
            reportViewer1.LocalReport.SetParameters(parameters);
            this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            this.reportViewer1.RefreshReport();
        }
    }
}
