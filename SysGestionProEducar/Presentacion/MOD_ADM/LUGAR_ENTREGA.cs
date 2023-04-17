using BLL;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;
namespace Presentacion.MOD_ADM
{
    public partial class LUGAR_ENTREGA : Form
    {
        string boton; DataTable dtLGE;
        lugarEntregaBLL lgeBLL = new lugarEntregaBLL();
        lugarEntregaTo lgeTo = new lugarEntregaTo();

        public LUGAR_ENTREGA()
        {
            InitializeComponent();
        }

        private void LUGAR_ENTREGA_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            dtLGE = lgeBLL.obtenerLugarEntregaBLL();
            cargaDataGrid();
            btn_nuevo.Select();
        }
        private void cargaDataGrid()
        {
            if (dtLGE.Rows.Count > 0)
            {
                dgw1.Rows.Clear();
                foreach (DataRow rw in dtLGE.Rows)
                {
                    int rowId = dgw1.Rows.Add();
                    DataGridViewRow row = dgw1.Rows[rowId];
                    row.Cells["Cod"].Value = rw["Cód"].ToString();
                    row.Cells["desc"].Value = rw["Descripción"].ToString();
                }
            }
        }
        private void LUGAR_ENTREGA_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void Limpiar()
        {
            txt_cod.Clear();
            txt_desc.Clear();
            txt_cod.ReadOnly = false;
            txt_desc.ReadOnly = false;
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            boton = "NUEVO";
            btn_guardar.Visible = true;
            btn_modificar2.Visible = false;
            Limpiar();
            txt_cod.Text = dgw1.Rows.Count == 0 ? "01" : obtieneCodigo(Convert.ToInt32(dgw1.Rows[dgw1.Rows.Count - 1].Cells["Cod"].Value));
            TabControl1.SelectedTab = TabPage2;
            txt_desc.Focus();
        }
        private string obtieneCodigo(int it)
        {
            string ite = (it + 1).ToString();
            return ite.PadLeft(2, '0');
        }
        private void btn_modificar_Click(object sender, EventArgs e)
        {
            int i = dgw1.CurrentRow.Index;
            boton = "MODIFICAR";
            btn_guardar.Visible = false;
            btn_modificar2.Visible = true;
            Limpiar();
            CargarDatos();
            txt_cod.ReadOnly = true;
            TabControl1.SelectedTab = TabPage2;
            txt_desc.Focus();
        }

        private void CargarDatos()
        {
            txt_cod.Text = dgw1[0, dgw1.CurrentRow.Index].Value.ToString();
            txt_desc.Text = dgw1[1, dgw1.CurrentRow.Index].Value.ToString();
        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TabControl1.SelectedTab == TabPage2)
            {
                if (boton == "NUEVO")
                {
                    boton = "DETALLES1";
                }
                else if (boton == "MODIFICAR")
                {
                    boton = "DETALLES2";
                }
                else
                {
                    boton = "DETALLES";
                    Limpiar();
                    if (dgw1.Rows.Count == 0)
                    {


                    }
                    else
                        CargarDatos();

                    txt_cod.ReadOnly = true;
                    txt_desc.ReadOnly = true;
                    btn_guardar.Visible = false;
                    btn_modificar2.Visible = false;
                }
            }
            else
                btn_nuevo.Select();
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (!valida())
                return;
            DialogResult rs = MessageBox.Show("¿ ESTA SEGURO DE ADICIONAR UN NUEVO LUGAR DE ENTREGA ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                lgeTo.COD_LUGAR_ENT = txt_cod.Text;
                lgeTo.DESC_LUGAR_ENT = txt_desc.Text;
                if (!lgeBLL.insertarLugarEntregaBLL(lgeTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("SE ADICIONÓ CORRECTAMENTE EL LUGAR DE ENTREGA !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgw1.Rows.Add(txt_cod.Text, txt_desc.Text);//, txtdescc.Text);
                    TabControl1.SelectedTab = TabPage1;
                    btn_nuevo.Select();
                }
            }

        }
        private bool valida()
        {
            bool result = true;
            if (txt_cod.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el codigo !!!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_cod.Focus();
                return result = false;
            }
            if (txt_desc.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese la descripcion !!!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_desc.Focus();
                return result = false;
            }
            if (btn_guardar.Visible)
            {
                lgeTo.COD_LUGAR_ENT = txt_cod.Text;
                if (lgeBLL.verificarLugarEntregaBLL(lgeTo) > 0)
                {
                    MessageBox.Show("El codigo ya existe !!!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txt_cod.Focus();
                    return result = false;
                }
            }
            return result;
        }
        private void btn_modificar2_Click(object sender, EventArgs e)
        {
            if (!valida())
                return;
            DialogResult rs = MessageBox.Show("¿ ESTA SEGURO DE MODIFICAR EL LUGAR DE ENTREGA ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                lgeTo.COD_LUGAR_ENT = txt_cod.Text;
                lgeTo.DESC_LUGAR_ENT = txt_desc.Text;
                if (!lgeBLL.modificarLugarEntregaBLL(lgeTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("SE MODIFICÓ CORRECTAMENTE EL LUGAR DE ENTREGA !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgw1.CurrentRow.Cells["Cod"].Value = txt_cod.Text;
                    dgw1.CurrentRow.Cells["desc"].Value = txt_desc.Text;
                    TabControl1.SelectedTab = TabPage1;
                    btn_nuevo.Select();
                }
            }

        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            TabControl1.SelectedTab = TabPage1;
            btn_nuevo.Select();
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("¿ ESTA SEGURO DE ELIMINAR EL LUGAR DE ENTREGA ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                lgeTo.COD_LUGAR_ENT = dgw1.CurrentRow.Cells["Cod"].Value.ToString();
                if (!lgeBLL.eliminarLugarEntregaBLL(lgeTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("SE ELIMINÓ CORRECTAMENTE EL LUGAR DE ENTREGA !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgw1.Rows.RemoveAt(dgw1.CurrentRow.Index);
                }
            }

        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
