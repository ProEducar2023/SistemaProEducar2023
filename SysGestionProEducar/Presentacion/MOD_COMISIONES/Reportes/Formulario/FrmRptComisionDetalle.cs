using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using static Presentacion.HELPERS.GenericMethod;
using static Presentacion.HELPERS.GenericUtil;
using static Presentacion.HELPERS.ErrorPrint;
using static Presentacion.HELPERS.AppearanceUtil;
using static Presentacion.HELPERS.Constantes;
using Entidades;
using System.Threading.Tasks;
using Presentacion.HELPERS.Forms;

namespace Presentacion.MOD_COMISIONES.Reportes.Formulario
{
    public partial class FrmRptComisionDetalle : Form
    {
        public FrmRptComisionDetalle()
        {
            InitializeComponent();
        }

        private static FrmRptComisionDetalle instancia;
        public static FrmRptComisionDetalle Instancia()
        {
            if (instancia == null || instancia.IsDisposed)
                instancia = new FrmRptComisionDetalle();
            return instancia;
        }

        private readonly comisionesBLL BLComision = new comisionesBLL();
        private readonly personaBLL BLPersona = new personaBLL();
        private readonly nivelBLL BLNivel = new nivelBLL();

        private DataTable dtPeriodoGenerado;

        private delegate string[] ObtenerParametrosRpt();

        private void FrmRptComisionDetalle_Load(object sender, EventArgs e)
        {
            StartControls();
            CargarNivelVenta();
            CargarPeriodoGenerado();
        }

        private void StartControls()
        {
            cboNivelVenta.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPeriodoGen.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPersona.DropDownStyle = ComboBoxStyle.DropDownList;

            btnImprimir.StyleButtonFlat();
        }

        private void CargarPeriodoGenerado()
        {
            dtPeriodoGenerado = BLComision.ObtenerPeriodoGeneradosComisionYDevolucion();
            if (dtPeriodoGenerado != null && dtPeriodoGenerado.Columns.Count > 0)
            {
                DataRow row = dtPeriodoGenerado.NewRow();
                row["ID"] = 0;
                row["FE_AÑO_PER"] = "";
                row["FE_MES_PER"] = "";
                row["PERIODO_TEXT"] = "Seleccione";
                dtPeriodoGenerado.Rows.InsertAt(row, 0);

                cboPeriodoGen.ValueMember = "ID";
                cboPeriodoGen.DisplayMember = "PERIODO_TEXT";
                cboPeriodoGen.DataSource = dtPeriodoGenerado;
            }
        }

        private void CargarNivelVenta()
        {
            DataTable dt = BLNivel.obtenerNivelBLL().Select("COD_NIVEL IN ('01', '02', '03', '04')").CopyToDataTable();
            cboNivelVenta.ValueMember = "COD_NIVEL";
            cboNivelVenta.DisplayMember = "DESC_NIVEL";
            cboNivelVenta.DataSource = dt;
        }

        private DataRow PeriodoSeleccionado
        {
            get
            {
                if (dtPeriodoGenerado != null)
                    return dtPeriodoGenerado.Select("ID = " + Convert.ToInt32(cboPeriodoGen.SelectedValue)).FirstOrDefault();
                return null;
            }
        }

        private async void BtnImprimir_Click(object sender, EventArgs e)
        {
            FrmLoading frmLoading = null;
            try
            {
                if (!ValidarGenerarReporte())
                    return;
                frmLoading = frmLoading.StartLoadingForm(this);
                frmLoading.Show();
                DataTable dt = await ObtenerComionesDetalle();
                const string data_set_name = "DataSet1";
                string reporte = ObtenerModeloReporte();
                string titulo = ObtenerTituloReporte();
                string periodoText = string.Concat("Periodo: ", PeriodoSeleccionado["FE_MES_PER"].ToString(), " - ", PeriodoSeleccionado["FE_AÑO_PER"].ToString());
                object[] parameters = { titulo, periodoText };
                frmLoading.CloseLoadingForm();
                Form frm = CreateReportForm(reporte, data_set_name, dt, parameters);
                frm.Show();
            }
            catch (Exception ex)
            {
                frmLoading.CloseLoadingForm();
                ex.PrintException();
            }
        }

        private async Task<DataTable> ObtenerComionesDetalle()
        {
            string[] parameters = ObtenerParametrosReporte();
            string feAñoPer = parameters[0];
            string feMesPer = parameters[1];
            string codPer = parameters[2];
            string codNivel = parameters[3];
            Task<DataTable> dt = Task.Run(() =>
            {
                switch (cboNivelVenta.SelectedValue?.ToString())
                {
                    case COD_NIVEL_VENDEDOR: return BLComision.RptComisionesDetalleXVendedor(feAñoPer, feMesPer, codPer);
                    default: return BLComision.RptComisionesDetalleXSuperior(feAñoPer, feMesPer, codPer, codNivel);
                }
            });
            return await dt;
        }

        private string[] ObtenerParametrosReporte()
        {
            string[] parameters = null;
            if (InvokeRequired)
            {
                ObtenerParametrosRpt del = new ObtenerParametrosRpt(ObtenerParametrosReporte);
                _ = Invoke(del, parameters);
            }
            else
            {
                string feAñoPer = PeriodoSeleccionado["FE_AÑO_PER"].ToString();
                string feMesPer = PeriodoSeleccionado["FE_MES_PER"].ToString();
                string codPer = cboPersona.SelectedValue?.ToString();
                string codNivel = cboNivelVenta.SelectedValue?.ToString();
                parameters = new[] { feAñoPer, feMesPer, codPer, codNivel };
            }
            return parameters;
        }

        private string ObtenerModeloReporte()
        {
            switch (cboNivelVenta.SelectedValue?.ToString())
            {
                case COD_NIVEL_VENDEDOR: return ObtenerRutaReporteTareaje("RptComisionesDetalle", Modulo.MOD_COMISIONES);
                default: return ObtenerRutaReporteTareaje("RptComisionesDetalle2", Modulo.MOD_COMISIONES);
            }
        }

        private string ObtenerTituloReporte()
        {
            switch (cboNivelVenta.SelectedValue?.ToString())
            {
                case COD_NIVEL_VENDEDOR: return "REPORTE DE COMISIONES VENTAS PROPIAS - POR VENDEDOR";
                default: return string.Concat("REPORTE DE COMISIONES POR TERCEROS - POR ", cboNivelVenta.Text);
            }
        }

        private bool ValidarGenerarReporte()
        {
            if (string.IsNullOrEmpty(cboNivelVenta.SelectedValue?.ToString()))
            {
                _ = MessageBox.Show("Seleccione un nivel de venta", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cboPersona.SelectedValue == null)
            {
                _ = MessageBox.Show("Seleccione una persona", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(cboPeriodoGen.SelectedValue?.ToString()) || (PeriodoSeleccionado != null && PeriodoSeleccionado["ID"].ToInt32() == 0))
            {
                _ = MessageBox.Show("Seleccione un período", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void CboNivelVenta_SelectedValueChanged(object sender, EventArgs e)
        {
            CargarPersonaXNivelVenta();
        }

        private void CargarPersonaXNivelVenta()
        {
            if (cboNivelVenta.SelectedValue != null)
            {
                DataTable dt = BLPersona.ObtenerMaestroPersonaXNivel(cboNivelVenta.SelectedValue.ToString());
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow row = dt.NewRow();
                    row["COD_PER"] = "";
                    row["DESC_PER"] = "Todos";
                    row["COD_NIVEL"] = "00";
                    dt.Rows.InsertAt(row, 0);

                    cboPersona.ValueMember = "COD_PER";
                    cboPersona.DisplayMember = "DESC_PER";
                    cboPersona.DataSource = dt;
                }
            }
        }
    }
}
