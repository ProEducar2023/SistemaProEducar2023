using BLL;
using Entidades;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
namespace Presentacion.MOD_FACT_VTA.MOD_VTA
{
    public partial class REPORTE_TELEFONICO : Form
    {
        string boton = "";
        string AÑO = "", MES = "", COD_MOD = "", COD_USU = "", TIPO_USU = "";
        DateTime FECHA_INI, FECHA_GRAL;
        HelpersBLL helBLL = new HelpersBLL();
        HelpersTo helTo = new HelpersTo();
        reporteTelefonicoBLL rtBLL = new reporteTelefonicoBLL();
        reporteTelefonicoTo rtTo = new reporteTelefonicoTo();
        public REPORTE_TELEFONICO(string AÑO, string MES, DateTime FECHA_INI, DateTime FECHA_GRAL, string COD_MOD, string TIPO_USU, string COD_USU)
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

        private void REPORTE_TELEFONICO_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            CARGAR_SUCURSAL();
            CARGAR_VENDEDOR();
            CARGAR_SEMANA_CONTRATO();
            CARGAR_PROGRAMAS();
            TIPO_PLANILLA();
            lbl_mes.Text = HelpersBLL.OBTENER_NOM_MES(MES);
            lbl_año.Text = AÑO;
            CARGAR_DATAGRID();
            btn_nuevo.Select();
            //CARGAR_COMBO_SEMANA();
        }
        private void CARGAR_DATAGRID()
        {
            rtTo.FE_MES = MES;
            rtTo.FE_AÑO = AÑO;
            dgw1.Rows.Clear();
            DataTable dt = rtBLL.obtenerReporteTelefonicoMensualBLL(rtTo);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow rw in dt.Rows)
                {
                    int rowId = dgw1.Rows.Add();
                    DataGridViewRow row = dgw1.Rows[rowId];
                    row.Cells["cod_sucursal"].Value = rw["SUCURSAL"].ToString();
                    row.Cells["cod_programa"].Value = rw["COD_PROGRMA"].ToString();
                    row.Cells["tipo_planilla1"].Value = rw["TIPO_PLANILLA"].ToString();
                    row.Cells["fe_mes"].Value = rw["FE_MES"].ToString();
                    row.Cells["fe_año"].Value = rw["FE_AÑO"].ToString();
                    row.Cells["codigo"].Value = rw["COD_SEMANA"].ToString();
                    row.Cells["mess"].Value = lbl_mes.Text;
                    row.Cells["nombre"].Value = rw["NOM_SEMANA"].ToString();
                    row.Cells["cantidad_tot"].Value = rw["CANTIDAD_TOT"].ToString();
                    row.Cells["monto_tot"].Value = rw["MONTO_TOT"].ToString();
                }
            }
        }

        private void REPORTE_TELEFONICO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void CARGAR_SEMANA_CONTRATO()
        {
            semanaContratoBLL secBLL = new semanaContratoBLL();
            semanaContratoTo secTo = new semanaContratoTo();
            secTo.FE_AÑO = AÑO;
            secTo.FE_MES = MES;
            DataTable dt = secBLL.obtenerSemanaContratoparaPreventaBLL(secTo);
            if (dt.Rows.Count > 0)
            {
                cbo_semana.ValueMember = "NRO_SEMANA";
                cbo_semana.DisplayMember = "NOM_SEMANA";
                cbo_semana.DataSource = dt;
                cbo_semana.SelectedIndex = 0;
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

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            boton = "NUEVO";
            LIMPIAR_CABECERA();
            btn_guardar.Visible = true;
            btn_modificar2.Visible = false;
            txt_cod2.ReadOnly = false;
            txt_desc2.ReadOnly = false;
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
            dgw_det.Rows.Clear();
            Panel1.Visible = false;
        }
        private void dgw_per2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int idx = dgw_per2.CurrentRow.Index;
                txt_cod2.Text = dgw_per2[0, idx].Value.ToString();
                txt_desc2.Text = dgw_per2[1, idx].Value.ToString();
                panel_per2.Visible = false;
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

        private void btn_agregar1_Click(object sender, EventArgs e)
        {
            btn_guardar2.Visible = true;
            btn_mod1.Visible = false;
            Panel1.Visible = true;
            LIMPIAR_CONTACTO();
            txt_cod2.Focus();
        }
        private void LIMPIAR_CONTACTO()
        {
            txt_cod2.Clear();
            txt_desc2.Clear();
            txt_cantidad.Clear();
            txt_monto.Clear();
            txt_cod2.ReadOnly = false;
            txt_desc2.ReadOnly = false;
            txt_cantidad.ReadOnly = false;
            txt_monto.ReadOnly = false;
        }

        private void btn_guardar2_Click(object sender, EventArgs e)
        {
            if (!validaGuardarModificar("guardar"))
                return;

            dgw_det.Rows.Add(cbo_semana.SelectedValue.ToString(), txt_cod2.Text, txt_desc2.Text, txt_cantidad.Text, txt_monto.Text);
            Panel1.Visible = false;
            btn_agregar1.Focus();
        }
        private bool validaGuardarModificar(string op)
        {
            bool result = true;
            //if(DTP_DOC.Value.Date < FECHA_INI.Date || DTP_DOC.Value.Date > FECHA_GRAL.Date)
            //{
            //    MessageBox.Show("Fecha no valida por estar fuera del Periodo !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    DTP_DOC.Focus();
            //    return result = false;
            //}
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
            if (txt_cantidad.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese la Cantidad !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_cantidad.Focus();
                return result = false;
            }
            if (txt_monto.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el Monto !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_monto.Focus();
                return result = false;
            }
            if (op == "guardar")
            {
                var query = from DataGridViewRow row in dgw_det.Rows
                            where (row.Cells[1].Value.ToString() == txt_cod2.Text)
                            select row;
                if (query.Count() > 0)
                {
                    MessageBox.Show("El vendedor ya ha sido ingresado en esta semana !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txt_cod2.Focus();
                    return result = false;
                }
            }

            //DateTime ini = Convert.ToDateTime(cbo_semana.Text.Substring(4, 10));
            //DateTime fin = Convert.ToDateTime(cbo_semana.Text.Substring(18, 10));
            //if(DTP_DOC.Value.Date < ini.Date || DTP_DOC.Value.Date > fin.Date)
            //{
            //    MessageBox.Show("Fecha no se encuentra en el rango de la semana !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    DTP_DOC.Focus();
            //    return result = false;
            //}

            return result;
        }

        private void btn_cancelar2_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (!validaGuardar("guardar"))
                return;

            DialogResult rs = MessageBox.Show("¿ Esta seguro de Grabar ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                rtTo.SUCURSAL = CBO_SUCURSAL.SelectedValue.ToString();
                rtTo.COD_PROGRAMA = cbo_prog.SelectedValue.ToString();
                rtTo.TIPO_PLANILLA = cbo_tipo_planilla.SelectedValue.ToString();
                rtTo.FE_MES = MES;
                rtTo.FE_AÑO = AÑO;
                rtTo.COD_SEMANA = cbo_semana.SelectedValue.ToString();
                rtTo.NOM_SEMANA = cbo_semana.Text;
                rtTo.FECHA = DateTime.Now;
                rtTo.COD_CREA = COD_USU;
                rtTo.FECHA_CREA = DateTime.Now;
                DataTable dtDetalle = HelpersBLL.obtenerDT(dgw_det);
                rtTo.MONTO_TOTAL = montoTotal(dtDetalle);
                rtTo.CANTIDAD_TOT = cantTotal(dtDetalle);
                if (!rtBLL.grabarReporteTelefonicoBLL(rtTo, dtDetalle, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    dgw1.Rows.Add(rtTo.SUCURSAL, rtTo.COD_PROGRAMA, rtTo.TIPO_PLANILLA, MES, AÑO, rtTo.COD_SEMANA, lbl_mes.Text,
                        rtTo.NOM_SEMANA, rtTo.CANTIDAD_TOT, rtTo.MONTO_TOTAL);
                    TabControl1.SelectedTab = TabPage1;
                }
            }
        }
        private decimal montoTotal(DataTable dt)
        {
            decimal sum = 0;
            foreach (DataRow rw in dt.Rows)
            {
                sum += Convert.ToDecimal(rw["monto"]);
            }
            return sum;
        }
        private int cantTotal(DataTable dt)
        {
            int sum = 0;
            foreach (DataRow rw in dt.Rows)
            {
                sum += Convert.ToInt32(rw["cant"]);
            }
            return sum;
        }
        private bool validaGuardar(string op)
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
            if (cbo_tipo_planilla.SelectedIndex == -1)
            {
                MessageBox.Show("Elija el Tipo de Venta !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_tipo_planilla.Focus();
                return result = false;
            }
            if (cbo_semana.SelectedIndex == -1)
            {
                MessageBox.Show("Elija la Semana !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_semana.Focus();
                return result = false;
            }
            //
            if (op == "guardar")
            {
                foreach (DataGridViewRow row in dgw1.Rows)
                {
                    if (row.Cells["codigo"].Value.ToString() == cbo_semana.SelectedValue.ToString())
                    {
                        MessageBox.Show("La Semana ya existe en la lista !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txt_cod2.Focus();
                        return result = false;
                    }
                }
            }

            //
            return result;
        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            boton = "MODIFICAR";
            LIMPIAR_CABECERA();
            btn_guardar.Visible = false;
            btn_modificar2.Visible = true;
            txt_cod2.ReadOnly = true;
            txt_desc2.ReadOnly = true;
            CARGAR_CABECERA();
            CARGAR_DETALLES();
            TabControl1.SelectedTab = TabPage2;
            btn_agregar1.Focus();
        }
        private void CARGAR_DETALLES()
        {
            int idx = dgw1.CurrentRow.Index;
            reporteTelefonicoDetalleBLL rtdBLL = new reporteTelefonicoDetalleBLL();
            reporteTelefonicoDetalleTo rtdTo = new reporteTelefonicoDetalleTo();
            dgw_det.Rows.Clear();
            rtdTo.SUCURSAL = dgw1.CurrentRow.Cells["cod_sucursal"].Value.ToString();
            rtdTo.COD_PROGRAMA = dgw1.CurrentRow.Cells["cod_programa"].Value.ToString();
            rtdTo.TIPO_PLANILLA = dgw1.CurrentRow.Cells["tipo_planilla1"].Value.ToString();
            rtdTo.FE_MES = dgw1.CurrentRow.Cells["fe_mes"].Value.ToString();
            rtdTo.FE_AÑO = dgw1.CurrentRow.Cells["fe_año"].Value.ToString();
            rtdTo.COD_SEMANA = dgw1.CurrentRow.Cells["codigo"].Value.ToString();
            DataTable dtDet = rtdBLL.obtenerReporteTelefonicoDetalleBLL(rtdTo);
            foreach (DataRow rw in dtDet.Rows)
            {
                int rowId = dgw_det.Rows.Add();
                DataGridViewRow row = dgw_det.Rows[rowId];
                row.Cells["cod_semana"].Value = rw["COD_SEMANA"].ToString();
                row.Cells["cod_per"].Value = rw["COD_PER"].ToString();
                row.Cells["nom_per"].Value = rw["NOM_PER"].ToString();
                row.Cells["cant"].Value = rw["CANTIDAD"].ToString();
                row.Cells["monto"].Value = rw["MONTO"].ToString();
            }
        }
        private void CARGAR_CABECERA()
        {
            if (dgw1.Rows.Count > 0)
            {
                int idx = dgw1.CurrentRow.Index;
                CBO_SUCURSAL.SelectedValue = dgw1.CurrentRow.Cells["cod_sucursal"].Value;
                cbo_prog.SelectedValue = dgw1.CurrentRow.Cells["cod_programa"].Value;
                //txt_cod2.Text = dgw1.CurrentRow.Cells["codigo"].Value.ToString();
                //txt_desc2.Text = dgw1.CurrentRow.Cells["nombre"].Value.ToString();
                cbo_tipo_planilla.SelectedValue = dgw1.CurrentRow.Cells["tipo_planilla1"].Value;
                cbo_semana.SelectedValue = dgw1.CurrentRow.Cells["codigo"].Value;
            }
        }

        private void btn_modificar3_Click(object sender, EventArgs e)
        {
            btn_guardar2.Visible = false;
            btn_mod1.Visible = true;
            //item1.Text = dgw1.CurrentRow.Index.ToString
            LIMPIAR_CONTACTO();
            CARGAR_CONTACTO();
            Panel1.Visible = true;
            txt_cod2.Focus();
        }
        private void CARGAR_CONTACTO()
        {
            if (dgw_det.Rows.Count > 0)
            {
                //DTP_DOC.Value = Convert.ToDateTime(dgw_det.CurrentRow.Cells["fecha"].Value);
                txt_cod2.Text = dgw_det.CurrentRow.Cells["cod_per"].Value.ToString();
                txt_desc2.Text = dgw_det.CurrentRow.Cells["nom_per"].Value.ToString();
                txt_cantidad.Text = dgw_det.CurrentRow.Cells["cant"].Value.ToString();
                txt_monto.Text = dgw_det.CurrentRow.Cells["monto"].Value.ToString();
            }
        }
        private void btn_eliminar2_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("¿ Esta seguro de Eliminar este registro ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                if (dgw_det.Rows.Count > 0)
                    dgw_det.Rows.RemoveAt(dgw_det.CurrentRow.Index);
            }
        }

        private void btn_mod1_Click(object sender, EventArgs e)
        {
            if (!validaGuardarModificar("modificar"))
                return;
            dgw_det.CurrentRow.Cells["cod_per"].Value = txt_cod2.Text;
            dgw_det.CurrentRow.Cells["nom_per"].Value = txt_desc2.Text;
            dgw_det.CurrentRow.Cells["cant"].Value = txt_cantidad.Text;
            dgw_det.CurrentRow.Cells["monto"].Value = txt_monto.Text;
            Panel1.Visible = false;
        }

        private void btn_modificar2_Click(object sender, EventArgs e)
        {
            if (!validaGuardar("modificar"))
                return;

            DialogResult rs = MessageBox.Show("¿ Esta seguro de Grabar ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                rtTo.SUCURSAL = CBO_SUCURSAL.SelectedValue.ToString();
                rtTo.COD_PROGRAMA = cbo_prog.SelectedValue.ToString();
                rtTo.TIPO_PLANILLA = cbo_tipo_planilla.SelectedValue.ToString();
                rtTo.FE_MES = MES;
                rtTo.FE_AÑO = AÑO;
                rtTo.COD_SEMANA = cbo_semana.SelectedValue.ToString();
                rtTo.NOM_SEMANA = cbo_semana.Text;
                rtTo.FECHA = DateTime.Now;
                rtTo.COD_CREA = COD_USU;
                rtTo.FECHA_CREA = DateTime.Now;
                rtTo.COD_MOD = COD_USU;
                rtTo.FECHA_MOD = DateTime.Now;
                DataTable dtDetalle = HelpersBLL.obtenerDT(dgw_det);
                rtTo.MONTO_TOTAL = montoTotal(dtDetalle);
                rtTo.CANTIDAD_TOT = cantTotal(dtDetalle);
                if (!rtBLL.modificarReporteTelefonicoBLL(rtTo, dtDetalle, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    dgw1.CurrentRow.Cells["cod_sucursal"].Value = rtTo.SUCURSAL;
                    dgw1.CurrentRow.Cells["cod_programa"].Value = rtTo.COD_PROGRAMA;
                    dgw1.CurrentRow.Cells["tipo_planilla1"].Value = rtTo.TIPO_PLANILLA;
                    dgw1.CurrentRow.Cells["fe_mes"].Value = MES;
                    dgw1.CurrentRow.Cells["fe_año"].Value = AÑO;
                    dgw1.CurrentRow.Cells["cantidad_tot"].Value = rtTo.CANTIDAD_TOT.ToString();
                    dgw1.CurrentRow.Cells["monto_tot"].Value = rtTo.MONTO_TOTAL.ToString();

                    TabControl1.SelectedTab = TabPage1;
                }
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            TabControl1.SelectedTab = TabPage1;
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (dgw1.Rows.Count <= 0)
                return;

            DialogResult rs = MessageBox.Show("¿ Esta seguro de Eliminar el registro y todo su detalle ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                rtTo.SUCURSAL = dgw1.CurrentRow.Cells["cod_sucursal"].Value.ToString();
                rtTo.COD_PROGRAMA = dgw1.CurrentRow.Cells["cod_programa"].Value.ToString();
                rtTo.TIPO_PLANILLA = dgw1.CurrentRow.Cells["tipo_planilla1"].Value.ToString();
                rtTo.FE_MES = dgw1.CurrentRow.Cells["fe_mes"].Value.ToString();
                rtTo.FE_AÑO = dgw1.CurrentRow.Cells["fe_año"].Value.ToString();
                rtTo.COD_SEMANA = dgw1.CurrentRow.Cells["codigo"].Value.ToString();

                if (!rtBLL.finiquitarReporteTelefonicoBLL(rtTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    dgw1.Rows.RemoveAt(dgw1.CurrentRow.Index);
                    dgw1.Select();
                }
            }
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txt_monto_Leave(object sender, EventArgs e)
        {
            if (txt_monto.Text.Trim() != "")
            {
                txt_monto.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(txt_monto.Text);
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
                    LIMPIAR_CABECERA();
                    if (dgw1.Rows.Count == 0)
                    {
                    }
                    else
                    {
                        CARGAR_CABECERA();
                        CARGAR_DETALLES();
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
