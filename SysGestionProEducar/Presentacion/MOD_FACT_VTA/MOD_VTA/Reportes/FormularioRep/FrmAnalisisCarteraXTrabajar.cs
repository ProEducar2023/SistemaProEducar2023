using System;
using System.Data;
using System.Windows.Forms;
using BLL;
using Presentacion.HELPERS.Forms;
using static Presentacion.HELPERS.ErrorPrint;
using static Presentacion.HELPERS.GenericUtil;
using static Presentacion.HELPERS.GenericMethod;
using static Presentacion.HELPERS.AppearanceUtil;
using System.Threading;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;

namespace Presentacion.MOD_FACT_VTA.MOD_VTA.Reportes.FormularioRep
{
    public partial class FrmAnalisisCarteraXTrabajar : Form
    {
        private readonly planillaCabeceraBLL BLPlanilla = new planillaCabeceraBLL();
        public FrmAnalisisCarteraXTrabajar()
        {
            InitializeComponent();
        }

        private CancellationTokenSource cancellationtokenSource;

        private void AnalisisCarteraXTrabajar_Load(object sender, EventArgs e)
        {
            StartControls();
        }

        private void StartControls()
        {
            btnGenerarReporte.StyleButtonFlat();
            btnCancelar.StyleButtonFlat();
        }

        private async void BtnGenerarReporte_Click(object sender, EventArgs e)
        {
            FrmLoading frmLoading = null;
            try
            {
                cancellationtokenSource = new CancellationTokenSource();
                CancellationToken cancellationToken = cancellationtokenSource.Token;
                frmLoading = frmLoading.StartLoadingForm(this);
                DataTable dt = await Task.Run(() => BLPlanilla.AnalisisCarteraXTrabajar(cancellationToken, dtFechaReporte.Value));
                frmLoading.CloseLoadingForm();
                if (cancellationToken.IsCancellationRequested)
                    return;
                const string titulo = "ANÁLISIS DE CARTERA TOTAL POR TRABAJAR";
                const string data_set_name = "DataSet1";
                string reporte = ObtenerRutaReporteTareaje("RptAnalisisCarteraXTrabajar", Entidades.Modulo.MOD_VTA);
                string fechaReporteText = string.Concat("Fecha Reporte: ", dtFechaReporte.Value.Month.NombreMes(), " - ", dtFechaReporte.Value.Year);
                object[] parameters = { titulo, fechaReporteText };
                Form frm = CreateReportForm(reporte, data_set_name, dt, DisplayMode.Normal, ZoomMode.PageWidth, parameters);
                frm.Show();
            }
            catch(SqlException sqlEx)
            {
                if (sqlEx.Number == 0 && cancellationtokenSource.IsCancellationRequested)
                {
                    _ = MessageBox.Show("Proceso Cancelado");
                }
                else
                    sqlEx.PrintException();
            }
            catch (Exception ex)
            {
                frmLoading.CloseLoadingForm();
                ex.PrintException();
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            if (cancellationtokenSource != null)
                cancellationtokenSource.Cancel();
        }
    }
}
