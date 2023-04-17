using BLL;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;

namespace Presentacion.MOD_CXC
{
    public partial class HISTORIAL_TRANSFERENCIA_TIPO_PLANILLA : Form
    {
        cambioTipoPllaHistoricoBLL ctpBLL = new cambioTipoPllaHistoricoBLL();
        cambioTipoPllaHistoricoTo ctpTo = new cambioTipoPllaHistoricoTo();
        string nro_contrato;
        public HISTORIAL_TRANSFERENCIA_TIPO_PLANILLA(string nro_contrato)
        {
            InitializeComponent();
            this.nro_contrato = nro_contrato;
        }

        private void HISTORIAL_TRANSFERENCIA_TIPO_PLANILLA_Load(object sender, EventArgs e)
        {
            txt_nro_contrato.Text = nro_contrato;
            ctpTo.NRO_CONTRATO = nro_contrato;
            DataTable dt = ctpBLL.obtenerCambioTipoPllaHistoricoBLL(ctpTo);
            lbl_nro_reg_docs.Text = "Nro de Registros : 0";
            if (dt.Rows.Count > 0)
            {
                dgwHistorial.Rows.Clear();
                lbl_nro_reg_docs.Text = "Nro de Registros : " + dt.Rows.Count.ToString();
                foreach (DataRow rw in dt.Rows)
                {
                    int rowId = dgwHistorial.Rows.Add();
                    DataGridViewRow row = dgwHistorial.Rows[rowId];
                    row.Cells["FECHA_CAMBIO"].Value = Convert.ToDateTime(rw["FECHA_CAMBIO"]).ToShortDateString();
                    row.Cells["TIPO_PLANILLA_CAMBIADA"].Value = Convert.ToString(rw["TIPO_PLANILLA_CAMBIADA"]);
                    row.Cells["COD_MOTIVO"].Value = Convert.ToString(rw["COD_MOTIVO"]);
                    row.Cells["DESC_MOTIVO"].Value = Convert.ToString(rw["DESC_MOTIVO"]);
                    row.Cells["COD_AUTORIZADOR"].Value = Convert.ToString(rw["COD_AUTORIZADOR"]);
                    row.Cells["DESC_AUTORIZADOR"].Value = Convert.ToString(rw["DESC_AUTORIZADOR"]);
                    row.Cells["CUOTAS_CAMBIADAS"].Value = Convert.ToString(rw["CUOTAS_CAMBIADAS"]);
                    row.Cells["OBSERVACIONES"].Value = Convert.ToString(rw["OBSERVACIONES"]);
                }
            }
        }
    }
}
