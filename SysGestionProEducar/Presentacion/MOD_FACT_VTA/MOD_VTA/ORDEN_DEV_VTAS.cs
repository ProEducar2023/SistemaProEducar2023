using BLL;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;

namespace Presentacion.MOD_FACT_VTA.MOD_VTA
{
    public partial class ORDEN_DEV_VTAS : Form
    {
        string AÑO = "", MES = "", COD_MOD = "", COD_USU = "", TIPO_USU = "";
        DateTime FECHA_INI, FECHA_GRAL;
        Decimal igv0;
        string boton;
        DataTable dt00 = new DataTable();
        DataTable DT00 = new DataTable();
        HelpersBLL helBLL = new HelpersBLL();
        HelpersTo helTo = new HelpersTo();
        directorioBLL dirBLL = new directorioBLL();
        directorioTo dirTo = new directorioTo();
        CONSULTAS.CONSULTA_ORD_DEV_FAC_VTA frm = new CONSULTAS.CONSULTA_ORD_DEV_FAC_VTA();
        contratoCabeceraBLL ccBLL = new contratoCabeceraBLL();
        contratoCabeceraTo ccTo = new contratoCabeceraTo();
        contratoDetalleBLL dcBLL = new contratoDetalleBLL();
        contratoDetalleTo dcTo = new contratoDetalleTo();
        string NOMBRE_PC = System.Environment.MachineName;
        //
        string NRO_DOC, NRO_PRESUPUESTO, CBO_MONEDA1, FORMA_PAGO, STATUS_PV, COD_PER_ELAB, COD_PER_APROB, STATUS_APROB, STATUS_ANUL,
                    STATUS_CIERRE, COD_VENDEDOR, CONDICION_VENTA, COD_CONTACTO, TIPO_PRECIO, OBSERVACION, COD_MOV, NRO_REPORTE, COD_PROGRAMA,
                    PERIODO, NRO_SEMANA, TIPO_PLANILLA, COD_ALMACEN, COD_NIVEL1, COD_NIVEL2, COD_NIVEL3, STATUS_FAC, TIPO_PEDIDO, STATUS_GUIA,
                    COD_REF, NRO_REF, SERIE, COD_SUB_PTO_VEN, COD_CANAL_DSCTO, COD_PTO_COB, COD_TIPO_VENTA, COD_MODALIDAD_VTA, TIPO_ORIGEN,
                    NRO_FACT_PRE_UNI, AÑO_DOC, MES_DOC, COD_KIT;
        DateTime FECHA_PRE, FECHA_APROB, FEC_REPORTE, FEC_PRIMER_VENC, FEC_CUO_MEN;
        int NRO_DIAS, NRO_CUOTAS, NRO_DIAS_VENC;
        decimal TIPO_CAMBIO, SUELDO_NETO, PRESTAMOS, OTROS_DSCTOS, JUDICIALES, NETO_COBRAR, TOTAL_CONTRATO, IMP_CUOTA_INICIAL,
            IMP_CUOTA_MES;

        public ORDEN_DEV_VTAS(string AÑO, string MES, DateTime FECHA_INI, DateTime FECHA_GRAL, string COD_MOD, string TIPO_USU, string COD_USU)
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

        private void ORDEN_DEV_VTAS_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            DATAGRID();
            CARGAR_CLASE();
            CARGAR_SUCURSAL();
            CARGAR_PERSONAS();
            CARGAR_PERSONAS_PERSONAL();
            //CARGAR_FIRMANTES();
            CARGAR_MONEDA();
            DOCUMENTOS();
            CARGAR_MOTIVO_DEVOLUCION();
            CARGAR_DEVOLVER_A();
            cargarTipoOperacionFacturaElectronica();
            igv0 = helBLL.obtenerImpuestoBLL("IGV");
            TXT_IGV2.Text = igv0.ToString();
            //DTP_OC.Value = Convert.ToDateTime(DateTime.Now.Day + "/" + MES + "/" + AÑO);
            DateTime fe_OC = DateTime.Now;
            if (DateTime.TryParse((DateTime.Now.Day + "/" + MES + "/" + AÑO), out fe_OC))
                DTP_OC.Value = Convert.ToDateTime(DateTime.Now.Day + "/" + MES + "/" + AÑO);
            else
                DTP_OC.Value = FECHA_GRAL;
            //DTP_FACT.Value = Convert.ToDateTime(DateTime.Now.Day + "/" + MES + "/" + AÑO);
            DateTime fe_FACT = DateTime.Now;
            if (DateTime.TryParse((DateTime.Now.Day + "/" + MES + "/" + AÑO), out fe_FACT))
                DTP_FACT.Value = Convert.ToDateTime(DateTime.Now.Day + "/" + MES + "/" + AÑO);
            else
                DTP_FACT.Value = FECHA_GRAL;
            //dtp_fact_cc.Value = Convert.ToDateTime(DateTime.Now.Day + "/" + MES + "/" + AÑO);
            DateTime fe_fact_cc = DateTime.Now;
            if (DateTime.TryParse((DateTime.Now.Day + "/" + MES + "/" + AÑO), out fe_fact_cc))
                dtp_fact_cc.Value = Convert.ToDateTime(DateTime.Now.Day + "/" + MES + "/" + AÑO);
            else
                dtp_fact_cc.Value = FECHA_GRAL;
            //EstadoEnabledAnular();
            dt00.Columns.Add("sucursal");
            dt00.Columns.Add("Clase");
            dt00.Columns.Add("Cod_per");
            dt00.Columns.Add("Nro_OC");
            dt00.Columns.Add("Fe_año");
            dt00.Columns.Add("Fe_mes");
            dt00.Columns.Add("Item");
            dt00.Columns.Add("Articulo");
            dt00.Columns.Add("Cantidad");
            dt00.Columns.Add("Cantidad_RECIB");
            dt00.Columns.Add("Cantidad_ANUL");
            dt00.Columns.Add("Precio_Unit");
            dt00.Columns.Add("Valor_COmpra");
            dt00.Columns.Add("Por_igv");
            dt00.Columns.Add("Por_Dscto");
            dt00.Columns.Add("Status_igv");
            dt00.Columns.Add("Valor_IGV");
            dt00.Columns.Add("Valor_Dscto");
            dt00.Columns.Add("Nro_REQ");
            dt00.Columns.Add("Ajuste_igv");
            dt00.Columns.Add("Ajuste_Bi");
            dt00.Columns.Add("Nombre_pc");
            dt00.Columns.Add("COD_ART_PRO");
            dt00.Columns.Add("DESC_ART_PRO");
            dt00.Columns.Add("obs_ART_PRO");
            dt00.Columns.Add("NRO_SOL_COMPRA");
            dt00.Columns.Add("NRO_ITEM");
            dt00.Columns.Add("TIPO");
            //
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
            DT00.Columns.Add("ST_VALOR_REFERENCIAL");
            DT00.Columns.Add("COD_KIT");
            //
            btn_nuevo.Select();
        }
        private void CARGAR_DEVOLVER_A()
        {
            directorioBLL dirBLL = new directorioBLL();
            directorioTo dirTo = new directorioTo();
            dirTo.TABLA_COD = "TDEVA";//TABLA DE DEVOLVER A
            DataTable dt = dirBLL.MOSTRAR_DIRECTORIO_DATO_BLL(dirTo);
            cboDevolverA.ValueMember = "Codigo";
            cboDevolverA.DisplayMember = "Descripción";
            cboDevolverA.DataSource = dt;
        }
        private void ORDEN_DEV_VTAS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void DATAGRID()
        {
            ccTo.FE_AÑO = AÑO;
            ccTo.FE_MES = MES;
            DataTable dt = ccBLL.MOSTRAR_ORD_DEV_VTA_BLL(ccTo);
            if (dt.Rows.Count > 0)
            {
                DGW.DataSource = dt;
                DGW.Columns["COD_SUCURSAL"].Visible = false;
                DGW.Columns["DESC_SUCURSAL"].Visible = false;
                //DGW.Columns["DESC_SUCURSAL"].HeaderText = "SUCURSAL";
                //DGW.Columns["DESC_SUCURSAL"].Width = 100;
                DGW.Columns["COD_CLASE"].Visible = false;
                DGW.Columns["DESC_CLASE"].HeaderText = "Clase";
                DGW.Columns["DESC_CLASE"].Width = 90;
                DGW.Columns["TIPO_ORIGEN"].HeaderText = "Orig";
                DGW.Columns["TIPO_ORIGEN"].Width = 40;
                DGW.Columns["NRODOC"].HeaderText = "Fac/Bol/Con";
                DGW.Columns["NRODOC"].Width = 90;
                DGW.Columns["COD_PER"].Visible = false;
                DGW.Columns["DESC_PER"].HeaderText = "Cliente";
                DGW.Columns["DESC_PER"].Width = 190;
                DGW.Columns["NRO_DOCU"].HeaderText = "Dni / Ruc";
                DGW.Columns["NRO_DOCU"].Width = 80;
                DGW.Columns["NRO_PRESUPUESTO"].HeaderText = "Contrato";
                DGW.Columns["NRO_PRESUPUESTO"].Width = 80;
                DGW.Columns["FECHA_DOCU"].HeaderText = "Fecha";
                DGW.Columns["FECHA_DOCU"].Width = 70;
                DGW.Columns["FECHA_DOCU"].DefaultCellStyle.Format = "dd/MM/yyyy";
                DGW.Columns["ST"].HeaderText = "Anulado";
                DGW.Columns["ST"].Width = 60;
                DGW.Columns["COD_PER_ELAB"].Visible = false;
                DGW.Columns["COD_DOC"].Visible = false;
                //DGW.Columns["NRO_DOC"].Visible = false;
                DGW.Columns["FECHA_DOC"].Visible = false;
                DGW.Columns["COD_MONEDA"].Visible = false;
                DGW.Columns["TIPO_CAMBIO"].Visible = false;
                DGW.Columns["OBSERVACION"].Visible = false;
                DGW.Columns["FE_AÑO"].Visible = false;
                DGW.Columns["FE_MES"].Visible = false;
                DGW.Columns["COD_MODALIDAD_VTA"].Visible = false;
                DGW.Columns["NRO_FAC_PRE_UNI"].Visible = false;
                DGW.Columns["NRO_DOC"].Visible = false;
                DGW.Columns["APR"].HeaderText = "Aprobado";
                DGW.Columns["APR"].Width = 60;
                DGW.Columns["COD_REF"].Visible = false;
            }
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
        private void CARGAR_PERSONAS()
        {
            helTo.CODIGO = "04";//VENDEDORES
            DataTable dt = helBLL.MOSTRAR_PERSONAS_XCOBRAR_BLL(helTo);
            dgw_per.DataSource = dt;
            dgw_per.Columns[0].Width = 70;
            dgw_per.Columns[1].Width = 200;
            dgw_per.Columns[2].Width = 80;
            dgw_per.Columns[3].Visible = false;
            dgw_per.Columns[4].Visible = false;
            dgw_per.Columns[5].HeaderText = "Institucion";
            dgw_per.Columns[5].Width = 150;
        }
        private void CARGAR_PERSONAS_PERSONAL()
        {
            CBO_ELAB.Items.Clear();
            personalBLL perBLL = new personalBLL();
            DataTable dt = perBLL.obtenerPersonalAtencionClienteBLL();
            CBO_ELAB.ValueMember = "COD_PER";
            CBO_ELAB.DisplayMember = "DESC_PER";
            CBO_ELAB.DataSource = dt;
            CBO_ELAB.SelectedIndex = -1;
        }
        private void CARGAR_MONEDA()
        {
            DataTable dt = helBLL.obtenerMonedaBLL();
            CBO_MONEDA.ValueMember = "COD_MONEDA";
            CBO_MONEDA.DisplayMember = "desc_moneda";
            CBO_MONEDA.DataSource = dt;
            CBO_MONEDA.SelectedItem = -1;
            //para la moneda del label de contratos
            DataTable dt1 = helBLL.obtenerMonedaBLL();
            cbo_moneda_cc.ValueMember = "COD_MONEDA";
            cbo_moneda_cc.DisplayMember = "desc_moneda";
            cbo_moneda_cc.DataSource = dt;
            cbo_moneda_cc.SelectedItem = -1;
        }
        private void DOCUMENTOS()
        {
            DataTable dt = helBLL.obtenerDesc_Doc_GestionBLL();
            CBO_DOC.ValueMember = "COD_DOC";
            CBO_DOC.DisplayMember = "DESC_DOC";
            CBO_DOC.DataSource = dt;
            CBO_DOC.SelectedIndex = -1;
            //
            cbo_doc_cc.DisplayMember = "Text";
            cbo_doc_cc.ValueMember = "Value";
            cbo_doc_cc.Items.Add(new { Text = "CONTRATOS", Value = "00" });
            cbo_doc_cc.SelectedIndex = 0;
        }
        private void CARGAR_MOTIVO_DEVOLUCION()
        {
            dirTo.TABLA_COD = "TMDEV";
            //// para el otro combo de Motivos
            DataTable dt1 = dirBLL.MOSTRAR_DIRECTORIO_DATO_BLL(dirTo);
            cbo_mod_vta_cc.ValueMember = "Codigo";
            cbo_mod_vta_cc.DisplayMember = "Descripción";
            cbo_mod_vta_cc.DataSource = dt1;
            cbo_mod_vta_cc.SelectedIndex = -1;
        }
        private void cargarTipoOperacionFacturaElectronica()
        {
            var cboTipoOperacionFE = new[] { new { cod = "01", val = "ANULACIÓN DE LA OPERACIÓN" }, new { cod = "02", val = "ANULACIÓN POR ERROR EN EL RUC" },
                                            new { cod = "03", val = "CORRECIÓN POR ERROR EN LA DESCRIPCIÓN" }, new { cod = "04", val = "DESCUENTO GLOBAL" },
                                            new { cod = "05", val = "DESCUENTO POR ITEM" }, new { cod = "06", val = "DEVOLUCIÓN TOTAL" },
                                            new { cod = "07", val = "DEVOLUCIÓN POR ITEM" }, new { cod = "08", val = "BONIFICACIÓN" },
                                            new { cod = "09", val = "DISMINUCIÓN EN EL VALOR" }};
            cbo_mot_dev.ValueMember = "cod";
            cbo_mot_dev.DisplayMember = "val";
            cbo_mot_dev.DataSource = cboTipoOperacionFE;
            cbo_mot_dev.SelectedIndex = -1;
        }
        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            boton = "NUEVO";
            btn_grabar.Visible = true;
            //btn_grabar2.Visible = false;
            btn_grabar.Enabled = true;
            btn_imprimir.Enabled = false;
            TabControl1.SelectedTab = TabPage2;
            TabControl2.SelectedTab = TabPage3;
            Panel1.Visible = true;
            //cbo_ni.Visible = true;
            //TXT_NI.Visible = false;
            LIMPIAR_CABECERA();
            LIMPIAR_DETALLES();
            gb_oc.Enabled = true;
            CBO_SUCURSAL.Focus();
        }
        private void LIMPIAR_CABECERA()
        {
            CBO_SUCURSAL.SelectedIndex = 0;
            CBO_CLASE.SelectedIndex = 0;
            TXT_COD.Text = "";
            TXT_DESC.Text = "";
            txt_doc_per.Text = "";
            CBO_ELAB.SelectedIndex = -1;
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

        private void btn_oc_Click(object sender, EventArgs e)
        {
            if (!validaTraeFacturas("Factura"))
                return;

            TabPage5.Select();
            //gb_oc.Enabled = false;//deshabilita el groupbox de orden de devolucion
            //CBO_DOC.Enabled = false;
            boton3("F");//FACTURA
        }
        private bool validaTraeFacturas(string op)
        {
            bool result = true;
            if (CBO_SUCURSAL.SelectedIndex <= -1)
            {
                MessageBox.Show("Elija la Sucursal !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                CBO_SUCURSAL.Focus();
                return result = false;
            }
            if (CBO_CLASE.SelectedIndex <= -1)
            {
                MessageBox.Show("Elija la Clase !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                CBO_CLASE.Focus();
                return result = false;
            }
            if (TXT_COD.Text == "")
            {
                MessageBox.Show("Ingrese el Proveedor !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TXT_COD.Focus();
                return result = false;
            }
            if (Panel_PER.Visible)
            {
                MessageBox.Show("Ingrese el Proveedor !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dgw_per.Focus();
                return result = false;
            }
            if (op == "Factura")
            {
                if (CBO_DOC.SelectedIndex == -1)
                {
                    MessageBox.Show("Ingrese el Documento !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    CBO_DOC.Focus();
                    return result = false;
                }
                //if (!(DTP_FACT.Value.Date <= FECHA_GRAL.Date && DTP_FACT.Value.Date >= FECHA_INI.Date))
                //{
                //    MessageBox.Show("LA FECHA ESTA FUERA DEL RANGO !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //    DTP_FACT.Focus();
                //    return result = false;
                //}
            }
            else if (op == "Contrato")
            {
                if (cbo_doc_cc.SelectedIndex == -1)
                {
                    MessageBox.Show("Ingrese el Documento !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cbo_doc_cc.Focus();
                    return result = false;
                }
                //if (!(DTP_FACT.Value.Date <= FECHA_GRAL.Date && DTP_FACT.Value.Date >= FECHA_INI.Date))
                //{
                //    MessageBox.Show("LA FECHA ESTA FUERA DEL RANGO !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //    dtp_fact_cc.Focus();
                //    return result = false;
                //}
            }
            return result;
        }
        private void boton3(string tip_ori)
        {
            frm.COD_SUCURSAL = CBO_SUCURSAL.SelectedValue.ToString();
            frm.COD_CLASE = CBO_CLASE.SelectedValue.ToString();
            frm.Text = TXT_DESC.Text;
            if (tip_ori == "F")
                frm.COD_DOC = CBO_DOC.SelectedValue.ToString();//poner advertencia de elegir un tipo documento 
            frm.COD_PER = TXT_COD.Text.Trim();
            //frm.CARGAR_FACTURACION(AÑO, MES);
            if (tip_ori == "F")
                frm.CARGAR_FACTURACION(AÑO, MES);
            else if (tip_ori == "C")
                frm.CARGAR_CONTRATO(AÑO, MES);
            if (frm.DGW_CAB.Rows.Count > 0)
            {
                frm.ShowDialog();
                if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    string origen = "";
                    if (tip_ori == "F")//si viene de Factura o Boleta
                        origen = CBO_DOC.SelectedValue.ToString();
                    else if (tip_ori == "C")//si viene de Contrato
                        origen = tip_ori;
                    INSERTAR_DE_DAILOG(origen);
                    frm.Hide();
                }
            }
            else
            {
                MessageBox.Show("No existen más documentos por devolver para este Cliente !!!", "Mensaje");//cambié contratos x documentos, pues es mas general
            }

        }
        private void INSERTAR_DE_DAILOG(string tip_ori)
        {
            //
            int inx = frm.DGW_CAB.CurrentRow.Index;
            if (tip_ori == "01" || tip_ori == "03")//boleta o factura
            {
                TXT_TC.Text = frm.DGW_CAB[4, inx].Value.ToString();
                DTP_FACT.Value = Convert.ToDateTime(frm.DGW_CAB[1, inx].Value);
                TXT_NRO_FACT.Text = frm.DGW_CAB[0, inx].Value.ToString();
                CBO_MONEDA.SelectedValue = frm.DGW_CAB[3, inx].Value;//.ToString() == "S" ? "SOLES" : frm.DGW_CAB[4, frm.DGW_CAB.CurrentRow.Index].Value.ToString() == "D" ? "DOLARES" : "";
                TXT_NRO_OC.Text = frm.DGW_CAB.Rows[inx].Cells["NRO_DOC_VTA"].Value.ToString();
                COD_REF = frm.DGW_CAB.Rows[inx].Cells["COD_REF"].Value.ToString();
            }
            else if (tip_ori == "C")
            {
                txt_tc_cc.Text = frm.DGW_CAB[4, inx].Value.ToString();
                dtp_fact_cc.Value = Convert.ToDateTime(frm.DGW_CAB[1, inx].Value);
                txt_nro_fact_cc.Text = frm.DGW_CAB[0, inx].Value.ToString();
                cbo_moneda_cc.SelectedValue = frm.DGW_CAB[3, inx].Value;//.ToString() == "S" ? "SOLES" : frm.DGW_CAB[4, frm.DGW_CAB.CurrentRow.Index].Value.ToString() == "D" ? "DOLARES" : "";
                TXT_NRO_OC.Text = frm.DGW_CAB.Rows[inx].Cells["NRO_DOC_VTA"].Value.ToString();
            }
            //
            NRO_DOC = frm.DGW_CAB.Rows[inx].Cells["NRO_DOC_VTA"].Value.ToString();
            NRO_PRESUPUESTO = frm.DGW_CAB.Rows[inx].Cells["NRO_PRESUPUESTO"].Value.ToString();
            CBO_MONEDA1 = frm.DGW_CAB.Rows[inx].Cells["COD_MONEDA"].Value.ToString();
            FORMA_PAGO = frm.DGW_CAB.Rows[inx].Cells["FORMA_PAGO"].Value.ToString();
            STATUS_PV = frm.DGW_CAB.Rows[inx].Cells["STATUS_PV"].Value.ToString();
            //COD_PER_ELAB = frm.DGW_CAB.Rows[inx].Cells["COD_PER_ELAB"].Value.ToString();
            COD_PER_APROB = frm.DGW_CAB.Rows[inx].Cells["COD_PER_APROB"].Value.ToString();
            STATUS_APROB = frm.DGW_CAB.Rows[inx].Cells["STATUS_APROB"].Value.ToString();
            STATUS_ANUL = frm.DGW_CAB.Rows[inx].Cells["STATUS_ANUL"].Value.ToString();
            STATUS_CIERRE = frm.DGW_CAB.Rows[inx].Cells["STATUS_CIERRE"].Value.ToString();
            COD_VENDEDOR = frm.DGW_CAB.Rows[inx].Cells["COD_VENDEDOR"].Value.ToString();
            CONDICION_VENTA = frm.DGW_CAB.Rows[inx].Cells["CONDICION_VENTA"].Value.ToString();
            COD_CONTACTO = frm.DGW_CAB.Rows[inx].Cells["COD_CONTACTO"].Value.ToString();
            TIPO_PRECIO = frm.DGW_CAB.Rows[inx].Cells["TIPO_PRECIO"].Value.ToString();
            OBSERVACION = frm.DGW_CAB.Rows[inx].Cells["OBSERVACION"].Value.ToString();
            COD_MOV = frm.DGW_CAB.Rows[inx].Cells["COD_MOV"].Value.ToString();
            COD_PROGRAMA = frm.DGW_CAB.Rows[inx].Cells["COD_PROGRAMA"].Value.ToString();
            PERIODO = frm.DGW_CAB.Rows[inx].Cells["PERIODO"].Value.ToString();
            NRO_SEMANA = frm.DGW_CAB.Rows[inx].Cells["NRO_SEMANA"].Value.ToString();
            TIPO_PLANILLA = frm.DGW_CAB.Rows[inx].Cells["TIPO_PLANILLA"].Value.ToString();
            COD_ALMACEN = frm.DGW_CAB.Rows[inx].Cells["COD_ALMACEN"].Value.ToString();

            COD_NIVEL1 = frm.DGW_CAB.Rows[inx].Cells["COD_NIVEL1"].Value.ToString();
            COD_NIVEL2 = frm.DGW_CAB.Rows[inx].Cells["COD_NIVEL2"].Value.ToString();
            COD_NIVEL3 = frm.DGW_CAB.Rows[inx].Cells["COD_NIVEL3"].Value.ToString();
            //STATUS_FAC = TIPO_ORIGEN == "F" ? "1" : "0";//frm.DGW_CAB.Rows[inx].Cells["STATUS_FAC"].Value.ToString();
            STATUS_FAC = tip_ori == "C" ? "0" : "1";// si no es C entonces es que esta facturado ya sea como FACTURA O Boleta
            STATUS_PV = frm.DGW_CAB.Rows[inx].Cells["STATUS_PV"].Value.ToString();
            NRO_REPORTE = frm.DGW_CAB.Rows[inx].Cells["NRO_REPORTE"].Value.ToString();
            TIPO_PEDIDO = frm.DGW_CAB.Rows[inx].Cells["TIPO_PEDIDO"].Value.ToString();
            STATUS_GUIA = frm.DGW_CAB.Rows[inx].Cells["STATUS_GUIA"].Value.ToString();
            //COD_REF = frm.DGW_CAB.Rows[inx].Cells["COD_REF"].Value.ToString();
            NRO_REF = frm.DGW_CAB.Rows[inx].Cells["NRO_REF"].Value.ToString();
            SERIE = NRO_DOC.Substring(0, 3);
            COD_SUB_PTO_VEN = frm.DGW_CAB.Rows[inx].Cells["COD_SUB_PTO_VEN"].Value.ToString();
            COD_CANAL_DSCTO = frm.DGW_CAB.Rows[inx].Cells["COD_CANAL_DSCTO"].Value.ToString();
            COD_PTO_COB = frm.DGW_CAB.Rows[inx].Cells["COD_PTO_COB"].Value.ToString();
            COD_TIPO_VENTA = frm.DGW_CAB.Rows[inx].Cells["COD_TIPO_VENTA"].Value.ToString();
            COD_MODALIDAD_VTA = frm.DGW_CAB.Rows[inx].Cells["COD_MOV"].Value.ToString();
            FECHA_PRE = Convert.ToDateTime(frm.DGW_CAB.Rows[inx].Cells["FECHA_PRE"].Value);

            FECHA_APROB = Convert.ToDateTime(frm.DGW_CAB.Rows[inx].Cells["FECHA_APROB"].Value);
            FEC_REPORTE = Convert.ToDateTime(frm.DGW_CAB.Rows[inx].Cells["FEC_REPORTE"].Value);
            FEC_PRIMER_VENC = frm.DGW_CAB.Rows[inx].Cells["FEC_PRIMER_VENC"].Value.ToString() == "" ? DateTime.Now : Convert.ToDateTime(frm.DGW_CAB.Rows[inx].Cells["FEC_PRIMER_VENC"].Value);
            FEC_CUO_MEN = Convert.ToDateTime(frm.DGW_CAB.Rows[inx].Cells["FEC_CUO_MEN"].Value);
            NRO_DIAS = Convert.ToInt32(frm.DGW_CAB.Rows[inx].Cells["NRO_DIAS"].Value);

            NRO_CUOTAS = Convert.ToInt32(frm.DGW_CAB.Rows[inx].Cells["NRO_CUOTAS"].Value);
            NRO_DIAS_VENC = Convert.ToInt32(frm.DGW_CAB.Rows[inx].Cells["NRO_DIAS_VENC"].Value);
            TIPO_CAMBIO = Convert.ToDecimal(frm.DGW_CAB.Rows[inx].Cells["TIPO_CAMBIO"].Value);

            SUELDO_NETO = Convert.ToDecimal(frm.DGW_CAB.Rows[inx].Cells["SUELDO_NETO"].Value);
            PRESTAMOS = Convert.ToDecimal(frm.DGW_CAB.Rows[inx].Cells["PRESTAMOS"].Value);
            OTROS_DSCTOS = Convert.ToDecimal(frm.DGW_CAB.Rows[inx].Cells["OTROS_DSCTOS"].Value);
            JUDICIALES = Convert.ToDecimal(frm.DGW_CAB.Rows[inx].Cells["JUDICIALES"].Value);
            NETO_COBRAR = Convert.ToDecimal(frm.DGW_CAB.Rows[inx].Cells["NETO_COBRAR"].Value);
            TOTAL_CONTRATO = Convert.ToDecimal(frm.DGW_CAB[2, inx].Value);
            IMP_CUOTA_INICIAL = Convert.ToDecimal(frm.DGW_CAB.Rows[inx].Cells["IMP_CUOTA_INICIAL"].Value);
            IMP_CUOTA_MES = Convert.ToDecimal(frm.DGW_CAB.Rows[inx].Cells["IMP_COUTA_MES"].Value);
            AÑO_DOC = frm.DGW_CAB.Rows[inx].Cells["AÑO_DOC"].Value.ToString();
            MES_DOC = frm.DGW_CAB.Rows[inx].Cells["MES_DOC"].Value.ToString();
            COD_KIT = frm.DGW_CAB.Rows[inx].Cells["COD_KIT"].Value.ToString();

            //TIPO_ORIGEN = tip_ori;
            if (tip_ori == "01")
                TIPO_ORIGEN = "F";
            else if (tip_ori == "03")
                TIPO_ORIGEN = "B";
            else if (tip_ori == "C")
                TIPO_ORIGEN = "C";

            dgw_det.Rows.Clear();
            int i = 0;
            int num = frm.DGW_DET.Rows.Count - 1;
            while (i <= num)
            {
                dgw_det.Rows.Add((dgw_det.Rows.Count + 1).ToString("00"), frm.DGW_DET[1, i].Value.ToString(), frm.DGW_DET[2, i].Value.ToString(), frm.DGW_DET[3, i].Value.ToString(), frm.DGW_DET[4, i].Value.ToString(), frm.DGW_DET[5, i].Value.ToString(), true, frm.DGW_DET[6, i].Value.ToString(), frm.DGW_DET[7, i].Value.ToString(), "1", frm.DGW_DET[8, i].Value.ToString(), frm.DGW_DET[9, i].Value.ToString(), 0, 0, "Devolucion de Compras", TXT_NRO_FACT.Text, frm.DGW_DET.Rows[i].Cells["ST_VALOR_REFERENCIAL"].Value.ToString());
                i++;
            }
            HALLAR_TOTAL_OC();
        }
        private void HALLAR_TOTAL_OC()
        {
            //decimal impor = 0, dscto = 0, igv = 0, neto = 0, total = 0;
            //foreach (DataGridViewRow rw in dgw_det.Rows)
            //{
            //    impor = impor + Convert.ToDecimal(rw.Cells[5].Value);
            //    dscto = dscto + Convert.ToDecimal(rw.Cells[11].Value);
            //}
            //total = impor;
            //neto = total;
            //igv = total - neto;
            //TXT_TB.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(neto.ToString());
            //TXT_TD.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(dscto.ToString());
            //TXT_TN.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(neto.ToString());
            //TXT_TIGV.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(igv.ToString());
            //TXT_TT.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(impor.ToString());

            decimal impor = 0, dscto = 0, igv = 0, neto = 0, total = 0;
            foreach (DataGridViewRow rw in dgw_det.Rows)
            {
                if (rw.Cells["ST_VALOR_REFERENCIAL"].Value.ToString() == "0")
                {
                    impor = impor + Convert.ToDecimal(rw.Cells[5].Value);
                    igv = 0;//igv + Convert.ToDecimal(rw.Cells[11].Value);
                    dscto = dscto + Convert.ToDecimal(rw.Cells[11].Value);
                }
            }
            total = impor;
            neto = total;
            TXT_TB.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES((impor - igv).ToString());
            TXT_TD.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(dscto.ToString());
            TXT_TN.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES((impor - igv).ToString());
            TXT_TIGV.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(igv.ToString());
            TXT_TT.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES((impor - dscto).ToString());
            //DSCTO_TOTAL1 = dscto;
        }
        private bool validaGrabar()
        {
            bool result = true;
            if (dgw_det.Rows.Count <= 0)
            {
                MessageBox.Show("No hay articulos en el detalle !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return result = false;
            }
            if (TabControl2.SelectedTab == TabPage5)
            {
                if (CBO_DOC.SelectedIndex <= -1)
                {
                    MessageBox.Show("Elija el Documento !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    CBO_DOC.Focus();
                    return result = false;
                }
                if (TXT_NRO_FACT.Text.Trim() == "")
                {
                    MessageBox.Show("Ingrese el Nro del Documento !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    TXT_NRO_FACT.Focus();
                    return result = false;
                }
                if (cbo_mot_dev.SelectedIndex <= -1)
                {
                    MessageBox.Show("Elija el Motivo de Devolución !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cbo_mot_dev.Focus();
                    return result = false;
                }
            }
            else if (TabControl2.SelectedTab == tabPage4)
            {
                if (cbo_doc_cc.SelectedIndex <= -1)
                {
                    MessageBox.Show("Elija el Documento !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cbo_doc_cc.Focus();
                    return result = false;
                }
                if (txt_nro_fact_cc.Text.Trim() == "")
                {
                    MessageBox.Show("Ingrese el Nro del Documento !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txt_nro_fact_cc.Focus();
                    return result = false;
                }
                if (cbo_mod_vta_cc.SelectedIndex <= -1)
                {
                    MessageBox.Show("Elija el Motivo de Devolución !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cbo_mod_vta_cc.Focus();
                    return result = false;
                }
            }
            return result;
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            TabControl1.SelectedTab = TabPage1;
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void btn_grabar_Click(object sender, EventArgs e)
        {
            if (!validaGrabar())
                return;

            DialogResult rs = MessageBox.Show("¿ Esta seguro de crear una orden de devolucion de ventas  ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";

                ccTo.COD_SUCURSAL = CBO_SUCURSAL.SelectedValue.ToString();
                ccTo.NRO_DOC = NRO_DOC;//LO CAMBIO POR TXT_NI
                ccTo.COD_PER = TXT_COD.Text;
                ccTo.COD_CLASE = CBO_CLASE.SelectedValue.ToString();
                ccTo.FE_AÑO = AÑO;
                ccTo.FE_MES = MES;
                ccTo.FECHA_DOC = DTP_OC.Value;
                ccTo.NRO_PRESUPUESTO = NRO_PRESUPUESTO;
                ccTo.FECHA_PRE = FECHA_PRE;
                ccTo.COD_MONEDA = CBO_MONEDA1;
                ccTo.TIPO_CAMBIO = TIPO_CAMBIO;
                ccTo.FORMA_PAGO = FORMA_PAGO;
                ccTo.STATUS_PV = STATUS_PV;
                ccTo.NRO_DIAS = NRO_DIAS;
                ccTo.COD_PER_ELAB = Convert.ToString(CBO_ELAB.SelectedValue);//COD_PER_ELAB;
                ccTo.COD_PER_APROB = COD_PER_APROB;
                ccTo.STATUS_APROB = STATUS_APROB;
                ccTo.STATUS_ANUL = STATUS_ANUL;
                ccTo.STATUS_CIERRE = STATUS_CIERRE;
                ccTo.COD_VENDEDOR = COD_VENDEDOR;
                ccTo.CONDICION_VENTA = CONDICION_VENTA;
                ccTo.COD_CONTACTO = COD_CONTACTO;
                ccTo.FECHA_APROB = FECHA_APROB;
                ccTo.TIPO_PRECIO = TIPO_PRECIO;
                ccTo.OBSERVACION = TXT_OBS_ENVIO.Text;//txt_obs_envio_cc.Text;//OBSERVACION;
                ccTo.COD_MOV = COD_MOV;
                ccTo.NRO_REPORTE = NRO_REPORTE;
                ccTo.FEC_REPORTE = FEC_REPORTE;
                ccTo.COD_PROGRAMA = COD_PROGRAMA;
                ccTo.PERIODO = PERIODO;
                ccTo.NRO_SEMANA = NRO_SEMANA;
                ccTo.TIPO_PLANILLA = TIPO_PLANILLA;
                ccTo.COD_ALMACEN = COD_ALMACEN;
                ccTo.COD_NIVEL1 = COD_NIVEL1;
                ccTo.COD_NIVEL2 = COD_NIVEL2;
                ccTo.COD_NIVEL3 = COD_NIVEL3;
                ccTo.SUELDO_NETO = SUELDO_NETO;
                ccTo.PRESTAMOS = PRESTAMOS;
                ccTo.OTROS_DSCTOS = OTROS_DSCTOS;
                ccTo.JUDICIALES = JUDICIALES;
                ccTo.NETO_COBRAR = NETO_COBRAR;
                ccTo.TOTAL_CONTRATO = TOTAL_CONTRATO;
                ccTo.NRO_CUOTAS = NRO_CUOTAS;
                ccTo.IMP_CUOTA_INICIAL = IMP_CUOTA_INICIAL;
                ccTo.IMP_CUOTA_MES = IMP_CUOTA_MES;
                ccTo.FEC_PRIMER_VENC = FEC_PRIMER_VENC;
                ccTo.NRO_DIAS_VENC = NRO_DIAS_VENC;
                ccTo.FEC_CUO_MEN = FEC_CUO_MEN;
                ccTo.STATUS_FAC = STATUS_FAC;
                ccTo.TIPO_PEDIDO = TIPO_PEDIDO;
                ccTo.STATUS_GUIA = STATUS_GUIA;
                ccTo.COD_REF = Convert.ToString(cboDevolverA.SelectedValue);//COD_REF;
                ccTo.NRO_REF = NRO_REF;
                ccTo.NOMBRE_PC = NOMBRE_PC;
                ccTo.SERIE = SERIE;
                ccTo.COD_SUB_PTO_VEN = COD_SUB_PTO_VEN;
                ccTo.COD_CANAL_DSCTO = COD_CANAL_DSCTO;
                ccTo.COD_PTO_COB = COD_PTO_COB;
                ccTo.COD_TIPO_VENTA = COD_TIPO_VENTA;
                //ccTo.COD_MODALIDAD_VTA = TIPO_ORIGEN == "F" ?  cbo_mot_dev.SelectedValue.ToString() : cbo_mod_vta_cc.SelectedValue.ToString();//aqui van los codigos de motivo de devolucion
                ccTo.COD_MODALIDAD_VTA = TIPO_ORIGEN == "C" ? cbo_mod_vta_cc.SelectedValue.ToString() : cbo_mot_dev.SelectedValue.ToString();
                //ccTo.NRO_FAC_PRE_UNI = TIPO_ORIGEN == "F" ? TXT_NRO_FACT.Text.Trim() : "";
                ccTo.NRO_FAC_PRE_UNI = TIPO_ORIGEN == "C" ? ccTo.NRO_PRESUPUESTO : TXT_NRO_FACT.Text.Trim();
                //ccTo.FECHA_FAC_PRE_UNI = TIPO_ORIGEN == "F" ? DTP_FACT.Value : (DateTime?)null;
                ccTo.FECHA_FAC_PRE_UNI = TIPO_ORIGEN == "C" ? (DateTime?)null : DTP_FACT.Value;
                ccTo.TIPO_ORIGEN = TIPO_ORIGEN;
                // NRO_FACT_PRE_UNI = TIPO_ORIGEN == "F" ? TXT_NRO_FACT.Text : txt_nro_fact_cc.Text;
                NRO_FACT_PRE_UNI = TIPO_ORIGEN == "C" ? txt_nro_fact_cc.Text : TXT_NRO_FACT.Text;
                ccTo.AÑO_DOC = AÑO_DOC;
                ccTo.MES_DOC = MES_DOC;
                ccTo.COD_KIT = COD_KIT;
                //DataTable dtDetalle = (DataTable)DGW_DET.DataSource;
                DT00.Rows.Clear();
                int num = dgw_det.Rows.Count - 1;
                int num3 = num;
                int i = 0, j = 0;
                while (i <= num3)
                {
                    if (Convert.ToBoolean(dgw_det[6, i].Value))
                    {
                        DT00.Rows.Add(CBO_SUCURSAL.SelectedValue.ToString(), NRO_DOC, NRO_FACT_PRE_UNI, TXT_COD.Text, CBO_CLASE.SelectedValue.ToString(),
                        AÑO, MES, (j + 1).ToString("00"), dgw_det[1, i].Value.ToString(), dgw_det[3, i].Value.ToString(), "0.000", "0.000",
                        dgw_det[4, i].Value.ToString(), dgw_det[5, i].Value.ToString(), dgw_det[7, i].Value.ToString(), dgw_det[8, i].Value.ToString(),
                        dgw_det[9, i].Value.ToString(), dgw_det[10, i].Value.ToString(), dgw_det[11, i].Value.ToString(), dgw_det[12, i].Value.ToString(),
                        dgw_det[13, i].Value.ToString(), "H", dgw_det[14, i].Value.ToString(), NOMBRE_PC, NRO_PRESUPUESTO,
                        (i + 1).ToString("00"), "", dgw_det[2, i].Value.ToString(), "", "0", dgw_det.Rows[i].Cells["ST_VALOR_REFERENCIAL"].Value.ToString());
                        j++;
                    }
                    i++;
                }
                if (!ccBLL.adicionaInsertaContratoOrdDevVtasBLL(ccTo, DT00, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("La orden de devolucion de ventas creo correctamente", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //TabControl1.SelectedTab = TabPage1;
                    DATAGRID();
                    DialogResult rs1 = MessageBox.Show("¿ Desea hacer el otro Documento ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rs1 == DialogResult.Yes)
                    {
                        if (TabControl2.SelectedTab == TabPage5)
                        {
                            btn_oc_Click(sender, e);
                        }
                        else if (TabControl2.SelectedTab == tabPage4)
                        {
                            btn_oc_cc_Click(sender, e);
                        }
                    }
                    else
                    {
                        //DGW.Select();
                        TabControl1.SelectedTab = TabPage1;
                        FOCO_NUEVO_REG();
                    }
                    //TabControl1.SelectedTab = TabPage1;
                    //FOCO_NUEVO_REG();
                }
            }
        }
        private void FOCO_NUEVO_REG()
        {
            int i, cont = 0;
            cont = DGW.Rows.Count - 1;
            string nrocon = "";
            if (txt_nro_fact_cc.Text != "" && TXT_NRO_FACT.Text == "")
                nrocon = txt_nro_fact_cc.Text;
            else if (txt_nro_fact_cc.Text == "" && TXT_NRO_FACT.Text != "")
                nrocon = TXT_NRO_FACT.Text;
            for (i = 0; i <= cont; i++)
            {
                if (nrocon == DGW.Rows[i].Cells["NRO_PRESUPUESTO"].Value.ToString())
                {
                    DGW.CurrentCell = DGW.Rows[i].Cells["NRO_PRESUPUESTO"];
                    return;
                }
            }
        }
        private void BTN_CONSULTA_Click(object sender, EventArgs e)
        {
            string tip_origen = DGW[3, DGW.CurrentRow.Index].Value.ToString();
            boton = "MODIFICAR";
            btn_grabar.Visible = false;
            //btn_grabar2.Visible = false;
            btn_imprimir.Enabled = true;
            TabControl1.SelectedTab = TabPage2;
            Panel1.Visible = true;
            LIMPIAR_CABECERA();
            LIMPIAR_DETALLES();
            CARGAR_DATOS(tip_origen);
            CARGAR_DETALLES_DGW();
            gb_oc.Enabled = false;
            dgw_det.ReadOnly = true;
            btn_ajuste.Enabled = false;
            HALLAR_TOTAL_OC();
        }
        private void LIMPIAR_DETALLES()
        {
            CBO_DOC.SelectedIndex = -1;
            TXT_NRO_FACT.Text = "";
            CBO_MONEDA.SelectedIndex = -1;
            TXT_TC.Text = "";
            cbo_mot_dev.SelectedIndex = -1;
            TXT_OBS_ENVIO.Text = "";
            //
            cbo_doc_cc.SelectedIndex = 0;
            txt_nro_fact_cc.Text = "";
            cbo_moneda_cc.SelectedIndex = -1;
            txt_tc_cc.Text = "";
            cbo_mod_vta_cc.SelectedIndex = -1;
            txt_obs_envio_cc.Text = "";
            //
            dgw_det.Rows.Clear();
        }
        private void CARGAR_DATOS(string tip_origen)
        {
            int i = DGW.CurrentRow.Index;
            CBO_SUCURSAL.SelectedValue = DGW.Rows[i].Cells["COD_SUCURSAL"].Value;
            CBO_CLASE.SelectedValue = DGW.Rows[i].Cells["COD_CLASE"].Value;
            TXT_COD.Text = DGW.Rows[i].Cells["COD_PER"].Value.ToString();
            TXT_DESC.Text = DGW.Rows[i].Cells["DESC_PER"].Value.ToString();
            txt_doc_per.Text = DGW.Rows[i].Cells["NRO_DOCU"].Value.ToString();
            CBO_ELAB.SelectedValue = DGW.Rows[i].Cells["COD_PER_ELAB"].Value.ToString();
            //
            if (tip_origen == "F" || tip_origen == "B")//si va a darse una devolucion con factura o boleta
            {
                CBO_DOC.SelectedValue = DGW.Rows[i].Cells["COD_DOC"].Value.ToString();
                TXT_NRO_FACT.Text = DGW.Rows[i].Cells["NRODOC"].Value.ToString();
                DTP_FACT.Value = Convert.ToDateTime(DGW.Rows[i].Cells["FECHA_DOC"].Value);
                CBO_MONEDA.SelectedValue = DGW.Rows[i].Cells["COD_MONEDA"].Value.ToString();
                TXT_TC.Text = string.Format(DGW.Rows[i].Cells["TIPO_CAMBIO"].Value.ToString(), "###,###,##.00");
                cbo_mot_dev.SelectedValue = DGW.Rows[i].Cells["COD_MODALIDAD_VTA"].Value.ToString();
                TXT_OBS_ENVIO.Text = DGW.Rows[i].Cells["OBSERVACION"].Value.ToString();
                cboDevolverA.SelectedValue = Convert.ToString(DGW.Rows[i].Cells["COD_REF"].Value);
            }
            else if (tip_origen == "C")//si va a darse una devolucion sin factura, solo con el contrato
            {
                cbo_doc_cc.SelectedIndex = 0;
                txt_nro_fact_cc.Text = DGW.Rows[i].Cells["NRODOC"].Value.ToString();
                dtp_fact_cc.Value = Convert.ToDateTime(DGW.Rows[i].Cells["FECHA_DOC"].Value);
                cbo_moneda_cc.SelectedValue = DGW.Rows[i].Cells["COD_MONEDA"].Value.ToString();
                txt_tc_cc.Text = string.Format(DGW.Rows[i].Cells["TIPO_CAMBIO"].Value.ToString(), "###,###,##.00");
                cbo_mod_vta_cc.SelectedValue = DGW.Rows[i].Cells["COD_MODALIDAD_VTA"].Value.ToString();
                txt_obs_envio_cc.Text = DGW.Rows[i].Cells["OBSERVACION"].Value.ToString();
            }
        }
        private void CARGAR_DETALLES_DGW()
        {
            dgw_det.Rows.Clear();
            int i = DGW.CurrentRow.Index;
            dcTo.COD_SUCURSAL = DGW.Rows[i].Cells["COD_SUCURSAL"].Value.ToString();
            dcTo.NRO_PRESUPUESTO = DGW.Rows[i].Cells["NRO_PRESUPUESTO"].Value.ToString();
            dcTo.COD_PER = DGW.Rows[i].Cells["COD_PER"].Value.ToString();
            dcTo.COD_CLASE = DGW.Rows[i].Cells["COD_CLASE"].Value.ToString();
            dcTo.FE_AÑO = DGW.Rows[i].Cells["FE_AÑO"].Value.ToString();
            dcTo.FE_MES = DGW.Rows[i].Cells["FE_MES"].Value.ToString();
            dcTo.COD_D_H = "H";
            dcTo.NRO_FAC_PRE_UNI = DGW.Rows[i].Cells["NRODOC"].Value.ToString();
            //dcTo.NRO_FAC_PRE_UNI = DGW.Rows[i].Cells["NRO_FAC_PRE_UNI"].Value.ToString();

            DataTable dt = dcBLL.obtenerOrdenDevVtaDetalleBLL(dcTo);
            if (dt.Rows.Count > 0)
            {
                //dgw_det.Rows.Clear();
                foreach (DataRow rw in dt.Rows)
                {
                    int rowId = dgw_det.Rows.Add();
                    DataGridViewRow row = dgw_det.Rows[rowId];
                    row.Cells[0].Value = rw["ITEM"].ToString();
                    row.Cells[1].Value = rw["COD_ARTICULO"].ToString();
                    row.Cells[2].Value = rw["DESC_ARTICULO"].ToString();
                    row.Cells[3].Value = rw["CANTIDAD_PED"].ToString();
                    row.Cells[4].Value = rw["PRECIO_UNIT"].ToString();
                    row.Cells[5].Value = rw["VALOR_COMPRA"].ToString();
                    row.Cells[6].Value = true;
                    row.Cells[7].Value = rw["POR_IGV"].ToString();
                    row.Cells[8].Value = rw["POR_DSCTO"].ToString();
                    row.Cells[10].Value = rw["VALOR_IGV"].ToString();
                    row.Cells[11].Value = rw["VALOR_DSCTO"].ToString();
                    row.Cells[12].Value = "0.00";
                    row.Cells[13].Value = "0.00";
                    row.Cells[14].Value = rw["OBSERVACION"].ToString();
                    row.Cells["ST_VALOR_REFERENCIAL"].Value = rw["ST_VALOR_REFERENCIAL"].ToString();
                }
            }
        }

        private void btn_aprobar_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("¿ Esta seguro de aprobar esta orden de devolucion de ventas  ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                ccTo.COD_SUCURSAL = DGW.CurrentRow.Cells["COD_SUCURSAL"].Value.ToString();
                ccTo.NRO_PRESUPUESTO = DGW.CurrentRow.Cells["NRO_PRESUPUESTO"].Value.ToString();
                ccTo.COD_PER = DGW.CurrentRow.Cells["COD_PER"].Value.ToString();
                ccTo.COD_CLASE = DGW.CurrentRow.Cells["COD_CLASE"].Value.ToString();
                ccTo.FE_AÑO = DGW.CurrentRow.Cells["FE_AÑO"].Value.ToString();
                ccTo.FE_MES = DGW.CurrentRow.Cells["FE_MES"].Value.ToString();
                ccTo.NRO_FAC_PRE_UNI = DGW.CurrentRow.Cells["NRO_FAC_PRE_UNI"].Value.ToString();
                ccTo.STATUS_NC = "1";

                if (!ccBLL.modificaApruebaOrdDevVtasBLL(ccTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("La orden de devolucion de ventas aprobó correctamente", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //TabControl1.SelectedTab = TabPage1;
                    DATAGRID();
                }
            }

        }

        private void btn_oc_cc_Click(object sender, EventArgs e)
        {
            if (!validaTraeFacturas("Contratos"))
                return;

            TabPage3.Select();
            //gb_oc.Enabled = false;
            //CBO_DOC.Enabled = false;
            boton3("C");//contrato
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (!validaEliminarOrdenDev())
                return;

            DialogResult rs = MessageBox.Show("¿ Esta seguro de eliminar la Orden de Devolucion ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                ccTo.COD_SUCURSAL = DGW.CurrentRow.Cells["COD_SUCURSAL"].Value.ToString();
                ccTo.COD_CLASE = DGW.CurrentRow.Cells["COD_CLASE"].Value.ToString();
                ccTo.NRO_DOC = DGW.CurrentRow.Cells["NRODOC"].Value.ToString();
                ccTo.COD_PER = DGW.CurrentRow.Cells["COD_PER"].Value.ToString();
                ccTo.AÑO_DOC = DGW.CurrentRow.Cells["FE_AÑO"].Value.ToString();
                ccTo.MES_DOC = DGW.CurrentRow.Cells["FE_MES"].Value.ToString();
                ccTo.NRO_PRESUPUESTO = DGW.CurrentRow.Cells["NRO_PRESUPUESTO"].Value.ToString();
                ccTo.TIPO_ORIGEN = DGW.CurrentRow.Cells["TIPO_ORIGEN"].Value.ToString();
                if (!ccBLL.eliminaContratoOrdDevVtasBLL(ccTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("La Orden de Devolucion se eliminó correctamente !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                DATAGRID();
            }
        }
        private bool validaEliminarOrdenDev()
        {
            bool result = true;
            return result;
        }

    }
}
