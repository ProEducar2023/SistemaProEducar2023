using BLL;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;
namespace Presentacion.MOD_COMISIONES
{
    public partial class ADELANTO_COMISIONES_X_COMISIONISTA : Form
    {
        string AÑO = "", MES = "", COD_MOD = "", COD_USU = "", TIPO_USU = "", AÑO1 = "", MES1 = "";
        DateTime FECHA_INI, FECHA_GRAL;
        DataTable dtAdelantoLiq;
        pLiqAdelantoBLL lqaBLL = new pLiqAdelantoBLL();
        pLiqAdelantoTo lqaTo = new pLiqAdelantoTo();
        public ADELANTO_COMISIONES_X_COMISIONISTA(string AÑO, string MES, DateTime FECHA_INI, DateTime FECHA_GRAL, string COD_MOD, string TIPO_USU, string COD_USU)
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

        private void ADELANTO_COMISIONES_X_COMISIONISTA_Load(object sender, EventArgs e)
        {
            CARGAR_ADELANTO_DEL_PERIODO();
            CARGAR_ADELANTO_PENDIENTES();
        }

        private void ADELANTO_COMISIONES_X_COMISIONISTA_KeyDown(object sender, KeyEventArgs e)
        {

        }
        private void CARGAR_ADELANTO_DEL_PERIODO()
        {
            pLiqAdelantoBLL lqaBLL = new pLiqAdelantoBLL();
            pLiqAdelantoTo lqaTo = new pLiqAdelantoTo();
            lqaTo.FE_AÑO = AÑO;
            lqaTo.FE_MES = MES;
            dtAdelantoLiq = lqaBLL.obtenerPLiqAdelantoBLL(lqaTo);
            dgw2.Rows.Clear();
            if (dtAdelantoLiq.Rows.Count > 0)
            {
                foreach (DataRow rw in dtAdelantoLiq.Rows)
                {
                    int rowId = dgw2.Rows.Add();
                    DataGridViewRow row = dgw2.Rows[rowId];
                    row.Cells["FE_AÑO1"].Value = rw["FE_AÑO"].ToString();
                    row.Cells["FE_MES1"].Value = rw["FE_MES"].ToString();
                    row.Cells["COD_PER1"].Value = rw["COD_PER"].ToString();
                    row.Cells["DESC_PER1"].Value = rw["DESC_PER"].ToString();
                    row.Cells["COD_DOC1"].Value = rw["COD_DOC"].ToString();
                    row.Cells["NRO_DOC1"].Value = rw["NRO_DOC"].ToString();
                    row.Cells["FECHA_DOC1"].Value = rw["FECHA_DOC"].ToString().Substring(0, 10);
                    row.Cells["IMP_DOC1"].Value = rw["IMP_DOC"].ToString();
                    row.Cells["OBSERVACION1"].Value = rw["OBSERVACION"].ToString();
                    row.Cells["COD_SUCURSAL1"].Value = rw["COD_SUCURSAL"].ToString();
                    row.Cells["COD_MONEDA1"].Value = rw["COD_MONEDA"].ToString();
                }
            }
        }
        private void CARGAR_ADELANTO_PENDIENTES()
        {
            pAdelantoBLL padeBLL = new pAdelantoBLL();
            DataTable dt = padeBLL.obtenerP_AdelantoBLL();
            dgw1.Rows.Clear();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow rw in dt.Rows)
                {
                    int rowId = dgw1.Rows.Add();
                    DataGridViewRow row = dgw1.Rows[rowId];
                    row.Cells["FE_AÑO"].Value = rw["FE_AÑO"].ToString();
                    row.Cells["FE_MES"].Value = rw["FE_MES"].ToString();
                    row.Cells["COD_PER"].Value = rw["COD_PER"].ToString();
                    row.Cells["DESC_PER"].Value = rw["DESC_PER"].ToString();
                    row.Cells["COD_DOC"].Value = rw["COD_DOC"].ToString();
                    row.Cells["NRO_DOC"].Value = rw["NRO_DOC"].ToString();
                    row.Cells["FECHA_DOC"].Value = rw["FECHA_DOC"].ToString().Substring(0, 10);
                    row.Cells["IMP_INI"].Value = rw["IMP_INI"].ToString();
                    //row.Cells["IMP_DOC"].Value = rw["IMP_DOC"].ToString();
                    row.Cells["IMP_DOC"].Value = Convert.ToDecimal(rw["IMP_DOC"]) - obtieneImporteReal(rw["NRO_DOC"].ToString());
                    row.Cells["OBSERVACION"].Value = rw["OBSERVACION"].ToString();
                    row.Cells["COD_SUCURSAL"].Value = rw["COD_SUCURSAL"].ToString();
                    row.Cells["COD_MONEDA"].Value = rw["COD_MONEDA"].ToString();
                    row.Cells["X"].Value = false;
                }
            }
        }
        private decimal obtieneImporteReal(string nro_doc)
        {
            decimal imp = 0;
            DataRow[] row = dtAdelantoLiq.Select("NRO_DOC = '" + nro_doc + "'");
            foreach (DataRow rw in row)
            {
                imp = Convert.ToDecimal(rw["IMP_DOC"]);
                break;
            }
            return imp;
        }
        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }

        private void btn_grabar2_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("¿ Esta seguro de Liquidar los Adelantos para estas personas ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                lqaTo.FE_AÑO = AÑO;//cbo_año.SelectedValue.ToString();
                lqaTo.FE_MES = MES;//cbo_mes1.SelectedValue.ToString();
                lqaTo.COD_USU_CREA = COD_USU;
                lqaTo.FECHA_DOC = DateTime.Now;
                lqaTo.FECHA_CREA = DateTime.Now;
                //DataTable dtComision = OBTENER_COMISIONES_REALES();
                DataTable dtAdelanto = HelpersBLL.obtenerDTX(dgw1);
                //DataTable dt = new DataTable();

                if (!lqaBLL.liquidacionAdelantosBLL(lqaTo, dtAdelanto, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Los Adelantos se liquidaron correctamente !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //dgw1.Rows.Clear();
                    QUITAR_FILAS_MARCADAS();
                    CARGAR_ADELANTO_DEL_PERIODO();
                }
            }
        }
        private void QUITAR_FILAS_MARCADAS()
        {
            for (int i = dgw1.Rows.Count - 1; i >= 0; i--)
            {
                if (Convert.ToBoolean(dgw1.Rows[i].Cells["X"].Value))
                    dgw1.Rows.RemoveAt(dgw1.Rows[i].Index);
            }
        }
        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("¿ Esta seguro de Eliminar los Adelantos Liquidados del \nComisionista " + dgw2.CurrentRow.Cells["DESC_PER1"].Value.ToString() + " ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                lqaTo.COD_SUCURSAL = dgw2.CurrentRow.Cells["COD_SUCURSAL1"].Value.ToString();
                lqaTo.FE_AÑO = dgw2.CurrentRow.Cells["FE_AÑO1"].Value.ToString();
                lqaTo.FE_MES = dgw2.CurrentRow.Cells["FE_MES1"].Value.ToString();
                lqaTo.COD_PER = dgw2.CurrentRow.Cells["COD_PER1"].Value.ToString();
                lqaTo.COD_DOC = dgw2.CurrentRow.Cells["COD_DOC1"].Value.ToString();
                lqaTo.NRO_DOC = dgw2.CurrentRow.Cells["NRO_DOC1"].Value.ToString();
                lqaTo.IMP_DOC = Convert.ToDecimal(dgw2.CurrentRow.Cells["IMP_DOC1"].Value);
                lqaTo.COD_USU_MOD = COD_USU;
                lqaTo.FECHA_MOD = DateTime.Now;

                if (!lqaBLL.eliminarPLiqAdelantoBLL(lqaTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Los Adelantos se eliminaron correctamente !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ELIMINAR_FILA_DATAGRID();
                    CARGAR_ADELANTO_PENDIENTES();
                }
            }
        }
        private void ELIMINAR_FILA_DATAGRID()
        {
            dgw2.Rows.Remove(dgw2.CurrentRow);
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
