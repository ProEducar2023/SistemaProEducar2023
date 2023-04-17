using BLL;
using System;
using System.Data;
using System.Windows.Forms;
using Presentacion.HELPERS;

namespace Presentacion
{
    public partial class INICIO : Form
    {
        string TIPO_USU = "", COD_USU = "", clave = "";
        usuariosBLL usuBLL = new usuariosBLL();
        empresaBLL empBLL = new empresaBLL();
        DataTable dtUsuario;
        DataTable dtEmpresa;
        public INICIO()
        {
            InitializeComponent();
        }
        private void INICIO_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            cargar_usuario();
            cargar_empresa();
            //txt_c.Text = "imaginacion";
        }
        private void cargar_usuario()
        {
            dtUsuario = usuBLL.obtenerTodosUsuariosBLL();
            cbo_usuario.DisplayMember = "Nick";
            cbo_usuario.ValueMember = "Cod_usu";
            cbo_usuario.DataSource = dtUsuario;
            cbo_usuario.SelectedIndex = -1;
        }
        private void cargar_empresa()
        {
            dtEmpresa = empBLL.obtenerTodasEmpresasBLL();
            cbo_empresa.DisplayMember = "Razon_Social";
            cbo_empresa.ValueMember = "Cod_Empresa";
            cbo_empresa.DataSource = dtEmpresa;
            cbo_empresa.SelectedIndex = -1;
        }

        private void INICIO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            if (!validaAceptar())
                return;

            EstablecerUsuarioSistema();
            EstablecerEmpresaSistema();
            string COD_EMPRESA = cbo_empresa.SelectedValue.ToString();
            string COD_PAIS = dtEmpresa.AsEnumerable().Where(x => x.Field<string>("Cod_Empresa") == Convert.ToString(cbo_empresa.SelectedValue)).CopyToDataTable().Rows[0]["COD_PAIS"].ToString();
            Properties.Settings.Default.BD_COD = cbo_empresa.SelectedValue.ToString();
            Properties.Settings.Default.Save();
            //> COD_PAIS
            ICONOS frm = new ICONOS(COD_EMPRESA, COD_USU, COD_PAIS);
            frm.Show();
            this.Hide();

            //if(txt_c.Text.Trim() == "123")
            //{
            //    ICONOS frm = new ICONOS(TIPO_USU, COD_USU);
            //    frm.Show();
            //    this.Hide();
            //}
            //else
            //{
            //    MessageBox.Show("Contraseña incorrecta !!!","MENSAJE",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            //    txt_c.Clear();
            //    txt_c.Focus();
            //}

        }
        private bool validaAceptar()
        {
            bool result = true;
            string enc = HelpersBLL.ENCRIPTAR(txt_c.Text);
            if (clave != enc)
            {
                MessageBox.Show("Contraseña incorrecta !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_c.Clear();
                txt_c.Focus();
                return result = false;
            }
            return result;
        }
        private void cbo_usuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_usuario.SelectedValue != null)
            {
                DataRow[] rs = dtUsuario.Select("Nick = '" + cbo_usuario.Text + "'");
                foreach (DataRow r in rs)
                {
                    clave = r["Clave"].ToString();
                    TIPO_USU = r["Tipo"].ToString();
                    COD_USU = r["Cod_usu"].ToString();
                }
            }
        }

        private void EstablecerUsuarioSistema()
        {
            DataTable dt = usuBLL.obtenerUsuario_x_CodBLL(new Entidades.usuariosTo { Cod_usu = COD_USU });
            if (dt != null)
            {
                GenericUtil.UsuarioSistema = new Entidades.usuariosTo
                {
                    Cod_usu = dt.Rows[0]["Cod_usu"].ToString(),
                    Nombres = dt.Rows[0]["Nombres"].ToString(),
                    Tipo = dt.Rows[0]["Tipo"].ToString(),
                    Nick = dt.Rows[0]["Nick"].ToString()
                };
            }
            else
                _ = MessageBox.Show("Error al obtener el usuario del sistema. \n Comuniquese con el administador del sistema", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void EstablecerEmpresaSistema()
        {
            DataRow[] rowsEmpresa = dtEmpresa.Select("Cod_Empresa = '" + cbo_empresa.SelectedValue.ToString() + "'");
            if(rowsEmpresa.Length == 1)
            {
                GenericUtil.EmpresaSistema = new Entidades.empresaTo
                {
                    CodPais = rowsEmpresa[0]["COD_PAIS"].ToString(),
                    Cod_Empresa = rowsEmpresa[0]["Cod_Empresa"].ToString(),
                    Nro_Ruc = rowsEmpresa[0]["Nro_Ruc"].ToString(),
                    Razon_Social = rowsEmpresa[0]["Razon_Social"].ToString()
                };
            }
            else
                _ = MessageBox.Show("Error al obtener la empresa del sistema. \n Comuniquese con el administador del sistema", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
