using BLL;
using Entidades;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Presentacion.MOD_CXC
{
    public partial class PLANILLA_DIRECTA_VARIOS : Form
    {
        string AÑO = "", MES = "", COD_MOD = "", COD_USU = "", TIPO_USU = "";
        DateTime FECHA_INI, FECHA_GRAL;
        string boton; string COD_DOC; string NRO_PLANILLA_COBRANZA;
        DataTable dtTipPlla; DataTable dtDetalle; DataTable dtDevCli;
        Decimal total_enviado = 0, total_recibido, total_deposito = 0, total_gastos_retenidos_x_banco, total_retencion_x_dev_cliente = 0;
        //DateTimePicker dtp = new DateTimePicker();
        //Rectangle _Rectangle;
        tipoDocInvBLL tdiBLL = new tipoDocInvBLL();
        tipoDocInvTo tdiTo = new tipoDocInvTo(); contratoCabeceraBLL ccBLL = new contratoCabeceraBLL();
        contratoCabeceraTo ccTo = new contratoCabeceraTo();
        planillaDirectaVariosBLL pdvBLL = new planillaDirectaVariosBLL();
        planillaDirectaVariosTo pdvTo = new planillaDirectaVariosTo();
        planillaDirectaVariosDetalleBLL pdvdBLL = new planillaDirectaVariosDetalleBLL();
        planillaDirectaVariosDetalleTo pdvdTo = new planillaDirectaVariosDetalleTo();
        canjePCtasxCobrarBLL pctaBLL = new canjePCtasxCobrarBLL();
        canjePCtasxCobrarTo pctaTo = new canjePCtasxCobrarTo();
        public PLANILLA_DIRECTA_VARIOS(string AÑO, string MES, DateTime FECHA_INI, DateTime FECHA_GRAL, string COD_MOD, string TIPO_USU, string COD_USU)
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

        private void PLANILLA_DIRECTA_VARIOS_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            DATAGRID();
            CARGAR_SUCURSAL();
            CARGAR_CANAL_DSCTO();
            CARGAR_PROGRAMAS();
            CARGAR_GESTOR();
            CARGAR_TIPO_PLANILLA();
            CARGA_COMBO_TARJETAS();
            CARGAR_PUNTO_COBRANZA_VISA();
            ////dtp.Visible = false;
            ////dtp.Format = DateTimePickerFormat.Custom;
            ////dtp.Width = 100;
            ////DGW_DET.Controls.Add(dtp);
            ////dtp.ValueChanged += new EventHandler(dtp_ValueChanged);
            ////DGW_DET.CellBeginEdit += this.DGW_DET_CellBeginEdit;
            ////DGW_DET.CellEndEdit += this.DGW_DET_CellEndEdit;
            //dtp_generacion.Value = Convert.ToDateTime(DateTime.Now.Day + "/" + MES + "/" + AÑO);
            DateTime fe_plla = DateTime.Now;
            if (DateTime.TryParse((DateTime.Now.Day + "/" + MES + "/" + AÑO), out fe_plla))
                dtp_generacion.Value = Convert.ToDateTime(DateTime.Now.Day + "/" + MES + "/" + AÑO);
            else
                dtp_generacion.Value = FECHA_GRAL;
        }
        //private void dtp_TextChanged(object sender, EventArgs e)
        //{
        //    DGW_DET.CurrentCell.Value = dtp.Text.ToString();
        //}
        //private void dtp_ValueChanged(object sender, EventArgs e)
        //{
        //    DGW_DET.CurrentCell.Value = dtp.Text;
        //}
        private void CARGAR_SUCURSAL()
        {
            HelpersBLL helBLL = new HelpersBLL();
            HelpersTo helTo = new HelpersTo();
            helTo.CODIGO = COD_USU;
            DataTable dt = helBLL.CBO_SUCURSALBLL(helTo);
            cbo_sucursal.ValueMember = "COD_SUCURSAL";
            cbo_sucursal.DisplayMember = "DESC_sucursal";
            cbo_sucursal.DataSource = dt;
        }
        private void CARGAR_CANAL_DSCTO()
        {
            canalDescuentoBLL cdscBLL = new canalDescuentoBLL();
            DataTable dt = cdscBLL.ObtenerCanalDescuentoBLL();
            cbo_canaldscto.ValueMember = "COD_CANAL_DSCTO";
            cbo_canaldscto.DisplayMember = "DESCRIPCION";
            cbo_canaldscto.DataSource = dt;
            cbo_canaldscto.SelectedIndex = 0;
        }
        private void CARGAR_PROGRAMAS()
        {
            programaBLL prgBLL = new programaBLL();
            DataTable dt = prgBLL.obtenerProgramaBLL();
            cbo_programa.ValueMember = "COD_PROGRAMA";
            cbo_programa.DisplayMember = "DESC_PROGRAMA";
            cbo_programa.DataSource = dt;
            cbo_programa.SelectedIndex = 0;
        }
        private void CARGAR_GESTOR()
        {
            personaBLL perBLL = new personaBLL();
            DataTable dt = perBLL.obtenerGestoresBLL();
            if (dt.Rows.Count > 0)
            {
                cbo_gestor.DataSource = dt;
                cbo_gestor.ValueMember = "COD_PER";
                cbo_gestor.DisplayMember = "DESC_PER";
                cbo_gestor.SelectedIndex = 0;
            }
        }
        private void CARGAR_TIPO_PLANILLA()
        {
            tipoPlanillaCreacionBLL tpcBLL = new tipoPlanillaCreacionBLL();
            dtTipPlla = tpcBLL.obtenerTipoPlanillaCreacionxTransferenciaBLL();
            if (dtTipPlla.Rows.Count > 0)
            {
                cbo_tipo_planilla.ValueMember = "COD_TIPO_PLLA";
                cbo_tipo_planilla.DisplayMember = "DESC_TIPO";
                cbo_sucursal.SelectedIndex = 0;
                cbo_tipo_planilla.DataSource = dtTipPlla;
                cbo_tipo_planilla.SelectedValue = "PV";
                //establecerPlanilla();
            }
        }
        private void CARGA_COMBO_TARJETAS()
        {
            DataGridViewComboBoxColumn comboboxColumn = DGW_DET.Columns["TIPO_TARJETA"] as DataGridViewComboBoxColumn;
            tarjetasBLL tjBLL = new tarjetasBLL();
            tarjetasTo tjTo = new tarjetasTo();
            DataTable dt = tjBLL.obtenerTarjetasBLL();
            comboboxColumn.DataSource = dt;
            comboboxColumn.DisplayMember = "DESC_TARJETA";
            comboboxColumn.ValueMember = "COD_TARJETA";
            // bindeo los datos de los productos a la grilla
            DGW_DET.AutoGenerateColumns = false;
            //DGW_DET.DataSource = ProductosDAL.GetAllProductos();
        }
        private void CARGAR_PUNTO_COBRANZA_VISA()
        {
            puntoCobranzaBLL pcoBLL = new puntoCobranzaBLL();
            puntoCobranzaTo pcoTo = new puntoCobranzaTo();
            DataTable dt = pcoBLL.obtenerPuntosCobranzaVisaBLL();
            if (dt.Rows.Count > 0)
            {
                cboPtoCob.ValueMember = "COD_PTO_COB";
                cboPtoCob.DisplayMember = "DESC_PTO_COB";
                cboPtoCob.DataSource = dt;
                cboPtoCob.SelectedIndex = 0;
            }
        }
        private void DATAGRID()
        {
            pdvTo.FE_AÑO = AÑO;
            pdvTo.FE_MES = MES;
            DataTable dt = pdvBLL.obtener_I_Planilla_Directa_Varios_BLL(pdvTo);
            lbl_reg.Text = "Nro de Registros : 0";
            if (dt.Rows.Count > 0)
            {
                lbl_reg.Text = "Nro de Registros : " + dt.Rows.Count.ToString();
                dgv_generados.Rows.Clear();
                foreach (DataRow rw in dt.Rows)
                {
                    int rowId = dgv_generados.Rows.Add();
                    DataGridViewRow row = dgv_generados.Rows[rowId];
                    row.Cells["NRO_PLANILLA_COB"].Value = rw["NRO_PLANILLA_COB"].ToString();
                    row.Cells["TIPO_PLANILLA"].Value = rw["TIPO_PLANILLA"].ToString();
                    row.Cells["FE_AÑO"].Value = rw["FE_AÑO"].ToString();
                    row.Cells["FE_MES"].Value = rw["FE_MES"].ToString();
                    row.Cells["COD_SUCURSAL"].Value = rw["COD_SUCURSAL"].ToString();
                    row.Cells["CANAL_DSCTO"].Value = rw["CANAL_DSCTO"].ToString();
                    row.Cells["COD_GESTOR"].Value = rw["COD_GESTOR"].ToString();
                    row.Cells["PROGRAMA"].Value = rw["PROGRAMA"].ToString();
                    row.Cells["DESC_PROGRAMA"].Value = rw["DESC_PROGRAMA"].ToString();
                    row.Cells["FECHA_PLANILLA_COB"].Value = Convert.ToDateTime(rw["FECHA_PLANILLA_COB"]);
                    row.Cells["NUM_MOVIMIENTO"].Value = rw["NUM_MOVIMIENTO"].ToString();
                    row.Cells["TOTAL_ENVIADO2"].Value = rw["TOTAL_ENVIADO"].ToString();
                    row.Cells["TOTAL_RECIBIDO2"].Value = rw["TOTAL_RECIBIDO"].ToString();
                    row.Cells["TOTAL_GASTOS_RETENIDOS_X_BANCO2"].Value = rw["TOTAL_GASTOS_RETENIDOS_X_BANCO"].ToString();
                    row.Cells["TOTAL_RETENCION_X_DEV_CLIENTE2"].Value = rw["TOTAL_RETENCION_X_DEV_CLIENTE"].ToString();
                    row.Cells["TOTAL_DEPOSITO2"].Value = rw["TOTAL_DEPOSITO"].ToString();
                    row.Cells["OBSERVACIONES2"].Value = rw["OBSERVACIONES"].ToString();
                    row.Cells["STATUS_APROBADO2"].Value = rw["STATUS_APROBADO"].ToString() == "1" ? true : false;
                    row.Cells["COD_PTO_COB"].Value = Convert.ToString(rw["COD_PTO_COB"]);
                }
            }
        }
        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            boton = "NUEVO";
            BTN_GRABAR.Visible = true;
            btn_grabar2.Visible = false;

            TabControl1.SelectedTab = (TabPage2);
            LIMPIAR();
            cbo_sucursal.SelectedIndex = 0;
            cbo_tipo_planilla.SelectedValue = "PV";
            establecerPlanilla();
            DGW_DET.Rows.Clear();
            cbo_tipo_planilla.Enabled = true;
            Panel1.Visible = true;
            BTN_GRABAR.Enabled = true;
            gb_oc.Enabled = true;
            btn_grabar2.Enabled = true;
            nuevaFila();
        }
        private void LIMPIAR()
        {
            cbo_sucursal.SelectedIndex = -1;
            cbo_canaldscto.SelectedIndex = 0;
            cbo_tipo_planilla.SelectedIndex = -1; ;
            cbo_programa.SelectedIndex = 0;
            cbo_gestor.SelectedIndex = 0;
            txt_nro_movimiento.Clear();
            txt_obs.Clear();
            DGW_DET.Rows.Clear();
            txt_gastos.Text = "0.00";
            txt_retencion.Text = "0.00";
            txt_tot_enviado.Text = "0.00";
            txt_tot_recibido.Text = "0.00";
            txt_tot_deposito.Text = "0.00";
            lbl_reg.Text = "Cantidad de Registros : 0";
        }

        private void cbo_tipo_planilla_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void cbo_tipo_planilla_SelectionChangeCommitted(object sender, EventArgs e)
        {
            establecerPlanilla();
        }
        private void establecerPlanilla()
        {
            if (cbo_tipo_planilla.SelectedValue != null)
            {
                if (cbo_sucursal.SelectedValue != null)
                {
                    obtieneNroPlla();
                    lbl_cod_tipo_plla.Text = cbo_tipo_planilla.SelectedValue.ToString();
                }
            }
        }
        private void obtieneNroPlla()
        {
            //if (BTN_GRABAR.Visible)
            //{
            tdiTo.TIPO_DOC = cbo_tipo_planilla.SelectedValue.ToString();
            COD_DOC = tdiBLL.obtieneCodDocInvxTipoDocBLL(tdiTo);
            DataTable dt = HelpersBLL.obtieneNroPlanilla(cbo_sucursal.SelectedValue.ToString(), "0", COD_DOC);
            txt_ser.Text = dt.Rows[0]["SERIE"].ToString();
            txt_num.Text = dt.Rows[0]["NUMERO"].ToString();
        }
        private void nuevaFila()
        {
            int rowId = DGW_DET.Rows.Add();
            DataGridViewRow row = DGW_DET.Rows[rowId];
            row.Cells["NRO_CONTRATO"].Value = "";
            row.Cells["NRO_CONTRATO"].ReadOnly = false;
            row.Cells["COD_PER"].Value = "";
            row.Cells["COD_PER"].ReadOnly = true;
            row.Cells["DNI"].Value = "";
            row.Cells["DNI"].ReadOnly = true;
            row.Cells["DESC_PER"].Value = "";
            row.Cells["DESC_PER"].ReadOnly = true;
            row.Cells["COD_INSTITUCION"].Value = "";
            row.Cells["COD_INSTITUCION"].ReadOnly = true;
            row.Cells["DESC_INST"].Value = "";
            row.Cells["DESC_INST"].ReadOnly = true;
            row.Cells["TIPO_TARJETA"].Value = "01";
            row.Cells["TIPO_TARJETA"].ReadOnly = false;
            row.Cells["FE_1ER_PROCESO"].Value = dtp_generacion.Value.ToShortDateString();
            row.Cells["FE_1ER_PROCESO"].ReadOnly = false;
            row.Cells["NRO_CUOTAS"].Value = "";
            row.Cells["NRO_CUOTAS"].ReadOnly = true;
            row.Cells["MONTO_CUOTA"].Value = "0.00";
            row.Cells["MONTO_CUOTA"].ReadOnly = false;
            row.Cells["DSCTO_TARJETA"].Value = "0.00";
            row.Cells["DSCTO_TARJETA"].ReadOnly = false;
            row.Cells["PAGO_VISA"].Value = "0.00";
            row.Cells["PAGO_VISA"].ReadOnly = false;

            DGW_DET.Rows[rowId].Cells["NRO_CONTRATO"].Selected = true;
            DGW_DET.BeginEdit(true);
        }

        private void DGW_DET_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (DGW_DET.Focused)
            {
                if (e.ColumnIndex == 0)
                {
                    ccTo.NRO_PRESUPUESTO = DGW_DET.CurrentRow.Cells["NRO_CONTRATO"].Value.ToString();
                    DataTable dt = ccBLL.obtener_Personas_para_Plla_Directa_VariosBLL(ccTo);
                    if (dt.Rows.Count > 0)
                    {
                        DGW_DET.CurrentRow.Cells["COD_PER"].Value = dt.Rows[0]["COD_PER"].ToString();
                        DGW_DET.CurrentRow.Cells["DNI"].Value = dt.Rows[0]["DNI"].ToString();
                        DGW_DET.CurrentRow.Cells["DESC_PER"].Value = dt.Rows[0]["DESC_PER"].ToString();
                        DGW_DET.CurrentRow.Cells["COD_INSTITUCION"].Value = dt.Rows[0]["COD_INSTITUCION"].ToString();
                        DGW_DET.CurrentRow.Cells["DESC_INST"].Value = dt.Rows[0]["DESC_INST"].ToString();
                        DGW_DET.CurrentRow.Cells["NRO_CUOTAS"].Value = dt.Rows[0]["NRO_CUOTAS"].ToString();
                        DGW_DET.CurrentRow.Cells["MONTO_CUOTA"].Value = dt.Rows[0]["MONTO_CUOTA"].ToString();
                        DGW_DET.CurrentRow.Cells["TIPO_TARJETA"].Selected = true;
                        DGW_DET.BeginEdit(true);
                    }
                    else
                    {
                        MessageBox.Show("Este contrato " + Convert.ToString(DGW_DET.CurrentRow.Cells["NRO_CONTRATO"].Value) +
                            " no existe o el tipo venta ingresado no es Visa !!!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        DGW_DET.CurrentRow.Cells["NRO_CONTRATO"].Value = "";
                        //DGW_DET.CurrentRow.Cells["NRO_CONTRATO"].Selected = true;
                        //DGW_DET.BeginEdit(true);
                    }
                }
                this.BeginInvoke(new MethodInvoker(() =>
               {
                   //if (DGW_DET.Focused)
                   //{
                   //    if (e.ColumnIndex == 0)
                   //    {
                   //        ccTo.NRO_PRESUPUESTO = DGW_DET.CurrentRow.Cells["NRO_CONTRATO"].Value.ToString();
                   //        DataTable dt = ccBLL.obtener_Personas_para_Plla_Directa_VariosBLL(ccTo);
                   //        if (dt.Rows.Count > 0)
                   //        {
                   //            DGW_DET.CurrentRow.Cells["COD_PER"].Value = dt.Rows[0]["COD_PER"].ToString();
                   //            DGW_DET.CurrentRow.Cells["DNI"].Value = dt.Rows[0]["DNI"].ToString();
                   //            DGW_DET.CurrentRow.Cells["DESC_PER"].Value = dt.Rows[0]["DESC_PER"].ToString();
                   //            DGW_DET.CurrentRow.Cells["COD_INSTITUCION"].Value = dt.Rows[0]["COD_INSTITUCION"].ToString();
                   //            DGW_DET.CurrentRow.Cells["DESC_INST"].Value = dt.Rows[0]["DESC_INST"].ToString();
                   //            DGW_DET.CurrentRow.Cells["NRO_CUOTAS"].Value = dt.Rows[0]["NRO_CUOTAS"].ToString();
                   //            DGW_DET.CurrentRow.Cells["MONTO_CUOTA"].Value = dt.Rows[0]["MONTO_CUOTA"].ToString();
                   //            DGW_DET.CurrentRow.Cells["TIPO_TARJETA"].Selected = true;
                   //            DGW_DET.BeginEdit(true);
                   //        }
                   //    }
                   if (DGW_DET.Focused)
                   {
                       if (e.ColumnIndex == 6)
                       {
                           DGW_DET.CurrentRow.Cells["FE_1ER_PROCESO"].Selected = true;
                           DGW_DET.BeginEdit(true);
                       }
                       else if (e.ColumnIndex == 7)
                       {
                           //try
                           //{
                           //    DGW_DET.CurrentCell.Value = dtp.Value.Date;

                           //    //DGW_DET.CurrentRow.Cells["MONTO_CUOTA"].Selected = true;
                           //    //DGW_DET.BeginEdit(true);
                           //}
                           //catch (Exception)
                           //{

                           //    throw;
                           //}
                           DGW_DET.CurrentRow.Cells["MONTO_CUOTA"].Selected = true;
                           DGW_DET.BeginEdit(true);

                       }
                       else if (e.ColumnIndex == 9)
                       {
                           DGW_DET.CurrentRow.Cells["DSCTO_TARJETA"].Selected = true;
                           DGW_DET.BeginEdit(true);
                       }
                       else if (e.ColumnIndex == 10)
                       {
                           DGW_DET.CurrentRow.Cells["PAGO_VISA"].Selected = true;
                           DGW_DET.BeginEdit(true);
                       }
                       else if (e.ColumnIndex == 11)
                       {
                           DialogResult rs = MessageBox.Show("¿ Desea agregar un nuevo Cliente ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                           if (rs == DialogResult.Yes)
                           {
                               totales();//sumariza todo
                               nuevaFila();
                           }
                           else
                               totales();//sumariza todo
                       }
                   }
               }));
            }
        }
        private void totales()
        {
            total_enviado = DGW_DET.Rows.Cast<DataGridViewRow>().Sum(x => Convert.ToDecimal(x.Cells["MONTO_CUOTA"].Value));
            txt_tot_enviado.Text = total_enviado.ToString();
            total_recibido = DGW_DET.Rows.Cast<DataGridViewRow>().Sum(x => Convert.ToDecimal(x.Cells["PAGO_VISA"].Value));
            txt_tot_recibido.Text = total_recibido.ToString();
            total_gastos_retenidos_x_banco = Convert.ToDecimal(txt_gastos.Text);
            total_retencion_x_dev_cliente = Convert.ToDecimal(txt_retencion.Text);
            total_deposito = total_recibido - total_gastos_retenidos_x_banco - total_retencion_x_dev_cliente;
            txt_tot_deposito.Text = Convert.ToString(total_deposito);
            lbl_reg.Text = "Cantidad de Registros : " + DGW_DET.Rows.Count.ToString();
        }

        private void txt_gastos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                gastos();
        }
        private void gastos()
        {
            total_gastos_retenidos_x_banco = Convert.ToDecimal(txt_gastos.Text);
            total_retencion_x_dev_cliente = Convert.ToDecimal(txt_retencion.Text);
            total_deposito = total_recibido - total_gastos_retenidos_x_banco - total_retencion_x_dev_cliente;
            txt_tot_deposito.Text = Convert.ToString(total_deposito);
        }
        private void txt_gastos_Leave(object sender, EventArgs e)
        {
            gastos();
        }

        private void btn_retencion_Click(object sender, EventArgs e)
        {
            MOD_CXC.Ingreso_Retencion_Devolucion_Cliente frm = new Ingreso_Retencion_Devolucion_Cliente(dtDevCli);
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                dtDevCli = HelpersBLL.obtenerDT(frm.dgw_dev_cliente);
                txt_retencion.Text = frm.txt_total.Text;
                gastos();
            }
        }

        private void btn_adicionar_fila_Click(object sender, EventArgs e)
        {
            nuevaFila();
        }

        private void btn_eliminar_fila_Click(object sender, EventArgs e)
        {
            if (DGW_DET.Rows.Count > 0)
            {
                DialogResult rs = MessageBox.Show("¿ Esta seguro de eliminar éste registro ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    DGW_DET.Rows.RemoveAt(DGW_DET.CurrentRow.Index);
                    totales();
                }
            }
        }

        private void BTN_GRABAR_Click(object sender, EventArgs e)
        {
            if (!validaGrabar())
                return;

            DialogResult rs = MessageBox.Show("¿ Esta seguro de grabar la Planilla ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                pdvTo.NRO_PLANILLA_COB = txt_ser.Text + "-" + txt_num.Text;
                pdvTo.TIPO_PLANILLA = cbo_tipo_planilla.SelectedValue.ToString();
                pdvTo.FE_AÑO = AÑO;
                pdvTo.FE_MES = MES;
                pdvTo.COD_SUCURSAL = cbo_sucursal.SelectedValue.ToString();
                pdvTo.CANAL_DSCTO = cbo_canaldscto.SelectedValue.ToString();
                pdvTo.COD_GESTOR = cbo_gestor.SelectedValue.ToString();
                pdvTo.PROGRAMA = cbo_programa.SelectedValue.ToString();
                pdvTo.FECHA_PLANILLA_COB = dtp_generacion.Value;
                pdvTo.NUM_MOVIMIENTO = txt_nro_movimiento.Text;
                pdvTo.TOTAL_ENVIADO = total_enviado;
                pdvTo.TOTAL_RECIBIDO = total_recibido;
                pdvTo.TOTAL_GASTOS_RETENIDOS_X_BANCO = total_gastos_retenidos_x_banco;
                pdvTo.TOTAL_RETENCION_X_DEV_CLIENTE = total_retencion_x_dev_cliente;
                pdvTo.TOTAL_DEPOSITO = total_deposito;
                pdvTo.OBSERVACIONES = txt_obs.Text;
                pdvTo.STATUS_APROBADO = "0";
                pdvTo.COD_CREACION = COD_USU;
                pdvTo.FECHA_CREACION = DateTime.Now;
                pdvTo.SERIE = txt_ser.Text.Trim();
                pdvTo.COD_DOC = COD_DOC;
                pdvTo.STATUS_DOC = "0";
                pdvTo.COD_PTO_COB = Convert.ToString(cboPtoCob.SelectedValue);
                dtDetalle = HelpersBLL.obtenerDT(DGW_DET);
                if (!pdvBLL.adicionaNuevaPlanillaBLL(pdvTo, dtDetalle, dtDevCli, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("El ingreso se hizo correctamente", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TabControl1.SelectedTab = TabPage1;
                    DATAGRID();
                    FOCO_NUEVO_REG("grabar");
                }
            }
        }
        private void btn_grabar2_Click(object sender, EventArgs e)
        {
            if (!validaGrabar())
                return;

            DialogResult rs = MessageBox.Show("¿ Esta seguro de modificar la Planilla ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                pdvTo.NRO_PLANILLA_COB = txt_ser.Text + "-" + txt_num.Text;
                pdvTo.TIPO_PLANILLA = cbo_tipo_planilla.SelectedValue.ToString();
                pdvTo.FE_AÑO = AÑO;
                pdvTo.FE_MES = MES;
                pdvTo.COD_SUCURSAL = cbo_sucursal.SelectedValue.ToString();
                pdvTo.CANAL_DSCTO = cbo_canaldscto.SelectedValue.ToString();
                pdvTo.COD_GESTOR = cbo_gestor.SelectedValue.ToString();
                pdvTo.PROGRAMA = cbo_programa.SelectedValue.ToString();
                pdvTo.FECHA_PLANILLA_COB = dtp_generacion.Value;
                pdvTo.NUM_MOVIMIENTO = txt_nro_movimiento.Text;
                pdvTo.TOTAL_ENVIADO = total_enviado;
                pdvTo.TOTAL_RECIBIDO = total_recibido;
                pdvTo.TOTAL_GASTOS_RETENIDOS_X_BANCO = total_gastos_retenidos_x_banco;
                pdvTo.TOTAL_RETENCION_X_DEV_CLIENTE = total_retencion_x_dev_cliente;
                pdvTo.TOTAL_DEPOSITO = total_deposito;
                pdvTo.OBSERVACIONES = txt_obs.Text;
                //pdvTo.STATUS_APROBADO = "0";
                pdvTo.COD_CREACION = COD_USU;
                pdvTo.FECHA_CREACION = DateTime.Now;
                pdvTo.COD_MODIFICACION = pdvTo.COD_CREACION;
                pdvTo.FECHA_MODIFICACION = pdvTo.FECHA_CREACION;
                pdvTo.COD_PTO_COB = Convert.ToString(cboPtoCob.SelectedValue);
                //pdvTo.SERIE = txt_ser.Text.Trim();
                //pdvTo.COD_DOC = COD_DOC;
                //pdvTo.STATUS_DOC = "0";
                dtDetalle = HelpersBLL.obtenerDT(DGW_DET);
                if (!pdvBLL.modificaNuevaPlanillaBLL(pdvTo, dtDetalle, dtDevCli, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("La modificación se hizo correctamente", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TabControl1.SelectedTab = TabPage1;
                    DATAGRID();
                    FOCO_NUEVO_REG("modificar");
                }
            }
        }
        private void FOCO_NUEVO_REG(string op)
        {
            int i, cont = 0; string nrocon = "";
            cont = dgv_generados.Rows.Count - 1;
            if (op == "grabar" || op == "modificar")
                nrocon = txt_ser.Text + "-" + txt_num.Text.Trim() + lbl_cod_tipo_plla.Text;
            else if (op == "aprobar")
                nrocon = NRO_PLANILLA_COBRANZA + dgv_generados.CurrentRow.Cells["TIPO_PLANILLA"].Value.ToString();

            for (i = 0; i <= cont; i++)
            {
                if (nrocon == dgv_generados.Rows[i].Cells["NRO_PLANILLA_COB"].Value.ToString().ToLower() + dgv_generados.Rows[i].Cells["TIPO_PLANILLA"].Value.ToString())
                {
                    dgv_generados.CurrentCell = dgv_generados.Rows[i].Cells["NRO_PLANILLA_COB"];
                    return;
                }
            }
        }
        private bool validaGrabar()
        {
            bool result = true;
            for (int i = 0; i < DGW_DET.Rows.Count; i++)
            {
                if (Convert.ToString(DGW_DET.Rows[i].Cells["NRO_CONTRATO"].Value) == "")
                {
                    MessageBox.Show("El registro está vacio !!!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    DGW_DET.Rows[i].Cells["NRO_CONTRATO"].Selected = true;
                    DGW_DET.BeginEdit(true);
                    return result = false;
                }
            }
            return result;
        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            if (!validaModificar())
                return;
            BTN_GRABAR.Visible = false;
            btn_grabar2.Visible = true;
            //txt_ser.Visible = true;
            TabControl1.SelectedTab = (TabPage2);
            LIMPIAR();
            BTN_GRABAR.Enabled = false;
            btn_grabar2.Enabled = true;
            txt_ser.ReadOnly = true;
            txt_num.ReadOnly = true;
            cbo_tipo_planilla.Enabled = false;
            CARGAR_CABECERA_DOCUMENTO();
            CARGAR_DETALLE_DOCUMENTO();
            CARGAR_DETALLE_DEVOLUCION();
            totales();
        }
        private void CARGAR_CABECERA_DOCUMENTO()
        {
            cbo_sucursal.SelectedValue = dgv_generados.CurrentRow.Cells["COD_SUCURSAL"].Value;
            lbl_cod_tipo_plla.Text = Convert.ToString(dgv_generados.CurrentRow.Cells["TIPO_PLANILLA"].Value);
            txt_ser.Text = Convert.ToString(dgv_generados.CurrentRow.Cells["NRO_PLANILLA_COB"].Value).Substring(0, 3);
            txt_num.Text = Convert.ToString(dgv_generados.CurrentRow.Cells["NRO_PLANILLA_COB"].Value).Substring(4, 7);
            dtp_generacion.Value = Convert.ToDateTime(dgv_generados.CurrentRow.Cells["FECHA_PLANILLA_COB"].Value);
            cbo_canaldscto.SelectedValue = dgv_generados.CurrentRow.Cells["CANAL_DSCTO"].Value;
            cbo_tipo_planilla.SelectedValue = dgv_generados.CurrentRow.Cells["TIPO_PLANILLA"].Value;
            cbo_programa.SelectedValue = dgv_generados.CurrentRow.Cells["PROGRAMA"].Value;
            cbo_gestor.SelectedValue = dgv_generados.CurrentRow.Cells["COD_GESTOR"].Value;
            txt_nro_movimiento.Text = Convert.ToString(dgv_generados.CurrentRow.Cells["NUM_MOVIMIENTO"].Value);
            txt_obs.Text = Convert.ToString(dgv_generados.CurrentRow.Cells["OBSERVACIONES2"].Value);
            txt_tot_enviado.Text = Convert.ToDecimal(dgv_generados.CurrentRow.Cells["TOTAL_ENVIADO2"].Value).ToString("###,###,##0.00");
            txt_tot_recibido.Text = Convert.ToDecimal(dgv_generados.CurrentRow.Cells["TOTAL_RECIBIDO2"].Value).ToString("###,###,##0.00");
            txt_gastos.Text = Convert.ToDecimal(dgv_generados.CurrentRow.Cells["TOTAL_GASTOS_RETENIDOS_X_BANCO2"].Value).ToString("###,###,##0.00");
            txt_retencion.Text = Convert.ToDecimal(dgv_generados.CurrentRow.Cells["TOTAL_RETENCION_X_DEV_CLIENTE2"].Value).ToString("###,###,##0.00");
            txt_tot_deposito.Text = Convert.ToDecimal(dgv_generados.CurrentRow.Cells["TOTAL_DEPOSITO2"].Value).ToString("###,###,##0.00");
            cboPtoCob.SelectedValue = Convert.ToString(dgv_generados.CurrentRow.Cells["COD_PTO_COB"].Value);
            total_enviado = Convert.ToDecimal(txt_tot_enviado.Text);
            total_recibido = Convert.ToDecimal(txt_tot_recibido.Text);
        }
        private void CARGAR_DETALLE_DOCUMENTO()
        {

            pdvdTo.NRO_PLANILLA_COB = Convert.ToString(dgv_generados.CurrentRow.Cells["NRO_PLANILLA_COB"].Value);
            pdvdTo.TIPO_PLANILLA = Convert.ToString(dgv_generados.CurrentRow.Cells["TIPO_PLANILLA"].Value);
            //pdvdTo.FE_AÑO = Convert.ToString(dgv_generados.CurrentRow.Cells["FE_AÑO"].Value);
            //pdvdTo.FE_MES = Convert.ToString(dgv_generados.CurrentRow.Cells["FE_MES"].Value);
            DataTable dt = pdvdBLL.obtener_T_Planilla_Directa_Varios_Detalle_BLL(pdvdTo);
            if (dt.Rows.Count > 0)
            {
                lbl_reg.Text = "Nro de Registros : " + dt.Rows.Count.ToString();
                foreach (DataRow rw in dt.Rows)
                {
                    int rowId = DGW_DET.Rows.Add();
                    DataGridViewRow row = DGW_DET.Rows[rowId];
                    row.Cells["NRO_CONTRATO"].Value = rw["NRO_CONTRATO"].ToString();
                    row.Cells["COD_PER"].Value = rw["COD_PER"].ToString();
                    row.Cells["DNI"].Value = rw["DNI"].ToString();
                    row.Cells["DESC_PER"].Value = rw["DESC_PER"].ToString();
                    row.Cells["COD_INSTITUCION"].Value = rw["COD_INSTITUCION"].ToString();
                    row.Cells["DESC_INST"].Value = rw["DESC_INST"].ToString();
                    row.Cells["TIPO_TARJETA"].Value = rw["TIPO_TARJETA"].ToString();
                    row.Cells["FE_1ER_PROCESO"].Value = Convert.ToDateTime(rw["FE_1ER_PROCESO"]).ToShortDateString();
                    row.Cells["NRO_CUOTAS"].Value = rw["NRO_CUOTAS"].ToString();
                    row.Cells["MONTO_CUOTA"].Value = rw["MONTO_CUOTA"].ToString();
                    row.Cells["DSCTO_TARJETA"].Value = rw["DSCTO_TARJETA"].ToString();
                    row.Cells["PAGO_VISA"].Value = rw["PAGO_VISA"].ToString();
                }

            }

        }
        private void CARGAR_DETALLE_DEVOLUCION()
        {
            pdvdTo.NRO_PLANILLA_COB = Convert.ToString(dgv_generados.CurrentRow.Cells["NRO_PLANILLA_COB"].Value);
            pdvdTo.TIPO_PLANILLA = Convert.ToString(dgv_generados.CurrentRow.Cells["TIPO_PLANILLA"].Value);
            //pdvdTo.FE_AÑO = Convert.ToString(dgv_generados.CurrentRow.Cells["FE_AÑO"].Value);
            //pdvdTo.FE_MES = Convert.ToString(dgv_generados.CurrentRow.Cells["FE_MES"].Value);
            dtDevCli = null;
            DataTable dt = pdvdBLL.obtener_T_Dev_Planilla_Directa_Varios_Detalle_BLL(pdvdTo);
            if (dt.Rows.Count > 0)
            {
                dtDevCli = dt;
            }
        }
        private bool validaModificar()
        {
            bool result = true;
            if (Convert.ToBoolean(dgv_generados.CurrentRow.Cells["STATUS_APROBADO2"].Value))
            {
                MessageBox.Show("No se puede modificar porque ya está Aprobado !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return result = false;
            }

            return result;
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            TabControl1.SelectedTab = (TabPage1);
        }

        private void btn_consulta_Click(object sender, EventArgs e)
        {
            BTN_GRABAR.Visible = false;
            btn_grabar2.Visible = false;
            //txt_ser.Visible = true;
            TabControl1.SelectedTab = (TabPage2);
            LIMPIAR();
            cbo_tipo_planilla.Enabled = false;
            CARGAR_CABECERA_DOCUMENTO();
            CARGAR_DETALLE_DOCUMENTO();
            CARGAR_DETALLE_DEVOLUCION();
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private bool validaAprobar()
        {
            bool result = true;
            if (Convert.ToBoolean(dgv_generados.CurrentRow.Cells["STATUS_APROBADO2"].Value))
            {
                MessageBox.Show("Este contrato ya está aprobado !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return result = false;
            }
            return result;
        }
        private void btnAprobar_Click(object sender, EventArgs e)
        {
            if (!validaAprobar())
                return;

            //MessageBox.Show("TODAVIA EN CONSTRUCCION !!!", "MENSAJE");

            DialogResult rs = MessageBox.Show("¿ Esta seguro aprobar o cerrar la Planilla ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                //planillaCabeceraBLL plcBLL = new planillaCabeceraBLL();
                planillaCabeceraTo pllcTo = new planillaCabeceraTo();
                string errMensaje = "";
                pllcTo.NRO_PLANILLA_COB = dgv_generados.CurrentRow.Cells["NRO_PLANILLA_COB"].Value.ToString();
                //plcTo.SERIE = dgv_generados.CurrentRow.Cells["NRO_PLANILLA_DOC2"].Value.ToString().Substring(0, 3);
                pllcTo.COD_INSTITUCION = "";//dgv_generados.CurrentRow.Cells["COD_INSTITUCION"].Value.ToString();
                pllcTo.COD_PTO_COB_CONSOLIDADO = Convert.ToString(dgv_generados.CurrentRow.Cells["COD_PTO_COB"].Value);//dgv_generados.CurrentRow.Cells["COD_PTO_COB2"].Value.ToString();
                pllcTo.COD_CANAL_DSCTO = dgv_generados.CurrentRow.Cells["CANAL_DSCTO"].Value.ToString();
                pllcTo.FE_AÑO = dgv_generados.CurrentRow.Cells["FE_AÑO"].Value.ToString();
                pllcTo.FE_MES = dgv_generados.CurrentRow.Cells["FE_MES"].Value.ToString();
                pllcTo.COD_MOD = COD_USU;
                pllcTo.FECHA_MOD = DateTime.Now;
                pllcTo.COD_SUCURSAL = dgv_generados.CurrentRow.Cells["COD_SUCURSAL"].Value.ToString();
                pllcTo.COD_CLASE = "01";
                pllcTo.COD_SECTORISTA = "";
                pllcTo.FECHA_PLANILLA_COB = Convert.ToDateTime(dgv_generados.CurrentRow.Cells["FECHA_PLANILLA_COB"].Value);
                pllcTo.FECHA_RECEPCION = pllcTo.FECHA_PLANILLA_COB;
                pllcTo.OBSERVACION = dgv_generados.CurrentRow.Cells["OBSERVACIONES2"].Value.ToString();
                pllcTo.TIPO_PLANILLA = Convert.ToString(dgv_generados.CurrentRow.Cells["TIPO_PLANILLA"].Value);
                planillaDetalleOtrasDevDsctosBLL pldBLL = new planillaDetalleOtrasDevDsctosBLL();
                planillaDetalleOtrasDevDsctosTo pldTo = new planillaDetalleOtrasDevDsctosTo();
                pdvTo.NRO_PLANILLA_COB = pllcTo.NRO_PLANILLA_COB;
                pdvTo.TIPO_PLANILLA = pllcTo.TIPO_PLANILLA;
                pdvTo.FE_AÑO = pllcTo.FE_AÑO;
                pdvTo.FE_MES = pllcTo.FE_MES;
                DataTable dtDet = pdvBLL.obtenerPlanillaDetalleDirectoVariosBLL(pdvTo);
                DataTable dtDetalle = distribuirImporte(dtDet, pllcTo);
                //
                pdvTo.NRO_PLANILLA_COB = pllcTo.NRO_PLANILLA_COB;
                pdvTo.COD_INSTITUCION = pllcTo.COD_INSTITUCION; //esta vacio
                pdvTo.CANAL_DSCTO = pllcTo.COD_CANAL_DSCTO;
                pdvTo.FE_AÑO = pllcTo.FE_AÑO;
                pdvTo.FE_MES = pllcTo.FE_MES;
                pdvTo.TIPO_PLANILLA = pllcTo.TIPO_PLANILLA;
                NRO_PLANILLA_COBRANZA = pllcTo.NRO_PLANILLA_COB;

                if (!pdvBLL.aprobarPlanillasDirectaVariosBLL(pllcTo, pdvTo, dtDetalle, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Se aprobó o cerró correctamente", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TabControl1.SelectedTab = TabPage1;
                    DATAGRID();
                    //CARGAR_PERSONAS();//para actualizar el grid desplegable
                    FOCO_NUEVO_REG("aprobar");
                }
            }
        }
        private DataTable distribuirImporte(DataTable dtBasico, planillaCabeceraTo pllcTo)
        {
            DataTable dtCuotas;
            decimal monto_a_pagar;
            string cod_sucursal = pllcTo.COD_SUCURSAL;
            string cod_clase = pllcTo.COD_CLASE;
            string nro_contrato;
            DataTable dtDetail = dtBasico.Clone();
            dtDetail.Columns.Add("NRO_DOC");
            dtDetail.Columns.Add("IMP_COB", typeof(decimal));
            dtDetail.Columns.Add("IMP_COB_CTA_CTE", typeof(decimal));
            dtDetail.Columns.Add("IMP_DEV", typeof(decimal));
            dtDetail.Columns.Add("NRO_LETRA");
            dtDetail.Columns.Add("FECHA_VEN");
            foreach (DataRow rw in dtBasico.Rows)
            {
                nro_contrato = rw["NRO_CONTRATO"].ToString();
                dtCuotas = obtieneCuotasNoCanceladasBLL(cod_sucursal, cod_clase, nro_contrato);
                monto_a_pagar = Convert.ToDecimal(rw["IMP_DOC"]);
                if (dtCuotas.Rows.Count > 0)
                {
                    foreach (DataRow row in dtCuotas.Rows)
                    {
                        if (monto_a_pagar > 0)
                        {
                            DataRow fila = dtDetail.NewRow();
                            fila["NRO_PLANILLA_COB"] = rw["NRO_PLANILLA_COB"];
                            fila["COD_INSTITUCION"] = rw["COD_INSTITUCION"];
                            fila["COD_PTO_COB_CONSOLIDADO"] = rw["COD_PTO_COB_CONSOLIDADO"];
                            fila["CANAL_DSCTO"] = rw["CANAL_DSCTO"];
                            fila["FE_AÑO"] = rw["FE_AÑO"];
                            fila["FE_MES"] = rw["FE_MES"];
                            fila["NRO_CONTRATO"] = rw["NRO_CONTRATO"];
                            fila["COD_DOC"] = rw["COD_DOC"];
                            fila["NRO_DOC"] = row["NRO_DOC"];
                            fila["IMP_DOC"] = row["IMP_DOC"];
                            if (monto_a_pagar >= Convert.ToDecimal(row["IMP_DOC"]))
                                fila["IMP_COB"] = row["IMP_DOC"];
                            else
                                fila["IMP_COB"] = monto_a_pagar;
                            monto_a_pagar -= Convert.ToDecimal(row["IMP_DOC"]);
                            fila["IMP_COB_CTA_CTE"] = "0";
                            fila["IMP_DEV"] = "0";
                            fila["NRO_LETRA"] = row["NRO_LETRA"];
                            fila["TOT_LETRA"] = rw["TOT_LETRA"];
                            fila["COD_PTO_COB"] = rw["COD_PTO_COB"];
                            fila["FECHA_RECEPCION"] = rw["FECHA_RECEPCION"];
                            fila["COD_COBRADOR"] = rw["COD_COBRADOR"];
                            fila["FECHA_PLANILLA_COB"] = rw["FECHA_PLANILLA_COB"];
                            fila["OBSERVACION"] = rw["OBSERVACION"];
                            fila["FECHA_VEN"] = row["FECHA_VEN"];
                            fila["FECHA_CONTRATO"] = rw["FECHA_CONTRATO"];
                            fila["TIPO_CAMBIO"] = rw["TIPO_CAMBIO"];
                            fila["AÑO"] = rw["AÑO"];
                            fila["MES"] = rw["MES"];
                            fila["COD_MOTIVO_NO_DESCONTADO"] = rw["COD_MOTIVO_NO_DESCONTADO"];
                            fila["TOTAL_DEPOSITO"] = rw["TOTAL_DEPOSITO"];

                            dtDetail.Rows.Add(fila);
                        }
                        else
                            break;
                    }
                }
            }

            return dtDetail;
        }
        private DataTable obtieneCuotasNoCanceladasBLL(string cod_sucursal, string cod_clase, string nro_contrato)
        {
            DataTable dt;
            canjePCtasxCobrarBLL pccBLL = new canjePCtasxCobrarBLL();
            canjePCtasxCobrarTo pccTo = new canjePCtasxCobrarTo();
            pccTo.COD_SUCURSAL = cod_sucursal;
            pccTo.COD_CLASE = cod_clase;
            pccTo.NRO_CONTRATO = nro_contrato;
            dt = pccBLL.obtenerCuotasPendientesxContratoBLL(pccTo);
            return dt;
        }

        private void DGW_DET_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //switch (DGW_DET.Columns[e.ColumnIndex].Name)
            //{
            //    case "FE_1ER_PROCESO":
            //        _Rectangle = DGW_DET.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
            //        dtp.Size = new Size(_Rectangle.Width, _Rectangle.Height);
            //        dtp.Location = new Point(_Rectangle.X, _Rectangle.Y);
            //        dtp.Visible = true;

            //        break;
            //    //default:
            //    //    dtp.Visible = false;
            //    //    break;
            //}
        }

        private void DGW_DET_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            //dtp.Visible = true;
        }

        private void DGW_DET_Scroll(object sender, ScrollEventArgs e)
        {
            //dtp.Visible = true;
        }

        private void DGW_DET_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            //try
            //{
            //    if (DGW_DET.Focused && DGW_DET.CurrentCell.ColumnIndex == 7)
            //    {
            //        dtp.Location = DGW_DET.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Location;
            //        dtp.Visible = true;
            //        if (DGW_DET.CurrentCell.Value != DBNull.Value && DGW_DET.CurrentCell.Value.ToString() != "")
            //            dtp.Value = Convert.ToDateTime(DGW_DET.CurrentCell.Value);
            //        else
            //            dtp.Value = DateTime.Today;
            //    }
            //    else
            //        dtp.Visible = false;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);   
            //}

        }

        private void DGW_DET_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                if (!validaFechaCeldaGrid(e.FormattedValue.ToString()))
                {
                    //cuando le das a ESCAPE toma este valor, el de la columna 7
                    DGW_DET.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = DGW_DET.Rows[e.RowIndex].Cells["FE_1ER_PROCESO"].Value;// col 7
                    e.Cancel = true;
                    return;
                }
                DataGridViewCell cell = DGW_DET.Rows[e.RowIndex].Cells[e.ColumnIndex];
                DGW_DET.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = cell.Value;
            }
            else if (e.ColumnIndex == 9 || e.ColumnIndex == 10 || e.ColumnIndex == 11)
            {
                if (!validaNumeroCeldaGrid(e.FormattedValue.ToString(), false))
                {
                    //cuando le das a ESCAPE toma este valor, el de la columna 6
                    DGW_DET.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = DGW_DET.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;// col 6
                    e.Cancel = true;
                }
                DataGridViewCell cell = DGW_DET.Rows[e.RowIndex].Cells[e.ColumnIndex];
                DGW_DET.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = string.Format("{0:###,###,##0.00}", Convert.ToDecimal(cell.Value));
            }
        }
        private bool validaFechaCeldaGrid(string valor)
        {
            bool result = true;
            if (!HelpersBLL.esFecha(valor))
            {
                MessageBox.Show("Fecha no válida !!!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return result = false;
            }
            return result;
        }
        private bool validaNumeroCeldaGrid(string valor, bool incluyeCero)
        {
            bool result = true;
            if (!HelpersBLL.esNumeroDecimal(valor, incluyeCero))
            {
                MessageBox.Show("Cantidad no válida !!!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return result = false;
            }
            return result;
        }

        private void btnDesAprobar_Click(object sender, EventArgs e)
        {
            if (!validaDesAprobar())
                return;

            string errMensaje = "";
            pdvTo.NRO_PLANILLA_COB = Convert.ToString(dgv_generados.CurrentRow.Cells["NRO_PLANILLA_COB"].Value);
            pdvTo.TIPO_PLANILLA = Convert.ToString(dgv_generados.CurrentRow.Cells["TIPO_PLANILLA"].Value);
            pdvTo.FE_AÑO = Convert.ToString(dgv_generados.CurrentRow.Cells["FE_AÑO"].Value);
            pdvTo.FE_MES = Convert.ToString(dgv_generados.CurrentRow.Cells["FE_MES"].Value);
            DataTable dtDet = pdvBLL.obtenerPlanillaDetalleDirectoVariosBLL(pdvTo);
            //if (!pdvBLL.aprobarPlanillasDirectaVariosBLL(pllcTo, pdvTo, dtDetalle, ref errMensaje))
            //    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //else
            //{
            //    MessageBox.Show("Se aprobó o cerró correctamente", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    TabControl1.SelectedTab = TabPage1;
            //    DATAGRID();
            //    FOCO_NUEVO_REG("aprobar");
            //}
        }
        private bool validaDesAprobar()
        {
            bool result = true;
            if (!Convert.ToBoolean(dgv_generados.CurrentRow.Cells["STATUS_APROBADO2"].Value))
            {
                MessageBox.Show("No se puede DesAprobar este contrato porque no está Aprobado !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return result = false;
            }
            return result;
        }

    }
}
