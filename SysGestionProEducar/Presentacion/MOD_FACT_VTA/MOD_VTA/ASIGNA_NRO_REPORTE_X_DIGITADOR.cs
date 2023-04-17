using BLL;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;

namespace Presentacion.MOD_FACT_VTA.MOD_VTA
{
    public partial class ASIGNA_NRO_REPORTE_X_DIGITADOR : Form
    {
        personaBLL perBLL = new personaBLL();
        temporal_Nro_ReporteBLL tnrBLL = new temporal_Nro_ReporteBLL();
        temporal_Nro_ReporteTo tnrTo = new temporal_Nro_ReporteTo();
        precontratoCabeceraBLL pccBLL = new precontratoCabeceraBLL();
        precontratoCabeceraTo pccTo = new precontratoCabeceraTo();
        string COD_USU;
        public ASIGNA_NRO_REPORTE_X_DIGITADOR(string COD_USU)
        {
            InitializeComponent();
            this.COD_USU = COD_USU;
        }
        private void ASIGNA_NRO_REPORTE_X_DIGITADOR_Load(object sender, EventArgs e)
        {
            CARGAR_PERSONAS_PERSONAL();
        }
        private void CARGAR_PERSONAS_PERSONAL()
        {
            cboDigitador.Items.Clear();
            personalBLL perBLL = new personalBLL();
            DataTable dt = perBLL.obtenerPersonalparaPreventaBLL();
            cboDigitador.ValueMember = "COD_PER";
            cboDigitador.DisplayMember = "DESC_PER";
            cboDigitador.DataSource = dt;
            cboDigitador.SelectedIndex = -1;
        }

        private void cboDigitador_SelectionChangeCommitted(object sender, EventArgs e)
        {
            tnrTo.cod_per_elab = cboDigitador.SelectedValue.ToString();
            DataTable dt = tnrBLL.obtener_Temporal_Nro_Reporte_x_DigitadorBLL(tnrTo);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow rw in dt.Rows)
                {
                    int idx = dgw_det.Rows.Add();
                    DataGridViewRow row = dgw_det.Rows[idx];
                    row.Cells["NRO_PRESUPUESTO"].Value = rw["NRO_PRESUPUESTO"].ToString();
                    row.Cells["DESC_PER"].Value = rw["DESC_PER"].ToString();
                }
            }
        }

        private void btn_grabar_Click(object sender, EventArgs e)
        {
            if (!validaCombo())
                return;
            DialogResult rs = MessageBox.Show("¿ Esta seguro de Asignar un Numero de Reporte a los Contratos Ingresados ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                string nro_repo = "";
                pccTo.COD_PER_ELAB = cboDigitador.SelectedValue.ToString();
                pccTo.COD_USU = COD_USU;
                pccTo.FECHA_CREA = DateTime.Now;
                if (!pccBLL.proceso_Cerrar_Nro_Reporte_x_DigitadorBLL(pccTo, ref nro_repo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("El Numero de Reporte asignado a los \ncontratos ingresados es : " + nro_repo + " !!!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Dispose();
                }
            }
        }
        private bool validaCombo()
        {
            bool result = true;
            if (cboDigitador.SelectedIndex <= -1)
            {
                MessageBox.Show("Elegir el Digitador !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboDigitador.Focus();
                return result = false;
            }
            if (dgw_det.Rows.Count <= 0)
            {
                MessageBox.Show("No existen contratos para asignar Numero de Reporte !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboDigitador.Focus();
                return result = false;
            }
            return result;
        }

    }
}
