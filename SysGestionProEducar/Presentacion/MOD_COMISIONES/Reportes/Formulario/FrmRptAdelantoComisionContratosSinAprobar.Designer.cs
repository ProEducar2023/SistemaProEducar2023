
namespace Presentacion.MOD_COMISIONES.Reportes.Formulario
{
    partial class FrmRptAdelantoComisionContratosSinAprobar
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
            this.btnImprimir = new System.Windows.Forms.Button();
            this.cboPersona = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboPrograma = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboNroAdelanto = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.Color.White;
            this.btnImprimir.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnImprimir.ForeColor = System.Drawing.Color.Teal;
            this.btnImprimir.Location = new System.Drawing.Point(154, 141);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(167, 38);
            this.btnImprimir.TabIndex = 54;
            this.btnImprimir.Text = "Generar Reporte";
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.BtnImprimir_Click);
            // 
            // cboPersona
            // 
            this.cboPersona.FormattingEnabled = true;
            this.cboPersona.Location = new System.Drawing.Point(128, 91);
            this.cboPersona.Name = "cboPersona";
            this.cboPersona.Size = new System.Drawing.Size(220, 21);
            this.cboPersona.TabIndex = 53;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(76, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 52;
            this.label2.Text = "Persona";
            // 
            // cboPrograma
            // 
            this.cboPrograma.BackColor = System.Drawing.Color.White;
            this.cboPrograma.FormattingEnabled = true;
            this.cboPrograma.Location = new System.Drawing.Point(128, 37);
            this.cboPrograma.Name = "cboPrograma";
            this.cboPrograma.Size = new System.Drawing.Size(220, 21);
            this.cboPrograma.TabIndex = 56;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(70, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 55;
            this.label3.Text = "Programa";
            // 
            // cboNroAdelanto
            // 
            this.cboNroAdelanto.FormattingEnabled = true;
            this.cboNroAdelanto.Location = new System.Drawing.Point(128, 64);
            this.cboNroAdelanto.Name = "cboNroAdelanto";
            this.cboNroAdelanto.Size = new System.Drawing.Size(220, 21);
            this.cboNroAdelanto.TabIndex = 58;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 57;
            this.label1.Text = "Nro Grupo";
            // 
            // FrmRptAdelantoComisionContratosSinAprobar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 249);
            this.Controls.Add(this.cboNroAdelanto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboPrograma);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.cboPersona);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmRptAdelantoComisionContratosSinAprobar";
            this.Text = "REPORTE DE ADELANTO DE COMISIONES DE CONTRATOS SIN APROBAR";
            this.Load += new System.EventHandler(this.FrmRptAdelantoComisionContratosSinAprobar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.ComboBox cboPersona;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboPrograma;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboNroAdelanto;
        private System.Windows.Forms.Label label1;
    }
}