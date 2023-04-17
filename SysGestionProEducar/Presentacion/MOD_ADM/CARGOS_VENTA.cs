using BLL;
using System;
using System.Data;
using System.Windows.Forms;

namespace Presentacion.MOD_ADM
{
    public partial class CARGOS_VENTA : Form
    {
        string boton;
        DataTable dtCargosVenta;
        cargosVentaBLL cavBLL = new cargosVentaBLL();
        public CARGOS_VENTA()
        {
            InitializeComponent();
        }

        private void CARGOS_VENTA_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            dtCargosVenta = cavBLL.obtenerCargosVentaBLL();
            cargaDataGrid();
            btn_nuevo.Select();
        }
        private void cargaDataGrid()
        {
            if (dtCargosVenta.Rows.Count > 0)
            {
                dgw1.Rows.Clear();
                foreach (DataRow rw in dtCargosVenta.Rows)
                {
                    int rowId = dgw1.Rows.Add();
                    DataGridViewRow row = dgw1.Rows[rowId];
                    row.Cells["cod"].Value = rw["COD_CARGO"].ToString();
                    row.Cells["desc"].Value = rw["DESC_CARGO"].ToString();
                }
            }
        }
        private void CARGOS_VENTA_KeyDown(object sender, KeyEventArgs e)
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
            txt_cod.Enabled = true;
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            boton = "NUEVO";
            btn_guardar.Visible = true;
            btn_modificar2.Visible = false;
            Limpiar();
            txt_cod.Text = dgw1.Rows.Count == 0 ? "01" : obtieneCodigo(Convert.ToInt32(dgw1.Rows[dgw1.Rows.Count - 1].Cells["cod"].Value));
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
                    txt_cod.Enabled = false;
                }
            }
            else
                btn_nuevo.Select();
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("¿ ESTA SEGURO DE ADICIONAR UN NUEVO CARGO ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                if (!valida())
                    return;
                string errMensaje = string.Empty;
                if (!cavBLL.insertaCargosVentaBLL(txt_cod.Text, txt_desc.Text, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("SE ADICIONÓ CORRECTAMENTE EL CARGO !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgw1.Rows.Add(txt_cod.Text, txt_desc.Text);
                    TabControl1.SelectedTab = TabPage1;
                    btn_nuevo.Select();
                }
            }

        }
        private bool valida()
        {
            bool result = true;
            if (txt_desc.Text.Trim() == "")
            {
                MessageBox.Show("INGRESAR LA DESCRIPCIÓN !!!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_desc.Focus();
                return result = false;
            }

            return result;
        }
        private void btn_modificar2_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("¿ ESTA SEGURO DE MODIFICAR EL CARGO ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                if (!valida())
                    return;
                string errMensaje = string.Empty;
                if (!cavBLL.modificaCargosVentaBLL(txt_cod.Text, txt_desc.Text, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("SE MODIFICÓ CORRECTAMENTE EL CARGO !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            DialogResult rs = MessageBox.Show("¿ ESTA SEGURO DE ELIMINAR ESTE CARGO ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                if (!cavBLL.eliminaCargosVentaBLL(dgw1.CurrentRow.Cells["cod"].Value.ToString(), ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("SE ELIMINÓ CORRECTAMENTE EL CARGO !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
