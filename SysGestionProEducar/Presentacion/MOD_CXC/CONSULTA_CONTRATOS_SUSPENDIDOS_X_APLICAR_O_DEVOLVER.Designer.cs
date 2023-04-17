namespace Presentacion.MOD_CXC
{
    partial class CONSULTA_CONTRATOS_SUSPENDIDOS_X_APLICAR_O_DEVOLVER
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DGW_DEV_EXC_CUOTA = new System.Windows.Forms.DataGridView();
            this.NRO_PLANILLA_COB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FECHA_DOC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IMP_INI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGW_DEV_EXC_CUOTA_DETALLE = new System.Windows.Forms.DataGridView();
            this.NRO_PLANILLA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FECHA_PLANILLA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESC_TIPO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IMP_DOC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NRO_DOCUMENTO_PAGO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FECHA_PAGO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DGW_DEV_EXC_CUOTA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGW_DEV_EXC_CUOTA_DETALLE)).BeginInit();
            this.SuspendLayout();
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
            this.NRO_PLANILLA_COB,
            this.FECHA_DOC,
            this.IMP_INI});
            this.DGW_DEV_EXC_CUOTA.Location = new System.Drawing.Point(5, 9);
            this.DGW_DEV_EXC_CUOTA.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.DGW_DEV_EXC_CUOTA.MultiSelect = false;
            this.DGW_DEV_EXC_CUOTA.Name = "DGW_DEV_EXC_CUOTA";
            this.DGW_DEV_EXC_CUOTA.ReadOnly = true;
            this.DGW_DEV_EXC_CUOTA.RowHeadersWidth = 25;
            this.DGW_DEV_EXC_CUOTA.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.DGW_DEV_EXC_CUOTA.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.DGW_DEV_EXC_CUOTA.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGW_DEV_EXC_CUOTA.Size = new System.Drawing.Size(638, 101);
            this.DGW_DEV_EXC_CUOTA.TabIndex = 250;
            this.DGW_DEV_EXC_CUOTA.TabStop = false;
            this.DGW_DEV_EXC_CUOTA.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGW_DEV_EXC_CUOTA_CellContentClick);
            this.DGW_DEV_EXC_CUOTA.SelectionChanged += new System.EventHandler(this.DGW_DEV_EXC_CUOTA_SelectionChanged);
            this.DGW_DEV_EXC_CUOTA.Click += new System.EventHandler(this.DGW_DEV_EXC_CUOTA_Click);
            // 
            // NRO_PLANILLA_COB
            // 
            this.NRO_PLANILLA_COB.HeaderText = "Nro Planilla Descuento";
            this.NRO_PLANILLA_COB.Name = "NRO_PLANILLA_COB";
            this.NRO_PLANILLA_COB.ReadOnly = true;
            this.NRO_PLANILLA_COB.Width = 80;
            // 
            // FECHA_DOC
            // 
            this.FECHA_DOC.HeaderText = "Fecha Planilla";
            this.FECHA_DOC.Name = "FECHA_DOC";
            this.FECHA_DOC.ReadOnly = true;
            this.FECHA_DOC.Width = 80;
            // 
            // IMP_INI
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.IMP_INI.DefaultCellStyle = dataGridViewCellStyle1;
            this.IMP_INI.HeaderText = "Importe";
            this.IMP_INI.Name = "IMP_INI";
            this.IMP_INI.ReadOnly = true;
            this.IMP_INI.Width = 60;
            // 
            // DGW_DEV_EXC_CUOTA_DETALLE
            // 
            this.DGW_DEV_EXC_CUOTA_DETALLE.AllowUserToAddRows = false;
            this.DGW_DEV_EXC_CUOTA_DETALLE.AllowUserToDeleteRows = false;
            this.DGW_DEV_EXC_CUOTA_DETALLE.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGW_DEV_EXC_CUOTA_DETALLE.BackgroundColor = System.Drawing.Color.White;
            this.DGW_DEV_EXC_CUOTA_DETALLE.ColumnHeadersHeight = 47;
            this.DGW_DEV_EXC_CUOTA_DETALLE.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NRO_PLANILLA,
            this.FECHA_PLANILLA,
            this.DESC_TIPO,
            this.IMP_DOC,
            this.NRO_DOCUMENTO_PAGO,
            this.FECHA_PAGO});
            this.DGW_DEV_EXC_CUOTA_DETALLE.Location = new System.Drawing.Point(5, 115);
            this.DGW_DEV_EXC_CUOTA_DETALLE.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.DGW_DEV_EXC_CUOTA_DETALLE.MultiSelect = false;
            this.DGW_DEV_EXC_CUOTA_DETALLE.Name = "DGW_DEV_EXC_CUOTA_DETALLE";
            this.DGW_DEV_EXC_CUOTA_DETALLE.ReadOnly = true;
            this.DGW_DEV_EXC_CUOTA_DETALLE.RowHeadersWidth = 25;
            this.DGW_DEV_EXC_CUOTA_DETALLE.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.DGW_DEV_EXC_CUOTA_DETALLE.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.DGW_DEV_EXC_CUOTA_DETALLE.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGW_DEV_EXC_CUOTA_DETALLE.Size = new System.Drawing.Size(638, 101);
            this.DGW_DEV_EXC_CUOTA_DETALLE.TabIndex = 249;
            this.DGW_DEV_EXC_CUOTA_DETALLE.TabStop = false;
            // 
            // NRO_PLANILLA
            // 
            this.NRO_PLANILLA.HeaderText = "Nro Planilla";
            this.NRO_PLANILLA.Name = "NRO_PLANILLA";
            this.NRO_PLANILLA.ReadOnly = true;
            this.NRO_PLANILLA.Width = 80;
            // 
            // FECHA_PLANILLA
            // 
            this.FECHA_PLANILLA.HeaderText = "Fecha Planilla";
            this.FECHA_PLANILLA.Name = "FECHA_PLANILLA";
            this.FECHA_PLANILLA.ReadOnly = true;
            this.FECHA_PLANILLA.Width = 80;
            // 
            // DESC_TIPO
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.DESC_TIPO.DefaultCellStyle = dataGridViewCellStyle2;
            this.DESC_TIPO.HeaderText = "Tipo";
            this.DESC_TIPO.Name = "DESC_TIPO";
            this.DESC_TIPO.ReadOnly = true;
            this.DESC_TIPO.Width = 210;
            // 
            // IMP_DOC
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.IMP_DOC.DefaultCellStyle = dataGridViewCellStyle3;
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
            // CONSULTA_CONTRATOS_SUSPENDIDOS_X_APLICAR_O_DEVOLVER
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 224);
            this.Controls.Add(this.DGW_DEV_EXC_CUOTA);
            this.Controls.Add(this.DGW_DEV_EXC_CUOTA_DETALLE);
            this.Name = "CONSULTA_CONTRATOS_SUSPENDIDOS_X_APLICAR_O_DEVOLVER";
            this.Text = "Contratos Suspendidos por Aplicar o Devolver";
            this.Load += new System.EventHandler(this.CONSULTA_CONTRATOS_SUSPENDIDOS_X_APLICAR_O_DEVOLVER_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGW_DEV_EXC_CUOTA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGW_DEV_EXC_CUOTA_DETALLE)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.DataGridView DGW_DEV_EXC_CUOTA;
        internal System.Windows.Forms.DataGridView DGW_DEV_EXC_CUOTA_DETALLE;
        private System.Windows.Forms.DataGridViewTextBoxColumn NRO_PLANILLA_COB;
        private System.Windows.Forms.DataGridViewTextBoxColumn FECHA_DOC;
        private System.Windows.Forms.DataGridViewTextBoxColumn IMP_INI;
        private System.Windows.Forms.DataGridViewTextBoxColumn NRO_PLANILLA;
        private System.Windows.Forms.DataGridViewTextBoxColumn FECHA_PLANILLA;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESC_TIPO;
        private System.Windows.Forms.DataGridViewTextBoxColumn IMP_DOC;
        private System.Windows.Forms.DataGridViewTextBoxColumn NRO_DOCUMENTO_PAGO;
        private System.Windows.Forms.DataGridViewTextBoxColumn FECHA_PAGO;
    }
}