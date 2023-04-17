using BLL;
using Entidades;
using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Windows.Forms;
namespace Presentacion.MOD_ALM
{
    public partial class NOTA_INGRESO_DIRECTA : Form
    {
        string AÑO = "", MES = "", COD_MOD = "", COD_USU = "", TIPO_USU = "";
        string COD_SUCURSAL = "", COD_ACT = "", COD_MOV = "", COD_CONTACTO = "", COD_DH = "", COD_MONEDA = "", COD_ELABORADO = "";
        DateTime FECHA_INI, FECHA_GRAL;
        string boton = "", STATUS_PV = "", TIPO_OPERACION = "", COD_CLASE = "", ST_SERIE = "", COD_DOC = "";
        decimal igv0 = 0; int fila;
        DataTable dt00 = new DataTable();
        DataTable DtSerie = new DataTable();
        HelpersBLL helBLL = new HelpersBLL();
        HelpersTo helTo = new HelpersTo();
        inventariosBLL invBLL = new inventariosBLL();
        inventariosTo invTo = new inventariosTo();
        serieDocumentoBLL srdBLL = new serieDocumentoBLL();
        serieDocumentosTo srdTo = new serieDocumentosTo();
        articuloUbicacionBLL almBLL = new articuloUbicacionBLL();
        articuloUbicacionTo almTo = new articuloUbicacionTo();
        string NOMBRE_PC = System.Environment.MachineName;
        public NOTA_INGRESO_DIRECTA(string AÑO, string MES, DateTime FECHA_INI, DateTime FECHA_GRAL, string COD_MOD, string TIPO_USU, string COD_USU)
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

        private void NOTA_INGRESO_DIRECTA_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            DATAGRID();
            CARGAR_CLASE();
            CARGAR_MOVIMIENTO();
            CARGAR_SUCURSAL();
            CARGAR_PERSONAS();
            CARGAR_MONEDA();
            CARGAR_PERSONAS_PERSONAL();
            COD_DH = "D";
            DOCUMENTOS();

            //EstadoEnabledAnular();
            igv0 = helBLL.obtenerImpuestoBLL("IGV");
            TXT_IGV.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(igv0.ToString());
            TXT_IGV2.Text = TXT_IGV.Text;

            dt00.Columns.Add("sucursal");//
            dt00.Columns.Add("Clase");//
            dt00.Columns.Add("Cod_per");//
            dt00.Columns.Add("COD_DOC");//
            dt00.Columns.Add("NRO_DOC_INV");//
            dt00.Columns.Add("Fe_año");//
            dt00.Columns.Add("Fe_mes");//
            dt00.Columns.Add("Item");//
            dt00.Columns.Add("Item2");//
            dt00.Columns.Add("Articulo");
            dt00.Columns.Add("Cantidad");
            dt00.Columns.Add("Cantidad_anul");
            dt00.Columns.Add("COD_D_H");
            dt00.Columns.Add("COD_MONEDA");
            dt00.Columns.Add("COD_ALMACEN");
            dt00.Columns.Add("Precio_Unit");
            dt00.Columns.Add("Valor_COmpra");
            dt00.Columns.Add("Por_igv");
            dt00.Columns.Add("Por_Dscto");
            dt00.Columns.Add("Status_igv");
            dt00.Columns.Add("Valor_IGV");
            dt00.Columns.Add("Valor_Dscto");
            dt00.Columns.Add("Ajuste_igv");
            dt00.Columns.Add("Ajuste_Bi");
            dt00.Columns.Add("COD_AREA");
            dt00.Columns.Add("STATUS_FACT");
            dt00.Columns.Add("Nombre_pc");
            dt00.Columns.Add("NRO_PEDIDO");
            dt00.Columns.Add("FECHA_PEDIDO");
            dt00.Columns.Add("OBSERVACION");
            dt00.Columns.Add("COD_COND_DEV");

            btn_nuevo.Select();
        }
        private void DATAGRID()
        {
            invTo.FE_AÑO = AÑO;
            invTo.FE_MES = MES;
            invTo.TIPO_USU = TIPO_USU;
            invTo.COD_USU = COD_USU;
            DataTable dt = invBLL.obtenerInventariosBLL(invTo);
            DataView dv = dt.AsEnumerable().Where(x => x.Field<string>("TIPO_ORIGEN").Trim() == "").AsDataView();
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
            //dgw1.Columns[20].Visible = false;
            dgw1.Columns[1].Width = (90);
            dgw1.Columns[3].Width = (90);
            dgw1.Columns[4].Width = (80);
            dgw1.Columns[6].Width = (195);
            dgw1.Columns[10].Width = (75);
            dgw1.Columns[10].DefaultCellStyle.Format = ("d");
            dgw1.Columns[12].Width = (80);
            dgw1.Columns[15].Width = (30);
            dgw1.Columns[18].Width = (30);
            dgw1.Columns[20].Width = (30);
            dgw1.Columns[21].Width = (30);
        }
        private void DOCUMENTOS()
        {
            DataTable dt = helBLL.obtenerDesc_Doc_GestionBLL();
            cbo_tipo_doc.ValueMember = "COD_DOC";
            cbo_tipo_doc.DisplayMember = "DESC_DOC";
            cbo_tipo_doc.DataSource = dt;
            cbo_tipo_doc.SelectedIndex = -1;
        }
        private void CARGAR_PERSONAS_PERSONAL()
        {
            //cbo_elab.Items.Clear();
            personalBLL perBLL = new personalBLL();
            DataTable dt = perBLL.obtenerPersonalparaInventarioBLL();
            cbo_elab.ValueMember = "COD_PER";
            cbo_elab.DisplayMember = "DESC_PER";
            cbo_elab.DataSource = dt;
            cbo_elab.SelectedIndex = -1;
        }
        private void CARGAR_MOVIMIENTO()
        {
            movimientosBLL movBLL = new movimientosBLL();
            DataTable dt = movBLL.obtenerMovimientosparaInventarioBLL();
            cbo_mov.ValueMember = "COD_MOV";
            cbo_mov.DisplayMember = "DESC_MOV";
            cbo_mov.DataSource = dt;
            cbo_mov.SelectedIndex = -1;
        }
        private void CARGAR_MONEDA()
        {
            DataTable dt = helBLL.obtenerMonedaBLL();
            CBO_MONEDA.ValueMember = "COD_MONEDA";
            CBO_MONEDA.DisplayMember = "desc_moneda";
            CBO_MONEDA.DataSource = dt;
            //CBO_MONEDA.SelectedItem = -1;
        }
        private void CARGAR_PERSONAS()
        {
            DataTable dt = helBLL.MOSTRAR_PERSONAS_XPAGAR_BLL();
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
        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            boton = "NUEVO";
            BTN_GRABAR.Visible = true;
            btn_grabar2.Visible = false;
            cbo_ni.Visible = true;
            TXT_NI.Visible = false;
            TabControl1.SelectedTab = (TabPage2);
            LIMPIAR_CABECERA();
            Panel1.Visible = true;
            Panel2.Visible = false;
            Panel0.Enabled = true;
            BTN_GRABAR.Enabled = true;
            TXT_NI.Text = "001";
            //txt_numero.Text = "000000" + (dgw1.Rows.Count + 1).ToString(); 
            cbo_sucursal.Focus();

        }
        private void LIMPIAR_CABECERA()
        {
            TXT_COD.Clear();
            TXT_DESC.Clear();
            txt_doc_per.Clear();
            txt_obs.Clear();
            txt_nro_doc.Clear();
            DGW_DET.Rows.Clear();
            gb_oc.Enabled = true;
            GB2.Enabled = true;
            TXT_TB.Text = "0.00";
            TXT_TD.Text = "0.00";
            TXT_TN.Text = "0.00";
            TXT_TT.Text = "0.00";
            TXT_TIGV.Text = "0.00";
            btn_mod.Enabled = true;
            //dtp_inv.Value = Convert.ToDateTime(DateTime.Now.Day + "/" + FECHA_INI.Month + "/" + FECHA_INI.Year);
            dtp_inv.Value = HelpersBLL.validaFecha(MES, AÑO, FECHA_GRAL);
            //dtp_doc.Value = Convert.ToDateTime(DateTime.Now.Day + "/" + FECHA_INI.Month + "/" + FECHA_INI.Year);
            dtp_doc.Value = dtp_inv.Value;
            cbo_elab.SelectedIndex = -1;
        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            //gb_oc.Enabled = false;
            //GB2.Enabled = false;
            Panel1.Visible = false;
            Panel2.Visible = true;
            btn_guardar2.Visible = true;
            btn_mod2.Visible = false;
            LIMPIAR_DETALLES();
            TXT_COD_PRO.Enabled = true;
            TXT_DESC_PRO.Enabled = true;
            TXT_NRO_PARTE.Enabled = true;
            cbo_almacen.SelectedIndex = 0;
            TXT_COD_PRO.Focus();
        }
        private void LIMPIAR_DETALLES()
        {
            TXT_COD_PRO.Clear();
            TXT_DESC_PRO.Clear();
            TXT_NRO_PARTE.Clear();
            TXT_CANT.Clear();
            TXT_PU.Clear();
            //TXT_SERIE.Clear();
            //CBO_AREA.SelectedIndex = -1;
            //CBO_MAQ.SelectedIndex = -1;
            //CBO_PARTE.SelectedIndex = -1;
            TXT_DSCTO.Text = "0.00";
            TXT_DSCTO.ReadOnly = false;
            TXT_DSCTO.Text = "0.00";
            Panel_PRO.Visible = false;
            txt_pu1.Text = "0.00";
            txt_bruto1.Text = "0.00";
            txt_dscto1.Text = "0.00";
            txt_neto1.Text = "0.00";
            txt_igv1.Text = "0.00";
            txt_total1.Text = "0.00";
            //btn_serie.Enabled = false;
        }

        private void btn_guardar2_Click(object sender, EventArgs e)
        {
            if (!validaAdicionaModificaItem())
                return;

            if (TXT_DESC.Text == "")
                TXT_DESC.Text = "0.00";
            string strCodAlmacen = cbo_almacen.SelectedValue.ToString();
            HALLAR_VALOR_VENTA();
            string STATUS_IGV = "0";
            if (CH_IGV.Checked)
                STATUS_IGV = "1";

            string strNroReq = "", strActividad = "", strCodArea = "", strArea = "", strMaq = "", strCodParte = "", strParte = "";
            almTo.COD_ALMACEN = cbo_almacen.SelectedValue.ToString();
            almTo.COD_ARTICULO = TXT_COD_PRO.Text;
            string strUbicacion = almBLL.obtenerArticuloUbicacionparaInventarioBLL(almTo);
            DGW_DET.Rows.Add((hallar_item(DGW_DET.Rows.Count)), TXT_COD_PRO.Text, TXT_DESC_PRO.Text, HelpersBLL.OBTIENE_PRECIO_TRES_DECIMALES(TXT_CANT.Text),
    HelpersBLL.OBTIENE_PRECIO_TRES_DECIMALES(txt_pu1.Text), HelpersBLL.OBTIENE_PRECIO_TRES_DECIMALES(txt_bruto1.Text), TXT_IGV.Text, TXT_DSCTO.Text, STATUS_IGV, txt_igv1.Text,
    txt_dscto1.Text, "0.00", "0.00", strCodAlmacen, cbo_almacen.Text, TXT_NRO_PARTE.Text, "", "", "", strNroReq,
    COD_ACT, strActividad, strCodArea, strArea, "", strMaq, strCodParte, strParte, strUbicacion, "");
            HALLAR_TOTAL_OC();
            LIMPIAR_DETALLES();
            TXT_COD_PRO.Focus();
            //decimal cant = Convert.ToDecimal(TXT_CANT.Text);
            //decimal preu = Convert.ToDecimal(TXT_PU.Text);
            //decimal imp = cant*preu;
            //DGW_DET.Rows.Add("0" + (DGW_DET.Rows.Count + 1).ToString(), TXT_COD_PRO.Text, TXT_DESC_PRO.Text, cant.ToString(), preu.ToString(),imp.ToString()); 
        }
        private void HALLAR_TOTAL_OC()
        {
            decimal impor = 0, dscto = 0, igv = 0, neto = 0, total = 0;
            foreach (DataGridViewRow rw in DGW_DET.Rows)
            {
                impor = impor + Convert.ToDecimal(rw.Cells[5].Value);
                dscto = dscto + Convert.ToDecimal(rw.Cells[10].Value);
                igv = igv + Convert.ToDecimal(rw.Cells[9].Value);
                neto = impor - dscto;
                total = neto + igv;
            }
            TXT_TB.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(impor.ToString());
            TXT_TD.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(dscto.ToString());
            TXT_TN.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(neto.ToString());
            TXT_TIGV.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(igv.ToString());
            TXT_TT.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(total.ToString());
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
                //if (CH_PV.Checked)
                //    txt_pu1.Text = TXT_PU.Text;// (Convert.ToDecimal(TXT_PU.Text) * (100 / (100 + igv0))).ToString();
                //else
                //    txt_pu1.Text = TXT_PU.Text;

                //txt_bruto1.Text = (((Convert.ToDecimal(txt_pu1.Text) * Convert.ToDecimal(TXT_CANT.Text)))).ToString();
                //txt_dscto1.Text = (Convert.ToDecimal(txt_bruto1.Text) * (Convert.ToDecimal(TXT_DSCTO.Text)) / 100).ToString();
                //txt_neto1.Text = (((Convert.ToDecimal(txt_bruto1.Text) - Convert.ToDecimal(txt_dscto1.Text)))).ToString();
                //txt_igv1.Text = (((Convert.ToDecimal(txt_neto1.Text) * (Convert.ToDecimal(TXT_IGV.Text) / 100)))).ToString();
                //txt_total1.Text = (Decimal.Add(Decimal.Parse(txt_neto1.Text), Decimal.Parse(txt_igv1.Text))).ToString();
                //txt_pu1.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(txt_pu1.Text);
                //txt_neto1.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(txt_neto1.Text);
                //txt_igv1.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(txt_igv1.Text);
                //txt_total1.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(txt_total1.Text);
                //txt_dscto1.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(txt_dscto1.Text);
                if (CH_PV.Checked)
                    txt_pu1.Text = (Convert.ToDecimal(TXT_PU.Text) * (100 / (100 + igv0))).ToString();
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
        private bool validaAdicionaModificaItem()
        {
            bool result = true;
            if (TXT_COD_PRO.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el producto !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TXT_COD_PRO.Focus();
                return result = false;
            }
            if (Panel_PRO.Visible == true)
            {
                MessageBox.Show("Ingrese el producto !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                DGW_PRO.Focus();
                return result = false;
            }
            if (cbo_almacen.SelectedIndex == -1)
            {
                MessageBox.Show("Elija el almacen !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_almacen.Focus();
                return result = false;
            }
            if (TXT_CANT.Text.Trim() == "" || TXT_CANT.Text == "0.000")
            {
                MessageBox.Show("Ingrese la cantidad !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TXT_CANT.Focus();
                return result = false;
            }
            if (TXT_PU.Text.Trim() == "" || TXT_PU.Text == "0.000")
            {
                MessageBox.Show("Ingrese el Precio Unitario !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TXT_PU.Focus();
                return result = false;
            }
            return result;
        }
        private void btn_cancelar2_Click(object sender, EventArgs e)
        {
            Panel1.Visible = true;
            Panel2.Visible = false;
            btn_agregar.Focus();
        }

        private void btn_grabar2_Click(object sender, EventArgs e)
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
                //txt_numero.Text = HALLAR_NRO_ING(cbo_ni.Text);
                COD_MOV = cbo_mov.SelectedValue.ToString();
                COD_DOC = cbo_tipo_doc.SelectedValue.ToString();
                COD_ELABORADO = "";
                if (cbo_elab.SelectedIndex != -1)
                {
                    COD_ELABORADO = cbo_elab.SelectedValue.ToString();
                }
                if (CH_PV.Checked)
                    STATUS_PV = "1";
                else
                    STATUS_PV = "0";

                string errMensaje = "";
                invTo.COD_SUCURSAL = COD_SUCURSAL;
                invTo.COD_CLASE = COD_CLASE;
                invTo.COD_PER = TXT_COD.Text;
                //invTo.COD_CLASE_PER = "1";
                //invTo.NRO_DOC_PER = txt_doc_per.Text;
                invTo.COD_DOC_INV = "01";
                invTo.NRO_DOC_INV = TXT_NI.Text + "-" + txt_numero.Text;
                //invTo.SERIE = cbo_ni.Text.Substring(0, 3);
                //invTo.NUMERO = txt_numero.Text;
                invTo.FE_AÑO = AÑO;
                invTo.FE_MES = MES;
                //invTo.COD_MOV = COD_MOV;
                //invTo.COD_MONEDA = COD_MONEDA;
                //invTo.FECHA_DOC_INV = dtp_inv.Value;
                invTo.FECHA_DOC = dtp_doc.Value;
                invTo.COD_DOC = COD_DOC;
                invTo.NRO_DOC = txt_nro_doc.Text;
                invTo.OBSERVACION = txt_obs.Text;
                //invTo.TIPO_CAMBIO = Convert.ToDecimal(TXT_TC.Text);
                //invTo.STATUS_PV = STATUS_PV;
                invTo.COD_USU = COD_USU;
                invTo.FECHA = DateTime.Now;
                invTo.NOMBRE_PC = NOMBRE_PC;
                invTo.COD_ELABORADO = COD_ELABORADO;
                invTo.FECHA_DOC_ARTICULO = dtp_doc.Value;

                dt00.Rows.Clear();
                int num = DGW_DET.Rows.Count - 1;
                int num3 = num;
                //ArrayList ListaSerie = new ArrayList();
                int i = 0;
                while (i <= num3)
                {
                    dt00.Rows.Add(COD_SUCURSAL, COD_CLASE, TXT_COD.Text, "01", (cbo_ni.Text.Substring(0, 3) + "-" + txt_numero.Text),
                    AÑO, MES, DGW_DET[0, i].Value.ToString(), DGW_DET[0, i].Value.ToString(), DGW_DET[1, i].Value.ToString(), DGW_DET[3, i].Value.ToString(), 0, COD_DH,
                    COD_MONEDA, DGW_DET[13, i].Value.ToString(), DGW_DET[4, i].Value.ToString(), DGW_DET[5, i].Value.ToString(), DGW_DET[6, i].Value.ToString(), DGW_DET[7, i].Value.ToString(),
                    DGW_DET[8, i].Value.ToString(), DGW_DET[9, i].Value.ToString(), DGW_DET[10, i].Value.ToString(), DGW_DET[11, i].Value.ToString(), DGW_DET[12, i].Value.ToString(),
                    DGW_DET[22, i].Value.ToString(), "0", NOMBRE_PC, "", DateTime.Now,
                    DGW_DET[16, i].Value.ToString(), "");
                    i++;

                }
                if (!invBLL.modificaActualizaInventariosBLL(invTo, dt00, DtSerie, ref errMensaje))
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
                    DATAGRID();
                    FOCO_NUEVO_REG2();
                    Panel1.Visible = true;
                    Panel2.Visible = false;
                    Panel0.Enabled = false;
                    btn_grabar2.Enabled = false;
                    btn_Imprimir.Enabled = true;
                    btn_Imprimir.Focus();
                }
            }

        }
        private void FOCO_NUEVO_REG2()
        {
            int i, cont = 0;
            cont = dgw1.Rows.Count - 1;
            string nrocon = TXT_NI.Text.Substring(0, 3) + "-" + txt_numero.Text;
            for (i = 0; i <= cont; i++)
            {
                if (nrocon == dgw1[4, i].Value.ToString().ToLower())
                {
                    dgw1.CurrentCell = dgw1.Rows[i].Cells[4];
                    return;
                }
            }
        }
        private void NOTA_INGRESO_DIRECTA_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void BTN_GRABAR_Click(object sender, EventArgs e)
        {
            if (!validaAdicionaModificaNI())
                return;

            DialogResult rs = MessageBox.Show("¿ Esta seguro de adicionar una nueva Nota de Ingreso ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                txt_numero.Text = HALLAR_NRO_ING(cbo_ni.Text);
                COD_MOV = cbo_mov.SelectedValue.ToString();
                COD_DOC = cbo_tipo_doc.SelectedValue.ToString();
                COD_ELABORADO = "";
                if (cbo_elab.SelectedIndex != -1)
                {
                    COD_ELABORADO = cbo_elab.SelectedValue.ToString();
                }
                if (CH_PV.Checked)
                    STATUS_PV = "1";
                else
                    STATUS_PV = "0";

                string errMensaje = "";
                invTo.COD_SUCURSAL = COD_SUCURSAL;
                invTo.COD_CLASE = COD_CLASE;
                invTo.COD_PER = TXT_COD.Text;
                invTo.COD_CLASE_PER = "1";
                invTo.NRO_DOC_PER = txt_doc_per.Text;
                invTo.COD_DOC_INV = "01";
                invTo.NRO_DOC_INV = cbo_ni.Text.Substring(0, 3) + "-" + txt_numero.Text;
                invTo.SERIE = cbo_ni.Text.Substring(0, 3);
                invTo.NUMERO = txt_numero.Text;
                invTo.FE_AÑO = AÑO;
                invTo.FE_MES = MES;
                invTo.COD_MOV = COD_MOV;
                invTo.COD_MONEDA = COD_MONEDA;
                invTo.FECHA_DOC_INV = dtp_inv.Value;
                invTo.FECHA_DOC = dtp_doc.Value;
                invTo.COD_DOC = COD_DOC;
                invTo.NRO_DOC = txt_nro_doc.Text;
                invTo.OBSERVACION = txt_obs.Text;
                invTo.TIPO_CAMBIO = Convert.ToDecimal(TXT_TC.Text);
                invTo.STATUS_PV = STATUS_PV;
                invTo.COD_USU = COD_USU;
                invTo.FECHA = DateTime.Now;
                invTo.NOMBRE_PC = NOMBRE_PC;
                invTo.COD_ELABORADO = COD_ELABORADO;
                invTo.FECHA_DOC_ARTICULO = dtp_doc.Value;
                invTo.COD_MOTIVO_DEVOLUCION = "";
                invTo.TIPO_ORIGEN = "";
                invTo.NRO_PEDIDO = "";

                dt00.Rows.Clear();
                int num = DGW_DET.Rows.Count - 1;
                int num3 = num;
                ArrayList ListaSerie = new ArrayList();
                int i = 0;
                while (i <= num3)
                {
                    dt00.Rows.Add(COD_SUCURSAL, COD_CLASE, TXT_COD.Text, "01", (cbo_ni.Text.Substring(0, 3) + "-" + txt_numero.Text),
                    AÑO, MES, DGW_DET[0, i].Value.ToString(), DGW_DET[0, i].Value.ToString(), DGW_DET[1, i].Value.ToString(), DGW_DET[3, i].Value.ToString(), 0, COD_DH,
                    COD_MONEDA, DGW_DET[13, i].Value.ToString(), DGW_DET[4, i].Value.ToString(), DGW_DET[5, i].Value.ToString(), DGW_DET[6, i].Value.ToString(), DGW_DET[7, i].Value.ToString(),
                    DGW_DET[8, i].Value.ToString(), DGW_DET[9, i].Value.ToString(), DGW_DET[10, i].Value.ToString(), DGW_DET[11, i].Value.ToString(), DGW_DET[12, i].Value.ToString(),
                    DGW_DET[22, i].Value.ToString(), "0", NOMBRE_PC, "", DateTime.Now,
                    DGW_DET[16, i].Value.ToString(), "");
                    i++;
                }

                if (!invBLL.adicionaInsertaInventariosBLL(invTo, dt00, DtSerie, ref errMensaje))
                {
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (!helBLL.ELIMINAR_TEMPORAL("INV", NOMBRE_PC, ref errMensaje))
                        MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    CARGAR_DETALLES_DGW2();
                    //'-------------------------
                    MessageBox.Show("La Nota de Ingreso se guardó", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    srdTo.COD_SUCURSAL = COD_SUCURSAL;
                    srdTo.COD_DOC = "01";
                    srdTo.STATUS_DOC = "0";
                    srdTo.SERIE = cbo_ni.Text;
                    DATAGRID();
                    CARGAR_NRO_INGRESO();
                    FOCO_NUEVO_REG();
                    Panel1.Visible = true;
                    Panel2.Visible = false;
                    Panel0.Enabled = false;
                    BTN_GRABAR.Enabled = false;
                    btn_Imprimir.Enabled = true;
                    btn_Imprimir.Focus();
                }
            }

        }
        private void CARGAR_DETALLES_DGW2()
        {
            DGW_DET.Rows.Clear();
            invTo.COD_CLASE = COD_CLASE;
            invTo.COD_SUCURSAL = COD_SUCURSAL;
            invTo.COD_PER = TXT_COD.Text;
            invTo.COD_DOC_INV = cbo_ni.Text + "-" + txt_numero.Text;
            invTo.FE_AÑO = AÑO;
            invTo.FE_MES = MES;
            bool IGV_CERO;
            int idx;
            DataTable dt = invBLL.obtenerMostrar_Nota_Ingreso_DetalleBLL(invTo);//VER EL SP SE TRAEN MENOS DE LO QUE SE ASIGNA
            foreach (DataRow rw in dt.Rows)
            {
                idx = DGW_DET.Rows.Add();
                IGV_CERO = Convert.ToDecimal(rw[6]) == 0 ? true : false;
                DataGridViewRow row = DGW_DET.Rows[idx];
                row.Cells[0].Value = rw[0].ToString();
                row.Cells[1].Value = rw[1].ToString();
                row.Cells[2].Value = rw[2].ToString();
                row.Cells[3].Value = rw[3].ToString();
                row.Cells[4].Value = rw[4].ToString();
                row.Cells[5].Value = rw[5].ToString();
                row.Cells[6].Value = IGV_CERO == true ? rw[6].ToString() : igv0.ToString();
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
                row.Cells[22].Value = rw[22].ToString();
                row.Cells[23].Value = rw[23].ToString();
                row.Cells[24].Value = rw[24].ToString();
            }
            HALLAR_TOTAL_OC();
            ObtenerSaldoUbicacion();
        }
        private void CARGAR_DETALLES_DGW()
        {
            DGW_DET.Rows.Clear();
            invTo.COD_CLASE = COD_CLASE;
            invTo.COD_SUCURSAL = COD_SUCURSAL;
            invTo.COD_PER = TXT_COD.Text;
            //invTo.COD_DOC_INV = TXT_NI.Text + "-" + txt_numero.Text;
            invTo.NRO_DOC_INV = TXT_NI.Text + "-" + txt_numero.Text;
            invTo.FE_AÑO = AÑO;
            invTo.FE_MES = MES;
            bool IGV_CERO;
            int idx;
            DataTable dt = invBLL.obtenerMostrar_Nota_Ingreso_DetalleBLL(invTo);//VER EL SP SE TRAEN MENOS DE LO QUE SE ASIGNA
            foreach (DataRow rw in dt.Rows)
            {
                idx = DGW_DET.Rows.Add();
                IGV_CERO = Convert.ToDecimal(rw[6]) == 0 ? true : false;
                DataGridViewRow row = DGW_DET.Rows[idx];
                row.Cells[0].Value = rw[0].ToString();
                row.Cells[1].Value = rw[1].ToString();
                row.Cells[2].Value = rw[2].ToString();
                row.Cells[3].Value = rw[3].ToString();
                row.Cells[4].Value = rw[4].ToString();
                row.Cells[5].Value = rw[5].ToString();
                row.Cells[6].Value = IGV_CERO == true ? rw[6].ToString() : igv0.ToString();
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
                row.Cells[22].Value = rw[22].ToString();
                row.Cells[23].Value = rw[23].ToString();
                row.Cells[24].Value = rw[24].ToString();
            }
            HALLAR_TOTAL_OC();
            ObtenerSaldoUbicacion();
        }
        public void ObtenerSaldoUbicacion()
        {
            for (int i = 0; i <= DGW_DET.Rows.Count - 1; i++)
            {
                string articulo = DGW_DET[1, i].Value.ToString();
                string almacen = DGW_DET[13, i].Value.ToString();
                almTo.COD_ARTICULO = articulo;
                almTo.COD_ALMACEN = almacen;
                try
                {
                    DGW_DET[28, i].Value = almBLL.obtenerArticuloUbicacionparaInventarioBLL(almTo);
                }
                catch (Exception)
                {
                    DGW_DET[28, i].Value = "";
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
            if ((TXT_TC.Text == "0.0000" || TXT_TC.Text == "") && CBO_MONEDA.SelectedValue.ToString() == "D")
            {
                MessageBox.Show("Debe ingresar el Tipo de Cambio", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TXT_TC.Focus();
                return result = false;
            }
            if (TXT_COD.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el codigo del Proveedor !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TXT_COD.Focus();
                return result = false;
            }
            if (TXT_DESC.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese la descripcion del Proveedor !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TXT_DESC.Focus();
                return result = false;
            }
            if (cbo_tipo_doc.SelectedIndex == -1)
            {
                MessageBox.Show("Elija el Documento", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_tipo_doc.Focus();
                return result = false;
            }
            if (txt_nro_doc.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el Nº de Documento", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_nro_doc.Focus();
                return result = false;
            }
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
            invTo.COD_SUCURSAL = COD_SUCURSAL;
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
            return result;
        }
        public bool VERIFICAR_DOC_INVENTARIO(inventariosTo invTo, ref bool existe, ref string errMensaje)
        {
            bool result = true;
            if (!invBLL.VERIFICAR_DOC_INVENTARIOBLL(invTo, ref existe, ref errMensaje))
                return result = false;
            return result;
        }
        private void TXT_COD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && TXT_COD.Text.Trim() != "")
            {
                if (dgw_per.Rows.Count > 0)
                {
                    dgw_per.Sort(dgw_per.Columns[0], System.ComponentModel.ListSortDirection.Ascending);
                    int num2 = dgw_per.Rows.Count - 1;
                    int i = 0;
                    while (i <= num2)
                    {
                        if (dgw_per[0, i].Value.ToString().Length >= TXT_COD.TextLength)
                        {
                            if (TXT_COD.Text.ToLower() == dgw_per[0, i].Value.ToString().ToLower().Substring(0, TXT_COD.TextLength))
                            {
                                dgw_per.CurrentCell = dgw_per.Rows[i].Cells[0];
                                break;
                            }
                        }
                        dgw_per.CurrentCell = dgw_per.Rows[0].Cells[0];
                        i += 1;
                    }
                    Panel_PER.Visible = true;
                    dgw_per.Visible = true;
                    Panel_PER.Focus();
                }
                else
                {
                    MessageBox.Show("No existen Persona X Pagar !!!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
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
                        if (dgw_per[1, i].Value.ToString().Length >= TXT_DESC.TextLength)
                        {
                            if (TXT_DESC.Text.ToLower() == dgw_per[1, i].Value.ToString().ToLower().Substring(0, TXT_DESC.TextLength))
                            {
                                dgw_per.CurrentCell = dgw_per.Rows[i].Cells[0];
                                break;
                            }
                        }

                        dgw_per.CurrentCell = dgw_per.Rows[0].Cells[0];
                        i += 1;
                    }
                    Panel_PER.Visible = true;
                    dgw_per.Visible = true;
                    Panel_PER.Focus();
                }
                else
                {
                    MessageBox.Show("No existen Persona X Pagar !!!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
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
                        i += 1;
                    }
                    Panel_PER.Visible = true;
                    dgw_per.Visible = true;
                    Panel_PER.Focus();
                }
                else
                {
                    MessageBox.Show("No existen Persona X Pagar !!!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                KL.Focus();
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

        private void cbo_sucursal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_sucursal.SelectedValue != null)
            {
                if (cbo_sucursal.SelectedIndex > -1)
                {
                    cbo_ni.Enabled = true;
                    COD_SUCURSAL = cbo_sucursal.SelectedValue.ToString();
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
            mvsTo.COD_SUCURSAL = COD_SUCURSAL;
            mvsTo.COD_MOV = COD_MOV;
            mvsTo.STATUS_DOC = "0";
            mvsTo.COD_DOC = "01";
            cbo_ni.ValueMember = "SERIE";
            cbo_ni.DisplayMember = "SERIE";
            cbo_ni.DataSource = mvsBLL.obtenerMovimientoSerieparaInventarioBLL(mvsTo);
        }
        private void CARGAR_ALMACEN()
        {
            almacenesBLL almBLL = new almacenesBLL();
            almacenTo almTo = new almacenTo();
            almTo.COD_CLASE = COD_CLASE;
            almTo.COD_SUCURSAL = COD_SUCURSAL;
            cbo_almacen.ValueMember = "COD_ALMACEN";
            cbo_almacen.DisplayMember = "DESC_CORTA";
            cbo_almacen.DataSource = almBLL.obtenerAlmacenesparaInventarioBLL(almTo);
        }

        private void cbo_clase_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_clase.SelectedValue != null)
            {
                if (cbo_clase.SelectedIndex > -1)
                {
                    COD_CLASE = cbo_clase.SelectedValue.ToString();
                    CARGAR_PRODUCTOS();
                    if (cbo_sucursal.SelectedIndex > -1)
                        CARGAR_ALMACEN();
                }
            }
        }
        private void CARGAR_PRODUCTOS()
        {
            articuloClaseBLL arcBLL = new articuloClaseBLL();
            articuloClaseTo arcTo = new articuloClaseTo();
            arcTo.COD_CLASE = COD_CLASE;
            DGW_PRO.DataSource = arcBLL.obtenerArticuloClaseparaInventarioBLL(arcTo);
            DGW_PRO.Columns[2].Visible = false;
            DGW_PRO.Columns[3].Visible = false;
            DGW_PRO.Columns[4].Visible = false;
        }

        private void cbo_ni_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_ni.SelectedValue != null)
            {
                if (cbo_ni.SelectedIndex > -1)
                    txt_numero.Text = HALLAR_NRO_ING(cbo_ni.Text);
            }
        }
        public string HALLAR_NRO_ING(string serie0)
        {
            int sr = -1;
            srdTo.COD_SUCURSAL = COD_SUCURSAL;
            srdTo.SERIE = serie0;
            srdTo.COD_DOC = "01";
            sr = srdBLL.obtenerNro_IngBLL(srdTo);
            return sr.ToString("0000000");
        }

        private void cbo_mov_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_mov.SelectedValue != null)
            {
                if (cbo_mov.SelectedIndex > -1)
                {
                    txt_numero.Clear();
                    COD_MOV = cbo_mov.SelectedValue.ToString();
                    if (cbo_sucursal.SelectedIndex > -1)
                        CARGAR_NRO_INGRESO();

                }
            }
        }
        private void CBO_MONEDA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBO_MONEDA.SelectedValue != null)
            {
                if (CBO_MONEDA.SelectedIndex > -1)
                {
                    COD_MONEDA = CBO_MONEDA.SelectedValue.ToString();
                    if (COD_MONEDA == "S")
                        TXT_TC.Text = helBLL.SACAR_CAMBIO(dtp_inv.Value.Year.ToString(), HelpersBLL.OBTIENE_CODIGO(2, dtp_inv.Value.Month.ToString()), HelpersBLL.OBTIENE_CODIGO(2, dtp_inv.Value.Day.ToString()), "D");
                    else
                        TXT_TC.Text = helBLL.SACAR_CAMBIO(dtp_inv.Value.Year.ToString(), HelpersBLL.OBTIENE_CODIGO(2, dtp_inv.Value.Month.ToString()), HelpersBLL.OBTIENE_CODIGO(2, dtp_inv.Value.Day.ToString()), COD_MONEDA);

                }
            }
        }

        private void TXT_TC_Leave(object sender, EventArgs e)
        {
            TXT_TC.Text = HelpersBLL.OBTIENE_PRECIO_CUATRO_DECIMALES(TXT_TC.Text);
        }

        private void TXT_COD_PRO_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter && TXT_COD_PRO.Text.Trim() != "")
            //{
            //    if (DGW_PRO.Rows.Count > 0)
            //    {
            //        DGW_PRO.Sort(DGW_PRO.Columns[0], System.ComponentModel.ListSortDirection.Ascending);
            //        int num2 = DGW_PRO.Rows.Count - 1;
            //        int i = 0;
            //        while (i <= num2)
            //        {
            //            if(TXT_COD_PRO.Text.ToLower() == DGW_PRO[0,i].Value.ToString().ToLower())
            //            {
            //                TXT_COD_PRO.Text = DGW_PRO[0, i].Value.ToString();
            //                TXT_DESC_PRO.Text = DGW_PRO[1, i].Value.ToString();
            //                TXT_NRO_PARTE.Text = DGW_PRO[2, i].Value.ToString();
            //                if (DGW_PRO[3, i].Value.ToString() == "0")
            //                    CH_IGV.Checked = false;
            //                else
            //                    CH_IGV.Checked = true;
            //                Panel_PRO.Visible = false;
            //                TXT_CANT.Focus();
            //                return;
            //            }
            //            if (DGW_PRO[0, i].Value.ToString().Length >= TXT_COD_PRO.TextLength)
            //            {
            //                if (TXT_COD_PRO.Text.ToLower() == DGW_PRO[0, i].Value.ToString().ToLower().Substring(0, TXT_COD_PRO.TextLength))
            //                {
            //                    Panel_PRO.Visible = true;
            //                    DGW_PRO.Focus();
            //                    DGW_PRO.CurrentCell = DGW_PRO.Rows[i].Cells[0];
            //                    break;
            //                }
            //            }
            //            else if(HelpersBLL.IsNumeric(TXT_COD_PRO.Text.Trim()) && HelpersBLL.IsNumeric(DGW_PRO[0,i].Value.ToString()))
            //            {
            //                if(Int64.Parse(TXT_COD_PRO.Text.Trim()) == Int64.Parse(DGW_PRO[0,i].Value.ToString()))
            //                {
            //                    DGW_PRO.CurrentCell = DGW_PRO.Rows[i].Cells[0];
            //                    break;
            //                }
            //            }
            //            DGW_PRO.CurrentCell = DGW_PRO.Rows[0].Cells[0];
            //            i += 1;
            //        }
            //        Panel_PRO.Visible = true;
            //        DGW_PRO.Visible = true;
            //        DGW_PRO.Focus();
            //    }
            //    else
            //    {
            //        MessageBox.Show("No existen Productos de la Clase: " + cbo_clase.Text + " !!!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    }
            //}
        }

        private void DGW_PRO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int idx = DGW_PRO.CurrentRow.Index;
                TXT_COD_PRO.Text = DGW_PRO[0, idx].Value.ToString();
                TXT_DESC_PRO.Text = DGW_PRO[1, idx].Value.ToString();
                TXT_NRO_PARTE.Text = DGW_PRO[2, idx].Value.ToString();
                Panel_PRO.Visible = false;
                KL2.Focus();
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

        private void TXT_COD_PRO_Leave(object sender, EventArgs e)
        {
            if (TXT_COD_PRO.Text.Trim() == "")
                return;
            if (DGW_PRO.Rows.Count > 0)
            {
                DGW_PRO.Sort(DGW_PRO.Columns[0], System.ComponentModel.ListSortDirection.Ascending);
                int num2 = DGW_PRO.Rows.Count - 1;
                int i = 0;
                while (i <= num2)
                {
                    if (TXT_COD_PRO.Text.ToLower() == DGW_PRO[0, i].Value.ToString().ToLower())
                    {
                        TXT_COD_PRO.Text = DGW_PRO[0, i].Value.ToString();
                        TXT_DESC_PRO.Text = DGW_PRO[1, i].Value.ToString();
                        TXT_NRO_PARTE.Text = DGW_PRO[2, i].Value.ToString();
                        if (DGW_PRO[3, i].Value.ToString() == "0")
                            CH_IGV.Checked = false;
                        else
                            CH_IGV.Checked = true;
                        Panel_PRO.Visible = false;
                        TXT_CANT.Focus();
                        return;
                    }
                    if (DGW_PRO[0, i].Value.ToString().Length >= TXT_COD_PRO.TextLength)
                    {
                        if (TXT_COD_PRO.Text.ToLower() == DGW_PRO[0, i].Value.ToString().ToLower().Substring(0, TXT_COD_PRO.TextLength))
                        {
                            Panel_PRO.Visible = true;
                            DGW_PRO.Focus();
                            DGW_PRO.CurrentCell = DGW_PRO.Rows[i].Cells[0];
                            break;
                        }
                    }
                    else if (HelpersBLL.IsNumeric(TXT_COD_PRO.Text.Trim()) && HelpersBLL.IsNumeric(DGW_PRO[0, i].Value.ToString()))
                    {
                        if (Int64.Parse(TXT_COD_PRO.Text.Trim()) == Int64.Parse(DGW_PRO[0, i].Value.ToString()))
                        {
                            DGW_PRO.CurrentCell = DGW_PRO.Rows[i].Cells[0];
                            break;
                        }
                    }
                    DGW_PRO.CurrentCell = DGW_PRO.Rows[0].Cells[0];
                    i += 1;
                }
                Panel_PRO.Visible = true;
                DGW_PRO.Visible = true;
                DGW_PRO.Focus();
            }
            else
            {
                MessageBox.Show("No existen Productos de la Clase: " + cbo_clase.Text + " !!!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void TXT_DESC_PRO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && TXT_DESC_PRO.Text.Trim() != "")
            {
                if (DGW_PRO.Rows.Count > 0)
                {
                    DGW_PRO.Sort(DGW_PRO.Columns[1], System.ComponentModel.ListSortDirection.Ascending);
                    int num2 = DGW_PRO.Rows.Count - 1;
                    int i = 0;
                    while (i <= num2)
                    {
                        if (DGW_PRO[1, i].Value.ToString().Length >= TXT_DESC_PRO.TextLength)
                        {
                            if (TXT_DESC_PRO.Text.ToLower() == DGW_PRO[1, i].Value.ToString().ToLower().Substring(0, TXT_DESC_PRO.TextLength))
                            {
                                DGW_PRO.CurrentCell = DGW_PRO.Rows[i].Cells[0];
                                break;
                            }
                        }

                        DGW_PRO.CurrentCell = DGW_PRO.Rows[0].Cells[0];
                        i += 1;
                    }
                    Panel_PRO.Visible = true;
                    Panel_PRO.Focus();
                }
                else
                {
                    MessageBox.Show("No existen Productos de la Clase: " + cbo_clase.Text + " !!!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            HALLAR_VALOR_VENTA();
        }

        private void btn_mod2_Click(object sender, EventArgs e)
        {
            if (!validaAdicionaModificaItem())
                return;

            string str2 = "0";
            string strCodAlmacen = cbo_almacen.SelectedValue.ToString();
            string strNroReq = "", strActividad = "", strCodArea = "", strArea = "", strMaq = "", strCodParte = "", strParte = "";
            almTo.COD_ALMACEN = cbo_almacen.SelectedValue.ToString();
            almTo.COD_ARTICULO = TXT_COD_PRO.Text;
            string strUbicacion = almBLL.obtenerArticuloUbicacionparaInventarioBLL(almTo);

            if (CH_IGV.Checked)
                str2 = "1";
            int num = DGW_DET.CurrentRow.Index;
            DGW_DET[1, num].Value = TXT_COD_PRO.Text;
            DGW_DET[2, num].Value = TXT_DESC_PRO.Text;
            DGW_DET[3, num].Value = HelpersBLL.OBTIENE_PRECIO_TRES_DECIMALES(TXT_CANT.Text);
            DGW_DET[4, num].Value = HelpersBLL.OBTIENE_PRECIO_TRES_DECIMALES(txt_pu1.Text);
            DGW_DET[5, num].Value = HelpersBLL.OBTIENE_PRECIO_TRES_DECIMALES(txt_bruto1.Text);
            DGW_DET[6, num].Value = TXT_IGV.Text;
            DGW_DET[7, num].Value = TXT_DSCTO.Text;
            DGW_DET[8, num].Value = str2;
            DGW_DET[9, num].Value = txt_igv1.Text;
            DGW_DET[10, num].Value = txt_dscto1.Text;
            DGW_DET[13, num].Value = strCodAlmacen;
            DGW_DET[14, num].Value = cbo_almacen.Text;
            DGW_DET[15, num].Value = TXT_NRO_PARTE.Text;
            DGW_DET[16, num].Value = "";
            DGW_DET[19, num].Value = strNroReq;
            DGW_DET[20, num].Value = COD_ACT;
            DGW_DET[21, num].Value = strActividad;
            DGW_DET[22, num].Value = strCodArea;
            DGW_DET[23, num].Value = strArea;
            DGW_DET[24, num].Value = "";
            DGW_DET[25, num].Value = strMaq;
            DGW_DET[26, num].Value = strCodParte;
            DGW_DET[27, num].Value = strParte;
            DGW_DET[28, num].Value = strUbicacion;
            DGW_DET[29, num].Value = "";
            HALLAR_TOTAL_OC();
            Panel2.Visible = false;
            Panel1.Visible = true;
            btn_agregar.Focus();
        }

        private void btn_mod_Click(object sender, EventArgs e)
        {
            try
            {
                int num = DGW_DET.CurrentRow.Index;
            }
            catch (Exception)
            {
                MessageBox.Show("Debe elegir un registro !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            btn_guardar2.Visible = false;
            btn_mod2.Visible = true;
            ITEM.Text = DGW_DET.CurrentRow.Index.ToString();
            Panel1.Visible = false;
            Panel2.Visible = true;
            LIMPIAR_DETALLES();
            CARGAR_DETALLE1();
            TXT_COD_PRO.Enabled = false;
            TXT_DESC_PRO.Enabled = false;
            TXT_NRO_PARTE.Enabled = false;
            Panel_PRO.Visible = false;
            TXT_CANT.Focus();
        }
        private void CARGAR_DETALLE1()
        {
            TXT_COD_PRO.Text = DGW_DET[1, DGW_DET.CurrentRow.Index].Value.ToString();
            TXT_DESC_PRO.Text = DGW_DET[2, DGW_DET.CurrentRow.Index].Value.ToString();
            TXT_CANT.Text = DGW_DET[3, DGW_DET.CurrentRow.Index].Value.ToString();
            TXT_IGV.Text = DGW_DET[6, DGW_DET.CurrentRow.Index].Value.ToString();
            if (DGW_DET[8, DGW_DET.CurrentRow.Index].Value.ToString() == "1")
                CH_IGV.Checked = true;
            else
                CH_IGV.Checked = false;
            if (CH_PV.Checked)
                TXT_PU.Text = HelpersBLL.OBTIENE_PRECIO_TRES_DECIMALES((Convert.ToDecimal(DGW_DET[4, DGW_DET.CurrentRow.Index].Value) * (((100 + Convert.ToDecimal(TXT_IGV.Text)) / 100))).ToString());
            else
                TXT_PU.Text = DGW_DET[4, DGW_DET.CurrentRow.Index].Value.ToString();

            TXT_DSCTO.Text = DGW_DET[7, DGW_DET.CurrentRow.Index].Value.ToString();
            cbo_almacen.Text = DGW_DET[14, DGW_DET.CurrentRow.Index].Value.ToString();
            TXT_NRO_PARTE.Text = DGW_DET[15, DGW_DET.CurrentRow.Index].Value.ToString();
            HALLAR_VALOR_VENTA();
        }

        private void btn_eliminar2_Click(object sender, EventArgs e)
        {
            try
            {
                int num = DGW_DET.CurrentRow.Index;
            }
            catch (Exception)
            {
                MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            DGW_DET.Rows.RemoveAt(DGW_DET.CurrentRow.Index);
            REORDENAR_NRO_ITEM();
            HALLAR_TOTAL_OC();

        }
        private void REORDENAR_NRO_ITEM()
        {
            int it = 0;
            foreach (DataGridViewRow row in DGW_DET.Rows)
            {
                row.Cells[0].Value = hallar_item(it);
                it++;
            }
        }
        private void btn_nuevo3_Click(object sender, EventArgs e)
        {
            boton = "NUEVO";
            BTN_GRABAR.Visible = true;
            btn_grabar2.Visible = false;
            cbo_ni.Visible = true;
            TXT_NI.Visible = false;
            btn_mod.Visible = true;
            LIMPIAR_CABECERA();
            Panel1.Visible = true;
            Panel2.Visible = false;
            Panel0.Enabled = true;
            BTN_GRABAR.Enabled = true;
            cbo_sucursal.Focus();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            TabControl1.SelectedTab = TabPage1;
            btn_nuevo.Focus();
        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            if (!validaModificaNI())
                return;

            boton = "MODIFICAR";
            btn_Imprimir.Enabled = false;
            TabControl1.SelectedTab = TabPage2;
            LIMPIAR_CABECERA();
            BTN_GRABAR.Visible = false;
            btn_grabar2.Visible = true;
            btn_grabar2.Enabled = true;
            gb_oc.Enabled = false;
            GB2.Enabled = true;
            DGW_DET.Enabled = true;
            CARGAR_DATOS();

            CARGAR_DETALLES_DGW();
            Panel1.Visible = true;
            Panel2.Visible = false;
            Panel0.Enabled = true;
            cbo_ni.Visible = false;
            TXT_NI.Visible = true;
            CBO_MONEDA.Enabled = false;
            TXT_TC.Enabled = false;
            CH_PV.Enabled = false;
            HALLAR_TOTAL_OC();
            cbo_sucursal.Focus();
        }
        private void CARGAR_DATOS()
        {
            int idx = dgw1.CurrentRow.Index;
            cbo_ni.SelectedIndex = -1;
            COD_SUCURSAL = dgw1[0, idx].Value.ToString();
            cbo_sucursal.Text = dgw1[1, idx].Value.ToString();
            COD_CLASE = dgw1[2, idx].Value.ToString();
            cbo_clase.Text = dgw1[3, idx].Value.ToString();
            COD_MOV = dgw1[8, idx].Value.ToString();
            cbo_mov.Text = dgw1[9, idx].Value.ToString();
            string str = dgw1[4, idx].Value.ToString();
            TXT_NI.Text = str.Substring(0, 3);
            txt_numero.Text = str.Substring(4, 7);
            TXT_COD.Text = dgw1[5, idx].Value.ToString();
            TXT_DESC.Text = dgw1[6, idx].Value.ToString();
            txt_doc_per.Text = dgw1[7, idx].Value.ToString();

            //CARGAR_STATUS();
            dtp_inv.Value = Convert.ToDateTime(dgw1[10, idx].Value);
            COD_DOC = dgw1[11, idx].Value.ToString();
            cbo_tipo_doc.SelectedValue = COD_DOC;
            txt_nro_doc.Text = dgw1[12, idx].Value.ToString();
            dtp_doc.Value = Convert.ToDateTime(dgw1[13, idx].Value);
            txt_obs.Text = dgw1[14, idx].Value.ToString();
            COD_MONEDA = dgw1[15, idx].Value.ToString();
            CBO_MONEDA.SelectedValue = COD_MONEDA;
            TXT_TC.Text = dgw1[16, idx].Value.ToString();
            STATUS_PV = dgw1[17, idx].Value.ToString();
            COD_ELABORADO = dgw1[19, idx].Value.ToString();
            cbo_elab.SelectedValue = COD_ELABORADO;
        }
        private bool validaModificaNI()
        {
            bool result = true;
            int idx = dgw1.CurrentRow.Index;
            try
            {
                int num = dgw1.CurrentRow.Index;
            }
            catch (Exception)
            {
                MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return result = false;
            }
            if (dgw1[18, idx].Value != null)
            {
                if (Convert.ToBoolean(dgw1[18, idx].Value))
                {
                    MessageBox.Show("La Nota de Ingreso se encuentra facturada.", "No se puede Modificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return result = false;
                }
            }
            if (dgw1[20, idx].Value != null)
            {
                if (Convert.ToBoolean(dgw1[20, idx].Value))
                {
                    MessageBox.Show("La Nota de Ingreso se encuentra anulada.", "No se puede Modificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return result = false;
                }
            }
            if (dgw1[21, idx].Value != null)
            {
                if (Convert.ToBoolean(dgw1[21, idx].Value))
                {
                    MessageBox.Show("La Nota de Ingreso se transfirió a Costos.", "No se puede Modificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return result = false;
                }
            }

            string str5 = dgw1[0, idx].Value.ToString();
            string str3 = dgw1[2, idx].Value.ToString();
            string str4 = dgw1[5, idx].Value.ToString();
            string str = dgw1[4, idx].Value.ToString();
            string errMensaje = ""; bool flag2 = false;
            if (!Verifica_Detalle(str5, str3, str4, str, ref flag2, ref errMensaje))
            {
                MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!flag2)
            {
                MessageBox.Show("Un detalle de la Nota de Ingreso se encuentra facturada", "No se puede modificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return result = false;
            }

            return result;
        }
        private bool Verifica_Detalle(string cod_sucursal0, string cod_clase0, string cod_per0, string nro_doc0, ref bool flag2, ref string errMensaje)
        {
            //string errMensaje = "";
            //bool flag2 = false;
            bool result = true;
            invTo.COD_SUCURSAL = cod_sucursal0;
            invTo.COD_CLASE = cod_clase0;
            invTo.COD_PER = cod_per0;
            invTo.COD_DOC_INV = "01";
            invTo.NRO_DOC_INV = nro_doc0;
            invTo.FE_AÑO = AÑO;
            invTo.FE_MES = MES;
            if (!invBLL.VerificaDetalleBLL(invTo, ref flag2, ref errMensaje))
                return result = false;
            return result;
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (!validaEliminarAnular())
                return;

            string errMensaje = "";
            int idx = dgw1.CurrentRow.Index;
            string str5 = dgw1[0, idx].Value.ToString();
            string str3 = dgw1[2, idx].Value.ToString();
            string str4 = dgw1[5, idx].Value.ToString();
            string str = dgw1[4, idx].Value.ToString();

            DialogResult rs = MessageBox.Show("¿ Esta seguro de eliminar la Nota de Ingreso Nº " + dgw1[4, dgw1.CurrentRow.Index].Value.ToString() + " ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                if (TIPO_USU != "MS")
                {
                    DIALOGOS.frmValidarEliminarAnular frm = new DIALOGOS.frmValidarEliminarAnular();
                    frm.Label2.Visible = false;
                    frm.txtObservacion.Visible = false;
                    frm.cargar_usuario("ALM");
                    frm.cboUsuario.Focus();
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        string pass = frm.txtContraseña.Text;
                        string claveEncriptada = HelpersBLL.ENCRIPTAR(pass.ToUpper());
                        string codigo = helBLL.ValidarUsuarioEliminacionAnulacionBLL(claveEncriptada, frm.cboUsuario.Text);
                        int RSLT = helBLL.ValidarDirectorioDesaprobarBLL(codigo, "ALM");
                        if (RSLT > 0)
                        {
                            eliminaNotaIngreso(str4, "01", str3, str, str5, ref errMensaje);
                            this.Dispose();
                        }
                        else
                            MessageBox.Show("USTED NO TIENE PERMISOS !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    frm.Dispose();
                }
                else
                {
                    eliminaNotaIngreso(str4, "01", str3, str, str5, ref errMensaje);
                }
                DATAGRID();
            }
            btn_nuevo.Select();
        }
        private void eliminaNotaIngreso(string str4, string str2, string str3, string str, string str5, ref string errMensaje)
        {
            invTo.COD_SUCURSAL = str5;
            invTo.COD_CLASE = str3;
            invTo.COD_PER = str4;
            invTo.COD_DOC_INV = str2;
            invTo.NRO_DOC_INV = str;
            invTo.FE_AÑO = AÑO;
            invTo.FE_MES = MES;
            if (!invBLL.ELIMINA_NOTA_INGRESO(invTo, ref errMensaje))
            {
                MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("LA NOTA DE INGRESO SE ELIMINO !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        private bool validaEliminarAnular()
        {
            bool result = true;
            string errMensaje = "";
            int idx = dgw1.CurrentRow.Index;
            try
            {
                int num = dgw1.CurrentRow.Index;
            }
            catch (Exception)
            {
                MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return result = false;
            }
            if (dgw1[18, idx].Value != null)
            {
                if (Convert.ToBoolean(dgw1[18, idx].Value))
                {
                    MessageBox.Show("La Nota de Ingreso se encuentra facturada.", "No se puede Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return result = false;
                }
            }
            if (dgw1[21, idx].Value != null)
            {
                if (Convert.ToBoolean(dgw1[21, idx].Value))
                {
                    MessageBox.Show("La Nota de Ingreso se transfirió a Costos.", "No se puede Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return result = false;
                }
            }
            string str5 = dgw1[0, idx].Value.ToString();
            string str3 = dgw1[2, idx].Value.ToString();
            string str4 = dgw1[5, idx].Value.ToString();
            string str = dgw1[4, idx].Value.ToString();
            bool flag2 = false;
            if (!Verifica_Detalle(str5, str3, str4, str, ref flag2, ref errMensaje))
            {
                MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return result = false; ;
            }
            if (!flag2)
            {
                MessageBox.Show("Un detalle de la Nota de Ingreso se encuentra facturada", "No se puede Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return result = false;
            }
            string str7 = "True";
            if (!VERIFICAR_MOD_NOTA_INGRESO(str5, str3, str, str4, ref str7, ref errMensaje))
            {
                MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return result = false; ;
            }
            if (str7 != "True")
            {
                MessageBox.Show("No existe saldo en el Artículo: " + str7, "No se puede Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return result = false;
            }
            return result;
        }
        private bool VERIFICAR_MOD_NOTA_INGRESO(string str5, string str3, string str, string str4, ref string str7, ref string errMensaje)
        {
            bool result = true;
            invTo.COD_SUCURSAL = str5;
            invTo.COD_CLASE = str3;
            invTo.COD_PER = str;
            invTo.NRO_DOC_INV = str4;
            invTo.FE_AÑO = AÑO;
            invTo.FE_MES = MES;
            if (!invBLL.VERIFICAR_MOD_NOTA_INGRESO(invTo, ref str7, ref errMensaje))
                return result = false;
            return result;

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
            boton = "MODIFICAR";
            BTN_GRABAR.Visible = false;
            btn_grabar2.Visible = false;
            btn_grabar2.Enabled = false;
            btn_Imprimir.Enabled = true;
            TabControl1.SelectedTab = TabPage2;
            LIMPIAR_CABECERA();
            gb_oc.Enabled = false;
            GB2.Enabled = false;
            DGW_DET.Enabled = true;
            CARGAR_DATOS();
            CARGAR_DETALLES_DGW();
            Panel1.Visible = true;
            Panel2.Visible = false;
            Panel0.Enabled = false;
            cbo_ni.Visible = false;
            TXT_NI.Visible = true;
            HALLAR_TOTAL_OC();
            btn_Imprimir.Focus();
        }

        private void btn_anul_Click(object sender, EventArgs e)
        {
            if (!validaEliminarAnular())
                return;

            string errMensaje = "";
            int idx = dgw1.CurrentRow.Index;
            string str5 = dgw1[0, idx].Value.ToString();
            string str3 = dgw1[2, idx].Value.ToString();
            string str4 = dgw1[5, idx].Value.ToString();
            string str = dgw1[4, idx].Value.ToString();

            DialogResult rs = MessageBox.Show("Sì para Anular, No para Cancelar Anulación, Cancelar para salir.", "ADVERTENCIA", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);

            if (rs == DialogResult.Yes || rs == DialogResult.No)
            {
                string str8 = rs == DialogResult.Yes ? "1" : "0";

                if (TIPO_USU != "MS")
                {
                    DIALOGOS.frmValidarEliminarAnular frm = new DIALOGOS.frmValidarEliminarAnular();
                    frm.Label2.Visible = false;
                    frm.txtObservacion.Visible = true;
                    frm.txtContraseña.Text = "";
                    frm.txtObservacion.Text = "";
                    frm.cargar_usuario("ALM");
                    frm.cboUsuario.Focus();
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        string pass = frm.txtContraseña.Text;
                        string claveEncriptada = HelpersBLL.ENCRIPTAR(pass.ToUpper());
                        string codigo = helBLL.ValidarUsuarioEliminacionAnulacionBLL(claveEncriptada, frm.cboUsuario.Text);
                        int RSLT = helBLL.ValidarDirectorioDesaprobarBLL(codigo, "ALM");
                        if (RSLT > 0)
                        {
                            anulaNotaIngreso(str4, "01", str3, str, str5, str8, frm.txtObservacion.Text, codigo, ref errMensaje);
                            this.Dispose();
                        }
                        else
                            MessageBox.Show("USTED NO TIENE PERMISOS !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    frm.Dispose();
                }
                else
                {
                    anulaNotaIngreso(str4, "01", str3, str, str5, str8, "", "", ref errMensaje);
                }
                DATAGRID();
            }
            btn_nuevo.Select();
        }
        private void anulaNotaIngreso(string str4, string str2, string str3, string str, string str5, string str8, string OBS, string codigo, ref string errMensaje)
        {
            invTo.COD_SUCURSAL = str5;
            invTo.COD_CLASE = str3;
            invTo.COD_PER = str4;
            invTo.COD_DOC_INV = str2;
            invTo.NRO_DOC_INV = str;
            invTo.FE_AÑO = AÑO;
            invTo.FE_MES = MES;
            invTo.ESTADO0 = str8;
            invTo.TIPO_USU = "1";
            invTo.OBSERVACION = OBS;
            invTo.COD_USU_MOD = codigo;
            invTo.FECHA_MOD = DateTime.Now;
            if (!invBLL.ANULA_NOTA_INGRESO(invTo, ref errMensaje))
            {
                MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("La Nota de Ingreso se Anulò !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                DIALOGOS.CONSULTA_SALDO_X_ARTICULO frm = new DIALOGOS.CONSULTA_SALDO_X_ARTICULO(COD_CLASE, TXT_COD_PRO.Text, TXT_DESC_PRO.Text, TIPO_USU, COD_USU);
                frm.ShowDialog();
            }
        }

        private void txt_letra_TextChanged(object sender, EventArgs e)
        {
            int i;
            if (ch_cod.Checked)
            {
                txt_letra.Focus();
                for (i = 0; i < dgw1.Rows.Count; i++)
                {
                    if (txt_letra.TextLength <= dgw1[4, i].Value.ToString().Length)
                    {
                        if (txt_letra.Text.ToLower() == dgw1[4, i].Value.ToString().Substring(0, txt_letra.TextLength).ToLower())
                        {
                            dgw1.CurrentCell = dgw1.Rows[i].Cells[4];
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
                    if (txt_letra.TextLength <= dgw1[6, i].Value.ToString().Length)
                    {
                        if (txt_letra.Text.ToLower() == dgw1[6, i].Value.ToString().Substring(0, txt_letra.TextLength).ToLower())
                        {
                            dgw1.CurrentCell = dgw1.Rows[i].Cells[6];
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
                dgw1.Sort(dgw1.Columns[4], System.ComponentModel.ListSortDirection.Ascending);
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
                dgw1.Sort(dgw1.Columns[6], System.ComponentModel.ListSortDirection.Ascending);
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
                for (f = 0; f <= dgw1[4, i].Value.ToString().Length - txt_letra.TextLength; f++)
                {
                    if (txt_letra.TextLength <= dgw1[4, i].Value.ToString().Length)
                    {
                        if (txt_letra.Text.ToLower() == dgw1[4, i].Value.ToString().Substring(f, txt_letra.TextLength).ToLower())
                        {
                            dgw1.CurrentCell = dgw1.Rows[i].Cells[4];
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
                for (f = 0; f <= dgw1[4, i].Value.ToString().Length - txt_letra.TextLength; f++)
                {
                    if (txt_letra.TextLength <= dgw1[4, i].Value.ToString().Length)
                    {
                        if (txt_letra.Text.ToLower() == dgw1[4, i].Value.ToString().Substring(f, txt_letra.TextLength).ToLower())
                        {
                            dgw1.CurrentCell = dgw1.Rows[i].Cells[4];
                            fila = i + 1;
                            return;
                        }
                    }
                }
            }
            MessageBox.Show("Ya no existen más registros !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void CH_IGV_CheckedChanged(object sender, EventArgs e)
        {
            if (CH_IGV.Checked)
                TXT_IGV.Text = igv0.ToString();
            else
                TXT_IGV.Text = "0.00";
            HALLAR_VALOR_VENTA();
        }

        private void TXT_DSCTO_Leave(object sender, EventArgs e)
        {
            TXT_DSCTO.Text = HelpersBLL.OBTIENE_PRECIO_TRES_DECIMALES(TXT_DSCTO.Text);
            HALLAR_VALOR_VENTA();
        }

        private void TabPage2_Click(object sender, EventArgs e)
        {

        }
    }
}
