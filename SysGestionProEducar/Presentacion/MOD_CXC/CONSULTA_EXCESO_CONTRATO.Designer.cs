namespace Presentacion.MOD_CXC
{
    partial class CONSULTA_EXCESO_CONTRATO
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
            this.DGW_EXCESO_DEVOLUCION = new System.Windows.Forms.DataGridView();
            this.NRO_PLANILLA_COB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FECHA_PLANILLA_COB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IMP_INI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Devuelto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columna = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DGW_EXCESO_DEVOLUCION)).BeginInit();
            this.SuspendLayout();
            // 
            // DGW_EXCESO_DEVOLUCION
            // 
            this.DGW_EXCESO_DEVOLUCION.AllowUserToAddRows = false;
            this.DGW_EXCESO_DEVOLUCION.AllowUserToDeleteRows = false;
            this.DGW_EXCESO_DEVOLUCION.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGW_EXCESO_DEVOLUCION.BackgroundColor = System.Drawing.Color.White;
            this.DGW_EXCESO_DEVOLUCION.ColumnHeadersHeight = 47;
            this.DGW_EXCESO_DEVOLUCION.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NRO_PLANILLA_COB,
            this.FECHA_PLANILLA_COB,
            this.IMP_INI,
            this.Devuelto,
            this.columna,
            this.Column2});
            this.DGW_EXCESO_DEVOLUCION.Location = new System.Drawing.Point(7, 18);
            this.DGW_EXCESO_DEVOLUCION.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.DGW_EXCESO_DEVOLUCION.MultiSelect = false;
            this.DGW_EXCESO_DEVOLUCION.Name = "DGW_EXCESO_DEVOLUCION";
            this.DGW_EXCESO_DEVOLUCION.RowHeadersWidth = 25;
            this.DGW_EXCESO_DEVOLUCION.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.DGW_EXCESO_DEVOLUCION.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.DGW_EXCESO_DEVOLUCION.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGW_EXCESO_DEVOLUCION.Size = new System.Drawing.Size(568, 190);
            this.DGW_EXCESO_DEVOLUCION.TabIndex = 41;
            this.DGW_EXCESO_DEVOLUCION.TabStop = false;
            // 
            // NRO_PLANILLA_COB
            // 
            this.NRO_PLANILLA_COB.HeaderText = "Planilla Exceso Contrato";
            this.NRO_PLANILLA_COB.Name = "NRO_PLANILLA_COB";
            this.NRO_PLANILLA_COB.Width = 80;
            // 
            // FECHA_PLANILLA_COB
            // 
            this.FECHA_PLANILLA_COB.HeaderText = "Fec Planilla";
            this.FECHA_PLANILLA_COB.Name = "FECHA_PLANILLA_COB";
            this.FECHA_PLANILLA_COB.Width = 80;
            // 
            // IMP_INI
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.IMP_INI.DefaultCellStyle = dataGridViewCellStyle1;
            this.IMP_INI.HeaderText = "Descuento Exceso Contrato";
            this.IMP_INI.Name = "IMP_INI";
            this.IMP_INI.Width = 70;
            // 
            // Devuelto
            // 
            this.Devuelto.HeaderText = "Devuelto";
            this.Devuelto.Name = "Devuelto";
            this.Devuelto.Width = 70;
            // 
            // columna
            // 
            this.columna.HeaderText = "Fec Devolucion";
            this.columna.Name = "columna";
            this.columna.Width = 80;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Tipo Devolucion";
            this.Column2.Name = "Column2";
            this.Column2.Width = 120;
            // 
            // CONSULTA_EXCESO_CONTRATO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 224);
            this.Controls.Add(this.DGW_EXCESO_DEVOLUCION);
            this.Name = "CONSULTA_EXCESO_CONTRATO";
            this.Text = "Exceso Contrato";
            this.Load += new System.EventHandler(this.CONSULTA_EXCESO_CONTRATO_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGW_EXCESO_DEVOLUCION)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.DataGridView DGW_EXCESO_DEVOLUCION;
        private System.Windows.Forms.DataGridViewTextBoxColumn NRO_PLANILLA_COB;
        private System.Windows.Forms.DataGridViewTextBoxColumn FECHA_PLANILLA_COB;
        private System.Windows.Forms.DataGridViewTextBoxColumn IMP_INI;
        private System.Windows.Forms.DataGridViewTextBoxColumn Devuelto;
        private System.Windows.Forms.DataGridViewTextBoxColumn columna;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}