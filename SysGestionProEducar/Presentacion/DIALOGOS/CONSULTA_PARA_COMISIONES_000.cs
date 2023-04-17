using BLL;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;

namespace Presentacion.DIALOGOS
{
    public partial class CONSULTA_PARA_COMISIONES_000 : Form
    {
        pComisionBLL pcoBLL = new pComisionBLL();
        pComisionTo pcoTo = new pComisionTo();
        public CONSULTA_PARA_COMISIONES_000()
        {
            InitializeComponent();
        }

        private void CONSULTA_PARA_COMISIONES_000_Load(object sender, EventArgs e)
        {

        }
        public void OBTENER_P_COMISION_POR_PERIODO(string AÑO, string MES, string LETRA, string PRE_APROB)
        {
            pcoTo.FE_AÑO = AÑO;
            pcoTo.FE_MES = MES;
            pcoTo.NRO_LETRA = LETRA;
            pcoTo.STATUS_PRE_APROB = PRE_APROB;
            dgw.Rows.Clear();
            DataTable dt = null;
            if (pcoTo.NRO_LETRA == "000")
                dt = pcoBLL.obtenerPComisionPorPeriodoBLL(pcoTo);
            else
                dt = pcoBLL.obtenerPComisionDif000BLL(pcoTo);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow rw in dt.Rows)
                {
                    int rowId = dgw.Rows.Add();
                    DataGridViewRow row = dgw.Rows[rowId];
                    row.Cells["TIPO_VTA"].Value = rw["TIPO_VTA"].ToString();
                    row.Cells["COD_PROGRAMA"].Value = rw["COD_PROGRAMA"].ToString();
                    row.Cells["COD_VENDEDOR"].Value = rw["COD_VENDEDOR"].ToString();
                    row.Cells["DESC_PER"].Value = rw["DESC_PER"].ToString();
                    row.Cells["NRO_CONTRATO"].Value = rw["NRO_CONTRATO"].ToString();
                    row.Cells["FE_CONTRATO"].Value = rw["FE_CONTRATO"].ToString();
                    row.Cells["FE_AÑO"].Value = rw["FE_AÑO"].ToString();
                    row.Cells["FE_MES"].Value = rw["FE_MES"].ToString();
                    row.Cells["FE_DOC"].Value = rw["FE_DOC"].ToString();
                    row.Cells["COD_PER"].Value = rw["COD_PER"].ToString();
                    row.Cells["NOMCLI"].Value = rw["NOMCLI"].ToString();
                    row.Cells["NRO_LETRA"].Value = rw["NRO_LETRA"].ToString();
                    row.Cells["COD_NIVEL"].Value = rw["COD_NIVEL"].ToString();
                    row.Cells["DESC_NIVEL"].Value = rw["DESC_NIVEL"].ToString();
                    row.Cells["IMP_FIN"].Value = rw["IMP_FIN"].ToString();
                    row.Cells["COD_PER_SUP"].Value = rw["COD_PER_SUP"].ToString();
                    row.Cells["NOMSUP"].Value = rw["NOMSUP"].ToString();
                    row.Cells["X"].Value = true;
                }
            }
        }

        private void BTN_ACEPTAR_Click(object sender, EventArgs e)
        {

        }

    }
}
