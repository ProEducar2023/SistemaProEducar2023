using BLL;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;

namespace Presentacion.MOD_CXC
{
    public partial class CONSULTA_EXCESO_CONTRATO : Form
    {
        string nro_contrato;
        public CONSULTA_EXCESO_CONTRATO(string nro_contrato)
        {
            InitializeComponent();
            this.nro_contrato = nro_contrato;
        }

        private void CONSULTA_EXCESO_CONTRATO_Load(object sender, EventArgs e)
        {
            pDevolucionBLL pdevBLL = new pDevolucionBLL();
            pDevolucionTo pdevTo = new pDevolucionTo();
            pdevTo.NRO_CONTRATO = nro_contrato;
            DataTable dt = pdevBLL.obtenerDevxExcesoContratoBLL(pdevTo);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow rw in dt.Rows)
                {
                    int rowId = DGW_EXCESO_DEVOLUCION.Rows.Add();
                    DataGridViewRow row = DGW_EXCESO_DEVOLUCION.Rows[rowId];
                    row.Cells["NRO_PLANILLA_COB"].Value = rw["NRO_PLANILLA_COB"].ToString();
                    row.Cells["FECHA_PLANILLA_COB"].Value = rw["FECHA_PLANILLA_COB"].ToString().Substring(0, 10);
                    row.Cells["IMP_INI"].Value = Convert.ToDecimal(rw["IMP_INI"]).ToString("###,###,##0.00");
                }
            }
        }

    }
}
