﻿
namespace Presentacion.MOD_CXC.Reportes.Formulario
{
    partial class FrmRptInstitucionXCliente1
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
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cboINSTITUCIONES = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(368, 89);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(107, 55);
            this.button2.TabIndex = 7;
            this.button2.Text = "imprimir Detallado";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Institución";
            // 
            // cboINSTITUCIONES
            // 
            this.cboINSTITUCIONES.FormattingEnabled = true;
            this.cboINSTITUCIONES.Location = new System.Drawing.Point(91, 46);
            this.cboINSTITUCIONES.Name = "cboINSTITUCIONES";
            this.cboINSTITUCIONES.Size = new System.Drawing.Size(227, 21);
            this.cboINSTITUCIONES.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(368, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 55);
            this.button1.TabIndex = 4;
            this.button1.Text = "imprimir Resumen";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmRptInstitucionXCliente1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 152);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboINSTITUCIONES);
            this.Controls.Add(this.button1);
            this.Name = "FrmRptInstitucionXCliente1";
            this.Text = "FrmRptInstitucionXCliente1";
            this.Load += new System.EventHandler(this.FrmRptInstitucionXCliente1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboINSTITUCIONES;
        private System.Windows.Forms.Button button1;
    }
}