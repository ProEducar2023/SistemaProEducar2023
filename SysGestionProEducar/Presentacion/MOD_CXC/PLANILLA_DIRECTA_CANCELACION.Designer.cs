namespace Presentacion.MOD_CXC
{
    partial class PLANILLA_DIRECTA_CANCELACION
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PLANILLA_DIRECTA_CANCELACION));
            this.DGW = new System.Windows.Forms.DataGridView();
            this.NRO_CONTRATO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESC_PER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COD_PERSONA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NRO_DOC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FECHA_CONFIRMADA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IMPORTE_PAGO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COD_LLAMADA = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.FECHA_NUEVA_LLAMADA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IMPORTE_DEPOSITADO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NRO_OPERACION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FECHA_OPERACION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COD_BANCO = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.OBSERVACIONES = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NRO_CUOTA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_tot_importe_dptdo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Historial = new System.Windows.Forms.Button();
            this.txt_tot_importe = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_cierre = new System.Windows.Forms.Button();
            this.btn_aceptar = new System.Windows.Forms.Button();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.lbl_fec_llamada_conf = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGW)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DGW
            // 
            this.DGW.AllowUserToAddRows = false;
            this.DGW.AllowUserToDeleteRows = false;
            this.DGW.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
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
            this.NRO_CONTRATO,
            this.DESC_PER,
            this.COD_PERSONA,
            this.NRO_DOC,
            this.FECHA_CONFIRMADA,
            this.IMPORTE_PAGO,
            this.COD_LLAMADA,
            this.FECHA_NUEVA_LLAMADA,
            this.IMPORTE_DEPOSITADO,
            this.NRO_OPERACION,
            this.FECHA_OPERACION,
            this.COD_BANCO,
            this.OBSERVACIONES,
            this.NRO_CUOTA});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Arial", 8.25F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGW.DefaultCellStyle = dataGridViewCellStyle6;
            this.DGW.Location = new System.Drawing.Point(11, 44);
            this.DGW.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.DGW.MultiSelect = false;
            this.DGW.Name = "DGW";
            this.DGW.RowHeadersWidth = 25;
            this.DGW.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.DGW.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.DGW.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGW.Size = new System.Drawing.Size(1056, 400);
            this.DGW.TabIndex = 32;
            this.DGW.TabStop = false;
            this.DGW.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGW_CellClick);
            this.DGW.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.DGW_ColumnWidthChanged);
            this.DGW.Scroll += new System.Windows.Forms.ScrollEventHandler(this.DGW_Scroll);
            // 
            // NRO_CONTRATO
            // 
            this.NRO_CONTRATO.HeaderText = "Contrato";
            this.NRO_CONTRATO.Name = "NRO_CONTRATO";
            this.NRO_CONTRATO.ReadOnly = true;
            this.NRO_CONTRATO.Width = 60;
            // 
            // DESC_PER
            // 
            this.DESC_PER.HeaderText = "Cliente";
            this.DESC_PER.Name = "DESC_PER";
            this.DESC_PER.ReadOnly = true;
            this.DESC_PER.Width = 195;
            // 
            // COD_PERSONA
            // 
            this.COD_PERSONA.HeaderText = "COD_PERSONA";
            this.COD_PERSONA.Name = "COD_PERSONA";
            this.COD_PERSONA.Visible = false;
            // 
            // NRO_DOC
            // 
            this.NRO_DOC.HeaderText = "Doc";
            this.NRO_DOC.Name = "NRO_DOC";
            this.NRO_DOC.ReadOnly = true;
            this.NRO_DOC.Width = 70;
            // 
            // FECHA_CONFIRMADA
            // 
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.FECHA_CONFIRMADA.DefaultCellStyle = dataGridViewCellStyle2;
            this.FECHA_CONFIRMADA.HeaderText = "F Conf";
            this.FECHA_CONFIRMADA.Name = "FECHA_CONFIRMADA";
            this.FECHA_CONFIRMADA.ReadOnly = true;
            this.FECHA_CONFIRMADA.Visible = false;
            this.FECHA_CONFIRMADA.Width = 75;
            // 
            // IMPORTE_PAGO
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.IMPORTE_PAGO.DefaultCellStyle = dataGridViewCellStyle3;
            this.IMPORTE_PAGO.HeaderText = "Importe";
            this.IMPORTE_PAGO.Name = "IMPORTE_PAGO";
            this.IMPORTE_PAGO.ReadOnly = true;
            this.IMPORTE_PAGO.Width = 70;
            // 
            // COD_LLAMADA
            // 
            this.COD_LLAMADA.HeaderText = "Respueta";
            this.COD_LLAMADA.Name = "COD_LLAMADA";
            this.COD_LLAMADA.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.COD_LLAMADA.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.COD_LLAMADA.Width = 150;
            // 
            // FECHA_NUEVA_LLAMADA
            // 
            this.FECHA_NUEVA_LLAMADA.HeaderText = "F Llamada";
            this.FECHA_NUEVA_LLAMADA.Name = "FECHA_NUEVA_LLAMADA";
            this.FECHA_NUEVA_LLAMADA.Width = 80;
            // 
            // IMPORTE_DEPOSITADO
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.IMPORTE_DEPOSITADO.DefaultCellStyle = dataGridViewCellStyle4;
            this.IMPORTE_DEPOSITADO.HeaderText = "Imp Deptdo";
            this.IMPORTE_DEPOSITADO.Name = "IMPORTE_DEPOSITADO";
            this.IMPORTE_DEPOSITADO.Width = 70;
            // 
            // NRO_OPERACION
            // 
            this.NRO_OPERACION.HeaderText = "Operacion";
            this.NRO_OPERACION.Name = "NRO_OPERACION";
            this.NRO_OPERACION.Width = 70;
            // 
            // FECHA_OPERACION
            // 
            dataGridViewCellStyle5.NullValue = null;
            this.FECHA_OPERACION.DefaultCellStyle = dataGridViewCellStyle5;
            this.FECHA_OPERACION.HeaderText = "F Operacion";
            this.FECHA_OPERACION.Name = "FECHA_OPERACION";
            this.FECHA_OPERACION.Width = 80;
            // 
            // COD_BANCO
            // 
            this.COD_BANCO.HeaderText = "Banco";
            this.COD_BANCO.Name = "COD_BANCO";
            this.COD_BANCO.Width = 160;
            // 
            // OBSERVACIONES
            // 
            this.OBSERVACIONES.HeaderText = "OBSERVACIONES";
            this.OBSERVACIONES.Name = "OBSERVACIONES";
            this.OBSERVACIONES.Visible = false;
            // 
            // NRO_CUOTA
            // 
            this.NRO_CUOTA.HeaderText = "NRO_CUOTA";
            this.NRO_CUOTA.Name = "NRO_CUOTA";
            this.NRO_CUOTA.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txt_tot_importe_dptdo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btn_Historial);
            this.groupBox1.Controls.Add(this.txt_tot_importe);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btn_cierre);
            this.groupBox1.Controls.Add(this.btn_aceptar);
            this.groupBox1.Controls.Add(this.btn_cancelar);
            this.groupBox1.Location = new System.Drawing.Point(13, 450);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1054, 59);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            // 
            // txt_tot_importe_dptdo
            // 
            this.txt_tot_importe_dptdo.BackColor = System.Drawing.Color.White;
            this.txt_tot_importe_dptdo.Location = new System.Drawing.Point(623, 19);
            this.txt_tot_importe_dptdo.Name = "txt_tot_importe_dptdo";
            this.txt_tot_importe_dptdo.ReadOnly = true;
            this.txt_tot_importe_dptdo.Size = new System.Drawing.Size(87, 20);
            this.txt_tot_importe_dptdo.TabIndex = 43;
            this.txt_tot_importe_dptdo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F);
            this.label1.Location = new System.Drawing.Point(516, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 14);
            this.label1.TabIndex = 42;
            this.label1.Text = "Total Importe Deptdo";
            // 
            // btn_Historial
            // 
            this.btn_Historial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Historial.Image = ((System.Drawing.Image)(resources.GetObject("btn_Historial.Image")));
            this.btn_Historial.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Historial.Location = new System.Drawing.Point(37, 19);
            this.btn_Historial.Name = "btn_Historial";
            this.btn_Historial.Size = new System.Drawing.Size(77, 27);
            this.btn_Historial.TabIndex = 41;
            this.btn_Historial.Text = "&Historial";
            this.btn_Historial.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Historial.UseVisualStyleBackColor = true;
            this.btn_Historial.Click += new System.EventHandler(this.btn_Historial_Click);
            // 
            // txt_tot_importe
            // 
            this.txt_tot_importe.BackColor = System.Drawing.Color.White;
            this.txt_tot_importe.Location = new System.Drawing.Point(326, 19);
            this.txt_tot_importe.Name = "txt_tot_importe";
            this.txt_tot_importe.ReadOnly = true;
            this.txt_tot_importe.Size = new System.Drawing.Size(87, 20);
            this.txt_tot_importe.TabIndex = 40;
            this.txt_tot_importe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F);
            this.label2.Location = new System.Drawing.Point(256, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 14);
            this.label2.TabIndex = 39;
            this.label2.Text = "Total Importe";
            // 
            // btn_cierre
            // 
            this.btn_cierre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cierre.Image = ((System.Drawing.Image)(resources.GetObject("btn_cierre.Image")));
            this.btn_cierre.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_cierre.Location = new System.Drawing.Point(788, 19);
            this.btn_cierre.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_cierre.Name = "btn_cierre";
            this.btn_cierre.Size = new System.Drawing.Size(77, 27);
            this.btn_cierre.TabIndex = 36;
            this.btn_cierre.Text = "&Cierre";
            this.btn_cierre.UseVisualStyleBackColor = true;
            this.btn_cierre.Visible = false;
            this.btn_cierre.Click += new System.EventHandler(this.btn_cierre_Click);
            // 
            // btn_aceptar
            // 
            this.btn_aceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_aceptar.Image = ((System.Drawing.Image)(resources.GetObject("btn_aceptar.Image")));
            this.btn_aceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_aceptar.Location = new System.Drawing.Point(869, 19);
            this.btn_aceptar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_aceptar.Name = "btn_aceptar";
            this.btn_aceptar.Size = new System.Drawing.Size(77, 27);
            this.btn_aceptar.TabIndex = 34;
            this.btn_aceptar.Text = "&Confirmar";
            this.btn_aceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_aceptar.UseVisualStyleBackColor = true;
            this.btn_aceptar.Click += new System.EventHandler(this.btn_aceptar_Click);
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancelar.Image = ((System.Drawing.Image)(resources.GetObject("btn_cancelar.Image")));
            this.btn_cancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_cancelar.Location = new System.Drawing.Point(950, 19);
            this.btn_cancelar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(77, 27);
            this.btn_cancelar.TabIndex = 35;
            this.btn_cancelar.Text = "&Cancelar";
            this.btn_cancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_cancelar.UseVisualStyleBackColor = true;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // lbl_fec_llamada_conf
            // 
            this.lbl_fec_llamada_conf.AutoSize = true;
            this.lbl_fec_llamada_conf.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Bold);
            this.lbl_fec_llamada_conf.Location = new System.Drawing.Point(290, 15);
            this.lbl_fec_llamada_conf.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_fec_llamada_conf.Name = "lbl_fec_llamada_conf";
            this.lbl_fec_llamada_conf.Size = new System.Drawing.Size(52, 15);
            this.lbl_fec_llamada_conf.TabIndex = 35;
            this.lbl_fec_llamada_conf.Text = "llamada";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(102, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(186, 15);
            this.label10.TabIndex = 34;
            this.label10.Text = "Fecha de Confirmacion de Pago";
            // 
            // PLANILLA_DIRECTA_CANCELACION
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 540);
            this.Controls.Add(this.lbl_fec_llamada_conf);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.DGW);
            this.Name = "PLANILLA_DIRECTA_CANCELACION";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CONFIRMACION DE PAGO";
            this.Load += new System.EventHandler(this.PLANILLA_DIRECTA_CANCELACION_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PLANILLA_DIRECTA_CANCELACION_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.DGW)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.DataGridView DGW;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.Button btn_aceptar;
        internal System.Windows.Forms.Button btn_cancelar;
        internal System.Windows.Forms.Button btn_cierre;
        internal System.Windows.Forms.TextBox txt_tot_importe;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Button btn_Historial;
        internal System.Windows.Forms.Label lbl_fec_llamada_conf;
        internal System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridViewTextBoxColumn NRO_CONTRATO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESC_PER;
        private System.Windows.Forms.DataGridViewTextBoxColumn COD_PERSONA;
        private System.Windows.Forms.DataGridViewTextBoxColumn NRO_DOC;
        private System.Windows.Forms.DataGridViewTextBoxColumn FECHA_CONFIRMADA;
        private System.Windows.Forms.DataGridViewTextBoxColumn IMPORTE_PAGO;
        private System.Windows.Forms.DataGridViewComboBoxColumn COD_LLAMADA;
        private System.Windows.Forms.DataGridViewTextBoxColumn FECHA_NUEVA_LLAMADA;
        private System.Windows.Forms.DataGridViewTextBoxColumn IMPORTE_DEPOSITADO;
        private System.Windows.Forms.DataGridViewTextBoxColumn NRO_OPERACION;
        private System.Windows.Forms.DataGridViewTextBoxColumn FECHA_OPERACION;
        private System.Windows.Forms.DataGridViewComboBoxColumn COD_BANCO;
        private System.Windows.Forms.DataGridViewTextBoxColumn OBSERVACIONES;
        private System.Windows.Forms.DataGridViewTextBoxColumn NRO_CUOTA;
        internal System.Windows.Forms.TextBox txt_tot_importe_dptdo;
        internal System.Windows.Forms.Label label1;

    }
}