using Entidades;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Presentacion.MOD_ALM.Reportes.FormularioRep
{
    public partial class REP_DEVOLUCION_DE_MERCADERIAS : Form
    {
        public List<inventariosTo> lstinv = new List<inventariosTo>();
        public string fec_del { get; set; }
        public string fec_al { get; set; }
        public string prog { get; set; }
        public REP_DEVOLUCION_DE_MERCADERIAS()
        {
            InitializeComponent();
        }

        private void REP_DEVOLUCION_DE_MERCADERIAS_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.DataSources.Clear();
            ReportParameter[] parameters = new ReportParameter[3];
            parameters[0] = new ReportParameter("par_fec_del", fec_del);
            parameters[1] = new ReportParameter("par_fec_al", fec_al);
            parameters[2] = new ReportParameter("par_prog", prog);
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("devolucionMercaderia", lstinv));
            reportViewer1.LocalReport.SetParameters(parameters);
            this.reportViewer1.RefreshReport();
        }
    }
}
