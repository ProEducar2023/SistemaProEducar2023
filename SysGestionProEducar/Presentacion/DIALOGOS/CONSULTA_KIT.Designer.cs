namespace Presentacion.DIALOGOS
{
    partial class CONSULTA_KIT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CONSULTA_KIT));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.BTN_ACEPTAR = new System.Windows.Forms.Button();
            this.BTN_CANCELAR = new System.Windows.Forms.Button();
            this.DGW = new System.Windows.Forms.DataGridView();
            this.DataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGW_DET = new System.Windows.Forms.DataGridView();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.STATUS_IGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGW_CAB = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_cantidad_a_ingresar = new System.Windows.Forms.TextBox();
            this.lbl_cantidad_a_ingresar = new System.Windows.Forms.Label();
            this.TableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGW_DET)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGW_CAB)).BeginInit();
            this.SuspendLayout();
            // 
            // TableLayoutPanel1
            // 
            this.TableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TableLayoutPanel1.ColumnCount = 2;
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel1.Controls.Add(this.BTN_ACEPTAR, 0, 0);
            this.TableLayoutPanel1.Controls.Add(this.BTN_CANCELAR, 1, 0);
            this.TableLayoutPanel1.Location = new System.Drawing.Point(380, 421);
            this.TableLayoutPanel1.Name = "TableLayoutPanel1";
            this.TableLayoutPanel1.RowCount = 1;
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel1.Size = new System.Drawing.Size(172, 33);
            this.TableLayoutPanel1.TabIndex = 41;
            // 
            // BTN_ACEPTAR
            // 
            this.BTN_ACEPTAR.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BTN_ACEPTAR.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BTN_ACEPTAR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_ACEPTAR.Image = ((System.Drawing.Image)(resources.GetObject("BTN_ACEPTAR.Image")));
            this.BTN_ACEPTAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTN_ACEPTAR.Location = new System.Drawing.Point(5, 3);
            this.BTN_ACEPTAR.Name = "BTN_ACEPTAR";
            this.BTN_ACEPTAR.Size = new System.Drawing.Size(76, 27);
            this.BTN_ACEPTAR.TabIndex = 32;
            this.BTN_ACEPTAR.Text = "&Agregar";
            this.BTN_ACEPTAR.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTN_ACEPTAR.Click += new System.EventHandler(this.BTN_ACEPTAR_Click);
            // 
            // BTN_CANCELAR
            // 
            this.BTN_CANCELAR.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BTN_CANCELAR.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BTN_CANCELAR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_CANCELAR.Image = ((System.Drawing.Image)(resources.GetObject("BTN_CANCELAR.Image")));
            this.BTN_CANCELAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTN_CANCELAR.Location = new System.Drawing.Point(91, 3);
            this.BTN_CANCELAR.Name = "BTN_CANCELAR";
            this.BTN_CANCELAR.Size = new System.Drawing.Size(76, 27);
            this.BTN_CANCELAR.TabIndex = 33;
            this.BTN_CANCELAR.Text = "&Salir";
            this.BTN_CANCELAR.Click += new System.EventHandler(this.BTN_CANCELAR_Click);
            // 
            // DGW
            // 
            this.DGW.AllowUserToAddRows = false;
            this.DGW.AllowUserToDeleteRows = false;
            this.DGW.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGW.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DataGridViewTextBoxColumn1,
            this.DataGridViewTextBoxColumn2});
            this.DGW.Location = new System.Drawing.Point(12, 427);
            this.DGW.Name = "DGW";
            this.DGW.Size = new System.Drawing.Size(23, 20);
            this.DGW.TabIndex = 40;
            this.DGW.Visible = false;
            // 
            // DataGridViewTextBoxColumn1
            // 
            this.DataGridViewTextBoxColumn1.HeaderText = "COD_ARTICULO";
            this.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1";
            // 
            // DataGridViewTextBoxColumn2
            // 
            this.DataGridViewTextBoxColumn2.HeaderText = "COD_KIT";
            this.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2";
            // 
            // DGW_DET
            // 
            this.DGW_DET.AllowUserToAddRows = false;
            this.DGW_DET.AllowUserToDeleteRows = false;
            this.DGW_DET.BackgroundColor = System.Drawing.Color.White;
            this.DGW_DET.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column11,
            this.Column12,
            this.Column3,
            this.Column4,
            this.Column13,
            this.Column14,
            this.Column5,
            this.STATUS_IGV});
            this.DGW_DET.Location = new System.Drawing.Point(0, 140);
            this.DGW_DET.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.DGW_DET.MultiSelect = false;
            this.DGW_DET.Name = "DGW_DET";
            this.DGW_DET.RowHeadersWidth = 25;
            this.DGW_DET.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.DGW_DET.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.DGW_DET.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.DGW_DET.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGW_DET.Size = new System.Drawing.Size(564, 275);
            this.DGW_DET.TabIndex = 39;
            this.DGW_DET.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGW_DET_CellEndEdit);
            this.DGW_DET.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.DGW_DET_CellValidating);
            // 
            // Column11
            // 
            this.Column11.HeaderText = "Codigo";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.Width = 50;
            // 
            // Column12
            // 
            this.Column12.FillWeight = 304.5685F;
            this.Column12.HeaderText = "Descripcion";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            this.Column12.Width = 300;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Nº Parte";
            this.Column3.Name = "Column3";
            this.Column3.Visible = false;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "u.m";
            this.Column4.Name = "Column4";
            this.Column4.Visible = false;
            // 
            // Column13
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N3";
            this.Column13.DefaultCellStyle = dataGridViewCellStyle7;
            this.Column13.FillWeight = 31.81049F;
            this.Column13.HeaderText = "Cantidad";
            this.Column13.Name = "Column13";
            this.Column13.Width = 65;
            // 
            // Column14
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N3";
            this.Column14.DefaultCellStyle = dataGridViewCellStyle8;
            this.Column14.FillWeight = 31.81049F;
            this.Column14.HeaderText = "P.U.";
            this.Column14.Name = "Column14";
            this.Column14.ReadOnly = true;
            this.Column14.Width = 65;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Ref";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column5.Width = 40;
            // 
            // STATUS_IGV
            // 
            this.STATUS_IGV.HeaderText = "STATUS_IGV";
            this.STATUS_IGV.Name = "STATUS_IGV";
            this.STATUS_IGV.Visible = false;
            // 
            // DGW_CAB
            // 
            this.DGW_CAB.AllowUserToAddRows = false;
            this.DGW_CAB.AllowUserToDeleteRows = false;
            this.DGW_CAB.BackgroundColor = System.Drawing.Color.White;
            this.DGW_CAB.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.DGW_CAB.Dock = System.Windows.Forms.DockStyle.Top;
            this.DGW_CAB.Location = new System.Drawing.Point(0, 0);
            this.DGW_CAB.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.DGW_CAB.MultiSelect = false;
            this.DGW_CAB.Name = "DGW_CAB";
            this.DGW_CAB.ReadOnly = true;
            this.DGW_CAB.RowHeadersWidth = 25;
            this.DGW_CAB.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.DGW_CAB.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.DGW_CAB.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.DGW_CAB.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGW_CAB.Size = new System.Drawing.Size(564, 119);
            this.DGW_CAB.TabIndex = 38;
            this.DGW_CAB.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGW_CAB_CellEnter);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Cód KIT";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 70;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Descripción de KIT";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 440;
            // 
            // txt_cantidad_a_ingresar
            // 
            this.txt_cantidad_a_ingresar.BackColor = System.Drawing.Color.White;
            this.txt_cantidad_a_ingresar.Location = new System.Drawing.Point(374, 119);
            this.txt_cantidad_a_ingresar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_cantidad_a_ingresar.MaxLength = 5;
            this.txt_cantidad_a_ingresar.Name = "txt_cantidad_a_ingresar";
            this.txt_cantidad_a_ingresar.Size = new System.Drawing.Size(51, 20);
            this.txt_cantidad_a_ingresar.TabIndex = 42;
            this.txt_cantidad_a_ingresar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_cantidad_a_ingresar_KeyDown);
            this.txt_cantidad_a_ingresar.Leave += new System.EventHandler(this.txt_cantidad_a_ingresar_Leave);
            // 
            // lbl_cantidad_a_ingresar
            // 
            this.lbl_cantidad_a_ingresar.AutoSize = true;
            this.lbl_cantidad_a_ingresar.Location = new System.Drawing.Point(275, 122);
            this.lbl_cantidad_a_ingresar.Name = "lbl_cantidad_a_ingresar";
            this.lbl_cantidad_a_ingresar.Size = new System.Drawing.Size(98, 13);
            this.lbl_cantidad_a_ingresar.TabIndex = 43;
            this.lbl_cantidad_a_ingresar.Text = "Cantidad a ingresar";
            // 
            // CONSULTA_KIT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 460);
            this.Controls.Add(this.txt_cantidad_a_ingresar);
            this.Controls.Add(this.lbl_cantidad_a_ingresar);
            this.Controls.Add(this.TableLayoutPanel1);
            this.Controls.Add(this.DGW);
            this.Controls.Add(this.DGW_DET);
            this.Controls.Add(this.DGW_CAB);
            this.Name = "CONSULTA_KIT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta Kit";
            this.Load += new System.EventHandler(this.CONSULTA_KIT_Load);
            this.Shown += new System.EventHandler(this.CONSULTA_KIT_Shown);
            this.TableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGW_DET)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGW_CAB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
        internal System.Windows.Forms.Button BTN_ACEPTAR;
        internal System.Windows.Forms.Button BTN_CANCELAR;
        internal System.Windows.Forms.DataGridView DGW;
        internal System.Windows.Forms.DataGridViewTextBoxColumn DataGridViewTextBoxColumn1;
        internal System.Windows.Forms.DataGridViewTextBoxColumn DataGridViewTextBoxColumn2;
        internal System.Windows.Forms.DataGridView DGW_DET;
        internal System.Windows.Forms.DataGridView DGW_CAB;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn STATUS_IGV;
        internal System.Windows.Forms.TextBox txt_cantidad_a_ingresar;
        internal System.Windows.Forms.Label lbl_cantidad_a_ingresar;
    }
}