
namespace Presentacion.MOD_FACT_VTA.MOD_VTA.Reportes.FormularioRep
{
    partial class FrmAnalisisCarteraXTrabajar
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
            this.label1 = new System.Windows.Forms.Label();
            this.dtFechaReporte = new System.Windows.Forms.DateTimePicker();
            this.btnGenerarReporte = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.numImpProyecCD = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numImpProyecCD)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(143, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha Reporte";
            // 
            // dtFechaReporte
            // 
            this.dtFechaReporte.CustomFormat = "MM/yyyy";
            this.dtFechaReporte.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFechaReporte.Location = new System.Drawing.Point(227, 92);
            this.dtFechaReporte.Name = "dtFechaReporte";
            this.dtFechaReporte.Size = new System.Drawing.Size(118, 20);
            this.dtFechaReporte.TabIndex = 1;
            // 
            // btnGenerarReporte
            // 
            this.btnGenerarReporte.Location = new System.Drawing.Point(111, 193);
            this.btnGenerarReporte.Name = "btnGenerarReporte";
            this.btnGenerarReporte.Size = new System.Drawing.Size(135, 43);
            this.btnGenerarReporte.TabIndex = 2;
            this.btnGenerarReporte.Text = "Generar Reporte";
            this.btnGenerarReporte.UseVisualStyleBackColor = true;
            this.btnGenerarReporte.Click += new System.EventHandler(this.BtnGenerarReporte_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(262, 193);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(135, 43);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(184, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Importe Proyectado Cobranza Directa";
            // 
            // numImpProyecCD
            // 
            this.numImpProyecCD.DecimalPlaces = 2;
            this.numImpProyecCD.Location = new System.Drawing.Point(227, 129);
            this.numImpProyecCD.Name = "numImpProyecCD";
            this.numImpProyecCD.Size = new System.Drawing.Size(120, 20);
            this.numImpProyecCD.TabIndex = 5;
            this.numImpProyecCD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numImpProyecCD.ThousandsSeparator = true;
            // 
            // FrmAnalisisCarteraXTrabajar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 264);
            this.Controls.Add(this.numImpProyecCD);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGenerarReporte);
            this.Controls.Add(this.dtFechaReporte);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmAnalisisCarteraXTrabajar";
            this.Text = "AnalisisCarteraXTrabajar";
            this.Load += new System.EventHandler(this.AnalisisCarteraXTrabajar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numImpProyecCD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtFechaReporte;
        private System.Windows.Forms.Button btnGenerarReporte;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numImpProyecCD;
    }
}