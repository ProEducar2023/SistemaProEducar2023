namespace Presentacion.MOD_CXC
{
    partial class CONSULTA_DEV_X_RECLAMOS
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
            this.DGW_DEV_X_RECLAMO = new System.Windows.Forms.DataGridView();
            this.Label2 = new System.Windows.Forms.Label();
            this.lbl_imp_pagado = new System.Windows.Forms.Label();
            this.NRO_PLANILLA_DOC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FECHA_PLANILLA_DOC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TIPO_PLANILLA_DOC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IMP_DOC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESC_MOTIVO_OT_DEV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NRO_DOCUMENTO_PAGO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FECHA_PAGO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DGW_DEV_X_RECLAMO)).BeginInit();
            this.SuspendLayout();
            // 
            // DGW_DEV_X_RECLAMO
            // 
            this.DGW_DEV_X_RECLAMO.AllowUserToAddRows = false;
            this.DGW_DEV_X_RECLAMO.AllowUserToDeleteRows = false;
            this.DGW_DEV_X_RECLAMO.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGW_DEV_X_RECLAMO.BackgroundColor = System.Drawing.Color.White;
            this.DGW_DEV_X_RECLAMO.ColumnHeadersHeight = 47;
            this.DGW_DEV_X_RECLAMO.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NRO_PLANILLA_DOC,
            this.FECHA_PLANILLA_DOC,
            this.TIPO_PLANILLA_DOC,
            this.IMP_DOC,
            this.DESC_MOTIVO_OT_DEV,
            this.NRO_DOCUMENTO_PAGO,
            this.FECHA_PAGO});
            this.DGW_DEV_X_RECLAMO.Location = new System.Drawing.Point(9, 32);
            this.DGW_DEV_X_RECLAMO.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.DGW_DEV_X_RECLAMO.MultiSelect = false;
            this.DGW_DEV_X_RECLAMO.Name = "DGW_DEV_X_RECLAMO";
            this.DGW_DEV_X_RECLAMO.RowHeadersWidth = 25;
            this.DGW_DEV_X_RECLAMO.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.DGW_DEV_X_RECLAMO.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.DGW_DEV_X_RECLAMO.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGW_DEV_X_RECLAMO.Size = new System.Drawing.Size(632, 175);
            this.DGW_DEV_X_RECLAMO.TabIndex = 42;
            this.DGW_DEV_X_RECLAMO.TabStop = false;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(11, 9);
            this.Label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(120, 13);
            this.Label2.TabIndex = 241;
            this.Label2.Text = "Total Pagado x Cliente :";
            // 
            // lbl_imp_pagado
            // 
            this.lbl_imp_pagado.AutoSize = true;
            this.lbl_imp_pagado.Location = new System.Drawing.Point(135, 9);
            this.lbl_imp_pagado.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_imp_pagado.Name = "lbl_imp_pagado";
            this.lbl_imp_pagado.Size = new System.Drawing.Size(67, 13);
            this.lbl_imp_pagado.TabIndex = 242;
            this.lbl_imp_pagado.Text = "xxxxxxxxxxxx";
            // 
            // NRO_PLANILLA_DOC
            // 
            this.NRO_PLANILLA_DOC.HeaderText = "Planilla Dev x Reclamo";
            this.NRO_PLANILLA_DOC.Name = "NRO_PLANILLA_DOC";
            this.NRO_PLANILLA_DOC.Width = 80;
            // 
            // FECHA_PLANILLA_DOC
            // 
            this.FECHA_PLANILLA_DOC.HeaderText = "Fec Planilla";
            this.FECHA_PLANILLA_DOC.Name = "FECHA_PLANILLA_DOC";
            this.FECHA_PLANILLA_DOC.Width = 80;
            // 
            // TIPO_PLANILLA_DOC
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.TIPO_PLANILLA_DOC.DefaultCellStyle = dataGridViewCellStyle1;
            this.TIPO_PLANILLA_DOC.HeaderText = "Tipo";
            this.TIPO_PLANILLA_DOC.Name = "TIPO_PLANILLA_DOC";
            this.TIPO_PLANILLA_DOC.Visible = false;
            this.TIPO_PLANILLA_DOC.Width = 50;
            // 
            // IMP_DOC
            // 
            this.IMP_DOC.HeaderText = "Importe Dev x Reclamo";
            this.IMP_DOC.Name = "IMP_DOC";
            this.IMP_DOC.Width = 70;
            // 
            // DESC_MOTIVO_OT_DEV
            // 
            this.DESC_MOTIVO_OT_DEV.HeaderText = "Motivo Reclamo";
            this.DESC_MOTIVO_OT_DEV.Name = "DESC_MOTIVO_OT_DEV";
            this.DESC_MOTIVO_OT_DEV.Width = 200;
            // 
            // NRO_DOCUMENTO_PAGO
            // 
            this.NRO_DOCUMENTO_PAGO.HeaderText = "Nro Recibo";
            this.NRO_DOCUMENTO_PAGO.Name = "NRO_DOCUMENTO_PAGO";
            this.NRO_DOCUMENTO_PAGO.Width = 80;
            // 
            // FECHA_PAGO
            // 
            this.FECHA_PAGO.HeaderText = "Fec     Pago";
            this.FECHA_PAGO.Name = "FECHA_PAGO";
            this.FECHA_PAGO.Width = 80;
            // 
            // CONSULTA_DEV_X_RECLAMOS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 224);
            this.Controls.Add(this.lbl_imp_pagado);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.DGW_DEV_X_RECLAMO);
            this.Name = "CONSULTA_DEV_X_RECLAMOS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta Devolucion por Reclamos";
            this.Load += new System.EventHandler(this.CONSULTA_DEV_X_RECLAMOS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGW_DEV_X_RECLAMO)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.DataGridView DGW_DEV_X_RECLAMO;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label lbl_imp_pagado;
        private System.Windows.Forms.DataGridViewTextBoxColumn NRO_PLANILLA_DOC;
        private System.Windows.Forms.DataGridViewTextBoxColumn FECHA_PLANILLA_DOC;
        private System.Windows.Forms.DataGridViewTextBoxColumn TIPO_PLANILLA_DOC;
        private System.Windows.Forms.DataGridViewTextBoxColumn IMP_DOC;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESC_MOTIVO_OT_DEV;
        private System.Windows.Forms.DataGridViewTextBoxColumn NRO_DOCUMENTO_PAGO;
        private System.Windows.Forms.DataGridViewTextBoxColumn FECHA_PAGO;
    }
}