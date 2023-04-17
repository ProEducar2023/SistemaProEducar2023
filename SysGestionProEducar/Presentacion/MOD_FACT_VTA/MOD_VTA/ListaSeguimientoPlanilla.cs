using BLL;
using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Presentacion.MOD_FACT_VTA.MOD_VTA
{
    public partial class ListaSeguimientoPlanilla : Form
    {
        private static string AÑO, MES;
        public ListaSeguimientoPlanilla(string año, string mes)
        {
            InitializeComponent();
            StartControls();
            AÑO = año;
            MES = mes;
        }

        private readonly SeguimientoPlanillasBLL BLSeguimientoPla = new SeguimientoPlanillasBLL();

        private static readonly CultureInfo culture = CultureInfo.CreateSpecificCulture("en-CA");
        private static readonly Color[] colorBack = new Color[] { Color.PaleTurquoise, Color.MediumSpringGreen, Color.Tan, Color.PeachPuff, Color.LightSalmon, Color.LightSteelBlue };

        private void ListaSeguimientoPlanilla_Load(object sender, EventArgs e)
        {
            CargarMes();
            BackColorLeyeda();
            ColorPanelLeyenda();
        }

        private void StartControls()
        {
            dgvPlanillas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPlanillas.DefaultCellStyle.SelectionBackColor = Color.White;
            dgvPlanillas.DefaultCellStyle.SelectionForeColor = Color.Blue;
            dgvPlanillas.EnableHeadersVisualStyles = false;

            numAño.DecimalPlaces = 0;
            numAño.Maximum = decimal.MaxValue;
            cboMes.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void CargarMes()
        {
            var mes = new[]
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

            cboMes.DataSource = mes;
            cboMes.DisplayMember = "name";
            cboMes.ValueMember = "value";
            cboMes.SelectedValue = MES;
            numAño.Value = Convert.ToDecimal(AÑO);
        }

        private void ListarPlanillas()
        {
            dgvPlanillas.DataSource = BLSeguimientoPla.ListarSeguimientoPlanillasControl(numAño.Value.ToString(), cboMes.SelectedValue.ToString());
            dgvPlanillas.Columns["COD_PTO_COB"].HeaderText = "COD";
            dgvPlanillas.Columns["COD_PTO_COB"].Width = 40;
            dgvPlanillas.Columns["DESC_PTO_COB"].HeaderText = "P. COBRANZA";
            dgvPlanillas.Columns["DESC_PTO_COB"].Width = 120;
            dgvPlanillas.Columns["NRO_PLANILLA_COB"].HeaderText = "NRO.PLLA.";
            dgvPlanillas.Columns["NRO_PLANILLA_COB"].Width = 90;
            dgvPlanillas.Columns["PERIODO"].HeaderText = "PERÍODO";
            dgvPlanillas.Columns["PERIODO"].Width = 60;
            dgvPlanillas.Columns["IMP_ENVIO"].HeaderText = "IMP.PLLA.";
            dgvPlanillas.Columns["IMP_ENVIO"].Width = 70;
            dgvPlanillas.Columns["IMPORTE_LISTADO"].HeaderText = "IMP.LIST";
            dgvPlanillas.Columns["IMPORTE_LISTADO"].Width = 70;
            dgvPlanillas.Columns["IMPORTE_CASILLERO"].HeaderText = "IMP.CASI.";
            dgvPlanillas.Columns["IMPORTE_CASILLERO"].Width = 70;
            dgvPlanillas.Columns["OTROS_DSCTOS"].HeaderText = "O.DCTOS";
            dgvPlanillas.Columns["OTROS_DSCTOS"].Width = 70;
            dgvPlanillas.Columns["IMPORTE_NETO"].HeaderText = "IMP.NETO";
            dgvPlanillas.Columns["IMPORTE_NETO"].Width = 70;
            dgvPlanillas.Columns["FECHA_EJECUCION"].HeaderText = "F.APROBA";
            dgvPlanillas.Columns["FECHA_EJECUCION"].Width = 70;
            dgvPlanillas.Columns["FE_TRANSFERENCIA"].HeaderText = "F.INI.SEGUI";
            dgvPlanillas.Columns["FE_TRANSFERENCIA"].Width = 70;
            dgvPlanillas.Columns["FECHA_ENVIO_CORREO"].HeaderText = "F.ENV.CRREO";
            dgvPlanillas.Columns["FECHA_ENVIO_CORREO"].Width = 85;
            dgvPlanillas.Columns["T_TRANS_ENVIO_1"].HeaderText = "T.TRANS";
            dgvPlanillas.Columns["T_TRANS_ENVIO_1"].Width = 70;
            dgvPlanillas.Columns["FECHA_ENVIO_CORRESP"].HeaderText = "F.ENV.CRRES";
            dgvPlanillas.Columns["FECHA_ENVIO_CORRESP"].Width = 95;
            dgvPlanillas.Columns["T_TRANS_ENVIO_2"].HeaderText = "T.TRANS";
            dgvPlanillas.Columns["T_TRANS_ENVIO_2"].Width = 70;
            dgvPlanillas.Columns["FECHA_RECEP_CORREO"].HeaderText = "F.REC.CRREO";
            dgvPlanillas.Columns["FECHA_RECEP_CORREO"].Width = 85;
            dgvPlanillas.Columns["T_TRANS_RECEP_1"].HeaderText = "T.TRANS";
            dgvPlanillas.Columns["T_TRANS_RECEP_1"].Width = 70;
            dgvPlanillas.Columns["FECHA_RECEP_CORRESP"].HeaderText = "F.REC.CRRES";
            dgvPlanillas.Columns["FECHA_RECEP_CORRESP"].Width = 85;
            dgvPlanillas.Columns["T_TRANS_RECEP_1"].HeaderText = "T.TRANS";
            dgvPlanillas.Columns["T_TRANS_RECEP_1"].Width = 70;
            dgvPlanillas.Columns["FECHA_PROCESO"].HeaderText = "F.PROCES";
            dgvPlanillas.Columns["FECHA_PROCESO"].Width = 70;
            dgvPlanillas.Columns["T_TRANS_RECEP"].HeaderText = "T.TRANS";
            dgvPlanillas.Columns["T_TRANS_RECEP"].Width = 70;
            dgvPlanillas.Columns["FECHA_LISTA"].HeaderText = "F.LISTA";
            dgvPlanillas.Columns["FECHA_LISTA"].Width = 70;
            dgvPlanillas.Columns["T_TRANS_LISTA"].HeaderText = "T.TRANS";
            dgvPlanillas.Columns["T_TRANS_LISTA"].Width = 70;
            dgvPlanillas.Columns["FECHA_DEV_SEGUI"].HeaderText = "F.DEV.PLLA";
            dgvPlanillas.Columns["FECHA_DEV_SEGUI"].Width = 70;
            dgvPlanillas.Columns["T_TRANS_EJE"].HeaderText = "T.TRANS";
            dgvPlanillas.Columns["T_TRANS_EJE"].Width = 70;
            dgvPlanillas.Columns["IMP_RECEPCION_CTA_CTE"].HeaderText = "IMP.EJEC";
            dgvPlanillas.Columns["IMP_RECEPCION_CTA_CTE"].Width = 70;
            dgvPlanillas.Columns["IMP_RECEPCION_CTA_CTE"].DefaultCellStyle.Format = "N3";
            dgvPlanillas.Columns["FECHA_EJE"].HeaderText = "F.EJEC";
            dgvPlanillas.Columns["FECHA_EJE"].Width = 70;
            dgvPlanillas.Columns["T_TRANS_RECEP"].HeaderText = "T.TRANS";
            dgvPlanillas.Columns["T_TRANS_RECEP"].Width = 70;
            dgvPlanillas.Columns["SI/NO"].Width = 50;

            dgvPlanillas.Columns["IMPORTE_DESCUENTO"].Visible = false;
            dgvPlanillas.Columns["PORCENTAJE_CASILLERO"].Visible = false;

            dgvPlanillas.Columns["IMP_ENVIO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPlanillas.Columns["IMPORTE_LISTADO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPlanillas.Columns["IMPORTE_CASILLERO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPlanillas.Columns["OTROS_DSCTOS"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPlanillas.Columns["IMPORTE_NETO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPlanillas.Columns["IMP_RECEPCION_CTA_CTE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvPlanillas.Columns["NRO_PLANILLA_COB"].Frozen = true;

            StyleHeaderTextDataGridView();
        }

        private void StyleHeaderTextDataGridView()
        {
            foreach (DataGridViewColumn column in dgvPlanillas.Columns)
            {
                if (column.Index <= 6)
                {
                    column.HeaderCell.Style.BackColor = colorBack[0];
                    column.DefaultCellStyle.BackColor = Color.PowderBlue;
                }
                else if (column.Index <= 10)
                {
                    column.HeaderCell.Style.BackColor = colorBack[1];
                    column.DefaultCellStyle.BackColor = Color.White;
                }
                else if (column.Index <= 14)
                {
                    column.HeaderCell.Style.BackColor = colorBack[2];
                    column.DefaultCellStyle.BackColor = Color.PowderBlue;
                }
                else if (column.Index <= 18)
                {
                    column.HeaderCell.Style.BackColor = colorBack[3];
                    column.DefaultCellStyle.BackColor = Color.White;
                }
                else if (column.Index <= 21)
                {
                    column.HeaderCell.Style.BackColor = colorBack[4];
                    column.DefaultCellStyle.BackColor = Color.PowderBlue;
                }
                else
                {
                    column.HeaderCell.Style.BackColor = colorBack[5];
                    column.DefaultCellStyle.BackColor = Color.White;
                }
            }
        }

        private void CboMes_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ListarPlanillas();
            MostrarDatosAdicionales();
        }

        private void NumAño_ValueChanged(object sender, EventArgs e)
        {
            ListarPlanillas();
            MostrarDatosAdicionales();
        }

        private void BackColorLeyeda()
        {
            lblEtap1.BackColor = colorBack[0];
            lblEtapa2.BackColor = colorBack[1];
            lblEtapa3.BackColor = colorBack[2];
            lblEtapa4.BackColor = colorBack[3];
            lblEtapa5.BackColor = colorBack[4];
            lblPlanillasEjecutadas.BackColor = colorBack[5];

            lblPlanilla.BackColor = colorBack[0];
            lblTotImpPlanilla.BackColor = colorBack[0];
            lblTotListado.BackColor = colorBack[4];
            lblTotImpCas.BackColor = colorBack[5];
            lblTotOtrosDsct.BackColor = colorBack[5];
            lblTotImpNeto.BackColor = colorBack[5];
        }

        private void BtnTransferir_Click(object sender, EventArgs e)
        {
            string año = numAño.Value.ToString();
            string mes = cboMes.SelectedValue.ToString();
            if (BLSeguimientoPla.ListarPlanillasXPtoCobranza(año, mes).Rows.Count == 0)
            {
                _ = MessageBox.Show("No hay planillas para transferir", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int planillaTran = 0;
            foreach (DataGridViewRow row in dgvPlanillas.Rows)
            {
                planillaTran += !string.IsNullOrEmpty(row.Cells["FE_TRANSFERENCIA"].Value.ToString()) ? 0 : 1;
            }

            DialogResult dr = MessageBox.Show("¿Esta seguro de transferir de planillas a seguimiento? \n" +
                "Total planillas a transfereir : " + planillaTran.ToString(), "MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    const string status = "PT";
                    int result = BLSeguimientoPla.TransferirPlanillas(status, año, mes);
                    _ = MessageBox.Show("Total Planillas Transferidas : " + result.ToString(), "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListarPlanillas();
                    MostrarDatosAdicionales();
                }
                catch (Exception ex)
                {
                    _ = MessageBox.Show(ex.Message, "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DgvPlanillas_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void MostrarDatosAdicionales()
        {
            decimal totalEnvio = 0;
            decimal totalListado = 0;
            decimal totalCasillero = 0;
            decimal totalOtrosDesctos = 0;
            decimal totalNeto = 0;
            foreach (DataGridViewRow row in dgvPlanillas.Rows)
            {
                totalEnvio += string.IsNullOrEmpty(row.Cells["IMP_ENVIO"].Value?.ToString()) ? 0 : Convert.ToDecimal(row.Cells["IMP_ENVIO"].Value, culture);
                totalListado += string.IsNullOrEmpty(row.Cells["IMPORTE_LISTADO"].Value?.ToString()) ? 0 : Convert.ToDecimal(row.Cells["IMPORTE_LISTADO"].Value, culture);
                totalCasillero += string.IsNullOrEmpty(row.Cells["IMPORTE_CASILLERO"].Value?.ToString()) ? 0 : Convert.ToDecimal(row.Cells["IMPORTE_CASILLERO"].Value, culture);
                totalOtrosDesctos += string.IsNullOrEmpty(row.Cells["OTROS_DSCTOS"].Value?.ToString()) ? 0 : Convert.ToDecimal(row.Cells["OTROS_DSCTOS"].Value, culture);
                totalNeto += string.IsNullOrEmpty(row.Cells["IMPORTE_NETO"].Value?.ToString()) ? 0 : Convert.ToDecimal(row.Cells["IMPORTE_NETO"].Value, culture);
            }
            lblTotImpPlanilla.Text = "Imp.Plan: " + totalEnvio.ToString("N2");
            lblTotListado.Text = "Imp.List : " + totalListado.ToString("N2");
            lblTotImpCas.Text = "Imp.Casi : " + totalCasillero.ToString("N2");
            lblTotOtrosDsct.Text = "O.Dctos : " + totalOtrosDesctos.ToString("N2");
            lblTotImpNeto.Text = "Imp.Neto : " + totalNeto.ToString("N2");
            lblPlanilla.Text = "Planillas : " + dgvPlanillas.Rows.Count.ToString();
        }

        private void ColorPanelLeyenda()
        {
            panel3.BackColor = colorBack[0];
            panel4.BackColor = colorBack[1];
            panel5.BackColor = colorBack[2];
            panel6.BackColor = colorBack[3];
            panel7.BackColor = colorBack[4];
            panel8.BackColor = colorBack[5];
        }
    }
}
