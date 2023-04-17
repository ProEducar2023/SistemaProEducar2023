using BLL;
using Entidades;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
namespace Presentacion.MOD_ADM
{
    public partial class EQUIPOS_DE_COBRANZA : Form
    {
        DataTable dtEqc, dtTipoDoc, dtPrgNiv;
        personaBLL perBLL = new personaBLL();
        string BOTON;
        int fila;
        DIALOGOS.frmListar frm = new DIALOGOS.frmListar();
        eq_vta_nivel_progBLL eqvBLL = new eq_vta_nivel_progBLL();
        eq_vta_nivel_progTo eqvTo = new eq_vta_nivel_progTo();
        public EQUIPOS_DE_COBRANZA()
        {
            InitializeComponent();
        }

        private void EQUIPOS_DE_COBRANZA_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            cargaGrid();
            cargaCombo();
            cargaComboPrograma();
            cargaComboNivel();
            cargaTipoPlanilla();
            btn_nuevo.Select();
        }
        private void cargaTipoPlanilla()
        {
            var planilla = new[] {  new { val = "DESCUENTO", cod = "P" },
                                    new { val = "DIRECTA", cod = "D" }};

            cbo_tipo_pla.ValueMember = "cod";
            cbo_tipo_pla.DisplayMember = "val";
            cbo_tipo_pla.DataSource = planilla;
            cbo_tipo_pla.SelectedIndex = -1;
        }
        private void EQUIPOS_DE_COBRANZA_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void cargaComboPrograma()
        {
            programaBLL progBLL = new programaBLL();
            DataTable dt = progBLL.obtenerProgramaBLL();
            cboprograma.ValueMember = "COD_PROGRAMA";
            cboprograma.DisplayMember = "DESC_PROGRAMA";
            cboprograma.DataSource = dt;
        }
        private void cargaComboNivel()
        {
            nivelBLL nivBLL = new nivelBLL();
            DataTable dt = nivBLL.obtenerNivelCobranzaBLL();
            cbonivel.ValueMember = "COD_NIVEL";
            cbonivel.DisplayMember = "DESC_NIVEL";
            cbonivel.DataSource = dt;
        }
        private void cargaGrid()
        {
            dtEqc = eqvBLL.obtenerEquipoCobBLL();
            if (dtEqc.Rows.Count > 0)
            {
                foreach (DataRow rw in dtEqc.Rows)
                {
                    int rowId = dgw.Rows.Add();
                    DataGridViewRow row = dgw.Rows[rowId];
                    row.Cells["cod"].Value = rw["COD_EQCOB"].ToString();
                    row.Cells["tipdoc"].Value = rw["TIP_DOC"].ToString();
                    row.Cells["nrodoc"].Value = rw["NRO_DOC"].ToString();
                    row.Cells["desc"].Value = rw["DESC_EQVTA"].ToString();
                    row.Cells["nom"].Value = rw["NOMBRE"].ToString();
                    row.Cells["app"].Value = rw["PATERNO"].ToString();
                    row.Cells["apm"].Value = rw["MATERNO"].ToString();
                    row.Cells["email"].Value = rw["MAIL"].ToString();
                    row.Cells["act"].Value = Convert.ToBoolean(rw["ACTIVO"]);
                }
            }
        }
        private void cargaCombo()
        {
            dtTipoDoc = perBLL.obtenerTipoDocBLL();
            if (dtTipoDoc.Rows.Count > 0)
            {
                cbo_tipo_doc.DisplayMember = "DESC_TIPO";
                cbo_tipo_doc.ValueMember = "COD_TIPO";
                cbo_tipo_doc.DataSource = dtTipoDoc;
            }
        }
        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            BOTON = "NUEVO";
            LIMPIAR_CABECERA();
            LIMPIAR_DETALLE2();
            //ch_act.Checked = true;
            btn_guardar.Visible = true;
            ch_act.Checked = false;
            btn_modificar2.Visible = false;
            btnBuscarPersona.Enabled = true;
            Panel2.Enabled = true;
            TabControl1.SelectedTab = TabPage2;
            txt_cod.Focus();
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
            //txtLogin.Clear();
            //txtCodUsuario.Clear();
            btn_cancelar.Visible = true;
        }
        private void LIMPIAR_DETALLE2()
        {
            DGW_DET.Rows.Clear();
        }
        private void CARGAR_CABECERA()
        {

            txt_cod.Text = dgw[0, dgw.CurrentRow.Index].Value.ToString();
            //cbo_tipo_doc.Text = perBLL.obte  //AQUI HAY QUE VER EL PROGRAMA QUE TRAE LAS PERSONAS DEBE TRAER EL CODIGO DEL TIPODOC SOLO TRAE LA DESCRIPCION 
            cbo_tipo_doc.SelectedValue = dgw[1, dgw.CurrentRow.Index].Value.ToString();
            txt_nro_doc.Text = dgw[2, dgw.CurrentRow.Index].Value.ToString();
            txt_desc.Text = dgw[3, dgw.CurrentRow.Index].Value.ToString();
            txt_nom.Text = dgw[4, dgw.CurrentRow.Index].Value.ToString();
            txt_pat.Text = dgw[5, dgw.CurrentRow.Index].Value.ToString();
            txt_mat.Text = dgw[6, dgw.CurrentRow.Index].Value.ToString();
            txt_mail.Text = dgw[7, dgw.CurrentRow.Index].Value.ToString();
            ch_act.Checked = Convert.ToBoolean(dgw[8, dgw.CurrentRow.Index].Value);

        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            if (dgw.Rows.Count <= 0)
                return;
            BOTON = "MODIFICAR";
            LIMPIAR_CABECERA();
            btn_guardar.Visible = false;
            btn_modificar2.Visible = true;
            btnBuscarPersona.Enabled = false;
            CARGAR_CABECERA();
            CARGAR_DETALLES();
            txt_cod.ReadOnly = true;
            BTN_GUARDAR2.Visible = false;
            BTN_MODIFICAR4.Visible = false;
            Panel2.Enabled = true;
            TabControl1.SelectedTab = TabPage2;
            cbo_tipo_doc.Select();
        }
        private void CARGAR_DETALLES()
        {
            progNivelBLL prniBLL = new progNivelBLL();
            progNivelTo prniTo = new progNivelTo();
            prniTo.COD_PER = txt_cod.Text;
            DGW_DET.Rows.Clear();
            dtPrgNiv = prniBLL.obtenerProgramaNivelporCodigoCobranzaBLL(prniTo);
            foreach (DataRow rw in dtPrgNiv.Rows)
            {
                int rowId = DGW_DET.Rows.Add();
                DataGridViewRow row = DGW_DET.Rows[rowId];
                row.Cells["codper"].Value = rw["COD_PER"].ToString();
                row.Cells["codp"].Value = rw["COD_PROGRAMA"].ToString();
                row.Cells["desp"].Value = rw["DESC_PROGRAMA"].ToString();
                row.Cells["codni"].Value = rw["COD_NIVEL"].ToString();
                row.Cells["desni"].Value = rw["DESC_NIVEL"].ToString();
                row.Cells["tip"].Value = rw["TIPO_PLANILLA"].ToString();
                row.Cells["actprogni"].Value = Convert.ToBoolean(rw["ACTIVIDAD"]);
            }
        }

        private void btnBuscarPersona_Click(object sender, EventArgs e)
        {
            frm.tipo = "EqCobranza";
            frm.CargarDatos();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                DataGridViewRow row = frm.dgw.CurrentRow;
                txt_cod.Text = row.Cells[0].Value.ToString();
                txt_desc.Text = row.Cells[1].Value.ToString();
                txt_pat.Text = row.Cells[2].Value.ToString();
                txt_mat.Text = row.Cells[3].Value.ToString();
                txt_nom.Text = row.Cells[4].Value.ToString();
                //cbo_tipo_doc.Text = row.Cells[5].Value.ToString();
                txt_nro_doc.Text = row.Cells[6].Value.ToString();
                txt_mail.Text = row.Cells[7].Value.ToString();
                cbo_tipo_doc.SelectedValue = row.Cells[8].Value.ToString();//COD_TIPO
            }
        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            DGW_DET.Visible = false;
            Panel1.Visible = true;
            BTN_GUARDAR2.Visible = true;
            BTN_MODIFICAR4.Visible = false;
            LIMPIAR_DETALLE1();
            btnBuscarPersona.Focus();
        }
        private void LIMPIAR_DETALLE1()
        {
            cbo_tipo_pla.SelectedIndex = -1;
            cboprograma.SelectedIndex = -1;
            cbonivel.SelectedIndex = -1;
            ch_actpn.Checked = false;
        }

        private void btn_modificar3_Click(object sender, EventArgs e)
        {
            BTN_GUARDAR2.Visible = false;
            BTN_MODIFICAR4.Visible = true;
            LIMPIAR_DETALLE1();
            CARGAR_DETALLES1();
            DGW_DET.Visible = false;
            Panel1.Visible = true;
        }
        private void CARGAR_DETALLES1()
        {
            int idx = DGW_DET.CurrentRow.Index;
            cboprograma.SelectedValue = DGW_DET[1, idx].Value;
            cbonivel.SelectedValue = DGW_DET[3, idx].Value;
            cbo_tipo_pla.SelectedValue = DGW_DET[5, idx].Value;
            ch_actpn.Checked = Convert.ToBoolean(DGW_DET[6, idx].Value);
        }

        private void btn_eliminar2_Click(object sender, EventArgs e)
        {
            if (DGW_DET.Rows.Count <= 0)
                return;
            DialogResult rs = MessageBox.Show("¿ Esta seguro de eliminar ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                DGW_DET.Rows.RemoveAt(DGW_DET.CurrentRow.Index);
            }
        }

        private void BTN_GUARDAR2_Click(object sender, EventArgs e)
        {
            if (!validaProgNiv())
                return;
            DGW_DET.Rows.Add(txt_cod.Text, cboprograma.SelectedValue.ToString(), cboprograma.Text, cbonivel.SelectedValue.ToString(), cbonivel.Text, cbo_tipo_pla.SelectedValue.ToString(), ch_actpn.Checked);
            Panel1.Visible = false;
            DGW_DET.Visible = true;
        }
        private bool validaProgNiv()
        {
            bool result = true;
            if (cbo_tipo_pla.SelectedIndex == -1)
            {
                MessageBox.Show("SELECCIONE EL TIPO !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_tipo_pla.Focus();
                return result = false;
            }
            if (cboprograma.SelectedIndex == -1)
            {
                MessageBox.Show("SELECCIONE UN PROGRAMA !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboprograma.Focus();
                return result = false;
            }
            if (cbonivel.SelectedIndex == -1)
            {
                MessageBox.Show("SELECCIONE UN NIVEL !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbonivel.Focus();
                return result = false;
            }
            var query = from DataGridViewRow row in DGW_DET.Rows
                        where (row.Cells["codp"].Value.ToString() == cboprograma.SelectedValue.ToString() && row.Cells["codni"].Value.ToString() == cbonivel.SelectedValue.ToString())
                        select row;
            if (query.Count() > 0)
            {
                MessageBox.Show("Ya existe Programa y Nivel !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_tipo_pla.Focus();
                return result = false;
            }
            return result;
        }

        private void BTN_MODIFICAR4_Click(object sender, EventArgs e)
        {
            if (!validaProgNiv())
                return;
            int idx = DGW_DET.CurrentRow.Index;
            DGW_DET[1, idx].Value = cboprograma.SelectedValue.ToString();
            DGW_DET[2, idx].Value = cboprograma.Text;
            DGW_DET[3, idx].Value = cbonivel.SelectedValue.ToString();
            DGW_DET[4, idx].Value = cbonivel.Text;
            DGW_DET[5, idx].Value = cbo_tipo_pla.SelectedValue.ToString();
            DGW_DET[6, idx].Value = ch_actpn.Checked;
            Panel1.Visible = false;
            DGW_DET.Visible = true;
        }

        private void btn_cancelar2_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            DGW_DET.Visible = true;
        }
        private bool validaGuardarModificar()
        {
            bool result = true;
            if (txt_cod.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el codigo !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_cod.Focus();
                return result = false;
            }
            if (DGW_DET.Rows.Count <= 0)
            {
                MessageBox.Show("Elija el programa y el nivel !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboprograma.Focus();
                return result = false;
            }
            if (btn_guardar.Visible == true)
            {
                var query = from DataGridViewRow row in dgw.Rows
                            where row.Cells["cod"].Value.ToString() == txt_cod.Text
                            select row;
                if (query.Count() > 0)
                {
                    MessageBox.Show("Ya existe el agente cobrador !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txt_cod.Focus();
                    return result = false;
                }
            }
            return result;
        }
        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (!validaGuardarModificar())
                return;
            DialogResult rs = MessageBox.Show("¿ Esta seguro de adicionar una nueva persona para el el Eq de Cobranza ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                //string tipo_doc = perBLL.obtenerCodTipoDocBLL(cbo_tipo_doc.Text);
                eqvTo.COD_EQVTA = txt_cod.Text;
                eqvTo.TIP_DOC = cbo_tipo_doc.SelectedValue.ToString();
                eqvTo.NRO_DOC = txt_nro_doc.Text;
                eqvTo.DESC_EQVTA = txt_desc.Text;
                eqvTo.NOMBRE = txt_nom.Text;
                eqvTo.PATERNO = txt_pat.Text;
                eqvTo.MATERNO = txt_mat.Text;
                eqvTo.MAIL = txt_mail.Text;
                eqvTo.ACTIVO = ch_act.Checked;
                dtPrgNiv = obtieneDTProgNiv();
                if (!eqvBLL.adicionaEqCobranzaProgNivBLL(eqvTo, dtPrgNiv, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Se adiciono correctamente la persona !!!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //
                    dgw.Rows.Add(txt_cod.Text, cbo_tipo_doc.SelectedValue.ToString(), txt_nro_doc.Text, txt_desc.Text, txt_nom.Text, txt_pat.Text, txt_mat.Text, txt_mail.Text, ch_act.Checked);
                    TabControl1.SelectedTab = TabPage1;
                    btn_nuevo.Select();
                }
            }
        }
        private DataTable obtieneDTProgNiv()
        {
            DataTable table = new DataTable();
            foreach (DataGridViewColumn column in DGW_DET.Columns)
            {
                table.Columns.Add(column.Name, typeof(string));
            }
            foreach (DataGridViewRow row in DGW_DET.Rows)
            {
                DataRow dataRow = table.NewRow();
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    dataRow[i] = row.Cells[i].Value != null ? row.Cells[i].Value : DBNull.Value;
                }
                table.Rows.Add(dataRow);
            }
            return table;
        }
        private void btn_modificar2_Click(object sender, EventArgs e)
        {
            if (!validaGuardarModificar())
                return;
            DialogResult rs = MessageBox.Show("¿ Esta seguro de modificar la persona ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                //string tipo_doc = perBLL.obtenerCodTipoDocBLL(cbo_tipo_doc.Text);
                eqvTo.COD_EQVTA = txt_cod.Text;
                eqvTo.TIP_DOC = cbo_tipo_doc.SelectedValue.ToString();
                eqvTo.NRO_DOC = txt_nro_doc.Text;
                eqvTo.DESC_EQVTA = txt_desc.Text;
                eqvTo.NOMBRE = txt_nom.Text;
                eqvTo.PATERNO = txt_pat.Text;
                eqvTo.MATERNO = txt_mat.Text;
                eqvTo.MAIL = txt_mail.Text;
                eqvTo.ACTIVO = ch_act.Checked;
                dtPrgNiv = obtieneDTProgNiv();
                if (!eqvBLL.modificaActualizaEqCobranzaProgNivBLL(eqvTo, dtPrgNiv, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Se modificò correctamene la persona !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //
                    int idx = dgw.CurrentRow.Index;
                    dgw[0, idx].Value = txt_cod.Text;
                    dgw[1, idx].Value = cbo_tipo_doc.SelectedValue.ToString();
                    dgw[2, idx].Value = txt_nro_doc.Text;
                    dgw[3, idx].Value = txt_desc.Text;
                    dgw[4, idx].Value = txt_nom.Text;
                    dgw[5, idx].Value = txt_pat.Text;
                    dgw[6, idx].Value = txt_mat.Text;
                    dgw[7, idx].Value = txt_mail.Text;
                    dgw[8, idx].Value = ch_act.Checked;
                    TabControl1.SelectedTab = TabPage1;
                    btn_nuevo.Select();
                }
            }
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            TabControl1.SelectedTab = TabPage1;
            btn_nuevo.Select();
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
            else if (ch_rs.Checked)
            {
                txt_letra.Focus();
                for (i = 0; i < dgw.Rows.Count; i++)
                {
                    if (txt_letra.TextLength <= dgw[3, i].Value.ToString().Length)
                    {
                        if (txt_letra.Text.ToLower() == dgw[3, i].Value.ToString().Substring(0, txt_letra.TextLength).ToLower())
                        {
                            dgw.CurrentCell = dgw.Rows[i].Cells[3];
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
                dgw.Sort(dgw.Columns[2], System.ComponentModel.ListSortDirection.Ascending);
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
                dgw.Sort(dgw.Columns[3], System.ComponentModel.ListSortDirection.Ascending);
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
                for (f = 0; f <= dgw[3, i].Value.ToString().Length - txt_letra.TextLength; f++)
                {
                    if (txt_letra.TextLength <= dgw[3, i].Value.ToString().Length)
                    {
                        if (txt_letra.Text.ToLower() == dgw[3, i].Value.ToString().Substring(f, txt_letra.TextLength).ToLower())
                        {
                            dgw.CurrentCell = dgw.Rows[i].Cells[3];
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
                for (f = 0; f <= dgw[3, i].Value.ToString().Length - txt_letra.TextLength; f++)
                {
                    if (txt_letra.TextLength <= dgw[3, i].Value.ToString().Length)
                    {
                        if (txt_letra.Text.ToLower() == dgw[3, i].Value.ToString().Substring(f, txt_letra.TextLength).ToLower())
                        {
                            dgw.CurrentCell = dgw.Rows[i].Cells[3];
                            fila = i + 1;
                            return;
                        }
                    }
                }
            }
            MessageBox.Show("Ya no existen más registros !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (dgw.Rows.Count <= 0)
                return;
            DialogResult rs = MessageBox.Show("¿ Esta seguro de eliminar el Personal de Cobranza ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                eqvTo.COD_EQVTA = dgw.CurrentRow.Cells[0].Value.ToString();


                if (!eqvBLL.eliminaEqCobranzaProgNivBLL(eqvTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("El Personal de Cobranza se eliminó correctamente", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgw.Rows.RemoveAt(dgw.CurrentRow.Index);
                    btn_nuevo.Select();
                }
            }
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
                    LIMPIAR_DETALLE2();
                    if (dgw.Rows.Count == 0)
                    { }
                    else
                    {
                        CARGAR_CABECERA();
                        CARGAR_DETALLES();
                    }
                    Panel1.Visible = false;
                    Panel2.Visible = true;
                    Panel2.Enabled = false;
                    btn_guardar.Visible = false;
                    btn_modificar2.Visible = false;
                    btnBuscarPersona.Enabled = false;
                }
            }
            else
                btn_nuevo.Select();
        }
    }
}
