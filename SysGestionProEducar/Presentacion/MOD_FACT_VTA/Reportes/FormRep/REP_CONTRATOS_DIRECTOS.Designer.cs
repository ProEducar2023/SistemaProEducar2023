namespace Presentacion.MOD_FACT_VTA.Reportes.FormRep
{
    partial class REP_CONTRATOS_DIRECTOS
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
            this.contratoCabeceraToBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.contratoCabeceraToBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // contratoCabeceraToBindingSource
            // 
            this.contratoCabeceraToBindingSource.DataSource = typeof(Entidades.contratoCabeceraTo);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "ContratosDirectos";
            reportDataSource1.Value = this.contratoCabeceraToBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Presentacion.MOD_FACT_VTA.Reportes.ReportViewer.REP_CONTRATOS_DIRECTOS.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(781, 463);
            this.reportViewer1.TabIndex = 0;
            // 
            // REP_CONTRATOS_DIRECTOS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 463);
            this.Controls.Add(this.reportViewer1);
            this.Name = "REP_CONTRATOS_DIRECTOS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte Contratos Directos";
            this.Load += new System.EventHandler(this.REP_CONTRATOS_DIRECTOS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.contratoCabeceraToBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource contratoCabeceraToBindingSource;
    }
}