namespace Presentacion.MOD_ADM
{
    partial class NUMERACION_COMPROBANTE
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NUMERACION_COMPROBANTE));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.cbo_año = new System.Windows.Forms.ComboBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.cbo_mes = new System.Windows.Forms.ComboBox();
            this.Label7 = new System.Windows.Forms.Label();
            this.btnConsultarSuspendidos = new System.Windows.Forms.Button();
            this.btn_salir = new System.Windows.Forms.Button();
            this.btn_eliminar = new System.Windows.Forms.Button();
            this.btn_modificar = new System.Windows.Forms.Button();
            this.btn_nuevo = new System.Windows.Forms.Button();
            this.dgw1 = new System.Windows.Forms.DataGridView();
            this.cod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nroini = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nrofin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stsus = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.annio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnDesSus = new System.Windows.Forms.Button();
            this.cbo_año1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbo_mes1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCancelarSus = new System.Windows.Forms.Button();
            this.btnVerSus = new System.Windows.Forms.Button();
            this.dgw_sus = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.annio1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mes1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TabPage2 = new System.Windows.Forms.TabPage();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.panel_per2 = new System.Windows.Forms.Panel();
            this.dgw_per2 = new System.Windows.Forms.DataGridView();
            this.chk_sus = new System.Windows.Forms.CheckBox();
            this.Label42 = new System.Windows.Forms.Label();
            this.dtp_fec_comp = new System.Windows.Forms.DateTimePicker();
            this.txt_desc2 = new System.Windows.Forms.TextBox();
            this.txt_cod2 = new System.Windows.Forms.TextBox();
            this.txt_fin = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_ini = new System.Windows.Forms.TextBox();
            this.btn_guardar = new System.Windows.Forms.Button();
            this.btn_modificar2 = new System.Windows.Forms.Button();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.TabControl1.SuspendLayout();
            this.TabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw1)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw_sus)).BeginInit();
            this.TabPage2.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.panel_per2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw_per2)).BeginInit();
            this.SuspendLayout();
            // 
            // TabControl1
            // 
            this.TabControl1.Controls.Add(this.TabPage1);
            this.TabControl1.Controls.Add(this.tabPage3);
            this.TabControl1.Controls.Add(this.TabPage2);
            this.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabControl1.Location = new System.Drawing.Point(0, 0);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(556, 310);
            this.TabControl1.TabIndex = 4;
            this.TabControl1.SelectedIndexChanged += new System.EventHandler(this.TabControl1_SelectedIndexChanged);
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.cbo_año);
            this.TabPage1.Controls.Add(this.Label8);
            this.TabPage1.Controls.Add(this.cbo_mes);
            this.TabPage1.Controls.Add(this.Label7);
            this.TabPage1.Controls.Add(this.btnConsultarSuspendidos);
            this.TabPage1.Controls.Add(this.btn_salir);
            this.TabPage1.Controls.Add(this.btn_eliminar);
            this.TabPage1.Controls.Add(this.btn_modificar);
            this.TabPage1.Controls.Add(this.btn_nuevo);
            this.TabPage1.Controls.Add(this.dgw1);
            this.TabPage1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabPage1.Location = new System.Drawing.Point(4, 23);
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage1.Size = new System.Drawing.Size(548, 283);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "Lista de Numeracion";
            this.TabPage1.UseVisualStyleBackColor = true;
            // 
            // cbo_año
            // 
            this.cbo_año.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_año.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_año.FormattingEnabled = true;
            this.cbo_año.Location = new System.Drawing.Point(312, 15);
            this.cbo_año.Name = "cbo_año";
            this.cbo_año.Size = new System.Drawing.Size(68, 22);
            this.cbo_año.TabIndex = 9;
            this.cbo_año.TabStop = false;
            this.cbo_año.SelectedIndexChanged += new System.EventHandler(this.cbo_año_SelectedIndexChanged);
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label8.Location = new System.Drawing.Point(276, 18);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(30, 14);
            this.Label8.TabIndex = 12;
            this.Label8.Text = "Año:";
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
            this.cbo_mes.Location = new System.Drawing.Point(149, 15);
            this.cbo_mes.Name = "cbo_mes";
            this.cbo_mes.Size = new System.Drawing.Size(121, 22);
            this.cbo_mes.TabIndex = 10;
            this.cbo_mes.TabStop = false;
            this.cbo_mes.SelectedIndexChanged += new System.EventHandler(this.cbo_mes_SelectedIndexChanged);
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label7.Location = new System.Drawing.Point(113, 18);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(33, 14);
            this.Label7.TabIndex = 11;
            this.Label7.Text = "Mes :";
            // 
            // btnConsultarSuspendidos
            // 
            this.btnConsultarSuspendidos.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnConsultarSuspendidos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsultarSuspendidos.Image = ((System.Drawing.Image)(resources.GetObject("btnConsultarSuspendidos.Image")));
            this.btnConsultarSuspendidos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConsultarSuspendidos.Location = new System.Drawing.Point(457, 217);
            this.btnConsultarSuspendidos.Name = "btnConsultarSuspendidos";
            this.btnConsultarSuspendidos.Size = new System.Drawing.Size(85, 49);
            this.btnConsultarSuspendidos.TabIndex = 5;
            this.btnConsultarSuspendidos.Text = "&Consultar Suspendidos";
            this.btnConsultarSuspendidos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConsultarSuspendidos.UseVisualStyleBackColor = true;
            this.btnConsultarSuspendidos.Click += new System.EventHandler(this.btnConsultarSuspendidos_Click);
            // 
            // btn_salir
            // 
            this.btn_salir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_salir.Image = ((System.Drawing.Image)(resources.GetObject("btn_salir.Image")));
            this.btn_salir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_salir.Location = new System.Drawing.Point(457, 176);
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
            this.btn_eliminar.Location = new System.Drawing.Point(457, 135);
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
            this.btn_modificar.Location = new System.Drawing.Point(457, 94);
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
            this.btn_nuevo.Location = new System.Drawing.Point(457, 53);
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
            this.fecha,
            this.nroini,
            this.nrofin,
            this.stsus,
            this.annio,
            this.mes});
            this.dgw1.Location = new System.Drawing.Point(6, 53);
            this.dgw1.MultiSelect = false;
            this.dgw1.Name = "dgw1";
            this.dgw1.ReadOnly = true;
            this.dgw1.RowHeadersWidth = 25;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            this.dgw1.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgw1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dgw1.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.dgw1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgw1.Size = new System.Drawing.Size(445, 213);
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
            this.desc.Width = 180;
            // 
            // fecha
            // 
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.fecha.DefaultCellStyle = dataGridViewCellStyle1;
            this.fecha.HeaderText = "Fecha";
            this.fecha.Name = "fecha";
            this.fecha.ReadOnly = true;
            this.fecha.Width = 70;
            // 
            // nroini
            // 
            this.nroini.HeaderText = "Inicio";
            this.nroini.Name = "nroini";
            this.nroini.ReadOnly = true;
            this.nroini.Width = 50;
            // 
            // nrofin
            // 
            this.nrofin.HeaderText = "Fin";
            this.nrofin.Name = "nrofin";
            this.nrofin.ReadOnly = true;
            this.nrofin.Width = 50;
            // 
            // stsus
            // 
            this.stsus.HeaderText = "stsus";
            this.stsus.Name = "stsus";
            this.stsus.ReadOnly = true;
            this.stsus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.stsus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.stsus.Visible = false;
            // 
            // annio
            // 
            this.annio.HeaderText = "annio";
            this.annio.Name = "annio";
            this.annio.ReadOnly = true;
            this.annio.Visible = false;
            // 
            // mes
            // 
            this.mes.HeaderText = "mes";
            this.mes.Name = "mes";
            this.mes.ReadOnly = true;
            this.mes.Visible = false;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnDesSus);
            this.tabPage3.Controls.Add(this.cbo_año1);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.cbo_mes1);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.btnCancelarSus);
            this.tabPage3.Controls.Add(this.btnVerSus);
            this.tabPage3.Controls.Add(this.dgw_sus);
            this.tabPage3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage3.Location = new System.Drawing.Point(4, 23);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(548, 283);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Suspendidos";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnDesSus
            // 
            this.btnDesSus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDesSus.Image = ((System.Drawing.Image)(resources.GetObject("btnDesSus.Image")));
            this.btnDesSus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDesSus.Location = new System.Drawing.Point(458, 100);
            this.btnDesSus.Name = "btnDesSus";
            this.btnDesSus.Size = new System.Drawing.Size(85, 35);
            this.btnDesSus.TabIndex = 17;
            this.btnDesSus.Text = "&Des-Susp";
            this.btnDesSus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDesSus.UseVisualStyleBackColor = true;
            this.btnDesSus.Click += new System.EventHandler(this.btnDesSus_Click);
            // 
            // cbo_año1
            // 
            this.cbo_año1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_año1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_año1.FormattingEnabled = true;
            this.cbo_año1.Location = new System.Drawing.Point(321, 19);
            this.cbo_año1.Name = "cbo_año1";
            this.cbo_año1.Size = new System.Drawing.Size(68, 22);
            this.cbo_año1.TabIndex = 13;
            this.cbo_año1.TabStop = false;
            this.cbo_año1.SelectedIndexChanged += new System.EventHandler(this.cbo_año1_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(285, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 14);
            this.label4.TabIndex = 16;
            this.label4.Text = "Año:";
            // 
            // cbo_mes1
            // 
            this.cbo_mes1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_mes1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_mes1.FormattingEnabled = true;
            this.cbo_mes1.Items.AddRange(new object[] {
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
            this.cbo_mes1.Location = new System.Drawing.Point(158, 19);
            this.cbo_mes1.Name = "cbo_mes1";
            this.cbo_mes1.Size = new System.Drawing.Size(121, 22);
            this.cbo_mes1.TabIndex = 14;
            this.cbo_mes1.TabStop = false;
            this.cbo_mes1.SelectedIndexChanged += new System.EventHandler(this.cbo_mes1_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(122, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 14);
            this.label5.TabIndex = 15;
            this.label5.Text = "Mes :";
            // 
            // btnCancelarSus
            // 
            this.btnCancelarSus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelarSus.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelarSus.Image")));
            this.btnCancelarSus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelarSus.Location = new System.Drawing.Point(458, 140);
            this.btnCancelarSus.Name = "btnCancelarSus";
            this.btnCancelarSus.Size = new System.Drawing.Size(85, 35);
            this.btnCancelarSus.TabIndex = 4;
            this.btnCancelarSus.Text = "&Cancelar";
            this.btnCancelarSus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelarSus.UseVisualStyleBackColor = true;
            this.btnCancelarSus.Click += new System.EventHandler(this.btnCancelarSus_Click);
            // 
            // btnVerSus
            // 
            this.btnVerSus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerSus.Image = ((System.Drawing.Image)(resources.GetObject("btnVerSus.Image")));
            this.btnVerSus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVerSus.Location = new System.Drawing.Point(458, 59);
            this.btnVerSus.Name = "btnVerSus";
            this.btnVerSus.Size = new System.Drawing.Size(85, 35);
            this.btnVerSus.TabIndex = 2;
            this.btnVerSus.Text = "&Consultar";
            this.btnVerSus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVerSus.UseVisualStyleBackColor = true;
            this.btnVerSus.Click += new System.EventHandler(this.btnVerSus_Click);
            // 
            // dgw_sus
            // 
            this.dgw_sus.AllowUserToAddRows = false;
            this.dgw_sus.AllowUserToDeleteRows = false;
            this.dgw_sus.AllowUserToResizeRows = false;
            this.dgw_sus.BackgroundColor = System.Drawing.Color.White;
            this.dgw_sus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgw_sus.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewCheckBoxColumn1,
            this.annio1,
            this.mes1});
            this.dgw_sus.Location = new System.Drawing.Point(3, 54);
            this.dgw_sus.MultiSelect = false;
            this.dgw_sus.Name = "dgw_sus";
            this.dgw_sus.ReadOnly = true;
            this.dgw_sus.RowHeadersWidth = 25;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            this.dgw_sus.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgw_sus.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dgw_sus.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.dgw_sus.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgw_sus.Size = new System.Drawing.Size(445, 213);
            this.dgw_sus.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.FillWeight = 48.07222F;
            this.dataGridViewTextBoxColumn1.HeaderText = "Cod";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 50;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.FillWeight = 103.8613F;
            this.dataGridViewTextBoxColumn2.HeaderText = "Descripcion";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 180;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn3.FillWeight = 66.54022F;
            this.dataGridViewTextBoxColumn3.HeaderText = "Fecha";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 70;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Inicio";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 50;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Fin";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 50;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.HeaderText = "stsus";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.ReadOnly = true;
            this.dataGridViewCheckBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCheckBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewCheckBoxColumn1.Visible = false;
            // 
            // annio1
            // 
            this.annio1.HeaderText = "annio";
            this.annio1.Name = "annio1";
            this.annio1.ReadOnly = true;
            this.annio1.Visible = false;
            // 
            // mes1
            // 
            this.mes1.HeaderText = "mes";
            this.mes1.Name = "mes1";
            this.mes1.ReadOnly = true;
            this.mes1.Visible = false;
            // 
            // TabPage2
            // 
            this.TabPage2.Controls.Add(this.GroupBox1);
            this.TabPage2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabPage2.Location = new System.Drawing.Point(4, 23);
            this.TabPage2.Name = "TabPage2";
            this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage2.Size = new System.Drawing.Size(548, 283);
            this.TabPage2.TabIndex = 1;
            this.TabPage2.Text = "Detalles";
            this.TabPage2.UseVisualStyleBackColor = true;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.panel_per2);
            this.GroupBox1.Controls.Add(this.chk_sus);
            this.GroupBox1.Controls.Add(this.Label42);
            this.GroupBox1.Controls.Add(this.dtp_fec_comp);
            this.GroupBox1.Controls.Add(this.txt_desc2);
            this.GroupBox1.Controls.Add(this.txt_cod2);
            this.GroupBox1.Controls.Add(this.txt_fin);
            this.GroupBox1.Controls.Add(this.label3);
            this.GroupBox1.Controls.Add(this.txt_ini);
            this.GroupBox1.Controls.Add(this.btn_guardar);
            this.GroupBox1.Controls.Add(this.btn_modificar2);
            this.GroupBox1.Controls.Add(this.btn_cancelar);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Location = new System.Drawing.Point(8, 6);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(532, 247);
            this.GroupBox1.TabIndex = 1;
            this.GroupBox1.TabStop = false;
            // 
            // panel_per2
            // 
            this.panel_per2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_per2.Controls.Add(this.dgw_per2);
            this.panel_per2.Location = new System.Drawing.Point(72, 39);
            this.panel_per2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel_per2.Name = "panel_per2";
            this.panel_per2.Size = new System.Drawing.Size(447, 202);
            this.panel_per2.TabIndex = 38;
            this.panel_per2.Visible = false;
            // 
            // dgw_per2
            // 
            this.dgw_per2.AllowUserToAddRows = false;
            this.dgw_per2.AllowUserToDeleteRows = false;
            this.dgw_per2.BackgroundColor = System.Drawing.Color.White;
            this.dgw_per2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgw_per2.Location = new System.Drawing.Point(16, 3);
            this.dgw_per2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dgw_per2.MultiSelect = false;
            this.dgw_per2.Name = "dgw_per2";
            this.dgw_per2.ReadOnly = true;
            this.dgw_per2.RowHeadersWidth = 25;
            this.dgw_per2.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dgw_per2.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.dgw_per2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgw_per2.Size = new System.Drawing.Size(418, 194);
            this.dgw_per2.TabIndex = 10;
            this.dgw_per2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgw_per2_KeyDown);
            // 
            // chk_sus
            // 
            this.chk_sus.AutoSize = true;
            this.chk_sus.Location = new System.Drawing.Point(401, 69);
            this.chk_sus.Name = "chk_sus";
            this.chk_sus.Size = new System.Drawing.Size(83, 18);
            this.chk_sus.TabIndex = 6;
            this.chk_sus.Text = "Suspendido";
            this.chk_sus.UseVisualStyleBackColor = true;
            // 
            // Label42
            // 
            this.Label42.AutoSize = true;
            this.Label42.Location = new System.Drawing.Point(35, 46);
            this.Label42.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label42.Name = "Label42";
            this.Label42.Size = new System.Drawing.Size(37, 14);
            this.Label42.TabIndex = 36;
            this.Label42.Text = "Fecha";
            // 
            // dtp_fec_comp
            // 
            this.dtp_fec_comp.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_fec_comp.Location = new System.Drawing.Point(90, 42);
            this.dtp_fec_comp.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dtp_fec_comp.Name = "dtp_fec_comp";
            this.dtp_fec_comp.Size = new System.Drawing.Size(77, 20);
            this.dtp_fec_comp.TabIndex = 3;
            // 
            // txt_desc2
            // 
            this.txt_desc2.BackColor = System.Drawing.Color.White;
            this.txt_desc2.Location = new System.Drawing.Point(141, 18);
            this.txt_desc2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_desc2.MaxLength = 60;
            this.txt_desc2.Name = "txt_desc2";
            this.txt_desc2.Size = new System.Drawing.Size(343, 20);
            this.txt_desc2.TabIndex = 2;
            this.txt_desc2.Leave += new System.EventHandler(this.txt_desc2_Leave);
            // 
            // txt_cod2
            // 
            this.txt_cod2.BackColor = System.Drawing.Color.White;
            this.txt_cod2.Location = new System.Drawing.Point(90, 18);
            this.txt_cod2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_cod2.MaxLength = 5;
            this.txt_cod2.Name = "txt_cod2";
            this.txt_cod2.Size = new System.Drawing.Size(51, 20);
            this.txt_cod2.TabIndex = 1;
            this.txt_cod2.Leave += new System.EventHandler(this.txt_cod2_Leave);
            // 
            // txt_fin
            // 
            this.txt_fin.BackColor = System.Drawing.Color.White;
            this.txt_fin.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_fin.Location = new System.Drawing.Point(90, 89);
            this.txt_fin.MaxLength = 7;
            this.txt_fin.Name = "txt_fin";
            this.txt_fin.Size = new System.Drawing.Size(77, 20);
            this.txt_fin.TabIndex = 5;
            this.txt_fin.Leave += new System.EventHandler(this.txt_fin_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 14);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nro Fin";
            // 
            // txt_ini
            // 
            this.txt_ini.BackColor = System.Drawing.Color.White;
            this.txt_ini.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_ini.Location = new System.Drawing.Point(90, 66);
            this.txt_ini.MaxLength = 7;
            this.txt_ini.Name = "txt_ini";
            this.txt_ini.Size = new System.Drawing.Size(77, 20);
            this.txt_ini.TabIndex = 4;
            this.txt_ini.Leave += new System.EventHandler(this.txt_ini_Leave);
            // 
            // btn_guardar
            // 
            this.btn_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_guardar.Image = ((System.Drawing.Image)(resources.GetObject("btn_guardar.Image")));
            this.btn_guardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_guardar.Location = new System.Drawing.Point(174, 148);
            this.btn_guardar.Name = "btn_guardar";
            this.btn_guardar.Size = new System.Drawing.Size(77, 27);
            this.btn_guardar.TabIndex = 7;
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
            this.btn_modificar2.Location = new System.Drawing.Point(174, 148);
            this.btn_modificar2.Name = "btn_modificar2";
            this.btn_modificar2.Size = new System.Drawing.Size(77, 27);
            this.btn_modificar2.TabIndex = 7;
            this.btn_modificar2.Text = "&Modificar";
            this.btn_modificar2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_modificar2.UseVisualStyleBackColor = true;
            this.btn_modificar2.Click += new System.EventHandler(this.btn_modificar2_Click);
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancelar.Image = ((System.Drawing.Image)(resources.GetObject("btn_cancelar.Image")));
            this.btn_cancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_cancelar.Location = new System.Drawing.Point(257, 148);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(77, 27);
            this.btn_cancelar.TabIndex = 8;
            this.btn_cancelar.Text = "&Cancelar";
            this.btn_cancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_cancelar.UseVisualStyleBackColor = true;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(33, 69);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(37, 14);
            this.Label2.TabIndex = 1;
            this.Label2.Text = "Nro Ini";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(26, 21);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(47, 14);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Persona";
            // 
            // NUMERACION_COMPROBANTE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 310);
            this.ControlBox = false;
            this.Controls.Add(this.TabControl1);
            this.Name = "NUMERACION_COMPROBANTE";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Numeración de Contrato";
            this.Load += new System.EventHandler(this.NUMERACION_COMPROBANTE_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NUMERACION_COMPROBANTE_KeyDown);
            this.TabControl1.ResumeLayout(false);
            this.TabPage1.ResumeLayout(false);
            this.TabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw1)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw_sus)).EndInit();
            this.TabPage2.ResumeLayout(false);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.panel_per2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgw_per2)).EndInit();
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
        internal System.Windows.Forms.TextBox txt_fin;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox txt_ini;
        internal System.Windows.Forms.Button btn_guardar;
        internal System.Windows.Forms.Button btn_modificar2;
        internal System.Windows.Forms.Button btn_cancelar;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox txt_desc2;
        internal System.Windows.Forms.TextBox txt_cod2;
        internal System.Windows.Forms.Label Label42;
        internal System.Windows.Forms.DateTimePicker dtp_fec_comp;
        internal System.Windows.Forms.CheckBox chk_sus;
        private System.Windows.Forms.TabPage tabPage3;
        internal System.Windows.Forms.DataGridView dgw_sus;
        internal System.Windows.Forms.Button btnConsultarSuspendidos;
        internal System.Windows.Forms.Button btnVerSus;
        internal System.Windows.Forms.Button btnCancelarSus;
        internal System.Windows.Forms.Panel panel_per2;
        internal System.Windows.Forms.DataGridView dgw_per2;
        internal System.Windows.Forms.ComboBox cbo_año;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.ComboBox cbo_mes;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.ComboBox cbo_año1;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.ComboBox cbo_mes1;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.Button btnDesSus;
        private System.Windows.Forms.DataGridViewTextBoxColumn cod;
        private System.Windows.Forms.DataGridViewTextBoxColumn desc;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn nroini;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrofin;
        private System.Windows.Forms.DataGridViewCheckBoxColumn stsus;
        private System.Windows.Forms.DataGridViewTextBoxColumn annio;
        private System.Windows.Forms.DataGridViewTextBoxColumn mes;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn annio1;
        private System.Windows.Forms.DataGridViewTextBoxColumn mes1;

    }
}