using Entidades;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Presentacion.MOD_FACT_VTA.MOD_VTA.Reportes.FormRep
{
    public partial class REP_CONTRATOS_REGISTRADOS : Form
    {
        public List<contratoCabeceraTo> lstcc = new List<contratoCabeceraTo>();
        public string Institucion { get; set; }
        public string Nom_semana { get; set; }
        public string Periodo { get; set; }
        public REP_CONTRATOS_REGISTRADOS()
        {
            InitializeComponent();
        }

        private void REP_CONTRATOS_REGISTRADOS_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.DataSources.Clear();
            ReportParameter[] parameters = new ReportParameter[3];
            parameters[0] = new ReportParameter("par_Institucion", Institucion);
            parameters[1] = new ReportParameter("parNom_semana", Nom_semana);
            parameters[2] = new ReportParameter("parPeriodo", Periodo);
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("ContratosRegistrados", lstcc));
            reportViewer1.LocalReport.SetParameters(parameters);
            this.reportViewer1.RefreshReport();
        }
    }
}
