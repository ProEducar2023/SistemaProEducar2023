namespace Presentacion.MOD_ADM
{
    partial class CTA_INVENTARIO
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
            this.Panel1 = new System.Windows.Forms.Panel();
            this.dgw = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.item1 = new System.Windows.Forms.TextBox();
            this.btn_mod2 = new System.Windows.Forms.Button();
            this.btn_nuevo2 = new System.Windows.Forms.Button();
            this.btn_eliminar2 = new System.Windows.Forms.Button();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.txt_dif = new System.Windows.Forms.TextBox();
            this.Label10 = new System.Windows.Forms.Label();
            this.cbo_tipo = new System.Windows.Forms.ComboBox();
            this.Label7 = new System.Windows.Forms.Label();
            this.txt_origen = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.txt_destino = new System.Windows.Forms.TextBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.txt_enlace = new System.Windows.Forms.TextBox();
            this.Label9 = new System.Windows.Forms.Label();
            this.btn_guardar2 = new System.Windows.Forms.Button();
            this.btn_cancelar2 = new System.Windows.Forms.Button();
            this.btn_modificar2 = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.TXT_CUENTA = new System.Windows.Forms.TextBox();
            this.cbo_subgrupo = new System.Windows.Forms.ComboBox();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.btnlimpiar = new System.Windows.Forms.Button();
            this.btn_salir = new System.Windows.Forms.Button();
            this.BTN_ACEPTAR = new System.Windows.Forms.Button();
            this.Label6 = new System.Windows.Forms.Label();
            this.cbo_sucursal = new System.Windows.Forms.ComboBox();
            this.cbo_grupo = new System.Windows.Forms.ComboBox();
            this.cbo_clase = new System.Windows.Forms.ComboBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw)).BeginInit();
            this.Panel2.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel1
            // 
            this.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel1.Controls.Add(this.dgw);
            this.Panel1.Controls.Add(this.item1);
            this.Panel1.Controls.Add(this.btn_mod2);
            this.Panel1.Controls.Add(this.btn_nuevo2);
            this.Panel1.Controls.Add(this.btn_eliminar2);
            this.Panel1.Enabled = false;
            this.Panel1.Location = new System.Drawing.Point(6, 106);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(511, 178);
            this.Panel1.TabIndex = 18;
            // 
            // dgw
            // 
            this.dgw.AllowUserToAddRows = false;
            this.dgw.AllowUserToDeleteRows = false;
            this.dgw.AllowUserToOrderColumns = true;
            this.dgw.AllowUserToResizeRows = false;
            this.dgw.BackgroundColor = System.Drawing.Color.White;
            this.dgw.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dgw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgw.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column3,
            this.Column1,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8});
            this.dgw.Location = new System.Drawing.Point(3, 6);
            this.dgw.MultiSelect = false;
            this.dgw.Name = "dgw";
            this.dgw.ReadOnly = true;
            this.dgw.RowHeadersWidth = 25;
            this.dgw.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgw.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dgw.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.dgw.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgw.Size = new System.Drawing.Size(405, 158);
            this.dgw.TabIndex = 4;
            this.dgw.TabStop = false;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Cod";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 40;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Sub-Grupo";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 150;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Cuenta";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 90;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Origen";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Destino";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Enlace";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Tipo";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Visible = false;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Diferida";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // item1
            // 
            this.item1.Location = new System.Drawing.Point(335, 125);
            this.item1.Name = "item1";
            this.item1.Size = new System.Drawing.Size(25, 20);
            this.item1.TabIndex = 15;
            this.item1.Visible = false;
            // 
            // btn_mod2
            // 
            this.btn_mod2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_mod2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_mod2.Location = new System.Drawing.Point(417, 44);
            this.btn_mod2.Name = "btn_mod2";
            this.btn_mod2.Size = new System.Drawing.Size(77, 27);
            this.btn_mod2.TabIndex = 1;
            this.btn_mod2.Text = "&Modificar";
            this.btn_mod2.UseVisualStyleBackColor = true;
            // 
            // btn_nuevo2
            // 
            this.btn_nuevo2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_nuevo2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_nuevo2.Location = new System.Drawing.Point(417, 12);
            this.btn_nuevo2.Name = "btn_nuevo2";
            this.btn_nuevo2.Size = new System.Drawing.Size(77, 27);
            this.btn_nuevo2.TabIndex = 0;
            this.btn_nuevo2.Text = "&Agregar";
            this.btn_nuevo2.UseVisualStyleBackColor = true;
            // 
            // btn_eliminar2
            // 
            this.btn_eliminar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_eliminar2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_eliminar2.Location = new System.Drawing.Point(417, 77);
            this.btn_eliminar2.Name = "btn_eliminar2";
            this.btn_eliminar2.Size = new System.Drawing.Size(77, 27);
            this.btn_eliminar2.TabIndex = 2;
            this.btn_eliminar2.Text = "&Eliminar";
            this.btn_eliminar2.UseVisualStyleBackColor = true;
            // 
            // Panel2
            // 
            this.Panel2.Controls.Add(this.GroupBox2);
            this.Panel2.Location = new System.Drawing.Point(40, 106);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(425, 178);
            this.Panel2.TabIndex = 19;
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.txt_dif);
            this.GroupBox2.Controls.Add(this.Label10);
            this.GroupBox2.Controls.Add(this.cbo_tipo);
            this.GroupBox2.Controls.Add(this.Label7);
            this.GroupBox2.Controls.Add(this.txt_origen);
            this.GroupBox2.Controls.Add(this.Label3);
            this.GroupBox2.Controls.Add(this.txt_destino);
            this.GroupBox2.Controls.Add(this.Label8);
            this.GroupBox2.Controls.Add(this.txt_enlace);
            this.GroupBox2.Controls.Add(this.Label9);
            this.GroupBox2.Controls.Add(this.btn_guardar2);
            this.GroupBox2.Controls.Add(this.btn_cancelar2);
            this.GroupBox2.Controls.Add(this.btn_modificar2);
            this.GroupBox2.Controls.Add(this.Label1);
            this.GroupBox2.Controls.Add(this.Label2);
            this.GroupBox2.Controls.Add(this.TXT_CUENTA);
            this.GroupBox2.Controls.Add(this.cbo_subgrupo);
            this.GroupBox2.Location = new System.Drawing.Point(6, 7);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(403, 158);
            this.GroupBox2.TabIndex = 0;
            this.GroupBox2.TabStop = false;
            // 
            // txt_dif
            // 
            this.txt_dif.Location = new System.Drawing.Point(120, 121);
            this.txt_dif.MaxLength = 8;
            this.txt_dif.Name = "txt_dif";
            this.txt_dif.Size = new System.Drawing.Size(80, 20);
            this.txt_dif.TabIndex = 5;
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.Location = new System.Drawing.Point(29, 124);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(80, 13);
            this.Label10.TabIndex = 42;
            this.Label10.Text = "Cuenta Diferida";
            // 
            // cbo_tipo
            // 
            this.cbo_tipo.BackColor = System.Drawing.Color.White;
            this.cbo_tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_tipo.FormattingEnabled = true;
            this.cbo_tipo.ItemHeight = 13;
            this.cbo_tipo.Items.AddRange(new object[] {
            "Inventario",
            "Diferida",
            "Resultado"});
            this.cbo_tipo.Location = new System.Drawing.Point(120, 50);
            this.cbo_tipo.Name = "cbo_tipo";
            this.cbo_tipo.Size = new System.Drawing.Size(78, 21);
            this.cbo_tipo.TabIndex = 2;
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(29, 52);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(28, 13);
            this.Label7.TabIndex = 40;
            this.Label7.Text = "Tipo";
            // 
            // txt_origen
            // 
            this.txt_origen.Location = new System.Drawing.Point(120, 98);
            this.txt_origen.MaxLength = 8;
            this.txt_origen.Name = "txt_origen";
            this.txt_origen.Size = new System.Drawing.Size(80, 20);
            this.txt_origen.TabIndex = 4;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(29, 100);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(75, 13);
            this.Label3.TabIndex = 39;
            this.Label3.Text = "Cuenta Origen";
            // 
            // txt_destino
            // 
            this.txt_destino.Location = new System.Drawing.Point(291, 53);
            this.txt_destino.MaxLength = 8;
            this.txt_destino.Name = "txt_destino";
            this.txt_destino.Size = new System.Drawing.Size(80, 20);
            this.txt_destino.TabIndex = 6;
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Location = new System.Drawing.Point(232, 58);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(43, 13);
            this.Label8.TabIndex = 38;
            this.Label8.Text = "Destino";
            // 
            // txt_enlace
            // 
            this.txt_enlace.Location = new System.Drawing.Point(291, 77);
            this.txt_enlace.MaxLength = 8;
            this.txt_enlace.Name = "txt_enlace";
            this.txt_enlace.Size = new System.Drawing.Size(80, 20);
            this.txt_enlace.TabIndex = 7;
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Location = new System.Drawing.Point(232, 83);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(40, 13);
            this.Label9.TabIndex = 37;
            this.Label9.Text = "Enlace";
            // 
            // btn_guardar2
            // 
            this.btn_guardar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_guardar2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_guardar2.Location = new System.Drawing.Point(215, 118);
            this.btn_guardar2.Name = "btn_guardar2";
            this.btn_guardar2.Size = new System.Drawing.Size(77, 27);
            this.btn_guardar2.TabIndex = 8;
            this.btn_guardar2.Text = "&Guardar";
            this.btn_guardar2.UseVisualStyleBackColor = true;
            // 
            // btn_cancelar2
            // 
            this.btn_cancelar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancelar2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_cancelar2.Location = new System.Drawing.Point(298, 118);
            this.btn_cancelar2.Name = "btn_cancelar2";
            this.btn_cancelar2.Size = new System.Drawing.Size(77, 27);
            this.btn_cancelar2.TabIndex = 9;
            this.btn_cancelar2.Text = "&Cancelar";
            this.btn_cancelar2.UseVisualStyleBackColor = true;
            // 
            // btn_modificar2
            // 
            this.btn_modificar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_modificar2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_modificar2.Location = new System.Drawing.Point(215, 118);
            this.btn_modificar2.Name = "btn_modificar2";
            this.btn_modificar2.Size = new System.Drawing.Size(77, 27);
            this.btn_modificar2.TabIndex = 8;
            this.btn_modificar2.Text = "&Modificar";
            this.btn_modificar2.UseVisualStyleBackColor = true;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(29, 28);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(64, 13);
            this.Label1.TabIndex = 25;
            this.Label1.Text = "Sub - Grupo";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(29, 76);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(86, 13);
            this.Label2.TabIndex = 25;
            this.Label2.Text = "Cuenta Corriente";
            // 
            // TXT_CUENTA
            // 
            this.TXT_CUENTA.Location = new System.Drawing.Point(120, 75);
            this.TXT_CUENTA.MaxLength = 8;
            this.TXT_CUENTA.Name = "TXT_CUENTA";
            this.TXT_CUENTA.Size = new System.Drawing.Size(80, 20);
            this.TXT_CUENTA.TabIndex = 3;
            // 
            // cbo_subgrupo
            // 
            this.cbo_subgrupo.BackColor = System.Drawing.Color.White;
            this.cbo_subgrupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_subgrupo.Enabled = false;
            this.cbo_subgrupo.FormattingEnabled = true;
            this.cbo_subgrupo.ItemHeight = 13;
            this.cbo_subgrupo.Location = new System.Drawing.Point(120, 25);
            this.cbo_subgrupo.Name = "cbo_subgrupo";
            this.cbo_subgrupo.Size = new System.Drawing.Size(251, 21);
            this.cbo_subgrupo.TabIndex = 1;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.btnlimpiar);
            this.GroupBox1.Controls.Add(this.btn_salir);
            this.GroupBox1.Controls.Add(this.BTN_ACEPTAR);
            this.GroupBox1.Controls.Add(this.Label6);
            this.GroupBox1.Controls.Add(this.cbo_sucursal);
            this.GroupBox1.Controls.Add(this.cbo_grupo);
            this.GroupBox1.Controls.Add(this.cbo_clase);
            this.GroupBox1.Controls.Add(this.Label5);
            this.GroupBox1.Controls.Add(this.Label4);
            this.GroupBox1.Location = new System.Drawing.Point(40, 9);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(442, 91);
            this.GroupBox1.TabIndex = 17;
            this.GroupBox1.TabStop = false;
            // 
            // btnlimpiar
            // 
            this.btnlimpiar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnlimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnlimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnlimpiar.Location = new System.Drawing.Point(342, 36);
            this.btnlimpiar.Name = "btnlimpiar";
            this.btnlimpiar.Size = new System.Drawing.Size(77, 24);
            this.btnlimpiar.TabIndex = 5;
            this.btnlimpiar.Text = "&Limpiar";
            this.btnlimpiar.UseVisualStyleBackColor = true;
            // 
            // btn_salir
            // 
            this.btn_salir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_salir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_salir.Location = new System.Drawing.Point(342, 61);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(77, 25);
            this.btn_salir.TabIndex = 6;
            this.btn_salir.Text = "&Salir";
            this.btn_salir.UseVisualStyleBackColor = true;
            // 
            // BTN_ACEPTAR
            // 
            this.BTN_ACEPTAR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_ACEPTAR.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTN_ACEPTAR.Location = new System.Drawing.Point(342, 8);
            this.BTN_ACEPTAR.Name = "BTN_ACEPTAR";
            this.BTN_ACEPTAR.Size = new System.Drawing.Size(77, 27);
            this.BTN_ACEPTAR.TabIndex = 4;
            this.BTN_ACEPTAR.Text = "&Aceptar";
            this.BTN_ACEPTAR.UseVisualStyleBackColor = true;
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(14, 14);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(48, 13);
            this.Label6.TabIndex = 25;
            this.Label6.Text = "Sucursal";
            // 
            // cbo_sucursal
            // 
            this.cbo_sucursal.BackColor = System.Drawing.Color.White;
            this.cbo_sucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_sucursal.FormattingEnabled = true;
            this.cbo_sucursal.Location = new System.Drawing.Point(70, 11);
            this.cbo_sucursal.Name = "cbo_sucursal";
            this.cbo_sucursal.Size = new System.Drawing.Size(249, 21);
            this.cbo_sucursal.TabIndex = 1;
            // 
            // cbo_grupo
            // 
            this.cbo_grupo.BackColor = System.Drawing.Color.White;
            this.cbo_grupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_grupo.Enabled = false;
            this.cbo_grupo.FormattingEnabled = true;
            this.cbo_grupo.ItemHeight = 13;
            this.cbo_grupo.Location = new System.Drawing.Point(70, 63);
            this.cbo_grupo.Name = "cbo_grupo";
            this.cbo_grupo.Size = new System.Drawing.Size(250, 21);
            this.cbo_grupo.TabIndex = 3;
            // 
            // cbo_clase
            // 
            this.cbo_clase.BackColor = System.Drawing.Color.White;
            this.cbo_clase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_clase.FormattingEnabled = true;
            this.cbo_clase.Location = new System.Drawing.Point(70, 37);
            this.cbo_clase.Name = "cbo_clase";
            this.cbo_clase.Size = new System.Drawing.Size(249, 21);
            this.cbo_clase.TabIndex = 2;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(14, 66);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(36, 13);
            this.Label5.TabIndex = 21;
            this.Label5.Text = "Grupo";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(14, 40);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(33, 13);
            this.Label4.TabIndex = 20;
            this.Label4.Text = "Clase";
            // 
            // CTA_INVENTARIO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 293);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.Panel2);
            this.Controls.Add(this.GroupBox1);
            this.Name = "CTA_INVENTARIO";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cuenta Contable - Inventario";
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw)).EndInit();
            this.Panel2.ResumeLayout(false);
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.DataGridView dgw;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        internal System.Windows.Forms.TextBox item1;
        internal System.Windows.Forms.Button btn_mod2;
        internal System.Windows.Forms.Button btn_nuevo2;
        internal System.Windows.Forms.Button btn_eliminar2;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.TextBox txt_dif;
        internal System.Windows.Forms.Label Label10;
        internal System.Windows.Forms.ComboBox cbo_tipo;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.TextBox txt_origen;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox txt_destino;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.TextBox txt_enlace;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.Button btn_guardar2;
        internal System.Windows.Forms.Button btn_cancelar2;
        internal System.Windows.Forms.Button btn_modificar2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox TXT_CUENTA;
        internal System.Windows.Forms.ComboBox cbo_subgrupo;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Button btnlimpiar;
        internal System.Windows.Forms.Button btn_salir;
        internal System.Windows.Forms.Button BTN_ACEPTAR;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.ComboBox cbo_sucursal;
        internal System.Windows.Forms.ComboBox cbo_grupo;
        internal System.Windows.Forms.ComboBox cbo_clase;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label4;
    }
}