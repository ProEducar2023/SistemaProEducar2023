namespace Presentacion.MOD_ADM
{
    partial class EQUIPO_VENTA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EQUIPO_VENTA));
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.GroupBox8 = new System.Windows.Forms.GroupBox();
            this.btn_sgt = new System.Windows.Forms.Button();
            this.btn_buscar = new System.Windows.Forms.Button();
            this.ch_ca = new System.Windows.Forms.RadioButton();
            this.ch_rs = new System.Windows.Forms.RadioButton();
            this.ch_cod = new System.Windows.Forms.RadioButton();
            this.txt_letra = new System.Windows.Forms.TextBox();
            this.btn_salir = new System.Windows.Forms.Button();
            this.btn_modificar = new System.Windows.Forms.Button();
            this.dgw1 = new System.Windows.Forms.DataGridView();
            this.TabPage2 = new System.Windows.Forms.TabPage();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.TabControl2 = new System.Windows.Forms.TabControl();
            this.TabPage3 = new System.Windows.Forms.TabPage();
            this.Panel_v0 = new System.Windows.Forms.Panel();
            this.dgw = new System.Windows.Forms.DataGridView();
            this.codcc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cargocc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_eliminar2 = new System.Windows.Forms.Button();
            this.btn_nuevo2 = new System.Windows.Forms.Button();
            this.Panel_v1 = new System.Windows.Forms.Panel();
            this.GroupBox5 = new System.Windows.Forms.GroupBox();
            this.btn_cancelar2 = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.btn_guardar2 = new System.Windows.Forms.Button();
            this.cbo_cargo = new System.Windows.Forms.ComboBox();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.txt_NRO_DOC = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.txt_desc = new System.Windows.Forms.TextBox();
            this.txt_cod = new System.Windows.Forms.TextBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.cod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nrodoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cargo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COD_CARGO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESC_CARGO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TabControl1.SuspendLayout();
            this.TabPage1.SuspendLayout();
            this.GroupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw1)).BeginInit();
            this.TabPage2.SuspendLayout();
            this.TabControl2.SuspendLayout();
            this.TabPage3.SuspendLayout();
            this.Panel_v0.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw)).BeginInit();
            this.Panel_v1.SuspendLayout();
            this.GroupBox5.SuspendLayout();
            this.GroupBox2.SuspendLayout();
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
            this.TabControl1.Size = new System.Drawing.Size(707, 390);
            this.TabControl1.TabIndex = 1;
            this.TabControl1.SelectedIndexChanged += new System.EventHandler(this.TabControl1_SelectedIndexChanged);
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.GroupBox8);
            this.TabPage1.Controls.Add(this.btn_salir);
            this.TabPage1.Controls.Add(this.btn_modificar);
            this.TabPage1.Controls.Add(this.dgw1);
            this.TabPage1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabPage1.Location = new System.Drawing.Point(4, 23);
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage1.Size = new System.Drawing.Size(699, 363);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "Lista de Usuarios";
            this.TabPage1.UseVisualStyleBackColor = true;
            // 
            // GroupBox8
            // 
            this.GroupBox8.Controls.Add(this.btn_sgt);
            this.GroupBox8.Controls.Add(this.btn_buscar);
            this.GroupBox8.Controls.Add(this.ch_ca);
            this.GroupBox8.Controls.Add(this.ch_rs);
            this.GroupBox8.Controls.Add(this.ch_cod);
            this.GroupBox8.Controls.Add(this.txt_letra);
            this.GroupBox8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox8.Location = new System.Drawing.Point(17, 289);
            this.GroupBox8.Name = "GroupBox8";
            this.GroupBox8.Size = new System.Drawing.Size(577, 65);
            this.GroupBox8.TabIndex = 10;
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
            this.btn_sgt.Location = new System.Drawing.Point(373, 16);
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
            this.btn_buscar.Location = new System.Drawing.Point(293, 16);
            this.btn_buscar.Name = "btn_buscar";
            this.btn_buscar.Size = new System.Drawing.Size(74, 26);
            this.btn_buscar.TabIndex = 1;
            this.btn_buscar.Text = "&Buscar";
            this.btn_buscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_buscar.UseVisualStyleBackColor = true;
            this.btn_buscar.Click += new System.EventHandler(this.btn_buscar_Click);
            // 
            // ch_ca
            // 
            this.ch_ca.AutoSize = true;
            this.ch_ca.Font = new System.Drawing.Font("Arial", 8.25F);
            this.ch_ca.Location = new System.Drawing.Point(292, 45);
            this.ch_ca.Name = "ch_ca";
            this.ch_ca.Size = new System.Drawing.Size(62, 18);
            this.ch_ca.TabIndex = 6;
            this.ch_ca.Text = "Cadena";
            this.ch_ca.UseVisualStyleBackColor = true;
            this.ch_ca.CheckedChanged += new System.EventHandler(this.ch_ca_CheckedChanged);
            // 
            // ch_rs
            // 
            this.ch_rs.AutoSize = true;
            this.ch_rs.Font = new System.Drawing.Font("Arial", 8.25F);
            this.ch_rs.Location = new System.Drawing.Point(105, 45);
            this.ch_rs.Name = "ch_rs";
            this.ch_rs.Size = new System.Drawing.Size(62, 18);
            this.ch_rs.TabIndex = 3;
            this.ch_rs.Text = "Nombre";
            this.ch_rs.UseVisualStyleBackColor = true;
            this.ch_rs.CheckedChanged += new System.EventHandler(this.ch_rs_CheckedChanged);
            // 
            // ch_cod
            // 
            this.ch_cod.AutoSize = true;
            this.ch_cod.Font = new System.Drawing.Font("Arial", 8.25F);
            this.ch_cod.Location = new System.Drawing.Point(6, 45);
            this.ch_cod.Name = "ch_cod";
            this.ch_cod.Size = new System.Drawing.Size(58, 18);
            this.ch_cod.TabIndex = 2;
            this.ch_cod.Text = "Código";
            this.ch_cod.UseVisualStyleBackColor = true;
            this.ch_cod.CheckedChanged += new System.EventHandler(this.ch_cod_CheckedChanged);
            // 
            // txt_letra
            // 
            this.txt_letra.Font = new System.Drawing.Font("Arial", 8.25F);
            this.txt_letra.Location = new System.Drawing.Point(6, 19);
            this.txt_letra.Name = "txt_letra";
            this.txt_letra.Size = new System.Drawing.Size(275, 20);
            this.txt_letra.TabIndex = 0;
            this.txt_letra.TextChanged += new System.EventHandler(this.txt_letra_TextChanged);
            // 
            // btn_salir
            // 
            this.btn_salir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_salir.Image = ((System.Drawing.Image)(resources.GetObject("btn_salir.Image")));
            this.btn_salir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_salir.Location = new System.Drawing.Point(604, 56);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(85, 35);
            this.btn_salir.TabIndex = 9;
            this.btn_salir.Text = "&Salir";
            this.btn_salir.UseVisualStyleBackColor = true;
            this.btn_salir.Click += new System.EventHandler(this.btn_salir_Click);
            // 
            // btn_modificar
            // 
            this.btn_modificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_modificar.Image = ((System.Drawing.Image)(resources.GetObject("btn_modificar.Image")));
            this.btn_modificar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_modificar.Location = new System.Drawing.Point(604, 15);
            this.btn_modificar.Name = "btn_modificar";
            this.btn_modificar.Size = new System.Drawing.Size(85, 35);
            this.btn_modificar.TabIndex = 7;
            this.btn_modificar.Text = "&Modificar";
            this.btn_modificar.UseVisualStyleBackColor = true;
            this.btn_modificar.Click += new System.EventHandler(this.btn_modificar_Click);
            // 
            // dgw1
            // 
            this.dgw1.AllowUserToAddRows = false;
            this.dgw1.AllowUserToDeleteRows = false;
            this.dgw1.AllowUserToOrderColumns = true;
            this.dgw1.AllowUserToResizeRows = false;
            this.dgw1.BackgroundColor = System.Drawing.Color.White;
            this.dgw1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgw1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cod,
            this.nom,
            this.nrodoc,
            this.codc,
            this.cargo,
            this.COD_CARGO,
            this.DESC_CARGO});
            this.dgw1.Location = new System.Drawing.Point(17, 15);
            this.dgw1.MultiSelect = false;
            this.dgw1.Name = "dgw1";
            this.dgw1.ReadOnly = true;
            this.dgw1.RowHeadersWidth = 25;
            this.dgw1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dgw1.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.dgw1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgw1.Size = new System.Drawing.Size(577, 268);
            this.dgw1.TabIndex = 0;
            // 
            // TabPage2
            // 
            this.TabPage2.Controls.Add(this.btn_cancelar);
            this.TabPage2.Controls.Add(this.TabControl2);
            this.TabPage2.Controls.Add(this.GroupBox2);
            this.TabPage2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabPage2.Location = new System.Drawing.Point(4, 23);
            this.TabPage2.Name = "TabPage2";
            this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage2.Size = new System.Drawing.Size(699, 363);
            this.TabPage2.TabIndex = 1;
            this.TabPage2.Text = "Detalles";
            this.TabPage2.UseVisualStyleBackColor = true;
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancelar.Image = ((System.Drawing.Image)(resources.GetObject("btn_cancelar.Image")));
            this.btn_cancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_cancelar.Location = new System.Drawing.Point(588, 223);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(85, 35);
            this.btn_cancelar.TabIndex = 15;
            this.btn_cancelar.TabStop = false;
            this.btn_cancelar.Text = "&Cancelar";
            this.btn_cancelar.UseVisualStyleBackColor = true;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // TabControl2
            // 
            this.TabControl2.Controls.Add(this.TabPage3);
            this.TabControl2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabControl2.ItemSize = new System.Drawing.Size(450, 19);
            this.TabControl2.Location = new System.Drawing.Point(10, 99);
            this.TabControl2.Name = "TabControl2";
            this.TabControl2.SelectedIndex = 0;
            this.TabControl2.Size = new System.Drawing.Size(557, 256);
            this.TabControl2.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.TabControl2.TabIndex = 12;
            this.TabControl2.TabStop = false;
            // 
            // TabPage3
            // 
            this.TabPage3.Controls.Add(this.Panel_v0);
            this.TabPage3.Controls.Add(this.Panel_v1);
            this.TabPage3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabPage3.Location = new System.Drawing.Point(4, 23);
            this.TabPage3.Name = "TabPage3";
            this.TabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage3.Size = new System.Drawing.Size(549, 229);
            this.TabPage3.TabIndex = 0;
            this.TabPage3.Text = "Cargos";
            this.TabPage3.UseVisualStyleBackColor = true;
            this.TabPage3.Click += new System.EventHandler(this.TabPage3_Click);
            // 
            // Panel_v0
            // 
            this.Panel_v0.Controls.Add(this.dgw);
            this.Panel_v0.Controls.Add(this.btn_eliminar2);
            this.Panel_v0.Controls.Add(this.btn_nuevo2);
            this.Panel_v0.Location = new System.Drawing.Point(0, 2);
            this.Panel_v0.Name = "Panel_v0";
            this.Panel_v0.Size = new System.Drawing.Size(549, 224);
            this.Panel_v0.TabIndex = 14;
            // 
            // dgw
            // 
            this.dgw.AllowUserToAddRows = false;
            this.dgw.AllowUserToDeleteRows = false;
            this.dgw.AllowUserToOrderColumns = true;
            this.dgw.AllowUserToResizeRows = false;
            this.dgw.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgw.BackgroundColor = System.Drawing.Color.White;
            this.dgw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgw.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codcc,
            this.cargocc});
            this.dgw.Location = new System.Drawing.Point(31, 36);
            this.dgw.MultiSelect = false;
            this.dgw.Name = "dgw";
            this.dgw.ReadOnly = true;
            this.dgw.RowHeadersWidth = 25;
            this.dgw.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dgw.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.dgw.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgw.Size = new System.Drawing.Size(366, 135);
            this.dgw.TabIndex = 0;
            // 
            // codcc
            // 
            this.codcc.FillWeight = 30.45685F;
            this.codcc.HeaderText = "Cod";
            this.codcc.Name = "codcc";
            this.codcc.ReadOnly = true;
            // 
            // cargocc
            // 
            this.cargocc.FillWeight = 169.5432F;
            this.cargocc.HeaderText = "Cargo";
            this.cargocc.MinimumWidth = 150;
            this.cargocc.Name = "cargocc";
            this.cargocc.ReadOnly = true;
            // 
            // btn_eliminar2
            // 
            this.btn_eliminar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_eliminar2.Image = ((System.Drawing.Image)(resources.GetObject("btn_eliminar2.Image")));
            this.btn_eliminar2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_eliminar2.Location = new System.Drawing.Point(426, 71);
            this.btn_eliminar2.Name = "btn_eliminar2";
            this.btn_eliminar2.Size = new System.Drawing.Size(77, 27);
            this.btn_eliminar2.TabIndex = 3;
            this.btn_eliminar2.Text = "&Eliminar";
            this.btn_eliminar2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_eliminar2.UseVisualStyleBackColor = true;
            this.btn_eliminar2.Click += new System.EventHandler(this.btn_eliminar2_Click);
            // 
            // btn_nuevo2
            // 
            this.btn_nuevo2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_nuevo2.Image = ((System.Drawing.Image)(resources.GetObject("btn_nuevo2.Image")));
            this.btn_nuevo2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_nuevo2.Location = new System.Drawing.Point(426, 38);
            this.btn_nuevo2.Name = "btn_nuevo2";
            this.btn_nuevo2.Size = new System.Drawing.Size(77, 27);
            this.btn_nuevo2.TabIndex = 1;
            this.btn_nuevo2.Text = "&Agregar";
            this.btn_nuevo2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_nuevo2.UseVisualStyleBackColor = true;
            this.btn_nuevo2.Click += new System.EventHandler(this.btn_nuevo2_Click);
            // 
            // Panel_v1
            // 
            this.Panel_v1.Controls.Add(this.GroupBox5);
            this.Panel_v1.Location = new System.Drawing.Point(18, 6);
            this.Panel_v1.Name = "Panel_v1";
            this.Panel_v1.Size = new System.Drawing.Size(528, 217);
            this.Panel_v1.TabIndex = 0;
            this.Panel_v1.Visible = false;
            // 
            // GroupBox5
            // 
            this.GroupBox5.Controls.Add(this.btn_cancelar2);
            this.GroupBox5.Controls.Add(this.Label1);
            this.GroupBox5.Controls.Add(this.btn_guardar2);
            this.GroupBox5.Controls.Add(this.cbo_cargo);
            this.GroupBox5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox5.Location = new System.Drawing.Point(13, 12);
            this.GroupBox5.Name = "GroupBox5";
            this.GroupBox5.Size = new System.Drawing.Size(499, 191);
            this.GroupBox5.TabIndex = 16;
            this.GroupBox5.TabStop = false;
            // 
            // btn_cancelar2
            // 
            this.btn_cancelar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancelar2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancelar2.Image = ((System.Drawing.Image)(resources.GetObject("btn_cancelar2.Image")));
            this.btn_cancelar2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_cancelar2.Location = new System.Drawing.Point(347, 113);
            this.btn_cancelar2.Name = "btn_cancelar2";
            this.btn_cancelar2.Size = new System.Drawing.Size(77, 27);
            this.btn_cancelar2.TabIndex = 4;
            this.btn_cancelar2.Text = "&Cancelar";
            this.btn_cancelar2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_cancelar2.UseVisualStyleBackColor = true;
            this.btn_cancelar2.Click += new System.EventHandler(this.btn_cancelar2_Click);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(76, 44);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(36, 14);
            this.Label1.TabIndex = 8;
            this.Label1.Text = "Cargo";
            // 
            // btn_guardar2
            // 
            this.btn_guardar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_guardar2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_guardar2.Image = ((System.Drawing.Image)(resources.GetObject("btn_guardar2.Image")));
            this.btn_guardar2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_guardar2.Location = new System.Drawing.Point(264, 113);
            this.btn_guardar2.Name = "btn_guardar2";
            this.btn_guardar2.Size = new System.Drawing.Size(77, 27);
            this.btn_guardar2.TabIndex = 3;
            this.btn_guardar2.Text = "&Guardar";
            this.btn_guardar2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_guardar2.UseVisualStyleBackColor = true;
            this.btn_guardar2.Click += new System.EventHandler(this.btn_guardar2_Click);
            // 
            // cbo_cargo
            // 
            this.cbo_cargo.BackColor = System.Drawing.Color.White;
            this.cbo_cargo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_cargo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_cargo.FormattingEnabled = true;
            this.cbo_cargo.Items.AddRange(new object[] {
            "01 REQUISION",
            "02 ORDEN DE COMPRA",
            "03 NOTA DE PEDIDO",
            "04 VENDEDOR",
            "05 COBRADOR",
            "06 ALMACENERO"});
            this.cbo_cargo.Location = new System.Drawing.Point(156, 41);
            this.cbo_cargo.Name = "cbo_cargo";
            this.cbo_cargo.Size = new System.Drawing.Size(200, 22);
            this.cbo_cargo.TabIndex = 2;
            this.cbo_cargo.SelectedIndexChanged += new System.EventHandler(this.cbo_cargo_SelectedIndexChanged);
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.txt_NRO_DOC);
            this.GroupBox2.Controls.Add(this.Label2);
            this.GroupBox2.Controls.Add(this.txt_desc);
            this.GroupBox2.Controls.Add(this.txt_cod);
            this.GroupBox2.Controls.Add(this.Label6);
            this.GroupBox2.Controls.Add(this.Label5);
            this.GroupBox2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox2.Location = new System.Drawing.Point(10, 10);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(647, 80);
            this.GroupBox2.TabIndex = 2;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Datos del Trabajador";
            this.GroupBox2.Enter += new System.EventHandler(this.GroupBox2_Enter);
            // 
            // txt_NRO_DOC
            // 
            this.txt_NRO_DOC.BackColor = System.Drawing.Color.White;
            this.txt_NRO_DOC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_NRO_DOC.Enabled = false;
            this.txt_NRO_DOC.Font = new System.Drawing.Font("Arial", 8.25F);
            this.txt_NRO_DOC.Location = new System.Drawing.Point(407, 22);
            this.txt_NRO_DOC.MaxLength = 20;
            this.txt_NRO_DOC.Name = "txt_NRO_DOC";
            this.txt_NRO_DOC.Size = new System.Drawing.Size(150, 20);
            this.txt_NRO_DOC.TabIndex = 2;
            this.txt_NRO_DOC.TabStop = false;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Arial", 8.25F);
            this.Label2.Location = new System.Drawing.Point(325, 25);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(76, 14);
            this.Label2.TabIndex = 5;
            this.Label2.Text = "Nº Documento";
            // 
            // txt_desc
            // 
            this.txt_desc.BackColor = System.Drawing.Color.White;
            this.txt_desc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_desc.Enabled = false;
            this.txt_desc.Font = new System.Drawing.Font("Arial", 8.25F);
            this.txt_desc.Location = new System.Drawing.Point(67, 48);
            this.txt_desc.MaxLength = 60;
            this.txt_desc.Name = "txt_desc";
            this.txt_desc.Size = new System.Drawing.Size(490, 20);
            this.txt_desc.TabIndex = 3;
            this.txt_desc.TabStop = false;
            // 
            // txt_cod
            // 
            this.txt_cod.BackColor = System.Drawing.Color.White;
            this.txt_cod.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_cod.Enabled = false;
            this.txt_cod.Font = new System.Drawing.Font("Arial", 8.25F);
            this.txt_cod.Location = new System.Drawing.Point(67, 22);
            this.txt_cod.MaxLength = 5;
            this.txt_cod.Name = "txt_cod";
            this.txt_cod.Size = new System.Drawing.Size(60, 20);
            this.txt_cod.TabIndex = 1;
            this.txt_cod.TabStop = false;
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Font = new System.Drawing.Font("Arial", 8.25F);
            this.Label6.Location = new System.Drawing.Point(9, 51);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(44, 14);
            this.Label6.TabIndex = 1;
            this.Label6.Text = "Nombre";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Arial", 8.25F);
            this.Label5.Location = new System.Drawing.Point(9, 25);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(40, 14);
            this.Label5.TabIndex = 0;
            this.Label5.Text = "Codigo";
            // 
            // cod
            // 
            this.cod.FillWeight = 27.44528F;
            this.cod.HeaderText = "Codigo";
            this.cod.Name = "cod";
            this.cod.ReadOnly = true;
            this.cod.Width = 70;
            // 
            // nom
            // 
            this.nom.FillWeight = 65.29039F;
            this.nom.HeaderText = "Nombre";
            this.nom.Name = "nom";
            this.nom.ReadOnly = true;
            this.nom.Width = 240;
            // 
            // nrodoc
            // 
            this.nrodoc.FillWeight = 144.5231F;
            this.nrodoc.HeaderText = "Nro Doc";
            this.nrodoc.Name = "nrodoc";
            this.nrodoc.ReadOnly = true;
            this.nrodoc.Width = 80;
            // 
            // codc
            // 
            this.codc.HeaderText = "codc";
            this.codc.Name = "codc";
            this.codc.ReadOnly = true;
            this.codc.Visible = false;
            // 
            // cargo
            // 
            this.cargo.HeaderText = "cargo";
            this.cargo.Name = "cargo";
            this.cargo.ReadOnly = true;
            this.cargo.Visible = false;
            // 
            // COD_CARGO
            // 
            this.COD_CARGO.HeaderText = "COD_CARGO";
            this.COD_CARGO.Name = "COD_CARGO";
            this.COD_CARGO.ReadOnly = true;
            this.COD_CARGO.Visible = false;
            // 
            // DESC_CARGO
            // 
            this.DESC_CARGO.HeaderText = "Cargo";
            this.DESC_CARGO.Name = "DESC_CARGO";
            this.DESC_CARGO.ReadOnly = true;
            this.DESC_CARGO.Width = 140;
            // 
            // EQUIPO_VENTA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 390);
            this.Controls.Add(this.TabControl1);
            this.Name = "EQUIPO_VENTA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento de Usuarios - Cargos";
            this.Load += new System.EventHandler(this.EQUIPO_VENTA_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EQUIPO_VENTA_KeyDown);
            this.TabControl1.ResumeLayout(false);
            this.TabPage1.ResumeLayout(false);
            this.GroupBox8.ResumeLayout(false);
            this.GroupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw1)).EndInit();
            this.TabPage2.ResumeLayout(false);
            this.TabControl2.ResumeLayout(false);
            this.TabPage3.ResumeLayout(false);
            this.Panel_v0.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgw)).EndInit();
            this.Panel_v1.ResumeLayout(false);
            this.GroupBox5.ResumeLayout(false);
            this.GroupBox5.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TabControl TabControl1;
        internal System.Windows.Forms.TabPage TabPage1;
        internal System.Windows.Forms.GroupBox GroupBox8;
        internal System.Windows.Forms.Button btn_sgt;
        internal System.Windows.Forms.Button btn_buscar;
        internal System.Windows.Forms.RadioButton ch_ca;
        internal System.Windows.Forms.RadioButton ch_rs;
        internal System.Windows.Forms.RadioButton ch_cod;
        internal System.Windows.Forms.TextBox txt_letra;
        internal System.Windows.Forms.Button btn_salir;
        internal System.Windows.Forms.Button btn_modificar;
        internal System.Windows.Forms.DataGridView dgw1;
        internal System.Windows.Forms.TabPage TabPage2;
        internal System.Windows.Forms.Button btn_cancelar;
        internal System.Windows.Forms.TabControl TabControl2;
        internal System.Windows.Forms.TabPage TabPage3;
        internal System.Windows.Forms.Panel Panel_v0;
        internal System.Windows.Forms.DataGridView dgw;
        internal System.Windows.Forms.Button btn_eliminar2;
        internal System.Windows.Forms.Button btn_nuevo2;
        internal System.Windows.Forms.Panel Panel_v1;
        internal System.Windows.Forms.GroupBox GroupBox5;
        internal System.Windows.Forms.Button btn_cancelar2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Button btn_guardar2;
        internal System.Windows.Forms.ComboBox cbo_cargo;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.TextBox txt_NRO_DOC;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox txt_desc;
        internal System.Windows.Forms.TextBox txt_cod;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label Label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn codcc;
        private System.Windows.Forms.DataGridViewTextBoxColumn cargocc;
        private System.Windows.Forms.DataGridViewTextBoxColumn cod;
        private System.Windows.Forms.DataGridViewTextBoxColumn nom;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrodoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn codc;
        private System.Windows.Forms.DataGridViewTextBoxColumn cargo;
        private System.Windows.Forms.DataGridViewTextBoxColumn COD_CARGO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESC_CARGO;
    }
}