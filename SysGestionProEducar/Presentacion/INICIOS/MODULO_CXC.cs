using System;
using System.Data;
using System.Windows.Forms;

namespace Presentacion.INICIOS
{
    public partial class MODULO_CXC : Form
    {
        string AÑO = "", MES = "", COD_MOD, TIPO_USU, COD_USU, NOM_EMPRESA, NOM_USU;
        DateTime FECHA_INI, FECHA_GRAL;
        public MODULO_CXC(string AÑO, string MES, DateTime FECHA_INI, DateTime FECHA_GRAL, string COD_MOD,string TIPO_USU,string COD_USU,string NOM_EMPRESA,string NOM_USU)
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
        private void MODULO_CXC_Load(object sender, EventArgs e)
        {
            tsstlUsuario.Text = NOM_USU;
            tsslEmpresa.Text = NOM_EMPRESA;
            tsslProceso.Text = FECHA_GRAL.Date.ToShortDateString();
        }
        private void CanjeDocumentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MOD_CXC.CANJE_DOC_CXC frm = new MOD_CXC.CANJE_DOC_CXC(AÑO, MES, FECHA_INI, FECHA_GRAL, COD_MOD, TIPO_USU, COD_USU);
            //frm.MdiParent = this;
            //frm.Show();
        }

        private void SalirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void GeneraciónDirectaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void MODULO_CXC_Activated(object sender, EventArgs e)
        {
            tsstlUsuario.Text = "AUTOR";
            tsslEmpresa.Text = "EDICIONES AMERICANAS";
            tsslProceso.Text = FECHA_GRAL.Date.ToShortDateString();
        }
        private void llamadasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_CXC.PLANILLA_DIRECTA_LLAMADAS frm = new MOD_CXC.PLANILLA_DIRECTA_LLAMADAS(AÑO, MES, FECHA_INI, FECHA_GRAL, COD_MOD, TIPO_USU, COD_USU, "P");
            frm.MdiParent = this;
            frm.Show();
        }

        private void cierreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_CXC.CIERRE_PLANILLA_DIRECTA frm = new MOD_CXC.CIERRE_PLANILLA_DIRECTA(AÑO, MES, FECHA_INI, FECHA_GRAL, COD_MOD, TIPO_USU, COD_USU, "P");
            frm.MdiParent = this;
            frm.Show();
        }

        private void confirmacionPagoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_CXC.PLANILLA_DIRECTA_CANCELACION frm = new MOD_CXC.PLANILLA_DIRECTA_CANCELACION(COD_USU, "D");
            frm.MdiParent = this;
            frm.Show();
        }
        private void cobranzaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_CXC.PLANILLA_DIRECTA_COBRANZA frm = new MOD_CXC.PLANILLA_DIRECTA_COBRANZA(COD_USU);
            frm.MdiParent = this;
            frm.Show();
        }

        private void calendarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_CXC.PLANILLA_DIRECTA_FERIADOS frm = new MOD_CXC.PLANILLA_DIRECTA_FERIADOS(AÑO, MES, FECHA_INI, FECHA_GRAL, COD_MOD, TIPO_USU, COD_USU, "P");
            frm.MdiParent = this;
            frm.Show();
        }

        private void transferenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_CXC.TRANSFERENCIA_PLANILLA_DIRECTA_DESCUENTO frm = new MOD_CXC.TRANSFERENCIA_PLANILLA_DIRECTA_DESCUENTO(COD_USU);
            frm.MdiParent = this;
            frm.Show();
        }

        private void planillaDeCobranzaInternaEnviadaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string titulo = "Planilla de Cobranza Interna - Enviada";
            int op = 1;
            MOD_CXC.Reportes.FormRep.PLANILLA_COBRANZA_INTERNA_ENVIADA_DETALLE frm = new MOD_CXC.Reportes.FormRep.PLANILLA_COBRANZA_INTERNA_ENVIADA_DETALLE(titulo,op,AÑO,MES);
            frm.MdiParent = this;
            frm.Show();
        }
        
        private void planillaDeCobranzaInternaEjecutadaDetalladaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string titulo = "Planilla de Cobranza Interna - Ejecutada";
            int op = 2;
            MOD_CXC.Reportes.FormRep.PLANILLA_COBRANZA_INTERNA_ENVIADA_DETALLE frm = new MOD_CXC.Reportes.FormRep.PLANILLA_COBRANZA_INTERNA_ENVIADA_DETALLE(titulo,op,AÑO,MES);
            frm.MdiParent = this;
            frm.Show();
        }
        private void planilaDeCobranzaInternaEjecutadaResumenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string titulo = "Planilla de Cobranza Interna - Ejecutada (Resumen)";
            int op = 3;
            MOD_CXC.Reportes.FormRep.PLANILLA_COBRANZA_INTERNA_ENVIADA_DETALLE frm = new MOD_CXC.Reportes.FormRep.PLANILLA_COBRANZA_INTERNA_ENVIADA_DETALLE(titulo, op,AÑO,MES);
            frm.MdiParent = this;
            frm.Show();
        }
        private void mnuPlanillasGenracion_Click(object sender, EventArgs e)
        {
            MOD_CXC.GENERACION_I_PLANILLAS frm = new MOD_CXC.GENERACION_I_PLANILLAS(AÑO, MES, FECHA_INI, FECHA_GRAL, COD_MOD, TIPO_USU, COD_USU);
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuPlanillasEnvio_Click(object sender, EventArgs e)
        {
            
        }

        private void mnuPlanillasRecepcion_Click(object sender, EventArgs e)
        {
            MOD_CXC.RECEPCION_I_PLANILLAS frm = new MOD_CXC.RECEPCION_I_PLANILLAS(AÑO, MES, FECHA_INI, FECHA_GRAL, COD_MOD, TIPO_USU, COD_USU);
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuPlanillasCancelacion_Click(object sender, EventArgs e)
        {
            MOD_CXC.CANCELACION_I_PLANILLA frm = new MOD_CXC.CANCELACION_I_PLANILLA(AÑO, MES, FECHA_INI, FECHA_GRAL, COD_MOD, TIPO_USU, COD_USU);
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuPlanillasConsulta_Click(object sender, EventArgs e)
        {
            MOD_CXC.CONSULTA_COBRANZA_I_PLANILLA frm = new MOD_CXC.CONSULTA_COBRANZA_I_PLANILLA(AÑO, MES, FECHA_INI, FECHA_GRAL, COD_MOD, TIPO_USU, COD_USU);
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuDescuentoDirectaCalendario_Click(object sender, EventArgs e)
        {
            MOD_CXC.PLANILLA_DIRECTA_FERIADOS frm = new MOD_CXC.PLANILLA_DIRECTA_FERIADOS(AÑO, MES, FECHA_INI, FECHA_GRAL, COD_MOD, TIPO_USU, COD_USU, "D");
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuDescuentoDirectaCierre_Click(object sender, EventArgs e)
        {
            MOD_CXC.CIERRE_DESCUENTO_DIRECTA frm = new MOD_CXC.CIERRE_DESCUENTO_DIRECTA(AÑO, MES, FECHA_INI, FECHA_GRAL, COD_MOD, TIPO_USU, COD_USU, "D");
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuDescuentoDirectaLlamadas_Click(object sender, EventArgs e)
        {
            MOD_CXC.I_LLAMADAS_COBRANZA_DIRECTA frm = new MOD_CXC.I_LLAMADAS_COBRANZA_DIRECTA(AÑO, MES, FECHA_INI, FECHA_GRAL, COD_MOD, TIPO_USU, COD_USU);
            frm.MdiParent = this;
            frm.Show();

        }

        private void mnuTransferenciaDocumentos_Click(object sender, EventArgs e)
        {
            MOD_CXC.TRANSFERENCIA_DOCUMENTO_VENCIDOS_DIRECTA frm = new MOD_CXC.TRANSFERENCIA_DOCUMENTO_VENCIDOS_DIRECTA(AÑO, MES, FECHA_INI, FECHA_GRAL, COD_MOD, TIPO_USU, COD_USU);
            frm.MdiParent = this;
            frm.Show();
        }

        private void verificacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_CXC.I_LLAMADAS_VERIFICACION frm = new MOD_CXC.I_LLAMADAS_VERIFICACION(AÑO, MES, FECHA_INI, FECHA_GRAL, COD_MOD, TIPO_USU, COD_USU);
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuResumenPlanillaR_Click(object sender, EventArgs e)
        {
            MOD_CXC.I_LLAMADAS_R_PLANILLA frm = new MOD_CXC.I_LLAMADAS_R_PLANILLA(AÑO, MES, FECHA_INI, FECHA_GRAL, COD_MOD, TIPO_USU, COD_USU);
            frm.MdiParent = this;
            frm.Show();
        }

        private void porBloqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_CXC.CANJE_DOC_CXC_X_BLOQUE frm = new MOD_CXC.CANJE_DOC_CXC_X_BLOQUE(AÑO, MES, FECHA_INI, FECHA_GRAL, COD_MOD, TIPO_USU, COD_USU);
            frm.MdiParent = this;
            frm.Show();
        }

        private void individualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_CXC.CANJE_DOC_CXC frm = new MOD_CXC.CANJE_DOC_CXC(AÑO, MES, FECHA_INI, FECHA_GRAL, COD_MOD, TIPO_USU, COD_USU);
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuInformativos_Click(object sender, EventArgs e)
        {
            MOD_CXC.PLANILLA_DESCUENTO_INFORMATIVA frm = new MOD_CXC.PLANILLA_DESCUENTO_INFORMATIVA(AÑO, MES, FECHA_INI, FECHA_GRAL, COD_MOD, TIPO_USU, COD_USU);
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuEstadoCuentaKardexCliente_Click(object sender, EventArgs e)
        {
            MOD_CXC.CONSULTA_ESTADO_CUENTA_KARDEX_CLIENTE frm = new MOD_CXC.CONSULTA_ESTADO_CUENTA_KARDEX_CLIENTE(AÑO, MES, FECHA_INI, FECHA_GRAL);
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuEstadoCuentaCuotasComprometidasPlanillasEnviadas_Click(object sender, EventArgs e)
        {
            MOD_CXC.CONSULTA_ESTADO_CUENTA_CUOTAS_COMPROMETIDAS_EN_PLANILLAS_ENVIADAS frm = new MOD_CXC.CONSULTA_ESTADO_CUENTA_CUOTAS_COMPROMETIDAS_EN_PLANILLAS_ENVIADAS();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuGeneracionPllaDescuento_Click(object sender, EventArgs e)
        {
            
        }

        private void inputOtrasDevDescMenuItem_Click(object sender, EventArgs e)
        {
            MOD_CXC.INPUT_PARA_HACER_DEVOLUCIONES frm = new MOD_CXC.INPUT_PARA_HACER_DEVOLUCIONES(AÑO, MES, FECHA_INI, FECHA_GRAL, COD_MOD, TIPO_USU, COD_USU);
            frm.MdiParent = this;
            frm.Show();
        }

        private void generacionOtrasDevolucionesYDescuentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_CXC.GENERACION_PLANILLAS_OTRAS_DEV_DSCTOS frm = new MOD_CXC.GENERACION_PLANILLAS_OTRAS_DEV_DSCTOS(AÑO, MES, FECHA_INI, FECHA_GRAL, COD_MOD, TIPO_USU, COD_USU);
            frm.MdiParent = this;
            frm.Show();
        }

        private void generacionDePlanillasDirectasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_CXC.GENERACION_PLANILLAS_DESCUENTO_DIRECTA frm = new MOD_CXC.GENERACION_PLANILLAS_DESCUENTO_DIRECTA(AÑO, MES, FECHA_INI, FECHA_GRAL, COD_MOD, TIPO_USU, COD_USU);
            frm.MdiParent = this;
            frm.Show();
        }

        private void contratosSuspendidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_CXC.CONTRATOS_SUSPENDIDOS frm = new MOD_CXC.CONTRATOS_SUSPENDIDOS(AÑO, MES, FECHA_INI, FECHA_GRAL, COD_MOD, TIPO_USU, COD_USU);
            frm.MdiParent = this;
            frm.Show();
        }

        private void EfectividadComparativaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_CXC.Reportes.Formulario.FrmRptEfectividadComparativa frm = new MOD_CXC.Reportes.Formulario.FrmRptEfectividadComparativa()
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen
            };
            frm.Show();
        }

        private void mnuCambioPtoCob_Click(object sender, EventArgs e)
        {
            //MOD_CXC.MANTENIMIENTO_CAMBIO_PUNTO_COBRANZA frm = new MOD_CXC.MANTENIMIENTO_CAMBIO_PUNTO_COBRANZA(AÑO,MES,COD_USU,FECHA_INI,FECHA_GRAL);
            //frm.MdiParent = this;
            //frm.Show();
        }

        private void institucionPorClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_CXC.Reportes.Formulario.FrmRptInstitucionXCliente1 frm = new MOD_CXC.Reportes.Formulario.FrmRptInstitucionXCliente1()
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen
            };
            frm.Show();
        }

        private void reporteDePlanillaPorTiposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_CXC.Reportes.Formulario.FrmReportePlanillaTipos frm = new MOD_CXC.Reportes.Formulario.FrmReportePlanillaTipos()
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen
            };
            frm.Show();
        }

        private void DetalleContratosFechIdenPagoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_CXC.Reportes.Formulario.FrmRptDetalladoContratosIdentificadoPago frmReporte = new MOD_CXC.Reportes.Formulario.FrmRptDetalladoContratosIdentificadoPago
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen
            };
            frmReporte.Show();
        }

        private void cuentasPorCobrarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            MOD_CXC.Reportes.Formulario.REPORTE_DE_CTAS_X_COBRAR frmReporteCtasCobrar = new MOD_CXC.Reportes.Formulario.REPORTE_DE_CTAS_X_COBRAR()
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen
            };
            frmReporteCtasCobrar.Show();
        }

        private void proyecciónCuentasXCobrarMesVencidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_CXC.Reportes.Formulario.REPORTE_DE_PROYECCION_DE_COBRANZAS frmReporteCtasCobrar = new MOD_CXC.Reportes.Formulario.REPORTE_DE_PROYECCION_DE_COBRANZAS(AÑO, MES)
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen
            };
            frmReporteCtasCobrar.Show();
        }

        private void carteraTotalProyectadaAUnMesCuotaMásAntiguaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_CXC.Reportes.Formulario.REPORTE_CARTERA_TOTAL_PROYECTADA frmReporteCtasCobrar = new MOD_CXC.Reportes.Formulario.REPORTE_CARTERA_TOTAL_PROYECTADA(AÑO, MES)
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen
            };
            frmReporteCtasCobrar.Show();
        }

        private void análisisCarteraXTrabajarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_FACT_VTA.MOD_VTA.Reportes.FormularioRep.FrmAnalisisCarteraXTrabajar frm = new MOD_FACT_VTA.MOD_VTA.Reportes.FormularioRep.FrmAnalisisCarteraXTrabajar()
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen
            };
            frm.Show();
        }

        private void MovimientoCarteraXUbicaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_CXC.Reportes.Formulario.REPORTE_DE_COBRANZA_X_UBICACION frm = new MOD_CXC.Reportes.Formulario.REPORTE_DE_COBRANZA_X_UBICACION();
            frm.MdiParent = this;
            frm.Show();
        }

        private void generacionDePlanillasDirectaVariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_CXC.PLANILLA_DIRECTA_VARIOS frm = new MOD_CXC.PLANILLA_DIRECTA_VARIOS(AÑO, MES, FECHA_INI, FECHA_GRAL, COD_MOD, TIPO_USU, COD_USU);
            frm.MdiParent = this;
            frm.Show();
        }

        private void cambioDeUbicacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_CXC.Reportes.FormRep.REPORTE_CAMBIO_DE_UBICACION_I frm = new MOD_CXC.Reportes.FormRep.REPORTE_CAMBIO_DE_UBICACION_I();
            frm.MdiParent = this;
            frm.Show();
        }

        private void ingresoDatosPlanillasNoTransferidasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MOD_CXC.INGRESO_PLLAS_NO_TRANSFERIDAS frm = new MOD_CXC.INGRESO_PLLAS_NO_TRANSFERIDAS(AÑO, MES, FECHA_INI, FECHA_GRAL, COD_MOD, TIPO_USU, COD_USU);
            //frm.MdiParent = this;
            //frm.Show();
        }

        private void envioDePlanillasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_CXC.ENVIO_I_PLANILLAS frm = new MOD_CXC.ENVIO_I_PLANILLAS(AÑO, MES, FECHA_INI, FECHA_GRAL, COD_MOD, TIPO_USU, COD_USU);
            frm.MdiParent = this;
            frm.Show();
        }

        private void configuracionDePlanillasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MOD_CXC.CONFIGURACION_ARCHIVOS_ENVIAR frm = new MOD_CXC.CONFIGURACION_ARCHIVOS_ENVIAR(AÑO, MES, FECHA_INI, FECHA_GRAL, COD_MOD, TIPO_USU, COD_USU);
            //frm.MdiParent = this;
            //frm.Show();
        }

        private void reToolStripMenuItem_Click(object sender, EventArgs e)
        {

           // MOD_CXC.Reportes.Formulario.FrmCancelacionXPlanilla frm = new MOD_CXC.Reportes.Formulario.FrmCancelacionXPlanilla()
           // {
            //    MdiParent = this,
            //    StartPosition = FormStartPosition.CenterScreen
           // };
            //frm.Show();
        }
    }
}
