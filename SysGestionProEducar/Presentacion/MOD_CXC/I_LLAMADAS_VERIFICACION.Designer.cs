namespace Presentacion.MOD_CXC
{
    partial class I_LLAMADAS_VERIFICACION
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(I_LLAMADAS_VERIFICACION));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_datos_cliente = new System.Windows.Forms.LinkLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_Salir = new System.Windows.Forms.Button();
            this.GroupBox6 = new System.Windows.Forms.GroupBox();
            this.txt_mes_mor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_fec_llamada = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dgw_llamadas = new System.Windows.Forms.DataGridView();
            this.NRO_CONTRATO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COD_PERSONA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CLIENTE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DNI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COD_GESTOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GESTOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OBSERVACIONES = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IMPORTE_PAGO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FECHA_DEPOSITO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NRO_OPERACION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INSTITUCION_BANCARIA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BANCO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txt_observaciones = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_gestor = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.GroupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw_llamadas)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Italic);
            this.label2.Location = new System.Drawing.Point(670, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 14);
            this.label2.TabIndex = 140;
            this.label2.Text = "Doble click en el grid";
            // 
            // lbl_datos_cliente
            // 
            this.lbl_datos_cliente.AutoSize = true;
            this.lbl_datos_cliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_datos_cliente.Location = new System.Drawing.Point(557, 32);
            this.lbl_datos_cliente.Name = "lbl_datos_cliente";
            this.lbl_datos_cliente.Size = new System.Drawing.Size(111, 13);
            this.lbl_datos_cliente.TabIndex = 139;
            this.lbl_datos_cliente.TabStop = true;
            this.lbl_datos_cliente.Text = "Ver Datos del Clientes";
            this.lbl_datos_cliente.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbl_datos_cliente_LinkClicked);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_Salir);
            this.groupBox1.Location = new System.Drawing.Point(673, 552);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(122, 48);
            this.groupBox1.TabIndex = 138;
            this.groupBox1.TabStop = false;
            // 
            // btn_Salir
            // 
            this.btn_Salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Salir.Image = ((System.Drawing.Image)(resources.GetObject("btn_Salir.Image")));
            this.btn_Salir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Salir.Location = new System.Drawing.Point(23, 13);
            this.btn_Salir.Name = "btn_Salir";
            this.btn_Salir.Size = new System.Drawing.Size(77, 27);
            this.btn_Salir.TabIndex = 31;
            this.btn_Salir.Text = "&Salir";
            this.btn_Salir.UseVisualStyleBackColor = true;
            this.btn_Salir.Click += new System.EventHandler(this.btn_Salir_Click);
            // 
            // GroupBox6
            // 
            this.GroupBox6.Controls.Add(this.txt_mes_mor);
            this.GroupBox6.Controls.Add(this.label1);
            this.GroupBox6.Controls.Add(this.lbl_fec_llamada);
            this.GroupBox6.Controls.Add(this.label10);
            this.GroupBox6.Location = new System.Drawing.Point(21, 8);
            this.GroupBox6.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.GroupBox6.Name = "GroupBox6";
            this.GroupBox6.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.GroupBox6.Size = new System.Drawing.Size(521, 41);
            this.GroupBox6.TabIndex = 137;
            this.GroupBox6.TabStop = false;
            // 
            // txt_mes_mor
            // 
            this.txt_mes_mor.BackColor = System.Drawing.Color.White;
            this.txt_mes_mor.Location = new System.Drawing.Point(467, 11);
            this.txt_mes_mor.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_mes_mor.Name = "txt_mes_mor";
            this.txt_mes_mor.ReadOnly = true;
            this.txt_mes_mor.Size = new System.Drawing.Size(19, 20);
            this.txt_mes_mor.TabIndex = 133;
            this.txt_mes_mor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_mes_mor.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(353, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 14);
            this.label1.TabIndex = 132;
            this.label1.Text = "Meses de Morosidad : ";
            this.label1.Visible = false;
            // 
            // lbl_fec_llamada
            // 
            this.lbl_fec_llamada.AutoSize = true;
            this.lbl_fec_llamada.Font = new System.Drawing.Font("Arial", 8.25F);
            this.lbl_fec_llamada.Location = new System.Drawing.Point(100, 13);
            this.lbl_fec_llamada.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_fec_llamada.Name = "lbl_fec_llamada";
            this.lbl_fec_llamada.Size = new System.Drawing.Size(55, 14);
            this.lbl_fec_llamada.TabIndex = 30;
            this.lbl_fec_llamada.Text = "fec activa";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 8.25F);
            this.label10.Location = new System.Drawing.Point(17, 13);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 14);
            this.label10.TabIndex = 28;
            this.label10.Text = "Fecha Activa";
            // 
            // dgw_llamadas
            // 
            this.dgw_llamadas.AllowUserToAddRows = false;
            this.dgw_llamadas.AllowUserToDeleteRows = false;
            this.dgw_llamadas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgw_llamadas.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 8.25F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgw_llamadas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgw_llamadas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NRO_CONTRATO,
            this.COD_PERSONA,
            this.CLIENTE,
            this.DNI,
            this.COD_GESTOR,
            this.GESTOR,
            this.OBSERVACIONES,
            this.IMPORTE_PAGO,
            this.FECHA_DEPOSITO,
            this.NRO_OPERACION,
            this.INSTITUCION_BANCARIA,
            this.BANCO});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Arial", 8.25F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgw_llamadas.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgw_llamadas.Location = new System.Drawing.Point(21, 55);
            this.dgw_llamadas.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dgw_llamadas.MultiSelect = false;
            this.dgw_llamadas.Name = "dgw_llamadas";
            this.dgw_llamadas.ReadOnly = true;
            this.dgw_llamadas.RowHeadersWidth = 25;
            this.dgw_llamadas.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dgw_llamadas.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.dgw_llamadas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgw_llamadas.Size = new System.Drawing.Size(774, 440);
            this.dgw_llamadas.TabIndex = 136;
            this.dgw_llamadas.TabStop = false;
            this.dgw_llamadas.SelectionChanged += new System.EventHandler(this.dgw_llamadas_SelectionChanged);
            this.dgw_llamadas.Click += new System.EventHandler(this.dgw_llamadas_Click);
            this.dgw_llamadas.DoubleClick += new System.EventHandler(this.dgw_llamadas_DoubleClick);
            // 
            // NRO_CONTRATO
            // 
            this.NRO_CONTRATO.HeaderText = "Contrato";
            this.NRO_CONTRATO.Name = "NRO_CONTRATO";
            this.NRO_CONTRATO.ReadOnly = true;
            this.NRO_CONTRATO.Width = 70;
            // 
            // COD_PERSONA
            // 
            this.COD_PERSONA.HeaderText = "COD_PERSONA";
            this.COD_PERSONA.Name = "COD_PERSONA";
            this.COD_PERSONA.ReadOnly = true;
            this.COD_PERSONA.Visible = false;
            // 
            // CLIENTE
            // 
            this.CLIENTE.HeaderText = "Cliente";
            this.CLIENTE.Name = "CLIENTE";
            this.CLIENTE.ReadOnly = true;
            this.CLIENTE.Width = 240;
            // 
            // DNI
            // 
            this.DNI.HeaderText = "Dni";
            this.DNI.Name = "DNI";
            this.DNI.ReadOnly = true;
            this.DNI.Width = 70;
            // 
            // COD_GESTOR
            // 
            this.COD_GESTOR.HeaderText = "COD_GESTOR";
            this.COD_GESTOR.Name = "COD_GESTOR";
            this.COD_GESTOR.ReadOnly = true;
            this.COD_GESTOR.Visible = false;
            // 
            // GESTOR
            // 
            this.GESTOR.HeaderText = "Gestor";
            this.GESTOR.Name = "GESTOR";
            this.GESTOR.ReadOnly = true;
            this.GESTOR.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.GESTOR.Visible = false;
            this.GESTOR.Width = 200;
            // 
            // OBSERVACIONES
            // 
            this.OBSERVACIONES.HeaderText = "OBSERVACIONES";
            this.OBSERVACIONES.Name = "OBSERVACIONES";
            this.OBSERVACIONES.ReadOnly = true;
            this.OBSERVACIONES.Visible = false;
            // 
            // IMPORTE_PAGO
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.IMPORTE_PAGO.DefaultCellStyle = dataGridViewCellStyle5;
            this.IMPORTE_PAGO.HeaderText = "Importe";
            this.IMPORTE_PAGO.Name = "IMPORTE_PAGO";
            this.IMPORTE_PAGO.ReadOnly = true;
            this.IMPORTE_PAGO.Width = 50;
            // 
            // FECHA_DEPOSITO
            // 
            this.FECHA_DEPOSITO.HeaderText = "Fe Deposito";
            this.FECHA_DEPOSITO.Name = "FECHA_DEPOSITO";
            this.FECHA_DEPOSITO.ReadOnly = true;
            this.FECHA_DEPOSITO.Width = 70;
            // 
            // NRO_OPERACION
            // 
            this.NRO_OPERACION.HeaderText = "Nro Operacion";
            this.NRO_OPERACION.Name = "NRO_OPERACION";
            this.NRO_OPERACION.ReadOnly = true;
            this.NRO_OPERACION.Width = 90;
            // 
            // INSTITUCION_BANCARIA
            // 
            this.INSTITUCION_BANCARIA.HeaderText = "INSTITUCION_BANCARIA";
            this.INSTITUCION_BANCARIA.Name = "INSTITUCION_BANCARIA";
            this.INSTITUCION_BANCARIA.ReadOnly = true;
            this.INSTITUCION_BANCARIA.Visible = false;
            // 
            // BANCO
            // 
            this.BANCO.HeaderText = "Banco";
            this.BANCO.Name = "BANCO";
            this.BANCO.ReadOnly = true;
            this.BANCO.Width = 130;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txt_observaciones);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txt_gestor);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(21, 501);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(646, 101);
            this.groupBox2.TabIndex = 141;
            this.groupBox2.TabStop = false;
            // 
            // txt_observaciones
            // 
            this.txt_observaciones.BackColor = System.Drawing.Color.White;
            this.txt_observaciones.Location = new System.Drawing.Point(132, 39);
            this.txt_observaciones.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_observaciones.Multiline = true;
            this.txt_observaciones.Name = "txt_observaciones";
            this.txt_observaciones.ReadOnly = true;
            this.txt_observaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_observaciones.Size = new System.Drawing.Size(461, 56);
            this.txt_observaciones.TabIndex = 137;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(47, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 14);
            this.label4.TabIndex = 136;
            this.label4.Text = "Observaciones";
            // 
            // txt_gestor
            // 
            this.txt_gestor.BackColor = System.Drawing.Color.White;
            this.txt_gestor.Location = new System.Drawing.Point(132, 13);
            this.txt_gestor.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_gestor.Name = "txt_gestor";
            this.txt_gestor.ReadOnly = true;
            this.txt_gestor.Size = new System.Drawing.Size(389, 20);
            this.txt_gestor.TabIndex = 135;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(47, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 14);
            this.label3.TabIndex = 134;
            this.label3.Text = "Gestor ";
            // 
            // I_LLAMADAS_VERIFICACION
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 611);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_datos_cliente);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.GroupBox6);
            this.Controls.Add(this.dgw_llamadas);
            this.Name = "I_LLAMADAS_VERIFICACION";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Verificar Llamadas";
            this.Load += new System.EventHandler(this.I_LLAMADAS_VERIFICACION_Load);
            this.groupBox1.ResumeLayout(false);
            this.GroupBox6.ResumeLayout(false);
            this.GroupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw_llamadas)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel lbl_datos_cliente;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.Button btn_Salir;
        internal System.Windows.Forms.GroupBox GroupBox6;
        internal System.Windows.Forms.TextBox txt_mes_mor;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label lbl_fec_llamada;
        internal System.Windows.Forms.Label label10;
        internal System.Windows.Forms.DataGridView dgw_llamadas;
        private System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.TextBox txt_observaciones;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.TextBox txt_gestor;
        internal System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn NRO_CONTRATO;
        private System.Windows.Forms.DataGridViewTextBoxColumn COD_PERSONA;
        private System.Windows.Forms.DataGridViewTextBoxColumn CLIENTE;
        private System.Windows.Forms.DataGridViewTextBoxColumn DNI;
        private System.Windows.Forms.DataGridViewTextBoxColumn COD_GESTOR;
        private System.Windows.Forms.DataGridViewTextBoxColumn GESTOR;
        private System.Windows.Forms.DataGridViewTextBoxColumn OBSERVACIONES;
        private System.Windows.Forms.DataGridViewTextBoxColumn IMPORTE_PAGO;
        private System.Windows.Forms.DataGridViewTextBoxColumn FECHA_DEPOSITO;
        private System.Windows.Forms.DataGridViewTextBoxColumn NRO_OPERACION;
        private System.Windows.Forms.DataGridViewTextBoxColumn INSTITUCION_BANCARIA;
        private System.Windows.Forms.DataGridViewTextBoxColumn BANCO;
    }
}