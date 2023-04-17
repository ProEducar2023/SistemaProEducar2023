using Entidades;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Presentacion.MOD_FACT_VTA.Reportes.FormRep
{
    public partial class REP_CONTRATOS_DIRECTOS : Form
    {
        public List<contratoCabeceraTo> lstcc = new List<contratoCabeceraTo>();
        public string Empresa { get; set; }
        public string fe_año { get; set; }
        public string fe_mes { get; set; }
        public REP_CONTRATOS_DIRECTOS()
        {
            InitializeComponent();
        }

        private void REP_CONTRATOS_DIRECTOS_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.DataSources.Clear();
            ReportParameter[] parameters = new ReportParameter[3];
            parameters[0] = new ReportParameter("par_Empresa", Empresa);
            parameters[1] = new ReportParameter("par_fe_año", fe_año);
            parameters[2] = new ReportParameter("par_fe_mes", fe_mes);
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("ContratosDirectos", lstcc));
            reportViewer1.LocalReport.SetParameters(parameters);
            this.reportViewer1.RefreshReport();
        }
    }
}
