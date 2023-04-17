using System;
using System.Windows.Forms;

namespace Presentacion.MOD_ADM
{
    public partial class PERIODO_CIERRE : Form
    {
        public PERIODO_CIERRE()
        {
            InitializeComponent();
        }

        private void PERIODO_CIERRE_Load(object sender, EventArgs e)
        {
            KeyPreview = false;
            dgw1.Rows.Add("2017", "Enero", "01/01/2017", "31/01/2017");
            dgw1.Rows.Add("2017", "Febrero", "01/02/2017", "28/02/2017");
            //
            dgvModulos.Rows.Add("01", "ADMINISTRACION", false, false);
            dgvModulos.Rows.Add("02", "ALMACEN", false, false);
            dgvModulos.Rows.Add("03", "CUENTAS POR COBRAR", false, false);
            dgvModulos.Rows.Add("04", "CUENTAS POR PAGAR", false, false);
            dgvModulos.Rows.Add("05", "VENTAS", false, false);
            tpDetalles.Parent = null;
        }

        private void PERIODO_CIERRE_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void btn_cierre_Click(object sender, EventArgs e)
        {
            cboMes.SelectedItem = dgw1[1, dgw1.CurrentRow.Index].Value;
            dtp1.Value = Convert.ToDateTime(dgw1[2, dgw1.CurrentRow.Index].Value);
            dtp2.Value = Convert.ToDateTime(dgw1[3, dgw1.CurrentRow.Index].Value);
            cbo_año.Enabled = false; cboMes.Enabled = false;
            dtp1.Enabled = false; dtp2.Enabled = false;
            tpDetalles.Parent = tcPeriodo;
            tcPeriodo.SelectedTab = tpDetalles;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            tpDetalles.Parent = null;
            tcPeriodo.SelectedTab = tpLista;
        }

        private void tcPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabControl tb = (TabControl)sender;
            if (tb.SelectedIndex == 0)
                tpDetalles.Parent = null;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            tpDetalles.Parent = null;
            tcPeriodo.SelectedTab = tpLista;
        }
    }
}
