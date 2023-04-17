using System;
using System.Data;
using System.Windows.Forms;
using BLL;

namespace Presentacion.MOD_FACT_VTA.MOD_VTA
{
    public partial class RevertirTransferencia : Form
    {
        public RevertirTransferencia()
        {
            InitializeComponent();
        }

        private static readonly SeguimientoPlanillasBLL BLSeguimiento = new SeguimientoPlanillasBLL();

        private void RevertirTransferencia_Load(object sender, EventArgs e)
        {
            CargarPeriodo();
        }

        private void CargarPeriodo()
        {
            DataTable dtAñoMes = BLSeguimiento.ObtenerMesAñoTransferidos();
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Descripcion", typeof(string));

            DataRow rw1 = dt.NewRow();
            rw1["Id"] = 0;
            rw1["Descripcion"] = "Seleccinar";
            dt.Rows.Add(rw1);

            int id = 1;
            foreach (DataRow row in dtAñoMes.Rows)
            {
                DataRow rw = dt.NewRow();
                rw["Id"] = id++;
                rw["Descripcion"] = row["FE_MES"].ToString() + "-" + row["FE_AÑO"].ToString();
                dt.Rows.Add(rw);
            }

            cboMes.DataSource = dt;
            cboMes.DisplayMember = "Descripcion";
            cboMes.ValueMember = "Id";
        }

        private void BtnProcesar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboMes.SelectedValue) == 0)
            {
                _ = MessageBox.Show("Seleccione un período", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (DialogResult.Yes == MessageBox.Show("¿Esta seguro de eliminar las planillas transferidas?", "MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                string año = cboMes.Text.Substring(3, 4);
                string mes = cboMes.Text.Substring(0, 2);
                int cantidad = BLSeguimiento.RevertirTransferencia(año, mes);
                _ = MessageBox.Show("Planillas eliminadas de transferencia : " + cantidad.ToString(), "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
