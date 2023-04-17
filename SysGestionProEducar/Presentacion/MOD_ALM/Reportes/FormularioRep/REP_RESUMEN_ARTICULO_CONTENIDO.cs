using Entidades;
using Microsoft.Reporting.WinForms;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Presentacion.MOD_ALM.Reportes.FormularioRep
{
    public partial class REP_RESUMEN_ARTICULO_CONTENIDO : Form
    {
        public List<articuloContenidoMovimientoTo> lacm = new List<articuloContenidoMovimientoTo>();
        public string fec_desde { get; set; }
        public string fec_hasta { get; set; }
        //public string alm { get; set; }
        public string desc_articulo { get; set; }
        public REP_RESUMEN_ARTICULO_CONTENIDO()
        {
            InitializeComponent();
        }

        private void REP_RESUMEN_ARTICULO_CONTENIDO_Load(object sender, System.EventArgs e)
        {
            reportViewer1.LocalReport.DataSources.Clear();
            ReportParameter[] parameters = new ReportParameter[3];
            parameters[0] = new ReportParameter("par_fec_del", fec_desde);
            parameters[1] = new ReportParameter("par_fec_al", fec_hasta);
            parameters[2] = new ReportParameter("par_desc_articulo", desc_articulo);
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("ArticuloContenidoMov", lacm));
            reportViewer1.LocalReport.SetParameters(parameters);
            this.reportViewer1.RefreshReport();
        }
    }
}
