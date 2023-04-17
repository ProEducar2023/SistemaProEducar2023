using System;
using System.Windows.Forms;

namespace Presentacion.MOD_VTA
{
    public partial class MODULO_ALMACEN : Form
    {
        string AÑO = "", MES = "", COD_MOD, TIPO_USU = "", COD_USU = "", NOM_EMPRESA = "", NOM_USU = "";
        DateTime FECHA_INI, FECHA_GRAL;
        public MODULO_ALMACEN(string AÑO, string MES, DateTime FECHA_INI, DateTime FECHA_GRAL, string COD_MOD, string TIPO_USU, string COD_USU, string NOM_EMPRESA, string NOM_USU)
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
        private void MODULO_ALMACEN_Load(object sender, EventArgs e)
        {
            tsstlUsuario.Text = NOM_USU;
            tsslEmpresa.Text = NOM_EMPRESA;
            tsslProceso.Text = FECHA_GRAL.Date.ToShortDateString();
        }
        private void DirectosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_ALM.NOTA_INGRESO_DIRECTA frm = new MOD_ALM.NOTA_INGRESO_DIRECTA(AÑO, MES, FECHA_INI, FECHA_GRAL, COD_MOD, TIPO_USU, COD_USU);
            frm.MdiParent = this;
            frm.Show();
        }

        private void OrdenDeDevoluciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_ALM.NOTA_INGRESO_ODEV frm = new MOD_ALM.NOTA_INGRESO_ODEV(AÑO, MES, FECHA_INI, FECHA_GRAL, COD_MOD, TIPO_USU, COD_USU);
            frm.MdiParent = this;
            frm.Show();
        }

        private void ProductoTerminadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_ALM.NOTA_INGRESO_DIRECTA_OP frm = new MOD_ALM.NOTA_INGRESO_DIRECTA_OP();
            frm.MdiParent = this;
            frm.Show();
        }

        private void ToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            MOD_ALM.NOTA_SALIDAS frm = new MOD_ALM.NOTA_SALIDAS(AÑO, MES, FECHA_INI, FECHA_GRAL, COD_MOD, TIPO_USU, COD_USU);
            frm.MdiParent = this;
            frm.Show();
        }

        private void DirectaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //CONSULTAS.CONSULTA_NS frm = new CONSULTAS.CONSULTA_NS();
            //frm.MdiParent = this;
            //frm.Show();
            MOD_ALM.NOTA_SALIDA_PEDIDO frm = new MOD_ALM.NOTA_SALIDA_PEDIDO();
            frm.MdiParent = this;
            frm.Show();
        }

        private void DevolucionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_ALM.NOTA_SALIDAS_DEV frm = new MOD_ALM.NOTA_SALIDAS_DEV();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuTransferenciaClaseSucursal_Click(object sender, EventArgs e)
        {
            //dentro del formulario hay un metodo ObtenerInstancia y el grid del original es uno especial
            MOD_ALM.frmTransferenciaClaseAlmacen frm = new MOD_ALM.frmTransferenciaClaseAlmacen();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuTransferenciaDirecta_Click(object sender, EventArgs e)
        {
            MOD_ALM.NOTA_TRANSFERENCIA frm = new MOD_ALM.NOTA_TRANSFERENCIA(AÑO, MES, FECHA_INI, FECHA_GRAL, COD_MOD, TIPO_USU, COD_USU);
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuTransferenciaRequerimientoClase_Click(object sender, EventArgs e)
        {
            MOD_ALM.frmNotaTransferenciaRequerimientoClase frm = new MOD_ALM.frmNotaTransferenciaRequerimientoClase();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuTranferenciaControlTerceros_Click(object sender, EventArgs e)
        {
            MOD_ALM.frmNotaTransferenciaControl frm = new MOD_ALM.frmNotaTransferenciaControl();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuTransferenciaTransformaciones_Click(object sender, EventArgs e)
        {
            MOD_ALM.frmNotaTransformaciones frm = new MOD_ALM.frmNotaTransformaciones();
            frm.MdiParent = this;
            frm.Show();
        }

        private void InventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //CONSULTAS.CONSULTA_X_DOC_ING frm = new CONSULTAS.CONSULTA_X_DOC_ING();
            MOD_ALM.GUIA_VTA frm = new MOD_ALM.GUIA_VTA();
            frm.MdiParent = this;
            frm.Show();
        }

        private void ServicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_ALM.GUIA_VTA_SERV frm = new MOD_ALM.GUIA_VTA_SERV();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuGuiaExportacion_Click(object sender, EventArgs e)
        {
            MOD_ALM.frmGuiaExportacion frm = new MOD_ALM.frmGuiaExportacion();
            frm.MdiParent = this;
            frm.Show();
        }

        private void FacturadasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_ALM.frmGuiaVentaFacturada frm = new MOD_ALM.frmGuiaVentaFacturada();
            frm.MdiParent = this;
            frm.Show();
        }

        private void GuíasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_ALM.frmGuiaVentaPedido frm = new MOD_ALM.frmGuiaVentaPedido();
            frm.MdiParent = this;
            frm.Show();
        }

        private void DevoluciónDeComprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_ALM.GUIA_NOTA_DEV frm = new MOD_ALM.GUIA_NOTA_DEV();
            frm.MdiParent = this;
            frm.Show();
        }

        private void TransferenciaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MOD_ALM.GUIA_TRANSFERENCIA frm = new MOD_ALM.GUIA_TRANSFERENCIA();
            frm.MdiParent = this;
            frm.Show();
        }

        private void InternoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_ALM.GUIA_NOTA_SALIDAS2 frm = new MOD_ALM.GUIA_NOTA_SALIDAS2();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuGuiaServicioGasto_Click(object sender, EventArgs e)
        {
            MOD_ALM.frmGuiaServicioGasto frm = new MOD_ALM.frmGuiaServicioGasto();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuTransferenciaRequerimiento_Click(object sender, EventArgs e)
        {
            MOD_ALM.frmNotaTransferenciaRequerimiento frm = new MOD_ALM.frmNotaTransferenciaRequerimiento();
            frm.MdiParent = this;
            frm.Show();
        }

        private void SalirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void mnuKardexInventarioHistorico_Click(object sender, EventArgs e)
        {
            MOD_ALM.Reportes.Formulario.KARDEX_INVENTARIO_HISTORICO frm = new MOD_ALM.Reportes.Formulario.KARDEX_INVENTARIO_HISTORICO(AÑO, MES, FECHA_INI, FECHA_GRAL, COD_MOD, TIPO_USU, COD_USU);
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuDevolucionMercaderias_Click(object sender, EventArgs e)
        {
            MOD_ALM.Reportes.Formulario.DEVOLUCION_DE_MERCADERIAS frm = new MOD_ALM.Reportes.Formulario.DEVOLUCION_DE_MERCADERIAS(AÑO, MES, FECHA_INI, FECHA_GRAL, COD_MOD, TIPO_USU, COD_USU);
            frm.MdiParent = this;
            frm.Show();
        }

        private void resumenArticuloContenidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_ALM.Reportes.Formulario.RESUMEN_ARTICULO_CONTENIDO frm = new MOD_ALM.Reportes.Formulario.RESUMEN_ARTICULO_CONTENIDO(AÑO, MES);
            frm.MdiParent = this;
            frm.Show();
        }




    }
}
