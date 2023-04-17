using BLL;
using System;
using System.Data;
using System.Windows.Forms;
namespace Presentacion.MOD_ADM
{
    public partial class PERSONA_VENTA : Form
    {
        string BOTON; DataTable dtMaestroPersona, dtTipoDoc;
        DIALOGOS.frmListar frm = new DIALOGOS.frmListar();
        personaBLL perBLL = new personaBLL();
        int fila;
        public PERSONA_VENTA()
        {
            InitializeComponent();
        }

        private void PERSONA_VENTA_Load(object sender, EventArgs e)
        {
            KeyPreview = true;

            cargaGrid();
            cargaCombo();
            btn_nuevo.Select();
        }
        private void cargaGrid()
        {
            dtMaestroPersona = perBLL.obtenerPersonaUsuariosCargoBLL();
            if (dtMaestroPersona.Rows.Count > 0)
            {
                foreach (DataRow rw in dtMaestroPersona.Rows)
                {
                    int rowId = dgw.Rows.Add();
                    DataGridViewRow row = dgw.Rows[rowId];
                    row.Cells["cod"].Value = rw["Codigo"].ToString();
                    row.Cells["desc"].Value = rw["Nombre"].ToString();
                    row.Cells["nrodoc"].Value = rw["Nroº Doc."].ToString();
                    row.Cells["nom"].Value = rw["NOMBRE"].ToString();
                    row.Cells["app"].Value = rw["PATERNO"].ToString();
                    row.Cells["apm"].Value = rw["MATERNO"].ToString();
                    row.Cells["login"].Value = "";
                    row.Cells["email"].Value = rw["MAIL"].ToString();
                    row.Cells["tipdoc"].Value = rw[6].ToString();
                }
            }
        }
        private void cargaCombo()
        {
            dtTipoDoc = perBLL.obtenerTipoDocBLL();
            cbo_tipo_doc.DisplayMember = "DESC_TIPO";
            cbo_tipo_doc.ValueMember = "COD_TIPO";
            cbo_tipo_doc.DataSource = dtTipoDoc;
        }
        private void PERSONA_VENTA_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void LIMPIAR_CABECERA()
        {
            txt_cod.Clear();
            txt_desc.Clear();
            txt_nom.Clear();
            txt_pat.Clear();
            txt_mat.Clear();
            txt_nro_doc.Clear();
            txt_mail.Clear();
            cbo_tipo_doc.SelectedIndex = -1;
            txtLogin.Clear();
            txtCodUsuario.Clear();
            btn_cancelar.Visible = true;
        }
        private void CARGAR_CABECERA()
        {
            if (dgw.Rows.Count > 0)
            {
                txt_cod.Text = dgw[0, dgw.CurrentRow.Index].Value.ToString();
                txt_desc.Text = dgw[1, dgw.CurrentRow.Index].Value.ToString();
                txt_nro_doc.Text = dgw[2, dgw.CurrentRow.Index].Value.ToString();
                txt_nom.Text = dgw[3, dgw.CurrentRow.Index].Value.ToString();
                txt_pat.Text = dgw[4, dgw.CurrentRow.Index].Value.ToString();
                txt_mat.Text = dgw[5, dgw.CurrentRow.Index].Value.ToString();
                //TIPO_DOC = dgw[6, dgw.CurrentRow.Index].Value.ToString();
                txtLogin.Text = dgw[6, dgw.CurrentRow.Index].Value.ToString();
                txt_mail.Text = dgw[7, dgw.CurrentRow.Index].Value.ToString();
                cbo_tipo_doc.SelectedValue = dgw[8, dgw.CurrentRow.Index].Value.ToString();
                //txtCodUsuario.Text = dgw[9, dgw.CurrentRow.Index].Value.ToString();
            }
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            BOTON = "NUEVO";
            LIMPIAR_CABECERA();
            btn_guardar.Visible = true;
            btn_modificar2.Visible = false;
            btnBuscarPersona.Enabled = true;
            TabControl1.SelectedTab = TabPage2;
            txt_cod.Focus();
        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            BOTON = "MODIFICAR";
            LIMPIAR_CABECERA();
            btn_guardar.Visible = false;
            btn_modificar2.Visible = true;
            btnBuscarPersona.Enabled = false;
            CARGAR_CABECERA();
            txt_cod.ReadOnly = true;
            TabControl1.SelectedTab = TabPage2;
            cbo_tipo_doc.Select();
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (dgw.Rows.Count <= 0)
                return;
            DialogResult rs = MessageBox.Show("¿ Esta seguro de eliminar este Usuario ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                //
                if (!perBLL.eliminaPersonaUsuariosBLL(dgw.CurrentRow.Cells["cod"].Value.ToString(), ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Se elimino correctamente el Usuario !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //
                    dgw.Rows.RemoveAt(dgw.CurrentRow.Index);
                    btn_nuevo.Select();
                }
            }

        }
        private void btn_guardar_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("¿ Esta seguro de adicionar un nuevo Usuario ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                //
                //string tipo_doc = perBLL.obtenerCodTipoDocBLL(cbo_tipo_doc.Text);
                if (!perBLL.insertaPersonaUsuariosCargoBLL(txt_cod.Text, txt_desc.Text, txt_nom.Text, txt_pat.Text, txt_mat.Text,
                    cbo_tipo_doc.SelectedValue.ToString(), txt_nro_doc.Text, txt_mail.Text, txtCodUsuario.Text, txtLogin.Text, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("SE adiciono correctamente el Usuario !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //
                    dgw.Rows.Add(txt_cod.Text, txt_nro_doc.Text, txt_desc.Text, txt_nom.Text, txt_pat.Text, txt_mat.Text, txtLogin.Text, txt_mail.Text, cbo_tipo_doc.SelectedValue.ToString());
                    //LIMPIAR_CABECERA();
                    //txt_cod.Focus();
                    TabControl1.SelectedTab = TabPage1;
                    btn_nuevo.Select();
                }
            }

        }

        private void btn_modificar2_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("¿ Esta seguro de Modificar el Usuario ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                //string tipo_doc = perBLL.obtenerCodTipoDocBLL(cbo_tipo_doc.Text);
                if (!perBLL.modificaPersonaUsuariosCargoBLL(txt_cod.Text, txt_desc.Text, txt_nom.Text, txt_pat.Text, txt_mat.Text,
                    cbo_tipo_doc.SelectedValue.ToString(), txt_nro_doc.Text, txt_mail.Text, txtCodUsuario.Text, txtLogin.Text, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Se modifico correctamente el Usuario !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //
                    dgw.CurrentRow.Cells["cod"].Value = txt_cod.Text;
                    dgw.CurrentRow.Cells["desc"].Value = txt_desc.Text;
                    dgw.CurrentRow.Cells["nrodoc"].Value = txt_nro_doc.Text;
                    dgw.CurrentRow.Cells["nom"].Value = txt_nom.Text;
                    dgw.CurrentRow.Cells["app"].Value = txt_pat.Text;
                    dgw.CurrentRow.Cells["apm"].Value = txt_mat.Text;
                    dgw.CurrentRow.Cells["login"].Value = txtLogin.Text;
                    dgw.CurrentRow.Cells["email"].Value = txt_mail.Text;
                    dgw.CurrentRow.Cells["tipdoc"].Value = cbo_tipo_doc.SelectedValue.ToString();
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

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TabControl1.SelectedTab == TabPage2)
            {
                if (BOTON == "NUEVO")
                {
                    BOTON = "DETALLES1";
                }
                else if (BOTON == "MODIFICAR")
                {
                    BOTON = "DETALLES2";
                }
                else
                {
                    BOTON = "DETALLES";
                    LIMPIAR_CABECERA();
                    CARGAR_CABECERA();
                    btn_guardar.Visible = false;
                    btn_modificar2.Visible = false;
                    txt_cod.ReadOnly = true;
                    txt_desc.ReadOnly = true;
                    txt_nom.ReadOnly = true;
                    txt_pat.ReadOnly = true;
                    txt_mat.ReadOnly = true;
                    txt_nro_doc.ReadOnly = true;
                    txt_mail.ReadOnly = true;
                    cbo_tipo_doc.Enabled = false;
                }
            }
            //else
            //    btn_nuevo.Select(); 
        }

        private void btnBuscarPersona_Click(object sender, EventArgs e)
        {
            //DIALOGOS.frmListar frm = new DIALOGOS.frmListar();
            frm.tipo = "Personal";
            frm.CargarDatos();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                DataGridViewRow row = frm.dgw.CurrentRow;
                txt_cod.Text = row.Cells[0].Value.ToString();
                txt_desc.Text = row.Cells[1].Value.ToString();
                txt_pat.Text = row.Cells[2].Value.ToString();
                txt_mat.Text = row.Cells[3].Value.ToString();
                txt_nom.Text = row.Cells[4].Value.ToString();
                cbo_tipo_doc.Text = row.Cells[5].Value.ToString();
                txt_nro_doc.Text = row.Cells[6].Value.ToString();
                txt_mail.Text = row.Cells[7].Value.ToString();
                cbo_tipo_doc.SelectedValue = row.Cells[8].Value.ToString();
            }
        }

        private void btnBuscarUsuario_Click(object sender, EventArgs e)
        {
            //DIALOGOS.frmListar frm = new DIALOGOS.frmListar();
            frm.tipo = "Usuarios";
            frm.CargarDatos();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                DataGridViewRow row = frm.dgw.CurrentRow;
                txtLogin.Text = row.Cells[4].Value.ToString();

            }
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
            else if (ch_dni.Checked)
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
            else if (ch_rs.Checked)
            {
                txt_letra.Focus();
                for (i = 0; i < dgw.Rows.Count; i++)
                {
                    if (txt_letra.TextLength <= dgw[2, i].Value.ToString().Length)
                    {
                        if (txt_letra.Text.ToLower() == dgw[2, i].Value.ToString().Substring(0, txt_letra.TextLength).ToLower())
                        {
                            dgw.CurrentCell = dgw.Rows[i].Cells[2];
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

        private void ch_dni_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_dni.Checked)
            {
                dgw.Sort(dgw.Columns[1], System.ComponentModel.ListSortDirection.Ascending);
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
                dgw.Sort(dgw.Columns[2], System.ComponentModel.ListSortDirection.Ascending);
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
                for (f = 0; f <= dgw[2, i].Value.ToString().Length - txt_letra.TextLength; f++)
                {
                    if (txt_letra.TextLength <= dgw[2, i].Value.ToString().Length)
                    {
                        if (txt_letra.Text.ToLower() == dgw[2, i].Value.ToString().Substring(f, txt_letra.TextLength).ToLower())
                        {
                            dgw.CurrentCell = dgw.Rows[i].Cells[2];
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
                for (f = 0; f <= dgw[2, i].Value.ToString().Length - txt_letra.TextLength; f++)
                {
                    if (txt_letra.TextLength <= dgw[2, i].Value.ToString().Length)
                    {
                        if (txt_letra.Text.ToLower() == dgw[2, i].Value.ToString().Substring(f, txt_letra.TextLength).ToLower())
                        {
                            dgw.CurrentCell = dgw.Rows[i].Cells[2];
                            fila = i + 1;
                            return;
                        }
                    }
                }
            }
            MessageBox.Show("Ya no existen más registros !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
