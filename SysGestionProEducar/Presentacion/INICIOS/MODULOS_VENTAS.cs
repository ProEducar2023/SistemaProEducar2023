using System;
using System.Windows.Forms;

namespace Presentacion.MOD_VTA
{
    public partial class MODULOS_VENTAS : Form
    {
        public Presentacion.MOD_VTA.PEDIDO2 pedido2;
        public Presentacion.MOD_VTA.PRESUPUESTO_PEDIDO presupuesto_pedido;
        string AÑO = "", MES = "", COD_MOD, TIPO_USU, COD_USU, NOM_EMPRESA, NOM_USU;
        DateTime FECHA_INI, FECHA_GRAL;
        public MODULOS_VENTAS(string AÑO, string MES, DateTime FECHA_INI, DateTime FECHA_GRAL, string COD_MOD, string TIPO_USU, string COD_USU, string NOM_EMPRESA, string NOM_USU)
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

        private void EliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void semanaContratoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void MODULOS_VENTAS_Load(object sender, EventArgs e)
        {
            tsstlUsuario.Text = NOM_USU;
            tsslEmpresa.Text = NOM_EMPRESA;
            tsslProceso.Text = FECHA_GRAL.Date.ToShortDateString();
        }
        //private void MODULOS_VENTAS_Activated(object sender, EventArgs e)
        //{
        //    tsstlUsuario.Text = NOM_USU;
        //    tsslEmpresa.Text = NOM_EMPRESA;
        //    tsslProceso.Text = FECHA_GRAL.Date.ToShortDateString();
        //}

        private void planillaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void planillaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            presupuesto_pedido = new MOD_VTA.PRESUPUESTO_PEDIDO(AÑO, MES, FECHA_INI, FECHA_GRAL, COD_MOD, TIPO_USU, COD_USU, this);
            presupuesto_pedido.MdiParent = this;
            presupuesto_pedido.Show();
        }

        private void OrdenDeDevoluciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_FACT_VTA.MOD_VTA.ORDEN_DEV_VTAS frm = new MOD_FACT_VTA.MOD_VTA.ORDEN_DEV_VTAS(AÑO, MES, FECHA_INI, FECHA_GRAL, COD_MOD, TIPO_USU, COD_USU);
            frm.MdiParent = this;
            frm.Show();
        }

        private void planillasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SysSeguimiento.SeguimientoPlanilla seguimientoPlanilla = new SysSeguimiento.SeguimientoPlanilla(AÑO, MES, COD_USU)
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen
            };
            seguimientoPlanilla.Show();
        }

        private void transferenciasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_FACT_VTA.MOD_VTA.TransferenciaPlanillas transferenciaPlanillas = new MOD_FACT_VTA.MOD_VTA.TransferenciaPlanillas(AÑO, MES)
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen
            };
            transferenciaPlanillas.Show();
        }

        private void ChequesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_FACT_VTA.MOD_VTA.SeguimientoCheques seguimiento = new MOD_FACT_VTA.MOD_VTA.SeguimientoCheques(AÑO, MES, COD_USU)
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen
            };
            seguimiento.Show();
        }

        private void listaPlanillaXEtapaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_FACT_VTA.MOD_VTA.ListaSeguimientoPlanilla listaSeguimiento = new MOD_FACT_VTA.MOD_VTA.ListaSeguimientoPlanilla(AÑO, MES)
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            listaSeguimiento.Show();
        }

        private void listaChequeXEtapaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_FACT_VTA.MOD_VTA.ListaSeguimientoCheque listaCheque = new MOD_FACT_VTA.MOD_VTA.ListaSeguimientoCheque(AÑO, MES)
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            listaCheque.Show();
        }

        private void EfectividadComparativaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_FACT_VTA.MOD_VTA.Reportes.ReporteODR.FrmRptEfectividadComparativa rptEfectividad = new MOD_FACT_VTA.MOD_VTA.Reportes.ReporteODR.FrmRptEfectividadComparativa()
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen
            };
            rptEfectividad.Show();
        }

        private void EfectividadComparativaGeneEnvVsEjecToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_FACT_VTA.MOD_VTA.Reportes.ReporteODR.FrmRptEfectividadComparativaEnvGen rptEfectividad = new MOD_FACT_VTA.MOD_VTA.Reportes.ReporteODR.FrmRptEfectividadComparativaEnvGen()
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen
            };
            rptEfectividad.Show();
        }

        private void EfectividadComparativaGeneEnvVsEjecMesMesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_FACT_VTA.MOD_VTA.Reportes.ReporteODR.FrmRptEfectividadComparativaEnvGen2 rptEfectividad = new MOD_FACT_VTA.MOD_VTA.Reportes.ReporteODR.FrmRptEfectividadComparativaEnvGen2()
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen
            };
            rptEfectividad.Show();
        }

        private void ResumenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_FACT_VTA.MOD_VTA.FrmResumenSeguimientoPlanilla rptEfectividad = new MOD_FACT_VTA.MOD_VTA.FrmResumenSeguimientoPlanilla(AÑO, MES)
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen
            };
            rptEfectividad.Show();
        }

        private void reporteTelefonicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_FACT_VTA.MOD_VTA.REPORTE_TELEFONICO frm = new MOD_FACT_VTA.MOD_VTA.REPORTE_TELEFONICO(AÑO, MES, FECHA_INI, FECHA_GRAL, COD_MOD, TIPO_USU, COD_USU);
            frm.MdiParent = this;
            frm.Show();
        }

        private void ingresosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_FACT_VTA.MOD_VTA.PREVENTA_META frm = new MOD_FACT_VTA.MOD_VTA.PREVENTA_META(AÑO, MES, FECHA_INI, FECHA_GRAL, COD_MOD, TIPO_USU, COD_USU);
            frm.MdiParent = this;
            frm.Show();
        }

        private void consultaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MOD_FACT_VTA.MOD_VTA.CONSULTA_METAS frm = new MOD_FACT_VTA.MOD_VTA.CONSULTA_METAS(AÑO, MES, FECHA_INI, FECHA_GRAL, COD_MOD, TIPO_USU, COD_USU);
            frm.MdiParent = this;
            frm.Show();
        }

        private void AtendidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_FACT_VTA.MOD_VTA.Reportes.FormRep.REPORTE_CONTRATOS_REGISTRADOS frm = new MOD_FACT_VTA.MOD_VTA.Reportes.FormRep.REPORTE_CONTRATOS_REGISTRADOS();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuPreventaPlanillaPeriodoActual_Click(object sender, EventArgs e)
        {
            pedido2 = new Presentacion.MOD_VTA.PEDIDO2(AÑO, MES, FECHA_INI, FECHA_GRAL, COD_MOD, TIPO_USU, COD_USU, this);
            pedido2.MdiParent = this;
            pedido2.Show();
        }

        private void mnuPreventaPlanillaTodosPeriodos_Click(object sender, EventArgs e)
        {

        }

        private void controlDeCalidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_FACT_VTA.MOD_VTA.Reportes.FormularioRep.REPORTE_CONTROL_CALIDAD_CONTRATOS frm = new MOD_FACT_VTA.MOD_VTA.Reportes.FormularioRep.REPORTE_CONTROL_CALIDAD_CONTRATOS(AÑO, MES, FECHA_GRAL);
            frm.MdiParent = this;
            frm.Show();
        }


    }
}
