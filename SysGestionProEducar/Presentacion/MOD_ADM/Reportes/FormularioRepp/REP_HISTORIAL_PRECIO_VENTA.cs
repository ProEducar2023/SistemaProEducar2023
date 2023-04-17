using Entidades;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Presentacion.MOD_ADM.Reportes.FormularioRepp
{
    public partial class REP_HISTORIAL_PRECIO_VENTA : Form
    {
        public List<inventariosTo> linv = new List<inventariosTo>();
        public string fec_desde { get; set; }
        public string fec_hasta { get; set; }
        public string grupo { get; set; }
        public string kit { get; set; }
        public REP_HISTORIAL_PRECIO_VENTA()
        {
            InitializeComponent();
        }

        private void REP_HISTORIAL_PRECIO_VENTA_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.DataSources.Clear();
            ReportParameter[] parameters = new ReportParameter[4];
            parameters[0] = new ReportParameter("par_fec_desde", fec_desde);
            parameters[1] = new ReportParameter("par_fec_hasta", fec_hasta);
            parameters[2] = new ReportParameter("par_grupo", grupo);
            parameters[3] = new ReportParameter("par_kit", kit);
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("HistorialPrecioVenta", linv));
            reportViewer1.LocalReport.SetParameters(parameters);
            this.reportViewer1.RefreshReport();
        }
    }
}
