using BLL;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;
namespace Presentacion.MOD_ADM
{
    public partial class SUCURSAL : Form
    {
        string boton; DataTable dtSuc; //string con;
        sucursalBLL sucBLL = new sucursalBLL();
        sucursalTo sucTo = new sucursalTo();
        public SUCURSAL()
        {
            InitializeComponent();
        }

        private void SUCURSAL_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            //DATAGRID()
            dtSuc = sucBLL.obtenerSucursalBLL();
            cargaDataGrid();
            btn_nuevo.Select();
        }
        private void cargaDataGrid()
        {
            if (dtSuc.Rows.Count > 0)
            {
                dgw1.Rows.Clear();
                foreach (DataRow rw in dtSuc.Rows)
                {
                    int rowId = dgw1.Rows.Add();
                    DataGridViewRow row = dgw1.Rows[rowId];
                    row.Cells["cod"].Value = rw["Cod"].ToString();
                    row.Cells["desc"].Value = rw["Descripción"].ToString();
                    row.Cells["descc"].Value = rw["DESC_CORTA"].ToString();
                    row.Cells["tel"].Value = rw["TELEFONO"].ToString();
                    row.Cells["dir"].Value = rw["DIRECCION"].ToString();
                    row.Cells["loc"].Value = rw["localidad"].ToString();
                }
            }
        }
        private void SUCURSAL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }
        private void LIMPIAR()
        {
            txt_cod.Clear();
            txt_desc.Clear();
            txt_desc2.Clear();
            txt_fono.Clear();
            txt_dir.Clear();
            txt_localidad.Clear();
            txt_cod.ReadOnly = false;
            txt_desc.ReadOnly = false;
            txt_desc2.ReadOnly = false;
            txt_fono.ReadOnly = false;
            txt_dir.ReadOnly = false;
            txt_localidad.ReadOnly = false;
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            boton = "NUEVO";
            btn_guardar.Visible = true;
            btn_modificar2.Visible = false;
            LIMPIAR();
            //SGT_CODIGO()
            txt_cod.Text = dgw1.Rows.Count == 0 ? "0001" : obtieneCodigo(Convert.ToInt32(dgw1.Rows[dgw1.Rows.Count - 1].Cells["cod"].Value));
            TabControl1.SelectedTab = TabPage2;
            txt_cod.Focus();
        }
        private string obtieneCodigo(int it)
        {
            string ite = (it + 1).ToString();
            return ite.PadLeft(4, '0');
        }
        private void btn_modificar_Click(object sender, EventArgs e)
        {
            boton = "MODIFICAR";
            btn_guardar.Visible = false;
            btn_modificar2.Visible = true;
            LIMPIAR();
            CARGAR_DATOS();
            txt_cod.ReadOnly = true;
            TabControl1.SelectedTab = TabPage2;
            txt_desc.Focus();
        }
        private void CARGAR_DATOS()
        {
            txt_cod.Text = dgw1[0, dgw1.CurrentRow.Index].Value.ToString();
            txt_desc.Text = dgw1[1, dgw1.CurrentRow.Index].Value.ToString();
            txt_desc2.Text = dgw1[2, dgw1.CurrentRow.Index].Value.ToString();
            txt_fono.Text = dgw1[3, dgw1.CurrentRow.Index].Value.ToString();
            txt_dir.Text = dgw1[4, dgw1.CurrentRow.Index].Value.ToString();
            txt_localidad.Text = dgw1[5, dgw1.CurrentRow.Index].Value.ToString();
        }
        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TabControl1.SelectedTab == TabPage2)
            {
                if (boton == "NUEVO")
                    boton = "DETALLES1";
                else if (boton == "MODIFICAR")
                    boton = "DETALLES2";
                else
                {
                    boton = "DETALLES";
                    LIMPIAR();
                    if (dgw1.Rows.Count == 0)
                    { }
                    else
                        CARGAR_DATOS();

                    txt_cod.ReadOnly = true;
                    txt_desc.ReadOnly = true;
                    txt_desc2.ReadOnly = true;
                    txt_fono.ReadOnly = true;
                    txt_dir.ReadOnly = true;
                    txt_localidad.ReadOnly = true;
                    btn_guardar.Visible = false;
                    btn_modificar2.Visible = false;
                }
            }
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (!verifica())
                return;
            DialogResult rs = MessageBox.Show("¿ ESTA SEGURO DE ADICIONAR UNA NUEVA SUCURSAL ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                sucTo.COD_SUCURSAL = txt_cod.Text;
                sucTo.DESC_SUCURSAL = txt_desc.Text;
                sucTo.DESC_CORTA = txt_desc2.Text;
                sucTo.TELEFONO = txt_fono.Text;
                sucTo.DIRECCION = txt_dir.Text;
                sucTo.LOCALIDAD = txt_localidad.Text;
                if (!sucBLL.insertaSucursalBLL(sucTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("SE ADICIONÓ CORRECTAMENTE LA SUCURSAL !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //
                    dgw1.Rows.Add(txt_cod.Text, txt_desc.Text, txt_desc2.Text, txt_fono.Text, txt_dir.Text, txt_localidad.Text);
                    TabControl1.SelectedTab = TabPage1;
                    btn_nuevo.Select();
                }
            }
        }
        private bool verifica()
        {
            bool result = true;
            string errMensaje = string.Empty;
            if (txt_cod.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el codigo !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_cod.Focus();
                return result = false;
            }
            if (txt_desc2.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese la descripcion abreviada !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_desc2.Focus();
                return result = false;
            }
            if (txt_fono.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el telefono !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_fono.Focus();
                return result = false;
            }
            if (txt_dir.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese la direccion !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_dir.Focus();
                return result = false;
            }
            if (btn_guardar.Visible)
            {
                sucTo.COD_SUCURSAL = txt_cod.Text;
                int cant = sucBLL.verificaSucursalBLL(sucTo, ref errMensaje);
                if (cant < 0)
                {
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return result = false;
                }
                else if (cant > 0)
                {
                    MessageBox.Show(errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txt_cod.Focus();
                    return result = false;
                }
            }

            return result;
        }


        private void btn_modificar2_Click(object sender, EventArgs e)
        {
            if (!verifica())
                return;
            DialogResult rs = MessageBox.Show("¿ ESTA SEGURO DE MODIFICAR LA SUCURSAL ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                sucTo.COD_SUCURSAL = txt_cod.Text;
                sucTo.DESC_SUCURSAL = txt_desc.Text;
                sucTo.DESC_CORTA = txt_desc2.Text;
                sucTo.TELEFONO = txt_fono.Text;
                sucTo.DIRECCION = txt_dir.Text;
                sucTo.LOCALIDAD = txt_localidad.Text;
                if (!sucBLL.modificaSucursalBLL(sucTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("SE MODIFICÓ CORRECTAMENTE LA SUCURSAL !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //
                    dgw1.CurrentRow.Cells["cod"].Value = txt_cod.Text;
                    dgw1.CurrentRow.Cells["desc"].Value = txt_desc.Text;
                    dgw1.CurrentRow.Cells["descc"].Value = txt_desc2.Text;
                    dgw1.CurrentRow.Cells["tel"].Value = txt_fono.Text;
                    dgw1.CurrentRow.Cells["dir"].Value = txt_dir.Text;
                    dgw1.CurrentRow.Cells["loc"].Value = txt_localidad.Text;
                    TabControl1.SelectedTab = TabPage1;
                    btn_nuevo.Select();
                }
            }
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("¿ ESTA SEGURO DE ELIMINAR ESTE SUCURSAL ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                sucTo.COD_SUCURSAL = dgw1[0, dgw1.CurrentRow.Index].Value.ToString();
                if (!sucBLL.eliminaSucursalBLL(sucTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("SE ELIMINÓ CORRECTAMENTE LA SUCURSAL !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //
                    dgw1.Rows.RemoveAt(dgw1.CurrentRow.Index);
                }
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            TabControl1.SelectedTab = TabPage1;
            btn_nuevo.Select();
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }

}
