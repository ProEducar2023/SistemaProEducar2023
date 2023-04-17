namespace Presentacion.REPORTES.FORM_REP
{
    partial class REP_PERSONAL1
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
            this.ReportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.personaToBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.personaToBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ReportViewer1
            // 
            this.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "Detalle";
            reportDataSource1.Value = this.personaToBindingSource;
            this.ReportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.ReportViewer1.LocalReport.ReportEmbeddedResource = "Presentacion.REPORTES.REPORTVIEWER.REP_PERSONA01.rdlc";
            this.ReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.ReportViewer1.Name = "ReportViewer1";
            this.ReportViewer1.Size = new System.Drawing.Size(726, 621);
            this.ReportViewer1.TabIndex = 0;
            // 
            // personaToBindingSource
            // 
            this.personaToBindingSource.DataSource = typeof(Entidades.personaTo);
            // 
            // REP_PERSONAL1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 621);
            this.Controls.Add(this.ReportViewer1);
            this.Name = "REP_PERSONAL1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "REP_PERSONAL1";
            this.Load += new System.EventHandler(this.REP_PERSONAL1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.personaToBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer ReportViewer1;
        private System.Windows.Forms.BindingSource personaToBindingSource;
    }
}