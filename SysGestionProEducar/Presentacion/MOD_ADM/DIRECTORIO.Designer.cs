namespace Presentacion.MOD_ADM
{
    partial class DIRECTORIO
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DIRECTORIO));
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.btn_salir = new System.Windows.Forms.Button();
            this.btn_eliminar = new System.Windows.Forms.Button();
            this.btn_modificar = new System.Windows.Forms.Button();
            this.btn_nuevo = new System.Windows.Forms.Button();
            this.dgw1 = new System.Windows.Forms.DataGridView();
            this.TabPage2 = new System.Windows.Forms.TabPage();
            this.BTN_CANCELAR = new System.Windows.Forms.Button();
            this.TabControl2 = new System.Windows.Forms.TabControl();
            this.TabPage3 = new System.Windows.Forms.TabPage();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.GroupBox5 = new System.Windows.Forms.GroupBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.TXT_DESC_det = new System.Windows.Forms.TextBox();
            this.btn_cancelar2 = new System.Windows.Forms.Button();
            this.btn_modificar2 = new System.Windows.Forms.Button();
            this.TXT_COD_det = new System.Windows.Forms.TextBox();
            this.btn_guardar2 = new System.Windows.Forms.Button();
            this.txt_obs_det = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label14 = new System.Windows.Forms.Label();
            this.dgw = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.item1 = new System.Windows.Forms.TextBox();
            this.btn_nuevo2 = new System.Windows.Forms.Button();
            this.btn_eliminar2 = new System.Windows.Forms.Button();
            this.btn_mod2 = new System.Windows.Forms.Button();
            this.j1 = new System.Windows.Forms.GroupBox();
            this.nup_obs = new System.Windows.Forms.NumericUpDown();
            this.Label1 = new System.Windows.Forms.Label();
            this.txt_desc = new System.Windows.Forms.TextBox();
            this.txt_cod = new System.Windows.Forms.TextBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.TabControl1.SuspendLayout();
            this.TabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw1)).BeginInit();
            this.TabPage2.SuspendLayout();
            this.TabControl2.SuspendLayout();
            this.TabPage3.SuspendLayout();
            this.Panel1.SuspendLayout();
            this.Panel2.SuspendLayout();
            this.GroupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw)).BeginInit();
            this.j1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nup_obs)).BeginInit();
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
            this.TabControl1.Size = new System.Drawing.Size(543, 323);
            this.TabControl1.TabIndex = 1;
            this.TabControl1.SelectedIndexChanged += new System.EventHandler(this.TabControl1_SelectedIndexChanged);
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.btn_salir);
            this.TabPage1.Controls.Add(this.btn_eliminar);
            this.TabPage1.Controls.Add(this.btn_modificar);
            this.TabPage1.Controls.Add(this.btn_nuevo);
            this.TabPage1.Controls.Add(this.dgw1);
            this.TabPage1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabPage1.Location = new System.Drawing.Point(4, 23);
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage1.Size = new System.Drawing.Size(535, 296);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "Lista de Tablas";
            this.TabPage1.UseVisualStyleBackColor = true;
            // 
            // btn_salir
            // 
            this.btn_salir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_salir.Image = ((System.Drawing.Image)(resources.GetObject("btn_salir.Image")));
            this.btn_salir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_salir.Location = new System.Drawing.Point(442, 144);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(85, 35);
            this.btn_salir.TabIndex = 9;
            this.btn_salir.Text = "&Salir";
            this.btn_salir.UseVisualStyleBackColor = true;
            this.btn_salir.Click += new System.EventHandler(this.btn_salir_Click);
            // 
            // btn_eliminar
            // 
            this.btn_eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_eliminar.Image = ((System.Drawing.Image)(resources.GetObject("btn_eliminar.Image")));
            this.btn_eliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_eliminar.Location = new System.Drawing.Point(442, 103);
            this.btn_eliminar.Name = "btn_eliminar";
            this.btn_eliminar.Size = new System.Drawing.Size(85, 35);
            this.btn_eliminar.TabIndex = 8;
            this.btn_eliminar.Text = "&Eliminar";
            this.btn_eliminar.UseVisualStyleBackColor = true;
            this.btn_eliminar.Click += new System.EventHandler(this.btn_eliminar_Click);
            // 
            // btn_modificar
            // 
            this.btn_modificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_modificar.Image = ((System.Drawing.Image)(resources.GetObject("btn_modificar.Image")));
            this.btn_modificar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_modificar.Location = new System.Drawing.Point(442, 62);
            this.btn_modificar.Name = "btn_modificar";
            this.btn_modificar.Size = new System.Drawing.Size(85, 35);
            this.btn_modificar.TabIndex = 7;
            this.btn_modificar.Text = "&Modificar";
            this.btn_modificar.UseVisualStyleBackColor = true;
            this.btn_modificar.Click += new System.EventHandler(this.btn_modificar_Click);
            // 
            // btn_nuevo
            // 
            this.btn_nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_nuevo.Image = ((System.Drawing.Image)(resources.GetObject("btn_nuevo.Image")));
            this.btn_nuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_nuevo.Location = new System.Drawing.Point(442, 21);
            this.btn_nuevo.Name = "btn_nuevo";
            this.btn_nuevo.Size = new System.Drawing.Size(85, 35);
            this.btn_nuevo.TabIndex = 6;
            this.btn_nuevo.Text = "&Nuevo";
            this.btn_nuevo.UseVisualStyleBackColor = true;
            this.btn_nuevo.Click += new System.EventHandler(this.btn_nuevo_Click);
            // 
            // dgw1
            // 
            this.dgw1.AllowUserToAddRows = false;
            this.dgw1.AllowUserToDeleteRows = false;
            this.dgw1.AllowUserToOrderColumns = true;
            this.dgw1.AllowUserToResizeRows = false;
            this.dgw1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgw1.BackgroundColor = System.Drawing.Color.White;
            this.dgw1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgw1.Location = new System.Drawing.Point(19, 21);
            this.dgw1.MultiSelect = false;
            this.dgw1.Name = "dgw1";
            this.dgw1.ReadOnly = true;
            this.dgw1.RowHeadersWidth = 25;
            this.dgw1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dgw1.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.dgw1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgw1.Size = new System.Drawing.Size(408, 257);
            this.dgw1.TabIndex = 0;
            this.dgw1.TabStop = false;
            // 
            // TabPage2
            // 
            this.TabPage2.Controls.Add(this.BTN_CANCELAR);
            this.TabPage2.Controls.Add(this.TabControl2);
            this.TabPage2.Controls.Add(this.j1);
            this.TabPage2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabPage2.Location = new System.Drawing.Point(4, 23);
            this.TabPage2.Name = "TabPage2";
            this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage2.Size = new System.Drawing.Size(535, 296);
            this.TabPage2.TabIndex = 1;
            this.TabPage2.Text = "Detalles";
            this.TabPage2.UseVisualStyleBackColor = true;
            // 
            // BTN_CANCELAR
            // 
            this.BTN_CANCELAR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_CANCELAR.Image = ((System.Drawing.Image)(resources.GetObject("BTN_CANCELAR.Image")));
            this.BTN_CANCELAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTN_CANCELAR.Location = new System.Drawing.Point(448, 246);
            this.BTN_CANCELAR.Name = "BTN_CANCELAR";
            this.BTN_CANCELAR.Size = new System.Drawing.Size(77, 27);
            this.BTN_CANCELAR.TabIndex = 80;
            this.BTN_CANCELAR.TabStop = false;
            this.BTN_CANCELAR.Text = "&Cancelar";
            this.BTN_CANCELAR.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTN_CANCELAR.UseVisualStyleBackColor = true;
            this.BTN_CANCELAR.Click += new System.EventHandler(this.BTN_CANCELAR_Click);
            // 
            // TabControl2
            // 
            this.TabControl2.Controls.Add(this.TabPage3);
            this.TabControl2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabControl2.ItemSize = new System.Drawing.Size(425, 19);
            this.TabControl2.Location = new System.Drawing.Point(6, 101);
            this.TabControl2.Name = "TabControl2";
            this.TabControl2.SelectedIndex = 0;
            this.TabControl2.Size = new System.Drawing.Size(432, 195);
            this.TabControl2.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.TabControl2.TabIndex = 1;
            // 
            // TabPage3
            // 
            this.TabPage3.Controls.Add(this.Panel1);
            this.TabPage3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabPage3.Location = new System.Drawing.Point(4, 23);
            this.TabPage3.Name = "TabPage3";
            this.TabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage3.Size = new System.Drawing.Size(424, 168);
            this.TabPage3.TabIndex = 0;
            this.TabPage3.Text = "Lista de Datos";
            this.TabPage3.UseVisualStyleBackColor = true;
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.Panel2);
            this.Panel1.Controls.Add(this.dgw);
            this.Panel1.Controls.Add(this.item1);
            this.Panel1.Controls.Add(this.btn_nuevo2);
            this.Panel1.Controls.Add(this.btn_eliminar2);
            this.Panel1.Controls.Add(this.btn_mod2);
            this.Panel1.Location = new System.Drawing.Point(6, 4);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(412, 163);
            this.Panel1.TabIndex = 15;
            // 
            // Panel2
            // 
            this.Panel2.Controls.Add(this.GroupBox5);
            this.Panel2.Location = new System.Drawing.Point(-3, -1);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(423, 165);
            this.Panel2.TabIndex = 0;
            // 
            // GroupBox5
            // 
            this.GroupBox5.Controls.Add(this.Label2);
            this.GroupBox5.Controls.Add(this.TXT_DESC_det);
            this.GroupBox5.Controls.Add(this.btn_cancelar2);
            this.GroupBox5.Controls.Add(this.btn_modificar2);
            this.GroupBox5.Controls.Add(this.TXT_COD_det);
            this.GroupBox5.Controls.Add(this.btn_guardar2);
            this.GroupBox5.Controls.Add(this.txt_obs_det);
            this.GroupBox5.Controls.Add(this.Label4);
            this.GroupBox5.Controls.Add(this.Label14);
            this.GroupBox5.Location = new System.Drawing.Point(7, 8);
            this.GroupBox5.Name = "GroupBox5";
            this.GroupBox5.Size = new System.Drawing.Size(406, 144);
            this.GroupBox5.TabIndex = 0;
            this.GroupBox5.TabStop = false;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(3, 74);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(69, 14);
            this.Label2.TabIndex = 7;
            this.Label2.Text = "Observación";
            // 
            // TXT_DESC_det
            // 
            this.TXT_DESC_det.BackColor = System.Drawing.Color.White;
            this.TXT_DESC_det.Location = new System.Drawing.Point(72, 45);
            this.TXT_DESC_det.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.TXT_DESC_det.MaxLength = 60;
            this.TXT_DESC_det.Name = "TXT_DESC_det";
            this.TXT_DESC_det.Size = new System.Drawing.Size(327, 20);
            this.TXT_DESC_det.TabIndex = 2;
            // 
            // btn_cancelar2
            // 
            this.btn_cancelar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancelar2.Image = ((System.Drawing.Image)(resources.GetObject("btn_cancelar2.Image")));
            this.btn_cancelar2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_cancelar2.Location = new System.Drawing.Point(322, 111);
            this.btn_cancelar2.Name = "btn_cancelar2";
            this.btn_cancelar2.Size = new System.Drawing.Size(77, 27);
            this.btn_cancelar2.TabIndex = 5;
            this.btn_cancelar2.Text = "&Cancelar";
            this.btn_cancelar2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_cancelar2.UseVisualStyleBackColor = true;
            this.btn_cancelar2.Click += new System.EventHandler(this.btn_cancelar2_Click);
            // 
            // btn_modificar2
            // 
            this.btn_modificar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_modificar2.Image = ((System.Drawing.Image)(resources.GetObject("btn_modificar2.Image")));
            this.btn_modificar2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_modificar2.Location = new System.Drawing.Point(239, 111);
            this.btn_modificar2.Name = "btn_modificar2";
            this.btn_modificar2.Size = new System.Drawing.Size(77, 27);
            this.btn_modificar2.TabIndex = 4;
            this.btn_modificar2.Text = "&Guardar";
            this.btn_modificar2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_modificar2.UseVisualStyleBackColor = true;
            this.btn_modificar2.Click += new System.EventHandler(this.btn_modificar2_Click);
            // 
            // TXT_COD_det
            // 
            this.TXT_COD_det.BackColor = System.Drawing.Color.White;
            this.TXT_COD_det.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TXT_COD_det.Location = new System.Drawing.Point(72, 19);
            this.TXT_COD_det.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.TXT_COD_det.MaxLength = 10;
            this.TXT_COD_det.Name = "TXT_COD_det";
            this.TXT_COD_det.Size = new System.Drawing.Size(100, 20);
            this.TXT_COD_det.TabIndex = 1;
            // 
            // btn_guardar2
            // 
            this.btn_guardar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_guardar2.Image = ((System.Drawing.Image)(resources.GetObject("btn_guardar2.Image")));
            this.btn_guardar2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_guardar2.Location = new System.Drawing.Point(239, 111);
            this.btn_guardar2.Name = "btn_guardar2";
            this.btn_guardar2.Size = new System.Drawing.Size(77, 27);
            this.btn_guardar2.TabIndex = 4;
            this.btn_guardar2.Text = "&Guardar";
            this.btn_guardar2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_guardar2.UseVisualStyleBackColor = true;
            this.btn_guardar2.Click += new System.EventHandler(this.btn_guardar2_Click);
            // 
            // txt_obs_det
            // 
            this.txt_obs_det.BackColor = System.Drawing.Color.White;
            this.txt_obs_det.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_obs_det.Location = new System.Drawing.Point(72, 71);
            this.txt_obs_det.MaxLength = 60;
            this.txt_obs_det.Name = "txt_obs_det";
            this.txt_obs_det.Size = new System.Drawing.Size(327, 20);
            this.txt_obs_det.TabIndex = 3;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(3, 48);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(64, 14);
            this.Label4.TabIndex = 5;
            this.Label4.Text = "Descripción";
            // 
            // Label14
            // 
            this.Label14.AutoSize = true;
            this.Label14.Location = new System.Drawing.Point(3, 22);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(40, 14);
            this.Label14.TabIndex = 1;
            this.Label14.Text = "Codigo";
            // 
            // dgw
            // 
            this.dgw.AllowUserToAddRows = false;
            this.dgw.AllowUserToDeleteRows = false;
            this.dgw.AllowUserToOrderColumns = true;
            this.dgw.AllowUserToResizeRows = false;
            this.dgw.BackgroundColor = System.Drawing.Color.White;
            this.dgw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgw.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dgw.Location = new System.Drawing.Point(7, 4);
            this.dgw.MultiSelect = false;
            this.dgw.Name = "dgw";
            this.dgw.ReadOnly = true;
            this.dgw.RowHeadersWidth = 25;
            this.dgw.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dgw.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.dgw.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgw.Size = new System.Drawing.Size(320, 156);
            this.dgw.TabIndex = 15;
            this.dgw.TabStop = false;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Cod";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 70;
            // 
            // Column2
            // 
            this.Column2.FillWeight = 194.9239F;
            this.Column2.HeaderText = "Descripción";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 223;
            // 
            // Column3
            // 
            this.Column3.FillWeight = 5.076141F;
            this.Column3.HeaderText = "Observacion";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Visible = false;
            this.Column3.Width = 26;
            // 
            // item1
            // 
            this.item1.Location = new System.Drawing.Point(340, 116);
            this.item1.Name = "item1";
            this.item1.Size = new System.Drawing.Size(25, 20);
            this.item1.TabIndex = 14;
            this.item1.Visible = false;
            // 
            // btn_nuevo2
            // 
            this.btn_nuevo2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_nuevo2.Image = ((System.Drawing.Image)(resources.GetObject("btn_nuevo2.Image")));
            this.btn_nuevo2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_nuevo2.Location = new System.Drawing.Point(329, 3);
            this.btn_nuevo2.Name = "btn_nuevo2";
            this.btn_nuevo2.Size = new System.Drawing.Size(77, 27);
            this.btn_nuevo2.TabIndex = 1;
            this.btn_nuevo2.Text = "&Agregar";
            this.btn_nuevo2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_nuevo2.UseVisualStyleBackColor = true;
            this.btn_nuevo2.Click += new System.EventHandler(this.btn_nuevo2_Click);
            // 
            // btn_eliminar2
            // 
            this.btn_eliminar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_eliminar2.Image = ((System.Drawing.Image)(resources.GetObject("btn_eliminar2.Image")));
            this.btn_eliminar2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_eliminar2.Location = new System.Drawing.Point(329, 62);
            this.btn_eliminar2.Name = "btn_eliminar2";
            this.btn_eliminar2.Size = new System.Drawing.Size(77, 27);
            this.btn_eliminar2.TabIndex = 3;
            this.btn_eliminar2.Text = "&Eliminar";
            this.btn_eliminar2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_eliminar2.UseVisualStyleBackColor = true;
            this.btn_eliminar2.Click += new System.EventHandler(this.btn_eliminar2_Click);
            // 
            // btn_mod2
            // 
            this.btn_mod2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_mod2.Image = ((System.Drawing.Image)(resources.GetObject("btn_mod2.Image")));
            this.btn_mod2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_mod2.Location = new System.Drawing.Point(329, 32);
            this.btn_mod2.Name = "btn_mod2";
            this.btn_mod2.Size = new System.Drawing.Size(77, 27);
            this.btn_mod2.TabIndex = 2;
            this.btn_mod2.Text = "&Modificar";
            this.btn_mod2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_mod2.UseVisualStyleBackColor = true;
            this.btn_mod2.Click += new System.EventHandler(this.btn_mod2_Click);
            // 
            // j1
            // 
            this.j1.Controls.Add(this.nup_obs);
            this.j1.Controls.Add(this.Label1);
            this.j1.Controls.Add(this.txt_desc);
            this.j1.Controls.Add(this.txt_cod);
            this.j1.Controls.Add(this.Label6);
            this.j1.Controls.Add(this.Label5);
            this.j1.Location = new System.Drawing.Point(23, 8);
            this.j1.Name = "j1";
            this.j1.Size = new System.Drawing.Size(475, 87);
            this.j1.TabIndex = 0;
            this.j1.TabStop = false;
            // 
            // nup_obs
            // 
            this.nup_obs.BackColor = System.Drawing.Color.White;
            this.nup_obs.Location = new System.Drawing.Point(318, 20);
            this.nup_obs.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nup_obs.Name = "nup_obs";
            this.nup_obs.Size = new System.Drawing.Size(36, 20);
            this.nup_obs.TabIndex = 2;
            this.nup_obs.ValueChanged += new System.EventHandler(this.nup_obs_ValueChanged);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(213, 22);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(78, 14);
            this.Label1.TabIndex = 4;
            this.Label1.Text = "Nroº de digitos";
            // 
            // txt_desc
            // 
            this.txt_desc.BackColor = System.Drawing.Color.White;
            this.txt_desc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_desc.Location = new System.Drawing.Point(77, 48);
            this.txt_desc.MaxLength = 60;
            this.txt_desc.Name = "txt_desc";
            this.txt_desc.Size = new System.Drawing.Size(392, 20);
            this.txt_desc.TabIndex = 3;
            // 
            // txt_cod
            // 
            this.txt_cod.BackColor = System.Drawing.Color.White;
            this.txt_cod.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_cod.Location = new System.Drawing.Point(77, 19);
            this.txt_cod.MaxLength = 5;
            this.txt_cod.Name = "txt_cod";
            this.txt_cod.Size = new System.Drawing.Size(60, 20);
            this.txt_cod.TabIndex = 1;
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(15, 51);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(64, 14);
            this.Label6.TabIndex = 1;
            this.Label6.Text = "Descripción";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(15, 22);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(40, 14);
            this.Label5.TabIndex = 0;
            this.Label5.Text = "Codigo";
            // 
            // DIRECTORIO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 323);
            this.Controls.Add(this.TabControl1);
            this.Name = "DIRECTORIO";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento de Directorio";
            this.Load += new System.EventHandler(this.DIRECTORIO_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DIRECTORIO_KeyDown);
            this.TabControl1.ResumeLayout(false);
            this.TabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgw1)).EndInit();
            this.TabPage2.ResumeLayout(false);
            this.TabControl2.ResumeLayout(false);
            this.TabPage3.ResumeLayout(false);
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.Panel2.ResumeLayout(false);
            this.GroupBox5.ResumeLayout(false);
            this.GroupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw)).EndInit();
            this.j1.ResumeLayout(false);
            this.j1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nup_obs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TabControl TabControl1;
        internal System.Windows.Forms.TabPage TabPage1;
        internal System.Windows.Forms.Button btn_salir;
        internal System.Windows.Forms.Button btn_eliminar;
        internal System.Windows.Forms.Button btn_modificar;
        internal System.Windows.Forms.Button btn_nuevo;
        internal System.Windows.Forms.DataGridView dgw1;
        internal System.Windows.Forms.TabPage TabPage2;
        internal System.Windows.Forms.Button BTN_CANCELAR;
        internal System.Windows.Forms.TabControl TabControl2;
        internal System.Windows.Forms.TabPage TabPage3;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.GroupBox GroupBox5;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox TXT_DESC_det;
        internal System.Windows.Forms.Button btn_cancelar2;
        internal System.Windows.Forms.Button btn_modificar2;
        internal System.Windows.Forms.TextBox TXT_COD_det;
        internal System.Windows.Forms.Button btn_guardar2;
        internal System.Windows.Forms.TextBox txt_obs_det;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label14;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.TextBox item1;
        internal System.Windows.Forms.Button btn_nuevo2;
        internal System.Windows.Forms.Button btn_eliminar2;
        internal System.Windows.Forms.Button btn_mod2;
        internal System.Windows.Forms.GroupBox j1;
        internal System.Windows.Forms.NumericUpDown nup_obs;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox txt_desc;
        internal System.Windows.Forms.TextBox txt_cod;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.DataGridView dgw;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}