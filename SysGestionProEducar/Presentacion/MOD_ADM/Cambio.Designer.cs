namespace Presentacion.MOD_ADM
{
    partial class Cambio
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cambio));
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.dgw1 = new System.Windows.Forms.DataGridView();
            this.cbo_año = new System.Windows.Forms.ComboBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.btn_Nuevo = new System.Windows.Forms.Button();
            this.cbo_mes = new System.Windows.Forms.ComboBox();
            this.btn_Modificar = new System.Windows.Forms.Button();
            this.Label7 = new System.Windows.Forms.Label();
            this.btn_eliminar = new System.Windows.Forms.Button();
            this.btn_salir = new System.Windows.Forms.Button();
            this.TabPage2 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.GroupBox();
            this.txt_compra_paralelo = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_venta_paralelo = new System.Windows.Forms.TextBox();
            this.btn_guardar = new System.Windows.Forms.Button();
            this.Label2 = new System.Windows.Forms.Label();
            this.btn_modificar2 = new System.Windows.Forms.Button();
            this.txt_compra = new System.Windows.Forms.TextBox();
            this.btn_Cancelar = new System.Windows.Forms.Button();
            this.cbo_moneda1 = new System.Windows.Forms.ComboBox();
            this.dtp1 = new System.Windows.Forms.DateTimePicker();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.txt_venta = new System.Windows.Forms.TextBox();
            this.TabPage3 = new System.Windows.Forms.TabPage();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.Button1 = new System.Windows.Forms.Button();
            this.gb1 = new System.Windows.Forms.GroupBox();
            this.btn_archivo1 = new System.Windows.Forms.Button();
            this.btn_imprimir1 = new System.Windows.Forms.Button();
            this.btn_pantalla1 = new System.Windows.Forms.Button();
            this.dtp_al = new System.Windows.Forms.DateTimePicker();
            this.dtp_del = new System.Windows.Forms.DateTimePicker();
            this.Label9 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.cbo_moneda2 = new System.Windows.Forms.ComboBox();
            this.TabControl1.SuspendLayout();
            this.TabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw1)).BeginInit();
            this.TabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.TabPage3.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.gb1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControl1
            // 
            this.TabControl1.Controls.Add(this.TabPage1);
            this.TabControl1.Controls.Add(this.TabPage2);
            this.TabControl1.Controls.Add(this.TabPage3);
            this.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabControl1.ItemSize = new System.Drawing.Size(277, 18);
            this.TabControl1.Location = new System.Drawing.Point(0, 0);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(542, 310);
            this.TabControl1.TabIndex = 4;
            // 
            // TabPage1
            // 
            this.TabPage1.BackColor = System.Drawing.Color.Transparent;
            this.TabPage1.Controls.Add(this.dgw1);
            this.TabPage1.Controls.Add(this.cbo_año);
            this.TabPage1.Controls.Add(this.Label8);
            this.TabPage1.Controls.Add(this.btn_Nuevo);
            this.TabPage1.Controls.Add(this.cbo_mes);
            this.TabPage1.Controls.Add(this.btn_Modificar);
            this.TabPage1.Controls.Add(this.Label7);
            this.TabPage1.Controls.Add(this.btn_eliminar);
            this.TabPage1.Controls.Add(this.btn_salir);
            this.TabPage1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabPage1.Location = new System.Drawing.Point(4, 22);
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage1.Size = new System.Drawing.Size(534, 284);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "Tabla de Cambios";
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
            this.dgw1.Location = new System.Drawing.Point(29, 70);
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
            this.dgw1.Size = new System.Drawing.Size(380, 200);
            this.dgw1.TabIndex = 9;
            // 
            // cbo_año
            // 
            this.cbo_año.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_año.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_año.FormattingEnabled = true;
            this.cbo_año.Location = new System.Drawing.Point(225, 23);
            this.cbo_año.Name = "cbo_año";
            this.cbo_año.Size = new System.Drawing.Size(68, 22);
            this.cbo_año.TabIndex = 0;
            this.cbo_año.TabStop = false;
            this.cbo_año.SelectedIndexChanged += new System.EventHandler(this.cbo_año_SelectedIndexChanged);
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label8.Location = new System.Drawing.Point(189, 26);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(30, 14);
            this.Label8.TabIndex = 8;
            this.Label8.Text = "Año:";
            // 
            // btn_Nuevo
            // 
            this.btn_Nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Nuevo.Image = ((System.Drawing.Image)(resources.GetObject("btn_Nuevo.Image")));
            this.btn_Nuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Nuevo.Location = new System.Drawing.Point(431, 70);
            this.btn_Nuevo.Name = "btn_Nuevo";
            this.btn_Nuevo.Size = new System.Drawing.Size(85, 35);
            this.btn_Nuevo.TabIndex = 1;
            this.btn_Nuevo.Text = "&Nuevo";
            this.btn_Nuevo.UseVisualStyleBackColor = true;
            this.btn_Nuevo.Click += new System.EventHandler(this.btn_Nuevo_Click);
            // 
            // cbo_mes
            // 
            this.cbo_mes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_mes.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_mes.FormattingEnabled = true;
            this.cbo_mes.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12"});
            this.cbo_mes.Location = new System.Drawing.Point(62, 23);
            this.cbo_mes.Name = "cbo_mes";
            this.cbo_mes.Size = new System.Drawing.Size(121, 22);
            this.cbo_mes.TabIndex = 0;
            this.cbo_mes.TabStop = false;
            this.cbo_mes.SelectedIndexChanged += new System.EventHandler(this.cbo_mes_SelectedIndexChanged);
            // 
            // btn_Modificar
            // 
            this.btn_Modificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Modificar.Image = ((System.Drawing.Image)(resources.GetObject("btn_Modificar.Image")));
            this.btn_Modificar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Modificar.Location = new System.Drawing.Point(431, 111);
            this.btn_Modificar.Name = "btn_Modificar";
            this.btn_Modificar.Size = new System.Drawing.Size(85, 35);
            this.btn_Modificar.TabIndex = 2;
            this.btn_Modificar.Text = "&Modificar";
            this.btn_Modificar.UseVisualStyleBackColor = true;
            this.btn_Modificar.Click += new System.EventHandler(this.btn_Modificar_Click);
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label7.Location = new System.Drawing.Point(26, 26);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(33, 14);
            this.Label7.TabIndex = 6;
            this.Label7.Text = "Mes :";
            // 
            // btn_eliminar
            // 
            this.btn_eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_eliminar.Image = ((System.Drawing.Image)(resources.GetObject("btn_eliminar.Image")));
            this.btn_eliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_eliminar.Location = new System.Drawing.Point(431, 152);
            this.btn_eliminar.Name = "btn_eliminar";
            this.btn_eliminar.Size = new System.Drawing.Size(85, 35);
            this.btn_eliminar.TabIndex = 3;
            this.btn_eliminar.Text = "&Eliminar";
            this.btn_eliminar.UseVisualStyleBackColor = true;
            this.btn_eliminar.Click += new System.EventHandler(this.btn_eliminar_Click);
            // 
            // btn_salir
            // 
            this.btn_salir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_salir.Image = ((System.Drawing.Image)(resources.GetObject("btn_salir.Image")));
            this.btn_salir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_salir.Location = new System.Drawing.Point(431, 193);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(85, 35);
            this.btn_salir.TabIndex = 4;
            this.btn_salir.Text = "&Salir";
            this.btn_salir.UseVisualStyleBackColor = true;
            this.btn_salir.Click += new System.EventHandler(this.btn_salir_Click);
            // 
            // TabPage2
            // 
            this.TabPage2.Controls.Add(this.panel1);
            this.TabPage2.Location = new System.Drawing.Point(4, 22);
            this.TabPage2.Name = "TabPage2";
            this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage2.Size = new System.Drawing.Size(534, 284);
            this.TabPage2.TabIndex = 1;
            this.TabPage2.Text = "Detalles";
            this.TabPage2.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txt_compra_paralelo);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.txt_venta_paralelo);
            this.panel1.Controls.Add(this.btn_guardar);
            this.panel1.Controls.Add(this.Label2);
            this.panel1.Controls.Add(this.btn_modificar2);
            this.panel1.Controls.Add(this.txt_compra);
            this.panel1.Controls.Add(this.btn_Cancelar);
            this.panel1.Controls.Add(this.cbo_moneda1);
            this.panel1.Controls.Add(this.dtp1);
            this.panel1.Controls.Add(this.Label3);
            this.panel1.Controls.Add(this.Label1);
            this.panel1.Controls.Add(this.Label4);
            this.panel1.Controls.Add(this.txt_venta);
            this.panel1.Font = new System.Drawing.Font("Arial", 8.25F);
            this.panel1.Location = new System.Drawing.Point(23, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(484, 222);
            this.panel1.TabIndex = 31;
            this.panel1.TabStop = false;
            // 
            // txt_compra_paralelo
            // 
            this.txt_compra_paralelo.BackColor = System.Drawing.Color.White;
            this.txt_compra_paralelo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_compra_paralelo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_compra_paralelo.Location = new System.Drawing.Point(119, 134);
            this.txt_compra_paralelo.MaxLength = 10;
            this.txt_compra_paralelo.Name = "txt_compra_paralelo";
            this.txt_compra_paralelo.Size = new System.Drawing.Size(92, 20);
            this.txt_compra_paralelo.TabIndex = 29;
            this.txt_compra_paralelo.Tag = "";
            this.txt_compra_paralelo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(244, 137);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 14);
            this.label10.TabIndex = 31;
            this.label10.Text = "V. Venta Paralelo";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(22, 137);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(98, 14);
            this.label11.TabIndex = 32;
            this.label11.Text = "V. Compra Paralelo";
            // 
            // txt_venta_paralelo
            // 
            this.txt_venta_paralelo.BackColor = System.Drawing.Color.White;
            this.txt_venta_paralelo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_venta_paralelo.Location = new System.Drawing.Point(334, 137);
            this.txt_venta_paralelo.Name = "txt_venta_paralelo";
            this.txt_venta_paralelo.Size = new System.Drawing.Size(92, 20);
            this.txt_venta_paralelo.TabIndex = 30;
            this.txt_venta_paralelo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btn_guardar
            // 
            this.btn_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_guardar.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_guardar.Image = ((System.Drawing.Image)(resources.GetObject("btn_guardar.Image")));
            this.btn_guardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_guardar.Location = new System.Drawing.Point(266, 174);
            this.btn_guardar.Name = "btn_guardar";
            this.btn_guardar.Size = new System.Drawing.Size(77, 27);
            this.btn_guardar.TabIndex = 5;
            this.btn_guardar.Text = "&Guardar";
            this.btn_guardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_guardar.UseVisualStyleBackColor = true;
            this.btn_guardar.Click += new System.EventHandler(this.btn_guardar_Click);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(23, 29);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(45, 14);
            this.Label2.TabIndex = 15;
            this.Label2.Text = "Moneda";
            // 
            // btn_modificar2
            // 
            this.btn_modificar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_modificar2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_modificar2.Image = ((System.Drawing.Image)(resources.GetObject("btn_modificar2.Image")));
            this.btn_modificar2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_modificar2.Location = new System.Drawing.Point(266, 174);
            this.btn_modificar2.Name = "btn_modificar2";
            this.btn_modificar2.Size = new System.Drawing.Size(77, 27);
            this.btn_modificar2.TabIndex = 5;
            this.btn_modificar2.Text = "&Modificar";
            this.btn_modificar2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_modificar2.UseVisualStyleBackColor = true;
            this.btn_modificar2.Click += new System.EventHandler(this.btn_modificar2_Click);
            // 
            // txt_compra
            // 
            this.txt_compra.BackColor = System.Drawing.Color.White;
            this.txt_compra.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_compra.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_compra.Location = new System.Drawing.Point(119, 100);
            this.txt_compra.MaxLength = 10;
            this.txt_compra.Name = "txt_compra";
            this.txt_compra.Size = new System.Drawing.Size(92, 20);
            this.txt_compra.TabIndex = 3;
            this.txt_compra.Tag = "";
            this.txt_compra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btn_Cancelar
            // 
            this.btn_Cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cancelar.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cancelar.Image = ((System.Drawing.Image)(resources.GetObject("btn_Cancelar.Image")));
            this.btn_Cancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Cancelar.Location = new System.Drawing.Point(349, 174);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Size = new System.Drawing.Size(77, 27);
            this.btn_Cancelar.TabIndex = 6;
            this.btn_Cancelar.Text = "&Cancelar";
            this.btn_Cancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Cancelar.UseVisualStyleBackColor = true;
            this.btn_Cancelar.Click += new System.EventHandler(this.btn_Cancelar_Click);
            // 
            // cbo_moneda1
            // 
            this.cbo_moneda1.BackColor = System.Drawing.Color.White;
            this.cbo_moneda1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_moneda1.DropDownWidth = 115;
            this.cbo_moneda1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_moneda1.FormattingEnabled = true;
            this.cbo_moneda1.Location = new System.Drawing.Point(119, 26);
            this.cbo_moneda1.Name = "cbo_moneda1";
            this.cbo_moneda1.Size = new System.Drawing.Size(132, 22);
            this.cbo_moneda1.TabIndex = 1;
            // 
            // dtp1
            // 
            this.dtp1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp1.Location = new System.Drawing.Point(119, 64);
            this.dtp1.Name = "dtp1";
            this.dtp1.Size = new System.Drawing.Size(83, 20);
            this.dtp1.TabIndex = 2;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(244, 103);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(63, 14);
            this.Label3.TabIndex = 16;
            this.Label3.Text = "Valor Venta";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(23, 67);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(37, 14);
            this.Label1.TabIndex = 28;
            this.Label1.Text = "Fecha";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(23, 103);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(72, 14);
            this.Label4.TabIndex = 17;
            this.Label4.Text = "Valor Compra";
            // 
            // txt_venta
            // 
            this.txt_venta.BackColor = System.Drawing.Color.White;
            this.txt_venta.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_venta.Location = new System.Drawing.Point(334, 103);
            this.txt_venta.Name = "txt_venta";
            this.txt_venta.Size = new System.Drawing.Size(92, 20);
            this.txt_venta.TabIndex = 4;
            this.txt_venta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // TabPage3
            // 
            this.TabPage3.Controls.Add(this.GroupBox2);
            this.TabPage3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabPage3.Location = new System.Drawing.Point(4, 22);
            this.TabPage3.Name = "TabPage3";
            this.TabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage3.Size = new System.Drawing.Size(534, 284);
            this.TabPage3.TabIndex = 2;
            this.TabPage3.Text = "Reporte";
            this.TabPage3.UseVisualStyleBackColor = true;
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.Button1);
            this.GroupBox2.Controls.Add(this.gb1);
            this.GroupBox2.Controls.Add(this.dtp_al);
            this.GroupBox2.Controls.Add(this.dtp_del);
            this.GroupBox2.Controls.Add(this.Label9);
            this.GroupBox2.Controls.Add(this.Label6);
            this.GroupBox2.Controls.Add(this.Label5);
            this.GroupBox2.Controls.Add(this.cbo_moneda2);
            this.GroupBox2.Location = new System.Drawing.Point(32, 24);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(461, 237);
            this.GroupBox2.TabIndex = 0;
            this.GroupBox2.TabStop = false;
            // 
            // Button1
            // 
            this.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button1.Image = ((System.Drawing.Image)(resources.GetObject("Button1.Image")));
            this.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Button1.Location = new System.Drawing.Point(303, 129);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(77, 27);
            this.Button1.TabIndex = 132;
            this.Button1.Text = "&Cancelar";
            this.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // gb1
            // 
            this.gb1.BackColor = System.Drawing.Color.White;
            this.gb1.Controls.Add(this.btn_archivo1);
            this.gb1.Controls.Add(this.btn_imprimir1);
            this.gb1.Controls.Add(this.btn_pantalla1);
            this.gb1.Location = new System.Drawing.Point(119, 174);
            this.gb1.Name = "gb1";
            this.gb1.Size = new System.Drawing.Size(261, 47);
            this.gb1.TabIndex = 131;
            this.gb1.TabStop = false;
            // 
            // btn_archivo1
            // 
            this.btn_archivo1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_archivo1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_archivo1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_archivo1.Location = new System.Drawing.Point(172, 15);
            this.btn_archivo1.Name = "btn_archivo1";
            this.btn_archivo1.Size = new System.Drawing.Size(75, 23);
            this.btn_archivo1.TabIndex = 2;
            this.btn_archivo1.Text = "&Archivo";
            this.btn_archivo1.UseVisualStyleBackColor = false;
            // 
            // btn_imprimir1
            // 
            this.btn_imprimir1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_imprimir1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_imprimir1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_imprimir1.Location = new System.Drawing.Point(91, 15);
            this.btn_imprimir1.Name = "btn_imprimir1";
            this.btn_imprimir1.Size = new System.Drawing.Size(75, 23);
            this.btn_imprimir1.TabIndex = 1;
            this.btn_imprimir1.Text = "&Imprimir";
            this.btn_imprimir1.UseVisualStyleBackColor = false;
            // 
            // btn_pantalla1
            // 
            this.btn_pantalla1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_pantalla1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_pantalla1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_pantalla1.Location = new System.Drawing.Point(10, 15);
            this.btn_pantalla1.Name = "btn_pantalla1";
            this.btn_pantalla1.Size = new System.Drawing.Size(75, 23);
            this.btn_pantalla1.TabIndex = 0;
            this.btn_pantalla1.Text = "&Pantalla";
            this.btn_pantalla1.UseVisualStyleBackColor = false;
            // 
            // dtp_al
            // 
            this.dtp_al.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_al.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_al.Location = new System.Drawing.Point(297, 87);
            this.dtp_al.Name = "dtp_al";
            this.dtp_al.Size = new System.Drawing.Size(83, 20);
            this.dtp_al.TabIndex = 21;
            // 
            // dtp_del
            // 
            this.dtp_del.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_del.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_del.Location = new System.Drawing.Point(125, 87);
            this.dtp_del.Name = "dtp_del";
            this.dtp_del.Size = new System.Drawing.Size(83, 20);
            this.dtp_del.TabIndex = 20;
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label9.Location = new System.Drawing.Point(23, 90);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(56, 14);
            this.Label9.TabIndex = 19;
            this.Label9.Text = "Rango Del";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.Location = new System.Drawing.Point(255, 90);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(17, 14);
            this.Label6.TabIndex = 18;
            this.Label6.Text = "Al";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.Location = new System.Drawing.Point(23, 45);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(45, 14);
            this.Label5.TabIndex = 17;
            this.Label5.Text = "Moneda";
            // 
            // cbo_moneda2
            // 
            this.cbo_moneda2.BackColor = System.Drawing.Color.White;
            this.cbo_moneda2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_moneda2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_moneda2.FormattingEnabled = true;
            this.cbo_moneda2.Location = new System.Drawing.Point(125, 42);
            this.cbo_moneda2.Name = "cbo_moneda2";
            this.cbo_moneda2.Size = new System.Drawing.Size(132, 22);
            this.cbo_moneda2.TabIndex = 16;
            // 
            // Cambio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 310);
            this.Controls.Add(this.TabControl1);
            this.Name = "Cambio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento de Tipo de Cambio";
            this.Load += new System.EventHandler(this.Cambio_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Cambio_KeyDown);
            this.TabControl1.ResumeLayout(false);
            this.TabPage1.ResumeLayout(false);
            this.TabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw1)).EndInit();
            this.TabPage2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.TabPage3.ResumeLayout(false);
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.gb1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TabControl TabControl1;
        internal System.Windows.Forms.TabPage TabPage1;
        internal System.Windows.Forms.DataGridView dgw1;
        internal System.Windows.Forms.ComboBox cbo_año;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.Button btn_Nuevo;
        internal System.Windows.Forms.ComboBox cbo_mes;
        internal System.Windows.Forms.Button btn_Modificar;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.Button btn_eliminar;
        internal System.Windows.Forms.Button btn_salir;
        internal System.Windows.Forms.TabPage TabPage2;
        internal System.Windows.Forms.GroupBox panel1;
        internal System.Windows.Forms.Button btn_guardar;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Button btn_modificar2;
        internal System.Windows.Forms.TextBox txt_compra;
        internal System.Windows.Forms.Button btn_Cancelar;
        internal System.Windows.Forms.ComboBox cbo_moneda1;
        internal System.Windows.Forms.DateTimePicker dtp1;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.TextBox txt_venta;
        internal System.Windows.Forms.TabPage TabPage3;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.Button Button1;
        internal System.Windows.Forms.GroupBox gb1;
        internal System.Windows.Forms.Button btn_archivo1;
        internal System.Windows.Forms.Button btn_imprimir1;
        internal System.Windows.Forms.Button btn_pantalla1;
        internal System.Windows.Forms.DateTimePicker dtp_al;
        internal System.Windows.Forms.DateTimePicker dtp_del;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.ComboBox cbo_moneda2;
        internal System.Windows.Forms.TextBox txt_compra_paralelo;
        internal System.Windows.Forms.Label label10;
        internal System.Windows.Forms.Label label11;
        internal System.Windows.Forms.TextBox txt_venta_paralelo;
    }
}