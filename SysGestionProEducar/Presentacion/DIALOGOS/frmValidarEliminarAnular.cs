using BLL;
using System;
using System.Data;
using System.Windows.Forms;
namespace Presentacion.DIALOGOS
{
    public partial class frmValidarEliminarAnular : Form
    {
        public frmValidarEliminarAnular()
        {
            InitializeComponent();
        }

        private void frmValidarEliminarAnular_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtObservacion.Text.Trim() == "" && txtObservacion.Visible == true && cboUsuario.SelectedIndex == -1)
                MessageBox.Show("DEBE COMPLETAR LOS DATOS !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
                DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void frmValidarEliminarAnular_Load(object sender, EventArgs e)
        {
            txtContraseña.Text = "";
            txtObservacion.Text = "";
            cboUsuario.SelectedIndex = -1;
            Label3.Focus();
            KeyPreview = true;
        }
        public void cargar_usuario(string COD_MOD)
        {
            string TABLA_COD = "TA_E";//Tabla Anular Eliminar
            personaBLL perBLL = new personaBLL();
            DataTable dt = perBLL.obtenerUsuariosparaDesaprobarBLL(TABLA_COD, COD_MOD);
            cboUsuario.ValueMember = "CODIGO";
            cboUsuario.DisplayMember = "DESCRIPCION";
            cboUsuario.DataSource = dt;
        }
    }
}
