using System.Drawing;
using System.Windows.Forms;

namespace Presentacion.HELPERS
{
    public static class AjusteGridView
    {
        public static void InitStyle_1(DataGridView gridView)
        {
            if (gridView != null)
            {
                gridView.AllowDrop = false;
                gridView.AllowUserToAddRows = false;
                gridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                gridView.DefaultCellStyle.SelectionBackColor = Color.White;
                gridView.DefaultCellStyle.SelectionForeColor = Color.Blue;
                gridView.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                gridView.MultiSelect = false;
                gridView.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }
        }

        public static void InitStyle_2(DataGridView gridView)
        {
            if (gridView != null)
            {
                gridView.AllowDrop = false;
                gridView.AllowUserToAddRows = false;
                gridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                gridView.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                gridView.MultiSelect = false;
            }
        }
    }
}
