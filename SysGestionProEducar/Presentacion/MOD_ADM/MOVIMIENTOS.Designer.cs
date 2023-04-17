namespace Presentacion.MOD_ADM
{
    partial class MOVIMIENTOS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MOVIMIENTOS));
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.btn_salir = new System.Windows.Forms.Button();
            this.BTN_MODIFICAR = new System.Windows.Forms.Button();
            this.btn_eliminar = new System.Windows.Forms.Button();
            this.btn_nuevo = new System.Windows.Forms.Button();
            this.dgw1 = new System.Windows.Forms.DataGridView();
            this.TabPage2 = new System.Windows.Forms.TabPage();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.gbSeries = new System.Windows.Forms.GroupBox();
            this.btn_eliminar2 = new System.Windows.Forms.Button();
            this.btn_agregar = new System.Windows.Forms.Button();
            this.dgvSeriesDocumento = new System.Windows.Forms.DataGridView();
            this.codsuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.suc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coddoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.doc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stadoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.btn_modificar2 = new System.Windows.Forms.Button();
            this.btn_guardar = new System.Windows.Forms.Button();
            this.cod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.abr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ope = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codsunat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipmov = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valcost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbCabecera = new System.Windows.Forms.GroupBox();
            this.txtCodSunat = new System.Windows.Forms.TextBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.ch_vc = new System.Windows.Forms.CheckBox();
            this.CBO_OPE = new System.Windows.Forms.ComboBox();
            this.Label7 = new System.Windows.Forms.Label();
            this.cbo_tipo_mov = new System.Windows.Forms.ComboBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.cbo_tipo_per = new System.Windows.Forms.ComboBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.txt_desc2 = new System.Windows.Forms.TextBox();
            this.txt_desc = new System.Windows.Forms.TextBox();
            this.txt_cod = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.TabControl1.SuspendLayout();
            this.TabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw1)).BeginInit();
            this.TabPage2.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.gbSeries.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeriesDocumento)).BeginInit();
            this.gbCabecera.SuspendLayout();
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
            this.TabControl1.Size = new System.Drawing.Size(600, 401);
            this.TabControl1.TabIndex = 1;
            this.TabControl1.SelectedIndexChanged += new System.EventHandler(this.TabControl1_SelectedIndexChanged);
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.btn_salir);
            this.TabPage1.Controls.Add(this.BTN_MODIFICAR);
            this.TabPage1.Controls.Add(this.btn_eliminar);
            this.TabPage1.Controls.Add(this.btn_nuevo);
            this.TabPage1.Controls.Add(this.dgw1);
            this.TabPage1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabPage1.Location = new System.Drawing.Point(4, 23);
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage1.Size = new System.Drawing.Size(592, 374);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "Lista de Movimientos";
            this.TabPage1.UseVisualStyleBackColor = true;
            // 
            // btn_salir
            // 
            this.btn_salir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_salir.Image = ((System.Drawing.Image)(resources.GetObject("btn_salir.Image")));
            this.btn_salir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_salir.Location = new System.Drawing.Point(499, 151);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(85, 35);
            this.btn_salir.TabIndex = 4;
            this.btn_salir.Text = "&Salir";
            this.btn_salir.UseVisualStyleBackColor = true;
            this.btn_salir.Click += new System.EventHandler(this.btn_salir_Click);
            // 
            // BTN_MODIFICAR
            // 
            this.BTN_MODIFICAR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_MODIFICAR.Image = ((System.Drawing.Image)(resources.GetObject("BTN_MODIFICAR.Image")));
            this.BTN_MODIFICAR.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTN_MODIFICAR.Location = new System.Drawing.Point(499, 69);
            this.BTN_MODIFICAR.Name = "BTN_MODIFICAR";
            this.BTN_MODIFICAR.Size = new System.Drawing.Size(85, 35);
            this.BTN_MODIFICAR.TabIndex = 2;
            this.BTN_MODIFICAR.Text = "&Modificar";
            this.BTN_MODIFICAR.UseVisualStyleBackColor = true;
            this.BTN_MODIFICAR.Click += new System.EventHandler(this.BTN_MODIFICAR_Click);
            // 
            // btn_eliminar
            // 
            this.btn_eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_eliminar.Image = ((System.Drawing.Image)(resources.GetObject("btn_eliminar.Image")));
            this.btn_eliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_eliminar.Location = new System.Drawing.Point(499, 110);
            this.btn_eliminar.Name = "btn_eliminar";
            this.btn_eliminar.Size = new System.Drawing.Size(85, 35);
            this.btn_eliminar.TabIndex = 3;
            this.btn_eliminar.Text = "&Eliminar";
            this.btn_eliminar.UseVisualStyleBackColor = true;
            this.btn_eliminar.Click += new System.EventHandler(this.btn_eliminar_Click);
            // 
            // btn_nuevo
            // 
            this.btn_nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_nuevo.Image = ((System.Drawing.Image)(resources.GetObject("btn_nuevo.Image")));
            this.btn_nuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_nuevo.Location = new System.Drawing.Point(499, 28);
            this.btn_nuevo.Name = "btn_nuevo";
            this.btn_nuevo.Size = new System.Drawing.Size(85, 35);
            this.btn_nuevo.TabIndex = 1;
            this.btn_nuevo.Text = "&Nuevo";
            this.btn_nuevo.UseVisualStyleBackColor = true;
            this.btn_nuevo.Click += new System.EventHandler(this.btn_nuevo_Click);
            // 
            // dgw1
            // 
            this.dgw1.AllowUserToAddRows = false;
            this.dgw1.AllowUserToDeleteRows = false;
            this.dgw1.BackgroundColor = System.Drawing.Color.White;
            this.dgw1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgw1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cod,
            this.desc,
            this.abr,
            this.ope,
            this.codsunat,
            this.tipmov,
            this.valcost});
            this.dgw1.Location = new System.Drawing.Point(38, 28);
            this.dgw1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dgw1.MultiSelect = false;
            this.dgw1.Name = "dgw1";
            this.dgw1.ReadOnly = true;
            this.dgw1.RowHeadersWidth = 25;
            this.dgw1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dgw1.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.dgw1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgw1.Size = new System.Drawing.Size(427, 317);
            this.dgw1.TabIndex = 11;
            // 
            // TabPage2
            // 
            this.TabPage2.Controls.Add(this.GroupBox1);
            this.TabPage2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabPage2.Location = new System.Drawing.Point(4, 23);
            this.TabPage2.Name = "TabPage2";
            this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage2.Size = new System.Drawing.Size(592, 374);
            this.TabPage2.TabIndex = 1;
            this.TabPage2.Text = "Detalles";
            this.TabPage2.UseVisualStyleBackColor = true;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.gbCabecera);
            this.GroupBox1.Controls.Add(this.gbSeries);
            this.GroupBox1.Controls.Add(this.btn_cancelar);
            this.GroupBox1.Controls.Add(this.btn_modificar2);
            this.GroupBox1.Controls.Add(this.btn_guardar);
            this.GroupBox1.Location = new System.Drawing.Point(51, 6);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(492, 343);
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            // 
            // gbSeries
            // 
            this.gbSeries.Controls.Add(this.btn_eliminar2);
            this.gbSeries.Controls.Add(this.btn_agregar);
            this.gbSeries.Controls.Add(this.dgvSeriesDocumento);
            this.gbSeries.Location = new System.Drawing.Point(9, 150);
            this.gbSeries.Name = "gbSeries";
            this.gbSeries.Size = new System.Drawing.Size(472, 156);
            this.gbSeries.TabIndex = 18;
            this.gbSeries.TabStop = false;
            this.gbSeries.Text = "Series documento";
            // 
            // btn_eliminar2
            // 
            this.btn_eliminar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_eliminar2.Image = ((System.Drawing.Image)(resources.GetObject("btn_eliminar2.Image")));
            this.btn_eliminar2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_eliminar2.Location = new System.Drawing.Point(390, 52);
            this.btn_eliminar2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_eliminar2.Name = "btn_eliminar2";
            this.btn_eliminar2.Size = new System.Drawing.Size(77, 27);
            this.btn_eliminar2.TabIndex = 32;
            this.btn_eliminar2.Text = "&Eliminar";
            this.btn_eliminar2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_eliminar2.UseVisualStyleBackColor = true;
            this.btn_eliminar2.Click += new System.EventHandler(this.btn_eliminar2_Click);
            // 
            // btn_agregar
            // 
            this.btn_agregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_agregar.Image = ((System.Drawing.Image)(resources.GetObject("btn_agregar.Image")));
            this.btn_agregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_agregar.Location = new System.Drawing.Point(390, 19);
            this.btn_agregar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_agregar.Name = "btn_agregar";
            this.btn_agregar.Size = new System.Drawing.Size(77, 27);
            this.btn_agregar.TabIndex = 8;
            this.btn_agregar.Text = "&Agregar";
            this.btn_agregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_agregar.UseVisualStyleBackColor = true;
            this.btn_agregar.Click += new System.EventHandler(this.btn_agregar_Click);
            // 
            // dgvSeriesDocumento
            // 
            this.dgvSeriesDocumento.AllowUserToAddRows = false;
            this.dgvSeriesDocumento.AllowUserToDeleteRows = false;
            this.dgvSeriesDocumento.AllowUserToResizeColumns = false;
            this.dgvSeriesDocumento.AllowUserToResizeRows = false;
            this.dgvSeriesDocumento.BackgroundColor = System.Drawing.Color.White;
            this.dgvSeriesDocumento.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codsuc,
            this.suc,
            this.coddoc,
            this.doc,
            this.stadoc,
            this.ser});
            this.dgvSeriesDocumento.Location = new System.Drawing.Point(5, 19);
            this.dgvSeriesDocumento.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dgvSeriesDocumento.MultiSelect = false;
            this.dgvSeriesDocumento.Name = "dgvSeriesDocumento";
            this.dgvSeriesDocumento.ReadOnly = true;
            this.dgvSeriesDocumento.RowHeadersVisible = false;
            this.dgvSeriesDocumento.RowHeadersWidth = 25;
            this.dgvSeriesDocumento.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dgvSeriesDocumento.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.dgvSeriesDocumento.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSeriesDocumento.Size = new System.Drawing.Size(381, 131);
            this.dgvSeriesDocumento.TabIndex = 30;
            // 
            // codsuc
            // 
            this.codsuc.HeaderText = "codsuc";
            this.codsuc.Name = "codsuc";
            this.codsuc.ReadOnly = true;
            this.codsuc.Visible = false;
            // 
            // suc
            // 
            this.suc.HeaderText = "Sucursal";
            this.suc.Name = "suc";
            this.suc.ReadOnly = true;
            this.suc.Width = 150;
            // 
            // coddoc
            // 
            this.coddoc.HeaderText = "coddoc";
            this.coddoc.Name = "coddoc";
            this.coddoc.ReadOnly = true;
            this.coddoc.Visible = false;
            // 
            // doc
            // 
            this.doc.HeaderText = "Documento";
            this.doc.Name = "doc";
            this.doc.ReadOnly = true;
            this.doc.Width = 150;
            // 
            // stadoc
            // 
            this.stadoc.HeaderText = "stadoc";
            this.stadoc.Name = "stadoc";
            this.stadoc.ReadOnly = true;
            this.stadoc.Visible = false;
            // 
            // ser
            // 
            this.ser.HeaderText = "Serie";
            this.ser.Name = "ser";
            this.ser.ReadOnly = true;
            this.ser.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ser.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ser.Width = 55;
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancelar.Image = ((System.Drawing.Image)(resources.GetObject("btn_cancelar.Image")));
            this.btn_cancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_cancelar.Location = new System.Drawing.Point(403, 309);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(77, 27);
            this.btn_cancelar.TabIndex = 14;
            this.btn_cancelar.Text = "&Cancelar";
            this.btn_cancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_cancelar.UseVisualStyleBackColor = true;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // btn_modificar2
            // 
            this.btn_modificar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_modificar2.Image = ((System.Drawing.Image)(resources.GetObject("btn_modificar2.Image")));
            this.btn_modificar2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_modificar2.Location = new System.Drawing.Point(318, 310);
            this.btn_modificar2.Name = "btn_modificar2";
            this.btn_modificar2.Size = new System.Drawing.Size(77, 27);
            this.btn_modificar2.TabIndex = 13;
            this.btn_modificar2.Text = "&Guardar";
            this.btn_modificar2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_modificar2.UseVisualStyleBackColor = true;
            this.btn_modificar2.Visible = false;
            this.btn_modificar2.Click += new System.EventHandler(this.btn_modificar2_Click);
            // 
            // btn_guardar
            // 
            this.btn_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_guardar.Image = ((System.Drawing.Image)(resources.GetObject("btn_guardar.Image")));
            this.btn_guardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_guardar.Location = new System.Drawing.Point(318, 310);
            this.btn_guardar.Name = "btn_guardar";
            this.btn_guardar.Size = new System.Drawing.Size(77, 27);
            this.btn_guardar.TabIndex = 13;
            this.btn_guardar.Text = "&Guardar";
            this.btn_guardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_guardar.UseVisualStyleBackColor = true;
            this.btn_guardar.Click += new System.EventHandler(this.btn_guardar_Click);
            // 
            // cod
            // 
            this.cod.HeaderText = "Cod";
            this.cod.Name = "cod";
            this.cod.ReadOnly = true;
            this.cod.Width = 40;
            // 
            // desc
            // 
            this.desc.HeaderText = "Descripcion";
            this.desc.Name = "desc";
            this.desc.ReadOnly = true;
            this.desc.Width = 160;
            // 
            // abr
            // 
            this.abr.HeaderText = "abr";
            this.abr.Name = "abr";
            this.abr.ReadOnly = true;
            this.abr.Visible = false;
            // 
            // ope
            // 
            this.ope.HeaderText = "Operacion";
            this.ope.Name = "ope";
            this.ope.ReadOnly = true;
            // 
            // codsunat
            // 
            this.codsunat.HeaderText = "Cod Sunat";
            this.codsunat.Name = "codsunat";
            this.codsunat.ReadOnly = true;
            this.codsunat.Width = 85;
            // 
            // tipmov
            // 
            this.tipmov.HeaderText = "tipmov";
            this.tipmov.Name = "tipmov";
            this.tipmov.ReadOnly = true;
            this.tipmov.Visible = false;
            // 
            // valcost
            // 
            this.valcost.HeaderText = "valcost";
            this.valcost.Name = "valcost";
            this.valcost.ReadOnly = true;
            this.valcost.Visible = false;
            // 
            // gbCabecera
            // 
            this.gbCabecera.Controls.Add(this.txtCodSunat);
            this.gbCabecera.Controls.Add(this.Label8);
            this.gbCabecera.Controls.Add(this.ch_vc);
            this.gbCabecera.Controls.Add(this.CBO_OPE);
            this.gbCabecera.Controls.Add(this.Label7);
            this.gbCabecera.Controls.Add(this.cbo_tipo_mov);
            this.gbCabecera.Controls.Add(this.Label6);
            this.gbCabecera.Controls.Add(this.cbo_tipo_per);
            this.gbCabecera.Controls.Add(this.Label5);
            this.gbCabecera.Controls.Add(this.txt_desc2);
            this.gbCabecera.Controls.Add(this.txt_desc);
            this.gbCabecera.Controls.Add(this.txt_cod);
            this.gbCabecera.Controls.Add(this.Label3);
            this.gbCabecera.Controls.Add(this.Label2);
            this.gbCabecera.Controls.Add(this.Label1);
            this.gbCabecera.Location = new System.Drawing.Point(9, 8);
            this.gbCabecera.Name = "gbCabecera";
            this.gbCabecera.Size = new System.Drawing.Size(472, 136);
            this.gbCabecera.TabIndex = 19;
            this.gbCabecera.TabStop = false;
            // 
            // txtCodSunat
            // 
            this.txtCodSunat.Location = new System.Drawing.Point(320, 60);
            this.txtCodSunat.MaxLength = 2;
            this.txtCodSunat.Name = "txtCodSunat";
            this.txtCodSunat.Size = new System.Drawing.Size(100, 20);
            this.txtCodSunat.TabIndex = 26;
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Location = new System.Drawing.Point(249, 65);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(57, 14);
            this.Label8.TabIndex = 34;
            this.Label8.Text = "Cod Sunat";
            // 
            // ch_vc
            // 
            this.ch_vc.AutoSize = true;
            this.ch_vc.Enabled = false;
            this.ch_vc.Location = new System.Drawing.Point(320, 110);
            this.ch_vc.Name = "ch_vc";
            this.ch_vc.Size = new System.Drawing.Size(82, 18);
            this.ch_vc.TabIndex = 29;
            this.ch_vc.Text = "Valor Costo";
            this.ch_vc.UseVisualStyleBackColor = true;
            // 
            // CBO_OPE
            // 
            this.CBO_OPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBO_OPE.FormattingEnabled = true;
            this.CBO_OPE.Location = new System.Drawing.Point(80, 82);
            this.CBO_OPE.Name = "CBO_OPE";
            this.CBO_OPE.Size = new System.Drawing.Size(95, 22);
            this.CBO_OPE.TabIndex = 27;
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(3, 85);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(80, 14);
            this.Label7.TabIndex = 32;
            this.Label7.Text = "Tipo Operación";
            // 
            // cbo_tipo_mov
            // 
            this.cbo_tipo_mov.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_tipo_mov.FormattingEnabled = true;
            this.cbo_tipo_mov.Location = new System.Drawing.Point(80, 108);
            this.cbo_tipo_mov.Name = "cbo_tipo_mov";
            this.cbo_tipo_mov.Size = new System.Drawing.Size(95, 22);
            this.cbo_tipo_mov.TabIndex = 28;
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(3, 111);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(52, 14);
            this.Label6.TabIndex = 33;
            this.Label6.Text = "Tipo Mov.";
            // 
            // cbo_tipo_per
            // 
            this.cbo_tipo_per.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_tipo_per.FormattingEnabled = true;
            this.cbo_tipo_per.Items.AddRange(new object[] {
            "C",
            "P"});
            this.cbo_tipo_per.Location = new System.Drawing.Point(248, 108);
            this.cbo_tipo_per.Name = "cbo_tipo_per";
            this.cbo_tipo_per.Size = new System.Drawing.Size(40, 22);
            this.cbo_tipo_per.TabIndex = 30;
            this.cbo_tipo_per.Visible = false;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(208, 111);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(34, 14);
            this.Label5.TabIndex = 31;
            this.Label5.Text = "Clase";
            this.Label5.Visible = false;
            // 
            // txt_desc2
            // 
            this.txt_desc2.BackColor = System.Drawing.Color.White;
            this.txt_desc2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_desc2.Location = new System.Drawing.Point(80, 59);
            this.txt_desc2.MaxLength = 15;
            this.txt_desc2.Name = "txt_desc2";
            this.txt_desc2.Size = new System.Drawing.Size(150, 20);
            this.txt_desc2.TabIndex = 25;
            // 
            // txt_desc
            // 
            this.txt_desc.BackColor = System.Drawing.Color.White;
            this.txt_desc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_desc.Location = new System.Drawing.Point(80, 35);
            this.txt_desc.MaxLength = 50;
            this.txt_desc.Name = "txt_desc";
            this.txt_desc.Size = new System.Drawing.Size(385, 20);
            this.txt_desc.TabIndex = 23;
            // 
            // txt_cod
            // 
            this.txt_cod.BackColor = System.Drawing.Color.White;
            this.txt_cod.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_cod.Location = new System.Drawing.Point(80, 10);
            this.txt_cod.MaxLength = 3;
            this.txt_cod.Name = "txt_cod";
            this.txt_cod.Size = new System.Drawing.Size(40, 20);
            this.txt_cod.TabIndex = 21;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(3, 62);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(57, 14);
            this.Label3.TabIndex = 24;
            this.Label3.Text = "Abreviado";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(3, 38);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(64, 14);
            this.Label2.TabIndex = 22;
            this.Label2.Text = "Descripción";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(3, 13);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(40, 14);
            this.Label1.TabIndex = 20;
            this.Label1.Text = "Codigo";
            // 
            // MOVIMIENTOS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 401);
            this.ControlBox = false;
            this.Controls.Add(this.TabControl1);
            this.Name = "MOVIMIENTOS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento de Movimientos";
            this.Load += new System.EventHandler(this.MOVIMIENTOS_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MOVIMIENTOS_KeyDown);
            this.TabControl1.ResumeLayout(false);
            this.TabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgw1)).EndInit();
            this.TabPage2.ResumeLayout(false);
            this.GroupBox1.ResumeLayout(false);
            this.gbSeries.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeriesDocumento)).EndInit();
            this.gbCabecera.ResumeLayout(false);
            this.gbCabecera.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TabControl TabControl1;
        internal System.Windows.Forms.TabPage TabPage1;
        internal System.Windows.Forms.Button btn_salir;
        internal System.Windows.Forms.Button BTN_MODIFICAR;
        internal System.Windows.Forms.Button btn_eliminar;
        internal System.Windows.Forms.Button btn_nuevo;
        internal System.Windows.Forms.DataGridView dgw1;
        internal System.Windows.Forms.TabPage TabPage2;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.GroupBox gbSeries;
        internal System.Windows.Forms.Button btn_eliminar2;
        internal System.Windows.Forms.Button btn_agregar;
        internal System.Windows.Forms.DataGridView dgvSeriesDocumento;
        internal System.Windows.Forms.Button btn_cancelar;
        internal System.Windows.Forms.Button btn_modificar2;
        internal System.Windows.Forms.Button btn_guardar;
        private System.Windows.Forms.DataGridViewTextBoxColumn codsuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn suc;
        private System.Windows.Forms.DataGridViewTextBoxColumn coddoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn doc;
        private System.Windows.Forms.DataGridViewTextBoxColumn stadoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn ser;
        private System.Windows.Forms.DataGridViewTextBoxColumn cod;
        private System.Windows.Forms.DataGridViewTextBoxColumn desc;
        private System.Windows.Forms.DataGridViewTextBoxColumn abr;
        private System.Windows.Forms.DataGridViewTextBoxColumn ope;
        private System.Windows.Forms.DataGridViewTextBoxColumn codsunat;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipmov;
        private System.Windows.Forms.DataGridViewTextBoxColumn valcost;
        private System.Windows.Forms.GroupBox gbCabecera;
        internal System.Windows.Forms.TextBox txtCodSunat;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.CheckBox ch_vc;
        internal System.Windows.Forms.ComboBox CBO_OPE;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.ComboBox cbo_tipo_mov;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.ComboBox cbo_tipo_per;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.TextBox txt_desc2;
        internal System.Windows.Forms.TextBox txt_desc;
        internal System.Windows.Forms.TextBox txt_cod;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
    }
}