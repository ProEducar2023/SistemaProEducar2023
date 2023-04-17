using System;
using System.Globalization;
using System.Windows.Forms;
using BLL;
using Entidades;

namespace Presentacion.MOD_FACT_VTA.MOD_VTA
{
    public partial class TransferenciaDescontados : Form
    {
        public TransferenciaDescontados()
        {
            InitializeComponent();
        }

        private readonly SeguimientoPlanillasBLL BLSeguimientoPla = new SeguimientoPlanillasBLL();

        private static readonly CultureInfo culture = CultureInfo.CreateSpecificCulture("en-CA");

        private void TransferenciaDescontados_Load(object sender, EventArgs e)
        {
            StartControls();
            ListarPuntosCobranza();
        }

        private void StartControls()
        {
            dgvPlanillasDesc.MultiSelect = false;
            dgvPlanillasDesc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void ListarPuntosCobranza()
        {
            dgvPlanillasDesc.DataSource = BLSeguimientoPla.ListarPlanilasSiDescontadas();
            dgvPlanillasDesc.Columns["COD_PTO_COB"].HeaderText = "CODIGO";
            dgvPlanillasDesc.Columns["COD_PTO_COB"].Width = 80;
            dgvPlanillasDesc.Columns["DESC_PTO_COB"].HeaderText = "PUNTO COBRANZA";
            dgvPlanillasDesc.Columns["DESC_PTO_COB"].Width = 250;
            dgvPlanillasDesc.Columns["CANTIDAD"].HeaderText = "CANT.PLANILLA";
            dgvPlanillasDesc.Columns["CANTIDAD"].Width = 100;
            dgvPlanillasDesc.Columns["NRO_PLANILLA_COB"].HeaderText = "NRO.PLANILLA";
            dgvPlanillasDesc.Columns["NRO_PLANILLA_COB"].Width = 100;
            dgvPlanillasDesc.Columns["IMPORTE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            if (dgvPlanillasDesc.Rows.Count > 0)
            {
                MostrarDatosAdicionales();
            }
            else
                _ = MessageBox.Show("No hay planillas para transferir", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MostrarDatosAdicionales()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dgvPlanillasDesc.Rows)
            {
                total += string.IsNullOrEmpty(row.Cells["IMPORTE"].Value?.ToString()) ? 0 : Convert.ToDecimal(row.Cells["IMPORTE"].Value, culture);
            }
            //> lblTotalImporte.Text = "Total Importe : " + total.ToString("0,00.00");
            //> lblCantPlanilla.Text = "Total Cantidad : " + dgvPlanillasDesc.Rows.Count.ToString();
        }
    }
}
