using System;
using System.Windows.Forms;

namespace Presentacion.MOD_COMISIONES
{
    public partial class CONSULTA_ADELANTO_COMISIONES_PARA_RESUMEN : Form
    {
        public CONSULTA_ADELANTO_COMISIONES_PARA_RESUMEN()
        {
            InitializeComponent();
        }
        public void mostrarAdelantosPendientes(string cod_comisionista)
        {
            //pAdelantoBLL padeBLL = new pAdelantoBLL();
            //pAdelantoTo padeTo = new pAdelantoTo();
            //padeTo.COD_PER = cod_comisionista;
            //DataTable dt = padeBLL.obtenerP_AdelantoBLL(padeTo);
            //dgw1.Rows.Clear();
            //if(dt.Rows.Count > 0)
            //{
            //    foreach(DataRow rw in dt.Rows)
            //    {
            //        int rowId = dgw1.Rows.Add();
            //        DataGridViewRow row = dgw1.Rows[rowId];
            //        row.Cells["FE_AÑO"].Value = rw["FE_AÑO"].ToString();
            //        row.Cells["FE_MES"].Value = rw["FE_MES"].ToString();
            //        row.Cells["COD_PER"].Value = rw["COD_PER"].ToString();
            //        row.Cells["DESC_PER"].Value = rw["DESC_PER"].ToString();
            //        row.Cells["COD_DOC"].Value = rw["COD_DOC"].ToString();
            //        row.Cells["NRO_DOC"].Value = rw["NRO_DOC"].ToString();
            //        row.Cells["FECHA_DOC"].Value = rw["FECHA_DOC"].ToString().Substring(0, 10);
            //        row.Cells["IMP_INI"].Value = rw["IMP_INI"].ToString();
            //        row.Cells["IMP_DOC"].Value = rw["IMP_DOC"].ToString();
            //        row.Cells["OBSERVACION"].Value = rw["OBSERVACION"].ToString();
            //        row.Cells["X"].Value = false;
            //    }
            //}
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Hide();
        }
    }
}
