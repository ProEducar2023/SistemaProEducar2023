using BLL;
using System;
using System.Data;
using System.Windows.Forms;
using static Presentacion.HELPERS.GenericUtil;
using static Presentacion.HELPERS.ErrorPrint;

namespace Presentacion.MOD_FACT_VTA.MOD_VTA.Reportes.FormularioRep
{
    public partial class FrmRptResumenSeguimientoPlanillas : Form
    {
        private readonly programaBLL prgBLL;
        private readonly puntoCobranzaBLL BLPuntoCobranza;
        private readonly SeguimientoPlanillasBLL BLSeguimiento;
        private readonly ChequeBLL BLCheque;

        private readonly string año, mes;
        private readonly bool acces;
        public FrmRptResumenSeguimientoPlanillas(string año, string mes, bool acces)
        {
            InitializeComponent();
            prgBLL = new programaBLL();
            BLPuntoCobranza = new puntoCobranzaBLL();
            BLSeguimiento = new SeguimientoPlanillasBLL();
            BLCheque = new ChequeBLL();

            this.año = año;
            this.mes = mes;
            this.acces = acces;

            StartControls();
        }

        private void FrmRptResumenSeguimientoPlanillas_Load(object sender, EventArgs e)
        {
            CargarPrograma();
            CargarPuntoCobranza();
            CargarMeses();
        }

        private void StartControls()
        {
            numAño.Maximum = decimal.MaxValue;
            cboPrograma.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPuntoCobranza.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMes.DropDownStyle = ComboBoxStyle.DropDownList;

            Text = acces ? "REPORTE SEGUIMIENTO PLANILLAS" : "REPORTE SEGUIMIENTO CHEQUES";
        }

        private void CargarPrograma()
        {
            DataTable dt = prgBLL.obtenerProgramaBLL();
            //DataRow row = dt.NewRow();
            //row["COD_PROGRAMA"] = "0";
            //row["DESC_PROGRAMA"] = "Todos";
            //dt.Rows.InsertAt(row, 0);
            cboPrograma.ValueMember = "COD_PROGRAMA";
            cboPrograma.DisplayMember = "DESC_PROGRAMA";
            cboPrograma.DataSource = dt;
            cboPrograma.SelectedIndex = 0;
        }

        private void CargarPuntoCobranza()
        {
            DataTable dt = BLPuntoCobranza.ListarPtoCobranzaXPais(EmpresaSistema.CodPais);
            DataView dv = dt.DefaultView;
            dv.Sort = "DESC_PTO_COB ASC";
            DataTable dtSort = dv.ToTable();
            DataRow row = dtSort.NewRow();
            row["COD_PTO_COB"] = "000";
            row["DESC_PTO_COB"] = "Todos";
            dtSort.Rows.InsertAt(row, 0);
            cboPuntoCobranza.DataSource = dtSort;
            cboPuntoCobranza.ValueMember = "COD_PTO_COB";
            cboPuntoCobranza.DisplayMember = "DESC_PTO_COB";
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                if (acces)
                    ReporteSeguimientoPlanillas();
                else
                    ReporteSeguimientoCheques();
            }
            catch (Exception ex)
            {
                ex.PrintException();
            }
        }

        private void ReporteSeguimientoPlanillas()
        {
            string reporte = ObtenerRutaReporteTareaje_MOD_FACT_VTA("RptResumenSeguimientoPlanilla2");
            string dataSetName = "DataSet1";
            DataTable dt = BLSeguimiento.RptResumenSeguimientoPlanilla(cboPrograma.SelectedValue.ToString(), numAño.Value.ToString(), cboMes.SelectedValue.ToString(), cboPuntoCobranza.SelectedValue.ToString());
            string titulo = "REPORTE DE SEGUIMIENTO DE ENVIO DE PLANILLAS PARA DESCTO";
            string periodo = cboMes.Text + " - " + numAño.Value.ToString();
            object[] reportParam = new object[] { titulo, cboPrograma.Text, periodo, cboPuntoCobranza.Text };
            Form frm = CreateReportForm(reporte, dataSetName, dt, reportParam);
            frm.Show();
        }

        private void ReporteSeguimientoCheques()
        {
            string reporte = ObtenerRutaReporteTareaje_MOD_FACT_VTA("RptResumenSeguimientoCheque");
            string dataSetName = "DataSet1";
            DataTable dt = BLCheque.RptResumenSeguimientoCheque(cboPrograma.SelectedValue.ToString(), cboPuntoCobranza.SelectedValue.ToString(), numAño.Value.ToString(), cboMes.SelectedValue.ToString());
            string titulo = "REPORTE DE SEGUIMIENTO CHEQUES";
            string periodo = cboMes.Text + " - " + numAño.Value.ToString();
            object[] reportParam = new object[] { titulo, cboPrograma.Text, periodo, cboPuntoCobranza.Text };
            Form frm = CreateReportForm(reporte, dataSetName, dt, reportParam);
            frm.Show();
        }

        private void CargarMeses()
        {
            var meses = new[]
            {
                new { value = "01", name = "ENERO" },
                new { value = "02", name = "FEBRERO" },
                new { value = "03", name = "MARZO" },
                new { value = "04", name = "ABRIL" },
                new { value = "05", name = "MAYO" },
                new { value = "06", name = "JUNIO" },
                new { value = "07", name = "JULIO" },
                new { value = "08", name = "AGOSTO" },
                new { value = "09", name = "SEPTIEMBRE" },
                new { value = "10", name = "OCTUBRE" },
                new { value = "11", name = "NOVIEMBRE" },
                new { value = "12", name = "DICIEMBRE" }
            };

            cboMes.DataSource = meses;
            cboMes.DisplayMember = "name";
            cboMes.ValueMember = "value";
            cboMes.SelectedValue = mes;
            numAño.Value = Convert.ToDecimal(año);
        }
    }
}
