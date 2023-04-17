using BLL;
using System;
using System.Data;
using System.Windows.Forms;
namespace Presentacion.DIALOGOS
{
    public partial class PRE_DESAPROBADO_POR : Form
    {
        string PWD;
        public PRE_DESAPROBADO_POR()
        {
            InitializeComponent();
        }

        private void PRE_DESAPROBADO_POR_Load(object sender, EventArgs e)
        {
            txtContraseña.Text = "";
            cboUsuario.SelectedIndex = -1;
            Label3.Focus();
            //'CARGAR_PERSONAL()
            KeyPreview = true;
        }
        public void cargar_usuario(string COD_MOD)
        {
            //string TABLA_COD = "TA_D";
            personaBLL perBLL = new personaBLL();
            DataTable dt = perBLL.obtenerUsuariosparaDesaprobarVentasBLL();
            cboUsuario.ValueMember = "CODIGO";
            cboUsuario.DisplayMember = "DESCRIPCION";
            PWD = dt.Rows[0]["OBSERVACION"].ToString();
            cboUsuario.DataSource = dt;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!validaAceptar())
                return;
            DialogResult = DialogResult.OK;
        }
        private bool validaAceptar()
        {
            bool result = true;
            if (cboUsuario.SelectedIndex == -1 || txtContraseña.Text == "")
            {
                MessageBox.Show("Debe completar los datos !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return result = false;
            }
            if (PWD != txtContraseña.Text.Trim())
            {
                MessageBox.Show("Contraseña incorrecta !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtContraseña.Focus();
                return result = false;
            }
            return result;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
