using BLL;
using Entidades;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Presentacion.MOD_FACT_VTA
{

    public partial class CONTRATOS_DIRECTOS_FACTURACION : Form
    {
        string AÑO = "", MES = "", COD_MOD = "", COD_USU = "", TIPO_USU = "";
        DateTime FECHA_INI, FECHA_GRAL;
        contratoCabeceraBLL ccBLL = new contratoCabeceraBLL();
        contratoCabeceraTo ccTo = new contratoCabeceraTo();
        contratoDetalleBLL ccdBLL = new contratoDetalleBLL();
        contratoDetalleTo ccdTo = new contratoDetalleTo();
        HelpersBLL helBLL = new HelpersBLL();
        HelpersTo helTo = new HelpersTo();
        progNivelRelacionBLL pnrBLL = new progNivelRelacionBLL();
        progNivelRelacionTo pnrTo = new progNivelRelacionTo();
        personaMaestroBLL prmBLL = new personaMaestroBLL();
        personaMaestroTo prmTo = new personaMaestroTo();
        personaBLL perBLL = new personaBLL();
        personaTo perTo = new personaTo();
        modalidadVentaBLL mvBLL = new modalidadVentaBLL();
        //DataTable dt00 = new DataTable();
        DataTable dtContrato;
        string COD_INSTITUCION;
        DataTable dtPersona;
        decimal cant = 0, igv0 = 0;
        string STATUS_DSCTO = "0", STATUS_IGV = "0", RUC, PRECIO, FONO, AÑO0, boton;
        DIALOGOS.CONSULTA_KIT frmKit = new DIALOGOS.CONSULTA_KIT();
        private string CODARTCLI = "", DESCARTCLI = "", PARTEARTCLI = "";
        string COD_PRECIO2 = "", COD_SUCURSAL;
        decimal TOTAL_CONTRATO = 0, IMP_CUOTA_INICIAL = 0, IMP_CUOTA_MES = 0;
        int NRO_CUOTAS, NRO_DIAS_VENC, NRO_DIAS1;
        DateTime? FEC_PRIMER_VENC; DateTime FEC_CUO_MEN;
        string NOMBRE_PC = System.Environment.MachineName;
        DataTable DT00 = new DataTable();
        DataTable dtCondVenta = null;
        string COD_CLASE;
        DIALOGOS.Dialog3 obs = new DIALOGOS.Dialog3();
        string DNI_C;
        int fila;
        public CONTRATOS_DIRECTOS_FACTURACION(string AÑO, string MES, DateTime FECHA_INI, DateTime FECHA_GRAL, string COD_MOD, string TIPO_USU, string COD_USU)
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

        private void CONTRATOS_DIRECTOS_FACTURACION_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            DATAGRID();
            CARGAR_CLASE(); //HAY QUE REVISAR LOS PARAMETROS DE ENTRADA CORRECTOS O HACER EL LOGIN
            CARGAR_SUCURSAL();
            CARGAR_PERSONAS();
            //CARGAR_COND_VENTA();
            CARGAR_PROGRAMAS();
            TIPO_PLANILLA();
            CARGAR_MONEDA();
            cargaFormaPago();
            cargaCondicionVenta();
            CARGAR_MOVIMIENTO();
            //
            OBTENER_TIPO_CAMBIO();
            igv0 = helBLL.obtenerImpuestoBLL("IGV");
            TXT_IGV.Text = igv0.ToString();
            TXT_IGV2.Text = TXT_IGV.Text;
            //TXT_TC.Text = helBLL.obtenerTipoCambioBLL(DTP_DOC.Value.Year.ToString(), HelpersBLL.OBTIENE_CODIGO(2, DTP_DOC.Value.Month.ToString()),
            //HelpersBLL.OBTIENE_CODIGO(2, DTP_DOC.Value.Day.ToString()), "D");
            //DTP_DOC.Value = Convert.ToDateTime(DateTime.Now.Day + "/" + FECHA_INI.Month + "/" + FECHA_INI.Year); 
            DTP_DOC.Value = HelpersBLL.validaFecha(MES, AÑO, FECHA_GRAL);
            btn_nuevo.Select();

        }
        private void OBTENER_TIPO_CAMBIO()
        {
            //string cod_mon = cbo_moneda.SelectedValue.ToString();
            TXT_TC.Text = helBLL.obtenerTipoCambioBLL(DTP_DOC.Value.Year.ToString(), HelpersBLL.OBTIENE_CODIGO(2, DTP_DOC.Value.Month.ToString()),
                HelpersBLL.OBTIENE_CODIGO(2, DTP_DOC.Value.Day.ToString()), "D");
        }
        private void DATAGRID()
        {
            ccTo.FE_AÑO = AÑO;
            ccTo.FE_MES = MES;
            dtContrato = ccBLL.obtenerContratoCabecera_para_Fact_Elect_BLL(ccTo);
            if (dtContrato.Rows.Count > 0)
            {
                DGW.DataSource = dtContrato;
                DGW.Columns["COD_SUCURSAL"].Visible = false;
                DGW.Columns["COD_CLASE"].Visible = false;
                DGW.Columns["NRO_DOC"].Visible = false;
                DGW.Columns["COD_PER"].Visible = false;
                DGW.Columns["DNI"].Visible = false;
                DGW.Columns["COD_MONEDA"].Visible = false;
                DGW.Columns["Desc_moneda"].Visible = false;
                DGW.Columns["FE_AÑO"].Visible = false;
                DGW.Columns["FE_MES"].Visible = false;
                DGW.Columns["OBS"].Visible = false;
                DGW.Columns["TIPO_CAMBIO"].Visible = false;
                DGW.Columns["FORMA_PAGO"].Visible = false;
                DGW.Columns["STATUS_PV"].Visible = false;
                DGW.Columns["NRO_DIAS"].Visible = false;
                DGW.Columns["COD_PER_ELAB"].Visible = false;
                DGW.Columns["COD_CONTACTO"].Visible = false;
                DGW.Columns["CONDICION_VENTA"].Visible = false;
                DGW.Columns["DESC_TIPO"].Visible = false;
                DGW.Columns["TIPO_PRECIO"].Visible = false;
                DGW.Columns["OBSERVACION"].Visible = false;
                DGW.Columns["NRO_REPORTE"].Visible = false;
                DGW.Columns["FEC_REPORTE"].Visible = false;
                DGW.Columns["COD_PROGRAMA"].Visible = false;
                DGW.Columns["DESC_PROGRAMA"].Visible = false;
                DGW.Columns["PERIODO"].Visible = false;
                DGW.Columns["NRO_SEMANA"].Visible = false;
                DGW.Columns["TIPO_PLANILLA"].Visible = false;
                DGW.Columns["COD_ALMACEN"].Visible = false;
                DGW.Columns["COD_NIVEL1"].Visible = false;
                DGW.Columns["COD_NIVEL2"].Visible = false;
                DGW.Columns["COD_NIVEL3"].Visible = false;
                //DGW.Columns["TOTAL_CONTRATO"].Visible = false;
                DGW.Columns["NRO_CUOTAS"].Visible = false;
                DGW.Columns["IMP_CUOTA_INICIAL"].Visible = false;
                DGW.Columns["IMP_COUTA_MES"].Visible = false;
                DGW.Columns["FEC_PRIMER_VENC"].Visible = false;
                DGW.Columns["NRO_DIAS_VENC"].Visible = false;
                DGW.Columns["FEC_CUO_MEN"].Visible = false;
                DGW.Columns["Sucursal"].Width = 160;
                DGW.Columns["Clase"].Width = 90;
                DGW.Columns["Cliente"].Width = 180;
                //DGW.Columns["FECHA_DOC"].Width = 70;
                //DGW.Columns["FECHA_DOC"].DefaultCellStyle.Format = "d";
                DGW.Columns["FECHA_DOC"].Visible = false;
                DGW.Columns["COD_INSTITUCION"].Visible = false;
                DGW.Columns["NRO_PRESUPUESTO"].HeaderText = "Contrato";
                DGW.Columns["NRO_PRESUPUESTO"].DisplayIndex = 7;
                DGW.Columns["NRO_PRESUPUESTO"].Width = 60;
                DGW.Columns["FECHA_PRE"].HeaderText = "Fe Contrato";
                DGW.Columns["FECHA_PRE"].DisplayIndex = 8;
                DGW.Columns["FECHA_PRE"].Width = 70;
                DGW.Columns["FECHA_PRE"].DefaultCellStyle.Format = "d";
                DGW.Columns["TOTAL_CONTRATO"].HeaderText = "Imp Contrato";
                DGW.Columns["TOTAL_CONTRATO"].DisplayIndex = 9;
                DGW.Columns["TOTAL_CONTRATO"].Width = 75;
                DGW.Columns["TOTAL_CONTRATO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                DGW.Columns["TOTAL_CONTRATO"].DefaultCellStyle.Format = "###,###,##0.00";
                DGW.Columns["DESC_INST"].HeaderText = "Institucion";
                DGW.Columns["DESC_INST"].Width = 150;
                txt_nro_contratos.Text = DGW.Rows.Count.ToString();
                txt_imp_total.Text = DGW.Rows.Cast<DataGridViewRow>().Sum(x => Convert.ToDecimal(x.Cells["TOTAL_CONTRATO"].Value)).ToString("###,###,##0.00");
            }
            else
                DGW.DataSource = null;

        }
        private void CARGAR_MONEDA()
        {
            DataTable dt = helBLL.obtenerMonedaBLL();
            CBO_MONEDA.ValueMember = "COD_MONEDA";
            CBO_MONEDA.DisplayMember = "desc_moneda";
            CBO_MONEDA.DataSource = dt;
            CBO_MONEDA.SelectedIndex = 1;
        }
        private void TIPO_PLANILLA()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("cod", typeof(string));
            dt.Columns.Add("val", typeof(string));
            DataRow rw2 = dt.NewRow();
            rw2["cod"] = "P";
            rw2["val"] = "PLANILLA";
            dt.Rows.Add(rw2);

            cbo_tipo_planilla.ValueMember = "cod";
            cbo_tipo_planilla.DisplayMember = "val";
            cbo_tipo_planilla.DataSource = dt;
            cbo_tipo_planilla.SelectedIndex = 0;
        }
        private void cargaCondicionVenta()
        {
            dtCondVenta = helBLL.obtenerCondicionVentaBLL();
            cbo_VENTA.ValueMember = "COD_TIPO";
            cbo_VENTA.DisplayMember = "DESC_TIPO";
            cbo_VENTA.DataSource = dtCondVenta;
            cbo_VENTA.SelectedIndex = 0;
        }
        private void cargaFormaPago()
        {
            DataTable dt = helBLL.obtenerFormaPagoBLL();
            CBO_PAGO.ValueMember = "COD_TIPO";
            CBO_PAGO.DisplayMember = "DESC_TIPO";
            CBO_PAGO.DataSource = dt;
            CBO_PAGO.SelectedIndex = 2;
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
        private void CARGAR_PERSONAS()
        {
            helTo.CODIGO = "04";//VENDEDORES
            dtPersona = helBLL.MOSTRAR_PERSONAS_XCOBRAR_BLL(helTo);
            dgw_per.DataSource = dtPersona;
            dgw_per.Columns["Cod Ref"].Visible = false;
            dgw_per.Columns["COD_INSTITUCION"].Visible = false;
            dgw_per.Columns["DESC_INST"].Visible = false;
        }
        private void CARGAR_SUCURSAL()
        {
            //string COD_USU = "0000";
            helTo.CODIGO = COD_USU;
            DataTable dt = helBLL.CBO_SUCURSALBLL(helTo);
            CBO_SUCURSAL.ValueMember = "COD_SUCURSAL";
            CBO_SUCURSAL.DisplayMember = "DESC_sucursal";
            CBO_SUCURSAL.DataSource = dt;
            CBO_SUCURSAL.SelectedIndex = 0;
        }
        private void CARGAR_CLASE()
        {
            //string TIPO_USU = "MS";
            //string COD_USU = "0000";
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
            CBO_CLASE.ValueMember = "COD_CLASE";
            CBO_CLASE.DisplayMember = "DESC_CLASE";
            CBO_CLASE.DataSource = dt;
            CBO_CLASE.SelectedIndex = 0;
        }
        private void CARGAR_MOVIMIENTO()
        {
            movimientosBLL movBLL = new movimientosBLL();
            DataTable dt = movBLL.obtenerMovimientosparaPedidoBLL();
            cbo_movimiento.ValueMember = "COD_MOV";
            cbo_movimiento.DisplayMember = "DESC_MOV";
            cbo_movimiento.DataSource = dt;
            cbo_movimiento.SelectedIndex = 1;
        }
        private void CONTRATOS_DIRECTOS_FACTURACION_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            vistaPersona();
        }
        private void vistaPersona()
        {
            MOD_ADM.PERSONA frm = new MOD_ADM.PERSONA(1, "");
            ////DIALOGOS.frmIngresoPersona frm = new DIALOGOS.frmIngresoPersona(DNI_C);
            //frm.ShowDialog();
            //if (Properties.Settings.Default.PER == "1")
            //{
            //    if (frm.LBL.Text == "NO")
            //    {
            //        vistaPersona();
            //    }
            //    else
            //    {
            //        TXT_COD.Text = "";
            //        TXT_DESC.Text = "";
            //        txt_doc_per.Text = "";

            //        TXT_COD.Text = frm.txt_cod.Text;
            //        TXT_DESC.Text = frm.cbo_tipo.SelectedItem.ToString() == "NATURAL" ? frm.txt_pat.Text + " " + frm.txt_mat.Text + " " + frm.txt_nom.Text : frm.txt_desc.Text;
            //        txt_doc_per.Text = frm.txt_nro_doc.Text;
            //        COD_INSTITUCION = frm.cbo_institucion.SelectedValue != null ? frm.cbo_institucion.SelectedValue.ToString() : "";//lo trae para el punto de venta
            //        lbl_institucion.Text = frm.cbo_institucion.Text;//se vé la descripción pero no se graba el codigo institucion
            //        //CARGAR_SUB_PUNTO_VENTA();
            //        txt_numero.Focus();
            //    }
            //}
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (Properties.Settings.Default.PER == "1")
                {
                    //if (frm.LBL.Text == "NO")
                    //{
                    //    vistaPersona();
                    //}
                    //else
                    //{
                    //    TXT_COD.Text = "";
                    //    TXT_DESC.Text = "";
                    //    txt_doc_per.Text = "";

                    //    TXT_COD.Text = frm.txt_cod.Text;
                    //    TXT_DESC.Text = frm.cbo_tipo.SelectedItem.ToString() == "NATURAL" ? frm.txt_pat.Text + " " + frm.txt_mat.Text + " " + frm.txt_nom.Text : frm.txt_desc.Text;
                    //    txt_doc_per.Text = frm.txt_nro_doc.Text;
                    //    COD_INSTITUCION = frm.cbo_institucion.SelectedValue != null ? frm.cbo_institucion.SelectedValue.ToString() : "";//lo trae para el punto de venta
                    //    lbl_institucion.Text = frm.cbo_institucion.Text;//se vé la descripción pero no se graba el codigo institucion
                    //    //CARGAR_SUB_PUNTO_VENTA();
                    //    txt_numero.Focus();
                    //}
                    TXT_COD.Text = "";
                    TXT_DESC.Text = "";
                    txt_doc_per.Text = "";

                    TXT_COD.Text = frm.txt_cod.Text;
                    TXT_DESC.Text = frm.cbo_tipo.SelectedItem.ToString() == "NATURAL" ? frm.txt_pat.Text + " " + frm.txt_mat.Text + " " + frm.txt_nom.Text : frm.txt_desc.Text;
                    txt_doc_per.Text = frm.txt_nro_doc.Text;
                    COD_INSTITUCION = frm.cbo_institucion.SelectedValue != null ? frm.cbo_institucion.SelectedValue.ToString() : "";//lo trae para el punto de venta
                    lbl_institucion.Text = frm.cbo_institucion.Text;//se vé la descripción pero no se graba el codigo institucion
                    //CARGAR_SUB_PUNTO_VENTA();
                    txt_numero.Focus();
                }
            }
        }
        private void vistaPersona2()
        {
            DIALOGOS.frmIngresoPersona frm = new DIALOGOS.frmIngresoPersona(DNI_C);
            frm.ShowDialog();
            if (Properties.Settings.Default.PER == "1")
            {
                if (frm.LBL.Text == "NO")
                {
                    vistaPersona2();
                }
                else
                {
                    TXT_COD.Text = "";
                    TXT_DESC.Text = "";
                    txt_doc_per.Text = "";

                    TXT_COD.Text = frm.txt_cod.Text;
                    TXT_DESC.Text = frm.cbo_tipo.SelectedItem.ToString() == "NATURAL" ? frm.txt_pat.Text + " " + frm.txt_mat.Text + " " + frm.txt_nom.Text : frm.txt_desc.Text;
                    txt_doc_per.Text = frm.txt_nro_doc.Text;
                    COD_INSTITUCION = frm.cbo_institucion.SelectedValue != null ? frm.cbo_institucion.SelectedValue.ToString() : "";//lo trae para el punto de venta
                    lbl_institucion.Text = frm.cbo_institucion.Text;//se vé la descripción pero no se graba el codigo institucion
                    //CARGAR_SUB_PUNTO_VENTA();
                    txt_numero.Focus();
                }
            }
        }
        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            boton = "NUEVO";
            btn_grabar.Visible = true;
            btn_grabar2.Visible = false;
            btn_grabar.Enabled = true;
            btn_imprimir.Enabled = true;
            btn_oc.Enabled = true;
            gb_oc.Enabled = true;
            TabControl1.SelectedTab = (TabPage2);
            Panel1.Visible = true;
            Panel2.Visible = false;
            //Panel0.Enabled = true;
            btn_mod.Visible = true;
            LIMPIAR_CABECERA();
            //  SGT_ORDEN();
            CBO_SUCURSAL.Select();
            campos_clave_modificacion(true);
            btnConsultaCliente.Visible = false;
            btnNuevoCliente.Visible = true;
            txt_numero.Enabled = true;
        }
        private void LIMPIAR_CABECERA()
        {
            if (CBO_SUCURSAL.SelectedIndex != -1)
            {
                string text = CBO_SUCURSAL.Text;
                CBO_SUCURSAL.SelectedIndex = -1;
                CBO_SUCURSAL.Text = text;
            }
            TXT_COD.Clear();
            TXT_DESC.Clear();
            txt_doc_per.Clear();
            //TXT_NI.Clear();
            CBO_MONEDA.SelectedIndex = 1;

            cbo_prog.SelectedIndex = 0;
            gb_oc.Enabled = true;
            //ch_dif.Enabled = true;
            cbo_prog.Enabled = true;

            btn_ajuste.Enabled = true;
            DGW_DET.Rows.Clear();
            TXT_TB.Text = "0.00";
            TXT_TD.Text = "0.00";
            TXT_TN.Text = "0.00";
            TXT_TT.Text = "0.00";
            TXT_TIGV.Text = "0.00";
            //ch_dif.Checked = false;
            txt_numero.Clear();

            cbo_tipo_planilla.SelectedIndex = 0;
            CBO_PAGO.SelectedIndex = 2;
            cbo_VENTA.SelectedIndex = 0;

            lbl_institucion.Text = "";

            TabControl2.SelectedTab = (TabPage3);
        }

        private void btn_oc_Click(object sender, EventArgs e)
        {
            DGW_CAB_DIALOG();
            //
            frmKit.ShowDialog();
            if (frmKit.DialogResult == DialogResult.OK)
            {
                INSERTAR_DE_DIALOG();
                HALLAR_TOTAL_OC();
                frmKit.Hide();
                btn_grabar.Focus();
            }
        }
        public void DGW_CAB_DIALOG()
        {
            DGW_CAB.Rows.Clear();
            kitBLL kiBLL = new kitBLL();
            DataTable dt = kiBLL.obtenerKitBLL();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow rw in dt.Rows)
                {
                    int idx = DGW_CAB.Rows.Add();
                    DataGridViewRow row = DGW_CAB.Rows[idx];
                    row.Cells[0].Value = rw[0].ToString();
                    row.Cells[1].Value = rw[1].ToString();
                }
                //
                int num = DGW_CAB.Rows.Count - 1;
                int num3 = num;
                frmKit.DGW_CAB.Rows.Clear();
                frmKit.DGW_DET.Rows.Clear();
                int i = 0;
                do
                {
                    //string x = DGW_CAB[0, i].Value.ToString();
                    frmKit.DGW_CAB.Rows.Add(DGW_CAB[0, i].Value.ToString(), DGW_CAB[1, i].Value.ToString());
                    i++;
                }
                while (i <= num3);
            }
        }
        private void INSERTAR_DE_DIALOG()
        {
            int num = frmKit.DGW_DET.Rows.Count - 1;
            string cod_kit = frmKit.COD_KIT;
            int num3 = num;
            int i = 0;
            decimal x = 0, imp = 0, iva = 0;

            do
            {

                if (CH_PV.Checked)
                {
                    x = Convert.ToDecimal(frmKit.DGW_DET[4, i].Value) * Convert.ToDecimal(frmKit.DGW_DET[5, i].Value);//cant*preuni
                    imp = x / (1 + (igv0 / 100));
                    iva = frmKit.DGW_DET.Rows[i].Cells["STATUS_IGV"].Value.ToString() == "0" ? 0 : x - imp;
                    DGW_DET.Rows.Add((DGW_DET.Rows.Count + 1).ToString("00"), frmKit.DGW_DET[0, i].Value.ToString(), frmKit.DGW_DET[1, i].Value.ToString(),
                    frmKit.DGW_DET[4, i].Value.ToString(), "0.000", "0.000",
                    frmKit.DGW_DET[5, i].Value.ToString(),
                    x, frmKit.DGW_DET.Rows[i].Cells["STATUS_IGV"].Value.ToString() == "0" ? "0.00" : TXT_IGV.Text, "0.00",
                    frmKit.DGW_DET.Rows[i].Cells["STATUS_IGV"].Value.ToString(), iva, "0.00", "0.00", "0.00",
                    "D", "", TXT_NRO_PARTE.Text, CODARTCLI, DESCARTCLI, PARTEARTCLI, "", "", COD_PRECIO2,
                    frmKit.DGW_DET[6, i].Value.ToString().ToLower() == "false" ? "0" : "1", cod_kit);
                }
                else
                {
                    x = Convert.ToDecimal(frmKit.DGW_DET[4, i].Value) * Convert.ToDecimal(frmKit.DGW_DET[5, i].Value);//cant*preuni
                    imp = x / (1 + (igv0 / 100));
                    iva = x * (igv0 / 100);
                    DGW_DET.Rows.Add((DGW_DET.Rows.Count + 1).ToString("00"), frmKit.DGW_DET[0, i].Value.ToString(), frmKit.DGW_DET[1, i].Value.ToString(),
                    frmKit.DGW_DET[4, i].Value.ToString(), "0.000", "0.000",
                    frmKit.DGW_DET[5, i].Value.ToString(),
                    x, frmKit.DGW_DET.Rows[i].Cells["STATUS_IGV"].Value.ToString() == "0" ? "0.00" : TXT_IGV.Text, "0.00",
                    frmKit.DGW_DET.Rows[i].Cells["STATUS_IGV"].Value.ToString(), iva, "0.00", "0.00", "0.00",
                    "D", "", TXT_NRO_PARTE.Text, CODARTCLI, DESCARTCLI, PARTEARTCLI, "", "", COD_PRECIO2,
                    frmKit.DGW_DET[6, i].Value.ToString().ToLower() == "false" ? "0" : "1", cod_kit);
                }
                i++;
            }
            while (i <= num3);
            int j = 0, cont = 0;
            cont = DGW_DET.Rows.Count - 1;
            if (CH_PV.Checked)
            {
                for (j = 0; j <= cont; j++)
                {
                    DGW_DET[7, j].Value = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(DGW_DET[7, j].Value.ToString());
                    //dgw_det[8, j].Value = frmKit.DGW_DET.Rows[i].Cells["STATUS_IGV"].Value.ToString()=="0" ? "0" : TXT_IGV.Text;
                    DGW_DET[11, j].Value = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(DGW_DET[11, j].Value.ToString());
                }
            }


        }
        private void HALLAR_TOTAL_OC()
        {
            decimal impor = 0, dscto = 0, igv = 0, neto = 0, total = 0;
            foreach (DataGridViewRow rw in DGW_DET.Rows)
            {
                if (rw.Cells["st_valor_referencial"].Value.ToString() == "0")
                {
                    impor = impor + Convert.ToDecimal(rw.Cells[7].Value);
                    igv = 0;//igv + Convert.ToDecimal(rw.Cells[11].Value);
                    dscto = dscto + Convert.ToDecimal(rw.Cells[12].Value);
                }
            }
            total = impor;
            neto = total;

            TXT_TB.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES((impor - igv).ToString());
            TXT_TD.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(dscto.ToString());
            TXT_TN.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES((impor - igv).ToString());
            TXT_TIGV.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(igv.ToString());
            TXT_TT.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(impor.ToString());
        }

        private void btn_grabar_Click(object sender, EventArgs e)
        {
            if (!validaGrabar())
                return;

            DialogResult rs = MessageBox.Show("¿ Esta seguro de crear un nuevo Contrato ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                ccTo.COD_SUCURSAL = CBO_SUCURSAL.SelectedValue.ToString();
                ccTo.NRO_DOC = txt_numero.Text;//txt_nro.Text + "-" + txt_numero1.Text;//LO CAMBIO POR TXT_NI
                ccTo.COD_PER = TXT_COD.Text;
                ccTo.COD_CLASE = CBO_CLASE.SelectedValue.ToString();
                ccTo.FE_AÑO = AÑO;
                ccTo.FE_MES = MES;
                ccTo.FECHA_DOC = DateTime.Now;
                ccTo.NRO_PRESUPUESTO = txt_numero.Text;
                ccTo.FECHA_PRE = DTP_DOC.Value;
                ccTo.COD_MONEDA = CBO_MONEDA.SelectedValue.ToString();
                ccTo.TIPO_CAMBIO = Convert.ToDecimal(TXT_TC.Text);
                ccTo.FORMA_PAGO = CBO_PAGO.SelectedValue.ToString();
                ccTo.STATUS_PV = CH_PV.Checked ? "1" : "0";
                ccTo.NRO_DIAS = NRO_DIAS1;
                ccTo.COD_PER_ELAB = COD_USU;
                ccTo.COD_PER_APROB = "";
                ccTo.STATUS_APROB = "1";
                ccTo.STATUS_ANUL = "0";
                ccTo.STATUS_CIERRE = "";
                ccTo.COD_VENDEDOR = "";
                ccTo.CONDICION_VENTA = cbo_VENTA.SelectedValue != null ? cbo_VENTA.SelectedValue.ToString() : "";
                ccTo.COD_CONTACTO = "";
                ccTo.FECHA_APROB = DateTime.Now;
                ccTo.TIPO_PRECIO = "";
                ccTo.OBSERVACION = "";
                ccTo.COD_MOV = cbo_movimiento.SelectedValue.ToString();
                ccTo.NRO_REPORTE = "";
                ccTo.FEC_REPORTE = DateTime.Now;
                ccTo.COD_PROGRAMA = cbo_prog.SelectedValue.ToString();
                ccTo.PERIODO = MES;
                ccTo.NRO_SEMANA = "";
                ccTo.TIPO_PLANILLA = cbo_tipo_planilla.SelectedValue.ToString();
                ccTo.COD_ALMACEN = "";
                ccTo.COD_NIVEL1 = "";
                ccTo.COD_NIVEL2 = "";
                ccTo.COD_NIVEL3 = "";
                ccTo.SUELDO_NETO = 0;
                ccTo.PRESTAMOS = 0;
                ccTo.JUDICIALES = 0;
                ccTo.OTROS_DSCTOS = 0;
                ccTo.IMPORTE_PROTECCION = 0;
                ccTo.NETO_COBRAR = 0;
                //idx0 = DGW_PRES_PTE.CurrentRow.Index;
                ccTo.NRO_CUOTAS = NRO_CUOTAS;
                ccTo.IMP_CUOTA_INICIAL = IMP_CUOTA_INICIAL;
                ccTo.IMP_CUOTA_MES = IMP_CUOTA_MES;
                ccTo.FEC_PRIMER_VENC = FEC_PRIMER_VENC;
                ccTo.NRO_DIAS_VENC = NRO_DIAS_VENC;
                ccTo.FEC_CUO_MEN = DateTime.Now;
                ccTo.STATUS_FAC = "0";
                ccTo.TIPO_PEDIDO = "";
                ccTo.STATUS_GUIA = "";
                ccTo.COD_REF = "";
                ccTo.NRO_REF = "";
                ccTo.NOMBRE_PC = NOMBRE_PC;
                ccTo.SERIE = "";
                ccTo.COD_SUB_PTO_VEN = "";
                ccTo.COD_CANAL_DSCTO = "";
                ccTo.COD_PTO_COB = "";
                ccTo.COD_TIPO_VENTA = "";
                ccTo.COD_MODALIDAD_VTA = "";
                ccTo.COD_LUG_VTA = "";
                ccTo.COD_INSTITUCION = COD_INSTITUCION;
                //DataTable dtDetalle = (DataTable)DGW_DET.DataSource;
                DT00.Rows.Clear();
                DT00 = HelpersBLL.obtenerDT(DGW_DET);
                TOTAL_CONTRATO = Convert.ToDecimal(TXT_TT.Text);//obtenerContratoTotal(DT00);//DT00.AsEnumerable().Sum(x => x.Field<decimal>("VANET"));
                ccTo.TOTAL_CONTRATO = TOTAL_CONTRATO;

                if (!ccBLL.adicionaInsertaContrato_dbf_BLL(ccTo, DT00, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("El Contrato se creo correctamente", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TabControl1.SelectedTab = TabPage1;
                    DATAGRID();
                    FOCO_NUEVO_REG2(txt_numero.Text);
                }
            }
        }
        private decimal obtenerContratoTotal(DataTable dt)
        {
            decimal tot = 0;
            foreach (DataRow rw in dt.Rows)
                tot += Convert.ToDecimal(rw["VANET"]);
            return tot;
        }
        private void FOCO_NUEVO_REG2(string cont2)
        {
            int i, cont = 0;
            cont = DGW.Columns.Count - 1;
            string nrocon = cont2;
            for (i = 0; i <= cont; i++)
            {
                if (nrocon == DGW.Rows[i].Cells["NRO_PRESUPUESTO"].Value.ToString().ToLower())
                {
                    DGW.CurrentCell = DGW.Rows[i].Cells["NRO_PRESUPUESTO"];
                    return;
                }
            }
        }
        private bool validaGrabar()
        {
            bool result = true;
            string errMensaje = "";
            int I = 0, CONT = 0;
            CONT = DGW_DET.Rows.Count - 1;
            for (I = 0; I <= CONT; I++)
            {
                if (DGW_DET[6, I].Value.ToString() == "" || DGW_DET[6, I].Value.ToString() == "0.000")
                {
                    MessageBox.Show("VERIFICA QUE TODOS LOS DETALLES TENGAN PRECIO UNITARIO !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    btn_agregar.Focus();
                    return result = false;
                }
            }
            if (DGW_DET.Rows.Count <= 0)
            {
                MessageBox.Show("CONTRATO SIN DETALLE !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btn_agregar.Focus();
                return result = false;
            }
            if (CBO_MONEDA.SelectedIndex <= -1)
            {
                MessageBox.Show("Elija la moneda !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                CBO_MONEDA.Focus();
                return result = false;
            }
            if (TXT_TC.Text == "0.0000" && CBO_MONEDA.SelectedValue.ToString() != "S")
            {
                MessageBox.Show("DEBE INGRESAR EL TIPO DE CAMBIO !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TXT_TC.Focus();
                return result = false;
            }
            if (CBO_SUCURSAL.SelectedIndex == -1)
            {
                MessageBox.Show("ELIJE LA SUCURSAL !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                CBO_SUCURSAL.Focus();
                return result = false;
            }
            if (CBO_CLASE.SelectedIndex == -1)
            {
                MessageBox.Show("ELIJE LA CLASE !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                CBO_CLASE.Focus();
                return result = false;
            }
            if (TXT_COD.Text.Trim() == "")
            {
                MessageBox.Show("INGRESE EL CODIGO DEL CLIENTE !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TXT_COD.Focus();
                return result = false;
            }
            if (TXT_DESC.Text.Trim() == "")
            {
                MessageBox.Show("INGRESE EL NOMBRE DEL CLIENTE !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TXT_DESC.Focus();
                return result = false;
            }
            if (txt_doc_per.Text.Trim() == "")
            {
                MessageBox.Show("INGRESE EL DNI !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_doc_per.Focus();
                return result = false;
            }
            if (txt_numero.Text.Trim() == "")
            {
                MessageBox.Show("INGRESEL EL NRO DE CONTRATO !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_numero.Focus();
                return result = false;
            }

            if (cbo_prog.SelectedIndex == -1)
            {
                MessageBox.Show("Elija el Programa !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_prog.Focus();
                return result = false;
            }

            if (cbo_tipo_planilla.SelectedIndex == -1)
            {
                MessageBox.Show("Elija el tipo de planilla !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_tipo_planilla.Focus();
                return result = false;
            }
            if (CBO_PAGO.SelectedIndex == -1)
            {
                MessageBox.Show("Elija el tipo de pago !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                CBO_PAGO.Focus();
                return result = false;
            }
            if (cbo_VENTA.SelectedIndex == -1 && CBO_PAGO.SelectedValue.ToString() == "03")//03 CREDITO
            {
                MessageBox.Show("Elija la condicion de venta !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_VENTA.Focus();
                return result = false;
            }
            if (!(DTP_DOC.Value.Date <= FECHA_GRAL.Date))
            {
                MessageBox.Show("La Fecha debe ser menor que la Fecha de Proceso !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                DTP_DOC.Focus();
                return result = false;
            }
            if (btn_grabar.Visible)
            {
                ccTo.COD_SUCURSAL = CBO_SUCURSAL.SelectedValue.ToString();
                ccTo.NRO_PRESUPUESTO = txt_numero.Text.Trim();
                if (ccBLL.VERIFICA_NRO_CONTRATO_BLL(ccTo, ref errMensaje))
                {
                    MessageBox.Show("El Nro de Contrato " + txt_numero.Text + " ya ha sido ingresado !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txt_numero.Focus();
                    return result = false;
                }
                else
                {
                    if (errMensaje != "")
                        MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return result;
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
                            lbl_institucion.Text = dgw_per.Rows[i].Cells["DESC_INST"].Value.ToString();

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
                    Panel1.Visible = true;
                    Panel1.SendToBack();
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
                    btnNuevoCliente_Click(sender, e);
                }//Gestion Comercial/compras/servicio/requiriento de servicio
                else if (dgw_per.Rows.Count > 0)
                {
                    DataRow[] rs = dtPersona.Select("[Nroº Doc] = '" + txt_doc_per.Text.Trim() + "'");
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
                        btnNuevoCliente_Click(sender, e);
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
                COD_INSTITUCION = dgw_per.Rows[idx].Cells["COD_INSTITUCION"].Value.ToString();
                lbl_institucion.Text = dgw_per.Rows[idx].Cells["DESC_INST"].Value.ToString();
                //CARGAR_SUB_PUNTO_VENTA();

                Panel_PER.Visible = false;
                //MostrarFormaPago();
                TabControl2.SelectedTab = TabPage3;
                gb_oc.Focus();
                //txt_numero.Focus();
                txt_doc_per.Focus();
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

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            if (!validaModificarEliminarAnularPrecontrato())
                return;

            boton = "MODIFICAR";
            btn_grabar.Visible = false;
            btn_grabar2.Visible = true;
            btn_grabar2.Enabled = true;
            btn_imprimir.Enabled = true;
            btn_oc.Enabled = true;
            gb_oc.Enabled = true;
            TabControl1.SelectedTab = TabPage2;
            Panel1.Visible = true;
            Panel2.Visible = false;
            Panel0.Enabled = true;
            COD_INSTITUCION = DGW.CurrentRow.Cells["COD_INSTITUCION"].Value.ToString();
            lbl_institucion.Text = DGW.CurrentRow.Cells["DESC_INST"].Value.ToString();
            //CARGAR_SUB_PUNTO_VENTA();//llena punto de venta
            //llenaLugarVenta();//llena lugar de venta
            LIMPIAR_CABECERA();
            CARGAR_CABECERA(DGW);
            CARGAR_DETALLES_DGW();
            //gb_oc.Enabled = false;
            CH_PV.Enabled = false;
            //txt_oc.Enabled = true;
            //dtp_oc.Enabled = false;
            //txt_cod2.Enabled = false;
            //txt_desc2.Enabled = false;
            campos_clave_modificacion(false);
            txt_numero.Enabled = false;
            HALLAR_TOTAL_OC();
            btn_agregar.Focus();
        }
        private void campos_clave_modificacion(bool val)
        {
            CBO_SUCURSAL.Enabled = val;
            CBO_CLASE.Enabled = val;
            TXT_COD.Enabled = val;
            TXT_DESC.Enabled = val;
            txt_doc_per.Enabled = val;
        }
        private bool validaModificarEliminarAnularPrecontrato()
        {
            bool result = true;
            try
            {
                int index = DGW.CurrentRow.Index;
            }
            catch (Exception)
            {
                MessageBox.Show("DEBE ELEGIR UN REGISTRO !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return result = false;
            }

            return result;
        }
        private void BTN_CONSULTA_Click(object sender, EventArgs e)
        {
            gb_oc.Enabled = false;
            Panel0.Enabled = false;
            btn_oc.Enabled = false;
            btn_grabar.Enabled = false;
            btn_grabar2.Enabled = false;
            CARGAR_CABECERA(DGW);
            CARGAR_DETALLES_DGW();
            HALLAR_TOTAL_OC();
            TabControl1.SelectedTab = TabPage2;
        }
        private void CARGAR_CABECERA(DataGridView dgw)
        {
            txt_numero.Text = dgw.CurrentRow.Cells["NRO_DOC"].Value.ToString();
            DTP_DOC.Value = Convert.ToDateTime(dgw.CurrentRow.Cells["FECHA_PRE"].Value);
            CBO_PAGO.SelectedValue = dgw.CurrentRow.Cells["FORMA_PAGO"].Value;
            cbo_VENTA.SelectedValue = dgw.CurrentRow.Cells["CONDICION_VENTA"].Value;
            cbo_tipo_planilla.SelectedValue = dgw.CurrentRow.Cells["TIPO_PLANILLA"].Value;
            cbo_prog.SelectedValue = dgw.CurrentRow.Cells["COD_PROGRAMA"].Value;
            CBO_MONEDA.SelectedValue = dgw.CurrentRow.Cells["COD_MONEDA"].Value;
            TXT_COD.Text = dgw.CurrentRow.Cells["COD_PER"].Value.ToString();
            TXT_DESC.Text = dgw.CurrentRow.Cells["Cliente"].Value.ToString();
            txt_doc_per.Text = dgw.CurrentRow.Cells["DNI"].Value.ToString();
            CBO_SUCURSAL.SelectedValue = dgw.CurrentRow.Cells["COD_SUCURSAL"].Value;
            CBO_CLASE.SelectedValue = dgw.CurrentRow.Cells["COD_CLASE"].Value;
        }
        private void CARGAR_DETALLES_DGW()
        {
            DGW_DET.Rows.Clear();
            ccdTo.COD_CLASE = CBO_CLASE.SelectedValue.ToString();
            ccdTo.COD_SUCURSAL = CBO_SUCURSAL.SelectedValue.ToString();
            ccdTo.COD_PER = TXT_COD.Text;
            //ccdTo.NRO_DOC = txt_numero.Text;
            ccdTo.NRO_DOC = DGW.CurrentRow.Cells["NRO_DOC"].Value.ToString();
            ccdTo.FE_AÑO = DGW.CurrentRow.Cells["FE_AÑO"].Value.ToString();
            ccdTo.FE_MES = DGW.CurrentRow.Cells["FE_MES"].Value.ToString();
            DataTable dt = ccdBLL.obtenerContratoDetalleContratoBLL(ccdTo);
            if (dt.Rows.Count > 0)
            {
                DGW_DET.Rows.Clear();
                foreach (DataRow rw in dt.Rows)
                {
                    int rowId = DGW_DET.Rows.Add();
                    DataGridViewRow row = DGW_DET.Rows[rowId];
                    //row.Cells["NUDOC1"].Value = rw["NRO_PRESUPUESTO"].ToString();
                    row.Cells["NUIT1"].Value = rw["ITEM"].ToString();
                    //row.Cells["FEDOC1"].Value = Convert.ToDateTime(DGW.CurrentRow.Cells["FECHA_DOC"].Value);//rw["FEDOC"].ToString();
                    //row.Cells["CDCTE1"].Value = rw["NRO_PRESUPUESTO"].ToString();
                    row.Cells["CDART"].Value = rw["COD_ARTICULO"].ToString();
                    row.Cells["DSART"].Value = rw["DESC_ARTICULO"].ToString();
                    row.Cells["CADOC"].Value = rw["CANTIDAD_PED"].ToString();
                    row.Cells["PRVAC"].Value = rw["PRECIO_UNIT"].ToString();
                    row.Cells["PODES"].Value = rw["POR_DSCTO"].ToString();
                    row.Cells["POIGV"].Value = rw["POR_IGV"].ToString();
                    row.Cells["VANET"].Value = rw["VALOR_COMPRA"].ToString();
                    row.Cells["VADES"].Value = rw["VALOR_DSCTO"].ToString();
                    row.Cells["VAIGV"].Value = rw["VALOR_IGV"].ToString();
                    //row.Cells["FECTE"].Value = Convert.ToDateTime(DGW.CurrentRow.Cells["FECHA_DOC"].Value);//rw["FECTE"].ToString();
                    row.Cells["CDD_H"].Value = rw["COD_D_H"].ToString();
                    row.Cells["DSOBS"].Value = rw["OBSERVACION"].ToString();
                    row.Cells["ST_VALOR_REFERENCIAL"].Value = rw["ST_VALOR_REFERENCIAL"].ToString() == "True" ? "1" : "0";//obtenerValorReferencial(rw["COD_ARTICULO"].ToString());//rw["ST_VALOR_REFERENCIAL"].ToString() == "True" ? "VALOR REFERENCIAL" : "PRECIO UNITARIO";
                    row.Cells["cod_kit"].Value = rw["COD_KIT"].ToString();
                }
            }
        }

        private void btn_nuevo2_Click(object sender, EventArgs e)
        {
            boton = "NUEVO";
            gb_oc.Enabled = true;
            btn_oc.Enabled = true;
            btn_grabar.Visible = true;
            btn_grabar2.Visible = false;
            btn_grabar.Enabled = true;
            btn_imprimir.Enabled = false;
            TabControl1.SelectedTab = TabPage2;
            Panel1.Visible = true;
            Panel2.Visible = false;
            //Panel0.Enabled = true;
            //ListaIngresos.Clear();
            LIMPIAR_CABECERA();
            txt_numero.Enabled = true;
            CBO_SUCURSAL.Focus();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            TabControl1.SelectedTab = TabPage1;
            btn_nuevo.Select();
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (!validaModificarEliminarAnularPrecontrato())
                return;

            string errMensaje = "";
            DialogResult rs = MessageBox.Show("¿ Esta seguro de eliminar el contrato Nº " + DGW.CurrentRow.Cells["NRO_DOC"].Value.ToString() + " ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                ccTo.COD_SUCURSAL = DGW.CurrentRow.Cells["COD_SUCURSAL"].Value.ToString();
                ccTo.COD_CLASE = DGW.CurrentRow.Cells["COD_CLASE"].Value.ToString();
                ccTo.COD_PER = DGW.CurrentRow.Cells["COD_PER"].Value.ToString();
                ccTo.NRO_DOC = DGW.CurrentRow.Cells["NRO_DOC"].Value.ToString();
                ccTo.FE_AÑO = null;
                ccTo.FE_MES = null;
                if (!ccBLL.ELIMINAR_PEDIDOBLL(ccTo, ref errMensaje))
                {
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("El Contrato se eliminó !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                DATAGRID();
                btn_nuevo.Select();
            }
        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            TabPage3.Select();
            //gb_oc.Enabled = false;
            //CH_PV.Enabled = false;
            //ch_dif.Enabled = false;
            cbo_prog.Enabled = false;
            //txt_oc.Enabled = true;
            //dtp_oc.Enabled = false;
            //txt_cod2.Enabled = false;
            //txt_desc2.Enabled = false;
            Panel1.Visible = false;
            Panel2.Visible = true;
            btn_guardar2.Visible = true;
            btn_mod2.Visible = false;
            LIMPIAR_DETALLES();
            TXT_COD_PRO.Focus();
        }
        private void LIMPIAR_DETALLES()
        {
            TXT_COD_PRO.Clear();
            TXT_DESC_PRO.Clear();
            TXT_NRO_PARTE.Clear();
            TXT_CANT.Clear();
            TXT_DSCTO.Text = "0.00";
            TXT_PU.Text = "0.000";
            txt_pu1.Text = "0.00";
            txt_bruto1.Text = "0.00";
            txt_dscto1.Text = "0.00";
            txt_neto1.Text = "0.00";
            txt_igv1.Text = "0.00";
            txt_total1.Text = "0.00";
            CH_IGV.Checked = true;
            TXT_COD_PRO.Enabled = true;
            TXT_DESC_PRO.Enabled = true;
            TXT_NRO_PARTE.Enabled = true;
            TXT_CANT.Enabled = true;
        }

        private void btn_mod2_Click(object sender, EventArgs e)
        {
            if (!validaModificaUnRegistro())
                return;
            string str = CH_IGV.Checked ? "1" : "0";
            int idx = DGW_DET.CurrentRow.Index;
            DGW_DET[1, idx].Value = TXT_COD_PRO.Text;
            DGW_DET[2, idx].Value = TXT_DESC_PRO.Text;
            DGW_DET[3, idx].Value = HelpersBLL.OBTIENE_PRECIO_TRES_DECIMALES(TXT_CANT.Text);
            DGW_DET[6, idx].Value = HelpersBLL.OBTIENE_PRECIO_TRES_DECIMALES(txt_pu1.Text);
            DGW_DET[7, idx].Value = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES((Convert.ToDecimal(TXT_PU.Text) * Convert.ToDecimal(TXT_CANT.Text)).ToString());//HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(txt_bruto1.Text);
            DGW_DET[8, idx].Value = TXT_IGV.Text;
            DGW_DET[9, idx].Value = TXT_DSCTO.Text;
            DGW_DET[10, idx].Value = str;
            DGW_DET[11, idx].Value = txt_igv1.Text;
            DGW_DET[12, idx].Value = txt_dscto1.Text;
            DGW_DET[16, idx].Value = obs.txt_obs.Text;
            DGW_DET.Rows[idx].Cells["st_valor_referencial"].Value = chk_st_val_ref.Checked ? "1" : "0";
            //DGW_DET[17, idx].Value = STATUS_DSCTO;
            //DGW_DET[18, idx].Value = COD_PRECIO2;
            //
            HALLAR_TOTAL_OC();
            Panel2.Visible = false;
            Panel1.Visible = true;
            btn_agregar.Focus();
        }
        private bool validaModificaUnRegistro()
        {
            bool result = true;
            if (TXT_COD_PRO.Text.Trim() == "")
            {
                MessageBox.Show("ELIJA EL PRODUCTO !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TXT_COD_PRO.Focus();
                return result = false;
            }
            if (Panel_PRO.Visible)
            {
                MessageBox.Show("ELIJA EL PRODUCTO !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                DGW_PRO.Focus();
                return result = false;
            }
            if (Convert.ToDecimal(TXT_CANT.Text) == 0)
            {
                MessageBox.Show("INGRESE UNA CANTIDAD !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TXT_CANT.Focus();
                return result = false;
            }
            return result;
        }

        private void btn_cancelar2_Click(object sender, EventArgs e)
        {
            Panel1.Visible = true;
            Panel2.Visible = false;
            btn_agregar.Select();
        }

        private void TXT_COD_PRO_Leave(object sender, EventArgs e)
        {
            if (TXT_COD_PRO.Text.Trim() != "")
            {
                if (DGW_PRO.Rows.Count > 0)
                {
                    DGW_PRO.Sort(DGW_PRO.Columns[0], System.ComponentModel.ListSortDirection.Ascending);
                    int i = 0, num2 = 0;
                    num2 = DGW_PRO.Rows.Count - 1;
                    do
                    {
                        if (TXT_COD_PRO.Text.ToLower() == DGW_PRO[0, i].Value.ToString().ToLower())
                        {
                            TXT_COD_PRO.Text = DGW_PRO[0, i].Value.ToString();
                            TXT_DESC_PRO.Text = DGW_PRO[1, i].Value.ToString();
                            TXT_NRO_PARTE.Text = DGW_PRO[2, i].Value.ToString();
                            CH_IGV.Checked = true;
                            if (DGW_PRO[3, i].Value.ToString() == "0")
                                CH_IGV.Checked = false;

                            Panel_PRO.Visible = false;
                            TXT_CANT.Focus();
                            return;
                        }
                        if (DGW_PRO[0, i].Value.ToString().Length >= TXT_COD_PRO.TextLength)
                        {
                            if (TXT_COD_PRO.Text.ToLower() == DGW_PRO[0, i].Value.ToString().ToLower().Substring(0, TXT_COD_PRO.TextLength).ToLower())
                            {
                                DGW_PRO.CurrentCell = DGW_PRO.Rows[i].Cells[0];
                                break;
                            }
                        }
                        DGW_PRO.CurrentCell = DGW_PRO.Rows[0].Cells[0];
                        i += 1;
                    }
                    while (i <= num2);
                    Panel_PRO.Visible = true;
                    DGW_PRO.Visible = true;
                    DGW_PRO.Focus();
                }
                else
                {
                    MessageBox.Show("NO EXISTEN PRODUCTOS DE LA CLASE " + CBO_CLASE.Text, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void TXT_DESC_PRO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && TXT_DESC_PRO.Text.Trim() != "")
            {
                if (DGW_PRO.Rows.Count > 0)
                {
                    DGW_PRO.Sort(DGW_PRO.Columns[1], System.ComponentModel.ListSortDirection.Ascending);
                    int i = 0, num2 = 0;
                    num2 = DGW_PRO.Rows.Count - 1;
                    do
                    {

                        if (TXT_DESC_PRO.Text.ToLower() == DGW_PRO[1, i].Value.ToString().ToLower().Substring(0, TXT_DESC_PRO.TextLength).ToLower())
                        {
                            DGW_PRO.CurrentCell = DGW_PRO.Rows[i].Cells[0];
                            break;
                        }
                        DGW_PRO.CurrentCell = DGW_PRO.Rows[0].Cells[0];
                        i += 1;
                    }
                    while (i <= num2);
                    Panel_PRO.Visible = true;
                    DGW_PRO.Visible = true;
                    DGW_PRO.Focus();
                }
                else
                {
                    MessageBox.Show("NO EXISTEN PRODUCTOS DE LA CLASE " + CBO_CLASE.Text, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void TXT_CANT_Leave(object sender, EventArgs e)
        {
            TXT_CANT.Text = HelpersBLL.OBTIENE_PRECIO_TRES_DECIMALES(TXT_CANT.Text);
        }

        private void TXT_PU_KeyDown(object sender, KeyEventArgs e)
        {
            if (HelpersBLL.IsNumeric(TXT_CANT.Text) && HelpersBLL.IsNumeric(TXT_PU.Text))
            {
                HALLAR_VALOR_VENTA();
            }
        }

        private void TXT_PU_Leave(object sender, EventArgs e)
        {
            TXT_PU.Text = HelpersBLL.OBTIENE_PRECIO_TRES_DECIMALES(TXT_PU.Text);
        }
        private void HALLAR_VALOR_VENTA()
        {
            if (TXT_CANT.Text.Trim() == "" || TXT_DSCTO.Text.Trim() == "" || TXT_PU.Text.Trim() == "")
            { }
            else
            {
                if (CH_PV.Checked)
                    txt_pu1.Text = TXT_PU.Text;//(Convert.ToDecimal(TXT_PU.Text) * (100 / (100 + igv0))).ToString();
                else
                    txt_pu1.Text = TXT_PU.Text;

                txt_bruto1.Text = (((Convert.ToDecimal(txt_pu1.Text) * Convert.ToDecimal(TXT_CANT.Text)))).ToString();
                if (ch_dscto.Checked)
                    txt_dscto1.Text = (Convert.ToDecimal(txt_bruto1.Text) * Convert.ToDecimal(TXT_DSCTO.Text) / 100).ToString();
                else
                    txt_dscto1.Text = TXT_DSCTO.Text;

                txt_neto1.Text = (((Convert.ToDecimal(txt_bruto1.Text) - Convert.ToDecimal(txt_dscto1.Text)))).ToString();
                txt_igv1.Text = (((Convert.ToDecimal(txt_neto1.Text) * (Convert.ToDecimal(TXT_IGV.Text) / 100)))).ToString();
                txt_total1.Text = (Decimal.Add(Decimal.Parse(txt_neto1.Text), Decimal.Parse(txt_igv1.Text))).ToString();
                txt_neto1.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(txt_neto1.Text);
                txt_igv1.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(txt_igv1.Text);
                txt_total1.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(txt_total1.Text);
                txt_dscto1.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(txt_dscto1.Text);
            }
        }

        private void CH_IGV_CheckedChanged(object sender, EventArgs e)
        {
            if (CH_IGV.Checked)
            {
                STATUS_IGV = "1";
                TXT_IGV.Text = igv0.ToString();
            }
            else
            {
                STATUS_IGV = "0";
                TXT_IGV.Text = "0.00";
            }
            HALLAR_VALOR_VENTA();
        }

        private void btn_obs_Click(object sender, EventArgs e)
        {
            obs.txt_obs.MaxLength = 800;
            obs.Show();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (TXT_COD_PRO.Text.Trim() == "")
            {
                MessageBox.Show("Debe elegir un Producto !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TXT_COD_PRO.Focus();
            }
            else if (Panel_PRO.Visible)
            {
                MessageBox.Show("Debe elegir un Producto", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                DGW_PRO.Focus();
            }
            else
            {
                COD_CLASE = CBO_CLASE.SelectedValue.ToString();
                DIALOGOS.CONSULTA_SALDO_X_ARTICULO frm = new DIALOGOS.CONSULTA_SALDO_X_ARTICULO(COD_CLASE, TXT_COD_PRO.Text, TXT_DESC_PRO.Text, TIPO_USU, COD_USU);
                frm.ShowDialog();
            }
        }
        private void CBO_CLASE_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBO_CLASE.SelectedIndex != -1)
            {
                CARGAR_PRODUCTOS();
            }
        }
        private void CARGAR_PRODUCTOS()
        {
            articuloClaseBLL arcBLL = new articuloClaseBLL();
            articuloClaseTo arcTo = new articuloClaseTo();
            arcTo.COD_CLASE = CBO_CLASE.SelectedValue.ToString();
            DataTable dt = arcBLL.obtenerDGW_Articulos_ClaseBLL(arcTo);
            DGW_PRO.DataSource = dt;
            //DGW_PRO.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("arial",8.0M,System.Drawing.FontStyle.Bold);
            DGW_PRO.Columns[3].Visible = false;
            DGW_PRO.Columns[4].Visible = false;
            DGW_PRO.Columns[0].Width = 80;
            DGW_PRO.Columns[1].Width = 240;
        }
        private void DGW_PRO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TXT_COD_PRO.Text = DGW_PRO[0, DGW_PRO.CurrentRow.Index].Value.ToString();
                TXT_DESC_PRO.Text = DGW_PRO[1, DGW_PRO.CurrentRow.Index].Value.ToString();
                TXT_NRO_PARTE.Text = DGW_PRO[2, DGW_PRO.CurrentRow.Index].Value.ToString();
                CH_IGV.Checked = true;
                if (DGW_PRO[3, DGW_PRO.CurrentRow.Index].Value.ToString() == "0")
                    CH_IGV.Checked = false;


                Panel_PRO.Visible = false;
                kl3.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Panel_PRO.Visible = false;
                TXT_COD_PRO.Clear();
                TXT_DESC_PRO.Clear();
                TXT_NRO_PARTE.Clear();
                TXT_COD_PRO.Focus();
            }
        }

        private void btn_mod_Click(object sender, EventArgs e)
        {
            try
            {
                int num = DGW_DET.CurrentRow.Index;
            }
            catch (Exception)
            {
                MessageBox.Show("DEBE ELEGIR UN REGISTRO !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            TXT_COD_PRO.Enabled = false;
            TXT_DESC_PRO.Enabled = false;
            TXT_NRO_PARTE.Enabled = false;
            Panel_PRO.Visible = false;
            btn_guardar2.Visible = false;
            btn_mod2.Visible = true;
            Panel1.Visible = false;
            Panel2.Visible = true;
            LIMPIAR_DETALLES();
            CARGAR_DETALLE1();
            HALLAR_VALOR_VENTA();
            TXT_CANT.Focus();
        }
        private void CARGAR_DETALLE1()
        {
            int idx = DGW_DET.CurrentRow.Index;
            TXT_COD_PRO.Text = DGW_DET[1, idx].Value.ToString();
            TXT_DESC_PRO.Text = DGW_DET[2, idx].Value.ToString();
            TXT_COD_PRO.Focus();
            TXT_PU.Focus();
            //COD_PRECIO2 = DGW_DET[18, idx].Value.ToString();
            decimal PrecioUnitario = Convert.ToDecimal(DGW_DET[6, idx].Value);
            TXT_CANT.Text = DGW_DET[3, idx].Value.ToString();
            TXT_IGV.Text = DGW_DET[8, idx].Value.ToString();
            if (CH_PV.Checked)
            {
                TXT_PU.Text = DGW_DET[6, idx].Value.ToString();//(PrecioUnitario + (PrecioUnitario * (Convert.ToDecimal(TXT_IGV.Text) / 100))).ToString();
                TXT_PU.Text = HelpersBLL.OBTIENE_PRECIO_TRES_DECIMALES(TXT_PU.Text);
            }
            else
                TXT_PU.Text = HelpersBLL.OBTIENE_PRECIO_TRES_DECIMALES(TXT_PU.Text);

            txt_bruto1.Text = DGW_DET[7, idx].Value.ToString();
            TXT_DSCTO.Text = DGW_DET[9, idx].Value.ToString();
            if (DGW_DET.Rows[idx].Cells["ST_IGV"].Value.ToString() == "1")
                CH_IGV.Checked = true;
            else
                CH_IGV.Checked = false;
            obs.txt_obs.Text = DGW_DET[16, idx].Value.ToString();
            //if (DGW_DET[17, idx].Value.ToString() == "1")
            //    ch_dscto.Checked = true;
            //else
            //    ch_dscto.Checked = false;

        }

        private void btn_eliminar2_Click(object sender, EventArgs e)
        {
            int idx = -1;
            try
            {
                idx = DGW_DET.CurrentRow.Index;
            }
            catch (Exception)
            {
                MessageBox.Show("DEBE DE ELEGIR UN REGISTRO !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (Convert.ToDecimal(DGW_DET[4, idx].Value) != 0)
            {
                MessageBox.Show("EL DETALLE YA SE INGRESO !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            //else if (Convert.ToDecimal(DGW_DET[5, idx].Value) != 0)
            //{
            //    MessageBox.Show("EL DETALLE SE HA ANULADO !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //}
            else
            {
                DialogResult rs = MessageBox.Show("¿ ESTA SEGURO DE ELIMINAR EL REGISTRO ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    DGW_DET.Rows.RemoveAt(DGW_DET.CurrentRow.Index);
                }
                HALLAR_TOTAL_OC();
            }
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            CARGAR_PERSONAS();
        }

        private void btn_grabar2_Click(object sender, EventArgs e)
        {
            if (!validaGrabar())
                return;

            DialogResult rs = MessageBox.Show("¿ Esta seguro de modificar el Contrato ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                ccTo.COD_SUCURSAL = CBO_SUCURSAL.SelectedValue.ToString();
                ccTo.NRO_DOC = txt_numero.Text;//txt_nro.Text + "-" + txt_numero1.Text;//LO CAMBIO POR TXT_NI
                ccTo.COD_PER = TXT_COD.Text;
                ccTo.COD_CLASE = CBO_CLASE.SelectedValue.ToString();
                ccTo.FE_AÑO = AÑO;
                ccTo.FE_MES = MES;
                ccTo.FECHA_DOC = DateTime.Now;
                ccTo.NRO_PRESUPUESTO = txt_numero.Text;
                ccTo.FECHA_PRE = DTP_DOC.Value;
                ccTo.COD_MONEDA = CBO_MONEDA.SelectedValue.ToString();
                ccTo.TIPO_CAMBIO = Convert.ToDecimal(TXT_TC.Text);
                ccTo.FORMA_PAGO = CBO_PAGO.SelectedValue.ToString();
                ccTo.STATUS_PV = CH_PV.Checked ? "1" : "0";
                ccTo.NRO_DIAS = NRO_DIAS1;
                ccTo.COD_PER_ELAB = COD_USU;
                ccTo.COD_PER_APROB = "";
                ccTo.STATUS_APROB = "1";
                ccTo.STATUS_ANUL = "0";
                ccTo.STATUS_CIERRE = "";
                ccTo.COD_VENDEDOR = "";
                ccTo.CONDICION_VENTA = cbo_VENTA.SelectedValue != null ? cbo_VENTA.SelectedValue.ToString() : "";
                ccTo.COD_CONTACTO = "";
                ccTo.FECHA_APROB = DateTime.Now;
                ccTo.TIPO_PRECIO = "";
                ccTo.OBSERVACION = "";
                ccTo.COD_MOV = cbo_movimiento.SelectedValue.ToString();
                ccTo.NRO_REPORTE = "";
                ccTo.FEC_REPORTE = DateTime.Now;
                ccTo.COD_PROGRAMA = cbo_prog.SelectedValue.ToString();
                ccTo.PERIODO = MES;
                ccTo.NRO_SEMANA = "";
                ccTo.TIPO_PLANILLA = cbo_tipo_planilla.SelectedValue.ToString();
                ccTo.COD_ALMACEN = "";
                ccTo.COD_NIVEL1 = "";
                ccTo.COD_NIVEL2 = "";
                ccTo.COD_NIVEL3 = "";
                ccTo.SUELDO_NETO = 0;
                ccTo.PRESTAMOS = 0;
                ccTo.JUDICIALES = 0;
                ccTo.OTROS_DSCTOS = 0;
                ccTo.IMPORTE_PROTECCION = 0;
                ccTo.NETO_COBRAR = 0;
                //idx0 = DGW_PRES_PTE.CurrentRow.Index;
                ccTo.NRO_CUOTAS = NRO_CUOTAS;
                ccTo.IMP_CUOTA_INICIAL = IMP_CUOTA_INICIAL;
                ccTo.IMP_CUOTA_MES = IMP_CUOTA_MES;
                ccTo.FEC_PRIMER_VENC = FEC_PRIMER_VENC;
                ccTo.NRO_DIAS_VENC = NRO_DIAS_VENC;
                ccTo.FEC_CUO_MEN = DateTime.Now;
                ccTo.STATUS_FAC = "0";
                ccTo.TIPO_PEDIDO = "";
                ccTo.STATUS_GUIA = "";
                ccTo.COD_REF = "";
                ccTo.NRO_REF = "";
                ccTo.NOMBRE_PC = NOMBRE_PC;
                ccTo.SERIE = "";
                ccTo.COD_SUB_PTO_VEN = "";
                ccTo.COD_CANAL_DSCTO = "";
                ccTo.COD_PTO_COB = "";
                ccTo.COD_TIPO_VENTA = "";
                ccTo.COD_MODALIDAD_VTA = "";
                ccTo.COD_LUG_VTA = "";
                ccTo.COD_INSTITUCION = COD_INSTITUCION;
                //DataTable dtDetalle = (DataTable)DGW_DET.DataSource;
                DT00.Rows.Clear();
                DT00 = HelpersBLL.obtenerDT(DGW_DET);
                TOTAL_CONTRATO = Convert.ToDecimal(TXT_TT.Text);//obtenerContratoTotal(DT00);//DT00.AsEnumerable().Sum(x => x.Field<decimal>("VANET"));
                ccTo.TOTAL_CONTRATO = TOTAL_CONTRATO;

                if (!ccBLL.modificarContratoDirectoFacturacionBLL(ccTo, DT00, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("El Contrato se modificó correctamente", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TabControl1.SelectedTab = TabPage1;
                    DATAGRID();
                    FOCO_NUEVO_REG2(txt_numero.Text);
                }
            }
        }

        private void CBO_PAGO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBO_PAGO.SelectedValue != null)
            {
                if (CBO_PAGO.SelectedValue.ToString() == "03")
                    cbo_VENTA.Enabled = true;
                else
                {
                    cbo_VENTA.SelectedIndex = -1;
                    cbo_VENTA.Enabled = false;
                    //txt_nro_dias.Text = "0";
                }
            }
        }

        private void btn_guardar2_Click(object sender, EventArgs e)
        {
            if (!validaIngresoArticulo())
                return;
            HALLAR_VALOR_VENTA();
            string preunit = HelpersBLL.OBTIENE_PRECIO_TRES_DECIMALES(txt_pu1.Text);
            string cant = HelpersBLL.OBTIENE_PRECIO_TRES_DECIMALES(TXT_CANT.Text);
            //string impor = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(txt_bruto1.Text);
            string impor = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES((Convert.ToDecimal(TXT_PU.Text) * Convert.ToDecimal(TXT_CANT.Text)).ToString());
            DGW_DET.Rows.Add(hallar_item(DGW_DET.Rows.Count), TXT_COD_PRO.Text, TXT_DESC_PRO.Text,
                cant, "0.000", "0.000",
                preunit,
                impor, TXT_IGV.Text, TXT_DSCTO.Text, STATUS_IGV, txt_igv1.Text, txt_dscto1.Text, "0.00", "0.00",
                "D", obs.txt_obs.Text, TXT_NRO_PARTE.Text, CODARTCLI, DESCARTCLI, PARTEARTCLI, "", "", COD_PRECIO2,
                chk_st_val_ref.Checked ? "1" : "0");//0 indica que el articulo ingresado individualmente entra como st_valor_referencial=0, o sea no es regalo, este campo no esta en la tabla de articulos sino en el de kit_detalle
            HALLAR_TOTAL_OC();
            LIMPIAR_DETALLES();
            TXT_COD_PRO.Focus();
        }
        private string hallar_item(int it)
        {
            string ite = (it + 1).ToString();
            return ite.PadLeft(2, '0');
        }
        private bool validaIngresoArticulo()
        {
            bool result = true;
            if (TXT_COD_PRO.Text == "")
            {
                MessageBox.Show("ELIJA EL PRODUCTO", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TXT_COD_PRO.Focus();
                return result = false;
            }
            if (Panel_PRO.Visible == true)
            {
                MessageBox.Show("ELIJA EL PRODUCTO", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                DGW_PRO.Focus();
                return result = false;
            }
            if (TXT_CANT.Text == "0.00")
            {
                MessageBox.Show("INGRESA LA CANTIDAD", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TXT_CANT.Focus();
                return result = false;
            }
            else if (TXT_DSCTO.Text == "")
                TXT_DSCTO.Text = "0.00";
            return result;
        }

        private void cbo_VENTA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_VENTA.SelectedValue != null)
            {
                int nro_dias = 0;
                if (cbo_VENTA.SelectedIndex != -1)
                {
                    DataRow[] rs = dtCondVenta.Select("COD_TIPO = '" + cbo_VENTA.SelectedValue.ToString() + "'");
                    foreach (DataRow r in rs)
                    {
                        nro_dias = Convert.ToInt32(r["NRO_DIAS"]);
                    }
                    NRO_DIAS1 = nro_dias;
                    //DTP_VEN.Value.AddDays(nro_dias);
                    //DTP_VEN.Value = DTP_DOC.Value.AddDays(nro_dias);
                }
            }
        }

        private void DTP_DOC_ValueChanged(object sender, EventArgs e)
        {
            OBTENER_TIPO_CAMBIO();
        }

        private void txt_numero_Leave(object sender, EventArgs e)
        {
            //string errMensaje = "";
            //if (btn_grabar.Visible)
            //{
            //    ccTo.COD_SUCURSAL = CBO_SUCURSAL.SelectedValue.ToString();
            //    ccTo.NRO_PRESUPUESTO = txt_numero.Text.Trim();
            //    if (ccBLL.VERIFICA_NRO_CONTRATO_BLL(ccTo, ref errMensaje))
            //    {
            //        MessageBox.Show("El Nro de Contrato " + txt_numero.Text + " ya ha sido ingresado !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //        txt_numero.Focus();
            //        //return result = false;
            //    }
            //    else
            //    {
            //        if (errMensaje != "")
            //            MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
        }

        private void txt_letra_TextChanged(object sender, EventArgs e)
        {
            int i;
            if (ch_cod.Checked)
            {
                txt_letra.Focus();
                for (i = 0; i < DGW.Rows.Count; i++)
                {
                    if (txt_letra.TextLength <= DGW.Rows[i].Cells["NRO_PRESUPUESTO"].Value.ToString().Length)
                    {
                        if (txt_letra.Text.ToLower() == DGW.Rows[i].Cells["NRO_PRESUPUESTO"].Value.ToString().Substring(0, txt_letra.TextLength).ToLower())
                        {
                            DGW.CurrentCell = DGW.Rows[i].Cells["NRO_PRESUPUESTO"];
                            break;
                        }
                    }

                }
            }
            else if (ch_rs.Checked)
            {
                txt_letra.Focus();
                for (i = 0; i < DGW.Rows.Count; i++)
                {
                    if (txt_letra.TextLength <= DGW.Rows[i].Cells["Cliente"].Value.ToString().Length)
                    {
                        if (txt_letra.Text.ToLower() == DGW.Rows[i].Cells["Cliente"].Value.ToString().Substring(0, txt_letra.TextLength).ToLower())
                        {
                            DGW.CurrentCell = DGW.Rows[i].Cells["Cliente"];
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
                DGW.Sort(DGW.Columns["NRO_PRESUPUESTO"], System.ComponentModel.ListSortDirection.Ascending);
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
                DGW.Sort(DGW.Columns["Cliente"], System.ComponentModel.ListSortDirection.Ascending);
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
            for (i = 0; i < DGW.Rows.Count; i++)
            {
                for (f = 0; f <= DGW.Rows[i].Cells["Cliente"].Value.ToString().Length - txt_letra.TextLength; f++)
                {
                    if (txt_letra.TextLength <= DGW.Rows[i].Cells["Cliente"].Value.ToString().Length)
                    {
                        if (txt_letra.Text.ToLower() == DGW.Rows[i].Cells["Cliente"].Value.ToString().Substring(f, txt_letra.TextLength).ToLower())
                        {
                            DGW.CurrentCell = DGW.Rows[i].Cells["Cliente"];
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
            for (i = fila; i < DGW.Rows.Count; i++)
            {
                for (f = 0; f <= DGW.Rows[i].Cells["Cliente"].Value.ToString().Length - txt_letra.TextLength; f++)
                {
                    if (txt_letra.TextLength <= DGW.Rows[i].Cells["Cliente"].Value.ToString().Length)
                    {
                        if (txt_letra.Text.ToLower() == DGW.Rows[i].Cells["Cliente"].Value.ToString().Substring(f, txt_letra.TextLength).ToLower())
                        {
                            DGW.CurrentCell = DGW.Rows[i].Cells["Cliente"];
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
