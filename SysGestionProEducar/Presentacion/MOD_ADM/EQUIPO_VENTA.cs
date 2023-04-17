using BLL;
using System;
using System.Data;
using System.Windows.Forms;

namespace Presentacion.MOD_ADM
{
    public partial class EQUIPO_VENTA : Form
    {
        string boton;
        string cargo1;
        int fila;
        DataTable dtCombo, dtUsuario, dtCargos;
        personaBLL perBLL = new personaBLL();
        public EQUIPO_VENTA()
        {
            InitializeComponent();
        }

        private void EQUIPO_VENTA_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            CARGAR_CARGO();
            cargaGrid();
            btn_modificar.Select();
        }
        private void CARGAR_CARGO()
        {
            dtCombo = perBLL.obtenerCargoBLL();
            cbo_cargo.DisplayMember = "desc_cargo";
            cbo_cargo.ValueMember = "desc_cargo";
            cbo_cargo.DataSource = dtCombo;
        }
        private void cargaGrid()
        {
            dtUsuario = perBLL.obtenerEquipoVentaBLL();
            if (dtUsuario.Rows.Count > 0)
            {
                foreach (DataRow rw in dtUsuario.Rows)
                {
                    int rowId = dgw1.Rows.Add();
                    DataGridViewRow row = dgw1.Rows[rowId];
                    row.Cells["cod"].Value = rw["Codigo"].ToString();
                    row.Cells["nom"].Value = rw["Nombre"].ToString();
                    row.Cells["nrodoc"].Value = rw["Nroº Doc."].ToString();
                    row.Cells["COD_CARGO"].Value = rw["COD_CARGO"].ToString();
                    row.Cells["DESC_CARGO"].Value = rw["DESC_CARGO"].ToString();

                }
            }
        }
        private void EQUIPO_VENTA_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void CARGAR_CABECERA()
        {

            txt_cod.Text = dgw1[0, dgw1.CurrentRow.Index].Value.ToString();
            txt_desc.Text = dgw1[1, dgw1.CurrentRow.Index].Value.ToString();
            txt_NRO_DOC.Text = dgw1[2, dgw1.CurrentRow.Index].Value.ToString();
            //if (dgw1[3, dgw1.CurrentRow.Index].Value.ToString() != "" || dgw1[4, dgw1.CurrentRow.Index].Value.ToString() != "")
            //    dgw.Rows.Add(dgw1[3, dgw1.CurrentRow.Index].Value.ToString(), dgw1[4, dgw1.CurrentRow.Index].Value.ToString());
        }
        private void LIMPIAR_CABECERA()
        {
            txt_cod.Clear();
            txt_desc.Clear();
            txt_NRO_DOC.Clear();
            dgw.Rows.Clear();
        }
        private void LIMPIAR_detalle()
        {
            cbo_cargo.SelectedIndex = -1;
            cbo_cargo.Enabled = true;
            btn_guardar2.Visible = true;
            btn_cancelar2.Visible = true;
        }

        private void btn_nuevo2_Click(object sender, EventArgs e)
        {
            LIMPIAR_detalle();
            btn_guardar2.Visible = true;
            btn_cancelar.Visible = false;
            Panel_v0.Visible = false;
            Panel_v1.Visible = true;
            cbo_cargo.Select();
        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            if (dgw1.Rows.Count <= 0)
                return;
            boton = "MODIFICAR";
            LIMPIAR_CABECERA();
            CARGAR_CABECERA();
            btn_cancelar.Visible = true;
            btn_cancelar.Text = "&Cancelar";
            obtieneCargos();
            TabControl1.SelectedTab = TabPage2;
            Panel_v0.Visible = true;
            Panel_v1.Visible = false;
            btn_nuevo2.Select();
        }
        private void obtieneCargos()
        {
            dgw.Rows.Clear();
            dtCargos = perBLL.obtieneCargoporUsuarioBLL(dgw1.CurrentRow.Cells["cod"].Value.ToString());
            if (dtCargos.Rows.Count > 0)
            {
                foreach (DataRow rw in dtCargos.Rows)
                {
                    int rowId = dgw.Rows.Add();
                    DataGridViewRow row = dgw.Rows[rowId];
                    row.Cells["codcc"].Value = rw["COD_cargo"].ToString();
                    row.Cells["cargocc"].Value = rw["desc_cargo"].ToString();
                }
            }
        }
        private void btn_eliminar2_Click(object sender, EventArgs e)
        {
            if (dgw.Rows.Count <= 0)
                return;
            DialogResult rs = MessageBox.Show("¿ Esta seguro de eliminar el Cargo !!! ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;

                if (!perBLL.eliminarCargoPersonaUsuariosCargoBLL(txt_cod.Text, dgw.CurrentRow.Cells["codcc"].Value.ToString(), ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Se elimino correctamente el Cargo !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgw.Rows.RemoveAt(dgw.CurrentRow.Index);
                    TabControl1.SelectedTab = TabPage1;
                    btn_modificar.Select();
                }
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            TabControl1.SelectedTab = TabPage1;
            btn_modificar.Select();
        }

        private void btn_cancelar2_Click(object sender, EventArgs e)
        {
            Panel_v1.Visible = false;
            Panel_v0.Visible = true;
            btn_cancelar.Visible = true;
            btn_cancelar.Text = "&Salir";
            btn_nuevo2.Select();
        }

        private void btn_guardar2_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("¿ ESTA SEGURO DE ADICIONAR UN NUEVO CARGO ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                //
                if (!perBLL.insertaCargoPersonaUsuariosCargoBLL(txt_cod.Text, cargo1, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("SE ADICIONÓ CORRECTAMENTE EL CARGO !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //
                    dgw.Rows.Add(cargo1, cbo_cargo.Text);
                    //dgw1.CurrentRow.Cells["codc"].Value = cbo_cargo.SelectedItem.ToString().Substring(0, 2);
                    //dgw1.CurrentRow.Cells["cargo"].Value = cbo_cargo.SelectedItem.ToString().Substring(3, cbo_cargo.SelectedItem.ToString().Length - 3);
                    LIMPIAR_detalle();
                    Panel_v1.Visible = false;
                    Panel_v0.Visible = true;
                    btn_cancelar.Text = "&Salir";
                    btn_cancelar.Visible = true;
                    btn_nuevo2.Select();
                }
            }

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
                    //Limpiar();
                    if (dgw1.Rows.Count == 0)
                    {
                    }
                    else
                    {
                        LIMPIAR_CABECERA();
                        CARGAR_CABECERA();
                        LIMPIAR_detalle();
                    }
                    txt_cod.ReadOnly = true;
                    txt_desc.ReadOnly = true;
                    txt_NRO_DOC.ReadOnly = true;
                    btn_cancelar.Text = "&Cancelar";
                    btn_cancelar.Visible = true;
                    btn_cancelar.Select();
                }
            }
            else
                btn_modificar.Select();
        }

        private void cbo_cargo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_cargo.SelectedIndex > -1)
                COD_CARGO_VENTA();
        }
        private void COD_CARGO_VENTA()
        {
            cargo1 = perBLL.obtenerCodCargoVentaBLL(cbo_cargo.Text);
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txt_letra_TextChanged(object sender, EventArgs e)
        {
            int i;
            if (ch_cod.Checked)
            {
                txt_letra.Focus();
                for (i = 0; i < dgw.Rows.Count; i++)
                {
                    if (txt_letra.TextLength <= dgw[0, i].Value.ToString().Length)
                    {
                        if (txt_letra.Text.ToLower() == dgw[0, i].Value.ToString().Substring(0, txt_letra.TextLength).ToLower())
                        {
                            dgw.CurrentCell = dgw.Rows[i].Cells[0];
                            break;
                        }
                    }

                }
            }
            else if (ch_rs.Checked)
            {
                txt_letra.Focus();
                for (i = 0; i < dgw.Rows.Count; i++)
                {
                    if (txt_letra.TextLength <= dgw[1, i].Value.ToString().Length)
                    {
                        if (txt_letra.Text.ToLower() == dgw[1, i].Value.ToString().Substring(0, txt_letra.TextLength).ToLower())
                        {
                            dgw.CurrentCell = dgw.Rows[i].Cells[1];
                            break;
                        }
                    }
                }
            }
        }

        private void ch_cod_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_cod.Checked)
            {
                dgw.Sort(dgw.Columns[0], System.ComponentModel.ListSortDirection.Ascending);
                btn_buscar.Enabled = false;
                btn_sgt.Enabled = false;
                txt_letra.Clear();
                txt_letra.Focus();
            }
        }

        private void ch_rs_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_rs.Checked)
            {
                dgw.Sort(dgw.Columns[1], System.ComponentModel.ListSortDirection.Ascending);
                btn_buscar.Enabled = false;
                btn_sgt.Enabled = false;
                txt_letra.Clear();
                txt_letra.Focus();
            }
        }

        private void ch_ca_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_ca.Checked)
            {
                btn_buscar.Enabled = true;
                txt_letra.Clear();
                txt_letra.Focus();
            }
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            int i, f;
            txt_letra.Focus();
            btn_sgt.Enabled = true;
            for (i = 0; i < dgw.Rows.Count; i++)
            {
                for (f = 0; f <= dgw[1, i].Value.ToString().Length - txt_letra.TextLength; f++)
                {
                    if (txt_letra.TextLength <= dgw[1, i].Value.ToString().Length)
                    {
                        if (txt_letra.Text.ToLower() == dgw[1, i].Value.ToString().Substring(f, txt_letra.TextLength).ToLower())
                        {
                            dgw.CurrentCell = dgw.Rows[i].Cells[1];
                            fila = i + 1;
                            return;
                        }
                    }
                }
            }
        }

        private void btn_sgt_Click(object sender, EventArgs e)
        {
            int i, f;//antes de dar a siguiente primero se hace buscar para que lo ubique en la primera coincidencia luego se da siguiente, siguiente..., hasta encontrar el valor buscado.
            for (i = fila; i < dgw.Rows.Count; i++)
            {
                for (f = 0; f <= dgw[1, i].Value.ToString().Length - txt_letra.TextLength; f++)
                {
                    if (txt_letra.TextLength <= dgw[1, i].Value.ToString().Length)
                    {
                        if (txt_letra.Text.ToLower() == dgw[1, i].Value.ToString().Substring(f, txt_letra.TextLength).ToLower())
                        {
                            dgw.CurrentCell = dgw.Rows[i].Cells[1];
                            fila = i + 1;
                            return;
                        }
                    }
                }
            }
            MessageBox.Show("Ya no existen más registros !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void GroupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void TabPage3_Click(object sender, EventArgs e)
        {

        }
    }
}
