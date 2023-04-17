namespace Presentacion.REPORTES.FORM_REPORTES
{
    partial class REP_KARDEX_SALDO2
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
            this.dT_KARDEX_SALDO_ARTICULO = new Presentacion.REPORTES.DATASET.DT_KARDEX_SALDO_ARTICULO();
            this.dataTable1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dT_KARDEX_SALDO_ARTICULO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ReportViewer1
            // 
            this.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DT_KARDEX_SALDO_ARTICULO_DataTable1";
            reportDataSource1.Value = this.dataTable1BindingSource;
            this.ReportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.ReportViewer1.LocalReport.ReportEmbeddedResource = "Presentacion.REPORTES.REPORTVIEWER.REP_KARDEX_SALDO2.rdlc";
            this.ReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.ReportViewer1.Name = "ReportViewer1";
            this.ReportViewer1.Size = new System.Drawing.Size(762, 694);
            this.ReportViewer1.TabIndex = 0;
            // 
            // dT_KARDEX_SALDO_ARTICULO
            // 
            this.dT_KARDEX_SALDO_ARTICULO.DataSetName = "DT_KARDEX_SALDO_ARTICULO";
            this.dT_KARDEX_SALDO_ARTICULO.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataTable1BindingSource
            // 
            this.dataTable1BindingSource.DataMember = "DataTable1";
            this.dataTable1BindingSource.DataSource = this.dT_KARDEX_SALDO_ARTICULO;
            // 
            // REP_KARDEX_SALDO2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 694);
            this.Controls.Add(this.ReportViewer1);
            this.Name = "REP_KARDEX_SALDO2";
            this.Text = "REP_KARDEX_SALDO2";
            this.Load += new System.EventHandler(this.REP_KARDEX_SALDO2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dT_KARDEX_SALDO_ARTICULO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer ReportViewer1;
        private System.Windows.Forms.BindingSource dataTable1BindingSource;
        private DATASET.DT_KARDEX_SALDO_ARTICULO dT_KARDEX_SALDO_ARTICULO;
    }
}