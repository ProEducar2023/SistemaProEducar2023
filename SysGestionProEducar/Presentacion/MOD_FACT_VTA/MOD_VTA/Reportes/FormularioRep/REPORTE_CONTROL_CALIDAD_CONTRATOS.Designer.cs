namespace Presentacion.MOD_FACT_VTA.MOD_VTA.Reportes.FormularioRep
{
    partial class REPORTE_CONTROL_CALIDAD_CONTRATOS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(REPORTE_CONTROL_CALIDAD_CONTRATOS));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboPrograma = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rbt_fecha_contrato = new System.Windows.Forms.RadioButton();
            this.rbt_fecha_reporte = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_impresion2 = new System.Windows.Forms.Button();
            this.btn_pantalla2 = new System.Windows.Forms.Button();
            this.btn_salir2 = new System.Windows.Forms.Button();
            this.rbt_fecha_aprobacion = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp_hasta = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.dtp_desde = new System.Windows.Forms.DateTimePicker();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbt_fecha_aprobacion);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.dtp_hasta);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.dtp_desde);
            this.groupBox2.Controls.Add(this.cboPrograma);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.rbt_fecha_contrato);
            this.groupBox2.Controls.Add(this.rbt_fecha_reporte);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(354, 177);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filtros";
            // 
            // cboPrograma
            // 
            this.cboPrograma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPrograma.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPrograma.FormattingEnabled = true;
            this.cboPrograma.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12"});
            this.cboPrograma.Location = new System.Drawing.Point(82, 21);
            this.cboPrograma.Name = "cboPrograma";
            this.cboPrograma.Size = new System.Drawing.Size(222, 22);
            this.cboPrograma.TabIndex = 257;
            this.cboPrograma.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 258;
            this.label3.Text = "Programa";
            // 
            // rbt_fecha_contrato
            // 
            this.rbt_fecha_contrato.AutoSize = true;
            this.rbt_fecha_contrato.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbt_fecha_contrato.Location = new System.Drawing.Point(80, 93);
            this.rbt_fecha_contrato.Name = "rbt_fecha_contrato";
            this.rbt_fecha_contrato.Size = new System.Drawing.Size(153, 17);
            this.rbt_fecha_contrato.TabIndex = 54;
            this.rbt_fecha_contrato.Text = "Por Fecha de Contrato";
            this.rbt_fecha_contrato.UseVisualStyleBackColor = true;
            // 
            // rbt_fecha_reporte
            // 
            this.rbt_fecha_reporte.AutoSize = true;
            this.rbt_fecha_reporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbt_fecha_reporte.Location = new System.Drawing.Point(80, 71);
            this.rbt_fecha_reporte.Name = "rbt_fecha_reporte";
            this.rbt_fecha_reporte.Size = new System.Drawing.Size(150, 17);
            this.rbt_fecha_reporte.TabIndex = 53;
            this.rbt_fecha_reporte.Text = "Por Fecha de Reporte";
            this.rbt_fecha_reporte.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.White;
            this.groupBox3.Controls.Add(this.btn_impresion2);
            this.groupBox3.Controls.Add(this.btn_pantalla2);
            this.groupBox3.Controls.Add(this.btn_salir2);
            this.groupBox3.Location = new System.Drawing.Point(12, 195);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(354, 54);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            // 
            // btn_impresion2
            // 
            this.btn_impresion2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_impresion2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_impresion2.Image = ((System.Drawing.Image)(resources.GetObject("btn_impresion2.Image")));
            this.btn_impresion2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_impresion2.Location = new System.Drawing.Point(137, 15);
            this.btn_impresion2.Name = "btn_impresion2";
            this.btn_impresion2.Size = new System.Drawing.Size(77, 27);
            this.btn_impresion2.TabIndex = 38;
            this.btn_impresion2.Text = "&Imprimir";
            this.btn_impresion2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_impresion2.UseVisualStyleBackColor = false;
            // 
            // btn_pantalla2
            // 
            this.btn_pantalla2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_pantalla2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_pantalla2.Image = ((System.Drawing.Image)(resources.GetObject("btn_pantalla2.Image")));
            this.btn_pantalla2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_pantalla2.Location = new System.Drawing.Point(44, 15);
            this.btn_pantalla2.Name = "btn_pantalla2";
            this.btn_pantalla2.Size = new System.Drawing.Size(77, 27);
            this.btn_pantalla2.TabIndex = 37;
            this.btn_pantalla2.Text = "&Ver";
            this.btn_pantalla2.UseVisualStyleBackColor = false;
            this.btn_pantalla2.Click += new System.EventHandler(this.btn_pantalla2_Click);
            // 
            // btn_salir2
            // 
            this.btn_salir2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_salir2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_salir2.Image = ((System.Drawing.Image)(resources.GetObject("btn_salir2.Image")));
            this.btn_salir2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_salir2.Location = new System.Drawing.Point(231, 15);
            this.btn_salir2.Name = "btn_salir2";
            this.btn_salir2.Size = new System.Drawing.Size(75, 26);
            this.btn_salir2.TabIndex = 40;
            this.btn_salir2.Text = "&Salir";
            this.btn_salir2.UseVisualStyleBackColor = true;
            // 
            // rbt_fecha_aprobacion
            // 
            this.rbt_fecha_aprobacion.AutoSize = true;
            this.rbt_fecha_aprobacion.Checked = true;
            this.rbt_fecha_aprobacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbt_fecha_aprobacion.Location = new System.Drawing.Point(80, 50);
            this.rbt_fecha_aprobacion.Name = "rbt_fecha_aprobacion";
            this.rbt_fecha_aprobacion.Size = new System.Drawing.Size(169, 17);
            this.rbt_fecha_aprobacion.TabIndex = 263;
            this.rbt_fecha_aprobacion.TabStop = true;
            this.rbt_fecha_aprobacion.Text = "Por Fecha de Aprobacion";
            this.rbt_fecha_aprobacion.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(188, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 262;
            this.label1.Text = "Hasta";
            // 
            // dtp_hasta
            // 
            this.dtp_hasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_hasta.Location = new System.Drawing.Point(226, 118);
            this.dtp_hasta.Name = "dtp_hasta";
            this.dtp_hasta.Size = new System.Drawing.Size(78, 20);
            this.dtp_hasta.TabIndex = 261;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(42, 121);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 260;
            this.label7.Text = "Desde";
            // 
            // dtp_desde
            // 
            this.dtp_desde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_desde.Location = new System.Drawing.Point(83, 118);
            this.dtp_desde.Name = "dtp_desde";
            this.dtp_desde.Size = new System.Drawing.Size(78, 20);
            this.dtp_desde.TabIndex = 259;
            // 
            // REPORTE_CONTROL_CALIDAD_CONTRATOS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 268);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Name = "REPORTE_CONTROL_CALIDAD_CONTRATOS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte Control de Calidad";
            this.Load += new System.EventHandler(this.REPORTE_CONTROL_CALIDAD_CONTRATOS_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.REPORTE_CONTROL_CALIDAD_CONTRATOS_KeyDown);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.ComboBox cboPrograma;
        internal System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rbt_fecha_contrato;
        private System.Windows.Forms.RadioButton rbt_fecha_reporte;
        internal System.Windows.Forms.GroupBox groupBox3;
        internal System.Windows.Forms.Button btn_impresion2;
        internal System.Windows.Forms.Button btn_pantalla2;
        internal System.Windows.Forms.Button btn_salir2;
        private System.Windows.Forms.RadioButton rbt_fecha_aprobacion;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtp_hasta;
        internal System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtp_desde;
    }
}