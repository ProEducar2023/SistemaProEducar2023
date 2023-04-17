namespace Presentacion.MOD_COMISIONES
{
    partial class CONSULTA_ADELANTO_COMISIONES_PARA_RESUMEN
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CONSULTA_ADELANTO_COMISIONES_PARA_RESUMEN));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgw1 = new System.Windows.Forms.DataGridView();
            this.btn_grabar = new System.Windows.Forms.Button();
            this.btn_salir = new System.Windows.Forms.Button();
            this.FE_AÑO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FE_MES = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COD_PER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESC_PER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COD_DOC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NRO_DOC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FECHA_DOC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IMP_INI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IMP_DOC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OBSERVACION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.X = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgw1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgw1
            // 
            this.dgw1.AllowUserToAddRows = false;
            this.dgw1.AllowUserToDeleteRows = false;
            this.dgw1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgw1.BackgroundColor = System.Drawing.Color.White;
            this.dgw1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FE_AÑO,
            this.FE_MES,
            this.COD_PER,
            this.DESC_PER,
            this.COD_DOC,
            this.NRO_DOC,
            this.FECHA_DOC,
            this.IMP_INI,
            this.IMP_DOC,
            this.OBSERVACION,
            this.X});
            this.dgw1.Location = new System.Drawing.Point(20, 13);
            this.dgw1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dgw1.MultiSelect = false;
            this.dgw1.Name = "dgw1";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgw1.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgw1.RowHeadersWidth = 25;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 8.25F);
            this.dgw1.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgw1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dgw1.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.dgw1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgw1.Size = new System.Drawing.Size(787, 256);
            this.dgw1.TabIndex = 54;
            // 
            // btn_grabar
            // 
            this.btn_grabar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_grabar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_grabar.Image = ((System.Drawing.Image)(resources.GetObject("btn_grabar.Image")));
            this.btn_grabar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_grabar.Location = new System.Drawing.Point(624, 275);
            this.btn_grabar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_grabar.Name = "btn_grabar";
            this.btn_grabar.Size = new System.Drawing.Size(84, 27);
            this.btn_grabar.TabIndex = 63;
            this.btn_grabar.Text = "&Aceptar";
            this.btn_grabar.UseVisualStyleBackColor = true;
            // 
            // btn_salir
            // 
            this.btn_salir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_salir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_salir.Image = ((System.Drawing.Image)(resources.GetObject("btn_salir.Image")));
            this.btn_salir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_salir.Location = new System.Drawing.Point(723, 275);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(84, 27);
            this.btn_salir.TabIndex = 64;
            this.btn_salir.Text = "&Cancelar";
            this.btn_salir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_salir.UseVisualStyleBackColor = true;
            this.btn_salir.Click += new System.EventHandler(this.btn_salir_Click);
            // 
            // FE_AÑO
            // 
            this.FE_AÑO.HeaderText = "FE_AÑO";
            this.FE_AÑO.Name = "FE_AÑO";
            this.FE_AÑO.Visible = false;
            // 
            // FE_MES
            // 
            this.FE_MES.HeaderText = "FE_MES";
            this.FE_MES.Name = "FE_MES";
            this.FE_MES.Visible = false;
            // 
            // COD_PER
            // 
            this.COD_PER.HeaderText = "COD_COMISIONANTE";
            this.COD_PER.Name = "COD_PER";
            this.COD_PER.Visible = false;
            // 
            // DESC_PER
            // 
            this.DESC_PER.HeaderText = "Comisionista";
            this.DESC_PER.Name = "DESC_PER";
            this.DESC_PER.ReadOnly = true;
            this.DESC_PER.Width = 240;
            // 
            // COD_DOC
            // 
            this.COD_DOC.HeaderText = "COD_DOC";
            this.COD_DOC.Name = "COD_DOC";
            this.COD_DOC.Visible = false;
            // 
            // NRO_DOC
            // 
            this.NRO_DOC.HeaderText = "Nro Docu";
            this.NRO_DOC.Name = "NRO_DOC";
            this.NRO_DOC.Width = 80;
            // 
            // FECHA_DOC
            // 
            this.FECHA_DOC.HeaderText = "Fe Docu";
            this.FECHA_DOC.Name = "FECHA_DOC";
            this.FECHA_DOC.Width = 70;
            // 
            // IMP_INI
            // 
            this.IMP_INI.HeaderText = "Imp";
            this.IMP_INI.Name = "IMP_INI";
            this.IMP_INI.Width = 60;
            // 
            // IMP_DOC
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.IMP_DOC.DefaultCellStyle = dataGridViewCellStyle1;
            this.IMP_DOC.HeaderText = "Importe";
            this.IMP_DOC.Name = "IMP_DOC";
            this.IMP_DOC.Width = 60;
            // 
            // OBSERVACION
            // 
            this.OBSERVACION.HeaderText = "Observacion";
            this.OBSERVACION.Name = "OBSERVACION";
            this.OBSERVACION.Width = 200;
            // 
            // X
            // 
            this.X.HeaderText = "X";
            this.X.Name = "X";
            this.X.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.X.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.X.Width = 30;
            // 
            // CONSULTA_ADELANTO_COMISIONES_PARA_RESUMEN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 310);
            this.Controls.Add(this.btn_salir);
            this.Controls.Add(this.btn_grabar);
            this.Controls.Add(this.dgw1);
            this.Name = "CONSULTA_ADELANTO_COMISIONES_PARA_RESUMEN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adelanto Comisiones Pendientes x Persona";
            ((System.ComponentModel.ISupportInitialize)(this.dgw1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.DataGridView dgw1;
        internal System.Windows.Forms.Button btn_grabar;
        internal System.Windows.Forms.Button btn_salir;
        private System.Windows.Forms.DataGridViewTextBoxColumn FE_AÑO;
        private System.Windows.Forms.DataGridViewTextBoxColumn FE_MES;
        private System.Windows.Forms.DataGridViewTextBoxColumn COD_PER;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESC_PER;
        private System.Windows.Forms.DataGridViewTextBoxColumn COD_DOC;
        private System.Windows.Forms.DataGridViewTextBoxColumn NRO_DOC;
        private System.Windows.Forms.DataGridViewTextBoxColumn FECHA_DOC;
        private System.Windows.Forms.DataGridViewTextBoxColumn IMP_INI;
        private System.Windows.Forms.DataGridViewTextBoxColumn IMP_DOC;
        private System.Windows.Forms.DataGridViewTextBoxColumn OBSERVACION;
        private System.Windows.Forms.DataGridViewCheckBoxColumn X;
    }
}