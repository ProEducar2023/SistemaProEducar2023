using Microsoft.Reporting.WinForms;
using System;
using System.Windows.Forms;
namespace Presentacion.REPORTES.FORM_REP
{
    public partial class REP_AÑO_MES : Form
    {
        public string REP;
        public REP_AÑO_MES()
        {
            InitializeComponent();
        }

        private void REP_AÑO_MES_Load(object sender, EventArgs e)
        {
            if (REP == "AGRU")
            {
                this.reportViewer1.Visible = false;
                this.reportViewer2.Visible = true;
                this.reportViewer2.SetDisplayMode(DisplayMode.PrintLayout);
                this.reportViewer2.ZoomMode = ZoomMode.PageWidth;
                //' Me.ReportViewer2.RefreshReport()
                this.reportViewer2.Refresh();
                this.reportViewer2.RefreshReport();
            }
            else
            {
                this.reportViewer1.Visible = true;
                this.reportViewer2.Visible = false;
                this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                this.reportViewer1.ZoomMode = ZoomMode.PageWidth;
                this.reportViewer1.Refresh();
                this.reportViewer1.RefreshReport();
            }
        }
        private void CREAR_REPORTE(string AGRU, string DESC_MES, string AÑO0, string MES0, string CLASE, string ST_GRUPO,
            string COD_GRUPO, string ST_SUBGRUPO, string COD_SUBGRUPO, string DESC_CLASE, string NEGATIVO, string ORD,
            string GRUPO0, string SUBGRUPO0, string SALDO0, string RUC_EMPRESA, string DESC_EMPRESA)
        {
            ReportParameter p1 = new ReportParameter("RUC", RUC_EMPRESA);
            ReportParameter p2 = new ReportParameter("EMPRESA", DESC_EMPRESA);
            ReportParameter p3 = new ReportParameter("AÑO", AÑO0);
            ReportParameter p4 = new ReportParameter("MES", MES0);
            ReportParameter p5 = new ReportParameter("CLASE", DESC_CLASE);
            ReportParameter p6 = new ReportParameter("ORD", ORD);
            ReportParameter p7 = new ReportParameter("NEGATIVO", NEGATIVO);
            ReportParameter p8 = new ReportParameter("GRUPO", GRUPO0);
            ReportParameter p9 = new ReportParameter("SUBGRUPO", SUBGRUPO0);
            ReportParameter p10 = new ReportParameter("SALDO0", SALDO0);

            if (REP == "AGRU")
            {

            }
        }
    }
}
