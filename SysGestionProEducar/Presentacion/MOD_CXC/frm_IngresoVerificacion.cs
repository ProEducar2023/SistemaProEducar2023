using BLL;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;

namespace Presentacion.MOD_CXC
{
    public partial class frm_IngresoVerificacion : Form
    {
        string nro_contrato; string cod_persona; string cod_gestor; string cod_motivo_llamada;
        DateTime fecha_operacion_llamada; string cod_usu; string AÑO; string MES;
        descuentoDirectaSeguimientoBLL ddsBLL = new descuentoDirectaSeguimientoBLL();
        descuentoDirectaSeguimientoTo ddsTo = new descuentoDirectaSeguimientoTo();
        descuentoDirectoBLL ddBLL = new descuentoDirectoBLL();
        public frm_IngresoVerificacion(string nro_contrato, string cod_persona, string cod_gestor, string cod_motivo_llamada,
            DateTime fecha_operacion_llamada, string cod_usu, string AÑO, string MES)
        {
            InitializeComponent();
            this.nro_contrato = nro_contrato;
            this.cod_persona = cod_persona;
            this.cod_gestor = cod_gestor;
            this.cod_motivo_llamada = cod_motivo_llamada;
            this.fecha_operacion_llamada = fecha_operacion_llamada;
            //this.fecha_compromiso_pago = fecha_compromiso_pago;
            //this.observacion = observacion;
            //this.importe_pago = importe_pago;
            //this.fecha_deposito = fecha_deposito;
            //this.nro_operacion = nro_operacion;
            //this.institucion_bancaria = institucion_bancaria;
            this.cod_usu = cod_usu;
            this.AÑO = AÑO;
            this.MES = MES;
        }

        private void frm_IngresoVerificacion_Load(object sender, EventArgs e)
        {
            CARGAR_BANCO();
            CARGAR_MOTIVO_LLAMADAS();
            //CARGAR_DATOS();
        }
        private void CARGAR_BANCO()
        {
            cobranzaDirectaBLL codBLL = new cobranzaDirectaBLL();
            cobranzaDirectaTo codTo = new cobranzaDirectaTo();
            DataTable dt = codBLL.MOSTRAR_CUENTA_BANCO_BLL();
            if (dt.Rows.Count > 0)
            {
                cbo_banco.DataSource = dt;
                cbo_banco.DisplayMember = "DESCRIPCION";
                cbo_banco.ValueMember = "COD_BANCO";
                cbo_banco.SelectedIndex = -1;
            }
        }
        private void CARGAR_MOTIVO_LLAMADAS()
        {
            motivoLlamadasDescCobDirBLL mlBLL = new motivoLlamadasDescCobDirBLL();
            motivoLlamadasDescCobDirTo mlTo = new motivoLlamadasDescCobDirTo();
            mlTo.CATEGORIA = "2";//motivos para las verificaciones
            DataTable dtMotivo = mlBLL.obtenerMotivoLlamadasDescCobDirBLL(mlTo);
            if (dtMotivo.Rows.Count > 0)
            {
                cbo_motivo.DataSource = dtMotivo;
                cbo_motivo.DisplayMember = "DESC_MOTIVO";
                cbo_motivo.ValueMember = "COD_MOTIVO";
                cbo_motivo.SelectedIndex = -1;
            }
        }

        private void frm_IngresoVerificacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void btn_grabar_Click(object sender, EventArgs e)
        {
            if (!valida())
                return;

            DialogResult rs = MessageBox.Show("¿ Está seguro de grabar este registro con el contrato " + nro_contrato + " ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                //int idx = dgw_llamadas.CurrentRow.Index;
                ddsTo.NRO_CONTRATO = nro_contrato;//dgw_llamadas.CurrentRow.Cells["NRO_CONTRATO"].Value.ToString();
                ddsTo.COD_PERSONA = cod_persona;//dgw_llamadas.CurrentRow.Cells["COD_PERSONA"].Value.ToString();
                ddsTo.COD_GESTOR = cod_gestor;//cbo_gestor.SelectedValue.ToString();
                ddsTo.COD_MOTIVO_LLAMADA = cbo_motivo.SelectedValue.ToString();//dgw_llamadas.CurrentRow.Cells["COD_MOTIVO"].Value.ToString();
                ddsTo.FECHA_OPERACION_LLAMADA = fecha_operacion_llamada;//Convert.ToDateTime(lbl_fec_llamada.Text);
                ddsTo.FE_AÑO = AÑO;
                ddsTo.FE_MES = MES;
                ddsTo.FECHA_COMPROMISO_PAGO = dtp_fec_com_pago.Value;//fec_com_pago;
                ddsTo.OBSERVACIONES = txt_observaciones.Text;//observaciones;
                ddsTo.IMPORTE_PAGO = txt_imp_pago.Text.Trim() == "" ? 0 : Convert.ToDecimal(txt_imp_pago.Text);//imp_pago;
                ddsTo.STATUS_CONFIRMACION_PAGO = "1";
                ddsTo.FECHA_DEPOSITO = chk_fec_deposito.Checked ? dtp_fec_deposito.Value : (DateTime?)null;//fec_deposito;
                ddsTo.NRO_OPERACION = txt_nro_operacion.Text;//nro_operacion;
                ddsTo.INSTITUCION_BANCARIA = cbo_banco.Enabled == true ? cbo_banco.SelectedValue.ToString() : "";
                ddsTo.COD_USU = cod_usu;
                ddsTo.FEC_COD_USU = DateTime.Now;
                ddsTo.COD_MOTIVO_LLAMADA_ORIGEN = cod_motivo_llamada;
                if (!ddsBLL.adicionaDatosparaValidacionLLamadasBLL(ddsTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Se grabó correctamente !!!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Hide();
                }
            }
        }
        private bool valida()
        {
            bool result = true;
            string errMensaje = "";
            if (cbo_motivo.SelectedIndex == -1)
            {
                MessageBox.Show("Elija el motivo !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_motivo.Focus();
                return result = false;
            }
            if (ddBLL.esFeriado(dtp_fec_com_pago.Value, ref errMensaje))
            {
                MessageBox.Show("El día elegido es feriado !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_motivo.Focus();
                return result = false;
            }
            if (cbo_motivo.SelectedValue.ToString() == "06")
            {
                if (fecha_operacion_llamada >= dtp_fec_com_pago.Value)
                {
                    MessageBox.Show("Fecha incorrecta !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cbo_motivo.Focus();
                    return result = false;
                }
            }
            else
            {
                if (fecha_operacion_llamada > dtp_fec_com_pago.Value)
                {
                    MessageBox.Show("Fecha incorrecta !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cbo_motivo.Focus();
                    return result = false;
                }
            }
            if (txt_observaciones.Text == "")
            {
                MessageBox.Show("Ingrese observaciones !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_observaciones.Focus();
                return result = false;
            }
            if (cbo_motivo.SelectedValue.ToString() == "05" || cbo_motivo.SelectedValue.ToString() == "07")//Confirmacion de pago
            {
                if (txt_imp_pago.Text == "")
                {
                    MessageBox.Show("Ingrese el importe !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txt_imp_pago.Focus();
                    return result = false;
                }
                decimal d = 0;
                if (!decimal.TryParse(txt_imp_pago.Text, out d))
                {
                    MessageBox.Show("Ingrese un número valido !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txt_imp_pago.Focus();
                    return result = false;
                }
                if (fecha_operacion_llamada > dtp_fec_deposito.Value)
                {
                    MessageBox.Show("Fecha incorrecta !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txt_imp_pago.Focus();
                }
                if (txt_nro_operacion.Text == "")
                {
                    MessageBox.Show("Ingrese numero de operacion !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txt_nro_operacion.Focus();
                    return result = false;
                }
                if (cbo_banco.SelectedIndex == -1)
                {
                    MessageBox.Show("Elija el Banco !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cbo_banco.Focus();
                    return result = false;
                }
            }
            return result;
        }

        private void cbo_motivo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_motivo.SelectedValue != null)
            {
                if (cbo_motivo.SelectedValue.ToString() == "05" || cbo_motivo.SelectedValue.ToString() == "07")//Abonado ó Abonado con Modificacion
                    habilita_controles(true);
                else
                    habilita_controles(false);
            }
        }
        private void habilita_controles(bool val)
        {
            txt_imp_pago.Clear();
            txt_imp_pago.Enabled = val;
            chk_fec_deposito.Checked = val;
            chk_fec_deposito.Enabled = val;
            dtp_fec_deposito.Enabled = val;
            txt_nro_operacion.Clear();
            txt_nro_operacion.Enabled = val;
            cbo_banco.SelectedIndex = -1;
            cbo_banco.Enabled = val;
        }

        private void dtp_fec_com_pago_ValueChanged(object sender, EventArgs e)
        {
            string errMensaje = "";
            if (ddBLL.esFeriado(dtp_fec_com_pago.Value, ref errMensaje))
            {
                MessageBox.Show("El día elegido es feriado !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_motivo.Focus();
            }
            if (cbo_motivo.SelectedValue.ToString() == "06")//No Abonado
            {
                if (fecha_operacion_llamada >= dtp_fec_com_pago.Value)
                {
                    MessageBox.Show("Fecha incorrecta !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cbo_motivo.Focus();
                }
            }
            else
            {
                if (fecha_operacion_llamada > dtp_fec_com_pago.Value)
                {
                    MessageBox.Show("Fecha incorrecta !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cbo_motivo.Focus();
                }
            }
        }

        private void dtp_fec_deposito_ValueChanged(object sender, EventArgs e)
        {
            if (fecha_operacion_llamada > dtp_fec_deposito.Value)
            {
                MessageBox.Show("Fecha incorrecta !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_imp_pago.Focus();
            }
        }
    }
}
