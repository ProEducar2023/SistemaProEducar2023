using BLL;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;
namespace Presentacion.DIALOGOS
{
    public partial class CONSULTA_KIT : Form
    {
        kitDetalleBLL kidBLL = new kitDetalleBLL();
        kitDetalleTo kidTo = new kitDetalleTo();
        public string COD_KIT;
        public CONSULTA_KIT()
        {
            InitializeComponent();
        }

        private void CONSULTA_KIT_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
        }
        private void CARGAR_DETALLES_KIT(object COD_KIT)
        {
            if (DGW_DET.Rows.Count > 0)
                DGW_DET.Rows.Clear();
            kidTo.COD_KIT = COD_KIT.ToString();
            DataTable dt = kidBLL.obtenerKitDetalleporCodKitBLL(kidTo);
            foreach (DataRow rw in dt.Rows)
            {
                int idx = DGW_DET.Rows.Add();
                DataGridViewRow row = DGW_DET.Rows[idx];
                row.Cells[0].Value = rw[0].ToString();
                row.Cells[1].Value = rw[1].ToString();
                row.Cells[2].Value = rw[2].ToString();
                row.Cells[3].Value = rw[3].ToString();
                row.Cells[4].Value = rw[4].ToString();
                row.Cells[5].Value = rw[5].ToString();
                row.Cells[6].Value = Convert.ToBoolean(rw[8]);
                row.Cells["STATUS_IGV"].Value = rw["STATUS_IGV"].ToString();
            }
        }
        private void BTN_ACEPTAR_Click(object sender, EventArgs e)
        {
            int num = DGW_DET.Rows.Count - 1;
            int num3 = num;
            int i = 0;

            while (i <= num3)
            {
                COD_KIT = DGW_CAB[0, DGW_CAB.CurrentRow.Index].Value.ToString();
                string ARTICULO = DGW_DET[0, i].Value.ToString();
                if (VALIDAR_DET(COD_KIT, ARTICULO))
                {
                    MessageBox.Show("Los artículos del Kit se adicionaron correctamente !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
                }
                DGW.Rows.Add(DGW_DET[0, i].Value, DGW_CAB[0, DGW_CAB.CurrentRow.Index].Value);
                i++;
            }
        }
        private bool VALIDAR_DET(object COD_KIT, object ARTICULO)
        {
            int num = DGW.Rows.Count - 1;
            int num3 = num;
            int i = 0;
            while (i <= num3)
            {
                if (DGW[0, i].Value.ToString() == ARTICULO.ToString() && DGW[1, i].Value.ToString() == COD_KIT.ToString())
                    return false;
                i++;
            }

            return true;
        }
        private void BTN_CANCELAR_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Hide();
        }

        private void DGW_CAB_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (DGW_CAB.Rows.Count > 0)
            {
                object COD_KIT = DGW_CAB[0, DGW_CAB.CurrentRow.Index].Value;
                CARGAR_DETALLES_KIT(COD_KIT);
            }
        }

        private void CONSULTA_KIT_Shown(object sender, EventArgs e)
        {
            BTN_ACEPTAR.Focus();
        }

        private void txt_cantidad_a_ingresar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_cantidad_a_ingresar.Text = HelpersBLL.OBTIENE_PRECIO_TRES_DECIMALES(txt_cantidad_a_ingresar.Text);
                foreach (DataGridViewRow row in DGW_DET.Rows)
                {
                    row.Cells[4].Value = txt_cantidad_a_ingresar.Text;
                }
                BTN_ACEPTAR.Focus();
            }
        }

        private void txt_cantidad_a_ingresar_Leave(object sender, EventArgs e)
        {
            txt_cantidad_a_ingresar.Text = HelpersBLL.OBTIENE_PRECIO_TRES_DECIMALES(txt_cantidad_a_ingresar.Text);
            BTN_ACEPTAR.Focus();
        }

        private void DGW_DET_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                if (!validaCeldasGrid(e.FormattedValue.ToString(), true))
                {
                    e.Cancel = true;
                }

            }
        }
        private bool validaCeldasGrid(string valor, bool incluyeCero)
        {
            bool result = true;
            if (!HelpersBLL.esNumeroDecimal(valor, incluyeCero))
            {
                MessageBox.Show("Cantidad no válida !!!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return result = false;
            }
            return result;
        }

        private void DGW_DET_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                DataGridViewCell cell = DGW_DET.Rows[e.RowIndex].Cells[e.ColumnIndex];
                DGW_DET.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = HelpersBLL.OBTIENE_PRECIO_TRES_DECIMALES(cell.Value.ToString());
            }
        }
    }
}
