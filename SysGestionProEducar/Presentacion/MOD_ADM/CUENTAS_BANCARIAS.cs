using BLL;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;
namespace Presentacion.MOD_ADM
{
    public partial class CUENTAS_BANCARIAS : Form
    {
        cuentaBancariaBLL ctcBLL = new cuentaBancariaBLL();
        cuentaBancariaTo ctcTo = new cuentaBancariaTo();
        public CUENTAS_BANCARIAS()
        {
            InitializeComponent();
        }

        private void CUENTAS_BANCARIAS_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            DATAGRID();
            CARGAR_BANCOS();
            //CARGAR_MONEDA();
            //CARGAR_SUCURSAL();
            CARGAR_BANCOS();
            btn_nuevo.Select();
        }
        private void CUENTAS_BANCARIAS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        public void CARGAR_BANCOS()
        {

        }
        private void DATAGRID()
        {
            DataTable dt = ctcBLL.obtenerCuentasBancariasBLL();
            if (dt.Rows.Count > 0)
            {
                dgw1.DataSource = dt;
                dgw1.Columns[1].Visible = false;
                dgw1.Columns[3].Visible = false;
                dgw1.Columns[6].Visible = false;
                dgw1.Columns[7].Visible = false;
                dgw1.Columns[9].Visible = false;
                dgw1.Columns[0].Width = 40;
                dgw1.Columns[2].Width = 220;
                dgw1.Columns[4].Width = 135;
                dgw1.Columns[5].Width = 35;
            }
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {

        }

    }
}
