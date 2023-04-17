namespace Presentacion.MOD_FACT_VTA.MOD_VTA.Reportes.FormRep
{
    partial class REP_CONTRATOS_REGISTRADOS_RESUMEN
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
            this.contratoCabeceraToBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.contratoCabeceraToBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "ContratosRegistradosResumen";
            reportDataSource1.Value = this.contratoCabeceraToBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Presentacion.MOD_FACT_VTA.MOD_VTA.Reportes.ReportViewer.REP_CONTRATOS_REGISTRADOS" +
    "_RESUMEN.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(752, 439);
            this.reportViewer1.TabIndex = 0;
            // 
            // contratoCabeceraToBindingSource
            // 
            this.contratoCabeceraToBindingSource.DataSource = typeof(Entidades.contratoCabeceraTo);
            // 
            // REP_CONTRATOS_REGISTRADOS_RESUMEN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 439);
            this.Controls.Add(this.reportViewer1);
            this.Name = "REP_CONTRATOS_REGISTRADOS_RESUMEN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Resumen de Contratos Registrados";
            this.Load += new System.EventHandler(this.REP_CONTRATOS_REGISTRADOS_RESUMEN_Load);
            ((System.ComponentModel.ISupportInitialize)(this.contratoCabeceraToBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource contratoCabeceraToBindingSource;
    }
}