using System;
using System.Windows.Forms;

namespace Presentacion.MOD_VTA
{
    public partial class MODULO_CXP : Form
    {
        string AÑO = "", MES = "", COD_MOD, TIPO_USU, COD_USU, NOM_EMPRESA, NOM_USU;
        DateTime FECHA_INI, FECHA_GRAL;
        public MODULO_CXP(string AÑO, string MES, DateTime FECHA_INI, DateTime FECHA_GRAL, string COD_MOD, string TIPO_USU, string COD_USU, string NOM_EMPRESA, string NOM_USU)
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
        private void MODULO_CXP_Load(object sender, EventArgs e)
        {
            tsstlUsuario.Text = NOM_USU;
            tsslEmpresa.Text = NOM_EMPRESA;
            tsslProceso.Text = FECHA_GRAL.Date.ToShortDateString();
        }
        private void LetrasPendientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //CONSULTAS.CONSULTA_LETRAS frm = new CONSULTAS.CONSULTA_LETRAS();
            MOD_COMISIONES.CONSULTA_COMISIONES_PENDIENTES_X_LIQUIDAR frm = new MOD_COMISIONES.CONSULTA_COMISIONES_PENDIENTES_X_LIQUIDAR();
            frm.MdiParent = this;
            frm.Show();
        }

        private void DocumentosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //CONSULTAS.CONSULTA_CXP1 frm = new CONSULTAS.CONSULTA_CXP1();
            MOD_COMISIONES.CONSULTA_COMISIONES_HISTORICO frm = new MOD_COMISIONES.CONSULTA_COMISIONES_HISTORICO();
            frm.MdiParent = this;
            frm.Show();
        }

        private void KardexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            REPORTES.FORM_REPORTES.REPORTE_KARDEX frm = new REPORTES.FORM_REPORTES.REPORTE_KARDEX();
            frm.MdiParent = this;
            frm.Show();
        }

        private void PendientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            REPORTES.FORM_REPORTES.REPORTE_PTE_GRAL frm = new REPORTES.FORM_REPORTES.REPORTE_PTE_GRAL();
            frm.MdiParent = this;
            frm.Show();
        }

        private void CanceladasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            REPORTES.FORM_REPORTES.REPORTE_CANC_COB frm = new REPORTES.FORM_REPORTES.REPORTE_CANC_COB();
            frm.MdiParent = this;
            frm.Show();

        }

        private void GeneraciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            REPORTES.FORM_REPORTES.REPORTE_GENERACION frm = new REPORTES.FORM_REPORTES.REPORTE_GENERACION();
            frm.MdiParent = this;
            frm.Show();
        }

        private void PagosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            REPORTES.FORM_REPORTES.REPORTE_PAGOS frm = new REPORTES.FORM_REPORTES.REPORTE_PAGOS();
            frm.MdiParent = this;
            frm.Show();
        }

        private void comisionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_COMISIONES.MAESTRO_COMISIONES frm = new MOD_COMISIONES.MAESTRO_COMISIONES(AÑO, MES, FECHA_INI, FECHA_GRAL, COD_MOD, TIPO_USU, COD_USU);
            frm.MdiParent = this;
            frm.Show();
        }

        private void consultaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_COMISIONES.CONSULTA_MAESTRO_COMISIONES frm = new MOD_COMISIONES.CONSULTA_MAESTRO_COMISIONES();
            frm.MdiParent = this;
            frm.Show();
        }

        private void DescuadreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_COMISIONES.ATENCION_CLIENTES_INGRESO frm = new MOD_COMISIONES.ATENCION_CLIENTES_INGRESO();
            frm.Show();
        }

        private void seguimientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_COMISIONES.ATENCION_CLIENTE_SEGUIMIENTO frm = new MOD_COMISIONES.ATENCION_CLIENTE_SEGUIMIENTO();
            frm.MdiParent = this;
            frm.Show();
        }

        private void GeneraciónDirectaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_COMISIONES.GENERACION_COMISIONES frm = new MOD_COMISIONES.GENERACION_COMISIONES(AÑO, MES, FECHA_INI, FECHA_GRAL, COD_MOD, TIPO_USU, COD_USU);
            frm.MdiParent = this;
            frm.Show();
        }

        private void CajeroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_COMISIONES.LIQUIDACION_COMISIONES frm = new MOD_COMISIONES.LIQUIDACION_COMISIONES(AÑO, MES, FECHA_INI, FECHA_GRAL, COD_MOD, TIPO_USU, COD_USU);
            frm.MdiParent = this;
            frm.Show();
        }

        private void SalirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void resumenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_COMISIONES.RESUMEN_COMISIONES frm = new MOD_COMISIONES.RESUMEN_COMISIONES(AÑO, MES, FECHA_INI, FECHA_GRAL, COD_MOD, TIPO_USU, COD_USU);
            frm.MdiParent = this;
            frm.Show();
        }

        private void adelantosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_COMISIONES.ADELANTO_COMISIONES_X_COMISIONISTA frm = new MOD_COMISIONES.ADELANTO_COMISIONES_X_COMISIONISTA(AÑO, MES, FECHA_INI, FECHA_GRAL, COD_MOD, TIPO_USU, COD_USU);
            frm.MdiParent = this;
            frm.Show();
        }

        private void liquidacionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void generacionYDevolucionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ComisionesToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            MOD_COMISIONES.FrmComisiones frmComisiones = new MOD_COMISIONES.FrmComisiones()
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen
            };
            frmComisiones.Show();
        }

        private void AsociarConceptosLiquidaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_COMISIONES.FrmAsociarConceptosTesoreria frmAsociarConcepto = new MOD_COMISIONES.FrmAsociarConceptosTesoreria()
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen
            };
            frmAsociarConcepto.Show();
        }

        private void ReporteComisionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_COMISIONES.Reportes.Formulario.FrmRptComisionDetalle frmReporte = MOD_COMISIONES.Reportes.Formulario.FrmRptComisionDetalle.Instancia();
            frmReporte.StartPosition = FormStartPosition.CenterScreen;
            frmReporte.Show();
        }

        private void CalculoDeComisionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_COMISIONES.FrmProcesamientoComision frmComisiones = new MOD_COMISIONES.FrmProcesamientoComision()
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen
            };
            frmComisiones.Show();
        }

        private void DevolucionDeComisionesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MOD_COMISIONES.FrmGenerarDevolucionesComision frmGenerarDevolucionesComision = new MOD_COMISIONES.FrmGenerarDevolucionesComision()
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen
            };
            frmGenerarDevolucionesComision.Show();
        }

        private void AdelantoDeComisionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_COMISIONES.FrmAdelantoComision frmAdelantoComision = new MOD_COMISIONES.FrmAdelantoComision()
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen
            };
            frmAdelantoComision.Show();
        }

        private void OtrosIngresosYEgresosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_COMISIONES.FrmRegistroOtrosIngresosEgresosVendedores frmRegistroOtrosIngresosEgresosVendedores = new MOD_COMISIONES.FrmRegistroOtrosIngresosEgresosVendedores()
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen
            };
            frmRegistroOtrosIngresosEgresosVendedores.Show();
        }


        private void LiquidacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_COMISIONES.Reportes.Formulario.FrmRptLiquidaciones frmLiqu = new MOD_COMISIONES.Reportes.Formulario.FrmRptLiquidaciones()
            {
                StartPosition = FormStartPosition.CenterScreen,
                MdiParent = this
            };
            frmLiqu.Show();
        }

        private void ComisionesDetalleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_COMISIONES.Reportes.Formulario.FrmRptComisionDetalle frmComision = MOD_COMISIONES.Reportes.Formulario.FrmRptComisionDetalle.Instancia();
            frmComision.StartPosition = FormStartPosition.CenterScreen;
            frmComision.MdiParent = this;
            frmComision.Show();
        }

        private void ReportesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MOD_COMISIONES.Reportes.Formulario.FrmRptLiquidaciones frmLiqu = new MOD_COMISIONES.Reportes.Formulario.FrmRptLiquidaciones()
            {
                StartPosition = FormStartPosition.CenterScreen,
                MdiParent = this
            };
            frmLiqu.Show();
        }

        private void resumenToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void adelantosToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void devolucionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void devolucionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_COMISIONES.DEVOLUCION_COMISIONES_X_COMISIONISTA frm = new MOD_COMISIONES.DEVOLUCION_COMISIONES_X_COMISIONISTA(AÑO, MES, FECHA_INI, FECHA_GRAL, COD_MOD, TIPO_USU, COD_USU);
            frm.MdiParent = this;
            frm.Show();
        }

        private void otrosCargosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MOD_COMISIONES.OTROS_CARGOS_COMISIONES_X_COMISIONISTA frm = new MOD_COMISIONES.OTROS_CARGOS_COMISIONES_X_COMISIONISTA(AÑO, MES, FECHA_INI, FECHA_GRAL, COD_MOD, TIPO_USU, COD_USU);
            frm.MdiParent = this;
            frm.Show();
        }

        private void comisionesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MOD_COMISIONES.COMISION_COMISIONES_X_COMISIONISTA frm = new MOD_COMISIONES.COMISION_COMISIONES_X_COMISIONISTA(AÑO, MES, FECHA_INI, FECHA_GRAL, COD_MOD, TIPO_USU, COD_USU);
            frm.MdiParent = this;
            frm.Show();
        }

        private void búsquedaPorVendedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_COMISIONES.CONSULTA_COMISIONES_X_PERSONA frm = new MOD_COMISIONES.CONSULTA_COMISIONES_X_PERSONA();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
