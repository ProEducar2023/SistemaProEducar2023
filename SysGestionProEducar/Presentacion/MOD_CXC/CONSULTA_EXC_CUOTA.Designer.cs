namespace Presentacion.MOD_CXC
{
    partial class CONSULTA_EXC_CUOTA
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lbl_importe = new System.Windows.Forms.Label();
            this.lbl_imp = new System.Windows.Forms.Label();
            this.DGW_DEV_EXC_CUOTA = new System.Windows.Forms.DataGridView();
            this.NRO_PLLA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FECHA_PLLA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TIPO_PLA_COBRANZA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IMP_DOC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NRO_DOCUMENTO_PAGO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FECHA_PAGO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DGW_DEV_EXC_CUOTA)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_importe
            // 
            this.lbl_importe.AutoSize = true;
            this.lbl_importe.Location = new System.Drawing.Point(197, 13);
            this.lbl_importe.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_importe.Name = "lbl_importe";
            this.lbl_importe.Size = new System.Drawing.Size(67, 13);
            this.lbl_importe.TabIndex = 245;
            this.lbl_importe.Text = "xxxxxxxxxxxx";
            // 
            // lbl_imp
            // 
            this.lbl_imp.AutoSize = true;
            this.lbl_imp.Location = new System.Drawing.Point(11, 13);
            this.lbl_imp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_imp.Name = "lbl_imp";
            this.lbl_imp.Size = new System.Drawing.Size(86, 13);
            this.lbl_imp.TabIndex = 244;
            this.lbl_imp.Text = "Importe Exceso :";
            // 
            // DGW_DEV_EXC_CUOTA
            // 
            this.DGW_DEV_EXC_CUOTA.AllowUserToAddRows = false;
            this.DGW_DEV_EXC_CUOTA.AllowUserToDeleteRows = false;
            this.DGW_DEV_EXC_CUOTA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGW_DEV_EXC_CUOTA.BackgroundColor = System.Drawing.Color.White;
            this.DGW_DEV_EXC_CUOTA.ColumnHeadersHeight = 47;
            this.DGW_DEV_EXC_CUOTA.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NRO_PLLA,
            this.FECHA_PLLA,
            this.TIPO_PLA_COBRANZA,
            this.IMP_DOC,
            this.NRO_DOCUMENTO_PAGO,
            this.FECHA_PAGO});
            this.DGW_DEV_EXC_CUOTA.Location = new System.Drawing.Point(4, 37);
            this.DGW_DEV_EXC_CUOTA.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.DGW_DEV_EXC_CUOTA.MultiSelect = false;
            this.DGW_DEV_EXC_CUOTA.Name = "DGW_DEV_EXC_CUOTA";
            this.DGW_DEV_EXC_CUOTA.ReadOnly = true;
            this.DGW_DEV_EXC_CUOTA.RowHeadersWidth = 25;
            this.DGW_DEV_EXC_CUOTA.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.DGW_DEV_EXC_CUOTA.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.DGW_DEV_EXC_CUOTA.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGW_DEV_EXC_CUOTA.Size = new System.Drawing.Size(638, 175);
            this.DGW_DEV_EXC_CUOTA.TabIndex = 246;
            this.DGW_DEV_EXC_CUOTA.TabStop = false;
            // 
            // NRO_PLLA
            // 
            this.NRO_PLLA.HeaderText = "Nro Planilla";
            this.NRO_PLLA.Name = "NRO_PLLA";
            this.NRO_PLLA.ReadOnly = true;
            this.NRO_PLLA.Width = 80;
            // 
            // FECHA_PLLA
            // 
            this.FECHA_PLLA.HeaderText = "Fecha Planilla";
            this.FECHA_PLLA.Name = "FECHA_PLLA";
            this.FECHA_PLLA.ReadOnly = true;
            this.FECHA_PLLA.Width = 80;
            // 
            // TIPO_PLA_COBRANZA
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.TIPO_PLA_COBRANZA.DefaultCellStyle = dataGridViewCellStyle1;
            this.TIPO_PLA_COBRANZA.HeaderText = "Tipo";
            this.TIPO_PLA_COBRANZA.Name = "TIPO_PLA_COBRANZA";
            this.TIPO_PLA_COBRANZA.ReadOnly = true;
            this.TIPO_PLA_COBRANZA.Width = 210;
            // 
            // IMP_DOC
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.IMP_DOC.DefaultCellStyle = dataGridViewCellStyle2;
            this.IMP_DOC.HeaderText = "Importe";
            this.IMP_DOC.Name = "IMP_DOC";
            this.IMP_DOC.ReadOnly = true;
            this.IMP_DOC.Width = 60;
            // 
            // NRO_DOCUMENTO_PAGO
            // 
            this.NRO_DOCUMENTO_PAGO.HeaderText = "Nro Recibo";
            this.NRO_DOCUMENTO_PAGO.Name = "NRO_DOCUMENTO_PAGO";
            this.NRO_DOCUMENTO_PAGO.ReadOnly = true;
            this.NRO_DOCUMENTO_PAGO.Width = 80;
            // 
            // FECHA_PAGO
            // 
            this.FECHA_PAGO.HeaderText = "Fecha Recibo";
            this.FECHA_PAGO.Name = "FECHA_PAGO";
            this.FECHA_PAGO.ReadOnly = true;
            this.FECHA_PAGO.Width = 80;
            // 
            // CONSULTA_EXC_CUOTA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 224);
            this.Controls.Add(this.DGW_DEV_EXC_CUOTA);
            this.Controls.Add(this.lbl_importe);
            this.Controls.Add(this.lbl_imp);
            this.Name = "CONSULTA_EXC_CUOTA";
            this.Text = "Consulta Exceso de Cuota ó Descontados en Periodo Suspendido";
            this.Load += new System.EventHandler(this.CONSULTA_EXC_CUOTA_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGW_DEV_EXC_CUOTA)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lbl_importe;
        internal System.Windows.Forms.Label lbl_imp;
        internal System.Windows.Forms.DataGridView DGW_DEV_EXC_CUOTA;
        private System.Windows.Forms.DataGridViewTextBoxColumn NRO_PLLA;
        private System.Windows.Forms.DataGridViewTextBoxColumn FECHA_PLLA;
        private System.Windows.Forms.DataGridViewTextBoxColumn TIPO_PLA_COBRANZA;
        private System.Windows.Forms.DataGridViewTextBoxColumn IMP_DOC;
        private System.Windows.Forms.DataGridViewTextBoxColumn NRO_DOCUMENTO_PAGO;
        private System.Windows.Forms.DataGridViewTextBoxColumn FECHA_PAGO;
    }
}