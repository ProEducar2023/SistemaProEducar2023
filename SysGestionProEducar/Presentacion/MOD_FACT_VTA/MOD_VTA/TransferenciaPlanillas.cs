using BLL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Presentacion.MOD_FACT_VTA.MOD_VTA
{
    public partial class TransferenciaPlanillas : Form
    {
        private static string AÑO, MES;
        public TransferenciaPlanillas(string año, string mes)
        {
            InitializeComponent();
            AÑO = año;
            MES = mes;
        }

        private readonly puntoCobranzaBLL BLPuntoCobranza = new puntoCobranzaBLL();
        private readonly SeguimientoPlanillasBLL BLSeguimientoPla = new SeguimientoPlanillasBLL();

        private static readonly CultureInfo culture = CultureInfo.CreateSpecificCulture("en-CA");

        private void TransferenciaPlanillas_Load(object sender, EventArgs e)
        {
            StartControls();
            ColorPanelLeyenda();
            CargarMes();
            ListarPuntosCobranza();
        }

        private void StartControls()
        {
            dgvPuntoCobranza.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPlanillasDesc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPlanillasDesc.DefaultCellStyle.SelectionBackColor = Color.White;
            dgvPlanillasDesc.DefaultCellStyle.SelectionForeColor = Color.Blue;

            label2.Text = "Perído " + MES + " - " + AÑO;

            numAño.DecimalPlaces = 0;
            numAño.Maximum = decimal.MaxValue;

            cboMes.DropDownStyle = ComboBoxStyle.DropDownList;

            rdbTodos.Checked = true;
            lblTotalListado.BackColor = Color.MediumSpringGreen;
            lblTotalCasillero.BackColor = Color.MediumSpringGreen;
            lblTotalOtrosDesctos.BackColor = Color.MediumSpringGreen;
            lblTotalNeto.BackColor = Color.MediumSpringGreen;
            lblTotalEjecutado.BackColor = Color.Tan;
            lblTotalPagado.BackColor = Color.Lavender;
            lblTotalSaldo.BackColor = Color.Lavender;
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

        private void ListarPuntosCobranza()
        {
            dgvPuntoCobranza.DataSource = BLPuntoCobranza.ObtenerPtoCobranzaCantPlanillaBLL(AÑO, MES);
            dgvPuntoCobranza.Columns["COD_PTO_COB"].HeaderText = "CODIGO";
            dgvPuntoCobranza.Columns["COD_PTO_COB"].Width = 80;
            dgvPuntoCobranza.Columns["DESC_PTO_COB"].HeaderText = "PUNTO COBRANZA";
            dgvPuntoCobranza.Columns["DESC_PTO_COB"].Width = 250;
            dgvPuntoCobranza.Columns["CANTIDAD"].HeaderText = "CANT.PLANILLA";
            dgvPuntoCobranza.Columns["CANTIDAD"].Width = 100;
            dgvPuntoCobranza.Columns["NRO_PLANILLA_COB"].HeaderText = "NRO.PLANILLA";
            dgvPuntoCobranza.Columns["NRO_PLANILLA_COB"].Width = 100;
            dgvPuntoCobranza.Columns["IMPORTE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            if (dgvPuntoCobranza.Rows.Count > 0)
            {
                MostrarDatosAdicionales();
            }
            else
                _ = MessageBox.Show("No hay planillas para transferir", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ListarPlanillasSiDescontadas(int acces)
        {
            dgvPlanillasDesc.DataSource = BLSeguimientoPla.ListarPlanillaControl(numAño.Value.ToString(), cboMes.SelectedValue.ToString(), acces);
            dgvPlanillasDesc.Columns["COD_PTO_COB"].HeaderText = "COD";
            dgvPlanillasDesc.Columns["COD_PTO_COB"].Width = 40;
            dgvPlanillasDesc.Columns["DESC_PTO_COB"].HeaderText = "P. COBRANZA";
            dgvPlanillasDesc.Columns["DESC_PTO_COB"].Width = 120;
            dgvPlanillasDesc.Columns["NRO_PLANILLA_COB"].HeaderText = "NRO.PLANILLA";
            dgvPlanillasDesc.Columns["NRO_PLANILLA_COB"].Width = 90;
            dgvPlanillasDesc.Columns["PERIODO"].HeaderText = "PERÍODO";
            dgvPlanillasDesc.Columns["PERIODO"].Width = 60;
            dgvPlanillasDesc.Columns["IMP_ENVIO"].HeaderText = "IMP.PLAN";
            dgvPlanillasDesc.Columns["IMP_ENVIO"].Width = 70;
            dgvPlanillasDesc.Columns["FE_TRANSFERENCIA"].HeaderText = "F.INI.SEGUI";
            dgvPlanillasDesc.Columns["FE_TRANSFERENCIA"].Width = 70;
            dgvPlanillasDesc.Columns["FECHA_FIN_SEGUI"].HeaderText = "F.ENT.LIST";
            dgvPlanillasDesc.Columns["FECHA_FIN_SEGUI"].Width = 70;
            dgvPlanillasDesc.Columns["IMPORTE_DESCUENTO"].HeaderText = "IMP.DSCTO";
            dgvPlanillasDesc.Columns["IMPORTE_DESCUENTO"].Width = 70;
            dgvPlanillasDesc.Columns["IMPORTE_LISTADO"].HeaderText = "IMP.LIST";
            dgvPlanillasDesc.Columns["IMPORTE_LISTADO"].Width = 70;
            dgvPlanillasDesc.Columns["PORCENTAJE_CASILLERO"].HeaderText = "%.CASI.";
            dgvPlanillasDesc.Columns["PORCENTAJE_CASILLERO"].Width = 50;
            dgvPlanillasDesc.Columns["IMPORTE_CASILLERO"].HeaderText = "IMP.CASI.";
            dgvPlanillasDesc.Columns["IMPORTE_CASILLERO"].Width = 70;
            dgvPlanillasDesc.Columns["OTROS_DSCTOS"].HeaderText = "O.DCTOS";
            dgvPlanillasDesc.Columns["OTROS_DSCTOS"].Width = 70;
            dgvPlanillasDesc.Columns["IMPORTE_NETO"].HeaderText = "IMP.NETO";
            dgvPlanillasDesc.Columns["IMPORTE_NETO"].Width = 70;
            dgvPlanillasDesc.Columns["FECHA_EJECUCION"].HeaderText = "F.EJECU";
            dgvPlanillasDesc.Columns["FECHA_EJECUCION"].Width = 70;
            dgvPlanillasDesc.Columns["IMP_RECEPCION_CTA_CTE"].HeaderText = "IMP.EJECU";
            dgvPlanillasDesc.Columns["IMP_RECEPCION_CTA_CTE"].Width = 70;
            dgvPlanillasDesc.Columns["DIFERENCIA"].HeaderText = "DIFEREN.";
            dgvPlanillasDesc.Columns["DIFERENCIA"].Width = 70;
            dgvPlanillasDesc.Columns["T.TRANSCURRIDO"].HeaderText = "T.TRANS";
            dgvPlanillasDesc.Columns["T.TRANSCURRIDO"].Width = 70;
            dgvPlanillasDesc.Columns["FECHA_PAGO"].HeaderText = "ULT.F.PAGO";
            dgvPlanillasDesc.Columns["FECHA_PAGO"].Width = 72;
            dgvPlanillasDesc.Columns["IMP_ACUMULADO"].HeaderText = "IMP.ACUM";
            dgvPlanillasDesc.Columns["IMP_ACUMULADO"].DefaultCellStyle.Format = "N3";
            dgvPlanillasDesc.Columns["IMP_ACUMULADO"].Width = 70;
            dgvPlanillasDesc.Columns["SALDO"].Width = 70;
            dgvPlanillasDesc.Columns["SALDO"].DefaultCellStyle.Format = "N3";

            dgvPlanillasDesc.Columns["IMPORTE_DESCUENTO"].Visible = false;
            dgvPlanillasDesc.Columns["DIFERENCIA"].Visible = false;

            dgvPlanillasDesc.Columns["IMP_ENVIO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPlanillasDesc.Columns["IMPORTE_DESCUENTO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPlanillasDesc.Columns["IMPORTE_LISTADO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPlanillasDesc.Columns["IMPORTE_CASILLERO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPlanillasDesc.Columns["OTROS_DSCTOS"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPlanillasDesc.Columns["IMPORTE_NETO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPlanillasDesc.Columns["IMP_RECEPCION_CTA_CTE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPlanillasDesc.Columns["DIFERENCIA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPlanillasDesc.Columns["IMP_ACUMULADO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPlanillasDesc.Columns["SALDO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            StyleHeaderTextDataGridView();
        }

        private void BtnTransferir2_Click(object sender, EventArgs e)
        {
            if (BLSeguimientoPla.ListarPlanillasXPtoCobranza(AÑO, MES).Rows.Count == 0)
            {
                _ = MessageBox.Show("No hay planillas para transferir", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            foreach (DataGridViewRow row in dgvPuntoCobranza.Rows)
            {
                if (Convert.ToInt32(row.Cells["CANTIDAD"].Value) > 1)
                {
                    _ = MessageBox.Show("El punto de cobranza " + row.Cells["DESC_PTO_COB"].Value.ToString() + " tiene mas de 1 planilla", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                }
            }

            DialogResult dr = MessageBox.Show("¿Esta seguro de transferir todas las planillas?", "MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    const string status = "PT";
                    int result = BLSeguimientoPla.TransferirPlanillas(status, AÑO, MES);
                    _ = MessageBox.Show("Total Planillas Transferidas : " + result.ToString(), "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListarPuntosCobranza();
                    MostrarDatosAdicionales();
                }
                catch (Exception ex)
                {
                    _ = MessageBox.Show(ex.Message, "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void MostrarDatosAdicionales()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dgvPuntoCobranza.Rows)
            {
                total += string.IsNullOrEmpty(row.Cells["IMPORTE"].Value?.ToString()) ? 0 : Convert.ToDecimal(row.Cells["IMPORTE"].Value, culture);
            }
            lblTotalImporte.Text = "Total Importe : " + total.ToString("0,00.00");
            lblCantPlanilla.Text = "Total Cantidad : " + dgvPuntoCobranza.Rows.Count.ToString();
        }

        private void MostrarDatosAdicionales2()
        {
            decimal totalDscto = 0;
            decimal totalListado = 0;
            decimal totalCasillero = 0;
            decimal totalOtrosDesctos = 0;
            decimal totalNeto = 0;
            decimal totalEjecutado = 0;
            decimal totalPagado = 0;
            decimal totalSaldo = 0;
            foreach (DataGridViewRow row in dgvPlanillasDesc.Rows)
            {
                totalDscto += string.IsNullOrEmpty(row.Cells["IMPORTE_DESCUENTO"].Value?.ToString()) ? 0 : Convert.ToDecimal(row.Cells["IMPORTE_DESCUENTO"].Value, culture);
                totalListado += string.IsNullOrEmpty(row.Cells["IMPORTE_LISTADO"].Value?.ToString()) ? 0 : Convert.ToDecimal(row.Cells["IMPORTE_LISTADO"].Value, culture);
                totalCasillero += string.IsNullOrEmpty(row.Cells["IMPORTE_CASILLERO"].Value?.ToString()) ? 0 : Convert.ToDecimal(row.Cells["IMPORTE_CASILLERO"].Value, culture);
                totalOtrosDesctos += string.IsNullOrEmpty(row.Cells["OTROS_DSCTOS"].Value?.ToString()) ? 0 : Convert.ToDecimal(row.Cells["OTROS_DSCTOS"].Value, culture);
                totalNeto += string.IsNullOrEmpty(row.Cells["IMPORTE_NETO"].Value?.ToString()) ? 0 : Convert.ToDecimal(row.Cells["IMPORTE_NETO"].Value, culture);
                totalEjecutado += string.IsNullOrEmpty(row.Cells["IMP_RECEPCION_CTA_CTE"].Value?.ToString()) ? 0 : Convert.ToDecimal(row.Cells["IMP_RECEPCION_CTA_CTE"].Value, culture);
                totalPagado += string.IsNullOrEmpty(row.Cells["IMP_ACUMULADO"].Value?.ToString()) ? 0 : Convert.ToDecimal(row.Cells["IMP_ACUMULADO"].Value, culture);
                totalSaldo += string.IsNullOrEmpty(row.Cells["SALDO"].Value?.ToString()) ? 0 : Convert.ToDecimal(row.Cells["SALDO"].Value, culture);
            }
            lblTotalDscto.Text = "Total Dscto: " + totalDscto.ToString("0,00.00");
            lblTotalListado.Text = "Total Listado : " + totalListado.ToString("0,00.00");
            lblTotalCasillero.Text = "Total Casillero : " + totalCasillero.ToString("0,00.00");
            lblTotalOtrosDesctos.Text = "Otros Dsctos : " + totalOtrosDesctos.ToString("0,00.00");
            lblTotalNeto.Text = "Total Neto : " + totalNeto.ToString("0,00.00");
            lblTotalEjecutado.Text = "Total Ejecutado : " + totalEjecutado.ToString("0,00.00");
            lblTotalPagado.Text = "Total Pagado : " + totalPagado.ToString("0,00.00");
            lblTotalSaldo.Text = "Total Saldo : " + totalSaldo.ToString("0,00.00");
            lblCantPlanilla2.Text = "Planillas : " + dgvPlanillasDesc.Rows.Count.ToString();
        }

        private void TxtCodigoPC_TextChanged(object sender, EventArgs e)
        {
            const string nameColumn = "COD_PTO_COB";
            TextChangedPC(nameColumn, txtCodigoPC.Text);
        }

        private void TxtDescPC_KeyDown(object sender, KeyEventArgs e)
        {
            const string nameColumn = "DESC_PTO_COB";
            if (e.KeyCode == Keys.Enter)
            {
                TextChangedPC(nameColumn, txtDescPC.Text);
            }
        }

        private void BtnTransferir3_Click(object sender, EventArgs e)
        {
            if (BLSeguimientoPla.ListarPlanilasSiDescontadas().Rows.Count == 0)
            {
                _ = MessageBox.Show("No hay planillas para transferir", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult dr = MessageBox.Show("¿Esta seguro de transferir todas las planillas?", "MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    int result = BLSeguimientoPla.TransferirPlanillasSiDescontadas();
                    _ = MessageBox.Show("Total Planillas Transferidas : " + result.ToString(), "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListarPlanillasSiDescontadas(ObtenerTagRadioButtonChecked());
                    MostrarDatosAdicionales2();
                }
                catch (Exception ex)
                {
                    _ = MessageBox.Show(ex.Message + "\n" + ex.StackTrace, "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                if (dgvPlanillasDesc.Rows.Count > 0)
                {
                    MostrarDatosAdicionales2();
                }
                else
                    _ = MessageBox.Show("No hay planillas para transferir", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CboMes_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ListarPlanillasSiDescontadas(ObtenerTagRadioButtonChecked());
            MostrarDatosAdicionales2();
        }

        private void NumAño_ValueChanged(object sender, EventArgs e)
        {
            ListarPlanillasSiDescontadas(ObtenerTagRadioButtonChecked());
            MostrarDatosAdicionales2();
        }

        private void ChkTodos_Click(object sender, EventArgs e)
        {
            RadioButton rad = sender as RadioButton;
            ListarPlanillasSiDescontadas(Convert.ToInt32(rad.Tag));
            MostrarDatosAdicionales2();
        }

        private int ObtenerTagRadioButtonChecked()
        {
            foreach (RadioButton rad in pnlRadioGroup.Controls.Cast<RadioButton>().ToList())
            {
                if (rad.Checked)
                    return Convert.ToInt32(rad.Tag);
            }
            return 0;
        }

        private void TextChangedPC(string nameColumn, string text)
        {
            IEnumerable<DataGridViewRow> row = dgvPuntoCobranza.Rows.Cast<DataGridViewRow>()
                .Where(x => x.Cells[nameColumn].Value.ToString().Contains(text));
            if (row.Any())
                dgvPuntoCobranza.CurrentCell = dgvPuntoCobranza[0, row.Select(f => f.Index).FirstOrDefault()];
        }

        private void StyleHeaderTextDataGridView()
        {
            foreach (DataGridViewColumn column in dgvPlanillasDesc.Columns)
            {
                if (column.Index <= 5)
                    column.HeaderCell.Style.BackColor = Color.PaleTurquoise;
                else if (column.Index <= 12)
                    column.HeaderCell.Style.BackColor = Color.MediumSpringGreen;
                else if (column.Index <= 16)
                    column.HeaderCell.Style.BackColor = Color.Tan;
                else
                    column.HeaderCell.Style.BackColor = Color.Lavender;
            }
            dgvPlanillasDesc.EnableHeadersVisualStyles = false;
        }

        private void ColorPanelLeyenda()
        {
            panel3.BackColor = Color.PaleTurquoise;
            panel4.BackColor = Color.MediumSpringGreen;
            panel5.BackColor = Color.Tan;
            panel6.BackColor = Color.Lavender;
        }
    }
}
