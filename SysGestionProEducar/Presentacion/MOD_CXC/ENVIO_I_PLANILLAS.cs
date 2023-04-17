using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Presentacion.MOD_CXC
{
    public partial class ENVIO_I_PLANILLAS : Form
    {
        string AÑO = "", MES = "", COD_MOD = "", COD_USU = "", TIPO_USU = "";
        DateTime FECHA_INI, FECHA_GRAL;
        string BOTON;
        planillaCabeceraBLL plcBLL = new planillaCabeceraBLL();
        planillaCabeceraTo plcTo = new planillaCabeceraTo();
        public ENVIO_I_PLANILLAS(string AÑO, string MES, DateTime FECHA_INI, DateTime FECHA_GRAL, string COD_MOD, string TIPO_USU, string COD_USU)
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

        private void ENVIO_I_PLANILLAS_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            PLANILLAS_ENVIADAS();
            PENDIENTES_X_ENVIAR();
            CARGAR_SUCURSAL();
            CARGAR_CANAL_DSCTO();
            CARGAR_INSTITUCIONES();
            //CARGAR_PTO_COBRANZA_CONSOLIDADO();
            //CARGAR_SECTORISTA();
            INICIAR_CABECERA_GRID_DETALLE();
            CARGAR_TIPO_PLANILLA();
            CARGAR_FORMATOS();
            LIMPIAR_CABECERA();
            //dtp_fecenv.Value = Convert.ToDateTime(DateTime.Now.Day + "/" + FECHA_INI.Month + "/" + FECHA_INI.Year);
            dtp_fecenv.Value = HelpersBLL.validaFecha(MES, AÑO, FECHA_GRAL);
        }

        private void ENVIO_I_PLANILLAS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void CARGAR_CANAL_DSCTO()
        {
            canalDescuentoBLL cdscBLL = new canalDescuentoBLL();
            DataTable dt = cdscBLL.ObtenerCanalDescuentoBLL();
            cbo_canaldscto.ValueMember = "COD_CANAL_DSCTO";
            cbo_canaldscto.DisplayMember = "DESCRIPCION";
            cbo_canaldscto.DataSource = dt;
            cbo_canaldscto.SelectedIndex = -1;
        }
        private void CARGAR_FORMATOS()
        {
            directorioBLL dirBLL = new directorioBLL();
            directorioTo dirTo = new directorioTo();
            dirTo.TABLA_COD = "TDEFO";
            DataTable dt = dirBLL.MOSTRAR_DIRECTORIO_DATO_BLL(dirTo);
            cbo_formato.ValueMember = "Codigo";
            cbo_formato.DisplayMember = "Descripción";
            cbo_formato.DataSource = dt;
            //cbo_formato.SelectedIndex = -1;
        }
        private void PLANILLAS_ENVIADAS()
        {
            plcTo.FE_AÑO = AÑO;
            plcTo.FE_MES = MES;
            plcTo.STATUS_ENVIO = "1";
            DataTable dt = plcBLL.obtener_Envio_I_Planilla_Cabecera_BLL(plcTo);
            if (dt.Rows.Count > 0)
            {
                dgw_enviados.Rows.Clear();
                foreach (DataRow rw in dt.Rows)
                {
                    int rowId = dgw_enviados.Rows.Add();
                    DataGridViewRow row = dgw_enviados.Rows[rowId];
                    row.Cells["NRO_PLANILLA_COB"].Value = rw["NRO_PLANILLA_COB"].ToString();
                    row.Cells["FECHA_ENVIO"].Value = rw["FECHA_ENVIO"].ToString().Substring(0, 10);
                    row.Cells["COD_INSTITUCION"].Value = rw["COD_INSTITUCION"].ToString();
                    row.Cells["DESC_INST"].Value = rw["DESC_INST"].ToString();
                    row.Cells["COD_PTO_COB_CONSOLIDADO"].Value = rw["COD_PTO_COB_CONSOLIDADO"].ToString();
                    row.Cells["DESC_PTO_COB"].Value = rw["DESC_PTO_COB"].ToString();
                    row.Cells["COD_CANAL_DSCTO"].Value = rw["COD_CANAL_DSCTO"].ToString();
                    row.Cells["DESCRIPCION"].Value = rw["DESCRIPCION"].ToString();
                    row.Cells["COD_SUCURSAL"].Value = rw["COD_SUCURSAL"].ToString();
                    row.Cells["COD_PTO_COB"].Value = rw["COD_PTO_COB"].ToString();
                    row.Cells["COD_SECTORISTA"].Value = rw["COD_SECTORISTA"].ToString();
                    row.Cells["DESC_EQVTA"].Value = rw["DESC_EQVTA"].ToString();
                    row.Cells["COD_COBRADOR"].Value = rw["COD_COBRADOR"].ToString();
                    row.Cells["COBR"].Value = rw["COBR"].ToString();
                    row.Cells["FECHA_PLANILLA_COB"].Value = rw["FECHA_PLANILLA_COB"].ToString();
                    row.Cells["FECHA_VEN_AL"].Value = rw["FECHA_VEN_AL"].ToString();
                    row.Cells["FECHA_APROBACION"].Value = rw["FECHA_APROBACION"].ToString();
                    row.Cells["OBSERVACION"].Value = rw["OBSERVACION"].ToString();
                    row.Cells["TIPO_PLANILLA"].Value = rw["TIPO_PLANILLA"].ToString();
                    row.Cells["COD_FORMATO"].Value = rw["COD_FORMATO"].ToString();
                    row.Cells["FE_AÑO"].Value = rw["FE_AÑO"].ToString();
                    row.Cells["FE_MES"].Value = rw["FE_MES"].ToString();
                    row.Cells["IMP_ENVIO"].Value = rw["IMP_ENVIO"].ToString();
                }
            }
        }
        private void PLANILLAS_ENVIADAS_ANTIGUO()
        {
            plcTo.FE_AÑO = AÑO;
            plcTo.FE_MES = MES;
            plcTo.STATUS_ENVIO = "1";
            DataTable dt = plcBLL.obtener_Envio_I_Planilla_Cabecera_BLL(plcTo);
            if (dt.Rows.Count > 0)
            {
                dgw_enviados.DataSource = dt;
                dgw_enviados.Columns["NRO_PLANILLA_COB"].HeaderText = "Nro Planilla";
                dgw_enviados.Columns["NRO_PLANILLA_COB"].Width = 80;
                dgw_enviados.Columns["FECHA_ENVIO"].HeaderText = "Fec Envio";
                dgw_enviados.Columns["FECHA_ENVIO"].Width = 70;
                dgw_enviados.Columns["FECHA_ENVIO"].DefaultCellStyle.Format = "d";
                dgw_enviados.Columns["COD_INSTITUCION"].Visible = false;
                dgw_enviados.Columns["DESC_INST"].HeaderText = "Institucion";
                dgw_enviados.Columns["DESC_INST"].Width = 170;
                dgw_enviados.Columns["COD_PTO_COB_CONSOLIDADO"].Visible = false;
                dgw_enviados.Columns["DESC_PTO_COB"].HeaderText = "Punto Cobranza Consolidado";
                dgw_enviados.Columns["DESC_PTO_COB"].Width = 210;
                dgw_enviados.Columns["COD_CANAL_DSCTO"].Visible = false;
                dgw_enviados.Columns["DESCRIPCION"].HeaderText = "Canal Descuento";
                dgw_enviados.Columns["DESCRIPCION"].Width = 170;
                dgw_enviados.Columns["COD_SUCURSAL"].Visible = false;
                dgw_enviados.Columns["COD_PTO_COB"].Visible = false;
                dgw_enviados.Columns["COD_SECTORISTA"].Visible = false;
                dgw_enviados.Columns["DESC_EQVTA"].HeaderText = "Sectorista";
                dgw_enviados.Columns["DESC_EQVTA"].Width = 190;
                dgw_enviados.Columns["COD_COBRADOR"].Visible = false;
                dgw_enviados.Columns["COBR"].Visible = false;
                dgw_enviados.Columns["FECHA_PLANILLA_COB"].Visible = false;
                dgw_enviados.Columns["FECHA_VEN_AL"].Visible = false;
                dgw_enviados.Columns["FECHA_APROBACION"].Visible = false;
                dgw_enviados.Columns["OBSERVACION"].Visible = false;
                dgw_enviados.Columns["TIPO_PLANILLA"].Visible = false;
                dgw_enviados.Columns["COD_FORMATO"].Visible = false;
                dgw_enviados.Columns["FE_AÑO"].Visible = false;
                dgw_enviados.Columns["FE_MES"].Visible = false;
                dgw_enviados.Columns["IMP_ENVIO"].HeaderText = "Imp Enviado";
                dgw_enviados.Columns["IMP_ENVIO"].Width = 80;
            }
        }
        private void PENDIENTES_X_ENVIAR()
        {
            plcTo.FE_AÑO = AÑO;
            plcTo.FE_MES = MES;
            plcTo.STATUS_ENVIO = "0";
            DataTable dt = plcBLL.obtener_Envio_I_Planilla_Cabecera_BLL(plcTo);
            if (dt.Rows.Count >= 0)
            {
                dgw1.Rows.Clear();
                foreach (DataRow rw in dt.Rows)
                {
                    int rowId = dgw1.Rows.Add();
                    DataGridViewRow row = dgw1.Rows[rowId];
                    row.Cells["NRO_PLANILLA_COB1"].Value = rw["NRO_PLANILLA_COB"].ToString();
                    //row.Cells["FECHA_ENVIO1"].Value = rw["FECHA_ENVIO"].ToString().Substring(0, 10);
                    row.Cells["COD_INSTITUCION1"].Value = rw["COD_INSTITUCION"].ToString();
                    row.Cells["DESC_INST1"].Value = rw["DESC_INST"].ToString();
                    row.Cells["COD_PTO_COB_CONSOLIDADO1"].Value = rw["COD_PTO_COB_CONSOLIDADO"].ToString();
                    row.Cells["DESC_PTO_COB1"].Value = rw["DESC_PTO_COB"].ToString();
                    row.Cells["COD_CANAL_DSCTO1"].Value = rw["COD_CANAL_DSCTO"].ToString();
                    row.Cells["DESCRIPCION1"].Value = rw["DESCRIPCION"].ToString();
                    row.Cells["COD_SUCURSAL1"].Value = rw["COD_SUCURSAL"].ToString();
                    row.Cells["COD_PTO_COB1"].Value = rw["COD_PTO_COB"].ToString();
                    row.Cells["COD_SECTORISTA1"].Value = rw["COD_SECTORISTA"].ToString();
                    row.Cells["DESC_EQVTA1"].Value = rw["DESC_EQVTA"].ToString();
                    row.Cells["COD_COBRADOR1"].Value = rw["COD_COBRADOR"].ToString();
                    row.Cells["COBR1"].Value = rw["COBR"].ToString();
                    row.Cells["FECHA_PLANILLA_COB1"].Value = rw["FECHA_PLANILLA_COB"].ToString();
                    row.Cells["FECHA_VEN_AL1"].Value = rw["FECHA_VEN_AL"].ToString();
                    row.Cells["FECHA_APROBACION1"].Value = rw["FECHA_APROBACION"].ToString();
                    row.Cells["OBSERVACION1"].Value = rw["OBSERVACION"].ToString();
                    row.Cells["TIPO_PLANILLA1"].Value = rw["TIPO_PLANILLA"].ToString();
                    row.Cells["COD_FORMATO1"].Value = rw["COD_FORMATO"].ToString();
                    row.Cells["FE_AÑO1"].Value = rw["FE_AÑO"].ToString();
                    row.Cells["FE_MES1"].Value = rw["FE_MES"].ToString();
                    row.Cells["IMP_ENVIO1"].Value = rw["IMP_ENVIO"].ToString();
                }
            }
        }
        private void PENDIENTES_X_ENVIAR_ANTIGUO()
        {
            plcTo.FE_AÑO = AÑO;
            plcTo.FE_MES = MES;
            plcTo.STATUS_ENVIO = "0";
            DataTable dt = plcBLL.obtener_Envio_I_Planilla_Cabecera_BLL(plcTo);
            if (dt.Rows.Count >= 0)
            {
                dgw1.DataSource = dt;
                dgw1.Columns["NRO_PLANILLA_COB"].HeaderText = "Nro Planilla";
                dgw1.Columns["NRO_PLANILLA_COB"].Width = 80;
                dgw1.Columns["COD_INSTITUCION"].Visible = false;
                dgw1.Columns["DESC_INST"].HeaderText = "Institucion";
                dgw1.Columns["DESC_INST"].Width = 170;
                dgw1.Columns["COD_PTO_COB_CONSOLIDADO"].Visible = false;
                dgw1.Columns["DESC_PTO_COB"].HeaderText = "Punto Cobranza Consolidado";
                dgw1.Columns["DESC_PTO_COB"].Width = 210;
                dgw1.Columns["COD_CANAL_DSCTO"].Visible = false;
                dgw1.Columns["DESCRIPCION"].HeaderText = "Canal Descuento";
                dgw1.Columns["DESCRIPCION"].Width = 170;
                dgw1.Columns["COD_SUCURSAL"].Visible = false;
                dgw1.Columns["COD_PTO_COB"].Visible = false;
                dgw1.Columns["COD_SECTORISTA"].Visible = false;
                dgw1.Columns["DESC_EQVTA"].HeaderText = "Sectorista";
                dgw1.Columns["DESC_EQVTA"].Width = 190;
                dgw1.Columns["FECHA_ENVIO"].Visible = false;
                dgw1.Columns["COD_COBRADOR"].Visible = false;
                dgw1.Columns["COBR"].Visible = false;
                dgw1.Columns["FECHA_PLANILLA_COB"].Visible = false;
                dgw1.Columns["FECHA_VEN_AL"].Visible = false;
                dgw1.Columns["FECHA_APROBACION"].Visible = false;
                dgw1.Columns["OBSERVACION"].Visible = false;
                dgw1.Columns["TIPO_PLANILLA"].Visible = false;
                dgw1.Columns["COD_FORMATO"].Visible = false;
                dgw1.Columns["FE_AÑO"].Visible = false;
                dgw1.Columns["FE_MES"].Visible = false;
            }

        }
        private void CARGAR_SUCURSAL()
        {
            HelpersBLL helBLL = new HelpersBLL();
            HelpersTo helTo = new HelpersTo();
            helTo.CODIGO = COD_USU;
            DataTable dt = helBLL.CBO_SUCURSALBLL(helTo);
            cbo_sucursal.ValueMember = "COD_SUCURSAL";
            cbo_sucursal.DisplayMember = "DESC_sucursal";
            cbo_sucursal.DataSource = dt;
            cbo_sucursal.SelectedIndex = -1;
        }
        private void CARGAR_INSTITUCIONES()
        {
            institucionesBLL insBLL = new institucionesBLL();
            DataTable dtInst = insBLL.obtenerInstitucionesBLL();
            cbo_institucion.ValueMember = "COD_INST";
            cbo_institucion.DisplayMember = "DESC_INST";
            cbo_institucion.DataSource = dtInst;
        }
        private void CARGAR_PTO_COBRANZA_CONSOLIDADO()
        {
            puntoCobranzaBLL ptoBLL = new puntoCobranzaBLL();
            puntoCobranzaTo ptoTo = new puntoCobranzaTo();
            ptoTo.STATUS_CONSOLIDADO = true;
            ptoTo.COD_INSTITUCION = cbo_institucion.SelectedValue.ToString();
            DataTable dt = ptoBLL.obtenerPuntosCobranzaBLL(ptoTo);
            cbo_ptoCobranza.ValueMember = "COD_PTO_COB";
            cbo_ptoCobranza.DisplayMember = "DESC_PTO_COB";
            cbo_ptoCobranza.DataSource = dt;
            cbo_ptoCobranza.SelectedIndex = -1;
        }
        private void INICIAR_CABECERA_GRID_DETALLE()
        {
            DGW_DET.Columns["NRO_CONTRATO_Det"].HeaderText = "Contrato";
            DGW_DET.Columns["NRO_CONTRATO_Det"].Width = 60;
            DGW_DET.Columns["NRO_CONTRATO_Det"].ReadOnly = true;
            DGW_DET.Columns["COD_PER_Det"].HeaderText = "Codigo";
            DGW_DET.Columns["COD_PER_Det"].Width = 55;
            DGW_DET.Columns["COD_PER_Det"].ReadOnly = true;
            DGW_DET.Columns["DES_IDENTIDAD_Det"].HeaderText = "Cod Modular";
            DGW_DET.Columns["DES_IDENTIDAD_Det"].Width = 80;
            DGW_DET.Columns["DES_IDENTIDAD_Det"].ReadOnly = true;
            DGW_DET.Columns["DES_PROCESO_Det"].HeaderText = "Cod Pago";
            DGW_DET.Columns["DES_PROCESO_Det"].Width = 80;
            DGW_DET.Columns["DES_PROCESO_Det"].ReadOnly = true;
            DGW_DET.Columns["DESC_PER_Det"].HeaderText = "Nombre Cliente";
            DGW_DET.Columns["DESC_PER_Det"].Width = 240;
            DGW_DET.Columns["DESC_PER_Det"].ReadOnly = true;
            DGW_DET.Columns["DNI_Det"].HeaderText = "DNI/Ruc";
            DGW_DET.Columns["DNI_Det"].Width = 90;
            DGW_DET.Columns["DNI_Det"].ReadOnly = true;
            DGW_DET.Columns["COD_DOC_Det"].Visible = false;
            DGW_DET.Columns["NRO_DOC_Det"].HeaderText = "N° Doc";
            DGW_DET.Columns["NRO_DOC_Det"].Width = 60;
            DGW_DET.Columns["NRO_DOC_Det"].ReadOnly = true;
            DGW_DET.Columns["FECHA_VEN_Det"].HeaderText = "Fec Ven";
            DGW_DET.Columns["FECHA_VEN_Det"].Width = 70;
            DGW_DET.Columns["FECHA_VEN_Det"].ReadOnly = true;
            DGW_DET.Columns["FECHA_VEN_Det"].DefaultCellStyle.Format = "{0:dd/MM/yyyy}";
            DGW_DET.Columns["IMP_INI_Det"].HeaderText = "Imp Cuota";
            DGW_DET.Columns["IMP_INI_Det"].Width = 65;
            DGW_DET.Columns["IMP_INI_Det"].ReadOnly = true;
            DGW_DET.Columns["IMP_INI_Det"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DGW_DET.Columns["SAL_IMP_Det"].HeaderText = "ImpxEnviar";
            DGW_DET.Columns["SAL_IMP_Det"].Width = 65;
            DGW_DET.Columns["SAL_IMP_Det"].ReadOnly = false;
            DGW_DET.Columns["SAL_IMP_Det"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DGW_DET.Columns["NRO_LETRA_Det"].HeaderText = "Letra";
            DGW_DET.Columns["NRO_LETRA_Det"].Width = 55;
            DGW_DET.Columns["NRO_LETRA_Det"].ReadOnly = true;
            DGW_DET.Columns["TOT_LETRA_Det"].HeaderText = "Tot Let";
            DGW_DET.Columns["TOT_LETRA_Det"].Width = 55;
            DGW_DET.Columns["TOT_LETRA_Det"].ReadOnly = true;
            DGW_DET.Columns["OBSERVACION_Det"].HeaderText = "Observaciones";
            DGW_DET.Columns["OBSERVACION_Det"].Width = 110;
            DGW_DET.Columns["OBSERVACION_Det"].ReadOnly = false;
            DGW_DET.Columns["COD_PTO_COB_Det"].Visible = false;
            DGW_DET.Columns["COD_CANAL_DSCTO_Det"].Visible = false;
            DGW_DET.Columns["PATERNO_Det"].Visible = false;
            DGW_DET.Columns["MATERNO_Det"].Visible = false;
            DGW_DET.Columns["NOMBRE_Det"].Visible = false;
            DGW_DET.Columns["COD_CARGO_Det"].Visible = false;
            DGW_DET.Columns["FECHA_ENVIO_Det"].Visible = false;
            DGW_DET.Columns["FECHA_PRE_Det"].Visible = false;
            //DGW_DET.Columns["DES_PROCESO_Det"].Visible = false;
            DGW_DET.Columns["COD_ZONA_Det"].Visible = false;
            DGW_DET.Columns["DESC_PTO_VEN"].Visible = false;
        }
        private void CARGAR_TIPO_PLANILLA()
        {
            //var planilla = new[] {  new { val = "DESCUENTO", cod = "P" },
            //                        new { val = "DIRECTA", cod = "D" },
            //                        new { val = "DESCUENTO/DIRECTA", cod = "PD" }};

            //cbo_tipo_planilla.ValueMember = "cod";
            //cbo_tipo_planilla.DisplayMember = "val";
            //cbo_tipo_planilla.DataSource = planilla;
            //cbo_tipo_planilla.SelectedIndex = -1;

            tipoPlanillaCreacionBLL tpllaBLL = new tipoPlanillaCreacionBLL();
            tipoPlanillaCreacionTo tpllaTo = new tipoPlanillaCreacionTo();
            tpllaTo.STATUS_GENERACION = "1";
            tpllaTo.COD_VENTA = "VTA";
            DataTable dtTipoPlla = tpllaBLL.obtenerTipoPlanillaCreacionxStGeneracionBLL(tpllaTo);
            if (dtTipoPlla.Rows.Count > 0)
            {
                cbo_tipo_planilla.ValueMember = "COD_TIPO_PLLA";
                cbo_tipo_planilla.DisplayMember = "DESC_TIPO";
                cbo_tipo_planilla.DataSource = dtTipoPlla;
                cbo_tipo_planilla.SelectedIndex = 0;
            }
        }
        private void btn_salir_Click(object sender, EventArgs e)
        {
            TabControl1.SelectedTab = TabPage3;
        }

        private void btn_consulta_Click(object sender, EventArgs e)
        {
            if (dgw1.Rows.Count > 0)
            {
                LIMPIAR_CABECERA();
                DGW_DET.Rows.Clear();
                CARGAR_CABECERA_PEND(dgw1);
                CARGAR_DETALLE_PEND(dgw1);
                TabControl1.SelectedTab = TabPage2;
            }
        }
        private void LIMPIAR_CABECERA()
        {
            cbo_sucursal.SelectedIndex = -1;
            cbo_institucion.SelectedIndex = -1;
            cbo_ptoCobranza.SelectedIndex = -1;
            cbo_sectorista.SelectedIndex = -1;
            cbo_canaldscto.SelectedIndex = -1;
            txt_ser.Clear();
            txt_num.Clear();
            txt_obs.Clear();
            cbo_pto_cob.DataSource = null;
            cbo_tipo_planilla.SelectedIndex = -1;
            cbo_cobrador.SelectedIndex = -1;

        }
        private void CARGAR_CABECERA_PEND(DataGridView dg)
        {
            int idx = dg.CurrentRow.Index;
            cbo_sucursal.SelectedValue = dg.Rows[idx].Cells["COD_SUCURSAL1"].Value;
            cbo_institucion.SelectedValue = dg.Rows[idx].Cells["COD_INSTITUCION1"].Value;
            cbo_ptoCobranza.SelectedValue = dg.Rows[idx].Cells["COD_PTO_COB_CONSOLIDADO1"].Value;
            cbo_formato.SelectedValue = dg.Rows[idx].Cells["COD_FORMATO1"].Value;
            cbo_canaldscto.SelectedValue = dg.Rows[idx].Cells["COD_CANAL_DSCTO1"].Value;
            if (dg.Rows[idx].Cells["COD_PTO_COB1"].Value.ToString() != "")
            {
                //CH_PV.Checked = true;
                llena_Pto_Cobranza_X_PtoCobConsolidado();
                cbo_pto_cob.SelectedValue = dg.Rows[idx].Cells["COD_PTO_COB1"].Value;
            }
            else
            {
                cbo_pto_cob.DataSource = null;
                //CH_PV.Checked = false;
            }
            cbo_sectorista.SelectedValue = dg.Rows[idx].Cells["COD_SECTORISTA1"].Value;
            txt_obs.Text = dg.Rows[idx].Cells["OBSERVACION1"].Value.ToString();
            txt_ser.Text = dg.Rows[idx].Cells["NRO_PLANILLA_COB1"].Value.ToString().Substring(0, 3);
            txt_num.Text = dg.Rows[idx].Cells["NRO_PLANILLA_COB1"].Value.ToString().Substring(4, 7);
            dtp_generacion.Value = Convert.ToDateTime(dg.Rows[idx].Cells["FECHA_PLANILLA_COB1"].Value);
            dtp_fecven.Value = Convert.ToDateTime(dg.Rows[idx].Cells["FECHA_VEN_AL1"].Value);
            cbo_tipo_planilla.SelectedValue = dg.Rows[idx].Cells["TIPO_PLANILLA1"].Value.ToString().Trim();
            if (dg.Rows[idx].Cells["COD_COBRADOR1"].Value.ToString() != "")
            {
                llena_Cobradores();
                cbo_cobrador.SelectedValue = dg.Rows[idx].Cells["COD_COBRADOR1"].Value;
            }
        }
        private void CARGAR_CABECERA_ENVIADA(DataGridView dg)
        {
            int idx = dg.CurrentRow.Index;
            cbo_sucursal.SelectedValue = dg.Rows[idx].Cells["COD_SUCURSAL"].Value;
            cbo_institucion.SelectedValue = dg.Rows[idx].Cells["COD_INSTITUCION"].Value;
            cbo_ptoCobranza.SelectedValue = dg.Rows[idx].Cells["COD_PTO_COB_CONSOLIDADO"].Value;
            cbo_formato.SelectedValue = dg.Rows[idx].Cells["COD_FORMATO"].Value;
            cbo_canaldscto.SelectedValue = dg.Rows[idx].Cells["COD_CANAL_DSCTO"].Value;
            if (dg.Rows[idx].Cells["COD_PTO_COB"].Value.ToString() != "")
            {
                //CH_PV.Checked = true;
                llena_Pto_Cobranza_X_PtoCobConsolidado();
                cbo_pto_cob.SelectedValue = dg.Rows[idx].Cells["COD_PTO_COB"].Value;
            }
            else
            {
                cbo_pto_cob.DataSource = null;
                //CH_PV.Checked = false;
            }
            cbo_sectorista.SelectedValue = dg.Rows[idx].Cells["COD_SECTORISTA"].Value;
            txt_obs.Text = dg.Rows[idx].Cells["OBSERVACION"].Value.ToString();
            txt_ser.Text = dg.Rows[idx].Cells["NRO_PLANILLA_COB"].Value.ToString().Substring(0, 3);
            txt_num.Text = dg.Rows[idx].Cells["NRO_PLANILLA_COB"].Value.ToString().Substring(4, 7);
            dtp_generacion.Value = Convert.ToDateTime(dg.Rows[idx].Cells["FECHA_PLANILLA_COB"].Value);
            dtp_fecven.Value = Convert.ToDateTime(dg.Rows[idx].Cells["FECHA_VEN_AL"].Value);
            cbo_tipo_planilla.SelectedValue = dg.Rows[idx].Cells["TIPO_PLANILLA"].Value.ToString().Trim();
            if (dg.Rows[idx].Cells["COD_COBRADOR"].Value.ToString() != "")
            {
                llena_Cobradores();
                cbo_cobrador.SelectedValue = dg.Rows[idx].Cells["COD_COBRADOR"].Value;
            }
        }
        private void llena_Pto_Cobranza_X_PtoCobConsolidado()
        {
            puntoCobranzaBLL ptoBLL = new puntoCobranzaBLL();
            puntoCobranzaTo ptoTo = new puntoCobranzaTo();
            ptoTo.COD_PTO_COB = cbo_ptoCobranza.SelectedValue.ToString();
            DataTable dt = ptoBLL.obtenerPtoCobranzaxPtoCobConsolidadoBLL(ptoTo);
            cbo_pto_cob.ValueMember = "COD_PTO_COB";
            cbo_pto_cob.DisplayMember = "DESC_PTO_COB";
            cbo_pto_cob.DataSource = dt;
        }
        private void llena_Cobradores()
        {
            progNivelBLL prnBLL = new progNivelBLL();
            progNivelTo prnTo = new progNivelTo();
            prnTo.COD_PER = cbo_sectorista.SelectedValue.ToString();
            prnTo.COD_NIVEL = "02";//02 cobrador, 03 gestor
            DataTable dt = prnBLL.obtenerCobradoresxSectoristaBLL(prnTo);
            cbo_cobrador.ValueMember = "COD_EQCOB";
            cbo_cobrador.DisplayMember = "DESC_EQVTA";
            cbo_cobrador.DataSource = dt;
            cbo_cobrador.SelectedIndex = -1;
        }
        private void CARGAR_DETALLE_PEND(DataGridView dg)
        {
            planillaDetalleBLL pldBLL = new planillaDetalleBLL();
            planillaDetalleTo pldTo = new planillaDetalleTo();
            int idx = dg.CurrentRow.Index;
            pldTo.NRO_PLANILLA_COB = dg.Rows[idx].Cells["NRO_PLANILLA_COB1"].Value.ToString();
            pldTo.COD_INSTITUCION = dg.Rows[idx].Cells["COD_INSTITUCION1"].Value.ToString();
            pldTo.COD_PTO_COB_CONSOLIDADO = dg.Rows[idx].Cells["COD_PTO_COB_CONSOLIDADO1"].Value.ToString();
            pldTo.COD_CANAL_DSCTO = dg.Rows[idx].Cells["COD_CANAL_DSCTO1"].Value.ToString();
            pldTo.FE_AÑO = AÑO;
            pldTo.FE_MES = MES;
            DataTable dt = pldBLL.obtener_I_Planilla_Detalle_Envio_BLL(pldTo);
            if (dt.Rows.Count > 0)
            {
                DGW_DET.Rows.Clear();
                foreach (DataRow rw in dt.Rows)
                {
                    int rowId = DGW_DET.Rows.Add();
                    DataGridViewRow row = DGW_DET.Rows[rowId];
                    row.Cells["NRO_CONTRATO_Det"].Value = rw["NRO_CONTRATO"].ToString();
                    row.Cells["COD_PER_Det"].Value = rw["COD_PER"].ToString();
                    row.Cells["DES_IDENTIDAD_Det"].Value = rw["DES_IDENTIDAD"].ToString().Trim();
                    row.Cells["DES_PROCESO_Det"].Value = rw["DES_PROCESO"].ToString().Trim();
                    row.Cells["DESC_PER_Det"].Value = rw["DESC_PER"].ToString();
                    row.Cells["DNI_Det"].Value = rw["DNI"].ToString();
                    row.Cells["COD_DOC_Det"].Value = rw["COD_DOC"].ToString();
                    row.Cells["NRO_DOC_Det"].Value = rw["NRO_DOC"].ToString().Trim();
                    row.Cells["FECHA_VEN_Det"].Value = string.Format("{0:dd/MM/yyyy}", rw["FECHA_VEN"]);//rw["FECHA_VEN"].ToString().Substring(0, 10);
                    row.Cells["IMP_INI_Det"].Value = rw["IMP_INI"].ToString();
                    row.Cells["SAL_IMP_Det"].Value = rw["SAL_IMP"].ToString();
                    row.Cells["NRO_LETRA_Det"].Value = rw["NRO_LETRA"].ToString();
                    row.Cells["TOT_LETRA_Det"].Value = rw["TOT_LETRA"].ToString();
                    row.Cells["OBSERVACION_Det"].Value = rw["OBSERVACION"].ToString();
                    row.Cells["COD_PTO_COB_Det"].Value = rw["COD_PTO_COB"].ToString();
                    row.Cells["COD_CANAL_DSCTO_Det"].Value = rw["COD_CANAL_DSCTO"].ToString();
                    row.Cells["PATERNO_Det"].Value = rw["PATERNO"].ToString();
                    row.Cells["MATERNO_Det"].Value = rw["MATERNO"].ToString();
                    row.Cells["NOMBRE_Det"].Value = rw["NOMBRE"].ToString();
                    row.Cells["COD_CARGO_Det"].Value = rw["COD_CARGO"].ToString();
                    row.Cells["FECHA_ENVIO_Det"].Value = rw["FECHA_ENVIO"].ToString() == "" ? "" : string.Format("{0:dd/MM/yyyy}", rw["FECHA_ENVIO"]);//rw["FECHA_ENVIO"].ToString().Substring(0, 10);
                    row.Cells["FECHA_PRE_Det"].Value = string.Format("{0:dd/MM/yyyy}", rw["FECHA_PRE"]);//rw["FECHA_PRE"].ToString().Substring(0, 10);
                    row.Cells["FECHA_PRIMER_VENC_Det"].Value = rw["FEC_PRIMER_VENC"].ToString().Substring(6, 4) + rw["FEC_PRIMER_VENC"].ToString().Substring(3, 2) + rw["FEC_PRIMER_VENC"].ToString().Substring(0, 2);
                    row.Cells["TOTAL_CONTRATO_Det"].Value = rw["TOTAL_CONTRATO"].ToString();
                    row.Cells["COD_ZONA_Det"].Value = rw["COD_ZONA"].ToString();
                    row.Cells["DESC_PTO_VEN"].Value = rw["DESC_PTO_VEN"].ToString();
                }
            }
            HALLAR_TOTALES();
            HALLAR_NRO_CONTRATOS();
        }
        private void CARGAR_DETALLE_ENVIADA(DataGridView dg)
        {
            planillaDetalleBLL pldBLL = new planillaDetalleBLL();
            planillaDetalleTo pldTo = new planillaDetalleTo();
            int idx = dg.CurrentRow.Index;
            pldTo.NRO_PLANILLA_COB = dg.Rows[idx].Cells["NRO_PLANILLA_COB"].Value.ToString();
            pldTo.COD_INSTITUCION = dg.Rows[idx].Cells["COD_INSTITUCION"].Value.ToString();
            pldTo.COD_PTO_COB_CONSOLIDADO = dg.Rows[idx].Cells["COD_PTO_COB_CONSOLIDADO"].Value.ToString();
            pldTo.COD_CANAL_DSCTO = dg.Rows[idx].Cells["COD_CANAL_DSCTO"].Value.ToString();
            pldTo.FE_AÑO = AÑO;
            pldTo.FE_MES = MES;
            DataTable dt = pldBLL.obtener_I_Planilla_Detalle_Envio_BLL(pldTo);
            if (dt.Rows.Count > 0)
            {
                DGW_DET.Rows.Clear();
                foreach (DataRow rw in dt.Rows)
                {
                    int rowId = DGW_DET.Rows.Add();
                    DataGridViewRow row = DGW_DET.Rows[rowId];
                    row.Cells["NRO_CONTRATO_Det"].Value = rw["NRO_CONTRATO"].ToString();
                    row.Cells["COD_PER_Det"].Value = rw["COD_PER"].ToString();
                    row.Cells["DES_IDENTIDAD_Det"].Value = rw["DES_IDENTIDAD"].ToString().Trim();
                    row.Cells["DES_PROCESO_Det"].Value = rw["DES_PROCESO"].ToString().Trim();
                    row.Cells["DESC_PER_Det"].Value = rw["DESC_PER"].ToString();
                    row.Cells["DNI_Det"].Value = rw["DNI"].ToString();
                    row.Cells["COD_DOC_Det"].Value = rw["COD_DOC"].ToString();
                    row.Cells["NRO_DOC_Det"].Value = rw["NRO_DOC"].ToString().Trim();
                    row.Cells["FECHA_VEN_Det"].Value = string.Format("{0:dd/MM/yyyy}", rw["FECHA_VEN"]);//rw["FECHA_VEN"].ToString().Substring(0, 10);
                    row.Cells["IMP_INI_Det"].Value = rw["IMP_INI"].ToString();
                    row.Cells["SAL_IMP_Det"].Value = rw["SAL_IMP"].ToString();
                    row.Cells["NRO_LETRA_Det"].Value = rw["NRO_LETRA"].ToString();
                    row.Cells["TOT_LETRA_Det"].Value = rw["TOT_LETRA"].ToString();
                    row.Cells["OBSERVACION_Det"].Value = rw["OBSERVACION"].ToString();
                    row.Cells["COD_PTO_COB_Det"].Value = rw["COD_PTO_COB"].ToString();
                    row.Cells["COD_CANAL_DSCTO_Det"].Value = rw["COD_CANAL_DSCTO"].ToString();
                    row.Cells["PATERNO_Det"].Value = rw["PATERNO"].ToString();
                    row.Cells["MATERNO_Det"].Value = rw["MATERNO"].ToString();
                    row.Cells["NOMBRE_Det"].Value = rw["NOMBRE"].ToString();
                    row.Cells["COD_CARGO_Det"].Value = rw["COD_CARGO"].ToString();
                    row.Cells["FECHA_ENVIO_Det"].Value = rw["FECHA_ENVIO"].ToString() == "" ? "" : string.Format("{0:dd/MM/yyyy}", rw["FECHA_ENVIO"]);//rw["FECHA_ENVIO"].ToString().Substring(0, 10);
                    row.Cells["FECHA_PRE_Det"].Value = string.Format("{0:dd/MM/yyyy}", rw["FECHA_PRE"]);//rw["FECHA_PRE"].ToString().Substring(0, 10);
                    row.Cells["FECHA_PRIMER_VENC_Det"].Value = rw["FEC_PRIMER_VENC"].ToString().Substring(6, 4) + rw["FEC_PRIMER_VENC"].ToString().Substring(3, 2) + rw["FEC_PRIMER_VENC"].ToString().Substring(0, 2);
                    row.Cells["TOTAL_CONTRATO_Det"].Value = rw["TOTAL_CONTRATO"].ToString();
                    row.Cells["COD_ZONA_Det"].Value = rw["COD_ZONA"].ToString();
                    row.Cells["DESC_PTO_VEN"].Value = rw["DESC_PTO_VEN"].ToString();
                }
            }
            HALLAR_TOTALES();
            HALLAR_NRO_CONTRATOS();
        }
        private void HALLAR_TOTALES()
        {
            int num = DGW_DET.Rows.Count - 1;
            decimal sum = 0;
            int i = 0;
            while (i <= num)
            {
                sum = decimal.Add(sum, Convert.ToDecimal(DGW_DET.Rows[i].Cells["SAL_IMP_Det"].Value));//posicion 9
                i++;
            }
            txt_totimp.Text = sum.ToString();
            txt_totimp.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(txt_totimp.Text);
            txt_ctas.Text = DGW_DET.Rows.Count.ToString();
        }

        private void cbo_sectorista_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_sectorista.SelectedValue != null)
            {
                llena_Sectorista();
            }
        }
        private void llena_Sectorista()
        {
            puntoCobranzaBLL ptoBLL = new puntoCobranzaBLL();
            puntoCobranzaTo ptoTo = new puntoCobranzaTo();
            ptoTo.COD_PTO_COB = cbo_ptoCobranza.SelectedValue.ToString();
            DataTable dt = ptoBLL.obtenerSectoristaPuntosCobranzaBLL(ptoTo);
            cbo_sectorista.SelectedValue = dt.Rows[0]["COD_SECTORISTA"];
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
            sdoTo.COD_DOC = "43";//planilla de cobranza
            //txt_nro_ini.Text = sdoBLL.obtenerNro_Ing2BLL(sdoTo);
            txt_ser.Text = sdoBLL.OBTENER_SERIE_NRO_BLL(sdoTo).Rows[0]["SERIE"].ToString();
            txt_num.Text = sdoBLL.OBTENER_SERIE_NRO_BLL(sdoTo).Rows[0]["NUMERO"].ToString();
        }

        private void cbo_ptoCobranza_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_ptoCobranza.SelectedValue != null)
            {
                CARGAR_SECTORISTA();
                llena_Sectorista();
                llena_Cobradores();
            }
        }
        private void CARGAR_SECTORISTA()
        {
            progNivelBLL prnBLL = new progNivelBLL();
            DataTable dtEqc = prnBLL.obtenerSectoristasparaCrearEqCobradoresBLL("01");//02 Cobradores
            cbo_sectorista.ValueMember = "COD_EQCOB";
            cbo_sectorista.DisplayMember = "DESC_EQVTA";
            cbo_sectorista.DataSource = dtEqc;
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            TabControl1.SelectedTab = TabPage3;
        }
        private void HALLAR_NRO_CONTRATOS()
        {
            int n = 1; int j = 0;
            for (int i = 0; i < DGW_DET.Rows.Count - 1; i++)
            {
                if (i == DGW_DET.Rows.Count - 1)
                    break;
                for (j = i; j < DGW_DET.Rows.Count - 1; j++)
                {
                    if (DGW_DET[0, j].Value.ToString() != DGW_DET[0, j + 1].Value.ToString())
                    {
                        n++;
                        i = j;
                        break;
                    }
                }
            }
            txt_ctas.Text = n.ToString();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("¿ Esta seguro de Enviar la Planilla ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                FolderBrowserDialog ofbd = new FolderBrowserDialog();
                if (ofbd.ShowDialog() == DialogResult.OK)
                {
                    string errMensaje = "";
                    plcTo.NRO_PLANILLA_COB = txt_ser.Text + "-" + txt_num.Text;
                    plcTo.COD_INSTITUCION = cbo_institucion.SelectedValue.ToString();
                    plcTo.COD_PTO_COB_CONSOLIDADO = cbo_ptoCobranza.SelectedValue.ToString();
                    //plcTo.COD_PTO_COB = cbo_tipo_planilla.SelectedValue.ToString() == "P" ? "" : cbo_pto_cob.SelectedValue.ToString();
                    plcTo.COD_PTO_COB = cbo_ptoCobranza.SelectedValue.ToString();
                    plcTo.DESC_PTO_COB = cbo_ptoCobranza.Text;
                    plcTo.COD_CANAL_DSCTO = cbo_canaldscto.SelectedValue.ToString();
                    plcTo.FE_AÑO = AÑO;//dtp_generacion.Value.ToShortDateString().Substring(6, 4);
                    plcTo.FE_MES = MES;//dtp_generacion.Value.ToShortDateString().Substring(3, 2);
                    plcTo.NOMBRE_MES = HelpersBLL.OBTENER_NOM_MES(MES);
                    plcTo.FECHA_ENVIO = dtp_fecenv.Value;
                    plcTo.TIPO_PLANILLA = cbo_tipo_planilla.SelectedValue.ToString();
                    plcTo.COD_MOD = COD_USU;
                    plcTo.FECHA_MOD = DateTime.Now;
                    plcTo.IMP_ENVIO = Convert.ToDecimal(txt_totimp.Text);
                    DataTable dtDetalle = obtenerDT();
                    DataTable dtDetalleConsolidado = obtenerDTConsolidado(dtDetalle);
                    if (!plcBLL.generaActualizaPlanillaBLL(plcTo, ofbd.SelectedPath, dtDetalle, dtDetalleConsolidado, ref errMensaje))
                        MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        MessageBox.Show("La planilla se envió correctamente !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TabControl1.SelectedTab = TabPage1;
                        PLANILLAS_ENVIADAS();
                        PENDIENTES_X_ENVIAR();
                        FOCO_NUEVO_REG();
                    }
                }
            }
        }
        private DataTable obtenerDTConsolidado(DataTable dt)
        {
            DataTable table = dt.Clone();
            decimal imp = 0; int j = 0; decimal imp2 = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (i == dt.Rows.Count - 1)
                {
                    table.ImportRow(dt.Rows[i]);
                    break;
                }
                if (dt.Rows[i]["NRO_CONTRATO_Det"].ToString() == dt.Rows[i + 1]["NRO_CONTRATO_Det"].ToString())
                {
                    j = 1;
                    imp2 = Convert.ToDecimal(dt.Rows[i]["IMP_INI_Det"]);
                    imp = Convert.ToDecimal(dt.Rows[i]["SAL_IMP_Det"]);
                    while (dt.Rows[i]["NRO_CONTRATO_Det"].ToString() == dt.Rows[i + j]["NRO_CONTRATO_Det"].ToString())
                    {
                        imp2 += Convert.ToDecimal(dt.Rows[i]["IMP_INI_Det"]);
                        imp += Convert.ToDecimal(dt.Rows[i + j]["SAL_IMP_Det"]);
                        j++;
                        if (i + j == dt.Rows.Count)
                            break;
                    }
                    DataRow rw = table.NewRow();
                    rw["NRO_CONTRATO_Det"] = dt.Rows[i]["NRO_CONTRATO_Det"].ToString();
                    rw["COD_PER_Det"] = dt.Rows[i]["COD_PER_Det"].ToString();
                    rw["DES_IDENTIDAD_Det"] = dt.Rows[i]["DES_IDENTIDAD_Det"].ToString();
                    rw["DES_PROCESO_Det"] = dt.Rows[i]["DES_PROCESO_Det"].ToString();
                    rw["DESC_PER_Det"] = dt.Rows[i]["DESC_PER_Det"].ToString();
                    rw["DNI_Det"] = dt.Rows[i]["DNI_Det"].ToString();
                    rw["COD_DOC_Det"] = dt.Rows[i]["COD_DOC_Det"].ToString();
                    rw["NRO_DOC_Det"] = dt.Rows[i]["NRO_DOC_Det"].ToString();
                    rw["FECHA_VEN_Det"] = dt.Rows[i]["FECHA_VEN_Det"].ToString();
                    rw["IMP_INI_Det"] = imp2;
                    rw["SAL_IMP_Det"] = imp;
                    rw["NRO_LETRA_Det"] = dt.Rows[i]["NRO_LETRA_Det"].ToString();
                    rw["TOT_LETRA_Det"] = dt.Rows[i]["TOT_LETRA_Det"].ToString();
                    rw["OBSERVACION_Det"] = dt.Rows[i]["OBSERVACION_Det"].ToString();
                    rw["COD_PTO_COB_Det"] = dt.Rows[i]["COD_PTO_COB_Det"].ToString();
                    rw["COD_CANAL_DSCTO_Det"] = dt.Rows[i]["COD_CANAL_DSCTO_Det"].ToString();
                    rw["PATERNO_Det"] = dt.Rows[i]["PATERNO_Det"].ToString();
                    rw["MATERNO_Det"] = dt.Rows[i]["MATERNO_Det"].ToString();
                    rw["NOMBRE_Det"] = dt.Rows[i]["NOMBRE_Det"].ToString();
                    rw["COD_CARGO_Det"] = dt.Rows[i]["COD_CARGO_Det"].ToString();
                    rw["FECHA_ENVIO_Det"] = dt.Rows[i]["FECHA_ENVIO_Det"].ToString();
                    rw["FECHA_PRE_Det"] = dt.Rows[i]["FECHA_PRE_Det"].ToString();
                    rw["FECHA_PRIMER_VENC_Det"] = dt.Rows[i]["FECHA_PRIMER_VENC_Det"].ToString();
                    rw["TOTAL_CONTRATO_Det"] = dt.Rows[i]["TOTAL_CONTRATO_Det"].ToString();
                    rw["COD_ZONA_Det"] = dt.Rows[i]["COD_ZONA_Det"].ToString();
                    rw["DESC_PTO_VEN"] = dt.Rows[i]["DESC_PTO_VEN"].ToString();

                    table.Rows.Add(rw);
                    i = i + j - 1;
                }
                else
                {
                    table.ImportRow(dt.Rows[i]);
                }
            }
            return table;
        }
        private void FOCO_NUEVO_REG()
        {
            int i, cont = 0;
            cont = dgw_enviados.Columns.Count - 1;
            string nrocon = txt_ser.Text + "-" + txt_num.Text.Trim();
            for (i = 0; i <= cont; i++)
            {
                if (nrocon == dgw_enviados.Rows[i].Cells["NRO_PLANILLA_COB"].Value.ToString().ToLower())
                {
                    dgw_enviados.CurrentCell = dgw_enviados.Rows[i].Cells["NRO_PLANILLA_COB"];
                    return;
                }
            }
        }
        private DataTable obtenerDT()
        {
            DataTable table = new DataTable();
            foreach (DataGridViewColumn column in DGW_DET.Columns)
            {
                table.Columns.Add(column.Name, typeof(string));
            }
            foreach (DataGridViewRow row in DGW_DET.Rows)
            {
                DataRow dataRow = table.NewRow();
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    dataRow[i] = row.Cells[i].Value != null ? row.Cells[i].Value : DBNull.Value;
                }
                table.Rows.Add(dataRow);
            }
            return table;
        }

        private void btn_retornar_Click(object sender, EventArgs e)
        {
            if (!validaRetorno("pendiente", dgw1))
                return;
            DialogResult rs = MessageBox.Show("¿ Esta seguro de Retornar la Planilla ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                retornaGeneracionPlanillas(dgw1);
                TabControl1.SelectedTab = TabPage1;
            }
        }
        private void retornaGeneracionPlanillas(DataGridView dg)
        {
            personaBLL perBLL = new personaBLL();
            //DESAPROBADO_POR fdp = new DESAPROBADO_POR();
            DIALOGOS.DESAPROBADO_POR fdp = new DIALOGOS.DESAPROBADO_POR();
            fdp.cboUsuario.Items.Clear();
            fdp.cargar_usuario("VTA");
            if (fdp.ShowDialog() == DialogResult.OK)
            {
                string pass = fdp.txtContraseña.Text;
                string claveEncriptada = HelpersBLL.ENCRIPTAR(pass.ToUpper());
                //string codigo = perBLL.ValidarUsuarioEliminacionAnulacionBLL(claveEncriptada, fdp.cboUsuario.Text);
                string codigo = "XXXX"; perBLL.ValidarUsuarioEliminacionAnulacionBLL(pass, fdp.cboUsuario.Text);
                int RSLT = perBLL.ValidarDirectorioDesaprobarBLL(codigo, "VTA");
                if (RSLT > 0)
                {
                    string errMensaje = "";
                    int idx = dg.CurrentRow.Index;
                    plcTo.NRO_PLANILLA_COB = dg.Rows[idx].Cells["NRO_PLANILLA_COB1"].Value.ToString();
                    plcTo.COD_INSTITUCION = dg.Rows[idx].Cells["COD_INSTITUCION1"].Value.ToString();
                    plcTo.COD_PTO_COB_CONSOLIDADO = dg.Rows[idx].Cells["COD_PTO_COB_CONSOLIDADO1"].Value.ToString();
                    plcTo.COD_CANAL_DSCTO = dg.Rows[idx].Cells["COD_CANAL_DSCTO1"].Value.ToString();
                    plcTo.FE_AÑO = dg.Rows[idx].Cells["FE_AÑO1"].Value.ToString();
                    plcTo.FE_MES = dg.Rows[idx].Cells["FE_MES1"].Value.ToString();

                    if (!plcBLL.Retornar_a_Generacion_BLL(plcTo, ref errMensaje))
                        MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        MessageBox.Show("La planilla se retornó correctamente !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //TabControl1.SelectedTab = TabPage1;
                        PLANILLAS_ENVIADAS();
                        PENDIENTES_X_ENVIAR();
                    }

                }
                else
                    MessageBox.Show("USTED NO TIENE PERMISOS !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private bool validaRetorno(string val, DataGridView dg)
        {
            bool result = true;
            if (dg.Rows.Count <= 0)
            {
                MessageBox.Show("No hay registros !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return result = false;
            }

            return result;
        }

        private void btn_Imprimir_Click(object sender, EventArgs e)
        {
            if (DGW_DET.Rows.Count > 0)
            {
                List<planillaDetalleTo> pll = new List<planillaDetalleTo>();
                foreach (DataGridViewRow row in DGW_DET.Rows)
                {
                    planillaDetalleTo pld = new planillaDetalleTo();
                    pld.NRO_CONTRATO = row.Cells[0].Value.ToString();
                    pld.FECHA_CONTRATO = Convert.ToDateTime(row.Cells["FECHA_PRE_Det"].Value);
                    pld.CLIENTE = row.Cells["DESC_PER_Det"].Value.ToString();//3
                    pld.DESC_IDENTIDAD = row.Cells["DES_IDENTIDAD_Det"].Value.ToString();//2
                    //pld.DNI = row.Cells[4].Value.ToString();
                    pld.DES_PROCESO = row.Cells["DES_PROCESO_Det"].Value.ToString();
                    pld.IMP_DOC = Convert.ToDecimal(row.Cells["SAL_IMP_Det"].Value);//9
                    pld.NRO_LETRA = row.Cells["NRO_LETRA_Det"].Value.ToString() + "/" + row.Cells["TOT_LETRA_Det"].Value.ToString(); // 10 / 11
                    pll.Add(pld);
                }

                Reportes.FormRep.REP_COBRANZA_INTERNA_ENVIADA frm = new Reportes.FormRep.REP_COBRANZA_INTERNA_ENVIADA();
                frm.nro_planilla = txt_ser.Text + "-" + txt_num.Text;
                frm.fec_planilla = dtp_generacion.Value.ToShortDateString();
                frm.pto_cob_consolidado = cbo_ptoCobranza.Text;
                frm.totalcuotas = DGW_DET.Rows.Count.ToString();
                frm.totalclientes = HALLAR_TOTAL_CLIENTES();
                frm.lstpll = pll;
                frm.Show();
            }
        }
        private string HALLAR_TOTAL_CLIENTES()
        {
            string n = "";
            return n = DGW_DET.Rows.Cast<DataGridViewRow>().Select(x => x.Cells[0].Value).Distinct().Count().ToString();
        }
        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            BOTON = "NUEVO";
            btn_Imprimir.Enabled = false;
            TabControl1.SelectedTab = TabPage1;
            LIMPIAR_CABECERA();
        }

        private void btn_salir1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btn_Consulta1_Click(object sender, EventArgs e)
        {
            try
            {
                int num = dgw_enviados.CurrentRow.Index;
            }
            catch (Exception)
            {
                MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            BOTON = "MODIFICAR";

            btn_Imprimir.Enabled = true;
            TabControl1.SelectedTab = TabPage2;
            LIMPIAR_CABECERA();
            DGW_DET.Rows.Clear();
            DGW_DET.Enabled = true;
            CARGAR_CABECERA_ENVIADA(dgw_enviados);//aqui esta el problema
            CARGAR_DETALLE_ENVIADA(dgw_enviados);
            btn_Imprimir.Focus();
        }

        private void cbo_institucion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_institucion.SelectedValue != null)
                CARGAR_PTO_COBRANZA_CONSOLIDADO();
        }

        private void btn_vista_previa_Click(object sender, EventArgs e)
        {
            DataTable dtDetalle = obtenerDT();
            DataTable dtDetalleConsolidado = obtenerDTConsolidado(dtDetalle);
            if (dtDetalleConsolidado.Rows.Count > 0)
            {
                List<planillaDetalleTo> lpcc = new List<planillaDetalleTo>();
                foreach (DataRow row in dtDetalleConsolidado.Rows)
                {
                    planillaDetalleTo pld = new planillaDetalleTo();
                    pld.NRO_CONTRATO = row[0].ToString();
                    pld.FECHA_CONTRATO = Convert.ToDateTime(row["FECHA_PRE_Det"]);
                    pld.CLIENTE = row["DESC_PER_Det"].ToString();//3
                    pld.DESC_IDENTIDAD = row["DES_IDENTIDAD_Det"].ToString();//2
                    pld.DNI = row["DNI_Det"].ToString();
                    pld.DES_PROCESO = row["DES_PROCESO_Det"].ToString();
                    pld.IMP_DOC = Convert.ToDecimal(row["SAL_IMP_Det"]);//9
                    pld.NRO_LETRA = row["NRO_LETRA_Det"].ToString() + "/" + row["TOT_LETRA_Det"].ToString(); // 10 / 11
                    pld.DESC_PTO_VEN = row["DESC_PTO_VEN"].ToString();
                    lpcc.Add(pld);
                }
                MOD_CXC.Reportes.FormRep.REP_PLANILLA_ENVIADA_PREVIA frm = new MOD_CXC.Reportes.FormRep.REP_PLANILLA_ENVIADA_PREVIA();
                frm.nro_planilla = txt_ser.Text + "-" + txt_num.Text;
                frm.fec_planilla = dtp_generacion.Value.ToShortDateString();
                frm.pto_cob_consolidado = cbo_ptoCobranza.Text;
                frm.totalcuotas = DGW_DET.Rows.Count.ToString();
                frm.totalclientes = HALLAR_TOTAL_CLIENTES();
                frm.lstpll = lpcc;
                frm.Show();
            }
            else
            {
                MessageBox.Show("No existen datos !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //txt_nro_rep.Focus();
            }
        }

        private void cbo_tipo_planilla_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_tipo_planilla.SelectedValue != null)
                lbl_cod_tipo_plla.Text = cbo_tipo_planilla.SelectedValue.ToString();
        }

    }
}
