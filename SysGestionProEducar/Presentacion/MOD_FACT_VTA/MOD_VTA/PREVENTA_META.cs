using BLL;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;

namespace Presentacion.MOD_FACT_VTA.MOD_VTA
{
    public partial class PREVENTA_META : Form
    {
        string boton = "";
        string AÑO = "", MES = "", COD_MOD = "", COD_USU = "", TIPO_USU = "";
        DateTime FECHA_INI, FECHA_GRAL;
        HelpersBLL helBLL = new HelpersBLL();
        HelpersTo helTo = new HelpersTo();
        metasBLL mtBLL = new metasBLL();
        metasTo mtTo = new metasTo();
        public PREVENTA_META(string AÑO, string MES, DateTime FECHA_INI, DateTime FECHA_GRAL, string COD_MOD, string TIPO_USU, string COD_USU)
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

        private void PREVENTA_META_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            CARGAR_SUCURSAL();
            CARGAR_VENDEDOR();
            CARGAR_PROGRAMAS();
            TIPO_PLANILLA();
            lbl_mes.Text = HelpersBLL.OBTENER_NOM_MES(MES);
            lbl_año.Text = AÑO;
            CARGAR_DATAGRID();
            btn_nuevo.Select();
        }

        private void PREVENTA_META_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void CARGAR_DATAGRID()
        {
            mtTo.FE_MES = MES;
            mtTo.FE_AÑO = AÑO;
            dgw1.Rows.Clear();
            DataTable dt = mtBLL.obtenerPreventasMetasMensualBLL(mtTo);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow rw in dt.Rows)
                {
                    int rowId = dgw1.Rows.Add();
                    DataGridViewRow row = dgw1.Rows[rowId];
                    row.Cells["fe_mes"].Value = rw["FE_MES"].ToString();
                    row.Cells["fe_año"].Value = rw["FE_AÑO"].ToString();
                    row.Cells["codigo"].Value = rw["COD_PER"].ToString();
                    row.Cells["nombre"].Value = rw["NOM_PER"].ToString();
                    row.Cells["cantidad"].Value = rw["CANTIDAD"].ToString();
                    row.Cells["monto_tot"].Value = rw["MONTO"].ToString();
                    row.Cells["cod_sucursal"].Value = rw["SUCURSAL"].ToString();
                    row.Cells["cod_programa"].Value = rw["COD_PROGRMA"].ToString();
                    row.Cells["tipo_planilla1"].Value = rw["TIPO_PLANILLA"].ToString();
                    row.Cells["cantidad"].Value = rw["CANTIDAD"].ToString();
                    row.Cells["fecha"].Value = rw["FECHA"].ToString();
                }
            }
        }
        private void TIPO_PLANILLA()
        {
            var items = new[] { new { cod = "P", val = "PLANILLA" }, new { cod = "D", val = "DIRECTA" } };
            cbo_tipo_planilla.ValueMember = "cod";
            cbo_tipo_planilla.DisplayMember = "val";
            cbo_tipo_planilla.DataSource = items;
            cbo_tipo_planilla.SelectedIndex = 0;
        }
        private void CARGAR_SUCURSAL()
        {
            helTo.CODIGO = COD_USU;
            DataTable dt = helBLL.CBO_SUCURSALBLL(helTo);
            CBO_SUCURSAL.ValueMember = "COD_SUCURSAL";
            CBO_SUCURSAL.DisplayMember = "DESC_sucursal";
            CBO_SUCURSAL.DataSource = dt;
            CBO_SUCURSAL.SelectedIndex = 0;
        }
        private void CARGAR_VENDEDOR()
        {
            progNivelBLL prnBLL = new progNivelBLL();
            DataTable dt = prnBLL.obtenerVendedoresparaCrearEqVentasBLL();
            dgw_per2.DataSource = dt;
            dgw_per2.Columns[0].Width = 55;
            dgw_per2.Columns[1].Width = 240;
        }
        private void CARGAR_PROGRAMAS()
        {
            programaBLL prgBLL = new programaBLL();
            DataTable dt = prgBLL.obtenerProgramaBLL();
            cbo_prog.ValueMember = "COD_PROGRAMA";
            cbo_prog.DisplayMember = "DESC_PROGRAMA";
            cbo_prog.DataSource = dt;
            cbo_prog.SelectedIndex = 0;
        }
        private void btn_guardar_Click(object sender, EventArgs e)
        {

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
                            txt_desc2.Text = dgw_per2[1, i].Value.ToString();
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
            if (txt_desc2.Text == "")
            {
                txt_cod2.Focus();
            }
            else
            {
                if (dgw_per2.Rows.Count > 0)
                {
                    dgw_per2.Sort(dgw_per2.Columns[1], System.ComponentModel.ListSortDirection.Ascending);
                    int i = 0, num2 = 0;
                    num2 = dgw_per2.Rows.Count;
                    do
                    {
                        if (dgw_per2[1, i].Value.ToString().Length >= txt_desc2.TextLength)
                        {
                            if (txt_desc2.Text.ToLower() == dgw_per2[1, i].Value.ToString().ToLower().Substring(0, txt_desc2.TextLength).ToLower())
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
                txt_desc2.Text = dgw_per2[1, idx].Value.ToString();
                panel_per2.Visible = false;
                //cbo_tipo_planilla.Select();
                GroupBox4.Select();
                //VerificaNumeracionContrato();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                //Panel_PER.Visible = false;
                panel_per2.Visible = false;
                txt_cod2.Clear();
                txt_desc2.Clear();
                //txt_doc_per.Clear();
                //txt_cod2.Focus();

            }
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            boton = "NUEVO";
            LIMPIAR_CABECERA();
            btn_guardar.Visible = true;
            btn_modificar2.Visible = false;
            CBO_SUCURSAL.Enabled = true;
            cbo_prog.Enabled = true;
            txt_cod2.ReadOnly = false;
            txt_desc2.ReadOnly = false;
            cbo_tipo_planilla.Enabled = true;
            TabControl1.SelectedTab = TabPage2;
            CBO_SUCURSAL.SelectedIndex = 0;
            cbo_prog.SelectedIndex = 0;
            cbo_tipo_planilla.SelectedIndex = 0;
            txt_cod2.Focus();
        }
        private void LIMPIAR_CABECERA()
        {
            CBO_SUCURSAL.SelectedIndex = -1;
            cbo_prog.SelectedIndex = -1;
            cbo_tipo_planilla.SelectedIndex = -1;
            txt_cod2.Clear();
            txt_desc2.Clear();
            txt_cant.Clear();
            txt_monto.Clear();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            TabControl1.SelectedTab = TabPage1;
        }

        private void btn_guardar_Click_1(object sender, EventArgs e)
        {
            if (!validaGuardar("guardar"))
                return;

            DialogResult rs = MessageBox.Show("¿ Esta seguro de Grabar ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                mtTo.FE_MES = MES;
                mtTo.FE_AÑO = AÑO;
                mtTo.COD_PER = txt_cod2.Text;
                mtTo.NOM_PER = txt_desc2.Text;
                mtTo.SUCURSAL = CBO_SUCURSAL.SelectedValue.ToString();
                mtTo.FECHA = DateTime.Now;
                mtTo.COD_PROGRAMA = cbo_prog.SelectedValue.ToString();
                mtTo.TIPO_PLANILLA = cbo_tipo_planilla.SelectedValue.ToString();
                mtTo.MONTO = Convert.ToDecimal(txt_monto.Text);
                mtTo.CANTIDAD = Convert.ToInt32(txt_cant.Text);
                mtTo.COD_CREA = COD_USU;
                mtTo.FECHA_CREA = DateTime.Now;
                if (!mtBLL.insertarMetasBLL(mtTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    dgw1.Rows.Add(MES, AÑO, txt_cod2.Text, txt_desc2.Text, txt_cant.Text, HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(txt_monto.Text), mtTo.SUCURSAL, mtTo.COD_PROGRAMA, mtTo.TIPO_PLANILLA, mtTo.CANTIDAD, mtTo.FECHA);
                    TabControl1.SelectedTab = TabPage1;
                }
            }
        }
        private bool validaGuardar(string val)
        {
            bool result = true;

            if (CBO_SUCURSAL.SelectedIndex == -1)
            {
                MessageBox.Show("Elija la Sucursal !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                CBO_SUCURSAL.Focus();
                return result = false;
            }
            if (cbo_prog.SelectedIndex == -1)
            {
                MessageBox.Show("Elija el Programa !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_prog.Focus();
                return result = false;
            }
            if (txt_cod2.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el codigo del Vendedor !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_cod2.Focus();
                return result = false;
            }
            if (txt_desc2.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el Nombre del Vendedor !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_desc2.Focus();
                return result = false;
            }
            //if (DTP_DOC.Value.Date < FECHA_INI.Date || DTP_DOC.Value.Date > FECHA_GRAL.Date)
            //{
            //    MessageBox.Show("Fecha no valida por estar fuera del Periodo !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    DTP_DOC.Focus();
            //    return result = false;
            //}
            //
            if (val == "guardar")
            {
                foreach (DataGridViewRow row in dgw1.Rows)
                {
                    if (row.Cells["codigo"].Value.ToString() == txt_cod2.Text)
                    {
                        MessageBox.Show("El Vendedor ya existe en la lista !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txt_cod2.Focus();
                        return result = false;
                    }
                }
            }

            //
            return result;
        }

        private void txt_monto_Leave(object sender, EventArgs e)
        {
            if (txt_monto.Text.Trim() != "")
            {
                txt_monto.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(txt_monto.Text);
            }
        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            boton = "MODIFICAR";
            LIMPIAR_CABECERA();
            btn_guardar.Visible = false;
            btn_modificar2.Visible = true;
            CBO_SUCURSAL.Enabled = false;
            cbo_prog.Enabled = false;
            txt_cod2.ReadOnly = true;
            txt_desc2.ReadOnly = true;
            cbo_tipo_planilla.Enabled = false;
            CARGAR_CABECERA();
            TabControl1.SelectedTab = TabPage2;
            cbo_tipo_planilla.Focus();
        }
        private void CARGAR_CABECERA()
        {
            if (dgw1.Rows.Count > 0)
            {
                CBO_SUCURSAL.SelectedValue = dgw1.CurrentRow.Cells["cod_sucursal"].Value;
                cbo_prog.SelectedValue = dgw1.CurrentRow.Cells["cod_programa"].Value;
                txt_cod2.Text = dgw1.CurrentRow.Cells["codigo"].Value.ToString();
                txt_desc2.Text = dgw1.CurrentRow.Cells["nombre"].Value.ToString();
                cbo_tipo_planilla.SelectedValue = dgw1.CurrentRow.Cells["tipo_planilla1"].Value;
                txt_monto.Text = dgw1.CurrentRow.Cells["monto_tot"].Value.ToString();
                txt_cant.Text = dgw1.CurrentRow.Cells["cantidad"].Value.ToString();
                //DTP_DOC.Value = Convert.ToDateTime(dgw1.CurrentRow.Cells["fecha"].Value);
            }
        }

        private void btn_modificar2_Click(object sender, EventArgs e)
        {
            if (!validaGuardar("modificar"))
                return;

            DialogResult rs = MessageBox.Show("¿ Esta seguro de Modificar ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                mtTo.FE_MES = MES;
                mtTo.FE_AÑO = AÑO;
                mtTo.COD_PER = txt_cod2.Text;
                mtTo.NOM_PER = txt_desc2.Text;
                mtTo.SUCURSAL = CBO_SUCURSAL.SelectedValue.ToString();
                mtTo.FECHA = DateTime.Now;
                mtTo.COD_PROGRAMA = cbo_prog.SelectedValue.ToString();
                mtTo.TIPO_PLANILLA = cbo_tipo_planilla.SelectedValue.ToString();
                mtTo.MONTO = Convert.ToDecimal(txt_monto.Text);
                mtTo.CANTIDAD = Convert.ToInt32(txt_cant.Text);
                mtTo.COD_MOD = COD_USU;
                mtTo.FECHA_MOD = DateTime.Now;
                if (!mtBLL.modificarMetasBLL(mtTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    dgw1.CurrentRow.Cells["codigo"].Value = txt_cod2.Text;
                    dgw1.CurrentRow.Cells["nombre"].Value = txt_desc2.Text;
                    dgw1.CurrentRow.Cells["monto_tot"].Value = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(mtTo.MONTO.ToString());
                    dgw1.CurrentRow.Cells["cod_sucursal"].Value = mtTo.SUCURSAL;
                    dgw1.CurrentRow.Cells["cod_programa"].Value = mtTo.COD_PROGRAMA;
                    dgw1.CurrentRow.Cells["tipo_planilla1"].Value = mtTo.TIPO_PLANILLA;
                    dgw1.CurrentRow.Cells["cantidad"].Value = mtTo.CANTIDAD;
                    dgw1.CurrentRow.Cells["fecha"].Value = mtTo.FECHA.ToShortDateString();
                    TabControl1.SelectedTab = TabPage1;
                }
            }
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (dgw1.Rows.Count <= 0)
                return;

            DialogResult rs = MessageBox.Show("¿ Esta seguro de Eliminar el registro ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                mtTo.SUCURSAL = dgw1.CurrentRow.Cells["cod_sucursal"].Value.ToString();
                mtTo.COD_PROGRAMA = dgw1.CurrentRow.Cells["cod_programa"].Value.ToString();
                mtTo.TIPO_PLANILLA = dgw1.CurrentRow.Cells["tipo_planilla1"].Value.ToString();
                mtTo.FE_MES = MES;
                mtTo.FE_AÑO = AÑO;
                mtTo.COD_PER = dgw1.CurrentRow.Cells["codigo"].Value.ToString();

                if (!mtBLL.eliminarMetasBLL(mtTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    dgw1.Rows.RemoveAt(dgw1.CurrentRow.Index);
                    btn_nuevo.Select();
                }
            }
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Dispose();
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
                    LIMPIAR_CABECERA();
                    if (dgw1.Rows.Count == 0)
                    {
                    }
                    else
                    {
                        CARGAR_CABECERA();
                    }

                    CBO_SUCURSAL.Enabled = false;
                    cbo_prog.Enabled = false;
                    txt_cod2.ReadOnly = true;
                    txt_desc2.ReadOnly = true;
                    cbo_tipo_planilla.Enabled = false;
                    btn_guardar.Visible = false;
                    btn_modificar2.Visible = false;
                }
            }
            else
                btn_nuevo.Select();
        }
    }
}
