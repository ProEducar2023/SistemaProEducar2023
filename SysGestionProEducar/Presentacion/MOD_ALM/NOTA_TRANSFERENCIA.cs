using BLL;
using Entidades;
using System;
using System.Collections;
using System.Data;
using System.Windows.Forms;

namespace Presentacion.MOD_ALM
{
    public partial class NOTA_TRANSFERENCIA : Form
    {
        string BOTON, COD_SUCURSAL, COD_ALMACEN1, COD_ALMACEN2, COD_CLASE, COD_MOV;
        string AÑO = "", MES = "", COD_MOD = "", COD_USU = "", TIPO_USU = "";
        string COD_ACT = "", COD_CONTACTO = "", COD_DH = "", COD_MONEDA = "", COD_ELABORADO = "";
        DateTime FECHA_INI, FECHA_GRAL;
        DataTable dt00 = new DataTable();
        int fila, fila2, fila3;
        string Codigoelab; string NombreCompletoUsuario;
        DIALOGOS.Dialog3 obs = new DIALOGOS.Dialog3();
        DIALOGOS.frmValidarEliminarAnular frm = new DIALOGOS.frmValidarEliminarAnular();
        inventariosBLL invBLL = new inventariosBLL();
        inventariosTo invTo = new inventariosTo();
        HelpersBLL helBLL = new HelpersBLL();
        HelpersTo helTo = new HelpersTo();
        serieDocumentoBLL srdBLL = new serieDocumentoBLL();
        serieDocumentosTo srdTo = new serieDocumentosTo();
        string NOMBRE_PC = System.Environment.MachineName;
        DIALOGOS.CONSULTA_KIT frmKit = new DIALOGOS.CONSULTA_KIT();
        public NOTA_TRANSFERENCIA(string AÑO, string MES, DateTime FECHA_INI, DateTime FECHA_GRAL, string COD_MOD, string TIPO_USU, string COD_USU)
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

        private void NOTA_TRANSFERENCIA_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            DATAGRID();
            CargarAlmacenero();
            CARGAR_CLASE();
            CARGAR_SUCURSAL();
            CARGAR_MOV();
            CARGAR_PERSONAS();
            //dtp_inv.Value = Convert.ToDateTime(DateTime.Now.Day + "/" + FECHA_INI.Month + "/" + FECHA_INI.Year);
            dtp_inv.Value = HelpersBLL.validaFecha(MES, AÑO, FECHA_GRAL);
            //DIRECTORIO_CONFIGURACION();
            //EstadoEnabledAnular();
            ////DGW_DET.ColumnHeadersDefaultCellStyle.Font = (New Font("ARIAL", 8.0!, FontStyle.Bold))
            ////dgw1.ColumnHeadersDefaultCellStyle.Font = (New Font("ARIAL", 8.0!, FontStyle.Bold))
            dt00.Columns.Add("COD_SUCURSAL");
            dt00.Columns.Add("COD_CLASE");
            dt00.Columns.Add("COD_PER");
            //dt00.Columns.Add("COD_DOC");
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
        private void CARGAR_PERSONAS()
        {
            //DataTable dt = helBLL.MOSTRAR_PERSONAS_XCOBRAR_BLL(helTo);
            DataTable dt = helBLL.MOSTRAR_PERSONAS_XPAGAR_PERSONAL_BLL();
            if (dt.Rows.Count > 0)
            {
                dgw_per.DataSource = dt;
                dgw_per.Columns[0].Width = 60;
                dgw_per.Columns[1].Width = 300;
                dgw_per.Columns[2].Width = 80;
                //dgw_per.Columns[3].Visible = false;
                //dgw_per.Columns[4].Visible = false;
                //dgw_per.Columns[5].Visible = false;
            }
        }
        private void CARGAR_MOV()
        {
            movimientosBLL movBLL = new movimientosBLL();
            DataTable dt = movBLL.obtenerMovimientosparaTransferenciaBLL();
            cbo_mov.ValueMember = "COD_MOV";
            cbo_mov.DisplayMember = "DESC_MOV";
            cbo_mov.DataSource = dt;
            cbo_mov.SelectedIndex = 0;
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
            cbo_clase.SelectedIndex = 0;
        }
        private void CargarAlmacenero()
        {
            personalBLL perBLL = new personalBLL();
            DataTable dt = perBLL.obtenerPersonalparaInventarioBLL();
            cbo_elab.ValueMember = "COD_PER";
            cbo_elab.DisplayMember = "DESC_PER";
            cbo_elab.DataSource = dt;
            cbo_elab.SelectedIndex = 0;
        }
        private void NOTA_TRANSFERENCIA_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }
        private void DATAGRID()
        {
            invTo.FE_AÑO = AÑO;
            invTo.FE_MES = MES;
            invTo.TIPO_USU = TIPO_USU;
            invTo.COD_USU = COD_USU;
            DataTable dt = invBLL.Mostrar_Nota_TransferenciaBLL(invTo);
            lbl_nro_reg_docs.Text = "Nro de Registros : 0";
            if (dt.Rows.Count > 0)
            {
                lbl_nro_reg_docs.Text = "Nro de Registros : " + dt.Rows.Count.ToString();
                dgw1.DataSource = dt;
                dgw1.Columns[0].Visible = false;
                dgw1.Columns[2].Visible = false;
                dgw1.Columns[5].Visible = false;
                dgw1.Columns[7].Visible = false;
                dgw1.Columns[8].Visible = false;
                dgw1.Columns[9].Visible = false;
                dgw1.Columns[11].Visible = false;
                dgw1.Columns[12].Visible = false;
                dgw1.Columns[13].Visible = false;
                dgw1.Columns[1].Width = 120;
                dgw1.Columns[3].Width = 120;
                dgw1.Columns[4].Width = 80;
                dgw1.Columns[6].Width = 230;
                dgw1.Columns[10].Width = 70;
                dgw1.Columns[14].Width = 150;
                dgw1.Columns[15].Width = 35;
                dgw1.Columns[16].Width = 35;
                dgw1.Columns[17].Width = 35;
            }
        }
        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            BOTON = "NUEVO";
            btn_grabar.Visible = true;
            btn_grabar2.Visible = false;
            btn_grabar.Enabled = true;
            btn_imprimir.Enabled = false;
            TabControl1.SelectedTab = (TabPage2);

            cbo_ni.Visible = true;
            TXT_NI.Visible = false;
            LIMPIAR_CABECERA();
            Panel1.Visible = true;
            Panel2.Visible = false;
            Panel0.Enabled = true;
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
            txt_obs.Enabled = true;
            Panel_PER.Visible = false;
            gb_cab.Enabled = true;
            DGW_DET.Rows.Clear();
            Panel1.Visible = true;
            Panel2.Visible = false;
            Panel0.Enabled = true;
            //dtp_inv.Value = DateTime.Now;
            cbo_elab.SelectedIndex = 0;
        }
        private void btn_agregar_x_kit_Click(object sender, EventArgs e)
        {
            if (!validaAgregar())
                return;
            COD_ALMACEN1 = cbo_almacen1.SelectedValue.ToString();
            COD_ALMACEN2 = cbo_almacen2.SelectedValue.ToString();
            DGW_CAB_DIALOG();
            //
            frmKit.ShowDialog();
            if (frmKit.DialogResult == DialogResult.OK)
            {
                Insertar_Registros_del_Kit();
            }
        }
        private void Insertar_Registros_del_Kit()
        {
            DGW_DET.Rows.Clear();
            int j = 1;
            foreach (DataGridViewRow rw in frmKit.DGW_DET.Rows)
            {
                insertar_dos_veces_en_grid_detalle(rw, j);
                j++;
            }
        }
        private void insertar_dos_veces_en_grid_detalle(DataGridViewRow rw, int j)
        {
            string str;
            for (int i = 0; i <= 1; i++)//dos veces
            {
                str = j.ToString().PadLeft(2, '0');
                int idx = DGW_DET.Rows.Add();
                DataGridViewRow row = DGW_DET.Rows[idx];
                row.Cells[0].Value = str;
                row.Cells[1].Value = rw.Cells[0].Value;
                row.Cells[2].Value = rw.Cells[1].Value;
                row.Cells[3].Value = rw.Cells[4].Value;
                row.Cells[4].Value = i == 0 ? COD_ALMACEN1 : COD_ALMACEN2;
                row.Cells[5].Value = i == 0 ? cbo_almacen1.Text : cbo_almacen2.Text;
                row.Cells[6].Value = i == 0 ? "H" : "D";
                row.Cells[7].Value = "";
                row.Cells[8].Value = i == 0 ? "" : txt_obs.Text;
                row.Cells[9].Value = "";
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
                frmKit.txt_cantidad_a_ingresar.Clear();
                frmKit.lbl_cantidad_a_ingresar.Visible = true;
                frmKit.txt_cantidad_a_ingresar.Visible = true;
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
        private void btn_agregar_Click(object sender, EventArgs e)
        {
            if (!validaAgregar())
                return;

            COD_ALMACEN1 = cbo_almacen1.SelectedValue.ToString();
            COD_ALMACEN2 = cbo_almacen2.SelectedValue.ToString();
            gb_cab.Enabled = false;
            Panel1.Visible = false;
            Panel2.Visible = true;
            Panel2.BringToFront();
            LIMPIAR_DETALLES();
            TXT_COD_PRO.Focus();
        }
        public bool validaAgregar()
        {
            bool result = true;
            if (cbo_sucursal.SelectedIndex <= -1)
            {
                MessageBox.Show("Elija la Sucursal !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_sucursal.Focus();
                return result = false;
            }
            if (cbo_mov.SelectedIndex <= -1)
            {
                MessageBox.Show("Elija el Movimiento !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_mov.Focus();
                return result = false;
            }
            if (cbo_clase.SelectedIndex <= -1)
            {
                MessageBox.Show("Elija la Clase !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_clase.Focus();
                return result = false;
            }
            if (TXT_COD.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el Codigo !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TXT_COD.Focus();
                return result = false;
            }
            if (TXT_DESC.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el Nombre !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TXT_DESC.Focus();
                return result = false;
            }
            if (txt_doc_per.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el DNI !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_doc_per.Focus();
                return result = false;
            }
            if (cbo_almacen1.SelectedIndex <= -1)
            {
                MessageBox.Show("Elija el almacen de Origen !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_almacen1.Focus();
                return result = false;
            }
            if (cbo_almacen2.SelectedIndex <= -1)
            {
                MessageBox.Show("Elija el almacen de Destino !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_almacen2.Focus();
                return result = false;
            }
            if (cbo_elab.SelectedIndex <= -1)
            {
                MessageBox.Show("Elija quien lo ejecuta !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_elab.Focus();
                return result = false;
            }
            if (dtp_inv.Value.Date < FECHA_INI.Date || dtp_inv.Value.Date > FECHA_GRAL.Date)
            {
                MessageBox.Show("Fecha no se encuentra en el Periodo !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtp_inv.Focus();
                return result = false;
            }
            if (cbo_almacen1.SelectedValue.ToString() == cbo_almacen2.SelectedValue.ToString())
            {
                MessageBox.Show("El almacén de origen es mismo que el de destino !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_almacen2.Focus();
                return result = false;
            }
            return result;
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
            DGW_PRO.Columns[0].Width = 40;
            DGW_PRO.Columns[1].Width = 300;
            DGW_PRO.Columns[2].Visible = false;
            DGW_PRO.Columns[3].Visible = false;
            DGW_PRO.Columns[4].Visible = false;
            DGW_PRO.Columns[5].Width = 40;
        }
        private void CARGAR_ALMACEN()
        {
            almacenesBLL almBLL = new almacenesBLL();
            almacenTo almTo = new almacenTo();
            almTo.COD_CLASE = COD_CLASE;
            almTo.COD_SUCURSAL = COD_SUCURSAL;
            cbo_almacen1.ValueMember = "COD_ALMACEN";
            cbo_almacen1.DisplayMember = "DESC_CORTA";
            cbo_almacen1.DataSource = almBLL.obtenerAlmacenesparaInventarioBLL(almTo);
            //
            cbo_almacen2.ValueMember = "COD_ALMACEN";
            cbo_almacen2.DisplayMember = "DESC_CORTA";
            cbo_almacen2.DataSource = almBLL.obtenerAlmacenesparaInventarioBLL(almTo);
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
            srdTo.COD_DOC = "03";
            sr = srdBLL.obtenerNro_IngBLL(srdTo);
            return sr.ToString("0000000");
        }

        private void cbo_sucursal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_sucursal.SelectedValue != null)
            {
                if (cbo_sucursal.SelectedIndex > -1)
                {
                    cbo_ni.Enabled = true;
                    COD_SUCURSAL = cbo_sucursal.SelectedValue.ToString();
                    CARGAR_NRO_SALIDA();
                    if (cbo_clase.SelectedIndex > -1)
                        CARGAR_ALMACEN();
                }
            }
        }
        private void CARGAR_NRO_SALIDA()
        {
            cbo_ni.DataSource = null;
            srdTo.COD_SUCURSAL = cbo_sucursal.SelectedValue.ToString();
            //mosTo.COD_MOV = cbo_mov.SelectedValue.ToString();
            //mosTo.STATUS_DOC = "0";
            //mosTo.COD_DOC = "03";
            DataTable dt = srdBLL.CBO_NRO_NOTAS_TRANS(srdTo);
            cbo_ni.DataSource = dt;
            cbo_ni.ValueMember = "SERIE";
            cbo_ni.DisplayMember = "SERIE";
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
                    Panel_PER.BringToFront();
                    Panel_PER.Visible = true;
                    dgw_per.Visible = true;
                    dgw_per.Focus();
                }
            }
            else
            {
                if (dgw_per.Rows.Count > 0)
                {
                    Panel_PER.BringToFront();
                    Panel_PER.Visible = true;
                    dgw_per.Visible = true;
                    dgw_per.Focus();
                    dgw_per.CurrentCell = dgw_per.Rows[0].Cells[0];
                }
            }
        }
        //private void TXT_COD_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter && TXT_COD.Text.Trim() != "")
        //    {
        //        if (dgw_per.Rows.Count > 0)
        //        {
        //            dgw_per.Sort(dgw_per.Columns[0], System.ComponentModel.ListSortDirection.Ascending);
        //            int num2 = dgw_per.Rows.Count - 1;
        //            int i = 0;
        //            while (i <= num2)
        //            {
        //                if (dgw_per[0, i].Value.ToString().Length >= TXT_COD.TextLength)
        //                {
        //                    if (TXT_COD.Text.ToLower() == dgw_per[0, i].Value.ToString().ToLower().Substring(0, TXT_COD.TextLength))
        //                    {
        //                        dgw_per.CurrentCell = dgw_per.Rows[i].Cells[0];
        //                        break;
        //                    }
        //                }
        //                dgw_per.CurrentCell = dgw_per.Rows[0].Cells[0];
        //                i += 1;
        //            }
        //            Panel_PER.Visible = true;
        //            dgw_per.Visible = true;
        //            Panel_PER.Focus();
        //        }
        //        else
        //        {
        //            MessageBox.Show("No existen Persona X Pagar !!!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //        }
        //    }
        //}
        private void TXT_DESC_Leave(object sender, EventArgs e)
        {
            if (TXT_DESC.Text == "")
            {
                if (dgw_per.Rows.Count > 0)
                {
                    Panel_PER.Visible = true;
                    dgw_per.Visible = true;
                    dgw_per.Focus();
                    dgw_per.CurrentCell = dgw_per.Rows[0].Cells[0];
                }
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
        //private void TXT_DESC_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter && TXT_DESC.Text.Trim() != "")
        //    {
        //        if (dgw_per.Rows.Count > 0)
        //        {
        //            dgw_per.Sort(dgw_per.Columns[1], System.ComponentModel.ListSortDirection.Ascending);
        //            int num2 = dgw_per.Rows.Count - 1;
        //            int i = 0;
        //            while (i <= num2)
        //            {
        //                if (dgw_per[1, i].Value.ToString().Length >= TXT_DESC.TextLength)
        //                {
        //                    if (TXT_DESC.Text.ToLower() == dgw_per[1, i].Value.ToString().ToLower().Substring(0, TXT_DESC.TextLength))
        //                    {
        //                        dgw_per.CurrentCell = dgw_per.Rows[i].Cells[0];
        //                        break;
        //                    }
        //                }

        //                dgw_per.CurrentCell = dgw_per.Rows[0].Cells[0];
        //                i += 1;
        //            }
        //            Panel_PER.Visible = true;
        //            dgw_per.Visible = true;
        //            Panel_PER.Focus();
        //        }
        //        else
        //        {
        //            MessageBox.Show("No existen Persona X Pagar !!!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //        }
        //    }
        //}

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
                kl1.Focus();
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

        private void btn_cancelar2_Click(object sender, EventArgs e)
        {
            Panel1.Visible = true;
            Panel2.Visible = false;
            btn_agregar.Focus();
        }

        private void btn_guardar2_Click(object sender, EventArgs e)
        {
            if (!validaAdicionaModificaItem())
                return;

            //SALDO_PRODUCTO();
            string str = DGW_DET.Rows.Count == 0 ? "01" : hallar_item(Convert.ToInt32(DGW_DET.Rows[DGW_DET.Rows.Count - 1].Cells[0].Value));
            string UBI1 = "";//helBLL.ObtenerUbicacionArticulo(COD_ALMACEN1, TXT_COD_PRO.Text);
            string UBI2 = "";// OBJ.ObtenerUbicacionArticulo(COD_ALMACEN2, TXT_COD_PRO.Text);
            DGW_DET.Rows.Add(str, TXT_COD_PRO.Text, TXT_DESC_PRO.Text, txt_cant.Text, COD_ALMACEN1, cbo_almacen1.Text, "H", TXT_NRO_PARTE.Text, "", UBI1);
            DGW_DET.Rows.Add(str, TXT_COD_PRO.Text, TXT_DESC_PRO.Text, txt_cant.Text, COD_ALMACEN2, cbo_almacen2.Text, "D", TXT_NRO_PARTE.Text, obs.txt_obs.Text, UBI2);
            LIMPIAR_DETALLES();
            TXT_COD_PRO.Focus();
        }
        private void LIMPIAR_DETALLES()
        {
            TXT_COD_PRO.Clear();
            TXT_DESC_PRO.Clear();
            TXT_NRO_PARTE.Clear();
            obs.txt_obs.Clear();
            txt_cant.Text = "0.00";
            Panel_PRO.Visible = false;
        }
        private string hallar_item(int it)
        {
            string ite = (it + 1).ToString();
            return ite.PadLeft(2, '0');
        }
        private bool validaAdicionaModificaItem()
        {
            bool result = true;
            if (TXT_COD_PRO.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el Producto", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TXT_COD_PRO.Focus();
                return result = false;
            }
            if (Panel_PRO.Visible)
            {
                MessageBox.Show("Elija el Producto", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                DGW_PRO.Focus();
                return result = false;
            }
            if (txt_cant.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese la Cantidad", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_cant.Focus();
                return result = false;
            }
            //SALDO DEL PRODUCTO
            return result;

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
                        //if (DGW_PRO[3, i].Value.ToString() == "0")
                        //    CH_IGV.Checked = false;
                        //else
                        //    CH_IGV.Checked = true;
                        //Panel_PRO.Visible = false;
                        //TXT_CANT.Focus();
                        txt_cant.Focus();
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

        private void DGW_PRO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int idx = DGW_PRO.CurrentRow.Index;
                TXT_COD_PRO.Text = DGW_PRO[0, idx].Value.ToString();
                TXT_DESC_PRO.Text = DGW_PRO[1, idx].Value.ToString();
                TXT_NRO_PARTE.Text = DGW_PRO[2, idx].Value.ToString();
                Panel_PRO.Visible = false;
                kl2.Focus();
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

        private void btn_grabar_Click(object sender, EventArgs e)
        {
            if (!validaAdicionaModificaTR())
                return;

            DialogResult rs = MessageBox.Show("¿ Esta seguro de crear una nueva Nota de Transferencia ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                txt_numero.Text = HALLAR_NRO_ING(cbo_ni.Text);
                COD_MOV = cbo_mov.SelectedValue.ToString();
                COD_ELABORADO = "";
                if (cbo_elab.SelectedIndex != -1)
                {
                    COD_ELABORADO = cbo_elab.SelectedValue.ToString();
                }

                string errMensaje = "";
                invTo.COD_SUCURSAL = COD_SUCURSAL;
                invTo.COD_CLASE = COD_CLASE;
                invTo.COD_PER = TXT_COD.Text;
                invTo.COD_CLASE_PER = "1";
                invTo.NRO_DOC_PER = txt_doc_per.Text;
                invTo.COD_DOC_INV = "03";
                invTo.NRO_DOC_INV = cbo_ni.Text.Substring(0, 3) + "-" + txt_numero.Text;
                invTo.SERIE = cbo_ni.Text.Substring(0, 3);
                invTo.NUMERO = txt_numero.Text;
                invTo.FE_AÑO = AÑO;
                invTo.FE_MES = MES;
                invTo.COD_MOV = COD_MOV;
                invTo.COD_MONEDA = "S";// COD_MONEDA;
                invTo.FECHA_DOC_INV = dtp_inv.Value.Date;
                invTo.FECHA_DOC = null;
                invTo.COD_DOC = "";
                invTo.NRO_DOC = "";
                invTo.OBSERVACION = txt_obs.Text;
                invTo.TIPO_CAMBIO = 0;// Convert.ToDecimal(TXT_TC.Text);
                invTo.STATUS_PV = "";
                invTo.COD_USU = COD_USU;
                invTo.FECHA = DateTime.Now;
                invTo.NOMBRE_PC = NOMBRE_PC;
                invTo.COD_ELABORADO = COD_ELABORADO;
                invTo.FECHA_DOC_ARTICULO = DateTime.Now;//dtp_doc.Value;
                invTo.COD_ALMACEN1 = COD_ALMACEN1;
                invTo.COD_ALMACEN2 = COD_ALMACEN2;

                dt00.Rows.Clear();
                int num = DGW_DET.Rows.Count - 1;
                int num3 = num;
                ArrayList ListaSerie = new ArrayList();
                int i = 0;
                while (i <= num3)
                {
                    dt00.Rows.Add(COD_SUCURSAL, COD_CLASE, TXT_COD.Text, "03", (cbo_ni.Text.Substring(0, 3) + "-" + txt_numero.Text),
                    AÑO, MES, (i + 1).ToString("00"), DGW_DET[0, i].Value.ToString(), DGW_DET[1, i].Value.ToString(), DGW_DET[3, i].Value.ToString(), 0, DGW_DET[6, i].Value.ToString(),
                    "S", DGW_DET[4, i].Value.ToString(), "0.00", "0.00", "0.00", "0.00", "1", "0.00", "0.00", "0.00", "0.00", "", "1",
                    NOMBRE_PC, "", DateTime.Now, DGW_DET[8, i].Value.ToString(), "");
                    i++;
                }

                if (!invBLL.adicionaTransferenciaInventariosBLL(invTo, dt00, ref errMensaje))
                {
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (!helBLL.ELIMINAR_TEMPORAL("INV", NOMBRE_PC, ref errMensaje))
                        MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //CARGAR_DETALLES_DGW2();
                    MessageBox.Show("La Nota de Transferencia se guardó", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    srdTo.COD_SUCURSAL = COD_SUCURSAL;
                    srdTo.COD_DOC = "03";
                    srdTo.STATUS_DOC = "0";
                    srdTo.SERIE = cbo_ni.Text;
                    //txt_numero.Text = srdBLL.HALLAR_NRO_ACTUAL(srdTo);
                    DATAGRID();
                    CARGAR_NRO_INGRESO();
                    FOCO_NUEVO_REG();
                    Panel1.Visible = true;
                    Panel2.Visible = false;
                    Panel0.Enabled = false;
                    btn_grabar.Enabled = false;
                    btn_imprimir.Enabled = true;
                    btn_imprimir.Focus();
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
            mvsTo.COD_DOC = "03";
            cbo_ni.ValueMember = "SERIE";
            cbo_ni.DisplayMember = "SERIE";
            cbo_ni.DataSource = mvsBLL.obtenerMovimientoSerieparaInventarioBLL(mvsTo);
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
        private bool validaAdicionaModificaTR()
        {
            bool result = true;

            return result;
        }

        private void BTN_CANCELAR_Click(object sender, EventArgs e)
        {
            TabControl1.SelectedTab = TabPage1;
        }

        private void btn_consulta_Click(object sender, EventArgs e)
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
                DIALOGOS.CONSULTA_SALDO_TRANSFERENCIA frm = new DIALOGOS.CONSULTA_SALDO_TRANSFERENCIA(COD_CLASE, COD_ALMACEN1, cbo_almacen1.Text, COD_ALMACEN2, cbo_almacen2.Text, TXT_COD_PRO.Text, TXT_DESC_PRO.Text);
                frm.ShowDialog();
            }
        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            if (!validaModificarEliminar())
                return;

            BOTON = "MODIFICAR";
            btn_grabar.Visible = false;
            btn_grabar2.Visible = true;
            btn_grabar2.Enabled = true;
            btn_imprimir.Enabled = false;
            TabControl1.SelectedTab = (TabPage2);
            LIMPIAR_CABECERA();
            gb_cab.Enabled = false;
            Panel1.Visible = true;
            Panel2.Visible = false;
            Panel1.Enabled = true;
            Panel0.Enabled = true;
            CARGAR_DATOS();
            CARGAR_DETALLES_DGW();
            //CargarUbicacion();
            cbo_ni.Visible = false;
            TXT_NI.Visible = true;
            cbo_sucursal.Focus();
        }
        private void CARGAR_DATOS()
        {
            cbo_ni.SelectedIndex = -1;
            COD_SUCURSAL = dgw1.CurrentRow.Cells[0].Value.ToString();
            cbo_sucursal.Text = dgw1.CurrentRow.Cells[1].Value.ToString();
            COD_CLASE = dgw1.CurrentRow.Cells[2].Value.ToString();
            cbo_clase.Text = dgw1.CurrentRow.Cells[3].Value.ToString();
            string str = dgw1.CurrentRow.Cells[4].Value.ToString();
            TXT_NI.Text = str.Substring(0, 3);
            txt_numero.Text = str.Substring(4, 7);
            TXT_COD.Text = dgw1.CurrentRow.Cells[5].Value.ToString();
            TXT_DESC.Text = dgw1.CurrentRow.Cells[6].Value.ToString();
            txt_doc_per.Text = dgw1.CurrentRow.Cells[7].Value.ToString();
            COD_MOV = dgw1.CurrentRow.Cells[8].Value.ToString();
            cbo_mov.Text = dgw1.CurrentRow.Cells[9].Value.ToString();
            dtp_inv.Value = Convert.ToDateTime(dgw1.CurrentRow.Cells[10].Value);
            txt_obs.Text = dgw1.CurrentRow.Cells[11].Value.ToString();
            COD_ALMACEN1 = dgw1.CurrentRow.Cells[12].Value.ToString();
            COD_ALMACEN2 = dgw1.CurrentRow.Cells[13].Value.ToString();
            cbo_almacen1.SelectedValue = COD_ALMACEN1;
            cbo_almacen2.SelectedValue = COD_ALMACEN2;
            cbo_elab.Text = dgw1.CurrentRow.Cells[14].Value.ToString();
        }
        private void CARGAR_DETALLES_DGW()
        {
            DGW_DET.Rows.Clear();
            invTo.COD_CLASE = COD_CLASE;
            invTo.COD_SUCURSAL = COD_SUCURSAL;
            invTo.COD_PER = TXT_COD.Text;
            invTo.NRO_DOC_INV = TXT_NI.Text + "-" + txt_numero.Text;
            invTo.FE_AÑO = AÑO;
            invTo.FE_MES = MES;
            //bool IGV_CERO;
            int idx;
            DataTable dt = invBLL.obtenerMostrar_Nota_Transferencia_DetalleBLL(invTo);
            foreach (DataRow rw in dt.Rows)
            {
                idx = DGW_DET.Rows.Add();
                //IGV_CERO = Convert.ToDecimal(rw[6]) == 0 ? true : false;
                DataGridViewRow row = DGW_DET.Rows[idx];
                row.Cells[0].Value = rw[0].ToString();
                row.Cells[1].Value = rw[1].ToString();
                row.Cells[2].Value = rw[2].ToString();
                row.Cells[3].Value = rw[3].ToString();
                row.Cells[4].Value = rw[4].ToString();
                row.Cells[5].Value = rw[5].ToString();
                row.Cells[6].Value = rw[6].ToString();
                row.Cells[7].Value = rw[7].ToString();
                row.Cells[8].Value = rw[8].ToString();
                row.Cells[9].Value = "";
            }
        }
        private bool validaModificarEliminar()
        {
            bool result = true;

            try
            {
                int num = dgw1.CurrentRow.Index;
            }
            catch (Exception)
            {
                MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return result = false;
            }
            if (Convert.ToBoolean(dgw1.CurrentRow.Cells[15].Value))
            {
                MessageBox.Show("La Nota de Transf. se transfirió a Costos.", "No se puede eliminar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return result = false;
            }
            if (Convert.ToBoolean(dgw1.CurrentRow.Cells[16].Value))
            {
                MessageBox.Show("La Nota de Transf. tiene una Guia.", "No se puede eliminar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return result = false;
            }
            return result;
        }

        private void btn_grabar2_Click(object sender, EventArgs e)
        {
            if (!validaAdicionaModificaTR())
                return;

            DialogResult rs = MessageBox.Show("¿ Esta seguro de modificar la Nota de Transferencia ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                //txt_numero.Text = HALLAR_NRO_ING(cbo_ni.Text);
                COD_MOV = cbo_mov.SelectedValue.ToString();
                COD_ELABORADO = "";
                if (cbo_elab.SelectedIndex != -1)
                {
                    COD_ELABORADO = cbo_elab.SelectedValue.ToString();
                }

                string errMensaje = "";
                invTo.COD_SUCURSAL = COD_SUCURSAL;
                invTo.COD_CLASE = COD_CLASE;
                invTo.COD_PER = TXT_COD.Text;
                invTo.COD_CLASE_PER = "1";
                invTo.NRO_DOC_PER = txt_doc_per.Text;
                invTo.COD_DOC_INV = "03";
                invTo.NRO_DOC_INV = TXT_NI.Text.Substring(0, 3) + "-" + txt_numero.Text;
                invTo.SERIE = TXT_NI.Text.Substring(0, 3);
                invTo.NUMERO = txt_numero.Text;
                invTo.FE_AÑO = AÑO;
                invTo.FE_MES = MES;
                invTo.COD_MOV = COD_MOV;
                invTo.COD_MONEDA = "S";// COD_MONEDA;
                invTo.FECHA_DOC_INV = dtp_inv.Value;
                invTo.FECHA_DOC = null;
                invTo.COD_DOC = "";
                invTo.NRO_DOC = "";
                invTo.OBSERVACION = txt_obs.Text;
                invTo.TIPO_CAMBIO = 0;// Convert.ToDecimal(TXT_TC.Text);
                invTo.STATUS_PV = "";
                invTo.COD_USU = COD_USU;
                invTo.FECHA = DateTime.Now;
                invTo.NOMBRE_PC = NOMBRE_PC;
                invTo.COD_ELABORADO = COD_ELABORADO;
                invTo.FECHA_DOC_ARTICULO = DateTime.Now;//dtp_doc.Value;
                invTo.COD_ALMACEN1 = COD_ALMACEN1;
                invTo.COD_ALMACEN2 = COD_ALMACEN2;

                dt00.Rows.Clear();
                int num = DGW_DET.Rows.Count - 1;
                int num3 = num;
                ArrayList ListaSerie = new ArrayList();
                int i = 0;
                while (i <= num3)
                {
                    dt00.Rows.Add(COD_SUCURSAL, COD_CLASE, TXT_COD.Text, "03", (TXT_NI.Text.Substring(0, 3) + "-" + txt_numero.Text),
                    AÑO, MES, (i + 1).ToString("00"), DGW_DET[0, i].Value.ToString(), DGW_DET[1, i].Value.ToString(), DGW_DET[3, i].Value.ToString(), 0, DGW_DET[6, i].Value.ToString(),
                    "S", DGW_DET[4, i].Value.ToString(), "0.00", "0.00", "0.00", "0.00", "1", "0.00", "0.00", "0.00", "0.00", "", "1",
                    NOMBRE_PC, "", DateTime.Now, DGW_DET[8, i].Value.ToString(), "");
                    i++;
                }

                if (!invBLL.modificaTransferenciaInventariosBLL(invTo, dt00, ref errMensaje))
                {
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (!helBLL.ELIMINAR_TEMPORAL("INV", NOMBRE_PC, ref errMensaje))
                        MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("La Nota de Transferencia se actualizó", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    DATAGRID();
                    //CARGAR_NRO_INGRESO();
                    //FOCO_NUEVO_REG();
                    Panel1.Visible = true;
                    Panel2.Visible = false;
                    Panel0.Enabled = false;
                    btn_grabar.Enabled = false;
                    btn_imprimir.Enabled = true;
                    btn_imprimir.Focus();
                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            BOTON = "MODIFICAR";
            btn_grabar.Visible = false;
            btn_grabar2.Visible = false;
            btn_grabar2.Enabled = true;
            btn_imprimir.Enabled = true;
            TabControl1.SelectedTab = (TabPage2);
            LIMPIAR_CABECERA();
            gb_cab.Enabled = false;
            Panel1.Visible = true;
            Panel2.Visible = false;
            Panel0.Enabled = false;
            CARGAR_DATOS();
            CARGAR_DETALLES_DGW();
            //CargarUbicacion();
            cbo_ni.Visible = false;
            TXT_NI.Visible = true;
            btn_imprimir.Focus();
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (!validaModificarEliminar())
                return;

            string errMensaje = "";
            int idx = dgw1.CurrentRow.Index;
            string str5 = dgw1[0, idx].Value.ToString();
            string str3 = dgw1[2, idx].Value.ToString();
            string str4 = dgw1[5, idx].Value.ToString();
            string str = dgw1[4, idx].Value.ToString();

            DialogResult rs = MessageBox.Show("¿ Esta seguro de eliminar la Nota de Transferencia Nº " + dgw1[4, dgw1.CurrentRow.Index].Value.ToString() + " ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                            eliminaNotaTransferencia(str4, "03", str3, str, str5, ref errMensaje);
                            this.Dispose();
                        }
                        else
                            MessageBox.Show("USTED NO TIENE PERMISOS !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    frm.Dispose();
                }
                else
                {
                    eliminaNotaTransferencia(str4, "03", str3, str, str5, ref errMensaje);
                }
                DATAGRID();
            }
            btn_nuevo.Select();
        }
        private void eliminaNotaTransferencia(string str4, string str2, string str3, string str, string str5, ref string errMensaje)
        {
            invTo.COD_SUCURSAL = str5;
            invTo.COD_CLASE = str3;
            invTo.COD_PER = str4;
            invTo.COD_DOC_INV = str2;
            invTo.NRO_DOC_INV = str;
            invTo.FE_AÑO = AÑO;
            invTo.FE_MES = MES;
            if (!invBLL.ELIMINA_NOTA_TRANSFERENCIA(invTo, ref errMensaje))
            {
                MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("La Nota de Transferencia se eliminó !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btn_anul_Click(object sender, EventArgs e)
        {
            if (!validaModificarEliminar())
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
                            anulaNotaTransferencia(str4, "03", str3, str, str5, str8, frm.txtObservacion.Text, codigo, ref errMensaje);
                            this.Dispose();
                        }
                        else
                            MessageBox.Show("USTED NO TIENE PERMISOS !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    frm.Dispose();
                }
                else
                {
                    anulaNotaTransferencia(str4, "03", str3, str, str5, str8, "", "", ref errMensaje);
                }
                DATAGRID();
            }
            btn_nuevo.Select();
        }
        private void anulaNotaTransferencia(string str4, string str2, string str3, string str, string str5, string str8, string OBS, string codigo, ref string errMensaje)
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
            if (!invBLL.ANULA_NOTA_TRANSFERENCIA(invTo, ref errMensaje))
            {
                MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("La Nota de Transferencia se Anuló !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btn_nuevo2_Click(object sender, EventArgs e)
        {
            btn_grabar.Visible = true;
            btn_grabar2.Visible = false;
            btn_grabar.Enabled = true;
            btn_imprimir.Enabled = false;
            LIMPIAR_CABECERA();
            cbo_ni.Visible = true;
            TXT_NI.Visible = false;
            Panel1.Visible = true;
            Panel2.Visible = false;
            Panel1.Enabled = true;
            if (COD_ELABORADO == "")
                TabControl1.SelectedTab = TabPage1;
            else if (cbo_elab.SelectedIndex == -1)
            {
                cbo_elab.SelectedValue = COD_ELABORADO;
                cbo_elab.Enabled = false;
            }
            cbo_sucursal.Focus();
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
            string str2 = DGW_DET.CurrentRow.Cells[1].Value.ToString();
            DGW_DET.Rows.RemoveAt(DGW_DET.CurrentRow.Index);
            int num2 = DGW_DET.Rows.Count - 1;
            int num3 = 0;
            int num4 = num2;
            while (num3 <= num4)
            {
                if (DGW_DET.Rows[num3].Cells[1].Value.ToString() == str2)
                {
                    DGW_DET.Rows.RemoveAt(DGW_DET.CurrentRow.Index);
                    break;
                }
                num3++;
            }
            REORDENAR_NRO_ITEM();
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

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btn_obs_Click(object sender, EventArgs e)
        {
            obs.ShowDialog();
        }






    }
}
