namespace Presentacion.MOD_VTA
{
    partial class MODULO_FACT_VTAS
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.MenuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FacturaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.InventarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GuíasPedidosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serviciosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sistemaAnteriorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contratosDirectosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TransferenciasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ContabilidadToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ConsultaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FactServicioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DocumentosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.MovimientosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HistóricoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ReporteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RegistroDeVentasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.facturacionElectrónicaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.envíoDeDocumentosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.comunicaciónDeBajaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resumenDiarioDeBoletasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarTicketToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SalirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ssEstado = new System.Windows.Forms.StatusStrip();
            this.ToolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsstlUsuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslEmpresa = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslProceso = new System.Windows.Forms.ToolStripStatusLabel();
            this.mnuContratosDirectos = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStrip1.SuspendLayout();
            this.ssEstado.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuStrip1
            // 
            this.MenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FacturaciónToolStripMenuItem,
            this.SalirToolStripMenuItem});
            this.MenuStrip1.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip1.Name = "MenuStrip1";
            this.MenuStrip1.Size = new System.Drawing.Size(1019, 24);
            this.MenuStrip1.TabIndex = 4;
            this.MenuStrip1.Text = "MenuStrip1";
            // 
            // FacturaciónToolStripMenuItem
            // 
            this.FacturaciónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.InventarioToolStripMenuItem,
            this.TransferenciasToolStripMenuItem,
            this.ToolStripSeparator1,
            this.ConsultaToolStripMenuItem,
            this.ToolStripSeparator3,
            this.ReporteToolStripMenuItem,
            this.facturacionElectrónicaToolStripMenuItem});
            this.FacturaciónToolStripMenuItem.Name = "FacturaciónToolStripMenuItem";
            this.FacturaciónToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.FacturaciónToolStripMenuItem.Text = "&Facturación";
            // 
            // InventarioToolStripMenuItem
            // 
            this.InventarioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GuíasPedidosToolStripMenuItem,
            this.serviciosToolStripMenuItem,
            this.sistemaAnteriorToolStripMenuItem,
            this.contratosDirectosToolStripMenuItem});
            this.InventarioToolStripMenuItem.Name = "InventarioToolStripMenuItem";
            this.InventarioToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.InventarioToolStripMenuItem.Text = "&Inventario";
            // 
            // GuíasPedidosToolStripMenuItem
            // 
            this.GuíasPedidosToolStripMenuItem.Name = "GuíasPedidosToolStripMenuItem";
            this.GuíasPedidosToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.GuíasPedidosToolStripMenuItem.Text = "&Contratos";
            this.GuíasPedidosToolStripMenuItem.Click += new System.EventHandler(this.GuíasPedidosToolStripMenuItem_Click);
            // 
            // serviciosToolStripMenuItem
            // 
            this.serviciosToolStripMenuItem.Name = "serviciosToolStripMenuItem";
            this.serviciosToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.serviciosToolStripMenuItem.Text = "Servicios";
            this.serviciosToolStripMenuItem.Click += new System.EventHandler(this.serviciosToolStripMenuItem_Click);
            // 
            // sistemaAnteriorToolStripMenuItem
            // 
            this.sistemaAnteriorToolStripMenuItem.Name = "sistemaAnteriorToolStripMenuItem";
            this.sistemaAnteriorToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.sistemaAnteriorToolStripMenuItem.Text = "Sistema Anterior";
            this.sistemaAnteriorToolStripMenuItem.Click += new System.EventHandler(this.sistemaAnteriorToolStripMenuItem_Click);
            // 
            // contratosDirectosToolStripMenuItem
            // 
            this.contratosDirectosToolStripMenuItem.Name = "contratosDirectosToolStripMenuItem";
            this.contratosDirectosToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.contratosDirectosToolStripMenuItem.Text = "Contratos Directos";
            this.contratosDirectosToolStripMenuItem.Click += new System.EventHandler(this.contratosDirectosToolStripMenuItem_Click);
            // 
            // TransferenciasToolStripMenuItem
            // 
            this.TransferenciasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ContabilidadToolStripMenuItem1});
            this.TransferenciasToolStripMenuItem.Name = "TransferenciasToolStripMenuItem";
            this.TransferenciasToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.TransferenciasToolStripMenuItem.Text = "&Transferencias";
            // 
            // ContabilidadToolStripMenuItem1
            // 
            this.ContabilidadToolStripMenuItem1.Name = "ContabilidadToolStripMenuItem1";
            this.ContabilidadToolStripMenuItem1.Size = new System.Drawing.Size(142, 22);
            this.ContabilidadToolStripMenuItem1.Text = "&Contabilidad";
            // 
            // ToolStripSeparator1
            // 
            this.ToolStripSeparator1.Name = "ToolStripSeparator1";
            this.ToolStripSeparator1.Size = new System.Drawing.Size(194, 6);
            // 
            // ConsultaToolStripMenuItem
            // 
            this.ConsultaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FactServicioToolStripMenuItem});
            this.ConsultaToolStripMenuItem.Name = "ConsultaToolStripMenuItem";
            this.ConsultaToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.ConsultaToolStripMenuItem.Text = "&Consulta";
            // 
            // FactServicioToolStripMenuItem
            // 
            this.FactServicioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DocumentosToolStripMenuItem1,
            this.MovimientosToolStripMenuItem,
            this.HistóricoToolStripMenuItem});
            this.FactServicioToolStripMenuItem.Name = "FactServicioToolStripMenuItem";
            this.FactServicioToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.FactServicioToolStripMenuItem.Text = "&Servicio";
            // 
            // DocumentosToolStripMenuItem1
            // 
            this.DocumentosToolStripMenuItem1.Name = "DocumentosToolStripMenuItem1";
            this.DocumentosToolStripMenuItem1.Size = new System.Drawing.Size(144, 22);
            this.DocumentosToolStripMenuItem1.Text = "&Documentos";
            // 
            // MovimientosToolStripMenuItem
            // 
            this.MovimientosToolStripMenuItem.Name = "MovimientosToolStripMenuItem";
            this.MovimientosToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.MovimientosToolStripMenuItem.Text = "&Movimientos";
            // 
            // HistóricoToolStripMenuItem
            // 
            this.HistóricoToolStripMenuItem.Name = "HistóricoToolStripMenuItem";
            this.HistóricoToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.HistóricoToolStripMenuItem.Text = "&Histórico";
            // 
            // ToolStripSeparator3
            // 
            this.ToolStripSeparator3.Name = "ToolStripSeparator3";
            this.ToolStripSeparator3.Size = new System.Drawing.Size(194, 6);
            // 
            // ReporteToolStripMenuItem
            // 
            this.ReporteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RegistroDeVentasToolStripMenuItem,
            this.mnuContratosDirectos});
            this.ReporteToolStripMenuItem.Name = "ReporteToolStripMenuItem";
            this.ReporteToolStripMenuItem.ShowShortcutKeys = false;
            this.ReporteToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.ReporteToolStripMenuItem.Text = "&Reporte";
            // 
            // RegistroDeVentasToolStripMenuItem
            // 
            this.RegistroDeVentasToolStripMenuItem.Name = "RegistroDeVentasToolStripMenuItem";
            this.RegistroDeVentasToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.RegistroDeVentasToolStripMenuItem.Text = "&Registro de Ventas";
            // 
            // facturacionElectrónicaToolStripMenuItem
            // 
            this.facturacionElectrónicaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.envíoDeDocumentosToolStripMenuItem,
            this.toolStripSeparator2,
            this.comunicaciónDeBajaToolStripMenuItem,
            this.resumenDiarioDeBoletasToolStripMenuItem,
            this.consultarTicketToolStripMenuItem});
            this.facturacionElectrónicaToolStripMenuItem.Name = "facturacionElectrónicaToolStripMenuItem";
            this.facturacionElectrónicaToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.facturacionElectrónicaToolStripMenuItem.Text = "Facturacion Electrónica";
            // 
            // envíoDeDocumentosToolStripMenuItem
            // 
            this.envíoDeDocumentosToolStripMenuItem.Name = "envíoDeDocumentosToolStripMenuItem";
            this.envíoDeDocumentosToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.envíoDeDocumentosToolStripMenuItem.Text = "Envío de documentos";
            this.envíoDeDocumentosToolStripMenuItem.Click += new System.EventHandler(this.envíoDeDocumentosToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(210, 6);
            // 
            // comunicaciónDeBajaToolStripMenuItem
            // 
            this.comunicaciónDeBajaToolStripMenuItem.Name = "comunicaciónDeBajaToolStripMenuItem";
            this.comunicaciónDeBajaToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.comunicaciónDeBajaToolStripMenuItem.Text = "Comunicación de bajas";
            this.comunicaciónDeBajaToolStripMenuItem.Click += new System.EventHandler(this.comunicaciónDeBajaToolStripMenuItem_Click);
            // 
            // resumenDiarioDeBoletasToolStripMenuItem
            // 
            this.resumenDiarioDeBoletasToolStripMenuItem.Name = "resumenDiarioDeBoletasToolStripMenuItem";
            this.resumenDiarioDeBoletasToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.resumenDiarioDeBoletasToolStripMenuItem.Text = "Resumen diario de Boletas";
            this.resumenDiarioDeBoletasToolStripMenuItem.Click += new System.EventHandler(this.resumenDiarioDeBoletasToolStripMenuItem_Click);
            // 
            // consultarTicketToolStripMenuItem
            // 
            this.consultarTicketToolStripMenuItem.Name = "consultarTicketToolStripMenuItem";
            this.consultarTicketToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.consultarTicketToolStripMenuItem.Text = "Consultar Ticket";
            this.consultarTicketToolStripMenuItem.Click += new System.EventHandler(this.consultarTicketToolStripMenuItem_Click);
            // 
            // SalirToolStripMenuItem
            // 
            this.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem";
            this.SalirToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.SalirToolStripMenuItem.Text = "&Salir";
            this.SalirToolStripMenuItem.Click += new System.EventHandler(this.SalirToolStripMenuItem_Click);
            // 
            // ssEstado
            // 
            this.ssEstado.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ssEstado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripStatusLabel1,
            this.ToolStripStatusLabel2,
            this.tsstlUsuario,
            this.ToolStripStatusLabel3,
            this.tsslEmpresa,
            this.ToolStripStatusLabel4,
            this.tsslProceso});
            this.ssEstado.Location = new System.Drawing.Point(0, 549);
            this.ssEstado.Name = "ssEstado";
            this.ssEstado.Size = new System.Drawing.Size(1019, 25);
            this.ssEstado.TabIndex = 11;
            // 
            // ToolStripStatusLabel1
            // 
            this.ToolStripStatusLabel1.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.ToolStripStatusLabel1.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1";
            this.ToolStripStatusLabel1.Size = new System.Drawing.Size(615, 20);
            this.ToolStripStatusLabel1.Spring = true;
            // 
            // ToolStripStatusLabel2
            // 
            this.ToolStripStatusLabel2.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)(((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.ToolStripStatusLabel2.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2";
            this.ToolStripStatusLabel2.Size = new System.Drawing.Size(56, 20);
            this.ToolStripStatusLabel2.Text = "Usuario:";
            // 
            // tsstlUsuario
            // 
            this.tsstlUsuario.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)(((System.Windows.Forms.ToolStripStatusLabelBorderSides.Top | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tsstlUsuario.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.tsstlUsuario.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsstlUsuario.ForeColor = System.Drawing.Color.Blue;
            this.tsstlUsuario.Image = global::Presentacion.Properties.Resources.image1;
            this.tsstlUsuario.Name = "tsstlUsuario";
            this.tsstlUsuario.Size = new System.Drawing.Size(77, 20);
            this.tsstlUsuario.Text = "[Usuario]";
            // 
            // ToolStripStatusLabel3
            // 
            this.ToolStripStatusLabel3.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)(((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.ToolStripStatusLabel3.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3";
            this.ToolStripStatusLabel3.Size = new System.Drawing.Size(63, 20);
            this.ToolStripStatusLabel3.Text = "Empresa:";
            // 
            // tsslEmpresa
            // 
            this.tsslEmpresa.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)(((System.Windows.Forms.ToolStripStatusLabelBorderSides.Top | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tsslEmpresa.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.tsslEmpresa.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsslEmpresa.ForeColor = System.Drawing.Color.Blue;
            this.tsslEmpresa.Name = "tsslEmpresa";
            this.tsslEmpresa.Size = new System.Drawing.Size(68, 20);
            this.tsslEmpresa.Text = "[Empresa]";
            // 
            // ToolStripStatusLabel4
            // 
            this.ToolStripStatusLabel4.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)(((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.ToolStripStatusLabel4.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4";
            this.ToolStripStatusLabel4.Size = new System.Drawing.Size(60, 20);
            this.ToolStripStatusLabel4.Text = "Proceso:";
            // 
            // tsslProceso
            // 
            this.tsslProceso.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)(((System.Windows.Forms.ToolStripStatusLabelBorderSides.Top | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tsslProceso.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.tsslProceso.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsslProceso.ForeColor = System.Drawing.Color.Blue;
            this.tsslProceso.Name = "tsslProceso";
            this.tsslProceso.Size = new System.Drawing.Size(65, 20);
            this.tsslProceso.Text = "[Proceso]";
            // 
            // mnuContratosDirectos
            // 
            this.mnuContratosDirectos.Name = "mnuContratosDirectos";
            this.mnuContratosDirectos.Size = new System.Drawing.Size(172, 22);
            this.mnuContratosDirectos.Text = "Contratos Directos";
            this.mnuContratosDirectos.Click += new System.EventHandler(this.mnuContratosDirectos_Click);
            // 
            // MODULO_FACT_VTAS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Presentacion.Properties.Resources.fondo3;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1019, 574);
            this.Controls.Add(this.ssEstado);
            this.Controls.Add(this.MenuStrip1);
            this.IsMdiContainer = true;
            this.Name = "MODULO_FACT_VTAS";
            this.Text = "Modulo de Facturación de Ventas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MODULO_FACT_VTAS_Load);
            this.MenuStrip1.ResumeLayout(false);
            this.MenuStrip1.PerformLayout();
            this.ssEstado.ResumeLayout(false);
            this.ssEstado.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.ToolTip toolTip;
        internal System.Windows.Forms.MenuStrip MenuStrip1;
        internal System.Windows.Forms.ToolStripMenuItem FacturaciónToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem InventarioToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem GuíasPedidosToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem TransferenciasToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem ContabilidadToolStripMenuItem1;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator1;
        internal System.Windows.Forms.ToolStripMenuItem ConsultaToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem FactServicioToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem DocumentosToolStripMenuItem1;
        internal System.Windows.Forms.ToolStripMenuItem MovimientosToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem HistóricoToolStripMenuItem;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator3;
        internal System.Windows.Forms.ToolStripMenuItem ReporteToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem RegistroDeVentasToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem SalirToolStripMenuItem;
        internal System.Windows.Forms.StatusStrip ssEstado;
        internal System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel1;
        internal System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel2;
        internal System.Windows.Forms.ToolStripStatusLabel tsstlUsuario;
        internal System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel3;
        internal System.Windows.Forms.ToolStripStatusLabel tsslEmpresa;
        internal System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel4;
        internal System.Windows.Forms.ToolStripStatusLabel tsslProceso;
        private System.Windows.Forms.ToolStripMenuItem sistemaAnteriorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem facturacionElectrónicaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem envíoDeDocumentosToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem comunicaciónDeBajaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resumenDiarioDeBoletasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarTicketToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serviciosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contratosDirectosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuContratosDirectos;
    }
}



