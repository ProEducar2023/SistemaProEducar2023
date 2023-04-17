using BLL;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;

namespace Presentacion.MOD_FACT_VTA.MOD_VTA
{
    public partial class PREVENTA_TODOS_PERIODOS : Form
    {
        string AÑO = "", MES = "", COD_MOD = "", COD_USU = "", TIPO_USU = "";
        DateTime FECHA_INI, FECHA_GRAL;
        precontratoCabeceraBLL pccBLL = new precontratoCabeceraBLL();
        precontratoCabeceraTo pccTo = new precontratoCabeceraTo();
        precontratoDetalleBLL pcdBLL = new precontratoDetalleBLL();
        precontratoDetalleTo pcdTo = new precontratoDetalleTo();
        HelpersBLL helBLL = new HelpersBLL();
        HelpersTo helTo = new HelpersTo();
        progNivelRelacionBLL pnrBLL = new progNivelRelacionBLL();
        progNivelRelacionTo pnrTo = new progNivelRelacionTo();
        personaMaestroBLL prmBLL = new personaMaestroBLL();
        personaMaestroTo prmTo = new personaMaestroTo();
        personaBLL perBLL = new personaBLL();
        personaTo perTo = new personaTo();
        modalidadVentaBLL mvBLL = new modalidadVentaBLL();
        modalidadVentaTo mvTo = new modalidadVentaTo();
        lugarVentaBLL lgvBLL = new lugarVentaBLL();
        lugarVentaTo lgvTo = new lugarVentaTo();
        puntoVentaBLL ptvBLL = new puntoVentaBLL();
        puntoVentaTo ptvTo = new puntoVentaTo();
        decimal preuni = 0, prenet = 0, prebru = 0, igv = 0, desc = 0, preigv = 0, tot = 0;
        decimal tprebru = 0, tprenet = 0, tpreigv = 0, total = 0;
        decimal cant = 0, igv0 = 0;
        decimal sneto = 0, pres = 0, otrdesc = 0, jud = 0, netcob = 0, subtotal = 0, sub_50_total = 0, sub_subtotal = 0, imp_prot = 0;
        decimal eval_cont = 0;
        DataTable dtSemanaContrato; DataTable dtPersona;
        //DIALOGOS.APROBADO_POR aprob = new DIALOGOS.APROBADO_POR(FECHA_INI,FECHA_GRAL);
        string COD_MOV, STATUS_PV1, NRO_OC222, TIPO_ORIGEN, ST_DIF;
        string STATUS_DSCTO = "0", STATUS_IGV = "0", RUC, PRECIO, FONO, AÑO0, boton;
        string COD_MONEDA1, COD_FORMA_PAGO, COD_CLASE1, COD_CONTACTO1, COD_ELAB;
        string COD_FIRMA, MES0, P_MONEDA, ESTADO_DGW, DIR, COD_VENTA, COD_PRECIO1;
        string COD_PRECIO2 = "", COD_SUCURSAL1;
        string codsup, coddir, coddirnac;
        private string CODARTCLI = "", DESCARTCLI = "", PARTEARTCLI = "";
        decimal TOTAL_CONTRATO1 = 0, IMP_CUOTA_INICIAL1 = 0, IMP_CUOTA_MES1 = 0;
        int NRO_CUOTAS1, NRO_DIAS_VENC1;
        DateTime? FEC_PRIMER_VENC1; DateTime FEC_CUO_MEN1;
        DataTable dt00 = new DataTable();
        DataTable dtPreContrato;
        int fila, fila2, fila3;
        decimal IGV0, DSCTO_TOTAL1;
        string NOMBRE_PC = System.Environment.MachineName;
        string COD_INSTITUCION1, COD_KIT1;
        DIALOGOS.Dialog3 obs = new DIALOGOS.Dialog3();
        DIALOGOS.Dialog3 obs2 = new DIALOGOS.Dialog3();
        //string boton;
        DIALOGOS.CONSULTA_KIT frmKit = new DIALOGOS.CONSULTA_KIT();
        MOD_FACT_VTA.MOD_VTA.PLAN_DE_PAGOS_PRECONTRATO frmPagos;
        DataTable dtPtoVta; DataTable dtLugVta;
        bool val_Semana_Contrato = true;
        public PREVENTA_TODOS_PERIODOS(string AÑO, string MES, DateTime FECHA_INI, DateTime FECHA_GRAL, string COD_MOD, string TIPO_USU, string COD_USU)
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

        private void PREVENTA_TODOS_PERIODOS_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            DATAGRID();
            CARGAR_CLASE(); //HAY QUE REVISAR LOS PARAMETROS DE ENTRADA CORRECTOS O HACER EL LOGIN
            CARGAR_SUCURSAL();
            CARGAR_VENDEDOR();
            CARGAR_PERSONAS();
            CARGAR_PERSONAS_PERSONAL();
            //CARGAR_MOVIMIENTO();
            //CARGAR_COND_VENTA();
            CARGAR_PROGRAMAS();
            CARGAR_ALMACENES();
            CARGAR_TIPO_PLANILLA();
            CARGAR_MONEDA();
            cargaFormaPago();
            cargaCondicionVenta();
            CARGAR_EVAL_CONTRATO();//PORCENTAJE CON EL QUE SE EVALUA EL CONTRATO
            //CARGAR_SUB_PUNTO_VENTA();
            CARGAR_CANAL_DSCTO();
            CARGAR_PUNTO_COBRANZA();
            //CARGAR_TIPO_VENTA();
            CARGAR_MODALIDAD_VENTA();
            igv0 = helBLL.obtenerImpuestoBLL("IGV");
            TXT_IGV.Text = igv0.ToString();
            TXT_IGV2.Text = TXT_IGV.Text;
            TXT_TC.Text = obtener_tipo_cambio();

            //DTP_DOC.Value = Convert.ToDateTime(DateTime.Now.Day + "/" + FECHA_INI.Month + "/" + FECHA_INI.Year);
            DTP_DOC.Value = HelpersBLL.validaFecha(MES, AÑO, FECHA_GRAL);
            DTP_DOC.Enabled = false;
            //dtp_oc.Value = Convert.ToDateTime(DateTime.Now.Day + "/" + FECHA_INI.Month + "/" + FECHA_INI.Year);
            dtp_oc.Value = DTP_DOC.Value;
            dtp_oc.Enabled = false;
            //
            dt00.Columns.Add("COD_SUCURSAL");
            dt00.Columns.Add("NRO_PRESUPUESTO");
            dt00.Columns.Add("COD_PER");
            dt00.Columns.Add("COD_CLASE");
            dt00.Columns.Add("FE_AÑO");
            dt00.Columns.Add("FE_MES");
            dt00.Columns.Add("ITEM");
            dt00.Columns.Add("COD_ARTICULO");
            dt00.Columns.Add("CANTIDAD_PED");
            dt00.Columns.Add("CANTIDAD_ATEN");
            dt00.Columns.Add("CANTIDAD_ANUL");
            dt00.Columns.Add("PRECIO_UNIT");
            dt00.Columns.Add("VALOR_COMPRA");
            dt00.Columns.Add("POR_IGV");
            dt00.Columns.Add("POR_DSCTO");
            dt00.Columns.Add("STATUS_IGV");
            dt00.Columns.Add("VALOR_IGV");
            dt00.Columns.Add("VALOR_DSCTO");
            dt00.Columns.Add("AJUSTE_IGV");
            dt00.Columns.Add("AJUSTE_BI");
            dt00.Columns.Add("COD_D_H");
            dt00.Columns.Add("OBSERVACION");
            //dt00.Columns.Add("status_por_dscto");
            //dt00.Columns.Add("NRO_DIAS");
            //dt00.Columns.Add("FECHA_ENTREGA");
            dt00.Columns.Add("NOMBRE_PC");
            dt00.Columns.Add("COD_CONDICION");
            dt00.Columns.Add("DESC_ARTICULO");
            dt00.Columns.Add("TIPO_PRECIO");
            dt00.Columns.Add("ST_VALOR_REFERENCIAL");
            dt00.Columns.Add("STATUS_POR_DSCTO");
            btn_nuevo.Select();
            //
        }
        public void CARGAR_MODALIDAD_VENTA()
        {
            DataTable dt = mvBLL.obtenerModalidadVentaBLL();
            cbo_modalidad_venta.ValueMember = "COD_MODALIDAD_VTA";
            cbo_modalidad_venta.DisplayMember = "DESC_MODALIDAD_VTA";
            cbo_modalidad_venta.DataSource = dt;
            cbo_modalidad_venta.SelectedIndex = 0;
        }
        private void CARGAR_PUNTO_COBRANZA()
        {
            puntoCobranzaBLL pcoBLL = new puntoCobranzaBLL();
            puntoCobranzaTo pcoTo = new puntoCobranzaTo();
            pcoTo.STATUS_CONSOLIDADO = false;
            //DataTable dt = pcoBLL.obtenerPuntosCobranzaBLL(pcoTo);
            DataTable dt = pcoBLL.obtenerTodosPuntosCobranzaBLL();
            if (dt.Rows.Count > 0)
            {
                cboptocob.ValueMember = "COD_PTO_COB";
                cboptocob.DisplayMember = "DESC_PTO_COB";
                cboptocob.DataSource = dt;
                cboptocob.SelectedIndex = -1;
            }
            //cboptocob.AutoCompleteCustomSource = AutoCompleClass.AutoComplete(dt);
            //cboptocob.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //cboptocob.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }
        private void CARGAR_CANAL_DSCTO()
        {
            canalDescuentoBLL cdscBLL = new canalDescuentoBLL();
            DataTable dt = cdscBLL.ObtenerCanalDescuentoBLL();
            cbocandesc.ValueMember = "COD_CANAL_DSCTO";
            cbocandesc.DisplayMember = "DESCRIPCION";
            cbocandesc.DataSource = dt;
            cbocandesc.SelectedIndex = 0;
        }
        private void CARGAR_SUB_PUNTO_VENTA()
        {
            //ptvTo.STATUS_CONSOLIDADO = false;
            ptvTo.COD_INSTITUCION = COD_INSTITUCION1;
            dtPtoVta = ptvBLL.obtenerPuntosVentasBLL(ptvTo);
            if (dtPtoVta.Rows.Count > 0)
            {
                cboptovta.ValueMember = "COD_PTO_VEN";
                cboptovta.DisplayMember = "DESC_PTO_VEN";
                cboptovta.DataSource = dtPtoVta;
                cboptovta.SelectedIndex = -1;

                cboptovta.AutoCompleteCustomSource = AutoCompleClass.AutoComplete(dtPtoVta);
                cboptovta.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cboptovta.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
            //
            //lblptovtacons.Text = "";
            //de la riva aguero

        }
        private void CARGAR_EVAL_CONTRATO()
        {
            //directorioBLL dirBLL = new directorioBLL();
            eval_cont = pccBLL.obtenerPorcentajeEvalContratoBLL();
        }
        private void DATAGRID()
        {
            pccTo.TIPO_USU = TIPO_USU;
            pccTo.COD_USU = COD_USU;
            dtPreContrato = pccBLL.obtenerPreContratoCabeceraTodosPeriodosBLL(pccTo);
            if (dtPreContrato.Rows.Count > 0)
            {
                DGW.Rows.Clear();
                foreach (DataRow rw in dtPreContrato.Rows)
                {
                    int rowId = DGW.Rows.Add();
                    DataGridViewRow row = DGW.Rows[rowId];
                    row.Cells["COD_SUCURSAL"].Value = rw["COD_SUCURSAL"].ToString();
                    row.Cells["Sucursal"].Value = rw["Sucursal"].ToString();
                    row.Cells["cod_clase"].Value = rw["cod_clase"].ToString();
                    row.Cells["Clase"].Value = rw["Clase"].ToString();
                    row.Cells["cod_per"].Value = rw["cod_per"].ToString();
                    row.Cells["Cliente"].Value = rw["Cliente"].ToString();
                    row.Cells["NRO_DOC"].Value = rw["NRO_DOC"].ToString();
                    row.Cells["Contrato"].Value = rw["Contrato"].ToString();
                    row.Cells["Fecha"].Value = rw["Fecha"].ToString().Substring(0, 10);
                    row.Cells["cod_moneda"].Value = rw["cod_moneda"].ToString();
                    row.Cells["tipo_cambio"].Value = rw["tipo_cambio"].ToString();
                    row.Cells["forma_pago"].Value = rw["forma_pago"].ToString();
                    row.Cells["OBS_VAC"].Value = rw["OBS_VAC"].ToString();
                    row.Cells["status_pv"].Value = rw["status_pv"].ToString();
                    row.Cells["nro_dias"].Value = rw["nro_dias"].ToString();
                    row.Cells["ELAB"].Value = rw["ELAB"].ToString();
                    row.Cells["Cie"].Value = rw["Cie."].ToString();
                    row.Cells["cod_vendedor"].Value = rw["cod_vendedor"].ToString();
                    row.Cells["cod_per_aprob"].Value = rw["cod_per_aprob"].ToString();
                    row.Cells["Aprob"].Value = Convert.ToBoolean(rw["Aprob"]);
                    row.Cells["Anul"].Value = Convert.ToBoolean(rw["Anul"]);
                    row.Cells["CONDICION_VENTA"].Value = rw["CONDICION_VENTA"].ToString();
                    row.Cells["FE_AÑO"].Value = rw["FE_AÑO"].ToString();
                    row.Cells["FE_MES"].Value = rw["FE_MES"].ToString();
                    row.Cells["COD_CONTACTO"].Value = rw["COD_CONTACTO"].ToString();
                    row.Cells["TIPO_PRECIO"].Value = rw["TIPO_PRECIO"].ToString();
                    row.Cells["OBSERVACION"].Value = rw["OBSERVACION"].ToString();
                    row.Cells["NRO_REPORTE"].Value = rw["NRO_REPORTE"].ToString();
                    row.Cells["FEC_REPORTE"].Value = rw["FEC_REPORTE"].ToString();
                    row.Cells["COD_PROGRAMA"].Value = rw["COD_PROGRAMA"].ToString();
                    row.Cells["PERIODO"].Value = rw["PERIODO"].ToString();
                    row.Cells["NRO_SEMANA"].Value = rw["NRO_SEMANA"].ToString();
                    row.Cells["TIPO_PLANILLA"].Value = rw["TIPO_PLANILLA"].ToString();
                    row.Cells["COD_ALMACEN"].Value = rw["COD_ALMACEN"].ToString();
                    row.Cells["COD_NIVEL1"].Value = rw["COD_NIVEL1"].ToString();
                    row.Cells["COD_NIVEL2"].Value = rw["COD_NIVEL2"].ToString();
                    row.Cells["COD_NIVEL3"].Value = rw["COD_NIVEL3"].ToString();
                    row.Cells["SUELDO_BASICO"].Value = rw["SUELDO_BASICO"].ToString();
                    row.Cells["SUELDO_BRUTO"].Value = rw["SUELDO_BRUTO"].ToString();
                    row.Cells["OTROS_DSCTOS"].Value = rw["OTROS_DSCTOS"].ToString();
                    row.Cells["JUDICIALES"].Value = rw["JUDICIALES"].ToString();
                    row.Cells["FE_MES"].Value = rw["FE_MES"].ToString();
                    row.Cells["NETO_COBRAR"].Value = rw["NETO_COBRAR"].ToString();
                    row.Cells["TOTAL_CONTRATO"].Value = string.Format("{0:N2}", rw["TOTAL_CONTRATO"]);// rw["TOTAL_CONTRATO"].ToString();
                    row.Cells["NRO_CUOTAS"].Value = rw["NRO_CUOTAS"].ToString();
                    row.Cells["IMP_CUOTA_INICIAL"].Value = rw["IMP_CUOTA_INICIAL"].ToString();
                    row.Cells["IMP_CUOTA_MES"].Value = rw["IMP_CUOTA_MES"].ToString();
                    row.Cells["FEC_PRIMER_VENC"].Value = rw["FEC_PRIMER_VENC"].ToString().Substring(0, 10);
                    row.Cells["NRO_DIAS_VENC"].Value = rw["NRO_DIAS_VENC"].ToString();
                    row.Cells["FEC_CUO_MEN"].Value = rw["FEC_CUO_MEN"].ToString().Substring(0, 10);
                    row.Cells["COD_SUB_PTO_VEN"].Value = rw["COD_SUB_PTO_VEN"].ToString();
                    row.Cells["COD_CANAL_DSCTO"].Value = rw["COD_CANAL_DSCTO"].ToString();
                    row.Cells["COD_PTO_COB"].Value = rw["COD_PTO_COB"].ToString();
                    row.Cells["COD_TIPO_VENTA"].Value = rw["COD_TIPO_VENTA"].ToString();
                    row.Cells["COD_MODALIDAD_VTA"].Value = rw["COD_MODALIDAD_VTA"].ToString();
                    row.Cells["COD_INSTITUCION"].Value = rw["COD_INSTITUCION"].ToString();
                    row.Cells["COD_LUG_VTA"].Value = rw["COD_LUG_VTA"].ToString();
                    row.Cells["DIAS"].Value = rw["DIAS"].ToString();
                    row.Cells["VENDEDOR"].Value = rw["VENDEDOR"].ToString();
                    row.Cells["DESC_INST"].Value = rw["DESC_INST"].ToString();
                    row.Cells["DESC_PTO_VEN"].Value = rw["DESC_PTO_VEN"].ToString();
                    row.Cells["DESC_PTO_COB"].Value = rw["DESC_PTO_COB"].ToString();
                    row.Cells["IMPORTE_PROTECCION"].Value = rw["IMPORTE_PROTECCION"].ToString();
                    row.Cells["DESC_ALMACEN"].Value = rw["DESC_ALMACEN"].ToString();
                    row.Cells["COD_KIT"].Value = rw["COD_KIT"].ToString();
                    row.Cells["DSCTO_TOTAL"].Value = rw["DSCTO_TOTAL"].ToString();
                }
            }

        }
        private void CARGAR_PERSONAS_PERSONAL()
        {
            CBO_PERSONAL.Items.Clear();
            personalBLL perBLL = new personalBLL();
            DataTable dt = perBLL.obtenerPersonalparaPreventaBLL();
            CBO_PERSONAL.ValueMember = "COD_PER";
            CBO_PERSONAL.DisplayMember = "DESC_PER";
            CBO_PERSONAL.DataSource = dt;
            CBO_PERSONAL.SelectedIndex = -1;
        }
        private void CARGAR_MONEDA()
        {
            DataTable dt = helBLL.obtenerMonedaBLL();
            CBO_MONEDA.ValueMember = "COD_MONEDA";
            CBO_MONEDA.DisplayMember = "desc_moneda";
            CBO_MONEDA.DataSource = dt;
            CBO_MONEDA.SelectedIndex = 1;
        }
        private void CARGAR_TIPO_PLANILLA()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("cod", typeof(string));
            dt.Columns.Add("val", typeof(string));
            DataRow rw2 = dt.NewRow();
            rw2["cod"] = "P";
            rw2["val"] = "DESCUENTO";
            dt.Rows.Add(rw2);
            cbo_tipo_planilla.ValueMember = "cod";
            cbo_tipo_planilla.DisplayMember = "val";
            cbo_tipo_planilla.DataSource = dt;
            cbo_tipo_planilla.SelectedIndex = 0;
        }
        private void CARGAR_ALMACENES()
        {
            almacenesBLL almBLL = new almacenesBLL();
            DataTable dt = almBLL.obtenerAlmacenesBLL();
            cbo_alm.ValueMember = "Cod";
            cbo_alm.DisplayMember = "Descripción";
            cbo_alm.DataSource = dt;
            cbo_alm.SelectedIndex = -1;
        }
        private void cargaCondicionVenta()
        {
            DataTable dt = helBLL.obtenerCondicionVentaBLL();
            cbo_VENTA.ValueMember = "COD_TIPO";
            cbo_VENTA.DisplayMember = "DESC_TIPO";
            cbo_VENTA.DataSource = dt;
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
        private void CARGAR_VENDEDOR()
        {
            progNivelBLL prnBLL = new progNivelBLL();
            DataTable dt = prnBLL.obtenerVendedoresparaCrearEqVentasBLL();
            dgw_per2.DataSource = dt;
            dgw_per2.Columns[0].Width = 55;
            dgw_per2.Columns[1].Width = 240;
        }
        private void CARGAR_PERSONAS()
        {
            helTo.CODIGO = "04";//VENDEDORES
            dtPersona = helBLL.MOSTRAR_PERSONAS_XCOBRAR_BLL(helTo);
            if (dtPersona.Rows.Count > 0)
            {
                dgw_per.DataSource = dtPersona;
                dgw_per.Columns["Cod"].HeaderText = "Código";
                dgw_per.Columns["Cod"].Width = 50;
                dgw_per.Columns["Razón Social"].HeaderText = "Nombre o Razón Social";
                dgw_per.Columns["Razón Social"].Width = 260;
                dgw_per.Columns["Nroº Doc"].HeaderText = "DNI / RUC";
                dgw_per.Columns["Nroº Doc"].Width = 80;
                dgw_per.Columns["Cod Ref"].Visible = false;
                dgw_per.Columns["COD_INSTITUCION"].Visible = false;
                dgw_per.Columns["DESC_INST"].Visible = false;
            }

        }
        private void CARGAR_SUCURSAL()
        {
            helTo.CODIGO = COD_USU;
            DataTable dt = helBLL.CBO_SUCURSALBLL(helTo);
            CBO_SUCURSAL.ValueMember = "COD_SUCURSAL";
            CBO_SUCURSAL.DisplayMember = "DESC_sucursal";
            CBO_SUCURSAL.DataSource = dt;
            CBO_SUCURSAL.SelectedIndex = 0;
        }
        private void CARGAR_CLASE()
        {
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

        private void PREVENTA_TODOS_PERIODOS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            MOD_ADM.PERSONA frm = new MOD_ADM.PERSONA(1, "");
            frm.Text = "Ingrese Datos del Nuevo Cliente";
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (Properties.Settings.Default.PER == "1")
                {
                    TXT_COD.Text = "";
                    TXT_DESC.Text = "";
                    txt_doc_per.Text = "";
                    //DataGridViewRow row = frm.dgw.CurrentRow;
                    //TXT_COD.Text = row.Cells[0].Value.ToString();
                    //TXT_DESC.Text = frm.cbo_tipo.SelectedItem.ToString() == "NATURAL" ? row.Cells[7].Value.ToString() + " " + row.Cells[8].Value.ToString() + " " + row.Cells[6].Value.ToString() : row.Cells[1].Value.ToString();
                    //txt_doc_per.Text = frm.txt_nro_doc.Text;
                    TXT_COD.Text = frm.txt_cod.Text;
                    TXT_DESC.Text = frm.cbo_tipo.SelectedItem.ToString() == "NATURAL" ? frm.txt_pat.Text + " " + frm.txt_mat.Text + " " + frm.txt_nom.Text : frm.txt_desc.Text;
                    txt_doc_per.Text = frm.txt_nro_doc.Text;
                    COD_INSTITUCION1 = frm.cbo_institucion.SelectedValue.ToString();//lo trae para el punto de venta
                    lbl_institucion.Text = frm.cbo_institucion.Text;//se vé la descripción pero no se graba el codigo institucion
                    CARGAR_SUB_PUNTO_VENTA();
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
            TabControl1.SelectedTab = (TabPage2);
            Panel1.Visible = true;
            Panel2.Visible = false;
            Panel0.Enabled = true;
            btn_mod.Visible = true;
            LIMPIAR_CABECERA();
            //  SGT_ORDEN();
            CBO_SUCURSAL.Select();
            btnConsultaCliente.Visible = false;
            btnNuevoCliente.Visible = true;
            txt_numero.Enabled = true;
            campos_clave_modificacion(true);
            DateTime dtp = DTP_DOC.Value;
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
            //TXT_TC.Clear();
            txt_oc.Clear();
            //CBO_TIPO_ORIGEN.SelectedIndex = -1;
            //cbo_prog.SelectedIndex = -1;
            gb_oc.Enabled = true;
            //ch_dif.Enabled = true;
            cbo_prog.Enabled = true;
            txt_oc.Enabled = true;
            //dtp_oc.Enabled = false;
            chk_fec_contrato.Checked = false;
            chk_fec_reporte.Checked = false;
            txt_cod2.Enabled = true;
            txt_desc2.Enabled = true;
            //gb_DEntrega.Enabled = true;
            gb_venta.Enabled = true;
            //TXT_DIR_ENTREGA.Clear();
            //TXT_OBS_ENTREGA.Clear();
            obs.txt_obs.Clear();
            //txt_obs1.Clear();
            //txt_obs2.Clear();
            //txt_obs3.Clear();
            btn_ajuste.Enabled = true;
            dgw_det.Rows.Clear();
            TXT_TB.Text = "0.00";
            TXT_TD.Text = "0.00";
            TXT_TN.Text = "0.00";
            TXT_TT.Text = "0.00";
            TXT_TIGV.Text = "0.00";
            //ch_dif.Checked = false;
            txt_numero.Clear();
            txt_mes.Clear();
            cbo_semana.DataSource = null;//limpia el combo
            cbo_tipo_planilla.SelectedIndex = 0;
            CBO_PAGO.SelectedIndex = 2;
            cbo_VENTA.SelectedIndex = 0;
            //TXT_OBS_ENTREGA.Clear();
            obs2.txt_obs.Clear();
            txtsbas.Clear();
            txtsbru.Clear();
            cbo_modalidad_venta.SelectedIndex = 0;
            cbo_tipo_venta.SelectedIndex = 0;
            cbocandesc.SelectedIndex = 0;
            //cboptocob.SelectedIndex = -1;
            txt_otro_desc.Clear();
            txt_judicial.Clear();
            txt_neto_cob.Clear();
            obs2.txt_obs.Clear();
            lbl_institucion.Text = "";
            txt_subtotal.Clear();
            txt_50_subtotal.Clear();
            txt_sub_sub_total.Clear();
            txt_imp_proteccion.Clear();
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
                button4.Focus();//boton plan de pagos
            }
        }
        private void INSERTAR_DE_DIALOG()
        {
            COD_KIT1 = frmKit.COD_KIT;
            int num = frmKit.DGW_DET.Rows.Count - 1;
            int num3 = num;
            int i = 0;
            decimal x = 0, imp = 0, iva = 0;
            dgw_det.Rows.Clear();
            do
            {
                //dgw_det.Rows.Add((dgw_det.Rows.Count + 1).ToString("00"), frmKit.DGW_DET[0, i].Value.ToString(), frmKit.DGW_DET[1, i].Value.ToString(),
                //    frmKit.DGW_DET[4, i].Value.ToString(), "0.000", "0.000",
                //    frmKit.DGW_DET[5, i].Value.ToString(),
                //    "0.00", "0.00", "0.00", "1", "0.00", "0.00", "0.00", "0.00",
                //    "D", "", TXT_NRO_PARTE.Text, CODARTCLI, DESCARTCLI, PARTEARTCLI, "", "", COD_PRECIO2, 
                //    frmKit.DGW_DET[6, i].Value.ToString().ToLower() == "false" ? "0" : "1");
                if (CH_PV.Checked)
                {
                    x = Convert.ToDecimal(frmKit.DGW_DET[4, i].Value) * Convert.ToDecimal(frmKit.DGW_DET[5, i].Value);//cant*preuni
                    imp = x / (1 + (igv0 / 100));
                    iva = frmKit.DGW_DET.Rows[i].Cells["STATUS_IGV"].Value.ToString() == "0" ? 0 : x - imp;
                    dgw_det.Rows.Add((dgw_det.Rows.Count + 1).ToString("00"), frmKit.DGW_DET[0, i].Value.ToString(), frmKit.DGW_DET[1, i].Value.ToString(),
                    frmKit.DGW_DET[4, i].Value.ToString(), "0.000", "0.000",
                    frmKit.DGW_DET[5, i].Value.ToString(),
                    x, frmKit.DGW_DET.Rows[i].Cells["STATUS_IGV"].Value.ToString() == "0" ? "0.00" : TXT_IGV.Text, "0.00",
                    frmKit.DGW_DET.Rows[i].Cells["STATUS_IGV"].Value.ToString(), iva, "0.00", "0.00", "0.00",
                    "D", "", "0", CODARTCLI, DESCARTCLI, PARTEARTCLI, "", "", COD_PRECIO2,
                    frmKit.DGW_DET[6, i].Value.ToString().ToLower() == "false" ? "0" : "1");
                }
                else
                {
                    x = Convert.ToDecimal(frmKit.DGW_DET[4, i].Value) * Convert.ToDecimal(frmKit.DGW_DET[5, i].Value);//cant*preuni
                    imp = x / (1 + (igv0 / 100));
                    iva = x * (igv0 / 100);
                    dgw_det.Rows.Add((dgw_det.Rows.Count + 1).ToString("00"), frmKit.DGW_DET[0, i].Value.ToString(), frmKit.DGW_DET[1, i].Value.ToString(),
                    frmKit.DGW_DET[4, i].Value.ToString(), "0.000", "0.000",
                    frmKit.DGW_DET[5, i].Value.ToString(),
                    x, frmKit.DGW_DET.Rows[i].Cells["STATUS_IGV"].Value.ToString() == "0" ? "0.00" : TXT_IGV.Text, "0.00",
                    frmKit.DGW_DET.Rows[i].Cells["STATUS_IGV"].Value.ToString(), iva, "0.00", "0.00", "0.00",
                    "D", "", "0", CODARTCLI, DESCARTCLI, PARTEARTCLI, "", "", COD_PRECIO2,
                    frmKit.DGW_DET[6, i].Value.ToString().ToLower() == "false" ? "0" : "1");
                }
                i++;
            }
            while (i <= num3);
            int j = 0, cont = 0;
            cont = dgw_det.Rows.Count - 1;
            if (CH_PV.Checked)
            {
                for (j = 0; j <= cont; j++)
                {
                    dgw_det[7, j].Value = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(dgw_det[7, j].Value.ToString());
                    //dgw_det[8, j].Value = frmKit.DGW_DET.Rows[i].Cells["STATUS_IGV"].Value.ToString()=="0" ? "0" : TXT_IGV.Text;
                    dgw_det[11, j].Value = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(dgw_det[11, j].Value.ToString());
                }
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
                //DGW_CAB.DataSource = dt;
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

        private void btn_grabar_Click(object sender, EventArgs e)
        {
            if (!validaGrabar())
                return;

            DialogResult rs = MessageBox.Show("¿ ESTA SEGURO DE ADICIONAR UN NUEVO PRECONTRATO ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                string nro_repo = "";
                COD_SUCURSAL1 = CBO_SUCURSAL.SelectedValue.ToString();
                STATUS_PV1 = CH_PV.Checked ? "1" : "0";
                COD_ELAB = "";
                COD_FORMA_PAGO = "";
                COD_MOV = "";
                COD_VENTA = "";
                COD_PRECIO1 = "";
                COD_CONTACTO1 = "";
                ST_DIF = "0";
                COD_ELAB = CBO_PERSONAL.SelectedValue.ToString();
                COD_FORMA_PAGO = CBO_PAGO.SelectedValue.ToString();
                //COD_MOV = cbo_movimiento.SelectedValue.ToString();
                COD_VENTA = cbo_VENTA.SelectedValue != null ? cbo_VENTA.SelectedValue.ToString() : "";
                COD_CLASE1 = CBO_CLASE.SelectedValue.ToString();
                COD_MONEDA1 = CBO_MONEDA.SelectedValue.ToString();
                //string  AÑO = DateTime.Now.Year.ToString();
                //string MES = DateTime.Now.Month.ToString("00");
                //
                pccTo.COD_SUCURSAL = COD_SUCURSAL1;
                pccTo.NRO_PRESUPUESTO = txt_numero.Text;
                pccTo.COD_PER = TXT_COD.Text;
                pccTo.COD_CLASE = COD_CLASE1;
                pccTo.FE_AÑO = AÑO;
                pccTo.FE_MES = MES;
                pccTo.FECHA_PRE = DTP_DOC.Value;
                pccTo.COD_MONEDA = COD_MONEDA1;
                pccTo.TIPO_CAMBIO = Convert.ToDecimal(TXT_TC.Text);
                pccTo.FORMA_PAGO = COD_FORMA_PAGO;
                pccTo.OBSERVACION = obs2.txt_obs.Text;
                pccTo.STATUS_PV = STATUS_PV1;
                pccTo.NRO_DIAS = Convert.ToInt32(txt_nro_dias.Text);
                pccTo.COD_PER_ELAB = COD_ELAB;
                pccTo.COD_PER_APROB = "";
                pccTo.STATUS_APROB = "0";//se aprueba al momento de crear el contrato, lo dijo la señora
                pccTo.STATUS_ANUL = "0";
                pccTo.STATUS_CIERRE = "0";
                pccTo.COD_VENDEDOR = txt_cod2.Text;
                pccTo.NOMBRE_PC = NOMBRE_PC;
                pccTo.CONDICION_VENTA = COD_VENTA;
                pccTo.COD_CONTACTO = COD_CONTACTO1;
                pccTo.FECHA_APROB = null;//*******
                pccTo.TIPO_PRECIO = COD_PRECIO1;
                pccTo.NRO_REPORTE = txt_oc.Text;
                pccTo.FEC_REPORTE = dtp_oc.Value;
                pccTo.COD_PROGRAMA = cbo_prog.SelectedValue.ToString();
                pccTo.PERIODO = txt_mes.Text;
                pccTo.NRO_SEMANA = cbo_semana.SelectedValue.ToString();
                pccTo.TIPO_PLANILLA = cbo_tipo_planilla.SelectedValue.ToString();
                pccTo.COD_ALMACEN = cbo_alm.SelectedValue.ToString();
                pccTo.COD_NIVEL1 = coddirnac;
                pccTo.COD_NIVEL2 = coddir;
                pccTo.COD_NIVEL3 = codsup;
                pccTo.SUELDO_BASICO = txtsbas.Text.Trim() == "" ? 0 : Convert.ToDecimal(txtsbas.Text);
                pccTo.SUELDO_BRUTO = txtsbru.Text.Trim() == "" ? 0 : Convert.ToDecimal(txtsbru.Text);
                pccTo.OTROS_DSCTOS = txt_otro_desc.Text.Trim() == "" ? 0 : Convert.ToDecimal(txt_otro_desc.Text);
                pccTo.JUDICIALES = txt_judicial.Text.Trim() == "" ? 0 : Convert.ToDecimal(txt_judicial.Text);
                pccTo.NETO_COBRAR = txt_neto_cob.Text.Trim() == "" ? 0 : Convert.ToDecimal(txt_neto_cob.Text);
                pccTo.TOTAL_CONTRATO = TOTAL_CONTRATO1;
                pccTo.NRO_CUOTAS = NRO_CUOTAS1;
                pccTo.IMP_CUOTA_INICIAL = IMP_CUOTA_INICIAL1;
                pccTo.IMP_CUOTA_MES = IMP_CUOTA_MES1;
                pccTo.FEC_PRIMER_VENC = FEC_PRIMER_VENC1;
                pccTo.NRO_DIAS_VENC = NRO_DIAS_VENC1;
                pccTo.FEC_CUO_MEN = FEC_CUO_MEN1;
                pccTo.COD_SUB_PTO_VEN = cboptovta.SelectedValue.ToString();
                pccTo.COD_PTO_COB = cboptocob.SelectedValue.ToString();
                pccTo.COD_CANAL_DSCTO = cbocandesc.SelectedValue.ToString();
                pccTo.COD_TIPO_VENTA = cbo_tipo_venta.SelectedValue.ToString();
                pccTo.COD_MODALIDAD_VTA = cbo_modalidad_venta.SelectedValue.ToString();
                pccTo.COD_LUG_VTA = cbo_lug_vta.SelectedValue.ToString();
                pccTo.COD_INSTITUCION = COD_INSTITUCION1;
                pccTo.IMPORTE_PROTECCION = txt_imp_proteccion.Text.Trim() == "" ? 0 : Convert.ToDecimal(txt_imp_proteccion.Text);
                pccTo.COD_KIT = COD_KIT1;
                pccTo.DSCTO_TOTAL = DSCTO_TOTAL1;
                pccTo.COD_USU = COD_USU;
                pccTo.COD_USU_CREA = COD_USU;
                pccTo.FECHA_CREA = DateTime.Now;
                dt00.Rows.Clear();
                int num = dgw_det.Rows.Count - 1;
                int num3 = num;
                int i = 0;
                while (i <= num3)
                {
                    dt00.Rows.Add(COD_SUCURSAL1, "", TXT_COD.Text, COD_CLASE1, AÑO, MES, dgw_det[0, i].Value.ToString(), dgw_det[1, i].Value.ToString(),
                        Convert.ToDecimal(dgw_det[3, i].Value), Convert.ToDecimal(dgw_det[4, i].Value),
                        Convert.ToDecimal(dgw_det[5, i].Value), Convert.ToDecimal(dgw_det[6, i].Value), Convert.ToDecimal(dgw_det[7, i].Value),
                        Convert.ToDecimal(dgw_det[8, i].Value), Convert.ToDecimal(dgw_det[9, i].Value), dgw_det[10, i].Value.ToString(), Convert.ToDecimal(dgw_det[11, i].Value),
                        Convert.ToDecimal(dgw_det[12, i].Value), Convert.ToDecimal(dgw_det[13, i].Value), Convert.ToDecimal(dgw_det[14, i].Value),
                        dgw_det[15, i].Value.ToString(), dgw_det[16, i].Value.ToString(),// dgw_det[17, i].Value.ToString(), dgw_det[18, i].Value.ToString(), dgw_det[19, i].Value.ToString(),
                        NOMBRE_PC, dgw_det[21, i].Value.ToString(), dgw_det[2, i].Value.ToString(), dgw_det[23, i].Value.ToString(),
                        dgw_det.Rows[i].Cells["st_valor_referencial"].Value.ToString(), dgw_det.Rows[i].Cells["st_por_dscto"].Value.ToString());
                    i++;
                }

                if (!pccBLL.adicionaPreContratoBLL(pccTo, dt00, ref nro_repo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Se adicionó correctamente el Pre-Contrato !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //gb_oc.Enabled = false;
                    Panel1.Visible = true;
                    btn_grabar.Enabled = false;
                    Panel2.Visible = false;
                    Panel0.Enabled = false;
                    btn_imprimir.Enabled = true;
                    //DATAGRID() : FOCO_NUEVO_REG();
                    btn_nuevo2.Select();
                    //
                    DATAGRID(); FOCO_NUEVO_REG(txt_numero.Text.Trim());
                    //DGW.Rows.Add(CBO_SUCURSAL.Text, CBO_CLASE.Text, TXT_DESC.Text, "001" + "-" + txt_numero.Text, DTP_DOC.Value.ToShortDateString(), false, false);
                    //TabControl1.SelectedTab = TabPage1;
                }
            }
        }
        private void FOCO_NUEVO_REG(string contrato)
        {
            int i, cont = 0;
            cont = DGW.Columns.Count - 1;
            string nrocon = contrato;
            for (i = 0; i <= cont; i++)
            {
                if (nrocon == DGW.Rows[i].Cells["Contrato"].Value.ToString().ToLower())
                {
                    DGW.CurrentCell = DGW.Rows[i].Cells["Contrato"];
                    return;
                }
            }
        }
        private bool validaGrabar()
        {
            bool result = true;
            string errMensaje = "";
            int I = 0, CONT = 0;
            CONT = dgw_det.Rows.Count - 1;
            for (I = 0; I <= CONT; I++)
            {
                if (dgw_det[6, I].Value.ToString() == "" || dgw_det[6, I].Value.ToString() == "0.000")
                {
                    MessageBox.Show("VERIFICA QUE TODOS LOS DETALLES TENGAN PRECIO UNITARIO !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    btn_agregar.Focus();
                    return result = false;
                }
            }
            if (dgw_det.Rows.Count <= 0)
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
            if (chk_fec_contrato.Checked == false)
            {
                MessageBox.Show("INGRESE LA FECHA DEL CONTRATO !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                chk_fec_contrato.Focus();
                return result = false;
            }
            if (chk_fec_reporte.Checked == false)
            {
                MessageBox.Show("INGRESE LA FECHA DE REPORTE !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                chk_fec_reporte.Focus();
                return result = false;
            }
            if (txt_oc.Text.Trim() == "")
            {
                MessageBox.Show("INGRESE EL NRO DE REPORTE !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_oc.Focus();
                return result = false;
            }
            //if(!(dtp_oc.Value.Date <= FECHA_GRAL.Date && dtp_oc.Value.Date >= FECHA_INI.Date))
            //{
            //    MessageBox.Show("LA FECHA ESTA FUERA DEL RANGO !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    dtp_oc.Focus();
            //    return result = false;
            //}
            if (cboptovta.SelectedIndex == -1)
            {
                MessageBox.Show("Elija el Punto de Venta !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboptovta.Focus();
                return result = false;
            }
            if (cbo_lug_vta.SelectedIndex == -1)
            {
                MessageBox.Show("Elija el Lugar de Venta !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_lug_vta.Focus();
                return result = false;
            }
            if (cbo_prog.SelectedIndex == -1)
            {
                MessageBox.Show("Elija el Programa !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_prog.Focus();
                return result = false;
            }
            if (txt_mes.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el mes de reporte !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_mes.Focus();
                return result = false;
            }
            if (cbo_semana.SelectedIndex == -1)
            {
                MessageBox.Show("Elija la semana !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_semana.Focus();
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
            if (txt_cod2.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el codigo del vendedor !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TabControl2.SelectedTab = TabPage4;
                txt_cod2.Focus();
                return result = false;
            }
            if (txt_desc2.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el vendedor !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_desc2.Focus();
                return result = false;
            }
            if (lblsup.Text.Trim() == "" || lbldir.Text.Trim() == "" || lbldirn.Text.Trim() == "")
            {
                MessageBox.Show("Elija el cargos superiores !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_cod2.Focus();
                return result = false;
            }
            if (cbocandesc.SelectedIndex <= -1)
            {
                MessageBox.Show("Elija el Canal de Descuento !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbocandesc.Focus();
                return result = false;
            }
            if (cboptovta.SelectedIndex <= -1)
            {
                MessageBox.Show("Elija el sub Punto de Venta !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboptovta.Focus();
                return result = false;
            }
            if (CBO_PERSONAL.SelectedIndex == -1)
            {
                MessageBox.Show("Elija el usuario quien elaboro el Contrato !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                CBO_PERSONAL.Focus();
                return result = false;
            }
            if (cbo_modalidad_venta.SelectedIndex == -1)
            {
                MessageBox.Show("Elija la Modalidad de Venta !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_modalidad_venta.Focus();
                return result = false;
            }
            if (IMP_CUOTA_MES1 <= 0)
            {
                MessageBox.Show("Ingrese todos los datos del Plan de Pagos !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                button4.Focus();
                return result = false;
            }
            if (TOTAL_CONTRATO1 != Convert.ToDecimal(TXT_TT.Text))
            {
                MessageBox.Show("No coinciden los totales Revise el Plan de Pagos !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                button4.Focus();
                return result = false;
            }
            if (btn_grabar.Visible)
            {
                pccTo.COD_SUCURSAL = CBO_SUCURSAL.SelectedValue.ToString();
                pccTo.NRO_PRESUPUESTO = txt_numero.Text.Trim();
                if (pccBLL.VERIFICA_NRO_CONTROTATO_BLL(pccTo, ref errMensaje))
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
            if (!VerificaNumeracionContrato())
                return result = false;
            if (val_Semana_Contrato)
            {
                MessageBox.Show("No se encontró la fecha de Reporte en ninguna Semana de Reporte,\nREVISELO en el formulario correspondiente !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtp_oc.Focus();
                return result = false;
            }
            return result;
        }

        private void BTN_CONSULTA_Click(object sender, EventArgs e)
        {
            boton = "MODIFICAR";
            btn_grabar.Visible = false;
            btn_grabar2.Visible = false;
            btn_imprimir.Enabled = true;
            btn_oc.Enabled = true;
            TabControl1.SelectedTab = TabPage2;
            Panel1.Visible = true;
            Panel2.Visible = false;
            Panel0.Enabled = false;
            LIMPIAR_CABECERA();
            CARGAR_DATOS(DGW);
            CARGAR_DETALLES_DGW();
            gb_oc.Enabled = false;
            //CH_PV.Enabled = false;
            //ch_dif.Enabled = false;
            cbo_prog.Enabled = false;
            txt_oc.Enabled = false;
            dtp_oc.Enabled = false;
            txt_cod2.Enabled = false;
            txt_desc2.Enabled = false;
            gb_venta.Enabled = false;
            //gb_DEntrega.Enabled = false;
            btn_ajuste.Enabled = false;
            HALLAR_TOTAL_OC();
            chk_fec_contrato.Checked = true;
            chk_fec_reporte.Checked = true;
            btnConsultaCliente.Visible = true;
            btnNuevoCliente.Visible = false;
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
                            //
                            //CARGAR_CONTACTO();
                            //MostrarFormaPago();
                            //cbo_ni.Focus();
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

        private void dgw_per_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int idx = dgw_per.CurrentRow.Index;
                TXT_COD.Text = dgw_per[0, idx].Value.ToString();
                TXT_DESC.Text = dgw_per[1, idx].Value.ToString();
                txt_doc_per.Text = dgw_per[2, idx].Value.ToString();
                COD_INSTITUCION1 = dgw_per.Rows[idx].Cells["COD_INSTITUCION"].Value.ToString();
                lbl_institucion.Text = dgw_per.Rows[idx].Cells["DESC_INST"].Value.ToString();
                CARGAR_SUB_PUNTO_VENTA();

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

        private void txt_cod2_Leave(object sender, EventArgs e)
        {
            if (txt_cod2.Text.Trim() != "")
            {
                if (dgw_per2.Rows.Count > 0)
                {
                    dgw_per2.Sort(dgw_per2.Columns[0], System.ComponentModel.ListSortDirection.Ascending);
                    int i = 0, num2 = 0;
                    num2 = dgw_per2.Rows.Count - 1;
                    do
                    {
                        if (txt_cod2.Text.ToLower() == dgw_per2[0, i].Value.ToString().ToLower())
                        {
                            txt_cod2.Text = dgw_per2[0, i].Value.ToString();
                            txt_desc2.Text = dgw_per2[1, i].Value.ToString();
                            //txt_doc_per.Text = dgw_per2[2, i].Value.ToString();
                            //TabControl2.SelectedTab = TabPage10;    
                            cboptovta.Focus();
                            return;
                        }
                        if (txt_cod2.Text.ToLower() == dgw_per2[0, i].Value.ToString().ToLower().Substring(0, txt_cod2.TextLength))
                        {
                            dgw_per2.CurrentCell = dgw_per2.Rows[i].Cells[0];
                            break;
                        }
                        dgw_per2.CurrentCell = dgw_per2.Rows[0].Cells[0];
                        i += 1;
                    }
                    while (i <= num2);
                    panel_per2.Visible = true;
                    dgw_per2.Visible = true;
                    dgw_per2.Focus();
                }
            }
        }
        private void llenaSuperiores()
        {
            if (cbo_prog.SelectedValue == null)
            {
                MessageBox.Show("Elija un programa !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_prog.Focus();
                return;
            }
            pnrTo.COD_PROG = cbo_prog.SelectedValue.ToString();
            pnrTo.COD_VEND = txt_cod2.Text;
            DataTable dt = pnrBLL.obtenerNivelesSuperioresVendedorBLL(pnrTo);
            if (dt.Rows.Count > 0)
            {
                lblsup.Text = dt.Rows[2][5].ToString();
                lbldir.Text = dt.Rows[1][5].ToString();
                lbldirn.Text = dt.Rows[0][5].ToString();
                //lblalm.Text = dt.Rows[0][6].ToString();
                cbo_alm.SelectedValue = dt.Rows[0][4].ToString();
                codsup = dt.Rows[2][2].ToString();
                coddir = dt.Rows[1][2].ToString();
                coddirnac = dt.Rows[0][2].ToString();
            }
            else
            {
                MessageBox.Show("Vendedor no tiene  Equipo de Venta !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lblsup.Text = "";
                lbldir.Text = "";
                lbldirn.Text = "";
                cbo_alm.SelectedIndex = -1;
                codsup = "";
                coddir = "";
                coddirnac = "";
                txt_cod2.Text = "";
                txt_desc2.Text = "";
                txt_cod2.Focus();
            }

        }

        private void dgw_per2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int idx = dgw_per2.CurrentRow.Index;
                txt_cod2.Text = dgw_per2[0, idx].Value.ToString();
                txt_desc2.Text = dgw_per2[1, idx].Value.ToString();
                panel_per2.Visible = false;
                llenaSuperiores();
                VerificaNumeracionContrato();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                //Panel_PER.Visible = false;
                panel_per2.Visible = false;
                txt_cod2.Clear();
                txt_desc2.Clear();
                //txt_doc_per.Clear();
                txt_cod2.Focus();
            }
        }
        private bool VerificaNumeracionContrato()
        {
            bool result = true;
            if (txt_numero.Text != "" && lblsup.Text != "")
            {
                if (!VERIFICA_NUMERACION(txt_cod2.Text, Convert.ToInt64(txt_numero.Text)))
                {
                    MessageBox.Show("Este Nro de Contrato no está autorizado !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txt_cod2.Text = "";
                    txt_desc2.Text = "";
                    lbldirn.Text = "";
                    lbldir.Text = "";
                    lblsup.Text = "";
                    coddirnac = "";
                    coddir = "";
                    codsup = "";
                    cbo_alm.SelectedIndex = -1;
                    TabControl2.SelectedTab = TabPage3;
                    gb_oc.Focus();
                    txt_numero.Focus();
                    return result = false;
                }
                else
                {
                    groupBox3.Focus();
                    cbo_alm.TabIndex = 4;

                }
            }
            else if (lblsup.Text != "")
            {
                MessageBox.Show("Ingrese el Nro de Contrato !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TabControl2.SelectedTab = TabPage3;
                gb_oc.Focus();
                txt_numero.Focus();
            }
            return result;
        }
        private bool VERIFICA_NUMERACION(string COD_VEN, decimal nro_con)
        {
            bool flag = false;
            numeracionComprobanteBLL ncBLL = new numeracionComprobanteBLL();
            numeracionComprobanteTo ncTo = new numeracionComprobanteTo();
            ncTo.COD_VEN = COD_VEN;
            DataTable dt = ncBLL.obtenerNumeracionporVendedorBLL(ncTo);
            Int64 ini, fin = 0;
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow rw in dt.Rows)
                {
                    ini = Convert.ToInt64(rw[0]);
                    fin = Convert.ToInt64(rw[1]);
                    if (ini <= nro_con && nro_con <= fin)
                        return flag = true;
                }
                flag = false;
            }
            return flag;
        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            TabPage3.Select();
            gb_oc.Enabled = false;
            //CH_PV.Enabled = false;
            //ch_dif.Enabled = false;
            cbo_prog.Enabled = false;
            txt_oc.Enabled = true;
            dtp_oc.Enabled = false;
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
                    MessageBox.Show("No existen productos de la clase " + CBO_CLASE.Text, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                    MessageBox.Show("No existen productos de la clase " + CBO_CLASE.Text, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
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
                //CODARTCLI = null;
                //DESCARTCLI = null;
                //HALLAR_ART_CLIENTE();
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

        private void btn_guardar2_Click(object sender, EventArgs e)
        {
            if (!validaIngresoArticulo())
                return;
            HALLAR_VALOR_VENTA();
            string preunit = HelpersBLL.OBTIENE_PRECIO_TRES_DECIMALES(txt_pu1.Text);
            string cant = HelpersBLL.OBTIENE_PRECIO_TRES_DECIMALES(TXT_CANT.Text);
            //string impor = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(txt_bruto1.Text);
            string impor = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES((Convert.ToDecimal(TXT_PU.Text) * Convert.ToDecimal(TXT_CANT.Text)).ToString());
            dgw_det.Rows.Add(hallar_item(dgw_det.Rows.Count), TXT_COD_PRO.Text, TXT_DESC_PRO.Text,
                cant, "0.000", "0.000",
                preunit,
                impor, TXT_IGV.Text,
                STATUS_DSCTO == "1" ? TXT_DSCTO.Text : "0.00",//TXT_DSCTO.Text, 
                STATUS_IGV, txt_igv1.Text,
                STATUS_DSCTO == "1" ? "0.00" : txt_dscto1.Text,//txt_dscto1.Text,
                "0.00", "0.00",
                "D", obs.txt_obs.Text, STATUS_DSCTO, CODARTCLI, DESCARTCLI, PARTEARTCLI, "", "", COD_PRECIO2,
                chk_st_val_ref.Checked ? "1" : "0");//0 indica que el articulo ingresado individualmente entra como st_valor_referencial=0, o sea no es regalo, este campo no esta en la tabla de articulos sino en el de kit_detalle
            HALLAR_TOTAL_OC();
            LIMPIAR_DETALLES();
            TXT_COD_PRO.Focus();
        }
        private void HALLAR_TOTAL_OC()
        {
            decimal impor = 0, dscto = 0, igv = 0, neto = 0, total = 0;
            foreach (DataGridViewRow rw in dgw_det.Rows)
            {
                ////impor = impor + Convert.ToDecimal(rw.Cells[7].Value);
                ////dscto = dscto + Convert.ToDecimal(rw.Cells[12].Value);
                ////igv = igv + Convert.ToDecimal(rw.Cells[11].Value);
                ////neto = impor - dscto;
                ////total = neto + igv;
                //impor = impor + Convert.ToDecimal(rw.Cells[7].Value);
                //dscto = dscto + Convert.ToDecimal(rw.Cells[12].Value);
                if (rw.Cells["st_valor_referencial"].Value.ToString() == "0")
                {
                    impor = impor + Convert.ToDecimal(rw.Cells[7].Value);
                    igv = 0;//igv + Convert.ToDecimal(rw.Cells[11].Value);
                    dscto = dscto + Convert.ToDecimal(rw.Cells[12].Value);
                }


            }
            total = impor;
            //neto = total / 1.18M;
            //neto = total / (1 + Math.Round((igv0 / 100), 2));
            neto = total;
            //igv = total - neto;
            //TXT_TB.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(impor.ToString());
            //TXT_TD.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(dscto.ToString());
            //TXT_TN.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(neto.ToString());
            //TXT_TIGV.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(igv.ToString());
            //TXT_TT.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(total.ToString());
            TXT_TB.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES((impor - igv).ToString());
            TXT_TD.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(dscto.ToString());
            TXT_TN.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES((impor - igv).ToString());
            TXT_TIGV.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(igv.ToString());
            TXT_TT.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES((impor - dscto).ToString());
            DSCTO_TOTAL1 = dscto;
        }
        private string hallar_item(int it)
        {
            string ite = (it + 1).ToString();
            return ite.PadLeft(2, '0');
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

        private void btn_cancelar2_Click(object sender, EventArgs e)
        {
            Panel1.Visible = true;
            Panel2.Visible = false;
            btn_agregar.Select();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            decimal ttotal = Convert.ToDecimal(TXT_TT.Text);
            NRO_DIAS_VENC1 = Convert.ToInt32(txt_nro_dias.Text);
            frmPagos = new MOD_FACT_VTA.MOD_VTA.PLAN_DE_PAGOS_PRECONTRATO(ttotal, NRO_CUOTAS1, IMP_CUOTA_INICIAL1, IMP_CUOTA_MES1, FEC_PRIMER_VENC1, NRO_DIAS_VENC1, FEC_CUO_MEN1, MES, AÑO, FECHA_GRAL);
            if (btn_grabar.Visible)
            {
                frmPagos.ShowDialog();
                if (frmPagos.DialogResult == DialogResult.OK)
                {
                    TOTAL_CONTRATO1 = Convert.ToDecimal(frmPagos.txt_tot.Text);
                    NRO_CUOTAS1 = Convert.ToInt32(frmPagos.txtncuo.Text);
                    IMP_CUOTA_INICIAL1 = frmPagos.txt_ci.Text == "" ? 0 : Convert.ToDecimal(frmPagos.txt_ci.Text);
                    IMP_CUOTA_MES1 = Convert.ToDecimal(frmPagos.txtcuotas.Text);
                    FEC_PRIMER_VENC1 = frmPagos.dtp_vcto.Value.Date == DateTime.Now.AddYears(-10).Date ? (DateTime?)null : frmPagos.dtp_vcto.Value;
                    NRO_DIAS_VENC1 = Convert.ToInt32(frmPagos.txt_ndvcto.Text);
                    FEC_CUO_MEN1 = frmPagos.dtp_fmen.Value;
                    btn_grabar.Focus();
                }
            }
            else
            {
                frmPagos.txt_tot.Text = TOTAL_CONTRATO1.ToString();//TODO ESTE PARRAFO ES PARA QUE SE VEAN LOS DATOS DEL PLAN DE PAGOS EN EL FORMULARIO
                frmPagos.txt_ci.Text = IMP_CUOTA_INICIAL1.ToString();
                frmPagos.txtcuotas.Text = IMP_CUOTA_MES1.ToString();
                frmPagos.txtncuo.Text = NRO_CUOTAS1.ToString();
                frmPagos.dtp_vcto.Value = Convert.ToDateTime(FEC_PRIMER_VENC1);
                frmPagos.txt_ndvcto.Text = NRO_DIAS_VENC1.ToString();
                frmPagos.dtp_fmen.Value = FEC_CUO_MEN1;
                frmPagos.lblsaldo.Text = (Convert.ToDecimal(frmPagos.txt_tot.Text) - Convert.ToDecimal(frmPagos.txt_ci.Text)).ToString();
                frmPagos.ShowDialog();
                //
                if (frmPagos.txt_tot.Text != "")//ESTO ES PARA QUE MODIFIQUE EL PLAN DE PAGOS
                {
                    TOTAL_CONTRATO1 = Convert.ToDecimal(frmPagos.txt_tot.Text);
                    NRO_CUOTAS1 = Convert.ToInt32(frmPagos.txtncuo.Text);
                    IMP_CUOTA_INICIAL1 = frmPagos.txt_ci.Text == "" ? 0 : Convert.ToDecimal(frmPagos.txt_ci.Text);
                    IMP_CUOTA_MES1 = Convert.ToDecimal(frmPagos.txtcuotas.Text);
                    FEC_PRIMER_VENC1 = frmPagos.dtp_vcto.Value.Date == DateTime.Now.AddYears(-10).Date ? (DateTime?)null : frmPagos.dtp_vcto.Value;
                    NRO_DIAS_VENC1 = Convert.ToInt32(frmPagos.txt_ndvcto.Text);
                    FEC_CUO_MEN1 = frmPagos.dtp_fmen.Value;
                }
            }
        }

        private void TXT_PU_KeyDown(object sender, KeyEventArgs e)
        {
            if (HelpersBLL.IsNumeric(TXT_CANT.Text) && HelpersBLL.IsNumeric(TXT_PU.Text))
            {
                HALLAR_VALOR_VENTA();
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
                    txt_nro_dias.Text = "0";
                }
            }
        }

        private void TXT_CANT_Leave(object sender, EventArgs e)
        {
            TXT_CANT.Text = HelpersBLL.OBTIENE_PRECIO_TRES_DECIMALES(TXT_CANT.Text);
        }

        private void TXT_PU_Leave(object sender, EventArgs e)
        {
            TXT_PU.Text = HelpersBLL.OBTIENE_PRECIO_TRES_DECIMALES(TXT_PU.Text);
        }

        private void btn_mod_Click(object sender, EventArgs e)
        {
            try
            {
                int num = dgw_det.CurrentRow.Index;
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
            if (Convert.ToDecimal(dgw_det[4, dgw_det.CurrentRow.Index].Value) != 0 && dgw_det[22, dgw_det.CurrentRow.Index].Value.ToString() == "")
            {
                MessageBox.Show("EL DETALLE YA SE INGRESO !!!", "NO SE PUEDE MODIFICAR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else if (Convert.ToDecimal(dgw_det[5, dgw_det.CurrentRow.Index].Value) != 0)
            {
                MessageBox.Show("EL DETALLE SE HA ANULADO !!!", "NO SE PUEDE MODIFICAR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                btn_guardar2.Visible = false;
                btn_mod2.Visible = true;
                Panel1.Visible = false;
                Panel2.Visible = true;
                LIMPIAR_DETALLES();
                CARGAR_DETALLE1();
                HALLAR_VALOR_VENTA();
                TXT_CANT.Focus();
            }
        }
        private void CARGAR_DETALLE1()
        {
            int idx = dgw_det.CurrentRow.Index;
            TXT_COD_PRO.Text = dgw_det[1, idx].Value.ToString();
            TXT_DESC_PRO.Text = dgw_det[2, idx].Value.ToString();
            TXT_COD_PRO.Focus();
            TXT_PU.Focus();
            COD_PRECIO2 = dgw_det[18, idx].Value.ToString();
            decimal PrecioUnitario = Convert.ToDecimal(dgw_det[6, idx].Value);
            TXT_CANT.Text = dgw_det[3, idx].Value.ToString();
            TXT_IGV.Text = dgw_det[8, idx].Value.ToString();
            if (CH_PV.Checked)
            {
                TXT_PU.Text = dgw_det[6, idx].Value.ToString();//(PrecioUnitario + (PrecioUnitario * (Convert.ToDecimal(TXT_IGV.Text) / 100))).ToString();
                TXT_PU.Text = HelpersBLL.OBTIENE_PRECIO_TRES_DECIMALES(TXT_PU.Text);
            }
            else
                TXT_PU.Text = HelpersBLL.OBTIENE_PRECIO_TRES_DECIMALES(TXT_PU.Text);

            txt_bruto1.Text = dgw_det[7, idx].Value.ToString();
            TXT_DSCTO.Text = dgw_det.Rows[idx].Cells["st_por_dscto"].Value.ToString() == "1" ? dgw_det[9, idx].Value.ToString() : dgw_det[12, idx].Value.ToString();
            if (dgw_det[10, idx].Value.ToString() == "1")
                CH_IGV.Checked = true;
            else
                CH_IGV.Checked = false;
            obs.txt_obs.Text = dgw_det[16, idx].Value.ToString();
            if (dgw_det.Rows[idx].Cells["st_por_dscto"].Value.ToString() == "1")
                ch_dscto.Checked = true;
            else
                ch_dscto.Checked = false;
            //if (dgw_det[17, idx].Value.ToString() == "1")
            //    ch_dscto.Checked = true;
            //else
            //    ch_dscto.Checked = false;
        }
        private void llenaCbo_Semana_Contrato()
        {
            semanaContratoBLL scBLL = new semanaContratoBLL();
            semanaContratoTo scTo = new semanaContratoTo();
            txt_mes.Text = dtp_oc.Value.ToShortDateString().Substring(3, 7);
            char[] separador = { '/' };
            string[] palabra = txt_mes.Text.Split(separador);
            scTo.FE_MES = palabra[0];
            scTo.FE_AÑO = palabra[1];
            dtSemanaContrato = scBLL.obtenerSemanaContratoparaPreventaBLL(scTo);
            if (dtSemanaContrato.Rows.Count > 0)
            {
                cbo_semana.ValueMember = "NRO_SEMANA";
                cbo_semana.DisplayMember = "NOM_SEMANA";
                cbo_semana.DataSource = dtSemanaContrato;
                //
                val_Semana_Contrato = true;
                foreach (DataRow rw in dtSemanaContrato.Rows)
                {
                    if (Convert.ToDateTime(rw["FE_DEL"]) <= dtp_oc.Value.Date && dtp_oc.Value.Date <= Convert.ToDateTime(rw["FE_AL"]))
                    {
                        cbo_semana.SelectedValue = rw["NRO_SEMANA"].ToString();
                        val_Semana_Contrato = false;
                        break;
                    }
                }
                if (val_Semana_Contrato)
                {
                    MessageBox.Show("No se encontró la fecha de Reporte en ninguna Semana de Reporte,\nREVISELO en el formulario correspondiente !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dtp_oc.Focus();
                }
            }
        }
        private bool validaSemanaContrato()
        {
            bool result = true;
            if (txt_mes.Text.Trim() != "")
            {
                if (txt_mes.Text.Length != 7)
                {
                    MessageBox.Show("Escriba correctamente el mes y el año !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txt_mes.Focus();
                    return result = false;
                }
                if (txt_mes.Text.Substring(2, 1) != "/")
                {
                    MessageBox.Show("Escriba correctamente el mes y el año !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txt_mes.Focus();
                    return result = false;
                }
            }
            else
            {
                cbo_tipo_planilla.Focus();
                return result = false;
            }
            return result;
        }

        private void TXT_TC_Leave(object sender, EventArgs e)
        {
            TXT_TC.Text = HelpersBLL.OBTIENE_PRECIO_CUATRO_DECIMALES(TXT_TC.Text);
        }

        private void btn_obs_Click(object sender, EventArgs e)
        {
            obs.txt_obs.MaxLength = 800;
            obs.Show();
        }

        private void btn_eliminar2_Click(object sender, EventArgs e)
        {
            int idx = -1;
            try
            {
                idx = dgw_det.CurrentRow.Index;
            }
            catch (Exception)
            {
                MessageBox.Show("DEBE DE ELEGIR UN REGISTRO !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (Convert.ToDecimal(dgw_det[4, idx].Value) != 0)
            {
                MessageBox.Show("EL DETALLE YA SE INGRESO !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (Convert.ToDecimal(dgw_det[5, idx].Value) != 0)
            {
                MessageBox.Show("EL DETALLE SE HA ANULADO !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                DialogResult rs = MessageBox.Show("¿ ESTA SEGURO DE ELIMINAR EL REGISTRO ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    dgw_det.Rows.RemoveAt(dgw_det.CurrentRow.Index);
                }
                HALLAR_TOTAL_OC();
            }
        }

        private void btn_mod2_Click(object sender, EventArgs e)
        {
            if (!validaModificaUnRegistro())
                return;
            string str = CH_IGV.Checked ? "1" : "0";
            int idx = dgw_det.CurrentRow.Index;
            dgw_det[1, idx].Value = TXT_COD_PRO.Text;
            dgw_det[2, idx].Value = TXT_DESC_PRO.Text;
            dgw_det[3, idx].Value = HelpersBLL.OBTIENE_PRECIO_TRES_DECIMALES(TXT_CANT.Text);
            dgw_det[6, idx].Value = HelpersBLL.OBTIENE_PRECIO_TRES_DECIMALES(txt_pu1.Text);
            dgw_det[7, idx].Value = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES((Convert.ToDecimal(TXT_PU.Text) * Convert.ToDecimal(TXT_CANT.Text)).ToString());//HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(txt_bruto1.Text);
            dgw_det[8, idx].Value = TXT_IGV.Text;
            dgw_det[9, idx].Value = STATUS_DSCTO == "1" ? TXT_DSCTO.Text : "0.00";
            dgw_det[10, idx].Value = str;
            dgw_det[11, idx].Value = txt_igv1.Text;
            dgw_det[12, idx].Value = STATUS_DSCTO == "1" ? txt_dscto1.Text : TXT_DSCTO.Text;
            dgw_det[16, idx].Value = obs.txt_obs.Text;
            dgw_det[17, idx].Value = STATUS_DSCTO;
            dgw_det[18, idx].Value = COD_PRECIO2;
            dgw_det.Rows[idx].Cells["st_valor_referencial"].Value = chk_st_val_ref.Checked ? "1" : "0";
            dgw_det.Rows[idx].Cells["st_por_dscto"].Value = ch_dscto.Checked ? "1" : "0";
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

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            TabControl1.SelectedTab = TabPage1;
            btn_nuevo.Select();
        }

        private void btn_nuevo2_Click(object sender, EventArgs e)
        {
            boton = "NUEVO";
            btn_grabar.Visible = true;
            btn_grabar2.Visible = false;
            btn_grabar.Enabled = true;
            btn_imprimir.Enabled = false;
            TabControl1.SelectedTab = TabPage2;
            Panel1.Visible = true;
            Panel2.Visible = false;
            Panel0.Enabled = true;
            //ListaIngresos.Clear();
            LIMPIAR_CABECERA();
            txt_numero.Enabled = true;
            CBO_SUCURSAL.Focus();
        }

        private void btn_aprobado_Click(object sender, EventArgs e)
        {
            if (!validarAprobado())
                return;
            DIALOGOS.APROBADO_POR aprob = new DIALOGOS.APROBADO_POR(FECHA_INI, FECHA_GRAL, TIPO_USU, "PreContrato");
            aprob.a_COD_SUCURSAL3 = DGW.CurrentRow.Cells["COD_SUCURSAL"].Value.ToString();//DGW[0, DGW.CurrentRow.Index].Value.ToString();
            aprob.a_COD_CLASE3 = DGW.CurrentRow.Cells["cod_clase"].Value.ToString();//DGW[2, DGW.CurrentRow.Index].Value.ToString();
            aprob.a_COD_PER3 = DGW.CurrentRow.Cells["cod_per"].Value.ToString();//DGW[4, DGW.CurrentRow.Index].Value.ToString();
            aprob.a_NRO_DOC3 = DGW.CurrentRow.Cells["Contrato"].Value.ToString();//DGW[7, DGW.CurrentRow.Index].Value.ToString();
            aprob.AÑO0 = DGW.CurrentRow.Cells["FE_AÑO"].Value.ToString();//DGW[22, DGW.CurrentRow.Index].Value.ToString();
            aprob.MES0 = DGW.CurrentRow.Cells["FE_MES"].Value.ToString();//DGW[23, DGW.CurrentRow.Index].Value.ToString();
            //aprob.DTP_DOC.Value = FECHA_GRAL;
            aprob.ShowDialog();
            string cont2 = DGW.CurrentRow.Cells["Contrato"].Value.ToString();//DGW[7, DGW.CurrentRow.Index].Value.ToString();
            DATAGRID();
            //FOCO_NUEVO_REG2(cont2);
        }
        private bool validarAprobado()
        {
            bool result = true;
            //if(Convert.ToBoolean(DGW[16,DGW.CurrentRow.Index].Value))
            if (Convert.ToBoolean(DGW.CurrentRow.Cells["Cie"].Value))
            {
                MessageBox.Show("EL Pre-Contrato se encuentra totalmente enviado !!!", "YA SE ENCUENTRA CERRADO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return result = false;
            }
            return result;
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
            TabControl1.SelectedTab = TabPage2;
            Panel1.Visible = true;
            Panel2.Visible = false;
            Panel0.Enabled = true;
            COD_INSTITUCION1 = DGW.CurrentRow.Cells["COD_INSTITUCION"].Value.ToString();
            lbl_institucion.Text = DGW.CurrentRow.Cells["DESC_INST"].Value.ToString();
            CARGAR_SUB_PUNTO_VENTA();//llena punto de venta
            //llenaLugarVenta();//llena lugar de venta
            LIMPIAR_CABECERA();
            CARGAR_DATOS(DGW);
            CARGAR_DETALLES_DGW();
            //gb_oc.Enabled = false;
            CH_PV.Enabled = false;
            txt_oc.Enabled = true;
            dtp_oc.Enabled = false;
            txt_cod2.Enabled = false;
            txt_desc2.Enabled = false;
            txt_numero.Enabled = false;
            campos_clave_modificacion(false);
            HALLAR_TOTAL_OC();
            chk_fec_contrato.Checked = true;
            chk_fec_reporte.Checked = true;
            btn_agregar.Focus();
        }
        private void campos_clave_modificacion(bool val)
        {
            CBO_SUCURSAL.Enabled = val;
            CBO_CLASE.Enabled = val;
            TXT_COD.Enabled = val;
            TXT_DESC.Enabled = val;
            txt_doc_per.Enabled = val;
            btn_refresh.Enabled = val;
        }
        private void CARGAR_DATOS(DataGridView DGW0)
        {
            int idx = DGW0.CurrentRow.Index;
            CBO_SUCURSAL.SelectedValue = DGW0.Rows[idx].Cells["COD_SUCURSAL"].Value;//DGW0[0, idx].Value;
            CBO_CLASE.SelectedValue = DGW0.Rows[idx].Cells["cod_clase"].Value.ToString();//DGW0[2, idx].Value;
            TXT_COD.Text = DGW0.Rows[idx].Cells["cod_per"].Value.ToString();//DGW0[4, idx].Value.ToString();
            TXT_DESC.Text = DGW0.Rows[idx].Cells["Cliente"].Value.ToString();//DGW0[5, idx].Value.ToString();
            txt_doc_per.Text = DGW0.Rows[idx].Cells["NRO_DOC"].Value.ToString();//DGW0[6, idx].Value.ToString();
            txt_numero.Text = DGW0.Rows[idx].Cells["Contrato"].Value.ToString();//DGW0[7, idx].Value.ToString();
            DTP_DOC.Value = Convert.ToDateTime(DGW0.Rows[idx].Cells["Fecha"].Value);//Convert.ToDateTime(DGW0[8, idx].Value);
            CBO_MONEDA.SelectedValue = DGW0.Rows[idx].Cells["cod_moneda"].Value.ToString();//DGW0[9, idx].Value;
            TXT_TC.Text = DGW0.Rows[idx].Cells["tipo_cambio"].Value.ToString();//DGW0[10, idx].Value.ToString();
            AÑO0 = DGW0.Rows[idx].Cells["FE_AÑO"].Value.ToString();//DGW0[22, idx].Value.ToString();
            MES0 = DGW0.Rows[idx].Cells["FE_MES"].Value.ToString();//DGW0[23, idx].Value.ToString();
            txt_oc.Text = DGW0.Rows[idx].Cells["NRO_REPORTE"].Value.ToString();//DGW0[27, idx].Value.ToString();
            dtp_oc.Value = Convert.ToDateTime(DGW0.Rows[idx].Cells["FEC_REPORTE"].Value);//Convert.ToDateTime(DGW0[28, idx].Value);
            cbo_prog.SelectedValue = DGW0.Rows[idx].Cells["COD_PROGRAMA"].Value;//DGW0[29, idx].Value;
            txt_mes.Text = DGW0.Rows[idx].Cells["PERIODO"].Value.ToString();//DGW0[30, idx].Value.ToString();
            llenaCbo_Semana_Contrato();
            cbo_semana.SelectedValue = DGW0.Rows[idx].Cells["NRO_SEMANA"].Value;//DGW0[31, idx].Value;
            cbo_tipo_planilla.SelectedValue = DGW0.Rows[idx].Cells["TIPO_PLANILLA"].Value;//DGW0[32, idx].Value;
            CBO_PAGO.SelectedValue = DGW0.Rows[idx].Cells["forma_pago"].Value;//DGW0[11, idx].Value;
            cbo_VENTA.SelectedValue = DGW0.Rows[idx].Cells["CONDICION_VENTA"].Value;//DGW0[21, idx].Value;
            //TXT_OBS_ENTREGA.Text = DGW0[12, idx].Value.ToString();
            obs2.txt_obs.Text = DGW0.Rows[idx].Cells["OBS_VAC"].Value.ToString();//DGW0[12, idx].Value.ToString();
            CBO_PERSONAL.SelectedValue = DGW0.Rows[idx].Cells["ELAB"].Value;//DGW0[15, idx].Value;
            txt_nro_dias.Text = DGW0.Rows[idx].Cells["nro_dias"].Value.ToString();//DGW0[14 ,idx].Value.ToString();
            txt_cod2.Text = DGW0.Rows[idx].Cells["cod_vendedor"].Value.ToString();//DGW0[17 ,idx].Value.ToString();
            prmTo.COD_PER = txt_cod2.Text;
            txt_desc2.Text = prmBLL.obtenerNombrePersonaporCOD_PERBLL(prmTo);
            llenaSuperiores();
            txtsbas.Text = DGW0.Rows[idx].Cells["SUELDO_BASICO"].Value.ToString();//DGW0[37, idx].Value.ToString();
            txtsbru.Text = DGW0.Rows[idx].Cells["SUELDO_BRUTO"].Value.ToString();//DGW0[38, idx].Value.ToString();
            txt_otro_desc.Text = DGW0.Rows[idx].Cells["OTROS_DSCTOS"].Value.ToString();//DGW0[39, idx].Value.ToString();
            txt_judicial.Text = DGW0.Rows[idx].Cells["JUDICIALES"].Value.ToString();//DGW0[40, idx].Value.ToString();
            txt_neto_cob.Text = DGW0.Rows[idx].Cells["NETO_COBRAR"].Value.ToString();//DGW0[41, idx].Value.ToString();
            decimal ttotal = Convert.ToDecimal(DGW0.Rows[idx].Cells["TOTAL_CONTRATO"].Value);//Convert.ToDecimal(DGW0[42,idx].Value);
            MOD_FACT_VTA.MOD_VTA.PLAN_DE_PAGOS_PRECONTRATO frmPagos = new MOD_FACT_VTA.MOD_VTA.PLAN_DE_PAGOS_PRECONTRATO(ttotal, NRO_CUOTAS1, IMP_CUOTA_INICIAL1, IMP_CUOTA_MES1, FEC_PRIMER_VENC1, NRO_DIAS_VENC1, FEC_CUO_MEN1, MES, AÑO, FECHA_GRAL);
            frmPagos.txt_tot.Text = DGW0.Rows[idx].Cells["TOTAL_CONTRATO"].Value.ToString();//DGW0[42, idx].Value.ToString();
            frmPagos.txtncuo.Text = DGW0.Rows[idx].Cells["NRO_CUOTAS"].Value.ToString();//DGW0[43, idx].Value.ToString();
            frmPagos.txt_ci.Text = DGW0.Rows[idx].Cells["IMP_CUOTA_INICIAL"].Value.ToString(); //DGW0[44, idx].Value.ToString();
            frmPagos.txtcuotas.Text = DGW0.Rows[idx].Cells["IMP_CUOTA_MES"].Value.ToString();//DGW0[45, idx].Value.ToString();
            frmPagos.dtp_vcto.Value = DGW0.Rows[idx].Cells["FEC_PRIMER_VENC"].Value.ToString() == "" ? DateTimePicker.MinimumDateTime : Convert.ToDateTime(DGW0.Rows[idx].Cells["FEC_PRIMER_VENC"].Value);//DGW0[46, idx].Value.ToString() == "" ? DateTimePicker.MinimumDateTime : Convert.ToDateTime(DGW0[46, idx].Value);
            TOTAL_CONTRATO1 = Convert.ToDecimal(DGW0.Rows[idx].Cells["TOTAL_CONTRATO"].Value);//Convert.ToDecimal(DGW0[42, idx].Value);
            NRO_CUOTAS1 = Convert.ToInt32(DGW0.Rows[idx].Cells["NRO_CUOTAS"].Value);//Convert.ToInt32(DGW0[43, idx].Value);
            IMP_CUOTA_INICIAL1 = Convert.ToDecimal(DGW0.Rows[idx].Cells["IMP_CUOTA_INICIAL"].Value);//Convert.ToDecimal(DGW0[44, idx].Value);
            IMP_CUOTA_MES1 = Convert.ToDecimal(DGW0.Rows[idx].Cells["IMP_CUOTA_MES"].Value);//Convert.ToDecimal(DGW0[45, idx].Value);
            FEC_PRIMER_VENC1 = frmPagos.dtp_vcto.Value;
            NRO_DIAS_VENC1 = Convert.ToInt32(DGW0.Rows[idx].Cells["NRO_DIAS_VENC"].Value);//Convert.ToInt32(DGW0[47, idx].Value);
            FEC_CUO_MEN1 = Convert.ToDateTime(DGW0.Rows[idx].Cells["FEC_CUO_MEN"].Value);//Convert.ToDateTime(DGW0[48,idx].Value);
            cboptovta.SelectedValue = DGW0.Rows[idx].Cells["COD_SUB_PTO_VEN"].Value;//DGW0[49, idx].Value.ToString();
            llenaLugarVenta();//llena lugar de venta
            cbocandesc.SelectedValue = DGW0.Rows[idx].Cells["COD_CANAL_DSCTO"].Value;//DGW0[50, idx].Value.ToString();
            cboptocob.SelectedValue = DGW0.Rows[idx].Cells["COD_PTO_COB"].Value;//DGW0[51, idx].Value.ToString();
            cbo_tipo_venta.SelectedValue = DGW0.Rows[idx].Cells["COD_TIPO_VENTA"].Value;//DGW0[52, idx].Value.ToString();
            cbo_modalidad_venta.SelectedValue = DGW0.Rows[idx].Cells["COD_MODALIDAD_VTA"].Value;//DGW0[53, idx].Value.ToString();
            cbo_lug_vta.SelectedValue = DGW0.CurrentRow.Cells["COD_LUG_VTA"].Value.ToString();
            lbl_institucion.Text = DGW0.CurrentRow.Cells["DESC_INST"].Value.ToString();
            txt_imp_proteccion.Text = DGW0.CurrentRow.Cells["IMPORTE_PROTECCION"].Value.ToString();
            COD_KIT1 = DGW0.CurrentRow.Cells["COD_KIT"].Value.ToString();
            DSCTO_TOTAL1 = Convert.ToDecimal(DGW0.CurrentRow.Cells["DSCTO_TOTAL"].Value);
            calculo_Neto_Cobrar();
        }
        private void CARGAR_DETALLES_DGW()
        {
            dgw_det.Rows.Clear();
            pcdTo.COD_CLASE = CBO_CLASE.SelectedValue.ToString();
            pcdTo.COD_SUCURSAL = CBO_SUCURSAL.SelectedValue.ToString();
            pcdTo.COD_PER = TXT_COD.Text;
            pcdTo.NRO_PRESUPUESTO = txt_numero.Text;
            pcdTo.FE_AÑO = AÑO0;
            pcdTo.FE_MES = MES0;
            DataTable dt = pcdBLL.obtenerPreContratoDetalleBLL(pcdTo);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow rw in dt.Rows)
                {
                    int idx = dgw_det.Rows.Add();
                    DataGridViewRow row = dgw_det.Rows[idx];
                    row.Cells[0].Value = rw[0].ToString();
                    row.Cells[1].Value = rw[1].ToString();
                    row.Cells[2].Value = rw[2].ToString();
                    row.Cells[3].Value = rw[3].ToString();
                    row.Cells[4].Value = rw[4].ToString();
                    row.Cells[5].Value = rw[5].ToString();
                    row.Cells[6].Value = rw[6].ToString();
                    row.Cells[7].Value = rw[7].ToString();
                    row.Cells[8].Value = rw[8].ToString();
                    row.Cells[9].Value = rw[9].ToString();
                    row.Cells[10].Value = rw[10].ToString();
                    row.Cells[11].Value = rw[11].ToString();
                    row.Cells[12].Value = rw[12].ToString();
                    row.Cells[13].Value = rw[13].ToString();
                    row.Cells[14].Value = rw[14].ToString();
                    row.Cells[15].Value = rw[15].ToString();
                    row.Cells[16].Value = rw[16].ToString();
                    row.Cells[17].Value = rw[17].ToString();
                    row.Cells[18].Value = rw[18].ToString();
                    row.Cells[19].Value = rw[19].ToString();
                    row.Cells[20].Value = rw[20].ToString();
                    row.Cells[21].Value = rw[21].ToString();
                    row.Cells[22].Value = "";
                    row.Cells[23].Value = "";
                    row.Cells["st_valor_referencial"].Value = rw["ST_VALOR_REFERENCIAL"].ToString();
                    row.Cells["st_por_dscto"].Value = rw["STATUS_POR_DSCTO"].ToString();
                }
            }
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
            //if(Convert.ToBoolean(DGW[16, DGW.CurrentRow.Index].Value))
            if (Convert.ToBoolean(DGW.CurrentRow.Cells["Cie"].Value))
            {
                MessageBox.Show("EL PRECONTRATO SE ENCUENTRA TOTALMENTE ENVIADO !!!", "NO SE PUEDE MODIFICAR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return result = false;
            }
            //if(Convert.ToBoolean(DGW[19, DGW.CurrentRow.Index].Value))//como ingresa como aprobado desde el inicio ya no debe preguntar esto o sino no se podria modificar 
            //{
            //    MessageBox.Show("EL PRECONTRATO SE ENCUENTRA APROBADO !!!", "YA SE ENCUENTRA APROBADO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return result = false;
            //}
            //if (Convert.ToBoolean(DGW[20, DGW.CurrentRow.Index].Value))
            if (Convert.ToBoolean(DGW.CurrentRow.Cells["Anul"].Value))
            {
                MessageBox.Show("EL PRECONTRATO SE ENCUENTRA ANULADO !!!", "YA SE ENCUENTRA ANULADO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return result = false;
            }
            return result;
        }

        private void cbo_VENTA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_VENTA.SelectedValue != null)
            {
                string cod_venta = cbo_VENTA.SelectedValue.ToString();
                txt_nro_dias.Text = helBLL.NRO_DIAS_CONDICION_VENTABLL(cod_venta);
            }
        }

        private void btn_grabar2_Click(object sender, EventArgs e)
        {
            if (!validaGrabar())
                return;

            DialogResult rs = MessageBox.Show("¿ Esta seguro de Modificar el Pre-Contrato ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                COD_SUCURSAL1 = CBO_SUCURSAL.SelectedValue.ToString();
                STATUS_PV1 = CH_PV.Checked ? "1" : "0";
                COD_ELAB = "";
                COD_FORMA_PAGO = "";
                COD_MOV = "";
                COD_VENTA = "";
                COD_PRECIO1 = "";
                COD_CONTACTO1 = "";
                ST_DIF = "0";
                COD_ELAB = CBO_PERSONAL.SelectedValue.ToString();
                COD_FORMA_PAGO = CBO_PAGO.SelectedValue.ToString();
                //COD_MOV = cbo_movimiento.SelectedValue.ToString();
                COD_VENTA = cbo_VENTA.SelectedValue == null ? "" : cbo_VENTA.SelectedValue.ToString();
                COD_CLASE1 = CBO_CLASE.SelectedValue.ToString();
                COD_MONEDA1 = CBO_MONEDA.SelectedValue.ToString();
                //string  AÑO = DateTime.Now.Year.ToString();
                //string MES = DateTime.Now.Month.ToString("00");
                //
                pccTo.COD_SUCURSAL = COD_SUCURSAL1;
                pccTo.NRO_PRESUPUESTO = txt_numero.Text;
                pccTo.COD_PER = TXT_COD.Text;
                pccTo.COD_CLASE = COD_CLASE1;
                pccTo.FE_AÑO = AÑO;
                pccTo.FE_MES = MES;
                pccTo.FECHA_PRE = DTP_DOC.Value;
                pccTo.COD_MONEDA = COD_MONEDA1;
                pccTo.TIPO_CAMBIO = Convert.ToDecimal(TXT_TC.Text);
                pccTo.FORMA_PAGO = COD_FORMA_PAGO;
                //pccTo.OBSERVACION = TXT_OBS_ENTREGA.Text;
                pccTo.OBSERVACION = obs2.txt_obs.Text;
                pccTo.STATUS_PV = STATUS_PV1;
                pccTo.NRO_DIAS = Convert.ToInt32(txt_nro_dias.Text);
                pccTo.COD_PER_ELAB = COD_ELAB;
                pccTo.COD_PER_APROB = "";
                pccTo.STATUS_APROB = "0";
                pccTo.STATUS_ANUL = "0";
                pccTo.STATUS_CIERRE = "0";
                pccTo.COD_VENDEDOR = txt_cod2.Text;
                pccTo.NOMBRE_PC = NOMBRE_PC;
                pccTo.CONDICION_VENTA = COD_VENTA;
                pccTo.COD_CONTACTO = COD_CONTACTO1;
                pccTo.FECHA_APROB = null;//*******
                pccTo.TIPO_PRECIO = COD_PRECIO1;
                pccTo.NRO_REPORTE = txt_oc.Text;
                pccTo.FEC_REPORTE = dtp_oc.Value;
                pccTo.COD_PROGRAMA = cbo_prog.SelectedValue.ToString();
                pccTo.PERIODO = txt_mes.Text;
                pccTo.NRO_SEMANA = cbo_semana.SelectedValue.ToString();
                pccTo.TIPO_PLANILLA = cbo_tipo_planilla.SelectedValue.ToString();
                pccTo.COD_ALMACEN = cbo_alm.SelectedValue.ToString();
                pccTo.COD_NIVEL1 = coddirnac;
                pccTo.COD_NIVEL2 = coddir;
                pccTo.COD_NIVEL3 = codsup;
                pccTo.SUELDO_BASICO = Convert.ToDecimal(txtsbas.Text);
                pccTo.SUELDO_BRUTO = Convert.ToDecimal(txtsbru.Text);
                pccTo.OTROS_DSCTOS = txt_otro_desc.Text.Trim() == "" ? 0 : Convert.ToDecimal(txt_otro_desc.Text);
                pccTo.JUDICIALES = txt_judicial.Text.Trim() == "" ? 0 : Convert.ToDecimal(txt_judicial.Text);
                pccTo.NETO_COBRAR = txt_neto_cob.Text.Trim() == "" ? 0 : Convert.ToDecimal(txt_neto_cob.Text);
                pccTo.TOTAL_CONTRATO = TOTAL_CONTRATO1;
                pccTo.NRO_CUOTAS = NRO_CUOTAS1;
                pccTo.IMP_CUOTA_INICIAL = IMP_CUOTA_INICIAL1;
                pccTo.IMP_CUOTA_MES = IMP_CUOTA_MES1;
                pccTo.FEC_PRIMER_VENC = FEC_PRIMER_VENC1;
                pccTo.NRO_DIAS_VENC = NRO_DIAS_VENC1;
                pccTo.FEC_CUO_MEN = FEC_CUO_MEN1;
                pccTo.COD_SUB_PTO_VEN = cboptovta.SelectedValue.ToString();
                pccTo.COD_PTO_COB = cboptocob.SelectedValue.ToString();
                pccTo.COD_CANAL_DSCTO = cbocandesc.SelectedValue.ToString();
                pccTo.COD_TIPO_VENTA = cbo_tipo_venta.SelectedValue.ToString();
                pccTo.COD_MODALIDAD_VTA = cbo_modalidad_venta.SelectedValue.ToString();
                pccTo.COD_LUG_VTA = cbo_lug_vta.SelectedValue.ToString();
                pccTo.COD_INSTITUCION = COD_INSTITUCION1;
                pccTo.IMPORTE_PROTECCION = txt_imp_proteccion.Text.Trim() == "" ? 0 : Convert.ToDecimal(txt_imp_proteccion.Text);
                pccTo.COD_KIT = COD_KIT1;
                pccTo.DSCTO_TOTAL = DSCTO_TOTAL1;
                dt00.Rows.Clear();
                int num = dgw_det.Rows.Count - 1;
                int num3 = num;
                int i = 0;
                while (i <= num3)
                {
                    dt00.Rows.Add(COD_SUCURSAL1, "", TXT_COD.Text, COD_CLASE1, AÑO, MES, dgw_det[0, i].Value.ToString(), dgw_det[1, i].Value.ToString(),
                        Convert.ToDecimal(dgw_det[3, i].Value), Convert.ToDecimal(dgw_det[4, i].Value),
                        Convert.ToDecimal(dgw_det[5, i].Value), Convert.ToDecimal(dgw_det[6, i].Value), Convert.ToDecimal(dgw_det[7, i].Value),
                        Convert.ToDecimal(dgw_det[8, i].Value), Convert.ToDecimal(dgw_det[9, i].Value), dgw_det[10, i].Value.ToString(), Convert.ToDecimal(dgw_det[11, i].Value),
                        Convert.ToDecimal(dgw_det[12, i].Value), Convert.ToDecimal(dgw_det[13, i].Value), Convert.ToDecimal(dgw_det[14, i].Value),
                        dgw_det[15, i].Value.ToString(), dgw_det[16, i].Value.ToString(),// dgw_det[17, i].Value.ToString(), dgw_det[18, i].Value.ToString(), dgw_det[19, i].Value.ToString(),
                        NOMBRE_PC, dgw_det[21, i].Value.ToString(), dgw_det[2, i].Value.ToString(), dgw_det[23, i].Value.ToString(),
                        dgw_det.Rows[i].Cells["st_valor_referencial"].Value.ToString(), dgw_det.Rows[i].Cells["st_por_dscto"].Value.ToString());
                    i++;
                }

                if (!pccBLL.modificaPreContratoBLL(pccTo, dt00, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Se modificó correctamente el Pre-Contrato !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //gb_oc.Enabled = false;
                    Panel1.Visible = true;
                    btn_grabar.Enabled = false;
                    Panel2.Visible = false;
                    Panel0.Enabled = false;
                    btn_imprimir.Enabled = true;
                    DATAGRID(); FOCO_NUEVO_REG(txt_numero.Text.Trim());
                    //btn_imprimir.Select();
                    //
                    //DGW.Rows.Add(CBO_SUCURSAL.Text, CBO_CLASE.Text, TXT_DESC.Text, "001" + "-" + txt_numero.Text, DTP_DOC.Value.ToShortDateString(), false, false);
                    TabControl1.SelectedTab = TabPage1;
                }
            }
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
            bool flag2 = false;
            string str4, str2, str3, str6, str, str5 = "";
            int idx = DGW.CurrentRow.Index;
            str4 = DGW.Rows[idx].Cells["COD_SUCURSAL"].Value.ToString();//DGW[0, idx].Value.ToString();
            str2 = DGW.Rows[idx].Cells["cod_clase"].Value.ToString();//DGW[2, idx].Value.ToString();
            str3 = DGW.Rows[idx].Cells["cod_per"].Value.ToString();//DGW[4, idx].Value.ToString();
            str6 = DGW.Rows[idx].Cells["Contrato"].Value.ToString();//DGW[7, idx].Value.ToString();
            str = DGW.Rows[idx].Cells["FE_AÑO"].Value.ToString();//DGW[22, idx].Value.ToString();
            str5 = DGW.Rows[idx].Cells["FE_MES"].Value.ToString();//DGW[23, idx].Value.ToString();

            DialogResult rs = MessageBox.Show("¿ ESTA SEGURO DE ELIMINAR EL PRECONTRATO Nº " + str6 + " ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                if (!VERIFICAR_ORDEN_PEDIDO(str4, str2, str3, str6, ref flag2, ref errMensaje))
                {
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (!flag2)
                {
                    MessageBox.Show("EL PRECONTRATO YA FUE INGRESADO, NO SE PUEDE ELIMINAR !!!", "NO SE PUEDE ELIMINAR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else if (TIPO_USU != "MS")
                {
                    DIALOGOS.frmValidarEliminarAnular frm = new DIALOGOS.frmValidarEliminarAnular();
                    frm.Label2.Visible = false;
                    frm.txtObservacion.Visible = false;
                    frm.cargar_usuario("VTA");
                    frm.cboUsuario.Focus();
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        string pass = frm.txtContraseña.Text;
                        string claveEncriptada = HelpersBLL.ENCRIPTAR(pass.ToUpper());
                        string codigo = perBLL.ValidarUsuarioEliminacionAnulacionBLL(claveEncriptada, frm.cboUsuario.Text);
                        int RSLT = perBLL.ValidarDirectorioDesaprobarBLL(codigo, "VTA");
                        if (RSLT > 0)
                        {
                            eliminaPreContrato(str4, str2, str3, str6, str, str5, ref errMensaje);
                            this.Dispose();
                        }
                        else
                            MessageBox.Show("USTED NO TIENE PERMISOS !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    frm.Dispose();
                }
                else
                {
                    eliminaPreContrato(str4, str2, str3, str6, str, str5, ref errMensaje);
                }
                DATAGRID();
                btn_nuevo.Select();
            }
        }
        private void eliminaPreContrato(string str4, string str2, string str3, string str6, string str, string str5, ref string errMensaje)
        {
            pccTo.COD_SUCURSAL = str4;
            pccTo.COD_CLASE = str2;
            pccTo.COD_PER = str3;
            pccTo.NRO_PRESUPUESTO = str6;
            pccTo.FE_AÑO = str;
            pccTo.FE_MES = str5;
            if (!pccBLL.ELIMINAR_PEDIDOBLL(pccTo, ref errMensaje))
            {
                MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("EL PRECONTRATO SE ELIMINO !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        private bool VERIFICAR_ORDEN_PEDIDO(string COD_SUCURSAL3, string COD_CLASE3, string COD_PER3, string NRO_doc3, ref bool flag2, ref string errMensaje)
        {
            bool result = true;
            pccTo.COD_SUCURSAL = COD_SUCURSAL3;
            pccTo.COD_CLASE = COD_CLASE3;
            pccTo.COD_PER = COD_PER3;
            pccTo.NRO_PRESUPUESTO = NRO_doc3;
            pccTo.FE_AÑO = AÑO;
            pccTo.FE_MES = MES;
            if (!pccBLL.VERIFICA_ORDEN_PEDIDOBLL(pccTo, ref flag2, ref errMensaje))
                return result = false;
            return result;
        }

        private void btn_cierre_Click(object sender, EventArgs e)
        {
            if (!validaCierre())
                return;

            string errMensaje = "";
            string str4, str2, str3, str6, str, str5 = "";
            int idx = DGW.CurrentRow.Index;
            str4 = DGW.Rows[idx].Cells["COD_SUCURSAL"].Value.ToString();//DGW[0, idx].Value.ToString();
            str2 = DGW.Rows[idx].Cells["cod_clase"].Value.ToString(); //DGW[2, idx].Value.ToString();
            str3 = DGW.Rows[idx].Cells["cod_per"].Value.ToString();//DGW[4, idx].Value.ToString();
            str6 = DGW.Rows[idx].Cells["Contrato"].Value.ToString();//DGW[7, idx].Value.ToString();
            str = DGW.Rows[idx].Cells["FE_AÑO"].Value.ToString();//DGW[22, idx].Value.ToString();
            str5 = DGW.Rows[idx].Cells["FE_MES"].Value.ToString();//DGW[23, idx].Value.ToString();

            DialogResult rs = MessageBox.Show("¿ Esta seguro de cerrar el Pre-Contrato Nº " + str6 + " ?, YA NO RECIBIRA MAS ARTICULOS", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                pccTo.COD_SUCURSAL = str4;
                pccTo.COD_CLASE = str2;
                pccTo.COD_PER = str3;
                pccTo.NRO_PRESUPUESTO = str6;
                pccTo.FE_AÑO = str;
                pccTo.FE_MES = str5;
                if (!pccBLL.CERRAR_PEDIDOBLL(pccTo, ref errMensaje))
                {
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("EL PRECONTRATO SE CERRO SATISFACTORIAMENTE !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private bool validaCierre()
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
            //if (Convert.ToBoolean(DGW[16, DGW.CurrentRow.Index].Value))
            if (Convert.ToBoolean(DGW.CurrentRow.Cells["Cie"].Value))
            {
                MessageBox.Show("El Pre-Contrato se encuentar totalmente enviado !!!", "NO SE PUEDE MODIFICAR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return result = false;
            }
            return result;
        }

        private void REFRE_Click(object sender, EventArgs e)
        {
            DATAGRID();
        }

        private void BTN_ANULAR_Click(object sender, EventArgs e)
        {
            if (!validaModificarEliminarAnularPrecontrato())
                return;

            string errMensaje = "";
            bool flag2 = false;
            string str4, str2, str3, str6, str, str5 = "";
            int idx = DGW.CurrentRow.Index;
            str4 = DGW.Rows[idx].Cells["COD_SUCURSAL"].Value.ToString();//DGW[0, idx].Value.ToString();
            str2 = DGW.Rows[idx].Cells["cod_clase"].Value.ToString();//DGW[2, idx].Value.ToString();
            str3 = DGW.Rows[idx].Cells["cod_per"].Value.ToString();//DGW[4, idx].Value.ToString();
            str6 = DGW.Rows[idx].Cells["Contrato"].Value.ToString();//DGW[7, idx].Value.ToString();
            str = DGW.Rows[idx].Cells["FE_AÑO"].Value.ToString();//DGW[22, idx].Value.ToString();
            str5 = DGW.Rows[idx].Cells["FE_MES"].Value.ToString();//DGW[23, idx].Value.ToString();
            string tipousu = "";
            string codigo = "";
            string obs = "";
            DialogResult rs = MessageBox.Show("¿ Esta seguro de Anular el Pre-Contrato Nº " + str6 + " ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                if (!VERIFICAR_ORDEN_PEDIDO(str4, str2, str3, str6, ref flag2, ref errMensaje))
                {
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (!flag2)
                {
                    MessageBox.Show("El Pre-Contrato ya ha sido anulado, no se puede volver a anular !!!", "NO SE PUEDE ANULAR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else if (TIPO_USU != "MS")
                {
                    DIALOGOS.frmValidarEliminarAnular frm = new DIALOGOS.frmValidarEliminarAnular();
                    frm.Label2.Visible = true;
                    frm.txtObservacion.Visible = true;
                    frm.txtContraseña.Text = "";
                    frm.txtObservacion.Text = "";
                    frm.cargar_usuario("VTA");
                    frm.cboUsuario.Focus();
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        string pass = frm.txtContraseña.Text;
                        string claveEncriptada = HelpersBLL.ENCRIPTAR(pass.ToUpper());
                        codigo = perBLL.ValidarUsuarioEliminacionAnulacionBLL(claveEncriptada, frm.cboUsuario.Text);
                        tipousu = "1";
                        obs = frm.txtObservacion.Text;

                        int RSLT = perBLL.ValidarDirectorioDesaprobarBLL(codigo, "VTA");
                        if (RSLT > 0)
                        {
                            anularPreContrato(str4, str2, str3, str6, str, str5, tipousu, obs, ref errMensaje);
                            this.Dispose();
                        }
                        else
                            MessageBox.Show("USTED NO TIENE PERMISOS !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    frm.Dispose();
                }
                else
                {
                    tipousu = "0";
                    obs = "";
                    anularPreContrato(str4, str2, str3, str6, str, str5, tipousu, obs, ref errMensaje);
                }
                DATAGRID();
                btn_nuevo.Select();
            }
        }
        private void anularPreContrato(string str4, string str2, string str3, string str6, string str, string str5, string tipousu, string obs, ref string errMensaje)
        {
            pccTo.COD_SUCURSAL = str4;
            pccTo.COD_CLASE = str2;
            pccTo.COD_PER = str3;
            pccTo.NRO_PRESUPUESTO = str6;
            pccTo.FE_AÑO = str;
            pccTo.FE_MES = str5;
            pccTo.TIPO_USU = tipousu;
            pccTo.OBSERVACION = obs;

            if (!pccBLL.ANULAR_PEDIDOBLL(pccTo, ref errMensaje))
                MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show("El Pre-Contrato se anuló !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void txt_numero_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txt_numero.Text = HelpersBLL.OBTIENE_CODIGO(7, txt_numero.Text);
        }

        private void cbo_tipo_planilla_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TabControl2.SelectedTab = TabPage5;
                gb_venta.Focus();
                //CBO_PAGO.Focus();
            }
        }

        private void CBO_PERSONAL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TabControl2.SelectedTab = TabPage4;
                groupBox3.Focus();
            }
        }

        private void cbo_alm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TabControl2.SelectedTab = tabPage7;
                grbPtoVenta.Focus();
            }
        }

        private void btn_obse_Click(object sender, EventArgs e)
        {
            obs2.txt_obs.MaxLength = 800;
            obs2.ShowDialog();
            TabControl2.SelectedTab = TabPage6;
            groupBox4.Focus();
            txtsbas.Focus();
        }

        private void txtsbas_Leave(object sender, EventArgs e)
        {
            txtsbas.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(txtsbas.Text);
            calculo_Neto_Cobrar();
        }

        private void txtsbru_Leave(object sender, EventArgs e)
        {
            txtsbru.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(txtsbru.Text);
            calculo_Neto_Cobrar();
        }

        private void txt_judicial_Leave(object sender, EventArgs e)
        {
            txt_judicial.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(txt_judicial.Text);
            calculo_Neto_Cobrar();
        }

        private void txt_otro_desc_Leave(object sender, EventArgs e)
        {
            txt_otro_desc.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(txt_otro_desc.Text);
            calculo_Neto_Cobrar();
        }

        private void txt_imp_proteccion_Leave(object sender, EventArgs e)
        {
            txt_imp_proteccion.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(txt_imp_proteccion.Text);
            calculo_Neto_Cobrar();
        }
        private void calculo_Neto_Cobrar()
        {
            sneto = txtsbas.Text.Trim() == "" ? 0 : Convert.ToDecimal(txtsbas.Text);
            pres = txtsbru.Text.Trim() == "" ? 0 : Convert.ToDecimal(txtsbru.Text);
            jud = txt_judicial.Text.Trim() == "" ? 0 : Convert.ToDecimal(txt_judicial.Text);
            subtotal = txt_subtotal.Text.Trim() == "" ? 0 : Convert.ToDecimal(txt_subtotal.Text);
            sub_50_total = txt_50_subtotal.Text.Trim() == "" ? 0 : Convert.ToDecimal(txt_50_subtotal.Text);
            otrdesc = txt_otro_desc.Text.Trim() == "" ? 0 : Convert.ToDecimal(txt_otro_desc.Text);
            sub_subtotal = txt_sub_sub_total.Text.Trim() == "" ? 0 : Convert.ToDecimal(txt_sub_sub_total.Text);
            imp_prot = txt_imp_proteccion.Text.Trim() == "" ? 0 : Convert.ToDecimal(txt_imp_proteccion.Text);
            subtotal = sneto - pres - jud;
            txt_subtotal.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(subtotal.ToString());
            sub_50_total = (sneto - pres - jud) / 2;
            txt_50_subtotal.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(sub_50_total.ToString());
            sub_subtotal = ((sneto - pres - jud) / 2) - otrdesc;
            txt_sub_sub_total.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(sub_subtotal.ToString());
            netcob = ((sneto - pres - jud) / 2) - otrdesc - imp_prot;
            txt_neto_cob.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(netcob.ToString());
        }

        private void cboptovta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboptovta.SelectedValue != null)
            {
                //////ESTO ERA CUANDO HABIA GRUPO DE VENTA  
                //puntoVentaBLL ptvBLL = new puntoVentaBLL();
                //puntoVentaTo ptvTo = new puntoVentaTo();
                //ptvTo.COD_PTO_VEN = cboptovta.SelectedValue.ToString();
                //DataTable dt = ptvBLL.obtenerPuntoVentaConsolidadoBLL(ptvTo);
                //if (dt.Rows.Count > 0)
                //    lblptovtacons.Text = dt.Rows[0][0].ToString();
                //else
                //    lblptovtacons.Text = "";
                //
                llenaLugarVenta();
                DataRow[] rs = dtPtoVta.Select("COD_INSTITUCION='" + COD_INSTITUCION1 + "' AND COD_PTO_VEN='" + cboptovta.SelectedValue.ToString() + "'");
                foreach (DataRow r in rs)
                {
                    //cbocandesc.SelectedValue = r["COD_CANAL_DSCTO"].ToString();//esto se comentó porque no se quiere que este amarrado con el pto de cobranza
                    cboptocob.SelectedValue = r["COD_PTO_COB"].ToString();
                }
            }
        }
        private void llenaLugarVenta()
        {
            if (COD_INSTITUCION1 != null)
            {
                lgvTo.COD_INSTITUCION = COD_INSTITUCION1;
                lgvTo.COD_PTO_VTA = cboptovta.SelectedValue.ToString();
                dtLugVta = null;
                dtLugVta = lgvBLL.obtenerLugarVentaCodInsCodPtoVtaBLL(lgvTo);
                if (dtLugVta.Rows.Count > 0)
                {
                    cbo_lug_vta.ValueMember = "COD_LUG_VTA";
                    cbo_lug_vta.DisplayMember = "DESC_LUG_VTA";
                    cbo_lug_vta.DataSource = dtLugVta;
                    cbo_lug_vta.SelectedIndex = -1;

                    cbo_lug_vta.AutoCompleteCustomSource = AutoCompleClass.AutoComplete(dtLugVta);
                    cbo_lug_vta.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    cbo_lug_vta.AutoCompleteSource = AutoCompleteSource.CustomSource;
                }
                else
                {
                    cbo_lug_vta.ValueMember = "COD_LUG_VTA";
                    cbo_lug_vta.DisplayMember = "DESC_LUG_VTA";
                    cbo_lug_vta.DataSource = null;
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

        private void cbo_modalidad_venta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_modalidad_venta.SelectedValue != null)
            {
                mvTo.COD_MODALIDAD_VTA = cbo_modalidad_venta.SelectedValue.ToString();
                DataTable dt = mvBLL.obtenerTipoVentaporCodBLL(mvTo);
                if (dt.Rows.Count > 0)
                {
                    cbo_tipo_venta.ValueMember = "COD_TIPO_VENTA";
                    cbo_tipo_venta.DisplayMember = "DESC_TIPO_VENTA";
                    cbo_tipo_venta.DataSource = dt;
                    cbo_tipo_venta.SelectedIndex = 0;
                }
                else
                {
                    cbo_tipo_venta.DataSource = null;
                    var tipo = new[] { new { cod = "00", val = " " } };
                    cbo_tipo_venta.ValueMember = "cod";
                    cbo_tipo_venta.DisplayMember = "val";
                    cbo_tipo_venta.DataSource = tipo;
                    cbo_tipo_venta.SelectedIndex = 0;
                }
            }
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
                COD_CLASE1 = CBO_CLASE.SelectedValue.ToString();
                DIALOGOS.CONSULTA_SALDO_X_ARTICULO frm = new DIALOGOS.CONSULTA_SALDO_X_ARTICULO(COD_CLASE1, TXT_COD_PRO.Text, TXT_DESC_PRO.Text, TIPO_USU, COD_USU);
                frm.ShowDialog();
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

        private void cbo_lug_vta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TabControl2.SelectedTab = TabPage6;
                groupBox4.Focus();//Evaluacion de Contrato
                //TabControl2.SelectedTab = TabPage10;
                //groupBox2.Focus();//Cobranza
            }
        }

        private void btn_Aprobar_Click(object sender, EventArgs e)
        {
            DIALOGOS.DESAPROBADO_POR fdp = new DIALOGOS.DESAPROBADO_POR();
            fdp.cboUsuario.Items.Clear();
            fdp.cargar_usuario("VTA");
            if (fdp.ShowDialog() == DialogResult.OK)
                cbo_alm.Enabled = true;
            else
                cbo_alm.Enabled = false;
        }

        private void DTP_DOC_ValueChanged(object sender, EventArgs e)
        {
            TXT_TC.Text = obtener_tipo_cambio();
        }
        private string obtener_tipo_cambio()
        {
            string tc = helBLL.obtenerTipoCambioBLL(DTP_DOC.Value.Year.ToString(), HelpersBLL.OBTIENE_CODIGO(2, DTP_DOC.Value.Month.ToString()),
            HelpersBLL.OBTIENE_CODIGO(2, DTP_DOC.Value.Day.ToString()), "D");
            return tc;
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            CARGAR_PERSONAS();
        }

        private void txt_oc_Leave(object sender, EventArgs e)
        {
            txt_oc.Text = HelpersBLL.OBTIENE_CODIGO(6, txt_oc.Text);
        }

        private void chk_fec_contrato_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_fec_contrato.Checked)
            {
                DTP_DOC.Enabled = true;
                DTP_DOC.Focus();
            }
            else
                DTP_DOC.Enabled = false;
        }

        private void chk_fec_reporte_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_fec_reporte.Checked)
            {
                dtp_oc.Enabled = true;
                dtp_oc.Focus();
                dtp_oc_ValueChanged(sender, e);
            }
            else
                dtp_oc.Enabled = false;
        }

        private void dtp_oc_ValueChanged(object sender, EventArgs e)
        {
            if (chk_fec_reporte.Checked)
                llenaCbo_Semana_Contrato();
        }

        private void txt_desc2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_desc2.Text == "")
                {
                    //cbo_alm.Focus();
                    cboptovta.Focus();
                }
                else
                {
                    if (dgw_per2.Rows.Count > 0)
                    {
                        dgw_per2.Sort(dgw_per2.Columns[1], System.ComponentModel.ListSortDirection.Ascending);
                        int i = 0, num2 = 0;
                        num2 = dgw_per2.Rows.Count;
                        do
                        {
                            if (dgw_per2[1, i].Value.ToString().Length >= txt_desc2.TextLength)
                            {
                                if (txt_desc2.Text.ToLower() == dgw_per2[1, i].Value.ToString().ToLower().Substring(0, txt_desc2.TextLength).ToLower())
                                {
                                    dgw_per2.CurrentCell = dgw_per2.Rows[i].Cells[0];
                                    break;
                                }
                            }
                            dgw_per2.CurrentCell = dgw_per2.Rows[0].Cells[0];
                            i += 1;
                        }
                        while (i < num2);
                        panel_per2.Visible = true;
                        dgw_per2.Visible = true;
                        dgw_per2.Focus();
                    }
                }
            }
            else if (e.KeyCode == Keys.Right)
            {
                TabControl2.SelectedTab = tabPage7;
                cbocandesc.Focus();
            }
        }

        private void txt_neto_cob_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (sneto > 0)
                {
                    if ((netcob / sneto) * 100 < eval_cont)
                    {
                        MessageBox.Show("El neto a cobrar es menor que el " + eval_cont.ToString() + " % ", "ADVERETENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                TabControl2.SelectedTab = TabPage3;
                btn_nuevo2.Focus();
            }
        }

        private void TXT_DSCTO_Leave(object sender, EventArgs e)
        {
            TXT_DSCTO.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(TXT_DSCTO.Text);
            HALLAR_VALOR_VENTA();
        }

        private void ch_dscto_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_dscto.Checked)
                STATUS_DSCTO = "1";
            else
                STATUS_DSCTO = "0";
            HALLAR_VALOR_VENTA();
        }

        private void btn_AprBlq_Click(object sender, EventArgs e)
        {
            DIALOGOS.APROBADO_POR_BLOQUE frm = new DIALOGOS.APROBADO_POR_BLOQUE(DGW, "PreContrato", COD_USU, MES, AÑO);
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                if (frm.lbl_nro_contrato.Text != "")
                {
                    FOCO_NUEVO_REG(frm.lbl_nro_contrato.Text);
                    btn_modificar_Click(sender, e);
                    button4_Click(sender, e);
                    dtp_vcto.Focus();
                }
            }
            else
                DATAGRID();
        }

        private void btn_c_calidad_Click(object sender, EventArgs e)
        {
            MOD_FACT_VTA.MOD_VTA.Reportes.FormRep.REPORTE_CONTROL_CALIDAD frm = new MOD_FACT_VTA.MOD_VTA.Reportes.FormRep.REPORTE_CONTROL_CALIDAD(MES, AÑO, FECHA_GRAL);
            frm.Show();
        }

        private void btn_refresh_semana_Click(object sender, EventArgs e)
        {
            if (chk_fec_reporte.Checked)
                llenaCbo_Semana_Contrato();
        }

        private void txt_letra_TextChanged(object sender, EventArgs e)
        {
            int i;
            if (ch_cod.Checked)
            {
                txt_letra.Focus();
                for (i = 0; i < DGW.Rows.Count; i++)
                {
                    if (txt_letra.TextLength <= DGW.Rows[i].Cells["Contrato"].Value.ToString().Length)
                    {
                        if (txt_letra.Text.ToLower() == DGW.Rows[i].Cells["Contrato"].Value.ToString().Substring(0, txt_letra.TextLength).ToLower())
                        {
                            DGW.CurrentCell = DGW.Rows[i].Cells["Contrato"];
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
                DGW.Sort(DGW.Columns["Contrato"], System.ComponentModel.ListSortDirection.Ascending);
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
