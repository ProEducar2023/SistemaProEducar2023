namespace Presentacion.DIALOGOS
{
    partial class CONSULTA_PARA_CANJE_CXC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CONSULTA_PARA_CANJE_CXC));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.GroupBox8 = new System.Windows.Forms.GroupBox();
            this.ch_cod = new System.Windows.Forms.RadioButton();
            this.txt_letra = new System.Windows.Forms.TextBox();
            this.LBL = new System.Windows.Forms.Label();
            this.DGW = new System.Windows.Forms.DataGridView();
            this.DataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGW_CAB = new System.Windows.Forms.DataGridView();
            this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.OK_Button = new System.Windows.Forms.Button();
            this.Cancel_Button = new System.Windows.Forms.Button();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Seleccion = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cod_prog = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGW_CAB)).BeginInit();
            this.TableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox8
            // 
            this.GroupBox8.Controls.Add(this.ch_cod);
            this.GroupBox8.Controls.Add(this.txt_letra);
            this.GroupBox8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox8.Location = new System.Drawing.Point(12, 235);
            this.GroupBox8.Name = "GroupBox8";
            this.GroupBox8.Size = new System.Drawing.Size(231, 62);
            this.GroupBox8.TabIndex = 38;
            this.GroupBox8.TabStop = false;
            this.GroupBox8.Text = "Buscado por:";
            // 
            // ch_cod
            // 
            this.ch_cod.AutoSize = true;
            this.ch_cod.Font = new System.Drawing.Font("Arial", 8.25F);
            this.ch_cod.Location = new System.Drawing.Point(6, 35);
            this.ch_cod.Name = "ch_cod";
            this.ch_cod.Size = new System.Drawing.Size(94, 18);
            this.ch_cod.TabIndex = 1;
            this.ch_cod.Text = "Nº Documento";
            this.ch_cod.UseVisualStyleBackColor = true;
            this.ch_cod.CheckedChanged += new System.EventHandler(this.ch_cod_CheckedChanged);
            // 
            // txt_letra
            // 
            this.txt_letra.Font = new System.Drawing.Font("Arial", 8.25F);
            this.txt_letra.Location = new System.Drawing.Point(6, 15);
            this.txt_letra.Name = "txt_letra";
            this.txt_letra.Size = new System.Drawing.Size(206, 20);
            this.txt_letra.TabIndex = 0;
            this.txt_letra.TextChanged += new System.EventHandler(this.txt_letra_TextChanged);
            // 
            // LBL
            // 
            this.LBL.AutoSize = true;
            this.LBL.Location = new System.Drawing.Point(290, 266);
            this.LBL.Name = "LBL";
            this.LBL.Size = new System.Drawing.Size(39, 13);
            this.LBL.TabIndex = 37;
            this.LBL.Text = "Label1";
            this.LBL.Visible = false;
            // 
            // DGW
            // 
            this.DGW.AllowUserToAddRows = false;
            this.DGW.AllowUserToDeleteRows = false;
            this.DGW.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGW.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DataGridViewTextBoxColumn1,
            this.DataGridViewTextBoxColumn2});
            this.DGW.Location = new System.Drawing.Point(0, 135);
            this.DGW.Name = "DGW";
            this.DGW.Size = new System.Drawing.Size(224, 57);
            this.DGW.TabIndex = 36;
            this.DGW.Visible = false;
            // 
            // DataGridViewTextBoxColumn1
            // 
            this.DataGridViewTextBoxColumn1.HeaderText = "COD_DOC";
            this.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1";
            this.DataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // DataGridViewTextBoxColumn2
            // 
            this.DataGridViewTextBoxColumn2.HeaderText = "NRO_DOC";
            this.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2";
            this.DataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // DGW_CAB
            // 
            this.DGW_CAB.AllowUserToAddRows = false;
            this.DGW_CAB.AllowUserToDeleteRows = false;
            this.DGW_CAB.BackgroundColor = System.Drawing.Color.White;
            this.DGW_CAB.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column4,
            this.Column5,
            this.Seleccion,
            this.Column9,
            this.Column1,
            this.cod_prog});
            this.DGW_CAB.Dock = System.Windows.Forms.DockStyle.Top;
            this.DGW_CAB.Location = new System.Drawing.Point(0, 0);
            this.DGW_CAB.Name = "DGW_CAB";
            this.DGW_CAB.RowHeadersWidth = 25;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            this.DGW_CAB.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.DGW_CAB.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.DGW_CAB.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.DGW_CAB.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGW_CAB.Size = new System.Drawing.Size(537, 227);
            this.DGW_CAB.TabIndex = 1;
            this.DGW_CAB.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.DGW_CAB_CellBeginEdit);
            // 
            // TableLayoutPanel1
            // 
            this.TableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TableLayoutPanel1.ColumnCount = 2;
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel1.Controls.Add(this.OK_Button, 0, 0);
            this.TableLayoutPanel1.Controls.Add(this.Cancel_Button, 1, 0);
            this.TableLayoutPanel1.Location = new System.Drawing.Point(365, 257);
            this.TableLayoutPanel1.Name = "TableLayoutPanel1";
            this.TableLayoutPanel1.RowCount = 1;
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel1.Size = new System.Drawing.Size(162, 31);
            this.TableLayoutPanel1.TabIndex = 34;
            // 
            // OK_Button
            // 
            this.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.OK_Button.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OK_Button.Image = ((System.Drawing.Image)(resources.GetObject("OK_Button.Image")));
            this.OK_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.OK_Button.Location = new System.Drawing.Point(3, 3);
            this.OK_Button.Name = "OK_Button";
            this.OK_Button.Size = new System.Drawing.Size(75, 25);
            this.OK_Button.TabIndex = 2;
            this.OK_Button.Text = "&Aceptar";
            this.OK_Button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.OK_Button.Click += new System.EventHandler(this.OK_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Cancel_Button.Image = ((System.Drawing.Image)(resources.GetObject("Cancel_Button.Image")));
            this.Cancel_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Cancel_Button.Location = new System.Drawing.Point(84, 3);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(75, 25);
            this.Cancel_Button.TabIndex = 3;
            this.Cancel_Button.Text = "&Cancelar";
            this.Cancel_Button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Column3
            // 
            this.Column3.HeaderText = "NªContrato";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Fecha";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 80;
            // 
            // Column5
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            this.Column5.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column5.HeaderText = "Importe";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Seleccion
            // 
            this.Seleccion.HeaderText = "Ok";
            this.Seleccion.Name = "Seleccion";
            this.Seleccion.Width = 30;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Fec 1er Vct";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Fec Vct Men";
            this.Column1.Name = "Column1";
            // 
            // cod_prog
            // 
            this.cod_prog.HeaderText = "cod_prog";
            this.cod_prog.Name = "cod_prog";
            this.cod_prog.Visible = false;
            // 
            // CONSULTA_PARA_CANJE_CXC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 298);
            this.Controls.Add(this.GroupBox8);
            this.Controls.Add(this.LBL);
            this.Controls.Add(this.DGW);
            this.Controls.Add(this.DGW_CAB);
            this.Controls.Add(this.TableLayoutPanel1);
            this.Name = "CONSULTA_PARA_CANJE_CXC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CONSULTA_PARA_CANJE_CXC";
            this.Shown += new System.EventHandler(this.CONSULTA_PARA_CANJE_CXC_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CONSULTA_PARA_CANJE_CXC_KeyDown);
            this.GroupBox8.ResumeLayout(false);
            this.GroupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGW_CAB)).EndInit();
            this.TableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.GroupBox GroupBox8;
        internal System.Windows.Forms.RadioButton ch_cod;
        internal System.Windows.Forms.TextBox txt_letra;
        internal System.Windows.Forms.Label LBL;
        internal System.Windows.Forms.DataGridView DGW;
        internal System.Windows.Forms.DataGridViewTextBoxColumn DataGridViewTextBoxColumn1;
        internal System.Windows.Forms.DataGridViewTextBoxColumn DataGridViewTextBoxColumn2;
        internal System.Windows.Forms.DataGridView DGW_CAB;
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
        internal System.Windows.Forms.Button OK_Button;
        internal System.Windows.Forms.Button Cancel_Button;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Seleccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cod_prog;
    }
}