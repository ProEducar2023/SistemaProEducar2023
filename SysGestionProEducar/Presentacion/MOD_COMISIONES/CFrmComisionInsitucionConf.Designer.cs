
namespace Presentacion.MOD_COMISIONES
{
    partial class CFrmComisionInsitucionConf
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.numBaseImponible = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNroCuota = new System.Windows.Forms.TextBox();
            this.trvTipoVenta = new System.Windows.Forms.TreeView();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.dtFechaIniVigencia = new System.Windows.Forms.DateTimePicker();
            this.numPorcentajeCom = new System.Windows.Forms.NumericUpDown();
            this.numImporteCom = new System.Windows.Forms.NumericUpDown();
            this.cboInstitucion = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblInstitucion = new System.Windows.Forms.Label();
            this.cboTipoComision = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numBaseImponible)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPorcentajeCom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numImporteCom)).BeginInit();
            this.SuspendLayout();
            // 
            // numBaseImponible
            // 
            this.numBaseImponible.Location = new System.Drawing.Point(175, 190);
            this.numBaseImponible.Name = "numBaseImponible";
            this.numBaseImponible.Size = new System.Drawing.Size(149, 20);
            this.numBaseImponible.TabIndex = 43;
            this.numBaseImponible.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(71, 199);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 13);
            this.label8.TabIndex = 42;
            this.label8.Text = "Base Imponible";
            // 
            // txtNroCuota
            // 
            this.txtNroCuota.Location = new System.Drawing.Point(175, 77);
            this.txtNroCuota.Name = "txtNroCuota";
            this.txtNroCuota.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtNroCuota.Size = new System.Drawing.Size(188, 20);
            this.txtNroCuota.TabIndex = 41;
            this.txtNroCuota.Text = "000";
            this.txtNroCuota.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtNroCuota_KeyDown);
            this.txtNroCuota.Leave += new System.EventHandler(this.TxtNroCuota_Leave);
            // 
            // trvTipoVenta
            // 
            this.trvTipoVenta.CheckBoxes = true;
            this.trvTipoVenta.Location = new System.Drawing.Point(175, 248);
            this.trvTipoVenta.Name = "trvTipoVenta";
            this.trvTipoVenta.Size = new System.Drawing.Size(149, 71);
            this.trvTipoVenta.TabIndex = 40;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(85, 257);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 13);
            this.label10.TabIndex = 39;
            this.label10.Text = "Tipo Venta";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(331, 183);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 16);
            this.label9.TabIndex = 38;
            this.label9.Text = "%";
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackColor = System.Drawing.Color.Teal;
            this.btnGrabar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGrabar.ForeColor = System.Drawing.Color.White;
            this.btnGrabar.Location = new System.Drawing.Point(202, 351);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(100, 37);
            this.btnGrabar.TabIndex = 37;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.UseVisualStyleBackColor = false;
            this.btnGrabar.Click += new System.EventHandler(this.BtnGrabar_Click);
            // 
            // dtFechaIniVigencia
            // 
            this.dtFechaIniVigencia.CustomFormat = "dd/MM/yyyy";
            this.dtFechaIniVigencia.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFechaIniVigencia.Location = new System.Drawing.Point(175, 218);
            this.dtFechaIniVigencia.Name = "dtFechaIniVigencia";
            this.dtFechaIniVigencia.Size = new System.Drawing.Size(149, 20);
            this.dtFechaIniVigencia.TabIndex = 36;
            // 
            // numPorcentajeCom
            // 
            this.numPorcentajeCom.Location = new System.Drawing.Point(175, 162);
            this.numPorcentajeCom.Name = "numPorcentajeCom";
            this.numPorcentajeCom.Size = new System.Drawing.Size(149, 20);
            this.numPorcentajeCom.TabIndex = 35;
            this.numPorcentajeCom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numImporteCom
            // 
            this.numImporteCom.Location = new System.Drawing.Point(175, 134);
            this.numImporteCom.Name = "numImporteCom";
            this.numImporteCom.Size = new System.Drawing.Size(149, 20);
            this.numImporteCom.TabIndex = 34;
            this.numImporteCom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cboInstitucion
            // 
            this.cboInstitucion.FormattingEnabled = true;
            this.cboInstitucion.Location = new System.Drawing.Point(175, 48);
            this.cboInstitucion.Name = "cboInstitucion";
            this.cboInstitucion.Size = new System.Drawing.Size(188, 21);
            this.cboInstitucion.TabIndex = 31;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(68, 226);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 13);
            this.label7.TabIndex = 30;
            this.label7.Text = "Inicio Vigencia";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(41, 167);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "Porcentaje Comisión";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(57, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "Importe Comisión";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(94, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "N° Cuota";
            // 
            // lblInstitucion
            // 
            this.lblInstitucion.AutoSize = true;
            this.lblInstitucion.Location = new System.Drawing.Point(89, 51);
            this.lblInstitucion.Name = "lblInstitucion";
            this.lblInstitucion.Size = new System.Drawing.Size(55, 13);
            this.lblInstitucion.TabIndex = 24;
            this.lblInstitucion.Text = "Institución";
            // 
            // cboTipoComision
            // 
            this.cboTipoComision.FormattingEnabled = true;
            this.cboTipoComision.Location = new System.Drawing.Point(175, 103);
            this.cboTipoComision.Name = "cboTipoComision";
            this.cboTipoComision.Size = new System.Drawing.Size(188, 21);
            this.cboTipoComision.TabIndex = 45;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(78, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 44;
            this.label3.Text = "Tipo Comisión";
            // 
            // CFrmComisionInsitucionConf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cboTipoComision);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numBaseImponible);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtNroCuota);
            this.Controls.Add(this.trvTipoVenta);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.dtFechaIniVigencia);
            this.Controls.Add(this.numPorcentajeCom);
            this.Controls.Add(this.numImporteCom);
            this.Controls.Add(this.cboInstitucion);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblInstitucion);
            this.Name = "CFrmComisionInsitucionConf";
            this.Size = new System.Drawing.Size(464, 500);
            this.Load += new System.EventHandler(this.CFrmComisionInsitucionConf_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numBaseImponible)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPorcentajeCom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numImporteCom)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numBaseImponible;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNroCuota;
        private System.Windows.Forms.TreeView trvTipoVenta;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        internal System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.DateTimePicker dtFechaIniVigencia;
        private System.Windows.Forms.NumericUpDown numPorcentajeCom;
        private System.Windows.Forms.NumericUpDown numImporteCom;
        private System.Windows.Forms.ComboBox cboInstitucion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblInstitucion;
        private System.Windows.Forms.ComboBox cboTipoComision;
        private System.Windows.Forms.Label label3;
    }
}
