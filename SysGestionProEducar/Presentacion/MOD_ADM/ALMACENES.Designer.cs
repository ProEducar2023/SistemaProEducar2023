namespace Presentacion.MOD_ADM
{
    partial class ALMACENES
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ALMACENES));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.btn_salir = new System.Windows.Forms.Button();
            this.btn_eliminar = new System.Windows.Forms.Button();
            this.btn_modificar = new System.Windows.Forms.Button();
            this.btn_nuevo = new System.Windows.Forms.Button();
            this.dgw1 = new System.Windows.Forms.DataGridView();
            this.cod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.abr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipalm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codcla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.succod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sucdes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stsuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESC_TIPO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESC_CLASE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TabPage2 = new System.Windows.Forms.TabPage();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.chkPicking = new System.Windows.Forms.CheckBox();
            this.Label9 = new System.Windows.Forms.Label();
            this.Label8 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.txt_fono = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.txt_dir = new System.Windows.Forms.TextBox();
            this.txt_localidad = new System.Windows.Forms.TextBox();
            this.btn_modificar2 = new System.Windows.Forms.Button();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.Label6 = new System.Windows.Forms.Label();
            this.btn_guardar = new System.Windows.Forms.Button();
            this.cbo_sucursal = new System.Windows.Forms.ComboBox();
            this.ch_sucursal = new System.Windows.Forms.CheckBox();
            this.CBO_CLASE = new System.Windows.Forms.ComboBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.CBO_TIPO = new System.Windows.Forms.ComboBox();
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
            this.SuspendLayout();
            // 
            // TabControl1
            // 
            this.TabControl1.Controls.Add(this.TabPage1);
            this.TabControl1.Controls.Add(this.TabPage2);
            this.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.TabControl1.Location = new System.Drawing.Point(0, 0);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(593, 323);
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
            this.TabPage1.Font = new System.Drawing.Font("Arial", 8.25F);
            this.TabPage1.Location = new System.Drawing.Point(4, 23);
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage1.Size = new System.Drawing.Size(585, 296);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "Lista de Almacenes";
            this.TabPage1.UseVisualStyleBackColor = true;
            // 
            // btn_salir
            // 
            this.btn_salir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_salir.Image = ((System.Drawing.Image)(resources.GetObject("btn_salir.Image")));
            this.btn_salir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_salir.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_salir.Location = new System.Drawing.Point(492, 147);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(85, 35);
            this.btn_salir.TabIndex = 4;
            this.btn_salir.Text = "&Salir";
            this.btn_salir.UseVisualStyleBackColor = true;
            this.btn_salir.Click += new System.EventHandler(this.btn_salir_Click);
            // 
            // btn_eliminar
            // 
            this.btn_eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_eliminar.Image = ((System.Drawing.Image)(resources.GetObject("btn_eliminar.Image")));
            this.btn_eliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_eliminar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_eliminar.Location = new System.Drawing.Point(492, 106);
            this.btn_eliminar.Name = "btn_eliminar";
            this.btn_eliminar.Size = new System.Drawing.Size(85, 35);
            this.btn_eliminar.TabIndex = 3;
            this.btn_eliminar.Text = "&Eliminar";
            this.btn_eliminar.UseVisualStyleBackColor = true;
            this.btn_eliminar.Click += new System.EventHandler(this.btn_eliminar_Click);
            // 
            // btn_modificar
            // 
            this.btn_modificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_modificar.Image = ((System.Drawing.Image)(resources.GetObject("btn_modificar.Image")));
            this.btn_modificar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_modificar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_modificar.Location = new System.Drawing.Point(492, 65);
            this.btn_modificar.Name = "btn_modificar";
            this.btn_modificar.Size = new System.Drawing.Size(85, 35);
            this.btn_modificar.TabIndex = 2;
            this.btn_modificar.Text = "&Modificar";
            this.btn_modificar.UseVisualStyleBackColor = true;
            this.btn_modificar.Click += new System.EventHandler(this.btn_modificar_Click);
            // 
            // btn_nuevo
            // 
            this.btn_nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_nuevo.Image = ((System.Drawing.Image)(resources.GetObject("btn_nuevo.Image")));
            this.btn_nuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_nuevo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_nuevo.Location = new System.Drawing.Point(492, 24);
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
            this.dgw1.AllowUserToOrderColumns = true;
            this.dgw1.AllowUserToResizeRows = false;
            this.dgw1.BackgroundColor = System.Drawing.Color.White;
            this.dgw1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgw1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cod,
            this.desc,
            this.abr,
            this.tipalm,
            this.codcla,
            this.succod,
            this.sucdes,
            this.loc,
            this.dir,
            this.tel,
            this.stsuc,
            this.DESC_TIPO,
            this.DESC_CLASE});
            this.dgw1.Location = new System.Drawing.Point(19, 24);
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
            this.dgw1.Size = new System.Drawing.Size(459, 250);
            this.dgw1.TabIndex = 0;
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
            this.desc.HeaderText = "Descripcion";
            this.desc.Name = "desc";
            this.desc.ReadOnly = true;
            this.desc.Width = 200;
            // 
            // abr
            // 
            this.abr.HeaderText = "abr";
            this.abr.Name = "abr";
            this.abr.ReadOnly = true;
            this.abr.Visible = false;
            // 
            // tipalm
            // 
            this.tipalm.HeaderText = "tipalm";
            this.tipalm.Name = "tipalm";
            this.tipalm.ReadOnly = true;
            this.tipalm.Visible = false;
            // 
            // codcla
            // 
            this.codcla.HeaderText = "codcla";
            this.codcla.Name = "codcla";
            this.codcla.ReadOnly = true;
            this.codcla.Visible = false;
            // 
            // succod
            // 
            this.succod.HeaderText = "succod";
            this.succod.Name = "succod";
            this.succod.ReadOnly = true;
            this.succod.Visible = false;
            // 
            // sucdes
            // 
            this.sucdes.HeaderText = "Sucursal";
            this.sucdes.Name = "sucdes";
            this.sucdes.ReadOnly = true;
            this.sucdes.Width = 170;
            // 
            // loc
            // 
            this.loc.HeaderText = "loc";
            this.loc.Name = "loc";
            this.loc.ReadOnly = true;
            this.loc.Visible = false;
            // 
            // dir
            // 
            this.dir.HeaderText = "dir";
            this.dir.Name = "dir";
            this.dir.ReadOnly = true;
            this.dir.Visible = false;
            // 
            // tel
            // 
            this.tel.HeaderText = "tel";
            this.tel.Name = "tel";
            this.tel.ReadOnly = true;
            this.tel.Visible = false;
            // 
            // stsuc
            // 
            this.stsuc.HeaderText = "stsuc";
            this.stsuc.Name = "stsuc";
            this.stsuc.ReadOnly = true;
            this.stsuc.Visible = false;
            // 
            // DESC_TIPO
            // 
            this.DESC_TIPO.HeaderText = "Tipo";
            this.DESC_TIPO.Name = "DESC_TIPO";
            this.DESC_TIPO.ReadOnly = true;
            // 
            // DESC_CLASE
            // 
            this.DESC_CLASE.HeaderText = "Clase";
            this.DESC_CLASE.Name = "DESC_CLASE";
            this.DESC_CLASE.ReadOnly = true;
            // 
            // TabPage2
            // 
            this.TabPage2.Controls.Add(this.GroupBox1);
            this.TabPage2.Font = new System.Drawing.Font("Arial", 8.25F);
            this.TabPage2.Location = new System.Drawing.Point(4, 23);
            this.TabPage2.Name = "TabPage2";
            this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage2.Size = new System.Drawing.Size(585, 296);
            this.TabPage2.TabIndex = 1;
            this.TabPage2.Text = "Detalles";
            this.TabPage2.UseVisualStyleBackColor = true;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.chkPicking);
            this.GroupBox1.Controls.Add(this.Label9);
            this.GroupBox1.Controls.Add(this.Label8);
            this.GroupBox1.Controls.Add(this.Label7);
            this.GroupBox1.Controls.Add(this.txt_fono);
            this.GroupBox1.Controls.Add(this.Label4);
            this.GroupBox1.Controls.Add(this.txt_dir);
            this.GroupBox1.Controls.Add(this.txt_localidad);
            this.GroupBox1.Controls.Add(this.btn_modificar2);
            this.GroupBox1.Controls.Add(this.btn_cancelar);
            this.GroupBox1.Controls.Add(this.Label6);
            this.GroupBox1.Controls.Add(this.btn_guardar);
            this.GroupBox1.Controls.Add(this.cbo_sucursal);
            this.GroupBox1.Controls.Add(this.ch_sucursal);
            this.GroupBox1.Controls.Add(this.CBO_CLASE);
            this.GroupBox1.Controls.Add(this.Label5);
            this.GroupBox1.Controls.Add(this.CBO_TIPO);
            this.GroupBox1.Controls.Add(this.txt_desc2);
            this.GroupBox1.Controls.Add(this.txt_desc);
            this.GroupBox1.Controls.Add(this.txt_cod);
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Location = new System.Drawing.Point(35, 8);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(511, 280);
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            // 
            // chkPicking
            // 
            this.chkPicking.AutoSize = true;
            this.chkPicking.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chkPicking.Location = new System.Drawing.Point(107, 233);
            this.chkPicking.Name = "chkPicking";
            this.chkPicking.Size = new System.Drawing.Size(192, 18);
            this.chkPicking.TabIndex = 19;
            this.chkPicking.Text = "¿Mostrar en picking de despacho?";
            this.chkPicking.UseVisualStyleBackColor = true;
            this.chkPicking.Visible = false;
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label9.Location = new System.Drawing.Point(19, 210);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(48, 14);
            this.Label9.TabIndex = 18;
            this.Label9.Text = "Teléfono";
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label8.Location = new System.Drawing.Point(19, 187);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(52, 14);
            this.Label8.TabIndex = 17;
            this.Label8.Text = "Dirección";
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label7.Location = new System.Drawing.Point(19, 164);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(53, 14);
            this.Label7.TabIndex = 16;
            this.Label7.Text = "Localidad";
            // 
            // txt_fono
            // 
            this.txt_fono.BackColor = System.Drawing.Color.White;
            this.txt_fono.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_fono.Location = new System.Drawing.Point(107, 207);
            this.txt_fono.MaxLength = 20;
            this.txt_fono.Name = "txt_fono";
            this.txt_fono.Size = new System.Drawing.Size(200, 20);
            this.txt_fono.TabIndex = 10;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label4.Location = new System.Drawing.Point(19, 89);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(86, 14);
            this.Label4.TabIndex = 6;
            this.Label4.Text = "Tipo de Almacén";
            // 
            // txt_dir
            // 
            this.txt_dir.BackColor = System.Drawing.Color.White;
            this.txt_dir.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_dir.Location = new System.Drawing.Point(107, 184);
            this.txt_dir.MaxLength = 60;
            this.txt_dir.Name = "txt_dir";
            this.txt_dir.Size = new System.Drawing.Size(388, 20);
            this.txt_dir.TabIndex = 9;
            // 
            // txt_localidad
            // 
            this.txt_localidad.BackColor = System.Drawing.Color.White;
            this.txt_localidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_localidad.Location = new System.Drawing.Point(107, 161);
            this.txt_localidad.MaxLength = 20;
            this.txt_localidad.Name = "txt_localidad";
            this.txt_localidad.Size = new System.Drawing.Size(200, 20);
            this.txt_localidad.TabIndex = 8;
            // 
            // btn_modificar2
            // 
            this.btn_modificar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_modificar2.Image = ((System.Drawing.Image)(resources.GetObject("btn_modificar2.Image")));
            this.btn_modificar2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_modificar2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_modificar2.Location = new System.Drawing.Point(335, 239);
            this.btn_modificar2.Name = "btn_modificar2";
            this.btn_modificar2.Size = new System.Drawing.Size(77, 27);
            this.btn_modificar2.TabIndex = 11;
            this.btn_modificar2.Text = "&Guardar";
            this.btn_modificar2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_modificar2.UseVisualStyleBackColor = true;
            this.btn_modificar2.Click += new System.EventHandler(this.btn_modificar2_Click);
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancelar.Image = ((System.Drawing.Image)(resources.GetObject("btn_cancelar.Image")));
            this.btn_cancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_cancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_cancelar.Location = new System.Drawing.Point(418, 239);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(77, 27);
            this.btn_cancelar.TabIndex = 12;
            this.btn_cancelar.Text = "&Cancelar";
            this.btn_cancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_cancelar.UseVisualStyleBackColor = true;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label6.Location = new System.Drawing.Point(19, 139);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(50, 14);
            this.Label6.TabIndex = 12;
            this.Label6.Text = "Sucursal";
            // 
            // btn_guardar
            // 
            this.btn_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_guardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_guardar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_guardar.Location = new System.Drawing.Point(335, 239);
            this.btn_guardar.Name = "btn_guardar";
            this.btn_guardar.Size = new System.Drawing.Size(77, 27);
            this.btn_guardar.TabIndex = 11;
            this.btn_guardar.Text = "&Guardar";
            this.btn_guardar.UseVisualStyleBackColor = true;
            this.btn_guardar.Click += new System.EventHandler(this.btn_guardar_Click);
            // 
            // cbo_sucursal
            // 
            this.cbo_sucursal.BackColor = System.Drawing.Color.White;
            this.cbo_sucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_sucursal.Enabled = false;
            this.cbo_sucursal.FormattingEnabled = true;
            this.cbo_sucursal.Items.AddRange(new object[] {
            "SUCURSAL 1",
            "SUCURSAL 2"});
            this.cbo_sucursal.Location = new System.Drawing.Point(107, 136);
            this.cbo_sucursal.Name = "cbo_sucursal";
            this.cbo_sucursal.Size = new System.Drawing.Size(200, 22);
            this.cbo_sucursal.TabIndex = 7;
            // 
            // ch_sucursal
            // 
            this.ch_sucursal.AutoSize = true;
            this.ch_sucursal.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ch_sucursal.Location = new System.Drawing.Point(318, 118);
            this.ch_sucursal.Name = "ch_sucursal";
            this.ch_sucursal.Size = new System.Drawing.Size(69, 18);
            this.ch_sucursal.TabIndex = 6;
            this.ch_sucursal.Text = "Sucursal";
            this.ch_sucursal.UseVisualStyleBackColor = true;
            this.ch_sucursal.CheckedChanged += new System.EventHandler(this.ch_sucursal_CheckedChanged);
            // 
            // CBO_CLASE
            // 
            this.CBO_CLASE.BackColor = System.Drawing.Color.White;
            this.CBO_CLASE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBO_CLASE.FormattingEnabled = true;
            this.CBO_CLASE.Items.AddRange(new object[] {
            "MERCADERIAS",
            "PRODUCTO TERMINADO",
            "ACTIVOS"});
            this.CBO_CLASE.Location = new System.Drawing.Point(107, 111);
            this.CBO_CLASE.Name = "CBO_CLASE";
            this.CBO_CLASE.Size = new System.Drawing.Size(200, 22);
            this.CBO_CLASE.TabIndex = 5;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label5.Location = new System.Drawing.Point(19, 114);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(88, 14);
            this.Label5.TabIndex = 8;
            this.Label5.Text = "Clase de Artículo";
            // 
            // CBO_TIPO
            // 
            this.CBO_TIPO.BackColor = System.Drawing.Color.White;
            this.CBO_TIPO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBO_TIPO.FormattingEnabled = true;
            this.CBO_TIPO.Items.AddRange(new object[] {
            "INVENTARIOS",
            "VENTAS"});
            this.CBO_TIPO.Location = new System.Drawing.Point(107, 86);
            this.CBO_TIPO.Name = "CBO_TIPO";
            this.CBO_TIPO.Size = new System.Drawing.Size(200, 22);
            this.CBO_TIPO.TabIndex = 4;
            // 
            // txt_desc2
            // 
            this.txt_desc2.BackColor = System.Drawing.Color.White;
            this.txt_desc2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_desc2.Location = new System.Drawing.Point(107, 63);
            this.txt_desc2.MaxLength = 20;
            this.txt_desc2.Name = "txt_desc2";
            this.txt_desc2.Size = new System.Drawing.Size(200, 20);
            this.txt_desc2.TabIndex = 3;
            // 
            // txt_desc
            // 
            this.txt_desc.BackColor = System.Drawing.Color.White;
            this.txt_desc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_desc.Location = new System.Drawing.Point(107, 40);
            this.txt_desc.MaxLength = 40;
            this.txt_desc.Name = "txt_desc";
            this.txt_desc.Size = new System.Drawing.Size(300, 20);
            this.txt_desc.TabIndex = 2;
            // 
            // txt_cod
            // 
            this.txt_cod.BackColor = System.Drawing.Color.White;
            this.txt_cod.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_cod.Location = new System.Drawing.Point(107, 17);
            this.txt_cod.MaxLength = 4;
            this.txt_cod.Name = "txt_cod";
            this.txt_cod.Size = new System.Drawing.Size(30, 20);
            this.txt_cod.TabIndex = 1;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label3.Location = new System.Drawing.Point(19, 66);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(57, 14);
            this.Label3.TabIndex = 2;
            this.Label3.Text = "Abreviado";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label2.Location = new System.Drawing.Point(19, 43);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(64, 14);
            this.Label2.TabIndex = 1;
            this.Label2.Text = "Descripción";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label1.Location = new System.Drawing.Point(19, 20);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(40, 14);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Codigo";
            // 
            // ALMACENES
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 323);
            this.Controls.Add(this.TabControl1);
            this.Name = "ALMACENES";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento de Almacenes";
            this.Load += new System.EventHandler(this.ALMACENES_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ALMACENES_KeyDown);
            this.TabControl1.ResumeLayout(false);
            this.TabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgw1)).EndInit();
            this.TabPage2.ResumeLayout(false);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
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
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.CheckBox chkPicking;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.TextBox txt_fono;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.TextBox txt_dir;
        internal System.Windows.Forms.TextBox txt_localidad;
        internal System.Windows.Forms.Button btn_modificar2;
        internal System.Windows.Forms.Button btn_cancelar;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Button btn_guardar;
        internal System.Windows.Forms.ComboBox cbo_sucursal;
        internal System.Windows.Forms.CheckBox ch_sucursal;
        internal System.Windows.Forms.ComboBox CBO_CLASE;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.ComboBox CBO_TIPO;
        internal System.Windows.Forms.TextBox txt_desc2;
        internal System.Windows.Forms.TextBox txt_desc;
        internal System.Windows.Forms.TextBox txt_cod;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cod;
        private System.Windows.Forms.DataGridViewTextBoxColumn desc;
        private System.Windows.Forms.DataGridViewTextBoxColumn abr;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipalm;
        private System.Windows.Forms.DataGridViewTextBoxColumn codcla;
        private System.Windows.Forms.DataGridViewTextBoxColumn succod;
        private System.Windows.Forms.DataGridViewTextBoxColumn sucdes;
        private System.Windows.Forms.DataGridViewTextBoxColumn loc;
        private System.Windows.Forms.DataGridViewTextBoxColumn dir;
        private System.Windows.Forms.DataGridViewTextBoxColumn tel;
        private System.Windows.Forms.DataGridViewTextBoxColumn stsuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESC_TIPO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESC_CLASE;
    }
}