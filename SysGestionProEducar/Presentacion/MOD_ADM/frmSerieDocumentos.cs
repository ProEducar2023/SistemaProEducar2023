using BLL;
using System;
using System.Data;
using System.Windows.Forms;
namespace Presentacion.MOD_ADM
{
    public partial class frmSerieDocumentos : Form
    {
        DataGridView GridSerieActual;
        serieDocumentoBLL sdoBLL = new serieDocumentoBLL();
        public frmSerieDocumentos(string descripcionMovimiento, DataGridView serieActual)
        {
            InitializeComponent();
            //
            tslMensaje.Text = descripcionMovimiento;
            this.GridSerieActual = serieActual;
        }

        private void frmSerieDocumentos_Load(object sender, EventArgs e)
        {
            CargarSeriesDocumento();
            if (GridSerieActual.RowCount > 0)
            {
                if (dgvSeriesDocumento.Rows.Count > 0)
                {
                    int i = 0; int j = 0; bool op;
                    while (i <= GridSerieActual.RowCount - 1)
                    {
                        while (j <= dgvSeriesDocumento.Rows.Count - 1)
                        {
                            op = GridSerieActual[4, i].Value.ToString() == "1" ? true : false;
                            if (dgvSeriesDocumento[0, j].Value.ToString() == GridSerieActual[0, i].Value.ToString() && dgvSeriesDocumento[2, j].Value.ToString() == GridSerieActual[2, i].Value.ToString() &&
                                Convert.ToBoolean(dgvSeriesDocumento[4, j].Value) == op && dgvSeriesDocumento[5, j].Value.ToString() == GridSerieActual[5, i].Value.ToString())
                            {
                                dgvSeriesDocumento[6, j].Value = true;
                                break;
                            }
                            j = j + 1;
                        }
                        i = i + 1;
                    }
                }
            }
        }
        private void CargarSeriesDocumento()
        {
            dgvSeriesDocumento.Rows.Clear();
            DataTable dt = sdoBLL.obtenerSerieDocumentoBLL();
            foreach (DataRow rw in dt.Rows)
            {
                int rowId = dgvSeriesDocumento.Rows.Add();
                DataGridViewRow row = dgvSeriesDocumento.Rows[rowId];
                row.Cells["codsuc"].Value = rw["COD_SUCURSAL"].ToString();
                row.Cells["suc"].Value = rw["Sucursal"].ToString();
                row.Cells["coddoc"].Value = rw["Cod Doc"].ToString();
                row.Cells["doc"].Value = rw["Documento"].ToString();
                row.Cells["sunat"].Value = rw["STATUS_DOC"].ToString() == "1" ? true : false;
                row.Cells["ser"].Value = rw["Serie"].ToString();
                row.Cells["ok"].Value = false;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
