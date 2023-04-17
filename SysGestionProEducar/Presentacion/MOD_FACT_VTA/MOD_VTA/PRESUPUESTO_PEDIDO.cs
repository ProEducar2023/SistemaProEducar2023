using BLL;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;
namespace Presentacion.MOD_VTA
{
    public partial class PRESUPUESTO_PEDIDO : Form
    {
        private MODULOS_VENTAS modulos_ventas;
        string AÑO = "", MES = "", COD_MOD = "", COD_USU = "", TIPO_USU = "";
        decimal igv0;
        string BOTON;
        string coddir, coddirnac, codsup;
        DateTime FECHA_INI, FECHA_GRAL;
        DataTable DT00 = new DataTable();
        DataTable DT01 = new DataTable();
        DataTable DTEliminar;
        DataTable dtContrato;
        serieDocumentoBLL sdBLL = new serieDocumentoBLL();
        serieDocumentosTo sdTo = new serieDocumentosTo();
        progNivelRelacionBLL pnrBLL = new progNivelRelacionBLL();
        progNivelRelacionTo pnrTo = new progNivelRelacionTo();
        precontratoCabeceraBLL pccBLL = new precontratoCabeceraBLL();
        precontratoCabeceraTo pccTo = new precontratoCabeceraTo();
        precontratoDetalleBLL pcdBLL = new precontratoDetalleBLL();
        precontratoDetalleTo pcdTo = new precontratoDetalleTo();
        contratoCabeceraBLL ccBLL = new contratoCabeceraBLL();
        contratoCabeceraTo ccTo = new contratoCabeceraTo();
        contratoDetalleBLL ccdBLL = new contratoDetalleBLL();
        contratoDetalleTo ccdTo = new contratoDetalleTo();
        personaBLL perBLL = new personaBLL();
        HelpersBLL helBLL = new HelpersBLL();
        HelpersTo helTo = new HelpersTo();
        comboItemsBLL comBLL = new comboItemsBLL();
        DataTable dtCombos = new DataTable();
        //serieDocumentoBLL srdBLL = new serieDocumentoBLL();
        //serieDocumentosTo srdTo = new serieDocumentosTo();

        DIALOGOS.Dialog3 obs2 = new DIALOGOS.Dialog3();
        string NOMBRE_PC = System.Environment.MachineName;
        int idx0 = 0;
        string COD_INSTITUCION;
        decimal sneto = 0, pres = 0, otrdesc = 0, jud = 0, netcob = 0, subtotal = 0, sub_50_total = 0, sub_subtotal = 0, imp_prot = 0;
        int fila = 0;
        public PRESUPUESTO_PEDIDO(string AÑO, string MES, DateTime FECHA_INI, DateTime FECHA_GRAL, string COD_MOD, string TIPO_USU, string COD_USU, MODULOS_VENTAS modulos_ventas)
        {
            InitializeComponent();
            this.AÑO = AÑO;
            this.MES = MES;
            this.FECHA_INI = FECHA_INI;
            this.FECHA_GRAL = FECHA_GRAL;
            this.COD_MOD = COD_MOD;
            this.TIPO_USU = TIPO_USU;
            this.COD_USU = COD_USU;
            this.modulos_ventas = modulos_ventas;
        }

        private void PRESUPUESTO_PEDIDO_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            DATAGRID();//CARGA GRID DE PEDIDOS(CONTRATOS)
            //CARGAR_CLASE(); //HAY QUE REVISAR LOS PARAMETROS DE ENTRADA CORRECTOS O HACER EL LOGIN
            //CARGAR_SUCURSAL();
            //CARGAR_VENDEDOR();
            //CARGAR_PERSONAS();
            CARGAR_PERSONAS_PERSONAL();
            CARGAR_MOVIMIENTO();
            //CARGAR_COND_VENTA();
            //CARGAR_PROGRAMAS();
            CARGAR_ALMACENES();
            //TIPO_PLANILLA();
            //CARGAR_MONEDA();
            //cargaFormaPago();
            //cargaCondicionVenta();
            igv0 = helBLL.obtenerImpuestoBLL("IGV");
            TXT_IGV2.Text = igv0.ToString();
            //TXT_IGV2.Text = TXT_IGV.Text;
            CARGAR_PRESUPUESTOS_PENDIENTES();//CARGA GRID PENDIENTES(PRECONTRATOS)
            //DGW_PRES_PTE.Rows.Add("SUCURSAL 1", "MERCADERIAS", "CAMPOS VELA JUAN", "20523698", "07/03/2017",true,"",false);
            CARGA_INVENTARIO();
            cargaDataTable();
            DT00.Columns.Add("sucursal");
            DT00.Columns.Add("nro_doc");
            DT00.Columns.Add("NRO_FAC_PRE_UNI");
            DT00.Columns.Add("Cod_per");
            DT00.Columns.Add("cod_clase");
            DT00.Columns.Add("Fe_año");
            DT00.Columns.Add("Fe_mes");
            DT00.Columns.Add("Item");
            DT00.Columns.Add("Articulo");
            DT00.Columns.Add("Cantidad_ped");
            DT00.Columns.Add("Cantidad_aten");
            DT00.Columns.Add("Cantidad_anul");
            DT00.Columns.Add("Precio_Unit");
            DT00.Columns.Add("Valor_Compra");
            DT00.Columns.Add("Por_igv");
            DT00.Columns.Add("Por_Dscto");
            DT00.Columns.Add("Status_igv");
            DT00.Columns.Add("Valor_IGV");
            DT00.Columns.Add("Valor_Dscto");
            DT00.Columns.Add("Ajuste_igv");
            DT00.Columns.Add("Ajuste_Bi");
            DT00.Columns.Add("COD_d_h");
            DT00.Columns.Add("observacion");
            DT00.Columns.Add("Nombre_pc");
            DT00.Columns.Add("NRO_PRESUPUESTO");
            DT00.Columns.Add("NRO_ITEM");
            DT00.Columns.Add("COD_CONDICION");
            DT00.Columns.Add("DESC_ARTICULO");
            DT00.Columns.Add("TIPO_PRECIO");
            DT00.Columns.Add("TIPO_ENTR_FAC");
            DT00.Columns.Add("ST_VALOR_REFERENCIA");
            btn_nuevo.Select();
        }
        private void CARGA_INVENTARIO()
        {
            DT01.Columns.Add("sucursal");
            DT01.Columns.Add("Clase");
            DT01.Columns.Add("Cod_per");
            DT01.Columns.Add("COD_DOC");
            DT01.Columns.Add("NRO_DOC_INV");
            DT01.Columns.Add("Fe_año");
            DT01.Columns.Add("Fe_mes");
            DT01.Columns.Add("Item");
            DT01.Columns.Add("Item2");
            DT01.Columns.Add("Articulo");
            DT01.Columns.Add("Cantidad");
            DT01.Columns.Add("Cantidad_anul");
            DT01.Columns.Add("COD_D_H");
            DT01.Columns.Add("COD_MONEDA");
            DT01.Columns.Add("COD_ALMACEN");
            DT01.Columns.Add("Precio_Unit");
            DT01.Columns.Add("Valor_COmpra");
            DT01.Columns.Add("Por_igv");
            DT01.Columns.Add("Por_Dscto");
            DT01.Columns.Add("Status_igv");
            DT01.Columns.Add("Valor_IGV");
            DT01.Columns.Add("Valor_Dscto");
            DT01.Columns.Add("Ajuste_igv");
            DT01.Columns.Add("Ajuste_Bi");
            DT01.Columns.Add("COD_AREA");
            DT01.Columns.Add("STATUS_FACT");
            DT01.Columns.Add("Nombre_pc");
            DT01.Columns.Add("NRO_PEDIDO");//*****************
            DT01.Columns.Add("FECHA_PEDIDO");//******************
            DT01.Columns.Add("OBSERVACION");
        }
        private void CARGAR_SERIE_NRO()
        {
            sdTo.COD_SUCURSAL = CBO_SUCURSAL.SelectedValue.ToString();
            sdTo.COD_DOC = "04";
            sdTo.STATUS_DOC = "0";
            DataTable dt = sdBLL.OBTENER_SERIE_NRO_BLL(sdTo);
            txt_nro.Text = dt.Rows[0][1].ToString();
            txt_numero1.Text = dt.Rows[0][0].ToString();
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
        private void CARGAR_PERSONAS_PERSONAL()
        {
            CBO_PERSONAL.Items.Clear();
            personalBLL perBLL = new personalBLL();
            DataTable dt = perBLL.obtenerPersonalparaPreventaBLL();
            CBO_PERSONAL.ValueMember = "COD_PER";
            CBO_PERSONAL.DisplayMember = "DESC_PER";
            CBO_PERSONAL.DataSource = dt;
            CBO_PERSONAL.SelectedIndex = 0;
        }
        private void cargaDataTable()
        {
            dtCombos.Columns.Add("cod_suc");
            dtCombos.Columns.Add("desc_suc");
            dtCombos.Columns.Add("cod_cla");
            dtCombos.Columns.Add("desc_cla");
            //dtCombos.Columns.Add("cod_mov");
            //dtCombos.Columns.Add("desc_mov");
            dtCombos.Columns.Add("cod_mon");
            dtCombos.Columns.Add("desc_mon");
            dtCombos.Columns.Add("cod_pro");
            dtCombos.Columns.Add("desc_pro");
            dtCombos.Columns.Add("cod_sem");
            dtCombos.Columns.Add("desc_sem");
            dtCombos.Columns.Add("cod_pla");
            dtCombos.Columns.Add("desc_pla");
            dtCombos.Columns.Add("cod_pag");
            dtCombos.Columns.Add("desc_pag");
            dtCombos.Columns.Add("cod_ven");
            dtCombos.Columns.Add("desc_ven");
            dtCombos.Columns.Add("cod_dig");
            dtCombos.Columns.Add("desc_dig");
            //
            dtCombos.Columns.Add("cod_sub_pto_ven");
            dtCombos.Columns.Add("desc_sub_pto_ven");
            dtCombos.Columns.Add("cod_can_dscto");
            dtCombos.Columns.Add("desc_can_dscto");
            dtCombos.Columns.Add("cod_pto_cob");
            dtCombos.Columns.Add("desc_pto_cob");
            //
            dtCombos.Columns.Add("cod_tipo_vta");
            dtCombos.Columns.Add("desc_tipo_vta");
            //
            dtCombos.Columns.Add("cod_mod_vta");
            dtCombos.Columns.Add("desc_mod_vta");
            //
            dtCombos.Columns.Add("cod_lug_vta");
            dtCombos.Columns.Add("desc_lug_vta");
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
        private void CARGAR_PRESUPUESTOS_PENDIENTES()
        {
            //DGW_PRES_PTE.Rows.Clear();
            DGW_PRES_PTE.DataSource = null;
            //pccTo.FE_AÑO = AÑO;
            //pccTo.FE_MES = MES;
            dtContrato = pccBLL.CARGAR_PRECONTRATOS_PENDIENTESBLL(pccTo);
            DGW_PRES_PTE.DataSource = dtContrato;
            //if(dtContrato.Rows.Count > 0)
            //{
            //    foreach(DataRow rw in dtContrato.Rows)
            //    {
            //        int idx = DGW_PRES_PTE.Rows.Add();
            //        DataGridViewRow row = DGW_PRES_PTE.Rows[idx];
            //        row.Cells[0].Value = rw[1].ToString();
            //        row.Cells[1].Value = rw[3].ToString();
            //        row.Cells[2].Value = rw[6].ToString();
            //        row.Cells[3].Value = rw[4].ToString();
            //        row.Cells[4].Value = rw[11].ToString();
            //        row.Cells[5].Value = rw[40].ToString() == "1" ? true : false;
            //        row.Cells[6].Value = rw[41].ToString() == "1" ? true : false;
            //        //row.Cells[7].Value = rw[0].ToString();
            //    }
            //}
        }
        public void DATAGRID()
        {
            ccTo.FE_AÑO = AÑO;
            ccTo.FE_MES = MES;
            ccTo.TIPO_USU = TIPO_USU;//DE MOMENTO ESTO SALE DE INICIO (LOGIN)
            ccTo.COD_USU = COD_USU;
            dgw1.DataSource = null;
            lbl_nro_reg_docs.Text = "Nro de Registros : 0";
            dtContrato = ccBLL.obtenerContratoCabeceraBLL(ccTo);
            if (dtContrato.Rows.Count > 0)
            {
                lbl_nro_reg_docs.Text = "Nro de Registros : " + dtContrato.Rows.Count.ToString();
                dgw1.DataSource = dtContrato;
                dgw1.Columns["COD_SUCURSAL"].Visible = false;
                dgw1.Columns["COD_CLASE"].Visible = false;
                dgw1.Columns["NRO_DOC"].Visible = false;
                dgw1.Columns["COD_PER"].Visible = false;
                dgw1.Columns["DNI"].Visible = false;
                dgw1.Columns["COD_MONEDA"].Visible = false;
                dgw1.Columns["Desc_moneda"].Visible = false;
                dgw1.Columns["FE_AÑO"].Visible = false;
                dgw1.Columns["FE_MES"].Visible = false;
                dgw1.Columns["OBS"].Visible = false;
                dgw1.Columns["TIPO_CAMBIO"].Visible = false;
                dgw1.Columns["FORMA_PAGO"].Visible = false;
                dgw1.Columns["FORMA_PAGO_TIPO"].Visible = false;
                dgw1.Columns["STATUS_PV"].Visible = false;
                dgw1.Columns["NRO_DIAS"].Visible = false;
                dgw1.Columns["COD_PER_ELAB"].Visible = false;
                dgw1.Columns["DESC_PER_ELAB"].Visible = false;
                dgw1.Columns["COD_VENDEDOR"].Visible = false;
                dgw1.Columns["DESC_PER"].Visible = false;
                dgw1.Columns["COD_CONTACTO"].Visible = false;
                dgw1.Columns["CONDICION_VENTA"].Visible = false;
                dgw1.Columns["DESC_TIPO"].Visible = false;
                dgw1.Columns["TIPO_PRECIO"].Visible = false;
                dgw1.Columns["OBSERVACION"].Visible = false;
                //dgw1.Columns["NRO_REPORTE"].Visible = false;
                //dgw1.Columns["FEC_REPORTE"].Visible = false;
                dgw1.Columns["COD_PROGRAMA"].Visible = false;
                dgw1.Columns["DESC_PROGRAMA"].Visible = false;
                dgw1.Columns["PERIODO"].Visible = false;
                dgw1.Columns["NRO_SEMANA"].Visible = false;
                dgw1.Columns["NOM_SEMANA"].Visible = false;
                dgw1.Columns["TIPO_OPERACION"].Visible = false;
                dgw1.Columns["TIPO_PLANILLA"].Visible = false;
                dgw1.Columns["DESC_TIPO"].Visible = false;
                dgw1.Columns["NOM_NIVEL_INSTITUCION"].Visible = false;
                dgw1.Columns["COD_ALMACEN"].Visible = false;
                dgw1.Columns["COD_NIVEL1"].Visible = false;
                dgw1.Columns["COD_NIVEL2"].Visible = false;
                dgw1.Columns["COD_NIVEL3"].Visible = false;
                dgw1.Columns["SUELDO_NETO"].Visible = false;
                dgw1.Columns["PRESTAMOS"].Visible = false;
                dgw1.Columns["OTROS_DSCTOS"].Visible = false;
                dgw1.Columns["JUDICIALES"].Visible = false;
                dgw1.Columns["NETO_COBRAR"].Visible = false;
                dgw1.Columns["TOTAL_CONTRATO"].Visible = false;
                dgw1.Columns["NRO_CUOTAS"].Visible = false;
                dgw1.Columns["IMP_CUOTA_INICIAL"].Visible = false;
                dgw1.Columns["IMP_COUTA_MES"].Visible = false;
                dgw1.Columns["FEC_PRIMER_VENC"].Visible = false;
                dgw1.Columns["NRO_DIAS_VENC"].Visible = false;
                dgw1.Columns["FEC_CUO_MEN"].Visible = false;
                dgw1.Columns["Cie."].Visible = false;
                //
                dgw1.Columns["COD_MOV"].Visible = false;
                dgw1.Columns["COD_SUB_PTO_VEN"].Visible = false;
                dgw1.Columns["DESC_PTO_VEN"].Visible = false;
                dgw1.Columns["COD_CANAL_DSCTO"].Visible = false;
                dgw1.Columns["DESCRIPCION"].Visible = false;
                dgw1.Columns["COD_PTO_COB"].Visible = false;
                dgw1.Columns["DESC_PTO_COB"].Visible = false;
                dgw1.Columns["COD_TIPO_VENTA"].Visible = false;
                dgw1.Columns["DESC_TIPO_VENTA"].Visible = false;
                dgw1.Columns["COD_MODALIDAD_VTA"].Visible = false;
                dgw1.Columns["DESC_MODALIDAD_VTA"].Visible = false;
                dgw1.Columns["NRO_DOC"].Visible = false;
                dgw1.Columns["FECHA_DOC"].Visible = false;
                dgw1.Columns["COD_LUG_VTA"].Visible = false;
                dgw1.Columns["DESC_LUG_VTA"].Visible = false;
                dgw1.Columns["DESC_INST"].Visible = false;
                dgw1.Columns["IMPORTE_PROTECCION"].Visible = false;
                dgw1.Columns["NRO_DOC_INV"].Visible = false;
                //
                dgw1.Columns["Sucursal"].Width = 130;
                dgw1.Columns["Clase"].Width = 100;
                dgw1.Columns["Cliente"].Width = 180;
                dgw1.Columns["FECHA_APROB"].HeaderText = "Fe Apro";
                dgw1.Columns["FECHA_APROB"].Width = 70;
                dgw1.Columns["FECHA_APROB"].DefaultCellStyle.Format = "d";
                dgw1.Columns["Aprob"].Width = 40;
                dgw1.Columns["PreAprob"].Width = 40;
                dgw1.Columns["Anul"].Width = 40;
                //dgw1.Columns[56].Width = 40;
                dgw1.Columns["Fact"].Width = 40;
                dgw1.Columns["NRO_PRESUPUESTO"].HeaderText = "Contrato";
                dgw1.Columns["NRO_PRESUPUESTO"].DisplayIndex = 7;
                dgw1.Columns["NRO_PRESUPUESTO"].Width = 70;
                dgw1.Columns["FECHA_PRE"].HeaderText = "Fe Cont";
                dgw1.Columns["FECHA_PRE"].DisplayIndex = 8;
                dgw1.Columns["FECHA_PRE"].Width = 70;
                dgw1.Columns["FECHA_PRE"].DefaultCellStyle.Format = "d";
                dgw1.Columns["NRO_REPORTE"].HeaderText = "Nº Repo";
                dgw1.Columns["NRO_REPORTE"].DisplayIndex = 9;
                dgw1.Columns["NRO_REPORTE"].Width = 60;
                dgw1.Columns["FEC_REPORTE"].HeaderText = "Fe Repo";
                dgw1.Columns["FEC_REPORTE"].DisplayIndex = 10;
                dgw1.Columns["FEC_REPORTE"].Width = 70;
                dgw1.Columns["FEC_REPORTE"].DefaultCellStyle.Format = "d";
                dgw1.Select();
            }

        }
        private void btn_pedido_det_Click(object sender, EventArgs e)
        {
            if (DGW_PRES_PTE.Rows.Count > 0)
            {
                int idx = DGW_PRES_PTE.CurrentRow.Index;
                idx0 = idx;
                BOTON = "NUEVO";
                btn_grabar2.Visible = false;
                BTN_GRABAR.Visible = true;
                BTN_GRABAR.Enabled = true;
                btn_Imprimir.Enabled = false;
                gb_oc.Enabled = true;
                LIMPIAR_CABECERA();
                CBO_SUCURSAL.Focus();
                CARGAR_COMBOS_PRESUPUESTO(idx);
                CARGAR_DATOS_PRESUPUESTO(idx);
                CARGAR_SERIE_NRO();
                CARGAR_DETALLES_DGW_PRESUPUESTO();
                HALLAR_TOTAL_OC();
                txtalm.Text = cbo_alm.Text;
                TabControl1.SelectedTab = TabPage2;
            }

        }
        private void CARGAR_DATOS_PRESUPUESTO(int idx)
        {

            CBO_SUCURSAL.ValueMember = "cod_suc";
            CBO_SUCURSAL.DisplayMember = "desc_suc";
            CBO_SUCURSAL.DataSource = dtCombos;
            CBO_SUCURSAL.SelectedIndex = 0;
            CBO_CLASE.ValueMember = "cod_cla";
            CBO_CLASE.DisplayMember = "desc_cla";
            CBO_CLASE.DataSource = dtCombos;
            CBO_CLASE.SelectedIndex = 0;
            CBO_MONEDA.ValueMember = "cod_mon";
            CBO_MONEDA.DisplayMember = "desc_mon";
            CBO_MONEDA.DataSource = dtCombos;
            CBO_MONEDA.SelectedIndex = 0;
            cbo_prog.ValueMember = "cod_pro";
            cbo_prog.DisplayMember = "desc_pro";
            cbo_prog.DataSource = dtCombos;
            cbo_prog.SelectedIndex = 0;
            cbo_semana.ValueMember = "cod_sem";
            cbo_semana.DisplayMember = "desc_sem";
            cbo_semana.DataSource = dtCombos;
            cbo_semana.SelectedIndex = 0;
            cbo_tipo_planilla.ValueMember = "cod_pla";
            cbo_tipo_planilla.DisplayMember = "desc_pla";
            cbo_tipo_planilla.DataSource = dtCombos;
            cbo_tipo_planilla.SelectedIndex = 0;
            CBO_PAGO.ValueMember = "cod_pag";
            CBO_PAGO.DisplayMember = "desc_pag";
            CBO_PAGO.DataSource = dtCombos;
            CBO_PAGO.SelectedIndex = 0;
            cbo_VENTA.ValueMember = "cod_ven";
            cbo_VENTA.DisplayMember = "desc_ven";
            cbo_VENTA.DataSource = dtCombos;
            cbo_VENTA.SelectedIndex = 0;
            //CBO_PERSONAL.ValueMember = "cod_dig";
            //CBO_PERSONAL.DisplayMember = "desc_dig";
            //CBO_PERSONAL.DataSource = dtCombos;
            //CBO_PERSONAL.SelectedIndex = 0;
            COD_INSTITUCION = DGW_PRES_PTE.Rows[idx].Cells["COD_INSTITUCION"].Value.ToString();
            lbl_institucion.Text = DGW_PRES_PTE.Rows[idx].Cells["DESC_INST"].Value.ToString();
            TXT_COD.Text = DGW_PRES_PTE[5, idx].Value.ToString();
            TXT_DESC.Text = DGW_PRES_PTE[6, idx].Value.ToString();
            txt_doc_per.Text = DGW_PRES_PTE[7, idx].Value.ToString();
            txt_numero.Text = DGW_PRES_PTE.Rows[idx].Cells["NRO_PRESUPUESTO"].Value.ToString();
            TXT_TC.Text = DGW_PRES_PTE[13, idx].Value.ToString();
            txt_oc.Text = DGW_PRES_PTE[28, idx].Value.ToString();
            dtp_oc.Value = Convert.ToDateTime(DGW_PRES_PTE[29, idx].Value);
            txt_mes.Text = DGW_PRES_PTE[32, idx].Value.ToString();
            DTP_DOC.Value = Convert.ToDateTime(DGW_PRES_PTE[12, idx].Value);
            txt_nro_dias.Text = DGW_PRES_PTE[18, idx].Value.ToString();
            obs2.txt_obs.Text = DGW_PRES_PTE[16, idx].Value.ToString();
            txtsbas.Text = DGW_PRES_PTE[40, idx].Value.ToString();
            txtsbru.Text = DGW_PRES_PTE[41, idx].Value.ToString();
            txt_judicial.Text = DGW_PRES_PTE[43, idx].Value.ToString();
            txt_subtotal.Text = (Convert.ToDecimal(txtsbas.Text) - Convert.ToDecimal(txtsbru.Text) - Convert.ToDecimal(txt_judicial.Text)).ToString();
            txt_50_subtotal.Text = (Convert.ToDecimal(txt_subtotal.Text) / 2).ToString();
            txt_otro_desc.Text = DGW_PRES_PTE[42, idx].Value.ToString();
            txt_sub_sub_total.Text = (Convert.ToDecimal(txt_50_subtotal.Text) - Convert.ToDecimal(txt_otro_desc.Text)).ToString();
            txt_imp_proteccion.Text = DGW_PRES_PTE.Rows[idx].Cells["IMPORTE_PROTECCION"].Value.ToString();
            txt_neto_cob.Text = DGW_PRES_PTE[44, idx].Value.ToString();
            txt_cod2.Text = DGW_PRES_PTE[21, idx].Value.ToString();
            txt_desc2.Text = DGW_PRES_PTE[22, idx].Value.ToString();
            CH_PV.Checked = DGW_PRES_PTE[17, idx].Value.ToString() == "1" ? true : false;
            cbo_alm.SelectedValue = DGW_PRES_PTE[36, idx].Value.ToString();
            //
            txt_tot.Text = DGW_PRES_PTE[45, idx].Value.ToString();
            txtncuo.Text = DGW_PRES_PTE[46, idx].Value.ToString();
            txt_ci.Text = DGW_PRES_PTE[47, idx].Value.ToString();
            txtcuotas.Text = DGW_PRES_PTE[48, idx].Value.ToString();
            dtp_vctoc.Value = DGW_PRES_PTE[49, idx].Value.ToString() == "" ? DateTime.Now : Convert.ToDateTime(DGW_PRES_PTE[49, idx].Value);
            txt_ndvcto.Text = DGW_PRES_PTE[50, idx].Value.ToString();
            dtp_fmen.Value = DGW_PRES_PTE[51, idx].Value.ToString() == "" ? DateTime.Now : Convert.ToDateTime(DGW_PRES_PTE[51, idx].Value);
            //
            pnrTo.COD_PROG = cbo_prog.SelectedValue.ToString();
            pnrTo.COD_VEND = txt_cod2.Text;
            DataTable dt = pnrBLL.obtenerNivelesSuperioresVendedorBLL(pnrTo);
            if (dt.Rows.Count > 0)
            {
                lblsup.Text = dt.Rows[2][5].ToString();
                lbldir.Text = dt.Rows[1][5].ToString();
                lbldirn.Text = dt.Rows[0][5].ToString();
                //lblalm.Text = dt.Rows[0][6].ToString();
                //cbo_alm.SelectedValue = dt.Rows[0][4].ToString();
                codsup = dt.Rows[2][2].ToString();
                coddir = dt.Rows[1][2].ToString();
                coddirnac = dt.Rows[0][2].ToString();
            }
            cboptovta.ValueMember = "cod_sub_pto_ven";
            cboptovta.DisplayMember = "desc_sub_pto_ven";
            cboptovta.DataSource = dtCombos;
            cbocandesc.ValueMember = "cod_can_dscto";
            cbocandesc.DisplayMember = "desc_can_dscto";
            cbocandesc.DataSource = dtCombos;
            cboptocob.ValueMember = "cod_pto_cob";
            cboptocob.DisplayMember = "desc_pto_cob";
            cboptocob.DataSource = dtCombos;
            cbo_tipo_venta.ValueMember = "cod_tipo_vta";
            cbo_tipo_venta.DisplayMember = "desc_tipo_vta";
            cbo_tipo_venta.DataSource = dtCombos;
            cbo_modalidad_venta.ValueMember = "cod_mod_vta";
            cbo_modalidad_venta.DisplayMember = "desc_mod_vta";
            cbo_modalidad_venta.DataSource = dtCombos;
            cbo_lug_vta.ValueMember = "cod_lug_vta";
            cbo_lug_vta.DisplayMember = "desc_lug_vta";
            cbo_lug_vta.DataSource = dtCombos;
        }
        private void CARGAR_DETALLES_DGW_PRESUPUESTO()
        {
            DGW_DET.Rows.Clear();
            pcdTo.COD_CLASE = CBO_CLASE.SelectedValue.ToString();
            pcdTo.COD_SUCURSAL = CBO_SUCURSAL.SelectedValue.ToString();
            pcdTo.COD_PER = TXT_COD.Text;
            pcdTo.NRO_PRESUPUESTO = txt_numero.Text;
            pcdTo.FE_AÑO = DGW_PRES_PTE.CurrentRow.Cells["fe_año"].Value.ToString();//AÑO;
            pcdTo.FE_MES = DGW_PRES_PTE.CurrentRow.Cells["fe_mes"].Value.ToString();//MES;
            DataTable dt = pcdBLL.obtenerPreContratoDetalleBLL(pcdTo);
            DGW_DET.DataSource = dt;
            //LLENA_DGW_DET_PRESUPUESTO(dt);
            //HALLAR_TOTAL_OC();
        }
        private void LLENA_DGW_DET_PRESUPUESTO(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow rw in dt.Rows)
                {
                    int rowId = DGW_DET.Rows.Add();
                    DataGridViewRow row = DGW_DET.Rows[rowId];
                    row.Cells["ITEM"].Value = rw["ITEM"].ToString();
                    row.Cells["COD_ARTICULO"].Value = rw["COD_ARTICULO"].ToString();
                    row.Cells["DESC_ARTICULO"].Value = rw["DESC_ARTICULO"].ToString();
                    row.Cells["CANTIDAD_PED"].Value = rw["CANTIDAD_PED"].ToString();
                    row.Cells["estado"].Value = rw["estado"].ToString();
                    row.Cells["precio_unit"].Value = rw["precio_unit"].ToString();
                    row.Cells["POR_IGV"].Value = rw["POR_IGV"].ToString();
                    row.Cells["POR_DSCTO"].Value = rw["POR_DSCTO"].ToString();
                    row.Cells["STATUS_IGV"].Value = rw["STATUS_IGV"].ToString();
                    row.Cells["COD_MONEDA"].Value = rw["COD_MONEDA"].ToString();
                    row.Cells["AJUSTE_IGV"].Value = rw["AJUSTE_IGV"].ToString();
                    row.Cells["AJUSTE_BI"].Value = rw["AJUSTE_BI"].ToString();
                    row.Cells["VALOR_IGV"].Value = rw["VALOR_IGV"].ToString();
                    row.Cells["VALOR_COMPRA"].Value = rw["VALOR_COMPRA"].ToString();
                    row.Cells["VALOR_DSCTO"].Value = rw["VALOR_DSCTO"].ToString();
                    row.Cells["ST_VALOR_REFERENCIAL"].Value = rw["ST_VALOR_REFERENCIAL"].ToString();
                    row.Cells["COD_D_H"].Value = rw["COD_D_H"].ToString();
                    row.Cells["NRO_PRESUPUESTO"].Value = rw["NRO_PRESUPUESTO"].ToString();
                    row.Cells["OBSERVACION"].Value = rw["OBSERVACION"].ToString();
                    row.Cells["COD_VENDEDOR"].Value = rw["COD_VENDEDOR"].ToString();
                    row.Cells["PRECIO_UNITARIO"].Value = rw["PRECIO_UNITARIO"].ToString();
                    row.Cells["COD_KIT"].Value = rw["COD_KIT"].ToString();
                }
            }
        }
        private void LLENA_DGW_DET(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow rw in dt.Rows)
                {
                    int rowId = DGW_DET.Rows.Add();
                    DataGridViewRow row = DGW_DET.Rows[rowId];
                    row.Cells["ITEM"].Value = rw["ITEM"].ToString();
                    row.Cells["COD_ARTICULO"].Value = rw["COD_ARTICULO"].ToString();
                    row.Cells["DESC_ARTICULO"].Value = rw["DESC_ARTICULO"].ToString();
                    row.Cells["CANTIDAD_PED"].Value = rw["CANTIDAD_PED"].ToString();
                    row.Cells["estado"].Value = rw["estado"].ToString();
                    row.Cells["precio_unit"].Value = rw["precio_unit"].ToString();
                    row.Cells["POR_IGV"].Value = rw["POR_IGV"].ToString();
                    row.Cells["POR_DSCTO"].Value = rw["POR_DSCTO"].ToString();
                    row.Cells["STATUS_IGV"].Value = rw["STATUS_IGV"].ToString();
                    row.Cells["COD_MONEDA"].Value = rw["COD_MONEDA"].ToString();
                    row.Cells["AJUSTE_IGV"].Value = rw["AJUSTE_IGV"].ToString();
                    row.Cells["AJUSTE_BI"].Value = rw["AJUSTE_BI"].ToString();
                    row.Cells["VALOR_IGV"].Value = rw["VALOR_IGV"].ToString();
                    row.Cells["VALOR_COMPRA"].Value = rw["VALOR_COMPRA"].ToString();
                    row.Cells["VALOR_DSCTO"].Value = rw["VALOR_DSCTO"].ToString();
                    row.Cells["ST_VALOR_REFERENCIAL"].Value = rw["ST_VALOR_REFERENCIAL"].ToString();
                    row.Cells["COD_D_H"].Value = rw["COD_D_H"].ToString();
                    row.Cells["NRO_PRESUPUESTO"].Value = rw["NRO_PRESUPUESTO"].ToString();
                    row.Cells["OBSERVACION"].Value = rw["OBSERVACION"].ToString();
                    row.Cells["COD_VENDEDOR"].Value = rw["COD_VENDEDOR"].ToString();
                    row.Cells["PRECIO_UNITARIO"].Value = rw["PRECIO_UNITARIO"].ToString();
                    row.Cells["COD_KIT"].Value = rw["COD_KIT"].ToString();
                }
            }
        }
        private void CARGAR_DETALLES_DGW()
        {
            //DGW_DET.Rows.Clear();
            DGW_DET.DataSource = null;
            ccdTo.COD_CLASE = CBO_CLASE.SelectedValue.ToString();
            ccdTo.COD_SUCURSAL = CBO_SUCURSAL.SelectedValue.ToString();
            ccdTo.COD_PER = TXT_COD.Text;
            //ccdTo.NRO_DOC = txt_numero.Text;
            ccdTo.NRO_DOC = txt_nro.Text + "-" + txt_numero1.Text;
            ccdTo.FE_AÑO = AÑO;
            ccdTo.FE_MES = MES;
            DataTable dt = ccdBLL.obtenerContratoDetalleContratoBLL(ccdTo);
            DGW_DET.DataSource = dt;//no se puede llenar con foreach porque se llena de dos sp diferentes con campos distos
            //LLENA_DGW_DET(dt);
            //HALLAR_TOTAL_OC();
            //foreach (DataRow rw in dt.Rows)
            //{
            //    int idx = DGW_DET.Rows.Add();
            //    DataGridViewRow row = DGW_DET.Rows[idx];
            //    row.Cells[0].Value = rw[0].ToString();
            //    row.Cells[1].Value = rw[1].ToString();
            //    row.Cells[2].Value = rw[2].ToString();
            //    row.Cells[3].Value = rw[3].ToString();
            //    row.Cells[4].Value = rw[4].ToString();
            //    row.Cells[5].Value = rw[5].ToString();
            //    row.Cells[6].Value = rw[6].ToString();
            //    row.Cells[7].Value = rw[7].ToString();
            //    row.Cells[8].Value = rw[8].ToString();
            //    row.Cells[9].Value = rw[9].ToString();
            //    row.Cells[10].Value = rw[10].ToString();
            //    row.Cells[11].Value = rw[11].ToString();
            //    row.Cells[12].Value = rw[12].ToString();
            //    row.Cells[13].Value = rw[13].ToString();
            //    row.Cells[14].Value = rw[14].ToString();
            //    row.Cells[15].Value = rw[15].ToString();
            //    row.Cells[16].Value = rw[16].ToString();
            //    row.Cells[17].Value = rw[17].ToString();
            //    row.Cells[18].Value = rw[18].ToString();
            //    row.Cells[19].Value = rw[19].ToString();
            //    row.Cells[20].Value = rw[20].ToString();
            //    row.Cells[21].Value = rw[21].ToString();
            //    row.Cells[22].Value = rw[22].ToString();
            //    row.Cells[23].Value = rw[23].ToString();
            //}
        }
        private void HALLAR_TOTAL_OC()
        {
            decimal impor = 0, dscto = 0, igv = 0, neto = 0, total = 0;
            foreach (DataGridViewRow rw in DGW_DET.Rows)
            {

                if (rw.Cells["st_valor_referencial"].Value.ToString() == "0")
                {
                    impor = impor + Convert.ToDecimal(rw.Cells["VALOR_COMPRA"].Value);
                    dscto = dscto + Convert.ToDecimal(rw.Cells["POR_DSCTO"].Value);
                }

            }
            total = impor;

            neto = total;
            //igv = total - neto;

            //TXT_TB.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(neto.ToString());
            //TXT_TD.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(dscto.ToString());
            //TXT_TN.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(neto.ToString());
            //TXT_TIGV.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(igv.ToString());
            //TXT_TT.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(impor.ToString());
            TXT_TB.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES((impor - igv).ToString());
            TXT_TD.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(dscto.ToString());
            TXT_TN.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES((impor - igv).ToString());
            TXT_TIGV.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(igv.ToString());
            TXT_TT.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(impor.ToString());
        }
        private void CARGAR_COMBOS_PRESUPUESTO(int idx)
        {
            if (DGW_PRES_PTE.Rows.Count > 0)
            {
                //int idx = DGW_PRES_PTE.CurrentRow.Index;
                dtCombos.Rows.Clear();
                DataRow rw = dtCombos.NewRow();
                rw["cod_suc"] = DGW_PRES_PTE[0, idx].Value.ToString();
                rw["desc_suc"] = DGW_PRES_PTE[1, idx].Value.ToString();
                rw["cod_cla"] = DGW_PRES_PTE[2, idx].Value.ToString();
                rw["desc_cla"] = DGW_PRES_PTE[3, idx].Value.ToString();
                rw["cod_mon"] = DGW_PRES_PTE[8, idx].Value.ToString();
                rw["desc_mon"] = DGW_PRES_PTE[9, idx].Value.ToString();
                rw["cod_pro"] = DGW_PRES_PTE[30, idx].Value.ToString();
                rw["desc_pro"] = DGW_PRES_PTE[31, idx].Value.ToString();
                rw["cod_sem"] = DGW_PRES_PTE[33, idx].Value.ToString();
                rw["desc_sem"] = DGW_PRES_PTE[34, idx].Value.ToString();
                rw["cod_pla"] = DGW_PRES_PTE[35, idx].Value.ToString();
                if (rw["cod_pla"].ToString().Trim() == "D")
                    rw["desc_pla"] = "DIRECTA";
                else if (rw["cod_pla"].ToString().Trim() == "DP")
                    rw["desc_pla"] = "DIRECTA/PLANILLA";
                else if (rw["cod_pla"].ToString().Trim() == "P")
                    rw["desc_pla"] = "PLANILLA";
                else if (rw["cod_pla"].ToString().Trim() == "PD")
                    rw["desc_pla"] = "PLANILLA/DIRECTA";
                rw["cod_pag"] = DGW_PRES_PTE[14, idx].Value.ToString();
                rw["desc_pag"] = DGW_PRES_PTE[15, idx].Value.ToString();
                rw["cod_ven"] = DGW_PRES_PTE[24, idx].Value.ToString();
                rw["desc_ven"] = DGW_PRES_PTE[25, idx].Value.ToString();
                rw["cod_dig"] = DGW_PRES_PTE[19, idx].Value.ToString();
                rw["desc_dig"] = DGW_PRES_PTE[20, idx].Value.ToString();
                //
                rw["cod_sub_pto_ven"] = DGW_PRES_PTE.Rows[idx].Cells["COD_SUB_PTO_VEN"].Value.ToString();
                rw["desc_sub_pto_ven"] = DGW_PRES_PTE.Rows[idx].Cells["DESC_PTO_VEN"].Value.ToString();
                rw["cod_can_dscto"] = DGW_PRES_PTE.Rows[idx].Cells["COD_CANAL_DSCTO"].Value.ToString();
                rw["desc_can_dscto"] = DGW_PRES_PTE.Rows[idx].Cells["DESCRIPCION"].Value.ToString();
                rw["cod_pto_cob"] = DGW_PRES_PTE.Rows[idx].Cells["COD_PTO_COB"].Value.ToString();
                rw["desc_pto_cob"] = DGW_PRES_PTE.Rows[idx].Cells["DESC_PTO_COB"].Value.ToString();
                //
                rw["cod_tipo_vta"] = DGW_PRES_PTE.Rows[idx].Cells["COD_TIPO_VENTA"].Value.ToString();
                rw["desc_tipo_vta"] = DGW_PRES_PTE.Rows[idx].Cells["DESC_TIPO_VENTA"].Value.ToString();
                //
                rw["cod_mod_vta"] = DGW_PRES_PTE.Rows[idx].Cells["COD_MODALIDAD_VTA"].Value.ToString();
                rw["desc_mod_vta"] = DGW_PRES_PTE.Rows[idx].Cells["DESC_MODALIDAD_VTA"].Value.ToString();
                //
                rw["cod_lug_vta"] = DGW_PRES_PTE.Rows[idx].Cells["COD_LUG_VTA"].Value.ToString();
                rw["desc_lug_vta"] = DGW_PRES_PTE.Rows[idx].Cells["DESC_LUG_VTA"].Value.ToString();
                dtCombos.Rows.Add(rw);
            }
        }
        private void CARGAR_COMBOS_PEDIDO()
        {
            if (dgw1.Rows.Count > 0)
            {
                int idx = dgw1.CurrentRow.Index;
                dtCombos.Rows.Clear();
                DataRow rw = dtCombos.NewRow();
                rw["cod_suc"] = dgw1.Rows[idx].Cells["COD_SUCURSAL"].Value.ToString();//dgw1[0, idx].Value.ToString();
                rw["desc_suc"] = dgw1.Rows[idx].Cells["Sucursal"].Value.ToString();//dgw1[1, idx].Value.ToString();
                rw["cod_cla"] = dgw1.Rows[idx].Cells["COD_CLASE"].Value.ToString();//dgw1[2, idx].Value.ToString();
                rw["desc_cla"] = dgw1.Rows[idx].Cells["Clase"].Value.ToString();//dgw1[3, idx].Value.ToString();
                rw["cod_mon"] = dgw1.Rows[idx].Cells["COD_MONEDA"].Value.ToString();//dgw1[8, idx].Value.ToString();
                rw["desc_mon"] = dgw1.Rows[idx].Cells["Desc_moneda"].Value.ToString();//dgw1[9, idx].Value.ToString();
                rw["cod_pro"] = dgw1.Rows[idx].Cells["COD_PROGRAMA"].Value.ToString();//dgw1[30, idx].Value.ToString();
                rw["desc_pro"] = dgw1.Rows[idx].Cells["DESC_PROGRAMA"].Value.ToString();//dgw1[31, idx].Value.ToString();
                rw["cod_sem"] = dgw1.Rows[idx].Cells["NRO_SEMANA"].Value.ToString();//dgw1[33, idx].Value.ToString();
                rw["desc_sem"] = dgw1.Rows[idx].Cells["NOM_SEMANA"].Value.ToString();//dgw1[34, idx].Value.ToString();
                rw["cod_pla"] = dgw1.Rows[idx].Cells["TIPO_PLANILLA"].Value.ToString();//dgw1[35, idx].Value.ToString();
                //if (rw["cod_pla"].ToString().Trim() == "D")
                //    rw["desc_pla"] = "DIRECTA";
                //else if (rw["cod_pla"].ToString().Trim() == "DP")
                //    rw["desc_pla"] = "DIRECTA/PLANILLA";
                //else if (rw["cod_pla"].ToString().Trim() == "P")
                //    rw["desc_pla"] = "DESCUENTO";
                //else if (rw["cod_pla"].ToString().Trim() == "PD")
                //    rw["desc_pla"] = "PLANILLA/DIRECTA";
                rw["desc_pla"] = dgw1.Rows[idx].Cells["DESC_TIPO_PLANILLA"].Value.ToString();
                rw["cod_pag"] = dgw1.Rows[idx].Cells["FORMA_PAGO"].Value.ToString();//dgw1[14, idx].Value.ToString();
                rw["desc_pag"] = dgw1.Rows[idx].Cells["FORMA_PAGO_TIPO"].Value.ToString();//dgw1[15, idx].Value.ToString();
                rw["cod_ven"] = dgw1.Rows[idx].Cells["CONDICION_VENTA"].Value.ToString();//dgw1[24, idx].Value.ToString();
                rw["desc_ven"] = dgw1.Rows[idx].Cells["DESC_TIPO"].Value.ToString();//dgw1[25, idx].Value.ToString();
                rw["cod_dig"] = dgw1.Rows[idx].Cells["COD_PER_ELAB"].Value.ToString();//dgw1[19, idx].Value.ToString();
                rw["desc_dig"] = dgw1.Rows[idx].Cells["DESC_PER_ELAB"].Value.ToString();//dgw1[20, idx].Value.ToString();
                //
                rw["cod_sub_pto_ven"] = dgw1.Rows[idx].Cells["COD_SUB_PTO_VEN"].Value.ToString();
                rw["desc_sub_pto_ven"] = dgw1.Rows[idx].Cells["DESC_PTO_VEN"].Value.ToString();
                rw["cod_can_dscto"] = dgw1.Rows[idx].Cells["COD_CANAL_DSCTO"].Value.ToString();
                rw["desc_can_dscto"] = dgw1.Rows[idx].Cells["DESCRIPCION"].Value.ToString();
                rw["cod_pto_cob"] = dgw1.Rows[idx].Cells["COD_PTO_COB"].Value.ToString();
                rw["desc_pto_cob"] = dgw1.Rows[idx].Cells["DESC_PTO_COB"].Value.ToString();
                //
                rw["cod_tipo_vta"] = dgw1.Rows[idx].Cells["COD_TIPO_VENTA"].Value.ToString();
                rw["desc_tipo_vta"] = dgw1.Rows[idx].Cells["DESC_TIPO_VENTA"].Value.ToString();
                //
                rw["cod_mod_vta"] = dgw1.Rows[idx].Cells["COD_MODALIDAD_VTA"].Value.ToString();
                rw["desc_mod_vta"] = dgw1.Rows[idx].Cells["DESC_MODALIDAD_VTA"].Value.ToString();
                //
                rw["cod_lug_vta"] = dgw1.Rows[idx].Cells["COD_LUG_VTA"].Value.ToString();
                rw["desc_lug_vta"] = dgw1.Rows[idx].Cells["DESC_LUG_VTA"].Value.ToString();
                dtCombos.Rows.Add(rw);
            }

        }
        private void LIMPIAR_CABECERA()
        {
            TXT_COD.Clear();
            txt_oc.Clear();
            txt_cod2.Clear();
            txt_desc2.Clear();
            //CBO_CLASE.Items.Clear();
            //CBO_CONTACTO.SelectedIndex = -1;
            CBO_PAGO.SelectedIndex = -1;
            //cbo_envio.SelectedIndex = -1;
            cbo_VENTA.SelectedIndex = -1;
            //CBO_TIPO_ORIGEN.SelectedIndex = -1;
            //CBO_TIPO_DIR.SelectedIndex = -1;
            //TXT_DIR_ENTREGA.Clear();
            cbo_movimiento.SelectedIndex = 1;
            TXT_DESC.Clear();
            txt_doc_per.Clear();
            //TXT_NI.Clear();
            CBO_PERSONAL.SelectedIndex = 0;
            //TXT_OBS_ENTREGA.Clear();
            CBO_SUCURSAL.Enabled = true;
            CBO_CLASE.Enabled = true;
            TXT_COD.Enabled = true;
            TXT_DESC.Enabled = true;
            txt_doc_per.Enabled = true;
            CBO_MONEDA.SelectedIndex = -1;
            CBO_MONEDA.Enabled = true;
            txt_numero.Clear();
            //Panel_PER.Visible = false;
            //gb_oc.Enabled = true;//LO 
            //DGW_DET.Rows.Clear();
            DGW_DET.DataSource = null;
            DGW_DET.Enabled = true;
            //gb_DEntrega.Enabled = true;
            //CH_DIFERIDO.Checked = false;
            //CBO_TIPO_ORIGEN.Text = obj.DIR_TABLA_DESC("ORIGEN", "TDEFA");
            CARGAR_PRESUPUESTOS_PENDIENTES();
            //ofr.DGW.Rows.Clear()

            //COD_PRECIO1 = obj.DIR_TABLA_DESC("PRECIO", "TDEFA")
            //cbo_precio1.Text = obj.DESC_TIPO_PRECIO(COD_PRECIO1)
        }
        private void btn_grabar2_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("¿ Esta seguro de Modificar el Contrato ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                ccTo.COD_SUCURSAL = CBO_SUCURSAL.SelectedValue.ToString();
                ccTo.NRO_DOC = txt_nro.Text + "-" + txt_numero1.Text;
                ccTo.COD_PER = TXT_COD.Text;
                ccTo.COD_CLASE = CBO_CLASE.SelectedValue.ToString();
                ccTo.FE_AÑO = AÑO;
                ccTo.FE_MES = MES;
                ccTo.COD_MOV = cbo_movimiento.SelectedValue.ToString();
                ccTo.COD_PER_ELAB = CBO_PERSONAL.SelectedValue.ToString();
                ccTo.FECHA_DOC = dtp_fecha.Value;
                ccTo.FEC_PRIMER_VENC = dtp_vctoc.Value;
                ccTo.FEC_CUO_MEN = dtp_fmen.Value;
                if (!ccBLL.modificarContratoBLL(ccTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("El Contrato se Modifico correctamente", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TabControl1.SelectedTab = TabPage1;
                    DATAGRID();
                    CARGAR_PRESUPUESTOS_PENDIENTES();
                    FOCO_NUEVO_REG2(txt_numero.Text);
                }
            }
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            TabControl1.SelectedTab = TabPage3;
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btn_obse_Click(object sender, EventArgs e)
        {

        }

        private void BTN_GRABAR_Click(object sender, EventArgs e)
        {
            if (!validaGrabar())
                return;

            DialogResult rs = MessageBox.Show("¿ Esta seguro de crear un nuevo Contrato ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                ccTo.COD_SUCURSAL = CBO_SUCURSAL.SelectedValue.ToString();
                ccTo.NRO_DOC = txt_nro.Text + "-" + txt_numero1.Text;//LO CAMBIO POR TXT_NI
                ccTo.COD_PER = TXT_COD.Text;
                ccTo.COD_CLASE = CBO_CLASE.SelectedValue.ToString();
                ccTo.FE_AÑO = AÑO;
                ccTo.FE_MES = MES;
                ccTo.FECHA_DOC = dtp_fecha.Value;
                ccTo.NRO_PRESUPUESTO = txt_numero.Text;
                ccTo.FECHA_PRE = DTP_DOC.Value;
                ccTo.COD_MONEDA = CBO_MONEDA.SelectedValue.ToString();
                ccTo.TIPO_CAMBIO = Convert.ToDecimal(TXT_TC.Text);
                ccTo.FORMA_PAGO = CBO_PAGO.SelectedValue.ToString();
                ccTo.STATUS_PV = CH_PV.Checked ? "1" : "0";
                ccTo.NRO_DIAS = Convert.ToInt32(txt_nro_dias.Text);
                ccTo.COD_PER_ELAB = CBO_PERSONAL.SelectedValue.ToString();
                ccTo.COD_PER_APROB = "";
                ccTo.STATUS_APROB = "";
                ccTo.STATUS_ANUL = "";
                ccTo.STATUS_CIERRE = "";
                ccTo.COD_VENDEDOR = txt_cod2.Text;
                ccTo.CONDICION_VENTA = cbo_VENTA.SelectedValue != null ? cbo_VENTA.SelectedValue.ToString() : "";
                ccTo.COD_CONTACTO = "";
                ccTo.FECHA_APROB = null;
                ccTo.TIPO_PRECIO = "";
                ccTo.OBSERVACION = obs2.txt_obs.Text;
                ccTo.COD_MOV = cbo_movimiento.SelectedValue.ToString();
                ccTo.NRO_REPORTE = txt_oc.Text;
                ccTo.FEC_REPORTE = dtp_oc.Value;
                ccTo.COD_PROGRAMA = cbo_prog.SelectedValue.ToString();
                ccTo.PERIODO = txt_mes.Text;
                ccTo.NRO_SEMANA = cbo_semana.SelectedValue.ToString();
                ccTo.TIPO_PLANILLA = cbo_tipo_planilla.SelectedValue.ToString();
                ccTo.COD_ALMACEN = cbo_alm.SelectedValue.ToString();
                ccTo.COD_NIVEL1 = coddirnac;
                ccTo.COD_NIVEL2 = coddir;
                ccTo.COD_NIVEL3 = codsup;
                ccTo.SUELDO_NETO = txtsbas.Text.Trim() == "" ? 0 : Convert.ToDecimal(txtsbas.Text);
                ccTo.PRESTAMOS = txtsbru.Text.Trim() == "" ? 0 : Convert.ToDecimal(txtsbru.Text);
                ccTo.JUDICIALES = txt_judicial.Text.Trim() == "" ? 0 : Convert.ToDecimal(txt_judicial.Text);
                ccTo.OTROS_DSCTOS = txt_otro_desc.Text.Trim() == "" ? 0 : Convert.ToDecimal(txt_otro_desc.Text);
                ccTo.IMPORTE_PROTECCION = txt_imp_proteccion.Text.Trim() == "" ? 0 : Convert.ToDecimal(txt_imp_proteccion.Text);
                ccTo.NETO_COBRAR = txt_neto_cob.Text.Trim() == "" ? 0 : Convert.ToDecimal(txt_neto_cob.Text);
                //idx0 = DGW_PRES_PTE.CurrentRow.Index;
                ccTo.TOTAL_CONTRATO = Convert.ToDecimal(DGW_PRES_PTE[45, idx0].Value);
                ccTo.NRO_CUOTAS = Convert.ToInt32(DGW_PRES_PTE[46, idx0].Value);
                ccTo.IMP_CUOTA_INICIAL = Convert.ToDecimal(DGW_PRES_PTE[47, idx0].Value);
                ccTo.IMP_CUOTA_MES = Convert.ToDecimal(DGW_PRES_PTE[48, idx0].Value);
                ccTo.FEC_PRIMER_VENC = dtp_vctoc.Value;
                ccTo.NRO_DIAS_VENC = Convert.ToInt32(DGW_PRES_PTE[50, idx0].Value);
                ccTo.FEC_CUO_MEN = dtp_fmen.Value;
                ccTo.STATUS_FAC = "";
                ccTo.TIPO_PEDIDO = "";
                ccTo.STATUS_GUIA = "";
                ccTo.COD_REF = "";
                ccTo.NRO_REF = "";
                ccTo.NOMBRE_PC = NOMBRE_PC;
                ccTo.SERIE = txt_nro.Text;
                ccTo.COD_SUB_PTO_VEN = cboptovta.SelectedValue.ToString();
                ccTo.COD_CANAL_DSCTO = cbocandesc.SelectedValue.ToString();
                ccTo.COD_PTO_COB = cboptocob.SelectedValue.ToString();
                ccTo.COD_TIPO_VENTA = cbo_tipo_venta.SelectedValue.ToString();
                ccTo.COD_MODALIDAD_VTA = cbo_modalidad_venta.SelectedValue.ToString();
                ccTo.COD_LUG_VTA = cbo_lug_vta.SelectedValue.ToString();
                ccTo.COD_INSTITUCION = COD_INSTITUCION;

                //DataTable dtDetalle = (DataTable)DGW_DET.DataSource;
                ccTo.NRO_DOC_INV = HALLAR_NRO_SALIDA();
                DT00.Rows.Clear();
                DT01.Rows.Clear();
                int num = DGW_DET.Rows.Count - 1;
                int num3 = num;
                int i = 0;
                while (i <= num3)
                {
                    DT00.Rows.Add(CBO_SUCURSAL.SelectedValue.ToString(), txt_nro.Text + "-" + txt_numero1.Text, "", TXT_COD.Text, CBO_CLASE.SelectedValue.ToString(),
                        AÑO, MES, (i + 1).ToString("00"), DGW_DET[1, i].Value.ToString(), DGW_DET[3, i].Value.ToString(), DGW_DET[4, i].Value.ToString(), DGW_DET[5, i].Value.ToString(),
                        DGW_DET[6, i].Value.ToString(), DGW_DET[7, i].Value.ToString(), DGW_DET[8, i].Value.ToString(), DGW_DET[9, i].Value.ToString(),
                        DGW_DET[10, i].Value.ToString(), DGW_DET[11, i].Value.ToString(), DGW_DET[12, i].Value.ToString(), DGW_DET[13, i].Value.ToString(),
                        DGW_DET[14, i].Value.ToString(), DGW_DET[15, i].Value.ToString(), DGW_DET[16, i].Value.ToString(), NOMBRE_PC, DGW_DET.Rows[i].Cells["NRO_PRESUPUESTO"].Value.ToString(),
                        DGW_DET[0, i].Value.ToString(), DGW_DET[19, i].Value.ToString(), DGW_DET.Rows[i].Cells["DESC_ARTICULO"].Value.ToString(), DGW_DET[21, i].Value.ToString(), "0",
                        DGW_DET.Rows[i].Cells["ST_VALOR_REFERENCIAL"].Value.ToString());
                    //
                    DT01.Rows.Add(CBO_SUCURSAL.SelectedValue.ToString(), CBO_CLASE.SelectedValue.ToString(), TXT_COD.Text, "02",
                        ccTo.NRO_DOC_INV, AÑO, MES, (i + 1).ToString("00"), DGW_DET[0, i].Value.ToString(),
                        DGW_DET[1, i].Value.ToString(), DGW_DET[3, i].Value.ToString(), 0, "H", "S", ccTo.COD_ALMACEN, DGW_DET[6, i].Value.ToString(),
                        DGW_DET[7, i].Value.ToString(), DGW_DET[8, i].Value.ToString(), DGW_DET[9, i].Value.ToString(), DGW_DET[10, i].Value.ToString(),
                        ((igv0 / 100) * Convert.ToDecimal(DGW_DET[11, i].Value)).ToString(), DGW_DET[12, i].Value.ToString(),
                        DGW_DET[13, i].Value.ToString(), DGW_DET[14, i].Value.ToString(), "", "0", NOMBRE_PC, ccTo.NRO_PRESUPUESTO, ccTo.FECHA_PRE, DGW_DET[16, i].Value.ToString());
                    i++;
                }
                if (!ccBLL.adicionaInsertaContratoBLL(ccTo, DT00, DT01, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("El Contrato se creo correctamente", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TabControl1.SelectedTab = TabPage1;
                    DATAGRID();
                    CARGAR_PRESUPUESTOS_PENDIENTES();
                    FOCO_NUEVO_REG2(txt_numero.Text);
                }
            }

        }
        public string HALLAR_NRO_SALIDA()
        {
            int sr = -1;
            sdTo.COD_SUCURSAL = CBO_SUCURSAL.SelectedValue.ToString();
            sdTo.SERIE = "001";
            sdTo.COD_DOC = "02";
            sr = sdBLL.obtenerNro_IngBLL(sdTo);
            return "001-" + sr.ToString("0000000");
        }
        private bool validaGrabar()
        {
            bool result = true;
            if (cbo_movimiento.SelectedIndex <= -1)
            {
                MessageBox.Show("Elija el valor del Movimiento !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_movimiento.Focus();
                return result = false;
            }
            if (CBO_PERSONAL.SelectedIndex <= -1)
            {
                MessageBox.Show("Elija la persona digitadora !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                CBO_PERSONAL.Focus();
                return result = false;
            }
            return result;
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            TabControl1.SelectedTab = TabPage1;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            TabControl1.SelectedTab = TabPage3;
        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            if (!validaModificarEliminar("No se puede Modificar"))
                return;
            BOTON = "MODIFICAR";
            //INDICE = dgw1.CurrentRow.Index;
            BTN_GRABAR.Visible = false;
            btn_grabar2.Visible = true;
            btn_grabar2.Enabled = true;
            btn_Imprimir.Enabled = false;

            TabControl1.SelectedTab = TabPage2;
            //'Panel1.Visible = True
            //'Panel2.Visible = False
            //'Panel0.Enabled = True
            LIMPIAR_CABECERA();
            CARGAR_COMBOS_PEDIDO();
            //CARGAR_DATOS_PEDIDO();
            CARGAR_DATOS();
            CARGAR_DETALLES_DGW();//btn_Modificar
            //cbo_ni.Visible = false;
            //TXT_NI.Visible = true;
            //gb_oc.Enabled = false;
            txtalm.Text = cbo_alm.Text;
            HALLAR_TOTAL_OC();
            cbo_movimiento.Focus();
        }
        private void CARGAR_DATOS()
        {
            int idx = dgw1.CurrentRow.Index;
            CBO_SUCURSAL.ValueMember = "cod_suc";
            CBO_SUCURSAL.DisplayMember = "desc_suc";
            CBO_SUCURSAL.DataSource = dtCombos;
            CBO_SUCURSAL.SelectedIndex = 0;
            CBO_CLASE.ValueMember = "cod_cla";
            CBO_CLASE.DisplayMember = "desc_cla";
            CBO_CLASE.DataSource = dtCombos;
            CBO_CLASE.SelectedIndex = 0;
            CBO_MONEDA.ValueMember = "cod_mon";
            CBO_MONEDA.DisplayMember = "desc_mon";
            CBO_MONEDA.DataSource = dtCombos;
            CBO_MONEDA.SelectedIndex = 0;
            cbo_prog.ValueMember = "cod_pro";
            cbo_prog.DisplayMember = "desc_pro";
            cbo_prog.DataSource = dtCombos;
            cbo_prog.SelectedIndex = 0;
            cbo_semana.ValueMember = "cod_sem";
            cbo_semana.DisplayMember = "desc_sem";
            cbo_semana.DataSource = dtCombos;
            cbo_semana.SelectedIndex = 0;
            cbo_tipo_planilla.ValueMember = "cod_pla";
            cbo_tipo_planilla.DisplayMember = "desc_pla";
            cbo_tipo_planilla.DataSource = dtCombos;
            cbo_tipo_planilla.SelectedIndex = 0;
            CBO_PAGO.ValueMember = "cod_pag";
            CBO_PAGO.DisplayMember = "desc_pag";
            CBO_PAGO.DataSource = dtCombos;
            CBO_PAGO.SelectedIndex = 0;
            cbo_VENTA.ValueMember = "cod_ven";
            cbo_VENTA.DisplayMember = "desc_ven";
            cbo_VENTA.DataSource = dtCombos;
            cbo_VENTA.SelectedIndex = 0;
            //CBO_PERSONAL.ValueMember = "cod_dig";
            //CBO_PERSONAL.DisplayMember = "desc_dig";
            //CBO_PERSONAL.DataSource = dtCombos;
            //CBO_PERSONAL.SelectedIndex = 0;
            CBO_PERSONAL.SelectedValue = dgw1.Rows[idx].Cells["COD_PER_ELAB"].Value;//dgw1[19, idx].Value;
            lbl_institucion.Text = dgw1.Rows[idx].Cells["DESC_INST"].Value.ToString();
            lblNivelInstitucion.Text = Convert.ToString(dgw1.Rows[idx].Cells["NOM_NIVEL_INSTITUCION"].Value);
            txt_nro.Text = dgw1[4, idx].Value.ToString().Substring(0, 3);
            txt_numero1.Text = dgw1[4, idx].Value.ToString().Substring(4, 7);
            TXT_COD.Text = dgw1.Rows[idx].Cells["COD_PER"].Value.ToString();//dgw1[5, idx].Value.ToString();
            TXT_DESC.Text = dgw1.Rows[idx].Cells["Cliente"].Value.ToString();//dgw1[6, idx].Value.ToString();
            txt_doc_per.Text = dgw1.Rows[idx].Cells["DNI"].Value.ToString();//dgw1[7, idx].Value.ToString();
            txt_numero.Text = dgw1.Rows[idx].Cells["NRO_PRESUPUESTO"].Value.ToString();//4
            TXT_TC.Text = dgw1.Rows[idx].Cells["TIPO_CAMBIO"].Value.ToString();//dgw1[13, idx].Value.ToString();
            txt_oc.Text = dgw1.Rows[idx].Cells["NRO_REPORTE"].Value.ToString();//dgw1[28, idx].Value.ToString();
            dtp_oc.Value = Convert.ToDateTime(dgw1.Rows[idx].Cells["FEC_REPORTE"].Value);//
            txt_mes.Text = dgw1.Rows[idx].Cells["PERIODO"].Value.ToString();//dgw1[32, idx].Value.ToString();
            DTP_DOC.Value = Convert.ToDateTime(dgw1.Rows[idx].Cells["FECHA_PRE"].Value);//12
            txt_nro_dias.Text = dgw1.Rows[idx].Cells["NRO_DIAS"].Value.ToString();//dgw1[18, idx].Value.ToString();
            obs2.txt_obs.Text = dgw1.Rows[idx].Cells["OBS"].Value.ToString(); //dgw1[16, idx].Value.ToString();
            txtsbas.Text = dgw1.Rows[idx].Cells["SUELDO_NETO"].Value.ToString();//dgw1[40, idx].Value.ToString();
            txtsbru.Text = dgw1.Rows[idx].Cells["PRESTAMOS"].Value.ToString();//dgw1[41, idx].Value.ToString();
            txt_otro_desc.Text = dgw1.Rows[idx].Cells["OTROS_DSCTOS"].Value.ToString();//dgw1[42, idx].Value.ToString();
            txt_judicial.Text = dgw1.Rows[idx].Cells["JUDICIALES"].Value.ToString();//dgw1[43, idx].Value.ToString();
            txt_imp_proteccion.Text = dgw1.Rows[idx].Cells["IMPORTE_PROTECCION"].Value.ToString();
            txt_neto_cob.Text = dgw1.Rows[idx].Cells["NETO_COBRAR"].Value.ToString();//dgw1[44, idx].Value.ToString();
            txt_cod2.Text = dgw1.Rows[idx].Cells["COD_VENDEDOR"].Value.ToString();//dgw1[21, idx].Value.ToString();
            txt_desc2.Text = dgw1.Rows[idx].Cells["DESC_PER"].Value.ToString();//dgw1[22, idx].Value.ToString();
            //
            txt_tot.Text = dgw1.Rows[idx].Cells["TOTAL_CONTRATO"].Value.ToString();//dgw1[45, idx].Value.ToString();
            txtncuo.Text = dgw1.Rows[idx].Cells["NRO_CUOTAS"].Value.ToString();//dgw1[46, idx].Value.ToString();
            txt_ci.Text = dgw1.Rows[idx].Cells["IMP_CUOTA_INICIAL"].Value.ToString();//dgw1[47, idx].Value.ToString();
            txtcuotas.Text = dgw1.Rows[idx].Cells["IMP_COUTA_MES"].Value.ToString();//dgw1[48, idx].Value.ToString();
            //dtp_vctoc.Value = dgw1[49, idx].Value.ToString() == "" ? DateTime.Now : Convert.ToDateTime(dgw1[49, idx].Value);
            dtp_vctoc.Value = dgw1.Rows[idx].Cells["FEC_PRIMER_VENC"].Value.ToString() == "" ? DateTime.Now : Convert.ToDateTime(dgw1.Rows[idx].Cells["FEC_PRIMER_VENC"].Value);
            txt_ndvcto.Text = dgw1.Rows[idx].Cells["NRO_DIAS_VENC"].Value.ToString();//dgw1[50, idx].Value.ToString();
            //dtp_fmen.Value = dgw1[51, idx].Value.ToString() == "" ? DateTime.Now : Convert.ToDateTime(dgw1[51, idx].Value);
            dtp_fmen.Value = dgw1.Rows[idx].Cells["FEC_CUO_MEN"].Value.ToString() == "" ? DateTime.Now : Convert.ToDateTime(dgw1.Rows[idx].Cells["FEC_CUO_MEN"].Value);
            dtp_fecha.Value = Convert.ToDateTime(dgw1.Rows[idx].Cells["FECHA_DOC"].Value);
            //
            CH_PV.Checked = dgw1.Rows[idx].Cells["STATUS_PV"].Value.ToString() == "1" ? true : false;//dgw1[17, idx].Value.ToString() == "1" ? true : false;
            cbo_movimiento.SelectedValue = dgw1.Rows[idx].Cells["COD_MOV"].Value.ToString(); //dgw1[54, idx].Value;
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
            cboptovta.ValueMember = "cod_sub_pto_ven";
            cboptovta.DisplayMember = "desc_sub_pto_ven";
            cboptovta.DataSource = dtCombos;
            cbocandesc.ValueMember = "cod_can_dscto";
            cbocandesc.DisplayMember = "desc_can_dscto";
            cbocandesc.DataSource = dtCombos;
            cboptocob.ValueMember = "cod_pto_cob";
            cboptocob.DisplayMember = "desc_pto_cob";
            cboptocob.DataSource = dtCombos;
            cbo_tipo_venta.ValueMember = "cod_tipo_vta";
            cbo_tipo_venta.DisplayMember = "desc_tipo_vta";
            cbo_tipo_venta.DataSource = dtCombos;
            cbo_modalidad_venta.ValueMember = "cod_mod_vta";
            cbo_modalidad_venta.DisplayMember = "desc_mod_vta";
            cbo_modalidad_venta.DataSource = dtCombos;
            cbo_lug_vta.ValueMember = "cod_lug_vta";
            cbo_lug_vta.DisplayMember = "desc_lug_vta";
            cbo_lug_vta.DataSource = dtCombos;
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
        private bool validaDesAprobarContrato()
        {
            bool result = true;
            string errMensaje = "";
            canjeICtasxCobrarBLL cicBLL = new canjeICtasxCobrarBLL();
            canjeICtasxCobrarTo cicTo = new canjeICtasxCobrarTo();
            cicTo.COD_SUCURSAL = Convert.ToString(dgw1.CurrentRow.Cells["COD_SUCURSAL"].Value);
            cicTo.COD_CLASE = Convert.ToString(dgw1.CurrentRow.Cells["COD_CLASE"].Value);
            cicTo.NRO_CONTRATO = Convert.ToString(dgw1.CurrentRow.Cells["NRO_PRESUPUESTO"].Value);
            if (cicBLL.verifica_Movimiento_ContratoBLL(cicTo, ref errMensaje))
            {
                MessageBox.Show("El contrato ya ha realizado algún movimiento \nvaya al Kardex del Cliente !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return result = false;
            }
            return result;
        }
        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (!validaDesAprobarContrato())
                return;

            DialogResult rs = MessageBox.Show("¿ Esta seguro de desaprobar el contrato " +
                Convert.ToString(dgw1.CurrentRow.Cells["NRO_PRESUPUESTO"].Value) + " ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                DTEliminar = HelpersBLL.obtenerEstructuraGrid(dgw1);
                DataRow row = DTEliminar.NewRow();
                row["COD_SUCURSAL"] = Convert.ToString(dgw1.CurrentRow.Cells["COD_SUCURSAL"].Value);
                row["COD_CLASE"] = Convert.ToString(dgw1.CurrentRow.Cells["COD_CLASE"].Value);
                row["COD_PER"] = Convert.ToString(dgw1.CurrentRow.Cells["COD_PER"].Value);
                row["NRO_PRESUPUESTO"] = Convert.ToString(dgw1.CurrentRow.Cells["NRO_PRESUPUESTO"].Value);
                row["FE_AÑO"] = Convert.ToString(dgw1.CurrentRow.Cells["FE_AÑO"].Value);
                row["FE_MES"] = Convert.ToString(dgw1.CurrentRow.Cells["FE_MES"].Value);
                DTEliminar.Rows.Add(row);

                if (!pccBLL.eliminaContratoVentasBLL(pccTo, DTEliminar, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Se eliminó correctamente el contrato !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //btn_imprimir.Enabled = true;
                    //DATAGRID() : FOCO_NUEVO_REG();
                    DATAGRID(); //FOCO_NUEVO_REG(txt_numero.Text.Trim());
                    //
                    foreach (Form form in Application.OpenForms)
                    {
                        if (modulos_ventas.pedido2 != null && form.GetType() == typeof(Presentacion.MOD_VTA.PEDIDO2))
                        {
                            modulos_ventas.pedido2.DATAGRID();
                        }
                    }
                }
            }

            //string errMensaje = "";
            //string str4, str2, str3, str6, str, str5, nro_doc_inv = "";
            //int idx = dgw1.CurrentRow.Index;
            //str4 = dgw1.Rows[idx].Cells["COD_SUCURSAL"].Value.ToString();//dgw1[0, idx].Value.ToString();
            //str2 = dgw1.Rows[idx].Cells["COD_CLASE"].Value.ToString();//dgw1[2, idx].Value.ToString();
            //str3 = dgw1.Rows[idx].Cells["COD_PER"].Value.ToString();//dgw1[5, idx].Value.ToString();
            ////str6 = dgw1[4, idx].Value.ToString();
            //str6 = dgw1.CurrentRow.Cells["NRO_PRESUPUESTO"].Value.ToString();
            //str = dgw1.Rows[idx].Cells["FE_AÑO"].Value.ToString();//dgw1[10, idx].Value.ToString();
            //str5 = dgw1.Rows[idx].Cells["FE_MES"].Value.ToString();//dgw1[11, idx].Value.ToString();
            //nro_doc_inv = dgw1.Rows[idx].Cells["NRO_DOC_INV"].Value.ToString();
            //DialogResult rs = MessageBox.Show("¿ Esta seguro de eliminar el Contrato Nº " + str6 + " ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (rs == DialogResult.Yes)
            //{
            //    if (TIPO_USU != "MS")
            //    {
            //        DIALOGOS.frmValidarEliminarAnular frm = new DIALOGOS.frmValidarEliminarAnular();
            //        frm.Label2.Visible = false;
            //        frm.txtObservacion.Visible = false;
            //        frm.cargar_usuario("VTA");
            //        frm.cboUsuario.Focus();
            //        if (frm.ShowDialog() == DialogResult.OK)
            //        {
            //            string pass = frm.txtContraseña.Text;
            //            string claveEncriptada = HelpersBLL.ENCRIPTAR(pass.ToUpper());
            //            string codigo = perBLL.ValidarUsuarioEliminacionAnulacionBLL(claveEncriptada, frm.cboUsuario.Text);
            //            int RSLT = perBLL.ValidarDirectorioDesaprobarBLL(codigo, "VTA");
            //            if (RSLT > 0)
            //            {
            //                eliminaContrato(str4, str2, str3, str6, str, str5,nro_doc_inv, ref errMensaje);
            //                this.Dispose();
            //            }
            //            else
            //                MessageBox.Show("Usted no tiene permisos !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //        }
            //        frm.Dispose();
            //    }
            //    else
            //    {
            //        eliminaContrato(str4, str2, str3, str6, str, str5,nro_doc_inv, ref errMensaje);
            //    }
            //    DATAGRID();
            //    CARGAR_PRESUPUESTOS_PENDIENTES();
            //}
        }
        private void eliminaContrato(string str4, string str2, string str3, string str6, string str, string str5, string nro_doc_inv, ref string errMensaje)
        {
            ccTo.COD_SUCURSAL = str4;
            ccTo.COD_CLASE = str2;
            ccTo.COD_PER = str3;
            ccTo.NRO_PRESUPUESTO = str6;
            ccTo.FE_AÑO = str;
            ccTo.FE_MES = str5;
            ccTo.NRO_DOC_INV = nro_doc_inv;
            if (!ccBLL.ELIMINAR_PEDIDO_PRESUPUESTO_BLL(ccTo, ref errMensaje))
            {
                MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("EL CONTRATO SE ELIMINO !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        public bool validaModificarEliminar(string titulo)
        {
            bool result = true;
            if (dgw1.Rows.Count <= 0)
            {
                MessageBox.Show("No existen registros !!!", titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return result = false;
            }
            if (Convert.ToBoolean(dgw1.CurrentRow.Cells["Fact"].Value))
            {
                MessageBox.Show("El Contrato está Facturado", titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return result = false;
            }
            if (Convert.ToBoolean(dgw1.CurrentRow.Cells["Cie."].Value))
            {
                MessageBox.Show("El Contrato está Cerrado", titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return result = false;
            }
            //if (Convert.ToBoolean(dgw1.CurrentRow.Cells["Aprob"].Value))
            //{
            //    MessageBox.Show("El Contrato está Aprobado", titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return result = false;
            //}
            //if (Convert.ToBoolean(dgw1.CurrentRow.Cells["Anul"].Value))
            //{
            //    MessageBox.Show("El Contrato está Anulado", titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return result = false;
            //}
            return result;
        }
        private void btn_consulta_Click(object sender, EventArgs e)
        {
            if (dgw1.Rows.Count > 0)
            {
                BOTON = "MODIFICAR";
                BTN_GRABAR.Visible = false;
                btn_grabar2.Visible = false;
                btn_Imprimir.Enabled = true;
                TabControl1.SelectedTab = TabPage2;
                LIMPIAR_CABECERA();
                CARGAR_COMBOS_PEDIDO();
                ////'---------------------------groupxbox de cabeceras
                //gb_oc.Enabled = false;
                //GroupBox3.Enabled = false;
                //GroupBox2.Enabled = false;
                //GB_VENTA.Enabled = False
                //gb_DEntrega.Enabled = False
                //'---------------------------
                CARGAR_DATOS();
                CARGAR_DETALLES_DGW();//Consulta
                cbo_ni.Visible = false;
                txt_nro.Visible = false;
                CH_PV.Visible = false;
                btn_Imprimir.Focus();
                btn_ajuste.Enabled = false;
                HALLAR_TOTAL_OC();
            }
        }

        private void btn_aprobado_Click(object sender, EventArgs e)
        {
            if (!validarAprobado())
                return;
            DIALOGOS.APROBADO_POR aprob = new DIALOGOS.APROBADO_POR(FECHA_INI, FECHA_GRAL, TIPO_USU, "Contrato");
            aprob.a_COD_SUCURSAL3 = dgw1[0, dgw1.CurrentRow.Index].Value.ToString();
            aprob.a_COD_CLASE3 = dgw1[2, dgw1.CurrentRow.Index].Value.ToString();
            aprob.a_COD_PER3 = dgw1[5, dgw1.CurrentRow.Index].Value.ToString();
            aprob.a_NRO_DOC3 = dgw1.CurrentRow.Cells["NRO_PRESUPUESTO"].Value.ToString();//dgw1[4, dgw1.CurrentRow.Index].Value.ToString();
            aprob.AÑO0 = dgw1[10, dgw1.CurrentRow.Index].Value.ToString();
            aprob.MES0 = dgw1[11, dgw1.CurrentRow.Index].Value.ToString();
            //aprob.DTP_DOC.Value = FECHA_GRAL;
            aprob.ShowDialog();
            string cont2 = dgw1.CurrentRow.Cells["NRO_PRESUPUESTO"].Value.ToString();//dgw1[4, dgw1.CurrentRow.Index].Value.ToString();
            DATAGRID();
            FOCO_NUEVO_REG2(cont2);
        }
        private void FOCO_NUEVO_REG2(string cont2)
        {
            int i, cont = 0;
            cont = dgw1.Columns.Count - 1;
            string nrocon = cont2;
            for (i = 0; i <= cont; i++)
            {
                if (nrocon == dgw1.Rows[i].Cells["NRO_PRESUPUESTO"].Value.ToString().ToLower())//dgw1[4, i].Value.ToString().ToLower())
                {
                    dgw1.CurrentCell = dgw1.Rows[i].Cells["NRO_PRESUPUESTO"];
                    return;
                }
            }
        }
        private bool validarAprobado()
        {
            bool result = true;
            if (dgw1.Rows.Count <= 0)//APROBADO
            {
                MessageBox.Show("No existen registros a aprobar !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return result = false;
            }
            //if (Convert.ToBoolean(dgw1[52, dgw1.CurrentRow.Index].Value))//APROBADO
            //{
            //    MessageBox.Show("El Contrato se encuentra aprobado !!!", "YA SE ENCUENTRA APROBADO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return result = false;
            //}
            if (Convert.ToBoolean(dgw1[56, dgw1.CurrentRow.Index].Value))//CERRADO
            {
                MessageBox.Show("El Contrato se encuentra totalmente enviado !!!", "YA SE ENCUENTRA CERRADO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return result = false;
            }
            return result;
        }

        private void btn_cierre_Click(object sender, EventArgs e)
        {
            if (!validaCierre())
                return;

            string errMensaje = "";
            string str5 = dgw1[0, dgw1.CurrentRow.Index].Value.ToString();
            string str3 = dgw1[2, dgw1.CurrentRow.Index].Value.ToString();
            string str4 = dgw1[5, dgw1.CurrentRow.Index].Value.ToString();
            string str7 = dgw1[4, dgw1.CurrentRow.Index].Value.ToString();
            string str2 = dgw1[10, dgw1.CurrentRow.Index].Value.ToString();
            string str6 = dgw1[11, dgw1.CurrentRow.Index].Value.ToString();
            DialogResult rs = MessageBox.Show("¿ Esta seguro de cerrar el Contrato Nº " + str7 + " ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                ccTo.COD_SUCURSAL = str5;
                ccTo.COD_CLASE = str3;
                ccTo.COD_PER = str4;
                ccTo.NRO_DOC = str7;
                ccTo.FE_AÑO = str2;
                ccTo.FE_MES = str6;
                if (!ccBLL.cerrarContratoBLL(ccTo, ref errMensaje))
                {
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("El Contrato se cerro correctamente", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //TabControl1.SelectedTab = TabPage1;
                    DATAGRID();
                    btn_nuevo.Focus();
                }
            }
        }
        private bool validaCierre()
        {
            bool result = true;
            if (dgw1.Rows.Count <= 0)//APROBADO
            {
                MessageBox.Show("No existen registros a Cerrar !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return result = false;
            }
            if (Convert.ToBoolean(dgw1[56, dgw1.CurrentRow.Index].Value))//CERRADO
            {
                MessageBox.Show("El Contrato se encuentra totalmente enviado !!!", "YA SE ENCUENTRA CERRADO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return result = false;
            }
            return result;
        }

        private void btn_anul_Click(object sender, EventArgs e)
        {
            if (!validaAnulado())
                return;

            //AQUI FALTA
        }
        private bool validaAnulado()
        {
            bool result = true;
            if (dgw1.Rows.Count <= 0)
            {
                MessageBox.Show("No existen registros a Anular !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return result = false;
            }
            if (Convert.ToBoolean(dgw1.Rows[dgw1.CurrentRow.Index].Cells["Fact"].Value))//FACTURADO
            {
                MessageBox.Show("El Contrato se encuentra facturado !!!", "YA SE ENCUENTRA FACTURADO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return result = false;
            }
            return result;
        }

        private void cboptovta_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cboptovta.SelectedValue != null)
            //{
            //    puntoVentaBLL ptvBLL = new puntoVentaBLL();
            //    puntoVentaTo ptvTo = new puntoVentaTo();
            //    ptvTo.COD_PTO_VEN = cboptovta.SelectedValue.ToString();
            //    DataTable dt = ptvBLL.obtenerPuntoVentaConsolidadoBLL(ptvTo);
            //    if (dt.Rows.Count > 0)
            //        lblptovtacons.Text = dt.Rows[0][0].ToString();
            //    else
            //        lblptovtacons.Text = "";
            //}
        }

        private void dtp_vctoc_ValueChanged(object sender, EventArgs e)
        {
            dtp_fmen.Value = dtp_vcto.Value.AddMonths(1);
        }

        private void btn_PreAprob_Click(object sender, EventArgs e)
        {
            if (!validarAprobado())
                return;
            DIALOGOS.PRE_APROBADO_POR aprob = new DIALOGOS.PRE_APROBADO_POR(FECHA_INI, FECHA_GRAL, TIPO_USU);
            aprob.a_COD_SUCURSAL3 = dgw1[0, dgw1.CurrentRow.Index].Value.ToString();
            aprob.a_COD_CLASE3 = dgw1[2, dgw1.CurrentRow.Index].Value.ToString();
            aprob.a_COD_PER3 = dgw1[5, dgw1.CurrentRow.Index].Value.ToString();
            aprob.a_NRO_DOC3 = dgw1[4, dgw1.CurrentRow.Index].Value.ToString();
            aprob.AÑO0 = dgw1[10, dgw1.CurrentRow.Index].Value.ToString();
            aprob.MES0 = dgw1[11, dgw1.CurrentRow.Index].Value.ToString();
            //aprob.DTP_DOC.Value = FECHA_GRAL;
            aprob.ShowDialog();
            //string cont2 = dgw1[4, dgw1.CurrentRow.Index].Value.ToString();
            string cont2 = dgw1.CurrentRow.Cells["NRO_PRESUPUESTO"].Value.ToString();
            DATAGRID();
            FOCO_NUEVO_REG2(cont2);
        }

        private void btn_deshacer_Click(object sender, EventArgs e)
        {

        }

        private void btn_refrescar_Click(object sender, EventArgs e)
        {
            DATAGRID();
        }

        private void txt_letra_TextChanged(object sender, EventArgs e)
        {
            int i;
            if (ch_cod.Checked)
            {
                txt_letra.Focus();
                for (i = 0; i < dgw1.Rows.Count; i++)
                {
                    if (txt_letra.TextLength <= dgw1.Rows[i].Cells["NRO_PRESUPUESTO"].Value.ToString().Length)
                    {
                        if (txt_letra.Text.ToLower() == dgw1.Rows[i].Cells["NRO_PRESUPUESTO"].Value.ToString().Substring(0, txt_letra.TextLength).ToLower())
                        {
                            dgw1.CurrentCell = dgw1.Rows[i].Cells["NRO_PRESUPUESTO"];
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
                dgw1.Sort(dgw1.Columns["NRO_PRESUPUESTO"], System.ComponentModel.ListSortDirection.Ascending);
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

        private void TabPage2_Click(object sender, EventArgs e)
        {

        }
    }
}


