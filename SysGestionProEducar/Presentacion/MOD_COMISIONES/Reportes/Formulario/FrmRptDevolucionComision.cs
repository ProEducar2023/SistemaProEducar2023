using System;
using System.Windows.Forms;
using static Presentacion.HELPERS.ErrorPrint;
using static Presentacion.HELPERS.GenericMethod;
using static Presentacion.HELPERS.GenericUtil;
using static Presentacion.HELPERS.AppearanceUtil;
using BLL;
using System.Data;
using System.Threading.Tasks;
using Presentacion.HELPERS.Forms;

namespace Presentacion.MOD_COMISIONES.Reportes.Formulario
{
    public partial class FrmRptDevolucionComision : Form
    {
        public FrmRptDevolucionComision()
        {
            CenterToParent();
            InitializeComponent();
            CargarPrograma();
        }

        private static FrmRptDevolucionComision _instancia;
        public static FrmRptDevolucionComision Instancia()
        {
            if (_instancia == null || _instancia.IsDisposed)
                _instancia = new FrmRptDevolucionComision();
            return _instancia;
        }

        private readonly comisionesBLL BLComision = new comisionesBLL();
        private readonly programaBLL BLPrograma = new programaBLL();

        private void FrmRptDevolucionComision_Load(object sender, EventArgs e)
        {
            StartControls();
        }

        private void StartControls()
        {
            dtFechaAprobIni.Value = new DateTime(2019, 1, 1);
            dtFechaAprobFin.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
            dtFechaDevIni.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtFechaDevFin.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
            btnGenerarReporte.StyleButtonFlat();
            cboPrograma.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void CargarPrograma()
        {
            DataTable dt = BLPrograma.obtenerProgramaBLL();
            cboPrograma.DataSource = dt;
            cboPrograma.DisplayMember = "DESC_PROGRAMA";
            cboPrograma.ValueMember = "COD_PROGRAMA";
        }

        private async void BtnGenerarReporte_Click(object sender, EventArgs e)
        {
            FrmLoading frmLoading = null;
            try
            {
                frmLoading = frmLoading.StartLoadingForm(this);
                string codPrograma = cboPrograma.SelectedValue.ToString();
                DateTime fechaAprobIni = dtFechaAprobIni.Value;
                DateTime fechaAprobFin = dtFechaAprobFin.Value;
                DateTime fechaDevIni = dtFechaDevIni.Value;
                DateTime fechaDevFin = dtFechaDevFin.Value;
                DataTable dt = await Task.Run(() => BLComision.RptDevolucionLiquidacionComisiones(codPrograma, fechaAprobIni, fechaAprobFin, fechaDevIni, fechaDevFin));
                frmLoading.CloseLoadingForm();
                string reporte = ObtenerRutaReporteTareaje("RptDevolucionComision", Entidades.Modulo.MOD_COMISIONES);
                string dataSetName = "DataSet1";
                string titulo = "REPORTE DE DEVOLUCIONES DE VENTAS PARA DESCONTAR EN LA LIQUIDACIÓN DE COMISIONES";
                string fechaPar1 = string.Concat("Fecha Aprobación: ", fechaAprobIni.ToShortDateString(), " - ", fechaAprobFin.ToShortDateString());
                string fechaPar2 = string.Concat("Fecha Devolución: ", fechaDevIni.ToShortDateString(), " - ", fechaDevFin.ToShortDateString());
                string programa = string.Concat("Programa: ", cboPrograma.Text);
                object[] parameters = { titulo, programa, fechaPar1, fechaPar2 };
                Form frm = CreateReportForm(reporte, dataSetName, dt, parameters);
                frm.Show();
            }
            catch (Exception ex)
            {
                frmLoading.CloseLoadingForm();
                ex.PrintException();
            }
        }
    }
}
