
namespace Presentacion.MOD_CXC.Reportes.Formulario
{
    partial class FrmRptEfectividadComparativa
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.dtFechaFin = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cboPrograma = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.chkInstitucion = new System.Windows.Forms.CheckBox();
            this.chkDepartamento = new System.Windows.Forms.CheckBox();
            this.chkPCobranza = new System.Windows.Forms.CheckBox();
            this.cboInstitucion = new System.Windows.Forms.ComboBox();
            this.cboDetartamento = new System.Windows.Forms.ComboBox();
            this.cboPCobranza = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbOp5 = new System.Windows.Forms.RadioButton();
            this.rdbOp4 = new System.Windows.Forms.RadioButton();
            this.rdbOp3 = new System.Windows.Forms.RadioButton();
            this.rdbOp2 = new System.Windows.Forms.RadioButton();
            this.rdbOp1 = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.btnConsultar);
            this.panel1.Controls.Add(this.dtFechaFin);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cboPrograma);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.dtFechaInicio);
            this.panel1.Controls.Add(this.chkInstitucion);
            this.panel1.Controls.Add(this.chkDepartamento);
            this.panel1.Controls.Add(this.chkPCobranza);
            this.panel1.Controls.Add(this.cboInstitucion);
            this.panel1.Controls.Add(this.cboDetartamento);
            this.panel1.Controls.Add(this.cboPCobranza);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(12, 15);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(632, 181);
            this.panel1.TabIndex = 0;
            // 
            // btnConsultar
            // 
            this.btnConsultar.BackColor = System.Drawing.Color.Teal;
            this.btnConsultar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnConsultar.ForeColor = System.Drawing.Color.White;
            this.btnConsultar.Location = new System.Drawing.Point(522, 126);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(82, 37);
            this.btnConsultar.TabIndex = 9;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = false;
            this.btnConsultar.Click += new System.EventHandler(this.BtnConsular_Click);
            // 
            // dtFechaFin
            // 
            this.dtFechaFin.CustomFormat = "MM/yyyy";
            this.dtFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFechaFin.Location = new System.Drawing.Point(360, 147);
            this.dtFechaFin.Name = "dtFechaFin";
            this.dtFechaFin.ShowUpDown = true;
            this.dtFechaFin.Size = new System.Drawing.Size(95, 20);
            this.dtFechaFin.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(123, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Programa";
            // 
            // cboPrograma
            // 
            this.cboPrograma.FormattingEnabled = true;
            this.cboPrograma.Location = new System.Drawing.Point(219, 21);
            this.cboPrograma.Name = "cboPrograma";
            this.cboPrograma.Size = new System.Drawing.Size(236, 21);
            this.cboPrograma.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(330, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(10, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "-";
            // 
            // dtFechaInicio
            // 
            this.dtFechaInicio.CustomFormat = "MM/yyyy";
            this.dtFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFechaInicio.Location = new System.Drawing.Point(219, 147);
            this.dtFechaInicio.Name = "dtFechaInicio";
            this.dtFechaInicio.ShowUpDown = true;
            this.dtFechaInicio.Size = new System.Drawing.Size(97, 20);
            this.dtFechaInicio.TabIndex = 6;
            // 
            // chkInstitucion
            // 
            this.chkInstitucion.AutoSize = true;
            this.chkInstitucion.Location = new System.Drawing.Point(198, 117);
            this.chkInstitucion.Name = "chkInstitucion";
            this.chkInstitucion.Size = new System.Drawing.Size(15, 14);
            this.chkInstitucion.TabIndex = 5;
            this.chkInstitucion.UseVisualStyleBackColor = true;
            this.chkInstitucion.CheckedChanged += new System.EventHandler(this.ChkPCobranza_CheckedChanged);
            // 
            // chkDepartamento
            // 
            this.chkDepartamento.AutoSize = true;
            this.chkDepartamento.Location = new System.Drawing.Point(198, 88);
            this.chkDepartamento.Name = "chkDepartamento";
            this.chkDepartamento.Size = new System.Drawing.Size(15, 14);
            this.chkDepartamento.TabIndex = 5;
            this.chkDepartamento.UseVisualStyleBackColor = true;
            this.chkDepartamento.CheckedChanged += new System.EventHandler(this.ChkPCobranza_CheckedChanged);
            // 
            // chkPCobranza
            // 
            this.chkPCobranza.AutoSize = true;
            this.chkPCobranza.Location = new System.Drawing.Point(198, 56);
            this.chkPCobranza.Name = "chkPCobranza";
            this.chkPCobranza.Size = new System.Drawing.Size(15, 14);
            this.chkPCobranza.TabIndex = 5;
            this.chkPCobranza.UseVisualStyleBackColor = true;
            this.chkPCobranza.CheckedChanged += new System.EventHandler(this.ChkPCobranza_CheckedChanged);
            // 
            // cboInstitucion
            // 
            this.cboInstitucion.FormattingEnabled = true;
            this.cboInstitucion.Location = new System.Drawing.Point(219, 113);
            this.cboInstitucion.Name = "cboInstitucion";
            this.cboInstitucion.Size = new System.Drawing.Size(236, 21);
            this.cboInstitucion.TabIndex = 4;
            // 
            // cboDetartamento
            // 
            this.cboDetartamento.FormattingEnabled = true;
            this.cboDetartamento.Location = new System.Drawing.Point(219, 84);
            this.cboDetartamento.Name = "cboDetartamento";
            this.cboDetartamento.Size = new System.Drawing.Size(236, 21);
            this.cboDetartamento.TabIndex = 4;
            // 
            // cboPCobranza
            // 
            this.cboPCobranza.FormattingEnabled = true;
            this.cboPCobranza.Location = new System.Drawing.Point(219, 53);
            this.cboPCobranza.Name = "cboPCobranza";
            this.cboPCobranza.Size = new System.Drawing.Size(236, 21);
            this.cboPCobranza.TabIndex = 4;
            this.cboPCobranza.TextChanged += new System.EventHandler(this.CboPCobranza_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(123, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Institución";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(123, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Período";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(123, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Departamento";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(123, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "P. Cobranza";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox1.Controls.Add(this.rdbOp5);
            this.groupBox1.Controls.Add(this.rdbOp4);
            this.groupBox1.Controls.Add(this.rdbOp3);
            this.groupBox1.Controls.Add(this.rdbOp2);
            this.groupBox1.Controls.Add(this.rdbOp1);
            this.groupBox1.Location = new System.Drawing.Point(12, 202);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(632, 118);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // rdbOp5
            // 
            this.rdbOp5.AutoSize = true;
            this.rdbOp5.Location = new System.Drawing.Point(222, 70);
            this.rdbOp5.Name = "rdbOp5";
            this.rdbOp5.Size = new System.Drawing.Size(210, 30);
            this.rdbOp5.TabIndex = 18;
            this.rdbOp5.TabStop = true;
            this.rdbOp5.Text = "Por Motivo No Descontado por Cliente \r\n(Comparativo por Mes) - RESUMEN";
            this.rdbOp5.UseVisualStyleBackColor = true;
            // 
            // rdbOp4
            // 
            this.rdbOp4.AutoSize = true;
            this.rdbOp4.Location = new System.Drawing.Point(6, 70);
            this.rdbOp4.Name = "rdbOp4";
            this.rdbOp4.Size = new System.Drawing.Size(210, 43);
            this.rdbOp4.TabIndex = 16;
            this.rdbOp4.TabStop = true;
            this.rdbOp4.Text = "Por Motivo No Descontado por Cliente \r\n(Comparativo por Mes) - DETALLE\r\n\r\n";
            this.rdbOp4.UseVisualStyleBackColor = true;
            // 
            // rdbOp3
            // 
            this.rdbOp3.AutoSize = true;
            this.rdbOp3.Location = new System.Drawing.Point(427, 16);
            this.rdbOp3.Name = "rdbOp3";
            this.rdbOp3.Size = new System.Drawing.Size(199, 43);
            this.rdbOp3.TabIndex = 15;
            this.rdbOp3.TabStop = true;
            this.rdbOp3.Text = "Efectividad de Planilla \r\nGenerado - Enviado Vs Descontado \r\n(Comparativo por Mes" +
    " en Importes)";
            this.rdbOp3.UseVisualStyleBackColor = true;
            // 
            // rdbOp2
            // 
            this.rdbOp2.AutoSize = true;
            this.rdbOp2.Location = new System.Drawing.Point(6, 16);
            this.rdbOp2.Name = "rdbOp2";
            this.rdbOp2.Size = new System.Drawing.Size(193, 43);
            this.rdbOp2.TabIndex = 14;
            this.rdbOp2.TabStop = true;
            this.rdbOp2.Text = "Efectividad de Planilla Generado - \r\nEnviado Vs Descontado \r\n(Mensual / Acumulado" +
    " en Importes)";
            this.rdbOp2.UseVisualStyleBackColor = true;
            // 
            // rdbOp1
            // 
            this.rdbOp1.AutoSize = true;
            this.rdbOp1.Location = new System.Drawing.Point(219, 16);
            this.rdbOp1.Name = "rdbOp1";
            this.rdbOp1.Size = new System.Drawing.Size(205, 43);
            this.rdbOp1.TabIndex = 13;
            this.rdbOp1.TabStop = true;
            this.rdbOp1.Text = "Efectividad de Planilla \r\nGenerado - Enviado Vs Descontado \r\n(Comparativo por Mes" +
    " en Porcentajes)\r\n";
            this.rdbOp1.UseVisualStyleBackColor = true;
            // 
            // FrmRptEfectividadComparativa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(656, 332);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmRptEfectividadComparativa";
            this.Text = "REPORTE DE EFECTIVIDAD DE PLANILLAS DSCTO";
            this.Load += new System.EventHandler(this.FrmRptEfectividadComparativa_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.DateTimePicker dtFechaFin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboPrograma;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtFechaInicio;
        private System.Windows.Forms.CheckBox chkDepartamento;
        private System.Windows.Forms.CheckBox chkPCobranza;
        private System.Windows.Forms.ComboBox cboDetartamento;
        private System.Windows.Forms.ComboBox cboPCobranza;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkInstitucion;
        private System.Windows.Forms.ComboBox cboInstitucion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbOp3;
        private System.Windows.Forms.RadioButton rdbOp2;
        private System.Windows.Forms.RadioButton rdbOp1;
        private System.Windows.Forms.RadioButton rdbOp5;
        private System.Windows.Forms.RadioButton rdbOp4;
    }
}