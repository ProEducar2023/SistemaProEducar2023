using BLL;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;
namespace Presentacion.MOD_ADM
{
    public partial class NUMERACION_COMPROBANTE : Form
    {
        string boton;
        string mes5, año5, mes51, año51;
        DataTable dtNC;
        numeracionComprobanteBLL ncBLL = new numeracionComprobanteBLL();
        numeracionComprobanteTo ncTo = new numeracionComprobanteTo();
        tipoCambioBLL tpcBLL = new tipoCambioBLL();
        tipoCambioTo tpcTo = new tipoCambioTo();
        public NUMERACION_COMPROBANTE()
        {
            InitializeComponent();
        }

        private void NUMERACION_COMPROBANTE_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            cargar_año();
            cargar_mes();
            mes5 = DateTime.Now.ToString("MM");
            año5 = DateTime.Now.Year.ToString();
            cbo_año.Text = DateTime.Now.Year.ToString();
            cbo_mes.SelectedValue = DateTime.Now.ToString("MM");
            //////////////
            mes51 = DateTime.Now.ToString("MM");
            año51 = DateTime.Now.Year.ToString();
            cbo_año1.Text = DateTime.Now.Year.ToString();
            cbo_mes1.SelectedValue = DateTime.Now.ToString("MM");
            CARGAR_DIRECTORES();
            //cargaGrid();
            //cargaGridSuspendidos();
            btn_nuevo.Select();
        }
        private void cargar_año()
        {
            DataTable dt = tpcBLL.obtenerAnnioBLL();
            DataTable dt1 = tpcBLL.obtenerAnnioBLL();
            if (dt.Rows.Count > 0)
            {
                cbo_año.ValueMember = "año";
                cbo_año.DisplayMember = "año";
                cbo_año.DataSource = dt;
                cbo_año.SelectedIndex = -1;
                //////////////
                cbo_año1.ValueMember = "año";
                cbo_año1.DisplayMember = "año";
                cbo_año1.DataSource = dt1;
                cbo_año1.SelectedIndex = -1;
            }
            else
            {
                var aa = new[] { new { cod = DateTime.Now.Year, val = DateTime.Now.Year } };
                cbo_año.ValueMember = "cod";
                cbo_año.DisplayMember = "val";
                cbo_año.DataSource = aa;
                cbo_año.SelectedIndex = -1;
                //////////////
                var bb = new[] { new { cod = DateTime.Now.Year, val = DateTime.Now.Year } };
                cbo_año1.ValueMember = "cod";
                cbo_año1.DisplayMember = "val";
                cbo_año1.DataSource = bb;
                cbo_año1.SelectedIndex = -1;
            }
        }
        private void cargar_mes()
        {
            var months = new[] { new { cod = "01", val = "Enero" }, new { cod = "02", val = "Febrero" },
                                new { cod = "03", val = "Marzo" }, new { cod = "04", val = "Abril" },
                                new { cod = "05", val = "Mayo" }, new { cod = "06", val = "Junio" },
                                new { cod = "07", val = "Julio" }, new { cod = "08", val = "Agosto" },
                                new { cod = "09", val = "Septiembre" }, new { cod = "10", val = "Octubre" },
                                new { cod = "11", val = "Noviembre" }, new { cod = "12", val = "Diciembre" }};
            cbo_mes.ValueMember = "cod";
            cbo_mes.DisplayMember = "val";
            cbo_mes.DataSource = months;
            //cbo_mes.SelectedIndex = -1;
            ///////////////
            var months1 = new[] { new { cod = "01", val = "Enero" }, new { cod = "02", val = "Febrero" },
                                new { cod = "03", val = "Marzo" }, new { cod = "04", val = "Abril" },
                                new { cod = "05", val = "Mayo" }, new { cod = "06", val = "Junio" },
                                new { cod = "07", val = "Julio" }, new { cod = "08", val = "Agosto" },
                                new { cod = "09", val = "Septiembre" }, new { cod = "10", val = "Octubre" },
                                new { cod = "11", val = "Noviembre" }, new { cod = "12", val = "Diciembre" }};
            cbo_mes1.ValueMember = "cod";
            cbo_mes1.DisplayMember = "val";
            cbo_mes1.DataSource = months1;
        }
        private void CARGAR_DIRECTORES()
        {
            progNivelBLL prnBLL = new progNivelBLL();
            //DataTable dt = prnBLL.obtenerDirectoresparaCrearEqVentasBLL();
            eq_vta_nivel_progBLL eqvBLL = new eq_vta_nivel_progBLL();
            DataTable dt = eqvBLL.obtenerEquipoBLL();
            dgw_per2.DataSource = dt;
            dgw_per2.Columns[0].Width = 55;
            dgw_per2.Columns[0].HeaderText = "Codigo";
            dgw_per2.Columns[0].DisplayIndex = 0;
            dgw_per2.Columns[3].Width = 235;
            dgw_per2.Columns[3].HeaderText = "Nombres";
            dgw_per2.Columns[3].DisplayIndex = 1;
            dgw_per2.Columns[2].Width = 80;
            dgw_per2.Columns[2].HeaderText = "Dni";
            dgw_per2.Columns[2].DisplayIndex = 2;
            dgw_per2.Columns[1].Visible = false;
            dgw_per2.Columns[4].Visible = false;
            dgw_per2.Columns[5].Visible = false;
            dgw_per2.Columns[6].Visible = false;
            dgw_per2.Columns[7].Visible = false;
            dgw_per2.Columns[8].Visible = false;
        }
        private void cargaGrid()
        {
            dgw1.Rows.Clear();
            ncTo.ST_SUSPENDIDO = false;
            ncTo.AÑO = año5;
            ncTo.MES = mes5;
            dtNC = ncBLL.obtenerNumeracionComprobanteBLL(ncTo);
            if (dtNC.Rows.Count > 0)
            {
                foreach (DataRow rw in dtNC.Rows)
                {
                    int rowId = dgw1.Rows.Add();
                    DataGridViewRow row = dgw1.Rows[rowId];
                    row.Cells["cod"].Value = rw["COD_VEN"].ToString();
                    row.Cells["desc"].Value = rw["NOM_VEN"].ToString();//HAY QUE AGREGAR NOMBRE 
                    row.Cells["fecha"].Value = Convert.ToDateTime(rw["FEC_COMPROBANTE"]);
                    row.Cells["nroini"].Value = rw["NRO_INI"].ToString();
                    row.Cells["nrofin"].Value = rw["NRO_FIN"].ToString();
                    row.Cells["stsus"].Value = Convert.ToBoolean(rw["ST_SUSPENDIDO"]);
                    row.Cells["annio"].Value = rw["AÑO"].ToString();
                    row.Cells["mes"].Value = rw["MES"].ToString();
                }
            }
        }
        private void cargaGridSuspendidos()
        {
            dgw_sus.Rows.Clear();
            ncTo.ST_SUSPENDIDO = true;
            ncTo.AÑO = año51;
            ncTo.MES = mes51;
            dtNC = ncBLL.obtenerNumeracionComprobanteBLL(ncTo);
            if (dtNC.Rows.Count > 0)
            {
                foreach (DataRow rw in dtNC.Rows)
                {
                    int rowId = dgw_sus.Rows.Add();
                    DataGridViewRow row = dgw_sus.Rows[rowId];
                    row.Cells[0].Value = rw["COD_VEN"].ToString();
                    row.Cells[1].Value = rw["NOM_VEN"].ToString();//HAY QUE AGREGAR NOMBRE 
                    row.Cells[2].Value = Convert.ToDateTime(rw["FEC_COMPROBANTE"]);
                    row.Cells[3].Value = rw["NRO_INI"].ToString();
                    row.Cells[4].Value = rw["NRO_FIN"].ToString();
                    row.Cells[5].Value = Convert.ToBoolean(rw["ST_SUSPENDIDO"]);
                    row.Cells[6].Value = rw["AÑO"].ToString();
                    row.Cells[7].Value = rw["MES"].ToString();
                }
            }
        }
        private void NUMERACION_COMPROBANTE_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void LIMPIAR()
        {
            txt_cod2.Text = "";
            txt_desc2.Text = "";
            dtp_fec_comp.Value = DateTime.Now;
            txt_ini.Text = "";
            txt_fin.Text = "";
            chk_sus.Checked = false;
            //
            txt_cod2.Enabled = true;
            txt_desc2.Enabled = true;
            dtp_fec_comp.Enabled = true;
            chk_sus.Enabled = true;
            txt_ini.Enabled = true;
            txt_fin.Enabled = true;
            btn_guardar.Visible = true;
            btn_modificar2.Visible = true;
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            boton = "NUEVO";
            LIMPIAR();
            //txt_cod.Text = dgw1.Rows.Count == 0 ? "01" : obtieneCodigo(Convert.ToInt32(dgw1.Rows[dgw1.Rows.Count - 1].Cells["codkit"].Value));
            dtp_fec_comp.Value = Convert.ToDateTime("01/" + cbo_mes.SelectedValue.ToString().PadLeft(2, '0') + "/" + cbo_año.SelectedValue.ToString());
            btn_guardar.Visible = true;
            btn_modificar2.Visible = false;
            TabControl1.SelectedTab = TabPage2;
            panel_per2.Visible = false;
            txt_cod2.Focus();
        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            boton = "MODIFICAR";
            LIMPIAR();
            btn_guardar.Visible = false;
            btn_modificar2.Visible = true;
            CARGAR_DETALLE();
            TabControl1.SelectedTab = TabPage2;
            panel_per2.Visible = false;
            txt_cod2.Focus();
        }
        private void CARGAR_DETALLE()
        {
            if (dgw1.Rows.Count > 0)
            {
                int idx = dgw1.CurrentRow.Index;
                txt_cod2.Text = dgw1[0, idx].Value.ToString();
                txt_desc2.Text = dgw1.Rows[idx].Cells["desc"].Value.ToString();
                dtp_fec_comp.Value = Convert.ToDateTime(dgw1[2, idx].Value);
                txt_ini.Text = dgw1[3, idx].Value.ToString();
                txt_fin.Text = dgw1[4, idx].Value.ToString();
                chk_sus.Checked = Convert.ToBoolean(dgw1[5, idx].Value);
            }
        }
        private void CARGAR_DETALLE_SUSPENDIDOS()
        {
            if (dgw_sus.Rows.Count > 0)
            {
                int idx = dgw_sus.CurrentRow.Index;
                txt_cod2.Text = dgw_sus[0, idx].Value.ToString();
                txt_desc2.Text = dgw_sus[1, idx].Value.ToString();
                dtp_fec_comp.Value = Convert.ToDateTime(dgw_sus[2, idx].Value);
                txt_ini.Text = dgw_sus[3, idx].Value.ToString();
                txt_fin.Text = dgw_sus[4, idx].Value.ToString();
                chk_sus.Checked = Convert.ToBoolean(dgw_sus[5, idx].Value);
            }
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (!validar())
                return;
            DialogResult rs = MessageBox.Show("¿ Esta seguro de adicionar una nueva Numeración ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                ncTo.COD_VEN = txt_cod2.Text;
                ncTo.NOM_VEN = txt_desc2.Text;
                ncTo.FEC_COMPROBANTE = dtp_fec_comp.Value;
                ncTo.NRO_INI = txt_ini.Text;
                ncTo.NRO_FIN = txt_fin.Text;
                ncTo.ST_SUSPENDIDO = chk_sus.Checked;
                ncTo.AÑO = cbo_año.Text;
                ncTo.MES = cbo_mes.SelectedValue.ToString();

                if (!ncBLL.insertarNumeracionComprobanteBLL(ncTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Se adicionó correctamente la Numeración !!!" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //
                    dgw1.Rows.Add(txt_cod2.Text, txt_desc2.Text, dtp_fec_comp.Value.ToShortDateString(), txt_ini.Text, txt_fin.Text,
                        chk_sus.Checked, cbo_año.Text, cbo_mes.SelectedValue.ToString());
                    LIMPIAR();
                    TabControl1.SelectedTab = TabPage1;
                    btn_nuevo.Select();
                }
            }
        }
        private bool validar()
        {
            bool result = true;
            if (txt_cod2.Text.Trim() == "")
            {
                MessageBox.Show("INGRESE EL CODIGO DEL VENDEDOR !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_cod2.Focus();
                return result = false;
            }
            if (txt_desc2.Text.Trim() == "")
            {
                MessageBox.Show("INGRESE EL NOMBRE DEL VENDEDOR !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_desc2.Focus();
                return result = false;
            }
            if (txt_ini.Text.Trim() == "")
            {
                MessageBox.Show("INGRESE EL NUMERO INICIAL !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_ini.Focus();
                return result = false;
            }
            if (txt_fin.Text.Trim() == "")
            {
                MessageBox.Show("INGRESE EL NUMERO FINAL !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_fin.Focus();
                return result = false;
            }
            if (Convert.ToInt32(txt_fin.Text) < Convert.ToInt32(txt_ini.Text))
            {
                MessageBox.Show("EL NUMERO FINAL DEBE SER MAYOR QUE EL NUMERO INICIAL !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_fin.Focus();
                return result = false;
            }
            if (btn_guardar.Visible)
            {
                ncTo.COD_VEN = txt_cod2.Text;
                ncTo.FEC_COMPROBANTE = dtp_fec_comp.Value;
                if (ncBLL.verificaNumeracionComprobanteBLL(ncTo) > 0)
                {
                    MessageBox.Show("Ya existen Codigo de vendedor con la misma fecha, cambie alguno !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txt_cod2.Focus();
                    return result = false;
                }
            }
            return result;
        }
        private void btn_modificar2_Click(object sender, EventArgs e)
        {
            if (!validar())
                return;
            DialogResult rs = MessageBox.Show("¿ Esta seguro de modificar la Numerción ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                ncTo.COD_VEN = txt_cod2.Text;
                ncTo.NOM_VEN = txt_desc2.Text;
                ncTo.FEC_COMPROBANTE = dtp_fec_comp.Value;
                ncTo.NRO_INI = txt_ini.Text;
                ncTo.NRO_FIN = txt_fin.Text;
                ncTo.ST_SUSPENDIDO = chk_sus.Checked;

                if (!ncBLL.modificarNumeracionComprobanteBLL(ncTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Se modificó correctamente la Numeración !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //
                    if (chk_sus.Checked)
                    {
                        if (cbo_mes.SelectedValue.ToString() == cbo_mes1.SelectedValue.ToString() && cbo_año.Text == cbo_año1.Text)
                        {
                            dgw_sus.Rows.Add(dgw1.CurrentRow.Cells[0].Value.ToString(), dgw1.CurrentRow.Cells[1].Value.ToString(),
                                Convert.ToDateTime(dgw1.CurrentRow.Cells[2].Value), dgw1.CurrentRow.Cells[3].Value.ToString(),
                                dgw1.CurrentRow.Cells[4].Value.ToString(), Convert.ToBoolean(dgw1.CurrentRow.Cells[5].Value),
                                cbo_año.Text, cbo_mes.SelectedValue.ToString());
                        }
                        //
                        dgw1.Rows.RemoveAt(dgw1.CurrentRow.Index);
                    }
                    else
                    {
                        dgw1.CurrentRow.Cells[0].Value = txt_cod2.Text;
                        dgw1.CurrentRow.Cells[1].Value = txt_desc2.Text;
                        dgw1.CurrentRow.Cells[2].Value = dtp_fec_comp.Value.ToShortDateString();
                        dgw1.CurrentRow.Cells[3].Value = txt_ini.Text;
                        dgw1.CurrentRow.Cells[4].Value = txt_fin.Text;
                        dgw1.CurrentRow.Cells[5].Value = chk_sus.Checked;
                    }

                    LIMPIAR();
                    TabControl1.SelectedTab = TabPage1;
                    btn_nuevo.Select();
                }
            }
        }

        private void txt_cod2_Leave(object sender, EventArgs e)
        {
            if (txt_cod2.Text.Trim() != "")
            {
                if (dgw_per2.Rows.Count > 0)
                {
                    dgw_per2.Sort(dgw_per2.Columns[0], System.ComponentModel.ListSortDirection.Ascending);
                    int i = 0, num2 = 0;
                    num2 = dgw_per2.Rows.Count - 1;
                    do
                    {
                        if (txt_cod2.Text.ToLower() == dgw_per2[0, i].Value.ToString().ToLower())
                        {
                            txt_cod2.Text = dgw_per2[0, i].Value.ToString();
                            txt_desc2.Text = dgw_per2[3, i].Value.ToString();
                            //txt_doc_per.Text = dgw_per2[2, i].Value.ToString();
                            //
                            //TabControl2.SelectedTab = TabPage10;    
                            return;
                        }
                        if (txt_cod2.Text.ToLower() == dgw_per2[0, i].Value.ToString().ToLower().Substring(0, txt_cod2.TextLength))
                        {
                            dgw_per2.CurrentCell = dgw_per2.Rows[i].Cells[0];
                            break;
                        }
                        dgw_per2.CurrentCell = dgw_per2.Rows[0].Cells[0];
                        i += 1;
                    }
                    while (i <= num2);
                    panel_per2.Visible = true;
                    dgw_per2.Visible = true;
                    dgw_per2.Focus();

                }
            }
        }
        private void txt_desc2_Leave(object sender, EventArgs e)
        {
            if (txt_desc2.Text != "")
            {
                if (dgw_per2.Rows.Count > 0)
                {
                    dgw_per2.Sort(dgw_per2.Columns[3], System.ComponentModel.ListSortDirection.Ascending);
                    int i = 0, num2 = 0;
                    num2 = dgw_per2.Rows.Count;
                    do
                    {
                        if (dgw_per2[3, i].Value.ToString().Length >= txt_desc2.TextLength)
                        {
                            if (txt_desc2.Text.ToLower() == dgw_per2[3, i].Value.ToString().ToLower().Substring(0, txt_desc2.TextLength).ToLower())
                            {
                                dgw_per2.CurrentCell = dgw_per2.Rows[i].Cells[0];
                                break;
                            }
                        }
                        dgw_per2.CurrentCell = dgw_per2.Rows[0].Cells[0];
                        i += 1;
                    }
                    while (i < num2);
                    panel_per2.Visible = true;
                    dgw_per2.Visible = true;
                    dgw_per2.Focus();
                }
            }
        }
        private void dgw_per2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int idx = dgw_per2.CurrentRow.Index;
                txt_cod2.Text = dgw_per2[0, idx].Value.ToString();
                txt_desc2.Text = dgw_per2[3, idx].Value.ToString();
                //txt_doc_per.Text = dgw_per[2, idx].Value.ToString();
                panel_per2.Visible = false;
                dtp_fec_comp.Focus();
                //TabControl2.SelectedTab = TabPage10;
                //cboptovta.Focus();
                //llenaSuperiores();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                panel_per2.Visible = false;
                txt_cod2.Clear();
                txt_desc2.Clear();
                //txt_doc_per.Clear();
                txt_cod2.Focus();
            }
        }

        private void txt_ini_Leave(object sender, EventArgs e)
        {
            txt_ini.Text = HelpersBLL.OBTIENE_CODIGO(7, txt_ini.Text);
        }

        private void txt_fin_Leave(object sender, EventArgs e)
        {
            txt_fin.Text = HelpersBLL.OBTIENE_CODIGO(7, txt_fin.Text);
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            TabControl1.SelectedTab = TabPage1;
            btn_nuevo.Select();
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("¿ ESTA SEGURO DE ELIMINAR LA NUMERACION ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                ncTo.COD_VEN = dgw1.CurrentRow.Cells["cod"].Value.ToString(); //txt_cod2.Text;
                ncTo.FEC_COMPROBANTE = Convert.ToDateTime(dgw1.CurrentRow.Cells["fecha"].Value); //dtp_fec_comp.Value;

                if (!ncBLL.eliminarNumeracionComprobanteBLL(ncTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("SE ELIMINÓ CORRECTAMENTE LA NUMERACIÓN !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                else if (boton == "SUSPENDIDO")
                {
                    boton = "DETALLES3";
                }
                else
                {
                    boton = "DETALLES";
                    LIMPIAR();
                    if (dgw1.Rows.Count == 0)
                    {

                    }
                    else
                        CARGAR_DETALLE();

                    txt_cod2.Enabled = false;
                    txt_desc2.Enabled = false;
                    dtp_fec_comp.Enabled = false;
                    chk_sus.Enabled = false;
                    txt_ini.Enabled = false;
                    txt_fin.Enabled = false;
                    btn_guardar.Visible = false;
                    btn_modificar2.Visible = false;
                }
            }
            else
                btn_nuevo.Select();
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnConsultarSuspendidos_Click(object sender, EventArgs e)
        {
            boton = "SUSPENDIDO";
            LIMPIAR();
            btn_guardar.Visible = false;
            btn_modificar2.Visible = false;
            dgw_sus.Rows.Clear();
            cargaGridSuspendidos();
            TabControl1.SelectedTab = tabPage3;
            panel_per2.Visible = false;
            btnVerSus.Focus();
        }

        private void btnVerSus_Click(object sender, EventArgs e)
        {
            boton = "SUSPENDIDO";
            LIMPIAR();
            btn_guardar.Visible = false;
            btn_modificar2.Visible = false;
            //cargaGridSuspendidos();
            CARGAR_DETALLE_SUSPENDIDOS();
            TabControl1.SelectedTab = TabPage2;
            panel_per2.Visible = false;
        }

        private void btnCancelarSus_Click(object sender, EventArgs e)
        {
            TabControl1.SelectedTab = TabPage1;
            btn_nuevo.Select();
        }

        private void cbo_mes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_mes.SelectedValue != null)
            {
                if ((cbo_mes.SelectedIndex > -1 && cbo_año.SelectedIndex > -1))
                {
                    mes5 = cbo_mes.SelectedValue.ToString();
                    cargaGrid();
                    if (dgw1.Rows.Count == 0)
                        MessageBox.Show("No existen registros para ese año y mes", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void cbo_año_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_año.SelectedValue != null)
            {
                if ((cbo_mes.SelectedIndex > -1 && cbo_año.SelectedIndex > -1))
                {
                    año5 = cbo_año.SelectedValue.ToString();
                    cargaGrid();
                    if (dgw1.Rows.Count == 0)
                        MessageBox.Show("No existen registros  para ese año y mes", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void cbo_mes1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_mes1.SelectedValue != null)
            {
                if ((cbo_mes1.SelectedIndex > -1 && cbo_año1.SelectedIndex > -1))
                {
                    mes51 = cbo_mes1.SelectedValue.ToString();
                    cargaGridSuspendidos();
                    if (dgw_sus.Rows.Count == 0)
                        MessageBox.Show("No existen registros Suspendidos para ese año y mes", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void cbo_año1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_año1.SelectedValue != null)
            {
                if ((cbo_mes1.SelectedIndex > -1 && cbo_año1.SelectedIndex > -1))
                {
                    año51 = cbo_año1.SelectedValue.ToString();
                    cargaGridSuspendidos();
                    if (dgw_sus.Rows.Count == 0)
                        MessageBox.Show("No existen registros Suspendidos para ese año y mes", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void btnDesSus_Click(object sender, EventArgs e)
        {
            if (!validaSuspender())
                return;

            DialogResult rs = MessageBox.Show("¿ Esta seguro de Des-Suspender el registro ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                ncTo.COD_VEN = dgw_sus.CurrentRow.Cells[0].Value.ToString();
                ncTo.FEC_COMPROBANTE = Convert.ToDateTime(dgw_sus.CurrentRow.Cells[2].Value);

                if (!ncBLL.desSustituirNumeracionComprobanteBLL(ncTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Se Des-suspendió correctamente el registro !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //
                    if (cbo_mes.SelectedValue.ToString() == cbo_mes1.SelectedValue.ToString() && cbo_año.Text == cbo_año1.Text)
                    {
                        dgw1.Rows.Add(dgw_sus.CurrentRow.Cells[0].Value.ToString(), dgw_sus.CurrentRow.Cells[1].Value.ToString(),
                            Convert.ToDateTime(dgw_sus.CurrentRow.Cells[2].Value), dgw_sus.CurrentRow.Cells[3].Value.ToString(),
                            dgw_sus.CurrentRow.Cells[4].Value.ToString(), Convert.ToBoolean(dgw_sus.CurrentRow.Cells[5].Value),
                            cbo_año.Text, cbo_mes.SelectedValue.ToString());
                    }
                    //
                    dgw_sus.Rows.RemoveAt(dgw_sus.CurrentRow.Index);
                }
            }
        }
        private bool validaSuspender()
        {
            bool result = true;
            if (dgw_sus.Rows.Count <= 0)
                return result = false;

            return result;
        }

    }
}
