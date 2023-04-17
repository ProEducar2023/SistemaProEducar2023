using BLL;
using Entidades;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
namespace Presentacion.MOD_ADM
{
    public partial class PUNTO_VENTA_GENERAR : Form
    {
        string AÑO = "", MES = "", COD_MOD = "", COD_USU = "", TIPO_USU = "";
        DateTime FECHA_INI, FECHA_GRAL; DataTable dtDet = null;
        string boton;
        int fila;
        puntoVentaBLL ptvBLL = new puntoVentaBLL();
        puntoVentaTo ptvTo = new puntoVentaTo();
        public PUNTO_VENTA_GENERAR(string AÑO, string MES, DateTime FECHA_INI, DateTime FECHA_GRAL, string COD_MOD, string TIPO_USU, string COD_USU)
        {
            InitializeComponent();
            this.AÑO = AÑO;
            this.MES = MES;
            this.FECHA_INI = FECHA_INI;
            this.FECHA_GRAL = FECHA_GRAL;
            this.COD_MOD = COD_MOD;
            this.TIPO_USU = TIPO_USU;
            this.COD_USU = COD_USU;
        }

        private void PUNTO_VENTA_GENERAR_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            CARGAR_INSTITUCIONES();
            cargaPais();
            CARGAR_TIPO_PLANILLA();
            DATAGRID();
            //rbtPtoVta.Checked = true;
            //FiltraporCategoria();
            //CARGAR_PUNTO_COBRANZA();
            btn_nuevo.Select();
        }
        private void CARGAR_TIPO_PLANILLA()
        {
            var planilla = new[] {  new { val = "DESCUENTO", cod = "P" },
                                    new { val = "DIRECTA", cod = "D" }};

            cbo_tipo_pla.ValueMember = "cod";
            cbo_tipo_pla.DisplayMember = "val";
            cbo_tipo_pla.DataSource = planilla;
            cbo_tipo_pla.SelectedIndex = -1;

        }
        private void PUNTO_VENTA_GENERAR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        public void DATAGRID()
        {
            DataTable dt = ptvBLL.obtenerPuntoVentaBLL();
            lbl_nro_reg.Text = "Nro de Registros : 0";
            if (dt.Rows.Count > 0)
            {
                lbl_nro_reg.Text = "Nro de Registros : " + dt.Rows.Count.ToString();
                dgw.DataSource = dt;
                dtDet = dt;
                DISEÑO_GRID();
            }

        }
        private void DISEÑO_GRID()
        {
            dgw.Columns["COD_PTO_VEN"].HeaderText = "Cod";
            dgw.Columns["COD_PTO_VEN"].Width = 40;
            dgw.Columns["DESC_PTO_VEN"].HeaderText = "Descripcion";
            dgw.Columns["DESC_PTO_VEN"].Width = 200;
            dgw.Columns["COD_INSTITUCION"].Visible = false;
            dgw.Columns["DESC_INSTITUCION"].HeaderText = "Institucion";
            dgw.Columns["DESC_INSTITUCION"].Width = 190;
            dgw.Columns["TIPO_PLANILLA"].HeaderText = "T";
            dgw.Columns["TIPO_PLANILLA"].Width = 30;
            dgw.Columns["PAIS"].Visible = false;
            dgw.Columns["DEPARTAMENTO"].Visible = false;
            dgw.Columns["PROVINCIA"].Visible = false;
            dgw.Columns["DISTRITO"].Visible = false;
            dgw.Columns["STATUS_CONSOLIDADO"].Visible = false;
            //dgw.Columns["STATUS_CONSOLIDADO"].HeaderText = "C";
            //dgw.Columns["STATUS_CONSOLIDADO"].Width = 25;
            dgw.Columns["DIRECCION"].Visible = false;
            //dgw.Columns["COD_PTO_VEN"].Visible = false;
            dgw.Columns["COD_PTO_COB"].Visible = false;
        }
        private void CARGAR_INSTITUCIONES()
        {
            institucionesBLL insBLL = new institucionesBLL();
            DataTable dtInst = insBLL.obtenerInstitucionesBLL();
            cboinst.ValueMember = "COD_INST";
            cboinst.DisplayMember = "DESC_INST";
            cboinst.DataSource = dtInst;
        }
        private void cargaPais()
        {
            HelpersBLL helBLL = new HelpersBLL();
            DataTable dt = helBLL.obtenerPaisBLL();
            cbopais.ValueMember = "COD_PAIS";
            cbopais.DisplayMember = "DESC_PAIS";
            cbopais.DataSource = dt;
            //cbopais.SelectedValue = "9589";
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            boton = "NUEVO";
            btn_guardar.Visible = true;
            btn_modificar2.Visible = false;
            Limpiar();
            cbopais.SelectedValue = "9589";
            //(dgw[0,dgw.Rows.Count - 1].Value).ToString().PadLeft(3, '0')
            var rows = dgw.Rows.Cast<DataGridViewRow>().Select(x => x.Cells["COD_PTO_VEN"].Value).ToList();
            string max = rows.Max().ToString();
            int num = dtDet == null ? 1 : Convert.ToInt32(max) + 1;
            //int num = dtDet == null ? 1 : Convert.ToInt32(dtDet.Rows[dtDet.Rows.Count - 1][0]) + 1;
            txtcod.Text = HelpersBLL.OBTIENE_CODIGO(3, num.ToString());
            TabControl1.SelectedTab = TabPage2;
            cboinst.Select();
        }
        private void btn_modificar_Click(object sender, EventArgs e)
        {
            if (dgw.Rows.Count <= 0)
                return;
            boton = "MODIFICAR";
            btn_guardar.Visible = false;
            btn_modificar2.Visible = true;
            Limpiar();
            CargarDatos();
            //txt_cod.ReadOnly = true;
            TabControl1.SelectedTab = TabPage2;
            cboinst.Select();
        }
        private void CargarDatos()
        {
            if (dgw.Rows.Count > 0)
            {
                int idx = dgw.CurrentRow.Index;
                txtcod.Text = dgw.Rows[idx].Cells["COD_PTO_VEN"].Value.ToString();
                cboinst.SelectedValue = dgw.Rows[idx].Cells["COD_INSTITUCION"].Value;
                txtptoven.Text = dgw.Rows[idx].Cells["DESC_PTO_VEN"].Value.ToString();
                cbopais.SelectedValue = dgw.Rows[idx].Cells["PAIS"].Value;
                cbodep.SelectedValue = dgw.Rows[idx].Cells["DEPARTAMENTO"].Value;
                cboprov.SelectedValue = dgw.Rows[idx].Cells["PROVINCIA"].Value;
                cbodist.SelectedValue = dgw.Rows[idx].Cells["DISTRITO"].Value;
                chbconsolidado.Checked = Convert.ToBoolean(dgw.Rows[idx].Cells["STATUS_CONSOLIDADO"].Value);
                cbo_tipo_pla.SelectedValue = dgw.Rows[idx].Cells["TIPO_PLANILLA"].Value;
                txt_dir.Text = dgw.Rows[idx].Cells["DIRECCION"].Value.ToString();
                cbo_pto_cob.SelectedValue = dgw.Rows[idx].Cells["COD_PTO_COB"].Value;
            }

        }
        private void Limpiar()
        {
            txtcod.Text = "";
            cbo_tipo_pla.SelectedIndex = -1;
            cboinst.SelectedIndex = -1;
            txtptoven.Text = "";
            cbopais.SelectedIndex = -1;
            cbodep.SelectedIndex = -1;
            cboprov.SelectedIndex = -1;
            cbodist.SelectedIndex = -1;
            cbopais.SelectedValue = "9589";
            cbodep.SelectedValue = "15";
            cboprov.SelectedValue = "01";
            cargaDistritos();
            chbconsolidado.Checked = false;
            txt_dir.Clear();
            cbo_pto_cob.SelectedIndex = -1;
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (!validaAdicionarModificar())
                return;
            DialogResult rs = MessageBox.Show("¿ Esta seguro de adicionar un nuevo Punto de Venta ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                ptvTo.COD_PTO_VEN = txtcod.Text.Trim();
                ptvTo.DESC_PTO_VEN = txtptoven.Text;
                ptvTo.COD_INSTITUCION = cboinst.SelectedValue.ToString();
                ptvTo.DESC_INSTITUCION = cboinst.Text;
                ptvTo.PAIS = cbopais.SelectedValue.ToString();
                ptvTo.DEPARTAMENTO = cbodep.SelectedValue.ToString();
                ptvTo.PROVINCIA = cboprov.SelectedValue.ToString();
                ptvTo.DISTRITO = cbodist.SelectedValue.ToString();
                ptvTo.STATUS_CONSOLIDADO = chbconsolidado.Checked;
                ptvTo.TIPO_PLANILLA = cbo_tipo_pla.SelectedValue.ToString();
                ptvTo.DIRECCION = txt_dir.Text;
                ptvTo.COD_PTO_COB = cbo_pto_cob.SelectedValue.ToString();

                if (!ptvBLL.insertarPuntoVentaBLL(ptvTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("El punto de Venta se creo correctamente", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DATAGRID();
                    //FiltraporCategoria();
                    TabControl1.SelectedTab = TabPage1;
                    btn_nuevo.Select();
                }
            }
        }
        public bool validaAdicionarModificar()
        {
            bool result = true;
            if (txtcod.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el Codigo !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtcod.Focus();
                return result = false;
            }
            if (cboinst.SelectedIndex == -1)
            {
                MessageBox.Show("Elija la Institucion !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboinst.Focus();
                return result = false;
            }
            if (txtptoven.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el Punto de Venta !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtptoven.Focus();
                return result = false;
            }
            if (cbo_tipo_pla.SelectedIndex == -1)
            {
                MessageBox.Show("Elija el Tipo de Planilla !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_tipo_pla.Focus();
                return result = false;
            }
            if (cbopais.SelectedIndex == -1)
            {
                MessageBox.Show("Elija el Pais !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbopais.Focus();
                return result = false;
            }
            if (cbodep.SelectedIndex == -1)
            {
                MessageBox.Show("Elija el Departamento !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbodep.Focus();
                return result = false;
            }
            if (cboprov.SelectedIndex == -1)
            {
                MessageBox.Show("Elija la Provincia !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboprov.Focus();
                return result = false;
            }
            if (cbodist.SelectedIndex == -1)
            {
                MessageBox.Show("Elija el Distrito !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbodist.Focus();
                return result = false;
            }
            if (btn_guardar.Visible)
            {
                ptvTo.COD_PTO_VEN = txtcod.Text;
                if (ptvBLL.verificaPuntoVentaBLL(ptvTo) > 0)
                {
                    MessageBox.Show("El Codigo ya existe !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtcod.Focus();
                    return result = false;
                }
            }
            return result;
        }

        private void btn_modificar2_Click(object sender, EventArgs e)
        {
            if (!validaAdicionarModificar())
                return;

            DialogResult rs = MessageBox.Show("¿ Esta seguro de modificar el Punto de Venta ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                ptvTo.COD_PTO_VEN = txtcod.Text.Trim();
                ptvTo.DESC_PTO_VEN = txtptoven.Text;
                ptvTo.COD_INSTITUCION = cboinst.SelectedValue.ToString();
                ptvTo.DESC_INSTITUCION = cboinst.Text;
                ptvTo.PAIS = cbopais.SelectedValue.ToString();
                ptvTo.DEPARTAMENTO = cbodep.SelectedValue.ToString();
                ptvTo.PROVINCIA = cboprov.SelectedValue.ToString();
                ptvTo.DISTRITO = cbodist.SelectedValue.ToString();
                ptvTo.STATUS_CONSOLIDADO = chbconsolidado.Checked;
                ptvTo.TIPO_PLANILLA = cbo_tipo_pla.SelectedValue.ToString();
                ptvTo.DIRECCION = txt_dir.Text;
                ptvTo.COD_PTO_COB = cbo_pto_cob.SelectedValue.ToString();

                if (!ptvBLL.modificarPuntoVentaBLL(ptvTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("El punto de Venta se modificó correctamente", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DATAGRID();
                    //FiltraporCategoria();
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
        private bool validaEliminar()
        {
            bool result = true;
            string errMensaje = "";
            if (dgw.Rows.Count <= 0)
                return result = false;
            ptvTo.COD_PTO_VEN = dgw.CurrentRow.Cells[0].Value.ToString();
            if (ptvBLL.validaHistoricoPedidoBLL(ptvTo, ref errMensaje))
            {
                MessageBox.Show("No se puede Eliminar \nEste Punto de Venta ya tiene Historico !!!", "No se puede Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            return result;
        }
        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (!validaEliminar())
                return;
            DialogResult rs = MessageBox.Show("¿ Esta seguro de eliminar el Punto de Venta ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                ptvTo.COD_PTO_VEN_CONS = dgw.CurrentRow.Cells[0].Value.ToString();
                ptvTo.STATUS_CONSOLIDADO = Convert.ToBoolean(dgw.CurrentRow.Cells["STATUS_CONSOLIDADO"].Value);
                if (!ptvBLL.eliminaPuntoVentayRelacionesBLL(ptvTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("El punto de Venta se eliminó correctamente", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DATAGRID();
                    //FiltraporCategoria();
                    TabControl1.SelectedTab = TabPage1;
                    btn_nuevo.Select();
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
                    if (dgw.Rows.Count == 0)
                    {


                    }
                    else
                        CargarDatos();

                    //txt_cod.ReadOnly = true;
                    //txt_desc.ReadOnly = true;
                    //txtdescc.ReadOnly = true;
                    btn_guardar.Visible = false;
                    btn_modificar2.Visible = false;
                }
            }
            else
                btn_nuevo.Select();
        }

        private void cbopais_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbopais.SelectedValue != null)
            {
                if (cbopais.SelectedValue.ToString() == "9589")
                    cargaDepartamentos();
                else
                {
                    cbodep.SelectedIndex = -1;
                    cboprov.SelectedIndex = -1;
                    cbodist.SelectedIndex = -1;
                }
            }
        }
        private void cargaDepartamentos()
        {
            HelpersBLL helBLL = new HelpersBLL();
            DataTable dt = helBLL.obtenerDepartamentoBLL();
            cbodep.ValueMember = "COD_DEP";
            cbodep.DisplayMember = "DESC_DEP";
            cbodep.DataSource = dt;
            //cbodep.SelectedValue = "15";
        }

        private void cbodep_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbopais.SelectedValue != null)
            {
                if (cbopais.SelectedValue.ToString() == "9589" && cbodep.SelectedValue != null)
                    cargaProvincias();
                else
                    cbodep.SelectedIndex = -1;
            }
        }
        private void cargaProvincias()
        {
            HelpersBLL helBLL = new HelpersBLL();
            HelpersTo helTo = new HelpersTo();
            helTo.CODIGO = cbodep.SelectedValue.ToString();
            DataTable dt = helBLL.obtenerPro_PaisBLL(helTo);
            cboprov.ValueMember = "COD_PRO";
            cboprov.DisplayMember = "DESC_PRO";
            cboprov.DataSource = dt;
        }

        private void cboprov_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbopais.SelectedValue != null)
            {
                if (cbopais.SelectedValue.ToString() == "9589" && cbodep.SelectedValue != null && cboprov.SelectedValue != null)
                    cargaDistritos();
                else
                    cbodep.SelectedIndex = -1;
            }
        }
        private void cargaDistritos()
        {
            HelpersBLL helBLL = new HelpersBLL();
            HelpersTo helTo = new HelpersTo();
            helTo.CODIGO = cbodep.SelectedValue.ToString();
            helTo.CODIGO2 = cboprov.SelectedValue.ToString();
            DataTable dt = helBLL.obtenerDist_Pro_PaisBLL(helTo);
            cbodist.ValueMember = "COD_DIST";
            cbodist.DisplayMember = "DESC_DIST";
            cbodist.DataSource = dt;
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txt_letra_TextChanged(object sender, EventArgs e)
        {
            int i;
            if (ch_rs.Checked)
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
            else if (ch_nc.Checked)
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

        private void ch_rs_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_rs.Checked)
            {
                dgw.Sort(dgw.Columns[0], System.ComponentModel.ListSortDirection.Ascending);
                btn_buscar.Enabled = false;
                btn_sgt.Enabled = false;
                txt_letra.Clear();
                txt_letra.Focus();
            }
        }
        private void ch_nc_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_nc.Checked)
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
        //private void FiltraporCategoria()
        //{
        //    if(dtDet != null)
        //    {
        //        DataView dv;
        //        if (rbtPtoVta.Checked)
        //            dv = new DataView(dtDet, "STATUS_CONSOLIDADO = False", "COD_PTO_VEN Asc", DataViewRowState.CurrentRows);
        //        else
        //            dv = new DataView(dtDet, "STATUS_CONSOLIDADO = True", "COD_PTO_VEN Asc", DataViewRowState.CurrentRows);
        //        dgw.DataSource = null;
        //        dgw.DataSource = dv.ToTable();
        //        DISEÑO_GRID();
        //    }
        //}

        private void CARGAR_PUNTO_COBRANZA()
        {
            //puntoVentaBLL ptvBLL = new puntoVentaBLL();
            //puntoVentaTo ptvTo = new puntoVentaTo();
            puntoCobranzaBLL ptcBLL = new puntoCobranzaBLL();
            puntoCobranzaTo ptcTo = new puntoCobranzaTo();
            ptcTo.STATUS_CONSOLIDADO = true;
            ptcTo.COD_INSTITUCION = cboinst.SelectedValue.ToString();
            //DataTable dt = ptvBLL.obtenerPuntosVentasBLL(ptvTo);
            DataTable dt = ptcBLL.obtenerPuntosCobranzaBLL(ptcTo);
            //DataTable dt = ptcBLL.obtenerTodosPuntosCobranzaBLL(ptcTo);
            cbo_pto_cob.ValueMember = "COD_PTO_COB";
            cbo_pto_cob.DisplayMember = "DESC_PTO_COB";
            cbo_pto_cob.DataSource = dt;
            cbo_pto_cob.SelectedIndex = -1;

            cbo_pto_cob.AutoCompleteCustomSource = AutoCompleClass.AutoComplete(dt);
            cbo_pto_cob.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbo_pto_cob.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void cboinst_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboinst.SelectedValue != null)
                CARGAR_PUNTO_COBRANZA();
        }



    }
}
