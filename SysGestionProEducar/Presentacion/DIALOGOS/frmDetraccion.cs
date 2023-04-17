using BLL;
using Entidades;
using System;
using System.Windows.Forms;

namespace Presentacion.DIALOGOS
{
    public partial class frmDetraccion : Form
    {
        public decimal Importe;
        public bool Cero;
        directorioBLL dirBLL = new directorioBLL();
        directorioTo dirTo = new directorioTo();
        public frmDetraccion()
        {
            InitializeComponent();
        }

        private void frmDetraccion_Load(object sender, EventArgs e)
        {
            if (Cero == false)
            {
                dirTo.TABLA_COD = "TDEFA";
                dirTo.CODIGO = "POR_D";
                txtPorDetraccion.Text = dirBLL.DIR_TABLA_DESC(dirTo);
                txtValorDetraccion.Text = (Importe * Convert.ToDecimal(txtPorDetraccion.Text) / 100).ToString();
            }
            txtValorDetraccion.Focus();
        }
        public void Limpiar()
        {
            txtPorDetraccion.Clear();
            txtValorDetraccion.Clear();
        }

        private void txtValorDetraccion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtValorDetraccion.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(txtValorDetraccion.Text);
                txtPorDetraccion.Focus();
            }
        }

        private void txtPorDetraccion_KeyDown(object sender, KeyEventArgs e)
        {
            txtPorDetraccion.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(txtPorDetraccion.Text);
            btnAceptar.Focus();
        }
    }
}
