using BLL;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;

namespace Presentacion.MOD_CXC
{
    public partial class INPUT_PARA_HACER_DEVOLUCIONES : Form
    {
        string AÑO = "", MES = "", COD_MOD = "", COD_USU = "", TIPO_USU = "";
        DateTime FECHA_INI, FECHA_GRAL;
        HelpersBLL helBLL = new HelpersBLL();
        HelpersTo helTo = new HelpersTo();
        devPCtasCobrarBLL devBLL = new devPCtasCobrarBLL();
        devPCtasCobrarTo devTo = new devPCtasCobrarTo();
        canjeTCtasxCobrarBLL ctcBLL = new canjeTCtasxCobrarBLL();
        canjeTCtasxCobrarTo ctcTo = new canjeTCtasxCobrarTo();
        DataTable dtPersona; DataTable dtTiposPlla;
        decimal monto_pagado = 0; decimal monto_total = 0; decimal monto_x_pagar = 0; decimal monto_comprometido = 0;
        public INPUT_PARA_HACER_DEVOLUCIONES(string AÑO, string MES, DateTime FECHA_INI, DateTime FECHA_GRAL, string COD_MOD, string TIPO_USU, string COD_USU)
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

        private void INPUT_PARA_HACER_DEVOLUCIONES_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            CARGAR_SUCURSAL();
            CARGAR_CLASE();
            CARGAR_PERSONAS("algunos");
            CARGAR_TIPO_PLANILLA();
            DATAGRID();
            CARGAR_MOTIVOS();
            //dtp_fec_doc.Value = Convert.ToDateTime(DateTime.Now.Day + "/" + MES + "/" + AÑO);
            DateTime fe_plla = DateTime.Now;
            if (DateTime.TryParse((DateTime.Now.Day + "/" + MES + "/" + AÑO), out fe_plla))
                dtp_fec_doc.Value = Convert.ToDateTime(DateTime.Now.Day + "/" + MES + "/" + AÑO);
            else
                dtp_fec_doc.Value = FECHA_GRAL;
        }
        private void INPUT_PARA_HACER_DEVOLUCIONES_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }
        private void CARGAR_MOTIVOS()
        {
            motivos_Otros_Dev_DsctosBLL movBLL = new motivos_Otros_Dev_DsctosBLL();
            motivos_Otros_Dev_DsctosTo movTo = new motivos_Otros_Dev_DsctosTo();
            DataTable dt = movBLL.obtenerMotivosOtrosDevDsctosBLL();
            if (dt.Rows.Count > 0)
            {
                cbo_motivo.DataSource = dt;
                cbo_motivo.ValueMember = "COD_MOTIVO_OT_DEV";
                cbo_motivo.DisplayMember = "DESC_MOTIVO_OT_DEV";
                cbo_motivo.SelectedIndex = 0;
            }
        }
        private void DATAGRID()
        {
            devTo.FE_AÑO = AÑO;
            devTo.FE_MES = MES;
            DataTable dt = devBLL.obtenerDevPCtasCobrarIngresoOtrosDevDsctosBLL(devTo);
            if (dt.Rows.Count > 0)
            {
                dgv_generados.Rows.Clear();
                foreach (DataRow rw in dt.Rows)
                {
                    int rowId = dgv_generados.Rows.Add();
                    DataGridViewRow row = dgv_generados.Rows[rowId];
                    row.Cells["NRO_PLANILLA_COB"].Value = rw["NRO_PLANILLA_COB"].ToString();
                    row.Cells["COD_SUCURSAL"].Value = rw["COD_SUCURSAL"].ToString();
                    row.Cells["COD_CLASE"].Value = rw["COD_CLASE"].ToString();
                    row.Cells["NRO_CONTRATO"].Value = rw["NRO_CONTRATO"].ToString();
                    row.Cells["FE_AÑO"].Value = rw["FE_AÑO"].ToString();
                    row.Cells["FE_MES"].Value = rw["FE_MES"].ToString();
                    row.Cells["COD_PER"].Value = rw["COD_PER"].ToString();
                    row.Cells["DESC_PER"].Value = rw["DESC_PER"].ToString();
                    row.Cells["NRO_DOC"].Value = rw["NRO_DOC"].ToString();
                    row.Cells["FECHA_DOC"].Value = rw["FECHA_DOC"].ToString().Substring(0, 10);
                    row.Cells["IMP_DOC"].Value = rw["IMP_DOC"].ToString();
                    row.Cells["COD_MOTIVO_NO_DESCONTADO"].Value = rw["COD_MOTIVO_NO_DESCONTADO"].ToString();
                    row.Cells["TIPO_PLA_COBRANZA"].Value = rw["TIPO_PLA_COBRANZA"].ToString();
                    row.Cells["OBSERVACION"].Value = rw["OBSERVACION"].ToString();
                }
            }
        }
        private void CARGAR_SUCURSAL()
        {
            helTo.CODIGO = COD_USU;
            DataTable dt = helBLL.CBO_SUCURSALBLL(helTo);
            cbo_sucursal.ValueMember = "COD_SUCURSAL";
            cbo_sucursal.DisplayMember = "DESC_sucursal";
            cbo_sucursal.DataSource = dt;
            cbo_sucursal.SelectedIndex = -1;
        }
        private void CARGAR_CLASE()
        {
            HelpersBLL helBLL = new HelpersBLL();
            HelpersTo helTo = new HelpersTo();
            bool validarTipo = true;
            string tipo = "P";
            bool validarDebeHaber = true;
            string debeHaber = "H";

            helTo.CODIGO = TIPO_USU;
            helTo.CODIGO2 = COD_USU;
            helTo.CODIGO3 = validarTipo == true ? "0" : "1";
            helTo.CODIGO4 = tipo;
            helTo.CODIGO5 = validarDebeHaber == true ? "0" : "1";
            helTo.CODIGO6 = debeHaber;
            DataTable dt = helBLL.CBO_CLASE_USU_TIPO_BLL(helTo);
            cbo_clase.ValueMember = "COD_CLASE";
            cbo_clase.DisplayMember = "DESC_CLASE";
            cbo_clase.DataSource = dt;
            cbo_clase.SelectedIndex = 0;
        }
        private void CARGAR_PERSONAS(string opcion)
        {
            //helTo.CODIGO = "04";//VENDEDORES
            if (opcion == "todos")
                dtPersona = helBLL.MOSTRAR_PERSONAS_X_DEVOLUCION_TODOS_BLL();
            else
                dtPersona = helBLL.MOSTRAR_PERSONAS_X_DEVOLUCION_BLL();
            if (dtPersona.Rows.Count > 0)
            {
                dgw_per.DataSource = dtPersona;
                dgw_per.Columns["COD_PER"].HeaderText = "Codigo";
                dgw_per.Columns["COD_PER"].Width = 50;
                dgw_per.Columns["NRO_PRESUPUESTO"].HeaderText = "Contrato";
                dgw_per.Columns["NRO_PRESUPUESTO"].Width = 70;
                dgw_per.Columns["DESC_PER"].HeaderText = "Nombre de Persona";
                dgw_per.Columns["DESC_PER"].Width = 230;
                dgw_per.Columns["NRO_DOC"].HeaderText = "DNI / RUC";
                dgw_per.Columns["NRO_DOC"].Width = 70;
                dgw_per.Columns["IMP_DOC"].Visible = false;
            }

        }
        private void CARGAR_TIPO_PLANILLA()
        {
            tipoPlanillaCreacionBLL tpcBLL = new tipoPlanillaCreacionBLL();
            dtTiposPlla = tpcBLL.obtenerTipoPlanillaCreacionxTransferenciaBLL();
            if (dtTiposPlla.Rows.Count > 0)
            {
                cbo_tipo_planilla.ValueMember = "COD_TIPO_PLLA";
                cbo_tipo_planilla.DisplayMember = "DESC_TIPO";
                cbo_tipo_planilla.DataSource = dtTiposPlla;
                cbo_tipo_planilla.SelectedValue.ToString();
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
                            txt_contrato.Text = dgw_per.Rows[i].Cells["NRO_PRESUPUESTO"].Value.ToString();
                            txt_contrato.Focus();
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
            else
            {
                if (dgw_per.Rows.Count > 0)
                {
                    Panel_PER.BringToFront();
                    Panel_PER.Visible = true;
                    dgw_per.Visible = true;
                    dgw_per.Focus();
                    dgw_per.CurrentCell = dgw_per.Rows[0].Cells[0];
                }
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
                txt_contrato.Text = dgw_per.Rows[idx].Cells["NRO_PRESUPUESTO"].Value.ToString();
                ctcTo.NRO_CONTRATO = txt_contrato.Text;
                string errMensaje = "";
                monto_pagado = ctcBLL.obtenerMontoPagadoxContratoBLL(ctcTo, ref errMensaje);
                monto_total = Convert.ToDecimal(dgw_per.Rows[idx].Cells["IMP_DOC"].Value);
                monto_x_pagar = monto_total - monto_pagado;
                monto_comprometido = ctcBLL.obtenerSumaImporteComprometidosBLL(ctcTo, ref errMensaje);
                lbl_imp_tot_pagado.Text = monto_pagado.ToString("###,###,##0.00");
                lbl_imp_tot_x_pagar.Text = monto_x_pagar.ToString("###,###,##0.00");
                lbl_imp_cuo_comp.Text = monto_comprometido.ToString("###,###,##0.00");
                Panel_PER.Visible = false;
                //MostrarFormaPago();
                txt_contrato.Focus();
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

        private void TXT_DESC_Leave(object sender, EventArgs e)
        {
            if (TXT_DESC.Text == "")
            {
                if (dgw_per.Rows.Count > 0)
                {
                    Panel_PER.Visible = true;
                    dgw_per.Visible = true;
                    //txt_doc_per.Focus();
                    dgw_per.Focus();
                    dgw_per.CurrentCell = dgw_per.Rows[0].Cells[0];

                }

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
                    Panel_PER.Visible = true;
                    dgw_per.Visible = true;
                    dgw_per.Focus();
                    dgw_per.CurrentCell = dgw_per.Rows[0].Cells[0];
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

        private void btn_grabar_Click(object sender, EventArgs e)
        {
            if (!validaFormulario())
                return;
            DialogResult rs = MessageBox.Show("¿ Esta seguro grabar el ingreso de documento ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                devTo.NRO_PLANILLA_COB = txt_ser.Text + "-" + txt_num.Text;
                devTo.SERIE = txt_ser.Text;
                devTo.COD_SUCURSAL = cbo_sucursal.SelectedValue.ToString();
                devTo.COD_CLASE = cbo_clase.SelectedValue.ToString();
                devTo.NRO_CONTRATO = txt_contrato.Text;
                devTo.FE_AÑO = AÑO;
                devTo.FE_MES = MES;
                devTo.COD_PER = TXT_COD.Text;
                devTo.DESC_PER = TXT_DESC.Text;
                devTo.COD_DOC = "60";
                devTo.NRO_DOC = "000000";
                devTo.FECHA_DOC = dtp_fec_doc.Value;
                devTo.FECHA_VEN = null;
                devTo.IMP_INI = Convert.ToDecimal(txt_importe.Text);
                devTo.IMP_DOC = devTo.IMP_INI;
                devTo.COD_MOTIVO_NO_DESCONTADO = cbo_motivo.SelectedValue.ToString();
                devTo.COD_D_H = "D";
                devTo.OBSERVACION = txt_obs.Text;
                devTo.COD_MONEDA = "S";
                devTo.TIPO_OPE = "GF";
                devTo.NRO_LETRA = "000";
                devTo.TOTAL_LETRA = "000";
                devTo.STATUS_GENERADO = "0";
                devTo.STATUS_CANCELADO = "0";
                devTo.TIPO_PLA_ORIGEN = "V";//referido a que viene por hacer un input para generar una planilla de devolucion o descuento especial
                devTo.TIPO_PLA_COBRANZA = cbo_tipo_planilla.SelectedValue.ToString();
                devTo.COD_USU_CREA = COD_USU;
                devTo.FECHA_CREA = DateTime.Now;
                devTo.CUOTA_COMPROMETIDA = chk_app.Checked;
                if (!devBLL.ingresarDevPctasCobrarOtrasDevolucionesDescuentosBLL(devTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("El ingreso se hizo correctamente", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tabControl1.SelectedTab = tabPage1;
                    DATAGRID();
                    FOCO_NUEVO_REG();
                }
            }

        }
        private void FOCO_NUEVO_REG()
        {
            int i, cont = 0;
            cont = dgv_generados.Columns.Count - 1;
            string nrocon = txt_ser.Text + "-" + txt_num.Text.Trim();
            for (i = 0; i <= cont; i++)
            {
                if (nrocon == dgv_generados.Rows[i].Cells["NRO_PLANILLA_COB"].Value.ToString().ToLower())
                {
                    dgv_generados.CurrentCell = dgv_generados.Rows[i].Cells["NRO_PLANILLA_COB"];
                    return;
                }
            }
        }
        private bool validaFormulario()
        {
            bool result = true;
            string status_ctacte;
            DataRow[] rw = dtTiposPlla.Select("COD_TIPO_PLLA='" + Convert.ToString(cbo_tipo_planilla.SelectedValue) + "'");
            status_ctacte = Convert.ToString(rw[0][2]);
            if (!HelpersBLL.esNumeroDecimal(txt_importe.Text, false))
            {
                MessageBox.Show("Importe no válido !!!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_importe.Focus();
                return result = false;
            }
            if (monto_x_pagar < Convert.ToDecimal(txt_importe.Text) && status_ctacte == "1")
            {
                MessageBox.Show("Importe no válido !!!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_importe.Focus();
                return result = false;
            }
            if (cbo_tipo_planilla.SelectedIndex == -1)
            {
                MessageBox.Show("Ingrese el tipo de planilla !!!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_tipo_planilla.Focus();
                return result = false;
            }
            if (cbo_motivo.SelectedIndex == -1)
            {
                MessageBox.Show("Ingrese el motivo !!!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_motivo.Focus();
                return result = false;
            }
            return result;
        }
        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cbo_sucursal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_sucursal.SelectedValue != null)
            {
                obtieneNroPlanilla();
            }
        }
        private void obtieneNroPlanilla()
        {
            serieDocumentoBLL sdoBLL = new serieDocumentoBLL();
            serieDocumentosTo sdoTo = new serieDocumentosTo();
            sdoTo.COD_SUCURSAL = cbo_sucursal.SelectedValue.ToString();
            sdoTo.STATUS_DOC = "0";
            sdoTo.COD_DOC = "60";//OTRAS DEVOLUC ó DESCTOS
            //txt_nro_ini.Text = sdoBLL.obtenerNro_Ing2BLL(sdoTo);
            txt_ser.Text = sdoBLL.OBTENER_SERIE_NRO_BLL(sdoTo).Rows[0]["SERIE"].ToString();
            txt_num.Text = sdoBLL.OBTENER_SERIE_NRO_BLL(sdoTo).Rows[0]["NUMERO"].ToString();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = (tabPage1);
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            btn_grabar.Visible = true;
            btn_modificar2.Visible = false;
            //txt_ser.Visible = trUe;
            tabControl1.SelectedTab = (tabPage2);
            LIMPIAR();
            cbo_sucursal.SelectedIndex = 0;
            //dgv_generados.Rows.Clear();
            btn_grabar.Enabled = true;
            //cbo_sucursal_SelectedIndexChanged(sender, e);
            cbo_sucursal.Focus();
        }
        private void LIMPIAR()
        {
            txt_ser.Clear();
            txt_num.Clear();
            //dtp_fec_doc.Value = Convert.ToDateTime(DateTime.Now.Day + "/" + MES + "/" + AÑO);
            DateTime fe_plla = DateTime.Now;
            if (DateTime.TryParse((DateTime.Now.Day + "/" + MES + "/" + AÑO), out fe_plla))
                dtp_fec_doc.Value = Convert.ToDateTime(DateTime.Now.Day + "/" + MES + "/" + AÑO);
            else
                dtp_fec_doc.Value = FECHA_GRAL;
            cbo_sucursal.SelectedIndex = -1;
            cbo_clase.SelectedIndex = 0;
            TXT_COD.Clear();
            TXT_DESC.Clear();
            txt_doc_per.Clear();
            txt_contrato.Clear();
            txt_importe.Clear();
            cbo_tipo_planilla.SelectedIndex = -1;
            cbo_motivo.SelectedIndex = -1;
            txt_obs.Clear();
            txt_importe.Clear();
        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            //boton = "MODIFICAR";
            btn_grabar.Visible = false;
            btn_modificar2.Visible = true;
            //txt_ser.Visible = true;
            tabControl1.SelectedTab = (tabPage2);
            LIMPIAR();
            btn_grabar.Enabled = true;
            btn_modificar2.Enabled = true;
            CARGAR_DOCUMENTO();
            TXT_COD.Focus();
        }
        private void CARGAR_DOCUMENTO()
        {
            cbo_sucursal.SelectedValue = dgv_generados.CurrentRow.Cells["COD_SUCURSAL"].Value;
            txt_ser.Text = dgv_generados.CurrentRow.Cells["NRO_PLANILLA_COB"].Value.ToString().Substring(0, 3);
            txt_num.Text = dgv_generados.CurrentRow.Cells["NRO_PLANILLA_COB"].Value.ToString().Substring(4, 7);
            dtp_fec_doc.Value = Convert.ToDateTime(dgv_generados.CurrentRow.Cells["FECHA_DOC"].Value);
            cbo_clase.SelectedValue = dgv_generados.CurrentRow.Cells["COD_CLASE"].Value;
            TXT_COD.Text = dgv_generados.CurrentRow.Cells["COD_PER"].Value.ToString();
            TXT_DESC.Text = dgv_generados.CurrentRow.Cells["DESC_PER"].Value.ToString();
            txt_doc_per.Text = dgv_generados.CurrentRow.Cells["NRO_DOC"].Value.ToString();
            txt_contrato.Text = dgv_generados.CurrentRow.Cells["NRO_CONTRATO"].Value.ToString();
            txt_importe.Text = dgv_generados.CurrentRow.Cells["IMP_DOC"].Value.ToString();
            cbo_tipo_planilla.SelectedValue = dgv_generados.CurrentRow.Cells["TIPO_PLA_COBRANZA"].Value;
            cbo_motivo.SelectedValue = dgv_generados.CurrentRow.Cells["COD_MOTIVO_NO_DESCONTADO"].Value;
            txt_obs.Text = dgv_generados.CurrentRow.Cells["OBSERVACION"].Value.ToString();
        }

        private void btn_modificar2_Click(object sender, EventArgs e)
        {
            if (!validaFormulario())
                return;
            DialogResult rs = MessageBox.Show("¿ Esta seguro de modificar el ingreso de documento ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                devTo.NRO_PLANILLA_COB = txt_ser.Text + "-" + txt_num.Text;
                devTo.SERIE = txt_ser.Text;
                devTo.COD_SUCURSAL = cbo_sucursal.SelectedValue.ToString();
                devTo.COD_CLASE = cbo_clase.SelectedValue.ToString();
                devTo.NRO_CONTRATO = txt_contrato.Text;
                devTo.FE_AÑO = AÑO;
                devTo.FE_MES = MES;
                devTo.COD_PER = TXT_COD.Text;
                devTo.DESC_PER = TXT_DESC.Text;
                devTo.COD_DOC = "60";
                devTo.NRO_DOC = "000000";
                devTo.FECHA_DOC = dtp_fec_doc.Value;
                devTo.FECHA_VEN = null;
                devTo.IMP_INI = Convert.ToDecimal(txt_importe.Text);
                devTo.IMP_DOC = devTo.IMP_INI;
                devTo.COD_MOTIVO_NO_DESCONTADO = cbo_motivo.SelectedValue.ToString();
                devTo.COD_D_H = "D";
                devTo.OBSERVACION = txt_obs.Text;
                devTo.COD_MONEDA = "S";
                devTo.TIPO_OPE = "GF";
                devTo.NRO_LETRA = "000";
                //devTo.TOTAL_LETRA = "000";
                //devTo.STATUS_GENERADO = "0";
                //devTo.STATUS_CANCELADO = "0";
                //devTo.TIPO_PLA_ORIGEN = "V";//referido a que viene por hacer un input para generar una planilla de devolucion o descuento especial
                devTo.TIPO_PLA_COBRANZA = cbo_tipo_planilla.SelectedValue.ToString();
                devTo.COD_USU_MOD = COD_USU;
                devTo.FECHA_MOD = DateTime.Now;
                if (!devBLL.modificarDevPctasCobrarOtrasDevolucionesDescuentosBLL(devTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("La modificación se hizo correctamente", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tabControl1.SelectedTab = tabPage1;
                    DATAGRID();
                    FOCO_NUEVO_REG();
                }
            }
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (!validaFormulario())
                return;
            DialogResult rs = MessageBox.Show("¿ Esta seguro de eliminar el documento ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                devTo.NRO_PLANILLA_COB = dgv_generados.CurrentRow.Cells["NRO_PLANILLA_COB"].Value.ToString();
                devTo.COD_SUCURSAL = dgv_generados.CurrentRow.Cells["COD_SUCURSAL"].Value.ToString();
                devTo.COD_CLASE = dgv_generados.CurrentRow.Cells["COD_CLASE"].Value.ToString();
                devTo.NRO_CONTRATO = dgv_generados.CurrentRow.Cells["NRO_CONTRATO"].Value.ToString();
                devTo.FE_AÑO = dgv_generados.CurrentRow.Cells["FE_AÑO"].Value.ToString();
                devTo.FE_MES = dgv_generados.CurrentRow.Cells["FE_MES"].Value.ToString();
                devTo.COD_D_H = "D";
                devTo.NRO_LETRA = "000";
                if (!devBLL.eliminarDevPctasCobrarOtrasDevolucionesDescuentosBLL(devTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("La eliminación se hizo correctamente", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //tabControl1.SelectedTab = tabPage1;
                    DATAGRID();
                    //FOCO_NUEVO_REG();
                }
            }
        }

        private void lkl_kardex_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string nro_contrato = txt_contrato.Text;
            MOD_COMISIONES.CONSULTA_KARDEX_X_CONTRATO frm = new MOD_COMISIONES.CONSULTA_KARDEX_X_CONTRATO(nro_contrato);
            frm.ShowDialog();
        }

        private void txt_importe_Leave(object sender, EventArgs e)
        {
            txt_importe.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(txt_importe.Text);
        }

        private void cbo_tipo_planilla_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_tipo_planilla.SelectedValue != null)
            {
                txt_importe.Text = "";
                txt_importe.ReadOnly = false;
                if (cbo_tipo_planilla.SelectedValue.ToString() == "DM" || cbo_tipo_planilla.SelectedValue.ToString() == "XM")
                {
                    chk_app.Checked = true;
                    aplicaCuotaComprometida();
                    if (cbo_tipo_planilla.SelectedValue.ToString() == "DM")
                        txt_importe.ReadOnly = true;

                    if (monto_comprometido > 0)
                        MessageBox.Show("Debe que crear también una planilla XAPLICAR EXC CUOTA COMPROMETIDA por el valor del monto comprometido !!!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void chk_app_CheckedChanged(object sender, EventArgs e)
        {
            aplicaCuotaComprometida();
        }
        private void aplicaCuotaComprometida()
        {
            if (chk_app.Checked)
                txt_importe.Text = (monto_x_pagar - monto_comprometido).ToString("###,###,##0.00");
            else
                txt_importe.Text = (monto_x_pagar).ToString("###,###,##0.00");
        }

        private void chbTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (chbTodos.Checked)
                CARGAR_PERSONAS("todos");
            else
                CARGAR_PERSONAS("algunos");
        }
    }
}
