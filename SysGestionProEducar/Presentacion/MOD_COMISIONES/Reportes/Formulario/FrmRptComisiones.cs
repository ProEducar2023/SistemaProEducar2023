using BLL;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using static Presentacion.HELPERS.AppearanceUtil;
using static Presentacion.HELPERS.GenericUtil;
using static Presentacion.HELPERS.ErrorPrint;
using System.Threading.Tasks;

namespace Presentacion.MOD_COMISIONES.Reportes.Formulario
{
    public partial class FrmRptComisiones : Form
    {
        public FrmRptComisiones()
        {
            InitializeComponent();
        }

        private readonly programaBLL BLPrograma = new programaBLL();
        private readonly personaBLL BLMaestroPersona = new personaBLL();
        private readonly nivelBLL BLNivel = new nivelBLL();
        private readonly comisionesBLL BLComisiones = new comisionesBLL();
        private readonly tipoPlanillaCreacionBLL BLTipoPlanilla = new tipoPlanillaCreacionBLL();

        private HELPERS.Forms.FrmLoading frmLoading;

        private const string COD_NIVEL_VENDEDOR = "04";

        private void FrmRptComisiones_Load(object sender, EventArgs e)
        {
            StartControls();
            CargarComboboxPrograma();
            CargarNivelVenta();
            CargarPersona();
            CagarTipoVenta();
        }

        private void StartControls()
        {
            btnImprimir.StyleButtonFlat();
            FormatCombobox(cboPrograma);
            FormatCombobox(cboNivelVenta);
            FormatCombobox(cboPersona);
            FormatCombobox(cboTipoVenta);
            dtFechaIniVigencia.Value = new DateTime(2019, 1, 1);
        }

        private void FormatCombobox(ComboBox comboBox)
        {
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void CargarComboboxPrograma()
        {
            DataTable dt = BLPrograma.obtenerProgramaBLL();
            cboPrograma.DataSource = dt;
            cboPrograma.DisplayMember = "DESC_PROGRAMA";
            cboPrograma.ValueMember = "COD_PROGRAMA";
        }

        private void CagarTipoVenta()
        {
            DataTable dt = BLTipoPlanilla.obtenerTipoPlanillaCreacionBLL().Select("COD_TIPO_PLLA IN('PP', 'PV')").CopyToDataTable();
            if (dt != null)
            {
                foreach (DataColumn column in dt.Columns)
                {
                    column.AllowDBNull = true;
                }
                DataRow row = dt.NewRow();
                row["COD_TIPO_PLLA"] = "00";
                row["DESC_TIPO"] = "Todos";
                dt.Rows.InsertAt(row, 0);

                cboTipoVenta.DataSource = dt;
                cboTipoVenta.ValueMember = "COD_TIPO_PLLA";
                cboTipoVenta.DisplayMember = "DESC_TIPO";
            }
        }

        private void CargarNivelVenta()
        {
            DataTable dt = BLNivel.obtenerNivelBLL();
            cboNivelVenta.DataSource = dt;
            cboNivelVenta.ValueMember = "COD_NIVEL";
            cboNivelVenta.DisplayMember = "DESC_NIVEL";
        }

        private void CargarPersona()
        {
            DataTable dt = BLMaestroPersona.ObtenerMaestroPersonaXNivel(cboNivelVenta.SelectedValue.ToString());
            foreach (DataColumn column in dt.Columns)
            {
                column.AllowDBNull = true;
            }
            DataRow row = dt.NewRow();
            row["COD_PER"] = "0";
            row["DESC_PER"] = "Todos";
            dt.Rows.InsertAt(row, 0);

            cboPersona.DataSource = dt;
            cboPersona.ValueMember = "COD_PER";
            cboPersona.DisplayMember = "DESC_PER";
        }

        private void CboNivelVenta_SelectedValueChanged(object sender, EventArgs e)
        {
            CargarPersona();
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdbOP1.Checked)
                    ReporteOpcion1();
                else if (rdbOP2.Checked)
                    ReporteOpcion2();
            }
            catch (Exception ex)
            {
                frmLoading.Close();
                ex.PrintException();
            }
        }

        private async void ReporteOpcion1()
        {
            frmLoading = new HELPERS.Forms.FrmLoading()
            {
                Owner = this,
                ShowInTaskbar = false
            };
            frmLoading.Show();

            string reportSource = ObtenerRutaReporteTareaje("RptComisionesXNivelVenta", Entidades.Modulo.MOD_COMISIONES);
            string dataSetName = "DataSet1";
            string titulo = string.Concat("REPORTE COMISIONES - POR ", cboNivelVenta.Text);
            string programaText = string.Concat("Programa: ", cboPrograma.Text);
            string nivelVentaText = string.Concat("Nivel Venta: ", cboNivelVenta.Text);
            string nombrePersonaText = string.Concat("Nombre: ", cboPersona.Text);
            string fechaVigenciaText = string.Concat("Vigencia: ", dtFechaIniVigencia.Text, " - ", dtFechaFinVigencia.Text);
            object[] parameters = { titulo, programaText, nivelVentaText, nombrePersonaText, fechaVigenciaText, cboNivelVenta.SelectedValue.ToString(),
                rdbIncluirResumen.Checked || rdbSoloDetalle.Checked, rdbIncluirResumen.Checked || rdbSoloResumen.Checked };
            string codTipoVenta = cboTipoVenta.SelectedValue.ToString();
            string codNivelVenta = cboNivelVenta.SelectedValue.ToString();
            string codPersona = cboPersona.SelectedValue.ToString();
            DateTime fechaIniVigencia = dtFechaIniVigencia.Value;
            DateTime fechaFinVigencia = dtFechaFinVigencia.Value;

            DataTable dt = null;
            await Task.Run(() =>
            {
                dt = ObtenerData(codTipoVenta, codNivelVenta, codPersona, fechaIniVigencia, fechaFinVigencia);
            });
            frmLoading.Close();
            Form frm = CreateReportForm
            (
                reportSource,
                dataSetName,
                dt,
                parameters
            );
            frm.Show();
        }

        private async void ReporteOpcion2()
        {
            frmLoading = new HELPERS.Forms.FrmLoading()
            {
                Owner = this,
                ShowInTaskbar = false
            };
            frmLoading.Show();

            string reportSource = ObtenerRutaReporteTareaje("RptComisionesPeriodico", Entidades.Modulo.MOD_COMISIONES);
            string dataSetName = "DataSet1";
            string titulo = string.Concat("REPORTE COMISIONES - POR ", cboNivelVenta.Text);
            string programaText = string.Concat("Programa: ", cboPrograma.Text);
            string nivelVentaText = string.Concat("Nivel Venta: ", cboNivelVenta.Text);
            string nombrePersonaText = string.Concat("Nombre: ", cboPersona.Text);
            string fechaVigenciaText = string.Concat("Vigencia: ", dtFechaIniVigencia.Text, " - ", dtFechaFinVigencia.Text);
            object[] parameters = { titulo, programaText, nivelVentaText, nombrePersonaText, fechaVigenciaText, cboNivelVenta.Text.ToLower(), rdbSoloDetalle.Checked, rdbSoloResumen.Checked };
            string codTipoVenta = cboTipoVenta.SelectedValue.ToString();
            string codNivelVenta = cboNivelVenta.SelectedValue.ToString();
            string codPersona = cboPersona.SelectedValue.ToString();
            DateTime fechaIniVigencia = dtFechaIniVigencia.Value;
            DateTime fechaFinVigencia = dtFechaFinVigencia.Value;

            DataTable dt = new DataTable();
            if (!rdbSoloResumen.Checked)
            {
                await Task.Run(() =>
                {
                    dt = BLComisiones.RptComisionXNivelVenta(codTipoVenta, codNivelVenta, codPersona, fechaIniVigencia, fechaFinVigencia);
                });
            }
            frmLoading.Close();
            ReportViewer reportViewer = null;
            Form frm = CreateReportForm
            (
                ref reportViewer,
                reportSource,
                dataSetName,
                dt,
                parameters
            );
            if (rdbIncluirResumen.Checked || rdbSoloResumen.Checked)
                reportViewer.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(RptvInforme_SubReportProcessing);
            reportViewer.RefreshReport();
            frm.Show();
        }

        private void RptvInforme_SubReportProcessing(object sender, SubreportProcessingEventArgs e)
        {
            e.DataSources.Add(
                new ReportDataSource(
                    "DataSet1",
                    BLComisiones.RptComisionResumen(cboTipoVenta.SelectedValue.ToString(), dtFechaIniVigencia.Value, dtFechaFinVigencia.Value)
                    )
                );
        }

        private DataTable ObtenerData(string codTipoVenta, string codNivelVenta, string codPersona, DateTime fechaIniVigencia, DateTime fechaFinVigencia)
        {
            if (codNivelVenta != COD_NIVEL_VENDEDOR)
                return BLComisiones.RptComisionVendedoresXNivelVenta(codTipoVenta, codNivelVenta, codPersona, fechaIniVigencia, fechaFinVigencia);
            else
                return BLComisiones.RptComisionXVendedor(codTipoVenta, codPersona, fechaIniVigencia, fechaFinVigencia);
        }
    }
}
