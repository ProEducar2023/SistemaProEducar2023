using BLL;
using Entidades;
using FacturacionElectronica;
using FacturacionElectronica.intercambio;
using FacturacionElectronica.modelos;
using FacturacionElectronica.service.implement;
using FacturacionElectronica.service.interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Windows.Forms;

namespace Presentacion.MOD_FACT_VTA
{
    public partial class FACTURACION_SERVICIOS : Form
    {
        string AÑO = "", MES = "", COD_MOD = "", COD_USU = "", TIPO_USU = "";
        DateTime FECHA_INI, FECHA_GRAL;
        string LETRA, COD_DH;
        string STATUS_DSCTO = "0", STATUS_IGV = "1";
        string boton;
        decimal ValorDetraccion, PorDetraccion;
        decimal igv0 = 0;
        bool EstadoFacturaElectronica;
        string CodigoMotivoFacturacionIgv = "";
        string NOMBRE_PC = System.Environment.MachineName;
        DataTable dtCondVenta = null;
        DataTable DT00 = new DataTable();
        DIALOGOS.Dialog3 obs = new DIALOGOS.Dialog3();
        facturacionVtaCabeceraBLL fvtaBLL = new facturacionVtaCabeceraBLL();
        facturacionVtaCabeceraTo fvtaTo = new facturacionVtaCabeceraTo();
        facturacionVtaDetalleBLL dfvtaBLL = new facturacionVtaDetalleBLL();
        facturacionVtaDetalleTo dfvtaTo = new facturacionVtaDetalleTo();
        HelpersBLL helBLL = new HelpersBLL();
        HelpersTo helTo = new HelpersTo();
        serieDocumentoBLL sdcBLL = new serieDocumentoBLL();
        serieDocumentosTo sdcTo = new serieDocumentosTo();
        articuloClaseBLL arcBLL = new articuloClaseBLL();
        articuloClaseTo arcTo = new articuloClaseTo();
        tipoCambioBLL tcpBLL = new tipoCambioBLL();
        tipoCambioTo tcpTo = new tipoCambioTo();
        personaBLL perBLL = new personaBLL();
        DIALOGOS.frmDetraccion formDetraccion = new DIALOGOS.frmDetraccion();
        int INDICE;
        public FACTURACION_SERVICIOS(string AÑO, string MES, DateTime FECHA_INI, DateTime FECHA_GRAL, string COD_MOD, string TIPO_USU, string COD_USU)
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
        private void FACTURACION_SERVICIOS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }
        struct AfectacionIgv
        {
            public string Codigo { get; set; }
            public string Descripcion { get; set; }
        }
        private void FACTURACION_SERVICIOS_Load(object sender, EventArgs e)
        {
            CargarCombo();
            //cboTipoOperacionFacturaElectronica.SelectedIndex = 0;
            cboCodigoPrecioVenta.SelectedIndex = 0;
            cboTipoAfectaciónIgv.SelectedIndex = 0;
            KeyPreview = true;
            DATAGRID();
            //CARGAR_PROYECTO();
            //CARGAR_CC();
            CARGAR_CLASE();
            CARGAR_SUCURSAL();
            CARGAR_VENDEDOR();
            CARGAR_PERSONAS();
            CARGAR_MOVIMIENTO();
            CARGAR_FORMAS_PAGO();
            CARGAR_COND_VENTA();
            CARGAR_CODIGO_PRECIO_VENTA();
            DOCUMENTOS();
            CARGAR_MONEDA();
            CARGAR_PERSONAS_PERSONAL();
            EstadoFacturaElectronica = true;
            chkStatusFacturaElectronica.Checked = true;
            igv0 = helBLL.obtenerImpuestoBLL("IGV");
            TXT_IGV.Text = igv0.ToString();
            TXT_IGV2.Text = TXT_IGV.Text;
            //TXT_TC.Text = helBLL.obtenerTipoCambioBLL(DTP_DOC.Value.Year.ToString(), HelpersBLL.OBTIENE_CODIGO(2, DTP_DOC.Value.Month.ToString()),
            //HelpersBLL.OBTIENE_CODIGO(2, DTP_DOC.Value.Day.ToString()), "D");
            //DTP_DOC.Value = Convert.ToDateTime(DateTime.Now.Day + "/" + FECHA_INI.Month + "/" + FECHA_INI.Year);
            DTP_DOC.Value = HelpersBLL.validaFecha(MES, AÑO, FECHA_GRAL);
            cargarTipoOperacionFacturaElectronica();
            //
            DT00.Columns.Add("COD_SUCURSAL");
            DT00.Columns.Add("COD_CLASE");
            DT00.Columns.Add("COD_DOC");
            DT00.Columns.Add("NRO_DOC");
            DT00.Columns.Add("COD_PER");
            DT00.Columns.Add("FE_AÑO");
            DT00.Columns.Add("FE_MES");
            DT00.Columns.Add("ITEM");
            DT00.Columns.Add("COD_DOC_GUIA");
            DT00.Columns.Add("NRO_DOC_GUIA");
            DT00.Columns.Add("NRO_PEDIDO");
            DT00.Columns.Add("COD_ARTICULO");
            DT00.Columns.Add("CANTIDAD");
            DT00.Columns.Add("COD_D_H");
            DT00.Columns.Add("COD_MONEDA");
            DT00.Columns.Add("PRECIO_UNITARIO");
            DT00.Columns.Add("VALOR_COMPRA");
            DT00.Columns.Add("POR_IGV");
            DT00.Columns.Add("POR_DSCTO");
            DT00.Columns.Add("STATUS_IGV");
            DT00.Columns.Add("VALOR_IGV");
            DT00.Columns.Add("VALOR_DSCTO");
            DT00.Columns.Add("AJUSTE_IGV");
            DT00.Columns.Add("AJUSTE_BI");
            DT00.Columns.Add("NRO_ITEM");
            DT00.Columns.Add("OBSERVACION");
            DT00.Columns.Add("NOMBRE_PC");
            DT00.Columns.Add("NRO_SALIDA");
            DT00.Columns.Add("TIPO_PRECIO");
            DT00.Columns.Add("NRO_INGRESO");
            DT00.Columns.Add("VALOR_REFERENCIAL");
            DT00.Columns.Add("VALOR_IGV_REF");
            DT00.Columns.Add("COD_PRECIO_VTA_FE");
            DT00.Columns.Add("COD_TIPO_AFEC_IGV_FE");
            DT00.Columns.Add("DESC_ARTICULO");
            btn_nuevo.Select();

        }
        private void CARGAR_MONEDA()
        {
            DataTable dt = helBLL.obtenerMonedaBLL();
            CBO_MONEDA.ValueMember = "COD_MONEDA";
            CBO_MONEDA.DisplayMember = "desc_moneda";
            CBO_MONEDA.DataSource = dt;
            CBO_MONEDA.SelectedItem = -1;

            DataTable dt1 = helBLL.obtenerMonedaBLL();
            CBO_MONEDA_REF.ValueMember = "COD_MONEDA";
            CBO_MONEDA_REF.DisplayMember = "desc_moneda";
            CBO_MONEDA_REF.DataSource = dt;
            CBO_MONEDA_REF.SelectedItem = -1;
        }
        private void DOCUMENTOS()
        {
            DataTable dt = helBLL.obtenerDesc_Doc_GestionBLL();
            cbo_tipo_doc.ValueMember = "COD_DOC";
            cbo_tipo_doc.DisplayMember = "DESC_DOC";
            cbo_tipo_doc.DataSource = dt;
            cbo_tipo_doc.SelectedIndex = -1;
            //
            DataTable dt1 = helBLL.obtenerDesc_Doc_GestionBLL();//para nota de credito y debito
            CBO_DOC.ValueMember = "COD_DOC";
            CBO_DOC.DisplayMember = "DESC_DOC";
            CBO_DOC.DataSource = dt1;
            CBO_DOC.SelectedIndex = -1;
        }
        private void CARGAR_CODIGO_PRECIO_VENTA()
        {
            var cboCodigoPrecioVta = new[] { new { cod = "01", val = "PRECIO UNITARIO" }, new { cod = "02", val = "VALOR REFERENCIAL" } };
            cboCodigoPrecioVenta.ValueMember = "cod";
            cboCodigoPrecioVenta.DisplayMember = "val";
            cboCodigoPrecioVenta.DataSource = cboCodigoPrecioVta;
            cboCodigoPrecioVenta.SelectedIndex = 0;
        }
        private void cargarTipoOperacionFacturaElectronica()
        {
            var cboTipoOperacionFE = new[] { new { cod = "01", val = "VENTAS INTERNAS" }, new { cod = "02", val = "VENTAS EXPORTACIONES" },
                                            new { cod = "03", val = "NO DOMICILIADOS" }, new { cod = "04", val = "VENTA INTERNA - ANTICIPO" },
                                            new { cod = "05", val = "VENTA ITINERANTE" }};
            cboTipoOperacionFacturaElectronica.ValueMember = "cod";
            cboTipoOperacionFacturaElectronica.DisplayMember = "val";
            cboTipoOperacionFacturaElectronica.DataSource = cboTipoOperacionFE;
            cboTipoOperacionFacturaElectronica.SelectedIndex = 0;
        }
        private void CARGAR_COND_VENTA()
        {
            dtCondVenta = helBLL.obtenerCondicionVentaBLL();
            cbo_VENTA.ValueMember = "COD_TIPO";
            cbo_VENTA.DisplayMember = "DESC_TIPO";
            cbo_VENTA.DataSource = dtCondVenta;
            cbo_VENTA.SelectedIndex = -1;
        }
        private void CARGAR_FORMAS_PAGO()
        {
            DataTable dt = helBLL.obtenerFormaPagoBLL();
            CBO_PAGO.ValueMember = "COD_TIPO";
            CBO_PAGO.DisplayMember = "DESC_TIPO";
            CBO_PAGO.DataSource = dt;
            CBO_PAGO.SelectedIndex = -1;
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
        private void CARGAR_MOVIMIENTO()
        {
            movimientosBLL movBLL = new movimientosBLL();
            DataTable dt = movBLL.obtenerMovimientosparaPedidoBLL();
            cbo_movimiento.ValueMember = "COD_MOV";
            cbo_movimiento.DisplayMember = "DESC_MOV";
            cbo_movimiento.DataSource = dt;
            cbo_movimiento.SelectedIndex = -1;
        }
        private void CARGAR_PERSONAS()
        {
            helTo.CODIGO = "04";//VENDEDORES
            DataTable dt = helBLL.MOSTRAR_PERSONAS_XCOBRAR_BLL(helTo);
            if (dt.Rows.Count > 0)
            {
                dgw_per.DataSource = dt;
                dgw_per.Columns[0].Width = 50;
                dgw_per.Columns[1].Width = 200;
                dgw_per.Columns[2].Width = 80;
                dgw_per.Columns[3].Visible = false;
                dgw_per.Columns[4].Visible = false;
                dgw_per.Columns[5].Width = 100;
            }
            else
                dgw_per.DataSource = null;
        }
        private void CARGAR_VENDEDOR()
        {
            progNivelBLL prnBLL = new progNivelBLL();
            DataTable dt = prnBLL.obtenerVendedoresparaCrearEqVentasBLL();
            if (dt.Rows.Count > 0)
            {
                dgw_per2.DataSource = dt;
                dgw_per2.Columns[0].Width = 55;
                dgw_per2.Columns[1].Width = 200;
                dgw_per2.Columns[2].Visible = false;
                dgw_per2.Columns[3].Width = 100;
            }
            else
                dgw_per2.DataSource = null;
        }
        private void CARGAR_SUCURSAL()
        {
            helTo.CODIGO = COD_USU;
            DataTable dt = helBLL.CBO_SUCURSALBLL(helTo);
            CBO_SUCURSAL.ValueMember = "COD_SUCURSAL";
            CBO_SUCURSAL.DisplayMember = "DESC_sucursal";
            CBO_SUCURSAL.DataSource = dt;
            CBO_SUCURSAL.SelectedIndex = -1;
        }
        private void CARGAR_CLASE()
        {
            bool validarTipo = true;
            string tipo = "S";
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
            CBO_CLASE.SelectedIndex = -1;
        }
        private void CargarCombo()
        {
            List<AfectacionIgv> Lista = new List<AfectacionIgv>();
            Lista.Add(new AfectacionIgv() { Codigo = "10", Descripcion = "GRAVADO-OPERACIONES ONEROSA" });
            Lista.Add(new AfectacionIgv() { Codigo = "11", Descripcion = "GRAVADO-RETIRO POR PREMIO" });
            Lista.Add(new AfectacionIgv() { Codigo = "12", Descripcion = "GRAVADO-RETIRO POR DONACION" });
            Lista.Add(new AfectacionIgv() { Codigo = "13", Descripcion = "GRAVADO-RETIRO" });
            Lista.Add(new AfectacionIgv() { Codigo = "14", Descripcion = "GRAVADO-RETIRO POR PUBLICIDAD" });
            Lista.Add(new AfectacionIgv() { Codigo = "15", Descripcion = "GRAVADO-BONIFICACIONES" });
            Lista.Add(new AfectacionIgv() { Codigo = "16", Descripcion = "GRAVADO-RETIRO POR ENTREGA A TRABAJADORES" });
            Lista.Add(new AfectacionIgv() { Codigo = "20", Descripcion = "EXONERADO-OPERACION ONEROSA" });
            Lista.Add(new AfectacionIgv() { Codigo = "21", Descripcion = "EXONERADO-TRANSFERENCIA GRATUITA" });
            Lista.Add(new AfectacionIgv() { Codigo = "30", Descripcion = "INAFECTO-OPERACION ONEROSA" });
            Lista.Add(new AfectacionIgv() { Codigo = "31", Descripcion = "INAFECTO-RETIRO POR BONIFICACION  " });
            Lista.Add(new AfectacionIgv() { Codigo = "32", Descripcion = "INAFECTO-RETIRO" });
            Lista.Add(new AfectacionIgv() { Codigo = "33", Descripcion = "INAFECTO-RETIRO POR MUESTRAS MEDICAS" });
            Lista.Add(new AfectacionIgv() { Codigo = "34", Descripcion = "INAFECTO-RETIRO POR CONVENIO COLECTIVO" });
            Lista.Add(new AfectacionIgv() { Codigo = "35", Descripcion = "INAFECTO-RETIRO POR PREMIO" });
            Lista.Add(new AfectacionIgv() { Codigo = "36", Descripcion = "INAFECTO-RETIRO POR PUBLICIDAD" });
            Lista.Add(new AfectacionIgv() { Codigo = "40", Descripcion = "EXPORTACION" });

            cboTipoAfectaciónIgv.ValueMember = "Codigo";
            cboTipoAfectaciónIgv.DisplayMember = "Descripcion";
            cboTipoAfectaciónIgv.DataSource = Lista;
            cboTipoAfectaciónIgv.SelectedIndex = -1;
        }
        private void DATAGRID()
        {
            fvtaTo.FE_AÑO = AÑO;
            fvtaTo.FE_MES = MES;
            fvtaTo.COD_USU = COD_USU;
            fvtaTo.TIPO_USU = TIPO_USU;
            DataTable dt = fvtaBLL.MOSTRAR_IFACT_VTA_SER_BLL(fvtaTo);
            if (dt.Rows.Count > 0)
            {
                DGW.DataSource = dt;
                DGW.Columns["COD_SUCURSAL"].Visible = false;
                DGW.Columns["DESC_SUCURSAL"].HeaderText = "Sucursal";
                DGW.Columns["DESC_SUCURSAL"].Width = 110;
                DGW.Columns["COD_CLASE"].Visible = false;
                DGW.Columns["DESC_CLASE"].HeaderText = "Clase";
                DGW.Columns["DESC_CLASE"].Width = 120;
                DGW.Columns["COD_DOC"].Visible = false;
                DGW.Columns["desc_doc"].HeaderText = "Documento";
                DGW.Columns["desc_doc"].Width = 100;
                DGW.Columns["NRO_DOC"].HeaderText = "Nro Docu";
                DGW.Columns["NRO_DOC"].Width = 80;
                DGW.Columns["COD_PER"].Visible = false;
                DGW.Columns["DESC_PER"].HeaderText = "Cliente";
                DGW.Columns["DESC_PER"].Width = 170;
                DGW.Columns["DNI"].Visible = false;
                DGW.Columns["FECHA_DOC"].HeaderText = "Fec Fact";
                DGW.Columns["FECHA_DOC"].Width = 70;
                DGW.Columns["FECHA_DOC"].DefaultCellStyle.Format = "d";
                DGW.Columns["COD_MONEDA"].Visible = false;
                DGW.Columns["TIPO_CAMBIO"].Visible = false;
                DGW.Columns["OBSERVACION"].Visible = false;
                DGW.Columns["STATUS_PV"].Visible = false;
                DGW.Columns["COD_VENDEDOR"].Visible = false;
                DGW.Columns["Anul."].Width = 40;
                DGW.Columns["Coi."].Visible = false;
                DGW.Columns["COD_REF"].Visible = false;
                DGW.Columns["NRO_REF"].Visible = false;
                DGW.Columns["FECHA_REF"].Visible = false;
                DGW.Columns["STATUS_FE"].Visible = false;
                DGW.Columns["TIPO_OPERACION_FE"].Visible = false;
                DGW.Columns["VALOR_DETRACCION"].Visible = false;
                DGW.Columns["POR_DETRACCION"].Visible = false;
                DGW.Columns["NRO_GUIA"].Visible = false;
                DGW.Columns["NOM_VENDEDOR"].Visible = false;
                DGW.Columns["COD_MOT_DEV"].Visible = false;
                DGW.Columns["FORMA_PAGO"].Visible = false;
                DGW.Columns["NRO_DIAS"].Visible = false;
                DGW.Columns["CONDICION_VENTA"].Visible = false;
                DGW.Columns["FECHA_VEN"].Visible = false;
                DGW.Columns["COD_MOV"].Visible = false;
                DGW.Columns["FE_AÑO"].Visible = false;
                DGW.Columns["FE_MES"].Visible = false;
            }
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            boton = "NUEVO";
            btn_grabar.Visible = true;
            btn_grabar.Enabled = true;
            btn_imprimir.Enabled = false;
            Panel1.Visible = true;
            Panel2.Visible = false;
            Panel0.Enabled = true;
            btn_mod.Visible = true;
            //cbo_ni.Visible = true;
            //TXT_NI.Visible = false;
            //'btn_Caja.Enabled = False

            //**********************************************
            //DATOS DE LA FACTURACION
            //**********************************************
            CBO_DOC.Enabled = true;
            btn_oc.Enabled = true;
            TXT_OBS_NOTA.Enabled = true;

            LIMPIAR_CABECERA();
            TabControl1.SelectedTab = (TabPage2);
            //SGT_ORDEN();
            valoresIniciales();
            CBO_SUCURSAL.Select();
        }
        public string HALLAR_NRO_DOC(string serie, string cod_doc)
        {
            string num = "";
            sdcTo.COD_SUCURSAL = CBO_SUCURSAL.SelectedValue.ToString();
            sdcTo.SERIE = serie;
            sdcTo.COD_DOC = cbo_tipo_doc.SelectedValue.ToString();
            return num = sdcBLL.obtenerNumeroSerieDocumentoparaFacturacionBLL(sdcTo).ToString();
        }
        private void LIMPIAR_CABECERA()
        {
            TabControl2.SelectedTab = (TabPage01);
            txt_nro_doc.Visible = false;
            CBO_NI2.Visible = true;
            TXT_NUMERO2.Visible = true;
            txt_nro_doc.Clear();
            //CBO_SUCURSAL.SelectedIndex = -1;
            if (cbo_tipo_doc.SelectedIndex != -1)
            {
                if (CBO_SUCURSAL.SelectedValue != null)
                {
                    if (CBO_NI2.SelectedIndex != -1)
                    {
                        TXT_NUMERO2.Text = HALLAR_NRO_DOC(CBO_NI2.Text, cbo_tipo_doc.SelectedValue.ToString());
                        txt_nro_doc.Text = LETRA + (CBO_NI2.Text + "-" + TXT_NUMERO2.Text);
                    }
                    else
                    {
                        string str3 = cbo_tipo_doc.Text;
                        cbo_tipo_doc.SelectedIndex = -1;
                        cbo_tipo_doc.Text = str3;
                    }
                }
            }
            ch_obs.Checked = false;
            TXT_COD.Clear();
            txt_cod2.Clear();
            TXT_DIA1.Clear();
            TXT_DIA1.Text = "0";
            TXT_DESC.Clear();
            txt_desc2.Clear();
            txt_doc_per.Clear();
            gb_cab0.Enabled = true;
            gb_oc.Enabled = true;
            btn_ajuste.Enabled = true;
            dgw_det.Rows.Clear();
            LBL_DOC.Text = ".";
            TXT_TB.Text = "0.00";
            TXT_TD.Text = "0.00";
            TXT_TN.Text = "0.00";
            TXT_TT.Text = "0.00";
            //-------------------------
            btnDetraccion.Enabled = true;
            //-------------------------
            TXT_TIGV.Text = "0.00";
            //-------------------------
            TXT_NRO_FACT.Clear();
            TXT_TC_REF.Clear();
            TXT_OBS_NOTA.Clear();
            CBO_MONEDA_REF.SelectedIndex = -1;
            CBO_DOC.SelectedIndex = -1;
            //STATUS_A = "0";
            //COD_MONEDA = obj.DIR_TABLA_DESC("MONCXC", "TDEFA");
            //string str = obj.DIR_TABLA_DESC("PVCXC", "TDEFA");
            btn_grabar.Visible = true;
            BTN_GRABAR2.Visible = false;
            btn_grabar.Enabled = true;
            BTN_GRABAR2.Enabled = true;

            //if(!string.IsNullOrEmpty(NombreCompletoUsuario))
            //{
            //    CBO_PERSONAL.Text = NombreCompletoUsuario;
            //    CBO_PERSONAL.Enabled = false;
            //}
            ValorDetraccion = 0;
            if (EstadoFacturaElectronica)
                chkStatusFacturaElectronica.Checked = true;
            else
                chkStatusFacturaElectronica.Checked = false;

            ValorDetraccion = 0; PorDetraccion = 0;
            btnDetraccion.Enabled = true;
            txtValorDetraccion.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(ValorDetraccion.ToString());
            txtPorcentajeDetraccion.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(PorDetraccion.ToString());
            //txtNumeroGuia.Clear();
            //txtNota.Clear();
        }

        private void CBO_NI2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBO_NI2.SelectedValue != null)
            {
                if (CBO_SUCURSAL.SelectedValue != null)
                {
                    if (CBO_NI2.SelectedIndex > -1)
                    {
                        TXT_NUMERO2.Text = HALLAR_NRO_DOC(CBO_NI2.Text, cbo_tipo_doc.SelectedValue.ToString());

                        if (chkStatusFacturaElectronica.Checked)
                            txt_nro_doc.Text = LETRA + CBO_NI2.Text + "-" + TXT_NUMERO2.Text;
                        else
                            txt_nro_doc.Text = CBO_NI2.Text + "-" + TXT_NUMERO2.Text;
                    }
                }
            }
        }

        private void CBO_CLASE_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBO_CLASE.SelectedValue != null)
            {
                CARGAR_PRODUCTOS();
            }
        }
        private void CARGAR_PRODUCTOS()
        {
            arcTo.COD_CLASE = CBO_CLASE.SelectedValue.ToString();
            DataTable dt = arcBLL.obtenerArticuloClaseparaInventarioBLL(arcTo);
            if (dt.Rows.Count > 0)
            {
                DGW_PRO.DataSource = dt;
                DGW_PRO.Columns[3].Visible = false;
                DGW_PRO.Columns[4].Visible = false;
                DGW_PRO.Columns[0].Width = 80;
            }
        }

        private void cbo_tipo_doc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_tipo_doc.SelectedValue != null)
            {
                if (cbo_tipo_doc.SelectedIndex != -1)
                {
                    CBO_NI2.Enabled = true;
                    //COD_DOC = cbo_tipo_doc.SelectedValue.ToString();
                    COD_DH = helBLL.COD_D_H(cbo_tipo_doc.SelectedValue.ToString());
                    CARGAR_NRO_DOC(cbo_tipo_doc.SelectedValue.ToString());
                    ValidaTagPage();
                    if (chkStatusFacturaElectronica.Checked)
                    {
                        if (cbo_tipo_doc.Text.Trim() == "FACTURA")
                        {
                            LETRA = "F";
                            CodigoMotivoFacturacionIgv = "";
                        }
                        else if (cbo_tipo_doc.Text.Trim() == "BOLETA DE VENTA")
                        {
                            LETRA = "B";
                            CodigoMotivoFacturacionIgv = "";
                        }
                        else if (cbo_tipo_doc.Text.Trim() == "NOTA DE CREDITO")
                            CargarComboMotivoNotaCredito();
                        else if (cbo_tipo_doc.Text.Trim() == "NOTA DE DEBITO")
                            CargarComboMotivoNotaDebito();
                        else
                        {
                            LETRA = "";
                            CodigoMotivoFacturacionIgv = "";
                        }
                    }
                    else
                    {
                        LETRA = "";
                        CodigoMotivoFacturacionIgv = "";
                    }
                }
                if (chkStatusFacturaElectronica.Checked)
                    txt_nro_doc.Text = LETRA + CBO_NI2.Text + "-" + TXT_NUMERO2.Text.PadLeft(7, '0');
                else
                    txt_nro_doc.Text = (CBO_NI2.Text + "-" + TXT_NUMERO2.Text.PadLeft(7, '0'));
            }

        }
        struct MotivoNotaCredito
        {
            public string Codigo { get; set; }
            public string Descripcion { get; set; }
        }
        private void CargarComboMotivoNotaCredito()
        {
            List<MotivoNotaCredito> Lista = new List<MotivoNotaCredito>();
            Lista.Add(new MotivoNotaCredito() { Codigo = "01", Descripcion = "ANULACIÓN DE LA OPERACIÓN" });
            Lista.Add(new MotivoNotaCredito() { Codigo = "02", Descripcion = "ANULACIÓN POR ERROR EN EL RUC" });
            Lista.Add(new MotivoNotaCredito() { Codigo = "03", Descripcion = "CORRECIÓN POR ERROR EN LA DESCRIPCIÓN" });
            Lista.Add(new MotivoNotaCredito() { Codigo = "04", Descripcion = "DESCUENTO GLOBAL" });
            Lista.Add(new MotivoNotaCredito() { Codigo = "05", Descripcion = "DESCUENTO POR ITEM" });
            Lista.Add(new MotivoNotaCredito() { Codigo = "06", Descripcion = "DEVOLUCIÓN TOTAL" });
            Lista.Add(new MotivoNotaCredito() { Codigo = "07", Descripcion = "DEVOLUCIÓN POR ITEM" });
            Lista.Add(new MotivoNotaCredito() { Codigo = "08", Descripcion = "BONIFICACIÓN" });
            Lista.Add(new MotivoNotaCredito() { Codigo = "09", Descripcion = "DISMINUCIÓN EN EL VALOR" });
            cboMotivoFacturaElectronica.ValueMember = "Codigo";
            cboMotivoFacturaElectronica.DisplayMember = "Descripcion";
            cboMotivoFacturaElectronica.DataSource = Lista;
            cboMotivoFacturaElectronica.SelectedIndex = -1;
        }
        struct MotivoNotaDebito
        {
            public string Codigo { get; set; }
            public string Descripcion { get; set; }
        }
        private void CargarComboMotivoNotaDebito()
        {
            List<MotivoNotaDebito> Lista = new List<MotivoNotaDebito>();
            Lista.Add(new MotivoNotaDebito() { Codigo = "01", Descripcion = "INTERESES POR MORA" });
            Lista.Add(new MotivoNotaDebito() { Codigo = "02", Descripcion = "AUMENTO EN EL VALOR " });
            Lista.Add(new MotivoNotaDebito() { Codigo = "03", Descripcion = "PENALIDADES" });
            cboMotivoFacturaElectronica.ValueMember = "Codigo";
            cboMotivoFacturaElectronica.DisplayMember = "Descripcion";
            cboMotivoFacturaElectronica.DataSource = Lista;
            cboMotivoFacturaElectronica.SelectedIndex = -1;
        }
        private void CARGAR_NRO_DOC(string COD_DOC)
        {
            if (CBO_SUCURSAL.SelectedValue != null)
            {
                sdcTo.COD_SUCURSAL = CBO_SUCURSAL.SelectedValue.ToString();
                sdcTo.COD_DOC = cbo_tipo_doc.SelectedValue.ToString();
                CBO_NI2.ValueMember = "SERIE";
                CBO_NI2.DisplayMember = "SERIE";
                CBO_NI2.DataSource = sdcBLL.obtenerSerieDocumentoparaFacturacionBLL(sdcTo);
            }
        }
        private void ValidaTagPage()
        {
            if (cbo_tipo_doc.SelectedValue.ToString() == "07" || cbo_tipo_doc.SelectedValue.ToString() == "08")
            {
                //TabPage03.Parent = Nothing
                TabPage5.Parent = TabControl2;
            }
            else
            {
                TabPage5.Parent = null;
            }
        }

        private void CBO_MONEDA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBO_MONEDA.SelectedValue != null)
            {
                if (CBO_MONEDA.SelectedIndex > -1)
                {
                    tcpTo.Año = DTP_DOC.Value.Year.ToString();
                    tcpTo.Mes = DTP_DOC.Value.Month.ToString("MM"); ;
                    tcpTo.Dia = DTP_DOC.Value.Day.ToString("dd");
                    tcpTo.Cod_Moneda = CBO_MONEDA.SelectedValue.ToString();
                }
            }
        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            if (!validaAgregarProductos())
                return;

            TabPage02.Select();
            //gb_cab0.Enabled = false;
            //gb_oc.Enabled = false;
            Panel1.Visible = false;
            Panel2.Visible = true;
            btn_guardar2.Visible = true;
            btn_mod2.Visible = false;
            LIMPIAR_DETALLES();
            TXT_COD_PRO.Focus();
        }
        private bool validaAgregarProductos()
        {
            bool result = true;
            if (TXT_COD.Text == "")
            {
                MessageBox.Show("Ingrese el codigo del Cliente !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TXT_COD.Focus();
                return result = false;
            }
            if (TXT_DESC.Text == "")
            {
                MessageBox.Show("Ingrese el nombre del Cliente !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TXT_DESC.Focus();
                return result = false;
            }
            if (txt_doc_per.Text == "")
            {
                MessageBox.Show("Ingrese el documento de identidad del Cliente !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_doc_per.Focus();
                return result = false;
            }
            if (TXT_NUMERO2.Text == "")
            {
                MessageBox.Show("Ingrese el  numero del Documento de Facturación !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TXT_NUMERO2.Focus();
                return result = false;
            }
            decimal tc = 0;
            if (!decimal.TryParse(TXT_TC.Text, out tc))
            {
                MessageBox.Show("El tipo de cambio debe de ser un número", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TXT_TC.Focus();
                return result = false;
            }
            if (Convert.ToDecimal(TXT_TC.Text) == 0)
            {
                MessageBox.Show("Ingrese el  tipo de Cambio !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TXT_TC.Focus();
                return result = false;
            }
            //
            if (txt_cod2.Text == "")
            {
                MessageBox.Show("Ingrese el codigo del Vendedor !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_cod2.Focus();
                return result = false;
            }
            if (txt_desc2.Text == "")
            {
                MessageBox.Show("Ingrese el nombre del Vendedor !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_desc2.Focus();
                return result = false;
            }
            if (!(DTP_DOC.Value.Date <= FECHA_GRAL.Date && DTP_DOC.Value.Date >= FECHA_INI.Date))
            {
                MessageBox.Show("La Fecha esta fuera del rango !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                DTP_DOC.Focus();
                return result = false;
            }
            return result;
        }
        private void LIMPIAR_DETALLES()
        {
            TXT_COD_PRO.Clear();
            TXT_DESC_PRO.Clear();
            TXT_NRO_PARTE.Clear();
            TXT_CANT.Clear();
            //obs.txt_obs.Clear();
            TXT_PU.Clear();
            if (CH_PV.Checked)
            {
                //ch_dscto.Checked = False
                //ch_dscto.Enabled = False
                TXT_DSCTO.Text = "0.00";
                TXT_DSCTO.ReadOnly = true;
            }
            else
            {
                ch_dscto.Checked = true;
                ch_dscto.Enabled = true;
                TXT_DSCTO.Clear();
                TXT_DSCTO.ReadOnly = true;
            }
            TXT_DSCTO.Text = "0.00";
            txt_pu1.Text = "0.00";
            txt_bruto1.Text = "0.00";
            txt_dscto1.Text = "0.00";
            txt_neto1.Text = "0.00";
            txt_igv1.Text = "0.00";
            txt_total1.Text = "0.00";
            CH_IGV.Checked = true;
            //obs.txt_obs.Clear();
        }

        private void btn_mod_Click(object sender, EventArgs e)
        {
            if (!validaModificarProductos())
                return;
            btn_guardar2.Visible = false;
            btn_mod2.Visible = true;
            ITEM.Text = dgw_det.CurrentRow.Index.ToString();
            Panel1.Visible = false;
            Panel2.Visible = true;
            LIMPIAR_DETALLES();
            CARGAR_DETALLE1();
            Panel_PRO.Visible = false;
            TXT_CANT.Focus();
        }
        private bool validaModificarProductos()
        {
            bool result = true;
            if (dgw_det.Rows.Count <= 0)
            {
                MessageBox.Show("No existen productos !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return result = false;
            }
            return result;
        }
        private void CARGAR_DETALLE1()
        {
            TXT_COD_PRO.Text = dgw_det.CurrentRow.Cells["codigo1"].Value.ToString();
            TXT_DESC_PRO.Text = dgw_det.CurrentRow.Cells["descripcion1"].Value.ToString();
            TXT_CANT.Text = dgw_det.CurrentRow.Cells["cantidad1"].Value.ToString();
            TXT_IGV.Text = dgw_det.CurrentRow.Cells["por_igv1"].Value.ToString();
            //
            if (dgw_det.CurrentRow.Cells["st_igv1"].Value.ToString() == "1")
                CH_IGV.Checked = true;
            else
                CH_IGV.Checked = false;
            //
            if (CH_PV.Checked)
                TXT_PU.Text = Math.Round(Convert.ToDecimal(dgw_det.CurrentRow.Cells["precio_u1"].Value) * ((Convert.ToDecimal(TXT_IGV.Text) / 100 + 1M)), 2).ToString();
            else
                TXT_PU.Text = Convert.ToDecimal(dgw_det.CurrentRow.Cells["precio_u1"].Value).ToString();
            //
            txt_bruto1.Text = dgw_det.CurrentRow.Cells["importe1"].Value.ToString();
            TXT_DSCTO.Text = dgw_det.CurrentRow.Cells["por_dscto1"].Value.ToString();
            obs.txt_obs.Text = dgw_det.CurrentRow.Cells["observacion1"].Value.ToString();
            if (dgw_det.CurrentRow.Cells["st_dscto1"].Value.ToString() == "1")
                ch_dscto.Checked = true;
            else
                ch_dscto.Checked = false;
            TXT_NRO_PARTE.Text = dgw_det.CurrentRow.Cells["nro_parte1"].Value.ToString();
            //
            cboCodigoPrecioVenta.SelectedValue = dgw_det.CurrentRow.Cells["cod_precio_fact_elec1"].Value.ToString();
            cboTipoAfectaciónIgv.SelectedValue = dgw_det.CurrentRow.Cells["cod_tipo_afec_igv1"].Value.ToString();
            HALLAR_VALOR_VENTA();
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
                }//Gestion Comercial/compras/servicio/requiriento de servicio
                else if (dgw_per.Rows.Count > 0)
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
            }
        }

        private void btn_eliminar2_Click(object sender, EventArgs e)
        {
            if (!validaEliminaProductos())
                return;

            DialogResult rs = MessageBox.Show("¿ Esta seguro de eliminar el registro ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                dgw_det.Rows.RemoveAt(dgw_det.CurrentRow.Index);
            }
            HALLAR_TOTAL_OC();
        }
        private bool validaEliminaProductos()
        {
            bool result = true;
            if (dgw_det.Rows.Count <= 0)
            {
                MessageBox.Show("No existen registro para eliminar !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return result = false;
            }
            return result;
        }
        private void HALLAR_TOTAL_OC()
        {
            int num, num2;
            num = 0;
            num2 = dgw_det.Rows.Count;
            decimal left = 0, num7 = 0, num9 = 0, num8 = 0, d = 0;
            int num10 = num2;

            while (num < num10)
            {
                left += Convert.ToDecimal(dgw_det.Rows[num].Cells["importe1"].Value) + Convert.ToDecimal(dgw_det.Rows[num].Cells["ajuste_bi1"].Value);
                num7 += Convert.ToDecimal(dgw_det.Rows[num].Cells["dscto1"].Value);
                num9 = (num9 + Convert.ToDecimal(dgw_det.Rows[num].Cells["importe1"].Value)) - Convert.ToDecimal(dgw_det.Rows[num].Cells["por_dscto1"].Value) + Convert.ToDecimal(dgw_det.Rows[num].Cells["ajuste_bi1"].Value);
                num8 = num8 + Convert.ToDecimal(dgw_det.Rows[num].Cells["igv1"].Value) + Convert.ToDecimal(dgw_det.Rows[num].Cells["ajuste_igv1"].Value);
                d = num8 + num9;
                num++;
            }
            TXT_TB.Text = (Math.Round(left, 2).ToString());
            TXT_TD.Text = (Math.Round(num7, 2).ToString());
            TXT_TN.Text = (Math.Round(num9, 2).ToString());
            TXT_TIGV.Text = (Math.Round(num8, 2).ToString());
            TXT_TT.Text = (Math.Round(d, 2).ToString());
            TXT_TB.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(TXT_TB.Text);
            TXT_TD.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(TXT_TD.Text);
            TXT_TN.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(TXT_TN.Text);
            TXT_TIGV.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(TXT_TIGV.Text);
            TXT_TT.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(TXT_TT.Text);

            //decimal impor = 0, dscto = 0, igv = 0, neto = 0, total = 0;
            //foreach (DataGridViewRow rw in dgw_det.Rows)
            //{
            //    ////impor = impor + Convert.ToDecimal(rw.Cells[7].Value);
            //    ////dscto = dscto + Convert.ToDecimal(rw.Cells[12].Value);
            //    ////igv = igv + Convert.ToDecimal(rw.Cells[11].Value);
            //    ////neto = impor - dscto;
            //    ////total = neto + igv;
            //    //impor = impor + Convert.ToDecimal(rw.Cells[7].Value);
            //    //dscto = dscto + Convert.ToDecimal(rw.Cells[12].Value);
            //    if (rw.Cells["cod_precio_fact_elec1"].Value.ToString() == "01")///hay que cambiar el valor del cell aqui
            //    {
            //        impor = impor + Convert.ToDecimal(rw.Cells["importe1"].Value);
            //        igv = 0;//igv + Convert.ToDecimal(rw.Cells[11].Value);
            //        dscto = dscto + Convert.ToDecimal(rw.Cells["dscto1"].Value);
            //    }


            //}
            //total = impor;
            ////neto = total / 1.18M;
            ////neto = total / (1 + Math.Round((igv0 / 100), 2));
            //neto = total;
            ////igv = total - neto;
            ////TXT_TB.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(impor.ToString());
            ////TXT_TD.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(dscto.ToString());
            ////TXT_TN.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(neto.ToString());
            ////TXT_TIGV.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(igv.ToString());
            ////TXT_TT.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(total.ToString());
            //TXT_TB.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES((impor - igv).ToString());
            //TXT_TD.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(dscto.ToString());
            //TXT_TN.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES((impor - igv).ToString());
            //TXT_TIGV.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(igv.ToString());
            //TXT_TT.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(impor.ToString());
        }

        private void btn_guardar2_Click(object sender, EventArgs e)
        {
            if (!validaGuardarProductos())
                return;

            if (TXT_DSCTO.Text == "")
                TXT_DSCTO.Text = "0.00";
            //HALLAR_VALOR_VENTA();
            if (cboCodigoPrecioVenta.Text == "VALOR REFERENCIAL")
                dgw_det.Rows.Add((hallar_item(dgw_det.Rows.Count)), TXT_COD_PRO.Text, TXT_DESC_PRO.Text, HelpersBLL.OBTIENE_PRECIO_TRES_DECIMALES(TXT_CANT.Text), "0.00", "0.00", HelpersBLL.OBTIENE_PRECIO_TRES_DECIMALES(txt_pu1.Text), 0, TXT_IGV.Text, TXT_DSCTO.Text, STATUS_IGV, 0, txt_dscto1.Text, "0.00", "0.00", "D", obs.txt_obs.Text, STATUS_DSCTO, TXT_NRO_PARTE.Text, cboCodigoPrecioVenta.SelectedValue.ToString(), cboTipoAfectaciónIgv.SelectedValue.ToString(), HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(txt_bruto1.Text), txt_igv1.Text);
            else
                dgw_det.Rows.Add((hallar_item(dgw_det.Rows.Count)), TXT_COD_PRO.Text, TXT_DESC_PRO.Text, HelpersBLL.OBTIENE_PRECIO_TRES_DECIMALES(TXT_CANT.Text), "0.00", "0.00", HelpersBLL.OBTIENE_PRECIO_TRES_DECIMALES(txt_pu1.Text), HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(txt_bruto1.Text), TXT_IGV.Text, TXT_DSCTO.Text, STATUS_IGV, txt_igv1.Text, txt_dscto1.Text, "0.00", "0.00", "D", obs.txt_obs.Text, STATUS_DSCTO, TXT_NRO_PARTE.Text, cboCodigoPrecioVenta.SelectedValue.ToString(), cboTipoAfectaciónIgv.SelectedValue.ToString(), 0, 0);

            HALLAR_TOTAL_OC();
            //if(TXT_COD_PRO.Text == "000000000A")
            //    STATUS_A = "1";
            //    //'LBL_DOC.Text = "Documento de Anticipo."
            LIMPIAR_DETALLES();
            TXT_COD_PRO.Focus();
        }
        private bool validaGuardarProductos()
        {
            bool result = true;
            if (TXT_COD_PRO.Text.Trim() == "")
            {
                MessageBox.Show("Elija codigo el Producto !", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TXT_COD_PRO.Focus();
                return result = false;
            }
            if (TXT_DESC_PRO.Text.Trim() == "")
            {
                MessageBox.Show("Elija el Producto !", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TXT_DESC_PRO.Focus();
                return result = false;
            }
            if (TXT_CANT.Text.Trim() == "0.00")
            {
                MessageBox.Show("Ingresa la cantidad !!!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TXT_CANT.Focus();
                return result = false;
            }
            if (TXT_PU.Text.Trim() == "0.00")
            {
                MessageBox.Show("Ingresa el precio U.!!!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TXT_PU.Focus();
                return result = false;
            }
            return result;
        }
        private void HALLAR_VALOR_VENTA()
        {
            if (TXT_CANT.Text.Trim() == "" || TXT_DSCTO.Text.Trim() == "" || TXT_PU.Text.Trim() == "")
            { }
            else
            {
                if (CH_PV.Checked)
                    txt_pu1.Text = (Convert.ToDecimal(TXT_PU.Text) * (100 / (100 + Convert.ToDecimal(TXT_IGV.Text)))).ToString();//txt_pu1.Text = (Convert.ToDecimal(TXT_PU.Text) * (100 / (100 + igv0))).ToString();//txt_pu1.Text = TXT_PU.Text;
                                                                                                                                 //txt_pu1.Text = TXT_PU.Text;
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
        private string hallar_item(int it)
        {
            string ite = (it + 1).ToString();
            return ite.PadLeft(2, '0');
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

        private void dgw_per_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int idx = dgw_per.CurrentRow.Index;
                TXT_COD.Text = dgw_per[0, idx].Value.ToString();
                TXT_DESC.Text = dgw_per[1, idx].Value.ToString();
                txt_doc_per.Text = dgw_per[2, idx].Value.ToString();


                Panel_PER.Visible = false;
                //TabControl2.SelectedTab = TabPage3;
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
                            //cboptovta.Focus();
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

        private void txt_desc2_Leave(object sender, EventArgs e)
        {
            if (txt_desc2.Text == "")
            {
                //cbo_alm.Focus();
                //cboptovta.Focus();
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

        private void dgw_per2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int idx = dgw_per2.CurrentRow.Index;
                txt_cod2.Text = dgw_per2[0, idx].Value.ToString();
                txt_desc2.Text = dgw_per2[1, idx].Value.ToString();
                panel_per2.Visible = false;
                cboTipoOperacionFacturaElectronica.Focus();
                //txt_desc2.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                //Panel_PER.Visible = false;
                panel_per2.Visible = false;
                txt_cod2.Clear();
                txt_desc2.Clear();
                txt_cod2.Focus();
            }
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
                        if (DGW_PRO[1, i].Value.ToString().Length >= TXT_DESC_PRO.TextLength)
                        {
                            if (TXT_DESC_PRO.Text.ToLower() == DGW_PRO[1, i].Value.ToString().ToLower().Substring(0, TXT_DESC_PRO.TextLength).ToLower())
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

        private void DGW_PRO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TXT_COD_PRO.Text = DGW_PRO[0, DGW_PRO.CurrentRow.Index].Value.ToString();
                TXT_DESC_PRO.Text = DGW_PRO[1, DGW_PRO.CurrentRow.Index].Value.ToString();
                TXT_NRO_PARTE.Text = DGW_PRO[2, DGW_PRO.CurrentRow.Index].Value.ToString();
                CH_IGV.Checked = true;
                if (DGW_PRO[3, DGW_PRO.CurrentRow.Index].Value.ToString() == "0")
                {
                    CH_IGV.Checked = false;
                    cboCodigoPrecioVenta.SelectedValue = "01";
                    cboTipoAfectaciónIgv.SelectedValue = "30";
                }
                else
                {
                    CH_IGV.Checked = true;
                    cboCodigoPrecioVenta.SelectedValue = "02";
                    cboTipoAfectaciónIgv.SelectedValue = "31";
                }

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

        private void TXT_CANT_Leave(object sender, EventArgs e)
        {
            TXT_CANT.Text = HelpersBLL.OBTIENE_PRECIO_TRES_DECIMALES(TXT_CANT.Text);
        }

        private void TXT_PU_Leave(object sender, EventArgs e)
        {
            TXT_PU.Text = HelpersBLL.OBTIENE_PRECIO_TRES_DECIMALES(TXT_PU.Text);
        }

        private void btn_obs_Click(object sender, EventArgs e)
        {
            obs.txt_obs.MaxLength = 800;
            obs.ShowDialog();
        }

        private void TXT_PU_KeyDown(object sender, KeyEventArgs e)
        {
            if (HelpersBLL.IsNumeric(TXT_CANT.Text) && HelpersBLL.IsNumeric(TXT_PU.Text))
            {
                HALLAR_VALOR_VENTA();
            }
        }

        private void btn_cancelar2_Click(object sender, EventArgs e)
        {
            Panel1.Visible = true;
            Panel2.Visible = false;
            btn_agregar.Select();
        }

        private async void btn_Imprimir_Click(object sender, EventArgs e)
        {
            //Facturacion electronica
            facturacionVtaCabeceraTo fvtaToFE = new facturacionVtaCabeceraTo();

            IIFacVtaService ifactService = Injector.Get<IFacVtaServiceImpl>();
            ITFacVtaService tfactService = Injector.Get<TFacVtaServiceImpl>();
            IDirectorioService iDirectorioService = Injector.Get<DirectorioServiceImpl>();


            string RutaPdf;
            string RutaXml;
            string RutaCdr;
            string smtp;
            int puertoSmtp;
            string ClaveSol;
            string UsuarioSol;
            string CertificadoDigital;
            string ClaveCertificado;
            string RutaImagen;
            string UrlSunatEnvio;
            string cuentaBanco;

            var listParamater = iDirectorioService.getAll();
            RutaPdf = listParamater.Where(x => x.Codigo == "FILPDF").SingleOrDefault().Descripcion;
            RutaXml = listParamater.Where(x => x.Codigo == "FILXML").SingleOrDefault().Descripcion;
            RutaCdr = listParamater.Where(x => x.Codigo == "FILCDR").SingleOrDefault().Descripcion;
            smtp = listParamater.Where(x => x.Codigo == "SMTP").SingleOrDefault().Descripcion;
            puertoSmtp = Convert.ToInt32(listParamater.Where(x => x.Codigo == "SMTPPT").SingleOrDefault().Descripcion);
            ClaveSol = listParamater.Where(x => x.Codigo == "PASSOL").SingleOrDefault().Descripcion;
            UsuarioSol = listParamater.Where(x => x.Codigo == "USUSOL").SingleOrDefault().Descripcion;
            CertificadoDigital = listParamater.Where(x => x.Codigo == "FIRDIG").SingleOrDefault().Descripcion;
            ClaveCertificado = listParamater.Where(x => x.Codigo == "PASSFD").SingleOrDefault().Descripcion;
            RutaImagen = listParamater.Where(x => x.Codigo == "IMALOG").SingleOrDefault().Descripcion;
            cuentaBanco = listParamater.Where(x => x.Codigo == "NUM_BN").SingleOrDefault().Descripcion;
            UrlSunatEnvio = ConfigurationManager.AppSettings["UrlSunatEnvio"];

            dynamic iFactVta = new ExpandoObject();
            iFactVta.CoSucursal = CBO_SUCURSAL.SelectedValue.ToString();
            iFactVta.CodClase = CBO_CLASE.SelectedValue.ToString();
            iFactVta.CodDoc = cbo_tipo_doc.SelectedValue.ToString();
            if (boton == "NUEVO")
                iFactVta.NroDoc = txt_nro_doc.Text;
            else if (boton == "MODIFICAR")
                iFactVta.NroDoc = txt_nro_doc.Text;

            iFactVta.CodCliente = TXT_COD.Text.Trim();
            iFactVta.Año = AÑO;
            iFactVta.Mes = MES;


            dynamic invoice = ifactService.GetInvoice(iFactVta);
            var lines = tfactService.getDetails(invoice);

            HttpResponseMessage response;
            var proxy = new HttpClient { BaseAddress = new Uri(ConfigurationManager.AppSettings["UrlElectronicInvoiceApi"]) };

            DocumentoElectronico documento = ifactService.generateElectronicInvoice(invoice, lines);
            documento.CuentaBancoNacion = cuentaBanco;

            string metodoApi;
            switch (documento.TipoDocumento)
            {
                case "07":
                    metodoApi = "api/GenerarNotaCredito";
                    break;
                case "08":
                    metodoApi = "api/GenerarNotaDebito";
                    break;
                default:
                    metodoApi = "api/GenerarFactura";
                    break;
            }

            response = await proxy.PostAsJsonAsync(metodoApi, documento);

            if (response.IsSuccessStatusCode)
            {
                var documentoResponse = await response.Content.ReadAsAsync<DocumentoResponse>();

                if (documentoResponse.Exito)
                {
                    metodoApi = "api/Firmar";
                    FirmadoRequest firmadoRequest = new FirmadoRequest
                    {
                        CertificadoDigital = Convert.ToBase64String(File.ReadAllBytes(CertificadoDigital)),
                        PasswordCertificado = ClaveCertificado,
                        RucEmisor = documento.Emisor.NroDocumento,
                        TramaXmlSinFirma = documentoResponse.TramaXmlSinFirma,
                        UnSoloNodoExtension = true
                    };

                    response = await proxy.PostAsJsonAsync(metodoApi, firmadoRequest);

                    if (response.IsSuccessStatusCode)
                    {
                        var firmadoResponse = await response.Content.ReadAsAsync<FirmadoResponse>();

                        if (firmadoResponse.Exito)
                        {
                            //Gurdamos el archivo
                            string path = string.Format(@"{0}\{1}-{2}.xml", RutaXml, documento.IdDocumento, documento.TipoDocumento);
                            File.WriteAllBytes(path, Convert.FromBase64String(firmadoResponse.TramaXmlFirmado));

                            switch (documento.TipoDocumento)
                            {
                                case "07":
                                    metodoApi = "api/GenerarNotaCreditoPdf";
                                    break;
                                case "08":
                                    metodoApi = "api/GenerarNotaDebitoPdf";
                                    break;
                                case "03":
                                    metodoApi = "api/GenerarBoletaPdf";
                                    break;
                                case "01":
                                    metodoApi = "api/GenerarFacturaPdf";
                                    break;
                            }

                            PdfRequest pdfRequest = new PdfRequest
                            {
                                ClaveCertificado = ClaveCertificado,
                                Documento = documento,
                                ResumenFirma = firmadoResponse.ResumenFirma,
                                RutaCertificado = CertificadoDigital,
                                RutaImagen = RutaImagen,
                                RutaPdf = RutaPdf,
                                ValorFirma = firmadoResponse.ValorFirma
                            };

                            response = await proxy.PostAsJsonAsync(metodoApi, pdfRequest);

                            if (response.IsSuccessStatusCode)
                            {
                                var pdfResponse = await response.Content.ReadAsAsync<PdfResponse>();

                                if (pdfResponse.Exito)
                                {
                                    using (var form = new Form())
                                    {
                                        var wb = new WebBrowser();
                                        wb.Dock = DockStyle.Fill;
                                        wb.Url = new Uri(pdfResponse.RutaArchivoPdf);
                                        form.Controls.Add(wb);
                                        form.WindowState = FormWindowState.Maximized;
                                        form.ShowDialog();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void btn_mod2_Click(object sender, EventArgs e)
        {
            if (!validaGuardarProductos())
                return;

            string str = "0";
            if (CH_IGV.Checked)
                str = "1";

            dgw_det.CurrentRow.Cells["codigo1"].Value = TXT_COD_PRO.Text;
            dgw_det.CurrentRow.Cells["descripcion1"].Value = TXT_DESC_PRO.Text;
            dgw_det.CurrentRow.Cells["cantidad1"].Value = HelpersBLL.OBTIENE_PRECIO_TRES_DECIMALES(TXT_CANT.Text);
            //dgw_det.CurrentRow.Cells["cant_aten1"].Value = TXT_COD_PRO.Text;
            //dgw_det.CurrentRow.Cells["cant_anul1"].Value = TXT_COD_PRO.Text;
            dgw_det.CurrentRow.Cells["precio_u1"].Value = HelpersBLL.OBTIENE_PRECIO_TRES_DECIMALES(txt_pu1.Text);
            //dgw_det.CurrentRow.Cells["importe1"].Value = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES((Convert.ToDecimal(TXT_PU.Text) * Convert.ToDecimal(TXT_CANT.Text)).ToString());
            dgw_det.CurrentRow.Cells["importe1"].Value = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(txt_bruto1.Text);
            dgw_det.CurrentRow.Cells["por_igv1"].Value = TXT_IGV.Text;
            dgw_det.CurrentRow.Cells["por_dscto1"].Value = TXT_DSCTO.Text;
            dgw_det.CurrentRow.Cells["st_igv1"].Value = str;
            dgw_det.CurrentRow.Cells["igv1"].Value = txt_igv1.Text;
            dgw_det.CurrentRow.Cells["dscto1"].Value = txt_dscto1.Text;
            //dgw_det.CurrentRow.Cells["ajuste_igv1"].Value = TXT_COD_PRO.Text;
            //dgw_det.CurrentRow.Cells["ajuste_bi1"].Value = TXT_COD_PRO.Text;
            //dgw_det.CurrentRow.Cells["dh1"].Value = TXT_COD_PRO.Text;
            dgw_det.CurrentRow.Cells["observacion1"].Value = obs.txt_obs.Text;
            dgw_det.CurrentRow.Cells["st_dscto1"].Value = STATUS_DSCTO;
            dgw_det.CurrentRow.Cells["nro_parte1"].Value = TXT_NRO_PARTE.Text;
            dgw_det.CurrentRow.Cells["cod_precio_fact_elec1"].Value = cboCodigoPrecioVenta.SelectedValue.ToString();
            dgw_det.CurrentRow.Cells["cod_tipo_afec_igv1"].Value = cboTipoAfectaciónIgv.SelectedValue.ToString();
            if (cboCodigoPrecioVenta.SelectedValue.ToString() == "02")//valor referencial
            {
                dgw_det.CurrentRow.Cells["importe1"].Value = "0.00";
                dgw_det.CurrentRow.Cells["igv1"].Value = "0.00";
                dgw_det.CurrentRow.Cells["valor_ref1"].Value = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(txt_bruto1.Text);
                dgw_det.CurrentRow.Cells["valor_igv_ref1"].Value = txt_igv1.Text;
            }
            else
            {
                dgw_det.CurrentRow.Cells["valor_ref1"].Value = "0.00";
                dgw_det.CurrentRow.Cells["valor_igv_ref1"].Value = "0.00";
            }
            HALLAR_TOTAL_OC();
            Panel2.Visible = false;
            Panel1.Visible = true;
            btn_agregar.Focus();

        }
        private bool validaModificaProductoSeleccionado()
        {
            bool result = true;
            return result;
        }

        private void CBO_PAGO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBO_PAGO.SelectedValue != null)
            {
                if (CBO_PAGO.SelectedIndex > -1)
                {
                    cbo_VENTA.SelectedIndex = -1;
                    TXT_DIA1.Text = "0";
                    cbo_VENTA.Enabled = true;
                    if (CBO_PAGO.SelectedValue.ToString() != "03")
                        cbo_VENTA.Enabled = false;
                }
            }
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
                    TXT_DIA1.Text = nro_dias.ToString();
                    //DTP_VEN.Value.AddDays(nro_dias);
                    DTP_VEN.Value = DTP_DOC.Value.AddDays(nro_dias);
                }
            }
        }
        private void btn_oc_Click(object sender, EventArgs e)
        {
            if (chkStatusFacturaElectronica.Checked)
            {
                if (CBO_DOC.Text.Trim() == "FACTURA")
                {
                    if (txt_nro_doc.Text.Substring(0, 1) == "B" || txt_nro_doc.Text.Substring(0, 1) == "F")
                        txt_nro_doc.Text = "F" + txt_nro_doc.Text.Remove(0, 1);
                    else
                        txt_nro_doc.Text = "F" + txt_nro_doc.Text;
                }
                else if (CBO_DOC.Text.Trim() == "BOLETA DE VENTA")
                {
                    if (txt_nro_doc.Text.Substring(0, 1) == "B" || txt_nro_doc.Text.Substring(0, 1) == "F")
                        txt_nro_doc.Text = "B" + txt_nro_doc.Text.Remove(0, 1);
                    else
                        txt_nro_doc.Text = "B" + txt_nro_doc.Text;
                }
            }
            CONSULTAS.CONSULTA_FACT buscar = new CONSULTAS.CONSULTA_FACT(AÑO, MES);
            buscar.Text = "Facturas de : " + TXT_DESC.Text;
            buscar.COD_SUC = CBO_SUCURSAL.SelectedValue.ToString();
            buscar.COD_DOC = CBO_DOC.SelectedValue.ToString();
            buscar.NRO_DOC = txt_nro_doc.Text;
            buscar.COD_PER = TXT_COD.Text;
            buscar._FormPadre = this;
            buscar.CARGAR_FACTURACION();
            //buscar.ShowDialog();

            DialogResult res = buscar.ShowDialog();
            if (res == DialogResult.OK)
            {
                TXT_NRO_FACT.Text = buscar.DGW_CAB.CurrentRow.Cells["NRO_DOC1"].Value.ToString();
                DTP_FACT.Value = Convert.ToDateTime(buscar.DGW_CAB.CurrentRow.Cells["FECHA_DOC1"].Value);
                CBO_MONEDA_REF.SelectedValue = buscar.DGW_CAB.CurrentRow.Cells["COD_MONEDA1"].Value;
                TXT_TC_REF.Text = cbo_tipo_doc.SelectedValue.ToString() == "07" ? buscar.DGW_CAB.CurrentRow.Cells["TIPO_CAMBIO1"].Value.ToString() : TXT_TC.Text;
            }
        }

        private void btn_grabar_Click(object sender, EventArgs e)
        {
            if (!validaGrabarDocumentoFacturacion())
                return;

            DialogResult rs = MessageBox.Show("¿ Esta seguro de hacer un nuevo Documento de Facturación ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                string COD_REF = ""; string NRO_REF = ""; decimal TIPO_CAMBIO = 0; DateTime? FECHA_REF;
                if (cbo_tipo_doc.SelectedValue.ToString() == "07")
                {
                    COD_REF = CBO_DOC.SelectedValue.ToString();
                    NRO_REF = TXT_NRO_FACT.Text;
                    FECHA_REF = DTP_FACT.Value;
                    TIPO_CAMBIO = Convert.ToDecimal(TXT_TC_REF.Text);
                }
                else if (cbo_tipo_doc.SelectedValue.ToString() == "08")
                {
                    COD_REF = CBO_DOC.SelectedValue.ToString();
                    NRO_REF = TXT_NRO_FACT.Text;
                    FECHA_REF = DTP_FACT.Value;
                    TIPO_CAMBIO = Convert.ToDecimal(TXT_TC.Text);
                    //TIPO_CAMBIO = Convert.ToDecimal(helBLL.obtenerTipoCambioBLL(DTP_DOC.Value.Year.ToString(), HelpersBLL.OBTIENE_CODIGO(2, DTP_DOC.Value.Month.ToString()),
                    //HelpersBLL.OBTIENE_CODIGO(2, DTP_DOC.Value.Day.ToString()), "D"));
                }
                else
                {
                    COD_REF = "";
                    NRO_REF = "";
                    FECHA_REF = null;
                    TIPO_CAMBIO = Convert.ToDecimal(TXT_TC.Text);
                    //TIPO_CAMBIO = Convert.ToDecimal(helBLL.obtenerTipoCambioBLL(DTP_DOC.Value.Year.ToString(), HelpersBLL.OBTIENE_CODIGO(2, DTP_DOC.Value.Month.ToString()),
                    //HelpersBLL.OBTIENE_CODIGO(2, DTP_DOC.Value.Day.ToString()), "D"));
                }
                fvtaTo.COD_SUCURSAL = CBO_SUCURSAL.SelectedValue.ToString();
                fvtaTo.COD_CLASE = CBO_CLASE.SelectedValue.ToString();
                fvtaTo.COD_DOC = cbo_tipo_doc.SelectedValue.ToString();
                //fvtaTo.NRO_DOC = cbo_ni.Text + "-" + txt_numero.Text.PadLeft(7,'0');
                fvtaTo.NRO_DOC = txt_nro_doc.Text;//obtenerPrefijoDocumentoElectronico(cbo_tipo_doc.SelectedValue.ToString()) + cbo_ni.Text + "-" + txt_numero.Text.PadLeft(7, '0');
                fvtaTo.COD_PER = TXT_COD.Text.Trim();
                fvtaTo.FE_AÑO = AÑO;
                fvtaTo.FE_MES = MES;
                fvtaTo.NRO_DOC_PER = txt_doc_per.Text.Trim();
                fvtaTo.FECHA_DOC = DTP_DOC.Value;
                DTP_VEN.Value = DTP_DOC.Value.AddDays(int.Parse(TXT_DIA1.Text));
                fvtaTo.FECHA_VEN = DTP_VEN.Value;
                fvtaTo.COD_MONEDA = CBO_MONEDA.SelectedValue.ToString();
                fvtaTo.OBSERVACION = TXT_OBS_NOTA.Text;
                fvtaTo.TIPO_ORIGEN = "S";//S que es de servicio
                fvtaTo.STATUS_PV = CH_PV.Checked ? "1" : "0";
                fvtaTo.COD_D_H = "D";
                fvtaTo.STATUS_CIERRE = "0";
                fvtaTo.NRO_PEDIDO = "";
                fvtaTo.NRO_PRESUPUESTO = "";
                fvtaTo.COD_VENDEDOR = txt_cod2.Text;
                fvtaTo.COD_USU_CREA = COD_USU;
                fvtaTo.FECHA_CREA = DateTime.Now;
                fvtaTo.SERIE2 = CBO_NI2.SelectedValue.ToString();
                fvtaTo.ST_TIP_VTA = "SS";
                fvtaTo.NOMBRE_PC = NOMBRE_PC;
                fvtaTo.COD_MOT_DEV = cboMotivoFacturaElectronica.SelectedValue == null ? "" : cboMotivoFacturaElectronica.SelectedValue.ToString();
                fvtaTo.COD_MOV = cbo_movimiento.SelectedValue.ToString();
                fvtaTo.TIPO_FACT = "S";
                fvtaTo.VALOR_DETRACCION = ValorDetraccion;
                fvtaTo.POR_DETRACCION = PorDetraccion;
                fvtaTo.STATUS_FE = "1";
                fvtaTo.STATUS_ENVIO_FE = "0";
                fvtaTo.TIPO_OPERACION_FE = cboTipoOperacionFacturaElectronica.SelectedValue.ToString();
                fvtaTo.STATUS_BAJA_FE = "0";
                fvtaTo.COD_REF = COD_REF;
                fvtaTo.NRO_REF = NRO_REF;
                fvtaTo.FECHA_REF = FECHA_REF;
                fvtaTo.TIPO_CAMBIO = TIPO_CAMBIO;
                fvtaTo.FORMA_PAGO = CBO_PAGO.SelectedValue.ToString();
                fvtaTo.NRO_DIAS = Convert.ToInt32(TXT_DIA1.Text);
                fvtaTo.CONDICION_VENTA = cbo_VENTA.SelectedValue != null ? cbo_VENTA.SelectedValue.ToString() : "";

                DT00.Rows.Clear();
                int num = dgw_det.Rows.Count - 1;
                int num3 = num;
                int i = 0;
                while (i <= num3)
                {
                    DT00.Rows.Add(CBO_SUCURSAL.SelectedValue.ToString(), CBO_CLASE.SelectedValue.ToString(), cbo_tipo_doc.SelectedValue.ToString(), txt_nro_doc.Text,
                    TXT_COD.Text.Trim(), AÑO, MES, dgw_det[0, i].Value.ToString(), "", "", "", dgw_det.Rows[i].Cells["codigo1"].Value.ToString(),
                    dgw_det.Rows[i].Cells["cantidad1"].Value.ToString(), dgw_det.Rows[i].Cells["dh1"].Value.ToString(), CBO_MONEDA.SelectedValue.ToString(),
                    Convert.ToDecimal(dgw_det.Rows[i].Cells["precio_u1"].Value), Convert.ToDecimal(dgw_det.Rows[i].Cells["importe1"].Value), dgw_det.Rows[i].Cells["por_igv1"].Value.ToString(),
                    dgw_det.Rows[i].Cells["por_dscto1"].Value.ToString(),
                    dgw_det.Rows[i].Cells["st_igv1"].Value.ToString(), dgw_det.Rows[i].Cells["igv1"].Value.ToString(),//8
                    dgw_det.Rows[i].Cells["dscto1"].Value.ToString(),//Convert.ToDecimal(DGW_DET[8, i].Value) * 0.01M * Convert.ToDecimal(DGW_DET[10, i].Value),
                    0, 0, dgw_det[0, i].Value.ToString(), dgw_det.Rows[i].Cells["observacion1"].Value.ToString(), NOMBRE_PC, "", "A",
                    "", dgw_det.Rows[i].Cells["valor_ref1"].Value.ToString(), dgw_det.Rows[i].Cells["valor_igv_ref1"].Value.ToString(),
                    dgw_det.Rows[i].Cells["cod_precio_fact_elec1"].Value.ToString(),
                    dgw_det.Rows[i].Cells["cod_tipo_afec_igv1"].Value.ToString(), dgw_det.Rows[i].Cells["descripcion1"].Value.ToString());
                    i++;
                }

                if (!fvtaBLL.adicionaFacturacionVentaDI_BLL(fvtaTo, DT00, ref errMensaje))
                {
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (!helBLL.ELIMINAR_TEMPORAL("FACT_VTA", NOMBRE_PC, ref errMensaje))
                        MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Se creó correctamente el Documento de Facturación !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DATAGRID();
                    Panel1.Visible = true;
                    btn_grabar.Enabled = false;
                    btn_imprimir.Enabled = true;
                    btn_imprimir.Focus();
                }
            }
        }
        private bool validaGrabarDocumentoFacturacion()
        {
            bool result = true;
            if (TXT_COD.Text == "")
            {
                MessageBox.Show("Ingrese el codigo del Cliente !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TXT_COD.Focus();
                return result = false;
            }
            if (TXT_DESC.Text == "")
            {
                MessageBox.Show("Ingrese el nombre del Cliente !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TXT_DESC.Focus();
                return result = false;
            }
            if (txt_doc_per.Text == "")
            {
                MessageBox.Show("Ingrese el documento de identidad del Cliente !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_doc_per.Focus();
                return result = false;
            }
            if (TXT_NUMERO2.Text == "")
            {
                MessageBox.Show("Ingrese el  numero del Documento de Facturación !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TXT_NUMERO2.Focus();
                return result = false;
            }
            decimal tc = 0;
            if (!decimal.TryParse(TXT_TC.Text, out tc))
            {
                MessageBox.Show("El tipo de cambio debe de ser un número", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TXT_TC.Focus();
                return result = false;
            }
            if (Convert.ToDecimal(TXT_TC.Text) == 0)
            {
                MessageBox.Show("Ingrese el  tipo de Cambio !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TXT_TC.Focus();
                return result = false;
            }
            //
            if (txt_cod2.Text == "")
            {
                MessageBox.Show("Ingrese el codigo del Vendedor !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_cod2.Focus();
                return result = false;
            }
            if (txt_desc2.Text == "")
            {
                MessageBox.Show("Ingrese el nombre del Vendedor !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_desc2.Focus();
                return result = false;
            }
            if (dgw_det.Rows.Count <= 0)
            {
                MessageBox.Show("Ingrese Productos !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btn_agregar.Focus();
                return result = false;
            }
            if (!(DTP_DOC.Value.Date <= FECHA_GRAL.Date && DTP_DOC.Value.Date >= FECHA_INI.Date))
            {
                MessageBox.Show("La Fecha esta fuera del rango !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                DTP_DOC.Focus();
                return result = false;
            }
            if (cbo_tipo_doc.SelectedValue.ToString() == "01" && txt_doc_per.Text.Length != 11)
            {
                MessageBox.Show("Solo se puede hacer una Factura con un cliente con RUC !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_tipo_doc.Focus();
                return result = false;
            }
            if (cbo_tipo_doc.SelectedValue.ToString() == "03" && txt_doc_per.Text.Length != 8)
            {
                MessageBox.Show("Solo se puede hacer una Boleta con un cliente con DNI !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_tipo_doc.Focus();
                return result = false;
            }
            return result;
        }

        private void BTN_GRABAR2_Click(object sender, EventArgs e)
        {
            if (!validaGrabarDocumentoFacturacion())
                return;

            DialogResult rs = MessageBox.Show("¿ Esta seguro de modificar Documento de Facturación ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                string COD_REF = ""; string NRO_REF = ""; decimal TIPO_CAMBIO = 0; DateTime? FECHA_REF;
                if (cbo_tipo_doc.SelectedValue.ToString() == "07")
                {
                    COD_REF = CBO_DOC.SelectedValue.ToString();
                    NRO_REF = TXT_NRO_FACT.Text;
                    FECHA_REF = DTP_FACT.Value;
                    TIPO_CAMBIO = Convert.ToDecimal(TXT_TC_REF.Text);
                }
                else if (cbo_tipo_doc.SelectedValue.ToString() == "08")
                {
                    COD_REF = CBO_DOC.SelectedValue.ToString();
                    NRO_REF = TXT_NRO_FACT.Text;
                    FECHA_REF = DTP_FACT.Value;
                    TIPO_CAMBIO = Convert.ToDecimal(TXT_TC.Text);
                    //TIPO_CAMBIO = Convert.ToDecimal(helBLL.obtenerTipoCambioBLL(DTP_DOC.Value.Year.ToString(), HelpersBLL.OBTIENE_CODIGO(2, DTP_DOC.Value.Month.ToString()),
                    //HelpersBLL.OBTIENE_CODIGO(2, DTP_DOC.Value.Day.ToString()), "D"));
                }
                else
                {
                    COD_REF = "";
                    NRO_REF = "";
                    FECHA_REF = null;
                    TIPO_CAMBIO = Convert.ToDecimal(TXT_TC.Text);
                    //TIPO_CAMBIO = Convert.ToDecimal(helBLL.obtenerTipoCambioBLL(DTP_DOC.Value.Year.ToString(), HelpersBLL.OBTIENE_CODIGO(2, DTP_DOC.Value.Month.ToString()),
                    //HelpersBLL.OBTIENE_CODIGO(2, DTP_DOC.Value.Day.ToString()), "D"));
                }
                fvtaTo.COD_SUCURSAL = CBO_SUCURSAL.SelectedValue.ToString();
                fvtaTo.COD_CLASE = CBO_CLASE.SelectedValue.ToString();
                fvtaTo.COD_DOC = cbo_tipo_doc.SelectedValue.ToString();
                //fvtaTo.NRO_DOC = cbo_ni.Text + "-" + txt_numero.Text.PadLeft(7,'0');
                fvtaTo.NRO_DOC = txt_nro_doc.Text;//obtenerPrefijoDocumentoElectronico(cbo_tipo_doc.SelectedValue.ToString()) + cbo_ni.Text + "-" + txt_numero.Text.PadLeft(7, '0');
                fvtaTo.COD_PER = TXT_COD.Text.Trim();
                fvtaTo.FE_AÑO = AÑO;
                fvtaTo.FE_MES = MES;
                fvtaTo.NRO_DOC_PER = txt_doc_per.Text.Trim();
                fvtaTo.FECHA_DOC = DTP_DOC.Value;
                DTP_VEN.Value = DTP_DOC.Value.AddDays(int.Parse(TXT_DIA1.Text));
                fvtaTo.FECHA_VEN = DTP_VEN.Value;
                fvtaTo.COD_MONEDA = CBO_MONEDA.SelectedValue.ToString();
                fvtaTo.OBSERVACION = TXT_OBS_NOTA.Text;
                fvtaTo.TIPO_ORIGEN = "S";//S que es de servicio
                fvtaTo.STATUS_PV = CH_PV.Checked ? "1" : "0";
                fvtaTo.COD_D_H = "D";
                fvtaTo.STATUS_CIERRE = "0";
                fvtaTo.NRO_PEDIDO = "";
                fvtaTo.NRO_PRESUPUESTO = "";
                fvtaTo.COD_VENDEDOR = txt_cod2.Text;
                fvtaTo.COD_USU_CREA = COD_USU;
                fvtaTo.FECHA_CREA = DateTime.Now;
                fvtaTo.SERIE2 = CBO_NI2.SelectedValue.ToString();
                fvtaTo.ST_TIP_VTA = "SS";
                fvtaTo.NOMBRE_PC = NOMBRE_PC;
                fvtaTo.COD_MOT_DEV = cboMotivoFacturaElectronica.SelectedValue == null ? "" : cboMotivoFacturaElectronica.SelectedValue.ToString();
                fvtaTo.COD_MOV = cbo_movimiento.SelectedValue.ToString();
                fvtaTo.TIPO_FACT = "S";
                fvtaTo.VALOR_DETRACCION = ValorDetraccion;
                fvtaTo.POR_DETRACCION = PorDetraccion;
                fvtaTo.STATUS_FE = "1";
                fvtaTo.STATUS_ENVIO_FE = "0";
                fvtaTo.TIPO_OPERACION_FE = cboTipoOperacionFacturaElectronica.SelectedValue.ToString();
                fvtaTo.STATUS_BAJA_FE = "0";
                fvtaTo.COD_REF = COD_REF;
                fvtaTo.NRO_REF = NRO_REF;
                fvtaTo.FECHA_REF = FECHA_REF;
                fvtaTo.TIPO_CAMBIO = TIPO_CAMBIO;
                fvtaTo.FORMA_PAGO = CBO_PAGO.SelectedValue.ToString();
                fvtaTo.NRO_DIAS = Convert.ToInt32(TXT_DIA1.Text);
                fvtaTo.CONDICION_VENTA = cbo_VENTA.SelectedValue != null ? cbo_VENTA.SelectedValue.ToString() : "";

                DT00.Rows.Clear();
                int num = dgw_det.Rows.Count - 1;
                int num3 = num;
                int i = 0;
                while (i <= num3)
                {
                    DT00.Rows.Add(CBO_SUCURSAL.SelectedValue.ToString(), CBO_CLASE.SelectedValue.ToString(), cbo_tipo_doc.SelectedValue.ToString(), txt_nro_doc.Text,
                    TXT_COD.Text.Trim(), AÑO, MES, dgw_det[0, i].Value.ToString(), "", "", "", dgw_det.Rows[i].Cells["codigo1"].Value.ToString(),
                    dgw_det.Rows[i].Cells["cantidad1"].Value.ToString(), dgw_det.Rows[i].Cells["dh1"].Value.ToString(), CBO_MONEDA.SelectedValue.ToString(),
                    Convert.ToDecimal(dgw_det.Rows[i].Cells["precio_u1"].Value), Convert.ToDecimal(dgw_det.Rows[i].Cells["importe1"].Value), dgw_det.Rows[i].Cells["por_igv1"].Value.ToString(),
                    dgw_det.Rows[i].Cells["por_dscto1"].Value.ToString(),
                    dgw_det.Rows[i].Cells["st_igv1"].Value.ToString(), dgw_det.Rows[i].Cells["igv1"].Value.ToString(),//8
                    dgw_det.Rows[i].Cells["dscto1"].Value.ToString(),//Convert.ToDecimal(DGW_DET[8, i].Value) * 0.01M * Convert.ToDecimal(DGW_DET[10, i].Value),
                    0, 0, dgw_det[0, i].Value.ToString(), dgw_det.Rows[i].Cells["observacion1"].Value.ToString(), NOMBRE_PC, "", "A",
                    "", dgw_det.Rows[i].Cells["valor_ref1"].Value.ToString(), dgw_det.Rows[i].Cells["valor_igv_ref1"].Value.ToString(),
                    dgw_det.Rows[i].Cells["cod_precio_fact_elec1"].Value.ToString(),
                    dgw_det.Rows[i].Cells["cod_tipo_afec_igv1"].Value.ToString(), dgw_det.Rows[i].Cells["descripcion1"].Value.ToString());
                    i++;
                }

                if (!fvtaBLL.modificaFacturacionVentaDI_BLL(fvtaTo, DT00, ref errMensaje))
                {
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (!helBLL.ELIMINAR_TEMPORAL("FACT_VTA", NOMBRE_PC, ref errMensaje))
                        MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Se creó correctamente el Documento de Facturación !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //TabControl1.SelectedTab = TabPage3;

                    DATAGRID();
                    GB6.Enabled = false;
                    dgw_det.ReadOnly = true;
                    BTN_GRABAR2.Enabled = false;
                    //btn_anti.Enabled = False
                    btn_imprimir.Enabled = true;
                    DGW.CurrentCell = (DGW.Rows[INDICE].Cells[1]);
                    btn_grabar.Visible = true;
                    BTN_GRABAR2.Visible = false;
                    btn_grabar.Enabled = true;
                    btn_imprimir.Enabled = false;
                    TabControl1.SelectedTab = (TabPage1);
                    //BTN_ANTICIPO.Visible = True
                    //BTN_ANTICIPO2.Visible = False
                    LIMPIAR_CABECERA();

                    //DATAGRID();
                    //Panel1.Visible = true;
                    //btn_grabar.Enabled = false;
                    //btn_imprimir.Enabled = true;
                    //btn_imprimir.Focus();
                }
            }
        }
        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btn_nuevo2_Click(object sender, EventArgs e)
        {
            boton = "NUEVO";
            btn_grabar.Visible = true;
            btn_grabar.Enabled = true;
            btn_imprimir.Enabled = false;
            Panel1.Visible = true;
            Panel2.Visible = false;
            Panel0.Enabled = true;
            btn_mod.Visible = true;
            valoresIniciales();
            //CBO_NI2.Visible = true;
            //TXT_NI2.Visible = False
            //**********************************************
            //DATOS DE LA FACTURACION
            //**********************************************
            CBO_DOC.Enabled = true;
            btn_oc.Enabled = true;
            TXT_OBS_NOTA.Enabled = true;
            LIMPIAR_CABECERA();
            TabControl1.SelectedTab = (TabPage2);
            CBO_SUCURSAL.Select();
        }
        private void valoresIniciales()
        {
            CBO_SUCURSAL.SelectedIndex = 0;
            CBO_CLASE.SelectedIndex = 0;
            cbo_tipo_doc.SelectedIndex = -1;
            CBO_MONEDA.SelectedValue = "S";
            cboTipoOperacionFacturaElectronica.SelectedValue = "01";
            CBO_PAGO.SelectedValue = "03";
            cbo_VENTA.SelectedIndex = -1;
            cbo_movimiento.SelectedIndex = 1;
        }
        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            TabControl1.SelectedTab = (TabPage1);
            btn_nuevo.Select();
        }

        private void BTN_CONSULTA_Click(object sender, EventArgs e)
        {
            boton = "MODIFICAR";
            LIMPIAR_CABECERA();
            //cbo_ni.Visible = False
            //TXT_NI.Visible = True
            //txt_numero.Visible = True
            btn_grabar.Visible = false;
            //BTN_ANTICIPO.Enabled = False
            btn_imprimir.Enabled = true;
            btnDetraccion.Enabled = false;

            Panel1.Visible = true;
            Panel2.Visible = false;
            Panel0.Enabled = false;
            //-----------------------
            dgw_det.ReadOnly = true;
            //btn_anti.Enabled = False
            //btn_cargo.Enabled = False
            //-----------------------
            txt_nro_doc.Visible = true;
            CBO_NI2.Visible = false;
            TXT_NUMERO2.Visible = false;
            CARGAR_DATOS();
            CARGAR_DETALLES_DGW();
            gb_cab0.Enabled = false;
            //btn_cargo.Enabled = False
            gb_oc.Enabled = false;
            //gb_DEntrega.Enabled = False
            btn_ajuste.Enabled = false;
            //btn_Caja.Visible = False
            HALLAR_TOTAL_OC();
            //CARGAR_TAB_ANTICIPO()
            //CARGAR_TAB_CARGOS()
            //TXT_TN3.Text = (CDbl(((TXT_TN2.Text) - Convert.ToDouble(ANT_TOTAL))))
            //TXT_TN3.Text = (obj.HACER_DECIMAL(TXT_TN3.Text))
            //If ((TXT_TI2.Text) = 0) Then
            //    TXT_TI3.Text = "0.00"
            //Else
            //    TXT_TI3.Text = (CDbl(((TXT_TN3.Text) * Convert.ToDouble(Decimal.Divide(IGV1, 100)))))
            //End If
            //TXT_TI3.Text = obj.HACER_DECIMAL(TXT_TI3.Text)
            //TXT_TT3.Text = (Decimal.Add((TXT_TN3.Text), (TXT_TI3.Text)))
            //TXT_TT3.Text = obj.HACER_DECIMAL(TXT_TT3.Text)
            //HALLAR_TOTAL_CARGO();

            //**********************************************
            //DATOS DE LA FACTURACION
            //**********************************************
            ValidaTagPage();

            CBO_DOC.Enabled = false;
            btn_oc.Enabled = false;
            TXT_OBS_NOTA.Enabled = false;

            TabControl1.SelectedTab = TabPage2;
            btn_imprimir.Focus();
        }
        private void CARGAR_DATOS()
        {
            CBO_SUCURSAL.SelectedValue = DGW.CurrentRow.Cells["COD_SUCURSAL"].Value;
            CBO_CLASE.SelectedValue = DGW.CurrentRow.Cells["cod_clase"].Value;
            cbo_tipo_doc.SelectedValue = DGW.CurrentRow.Cells["COD_DOC"].Value;
            COD_DH = helBLL.COD_D_H(cbo_tipo_doc.SelectedValue.ToString());
            txt_nro_doc.Text = DGW.CurrentRow.Cells["NRO_DOC"].Value.ToString();
            TXT_COD.Text = DGW.CurrentRow.Cells["COD_PER"].Value.ToString();
            TXT_DESC.Text = DGW.CurrentRow.Cells["DESC_PER"].Value.ToString();
            txt_doc_per.Text = DGW.CurrentRow.Cells["DNI"].Value.ToString();
            CBO_MONEDA.SelectedValue = DGW.CurrentRow.Cells["COD_MONEDA"].Value;
            DTP_DOC.Value = Convert.ToDateTime(DGW.CurrentRow.Cells["FECHA_DOC"].Value);
            TXT_TC.Text = DGW.CurrentRow.Cells["TIPO_CAMBIO"].Value.ToString();
            txt_cod2.Text = DGW.CurrentRow.Cells["COD_VENDEDOR"].Value.ToString();
            txt_desc2.Text = DGW.CurrentRow.Cells["NOM_VENDEDOR"].Value.ToString();
            chkStatusFacturaElectronica.Checked = DGW.CurrentRow.Cells["STATUS_FE"].Value.ToString() == "1" ? true : false;
            cboTipoOperacionFacturaElectronica.SelectedValue = DGW.CurrentRow.Cells["TIPO_OPERACION_FE"].Value;
            txtValorDetraccion.Text = DGW.CurrentRow.Cells["VALOR_DETRACCION"].Value.ToString();
            txtPorcentajeDetraccion.Text = DGW.CurrentRow.Cells["POR_DETRACCION"].Value.ToString();
            CBO_PAGO.SelectedValue = DGW.CurrentRow.Cells["FORMA_PAGO"].Value.ToString();
            TXT_DIA1.Text = DGW.CurrentRow.Cells["NRO_DIAS"].Value.ToString();
            DTP_VEN.Value = Convert.ToDateTime(DGW.CurrentRow.Cells["FECHA_VEN"].Value);
            cbo_VENTA.SelectedValue = DGW.CurrentRow.Cells["CONDICION_VENTA"].Value;
            cbo_movimiento.SelectedValue = DGW.CurrentRow.Cells["COD_MOV"].Value;
            //CBO_PERSONAL.SelectedValue = DGW.CurrentRow.Cells["COD_PER_ELAB"].Value;
            CBO_DOC.SelectedValue = DGW.CurrentRow.Cells["COD_REF"].Value;
            TXT_NRO_FACT.Text = DGW.CurrentRow.Cells["NRO_REF"].Value.ToString();
            DTP_FACT.Value = DGW.CurrentRow.Cells["FECHA_REF"].Value.ToString() == "" ? DateTime.Now : Convert.ToDateTime(DGW.CurrentRow.Cells["FECHA_REF"].Value);
            CBO_MONEDA_REF.SelectedValue = CBO_MONEDA.SelectedValue;//DGW.CurrentRow.Cells["COD_MONEDA"].ToString();
            TXT_TC_REF.Text = TXT_TC.Text;//DGW.CurrentRow.Cells[""].Value.ToString();
            TXT_OBS_NOTA.Text = DGW.CurrentRow.Cells["OBSERVACION"].Value.ToString();
            cboMotivoFacturaElectronica.SelectedValue = DGW.CurrentRow.Cells["COD_MOT_DEV"].Value;
            PorDetraccion = Convert.ToDecimal(DGW.CurrentRow.Cells["POR_DETRACCION"].Value);
            ValorDetraccion = Convert.ToDecimal(DGW.CurrentRow.Cells["VALOR_DETRACCION"].Value);
            txtPorcentajeDetraccion.Text = string.Format("{0:N2}", PorDetraccion);
            txtValorDetraccion.Text = string.Format("{0:N2}", ValorDetraccion);
        }
        private void CARGAR_DETALLES_DGW()
        {
            dgw_det.Rows.Clear();
            dfvtaTo.COD_CLASE = DGW.CurrentRow.Cells["COD_CLASE"].Value.ToString();
            dfvtaTo.COD_SUCURSAL = DGW.CurrentRow.Cells["COD_SUCURSAL"].Value.ToString();
            dfvtaTo.COD_PER = DGW.CurrentRow.Cells["COD_PER"].Value.ToString();
            dfvtaTo.NRO_DOC = DGW.CurrentRow.Cells["NRO_DOC"].Value.ToString();
            dfvtaTo.FE_AÑO = DGW.CurrentRow.Cells["FE_AÑO"].Value.ToString();
            dfvtaTo.FE_MES = DGW.CurrentRow.Cells["FE_MES"].Value.ToString();
            dfvtaTo.COD_DOC = DGW.CurrentRow.Cells["COD_DOC"].Value.ToString();
            DataTable dt = dfvtaBLL.obtenerFacturacionVtaDetalleDI_BLL(dfvtaTo);
            if (dt.Rows.Count > 0)
            {
                dgw_det.Rows.Clear();
                foreach (DataRow rw in dt.Rows)
                {
                    int rowId = dgw_det.Rows.Add();
                    DataGridViewRow row = dgw_det.Rows[rowId];
                    row.Cells["item1"].Value = rw["ITEM"].ToString();
                    row.Cells["codigo1"].Value = rw["COD_ARTICULO"].ToString();
                    row.Cells["descripcion1"].Value = rw["DESC_ARTICULO"].ToString();
                    row.Cells["cantidad1"].Value = rw["CANTIDAD"].ToString();
                    row.Cells["cant_aten1"].Value = "0";
                    row.Cells["cant_anul1"].Value = "0";
                    row.Cells["precio_u1"].Value = rw["PRECIO_UNITARIO"].ToString();
                    row.Cells["importe1"].Value = rw["VALOR_COMPRA"].ToString();
                    row.Cells["por_igv1"].Value = rw["POR_IGV"].ToString();
                    row.Cells["por_dscto1"].Value = rw["POR_DSCTO"].ToString();
                    row.Cells["st_igv1"].Value = rw["STATUS_IGV"].ToString();
                    row.Cells["igv1"].Value = rw["VALOR_IGV"].ToString();
                    row.Cells["dscto1"].Value = rw["VALOR_DSCTO"].ToString();
                    row.Cells["ajuste_igv1"].Value = rw["AJUSTE_IGV"].ToString();
                    row.Cells["ajuste_bi1"].Value = rw["AJUSTE_BI"].ToString();
                    row.Cells["dh1"].Value = rw["COD_D_H"].ToString();
                    row.Cells["observacion1"].Value = rw["OBSERVACION"].ToString();
                    row.Cells["st_dscto1"].Value = rw["STATUS_POR_DSCTO"].ToString();
                    row.Cells["nro_parte1"].Value = rw["NRO_PARTE"].ToString();
                    row.Cells["cod_precio_fact_elec1"].Value = rw["COD_PRECIO_VTA_FE"].ToString();
                    row.Cells["cod_tipo_afec_igv1"].Value = rw["COD_TIPO_AFEC_IGV_FE"].ToString();
                    row.Cells["valor_ref1"].Value = rw["VALOR_REFERENCIA"].ToString();
                    row.Cells["valor_igv_ref1"].Value = rw["VALOR_IGV_REFERENCIA"].ToString();
                    row.Cells["c_costo1"].Value = "";

                }
            }

        }

        private void btnDetraccion_Click(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(TXT_TB.Text) > 0)
            {
                if (ValorDetraccion != 0 && PorDetraccion != 0)
                {
                    formDetraccion.Cero = true;
                    formDetraccion.txtPorDetraccion.Text = string.Format("{0:N2}", txtPorcentajeDetraccion.Text);
                    formDetraccion.txtValorDetraccion.Text = string.Format("{0:N2}", txtValorDetraccion.Text);
                }
                formDetraccion.Importe = Convert.ToDecimal(TXT_TT.Text);
                formDetraccion.ShowDialog();
                if (formDetraccion.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    if (Convert.ToDecimal(formDetraccion.txtValorDetraccion.Text) != 0)
                    {
                        PorDetraccion = Convert.ToDecimal(formDetraccion.txtPorDetraccion.Text);
                        ValorDetraccion = Convert.ToDecimal(formDetraccion.txtValorDetraccion.Text);
                        txtPorcentajeDetraccion.Text = string.Format("{0:N2}", PorDetraccion);
                        txtValorDetraccion.Text = string.Format("{0:N2}", ValorDetraccion);
                        formDetraccion.Cero = false;
                    }
                    formDetraccion.Limpiar();
                }
            }
            else
                MessageBox.Show("Debe haber detalles", "Detracción", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            boton = "MODIFICAR";
            INDICE = DGW.CurrentRow.Index;
            btn_imprimir.Enabled = false;

            LIMPIAR_CABECERA();
            txt_nro_doc.Visible = true;
            CBO_NI2.Visible = false;
            TXT_NUMERO2.Visible = false;
            //cbo_ni.Visible = False
            //TXT_NI.Visible = True
            //txt_numero.Visible = True
            btn_grabar.Visible = false;
            BTN_GRABAR2.Visible = true;
            BTN_GRABAR2.Enabled = true;
            //BTN_ANTICIPO.Visible = false;
            //BTN_ANTICIPO2.Visible = True
            Panel0.Enabled = true;
            //Panel02.Enabled = True
            gb_cab0.Enabled = false;
            CARGAR_DATOS();
            CARGAR_DETALLES_DGW();
            HALLAR_TOTAL_OC();
            //CARGAR_TAB_ANTICIPO()
            //CARGAR_TAB_CARGOS()


            ValidaTagPage();

            //'**********************************************
            //'DATOS DE LA FACTURACION
            //'**********************************************
            CBO_DOC.Enabled = false;
            btn_oc.Enabled = false;
            TXT_OBS_NOTA.Enabled = false;

            TabControl1.SelectedTab = (TabPage2);
            btn_agregar.Focus();
        }

        private void btn_anular_Click(object sender, EventArgs e)
        {
            if (!validaEliminarAnularFacturacionVenta())
                return;

            string errMensaje = "";
            string cod_suc = DGW.CurrentRow.Cells["COD_SUCURSAL"].Value.ToString();
            string cod_cla = DGW.CurrentRow.Cells["COD_CLASE"].Value.ToString();
            string cod_docu = DGW.CurrentRow.Cells["COD_DOC"].Value.ToString();
            string nro_docu = DGW.CurrentRow.Cells["NRO_DOC"].Value.ToString();
            string cod_pers = DGW.CurrentRow.Cells["COD_PER"].Value.ToString();
            string fe_mess = DGW.CurrentRow.Cells["FE_MES"].Value.ToString();
            string fe_annio = DGW.CurrentRow.Cells["FE_AÑO"].Value.ToString();
            string tipousu = "";
            string codigo = "";
            string obs = "";
            DialogResult rs = MessageBox.Show("¿ Esta seguro de anular el Documento Nº " + nro_docu + " ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                if (TIPO_USU != "MS")
                {
                    DIALOGOS.frmValidarEliminarAnular frm = new DIALOGOS.frmValidarEliminarAnular();
                    frm.Label2.Visible = true;
                    frm.txtObservacion.Visible = true;
                    frm.txtContraseña.Text = "";
                    frm.txtObservacion.Text = "";
                    frm.cargar_usuario("F_V");
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
                            anularFacturaVentas(cod_suc, cod_cla, cod_docu, nro_docu, cod_pers, fe_annio, fe_mess, obs, tipousu, ref errMensaje);
                            this.Dispose();
                        }
                        else
                            MessageBox.Show("Usted no tiene Permisos !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    frm.Dispose();
                }
                else
                {
                    tipousu = "0";
                    obs = "";
                    anularFacturaVentas(cod_suc, cod_cla, cod_docu, nro_docu, cod_pers, fe_annio, fe_mess, obs, tipousu, ref errMensaje);
                }
                DATAGRID();
                btn_nuevo.Select();
            }
        }
        private bool validaEliminarAnularFacturacionVenta()
        {
            bool result = true;
            //if (Convert.ToBoolean(dgw1[19, dgw1.CurrentRow.Index].Value) == true)
            //{
            //    MessageBox.Show("El Documento ya está Anulado !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return result = false;
            //}
            return result;
        }
        private void anularFacturaVentas(string COD_SUCURSAL, string COD_CLASE, string COD_DOC, string NRO_DOC, string COD_PER, string FE_AÑO, string FE_MES, string OBS, string TIPOUSU, ref string errMensaje)
        {
            fvtaTo.COD_SUCURSAL = COD_SUCURSAL;
            fvtaTo.COD_CLASE = COD_CLASE;
            fvtaTo.COD_DOC = COD_DOC;
            fvtaTo.NRO_DOC = NRO_DOC;
            fvtaTo.COD_PER = COD_PER;
            fvtaTo.FE_AÑO = FE_AÑO;
            fvtaTo.FE_MES = FE_MES;
            fvtaTo.TIPO_USU = TIPOUSU;
            fvtaTo.OBSERVACION = OBS;
            fvtaTo.COD_USU_MOD = COD_USU;
            fvtaTo.FECHA_MOD = DateTime.Now;

            if (!fvtaBLL.anularFacturacionCabeceraBLL(fvtaTo, ref errMensaje))
            {
                MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("El Documento se anuló correctamente !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (!validaEliminarAnularFacturacionVenta())
                return;

            string errMensaje = "";

            string cod_suc = DGW.CurrentRow.Cells["COD_SUCURSAL"].Value.ToString();
            string cod_cla = DGW.CurrentRow.Cells["COD_CLASE"].Value.ToString();
            string cod_docu = DGW.CurrentRow.Cells["COD_DOC"].Value.ToString();
            string nro_docu = DGW.CurrentRow.Cells["NRO_DOC"].Value.ToString();
            string cod_pers = DGW.CurrentRow.Cells["COD_PER"].Value.ToString();
            string fe_mess = DGW.CurrentRow.Cells["FE_MES"].Value.ToString();
            string fe_annio = DGW.CurrentRow.Cells["FE_AÑO"].Value.ToString();
            //string tipousu = "";
            string codigo = "";
            string obs = "";
            DialogResult rs = MessageBox.Show("¿ Esta seguro de eliminar el Documento Nº " + nro_docu + " ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                if (TIPO_USU != "MS")
                {
                    DIALOGOS.frmValidarEliminarAnular frm = new DIALOGOS.frmValidarEliminarAnular();
                    frm.Label2.Visible = true;
                    frm.txtObservacion.Visible = true;
                    frm.txtContraseña.Text = "";
                    frm.txtObservacion.Text = "";
                    frm.cargar_usuario("F_V");
                    frm.cboUsuario.Focus();
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        string pass = frm.txtContraseña.Text;
                        string claveEncriptada = HelpersBLL.ENCRIPTAR(pass.ToUpper());
                        codigo = perBLL.ValidarUsuarioEliminacionAnulacionBLL(claveEncriptada, frm.cboUsuario.Text);
                        //tipousu = "1";
                        obs = frm.txtObservacion.Text;

                        int RSLT = perBLL.ValidarDirectorioDesaprobarBLL(codigo, "VTA");//el segundo parametro no se usa
                        if (RSLT > 0)
                        {
                            eliminarFacturaVentas(cod_suc, cod_cla, cod_docu, nro_docu, cod_pers, fe_annio, fe_mess, ref errMensaje);
                            this.Dispose();
                        }
                        else
                            MessageBox.Show("Usted no tiene Permisos !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    frm.Dispose();
                }
                else
                {
                    //tipousu = "0";
                    obs = "";
                    eliminarFacturaVentas(cod_suc, cod_cla, cod_docu, nro_docu, cod_pers, fe_annio, fe_mess, ref errMensaje);
                }
                DATAGRID();
                btn_nuevo.Select();
            }
        }
        private void eliminarFacturaVentas(string COD_SUCURSAL, string COD_CLASE, string COD_DOC, string NRO_DOC, string COD_PER, string FE_AÑO, string FE_MES, ref string errMensaje)
        {
            fvtaTo.COD_SUCURSAL = COD_SUCURSAL;
            fvtaTo.COD_CLASE = COD_CLASE;
            fvtaTo.COD_DOC = COD_DOC;
            fvtaTo.NRO_DOC = NRO_DOC;
            fvtaTo.COD_PER = COD_PER;
            fvtaTo.FE_AÑO = FE_AÑO;
            fvtaTo.FE_MES = FE_MES;

            if (!fvtaBLL.eliminarFacturacionCabeceraBLL(fvtaTo, ref errMensaje))
                MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show("El Documento se eliminó correctamente !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void TXT_TC_REF_TextChanged(object sender, EventArgs e)
        {
            if (cbo_tipo_doc.SelectedValue != null)
            {
                if (cbo_tipo_doc.SelectedValue.ToString() == "07")
                    TXT_TC.Text = TXT_TC_REF.Text;
            }
        }

        private void txtPorcentajeDetraccion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TabControl2.SelectedTab = TabPage02;
                gb_oc.Focus();
            }
        }

        private void DTP_DOC_ValueChanged(object sender, EventArgs e)
        {
            OBTENER_TIPO_CAMBIO();
        }
        private void OBTENER_TIPO_CAMBIO()
        {
            //string cod_mon = cbo_moneda.SelectedValue.ToString();
            TXT_TC.Text = helBLL.obtenerTipoCambioBLL(DTP_DOC.Value.Year.ToString(), HelpersBLL.OBTIENE_CODIGO(2, DTP_DOC.Value.Month.ToString()),
                HelpersBLL.OBTIENE_CODIGO(2, DTP_DOC.Value.Day.ToString()), "D");
        }
    }
}
