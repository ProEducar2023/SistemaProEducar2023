﻿namespace Presentacion.MOD_CXC.Reportes.FormRep
{
    partial class REP_DE_COBRANZA_X_UBICACION_RESUMEN_DETALLADO
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
            this.cambioTipoPllaHistoricoToBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.cambioTipoPllaHistoricoToBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "cobranzaUbicacionResumenDetallado";
            reportDataSource1.Value = this.cambioTipoPllaHistoricoToBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Presentacion.MOD_CXC.Reportes.ReportViewer.REP_COBRANZA_X_UBICACION_RESUMEN_DETAL" +
    "LADO.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(284, 261);
            this.reportViewer1.TabIndex = 0;
            // 
            // cambioTipoPllaHistoricoToBindingSource
            // 
            this.cambioTipoPllaHistoricoToBindingSource.DataSource = typeof(Entidades.cambioTipoPllaHistoricoTo);
            // 
            // REP_DE_COBRANZA_X_UBICACION_RESUMEN_DETALLADO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.reportViewer1);
            this.Name = "REP_DE_COBRANZA_X_UBICACION_RESUMEN_DETALLADO";
            this.Text = "REP_DE_COBRANZA_X_UBICACION_RESUMEN_DETALLADO";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.REP_DE_COBRANZA_X_UBICACION_RESUMEN_DETALLADO_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cambioTipoPllaHistoricoToBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource cambioTipoPllaHistoricoToBindingSource;
    }
}