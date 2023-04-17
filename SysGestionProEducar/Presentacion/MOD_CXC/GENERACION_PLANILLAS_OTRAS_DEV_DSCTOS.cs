using BLL;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;

namespace Presentacion.MOD_CXC
{
    public partial class GENERACION_PLANILLAS_OTRAS_DEV_DSCTOS : Form
    {
        string AÑO = "", MES = "", COD_MOD = "", COD_USU = "", TIPO_USU = "";
        DateTime FECHA_INI, FECHA_GRAL;
        HelpersBLL helBLL = new HelpersBLL();
        HelpersTo helTo = new HelpersTo();
        planillaCabeceraOtrasDevDsctosBLL plcBLL = new planillaCabeceraOtrasDevDsctosBLL();
        planillaCabeceraOtrasDevDsctosTo plcTo = new planillaCabeceraOtrasDevDsctosTo();
        tipoDocInvBLL tdiBLL = new tipoDocInvBLL();
        tipoDocInvTo tdiTo = new tipoDocInvTo();
        DataTable dtPersona;
        string COD_DOC;
        DataTable dtTipPlla;
        canjeTCtasxCobrarBLL ctcBLL = new canjeTCtasxCobrarBLL();
        canjeTCtasxCobrarTo ctcTo = new canjeTCtasxCobrarTo();
        decimal monto_pagado = 0; decimal monto_total = 0; decimal monto_total_a_pagar = 0;
        bool cuota_comprometida = false;//para saber si se aplican a las cuotas comprometidas
        public GENERACION_PLANILLAS_OTRAS_DEV_DSCTOS(string AÑO, string MES, DateTime FECHA_INI, DateTime FECHA_GRAL, string COD_MOD, string TIPO_USU, string COD_USU)
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

        private void GENERACION_PLANILLAS_OTRAS_DEV_DSCTOS_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            DATAGRID();
            CARGAR_SUCURSAL();
            CARGA_INSTITUCIONES();
            CARGAR_CANAL_DSCTO();
            CARGAR_TIPO_PLANILLA();
            CARGAR_PERSONAS();
            //dtp_generacion.Value = Convert.ToDateTime(DateTime.Now.Day + "/" + MES + "/" + AÑO);
            DateTime fe_plla = DateTime.Now;
            if (DateTime.TryParse((DateTime.Now.Day + "/" + MES + "/" + AÑO), out fe_plla))
                dtp_generacion.Value = Convert.ToDateTime(DateTime.Now.Day + "/" + MES + "/" + AÑO);
            else
                dtp_generacion.Value = FECHA_GRAL;
        }

        private void GENERACION_PLANILLAS_OTRAS_DEV_DSCTOS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }
        private void CARGAR_PERSONAS()
        {
            dgw_per.Rows.Clear();
            dtPersona = plcBLL.obtenerPlanillaCabeceraOtrasDevDsctosPendientesDAL();
            if (dtPersona.Rows.Count > 0)
            {
                foreach (DataRow rw in dtPersona.Rows)
                {
                    int rowId = dgw_per.Rows.Add();
                    DataGridViewRow row = dgw_per.Rows[rowId];
                    row.Cells["NRO_PLANILLA_COB1"].Value = rw["NRO_PLANILLA_COB"].ToString();
                    row.Cells["COD_SUCURSAL1"].Value = rw["COD_SUCURSAL"].ToString();
                    row.Cells["FE_AÑO1"].Value = rw["FE_AÑO"].ToString();
                    row.Cells["FE_MES1"].Value = rw["FE_MES"].ToString();
                    row.Cells["COD_PER1"].Value = rw["COD_PER"].ToString();
                    row.Cells["DESC_PER1"].Value = rw["DESC_PER"].ToString();
                    row.Cells["NRO_DOC1"].Value = rw["NRO_DOC"].ToString();
                    row.Cells["DESC_MOTIVO_OT_DEV1"].Value = rw["DESC_MOTIVO_OT_DEV"].ToString();
                    row.Cells["IMP_DOC1"].Value = rw["IMP_DOC"].ToString();
                    row.Cells["COD_MOTIVO_NO_DESCONTADO1"].Value = rw["COD_MOTIVO_NO_DESCONTADO"].ToString();
                    row.Cells["COD_INSTITUCION1"].Value = rw["COD_INSTITUCION"].ToString();
                    row.Cells["COD_CANAL_DSCTO1"].Value = rw["COD_CANAL_DSCTO"].ToString();
                    row.Cells["TIPO_PLA_COBRANZA1"].Value = rw["TIPO_PLA_COBRANZA"].ToString();
                    row.Cells["NRO_PRESUPUESTO1"].Value = rw["NRO_PRESUPUESTO"].ToString();
                    row.Cells["DESC_TIPO1"].Value = rw["DESC_TIPO"].ToString();
                    row.Cells["NRO_LETRA1"].Value = rw["NRO_LETRA"].ToString();
                    row.Cells["TOTAL_CONTRATO"].Value = rw["TOTAL_CONTRATO"].ToString();
                    row.Cells["CUOTA_COMPROMETIDA"].Value = rw["CUOTA_COMPROMETIDA"].ToString() == "True" ? "1" : "0";
                }
            }
        }
        private void DATAGRID()
        {
            plcTo.FE_AÑO = AÑO;
            plcTo.FE_MES = MES;
            DataTable dt = plcBLL.obtenerPlanillaCabeceraOtrasDevDsctosDAL(plcTo);
            if (dt.Rows.Count > 0)
            {
                dgv_generados.Rows.Clear();
                foreach (DataRow rw in dt.Rows)
                {
                    int rowId = dgv_generados.Rows.Add();
                    DataGridViewRow row = dgv_generados.Rows[rowId];
                    row.Cells["NRO_PLANILLA_DOC2"].Value = rw["NRO_PLANILLA_DOC"].ToString();
                    row.Cells["COD_INSTITUCION2"].Value = rw["COD_INSTITUCION"].ToString();
                    row.Cells["COD_CANAL_DSCTO2"].Value = rw["COD_CANAL_DSCTO"].ToString();
                    row.Cells["FE_AÑO2"].Value = rw["FE_AÑO"].ToString();
                    row.Cells["FE_MES2"].Value = rw["FE_MES"].ToString();
                    row.Cells["COD_PER2"].Value = rw["COD_PER"].ToString();
                    row.Cells["DESC_PER2"].Value = rw["DESC_PER"].ToString();
                    row.Cells["COD_SUCURSAL2"].Value = rw["COD_SUCURSAL"].ToString();
                    row.Cells["FECHA_PLANILLA_DOC2"].Value = rw["FECHA_PLANILLA_DOC"].ToString().Substring(0, 10);
                    row.Cells["COD_PER2"].Value = rw["COD_PER"].ToString();
                    row.Cells["DESC_PER2"].Value = rw["DESC_PER"].ToString();
                    row.Cells["DNI2"].Value = rw["DNI"].ToString();
                    row.Cells["NRO_CONTRATO2"].Value = rw["NRO_CONTRATO"].ToString();
                    row.Cells["TIPO_PLANILLA_DOC2"].Value = rw["TIPO_PLANILLA_DOC"].ToString();
                    row.Cells["IMPORTE_TOTAL2"].Value = rw["IMPORTE_TOTAL"].ToString();
                    row.Cells["OBSERVACIONES2"].Value = rw["OBSERVACIONES"].ToString();
                    row.Cells["STATUS_CIERRE2"].Value = rw["STATUS_CIERRE"].ToString() == "1" ? true : false;
                    row.Cells["DESC_TIPO2"].Value = rw["DESC_TIPO"].ToString();
                    row.Cells["COD_PTO_COB2"].Value = rw["COD_PTO_COB"].ToString();
                    row.Cells["STATUS_CTACTE2"].Value = rw["STATUS_CTACTE"].ToString();
                    row.Cells["COD_VENTA2"].Value = rw["COD_VENTA"].ToString();
                    row.Cells["STATUS_COMPROM"].Value = rw["STATUS_COMPROM"].ToString();
                }
            }
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
        private void CARGA_INSTITUCIONES()
        {
            institucionesBLL insBLL = new institucionesBLL();
            DataTable dtInstitucion = insBLL.obtenerInstitucionesBLL();
            ////dtInstitucion2 = insBLL.obtenerInstitucionesBLL();
            //DataRow rw = dtInstitucion.NewRow();
            //rw["COD_INST"] = "0";
            //rw["DESC_INST"] = "";
            //dtInstitucion.Rows.InsertAt(rw, 0);
            cbo_institucion.ValueMember = "COD_INST";
            cbo_institucion.DisplayMember = "DESC_INST";
            cbo_institucion.DataSource = dtInstitucion;
            cbo_institucion.SelectedIndex = 0;
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
        private void CARGAR_TIPO_PLANILLA()
        {
            tipoPlanillaCreacionBLL tpcBLL = new tipoPlanillaCreacionBLL();
            dtTipPlla = tpcBLL.obtenerTipoPlanillaCreacionxTransferenciaBLL();
            if (dtTipPlla.Rows.Count > 0)
            {
                cbo_tipo_planilla.ValueMember = "COD_TIPO_PLLA";
                cbo_tipo_planilla.DisplayMember = "DESC_TIPO";
                cbo_tipo_planilla.DataSource = dtTipPlla;
                cbo_tipo_planilla.SelectedIndex = 0;
            }
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            btn_grabar.Visible = true;
            btn_modificar2.Visible = false;
            TabControl1.SelectedTab = (TabPage2);
            LIMPIAR();
            cbo_sucursal.SelectedIndex = -1;
            btn_grabar.Enabled = true;
            txt_ser.ReadOnly = false;
            txt_num.ReadOnly = false;
            cbo_institucion.Enabled = true;
            cbo_canaldscto.Enabled = true;
            cbo_tipo_planilla.Enabled = true;
            cbo_sucursal.Focus();
        }
        private void LIMPIAR()
        {
            cbo_sucursal.SelectedIndex = -1;
            cbo_institucion.SelectedIndex = -1;
            txt_ser.Clear();
            txt_num.Clear();
            lbl_cod_tipo_plla.Text = "XX";
            TXT_COD.Clear();
            TXT_DESC.Clear();
            txt_doc_per.Clear();
            txt_tot_pagado.Clear();
            cbo_canaldscto.SelectedIndex = -1;
            cbo_tipo_planilla.SelectedIndex = -1;
            txt_observaciones.Clear();
            dgw_det.Rows.Clear();
        }
        private bool validaModificar()
        {
            bool result = true;
            if (Convert.ToBoolean(dgv_generados.CurrentRow.Cells["STATUS_CIERRE2"].Value))
            {
                MessageBox.Show("No se puede modificar porque ya está Aprobado !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return result = false;
            }

            return result;
        }
        private void btn_modificar_Click(object sender, EventArgs e)
        {
            if (!validaModificar())
                return;
            btn_grabar.Visible = false;
            btn_modificar2.Visible = true;
            //txt_ser.Visible = true;
            TabControl1.SelectedTab = (TabPage2);
            LIMPIAR();
            btn_grabar.Enabled = false;
            btn_modificar2.Enabled = true;
            txt_ser.ReadOnly = true;
            txt_num.ReadOnly = true;
            cbo_institucion.Enabled = false;
            cbo_canaldscto.Enabled = false;
            cbo_tipo_planilla.Enabled = false;
            CARGAR_CABECERA_DOCUMENTO();
            CARGAR_DETALLE_DOCUMENTO();
        }
        private void CARGAR_CABECERA_DOCUMENTO()
        {
            TXT_COD.Text = dgv_generados.CurrentRow.Cells["COD_PER2"].Value.ToString();
            TXT_DESC.Text = dgv_generados.CurrentRow.Cells["DESC_PER2"].Value.ToString();
            txt_doc_per.Text = dgv_generados.CurrentRow.Cells["DNI2"].Value.ToString();
            txt_nro_contrato.Text = dgv_generados.CurrentRow.Cells["NRO_CONTRATO2"].Value.ToString();
            cbo_sucursal.SelectedValue = dgv_generados.CurrentRow.Cells["COD_SUCURSAL2"].Value;
            cbo_institucion.SelectedValue = dgv_generados.CurrentRow.Cells["COD_INSTITUCION2"].Value;
            dtp_generacion.Value = Convert.ToDateTime(dgv_generados.CurrentRow.Cells["FECHA_PLANILLA_DOC2"].Value);
            lbl_cod_tipo_plla.Text = dgv_generados.CurrentRow.Cells["TIPO_PLANILLA_DOC2"].Value.ToString();
            txt_ser.Text = dgv_generados.CurrentRow.Cells["NRO_PLANILLA_DOC2"].Value.ToString().Substring(0, 3);
            txt_num.Text = dgv_generados.CurrentRow.Cells["NRO_PLANILLA_DOC2"].Value.ToString().Substring(4, 7);
            txt_tot_pagado.Text = Convert.ToDecimal(dgv_generados.CurrentRow.Cells["IMPORTE_TOTAL2"].Value).ToString("###,###,##0.00");
            cbo_canaldscto.SelectedValue = dgv_generados.CurrentRow.Cells["COD_CANAL_DSCTO2"].Value;
            cbo_tipo_planilla.SelectedValue = dgv_generados.CurrentRow.Cells["TIPO_PLANILLA_DOC2"].Value;
            txt_observaciones.Text = dgv_generados.CurrentRow.Cells["OBSERVACIONES2"].Value.ToString();
        }
        private void CARGAR_DETALLE_DOCUMENTO()
        {
            planillaDetalleOtrasDevDsctosBLL pldBLL = new planillaDetalleOtrasDevDsctosBLL();
            planillaDetalleOtrasDevDsctosTo pldTo = new planillaDetalleOtrasDevDsctosTo();
            pldTo.NRO_PLANILLA_DOC = dgv_generados.CurrentRow.Cells["NRO_PLANILLA_DOC2"].Value.ToString();
            pldTo.COD_INSTITUCION = dgv_generados.CurrentRow.Cells["COD_INSTITUCION2"].Value.ToString();
            pldTo.COD_CANAL_DSCTO = dgv_generados.CurrentRow.Cells["COD_CANAL_DSCTO2"].Value.ToString();
            pldTo.FE_AÑO = dgv_generados.CurrentRow.Cells["FE_AÑO2"].Value.ToString();
            pldTo.FE_MES = dgv_generados.CurrentRow.Cells["FE_MES2"].Value.ToString();
            pldTo.TIPO_PLANILLA_DOC = dgv_generados.CurrentRow.Cells["TIPO_PLANILLA_DOC2"].Value.ToString();

            DataTable dt = pldBLL.obtenerPlanillaDetalleOtrasDevDsctosBLL(pldTo);
            if (dt.Rows.Count > 0)
            {
                dgw_det.Rows.Clear();
                foreach (DataRow rw in dt.Rows)
                {
                    int rowId = dgw_det.Rows.Add();
                    DataGridViewRow row = dgw_det.Rows[rowId];
                    row.Cells["NRO_PLANILLA_DOC"].Value = rw["NRO_PLANILLA_DOC"].ToString();
                    row.Cells["COD_INSTITUCION"].Value = rw["COD_INSTITUCION"].ToString();
                    row.Cells["COD_CANAL_DSCTO"].Value = rw["COD_CANAL_DSCTO"].ToString();
                    row.Cells["FE_AÑO"].Value = rw["FE_AÑO"].ToString();
                    row.Cells["FE_MES"].Value = rw["FE_MES"].ToString();
                    row.Cells["NRO_PLANILLA_COB"].Value = rw["NRO_PLANILLA_COB"].ToString();
                    row.Cells["IMP_DOC"].Value = rw["IMP_DOC"].ToString();
                    row.Cells["MOTIVO_OTRAS_DEV_DSCTOS"].Value = rw["MOTIVO_OTRAS_DEV_DSCTOS"].ToString();
                    row.Cells["DESC_MOTIVO_OT_DEV"].Value = rw["DESC_MOTIVO_OT_DEV"].ToString();
                    row.Cells["NRO_LETRA"].Value = rw["NRO_LETRA"].ToString();
                    row.Cells["IMP_DEV"].Value = 0;//rw["IMP_DEV"].ToString();
                }
                if (pldTo.TIPO_PLANILLA_DOC == "PA" && Convert.ToDecimal(dt.Rows[0]["IMP_DEV"]) > 0)
                {
                    int rowId = dgw_det.Rows.Add();
                    DataGridViewRow row = dgw_det.Rows[rowId];
                    row.Cells["NRO_PLANILLA_DOC"].Value = dt.Rows[0]["NRO_PLANILLA_DOC"].ToString();
                    row.Cells["COD_INSTITUCION"].Value = dt.Rows[0]["COD_INSTITUCION"].ToString();
                    row.Cells["COD_CANAL_DSCTO"].Value = dt.Rows[0]["COD_CANAL_DSCTO"].ToString();
                    row.Cells["FE_AÑO"].Value = dt.Rows[0]["FE_AÑO"].ToString();
                    row.Cells["FE_MES"].Value = dt.Rows[0]["FE_MES"].ToString();
                    row.Cells["NRO_PLANILLA_COB"].Value = dt.Rows[0]["NRO_PLANILLA_COB"].ToString();
                    row.Cells["IMP_DOC"].Value = dt.Rows[0]["IMP_DOC"].ToString();
                    row.Cells["MOTIVO_OTRAS_DEV_DSCTOS"].Value = dt.Rows[0]["MOTIVO_OTRAS_DEV_DSCTOS"].ToString();
                    row.Cells["DESC_MOTIVO_OT_DEV"].Value = dt.Rows[0]["DESC_MOTIVO_OT_DEV"].ToString();
                    row.Cells["NRO_LETRA"].Value = "**";//dt.Rows[0]["NRO_LETRA"].ToString();
                    row.Cells["IMP_DEV"].Value = dt.Rows[0]["IMP_DEV"].ToString();
                    //aqui se va la servidor para traer datos de nro_contrato y demas columnas de dgw_det al final del grid de columnas
                    row.Cells["MOTIVO_OTRAS_DEV_DSCTOS2"].Value = "006";
                    row.Cells["NRO_CONTRATO"].Value = dgv_generados.CurrentRow.Cells["NRO_CONTRATO2"].Value.ToString();
                    row.Cells["COD_PER"].Value = dgv_generados.CurrentRow.Cells["COD_PER2"].Value.ToString();
                    row.Cells["FECHA_PLANILLA_COB"].Value = dgv_generados.CurrentRow.Cells["FECHA_PLANILLA_DOC2"].Value.ToString();
                    row.Cells["FECHA_VEN"].Value = "";
                    row.Cells["IMP_COB"].Value = dt.Rows[0]["IMP_DEV"].ToString();
                }
            }
        }

        private void btn_grabar_Click(object sender, EventArgs e)
        {
            if (!validaGrabar())
                return;
            string men = "";
            string mens = "";
            DataRow[] result = dtTipPlla.Select("COD_TIPO_PLLA='" + cbo_tipo_planilla.SelectedValue.ToString() + "'");
            if (result.Length > 0)
                men = result[0][2].ToString();
            if (men == "1")
                mens = "Esta operación afecta a la Cuenta Corriente del cliente.";
            else
                mens = "Esta operación afecta a Tesorería.";
            DialogResult rs = MessageBox.Show(mens + "\n¿ Esta seguro ingresar una nueva Planilla ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                plcTo.NRO_PLANILLA_DOC = txt_ser.Text + "-" + txt_num.Text;
                plcTo.SERIE = txt_ser.Text;
                plcTo.COD_INSTITUCION = cbo_institucion.SelectedValue.ToString();
                plcTo.COD_CANAL_DSCTO = cbo_canaldscto.SelectedValue.ToString();
                plcTo.FE_AÑO = AÑO;
                plcTo.FE_MES = MES;
                plcTo.COD_SUCURSAL = cbo_sucursal.SelectedValue.ToString();
                plcTo.COD_CLASE = "01";
                plcTo.FECHA_PLANILLA_DOC = dtp_generacion.Value;
                plcTo.COD_PER = TXT_COD.Text;
                plcTo.DESC_PER = TXT_DESC.Text;
                plcTo.DNI = txt_doc_per.Text;
                plcTo.NRO_CONTRATO = txt_nro_contrato.Text;
                plcTo.TIPO_PLANILLA_DOC = cbo_tipo_planilla.SelectedValue.ToString();
                plcTo.IMPORTE_TOTAL = Convert.ToDecimal(txt_tot_pagado.Text);
                plcTo.OBSERVACIONES = txt_observaciones.Text;
                plcTo.STATUS_CIERRE = "0";
                plcTo.COD_CREA = COD_USU;
                plcTo.FECHA_CREA = DateTime.Now;
                tdiTo.TIPO_DOC = plcTo.TIPO_PLANILLA_DOC;
                plcTo.COD_DOC = COD_DOC;//tdiBLL.obtieneCodDocInvxTipoDocBLL(tdiTo);
                plcTo.STATUS_DOC = "0";
                plcTo.NRO_LETRA = dgw_det.Rows[0].Cells["NRO_LETRA"].Value.ToString();
                plcTo.STATUS_COMPROM = cuota_comprometida == true ? "1" : "0";//"0";
                plcTo.COD_GESTOR = COD_USU;// hay que ver esto!!!!

                DataTable dtDetalle = HelpersBLL.obtenerDT(dgw_det);
                if (!plcBLL.insertarPlanillasOtrasDevDsctosBLL(plcTo, dtDetalle, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("El ingreso se hizo correctamente", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TabControl1.SelectedTab = TabPage1;
                    DATAGRID();
                    CARGAR_PERSONAS();//para actualizar el grid desplegable
                    FOCO_NUEVO_REG();
                }
            }
        }
        private bool validaGrabar()
        {
            bool result = true;
            //cuando se aplica que pregunte si es ultima cuota
            if (cbo_tipo_planilla.SelectedValue.ToString() == "PA" || cbo_tipo_planilla.SelectedValue.ToString() == "PC")
            {
                if (monto_pagado >= monto_total)
                {
                    MessageBox.Show("Se ha terminado de pagar todo el contrato, debe realizar una planilla \npor DEVOLUCION EXC CUOTA ó DEVOLUCION EXC CUOTA COMPROMETIDA", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return result = false;
                }
                if (Convert.ToDecimal(txt_tot_pagado.Text) > monto_total_a_pagar)
                {
                    MessageBox.Show("El importe de la planilla es superior al monto total de la deuda, \nse aplicarán " + monto_total_a_pagar + " y se hará una planilla de Exceso Contrato \npor " + (Convert.ToDecimal(txt_tot_pagado.Text) - monto_total_a_pagar) + " !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return result = true;
                }
            }

            return result;
        }
        private bool validaFormulario()
        {
            bool result = true;
            return result;
        }
        private void FOCO_NUEVO_REG()
        {
            int i, cont = 0;
            cont = dgv_generados.Columns.Count - 1;
            string nrocon = txt_ser.Text + "-" + txt_num.Text.Trim() + lbl_cod_tipo_plla.Text;
            for (i = 0; i <= cont; i++)
            {
                if (nrocon == dgv_generados.Rows[i].Cells["NRO_PLANILLA_DOC2"].Value.ToString().ToLower() + dgv_generados.Rows[i].Cells["TIPO_PLANILLA_DOC2"].Value.ToString())
                {
                    dgv_generados.CurrentCell = dgv_generados.Rows[i].Cells["NRO_PLANILLA_DOC2"];
                    return;
                }
            }
        }

        private void btn_modificar2_Click(object sender, EventArgs e)
        {
            if (!validaFormulario())
                return;
            DialogResult rs = MessageBox.Show("¿ Esta seguro modificar la Planilla ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                plcTo.NRO_PLANILLA_DOC = txt_ser.Text + "-" + txt_num.Text;
                plcTo.SERIE = txt_ser.Text;
                plcTo.COD_INSTITUCION = cbo_institucion.SelectedValue.ToString();
                plcTo.COD_CANAL_DSCTO = cbo_canaldscto.SelectedValue.ToString();
                plcTo.FE_AÑO = AÑO;
                plcTo.FE_MES = MES;
                plcTo.COD_SUCURSAL = cbo_sucursal.SelectedValue.ToString();
                plcTo.FECHA_PLANILLA_DOC = dtp_generacion.Value;
                plcTo.COD_PER = TXT_COD.Text;
                plcTo.DESC_PER = TXT_DESC.Text;
                plcTo.DNI = txt_doc_per.Text;
                plcTo.NRO_CONTRATO = txt_nro_contrato.Text;
                plcTo.TIPO_PLANILLA_DOC = cbo_tipo_planilla.SelectedValue.ToString();
                plcTo.IMPORTE_TOTAL = Convert.ToDecimal(txt_tot_pagado.Text);
                plcTo.OBSERVACIONES = txt_observaciones.Text;
                plcTo.STATUS_CIERRE = "0";
                plcTo.COD_CREA = COD_USU;
                plcTo.FECHA_CREA = DateTime.Now;
                tdiTo.TIPO_DOC = plcTo.TIPO_PLANILLA_DOC;
                plcTo.COD_DOC = COD_DOC;//tdiBLL.obtieneCodDocInvxTipoDocBLL(tdiTo);
                plcTo.STATUS_DOC = "0";
                plcTo.NRO_LETRA = dgw_det.Rows[0].Cells["NRO_LETRA"].Value.ToString();
                plcTo.STATUS_COMPROM = cuota_comprometida == true ? "1" : "0";//"0";

                DataTable dtDetalle = HelpersBLL.obtenerDT(dgw_det);
                if (!plcBLL.modificarPlanillasOtrasDevDsctosBLL(plcTo, dtDetalle, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("La modificación se hizo correctamente", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TabControl1.SelectedTab = TabPage1;
                    DATAGRID();
                    //FOCO_NUEVO_REG();
                }
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            TabControl1.SelectedTab = (TabPage1);
        }

        private void TXT_COD_Leave(object sender, EventArgs e)
        {
            if (TXT_COD.Text.Trim() != "")
            {
                if (dgw_per.Rows.Count > 0)
                {
                    //dgw_per.Sort(dgw_per.Columns[0], System.ComponentModel.ListSortDirection.Ascending);
                    dgw_per.Sort(dgw_per.Columns["COD_PER1"], System.ComponentModel.ListSortDirection.Ascending);
                    int i = 0, num2 = 0;
                    num2 = dgw_per.Rows.Count - 1;
                    do
                    {
                        //if (TXT_COD.Text.ToLower() == dgw_per[0, i].Value.ToString().ToLower())
                        if (TXT_COD.Text.ToLower() == dgw_per.Rows[i].Cells["COD_PER1"].Value.ToString().ToLower())
                        {
                            TXT_COD.Text = dgw_per.Rows[i].Cells["COD_PER1"].Value.ToString();//dgw_per[0, i].Value.ToString();
                            TXT_DESC.Text = dgw_per.Rows[i].Cells["DESC_PER1"].Value.ToString();//dgw_per[1, i].Value.ToString();
                            txt_doc_per.Text = dgw_per.Rows[i].Cells["NRO_DOC1"].Value.ToString();//dgw_per[2, i].Value.ToString();
                            cbo_sucursal.SelectedValue = dgw_per.Rows[i].Cells["COD_SUCURSAL1"].Value;
                            cbo_institucion.SelectedValue = dgw_per.Rows[i].Cells["COD_INSTITUCION1"].Value;
                            cbo_canaldscto.SelectedValue = dgw_per.Rows[i].Cells["COD_CANAL_DSCTO1"].Value;
                            cbo_tipo_planilla.SelectedValue = dgw_per.Rows[i].Cells["TIPO_PLA_COBRANZA1"].Value;
                            //ingresoDetalle();
                            btn_grabar.Focus();
                            return;
                        }
                        //f (TXT_COD.Text.ToLower() == dgw_per[0, i].Value.ToString().ToLower().Substring(0, TXT_COD.TextLength))
                        if (TXT_COD.Text.ToLower() == dgw_per.Rows[i].Cells["COD_PER1"].Value.ToString().ToLower().Substring(0, TXT_COD.TextLength))
                        {
                            dgw_per.CurrentCell = dgw_per.Rows[i].Cells["COD_PER1"];//dgw_per.Rows[i].Cells[0];
                            break;
                        }
                        dgw_per.CurrentCell = dgw_per.Rows[0].Cells["COD_PER1"];//dgw_per.Rows[0].Cells[0];
                        i += 1;
                    }
                    while (i <= num2);
                    Panel_PER.BringToFront();
                    Panel_PER.Visible = true;
                    dgw_per.Visible = true;
                    dgw_per.Focus();
                }
            }
        }
        private void ingresoDetalle()
        {
            dgw_det.Rows.Clear();
            //solo tiene un registro
            int rowId = dgw_det.Rows.Add();
            DataGridViewRow row = dgw_det.Rows[rowId];
            row.Cells["NRO_PLANILLA_DOC"].Value = txt_ser.Text + "-" + txt_num.Text;
            row.Cells["COD_INSTITUCION"].Value = cbo_institucion.SelectedValue.ToString();
            row.Cells["COD_CANAL_DSCTO"].Value = cbo_canaldscto.SelectedValue.ToString();
            row.Cells["FE_AÑO"].Value = AÑO;
            row.Cells["FE_MES"].Value = MES;
            row.Cells["NRO_PLANILLA_COB"].Value = dgw_per.CurrentRow.Cells["NRO_PLANILLA_COB1"].Value.ToString();
            row.Cells["IMP_DOC"].Value = txt_tot_pagado.Text;
            row.Cells["MOTIVO_OTRAS_DEV_DSCTOS"].Value = dgw_per.CurrentRow.Cells["COD_MOTIVO_NO_DESCONTADO1"].Value.ToString();
            row.Cells["DESC_MOTIVO_OT_DEV"].Value = dgw_per.CurrentRow.Cells["DESC_MOTIVO_OT_DEV1"].Value.ToString();
            row.Cells["NRO_LETRA"].Value = dgw_per.CurrentRow.Cells["NRO_LETRA1"].Value.ToString();
            row.Cells["IMP_DEV"].Value = 0;
            //
            if (Convert.ToDecimal(txt_tot_pagado.Text) > monto_total_a_pagar) //DEV EXCESO CONTRATO
            {

                //row.Cells["MOTIVO_OTRAS_DEV_DSCTOS2"].Value = "006";
                //row.Cells["NRO_CONTRATO"].Value = txt_nro_contrato.Text;
                //row.Cells["COD_PER"].Value = TXT_COD.Text;
                //row.Cells["FECHA_PLANILLA_COB"].Value = dtp_generacion.Value;
                //row.Cells["FECHA_VEN"].Value = "";
                //row.Cells["IMP_COB"].Value = Convert.ToDecimal(txt_tot_pagado.Text) - monto_total_a_pagar;
                row.Cells["IMP_DEV"].Value = Convert.ToDecimal(txt_tot_pagado.Text) - monto_total_a_pagar;// esto es lo que va para DEV EXCESO CONTRATO
            }
        }

        private void dgw_per_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int i = dgw_per.CurrentRow.Index;
                TXT_COD.Text = dgw_per.Rows[i].Cells["COD_PER1"].Value.ToString();//dgw_per[0, i].Value.ToString();
                TXT_DESC.Text = dgw_per.Rows[i].Cells["DESC_PER1"].Value.ToString();//dgw_per[1, i].Value.ToString();
                txt_doc_per.Text = dgw_per.Rows[i].Cells["NRO_DOC1"].Value.ToString();//dgw_per[2, i].Value.ToString();
                cbo_sucursal.SelectedValue = dgw_per.Rows[i].Cells["COD_SUCURSAL1"].Value;
                cbo_institucion.SelectedValue = dgw_per.Rows[i].Cells["COD_INSTITUCION1"].Value.ToString() == "" ? "01" : dgw_per.Rows[i].Cells["COD_INSTITUCION1"].Value;
                cbo_canaldscto.SelectedValue = dgw_per.Rows[i].Cells["COD_CANAL_DSCTO1"].Value.ToString() == "" ? "1404" : dgw_per.Rows[i].Cells["COD_CANAL_DSCTO1"].Value;
                cbo_tipo_planilla.SelectedValue = dgw_per.Rows[i].Cells["TIPO_PLA_COBRANZA1"].Value;
                txt_tot_pagado.Text = Convert.ToDecimal(dgw_per.Rows[i].Cells["IMP_DOC1"].Value).ToString("###,###,##0.00");
                lbl_cod_tipo_plla.Text = cbo_tipo_planilla.SelectedValue.ToString();
                txt_nro_contrato.Text = dgw_per.Rows[i].Cells["NRO_PRESUPUESTO1"].Value.ToString();
                cuota_comprometida = dgw_per.Rows[i].Cells["CUOTA_COMPROMETIDA"].Value.ToString() == "1" ? true : false;
                ctcTo.NRO_CONTRATO = txt_nro_contrato.Text;
                string errMensaje = "";
                monto_pagado = ctcBLL.obtenerMontoPagadoxContratoBLL(ctcTo, ref errMensaje);//monto que se ha pagado hasta el momento
                monto_total = Convert.ToDecimal(dgw_per.CurrentRow.Cells["TOTAL_CONTRATO"].Value);//monto del contrato
                monto_total_a_pagar = monto_total - monto_pagado;
                ingresoDetalle();
                Panel_PER.Visible = false;
                //MostrarFormaPago();
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
                    //dgw_per.Sort(dgw_per.Columns[1], System.ComponentModel.ListSortDirection.Ascending);
                    dgw_per.Sort(dgw_per.Columns["DESC_PER1"], System.ComponentModel.ListSortDirection.Ascending);
                    int i = 0, num2 = 0;
                    num2 = dgw_per.Rows.Count;
                    do
                    {
                        //if (dgw_per[1, i].Value.ToString().Length >= TXT_DESC.TextLength)
                        if (dgw_per.Rows[i].Cells["DESC_PER1"].Value.ToString().Length >= TXT_DESC.TextLength)
                        {
                            if (TXT_DESC.Text.ToLower() == dgw_per.Rows[i].Cells["DESC_PER1"].Value.ToString().ToLower().Substring(0, TXT_DESC.TextLength).ToLower())//dgw_per[1, i].Value.ToString().ToLower().Substring(0, TXT_DESC.TextLength).ToLower())
                            {
                                dgw_per.CurrentCell = dgw_per.Rows[i].Cells["COD_PER1"];//dgw_per.Rows[i].Cells[0];
                                break;
                            }
                        }
                        dgw_per.CurrentCell = dgw_per.Rows[0].Cells["COD_PER1"];//dgw_per.Rows[0].Cells[0];
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
                    DataRow[] rs = dtPersona.Select("NRO_DOC = '" + txt_doc_per.Text.Trim() + "'");
                    if (rs.Length > 0)
                    {
                        //dgw_per.Sort(dgw_per.Columns[2], System.ComponentModel.ListSortDirection.Ascending);
                        dgw_per.Sort(dgw_per.Columns["NRO_DOC1"], System.ComponentModel.ListSortDirection.Ascending);
                        int i = 0, num2 = 0;
                        num2 = dgw_per.Rows.Count;
                        do
                        {
                            //if (dgw_per[2, i].Value.ToString().Length >= txt_doc_per.TextLength)
                            if (dgw_per.Rows[i].Cells["NRO_DOC1"].Value.ToString().Length >= txt_doc_per.TextLength)
                            {
                                //if (txt_doc_per.Text.ToLower() == dgw_per[2, i].Value.ToString().ToLower().Substring(0, txt_doc_per.TextLength).ToLower())
                                if (txt_doc_per.Text.ToLower() == dgw_per.Rows[i].Cells["NRO_DOC1"].Value.ToString().ToLower().Substring(0, txt_doc_per.TextLength).ToLower())
                                {
                                    dgw_per.CurrentCell = dgw_per.Rows[i].Cells["COD_PER1"];//dgw_per.Rows[i].Cells[0];
                                    break;
                                }
                            }
                            dgw_per.CurrentCell = dgw_per.Rows[0].Cells["COD_PER1"];//dgw_per.Rows[0].Cells[0];
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
                    }
                }
            }
        }

        private void cbo_sucursal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_sucursal.SelectedValue != null)
            {
                if (cbo_tipo_planilla.SelectedValue != null)
                    obtieneNroPlla();
            }
        }
        private void obtieneNroPlla()
        {
            if (btn_grabar.Visible)
            {
                tdiTo.TIPO_DOC = cbo_tipo_planilla.SelectedValue.ToString();
                COD_DOC = tdiBLL.obtieneCodDocInvxTipoDocBLL(tdiTo);
                DataTable dt = HelpersBLL.obtieneNroPlanilla(cbo_sucursal.SelectedValue.ToString(), "0", COD_DOC);
                txt_ser.Text = dt.Rows[0]["SERIE"].ToString();
                txt_num.Text = dt.Rows[0]["NUMERO"].ToString();
            }
        }
        private bool validaAprobar()
        {
            bool result = true;
            if (Convert.ToBoolean(dgv_generados.CurrentRow.Cells["STATUS_CIERRE2"].Value))
            {
                MessageBox.Show("El registro ya está Aprobado !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return result = false;
            }

            return result;
        }
        private void btn_aprobar_Click(object sender, EventArgs e)
        {
            if (!validaAprobar())
                return;
            DialogResult rs = MessageBox.Show("¿ Esta seguro aprobar o cerrar la Planilla ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                plcTo.NRO_PLANILLA_DOC = dgv_generados.CurrentRow.Cells["NRO_PLANILLA_DOC2"].Value.ToString();
                plcTo.SERIE = dgv_generados.CurrentRow.Cells["NRO_PLANILLA_DOC2"].Value.ToString().Substring(0, 3);
                plcTo.COD_INSTITUCION = dgv_generados.CurrentRow.Cells["COD_INSTITUCION2"].Value.ToString();
                plcTo.COD_CANAL_DSCTO = dgv_generados.CurrentRow.Cells["COD_CANAL_DSCTO2"].Value.ToString();
                plcTo.FE_AÑO = dgv_generados.CurrentRow.Cells["FE_AÑO2"].Value.ToString();//AÑO;
                plcTo.FE_MES = dgv_generados.CurrentRow.Cells["FE_MES2"].Value.ToString();//MES;
                plcTo.COD_SUCURSAL = dgv_generados.CurrentRow.Cells["COD_SUCURSAL2"].Value.ToString();
                //plcTo.FECHA_PLANILLA_DOC = Convert.ToDateTime(Convert.ToDateTime(dgv_generados.CurrentRow.Cells["FECHA_PLANILLA_DOC2"].Value + " " + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString()));
                plcTo.FECHA_PLANILLA_DOC = Convert.ToDateTime(Convert.ToDateTime(dgv_generados.CurrentRow.Cells["FECHA_PLANILLA_DOC2"].Value.ToString() + " " + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString()));
                plcTo.COD_PER = dgv_generados.CurrentRow.Cells["COD_PER2"].Value.ToString();
                plcTo.DESC_PER = dgv_generados.CurrentRow.Cells["DESC_PER2"].Value.ToString();
                plcTo.DNI = dgv_generados.CurrentRow.Cells["DNI2"].Value.ToString();
                plcTo.NRO_CONTRATO = dgv_generados.CurrentRow.Cells["NRO_CONTRATO2"].Value.ToString();
                plcTo.TIPO_PLANILLA_DOC = dgv_generados.CurrentRow.Cells["TIPO_PLANILLA_DOC2"].Value.ToString();
                plcTo.IMPORTE_TOTAL = Convert.ToDecimal(dgv_generados.CurrentRow.Cells["IMPORTE_TOTAL2"].Value);
                plcTo.OBSERVACIONES = dgv_generados.CurrentRow.Cells["OBSERVACIONES2"].Value.ToString();
                plcTo.STATUS_CTACTE = dgv_generados.CurrentRow.Cells["STATUS_CTACTE2"].Value.ToString();
                plcTo.COD_VENTA = dgv_generados.CurrentRow.Cells["COD_VENTA2"].Value.ToString();
                plcTo.STATUS_COMPROM = dgv_generados.CurrentRow.Cells["STATUS_COMPROM"].Value.ToString();
                //plcTo.STATUS_CIERRE = "0";
                plcTo.COD_CREA = COD_USU;
                plcTo.FECHA_CREA = DateTime.Now;
                plcTo.COD_MOD = "S";
                //
                plcTo.COD_PTO_COB = dgv_generados.CurrentRow.Cells["COD_PTO_COB2"].Value.ToString();
                plcTo.COD_CLASE = "01";
                CARGAR_DETALLE_DOCUMENTO();
                DataTable dtDetalle = HelpersBLL.obtenerDT(dgw_det);
                if (!plcBLL.aprobarPlanillasOtrasDevDsctosBLL(plcTo, dtDetalle, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Se aprobó o cerró correctamente", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TabControl1.SelectedTab = TabPage1;
                    DATAGRID();
                    CARGAR_PERSONAS();//para actualizar el grid desplegable
                    //FOCO_NUEVO_REG();
                }
            }
        }

        private void cbo_tipo_planilla_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_tipo_planilla.SelectedValue != null)
            {
                if (chk_op.Checked == false)
                {
                    if (cbo_sucursal.SelectedValue != null)
                    {
                        obtieneNroPlla();
                        lbl_cod_tipo_plla.Text = cbo_tipo_planilla.SelectedValue.ToString();
                    }
                }
                else
                {
                    if (cbo_tipo_planilla.SelectedValue.ToString() == "DX" || cbo_tipo_planilla.SelectedValue.ToString() == "PA")
                    {
                        if (cbo_sucursal.SelectedValue != null)
                        {
                            obtieneNroPlla();
                            lbl_cod_tipo_plla.Text = cbo_tipo_planilla.SelectedValue.ToString();
                        }
                    }
                    else if (cbo_tipo_planilla.SelectedValue.ToString() == "DS" || cbo_tipo_planilla.SelectedValue.ToString() == "PS")
                    {
                        if (cbo_sucursal.SelectedValue != null)
                        {
                            obtieneNroPlla();
                            lbl_cod_tipo_plla.Text = cbo_tipo_planilla.SelectedValue.ToString();
                        }
                    }
                    else
                    {
                        cbo_tipo_planilla.SelectedValue = lbl_cod_tipo_plla.Text;
                    }
                    chk_op.Checked = false;
                }
            }
        }

        private void chk_op_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_op.Checked)
            {
                cbo_tipo_planilla.Enabled = true;
            }
            else
            {
                cbo_tipo_planilla.Enabled = false;
            }
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (!validaFormulario())
                return;
            DialogResult rs = MessageBox.Show("¿ Esta seguro eliminar la Planilla ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                plcTo.NRO_PLANILLA_DOC = dgv_generados.CurrentRow.Cells["NRO_PLANILLA_DOC2"].Value.ToString();
                plcTo.COD_INSTITUCION = dgv_generados.CurrentRow.Cells["COD_INSTITUCION2"].Value.ToString();
                plcTo.COD_CANAL_DSCTO = dgv_generados.CurrentRow.Cells["COD_CANAL_DSCTO2"].Value.ToString();
                plcTo.FE_AÑO = AÑO;
                plcTo.FE_MES = MES;
                plcTo.TIPO_PLANILLA_DOC = dgv_generados.CurrentRow.Cells["TIPO_PLANILLA_DOC2"].Value.ToString();
                if (!plcBLL.eliminarPlanillaOtrasDevDsctosBLL(plcTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Se eliminó correctamente la planilla", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DATAGRID();
                    CARGAR_PERSONAS();//para actualizar el grid desplegable
                    //FOCO_NUEVO_REG();
                }
            }
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btn_consulta_Click(object sender, EventArgs e)
        {
            btn_grabar.Visible = false;
            btn_modificar2.Visible = false;
            //txt_ser.Visible = true;
            TabControl1.SelectedTab = (TabPage2);
            LIMPIAR();
            btn_grabar.Enabled = true;
            btn_modificar2.Enabled = true;
            CARGAR_CABECERA_DOCUMENTO();
            CARGAR_DETALLE_DOCUMENTO();
        }
    }
}
