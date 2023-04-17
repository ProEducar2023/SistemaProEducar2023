using BLL;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;
namespace Presentacion.MOD_ADM
{
    public partial class CANAL_DESCUENTO : Form
    {
        string boton;
        DataTable dtCanalDsc;
        canalDescuentoBLL cadBLL = new canalDescuentoBLL();
        canalDescuentoTo cadTo = new canalDescuentoTo();
        public CANAL_DESCUENTO()
        {
            InitializeComponent();
        }

        private void CANAL_DESCUENTO_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            dtCanalDsc = cadBLL.ObtenerCanalDescuentoBLL();
            cargaDataGrid();
            btn_nuevo.Select();
        }
        private void cargaDataGrid()
        {
            if (dtCanalDsc.Rows.Count > 0)
            {
                dgw1.Rows.Clear();
                foreach (DataRow rw in dtCanalDsc.Rows)
                {
                    int rowId = dgw1.Rows.Add();
                    DataGridViewRow row = dgw1.Rows[rowId];
                    row.Cells["codi"].Value = rw["COD"].ToString();
                    row.Cells["cod"].Value = rw["COD_CANAL_DSCTO"].ToString();
                    row.Cells["desc"].Value = rw["DESCRIPCION"].ToString();
                    row.Cells["descc"].Value = rw["DESC_CORTA"].ToString();

                }
            }
        }
        private void CANAL_DESCUENTO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void Limpiar()
        {
            txt_codi.Clear();
            txt_cod.Clear();
            txt_desc.Clear();
            txtdescc.Clear();
            txt_cod.ReadOnly = false;
            txt_desc.ReadOnly = false;
            txtdescc.ReadOnly = false;
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            boton = "NUEVO";
            btn_guardar.Visible = true;
            btn_modificar2.Visible = false;
            Limpiar();
            txt_codi.Text = dgw1.Rows.Count == 0 ? "001" : obtieneCodigo(Convert.ToInt32(dgw1.Rows[dgw1.Rows.Count - 1].Cells["codi"].Value));
            TabControl1.SelectedTab = TabPage2;
            txt_cod.Focus();
        }
        private string obtieneCodigo(int it)
        {
            string ite = (it + 1).ToString();
            return ite.PadLeft(3, '0');
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
            txt_codi.Text = dgw1[0, dgw1.CurrentRow.Index].Value.ToString();
            txt_cod.Text = dgw1[1, dgw1.CurrentRow.Index].Value.ToString();
            txt_desc.Text = dgw1[2, dgw1.CurrentRow.Index].Value.ToString();
            txtdescc.Text = dgw1[3, dgw1.CurrentRow.Index].Value.ToString();
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

                    txt_codi.ReadOnly = true;
                    txt_cod.ReadOnly = true;
                    txt_desc.ReadOnly = true;
                    txtdescc.ReadOnly = true;
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
            DialogResult rs = MessageBox.Show("¿ ESTA SEGURO DE ADICIONAR UN NUEVO CANAL DE DESCUENTO ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                cadTo.COD = txt_codi.Text;
                cadTo.COD_CANAL_DSCTO = txt_cod.Text;
                cadTo.DESCRIPCION = txt_desc.Text;
                cadTo.DESC_CORTA = txtdescc.Text;
                if (!cadBLL.insertaCanalDescuentoBLL(cadTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("SE ADICIONÓ CORRECTAMENTE EL CANAL DE DESCUENTO !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    dgw1.Rows.Add(txt_codi.Text, txt_cod.Text, txt_desc.Text, txtdescc.Text);
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
                MessageBox.Show("INGRESAR EL CODIGO !!!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_cod.Focus();
                return result = false;
            }
            if (txt_desc.Text.Trim() == "")
            {
                MessageBox.Show("INGRESAR LA DESCRIPCIÓN !!!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_desc.Focus();
                return result = false;
            }
            if (txtdescc.Text.Trim() == "")
            {
                MessageBox.Show("INGRESAR LA DESCRIPCIÓN CORTA !!!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtdescc.Focus();
                return result = false;
            }
            return result;
        }
        private void btn_modificar2_Click(object sender, EventArgs e)
        {
            if (!valida())
                return;
            DialogResult rs = MessageBox.Show("¿ ESTA SEGURO DE MODIFICAR EL CANAL DE DESCUENTO ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                cadTo.COD = txt_codi.Text;
                cadTo.COD_CANAL_DSCTO = txt_cod.Text;
                cadTo.DESCRIPCION = txt_desc.Text;
                cadTo.DESC_CORTA = txtdescc.Text;
                if (!cadBLL.actualizaCanalDescuentoBLL(cadTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("SE MODIFICÓ CORRECTAMENTE EL CANAL DE DESCUENTO !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    dgw1.CurrentRow.Cells["cod"].Value = txt_cod.Text;
                    dgw1.CurrentRow.Cells["desc"].Value = txt_desc.Text;
                    dgw1.CurrentRow.Cells["descc"].Value = txtdescc.Text;
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
            DialogResult rs = MessageBox.Show("¿ ESTA SEGURO DE ELIMINAR ESTE CANAL DE DESCUENTO ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                if (!cadBLL.eliminaCanalDescuentoBLL(dgw1.CurrentRow.Cells["codi"].Value.ToString(), ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("SE ELIMINÓ CORRECTAMENTE EL CANAL DE DESCUENTO !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
