using System;
using System.Windows.Forms;

namespace Presentacion.MOD_FACT_VTA
{
    public partial class FrmEnviarCorreos : Form
    {
        public string correo1;

        public bool Ok;
        public FrmEnviarCorreos(string correos)
        {
            InitializeComponent();
            txtCorreo1.Text = correos;

        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            correo1 = txtCorreo1.Text;


            if (string.IsNullOrEmpty(correo1))
            {
                MessageBox.Show("Debe ingresar al menos un correo", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Ok = true;
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Ok = false;
            Close();
        }
    }
}
