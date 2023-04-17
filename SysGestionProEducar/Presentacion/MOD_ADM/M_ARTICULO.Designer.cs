namespace Presentacion.MOD_ADM
{
    partial class M_ARTICULO
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
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.GroupBox8 = new System.Windows.Forms.GroupBox();
            this.ch_rs = new System.Windows.Forms.RadioButton();
            this.ch_cod = new System.Windows.Forms.RadioButton();
            this.txt_letra = new System.Windows.Forms.TextBox();
            this.btn_salir = new System.Windows.Forms.Button();
            this.btn_modificar = new System.Windows.Forms.Button();
            this.btn_nuevo = new System.Windows.Forms.Button();
            this.dgw1 = new System.Windows.Forms.DataGridView();
            this.TabPage2 = new System.Windows.Forms.TabPage();
            this.Panel_PRO = new System.Windows.Forms.Panel();
            this.DGW_PRO = new System.Windows.Forms.DataGridView();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.Button5 = new System.Windows.Forms.Button();
            this.TXT_DESC_PRO = new System.Windows.Forms.TextBox();
            this.K = new System.Windows.Forms.TextBox();
            this.txt_saldo = new System.Windows.Forms.TextBox();
            this.btn_modificar2 = new System.Windows.Forms.Button();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.btn_guardar = new System.Windows.Forms.Button();
            this.TXT_COD_PRO = new System.Windows.Forms.TextBox();
            this.Label17 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.cbo_almacen = new System.Windows.Forms.ComboBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.CBO_CLASE = new System.Windows.Forms.ComboBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.TabControl1.SuspendLayout();
            this.TabPage1.SuspendLayout();
            this.GroupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw1)).BeginInit();
            this.TabPage2.SuspendLayout();
            this.Panel_PRO.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGW_PRO)).BeginInit();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControl1
            // 
            this.TabControl1.Controls.Add(this.TabPage1);
            this.TabControl1.Controls.Add(this.TabPage2);
            this.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabControl1.Location = new System.Drawing.Point(0, 0);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(672, 329);
            this.TabControl1.TabIndex = 4;
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.GroupBox8);
            this.TabPage1.Controls.Add(this.btn_salir);
            this.TabPage1.Controls.Add(this.btn_modificar);
            this.TabPage1.Controls.Add(this.btn_nuevo);
            this.TabPage1.Controls.Add(this.dgw1);
            this.TabPage1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabPage1.Location = new System.Drawing.Point(4, 23);
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage1.Size = new System.Drawing.Size(664, 302);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "Lista de Saldos de Articulo";
            this.TabPage1.UseVisualStyleBackColor = true;
            // 
            // GroupBox8
            // 
            this.GroupBox8.Controls.Add(this.ch_rs);
            this.GroupBox8.Controls.Add(this.ch_cod);
            this.GroupBox8.Controls.Add(this.txt_letra);
            this.GroupBox8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox8.Location = new System.Drawing.Point(21, 234);
            this.GroupBox8.Name = "GroupBox8";
            this.GroupBox8.Size = new System.Drawing.Size(239, 65);
            this.GroupBox8.TabIndex = 27;
            this.GroupBox8.TabStop = false;
            this.GroupBox8.Text = "Buscado por:";
            // 
            // ch_rs
            // 
            this.ch_rs.AutoSize = true;
            this.ch_rs.Font = new System.Drawing.Font("Arial", 8.25F);
            this.ch_rs.Location = new System.Drawing.Point(7, 42);
            this.ch_rs.Name = "ch_rs";
            this.ch_rs.Size = new System.Drawing.Size(58, 18);
            this.ch_rs.TabIndex = 1;
            this.ch_rs.Text = "Codigo";
            this.ch_rs.UseVisualStyleBackColor = true;
            // 
            // ch_cod
            // 
            this.ch_cod.AutoSize = true;
            this.ch_cod.Font = new System.Drawing.Font("Arial", 8.25F);
            this.ch_cod.Location = new System.Drawing.Point(101, 41);
            this.ch_cod.Name = "ch_cod";
            this.ch_cod.Size = new System.Drawing.Size(62, 18);
            this.ch_cod.TabIndex = 2;
            this.ch_cod.Text = "Articulo";
            this.ch_cod.UseVisualStyleBackColor = true;
            // 
            // txt_letra
            // 
            this.txt_letra.Font = new System.Drawing.Font("Arial", 8.25F);
            this.txt_letra.Location = new System.Drawing.Point(6, 19);
            this.txt_letra.Name = "txt_letra";
            this.txt_letra.Size = new System.Drawing.Size(206, 20);
            this.txt_letra.TabIndex = 0;
            // 
            // btn_salir
            // 
            this.btn_salir.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_salir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_salir.Location = new System.Drawing.Point(571, 105);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(85, 35);
            this.btn_salir.TabIndex = 3;
            this.btn_salir.Text = "&Salir";
            this.btn_salir.UseVisualStyleBackColor = true;
            // 
            // btn_modificar
            // 
            this.btn_modificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_modificar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_modificar.Location = new System.Drawing.Point(571, 64);
            this.btn_modificar.Name = "btn_modificar";
            this.btn_modificar.Size = new System.Drawing.Size(85, 35);
            this.btn_modificar.TabIndex = 2;
            this.btn_modificar.Text = "&Modificar";
            this.btn_modificar.UseVisualStyleBackColor = true;
            // 
            // btn_nuevo
            // 
            this.btn_nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_nuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_nuevo.Location = new System.Drawing.Point(571, 23);
            this.btn_nuevo.Name = "btn_nuevo";
            this.btn_nuevo.Size = new System.Drawing.Size(85, 35);
            this.btn_nuevo.TabIndex = 1;
            this.btn_nuevo.Text = "&Nuevo";
            this.btn_nuevo.UseVisualStyleBackColor = true;
            // 
            // dgw1
            // 
            this.dgw1.AllowUserToAddRows = false;
            this.dgw1.AllowUserToDeleteRows = false;
            this.dgw1.AllowUserToOrderColumns = true;
            this.dgw1.AllowUserToResizeRows = false;
            this.dgw1.BackgroundColor = System.Drawing.Color.White;
            this.dgw1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgw1.Location = new System.Drawing.Point(21, 23);
            this.dgw1.MultiSelect = false;
            this.dgw1.Name = "dgw1";
            this.dgw1.ReadOnly = true;
            this.dgw1.RowHeadersWidth = 25;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            this.dgw1.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgw1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dgw1.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.dgw1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgw1.Size = new System.Drawing.Size(544, 206);
            this.dgw1.TabIndex = 0;
            // 
            // TabPage2
            // 
            this.TabPage2.Controls.Add(this.Panel_PRO);
            this.TabPage2.Controls.Add(this.GroupBox1);
            this.TabPage2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabPage2.Location = new System.Drawing.Point(4, 23);
            this.TabPage2.Name = "TabPage2";
            this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage2.Size = new System.Drawing.Size(664, 302);
            this.TabPage2.TabIndex = 1;
            this.TabPage2.Text = "Detalles";
            this.TabPage2.UseVisualStyleBackColor = true;
            // 
            // Panel_PRO
            // 
            this.Panel_PRO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel_PRO.Controls.Add(this.DGW_PRO);
            this.Panel_PRO.Location = new System.Drawing.Point(18, 119);
            this.Panel_PRO.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Panel_PRO.Name = "Panel_PRO";
            this.Panel_PRO.Size = new System.Drawing.Size(492, 109);
            this.Panel_PRO.TabIndex = 15;
            this.Panel_PRO.Visible = false;
            // 
            // DGW_PRO
            // 
            this.DGW_PRO.AllowUserToAddRows = false;
            this.DGW_PRO.AllowUserToDeleteRows = false;
            this.DGW_PRO.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGW_PRO.BackgroundColor = System.Drawing.Color.White;
            this.DGW_PRO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGW_PRO.Location = new System.Drawing.Point(53, 0);
            this.DGW_PRO.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.DGW_PRO.MultiSelect = false;
            this.DGW_PRO.Name = "DGW_PRO";
            this.DGW_PRO.ReadOnly = true;
            this.DGW_PRO.RowHeadersWidth = 25;
            this.DGW_PRO.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.DGW_PRO.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.DGW_PRO.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGW_PRO.Size = new System.Drawing.Size(426, 104);
            this.DGW_PRO.TabIndex = 11;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.Button5);
            this.GroupBox1.Controls.Add(this.TXT_DESC_PRO);
            this.GroupBox1.Controls.Add(this.K);
            this.GroupBox1.Controls.Add(this.txt_saldo);
            this.GroupBox1.Controls.Add(this.btn_modificar2);
            this.GroupBox1.Controls.Add(this.btn_cancelar);
            this.GroupBox1.Controls.Add(this.btn_guardar);
            this.GroupBox1.Controls.Add(this.TXT_COD_PRO);
            this.GroupBox1.Controls.Add(this.Label17);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Controls.Add(this.cbo_almacen);
            this.GroupBox1.Controls.Add(this.Label6);
            this.GroupBox1.Controls.Add(this.CBO_CLASE);
            this.GroupBox1.Controls.Add(this.Label5);
            this.GroupBox1.Location = new System.Drawing.Point(18, 19);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(510, 188);
            this.GroupBox1.TabIndex = 1;
            this.GroupBox1.TabStop = false;
            // 
            // Button5
            // 
            this.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button5.Location = new System.Drawing.Point(485, 80);
            this.Button5.Name = "Button5";
            this.Button5.Size = new System.Drawing.Size(15, 20);
            this.Button5.TabIndex = 116;
            this.Button5.TabStop = false;
            this.Button5.UseVisualStyleBackColor = true;
            // 
            // TXT_DESC_PRO
            // 
            this.TXT_DESC_PRO.Location = new System.Drawing.Point(213, 80);
            this.TXT_DESC_PRO.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.TXT_DESC_PRO.Name = "TXT_DESC_PRO";
            this.TXT_DESC_PRO.Size = new System.Drawing.Size(267, 20);
            this.TXT_DESC_PRO.TabIndex = 4;
            // 
            // K
            // 
            this.K.Location = new System.Drawing.Point(462, 80);
            this.K.Name = "K";
            this.K.Size = new System.Drawing.Size(12, 20);
            this.K.TabIndex = 5;
            // 
            // txt_saldo
            // 
            this.txt_saldo.Location = new System.Drawing.Point(122, 106);
            this.txt_saldo.Name = "txt_saldo";
            this.txt_saldo.Size = new System.Drawing.Size(100, 20);
            this.txt_saldo.TabIndex = 6;
            this.txt_saldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btn_modificar2
            // 
            this.btn_modificar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_modificar2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_modificar2.Location = new System.Drawing.Point(320, 151);
            this.btn_modificar2.Name = "btn_modificar2";
            this.btn_modificar2.Size = new System.Drawing.Size(77, 27);
            this.btn_modificar2.TabIndex = 7;
            this.btn_modificar2.Text = "&Modificar";
            this.btn_modificar2.UseVisualStyleBackColor = true;
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_cancelar.Location = new System.Drawing.Point(403, 151);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(77, 27);
            this.btn_cancelar.TabIndex = 8;
            this.btn_cancelar.Text = "&Cancelar";
            this.btn_cancelar.UseVisualStyleBackColor = true;
            // 
            // btn_guardar
            // 
            this.btn_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_guardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_guardar.Location = new System.Drawing.Point(320, 151);
            this.btn_guardar.Name = "btn_guardar";
            this.btn_guardar.Size = new System.Drawing.Size(77, 27);
            this.btn_guardar.TabIndex = 7;
            this.btn_guardar.Text = "&Guardar";
            this.btn_guardar.UseVisualStyleBackColor = true;
            // 
            // TXT_COD_PRO
            // 
            this.TXT_COD_PRO.Location = new System.Drawing.Point(122, 80);
            this.TXT_COD_PRO.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.TXT_COD_PRO.Name = "TXT_COD_PRO";
            this.TXT_COD_PRO.Size = new System.Drawing.Size(87, 20);
            this.TXT_COD_PRO.TabIndex = 3;
            // 
            // Label17
            // 
            this.Label17.AutoSize = true;
            this.Label17.Location = new System.Drawing.Point(23, 83);
            this.Label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label17.Name = "Label17";
            this.Label17.Size = new System.Drawing.Size(44, 14);
            this.Label17.TabIndex = 13;
            this.Label17.Text = "Articulo";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(23, 109);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(67, 14);
            this.Label1.TabIndex = 12;
            this.Label1.Text = "Saldo Actual";
            // 
            // cbo_almacen
            // 
            this.cbo_almacen.BackColor = System.Drawing.Color.White;
            this.cbo_almacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_almacen.FormattingEnabled = true;
            this.cbo_almacen.Location = new System.Drawing.Point(122, 51);
            this.cbo_almacen.Name = "cbo_almacen";
            this.cbo_almacen.Size = new System.Drawing.Size(254, 22);
            this.cbo_almacen.TabIndex = 2;
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(23, 54);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(49, 14);
            this.Label6.TabIndex = 10;
            this.Label6.Text = "Almacen";
            // 
            // CBO_CLASE
            // 
            this.CBO_CLASE.BackColor = System.Drawing.Color.White;
            this.CBO_CLASE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBO_CLASE.FormattingEnabled = true;
            this.CBO_CLASE.Location = new System.Drawing.Point(122, 23);
            this.CBO_CLASE.Name = "CBO_CLASE";
            this.CBO_CLASE.Size = new System.Drawing.Size(254, 22);
            this.CBO_CLASE.TabIndex = 1;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(23, 26);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(69, 14);
            this.Label5.TabIndex = 8;
            this.Label5.Text = "Clase de Art.";
            // 
            // M_ARTICULO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 329);
            this.Controls.Add(this.TabControl1);
            this.Name = "M_ARTICULO";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento de Saldo de Artículos";
            this.TabControl1.ResumeLayout(false);
            this.TabPage1.ResumeLayout(false);
            this.GroupBox8.ResumeLayout(false);
            this.GroupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw1)).EndInit();
            this.TabPage2.ResumeLayout(false);
            this.Panel_PRO.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGW_PRO)).EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TabControl TabControl1;
        internal System.Windows.Forms.TabPage TabPage1;
        internal System.Windows.Forms.GroupBox GroupBox8;
        internal System.Windows.Forms.RadioButton ch_rs;
        internal System.Windows.Forms.RadioButton ch_cod;
        internal System.Windows.Forms.TextBox txt_letra;
        internal System.Windows.Forms.Button btn_salir;
        internal System.Windows.Forms.Button btn_modificar;
        internal System.Windows.Forms.Button btn_nuevo;
        internal System.Windows.Forms.DataGridView dgw1;
        internal System.Windows.Forms.TabPage TabPage2;
        internal System.Windows.Forms.Panel Panel_PRO;
        internal System.Windows.Forms.DataGridView DGW_PRO;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Button Button5;
        internal System.Windows.Forms.TextBox TXT_DESC_PRO;
        internal System.Windows.Forms.TextBox K;
        internal System.Windows.Forms.TextBox txt_saldo;
        internal System.Windows.Forms.Button btn_modificar2;
        internal System.Windows.Forms.Button btn_cancelar;
        internal System.Windows.Forms.Button btn_guardar;
        internal System.Windows.Forms.TextBox TXT_COD_PRO;
        internal System.Windows.Forms.Label Label17;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.ComboBox cbo_almacen;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.ComboBox CBO_CLASE;
        internal System.Windows.Forms.Label Label5;
    }
}