
namespace Presentacion.MOD_COMISIONES
{
    partial class FrmComisiones
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbComisiones = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvComision = new System.Windows.Forms.DataGridView();
            this.trvPersonas = new System.Windows.Forms.TreeView();
            this.rdbTodos = new System.Windows.Forms.RadioButton();
            this.rdbPV = new System.Windows.Forms.RadioButton();
            this.rdbPP = new System.Windows.Forms.RadioButton();
            this.btnReporte = new System.Windows.Forms.Button();
            this.btnNuevaComision = new System.Windows.Forms.Button();
            this.tbConfigComNVenta = new System.Windows.Forms.TabPage();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvFechaConfNivelVenta = new System.Windows.Forms.DataGridView();
            this.cboPersona = new System.Windows.Forms.ComboBox();
            this.cboNivelVenta = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvComisionConfNivelVenta = new System.Windows.Forms.DataGridView();
            this.rdbTodos2 = new System.Windows.Forms.RadioButton();
            this.rdbPV2 = new System.Windows.Forms.RadioButton();
            this.rdbPP2 = new System.Windows.Forms.RadioButton();
            this.btnConfigurarComision = new System.Windows.Forms.Button();
            this.tbConfigComInstitu = new System.Windows.Forms.TabPage();
            this.btnEliminar2 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvFechaConfInstitu = new System.Windows.Forms.DataGridView();
            this.cboInstitucion = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvComisionConfInstitu = new System.Windows.Forms.DataGridView();
            this.rdbTodos3 = new System.Windows.Forms.RadioButton();
            this.rdbPV3 = new System.Windows.Forms.RadioButton();
            this.rdbPP3 = new System.Windows.Forms.RadioButton();
            this.btnConfigurarComision2 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tbComisiones.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComision)).BeginInit();
            this.tbConfigComNVenta.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFechaConfNivelVenta)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComisionConfNivelVenta)).BeginInit();
            this.tbConfigComInstitu.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFechaConfInstitu)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComisionConfInstitu)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbComisiones);
            this.tabControl1.Controls.Add(this.tbConfigComNVenta);
            this.tabControl1.Controls.Add(this.tbConfigComInstitu);
            this.tabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl1.Location = new System.Drawing.Point(1, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1284, 574);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.TabControl1_DrawItem);
            // 
            // tbComisiones
            // 
            this.tbComisiones.Controls.Add(this.panel1);
            this.tbComisiones.Controls.Add(this.trvPersonas);
            this.tbComisiones.Controls.Add(this.rdbTodos);
            this.tbComisiones.Controls.Add(this.rdbPV);
            this.tbComisiones.Controls.Add(this.rdbPP);
            this.tbComisiones.Controls.Add(this.btnReporte);
            this.tbComisiones.Controls.Add(this.btnNuevaComision);
            this.tbComisiones.Location = new System.Drawing.Point(4, 22);
            this.tbComisiones.Name = "tbComisiones";
            this.tbComisiones.Padding = new System.Windows.Forms.Padding(3);
            this.tbComisiones.Size = new System.Drawing.Size(1276, 548);
            this.tbComisiones.TabIndex = 0;
            this.tbComisiones.Text = "Comisiones                     ";
            this.tbComisiones.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvComision);
            this.panel1.Location = new System.Drawing.Point(303, 44);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(966, 496);
            this.panel1.TabIndex = 11;
            // 
            // dgvComision
            // 
            this.dgvComision.AllowUserToAddRows = false;
            this.dgvComision.AllowUserToDeleteRows = false;
            this.dgvComision.BackgroundColor = System.Drawing.Color.White;
            this.dgvComision.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvComision.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvComision.Location = new System.Drawing.Point(0, 0);
            this.dgvComision.Name = "dgvComision";
            this.dgvComision.Size = new System.Drawing.Size(966, 496);
            this.dgvComision.TabIndex = 0;
            this.dgvComision.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.DgvComision_CellBeginEdit);
            this.dgvComision.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvComision_CellEndEdit);
            this.dgvComision.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DgvComision_CellFormatting);
            this.dgvComision.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvComision_ColumnHeaderMouseClick);
            this.dgvComision.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.DgvComision_DataError);
            this.dgvComision.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DgvComision_KeyDown);
            // 
            // trvPersonas
            // 
            this.trvPersonas.CheckBoxes = true;
            this.trvPersonas.Location = new System.Drawing.Point(8, 44);
            this.trvPersonas.Name = "trvPersonas";
            this.trvPersonas.Size = new System.Drawing.Size(289, 496);
            this.trvPersonas.TabIndex = 10;
            this.trvPersonas.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.TrvPersonas_AfterCheck);
            this.trvPersonas.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TrvPersonas_NodeMouseClick);
            // 
            // rdbTodos
            // 
            this.rdbTodos.AutoSize = true;
            this.rdbTodos.Location = new System.Drawing.Point(592, 14);
            this.rdbTodos.Name = "rdbTodos";
            this.rdbTodos.Size = new System.Drawing.Size(55, 17);
            this.rdbTodos.TabIndex = 16;
            this.rdbTodos.Tag = "0";
            this.rdbTodos.Text = "Todos";
            this.rdbTodos.UseVisualStyleBackColor = true;
            this.rdbTodos.Click += new System.EventHandler(this.RdbPP_Click);
            // 
            // rdbPV
            // 
            this.rdbPV.AutoSize = true;
            this.rdbPV.Location = new System.Drawing.Point(440, 8);
            this.rdbPV.Name = "rdbPV";
            this.rdbPV.Size = new System.Drawing.Size(110, 30);
            this.rdbPV.TabIndex = 15;
            this.rdbPV.Tag = "PV";
            this.rdbPV.Text = "Filtrar solo tipo de \r\nventa visa";
            this.rdbPV.UseVisualStyleBackColor = true;
            this.rdbPV.Click += new System.EventHandler(this.RdbPP_Click);
            // 
            // rdbPP
            // 
            this.rdbPP.AutoSize = true;
            this.rdbPP.Checked = true;
            this.rdbPP.Location = new System.Drawing.Point(303, 8);
            this.rdbPP.Name = "rdbPP";
            this.rdbPP.Size = new System.Drawing.Size(110, 30);
            this.rdbPP.TabIndex = 14;
            this.rdbPP.TabStop = true;
            this.rdbPP.Tag = "PP";
            this.rdbPP.Text = "Filtrar solo tipo de \r\nventa descuento";
            this.rdbPP.UseVisualStyleBackColor = true;
            this.rdbPP.Click += new System.EventHandler(this.RdbPP_Click);
            // 
            // btnReporte
            // 
            this.btnReporte.BackColor = System.Drawing.Color.Teal;
            this.btnReporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReporte.ForeColor = System.Drawing.Color.White;
            this.btnReporte.Location = new System.Drawing.Point(1156, 7);
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.Size = new System.Drawing.Size(113, 31);
            this.btnReporte.TabIndex = 13;
            this.btnReporte.Text = "Reporte";
            this.btnReporte.UseVisualStyleBackColor = false;
            // 
            // btnNuevaComision
            // 
            this.btnNuevaComision.BackColor = System.Drawing.Color.Teal;
            this.btnNuevaComision.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevaComision.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNuevaComision.ForeColor = System.Drawing.Color.White;
            this.btnNuevaComision.Location = new System.Drawing.Point(8, 6);
            this.btnNuevaComision.Name = "btnNuevaComision";
            this.btnNuevaComision.Size = new System.Drawing.Size(103, 23);
            this.btnNuevaComision.TabIndex = 12;
            this.btnNuevaComision.Text = "Nueva Comisión";
            this.btnNuevaComision.UseVisualStyleBackColor = false;
            this.btnNuevaComision.Click += new System.EventHandler(this.BtnNuevaComision_Click);
            // 
            // tbConfigComNVenta
            // 
            this.tbConfigComNVenta.Controls.Add(this.btnEliminar);
            this.tbConfigComNVenta.Controls.Add(this.groupBox1);
            this.tbConfigComNVenta.Controls.Add(this.cboPersona);
            this.tbConfigComNVenta.Controls.Add(this.cboNivelVenta);
            this.tbConfigComNVenta.Controls.Add(this.label2);
            this.tbConfigComNVenta.Controls.Add(this.label1);
            this.tbConfigComNVenta.Controls.Add(this.panel2);
            this.tbConfigComNVenta.Controls.Add(this.rdbTodos2);
            this.tbConfigComNVenta.Controls.Add(this.rdbPV2);
            this.tbConfigComNVenta.Controls.Add(this.rdbPP2);
            this.tbConfigComNVenta.Controls.Add(this.btnConfigurarComision);
            this.tbConfigComNVenta.Location = new System.Drawing.Point(4, 22);
            this.tbConfigComNVenta.Name = "tbConfigComNVenta";
            this.tbConfigComNVenta.Padding = new System.Windows.Forms.Padding(3);
            this.tbConfigComNVenta.Size = new System.Drawing.Size(1276, 548);
            this.tbConfigComNVenta.TabIndex = 1;
            this.tbConfigComNVenta.Text = "Config. Comisión Sup./Dir.Vta./Dir.Nac.                     ";
            this.tbConfigComNVenta.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.Teal;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Location = new System.Drawing.Point(8, 314);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(97, 27);
            this.btnEliminar.TabIndex = 29;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvFechaConfNivelVenta);
            this.groupBox1.Location = new System.Drawing.Point(5, 122);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(295, 189);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fecha de Configuración";
            // 
            // dgvFechaConfNivelVenta
            // 
            this.dgvFechaConfNivelVenta.AllowUserToAddRows = false;
            this.dgvFechaConfNivelVenta.AllowUserToDeleteRows = false;
            this.dgvFechaConfNivelVenta.BackgroundColor = System.Drawing.Color.White;
            this.dgvFechaConfNivelVenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFechaConfNivelVenta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFechaConfNivelVenta.Location = new System.Drawing.Point(3, 16);
            this.dgvFechaConfNivelVenta.Name = "dgvFechaConfNivelVenta";
            this.dgvFechaConfNivelVenta.ReadOnly = true;
            this.dgvFechaConfNivelVenta.Size = new System.Drawing.Size(289, 170);
            this.dgvFechaConfNivelVenta.TabIndex = 0;
            this.dgvFechaConfNivelVenta.SelectionChanged += new System.EventHandler(this.DgvFechaConfiguracion_SelectionChanged);
            // 
            // cboPersona
            // 
            this.cboPersona.FormattingEnabled = true;
            this.cboPersona.Location = new System.Drawing.Point(97, 82);
            this.cboPersona.Name = "cboPersona";
            this.cboPersona.Size = new System.Drawing.Size(188, 21);
            this.cboPersona.TabIndex = 27;
            this.cboPersona.SelectedValueChanged += new System.EventHandler(this.CboPersona_SelectedValueChanged);
            // 
            // cboNivelVenta
            // 
            this.cboNivelVenta.FormattingEnabled = true;
            this.cboNivelVenta.Location = new System.Drawing.Point(97, 47);
            this.cboNivelVenta.Name = "cboNivelVenta";
            this.cboNivelVenta.Size = new System.Drawing.Size(188, 21);
            this.cboNivelVenta.TabIndex = 26;
            this.cboNivelVenta.SelectedValueChanged += new System.EventHandler(this.CboNivelVenta_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Persona";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Nivel Venta";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvComisionConfNivelVenta);
            this.panel2.Location = new System.Drawing.Point(303, 44);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(966, 496);
            this.panel2.TabIndex = 20;
            // 
            // dgvComisionConfNivelVenta
            // 
            this.dgvComisionConfNivelVenta.AllowUserToAddRows = false;
            this.dgvComisionConfNivelVenta.AllowUserToDeleteRows = false;
            this.dgvComisionConfNivelVenta.BackgroundColor = System.Drawing.Color.White;
            this.dgvComisionConfNivelVenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvComisionConfNivelVenta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvComisionConfNivelVenta.Location = new System.Drawing.Point(0, 0);
            this.dgvComisionConfNivelVenta.Name = "dgvComisionConfNivelVenta";
            this.dgvComisionConfNivelVenta.Size = new System.Drawing.Size(966, 496);
            this.dgvComisionConfNivelVenta.TabIndex = 0;
            this.dgvComisionConfNivelVenta.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.DgvComisionConf_CellBeginEdit);
            this.dgvComisionConfNivelVenta.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvComisionConf_CellContentClick);
            this.dgvComisionConfNivelVenta.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvComisionConf_CellEndEdit);
            this.dgvComisionConfNivelVenta.CurrentCellDirtyStateChanged += new System.EventHandler(this.DgvComisionConf_CurrentCellDirtyStateChanged);
            this.dgvComisionConfNivelVenta.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.DgvComisionConf_DataError);
            // 
            // rdbTodos2
            // 
            this.rdbTodos2.AutoSize = true;
            this.rdbTodos2.Location = new System.Drawing.Point(592, 13);
            this.rdbTodos2.Name = "rdbTodos2";
            this.rdbTodos2.Size = new System.Drawing.Size(55, 17);
            this.rdbTodos2.TabIndex = 23;
            this.rdbTodos2.Tag = "0";
            this.rdbTodos2.Text = "Todos";
            this.rdbTodos2.UseVisualStyleBackColor = true;
            this.rdbTodos2.Click += new System.EventHandler(this.RdbPP2_Click);
            // 
            // rdbPV2
            // 
            this.rdbPV2.AutoSize = true;
            this.rdbPV2.Location = new System.Drawing.Point(440, 8);
            this.rdbPV2.Name = "rdbPV2";
            this.rdbPV2.Size = new System.Drawing.Size(110, 30);
            this.rdbPV2.TabIndex = 22;
            this.rdbPV2.Tag = "PV";
            this.rdbPV2.Text = "Filtrar solo tipo de \r\nventa visa";
            this.rdbPV2.UseVisualStyleBackColor = true;
            this.rdbPV2.Click += new System.EventHandler(this.RdbPP2_Click);
            // 
            // rdbPP2
            // 
            this.rdbPP2.AutoSize = true;
            this.rdbPP2.Checked = true;
            this.rdbPP2.Location = new System.Drawing.Point(303, 8);
            this.rdbPP2.Name = "rdbPP2";
            this.rdbPP2.Size = new System.Drawing.Size(110, 30);
            this.rdbPP2.TabIndex = 21;
            this.rdbPP2.TabStop = true;
            this.rdbPP2.Tag = "PP";
            this.rdbPP2.Text = "Filtrar solo tipo de \r\nventa descuento";
            this.rdbPP2.UseVisualStyleBackColor = true;
            this.rdbPP2.Click += new System.EventHandler(this.RdbPP2_Click);
            // 
            // btnConfigurarComision
            // 
            this.btnConfigurarComision.BackColor = System.Drawing.Color.Teal;
            this.btnConfigurarComision.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfigurarComision.ForeColor = System.Drawing.Color.White;
            this.btnConfigurarComision.Location = new System.Drawing.Point(8, 4);
            this.btnConfigurarComision.Name = "btnConfigurarComision";
            this.btnConfigurarComision.Size = new System.Drawing.Size(130, 38);
            this.btnConfigurarComision.TabIndex = 18;
            this.btnConfigurarComision.Text = "Configurar Comisión \r\nSup./Dir.Vta./Dir.Nac.";
            this.btnConfigurarComision.UseVisualStyleBackColor = false;
            this.btnConfigurarComision.Click += new System.EventHandler(this.BtnConfigurarComision_Click);
            // 
            // tbConfigComInstitu
            // 
            this.tbConfigComInstitu.Controls.Add(this.btnEliminar2);
            this.tbConfigComInstitu.Controls.Add(this.groupBox2);
            this.tbConfigComInstitu.Controls.Add(this.cboInstitucion);
            this.tbConfigComInstitu.Controls.Add(this.label4);
            this.tbConfigComInstitu.Controls.Add(this.panel3);
            this.tbConfigComInstitu.Controls.Add(this.rdbTodos3);
            this.tbConfigComInstitu.Controls.Add(this.rdbPV3);
            this.tbConfigComInstitu.Controls.Add(this.rdbPP3);
            this.tbConfigComInstitu.Controls.Add(this.btnConfigurarComision2);
            this.tbConfigComInstitu.Location = new System.Drawing.Point(4, 22);
            this.tbConfigComInstitu.Name = "tbConfigComInstitu";
            this.tbConfigComInstitu.Size = new System.Drawing.Size(1276, 548);
            this.tbConfigComInstitu.TabIndex = 2;
            this.tbConfigComInstitu.Text = "Config. Comisión por Institución                     ";
            this.tbConfigComInstitu.UseVisualStyleBackColor = true;
            // 
            // btnEliminar2
            // 
            this.btnEliminar2.BackColor = System.Drawing.Color.Teal;
            this.btnEliminar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar2.ForeColor = System.Drawing.Color.White;
            this.btnEliminar2.Location = new System.Drawing.Point(8, 314);
            this.btnEliminar2.Name = "btnEliminar2";
            this.btnEliminar2.Size = new System.Drawing.Size(97, 27);
            this.btnEliminar2.TabIndex = 40;
            this.btnEliminar2.Text = "Eliminar";
            this.btnEliminar2.UseVisualStyleBackColor = false;
            this.btnEliminar2.Click += new System.EventHandler(this.BtnEliminar2_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvFechaConfInstitu);
            this.groupBox2.Location = new System.Drawing.Point(5, 90);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(295, 221);
            this.groupBox2.TabIndex = 39;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Fecha de Configuración";
            // 
            // dgvFechaConfInstitu
            // 
            this.dgvFechaConfInstitu.AllowUserToAddRows = false;
            this.dgvFechaConfInstitu.AllowUserToDeleteRows = false;
            this.dgvFechaConfInstitu.BackgroundColor = System.Drawing.Color.White;
            this.dgvFechaConfInstitu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFechaConfInstitu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFechaConfInstitu.Location = new System.Drawing.Point(3, 16);
            this.dgvFechaConfInstitu.Name = "dgvFechaConfInstitu";
            this.dgvFechaConfInstitu.ReadOnly = true;
            this.dgvFechaConfInstitu.Size = new System.Drawing.Size(289, 202);
            this.dgvFechaConfInstitu.TabIndex = 0;
            this.dgvFechaConfInstitu.SelectionChanged += new System.EventHandler(this.DgvFechaConfInstitu_SelectionChanged);
            // 
            // cboInstitucion
            // 
            this.cboInstitucion.FormattingEnabled = true;
            this.cboInstitucion.Location = new System.Drawing.Point(72, 52);
            this.cboInstitucion.Name = "cboInstitucion";
            this.cboInstitucion.Size = new System.Drawing.Size(188, 21);
            this.cboInstitucion.TabIndex = 37;
            this.cboInstitucion.SelectedValueChanged += new System.EventHandler(this.CboInstitucion_SelectedValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 35;
            this.label4.Text = "Institución";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvComisionConfInstitu);
            this.panel3.Location = new System.Drawing.Point(303, 44);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(966, 496);
            this.panel3.TabIndex = 31;
            // 
            // dgvComisionConfInstitu
            // 
            this.dgvComisionConfInstitu.AllowUserToAddRows = false;
            this.dgvComisionConfInstitu.AllowUserToDeleteRows = false;
            this.dgvComisionConfInstitu.BackgroundColor = System.Drawing.Color.White;
            this.dgvComisionConfInstitu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvComisionConfInstitu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvComisionConfInstitu.Location = new System.Drawing.Point(0, 0);
            this.dgvComisionConfInstitu.Name = "dgvComisionConfInstitu";
            this.dgvComisionConfInstitu.Size = new System.Drawing.Size(966, 496);
            this.dgvComisionConfInstitu.TabIndex = 0;
            this.dgvComisionConfInstitu.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.DgvComisionConfInstitu_CellBeginEdit);
            this.dgvComisionConfInstitu.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvComisionConfInstitu_CellContentClick);
            this.dgvComisionConfInstitu.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvComisionConfInstitu_CellEndEdit);
            this.dgvComisionConfInstitu.CurrentCellDirtyStateChanged += new System.EventHandler(this.DgvComisionConfInstitu_CurrentCellDirtyStateChanged);
            this.dgvComisionConfInstitu.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.DgvComisionConfInstitu_DataError);
            // 
            // rdbTodos3
            // 
            this.rdbTodos3.AutoSize = true;
            this.rdbTodos3.Location = new System.Drawing.Point(592, 13);
            this.rdbTodos3.Name = "rdbTodos3";
            this.rdbTodos3.Size = new System.Drawing.Size(55, 17);
            this.rdbTodos3.TabIndex = 34;
            this.rdbTodos3.Tag = "0";
            this.rdbTodos3.Text = "Todos";
            this.rdbTodos3.UseVisualStyleBackColor = true;
            this.rdbTodos3.Click += new System.EventHandler(this.RdbPP3_Click);
            // 
            // rdbPV3
            // 
            this.rdbPV3.AutoSize = true;
            this.rdbPV3.Location = new System.Drawing.Point(440, 8);
            this.rdbPV3.Name = "rdbPV3";
            this.rdbPV3.Size = new System.Drawing.Size(110, 30);
            this.rdbPV3.TabIndex = 33;
            this.rdbPV3.Tag = "PV";
            this.rdbPV3.Text = "Filtrar solo tipo de \r\nventa visa";
            this.rdbPV3.UseVisualStyleBackColor = true;
            this.rdbPV3.Click += new System.EventHandler(this.RdbPP3_Click);
            // 
            // rdbPP3
            // 
            this.rdbPP3.AutoSize = true;
            this.rdbPP3.Checked = true;
            this.rdbPP3.Location = new System.Drawing.Point(303, 8);
            this.rdbPP3.Name = "rdbPP3";
            this.rdbPP3.Size = new System.Drawing.Size(110, 30);
            this.rdbPP3.TabIndex = 32;
            this.rdbPP3.TabStop = true;
            this.rdbPP3.Tag = "PP";
            this.rdbPP3.Text = "Filtrar solo tipo de \r\nventa descuento";
            this.rdbPP3.UseVisualStyleBackColor = true;
            this.rdbPP3.Click += new System.EventHandler(this.RdbPP3_Click);
            // 
            // btnConfigurarComision2
            // 
            this.btnConfigurarComision2.BackColor = System.Drawing.Color.Teal;
            this.btnConfigurarComision2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfigurarComision2.ForeColor = System.Drawing.Color.White;
            this.btnConfigurarComision2.Location = new System.Drawing.Point(8, 4);
            this.btnConfigurarComision2.Name = "btnConfigurarComision2";
            this.btnConfigurarComision2.Size = new System.Drawing.Size(130, 38);
            this.btnConfigurarComision2.TabIndex = 30;
            this.btnConfigurarComision2.Text = "Configurar Comisión \r\npor Institución";
            this.btnConfigurarComision2.UseVisualStyleBackColor = false;
            this.btnConfigurarComision2.Click += new System.EventHandler(this.BtnConfigurarComision2_Click);
            // 
            // FrmComisiones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1285, 577);
            this.Controls.Add(this.tabControl1);
            this.KeyPreview = true;
            this.Name = "FrmComisiones";
            this.Text = "MANTENEDOR COMISIÓN";
            this.Load += new System.EventHandler(this.FrmComisiones_Load);
            this.tabControl1.ResumeLayout(false);
            this.tbComisiones.ResumeLayout(false);
            this.tbComisiones.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvComision)).EndInit();
            this.tbConfigComNVenta.ResumeLayout(false);
            this.tbConfigComNVenta.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFechaConfNivelVenta)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvComisionConfNivelVenta)).EndInit();
            this.tbConfigComInstitu.ResumeLayout(false);
            this.tbConfigComInstitu.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFechaConfInstitu)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvComisionConfInstitu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbComisiones;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvComision;
        private System.Windows.Forms.TreeView trvPersonas;
        private System.Windows.Forms.RadioButton rdbTodos;
        private System.Windows.Forms.RadioButton rdbPV;
        private System.Windows.Forms.RadioButton rdbPP;
        private System.Windows.Forms.Button btnReporte;
        private System.Windows.Forms.Button btnNuevaComision;
        private System.Windows.Forms.TabPage tbConfigComNVenta;
        private System.Windows.Forms.Button btnConfigurarComision;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvComisionConfNivelVenta;
        private System.Windows.Forms.RadioButton rdbTodos2;
        private System.Windows.Forms.RadioButton rdbPV2;
        private System.Windows.Forms.RadioButton rdbPP2;
        private System.Windows.Forms.ComboBox cboPersona;
        private System.Windows.Forms.ComboBox cboNivelVenta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvFechaConfNivelVenta;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.TabPage tbConfigComInstitu;
        private System.Windows.Forms.Button btnEliminar2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvFechaConfInstitu;
        private System.Windows.Forms.ComboBox cboInstitucion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvComisionConfInstitu;
        private System.Windows.Forms.RadioButton rdbTodos3;
        private System.Windows.Forms.RadioButton rdbPV3;
        private System.Windows.Forms.RadioButton rdbPP3;
        private System.Windows.Forms.Button btnConfigurarComision2;
    }
}