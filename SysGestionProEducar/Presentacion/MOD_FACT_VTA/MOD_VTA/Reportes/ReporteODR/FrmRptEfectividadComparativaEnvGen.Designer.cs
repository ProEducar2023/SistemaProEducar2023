
namespace Presentacion.MOD_FACT_VTA.MOD_VTA.Reportes.ReporteODR
{
    partial class FrmRptEfectividadComparativaEnvGen
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConsultar
            // 
            this.btnConsultar.BackColor = System.Drawing.Color.Teal;
            this.btnConsultar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnConsultar.ForeColor = System.Drawing.Color.White;
            this.btnConsultar.Location = new System.Drawing.Point(397, 126);
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
            this.dtFechaFin.Location = new System.Drawing.Point(261, 143);
            this.dtFechaFin.Name = "dtFechaFin";
            this.dtFechaFin.ShowUpDown = true;
            this.dtFechaFin.Size = new System.Drawing.Size(95, 20);
            this.dtFechaFin.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Programa";
            // 
            // cboPrograma
            // 
            this.cboPrograma.FormattingEnabled = true;
            this.cboPrograma.Location = new System.Drawing.Point(120, 17);
            this.cboPrograma.Name = "cboPrograma";
            this.cboPrograma.Size = new System.Drawing.Size(236, 21);
            this.cboPrograma.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(231, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(10, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "-";
            // 
            // dtFechaInicio
            // 
            this.dtFechaInicio.CustomFormat = "MM/yyyy";
            this.dtFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFechaInicio.Location = new System.Drawing.Point(120, 143);
            this.dtFechaInicio.Name = "dtFechaInicio";
            this.dtFechaInicio.ShowUpDown = true;
            this.dtFechaInicio.Size = new System.Drawing.Size(97, 20);
            this.dtFechaInicio.TabIndex = 6;
            // 
            // chkInstitucion
            // 
            this.chkInstitucion.AutoSize = true;
            this.chkInstitucion.Location = new System.Drawing.Point(99, 113);
            this.chkInstitucion.Name = "chkInstitucion";
            this.chkInstitucion.Size = new System.Drawing.Size(15, 14);
            this.chkInstitucion.TabIndex = 5;
            this.chkInstitucion.UseVisualStyleBackColor = true;
            this.chkInstitucion.CheckedChanged += new System.EventHandler(this.ChkPCobranza_CheckedChanged);
            // 
            // chkDepartamento
            // 
            this.chkDepartamento.AutoSize = true;
            this.chkDepartamento.Location = new System.Drawing.Point(99, 84);
            this.chkDepartamento.Name = "chkDepartamento";
            this.chkDepartamento.Size = new System.Drawing.Size(15, 14);
            this.chkDepartamento.TabIndex = 5;
            this.chkDepartamento.UseVisualStyleBackColor = true;
            this.chkDepartamento.CheckedChanged += new System.EventHandler(this.ChkPCobranza_CheckedChanged);
            // 
            // chkPCobranza
            // 
            this.chkPCobranza.AutoSize = true;
            this.chkPCobranza.Location = new System.Drawing.Point(99, 52);
            this.chkPCobranza.Name = "chkPCobranza";
            this.chkPCobranza.Size = new System.Drawing.Size(15, 14);
            this.chkPCobranza.TabIndex = 5;
            this.chkPCobranza.UseVisualStyleBackColor = true;
            this.chkPCobranza.CheckedChanged += new System.EventHandler(this.ChkPCobranza_CheckedChanged);
            // 
            // cboInstitucion
            // 
            this.cboInstitucion.FormattingEnabled = true;
            this.cboInstitucion.Location = new System.Drawing.Point(120, 109);
            this.cboInstitucion.Name = "cboInstitucion";
            this.cboInstitucion.Size = new System.Drawing.Size(236, 21);
            this.cboInstitucion.TabIndex = 4;
            // 
            // cboDetartamento
            // 
            this.cboDetartamento.FormattingEnabled = true;
            this.cboDetartamento.Location = new System.Drawing.Point(120, 80);
            this.cboDetartamento.Name = "cboDetartamento";
            this.cboDetartamento.Size = new System.Drawing.Size(236, 21);
            this.cboDetartamento.TabIndex = 4;
            // 
            // cboPCobranza
            // 
            this.cboPCobranza.FormattingEnabled = true;
            this.cboPCobranza.Location = new System.Drawing.Point(120, 49);
            this.cboPCobranza.Name = "cboPCobranza";
            this.cboPCobranza.Size = new System.Drawing.Size(236, 21);
            this.cboPCobranza.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Institución";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Período";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Departamento";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "P. Cobranza";
            // 
            // panel1
            // 
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
            this.panel1.Location = new System.Drawing.Point(19, 14);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(512, 187);
            this.panel1.TabIndex = 1;
            // 
            // FrmRptEfectividadComparativaEnvGen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 214);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmRptEfectividadComparativaEnvGen";
            this.Text = "REPORTE DE EFECTIVIDAD DE PLANILLA GENERADA Y ENVIADA VS. EJECUTADA";
            this.Load += new System.EventHandler(this.FrmRptEfectividadComparativaEnvGen_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.DateTimePicker dtFechaFin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboPrograma;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtFechaInicio;
        private System.Windows.Forms.CheckBox chkInstitucion;
        private System.Windows.Forms.CheckBox chkDepartamento;
        private System.Windows.Forms.CheckBox chkPCobranza;
        private System.Windows.Forms.ComboBox cboInstitucion;
        private System.Windows.Forms.ComboBox cboDetartamento;
        private System.Windows.Forms.ComboBox cboPCobranza;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
    }
}