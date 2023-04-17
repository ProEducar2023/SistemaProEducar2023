using BLL;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;

namespace Presentacion.MOD_CXC
{
    public partial class CANCELACION_I_PLANILLA : Form
    {
        string AÑO = "", MES = "", COD_MOD = "", COD_USU = "", TIPO_USU = "";
        DateTime FECHA_INI, FECHA_GRAL;
        planillaCabeceraBLL plcBLL = new planillaCabeceraBLL();
        planillaCabeceraTo plcTo = new planillaCabeceraTo();

        public CANCELACION_I_PLANILLA(string AÑO, string MES, DateTime FECHA_INI, DateTime FECHA_GRAL, string COD_MOD, string TIPO_USU, string COD_USU)
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

        private void CANCELACION_I_PLANILLA_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            DATAGRID();
            CARGAR_SUCURSAL();
            CARGAR_CANAL_DSCTO();
            CARGAR_INSTITUCIONES();
            CARGAR_PTO_COBRANZA_CONSOLIDADO();
            //CARGAR_SECTORISTA();
            INICIAR_CABECERA_GRID_DETALLE();
            CARGAR_TIPO_PLANILLA();
            //CARGAR_FORMATOS();
        }

        private void CANCELACION_I_PLANILLA_KeyDown(object sender, KeyEventArgs e)
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
        private void DATAGRID()
        {
            plcTo.FE_AÑO = AÑO;//ESTO NO SE USA PORQUE LA FECHA ACTUAL AÑO Y MES PUEDEN NO SERLOS DE LOS DE LA TABLA EN PROCESO
            plcTo.FE_MES = MES;
            DataTable dt = plcBLL.obtener_Cancelacion_R_Planilla_Cabecera_BLL(plcTo);
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
                dgw1.Columns["DESC_PTO_COB"].HeaderText = "Punto Cobranza Consolidado";
                dgw1.Columns["DESC_PTO_COB"].Width = 240;
                dgw1.Columns["DESC_PTO_COB1"].HeaderText = "Punto Cobranza";
                dgw1.Columns["DESC_PTO_COB1"].Width = 240;
                dgw1.Columns["FECHA_RECEPCION"].HeaderText = "Fec Recep";
                dgw1.Columns["FECHA_RECEPCION"].Width = 70;
                dgw1.Columns["FECHA_RECEPCION"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgw1.Columns["IMP_RECEPCION_DOC"].HeaderText = "Imp Rec";
                dgw1.Columns["IMP_RECEPCION_DOC"].Width = 70;
                dgw1.Columns["IMP_RECEPCION_DOC"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //dgw1.Columns["IMP_RECEPCION_DEV"].HeaderText = "Dev";
                //dgw1.Columns["IMP_RECEPCION_DEV"].Width = 70;
                //dgw1.Columns["IMP_RECEPCION_DEV"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgw1.Columns["COD_SUCURSAL"].Visible = false;
                dgw1.Columns["COD_INSTITUCION"].Visible = false;
                dgw1.Columns["COD_PTO_COB_CONSOLIDADO"].Visible = false;
                dgw1.Columns["COD_PTO_COB"].Visible = false;
                dgw1.Columns["COD_CANAL_DSCTO"].Visible = false;
                dgw1.Columns["COD_SECTORISTA"].Visible = false;
                dgw1.Columns["OBSERVACION"].Visible = false;
                dgw1.Columns["FECHA_VEN_AL"].Visible = false;
                //dgw1.Columns["TIPO_PLANILLA"].Visible = false;
                dgw1.Columns["IMP_RECEPCION_DEV"].Visible = false;
                dgw1.Columns["COD_COBRADOR"].Visible = false;
                dgw1.Columns["STATUS_APROB"].HeaderText = "Aprob";
                dgw1.Columns["STATUS_APROB"].Width = 50;
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
            DGW_DET.Columns[0].HeaderText = "Nª Contrato";
            DGW_DET.Columns[0].Width = 80;
            DGW_DET.Columns[0].ReadOnly = true;
            DGW_DET.Columns[1].HeaderText = "Codigo";
            DGW_DET.Columns[1].Width = 60;
            DGW_DET.Columns[1].ReadOnly = true;
            DGW_DET.Columns[2].HeaderText = "Cod Id";
            DGW_DET.Columns[2].Width = 80;
            DGW_DET.Columns[2].ReadOnly = true;
            DGW_DET.Columns[3].HeaderText = "Nombre Cliente";
            DGW_DET.Columns[3].Width = 240;
            DGW_DET.Columns[3].ReadOnly = true;
            DGW_DET.Columns[4].HeaderText = "DNI/Ruc";
            DGW_DET.Columns[4].Width = 90;
            DGW_DET.Columns[4].ReadOnly = true;
            DGW_DET.Columns[5].Visible = false;
            DGW_DET.Columns[6].HeaderText = "N° Doc";
            DGW_DET.Columns[6].Width = 70;
            DGW_DET.Columns[6].ReadOnly = true;
            DGW_DET.Columns[7].HeaderText = "Fec Ven";
            DGW_DET.Columns[7].Width = 70;
            DGW_DET.Columns[7].ReadOnly = true;
            DGW_DET.Columns[7].DefaultCellStyle.Format = "dd/MM/yyyy";
            DGW_DET.Columns[8].HeaderText = "Imp Env";
            DGW_DET.Columns[8].Width = 65;
            DGW_DET.Columns[8].ReadOnly = true;
            DGW_DET.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DGW_DET.Columns[9].HeaderText = "Imp Rec";
            DGW_DET.Columns[9].Width = 65;
            DGW_DET.Columns[9].ReadOnly = true;
            DGW_DET.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DGW_DET.Columns[10].HeaderText = "x Dev";
            DGW_DET.Columns[10].Width = 75;
            DGW_DET.Columns[10].ReadOnly = true;
            DGW_DET.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DGW_DET.Columns[11].HeaderText = "Dev";
            DGW_DET.Columns[11].Width = 65;
            DGW_DET.Columns[11].ReadOnly = true;
            DGW_DET.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DGW_DET.Columns[12].HeaderText = "Letra";
            DGW_DET.Columns[12].Width = 55;
            DGW_DET.Columns[12].ReadOnly = true;
            DGW_DET.Columns[13].HeaderText = "Tot Letras";
            DGW_DET.Columns[13].Width = 65;
            DGW_DET.Columns[13].ReadOnly = true;
            DGW_DET.Columns[14].HeaderText = "Observaciones";
            DGW_DET.Columns[14].Width = 110;
            DGW_DET.Columns[14].ReadOnly = false;
            DGW_DET.Columns[15].Visible = false;
        }
        private void CARGAR_TIPO_PLANILLA()
        {
            //var planilla = new[] {  new { val = "PLANILLA", cod = "P" },
            //                        new { val = "DIRECTA", cod = "D" },
            //                        new { val = "PLANILLA/DIRECTA", cod = "PD" }};

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

        private void btn_consulta_Click(object sender, EventArgs e)
        {
            if (dgw1.Rows.Count > 0)
            {
                LIMPIAR_CABECERA();
                DGW_DET.Rows.Clear();
                CARGAR_CABECERA();
                CARGAR_DETALLE();
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
        private void CARGAR_CABECERA()
        {
            int idx = dgw1.CurrentRow.Index;
            cbo_sucursal.SelectedValue = dgw1.Rows[idx].Cells["COD_SUCURSAL"].Value;
            cbo_institucion.SelectedValue = dgw1.Rows[idx].Cells["COD_INSTITUCION"].Value;
            cbo_ptoCobranza.SelectedValue = dgw1.Rows[idx].Cells["COD_PTO_COB_CONSOLIDADO"].Value;
            cbo_canaldscto.SelectedValue = dgw1.Rows[idx].Cells["COD_CANAL_DSCTO"].Value;
            if (dgw1.Rows[idx].Cells["COD_PTO_COB"].Value.ToString() != "")
            {
                CH_PV.Checked = true;
                llena_Pto_Cobranza_X_PtoCobConsolidado();
                cbo_pto_cob.SelectedValue = dgw1.Rows[idx].Cells["COD_PTO_COB"].Value;
            }
            else
            {
                cbo_pto_cob.DataSource = null;
                CH_PV.Checked = false;
            }
            cbo_sectorista.SelectedValue = dgw1.Rows[idx].Cells["COD_SECTORISTA"].Value;
            txt_obs.Text = dgw1.Rows[idx].Cells["OBSERVACION"].Value.ToString();
            txt_ser.Text = dgw1.Rows[idx].Cells["NRO_PLANILLA_COB"].Value.ToString().Substring(0, 3);
            txt_num.Text = dgw1.Rows[idx].Cells["NRO_PLANILLA_COB"].Value.ToString().Substring(4, 7);
            dtp_generacion.Value = Convert.ToDateTime(dgw1.Rows[idx].Cells["FECHA_PLANILLA_COB"].Value);
            dtp_fecven.Value = Convert.ToDateTime(dgw1.Rows[idx].Cells["FECHA_VEN_AL"].Value);
            cbo_tipo_planilla.SelectedValue = dgw1.Rows[idx].Cells["TIPO_PLANILLA"].Value.ToString().Trim();
            if (dgw1.Rows[idx].Cells["COD_COBRADOR"].Value.ToString() != "")
            {
                llena_Cobradores();
                cbo_cobrador.SelectedValue = dgw1.Rows[idx].Cells["COD_COBRADOR"].Value;
            }

        }
        private void CARGAR_DETALLE()
        {
            planillaDetalleBLL pldBLL = new planillaDetalleBLL();
            planillaDetalleTo pldTo = new planillaDetalleTo();
            int idx = dgw1.CurrentRow.Index;
            pldTo.NRO_PLANILLA_COB = dgw1.Rows[idx].Cells["NRO_PLANILLA_COB"].Value.ToString();
            pldTo.COD_INSTITUCION = dgw1.Rows[idx].Cells["COD_INSTITUCION"].Value.ToString();
            pldTo.COD_PTO_COB = dgw1.Rows[idx].Cells["COD_PTO_COB"].Value.ToString();
            pldTo.COD_CANAL_DSCTO = dgw1.Rows[idx].Cells["COD_CANAL_DSCTO"].Value.ToString();
            //pldTo.FE_AÑO = AÑO;
            //pldTo.FE_MES = MES;
            DataTable dt = pldBLL.obtener_I_Planilla_Detalle_para_Cancelacion_BLL(pldTo);
            if (dt.Rows.Count > 0)
            {
                DGW_DET.Rows.Clear();
                foreach (DataRow rw in dt.Rows)
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
                    //row.Cells[8].Value = rw["SAL_IMP"].ToString();
                    //row.Cells[9].Value = rw["IMP_INI"].ToString();//SAL_IMP
                    row.Cells[8].Value = rw["IMP_DOC"].ToString();
                    row.Cells[9].Value = rw["IMP_COB"].ToString();
                    row.Cells[10].Value = rw["IMP_COB_CTA_CTE"].ToString();
                    row.Cells[11].Value = rw["IMP_DEV"].ToString();
                    row.Cells[12].Value = rw["NRO_LETRA"].ToString();
                    row.Cells[13].Value = rw["TOT_LETRA"].ToString();
                    row.Cells[14].Value = rw["OBSERVACION"].ToString();
                }
            }
            HALLAR_TOTALES();
            HALLAR_NRO_CONTRATOS();
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
        private void HALLAR_TOTALES()
        {
            int num = DGW_DET.Rows.Count - 1;
            decimal sum_env = 0, sum_rec = 0, sum_cta_cte = 0, sum_dev = 0;
            int i = 0;
            while (i <= num)
            {
                sum_env = decimal.Add(sum_env, Convert.ToDecimal(DGW_DET[8, i].Value));
                sum_rec = decimal.Add(sum_rec, Convert.ToDecimal(DGW_DET[9, i].Value));
                sum_cta_cte = decimal.Add(sum_cta_cte, Convert.ToDecimal(DGW_DET[10, i].Value));
                sum_dev = decimal.Add(sum_dev, Convert.ToDecimal(DGW_DET[11, i].Value));
                i++;
            }
            txt_totimp.Text = sum_env.ToString();
            txt_totimp.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(txt_totimp.Text);
            txt_tot_imp_rec.Text = sum_rec.ToString();
            txt_tot_imp_rec.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(txt_tot_imp_rec.Text);
            txt_tot_imp_ctate.Text = sum_cta_cte.ToString();
            txt_tot_imp_ctate.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(txt_tot_imp_ctate.Text);
            txt_tot_imp_dev.Text = sum_dev.ToString();
            txt_tot_imp_dev.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(txt_tot_imp_dev.Text);
            txt_ctas.Text = DGW_DET.Rows.Count.ToString();
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
                    if (DGW_DET[0, j].Value.ToString() != DGW_DET[0, j + 1].Value.ToString() && DGW_DET[0, j].Value.ToString() != "0000000")
                    {
                        n++;
                        i = j;
                        break;
                    }
                }
            }
            txt_ctas.Text = n.ToString();
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
        private void CARGAR_SECTORISTA()
        {
            progNivelBLL prnBLL = new progNivelBLL();
            DataTable dtEqc = prnBLL.obtenerSectoristasparaCrearEqCobradoresBLL("01");//02 Cobradores
            cbo_sectorista.ValueMember = "COD_EQCOB";
            cbo_sectorista.DisplayMember = "DESC_EQVTA";
            cbo_sectorista.DataSource = dtEqc;
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

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            TabControl1.SelectedTab = TabPage1;
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
            sdoTo.COD_DOC = "43";//planilla de cobranza
            //txt_nro_ini.Text = sdoBLL.obtenerNro_Ing2BLL(sdoTo);
            txt_ser.Text = sdoBLL.OBTENER_SERIE_NRO_BLL(sdoTo).Rows[0]["SERIE"].ToString();
            txt_num.Text = sdoBLL.OBTENER_SERIE_NRO_BLL(sdoTo).Rows[0]["NUMERO"].ToString();
        }

        private void btn_Aprob_Click(object sender, EventArgs e)
        {
            //if (!validaAprob())
            //    return;
            //DialogResult rs = MessageBox.Show("¿ Esta seguro de Aprobar la Cancelación de la Planilla ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (rs == DialogResult.Yes)
            //{
            //    string errMensaje = "";
            //    plcTo.NRO_PLANILLA_COB = dgw1.CurrentRow.Cells["NRO_PLANILLA_COB"].Value.ToString();
            //    plcTo.COD_INSTITUCION = dgw1.CurrentRow.Cells["COD_INSTITUCION"].Value.ToString();
            //    plcTo.COD_PTO_COB_CONSOLIDADO = dgw1.CurrentRow.Cells["COD_PTO_COB_CONSOLIDADO"].Value.ToString();
            //    plcTo.COD_CANAL_DSCTO = dgw1.CurrentRow.Cells["COD_CANAL_DSCTO"].Value.ToString();
            //    plcTo.FE_AÑO = dgw1.CurrentRow.Cells["FE_AÑO"].Value.ToString();
            //    plcTo.FE_MES = dgw1.CurrentRow.Cells["FE_MES"].Value.ToString();
            //    plcTo.COD_PTO_COB = dgw1.CurrentRow.Cells["COD_PTO_COB"].Value.ToString();
            //    plcTo.COD_MOD = COD_USU;
            //    plcTo.FECHA_MOD = DateTime.Now;

            //    if(!plcBLL.Aprobar_R_PlanillaBLL(plcTo,ref errMensaje))
            //        MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    else
            //    {
            //        MessageBox.Show("El Resumen de Planilla se aprobó correctamente !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        //TabControl1.SelectedTab = TabPage1;
            //        DATAGRID();
            //    }
            //}
        }
        //private bool validaAprob()
        //{
        //    bool result = true;
        //    if(Convert.ToBoolean(dgw1.CurrentRow.Cells["STATUS_APROB"].Value))
        //    {
        //        MessageBox.Show("El registro ya está aprobado !!!","MENSAJE",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
        //        return result = false;
        //    }
        //    return result;
        //}
    }
}
