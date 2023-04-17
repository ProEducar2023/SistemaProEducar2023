namespace Presentacion.MOD_CXC
{
    partial class RESUMEN_CANCELADOS_X_TIPO_PLANILLA
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
            this.DGW_DEV_X_RECLAMO = new System.Windows.Forms.DataGridView();
            this.DESC_TIPO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantRegistros = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DGW_DEV_X_RECLAMO)).BeginInit();
            this.SuspendLayout();
            // 
            // DGW_DEV_X_RECLAMO
            // 
            this.DGW_DEV_X_RECLAMO.AllowUserToAddRows = false;
            this.DGW_DEV_X_RECLAMO.AllowUserToDeleteRows = false;
            this.DGW_DEV_X_RECLAMO.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGW_DEV_X_RECLAMO.BackgroundColor = System.Drawing.Color.White;
            this.DGW_DEV_X_RECLAMO.ColumnHeadersHeight = 25;
            this.DGW_DEV_X_RECLAMO.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DESC_TIPO,
            this.CantRegistros,
            this.Total});
            this.DGW_DEV_X_RECLAMO.Location = new System.Drawing.Point(1, 3);
            this.DGW_DEV_X_RECLAMO.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.DGW_DEV_X_RECLAMO.MultiSelect = false;
            this.DGW_DEV_X_RECLAMO.Name = "DGW_DEV_X_RECLAMO";
            this.DGW_DEV_X_RECLAMO.RowHeadersWidth = 25;
            this.DGW_DEV_X_RECLAMO.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.DGW_DEV_X_RECLAMO.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.DGW_DEV_X_RECLAMO.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGW_DEV_X_RECLAMO.Size = new System.Drawing.Size(459, 147);
            this.DGW_DEV_X_RECLAMO.TabIndex = 43;
            this.DGW_DEV_X_RECLAMO.TabStop = false;
            // 
            // DESC_TIPO
            // 
            this.DESC_TIPO.HeaderText = "Tipo de Planilla";
            this.DESC_TIPO.Name = "DESC_TIPO";
            this.DESC_TIPO.Width = 280;
            // 
            // CantRegistros
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.CantRegistros.DefaultCellStyle = dataGridViewCellStyle1;
            this.CantRegistros.HeaderText = "Nª Pllas";
            this.CantRegistros.Name = "CantRegistros";
            this.CantRegistros.Width = 60;
            // 
            // Total
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Total.DefaultCellStyle = dataGridViewCellStyle2;
            this.Total.HeaderText = "Importe";
            this.Total.Name = "Total";
            this.Total.Width = 70;
            // 
            // RESUMEN_CANCELADOS_X_TIPO_PLANILLA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 152);
            this.Controls.Add(this.DGW_DEV_X_RECLAMO);
            this.Name = "RESUMEN_CANCELADOS_X_TIPO_PLANILLA";
            this.Text = "Resumen Cancelados por Tipo Planilla";
            this.Load += new System.EventHandler(this.RESUMEN_CANCELADOS_X_TIPO_PLANILLA_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGW_DEV_X_RECLAMO)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.DataGridView DGW_DEV_X_RECLAMO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESC_TIPO;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantRegistros;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
    }
}