using BLL;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;

namespace Presentacion.MOD_ADM
{
    public partial class LUGAR_VENTA : Form
    {
        string AÑO = "", MES = "", COD_MOD = "", COD_USU = "", TIPO_USU = "";
        DateTime FECHA_INI, FECHA_GRAL; DataTable dtDet = null;
        string boton;
        int fila;
        DataTable dtPtoVta;
        lugarVentaBLL lgvBLL = new lugarVentaBLL();
        lugarVentaTo lgvTo = new lugarVentaTo();
        public LUGAR_VENTA(string AÑO, string MES, DateTime FECHA_INI, DateTime FECHA_GRAL, string COD_MOD, string TIPO_USU, string COD_USU)
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

        private void LUGAR_VENTA_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            CARGAR_INSTITUCIONES();
            DATAGRID();
            CARGAR_PUNTO_VENTA();
            CARGAR_LUGAR_VENTA();
            btn_nuevo.Select();
        }
        private void LUGAR_VENTA_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }
        private void CARGAR_LUGAR_VENTA()
        {
            DataTable dt = lgvBLL.obtenerLugVentaPtoVentaBLL();
            if (dt.Rows.Count > 0)
            {
                dgw_lug_vta.DataSource = dt;
                dgw_lug_vta.Columns["DESC_LUG_VTA"].HeaderText = "Lugar de Venta";
                dgw_lug_vta.Columns["DESC_LUG_VTA"].Width = 250;
                dgw_lug_vta.Columns["DESC_PTO_VEN"].HeaderText = "Punto de Venta";
                dgw_lug_vta.Columns["DESC_PTO_VEN"].Width = 250;
            }
        }
        private void CARGAR_PUNTO_VENTA()
        {
            puntoVentaBLL ptoBLL = new puntoVentaBLL();
            puntoVentaTo ptoTo = new puntoVentaTo();
            dtPtoVta = ptoBLL.obtenerPuntoVentaBLL();

        }
        private void CARGAR_INSTITUCIONES()
        {
            institucionesBLL insBLL = new institucionesBLL();
            DataTable dtInst = insBLL.obtenerInstitucionesBLL();
            cboinst.ValueMember = "COD_INST";
            cboinst.DisplayMember = "DESC_INST";
            cboinst.DataSource = dtInst;
        }


        public void DATAGRID()
        {
            DataTable dt = lgvBLL.obtenerLugarVentaBLL();
            if (dt.Rows.Count > 0)
            {
                dgw.DataSource = dt;
                dtDet = dt;
                DISEÑO_GRID();
            }
        }
        private void DISEÑO_GRID()
        {
            dgw.Columns["COD_INSTITUCION"].Visible = false;
            dgw.Columns["DESC_INST"].HeaderText = "Institucion";
            dgw.Columns["DESC_INST"].Width = 150;
            dgw.Columns["COD_PTO_VTA"].Visible = false;
            dgw.Columns["DESC_PTO_VEN"].HeaderText = "Punto Venta";
            dgw.Columns["DESC_PTO_VEN"].Width = 200;
            dgw.Columns["COD_LUG_VTA"].Visible = false;
            dgw.Columns["DESC_LUG_VTA"].HeaderText = "Lugar Venta";
            dgw.Columns["DESC_LUG_VTA"].Width = 250;
            dgw.Columns["LOCALIDAD"].Visible = false;
            dgw.Columns["DIRECCION"].Visible = false;
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            boton = "NUEVO";
            btn_guardar.Visible = true;
            btn_modificar2.Visible = false;
            Limpiar();
            //cbopais.SelectedValue = "9589";
            //(dgw[0,dgw.Rows.Count - 1].Value).ToString().PadLeft(3, '0')
            //int num = dtDet == null ? 1 : Convert.ToInt32(dtDet.Rows[dtDet.Rows.Count - 1][0]) + 1;
            //txtcod.Text = HelpersBLL.OBTIENE_CODIGO(3, num.ToString());
            TabControl1.SelectedTab = TabPage2;
            cboinst.Select();
        }
        private void Limpiar()
        {
            txtcod.Text = "";
            cboinst.SelectedIndex = -1;
            txtlugven.Text = "";
            txt_dir.Clear();
            cbo_pto_vta.SelectedIndex = -1;
            txtlugven.Clear();
            txt_localidad.Clear();
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
                cboinst.SelectedValue = dgw.Rows[idx].Cells["COD_INSTITUCION"].Value;
                cbo_pto_vta.SelectedValue = dgw.Rows[idx].Cells["COD_PTO_VTA"].Value;
                txtcod.Text = dgw.Rows[idx].Cells["COD_LUG_VTA"].Value.ToString();
                txtlugven.Text = dgw.Rows[idx].Cells["DESC_LUG_VTA"].Value.ToString();
                txt_localidad.Text = dgw.Rows[idx].Cells["LOCALIDAD"].Value.ToString();
                txt_dir.Text = dgw.Rows[idx].Cells["DIRECCION"].Value.ToString();
            }

        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (!validaAdicionarModificar())
                return;
            DialogResult rs = MessageBox.Show("¿ Esta seguro de adicionar un nuevo Lugar de Venta ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                lgvTo.COD_INSTITUCION = cboinst.SelectedValue.ToString();
                lgvTo.COD_PTO_VTA = cbo_pto_vta.SelectedValue.ToString();
                lgvTo.COD_LUG_VTA = txtcod.Text;
                lgvTo.DESC_LUG_VTA = txtlugven.Text.Trim();
                lgvTo.LOCALIDAD = txt_localidad.Text;
                lgvTo.DIRECCION = txt_dir.Text;

                if (!lgvBLL.insertarLugarVentaBLL(lgvTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("El Lugar de Venta se creo correctamente", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DATAGRID();
                    CARGAR_LUGAR_VENTA();
                    TabControl1.SelectedTab = TabPage1;
                    btn_nuevo.Select();
                }
            }
        }
        public bool validaAdicionarModificar()
        {
            bool result = true;
            if (cboinst.SelectedIndex == -1)
            {
                MessageBox.Show("Elija la Institucion !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboinst.Focus();
                return result = false;
            }
            if (cbo_pto_vta.SelectedIndex == -1)
            {
                MessageBox.Show("Elija el Punto de Venta !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_pto_vta.Focus();
                return result = false;
            }
            if (txtcod.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el Codigo !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtcod.Focus();
                return result = false;
            }

            if (txtlugven.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el Lugar de Venta !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtlugven.Focus();
                return result = false;
            }


            return result;
        }

        private void cboinst_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboinst.SelectedValue != null)
            {
                if (dtPtoVta != null)
                {
                    lgvTo.COD_INSTITUCION = cboinst.SelectedValue.ToString();
                    DataRow[] rs = dtPtoVta.Select("COD_INSTITUCION = '" + lgvTo.COD_INSTITUCION + "'");
                    if (rs.Length > 0)
                    {
                        cbo_pto_vta.ValueMember = "COD_PTO_VEN";
                        cbo_pto_vta.DisplayMember = "DESC_PTO_VEN";
                        cbo_pto_vta.DataSource = rs.CopyToDataTable();
                        cbo_pto_vta.SelectedIndex = -1;
                        //
                        cbo_pto_vta.AutoCompleteCustomSource = AutoCompleClass.AutoComplete(rs.CopyToDataTable());
                        cbo_pto_vta.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        cbo_pto_vta.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    }

                }
            }
        }

        private void cbo_pto_vta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_pto_vta.SelectedValue != null)
            {

                lgvTo.COD_INSTITUCION = cboinst.SelectedValue.ToString();
                lgvTo.COD_PTO_VTA = cbo_pto_vta.SelectedValue.ToString();
                string cod_lug_vta = lgvBLL.obtenerCodLugVenBLL(lgvTo);
                txtcod.Text = cod_lug_vta == "" ? "001" : cod_lug_vta;
            }
        }

        private void btn_modificar2_Click(object sender, EventArgs e)
        {
            if (!validaAdicionarModificar())
                return;

            DialogResult rs = MessageBox.Show("¿ Esta seguro de modificar el Lugar de Venta ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                lgvTo.COD_INSTITUCION = cboinst.SelectedValue.ToString();
                lgvTo.COD_PTO_VTA = cbo_pto_vta.SelectedValue.ToString();
                lgvTo.COD_LUG_VTA = txtcod.Text;
                lgvTo.DESC_LUG_VTA = txtlugven.Text.Trim();
                lgvTo.LOCALIDAD = txt_localidad.Text;
                lgvTo.DIRECCION = txt_dir.Text;

                if (!lgvBLL.modificarLugarVentaBLL(lgvTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("El Lugar de Venta se modificó correctamente", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DATAGRID();
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
            if (!validaEliminar())
                return;
            DialogResult rs = MessageBox.Show("¿ Esta seguro de eliminar el Lugar de Venta ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                lgvTo.COD_INSTITUCION = dgw.CurrentRow.Cells["COD_INSTITUCION"].Value.ToString();
                lgvTo.COD_PTO_VTA = dgw.CurrentRow.Cells["COD_PTO_VTA"].Value.ToString();
                lgvTo.COD_LUG_VTA = dgw.CurrentRow.Cells["COD_LUG_VTA"].Value.ToString();
                if (!lgvBLL.eliminarLugarVentaBLL(lgvTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("El Lugar de Venta se eliminó correctamente", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DATAGRID();
                    TabControl1.SelectedTab = TabPage1;
                    btn_nuevo.Select();
                }
            }
        }
        private bool validaEliminar()
        {
            bool result = true;
            if (dgw.Rows.Count <= 0)
                return result = false;

            if (cboinst.SelectedIndex == -1)
            {
                MessageBox.Show("Elija la Institucion !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboinst.Focus();
                return result = false;
            }
            if (cbo_pto_vta.SelectedIndex == -1)
            {
                MessageBox.Show("Elija el Punto de Venta !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_pto_vta.Focus();
                return result = false;
            }
            if (txtcod.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el Codigo !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtcod.Focus();
                return result = false;
            }
            return result;
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
            else if (ch_nc.Checked)
            {
                txt_letra.Focus();
                for (i = 0; i < dgw.Rows.Count; i++)
                {
                    if (txt_letra.TextLength <= dgw[5, i].Value.ToString().Length)
                    {
                        if (txt_letra.Text.ToLower() == dgw[5, i].Value.ToString().Substring(0, txt_letra.TextLength).ToLower())
                        {
                            dgw.CurrentCell = dgw.Rows[i].Cells[5];
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
                dgw.Sort(dgw.Columns[3], System.ComponentModel.ListSortDirection.Ascending);
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
                dgw.Sort(dgw.Columns[5], System.ComponentModel.ListSortDirection.Ascending);
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
                for (f = 0; f <= dgw[5, i].Value.ToString().Length - txt_letra.TextLength; f++)
                {
                    if (txt_letra.TextLength <= dgw[5, i].Value.ToString().Length)
                    {
                        if (txt_letra.Text.ToLower() == dgw[5, i].Value.ToString().Substring(f, txt_letra.TextLength).ToLower())
                        {
                            dgw.CurrentCell = dgw.Rows[i].Cells[5];
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
                for (f = 0; f <= dgw[5, i].Value.ToString().Length - txt_letra.TextLength; f++)
                {
                    if (txt_letra.TextLength <= dgw[5, i].Value.ToString().Length)
                    {
                        if (txt_letra.Text.ToLower() == dgw[5, i].Value.ToString().Substring(f, txt_letra.TextLength).ToLower())
                        {
                            dgw.CurrentCell = dgw.Rows[i].Cells[5];
                            fila = i + 1;
                            return;
                        }
                    }
                }
            }
            MessageBox.Show("Ya no existen más registros !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btn_buscar2_Click(object sender, EventArgs e)
        {
            Panel_Lug_Vta.Visible = true;
            int i, f;
            bool val = true;
            //txtlugven.Focus();
            dgw_lug_vta.Select();
            btn_sgt2.Enabled = true;
            for (i = 0; i < dgw_lug_vta.Rows.Count; i++)
            {
                for (f = 0; f <= dgw_lug_vta[0, i].Value.ToString().Length - txtlugven.TextLength; f++)
                {
                    if (txtlugven.TextLength <= dgw_lug_vta[0, i].Value.ToString().Length)
                    {
                        if (txtlugven.Text.ToLower() == dgw_lug_vta[0, i].Value.ToString().Substring(f, txtlugven.TextLength).ToLower())
                        {
                            dgw_lug_vta.CurrentCell = dgw_lug_vta.Rows[i].Cells[0];
                            fila = i + 1;
                            val = false;
                            return;
                        }
                    }
                }
            }
            if (val)
            {
                MessageBox.Show("No existen registros con esa entrada !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Panel_Lug_Vta.Visible = false;
                txtlugven.Focus();
                btn_sgt2.Enabled = false;
            }
        }

        private void btn_sgt2_Click(object sender, EventArgs e)
        {
            int i, f;//antes de dar a siguiente primero se hace buscar para que lo ubique en la primera coincidencia luego se da siguiente, siguiente..., hasta encontrar el valor buscado.
            for (i = fila; i < dgw_lug_vta.Rows.Count; i++)
            {
                for (f = 0; f <= dgw_lug_vta[0, i].Value.ToString().Length - txtlugven.TextLength; f++)
                {
                    if (txtlugven.TextLength <= dgw_lug_vta[0, i].Value.ToString().Length)
                    {
                        if (txtlugven.Text.ToLower() == dgw_lug_vta[0, i].Value.ToString().Substring(f, txtlugven.TextLength).ToLower())
                        {
                            dgw_lug_vta.CurrentCell = dgw_lug_vta.Rows[i].Cells[0];
                            fila = i + 1;
                            return;
                        }
                    }
                }
            }
            MessageBox.Show("Ya no existen más registros !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            Panel_Lug_Vta.Visible = false;
            txtlugven.Focus();
            btn_sgt2.Enabled = false;
        }

        private void dgw_lug_vta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int idx = dgw_lug_vta.CurrentRow.Index;
                txtlugven.Text = dgw_lug_vta[0, idx].Value.ToString();
                Panel_Lug_Vta.Visible = false;
                btn_sgt2.Enabled = false;
                //txt_1.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Panel_Lug_Vta.Visible = false;
                btn_sgt2.Enabled = false;
                txt_localidad.Clear();
                txtlugven.Focus();
            }
        }

        private void txtlugven_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Panel_Lug_Vta.Visible = false;
                txtlugven.Focus();
                btn_sgt2.Enabled = false;
            }
        }
    }
}
