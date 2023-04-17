namespace Presentacion.MOD_ADM
{
    partial class INSTITUCIONES
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(INSTITUCIONES));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.btn_salir = new System.Windows.Forms.Button();
            this.btn_eliminar = new System.Windows.Forms.Button();
            this.btn_modificar = new System.Windows.Forms.Button();
            this.btn_nuevo = new System.Windows.Forms.Button();
            this.dgw1 = new System.Windows.Forms.DataGridView();
            this.cod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codpro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tip_pla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TabPage2 = new System.Windows.Forms.TabPage();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.panelNiveles = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtCodigo_ni = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDescripcion_ni = new System.Windows.Forms.TextBox();
            this.btnCancelar_ni = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.btnModificar_ni = new System.Windows.Forms.Button();
            this.btnGuardar_ni = new System.Windows.Forms.Button();
            this.cbo_tipo_pla = new System.Windows.Forms.ComboBox();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.btnEle_ni = new System.Windows.Forms.Button();
            this.dgwNiveles_ni = new System.Windows.Forms.DataGridView();
            this.CODIGO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESCRIPCION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAgre_ni = new System.Windows.Forms.Button();
            this.btnMod_ni = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cboproceso = new System.Windows.Forms.ComboBox();
            this.cboidentidad = new System.Windows.Forms.ComboBox();
            this.label32 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.txtdescc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_desc = new System.Windows.Forms.TextBox();
            this.txt_cod = new System.Windows.Forms.TextBox();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.btn_guardar = new System.Windows.Forms.Button();
            this.btn_modificar2 = new System.Windows.Forms.Button();
            this.TabControl1.SuspendLayout();
            this.TabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw1)).BeginInit();
            this.TabPage2.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.panelNiveles.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwNiveles_ni)).BeginInit();
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
            this.TabControl1.Size = new System.Drawing.Size(524, 381);
            this.TabControl1.TabIndex = 3;
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
            this.TabPage1.Size = new System.Drawing.Size(516, 354);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "Lista de Instituciones";
            this.TabPage1.UseVisualStyleBackColor = true;
            // 
            // btn_salir
            // 
            this.btn_salir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_salir.Image = ((System.Drawing.Image)(resources.GetObject("btn_salir.Image")));
            this.btn_salir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_salir.Location = new System.Drawing.Point(408, 180);
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
            this.btn_eliminar.Location = new System.Drawing.Point(408, 139);
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
            this.btn_modificar.Location = new System.Drawing.Point(408, 98);
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
            this.btn_nuevo.Location = new System.Drawing.Point(408, 57);
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
            this.dgw1.AllowUserToResizeRows = false;
            this.dgw1.BackgroundColor = System.Drawing.Color.White;
            this.dgw1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgw1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cod,
            this.desc,
            this.descc,
            this.codid,
            this.codpro,
            this.tip_pla});
            this.dgw1.Location = new System.Drawing.Point(40, 24);
            this.dgw1.MultiSelect = false;
            this.dgw1.Name = "dgw1";
            this.dgw1.ReadOnly = true;
            this.dgw1.RowHeadersWidth = 25;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            this.dgw1.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgw1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dgw1.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.dgw1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgw1.Size = new System.Drawing.Size(345, 286);
            this.dgw1.TabIndex = 0;
            // 
            // cod
            // 
            this.cod.FillWeight = 50.76142F;
            this.cod.HeaderText = "Cod";
            this.cod.Name = "cod";
            this.cod.ReadOnly = true;
            this.cod.Width = 50;
            // 
            // desc
            // 
            this.desc.FillWeight = 149.2386F;
            this.desc.HeaderText = "Descripcion";
            this.desc.Name = "desc";
            this.desc.ReadOnly = true;
            this.desc.Width = 210;
            // 
            // descc
            // 
            this.descc.HeaderText = "descc";
            this.descc.Name = "descc";
            this.descc.ReadOnly = true;
            this.descc.Visible = false;
            // 
            // codid
            // 
            this.codid.HeaderText = "codid";
            this.codid.Name = "codid";
            this.codid.ReadOnly = true;
            this.codid.Visible = false;
            // 
            // codpro
            // 
            this.codpro.HeaderText = "codpro";
            this.codpro.Name = "codpro";
            this.codpro.ReadOnly = true;
            this.codpro.Visible = false;
            // 
            // tip_pla
            // 
            this.tip_pla.HeaderText = "T";
            this.tip_pla.Name = "tip_pla";
            this.tip_pla.ReadOnly = true;
            this.tip_pla.Width = 30;
            // 
            // TabPage2
            // 
            this.TabPage2.Controls.Add(this.GroupBox1);
            this.TabPage2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabPage2.Location = new System.Drawing.Point(4, 23);
            this.TabPage2.Name = "TabPage2";
            this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage2.Size = new System.Drawing.Size(516, 354);
            this.TabPage2.TabIndex = 1;
            this.TabPage2.Text = "Detalles";
            this.TabPage2.UseVisualStyleBackColor = true;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.panelNiveles);
            this.GroupBox1.Controls.Add(this.cbo_tipo_pla);
            this.GroupBox1.Controls.Add(this.groupBox12);
            this.GroupBox1.Controls.Add(this.label4);
            this.GroupBox1.Controls.Add(this.cboproceso);
            this.GroupBox1.Controls.Add(this.cboidentidad);
            this.GroupBox1.Controls.Add(this.label32);
            this.GroupBox1.Controls.Add(this.label31);
            this.GroupBox1.Controls.Add(this.txtdescc);
            this.GroupBox1.Controls.Add(this.label3);
            this.GroupBox1.Controls.Add(this.txt_desc);
            this.GroupBox1.Controls.Add(this.txt_cod);
            this.GroupBox1.Controls.Add(this.btn_cancelar);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Controls.Add(this.btn_guardar);
            this.GroupBox1.Controls.Add(this.btn_modificar2);
            this.GroupBox1.Location = new System.Drawing.Point(34, 6);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(448, 339);
            this.GroupBox1.TabIndex = 1;
            this.GroupBox1.TabStop = false;
            // 
            // panelNiveles
            // 
            this.panelNiveles.Controls.Add(this.groupBox2);
            this.panelNiveles.Location = new System.Drawing.Point(7, 160);
            this.panelNiveles.Name = "panelNiveles";
            this.panelNiveles.Size = new System.Drawing.Size(420, 123);
            this.panelNiveles.TabIndex = 17;
            this.panelNiveles.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtCodigo_ni);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtDescripcion_ni);
            this.groupBox2.Controls.Add(this.btnCancelar_ni);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.btnGuardar_ni);
            this.groupBox2.Controls.Add(this.btnModificar_ni);
            this.groupBox2.Location = new System.Drawing.Point(14, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(395, 113);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Nivel";
            // 
            // txtCodigo_ni
            // 
            this.txtCodigo_ni.Location = new System.Drawing.Point(85, 11);
            this.txtCodigo_ni.MaxLength = 20;
            this.txtCodigo_ni.Name = "txtCodigo_ni";
            this.txtCodigo_ni.ReadOnly = true;
            this.txtCodigo_ni.Size = new System.Drawing.Size(80, 20);
            this.txtCodigo_ni.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 14);
            this.label5.TabIndex = 15;
            this.label5.Text = "Código";
            // 
            // txtDescripcion_ni
            // 
            this.txtDescripcion_ni.Location = new System.Drawing.Point(85, 38);
            this.txtDescripcion_ni.MaxLength = 50;
            this.txtDescripcion_ni.Name = "txtDescripcion_ni";
            this.txtDescripcion_ni.Size = new System.Drawing.Size(278, 20);
            this.txtDescripcion_ni.TabIndex = 7;
            // 
            // btnCancelar_ni
            // 
            this.btnCancelar_ni.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar_ni.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar_ni.Image")));
            this.btnCancelar_ni.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar_ni.Location = new System.Drawing.Point(168, 72);
            this.btnCancelar_ni.Name = "btnCancelar_ni";
            this.btnCancelar_ni.Size = new System.Drawing.Size(77, 27);
            this.btnCancelar_ni.TabIndex = 14;
            this.btnCancelar_ni.Text = "&Cancelar";
            this.btnCancelar_ni.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar_ni.UseVisualStyleBackColor = true;
            this.btnCancelar_ni.Click += new System.EventHandler(this.btnCancelar_ni_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(18, 41);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(30, 14);
            this.label11.TabIndex = 0;
            this.label11.Text = "Nivel";
            // 
            // btnModificar_ni
            // 
            this.btnModificar_ni.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificar_ni.Image = ((System.Drawing.Image)(resources.GetObject("btnModificar_ni.Image")));
            this.btnModificar_ni.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModificar_ni.Location = new System.Drawing.Point(87, 72);
            this.btnModificar_ni.Name = "btnModificar_ni";
            this.btnModificar_ni.Size = new System.Drawing.Size(77, 27);
            this.btnModificar_ni.TabIndex = 13;
            this.btnModificar_ni.Text = "&Modificar";
            this.btnModificar_ni.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnModificar_ni.UseVisualStyleBackColor = true;
            this.btnModificar_ni.Click += new System.EventHandler(this.btnModificar_ni_Click);
            // 
            // btnGuardar_ni
            // 
            this.btnGuardar_ni.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar_ni.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar_ni.Image")));
            this.btnGuardar_ni.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar_ni.Location = new System.Drawing.Point(87, 72);
            this.btnGuardar_ni.Name = "btnGuardar_ni";
            this.btnGuardar_ni.Size = new System.Drawing.Size(77, 27);
            this.btnGuardar_ni.TabIndex = 13;
            this.btnGuardar_ni.Text = "&Guardar";
            this.btnGuardar_ni.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar_ni.UseVisualStyleBackColor = true;
            this.btnGuardar_ni.Click += new System.EventHandler(this.btnGuardar_ni_Click);
            // 
            // cbo_tipo_pla
            // 
            this.cbo_tipo_pla.BackColor = System.Drawing.Color.White;
            this.cbo_tipo_pla.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_tipo_pla.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_tipo_pla.FormattingEnabled = true;
            this.cbo_tipo_pla.Items.AddRange(new object[] {
            "NATURAL",
            "JURIDICA",
            "SUJETOS NO DOMICILIADOS"});
            this.cbo_tipo_pla.Location = new System.Drawing.Point(90, 40);
            this.cbo_tipo_pla.Name = "cbo_tipo_pla";
            this.cbo_tipo_pla.Size = new System.Drawing.Size(135, 22);
            this.cbo_tipo_pla.TabIndex = 19;
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.btnEle_ni);
            this.groupBox12.Controls.Add(this.dgwNiveles_ni);
            this.groupBox12.Controls.Add(this.btnAgre_ni);
            this.groupBox12.Controls.Add(this.btnMod_ni);
            this.groupBox12.Location = new System.Drawing.Point(22, 157);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(395, 126);
            this.groupBox12.TabIndex = 19;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Niveles";
            // 
            // btnEle_ni
            // 
            this.btnEle_ni.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEle_ni.Image = ((System.Drawing.Image)(resources.GetObject("btnEle_ni.Image")));
            this.btnEle_ni.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEle_ni.Location = new System.Drawing.Point(303, 92);
            this.btnEle_ni.Name = "btnEle_ni";
            this.btnEle_ni.Size = new System.Drawing.Size(77, 27);
            this.btnEle_ni.TabIndex = 20;
            this.btnEle_ni.Text = "&Eliminar";
            this.btnEle_ni.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEle_ni.UseVisualStyleBackColor = true;
            this.btnEle_ni.Click += new System.EventHandler(this.btnEle_ni_Click);
            // 
            // dgwNiveles_ni
            // 
            this.dgwNiveles_ni.AllowUserToAddRows = false;
            this.dgwNiveles_ni.AllowUserToDeleteRows = false;
            this.dgwNiveles_ni.AllowUserToOrderColumns = true;
            this.dgwNiveles_ni.AllowUserToResizeRows = false;
            this.dgwNiveles_ni.BackgroundColor = System.Drawing.Color.White;
            this.dgwNiveles_ni.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwNiveles_ni.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CODIGO,
            this.DESCRIPCION});
            this.dgwNiveles_ni.Location = new System.Drawing.Point(6, 16);
            this.dgwNiveles_ni.MultiSelect = false;
            this.dgwNiveles_ni.Name = "dgwNiveles_ni";
            this.dgwNiveles_ni.ReadOnly = true;
            this.dgwNiveles_ni.RowHeadersWidth = 20;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            this.dgwNiveles_ni.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgwNiveles_ni.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dgwNiveles_ni.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.dgwNiveles_ni.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgwNiveles_ni.Size = new System.Drawing.Size(374, 72);
            this.dgwNiveles_ni.TabIndex = 16;
            this.dgwNiveles_ni.TabStop = false;
            this.dgwNiveles_ni.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGW5_CellContentClick);
            // 
            // CODIGO
            // 
            this.CODIGO.HeaderText = "Codigo";
            this.CODIGO.Name = "CODIGO";
            this.CODIGO.ReadOnly = true;
            this.CODIGO.Width = 50;
            // 
            // DESCRIPCION
            // 
            this.DESCRIPCION.HeaderText = "Nivel";
            this.DESCRIPCION.Name = "DESCRIPCION";
            this.DESCRIPCION.ReadOnly = true;
            this.DESCRIPCION.Width = 280;
            // 
            // btnAgre_ni
            // 
            this.btnAgre_ni.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgre_ni.Image = ((System.Drawing.Image)(resources.GetObject("btnAgre_ni.Image")));
            this.btnAgre_ni.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgre_ni.Location = new System.Drawing.Point(137, 92);
            this.btnAgre_ni.Name = "btnAgre_ni";
            this.btnAgre_ni.Size = new System.Drawing.Size(77, 27);
            this.btnAgre_ni.TabIndex = 18;
            this.btnAgre_ni.Text = "&Agregar";
            this.btnAgre_ni.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgre_ni.UseVisualStyleBackColor = true;
            this.btnAgre_ni.Click += new System.EventHandler(this.btnAgre_ni_Click);
            // 
            // btnMod_ni
            // 
            this.btnMod_ni.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMod_ni.Image = ((System.Drawing.Image)(resources.GetObject("btnMod_ni.Image")));
            this.btnMod_ni.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMod_ni.Location = new System.Drawing.Point(220, 92);
            this.btnMod_ni.Name = "btnMod_ni";
            this.btnMod_ni.Size = new System.Drawing.Size(77, 27);
            this.btnMod_ni.TabIndex = 19;
            this.btnMod_ni.Text = "&Modificar";
            this.btnMod_ni.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMod_ni.UseVisualStyleBackColor = true;
            this.btnMod_ni.Click += new System.EventHandler(this.btnMod_ni_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 14);
            this.label4.TabIndex = 20;
            this.label4.Text = "Grupo Planilla";
            // 
            // cboproceso
            // 
            this.cboproceso.BackColor = System.Drawing.Color.White;
            this.cboproceso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboproceso.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboproceso.FormattingEnabled = true;
            this.cboproceso.Items.AddRange(new object[] {
            "NATURAL",
            "JURIDICA",
            "SUJETOS NO DOMICILIADOS"});
            this.cboproceso.Location = new System.Drawing.Point(90, 133);
            this.cboproceso.Name = "cboproceso";
            this.cboproceso.Size = new System.Drawing.Size(135, 22);
            this.cboproceso.TabIndex = 5;
            // 
            // cboidentidad
            // 
            this.cboidentidad.BackColor = System.Drawing.Color.White;
            this.cboidentidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboidentidad.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboidentidad.FormattingEnabled = true;
            this.cboidentidad.Items.AddRange(new object[] {
            "NATURAL",
            "JURIDICA",
            "SUJETOS NO DOMICILIADOS"});
            this.cboidentidad.Location = new System.Drawing.Point(90, 110);
            this.cboidentidad.Name = "cboidentidad";
            this.cboidentidad.Size = new System.Drawing.Size(135, 22);
            this.cboidentidad.TabIndex = 4;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(20, 136);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(69, 14);
            this.label32.TabIndex = 18;
            this.label32.Text = "Cod Proceso";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(18, 115);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(72, 14);
            this.label31.TabIndex = 16;
            this.label31.Text = "Cod Identidad";
            // 
            // txtdescc
            // 
            this.txtdescc.BackColor = System.Drawing.Color.White;
            this.txtdescc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtdescc.Location = new System.Drawing.Point(90, 87);
            this.txtdescc.MaxLength = 20;
            this.txtdescc.Name = "txtdescc";
            this.txtdescc.Size = new System.Drawing.Size(243, 20);
            this.txtdescc.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 14);
            this.label3.TabIndex = 5;
            this.label3.Text = "Desc. Corta";
            // 
            // txt_desc
            // 
            this.txt_desc.BackColor = System.Drawing.Color.White;
            this.txt_desc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_desc.Location = new System.Drawing.Point(90, 64);
            this.txt_desc.MaxLength = 40;
            this.txt_desc.Name = "txt_desc";
            this.txt_desc.Size = new System.Drawing.Size(243, 20);
            this.txt_desc.TabIndex = 2;
            // 
            // txt_cod
            // 
            this.txt_cod.BackColor = System.Drawing.Color.White;
            this.txt_cod.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_cod.Location = new System.Drawing.Point(90, 18);
            this.txt_cod.MaxLength = 2;
            this.txt_cod.Name = "txt_cod";
            this.txt_cod.Size = new System.Drawing.Size(30, 20);
            this.txt_cod.TabIndex = 1;
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancelar.Image = ((System.Drawing.Image)(resources.GetObject("btn_cancelar.Image")));
            this.btn_cancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_cancelar.Location = new System.Drawing.Point(255, 303);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(77, 27);
            this.btn_cancelar.TabIndex = 7;
            this.btn_cancelar.Text = "&Cancelar";
            this.btn_cancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_cancelar.UseVisualStyleBackColor = true;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(19, 67);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(64, 14);
            this.Label2.TabIndex = 1;
            this.Label2.Text = "Descripción";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(19, 21);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(40, 14);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Codigo";
            // 
            // btn_guardar
            // 
            this.btn_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_guardar.Image = ((System.Drawing.Image)(resources.GetObject("btn_guardar.Image")));
            this.btn_guardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_guardar.Location = new System.Drawing.Point(174, 303);
            this.btn_guardar.Name = "btn_guardar";
            this.btn_guardar.Size = new System.Drawing.Size(77, 27);
            this.btn_guardar.TabIndex = 6;
            this.btn_guardar.Text = "&Guardar";
            this.btn_guardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_guardar.UseVisualStyleBackColor = true;
            this.btn_guardar.Click += new System.EventHandler(this.btn_guardar_Click);
            // 
            // btn_modificar2
            // 
            this.btn_modificar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_modificar2.Image = ((System.Drawing.Image)(resources.GetObject("btn_modificar2.Image")));
            this.btn_modificar2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_modificar2.Location = new System.Drawing.Point(174, 303);
            this.btn_modificar2.Name = "btn_modificar2";
            this.btn_modificar2.Size = new System.Drawing.Size(77, 27);
            this.btn_modificar2.TabIndex = 3;
            this.btn_modificar2.Text = "&Modificar";
            this.btn_modificar2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_modificar2.UseVisualStyleBackColor = true;
            this.btn_modificar2.Click += new System.EventHandler(this.btn_modificar2_Click);
            // 
            // INSTITUCIONES
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 381);
            this.ControlBox = false;
            this.Controls.Add(this.TabControl1);
            this.Name = "INSTITUCIONES";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "INSTITUCIONES";
            this.Load += new System.EventHandler(this.INSTITUCIONES_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.INSTITUCIONES_KeyDown);
            this.TabControl1.ResumeLayout(false);
            this.TabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgw1)).EndInit();
            this.TabPage2.ResumeLayout(false);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.panelNiveles.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox12.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgwNiveles_ni)).EndInit();
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
        internal System.Windows.Forms.TextBox txtdescc;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox txt_desc;
        internal System.Windows.Forms.TextBox txt_cod;
        internal System.Windows.Forms.Button btn_guardar;
        internal System.Windows.Forms.Button btn_modificar2;
        internal System.Windows.Forms.Button btn_cancelar;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.ComboBox cboproceso;
        internal System.Windows.Forms.ComboBox cboidentidad;
        internal System.Windows.Forms.Label label32;
        internal System.Windows.Forms.Label label31;
        internal System.Windows.Forms.ComboBox cbo_tipo_pla;
        internal System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox12;
        internal System.Windows.Forms.Panel panelNiveles;
        internal System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.TextBox txtCodigo_ni;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.TextBox txtDescripcion_ni;
        internal System.Windows.Forms.Button btnCancelar_ni;
        internal System.Windows.Forms.Button btnGuardar_ni;
        internal System.Windows.Forms.Label label11;
        internal System.Windows.Forms.Button btnModificar_ni;
        internal System.Windows.Forms.Button btnEle_ni;
        internal System.Windows.Forms.Button btnMod_ni;
        internal System.Windows.Forms.Button btnAgre_ni;
        internal System.Windows.Forms.DataGridView dgwNiveles_ni;
        private System.Windows.Forms.DataGridViewTextBoxColumn CODIGO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESCRIPCION;
        private System.Windows.Forms.DataGridViewTextBoxColumn cod;
        private System.Windows.Forms.DataGridViewTextBoxColumn desc;
        private System.Windows.Forms.DataGridViewTextBoxColumn descc;
        private System.Windows.Forms.DataGridViewTextBoxColumn codid;
        private System.Windows.Forms.DataGridViewTextBoxColumn codpro;
        private System.Windows.Forms.DataGridViewTextBoxColumn tip_pla;
    }
}