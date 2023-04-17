namespace Presentacion.MOD_ADM
{
    partial class PUNTO_VENTA_CONSOLIDADOS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PUNTO_VENTA_CONSOLIDADOS));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.GroupBox8 = new System.Windows.Forms.GroupBox();
            this.btn_sgt = new System.Windows.Forms.Button();
            this.btn_buscar = new System.Windows.Forms.Button();
            this.ch_ca = new System.Windows.Forms.RadioButton();
            this.ch_cod = new System.Windows.Forms.RadioButton();
            this.txt_letra = new System.Windows.Forms.TextBox();
            this.btn_salir = new System.Windows.Forms.Button();
            this.btn_modificar = new System.Windows.Forms.Button();
            this.dgw = new System.Windows.Forms.DataGridView();
            this.TabPage2 = new System.Windows.Forms.TabPage();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.btn_modificar2 = new System.Windows.Forms.Button();
            this.TabControl2 = new System.Windows.Forms.TabControl();
            this.TabPage4 = new System.Windows.Forms.TabPage();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_cancelar31 = new System.Windows.Forms.Button();
            this.cboptocob = new System.Windows.Forms.ComboBox();
            this.btn_guardar31 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_eliminar3 = new System.Windows.Forms.Button();
            this.btn_agregar2 = new System.Windows.Forms.Button();
            this.DGW2 = new System.Windows.Forms.DataGridView();
            this.codcons = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ITEM2 = new System.Windows.Forms.TextBox();
            this.TabControl1.SuspendLayout();
            this.TabPage1.SuspendLayout();
            this.GroupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw)).BeginInit();
            this.TabPage2.SuspendLayout();
            this.TabControl2.SuspendLayout();
            this.TabPage4.SuspendLayout();
            this.Panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGW2)).BeginInit();
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
            this.TabControl1.Size = new System.Drawing.Size(622, 385);
            this.TabControl1.TabIndex = 3;
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.GroupBox8);
            this.TabPage1.Controls.Add(this.btn_salir);
            this.TabPage1.Controls.Add(this.btn_modificar);
            this.TabPage1.Controls.Add(this.dgw);
            this.TabPage1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabPage1.Location = new System.Drawing.Point(4, 23);
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage1.Size = new System.Drawing.Size(614, 358);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "Grupos de Venta";
            this.TabPage1.UseVisualStyleBackColor = true;
            // 
            // GroupBox8
            // 
            this.GroupBox8.Controls.Add(this.btn_sgt);
            this.GroupBox8.Controls.Add(this.btn_buscar);
            this.GroupBox8.Controls.Add(this.ch_ca);
            this.GroupBox8.Controls.Add(this.ch_cod);
            this.GroupBox8.Controls.Add(this.txt_letra);
            this.GroupBox8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox8.Location = new System.Drawing.Point(19, 275);
            this.GroupBox8.Name = "GroupBox8";
            this.GroupBox8.Size = new System.Drawing.Size(524, 72);
            this.GroupBox8.TabIndex = 5;
            this.GroupBox8.TabStop = false;
            this.GroupBox8.Text = "Buscado por:";
            // 
            // btn_sgt
            // 
            this.btn_sgt.Enabled = false;
            this.btn_sgt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_sgt.Font = new System.Drawing.Font("Arial", 8.25F);
            this.btn_sgt.Image = ((System.Drawing.Image)(resources.GetObject("btn_sgt.Image")));
            this.btn_sgt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_sgt.Location = new System.Drawing.Point(449, 16);
            this.btn_sgt.Name = "btn_sgt";
            this.btn_sgt.Size = new System.Drawing.Size(64, 26);
            this.btn_sgt.TabIndex = 7;
            this.btn_sgt.Text = "&Sgte.";
            this.btn_sgt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_sgt.UseVisualStyleBackColor = true;
            this.btn_sgt.Click += new System.EventHandler(this.btn_sgt_Click);
            // 
            // btn_buscar
            // 
            this.btn_buscar.Enabled = false;
            this.btn_buscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_buscar.Font = new System.Drawing.Font("Arial", 8.25F);
            this.btn_buscar.Image = ((System.Drawing.Image)(resources.GetObject("btn_buscar.Image")));
            this.btn_buscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_buscar.Location = new System.Drawing.Point(369, 16);
            this.btn_buscar.Name = "btn_buscar";
            this.btn_buscar.Size = new System.Drawing.Size(74, 26);
            this.btn_buscar.TabIndex = 1;
            this.btn_buscar.Text = "&Buscar";
            this.btn_buscar.UseVisualStyleBackColor = true;
            this.btn_buscar.Click += new System.EventHandler(this.btn_buscar_Click);
            // 
            // ch_ca
            // 
            this.ch_ca.AutoSize = true;
            this.ch_ca.Font = new System.Drawing.Font("Arial", 8.25F);
            this.ch_ca.Location = new System.Drawing.Point(369, 45);
            this.ch_ca.Name = "ch_ca";
            this.ch_ca.Size = new System.Drawing.Size(62, 18);
            this.ch_ca.TabIndex = 6;
            this.ch_ca.Text = "Cadena";
            this.ch_ca.UseVisualStyleBackColor = true;
            this.ch_ca.CheckedChanged += new System.EventHandler(this.ch_ca_CheckedChanged);
            // 
            // ch_cod
            // 
            this.ch_cod.AutoSize = true;
            this.ch_cod.Font = new System.Drawing.Font("Arial", 8.25F);
            this.ch_cod.Location = new System.Drawing.Point(6, 45);
            this.ch_cod.Name = "ch_cod";
            this.ch_cod.Size = new System.Drawing.Size(98, 18);
            this.ch_cod.TabIndex = 2;
            this.ch_cod.Text = "Punto de Venta";
            this.ch_cod.UseVisualStyleBackColor = true;
            this.ch_cod.CheckedChanged += new System.EventHandler(this.ch_cod_CheckedChanged);
            // 
            // txt_letra
            // 
            this.txt_letra.Font = new System.Drawing.Font("Arial", 8.25F);
            this.txt_letra.Location = new System.Drawing.Point(6, 19);
            this.txt_letra.Name = "txt_letra";
            this.txt_letra.Size = new System.Drawing.Size(357, 20);
            this.txt_letra.TabIndex = 0;
            this.txt_letra.TextChanged += new System.EventHandler(this.txt_letra_TextChanged);
            // 
            // btn_salir
            // 
            this.btn_salir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_salir.Image = ((System.Drawing.Image)(resources.GetObject("btn_salir.Image")));
            this.btn_salir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_salir.Location = new System.Drawing.Point(520, 138);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(85, 35);
            this.btn_salir.TabIndex = 4;
            this.btn_salir.Text = "&Salir";
            this.btn_salir.UseVisualStyleBackColor = true;
            this.btn_salir.Click += new System.EventHandler(this.btn_salir_Click);
            // 
            // btn_modificar
            // 
            this.btn_modificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_modificar.Image = ((System.Drawing.Image)(resources.GetObject("btn_modificar.Image")));
            this.btn_modificar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_modificar.Location = new System.Drawing.Point(520, 85);
            this.btn_modificar.Name = "btn_modificar";
            this.btn_modificar.Size = new System.Drawing.Size(85, 35);
            this.btn_modificar.TabIndex = 2;
            this.btn_modificar.Text = "&Vincular";
            this.btn_modificar.UseVisualStyleBackColor = true;
            this.btn_modificar.Click += new System.EventHandler(this.btn_modificar_Click);
            // 
            // dgw
            // 
            this.dgw.AllowUserToAddRows = false;
            this.dgw.AllowUserToDeleteRows = false;
            this.dgw.AllowUserToOrderColumns = true;
            this.dgw.AllowUserToResizeRows = false;
            this.dgw.BackgroundColor = System.Drawing.Color.White;
            this.dgw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgw.Location = new System.Drawing.Point(19, 22);
            this.dgw.MultiSelect = false;
            this.dgw.Name = "dgw";
            this.dgw.ReadOnly = true;
            this.dgw.RowHeadersWidth = 25;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            this.dgw.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgw.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dgw.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.dgw.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgw.Size = new System.Drawing.Size(491, 246);
            this.dgw.TabIndex = 0;
            // 
            // TabPage2
            // 
            this.TabPage2.Controls.Add(this.btn_cancelar);
            this.TabPage2.Controls.Add(this.btn_modificar2);
            this.TabPage2.Controls.Add(this.TabControl2);
            this.TabPage2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabPage2.Location = new System.Drawing.Point(4, 23);
            this.TabPage2.Name = "TabPage2";
            this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage2.Size = new System.Drawing.Size(614, 358);
            this.TabPage2.TabIndex = 1;
            this.TabPage2.Text = "Relaciones";
            this.TabPage2.UseVisualStyleBackColor = true;
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancelar.Image = ((System.Drawing.Image)(resources.GetObject("btn_cancelar.Image")));
            this.btn_cancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_cancelar.Location = new System.Drawing.Point(519, 169);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(85, 35);
            this.btn_cancelar.TabIndex = 11;
            this.btn_cancelar.Text = "&Cancelar";
            this.btn_cancelar.UseVisualStyleBackColor = true;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // btn_modificar2
            // 
            this.btn_modificar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_modificar2.Image = ((System.Drawing.Image)(resources.GetObject("btn_modificar2.Image")));
            this.btn_modificar2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_modificar2.Location = new System.Drawing.Point(519, 124);
            this.btn_modificar2.Name = "btn_modificar2";
            this.btn_modificar2.Size = new System.Drawing.Size(85, 35);
            this.btn_modificar2.TabIndex = 10;
            this.btn_modificar2.Text = "&Guardar";
            this.btn_modificar2.UseVisualStyleBackColor = true;
            this.btn_modificar2.Click += new System.EventHandler(this.btn_modificar2_Click);
            // 
            // TabControl2
            // 
            this.TabControl2.Controls.Add(this.TabPage4);
            this.TabControl2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabControl2.Location = new System.Drawing.Point(6, 30);
            this.TabControl2.Name = "TabControl2";
            this.TabControl2.SelectedIndex = 0;
            this.TabControl2.Size = new System.Drawing.Size(487, 288);
            this.TabControl2.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.TabControl2.TabIndex = 12;
            // 
            // TabPage4
            // 
            this.TabPage4.Controls.Add(this.Panel2);
            this.TabPage4.Controls.Add(this.btn_eliminar3);
            this.TabPage4.Controls.Add(this.btn_agregar2);
            this.TabPage4.Controls.Add(this.DGW2);
            this.TabPage4.Controls.Add(this.ITEM2);
            this.TabPage4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabPage4.Location = new System.Drawing.Point(4, 23);
            this.TabPage4.Name = "TabPage4";
            this.TabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage4.Size = new System.Drawing.Size(479, 261);
            this.TabPage4.TabIndex = 1;
            this.TabPage4.Text = "Ptos de Venta";
            this.TabPage4.UseVisualStyleBackColor = true;
            // 
            // Panel2
            // 
            this.Panel2.Controls.Add(this.groupBox2);
            this.Panel2.Location = new System.Drawing.Point(16, 13);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(443, 232);
            this.Panel2.TabIndex = 15;
            this.Panel2.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_cancelar31);
            this.groupBox2.Controls.Add(this.cboptocob);
            this.groupBox2.Controls.Add(this.btn_guardar31);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(18, 39);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(409, 154);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            // 
            // btn_cancelar31
            // 
            this.btn_cancelar31.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancelar31.Image = ((System.Drawing.Image)(resources.GetObject("btn_cancelar31.Image")));
            this.btn_cancelar31.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_cancelar31.Location = new System.Drawing.Point(218, 99);
            this.btn_cancelar31.Name = "btn_cancelar31";
            this.btn_cancelar31.Size = new System.Drawing.Size(77, 27);
            this.btn_cancelar31.TabIndex = 4;
            this.btn_cancelar31.Text = "&Cancelar";
            this.btn_cancelar31.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_cancelar31.UseVisualStyleBackColor = true;
            this.btn_cancelar31.Click += new System.EventHandler(this.btn_cancelar31_Click);
            // 
            // cboptocob
            // 
            this.cboptocob.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboptocob.FormattingEnabled = true;
            this.cboptocob.ItemHeight = 14;
            this.cboptocob.Location = new System.Drawing.Point(96, 24);
            this.cboptocob.Name = "cboptocob";
            this.cboptocob.Size = new System.Drawing.Size(302, 22);
            this.cboptocob.TabIndex = 1;
            // 
            // btn_guardar31
            // 
            this.btn_guardar31.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_guardar31.Image = ((System.Drawing.Image)(resources.GetObject("btn_guardar31.Image")));
            this.btn_guardar31.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_guardar31.Location = new System.Drawing.Point(122, 99);
            this.btn_guardar31.Name = "btn_guardar31";
            this.btn_guardar31.Size = new System.Drawing.Size(77, 27);
            this.btn_guardar31.TabIndex = 3;
            this.btn_guardar31.Text = "&Guardar";
            this.btn_guardar31.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_guardar31.UseVisualStyleBackColor = true;
            this.btn_guardar31.Click += new System.EventHandler(this.btn_guardar31_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 14);
            this.label5.TabIndex = 0;
            this.label5.Text = "Pto de Venta";
            // 
            // btn_eliminar3
            // 
            this.btn_eliminar3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_eliminar3.Image = ((System.Drawing.Image)(resources.GetObject("btn_eliminar3.Image")));
            this.btn_eliminar3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_eliminar3.Location = new System.Drawing.Point(348, 189);
            this.btn_eliminar3.Name = "btn_eliminar3";
            this.btn_eliminar3.Size = new System.Drawing.Size(77, 27);
            this.btn_eliminar3.TabIndex = 15;
            this.btn_eliminar3.Text = "&Eliminar";
            this.btn_eliminar3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_eliminar3.UseVisualStyleBackColor = true;
            this.btn_eliminar3.Click += new System.EventHandler(this.btn_eliminar3_Click);
            // 
            // btn_agregar2
            // 
            this.btn_agregar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_agregar2.Image = ((System.Drawing.Image)(resources.GetObject("btn_agregar2.Image")));
            this.btn_agregar2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_agregar2.Location = new System.Drawing.Point(239, 189);
            this.btn_agregar2.Name = "btn_agregar2";
            this.btn_agregar2.Size = new System.Drawing.Size(77, 27);
            this.btn_agregar2.TabIndex = 13;
            this.btn_agregar2.Text = "&Agregar";
            this.btn_agregar2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_agregar2.UseVisualStyleBackColor = true;
            this.btn_agregar2.Click += new System.EventHandler(this.btn_agregar2_Click);
            // 
            // DGW2
            // 
            this.DGW2.AllowUserToAddRows = false;
            this.DGW2.AllowUserToDeleteRows = false;
            this.DGW2.AllowUserToOrderColumns = true;
            this.DGW2.AllowUserToResizeRows = false;
            this.DGW2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGW2.BackgroundColor = System.Drawing.Color.White;
            this.DGW2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGW2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codcons,
            this.codx,
            this.descx});
            this.DGW2.Location = new System.Drawing.Point(27, 19);
            this.DGW2.MultiSelect = false;
            this.DGW2.Name = "DGW2";
            this.DGW2.ReadOnly = true;
            this.DGW2.RowHeadersWidth = 25;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            this.DGW2.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.DGW2.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.DGW2.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.DGW2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGW2.Size = new System.Drawing.Size(398, 164);
            this.DGW2.TabIndex = 10;
            this.DGW2.TabStop = false;
            // 
            // codcons
            // 
            this.codcons.HeaderText = "Column1";
            this.codcons.Name = "codcons";
            this.codcons.ReadOnly = true;
            this.codcons.Visible = false;
            // 
            // codx
            // 
            this.codx.FillWeight = 27.41117F;
            this.codx.HeaderText = "Cod";
            this.codx.Name = "codx";
            this.codx.ReadOnly = true;
            // 
            // descx
            // 
            this.descx.FillWeight = 172.5888F;
            this.descx.HeaderText = "Descripcion";
            this.descx.Name = "descx";
            this.descx.ReadOnly = true;
            // 
            // ITEM2
            // 
            this.ITEM2.Location = new System.Drawing.Point(110, 179);
            this.ITEM2.Name = "ITEM2";
            this.ITEM2.Size = new System.Drawing.Size(16, 20);
            this.ITEM2.TabIndex = 15;
            this.ITEM2.Visible = false;
            // 
            // PUNTO_VENTA_CONSOLIDADOS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 385);
            this.Controls.Add(this.TabControl1);
            this.Name = "PUNTO_VENTA_CONSOLIDADOS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RELACIONAR PUNTOS DE VENTA";
            this.Load += new System.EventHandler(this.PUNTO_VENTA_CONSOLIDADOS_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PUNTO_VENTA_CONSOLIDADOS_KeyDown);
            this.TabControl1.ResumeLayout(false);
            this.TabPage1.ResumeLayout(false);
            this.GroupBox8.ResumeLayout(false);
            this.GroupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw)).EndInit();
            this.TabPage2.ResumeLayout(false);
            this.TabControl2.ResumeLayout(false);
            this.TabPage4.ResumeLayout(false);
            this.TabPage4.PerformLayout();
            this.Panel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGW2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TabControl TabControl1;
        internal System.Windows.Forms.TabPage TabPage1;
        internal System.Windows.Forms.GroupBox GroupBox8;
        internal System.Windows.Forms.Button btn_sgt;
        internal System.Windows.Forms.Button btn_buscar;
        internal System.Windows.Forms.RadioButton ch_ca;
        internal System.Windows.Forms.RadioButton ch_cod;
        internal System.Windows.Forms.TextBox txt_letra;
        internal System.Windows.Forms.Button btn_salir;
        internal System.Windows.Forms.Button btn_modificar;
        internal System.Windows.Forms.DataGridView dgw;
        internal System.Windows.Forms.TabPage TabPage2;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.Button btn_cancelar31;
        internal System.Windows.Forms.ComboBox cboptocob;
        internal System.Windows.Forms.Button btn_guardar31;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.Button btn_cancelar;
        internal System.Windows.Forms.Button btn_modificar2;
        internal System.Windows.Forms.TabControl TabControl2;
        internal System.Windows.Forms.TabPage TabPage4;
        internal System.Windows.Forms.Button btn_eliminar3;
        internal System.Windows.Forms.Button btn_agregar2;
        internal System.Windows.Forms.DataGridView DGW2;
        private System.Windows.Forms.DataGridViewTextBoxColumn codcons;
        private System.Windows.Forms.DataGridViewTextBoxColumn codx;
        private System.Windows.Forms.DataGridViewTextBoxColumn descx;
        internal System.Windows.Forms.TextBox ITEM2;
    }
}