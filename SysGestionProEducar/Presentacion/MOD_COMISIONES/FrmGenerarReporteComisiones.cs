using BLL;
using System;
using System.Data;
using System.Windows.Forms;
using System.Linq;
using static Presentacion.HELPERS.AppearanceUtil;
using static Presentacion.HELPERS.GenericUtil;
using static Presentacion.HELPERS.GenericMethod;
using static Presentacion.HELPERS.ErrorPrint;
using Presentacion.HELPERS.Forms;
using System.Threading.Tasks;
using Entidades;

namespace Presentacion.MOD_COMISIONES
{
    public partial class FrmGenerarReporteComisiones : Form
    {
        public FrmGenerarReporteComisiones()
        {
            InitializeComponent();
        }

        private readonly programaBLL BLPrograma = new programaBLL();
        private readonly personaBLL BLMaestroPersona = new personaBLL();
        private readonly nivelBLL BLNivel = new nivelBLL();
        private readonly comisionesBLL BLComision = new comisionesBLL();

        private DataTable dtPeriodo;

        private const string COD_NIVEL_VENDEDOR = "04";
        private void FrmGenerarReporteComisiones_Load(object sender, EventArgs e)
        {
            StartControls();
            CargarPrograma();
            CargarNivelVenta();
            CargarPersona();
        }

        private void StartControls()
        {
            btnImprimir.StyleButtonFlat();
            FormatCombobox(cboPrograma);
            FormatCombobox(cboNivelVenta);
            FormatCombobox(cboPersona);
            FormatCombobox(cboPeriodoGen);
            rdbComisionGenerado.Checked = true;
        }

        private void FormatCombobox(ComboBox comboBox)
        {
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void CargarPrograma()
        {
            DataTable dt = BLPrograma.obtenerProgramaBLL();
            cboPrograma.DataSource = dt;
            cboPrograma.DisplayMember = "DESC_PROGRAMA";
            cboPrograma.ValueMember = "COD_PROGRAMA";
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
            if (dt != null)
            {
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
        }

        private void CargarPeriodoGeneradoComision()
        {
            dtPeriodo = BLComision.ObtenerPeriodosGeneradosComision();
            cboPeriodoGen.ValueMember = "ID";
            cboPeriodoGen.DisplayMember = "PERIODO_TEXT";
            cboPeriodoGen.DataSource = dtPeriodo;
        }

        private void CargarPeriodoExcluidoComision()
        {
            dtPeriodo = BLComision.ObtenerPeriodosExcluidosComision();
            cboPeriodoGen.ValueMember = "ID";
            cboPeriodoGen.DisplayMember = "PERIODO_TEXT";
            cboPeriodoGen.DataSource = dtPeriodo;
        }

        private void CboNivelVenta_SelectedValueChanged(object sender, EventArgs e)
        {
            CargarPersona();
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            if (rdbComisionGenerado.Checked)
                GenerarReporteComisionGenerado();
            else if (rdbComisionExcluido.Checked)
                GenerarReporteComisionExcluido();
        }

        private async void GenerarReporteComisionGenerado()
        {
            FrmLoading frmLoading = null;
            try
            {
                frmLoading = frmLoading.StartLoadingForm(this);
                if (dtPeriodo == null || dtPeriodo.Rows.Count == 0)
                {
                    frmLoading.CloseLoadingForm();
                    return;
                }
                DataRow row = dtPeriodo.Rows.Cast<DataRow>().SingleOrDefault(x => Convert.ToInt32(x["ID"]) == Convert.ToInt32(cboPeriodoGen.SelectedValue));
                string feAñoPer = row["FE_AÑO_PER"].ToString();
                string feMesPer = row["FE_MES_PER"].ToString();
                string periodoProceso = row["PERIODO_PROCESO"].ToString();
                string codPrograma = cboPrograma.SelectedValue.ToString();
                string codVendedor = cboNivelVenta.SelectedValue.ToString() == COD_NIVEL_VENDEDOR ? cboPersona.SelectedValue.ToString() : "0";
                string codSuperior = cboNivelVenta.SelectedValue.ToString() != COD_NIVEL_VENDEDOR ? cboPersona.SelectedValue.ToString() : "0";
                string codNivelVenta = cboNivelVenta.SelectedValue.ToString() != COD_NIVEL_VENDEDOR ? cboNivelVenta.SelectedValue.ToString() : "0";
                DataTable dt;
                if (cboNivelVenta.SelectedValue.ToString() == COD_NIVEL_VENDEDOR)
                    dt = await Task.Run(() => BLComision.RptContratosComisionGeneradosXVendedor(feAñoPer, feMesPer, periodoProceso, codPrograma, codVendedor));
                else
                    dt = await Task.Run(() => BLComision.RptContratosComisionGeneradosXSuperior(feAñoPer, feMesPer, periodoProceso, codPrograma, codSuperior, codNivelVenta));
                frmLoading.Close();

                string reporte = cboNivelVenta.SelectedValue.ToString() == COD_NIVEL_VENDEDOR
                    ? ObtenerRutaReporteTareaje("RptComisionesGeneradasXVendedor", Modulo.MOD_COMISIONES)
                    : ObtenerRutaReporteTareaje("RptComisionesGeneradasXSuperior", Modulo.MOD_COMISIONES);
                string dataSetName = "DataSet1";
                string fechaPeriodo = string.Empty;
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow rw = dt.Select("FECHA_COBRA_INI IS NOT NULL").FirstOrDefault();
                    if (rw != null)
                        fechaPeriodo = Convert.ToDateTime(rw["FECHA_COBRA_INI"]).ToShortDateString() + " - " + Convert.ToDateTime(rw["FECHA_COBRA_FIN"]).ToShortDateString();
                }
                string titulo = "REPORTE DE COMISIONES POR VENTA APROBADA";
                string programa = string.Concat("Programa: ", cboPrograma.Text);
                string nivelVenta = string.Concat("Nivel de Venta: ", cboNivelVenta.Text);
                string persona = string.Concat("Nombre: ", cboPersona.Text);
                string ventasAprobadas = string.Concat("Ventas Aprobadas: ", fechaPeriodo);
                string periodo = string.Concat("Período: ", cboPeriodoGen.Text);
                object[] parameter = { titulo, programa, nivelVenta, persona, ventasAprobadas, periodo, cboNivelVenta.Text };
                Form form = CreateReportForm(reporte, dataSetName, dt, parameter);
                form.Show();
            }
            catch (Exception ex)
            {
                frmLoading.CloseLoadingForm();
                ex.PrintException();
            }
        }

        private async void GenerarReporteComisionExcluido()
        {
            FrmLoading frmLoading = null;
            try
            {
                frmLoading = frmLoading.StartLoadingForm(this);
                if (dtPeriodo == null || dtPeriodo.Rows.Count == 0)
                {
                    frmLoading.CloseLoadingForm();
                    return;
                }
                DataRow row = dtPeriodo.Rows.Cast<DataRow>().SingleOrDefault(x => Convert.ToInt32(x["ID"]) == Convert.ToInt32(cboPeriodoGen.SelectedValue));
                string feAñoPer = row["FE_AÑO_PER"].ToString();
                string feMesPer = row["FE_MES_PER"].ToString();
                string periodoProceso = row["PERIODO_PROCESO"].ToString();
                string codPrograma = cboPrograma.SelectedValue.ToString();
                string codVendedor = cboNivelVenta.SelectedValue.ToString() == COD_NIVEL_VENDEDOR ? cboPersona.SelectedValue.ToString() : "0";
                string codSuperior = cboNivelVenta.SelectedValue.ToString() != COD_NIVEL_VENDEDOR ? cboPersona.SelectedValue.ToString() : "0";
                string codNivelVenta = cboNivelVenta.SelectedValue.ToString() != COD_NIVEL_VENDEDOR ? cboNivelVenta.SelectedValue.ToString() : "0";

                DataTable dt;
                if (cboNivelVenta.SelectedValue.ToString() == COD_NIVEL_VENDEDOR)
                    dt = await Task.Run(() => BLComision.RptContratosComisionExcluidosXVendedor(feAñoPer, feMesPer, periodoProceso, codPrograma, codVendedor));
                else
                    dt = await Task.Run(() => BLComision.RptContratosComisionExcluidosXSuperior(feAñoPer, feMesPer, periodoProceso, codPrograma, codSuperior, codNivelVenta));

                frmLoading.Close();

                string reporte = cboNivelVenta.SelectedValue.ToString() == COD_NIVEL_VENDEDOR
                    ? ObtenerRutaReporteTareaje("RptComisionesExcluidosXVendedor", Modulo.MOD_COMISIONES)
                    : ObtenerRutaReporteTareaje("RptComisionesExcluidosXSuperior", Modulo.MOD_COMISIONES);
                string dataSetName = "DataSet1";
                string fechaPeriodo = string.Empty;
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow rw = dt.Select("FECHA_COBRA_INI IS NOT NULL").FirstOrDefault();
                    if (rw != null)
                        fechaPeriodo = Convert.ToDateTime(rw["FECHA_COBRA_INI"]).ToShortDateString() + " - " + Convert.ToDateTime(rw["FECHA_COBRA_FIN"]).ToShortDateString();
                }
                string titulo = "REPORTE DE COMISIONES EXCLUIDOS POR VENTA APROBADA";
                string programa = string.Concat("Programa: ", cboPrograma.Text);
                string nivelVenta = string.Concat("Nivel de Venta: ", cboNivelVenta.Text);
                string persona = string.Concat("Nombre: ", cboPersona.Text);
                string ventasAprobadas = string.Concat("Ventas Aprobadas: ", fechaPeriodo);
                string periodo = string.Concat("Período: ", cboPeriodoGen.Text);
                object[] parameter = { titulo, programa, nivelVenta, persona, ventasAprobadas, periodo, cboNivelVenta.Text };
                Form form = CreateReportForm(reporte, dataSetName, dt, parameter);
                form.Show();
            }
            catch (Exception ex)
            {
                frmLoading.CloseLoadingForm();
                ex.PrintException();
            }
        }

        private void RdbComisionGenerado_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbComisionGenerado.Checked)
                CargarPeriodoGeneradoComision();
            else if (rdbComisionExcluido.Checked)
                CargarPeriodoExcluidoComision();
        }
    }
}
