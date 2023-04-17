using BLL;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;
namespace Presentacion.DIALOGOS
{
    public partial class CONSULTA_PARA_CANJE_CXC : Form
    {
        precontratoCabeceraBLL pccBLL = new precontratoCabeceraBLL();
        precontratoCabeceraTo pccTo = new precontratoCabeceraTo();
        public CONSULTA_PARA_CANJE_CXC()
        {
            InitializeComponent();
        }
        private void CONSULTA_PARA_CANJE_CXC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        public void MOSTRAR_DATOS(string COD_SUCURSAL, string COD_MONEDA, string COD_PER, string NRO_CONTRATO)
        {
            this.Text = "Letras del Contrato : " + NRO_CONTRATO;
            pccTo.COD_SUCURSAL = COD_SUCURSAL;
            pccTo.COD_PER = COD_PER;

            DGW_CAB.Rows.Clear();
            DataTable dt = pccBLL.MOSTRAR_I_PRESUPUESTO_PARA_CANJE(pccTo);
            foreach (DataRow rw in dt.Rows)
            {
                int idx = DGW_CAB.Rows.Add();
                DataGridViewRow row = DGW_CAB.Rows[idx];
                row.Cells[0].Value = rw[0].ToString();
                row.Cells[1].Value = rw[1].ToString().Substring(0, 10);
                row.Cells[2].Value = rw[2].ToString();
                row.Cells[3].Value = false;
                row.Cells[4].Value = rw[4].ToString() == "" ? "" : rw[4].ToString().Substring(0, 10);
                row.Cells[5].Value = rw[5].ToString().Substring(0, 10);
                row.Cells[6].Value = rw[6].ToString();
            }
        }

        private void ch_cod_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_cod.Checked)
            {
                DGW_CAB.Sort(DGW_CAB.Columns[2], System.ComponentModel.ListSortDirection.Ascending);
                txt_letra.Clear();
                txt_letra.Focus();
            }
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void OK_Button_Click(object sender, EventArgs e)
        {
            int num2 = 0;
            int num = DGW_CAB.Rows.Count - 1;
            int num3 = num;
            while (num2 <= num3)
            {
                if (Convert.ToBoolean(DGW_CAB[3, num2].Value))
                {
                    string str = DGW_CAB[0, num2].Value.ToString();
                    string str2 = DGW_CAB[6, num2].Value.ToString();
                    if (VALIDAR(str, str2))
                    {
                        LBL.Text = "SI";
                        DGW.Rows.Add(str, str2);
                    }
                    else
                    {
                        LBL.Text = "NO";
                        MessageBox.Show("El Documento ya se insertó", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                num2++;
            }
        }
        private bool VALIDAR(string COD_DOC, string NRO_DOC)
        {
            int num2 = 0;
            int num = DGW.Rows.Count - 1;
            int num3 = num;
            while (num2 <= num3)
            {
                if (DGW[0, num2].Value.ToString() == COD_DOC && DGW[1, num2].Value.ToString() == NRO_DOC)
                {
                    return false;
                }
                num2++;
            }
            return true;
        }

        private void txt_letra_TextChanged(object sender, EventArgs e)
        {
            if (ch_cod.Checked)
            {
                txt_letra.Focus();
                int num2 = DGW_CAB.Rows.Count - 1;
                int i = 0;
                while (i <= num2)
                {
                    if (txt_letra.Text.ToLower() == DGW_CAB[2, i].Value.ToString().ToLower().Substring(0, txt_letra.TextLength))
                    {
                        DGW_CAB.CurrentCell = DGW_CAB.Rows[i].Cells[2];
                        break;
                    }
                    i++;
                }
            }
        }

        private void CONSULTA_PARA_CANJE_CXC_Shown(object sender, EventArgs e)
        {
            DGW_CAB.Select();
            DGW_CAB.CurrentRow.Cells[3].Selected = true;
        }

        private void DGW_CAB_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                foreach (DataGridViewRow row in DGW_CAB.Rows)
                {
                    row.Cells[3].Value = false;
                }
            }
        }

    }
}
