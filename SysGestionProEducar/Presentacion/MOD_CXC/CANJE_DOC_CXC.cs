using BLL;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;
namespace Presentacion.MOD_CXC
{
    public partial class CANJE_DOC_CXC : Form
    {
        string AÑO = "", MES = "", COD_MOD, TIPO_USU, COD_USU;
        DateTime FECHA_INI, FECHA_GRAL;
        string COD_D_H = "", COD_MONEDA = "", COD_SUCURSAL = "";
        decimal IMP_CUOTA_INICIAL, CUOTA_MENSUAL; string COD_PTO_COB;
        DataTable DT00 = new DataTable();
        DataTable dtPCTAS = new DataTable(); DataTable dtTCTAS = new DataTable();
        DataTable dtPTCTAS = new DataTable();
        string COD_CLASE, NRO_REPORTE, COD_VENDEDOR, COD_NIVEL1, COD_NIVEL2, COD_NIVEL3, COD_TIPO_VENTA, COD_MODALIDAD_VTA;
        DateTime FEC_REPORTE; string pre_aprob;
        HelpersBLL helBLL = new HelpersBLL();
        HelpersTo helTo = new HelpersTo();
        precontratoCabeceraBLL pccBLL = new precontratoCabeceraBLL();
        precontratoCabeceraTo pccTo = new precontratoCabeceraTo();
        DIALOGOS.CONSULTA_PARA_CANJE_CXC OFR = new DIALOGOS.CONSULTA_PARA_CANJE_CXC();
        canjeICtasxCobrarBLL ccixcBLL = new canjeICtasxCobrarBLL();
        canjeICtasxCobrarTo ccixcTo = new canjeICtasxCobrarTo();
        canjeTCtasxCobrarBLL cctxcBLL = new canjeTCtasxCobrarBLL();
        canjeTCtasxCobrarTo cctxcTo = new canjeTCtasxCobrarTo();
        progNivelBLL prnirBLL = new progNivelBLL();
        public CANJE_DOC_CXC(string AÑO, string MES, DateTime FECHA_INI, DateTime FECHA_GRAL, string COD_MOD, string TIPO_USU, string COD_USU)
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
        private void CANJE_DOC_CXC_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            //dgw1.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
            //DGW_DET2.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
            //dgw_det.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
            DATAGRID();
            CARGAR_SUCURSAL();
            CARGAR_PERSONAS();
            CARGAR_MONEDA();
            CARGAR_SECTORISTA();
            //CREAR_DT_TCTAS();
            CREAR_DT_PTCTAS();
            COD_D_H = helBLL.COD_D_H("30");//OBJ.COD_D_H("30");
            DT00.Columns.Add("sucursal");
            DT00.Columns.Add("COD_DOC");
            DT00.Columns.Add("NRO_DOC");
            DT00.Columns.Add("COD_PER");
            DT00.Columns.Add("AÑO");
            DT00.Columns.Add("MES");
            DT00.Columns.Add("NRO_PLAN");
            DT00.Columns.Add("COD_CUENTA");
            DT00.Columns.Add("COD_MP");
            DT00.Columns.Add("NRO_MP");
            DT00.Columns.Add("NRO_DOC_PER");
            DT00.Columns.Add("FECHA_DOC");
            DT00.Columns.Add("FECHA_VEN");
            DT00.Columns.Add("COD_D_H");
            DT00.Columns.Add("COD_MONEDA");
            DT00.Columns.Add("TIPO_CAMBIO");
            DT00.Columns.Add("IMP_DOC");
            DT00.Columns.Add("COD_SIT");
            DT00.Columns.Add("COD_EST");
            DT00.Columns.Add("COD_UBI");
            DT00.Columns.Add("OBSERVACION");
            DT00.Columns.Add("COD_REF");
            DT00.Columns.Add("NRO_REF");
            DT00.Columns.Add("FECHA_REF");
            DT00.Columns.Add("TIPO_INGRESO");
            DT00.Columns.Add("TIPO_OPE");
            DT00.Columns.Add("NRO_DOC_CANC");
            DT00.Columns.Add("TIPO_CANC");
            DT00.Columns.Add("POR_CANC");
            DT00.Columns.Add("NRO_LETRA");
            DT00.Columns.Add("TOTAL_LETRA");
            DT00.Columns.Add("NOMBRE_PC");
            DT00.Columns.Add("COD_COBRADOR");
            DT00.Columns.Add("ITEM");
            btn_nuevo.Select();
        }
        private void CARGAR_SECTORISTA()
        {
            DataTable dt = prnirBLL.obtenerSectoristasparaCrearEqCobradoresBLL("01");
            cbo_sectorista.ValueMember = "COD_EQCOB";
            cbo_sectorista.DisplayMember = "DESC_EQVTA";
            cbo_sectorista.DataSource = dt;
            cbo_sectorista.SelectedIndex = -1;
        }
        private void CREAR_DT_PTCTAS()
        {
            dtPTCTAS.Columns.Add("COD_SUCURSAL");
            dtPTCTAS.Columns.Add("COD_CLASE");
            dtPTCTAS.Columns.Add("NRO_CONTRATO");
            dtPTCTAS.Columns.Add("FE_AÑO");
            dtPTCTAS.Columns.Add("FE_MES");
            dtPTCTAS.Columns.Add("COD_PER");
            dtPTCTAS.Columns.Add("COD_DOC");
            dtPTCTAS.Columns.Add("NRO_DOC");
            dtPTCTAS.Columns.Add("FECHA_CONTRATO");
            dtPTCTAS.Columns.Add("FECHA_DOC");
            dtPTCTAS.Columns.Add("FECHA_VEN");
            dtPTCTAS.Columns.Add("COD_P_COBRANZA");
            dtPTCTAS.Columns.Add("IMP_INI");
            dtPTCTAS.Columns.Add("IMP_DOC");
            dtPTCTAS.Columns.Add("COD_COBRADOR");
            dtPTCTAS.Columns.Add("NRO_PLANILLA");
            dtPTCTAS.Columns.Add("FECHA_PLANILLA");
            dtPTCTAS.Columns.Add("COD_D_H");
            dtPTCTAS.Columns.Add("COD_MONEDA");
            dtPTCTAS.Columns.Add("TIPO_CAMBIO");
            //dtPTCTAS.Columns.Add("IMP_DOC");
            dtPTCTAS.Columns.Add("OBSERVACION");
            dtPTCTAS.Columns.Add("TIPO_OPE");
            dtPTCTAS.Columns.Add("NRO_LETRA");
            dtPTCTAS.Columns.Add("TOTAL_LETRA");
            dtPTCTAS.Columns.Add("COD_CONCEPTO");
            dtPTCTAS.Columns.Add("COD_USU_CREA");
            dtPTCTAS.Columns.Add("FECHA_CREA");
        }

        private void CARGAR_N_INICIAL()
        {
            serieDocumentoBLL sdoBLL = new serieDocumentoBLL();
            serieDocumentosTo sdoTo = new serieDocumentosTo();
            sdoTo.COD_SUCURSAL = COD_SUCURSAL;
            //sdoTo.SERIE = "000";
            //sdoTo.COD_DOC = "41";
            sdoTo.STATUS_DOC = "0";
            sdoTo.COD_DOC = "42";
            //txt_nro_ini.Text = sdoBLL.obtenerNro_Ing2BLL(sdoTo);
            txt_nro_ini.Text = sdoBLL.OBTENER_SERIE_NRO_BLL(sdoTo).Rows[0]["NUMERO"].ToString();
        }
        private void CANJE_DOC_CXC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }
        private void CARGAR_MONEDA()
        {
            DataTable dt = helBLL.obtenerMonedaBLL();
            CBO_MONEDA.ValueMember = "COD_MONEDA";
            CBO_MONEDA.DisplayMember = "desc_moneda";
            CBO_MONEDA.DataSource = dt;
            //CBO_MONEDA.SelectedItem = -1;
        }
        private void CARGAR_SUCURSAL()
        {
            //string COD_USU = "0000";
            helTo.CODIGO = COD_USU;
            DataTable dt = helBLL.CBO_SUCURSALBLL(helTo);
            cbo_sucursal.ValueMember = "COD_SUCURSAL";
            cbo_sucursal.DisplayMember = "DESC_sucursal";
            cbo_sucursal.DataSource = dt;
            cbo_sucursal.SelectedIndex = 0;
        }
        private void CARGAR_PERSONAS()
        {
            //helTo.CODIGO = "04";//VENDEDORES
            //DataTable dt = helBLL.MOSTRAR_PERSONAS_XCOBRAR_BLL(helTo);
            //pccTo.COD_PER = TXT_COD.Text;
            pccTo.COD_SUCURSAL = COD_SUCURSAL;
            //pccTo.FE_AÑO = AÑO;
            //pccTo.FE_MES = MES;
            DataTable dt = pccBLL.obtieneRegContratoBLL(pccTo);
            if (dt.Rows.Count >= 0)
            {
                dgw_per.DataSource = dt;
                dgw_per.Columns["Cod"].HeaderText = "Código";
                dgw_per.Columns["Cod"].Width = 50;
                dgw_per.Columns["Razón Social"].HeaderText = "Nombre o Razón Social";
                dgw_per.Columns["Razón Social"].Width = 180;
                dgw_per.Columns["Nroº Doc"].HeaderText = "Dni / Ruc";
                dgw_per.Columns["Nroº Doc"].Width = 70;
                dgw_per.Columns["Nª Contrato"].HeaderText = "Contrato";
                dgw_per.Columns["Nª Contrato"].Width = 60;
                dgw_per.Columns["FEC CON"].HeaderText = "Fec Cont";
                dgw_per.Columns["FEC CON"].Width = 70;
                dgw_per.Columns["FEC CON"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgw_per.Columns["PRE_APROB"].HeaderText = "Pre Apr";
                dgw_per.Columns["PRE_APROB"].Width = 40;
                dgw_per.Columns[4].Visible = false;
                dgw_per.Columns[5].Visible = false;
                dgw_per.Columns[6].Visible = false;
                dgw_per.Columns[7].Visible = false;
                dgw_per.Columns[8].Visible = false;
                dgw_per.Columns[9].Visible = false;
                dgw_per.Columns[11].Visible = false;
                dgw_per.Columns[12].Visible = false;
                dgw_per.Columns[13].Visible = false;
                dgw_per.Columns[14].Visible = false;
                dgw_per.Columns[15].Visible = false;
                dgw_per.Columns[16].Visible = false;
                dgw_per.Columns[17].Visible = false;
                dgw_per.Columns[18].Visible = false;
                dgw_per.Columns[19].Visible = false;
                dgw_per.Columns[20].Visible = false;
                dgw_per.Columns["COD_TIPO_VENTA"].Visible = false;
                dgw_per.Columns["DESC_TIPO_VENTA"].Visible = false;
                dgw_per.Columns["COD_MODALIDAD_VTA"].Visible = false;
                dgw_per.Columns["DESC_MODALIDAD_VTA"].Visible = false;
                dgw_per.Columns["IMP_COUTA_MES"].Visible = false;
                dgw_per.Columns["COD_SECTORISTA"].Visible = false;
                //dgw_per.Columns[""].
            }
        }
        private void DATAGRID()
        {
            ccixcTo.FE_AÑO = AÑO;
            ccixcTo.FE_MES = MES;
            ccixcTo.TIPO_USU = TIPO_USU;
            ccixcTo.COD_USU = COD_USU;
            DataTable dt = ccixcBLL.obtenerCanjeICtasxCobrarBLL(ccixcTo);
            dgw1.DataSource = dt;
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            LIMPIAR();
            TabControl1.SelectedTab = TabPage2;
            TXT_COD.Focus();
        }
        private void LIMPIAR()
        {
            //cbo_sucursal.SelectedIndex = -1;
            TXT_COD.Clear();
            TXT_DESC.Clear();
            txt_doc_per.Clear();
            Panel_PER.Visible = false;
            gb_cab.Enabled = true;
            txt_np.Clear();
            txt_nro_ini.Clear();
            txt_dia.Clear();
            txt_dia.Text = "0";
            txt_cuota.Clear();
            CBO_MONEDA.SelectedIndex = -1;
            TXT_TC2.Text = "0.0000";
            txt_obs.Clear();
            txt_total.Text = "0.00";
            txt_total2.Text = "0.00";
            txt_tipo_vta.Text = "";
            txt_mod_vta.Text = "";
            //gb_doc.Enabled = true;
            //GB3.Enabled = true;
            dgw_det.Rows.Clear();
            DGW_DET2.Rows.Clear();
            DGW_DET2.ReadOnly = false;
            dgw_det.ReadOnly = true;
            BTN_GRABAR.Enabled = true;
            btn_nuevo2.Enabled = false;
            btn_generar.Enabled = true;
            DTP_ACEP.Value = FECHA_GRAL;
            dtp_canje.Value = FECHA_GRAL;
            //DTP_ENT.Value = FECHA_GRAL
            DTP_VEN.Value = FECHA_GRAL;
            btn_doc.Enabled = true;
        }

        private void TXT_COD_Leave(object sender, EventArgs e)
        {
            if (TXT_COD.Text.Trim() != "")
            {
                if (dgw_per.Rows.Count > 0)
                {
                    dgw_per.Sort(dgw_per.Columns[0], System.ComponentModel.ListSortDirection.Ascending);
                    int num2 = dgw_per.Rows.Count - 1;
                    int i = 0;
                    while (i <= num2)
                    {
                        if (TXT_COD.Text.ToLower() == dgw_per[0, i].Value.ToString().ToLower())
                        {
                            TXT_COD.Text = dgw_per[0, i].Value.ToString();
                            TXT_DESC.Text = dgw_per[1, i].Value.ToString();
                            txt_doc_per.Text = dgw_per[2, i].Value.ToString();
                            dtp_canje.Focus();
                            return;
                        }
                        if (TXT_COD.Text.Trim() == dgw_per[0, i].Value.ToString().Substring(0, TXT_COD.TextLength).ToLower())
                        {
                            dgw_per.CurrentCell = dgw_per.Rows[i].Cells[0];
                            break;
                        }
                        dgw_per.CurrentCell = dgw_per.Rows[0].Cells[0];
                        i++;
                    }
                    Panel_PER.Visible = true;
                    dgw_per.Visible = true;
                    dgw_per.Focus();
                }
                else
                {
                    MessageBox.Show("No existen PERSONAS X COBRAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                //pccTo.COD_PER = TXT_COD.Text;
                //pccTo.COD_SUCURSAL = COD_SUCURSAL;
                //DataTable dt = pccBLL.obtieneRegContratoBLL(pccTo);
                txt_np.Text = dgw_per[3, idx].Value.ToString();
                CBO_MONEDA.SelectedValue = dgw_per[4, idx].Value;
                TXT_TC2.Text = dgw_per[5, idx].Value.ToString();
                txt_dia.Text = dgw_per[6, idx].Value.ToString();
                txt_cuota.Text = dgw_per[8, idx].Value.ToString();
                DTP_ACEP.Value = dgw_per[7, idx].Value.ToString() == "" ? DateTime.Now : Convert.ToDateTime(dgw_per[7, idx].Value);
                DTP_VEN.Value = Convert.ToDateTime(dgw_per[9, idx].Value);
                dtp_fec_con.Value = Convert.ToDateTime(dgw_per[10, idx].Value);
                txt_obs.Text = dgw_per[11, idx].Value.ToString();
                IMP_CUOTA_INICIAL = Convert.ToDecimal(dgw_per[12, idx].Value);
                COD_CLASE = dgw_per[13, idx].Value.ToString();
                NRO_REPORTE = dgw_per[14, idx].Value.ToString();
                FEC_REPORTE = Convert.ToDateTime(dgw_per[15, idx].Value);
                COD_VENDEDOR = dgw_per[16, idx].Value.ToString();
                COD_NIVEL1 = dgw_per[17, idx].Value.ToString();
                COD_NIVEL2 = dgw_per[18, idx].Value.ToString();
                COD_NIVEL3 = dgw_per[19, idx].Value.ToString();
                COD_PTO_COB = dgw_per[20, idx].Value.ToString();
                COD_TIPO_VENTA = dgw_per.Rows[idx].Cells["COD_TIPO_VENTA"].Value.ToString();
                txt_tipo_vta.Text = dgw_per.Rows[idx].Cells["DESC_TIPO_VENTA"].Value.ToString();
                COD_MODALIDAD_VTA = dgw_per.Rows[idx].Cells["COD_MODALIDAD_VTA"].Value.ToString();
                txt_mod_vta.Text = dgw_per.Rows[idx].Cells["DESC_MODALIDAD_VTA"].Value.ToString();
                CUOTA_MENSUAL = Convert.ToDecimal(dgw_per.Rows[idx].Cells["IMP_COUTA_MES"].Value);
                pre_aprob = dgw_per.Rows[idx].Cells["PRE_APROB"].Value.ToString() == "SI" ? "1" : "0";
                cbo_sectorista.SelectedValue = dgw_per.Rows[idx].Cells["COD_SECTORISTA"].Value.ToString();
                CARGAR_N_INICIAL();
                Panel_PER.Visible = false;
                //txt_obs.Focus();
                txt_tipo_vta.Focus();
                //GB3.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Panel_PER.Visible = false;
                TXT_COD.Focus();
                TXT_COD.Clear();
                TXT_DESC.Clear();
                txt_doc_per.Clear();
            }
        }

        private void TXT_DESC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && TXT_DESC.Text.Trim() != "")
            {
                if (dgw_per.Rows.Count > 0)
                {
                    dgw_per.Sort(dgw_per.Columns[1], System.ComponentModel.ListSortDirection.Ascending);
                    int num2 = dgw_per.Rows.Count - 1;
                    int i = 0;
                    while (i <= num2)
                    {
                        if (dgw_per[1, i].Value.ToString().Length >= txt_doc_per.TextLength)
                        {
                            if (TXT_DESC.Text.ToLower() == dgw_per[1, i].Value.ToString().Substring(0, TXT_DESC.TextLength).ToLower())
                            {
                                dgw_per.CurrentCell = dgw_per.Rows[i].Cells[0];
                                break;
                            }
                        }
                        dgw_per.CurrentCell = dgw_per.Rows[0].Cells[0];
                        i++;
                    }
                    Panel_PER.Visible = true;
                    dgw_per.Visible = true;
                    dgw_per.Focus();
                }
                else
                    MessageBox.Show("No existen PERSONAS X COBRAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txt_doc_per_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txt_doc_per.Text.Trim() != "")
            {
                if (dgw_per.Rows.Count > 0)
                {
                    dgw_per.Sort(dgw_per.Columns[2], System.ComponentModel.ListSortDirection.Ascending);
                    int num2 = dgw_per.Rows.Count - 1;
                    int i = 0;
                    while (i <= num2)
                    {
                        if (dgw_per[2, i].Value.ToString().Length >= txt_doc_per.TextLength)
                        {
                            if (txt_doc_per.Text.ToLower() == dgw_per[2, i].Value.ToString().ToLower().Substring(0, txt_doc_per.TextLength))
                            {
                                dgw_per.CurrentCell = dgw_per.Rows[i].Cells[0];
                                break;
                            }
                        }
                        dgw_per.CurrentCell = dgw_per.Rows[0].Cells[0];
                        i++;
                    }
                    Panel_PER.Visible = true;
                    dgw_per.Visible = true;
                    dgw_per.Focus();
                }
                else
                    MessageBox.Show("No existen PERSONAS X COBRAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btn_doc_Click(object sender, EventArgs e)
        {
            if (!validaDocumento())
                return;
            boton3();
        }
        private void boton3()
        {
            OFR.MOSTRAR_DATOS(COD_SUCURSAL, COD_MONEDA, TXT_COD.Text, txt_np.Text);
            if (OFR.DGW_CAB.Rows.Count > 0)
            {
                OFR.ShowDialog();
                bool x = false;
                //gb_cab.Enabled = false;
                //gb_doc.Enabled = false;
                if (OFR.DialogResult == DialogResult.OK)
                {
                    foreach (DataGridViewRow row in OFR.DGW_CAB.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[3].Value))
                        {
                            if (OFR.LBL.Text == "NO")
                                boton3();
                            else
                            {
                                INSERTAR_DE_DAILOG();
                                OFR.Hide();
                                HALLAR_TOTAL();
                                x = true;
                            }
                        }
                    }
                    if (x)
                    {
                        TabControl2.SelectedTab = TabPage4;
                        btn_doc.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Debe de elegir un uno !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        boton3();
                        //TabControl2.SelectedTab = TabPage3;
                        //btn_doc.Enabled = true;
                    }
                    btn_generar.Focus();
                }


            }
            else
                MessageBox.Show("No existen Contratos pendientes !!!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        private void HALLAR_TOTAL()
        {
            int num2 = 0;
            int num = dgw_det.Rows.Count - 1;
            decimal left = 0;
            int num4 = num;
            while (num2 <= num4)
            {
                if (Convert.ToBoolean(dgw_det[3, num2].Value))
                {
                    left = decimal.Add(left, Convert.ToDecimal(dgw_det[2, num2].Value));
                }
                num2++;
            }
            txt_total.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(left.ToString());
        }
        private void INSERTAR_DE_DAILOG()
        {
            int num = OFR.DGW_CAB.Rows.Count - 1;
            int num3 = num;
            int i = 0;
            while (i <= num3)
            {
                if (Convert.ToBoolean(OFR.DGW_CAB[3, i].Value))
                {
                    dgw_det.Rows.Add(OFR.DGW_CAB[0, i].Value.ToString(), OFR.DGW_CAB[1, i].Value.ToString(), OFR.DGW_CAB[2, i].Value.ToString(),
                        true, OFR.DGW_CAB[4, i].Value.ToString(), OFR.DGW_CAB[5, i].Value.ToString(),
                        OFR.DGW_CAB[6, i].Value.ToString());
                }
                i++;
            }
        }
        private bool validaDocumento()
        {
            bool result = true;
            if (cbo_sucursal.SelectedIndex < -1)
            {
                MessageBox.Show("Elija una sucursal !!!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_sucursal.Focus();
                return result = false;
            }
            if (TXT_COD.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el Proveedor !!!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TXT_COD.Focus();
                return result = false;
            }
            if (Panel_PER.Visible)
            {
                MessageBox.Show("Ingrese el Proveedor !!!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dgw_per.Focus();
                return result = false;
            }
            if (CBO_MONEDA.SelectedIndex == -1)
            {
                MessageBox.Show("Elija la moneda !!!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TXT_COD.Focus();
                return result = false;
            }

            return result;
        }

        private void cbo_sucursal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_sucursal.SelectedValue != null)
            {
                if (cbo_sucursal.SelectedIndex != -1)
                {
                    COD_SUCURSAL = cbo_sucursal.SelectedValue.ToString();
                }
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            TabControl1.SelectedTab = TabPage1;
            btn_nuevo.Select();
        }

        private void btn_generar_Click(object sender, EventArgs e)
        {
            if (dgw_det.Rows.Count <= 0)
                return;
            GENERAR_LETRAS();
            HALLAR_TOTAL_LETRAS();
        }
        private void GENERAR_LETRAS()
        {
            DGW_DET2.Rows.Clear();
            int num = Convert.ToInt32(txt_cuota.Text);
            int num3 = 1;
            int num4 = Convert.ToInt32(txt_nro_ini.Text);
            int num2 = Convert.ToInt32(txt_dia.Text);
            decimal num5 = Convert.ToDecimal(txt_total.Text);
            int num6 = num;
            decimal suma;
            while (num3 <= num6)
            {
                if (IMP_CUOTA_INICIAL > 0 && num3 == 1)//CASO DE QUE HAYA CUOTA INICIAL, PARA EL PRIMER REGISTRO
                    DGW_DET2.Rows.Add(num3.ToString("00"), ((num4 + num3) - 1).ToString("00000000000"), num3.ToString("00") + "/" + num.ToString("00"), DTP_ACEP.Value, Math.Round(IMP_CUOTA_INICIAL, 2));
                else if (IMP_CUOTA_INICIAL > 0 && num3 != num6)//CASO DE QUE HAYA CUOTA INICIAL PARA LOS OTROS REGISTROS
                    DGW_DET2.Rows.Add(num3.ToString("00"), ((num4 + num3) - 1).ToString("00000000000"), num3.ToString("00") + "/" + num.ToString("00"), DTP_VEN.Value.AddDays((num3 - 2) * num2), Math.Round(CUOTA_MENSUAL), 2);
                else if (num3 != num6)//CASO CUANDO NO HAYA CUOTA INICIAL
                    DGW_DET2.Rows.Add(num3.ToString("00"), ((num4 + num3) - 1).ToString("00000000000"), num3.ToString("00") + "/" + num.ToString("00"), DTP_VEN.Value.AddDays((num3 - 1) * num2), Math.Round(CUOTA_MENSUAL), 2);

                if (num3 == num6)
                {
                    suma = obtenerSuma();
                    DGW_DET2.Rows.Add(num3.ToString("00"), ((num4 + num3) - 1).ToString("00000000000"), num3.ToString("00") + "/" + num.ToString("00"), DTP_VEN.Value.AddDays((num3 - 2) * num2), Math.Round(Convert.ToDecimal(txt_total.Text) - suma, 2));
                }
                num3++;
            }
        }
        private decimal obtenerSuma()
        {
            decimal sum = 0;
            foreach (DataGridViewRow rw in DGW_DET2.Rows)
            {
                sum += Convert.ToDecimal(rw.Cells[4].Value);
            }
            return sum;
        }
        private void HALLAR_TOTAL_LETRAS()
        {
            decimal num3 = 0;
            int num2 = 0;
            int num = DGW_DET2.Rows.Count - 1;
            int num4 = num;
            while (num2 <= num4)
            {
                num3 = decimal.Add(num3, Convert.ToDecimal(DGW_DET2[4, num2].Value));
                num2++;
            }
            txt_total2.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(num3.ToString());
        }

        private void DGW_DET2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int num = DGW_DET2.CurrentRow.Index;
            try
            {
                DGW_DET2[4, num].Value = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(DGW_DET2[4, num].Value.ToString());
            }
            catch (Exception)
            {
                DGW_DET2[4, num].Value = "0.00";
            }
            HALLAR_TOTAL_LETRAS();
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btn_consulta_Click(object sender, EventArgs e)
        {
            if (!validaConsulta())
                return;

            LIMPIAR();
            CARGAR_DATOS();
            gb_cab.Enabled = false;
            //gb_doc.Enabled = false;
            //GB3.Enabled = false;
            BTN_GRABAR.Enabled = false;
            btn_nuevo2.Enabled = false;
            dgw_det.ReadOnly = true;
            DGW_DET2.ReadOnly = true;
            btn_generar.Enabled = false;
            TabControl1.SelectedTab = TabPage2;
            btn_cancelar.Focus();
        }
        private void CARGAR_DATOS()
        {
            int idx = dgw1.CurrentRow.Index;
            cbo_sucursal.SelectedValue = dgw1[0, idx].Value;
            txt_np.Text = dgw1.Rows[idx].Cells["NRO_CONTRATO"].Value.ToString();
            dtp_fec_con.Value = Convert.ToDateTime(dgw1.Rows[idx].Cells["FECHA_CONTRATO"].Value);
            TXT_COD.Text = dgw1.Rows[idx].Cells["COD_PER"].Value.ToString();
            TXT_DESC.Text = dgw1.Rows[idx].Cells["Proveedor"].Value.ToString();
            txt_doc_per.Text = dgw1.Rows[idx].Cells["Ruc/Dni"].Value.ToString();
            //dtp_canje.Value = Convert.ToDateTime(dgw1.Rows[idx].Cells[""].Value);//////
            CBO_MONEDA.SelectedValue = dgw1.Rows[idx].Cells["Mon"].Value;
            TXT_TC2.Text = dgw1.Rows[idx].Cells["T.C."].Value.ToString();
            DTP_ACEP.Value = dgw1.Rows[idx].Cells["FEC_PRIMER_VENC"].Value.ToString() == "" ? DateTime.Now : Convert.ToDateTime(dgw1.Rows[idx].Cells["FEC_PRIMER_VENC"].Value);/////
            txt_dia.Text = dgw1.Rows[idx].Cells["NRO_DIAS_VENC"].Value.ToString();///
            txt_cuota.Text = dgw1.Rows[idx].Cells["NRO_CUOTAS"].Value.ToString();///
            DTP_VEN.Value = Convert.ToDateTime(dgw1.Rows[idx].Cells["FEC_CUO_MEN"].Value);///
            txt_tipo_vta.Text = dgw1.Rows[idx].Cells["DESC_TIPO_VENTA"].Value.ToString();
            txt_mod_vta.Text = dgw1.Rows[idx].Cells["DESC_MODALIDAD_VTA"].Value.ToString();
            //
            GENERAR_LETRAS_REC(idx);
            HALLAR_TOTAL_LETRAS();
            CARGAR_GRID_REC();
        }
        private void CARGAR_GRID_REC()
        {
            dgw_det.Rows.Clear();
            dgw_det.Rows.Add(txt_np.Text, dtp_fec_con.Value, txt_total2.Text,
                             true, DTP_ACEP.Value, DTP_VEN.Value, "01");
            HALLAR_TOTAL();
        }
        private void GENERAR_LETRAS_REC(int idx)
        {
            cctxcTo.COD_SUCURSAL = dgw1[0, idx].Value.ToString();
            cctxcTo.NRO_CONTRATO = dgw1.Rows[idx].Cells["NRO_CONTRATO"].Value.ToString();
            DataTable dt = cctxcBLL.obtenerCanjeDetalleBLL(cctxcTo);
            txt_nro_ini.Text = dt.Rows[0]["NRO_DOC"].ToString();//////
            dtp_canje.Value = Convert.ToDateTime(dt.Rows[0]["FECHA_DOC"]);//////
            DGW_DET2.Rows.Clear();
            int num = Convert.ToInt32(txt_cuota.Text);
            int num3 = 1;
            int num4 = Convert.ToInt32(txt_nro_ini.Text);
            int num2 = Convert.ToInt32(txt_dia.Text);
            decimal num5 = Convert.ToDecimal(txt_total.Text);
            int num6 = num;
            foreach (DataRow rw in dt.Rows)
            {
                DGW_DET2.Rows.Add(num3.ToString("00"), rw["NRO_DOC"].ToString(), num3.ToString("00") + "/" + num.ToString("00"), rw["FECHA_VEN"].ToString().Substring(0, 10), rw["IMP_INI"].ToString());
                num3++;
            }
        }
        private void GENERAR_LETRAS_LET(int idx)
        {
            cctxcTo.COD_SUCURSAL = dgw1[0, idx].Value.ToString();
            cctxcTo.NRO_CONTRATO = dgw1.Rows[idx].Cells["NRO_CONTRATO"].Value.ToString();
            DataTable dt = cctxcBLL.obtenerCanjeDetalleBLL(cctxcTo);
            txt_nro_ini.Text = dt.Rows[0]["NRO_DOC"].ToString();//////
            dtp_canje.Value = Convert.ToDateTime(dt.Rows[0]["FECHA_DOC"]);//////
            DGW_DET2.Rows.Clear();
            int num = Convert.ToInt32(dgw1.Rows[idx].Cells["NRO_CUOTAS"].Value);//Convert.ToInt32(txt_cuota.Text);
            int num3 = 1;
            //int num4 = Convert.ToInt32(txt_nro_ini.Text);
            //int num2 = Convert.ToInt32(txt_dia.Text);
            //decimal num5 = Convert.ToDecimal(txt_total.Text);
            //int num6 = num;
            foreach (DataRow rw in dt.Rows)
            {
                DGW_LET.Rows.Add(num3.ToString("00"), rw["NRO_DOC"].ToString(), num3.ToString("00") + "/" + num.ToString("00"), rw["FECHA_VEN"].ToString().Substring(0, 10), rw["IMP_INI"].ToString());
                num3++;
            }
        }
        private bool validaConsulta()
        {
            bool result = true;
            if (dgw1.Rows.Count == 0)
            {
                return result = false;
            }
            return result;
        }
        private void BTN_GRABAR_Click(object sender, EventArgs e)
        {
            if (!validaGrabar())
                return;
            DialogResult rs = MessageBox.Show("¿ Esta seguro de Grabar ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                HALLAR_TOTAL_LETRAS();
                HALLAR_TOTAL();
                ccixcTo.COD_SUCURSAL = cbo_sucursal.SelectedValue.ToString();
                ccixcTo.COD_CLASE = COD_CLASE;
                ccixcTo.NRO_CONTRATO = txt_np.Text;
                ccixcTo.FE_AÑO = AÑO;
                ccixcTo.FE_MES = MES;
                ccixcTo.FECHA_CONTRATO = dtp_fec_con.Value;
                ccixcTo.FECHA_APROBACION = null;
                ccixcTo.NRO_REPORTE = NRO_REPORTE;
                ccixcTo.FECHA_REPORTE = FEC_REPORTE;
                ccixcTo.COD_MONEDA = CBO_MONEDA.SelectedValue.ToString();
                ccixcTo.TIPO_CAMBIO = Convert.ToDecimal(TXT_TC2.Text);
                ccixcTo.IMP_DOC = Convert.ToDecimal(txt_total.Text);
                ccixcTo.OBSERVACION = txt_obs.Text;
                ccixcTo.TIPO_OPE = "GF";
                ccixcTo.COD_PER = TXT_COD.Text;
                ccixcTo.NRO_CUOTAS = txt_cuota.Text;
                ccixcTo.IMP_DEVOLUCION = 0;
                ccixcTo.FECHA_DEVOLUCION = null;
                ccixcTo.COD_VENDEDOR = COD_VENDEDOR;
                ccixcTo.COD_NIVEL1 = COD_NIVEL1;
                ccixcTo.COD_NIVEL2 = COD_NIVEL2;
                ccixcTo.COD_NIVEL3 = COD_NIVEL3;
                ccixcTo.COD_PTO_COB = COD_PTO_COB;
                ccixcTo.COD_USU_CREA = COD_USU;
                ccixcTo.FECHA_CREA = DateTime.Now;
                ccixcTo.COD_SECTORISTA = cbo_sectorista.SelectedValue.ToString();
                ccixcTo.COD_TIPO_VENTA = COD_TIPO_VENTA;
                ccixcTo.COD_MODALIDAD_VTA = COD_MODALIDAD_VTA;
                ccixcTo.STATUS_PRE_APROB = pre_aprob;
                dtPTCTAS.Rows.Clear();
                dtPTCTAS = obtenerPTCTAS();
                if (!ccixcBLL.insertaAdicionaCanjeICtasxCobrarBLL(ccixcTo, dtPTCTAS, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("El Canje de guardó", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    DATAGRID();
                    CARGAR_PERSONAS();
                    //GB3.Enabled = false;
                    dgw_det.ReadOnly = true;
                    BTN_GRABAR.Enabled = false;
                    btn_nuevo2.Enabled = true;
                    btn_nuevo2.Focus();
                }
            }
        }
        private DataTable obtenerPTCTAS()
        {
            foreach (DataGridViewRow row in DGW_DET2.Rows)
            {
                DataRow rw = dtPTCTAS.NewRow();
                rw["COD_SUCURSAL"] = cbo_sucursal.SelectedValue.ToString();
                rw["COD_CLASE"] = COD_CLASE;
                rw["NRO_CONTRATO"] = txt_np.Text;
                rw["FE_AÑO"] = AÑO;
                rw["FE_MES"] = MES;
                rw["COD_PER"] = TXT_COD.Text;
                rw["COD_DOC"] = 30;
                rw["NRO_DOC"] = "";//
                rw["FECHA_CONTRATO"] = dtp_fec_con.Value;
                rw["FECHA_DOC"] = dtp_canje.Value;
                rw["FECHA_VEN"] = row.Cells[3].Value.ToString();
                rw["COD_P_COBRANZA"] = "";
                rw["IMP_INI"] = row.Cells[4].Value.ToString();
                rw["IMP_DOC"] = 0;
                rw["COD_COBRADOR"] = "";
                rw["NRO_PLANILLA"] = NRO_REPORTE;
                rw["FECHA_PLANILLA"] = FEC_REPORTE;
                rw["COD_D_H"] = "D";
                rw["COD_MONEDA"] = COD_MONEDA;
                rw["TIPO_CAMBIO"] = TXT_TC2.Text;
                //rw["IMP_DOC"] = 0;
                rw["OBSERVACION"] = "";
                rw["TIPO_OPE"] = "GF";
                rw["NRO_LETRA"] = row.Cells[0].Value.ToString().PadLeft(3, '0');
                rw["TOTAL_LETRA"] = txt_cuota.Text.ToString().PadLeft(3, '0');
                rw["COD_CONCEPTO"] = "";
                rw["COD_USU_CREA"] = COD_USU;
                rw["FECHA_CREA"] = DateTime.Now;
                dtPTCTAS.Rows.Add(rw);
            }
            return dtPTCTAS;
        }

        private bool validaGrabar()
        {
            bool result = true;
            if (dgw_det.Rows.Count == 0)
            {
                MessageBox.Show("Canje de Letras sin detalles de Documentos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return result = false;
            }
            if (DGW_DET2.Rows.Count == 0)
            {
                MessageBox.Show("Canje sin Detalles de Letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return result = false;
            }
            //if (!VALIDAR_FECHA())
            //{
            //    MessageBox.Show("La fecha de Vcto. de las letras no puede ser menor.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    TabControl2.SelectedTab = TabPage4;
            //    return result = false;
            //}
            if (txt_total.Text != txt_total2.Text)
            {
                MessageBox.Show("El importe Total de Letras no coincide con el Total a Pagar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_total2.Focus();
                return result = false;
            }
            if (Convert.ToDecimal(TXT_TC2.Text) == 0 && CBO_MONEDA.SelectedValue.ToString() != "S")
            {
                MessageBox.Show("Debe ingresar el Tipo de Cambio", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TXT_TC2.Focus();
                return result = false;
            }
            if (cbo_sucursal.SelectedIndex < 0)
            {
                MessageBox.Show("Elija la Sucursal !!!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_sucursal.Focus();
                return result = false;
            }
            if (TXT_COD.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el Codigo !!!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TXT_COD.Focus();
                return result = false;
            }
            if (TXT_DESC.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese la Descripcion !!!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TXT_DESC.Focus();
                return result = false;
            }
            if (cbo_sectorista.SelectedIndex < 0)
            {
                MessageBox.Show("Elija el Sectorista !!!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_sectorista.Focus();
                return result = false;
            }
            return result;
        }
        private bool VALIDAR_FECHA()
        {
            bool result = true;
            int num2 = 0;
            int num = DGW_DET2.Rows.Count - 1;
            int num3 = num;
            while (num2 <= num3)
            {
                if (Convert.ToDateTime(DGW_DET2[3, num2].Value) < dtp_canje.Value.Date)
                {
                    return result = false;
                }
                num2++;
            }
            return result;
        }

        private void btn_nuevo2_Click(object sender, EventArgs e)
        {
            LIMPIAR();
            CARGAR_PERSONAS();//actualiza las personas del grid desplegable
            cbo_sucursal.Focus();
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (!validarEliminar())
                return;

            DialogResult rs = MessageBox.Show("¿ Esta seguro de eliminar la cta corriente ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                int idx = dgw1.CurrentRow.Index;
                ccixcTo.COD_SUCURSAL = dgw1[0, idx].Value.ToString();
                ccixcTo.COD_PER = dgw1[2, idx].Value.ToString();
                ccixcTo.NRO_CONTRATO = dgw1[5, idx].Value.ToString();
                ccixcTo.FE_AÑO = AÑO;
                ccixcTo.FE_MES = MES;
                ccixcTo.FECHA_MOD = DateTime.Now;
                ccixcTo.COD_USU = COD_USU;

                if (!ccixcBLL.ELIMINAR_I_CTAS_COBRAR_CANJE_BLL(ccixcTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    DATAGRID();
                }
            }
        }
        private bool validarEliminar()
        {
            bool result = true;
            string errMensaje = "";
            if (dgw1.Rows.Count == 0)
            {
                MessageBox.Show("No existen registros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return result = false;
            }
            ccixcTo.NRO_CONTRATO = dgw1.CurrentRow.Cells["NRO_CONTRATO"].Value.ToString();
            if (ccixcBLL.VerificaExisteNroContratoEnviadoBLL(ccixcTo, ref errMensaje))
            {
                MessageBox.Show("No se puede eliminar la Cuenta Corriente pues \nel Contrato ya ha sido enviado a la Institucion !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return result = false;
            }
            //if(!VERIFICAR_LETRA())
            //{
            //    return result = false;
            //}
            return result;
        }
        private bool VERIFICAR_LETRA()
        {
            canjePCtasxCobrarBLL cpccBLL = new canjePCtasxCobrarBLL();
            canjePCtasxCobrarTo cpccTo = new canjePCtasxCobrarTo();
            bool result = true;
            int idx = dgw1.CurrentRow.Index;
            cpccTo.COD_SUCURSAL = dgw1[0, idx].Value.ToString();
            cpccTo.COD_PER = dgw1[2, idx].Value.ToString();

            GENERAR_LETRAS_LET(idx);//se llena el grid de generacion de letras para recorrerlo y ver si a traves del NRO_DOC verificar que IMP_DOC=0 o sea que ya esta completado el pago de cuotas
            int num2 = 0;
            int num = DGW_LET.Rows.Count - 1;
            int num3 = num;
            while (num2 <= num3)
            {
                string str2 = DGW_LET[1, num2].Value.ToString();
                cpccTo.NRO_DOC = str2;
                string str = "";
                str = cpccBLL.VERIFICAR_LETRA_CXC_BLL(cpccTo);
                if (str != "SI")
                {
                    MessageBox.Show(("La Letra Nº " + str2 + "no se encuentra cancelada."), "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return result = false;
                }
                num2++;
            }
            return result;

        }
    }
}
