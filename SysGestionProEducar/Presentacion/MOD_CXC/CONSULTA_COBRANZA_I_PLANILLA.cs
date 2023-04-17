using BLL;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;

namespace Presentacion.MOD_CXC
{
    public partial class CONSULTA_COBRANZA_I_PLANILLA : Form
    {
        string AÑO = "", MES = "", COD_MOD = "", COD_USU = "", TIPO_USU = "";
        DateTime FECHA_INI, FECHA_GRAL;
        planillaCabeceraBLL plcBLL = new planillaCabeceraBLL();
        planillaCabeceraTo plcTo = new planillaCabeceraTo();
        planillaDetalleBLL pldBLL = new planillaDetalleBLL();
        planillaDetalleTo pldTo = new planillaDetalleTo();
        public CONSULTA_COBRANZA_I_PLANILLA(string AÑO, string MES, DateTime FECHA_INI, DateTime FECHA_GRAL, string COD_MOD, string TIPO_USU, string COD_USU)
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

        private void CONSULTA_COBRANZA_I_PLANILLA_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            llenaMes();
            ObtenerCondicionesIniciales();
            INICIAR_CABECERA_GRID_DETALLE();
            INICIAR_CABECERA_GRID_DETALLE_R();
        }
        private void ObtenerCondicionesIniciales()
        {
            cbo_mes.SelectedValue = MES;
            txt_annio.Text = AÑO;
            obtenerBusqueda(cbo_mes.SelectedValue.ToString(), txt_annio.Text.Trim());
        }
        private void obtenerBusqueda(string mes, string annio)
        {
            plcTo.FE_MES = mes;
            plcTo.FE_AÑO = annio;
            DataTable dt = plcBLL.obtener_Consulta_I_Planilla_BLL(plcTo);
            if (dt.Rows.Count > 0)
            {
                dgw1.DataSource = dt;
                DATAGRID();
            }
            else
            {
                dgw1.DataSource = null;
                DGW_DET.Rows.Clear();
                DGW_R.DataSource = null;
                DGW_R_DET.Rows.Clear();
                MessageBox.Show("No se encontraron registros con los parámetros de entrada !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_mes.Focus();
            }
        }
        private void DATAGRID()
        {
            dgw1.Columns["NRO_PLANILLA_COB"].HeaderText = "Nro Planilla";
            dgw1.Columns["NRO_PLANILLA_COB"].Width = 80;
            dgw1.Columns["COD_INSTITUCION"].Visible = false;
            dgw1.Columns["COD_PTO_COB_CONSOLIDADO"].Visible = false;
            dgw1.Columns["COD_CANAL_DSCTO"].Visible = false;
            dgw1.Columns["FE_AÑO"].Visible = false;
            dgw1.Columns["FE_MES"].Visible = false;
            dgw1.Columns["DESCRIPCION"].Visible = false;
            dgw1.Columns["DESC_SUCURSAL"].Visible = false;
            dgw1.Columns["FECHA_PLANILLA_COB"].HeaderText = "Fec Planilla";
            dgw1.Columns["FECHA_PLANILLA_COB"].Width = 70;
            dgw1.Columns["FECHA_PLANILLA_COB"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgw1.Columns["FECHA_VEN_AL"].Visible = false;
            dgw1.Columns["FECHA_APROBACION"].HeaderText = "Fec Aproba";
            dgw1.Columns["FECHA_APROBACION"].Width = 70;
            dgw1.Columns["FECHA_APROBACION"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgw1.Columns["FECHA_ENVIO"].HeaderText = "Fec Envio";
            dgw1.Columns["FECHA_ENVIO"].Width = 70;
            dgw1.Columns["FECHA_ENVIO"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgw1.Columns["FECHA_RECEPCION"].HeaderText = "Fec Recep";
            dgw1.Columns["FECHA_RECEPCION"].Width = 70;
            dgw1.Columns["FECHA_RECEPCION"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgw1.Columns["FECHA_PAGO"].HeaderText = "Fec Pago";
            dgw1.Columns["FECHA_PAGO"].Width = 70;
            dgw1.Columns["FECHA_PAGO"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgw1.Columns["DESC_INST"].Visible = false;
            dgw1.Columns["DESC_PTO_COB"].HeaderText = "Pto Cob Consolidado";
            dgw1.Columns["DESC_PTO_COB"].Width = 200;
            dgw1.Columns["TIPO_PLANILLA"].Visible = false;
            dgw1.Columns["OBSERVACION"].Visible = false;
            dgw1.Columns["SEC"].Visible = false;
            dgw1.Columns["COB"].Visible = false;
            dgw1.Columns["CANT_CONTRATOS"].HeaderText = "Contratos";
            dgw1.Columns["CANT_CONTRATOS"].Width = 60;
            dgw1.Columns["IMP_ENVIO"].HeaderText = "Imp Enviado";
            dgw1.Columns["IMP_ENVIO"].Width = 80;
            dgw1.Columns["IMP_ENVIO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgw1.Columns["IMP_RECEPCION_CTA_CTE"].HeaderText = "Imp Rec CtaCte";
            dgw1.Columns["IMP_RECEPCION_CTA_CTE"].Width = 90;
            dgw1.Columns["IMP_RECEPCION_CTA_CTE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgw1.Columns["IMP_RECEPCION_DEV"].HeaderText = "Imp Rec Dev";
            dgw1.Columns["IMP_RECEPCION_DEV"].Width = 85;
            dgw1.Columns["IMP_RECEPCION_DEV"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgw1.Columns["TOTAL"].HeaderText = "Imp Total";
            dgw1.Columns["TOTAL"].Width = 85;
            dgw1.Columns["TOTAL"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
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
        private void INICIAR_CABECERA_GRID_DETALLE_R()
        {
            DGW_R_DET.Columns[0].HeaderText = "Nª Contrato";
            DGW_R_DET.Columns[0].Width = 80;
            DGW_R_DET.Columns[0].ReadOnly = true;
            DGW_R_DET.Columns[1].HeaderText = "Codigo";
            DGW_R_DET.Columns[1].Width = 60;
            DGW_R_DET.Columns[1].ReadOnly = true;
            DGW_R_DET.Columns[2].HeaderText = "Cod Id";
            DGW_R_DET.Columns[2].Width = 80;
            DGW_R_DET.Columns[2].ReadOnly = true;
            DGW_R_DET.Columns[3].HeaderText = "Nombre Cliente";
            DGW_R_DET.Columns[3].Width = 240;
            DGW_R_DET.Columns[3].ReadOnly = true;
            DGW_R_DET.Columns[4].HeaderText = "DNI/Ruc";
            DGW_R_DET.Columns[4].Width = 90;
            DGW_R_DET.Columns[4].ReadOnly = true;
            DGW_R_DET.Columns[5].Visible = false;
            DGW_R_DET.Columns[6].HeaderText = "N° Doc";
            DGW_R_DET.Columns[6].Width = 70;
            DGW_R_DET.Columns[6].ReadOnly = true;
            DGW_R_DET.Columns[7].HeaderText = "Fec Ven";
            DGW_R_DET.Columns[7].Width = 70;
            DGW_R_DET.Columns[7].ReadOnly = true;
            DGW_R_DET.Columns[7].DefaultCellStyle.Format = "dd/MM/yyyy";
            DGW_R_DET.Columns[8].HeaderText = "Imp Env";
            DGW_R_DET.Columns[8].Width = 65;
            DGW_R_DET.Columns[8].ReadOnly = true;
            DGW_R_DET.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DGW_R_DET.Columns[9].HeaderText = "Imp Rec";
            DGW_R_DET.Columns[9].Width = 65;
            DGW_R_DET.Columns[9].ReadOnly = true;
            DGW_R_DET.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DGW_R_DET.Columns[10].HeaderText = "x Dev";
            DGW_R_DET.Columns[10].Width = 75;
            DGW_R_DET.Columns[10].ReadOnly = true;
            DGW_R_DET.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DGW_R_DET.Columns[11].HeaderText = "Dev";
            DGW_R_DET.Columns[11].Width = 65;
            DGW_R_DET.Columns[11].ReadOnly = true;
            DGW_R_DET.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DGW_R_DET.Columns[12].HeaderText = "Letra";
            DGW_R_DET.Columns[12].Width = 55;
            DGW_R_DET.Columns[12].ReadOnly = true;
            DGW_R_DET.Columns[13].HeaderText = "Tot Letras";
            DGW_R_DET.Columns[13].Width = 65;
            DGW_R_DET.Columns[13].ReadOnly = true;
            DGW_R_DET.Columns[14].HeaderText = "Observaciones";
            DGW_R_DET.Columns[14].Width = 110;
            DGW_R_DET.Columns[14].ReadOnly = false;
            DGW_R_DET.Columns[15].Visible = false;
        }
        private void CONSULTA_COBRANZA_I_PLANILLA_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void llenaMes()
        {
            var meses = new[] { new {cod="01", val="Enero"},
                                new {cod="02", val="Febrero"},
                                new {cod="03", val="Marzo"},
                                new {cod="04", val="Abril"},
                                new {cod="05", val="Mayo"},
                                new {cod="06", val="Junio"},
                                new {cod="07", val="Julio"},
                                new {cod="08", val="Agosto"},
                                new {cod="09", val="Septiembre"},
                                new {cod="10", val="Octubre"},
                                new {cod="11", val="Noviembre"},
                                new {cod="12", val="Diciembre"},
                                };
            cbo_mes.ValueMember = "cod";
            cbo_mes.DisplayMember = "val";
            cbo_mes.DataSource = meses;
        }

        private void btn_consulta_Click(object sender, EventArgs e)
        {
            if (dgw1.Rows.Count > 0)
            {
                LIMPIAR_CABECERA();
                DGW_DET.Rows.Clear();
                //DGW_R.Rows.Clear();
                DGW_R_DET.Rows.Clear();
                CARGAR_CABECERA();
                CARGAR_DETALLE();
                CARGAR_R_PLANILLA();
                //R_PLANILLA
                TabControl1.SelectedTab = TabPage2;
            }
        }
        private void CARGAR_CABECERA()
        {
            int idx = dgw1.CurrentRow.Index;
            lbl_sucursal.Text = dgw1.Rows[idx].Cells["DESC_SUCURSAL"].Value.ToString();
            lbl_nro_pla_cob.Text = dgw1.Rows[idx].Cells["NRO_PLANILLA_COB"].Value.ToString();
            lbl_fec_pla.Text = dgw1.Rows[idx].Cells["FECHA_PLANILLA_COB"].Value.ToString().Substring(0, 10);
            lbl_fec_ven.Text = dgw1.Rows[idx].Cells["FECHA_VEN_AL"].Value.ToString().Substring(0, 10);
            lbl_institucion.Text = dgw1.Rows[idx].Cells["DESC_INST"].Value.ToString();
            lbl_pto_cob_cons.Text = dgw1.Rows[idx].Cells["DESC_PTO_COB"].Value.ToString();
            lbl_sectorista.Text = dgw1.Rows[idx].Cells["SEC"].Value.ToString();
            lbl_canal_dscto.Text = dgw1.Rows[idx].Cells["DESCRIPCION"].Value.ToString();
            lbl_tip_pla.Text = dgw1.Rows[idx].Cells["TIPO_PLANILLA"].Value.ToString();
            lbl_cobrador.Text = dgw1.Rows[idx].Cells["COB"].Value.ToString();
            lbl_obs.Text = dgw1.Rows[idx].Cells["OBSERVACION"].Value.ToString();
        }
        private void LIMPIAR_CABECERA()
        {
            lbl_sucursal.Text = "";
            lbl_nro_pla_cob.Text = "";
            lbl_fec_pla.Text = "";
            lbl_fec_ven.Text = "";
            lbl_institucion.Text = "";
            lbl_pto_cob_cons.Text = "";
            lbl_canal_dscto.Text = "";
            lbl_tip_pla.Text = "";
            lbl_obs.Text = "";
        }
        private void CARGAR_R_PLANILLA()
        {
            int idx = dgw1.CurrentRow.Index;
            plcTo.NRO_PLANILLA_COB = dgw1.Rows[idx].Cells["NRO_PLANILLA_COB"].Value.ToString();
            plcTo.COD_INSTITUCION = dgw1.Rows[idx].Cells["COD_INSTITUCION"].Value.ToString();
            plcTo.COD_PTO_COB_CONSOLIDADO = dgw1.Rows[idx].Cells["COD_PTO_COB_CONSOLIDADO"].Value.ToString();
            DataTable dt = plcBLL.obtener_R_Planilla_BLL(plcTo);
            if (dt.Rows.Count > 0)
            {
                DGW_R.DataSource = dt;
                DGW_R.Columns["NRO_PLANILLA_COB"].HeaderText = "Nro Planilla";
                DGW_R.Columns["NRO_PLANILLA_COB"].Width = 80;
                DGW_R.Columns["FECHA_PLANILLA_COB"].HeaderText = "Fec Planilla";
                DGW_R.Columns["FECHA_PLANILLA_COB"].Width = 70;
                DGW_R.Columns["FECHA_PLANILLA_COB"].DefaultCellStyle.Format = "dd/MM/yyyy";
                DGW_R.Columns["FECHA_APROBACION"].HeaderText = "Fec Aproba";
                DGW_R.Columns["FECHA_APROBACION"].Width = 70;
                DGW_R.Columns["FECHA_APROBACION"].DefaultCellStyle.Format = "dd/MM/yyyy";
                DGW_R.Columns["FECHA_ENVIO"].HeaderText = "Fec Envio";
                DGW_R.Columns["FECHA_ENVIO"].Width = 70;
                DGW_R.Columns["FECHA_ENVIO"].DefaultCellStyle.Format = "dd/MM/yyyy";
                DGW_R.Columns["FECHA_RECEPCION"].HeaderText = "Fec Recep";
                DGW_R.Columns["FECHA_RECEPCION"].Width = 70;
                DGW_R.Columns["FECHA_RECEPCION"].DefaultCellStyle.Format = "dd/MM/yyyy";
                //DGW_R.Columns["FECHA_PAGO"].HeaderText = "Fec Pago";
                //DGW_R.Columns["FECHA_PAGO"].Width = 70;
                //DGW_R.Columns["FECHA_PAGO"].DefaultCellStyle.Format = "dd/MM/yyyy";
                DGW_R.Columns["DESC_PTO_COB"].HeaderText = "Punto Cobranza";
                DGW_R.Columns["DESC_PTO_COB"].Width = 220;
                DGW_R.Columns["COD_PTO_COB"].Visible = false;
                DGW_R.Columns["IMP_ENV"].HeaderText = "Imp Envio";
                DGW_R.Columns["IMP_ENV"].Width = 80;
                DGW_R.Columns["IMP_ENV"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                DGW_R.Columns["IMP_RECEPCION_DOC"].HeaderText = "Imp Rec";
                DGW_R.Columns["IMP_RECEPCION_DOC"].Width = 80;
                DGW_R.Columns["IMP_RECEPCION_DOC"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                DGW_R.Columns["IMP_RECEPCION_DEV"].HeaderText = "Imp Dev";
                DGW_R.Columns["IMP_RECEPCION_DEV"].Width = 80;
                DGW_R.Columns["IMP_RECEPCION_DEV"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                DGW_R.Select();
            }
        }
        private void CARGAR_DETALLE()
        {
            int idx = dgw1.CurrentRow.Index;
            pldTo.NRO_PLANILLA_COB = dgw1.Rows[idx].Cells["NRO_PLANILLA_COB"].Value.ToString();
            pldTo.COD_INSTITUCION = dgw1.Rows[idx].Cells["COD_INSTITUCION"].Value.ToString();
            pldTo.COD_PTO_COB_CONSOLIDADO = dgw1.Rows[idx].Cells["COD_PTO_COB_CONSOLIDADO"].Value.ToString();
            pldTo.COD_CANAL_DSCTO = dgw1.Rows[idx].Cells["COD_CANAL_DSCTO"].Value.ToString();
            pldTo.FE_AÑO = AÑO;
            pldTo.FE_MES = MES;
            DataTable dt = pldBLL.obtener_I_Planilla_Detalle_para_Recepcion_BLL(pldTo);
            if (dt.Rows.Count > 0)
            {
                DGW_DET.Rows.Clear();
                foreach (DataRow rw in dt.Rows)
                {
                    if (rw["NRO_CONTRATO"].ToString() != "9999999")
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
                        row.Cells["CATEGORIA_MOTIVOS_PLANILLA"].Value = rw["CATEGORIA_MOTIVOS_PLANILLA"].ToString();
                    }
                }
            }
            HALLAR_TOTALES();
            HALLAR_NRO_CONTRATOS();
        }
        private void HALLAR_TOTALES()
        {
            //dtPla.AsEnumerable().Where(x =>x.Field<string>("COD_MOTIVO")=="").Sum(x => x.Field<decimal>("IMP_DOC")).ToString();
            int num = DGW_DET.Rows.Count - 1;
            decimal sum_env = 0, sum_rec = 0, sum_cta_cte = 0, sum_dev = 0;
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
                else if (DGW_DET.Rows[i].Cells["CATEGORIA_MOTIVOS_PLANILLA"].Value.ToString() == "03" && DGW_DET.Rows[i].Cells[14].Value.ToString() == "004")
                    sum_rec = decimal.Add(sum_rec, Convert.ToDecimal(DGW_DET[9, i].Value));//descontado
                sum_cta_cte = decimal.Add(sum_cta_cte, Convert.ToDecimal(DGW_DET[10, i].Value));//exceso cuota
                sum_dev = decimal.Add(sum_dev, Convert.ToDecimal(DGW_DET[11, i].Value));//indebido - exceso contrato
                i++;
            }
            txt_totimp.Text = sum_env.ToString();//no descontado
            txt_totimp.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(txt_totimp.Text);
            txt_tot_imp_rec.Text = sum_rec.ToString();//descontado
            txt_tot_imp_rec.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(txt_tot_imp_rec.Text);
            txt_tot_imp_ctate.Text = sum_cta_cte.ToString();//exceso cuot x devolver
            txt_tot_imp_ctate.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(txt_tot_imp_ctate.Text);
            txt_tot_imp_dev.Text = sum_dev.ToString();//descuento indebido / exceso contrato
            txt_tot_imp_dev.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(txt_tot_imp_dev.Text);
            txt_ctas.Text = DGW_DET.Rows.Count.ToString();
        }
        //private void HALLAR_TOTALES()
        //{
        //    int num = DGW_DET.Rows.Count - 1;
        //    decimal sum_env = 0, sum_rec = 0, sum_cta_cte = 0, sum_dev = 0;
        //    int i = 0;
        //    while (i <= num)
        //    {
        //        sum_env = decimal.Add(sum_env, Convert.ToDecimal(DGW_DET[8, i].Value));
        //        sum_rec = decimal.Add(sum_rec, Convert.ToDecimal(DGW_DET[9, i].Value));
        //        sum_cta_cte = decimal.Add(sum_cta_cte, Convert.ToDecimal(DGW_DET[10, i].Value));
        //        sum_dev = decimal.Add(sum_dev, Convert.ToDecimal(DGW_DET[11, i].Value));
        //        i++;
        //    }
        //    txt_totimp.Text = sum_env.ToString();
        //    txt_totimp.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(txt_totimp.Text);
        //    txt_tot_imp_rec.Text = sum_rec.ToString();
        //    txt_tot_imp_rec.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(txt_tot_imp_rec.Text);
        //    txt_tot_imp_ctate.Text = sum_cta_cte.ToString();
        //    txt_tot_imp_ctate.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(txt_tot_imp_ctate.Text);
        //    txt_tot_imp_dev.Text = sum_dev.ToString();
        //    txt_tot_imp_dev.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(txt_tot_imp_dev.Text);
        //    txt_ctas.Text = DGW_DET.Rows.Count.ToString();
        //}
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
        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            TabControl1.SelectedTab = TabPage1;
        }

        private void btn_cancelar2_Click(object sender, EventArgs e)
        {
            TabControl1.SelectedTab = TabPage1;
        }

        private void DGW_R_SelectionChanged(object sender, EventArgs e)
        {
            if (DGW_R.Rows.Count > 0)
            {
                //int idx = dgw1.CurrentRow.Index;
                //pldTo.NRO_PLANILLA_COB = dgw1.Rows[idx].Cells["NRO_PLANILLA_COB"].Value.ToString();
                //pldTo.COD_INSTITUCION = dgw1.Rows[idx].Cells["COD_INSTITUCION"].Value.ToString();
                //pldTo.COD_PTO_COB_CONSOLIDADO = dgw1.Rows[idx].Cells["COD_PTO_COB_CONSOLIDADO"].Value.ToString();
                //pldTo.COD_CANAL_DSCTO = dgw1.Rows[idx].Cells["COD_CANAL_DSCTO"].Value.ToString();
                //pldTo.FE_AÑO = AÑO;
                //pldTo.FE_MES = MES;
                ////pldTo.COD_PTO_COB = dgw1.Rows[idx].Cells["COD_PTO_COB"].Value.ToString();
                DataTable dt = pldBLL.obtener_I_Planilla_Detalle_para_Recepcion_BLL(pldTo);
                if (dt.Rows.Count > 0)
                {
                    DataView dv;
                    dv = new DataView(dt, "COD_PTO_COB = '" + DGW_R.CurrentRow.Cells["COD_PTO_COB"].Value.ToString() + "'", "COD_PTO_COB Asc", DataViewRowState.CurrentRows);

                    DGW_R_DET.Rows.Clear();
                    foreach (DataRow rw in dv.ToTable().Rows)
                    {
                        int rowId = DGW_R_DET.Rows.Add();
                        DataGridViewRow row = DGW_R_DET.Rows[rowId];
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
                        row.Cells[14].Value = rw["OBSERVACION"].ToString();
                    }
                }
                HALLAR_TOTALES_R();
                HALLAR_NRO_CONTRATOS_R();
            }
        }
        private void HALLAR_TOTALES_R()
        {
            int num = DGW_R_DET.Rows.Count - 1;
            decimal sum_env = 0, sum_rec = 0, sum_cta_cte = 0, sum_dev = 0;
            int i = 0;
            while (i <= num)
            {
                sum_env = decimal.Add(sum_env, Convert.ToDecimal(DGW_R_DET[8, i].Value));
                sum_rec = decimal.Add(sum_rec, Convert.ToDecimal(DGW_R_DET[9, i].Value));
                sum_cta_cte = decimal.Add(sum_cta_cte, Convert.ToDecimal(DGW_R_DET[10, i].Value));
                sum_dev = decimal.Add(sum_dev, Convert.ToDecimal(DGW_R_DET[11, i].Value));
                i++;
            }
            txt_totimp2.Text = sum_env.ToString();
            txt_totimp2.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(txt_totimp2.Text);
            txt_tot_imp_rec2.Text = sum_rec.ToString();
            txt_tot_imp_rec2.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(txt_tot_imp_rec2.Text);
            txt_tot_imp_ctate2.Text = sum_cta_cte.ToString();
            txt_tot_imp_ctate2.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(txt_tot_imp_ctate2.Text);
            txt_tot_imp_dev2.Text = sum_dev.ToString();
            txt_tot_imp_dev2.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(txt_tot_imp_dev2.Text);
            txt_ctas2.Text = DGW_R_DET.Rows.Count.ToString();
        }
        private void HALLAR_NRO_CONTRATOS_R()
        {
            int n = 1; int j = 0;
            for (int i = 0; i < DGW_R_DET.Rows.Count - 1; i++)
            {
                if (i == DGW_R_DET.Rows.Count - 1)
                    break;
                for (j = i; j < DGW_R_DET.Rows.Count - 1; j++)
                {
                    if (DGW_R_DET[0, j].Value.ToString() != DGW_R_DET[0, j + 1].Value.ToString() && DGW_R_DET[0, j].Value.ToString() != "0000000")
                    {
                        n++;
                        i = j;
                        break;
                    }
                }
            }
            txt_ctas2.Text = n.ToString();
        }
        private void btn_OK_Click(object sender, EventArgs e)
        {
            obtenerBusqueda(cbo_mes.SelectedValue.ToString(), txt_annio.Text.Trim());
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
