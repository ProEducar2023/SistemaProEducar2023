using BLL;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;

namespace Presentacion.MOD_ADM
{
    public partial class MOTIVO_DESCUENTO_DIRECTA : Form
    {
        string boton; DataTable dtSuc;
        motivoLlamadasDescCobDirBLL mlBLL = new motivoLlamadasDescCobDirBLL();
        motivoLlamadasDescCobDirTo mlTo = new motivoLlamadasDescCobDirTo();
        public MOTIVO_DESCUENTO_DIRECTA()
        {
            InitializeComponent();
        }

        private void MOTIVO_DESCUENTO_DIRECTA_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            //DATAGRID()
            mlTo.CATEGORIA = null;
            dtSuc = mlBLL.obtenerMotivoLlamadasDescCobDirBLL(mlTo);
            cargarCategoria();
            cargaDataGrid();
            btn_nuevo.Select();
        }
        private void cargarCategoria()
        {
            var categoria = new[] { new { cod = "1", val = "Llamadas" }, new { cod = "2", val = "Verificacion" } };
            cbo_categoria.ValueMember = "cod";
            cbo_categoria.DisplayMember = "val";
            cbo_categoria.DataSource = categoria;
            cbo_categoria.SelectedIndex = -1;
        }
        private void MOTIVO_DESCUENTO_DIRECTA_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
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
                    row.Cells["cod"].Value = rw["COD_MOTIVO"].ToString();
                    row.Cells["desc"].Value = rw["DESC_MOTIVO"].ToString();
                    row.Cells["tipo"].Value = rw["TIPO_MOTIVO"].ToString();
                    row.Cells["cod_categoria"].Value = rw["CATEGORIA"].ToString();
                    row.Cells["desc_categoria"].Value = rw["CATEGORIA"].ToString() == "1" ? "Llamadas" : "Verificacion";
                }
            }
        }
        private void LIMPIAR()
        {
            txt_cod.Clear();
            txt_desc.Clear();
            txt_tipo.Clear();
            cbo_categoria.SelectedIndex = -1;
            txt_cod.ReadOnly = false;
            txt_desc.ReadOnly = false;
            txt_tipo.ReadOnly = false;
            cbo_categoria.Enabled = true;
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            boton = "NUEVO";
            btn_guardar.Visible = true;
            btn_modificar2.Visible = false;
            LIMPIAR();
            //SGT_CODIGO()
            txt_cod.Text = dgw1.Rows.Count == 0 ? "01" : obtieneCodigo(Convert.ToInt32(dgw1.Rows[dgw1.Rows.Count - 1].Cells["cod"].Value));
            TabControl1.SelectedTab = TabPage2;
            txt_cod.Focus();
        }
        private string obtieneCodigo(int it)
        {
            string ite = (it + 1).ToString();
            return ite.PadLeft(2, '0');
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
            txt_tipo.Text = dgw1[2, dgw1.CurrentRow.Index].Value.ToString();
            cbo_categoria.SelectedValue = dgw1[3, dgw1.CurrentRow.Index].Value;
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
                    txt_tipo.ReadOnly = true;
                    cbo_categoria.Enabled = false;
                    btn_guardar.Visible = false;
                    btn_modificar2.Visible = false;
                }
            }
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (!verifica())
                return;
            DialogResult rs = MessageBox.Show("¿ Esta seguro de adicionar un nuevo Motivo ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                mlTo.COD_MOTIVO = txt_cod.Text;
                mlTo.DESC_MOTIVO = txt_desc.Text;
                mlTo.TIPO_MOTIVO = txt_tipo.Text;
                mlTo.CATEGORIA = cbo_categoria.SelectedValue.ToString();
                if (!mlBLL.insertarMotivoLlamadaDescCobDirBLL(mlTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Se adicionó correctamente el Motivo !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //
                    dgw1.Rows.Add(txt_cod.Text, txt_desc.Text, txt_tipo.Text, cbo_categoria.SelectedValue.ToString(), cbo_categoria.Text);
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
            if (txt_desc.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese la descripcion !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_desc.Focus();
                return result = false;
            }
            if (cbo_categoria.SelectedIndex == -1)
            {
                MessageBox.Show("Elija la categoria !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_categoria.Focus();
                return result = false;
            }
            if (btn_guardar.Visible)
            {
                mlTo.COD_MOTIVO = txt_cod.Text;
                int cant = mlBLL.verificaMotivoLlamadaDescCobDirBLL(mlTo, ref errMensaje);
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
            DialogResult rs = MessageBox.Show("¿ Esta seguro de modificar el Motivo ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                mlTo.COD_MOTIVO = txt_cod.Text;
                mlTo.DESC_MOTIVO = txt_desc.Text;
                mlTo.TIPO_MOTIVO = txt_tipo.Text;
                mlTo.CATEGORIA = cbo_categoria.SelectedValue.ToString();
                if (!mlBLL.modificarMotivoLlamadaDescCobDirBLL(mlTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Se modificó correctamente el Motivo !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //
                    dgw1.CurrentRow.Cells["cod"].Value = txt_cod.Text;
                    dgw1.CurrentRow.Cells["desc"].Value = txt_desc.Text;
                    dgw1.CurrentRow.Cells["tipo"].Value = txt_tipo.Text;
                    dgw1.CurrentRow.Cells["cod_categoria"].Value = cbo_categoria.SelectedValue.ToString();
                    dgw1.CurrentRow.Cells["desc_categoria"].Value = cbo_categoria.Text;
                    TabControl1.SelectedTab = TabPage1;
                    btn_nuevo.Select();
                }
            }
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("¿ Está seguro de eliminar este Motivo ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                mlTo.COD_MOTIVO = dgw1[0, dgw1.CurrentRow.Index].Value.ToString();
                if (!mlBLL.eliminarMotivoLlamadaDescCobDirBLL(mlTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Se eliminó correctamente el Motivo !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
