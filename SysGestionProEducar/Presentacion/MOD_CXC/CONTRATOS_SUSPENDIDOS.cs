using BLL;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;

namespace Presentacion.MOD_CXC
{
    public partial class CONTRATOS_SUSPENDIDOS : Form
    {
        string AÑO = "", MES = "", COD_MOD = "", COD_USU = "", TIPO_USU = "";
        DateTime FECHA_INI, FECHA_GRAL;
        contratosSuspendidosBLL csBLL = new contratosSuspendidosBLL();
        contratosSuspendidosTo csTo = new contratosSuspendidosTo();
        HelpersBLL helBLL = new HelpersBLL();
        HelpersTo helTo = new HelpersTo();
        directorioBLL dirBLL = new directorioBLL();
        directorioTo dirTo = new directorioTo();
        DataTable dtPersona;
        DateTime fecha_ini_sus; DateTime fecha_fin_sus;
        int fila = 0;
        public CONTRATOS_SUSPENDIDOS(string AÑO, string MES, DateTime FECHA_INI, DateTime FECHA_GRAL, string COD_MOD, string TIPO_USU, string COD_USU)
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

        private void CONTRATOS_SUSPENDIDOS_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            DATAGRID();
            CARGAR_SUCURSAL();
            CARGA_INSTITUCIONES();
            CARGAR_PERSONAS();
            CARGAR_MOTIVOS();
            //dtp_generacion.Value = Convert.ToDateTime(DateTime.Now.Day + "/" + MES + "/" + AÑO);
            DateTime fe_plla = DateTime.Now;
            if (DateTime.TryParse((DateTime.Now.Day + "/" + MES + "/" + AÑO), out fe_plla))
                dtp_generacion.Value = Convert.ToDateTime(DateTime.Now.Day + "/" + MES + "/" + AÑO);
            else
                dtp_generacion.Value = FECHA_GRAL;
            //dtp_anulacion.Value = Convert.ToDateTime(DateTime.Now.Day + "/" + MES + "/" + AÑO);
            DateTime fe_anul = DateTime.Now;
            if (DateTime.TryParse((DateTime.Now.Day + "/" + MES + "/" + AÑO), out fe_anul))
                dtp_anulacion.Value = Convert.ToDateTime(DateTime.Now.Day + "/" + MES + "/" + AÑO);
            else
                dtp_anulacion.Value = FECHA_GRAL;
            llenacomboMesIni();
            llenacomboMesFin();
            llenacomboAnnioIni();
            llenacomboAnnioFin();
            cbo_ini_mes.SelectedValue = dtp_generacion.Value.Month.ToString().PadLeft(2, '0');
            cbo_ini_annio.SelectedValue = dtp_generacion.Value.Year;
            cbo_fin_mes.SelectedValue = cbo_ini_mes.SelectedValue;
            cbo_fin_annio.SelectedValue = cbo_ini_annio.SelectedValue;
            //dtp_anulacion.Format = DateTimePickerFormat.Custom;
            //dtp_anulacion.CustomFormat = "''";
        }

        private void CONTRATOS_SUSPENDIDOS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }
        private void llenacomboMesIni()
        {
            cbo_ini_mes.ValueMember = "cod";
            cbo_ini_mes.DisplayMember = "nom";
            cbo_ini_mes.DataSource = HelpersBLL.OBTENER_MESES();
        }
        private void llenacomboAnnioIni()
        {
            cbo_ini_annio.ValueMember = "cod";
            cbo_ini_annio.DisplayMember = "nom";
            cbo_ini_annio.DataSource = HelpersBLL.OBTENER_AÑOS();
        }
        private void llenacomboMesFin()
        {
            cbo_fin_mes.ValueMember = "cod";
            cbo_fin_mes.DisplayMember = "nom";
            cbo_fin_mes.DataSource = HelpersBLL.OBTENER_MESES();
        }
        private void llenacomboAnnioFin()
        {
            cbo_fin_annio.ValueMember = "cod";
            cbo_fin_annio.DisplayMember = "nom";
            cbo_fin_annio.DataSource = HelpersBLL.OBTENER_AÑOS();
        }
        private void DATAGRID()
        {
            csTo.ST_SUSPENSION = "1";
            DataTable dt = csBLL.obtenerContratosSuspendidosActivosBLL(csTo);
            if (dt.Rows.Count > 0)
            {
                dgv_generados.Rows.Clear();
                foreach (DataRow rw in dt.Rows)
                {
                    int rowId = dgv_generados.Rows.Add();
                    DataGridViewRow row = dgv_generados.Rows[rowId];
                    row.Cells["COD_SUCURSAL"].Value = rw["COD_SUCURSAL"].ToString();
                    row.Cells["COD_INSTITUCION"].Value = rw["COD_INSTITUCION"].ToString();
                    row.Cells["NRO_CONTRATO"].Value = rw["NRO_CONTRATO"].ToString();
                    row.Cells["FECHA_SUSPENSION"].Value = rw["FECHA_SUSPENSION"].ToString().Substring(0, 10);
                    row.Cells["FECHA_INIC_SUS"].Value = rw["FECHA_INI_SUS"].ToString().Substring(0, 10);
                    row.Cells["FECHA_FINI_SUS"].Value = rw["FECHA_FIN_SUS"].ToString().Substring(0, 10);
                    row.Cells["COD_MOTIVO"].Value = rw["COD_MOTIVO"].ToString();
                    row.Cells["OBSERVACIONES"].Value = rw["OBSERVACIONES"].ToString();
                    row.Cells["COD_PER"].Value = rw["COD_PER"].ToString();
                    row.Cells["DESC_PER"].Value = rw["DESC_PER"].ToString();
                    row.Cells["NRO_DOC"].Value = rw["NRO_DOC"].ToString();
                    row.Cells["DESC_INST"].Value = rw["DESC_INST"].ToString();
                    row.Cells["COD_PTO_COB"].Value = rw["COD_PTO_COB"].ToString();
                    row.Cells["DESC_PTO_COB"].Value = rw["DESC_PTO_COB"].ToString();
                    row.Cells["ST_APROBACION"].Value = rw["ST_APROBACION"].ToString() == "1" ? true : false;
                    row.Cells["ST_ANULACION"].Value = rw["ST_ANULACION"].ToString() == "1" ? true : false;
                    row.Cells["SOLICITANTE"].Value = rw["SOLICITANTE"].ToString();
                    row.Cells["APROBADOR"].Value = rw["APROBADOR"].ToString();
                    row.Cells["MOTIVO"].Value = rw["MOTIVO"].ToString();
                    row.Cells["FECHA_ANULACION"].Value = rw["FECHA_ANULACION"].ToString() != "" ? rw["FECHA_ANULACION"].ToString() : "";
                    row.Cells["COD_ANULACION"].Value = rw["COD_ANULACION"].ToString();
                    row.Cells["OBS_ANULACION"].Value = rw["OBS_ANULACION"].ToString();
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
        private void CARGA_INSTITUCIONES()
        {
            institucionesBLL insBLL = new institucionesBLL();
            DataTable dtInstitucion = insBLL.obtenerInstitucionesBLL();
            cbo_institucion.ValueMember = "COD_INST";
            cbo_institucion.DisplayMember = "DESC_INST";
            cbo_institucion.DataSource = dtInstitucion;
            cbo_institucion.SelectedIndex = 0;
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
                dgw_per.Columns["COD_SUCURSAL"].Visible = false;
                dgw_per.Columns["COD_INSTITUCION"].Visible = false;
                dgw_per.Columns["COD_CANAL_DSCTO"].Visible = false;
                dgw_per.Columns["IMP_DOC"].Visible = false;
                dgw_per.Columns["COD_PTO_COB"].Visible = false;
            }
        }
        private void CARGAR_MOTIVOS()
        {
            dirTo.TABLA_COD = "TCSUS";
            DataTable dt = dirBLL.MOSTRAR_DIRECTORIO_DATO_BLL(dirTo);
            if (dt.Rows.Count > 0)
            {
                cbo_motivo.DataSource = dt;
                cbo_motivo.ValueMember = "Codigo";
                cbo_motivo.DisplayMember = "Descripción";
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
                cbo_pto_cob.SelectedValue = dgw_per.Rows[idx].Cells["COD_PTO_COB"].Value;
                txt_contrato.Text = dgw_per.Rows[idx].Cells["NRO_PRESUPUESTO"].Value.ToString();
                Panel_PER.Visible = false;
                MostrarCuotasNoCanceladas();
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
        private void MostrarCuotasNoCanceladas()
        {
            dgw_det.Rows.Clear();
            csTo.COD_SUCURSAL = cbo_sucursal.SelectedValue.ToString();
            csTo.NRO_CONTRATO = txt_contrato.Text;
            DataTable dtCuotas = obtieneCuotasNoCanceladasBLL(csTo);
            {
                foreach (DataRow rw in dtCuotas.Rows)
                {
                    int rowId = dgw_det.Rows.Add();
                    DataGridViewRow row = dgw_det.Rows[rowId];
                    row.Cells["NRO_DOCU"].Value = rw["NRO_DOC"].ToString();
                    row.Cells["NRO_LETRA"].Value = rw["NRO_LETRA"].ToString();
                    row.Cells["TOTAL_LETRA"].Value = rw["TOTAL_LETRA"].ToString();
                    row.Cells["IMP_DOC"].Value = rw["IMP_DOC"].ToString();
                    row.Cells["FECHA_VEN"].Value = rw["FECHA_VEN"].ToString().Substring(0, 10);
                }
            }
        }
        private DataTable obtieneCuotasNoCanceladasBLL(contratosSuspendidosTo plcTo)
        {
            DataTable dt;
            canjePCtasxCobrarBLL pccBLL = new canjePCtasxCobrarBLL();
            canjePCtasxCobrarTo pccTo = new canjePCtasxCobrarTo();
            pccTo.COD_SUCURSAL = plcTo.COD_SUCURSAL;
            pccTo.COD_CLASE = "01";
            pccTo.NRO_CONTRATO = plcTo.NRO_CONTRATO;
            return dt = pccBLL.obtenerCuotasPendientesxContratoBLL(pccTo);
        }
        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            btn_grabar.Visible = true;
            btn_modificar2.Visible = false;
            btn_anul.Visible = false;
            TXT_COD.Enabled = true;
            TXT_DESC.Enabled = true;
            txt_doc_per.Enabled = true;
            dtp_generacion.Enabled = true;
            txt_obs_anulacion.Enabled = false;
            dtp_anulacion.Enabled = false;
            TabControl1.SelectedTab = (TabPage2);
            LIMPIAR();
            cbo_sucursal.SelectedIndex = -1;
            btn_grabar.Enabled = true;
            cbo_institucion.Enabled = false;
            cbo_pto_cob.Enabled = false;
            //dtp_generacion.Value = Convert.ToDateTime(DateTime.Now.Day + "/" + MES + "/" + AÑO);// +DateTime.Now.TimeOfDay;
            DateTime fe_plla = DateTime.Now;
            if (DateTime.TryParse((DateTime.Now.Day + "/" + MES + "/" + AÑO), out fe_plla))
                dtp_generacion.Value = Convert.ToDateTime(DateTime.Now.Day + "/" + MES + "/" + AÑO);
            else
                dtp_generacion.Value = FECHA_GRAL;
            dtp_fe_ini_susp.Value = dtp_generacion.Value;
            dtp_fe_fin_susp.Value = dtp_generacion.Value;
            TXT_COD.Focus();
        }
        private void LIMPIAR()
        {
            cbo_sucursal.SelectedIndex = -1;
            cbo_institucion.SelectedIndex = -1;
            //lbl_cod_tipo_plla.Text = "XX";
            TXT_COD.Clear();
            TXT_DESC.Clear();
            txt_doc_per.Clear();
            cbo_pto_cob.SelectedIndex = -1;
            //cbo_tipo_planilla.SelectedIndex = -1;
            txt_observaciones.Clear();
            dgw_det.Rows.Clear();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            TabControl1.SelectedTab = (TabPage1);
        }

        private void cbo_institucion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_institucion.SelectedValue != null)
            {
                CARGAR_PUNTOS_COBRANZA();
            }
        }
        private void CARGAR_PUNTOS_COBRANZA()
        {
            puntoCobranzaBLL pcBLL = new puntoCobranzaBLL();
            puntoCobranzaTo pcTo = new puntoCobranzaTo();
            pcTo.COD_INSTITUCION = cbo_institucion.SelectedValue.ToString();
            pcTo.STATUS_CONSOLIDADO = true;
            DataTable dt = pcBLL.obtenerPuntosCobranza_x_Inst_BLL(pcTo);
            if (dt.Rows.Count > 0)
            {
                cbo_pto_cob.DataSource = dt;
                cbo_pto_cob.ValueMember = "COD_PTO_COB";
                cbo_pto_cob.DisplayMember = "DESC_PTO_COB";
            }
        }

        private void btn_grabar_Click(object sender, EventArgs e)
        {
            if (!validaFormulario())
                return;
            DialogResult rs = MessageBox.Show("¿ Esta seguro de suspender algunas de cuotas del contrato ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                csTo.COD_SUCURSAL = cbo_sucursal.SelectedValue.ToString();
                csTo.COD_INSTITUCION = cbo_institucion.SelectedValue.ToString();
                csTo.NRO_CONTRATO = txt_contrato.Text;
                csTo.FECHA_SUSPENSION = dtp_generacion.Value;
                csTo.COD_PER = TXT_COD.Text;
                csTo.COD_PTO_COB = cbo_pto_cob.SelectedValue.ToString();
                csTo.FECHA_INI_SUS = fecha_ini_sus; //Convert.ToDateTime("01/"+cbo_ini_mes.SelectedValue.ToString()+"/"+cbo_ini_annio.SelectedValue.ToString());
                csTo.FECHA_FIN_SUS = fecha_fin_sus; //Convert.ToDateTime("01/"+mes_fin+"/"+annio_fin).AddDays(-1);
                csTo.COD_MOTIVO = cbo_motivo.SelectedValue.ToString();
                csTo.OBSERVACIONES = txt_observaciones.Text;
                csTo.ST_SUSPENSION = "1";
                csTo.ST_ANULACION = "0";
                csTo.COD_CREACION = COD_USU;
                csTo.FECHA_CREACION = DateTime.Now;

                if (!csBLL.insertarContratosSuspendidosBLL(csTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("La suspension se hizo correctamente", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TabControl1.SelectedTab = TabPage1;
                    DATAGRID();
                    CARGAR_PERSONAS();//para actualizar el grid desplegable
                    FOCO_NUEVO_REG();
                }
            }
        }
        private bool validaFormulario()
        {
            bool result = true;
            fecha_ini_sus = HelpersBLL.FECHA_INI_DESCRIPCION_BLL(cbo_ini_mes.SelectedValue.ToString(), cbo_ini_annio.SelectedValue.ToString());
            fecha_fin_sus = HelpersBLL.FECHA_FIN_DESCRIPCION_BLL(cbo_fin_mes.SelectedValue.ToString(), cbo_fin_annio.SelectedValue.ToString());
            if (TXT_COD.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el codigo del cliente !!!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TXT_COD.Focus();
                return result = false;
            }
            if (TXT_DESC.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el nombre del cliente !!!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TXT_DESC.Focus();
                return result = false;
            }
            if (cbo_motivo.SelectedIndex == -1)
            {
                MessageBox.Show("Elija el motivo de suspension de cuotas !!!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_motivo.Focus();
                return result = false;
            }
            //fechas
            if (dtp_generacion.Value < FECHA_INI.Date)
            {
                MessageBox.Show("La fecha de suspension inicial es inferior a la del Periodo !!! ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtp_generacion.Focus();
                return result = false;
            }
            if (fecha_ini_sus.Date < FECHA_INI.Date)
            {
                MessageBox.Show("La fecha de inicio de suspension es inferior a la del Periodo !!! ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_ini_mes.Focus();
                return result = false;
            }
            if (fecha_fin_sus.Date < FECHA_INI.Date)
            {
                MessageBox.Show("La fecha de fin suspension es inferior a la del Periodo !!! ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_fin_mes.Focus();
                return result = false;
            }
            if (fecha_ini_sus.Date > fecha_fin_sus.Date)
            {
                MessageBox.Show("La fecha inicio de suspension es mayor a la fecha fin de suspension !!! ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_ini_mes.Focus();
                return result = false;
            }
            if (btn_grabar.Visible)
            {
                //trae contratos suspendidos
                csTo.NRO_CONTRATO = txt_contrato.Text;
                DataTable dtContratosSuspendidos = csBLL.obtenerContratosSuspendidosActivosxContratoBLL(csTo);
                if (dtContratosSuspendidos.Rows.Count > 0)
                {
                    foreach (DataRow rw in dtContratosSuspendidos.Rows)
                    {
                        if (Convert.ToDateTime(rw["FECHA_INI_SUS"]).Date <= fecha_ini_sus.Date && fecha_ini_sus.Date <= Convert.ToDateTime(rw["FECHA_FIN_SUS"]).Date ||
                            Convert.ToDateTime(rw["FECHA_INI_SUS"]).Date <= fecha_fin_sus.Date && fecha_fin_sus.Date <= Convert.ToDateTime(rw["FECHA_FIN_SUS"]).Date)
                        {
                            MessageBox.Show("El contrato " + rw["NRO_CONTRATO"].ToString() + " ya está suspendido en el periodo de " + HelpersBLL.OBTENER_PERIODOS_BLL(rw["FECHA_INI_SUS"].ToString(), rw["FECHA_FIN_SUS"].ToString()), "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            cbo_ini_mes.Focus();
                            return result = false;
                        }
                    }
                }
            }
            return result;
        }
        private void FOCO_NUEVO_REG()
        {
            int i, cont = 0;
            cont = dgv_generados.Columns.Count - 1;
            string nrocon = txt_contrato.Text;
            string fecha_sus = dtp_generacion.Value.ToShortDateString();
            for (i = 0; i <= cont; i++)
            {
                if (nrocon == dgv_generados.Rows[i].Cells["NRO_CONTRATO"].Value.ToString())
                {
                    if (fecha_sus == dgv_generados.Rows[i].Cells["FECHA_SUSPENSION"].Value.ToString())
                    {
                        dgv_generados.CurrentCell = dgv_generados.Rows[i].Cells["FECHA_SUSPENSION"];
                        return;
                    }
                }
            }
        }

        private void btn_modificar2_Click(object sender, EventArgs e)
        {
            if (!validaFormulario())
                return;
            DialogResult rs = MessageBox.Show("¿ Esta seguro modificar el contrato Suspendido ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                csTo.COD_SUCURSAL = cbo_sucursal.SelectedValue.ToString();
                csTo.COD_INSTITUCION = cbo_institucion.SelectedValue.ToString();
                csTo.NRO_CONTRATO = txt_contrato.Text;
                csTo.FECHA_SUSPENSION = dtp_generacion.Value;
                csTo.COD_PER = TXT_COD.Text;
                csTo.COD_PTO_COB = cbo_pto_cob.SelectedValue.ToString();
                csTo.FECHA_INI_SUS = fecha_ini_sus;//dtp_fe_ini_susp.Value;
                csTo.FECHA_FIN_SUS = fecha_fin_sus;//dtp_fe_fin_susp.Value;
                csTo.COD_MOTIVO = cbo_motivo.SelectedValue.ToString();
                csTo.OBSERVACIONES = txt_observaciones.Text;
                csTo.ST_SUSPENSION = "1";
                csTo.ST_ANULACION = "0";
                csTo.COD_MODIFICACION = COD_USU;
                csTo.FECHA_MODIFICACION = DateTime.Now;

                if (!csBLL.modificarContratosSuspendidosBLL(csTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("La modificación se hizo correctamente", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TabControl1.SelectedTab = TabPage1;
                    DATAGRID();
                    FOCO_NUEVO_REG();
                }
            }
        }
        private bool validaModificar()
        {
            bool result = true;
            if (Convert.ToBoolean(dgv_generados.CurrentRow.Cells["ST_ANULACION"].Value))
            {
                MessageBox.Show("No se puede Modificar porque ya está Anulado !!!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            btn_anul.Visible = false;
            txt_obs_anulacion.Enabled = false;
            dtp_anulacion.Enabled = false;
            TabControl1.SelectedTab = (TabPage2);
            LIMPIAR();
            btn_grabar.Enabled = false;
            btn_modificar2.Enabled = true;
            TXT_COD.Enabled = false;
            TXT_DESC.Enabled = false;
            txt_doc_per.Enabled = false;
            dtp_generacion.Enabled = false;
            cbo_institucion.Enabled = false;
            cbo_pto_cob.Enabled = false;
            CARGAR_CABECERA_DOCUMENTO();
            CARGAR_DETALLE_DOCUMENTO();
        }
        private void CARGAR_CABECERA_DOCUMENTO(int op = 0)
        {
            TXT_COD.Text = dgv_generados.CurrentRow.Cells["COD_PER"].Value.ToString();
            TXT_DESC.Text = dgv_generados.CurrentRow.Cells["DESC_PER"].Value.ToString();
            txt_doc_per.Text = dgv_generados.CurrentRow.Cells["NRO_DOC"].Value.ToString();
            txt_contrato.Text = dgv_generados.CurrentRow.Cells["NRO_CONTRATO"].Value.ToString();
            cbo_sucursal.SelectedValue = dgv_generados.CurrentRow.Cells["COD_SUCURSAL"].Value.ToString();
            cbo_institucion.SelectedValue = dgv_generados.CurrentRow.Cells["COD_INSTITUCION"].Value;
            dtp_generacion.Value = Convert.ToDateTime(dgv_generados.CurrentRow.Cells["FECHA_SUSPENSION"].Value);
            cbo_pto_cob.SelectedValue = dgv_generados.CurrentRow.Cells["COD_PTO_COB"].Value;
            dtp_fe_ini_susp.Value = Convert.ToDateTime(dgv_generados.CurrentRow.Cells["FECHA_INIC_SUS"].Value);
            dtp_fe_fin_susp.Value = Convert.ToDateTime(dgv_generados.CurrentRow.Cells["FECHA_FINI_SUS"].Value);
            cbo_ini_mes.SelectedValue = dgv_generados.CurrentRow.Cells["FECHA_INIC_SUS"].Value.ToString().Substring(3, 2);
            cbo_ini_annio.SelectedValue = dgv_generados.CurrentRow.Cells["FECHA_INIC_SUS"].Value.ToString().Substring(6, 4);
            cbo_fin_mes.SelectedValue = dgv_generados.CurrentRow.Cells["FECHA_FINI_SUS"].Value.ToString().Substring(3, 2);
            cbo_fin_annio.SelectedValue = dgv_generados.CurrentRow.Cells["FECHA_FINI_SUS"].Value.ToString().Substring(6, 4);
            cbo_motivo.SelectedValue = dgv_generados.CurrentRow.Cells["COD_MOTIVO"].Value;
            txt_observaciones.Text = dgv_generados.CurrentRow.Cells["OBSERVACIONES"].Value.ToString();
            if (dgv_generados.CurrentRow.Cells["FECHA_ANULACION"].Value.ToString() != "")
            {
                dtp_anulacion.Format = DateTimePickerFormat.Short;
                //dtp_anulacion.CustomFormat = "''";
                dtp_anulacion.Value = Convert.ToDateTime(dgv_generados.CurrentRow.Cells["FECHA_ANULACION"].Value);
            }
            else
            {
                if (op != 1)
                {
                    dtp_anulacion.Format = DateTimePickerFormat.Custom;
                    dtp_anulacion.CustomFormat = "''";
                }
                else
                {
                    dtp_anulacion.Format = DateTimePickerFormat.Short;
                    //dtp_anulacion.Value = Convert.ToDateTime(DateTime.Now.Day + "/" + MES + "/" + AÑO);                    
                    DateTime fe_plla = DateTime.Now;
                    if (DateTime.TryParse((DateTime.Now.Day + "/" + MES + "/" + AÑO), out fe_plla))
                        dtp_anulacion.Value = Convert.ToDateTime(DateTime.Now.Day + "/" + MES + "/" + AÑO);
                    else
                        dtp_anulacion.Value = FECHA_GRAL;
                }

            }
            txt_obs_anulacion.Text = dgv_generados.CurrentRow.Cells["OBS_ANULACION"].Value.ToString();
        }
        private void CARGAR_DETALLE_DOCUMENTO()
        {
            MostrarCuotasNoCanceladas();
        }

        private void btn_consulta_Click(object sender, EventArgs e)
        {
            btn_grabar.Visible = false;
            btn_modificar2.Visible = false;
            btn_anul.Visible = false;
            txt_obs_anulacion.Enabled = false;
            dtp_anulacion.Enabled = false;
            TabControl1.SelectedTab = (TabPage2);
            LIMPIAR();
            //btn_grabar.Enabled = false;
            //btn_modificar2.Enabled = true;
            TXT_COD.Enabled = false;
            TXT_DESC.Enabled = false;
            txt_doc_per.Enabled = false;
            dtp_generacion.Enabled = false;
            cbo_institucion.Enabled = false;
            cbo_pto_cob.Enabled = false;
            CARGAR_CABECERA_DOCUMENTO();
            CARGAR_DETALLE_DOCUMENTO();
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (!validaEliminacion())
                return;
            DialogResult rs = MessageBox.Show("¿ Esta seguro de eliminar el contrato Suspendido ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                csTo.COD_SUCURSAL = dgv_generados.CurrentRow.Cells["COD_SUCURSAL"].Value.ToString();
                csTo.COD_INSTITUCION = dgv_generados.CurrentRow.Cells["COD_INSTITUCION"].Value.ToString();
                csTo.NRO_CONTRATO = dgv_generados.CurrentRow.Cells["NRO_CONTRATO"].Value.ToString();
                csTo.FECHA_SUSPENSION = Convert.ToDateTime(dgv_generados.CurrentRow.Cells["FECHA_SUSPENSION"].Value);

                if (!csBLL.eliminarContratosSuspendidosBLL(csTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("La eliminacion se hizo correctamente", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TabControl1.SelectedTab = TabPage1;
                    DATAGRID();
                    //FOCO_NUEVO_REG();
                }
            }
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btn_desactivar_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Esta operacion desactivará todos los contratos suspendidos hasta la fecha " + dtp_generacion.Value.ToShortDateString() + " \n¿ Desea hacerlo ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                csTo.FECHA_SUSPENSION = dtp_generacion.Value;
                csTo.ST_SUSPENSION = "0";
                if (!csBLL.desactivarContratosSuspendidosBLL(csTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Se desactivaron correctamente los contratos suspendidos a la fecha mencionada", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TabControl1.SelectedTab = TabPage1;
                    DATAGRID();
                    //FOCO_NUEVO_REG();
                }
            }
        }

        private void btn_aprobar_Click(object sender, EventArgs e)
        {
            if (!validaAprobar())
                return;

            DialogResult rs = MessageBox.Show("¿ Esta seguro de aprobar la suspension del Contrato ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                csTo.COD_SUCURSAL = dgv_generados.CurrentRow.Cells["COD_SUCURSAL"].Value.ToString();
                csTo.COD_INSTITUCION = dgv_generados.CurrentRow.Cells["COD_INSTITUCION"].Value.ToString();
                csTo.NRO_CONTRATO = dgv_generados.CurrentRow.Cells["NRO_CONTRATO"].Value.ToString();
                csTo.FECHA_SUSPENSION = Convert.ToDateTime(dgv_generados.CurrentRow.Cells["FECHA_SUSPENSION"].Value);
                csTo.COD_APROBACION = COD_USU;
                csTo.FECHA_APROBACION = DateTime.Now;
                csTo.ST_APROBACION = "1";
                if (!csBLL.aprobarContratosSuspendidosBLL(csTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Se Aprobó las suspension del Contrato", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DATAGRID();
                    //FOCO_NUEVO_REG();
                }
            }
        }
        private bool validaAprobar()
        {
            bool result = true;
            if (Convert.ToBoolean(dgv_generados.CurrentRow.Cells["ST_APROBACION"].Value))
            {
                MessageBox.Show("No se puede Aprobar porque ya está Aprobado !!!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return result = false;
            }
            if (Convert.ToBoolean(dgv_generados.CurrentRow.Cells["ST_ANULACION"].Value))
            {
                MessageBox.Show("No se puede Aprobar porque ya está Anulado !!!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return result = false;
            }
            return result;
        }

        private void txt_letra_TextChanged(object sender, EventArgs e)
        {
            int i;
            if (ch_cod.Checked)
            {
                txt_letra.Focus();
                for (i = 0; i < dgv_generados.Rows.Count; i++)
                {
                    if (txt_letra.TextLength <= dgv_generados.Rows[i].Cells["NRO_CONTRATO"].Value.ToString().Length)
                    {
                        if (txt_letra.Text.ToLower() == dgv_generados.Rows[i].Cells["NRO_CONTRATO"].Value.ToString().Substring(0, txt_letra.TextLength).ToLower())
                        {
                            dgv_generados.CurrentCell = dgv_generados.Rows[i].Cells["NRO_CONTRATO"];
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
                    if (txt_letra.TextLength <= dgv_generados.Rows[i].Cells["DESC_PER"].Value.ToString().Length)
                    {
                        if (txt_letra.Text.ToLower() == dgv_generados.Rows[i].Cells["DESC_PER"].Value.ToString().Substring(0, txt_letra.TextLength).ToLower())
                        {
                            dgv_generados.CurrentCell = dgv_generados.Rows[i].Cells["DESC_PER"];
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
                dgv_generados.Sort(dgv_generados.Columns["NRO_CONTRATO"], System.ComponentModel.ListSortDirection.Ascending);
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
                dgv_generados.Sort(dgv_generados.Columns["DESC_PER"], System.ComponentModel.ListSortDirection.Ascending);
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
                for (f = 0; f <= dgv_generados.Rows[i].Cells["DESC_PER"].Value.ToString().Length - txt_letra.TextLength; f++)
                {
                    if (txt_letra.TextLength <= dgv_generados.Rows[i].Cells["DESC_PER"].Value.ToString().Length)
                    {
                        if (txt_letra.Text.ToLower() == dgv_generados.Rows[i].Cells["DESC_PER"].Value.ToString().Substring(f, txt_letra.TextLength).ToLower())
                        {
                            dgv_generados.CurrentCell = dgv_generados.Rows[i].Cells["DESC_PER"];
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
                for (f = 0; f <= dgv_generados.Rows[i].Cells["DESC_PER"].Value.ToString().Length - txt_letra.TextLength; f++)
                {
                    if (txt_letra.TextLength <= dgv_generados.Rows[i].Cells["DESC_PER"].Value.ToString().Length)
                    {
                        if (txt_letra.Text.ToLower() == dgv_generados.Rows[i].Cells["DESC_PER"].Value.ToString().Substring(f, txt_letra.TextLength).ToLower())
                        {
                            dgv_generados.CurrentCell = dgv_generados.Rows[i].Cells["DESC_PER"];
                            fila = i + 1;
                            return;
                        }
                    }
                }
            }
            MessageBox.Show("Ya no existen más registros !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        private bool validaAnular()
        {
            bool result = true;

            if (Convert.ToBoolean(dgv_generados.CurrentRow.Cells["ST_ANULACION"].Value))
            {
                MessageBox.Show("No se puede Anular porque ya está Anulado !!!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return result = false;
            }
            return result;
        }
        private void btn_anular_Click(object sender, EventArgs e)
        {
            if (!validaAnular())
                return;
            btn_grabar.Visible = false;
            btn_modificar2.Visible = false;
            btn_anul.Visible = true;
            txt_obs_anulacion.Enabled = true;
            dtp_anulacion.Enabled = true;
            TabControl1.SelectedTab = (TabPage2);
            LIMPIAR();
            btn_grabar.Enabled = false;
            btn_modificar2.Enabled = false;
            btn_anul.Enabled = true;
            TXT_COD.Enabled = false;
            TXT_DESC.Enabled = false;
            txt_doc_per.Enabled = false;
            dtp_generacion.Enabled = false;
            cbo_institucion.Enabled = false;
            cbo_pto_cob.Enabled = false;
            CARGAR_CABECERA_DOCUMENTO(1);
            CARGAR_DETALLE_DOCUMENTO();
        }

        private void btn_anul_Click(object sender, EventArgs e)
        {
            if (!validaAnulacion())
                return;

            DialogResult rs = MessageBox.Show("¿ Esta seguro de Anular el contrato Suspendido ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                csTo.COD_SUCURSAL = dgv_generados.CurrentRow.Cells["COD_SUCURSAL"].Value.ToString();
                csTo.COD_INSTITUCION = dgv_generados.CurrentRow.Cells["COD_INSTITUCION"].Value.ToString();
                csTo.NRO_CONTRATO = dgv_generados.CurrentRow.Cells["NRO_CONTRATO"].Value.ToString();
                csTo.FECHA_SUSPENSION = Convert.ToDateTime(dgv_generados.CurrentRow.Cells["FECHA_SUSPENSION"].Value);
                csTo.FECHA_ANULACION = dtp_anulacion.Value;
                csTo.COD_ANULACION = COD_USU;
                csTo.OBS_ANULACION = txt_obs_anulacion.Text;

                if (!csBLL.anularContratosSuspendidosBLL(csTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("La anulacion se hizo correctamente", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TabControl1.SelectedTab = TabPage1;
                    DATAGRID();
                    //FOCO_NUEVO_REG();
                }
            }
        }
        private bool validaAnulacion()
        {
            bool result = true;
            if (!(dgv_generados.Rows.Count > 0))
                return result = false;

            if (dtp_anulacion.Value.Date < dtp_generacion.Value.Date)
            {
                MessageBox.Show("La fecha de suspension debe ser menor o igual a la fecha de anulacion !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtp_anulacion.Focus();
                return result = false;
            }
            if (FECHA_GRAL.Date > Convert.ToDateTime(dgv_generados.CurrentRow.Cells["FECHA_FINI_SUS"].Value))
            {
                MessageBox.Show("No se puede anular un contrato suspendido cuya fecha fin de suspension es menor que la del periodo actual !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return result = false;
            }
            if (txt_obs_anulacion.Text == "")
            {
                MessageBox.Show("Debe escribir una observacion, por qué va a anular la suspension de contrato !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_obs_anulacion.Focus();
                return result = false;
            }
            return result;
        }
        private bool validaEliminacion()
        {
            bool result = true;
            if (!(dgv_generados.Rows.Count > 0))
                return result = false;
            if (FECHA_GRAL.Date > Convert.ToDateTime(dgv_generados.CurrentRow.Cells["FECHA_FINI_SUS"].Value))
            {
                MessageBox.Show("No se puede anular un contrato suspendido cuya fecha fin de suspension es menor que la del periodo actual !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return result = false;
            }
            return result;
        }
        private void dtp_anulacion_ValueChanged(object sender, EventArgs e)
        {
            dtp_anulacion.CustomFormat = "dd/MM/yyyy";
        }
    }
}
