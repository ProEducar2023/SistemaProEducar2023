using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Presentacion.MOD_CXC
{
    public partial class RECEPCION_I_PLANILLAS : Form
    {
        string AÑO = "", MES = "", COD_MOD = "", COD_USU = "", TIPO_USU = "";
        string temp = "";
        DateTime FECHA_INI, FECHA_GRAL;
        string BOTON;
        DataTable dtPlanillaEnviada, dtPlanillaContrato;
        planillaCabeceraBLL plcBLL = new planillaCabeceraBLL();
        planillaCabeceraTo plcTo = new planillaCabeceraTo();
        canjePCtasxCobrarBLL pctaBLL = new canjePCtasxCobrarBLL();
        canjePCtasxCobrarTo pctaTo = new canjePCtasxCobrarTo();
        contratoCabeceraBLL ccBLL = new contratoCabeceraBLL();
        contratoCabeceraTo ccTo = new contratoCabeceraTo();
        decimal sum_env = 0, sum_rec = 0, sum_cta_cte = 0, sum_dev = 0, sum_tot_rec = 0, sum_indebido = 0, sum_exceso_contrato = 0;
        DIALOGOS.CONSULTA_PCTAS_COBRAR_POR_NROCONTRATO OFR = new DIALOGOS.CONSULTA_PCTAS_COBRAR_POR_NROCONTRATO();
        string OP = "";
        planillaCabeceraOtrasDevDsctosBLL ploBLL = new planillaCabeceraOtrasDevDsctosBLL();
        planillaCabeceraOtrasDevDsctosTo ploTo = new planillaCabeceraOtrasDevDsctosTo();
        int filaSeleccionada = 0;
        public RECEPCION_I_PLANILLAS(string AÑO, string MES, DateTime FECHA_INI, DateTime FECHA_GRAL, string COD_MOD, string TIPO_USU, string COD_USU)
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

        private void RECEPCION_I_PLANILLAS_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            //DATAGRID();
            PLANILLAS_RECEPCIONADAS();
            PENDIENTES_X_RECEPCIONAR();
            CARGAR_SUCURSAL();
            CARGAR_CANAL_DSCTO();
            CARGAR_INSTITUCIONES();
            //CARGAR_PTO_COBRANZA_CONSOLIDADO();
            //CARGAR_SECTORISTA();
            INICIAR_CABECERA_GRID_DETALLE();
            CARGAR_TIPO_PLANILLA();
            //CARGAR_FORMATOS();
            CARGA_COMBO_OBS();
            //dtp_generacion.CustomFormat = "dd/MM/yyyy hh:mm:ss";
            //dtp_generacion.Format = DateTimePickerFormat.Custom;
            tlt_recepcion_plla.SetToolTip(btn_agregarCuota, "Indebidos y \nExceso Contrato");
            tlt_recepcion_plla.SetToolTip(btn_editar, "Suspendidos");
        }
        private void PLANILLAS_RECEPCIONADAS()
        {
            plcTo.FE_AÑO = AÑO;//ESTO NO SE USA PORQUE LA FECHA ACTUAL AÑO Y MES PUEDEN NO SER LOS DE LOS DE LA TABLA EN PROCESO // DON MIGUEL DICE QUE SI
            plcTo.FE_MES = MES;
            plcTo.STATUS_RECEPCION = "1";
            DataTable dt = plcBLL.obtener_Recepcion_I_Planilla_Cabecera_BLL(plcTo);
            dgw_recepcionado.DataSource = dt;
            if (dt.Rows.Count > 0)
            {
                dgw_recepcionado.Columns["TIPO_PLANILLA"].HeaderText = "Tipo";
                dgw_recepcionado.Columns["TIPO_PLANILLA"].Width = 30;
                dgw_recepcionado.Columns["TIPO_PLANILLA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgw_recepcionado.Columns["NRO_PLANILLA_COB"].HeaderText = "Nro Planilla";
                dgw_recepcionado.Columns["NRO_PLANILLA_COB"].Width = 80;
                dgw_recepcionado.Columns["FECHA_PLANILLA_COB"].HeaderText = "Fec Planilla";
                dgw_recepcionado.Columns["FECHA_PLANILLA_COB"].Width = 70;
                dgw_recepcionado.Columns["FECHA_PLANILLA_COB"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgw_recepcionado.Columns["COD_INSTITUCION"].Visible = false;
                dgw_recepcionado.Columns["DESC_INST"].HeaderText = "Institucion";
                dgw_recepcionado.Columns["DESC_INST"].Width = 150;
                dgw_recepcionado.Columns["COD_PTO_COB_CONSOLIDADO"].Visible = false;
                dgw_recepcionado.Columns["DESC_PTO_COB"].HeaderText = "Punto Cobranza Consolidado";
                dgw_recepcionado.Columns["DESC_PTO_COB"].Width = 170;
                dgw_recepcionado.Columns["COD_CANAL_DSCTO"].Visible = false;
                dgw_recepcionado.Columns["DESCRIPCION"].HeaderText = "Canal Descuento";
                dgw_recepcionado.Columns["DESCRIPCION"].Width = 150;
                dgw_recepcionado.Columns["COD_SUCURSAL"].Visible = false;
                dgw_recepcionado.Columns["COD_PTO_COB"].Visible = false;
                dgw_recepcionado.Columns["COD_SECTORISTA"].Visible = false;
                dgw_recepcionado.Columns["DESC_EQVTA"].HeaderText = "Sectorista";
                dgw_recepcionado.Columns["DESC_EQVTA"].Width = 150;
                dgw_recepcionado.Columns["COD_COBRADOR"].Visible = false;
                //dgw_recepcionado.Columns["COBR"].HeaderText = "Cobrador";
                //dgw_recepcionado.Columns["COBR"].Width = 160;
                dgw_recepcionado.Columns["COBR"].Visible = false;
                //dgw_recepcionado.Columns["FECHA_PLANILLA_COB"].Visible = false;
                dgw_recepcionado.Columns["FECHA_VEN_AL"].Visible = false;
                dgw_recepcionado.Columns["FECHA_APROBACION"].Visible = false;
                dgw_recepcionado.Columns["FECHA_ENVIO"].HeaderText = "Fec Env";
                dgw_recepcionado.Columns["FECHA_ENVIO"].Width = 70;
                dgw_recepcionado.Columns["FECHA_ENVIO"].DefaultCellStyle.Format = "dd/MM/yyyy";
                //dgw_recepcionado.Columns["FECHA_ENVIO"].Visible = false; ;
                dgw_recepcionado.Columns["OBSERVACION"].Visible = false;
                //dgw_recepcionado.Columns["TIPO_PLANILLA"].Visible = false;
                dgw_recepcionado.Columns["COD_FORMATO"].Visible = false;
                dgw_recepcionado.Columns["FE_AÑO"].Visible = false;
                dgw_recepcionado.Columns["FE_MES"].Visible = false;
                dgw_recepcionado.Columns["COD_CLASE"].Visible = false;
                dgw_recepcionado.Columns["FECHA_RECEPCION"].HeaderText = "Fec Rec";
                dgw_recepcionado.Columns["FECHA_RECEPCION"].Width = 70;
                dgw_recepcionado.Columns["FECHA_RECEPCION"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgw_recepcionado.Columns["STATUS_RECEPCION"].Visible = false;
                dgw_recepcionado.Columns["IMP_ENVIO"].HeaderText = "Imp Env";
                dgw_recepcionado.Columns["IMP_ENVIO"].Width = 60;
                dgw_recepcionado.Columns["IMP_ENVIO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgw_recepcionado.Columns["IMP_ENVIO"].DefaultCellStyle.Format = "###,###,##0.00";
                dgw_recepcionado.Columns["IMP_RECEPCION_CTA_CTE"].HeaderText = "Imp Rec";
                dgw_recepcionado.Columns["IMP_RECEPCION_CTA_CTE"].Width = 60;
                dgw_recepcionado.Columns["IMP_RECEPCION_CTA_CTE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgw_recepcionado.Columns["IMP_RECEPCION_CTA_CTE"].DefaultCellStyle.Format = "###,###,##0.00";
                dgw_recepcionado.Columns["APROBAR_RECEPCIONADO"].HeaderText = "Aprobado";
                dgw_recepcionado.Columns["APROBAR_RECEPCIONADO"].Width = 50;
            }

        }
        private void CARGA_COMBO_OBS()
        {
            DataGridViewComboBoxColumn comboboxColumn = DGW_DET.Columns["Column15"] as DataGridViewComboBoxColumn;
            directorioBLL dirBLL = new directorioBLL();
            directorioTo dirTo = new directorioTo();
            //dirTo.TABLA_COD = "RECEP";
            //DataTable dt = dirBLL.MOSTRAR_DIRECTORIO_DATO_BLL(dirTo);
            DataTable dt = dirBLL.MOSTRAR_MOTIVOS_RECEPCION_DESCUENTO_BLL();
            DataRow rw = dt.NewRow();
            rw["Descripción"] = " ";
            rw["Codigo"] = " ";
            dt.Rows.InsertAt(rw, 0);
            comboboxColumn.DataSource = dt;
            comboboxColumn.DisplayMember = "Descripción";
            comboboxColumn.ValueMember = "Codigo";
            // bindeo los datos de los productos a la grilla
            DGW_DET.AutoGenerateColumns = false;
            //DGW_DET.DataSource = ProductosDAL.GetAllProductos();
        }
        private void RECEPCION_I_PLANILLAS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
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
        private void PENDIENTES_X_RECEPCIONAR()
        {
            plcTo.FE_AÑO = AÑO;//ESTO NO SE USA PORQUE LA FECHA ACTUAL AÑO Y MES PUEDEN NO SER LOS DE LOS DE LA TABLA EN PROCESO // DON MIGUEL DICE QUE SI
            plcTo.FE_MES = MES;
            plcTo.STATUS_RECEPCION = "0";
            DataTable dt = plcBLL.obtener_Recepcion_I_Planilla_Cabecera_BLL(plcTo);
            dgw1.DataSource = dt;
            if (dt.Rows.Count > 0)
            {
                dgw1.Columns["TIPO_PLANILLA"].HeaderText = "Tipo";
                dgw1.Columns["TIPO_PLANILLA"].Width = 30;
                dgw1.Columns["TIPO_PLANILLA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgw1.Columns["NRO_PLANILLA_COB"].HeaderText = "Nro Planilla";
                dgw1.Columns["NRO_PLANILLA_COB"].Width = 80;
                dgw1.Columns["FECHA_PLANILLA_COB"].HeaderText = "Fec Planilla";
                dgw1.Columns["FECHA_PLANILLA_COB"].Width = 70;
                dgw1.Columns["FECHA_PLANILLA_COB"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgw1.Columns["COD_INSTITUCION"].Visible = false;
                dgw1.Columns["DESC_INST"].HeaderText = "Institucion";
                dgw1.Columns["DESC_INST"].Width = 160;
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
                dgw1.Columns["DESC_EQVTA"].Width = 180;
                dgw1.Columns["COD_COBRADOR"].Visible = false;
                dgw1.Columns["COBR"].Visible = false;
                //dgw1.Columns["COBR"].HeaderText = "Cobrador";
                //dgw1.Columns["COBR"].Width = 180;
                //dgw1.Columns["FECHA_PLANILLA_COB"].Visible = false;
                dgw1.Columns["FECHA_VEN_AL"].Visible = false;
                dgw1.Columns["FECHA_APROBACION"].Visible = false;
                dgw1.Columns["FECHA_ENVIO"].HeaderText = "Fec Env";
                dgw1.Columns["FECHA_ENVIO"].Width = 70;
                dgw1.Columns["FECHA_ENVIO"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgw1.Columns["IMP_ENVIO"].HeaderText = "Imp Env";
                dgw1.Columns["IMP_ENVIO"].Width = 70;
                dgw1.Columns["IMP_ENVIO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgw1.Columns["IMP_ENVIO"].DefaultCellStyle.Format = "###,###,##0.00";
                dgw1.Columns["OBSERVACION"].Visible = false;
                //dgw1.Columns["TIPO_PLANILLA"].Visible = false;
                dgw1.Columns["COD_FORMATO"].Visible = false;
                dgw1.Columns["FE_AÑO"].Visible = false;
                dgw1.Columns["FE_MES"].Visible = false;
                dgw1.Columns["COD_CLASE"].Visible = false;
                dgw1.Columns["FECHA_RECEPCION"].Visible = false;
                dgw1.Columns["STATUS_RECEPCION"].Visible = false;
                dgw1.Columns["APROBAR_RECEPCIONADO"].Visible = false;
                dgw1.Columns["IMP_RECEPCION_CTA_CTE"].Visible = false;
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
            DGW_DET.Columns[0].HeaderText = "Contrato";
            DGW_DET.Columns[0].Width = 60;
            DGW_DET.Columns[0].ReadOnly = true;
            DGW_DET.Columns[1].HeaderText = "Codigo";
            DGW_DET.Columns[1].Width = 50;
            DGW_DET.Columns[1].ReadOnly = true;
            DGW_DET.Columns[2].HeaderText = "Cod Modular";
            DGW_DET.Columns[2].Width = 80;
            DGW_DET.Columns[2].ReadOnly = true;
            DGW_DET.Columns[3].HeaderText = "Nombre Cliente";
            DGW_DET.Columns[3].Width = 200;
            DGW_DET.Columns[3].ReadOnly = true;
            DGW_DET.Columns[4].HeaderText = "DNI/Ruc";
            DGW_DET.Columns[4].Width = 80;
            DGW_DET.Columns[4].ReadOnly = true;
            DGW_DET.Columns[5].Visible = false;
            DGW_DET.Columns[6].HeaderText = "N° Doc";
            DGW_DET.Columns[6].Width = 60;
            DGW_DET.Columns[6].ReadOnly = true;
            DGW_DET.Columns[7].HeaderText = "Fec Ven";
            DGW_DET.Columns[7].Width = 70;
            DGW_DET.Columns[7].ReadOnly = true;
            DGW_DET.Columns[7].DefaultCellStyle.Format = "dd/MM/yyyy";
            DGW_DET.Columns[8].HeaderText = "Imp Env";
            DGW_DET.Columns[8].Width = 60;
            DGW_DET.Columns[8].ReadOnly = true;
            DGW_DET.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DGW_DET.Columns[9].HeaderText = "Imp Rec";
            DGW_DET.Columns[9].Width = 60;
            DGW_DET.Columns[9].ReadOnly = true;
            DGW_DET.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DGW_DET.Columns[10].HeaderText = "xDev";
            DGW_DET.Columns[10].Width = 50;
            DGW_DET.Columns[10].ReadOnly = true;
            DGW_DET.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DGW_DET.Columns[11].HeaderText = "Dev";
            DGW_DET.Columns[11].Width = 50;
            DGW_DET.Columns[11].ReadOnly = true;
            DGW_DET.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DGW_DET.Columns[12].HeaderText = "Letra";
            DGW_DET.Columns[12].Width = 45;
            DGW_DET.Columns[12].ReadOnly = true;
            DGW_DET.Columns[13].HeaderText = "Tot Let";
            DGW_DET.Columns[13].Width = 45;
            DGW_DET.Columns[13].ReadOnly = true;
            DGW_DET.Columns[14].HeaderText = "Motivo No Descontado";
            DGW_DET.Columns[14].Width = 240;
            DGW_DET.Columns[14].ReadOnly = false;
            DGW_DET.Columns[15].HeaderText = "Observacion";
            DGW_DET.Columns[15].Width = 100;
            DGW_DET.Columns[15].ReadOnly = false;
            DGW_DET.Columns[16].Visible = false;
            DGW_DET.Columns[17].DisplayIndex = 12;//OK
            DGW_DET.Columns[1].Visible = false;
            //DGW_DET.Columns[10].Visible = false;
            //DGW_DET.Columns[11].Visible = false;
            DGW_DET.Columns[17].Visible = false;
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
            //tpllaTo.STATUS_GENERACION = "1";
            tpllaTo.STATUS_CTACTE = "1";
            tpllaTo.COD_VENTA = "VTA";
            DataTable dtTipoPlla = tpllaBLL.obtenerTipoPlanillaCreacionGeneracionPllaBLL(tpllaTo);
            if (dtTipoPlla.Rows.Count > 0)
            {
                cbo_tipo_planilla.ValueMember = "COD_TIPO_PLLA";
                cbo_tipo_planilla.DisplayMember = "DESC_TIPO";
                cbo_tipo_planilla.DataSource = dtTipoPlla;
                cbo_tipo_planilla.SelectedIndex = 0;
            }
        }

        private void btn_consulta_Click(object sender, EventArgs e)
        {
            if (dgw_recepcionado.Rows.Count > 0)
            {
                try
                {
                    int num = dgw_recepcionado.CurrentRow.Index;
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
                CARGAR_CABECERA(dgw_recepcionado);
                CARGAR_DETALLE(dgw_recepcionado, 2);//1 para los que ya se han recepcionado antes
                HALLAR_TOTALES();
                HALLAR_NRO_CONTRATOS();
                Panel4.Enabled = false;
                gc_recepcionado.Enabled = false;
                btn_eliminar.Enabled = false;
                btn_agregarCuota.Enabled = false;
                btn_editar.Enabled = false;
                btn_Imprimir.Enabled = true;
                btnCargar.Enabled = false;
                btn_cancelar.Enabled = true;
                DGW_DET.Columns[14].ReadOnly = true;
                DGW_DET.Columns[17].ReadOnly = true;
                btn_Imprimir.Focus();
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
        private void CARGAR_CABECERA(DataGridView dg)
        {
            int idx = dg.CurrentRow.Index;
            cbo_sucursal.SelectedValue = dg.Rows[idx].Cells["COD_SUCURSAL"].Value;
            cbo_institucion.SelectedValue = dg.Rows[idx].Cells["COD_INSTITUCION"].Value;
            CARGAR_PTO_COBRANZA_CONSOLIDADO();
            cbo_ptoCobranza.SelectedValue = dg.Rows[idx].Cells["COD_PTO_COB_CONSOLIDADO"].Value;
            //cbo_formato.SelectedValue = dgw1.Rows[idx].Cells["COD_FORMATO"].Value;
            cbo_canaldscto.SelectedValue = dg.Rows[idx].Cells["COD_CANAL_DSCTO"].Value;
            if (dg.Rows[idx].Cells["COD_PTO_COB"].Value.ToString() != "")
            {
                CH_PV.Checked = true;
                llena_Pto_Cobranza_X_PtoCobConsolidado();
                cbo_pto_cob.SelectedValue = dg.Rows[idx].Cells["COD_PTO_COB"].Value;
            }
            else
            {
                cbo_pto_cob.DataSource = null;
                CH_PV.Checked = false;
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
            txt_tot_enviado.Text = Convert.ToDecimal(dg.Rows[idx].Cells["IMP_ENVIO"].Value).ToString("###,###,##0.00");
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
        private void CARGAR_DETALLE(DataGridView dg, int op)
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
            dtPlanillaEnviada = pldBLL.obtener_I_Planilla_Detalle_para_Recepcion_BLL(pldTo);//SP [MOSTRAR_T_PLANILLA_COB_DETALLE_PARA_RECEPCION]
            dtPlanillaContrato = dtPlanillaEnviada.Clone();
            DataTable dtConsolidado = pldBLL.obtener_I_Planilla_Detalle_para_Recepcion_Consolidado_BLL(pldTo);
            if (dtConsolidado.Rows.Count > 0)
            {
                DGW_DET_CONSOLIDADO.Rows.Clear();
                foreach (DataRow rwc in dtConsolidado.Rows)
                {
                    int rowIdc = DGW_DET_CONSOLIDADO.Rows.Add();
                    DataGridViewRow rowc = DGW_DET_CONSOLIDADO.Rows[rowIdc];
                    rowc.Cells["NRO_CONTRATO_Cab"].Value = rwc["NRO_CONTRATO"].ToString();
                    rowc.Cells["COD_PER_Cab"].Value = rwc["COD_PER"].ToString();
                    rowc.Cells["DES_IDENTIDAD_Cab"].Value = rwc["DES_IDENTIDAD"].ToString().Trim();
                    rowc.Cells["DES_PROCESO_Cab"].Value = rwc["DES_PROCESO"].ToString().Trim();
                    rowc.Cells["DESC_PER_Cab"].Value = rwc["DESC_PER"].ToString();
                    rowc.Cells["DNI_Cab"].Value = rwc["DNI"].ToString();
                    rowc.Cells["IMP_DOC_Cab"].Value = Convert.ToDecimal(rwc["IMP_DOC"]).ToString("###,###,##0.00");
                    rowc.Cells["IMP_COB_Cab"].Value = op == 1 ? Convert.ToDecimal(rowc.Cells["IMP_DOC_Cab"].Value).ToString("###,###,##0.00") : Convert.ToDecimal(rwc["IMP_COB"]).ToString("###,###,##0.00");
                    rowc.Cells["X"].Value = rwc["OK"].ToString();
                }
            }
            ///--------------------------------------------------------------------------------------------
            if (op == 2)
            {
                if (dtPlanillaEnviada.Rows.Count > 0)
                {
                    DGW_DET.Rows.Clear();
                    foreach (DataRow rw in dtPlanillaEnviada.Rows)
                    {
                        if (Convert.ToBoolean(rw[17]))
                        {
                            int rowId = DGW_DET.Rows.Add();
                            DataGridViewRow row = DGW_DET.Rows[rowId];
                            row.Cells[0].Value = rw["NRO_CONTRATO"].ToString() == "9999999" ? "" : rw["NRO_CONTRATO"].ToString();
                            row.Cells[1].Value = rw["COD_PER"].ToString();
                            row.Cells[2].Value = rw["DES_IDENTIDAD"].ToString().Trim();
                            row.Cells[3].Value = rw["DESC_PER"].ToString();
                            row.Cells[4].Value = rw["DNI"].ToString();
                            row.Cells[5].Value = rw["COD_DOC"].ToString();
                            row.Cells[6].Value = rw["NRO_DOC"].ToString().Trim();
                            row.Cells[7].Value = rw["FECHA_VEN"].ToString() == "" ? "" : rw["FECHA_VEN"].ToString().Substring(0, 10);
                            //row.Cells[8].Value = rw["SAL_IMP"].ToString();
                            //row.Cells[9].Value = rw["IMP_INI"].ToString();//SAL_IMP
                            row.Cells[8].Value = rw["IMP_DOC"].ToString();
                            //row.Cells[9].Value = Convert.ToDecimal(rw["IMP_COB"]) == 0 ? rw["IMP_DOC"].ToString() : rw["IMP_COB"].ToString();//
                            if (op == 1)//1 los que no se han hecho recepcion antes
                            {
                                if (chk_recepcionado.Checked)
                                    row.Cells[9].Value = "0.00";
                                else
                                    row.Cells[9].Value = rw["IMP_DOC"].ToString();
                            }
                            else if (op == 2)//2 los que ya hicieron recepcion antes 
                            {
                                row.Cells[9].Value = rw["IMP_COB"].ToString();
                            }
                            row.Cells[10].Value = rw["IMP_COB_CTA_CTE"].ToString();
                            row.Cells[11].Value = rw["IMP_DEV"].ToString();
                            row.Cells[12].Value = rw["NRO_LETRA"].ToString();
                            row.Cells[13].Value = rw["TOT_LETRA"].ToString();
                            row.Cells[14].Value = rw["COD_MOTIVO_NO_DESCONTADO"];
                            row.Cells[15].Value = rw["OBSERVACION"].ToString();
                            row.Cells[17].Value = Convert.ToBoolean(rw["OK"]);
                            row.Cells["NOM_MOTIVO_NO_DESCONTADO"].Value = rw["NOM_MOTIVO_NO_DESCONTADO"].ToString();
                            row.Cells["DES_PROCESO"].Value = rw["DES_PROCESO"].ToString();
                            row.Cells["CATEGORIA_MOTIVOS_PLANILLA"].Value = rw["CATEGORIA_MOTIVOS_PLANILLA"].ToString();
                        }
                    }

                }
            }

            //HALLAR_TOTALES();
            //HALLAR_NRO_CONTRATOS();
        }
        private void HALLAR_TOTALES()
        {
            //dtPla.AsEnumerable().Where(x =>x.Field<string>("COD_MOTIVO")=="").Sum(x => x.Field<decimal>("IMP_DOC")).ToString();
            int num = DGW_DET.Rows.Count - 1;
            //decimal sum_env=0, sum_rec=0, sum_cta_cte=0, sum_dev = 0, sum_tot_rec=0, sum_indebido=0, sum_exceso_contrato=0;
            sum_env = 0; sum_rec = 0; sum_cta_cte = 0; sum_dev = 0; sum_tot_rec = 0; sum_indebido = 0; sum_exceso_contrato = 0;
            int i = 0;
            while (i <= num)
            {
                if (DGW_DET.Rows[i].Cells["CATEGORIA_MOTIVOS_PLANILLA"].Value.ToString() == "01")//no descontado
                {
                    sum_env = decimal.Add(sum_env, Convert.ToDecimal(DGW_DET[8, i].Value) - Convert.ToDecimal(DGW_DET[9, i].Value));//no descontado
                    sum_rec += Convert.ToDecimal(DGW_DET[9, i].Value);
                }
                else if (DGW_DET.Rows[i].Cells["CATEGORIA_MOTIVOS_PLANILLA"].Value.ToString() == "02")
                    sum_rec = decimal.Add(sum_rec, Convert.ToDecimal(DGW_DET[9, i].Value));//descontado
                else if (DGW_DET.Rows[i].Cells["CATEGORIA_MOTIVOS_PLANILLA"].Value.ToString() == "03" && (DGW_DET.Rows[i].Cells[14].Value.ToString() == "004")) //|| DGW_DET.Rows[i].Cells[14].Value.ToString() == "006")
                    sum_rec = decimal.Add(sum_rec, Convert.ToDecimal(DGW_DET[9, i].Value));//descontado
                if (DGW_DET.Rows[i].Cells["CATEGORIA_MOTIVOS_PLANILLA"].Value.ToString() == "03" && DGW_DET.Rows[i].Cells[14].Value.ToString() == "005")
                    sum_indebido += Convert.ToDecimal(DGW_DET[11, i].Value);
                else if (DGW_DET.Rows[i].Cells["CATEGORIA_MOTIVOS_PLANILLA"].Value.ToString() == "03" && DGW_DET.Rows[i].Cells[14].Value.ToString() == "006")
                    sum_exceso_contrato += Convert.ToDecimal(DGW_DET[11, i].Value);
                //sum_dev = decimal.Add(sum_dev, Convert.ToDecimal(DGW_DET[11, i].Value));//indebido - exceso contrato
                sum_cta_cte = decimal.Add(sum_cta_cte, Convert.ToDecimal(DGW_DET[10, i].Value));//exceso cuota
                //sum_tot_rec = sum_rec + sum_cta_cte + sum_dev;
                sum_tot_rec = sum_rec + sum_cta_cte + sum_indebido + sum_exceso_contrato;
                i++;
            }
            txt_totimp.Text = sum_env.ToString();//no descontado
            txt_totimp.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(txt_totimp.Text);
            txt_tot_recibido.Text = sum_tot_rec.ToString();//descuento indebido / exceso contrato
            txt_tot_recibido.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(txt_tot_recibido.Text);
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

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            string ruta = "", arch = "";
            if (ruta.Length == 0)
                ruta = @"C:\";
            if (arch.Length == 0)
                arch = "";

            OpenFileDialog file = new OpenFileDialog();
            file.InitialDirectory = ruta;
            file.Filter = "Archivo de texto (*.txt)|*.txt;| All Files (*.*)|*.*";
            file.FilterIndex = 2;
            file.RestoreDirectory = false;
            if (file.ShowDialog() == DialogResult.OK)
            {
                txt_datos.Text = file.FileName;
                ruta = Path.GetDirectoryName(file.FileName);
                arch = Path.GetFileName(file.FileName);
            }
            DGW_DET.Rows.Clear();
            CARGAR_DETALLE(dgw1, 1);//1 porque aun no se ha recepcionado nada
            CARGA_RECEPCION();
            HALLAR_TOTALES();
            HALLAR_NRO_CONTRATOS();
        }
        private void CARGA_RECEPCION()
        {
            string line; string cod_arch = "", cod_grid = ""; decimal monto = 0;
            string[] campos = new string[2];
            bool encontrado;
            DataTable dt = new DataTable();
            dt.Columns.Add("val", typeof(string));
            dt.Columns.Add("cod", typeof(decimal));
            char[] separador = { '|' };
            StreamReader file = new StreamReader(txt_datos.Text);
            try
            {
                while ((line = file.ReadLine()) != null)
                {
                    campos = line.Split(separador);
                    cod_arch = campos[0];
                    monto = Convert.ToDecimal(campos[1]);
                    encontrado = false;
                    for (int i = 0; i < DGW_DET.Rows.Count; i++)
                    {
                        cod_grid = DGW_DET.Rows[i].Cells[2].Value.ToString();
                        if (cod_arch == cod_grid)
                        {
                            if (monto >= 0)
                            {
                                if (monto >= Convert.ToDecimal(DGW_DET.Rows[i].Cells[8].Value))
                                {
                                    DGW_DET.Rows[i].Cells[9].Value = DGW_DET.Rows[i].Cells[8].Value;
                                }
                                else
                                {
                                    DGW_DET.Rows[i].Cells[9].Value = monto;
                                    break;
                                }
                                monto = monto - Convert.ToDecimal(DGW_DET.Rows[i].Cells[8].Value);
                            }
                            encontrado = true;
                            if (i == DGW_DET.Rows.Count - 1)
                            {
                                if (monto > 0)
                                {
                                    DGW_DET.Rows[i].Cells[10].Value = monto;
                                    DGW_DET.Rows[i].Cells[11].ReadOnly = false;//se habilita columna Devolucion para escribir ahì, si se quiere pasar el exceso para devolver
                                }
                            }
                            DGW_DET.Rows[i].Cells["OK"].Value = true;//a todos los que encuentre los checkea por defecto, 
                        }
                        else
                        {
                            if (i != DGW_DET.Rows.Count - 1)
                            {
                                if (monto > 0 && encontrado == true)
                                {
                                    DGW_DET.Rows[i - 1].Cells[10].Value = monto;
                                    DGW_DET.Rows[i].Cells[11].ReadOnly = false;//se habilita columna Devolucion para escribir ahì, si se quiere pasar el exceso para devolver
                                }
                            }
                            else if (i == DGW_DET.Rows.Count - 1)
                            {
                                if (encontrado == false)
                                {
                                    DataRow rw = dt.NewRow();
                                    rw["val"] = campos[0];
                                    rw["cod"] = Convert.ToDecimal(campos[1]);
                                    dt.Rows.Add(rw);
                                }
                                else if (monto > 0 && encontrado == true)
                                {
                                    DGW_DET.Rows[i - 1].Cells[10].Value = monto;
                                    DGW_DET.Rows[i].Cells[11].ReadOnly = false;//se habilita columna Devolucion para escribir ahì, si se quiere pasar el exceso para devolver
                                }
                            }
                        }
                    }
                }
                foreach (DataRow fila in dt.Rows)
                {
                    int rowId = DGW_DET.Rows.Add();
                    DataGridViewRow row = DGW_DET.Rows[rowId];
                    row.Cells[0].Value = "0000000";
                    row.Cells[2].Value = fila[0];
                    row.Cells[11].Value = Convert.ToDecimal(fila[1]);
                }
                file.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("AY GUEY !!! " + cod_arch + " " + monto);
            }
        }
        private void HALLAR_NRO_CONTRATOS()
        {
            int n = 0; //int j = 0;
            DataTable dtN = null;
            dtN = obtenerDT();
            n = dtN.AsEnumerable().Where(x => x.Field<string>("Column1") != "0000000").Select(x => x.Field<string>("Column1")).Distinct().Count();
            txt_ctas.Text = n.ToString();
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {

        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            if (!validaGrabar())
                return;
            DialogResult rs = MessageBox.Show("¿ Esta seguro de Grabar la Recepcion de la Planilla ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                plcTo.NRO_PLANILLA_COB = txt_ser.Text + "-" + txt_num.Text;
                plcTo.COD_INSTITUCION = cbo_institucion.SelectedValue.ToString();
                plcTo.COD_PTO_COB_CONSOLIDADO = cbo_ptoCobranza.SelectedValue.ToString();
                plcTo.COD_CANAL_DSCTO = cbo_canaldscto.SelectedValue.ToString();
                plcTo.FE_AÑO = AÑO;//dtp_generacion.Value.ToShortDateString().Substring(6, 4);
                plcTo.FE_MES = MES;//dtp_generacion.Value.ToShortDateString().Substring(3, 2);
                plcTo.FECHA_RECEPCION = dtp_recep.Value;
                plcTo.COD_MOD = COD_USU;
                plcTo.FECHA_MOD = DateTime.Now;
                plcTo.TIPO_PLANILLA = cbo_tipo_planilla.SelectedValue.ToString();
                plcTo.COD_SUCURSAL = cbo_sucursal.SelectedValue.ToString();
                plcTo.STATUS_RECEPCIONADO = chk_recepcionado.Checked;
                //DateTime fecha = dtp_generacion.Value;
                //plcTo.FECHA_PLANILLA_COB = Convert.ToDateTime(fecha.ToString());
                plcTo.FECHA_PLANILLA_COB = dtp_generacion.Value.Date + DateTime.Now.TimeOfDay;
                DataTable dtDetalle = obtenerDT();
                //DataTable dtEliminar = dtDetalle.AsEnumerable().Where(x => x.Field<decimal>("Column9") == 0).CopyToDataTable();
                if (!plcBLL.RecepcionaPlanillaBLL(plcTo, dtDetalle, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("La planilla se grabó correctamente !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TabControl1.SelectedTab = TabPage3;
                    //DATAGRID();
                    PLANILLAS_RECEPCIONADAS();
                    PENDIENTES_X_RECEPCIONAR();
                    //btn_Imprimir.Enabled = true;
                    //btn_Imprimir.Focus();
                    FOCO_NUEVO_REG();
                }
            }
        }
        private void FOCO_NUEVO_REG()
        {
            int i, cont = 0;
            cont = dgw_recepcionado.Columns.Count - 1;
            string nrocon = txt_ser.Text + "-" + txt_num.Text.Trim();
            for (i = 0; i <= cont; i++)
            {
                if (nrocon == dgw_recepcionado.Rows[i].Cells["NRO_PLANILLA_COB"].Value.ToString().ToLower())
                {
                    dgw_recepcionado.CurrentCell = dgw_recepcionado.Rows[i].Cells["NRO_PLANILLA_COB"];
                    return;
                }
            }
        }
        public bool validaGrabar()
        {
            bool result = true;

            foreach (DataGridViewRow rw in DGW_DET.Rows)
            {
                if (!(rw.Cells[0].Value.ToString() == "0000000"))
                {
                    if ((Convert.ToDecimal(rw.Cells[9].Value) != (Convert.ToDecimal(rw.Cells[8].Value))) &&
                        (rw.Cells[14].Value.ToString().Trim() == "" || rw.Cells[14].Value == DBNull.Value))
                    {
                        MessageBox.Show("Elije el motivo de no descuento !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        rw.Selected = true;
                        return result = false;
                    }
                    if ((Convert.ToDecimal(rw.Cells[9].Value) == 0) &&
                        (rw.Cells[14].Value.ToString().Trim() == "005" || rw.Cells[14].Value.ToString().Trim() == "006"))
                    {
                        MessageBox.Show("Ingrese un valor en Imp Rec !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        rw.Cells[9].Selected = true;
                        DGW_DET.BeginEdit(true);
                        return result = false;
                    }
                }
            }
            return result;
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

        private void btn_agregarCuota_Click(object sender, EventArgs e)
        {
            OP = "IND/EXC";//INDEBIDO O EXCESO CONTTRATO
            agregar_Cuota_Indebida_ExcContrato();
        }
        private void agregar_Cuota_Indebida_ExcContrato()
        {
            int rowId = DGW_DET.Rows.Add();
            DataGridViewRow row = DGW_DET.Rows[rowId];
            row.Cells[0].Value = "";
            row.Cells[0].ReadOnly = false;
            row.Cells[1].Value = "";
            row.Cells[1].ReadOnly = true;
            row.Cells[2].Value = "";
            row.Cells[2].ReadOnly = true;
            row.Cells[3].Value = "";
            row.Cells[3].ReadOnly = OP == "IND/EXC" ? false : true;
            row.Cells[4].Value = "";
            row.Cells[4].ReadOnly = true;
            row.Cells[5].Value = "";
            row.Cells[5].ReadOnly = true;
            row.Cells[6].Value = "";
            row.Cells[6].ReadOnly = true;
            row.Cells[7].Value = "";
            row.Cells[7].ReadOnly = true;
            row.Cells[8].Value = "0";
            row.Cells[8].ReadOnly = true;
            row.Cells[9].Value = "0";
            row.Cells[9].ReadOnly = (OP == "IND/EXC" || OP == "SUSPENDIDO") ? false : true;
            row.Cells[10].Value = "0";
            row.Cells[10].ReadOnly = true;//OP == "SUSPENDIDO" ? false : true;
            row.Cells[11].Value = "0";
            row.Cells[11].ReadOnly = true;
            row.Cells[12].Value = "";
            row.Cells[12].ReadOnly = true;
            row.Cells[13].Value = "";
            row.Cells[13].ReadOnly = true;
            row.Cells[14].Value = "";
            row.Cells[14].ReadOnly = false;
            row.Cells[15].Value = "";
            row.Cells[15].ReadOnly = false;
            row.Cells[17].Value = true;//Convert.ToBoolean(rw["OK"]);
            row.Cells["NOM_MOTIVO_NO_DESCONTADO"].Value = "";
            row.Cells["DES_PROCESO"].Value = "";
            row.Cells["CATEGORIA_MOTIVOS_PLANILLA"].Value = "03";
            //DGW_DET.CurrentRow.Cells[0].Selected = true;
            DGW_DET.Rows[rowId].Cells[0].Selected = true;
            DGW_DET.BeginEdit(true);

        }
        private void INSERTAR_DE_DAILOG()
        {
            int idx = DGW_DET.CurrentRow.Index;
            int num = OFR.DGW_CAB.Rows.Count - 1;
            int num3 = num;
            int i = 0;
            decimal ctacte = 0;
            while (i <= num3)
            {
                if (Convert.ToBoolean(OFR.DGW_CAB[7, i].Value))
                {
                    ctacte = Convert.ToDecimal(DGW_DET.CurrentRow.Cells[10].Value);
                    DGW_DET.CurrentRow.Cells[10].Value = "0.00";
                    DGW_DET.Rows.Insert(idx + i + 1, DGW_DET[0, idx].Value.ToString(), DGW_DET[1, idx].Value.ToString(), DGW_DET[2, idx].Value.ToString(),
                        DGW_DET[3, idx].Value.ToString(), DGW_DET[4, idx].Value.ToString(), OFR.DGW_CAB[0, i].Value.ToString(),
                        OFR.DGW_CAB[1, i].Value.ToString().Trim(), OFR.DGW_CAB[2, i].Value.ToString(),
                        "0.00",//Convert.ToDecimal(OFR.DGW_CAB[3, i].Value) >= ctacte ? ctacte.ToString() : OFR.DGW_CAB[3, i].Value.ToString(),//OFR.DGW_CAB[3, i].Value.ToString(),
                        Convert.ToDecimal(OFR.DGW_CAB[4, i].Value) >= ctacte ? ctacte.ToString() : OFR.DGW_CAB[4, i].Value.ToString(),
                        Convert.ToDecimal(OFR.DGW_CAB[4, i].Value) >= ctacte ? "0.00" : (ctacte - Convert.ToDecimal(OFR.DGW_CAB[4, i].Value)).ToString(),
                        "0.00", OFR.DGW_CAB[5, i].Value.ToString(), OFR.DGW_CAB[6, i].Value.ToString(), "", "",//OFR.DGW_CAB[4, i].Value.ToString()
                        OFR.DGW_CAB[8, i].Value.ToString(), false);

                    DGW_DET.Rows[idx + i].Selected = true;
                }
                i++;
            }
            //DGW_DET.Sort(DGW_DET.Columns[0], System.ComponentModel.ListSortDirection.Ascending);
        }

        private void btn_Aprobar_Click(object sender, EventArgs e)
        {
            if (dgw_recepcionado.Rows.Count > 0)
            {
                if (!validaAprobar())
                    return;
                DialogResult rs = MessageBox.Show("¿ Esta seguro de Aprobar la Recepcion de la Planilla ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    string errMensaje = "";
                    plcTo.NRO_PLANILLA_COB = dgw_recepcionado.CurrentRow.Cells["NRO_PLANILLA_COB"].Value.ToString();
                    plcTo.COD_INSTITUCION = dgw_recepcionado.CurrentRow.Cells["COD_INSTITUCION"].Value.ToString();
                    plcTo.COD_PTO_COB_CONSOLIDADO = dgw_recepcionado.CurrentRow.Cells["COD_PTO_COB_CONSOLIDADO"].Value.ToString();
                    plcTo.COD_CANAL_DSCTO = dgw_recepcionado.CurrentRow.Cells["COD_CANAL_DSCTO"].Value.ToString();
                    plcTo.FE_AÑO = dgw_recepcionado.CurrentRow.Cells["FE_AÑO"].Value.ToString();
                    plcTo.FE_MES = dgw_recepcionado.CurrentRow.Cells["FE_MES"].Value.ToString();
                    plcTo.COD_MOD = COD_USU;
                    plcTo.FECHA_MOD = DateTime.Now;
                    plcTo.COD_SUCURSAL = dgw_recepcionado.CurrentRow.Cells["COD_SUCURSAL"].Value.ToString();
                    plcTo.COD_CLASE = dgw_recepcionado.CurrentRow.Cells["COD_CLASE"].Value.ToString();
                    plcTo.COD_SECTORISTA = dgw_recepcionado.CurrentRow.Cells["COD_SECTORISTA"].Value.ToString();
                    plcTo.FECHA_PLANILLA_COB = Convert.ToDateTime(dgw_recepcionado.CurrentRow.Cells["FECHA_PLANILLA_COB"].Value);
                    plcTo.FECHA_RECEPCION = Convert.ToDateTime(dgw_recepcionado.CurrentRow.Cells["FECHA_RECEPCION"].Value);
                    plcTo.OBSERVACION = dgw_recepcionado.CurrentRow.Cells["OBSERVACION"].Value.ToString();
                    plcTo.TIPO_PLANILLA = dgw_recepcionado.CurrentRow.Cells["TIPO_PLANILLA"].Value.ToString();
                    planillaDetalleBLL pldBLL = new planillaDetalleBLL();
                    planillaDetalleTo pldTo = new planillaDetalleTo();
                    pldTo.NRO_PLANILLA_COB = dgw_recepcionado.CurrentRow.Cells["NRO_PLANILLA_COB"].Value.ToString();
                    pldTo.COD_INSTITUCION = dgw_recepcionado.CurrentRow.Cells["COD_INSTITUCION"].Value.ToString();
                    pldTo.COD_PTO_COB_CONSOLIDADO = dgw_recepcionado.CurrentRow.Cells["COD_PTO_COB_CONSOLIDADO"].Value.ToString();
                    pldTo.COD_CANAL_DSCTO = dgw_recepcionado.CurrentRow.Cells["COD_CANAL_DSCTO"].Value.ToString();
                    pldTo.FE_AÑO = dgw_recepcionado.CurrentRow.Cells["FE_AÑO"].Value.ToString();
                    pldTo.FE_MES = dgw_recepcionado.CurrentRow.Cells["FE_MES"].Value.ToString();
                    DataTable dtDetalle = pldBLL.obtener_I_Planilla_Detalle_para_Aprobar_Recepcion_Planilla_BLL(pldTo);
                    decimal IMP_RECEPCION_CTA_CTE = dtDetalle.AsEnumerable().Sum(x => x.Field<decimal>("IMP_COB")) + dtDetalle.AsEnumerable().Sum(x => x.Field<decimal>("IMP_COB_CTA_CTE"));
                    plcTo.IMP_RECEPCION_CTA_CTE = IMP_RECEPCION_CTA_CTE;
                    decimal IMP_RECEPCION_DEV = dtDetalle.AsEnumerable().Sum(x => x.Field<decimal>("IMP_DEV"));
                    plcTo.IMP_RECEPCION_DEV = IMP_RECEPCION_DEV;
                    if (!plcBLL.Aprobar_Recepciona_PlanillaBLL(plcTo, dtDetalle, ref errMensaje))
                        MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        MessageBox.Show("La planilla se aprobó correctamente !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //TabControl1.SelectedTab = TabPage1;
                        //DATAGRID();
                        int i = dgw_recepcionado.CurrentRow.Index;
                        PLANILLAS_RECEPCIONADAS();
                        PENDIENTES_X_RECEPCIONAR();
                        dgw_recepcionado.CurrentCell = dgw_recepcionado[0, i];

                    }
                }
            }
        }
        private bool validaAprobar()
        {
            bool result = true;
            try
            {
                int num = dgw_recepcionado.CurrentRow.Index;
            }
            catch (Exception)
            {
                MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            //
            if (Convert.ToBoolean(dgw_recepcionado.CurrentRow.Cells["APROBAR_RECEPCIONADO"].Value))
            {
                MessageBox.Show("La Planilla " + dgw_recepcionado.CurrentRow.Cells["TIPO_PLANILLA"].Value.ToString() + " " + dgw_recepcionado.CurrentRow.Cells["NRO_PLANILLA_COB"].Value.ToString() + " ya está Aprobada !!!", "MESNAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return result = false;
            }
            //
            planillaDetalleBLL pldBLL = new planillaDetalleBLL();
            planillaDetalleTo pldTo = new planillaDetalleTo();
            int idx = dgw_recepcionado.CurrentRow.Index;
            pldTo.NRO_PLANILLA_COB = dgw_recepcionado.Rows[idx].Cells["NRO_PLANILLA_COB"].Value.ToString();
            pldTo.COD_INSTITUCION = dgw_recepcionado.Rows[idx].Cells["COD_INSTITUCION"].Value.ToString();
            pldTo.COD_PTO_COB_CONSOLIDADO = dgw_recepcionado.Rows[idx].Cells["COD_PTO_COB_CONSOLIDADO"].Value.ToString();
            pldTo.COD_CANAL_DSCTO = dgw_recepcionado.Rows[idx].Cells["COD_CANAL_DSCTO"].Value.ToString();
            pldTo.FE_AÑO = AÑO;
            pldTo.FE_MES = MES;
            DataTable dt = pldBLL.obtener_I_Planilla_Detalle_para_Recepcion_BLL(pldTo);
            foreach (DataRow rw in dt.Rows)
            {
                if (!Convert.ToBoolean(rw["OK"]))
                {
                    MessageBox.Show("Toda la columna OK debe de estar chequeda !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return result = false;
                }
            }
            return result;

        }
        private void creaRegistroExcesoContratoIndebido()
        {
            string contrato;
            contrato = DGW_DET.CurrentRow.Cells[0].Value.ToString();//.PadLeft(7, '0');
            DGW_DET.CurrentRow.Cells[0].Value = contrato;
            ccTo.NRO_PRESUPUESTO = contrato;
            DataTable dt = ccBLL.obtenerDatosDescuentoIndebidoxContratoBLL(ccTo);
            if (dt.Rows.Count > 0)
            {
                DGW_DET.CurrentRow.Cells[0].Value = dt.Rows[0]["NRO_PRESUPUESTO"].ToString();
                DGW_DET.CurrentRow.Cells[1].Value = dt.Rows[0]["COD_PER"].ToString();
                DGW_DET.CurrentRow.Cells[2].Value = dt.Rows[0]["DES_IDENTIDAD"].ToString().Trim();
                DGW_DET.CurrentRow.Cells[3].Value = dt.Rows[0]["DESC_PER"].ToString();
                DGW_DET.CurrentRow.Cells[4].Value = dt.Rows[0]["DNI"].ToString();
                DGW_DET.CurrentRow.Cells[5].Value = dt.Rows[0]["COD_DOC"].ToString();
                DGW_DET.CurrentRow.Cells[6].Value = "0000000";
                DGW_DET.CurrentRow.Cells[7].Value = dtp_generacion.Value;
                DGW_DET.CurrentRow.Cells[8].Value = "0.00";//dt.Rows[0]["IMP_DOC"].ToString();
                DGW_DET.CurrentRow.Cells[9].Value = "0.00"; //dt.Rows[0]["IMP_COB"].ToString();
                DGW_DET.CurrentRow.Cells[10].Value = "0.00";//dt.Rows[0]["IMP_COB_CTA_CTE"].ToString();
                DGW_DET.CurrentRow.Cells[11].Value = "0.00";//dt.Rows[0]["IMP_DEV"].ToString();
                DGW_DET.CurrentRow.Cells[12].Value = "**";//dt.Rows[0]["NRO_CUOTAS"].ToString().PadLeft(3, '0');
                DGW_DET.CurrentRow.Cells[13].Value = dt.Rows[0]["NRO_CUOTAS"].ToString().PadLeft(3, '0');
                DGW_DET.CurrentRow.Cells[14].Value = "006";//  EXCESO CONTRATO
                DGW_DET.CurrentRow.Cells[15].Value = "";
                DGW_DET.CurrentRow.Cells[17].Value = true;
                //DGW_DET.CurrentRow.Cells["NOM_MOTIVO_NO_DESCONTADO"].Value = dt.Rows[0]["NOM_MOTIVO_NO_DESCONTADO"].ToString();
                DGW_DET.CurrentRow.Cells["DES_PROCESO"].Value = dt.Rows[0]["DES_PROCESO"].ToString();
                DGW_DET.CurrentRow.Cells["CATEGORIA_MOTIVOS_PLANILLA"].Value = "03";
                DGW_DET.CurrentRow.Cells[9].Selected = true;
                DGW_DET.BeginEdit(true);
            }
            else
            {
                DGW_DET.CurrentRow.Cells[0].Value = "";
                DGW_DET.CurrentRow.Cells[1].Value = "";
                DGW_DET.CurrentRow.Cells[2].Value = "";
                DGW_DET.CurrentRow.Cells[3].Value = "";
                DGW_DET.CurrentRow.Cells[4].Value = "";
                DGW_DET.CurrentRow.Cells[5].Value = "";
                DGW_DET.CurrentRow.Cells[6].Value = "0000000";
                DGW_DET.CurrentRow.Cells[7].Value = dtp_generacion.Value;
                DGW_DET.CurrentRow.Cells[8].Value = "0.00";//dt.Rows[0]["IMP_DOC"].ToString();
                DGW_DET.CurrentRow.Cells[9].Value = "0.00"; //dt.Rows[0]["IMP_COB"].ToString();
                DGW_DET.CurrentRow.Cells[10].Value = "0.00";//dt.Rows[0]["IMP_COB_CTA_CTE"].ToString();
                DGW_DET.CurrentRow.Cells[11].Value = "0.00";//dt.Rows[0]["IMP_DEV"].ToString();
                DGW_DET.CurrentRow.Cells[12].Value = "000";
                DGW_DET.CurrentRow.Cells[13].Value = "000";
                DGW_DET.CurrentRow.Cells[14].Value = "005";//descuento indebido
                DGW_DET.CurrentRow.Cells[15].Value = "";
                DGW_DET.CurrentRow.Cells[17].Value = true;
                //DGW_DET.CurrentRow.Cells["NOM_MOTIVO_NO_DESCONTADO"].Value = dt.Rows[0]["NOM_MOTIVO_NO_DESCONTADO"].ToString();
                DGW_DET.CurrentRow.Cells["DES_PROCESO"].Value = "";
                DGW_DET.CurrentRow.Cells["CATEGORIA_MOTIVOS_PLANILLA"].Value = "03";
                DGW_DET.CurrentRow.Cells[3].Selected = true;
                DGW_DET.BeginEdit(true);
            }
        }
        private void creaRegistroSuspendido()
        {
            string contrato;
            contrato = DGW_DET.CurrentRow.Cells[0].Value.ToString();//.PadLeft(7, '0');
            DGW_DET.CurrentRow.Cells[0].Value = contrato;
            //ccTo.NRO_PRESUPUESTO = contrato;
            //DataTable dt = ccBLL.obtenerDatosDescuentoIndebidoxContratoBLL(ccTo);

            //canjePCtasxCobrarBLL pccBLL = new canjePCtasxCobrarBLL();
            //canjePCtasxCobrarTo pccTo = new canjePCtasxCobrarTo();
            pctaTo.COD_SUCURSAL = cbo_sucursal.SelectedValue.ToString();
            pctaTo.COD_CLASE = dgw1.CurrentRow != null ? dgw1.CurrentRow.Cells["COD_CLASE"].Value.ToString() : dgw_recepcionado.CurrentRow.Cells["COD_CLASE"].Value.ToString();
            pctaTo.NRO_CONTRATO = DGW_DET.CurrentRow.Cells[0].Value.ToString();
            pctaTo.COMPROMETIDO = false;
            DataTable dt = pctaBLL.obtenerCuotasPendientesxContratoSuspendidoBLL(pctaTo);
            if (dt.Rows.Count > 0)
            {
                DGW_DET.CurrentRow.Cells[0].Value = dt.Rows[0]["NRO_PRESUPUESTO"].ToString();
                DGW_DET.CurrentRow.Cells[1].Value = dt.Rows[0]["COD_PER"].ToString();
                DGW_DET.CurrentRow.Cells[2].Value = dt.Rows[0]["DES_IDENTIDAD"].ToString().Trim();
                DGW_DET.CurrentRow.Cells[3].Value = dt.Rows[0]["DESC_PER"].ToString();
                DGW_DET.CurrentRow.Cells[4].Value = dt.Rows[0]["DNI"].ToString();
                DGW_DET.CurrentRow.Cells[5].Value = dt.Rows[0]["COD_DOC"].ToString();
                DGW_DET.CurrentRow.Cells[6].Value = dt.Rows[0]["NRO_DOC"].ToString();
                DGW_DET.CurrentRow.Cells[7].Value = dt.Rows[0]["FECHA_VEN"].ToString().Substring(0, 10);
                DGW_DET.CurrentRow.Cells[8].Value = "0.00";//dt.Rows[0]["IMP_DOC"].ToString();
                DGW_DET.CurrentRow.Cells[9].Value = "0.00";//dt.Rows[0]["SALDO"].ToString();
                DGW_DET.CurrentRow.Cells[10].Value = dt.Rows[0]["SALDO"].ToString();//"0.00";//dt.Rows[0]["IMP_COB_CTA_CTE"].ToString();
                DGW_DET.CurrentRow.Cells[11].Value = "0.00";//dt.Rows[0]["IMP_DEV"].ToString();
                DGW_DET.CurrentRow.Cells[12].Value = dt.Rows[0]["NRO_LETRA"].ToString().PadLeft(3, '0');
                DGW_DET.CurrentRow.Cells[13].Value = dt.Rows[0]["TOTAL_LETRA"].ToString().PadLeft(3, '0');
                DGW_DET.CurrentRow.Cells[14].Value = "007";//CONTRATO SUSPENDIDO X DEVOLVER ó APLICAR---  EXCESO CUOTA X DEVOLVER ó APLICAR
                DGW_DET.CurrentRow.Cells[15].Value = "";
                DGW_DET.CurrentRow.Cells[17].Value = true;
                //DGW_DET.CurrentRow.Cells["NOM_MOTIVO_NO_DESCONTADO"].Value = dt.Rows[0]["NOM_MOTIVO_NO_DESCONTADO"].ToString();
                DGW_DET.CurrentRow.Cells["DES_PROCESO"].Value = dt.Rows[0]["DES_PROCESO"].ToString();
                DGW_DET.CurrentRow.Cells["CATEGORIA_MOTIVOS_PLANILLA"].Value = "03";
                DGW_DET.CurrentRow.Cells[9].Selected = true;
                DGW_DET.BeginEdit(true);
            }
        }
        private void DGW_DET_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //-------------------por el momento esta bien así pero hay que ver las validaciones
            if (e.ColumnIndex == 0)
            {
                if (OP == "IND/EXC")
                    creaRegistroExcesoContratoIndebido();
                else if (OP == "SUSPENDIDO")
                    creaRegistroSuspendido();
            }
            else if (e.ColumnIndex == 3)
            {
                DGW_DET.CurrentRow.Cells[9].Selected = true;
                DGW_DET.BeginEdit(true);
                //if (DGW_DET.CurrentRow.Cells[14].Value.ToString() == "005" || DGW_DET.CurrentRow.Cells[14].Value.ToString() == "006")
                //{
                //    DGW_DET.CurrentRow.Cells[11].Selected = true;
                //    DGW_DET.BeginEdit(true);
                //}
            }
            else if (e.ColumnIndex == 9 || e.ColumnIndex == 10 || e.ColumnIndex == 11)
            {
                if (DGW_DET.CurrentRow.Cells[14].Value.ToString() == "005" || DGW_DET.CurrentRow.Cells[14].Value.ToString() == "006")
                {
                    DGW_DET.CurrentRow.Cells[11].Value = DGW_DET.CurrentRow.Cells[9].Value;
                }
                else if (DGW_DET.CurrentRow.Cells[14].Value.ToString() == "004" || DGW_DET.CurrentRow.Cells[14].Value.ToString() == "007")
                {
                    DGW_DET.CurrentRow.Cells[10].Value = DGW_DET.CurrentRow.Cells[9].Value;
                    if (DGW_DET.CurrentRow.Cells[14].Value.ToString() == "007")
                        DGW_DET.CurrentRow.Cells[9].Value = "0.00";
                }
                HALLAR_TOTALES();
            }
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            OP = "SUSPENDIDO";
            agregar_Cuota_Indebida_ExcContrato();
        }

        private bool validaRetornoPendientes()
        {
            bool result = true;
            if (dgw1.Rows.Count <= 0)
            {
                MessageBox.Show("No hay registros !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return result = false;
            }
            try
            {
                int num = dgw1.CurrentRow.Index;
            }
            catch (Exception)
            {
                MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            return result;
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (!validaElimina()) ///hay que revisar las validaciones,lo comento para que pase nomas
                return;
            DialogResult rs = MessageBox.Show("¿ Esta seguro de eliminar registro con Contrato " + DGW_DET.CurrentRow.Cells[0].Value.ToString() +
                                            " y N° Letra" + DGW_DET.CurrentRow.Cells[12].Value.ToString() + " ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                DGW_DET.Rows.RemoveAt(DGW_DET.CurrentRow.Index);
                HALLAR_TOTALES();
            }
        }
        private bool validaElimina()
        {
            bool result = true;
            if (DGW_DET.Rows.Count <= 0)
            {
                MessageBox.Show("No se existen registros que eliminar !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return result = false;
            }
            if (Convert.ToDecimal(DGW_DET.CurrentRow.Cells[8].Value) != 0)
            {
                MessageBox.Show("No se puede eliminar este registro pues se envió en el archivo de la Planilla !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return result = false;
            }
            return result;
        }

        private void chk_recepcionado_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_recepcionado.Checked)
            {
                Panel4.Enabled = true;
                foreach (DataGridViewRow row in DGW_DET.Rows)
                {
                    row.Cells[9].Value = "0.00";
                    row.Cells[17].Value = false;
                }
            }
            else
            {
                Panel4.Enabled = false;
                foreach (DataGridViewRow row in DGW_DET.Rows)
                {
                    row.Cells[9].Value = row.Cells[8].Value;
                    row.Cells[17].Value = true;
                }
            }
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            //if (dgw_recepcionado.Rows.Count >= 0)
            //{
            BOTON = "NUEVO";
            btn_Imprimir.Enabled = false;
            TabControl1.SelectedTab = TabPage1;
            LIMPIAR_CABECERA();
            gc_recepcionado.Enabled = true;
            Panel4.Enabled = true;
            btn_eliminar.Enabled = true;
            btn_agregarCuota.Enabled = true;
            btn_editar.Enabled = true;
            btn_Imprimir.Enabled = true;
            btnCargar.Enabled = true;
            btn_cancelar.Enabled = true;
            //}
        }

        private void btn_procesar_planilla_Click(object sender, EventArgs e)
        {
            if (dgw1.Rows.Count > 0)
            {
                LIMPIAR_CABECERA();
                DGW_DET.Rows.Clear();
                CARGAR_CABECERA(dgw1);
                CARGAR_DETALLE(dgw1, 1);
                Panel4.Enabled = true;
                gc_recepcionado.Enabled = true;
                chk_recepcionado.Checked = true;
                DGW_DET.Columns[14].ReadOnly = false;
                DGW_DET.Columns[17].ReadOnly = false;
                TabControl1.SelectedTab = TabPage2;
            }
        }

        private void btn_cancelar1_Click(object sender, EventArgs e)
        {
            TabControl1.SelectedTab = TabPage3;
        }

        private void btn_Imprimir_Click(object sender, EventArgs e)
        {
            if (DGW_DET.Rows.Count > 0)
            {
                //Modifique el procedimiento almacenado pues se usa tambien en otro lado, ver si eso trae consequencias aquí.
                List<planillaDetalleTo> pll = new List<planillaDetalleTo>();
                foreach (DataGridViewRow row in DGW_DET.Rows)
                {
                    planillaDetalleTo pld = new planillaDetalleTo();
                    pld.NRO_CONTRATO = row.Cells[0].Value.ToString();
                    //pld.FECHA_CONTRATO = Convert.ToDateTime(row.Cells["FECHA_PRE"].Value);
                    pld.CLIENTE = row.Cells[3].Value.ToString();
                    pld.DESC_IDENTIDAD = row.Cells[2].Value.ToString();
                    //pld.DNI = row.Cells[4].Value.ToString();
                    pld.DES_PROCESO = row.Cells["DES_PROCESO"].Value.ToString();
                    pld.IMP_COB = Convert.ToDecimal(row.Cells[9].Value);
                    pld.NRO_LETRA = row.Cells[12].Value.ToString() + "/" + row.Cells[13].Value.ToString();
                    pld.NOM_MOTIVO_NO_DESCONTADO = "xxx DESCONTADOS xxx";
                    pll.Add(pld);
                    if (Convert.ToDecimal(row.Cells[8].Value) != (Convert.ToDecimal(row.Cells[9].Value) + Convert.ToDecimal(row.Cells[11].Value)))
                    {
                        planillaDetalleTo pld2 = new planillaDetalleTo();
                        pld2.NRO_CONTRATO = row.Cells[0].Value.ToString();
                        //pld.FECHA_CONTRATO = Convert.ToDateTime(row.Cells["FECHA_PRE"].Value);
                        pld2.CLIENTE = row.Cells[3].Value.ToString();
                        pld2.DESC_IDENTIDAD = row.Cells[2].Value.ToString();
                        //pld.DNI = row.Cells[4].Value.ToString();
                        pld2.DES_PROCESO = row.Cells["DES_PROCESO"].Value.ToString();
                        pld2.IMP_COB = Convert.ToDecimal(row.Cells[8].Value) - (Convert.ToDecimal(row.Cells[9].Value) + Convert.ToDecimal(row.Cells[11].Value));
                        pld2.NRO_LETRA = row.Cells[12].Value.ToString() + "/" + row.Cells[13].Value.ToString();
                        pld2.NOM_MOTIVO_NO_DESCONTADO = row.Cells["NOM_MOTIVO_NO_DESCONTADO"].Value.ToString();
                        pll.Add(pld2);
                    }
                }

                Reportes.FormRep.REP_COBRANZA_INTERNA_EJECUTADA frm = new Reportes.FormRep.REP_COBRANZA_INTERNA_EJECUTADA();
                frm.nro_planilla = txt_ser.Text + "-" + txt_num.Text;
                frm.fec_planilla = dtp_generacion.Value.ToShortDateString();
                frm.pto_cob_consolidado = cbo_ptoCobranza.Text;
                frm.imp_enviado = txt_totimp.Text;
                //frm.imp_no_descontado = (Convert.ToDecimal(txt_totimp.Text) - Convert.ToDecimal(txt_tot_imp_rec.Text)).ToString();
                frm.imp_no_descontado = (Convert.ToDecimal(txt_totimp.Text) - sum_rec).ToString();//se elimino el textbox para ponerlo en el formulario de detalle de los subtotales
                frm.lstpll = pll;
                frm.Show();
            }
        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            if (dgw_recepcionado.Rows.Count > 0)
            {
                if (!validaModificar())
                    return;
                BOTON = "MODIFICAR";

                btn_Imprimir.Enabled = true;
                TabControl1.SelectedTab = TabPage2;
                LIMPIAR_CABECERA();
                DGW_DET.Rows.Clear();
                DGW_DET.Enabled = true;
                CARGAR_CABECERA(dgw_recepcionado);
                CARGAR_DETALLE(dgw_recepcionado, 2);//1 para los que ya se han recepcionado antes
                HALLAR_TOTALES();
                HALLAR_NRO_CONTRATOS();
                Panel4.Enabled = false;
                gc_recepcionado.Enabled = false;
                btn_eliminar.Enabled = true;
                btn_agregarCuota.Enabled = true;
                btn_editar.Enabled = true;
                btn_Imprimir.Enabled = true;
                btnCargar.Enabled = true;
                btn_cancelar.Enabled = true;
                DGW_DET.Columns[9].ReadOnly = false;
                DGW_DET.Columns[14].ReadOnly = false;
                DGW_DET.Columns[17].ReadOnly = false;
                btn_Imprimir.Focus();
            }
        }
        private bool validaModificar()
        {
            bool result = true;
            try
            {
                int num = dgw_recepcionado.CurrentRow.Index;
            }
            catch (Exception)
            {
                MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            //
            if (Convert.ToBoolean(dgw_recepcionado.CurrentRow.Cells["APROBAR_RECEPCIONADO"].Value))
            {
                MessageBox.Show("La planilla Nº " + dgw_recepcionado.CurrentRow.Cells[0].Value.ToString() + " ya está Aprobada !!!", "MESNAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return result = false;
            }
            return result;
        }

        private void btn_retornar_pendientes_Click(object sender, EventArgs e)
        {
            if (!validaRetornoPendientes())
                return;

            personaBLL perBLL = new personaBLL();
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
                    int idx = dgw1.CurrentRow.Index;
                    plcTo.NRO_PLANILLA_COB = dgw1.Rows[idx].Cells["NRO_PLANILLA_COB"].Value.ToString();
                    plcTo.COD_INSTITUCION = dgw1.Rows[idx].Cells["COD_INSTITUCION"].Value.ToString();
                    plcTo.COD_PTO_COB_CONSOLIDADO = dgw1.Rows[idx].Cells["COD_PTO_COB_CONSOLIDADO"].Value.ToString();
                    plcTo.COD_CANAL_DSCTO = dgw1.Rows[idx].Cells["COD_CANAL_DSCTO"].Value.ToString();
                    plcTo.FE_AÑO = dgw1.Rows[idx].Cells["FE_AÑO"].Value.ToString();
                    plcTo.FE_MES = dgw1.Rows[idx].Cells["FE_MES"].Value.ToString();

                    if (!plcBLL.Retornar_a_Generacion_BLL(plcTo, ref errMensaje))
                        MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        MessageBox.Show("La planilla se retornó correctamente !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TabControl1.SelectedTab = TabPage1;
                        //DATAGRID();
                        PLANILLAS_RECEPCIONADAS();
                        PENDIENTES_X_RECEPCIONAR();
                    }

                }
                else
                    MessageBox.Show("USTED NO TIENE PERMISOS !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void DGW_DET_CONSOLIDADO_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8)
            {
                if (DGW_DET_CONSOLIDADO.CurrentRow != null)
                {
                    if (Convert.ToBoolean(DGW_DET_CONSOLIDADO.CurrentRow.Cells["X"].Value))
                    {
                        //operaciones de distribucion
                        hacerOperaciondeDistribucion();
                    }
                    else
                    {
                        //quitar del grid DGW_DET 
                        eliminarRegistros();
                        DGW_DET_CONSOLIDADO.CurrentRow.Cells["IMP_COB_Cab"].Value = Convert.ToDecimal(DGW_DET_CONSOLIDADO.CurrentRow.Cells["IMP_DOC_Cab"].Value);
                        DataRow[] row = dtPlanillaEnviada.Select("NRO_CONTRATO = '" + DGW_DET_CONSOLIDADO.CurrentRow.Cells["NRO_CONTRATO_Cab"].Value.ToString() + "' AND IMP_DOC = 0");
                        foreach (DataRow rw in row)
                        {
                            dtPlanillaEnviada.Rows.Remove(rw);
                        }
                    }
                }
            }
        }
        private void eliminarRegistros()
        {
            //elimina los registros que ya se encuentran en el grid de Generacion de Planillas           
            for (int j = DGW_DET.Rows.Count - 1; j >= 0; j--)
            {
                if (DGW_DET_CONSOLIDADO.CurrentRow.Cells["NRO_CONTRATO_Cab"].Value.ToString() == DGW_DET.Rows[j].Cells[0].Value.ToString())
                {
                    DGW_DET.Rows.Remove(DGW_DET.Rows[j]);
                }
            }
            HALLAR_TOTALES();
        }
        private void hacerOperaciondeDistribucion()
        {
            decimal imp_rec = 0;
            dtPlanillaContrato.Rows.Clear();
            DataRow[] ro = dtPlanillaEnviada.Select("NRO_CONTRATO = '" + DGW_DET_CONSOLIDADO.CurrentRow.Cells["NRO_CONTRATO_Cab"].Value.ToString() + " '");
            foreach (DataRow rw in ro)
                dtPlanillaContrato.ImportRow(rw);
            imp_rec = Convert.ToDecimal(DGW_DET_CONSOLIDADO.CurrentRow.Cells["IMP_COB_Cab"].Value);
            dtPlanillaContrato.Columns["IMP_COB"].ReadOnly = false;
            dtPlanillaContrato.Columns["COD_MOTIVO_NO_DESCONTADO"].ReadOnly = false;
            dtPlanillaContrato.Columns["CATEGORIA_MOTIVOS_PLANILLA"].ReadOnly = false;
            dtPlanillaContrato.Columns["IMP_COB_CTA_CTE"].ReadOnly = false;
            dtPlanillaContrato.Columns["IMP_DEV"].ReadOnly = false;
            //foreach(DataRow rw in dtPlanillaContrato.Rows)
            for (int i = 0; i < dtPlanillaContrato.Rows.Count; i++)
            {
                dtPlanillaContrato.Rows[i]["IMP_DEV"] = "0.00";
                dtPlanillaContrato.Rows[i]["IMP_COB_CTA_CTE"] = "0.00";
                dtPlanillaContrato.Rows[i]["COD_MOTIVO_NO_DESCONTADO"] = "";
                if (imp_rec == 0)
                {
                    dtPlanillaContrato.Rows[i]["IMP_COB"] = imp_rec;
                    dtPlanillaContrato.Rows[i][14] = "003";
                    dtPlanillaContrato.Rows[i]["CATEGORIA_MOTIVOS_PLANILLA"] = "01";
                }
                else if (imp_rec >= Convert.ToDecimal(dtPlanillaContrato.Rows[i]["IMP_DOC"]))
                {
                    dtPlanillaContrato.Rows[i]["IMP_COB"] = dtPlanillaContrato.Rows[i]["IMP_DOC"];
                    imp_rec -= Convert.ToDecimal(dtPlanillaContrato.Rows[i]["IMP_DOC"]);
                    //
                    if (i == (dtPlanillaContrato.Rows.Count - 1))
                    {
                        if (imp_rec > 0)
                        {
                            if (dtPlanillaContrato.Rows[i][12].ToString() == dtPlanillaContrato.Rows[i][13].ToString())
                            {
                                bool estaComprometida = false;
                                //se revisa si tiene cuota comprometidas anteriores
                                pctaTo.NRO_CONTRATO = DGW_DET_CONSOLIDADO.CurrentRow.Cells[0].Value.ToString();
                                pctaTo.NRO_PLANILLA = txt_ser.Text + "-" + txt_num.Text;
                                DataTable dtCuotasComprometidasContrato = pctaBLL.obtenerCuotasComprometidasContratoBLL(pctaTo);
                                if (dtCuotasComprometidasContrato.Rows.Count > 0)
                                {
                                    foreach (DataRow rw in dtCuotasComprometidasContrato.Rows)
                                    {
                                        if (Convert.ToInt32(dtPlanillaContrato.Rows[i]["NRO_LETRA"]) > Convert.ToInt32(rw["NRO_LETRA"]))
                                        {
                                            //exceso cuota
                                            estaComprometida = true;
                                            dtPlanillaContrato.Rows[i]["IMP_COB_CTA_CTE"] = imp_rec;//
                                            dtPlanillaContrato.Rows[i][14] = "004";//exceso cuota
                                            dtPlanillaContrato.Rows[i]["CATEGORIA_MOTIVOS_PLANILLA"] = "03";
                                            MessageBox.Show("El contrato " + dtPlanillaContrato.Rows[i]["NRO_CONTRATO"].ToString() + " del Sr(a) " + DGW_DET_CONSOLIDADO.CurrentRow.Cells["DESC_PER_Cab"].Value.ToString() + " \ntiene cuotas comprometidas y ha llegado a la última cuota.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                            break;
                                        }
                                    }
                                    //exceso contrato
                                    if (!estaComprometida)
                                    {
                                        creaRegistroExcesoContrato(i, imp_rec);
                                        break;
                                    }
                                }
                                else
                                {
                                    creaRegistroExcesoContrato(i, imp_rec);
                                    break;
                                }
                            }
                            else
                            {
                                //exceso cuota
                                dtPlanillaContrato.Rows[i]["IMP_COB_CTA_CTE"] = imp_rec;//
                                dtPlanillaContrato.Rows[i][14] = "004";//exceso cuota
                                dtPlanillaContrato.Rows[i]["CATEGORIA_MOTIVOS_PLANILLA"] = "03";
                            }
                        }
                    }
                }
                else
                {
                    dtPlanillaContrato.Rows[i]["IMP_COB"] = imp_rec;
                    dtPlanillaContrato.Rows[i][14] = "001";//descuento en partes
                    dtPlanillaContrato.Rows[i]["CATEGORIA_MOTIVOS_PLANILLA"] = "01";
                    imp_rec = 0;
                }
            }
            foreach (DataRow rw in dtPlanillaContrato.Rows)
            {
                int rowId = DGW_DET.Rows.Add();
                DataGridViewRow row = DGW_DET.Rows[rowId];
                row.Cells[0].Value = rw["NRO_CONTRATO"].ToString();
                row.Cells[1].Value = rw["COD_PER"].ToString();
                row.Cells[2].Value = rw["DES_IDENTIDAD"].ToString().Trim();
                row.Cells[3].Value = rw["DESC_PER"].ToString();
                row.Cells[4].Value = rw["DNI"].ToString();
                row.Cells[5].Value = rw["COD_DOC"].ToString();
                row.Cells[6].Value = rw["NRO_DOC"].ToString().Trim();
                row.Cells[7].Value = rw["FECHA_VEN"].ToString() == "" ? "" : rw["FECHA_VEN"].ToString().Substring(0, 10);
                row.Cells[8].Value = rw["IMP_DOC"].ToString();
                row.Cells[9].Value = rw["IMP_COB"].ToString();
                row.Cells[10].Value = rw["IMP_COB_CTA_CTE"].ToString();
                row.Cells[11].Value = rw["IMP_DEV"].ToString();
                row.Cells[12].Value = rw["NRO_LETRA"].ToString();
                row.Cells[13].Value = rw["TOT_LETRA"].ToString();
                row.Cells[14].Value = rw["COD_MOTIVO_NO_DESCONTADO"];
                row.Cells[15].Value = rw["OBSERVACION"].ToString();
                row.Cells[17].Value = true;//Convert.ToBoolean(rw["OK"]);
                row.Cells["NOM_MOTIVO_NO_DESCONTADO"].Value = rw["NOM_MOTIVO_NO_DESCONTADO"].ToString();
                row.Cells["DES_PROCESO"].Value = rw["DES_PROCESO"].ToString();
                row.Cells["CATEGORIA_MOTIVOS_PLANILLA"].Value = rw["CATEGORIA_MOTIVOS_PLANILLA"].ToString();
            }
            HALLAR_TOTALES();
        }
        private void creaRegistroExcesoContrato(int i, decimal imp)
        {
            DataRow rw = dtPlanillaContrato.NewRow();
            rw["NRO_CONTRATO"] = dtPlanillaContrato.Rows[i]["NRO_CONTRATO"].ToString();
            rw["COD_PER"] = dtPlanillaContrato.Rows[i]["COD_PER"].ToString();
            rw["DES_IDENTIDAD"] = dtPlanillaContrato.Rows[i]["DES_IDENTIDAD"].ToString();
            rw["DESC_PER"] = dtPlanillaContrato.Rows[i]["DESC_PER"].ToString();
            rw["DNI"] = dtPlanillaContrato.Rows[i]["DNI"].ToString();
            rw["COD_DOC"] = dtPlanillaContrato.Rows[i]["COD_DOC"].ToString();
            rw["NRO_DOC"] = "0000000";
            rw["FECHA_VEN"] = DateTime.Now.ToShortDateString();
            rw["IMP_DOC"] = "0.00";
            rw["IMP_COB"] = imp;
            rw["IMP_COB_CTA_CTE"] = "0.00";
            rw["IMP_DEV"] = imp;
            rw["NRO_LETRA"] = "**";
            rw["TOT_LETRA"] = dtPlanillaContrato.Rows[i]["TOT_LETRA"].ToString();
            rw["COD_MOTIVO_NO_DESCONTADO"] = "006";//exceso contrato
            rw["OBSERVACION"] = "";
            rw["COD_PTO_COB"] = dtPlanillaContrato.Rows[i]["COD_PTO_COB"].ToString();
            rw["OK"] = true;
            rw["NOM_MOTIVO_NO_DESCONTADO"] = dtPlanillaContrato.Rows[i]["NOM_MOTIVO_NO_DESCONTADO"].ToString();
            rw["DES_PROCESO"] = dtPlanillaContrato.Rows[i]["DES_PROCESO"].ToString();
            rw["CATEGORIA_MOTIVOS_PLANILLA"] = "03";
            dtPlanillaContrato.Rows.Add(rw);

        }
        private void INSERTAR_NUEVA_CUOTA(DataTable dt, decimal importe, string nro_letra)
        {
            int idx = DGW_DET.Rows[DGW_DET.Rows.Count - 1].Index;
            //DataTable dt = dt1.Clone();
            decimal imp = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (importe > 0)
                {
                    if (Convert.ToInt32(nro_letra) < Convert.ToInt32(dt.Rows[i]["NRO_LETRA"]))
                    {
                        if (importe >= Convert.ToDecimal(dt.Rows[i]["SAL_IMP"]))
                        {
                            imp = Convert.ToDecimal(dt.Rows[i]["SAL_IMP"]);
                            importe -= imp;
                        }
                        else
                        {
                            imp = importe;
                            importe = 0;
                        }
                        DGW_DET.CurrentRow.Cells[10].Value = "0.00";
                        DGW_DET.Rows.Insert(idx + 1, DGW_DET[0, idx].Value.ToString(), DGW_DET[1, idx].Value.ToString(), DGW_DET[2, idx].Value.ToString(),
                            DGW_DET[3, idx].Value.ToString(), DGW_DET[4, idx].Value.ToString(), dt.Rows[i][0].ToString(),
                            dt.Rows[i][1].ToString().Trim(), dt.Rows[i][2].ToString().Substring(0, 10),
                            "0.00",//Convert.ToDecimal(OFR.DGW_CAB[3, i].Value) >= ctacte ? ctacte.ToString() : OFR.DGW_CAB[3, i].Value.ToString(),//OFR.DGW_CAB[3, i].Value.ToString(),
                                   //Convert.ToDecimal(dt.Rows[i][4]) >= ctacte ? ctacte.ToString() : dt.Rows[i][4].ToString(),
                            imp,
                            //Convert.ToDecimal(dt.Rows[i][4]) >= ctacte ? "0.00" : (ctacte - Convert.ToDecimal(dt.Rows[i][4])).ToString(),
                            imp,
                            "0.00", dt.Rows[i][5].ToString(), dt.Rows[i][6].ToString(), "001", "",//003 es COD_MOTIVO_DESCUENTO
                            dt.Rows[i][8].ToString(), false);
                        //importe -= Convert.ToDecimal(DGW_DET[9, idx].Value);
                        idx++;
                        //DGW_DET.Rows[idx + i].Selected = true;
                    }
                }
            }
            if (importe > 0)
            {
                DGW_DET.Rows[idx].Cells[11].Value = importe;
            }
        }
        private void DGW_DET_CONSOLIDADO_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (DGW_DET_CONSOLIDADO.IsCurrentCellDirty)
            {
                DGW_DET_CONSOLIDADO.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void btn_ver_Click(object sender, EventArgs e)
        {
            MOD_CXC.frm_Consulta_TotalxCobrar_Recepcion_Planilla_Descuento frm = new frm_Consulta_TotalxCobrar_Recepcion_Planilla_Descuento(sum_rec, sum_cta_cte, sum_indebido, sum_exceso_contrato);
            frm.Show();
        }

        private void cbo_tipo_planilla_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_tipo_planilla.SelectedValue != null)
                lbl_cod_tipo_plla.Text = cbo_tipo_planilla.SelectedValue.ToString();
        }

        private void DGW_DET_CONSOLIDADO_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                if (!validaCeldasGrid(e.FormattedValue.ToString(), true))
                {
                    //cuando le das a ESCAPE toma este valor, el de la columna 6
                    DGW_DET_CONSOLIDADO.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = DGW_DET_CONSOLIDADO.Rows[e.RowIndex].Cells["IMP_DOC_Cab"].Value;// col 6
                    e.Cancel = true;
                }
                DataGridViewCell cell = DGW_DET_CONSOLIDADO.Rows[e.RowIndex].Cells[e.ColumnIndex];
                DGW_DET_CONSOLIDADO.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = string.Format("{0:###,###,##0.00}", Convert.ToDecimal(cell.Value));
            }
        }
        private bool validaCeldasGrid(string valor, bool incluyeCero)
        {
            bool result = true;
            if (!HelpersBLL.esNumeroDecimal(valor, incluyeCero))
            {
                MessageBox.Show("Cantidad no válida !!!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return result = false;
            }
            return result;
        }

        private void DGW_DET_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 9)
            {
                bool incluyeCero = true;
                //if (DGW_DET.CurrentRow.Cells[14].Value.ToString() == "007")
                //    incluyeCero = false;
                if (!validaCeldasGrid(e.FormattedValue.ToString(), incluyeCero))
                {
                    //cuando le das a ESCAPE toma este valor, el de la columna 6
                    //DGW_DET_CONSOLIDADO.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = DGW_DET_CONSOLIDADO.Rows[e.RowIndex].Cells["IMP_DOC_Cab"].Value;// col 6
                    e.Cancel = true;
                }
                DataGridViewCell cell = DGW_DET.Rows[e.RowIndex].Cells[e.ColumnIndex];
                DGW_DET.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = string.Format("{0:###,###,##0.00}", Convert.ToDecimal(cell.Value));
            }
        }
    }
}
