using BLL;
using Entidades;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
namespace Presentacion.MOD_COMISIONES
{
    public partial class MAESTRO_COMISIONES : Form
    {
        string boton = "";
        string AÑO = "", MES = "", COD_MOD = "", COD_USU = "", TIPO_USU = "";
        DateTime FECHA_INI, FECHA_GRAL;
        comisionesBLL comBLL = new comisionesBLL();
        comisionesTo comTo = new comisionesTo();
        HelpersBLL helBLL = new HelpersBLL();
        HelpersTo helTo = new HelpersTo();
        progNivelRelacionBLL pnrBLL = new progNivelRelacionBLL();
        progNivelRelacionTo pnrTo = new progNivelRelacionTo();
        institucionesBLL insBLL = new institucionesBLL();
        institucionesNivelesBLL inBLL = new institucionesNivelesBLL();
        institucionesNivelesTo inTo = new institucionesNivelesTo();
        decimal sumMontoPropio = 0; decimal sumMontoTerceros = 0;
        DataTable dtTipoPlla; DataTable dtJerarquia;
        public MAESTRO_COMISIONES(string AÑO, string MES, DateTime FECHA_INI, DateTime FECHA_GRAL, string COD_MOD, string TIPO_USU, string COD_USU)
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
        private void MAESTRO_COMISIONES_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            CARGAR_VENDEDOR();
            CARGAR_PROGRAMAS();
            //TIPO_PLANILLA();
            CARGAR_TIPO_PLANILLA();
            CARGAR_DATAGRID();
            CARGAR_NIVEL();//nivel de Comisionista
            CARGAR_INSTITUCIONES();

            btn_nuevo.Select();
        }
        private void CARGAR_INSTITUCIONES()
        {
            DataTable dt = insBLL.obtenerInstitucionesBLL();
            if (dt.Rows.Count > 0)
            {
                cboInstituciones.ValueMember = "COD_INST";
                cboInstituciones.DisplayMember = "DESC_INST";
                cboInstituciones.DataSource = dt;
                cboInstituciones.SelectedIndex = 0;
                CARGAR_NIVEL_INSTITUCIONES();
            }
        }
        private void CARGAR_NIVEL()
        {
            nivelBLL niBLL = new nivelBLL();
            DataTable dt = niBLL.obtenerNivelBLL();
            cbo_nivel.ValueMember = "COD_NIVEL";
            cbo_nivel.DisplayMember = "DESC_NIVEL";
            cbo_nivel.DataSource = dt;
            cbo_nivel.SelectedIndex = 0;
        }
        private void CARGAR_PERSONAS()
        {
            //progNivelBLL prnBLL = new progNivelBLL();
            //progNivelTo prnTo = new progNivelTo();
            //prnTo.COD_NIVEL = cbo_nivel.SelectedValue.ToString();
            //DataTable dt = prnBLL.obtenerPersonasParaConsultaMetasBLL(prnTo);
            //dgw_per3.DataSource = dt;
            //dgw_per3.Columns[0].Width = 55;
            //dgw_per3.Columns[1].Width = 240;
            //dgw_per3.Columns[2].Width = 70;
            //dgw_per3.Columns[3].Visible = false;
            //dgw_per3.Columns[4].Visible = false;

            if (cbo_nivel.SelectedValue.ToString() != "04")//o sea diferente de vendedor
            {
                DataTable dt = dtJerarquia.AsEnumerable().Where(x => x.Field<string>("COD_NIVEL") == cbo_nivel.SelectedValue.ToString()).CopyToDataTable();
                txt_cod3.Text = Convert.ToString(dt.Rows[0]["COD_SUPERIOR"]);
                txt_desc3.Text = Convert.ToString(dt.Rows[0]["DESC_PER"]);
            }
            else
            {
                txt_cod3.Text = txt_cod2.Text;
                txt_desc3.Text = txt_desc2.Text;
            }
            lblTexto.Text = "para " + txt_desc3.Text;
            txt_desc3.Focus();
        }
        private void CARGAR_DATAGRID()
        {
            dgw1.Rows.Clear();
            DataTable dt = comBLL.obtenerComisionesBLL();
            lbl_nro_reg_docs.Text = "Nro de Registros : 0";
            if (dt.Rows.Count > 0)
            {
                lbl_nro_reg_docs.Text = "Nro de Registros : " + dt.Rows.Count.ToString();
                foreach (DataRow rw in dt.Rows)
                {
                    int rowId = dgw1.Rows.Add();
                    DataGridViewRow row = dgw1.Rows[rowId];
                    row.Cells["tipo"].Value = rw["TIPO"].ToString();
                    row.Cells["cod_programa"].Value = rw["COD_PROGRAMA"].ToString();
                    row.Cells["COD_INSTITUCION"].Value = Convert.ToString(rw["COD_INSTITUCION"]);
                    row.Cells["DESC_INST"].Value = Convert.ToString(rw["DESC_INST"]);
                    row.Cells["COD_NIVEL_INSTITUCION"].Value = Convert.ToString(rw["COD_NIVEL_INSTITUCION"]);
                    row.Cells["DESCRIPCION"].Value = Convert.ToString(rw["DESCRIPCION"]);
                    row.Cells["cod_pers"].Value = rw["COD_PER"].ToString();
                    row.Cells["nom_pers"].Value = rw["NOM_PER"].ToString();
                    row.Cells["monto_tot_propio"].Value = rw["MONTO_PROPIO"].ToString();
                    row.Cells["monto_tot_terceros"].Value = rw["MONTO_TERCEROS"].ToString();
                }
                sumaTotales();
            }
        }
        private void MAESTRO_COMISIONES_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        //private void TIPO_PLANILLA()
        //{
        //    var items = new[] { new { cod = "P", val = "PLANILLA" }, new { cod = "D", val = "DIRECTA" } };
        //    cbo_tipo_planilla.ValueMember = "cod";
        //    cbo_tipo_planilla.DisplayMember = "val";
        //    cbo_tipo_planilla.DataSource = items;
        //    cbo_tipo_planilla.SelectedIndex = 0;
        //}
        private void CARGAR_TIPO_PLANILLA()
        {
            tipoPlanillaCreacionBLL tpllaBLL = new tipoPlanillaCreacionBLL();
            tipoPlanillaCreacionTo tpllaTo = new tipoPlanillaCreacionTo();
            tpllaTo.STATUS_GENERACION = "1";
            tpllaTo.COD_VENTA = "VTA";
            dtTipoPlla = tpllaBLL.obtenerTipoPlanillaCreacionxStGeneracionBLL(tpllaTo);
            if (dtTipoPlla.Rows.Count > 0)
            {
                cbo_tipo_planilla.ValueMember = "COD_TIPO_PLLA";
                cbo_tipo_planilla.DisplayMember = "DESC_TIPO";
                cbo_tipo_planilla.DataSource = dtTipoPlla;
                cbo_tipo_planilla.SelectedIndex = 0;
            }
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
            cbo_tipo_planilla.Enabled = true;
            cbo_prog.Enabled = true;
            txt_cod2.Enabled = true;
            txt_desc2.Enabled = true;
            cboInstituciones.Enabled = true;
            cboNivelInstituciones.Enabled = true;
            TabControl1.SelectedTab = TabPage2;
            cbo_prog.SelectedIndex = 0;
            cbo_tipo_planilla.SelectedIndex = 0;
            txt_cod2.Focus();
        }
        private void LIMPIAR_CABECERA()
        {
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
                obtenerdtJerarquia();
                //groupBox1.Select();
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
            //txtBlanco.Focus();

        }
        private void obtenerdtJerarquia()
        {
            //se obtiene la jerarquia de superiores del vendedor
            pnrTo.COD_PROG = cbo_prog.SelectedValue.ToString();
            pnrTo.COD_VEND = txt_cod2.Text.Trim();
            dtJerarquia = pnrBLL.obtenerNivelesSuperioresVendedorBLL(pnrTo);//COD_NIVEL , COD_SUPERIOR
        }
        private void cbo_nivel_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cbo_nivel.SelectedValue != null)
            //    CARGAR_PERSONAS();
        }
        private void cbo_nivel_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbo_nivel.SelectedValue != null)
                CARGAR_PERSONAS();
        }
        private void txt_cod3_Leave(object sender, EventArgs e)
        {
            if (txt_cod3.Text.Trim() != "")
            {
                if (dgw_per3.Rows.Count > 0)
                {
                    dgw_per3.Sort(dgw_per3.Columns[0], System.ComponentModel.ListSortDirection.Ascending);
                    int i = 0, num2 = 0;
                    num2 = dgw_per3.Rows.Count - 1;
                    do
                    {
                        if (txt_cod3.Text.ToLower() == dgw_per3[0, i].Value.ToString().ToLower())
                        {
                            txt_cod3.Text = dgw_per3[0, i].Value.ToString();
                            txt_desc3.Text = dgw_per3[1, i].Value.ToString();
                            return;
                        }
                        if (txt_cod3.Text.ToLower() == dgw_per3[0, i].Value.ToString().ToLower().Substring(0, txt_cod3.TextLength))
                        {
                            dgw_per3.CurrentCell = dgw_per3.Rows[i].Cells[0];
                            break;
                        }
                        dgw_per3.CurrentCell = dgw_per3.Rows[0].Cells[0];
                        i += 1;
                    }
                    while (i <= num2);
                    panel_per3.Visible = true;
                    dgw_per3.Visible = true;
                    dgw_per3.Focus();
                }
            }
        }

        private void txt_desc3_Leave(object sender, EventArgs e)
        {
            if (txt_desc3.Text == "")
            {
                txt_cod3.Focus();
            }
            else
            {
                if (dgw_per3.Rows.Count > 0)
                {
                    dgw_per3.Sort(dgw_per3.Columns[1], System.ComponentModel.ListSortDirection.Ascending);
                    int i = 0, num2 = 0;
                    num2 = dgw_per3.Rows.Count;
                    do
                    {
                        if (dgw_per3[1, i].Value.ToString().Length >= txt_desc3.TextLength)
                        {
                            if (txt_desc3.Text.ToLower() == dgw_per3[1, i].Value.ToString().ToLower().Substring(0, txt_desc3.TextLength).ToLower())
                            {
                                dgw_per3.CurrentCell = dgw_per3.Rows[i].Cells[0];
                                break;
                            }
                        }
                        dgw_per3.CurrentCell = dgw_per3.Rows[0].Cells[0];
                        i += 1;
                    }
                    while (i < num2);
                    panel_per3.Visible = true;
                    dgw_per3.Visible = true;
                    dgw_per3.Focus();
                }
            }
        }
        private void btn_agregar1_Click(object sender, EventArgs e)
        {
            btn_guardar2.Visible = true;
            btn_mod1.Visible = false;
            Panel1.Visible = true;
            LIMPIAR_CONTACTO();
            //txt_cod2.Focus();
            cbo_nivel.Focus();
        }
        private void LIMPIAR_CONTACTO()
        {
            cbo_nivel.Enabled = true;
            txt_cod3.Clear();
            txt_desc3.Clear();
            txt_importe.Clear();
            txtPorcentaje.Clear();
            txt_cuota.Clear();
            txt_cod3.ReadOnly = false;
            txt_desc3.ReadOnly = false;
            txt_importe.ReadOnly = false;
            txtPorcentaje.ReadOnly = false;
            txt_cuota.ReadOnly = false;
        }

        private void btn_modificar3_Click(object sender, EventArgs e)
        {
            btn_guardar2.Visible = false;
            btn_mod1.Visible = true;
            //item1.Text = dgw1.CurrentRow.Index.ToString
            LIMPIAR_CONTACTO();
            CARGAR_CONTACTO();
            Panel1.Visible = true;
            cbo_nivel.Focus();
        }
        private void CARGAR_CONTACTO()
        {
            if (dgw_det.Rows.Count > 0)
            {
                cbo_nivel.SelectedValue = dgw_det.CurrentRow.Cells["cod_nivel"].Value.ToString();
                txt_cod3.Text = dgw_det.CurrentRow.Cells["cod_per_sup"].Value.ToString();
                txt_desc3.Text = dgw_det.CurrentRow.Cells["nom_per_sup"].Value.ToString();
                txt_importe.Text = dgw_det.CurrentRow.Cells["importe0"].Value.ToString();
                txtPorcentaje.Text = dgw_det.CurrentRow.Cells["porcentaje0"].Value.ToString();
                txt_cuota.Text = dgw_det.CurrentRow.Cells["cuota0"].Value.ToString();
            }
        }

        private void btn_guardar2_Click(object sender, EventArgs e)
        {
            if (!validaGuardarModificar("guardar"))
                return;
            string porciento = txtPorcentaje.Text == "" ? "0.00" : Convert.ToDecimal(txtPorcentaje.Text).ToString("0.00");
            string importe = txt_importe.Text == "" ? "0.00" : Convert.ToDecimal(txt_importe.Text).ToString("0.00");
            dgw_det.Rows.Add(txt_cod2.Text, cbo_nivel.SelectedValue.ToString(), cbo_nivel.Text, txt_cod3.Text, txt_desc3.Text, importe, porciento, txt_cuota.Text);
            Panel1.Visible = false;
            btn_agregar1.Focus();
        }
        private bool validaGuardarModificar(string op)
        {
            bool result = true;

            if (cbo_nivel.SelectedIndex == -1)
            {
                MessageBox.Show("Elija un Nivel !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_nivel.Focus();
                return result = false;
            }
            if (txt_cod3.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el Código !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_cod3.Focus();
                return result = false;
            }
            if (txt_desc3.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el Nombre !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_desc3.Focus();
                return result = false;
            }
            if (txt_importe.Text.Trim() == "" && txtPorcentaje.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el Importe o el Porcentaje !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_importe.Focus();
                return result = false;
            }
            if (txt_cuota.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese la Cuota !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_cuota.Focus();
                return result = false;
            }
            if (op == "guardar")
            {
                foreach (DataGridViewRow row in dgw_det.Rows)
                {
                    if ((row.Cells["cod_nivel"].Value.ToString() == cbo_nivel.SelectedValue.ToString()) && (row.Cells["cuota0"].Value.ToString() == txt_cuota.Text.Trim()))
                    {
                        MessageBox.Show("El Nivel y la Cuota ya existe en la lista !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txt_cod2.Focus();
                        return result = false;
                    }
                }
            }

            return result;
        }

        private void btn_mod1_Click(object sender, EventArgs e)
        {
            if (!validaGuardarModificar("modificar"))
                return;
            string porciento = txtPorcentaje.Text == "" ? "0.00" : Convert.ToDecimal(txtPorcentaje.Text).ToString("0.00");
            string importe = txt_importe.Text == "" ? "0.00" : Convert.ToDecimal(txt_importe.Text).ToString("0.00");
            dgw_det.CurrentRow.Cells["cod_nivel"].Value = cbo_nivel.SelectedValue.ToString();
            dgw_det.CurrentRow.Cells["cod_per_sup"].Value = txt_cod3.Text;
            dgw_det.CurrentRow.Cells["nom_per_sup"].Value = txt_desc3.Text;
            dgw_det.CurrentRow.Cells["importe0"].Value = importe;
            dgw_det.CurrentRow.Cells["porcentaje0"].Value = porciento;
            dgw_det.CurrentRow.Cells["cuota0"].Value = txt_cuota.Text;
            Panel1.Visible = false;
        }

        private void btn_cancelar2_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
        }

        private void dgw_per3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int idx = dgw_per3.CurrentRow.Index;
                txt_cod3.Text = dgw_per3[0, idx].Value.ToString();
                txt_desc3.Text = dgw_per3[1, idx].Value.ToString();
                panel_per3.Visible = false;
                GroupBox4.Select();
                //VerificaNumeracionContrato();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                //Panel_PER.Visible = false;
                panel_per3.Visible = false;
                txt_cod3.Clear();
                txt_desc3.Clear();
                //txt_doc_per.Clear();
                //txt_cod2.Focus();

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

        private void txt_importe_Leave(object sender, EventArgs e)
        {

        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (!validaGuardar("guardar"))
                return;

            DialogResult rs = MessageBox.Show("¿ Esta seguro de Grabar ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                comTo.TIPO = cbo_tipo_planilla.SelectedValue.ToString();
                comTo.COD_PROGRAMA = cbo_prog.SelectedValue.ToString();
                comTo.COD_INSTITUCION = Convert.ToString(cboInstituciones.SelectedValue);
                comTo.COD_NIVEL_INSTITUCION = Convert.ToString(cboNivelInstituciones.SelectedValue);
                comTo.COD_PER = txt_cod2.Text;
                comTo.NOM_PER = txt_desc2.Text;
                comTo.FECHA = DateTime.Now;
                comTo.COD_CREA = COD_USU;
                comTo.FECHA_CREA = DateTime.Now;
                DataTable dtDetalle = HelpersBLL.obtenerDT(dgw_det);
                calculaMontos(dtDetalle);//calcula el monto propio y de terceros
                comTo.MONTO_PROPIO = sumMontoPropio;
                comTo.MONTO_TERCEROS = sumMontoTerceros;
                if (!comBLL.grabarMaestroComisionesBLL(comTo, dtDetalle, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    dgw1.Rows.Add(comTo.TIPO, comTo.COD_PROGRAMA, comTo.COD_PER, comTo.COD_INSTITUCION, cboInstituciones.Text, comTo.COD_NIVEL_INSTITUCION,
                        cboNivelInstituciones.Text, comTo.NOM_PER, comTo.MONTO_PROPIO, comTo.MONTO_TERCEROS);
                    sumaTotales();
                    lbl_nro_reg_docs.Text = "Nro de Registros : " + dgw1.Rows.Count.ToString();
                    TabControl1.SelectedTab = TabPage1;
                }
            }
        }
        private void sumaTotales()
        {
            txtTotMontoPropio.Text = Convert.ToString(dgw1.Rows.Cast<DataGridViewRow>().Sum(x => Convert.ToDecimal(x.Cells["monto_tot_propio"].Value)));
            txtTotMontoTerceros.Text = Convert.ToString(dgw1.Rows.Cast<DataGridViewRow>().Sum(x => Convert.ToDecimal(x.Cells["monto_tot_terceros"].Value)));
        }
        private void calculaMontos(DataTable dt)
        {
            sumMontoPropio = 0; sumMontoTerceros = 0;
            foreach (DataRow rw in dt.Rows)
            {
                if (rw["cod_nivel"].ToString() == "04")//vendedor, monto propio
                    sumMontoPropio += Convert.ToDecimal(rw["importe0"]);
                else
                    sumMontoTerceros += Convert.ToDecimal(rw["importe0"]);
            }
        }
        private bool validaGuardar(string op)
        {
            bool result = true;

            if (dgw_det.Rows.Count <= 0)
            {
                MessageBox.Show("No hay personas para comisionar !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return result = false;
            }
            if (cbo_tipo_planilla.SelectedIndex == -1)
            {
                MessageBox.Show("Elija la Planilla !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_tipo_planilla.Focus();
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
                MessageBox.Show("Ingrese el Código del Vendedor !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_cod2.Focus();
                return result = false;
            }
            //
            if (op == "guardar")
            {
                foreach (DataGridViewRow row in dgw1.Rows)
                {
                    if (row.Cells["tipo"].Value.ToString() == Convert.ToString(cbo_tipo_planilla.SelectedValue) && row.Cells["cod_programa"].Value.ToString() == Convert.ToString(cbo_prog.SelectedValue) &&
                        row.Cells["cod_pers"].Value.ToString() == txt_cod2.Text.Trim() && row.Cells["COD_INSTITUCION"].Value.ToString() == Convert.ToString(cboInstituciones.SelectedValue) &&
                        row.Cells["COD_NIVEL_INSTITUCION"].Value.ToString() == Convert.ToString(cboNivelInstituciones.SelectedValue))
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

        private void txt_cuota_Leave(object sender, EventArgs e)
        {
            txt_cuota.Text = HelpersBLL.OBTIENE_CODIGO(3, txt_cuota.Text);
            if (txt_cuota.Text == "000")
                lblCuota.Text = "a la firma del contrato";
            else
                lblCuota.Text = "Cuota Nro " + txt_cuota.Text.Substring(1, 2);
        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            boton = "MODIFICAR";
            LIMPIAR_CABECERA();
            btn_guardar.Visible = false;
            btn_modificar2.Visible = true;
            cbo_tipo_planilla.Enabled = false;
            cbo_prog.Enabled = false;
            txt_cod2.Enabled = false;
            txt_desc2.Enabled = false;
            cboInstituciones.Enabled = false;
            cboNivelInstituciones.Enabled = false;
            CARGAR_CABECERA();
            CARGAR_DETALLES();
            obtenerdtJerarquia();
            TabControl1.SelectedTab = TabPage2;
            btn_agregar1.Focus();
        }
        private void CARGAR_DETALLES()
        {
            comisionesDetalleBLL codBLL = new comisionesDetalleBLL();
            comisionesDetalleTo codTo = new comisionesDetalleTo();
            dgw_det.Rows.Clear();
            codTo.TIPO = dgw1.CurrentRow.Cells["tipo"].Value.ToString();
            codTo.COD_PROGRAMA = dgw1.CurrentRow.Cells["cod_programa"].Value.ToString();
            codTo.COD_PER = dgw1.CurrentRow.Cells["cod_pers"].Value.ToString();
            codTo.COD_INSTITUCION = Convert.ToString(dgw1.CurrentRow.Cells["COD_INSTITUCION"].Value);
            codTo.COD_NIVEL_INSTITUCION = Convert.ToString(dgw1.CurrentRow.Cells["COD_NIVEL_INSTITUCION"].Value);
            DataTable dtDet = codBLL.obtenerComisionesDetalleBLL(codTo);
            foreach (DataRow rw in dtDet.Rows)
            {
                int rowId = dgw_det.Rows.Add();
                DataGridViewRow row = dgw_det.Rows[rowId];
                row.Cells["cod_per0"].Value = rw["COD_PER"].ToString();
                row.Cells["cod_nivel"].Value = rw["COD_NIVEL"].ToString();
                row.Cells["nom_nivel"].Value = rw["NOM_NIVEL"].ToString();
                row.Cells["cod_per_sup"].Value = rw["COD_PER_SUP"].ToString();
                row.Cells["nom_per_sup"].Value = rw["NOM_PER_SUP"].ToString();
                row.Cells["importe0"].Value = rw["IMPORTE"].ToString();
                row.Cells["porcentaje0"].Value = rw["PORCENTAJE"].ToString();
                row.Cells["cuota0"].Value = rw["CUOTA"].ToString();
            }
        }
        private void CARGAR_CABECERA()
        {
            if (dgw1.Rows.Count > 0)
            {
                cbo_tipo_planilla.SelectedValue = dgw1.CurrentRow.Cells["tipo"].Value;
                cbo_prog.SelectedValue = dgw1.CurrentRow.Cells["cod_programa"].Value;
                txt_cod2.Text = dgw1.CurrentRow.Cells["cod_pers"].Value.ToString();
                txt_desc2.Text = dgw1.CurrentRow.Cells["nom_pers"].Value.ToString();
                cboInstituciones.SelectedValue = dgw1.CurrentRow.Cells["COD_INSTITUCION"].Value;
                CARGAR_NIVEL_INSTITUCIONES();
                cboNivelInstituciones.SelectedValue = dgw1.CurrentRow.Cells["COD_NIVEL_INSTITUCION"].Value;
            }
        }

        private void btn_modificar2_Click(object sender, EventArgs e)
        {
            if (!validaGuardar("modificar"))
                return;

            DialogResult rs = MessageBox.Show("¿ Esta seguro de Grabar ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                comTo.TIPO = cbo_tipo_planilla.SelectedValue.ToString();
                comTo.COD_PROGRAMA = cbo_prog.SelectedValue.ToString();
                comTo.COD_PER = txt_cod2.Text;
                comTo.COD_INSTITUCION = Convert.ToString(cboInstituciones.SelectedValue);
                comTo.COD_NIVEL_INSTITUCION = Convert.ToString(cboNivelInstituciones.SelectedValue);
                comTo.NOM_PER = txt_desc2.Text;
                comTo.FECHA = DateTime.Now;
                comTo.COD_CREA = COD_USU;
                comTo.FECHA_CREA = DateTime.Now;
                comTo.COD_MOD = COD_USU;
                comTo.FECHA_MOD = DateTime.Now;
                DataTable dtDetalle = HelpersBLL.obtenerDT(dgw_det);
                calculaMontos(dtDetalle);//calcula el monto propio y de terceros
                comTo.MONTO_PROPIO = sumMontoPropio;
                comTo.MONTO_TERCEROS = sumMontoTerceros;
                if (!comBLL.actualizarMaestroComisionesBLL(comTo, dtDetalle, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    dgw1.CurrentRow.Cells["monto_tot_propio"].Value = sumMontoPropio;
                    dgw1.CurrentRow.Cells["monto_tot_terceros"].Value = sumMontoTerceros;
                    sumaTotales();
                    TabControl1.SelectedTab = TabPage1;
                }
            }
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (dgw1.Rows.Count <= 0)
                return;

            DialogResult rs = MessageBox.Show("¿ Esta seguro de Eliminar el registro y todo su detalle ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                comTo.TIPO = dgw1.CurrentRow.Cells["tipo"].Value.ToString();
                comTo.COD_PROGRAMA = dgw1.CurrentRow.Cells["cod_programa"].Value.ToString();
                comTo.COD_PER = dgw1.CurrentRow.Cells["cod_pers"].Value.ToString();
                comTo.COD_INSTITUCION = Convert.ToString(dgw1.CurrentRow.Cells["COD_INSTITUCION"].Value);
                comTo.COD_NIVEL_INSTITUCION = Convert.ToString(dgw1.CurrentRow.Cells["COD_NIVEL_INSTITUCION"].Value);
                if (!comBLL.finiquitarMaestroComisionesBLL(comTo, ref errMensaje))
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

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            TabControl1.SelectedTab = TabPage1;
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

                    cbo_tipo_planilla.Enabled = false;
                    cbo_prog.Enabled = false;
                    txt_cod2.ReadOnly = true;
                    txt_desc2.ReadOnly = true;
                    btn_guardar.Visible = false;
                    btn_modificar2.Visible = false;
                }
            }
            else
                btn_nuevo.Select();
        }

        private void txt_desc2_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbo_prog_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txt_cod2_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel_per3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gb_oc_Enter(object sender, EventArgs e)
        {

        }

        private void cbo_tipo_planilla_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboInstituciones_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CARGAR_NIVEL_INSTITUCIONES();
        }
        private void CARGAR_NIVEL_INSTITUCIONES()
        {
            cboNivelInstituciones.DataSource = null;
            inTo.CODIGO = Convert.ToString(cboInstituciones.SelectedValue);
            DataTable dt = inBLL.obtenerInstitucionesNivelesBLL(inTo);
            if (dt.Rows.Count > 0)
            {
                cboNivelInstituciones.ValueMember = "CODIGO";
                cboNivelInstituciones.DisplayMember = "DESCRIPCION";
                cboNivelInstituciones.DataSource = dt;
                //cboNivelInstituciones.SelectedIndex = 0;
            }
        }

        private void txt_importe_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel_per2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Label11_Click(object sender, EventArgs e)
        {

        }

    }
}
