namespace Presentacion.MOD_CXC
{
    partial class PLANILLA_DIRECTA_LLAMADAS
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PLANILLA_DIRECTA_LLAMADAS));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DGW = new System.Windows.Forms.DataGridView();
            this.GroupBox6 = new System.Windows.Forms.GroupBox();
            this.cbo_sectorista = new System.Windows.Forms.ComboBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.btn_Traer = new System.Windows.Forms.Button();
            this.dtp_vcto = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_fec_llamada = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_Salir = new System.Windows.Forms.Button();
            this.btn_Historial = new System.Windows.Forms.Button();
            this.txt_tot_contratos = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txt_tot_importe = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.COD_SECTORISTA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FECHA_LLAMADA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NRO_CONTRATO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FECHA_CONTRATO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COD_PERSONA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESC_PER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CANT_CUOTA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IMPORTE_CUOTA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COD_LLAMADA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESCRIPCION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VISTO_CONFIRMADO = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.FECHA_NUEVA_LLAMADA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OBSERVACIONES = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DGW)).BeginInit();
            this.GroupBox6.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // DGW
            // 
            this.DGW.AllowUserToAddRows = false;
            this.DGW.AllowUserToDeleteRows = false;
            this.DGW.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGW.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGW.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGW.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.COD_SECTORISTA,
            this.FECHA_LLAMADA,
            this.NRO_CONTRATO,
            this.FECHA_CONTRATO,
            this.COD_PERSONA,
            this.DESC_PER,
            this.CANT_CUOTA,
            this.IMPORTE_CUOTA,
            this.COD_LLAMADA,
            this.DESCRIPCION,
            this.VISTO_CONFIRMADO,
            this.FECHA_NUEVA_LLAMADA,
            this.OBSERVACIONES});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 8.25F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGW.DefaultCellStyle = dataGridViewCellStyle5;
            this.DGW.Location = new System.Drawing.Point(21, 107);
            this.DGW.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.DGW.MultiSelect = false;
            this.DGW.Name = "DGW";
            this.DGW.ReadOnly = true;
            this.DGW.RowHeadersWidth = 25;
            this.DGW.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.DGW.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.DGW.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGW.Size = new System.Drawing.Size(742, 378);
            this.DGW.TabIndex = 2;
            this.DGW.TabStop = false;
            this.DGW.DoubleClick += new System.EventHandler(this.DGW_DoubleClick);
            // 
            // GroupBox6
            // 
            this.GroupBox6.Controls.Add(this.cbo_sectorista);
            this.GroupBox6.Controls.Add(this.Label3);
            this.GroupBox6.Controls.Add(this.btn_Traer);
            this.GroupBox6.Controls.Add(this.dtp_vcto);
            this.GroupBox6.Controls.Add(this.label1);
            this.GroupBox6.Controls.Add(this.lbl_fec_llamada);
            this.GroupBox6.Controls.Add(this.label10);
            this.GroupBox6.Location = new System.Drawing.Point(21, 12);
            this.GroupBox6.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.GroupBox6.Name = "GroupBox6";
            this.GroupBox6.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.GroupBox6.Size = new System.Drawing.Size(521, 75);
            this.GroupBox6.TabIndex = 3;
            this.GroupBox6.TabStop = false;
            // 
            // cbo_sectorista
            // 
            this.cbo_sectorista.BackColor = System.Drawing.Color.White;
            this.cbo_sectorista.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_sectorista.FormattingEnabled = true;
            this.cbo_sectorista.Location = new System.Drawing.Point(98, 46);
            this.cbo_sectorista.Name = "cbo_sectorista";
            this.cbo_sectorista.Size = new System.Drawing.Size(321, 21);
            this.cbo_sectorista.TabIndex = 35;
            this.cbo_sectorista.SelectedIndexChanged += new System.EventHandler(this.cbo_sectorista_SelectedIndexChanged);
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(29, 49);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(54, 13);
            this.Label3.TabIndex = 34;
            this.Label3.Text = "Sectorista";
            // 
            // btn_Traer
            // 
            this.btn_Traer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Traer.Image = ((System.Drawing.Image)(resources.GetObject("btn_Traer.Image")));
            this.btn_Traer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Traer.Location = new System.Drawing.Point(425, 12);
            this.btn_Traer.Name = "btn_Traer";
            this.btn_Traer.Size = new System.Drawing.Size(77, 27);
            this.btn_Traer.TabIndex = 33;
            this.btn_Traer.Text = "&Traer";
            this.btn_Traer.UseVisualStyleBackColor = true;
            this.btn_Traer.Click += new System.EventHandler(this.btn_Traer_Click);
            // 
            // dtp_vcto
            // 
            this.dtp_vcto.CalendarFont = new System.Drawing.Font("Arial", 8.25F);
            this.dtp_vcto.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_vcto.Location = new System.Drawing.Point(339, 17);
            this.dtp_vcto.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dtp_vcto.Name = "dtp_vcto";
            this.dtp_vcto.Size = new System.Drawing.Size(80, 20);
            this.dtp_vcto.TabIndex = 32;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F);
            this.label1.Location = new System.Drawing.Point(236, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 14);
            this.label1.TabIndex = 31;
            this.label1.Text = "Fecha Vencimiento";
            // 
            // lbl_fec_llamada
            // 
            this.lbl_fec_llamada.AutoSize = true;
            this.lbl_fec_llamada.Font = new System.Drawing.Font("Arial", 8.25F);
            this.lbl_fec_llamada.Location = new System.Drawing.Point(102, 21);
            this.lbl_fec_llamada.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_fec_llamada.Name = "lbl_fec_llamada";
            this.lbl_fec_llamada.Size = new System.Drawing.Size(43, 14);
            this.lbl_fec_llamada.TabIndex = 30;
            this.lbl_fec_llamada.Text = "llamada";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 8.25F);
            this.label10.Location = new System.Drawing.Point(17, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 14);
            this.label10.TabIndex = 28;
            this.label10.Text = "Fecha Llamada";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_Salir);
            this.groupBox1.Controls.Add(this.btn_Historial);
            this.groupBox1.Location = new System.Drawing.Point(548, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(215, 74);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // btn_Salir
            // 
            this.btn_Salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Salir.Image = ((System.Drawing.Image)(resources.GetObject("btn_Salir.Image")));
            this.btn_Salir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Salir.Location = new System.Drawing.Point(102, 28);
            this.btn_Salir.Name = "btn_Salir";
            this.btn_Salir.Size = new System.Drawing.Size(77, 27);
            this.btn_Salir.TabIndex = 31;
            this.btn_Salir.Text = "&Salir";
            this.btn_Salir.UseVisualStyleBackColor = true;
            this.btn_Salir.Click += new System.EventHandler(this.btn_Salir_Click);
            // 
            // btn_Historial
            // 
            this.btn_Historial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Historial.Image = ((System.Drawing.Image)(resources.GetObject("btn_Historial.Image")));
            this.btn_Historial.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Historial.Location = new System.Drawing.Point(19, 28);
            this.btn_Historial.Name = "btn_Historial";
            this.btn_Historial.Size = new System.Drawing.Size(77, 27);
            this.btn_Historial.TabIndex = 30;
            this.btn_Historial.Text = "&Historial";
            this.btn_Historial.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Historial.UseVisualStyleBackColor = true;
            this.btn_Historial.Click += new System.EventHandler(this.btn_Historial_Click);
            // 
            // txt_tot_contratos
            // 
            this.txt_tot_contratos.BackColor = System.Drawing.Color.White;
            this.txt_tot_contratos.Location = new System.Drawing.Point(108, 10);
            this.txt_tot_contratos.Name = "txt_tot_contratos";
            this.txt_tot_contratos.ReadOnly = true;
            this.txt_tot_contratos.Size = new System.Drawing.Size(25, 20);
            this.txt_tot_contratos.TabIndex = 33;
            this.txt_tot_contratos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(28, 13);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(79, 13);
            this.Label5.TabIndex = 32;
            this.Label5.Text = "Total Contratos";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txt_tot_importe);
            this.groupBox2.Controls.Add(this.txt_tot_contratos);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.Label5);
            this.groupBox2.Location = new System.Drawing.Point(22, 495);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(741, 36);
            this.groupBox2.TabIndex = 34;
            this.groupBox2.TabStop = false;
            // 
            // txt_tot_importe
            // 
            this.txt_tot_importe.BackColor = System.Drawing.Color.White;
            this.txt_tot_importe.Location = new System.Drawing.Point(389, 10);
            this.txt_tot_importe.Name = "txt_tot_importe";
            this.txt_tot_importe.ReadOnly = true;
            this.txt_tot_importe.Size = new System.Drawing.Size(79, 20);
            this.txt_tot_importe.TabIndex = 36;
            this.txt_tot_importe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(317, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 35;
            this.label2.Text = "Total Importe";
            // 
            // COD_SECTORISTA
            // 
            this.COD_SECTORISTA.HeaderText = "COD_SECTORISTA";
            this.COD_SECTORISTA.Name = "COD_SECTORISTA";
            this.COD_SECTORISTA.ReadOnly = true;
            this.COD_SECTORISTA.Visible = false;
            // 
            // FECHA_LLAMADA
            // 
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.FECHA_LLAMADA.DefaultCellStyle = dataGridViewCellStyle2;
            this.FECHA_LLAMADA.HeaderText = "FECHA_LLAMADA";
            this.FECHA_LLAMADA.Name = "FECHA_LLAMADA";
            this.FECHA_LLAMADA.ReadOnly = true;
            this.FECHA_LLAMADA.Visible = false;
            // 
            // NRO_CONTRATO
            // 
            this.NRO_CONTRATO.HeaderText = "Contrato";
            this.NRO_CONTRATO.Name = "NRO_CONTRATO";
            this.NRO_CONTRATO.ReadOnly = true;
            this.NRO_CONTRATO.Width = 70;
            // 
            // FECHA_CONTRATO
            // 
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.FECHA_CONTRATO.DefaultCellStyle = dataGridViewCellStyle3;
            this.FECHA_CONTRATO.HeaderText = "F Contrato";
            this.FECHA_CONTRATO.Name = "FECHA_CONTRATO";
            this.FECHA_CONTRATO.ReadOnly = true;
            this.FECHA_CONTRATO.Width = 75;
            // 
            // COD_PERSONA
            // 
            this.COD_PERSONA.HeaderText = "COD_PERSONA";
            this.COD_PERSONA.Name = "COD_PERSONA";
            this.COD_PERSONA.ReadOnly = true;
            this.COD_PERSONA.Visible = false;
            // 
            // DESC_PER
            // 
            this.DESC_PER.HeaderText = "Clientes";
            this.DESC_PER.Name = "DESC_PER";
            this.DESC_PER.ReadOnly = true;
            this.DESC_PER.Width = 200;
            // 
            // CANT_CUOTA
            // 
            this.CANT_CUOTA.HeaderText = "Letras";
            this.CANT_CUOTA.Name = "CANT_CUOTA";
            this.CANT_CUOTA.ReadOnly = true;
            this.CANT_CUOTA.Width = 45;
            // 
            // IMPORTE_CUOTA
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.IMPORTE_CUOTA.DefaultCellStyle = dataGridViewCellStyle4;
            this.IMPORTE_CUOTA.HeaderText = "Importe";
            this.IMPORTE_CUOTA.Name = "IMPORTE_CUOTA";
            this.IMPORTE_CUOTA.ReadOnly = true;
            this.IMPORTE_CUOTA.Width = 60;
            // 
            // COD_LLAMADA
            // 
            this.COD_LLAMADA.HeaderText = "COD_LLAMADA";
            this.COD_LLAMADA.Name = "COD_LLAMADA";
            this.COD_LLAMADA.ReadOnly = true;
            this.COD_LLAMADA.Visible = false;
            // 
            // DESCRIPCION
            // 
            this.DESCRIPCION.HeaderText = "Respuesta";
            this.DESCRIPCION.Name = "DESCRIPCION";
            this.DESCRIPCION.ReadOnly = true;
            this.DESCRIPCION.Width = 150;
            // 
            // VISTO_CONFIRMADO
            // 
            this.VISTO_CONFIRMADO.HeaderText = "C";
            this.VISTO_CONFIRMADO.Name = "VISTO_CONFIRMADO";
            this.VISTO_CONFIRMADO.ReadOnly = true;
            this.VISTO_CONFIRMADO.Width = 20;
            // 
            // FECHA_NUEVA_LLAMADA
            // 
            this.FECHA_NUEVA_LLAMADA.HeaderText = "Llamar";
            this.FECHA_NUEVA_LLAMADA.Name = "FECHA_NUEVA_LLAMADA";
            this.FECHA_NUEVA_LLAMADA.ReadOnly = true;
            this.FECHA_NUEVA_LLAMADA.Width = 75;
            // 
            // OBSERVACIONES
            // 
            this.OBSERVACIONES.HeaderText = "OBSERVACIONES";
            this.OBSERVACIONES.Name = "OBSERVACIONES";
            this.OBSERVACIONES.ReadOnly = true;
            this.OBSERVACIONES.Visible = false;
            // 
            // PLANILLA_DIRECTA_LLAMADAS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 540);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.GroupBox6);
            this.Controls.Add(this.DGW);
            this.Name = "PLANILLA_DIRECTA_LLAMADAS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LLAMADAS";
            this.Load += new System.EventHandler(this.PLANILLA_DIRECTA_LLAMADAS_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PLANILLA_DIRECTA_LLAMADAS_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.DGW)).EndInit();
            this.GroupBox6.ResumeLayout(false);
            this.GroupBox6.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.DataGridView DGW;
        internal System.Windows.Forms.GroupBox GroupBox6;
        internal System.Windows.Forms.Label label10;
        internal System.Windows.Forms.Label lbl_fec_llamada;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.Button btn_Salir;
        internal System.Windows.Forms.Button btn_Historial;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Button btn_Traer;
        internal System.Windows.Forms.DateTimePicker dtp_vcto;
        internal System.Windows.Forms.TextBox txt_tot_contratos;
        internal System.Windows.Forms.Label Label5;
        private System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.TextBox txt_tot_importe;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.ComboBox cbo_sectorista;
        internal System.Windows.Forms.Label Label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn COD_SECTORISTA;
        private System.Windows.Forms.DataGridViewTextBoxColumn FECHA_LLAMADA;
        private System.Windows.Forms.DataGridViewTextBoxColumn NRO_CONTRATO;
        private System.Windows.Forms.DataGridViewTextBoxColumn FECHA_CONTRATO;
        private System.Windows.Forms.DataGridViewTextBoxColumn COD_PERSONA;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESC_PER;
        private System.Windows.Forms.DataGridViewTextBoxColumn CANT_CUOTA;
        private System.Windows.Forms.DataGridViewTextBoxColumn IMPORTE_CUOTA;
        private System.Windows.Forms.DataGridViewTextBoxColumn COD_LLAMADA;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESCRIPCION;
        private System.Windows.Forms.DataGridViewCheckBoxColumn VISTO_CONFIRMADO;
        private System.Windows.Forms.DataGridViewTextBoxColumn FECHA_NUEVA_LLAMADA;
        private System.Windows.Forms.DataGridViewTextBoxColumn OBSERVACIONES;
    }
}