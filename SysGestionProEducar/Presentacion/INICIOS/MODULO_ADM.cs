using System;
using System.Windows.Forms;

namespace Presentacion.MOD_VTA
{
    public partial class MODULO_ADM : Form
    {
        //private int childFormNumber = 0;
        string AÑO = "", MES = "", COD_MOD, TIPO_USU, COD_USU, NOM_EMPRESA, NOM_USU;//, con;
        DateTime FECHA_INI, FECHA_GRAL;
        public MODULO_ADM(string AÑO, string MES, DateTime FECHA_INI, DateTime FECHA_GRAL, string COD_MOD, string TIPO_USU, string COD_USU, string NOM_EMPRESA, string NOM_USU)
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
            //this.con = con;
        }
        private void MODULO_ADM_Load(object sender, EventArgs e)
        {
            tsstlUsuario.Text = NOM_USU;
            tsslEmpresa.Text = NOM_EMPRESA;
        }
        private void ArticuloToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MOD_ADM.ARTICULO_CLASE frm = new MOD_ADM.ARTICULO_CLASE();
            frm.MdiParent = this;
            frm.Show();
        }

        private void PersonaProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_ADM.PERSONA frm = new MOD_ADM.PERSONA(0, "");
            frm.MdiParent = this;
            frm.Show();
        }

        private void SucursalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_ADM.SUCURSAL frm = new MOD_ADM.SUCURSAL();
            frm.MdiParent = this;
            frm.Show();
        }

        private void ArtículoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            REPORTES.FORM_REPORTES.REPORTE_ARTICULO frm = new REPORTES.FORM_REPORTES.REPORTE_ARTICULO();
            frm.MdiParent = this;
            frm.Show();
        }

        private void PersonasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            REPORTES.FORM_REPORTES.REPORTE_PERSONAS frm = new REPORTES.FORM_REPORTES.REPORTE_PERSONAS();
            frm.MdiParent = this;
            frm.Show();
        }

        private void SucursalesToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            REPORTES.FORM_REP.REP_SUCURSAL frm = new REPORTES.FORM_REP.REP_SUCURSAL();
            frm.MdiParent = this;
            frm.Show();
        }

        private void InventarioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CONSULTAS.CONSULTA_T_INV_ACTUALIZA frm = new CONSULTAS.CONSULTA_T_INV_ACTUALIZA();
            frm.MdiParent = this;
            frm.Show();
        }

        private void GastosToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            CONSULTAS.CONSULTA_T_GASTO_ACTUALIZA frm = new CONSULTAS.CONSULTA_T_GASTO_ACTUALIZA();
            frm.MdiParent = this;
            frm.Show();
        }

        private void OrdenDeCompraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CONSULTAS.CONSULTA_T_OC_ACTUALIZA frm = new CONSULTAS.CONSULTA_T_OC_ACTUALIZA();
            frm.MdiParent = this;
            frm.Show();
        }

        private void FacturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CONSULTAS.CONSULTA_T_FACT_ACTUALIZA frm = new CONSULTAS.CONSULTA_T_FACT_ACTUALIZA();
            frm.MdiParent = this;
            frm.Show();
        }

        private void FacturaVtaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CONSULTAS.CONSULTA_T_FACT_VTA_ACTUALIZA frm = new CONSULTAS.CONSULTA_T_FACT_VTA_ACTUALIZA();
            frm.MdiParent = this;
            frm.Show();
        }
        /// <summary>
        /// ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CabeceraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_ADM.RECOVERY_CABECERA_PEDIDO frm = new MOD_ADM.RECOVERY_CABECERA_PEDIDO();
            frm.MdiParent = this;
            frm.Show();
        }

        private void DetalleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CONSULTAS.CONSULTA_T_PEDIDO_ACTUALIZA frm = new CONSULTAS.CONSULTA_T_PEDIDO_ACTUALIZA();
            frm.MdiParent = this;
            frm.Show();
        }
        private void PedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void SaldosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_ADM.M_ARTICULO frm = new MOD_ADM.M_ARTICULO();
            frm.MdiParent = this;
            frm.Show();
        }

        private void PresupuestoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CONSULTAS.CONSULTA_T_PRESUPUESTO_ACTUALIZA frm = new CONSULTAS.CONSULTA_T_PRESUPUESTO_ACTUALIZA();
            frm.MdiParent = this;
            frm.Show();
        }

        private void DepuraciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Z_NUEVO.HOY.DEPURACION frm = new Z_NUEVO.HOY.DEPURACION();
            frm.MdiParent = this;
            frm.Show();
        }

        private void TipoDeCambioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_ADM.Cambio frm = new MOD_ADM.Cambio();
            frm.MdiParent = this;
            frm.Show();
        }

        private void ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            MOD_ADM.CLASE_ARTICULO frm = new MOD_ADM.CLASE_ARTICULO();
            frm.MdiParent = this;
            frm.Show();
        }

        private void GrupoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_ADM.GRUPO_ARTICULO frm = new MOD_ADM.GRUPO_ARTICULO();
            frm.MdiParent = this;
            frm.Show();
        }

        private void SubGrupoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_ADM.SUBGRUPO_ARTICULO frm = new MOD_ADM.SUBGRUPO_ARTICULO();
            frm.MdiParent = this;
            frm.Show();
        }

        private void UnidadDeMedidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_ADM.UNIDAD_MEDIDA frm = new MOD_ADM.UNIDAD_MEDIDA();
            frm.MdiParent = this;
            frm.Show();
        }

        private void VentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_ADM.ARTICULO_DETALLE frm = new MOD_ADM.ARTICULO_DETALLE();
            frm.MdiParent = this;
            frm.Show();
        }

        private void CompraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_ADM.ARTICULO_DETALLE_PROVEEDOR frm = new MOD_ADM.ARTICULO_DETALLE_PROVEEDOR();
            frm.MdiParent = this;
            frm.Show();
        }

        private void EquivalenteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MOD_ADM.EQUIVALENTE frm = new MOD_ADM.EQUIVALENTE();
            frm.MdiParent = this;
            frm.Show();
        }

        private void KitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_ADM.KIT frm = new MOD_ADM.KIT();
            frm.MdiParent = this;
            frm.Show();
        }

        private void TipoAlmacénToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_ADM.TIPO_ALMACEN frm = new MOD_ADM.TIPO_ALMACEN();
            frm.MdiParent = this;
            frm.Show();
        }

        private void AlmacénToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MOD_ADM.ALMACENES frm = new MOD_ADM.ALMACENES();
            frm.MdiParent = this;
            frm.Show();
        }

        private void AlmacénTercerosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_ADM.ALMACENES_TER frm = new MOD_ADM.ALMACENES_TER();
            frm.MdiParent = this;
            frm.Show();
        }

        private void TipoDocumentoEmpresaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_ADM.TIPO_DOCUMENTO_INV frm = new MOD_ADM.TIPO_DOCUMENTO_INV();
            frm.MdiParent = this;
            frm.Show();
        }

        private void SerieDocumentoEmpresaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_ADM.SERIE_DOCUMENTOS frm = new MOD_ADM.SERIE_DOCUMENTOS();
            frm.MdiParent = this;
            frm.Show();
        }

        private void ConfiguracionOpcionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_ADM.CONFIGURACION frm = new MOD_ADM.CONFIGURACION();
            frm.MdiParent = this;
            frm.Show();
        }

        private void CuentasBancariasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MOD_ADM.CUENTAS_BANCARIAS frm = new MOD_ADM.CUENTAS_BANCARIAS();
            frm.MdiParent = this;
            frm.Show();
        }

        private void ConceptosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MOD_ADM.CONCEPTO frm = new MOD_ADM.CONCEPTO();
            frm.MdiParent = this;
            frm.Show();
        }

        private void CentroDeCostosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MOD_ADM.AREA frm = new MOD_ADM.AREA();
            frm.MdiParent = this;
            frm.Show();
        }

        private void ProyectosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_ADM.PROYECTO frm = new MOD_ADM.PROYECTO();
            frm.MdiParent = this;
            frm.Show();
        }

        private void OrdenDeProducciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_ADM.ORDEN_PRODUCCION frm = new MOD_ADM.ORDEN_PRODUCCION();
            frm.MdiParent = this;
            frm.Show();
        }

        private void CargosDescuentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_ADM.CARGOS_DSCTO frm = new MOD_ADM.CARGOS_DSCTO();
            frm.MdiParent = this;
            frm.Show();
        }

        private void ActividadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_ADM.ACTIVIDAD frm = new MOD_ADM.ACTIVIDAD();
            frm.MdiParent = this;
            frm.Show();
        }

        private void ConceptoDistribuciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_ADM.CPTO_PORCENTAJE frm = new MOD_ADM.CPTO_PORCENTAJE();
            frm.MdiParent = this;
            frm.Show();
        }

        private void CobranzaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_ADM.CONCEPTO_COBRANZA frm = new MOD_ADM.CONCEPTO_COBRANZA();
            frm.MdiParent = this;
            frm.Show();
        }

        private void EquipoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_ADM.EQUIPO_VENTA frm = new MOD_ADM.EQUIPO_VENTA();
            frm.MdiParent = this;
            frm.Show();
        }

        private void PersonaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_ADM.PERSONA_VENTA frm = new MOD_ADM.PERSONA_VENTA();
            frm.MdiParent = this;
            frm.Show();
        }

        private void CargosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_ADM.CARGOS_VENTA frm = new MOD_ADM.CARGOS_VENTA();
            frm.MdiParent = this;
            frm.Show();
        }

        private void TransportistaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MOD_ADM.TRANSPORTISTA frm = new MOD_ADM.TRANSPORTISTA();
            frm.MdiParent = this;
            frm.Show();
        }

        private void TipoVehículoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MOD_ADM.TIPO_VEHICULO frm = new MOD_ADM.TIPO_VEHICULO();
            frm.MdiParent = this;
            frm.Show();
        }

        private void TipoTrasladoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_ADM.MOTIVO_TRASLADO frm = new MOD_ADM.MOTIVO_TRASLADO();
            frm.MdiParent = this;
            frm.Show();
        }

        private void AgenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_ADM.AGENCIA frm = new MOD_ADM.AGENCIA();
            frm.MdiParent = this;
            frm.Show();
        }

        private void LugarEntregaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_ADM.LUGAR_ENTREGA frm = new MOD_ADM.LUGAR_ENTREGA();
            frm.MdiParent = this;
            frm.Show();
        }

        private void GastosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MOD_ADM.CTA_GASTOS frm = new MOD_ADM.CTA_GASTOS();
            frm.MdiParent = this;
            frm.Show();
        }

        private void InventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_ADM.CTA_INVENTARIO frm = new MOD_ADM.CTA_INVENTARIO();
            frm.MdiParent = this;
            frm.Show();
        }

        private void InventarioVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_ADM.CTA_INV_VTA frm = new MOD_ADM.CTA_INV_VTA();
            frm.MdiParent = this;
            frm.Show();
        }

        private void CajaChicaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_ADM.FFIJO_REND frm = new MOD_ADM.FFIJO_REND();
            frm.MdiParent = this;
            frm.Show();
        }

        private void ToolStripMenuItem12_Click(object sender, EventArgs e)
        {
            MOD_ADM.DIRECTORIO frm = new MOD_ADM.DIRECTORIO();
            frm.MdiParent = this;
            frm.Show();
        }

        private void ConceptosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void CentroCostosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            REPORTES.FORM_REPORTES.REPORTE_CC frm = new REPORTES.FORM_REPORTES.REPORTE_CC();
            frm.MdiParent = this;
            frm.Show();
        }

        private void ClasesGruposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            REPORTES.FORM_REPORTES.REPORTE_GRUPO frm = new REPORTES.FORM_REPORTES.REPORTE_GRUPO();
            frm.MdiParent = this;
            frm.Show();
        }

        private void CuentasGastosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            REPORTES.FORM_REPORTES.REPORTES_CUENTAS frm = new REPORTES.FORM_REPORTES.REPORTES_CUENTAS();
            frm.MdiParent = this;
            frm.Show();
        }

        private void MovimientosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void OpcionesDeMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_ADM.FORMULARIO frm = new MOD_ADM.FORMULARIO();
            frm.MdiParent = this;
            frm.Show();
        }

        private void GdgToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_ADM.PERIODO frm = new MOD_ADM.PERIODO(1000);
            frm.MdiParent = this;
            frm.Show();
        }

        private void ToolStripMenuItem9_Click(object sender, EventArgs e)
        {
            //MOD_ADM.PERIODO frm = new MOD_ADM.PERIODO(1);
            MOD_ADM.PERIODO_COSTOS frm = new MOD_ADM.PERIODO_COSTOS(1, COD_USU);
            frm.MdiParent = this;
            frm.Show();
        }

        private void PeríodoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //MOD_ADM.PERIODO frm = new MOD_ADM.PERIODO(2);
            MOD_ADM.PERIODO_COSTOS frm = new MOD_ADM.PERIODO_COSTOS(2, COD_USU);
            frm.MdiParent = this;
            frm.Show();
        }

        private void ErToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MOD_ADM.PERIODO frm = new MOD_ADM.PERIODO(3);
            MOD_ADM.PERIODO_COSTOS frm = new MOD_ADM.PERIODO_COSTOS(3, COD_USU);
            frm.MdiParent = this;
            frm.Show();
        }

        private void FactDeComprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MOD_ADM.PERIODO frm = new MOD_ADM.PERIODO(5);
            MOD_ADM.PERIODO_COSTOS frm = new MOD_ADM.PERIODO_COSTOS(5, COD_USU);
            frm.MdiParent = this;
            frm.Show();
        }

        private void FactDeVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MOD_ADM.PERIODO frm = new MOD_ADM.PERIODO(6);
            MOD_ADM.PERIODO_COSTOS frm = new MOD_ADM.PERIODO_COSTOS(6, COD_USU);
            frm.MdiParent = this;
            frm.Show();
        }

        private void CierrePeriodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_ADM.PERIODO_CIERRE frm = new MOD_ADM.PERIODO_CIERRE();
            frm.MdiParent = this;
            frm.Show();
        }

        private void SucursalesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MOD_ADM.USU_SUCURSALES frm = new MOD_ADM.USU_SUCURSALES();
            frm.MdiParent = this;
            frm.Show();
        }

        private void ClasesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_ADM.USU_CLASE frm = new MOD_ADM.USU_CLASE();
            frm.MdiParent = this;
            frm.Show();
        }

        private void ModulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_ADM.USU_MODULO frm = new MOD_ADM.USU_MODULO();
            frm.MdiParent = this;
            frm.Show();
        }

        private void AreasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_ADM.USU_AREAS frm = new MOD_ADM.USU_AREAS();
            frm.MdiParent = this;
            frm.Show();
        }

        private void PorFormularioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_ADM.USU_FORM frm = new MOD_ADM.USU_FORM();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuVisorEventos_Click(object sender, EventArgs e)
        {
            MOD_ADM.frmVerLog frm = new MOD_ADM.frmVerLog();
            frm.MdiParent = this;
            frm.Show();
        }



        private void MantenimientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_ADM.MANTENIMIENTO_FORMULARIO_SEGURIDAD frm = new MOD_ADM.MANTENIMIENTO_FORMULARIO_SEGURIDAD();
            frm.MdiParent = this;
            frm.Show();
        }

        private void ConsultaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_ADM.CONSULTA_FORMULARIO_SEGURIDAD frm = new MOD_ADM.CONSULTA_FORMULARIO_SEGURIDAD();
            frm.MdiParent = this;
            frm.Show();
        }

        private void CargosClientestoolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_ADM.CARGOS_CLIENTES frm = new MOD_ADM.CARGOS_CLIENTES();
            frm.MdiParent = this;
            frm.Show();
        }

        private void institucionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_ADM.INSTITUCIONES frm = new MOD_ADM.INSTITUCIONES();
            frm.MdiParent = this;
            frm.Show();
        }

        private void TiposdeViviendatoolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_ADM.TIPOS_VIVIENDA frm = new MOD_ADM.TIPOS_VIVIENDA();
            frm.MdiParent = this;
            frm.Show();
        }

        private void ProgramatoolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_ADM.PROGRAMA frm = new MOD_ADM.PROGRAMA();
            frm.MdiParent = this;
            frm.Show();
        }

        private void CanalDescuentotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_ADM.CANAL_DESCUENTO frm = new MOD_ADM.CANAL_DESCUENTO();
            frm.MdiParent = this;
            frm.Show();
        }

        private void PuntoCobranzatoolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_ADM.PUNTO_COBRANZA_GENERAR frm = new MOD_ADM.PUNTO_COBRANZA_GENERAR(AÑO, MES, FECHA_INI, FECHA_GRAL, COD_MOD, TIPO_USU, COD_USU);
            frm.MdiParent = this;
            frm.Show();
        }

        private void equiposDeVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void supervisorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_ADM.SUPERVISOR_EQ_VTA frm = new MOD_ADM.SUPERVISOR_EQ_VTA();
            frm.MdiParent = this;
            frm.Show();
        }



        private void directorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_ADM.DIRECTOR_EQ_VTA frm = new MOD_ADM.DIRECTOR_EQ_VTA();
            frm.MdiParent = this;
            frm.Show();
        }

        private void vendedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_ADM.VENDEDOR_EQ_VTA frm = new MOD_ADM.VENDEDOR_EQ_VTA();
            frm.MdiParent = this;
            frm.Show();
        }

        private void detalleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //MOD_ADM.PUNTO_COBRANZA_GENERAR frm = new MOD_ADM.PUNTO_COBRANZA_GENERAR(AÑO, MES, FECHA_INI, FECHA_GRAL, COD_MOD, TIPO_USU, COD_USU);
            //frm.MdiParent = this;
            //frm.Show();
        }

        private void consolidadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MOD_ADM.PUNTO_COBRANZA_CONSOLIDADOS frm = new MOD_ADM.PUNTO_COBRANZA_CONSOLIDADOS();
            //frm.MdiParent = this;
            //frm.Show();
        }

        private void CuentasPorCobrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MOD_ADM.PERIODO frm = new MOD_ADM.PERIODO(4);
            MOD_ADM.PERIODO_COSTOS frm = new MOD_ADM.PERIODO_COSTOS(4, COD_USU);
            frm.MdiParent = this;
            frm.Show();
        }

        private void ToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            MOD_ADM.MOVIMIENTOS frm = new MOD_ADM.MOVIMIENTOS();
            frm.MdiParent = this;
            frm.Show();
        }

        private void vendedorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MOD_ADM.VENDEDOR frm = new MOD_ADM.VENDEDOR();
            frm.MdiParent = this;
            frm.Show();
        }

        private void nivelProgramaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_ADM.EQUIPOS_DE_VENTA frm = new MOD_ADM.EQUIPOS_DE_VENTA();
            frm.MdiParent = this;
            frm.Show();
        }

        private void relacionarEqVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_ADM.RELACION_EQ_VENTA frm = new MOD_ADM.RELACION_EQ_VENTA();
            frm.MdiParent = this;
            frm.Show();
        }

        private void SituaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_ADM.SITUACION frm = new MOD_ADM.SITUACION();
            frm.MdiParent = this;
            frm.Show();
        }

        private void numeracionDeComprobantesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_ADM.NUMERACION_COMPROBANTE frm = new MOD_ADM.NUMERACION_COMPROBANTE();
            frm.MdiParent = this;
            frm.Show();
        }

        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void semanaContratoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_VTA.SEMANA_CONTRATO frm = new MOD_VTA.SEMANA_CONTRATO();
            frm.MdiParent = this;
            frm.Show();
        }

        private void creacionEqCobranzaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_ADM.EQUIPOS_DE_COBRANZA frm = new MOD_ADM.EQUIPOS_DE_COBRANZA();
            frm.MdiParent = this;
            frm.Show();
        }

        private void relacionarEqCobranzaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_ADM.RELACION_EQ_COBRANZA frm = new MOD_ADM.RELACION_EQ_COBRANZA();
            frm.MdiParent = this;
            frm.Show();
        }

        private void detalleToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            MOD_ADM.PUNTO_VENTA_GENERAR frm = new MOD_ADM.PUNTO_VENTA_GENERAR(AÑO, MES, FECHA_INI, FECHA_GRAL, COD_MOD, TIPO_USU, COD_USU);
            frm.MdiParent = this;
            frm.Show();
        }

        private void consolidadoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MOD_ADM.PUNTO_VENTA_CONSOLIDADOS frm = new MOD_ADM.PUNTO_VENTA_CONSOLIDADOS();
            frm.MdiParent = this;
            frm.Show();
        }

        private void TipoVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_ADM.TIPO_VENTA frm = new MOD_ADM.TIPO_VENTA();
            frm.MdiParent = this;
            frm.Show();
        }

        private void ToolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }

        private void modalidadDeVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_ADM.MODALIDAD_VENTA frm = new MOD_ADM.MODALIDAD_VENTA();
            frm.MdiParent = this;
            frm.Show();
        }

        private void costosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_ADM.PERIODO_COSTOS frm = new MOD_ADM.PERIODO_COSTOS(7, COD_USU);
            frm.MdiParent = this;
            frm.Show();
        }

        private void saldoInicialCostosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_ADM.SALDO_INICIAL frm = new MOD_ADM.SALDO_INICIAL(AÑO, MES, FECHA_INI, FECHA_GRAL, COD_MOD, TIPO_USU, COD_USU);
            frm.MdiParent = this;
            frm.Show();
        }

        private void cargosYAbonosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_ADM.CARGOS_ABONOS_COMISIONES frm = new MOD_ADM.CARGOS_ABONOS_COMISIONES();
            frm.MdiParent = this;
            frm.Show();
        }

        private void lugarDeVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_ADM.LUGAR_VENTA frm = new MOD_ADM.LUGAR_VENTA(AÑO, MES, FECHA_INI, FECHA_GRAL, COD_MOD, TIPO_USU, COD_USU);
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuMotivoDescuentoDirecta_Click(object sender, EventArgs e)
        {
            MOD_ADM.MOTIVO_DESCUENTO_DIRECTA frm = new MOD_ADM.MOTIVO_DESCUENTO_DIRECTA();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuHistorialPreciosVenta_Click(object sender, EventArgs e)
        {
            MOD_ADM.Reportes.Formulario.HISTORIAL_PRECIOS_VENTA frm = new MOD_ADM.Reportes.Formulario.HISTORIAL_PRECIOS_VENTA();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuTiposPlanillaCreacion_Click(object sender, EventArgs e)
        {
            MOD_ADM.TIPO_PLANILLA_CREACION frm = new MOD_ADM.TIPO_PLANILLA_CREACION(COD_USU);
            frm.MdiParent = this;
            frm.Show();
        }


    }
}
