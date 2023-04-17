using Entidades;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Presentacion.MOD_ALM.Reportes.FormularioRep
{
    public partial class REP_KARDEX_INVENTARIO_HISTORICO_RESUMEN : Form
    {
        public List<inventariosTo> lstinv = new List<inventariosTo>();
        public string fec_del { get; set; }
        public string fec_al { get; set; }
        //public string alm { get; set; }
        public string suc { get; set; }
        public REP_KARDEX_INVENTARIO_HISTORICO_RESUMEN()
        {
            InitializeComponent();
        }

        private void REP_KARDEX_INVENTARIO_HISTORICO_RESUMEN_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.DataSources.Clear();
            ReportParameter[] parameters = new ReportParameter[3];
            parameters[0] = new ReportParameter("par_fec_del", fec_del);
            parameters[1] = new ReportParameter("par_fec_al", fec_al);
            //parameters[2] = new ReportParameter("par_alm", alm);
            parameters[2] = new ReportParameter("par_suc", suc);
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("kardexInventarioHistoricoResumen", lstinv));
            reportViewer1.LocalReport.SetParameters(parameters);
            this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            this.reportViewer1.RefreshReport();
        }
    }
}
