namespace Presentacion.MOD_ADM.Reportes.FormularioRepp
{
    partial class REP_HISTORIAL_PRECIO_VENTA
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
            this.inventariosToBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.inventariosToBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "HistorialPrecioVenta";
            reportDataSource1.Value = this.inventariosToBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Presentacion.MOD_ADM.Reportes.ReportViewer.REP_HISTORIAL_PRECIO_VENTA.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(752, 439);
            this.reportViewer1.TabIndex = 0;
            // 
            // inventariosToBindingSource
            // 
            this.inventariosToBindingSource.DataSource = typeof(Entidades.inventariosTo);
            // 
            // REP_HISTORIAL_PRECIO_VENTA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 439);
            this.Controls.Add(this.reportViewer1);
            this.Name = "REP_HISTORIAL_PRECIO_VENTA";
            this.Text = "Reporte Historial Precio Venta";
            this.Load += new System.EventHandler(this.REP_HISTORIAL_PRECIO_VENTA_Load);
            ((System.ComponentModel.ISupportInitialize)(this.inventariosToBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource inventariosToBindingSource;
    }
}