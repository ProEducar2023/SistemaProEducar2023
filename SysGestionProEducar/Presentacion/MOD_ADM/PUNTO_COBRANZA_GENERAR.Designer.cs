namespace Presentacion.MOD_ADM
{
    partial class PUNTO_COBRANZA_GENERAR
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PUNTO_COBRANZA_GENERAR));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.btn_Vincular = new System.Windows.Forms.Button();
            this.GroupBox8 = new System.Windows.Forms.GroupBox();
            this.btn_sgt = new System.Windows.Forms.Button();
            this.ch_nc = new System.Windows.Forms.RadioButton();
            this.btn_buscar = new System.Windows.Forms.Button();
            this.ch_ca = new System.Windows.Forms.RadioButton();
            this.ch_rs = new System.Windows.Forms.RadioButton();
            this.txt_letra = new System.Windows.Forms.TextBox();
            this.btn_salir = new System.Windows.Forms.Button();
            this.btn_modificar = new System.Windows.Forms.Button();
            this.btn_eliminar = new System.Windows.Forms.Button();
            this.btn_nuevo = new System.Windows.Forms.Button();
            this.dgw = new System.Windows.Forms.DataGridView();
            this.TabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbo_zonas = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_dir = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.chb_st_inf = new System.Windows.Forms.CheckBox();
            this.cbo_tipo_pla = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cbosucursal = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cbo_formato = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cbo_sectorista = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.chbconsolidado = new System.Windows.Forms.CheckBox();
            this.txtcod = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboconvenio = new System.Windows.Forms.ComboBox();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.label25 = new System.Windows.Forms.Label();
            this.btn_modificar2 = new System.Windows.Forms.Button();
            this.btn_guardar = new System.Windows.Forms.Button();
            this.cbosituacion = new System.Windows.Forms.ComboBox();
            this.label31 = new System.Windows.Forms.Label();
            this.txtplanilla = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbopais = new System.Windows.Forms.ComboBox();
            this.cbodep = new System.Windows.Forms.ComboBox();
            this.cbodist = new System.Windows.Forms.ComboBox();
            this.cboprov = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtptocob = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboinst = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lbl_nro_reg = new System.Windows.Forms.Label();
            this.TabControl1.SuspendLayout();
            this.TabPage1.SuspendLayout();
            this.GroupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw)).BeginInit();
            this.TabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.TabControl1.Size = new System.Drawing.Size(683, 473);
            this.TabControl1.TabIndex = 1;
            this.TabControl1.SelectedIndexChanged += new System.EventHandler(this.TabControl1_SelectedIndexChanged);
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.lbl_nro_reg);
            this.TabPage1.Controls.Add(this.btn_Vincular);
            this.TabPage1.Controls.Add(this.GroupBox8);
            this.TabPage1.Controls.Add(this.btn_salir);
            this.TabPage1.Controls.Add(this.btn_modificar);
            this.TabPage1.Controls.Add(this.btn_eliminar);
            this.TabPage1.Controls.Add(this.btn_nuevo);
            this.TabPage1.Controls.Add(this.dgw);
            this.TabPage1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabPage1.Location = new System.Drawing.Point(4, 23);
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage1.Size = new System.Drawing.Size(675, 446);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "Lista de Puntos de Cobranza";
            this.TabPage1.UseVisualStyleBackColor = true;
            // 
            // btn_Vincular
            // 
            this.btn_Vincular.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Vincular.Image = ((System.Drawing.Image)(resources.GetObject("btn_Vincular.Image")));
            this.btn_Vincular.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Vincular.Location = new System.Drawing.Point(584, 186);
            this.btn_Vincular.Name = "btn_Vincular";
            this.btn_Vincular.Size = new System.Drawing.Size(85, 35);
            this.btn_Vincular.TabIndex = 6;
            this.btn_Vincular.Text = "&Vincular";
            this.btn_Vincular.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Vincular.UseVisualStyleBackColor = true;
            this.btn_Vincular.Click += new System.EventHandler(this.btn_Vincular_Click);
            // 
            // GroupBox8
            // 
            this.GroupBox8.Controls.Add(this.btn_sgt);
            this.GroupBox8.Controls.Add(this.ch_nc);
            this.GroupBox8.Controls.Add(this.btn_buscar);
            this.GroupBox8.Controls.Add(this.ch_ca);
            this.GroupBox8.Controls.Add(this.ch_rs);
            this.GroupBox8.Controls.Add(this.txt_letra);
            this.GroupBox8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox8.Location = new System.Drawing.Point(6, 356);
            this.GroupBox8.Name = "GroupBox8";
            this.GroupBox8.Size = new System.Drawing.Size(572, 72);
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
            // ch_nc
            // 
            this.ch_nc.AutoSize = true;
            this.ch_nc.Enabled = false;
            this.ch_nc.Font = new System.Drawing.Font("Arial", 8.25F);
            this.ch_nc.Location = new System.Drawing.Point(164, 45);
            this.ch_nc.Name = "ch_nc";
            this.ch_nc.Size = new System.Drawing.Size(130, 18);
            this.ch_nc.TabIndex = 4;
            this.ch_nc.Text = "Entidad de Descuento";
            this.ch_nc.UseVisualStyleBackColor = true;
            this.ch_nc.CheckedChanged += new System.EventHandler(this.ch_nc_CheckedChanged);
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
            this.btn_buscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            // ch_rs
            // 
            this.ch_rs.AutoSize = true;
            this.ch_rs.Checked = true;
            this.ch_rs.Font = new System.Drawing.Font("Arial", 8.25F);
            this.ch_rs.Location = new System.Drawing.Point(27, 45);
            this.ch_rs.Name = "ch_rs";
            this.ch_rs.Size = new System.Drawing.Size(102, 18);
            this.ch_rs.TabIndex = 3;
            this.ch_rs.TabStop = true;
            this.ch_rs.Text = "Punto Cobranza";
            this.ch_rs.UseVisualStyleBackColor = true;
            this.ch_rs.CheckedChanged += new System.EventHandler(this.ch_rs_CheckedChanged);
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
            this.btn_salir.Location = new System.Drawing.Point(584, 145);
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
            this.btn_modificar.Location = new System.Drawing.Point(584, 63);
            this.btn_modificar.Name = "btn_modificar";
            this.btn_modificar.Size = new System.Drawing.Size(85, 35);
            this.btn_modificar.TabIndex = 2;
            this.btn_modificar.Text = "&Modificar";
            this.btn_modificar.UseVisualStyleBackColor = true;
            this.btn_modificar.Click += new System.EventHandler(this.btn_modificar_Click);
            // 
            // btn_eliminar
            // 
            this.btn_eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_eliminar.Image = ((System.Drawing.Image)(resources.GetObject("btn_eliminar.Image")));
            this.btn_eliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_eliminar.Location = new System.Drawing.Point(584, 104);
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
            this.btn_nuevo.Location = new System.Drawing.Point(584, 22);
            this.btn_nuevo.Name = "btn_nuevo";
            this.btn_nuevo.Size = new System.Drawing.Size(85, 35);
            this.btn_nuevo.TabIndex = 1;
            this.btn_nuevo.Text = "&Nuevo";
            this.btn_nuevo.UseVisualStyleBackColor = true;
            this.btn_nuevo.Click += new System.EventHandler(this.btn_nuevo_Click);
            // 
            // dgw
            // 
            this.dgw.AllowUserToAddRows = false;
            this.dgw.AllowUserToDeleteRows = false;
            this.dgw.AllowUserToOrderColumns = true;
            this.dgw.AllowUserToResizeRows = false;
            this.dgw.BackgroundColor = System.Drawing.Color.White;
            this.dgw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgw.Location = new System.Drawing.Point(6, 22);
            this.dgw.MultiSelect = false;
            this.dgw.Name = "dgw";
            this.dgw.ReadOnly = true;
            this.dgw.RowHeadersWidth = 25;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            this.dgw.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgw.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dgw.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.dgw.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgw.Size = new System.Drawing.Size(572, 320);
            this.dgw.TabIndex = 0;
            // 
            // TabPage2
            // 
            this.TabPage2.Controls.Add(this.groupBox2);
            this.TabPage2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabPage2.Location = new System.Drawing.Point(4, 23);
            this.TabPage2.Name = "TabPage2";
            this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage2.Size = new System.Drawing.Size(675, 446);
            this.TabPage2.TabIndex = 1;
            this.TabPage2.Text = "Detalles";
            this.TabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.cbo_zonas);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txt_dir);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.chb_st_inf);
            this.groupBox2.Controls.Add(this.cbo_tipo_pla);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.cbosucursal);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.cbo_formato);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.cbo_sectorista);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.chbconsolidado);
            this.groupBox2.Controls.Add(this.txtcod);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cboconvenio);
            this.groupBox2.Controls.Add(this.btn_cancelar);
            this.groupBox2.Controls.Add(this.label25);
            this.groupBox2.Controls.Add(this.btn_guardar);
            this.groupBox2.Controls.Add(this.cbosituacion);
            this.groupBox2.Controls.Add(this.label31);
            this.groupBox2.Controls.Add(this.txtplanilla);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.cbopais);
            this.groupBox2.Controls.Add(this.cbodep);
            this.groupBox2.Controls.Add(this.cbodist);
            this.groupBox2.Controls.Add(this.cboprov);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtptocob);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.cboinst);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.btn_modificar2);
            this.groupBox2.Location = new System.Drawing.Point(7, 14);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(658, 414);
            this.groupBox2.TabIndex = 37;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos";
            // 
            // cbo_zonas
            // 
            this.cbo_zonas.BackColor = System.Drawing.Color.White;
            this.cbo_zonas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_zonas.FormattingEnabled = true;
            this.cbo_zonas.Location = new System.Drawing.Point(163, 274);
            this.cbo_zonas.Name = "cbo_zonas";
            this.cbo_zonas.Size = new System.Drawing.Size(246, 22);
            this.cbo_zonas.TabIndex = 64;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(100, 277);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 14);
            this.label8.TabIndex = 65;
            this.label8.Text = "Zonas";
            // 
            // txt_dir
            // 
            this.txt_dir.Location = new System.Drawing.Point(163, 199);
            this.txt_dir.MaxLength = 80;
            this.txt_dir.Name = "txt_dir";
            this.txt_dir.Size = new System.Drawing.Size(423, 20);
            this.txt_dir.TabIndex = 9;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(99, 202);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(52, 14);
            this.label14.TabIndex = 63;
            this.label14.Text = "Direccion";
            // 
            // chb_st_inf
            // 
            this.chb_st_inf.AutoSize = true;
            this.chb_st_inf.Location = new System.Drawing.Point(323, 328);
            this.chb_st_inf.Name = "chb_st_inf";
            this.chb_st_inf.Size = new System.Drawing.Size(175, 18);
            this.chb_st_inf.TabIndex = 14;
            this.chb_st_inf.Text = "Status Consolidado Informativo";
            this.chb_st_inf.UseVisualStyleBackColor = true;
            // 
            // cbo_tipo_pla
            // 
            this.cbo_tipo_pla.BackColor = System.Drawing.Color.White;
            this.cbo_tipo_pla.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_tipo_pla.FormattingEnabled = true;
            this.cbo_tipo_pla.Location = new System.Drawing.Point(164, 94);
            this.cbo_tipo_pla.Name = "cbo_tipo_pla";
            this.cbo_tipo_pla.Size = new System.Drawing.Size(246, 22);
            this.cbo_tipo_pla.TabIndex = 4;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(94, 97);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(62, 14);
            this.label13.TabIndex = 60;
            this.label13.Text = "Tipo Planilla";
            // 
            // cbosucursal
            // 
            this.cbosucursal.BackColor = System.Drawing.Color.White;
            this.cbosucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbosucursal.FormattingEnabled = true;
            this.cbosucursal.Location = new System.Drawing.Point(163, 43);
            this.cbosucursal.Name = "cbosucursal";
            this.cbosucursal.Size = new System.Drawing.Size(246, 22);
            this.cbosucursal.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(100, 46);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(50, 14);
            this.label12.TabIndex = 58;
            this.label12.Text = "Sucursal";
            // 
            // cbo_formato
            // 
            this.cbo_formato.BackColor = System.Drawing.Color.White;
            this.cbo_formato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_formato.Enabled = false;
            this.cbo_formato.FormattingEnabled = true;
            this.cbo_formato.Location = new System.Drawing.Point(163, 378);
            this.cbo_formato.Name = "cbo_formato";
            this.cbo_formato.Size = new System.Drawing.Size(246, 22);
            this.cbo_formato.TabIndex = 16;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(111, 382);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(46, 14);
            this.label11.TabIndex = 56;
            this.label11.Text = "Formato";
            // 
            // cbo_sectorista
            // 
            this.cbo_sectorista.BackColor = System.Drawing.Color.White;
            this.cbo_sectorista.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_sectorista.Enabled = false;
            this.cbo_sectorista.FormattingEnabled = true;
            this.cbo_sectorista.Location = new System.Drawing.Point(163, 350);
            this.cbo_sectorista.Name = "cbo_sectorista";
            this.cbo_sectorista.Size = new System.Drawing.Size(246, 22);
            this.cbo_sectorista.TabIndex = 15;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(100, 353);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 14);
            this.label10.TabIndex = 54;
            this.label10.Text = "Sectorista";
            // 
            // chbconsolidado
            // 
            this.chbconsolidado.AutoSize = true;
            this.chbconsolidado.Location = new System.Drawing.Point(164, 328);
            this.chbconsolidado.Name = "chbconsolidado";
            this.chbconsolidado.Size = new System.Drawing.Size(162, 18);
            this.chbconsolidado.TabIndex = 13;
            this.chbconsolidado.Text = "Status Consolidado Proceso";
            this.chbconsolidado.UseVisualStyleBackColor = true;
            this.chbconsolidado.CheckedChanged += new System.EventHandler(this.chbconsolidado_CheckedChanged);
            // 
            // txtcod
            // 
            this.txtcod.Location = new System.Drawing.Point(163, 18);
            this.txtcod.MaxLength = 80;
            this.txtcod.Name = "txtcod";
            this.txtcod.Size = new System.Drawing.Size(63, 20);
            this.txtcod.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(113, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 14);
            this.label1.TabIndex = 50;
            this.label1.Text = "Codigo";
            // 
            // cboconvenio
            // 
            this.cboconvenio.BackColor = System.Drawing.Color.White;
            this.cboconvenio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboconvenio.FormattingEnabled = true;
            this.cboconvenio.Items.AddRange(new object[] {
            "SI",
            "NO"});
            this.cboconvenio.Location = new System.Drawing.Point(163, 223);
            this.cboconvenio.Name = "cboconvenio";
            this.cboconvenio.Size = new System.Drawing.Size(171, 22);
            this.cboconvenio.TabIndex = 10;
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancelar.Image = ((System.Drawing.Image)(resources.GetObject("btn_cancelar.Image")));
            this.btn_cancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_cancelar.Location = new System.Drawing.Point(501, 325);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(85, 35);
            this.btn_cancelar.TabIndex = 18;
            this.btn_cancelar.Text = "&Cancelar";
            this.btn_cancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_cancelar.UseVisualStyleBackColor = true;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(100, 226);
            this.label25.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(55, 14);
            this.label25.TabIndex = 48;
            this.label25.Text = "Convenio ";
            // 
            // btn_modificar2
            // 
            this.btn_modificar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_modificar2.Image = ((System.Drawing.Image)(resources.GetObject("btn_modificar2.Image")));
            this.btn_modificar2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_modificar2.Location = new System.Drawing.Point(501, 284);
            this.btn_modificar2.Name = "btn_modificar2";
            this.btn_modificar2.Size = new System.Drawing.Size(85, 35);
            this.btn_modificar2.TabIndex = 17;
            this.btn_modificar2.Text = "&Guardar";
            this.btn_modificar2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_modificar2.UseVisualStyleBackColor = true;
            this.btn_modificar2.Click += new System.EventHandler(this.btn_modificar2_Click);
            // 
            // btn_guardar
            // 
            this.btn_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_guardar.Image = ((System.Drawing.Image)(resources.GetObject("btn_guardar.Image")));
            this.btn_guardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_guardar.Location = new System.Drawing.Point(501, 284);
            this.btn_guardar.Name = "btn_guardar";
            this.btn_guardar.Size = new System.Drawing.Size(85, 35);
            this.btn_guardar.TabIndex = 17;
            this.btn_guardar.Text = "&Guardar";
            this.btn_guardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_guardar.UseVisualStyleBackColor = true;
            this.btn_guardar.Click += new System.EventHandler(this.btn_guardar_Click);
            // 
            // cbosituacion
            // 
            this.cbosituacion.BackColor = System.Drawing.Color.White;
            this.cbosituacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbosituacion.FormattingEnabled = true;
            this.cbosituacion.Location = new System.Drawing.Point(163, 248);
            this.cbosituacion.Name = "cbosituacion";
            this.cbosituacion.Size = new System.Drawing.Size(246, 22);
            this.cbosituacion.TabIndex = 11;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(100, 251);
            this.label31.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(54, 14);
            this.label31.TabIndex = 46;
            this.label31.Text = "Situacion ";
            // 
            // txtplanilla
            // 
            this.txtplanilla.Location = new System.Drawing.Point(163, 302);
            this.txtplanilla.MaxLength = 10;
            this.txtplanilla.Name = "txtplanilla";
            this.txtplanilla.Size = new System.Drawing.Size(63, 20);
            this.txtplanilla.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(34, 305);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(126, 14);
            this.label9.TabIndex = 45;
            this.label9.Text = "Dia Presentacion Planilla ";
            // 
            // cbopais
            // 
            this.cbopais.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbopais.FormattingEnabled = true;
            this.cbopais.Location = new System.Drawing.Point(163, 145);
            this.cbopais.Name = "cbopais";
            this.cbopais.Size = new System.Drawing.Size(171, 22);
            this.cbopais.TabIndex = 5;
            this.cbopais.SelectedIndexChanged += new System.EventHandler(this.cbopais_SelectedIndexChanged);
            // 
            // cbodep
            // 
            this.cbodep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbodep.FormattingEnabled = true;
            this.cbodep.Location = new System.Drawing.Point(422, 145);
            this.cbodep.Name = "cbodep";
            this.cbodep.Size = new System.Drawing.Size(164, 22);
            this.cbodep.TabIndex = 6;
            this.cbodep.SelectedIndexChanged += new System.EventHandler(this.cbodep_SelectedIndexChanged);
            // 
            // cbodist
            // 
            this.cbodist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbodist.FormattingEnabled = true;
            this.cbodist.Location = new System.Drawing.Point(422, 172);
            this.cbodist.Name = "cbodist";
            this.cbodist.Size = new System.Drawing.Size(164, 22);
            this.cbodist.TabIndex = 8;
            // 
            // cboprov
            // 
            this.cboprov.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboprov.FormattingEnabled = true;
            this.cboprov.Location = new System.Drawing.Point(163, 172);
            this.cboprov.Name = "cboprov";
            this.cboprov.Size = new System.Drawing.Size(171, 22);
            this.cboprov.TabIndex = 7;
            this.cboprov.SelectedIndexChanged += new System.EventHandler(this.cboprov_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(121, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 14);
            this.label2.TabIndex = 41;
            this.label2.Text = "País";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(340, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 14);
            this.label3.TabIndex = 39;
            this.label3.Text = "Departamento";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(101, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 14);
            this.label4.TabIndex = 37;
            this.label4.Text = "Provincia";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(371, 175);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 14);
            this.label5.TabIndex = 35;
            this.label5.Text = "Distrito";
            // 
            // txtptocob
            // 
            this.txtptocob.BackColor = System.Drawing.Color.White;
            this.txtptocob.Location = new System.Drawing.Point(163, 120);
            this.txtptocob.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtptocob.MaxLength = 60;
            this.txtptocob.Name = "txtptocob";
            this.txtptocob.Size = new System.Drawing.Size(423, 20);
            this.txtptocob.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(55, 123);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 14);
            this.label6.TabIndex = 31;
            this.label6.Text = "Punto de Cobranza ";
            // 
            // cboinst
            // 
            this.cboinst.BackColor = System.Drawing.Color.White;
            this.cboinst.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboinst.FormattingEnabled = true;
            this.cboinst.Location = new System.Drawing.Point(163, 69);
            this.cboinst.Name = "cboinst";
            this.cboinst.Size = new System.Drawing.Size(246, 22);
            this.cboinst.TabIndex = 3;
            this.cboinst.SelectedIndexChanged += new System.EventHandler(this.cboinst_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(100, 72);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 14);
            this.label7.TabIndex = 29;
            this.label7.Text = "Institución ";
            // 
            // lbl_nro_reg
            // 
            this.lbl_nro_reg.AutoSize = true;
            this.lbl_nro_reg.Location = new System.Drawing.Point(452, 5);
            this.lbl_nro_reg.Name = "lbl_nro_reg";
            this.lbl_nro_reg.Size = new System.Drawing.Size(103, 14);
            this.lbl_nro_reg.TabIndex = 41;
            this.lbl_nro_reg.Text = "Nro de Registros : 0";
            // 
            // PUNTO_COBRANZA_GENERAR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 473);
            this.Controls.Add(this.TabControl1);
            this.Name = "PUNTO_COBRANZA_GENERAR";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Punto de Cobranza";
            this.Load += new System.EventHandler(this.PUNTO_COBRANZA_GENERAR_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PUNTO_COBRANZA_GENERAR_KeyDown);
            this.TabControl1.ResumeLayout(false);
            this.TabPage1.ResumeLayout(false);
            this.TabPage1.PerformLayout();
            this.GroupBox8.ResumeLayout(false);
            this.GroupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw)).EndInit();
            this.TabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TabControl TabControl1;
        internal System.Windows.Forms.TabPage TabPage1;
        internal System.Windows.Forms.GroupBox GroupBox8;
        internal System.Windows.Forms.Button btn_sgt;
        internal System.Windows.Forms.RadioButton ch_nc;
        internal System.Windows.Forms.Button btn_buscar;
        internal System.Windows.Forms.RadioButton ch_ca;
        internal System.Windows.Forms.RadioButton ch_rs;
        internal System.Windows.Forms.TextBox txt_letra;
        internal System.Windows.Forms.Button btn_salir;
        internal System.Windows.Forms.Button btn_modificar;
        internal System.Windows.Forms.Button btn_eliminar;
        internal System.Windows.Forms.Button btn_nuevo;
        internal System.Windows.Forms.DataGridView dgw;
        internal System.Windows.Forms.TabPage TabPage2;
        internal System.Windows.Forms.Button btn_cancelar;
        internal System.Windows.Forms.Button btn_modificar2;
        internal System.Windows.Forms.Button btn_guardar;
        private System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.TextBox txtplanilla;
        internal System.Windows.Forms.Label label9;
        internal System.Windows.Forms.ComboBox cbopais;
        internal System.Windows.Forms.ComboBox cbodep;
        internal System.Windows.Forms.ComboBox cbodist;
        internal System.Windows.Forms.ComboBox cboprov;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.TextBox txtptocob;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.ComboBox cboinst;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.ComboBox cboconvenio;
        internal System.Windows.Forms.Label label25;
        internal System.Windows.Forms.ComboBox cbosituacion;
        internal System.Windows.Forms.Label label31;
        private System.Windows.Forms.CheckBox chbconsolidado;
        internal System.Windows.Forms.TextBox txtcod;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.ComboBox cbo_sectorista;
        internal System.Windows.Forms.Label label10;
        internal System.Windows.Forms.ComboBox cbo_formato;
        internal System.Windows.Forms.Label label11;
        internal System.Windows.Forms.ComboBox cbosucursal;
        internal System.Windows.Forms.Label label12;
        internal System.Windows.Forms.ComboBox cbo_tipo_pla;
        internal System.Windows.Forms.Label label13;
        internal System.Windows.Forms.TextBox txt_dir;
        internal System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox chb_st_inf;
        internal System.Windows.Forms.Button btn_Vincular;
        internal System.Windows.Forms.ComboBox cbo_zonas;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.Label lbl_nro_reg;

    }
}