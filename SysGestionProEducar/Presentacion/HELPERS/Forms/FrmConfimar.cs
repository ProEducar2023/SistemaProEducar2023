using BLL;
using Entidades;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Presentacion.HELPERS.Forms
{
    public partial class FrmConfirmar : Form
    {
        private readonly TIPO_CONFIRMAR access;
        public FrmConfirmar(TIPO_CONFIRMAR access)
        {
            InitializeComponent();
            this.access = access;
        }

        private readonly usuariosBLL usuBLL = new usuariosBLL();

        internal new delegate void Click(object sender, EventArgs e);
        internal event Click EventClick;

        private void BtnConfirmar_Click(object sender, EventArgs e)
        {
            switch (access)
            {
                case TIPO_CONFIRMAR.OTROS: Validar1(sender, e); break;
            }
        }

        private void Validar1(object sender, EventArgs e)
        {
            bool esValido = ValidarCredenciales();
            if (esValido)
            {
                EventClick(sender, e);
                Close();
            }
            else
            {
                _ = MessageBox.Show("La contraseña ingresada es incorrecta.", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContraseña.Clear();
                _ = txtContraseña.Focus();
            }
        }

        private bool ValidarCredenciales()
        {
            const string usuario = "MARTA";
            string clave = HelpersBLL.Encriptar(txtContraseña.Text.ToUpper());
            bool esValido = false;
            try
            {
                DataTable dtUsuario = usuBLL.obtenerTodosUsuariosBLL();
                if (dtUsuario != null && dtUsuario.Rows.Count > 0)
                {
                    DataRow row = dtUsuario.Select("Nick = '" + usuario + "'").First();
                    esValido = row != null && row["Clave"].ToString() == clave;
                }
            }
            catch (Exception ex)
            {
                ex.PrintException();
            }
            return esValido;
        }
    }
}
