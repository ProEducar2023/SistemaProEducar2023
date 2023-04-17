using BLL;
using Entidades;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Presentacion.MOD_CXC
{
    public partial class Ingreso_Retencion_Devolucion_Cliente : Form
    {
        HelpersBLL helBLL = new HelpersBLL();
        HelpersTo helTo = new HelpersTo();
        DataTable dtPersona, dtDevCli;
        string contrato; string codigo_per;
        public Ingreso_Retencion_Devolucion_Cliente(DataTable dtDevCli)
        {
            InitializeComponent();
            this.dtDevCli = dtDevCli;
        }
        private void Ingreso_Retencion_Devolucion_Cliente_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            CARGAR_PERSONAS();
            CARGAR_DATA_GRID();
        }
        private void Ingreso_Retencion_Devolucion_Cliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }
        private void CARGAR_DATA_GRID()
        {
            dgw_dev_cliente.Rows.Clear();
            if (dtDevCli != null)
            {
                if (dtDevCli.Rows.Count > 0)
                {
                    foreach (DataRow rw in dtDevCli.Rows)
                    {
                        int idx = dgw_dev_cliente.Rows.Add();
                        DataGridViewRow row = dgw_dev_cliente.Rows[idx];
                        row.Cells[0].Value = rw[0].ToString();
                        row.Cells[1].Value = rw[1].ToString();
                        row.Cells[2].Value = rw[2].ToString();
                        row.Cells[3].Value = rw[3].ToString();
                    }
                    sumaMontoDev();
                }
            }
        }
        private void CARGAR_PERSONAS()
        {
            //helTo.CODIGO = "04";//VENDEDORES
            dtPersona = helBLL.MOSTRAR_PERSONAS_X_DSCTO_DIRECTA_BLL();
            if (dtPersona.Rows.Count > 0)
            {
                dgw_per.DataSource = dtPersona;
                dgw_per.Columns["COD_PER"].HeaderText = "Codigo";
                dgw_per.Columns["COD_PER"].Width = 50;
                dgw_per.Columns["DESC_PER"].HeaderText = "Nombre de Persona";
                dgw_per.Columns["DESC_PER"].Width = 230;
                dgw_per.Columns["NRO_DOC"].HeaderText = "DNI / RUC";
                dgw_per.Columns["NRO_DOC"].Width = 70;
                dgw_per.Columns["NRO_PRESUPUESTO"].HeaderText = "Contrato";
                dgw_per.Columns["NRO_PRESUPUESTO"].Width = 70;
                dgw_per.Columns["DESC_PROGRAMA"].HeaderText = "Programa";
                dgw_per.Columns["DESC_PROGRAMA"].Width = 120;
                dgw_per.Columns["COD_PROGRAMA"].Visible = false;
                dgw_per.Columns["COD_SUCURSAL"].Visible = false;
                dgw_per.Columns["COD_INSTITUCION"].Visible = false;
                dgw_per.Columns["COD_CANAL_DSCTO"].Visible = false;
                dgw_per.Columns["IMP_DOC"].Visible = false;
                dgw_per.Columns["COD_PTO_COB"].Visible = false;
            }
        }
        private void dgw_per_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int idx = dgw_per.CurrentRow.Index;
                TXT_COD.Text = dgw_per[0, idx].Value.ToString();
                TXT_DESC.Text = dgw_per[1, idx].Value.ToString();
                txt_doc_per.Text = dgw_per[2, idx].Value.ToString();
                contrato = dgw_per.CurrentRow.Cells["NRO_PRESUPUESTO"].Value.ToString();
                codigo_per = dgw_per.CurrentRow.Cells["COD_PER"].Value.ToString();
                Panel_PER.Visible = false;
                txt_doc_per.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Panel_PER.Visible = false;
                TXT_COD.Clear();
                TXT_DESC.Clear();
                txt_doc_per.Clear();
                TXT_COD.Focus();
            }
        }

        private void TXT_COD_Leave(object sender, EventArgs e)
        {
            if (TXT_COD.Text.Trim() != "")
            {
                if (dgw_per.Rows.Count > 0)
                {
                    dgw_per.Sort(dgw_per.Columns[0], System.ComponentModel.ListSortDirection.Ascending);
                    int i = 0, num2 = 0;
                    num2 = dgw_per.Rows.Count - 1;
                    do
                    {
                        if (TXT_COD.Text.ToLower() == dgw_per[0, i].Value.ToString().ToLower())
                        {
                            TXT_COD.Text = dgw_per[0, i].Value.ToString();
                            TXT_DESC.Text = dgw_per[1, i].Value.ToString();
                            txt_doc_per.Text = dgw_per[2, i].Value.ToString();

                            return;
                        }
                        if (TXT_COD.Text.ToLower() == dgw_per[0, i].Value.ToString().ToLower().Substring(0, TXT_COD.TextLength))
                        {
                            dgw_per.CurrentCell = dgw_per.Rows[i].Cells[0];
                            break;
                        }
                        dgw_per.CurrentCell = dgw_per.Rows[0].Cells[0];
                        i += 1;
                    }
                    while (i <= num2);
                    Panel_PER.BringToFront();
                    Panel_PER.Visible = true;
                    dgw_per.Visible = true;
                    dgw_per.Focus();
                }
            }
        }

        private void TXT_DESC_Leave(object sender, EventArgs e)
        {
            if (TXT_DESC.Text == "")
            {
                txt_doc_per.Focus();
            }
            else
            {
                if (dgw_per.Rows.Count > 0)
                {
                    dgw_per.Sort(dgw_per.Columns[1], System.ComponentModel.ListSortDirection.Ascending);
                    int i = 0, num2 = 0;
                    num2 = dgw_per.Rows.Count;
                    do
                    {
                        if (dgw_per[1, i].Value.ToString().Length >= TXT_DESC.TextLength)
                        {
                            if (TXT_DESC.Text.ToLower() == dgw_per[1, i].Value.ToString().ToLower().Substring(0, TXT_DESC.TextLength).ToLower())
                            {
                                dgw_per.CurrentCell = dgw_per.Rows[i].Cells[0];
                                break;
                            }
                        }
                        dgw_per.CurrentCell = dgw_per.Rows[0].Cells[0];
                        i += 1;
                    }
                    while (i < num2);
                    Panel_PER.Visible = true;
                    dgw_per.Visible = true;
                    dgw_per.Focus();
                }
            }
        }

        private void txt_doc_per_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_doc_per.Text.Trim() == "")
                {
                    Panel_PER.Visible = false;
                }//Gestion Comercial/compras/servicio/requiriento de servicio
                else if (dgw_per.Rows.Count > 0)
                {
                    DataRow[] rs = dtPersona.Select("NRO_DOC = '" + txt_doc_per.Text.Trim() + "'");
                    if (rs.Length > 0)
                    {
                        dgw_per.Sort(dgw_per.Columns[2], System.ComponentModel.ListSortDirection.Ascending);
                        int i = 0, num2 = 0;
                        num2 = dgw_per.Rows.Count;
                        do
                        {
                            if (dgw_per[2, i].Value.ToString().Length >= txt_doc_per.TextLength)
                            {
                                if (txt_doc_per.Text.ToLower() == dgw_per[2, i].Value.ToString().ToLower().Substring(0, txt_doc_per.TextLength).ToLower())
                                {
                                    dgw_per.CurrentCell = dgw_per.Rows[i].Cells[0];
                                    break;
                                }
                            }
                            dgw_per.CurrentCell = dgw_per.Rows[0].Cells[0];
                            i += 1;
                        }
                        while (i < num2);
                        Panel_PER.Visible = true;
                        dgw_per.Visible = true;
                        dgw_per.Focus();
                    }
                    else
                    {
                        Panel_PER.Visible = false;
                    }
                }
            }
        }

        private void btn_adicionar_Click(object sender, EventArgs e)
        {
            if (TXT_COD.Text.Trim() != "" && TXT_DESC.Text.Trim() != "" && txt_doc_per.Text.Trim() != "")
            {
                nuevaFila();
                TXT_COD.Clear();
                TXT_DESC.Clear();
                txt_doc_per.Clear();
            }
        }

        private void nuevaFila()
        {
            int rowId = dgw_dev_cliente.Rows.Add();
            DataGridViewRow row = dgw_dev_cliente.Rows[rowId];
            row.Cells["NRO_CONTRATO"].Value = contrato;
            row.Cells["NRO_CONTRATO"].ReadOnly = true;
            row.Cells["COD_PER"].Value = codigo_per;
            row.Cells["COD_PER"].ReadOnly = true;
            row.Cells["APENOM"].Value = TXT_DESC.Text;
            row.Cells["APENOM"].ReadOnly = true;
            row.Cells["MONTO_DEV"].Value = "0.00";
            row.Cells["MONTO_DEV"].ReadOnly = false;

            dgw_dev_cliente.Rows[rowId].Cells["MONTO_DEV"].Selected = true;
            dgw_dev_cliente.BeginEdit(true);
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (dgw_dev_cliente.Rows.Count > 0)
            {
                DialogResult rs = MessageBox.Show("¿ Esta seguro de eliminar éste registro ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    dgw_dev_cliente.Rows.RemoveAt(dgw_dev_cliente.CurrentRow.Index);
                    sumaMontoDev();
                }
            }
        }

        private void dgw_dev_cliente_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                sumaMontoDev();
                TXT_COD.Focus();
            }
        }
        private void sumaMontoDev()
        {
            txt_total.Text = Convert.ToString(dgw_dev_cliente.Rows.Cast<DataGridViewRow>().Sum(x => Convert.ToDecimal(x.Cells["MONTO_DEV"].Value)));
        }

    }
}
