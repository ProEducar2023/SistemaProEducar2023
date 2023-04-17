using BLL;
using Entidades;
using System;
using System.Windows.Forms;
namespace Presentacion.DIALOGOS
{
    public partial class CONSULTA_SALDO_TRANSFERENCIA : Form
    {
        string COD_CLASE; string COD_ALMACEN1; string DESC_ALMACEN1;
        string COD_ALMACEN2; string DESC_ALMACEN2; string COD_PRODUCTO; string DESC_PRODUCTO;
        public CONSULTA_SALDO_TRANSFERENCIA(string COD_CLASE, string COD_ALMACEN1, string DESC_ALMACEN1,
        string COD_ALMACEN2, string DESC_ALMACEN2, string COD_PRODUCTO, string DESC_PRODUCTO)
        {
            InitializeComponent();
            this.COD_CLASE = COD_CLASE;
            this.COD_ALMACEN1 = COD_ALMACEN1;
            this.DESC_ALMACEN1 = DESC_ALMACEN1;
            this.COD_ALMACEN2 = COD_ALMACEN2;
            this.DESC_ALMACEN2 = DESC_ALMACEN2;
            this.COD_PRODUCTO = COD_PRODUCTO;
            this.DESC_PRODUCTO = DESC_PRODUCTO;
        }
        private void CONSULTA_SALDO_TRANSFERENCIA_Load(object sender, EventArgs e)
        {
            txt_almacen1.Text = (DESC_ALMACEN1);
            txt_saldo1.Text = (SALDO_PRODUCTO(COD_CLASE, (COD_ALMACEN1), (COD_PRODUCTO)));
            txt_almacen2.Text = (DESC_ALMACEN2);
            txt_saldo2.Text = (SALDO_PRODUCTO(COD_CLASE, (COD_ALMACEN2), (COD_PRODUCTO)));
        }
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void OK_Button_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
        public string SALDO_PRODUCTO(string cod_clase, string cod_almacen, string cod_producto)
        {
            string saldo = "0.00";
            articulosBLL artBLL = new articulosBLL();
            articulosTo artTo = new articulosTo();
            artTo.COD_CLASE = cod_clase;
            artTo.COD_ALMACEN = cod_almacen;
            artTo.COD_ARTICULO = cod_producto;
            return saldo = artBLL.obtenerSaldoProductoxTransferenciaBLL(artTo);
        }


    }
}
