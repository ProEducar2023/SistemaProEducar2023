using System.Windows.Forms;

namespace Presentacion.MOD_COMISIONES
{
    public partial class ATENCION_CLIENTES_INGRESO : Form
    {
        public ATENCION_CLIENTES_INGRESO()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MOD_COMISIONES.ATENCION_CLIENTE_ANULAR frm = new ATENCION_CLIENTE_ANULAR();
            frm.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MOD_COMISIONES.ATENCION_CLIENTES_KARDEX frm = new ATENCION_CLIENTES_KARDEX();
            frm.Show();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MOD_COMISIONES.ATENCIONS_CLIENTE_REFERENCIA frm = new ATENCIONS_CLIENTE_REFERENCIA();
            frm.Show();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MOD_COMISIONES.ATENCION_CLIENTE_BENEFICIARIO frm = new ATENCION_CLIENTE_BENEFICIARIO();
            frm.Show();
        }

        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtnro.Text = "0024856";
                txtcodcli.Text = "05465";
                txtnomcli.Text = "JOSE DE LA RIVA AGUERO Y SANCHEZ BOQUETE";
                txtdni.Text = "99640984";
                txtmoda.Text = "PLANILLA";
                dtpferesp.Focus();
            }
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MOD_COMISIONES.ATENCION_CLIENTE_SUSPENDER frm = new ATENCION_CLIENTE_SUSPENDER();
            frm.Show();
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MOD_COMISIONES.ATENCION_CLIENTE_MODALIDAD frm = new ATENCION_CLIENTE_MODALIDAD();
            frm.Show();
        }
    }
}
