
namespace Presentacion.MOD_COMISIONES
{
    partial class FrmGenerarReporteComisiones
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
            this.cboPrograma = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboPeriodoGen = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cboPersona = new System.Windows.Forms.ComboBox();
            this.cboNivelVenta = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.rdbComisionGenerado = new System.Windows.Forms.RadioButton();
            this.rdbComisionExcluido = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // cboPrograma
            // 
            this.cboPrograma.FormattingEnabled = true;
            this.cboPrograma.Location = new System.Drawing.Point(129, 59);
            this.cboPrograma.Name = "cboPrograma";
            this.cboPrograma.Size = new System.Drawing.Size(220, 21);
            this.cboPrograma.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Programa";
            // 
            // cboPeriodoGen
            // 
            this.cboPeriodoGen.FormattingEnabled = true;
            this.cboPeriodoGen.Location = new System.Drawing.Point(129, 155);
            this.cboPeriodoGen.Name = "cboPeriodoGen";
            this.cboPeriodoGen.Size = new System.Drawing.Size(125, 21);
            this.cboPeriodoGen.TabIndex = 35;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(47, 163);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 13);
            this.label11.TabIndex = 34;
            this.label11.Text = "Períodos Gen.";
            // 
            // cboPersona
            // 
            this.cboPersona.FormattingEnabled = true;
            this.cboPersona.Location = new System.Drawing.Point(129, 123);
            this.cboPersona.Name = "cboPersona";
            this.cboPersona.Size = new System.Drawing.Size(220, 21);
            this.cboPersona.TabIndex = 39;
            // 
            // cboNivelVenta
            // 
            this.cboNivelVenta.FormattingEnabled = true;
            this.cboNivelVenta.Location = new System.Drawing.Point(129, 90);
            this.cboNivelVenta.Name = "cboNivelVenta";
            this.cboNivelVenta.Size = new System.Drawing.Size(220, 21);
            this.cboNivelVenta.TabIndex = 38;
            this.cboNivelVenta.SelectedValueChanged += new System.EventHandler(this.CboNivelVenta_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(77, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 37;
            this.label2.Text = "Persona";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 36;
            this.label3.Text = "Nivel Venta";
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.Color.White;
            this.btnImprimir.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnImprimir.ForeColor = System.Drawing.Color.Teal;
            this.btnImprimir.Location = new System.Drawing.Point(152, 216);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(167, 38);
            this.btnImprimir.TabIndex = 40;
            this.btnImprimir.Text = "Generar Reporte";
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.BtnImprimir_Click);
            // 
            // rdbComisionGenerado
            // 
            this.rdbComisionGenerado.AutoSize = true;
            this.rdbComisionGenerado.Location = new System.Drawing.Point(76, 16);
            this.rdbComisionGenerado.Name = "rdbComisionGenerado";
            this.rdbComisionGenerado.Size = new System.Drawing.Size(95, 17);
            this.rdbComisionGenerado.TabIndex = 41;
            this.rdbComisionGenerado.TabStop = true;
            this.rdbComisionGenerado.Text = "De Comisiones";
            this.rdbComisionGenerado.UseVisualStyleBackColor = true;
            this.rdbComisionGenerado.CheckedChanged += new System.EventHandler(this.RdbComisionGenerado_CheckedChanged);
            // 
            // rdbComisionExcluido
            // 
            this.rdbComisionExcluido.AutoSize = true;
            this.rdbComisionExcluido.Location = new System.Drawing.Point(243, 16);
            this.rdbComisionExcluido.Name = "rdbComisionExcluido";
            this.rdbComisionExcluido.Size = new System.Drawing.Size(87, 17);
            this.rdbComisionExcluido.TabIndex = 42;
            this.rdbComisionExcluido.TabStop = true;
            this.rdbComisionExcluido.Text = "De Excluidos";
            this.rdbComisionExcluido.UseVisualStyleBackColor = true;
            // 
            // FrmGenerarReporteComisiones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 279);
            this.Controls.Add(this.rdbComisionExcluido);
            this.Controls.Add(this.rdbComisionGenerado);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.cboPersona);
            this.Controls.Add(this.cboNivelVenta);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboPeriodoGen);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cboPrograma);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmGenerarReporteComisiones";
            this.Text = "GENERAR DE GENERACIÓN DE COMISIONES";
            this.Load += new System.EventHandler(this.FrmGenerarReporteComisiones_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboPrograma;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboPeriodoGen;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cboPersona;
        private System.Windows.Forms.ComboBox cboNivelVenta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.RadioButton rdbComisionGenerado;
        private System.Windows.Forms.RadioButton rdbComisionExcluido;
    }
}