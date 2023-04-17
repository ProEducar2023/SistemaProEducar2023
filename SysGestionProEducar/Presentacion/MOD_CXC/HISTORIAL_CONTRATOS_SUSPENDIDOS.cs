using BLL;
using System;
using System.Data;
using System.Windows.Forms;

namespace Presentacion.MOD_CXC
{
    public partial class HISTORIAL_CONTRATOS_SUSPENDIDOS : Form
    {
        HelpersBLL helBLL = new HelpersBLL();
        DataTable dtSuspendidos;
        public HISTORIAL_CONTRATOS_SUSPENDIDOS(DataTable dtSuspendidos)
        {
            InitializeComponent();
            this.dtSuspendidos = dtSuspendidos;

        }

        private void HISTORIAL_CONTRATOS_SUSPENDIDOS_Load(object sender, EventArgs e)
        {
            if (dtSuspendidos.Rows.Count > 0)
            {
                foreach (DataRow rw in dtSuspendidos.Rows)
                {
                    int rowId = dgw_contratos_suspendidos.Rows.Add();
                    DataGridViewRow row = dgw_contratos_suspendidos.Rows[rowId];
                    row.Cells["FECHA_SUSPENSION"].Value = rw["FECHA_SUSPENSION"].ToString().Substring(0, 10);
                    row.Cells["PERIODOS"].Value = HelpersBLL.OBTENER_PERIODOS_BLL(rw["FECHA_INI_SUS"].ToString(), rw["FECHA_FIN_SUS"].ToString());
                    row.Cells["ST_ANULACION"].Value = rw["ST_ANULACION"].ToString() == "0" ? false : true;
                    row.Cells["OBSERVACIONES"].Value = rw["OBSERVACIONES"].ToString();
                    row.Cells["FECHA_ANULACION"].Value = rw["FECHA_ANULACION"].ToString() != "" ? rw["FECHA_ANULACION"].ToString().Substring(0, 10) : "";
                    row.Cells["DESC_ANULACION"].Value = rw["DESC_ANULACION"].ToString();
                    row.Cells["OBS_ANULACION"].Value = rw["OBS_ANULACION"].ToString();
                }
            }
        }
        private string obtenerPeriodos(string fecha_ini_sus, string fecha_fin_sus)
        {
            string periodos = "";
            periodos = HelpersBLL.OBTENER_NOM_MES(fecha_ini_sus.Substring(3, 2)) + " " + fecha_ini_sus.Substring(6, 4) + "  a  " + HelpersBLL.OBTENER_NOM_MES(fecha_fin_sus.Substring(3, 2)) + " " + fecha_fin_sus.Substring(6, 4);
            return periodos;
        }
    }
}
