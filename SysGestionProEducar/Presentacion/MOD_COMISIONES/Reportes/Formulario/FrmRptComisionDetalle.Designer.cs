﻿
namespace Presentacion.MOD_COMISIONES.Reportes.Formulario
{
    partial class FrmRptComisionDetalle
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
            this.label3 = new System.Windows.Forms.Label();
            this.cboPeriodoGen = new System.Windows.Forms.ComboBox();
            this.cboNivelVenta = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.Color.White;
            this.btnImprimir.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnImprimir.ForeColor = System.Drawing.Color.Teal;
            this.btnImprimir.Location = new System.Drawing.Point(156, 139);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(167, 38);
            this.btnImprimir.TabIndex = 61;
            this.btnImprimir.Text = "Generar Reporte";
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.BtnImprimir_Click);
            // 
            // cboPersona
            // 
            this.cboPersona.FormattingEnabled = true;
            this.cboPersona.Location = new System.Drawing.Point(130, 64);
            this.cboPersona.Name = "cboPersona";
            this.cboPersona.Size = new System.Drawing.Size(220, 21);
            this.cboPersona.TabIndex = 60;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(78, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 59;
            this.label2.Text = "Persona";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(78, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 67;
            this.label3.Text = "Período";
            // 
            // cboPeriodoGen
            // 
            this.cboPeriodoGen.FormattingEnabled = true;
            this.cboPeriodoGen.Location = new System.Drawing.Point(130, 91);
            this.cboPeriodoGen.Name = "cboPeriodoGen";
            this.cboPeriodoGen.Size = new System.Drawing.Size(220, 21);
            this.cboPeriodoGen.TabIndex = 66;
            // 
            // cboNivelVenta
            // 
            this.cboNivelVenta.FormattingEnabled = true;
            this.cboNivelVenta.Location = new System.Drawing.Point(130, 37);
            this.cboNivelVenta.Name = "cboNivelVenta";
            this.cboNivelVenta.Size = new System.Drawing.Size(220, 21);
            this.cboNivelVenta.TabIndex = 69;
            this.cboNivelVenta.SelectedValueChanged += new System.EventHandler(this.CboNivelVenta_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 68;
            this.label1.Text = "Nivel";
            // 
            // FrmRptComisionDetalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 249);
            this.Controls.Add(this.cboNivelVenta);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboPeriodoGen);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.cboPersona);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmRptComisionDetalle";
            this.Text = "REPORTE DETALLE DE COMISIONES";
            this.Load += new System.EventHandler(this.FrmRptComisionDetalle_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.ComboBox cboPersona;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboPeriodoGen;
        private System.Windows.Forms.ComboBox cboNivelVenta;
        private System.Windows.Forms.Label label1;
    }
}