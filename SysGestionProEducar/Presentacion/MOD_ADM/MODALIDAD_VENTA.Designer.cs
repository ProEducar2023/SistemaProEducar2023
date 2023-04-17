namespace Presentacion.MOD_ADM
{
    partial class MODALIDAD_VENTA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MODALIDAD_VENTA));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.btn_salir = new System.Windows.Forms.Button();
            this.btn_eliminar = new System.Windows.Forms.Button();
            this.btn_modificar = new System.Windows.Forms.Button();
            this.btn_nuevo = new System.Windows.Forms.Button();
            this.dgw1 = new System.Windows.Forms.DataGridView();
            this.COD_MODALIDAD_VTA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESC_MODALIDAD_VTA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESC_CORTA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TabPage2 = new System.Windows.Forms.TabPage();
            this.TabControl2 = new System.Windows.Forms.TabControl();
            this.TabPage3 = new System.Windows.Forms.TabPage();
            this.Panel_v0 = new System.Windows.Forms.Panel();
            this.dgw = new System.Windows.Forms.DataGridView();
            this.codcc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipocc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_eliminar2 = new System.Windows.Forms.Button();
            this.btn_nuevo2 = new System.Windows.Forms.Button();
            this.Panel_v1 = new System.Windows.Forms.Panel();
            this.GroupBox5 = new System.Windows.Forms.GroupBox();
            this.cbo_tipo_venta = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_cancelar2 = new System.Windows.Forms.Button();
            this.btn_guardar2 = new System.Windows.Forms.Button();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_descc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_desc = new System.Windows.Forms.TextBox();
            this.txt_cod = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.btn_modificar2 = new System.Windows.Forms.Button();
            this.btn_guardar = new System.Windows.Forms.Button();
            this.TabControl1.SuspendLayout();
            this.TabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw1)).BeginInit();
            this.TabPage2.SuspendLayout();
            this.TabControl2.SuspendLayout();
            this.TabPage3.SuspendLayout();
            this.Panel_v0.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw)).BeginInit();
            this.Panel_v1.SuspendLayout();
            this.GroupBox5.SuspendLayout();
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
            this.TabControl1.Size = new System.Drawing.Size(592, 323);
            this.TabControl1.TabIndex = 6;
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
            this.TabPage1.Size = new System.Drawing.Size(584, 296);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "Lista ";
            this.TabPage1.UseVisualStyleBackColor = true;
            // 
            // btn_salir
            // 
            this.btn_salir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_salir.Image = ((System.Drawing.Image)(resources.GetObject("btn_salir.Image")));
            this.btn_salir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_salir.Location = new System.Drawing.Point(448, 147);
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
            this.btn_eliminar.Location = new System.Drawing.Point(448, 106);
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
            this.btn_modificar.Location = new System.Drawing.Point(448, 65);
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
            this.btn_nuevo.Location = new System.Drawing.Point(448, 24);
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
            this.COD_MODALIDAD_VTA,
            this.DESC_MODALIDAD_VTA,
            this.DESC_CORTA});
            this.dgw1.Location = new System.Drawing.Point(22, 24);
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
            this.dgw1.Size = new System.Drawing.Size(403, 200);
            this.dgw1.TabIndex = 0;
            // 
            // COD_MODALIDAD_VTA
            // 
            this.COD_MODALIDAD_VTA.FillWeight = 50.76142F;
            this.COD_MODALIDAD_VTA.HeaderText = "Cod";
            this.COD_MODALIDAD_VTA.Name = "COD_MODALIDAD_VTA";
            this.COD_MODALIDAD_VTA.ReadOnly = true;
            this.COD_MODALIDAD_VTA.Width = 60;
            // 
            // DESC_MODALIDAD_VTA
            // 
            this.DESC_MODALIDAD_VTA.HeaderText = "Modalidad";
            this.DESC_MODALIDAD_VTA.Name = "DESC_MODALIDAD_VTA";
            this.DESC_MODALIDAD_VTA.ReadOnly = true;
            this.DESC_MODALIDAD_VTA.Width = 170;
            // 
            // DESC_CORTA
            // 
            this.DESC_CORTA.HeaderText = "Abreviacion";
            this.DESC_CORTA.Name = "DESC_CORTA";
            this.DESC_CORTA.ReadOnly = true;
            this.DESC_CORTA.Width = 120;
            // 
            // TabPage2
            // 
            this.TabPage2.Controls.Add(this.TabControl2);
            this.TabPage2.Controls.Add(this.GroupBox1);
            this.TabPage2.Controls.Add(this.btn_cancelar);
            this.TabPage2.Controls.Add(this.btn_modificar2);
            this.TabPage2.Controls.Add(this.btn_guardar);
            this.TabPage2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabPage2.Location = new System.Drawing.Point(4, 23);
            this.TabPage2.Name = "TabPage2";
            this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage2.Size = new System.Drawing.Size(584, 296);
            this.TabPage2.TabIndex = 1;
            this.TabPage2.Text = "Detalles";
            this.TabPage2.UseVisualStyleBackColor = true;
            // 
            // TabControl2
            // 
            this.TabControl2.Controls.Add(this.TabPage3);
            this.TabControl2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabControl2.ItemSize = new System.Drawing.Size(450, 19);
            this.TabControl2.Location = new System.Drawing.Point(19, 101);
            this.TabControl2.Name = "TabControl2";
            this.TabControl2.SelectedIndex = 0;
            this.TabControl2.Size = new System.Drawing.Size(474, 189);
            this.TabControl2.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.TabControl2.TabIndex = 4;
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
            this.TabPage3.Size = new System.Drawing.Size(466, 162);
            this.TabPage3.TabIndex = 0;
            this.TabPage3.Text = "Tipos de Venta";
            this.TabPage3.UseVisualStyleBackColor = true;
            // 
            // Panel_v0
            // 
            this.Panel_v0.Controls.Add(this.dgw);
            this.Panel_v0.Controls.Add(this.btn_eliminar2);
            this.Panel_v0.Controls.Add(this.btn_nuevo2);
            this.Panel_v0.Location = new System.Drawing.Point(8, 6);
            this.Panel_v0.Name = "Panel_v0";
            this.Panel_v0.Size = new System.Drawing.Size(452, 155);
            this.Panel_v0.TabIndex = 5;
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
            this.tipocc});
            this.dgw.Location = new System.Drawing.Point(31, 15);
            this.dgw.MultiSelect = false;
            this.dgw.Name = "dgw";
            this.dgw.ReadOnly = true;
            this.dgw.RowHeadersWidth = 25;
            this.dgw.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dgw.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.dgw.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgw.Size = new System.Drawing.Size(303, 129);
            this.dgw.TabIndex = 0;
            // 
            // codcc
            // 
            this.codcc.FillWeight = 30.45685F;
            this.codcc.HeaderText = "Cod";
            this.codcc.Name = "codcc";
            this.codcc.ReadOnly = true;
            // 
            // tipocc
            // 
            this.tipocc.FillWeight = 169.5432F;
            this.tipocc.HeaderText = "Tipo de Venta";
            this.tipocc.MinimumWidth = 150;
            this.tipocc.Name = "tipocc";
            this.tipocc.ReadOnly = true;
            // 
            // btn_eliminar2
            // 
            this.btn_eliminar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_eliminar2.Image = ((System.Drawing.Image)(resources.GetObject("btn_eliminar2.Image")));
            this.btn_eliminar2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_eliminar2.Location = new System.Drawing.Point(352, 48);
            this.btn_eliminar2.Name = "btn_eliminar2";
            this.btn_eliminar2.Size = new System.Drawing.Size(77, 27);
            this.btn_eliminar2.TabIndex = 5;
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
            this.btn_nuevo2.Location = new System.Drawing.Point(352, 15);
            this.btn_nuevo2.Name = "btn_nuevo2";
            this.btn_nuevo2.Size = new System.Drawing.Size(77, 27);
            this.btn_nuevo2.TabIndex = 4;
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
            this.Panel_v1.Size = new System.Drawing.Size(434, 161);
            this.Panel_v1.TabIndex = 0;
            this.Panel_v1.Visible = false;
            // 
            // GroupBox5
            // 
            this.GroupBox5.Controls.Add(this.cbo_tipo_venta);
            this.GroupBox5.Controls.Add(this.label4);
            this.GroupBox5.Controls.Add(this.btn_cancelar2);
            this.GroupBox5.Controls.Add(this.btn_guardar2);
            this.GroupBox5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox5.Location = new System.Drawing.Point(13, 12);
            this.GroupBox5.Name = "GroupBox5";
            this.GroupBox5.Size = new System.Drawing.Size(398, 135);
            this.GroupBox5.TabIndex = 16;
            this.GroupBox5.TabStop = false;
            // 
            // cbo_tipo_venta
            // 
            this.cbo_tipo_venta.BackColor = System.Drawing.Color.White;
            this.cbo_tipo_venta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_tipo_venta.FormattingEnabled = true;
            this.cbo_tipo_venta.Items.AddRange(new object[] {
            "MERCADERIAS",
            "PRODUCTO TERMINADO",
            "ACTIVOS"});
            this.cbo_tipo_venta.Location = new System.Drawing.Point(121, 31);
            this.cbo_tipo_venta.Name = "cbo_tipo_venta";
            this.cbo_tipo_venta.Size = new System.Drawing.Size(250, 22);
            this.cbo_tipo_venta.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 14);
            this.label4.TabIndex = 7;
            this.label4.Text = "Tipo Venta";
            // 
            // btn_cancelar2
            // 
            this.btn_cancelar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancelar2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancelar2.Image = ((System.Drawing.Image)(resources.GetObject("btn_cancelar2.Image")));
            this.btn_cancelar2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_cancelar2.Location = new System.Drawing.Point(294, 87);
            this.btn_cancelar2.Name = "btn_cancelar2";
            this.btn_cancelar2.Size = new System.Drawing.Size(77, 27);
            this.btn_cancelar2.TabIndex = 4;
            this.btn_cancelar2.Text = "&Cancelar";
            this.btn_cancelar2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_cancelar2.UseVisualStyleBackColor = true;
            this.btn_cancelar2.Click += new System.EventHandler(this.btn_cancelar2_Click);
            // 
            // btn_guardar2
            // 
            this.btn_guardar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_guardar2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_guardar2.Image = ((System.Drawing.Image)(resources.GetObject("btn_guardar2.Image")));
            this.btn_guardar2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_guardar2.Location = new System.Drawing.Point(199, 87);
            this.btn_guardar2.Name = "btn_guardar2";
            this.btn_guardar2.Size = new System.Drawing.Size(77, 27);
            this.btn_guardar2.TabIndex = 3;
            this.btn_guardar2.Text = "&Guardar";
            this.btn_guardar2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_guardar2.UseVisualStyleBackColor = true;
            this.btn_guardar2.Click += new System.EventHandler(this.btn_guardar2_Click);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.txt_descc);
            this.GroupBox1.Controls.Add(this.label3);
            this.GroupBox1.Controls.Add(this.txt_desc);
            this.GroupBox1.Controls.Add(this.txt_cod);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Location = new System.Drawing.Point(19, 6);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(474, 91);
            this.GroupBox1.TabIndex = 1;
            this.GroupBox1.TabStop = false;
            // 
            // txt_descc
            // 
            this.txt_descc.BackColor = System.Drawing.Color.White;
            this.txt_descc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_descc.Location = new System.Drawing.Point(115, 66);
            this.txt_descc.MaxLength = 20;
            this.txt_descc.Name = "txt_descc";
            this.txt_descc.Size = new System.Drawing.Size(243, 20);
            this.txt_descc.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 14);
            this.label3.TabIndex = 6;
            this.label3.Text = "Descripción Corta";
            // 
            // txt_desc
            // 
            this.txt_desc.BackColor = System.Drawing.Color.White;
            this.txt_desc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_desc.Location = new System.Drawing.Point(115, 39);
            this.txt_desc.MaxLength = 30;
            this.txt_desc.Name = "txt_desc";
            this.txt_desc.Size = new System.Drawing.Size(243, 20);
            this.txt_desc.TabIndex = 2;
            // 
            // txt_cod
            // 
            this.txt_cod.BackColor = System.Drawing.Color.White;
            this.txt_cod.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_cod.Location = new System.Drawing.Point(115, 13);
            this.txt_cod.MaxLength = 2;
            this.txt_cod.Name = "txt_cod";
            this.txt_cod.Size = new System.Drawing.Size(30, 20);
            this.txt_cod.TabIndex = 1;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(20, 42);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(64, 14);
            this.Label2.TabIndex = 1;
            this.Label2.Text = "Descripción";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(21, 16);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(40, 14);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Codigo";
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancelar.Image = ((System.Drawing.Image)(resources.GetObject("btn_cancelar.Image")));
            this.btn_cancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_cancelar.Location = new System.Drawing.Point(499, 224);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(77, 27);
            this.btn_cancelar.TabIndex = 7;
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
            this.btn_modificar2.Location = new System.Drawing.Point(499, 155);
            this.btn_modificar2.Name = "btn_modificar2";
            this.btn_modificar2.Size = new System.Drawing.Size(77, 27);
            this.btn_modificar2.TabIndex = 6;
            this.btn_modificar2.Text = "&Modificar";
            this.btn_modificar2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_modificar2.UseVisualStyleBackColor = true;
            this.btn_modificar2.Click += new System.EventHandler(this.btn_modificar2_Click);
            // 
            // btn_guardar
            // 
            this.btn_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_guardar.Image = ((System.Drawing.Image)(resources.GetObject("btn_guardar.Image")));
            this.btn_guardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_guardar.Location = new System.Drawing.Point(499, 188);
            this.btn_guardar.Name = "btn_guardar";
            this.btn_guardar.Size = new System.Drawing.Size(77, 27);
            this.btn_guardar.TabIndex = 6;
            this.btn_guardar.Text = "&Guardar";
            this.btn_guardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_guardar.UseVisualStyleBackColor = true;
            this.btn_guardar.Click += new System.EventHandler(this.btn_guardar_Click);
            // 
            // MODALIDAD_VENTA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 323);
            this.Controls.Add(this.TabControl1);
            this.Name = "MODALIDAD_VENTA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MODALIDAD_VENTA";
            this.Load += new System.EventHandler(this.MODALIDAD_VENTA_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MODALIDAD_VENTA_KeyDown);
            this.TabControl1.ResumeLayout(false);
            this.TabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgw1)).EndInit();
            this.TabPage2.ResumeLayout(false);
            this.TabControl2.ResumeLayout(false);
            this.TabPage3.ResumeLayout(false);
            this.Panel_v0.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgw)).EndInit();
            this.Panel_v1.ResumeLayout(false);
            this.GroupBox5.ResumeLayout(false);
            this.GroupBox5.PerformLayout();
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
        internal System.Windows.Forms.TextBox txt_descc;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox txt_desc;
        internal System.Windows.Forms.TextBox txt_cod;
        internal System.Windows.Forms.Button btn_guardar;
        internal System.Windows.Forms.Button btn_modificar2;
        internal System.Windows.Forms.Button btn_cancelar;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.ComboBox cbo_tipo_venta;
        internal System.Windows.Forms.TabControl TabControl2;
        internal System.Windows.Forms.TabPage TabPage3;
        internal System.Windows.Forms.Panel Panel_v0;
        internal System.Windows.Forms.DataGridView dgw;
        internal System.Windows.Forms.Button btn_eliminar2;
        internal System.Windows.Forms.Button btn_nuevo2;
        internal System.Windows.Forms.Panel Panel_v1;
        internal System.Windows.Forms.GroupBox GroupBox5;
        internal System.Windows.Forms.Button btn_cancelar2;
        internal System.Windows.Forms.Button btn_guardar2;
        private System.Windows.Forms.DataGridViewTextBoxColumn codcc;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipocc;
        private System.Windows.Forms.DataGridViewTextBoxColumn COD_MODALIDAD_VTA;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESC_MODALIDAD_VTA;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESC_CORTA;
    }
}