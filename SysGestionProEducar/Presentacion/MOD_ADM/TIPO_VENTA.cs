using BLL;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;
namespace Presentacion.MOD_ADM
{
    public partial class TIPO_VENTA : Form
    {
        string boton; DataTable dtTV;
        tipoVentaBLL tvBLL = new tipoVentaBLL();
        tipoVentaTo tvTo = new tipoVentaTo();
        public TIPO_VENTA()
        {
            InitializeComponent();
        }

        private void TIPO_VENTA_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            dtTV = tvBLL.obtenerTipoVentaBLL();
            cargaDataGrid();
            btn_nuevo.Select();
        }
        private void cargaDataGrid()
        {
            if (dtTV.Rows.Count > 0)
            {
                dgw1.Rows.Clear();
                foreach (DataRow rw in dtTV.Rows)
                {
                    int rowId = dgw1.Rows.Add();
                    DataGridViewRow row = dgw1.Rows[rowId];
                    row.Cells["cod"].Value = rw["COD_TIPO_VENTA"].ToString();
                    row.Cells["desc"].Value = rw["DESC_TIPO_VENTA"].ToString();
                    row.Cells["descc"].Value = rw["DESC_CORTA"].ToString();
                }
            }
        }
        private void TIPO_VENTA_KeyDown(object sender, KeyEventArgs e)
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
            txt_descc.Clear();
            txt_cod.ReadOnly = false;
            txt_desc.ReadOnly = false;
            txt_descc.ReadOnly = false;
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            boton = "NUEVO";
            btn_guardar.Visible = true;
            btn_modificar2.Visible = false;
            Limpiar();
            //txt_cod.Text = "0" + (dgw1.Rows.Count + 1).ToString();
            txt_cod.Text = dgw1.Rows.Count == 0 ? "01" : calcularItem();
            TabControl1.SelectedTab = TabPage2;
            txt_desc.Focus();
        }
        private string calcularItem()
        {
            string valor = "";
            int numValue = 0;
            for (int j = dgw1.Rows.Count - 1; j >= 0; j--)
            {
                if (int.TryParse(dgw1.Rows[j].Cells["cod"].Value.ToString(), out numValue))
                {
                    valor = obtieneCodigo(numValue);
                    return valor;
                }
            }
            valor = "01";
            return valor;
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
            txt_descc.Text = dgw1[2, dgw1.CurrentRow.Index].Value.ToString();
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
                    { }
                    else
                        CargarDatos();

                    txt_cod.ReadOnly = true;
                    txt_desc.ReadOnly = true;
                    txt_descc.ReadOnly = true;
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
            DialogResult rs = MessageBox.Show("¿ Esta seguro de adicionar un nuevo Tipo de Venta ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                tvTo.COD_TIPO_VENTA = txt_cod.Text;
                tvTo.DESC_TIPO_VENTA = txt_desc.Text;
                tvTo.DESC_CORTA = txt_desc.Text;
                if (!tvBLL.insertarTipoVentaBLL(tvTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Se adicionò correctamente el Tipo de Venta !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgw1.Rows.Add(txt_cod.Text, txt_desc.Text, txt_descc.Text);
                    TabControl1.SelectedTab = TabPage1;
                    btn_nuevo.Select();
                }
            }
        }
        private bool valida()
        {
            bool result = true;
            string errMensaje = "";
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
            if (txt_descc.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese la descripcion corta !!!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_descc.Focus();
                return result = false;
            }
            if (btn_guardar.Visible)
            {
                tvTo.COD_TIPO_VENTA = txt_cod.Text;
                if (tvBLL.verificaTipoVentaBLL(tvTo, ref errMensaje))
                {
                    MessageBox.Show("El codigo ya existe !!!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txt_cod.Focus();
                    return result = false;
                }
                else
                {
                    if (errMensaje != "")
                    {
                        MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return result = false;
                    }

                }
            }
            return result;
        }

        private void btn_modificar2_Click(object sender, EventArgs e)
        {
            if (!valida())
                return;
            DialogResult rs = MessageBox.Show("¿ Esta seguro de modificar el Tipo de Venta ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                tvTo.COD_TIPO_VENTA = txt_cod.Text;
                tvTo.DESC_TIPO_VENTA = txt_desc.Text;
                tvTo.DESC_CORTA = txt_descc.Text;
                if (!tvBLL.modificarTipoVentaBLL(tvTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Se modifico correctamente el Tipo de Venta !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgw1.CurrentRow.Cells["cod"].Value = txt_cod.Text;
                    dgw1.CurrentRow.Cells["desc"].Value = txt_desc.Text;
                    dgw1.CurrentRow.Cells["descc"].Value = txt_descc.Text;
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
            DialogResult rs = MessageBox.Show("¿ Esta seguro de eliminar el Tipo de Venta ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                tvTo.COD_TIPO_VENTA = dgw1.CurrentRow.Cells["cod"].Value.ToString();
                if (!tvBLL.eliminarTipoVentaBLL(tvTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Se elimino correctamente del Tipo de Venta !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
