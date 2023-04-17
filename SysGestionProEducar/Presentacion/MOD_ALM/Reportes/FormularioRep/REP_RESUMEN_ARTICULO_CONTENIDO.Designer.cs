namespace Presentacion.MOD_ALM.Reportes.FormularioRep
{
    partial class REP_RESUMEN_ARTICULO_CONTENIDO
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.articuloContenidoMovimientoToBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.articuloContenidoMovimientoToBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.articuloContenidoMovimientoToBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Presentacion.MOD_ALM.Reportes.ReportViewer.REP_RESUMEN_ARTICULO_CONTENIDO.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(517, 384);
            this.reportViewer1.TabIndex = 0;
            // 
            // articuloContenidoMovimientoToBindingSource
            // 
            this.articuloContenidoMovimientoToBindingSource.DataSource = typeof(Entidades.articuloContenidoMovimientoTo);
            // 
            // REP_RESUMEN_ARTICULO_CONTENIDO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 384);
            this.Controls.Add(this.reportViewer1);
            this.Name = "REP_RESUMEN_ARTICULO_CONTENIDO";
            this.Text = "REP_RESUMEN_ARTICULO_CONTENIDO";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.REP_RESUMEN_ARTICULO_CONTENIDO_Load);
            ((System.ComponentModel.ISupportInitialize)(this.articuloContenidoMovimientoToBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource articuloContenidoMovimientoToBindingSource;
    }
}