using BLL;
using Entidades;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace Presentacion.MOD_FACT_VTA
{
    public partial class CARGA_FACT_SIS_ANT : Form
    {
        string AÑO = "", MES = "", COD_MOD = "", COD_USU = "", TIPO_USU = "";
        DateTime FECHA_INI, FECHA_GRAL;
        string BOTON;
        string CDVEN;//cod vendedor
        string ruta = string.Empty;
        facturacionElectronicaCabeceraBLL faeBLL = new facturacionElectronicaCabeceraBLL();
        facturacionElectronicaCabeceraTo faeTo = new facturacionElectronicaCabeceraTo();
        contratoCabeceraBLL ccBLL = new contratoCabeceraBLL();
        contratoCabeceraTo ccTo = new contratoCabeceraTo();
        contratoDetalleBLL dcBLL = new contratoDetalleBLL();
        contratoDetalleTo dcTo = new contratoDetalleTo();
        kitDetalleBLL dkiBLL = new kitDetalleBLL();
        kitDetalleTo dkiTo = new kitDetalleTo();
        HelpersBLL helBLL = new HelpersBLL();
        HelpersTo helTo = new HelpersTo();
        DataTable DT00 = new DataTable();
        DataTable dtContrato, dtArticulos;
        public CARGA_FACT_SIS_ANT(string AÑO, string MES, DateTime FECHA_INI, DateTime FECHA_GRAL, string COD_MOD, string TIPO_USU, string COD_USU)
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
        private void CARGA_FACT_SIS_ANT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }
        private void CARGA_FACT_SIS_ANT_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            DATAGRID();
            CARGAR_MONEDA();
            CARGAR_CLASE();
            CARGAR_PERSONAS();
            CARGAR_ARTICULOS();
        }
        private void CARGAR_ARTICULOS()
        {
            dkiTo.COD_KIT = "01";
            dtArticulos = dkiBLL.obtenerKitDetalleporCodKitBLL(dkiTo);
            if (dtArticulos.Rows.Count <= 0)
            {
                MessageBox.Show("No se ha creado kit !!!", "ADVERTENCIA");
            }
        }
        private void CARGAR_PERSONAS()
        {
            helTo.CODIGO = "04";//VENDEDORES
            DataTable dt = helBLL.MOSTRAR_PERSONAS_XCOBRAR_BLL(helTo);
            dgw_per.DataSource = dt;

        }
        private void DATAGRID()
        {
            dtContrato = ccBLL.obtenerContratoCabecera_para_Fact_Elect_BLL(ccTo);
            if (dtContrato.Rows.Count > 0)
            {
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
                dgw1.Columns["STATUS_PV"].Visible = false;
                dgw1.Columns["NRO_DIAS"].Visible = false;
                dgw1.Columns["COD_PER_ELAB"].Visible = false;
                dgw1.Columns["COD_CONTACTO"].Visible = false;
                dgw1.Columns["CONDICION_VENTA"].Visible = false;
                dgw1.Columns["DESC_TIPO"].Visible = false;
                dgw1.Columns["TIPO_PRECIO"].Visible = false;
                dgw1.Columns["OBSERVACION"].Visible = false;
                dgw1.Columns["NRO_REPORTE"].Visible = false;
                dgw1.Columns["FEC_REPORTE"].Visible = false;
                dgw1.Columns["COD_PROGRAMA"].Visible = false;
                dgw1.Columns["DESC_PROGRAMA"].Visible = false;
                dgw1.Columns["PERIODO"].Visible = false;
                dgw1.Columns["NRO_SEMANA"].Visible = false;
                dgw1.Columns["TIPO_PLANILLA"].Visible = false;
                dgw1.Columns["COD_ALMACEN"].Visible = false;
                dgw1.Columns["COD_NIVEL1"].Visible = false;
                dgw1.Columns["COD_NIVEL2"].Visible = false;
                dgw1.Columns["COD_NIVEL3"].Visible = false;
                dgw1.Columns["TOTAL_CONTRATO"].Visible = false;
                dgw1.Columns["NRO_CUOTAS"].Visible = false;
                dgw1.Columns["IMP_CUOTA_INICIAL"].Visible = false;
                dgw1.Columns["IMP_COUTA_MES"].Visible = false;
                dgw1.Columns["FEC_PRIMER_VENC"].Visible = false;
                dgw1.Columns["NRO_DIAS_VENC"].Visible = false;
                dgw1.Columns["FEC_CUO_MEN"].Visible = false;
                dgw1.Columns["Sucursal"].Width = 130;
                dgw1.Columns["Clase"].Width = 100;
                dgw1.Columns["Cliente"].Width = 180;
                dgw1.Columns["FECHA_DOC"].Width = 70;
                dgw1.Columns["FECHA_DOC"].DefaultCellStyle.Format = "d";
                dgw1.Columns["NRO_PRESUPUESTO"].HeaderText = "Contrato";
                dgw1.Columns["NRO_PRESUPUESTO"].DisplayIndex = 7;
                dgw1.Columns["NRO_PRESUPUESTO"].Width = 70;
                dgw1.Columns["FECHA_PRE"].HeaderText = "Fe Cont";
                dgw1.Columns["FECHA_PRE"].DisplayIndex = 8;
                dgw1.Columns["FECHA_PRE"].Width = 70;
                dgw1.Columns["FECHA_PRE"].DefaultCellStyle.Format = "d";
            }
            else
                dgw1.DataSource = null;

        }
        private void CARGAR_MONEDA()
        {
            //DataTable dt = helBLL.obtenerMonedaBLL();
            //cbo_moneda.ValueMember = "COD_MONEDA";
            //cbo_moneda.DisplayMember = "desc_moneda";
            //cbo_moneda.DataSource = dt;
            //cbo_moneda.SelectedItem = -1;
        }
        private void CARGAR_CLASE()
        {
            //string TIPO_USU = "MS";
            //string COD_USU = "0000";
            //bool validarTipo = true;
            //string tipo = "P";
            //bool validarDebeHaber = true;
            //string debeHaber = "H";

            //helTo.CODIGO = TIPO_USU;
            //helTo.CODIGO2 = COD_USU;
            //helTo.CODIGO3 = validarTipo == true ? "0" : "1";
            //helTo.CODIGO4 = tipo;
            //helTo.CODIGO5 = validarDebeHaber == true ? "0" : "1";
            //helTo.CODIGO6 = debeHaber;
            //DataTable dt = helBLL.CBO_CLASE_USU_TIPO_BLL(helTo);
            //cbo_clase.ValueMember = "COD_CLASE";
            //cbo_clase.DisplayMember = "DESC_CLASE";
            //cbo_clase.DataSource = dt;
            //cbo_clase.SelectedIndex = -1;
        }
        private void BTN_NOTA_DET2_Click(object sender, EventArgs e)
        {
            if (!validaNuevoContrato())
                return;
            TabControl1.SelectedTab = TabPage2;
            Properties.Settings s = new Properties.Settings();
            ruta = s.RUTA;
            DataTable DT00 = new DataTable();
            if (File.Exists(ruta))
            {
                MessageBox.Show("No existe");
                return;
            }
            faeTo.CDCTE = txt_cont_ant.Text;
            CARGAR_CABECERA();
            CARGAR_DETALLE();
            HALLAR_TOTAL_OC();
        }
        private bool validaNuevoContrato()
        {
            bool result = true;
            string errMensaje = "";
            ccTo.COD_SUCURSAL = "0001";
            ccTo.NRO_PRESUPUESTO = txt_cont_ant.Text;
            if (ccBLL.VERIFICA_NRO_CONTRATO_BLL(ccTo, ref errMensaje))
            {
                MessageBox.Show("El Nro de Contrato " + txt_cont_ant.Text + " ya ha sido ingresado !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_cont_ant.Focus();
                return result = false;
            }
            else
            {
                if (errMensaje != "")
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        private void CARGAR_CABECERA()
        {
            DataTable dtCab = faeBLL.obtenerFacturaCabeceraDBF_BLL(faeTo, ruta);
            if (dtCab.Rows.Count > 0)
            {
                txt_contrato.Text = dtCab.Rows[0]["CDCTE"].ToString();
                dtp_fec_contrato.Value = Convert.ToDateTime(dtCab.Rows[0]["FECTE"]);
                txt_moneda.Text = dtCab.Rows[0]["CDMON"].ToString();
                txt_programa.Text = dtCab.Rows[0]["CDT_V"].ToString();
                CDVEN = dtCab.Rows[0]["CDVEN"].ToString();
                txt_tipo_planilla.Text = dtCab.Rows[0]["STORI"].ToString();
                txt_for_pago.Text = dtCab.Rows[0]["FOPAG"].ToString();
                txt_dia.Text = dtCab.Rows[0]["NUDIA"].ToString();
                txt_tot_imp.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(dtCab.Rows[0]["TOCTE"].ToString());
                txt_obs.Text = dtCab.Rows[0]["DSOBS"].ToString();
            }
            else
            {
                MessageBox.Show("El Nro de Contrato " + txt_cont_ant + " no existe !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }
        private void CARGAR_DETALLE()
        {
            DataTable dtDet = faeBLL.obtenerFacturaDetalleDBF_BLL(faeTo, ruta);
            if (dtDet.Rows.Count > 0)
            {
                DGW_DET.Rows.Clear();
                foreach (DataRow rw in dtDet.Rows)
                {
                    int rowId = DGW_DET.Rows.Add();
                    DataGridViewRow row = DGW_DET.Rows[rowId];
                    row.Cells["NUDOC1"].Value = rw["NUDOC"].ToString();
                    row.Cells["NUIT1"].Value = rw["NUIT1"].ToString();
                    row.Cells["FEDOC1"].Value = rw["FEDOC"].ToString();
                    row.Cells["CDCTE1"].Value = rw["CDCTE"].ToString();
                    row.Cells["CDART"].Value = rw["CDART"].ToString();
                    row.Cells["DSART"].Value = rw["DSART"].ToString();
                    row.Cells["CADOC"].Value = rw["CADOC"].ToString();
                    row.Cells["PRVAC"].Value = rw["PRVAC"].ToString();
                    row.Cells["PODES"].Value = rw["PODES"].ToString();
                    row.Cells["POIGV"].Value = rw["POIGV"].ToString();
                    row.Cells["VANET"].Value = rw["VANET"].ToString();
                    row.Cells["VADES"].Value = rw["VADES"].ToString();
                    row.Cells["VAIGV"].Value = rw["VAIGV"].ToString();
                    row.Cells["FECTE"].Value = rw["FECTE"].ToString();
                    row.Cells["CDD_H"].Value = rw["CDD_H"].ToString();
                    row.Cells["DSOBS"].Value = rw["DSOBS"].ToString();
                    row.Cells["ST_VALOR_REFERENCIAL"].Value = obtenerValorReferencial(rw["CDART"].ToString());
                }
            }
        }
        private string obtenerValorReferencial(string cod_art)
        {
            string vl = "VALOR REFERENCIAL";//valor por defecto, por si hay un articulo que no esté en el detalle de kit
            DataRow[] r = dtArticulos.Select("COD_ARTICULO = '" + cod_art + "'");
            if (r.Length > 0)
            {
                foreach (DataRow rw in r)
                    vl = rw["ST_VALOR_REFERENCIAL"].ToString() == "True" ? "VALOR REFERENCIAL" : "PRECIO UNITARIO";
            }
            return vl;
        }
        private void HALLAR_TOTAL_OC()
        {
            decimal impor = 0, dscto = 0, igv = 0, neto = 0, total = 0;
            foreach (DataGridViewRow rw in DGW_DET.Rows)
            {
                if (rw.Cells["ST_VALOR_REFERENCIAL"].Value.ToString() == "PRECIO UNITARIO")
                {
                    impor = impor + Convert.ToDecimal(rw.Cells["VANET"].Value);
                    igv = 0;//igv + Convert.ToDecimal(rw.Cells[11].Value);
                    dscto = dscto + Convert.ToDecimal(rw.Cells["VADES"].Value);
                }
            }
            total = impor;
            //neto = total / 1.18M;
            //neto = total / (1 + Math.Round((igv0 / 100), 2));
            neto = total;
            //igv = total - neto;

            TXT_TB.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES((impor - igv).ToString());
            TXT_TD.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(dscto.ToString());
            TXT_TN.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES((impor - igv).ToString());
            TXT_TIGV.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(igv.ToString());
            TXT_TT.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(impor.ToString());
        }
        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            LIMPIAR_CABECERA();
            TabControl1.SelectedTab = TabPage3;
            //txt_cont_ant.Focus();
        }
        private void LIMPIAR_CABECERA()
        {
            txt_contrato.Clear();
            //txt_nudoc.Clear();
            txt_for_pago.Clear();
            txt_tipo_planilla.Clear();
            txt_programa.Clear();
            txt_moneda.Clear();
            txt_tot_imp.Clear();
            TXT_COD.Clear();
            TXT_DESC.Clear();
            txt_doc_per.Clear();
            DGW_DET.Rows.Clear();
        }
        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void BTN_GRABAR_Click(object sender, EventArgs e)
        {
            if (!validaGrabar())
                return;

            DialogResult rs = MessageBox.Show("¿ Esta seguro de crear un nuevo Contrato ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                ccTo.COD_SUCURSAL = "0001";
                ccTo.NRO_DOC = txt_cont_ant.Text;//LO CAMBIO POR TXT_NI
                ccTo.COD_PER = TXT_COD.Text;
                ccTo.COD_CLASE = "01";
                ccTo.FE_AÑO = dtp_fec_contrato.Value.ToString("yyyy");
                ccTo.FE_MES = dtp_fec_contrato.Value.ToString("MM");
                ccTo.FECHA_DOC = dtp_fec_contrato.Value;
                ccTo.NRO_PRESUPUESTO = txt_cont_ant.Text;
                ccTo.FECHA_PRE = dtp_fec_contrato.Value;
                ccTo.COD_MONEDA = txt_moneda.Text;
                ccTo.TIPO_CAMBIO = 0;
                ccTo.FORMA_PAGO = txt_for_pago.Text;
                ccTo.STATUS_PV = "1";
                ccTo.NRO_DIAS = Convert.ToInt32(txt_dia.Text);
                ccTo.COD_PER_ELAB = "0000";
                ccTo.COD_PER_APROB = "";
                ccTo.STATUS_APROB = "";
                ccTo.STATUS_ANUL = "";
                ccTo.STATUS_CIERRE = "";
                ccTo.COD_VENDEDOR = CDVEN;//preguntar
                ccTo.CONDICION_VENTA = "";
                ccTo.COD_CONTACTO = "";
                ccTo.FECHA_APROB = null;
                ccTo.TIPO_PRECIO = "";
                ccTo.OBSERVACION = txt_obs.Text;
                ccTo.COD_MOV = "002";
                ccTo.NRO_REPORTE = "";
                ccTo.FEC_REPORTE = DateTime.Now;
                ccTo.COD_PROGRAMA = txt_programa.Text;
                ccTo.PERIODO = dtp_fec_contrato.Value.ToString("MM");
                ccTo.NRO_SEMANA = "";
                ccTo.TIPO_PLANILLA = txt_tipo_planilla.Text;
                ccTo.COD_ALMACEN = "";
                ccTo.COD_NIVEL1 = "";
                ccTo.COD_NIVEL2 = "";
                ccTo.COD_NIVEL3 = "";
                ccTo.SUELDO_NETO = txt_tot_imp.Text.Trim() == "" ? 0 : Convert.ToDecimal(txt_tot_imp.Text);
                ccTo.PRESTAMOS = 0;
                ccTo.OTROS_DSCTOS = 0;
                ccTo.JUDICIALES = 0;
                ccTo.NETO_COBRAR = 0;
                ccTo.TOTAL_CONTRATO = Convert.ToDecimal(txt_tot_imp.Text);
                ccTo.NRO_CUOTAS = 0;
                ccTo.IMP_CUOTA_INICIAL = 0;
                ccTo.IMP_CUOTA_MES = 0;
                ccTo.FEC_PRIMER_VENC = DateTime.Now;
                ccTo.NRO_DIAS_VENC = 0;
                ccTo.FEC_CUO_MEN = DateTime.Now;
                ccTo.STATUS_FAC = "";
                ccTo.TIPO_PEDIDO = "";
                ccTo.STATUS_GUIA = "";
                ccTo.COD_REF = "";
                ccTo.NRO_REF = "";
                ccTo.NOMBRE_PC = "";
                ccTo.SERIE = "";
                ccTo.COD_SUB_PTO_VEN = "";
                ccTo.COD_CANAL_DSCTO = "";
                ccTo.COD_PTO_COB = "";
                ccTo.COD_TIPO_VENTA = "";
                ccTo.COD_MODALIDAD_VTA = "";
                ccTo.COD_LUG_VTA = "";
                ccTo.COD_INSTITUCION = "";
                ccTo.IMPORTE_PROTECCION = 0;
                DT00.Rows.Clear();

                DT00 = HelpersBLL.obtenerDT(DGW_DET);
                if (!ccBLL.adicionaInsertaContrato_dbf_BLL(ccTo, DT00, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("El Contrato se creo correctamente", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TabControl1.SelectedTab = TabPage1;
                    DATAGRID();
                    FOCO_NUEVO_REG2(txt_cont_ant.Text);
                    //CARGAR_PRESUPUESTOS_PENDIENTES();//esto es para llenar el grid de los pendientes
                }
            }
        }
        private void FOCO_NUEVO_REG2(string cont2)
        {
            int i, cont = 0;
            cont = dgw1.Columns.Count - 1;
            string nrocon = cont2;
            for (i = 0; i <= cont; i++)
            {
                if (nrocon == dgw1.Rows[i].Cells["NRO_PRESUPUESTO"].Value.ToString().ToLower())
                {
                    dgw1.CurrentCell = dgw1.Rows[i].Cells["NRO_PRESUPUESTO"];
                    return;
                }
            }
        }
        private bool validaGrabar()
        {
            bool result = true;

            if (TXT_COD.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el código del cliente !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TXT_COD.Focus();
                return result = false;
            }
            if (TXT_DESC.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el nombre del cliente !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TXT_DESC.Focus();
                return result = false;
            }
            if (txt_doc_per.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el Dni !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_doc_per.Focus();
                return result = false;
            }
            //////////////////////////
            string errMensaje = "";
            ccTo.COD_SUCURSAL = "001";
            ccTo.NRO_PRESUPUESTO = txt_contrato.Text;
            if (ccBLL.VERIFICA_NRO_CONTRATO_BLL(ccTo, ref errMensaje))
            {
                MessageBox.Show("El Nro de Contrato " + txt_contrato.Text + " ya ha sido ingresado !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_contrato.Focus();
                return result = false;
            }
            else
            {
                if (errMensaje != "")
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            //
                            //      MostrarFormaPago();
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
                    btnNuevoCliente_Click(sender, e);
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

        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            MOD_ADM.PERSONA frm = new MOD_ADM.PERSONA(1, "");
            if (frm.ShowDialog() == DialogResult.OK)
            {
                TXT_COD.Text = "";
                TXT_DESC.Text = "";

                TXT_COD.Text = frm.txt_cod.Text;
                TXT_DESC.Text = frm.cbo_tipo.SelectedItem.ToString() == "NATURAL" ? frm.txt_pat.Text + " " + frm.txt_mat.Text + " " + frm.txt_nom.Text : frm.txt_desc.Text;
                txt_doc_per.Text = frm.txt_nro_doc.Text;
                BTN_GRABAR.Focus();
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
                //TabControl2.SelectedTab = TabPage3;
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
        private bool validaModificarEliminarAnularPrecontrato()
        {
            bool result = true;
            try
            {
                int index = dgw1.CurrentRow.Index;
            }
            catch (Exception)
            {
                MessageBox.Show("DEBE ELEGIR UN REGISTRO !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return result = false;
            }
            return result;
        }
        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (!validaModificarEliminarAnularPrecontrato())
                return;

            string errMensaje = "";
            DialogResult rs = MessageBox.Show("¿ Esta seguro de eliminar el contrato Nº " + dgw1.CurrentRow.Cells["NRO_DOC"].Value.ToString() + " ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                ccTo.COD_SUCURSAL = dgw1.CurrentRow.Cells["COD_SUCURSAL"].Value.ToString();
                ccTo.COD_CLASE = dgw1.CurrentRow.Cells["COD_CLASE"].Value.ToString();
                ccTo.COD_PER = dgw1.CurrentRow.Cells["COD_PER"].Value.ToString();
                ccTo.NRO_DOC = dgw1.CurrentRow.Cells["NRO_DOC"].Value.ToString();
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

        private void btn_nuevo2_Click(object sender, EventArgs e)
        {
            LIMPIAR_CABECERA();
            txt_contrato.Focus();
            TabControl1.SelectedTab = TabPage3;
        }

        private void btn_consulta_Click(object sender, EventArgs e)
        {
            CARGAR_CABECERA(dgw1);
            CARGAR_DETALLES_DGW();
            HALLAR_TOTAL_OC();
            TabControl1.SelectedTab = TabPage2;
        }
        private void CARGAR_CABECERA(DataGridView dgw)
        {
            txt_contrato.Text = dgw.CurrentRow.Cells["NRO_DOC"].Value.ToString();
            dtp_fec_contrato.Value = Convert.ToDateTime(dgw.CurrentRow.Cells["FECHA_DOC"].Value);
            txt_for_pago.Text = dgw.CurrentRow.Cells["FORMA_PAGO"].Value.ToString();
            txt_tipo_planilla.Text = dgw1.CurrentRow.Cells["TIPO_PLANILLA"].Value.ToString();
            txt_programa.Text = dgw.CurrentRow.Cells["COD_PROGRAMA"].Value.ToString();
            txt_moneda.Text = dgw.CurrentRow.Cells["COD_MONEDA"].Value.ToString();
            txt_tot_imp.Text = dgw.CurrentRow.Cells["TOTAL_CONTRATO"].Value.ToString();
            TXT_COD.Text = dgw.CurrentRow.Cells["COD_PER"].Value.ToString();
            TXT_DESC.Text = dgw.CurrentRow.Cells["Cliente"].Value.ToString();
            txt_doc_per.Text = dgw.CurrentRow.Cells["DNI"].Value.ToString();
            txt_dia.Text = dgw.CurrentRow.Cells["NRO_DIAS"].Value.ToString();
            txt_obs.Text = dgw.CurrentRow.Cells["OBSERVACION"].Value.ToString();
        }
        private void CARGAR_DETALLES_DGW()
        {
            DGW_DET.Rows.Clear();
            dcTo.COD_CLASE = "01";
            dcTo.COD_SUCURSAL = "0001";
            dcTo.COD_PER = TXT_COD.Text;
            //ccdTo.NRO_DOC = txt_numero.Text;
            dcTo.NRO_DOC = dgw1.CurrentRow.Cells["NRO_DOC"].Value.ToString();
            dcTo.FE_AÑO = AÑO;
            dcTo.FE_MES = MES;
            DataTable dt = dcBLL.obtenerContratoDetalleContratoBLL(dcTo);
            if (dt.Rows.Count > 0)
            {
                DGW_DET.Rows.Clear();
                foreach (DataRow rw in dt.Rows)
                {
                    int rowId = DGW_DET.Rows.Add();
                    DataGridViewRow row = DGW_DET.Rows[rowId];
                    row.Cells["NUDOC1"].Value = rw["NRO_PRESUPUESTO"].ToString();
                    row.Cells["NUIT1"].Value = rw["ITEM"].ToString();
                    row.Cells["FEDOC1"].Value = Convert.ToDateTime(dgw1.CurrentRow.Cells["FECHA_DOC"].Value);//rw["FEDOC"].ToString();
                    row.Cells["CDCTE1"].Value = rw["NRO_PRESUPUESTO"].ToString();
                    row.Cells["CDART"].Value = rw["COD_ARTICULO"].ToString();
                    row.Cells["DSART"].Value = rw["DESC_ARTICULO"].ToString();
                    row.Cells["CADOC"].Value = rw["CANTIDAD_PED"].ToString();
                    row.Cells["PRVAC"].Value = rw["PRECIO_UNIT"].ToString();
                    row.Cells["PODES"].Value = rw["POR_DSCTO"].ToString();
                    row.Cells["POIGV"].Value = rw["POR_IGV"].ToString();
                    row.Cells["VANET"].Value = rw["VALOR_COMPRA"].ToString();
                    row.Cells["VADES"].Value = rw["VALOR_DSCTO"].ToString();
                    row.Cells["VAIGV"].Value = rw["VALOR_IGV"].ToString();
                    row.Cells["FECTE"].Value = Convert.ToDateTime(dgw1.CurrentRow.Cells["FECHA_DOC"].Value);//rw["FECTE"].ToString();
                    row.Cells["CDD_H"].Value = rw["COD_D_H"].ToString();
                    row.Cells["DSOBS"].Value = rw["OBSERVACION"].ToString();
                    row.Cells["ST_VALOR_REFERENCIAL"].Value = obtenerValorReferencial(rw["COD_ARTICULO"].ToString());//rw["ST_VALOR_REFERENCIAL"].ToString() == "True" ? "VALOR REFERENCIAL" : "PRECIO UNITARIO";
                }
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            TabControl1.SelectedTab = TabPage1;
        }
    }
}
