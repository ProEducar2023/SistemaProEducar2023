using Microsoft.Reporting.WinForms;
using System;
using System.Windows.Forms;

namespace Presentacion.REPORTES.FORM_REPORTES
{
    public partial class REP_KARDEX_SALDO2 : Form
    {
        public REP_KARDEX_SALDO2()
        {
            InitializeComponent();
        }

        private void REP_KARDEX_SALDO2_Load(object sender, EventArgs e)
        {
            this.ReportViewer1.Visible = true;
            this.ReportViewer1.RefreshReport();
            this.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            this.ReportViewer1.ZoomMode = ZoomMode.PageWidth;
            this.ReportViewer1.RefreshReport();
            this.ReportViewer1.Refresh();
        }
        public void LLENAR_DATASET(string numeroInventario, string fechaInventario, string codigoArticulo,
        string articulo, string numeroParte, string movimiento, decimal ingreso, decimal salida,
        decimal precio, string almacen, string referencia, string numeroReferencia,
        string fechaReferencia, decimal valorDebe, decimal valorHaber, decimal saldoInicial,
        string ccop, decimal costoPromedio, string debeHaber, decimal saldoActual,
        decimal importeActual, string unidadMedida)
        {
            this.dT_KARDEX_SALDO_ARTICULO.DataTable1.Rows.Add(numeroInventario, fechaInventario, codigoArticulo, articulo, numeroParte,
            movimiento, ingreso, salida, precio, almacen, referencia, numeroReferencia, fechaReferencia, valorDebe, valorHaber, saldoInicial,
            ccop, costoPromedio, debeHaber, saldoActual, importeActual, unidadMedida);

        }
        public void CREAR_REPORTE(string EMPRESA, string RUC, string CLASE, string DESMES1, string DESMES2, string TOTAL_VISIBLE, string DIRECCION, string AÑO0)
        {
            ReportParameter p1 = new ReportParameter("EMPRESA", EMPRESA);
            ReportParameter p2 = new ReportParameter("RUC", RUC);
            ReportParameter p3 = new ReportParameter("CLASE", CLASE);
            ReportParameter p4 = new ReportParameter("FECHA1", DESMES1);
            ReportParameter p5 = new ReportParameter("FECHA2", DESMES2);
            ReportParameter p6 = new ReportParameter("TOTAL_VISIBLE", TOTAL_VISIBLE);
            ReportParameter p7 = new ReportParameter("DIRECCION", DIRECCION);
            ReportParameter p8 = new ReportParameter("ANIO00", AÑO0);
            this.ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1, p2, p3, p4, p5, p6, p7, p8 });
        }
    }
}
