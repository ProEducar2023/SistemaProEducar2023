
namespace Presentacion.MOD_FACT_VTA.MOD_VTA.Reportes.ReporteODR
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
            this.panel1.Location = new System.Drawing.Point(20, 15);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(576, 181);
            this.panel1.TabIndex = 0;
            // 
            // btnConsultar
            // 
            this.btnConsultar.BackColor = System.Drawing.Color.Teal;
            this.btnConsultar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnConsultar.ForeColor = System.Drawing.Color.White;
            this.btnConsultar.Location = new System.Drawing.Point(440, 126);
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
            this.dtFechaFin.Location = new System.Drawing.Point(304, 143);
            this.dtFechaFin.Name = "dtFechaFin";
            this.dtFechaFin.ShowUpDown = true;
            this.dtFechaFin.Size = new System.Drawing.Size(95, 20);
            this.dtFechaFin.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Programa";
            // 
            // cboPrograma
            // 
            this.cboPrograma.FormattingEnabled = true;
            this.cboPrograma.Location = new System.Drawing.Point(163, 17);
            this.cboPrograma.Name = "cboPrograma";
            this.cboPrograma.Size = new System.Drawing.Size(236, 21);
            this.cboPrograma.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(274, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(10, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "-";
            // 
            // dtFechaInicio
            // 
            this.dtFechaInicio.CustomFormat = "MM/yyyy";
            this.dtFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFechaInicio.Location = new System.Drawing.Point(163, 143);
            this.dtFechaInicio.Name = "dtFechaInicio";
            this.dtFechaInicio.ShowUpDown = true;
            this.dtFechaInicio.Size = new System.Drawing.Size(97, 20);
            this.dtFechaInicio.TabIndex = 6;
            // 
            // chkInstitucion
            // 
            this.chkInstitucion.AutoSize = true;
            this.chkInstitucion.Location = new System.Drawing.Point(142, 113);
            this.chkInstitucion.Name = "chkInstitucion";
            this.chkInstitucion.Size = new System.Drawing.Size(15, 14);
            this.chkInstitucion.TabIndex = 5;
            this.chkInstitucion.UseVisualStyleBackColor = true;
            this.chkInstitucion.CheckedChanged += new System.EventHandler(this.ChkPCobranza_CheckedChanged);
            // 
            // chkDepartamento
            // 
            this.chkDepartamento.AutoSize = true;
            this.chkDepartamento.Location = new System.Drawing.Point(142, 84);
            this.chkDepartamento.Name = "chkDepartamento";
            this.chkDepartamento.Size = new System.Drawing.Size(15, 14);
            this.chkDepartamento.TabIndex = 5;
            this.chkDepartamento.UseVisualStyleBackColor = true;
            this.chkDepartamento.CheckedChanged += new System.EventHandler(this.ChkPCobranza_CheckedChanged);
            // 
            // chkPCobranza
            // 
            this.chkPCobranza.AutoSize = true;
            this.chkPCobranza.Location = new System.Drawing.Point(142, 52);
            this.chkPCobranza.Name = "chkPCobranza";
            this.chkPCobranza.Size = new System.Drawing.Size(15, 14);
            this.chkPCobranza.TabIndex = 5;
            this.chkPCobranza.UseVisualStyleBackColor = true;
            this.chkPCobranza.CheckedChanged += new System.EventHandler(this.ChkPCobranza_CheckedChanged);
            // 
            // cboInstitucion
            // 
            this.cboInstitucion.FormattingEnabled = true;
            this.cboInstitucion.Location = new System.Drawing.Point(163, 109);
            this.cboInstitucion.Name = "cboInstitucion";
            this.cboInstitucion.Size = new System.Drawing.Size(236, 21);
            this.cboInstitucion.TabIndex = 4;
            // 
            // cboDetartamento
            // 
            this.cboDetartamento.FormattingEnabled = true;
            this.cboDetartamento.Location = new System.Drawing.Point(163, 80);
            this.cboDetartamento.Name = "cboDetartamento";
            this.cboDetartamento.Size = new System.Drawing.Size(236, 21);
            this.cboDetartamento.TabIndex = 4;
            // 
            // cboPCobranza
            // 
            this.cboPCobranza.FormattingEnabled = true;
            this.cboPCobranza.Location = new System.Drawing.Point(163, 49);
            this.cboPCobranza.Name = "cboPCobranza";
            this.cboPCobranza.Size = new System.Drawing.Size(236, 21);
            this.cboPCobranza.TabIndex = 4;
            this.cboPCobranza.TextChanged += new System.EventHandler(this.CboPCobranza_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(67, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Institución";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(67, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Período";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(67, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Departamento";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(67, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "P. Cobranza";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox1.Controls.Add(this.rdbOp3);
            this.groupBox1.Controls.Add(this.rdbOp2);
            this.groupBox1.Controls.Add(this.rdbOp1);
            this.groupBox1.Location = new System.Drawing.Point(20, 202);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(576, 65);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // rdbOp3
            // 
            this.rdbOp3.AutoSize = true;
            this.rdbOp3.Location = new System.Drawing.Point(376, 14);
            this.rdbOp3.Name = "rdbOp3";
            this.rdbOp3.Size = new System.Drawing.Size(199, 43);
            this.rdbOp3.TabIndex = 15;
            this.rdbOp3.TabStop = true;
            this.rdbOp3.Text = "Reporte de Efectividad de Planilla \r\nGenerado - Enviado Vs Descontado \r\nMes a Mes" +
    "";
            this.rdbOp3.UseVisualStyleBackColor = true;
            // 
            // rdbOp2
            // 
            this.rdbOp2.AutoSize = true;
            this.rdbOp2.Location = new System.Drawing.Point(182, 20);
            this.rdbOp2.Name = "rdbOp2";
            this.rdbOp2.Size = new System.Drawing.Size(196, 30);
            this.rdbOp2.TabIndex = 14;
            this.rdbOp2.TabStop = true;
            this.rdbOp2.Text = "Reporte de Efectividad de Planilla \r\nGenerado - Enviado Vs Descontado";
            this.rdbOp2.UseVisualStyleBackColor = true;
            // 
            // rdbOp1
            // 
            this.rdbOp1.AutoSize = true;
            this.rdbOp1.Location = new System.Drawing.Point(10, 20);
            this.rdbOp1.Name = "rdbOp1";
            this.rdbOp1.Size = new System.Drawing.Size(166, 30);
            this.rdbOp1.TabIndex = 13;
            this.rdbOp1.TabStop = true;
            this.rdbOp1.Text = "Reporte de Efectividad \r\nComparativo en porcentaje(%)";
            this.rdbOp1.UseVisualStyleBackColor = true;
            // 
            // FrmRptEfectividadComparativa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(617, 285);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmRptEfectividadComparativa";
            this.Text = "REPORTE EFECTIVIDAD COMPARATIVA";
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
    }
}