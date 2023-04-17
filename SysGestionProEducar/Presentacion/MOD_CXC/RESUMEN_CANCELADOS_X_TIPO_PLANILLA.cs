using System;
using System.Data;
using System.Windows.Forms;

namespace Presentacion.MOD_CXC
{
    public partial class RESUMEN_CANCELADOS_X_TIPO_PLANILLA : Form
    {
        DataTable dtTabla;
        public RESUMEN_CANCELADOS_X_TIPO_PLANILLA(DataTable dtTabla)
        {
            InitializeComponent();
            this.dtTabla = dtTabla;
        }

        private void RESUMEN_CANCELADOS_X_TIPO_PLANILLA_Load(object sender, EventArgs e)
        {
            if (dtTabla.Rows.Count > 0)
            {
                foreach (DataRow rw in dtTabla.Rows)
                {
                    int rowId = DGW_DEV_X_RECLAMO.Rows.Add();
                    DataGridViewRow row = DGW_DEV_X_RECLAMO.Rows[rowId];
                    row.Cells["DESC_TIPO"].Value = rw["DESC_TIPO"].ToString();
                    row.Cells["CantRegistros"].Value = rw["CantRegistros"].ToString();
                    row.Cells["Total"].Value = Convert.ToDecimal(rw["Total"]).ToString("###,###,##0.00");
                }

            }
        }
    }
}
