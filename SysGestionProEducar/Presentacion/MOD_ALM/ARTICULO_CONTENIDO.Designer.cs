namespace Presentacion.MOD_ALM
{
    partial class ARTICULO_CONTENIDO
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ARTICULO_CONTENIDO));
            this.DGW_DET = new System.Windows.Forms.DataGridView();
            this.ITEM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COD_ARTICULO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COD_ART_CONTENIDO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESC_ARTICULO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CANTIDAD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SITUACION = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.BTN_ACEPTAR = new System.Windows.Forms.Button();
            this.BTN_CANCELAR = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGW_DET)).BeginInit();
            this.SuspendLayout();
            // 
            // DGW_DET
            // 
            this.DGW_DET.AllowUserToAddRows = false;
            this.DGW_DET.AllowUserToDeleteRows = false;
            this.DGW_DET.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGW_DET.BackgroundColor = System.Drawing.Color.White;
            this.DGW_DET.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ITEM,
            this.COD_ARTICULO,
            this.COD_ART_CONTENIDO,
            this.DESC_ARTICULO,
            this.CANTIDAD,
            this.SITUACION});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGW_DET.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGW_DET.Location = new System.Drawing.Point(8, 6);
            this.DGW_DET.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.DGW_DET.MultiSelect = false;
            this.DGW_DET.Name = "DGW_DET";
            this.DGW_DET.RowHeadersWidth = 25;
            this.DGW_DET.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.DGW_DET.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.DGW_DET.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGW_DET.Size = new System.Drawing.Size(615, 294);
            this.DGW_DET.TabIndex = 56;
            // 
            // ITEM
            // 
            this.ITEM.HeaderText = "Item";
            this.ITEM.Name = "ITEM";
            this.ITEM.ReadOnly = true;
            this.ITEM.Width = 30;
            // 
            // COD_ARTICULO
            // 
            this.COD_ARTICULO.HeaderText = "COD_ARTICULO";
            this.COD_ARTICULO.Name = "COD_ARTICULO";
            this.COD_ARTICULO.ReadOnly = true;
            this.COD_ARTICULO.Visible = false;
            this.COD_ARTICULO.Width = 70;
            // 
            // COD_ART_CONTENIDO
            // 
            this.COD_ART_CONTENIDO.HeaderText = "Codigo";
            this.COD_ART_CONTENIDO.Name = "COD_ART_CONTENIDO";
            this.COD_ART_CONTENIDO.ReadOnly = true;
            this.COD_ART_CONTENIDO.Width = 60;
            // 
            // DESC_ARTICULO
            // 
            this.DESC_ARTICULO.HeaderText = "Descripción";
            this.DESC_ARTICULO.Name = "DESC_ARTICULO";
            this.DESC_ARTICULO.ReadOnly = true;
            this.DESC_ARTICULO.Width = 280;
            // 
            // CANTIDAD
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle1.Format = "N3";
            dataGridViewCellStyle1.NullValue = null;
            this.CANTIDAD.DefaultCellStyle = dataGridViewCellStyle1;
            this.CANTIDAD.HeaderText = "Cant";
            this.CANTIDAD.Name = "CANTIDAD";
            this.CANTIDAD.ReadOnly = true;
            this.CANTIDAD.Width = 40;
            // 
            // SITUACION
            // 
            this.SITUACION.HeaderText = "Condicion";
            this.SITUACION.Name = "SITUACION";
            this.SITUACION.Width = 150;
            // 
            // BTN_ACEPTAR
            // 
            this.BTN_ACEPTAR.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.BTN_ACEPTAR.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BTN_ACEPTAR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_ACEPTAR.Image = ((System.Drawing.Image)(resources.GetObject("BTN_ACEPTAR.Image")));
            this.BTN_ACEPTAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTN_ACEPTAR.Location = new System.Drawing.Point(459, 311);
            this.BTN_ACEPTAR.Name = "BTN_ACEPTAR";
            this.BTN_ACEPTAR.Size = new System.Drawing.Size(73, 29);
            this.BTN_ACEPTAR.TabIndex = 58;
            this.BTN_ACEPTAR.Text = "&Grabar";
            this.BTN_ACEPTAR.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BTN_CANCELAR
            // 
            this.BTN_CANCELAR.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.BTN_CANCELAR.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BTN_CANCELAR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_CANCELAR.Image = ((System.Drawing.Image)(resources.GetObject("BTN_CANCELAR.Image")));
            this.BTN_CANCELAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTN_CANCELAR.Location = new System.Drawing.Point(550, 311);
            this.BTN_CANCELAR.Name = "BTN_CANCELAR";
            this.BTN_CANCELAR.Size = new System.Drawing.Size(73, 29);
            this.BTN_CANCELAR.TabIndex = 59;
            this.BTN_CANCELAR.Text = "&Salir";
            // 
            // ARTICULO_CONTENIDO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 350);
            this.Controls.Add(this.DGW_DET);
            this.Controls.Add(this.BTN_ACEPTAR);
            this.Controls.Add(this.BTN_CANCELAR);
            this.Name = "ARTICULO_CONTENIDO";
            this.Text = "Contenido de Articulo";
            this.Load += new System.EventHandler(this.ARTICULO_CONTENIDO_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGW_DET)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.DataGridView DGW_DET;
        internal System.Windows.Forms.Button BTN_ACEPTAR;
        internal System.Windows.Forms.Button BTN_CANCELAR;
        private System.Windows.Forms.DataGridViewTextBoxColumn ITEM;
        private System.Windows.Forms.DataGridViewTextBoxColumn COD_ARTICULO;
        private System.Windows.Forms.DataGridViewTextBoxColumn COD_ART_CONTENIDO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESC_ARTICULO;
        private System.Windows.Forms.DataGridViewTextBoxColumn CANTIDAD;
        private System.Windows.Forms.DataGridViewComboBoxColumn SITUACION;
    }
}