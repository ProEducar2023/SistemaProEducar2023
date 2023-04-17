
namespace Presentacion.MOD_COMISIONES.Reportes.Formulario
{
    partial class FrmRptComisiones
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
            this.dtFechaIniVigencia = new System.Windows.Forms.DateTimePicker();
            this.cboPersona = new System.Windows.Forms.ComboBox();
            this.cboNivelVenta = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboPrograma = new System.Windows.Forms.ComboBox();
            this.dtFechaFinVigencia = new System.Windows.Forms.DateTimePicker();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.rdbIncluirResumen = new System.Windows.Forms.RadioButton();
            this.rdbSoloDetalle = new System.Windows.Forms.RadioButton();
            this.rdbSoloResumen = new System.Windows.Forms.RadioButton();
            this.cboTipoVenta = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdbOP2 = new System.Windows.Forms.RadioButton();
            this.rdbOP1 = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtFechaIniVigencia
            // 
            this.dtFechaIniVigencia.CustomFormat = "dd/MM/yyyy";
            this.dtFechaIniVigencia.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFechaIniVigencia.Location = new System.Drawing.Point(158, 153);
            this.dtFechaIniVigencia.Name = "dtFechaIniVigencia";
            this.dtFechaIniVigencia.Size = new System.Drawing.Size(107, 20);
            this.dtFechaIniVigencia.TabIndex = 20;
            // 
            // cboPersona
            // 
            this.cboPersona.FormattingEnabled = true;
            this.cboPersona.Location = new System.Drawing.Point(158, 117);
            this.cboPersona.Name = "cboPersona";
            this.cboPersona.Size = new System.Drawing.Size(220, 21);
            this.cboPersona.TabIndex = 19;
            // 
            // cboNivelVenta
            // 
            this.cboNivelVenta.FormattingEnabled = true;
            this.cboNivelVenta.Location = new System.Drawing.Point(158, 80);
            this.cboNivelVenta.Name = "cboNivelVenta";
            this.cboNivelVenta.Size = new System.Drawing.Size(220, 21);
            this.cboNivelVenta.TabIndex = 18;
            this.cboNivelVenta.SelectedValueChanged += new System.EventHandler(this.CboNivelVenta_SelectedValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(53, 159);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Fecha Vigencia";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(88, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Persona";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Nivel Venta";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(82, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Programa";
            // 
            // cboPrograma
            // 
            this.cboPrograma.BackColor = System.Drawing.Color.White;
            this.cboPrograma.FormattingEnabled = true;
            this.cboPrograma.Location = new System.Drawing.Point(158, 16);
            this.cboPrograma.Name = "cboPrograma";
            this.cboPrograma.Size = new System.Drawing.Size(220, 21);
            this.cboPrograma.TabIndex = 22;
            // 
            // dtFechaFinVigencia
            // 
            this.dtFechaFinVigencia.CustomFormat = "dd/MM/yyyy";
            this.dtFechaFinVigencia.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFechaFinVigencia.Location = new System.Drawing.Point(271, 153);
            this.dtFechaFinVigencia.Name = "dtFechaFinVigencia";
            this.dtFechaFinVigencia.Size = new System.Drawing.Size(107, 20);
            this.dtFechaFinVigencia.TabIndex = 23;
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.Color.White;
            this.btnImprimir.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnImprimir.ForeColor = System.Drawing.Color.Teal;
            this.btnImprimir.Location = new System.Drawing.Point(158, 265);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(167, 38);
            this.btnImprimir.TabIndex = 24;
            this.btnImprimir.Text = "Generar Reporte";
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.BtnImprimir_Click);
            // 
            // rdbIncluirResumen
            // 
            this.rdbIncluirResumen.AutoSize = true;
            this.rdbIncluirResumen.Checked = true;
            this.rdbIncluirResumen.Location = new System.Drawing.Point(28, 13);
            this.rdbIncluirResumen.Name = "rdbIncluirResumen";
            this.rdbIncluirResumen.Size = new System.Drawing.Size(101, 17);
            this.rdbIncluirResumen.TabIndex = 25;
            this.rdbIncluirResumen.TabStop = true;
            this.rdbIncluirResumen.Text = "Incluir Resumen";
            this.rdbIncluirResumen.UseVisualStyleBackColor = true;
            // 
            // rdbSoloDetalle
            // 
            this.rdbSoloDetalle.AutoSize = true;
            this.rdbSoloDetalle.Location = new System.Drawing.Point(135, 13);
            this.rdbSoloDetalle.Name = "rdbSoloDetalle";
            this.rdbSoloDetalle.Size = new System.Drawing.Size(82, 17);
            this.rdbSoloDetalle.TabIndex = 26;
            this.rdbSoloDetalle.Text = "Solo Detalle";
            this.rdbSoloDetalle.UseVisualStyleBackColor = true;
            // 
            // rdbSoloResumen
            // 
            this.rdbSoloResumen.AutoSize = true;
            this.rdbSoloResumen.Location = new System.Drawing.Point(236, 13);
            this.rdbSoloResumen.Name = "rdbSoloResumen";
            this.rdbSoloResumen.Size = new System.Drawing.Size(94, 17);
            this.rdbSoloResumen.TabIndex = 27;
            this.rdbSoloResumen.Text = "Solo Resumen";
            this.rdbSoloResumen.UseVisualStyleBackColor = true;
            // 
            // cboTipoVenta
            // 
            this.cboTipoVenta.FormattingEnabled = true;
            this.cboTipoVenta.Location = new System.Drawing.Point(158, 47);
            this.cboTipoVenta.Name = "cboTipoVenta";
            this.cboTipoVenta.Size = new System.Drawing.Size(220, 21);
            this.cboTipoVenta.TabIndex = 28;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(60, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "Tipo de Venta";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbSoloResumen);
            this.groupBox1.Controls.Add(this.rdbSoloDetalle);
            this.groupBox1.Controls.Add(this.rdbIncluirResumen);
            this.groupBox1.Location = new System.Drawing.Point(57, 219);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(349, 42);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdbOP2);
            this.groupBox2.Controls.Add(this.rdbOP1);
            this.groupBox2.Location = new System.Drawing.Point(57, 178);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(349, 42);
            this.groupBox2.TabIndex = 31;
            this.groupBox2.TabStop = false;
            // 
            // rdbOP2
            // 
            this.rdbOP2.AutoSize = true;
            this.rdbOP2.Location = new System.Drawing.Point(183, 18);
            this.rdbOP2.Name = "rdbOP2";
            this.rdbOP2.Size = new System.Drawing.Size(68, 17);
            this.rdbOP2.TabIndex = 27;
            this.rdbOP2.Text = "Opción 2";
            this.rdbOP2.UseVisualStyleBackColor = true;
            // 
            // rdbOP1
            // 
            this.rdbOP1.AutoSize = true;
            this.rdbOP1.Checked = true;
            this.rdbOP1.Location = new System.Drawing.Point(101, 18);
            this.rdbOP1.Name = "rdbOP1";
            this.rdbOP1.Size = new System.Drawing.Size(68, 17);
            this.rdbOP1.TabIndex = 25;
            this.rdbOP1.TabStop = true;
            this.rdbOP1.Text = "Opción 1";
            this.rdbOP1.UseVisualStyleBackColor = true;
            // 
            // FrmRptComisiones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(467, 331);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboTipoVenta);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.dtFechaFinVigencia);
            this.Controls.Add(this.cboPrograma);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtFechaIniVigencia);
            this.Controls.Add(this.cboPersona);
            this.Controls.Add(this.cboNivelVenta);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmRptComisiones";
            this.Text = "REPORTE DE COMISIÓN";
            this.Load += new System.EventHandler(this.FrmRptComisiones_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtFechaIniVigencia;
        private System.Windows.Forms.ComboBox cboPersona;
        private System.Windows.Forms.ComboBox cboNivelVenta;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboPrograma;
        private System.Windows.Forms.DateTimePicker dtFechaFinVigencia;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.RadioButton rdbIncluirResumen;
        private System.Windows.Forms.RadioButton rdbSoloDetalle;
        private System.Windows.Forms.RadioButton rdbSoloResumen;
        private System.Windows.Forms.ComboBox cboTipoVenta;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdbOP2;
        private System.Windows.Forms.RadioButton rdbOP1;
    }
}