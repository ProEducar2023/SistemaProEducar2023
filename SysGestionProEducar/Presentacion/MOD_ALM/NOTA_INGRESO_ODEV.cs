using BLL;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;
namespace Presentacion.MOD_ALM
{
    public partial class NOTA_INGRESO_ODEV : Form
    {
        string AÑO = "", MES = "", COD_MOD = "", COD_USU = "", TIPO_USU = "", TXT_TC = "", COD_MOTIVO_DEVOLUCION = "";
        DateTime FECHA_INI, FECHA_GRAL;
        string BOTON;
        DataTable DT00 = new DataTable();
        DataTable dt00 = new DataTable();
        string COD_DH = "";
        HelpersBLL helBLL = new HelpersBLL();
        HelpersTo helTo = new HelpersTo();
        contratoCabeceraBLL ccBLL = new contratoCabeceraBLL();
        contratoCabeceraTo ccTo = new contratoCabeceraTo();
        contratoDetalleBLL dcBLL = new contratoDetalleBLL();
        contratoDetalleTo dcTo = new contratoDetalleTo();
        serieDocumentoBLL srdBLL = new serieDocumentoBLL();
        serieDocumentosTo srdTo = new serieDocumentosTo();
        inventariosBLL invBLL = new inventariosBLL();
        inventariosTo invTo = new inventariosTo();
        string NOMBRE_PC = System.Environment.MachineName;
        string TIPO_ORI;
        DataGridViewComboBoxEditingControl dgvCombo;
        ARTICULO_CONTENIDO frm = new ARTICULO_CONTENIDO();
        DataTable dtArticuloContenido = new DataTable();
        string COD_REF1 = "", COD_ALMACEN1 = "";
        string COD_ALMACEN_ACTUAL;
        string AÑO_CONTRATO = "", MES_CONTRATO = "";

        public NOTA_INGRESO_ODEV(string AÑO, string MES, DateTime FECHA_INI, DateTime FECHA_GRAL, string COD_MOD, string TIPO_USU, string COD_USU)
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
        private void CrearTablaContenido()
        {
            dtArticuloContenido.Columns.Add("NRO_NOTA_ING");
            dtArticuloContenido.Columns.Add("COD_ARTICULO");
            dtArticuloContenido.Columns.Add("COD_ART_CONTENIDO");
            dtArticuloContenido.Columns.Add("DESC_ARTICULO");
            dtArticuloContenido.Columns.Add("CANTIDAD");
            dtArticuloContenido.Columns.Add("SITUACION");
        }
        private void NOTA_INGRESO_ODEV_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            //DGW_OC_PTE.Rows.Add("001","EDICIONES AMERICANAS","01","MERCADERIAS","15451","","MORA GOMEZ PAULA","25623025","S");
            LIMPIAR_CABECERA();
            DATAGRID();
            CARGAR_CLASE();
            CARGAR_SUCURSAL();
            CARGAR_MOVIMIENTO();
            CARGAR_PERSONAS();
            CARGAR_MONEDA();
            CARGAR_OC_PENDIENTES();
            CARGAR_PERSONAS_PERSONAL();
            DOCUMENTOS();
            CARGA_COMBO_DEV();
            //EstadoEnabledAnular()
            dtp_doc.Format = DateTimePickerFormat.Custom;
            dtp_doc.CustomFormat = "''";
            COD_DH = "D";
            CrearTablaContenido();
            //cbo_mov.SelectedValue = "030";
            //dtp_inv.Value = Convert.ToDateTime(DateTime.Now.Day + "/" + MES + "/" + AÑO);
            DateTime fe_plla = DateTime.Now;
            if (DateTime.TryParse((DateTime.Now.Day + "/" + MES + "/" + AÑO), out fe_plla))
                dtp_inv.Value = Convert.ToDateTime(DateTime.Now.Day + "/" + MES + "/" + AÑO);
            else
                dtp_inv.Value = FECHA_GRAL;
            DT00.Columns.Add("COD_SUCURSAL");
            DT00.Columns.Add("COD_CLASE");
            DT00.Columns.Add("COD_PER");
            DT00.Columns.Add("COD_DOC_INV");
            DT00.Columns.Add("NRO_DOC_INV");
            DT00.Columns.Add("FE_AÑO");
            DT00.Columns.Add("FE_MES");
            DT00.Columns.Add("ITEM");
            DT00.Columns.Add("NRO_ITEM");
            DT00.Columns.Add("COD_ARTICULO");
            DT00.Columns.Add("CANTIDAD");
            DT00.Columns.Add("CANTIDAD_ANUL");
            DT00.Columns.Add("COD_D_H");
            DT00.Columns.Add("COD_MONEDA");
            DT00.Columns.Add("COD_ALMACEN");
            DT00.Columns.Add("PRECIO_UNITARIO");
            DT00.Columns.Add("VALOR_COMPRA");
            DT00.Columns.Add("POR_IGV");
            DT00.Columns.Add("POR_DSCTO");
            DT00.Columns.Add("STATUS_IGV");
            DT00.Columns.Add("VALOR_IGV");
            DT00.Columns.Add("VALOR_DSCTO");
            DT00.Columns.Add("AJUSTE_IGV");
            DT00.Columns.Add("AJUSTE_BI");
            DT00.Columns.Add("COD_AREA");
            DT00.Columns.Add("STATUS_FACT");
            DT00.Columns.Add("NOMBRE_PC");
            DT00.Columns.Add("NRO_PEDIDO");
            DT00.Columns.Add("FECHA_PEDIDO");
            DT00.Columns.Add("OBSERVACION");
            DT00.Columns.Add("COD_COND_DEV");
            DT00.Columns.Add("ST_VALOR_REFERENCIAL");
            //
            dt00.Columns.Add("COD_SUCURSAL");
            dt00.Columns.Add("COD_CLASE");
            dt00.Columns.Add("COD_PER");
            dt00.Columns.Add("COD_DOC_INV");
            dt00.Columns.Add("NRO_DOC_INV");
            dt00.Columns.Add("FE_AÑO");
            dt00.Columns.Add("FE_MES");
            dt00.Columns.Add("ITEM");
            dt00.Columns.Add("NRO_ITEM");
            dt00.Columns.Add("COD_ARTICULO");
            dt00.Columns.Add("CANTIDAD");
            dt00.Columns.Add("CANTIDAD_ANUL");
            dt00.Columns.Add("COD_D_H");
            dt00.Columns.Add("COD_MONEDA");
            dt00.Columns.Add("COD_ALMACEN");
            dt00.Columns.Add("PRECIO_UNITARIO");
            dt00.Columns.Add("VALOR_COMPRA");
            dt00.Columns.Add("POR_IGV");
            dt00.Columns.Add("POR_DSCTO");
            dt00.Columns.Add("STATUS_IGV");
            dt00.Columns.Add("VALOR_IGV");
            dt00.Columns.Add("VALOR_DSCTO");
            dt00.Columns.Add("AJUSTE_IGV");
            dt00.Columns.Add("AJUSTE_BI");
            dt00.Columns.Add("COD_AREA");
            dt00.Columns.Add("STATUS_FACT");
            dt00.Columns.Add("NOMBRE_PC");
            dt00.Columns.Add("NRO_PEDIDO");
            dt00.Columns.Add("FECHA_PEDIDO");
            dt00.Columns.Add("OBSERVACION");
            dt00.Columns.Add("COD_COND_DEV");
            btn_nuevo.Select();

        }
        private void CARGA_COMBO_DEV()
        {
            DataGridViewComboBoxColumn comboboxColumn = DGW_DET.Columns["Column25"] as DataGridViewComboBoxColumn;
            directorioBLL dirBLL = new directorioBLL();
            directorioTo dirTo = new directorioTo();
            dirTo.TABLA_COD = "TDEVO";
            DataTable dt = dirBLL.MOSTRAR_DIRECTORIO_DATO_BLL(dirTo);
            DataRow rw = dt.NewRow();
            rw["Descripción"] = "";
            rw["Codigo"] = "";
            dt.Rows.InsertAt(rw, 0);
            comboboxColumn.DataSource = dt;
            comboboxColumn.DisplayMember = "Descripción";
            comboboxColumn.ValueMember = "Codigo";
            //
            // bindeo los datos de los productos a la grilla
            //
            DGW_DET.AutoGenerateColumns = false;
            //DGW_DET.DataSource = ProductosDAL.GetAllProductos();
        }
        private void DATAGRID()
        {
            invTo.FE_AÑO = AÑO;
            invTo.FE_MES = MES;
            invTo.TIPO_USU = TIPO_USU;
            invTo.COD_USU = COD_USU;
            DataTable dt = invBLL.obtenerInventariosBLL(invTo);
            DataView dv = dt.AsEnumerable().Where(x => x.Field<string>("TIPO_ORIGEN").Trim() != "").AsDataView();
            dgw1.DataSource = dv;
            dgw1.Columns[0].Visible = false;
            dgw1.Columns[2].Visible = false;
            dgw1.Columns[5].Visible = false;
            dgw1.Columns[7].Visible = false;
            dgw1.Columns[8].Visible = false;
            dgw1.Columns[9].Visible = false;
            dgw1.Columns[11].Visible = false;
            dgw1.Columns[13].Visible = false;
            dgw1.Columns[14].Visible = false;
            dgw1.Columns[16].Visible = false;
            dgw1.Columns[17].Visible = false;
            dgw1.Columns[19].Visible = false;
            dgw1.Columns[20].Visible = false;//Cos.
            dgw1.Columns["COD_ALMACEN"].Visible = false;
            //dgw1.Columns[20].Visible = false;
            dgw1.Columns[1].Width = (150);
            dgw1.Columns[3].Width = (90);
            dgw1.Columns[4].Width = (80);
            dgw1.Columns[6].Width = (350);
            dgw1.Columns[10].Width = (75);
            dgw1.Columns[10].DefaultCellStyle.Format = ("d");
            dgw1.Columns[12].Width = (80);
            dgw1.Columns[15].Width = (30);
            dgw1.Columns[18].Width = (30);
            dgw1.Columns[20].Width = (30);
            dgw1.Columns[21].Width = (30);
            dgw1.Columns["TIPO_ORIGEN"].HeaderText = "Origen";
            dgw1.Columns["TIPO_ORIGEN"].Width = 50;
            dgw1.Columns["TIPO_ORIGEN"].DisplayIndex = 5;
            dgw1.Columns["Nº Doc"].Visible = false;
            dgw1.Columns["COD_DOC"].Visible = false;
            dgw1.Columns["NRO_DOC"].Visible = false;
            dgw1.Columns["FECHA_DOC"].Visible = false;

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
        private void CARGAR_MOVIMIENTO()
        {
            movimientosBLL movBLL = new movimientosBLL();
            DataTable dt = movBLL.obtenerMovimientosparaInventarioBLL();
            cbo_mov.ValueMember = "COD_MOV";
            cbo_mov.DisplayMember = "DESC_MOV";
            cbo_mov.DataSource = dt;
            cbo_mov.SelectedIndex = 0;
            //cbo_mov.SelectedValue = "030";

        }
        private void CARGAR_PERSONAS()
        {
            DataTable dt = helBLL.MOSTRAR_PERSONAS_XPAGAR_BLL();
            dgw_per.DataSource = dt;

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
        private void DOCUMENTOS()
        {
            DataTable dt = helBLL.obtenerDesc_Doc_GestionBLL();
            cbo_tipo_doc.ValueMember = "COD_DOC";
            cbo_tipo_doc.DisplayMember = "DESC_DOC";
            cbo_tipo_doc.DataSource = dt;
            cbo_tipo_doc.SelectedIndex = -1;
        }
        private void CARGAR_OC_PENDIENTES()
        {
            ccTo.FE_AÑO = AÑO;
            ccTo.FE_MES = MES;
            DataTable dt = ccBLL.obtenerOrdenDevVentasPendientesBLL(ccTo);
            if (dt.Rows.Count > 0)
            {
                DGW_OC_PTE.Rows.Clear();
                foreach (DataRow rw in dt.Rows)
                {
                    int idx = DGW_OC_PTE.Rows.Add();
                    DataGridViewRow row = DGW_OC_PTE.Rows[idx];
                    row.Cells["COD_SUCURSAL"].Value = rw["COD_SUCURSAL"].ToString();
                    row.Cells["DESC_SUCURSAL"].Value = rw["DESC_SUCURSAL"].ToString();
                    row.Cells["COD_CLASE"].Value = rw["COD_CLASE"].ToString();
                    row.Cells["DESC_CLASE"].Value = rw["DESC_CLASE"].ToString();
                    row.Cells["NRO_FAC_PRE_UNI"].Value = rw["NRO_FAC_PRE_UNI"].ToString();
                    row.Cells["NRO_PRESUPUESTO"].Value = rw["NRO_PRESUPUESTO"].ToString();
                    row.Cells["DESC_PER"].Value = rw["DESC_PER"].ToString();
                    row.Cells["DNI"].Value = rw["DNI"].ToString();
                    row.Cells["COD_MONEDA"].Value = rw["COD_MONEDA"].ToString();
                    row.Cells["FE_AÑO"].Value = rw["FE_AÑO"].ToString();
                    row.Cells["FE_MES"].Value = rw["FE_MES"].ToString();
                    row.Cells["FECHA_DOC"].Value = rw["FECHA_DOC"].ToString().ToString().Substring(0, 10);
                    row.Cells["TIPO_CAMBIO"].Value = rw["TIPO_CAMBIO"].ToString();
                    row.Cells["COD_PERE"].Value = rw["COD_PER"].ToString();
                    row.Cells["COD_MODALIDAD_VTA"].Value = rw["COD_MODALIDAD_VTA"].ToString();
                    //row.Cells["NRO_FAC_PRE_UNI"].Value = rw["NRO_FAC_PRE_UNI"].ToString();
                    row.Cells["TIPO_ORIGEN"].Value = rw["TIPO_ORIGEN"].ToString();
                    row.Cells["COD_DOC"].Value = rw["COD_DOC"].ToString();
                    row.Cells["NRO_DOC"].Value = rw["NRO_DOC"].ToString();
                    row.Cells["FECHA_DOC_FAC"].Value = rw["FECHA_DOC_FAC"].ToString();//fecha de la factura
                    row.Cells["COD_REF"].Value = Convert.ToString(rw["COD_REF"]);
                    row.Cells["COD_ALMACEN"].Value = Convert.ToString(rw["COD_ALMACEN"]);
                }
            }
        }
        private void CARGAR_PERSONAS_PERSONAL()
        {
            //cbo_elab.Items.Clear();
            personalBLL perBLL = new personalBLL();
            DataTable dt = perBLL.obtenerPersonalparaInventarioBLL();
            cbo_elab.ValueMember = "COD_PER";
            cbo_elab.DisplayMember = "DESC_PER";
            cbo_elab.DataSource = dt;
            cbo_elab.SelectedIndex = 0;
        }
        private void NOTA_INGRESO_ODEV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            BOTON = "NUEVO";
            BTN_GRABAR.Visible = true;
            BTN_GRABAR.Enabled = true;
            btn_modificar_detalle.Visible = false;
            btn_modificar_detalle.Enabled = false;
            btn_Imprimir.Enabled = false;
            GB2.Enabled = true;
            TabControl1.SelectedTab = TabPage3;
            LIMPIAR_CABECERA();
            cbo_ni.Visible = true;
            TXT_NI.Visible = false;
            CARGAR_SUCURSAL();
            cbo_sucursal.Focus();
        }

        private void LIMPIAR_CABECERA()
        {
            cbo_almacen.SelectedIndex = -1;
            TXT_COD.Clear();
            TXT_DESC.Clear();
            txt_doc_per.Clear();
            TXT_NI.Clear();
            cbo_sucursal.Enabled = true;
            cbo_clase.Enabled = true;
            TXT_COD.Enabled = true;
            TXT_DESC.Enabled = true;
            txt_doc_per.Enabled = true;
            CBO_MONEDA.Enabled = true;
            txt_numero.Clear();
            txt_obs.Clear();
            txt_nro_doc.Clear();
            txt_obs.Enabled = true;
            Panel_PER.Visible = false;
            gb_cab.Enabled = true;
            DGW_DET.Rows.Clear();
            DGW_DET.Enabled = true;
            dtArticuloContenido.Rows.Clear();
            //CARGAR_OC_PENDIENTES();
            //ofr.DGW.Rows.Clear();
            //COD_MONEDA = obj.DIR_TABLA_DESC("MONCXP", "TDEFA")
        }

        private void btn_pedido_det_Click(object sender, EventArgs e)
        {
            if (!validaCrearNotaIngreso())
                return;
            cbo_ni.Visible = true;
            TXT_NI.Visible = false;
            BTN_GRABAR.Visible = true;
            cbo_sucursal.SelectedIndex = 0;
            cbo_sucursal.SelectedValue = DGW_OC_PTE.CurrentRow.Cells["COD_SUCURSAL"].Value.ToString(); //DGW_OC_PTE[0, DGW_OC_PTE.CurrentRow.Index].Value;
            cbo_clase.SelectedValue = DGW_OC_PTE.CurrentRow.Cells["COD_CLASE"].Value.ToString(); //DGW_OC_PTE[2, DGW_OC_PTE.CurrentRow.Index].Value;
            TXT_COD.Text = DGW_OC_PTE.CurrentRow.Cells["COD_PERE"].Value.ToString();//DGW_OC_PTE[13, DGW_OC_PTE.CurrentRow.Index].Value.ToString(); 
            TXT_DESC.Text = DGW_OC_PTE.CurrentRow.Cells["DESC_PER"].Value.ToString();//DGW_OC_PTE[6, DGW_OC_PTE.CurrentRow.Index].Value.ToString();
            txt_doc_per.Text = DGW_OC_PTE.CurrentRow.Cells["DNI"].Value.ToString();//DGW_OC_PTE[7, DGW_OC_PTE.CurrentRow.Index].Value.ToString();
            COD_MOTIVO_DEVOLUCION = DGW_OC_PTE.CurrentRow.Cells["COD_MODALIDAD_VTA"].Value.ToString();//DGW_OC_PTE[14, DGW_OC_PTE.CurrentRow.Index].Value.ToString();
            //string tip_ori = DGW_OC_PTE[16, DGW_OC_PTE.CurrentRow.Index].Value.ToString();
            //dtp_doc.Value = DateTime.Now.Date;----------------------
            //dtp_inv.Value = DateTime.Now.Date;
            cbo_sucursal.Enabled = false;
            cbo_clase.Enabled = false;
            TXT_COD.Enabled = false;
            TXT_DESC.Enabled = false;
            txt_doc_per.Enabled = false;
            CBO_MONEDA.SelectedIndex = 1;
            CBO_MONEDA.Enabled = false;
            //datos de grb_doc
            cbo_tipo_doc.SelectedValue = DGW_OC_PTE.CurrentRow.Cells["COD_DOC"].Value.ToString();//DGW_OC_PTE[17, DGW_OC_PTE.CurrentRow.Index].Value
            txt_nro_doc.Text = DGW_OC_PTE.CurrentRow.Cells["NRO_DOC"].Value.ToString();//DGW_OC_PTE[18, DGW_OC_PTE.CurrentRow.Index].Value.ToString();
            if (DGW_OC_PTE.CurrentRow.Cells["FECHA_DOC_FAC"].Value.ToString() != "")
                dtp_doc.Value = Convert.ToDateTime(DGW_OC_PTE.CurrentRow.Cells["FECHA_DOC_FAC"].Value);//Convert.ToDateTime(DGW_OC_PTE[19, DGW_OC_PTE.CurrentRow.Index].Value);
            else
            {
                dtp_doc.Format = DateTimePickerFormat.Custom;
                dtp_doc.CustomFormat = "''";
            }
            TIPO_ORI = DGW_OC_PTE.CurrentRow.Cells["TIPO_ORIGEN"].Value.ToString();
            //
            //string FAC_PRE_UNI = tip_ori == "F" ? DGW_OC_PTE[4, DGW_OC_PTE.CurrentRow.Index].Value.ToString() : tip_ori == "C" ? DGW_OC_PTE[5, DGW_OC_PTE.CurrentRow.Index].Value.ToString() : "";
            string FAC_PRE_UNI = "";
            if (TIPO_ORI == "F" || TIPO_ORI == "B")
            {
                FAC_PRE_UNI = DGW_OC_PTE.CurrentRow.Cells["NRO_FAC_PRE_UNI"].Value.ToString();
                grb_doc.Enabled = true;
            }
            else if (TIPO_ORI == "C")
            {
                FAC_PRE_UNI = DGW_OC_PTE.CurrentRow.Cells["NRO_PRESUPUESTO"].Value.ToString();
                grb_doc.Enabled = false;
            }
            COD_REF1 = Convert.ToString(DGW_OC_PTE.CurrentRow.Cells["COD_REF"].Value);
            COD_ALMACEN1 = Convert.ToString(DGW_OC_PTE.CurrentRow.Cells["COD_ALMACEN"].Value);
            cbo_almacen.SelectedValue = COD_REF1 == "01" ? "0000" : COD_ALMACEN1;//0000 es el Alm Principal
            AÑO_CONTRATO = DGW_OC_PTE.CurrentRow.Cells["FE_AÑO"].Value.ToString();
            MES_CONTRATO = DGW_OC_PTE.CurrentRow.Cells["FE_MES"].Value.ToString();

            CARGAR_DETALLES(cbo_sucursal.SelectedValue.ToString(), DGW_OC_PTE.CurrentRow.Cells["NRO_PRESUPUESTO"].Value.ToString(),//DGW_OC_PTE[5, DGW_OC_PTE.CurrentRow.Index].Value.ToString(),
                FAC_PRE_UNI, DGW_OC_PTE.CurrentRow.Cells["COD_PERE"].Value.ToString(),//DGW_OC_PTE[13, DGW_OC_PTE.CurrentRow.Index].Value.ToString(),
                cbo_clase.SelectedValue.ToString(), DGW_OC_PTE.CurrentRow.Cells["FE_AÑO"].Value.ToString(),//DGW_OC_PTE[9, DGW_OC_PTE.CurrentRow.Index].Value.ToString(),
                DGW_OC_PTE.CurrentRow.Cells["FE_MES"].Value.ToString());//DGW_OC_PTE[10, DGW_OC_PTE.CurrentRow.Index].Value.ToString());
            TabControl1.SelectedTab = TabPage2;
            cbo_mov.SelectedValue = "030";
            cbo_mov.Select();
        }
        private void CARGAR_DETALLES(string COD_SUCURSAL, string NRO_PRESUPUESTO,
            string NRO_FAC_PRE_UNI, string COD_PER,
            string COD_CLASE, string FE_AÑO, string FE_MES)
        {
            dcTo.COD_SUCURSAL = COD_SUCURSAL;
            dcTo.NRO_PRESUPUESTO = NRO_PRESUPUESTO;
            dcTo.NRO_FAC_PRE_UNI = NRO_FAC_PRE_UNI;
            dcTo.COD_PER = COD_PER;
            dcTo.COD_CLASE = COD_CLASE;
            dcTo.FE_AÑO = FE_AÑO;
            dcTo.FE_MES = FE_MES;

            DataTable dt = dcBLL.obtenerNotaIngresoDevVtaDetalleBLL(dcTo);
            if (dt.Rows.Count > 0)
            {
                DGW_DET.Rows.Clear();
                foreach (DataRow rw in dt.Rows)
                {
                    int idx = DGW_DET.Rows.Add();
                    DataGridViewRow row = DGW_DET.Rows[idx];
                    row.Cells[0].Value = rw["ITEM"].ToString();
                    row.Cells[1].Value = rw["NRO_PRESUPUESTO"].ToString();
                    row.Cells[2].Value = rw["COD_ARTICULO"].ToString();
                    row.Cells[3].Value = rw["DESC_ARTICULO"].ToString();
                    row.Cells[4].Value = rw["CANTIDAD_PED"].ToString();
                    row.Cells[5].Value = rw["CANT_ING"].ToString();
                    row.Cells[6].Value = true;
                    row.Cells[7].Value = rw["PRECIO_UNIT"].ToString();
                    row.Cells[8].Value = rw["POR_IGV"].ToString();
                    row.Cells[9].Value = rw["POR_DSCTO"].ToString();
                    row.Cells[10].Value = "1";
                    row.Cells[11].Value = rw["COD_CONDICION"].ToString();//combo con las condiciones de devolucion, buen estado, mal estado, incompleto
                    row.Cells[12].Value = rw["OBSERVACION"].ToString();
                    row.Cells[13].Value = rw["VALOR_DSCTO"].ToString();
                    row.Cells[14].Value = rw["VALOR_IGV"].ToString();
                    row.Cells[15].Value = rw["VALOR_COMPRA"].ToString();
                    row.Cells["ST_VALOR_REFERENCIAL"].Value = rw["ST_VALOR_REFERENCIAL"].ToString();
                    row.Cells["STATUS_DETALLE"].Value = rw["STATUS_DETALLE"].ToString();
                }
            }
        }
        private bool validaCrearNotaIngreso()
        {
            bool result = true;
            if (DGW_OC_PTE.Rows.Count <= 0)
            {
                MessageBox.Show("NO EXISTEN ORDENES DE DEVOLUCION !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return result = false;
            }
            return result;
        }
        private void BTN_GRABAR_Click(object sender, EventArgs e)
        {
            if (!validaAdicionaModificaNI())
                return;

            const string cod_almacen = "0000";//codigo almacen principal
            string men = COD_REF1 != "01" ? "Esta mercaderia sera devuelta al Almacen del Vendedor" : "Esta mercaderia sera devuelta al Almacen Principal";
            DialogResult rs = MessageBox.Show("¿ Esta seguro de crear una nueva Nota de Ingreso de Devolución" + "\n" + men + " ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                //txt_numero.Text = HALLAR_NRO_ING(cbo_ni.Text,"");
                string errMensaje = "";
                invTo.COD_SUCURSAL = cbo_sucursal.SelectedValue.ToString();
                invTo.COD_CLASE = cbo_clase.SelectedValue.ToString();
                invTo.COD_PER = TXT_COD.Text;
                invTo.COD_CLASE_PER = "1";
                invTo.NRO_DOC_PER = txt_doc_per.Text;
                invTo.COD_DOC_INV = "01";
                invTo.NRO_DOC_INV = cbo_ni.Text.Substring(0, 3) + "-" + txt_numero.Text;
                invTo.SERIE = cbo_ni.Text.Substring(0, 3);
                invTo.NUMERO = txt_numero.Text;
                invTo.FE_AÑO = AÑO;
                invTo.FE_MES = MES;
                invTo.COD_MOV = cbo_mov.SelectedValue.ToString();
                invTo.COD_MONEDA = CBO_MONEDA.SelectedValue.ToString();
                invTo.FECHA_DOC_INV = dtp_inv.Value;
                invTo.FECHA_DOC = grb_doc.Enabled ? dtp_doc.Value : (DateTime?)null;
                invTo.COD_DOC = grb_doc.Enabled ? cbo_tipo_doc.SelectedValue.ToString() : "";
                invTo.NRO_DOC = grb_doc.Enabled ? txt_nro_doc.Text : "";
                invTo.OBSERVACION = txt_obs.Text;
                invTo.TIPO_CAMBIO = Convert.ToDecimal(TXT_TC);
                invTo.STATUS_PV = "0";
                invTo.COD_USU = COD_USU;
                invTo.FECHA = DateTime.Now;
                invTo.NOMBRE_PC = NOMBRE_PC;
                invTo.COD_ELABORADO = cbo_elab.SelectedValue.ToString();
                invTo.FECHA_DOC_ARTICULO = dtp_doc.Value;
                invTo.COD_MOTIVO_DEVOLUCION = COD_MOTIVO_DEVOLUCION;
                invTo.NRO_DOC_VTA = DGW_OC_PTE.CurrentRow.Cells["NRO_FAC_PRE_UNI"].Value.ToString();//DGW_OC_PTE[4, DGW_OC_PTE.CurrentRow.Index].Value.ToString();
                invTo.NRO_FAC_PRE_UNI = DGW_OC_PTE.CurrentRow.Cells["NRO_FAC_PRE_UNI"].Value.ToString();//DGW_OC_PTE[15, DGW_OC_PTE.CurrentRow.Index].Value.ToString();
                invTo.NRO_PEDIDO = DGW_OC_PTE.CurrentRow.Cells["NRO_PRESUPUESTO"].Value.ToString();//DGW_OC_PTE[5, DGW_OC_PTE.CurrentRow.Index].Value.ToString();//aqui va el nro de contrato
                invTo.TIPO_ORIGEN = TIPO_ORI;
                invTo.COD_REF = COD_REF1;
                invTo.FE_AÑO2 = AÑO_CONTRATO;
                invTo.FE_MES2 = MES_CONTRATO;
                //dtArticuloContenido = HelpersBLL.obtenerDT(frm.DGW_DET);
                DT00.Rows.Clear();
                int num = DGW_DET.Rows.Count - 1;
                int num3 = num;
                int i = 0, j = 0;
                while (i <= num3)
                {
                    if (Convert.ToBoolean(DGW_DET[6, i].Value))
                    {
                        DT00.Rows.Add(cbo_sucursal.SelectedValue.ToString(), cbo_clase.SelectedValue.ToString(), TXT_COD.Text, "01", (cbo_ni.Text.Substring(0, 3) + "-" + txt_numero.Text),
                        AÑO, MES, (j + 1).ToString("00"), (j + 1).ToString("00"), DGW_DET[2, i].Value.ToString(), DGW_DET[5, i].Value.ToString(), 0, COD_DH,
                        CBO_MONEDA.SelectedValue.ToString(), cod_almacen, DGW_DET[7, i].Value.ToString(), DGW_DET[15, i].Value.ToString(), DGW_DET[8, i].Value.ToString(),
                        DGW_DET[9, i].Value.ToString(), DGW_DET[10, i].Value.ToString(), DGW_DET[14, i].Value.ToString(), DGW_DET[13, i].Value.ToString(), 0, 0, "", "1", NOMBRE_PC, invTo.NRO_PEDIDO,
                        invTo.FECHA_DOC, DGW_DET[12, i].Value.ToString(), DGW_DET[11, i].Value.ToString(), DGW_DET.Rows[i].Cells["ST_VALOR_REFERENCIAL"].Value.ToString());
                        j++;
                    }
                    i++;
                }
                inventariosTo inv02To = new inventariosTo();
                if (COD_REF1 != "01")//Dirigido al vendedor
                {
                    srdTo.COD_SUCURSAL = cbo_sucursal.SelectedValue.ToString();
                    DataTable dt = srdBLL.CBO_NRO_NOTAS_TRANS(srdTo);
                    string nro_doc_inv = Convert.ToString(dt.Rows[0]["SERIE"]) + "-" + Convert.ToString(dt.Rows[0]["NUMERO"]);

                    inv02To.COD_SUCURSAL = cbo_sucursal.SelectedValue.ToString();
                    inv02To.COD_CLASE = cbo_clase.SelectedValue.ToString();
                    inv02To.COD_PER = TXT_COD.Text;
                    inv02To.COD_CLASE_PER = "1";
                    inv02To.NRO_DOC_PER = txt_doc_per.Text;
                    inv02To.COD_DOC_INV = "03";
                    inv02To.NRO_DOC_INV = nro_doc_inv;
                    inv02To.SERIE = Convert.ToString(dt.Rows[0]["SERIE"]);
                    inv02To.NUMERO = Convert.ToString(dt.Rows[0]["NUMERO"]);
                    inv02To.FE_AÑO = AÑO;
                    inv02To.FE_MES = MES;
                    inv02To.COD_MOV = "300";
                    inv02To.COD_MONEDA = "S";// COD_MONEDA;
                    inv02To.FECHA_DOC_INV = dtp_inv.Value.Date;
                    inv02To.FECHA_DOC = null;
                    inv02To.COD_DOC = "";
                    inv02To.NRO_DOC = "";
                    inv02To.OBSERVACION = txt_obs.Text;
                    inv02To.TIPO_CAMBIO = 0;// Convert.ToDecimal(TXT_TC.Text);
                    inv02To.STATUS_PV = "";
                    inv02To.COD_USU = COD_USU;
                    inv02To.FECHA = DateTime.Now;
                    inv02To.NOMBRE_PC = NOMBRE_PC;
                    inv02To.COD_ELABORADO = cbo_elab.SelectedValue.ToString();
                    inv02To.FECHA_DOC_ARTICULO = DateTime.Now;//dtp_doc.Value;
                    inv02To.COD_ALMACEN1 = "0000";
                    inv02To.COD_ALMACEN2 = COD_ALMACEN1;

                    dt00.Rows.Clear();


                    dt00.Rows.Clear();
                    int num02 = DGW_DET.Rows.Count - 1;
                    int num302 = num;
                    int i02 = 0, j02 = 0;
                    while (i02 <= num302)
                    {
                        for (int k = 0; k < 2; k++)
                        {
                            if (Convert.ToBoolean(DGW_DET[6, i02].Value))
                            {
                                dt00.Rows.Add(cbo_sucursal.SelectedValue.ToString(), cbo_clase.SelectedValue.ToString(), TXT_COD.Text, "03", nro_doc_inv,
                                    AÑO, MES, (j02 + 1).ToString("00"), (i02 + 1).ToString("00"), DGW_DET[2, i02].Value.ToString(), DGW_DET[5, i02].Value.ToString(), 0, (j02 + 1) % 2 != 0 ? "H" : "D",
                                    CBO_MONEDA.SelectedValue.ToString(), (j02 + 1) % 2 != 0 ? "0000" : COD_ALMACEN1, "0.00", "0.00", "0.00",
                                "0.00", "1", "0.00", "0.00", 0, 0, "", "1", NOMBRE_PC, "",
                                invTo.FECHA_DOC, DGW_DET[12, i02].Value.ToString(), "");
                                j02++;
                            }
                        }

                        i02++;
                    }
                }
                if (!invBLL.adicionaInsertaInventariosDevolucionBLL(invTo, DT00, dtArticuloContenido, inv02To, dt00, ref errMensaje))
                {
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (!helBLL.ELIMINAR_TEMPORAL("INV", NOMBRE_PC, ref errMensaje))
                        MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //CARGAR_DETALLES_DGW2();
                    //'-------------------------
                    MessageBox.Show("La Nota de Ingreso de Devolución se guardó", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    srdTo.COD_SUCURSAL = cbo_sucursal.SelectedValue.ToString();
                    srdTo.COD_DOC = "01";
                    srdTo.STATUS_DOC = "0";
                    srdTo.SERIE = cbo_ni.Text;
                    //txt_numero.Text = srdBLL.HALLAR_NRO_ACTUAL(srdTo);
                    DATAGRID();
                    CARGAR_OC_PENDIENTES();//para que desaparezca el pendiente que ya se acaba de ejecutar
                    CARGAR_NRO_INGRESO();
                    FOCO_NUEVO_REG();
                    BTN_GRABAR.Enabled = false;
                    btn_Imprimir.Enabled = true;
                    //btn_Imprimir.Focus();
                }
            }
        }
        private void FOCO_NUEVO_REG()
        {
            int i, cont = 0;
            cont = dgw1.Rows.Count - 1;
            string nrocon = cbo_ni.Text.Substring(0, 3) + "-" + txt_numero.Text;
            for (i = 0; i <= cont; i++)
            {
                if (nrocon == dgw1[4, i].Value.ToString().ToLower())
                {
                    dgw1.CurrentCell = dgw1.Rows[i].Cells[4];
                    return;
                }
            }
        }
        private bool validaAdicionaModificaNI()
        {
            bool result = true;
            bool existe = false;
            if (DGW_DET.Rows.Count == 0)
            {
                MessageBox.Show("Nota de Ingreso sin Detalle", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return result = false;
            }
            if (cbo_sucursal.SelectedIndex == -1)
            {
                MessageBox.Show("Elija la Sucursal", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_sucursal.Focus();
                return result = false;
            }
            if (txt_numero.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el Nº de Ingreso", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_numero.Focus();
                return result = false;
            }
            if (cbo_mov.SelectedIndex == -1)
            {
                MessageBox.Show("Elija el Movimiento", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_mov.Focus();
                return result = false;
            }
            if (cbo_clase.SelectedIndex == -1)
            {
                MessageBox.Show("Elija la Clase", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_clase.Focus();
                return result = false;
            }
            if (TXT_COD.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el codigo del Cliente !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TXT_COD.Focus();
                return result = false;
            }
            if (TXT_DESC.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese la descripcion del Cliente !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TXT_DESC.Focus();
                return result = false;
            }
            //if (cbo_tipo_doc.SelectedIndex == -1)
            //{
            //    MessageBox.Show("Elija el Documento", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    cbo_tipo_doc.Focus();
            //    return result = false;
            //}
            //if (txt_nro_doc.Text.Trim() == "")
            //{
            //    MessageBox.Show("Ingrese el Nº de Documento", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    txt_nro_doc.Focus();
            //    return result = false;
            //}
            if (cbo_elab.SelectedIndex == -1)
            {
                MessageBox.Show("Ingrese quien lo Elabora !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_elab.Focus();
                return result = false;
            }
            string mss = "";
            if (HelpersBLL.VALIDAR_FECHA(dtp_inv.Value, FECHA_GRAL, FECHA_INI, ref mss) == "0")
            {
                MessageBox.Show(mss, "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtp_inv.Focus();
                return result = false;
            }
            ///
            existe = false; string errMensaje = "";
            invTo.COD_SUCURSAL = cbo_sucursal.SelectedValue.ToString();
            invTo.COD_DOC_INV = "01";
            invTo.NRO_DOC_INV = cbo_ni.Text + "-" + txt_numero.Text;
            if (VERIFICAR_DOC_INVENTARIO(invTo, ref existe, ref errMensaje))
            {
                if (!existe)
                {
                    MessageBox.Show("El numero de documento ya existe, verifique la numeración de la serie. !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cbo_ni.Focus();
                    return result = false;
                }
            }
            /// valida el contenido de los articulos contenido
            foreach (DataGridViewRow row in DGW_DET.Rows)
            {
                if (row.Cells["STATUS_DETALLE"].Value.ToString() == "1")
                {
                    foreach (DataRow rw in dtArticuloContenido.Rows)
                    {
                        if (row.Cells["Column12"].Value.ToString() == rw["COD_ARTICULO"].ToString() && rw["SITUACION"].ToString() == "")
                        {
                            MessageBox.Show("Revise el contenido de Articulos de : \n" + row.Cells["Column13"].Value.ToString(), "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return result = false;
                        }
                    }
                }
            }
            return result;
        }
        public bool VERIFICAR_DOC_INVENTARIO(inventariosTo invTo, ref bool existe, ref string errMensaje)
        {
            bool result = true;
            if (!invBLL.VERIFICAR_DOC_INVENTARIOBLL(invTo, ref existe, ref errMensaje))
                return result = false;
            return result;
        }
        private void cbo_clase_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_clase.SelectedValue != null)
            {
                if (cbo_clase.SelectedIndex > -1)
                {
                    if (cbo_sucursal.SelectedIndex > -1)
                    {
                        CARGAR_ALMACEN();
                    }
                }
            }
        }
        private void CARGAR_ALMACEN()
        {
            almacenesBLL almBLL = new almacenesBLL();
            almacenTo almTo = new almacenTo();
            almTo.COD_CLASE = cbo_clase.SelectedValue.ToString();
            almTo.COD_SUCURSAL = cbo_sucursal.SelectedValue.ToString();
            cbo_almacen.ValueMember = "COD_ALMACEN";
            cbo_almacen.DisplayMember = "DESC_CORTA";
            cbo_almacen.DataSource = almBLL.obtenerAlmacenesparaInventarioBLL(almTo);
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
                    //Panel1.Visible = true;
                    //Panel1.SendToBack();
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
                Panel_PER.Visible = false;
                //MostrarFormaPago();
                TabControl1.SelectedTab = TabPage3;
                //gb_oc.Focus();
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

        private void txt_doc_per_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_doc_per.Text.Trim() == "")
                {
                    //btnNuevoCliente_Click(sender, e);
                }
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

        private void cbo_sucursal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_sucursal.SelectedValue != null)
            {
                if (cbo_sucursal.SelectedIndex > -1)
                {
                    cbo_ni.Enabled = true;
                    //COD_SUCURSAL = cbo_sucursal.SelectedValue.ToString();
                    if (cbo_mov.SelectedIndex > -1)
                        CARGAR_NRO_INGRESO();
                    if (cbo_clase.SelectedIndex > -1)
                        CARGAR_ALMACEN();
                }
            }
        }
        private void CARGAR_NRO_INGRESO()
        {
            movimientoSerieBLL mvsBLL = new movimientoSerieBLL();
            movimientoSerieTo mvsTo = new movimientoSerieTo();
            mvsTo.COD_SUCURSAL = cbo_sucursal.SelectedValue.ToString();
            mvsTo.COD_MOV = cbo_mov.SelectedValue.ToString();
            mvsTo.STATUS_DOC = "0";
            mvsTo.COD_DOC = "01";
            cbo_ni.ValueMember = "SERIE";
            cbo_ni.DisplayMember = "SERIE";
            cbo_ni.DataSource = mvsBLL.obtenerMovimientoSerieparaInventarioBLL(mvsTo);
        }

        private void cbo_mov_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_mov.SelectedValue != null)
            {
                if (cbo_mov.SelectedIndex > -1)
                {
                    txt_numero.Clear();
                    //COD_MOV = cbo_mov.SelectedValue.ToString();
                    if (cbo_sucursal.SelectedIndex > -1)
                        CARGAR_NRO_INGRESO();

                }
            }
        }

        private void cbo_ni_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_ni.SelectedValue != null)
            {
                if (cbo_ni.SelectedIndex > -1)
                    txt_numero.Text = HALLAR_NRO_ING(cbo_ni.Text, "01");
            }
            //cbo_ni.SelectedIndex = -1;

        }
        public string HALLAR_NRO_ING(string serie0, string cod_doc)
        {
            int sr = -1;
            srdTo.COD_SUCURSAL = cbo_sucursal.SelectedValue.ToString();
            srdTo.SERIE = serie0;
            srdTo.COD_DOC = cod_doc;
            sr = srdBLL.obtenerNro_IngBLL(srdTo);
            return sr.ToString("0000000");
        }

        private void btn_consulta_Click(object sender, EventArgs e)
        {
            try
            {
                int num = dgw1.CurrentRow.Index;
            }
            catch (Exception)
            {
                MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            BOTON = "MODIFICAR";
            BTN_GRABAR.Visible = false;
            btn_modificar_detalle.Visible = false;
            BTN_GRABAR.Enabled = false;
            btn_Imprimir.Enabled = true;
            TabControl1.SelectedTab = TabPage2;
            LIMPIAR_CABECERA();
            GB2.Enabled = false;
            DGW_DET.Enabled = true;
            CARGAR_DATOS();
            CARGAR_DETALLES_DGW();
            CARGAR_ARTICULO_CONTENIDO_MOVIMIENTO();
            cbo_ni.Visible = false;
            TXT_NI.Visible = true;
            btn_Imprimir.Focus();
        }

        private void CARGAR_DETALLES_DGW()
        {
            DGW_DET.Rows.Clear();
            int idx0 = dgw1.CurrentRow.Index;
            invTo.COD_CLASE = dgw1[2, idx0].Value.ToString();
            invTo.COD_SUCURSAL = dgw1[0, idx0].Value.ToString();
            invTo.COD_PER = TXT_COD.Text;
            invTo.NRO_DOC_INV = TXT_NI.Text + "-" + txt_numero.Text;
            invTo.FE_AÑO = AÑO;
            invTo.FE_MES = MES;
            //bool IGV_CERO;
            int idx;
            DataTable dt = invBLL.obtenerMostrar_Nota_Ingreso_Detalle_OdevBLL(invTo);//VER EL SP SE TRAEN MENOS DE LO QUE SE ASIGNA
            foreach (DataRow rw in dt.Rows)
            {
                idx = DGW_DET.Rows.Add();
                DataGridViewRow row = DGW_DET.Rows[idx];
                row.Cells[0].Value = rw["ITEM"].ToString();
                row.Cells[1].Value = rw["NRO_PEDIDO"].ToString();
                row.Cells[2].Value = rw["COD_ARTICULO"].ToString();
                row.Cells[3].Value = rw["DESC_ARTICULO"].ToString();
                row.Cells[4].Value = rw["CANTIDAD"].ToString();
                row.Cells[5].Value = rw["CANT_ING"].ToString();
                row.Cells[6].Value = true;
                row.Cells[7].Value = rw["PRECIO_UNITARIO"].ToString();
                row.Cells[8].Value = rw["POR_IGV"].ToString();
                row.Cells[9].Value = rw["POR_DSCTO"].ToString();
                row.Cells[10].Value = "1";
                row.Cells[11].Value = rw["COD_COND_DEV"].ToString();//combo con las condiciones de devolucion, buen estado, mal estado, incompleto
                row.Cells[12].Value = rw["OBSERVACION"].ToString();
                row.Cells[13].Value = rw["VALOR_DSCTO"].ToString();
                row.Cells[14].Value = rw["VALOR_IGV"].ToString();
                row.Cells[15].Value = rw["VALOR_COMPRA"].ToString();
                row.Cells["STATUS_DETALLE"].Value = rw["STATUS_DETALLE"].ToString();

            }
            //ObtenerSaldoUbicacion();
        }
        private void CARGAR_DATOS()
        {
            int idx = dgw1.CurrentRow.Index;
            cbo_ni.SelectedIndex = -1;
            //COD_SUCURSAL = dgw1[0, idx].Value.ToString();
            cbo_sucursal.SelectedValue = dgw1[0, idx].Value.ToString();
            //COD_CLASE = dgw1[2, idx].Value.ToString();
            cbo_clase.SelectedValue = dgw1[2, idx].Value.ToString();
            //COD_MOV = dgw1[8, idx].Value.ToString();
            cbo_mov.SelectedValue = dgw1[8, idx].Value.ToString();
            string str = dgw1[4, idx].Value.ToString();
            TXT_NI.Text = str.Substring(0, 3);
            txt_numero.Text = str.Substring(4, 7);
            TXT_COD.Text = dgw1[5, idx].Value.ToString();
            TXT_DESC.Text = dgw1[6, idx].Value.ToString();
            txt_doc_per.Text = dgw1[7, idx].Value.ToString();

            //CARGAR_STATUS();
            dtp_inv.Value = Convert.ToDateTime(dgw1[10, idx].Value);
            //COD_DOC = dgw1[11, idx].Value.ToString();
            //cbo_tipo_doc.SelectedValue = dgw1.Rows[idx].Cells["cod_mov"].Value;//dgw1[22, idx].Value.ToString(); ;
            //txt_nro_doc.Text = dgw1[12, idx].Value.ToString();
            cbo_tipo_doc.SelectedValue = dgw1.CurrentRow.Cells["COD_DOC"].Value.ToString();//DGW_OC_PTE[17, DGW_OC_PTE.CurrentRow.Index].Value
            txt_nro_doc.Text = dgw1.CurrentRow.Cells["NRO_DOC"].Value.ToString();//DGW_OC_PTE[18, DGW_OC_PTE.CurrentRow.Index].Value.ToString();
            if (dgw1.CurrentRow.Cells["FECHA_DOC"].Value.ToString() != "")
                dtp_doc.Value = Convert.ToDateTime(dgw1.CurrentRow.Cells["FECHA_DOC"].Value);//Convert.ToDateTime(DGW_OC_PTE[19, DGW_OC_PTE.CurrentRow.Index].Value);
            else
            {
                dtp_doc.Format = DateTimePickerFormat.Custom;
                dtp_doc.CustomFormat = "''";
            }
            //if (dgw1.Rows[idx].Cells["TIPO_ORIGEN"].Value.ToString() != "C")
            //{
            //    dtp_doc.Value = dgw1[13, idx].Value == null ? DateTime.Now : Convert.ToDateTime(dgw1[13, idx].Value);
            //}
            //else
            //{
            //    dtp_doc.Format = DateTimePickerFormat.Custom;
            //    dtp_doc.CustomFormat = "''";
            //}
            txt_obs.Text = dgw1[14, idx].Value.ToString();
            //COD_MONEDA = dgw1[15, idx].Value.ToString();
            CBO_MONEDA.SelectedValue = dgw1[15, idx].Value.ToString();
            //TXT_TC.Text = dgw1[16, idx].Value.ToString();
            //STATUS_PV = dgw1[17, idx].Value.ToString();
            //COD_ELABORADO = dgw1[19, idx].Value.ToString();
            cbo_elab.SelectedValue = dgw1[19, idx].Value.ToString();
            cbo_almacen.SelectedValue = dgw1.Rows[idx].Cells["COD_ALMACEN"].Value;
            COD_ALMACEN_ACTUAL = Convert.ToString(cbo_almacen.SelectedValue);
        }
        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            TabControl1.SelectedTab = TabPage1;
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void CBO_MONEDA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBO_MONEDA.SelectedValue != null)
            {
                if (CBO_MONEDA.SelectedIndex > -1)
                {
                    if (CBO_MONEDA.SelectedValue.ToString() == "S")
                        TXT_TC = helBLL.SACAR_CAMBIO(dtp_inv.Value.Year.ToString(), HelpersBLL.OBTIENE_CODIGO(2, dtp_inv.Value.Month.ToString()), HelpersBLL.OBTIENE_CODIGO(2, dtp_inv.Value.Day.ToString()), "D");
                    else
                        TXT_TC = helBLL.SACAR_CAMBIO(dtp_inv.Value.Year.ToString(), HelpersBLL.OBTIENE_CODIGO(2, dtp_inv.Value.Month.ToString()), HelpersBLL.OBTIENE_CODIGO(2, dtp_inv.Value.Day.ToString()), CBO_MONEDA.SelectedValue.ToString());

                }
            }
        }

        private void dtp_doc_ValueChanged(object sender, EventArgs e)
        {
            dtp_doc.CustomFormat = "dd/MM/yyyy";
        }

        private void btn_nuevo2_Click(object sender, EventArgs e)
        {
            btn_nuevo_Click(sender, e);
        }
        private void DGW_DET_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (DGW_DET.IsCurrentCellDirty)
            {
                DGW_DET.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        private void DGW_DET_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            dgvCombo = e.Control as DataGridViewComboBoxEditingControl;
            if (dgvCombo != null)
            {
                dgvCombo.SelectedIndexChanged += new EventHandler(dvgCombo_SelectedIndexChanged);
            }
        }
        private bool validaBuenEstado()
        {
            bool result = true;

            return result;
        }
        private void dvgCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DGW_DET.CurrentRow.Cells["STATUS_DETALLE"].Value.ToString() == "1")
            {
                frm.COD_ARTI = DGW_DET.CurrentRow.Cells["Column12"].Value.ToString();
                frm.SITUACION_ARTICULO = DGW_DET.CurrentRow.Cells["Column25"].Value.ToString();
                frm.CARGAR_ARTICULO_CONTENIDO(dtArticuloContenido);

                frm.ShowDialog();
                if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    foreach (DataGridViewRow row in frm.DGW_DET.Rows)
                    {
                        if (dtArticuloContenido.Rows.Count > 0)
                        {
                            foreach (DataRow fila in dtArticuloContenido.Rows)
                            {
                                if (row.Cells["COD_ARTICULO"].Value.ToString() == fila["COD_ARTICULO"].ToString() &&
                                    row.Cells["COD_ART_CONTENIDO"].Value.ToString() == fila["COD_ART_CONTENIDO"].ToString())
                                {
                                    dtArticuloContenido.Rows.Remove(fila);
                                    break;
                                }
                            }

                        }
                        DataRow rwc = dtArticuloContenido.NewRow();
                        rwc["NRO_NOTA_ING"] = TXT_NI.Text + "-" + txt_numero.Text;
                        rwc["COD_ARTICULO"] = row.Cells["COD_ARTICULO"].Value;
                        rwc["COD_ART_CONTENIDO"] = row.Cells["COD_ART_CONTENIDO"].Value;
                        rwc["DESC_ARTICULO"] = row.Cells["DESC_ARTICULO"].Value;
                        rwc["CANTIDAD"] = row.Cells["CANTIDAD"].Value;
                        rwc["SITUACION"] = row.Cells["SITUACION"].Value;
                        dtArticuloContenido.Rows.Add(rwc);
                    }

                }
            }
        }

        private void DGW_DET_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCombo != null)
            {
                //MessageBox.Show("HOLA TODO SALIO BIEN, MIRA : " + DGW_DET.CurrentRow.Cells["Column25"].Value.ToString());
                dgvCombo.SelectedIndexChanged -= new EventHandler(dvgCombo_SelectedIndexChanged);
                //validaBuenEstado();
            }
        }
        private void CARGAR_ARTICULO_CONTENIDO_MOVIMIENTO()
        {
            articuloContenidoMovimientoBLL acmBLL = new articuloContenidoMovimientoBLL();
            articuloContenidoMovimientoTo acmTo = new articuloContenidoMovimientoTo();
            acmTo.NRO_NOTA_ING = TXT_NI.Text + "-" + txt_numero.Text;
            dtArticuloContenido = acmBLL.obtenerArticuloContenidoMovimientoxNroNotaIngBLL(acmTo);
            //DGW_DET.Rows.Clear();
            //if (dt.Rows.Count > 0)
            //{
            //    int i = 0;
            //    foreach (DataRow rw in dt.Rows)
            //    {
            //        int rowId = DGW_DET.Rows.Add();
            //        DataGridViewRow row = DGW_DET.Rows[rowId];
            //        i++;
            //        row.Cells["ITEM"].Value = i.ToString().PadLeft(2, '0');
            //        row.Cells["COD_ARTICULO"].Value = rw["COD_ARTICULO"].ToString();
            //        row.Cells["COD_ART_CONTENIDO"].Value = rw["COD_ART_CONTENIDO"].ToString();
            //        row.Cells["DESC_ARTICULO"].Value = rw["DESC_ARTICULO"].ToString();
            //        row.Cells["CANTIDAD"].Value = rw["CANTIDAD"].ToString();
            //        row.Cells["SITUACION"].Value = rw["SITUACION"].ToString();
            //    }
            //}
        }
        private void btn_ver_articulo_contenido_Click(object sender, EventArgs e)
        {
            if (DGW_DET.CurrentRow.Cells["STATUS_DETALLE"].Value.ToString() == "1")
            {
                //articuloContenidoMovimientoBLL acmBLL = new articuloContenidoMovimientoBLL();
                articuloContenidoMovimientoTo acmTo = new articuloContenidoMovimientoTo();
                frm.NRO_NOTA_ING = TXT_NI.Text + "-" + txt_numero.Text;
                frm.COD_ARTI = DGW_DET.CurrentRow.Cells[2].Value.ToString();
                frm.CARGAR_ARTICULO_CONTENIDO_MOVIMIENTO();
                frm.ShowDialog();
                //if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
                //{

                //}
            }
        }

        private void btn_modificar_detalle_Click(object sender, EventArgs e)
        {
            if (DGW_DET.Rows.Count == 0)
            {
                MessageBox.Show("Nota de Ingreso sin Detalle !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string mss = "";
            if (HelpersBLL.VALIDAR_FECHA(dtp_inv.Value, FECHA_GRAL, FECHA_INI, ref mss) == "0")
            {
                MessageBox.Show(mss, "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult rs = MessageBox.Show("¿ Esta seguro de modificar la Nota de Ingreso ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                invTo.COD_SUCURSAL = cbo_sucursal.SelectedValue.ToString();
                invTo.COD_CLASE = cbo_clase.SelectedValue.ToString();
                invTo.COD_PER = TXT_COD.Text;
                invTo.COD_CLASE_PER = "1";////////------------
                invTo.NRO_DOC_PER = txt_doc_per.Text;
                invTo.COD_DOC_INV = "01";
                invTo.NRO_DOC_INV = TXT_NI.Text + "-" + txt_numero.Text;
                //invTo.SERIE = cbo_ni.Text.Substring(0, 3);//--------------------
                invTo.NUMERO = txt_numero.Text;
                invTo.FE_AÑO = AÑO;
                invTo.FE_MES = MES;
                invTo.COD_MOV = cbo_mov.SelectedValue.ToString();//--------------------------
                invTo.COD_MONEDA = CBO_MONEDA.SelectedValue.ToString(); //------------------------
                invTo.FECHA_DOC_INV = dtp_inv.Value;//-------------------------------
                invTo.FECHA_DOC = grb_doc.Enabled ? dtp_doc.Value : (DateTime?)null;//dtp_doc.Value;
                invTo.COD_DOC = grb_doc.Enabled ? cbo_tipo_doc.SelectedValue.ToString() : "";//COD_DOC;
                invTo.NRO_DOC = grb_doc.Enabled ? txt_nro_doc.Text : "";//txt_nro_doc.Text;
                invTo.OBSERVACION = txt_obs.Text;
                invTo.TIPO_CAMBIO = Convert.ToDecimal(TXT_TC);//Convert.ToDecimal(TXT_TC.Text);
                invTo.STATUS_PV = "0";//----------------------------
                invTo.COD_USU = COD_USU;
                invTo.FECHA = DateTime.Now;
                invTo.NOMBRE_PC = NOMBRE_PC;
                invTo.COD_ELABORADO = cbo_elab.SelectedValue.ToString();//COD_ELABORADO;
                invTo.FECHA_DOC_ARTICULO = dtp_doc.Value;
                invTo.NRO_PEDIDO = "";
                invTo.COD_ALMACEN1 = COD_ALMACEN_ACTUAL;//aqui va la variable del almacen original
                invTo.COD_ALMACEN2 = Convert.ToString(cbo_almacen.SelectedValue);
                DT00.Rows.Clear();
                int num = DGW_DET.Rows.Count - 1;
                int num3 = num;
                //ArrayList ListaSerie = new ArrayList();
                int i = 0, j = 0;
                while (i <= num3)
                {
                    if (Convert.ToBoolean(DGW_DET[6, i].Value))
                    {
                        DT00.Rows.Add(cbo_sucursal.SelectedValue.ToString(), cbo_clase.SelectedValue.ToString(), TXT_COD.Text, "01", (TXT_NI.Text + "-" + txt_numero.Text),
                        AÑO, MES, (j + 1).ToString("00"), (j + 1).ToString("00"), DGW_DET[2, i].Value.ToString(), DGW_DET[5, i].Value.ToString(), 0, COD_DH,
                        CBO_MONEDA.SelectedValue.ToString(), cbo_almacen.SelectedValue.ToString(), DGW_DET[7, i].Value.ToString(), DGW_DET[15, i].Value.ToString(), DGW_DET[8, i].Value.ToString(),
                        DGW_DET[9, i].Value.ToString(), DGW_DET[10, i].Value.ToString(), DGW_DET[14, i].Value.ToString(), DGW_DET[13, i].Value.ToString(), 0, 0, "", "1", NOMBRE_PC, invTo.NRO_PEDIDO,
                        invTo.FECHA_DOC, DGW_DET[12, i].Value.ToString(), DGW_DET[11, i].Value.ToString(), "");
                        j++;
                    }
                    i++;
                }
                if (!invBLL.modificaActualizaInventariosDevueltosBLL(invTo, DT00, dtArticuloContenido, ref errMensaje))
                {
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (!helBLL.ELIMINAR_TEMPORAL("INV", NOMBRE_PC, ref errMensaje))
                        MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //CARGAR_DETALLES_DGW2();
                    //'-------------------------
                    MessageBox.Show("La Nota de Ingreso se Actualizó", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //srdTo.COD_SUCURSAL = COD_SUCURSAL;
                    //srdTo.COD_DOC = "01";
                    //srdTo.STATUS_DOC = "0";
                    //srdTo.SERIE = cbo_ni.Text;
                    //txt_numero.Text = srdBLL.HALLAR_NRO_ACTUAL(srdTo);
                    COD_ALMACEN_ACTUAL = invTo.COD_ALMACEN2;
                    DATAGRID();
                    CARGAR_NRO_INGRESO();
                    FOCO_NUEVO_REG();
                    btn_modificar_detalle.Enabled = false;
                    btn_Imprimir.Enabled = true;
                    //btn_Imprimir.Focus();
                    //TabControl1.SelectedTab = TabPage1;
                }
            }
        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            try
            {
                int num = dgw1.CurrentRow.Index;
            }
            catch (Exception)
            {
                MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            BOTON = "MODIFICAR";
            BTN_GRABAR.Visible = false;
            btn_modificar_detalle.Visible = true;
            btn_modificar_detalle.Enabled = true;
            btn_Imprimir.Enabled = true;
            TabControl1.SelectedTab = TabPage2;
            LIMPIAR_CABECERA();
            GB2.Enabled = true;
            DGW_DET.Enabled = true;
            CARGAR_DATOS();
            CARGAR_DETALLES_DGW();
            CARGAR_ARTICULO_CONTENIDO_MOVIMIENTO();
            cbo_ni.Visible = true;
            TXT_NI.Visible = true;
            btn_Imprimir.Focus();
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {

        }
    }
}
