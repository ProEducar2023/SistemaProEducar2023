using System;
using System.Drawing;
using System.Windows.Forms;

namespace Presentacion.MOD_COMISIONES
{
    public partial class ATENCION_CLIENTE_SEGUIMIENTO : Form
    {
        public ATENCION_CLIENTE_SEGUIMIENTO()
        {
            InitializeComponent();
        }

        private void ATENCION_CLIENTE_SEGUIMIENTO_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add("004545", "JOSE", "PLANILLA", "15/04/2018", "CREADA");
            dataGridView1.Rows.Add("005482", "MARIA", "PLANILLA", "05/04/2018", "PENDIENTE");
            dataGridView1.Rows.Add("001485", "JESUS", "PLANILLA", "01/04/2018", "CREADA");
            dataGridView1.Rows[0].DefaultCellStyle.BackColor = Color.LightGreen;
            dataGridView1.Rows[1].DefaultCellStyle.BackColor = Color.LightYellow;
            dataGridView1.Rows[2].DefaultCellStyle.BackColor = Color.Coral;
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            MOD_COMISIONES.ATENCION_CLIENTES_INGRESO frm = new ATENCION_CLIENTES_INGRESO();
            frm.Show();

        }
    }
}
