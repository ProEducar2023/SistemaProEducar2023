
namespace Presentacion.MOD_CXC.Reportes.Formulario
{
    partial class FrmCancelacionXPlanilla
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
            this.btnImprimir2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.dtFECHA2 = new System.Windows.Forms.DateTimePicker();
            this.dtFECHA1 = new System.Windows.Forms.DateTimePicker();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.cboTipo_cancelacion = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cboprogramas = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnImprimir3 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnImprimir2
            // 
            this.btnImprimir2.Location = new System.Drawing.Point(419, 95);
            this.btnImprimir2.Name = "btnImprimir2";
            this.btnImprimir2.Size = new System.Drawing.Size(152, 36);
            this.btnImprimir2.TabIndex = 52;
            this.btnImprimir2.Text = "Resumen Comparativo";
            this.btnImprimir2.UseVisualStyleBackColor = true;
            this.btnImprimir2.Click += new System.EventHandler(this.btnImprimir2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(10, 167);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(385, 63);
            this.groupBox1.TabIndex = 51;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ordenar Por:";
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(257, 27);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(116, 17);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.Text = "Punto de Cobranza";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(131, 27);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(91, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "Fecha Planilla";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(19, 27);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(73, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Nº Planilla";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // dtFECHA2
            // 
            this.dtFECHA2.CustomFormat = "MM/yyyy";
            this.dtFECHA2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFECHA2.Location = new System.Drawing.Point(282, 79);
            this.dtFECHA2.Name = "dtFECHA2";
            this.dtFECHA2.Size = new System.Drawing.Size(93, 20);
            this.dtFECHA2.TabIndex = 50;
            // 
            // dtFECHA1
            // 
            this.dtFECHA1.CustomFormat = "MM/yyyy";
            this.dtFECHA1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFECHA1.Location = new System.Drawing.Point(132, 79);
            this.dtFECHA1.Name = "dtFECHA1";
            this.dtFECHA1.Size = new System.Drawing.Size(93, 20);
            this.dtFECHA1.TabIndex = 49;
            // 
            // btnImprimir
            // 
            this.btnImprimir.Location = new System.Drawing.Point(419, 36);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(152, 36);
            this.btnImprimir.TabIndex = 48;
            this.btnImprimir.Text = "Resumen Por Planilla";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // cboTipo_cancelacion
            // 
            this.cboTipo_cancelacion.FormattingEnabled = true;
            this.cboTipo_cancelacion.Location = new System.Drawing.Point(173, 126);
            this.cboTipo_cancelacion.Name = "cboTipo_cancelacion";
            this.cboTipo_cancelacion.Size = new System.Drawing.Size(202, 21);
            this.cboTipo_cancelacion.TabIndex = 47;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 129);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(154, 13);
            this.label10.TabIndex = 46;
            this.label10.Text = "Tipo de planilla de cancelación";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(249, 82);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(16, 13);
            this.label9.TabIndex = 45;
            this.label9.Text = "Al";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 82);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 13);
            this.label8.TabIndex = 44;
            this.label8.Text = "Fecha de Planilla";
            // 
            // cboprogramas
            // 
            this.cboprogramas.FormattingEnabled = true;
            this.cboprogramas.Location = new System.Drawing.Point(78, 36);
            this.cboprogramas.Name = "cboprogramas";
            this.cboprogramas.Size = new System.Drawing.Size(149, 21);
            this.cboprogramas.TabIndex = 43;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 42;
            this.label5.Text = "Programas";
            // 
            // btnImprimir3
            // 
            this.btnImprimir3.Location = new System.Drawing.Point(416, 156);
            this.btnImprimir3.Name = "btnImprimir3";
            this.btnImprimir3.Size = new System.Drawing.Size(152, 36);
            this.btnImprimir3.TabIndex = 53;
            this.btnImprimir3.Text = "Detalle Por Contrato";
            this.btnImprimir3.UseVisualStyleBackColor = true;
            this.btnImprimir3.Click += new System.EventHandler(this.btnImprimir3_Click);
            // 
            // FrmCancelacionXPlanilla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 237);
            this.Controls.Add(this.btnImprimir3);
            this.Controls.Add(this.btnImprimir2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dtFECHA2);
            this.Controls.Add(this.dtFECHA1);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.cboTipo_cancelacion);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cboprogramas);
            this.Controls.Add(this.label5);
            this.Name = "FrmCancelacionXPlanilla";
            this.Text = "Cancelación Por Tipo Planilla";
            this.Load += new System.EventHandler(this.FrmCancelacionXPlanilla_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnImprimir2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.DateTimePicker dtFECHA2;
        private System.Windows.Forms.DateTimePicker dtFECHA1;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.ComboBox cboTipo_cancelacion;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboprogramas;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnImprimir3;
    }
}