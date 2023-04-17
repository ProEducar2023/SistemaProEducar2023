
namespace Presentacion.MOD_COMISIONES.Reportes.Formulario
{
    partial class FrmRptDevolucionComision
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
            this.label2 = new System.Windows.Forms.Label();
            this.dtFechaAprobIni = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtFechaAprobFin = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtFechaDevIni = new System.Windows.Forms.DateTimePicker();
            this.dtFechaDevFin = new System.Windows.Forms.DateTimePicker();
            this.btnGenerarReporte = new System.Windows.Forms.Button();
            this.cboPrograma = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha Aprobación";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fecha Devolución";
            // 
            // dtFechaAprobIni
            // 
            this.dtFechaAprobIni.CustomFormat = "dd/MM/yyyy";
            this.dtFechaAprobIni.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFechaAprobIni.Location = new System.Drawing.Point(147, 86);
            this.dtFechaAprobIni.Name = "dtFechaAprobIni";
            this.dtFechaAprobIni.Size = new System.Drawing.Size(116, 20);
            this.dtFechaAprobIni.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(269, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "-";
            // 
            // dtFechaAprobFin
            // 
            this.dtFechaAprobFin.CustomFormat = "dd/MM/yyyy";
            this.dtFechaAprobFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFechaAprobFin.Location = new System.Drawing.Point(285, 86);
            this.dtFechaAprobFin.Name = "dtFechaAprobFin";
            this.dtFechaAprobFin.Size = new System.Drawing.Size(116, 20);
            this.dtFechaAprobFin.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(269, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(10, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "-";
            // 
            // dtFechaDevIni
            // 
            this.dtFechaDevIni.CustomFormat = "dd/MM/yyyy";
            this.dtFechaDevIni.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFechaDevIni.Location = new System.Drawing.Point(147, 118);
            this.dtFechaDevIni.Name = "dtFechaDevIni";
            this.dtFechaDevIni.Size = new System.Drawing.Size(116, 20);
            this.dtFechaDevIni.TabIndex = 6;
            // 
            // dtFechaDevFin
            // 
            this.dtFechaDevFin.CustomFormat = "dd/MM/yyyy";
            this.dtFechaDevFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFechaDevFin.Location = new System.Drawing.Point(285, 118);
            this.dtFechaDevFin.Name = "dtFechaDevFin";
            this.dtFechaDevFin.Size = new System.Drawing.Size(116, 20);
            this.dtFechaDevFin.TabIndex = 7;
            // 
            // btnGenerarReporte
            // 
            this.btnGenerarReporte.Location = new System.Drawing.Point(182, 173);
            this.btnGenerarReporte.Name = "btnGenerarReporte";
            this.btnGenerarReporte.Size = new System.Drawing.Size(111, 39);
            this.btnGenerarReporte.TabIndex = 8;
            this.btnGenerarReporte.Text = "Generar Reporte";
            this.btnGenerarReporte.UseVisualStyleBackColor = true;
            this.btnGenerarReporte.Click += new System.EventHandler(this.BtnGenerarReporte_Click);
            // 
            // cboPrograma
            // 
            this.cboPrograma.BackColor = System.Drawing.Color.White;
            this.cboPrograma.FormattingEnabled = true;
            this.cboPrograma.Location = new System.Drawing.Point(147, 50);
            this.cboPrograma.Name = "cboPrograma";
            this.cboPrograma.Size = new System.Drawing.Size(220, 21);
            this.cboPrograma.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(71, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Programa";
            // 
            // FrmRptDevolucionComision
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 331);
            this.Controls.Add(this.cboPrograma);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnGenerarReporte);
            this.Controls.Add(this.dtFechaDevFin);
            this.Controls.Add(this.dtFechaDevIni);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtFechaAprobFin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtFechaAprobIni);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmRptDevolucionComision";
            this.Text = "REPORTE DEVOLUCIÓN COMISION";
            this.Load += new System.EventHandler(this.FrmRptDevolucionComision_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtFechaAprobIni;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtFechaAprobFin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtFechaDevIni;
        private System.Windows.Forms.DateTimePicker dtFechaDevFin;
        private System.Windows.Forms.Button btnGenerarReporte;
        private System.Windows.Forms.ComboBox cboPrograma;
        private System.Windows.Forms.Label label5;
    }
}