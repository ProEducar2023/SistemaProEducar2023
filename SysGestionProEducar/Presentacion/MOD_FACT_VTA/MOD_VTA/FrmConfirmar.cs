using BLL;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using static Presentacion.HELPERS.ErrorPrint;
using Entidades;


namespace Presentacion.MOD_FACT_VTA.MOD_VTA
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
                case TIPO_CONFIRMAR.RETORNAR_ETAPA_PROCESO: RetornarEtapaProceso(sender, e); break;
            }
        }

        private void RetornarEtapaProceso(object sender, EventArgs e)
        {
            const string contraseña = "er2758";
            const string contraseña2 = "pa1936";
            if (contraseña.Equals(txtContraseña.Text) || contraseña2.Equals(txtContraseña.Text))
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
    }
}
