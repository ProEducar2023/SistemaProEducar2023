using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static Presentacion.HELPERS.ErrorPrint;
using static Presentacion.HELPERS.AppearanceUtil;

namespace Presentacion.MOD_COMISIONES
{
    public partial class FrmEliminarComision : Form
    {
        private readonly List<ComisionTo> lstComisionTo;

        public FrmEliminarComision(List<ComisionTo> lstComisionTo)
        {
            InitializeComponent();
            this.lstComisionTo = lstComisionTo;
        }

        private readonly comisionesBLL BLComisiones = new comisionesBLL();

        private void FrmEliminarComision_Load(object sender, EventArgs e)
        {
            StartControls();
        }

        private void StartControls()
        {
            btnEliminar.StyleButtonFlat();
            txtNroCuota.MaxLength = 3;
        }

        private void TxtNroCuota_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FormatTxtNroCuota();
            }
        }

        private void TxtNroCuota_Leave(object sender, EventArgs e)
        {
            FormatTxtNroCuota();
        }

        private void FormatTxtNroCuota()
        {
            try
            {
                int num = Convert.ToInt32(txtNroCuota.Text.Replace("0", ""));
                if (!string.IsNullOrEmpty(txtNroCuota.Text))
                {
                    if (num <= 18)
                    {
                        txtNroCuota.Text = num.ToString().PadLeft(3, Convert.ToChar("0"));
                    }
                    else
                    {
                        _ = MessageBox.Show("El numero máximo de cuotas es 18", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtNroCuota.Text = "000";
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex is FormatException)
                    txtNroCuota.Text = "000";
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Esta seguro de eliminar?", "MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    int result = BLComisiones.EliminarComisionXNroCuota(lstComisionTo, txtNroCuota.Text);
                    _ = MessageBox.Show("Total registros eliminados: " + result.ToString(), "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                ex.PrintException2();
            }
        }
    }
}
