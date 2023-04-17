using BLL;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;

namespace Presentacion.MOD_CXC
{
    public partial class CONSULTA_DEV_X_RECLAMOS : Form
    {
        canjeTCtasxCobrarBLL ctcBLL = new canjeTCtasxCobrarBLL();
        canjeTCtasxCobrarTo ctcTo = new canjeTCtasxCobrarTo();
        string nro_contrato;
        public CONSULTA_DEV_X_RECLAMOS(string nro_contrato)
        {
            InitializeComponent();
            this.nro_contrato = nro_contrato;
        }

        private void CONSULTA_DEV_X_RECLAMOS_Load(object sender, EventArgs e)
        {
            pDevolucionBLL pdevBLL = new pDevolucionBLL();
            pDevolucionTo pdevTo = new pDevolucionTo();
            pdevTo.NRO_CONTRATO = nro_contrato;
            ctcTo.NRO_CONTRATO = nro_contrato;
            string errMensaje = "";
            decimal monto_pagado = ctcBLL.obtenerMontoPagadoxContratoBLL(ctcTo, ref errMensaje);
            DataTable dt = pdevBLL.obtenerDevxReclamoBLL(pdevTo);
            if (dt.Rows.Count > 0)
            {
                lbl_imp_pagado.Text = monto_pagado.ToString("###,###,##0.00");
                foreach (DataRow rw in dt.Rows)
                {
                    int rowId = DGW_DEV_X_RECLAMO.Rows.Add();
                    DataGridViewRow row = DGW_DEV_X_RECLAMO.Rows[rowId];
                    row.Cells["NRO_PLANILLA_DOC"].Value = rw["NRO_PLANILLA_DOC"].ToString();
                    row.Cells["FECHA_PLANILLA_DOC"].Value = rw["FECHA_PLANILLA_DOC"].ToString().Substring(0, 10);
                    row.Cells["TIPO_PLANILLA_DOC"].Value = rw["TIPO_PLANILLA_DOC"].ToString();
                    row.Cells["IMP_DOC"].Value = Convert.ToDecimal(rw["IMP_DOC"]).ToString("###,###,##0.00");
                    row.Cells["DESC_MOTIVO_OT_DEV"].Value = rw["DESC_MOTIVO_OT_DEV"].ToString();
                    row.Cells["NRO_DOCUMENTO_PAGO"].Value = rw["NRO_DOCUMENTO_PAGO"].ToString();
                    row.Cells["FECHA_PAGO"].Value = rw["FECHA_PAGO"].ToString() != "" ? rw["FECHA_PAGO"].ToString().Substring(0, 10) : "";
                }
            }
        }
    }
}
