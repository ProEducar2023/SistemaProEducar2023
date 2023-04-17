using System;
using System.Windows.Forms;
using Entidades;
using BLL;

namespace Presentacion.MOD_FACT_VTA.MOD_VTA
{
    public partial class CerrarEtapaDescuento : Form
    {
        private readonly SeguimientoPlanillaTo se;
        public CerrarEtapaDescuento(SeguimientoPlanillaTo se)
        {
            InitializeComponent();
            this.se = se;
        }

        private readonly SeguimientoPlanillasBLL BLSeguimiento = new SeguimientoPlanillasBLL();

        private void CerrarEtapaDescuento_Load(object sender, EventArgs e)
        {
            StartControls();
        }

        private void StartControls()
        {
            lblNroPlanilla.Text += se.NRO_PLANILLA;
            lblEstado.Text += "DESCUENTO";
            numImporte.DecimalPlaces = 2;
            numImporte.Maximum = decimal.MaxValue;
            numImporte.ThousandsSeparator = true;
            numImporte.Value = se.IMPORTE_DESCUENTO;
        }

        private void BtnRegistrarLlamada_Click(object sender, EventArgs e)
        {
            Grabar();
        }

        private void NumImporte_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Grabar();
            }
        }

        private void Grabar()
        {
            try
            {
                if (numImporte.Value == 0)
                {
                    _ = MessageBox.Show("Digite el importe descontado", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DialogResult dr = MessageBox.Show("¿Esta seguro de cerrar la etapa de descuento?", "MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dr == DialogResult.Yes)
                {
                    se.IMPORTE_DESCUENTO = numImporte.Value;
                    _ = BLSeguimiento.CerrarEtapaDecuento(se)
                        ? MessageBox.Show("La etapa de descuento se a cerrado correctamente", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        : MessageBox.Show("Ocurrió un error al cerrar la etapa de descuento", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show(ex.Message, "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
