using System;
using System.Windows.Forms;

namespace Presentacion.MOD_VTA
{
    public partial class MODULO_FACT_COMPRAS : Form
    {
        public MODULO_FACT_COMPRAS()
        {
            InitializeComponent();
        }

        private void OrdenCompraToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void InventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CONSULTAS.CONSULTA_FACT_COMPRAS frm = new CONSULTAS.CONSULTA_FACT_COMPRAS();
            frm.MdiParent = this;
            frm.Show();
        }

        private void GastosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CONSULTAS.CONSULTA_FACT_MOV frm = new CONSULTAS.CONSULTA_FACT_MOV();
            frm.MdiParent = this;
            frm.Show();
        }

        private void HistóricoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CONSULTAS.CONSULTA_FAC_DI_HIST frm = new CONSULTAS.CONSULTA_FAC_DI_HIST();
            frm.MdiParent = this;
            frm.Show();
        }

        private void DocumentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CONSULTAS.CONSULTA_GASTO frm = new CONSULTAS.CONSULTA_GASTO();
            frm.MdiParent = this;
            frm.Show();
        }

        private void MoviemientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CONSULTAS.CONSULTA_GASTO_MOV frm = new CONSULTAS.CONSULTA_GASTO_MOV();
            frm.MdiParent = this;
            frm.Show();
        }

        private void HistóricoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CONSULTAS.CONSULTA_GASTO_HIST frm = new CONSULTAS.CONSULTA_GASTO_HIST();
            frm.MdiParent = this;
            frm.Show();
        }

        private void HistóricoToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            CONSULTAS.CONSULTA_GASTO_HON_HIST frm = new CONSULTAS.CONSULTA_GASTO_HON_HIST();
            frm.MdiParent = this;
            frm.Show();
        }

        private void ComparaciónDePreciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CONSULTAS.CONSULTA_PRECIOS_FACT frm = new CONSULTAS.CONSULTA_PRECIOS_FACT();
            frm.MdiParent = this;
            frm.Show();
        }

        private void FacturaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            REPORTES.FORM_REPORTES.REPORTE_FACTURACION frm = new REPORTES.FORM_REPORTES.REPORTE_FACTURACION();
            frm.MdiParent = this;
            frm.Show();
        }

        private void ToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            REPORTES.FORM_REPORTES.REPORTE_FACTURACION_GASTO frm = new REPORTES.FORM_REPORTES.REPORTE_FACTURACION_GASTO();
            frm.MdiParent = this;
            frm.Show();
        }

        private void FactGastosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            REPORTES.FORM_REPORTES.REPORTE_GASTO frm = new REPORTES.FORM_REPORTES.REPORTE_GASTO();
            frm.MdiParent = this;
            frm.Show();
        }

        private void ComprasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            REPORTES.FORM_REPORTES.REPORTE_COMPRAS frm = new REPORTES.FORM_REPORTES.REPORTE_COMPRAS();
            frm.MdiParent = this;
            frm.Show();
        }

        private void MovilidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            REPORTES.FORM_REPORTES.REPORTE_MOVILIDAD frm = new REPORTES.FORM_REPORTES.REPORTE_MOVILIDAD();
            frm.MdiParent = this;
            frm.Show();

        }

        private void ResumenComprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            REPORTES.FORM_REPORTES.REPORTE_PRODUCTO_COMPRAS frm = new REPORTES.FORM_REPORTES.REPORTE_PRODUCTO_COMPRAS();
            frm.MdiParent = this;
            frm.Show();
        }

        private void RankingComprasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void SalirToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }



    }
}
