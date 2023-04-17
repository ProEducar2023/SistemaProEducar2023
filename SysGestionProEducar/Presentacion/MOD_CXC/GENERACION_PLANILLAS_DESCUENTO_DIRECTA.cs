using BLL;
using Entidades;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Presentacion.MOD_CXC
{
    public partial class GENERACION_PLANILLAS_DESCUENTO_DIRECTA : Form
    {
        string AÑO = "", MES = "", COD_MOD = "", COD_USU = "", TIPO_USU = "";
        DateTime FECHA_INI, FECHA_GRAL;
        HelpersBLL helBLL = new HelpersBLL();
        HelpersTo helTo = new HelpersTo();
        planillaCabeceraOtrasDevDsctosBLL plcBLL = new planillaCabeceraOtrasDevDsctosBLL();
        planillaCabeceraOtrasDevDsctosTo plcTo = new planillaCabeceraOtrasDevDsctosTo();
        tipoDocInvBLL tdiBLL = new tipoDocInvBLL();
        tipoDocInvTo tdiTo = new tipoDocInvTo();
        canjeTCtasxCobrarBLL ctcBLL = new canjeTCtasxCobrarBLL();
        canjeTCtasxCobrarTo ctcTo = new canjeTCtasxCobrarTo();
        canjePCtasxCobrarBLL pctaBLL = new canjePCtasxCobrarBLL();
        canjePCtasxCobrarTo pctaTo = new canjePCtasxCobrarTo();
        DataTable detPlla = new DataTable();
        string COD_DOC;
        DataTable dtPersona; int fila; string NRO_PLANILLA_COBRANZA;
        decimal monto_a_pagar = 0;
        public GENERACION_PLANILLAS_DESCUENTO_DIRECTA(string AÑO, string MES, DateTime FECHA_INI, DateTime FECHA_GRAL, string COD_MOD, string TIPO_USU, string COD_USU)
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

        private void GENERACION_PLANILLAS_DESCUENTO_DIRECTA_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            DATAGRID();
            CARGAR_SUCURSAL();
            CARGA_INSTITUCIONES();
            CARGAR_CANAL_DSCTO();
            CARGAR_PERSONAS();
            CARGAR_TIPO_PLANILLA();
            CARGAR_GESTOR();
            /////// //CARGAR_MOTIVOS();
            ///dtp_generacion.Value = Convert.ToDateTime(DateTime.Now.Day + "/" + MES + "/" + AÑO);
            DateTime fe_plla = DateTime.Now;
            if (DateTime.TryParse((DateTime.Now.Day + "/" + MES + "/" + AÑO), out fe_plla))
                dtp_generacion.Value = Convert.ToDateTime(DateTime.Now.Day + "/" + MES + "/" + AÑO);
            else
                dtp_generacion.Value = FECHA_GRAL;
        }
        private void CARGAR_GESTOR()
        {
            personaBLL perBLL = new personaBLL();
            DataTable dt = perBLL.obtenerGestoresBLL();
            if (dt.Rows.Count > 0)
            {
                cbo_gestor.DataSource = dt;
                cbo_gestor.ValueMember = "COD_PER";
                cbo_gestor.DisplayMember = "DESC_PER";
                cbo_gestor.SelectedIndex = -1;
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
        private void CARGA_INSTITUCIONES()
        {
            institucionesBLL insBLL = new institucionesBLL();
            DataTable dtInstitucion = insBLL.obtenerInstitucionesBLL();
            cbo_institucion.ValueMember = "COD_INST";
            cbo_institucion.DisplayMember = "DESC_INST";
            cbo_institucion.DataSource = dtInstitucion;
            cbo_institucion.SelectedIndex = 0;
        }
        private void CARGAR_CANAL_DSCTO()
        {
            canalDescuentoBLL cdscBLL = new canalDescuentoBLL();
            DataTable dt = cdscBLL.ObtenerCanalDescuentoBLL();
            cbo_canaldscto.ValueMember = "COD_CANAL_DSCTO";
            cbo_canaldscto.DisplayMember = "DESCRIPCION";
            cbo_canaldscto.DataSource = dt;
            cbo_canaldscto.SelectedIndex = 0;
        }
        private void CARGAR_PERSONAS()
        {
            //helTo.CODIGO = "04";//VENDEDORES
            dtPersona = helBLL.MOSTRAR_PERSONAS_X_DSCTO_DIRECTA_BLL();
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
                dgw_per.Columns["COD_PROGRAMA"].Visible = false;
                dgw_per.Columns["COD_SUCURSAL"].Visible = false;
                dgw_per.Columns["COD_INSTITUCION"].Visible = false;
                dgw_per.Columns["COD_CANAL_DSCTO"].Visible = false;
                dgw_per.Columns["IMP_DOC"].Visible = false;
                dgw_per.Columns["COD_PTO_COB"].Visible = false;
            }

        }
        private void CARGAR_TIPO_PLANILLA()
        {
            tipoPlanillaCreacionBLL tpcBLL = new tipoPlanillaCreacionBLL();
            DataTable dt = tpcBLL.obtenerTipoPlanillaCreacionxTransferenciaBLL();
            if (dt.Rows.Count > 0)
            {
                cbo_tipo_planilla.ValueMember = "COD_TIPO_PLLA";
                cbo_tipo_planilla.DisplayMember = "DESC_TIPO";
                cbo_tipo_planilla.DataSource = dt;
                cbo_tipo_planilla.SelectedValue = "PD";
            }
        }

        private void GENERACION_PLANILLAS_DESCUENTO_DIRECTA_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }
        private void DATAGRID()
        {
            plcTo.FE_AÑO = AÑO;
            plcTo.FE_MES = MES;
            DataTable dt = plcBLL.obtenerPlanillaCabeceraDescuentoDirectaBLL(plcTo);
            lbl_nro_reg.Text = "Nro de Registros : 0";
            if (dt.Rows.Count > 0)
            {
                lbl_nro_reg.Text = "Nro de Registros : " + dt.Rows.Count.ToString();
                dgv_generados.Rows.Clear();
                foreach (DataRow rw in dt.Rows)
                {
                    int rowId = dgv_generados.Rows.Add();
                    DataGridViewRow row = dgv_generados.Rows[rowId];
                    row.Cells["NRO_PLANILLA_DOC2"].Value = rw["NRO_PLANILLA_DOC"].ToString();
                    row.Cells["COD_INSTITUCION2"].Value = rw["COD_INSTITUCION"].ToString();
                    row.Cells["COD_CANAL_DSCTO2"].Value = rw["COD_CANAL_DSCTO"].ToString();
                    row.Cells["FE_AÑO2"].Value = rw["FE_AÑO"].ToString();
                    row.Cells["FE_MES2"].Value = rw["FE_MES"].ToString();
                    row.Cells["COD_PER2"].Value = rw["COD_PER"].ToString();
                    row.Cells["DESC_PER2"].Value = rw["DESC_PER"].ToString();
                    row.Cells["COD_SUCURSAL2"].Value = rw["COD_SUCURSAL"].ToString();
                    row.Cells["FECHA_PLANILLA_DOC2"].Value = rw["FECHA_PLANILLA_DOC"].ToString().Substring(0, 10);
                    row.Cells["COD_PER2"].Value = rw["COD_PER"].ToString();
                    row.Cells["DESC_PER2"].Value = rw["DESC_PER"].ToString();
                    row.Cells["DNI2"].Value = rw["DNI"].ToString();
                    row.Cells["NRO_CONTRATO2"].Value = rw["NRO_CONTRATO"].ToString();
                    row.Cells["TIPO_PLANILLA_DOC2"].Value = rw["TIPO_PLANILLA_DOC"].ToString();
                    row.Cells["IMPORTE_TOTAL2"].Value = rw["IMPORTE_TOTAL"].ToString();
                    row.Cells["OBSERVACIONES2"].Value = rw["OBSERVACIONES"].ToString();
                    row.Cells["STATUS_CIERRE2"].Value = rw["STATUS_CIERRE"].ToString() == "1" ? true : false;
                    row.Cells["DESC_TIPO2"].Value = rw["DESC_TIPO"].ToString();
                    row.Cells["COD_PTO_COB2"].Value = rw["COD_PTO_COB"].ToString();
                    row.Cells["STATUS_CTACTE2"].Value = rw["STATUS_CTACTE"].ToString();
                    row.Cells["COD_VENTA2"].Value = rw["COD_VENTA"].ToString();
                    row.Cells["COD_GESTOR2"].Value = rw["COD_GESTOR"].ToString();
                }
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
        }

        private void dgw_per_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int idx = dgw_per.CurrentRow.Index;
                TXT_COD.Text = dgw_per[0, idx].Value.ToString();
                TXT_DESC.Text = dgw_per[1, idx].Value.ToString();
                txt_doc_per.Text = dgw_per[2, idx].Value.ToString();
                cbo_sucursal.SelectedValue = dgw_per.Rows[idx].Cells["COD_SUCURSAL"].Value;
                cbo_institucion.SelectedValue = dgw_per.Rows[idx].Cells["COD_INSTITUCION"].Value.ToString() == "" ? "01" : dgw_per.Rows[idx].Cells["COD_INSTITUCION"].Value;
                cbo_canaldscto.SelectedValue = dgw_per.Rows[idx].Cells["COD_CANAL_DSCTO"].Value.ToString() == "" ? "1404" : dgw_per.Rows[idx].Cells["COD_CANAL_DSCTO"].Value;
                lbl_cod_tipo_plla.Text = "PD";//cbo_tipo_planilla.SelectedValue.ToString();
                txt_contrato.Text = dgw_per.Rows[idx].Cells["NRO_PRESUPUESTO"].Value.ToString();
                ctcTo.NRO_CONTRATO = txt_contrato.Text;
                string errMensaje = "";
                decimal monto_pagado = ctcBLL.obtenerMontoPagadoxContratoBLL(ctcTo, ref errMensaje);
                decimal monto_total = Convert.ToDecimal(dgw_per.Rows[idx].Cells["IMP_DOC"].Value);
                decimal monto_total_a_pagar = monto_total - monto_pagado;
                decimal monto_comprometido = ctcBLL.obtenerSumaImporteComprometidosBLL(ctcTo, ref errMensaje);
                lbl_imp_tot_pagado.Text = monto_pagado.ToString("###,###,##0.00");
                lbl_imp_cuo_comp.Text = monto_comprometido.ToString("###,###,##0.00");
                lbl_imp_tot_x_pagar.Text = (monto_total_a_pagar - monto_comprometido).ToString("###,###,##0.00");
                Panel_PER.Visible = false;
                //txt_observaciones.Focus();
                cbo_canaldscto.Focus();
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
            cbo_sucursal.SelectedIndex = -1;
            btn_grabar.Enabled = true;
            txt_ser.ReadOnly = false;
            txt_num.ReadOnly = false;
            cbo_institucion.Enabled = true;
            cbo_canaldscto.Enabled = true;
            cbo_tipo_planilla.Enabled = false;
            TXT_COD.Focus();
        }
        private void LIMPIAR()
        {
            cbo_sucursal.SelectedIndex = -1;
            cbo_institucion.SelectedIndex = -1;
            txt_ser.Clear();
            txt_num.Clear();
            //lbl_cod_tipo_plla.Text = "XX";
            TXT_COD.Clear();
            TXT_DESC.Clear();
            txt_doc_per.Clear();
            txt_tot_pagado.Clear();
            cbo_canaldscto.SelectedIndex = -1;
            cbo_gestor.SelectedIndex = -1;
            txt_observaciones.Clear();
            dgw_det.Rows.Clear();
        }

        private void cbo_sucursal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_sucursal.SelectedValue != null)
            {
                if (cbo_tipo_planilla.SelectedValue != null)
                    obtieneNroPlla();
            }
        }
        private void obtieneNroPlla()
        {
            if (btn_grabar.Visible)
            {
                tdiTo.TIPO_DOC = cbo_tipo_planilla.SelectedValue.ToString();
                COD_DOC = tdiBLL.obtieneCodDocInvxTipoDocBLL(tdiTo);
                DataTable dt = HelpersBLL.obtieneNroPlanilla(cbo_sucursal.SelectedValue.ToString(), "0", COD_DOC);
                txt_ser.Text = dt.Rows[0]["SERIE"].ToString();
                txt_num.Text = dt.Rows[0]["NUMERO"].ToString();
            }
        }

        private void txt_tot_pagado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                calculaCuotasaCobrar();
            }
        }
        private void calculaCuotasaCobrar()
        {
            decimal importe = 0;
            if (decimal.TryParse(txt_tot_pagado.Text, out importe))
            {
                importe = Convert.ToDecimal(txt_tot_pagado.Text);
                distribuirImporte(importe);
                //if (btn_grabar.Visible)
                //    txt_observaciones.Focus();
                //else
                //    btn_modificar2.Focus();
            }
        }
        private void distribuirImporte(decimal importe)
        {
            //TABLA CON LAS CUOTAS NO CANCELADAS
            dgw_det.Rows.Clear();
            plcTo.COD_SUCURSAL = cbo_sucursal.SelectedValue.ToString();
            plcTo.COD_CLASE = "01";
            plcTo.NRO_CONTRATO = txt_contrato.Text;
            pctaTo.NRO_CONTRATO = txt_contrato.Text;
            DataTable dtCuotasComprometidasContrato = pctaBLL.obtenerCuotasComprometidasContratoPllaDirectaBLL(pctaTo);
            DataTable dtCuotas = obtieneCuotasNoCanceladasBLL(plcTo);
            monto_a_pagar = importe;
            if (dtCuotas.Rows.Count > 0)
            {
                foreach (DataRow rw in dtCuotas.Rows)
                {
                    if (monto_a_pagar > 0)
                    {
                        int rowId = dgw_det.Rows.Add();
                        DataGridViewRow fila = dgw_det.Rows[rowId];
                        fila.Cells["NRO_PLANILLA_DOC"].Value = txt_ser.Text + "-" + txt_num.Text;
                        fila.Cells["COD_INSTITUCION"].Value = cbo_institucion.SelectedValue.ToString();
                        fila.Cells["COD_CANAL_DSCTO"].Value = cbo_canaldscto.SelectedValue.ToString();
                        fila.Cells["FE_AÑO"].Value = AÑO;
                        fila.Cells["FE_MES"].Value = MES;
                        fila.Cells["NRO_PLANILLA_COB"].Value = fila.Cells["NRO_PLANILLA_DOC"].Value;
                        fila.Cells["FECHA_VEN"].Value = rw["FECHA_VEN"].ToString().Substring(0, 10);
                        fila.Cells["NRO_DOCU"].Value = rw["NRO_DOC"];
                        fila.Cells["NRO_LETRA"].Value = rw["NRO_LETRA"];
                        fila.Cells["TOTAL_LETRA"].Value = rw["TOTAL_LETRA"];
                        fila.Cells["SALDO"].Value = rw["SALDO"];
                        if (monto_a_pagar >= Convert.ToDecimal(rw["IMP_DOC"]))
                            fila.Cells["IMP_DOC"].Value = rw["IMP_DOC"];
                        else
                            fila.Cells["IMP_DOC"].Value = monto_a_pagar;
                        monto_a_pagar -= Convert.ToDecimal(rw["IMP_DOC"]);
                        fila.Cells["MOTIVO_OTRAS_DEV_DSCTOS"].Value = "";
                        fila.Cells["IMP_DEV"].Value = 0;
                    }
                    else
                        break;
                }
                if (dtCuotasComprometidasContrato.Rows.Count > 0)
                {
                    foreach (DataRow rw in dtCuotasComprometidasContrato.Rows)
                    {
                        if (monto_a_pagar > 0 && Convert.ToDecimal(rw["IMP_INI"]) == Convert.ToDecimal(rw["IMP_DOC"]))
                        {
                            int rowId = dgw_det.Rows.Add();
                            DataGridViewRow fila = dgw_det.Rows[rowId];
                            fila.Cells["NRO_PLANILLA_DOC"].Value = txt_ser.Text + "-" + txt_num.Text;
                            fila.Cells["COD_INSTITUCION"].Value = cbo_institucion.SelectedValue.ToString();
                            fila.Cells["COD_CANAL_DSCTO"].Value = cbo_canaldscto.SelectedValue.ToString();
                            fila.Cells["FE_AÑO"].Value = AÑO;
                            fila.Cells["FE_MES"].Value = MES;
                            fila.Cells["NRO_PLANILLA_COB"].Value = fila.Cells["NRO_PLANILLA_DOC"].Value;
                            fila.Cells["FECHA_VEN"].Value = rw["FECHA_VEN"].ToString().Substring(0, 10);
                            fila.Cells["NRO_DOCU"].Value = rw["NRO_DOC"];
                            fila.Cells["NRO_LETRA"].Value = rw["NRO_LETRA"];
                            fila.Cells["TOTAL_LETRA"].Value = rw["TOTAL_LETRA"];
                            fila.Cells["SALDO"].Value = rw["SALDO"];
                            if (monto_a_pagar >= Convert.ToDecimal(rw["IMP_DOC"]))
                                fila.Cells["IMP_DOC"].Value = rw["IMP_DOC"];
                            else
                                fila.Cells["IMP_DOC"].Value = monto_a_pagar;
                            monto_a_pagar -= Convert.ToDecimal(rw["IMP_DOC"]);
                            fila.Cells["MOTIVO_OTRAS_DEV_DSCTOS"].Value = "";
                            fila.Cells["IMP_DEV"].Value = 0;
                        }
                    }
                }

                if (monto_a_pagar > 0)
                {
                    MessageBox.Show("Existe un exceso de contrato de " + monto_a_pagar.ToString("###,###,##0.00"), "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    int rowId = dgw_det.Rows.Add();
                    DataGridViewRow fila = dgw_det.Rows[rowId];
                    fila.Cells["NRO_PLANILLA_DOC"].Value = txt_ser.Text + "-" + txt_num.Text;
                    fila.Cells["COD_INSTITUCION"].Value = cbo_institucion.SelectedValue.ToString();
                    fila.Cells["COD_CANAL_DSCTO"].Value = cbo_canaldscto.SelectedValue.ToString();
                    fila.Cells["FE_AÑO"].Value = AÑO;
                    fila.Cells["FE_MES"].Value = MES;
                    fila.Cells["NRO_PLANILLA_COB"].Value = fila.Cells["NRO_PLANILLA_DOC"].Value;
                    fila.Cells["FECHA_VEN"].Value = "";
                    fila.Cells["NRO_DOCU"].Value = "";
                    fila.Cells["NRO_LETRA"].Value = "***";
                    fila.Cells["TOTAL_LETRA"].Value = "***";
                    fila.Cells["IMP_DOC"].Value = monto_a_pagar;
                    fila.Cells["MOTIVO_OTRAS_DEV_DSCTOS"].Value = "006";
                    fila.Cells["IMP_DEV"].Value = fila.Cells["IMP_DOC"].Value;
                }
            }
        }
        private DataTable obtieneCuotasNoCanceladasBLL(planillaCabeceraOtrasDevDsctosTo plcTo)
        {
            DataTable dt;
            canjePCtasxCobrarBLL pccBLL = new canjePCtasxCobrarBLL();
            canjePCtasxCobrarTo pccTo = new canjePCtasxCobrarTo();
            pccTo.COD_SUCURSAL = plcTo.COD_SUCURSAL;
            pccTo.COD_CLASE = plcTo.COD_CLASE;
            pccTo.NRO_CONTRATO = plcTo.NRO_CONTRATO;
            pccTo.COMPROMETIDO = chkComprometidas.Checked;
            if (!pccTo.COMPROMETIDO)
                dt = pccBLL.obtenerCuotasPendientesxContratoBLL(pccTo);
            else
                dt = pccBLL.obtenerCuotasPendientesxContratoxIncluyendoCuotaComprometidasBLL(pccTo);
            return dt;
        }
        private void txt_tot_pagado_Leave(object sender, EventArgs e)
        {
            txt_tot_pagado.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(txt_tot_pagado.Text);
            calculaCuotasaCobrar();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            TabControl1.SelectedTab = (TabPage1);
        }

        private void lkl_kardex_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string nro_contrato = txt_contrato.Text;
            MOD_COMISIONES.CONSULTA_KARDEX_X_CONTRATO frm = new MOD_COMISIONES.CONSULTA_KARDEX_X_CONTRATO(nro_contrato);
            frm.ShowDialog();
        }

        private void btn_grabar_Click(object sender, EventArgs e)
        {
            if (!validaFormulario())
                return;
            DialogResult rs = MessageBox.Show("¿ Esta seguro de crear una Planilla Directa ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                plcTo.NRO_PLANILLA_DOC = txt_ser.Text + "-" + txt_num.Text;
                plcTo.SERIE = txt_ser.Text;
                plcTo.COD_INSTITUCION = cbo_institucion.SelectedValue.ToString();
                plcTo.COD_CANAL_DSCTO = cbo_canaldscto.SelectedValue.ToString();
                plcTo.FE_AÑO = AÑO;
                plcTo.FE_MES = MES;
                plcTo.COD_SUCURSAL = cbo_sucursal.SelectedValue.ToString();
                plcTo.FECHA_PLANILLA_DOC = dtp_generacion.Value;
                plcTo.COD_PER = TXT_COD.Text;
                plcTo.DESC_PER = TXT_DESC.Text;
                plcTo.DNI = txt_doc_per.Text;
                plcTo.NRO_CONTRATO = txt_contrato.Text;
                plcTo.TIPO_PLANILLA_DOC = cbo_tipo_planilla.SelectedValue.ToString();
                plcTo.IMPORTE_TOTAL = Convert.ToDecimal(txt_tot_pagado.Text);
                plcTo.OBSERVACIONES = txt_observaciones.Text;
                plcTo.STATUS_CIERRE = "0";
                plcTo.COD_CREA = COD_USU;
                plcTo.FECHA_CREA = DateTime.Now;
                tdiTo.TIPO_DOC = plcTo.TIPO_PLANILLA_DOC;
                plcTo.COD_DOC = COD_DOC;//tdiBLL.obtieneCodDocInvxTipoDocBLL(tdiTo);
                plcTo.STATUS_DOC = "0";
                plcTo.NRO_LETRA = dgw_det.Rows[0].Cells["NRO_LETRA"].Value.ToString();
                plcTo.STATUS_COMPROM = chkComprometidas.Checked ? "1" : "0";
                plcTo.COD_GESTOR = cbo_gestor.SelectedValue.ToString();
                DataTable dtDetalle = HelpersBLL.obtenerDT(dgw_det);
                if (!plcBLL.insertarPlanillasOtrasDevDsctosBLL(plcTo, dtDetalle, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("El ingreso se hizo correctamente", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TabControl1.SelectedTab = TabPage1;
                    DATAGRID();
                    CARGAR_PERSONAS();//para actualizar el grid desplegable
                    FOCO_NUEVO_REG("grabar");
                }
            }
        }
        private void FOCO_NUEVO_REG(string op)
        {
            int i, cont = 0; string nrocon = "";
            cont = dgv_generados.Columns.Count - 1;
            if (op == "grabar")
                nrocon = txt_ser.Text + "-" + txt_num.Text.Trim() + lbl_cod_tipo_plla.Text;
            else if (op == "aprobar")
                nrocon = NRO_PLANILLA_COBRANZA + dgv_generados.CurrentRow.Cells["TIPO_PLANILLA_DOC2"].Value.ToString();

            for (i = 0; i <= cont; i++)
            {
                if (nrocon == dgv_generados.Rows[i].Cells["NRO_PLANILLA_DOC2"].Value.ToString().ToLower() + dgv_generados.Rows[i].Cells["TIPO_PLANILLA_DOC2"].Value.ToString())
                {
                    dgv_generados.CurrentCell = dgv_generados.Rows[i].Cells["NRO_PLANILLA_DOC2"];
                    return;
                }
            }
        }
        private bool validaFormulario()
        {
            bool result = true;
            if (dgw_det.Rows.Count == 0)
            {
                MessageBox.Show("No existe registros en el grid !!!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_tot_pagado.Focus();
                return result = false;
            }
            if (txt_tot_pagado.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el importe !!!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_tot_pagado.Focus();
                return result = false;
            }
            if (btn_grabar.Visible)
            {
                var query = from DataGridViewRow row in dgv_generados.Rows
                            where (row.Cells["NRO_CONTRATO2"].Value.ToString() == txt_contrato.Text.Trim() && !Convert.ToBoolean(row.Cells["STATUS_CIERRE2"].Value))
                            select row;
                if (query.Count() > 0)
                {
                    MessageBox.Show("El contrato tiene una cuota que aun no ha sido Aprobada, apruébala antes !!!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    TabControl1.SelectedTab = TabPage1;
                    FOCO_NUEVO();
                    return result = false;
                }
            }
            return result;
        }
        private void FOCO_NUEVO()
        {
            int i, cont;
            cont = dgv_generados.Rows.Count - 1;
            for (i = 0; i <= cont; i++)
            {
                if (txt_contrato.Text.Trim() == dgv_generados.Rows[i].Cells["NRO_CONTRATO2"].Value.ToString() && !Convert.ToBoolean(dgv_generados.Rows[i].Cells["STATUS_CIERRE2"].Value))
                {
                    dgv_generados.CurrentCell = dgv_generados.Rows[i].Cells["NRO_CONTRATO2"];
                    break;
                }
            }
        }
        private void btn_modificar_Click(object sender, EventArgs e)
        {
            if (!validaModificar())
                return;
            btn_grabar.Visible = false;
            btn_modificar2.Visible = true;
            //txt_ser.Visible = true;
            TabControl1.SelectedTab = (TabPage2);
            LIMPIAR();
            btn_grabar.Enabled = false;
            btn_modificar2.Enabled = true;
            txt_ser.ReadOnly = true;
            txt_num.ReadOnly = true;
            cbo_institucion.Enabled = false;
            cbo_canaldscto.Enabled = false;
            cbo_tipo_planilla.Enabled = false;
            CARGAR_CABECERA_DOCUMENTO();
            CARGAR_DETALLE_DOCUMENTO();
        }
        private bool validaModificar()
        {
            bool result = true;
            if (Convert.ToBoolean(dgv_generados.CurrentRow.Cells["STATUS_CIERRE2"].Value))
            {
                MessageBox.Show("No se puede modificar porque ya está Aprobado !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return result = false;
            }

            return result;
        }
        private void CARGAR_CABECERA_DOCUMENTO()
        {
            TXT_COD.Text = dgv_generados.CurrentRow.Cells["COD_PER2"].Value.ToString();
            TXT_DESC.Text = dgv_generados.CurrentRow.Cells["DESC_PER2"].Value.ToString();
            txt_doc_per.Text = dgv_generados.CurrentRow.Cells["DNI2"].Value.ToString();
            txt_contrato.Text = dgv_generados.CurrentRow.Cells["NRO_CONTRATO2"].Value.ToString();
            cbo_sucursal.SelectedValue = dgv_generados.CurrentRow.Cells["COD_SUCURSAL2"].Value;
            cbo_institucion.SelectedValue = dgv_generados.CurrentRow.Cells["COD_INSTITUCION2"].Value;
            dtp_generacion.Value = Convert.ToDateTime(dgv_generados.CurrentRow.Cells["FECHA_PLANILLA_DOC2"].Value);
            lbl_cod_tipo_plla.Text = dgv_generados.CurrentRow.Cells["TIPO_PLANILLA_DOC2"].Value.ToString();
            txt_ser.Text = dgv_generados.CurrentRow.Cells["NRO_PLANILLA_DOC2"].Value.ToString().Substring(0, 3);
            txt_num.Text = dgv_generados.CurrentRow.Cells["NRO_PLANILLA_DOC2"].Value.ToString().Substring(4, 7);
            txt_tot_pagado.Text = Convert.ToDecimal(dgv_generados.CurrentRow.Cells["IMPORTE_TOTAL2"].Value).ToString("###,###,##0.00");
            cbo_canaldscto.SelectedValue = dgv_generados.CurrentRow.Cells["COD_CANAL_DSCTO2"].Value;
            cbo_tipo_planilla.SelectedValue = dgv_generados.CurrentRow.Cells["TIPO_PLANILLA_DOC2"].Value;
            txt_observaciones.Text = dgv_generados.CurrentRow.Cells["OBSERVACIONES2"].Value.ToString();
            cbo_gestor.SelectedValue = dgv_generados.CurrentRow.Cells["COD_GESTOR2"].Value.ToString();
        }
        private void CARGAR_DETALLE_DOCUMENTO()
        {
            planillaDetalleOtrasDevDsctosBLL pldBLL = new planillaDetalleOtrasDevDsctosBLL();
            planillaDetalleOtrasDevDsctosTo pldTo = new planillaDetalleOtrasDevDsctosTo();
            pldTo.NRO_PLANILLA_DOC = dgv_generados.CurrentRow.Cells["NRO_PLANILLA_DOC2"].Value.ToString();
            pldTo.COD_INSTITUCION = dgv_generados.CurrentRow.Cells["COD_INSTITUCION2"].Value.ToString();
            pldTo.COD_CANAL_DSCTO = dgv_generados.CurrentRow.Cells["COD_CANAL_DSCTO2"].Value.ToString();
            pldTo.FE_AÑO = dgv_generados.CurrentRow.Cells["FE_AÑO2"].Value.ToString();
            pldTo.FE_MES = dgv_generados.CurrentRow.Cells["FE_MES2"].Value.ToString();
            pldTo.TIPO_PLANILLA_DOC = dgv_generados.CurrentRow.Cells["TIPO_PLANILLA_DOC2"].Value.ToString();

            DataTable dt = pldBLL.obtenerPlanillaDetalleOtrasDevDsctosBLL(pldTo);
            if (dt.Rows.Count > 0)
            {
                dgw_det.Rows.Clear();
                foreach (DataRow rw in dt.Rows)
                {
                    int rowId = dgw_det.Rows.Add();
                    DataGridViewRow row = dgw_det.Rows[rowId];
                    row.Cells["NRO_PLANILLA_DOC"].Value = rw["NRO_PLANILLA_DOC"].ToString();
                    row.Cells["COD_INSTITUCION"].Value = rw["COD_INSTITUCION"].ToString();
                    row.Cells["COD_CANAL_DSCTO"].Value = rw["COD_CANAL_DSCTO"].ToString();
                    row.Cells["FE_AÑO"].Value = rw["FE_AÑO"].ToString();
                    row.Cells["FE_MES"].Value = rw["FE_MES"].ToString();
                    row.Cells["NRO_PLANILLA_COB"].Value = rw["NRO_PLANILLA_COB"].ToString();
                    row.Cells["NRO_DOCU"].Value = rw["NRO_DOC"].ToString();
                    row.Cells["IMP_DOC"].Value = rw["IMP_DOC"].ToString();
                    row.Cells["MOTIVO_OTRAS_DEV_DSCTOS"].Value = rw["MOTIVO_OTRAS_DEV_DSCTOS"].ToString();
                    //row.Cells["DESC_MOTIVO_OT_DEV"].Value = rw["MOTIVO_OTRAS_DEV_DSCTOS"].ToString() == "" ? "" : rw["DESC_MOTIVO_OT_DEV"].ToString();
                    row.Cells["FECHA_VEN"].Value = rw["FECHA_VEN"].ToString() != "" ? rw["FECHA_VEN"].ToString().Substring(0, 10) : "";
                    row.Cells["NRO_LETRA"].Value = rw["NRO_LETRA"].ToString();
                    row.Cells["TOTAL_LETRA"].Value = rw["TOTAL_LETRA"].ToString();
                    row.Cells["IMP_DEV"].Value = rw["IMP_DEV"].ToString();
                }
            }
        }

        private void btn_consulta_Click(object sender, EventArgs e)
        {
            btn_grabar.Visible = false;
            btn_modificar2.Visible = false;
            //txt_ser.Visible = true;
            TabControl1.SelectedTab = (TabPage2);
            LIMPIAR();
            btn_grabar.Enabled = true;
            btn_modificar2.Enabled = true;
            CARGAR_CABECERA_DOCUMENTO();
            CARGAR_DETALLE_DOCUMENTO();
        }

        private void btn_modificar2_Click(object sender, EventArgs e)
        {
            if (!validaFormulario())
                return;
            DialogResult rs = MessageBox.Show("¿ Esta seguro modificar la Planilla ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                plcTo.NRO_PLANILLA_DOC = txt_ser.Text + "-" + txt_num.Text;
                plcTo.SERIE = txt_ser.Text;
                plcTo.COD_INSTITUCION = cbo_institucion.SelectedValue.ToString();
                plcTo.COD_CANAL_DSCTO = cbo_canaldscto.SelectedValue.ToString();
                plcTo.FE_AÑO = AÑO;
                plcTo.FE_MES = MES;
                plcTo.COD_SUCURSAL = cbo_sucursal.SelectedValue.ToString();
                plcTo.FECHA_PLANILLA_DOC = dtp_generacion.Value;
                plcTo.COD_PER = TXT_COD.Text;
                plcTo.DESC_PER = TXT_DESC.Text;
                plcTo.DNI = txt_doc_per.Text;
                plcTo.NRO_CONTRATO = txt_contrato.Text;
                plcTo.TIPO_PLANILLA_DOC = cbo_tipo_planilla.SelectedValue.ToString();
                plcTo.IMPORTE_TOTAL = Convert.ToDecimal(txt_tot_pagado.Text);
                plcTo.OBSERVACIONES = txt_observaciones.Text;
                plcTo.STATUS_CIERRE = "0";
                plcTo.COD_CREA = COD_USU;
                plcTo.FECHA_CREA = DateTime.Now;
                tdiTo.TIPO_DOC = plcTo.TIPO_PLANILLA_DOC;
                plcTo.COD_DOC = COD_DOC;//tdiBLL.obtieneCodDocInvxTipoDocBLL(tdiTo);
                plcTo.STATUS_DOC = "0";
                plcTo.NRO_LETRA = dgw_det.Rows[0].Cells["NRO_LETRA"].Value.ToString();
                plcTo.STATUS_COMPROM = chkComprometidas.Checked ? "1" : "0";
                plcTo.COD_GESTOR = cbo_gestor.SelectedValue.ToString();

                DataTable dtDetalle = HelpersBLL.obtenerDT(dgw_det);
                if (!plcBLL.modificarPlanillasOtrasDevDsctosBLL(plcTo, dtDetalle, ref errMensaje))
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

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (!validaEliminar())
                return;
            DialogResult rs = MessageBox.Show("¿ Esta seguro eliminar la Planilla ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                plcTo.NRO_PLANILLA_DOC = dgv_generados.CurrentRow.Cells["NRO_PLANILLA_DOC2"].Value.ToString();
                plcTo.COD_INSTITUCION = dgv_generados.CurrentRow.Cells["COD_INSTITUCION2"].Value.ToString();
                plcTo.COD_CANAL_DSCTO = dgv_generados.CurrentRow.Cells["COD_CANAL_DSCTO2"].Value.ToString();
                plcTo.FE_AÑO = AÑO;
                plcTo.FE_MES = MES;
                plcTo.TIPO_PLANILLA_DOC = dgv_generados.CurrentRow.Cells["TIPO_PLANILLA_DOC2"].Value.ToString();
                if (!plcBLL.eliminarPlanillaOtrasDevDsctosBLL(plcTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Se eliminó correctamente la planilla", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DATAGRID();
                    CARGAR_PERSONAS();//para actualizar el grid desplegable
                    //FOCO_NUEVO_REG();
                }
            }
        }
        private bool validaEliminar()
        {
            bool result = true;
            if (Convert.ToBoolean(dgv_generados.CurrentRow.Cells["STATUS_CIERRE2"].Value))
            {
                MessageBox.Show("El registro ya está Aprobado !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return result = false;
            }

            return result;
        }
        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private bool validaAprobar()
        {
            bool result = true;
            if (dgv_generados.Rows.Count == 0)
            {
                MessageBox.Show("No existen registros !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return result = false;
            }
            if (Convert.ToBoolean(dgv_generados.CurrentRow.Cells["STATUS_CIERRE2"].Value))
            {
                MessageBox.Show("El registro ya está Aprobado !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return result = false;
            }

            return result;
        }
        private void btn_aprobar_Click(object sender, EventArgs e)
        {
            if (!validaAprobar())
                return;
            DialogResult rs = MessageBox.Show("¿ Esta seguro aprobar o cerrar la Planilla ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                //planillaCabeceraBLL plcBLL = new planillaCabeceraBLL();
                planillaCabeceraTo pllcTo = new planillaCabeceraTo();
                string errMensaje = "";
                pllcTo.NRO_PLANILLA_COB = dgv_generados.CurrentRow.Cells["NRO_PLANILLA_DOC2"].Value.ToString();
                //plcTo.SERIE = dgv_generados.CurrentRow.Cells["NRO_PLANILLA_DOC2"].Value.ToString().Substring(0, 3);
                pllcTo.COD_INSTITUCION = dgv_generados.CurrentRow.Cells["COD_INSTITUCION2"].Value.ToString();
                pllcTo.COD_PTO_COB_CONSOLIDADO = dgv_generados.CurrentRow.Cells["COD_PTO_COB2"].Value.ToString();
                pllcTo.COD_CANAL_DSCTO = dgv_generados.CurrentRow.Cells["COD_CANAL_DSCTO2"].Value.ToString();
                pllcTo.FE_AÑO = dgv_generados.CurrentRow.Cells["FE_AÑO2"].Value.ToString();
                pllcTo.FE_MES = dgv_generados.CurrentRow.Cells["FE_MES2"].Value.ToString();
                pllcTo.COD_MOD = COD_USU;
                pllcTo.FECHA_MOD = DateTime.Now;
                pllcTo.COD_SUCURSAL = dgv_generados.CurrentRow.Cells["COD_SUCURSAL2"].Value.ToString();
                pllcTo.COD_CLASE = "01";
                pllcTo.COD_SECTORISTA = "";
                pllcTo.FECHA_PLANILLA_COB = Convert.ToDateTime(Convert.ToDateTime(dgv_generados.CurrentRow.Cells["FECHA_PLANILLA_DOC2"].Value + " " + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString()));
                pllcTo.FECHA_RECEPCION = pllcTo.FECHA_PLANILLA_COB;
                pllcTo.OBSERVACION = dgv_generados.CurrentRow.Cells["OBSERVACIONES2"].Value.ToString();
                pllcTo.TIPO_PLANILLA = "PD";
                planillaDetalleOtrasDevDsctosBLL pldBLL = new planillaDetalleOtrasDevDsctosBLL();
                planillaDetalleOtrasDevDsctosTo pldTo = new planillaDetalleOtrasDevDsctosTo();
                pldTo.NRO_PLANILLA_DOC = pllcTo.NRO_PLANILLA_COB;
                pldTo.COD_INSTITUCION = pllcTo.COD_INSTITUCION;
                pldTo.COD_CANAL_DSCTO = pllcTo.COD_CANAL_DSCTO;
                pldTo.FE_AÑO = pllcTo.FE_AÑO;
                pldTo.FE_MES = pllcTo.FE_MES;
                pldTo.TIPO_PLANILLA_DOC = pllcTo.TIPO_PLANILLA;
                pldTo.NRO_PLANILLA_COB = pllcTo.NRO_PLANILLA_COB;
                DataTable dtDetalle = pldBLL.obtenerPlanillaDetalleDstoDirectaBLL(pldTo);
                //
                plcTo.NRO_PLANILLA_DOC = pllcTo.NRO_PLANILLA_COB;
                plcTo.COD_INSTITUCION = pllcTo.COD_INSTITUCION;
                plcTo.COD_CANAL_DSCTO = pllcTo.COD_CANAL_DSCTO;
                plcTo.FE_AÑO = pllcTo.FE_AÑO;
                plcTo.FE_MES = pllcTo.FE_MES;
                plcTo.TIPO_PLANILLA_DOC = pllcTo.TIPO_PLANILLA;
                NRO_PLANILLA_COBRANZA = pllcTo.NRO_PLANILLA_COB;

                if (!plcBLL.aprobarPlanillasDescuentoDirectaBLL(pllcTo, plcTo, dtDetalle, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Se aprobó o cerró correctamente", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TabControl1.SelectedTab = TabPage1;
                    DATAGRID();
                    CARGAR_PERSONAS();//para actualizar el grid desplegable
                    FOCO_NUEVO_REG("aprobar");
                }
            }
        }

        private void chkComprometidas_CheckedChanged(object sender, EventArgs e)
        {
            calculaCuotasaCobrar();
        }

        private void txt_letra_TextChanged(object sender, EventArgs e)
        {
            int i;
            if (ch_cod.Checked)
            {
                txt_letra.Focus();
                for (i = 0; i < dgv_generados.Rows.Count; i++)
                {
                    if (txt_letra.TextLength <= dgv_generados.Rows[i].Cells["NRO_CONTRATO2"].Value.ToString().Length)
                    {
                        if (txt_letra.Text.ToLower() == dgv_generados.Rows[i].Cells["NRO_CONTRATO2"].Value.ToString().Substring(0, txt_letra.TextLength).ToLower())
                        {
                            dgv_generados.CurrentCell = dgv_generados.Rows[i].Cells["NRO_CONTRATO2"];
                            break;
                        }
                    }

                }
            }
            else if (ch_rs.Checked)
            {
                txt_letra.Focus();
                for (i = 0; i < dgv_generados.Rows.Count; i++)
                {
                    if (txt_letra.TextLength <= dgv_generados.Rows[i].Cells["DESC_PER2"].Value.ToString().Length)
                    {
                        if (txt_letra.Text.ToLower() == dgv_generados.Rows[i].Cells["DESC_PER2"].Value.ToString().Substring(0, txt_letra.TextLength).ToLower())
                        {
                            dgv_generados.CurrentCell = dgv_generados.Rows[i].Cells["DESC_PER2"];
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
                dgv_generados.Sort(dgv_generados.Columns["NRO_CONTRATO2"], System.ComponentModel.ListSortDirection.Ascending);
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
                dgv_generados.Sort(dgv_generados.Columns["DESC_PER2"], System.ComponentModel.ListSortDirection.Ascending);
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
            for (i = 0; i < dgv_generados.Rows.Count; i++)
            {
                for (f = 0; f <= dgv_generados.Rows[i].Cells["DESC_PER2"].Value.ToString().Length - txt_letra.TextLength; f++)
                {
                    if (txt_letra.TextLength <= dgv_generados.Rows[i].Cells["DESC_PER2"].Value.ToString().Length)
                    {
                        if (txt_letra.Text.ToLower() == dgv_generados.Rows[i].Cells["DESC_PER2"].Value.ToString().Substring(f, txt_letra.TextLength).ToLower())
                        {
                            dgv_generados.CurrentCell = dgv_generados.Rows[i].Cells["DESC_PER2"];
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
            for (i = fila; i < dgv_generados.Rows.Count; i++)
            {
                for (f = 0; f <= dgv_generados.Rows[i].Cells["DESC_PER2"].Value.ToString().Length - txt_letra.TextLength; f++)
                {
                    if (txt_letra.TextLength <= dgv_generados.Rows[i].Cells["DESC_PER2"].Value.ToString().Length)
                    {
                        if (txt_letra.Text.ToLower() == dgv_generados.Rows[i].Cells["DESC_PER2"].Value.ToString().Substring(f, txt_letra.TextLength).ToLower())
                        {
                            dgv_generados.CurrentCell = dgv_generados.Rows[i].Cells["DESC_PER2"];
                            fila = i + 1;
                            return;
                        }
                    }
                }
            }
            MessageBox.Show("Ya no existen más registros !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
