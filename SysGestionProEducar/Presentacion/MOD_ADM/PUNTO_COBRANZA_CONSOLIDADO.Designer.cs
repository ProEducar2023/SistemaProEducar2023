namespace Presentacion.MOD_ADM
{
    partial class PUNTO_COBRANZA_CONSOLIDADO
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
            this.item1 = new System.Windows.Forms.TextBox();
            this.btn_mod2 = new System.Windows.Forms.Button();
            this.btn_nuevo2 = new System.Windows.Forms.Button();
            this.btn_eliminar2 = new System.Windows.Forms.Button();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.Label9 = new System.Windows.Forms.Label();
            this.txt_exp = new System.Windows.Forms.TextBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.txt_dif = new System.Windows.Forms.TextBox();
            this.cbo_tipo = new System.Windows.Forms.ComboBox();
            this.Label7 = new System.Windows.Forms.Label();
            this.txt_origen = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
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
            this.Label4 = new System.Windows.Forms.Label();
            this.txtcod = new System.Windows.Forms.TextBox();
            this.txtdesc = new System.Windows.Forms.TextBox();
            this.cod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.Panel1.Location = new System.Drawing.Point(13, 119);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(503, 192);
            this.Panel1.TabIndex = 21;
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
            this.cod,
            this.desc});
            this.dgw.Location = new System.Drawing.Point(3, 6);
            this.dgw.MultiSelect = false;
            this.dgw.Name = "dgw";
            this.dgw.ReadOnly = true;
            this.dgw.RowHeadersWidth = 25;
            this.dgw.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgw.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dgw.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.dgw.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgw.Size = new System.Drawing.Size(405, 170);
            this.dgw.TabIndex = 4;
            this.dgw.TabStop = false;
            // 
            // item1
            // 
            this.item1.Location = new System.Drawing.Point(335, 135);
            this.item1.Name = "item1";
            this.item1.Size = new System.Drawing.Size(25, 20);
            this.item1.TabIndex = 15;
            this.item1.Visible = false;
            // 
            // btn_mod2
            // 
            this.btn_mod2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_mod2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_mod2.Location = new System.Drawing.Point(417, 47);
            this.btn_mod2.Name = "btn_mod2";
            this.btn_mod2.Size = new System.Drawing.Size(77, 29);
            this.btn_mod2.TabIndex = 1;
            this.btn_mod2.Text = "&Modificar";
            this.btn_mod2.UseVisualStyleBackColor = true;
            this.btn_mod2.Click += new System.EventHandler(this.btn_mod2_Click);
            // 
            // btn_nuevo2
            // 
            this.btn_nuevo2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_nuevo2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_nuevo2.Location = new System.Drawing.Point(417, 13);
            this.btn_nuevo2.Name = "btn_nuevo2";
            this.btn_nuevo2.Size = new System.Drawing.Size(77, 29);
            this.btn_nuevo2.TabIndex = 0;
            this.btn_nuevo2.Text = "&Agregar";
            this.btn_nuevo2.UseVisualStyleBackColor = true;
            this.btn_nuevo2.Click += new System.EventHandler(this.btn_nuevo2_Click);
            // 
            // btn_eliminar2
            // 
            this.btn_eliminar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_eliminar2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_eliminar2.Location = new System.Drawing.Point(417, 83);
            this.btn_eliminar2.Name = "btn_eliminar2";
            this.btn_eliminar2.Size = new System.Drawing.Size(77, 29);
            this.btn_eliminar2.TabIndex = 2;
            this.btn_eliminar2.Text = "&Eliminar";
            this.btn_eliminar2.UseVisualStyleBackColor = true;
            this.btn_eliminar2.Click += new System.EventHandler(this.btn_eliminar2_Click);
            // 
            // Panel2
            // 
            this.Panel2.Controls.Add(this.GroupBox2);
            this.Panel2.Location = new System.Drawing.Point(47, 119);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(425, 192);
            this.Panel2.TabIndex = 22;
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.Label9);
            this.GroupBox2.Controls.Add(this.txt_exp);
            this.GroupBox2.Controls.Add(this.Label8);
            this.GroupBox2.Controls.Add(this.txt_dif);
            this.GroupBox2.Controls.Add(this.cbo_tipo);
            this.GroupBox2.Controls.Add(this.Label7);
            this.GroupBox2.Controls.Add(this.txt_origen);
            this.GroupBox2.Controls.Add(this.Label3);
            this.GroupBox2.Controls.Add(this.btn_guardar2);
            this.GroupBox2.Controls.Add(this.btn_cancelar2);
            this.GroupBox2.Controls.Add(this.btn_modificar2);
            this.GroupBox2.Controls.Add(this.Label1);
            this.GroupBox2.Controls.Add(this.Label2);
            this.GroupBox2.Controls.Add(this.TXT_CUENTA);
            this.GroupBox2.Controls.Add(this.cbo_subgrupo);
            this.GroupBox2.Location = new System.Drawing.Point(6, 8);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(403, 170);
            this.GroupBox2.TabIndex = 0;
            this.GroupBox2.TabStop = false;
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Location = new System.Drawing.Point(15, 134);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(100, 13);
            this.Label9.TabIndex = 44;
            this.Label9.Text = "Cuenta Exportación";
            // 
            // txt_exp
            // 
            this.txt_exp.Location = new System.Drawing.Point(120, 127);
            this.txt_exp.MaxLength = 8;
            this.txt_exp.Name = "txt_exp";
            this.txt_exp.Size = new System.Drawing.Size(80, 20);
            this.txt_exp.TabIndex = 6;
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Location = new System.Drawing.Point(15, 108);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(80, 13);
            this.Label8.TabIndex = 42;
            this.Label8.Text = "Cuenta Diferida";
            // 
            // txt_dif
            // 
            this.txt_dif.Location = new System.Drawing.Point(120, 103);
            this.txt_dif.MaxLength = 8;
            this.txt_dif.Name = "txt_dif";
            this.txt_dif.Size = new System.Drawing.Size(80, 20);
            this.txt_dif.TabIndex = 5;
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
            "Resultado",
            "Servicio"});
            this.cbo_tipo.Location = new System.Drawing.Point(120, 53);
            this.cbo_tipo.Name = "cbo_tipo";
            this.cbo_tipo.Size = new System.Drawing.Size(80, 21);
            this.cbo_tipo.TabIndex = 2;
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(15, 56);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(28, 13);
            this.Label7.TabIndex = 40;
            this.Label7.Text = "Tipo";
            // 
            // txt_origen
            // 
            this.txt_origen.Location = new System.Drawing.Point(306, 78);
            this.txt_origen.MaxLength = 8;
            this.txt_origen.Name = "txt_origen";
            this.txt_origen.Size = new System.Drawing.Size(80, 20);
            this.txt_origen.TabIndex = 4;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(216, 82);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(75, 13);
            this.Label3.TabIndex = 39;
            this.Label3.Text = "Cuenta Origen";
            // 
            // btn_guardar2
            // 
            this.btn_guardar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_guardar2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_guardar2.Location = new System.Drawing.Point(228, 127);
            this.btn_guardar2.Name = "btn_guardar2";
            this.btn_guardar2.Size = new System.Drawing.Size(77, 29);
            this.btn_guardar2.TabIndex = 7;
            this.btn_guardar2.Text = "&Guardar";
            this.btn_guardar2.UseVisualStyleBackColor = true;
            // 
            // btn_cancelar2
            // 
            this.btn_cancelar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancelar2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_cancelar2.Location = new System.Drawing.Point(311, 127);
            this.btn_cancelar2.Name = "btn_cancelar2";
            this.btn_cancelar2.Size = new System.Drawing.Size(77, 29);
            this.btn_cancelar2.TabIndex = 8;
            this.btn_cancelar2.Text = "&Cancelar";
            this.btn_cancelar2.UseVisualStyleBackColor = true;
            this.btn_cancelar2.Click += new System.EventHandler(this.btn_cancelar2_Click);
            // 
            // btn_modificar2
            // 
            this.btn_modificar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_modificar2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_modificar2.Location = new System.Drawing.Point(228, 127);
            this.btn_modificar2.Name = "btn_modificar2";
            this.btn_modificar2.Size = new System.Drawing.Size(77, 29);
            this.btn_modificar2.TabIndex = 7;
            this.btn_modificar2.Text = "&Modificar";
            this.btn_modificar2.UseVisualStyleBackColor = true;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(15, 30);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(64, 13);
            this.Label1.TabIndex = 25;
            this.Label1.Text = "Sub - Grupo";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(15, 82);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(86, 13);
            this.Label2.TabIndex = 25;
            this.Label2.Text = "Cuenta Corriente";
            // 
            // TXT_CUENTA
            // 
            this.TXT_CUENTA.Location = new System.Drawing.Point(120, 79);
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
            this.cbo_subgrupo.Location = new System.Drawing.Point(120, 27);
            this.cbo_subgrupo.Name = "cbo_subgrupo";
            this.cbo_subgrupo.Size = new System.Drawing.Size(268, 21);
            this.cbo_subgrupo.TabIndex = 1;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.txtdesc);
            this.GroupBox1.Controls.Add(this.txtcod);
            this.GroupBox1.Controls.Add(this.btnlimpiar);
            this.GroupBox1.Controls.Add(this.btn_salir);
            this.GroupBox1.Controls.Add(this.BTN_ACEPTAR);
            this.GroupBox1.Controls.Add(this.Label6);
            this.GroupBox1.Controls.Add(this.Label4);
            this.GroupBox1.Location = new System.Drawing.Point(13, 15);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(503, 98);
            this.GroupBox1.TabIndex = 20;
            this.GroupBox1.TabStop = false;
            // 
            // btnlimpiar
            // 
            this.btnlimpiar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnlimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnlimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnlimpiar.Location = new System.Drawing.Point(342, 39);
            this.btnlimpiar.Name = "btnlimpiar";
            this.btnlimpiar.Size = new System.Drawing.Size(77, 26);
            this.btnlimpiar.TabIndex = 5;
            this.btnlimpiar.Text = "&Limpiar";
            this.btnlimpiar.UseVisualStyleBackColor = true;
            // 
            // btn_salir
            // 
            this.btn_salir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_salir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_salir.Location = new System.Drawing.Point(342, 66);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(77, 27);
            this.btn_salir.TabIndex = 6;
            this.btn_salir.Text = "&Salir";
            this.btn_salir.UseVisualStyleBackColor = true;
            // 
            // BTN_ACEPTAR
            // 
            this.BTN_ACEPTAR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_ACEPTAR.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTN_ACEPTAR.Location = new System.Drawing.Point(342, 9);
            this.BTN_ACEPTAR.Name = "BTN_ACEPTAR";
            this.BTN_ACEPTAR.Size = new System.Drawing.Size(77, 29);
            this.BTN_ACEPTAR.TabIndex = 4;
            this.BTN_ACEPTAR.Text = "&Aceptar";
            this.BTN_ACEPTAR.UseVisualStyleBackColor = true;
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(14, 15);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(40, 13);
            this.Label6.TabIndex = 25;
            this.Label6.Text = "Codigo";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(14, 43);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(63, 13);
            this.Label4.TabIndex = 20;
            this.Label4.Text = "Descripcion";
            // 
            // txtcod
            // 
            this.txtcod.Location = new System.Drawing.Point(92, 13);
            this.txtcod.MaxLength = 8;
            this.txtcod.Name = "txtcod";
            this.txtcod.Size = new System.Drawing.Size(80, 20);
            this.txtcod.TabIndex = 26;
            // 
            // txtdesc
            // 
            this.txtdesc.Location = new System.Drawing.Point(92, 39);
            this.txtdesc.MaxLength = 8;
            this.txtdesc.Name = "txtdesc";
            this.txtdesc.Size = new System.Drawing.Size(239, 20);
            this.txtdesc.TabIndex = 27;
            // 
            // cod
            // 
            this.cod.HeaderText = "Cod";
            this.cod.Name = "cod";
            this.cod.ReadOnly = true;
            this.cod.Width = 50;
            // 
            // desc
            // 
            this.desc.HeaderText = "Nombre";
            this.desc.Name = "desc";
            this.desc.ReadOnly = true;
            this.desc.Width = 300;
            // 
            // PUNTO_COBRANZA_CONSOLIDADO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 326);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.Panel2);
            this.Controls.Add(this.GroupBox1);
            this.Name = "PUNTO_COBRANZA_CONSOLIDADO";
            this.Text = "Consolidado de Cobranza";
            this.Load += new System.EventHandler(this.PUNTO_COBRANZA_CONSOLIDADO_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PUNTO_COBRANZA_CONSOLIDADO_KeyDown);
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
        internal System.Windows.Forms.TextBox item1;
        internal System.Windows.Forms.Button btn_mod2;
        internal System.Windows.Forms.Button btn_nuevo2;
        internal System.Windows.Forms.Button btn_eliminar2;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.TextBox txt_exp;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.TextBox txt_dif;
        internal System.Windows.Forms.ComboBox cbo_tipo;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.TextBox txt_origen;
        internal System.Windows.Forms.Label Label3;
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
        internal System.Windows.Forms.Label Label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn cod;
        private System.Windows.Forms.DataGridViewTextBoxColumn desc;
        internal System.Windows.Forms.TextBox txtdesc;
        internal System.Windows.Forms.TextBox txtcod;
    }
}