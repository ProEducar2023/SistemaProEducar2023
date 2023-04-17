using BLL;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;
namespace Presentacion.DIALOGOS
{
    public partial class CONSULTA_PCTAS_COBRAR_POR_NROCONTRATO : Form
    {
        canjePCtasxCobrarBLL pctaBLL = new canjePCtasxCobrarBLL();
        canjePCtasxCobrarTo pctaTo = new canjePCtasxCobrarTo();
        public CONSULTA_PCTAS_COBRAR_POR_NROCONTRATO()
        {
            InitializeComponent();
        }

        public void MOSTRAR_DATOS(DataTable dtD, string nrocontrato, string nroletra)
        {
            chkSeleccionarTodos.Checked = false;
            pctaTo.NRO_CONTRATO = nrocontrato;
            pctaTo.NRO_LETRA = nroletra;
            DGW_CAB.Rows.Clear();
            DataTable dt = pctaBLL.obtener_PCtasCobrar_por_NroContratoBLL(pctaTo);

            foreach (DataRow rw in dt.Rows)
            {
                int idx = DGW_CAB.Rows.Add();
                DataGridViewRow row = DGW_CAB.Rows[idx];
                row.Cells[0].Value = rw[0].ToString();
                row.Cells[1].Value = rw[1].ToString();
                row.Cells[2].Value = rw[2].ToString().Substring(0, 10);
                row.Cells[3].Value = rw[3].ToString();
                row.Cells[4].Value = rw[4].ToString();
                row.Cells[5].Value = rw[5].ToString();
                row.Cells[6].Value = rw[6].ToString();
                row.Cells[7].Value = false;
                row.Cells[8].Value = rw[7].ToString();
                row.Cells[9].Value = rw[8].ToString();
                row.Cells[10].Value = rw[9].ToString();
                row.Cells[11].Value = rw[10].ToString();
            }
            //elimina los registros que ya se encuentran en el grid de Generacion de Planillas
            for (int i = dtD.Rows.Count - 1; i >= 0; i--)
            {
                for (int j = DGW_CAB.Rows.Count - 1; j >= 0; j--)
                {
                    if (dtD.Rows[i]["NRO_LETRA"].ToString() == DGW_CAB.Rows[j].Cells[5].Value.ToString())
                    {
                        DGW_CAB.Rows.Remove(DGW_CAB.Rows[j]);
                    }
                }
            }
            if (DGW_CAB.Rows.Count > 0)
                DGW_CAB.Rows[0].Cells[7].Value = true;
        }

        private void chkSeleccionarTodos_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in DGW_CAB.Rows)
            {
                row.Cells[7].Value = chkSeleccionarTodos.Checked;
            }
        }

        private void DGW_CAB_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                if (e.RowIndex == -1)
                    return;
                if (DGW_CAB.CurrentRow != null)
                {
                    int k = DGW_CAB.CurrentRow.Index;
                    if (k > 0)
                    {
                        if (Convert.ToBoolean(DGW_CAB.Rows[k - 1].Cells[7].Value) && Convert.ToBoolean(DGW_CAB.Rows[k].Cells[7].Value))
                        {
                            DGW_CAB.Rows[k].Cells[7].Value = true;
                        }
                        else
                            DGW_CAB.Rows[k].Cells[7].Value = false;
                        DGW_CAB.EndEdit();
                    }
                }

            }
        }

        private void DGW_CAB_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (DGW_CAB.IsCurrentCellDirty)
            {
                DGW_CAB.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

    }
}
