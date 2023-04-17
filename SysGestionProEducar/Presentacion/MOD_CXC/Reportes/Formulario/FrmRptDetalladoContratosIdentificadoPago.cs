using BLL;
using Presentacion.HELPERS;
using Presentacion.HELPERS.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.MOD_CXC.Reportes.Formulario
{
    public partial class FrmRptDetalladoContratosIdentificadoPago : Form
    {
        private readonly programaBLL BLPrograma = new programaBLL();
        private readonly directorioBLL BLDirectorio = new directorioBLL();
        private readonly cambioTipoPllaHistoricoBLL BLCambioTipPllHistorico = new cambioTipoPllaHistoricoBLL();
        private readonly personaBLL BLMaestroPersona = new personaBLL();

        public FrmRptDetalladoContratosIdentificadoPago()
        {
            InitializeComponent();
        }

        private const string COD_TABLA_AREA_TRABAJO = "AREAT";
        private const string TIPO_TABLA = "D";

        private DataTable dtGestorAreaTrabajo;

        private void FrmRptDetalladoContratosIdentificadoPago_Load(object sender, EventArgs e)
        {
            StartControls();
            CargarPrograma();
            CargarAreaTrabajo();
        }

        private void StartControls()
        {
            cboPrograma.DropDownStyle = ComboBoxStyle.DropDownList;
            cboAreaTrabajo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGestor.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void CargarPrograma()
        {
            DataTable dt = BLPrograma.obtenerProgramaBLL();
            cboPrograma.ValueMember = "COD_PROGRAMA";
            cboPrograma.DisplayMember = "DESC_PROGRAMA";
            cboPrograma.DataSource = dt;
        }

        private void CargarAreaTrabajo()
        {
            DataTable dt = BLDirectorio.obtenerCodigoDescripcionDirectorioBLL(new Entidades.directorioTo { TABLA_COD = COD_TABLA_AREA_TRABAJO, TIPO = TIPO_TABLA });
            dtGestorAreaTrabajo = BLMaestroPersona.ObtenerGestoresXAreaTrabajo();
            if (dt != null)
            {
                DataRow row = dt.NewRow();
                row["CODIGO"] = "0";
                row["DESCRIPCION"] = "Todos";
                dt.Rows.InsertAt(row, 0);

                cboAreaTrabajo.DataSource = dt;
                cboAreaTrabajo.ValueMember = "CODIGO";
                cboAreaTrabajo.DisplayMember = "DESCRIPCION";
            }
        }

        private void CargarGestor()
        {
            DataTable dt = null;
            DataRow[] rows = dtGestorAreaTrabajo.Select("COD_AREA = '" + cboAreaTrabajo.SelectedValue.ToString() + "'");
            if (rows.Any())
                dt = rows.CopyToDataTable();

            if (dt == null)
            {
                dt = new DataTable();
                dt.Columns.Add("COD_PER", typeof(string));
                dt.Columns.Add("DESC_PER", typeof(string));
            }

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

                cboGestor.DataSource = dt;
                cboGestor.ValueMember = "COD_PER";
                cboGestor.DisplayMember = "DESC_PER";
            }
        }

        private void BtnGenerarReporte_Click(object sender, EventArgs e)
        {
            DetalladoXContratoFecIdenPago();
        }

        private async void DetalladoXContratoFecIdenPago()
        {
            FrmLoading frmLoading = null;
            try
            {
                frmLoading = new FrmLoading()
                {
                    Owner = this,
                    ShowInTaskbar = false
                };
                frmLoading.Show();

                string report = GenericUtil.ObtenerRutaReporteTareaje("RptDetalladoContratosIdentificadoPago", Entidades.Modulo.MOD_CXC);
                string dataSetName = "cobranzaUbicacionDetalle";
                string title = "REPORTE DE CONTRATOS POR FECHA DE IDENTIFICACIÓN DEL PAGO";
                string fechaIdentificacion = dtFechaIdenIni.Value.ToShortDateString() + " - " + dtFechaIdenFin.Value.ToShortDateString();
                object[] parameters = new object[] { cboPrograma.Text, cboAreaTrabajo.Text, cboGestor.Text, fechaIdentificacion, title, !chkIncluirSinFecIdenPago.Checked };

                string codPrograma = cboPrograma.SelectedValue.ToString();
                string codAreaTrabajo = cboAreaTrabajo.SelectedValue.ToString();
                string codGestor = cboGestor.SelectedValue.ToString();
                DateTime fechaIdenIni = dtFechaIdenIni.Value;
                DateTime fechaIdenFin = dtFechaIdenFin.Value;
                bool incluirSinFecIdenPago = chkIncluirSinFecIdenPago.Checked;
                DataTable dt = await Task.Run(() => BLCambioTipPllHistorico.RptDetalladoXContratoFecIdenPago(codPrograma, codAreaTrabajo,
                    codGestor, fechaIdenIni, fechaIdenFin, incluirSinFecIdenPago));
                frmLoading.Close();
                Form frm = GenericUtil.CreateReportForm(report, dataSetName, dt, parameters);
                frm.Show();
            }
            catch (Exception ex)
            {
                if (frmLoading != null)
                    frmLoading.Close();
                ex.PrintException();
            }
        }

        private void CboAreaTrabajo_SelectedValueChanged(object sender, EventArgs e)
        {
            CargarGestor();
        }
    }
}
