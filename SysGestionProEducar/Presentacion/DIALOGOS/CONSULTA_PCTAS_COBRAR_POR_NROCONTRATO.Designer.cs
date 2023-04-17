namespace Presentacion.DIALOGOS
{
    partial class CONSULTA_PCTAS_COBRAR_POR_NROCONTRATO
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
            this.DGW_CAB = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ini = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cod_prog = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cod_pto_cob = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desc_pto_cob = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cod_pto_ven = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desc_pto_ven = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.OK_Button = new System.Windows.Forms.Button();
            this.Cancel_Button = new System.Windows.Forms.Button();
            this.chkSeleccionarTodos = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.DGW_CAB)).BeginInit();
            this.TableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DGW_CAB
            // 
            this.DGW_CAB.AllowUserToAddRows = false;
            this.DGW_CAB.AllowUserToDeleteRows = false;
            this.DGW_CAB.BackgroundColor = System.Drawing.Color.White;
            this.DGW_CAB.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column3,
            this.Column4,
            this.ini,
            this.Column5,
            this.Column1,
            this.cod_prog,
            this.Column7,
            this.cod_pto_cob,
            this.desc_pto_cob,
            this.cod_pto_ven,
            this.desc_pto_ven});
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
            this.DGW_CAB.Size = new System.Drawing.Size(556, 227);
            this.DGW_CAB.TabIndex = 40;
            this.DGW_CAB.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGW_CAB_CellContentClick);
            this.DGW_CAB.CurrentCellDirtyStateChanged += new System.EventHandler(this.DGW_CAB_CurrentCellDirtyStateChanged);
            // 
            // Column2
            // 
            this.Column2.HeaderText = "coddoc";
            this.Column2.Name = "Column2";
            this.Column2.Visible = false;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Nª Doc";
            this.Column3.Name = "Column3";
            this.Column3.Width = 80;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Fecha";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 80;
            // 
            // ini
            // 
            this.ini.HeaderText = "Imp Ini";
            this.ini.Name = "ini";
            this.ini.Width = 80;
            // 
            // Column5
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            this.Column5.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column5.HeaderText = "Saldo";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 80;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Nro Letra";
            this.Column1.Name = "Column1";
            this.Column1.Width = 80;
            // 
            // cod_prog
            // 
            this.cod_prog.HeaderText = "Tot Letra";
            this.cod_prog.Name = "cod_prog";
            this.cod_prog.Width = 80;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Ok";
            this.Column7.Name = "Column7";
            this.Column7.Width = 30;
            // 
            // cod_pto_cob
            // 
            this.cod_pto_cob.HeaderText = "cod_pto_cob";
            this.cod_pto_cob.Name = "cod_pto_cob";
            this.cod_pto_cob.Visible = false;
            // 
            // desc_pto_cob
            // 
            this.desc_pto_cob.HeaderText = "desc_pto_cob";
            this.desc_pto_cob.Name = "desc_pto_cob";
            this.desc_pto_cob.Visible = false;
            // 
            // cod_pto_ven
            // 
            this.cod_pto_ven.HeaderText = "cod_pto_ven";
            this.cod_pto_ven.Name = "cod_pto_ven";
            this.cod_pto_ven.Visible = false;
            // 
            // desc_pto_ven
            // 
            this.desc_pto_ven.HeaderText = "desc_pto_ven";
            this.desc_pto_ven.Name = "desc_pto_ven";
            this.desc_pto_ven.Visible = false;
            // 
            // TableLayoutPanel1
            // 
            this.TableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TableLayoutPanel1.ColumnCount = 2;
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel1.Controls.Add(this.OK_Button, 0, 0);
            this.TableLayoutPanel1.Controls.Add(this.Cancel_Button, 1, 0);
            this.TableLayoutPanel1.Location = new System.Drawing.Point(384, 258);
            this.TableLayoutPanel1.Name = "TableLayoutPanel1";
            this.TableLayoutPanel1.RowCount = 1;
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel1.Size = new System.Drawing.Size(162, 31);
            this.TableLayoutPanel1.TabIndex = 39;
            // 
            // OK_Button
            // 
            this.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.OK_Button.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OK_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.OK_Button.Location = new System.Drawing.Point(3, 3);
            this.OK_Button.Name = "OK_Button";
            this.OK_Button.Size = new System.Drawing.Size(75, 25);
            this.OK_Button.TabIndex = 0;
            this.OK_Button.Text = "Aceptar";
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Cancel_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Cancel_Button.Location = new System.Drawing.Point(84, 3);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(75, 25);
            this.Cancel_Button.TabIndex = 1;
            this.Cancel_Button.Text = "Cancelar";
            // 
            // chkSeleccionarTodos
            // 
            this.chkSeleccionarTodos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSeleccionarTodos.AutoSize = true;
            this.chkSeleccionarTodos.Location = new System.Drawing.Point(445, 233);
            this.chkSeleccionarTodos.Name = "chkSeleccionarTodos";
            this.chkSeleccionarTodos.Size = new System.Drawing.Size(111, 17);
            this.chkSeleccionarTodos.TabIndex = 54;
            this.chkSeleccionarTodos.Text = "Seleccionar todos";
            this.chkSeleccionarTodos.UseVisualStyleBackColor = true;
            this.chkSeleccionarTodos.CheckedChanged += new System.EventHandler(this.chkSeleccionarTodos_CheckedChanged);
            // 
            // CONSULTA_PCTAS_COBRAR_POR_NROCONTRATO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 298);
            this.Controls.Add(this.chkSeleccionarTodos);
            this.Controls.Add(this.DGW_CAB);
            this.Controls.Add(this.TableLayoutPanel1);
            this.Name = "CONSULTA_PCTAS_COBRAR_POR_NROCONTRATO";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CONSULTA_PCTAS_COBRAR_POR_NROCONTRATO";
            ((System.ComponentModel.ISupportInitialize)(this.DGW_CAB)).EndInit();
            this.TableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.DataGridView DGW_CAB;
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
        internal System.Windows.Forms.Button OK_Button;
        internal System.Windows.Forms.Button Cancel_Button;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn ini;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cod_prog;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn cod_pto_cob;
        private System.Windows.Forms.DataGridViewTextBoxColumn desc_pto_cob;
        private System.Windows.Forms.DataGridViewTextBoxColumn cod_pto_ven;
        private System.Windows.Forms.DataGridViewTextBoxColumn desc_pto_ven;
        internal System.Windows.Forms.CheckBox chkSeleccionarTodos;
    }
}