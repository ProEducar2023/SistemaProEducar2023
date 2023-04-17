using BLL;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;

namespace Presentacion.MOD_CXC
{
    public partial class MANTENIMIENTO_CAMBIO_PUNTO_COBRANZA : Form
    {
        string AÑO = "", MES = "", COD_USU = "";
        HelpersBLL helBLL = new HelpersBLL();
        HelpersTo helTo = new HelpersTo();
        DataTable dtPersona; DataTable dtPersona_cli;
        cambioPuntoCobranzaBLL cpcBLL = new cambioPuntoCobranzaBLL();
        cambioPuntoCobranzaTo cpcTo = new cambioPuntoCobranzaTo();
        string COD_INSTITU = ""; string COD_INSTITU_CLI; int COD_CAMBIO_PTO_COB; string PTO_COB_ANT;
        public MANTENIMIENTO_CAMBIO_PUNTO_COBRANZA(string AÑO, string MES, string COD_USU)
        {
            InitializeComponent();
            this.COD_USU = COD_USU;
            this.MES = MES;
            this.AÑO = AÑO;
        }

        private void MANTENIMIENTO_CAMBIO_PUNTO_COBRANZA_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            DATAGRID();
            CARGAR_PERSONAS();
            CARGAR_PERSONAS_CLI();
            CARGAR_AUTORIZADOS();
            dtp_fe_cambio.Value = Convert.ToDateTime(DateTime.Now.Day + "/" + MES + "/" + AÑO);
        }
        private void MANTENIMIENTO_CAMBIO_PUNTO_COBRANZA_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }
        private void DATAGRID()
        {
            DataTable dt = cpcBLL.obtenerCambioPuntoCobranzaBLL();
            if (dt.Rows.Count > 0)
            {
                dgv_generados.Rows.Clear();
                foreach (DataRow rw in dt.Rows)
                {
                    int rowId = dgv_generados.Rows.Add();
                    DataGridViewRow row = dgv_generados.Rows[rowId];
                    row.Cells["ID_CAMBIO_PTO_COB"].Value = rw["ID_CAMBIO_PTO_COB"].ToString();
                    row.Cells["COD_PER"].Value = rw["COD_PER"].ToString();
                    row.Cells["DESC_PER"].Value = rw["DESC_PER"].ToString();
                    row.Cells["NRO_DOC"].Value = rw["NRO_DOC"].ToString();
                    row.Cells["DESC_PTO_COB2"].Value = rw["DESC_PTO_COB2"].ToString();//PTO COB ANTERIOR
                    row.Cells["COD_PTO_COB_ANT"].Value = rw["COD_PTO_COB_ANT"].ToString();
                    row.Cells["COD_PTO_COB"].Value = rw["COD_PTO_COB"].ToString();//PTO COB CON EL QUE CAMBIA
                    row.Cells["DESC_PTO_COB"].Value = rw["DESC_PTO_COB"].ToString();
                    row.Cells["FE_COD_PTO_COB"].Value = Convert.ToDateTime(rw["FE_COD_PTO_COB"]).Date;
                    row.Cells["AUTORIZADO"].Value = rw["AUTORIZADO"].ToString();
                    row.Cells["DESCRIPCION"].Value = rw["DESCRIPCION"].ToString();
                    row.Cells["OBSERVACIONES"].Value = rw["OBSERVACIONES"].ToString();
                    row.Cells["COD_INSTITUCION2"].Value = rw["COD_INSTITUCION"].ToString();
                    row.Cells["DESC_INSTITUCION"].Value = rw["DESC_INST"].ToString();
                    row.Cells["DES_PROCESO"].Value = rw["DES_PROCESO"].ToString();
                    row.Cells["COD_DESCUENTO"].Value = rw["COD_DESCUENTO"].ToString();
                }
            }
        }
        private void CARGAR_PUNTOS_COBRANZA(string cod_institucion)
        {
            puntoCobranzaBLL ptoBLL = new puntoCobranzaBLL();
            puntoCobranzaTo ptoTo = new puntoCobranzaTo();
            ptoTo.STATUS_CONSOLIDADO = true;
            ptoTo.COD_INSTITUCION = cod_institucion;
            DataTable dt = ptoBLL.obtenerPuntosCobranzaBLL(ptoTo);
            cbo_pto_cob_nuevo.ValueMember = "COD_PTO_COB";
            cbo_pto_cob_nuevo.DisplayMember = "DESC_PTO_COB";
            cbo_pto_cob_nuevo.DataSource = dt;
            cbo_pto_cob_nuevo.SelectedIndex = -1;
        }
        private void CARGAR_CONTRATOS_X_COD_PER(string codigo_persona)
        {
            contratoCabeceraBLL contratosBLL = new contratoCabeceraBLL();
            contratoCabeceraTo contratosTo = new contratoCabeceraTo();
            contratosTo.COD_PER = codigo_persona;
            DataTable dtContratos = contratosBLL.obtenerContratosxCodPersonaBLL(contratosTo);
            if (dtContratos.Rows.Count > 0)
            {
                cbo_contratos.ValueMember = "NRO_PRESUPUESTO";
                cbo_contratos.DisplayMember = "NRO_PRESUPUESTO";
                cbo_contratos.DataSource = dtContratos;
            }
        }
        private void CARGAR_AUTORIZADOS()
        {
            directorioBLL dirBLL = new directorioBLL();
            directorioTo dirTo = new directorioTo();
            dirTo.TABLA_COD = "TAPR";
            DataTable dt = dirBLL.MOSTRAR_APROBADORES_CAMBIO_PTO_COB_BLL(dirTo);
            if (dt.Rows.Count > 0)
            {
                cbo_autorizado.ValueMember = "CODIGO";
                cbo_autorizado.DisplayMember = "DESCRIPCION";
                cbo_autorizado.DataSource = dt;
                cbo_autorizado.SelectedIndex = -1;
            }
        }
        private void CARGAR_PERSONAS()
        {
            //helTo.CODIGO = "04";//VENDEDORES
            dtPersona = helBLL.MOSTRAR_PERSONAS_PARA_CAMBIO_PTO_COB_BLL();
            if (dtPersona.Rows.Count > 0)
            {
                dgw_per.DataSource = dtPersona;
                dgw_per.Columns["COD_PER"].HeaderText = "Codigo";
                dgw_per.Columns["COD_PER"].Width = 50;
                dgw_per.Columns["DESC_PER"].HeaderText = "Nombre de Persona";
                dgw_per.Columns["DESC_PER"].Width = 230;
                dgw_per.Columns["NRO_DOC"].HeaderText = "DNI / RUC";
                dgw_per.Columns["NRO_DOC"].Width = 70;
                dgw_per.Columns["NRO_PRESUPUESTO"].HeaderText = "Contrato";
                dgw_per.Columns["NRO_PRESUPUESTO"].Width = 70;
                dgw_per.Columns["DESC_PROGRAMA"].HeaderText = "Programa";
                dgw_per.Columns["DESC_PROGRAMA"].Width = 120;
                //dgw_per.Columns["COD_PROGRAMA"].Visible = false;
                dgw_per.Columns["COD_SUCURSAL"].Visible = false;
                dgw_per.Columns["COD_INSTITUCION"].Visible = false;
                //dgw_per.Columns["COD_CANAL_DSCTO"].Visible = false;
                dgw_per.Columns["IMP_DOC"].Visible = false;
                dgw_per.Columns["COD_PTO_COB"].Visible = false;
                dgw_per.Columns["DESC_PTO_COB"].Visible = false;
                dgw_per.Columns["DESC_INST"].Visible = false;
                dgw_per.Columns["DES_PROCESO"].Visible = true;
            }
        }
        private void CARGAR_PERSONAS_CLI()
        {
            //helTo.CODIGO = "04";//VENDEDORES
            dtPersona_cli = helBLL.MOSTRAR_PERSONAS_PARA_CAMBIO_PTO_COB_BLL();
            if (dtPersona_cli.Rows.Count > 0)
            {
                dgw_per_cli.DataSource = dtPersona;
                dgw_per_cli.Columns["COD_PER"].HeaderText = "Codigo";
                dgw_per_cli.Columns["COD_PER"].Width = 50;
                dgw_per_cli.Columns["DESC_PER"].HeaderText = "Nombre de Persona";
                dgw_per_cli.Columns["DESC_PER"].Width = 230;
                dgw_per_cli.Columns["NRO_DOC"].HeaderText = "DNI / RUC";
                dgw_per_cli.Columns["NRO_DOC"].Width = 70;
                dgw_per_cli.Columns["NRO_PRESUPUESTO"].HeaderText = "Contrato";
                dgw_per_cli.Columns["NRO_PRESUPUESTO"].Width = 70;
                dgw_per_cli.Columns["DESC_PROGRAMA"].HeaderText = "Programa";
                dgw_per_cli.Columns["DESC_PROGRAMA"].Width = 120;
                //dgw_per.Columns["COD_PROGRAMA"].Visible = false;
                dgw_per_cli.Columns["COD_SUCURSAL"].Visible = false;
                dgw_per_cli.Columns["COD_INSTITUCION"].Visible = false;
                //dgw_per.Columns["COD_CANAL_DSCTO"].Visible = false;
                dgw_per_cli.Columns["IMP_DOC"].Visible = false;
                dgw_per_cli.Columns["COD_PTO_COB"].Visible = false;
                dgw_per_cli.Columns["DESC_PTO_COB"].Visible = false;
                dgw_per_cli.Columns["DESC_INST"].Visible = false;
                dgw_per_cli.Columns["DES_PROCESO"].Visible = true;
            }
        }
        private void dgw_per_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int idx = dgw_per.CurrentRow.Index;
                TXT_COD.Text = dgw_per[0, idx].Value.ToString();
                TXT_DESC.Text = dgw_per[1, idx].Value.ToString();
                txt_doc_per.Text = dgw_per[2, idx].Value.ToString();
                COD_INSTITU = dgw_per.CurrentRow.Cells["COD_INSTITUCION"].Value.ToString();
                txt_desc_institucion.Text = dgw_per.CurrentRow.Cells["DESC_INST"].Value.ToString();
                //cbo_contratos.Items.Clear();
                //var contratos = dgw_per.Rows.Cast<DataGridViewRow>().Where(x => x.Cells["COD_PER"].Value.ToString() == TXT_COD.Text).Select(x => x.Cells["NRO_PRESUPUESTO"].Value).ToList();
                //cbo_contratos.DataSource = contratos;
                CARGAR_PUNTOS_COBRANZA(COD_INSTITU);
                CARGAR_CONTRATOS_X_COD_PER(TXT_COD.Text);
                PTO_COB_ANT = dgw_per.CurrentRow.Cells["COD_PTO_COB"].Value.ToString();
                txt_pto_cob_actual.Text = dgw_per.CurrentRow.Cells["DESC_PTO_COB"].Value.ToString();
                cbo_pto_cob_nuevo.SelectedValue = PTO_COB_ANT;
                txt_cod_descuento.Text = dgw_per.CurrentRow.Cells["DES_PROCESO"].Value.ToString();
                Panel_PER.Visible = false;
                VALIDA_COD_DESCUENTO(COD_INSTITU);
                dtp_fe_cambio.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Panel_PER.Visible = false;
                TXT_COD.Clear();
                TXT_DESC.Clear();
                txt_doc_per.Clear();
                TXT_COD.Focus();
            }
        }

        private void TXT_COD_Leave(object sender, EventArgs e)
        {
            if (TXT_COD.Text.Trim() != "")
            {
                if (dgw_per.Rows.Count > 0)
                {
                    dgw_per.Sort(dgw_per.Columns[0], System.ComponentModel.ListSortDirection.Ascending);
                    int i = 0, num2 = 0;
                    num2 = dgw_per.Rows.Count - 1;
                    do
                    {
                        if (TXT_COD.Text.ToLower() == dgw_per[0, i].Value.ToString().ToLower())
                        {
                            TXT_COD.Text = dgw_per[0, i].Value.ToString();
                            TXT_DESC.Text = dgw_per[1, i].Value.ToString();
                            txt_doc_per.Text = dgw_per[2, i].Value.ToString();
                            txt_pto_cob_actual.Text = dgw_per.CurrentRow.Cells["DESC_PTO_COB"].Value.ToString();
                            dtp_fe_cambio.Focus();
                            return;
                        }
                        if (TXT_COD.Text.ToLower() == dgw_per[0, i].Value.ToString().ToLower().Substring(0, TXT_COD.TextLength))
                        {
                            dgw_per.CurrentCell = dgw_per.Rows[i].Cells[0];
                            break;
                        }
                        dgw_per.CurrentCell = dgw_per.Rows[0].Cells[0];
                        i += 1;
                    }
                    while (i <= num2);
                    Panel_PER.BringToFront();
                    Panel_PER.Visible = true;
                    dgw_per.Visible = true;
                    dgw_per.Focus();
                }
            }
        }

        private void TXT_DESC_Leave(object sender, EventArgs e)
        {
            if (TXT_DESC.Text == "")
            {
                txt_doc_per.Focus();
            }
            else
            {
                if (dgw_per.Rows.Count > 0)
                {
                    dgw_per.Sort(dgw_per.Columns[1], System.ComponentModel.ListSortDirection.Ascending);
                    int i = 0, num2 = 0;
                    num2 = dgw_per.Rows.Count;
                    do
                    {
                        if (dgw_per[1, i].Value.ToString().Length >= TXT_DESC.TextLength)
                        {
                            if (TXT_DESC.Text.ToLower() == dgw_per[1, i].Value.ToString().ToLower().Substring(0, TXT_DESC.TextLength).ToLower())
                            {
                                dgw_per.CurrentCell = dgw_per.Rows[i].Cells[0];
                                break;
                            }
                        }
                        dgw_per.CurrentCell = dgw_per.Rows[0].Cells[0];
                        i += 1;
                    }
                    while (i < num2);
                    Panel_PER.Visible = true;
                    dgw_per.Visible = true;
                    dgw_per.Focus();
                }
            }
        }

        private void txt_doc_per_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_doc_per.Text.Trim() == "")
                {
                    Panel_PER.Visible = false;
                }//Gestion Comercial/compras/servicio/requiriento de servicio
                else if (dgw_per.Rows.Count > 0)
                {
                    DataRow[] rs = dtPersona.Select("NRO_DOC = '" + txt_doc_per.Text.Trim() + "'");
                    if (rs.Length > 0)
                    {
                        dgw_per.Sort(dgw_per.Columns[2], System.ComponentModel.ListSortDirection.Ascending);
                        int i = 0, num2 = 0;
                        num2 = dgw_per.Rows.Count;
                        do
                        {
                            if (dgw_per[2, i].Value.ToString().Length >= txt_doc_per.TextLength)
                            {
                                if (txt_doc_per.Text.ToLower() == dgw_per[2, i].Value.ToString().ToLower().Substring(0, txt_doc_per.TextLength).ToLower())
                                {
                                    dgw_per.CurrentCell = dgw_per.Rows[i].Cells[0];
                                    break;
                                }
                            }
                            dgw_per.CurrentCell = dgw_per.Rows[0].Cells[0];
                            i += 1;
                        }
                        while (i < num2);
                        Panel_PER.Visible = true;
                        dgw_per.Visible = true;
                        dgw_per.Focus();
                    }
                    else
                    {
                        Panel_PER.Visible = false;
                    }
                }
            }
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            btn_grabar.Visible = true;
            btn_modificar2.Visible = false;
            TabControl1.SelectedTab = (TabPage2);
            LIMPIAR();
            lbl_cob.Text = "Pto de Cob Actual";
            btn_grabar.Enabled = true;
            TXT_COD.Focus();
        }
        private void LIMPIAR()
        {
            TXT_COD.Clear();
            TXT_DESC.Clear();
            txt_doc_per.Clear();
            txt_pto_cob_actual.Clear();
            cbo_pto_cob_nuevo.SelectedIndex = -1;
            cbo_autorizado.SelectedIndex = -1;
            txt_observaciones.Clear();
            txt_cod_descuento.Clear();
            txt_desc_institucion.Clear();
            cbo_contratos.SelectedIndex = -1;
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            TabControl1.SelectedTab = (TabPage1);
        }

        private void btn_grabar_Click(object sender, EventArgs e)
        {
            if (!validaFormulario())
                return;
            DialogResult rs = MessageBox.Show("¿ Esta seguro de realizar el cambio de Punto de Cobranza ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                cpcTo.COD_PER = TXT_COD.Text;
                cpcTo.COD_PTO_COB = cbo_pto_cob_nuevo.SelectedValue.ToString();
                cpcTo.FE_COD_PTO_COB = dtp_fe_cambio.Value;
                cpcTo.AUTORIZADO = cbo_autorizado.SelectedValue.ToString();
                cpcTo.OBSERVACIONES = txt_observaciones.Text;
                cpcTo.COD_USU_CREA = COD_USU;
                cpcTo.FECHA_USU_CREA = DateTime.Now;
                cpcTo.COD_PTO_COB_ANT = PTO_COB_ANT;
                cpcTo.COD_DESCUENTO = txt_cod_descuento.Text;
                cpcTo.COD_INSTITUCION = COD_INSTITU;
                if (!cpcBLL.adicionaCambiodePuntoCobranzaBLL(cpcTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("El ingreso se hizo correctamente", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TabControl1.SelectedTab = TabPage1;
                    DATAGRID();
                    rbt_ult_reg.Checked = true;
                    CARGAR_PERSONAS();//para actualizar el grid desplegable
                    //FOCO_NUEVO_REG("grabar");
                }
            }
        }
        private bool validaFormulario()
        {
            bool result = true;
            cpcTo.SIN_CAMBIO_PTO_COB = false;
            if (PTO_COB_ANT == cbo_pto_cob_nuevo.SelectedValue.ToString())
            {
                cpcTo.SIN_CAMBIO_PTO_COB = true;
            }
            if (txt_cod_descuento.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el codigo de descuento !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_cod_descuento.Focus();
                return result = false;
            }
            if (cbo_autorizado.SelectedIndex == -1)
            {
                MessageBox.Show("Elija la persona que autoriza !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_autorizado.Focus();
                return result = false;
            }
            return result;
        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            if (!validaModificar())
                return;
            btn_grabar.Visible = false;
            btn_modificar2.Visible = true;
            TabControl1.SelectedTab = (TabPage2);
            lbl_cob.Text = "Pto de Cob Anterior";
            LIMPIAR();
            btn_grabar.Enabled = false;
            btn_modificar2.Enabled = true;

            CARGAR_CABECERA_DOCUMENTO();

        }
        private void VALIDA_COD_DESCUENTO(string cod_institucion)
        {
            if (cod_institucion == "01")//Ministerio de Educacion
                txt_cod_descuento.ReadOnly = false;
            else
                txt_cod_descuento.ReadOnly = true;
        }
        private bool validaModificar()
        {
            bool result = true;

            return result;
        }
        private void CARGAR_CABECERA_DOCUMENTO()
        {
            COD_CAMBIO_PTO_COB = Convert.ToInt32(dgv_generados.CurrentRow.Cells["ID_CAMBIO_PTO_COB"].Value);
            TXT_COD.Text = dgv_generados.CurrentRow.Cells["COD_PER"].Value.ToString();
            TXT_DESC.Text = dgv_generados.CurrentRow.Cells["DESC_PER"].Value.ToString();
            txt_doc_per.Text = dgv_generados.CurrentRow.Cells["NRO_DOC"].Value.ToString();
            txt_pto_cob_actual.Text = dgv_generados.CurrentRow.Cells["DESC_PTO_COB2"].Value.ToString();
            cbo_autorizado.SelectedValue = dgv_generados.CurrentRow.Cells["AUTORIZADO"].Value;
            txt_observaciones.Text = dgv_generados.CurrentRow.Cells["OBSERVACIONES"].Value.ToString();
            COD_INSTITU = dgv_generados.CurrentRow.Cells["COD_INSTITUCION2"].Value.ToString();
            VALIDA_COD_DESCUENTO(COD_INSTITU);
            CARGAR_PUNTOS_COBRANZA(COD_INSTITU);
            CARGAR_CONTRATOS_X_COD_PER(TXT_COD.Text);
            cbo_pto_cob_nuevo.SelectedValue = dgv_generados.CurrentRow.Cells["COD_PTO_COB"].Value;
            txt_cod_descuento.Text = dgv_generados.CurrentRow.Cells["COD_DESCUENTO"].Value.ToString();
            txt_desc_institucion.Text = dgv_generados.CurrentRow.Cells["DESC_INSTITUCION"].Value.ToString();
            PTO_COB_ANT = dgv_generados.CurrentRow.Cells["COD_PTO_COB_ANT"].Value.ToString();
        }

        private void btn_modificar2_Click(object sender, EventArgs e)
        {
            if (!validaFormulario())
                return;
            DialogResult rs = MessageBox.Show("¿ Esta seguro modificar el cambio de Punto de Cobranza ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                cpcTo.ID_CAMBIO_PTO_COB = COD_CAMBIO_PTO_COB;
                cpcTo.COD_PER = TXT_COD.Text;
                cpcTo.COD_PTO_COB = cbo_pto_cob_nuevo.SelectedValue.ToString();
                cpcTo.FE_COD_PTO_COB = dtp_fe_cambio.Value;
                cpcTo.AUTORIZADO = cbo_autorizado.SelectedValue.ToString();
                cpcTo.OBSERVACIONES = txt_observaciones.Text;
                cpcTo.COD_USU_CREA = COD_USU;
                cpcTo.FECHA_USU_CREA = DateTime.Now;
                cpcTo.COD_PTO_COB_ANT = PTO_COB_ANT;
                cpcTo.COD_DESCUENTO = txt_cod_descuento.Text;
                cpcTo.COD_INSTITUCION = COD_INSTITU;
                if (!cpcBLL.modificaCambiodePuntoCobranzaBLL(cpcTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("La modificación se hizo correctamente", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TabControl1.SelectedTab = TabPage1;
                    DATAGRID();
                    //FOCO_NUEVO_REG();
                }
            }
        }

        private void lkl_kardex_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (cbo_contratos.SelectedIndex != -1)
            {
                string nro_contrato = cbo_contratos.SelectedValue.ToString();
                MOD_COMISIONES.CONSULTA_KARDEX_X_CONTRATO frm = new MOD_COMISIONES.CONSULTA_KARDEX_X_CONTRATO(nro_contrato);
                frm.ShowDialog();
            }
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void DATAGRID_PERSONA()
        {
            cpcTo.COD_PER = txt_cod_cli.Text;
            DataTable dt = cpcBLL.obtenerCambioPuntoCobranzaxPersonaBLL(cpcTo);
            if (dt.Rows.Count > 0)
            {
                dgv_generados.Rows.Clear();
                foreach (DataRow rw in dt.Rows)
                {
                    int rowId = dgv_generados.Rows.Add();
                    DataGridViewRow row = dgv_generados.Rows[rowId];
                    row.Cells["ID_CAMBIO_PTO_COB"].Value = rw["ID_CAMBIO_PTO_COB"].ToString();
                    row.Cells["COD_PER"].Value = rw["COD_PER"].ToString();
                    row.Cells["DESC_PER"].Value = rw["DESC_PER"].ToString();
                    row.Cells["NRO_DOC"].Value = rw["NRO_DOC"].ToString();
                    row.Cells["DESC_PTO_COB2"].Value = rw["DESC_PTO_COB2"].ToString();//PTO COB ANTERIOR
                    row.Cells["COD_PTO_COB_ANT"].Value = rw["COD_PTO_COB_ANT"].ToString();
                    row.Cells["COD_PTO_COB"].Value = rw["COD_PTO_COB"].ToString();//PTO COB CON EL QUE CAMBIA
                    row.Cells["DESC_PTO_COB"].Value = rw["DESC_PTO_COB"].ToString();
                    row.Cells["FE_COD_PTO_COB"].Value = Convert.ToDateTime(rw["FE_COD_PTO_COB"]).Date;
                    row.Cells["AUTORIZADO"].Value = rw["AUTORIZADO"].ToString();
                    row.Cells["DESCRIPCION"].Value = rw["DESCRIPCION"].ToString();
                    row.Cells["OBSERVACIONES"].Value = rw["OBSERVACIONES"].ToString();
                    row.Cells["COD_INSTITUCION2"].Value = rw["COD_INSTITUCION"].ToString();
                    row.Cells["DESC_INSTITUCION"].Value = rw["DESC_INST"].ToString();
                    row.Cells["DES_PROCESO"].Value = rw["DES_PROCESO"].ToString();
                    row.Cells["COD_DESCUENTO"].Value = rw["COD_DESCUENTO"].ToString();
                }
            }
        }

        private void dgw_per_cli_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int idx = dgw_per_cli.CurrentRow.Index;
                txt_cod_cli.Text = dgw_per_cli[0, idx].Value.ToString();
                txt_nom_cli.Text = dgw_per_cli[1, idx].Value.ToString();
                txt_dni_cli.Text = dgw_per_cli[2, idx].Value.ToString();
                COD_INSTITU_CLI = dgw_per_cli.CurrentRow.Cells["COD_INSTITUCION"].Value.ToString();
                DATAGRID_PERSONA();
                panel_cli.Visible = false;
                //txt_observaciones.Focus();
                dgv_generados.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                panel_cli.Visible = false;
                txt_cod_cli.Clear();
                txt_nom_cli.Clear();
                txt_dni_cli.Clear();
                txt_cod_cli.Focus();
            }
        }

        private void txt_cod_cli_Leave(object sender, EventArgs e)
        {
            if (txt_cod_cli.Text.Trim() != "")
            {
                if (dgw_per_cli.Rows.Count > 0)
                {
                    dgw_per_cli.Sort(dgw_per_cli.Columns[0], System.ComponentModel.ListSortDirection.Ascending);
                    int i = 0, num2 = 0;
                    num2 = dgw_per_cli.Rows.Count - 1;
                    do
                    {
                        if (txt_cod_cli.Text.ToLower() == dgw_per_cli[0, i].Value.ToString().ToLower())
                        {
                            txt_cod_cli.Text = dgw_per_cli[0, i].Value.ToString();
                            txt_nom_cli.Text = dgw_per_cli[1, i].Value.ToString();
                            txt_dni_cli.Text = dgw_per_cli[2, i].Value.ToString();
                            //txt_pto_cob_actual.Text = dgw_per_cli.CurrentRow.Cells["DESC_PTO_COB"].Value.ToString();
                            //dtp_fe_cambio.Focus();
                            return;
                        }
                        if (txt_cod_cli.Text.ToLower() == dgw_per_cli[0, i].Value.ToString().ToLower().Substring(0, txt_cod_cli.TextLength))
                        {
                            dgw_per_cli.CurrentCell = dgw_per_cli.Rows[i].Cells[0];
                            break;
                        }
                        dgw_per_cli.CurrentCell = dgw_per_cli.Rows[0].Cells[0];
                        i += 1;
                    }
                    while (i <= num2);
                    panel_cli.BringToFront();
                    panel_cli.Visible = true;
                    dgw_per_cli.Visible = true;
                    dgw_per_cli.Focus();
                }
            }
        }

        private void txt_nom_cli_Leave(object sender, EventArgs e)
        {
            if (txt_nom_cli.Text == "")
            {
                txt_dni_cli.Focus();
            }
            else
            {
                if (dgw_per_cli.Rows.Count > 0)
                {
                    dgw_per_cli.Sort(dgw_per_cli.Columns[1], System.ComponentModel.ListSortDirection.Ascending);
                    int i = 0, num2 = 0;
                    num2 = dgw_per_cli.Rows.Count;
                    do
                    {
                        if (dgw_per_cli[1, i].Value.ToString().Length >= txt_nom_cli.TextLength)
                        {
                            if (txt_nom_cli.Text.ToLower() == dgw_per_cli[1, i].Value.ToString().ToLower().Substring(0, txt_nom_cli.TextLength).ToLower())
                            {
                                dgw_per_cli.CurrentCell = dgw_per_cli.Rows[i].Cells[0];
                                break;
                            }
                        }
                        dgw_per_cli.CurrentCell = dgw_per_cli.Rows[0].Cells[0];
                        i += 1;
                    }
                    while (i < num2);
                    panel_cli.Visible = true;
                    dgw_per_cli.Visible = true;
                    dgw_per_cli.Focus();
                }
            }
        }

        private void txt_dni_cli_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_dni_cli.Text.Trim() == "")
                {
                    panel_cli.Visible = false;
                }//Gestion Comercial/compras/servicio/requiriento de servicio
                else if (dgw_per_cli.Rows.Count > 0)
                {
                    DataRow[] rs = dtPersona_cli.Select("NRO_DOC = '" + txt_dni_cli.Text.Trim() + "'");
                    if (rs.Length > 0)
                    {
                        dgw_per_cli.Sort(dgw_per.Columns[2], System.ComponentModel.ListSortDirection.Ascending);
                        int i = 0, num2 = 0;
                        num2 = dgw_per_cli.Rows.Count;
                        do
                        {
                            if (dgw_per_cli[2, i].Value.ToString().Length >= txt_cod_cli.TextLength)
                            {
                                if (txt_dni_cli.Text.ToLower() == dgw_per_cli[2, i].Value.ToString().ToLower().Substring(0, txt_dni_cli.TextLength).ToLower())
                                {
                                    dgw_per_cli.CurrentCell = dgw_per_cli.Rows[i].Cells[0];
                                    break;
                                }
                            }
                            dgw_per_cli.CurrentCell = dgw_per_cli.Rows[0].Cells[0];
                            i += 1;
                        }
                        while (i < num2);
                        panel_cli.Visible = true;
                        dgw_per_cli.Visible = true;
                        dgw_per_cli.Focus();
                    }
                    else
                    {
                        panel_cli.Visible = false;
                    }
                }
            }
        }

        private void rbt_persona_CheckedChanged(object sender, EventArgs e)
        {
            if (rbt_persona.Checked)
            {
                txt_cod_cli.Clear();
                txt_nom_cli.Clear();
                txt_dni_cli.Clear();
                gbx_persona.Enabled = true;
                rbt_ult_reg.Checked = false;
                dgv_generados.Rows.Clear();
            }
        }

        private void rbt_ult_reg_CheckedChanged(object sender, EventArgs e)
        {
            if (rbt_ult_reg.Checked)
            {
                txt_cod_cli.Clear();
                txt_nom_cli.Clear();
                txt_dni_cli.Clear();
                gbx_persona.Enabled = false;
                rbt_ult_reg.Checked = true;
                dgv_generados.Rows.Clear();
                DATAGRID();
            }
        }
    }
}
