using System;
using System.Windows.Forms;

namespace Presentacion.MOD_FACT_VTA.MOD_VTA
{
    public partial class BackEstadoSeguimiento : Form
    {

        public BackEstadoSeguimiento()
        {
            InitializeComponent();
        }

        public new delegate void Click();
        public event Click EveClick;

        private void BtnConfirmar_Click(object sender, EventArgs e)
        {
            if (txtContraseña.Text == "1234567")
            {
                EveClick();
                Close();
            }
            else
            {
                _ = MessageBox.Show("La contraseña ingresada es incorrecta. \n Intentelo nuevamente", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContraseña.Clear();
                _ = txtContraseña.Focus();
            }
        }
    }
}
