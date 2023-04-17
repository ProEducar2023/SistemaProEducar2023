using BLL;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;

namespace Presentacion.MOD_CXC
{
    public partial class I_LLAMADAS_VERIFICACION : Form
    {
        calendarioBLL calBLL = new calendarioBLL();
        calendarioTo calTo = new calendarioTo();
        string AÑO, MES, COD_MOD, TIPO_USU, COD_USU;
        DateTime FECHA_INI, FECHA_GRAL;
        descuentoDirectaSeguimientoBLL ddsBLL = new descuentoDirectaSeguimientoBLL();
        descuentoDirectaSeguimientoTo ddsTo = new descuentoDirectaSeguimientoTo();
        DateTime? fec_com_pago = null; string observaciones = "";
        string nro_contrato; string cod_persona; string cod_gestor; string cod_motivo_llamada;
        DateTime fecha_operacion_llamada; DateTime? fecha_compromiso_pago; string observacion; decimal importe_pago;
        DateTime? fecha_deposito; string nro_operacion; string institucion_bancaria; string cod_usu;
        frm_IngresoVerificacion frm;
        public I_LLAMADAS_VERIFICACION(string AÑO, string MES, DateTime FECHA_INI, DateTime FECHA_GRAL, string COD_MOD, string TIPO_USU, string COD_USU)
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

        private void I_LLAMADAS_VERIFICACION_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            calTo.TIPO = "D";
            lbl_fec_llamada.Text = Convert.ToDateTime(calBLL.obtenerFechaActivaBLL(calTo)).ToShortDateString();
            CARGAR_GRID();
        }
        private void CARGAR_GRID()
        {
            ddsTo.COD_MOTIVO_LLAMADA = "03";
            DataTable dt = ddsBLL.obtenerContratosparaVerificarLlamadasBLL(ddsTo);
            if (dt.Rows.Count > 0)
            {
                dgw_llamadas.Rows.Clear();
                foreach (DataRow rw in dt.Rows)
                {
                    int rowId = dgw_llamadas.Rows.Add();
                    DataGridViewRow row = dgw_llamadas.Rows[rowId];
                    row.Cells["NRO_CONTRATO"].Value = rw["NRO_CONTRATO"].ToString();
                    row.Cells["COD_PERSONA"].Value = rw["COD_PERSONA"].ToString();
                    row.Cells["CLIENTE"].Value = rw["CLIENTE"].ToString();
                    row.Cells["DNI"].Value = rw["DNI"].ToString();
                    row.Cells["COD_GESTOR"].Value = rw["COD_GESTOR"].ToString();
                    row.Cells["GESTOR"].Value = rw["GESTOR"].ToString();
                    row.Cells["OBSERVACIONES"].Value = rw["OBSERVACIONES"].ToString();
                    row.Cells["IMPORTE_PAGO"].Value = rw["IMPORTE_PAGO"].ToString();
                    row.Cells["FECHA_DEPOSITO"].Value = rw["FECHA_DEPOSITO"].ToString().Substring(0, 10);
                    row.Cells["NRO_OPERACION"].Value = rw["NRO_OPERACION"].ToString();
                    row.Cells["INSTITUCION_BANCARIA"].Value = rw["INSTITUCION_BANCARIA"].ToString();
                    row.Cells["BANCO"].Value = rw["BANCO"].ToString();
                }
            }
        }

        private void dgw_llamadas_Click(object sender, EventArgs e)
        {
            muestra_observaciones();
        }

        private void dgw_llamadas_SelectionChanged(object sender, EventArgs e)
        {
            muestra_observaciones();
        }
        private void muestra_observaciones()
        {
            txt_gestor.Clear();
            txt_observaciones.Clear();
            if (dgw_llamadas.Rows.Count > 0)
            {
                if (dgw_llamadas.CurrentRow.Cells["NRO_CONTRATO"].Value != null)
                {
                    txt_gestor.Text = dgw_llamadas.CurrentRow.Cells["GESTOR"].Value.ToString();
                    txt_observaciones.Text = dgw_llamadas.CurrentRow.Cells["OBSERVACIONES"].Value.ToString();
                }
            }
        }

        private void dgw_llamadas_DoubleClick(object sender, EventArgs e)
        {
            if (dgw_llamadas.CurrentRow != null)
            {
                DateTime fec_operacion_llamada = Convert.ToDateTime(lbl_fec_llamada.Text);

                nro_contrato = dgw_llamadas.CurrentRow.Cells["NRO_CONTRATO"].Value.ToString();
                cod_persona = dgw_llamadas.CurrentRow.Cells["COD_PERSONA"].Value.ToString();
                cod_gestor = dgw_llamadas.CurrentRow.Cells["COD_GESTOR"].Value.ToString();// == "" ? cbo_gestor.SelectedValue.ToString() : dgw_llamadas.CurrentRow.Cells["COD_GESTOR"].Value.ToString();
                cod_motivo_llamada = "03";// dgw_llamadas.CurrentRow.Cells["COD_MOTIVO"].Value.ToString();
                fecha_operacion_llamada = Convert.ToDateTime(lbl_fec_llamada.Text);// dgw_llamadas.CurrentRow.Cells["FECHA_OPERACION_LLAMADA"].Value.ToString() != "" ? Convert.ToDateTime(Convert.ToDateTime(dgw_llamadas.CurrentRow.Cells["FECHA_OPERACION_LLAMADA"].Value)) : fec_operacion_llamada;

                cod_usu = COD_USU; //dgw_llamadas.CurrentRow.Cells["COD_USU2"].Value.ToString();
                frm = new frm_IngresoVerificacion(nro_contrato, cod_persona, cod_gestor, cod_motivo_llamada,
                    fecha_operacion_llamada, cod_usu, AÑO, MES);
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    dgw_llamadas.Rows.RemoveAt(dgw_llamadas.CurrentRow.Index);
                    //dgw_llamadas.CurrentRow.Cells["COD_MOTIVO"].Value = frm.cbo_motivo.SelectedValue.ToString();
                    //dgw_llamadas.CurrentRow.Cells["DESC_MOTIVO"].Value = frm.cbo_motivo.Text;
                    //dgw_llamadas.CurrentRow.Cells["FECHA_COMPROMISO_PAGO"].Value = frm.dtp_fec_com_pago.Value.ToShortDateString();
                    //dgw_llamadas.CurrentRow.Cells["OBSERVACIONES2"].Value = frm.txt_observaciones.Text;
                    //dgw_llamadas.CurrentRow.Cells["IMPORTE_PAGO"].Value = frm.txt_imp_pago.Text;
                    //dgw_llamadas.CurrentRow.Cells["NRO_OPERACIONES"].Value = frm.txt_nro_operacion.Text;
                    //dgw_llamadas.CurrentRow.Cells["FECHA_DEPOSITO"].Value = frm.dtp_fec_deposito.Value.ToShortDateString();
                    //dgw_llamadas.CurrentRow.Cells["INSTITUCION_BANCARIA"].Value = frm.cbo_banco.SelectedValue != null ? frm.cbo_banco.SelectedValue.ToString() : "";
                }
            }
        }

        private void lbl_datos_cliente_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string cod_per = dgw_llamadas.CurrentRow.Cells["COD_PERSONA"].Value.ToString();
            MOD_ADM.PERSONA frm = new MOD_ADM.PERSONA(2, cod_per);
            frm.ShowDialog();
        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
