using BLL;
using Entidades;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Presentacion.MOD_COMISIONES
{
    public partial class CONSULTA_KARDEX_X_CONTRATO : Form
    {
        string nro_contrato;
        public CONSULTA_KARDEX_X_CONTRATO(string nro_contrato)
        {
            InitializeComponent();
            this.nro_contrato = nro_contrato;
            this.Text = "Kardex Historico para el Contrato " + nro_contrato;
        }

        private void CONSULTA_KARDEX_X_CONTRATO_Load(object sender, EventArgs e)
        {
            canjeTCtasxCobrarBLL tccBLL = new canjeTCtasxCobrarBLL();
            canjeTCtasxCobrarTo tccTo = new canjeTCtasxCobrarTo();
            tccTo.NRO_CONTRATO = nro_contrato;
            DataTable dt = tccBLL.obtenerKardexporContratoBLL(tccTo);
            foreach (DataRow rw in dt.Rows)
            {
                int rowId = dgw.Rows.Add();
                DataGridViewRow row = dgw.Rows[rowId];
                row.Cells["NRO_CONTRATO1"].Value = rw["NRO_CONTRATO"].ToString();
                row.Cells["NRO_DOC"].Value = rw["NRO_DOC"].ToString();
                row.Cells["FECHA_DOC"].Value = rw["FECHA_DOC"].ToString().Substring(0, 10);
                row.Cells["FECHA_VEN"].Value = rw["FECHA_VEN"].ToString().Substring(0, 10);
                row.Cells["CUOTA"].Value = rw["CUOTA"].ToString();
                row.Cells["COD_D_H"].Value = rw["COD_D_H"].ToString();
                row.Cells["IMP_DOC"].Value = rw["IMP_DOC"].ToString();
                row.Cells["OBSERVACION"].Value = rw["OBSERVACION"].ToString();
            }
            colorearFilas();
        }
        private void colorearFilas()
        {
            int m = 0; ; decimal saldo = 0;
            for (int i = 0; i < dgw.Rows.Count; i++)
            {
                if (i == dgw.Rows.Count - 1)
                {
                    if (saldo == 0)
                    {
                        for (int j = m; j <= i; j++)
                        {
                            dgw.Rows[j].DefaultCellStyle.ForeColor = Color.Black;
                            dgw.Rows[j].DefaultCellStyle.BackColor = Color.FromArgb(255, 204, 204);
                        }
                    }
                    saldo = Convert.ToDecimal(dgw.Rows[i].Cells["IMP_DOC"].Value);
                    dgw.Rows[i].Cells["SALDO"].Value = saldo;
                    break;
                }
                if (dgw.Rows[i].Cells["COD_D_H"].Value.ToString() == "D")
                {
                    m = i;
                    saldo = Convert.ToDecimal(dgw.Rows[i].Cells["IMP_DOC"].Value);
                    dgw.Rows[i].Cells["SALDO"].Value = saldo;
                    dgw.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                    dgw.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(255, 102, 255);
                }
                if (dgw.Rows[i].Cells["CUOTA"].Value.ToString() == dgw.Rows[i + 1].Cells["CUOTA"].Value.ToString())
                {
                    saldo = saldo - Convert.ToDecimal(dgw.Rows[i + 1].Cells["IMP_DOC"].Value);
                    dgw.Rows[i + 1].Cells["SALDO"].Value = saldo;
                    dgw.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                    dgw.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(255, 102, 255);
                }
                else
                {
                    if (saldo == Convert.ToDecimal(dgw.Rows[i].Cells["IMP_DOC"].Value))
                    {
                        dgw.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                        dgw.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 255);
                    }
                    else if (saldo > 0)
                    {
                        dgw.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                        dgw.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(255, 102, 255);
                    }
                    else if (saldo == 0)
                    {
                        for (int j = m; j <= i; j++)
                        {
                            dgw.Rows[j].DefaultCellStyle.ForeColor = Color.Black;
                            dgw.Rows[j].DefaultCellStyle.BackColor = Color.FromArgb(255, 204, 204);
                        }
                    }
                }
            }
        }

        private void dgw_SelectionChanged(object sender, EventArgs e)
        {
            dgw.ClearSelection();
        }
    }
}
