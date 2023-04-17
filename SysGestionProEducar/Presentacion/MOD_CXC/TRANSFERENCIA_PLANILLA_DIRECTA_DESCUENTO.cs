using BLL;
using Entidades;
using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace Presentacion.MOD_CXC
{
    public partial class TRANSFERENCIA_PLANILLA_DIRECTA_DESCUENTO : Form
    {
        planillaDirectaSeguimientoBLL plsBLL = new planillaDirectaSeguimientoBLL();
        planillaDirectaSeguimientoTo plsTo = new planillaDirectaSeguimientoTo();
        devPCtasCobrarBLL devBLL = new devPCtasCobrarBLL();
        devPCtasCobrarTo devTo = new devPCtasCobrarTo();
        cambioTipoPllaHistoricoBLL ctpBLL = new cambioTipoPllaHistoricoBLL();
        cambioTipoPllaHistoricoTo ctpTo = new cambioTipoPllaHistoricoTo();

        string COD_USU;
        public TRANSFERENCIA_PLANILLA_DIRECTA_DESCUENTO(string COD_USU)
        {
            InitializeComponent();
            this.COD_USU = COD_USU;
        }

        private void TRANSFERENCIA_PLANILLA_DIRECTA_DESCUENTO_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            CARGAR_TIPO_PLANILLA();
            CARGAR_AUTORIZADOS();
            CARGAR_MOTIVOS();
            txt_nro_contrato.Focus();
        }
        private void TRANSFERENCIA_PLANILLA_DIRECTA_DESCUENTO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }
        private void CARGAR_AUTORIZADOS()
        {
            directorioBLL dirBLL = new directorioBLL();
            directorioTo dirTo = new directorioTo();
            dirTo.TABLA_COD = "TACP";
            DataTable dt = dirBLL.MOSTRAR_APROBADORES_CAMBIO_PTO_COB_BLL(dirTo);//Obtiene
            if (dt.Rows.Count > 0)
            {
                cboAutorizado.ValueMember = "CODIGO";
                cboAutorizado.DisplayMember = "DESCRIPCION";
                cboAutorizado.DataSource = dt;
                cboAutorizado.SelectedIndex = -1;
            }
        }
        private void CARGAR_MOTIVOS()
        {
            directorioBLL dirBLL = new directorioBLL();
            directorioTo dirTo = new directorioTo();
            dirTo.TABLA_COD = "TMCP";
            DataTable dt = dirBLL.MOSTRAR_APROBADORES_CAMBIO_PTO_COB_BLL(dirTo);//Obtiene
            if (dt.Rows.Count > 0)
            {
                cboMotivo.ValueMember = "CODIGO";
                cboMotivo.DisplayMember = "DESCRIPCION";
                cboMotivo.DataSource = dt;
                cboMotivo.SelectedIndex = -1;
            }
        }

        private void CARGAR_TIPO_PLANILLA()
        {
            tipoPlanillaCreacionBLL tpcBLL = new tipoPlanillaCreacionBLL();
            DataTable dt = tpcBLL.obtenerTipoPlanillaCreacionxTransferenciaBLL();
            DataTable dt1 = tpcBLL.obtenerTipoPlanillaCreacionxTransferenciaBLL();
            if (dt.Rows.Count > 0)
            {
                cbo_tipo_planilla.ValueMember = "COD_TIPO_PLLA";
                cbo_tipo_planilla.DisplayMember = "DESC_TIPO";
                cbo_tipo_planilla.DataSource = dt;
                cbo_tipo_planilla.SelectedValue.ToString();
                //
                cbo_trans_dev.ValueMember = "COD_TIPO_PLLA";
                cbo_trans_dev.DisplayMember = "DESC_TIPO";
                cbo_trans_dev.DataSource = dt1;
                cbo_trans_dev.SelectedValue.ToString();
            }
        }

        private void txt_nro_contrato_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_nro_contrato.Text = txt_nro_contrato.Text.PadLeft(7, '0');
                MostrarCuotasTranferir();
                cbo_tipo_planilla.Focus();
                lblnro.Text = DGW_DETALLE.Rows.Count.ToString();
            }
        }
        private void MostrarCuotasTranferir()
        {
            canjePCtasxCobrarBLL pctasBLL = new canjePCtasxCobrarBLL();
            canjePCtasxCobrarTo pctasTo = new canjePCtasxCobrarTo();
            pctasTo.NRO_CONTRATO = txt_nro_contrato.Text;
            DataTable dt = pctasBLL.obtener_PCtasCobrar_por_NroContrato_para_TransferenciaBLL(pctasTo);
            ctpTo.NRO_CONTRATO = pctasTo.NRO_CONTRATO;
            lblNroUbi.Text = ctpBLL.obtenerNroCambioTipoPllaHistoricoBLL(ctpTo);

            if (dt.Rows.Count > 0)
            {
                lblFechaContrato.Text = Convert.ToDateTime(dt.Rows[0]["FECHA_PRE"]).ToShortDateString();
                lblFechaAprob.Text = Convert.ToDateTime(dt.Rows[0]["FECHA_APROB"]).ToShortDateString();
                lblPtoCobranza.Text = Convert.ToString(dt.Rows[0]["DESC_PTO_COB"]);
                lblUbicacion.Text = Convert.ToString(dt.Rows[0]["DESC_TIPO"]);
                DGW_DETALLE.Rows.Clear();
                foreach (DataRow rw in dt.Rows)
                {
                    int rowId = DGW_DETALLE.Rows.Add();
                    DataGridViewRow row = DGW_DETALLE.Rows[rowId];
                    row.Cells["NRO_CONTRATO"].Value = rw["NRO_CONTRATO"].ToString();
                    row.Cells["COD_PER"].Value = rw["COD_PER"].ToString();
                    row.Cells["DESC_PER"].Value = rw["DESC_PER"].ToString();
                    row.Cells["LETRA"].Value = rw["LETRA"].ToString();
                    row.Cells["FECHA_VEN"].Value = rw["FECHA_VEN"].ToString().Substring(0, 10);
                    row.Cells["TIPO_PLA_COBRANZA"].Value = rw["TIPO_PLA_COBRANZA"].ToString();
                    //row.Cells["DESC_TIPO"].Value = rw["DESC_TIPO"].ToString();
                    row.Cells["IMP_INI"].Value = rw["IMP_INI"].ToString();
                    //row.Cells["STATUS_GENERADO"].Value = Convert.ToBoolean(rw["STATUS_GENERADO"]);
                    //if(!Convert.ToBoolean(row.Cells["STATUS_GENERADO"].Value))
                    //{
                    //    DGW_DETALLE.CurrentCell = DGW_DETALLE.CurrentRow.Cells["OP"];
                    //    DGW_DETALLE.BeginEdit(true);
                    //}
                }
                chk_todos.Checked = true;
                checkearTodos();
            }
            else
            {
                MessageBox.Show("El contrato " + txt_nro_contrato.Text + " no se encontró o no existe !", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            if (!validaTransferir())
                return;
            DialogResult rs = MessageBox.Show("¿ Esta seguro de hacer el cambio de Ubicacion ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                StringBuilder sb = new StringBuilder();
                string cuotas_cambiadas;
                plsTo.TIPO_PLA_COBRANZA = cbo_tipo_planilla.SelectedValue.ToString();
                //plsTo.TIPO_PLA_DESTINO = cbo_tipo_planilla.SelectedValue.ToString();
                plsTo.OBS_LLAMADA_LL = cbo_tipo_planilla.SelectedValue.ToString() == "D" ? "Transferencia de Planilla a Directa" : "Transferencia de Directa a Planilla";
                plsTo.COD_USU_MOD = COD_USU;
                plsTo.FECHA_MOD = DateTime.Now;
                //para cambio de planilla historico
                plsTo.NRO_CONTRATO = txt_nro_contrato.Text.Trim();
                plsTo.FECHA_CAMBIO = dtp_fec_cam.Value;
                plsTo.TIPO_PLA_DESTINO = Convert.ToString(cbo_tipo_planilla.SelectedValue);
                plsTo.COD_MOTIVO = Convert.ToString(cboMotivo.SelectedValue);
                plsTo.COD_AUTORIZADOR = Convert.ToString(cboAutorizado.SelectedValue);
                plsTo.OBSERVACIONES = txtObservaciones.Text.Trim();
                DataTable dtDetalle = HelpersBLL.obtenerDTX(DGW_DETALLE);
                for (int i = 0; i < dtDetalle.Rows.Count; i++)
                {
                    if (i != dtDetalle.Rows.Count - 1)
                        sb.Append(Convert.ToString(dtDetalle.Rows[i]["LETRA"]).Substring(0, 3) + ", ");
                    else
                        sb.Append(Convert.ToString(dtDetalle.Rows[i]["LETRA"]).Substring(0, 3) + ".");
                }
                cuotas_cambiadas = Convert.ToString(sb);
                plsTo.CUOTAS_CAMBIADAS = cuotas_cambiadas;
                if (!plsBLL.Grabar_Transferencia_CtasBLL(plsTo, dtDetalle, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("El cambio de ubicacion se realizó correctamente !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    int i = DGW_DETALLE.CurrentRow.Index;
                    MostrarCuotasTranferir();
                    DGW_DETALLE.CurrentCell = DGW_DETALLE[0, i];
                    dtp_fec_cam.Value = plsTo.FECHA_CAMBIO.AddMinutes(1);
                }
            }
        }
        private bool validaTransferir()
        {
            bool result = true;
            if (DGW_DETALLE.Rows.Count <= 0)
            {
                MessageBox.Show("No existen registros !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return result = false;
            }
            if (txt_nro_contrato.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el Nro de Contrato !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_nro_contrato.Focus();
                return result = false;
            }
            if (cbo_tipo_planilla.SelectedIndex < 0)
            {
                MessageBox.Show("ELija el Cambio !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_tipo_planilla.Focus();
                return result = false;
            }
            if (cboMotivo.SelectedIndex < 0)
            {
                MessageBox.Show("Elija el Motivo !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboMotivo.Focus();
                return result = false;
            }
            if (cboAutorizado.SelectedIndex < 0)
            {
                MessageBox.Show("Elija Autorizado por !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboAutorizado.Focus();
                return result = false;
            }
            if (Convert.ToString(cbo_tipo_planilla.SelectedValue) == Convert.ToString(DGW_DETALLE.Rows[0].Cells["TIPO_PLA_COBRANZA"].Value))
            {
                MessageBox.Show("Debe elegir otra Ubicacion !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_tipo_planilla.Focus();
                return result = false;
            }
            var query = from DataGridViewRow row in DGW_DETALLE.Rows
                        where (Convert.ToBoolean(row.Cells["OP"].Value) == true)
                        select row;
            if (query.Count() == 0)
            {
                MessageBox.Show("Elija alguna cuota !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return result = false;
            }

            return result;
        }

        private void chk_todos_CheckedChanged(object sender, EventArgs e)
        {
            checkearTodos();
        }
        private void checkearTodos()
        {
            foreach (DataGridViewRow row in DGW_DETALLE.Rows)
                row.Cells["OP"].Value = chk_todos.Checked;
        }
        private void txt_nro_contrato_Leave(object sender, EventArgs e)
        {
            txt_nro_contrato.Text = txt_nro_contrato.Text.PadLeft(7, '0');
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txt_nro_contrato_dev_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_nro_contrato_dev.Text = txt_nro_contrato_dev.Text.PadLeft(7, '0');
                MostrarCuotasTranferirDevolucion();
                cbo_trans_dev.Focus();
                lbl_nro_dev.Text = dgv_detalle_dev.Rows.Count.ToString();
            }
        }

        private void txt_nro_contrato_dev_Leave(object sender, EventArgs e)
        {
            //txt_nro_contrato_dev.Text = txt_nro_contrato_dev.Text.PadLeft(7, '0');
        }
        private void MostrarCuotasTranferirDevolucion()
        {

            devTo.NRO_CONTRATO = txt_nro_contrato_dev.Text.Trim() == "" ? "0000000" : txt_nro_contrato_dev.Text;
            devTo.DESC_PER = txt_nomclie_dev.Text.Trim() == "" ? "0000000" : txt_nomclie_dev.Text;
            DataTable dt = devBLL.obtenerDevPCtasCobrarTransferenciaBLL(devTo);
            if (dt.Rows.Count > 0)
            {
                dgv_detalle_dev.Rows.Clear();
                foreach (DataRow rw in dt.Rows)
                {
                    int rowId = dgv_detalle_dev.Rows.Add();
                    DataGridViewRow row = dgv_detalle_dev.Rows[rowId];
                    row.Cells["NRO_PLANILLA_COB_DEV"].Value = rw["NRO_PLANILLA_COB"].ToString();
                    row.Cells["COD_SUCURSAL_DEV"].Value = rw["COD_SUCURSAL"].ToString();
                    row.Cells["COD_CLASE_DEV"].Value = rw["COD_CLASE"].ToString();
                    row.Cells["NRO_CONTRATO_DEV"].Value = rw["NRO_CONTRATO"].ToString();
                    row.Cells["FE_AÑO_DEV"].Value = rw["FE_AÑO"].ToString();
                    row.Cells["FE_MES_DEV"].Value = rw["FE_MES"].ToString();
                    row.Cells["COD_D_H_DEV"].Value = rw["COD_D_H"].ToString();
                    row.Cells["NRO_LETRA_DEV"].Value = rw["NRO_LETRA"].ToString();
                    row.Cells["DESC_PER_DEV"].Value = rw["DESC_PER"].ToString();
                    row.Cells["IMP_DOC_DEV"].Value = rw["IMP_DOC"].ToString();
                    row.Cells["DESCRIPCION_DEV"].Value = rw["DESCRIPCION"].ToString();
                    row.Cells["TIPO_PLA_COBRANZA_DEV"].Value = rw["TIPO_PLA_COBRANZA"].ToString();
                }
            }
        }

        private void btn_trans_dev_Click(object sender, EventArgs e)
        {
            if (!validaTransferirDevoluciones())
                return;
            DialogResult rs = MessageBox.Show("¿ Esta seguro de hacer el cambio ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";

                devTo.TIPO_PLA_COBRANZA = cbo_trans_dev.SelectedValue.ToString();
                devTo.COD_USU_MOD = COD_USU;
                devTo.FECHA_MOD = DateTime.Now;
                DataTable dtDetalle = HelpersBLL.obtenerDTX(dgv_detalle_dev);
                if (!devBLL.Grabar_Transferencia_DevolucionesBLL(devTo, dtDetalle, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Se hizo el cambio correctamente !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    int i = dgv_detalle_dev.CurrentRow.Index;
                    MostrarCuotasTranferirDevolucion();
                    dgv_detalle_dev.CurrentCell = dgv_detalle_dev[0, i];
                }
            }
        }
        private bool validaTransferirDevoluciones()
        {
            bool result = true;
            if (dgv_detalle_dev.Rows.Count <= 0)
            {
                MessageBox.Show("No existen registros !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return result = false;
            }
            if (txt_nro_contrato_dev.Text.Trim() == "" && txt_nomclie_dev.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el Nro de Contrato ó el Nombre de la Persona !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_nro_contrato_dev.Focus();
                return result = false;
            }
            if (cbo_trans_dev.SelectedIndex < 0)
            {
                MessageBox.Show("ELija el Cambio !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_trans_dev.Focus();
                return result = false;
            }

            return result;
        }
        private void txt_nomclie_dev_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //txt_nomclie_dev.Text = txt_nro_contrato_dev.Text.PadLeft(7, '0');
                MostrarCuotasTranferirDevolucion();
                cbo_trans_dev.Focus();
                lbl_nro_dev.Text = dgv_detalle_dev.Rows.Count.ToString();
            }
        }

        private void txt_nomclie_dev_Leave(object sender, EventArgs e)
        {

        }

        private void chk_todos_dev_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgv_detalle_dev.Rows)
                row.Cells["OP_DEV"].Value = chk_todos_dev.Checked;
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            MOD_CXC.HISTORIAL_TRANSFERENCIA_TIPO_PLANILLA frm = new HISTORIAL_TRANSFERENCIA_TIPO_PLANILLA(txt_nro_contrato.Text);
            frm.ShowDialog();


        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click_1(object sender, EventArgs e)
        {

        }

    }

}
