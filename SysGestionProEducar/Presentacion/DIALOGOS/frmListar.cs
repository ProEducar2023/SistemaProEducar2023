using BLL;
using System;
using System.Data;
using System.Windows.Forms;
namespace Presentacion.DIALOGOS
{
    public partial class frmListar : Form
    {
        DataTable dt = new DataTable();
        public string tipo;
        public frmListar()
        {
            InitializeComponent();
            //this.op = op;
        }

        private void frmListar_Load(object sender, EventArgs e)
        {

        }
        public void CargarDatos()
        {
            if (tipo == "Personal")
            {
                personalBLL perBLL = new personalBLL();
                dt = perBLL.obtenerPersonalparaUsuariosCargoBLL();
                dgw.DataSource = dt;
            }
            else if (tipo == "Usuarios")
            {
                usuariosBLL usuBLL = new usuariosBLL();
                dt = usuBLL.obtenerUsuariosparaUsuariosCargoBLL();
                dgw.DataSource = dt;
            }
            else if (tipo == "EqVentas")
            {
                progNivelBLL prniBLL = new progNivelBLL();
                dt = prniBLL.obtenerPersonalparaCrearEqVentaBLL();//param=COD_PER codigo de personal
                dgw.DataSource = dt;
            }
            else if (tipo == "EqCobranza")
            {
                progNivelBLL prniBLL = new progNivelBLL();
                dt = prniBLL.obtenerPersonalparaCrearEqCobranzaBLL();
                dgw.DataSource = dt;
            }
        }

        private void dgw_DoubleClick(object sender, EventArgs e)
        {
            //this.Hide();
            OK_Button.DialogResult = DialogResult.OK;
        }
    }
}
