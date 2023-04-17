using System;
using System.Windows.Forms;

namespace Presentacion.MOD_VTA
{
    public partial class MODULO_FACT_VTAS : Form
    {
        string AÑO = "", MES = "", COD_MOD, TIPO_USU, COD_USU, NOM_EMPRESA, NOM_USU;
        DateTime FECHA_INI, FECHA_GRAL;
        public MODULO_FACT_VTAS(string AÑO, string MES, DateTime FECHA_INI, DateTime FECHA_GRAL, string COD_MOD, string TIPO_USU, string COD_USU, string NOM_EMPRESA, string NOM_USU)
        {
            InitializeComponent();
            this.AÑO = AÑO;
            this.MES = MES;
            this.FECHA_INI = FECHA_INI;
            this.FECHA_GRAL = FECHA_GRAL;
            this.COD_MOD = COD_MOD;
            this.TIPO_USU = TIPO_USU;
            this.COD_USU = COD_USU;
            this.NOM_EMPRESA = NOM_EMPRESA;
            this.NOM_USU = NOM_USU;
        }
        private void MODULO_FACT_VTAS_Load(object sender, EventArgs e)
        {
            tsstlUsuario.Text = NOM_USU;
            tsslEmpresa.Text = NOM_EMPRESA;
            tsslProceso.Text = FECHA_GRAL.Date.ToShortDateString();
        }
        private void GuíasPedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_FACT_VTA.FACTURACION_VTAS frm = new MOD_FACT_VTA.FACTURACION_VTAS(AÑO, MES, FECHA_INI, FECHA_GRAL, COD_MOD, TIPO_USU, COD_USU);
            frm.MdiParent = this;
            frm.Show();
        }

        private void SalirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void envíoDeDocumentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_FACT_VTA.frmEnvioFacturasEFact frm = new MOD_FACT_VTA.frmEnvioFacturasEFact();
            frm.MdiParent = this;
            frm.Show();
        }

        private void comunicaciónDeBajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_FACT_VTA.frmEnvioBajasEFact frm = new MOD_FACT_VTA.frmEnvioBajasEFact();
            frm.MdiParent = this;
            frm.Show();
        }

        private void resumenDiarioDeBoletasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_FACT_VTA.FrmEnvioResumenDiario frm = new MOD_FACT_VTA.FrmEnvioResumenDiario();
            frm.MdiParent = this;
            frm.Show();
        }

        private void consultarTicketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_FACT_VTA.FrmConsultarTicketSunat frm = new MOD_FACT_VTA.FrmConsultarTicketSunat();
            frm.MdiParent = this;
            frm.Show();
        }

        private void sistemaAnteriorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_FACT_VTA.CARGA_FACT_SIS_ANT frm = new MOD_FACT_VTA.CARGA_FACT_SIS_ANT(AÑO, MES, FECHA_INI, FECHA_GRAL, COD_MOD, TIPO_USU, COD_USU);
            frm.MdiParent = this;
            frm.Show();
        }

        private void serviciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_FACT_VTA.FACTURACION_SERVICIOS frm = new MOD_FACT_VTA.FACTURACION_SERVICIOS(AÑO, MES, FECHA_INI, FECHA_GRAL, COD_MOD, TIPO_USU, COD_USU);
            frm.MdiParent = this;
            frm.Show();
        }
        //nuevo
        private void contratosDirectosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_FACT_VTA.CONTRATOS_DIRECTOS_FACTURACION frm = new MOD_FACT_VTA.CONTRATOS_DIRECTOS_FACTURACION(AÑO, MES, FECHA_INI, FECHA_GRAL, COD_MOD, TIPO_USU, COD_USU);
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuContratosDirectos_Click(object sender, EventArgs e)
        {
            MOD_FACT_VTA.Reportes.FormRep.REPORTE_CONTRATOS_DIRECTOS frm = new MOD_FACT_VTA.Reportes.FormRep.REPORTE_CONTRATOS_DIRECTOS(AÑO, MES, FECHA_INI, FECHA_GRAL, COD_MOD, TIPO_USU, COD_USU);
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
