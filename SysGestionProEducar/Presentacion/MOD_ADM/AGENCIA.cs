using BLL;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;
namespace Presentacion.MOD_ADM
{
    public partial class AGENCIA : Form
    {
        string boton; DataTable dtAge;
        agenciaBLL ageBLL = new agenciaBLL();
        agenciaTo ageTo = new agenciaTo();
        public AGENCIA()
        {
            InitializeComponent();
        }

        private void AGENCIA_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            dtAge = ageBLL.obtenerAgenciaBLL();
            cargaDataGrid();
            btn_nuevo.Select();
        }
        private void cargaDataGrid()
        {
            if (dtAge.Rows.Count > 0)
            {
                dgw.Rows.Clear();
                foreach (DataRow rw in dtAge.Rows)
                {
                    int rowId = dgw.Rows.Add();
                    DataGridViewRow row = dgw.Rows[rowId];
                    row.Cells["cod"].Value = rw["Cod"].ToString();
                    row.Cells["ruc"].Value = rw["ruc"].ToString();
                    row.Cells["nom"].Value = rw["Descripción"].ToString();
                    row.Cells["dir"].Value = rw["direccion"].ToString();
                    row.Cells["fon"].Value = rw["telefono"].ToString();
                }
            }
        }
        private void AGENCIA_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void Limpiar()
        {
            txt_cod.Clear();
            txt_ruc.Clear();
            txt_nom.Clear();
            txt_dir.Clear();
            TXT_FONO.Clear();
            txt_cod.ReadOnly = false;
            txt_ruc.ReadOnly = false;
            txt_nom.ReadOnly = false;
            txt_dir.ReadOnly = false;
            TXT_FONO.ReadOnly = false;
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            boton = "NUEVO";
            btn_guardar.Visible = true;
            btn_modificar2.Visible = false;
            Limpiar();
            txt_cod.Text = dgw.Rows.Count == 0 ? "01" : obtieneCodigo(Convert.ToInt32(dgw.Rows[dgw.Rows.Count - 1].Cells["cod"].Value));
            TabControl1.SelectedTab = TabPage2;
            txt_ruc.Focus();
        }
        private string obtieneCodigo(int it)
        {
            string ite = (it + 1).ToString();
            return ite.PadLeft(2, '0');
        }
        private void btn_modificar_Click(object sender, EventArgs e)
        {
            int i = dgw.CurrentRow.Index;
            boton = "MODIFICAR";
            btn_guardar.Visible = false;
            btn_modificar2.Visible = true;
            Limpiar();
            CargarDatos();
            txt_cod.ReadOnly = true;
            TabControl1.SelectedTab = TabPage2;
            txt_ruc.Focus();
        }

        private void CargarDatos()
        {
            txt_cod.Text = dgw[0, dgw.CurrentRow.Index].Value.ToString();
            txt_ruc.Text = dgw[1, dgw.CurrentRow.Index].Value.ToString();
            txt_nom.Text = dgw[2, dgw.CurrentRow.Index].Value.ToString();
            txt_dir.Text = dgw[3, dgw.CurrentRow.Index].Value.ToString();
            TXT_FONO.Text = dgw[4, dgw.CurrentRow.Index].Value.ToString();
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
                    if (dgw.Rows.Count == 0)
                    {
                    }
                    else
                        CargarDatos();

                    txt_cod.ReadOnly = true;
                    txt_ruc.ReadOnly = true;
                    txt_nom.ReadOnly = true;
                    txt_dir.ReadOnly = true;
                    TXT_FONO.ReadOnly = true;
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
            DialogResult rs = MessageBox.Show("¿ ESTA SEGURO DE ADICIONAR UNA NUEVA AGENCIA ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                ageTo.COD_AGENCIA = txt_cod.Text;
                ageTo.NOMBRE = txt_nom.Text;
                ageTo.RUC = txt_ruc.Text;
                ageTo.DIRECCION = txt_dir.Text;
                ageTo.TELEFONO = TXT_FONO.Text;
                if (!ageBLL.insertarAgenciaBLL(ageTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("SE ADICIONÓ CORRECTAMENTE LA AGENCIA !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgw.Rows.Add(txt_cod.Text, txt_ruc.Text, txt_nom.Text, txt_dir.Text, TXT_FONO.Text);
                    TabControl1.SelectedTab = TabPage1;
                    btn_nuevo.Select();
                }
            }

        }
        private bool valida()
        {
            bool result = true;
            if (txt_ruc.Text.Trim() == "")
            {
                MessageBox.Show("INGRESAR EL RUC !!!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_ruc.Focus();
                return result = false;
            }
            if (txt_nom.Text.Trim() == "")
            {
                MessageBox.Show("INGRESAR EL NOMBRE !!!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_nom.Focus();
                return result = false;
            }
            if (txt_dir.Text.Trim() == "")
            {
                MessageBox.Show("INGRESAR LA DIRECCION !!!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_dir.Focus();
                return result = false;
            }
            if (TXT_FONO.Text.Trim() == "")
            {
                MessageBox.Show("INGRESAR EL TELEFONO !!!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TXT_FONO.Focus();
                return result = false;
            }
            if (btn_guardar.Visible)
            {
                ageTo.COD_AGENCIA = txt_cod.Text;
                if (ageBLL.verificarAgenciaBLL(ageTo) > 0)
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
            DialogResult rs = MessageBox.Show("¿ ESTA SEGURO DE MODIFICAR LA AGENCIA ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                ageTo.COD_AGENCIA = txt_cod.Text;
                ageTo.NOMBRE = txt_nom.Text;
                ageTo.RUC = txt_ruc.Text;
                ageTo.DIRECCION = txt_dir.Text;
                ageTo.TELEFONO = TXT_FONO.Text;
                if (!ageBLL.modificarAgenciaBLL(ageTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("SE MODIFICÓ CORRECTAMENTE LA AGENCIA !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgw.CurrentRow.Cells["cod"].Value = txt_cod.Text;
                    dgw.CurrentRow.Cells["ruc"].Value = txt_ruc.Text;
                    dgw.CurrentRow.Cells["nom"].Value = txt_nom.Text;
                    dgw.CurrentRow.Cells["dir"].Value = txt_dir.Text;
                    dgw.CurrentRow.Cells["fon"].Value = TXT_FONO.Text;
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
            DialogResult rs = MessageBox.Show("¿ ESTA SEGURO DE ELIMINAR ESTA INSTITUCION ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                ageTo.COD_AGENCIA = dgw.CurrentRow.Cells["cod"].Value.ToString();
                if (!ageBLL.eliminarAgenciaBLL(ageTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("SE ELIMINÓ CORRECTAMENTE LA INSTITUCION !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgw.Rows.RemoveAt(dgw.CurrentRow.Index);
                }
            }
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
