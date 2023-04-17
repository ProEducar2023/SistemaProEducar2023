using Entidades;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Presentacion.MOD_CXC.Reportes.FormRep
{
    public partial class REP_LISTA_EXCESO_CUOTA : Form
    {
        public List<personaTo> lstper = new List<personaTo>();
        public string pto_cob_consolidado { get; set; }

        public REP_LISTA_EXCESO_CUOTA()
        {
            InitializeComponent();
        }

        private void REP_LISTA_EXCESO_CUOTA_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.DataSources.Clear();
            ReportParameter[] parameters = new ReportParameter[1];
            parameters[0] = new ReportParameter("par_ptocobconsolidado", pto_cob_consolidado);
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Detalle", lstper));
            reportViewer1.LocalReport.SetParameters(parameters);
            this.reportViewer1.RefreshReport();
        }
    }
}
