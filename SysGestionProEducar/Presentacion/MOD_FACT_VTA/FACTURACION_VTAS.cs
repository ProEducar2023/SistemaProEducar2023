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
    public partial class FACTURACION_VTAS : Form
    {
        string AÑO = "", MES = "", COD_MOD = "", COD_USU = "", TIPO_USU = "";
        DateTime FECHA_INI, FECHA_GRAL;
        string BOTON, NRO_PED, COD_REF, NRO_REF, COD_DH_GRAL, COD_SUCURSAL2, TIPO_ORIGEN, CODIGO_VEND, ST_TIP_VTA, NRO_CONTRATO, GRID, NRO_INV, MOTIVO_DEV, COD_MOV_0, COD_KIT;
        DateTime FECHA_REF;
        DataTable DT00 = new DataTable();
        DataTable dtContratos, dtObsequios, dtDevContratos, dtDevObsequios;
        decimal IGV0;
        bool ops;
        HelpersBLL helBLL = new HelpersBLL();
        HelpersTo helTo = new HelpersTo();
        tipoCambioBLL tcpBLL = new tipoCambioBLL();
        tipoCambioTo tcpTo = new tipoCambioTo();
        serieDocumentoBLL sdcBLL = new serieDocumentoBLL();
        serieDocumentosTo sdcTo = new serieDocumentosTo();
        facturacionVtaCabeceraBLL fvtaBLL = new facturacionVtaCabeceraBLL();
        facturacionVtaCabeceraTo fvtaTo = new facturacionVtaCabeceraTo();
        facturacionVtaDetalleBLL dfvtaBLL = new facturacionVtaDetalleBLL();
        facturacionVtaDetalleTo dfvtaTo = new facturacionVtaDetalleTo();
        personaBLL perBLL = new personaBLL();
        directorioBLL dirBLL = new directorioBLL();
        directorioTo dirTo = new directorioTo();
        string NOMBRE_PC = System.Environment.MachineName;
        string serie_obsequios;
        string nro_doc_precio = "", nro_doc_obsequio = "";
        int fila; int fila1; int fila2; int fila3; int fila4;
        public FACTURACION_VTAS(string AÑO, string MES, DateTime FECHA_INI, DateTime FECHA_GRAL, string COD_MOD, string TIPO_USU, string COD_USU)
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

        private void FACTURACION_VTAS_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            DATAGRID();
            CARGAR_MONEDA();
            CARGAR_CLASE();
            CARGAR_PERSONAS();
            CARGAR_SUCURSAL();
            CARGAR_TIPO_OPERACION_FACTURA_ELECTRONICA();
            DOCUMENTOS();
            CargarCombo();
            LIMPIAR_CABECERA();
            IGV0 = helBLL.obtenerImpuestoBLL("IGV");
            TXT_IGV2.Text = IGV0.ToString();
            dtp_doc.Value = Convert.ToDateTime(DateTime.Now.Day + "/" + FECHA_INI.Month + "/" + FECHA_INI.Year);
            dirTo.TABLA_COD = "TSOBS";
            dirTo.CODIGO = null;
            serie_obsequios = dirBLL.DIR_TABLA_DESC(dirTo);//serie 06 por defecto para obsequios
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
            btn_nuevo.Select();
        }
        struct AfectacionIgv
        {
            public string Codigo { get; set; }
            public string Descripcion { get; set; }
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
            //para que aparesca en un combo del grid DGW_DET
            DataGridViewComboBoxColumn comboboxColumn = DGW_DET.Columns["COD_TIPO_AFEC_IGV_FE"] as DataGridViewComboBoxColumn;
            comboboxColumn.DataSource = Lista;
            comboboxColumn.DisplayMember = "Descripcion";
            comboboxColumn.ValueMember = "Codigo";
            // bindeo los datos de los productos a la grilla
            DGW_DET.AutoGenerateColumns = false;


        }
        private void CARGAR_TIPO_OPERACION_FACTURA_ELECTRONICA()
        {
            var tipo_op_fe = new[] { new { cod = "01", val = "VENTAS INTERNAS" }, new { cod = "02", val = "VENTA EXPORTACIONES" },
                                new { cod = "03", val = "NO DOMICILIADOS" }, new { cod = "04", val = "VENTA INTERNA - ANTICIPO" },
                                new { cod = "05", val = "VENTA ITINERANTE" }};
            cboTipoOperacionFacturaElectronica.ValueMember = "cod";
            cboTipoOperacionFacturaElectronica.DisplayMember = "val";
            cboTipoOperacionFacturaElectronica.DataSource = tipo_op_fe;
            cboTipoOperacionFacturaElectronica.SelectedIndex = 0;
        }
        private void FACTURACION_VTAS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void DATAGRID()
        {
            fvtaTo.FE_AÑO = AÑO;
            fvtaTo.FE_MES = MES;
            fvtaTo.TIPO_USU = TIPO_USU;
            fvtaTo.COD_USU = COD_USU;
            DataTable dt = fvtaBLL.obtenerFacturacionCabeceraBLL(fvtaTo);
            if (dt.Rows.Count > 0)
            {
                lbl_nro_reg_docs.Text = "Cantidad de Registros : " + dt.Rows.Count.ToString();
                dgw1.DataSource = dt;
                dgw1.Columns[0].Visible = false;
                dgw1.Columns[1].Visible = false;
                dgw1.Columns[2].Visible = false;
                dgw1.Columns[3].Visible = false;
                dgw1.Columns[4].Visible = false;
                dgw1.Columns[5].HeaderText = "Documento";
                dgw1.Columns[5].Width = 100;
                dgw1.Columns[6].HeaderText = "N° Doc";
                dgw1.Columns[6].Width = 100;
                dgw1.Columns[7].HeaderText = "Contrato";
                dgw1.Columns[7].Width = 70;
                dgw1.Columns[8].Visible = false;
                dgw1.Columns[9].HeaderText = "Cliente";
                dgw1.Columns[9].Width = 300;
                dgw1.Columns[10].HeaderText = "Vta";
                dgw1.Columns[10].Width = 40;
                dgw1.Columns[11].Visible = false;
                dgw1.Columns[12].HeaderText = "Fecha";
                dgw1.Columns[12].Width = 70;
                dgw1.Columns[12].DefaultCellStyle.Format = "d";
                dgw1.Columns[13].Visible = false;
                dgw1.Columns[14].Visible = false;
                dgw1.Columns[15].Visible = false;
                dgw1.Columns[16].Visible = false;
                dgw1.Columns[17].Visible = false;
                dgw1.Columns[18].HeaderText = "Cie.";
                dgw1.Columns[18].Width = 40;
                dgw1.Columns[19].HeaderText = "Anul.";
                dgw1.Columns[19].Width = 40;
                dgw1.Columns[20].Visible = false;
                dgw1.Columns[21].Visible = false;
                dgw1.Columns[22].Visible = false;
                dgw1.Columns[23].Visible = false;
                dgw1.Columns[24].Visible = false;
                dgw1.Columns["STATUS_ENVIO_FE"].Visible = false;
            }

        }
        private void CARGAR_MONEDA()
        {
            DataTable dt = helBLL.obtenerMonedaBLL();
            cbo_moneda.ValueMember = "COD_MONEDA";
            cbo_moneda.DisplayMember = "desc_moneda";
            cbo_moneda.DataSource = dt;
            cbo_moneda.SelectedItem = -1;
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
            cbo_clase.ValueMember = "COD_CLASE";
            cbo_clase.DisplayMember = "DESC_CLASE";
            cbo_clase.DataSource = dt;
            cbo_clase.SelectedIndex = -1;
        }
        private void CARGAR_PERSONAS()
        {
            helTo.CODIGO = "04";//VENDEDORES
            DataTable dt = helBLL.MOSTRAR_PERSONAS_XCOBRAR_BLL(helTo);
            dgw_per.DataSource = dt;
        }
        private void CARGAR_SUCURSAL()
        {
            //string COD_USU = "0000";
            helTo.CODIGO = COD_USU;
            DataTable dt = helBLL.CBO_SUCURSALBLL(helTo);
            cbo_sucursal.ValueMember = "COD_SUCURSAL";
            cbo_sucursal.DisplayMember = "DESC_sucursal";
            cbo_sucursal.DataSource = dt;
            cbo_sucursal.SelectedIndex = -1;
        }
        private void DOCUMENTOS()
        {
            DataTable dt = helBLL.obtenerDesc_Doc_GestionBLL();
            cbo_tipo_doc.ValueMember = "COD_DOC";
            cbo_tipo_doc.DisplayMember = "DESC_DOC";
            cbo_tipo_doc.DataSource = dt;
            cbo_tipo_doc.SelectedIndex = -1;

            DataTable dt1 = helBLL.obtenerDesc_Doc_GestionBLL();
            CBO_DOC.ValueMember = "COD_DOC";
            CBO_DOC.DisplayMember = "DESC_DOC";
            CBO_DOC.DataSource = dt1;
            CBO_DOC.SelectedIndex = -1;
        }
        private void LIMPIAR_CABECERA()
        {
            txt_dia.Clear();
            txt_dia.Text = "0";
            cbo_clase.SelectedIndex = -1;
            cbo_sucursal.SelectedIndex = -1;
            cbo_tipo_doc.SelectedIndex = -1;
            cbo_sucursal.Enabled = true;
            cbo_clase.Enabled = true;
            cbo_moneda.Enabled = true;
            cbo_tipo_doc.Enabled = true;
            txt_nro_doc.Visible = false;
            cbo_ni.Visible = true;
            txt_numero.Clear();
            txt_numero.Visible = true;
            TXT_COD.Clear();
            TXT_DESC.Clear();
            txt_doc_per.Clear();
            txt_obs.Clear();
            txt_nro_doc.Clear();
            txt_nro_doc.Enabled = true;
            txt_obs.Enabled = true;
            Panel_PER.Visible = false;
            DGW_DET.Rows.Clear();
            DGW_DET.Enabled = true;
            //ofr.DGW_G.Rows.Clear();
            //ofr.DGW_SALIDA.Rows.Clear();
            //CH_PV.Checked = false;
            cbo_moneda.SelectedIndex = -1;
            gb_cab.Enabled = true;
            GB2.Enabled = true;
            GB6.Enabled = true;
            TXT_TB.Text = "0.00";
            TXT_TD.Text = "0.00";
            TXT_TN.Text = "0.00";
            TXT_TT.Text = "0.00";
            TXT_TIGV.Text = "0.00";
            nro_doc_precio = "";
            nro_doc_obsequio = "";
            CARGAR_DOC_PENDIENTES();
        }
        private void CARGAR_DOC_PENDIENTES()
        {
            contratoCabeceraBLL ccBLL = new contratoCabeceraBLL();
            contratoCabeceraTo ccTo = new contratoCabeceraTo();
            ccTo.FE_AÑO = AÑO;
            ccTo.FE_MES = MES;
            dtContratos = ccBLL.obtenerContratosparaFacturacionBLL(ccTo);//CONTRATOS
            obtenerContratosparaFacturacion(dtContratos);
            //
            dtObsequios = ccBLL.obtenerContratosparaFacturacion3BLL(ccTo);//OBSEQUIOS
            obtenerObsequiosparaFacturacion(dtObsequios);
            //
            dtDevContratos = ccBLL.obtenerContratosDevolucionparaFacturacionBLL(ccTo);//DEVOLUCIONES DE CONTRATOS
            obtenerDevContratosparaFacturacion(dtDevContratos);
            //
            dtDevObsequios = ccBLL.obtenerObsequiosDevolucionparaFacturacionBLL(ccTo);//DEVOLUCIONES DE CONTRATOS DE OBSEQUIOS
            obtenerDevObsequiosparaFacturacion(dtDevObsequios);
        }
        private void obtenerContratosparaFacturacion(DataTable dt)
        {
            if (dt.Rows.Count >= 0)
            {
                decimal sum = 0;
                DGW_NOTA_PTE.Rows.Clear();
                lbl_nro_reg_contratos.Text = "Cantidad de Registros : " + dt.Rows.Count.ToString();
                foreach (DataRow rw in dt.Rows)
                {
                    int rowId = DGW_NOTA_PTE.Rows.Add();
                    DataGridViewRow row = DGW_NOTA_PTE.Rows[rowId];
                    row.Cells["COD_SUCURSAL"].Value = rw["COD_SUCURSAL"].ToString();
                    row.Cells["DESC_SUCURSAL"].Value = rw["DESC_SUCURSAL"].ToString();
                    row.Cells["COD_CLASE"].Value = rw["COD_CLASE"].ToString();
                    row.Cells["DESC_CLASE"].Value = rw["DESC_CLASE"].ToString();
                    row.Cells["NRO_DOC"].Value = rw["NRO_DOC"].ToString();
                    row.Cells["NRO_PRESUPUESTO"].Value = rw["NRO_PRESUPUESTO"].ToString();
                    row.Cells["COD_PER"].Value = rw["COD_PER"].ToString();
                    row.Cells["DESC_PER"].Value = rw["DESC_PER"].ToString();
                    row.Cells["DNI"].Value = rw["DNI"].ToString();
                    row.Cells["FECHA_PRE"].Value = rw["FECHA_PRE"].ToString().Substring(0, 10);
                    row.Cells["COD_VENDEDOR"].Value = rw["COD_VENDEDOR"].ToString();
                    row.Cells["DES_VEN"].Value = rw["DES_VEN"].ToString();
                    row.Cells["COD_MONEDA"].Value = rw["COD_MONEDA"].ToString();
                    row.Cells["FE_AÑO"].Value = rw["FE_AÑO"].ToString();
                    row.Cells["FE_MES"].Value = rw["FE_MES"].ToString();
                    row.Cells["FORMA_PAGO"].Value = rw["FORMA_PAGO"].ToString();
                    row.Cells["NRO_DIAS"].Value = rw["NRO_DIAS"].ToString();
                    row.Cells["IMP_DOC"].Value = rw["IMP_DOC"].ToString();
                    row.Cells["TOTAL_CONTRATO"].Value = rw["TOTAL_CONTRATO"].ToString();
                    row.Cells["COD_MOV"].Value = rw["COD_MOV"].ToString();
                    sum += Convert.ToDecimal(rw["TOTAL_CONTRATO"]);
                }
                txt_tot_contratos.Text = string.Format(sum.ToString(), "###,###,##0.00");

            }
        }
        private void obtenerObsequiosparaFacturacion(DataTable dt0)
        {
            if (dt0.Rows.Count >= 0)
            {
                DGW_OBSEQ.Rows.Clear();
                decimal sum = 0;
                lbl_nro_reg_obsequios.Text = "Cantidad de Registros : " + dt0.Rows.Count.ToString();
                foreach (DataRow rw in dt0.Rows)
                {
                    int rowId = DGW_OBSEQ.Rows.Add();
                    DataGridViewRow row = DGW_OBSEQ.Rows[rowId];
                    row.Cells["COD_SUCURSAL0"].Value = rw["COD_SUCURSAL"].ToString();
                    row.Cells["DESC_SUCURSAL0"].Value = rw["DESC_SUCURSAL"].ToString();
                    row.Cells["COD_CLASE0"].Value = rw["COD_CLASE"].ToString();
                    row.Cells["DESC_CLASE0"].Value = rw["DESC_CLASE"].ToString();
                    row.Cells["NRO_DOC0"].Value = rw["NRO_DOC"].ToString();
                    row.Cells["NRO_PRESUPUESTO0"].Value = rw["NRO_PRESUPUESTO"].ToString();
                    row.Cells["COD_PER0"].Value = rw["COD_PER"].ToString();
                    row.Cells["DESC_PER0"].Value = rw["DESC_PER"].ToString();
                    row.Cells["DNI0"].Value = rw["DNI"].ToString();
                    row.Cells["FECHA_PRE0"].Value = rw["FECHA_PRE"].ToString().Substring(0, 10);
                    row.Cells["COD_VENDEDOR0"].Value = rw["COD_VENDEDOR"].ToString();
                    row.Cells["DES_VEN0"].Value = rw["DES_VEN"].ToString();
                    row.Cells["COD_MONEDA0"].Value = rw["COD_MONEDA"].ToString();
                    row.Cells["FE_AÑO0"].Value = rw["FE_AÑO"].ToString();
                    row.Cells["FE_MES0"].Value = rw["FE_MES"].ToString();
                    row.Cells["FORMA_PAGO0"].Value = rw["FORMA_PAGO"].ToString();
                    row.Cells["NRO_DIAS0"].Value = rw["NRO_DIAS"].ToString();
                    row.Cells["IMP_DOC0"].Value = rw["IMP_DOC"].ToString();
                    row.Cells["TOTAL_CONTRATO0"].Value = rw["TOTAL_CONTRATO"].ToString();
                    row.Cells["COD_MOV1"].Value = rw["COD_MOV"].ToString();
                    sum += Convert.ToDecimal(rw["TOTAL_CONTRATO"]);
                }
                txt_tot_contratos0.Text = string.Format(sum.ToString(), "###,###,##0.00");
            }
        }
        private void obtenerDevContratosparaFacturacion(DataTable dt1)
        {
            if (dt1.Rows.Count >= 0)
            {
                dgw_ingreso.Rows.Clear();
                lbl_nro_reg_nota_credito.Text = "Cantidad de Registros : " + dt1.Rows.Count.ToString();
                foreach (DataRow rw in dt1.Rows)
                {
                    int rowId = dgw_ingreso.Rows.Add();
                    DataGridViewRow row = dgw_ingreso.Rows[rowId];
                    row.Cells["COD_SUCURSAL1"].Value = rw["COD_SUCURSAL"].ToString();
                    row.Cells["DESC_SUCURSAL1"].Value = rw["DESC_SUCURSAL"].ToString();
                    row.Cells["COD_CLASE1"].Value = rw["COD_CLASE"].ToString();
                    row.Cells["DESC_CLASE1"].Value = rw["DESC_CLASE"].ToString();
                    row.Cells["NRO_DOC_INV"].Value = rw["NRO_DOC_INV"].ToString();
                    row.Cells["COD_PER1"].Value = rw["COD_PER"].ToString();
                    row.Cells["DESC_PER1"].Value = rw["DESC_PER"].ToString();
                    row.Cells["nro_doc3"].Value = rw["nro_doc"].ToString();
                    row.Cells["FECHA_DOC1"].Value = rw["FECHA_DOC"].ToString() != "" ? rw["FECHA_DOC"].ToString().Substring(0, 10) : DateTime.Now.ToShortDateString();/////mal
                    row.Cells["DESC_PER2"].Value = rw["DES_VEN"].ToString();
                    row.Cells["COD_MONEDA1"].Value = rw["COD_MONEDA"].ToString();
                    row.Cells["FE_AÑO1"].Value = rw["FE_AÑO"].ToString();
                    row.Cells["FE_MES1"].Value = rw["FE_MES"].ToString();
                    row.Cells["NRO_PEDIDO"].Value = rw["NRO_PEDIDO"].ToString();
                    row.Cells["COD_MOTIVO_DEV"].Value = rw["COD_MOTIVO_DEV"].ToString();
                    row.Cells["COD_MOV2"].Value = rw["COD_MOV"].ToString();
                    row.Cells["TIPO_ORI"].Value = rw["TIPO_ORIGEN"].ToString();
                    row.Cells["COD_DOCUMENTO"].Value = rw["COD_DOCUMENTO"].ToString();
                    row.Cells["NRO_DOCUMENTO"].Value = rw["NRO_DOCUMENTO"].ToString();
                    row.Cells["TIPO_CAMBIO"].Value = rw["TIPO_CAMBIO"].ToString();
                    row.Cells["FORMA_PAGO1"].Value = rw["FORMA_PAGO"].ToString();
                    row.Cells["NRO_DIAS1"].Value = rw["NRO_DIAS"].ToString();
                    row.Cells["CONDICION_VENTA1"].Value = rw["CONDICION_VENTA"].ToString();
                    row.Cells["COD_KIT1"].Value = rw["COD_KIT"].ToString();
                }
            }
        }
        private void obtenerDevObsequiosparaFacturacion(DataTable dt2)
        {
            if (dt2.Rows.Count >= 0)
            {
                dgw_ingreso_obs.Rows.Clear();
                lbl_nro_reg_nota_credito_obsequios.Text = "Cantidad de Registros : " + dt2.Rows.Count.ToString();
                foreach (DataRow rw in dt2.Rows)
                {
                    int rowId = dgw_ingreso_obs.Rows.Add();
                    DataGridViewRow row = dgw_ingreso_obs.Rows[rowId];
                    row.Cells["COD_SUCURSAL3"].Value = rw["COD_SUCURSAL"].ToString();
                    row.Cells["DESC_SUCURSAL3"].Value = rw["DESC_SUCURSAL"].ToString();
                    row.Cells["COD_CLASE3"].Value = rw["COD_CLASE"].ToString();
                    row.Cells["DESC_CLASE3"].Value = rw["DESC_CLASE"].ToString();
                    row.Cells["NRO_DOC_INV3"].Value = rw["NRO_DOC_INV"].ToString();
                    row.Cells["COD_PER3"].Value = rw["COD_PER"].ToString();
                    row.Cells["DESC_PER3"].Value = rw["DESC_PER"].ToString();
                    row.Cells["nro_doc4"].Value = rw["nro_doc"].ToString();
                    row.Cells["FECHA_DOC3"].Value = rw["FECHA_DOC"].ToString();//.Substring(0, 10);
                    row.Cells["COD_VENDEDOR3"].Value = rw["COD_VENDEDOR"].ToString();
                    row.Cells["DESC_PER4"].Value = rw["DES_VEN"].ToString();
                    row.Cells["COD_MONEDA3"].Value = rw["COD_MONEDA"].ToString();
                    row.Cells["FE_AÑO3"].Value = rw["FE_AÑO"].ToString();
                    row.Cells["FE_MES3"].Value = rw["FE_MES"].ToString();
                    row.Cells["NRO_PEDIDO3"].Value = rw["NRO_PEDIDO"].ToString();
                    row.Cells["COD_MOTIVO_DEV2"].Value = rw["COD_MOTIVO_DEV"].ToString();
                    row.Cells["COD_MOV3"].Value = rw["COD_MOV"].ToString();
                    row.Cells["TIPO_ORI3"].Value = rw["TIPO_ORIGEN"].ToString();
                    row.Cells["COD_DOCUMENTO3"].Value = rw["COD_DOCUMENTO"].ToString();
                    row.Cells["NRO_DOCUMENTO3"].Value = rw["NRO_DOCUMENTO"].ToString();
                    row.Cells["TIPO_CAMBIO3"].Value = rw["TIPO_CAMBIO"].ToString();
                    row.Cells["FORMA_PAGO3"].Value = rw["FORMA_PAGO"].ToString();
                    row.Cells["NRO_DIAS3"].Value = rw["NRO_DIAS"].ToString();
                    row.Cells["CONDICION_VENTA3"].Value = rw["CONDICION_VENTA"].ToString();
                    row.Cells["COD_KIT2"].Value = rw["COD_KIT"].ToString();
                }
            }
        }
        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            BOTON = "NUEVO";
            BTN_GRABAR.Visible = true;
            BTN_GRABAR.Enabled = true;
            btn_Imprimir.Enabled = false;
            TabControl1.SelectedTab = TabPage3;
            TabControl2.SelectedTab = TabPage5;
            LIMPIAR_CABECERA();
            DGW_NOTA_PTE.Select();
        }

        private void btn_fact4_Click(object sender, EventArgs e)
        {
            if (dgw_ingreso.Rows.Count > 0)
            {
                BOTON = "NUEVO";
                BTN_GRABAR.Visible = true;
                BTN_GRABAR.Enabled = true;
                btn_Imprimir.Enabled = false;
                txt_nro_doc.Enabled = true;
                cbo_sucursal.SelectedValue = dgw_ingreso.CurrentRow.Cells["COD_SUCURSAL1"].Value.ToString();//dgw_ingreso[0, dgw_ingreso.CurrentRow.Index].Value;
                cbo_clase.SelectedValue = dgw_ingreso.CurrentRow.Cells["COD_CLASE1"].Value.ToString();//dgw_ingreso[2, dgw_ingreso.CurrentRow.Index].Value;
                TXT_COD.Text = dgw_ingreso.CurrentRow.Cells["COD_PER1"].Value.ToString();//dgw_ingreso[5, dgw_ingreso.CurrentRow.Index].Value.ToString();
                TXT_DESC.Text = dgw_ingreso.CurrentRow.Cells["DESC_PER1"].Value.ToString();//dgw_ingreso[6, dgw_ingreso.CurrentRow.Index].Value.ToString();
                txt_doc_per.Text = dgw_ingreso.CurrentRow.Cells["nro_doc3"].Value.ToString();//dgw_ingreso[7, dgw_ingreso.CurrentRow.Index].Value.ToString();
                cbo_moneda.SelectedValue = dgw_ingreso.CurrentRow.Cells["COD_MONEDA1"].Value.ToString();//dgw_ingreso[11, dgw_ingreso.CurrentRow.Index].Value;
                txt_dia.Text = "0";
                DTP_VEN.Value = dtp_doc.Value.AddDays(int.Parse(txt_dia.Text));
                string str = dgw_ingreso[4, dgw_ingreso.CurrentRow.Index].Value.ToString();
                cbo_sucursal.Enabled = false;
                cbo_clase.Enabled = false;
                cbo_tipo_doc.Enabled = true;
                //cbo_tipo_doc.SelectedIndex = -1;
                TXT_COD.Enabled = false;
                TXT_DESC.Enabled = false;
                txt_doc_per.Enabled = false;
                cbo_moneda.Enabled = false;
                txt_nro_doc.Visible = false;
                cbo_ni.Visible = true;
                txt_numero.Visible = true;
                dtp_doc.Enabled = true;
                txt_TC.Enabled = true;
                //dtp_doc.Value = DateTime.Now;
                txt_dia.Enabled = true;
                NRO_PED = dgw_ingreso[4, dgw_ingreso.CurrentRow.Index].Value.ToString();
                NRO_INV = dgw_ingreso[5, dgw_ingreso.CurrentRow.Index].Value.ToString();
                NRO_CONTRATO = "";//es el NRO_PRESUPUESTO que como viene de una Nota de Ingreso al almacen en la tabla INVENTARIO no concibe este campo
                MOTIVO_DEV = dgw_ingreso.CurrentRow.Cells["COD_MOTIVO_DEV"].Value.ToString();//dgw_ingreso[15, dgw_ingreso.CurrentRow.Index].Value.ToString();
                COD_MOV_0 = dgw_ingreso.CurrentRow.Cells["COD_MOV2"].Value.ToString();//DGW_NOTA_PTE
                CODIGO_VEND = dgw_ingreso.CurrentRow.Cells["COD_PER1"].Value.ToString();//dgw_ingreso[5, dgw_ingreso.CurrentRow.Index].Value.ToString();
                COD_KIT = dgw_ingreso.CurrentRow.Cells["COD_KIT1"].Value.ToString();
                ST_TIP_VTA = "PU";//Factura de Precio Unitario
                CBO_DOC.SelectedValue = dgw_ingreso.CurrentRow.Cells["COD_DOCUMENTO"].Value;
                TXT_NRO_FACT.Text = dgw_ingreso.CurrentRow.Cells["NRO_DOCUMENTO"].Value.ToString();
                DTP_FACT.Value = Convert.ToDateTime(dgw_ingreso.CurrentRow.Cells["FECHA_DOC1"].Value);
                TXT_TC_REF.Text = dgw_ingreso.CurrentRow.Cells["TIPO_CAMBIO"].Value.ToString();
                //FORMAPAGO(NRO_PED)
                TIPO_ORIGEN = "D";//DEVOLUCION
                GRID = "3";
                //AGREGADO POR CAMBIO DE IGV
                //Call Igv(FECHA_GRAL)
                OBTENER_TIPO_CAMBIO();
                CARGAR_DETALLES_GUIA2(str, cbo_sucursal.SelectedValue.ToString(),
                    cbo_clase.SelectedValue.ToString(), TXT_COD.Text, NRO_PED,
                    dgw_ingreso.CurrentRow.Cells["FE_AÑO1"].Value.ToString(),//dgw_ingreso[12, dgw_ingreso.CurrentRow.Index].Value.ToString(),
                    dgw_ingreso.CurrentRow.Cells["FE_MES1"].Value.ToString(),//dgw_ingreso[13, dgw_ingreso.CurrentRow.Index].Value.ToString(), 
                    CODIGO_VEND, COD_KIT);//trae 
                //ofr.DGW_PED.Rows.Add(NRO_PED)
                TabControl1.SelectedTab = TabPage2;
                ops = false;
                HALLAR_TOTAL_OC(ops);
                cbo_tipo_doc.Focus();
                COD_REF = "";
                NRO_REF = "";
                FECHA_REF = DateTime.Now;
                //ValidaTagPage();
            }
        }

        private void BTN_NOTA_DET2_Click(object sender, EventArgs e)
        {
            if (DGW_NOTA_PTE.Rows.Count > 0)
            {
                BOTON = "NUEVO";
                BTN_GRABAR.Visible = true;
                BTN_GRABAR.Enabled = true;
                btn_Imprimir.Enabled = false;
                txt_nro_doc.Enabled = true;
                cbo_sucursal.SelectedValue = DGW_NOTA_PTE[0, DGW_NOTA_PTE.CurrentRow.Index].Value;
                cbo_clase.SelectedValue = DGW_NOTA_PTE[2, DGW_NOTA_PTE.CurrentRow.Index].Value;
                TXT_COD.Text = DGW_NOTA_PTE[6, DGW_NOTA_PTE.CurrentRow.Index].Value.ToString();
                TXT_DESC.Text = DGW_NOTA_PTE[7, DGW_NOTA_PTE.CurrentRow.Index].Value.ToString();
                txt_doc_per.Text = DGW_NOTA_PTE[8, DGW_NOTA_PTE.CurrentRow.Index].Value.ToString();
                cbo_moneda.SelectedValue = DGW_NOTA_PTE[12, DGW_NOTA_PTE.CurrentRow.Index].Value;
                txt_dia.Text = DGW_NOTA_PTE[16, DGW_NOTA_PTE.CurrentRow.Index].Value.ToString();
                DTP_VEN.Value = dtp_doc.Value.AddDays(int.Parse(txt_dia.Text));
                cbo_sucursal.Enabled = false;
                cbo_clase.Enabled = false;
                cbo_tipo_doc.Enabled = true;
                cbo_tipo_doc.SelectedIndex = -1;
                TXT_COD.Enabled = false;
                TXT_DESC.Enabled = false;
                txt_doc_per.Enabled = false;
                cbo_moneda.Enabled = false;
                txt_nro_doc.Visible = false;
                cbo_ni.Visible = true;
                txt_numero.Visible = true;
                dtp_doc.Enabled = true;
                txt_TC.Enabled = true;
                //dtp_doc.Value = DateTime.Now;
                txt_dia.Enabled = true;
                NRO_PED = DGW_NOTA_PTE[4, DGW_NOTA_PTE.CurrentRow.Index].Value.ToString();
                NRO_CONTRATO = DGW_NOTA_PTE[5, DGW_NOTA_PTE.CurrentRow.Index].Value.ToString();
                CODIGO_VEND = DGW_NOTA_PTE[6, DGW_NOTA_PTE.CurrentRow.Index].Value.ToString();
                COD_MOV_0 = DGW_NOTA_PTE.CurrentRow.Cells["COD_MOV"].Value.ToString();
                ST_TIP_VTA = "PU";//Factura de Precio Unitario
                //FORMAPAGO(NRO_PED)
                TIPO_ORIGEN = "C";
                GRID = "1";
                //AGREGADO POR CAMBIO DE IGV
                //Call Igv(FECHA_GRAL)
                OBTENER_TIPO_CAMBIO();
                CARGAR_DETALLES_PEDIDO(cbo_sucursal.SelectedValue.ToString(),
                    cbo_clase.SelectedValue.ToString(), TXT_COD.Text, NRO_PED,
                    DGW_NOTA_PTE[15, DGW_NOTA_PTE.CurrentRow.Index].Value.ToString(),
                    DGW_NOTA_PTE[16, DGW_NOTA_PTE.CurrentRow.Index].Value.ToString(), 1);//trae los que no tiene valor referencial
                //ofr.DGW_PED.Rows.Add(NRO_PED)
                TabControl1.SelectedTab = TabPage2;
                ops = false;
                HALLAR_TOTAL_OC(ops);
                cbo_tipo_doc.Focus();
                COD_REF = "";
                NRO_REF = "";
                FECHA_REF = DateTime.Now;
                cbo_tipo_doc.SelectedIndex = 3;
                cbo_ni.SelectedIndex = 0;
                txt_nro_doc.Text = HALLAR_NRO_DOC(cbo_ni.SelectedValue.ToString(), cbo_tipo_doc.SelectedValue.ToString()).PadLeft(7, '0');
            }

        }
        private void OBTENER_TIPO_CAMBIO()
        {
            //string cod_mon = cbo_moneda.SelectedValue.ToString();
            txt_TC.Text = helBLL.obtenerTipoCambioBLL(dtp_doc.Value.Year.ToString(), HelpersBLL.OBTIENE_CODIGO(2, dtp_doc.Value.Month.ToString()),
                HelpersBLL.OBTIENE_CODIGO(2, dtp_doc.Value.Day.ToString()), "D");
        }
        private void HALLAR_TOTAL_OC(bool op)
        {
            decimal impor = 0, dscto = 0, igv = 0, neto = 0, total = 0, tot_val_ref = 0;
            foreach (DataGridViewRow rw in DGW_DET.Rows)
            {
                //impor = impor + Convert.ToDecimal(rw.Cells[7].Value);
                //dscto = dscto + Convert.ToDecimal(rw.Cells[12].Value);
                //igv = igv + Convert.ToDecimal(rw.Cells[11].Value);
                //neto = impor - dscto;
                //total = neto + igv;
                if (Convert.ToBoolean(rw.Cells["ok"].Value) == true)
                {
                    if (rw.Cells["valor_referencial"].Value.ToString() == "0")
                    {
                        impor = impor + Convert.ToDecimal(rw.Cells[6].Value);
                        dscto = dscto + Convert.ToDecimal(rw.Cells[12].Value);
                        //if(op)//solo si es valor referencial entra
                    }
                    else if (rw.Cells["valor_referencial"].Value.ToString() == "1")
                        tot_val_ref = tot_val_ref + Convert.ToDecimal(rw.Cells["importe"].Value);
                }
            }
            total = impor;
            //neto = total / 1.18M;
            //neto = total / (1 + Math.Round((igv0 / 100), 2));
            neto = total;
            igv = total - neto;
            //if (op)
            if (tot_val_ref > 0)
                txt_tot_val_ref.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(tot_val_ref.ToString());
            else
                txt_tot_val_ref.Text = "0";

            //TXT_TB.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(neto.ToString());
            //TXT_TD.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(dscto.ToString());
            //TXT_TN.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(neto.ToString());
            //TXT_TIGV.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(igv.ToString());
            //TXT_TT.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(impor.ToString());
            TXT_TB.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES((impor - igv).ToString());
            TXT_TD.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(dscto.ToString());
            TXT_TN.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES((impor - igv).ToString());
            TXT_TIGV.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(igv.ToString());
            TXT_TT.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES((impor - dscto).ToString());
        }
        private void CARGAR_DETALLES_PEDIDO(string COD_SUCURSAL, string COD_CLASE, string COD_PER, string NRO_PEDIDO, string AÑO0, string MES0, int j)
        {
            contratoDetalleBLL ccdBLL = new contratoDetalleBLL();
            contratoDetalleTo ccdTo = new contratoDetalleTo();
            DataTable dt = null;
            ccdTo.COD_SUCURSAL = COD_SUCURSAL;
            ccdTo.COD_CLASE = COD_CLASE;
            ccdTo.COD_PER = COD_PER;
            ccdTo.NRO_DOC = NRO_PEDIDO;
            ccdTo.FE_AÑO = AÑO0;
            ccdTo.FE_MES = MES0;
            if (j == 1)
                dt = ccdBLL.CARGAR_PEDIDO_DETALLES_PTE_BLL(ccdTo);//los que tienen NO valor referencial
            else if (j == 3)
                dt = ccdBLL.CARGAR_PEDIDO_DETALLES_PTE3_BLL(ccdTo);//los quen tienen valor referencial

            if (dt.Rows.Count > 0)
            {
                int i = 0;
                DGW_DET.Rows.Clear();
                foreach (DataRow rw in dt.Rows)
                {
                    int rowId = DGW_DET.Rows.Add();
                    DataGridViewRow row = DGW_DET.Rows[rowId];
                    row.Cells["item"].Value = obtieneCodigo(i);//rw["ITEM"].ToString();//obtieneCodigo(i);
                    row.Cells["npedido"].Value = NRO_PEDIDO;
                    row.Cells["cod_articulo"].Value = rw["COD_ARTICULO"].ToString();
                    row.Cells["desc_articulo"].Value = rw["DESC_ARTICULO"].ToString();
                    row.Cells["cant"].Value = rw["CANTIDAD_PED"].ToString();
                    row.Cells["preuni"].Value = rw["precio_unit"].ToString();
                    row.Cells["importe"].Value = rw["VALOR_COMPRA"].ToString();
                    row.Cells["ok"].Value = rw["estado"].ToString();
                    row.Cells["pigv"].Value = rw["POR_IGV"].ToString();
                    row.Cells["pdscto"].Value = rw["POR_DSCTO"].ToString();
                    row.Cells["vigv"].Value = rw["VALOR_IGV"].ToString();
                    row.Cells["vdscto"].Value = rw["VALOR_DSCTO"].ToString();
                    row.Cells["aigv"].Value = "0.00";
                    row.Cells["abi"].Value = "0.00";
                    row.Cells["dh"].Value = rw["COD_D_H"].ToString();
                    row.Cells["nro_item"].Value = rw["item"].ToString();
                    row.Cells["obs"].Value = rw["OBSERVACION"].ToString();
                    row.Cells["cod_vend"].Value = rw["COD_VENDEDOR"].ToString();
                    row.Cells["cod_pre_vta"].Value = rw["ST_VALOR_REFERENCIAL"].ToString() == "1" ? "VALOR REFERENCIAL" : "PRECIO UNITARIO";
                    //row.Cells["valor_referencial"].Value = rw["PRECIO_UNITARIO"].ToString();
                    row.Cells["valor_referencial"].Value = rw["ST_VALOR_REFERENCIAL"].ToString();
                    row.Cells["COD_TIPO_AFEC_IGV_FE"].Value = j == 1 ? "30" : "31";
                    i++;
                }
            }
        }
        private void CARGAR_DETALLES_GUIA2(string NRO_DOC_INV, string COD_SUCURSAL,
            string COD_CLASE, string COD_PER, string NRO_PEDIDO,
            string AÑO0,
            string MES0, string CODIGO_VEND, string COD_KIT)
        {
            inventariosBLL ccdBLL = new inventariosBLL();
            inventariosTo ccdTo = new inventariosTo();
            DataTable dt = null;
            ccdTo.COD_SUCURSAL = COD_SUCURSAL;
            ccdTo.COD_CLASE = COD_CLASE;
            ccdTo.COD_PER = COD_PER;
            ccdTo.NRO_DOC_INV = NRO_DOC_INV;
            ccdTo.FE_AÑO = AÑO0;
            ccdTo.FE_MES = MES0;//hay que poner COD_KIT y ST_SUSPENDIDO='0'
            ccdTo.COD_KIT = COD_KIT;
            dt = ccdBLL.CARGAR_GUIA_DETALLES_PTE2_BLL(ccdTo);

            if (dt.Rows.Count > 0)
            {
                int i = 0;
                DGW_DET.Rows.Clear();
                foreach (DataRow rw in dt.Rows)
                {
                    int rowId = DGW_DET.Rows.Add();
                    DataGridViewRow row = DGW_DET.Rows[rowId];
                    row.Cells["item"].Value = obtieneCodigo(i);// rw["ITEM"].ToString();//obtieneCodigo(i);
                    row.Cells["npedido"].Value = "";
                    row.Cells["cod_articulo"].Value = rw["COD_ARTICULO"].ToString();
                    row.Cells["desc_articulo"].Value = rw["DESC_ARTICULO"].ToString();
                    row.Cells["cant"].Value = rw["CANTIDAD"].ToString();
                    row.Cells["preuni"].Value = rw["precio_unitario"].ToString();
                    row.Cells["importe"].Value = rw["VALOR_COMPRA"].ToString();
                    row.Cells["ok"].Value = "True";
                    row.Cells["pigv"].Value = rw["POR_IGV"].ToString();
                    row.Cells["pdscto"].Value = rw["POR_DSCTO"].ToString();
                    row.Cells["vigv"].Value = rw["VALOR_IGV"].ToString();
                    row.Cells["vdscto"].Value = rw["VALOR_DSCTO"].ToString();
                    row.Cells["aigv"].Value = "0.00";
                    row.Cells["abi"].Value = "0.00";
                    row.Cells["dh"].Value = rw["COD_D_H"].ToString();
                    row.Cells["nro_item"].Value = rw["ITEM"].ToString();
                    row.Cells["obs"].Value = rw["OBSERVACION"].ToString();
                    row.Cells["cod_vend"].Value = CODIGO_VEND;
                    row.Cells["nro_ing"].Value = NRO_PEDIDO;//NRO_INGRESO
                    row.Cells["cod_pre_vta"].Value = rw["ST_VALOR_REFERENCIAL"].ToString() == "1" ? "VALOR REFERENCIAL" : "PRECIO UNITARIO";
                    //row.Cells["valor_referencial"].Value = rw["PRECIO_UNITARIO"].ToString();
                    row.Cells["valor_referencial"].Value = rw["ST_VALOR_REFERENCIAL"].ToString();
                    row.Cells["COD_TIPO_AFEC_IGV_FE"].Value = "30";
                    i++;
                }
            }
        }
        private void CARGAR_DETALLES_GUIA3(string NRO_DOC_INV, string COD_SUCURSAL, string COD_CLASE, string COD_PER, string NRO_PEDIDO,
            string AÑO0, string MES0, string CODIGO_VEND, string COD_KIT)
        {
            inventariosBLL ccdBLL = new inventariosBLL();
            inventariosTo ccdTo = new inventariosTo();
            DataTable dt = null;
            ccdTo.COD_SUCURSAL = COD_SUCURSAL;
            ccdTo.COD_CLASE = COD_CLASE;
            ccdTo.COD_PER = COD_PER;
            ccdTo.NRO_DOC_INV = NRO_DOC_INV;
            ccdTo.FE_AÑO = AÑO0;
            ccdTo.FE_MES = MES0;
            ccdTo.COD_KIT = COD_KIT;
            dt = ccdBLL.CARGAR_GUIA_DETALLES_PTE3_BLL(ccdTo);

            if (dt.Rows.Count > 0)
            {
                int i = 0;
                DGW_DET.Rows.Clear();
                foreach (DataRow rw in dt.Rows)
                {
                    int rowId = DGW_DET.Rows.Add();
                    DataGridViewRow row = DGW_DET.Rows[rowId];
                    row.Cells["item"].Value = obtieneCodigo(i);// rw["ITEM"].ToString();//obtieneCodigo(i);
                    row.Cells["npedido"].Value = "";
                    row.Cells["cod_articulo"].Value = rw["COD_ARTICULO"].ToString();
                    row.Cells["desc_articulo"].Value = rw["DESC_ARTICULO"].ToString();
                    row.Cells["cant"].Value = rw["CANTIDAD"].ToString();
                    row.Cells["preuni"].Value = rw["precio_unitario"].ToString();
                    row.Cells["importe"].Value = rw["VALOR_COMPRA"].ToString();
                    row.Cells["ok"].Value = "True";
                    row.Cells["pigv"].Value = rw["POR_IGV"].ToString();
                    row.Cells["pdscto"].Value = rw["POR_DSCTO"].ToString();
                    row.Cells["vigv"].Value = rw["VALOR_IGV"].ToString();
                    row.Cells["vdscto"].Value = rw["VALOR_DSCTO"].ToString();
                    row.Cells["aigv"].Value = "0.00";
                    row.Cells["abi"].Value = "0.00";
                    row.Cells["dh"].Value = rw["COD_D_H"].ToString();
                    row.Cells["nro_item"].Value = rw["ITEM"].ToString();
                    row.Cells["obs"].Value = rw["OBSERVACION"].ToString();
                    row.Cells["cod_vend"].Value = CODIGO_VEND;
                    row.Cells["nro_ing"].Value = NRO_PEDIDO;//NRO_INGRESO
                    row.Cells["cod_pre_vta"].Value = rw["ST_VALOR_REFERENCIAL"].ToString() == "1" ? "VALOR REFERENCIAL" : "PRECIO UNITARIO";
                    //row.Cells["valor_referencial"].Value = rw["PRECIO_UNITARIO"].ToString();
                    row.Cells["valor_referencial"].Value = rw["ST_VALOR_REFERENCIAL"].ToString();
                    row.Cells["COD_TIPO_AFEC_IGV_FE"].Value = "31";
                    i++;
                }
            }
        }
        private string obtieneCodigo(int it)
        {
            string ite = (it + 1).ToString();
            return ite.PadLeft(2, '0');
        }
        private string obtenerPrefijoDocumentoElectronico(string op)
        {
            string val = "";
            if (GRID == "1" && (op == "01" || op == "08"))//factura
                val = "F";
            else if (GRID == "1" && (op == "03" || op == "08"))//boleta
                val = "B";
            else if (GRID == "2" && (op == "01" || op == "08"))//FACTURA
                val = "F";
            else if (GRID == "2" && (op == "03" || op == "08"))//boleta
                val = "B";
            if (GRID == "3")
                val = dgw_ingreso.CurrentRow.Cells["TIPO_ORI"].Value.ToString();
            else if (GRID == "4")
                val = dgw_ingreso_obs.CurrentRow.Cells["TIPO_ORI3"].Value.ToString();
            return val;
        }
        private void BTN_GRABAR_Click(object sender, EventArgs e)
        {
            //string nro_doc_precio="",nro_doc_obsequio="";
            nro_doc_precio = obtenerPrefijoDocumentoElectronico(cbo_tipo_doc.SelectedValue.ToString()) + cbo_ni.Text + "-" + txt_numero.Text.PadLeft(7, '0');
            if (!validaGrabar())
                return;
            DialogResult rs;
            if (GRID == "1" || GRID == "3")
            {
                rs = MessageBox.Show("¿ Esta seguro de hacer un nuevo Documento de Facturación " + nro_doc_precio + " ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                fvtaTo.NRO_DOC = nro_doc_precio;
                fvtaTo.SERIE2 = cbo_ni.SelectedValue.ToString();
            }
            else
            {
                rs = DialogResult.Yes;
                if (nro_doc_obsequio == "")
                {
                    rs = MessageBox.Show("¿ Esta seguro de hacer un nuevo Documento de Facturación " + nro_doc_precio + " ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    fvtaTo.NRO_DOC = nro_doc_precio;
                    fvtaTo.SERIE2 = serie_obsequios;
                }
                else
                {
                    fvtaTo.NRO_DOC = nro_doc_obsequio;
                    fvtaTo.SERIE2 = serie_obsequios;
                }
            }

            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                string COD_REF = ""; string NRO_REF = ""; decimal TIPO_CAMBIO = 0;
                string FORMA_PAGO = ""; int NRO_DIAS = 0; string CONDICION_VENTA = "";
                if (GRID == "3")
                {
                    COD_REF = dgw_ingreso.CurrentRow.Cells["COD_DOCUMENTO"].Value.ToString();
                    NRO_REF = dgw_ingreso.CurrentRow.Cells["NRO_DOCUMENTO"].Value.ToString();
                    TIPO_CAMBIO = Convert.ToDecimal(dgw_ingreso.CurrentRow.Cells["TIPO_CAMBIO"].Value);
                    FORMA_PAGO = dgw_ingreso.CurrentRow.Cells["FORMA_PAGO1"].Value.ToString();
                    NRO_DIAS = dgw_ingreso.CurrentRow.Cells["NRO_DIAS1"].Value.ToString() == "" ? 0 : Convert.ToInt32(dgw_ingreso.CurrentRow.Cells["NRO_DIAS1"].Value);
                    CONDICION_VENTA = dgw_ingreso.CurrentRow.Cells["CONDICION_VENTA1"].Value.ToString();
                }
                else if (GRID == "4")
                {
                    COD_REF = dgw_ingreso_obs.CurrentRow.Cells["COD_DOCUMENTO3"].Value.ToString();
                    NRO_REF = dgw_ingreso_obs.CurrentRow.Cells["NRO_DOCUMENTO3"].Value.ToString();
                    TIPO_CAMBIO = Convert.ToDecimal(dgw_ingreso_obs.CurrentRow.Cells["TIPO_CAMBIO3"].Value);
                    FORMA_PAGO = dgw_ingreso_obs.CurrentRow.Cells["FORMA_PAGO3"].Value.ToString();
                    NRO_DIAS = dgw_ingreso_obs.CurrentRow.Cells["NRO_DIAS3"].Value.ToString() == "" ? 0 : Convert.ToInt32(dgw_ingreso_obs.CurrentRow.Cells["NRO_DIAS3"].Value);
                    CONDICION_VENTA = dgw_ingreso_obs.CurrentRow.Cells["CONDICION_VENTA3"].Value.ToString();
                }
                else
                {
                    COD_REF = "";
                    NRO_REF = "";
                    OBTENER_TIPO_CAMBIO();
                    TIPO_CAMBIO = Convert.ToDecimal(txt_TC.Text);
                    FORMA_PAGO = "";
                    NRO_DIAS = 0;
                    CONDICION_VENTA = "";
                }
                fvtaTo.COD_SUCURSAL = cbo_sucursal.SelectedValue.ToString();
                fvtaTo.COD_CLASE = cbo_clase.SelectedValue.ToString();
                fvtaTo.COD_DOC = cbo_tipo_doc.SelectedValue.ToString();
                //fvtaTo.NRO_DOC = cbo_ni.Text + "-" + txt_numero.Text.PadLeft(7,'0');
                //fvtaTo.NRO_DOC = nro_documento;//obtenerPrefijoDocumentoElectronico(cbo_tipo_doc.SelectedValue.ToString()) + cbo_ni.Text + "-" + txt_numero.Text.PadLeft(7,'0');
                fvtaTo.COD_PER = TXT_COD.Text.Trim();
                fvtaTo.FE_AÑO = AÑO;
                fvtaTo.FE_MES = MES;
                fvtaTo.NRO_DOC_PER = txt_doc_per.Text.Trim();
                fvtaTo.FECHA_DOC = dtp_doc.Value;
                DTP_VEN.Value = dtp_doc.Value.AddDays(int.Parse(txt_dia.Text));
                fvtaTo.FECHA_VEN = DTP_VEN.Value;
                fvtaTo.COD_MONEDA = cbo_moneda.SelectedValue.ToString();
                fvtaTo.TIPO_CAMBIO = txt_TC.Text == "" ? 0 : Convert.ToDecimal(txt_TC.Text);
                fvtaTo.OBSERVACION = txt_obs.Text;
                fvtaTo.TIPO_ORIGEN = TIPO_ORIGEN;//C O D
                fvtaTo.STATUS_PV = "1";
                fvtaTo.COD_D_H = COD_DH_GRAL;
                fvtaTo.STATUS_CIERRE = "0";
                fvtaTo.NRO_PEDIDO = NRO_PED;
                fvtaTo.NRO_PRESUPUESTO = NRO_CONTRATO;
                fvtaTo.COD_VENDEDOR = CODIGO_VEND;
                fvtaTo.COD_USU_CREA = COD_USU;
                fvtaTo.FECHA_CREA = DateTime.Now;
                fvtaTo.FECHA_REF = dtp_doc.Value;
                //fvtaTo.SERIE2 = cbo_ni.SelectedValue.ToString();
                fvtaTo.ST_TIP_VTA = ST_TIP_VTA;
                fvtaTo.NOMBRE_PC = NOMBRE_PC;
                fvtaTo.COD_MOT_DEV = TIPO_ORIGEN == "D" ? MOTIVO_DEV : "";
                fvtaTo.COD_MOV = COD_MOV_0;
                fvtaTo.TIPO_FACT = "I";
                fvtaTo.VALOR_DETRACCION = 0;
                fvtaTo.POR_DETRACCION = 0;
                fvtaTo.STATUS_FE = "1";
                fvtaTo.STATUS_ENVIO_FE = "0";
                fvtaTo.TIPO_OPERACION_FE = cboTipoOperacionFacturaElectronica.SelectedValue.ToString();
                fvtaTo.STATUS_BAJA_FE = "0";
                fvtaTo.COD_REF = COD_REF;
                fvtaTo.NRO_REF = NRO_REF;
                fvtaTo.TIPO_CAMBIO = TIPO_CAMBIO;
                string nro_ing = "";
                if (GRID == "3")
                    nro_ing = TIPO_ORIGEN == "D" ? dgw_ingreso[4, dgw_ingreso.CurrentRow.Index].Value.ToString() : "";
                else if (GRID == "4")
                    nro_ing = TIPO_ORIGEN == "D" ? dgw_ingreso_obs[4, dgw_ingreso_obs.CurrentRow.Index].Value.ToString() : "";
                fvtaTo.FORMA_PAGO = FORMA_PAGO;
                fvtaTo.NRO_DIAS = NRO_DIAS;
                fvtaTo.CONDICION_VENTA = CONDICION_VENTA;
                DT00.Rows.Clear();
                int num = DGW_DET.Rows.Count - 1;
                int num3 = num;
                int i = 0;
                while (i <= num3)
                {
                    if (Convert.ToBoolean(DGW_DET[7, i].Value))
                    {
                        decimal valor_compra, valor_igv, valor_referencial, valor_igv_ref;
                        valor_compra = DGW_DET.Rows[i].Cells["valor_referencial"].Value.ToString() == "0" ? Convert.ToDecimal(DGW_DET[6, i].Value) : 0;
                        valor_igv = DGW_DET.Rows[i].Cells["valor_referencial"].Value.ToString() == "0" ? Convert.ToDecimal(DGW_DET.Rows[i].Cells["vigv"].Value) : 0;
                        valor_referencial = DGW_DET.Rows[i].Cells["valor_referencial"].Value.ToString() == "1" ? Convert.ToDecimal(DGW_DET[6, i].Value) : 0;
                        valor_igv_ref = DGW_DET.Rows[i].Cells["valor_referencial"].Value.ToString() == "1" ? Convert.ToDecimal(DGW_DET.Rows[i].Cells["vigv"].Value) : 0;

                        DT00.Rows.Add(cbo_sucursal.SelectedValue.ToString(), cbo_clase.SelectedValue.ToString(), cbo_tipo_doc.SelectedValue.ToString(), cbo_ni.Text + "-" + txt_numero.Text.PadLeft(7, '0'),
                        TXT_COD.Text.Trim(), AÑO, MES, DGW_DET[0, i].Value.ToString(), "", "", DGW_DET[1, i].Value.ToString(), DGW_DET[2, i].Value.ToString(),
                        Convert.ToDecimal(DGW_DET[4, i].Value), DGW_DET[16, i].Value.ToString(), cbo_moneda.SelectedValue.ToString(),
                        Convert.ToDecimal(DGW_DET[5, i].Value), valor_compra, DGW_DET[8, i].Value.ToString(), Convert.ToDecimal(DGW_DET[9, i].Value),
                        DGW_DET[21, i].Value.ToString() == "PRECIO UNITARIO" ? "0" : "1", valor_igv,//8
                        DGW_DET.Rows[i].Cells["vdscto"].Value.ToString(),//Convert.ToDecimal(DGW_DET[8, i].Value) * 0.01M * Convert.ToDecimal(DGW_DET[10, i].Value),
                        0, 0, DGW_DET[17, i].Value.ToString(), DGW_DET[18, i].Value.ToString(), NOMBRE_PC, "", "A",
                        nro_ing, valor_referencial, valor_igv_ref,
                        DGW_DET[21, i].Value.ToString() == "PRECIO UNITARIO" ? "01" : "02",
                        DGW_DET.Rows[i].Cells["COD_TIPO_AFEC_IGV_FE"].Value.ToString());
                    }
                    i++;
                }
                //DGW_DET.Rows[i].Cells["vdscto"].Value.ToString(), DGW_DET[17, i].Value.ToString()
                if (!fvtaBLL.adicionaFacturacionVentaBLL(fvtaTo, DT00, ref errMensaje))
                {
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (!helBLL.ELIMINAR_TEMPORAL("FACT_VTA", NOMBRE_PC, ref errMensaje))
                        MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    //---------------ESTO HAY QUE VOLVER A DESCOMENTAR, LO PIDIO JORGE RINCON
                    MessageBox.Show("Se creó correctamente el Documento de Facturación !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //-------------------------------------------------------------------------------

                    DATAGRID();
                    CARGAR_DOC_PENDIENTES();
                    Panel1.Visible = true;
                    BTN_GRABAR.Enabled = false;

                    if (GRID == "1")
                    {
                        //string nro_documento = obtenerPrefijoDocumentoElectronico(cbo_tipo_doc.SelectedValue.ToString()) + cbo_ni.Text + "-" + txt_numero.Text.PadLeft(7, '0');
                        nro_doc_obsequio = obtenerPrefijoDocumentoElectronico(cbo_tipo_doc.SelectedValue.ToString()) + serie_obsequios + "-" + HALLAR_NRO_DOC(serie_obsequios, cbo_tipo_doc.SelectedValue.ToString()).PadLeft(7, '0');

                        //---------------ESTO HAY QUE VOLVER A DESCOMENTAR, LO PIDIO JORGE RINCON
                        DialogResult rs1 = MessageBox.Show("¿ Desea hacer el Documento de Obsequios " + nro_doc_obsequio + " ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        //----------------------------------------------------------------------------------

                        //DialogResult rs1 = DialogResult.Yes;--volver a poner descomentado para hacer ambas facturas a la vez
                        if (rs1 == DialogResult.Yes)
                        {
                            FOCO_NUEVO_REG_CONTRATO();
                            TabControl1.SelectedTab = TabPage3;
                            TabControl2.SelectedTab = tabPage4;
                            btn_Obsequios_Click(sender, e);
                            cbo_tipo_doc.SelectedValue = fvtaTo.COD_DOC;
                            dtp_doc.Value = fvtaTo.FECHA_DOC;
                            GRID = "2";
                            BTN_GRABAR_Click(sender, e);
                        }
                        else
                        {
                            btn_Imprimir.Enabled = true;
                            btn_Imprimir.Focus();
                        }
                    }
                    else if (GRID == "2")
                    {
                        TabControl1.SelectedTab = TabPage1;
                    }
                    else if (GRID == "3")
                    {
                        DialogResult rs2 = MessageBox.Show("¿ Desea hacer el Documento de Obsequios ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (rs2 == DialogResult.Yes)
                        {
                            FOCO_NUEVO_REG_DEVOLUCION();
                            TabControl1.SelectedTab = TabPage3;
                            TabControl2.SelectedTab = tabPage6;
                            btn_Dev_Obsequios_Click(sender, e);
                            cbo_tipo_doc.SelectedValue = fvtaTo.COD_DOC;
                            dtp_doc.Value = fvtaTo.FECHA_DOC;
                            GRID = "4";
                            BTN_GRABAR_Click(sender, e);
                        }
                        else
                        {
                            btn_Imprimir.Enabled = true;
                            btn_Imprimir.Focus();
                        }
                    }
                    else if (GRID == "4")
                    {
                        TabControl1.SelectedTab = TabPage1;
                    }
                    else
                    {
                        btn_Imprimir.Enabled = true;
                        btn_Imprimir.Focus();
                    }
                }
            }

        }
        private void FOCO_NUEVO_REG_CONTRATO()
        {
            int i, cont;
            cont = DGW_OBSEQ.Rows.Count - 1;
            for (i = 0; i <= cont; i++)
            {
                if (NRO_CONTRATO == DGW_OBSEQ.Rows[i].Cells["NRO_PRESUPUESTO0"].Value.ToString())
                {
                    DGW_OBSEQ.CurrentCell = DGW_OBSEQ.Rows[i].Cells["NRO_PRESUPUESTO0"];
                    break;
                }
            }
        }
        private void FOCO_NUEVO_REG_DEVOLUCION()
        {
            int i, cont;
            cont = dgw_ingreso_obs.Rows.Count - 1;
            for (i = 0; i <= cont; i++)
            {
                if (NRO_INV == dgw_ingreso_obs.Rows[i].Cells["NRO_DOC_INV3"].Value.ToString())
                {
                    DGW_OBSEQ.CurrentCell = dgw_ingreso_obs.Rows[i].Cells["NRO_DOC_INV3"];
                    break;
                }
            }
        }
        public bool validaGrabar()
        {
            bool result = true;
            string errMensaje = "";
            bool val = false;
            fvtaTo.NRO_DOC = nro_doc_precio;
            if (!fvtaBLL.validaExisteNroDocumentoFacturacionBLL(fvtaTo, ref val, ref errMensaje))
            {
                MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return result = false;
            }
            else
            {
                if (val)
                {
                    MessageBox.Show("Nro de Documento ya existe !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txt_numero.Focus();
                    return result = false;
                }
            }
            if (cbo_tipo_doc.SelectedIndex <= -1)
            {
                MessageBox.Show("Elija el Documento !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_tipo_doc.Focus();
                return result = false;
            }
            if (cbo_sucursal.SelectedIndex <= -1)
            {
                MessageBox.Show("Elija la Sucursal !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_sucursal.Focus();
                return result = false;
            }
            if (txt_nro_doc.Text.Trim() == "")
            {
                MessageBox.Show("Inserte el Nº de Documento !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_tipo_doc.Focus();
                return result = false;
            }
            if (cbo_clase.SelectedIndex <= -1)
            {
                MessageBox.Show("Elija la Clase de Articulo !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_clase.Focus();
                return result = false;
            }
            if (TXT_COD.Text.Trim() == "")
            {
                MessageBox.Show("Elija el Proveedor !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TXT_COD.Focus();
                return result = false;
            }
            if (cbo_moneda.SelectedIndex <= -1)
            {
                MessageBox.Show("Elija la Moneda !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_moneda.Focus();
                return result = false;
            }
            if (!(dtp_doc.Value.Date <= FECHA_GRAL.Date && dtp_doc.Value.Date >= FECHA_INI.Date))
            {
                MessageBox.Show("La Fecha fuera del rango !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtp_doc.Focus();
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
        private void btn_cargo_Click(object sender, EventArgs e)
        {
            //TabControl1.SelectedTab = TabPage7;
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            TabControl1.SelectedTab = TabPage1;
            rbnTodos.Checked = true;
            rbnTodosObs.Checked = true;
            btn_nuevo.Focus();
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
            iFactVta.CoSucursal = cbo_sucursal.SelectedValue.ToString();
            iFactVta.CodClase = cbo_clase.SelectedValue.ToString();
            iFactVta.CodDoc = cbo_tipo_doc.SelectedValue.ToString();
            if (BOTON == "NUEVO")
                iFactVta.NroDoc = obtenerPrefijoDocumentoElectronico(cbo_tipo_doc.SelectedValue.ToString()) + cbo_ni.Text + "-" + txt_numero.Text.PadLeft(7, '0');
            else if (BOTON == "MODIFICAR")
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

        private void cbo_moneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_moneda.SelectedValue != null)
            {
                if (cbo_moneda.SelectedIndex > -1)
                {
                    tcpTo.Año = dtp_doc.Value.Year.ToString();
                    tcpTo.Mes = dtp_doc.Value.Month.ToString("MM"); ;
                    tcpTo.Dia = dtp_doc.Value.Day.ToString("dd");
                    tcpTo.Cod_Moneda = cbo_moneda.SelectedValue.ToString();

                }
            }
        }

        private void cbo_tipo_doc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_tipo_doc.SelectedValue != null)
            {
                if (cbo_sucursal.SelectedValue != null)
                {
                    if (cbo_tipo_doc.SelectedIndex > -1)
                    {
                        cbo_ni.Enabled = true;
                        txt_numero.ReadOnly = false;
                        //COD_DOC = obj.cod_doc(cbo_tipo_doc.Text);
                        CARGAR_NRO_DOC(cbo_tipo_doc.SelectedValue.ToString());
                        COD_DH_GRAL = helBLL.COD_D_H(cbo_tipo_doc.SelectedValue.ToString());
                        //ValidaTagPage();
                    }
                }
            }
        }
        private void CARGAR_NRO_DOC(string COD_DOC)
        {
            sdcTo.COD_SUCURSAL = cbo_sucursal.SelectedValue.ToString();
            sdcTo.COD_DOC = cbo_tipo_doc.SelectedValue.ToString();
            cbo_ni.ValueMember = "SERIE";
            cbo_ni.DisplayMember = "SERIE";
            cbo_ni.DataSource = sdcBLL.obtenerSerieDocumentoparaFacturacionBLL(sdcTo);
        }
        private void cbo_ni_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_ni.SelectedValue != null)
            {
                if (cbo_ni.SelectedIndex > -1)
                {
                    txt_numero.Text = HALLAR_NRO_DOC(cbo_ni.Text, cbo_tipo_doc.SelectedValue.ToString());
                    txt_nro_doc.Text = (cbo_ni.Text + "-" + txt_numero.Text.PadLeft(7, '0'));
                }
            }
        }
        public string HALLAR_NRO_DOC(string serie, string cod_doc)
        {
            string num = "";
            sdcTo.COD_SUCURSAL = cbo_sucursal.SelectedValue.ToString();
            sdcTo.SERIE = serie;
            sdcTo.COD_DOC = cbo_tipo_doc.SelectedValue.ToString();
            return num = sdcBLL.obtenerNumeroSerieDocumentoparaFacturacionBLL(sdcTo).ToString();
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void DGW_DET_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DGW_DET.CurrentCell.ColumnIndex == 7)
            {
                if (Convert.ToBoolean(DGW_DET[7, DGW_DET.CurrentRow.Index].Value) == true)
                    DGW_DET[7, DGW_DET.CurrentRow.Index].Value = false;
                else
                    DGW_DET[7, DGW_DET.CurrentRow.Index].Value = true;
                HALLAR_TOTAL_OC(ops);
            }
        }

        private void btn_consulta_Click(object sender, EventArgs e)
        {
            BOTON = "MODIFICAR";
            LIMPIAR_CABECERA();
            BTN_GRABAR.Visible = false;
            btn_Imprimir.Enabled = true;
            TabControl1.SelectedTab = TabPage2;
            //LIMPIAR_CABECERA();
            txt_nro_doc.Visible = true;
            cbo_ni.Visible = false;
            txt_numero.Visible = false;
            GB2.Enabled = false;
            GB6.Enabled = false;
            gb_cab.Enabled = false;
            GB2.Enabled = false;
            CARGAR_DATOS();
            CARGAR_DETALLES_DGW();
            HALLAR_TOTAL_OC(ops);
            GRID = "0";
        }
        private void FOCO_CONTRATO_FACTURADO()
        {
            int i, cont;
            cont = dgw1.Rows.Count - 1;
            for (i = 0; i <= cont; i++)
            {
                if (NRO_CONTRATO == dgw1.Rows[i].Cells["NRO_PRESUPUESTO"].Value.ToString())
                {
                    dgw1.CurrentCell = dgw1.Rows[i].Cells["NRO_PRESUPUESTO"];
                    break;
                }
            }
        }

        private void CARGAR_DATOS()
        {
            cbo_ni.SelectedIndex = -1;
            //COD_SUCURSAL2 = dgw1[0, dgw1.CurrentRow.Index].Value.ToString();
            cbo_sucursal.SelectedValue = dgw1[0, dgw1.CurrentRow.Index].Value;
            //COD_CLASE1 = dgw1[2, dgw1.CurrentRow.Index].Value.ToString();
            cbo_clase.SelectedValue = dgw1[2, dgw1.CurrentRow.Index].Value;
            //COD_DOC = dgw1.Item(4, dgw1.CurrentRow.Index).Value.ToString
            cbo_tipo_doc.SelectedValue = dgw1[4, dgw1.CurrentRow.Index].Value;
            txt_nro_doc.Text = dgw1[6, dgw1.CurrentRow.Index].Value.ToString();
            TXT_COD.Text = dgw1[8, dgw1.CurrentRow.Index].Value.ToString();
            TXT_DESC.Text = dgw1[9, dgw1.CurrentRow.Index].Value.ToString();
            ops = dgw1[10, dgw1.CurrentRow.Index].Value.ToString() == "VR" ? true : false;
            txt_doc_per.Text = dgw1[11, dgw1.CurrentRow.Index].Value.ToString();
            dtp_doc.Value = Convert.ToDateTime(dgw1[12, dgw1.CurrentRow.Index].Value);
            DTP_VEN.Value = Convert.ToDateTime(dgw1[13, dgw1.CurrentRow.Index].Value);
            cbo_moneda.SelectedValue = dgw1[14, dgw1.CurrentRow.Index].Value;
            txt_TC.Text = dgw1[15, dgw1.CurrentRow.Index].Value.ToString();
            txt_obs.Text = dgw1[16, dgw1.CurrentRow.Index].Value.ToString();
            //CBO_DOC.SelectedValue = dgw1.CurrentRow.Cells[""]
        }
        private void CARGAR_DETALLES_DGW()
        {
            DGW_DET.Rows.Clear();
            dfvtaTo.COD_CLASE = dgw1[2, dgw1.CurrentRow.Index].Value.ToString();
            dfvtaTo.COD_SUCURSAL = dgw1[0, dgw1.CurrentRow.Index].Value.ToString();
            dfvtaTo.COD_PER = dgw1[8, dgw1.CurrentRow.Index].Value.ToString();
            dfvtaTo.COD_DOC = dgw1[4, dgw1.CurrentRow.Index].Value.ToString();
            dfvtaTo.NRO_DOC = dgw1[6, dgw1.CurrentRow.Index].Value.ToString();
            dfvtaTo.FE_AÑO = AÑO;
            dfvtaTo.FE_MES = MES;
            DataTable dt = dfvtaBLL.obtenerFacturacionVtaDetalleBLL(dfvtaTo);
            if (dt.Rows.Count > 0)
            {
                DGW_DET.Rows.Clear();
                foreach (DataRow rw in dt.Rows)
                {
                    int rowId = DGW_DET.Rows.Add();
                    DataGridViewRow row = DGW_DET.Rows[rowId];
                    row.Cells["item"].Value = rw["ITEM"].ToString();
                    row.Cells["npedido"].Value = rw["NRO_PEDIDO"].ToString();
                    row.Cells["cod_articulo"].Value = rw["COD_ARTICULO"].ToString();
                    row.Cells["desc_articulo"].Value = rw["DESC_ARTICULO"].ToString();
                    row.Cells["cant"].Value = rw["CANTIDAD"].ToString();
                    row.Cells["preuni"].Value = rw["precio_unitario"].ToString();
                    row.Cells["importe"].Value = dgw1.CurrentRow.Cells["ST_TIP_VTA"].Value.ToString() == "PU" ? rw["VALOR_COMPRA"].ToString() : rw["VALOR_REFERENCIAL"].ToString();
                    row.Cells["ok"].Value = rw["estado"].ToString();
                    row.Cells["pigv"].Value = rw["POR_IGV"].ToString();
                    row.Cells["pdscto"].Value = rw["POR_DSCTO"].ToString();
                    row.Cells["vigv"].Value = rw["VALOR_IGV"].ToString();
                    row.Cells["vdscto"].Value = rw["VALOR_DSCTO"].ToString();
                    row.Cells["aigv"].Value = "0.00";
                    row.Cells["abi"].Value = "0.00";
                    row.Cells["dh"].Value = rw["COD_D_H"].ToString();
                    row.Cells["nro_item"].Value = rw["NRO_ITEM"].ToString();
                    row.Cells["obs"].Value = rw["OBSERVACION"].ToString();
                    row.Cells["cod_vend"].Value = "";// rw["COD_VENDEDOR"].ToString();
                    row.Cells["nro_ing"].Value = rw["nro_ingreso"].ToString();
                    row.Cells["cod_pre_vta"].Value = dgw1.CurrentRow.Cells["ST_TIP_VTA"].Value.ToString() == "PU" ? "PRECIO UNITARIO" : "VALOR REFERENCIAL";//Convert.ToDecimal(rw["VALOR_REFERENCIAL"]) != 0 ? "VALOR REFERENCIAL" : "PRECIO UNITARIO";
                                                                                                                                                            //row.Cells["cod_pre_vta"].Value = rw["ST_VALOR_REFERENCIAL"].ToString() == "1" ? "VALOR REFERENCIAL" : "PRECIO UNITARIO";
                                                                                                                                                            //row.Cells["valor_referencial"].Value = rw["VALOR_REFERENCIAL"].ToString();
                    row.Cells["valor_referencial"].Value = rw["VALOR_REFERENCIAL"].ToString() == "0.00" ? "0" : "1";//rw["ST_VALOR_REFERENCIAL"].ToString();
                    row.Cells["COD_TIPO_AFEC_IGV_FE"].Value = dgw1.CurrentRow.Cells["ST_TIP_VTA"].Value.ToString() == "PU" ? "30" : "31";
                }
            }
        }

        private void btn_Obsequios_Click(object sender, EventArgs e)
        {
            if (DGW_OBSEQ.Rows.Count > 0)
            {
                BOTON = "NUEVO";
                BTN_GRABAR.Visible = true;
                BTN_GRABAR.Enabled = true;
                btn_Imprimir.Enabled = false;
                txt_nro_doc.Enabled = true;
                cbo_sucursal.SelectedValue = DGW_OBSEQ[0, DGW_OBSEQ.CurrentRow.Index].Value;
                cbo_clase.SelectedValue = DGW_OBSEQ[2, DGW_OBSEQ.CurrentRow.Index].Value;
                TXT_COD.Text = DGW_OBSEQ[6, DGW_OBSEQ.CurrentRow.Index].Value.ToString();
                TXT_DESC.Text = DGW_OBSEQ[7, DGW_OBSEQ.CurrentRow.Index].Value.ToString();
                txt_doc_per.Text = DGW_OBSEQ[8, DGW_OBSEQ.CurrentRow.Index].Value.ToString();
                cbo_moneda.SelectedValue = DGW_OBSEQ[12, DGW_OBSEQ.CurrentRow.Index].Value;
                txt_dia.Text = DGW_OBSEQ[16, DGW_OBSEQ.CurrentRow.Index].Value.ToString();
                DTP_VEN.Value = dtp_doc.Value.AddDays(int.Parse(txt_dia.Text));
                cbo_sucursal.Enabled = false;
                cbo_clase.Enabled = false;
                cbo_tipo_doc.Enabled = true;
                cbo_tipo_doc.SelectedIndex = -1;
                TXT_COD.Enabled = false;
                TXT_DESC.Enabled = false;
                txt_doc_per.Enabled = false;
                cbo_moneda.Enabled = false;
                txt_nro_doc.Visible = false;
                cbo_ni.Visible = true;
                txt_numero.Visible = true;
                dtp_doc.Enabled = true;
                txt_TC.Enabled = true;
                //dtp_doc.Value = DateTime.Now;
                txt_dia.Enabled = true;
                NRO_PED = DGW_OBSEQ[4, DGW_OBSEQ.CurrentRow.Index].Value.ToString();
                NRO_CONTRATO = DGW_OBSEQ[5, DGW_OBSEQ.CurrentRow.Index].Value.ToString();
                CODIGO_VEND = DGW_OBSEQ[6, DGW_OBSEQ.CurrentRow.Index].Value.ToString();
                COD_MOV_0 = DGW_OBSEQ.CurrentRow.Cells["COD_MOV1"].Value.ToString();//DGW_NOTA_PTE
                //FORMAPAGO(NRO_PED)
                TIPO_ORIGEN = "C";
                GRID = "2";
                ST_TIP_VTA = "VR";//Factura de Valor Referencial
                //AGREGADO POR CAMBIO DE IGV
                //Call Igv(FECHA_GRAL)
                OBTENER_TIPO_CAMBIO();
                CARGAR_DETALLES_PEDIDO(cbo_sucursal.SelectedValue.ToString(),
                    cbo_clase.SelectedValue.ToString(), TXT_COD.Text, NRO_PED,
                    DGW_OBSEQ[15, DGW_OBSEQ.CurrentRow.Index].Value.ToString(),
                    DGW_OBSEQ[16, DGW_OBSEQ.CurrentRow.Index].Value.ToString(), 3);
                //ofr.DGW_PED.Rows.Add(NRO_PED)
                TabControl1.SelectedTab = TabPage2;
                ops = true;
                HALLAR_TOTAL_OC(ops);
                cbo_tipo_doc.Focus();
                COD_REF = "";
                NRO_REF = "";
                FECHA_REF = DateTime.Now;
                cbo_tipo_doc.SelectedIndex = 3;//BOLETA DE VENTA, el problema es si elije FACTURA siempre para el regalo buscará BOLETA DE VENTA, hay que ponerlo como variable
                cbo_ni.SelectedIndex = 1;
                txt_nro_doc.Text = HALLAR_NRO_DOC(serie_obsequios, cbo_tipo_doc.SelectedValue.ToString()).PadLeft(7, '0');
            }

        }

        private void btn_anular_Click(object sender, EventArgs e)
        {
            if (!validaEliminarAnularFacturacionVenta())
                return;

            string errMensaje = "";
            string cod_suc = dgw1[0, dgw1.CurrentRow.Index].Value.ToString();
            string cod_cla = dgw1[2, dgw1.CurrentRow.Index].Value.ToString();
            string cod_docu = dgw1[4, dgw1.CurrentRow.Index].Value.ToString();
            string nro_docu = dgw1[6, dgw1.CurrentRow.Index].Value.ToString();
            string cod_pers = dgw1[8, dgw1.CurrentRow.Index].Value.ToString();
            string fe_mess = dgw1[12, dgw1.CurrentRow.Index].Value.ToString().Substring(3, 2);
            string fe_annio = dgw1[12, dgw1.CurrentRow.Index].Value.ToString().Substring(6, 4);
            string nro_contrato = dgw1[7, dgw1.CurrentRow.Index].Value.ToString();
            string st_valor_referencia = dgw1[10, dgw1.CurrentRow.Index].Value.ToString() == "PU" ? "0" : "1";
            string tipousu = "";
            string codigo = "";
            string obs = "";
            DialogResult rs = MessageBox.Show("¿ Esta seguro de anular el documento Nº " + nro_docu + " ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                            anularFacturaVentas(cod_suc, cod_cla, cod_docu, nro_docu, cod_pers, fe_annio, fe_mess, obs, tipousu, nro_contrato, st_valor_referencia, ref errMensaje);
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
                    anularFacturaVentas(cod_suc, cod_cla, cod_docu, nro_docu, cod_pers, fe_annio, fe_mess, obs, tipousu, nro_contrato, st_valor_referencia, ref errMensaje);
                }
                DATAGRID();
                btn_nuevo.Select();
            }
        }
        private void anularFacturaVentas(string COD_SUCURSAL, string COD_CLASE, string COD_DOC, string NRO_DOC, string COD_PER, string FE_AÑO, string FE_MES, string OBS, string TIPOUSU, string NRO_CONTRATO, string ST_VALOR_REFERENCIAL, ref string errMensaje)
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
            fvtaTo.NRO_PRESUPUESTO = NRO_CONTRATO;
            fvtaTo.ST_TIP_VTA = ST_VALOR_REFERENCIAL;

            if (!fvtaBLL.anularFacturacionCabeceraBLL(fvtaTo, ref errMensaje))
            {
                MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("El Documento se anuló correctamente !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        private bool validaEliminarAnularFacturacionVenta()
        {
            bool result = true;
            if (Convert.ToBoolean(dgw1[19, dgw1.CurrentRow.Index].Value) == true)
            {
                MessageBox.Show("El Documento ya está Anulado !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return result = false;
            }
            if (dgw1.CurrentRow.Cells["STATUS_ENVIO_FE"].Value.ToString() == "1")
            {
                MessageBox.Show("El Documento ya ha sido enviado a Sunat !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return result = false;
            }
            return result;
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (!validaEliminarAnularFacturacionVenta())
                return;

            string errMensaje = "";
            string cod_suc = dgw1[0, dgw1.CurrentRow.Index].Value.ToString();
            string cod_cla = dgw1[2, dgw1.CurrentRow.Index].Value.ToString();
            string cod_docu = dgw1[4, dgw1.CurrentRow.Index].Value.ToString();
            string nro_docu = dgw1[6, dgw1.CurrentRow.Index].Value.ToString();
            string cod_pers = dgw1[8, dgw1.CurrentRow.Index].Value.ToString();
            string fe_mess = dgw1[12, dgw1.CurrentRow.Index].Value.ToString().Substring(3, 2);
            string fe_annio = dgw1[12, dgw1.CurrentRow.Index].Value.ToString().Substring(6, 4);
            string nro_contrato = dgw1[7, dgw1.CurrentRow.Index].Value.ToString();
            string st_valor_referencia = dgw1[10, dgw1.CurrentRow.Index].Value.ToString() == "PU" ? "0" : "1";
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
                        {//poner nro_presupuesto
                            eliminarFacturaVentas(cod_suc, cod_cla, cod_docu, nro_docu, cod_pers, fe_annio, fe_mess, nro_contrato, st_valor_referencia, ref errMensaje);
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
                    eliminarFacturaVentas(cod_suc, cod_cla, cod_docu, nro_docu, cod_pers, fe_annio, fe_mess, nro_contrato, st_valor_referencia, ref errMensaje);
                }
                DATAGRID();
                btn_nuevo.Select();
            }
        }
        private void eliminarFacturaVentas(string COD_SUCURSAL, string COD_CLASE, string COD_DOC, string NRO_DOC, string COD_PER, string FE_AÑO, string FE_MES, string NRO_CONTRATO, string ST_VALOR_REFERENCIAL, ref string errMensaje)
        {
            fvtaTo.COD_SUCURSAL = COD_SUCURSAL;
            fvtaTo.COD_CLASE = COD_CLASE;
            fvtaTo.COD_DOC = COD_DOC;
            fvtaTo.NRO_DOC = NRO_DOC;
            fvtaTo.COD_PER = COD_PER;
            fvtaTo.FE_AÑO = FE_AÑO;
            fvtaTo.FE_MES = FE_MES;
            fvtaTo.NRO_PRESUPUESTO = NRO_CONTRATO;
            fvtaTo.ST_TIP_VTA = ST_VALOR_REFERENCIAL;

            if (!fvtaBLL.eliminarFacturacionCabeceraBLL(fvtaTo, ref errMensaje))
                MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show("El Documento se eliminó correctamente !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btn_nuevo2_Click(object sender, EventArgs e)
        {
            BOTON = "NUEVO";
            BTN_GRABAR.Visible = true;
            BTN_GRABAR.Enabled = true;
            btn_Imprimir.Enabled = false;
            TabControl1.SelectedTab = TabPage3;
            LIMPIAR_CABECERA();
            cbo_sucursal.Focus();
        }

        //private void chbCuotaIniCob_CheckedChanged(object sender, EventArgs e)
        //{
        //    if(chbCuotaIniCob.Checked)
        //    {
        //        try
        //        {
        //            DataTable dt = dtContratos.AsEnumerable().Where(x => (x.Field<string>("NRO_LETRA") == "001") && (x.Field<decimal>("IMP_DOC") >= 0 && x.Field<decimal>("IMP_DOC") < x.Field<decimal>("IMP_INI"))).CopyToDataTable();
        //            obtenerContratosparaFacturacion(dt);
        //            //if(dtContratos.AsEnumerable().Where(x => x.Field<decimal>("IMP_DOC") == 0).Any())
        //            //{
        //            //    DataTable dt = dtContratos.AsEnumerable().Where(x => (x.Field<string>("NRO_LETRA") == "001") && (x.Field<decimal>("IMP_DOC") >= 0 && x.Field<decimal>("IMP_DOC") < x.Field<decimal>("IMP_INI"))).CopyToDataTable();
        //            //    obtenerContratosparaFacturacion(dt);
        //            //}
        //        }
        //        catch (Exception)
        //        {
        //            MessageBox.Show("No se ha creado cuenta corriente");   
        //        }
        //    }
        //    else
        //    {
        //        obtenerContratosparaFacturacion(dtContratos);
        //    }
        //}

        //private void chbCuotaIniCob0_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chbCuotaIniCob0.Checked)
        //    {
        //        try
        //        {
        //            if (dtObsequios.AsEnumerable().Where(x => x.Field<decimal>("IMP_DOC") == 0).Any())
        //            {
        //                DataTable dt = dtObsequios.AsEnumerable().Where(x => x.Field<decimal>("IMP_DOC") == 0).CopyToDataTable();
        //                obtenerObsequiosparaFacturacion(dt);
        //            }
        //        }
        //        catch (Exception)
        //        {
        //            MessageBox.Show("No se ha creado cuenta corriente");   
        //        }
        //    }
        //    else
        //    {
        //        obtenerObsequiosparaFacturacion(dtObsequios);
        //    }
        //}

        private void btn_Dev_Obsequios_Click(object sender, EventArgs e)
        {
            if (dgw_ingreso_obs.Rows.Count > 0)
            {
                BOTON = "NUEVO";
                BTN_GRABAR.Visible = true;
                BTN_GRABAR.Enabled = true;
                btn_Imprimir.Enabled = false;
                txt_nro_doc.Enabled = true;
                cbo_sucursal.SelectedValue = dgw_ingreso_obs[0, dgw_ingreso_obs.CurrentRow.Index].Value;
                cbo_clase.SelectedValue = dgw_ingreso_obs[2, dgw_ingreso_obs.CurrentRow.Index].Value;
                TXT_COD.Text = dgw_ingreso_obs.CurrentRow.Cells["COD_PER3"].Value.ToString();//dgw_ingreso_obs[6, dgw_ingreso_obs.CurrentRow.Index].Value.ToString();
                TXT_DESC.Text = dgw_ingreso_obs.CurrentRow.Cells["DESC_PER3"].Value.ToString();//dgw_ingreso_obs[6, dgw_ingreso_obs.CurrentRow.Index].Value.ToString();
                txt_doc_per.Text = dgw_ingreso_obs.CurrentRow.Cells["nro_doc4"].Value.ToString();//dgw_ingreso_obs[7, dgw_ingreso_obs.CurrentRow.Index].Value.ToString();
                cbo_moneda.SelectedValue = dgw_ingreso_obs.CurrentRow.Cells["COD_MONEDA3"].Value.ToString(); //dgw_ingreso_obs[11, dgw_ingreso_obs.CurrentRow.Index].Value;
                txt_dia.Text = "0";
                DTP_VEN.Value = dtp_doc.Value.AddDays(int.Parse(txt_dia.Text));
                string str = dgw_ingreso_obs[4, dgw_ingreso_obs.CurrentRow.Index].Value.ToString();
                cbo_sucursal.Enabled = false;
                cbo_clase.Enabled = false;
                cbo_tipo_doc.Enabled = true;
                //cbo_tipo_doc.SelectedIndex = -1;
                TXT_COD.Enabled = false;
                TXT_DESC.Enabled = false;
                txt_doc_per.Enabled = false;
                cbo_moneda.Enabled = false;
                txt_nro_doc.Visible = false;
                cbo_ni.Visible = true;
                txt_numero.Visible = true;
                dtp_doc.Enabled = true;
                txt_TC.Enabled = true;
                //dtp_doc.Value = DateTime.Now;
                txt_dia.Enabled = true;
                NRO_PED = dgw_ingreso_obs.CurrentRow.Cells["NRO_PEDIDO3"].Value.ToString();//dgw_ingreso_obs[4, dgw_ingreso_obs.CurrentRow.Index].Value.ToString();
                NRO_CONTRATO = "";//es el NRO_PRESUPUESTO que como viene de una Nota de Ingreso al almacen en la tabla INVENTARIO no consibe este campo
                MOTIVO_DEV = dgw_ingreso_obs[16, dgw_ingreso_obs.CurrentRow.Index].Value.ToString();
                NRO_INV = dgw_ingreso_obs.CurrentRow.Cells["NRO_DOC_INV3"].Value.ToString();//dgw_ingreso_obs[4, dgw_ingreso_obs.CurrentRow.Index].Value.ToString();
                CODIGO_VEND = dgw_ingreso_obs.CurrentRow.Cells["COD_VENDEDOR3"].Value.ToString();//dgw_ingreso_obs[10, dgw_ingreso_obs.CurrentRow.Index].Value.ToString();
                COD_MOV_0 = dgw_ingreso_obs.CurrentRow.Cells["COD_MOV3"].Value.ToString();//DGW_NOTA_PTE
                ST_TIP_VTA = "VR";//Factura de Valor Referencial
                CBO_DOC.SelectedValue = dgw_ingreso_obs.CurrentRow.Cells["COD_DOCUMENTO3"].Value;
                TXT_NRO_FACT.Text = dgw_ingreso_obs.CurrentRow.Cells["NRO_DOCUMENTO3"].Value.ToString();
                DTP_FACT.Value = Convert.ToDateTime(dgw_ingreso_obs.CurrentRow.Cells["FECHA_DOC3"].Value);
                TXT_TC_REF.Text = dgw_ingreso_obs.CurrentRow.Cells["TIPO_CAMBIO3"].Value.ToString();
                //FORMAPAGO(NRO_PED)
                TIPO_ORIGEN = "D";//DEVOLUCION
                GRID = "4";
                //AGREGADO POR CAMBIO DE IGV
                //Call Igv(FECHA_GRAL)
                OBTENER_TIPO_CAMBIO();
                CARGAR_DETALLES_GUIA3(str, cbo_sucursal.SelectedValue.ToString(),
                    cbo_clase.SelectedValue.ToString(), TXT_COD.Text, NRO_PED,
                    dgw_ingreso_obs.CurrentRow.Cells["FE_AÑO3"].Value.ToString(),//dgw_ingreso_obs[13, dgw_ingreso_obs.CurrentRow.Index].Value.ToString(),
                    dgw_ingreso_obs.CurrentRow.Cells["FE_MES3"].Value.ToString(),//dgw_ingreso_obs[14, dgw_ingreso_obs.CurrentRow.Index].Value.ToString(), 
                    CODIGO_VEND,
                    dgw_ingreso_obs.CurrentRow.Cells["COD_KIT2"].Value.ToString());//trae 
                //ofr.DGW_PED.Rows.Add(NRO_PED)
                TabControl1.SelectedTab = TabPage2;
                ops = true;
                HALLAR_TOTAL_OC(ops);
                cbo_tipo_doc.Focus();
                COD_REF = "";
                NRO_REF = "";
                FECHA_REF = DateTime.Now;
                //cbo_tipo_doc.SelectedIndex = 4;//NOTA DE CREDITO
                //cbo_ni.SelectedIndex = 0;
                //txt_nro_doc.Text = HALLAR_NRO_DOC(serie_obsequios, cbo_tipo_doc.SelectedValue.ToString()).PadLeft(7, '0');
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

        private void dtp_doc_ValueChanged(object sender, EventArgs e)
        {
            OBTENER_TIPO_CAMBIO();
        }

        private void DGW_DET_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                bool incluyeCero = false;
                if (!validaCeldasGrid(e.FormattedValue.ToString(), incluyeCero))
                {
                    e.Cancel = true;
                }
                DataGridViewCell cell = DGW_DET.Rows[e.RowIndex].Cells[e.ColumnIndex];
                DGW_DET.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = string.Format("{0:###,###,##0.00}", Convert.ToDecimal(cell.Value));
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

        private void DGW_DET_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (DGW_DET.CurrentCell.ColumnIndex == 5)
            {
                DGW_DET.CurrentRow.Cells["importe"].Value = Convert.ToDecimal(DGW_DET.CurrentRow.Cells["cant"].Value) * Convert.ToDecimal(DGW_DET.CurrentRow.Cells["preuni"].Value);
                HALLAR_TOTAL_OC(ops);
            }
        }
        #region BusacadoPor
        private void txt_letra_TextChanged(object sender, EventArgs e)
        {
            int i;
            if (ch_cod.Checked)
            {
                txt_letra.Focus();
                for (i = 0; i < dgw1.Rows.Count; i++)
                {
                    if (txt_letra.TextLength <= dgw1.Rows[i].Cells[7].Value.ToString().Length)
                    {
                        if (txt_letra.Text.ToLower() == dgw1.Rows[i].Cells[7].Value.ToString().Substring(0, txt_letra.TextLength).ToLower())
                        {
                            dgw1.CurrentCell = dgw1.Rows[i].Cells[7];
                            break;
                        }
                    }

                }
            }
            else if (ch_rs.Checked)
            {
                txt_letra.Focus();
                for (i = 0; i < dgw1.Rows.Count; i++)
                {
                    if (txt_letra.TextLength <= dgw1.Rows[i].Cells["Cliente"].Value.ToString().Length)
                    {
                        if (txt_letra.Text.ToLower() == dgw1.Rows[i].Cells["Cliente"].Value.ToString().Substring(0, txt_letra.TextLength).ToLower())
                        {
                            dgw1.CurrentCell = dgw1.Rows[i].Cells["Cliente"];
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
                dgw1.Sort(dgw1.Columns[7], System.ComponentModel.ListSortDirection.Ascending);
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
                dgw1.Sort(dgw1.Columns["Cliente"], System.ComponentModel.ListSortDirection.Ascending);
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
            for (i = 0; i < dgw1.Rows.Count; i++)
            {
                for (f = 0; f <= dgw1.Rows[i].Cells["Cliente"].Value.ToString().Length - txt_letra.TextLength; f++)
                {
                    if (txt_letra.TextLength <= dgw1.Rows[i].Cells["Cliente"].Value.ToString().Length)
                    {
                        if (txt_letra.Text.ToLower() == dgw1.Rows[i].Cells["Cliente"].Value.ToString().Substring(f, txt_letra.TextLength).ToLower())
                        {
                            dgw1.CurrentCell = dgw1.Rows[i].Cells["Cliente"];
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
            for (i = fila; i < dgw1.Rows.Count; i++)
            {
                for (f = 0; f <= dgw1.Rows[i].Cells["Cliente"].Value.ToString().Length - txt_letra.TextLength; f++)
                {
                    if (txt_letra.TextLength <= dgw1.Rows[i].Cells["Cliente"].Value.ToString().Length)
                    {
                        if (txt_letra.Text.ToLower() == dgw1.Rows[i].Cells["Cliente"].Value.ToString().Substring(f, txt_letra.TextLength).ToLower())
                        {
                            dgw1.CurrentCell = dgw1.Rows[i].Cells["Cliente"];
                            fila = i + 1;
                            return;
                        }
                    }
                }
            }
            MessageBox.Show("Ya no existen más registros !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void txt_letra1_TextChanged(object sender, EventArgs e)
        {
            int i;
            if (ch_cod1.Checked)
            {
                txt_letra1.Focus();
                for (i = 0; i < DGW_NOTA_PTE.Rows.Count; i++)
                {
                    if (txt_letra1.TextLength <= DGW_NOTA_PTE.Rows[i].Cells["NRO_PRESUPUESTO"].Value.ToString().Length)
                    {
                        if (txt_letra1.Text.ToLower() == DGW_NOTA_PTE.Rows[i].Cells["NRO_PRESUPUESTO"].Value.ToString().Substring(0, txt_letra1.TextLength).ToLower())
                        {
                            DGW_NOTA_PTE.CurrentCell = DGW_NOTA_PTE.Rows[i].Cells["NRO_PRESUPUESTO"];
                            break;
                        }
                    }

                }
            }
            else if (ch_rs1.Checked)
            {
                txt_letra1.Focus();
                for (i = 0; i < DGW_NOTA_PTE.Rows.Count; i++)
                {
                    if (txt_letra1.TextLength <= DGW_NOTA_PTE.Rows[i].Cells["DESC_PER"].Value.ToString().Length)
                    {
                        if (txt_letra1.Text.ToLower() == DGW_NOTA_PTE.Rows[i].Cells["DESC_PER"].Value.ToString().Substring(0, txt_letra1.TextLength).ToLower())
                        {
                            DGW_NOTA_PTE.CurrentCell = DGW_NOTA_PTE.Rows[i].Cells["DESC_PER"];
                            break;
                        }
                    }
                }
            }
        }

        private void ch_cod1_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_cod1.Checked)
            {
                DGW_NOTA_PTE.Sort(DGW_NOTA_PTE.Columns["NRO_PRESUPUESTO"], System.ComponentModel.ListSortDirection.Ascending);
                btn_buscar1.Enabled = false;
                btn_sgt1.Enabled = false;
                txt_letra1.Clear();
                txt_letra1.Focus();
            }
        }

        private void ch_rs1_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_rs1.Checked)
            {
                DGW_NOTA_PTE.Sort(DGW_NOTA_PTE.Columns["DESC_PER"], System.ComponentModel.ListSortDirection.Ascending);
                btn_buscar1.Enabled = false;
                btn_sgt1.Enabled = false;
                txt_letra1.Clear();
                txt_letra1.Focus();
            }
        }

        private void ch_ca1_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_ca1.Checked)
            {
                btn_buscar1.Enabled = true;
                txt_letra1.Clear();
                txt_letra1.Focus();
            }
        }

        private void btn_buscar1_Click(object sender, EventArgs e)
        {
            int i, f;
            txt_letra1.Focus();
            btn_sgt1.Enabled = true;
            for (i = 0; i < DGW_NOTA_PTE.Rows.Count; i++)
            {
                for (f = 0; f <= DGW_NOTA_PTE.Rows[i].Cells["DESC_PER"].Value.ToString().Length - txt_letra1.TextLength; f++)
                {
                    if (txt_letra1.TextLength <= DGW_NOTA_PTE.Rows[i].Cells["DESC_PER"].Value.ToString().Length)
                    {
                        if (txt_letra1.Text.ToLower() == DGW_NOTA_PTE.Rows[i].Cells["DESC_PER"].Value.ToString().Substring(f, txt_letra1.TextLength).ToLower())
                        {
                            DGW_NOTA_PTE.CurrentCell = DGW_NOTA_PTE.Rows[i].Cells["DESC_PER"];
                            fila1 = i + 1;
                            return;
                        }
                    }
                }
            }
        }

        private void btn_sgt1_Click(object sender, EventArgs e)
        {
            int i, f;//antes de dar a siguiente primero se hace buscar para que lo ubique en la primera coincidencia luego se da siguiente, siguiente..., hasta encontrar el valor buscado.
            for (i = fila1; i < DGW_NOTA_PTE.Rows.Count; i++)
            {
                for (f = 0; f <= DGW_NOTA_PTE.Rows[i].Cells["DESC_PER"].Value.ToString().Length - txt_letra1.TextLength; f++)
                {
                    if (txt_letra1.TextLength <= DGW_NOTA_PTE.Rows[i].Cells["DESC_PER"].Value.ToString().Length)
                    {
                        if (txt_letra1.Text.ToLower() == DGW_NOTA_PTE.Rows[i].Cells["DESC_PER"].Value.ToString().Substring(f, txt_letra1.TextLength).ToLower())
                        {
                            DGW_NOTA_PTE.CurrentCell = DGW_NOTA_PTE.Rows[i].Cells["DESC_PER"];
                            fila1 = i + 1;
                            return;
                        }
                    }
                }
            }
            MessageBox.Show("Ya no existen más registros !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void txt_letra2_TextChanged(object sender, EventArgs e)
        {
            int i;
            if (ch_cod2.Checked)
            {
                txt_letra2.Focus();
                for (i = 0; i < DGW_OBSEQ.Rows.Count; i++)
                {
                    if (txt_letra2.TextLength <= DGW_OBSEQ.Rows[i].Cells["NRO_PRESUPUESTO0"].Value.ToString().Length)
                    {
                        if (txt_letra2.Text.ToLower() == DGW_OBSEQ.Rows[i].Cells["NRO_PRESUPUESTO0"].Value.ToString().Substring(0, txt_letra2.TextLength).ToLower())
                        {
                            DGW_OBSEQ.CurrentCell = DGW_OBSEQ.Rows[i].Cells["NRO_PRESUPUESTO0"];
                            break;
                        }
                    }

                }
            }
            else if (ch_rs2.Checked)
            {
                txt_letra2.Focus();
                for (i = 0; i < DGW_OBSEQ.Rows.Count; i++)
                {
                    if (txt_letra2.TextLength <= DGW_OBSEQ.Rows[i].Cells["DESC_PER0"].Value.ToString().Length)
                    {
                        if (txt_letra2.Text.ToLower() == DGW_OBSEQ.Rows[i].Cells["DESC_PER0"].Value.ToString().Substring(0, txt_letra2.TextLength).ToLower())
                        {
                            DGW_OBSEQ.CurrentCell = DGW_OBSEQ.Rows[i].Cells["DESC_PER0"];
                            break;
                        }
                    }
                }
            }
        }

        private void ch_cod2_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_cod2.Checked)
            {
                DGW_OBSEQ.Sort(DGW_OBSEQ.Columns["NRO_PRESUPUESTO0"], System.ComponentModel.ListSortDirection.Ascending);
                btn_buscar2.Enabled = false;
                btn_sgt2.Enabled = false;
                txt_letra2.Clear();
                txt_letra2.Focus();
            }
        }

        private void ch_rs2_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_rs2.Checked)
            {
                DGW_OBSEQ.Sort(DGW_OBSEQ.Columns["DESC_PER0"], System.ComponentModel.ListSortDirection.Ascending);
                btn_buscar2.Enabled = false;
                btn_sgt2.Enabled = false;
                txt_letra2.Clear();
                txt_letra2.Focus();
            }
        }

        private void ch_ca2_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_ca2.Checked)
            {
                btn_buscar2.Enabled = true;
                txt_letra2.Clear();
                txt_letra2.Focus();
            }
        }

        private void btn_buscar2_Click(object sender, EventArgs e)
        {
            int i, f;
            txt_letra2.Focus();
            btn_sgt2.Enabled = true;
            for (i = 0; i < DGW_OBSEQ.Rows.Count; i++)
            {
                for (f = 0; f <= DGW_OBSEQ.Rows[i].Cells["DESC_PER0"].Value.ToString().Length - txt_letra2.TextLength; f++)
                {
                    if (txt_letra2.TextLength <= DGW_OBSEQ.Rows[i].Cells["DESC_PER0"].Value.ToString().Length)
                    {
                        if (txt_letra2.Text.ToLower() == DGW_OBSEQ.Rows[i].Cells["DESC_PER0"].Value.ToString().Substring(f, txt_letra2.TextLength).ToLower())
                        {
                            DGW_OBSEQ.CurrentCell = DGW_OBSEQ.Rows[i].Cells["DESC_PER0"];
                            fila2 = i + 1;
                            return;
                        }
                    }
                }
            }
        }

        private void btn_sgt2_Click(object sender, EventArgs e)
        {
            int i, f;//antes de dar a siguiente primero se hace buscar para que lo ubique en la primera coincidencia luego se da siguiente, siguiente..., hasta encontrar el valor buscado.
            for (i = fila2; i < DGW_OBSEQ.Rows.Count; i++)
            {
                for (f = 0; f <= DGW_OBSEQ.Rows[i].Cells["DESC_PER0"].Value.ToString().Length - txt_letra2.TextLength; f++)
                {
                    if (txt_letra2.TextLength <= DGW_OBSEQ.Rows[i].Cells["DESC_PER0"].Value.ToString().Length)
                    {
                        if (txt_letra2.Text.ToLower() == DGW_OBSEQ.Rows[i].Cells["DESC_PER0"].Value.ToString().Substring(f, txt_letra2.TextLength).ToLower())
                        {
                            DGW_OBSEQ.CurrentCell = DGW_OBSEQ.Rows[i].Cells["DESC_PER0"];
                            fila2 = i + 1;
                            return;
                        }
                    }
                }
            }
            MessageBox.Show("Ya no existen más registros !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void txt_letra3_TextChanged(object sender, EventArgs e)
        {
            int i;
            if (ch_cod3.Checked)
            {
                txt_letra3.Focus();
                for (i = 0; i < dgw_ingreso.Rows.Count; i++)
                {
                    if (txt_letra3.TextLength <= dgw_ingreso.Rows[i].Cells["NRO_DOC_INV"].Value.ToString().Length)
                    {
                        if (txt_letra3.Text.ToLower() == dgw_ingreso.Rows[i].Cells["NRO_DOC_INV"].Value.ToString().Substring(0, txt_letra3.TextLength).ToLower())
                        {
                            dgw_ingreso.CurrentCell = dgw_ingreso.Rows[i].Cells["NRO_DOC_INV"];
                            break;
                        }
                    }

                }
            }
            else if (ch_rs3.Checked)
            {
                txt_letra3.Focus();
                for (i = 0; i < dgw_ingreso.Rows.Count; i++)
                {
                    if (txt_letra3.TextLength <= dgw_ingreso.Rows[i].Cells["DESC_PER1"].Value.ToString().Length)
                    {
                        if (txt_letra3.Text.ToLower() == dgw_ingreso.Rows[i].Cells["DESC_PER1"].Value.ToString().Substring(0, txt_letra3.TextLength).ToLower())
                        {
                            dgw_ingreso.CurrentCell = dgw_ingreso.Rows[i].Cells["DESC_PER1"];
                            break;
                        }
                    }
                }
            }
        }

        private void ch_cod3_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_cod3.Checked)
            {
                dgw_ingreso.Sort(dgw_ingreso.Columns["NRO_DOC_INV"], System.ComponentModel.ListSortDirection.Ascending);
                btn_buscar3.Enabled = false;
                btn_sgt3.Enabled = false;
                txt_letra3.Clear();
                txt_letra3.Focus();
            }
        }

        private void ch_rs3_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_rs3.Checked)
            {
                dgw_ingreso.Sort(dgw_ingreso.Columns["DESC_PER1"], System.ComponentModel.ListSortDirection.Ascending);
                btn_buscar3.Enabled = false;
                btn_sgt3.Enabled = false;
                txt_letra3.Clear();
                txt_letra3.Focus();
            }
        }

        private void ch_ca3_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_ca3.Checked)
            {
                btn_buscar3.Enabled = true;
                txt_letra3.Clear();
                txt_letra3.Focus();
            }
        }

        private void btn_buscar3_Click(object sender, EventArgs e)
        {
            int i, f;
            txt_letra3.Focus();
            btn_sgt3.Enabled = true;
            for (i = 0; i < dgw_ingreso.Rows.Count; i++)
            {
                for (f = 0; f <= dgw_ingreso.Rows[i].Cells["DESC_PER1"].Value.ToString().Length - txt_letra3.TextLength; f++)
                {
                    if (txt_letra3.TextLength <= dgw_ingreso.Rows[i].Cells["DESC_PER1"].Value.ToString().Length)
                    {
                        if (txt_letra3.Text.ToLower() == dgw_ingreso.Rows[i].Cells["DESC_PER1"].Value.ToString().Substring(f, txt_letra3.TextLength).ToLower())
                        {
                            dgw_ingreso.CurrentCell = dgw_ingreso.Rows[i].Cells["DESC_PER1"];
                            fila3 = i + 1;
                            return;
                        }
                    }
                }
            }
        }

        private void btn_sgt3_Click(object sender, EventArgs e)
        {
            int i, f;//antes de dar a siguiente primero se hace buscar para que lo ubique en la primera coincidencia luego se da siguiente, siguiente..., hasta encontrar el valor buscado.
            for (i = fila3; i < dgw_ingreso.Rows.Count; i++)
            {
                for (f = 0; f <= dgw_ingreso.Rows[i].Cells["DESC_PER1"].Value.ToString().Length - txt_letra3.TextLength; f++)
                {
                    if (txt_letra3.TextLength <= dgw_ingreso.Rows[i].Cells["DESC_PER1"].Value.ToString().Length)
                    {
                        if (txt_letra3.Text.ToLower() == dgw_ingreso.Rows[i].Cells["DESC_PER1"].Value.ToString().Substring(f, txt_letra3.TextLength).ToLower())
                        {
                            dgw_ingreso.CurrentCell = dgw_ingreso.Rows[i].Cells["DESC_PER1"];
                            fila3 = i + 1;
                            return;
                        }
                    }
                }
            }
            MessageBox.Show("Ya no existen más registros !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void txt_letra4_TextChanged(object sender, EventArgs e)
        {
            int i;
            if (ch_cod4.Checked)
            {
                txt_letra4.Focus();
                for (i = 0; i < dgw_ingreso_obs.Rows.Count; i++)
                {
                    if (txt_letra4.TextLength <= dgw_ingreso_obs.Rows[i].Cells["NRO_DOC_INV3"].Value.ToString().Length)
                    {
                        if (txt_letra4.Text.ToLower() == dgw_ingreso_obs.Rows[i].Cells["NRO_DOC_INV3"].Value.ToString().Substring(0, txt_letra4.TextLength).ToLower())
                        {
                            dgw_ingreso_obs.CurrentCell = dgw_ingreso_obs.Rows[i].Cells["NRO_DOC_INV3"];
                            break;
                        }
                    }

                }
            }
            else if (ch_rs4.Checked)
            {
                txt_letra4.Focus();
                for (i = 0; i < dgw_ingreso_obs.Rows.Count; i++)
                {
                    if (txt_letra4.TextLength <= dgw_ingreso_obs.Rows[i].Cells["DESC_PER3"].Value.ToString().Length)
                    {
                        if (txt_letra4.Text.ToLower() == dgw_ingreso_obs.Rows[i].Cells["DESC_PER3"].Value.ToString().Substring(0, txt_letra4.TextLength).ToLower())
                        {
                            dgw_ingreso_obs.CurrentCell = dgw_ingreso_obs.Rows[i].Cells["DESC_PER3"];
                            break;
                        }
                    }
                }
            }
        }
        #endregion


        private void rbnCuotaInicial_CheckedChanged(object sender, EventArgs e)
        {
            DataTable dt = dtContratos.AsEnumerable().Where(x => (x.Field<string>("NRO_LETRA") == "001") && (x.Field<decimal>("IMP_DOC") >= 0 && x.Field<decimal>("IMP_DOC") < x.Field<decimal>("IMP_INI"))).CopyToDataTable();
            obtenerContratosparaFacturacion(dt);
            //if(dtContratos.AsEnumerable().Where(x => x.Field<decimal>("IMP_DOC") == 0).Any())
            //{
            //    DataTable dt = dtContratos.AsEnumerable().Where(x => (x.Field<string>("NRO_LETRA") == "001") && (x.Field<decimal>("IMP_DOC") >= 0 && x.Field<decimal>("IMP_DOC") < x.Field<decimal>("IMP_INI"))).CopyToDataTable();
            //    obtenerContratosparaFacturacion(dt);
            //}
        }

        private void rbnTodos_CheckedChanged(object sender, EventArgs e)
        {
            obtenerContratosparaFacturacion(dtContratos);
        }

        private void rbnTodosObs_CheckedChanged(object sender, EventArgs e)
        {
            obtenerObsequiosparaFacturacion(dtObsequios);
        }

        private void rbnCuotaInicialObs_CheckedChanged(object sender, EventArgs e)
        {
            DataTable dt = dtObsequios.AsEnumerable().Where(x => (x.Field<string>("NRO_LETRA") == "001") && (x.Field<decimal>("IMP_DOC") >= 0 && x.Field<decimal>("IMP_DOC") < x.Field<decimal>("IMP_INI"))).CopyToDataTable();
            obtenerObsequiosparaFacturacion(dt);
        }
    }
}

