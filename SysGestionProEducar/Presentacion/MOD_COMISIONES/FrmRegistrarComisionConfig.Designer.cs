
namespace Presentacion.MOD_COMISIONES
{
    partial class FrmRegistrarComisionConfig
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cboNivelVenta = new System.Windows.Forms.ComboBox();
            this.cboPersona = new System.Windows.Forms.ComboBox();
            this.cboTipoComision = new System.Windows.Forms.ComboBox();
            this.numImporteCom = new System.Windows.Forms.NumericUpDown();
            this.numPorcentajeCom = new System.Windows.Forms.NumericUpDown();
            this.dtFechaIniVigencia = new System.Windows.Forms.DateTimePicker();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.trvTipoVenta = new System.Windows.Forms.TreeView();
            this.trvPersonas = new System.Windows.Forms.TreeView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numBaseImponible = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNroCuota = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numImporteCom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPorcentajeCom)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBaseImponible)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nivel Venta";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(90, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Persona";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(63, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tipo Comisión";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(86, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "N° Cuota";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(49, 181);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Importe Comisión";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(33, 209);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Porcentaje Comisión";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(60, 268);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Inicio Vigencia";
            // 
            // cboNivelVenta
            // 
            this.cboNivelVenta.FormattingEnabled = true;
            this.cboNivelVenta.Location = new System.Drawing.Point(160, 45);
            this.cboNivelVenta.Name = "cboNivelVenta";
            this.cboNivelVenta.Size = new System.Drawing.Size(188, 21);
            this.cboNivelVenta.TabIndex = 8;
            this.cboNivelVenta.SelectedValueChanged += new System.EventHandler(this.CboTipoPersona_SelectedValueChanged);
            // 
            // cboPersona
            // 
            this.cboPersona.FormattingEnabled = true;
            this.cboPersona.Location = new System.Drawing.Point(160, 80);
            this.cboPersona.Name = "cboPersona";
            this.cboPersona.Size = new System.Drawing.Size(188, 21);
            this.cboPersona.TabIndex = 9;
            // 
            // cboTipoComision
            // 
            this.cboTipoComision.FormattingEnabled = true;
            this.cboTipoComision.Location = new System.Drawing.Point(160, 111);
            this.cboTipoComision.Name = "cboTipoComision";
            this.cboTipoComision.Size = new System.Drawing.Size(188, 21);
            this.cboTipoComision.TabIndex = 10;
            // 
            // numImporteCom
            // 
            this.numImporteCom.Location = new System.Drawing.Point(160, 179);
            this.numImporteCom.Name = "numImporteCom";
            this.numImporteCom.Size = new System.Drawing.Size(149, 20);
            this.numImporteCom.TabIndex = 12;
            this.numImporteCom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numPorcentajeCom
            // 
            this.numPorcentajeCom.Location = new System.Drawing.Point(160, 207);
            this.numPorcentajeCom.Name = "numPorcentajeCom";
            this.numPorcentajeCom.Size = new System.Drawing.Size(149, 20);
            this.numPorcentajeCom.TabIndex = 13;
            this.numPorcentajeCom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dtFechaIniVigencia
            // 
            this.dtFechaIniVigencia.CustomFormat = "dd/MM/yyyy";
            this.dtFechaIniVigencia.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFechaIniVigencia.Location = new System.Drawing.Point(160, 263);
            this.dtFechaIniVigencia.Name = "dtFechaIniVigencia";
            this.dtFechaIniVigencia.Size = new System.Drawing.Size(149, 20);
            this.dtFechaIniVigencia.TabIndex = 14;
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackColor = System.Drawing.Color.Teal;
            this.btnGrabar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGrabar.ForeColor = System.Drawing.Color.White;
            this.btnGrabar.Location = new System.Drawing.Point(187, 396);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(100, 37);
            this.btnGrabar.TabIndex = 16;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.UseVisualStyleBackColor = false;
            this.btnGrabar.Click += new System.EventHandler(this.BtnGrabar_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(315, 209);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 16);
            this.label9.TabIndex = 17;
            this.label9.Text = "%";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(77, 299);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Tipo Venta";
            // 
            // trvTipoVenta
            // 
            this.trvTipoVenta.CheckBoxes = true;
            this.trvTipoVenta.Location = new System.Drawing.Point(160, 293);
            this.trvTipoVenta.Name = "trvTipoVenta";
            this.trvTipoVenta.Size = new System.Drawing.Size(149, 71);
            this.trvTipoVenta.TabIndex = 20;
            // 
            // trvPersonas
            // 
            this.trvPersonas.CheckBoxes = true;
            this.trvPersonas.Location = new System.Drawing.Point(12, 12);
            this.trvPersonas.Name = "trvPersonas";
            this.trvPersonas.Size = new System.Drawing.Size(289, 500);
            this.trvPersonas.TabIndex = 21;
            this.trvPersonas.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.TrvPersonas_AfterCheck);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numBaseImponible);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtNroCuota);
            this.groupBox1.Controls.Add(this.trvTipoVenta);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.btnGrabar);
            this.groupBox1.Controls.Add(this.dtFechaIniVigencia);
            this.groupBox1.Controls.Add(this.numPorcentajeCom);
            this.groupBox1.Controls.Add(this.numImporteCom);
            this.groupBox1.Controls.Add(this.cboTipoComision);
            this.groupBox1.Controls.Add(this.cboPersona);
            this.groupBox1.Controls.Add(this.cboNivelVenta);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(309, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(464, 500);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            // 
            // numBaseImponible
            // 
            this.numBaseImponible.Location = new System.Drawing.Point(160, 235);
            this.numBaseImponible.Name = "numBaseImponible";
            this.numBaseImponible.Size = new System.Drawing.Size(149, 20);
            this.numBaseImponible.TabIndex = 23;
            this.numBaseImponible.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(63, 241);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Base Imponible";
            // 
            // txtNroCuota
            // 
            this.txtNroCuota.Location = new System.Drawing.Point(160, 147);
            this.txtNroCuota.Name = "txtNroCuota";
            this.txtNroCuota.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtNroCuota.Size = new System.Drawing.Size(188, 20);
            this.txtNroCuota.TabIndex = 21;
            this.txtNroCuota.Text = "000";
            this.txtNroCuota.TextChanged += new System.EventHandler(this.TxtNroCuota_TextChanged);
            this.txtNroCuota.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtNroCuota_KeyDown);
            this.txtNroCuota.Leave += new System.EventHandler(this.TxtNroCuota_Leave);
            // 
            // FrmRegistrarComisionConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 521);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.trvPersonas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmRegistrarComisionConfig";
            this.Text = "COMISIÓN";
            this.Load += new System.EventHandler(this.FrmRegistrarComision_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numImporteCom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPorcentajeCom)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBaseImponible)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboNivelVenta;
        private System.Windows.Forms.ComboBox cboPersona;
        private System.Windows.Forms.ComboBox cboTipoComision;
        private System.Windows.Forms.NumericUpDown numImporteCom;
        private System.Windows.Forms.NumericUpDown numPorcentajeCom;
        private System.Windows.Forms.DateTimePicker dtFechaIniVigencia;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TreeView trvTipoVenta;
        private System.Windows.Forms.TreeView trvPersonas;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtNroCuota;
        private System.Windows.Forms.NumericUpDown numBaseImponible;
        private System.Windows.Forms.Label label8;
        internal System.Windows.Forms.Button btnGrabar;
    }
}