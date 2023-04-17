using BLL;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;
namespace Presentacion.MOD_ADM
{
    public partial class KIT : Form
    {
        string boton, UM;
        DataTable dtKit;
        kitBLL kiBLL = new kitBLL();
        kitTo kiTo = new kitTo();
        DateTime fec_actualizacion;
        string estado = "0";
        DataTable dtPKit;
        public KIT()
        {
            InitializeComponent();
        }

        private void KIT_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            //CARGAR_PRODUCTOS();
            //CARGAR_TIPO_VENTA();
            cargaGrid();
            llenaComboClase();
            dtp_desde.Value = DateTime.Now.AddDays(-30);
            dtp_hasta.Value = DateTime.Now;
            btn_nuevo.Select();
        }
        //public void CARGAR_TIPO_VENTA()
        //{
        //    tipoVentaBLL tvBLL = new tipoVentaBLL();
        //    DataTable dt = tvBLL.obtenerTipoVentaBLL();
        //    cbo_tipo_venta.ValueMember = "COD_TIPO_VENTA";
        //    cbo_tipo_venta.DisplayMember = "DESC_TIPO_VENTA";
        //    cbo_tipo_venta.DataSource = dt;
        //    cbo_tipo_venta.SelectedIndex = -1;
        //}
        private void CARGAR_PRODUCTOS()
        {
            articulosBLL artBLL = new articulosBLL();
            articulosTo artTo = new articulosTo();
            artTo.COD_CLASE = cbo_clase.SelectedValue.ToString();
            artTo.COD_GRUPO = cbo_grupo.SelectedValue.ToString();
            DataTable dtP = artBLL.obtenerArticulosparaKitBLL(artTo);
            if (dtP.Rows.Count > 0)
            {
                DGW_PRO.DataSource = dtP;
                //DGW_PRO.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8, FontStyle.Bold);
                DGW_PRO.Columns[0].Width = 50;
                DGW_PRO.Columns[1].Width = 180;
                DGW_PRO.Columns[2].Width = 80;
                DGW_PRO.Columns[3].Width = 50;
            }
            //DGW_PRO.DataSource = dtP;
        }
        private void cargaGrid()
        {
            dtKit = kiBLL.obtenerKitBLL();
            if (dtKit.Rows.Count > 0)
            {
                foreach (DataRow rw in dtKit.Rows)
                {
                    int rowId = dgw1.Rows.Add();
                    DataGridViewRow row = dgw1.Rows[rowId];
                    row.Cells["codkit"].Value = rw["Cod"];
                    row.Cells["deskit"].Value = rw["Descripción"];
                    row.Cells["COD_CLASE"].Value = rw["COD_CLASE"];
                    row.Cells["COD_GRUPO"].Value = rw["COD_GRUPO"];
                }
            }
        }
        private void KIT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void Limpiar()
        {
            txt_cod.Text = "";
            txt_desc.Text = "";
            dgw.Rows.Clear();
            TXT_COD_PRO.Text = "";
            TXT_DESC_PRO.Text = "";
            txt_nro_parte.Text = "";
            txt_cantidad.Text = "";
            txt_precio.Text = "";
            chk_sus.Checked = false;
            chk_val_ref.Checked = false;
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            boton = "NUEVO";
            LIMPIAR_CABECERA();
            LIMPIAR_detalle();
            txt_cod.Text = dgw1.Rows.Count == 0 ? "01" : obtieneCodigo(Convert.ToInt32(dgw1.Rows[dgw1.Rows.Count - 1].Cells["codkit"].Value));
            btn_guardar.Visible = true;
            btn_mod.Visible = false;
            btn_cancelar.Visible = true;
            btn_cancelar.Text = "&Cancelar";
            txt_cod.ReadOnly = false;
            TabControl1.SelectedTab = TabPage2;
            Panel1.Visible = true;
            Panel2.Visible = false;
            grDatosKit.Enabled = true;
            grControles.Enabled = true;
            btn_mod.Enabled = true;
            txt_cod.Focus();
        }
        private string obtieneCodigo(int it)
        {
            string ite = (it + 1).ToString();
            return ite.PadLeft(2, '0');
        }
        private void btn_modificar_Click(object sender, EventArgs e)
        {
            if (dgw1.Rows.Count <= 0)
                return;
            boton = "MODIFICAR";
            LIMPIAR_CABECERA();
            btn_guardar.Visible = false;
            btn_mod.Visible = true;
            btn_cancelar.Visible = true;
            btn_cancelar.Text = "&Cancelar";
            CARGAR_CABECERA();
            CARGAR_DETALLES();
            TabControl1.SelectedTab = TabPage2;
            Panel1.Visible = true;
            //panelito2.Visible = false;
            Panel2.Visible = false;
            //GroupBox5.Visible = false;
            //Panel_PRO.Visible = false;
            txt_cod.ReadOnly = true;
            grDatosKit.Enabled = true;
            grControles.Enabled = true;
            btn_mod.Enabled = true;
            txt_desc.Focus();
        }
        private void CARGAR_CABECERA()
        {
            txt_cod.Text = dgw1[0, dgw1.CurrentRow.Index].Value.ToString();
            txt_desc.Text = dgw1[1, dgw1.CurrentRow.Index].Value.ToString();
            cbo_clase.SelectedValue = dgw1.CurrentRow.Cells["COD_CLASE"].Value.ToString();
            cbo_grupo.SelectedValue = dgw1.CurrentRow.Cells["COD_GRUPO"].Value.ToString();
            dgw.Rows.Clear();
            //dgw.Rows.Add(dgw1[2, dgw1.CurrentRow.Index].Value.ToString(),dgw1[3, dgw1.CurrentRow.Index].Value.ToString(),"","", dgw1[4, dgw1.CurrentRow.Index].Value.ToString(), dgw1[5, dgw1.CurrentRow.Index].Value.ToString());

        }
        private void CARGAR_DETALLES()
        {
            kitDetalleBLL dkiBLL = new kitDetalleBLL();
            kitDetalleTo dkiTo = new kitDetalleTo();
            dkiTo.COD_KIT = dgw1.CurrentRow.Cells["codkit"].Value.ToString();
            dtPKit = dkiBLL.obtenerKitDetalleporCodKitBLL(dkiTo);
            dgw.Rows.Clear();
            foreach (DataRow rw in dtPKit.Rows)
            {
                int rowId = dgw.Rows.Add();
                DataGridViewRow row = dgw.Rows[rowId];
                row.Cells[0].Value = rw["COD_ARTICULO"].ToString();
                row.Cells[1].Value = rw["DESC_ARTICULO"].ToString();
                row.Cells[2].Value = rw["NRO_PARTE"].ToString();
                row.Cells[3].Value = rw["UNIDAD_MEDIDA"].ToString();
                row.Cells[4].Value = rw["CANTIDAD"];
                row.Cells[5].Value = rw["PRECIO_UNITARIO"];
                row.Cells[6].Value = Convert.ToBoolean(rw["ST_VALOR_REFERENCIAL"]);
                row.Cells[7].Value = string.Format("{0:dd/MM/yyyy}", rw["FEC_ACTUALIZACION"]);
                row.Cells[8].Value = Convert.ToBoolean(rw["ST_SUSPENDIDO"]);
            }
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
            if (txt_desc.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese la descripcion !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_desc.Focus();
                return result = false;
            }
            //if (cbo_tipo_venta.SelectedIndex < 0)
            //{
            //    MessageBox.Show("Elija el Tipo de Venta !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    cbo_tipo_venta.Focus();
            //    return result = false;
            //}
            if (dgw.Rows.Count <= 0)
            {
                MessageBox.Show("Ingrese articulos en el detalle !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btn_nuevo2.Focus();
                return result = false;
            }
            return result;
        }
        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (!validaGuardarModificar())
                return;
            DialogResult rs = MessageBox.Show("¿ Esta seguro de adicionar un nuevo Kit ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                kiTo.COD_KIT = txt_cod.Text;
                kiTo.DESC_KIT = txt_desc.Text;
                kiTo.COD_CLASE = cbo_clase.SelectedValue.ToString();
                kiTo.COD_GRUPO = cbo_grupo.SelectedValue.ToString();
                kiTo.FEC_ACTUALIZACION = fec_actualizacion;
                //kiTo.ESTADO = btn_guardar2.Visible ? "1" : "0";
                dtPKit = obtieneDTPKit();

                if (!kiBLL.adicionaKitBLL(kiTo, dtPKit, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show(" Se adicionó correctamente el Kit !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //
                    dgw1.Rows.Add(txt_cod.Text, txt_desc.Text, cbo_clase.SelectedValue.ToString(), cbo_grupo.SelectedValue.ToString(), "", "");//, dgw[0, dgw.CurrentRow.Index].Value.ToString(), dgw[1, dgw.CurrentRow.Index].Value.ToString(), dgw[4, dgw.CurrentRow.Index].Value.ToString(), dgw[5, dgw.CurrentRow.Index].Value.ToString());
                    LIMPIAR_CABECERA();
                    LIMPIAR_detalle();
                    TabControl1.SelectedTab = TabPage1;
                    btn_nuevo.Select();
                }
            }

        }
        public DataTable obtieneDTPKit()
        {
            DataTable table = new DataTable();
            foreach (DataGridViewColumn column in dgw.Columns)
            {
                table.Columns.Add(column.Name, typeof(string));
            }
            foreach (DataGridViewRow row in dgw.Rows)
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
        private void LIMPIAR_CABECERA()
        {
            txt_cod.Clear();
            txt_desc.Clear();
            cbo_clase.SelectedIndex = 0;
            cbo_grupo.SelectedIndex = -1;
            txt_cod.ReadOnly = true;
            txt_desc.ReadOnly = false;
            btn_mod.Visible = true;
            btn_guardar.Visible = true;
            btn_cancelar.Visible = true;
            //Panel1.Enabled = true;
            dgw.Rows.Clear();
        }
        private void btn_mod_Click(object sender, EventArgs e)
        {
            if (!validaGuardarModificar())
                return;
            DialogResult rs = MessageBox.Show("¿ ESTA SEGURO DE MODIFICAR EL KIT ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                //string tipo_doc = perBLL.obtenerCodTipoDocBLL(cbo_tipo_doc.Text);
                kiTo.COD_KIT = txt_cod.Text;
                kiTo.DESC_KIT = txt_desc.Text;
                kiTo.COD_CLASE = cbo_clase.SelectedValue.ToString();
                kiTo.COD_GRUPO = cbo_grupo.SelectedValue.ToString();
                kiTo.FEC_ACTUALIZACION = fec_actualizacion;
                //kiTo.ESTADO = btn_guardar2.Visible ? "1" : "0";//o sea si se va ingresar un nuevo articulo
                dtPKit = obtieneDTPKit();
                if (!kiBLL.actualizaModificaKitBLL(kiTo, dtPKit, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("SE MODIFICÓ CORRECTAMENTE EL KIT !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //
                    dgw1.CurrentRow.Cells["codkit"].Value = txt_cod.Text;
                    dgw1.CurrentRow.Cells["deskit"].Value = txt_desc.Text;
                    dgw1.CurrentRow.Cells["COD_CLASE"].Value = cbo_clase.SelectedValue.ToString();
                    dgw1.CurrentRow.Cells["COD_GRUPO"].Value = cbo_grupo.SelectedValue.ToString();

                    LIMPIAR_CABECERA();
                    LIMPIAR_detalle();
                    TabControl1.SelectedTab = TabPage1;

                    btn_nuevo.Select();
                }
            }

        }
        private void btn_modificar2_Click(object sender, EventArgs e)
        {
            int FILA = Convert.ToInt32(item1.Text);
            dgw[0, FILA].Value = TXT_COD_PRO.Text;
            dgw[1, FILA].Value = TXT_DESC_PRO.Text;
            dgw[2, FILA].Value = txt_nro_parte.Text;
            //dgw[3, FILA].Value = UM;
            dgw[4, FILA].Value = txt_cantidad.Text;
            dgw[5, FILA].Value = txt_precio.Text;
            dgw[6, FILA].Value = chk_val_ref.Checked;
            dgw[7, FILA].Value = dtp_fec_act.Value.ToShortDateString();
            dgw[8, FILA].Value = chk_sus.Checked;

            LIMPIAR_detalle();
            //panelito2.Visible = false;
            Panel2.Visible = false;
            //GroupBox5.Visible = false;
            //Panel_PRO.Visible = false;
            Panel1.Visible = true;
            btn_nuevo2.Select();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            TabControl1.SelectedTab = TabPage1;
            btn_nuevo.Select();
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (dgw1.Rows.Count <= 0)
                return;
            DialogResult rs = MessageBox.Show("¿ ESTA SEGURO DE ELIMINAR EL KIT Y SU DETALLE ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                kiTo.COD_KIT = dgw1[0, dgw1.CurrentRow.Index].Value.ToString();
                if (!kiBLL.eliminaKitCompletoBLL(kiTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("SE ELIMINÓ CORRECTAMENTE EL KIT Y SU DETALLE !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //
                    dgw1.Rows.RemoveAt(dgw1.CurrentRow.Index);
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
                    Limpiar();
                    if (dgw1.Rows.Count == 0)
                    { }
                    else
                    {
                        CARGAR_CABECERA();
                        CARGAR_DETALLES();
                    }
                    Panel1.Visible = true;
                    Panel2.Visible = false;
                    btn_guardar.Visible = false;
                    btn_modificar2.Visible = false;
                    grDatosKit.Enabled = false;
                    grControles.Enabled = false;
                    btn_mod.Enabled = false;
                }
            }
            else
                btn_nuevo.Select();
        }

        private void btn_nuevo2_Click(object sender, EventArgs e)
        {
            LIMPIAR_detalle();
            btn_guardar2.Visible = true;
            btn_modificar2.Visible = false;
            Panel1.Visible = true;
            //TXT_COD_PRO.Focus();
            Panel1.SendToBack();
            Panel2.BringToFront();
            Panel2.Visible = true;
            kiTo.ESTADO = "1";
            TXT_COD_PRO.Focus();
        }

        private void LIMPIAR_DETALLE()
        {
            TXT_COD_PRO.Text = "";
            TXT_DESC_PRO.Text = "";
            txt_nro_parte.Text = "";
            txt_cantidad.Text = "";
            txt_precio.Text = "";
            chk_sus.Checked = false;
            chk_val_ref.Checked = false;
        }

        private void btn_mod2_Click(object sender, EventArgs e)
        {
            LIMPIAR_detalle();
            btn_guardar2.Visible = false;
            btn_modificar2.Visible = true;
            item1.Text = dgw.CurrentRow.Index.ToString();
            Panel1.Visible = true;
            Panel1.SendToBack();
            Panel2.BringToFront();
            Panel2.Visible = true;
            CARGAR_detalle();
            TXT_COD_PRO.ReadOnly = true;
            TXT_DESC_PRO.ReadOnly = true;
            txt_nro_parte.ReadOnly = true;
            kiTo.ESTADO = "0";
            txt_cantidad.Focus();
        }
        private void LIMPIAR_detalle()
        {
            TXT_COD_PRO.Clear();
            TXT_DESC_PRO.Clear();
            txt_nro_parte.Clear();
            txt_cantidad.Clear();
            txt_precio.Clear();
            chk_sus.Checked = false;
            chk_val_ref.Checked = false;
            btn_modificar2.Visible = true;
            btn_guardar2.Visible = true;
            btn_cancelar2.Visible = true;
            TXT_COD_PRO.ReadOnly = false;
            TXT_DESC_PRO.ReadOnly = false;
            txt_nro_parte.ReadOnly = false;
            txt_cantidad.ReadOnly = false;
            txt_precio.ReadOnly = false;
            chk_sus.Enabled = true;
            chk_val_ref.Enabled = true;
        }
        private void CARGAR_detalle()
        {
            TXT_COD_PRO.Text = dgw[0, dgw.CurrentRow.Index].Value.ToString();
            TXT_DESC_PRO.Text = dgw[1, dgw.CurrentRow.Index].Value.ToString();
            //txt_nro_parte.Text = dgw[2, dgw.CurrentRow.Index].Value.ToString();
            //UM = dgw.Item(3, dgw.CurrentRow.Index).Value.ToString();
            txt_cantidad.Text = dgw[4, dgw.CurrentRow.Index].Value.ToString();
            //txt_cantidad.Text = obj.PRECIO_UNITARIO(txt_cantidad.Text();
            txt_precio.Text = dgw[5, dgw.CurrentRow.Index].Value.ToString();
            //txt_precio.Text = obj.PRECIO_UNITARIO(txt_precio.Text)
            chk_val_ref.Checked = Convert.ToBoolean(dgw[6, dgw.CurrentRow.Index].Value);
            dtp_fec_act.Value = Convert.ToDateTime(dgw[7, dgw.CurrentRow.Index].Value);
            chk_sus.Checked = Convert.ToBoolean(dgw[8, dgw.CurrentRow.Index].Value);

        }

        private void btn_guardar2_Click(object sender, EventArgs e)
        {
            dgw.Rows.Add(TXT_COD_PRO.Text, TXT_DESC_PRO.Text, "", "", txt_cantidad.Text, txt_precio.Text, chk_val_ref.Checked, dtp_fec_act.Value.ToShortDateString(), chk_sus.Checked);
            LIMPIAR_detalle();
            //panelito2.Visible = false;
            Panel2.Visible = false;
            //GroupBox5.Visible = false;
            //Panel_PRO.Visible = false;
            Panel1.Visible = true;
            btn_nuevo2.Select();
        }

        private void btn_cancelar2_Click(object sender, EventArgs e)
        {
            //panelito2.Visible = false;
            Panel2.Visible = false;
            //GroupBox5.Visible = false;
            //Panel_PRO.Visible = false;
            Panel1.Visible = true;
            btn_cancelar.Visible = true;
            btn_cancelar.Text = "&Salir";
            btn_nuevo2.Select();
        }

        private void btn_eliminar2_Click(object sender, EventArgs e)
        {
            dgw.Rows.RemoveAt(dgw.CurrentRow.Index);
        }

        private void TXT_COD_PRO_Leave(object sender, EventArgs e)
        {
            if (TXT_COD_PRO.Text.Trim() == "")
                return;

            int i = 0;
            if (DGW_PRO.Rows.Count > 0)
            {
                DGW_PRO.Sort(DGW_PRO.Columns[0], System.ComponentModel.ListSortDirection.Ascending);
                for (i = 0; i <= DGW_PRO.Rows.Count - 1; i++)
                {
                    if (TXT_COD_PRO.Text.ToLower() == (DGW_PRO[0, i].Value).ToString().ToLower())
                    {
                        TXT_COD_PRO.Text = DGW_PRO[0, i].Value.ToString();
                        TXT_DESC_PRO.Text = DGW_PRO[1, i].Value.ToString();
                        txt_nro_parte.Text = DGW_PRO[2, i].Value.ToString();
                        Panel_PRO.Visible = false;
                        txt_nro_parte.Focus();
                        return;
                    }
                    if (DGW_PRO[0, i].Value.ToString().Length >= TXT_COD_PRO.TextLength)
                    {
                        if (TXT_COD_PRO.Text.ToLower() == DGW_PRO[0, i].Value.ToString().ToLower().Substring(0, TXT_COD_PRO.TextLength))
                        {
                            Panel_PRO.Visible = true;
                            DGW_PRO.Focus();
                            DGW_PRO.CurrentCell = DGW_PRO.Rows[i].Cells[0];
                            break;
                        }
                    }
                    else if (HelpersBLL.IsNumeric(TXT_COD_PRO.Text) && HelpersBLL.IsNumeric(DGW_PRO[0, i].Value.ToString()))
                    {
                        if (Convert.ToInt64(TXT_COD_PRO.Text) == Convert.ToInt64(DGW_PRO[0, i].Value.ToString()))
                        {
                            DGW_PRO.CurrentCell = DGW_PRO.Rows[i].Cells[0];
                            break;
                        }
                    }
                    DGW_PRO.CurrentCell = DGW_PRO.Rows[0].Cells[0];
                }

                Panel_PRO.Visible = true;
                DGW_PRO.Visible = true;
                DGW_PRO.Focus();
            }
            else
            {
                MessageBox.Show("No existen PRODUCTOS ", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TXT_COD_PRO.Text = "";
                TXT_DESC_PRO.Text = "";
                txt_nro_parte.Text = "";
            }

        }
        private void TXT_DESC_PRO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (TXT_DESC_PRO.Text.Trim() == "")
                {
                    return;
                }
                int i;
                if (DGW_PRO.Rows.Count > 0)
                {
                    DGW_PRO.Sort(DGW_PRO.Columns[1], System.ComponentModel.ListSortDirection.Ascending);
                    for (i = 0; i < DGW_PRO.Rows.Count - 1; i++)
                    {
                        if (DGW_PRO[1, i].Value.ToString().Length >= TXT_DESC_PRO.TextLength)
                        {
                            if (TXT_DESC_PRO.Text.ToLower() == DGW_PRO[1, i].Value.ToString().Substring(0, TXT_DESC_PRO.TextLength).ToLower())
                            {
                                DGW_PRO.CurrentCell = DGW_PRO.Rows[i].Cells[0];
                                break;
                            }//Mid(DGW_PRO[1, i].Value, 1, Len(TXT_DESC_PRO.Text)).ToLower)
                        }
                        DGW_PRO.CurrentCell = DGW_PRO.Rows[0].Cells[0];

                    }
                    Panel_PRO.Visible = true;
                    DGW_PRO.Visible = true;
                    DGW_PRO.Focus();
                }
                else
                {
                    MessageBox.Show("No existen PRODUCTOS ", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    TXT_COD_PRO.Text = "";
                    TXT_DESC_PRO.Text = "";
                    txt_nro_parte.Text = "";
                    return;
                }
            }
        }
        private void TXT_DESC_PRO_Leave(object sender, EventArgs e)
        {
            if (TXT_DESC_PRO.Text.Trim() == "")
            {
                txt_nro_parte.Focus();
            }
            else
            {
                int i;
                if (DGW_PRO.Rows.Count > 0)
                {
                    DGW_PRO.Sort(DGW_PRO.Columns[1], System.ComponentModel.ListSortDirection.Ascending);
                    for (i = 0; i <= DGW_PRO.Rows.Count - 1; i++)
                    {
                        if (DGW_PRO[1, i].Value.ToString().Length >= TXT_DESC_PRO.TextLength)
                        {
                            if (TXT_DESC_PRO.Text.ToLower() == DGW_PRO[1, i].Value.ToString().ToLower().Substring(0, TXT_DESC_PRO.TextLength).ToLower())
                            {
                                DGW_PRO.CurrentCell = DGW_PRO.Rows[i].Cells[0];
                                break;
                            }
                        }
                        DGW_PRO.CurrentCell = DGW_PRO.Rows[0].Cells[0];
                    }
                    Panel_PRO.Visible = true;
                    DGW_PRO.Visible = true;
                    DGW_PRO.Focus();
                }
                else
                {
                    MessageBox.Show("No existen PRODUCTOS ", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    TXT_COD_PRO.Text = "";
                    TXT_DESC_PRO.Text = "";
                    txt_nro_parte.Text = "";
                    return;
                }
            }
        }
        private void DGW_PRO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TXT_COD_PRO.Text = DGW_PRO[0, DGW_PRO.CurrentRow.Index].Value.ToString();
                TXT_DESC_PRO.Text = DGW_PRO[1, DGW_PRO.CurrentRow.Index].Value.ToString();
                txt_nro_parte.Text = DGW_PRO[2, DGW_PRO.CurrentRow.Index].Value.ToString();
                UM = DGW_PRO[3, DGW_PRO.CurrentRow.Index].Value.ToString();
                txt_nro_parte.Focus();
                Panel_PRO.Visible = false;

            }
            else if (e.KeyCode == Keys.Escape)
            {
                Panel_PRO.Visible = false;
                TXT_COD_PRO.Clear();
                TXT_DESC_PRO.Clear();
                TXT_COD_PRO.Focus();
            }
        }
        private bool validaGuardarModificarArticulos()
        {
            bool result = true;
            if (TXT_COD_PRO.Text.Trim() == "")
            {
                MessageBox.Show("Ingese el codigo !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TXT_COD_PRO.Focus();
                return result = false;
            }
            if (TXT_DESC_PRO.Text.Trim() == "")
            {
                MessageBox.Show("Ingese la descripcion !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TXT_DESC_PRO.Focus();
                return result = false;
            }
            if (txt_cantidad.Text.Trim() == "")
            {
                MessageBox.Show("Ingese la cantidad !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_cantidad.Focus();
                return result = false;
            }
            if (txt_precio.Text.Trim() == "")
            {
                MessageBox.Show("Ingese el precio !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_precio.Focus();
                return result = false;
            }
            return result;
        }
        private void btn_guardar2_Click_1(object sender, EventArgs e)
        {
            if (!validaGuardarModificarArticulos())
                return;
            int i1 = 0, cont1 = 0;
            cont1 = dgw.Rows.Count - 1;
            if (dgw.Rows.Count > 0)
            {
                for (i1 = 0; i1 <= cont1; i1++)
                {
                    if (dgw[0, i1].Value.ToString() == TXT_COD_PRO.Text && dgw[7, i1].Value.ToString() == dtp_fec_act.Value.ToShortDateString())
                    {
                        MessageBox.Show("El codigo del producto ya existe con la misma fecha, cambia la fecha !!!", "YA EXISTE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        TXT_COD_PRO.Focus();
                        return;
                    }
                    if (dgw[0, i1].Value.ToString() == TXT_COD_PRO.Text)
                    {
                        MessageBox.Show("Esta a punto de modificar la Lista de Precios !!!", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgw[8, i1].Value = true;
                        dgw.Rows[i1].Visible = false;
                        fec_actualizacion = dtp_fec_act.Value;
                        break;
                    }
                }
            }
            else
            {
                fec_actualizacion = dtp_fec_act.Value;
            }
            dgw.Rows.Add(TXT_COD_PRO.Text, TXT_DESC_PRO.Text, txt_nro_parte.Text, UM, txt_cantidad.Text, txt_precio.Text, chk_val_ref.Checked, dtp_fec_act.Value.ToShortDateString(), chk_sus.Checked);
            //MessageBox.Show("Exito al guardar", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            LIMPIAR_detalle();
            Panel2.Visible = false;
            Panel1.Visible = true;
            btn_nuevo2.Select();
        }

        private void btn_modificar2_Click_1(object sender, EventArgs e)
        {
            if (!validaGuardarModificarArticulos())
                return;
            int idx = dgw.CurrentRow.Index;
            dgw[0, idx].Value = TXT_COD_PRO.Text;
            dgw[1, idx].Value = TXT_DESC_PRO.Text;
            dgw[3, idx].Value = UM;
            dgw[4, idx].Value = txt_cantidad.Text;
            dgw[5, idx].Value = txt_precio.Text;
            dgw[6, idx].Value = chk_val_ref.Checked;
            dgw[7, idx].Value = dtp_fec_act.Value.Date.ToShortDateString();
            dgw[8, idx].Value = chk_sus.Checked;

            //
            LIMPIAR_detalle();
            Panel2.Visible = false;
            Panel1.Visible = true;
            btn_nuevo2.Select();
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void txt_precio_Leave(object sender, EventArgs e)
        {
            if (txt_precio.Text.Trim() != string.Empty && HelpersBLL.IsNumeric(txt_precio.Text))
                txt_precio.Text = HelpersBLL.OBTIENE_PRECIO_TRES_DECIMALES(txt_precio.Text);
            else
                txt_precio.Text = "";
        }

        private void txt_cantidad_Leave(object sender, EventArgs e)
        {
            if (txt_cantidad.Text.Trim() != string.Empty)
                txt_cantidad.Text = HelpersBLL.OBTIENE_PRECIO_TRES_DECIMALES(txt_cantidad.Text);
            else
                txt_cantidad.Text = "";
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (dgw1.Rows.Count <= 0)
                return;
            kitDetalleBLL kidBLL = new kitDetalleBLL();
            kitDetalleTo kidTo = new kitDetalleTo();
            kidTo.COD_KIT = dgw1[0, dgw1.CurrentRow.Index].Value.ToString();
            kidTo.DESDE = dtp_desde.Value;
            kidTo.HASTA = dtp_hasta.Value;

            DataTable dt = kidBLL.obtenerKitDetalleporCodKit_FechaBLL(kidTo);
            dgwdet.DataSource = dt;
            dgwdet.Columns[0].Width = 60;
            dgwdet.Columns[1].Width = 260;
            dgwdet.Columns[2].Width = 60;
            dgwdet.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgwdet.Columns[3].Width = 70;
            dgwdet.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgwdet.Columns[4].Width = 70;
            dgwdet.Columns[5].Width = 30;
            dgwdet.Columns[6].Width = 40;
        }
        private void llenaComboClase()
        {
            claseBLL claBLL = new claseBLL();
            DataTable dt = claBLL.obtenerClaseArticuloparaGrupoBLL();
            cbo_clase.ValueMember = "COD_CLASE";
            cbo_clase.DisplayMember = "DESC_CLASE";
            cbo_clase.DataSource = dt;
        }
        private void cbo_clase_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_clase.SelectedIndex > -1)
            {
                grupoBLL gruBLL = new grupoBLL();
                DataTable dtGrupo = gruBLL.obtenerGrupoClaseBLL(cbo_clase.SelectedValue.ToString());
                cbo_grupo.DisplayMember = "DESC_GRUPO";
                cbo_grupo.ValueMember = "COD_GRUPO";
                cbo_grupo.DataSource = dtGrupo;
            }
        }


        private void cbo_grupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_grupo.SelectedValue != null)
                CARGAR_PRODUCTOS();
        }



    }
}
