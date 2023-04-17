namespace Presentacion.MOD_CXC.Reportes.Formulario
{
    partial class REPORTE_CARTERA_TOTAL_PROYECTADA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(REPORTE_CARTERA_TOTAL_PROYECTADA));
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdb2D3 = new System.Windows.Forms.RadioButton();
            this.rdb2D2 = new System.Windows.Forms.RadioButton();
            this.rdb2D1 = new System.Windows.Forms.RadioButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lblSubUbicacion = new System.Windows.Forms.Label();
            this.lblGrupoUbicacion = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboSubUbicacion = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboGrupoUbicacion = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.lblUbicacion = new System.Windows.Forms.Label();
            this.cboUbicacion = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdvPtoCob = new System.Windows.Forms.RadioButton();
            this.dtpFecReporte = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.chbSuspendido = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboPuntoCobranza = new System.Windows.Forms.ComboBox();
            this.cboPeriodoDesde = new System.Windows.Forms.ComboBox();
            this.dtpFecAprobHasta = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpFecAprobDesde = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboPrograma = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gb1 = new System.Windows.Forms.GroupBox();
            this.btn_impresion = new System.Windows.Forms.Button();
            this.btn_pantalla = new System.Windows.Forms.Button();
            this.btn_salir = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdbDetalladoXCont = new System.Windows.Forms.RadioButton();
            this.rdbResumen = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdbTodos = new System.Windows.Forms.RadioButton();
            this.rdbPV = new System.Windows.Forms.RadioButton();
            this.rdbPD = new System.Windows.Forms.RadioButton();
            this.rdbPP = new System.Windows.Forms.RadioButton();
            this.rdbSi = new System.Windows.Forms.RadioButton();
            this.rdbNo = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gb1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rdb2D3);
            this.panel1.Controls.Add(this.rdb2D2);
            this.panel1.Controls.Add(this.rdb2D1);
            this.panel1.Location = new System.Drawing.Point(11, 426);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(779, 63);
            this.panel1.TabIndex = 146;
            // 
            // rdb2D3
            // 
            this.rdb2D3.Checked = true;
            this.rdb2D3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdb2D3.Location = new System.Drawing.Point(550, 4);
            this.rdb2D3.Name = "rdb2D3";
            this.rdb2D3.Size = new System.Drawing.Size(159, 54);
            this.rdb2D3.TabIndex = 150;
            this.rdb2D3.TabStop = true;
            this.rdb2D3.Text = "Ubicación       : Todos Grupo Ubic.     : Todos Sub Ubicación : Todos";
            this.rdb2D3.UseVisualStyleBackColor = true;
            this.rdb2D3.CheckedChanged += new System.EventHandler(this.rdb2D3_CheckedChanged);
            // 
            // rdb2D2
            // 
            this.rdb2D2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdb2D2.Location = new System.Drawing.Point(303, 4);
            this.rdb2D2.Name = "rdb2D2";
            this.rdb2D2.Size = new System.Drawing.Size(197, 54);
            this.rdb2D2.TabIndex = 149;
            this.rdb2D2.Text = "Ubicación       : Elije 1 Grupo Ubic.     : Elije 1 Sub Ubicación : Todos";
            this.rdb2D2.UseVisualStyleBackColor = true;
            this.rdb2D2.CheckedChanged += new System.EventHandler(this.rdb2D2_CheckedChanged);
            // 
            // rdb2D1
            // 
            this.rdb2D1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdb2D1.Location = new System.Drawing.Point(75, 5);
            this.rdb2D1.Name = "rdb2D1";
            this.rdb2D1.Size = new System.Drawing.Size(197, 54);
            this.rdb2D1.TabIndex = 146;
            this.rdb2D1.Text = "Ubicación       : Elije 1 Grupo Ubic.     : Elije 1 Sub Ubicación : Elije 1";
            this.rdb2D1.UseVisualStyleBackColor = true;
            this.rdb2D1.CheckedChanged += new System.EventHandler(this.rdb2D1_CheckedChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(10, 290);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(780, 133);
            this.tabControl1.TabIndex = 144;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.lblSubUbicacion);
            this.tabPage3.Controls.Add(this.lblGrupoUbicacion);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.cboSubUbicacion);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.cboGrupoUbicacion);
            this.tabPage3.Controls.Add(this.label20);
            this.tabPage3.Controls.Add(this.lblUbicacion);
            this.tabPage3.Controls.Add(this.cboUbicacion);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(772, 107);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // lblSubUbicacion
            // 
            this.lblSubUbicacion.AutoSize = true;
            this.lblSubUbicacion.Location = new System.Drawing.Point(69, 71);
            this.lblSubUbicacion.Name = "lblSubUbicacion";
            this.lblSubUbicacion.Size = new System.Drawing.Size(77, 13);
            this.lblSubUbicacion.TabIndex = 140;
            this.lblSubUbicacion.Text = "Sub Ubicacion";
            // 
            // lblGrupoUbicacion
            // 
            this.lblGrupoUbicacion.AutoSize = true;
            this.lblGrupoUbicacion.Location = new System.Drawing.Point(59, 43);
            this.lblGrupoUbicacion.Name = "lblGrupoUbicacion";
            this.lblGrupoUbicacion.Size = new System.Drawing.Size(87, 13);
            this.lblGrupoUbicacion.TabIndex = 139;
            this.lblGrupoUbicacion.Text = "Grupo Ubicacion";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(91, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 138;
            this.label3.Text = "Ubicación";
            // 
            // cboSubUbicacion
            // 
            this.cboSubUbicacion.BackColor = System.Drawing.Color.White;
            this.cboSubUbicacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSubUbicacion.FormattingEnabled = true;
            this.cboSubUbicacion.Location = new System.Drawing.Point(166, 65);
            this.cboSubUbicacion.Name = "cboSubUbicacion";
            this.cboSubUbicacion.Size = new System.Drawing.Size(319, 21);
            this.cboSubUbicacion.TabIndex = 136;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(69, 68);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 13);
            this.label8.TabIndex = 137;
            // 
            // cboGrupoUbicacion
            // 
            this.cboGrupoUbicacion.BackColor = System.Drawing.Color.White;
            this.cboGrupoUbicacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGrupoUbicacion.FormattingEnabled = true;
            this.cboGrupoUbicacion.Location = new System.Drawing.Point(166, 40);
            this.cboGrupoUbicacion.Name = "cboGrupoUbicacion";
            this.cboGrupoUbicacion.Size = new System.Drawing.Size(319, 21);
            this.cboGrupoUbicacion.TabIndex = 134;
            this.cboGrupoUbicacion.SelectionChangeCommitted += new System.EventHandler(this.cboGrupoUbicacion_SelectionChangeCommitted);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(59, 40);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(0, 13);
            this.label20.TabIndex = 135;
            // 
            // lblUbicacion
            // 
            this.lblUbicacion.AutoSize = true;
            this.lblUbicacion.Location = new System.Drawing.Point(91, 19);
            this.lblUbicacion.Name = "lblUbicacion";
            this.lblUbicacion.Size = new System.Drawing.Size(0, 13);
            this.lblUbicacion.TabIndex = 131;
            // 
            // cboUbicacion
            // 
            this.cboUbicacion.BackColor = System.Drawing.Color.White;
            this.cboUbicacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUbicacion.FormattingEnabled = true;
            this.cboUbicacion.Location = new System.Drawing.Point(166, 16);
            this.cboUbicacion.Name = "cboUbicacion";
            this.cboUbicacion.Size = new System.Drawing.Size(319, 21);
            this.cboUbicacion.TabIndex = 130;
            this.cboUbicacion.SelectionChangeCommitted += new System.EventHandler(this.cboUbicacion_SelectionChangeCommitted);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbNo);
            this.groupBox1.Controls.Add(this.rdbSi);
            this.groupBox1.Controls.Add(this.rdvPtoCob);
            this.groupBox1.Controls.Add(this.dtpFecReporte);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.chbSuspendido);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cboPuntoCobranza);
            this.groupBox1.Controls.Add(this.cboPeriodoDesde);
            this.groupBox1.Controls.Add(this.dtpFecAprobHasta);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.dtpFecAprobDesde);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cboPrograma);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(14, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(772, 182);
            this.groupBox1.TabIndex = 143;
            this.groupBox1.TabStop = false;
            // 
            // rdvPtoCob
            // 
            this.rdvPtoCob.AutoSize = true;
            this.rdvPtoCob.Location = new System.Drawing.Point(633, 23);
            this.rdvPtoCob.Name = "rdvPtoCob";
            this.rdvPtoCob.Size = new System.Drawing.Size(89, 17);
            this.rdvPtoCob.TabIndex = 153;
            this.rdvPtoCob.Text = "Pto Cobranza";
            this.rdvPtoCob.UseVisualStyleBackColor = true;
            this.rdvPtoCob.Visible = false;
            this.rdvPtoCob.CheckedChanged += new System.EventHandler(this.rdvPtoCob_CheckedChanged);
            // 
            // dtpFecReporte
            // 
            this.dtpFecReporte.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecReporte.Location = new System.Drawing.Point(209, 102);
            this.dtpFecReporte.Name = "dtpFecReporte";
            this.dtpFecReporte.Size = new System.Drawing.Size(80, 20);
            this.dtpFecReporte.TabIndex = 137;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(107, 106);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(93, 13);
            this.label10.TabIndex = 138;
            this.label10.Text = "Fecha de Reporte";
            // 
            // chbSuspendido
            // 
            this.chbSuspendido.AutoSize = true;
            this.chbSuspendido.Location = new System.Drawing.Point(300, 101);
            this.chbSuspendido.Name = "chbSuspendido";
            this.chbSuspendido.Size = new System.Drawing.Size(525, 17);
            this.chbSuspendido.TabIndex = 136;
            this.chbSuspendido.Text = "No : Incluye Contratos Suspendidos (No Suma Importes)  / Sin Convenio / Sin Autor" +
    "ización de Descuento";
            this.chbSuspendido.UseVisualStyleBackColor = true;
            this.chbSuspendido.Visible = false;
            this.chbSuspendido.CheckedChanged += new System.EventHandler(this.chbSuspendido_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(526, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 135;
            this.label5.Text = "Punto Cobranza";
            this.label5.Visible = false;
            // 
            // cboPuntoCobranza
            // 
            this.cboPuntoCobranza.BackColor = System.Drawing.Color.White;
            this.cboPuntoCobranza.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPuntoCobranza.FormattingEnabled = true;
            this.cboPuntoCobranza.Location = new System.Drawing.Point(514, 46);
            this.cboPuntoCobranza.Name = "cboPuntoCobranza";
            this.cboPuntoCobranza.Size = new System.Drawing.Size(247, 21);
            this.cboPuntoCobranza.TabIndex = 134;
            this.cboPuntoCobranza.Visible = false;
            // 
            // cboPeriodoDesde
            // 
            this.cboPeriodoDesde.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPeriodoDesde.FormattingEnabled = true;
            this.cboPeriodoDesde.Location = new System.Drawing.Point(208, 74);
            this.cboPeriodoDesde.Name = "cboPeriodoDesde";
            this.cboPeriodoDesde.Size = new System.Drawing.Size(126, 21);
            this.cboPeriodoDesde.TabIndex = 133;
            this.cboPeriodoDesde.SelectionChangeCommitted += new System.EventHandler(this.cboPeriodoDesde_SelectionChangeCommitted);
            // 
            // dtpFecAprobHasta
            // 
            this.dtpFecAprobHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecAprobHasta.Location = new System.Drawing.Point(375, 45);
            this.dtpFecAprobHasta.Name = "dtpFecAprobHasta";
            this.dtpFecAprobHasta.Size = new System.Drawing.Size(80, 20);
            this.dtpFecAprobHasta.TabIndex = 123;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(341, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 13);
            this.label6.TabIndex = 127;
            this.label6.Text = "al";
            // 
            // dtpFecAprobDesde
            // 
            this.dtpFecAprobDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecAprobDesde.Location = new System.Drawing.Point(240, 45);
            this.dtpFecAprobDesde.Name = "dtpFecAprobDesde";
            this.dtpFecAprobDesde.Size = new System.Drawing.Size(80, 20);
            this.dtpFecAprobDesde.TabIndex = 121;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(108, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(126, 13);
            this.label7.TabIndex = 125;
            this.label7.Text = "Fecha de Aprobacion del";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(107, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 121;
            this.label2.Text = "Mes de Proyeccion";
            // 
            // cboPrograma
            // 
            this.cboPrograma.BackColor = System.Drawing.Color.White;
            this.cboPrograma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPrograma.FormattingEnabled = true;
            this.cboPrograma.Location = new System.Drawing.Point(208, 17);
            this.cboPrograma.Name = "cboPrograma";
            this.cboPrograma.Size = new System.Drawing.Size(247, 21);
            this.cboPrograma.TabIndex = 117;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(109, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 118;
            this.label1.Text = "Programa";
            // 
            // gb1
            // 
            this.gb1.BackColor = System.Drawing.Color.White;
            this.gb1.Controls.Add(this.btn_impresion);
            this.gb1.Controls.Add(this.btn_pantalla);
            this.gb1.Controls.Add(this.btn_salir);
            this.gb1.Location = new System.Drawing.Point(14, 495);
            this.gb1.Name = "gb1";
            this.gb1.Size = new System.Drawing.Size(776, 54);
            this.gb1.TabIndex = 142;
            this.gb1.TabStop = false;
            // 
            // btn_impresion
            // 
            this.btn_impresion.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_impresion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_impresion.Image = ((System.Drawing.Image)(resources.GetObject("btn_impresion.Image")));
            this.btn_impresion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_impresion.Location = new System.Drawing.Point(347, 18);
            this.btn_impresion.Name = "btn_impresion";
            this.btn_impresion.Size = new System.Drawing.Size(77, 27);
            this.btn_impresion.TabIndex = 17;
            this.btn_impresion.Text = "&Imprimir";
            this.btn_impresion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_impresion.UseVisualStyleBackColor = false;
            // 
            // btn_pantalla
            // 
            this.btn_pantalla.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_pantalla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_pantalla.Image = ((System.Drawing.Image)(resources.GetObject("btn_pantalla.Image")));
            this.btn_pantalla.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_pantalla.Location = new System.Drawing.Point(254, 18);
            this.btn_pantalla.Name = "btn_pantalla";
            this.btn_pantalla.Size = new System.Drawing.Size(77, 27);
            this.btn_pantalla.TabIndex = 15;
            this.btn_pantalla.Text = "Reporte";
            this.btn_pantalla.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_pantalla.UseVisualStyleBackColor = false;
            this.btn_pantalla.Click += new System.EventHandler(this.btn_pantalla_Click);
            // 
            // btn_salir
            // 
            this.btn_salir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_salir.Image = ((System.Drawing.Image)(resources.GetObject("btn_salir.Image")));
            this.btn_salir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_salir.Location = new System.Drawing.Point(441, 18);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(75, 26);
            this.btn_salir.TabIndex = 19;
            this.btn_salir.Text = "&Salir";
            this.btn_salir.UseVisualStyleBackColor = true;
            this.btn_salir.Click += new System.EventHandler(this.btn_salir_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdbDetalladoXCont);
            this.groupBox2.Controls.Add(this.rdbResumen);
            this.groupBox2.Location = new System.Drawing.Point(14, 194);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(772, 45);
            this.groupBox2.TabIndex = 148;
            this.groupBox2.TabStop = false;
            // 
            // rdbDetalladoXCont
            // 
            this.rdbDetalladoXCont.AutoSize = true;
            this.rdbDetalladoXCont.Location = new System.Drawing.Point(445, 14);
            this.rdbDetalladoXCont.Name = "rdbDetalladoXCont";
            this.rdbDetalladoXCont.Size = new System.Drawing.Size(123, 17);
            this.rdbDetalladoXCont.TabIndex = 149;
            this.rdbDetalladoXCont.Text = "Detallado X Contrato";
            this.rdbDetalladoXCont.UseVisualStyleBackColor = true;
            // 
            // rdbResumen
            // 
            this.rdbResumen.AutoSize = true;
            this.rdbResumen.Checked = true;
            this.rdbResumen.Location = new System.Drawing.Point(204, 14);
            this.rdbResumen.Name = "rdbResumen";
            this.rdbResumen.Size = new System.Drawing.Size(70, 17);
            this.rdbResumen.TabIndex = 148;
            this.rdbResumen.TabStop = true;
            this.rdbResumen.Text = "Resumen";
            this.rdbResumen.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rdbTodos);
            this.groupBox3.Controls.Add(this.rdbPV);
            this.groupBox3.Controls.Add(this.rdbPD);
            this.groupBox3.Controls.Add(this.rdbPP);
            this.groupBox3.Location = new System.Drawing.Point(14, 239);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(772, 45);
            this.groupBox3.TabIndex = 149;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tipos Ubicacion";
            // 
            // rdbTodos
            // 
            this.rdbTodos.AutoSize = true;
            this.rdbTodos.Checked = true;
            this.rdbTodos.Location = new System.Drawing.Point(53, 16);
            this.rdbTodos.Name = "rdbTodos";
            this.rdbTodos.Size = new System.Drawing.Size(55, 17);
            this.rdbTodos.TabIndex = 152;
            this.rdbTodos.TabStop = true;
            this.rdbTodos.Text = "Todos";
            this.rdbTodos.UseVisualStyleBackColor = true;
            this.rdbTodos.CheckedChanged += new System.EventHandler(this.rdbTodos_CheckedChanged);
            // 
            // rdbPV
            // 
            this.rdbPV.AutoSize = true;
            this.rdbPV.Location = new System.Drawing.Point(649, 16);
            this.rdbPV.Name = "rdbPV";
            this.rdbPV.Size = new System.Drawing.Size(45, 17);
            this.rdbPV.TabIndex = 150;
            this.rdbPV.Text = "Visa";
            this.rdbPV.UseVisualStyleBackColor = true;
            this.rdbPV.CheckedChanged += new System.EventHandler(this.rdbPV_CheckedChanged);
            // 
            // rdbPD
            // 
            this.rdbPD.AutoSize = true;
            this.rdbPD.Location = new System.Drawing.Point(446, 16);
            this.rdbPD.Name = "rdbPD";
            this.rdbPD.Size = new System.Drawing.Size(59, 17);
            this.rdbPD.TabIndex = 149;
            this.rdbPD.Text = "Directa";
            this.rdbPD.UseVisualStyleBackColor = true;
            this.rdbPD.CheckedChanged += new System.EventHandler(this.rdbPD_CheckedChanged);
            // 
            // rdbPP
            // 
            this.rdbPP.AutoSize = true;
            this.rdbPP.Location = new System.Drawing.Point(238, 16);
            this.rdbPP.Name = "rdbPP";
            this.rdbPP.Size = new System.Drawing.Size(76, 17);
            this.rdbPP.TabIndex = 148;
            this.rdbPP.Text = "Dscto. Plla";
            this.rdbPP.UseVisualStyleBackColor = true;
            this.rdbPP.CheckedChanged += new System.EventHandler(this.rdbPP_CheckedChanged);
            // 
            // rdbSi
            // 
            this.rdbSi.AutoSize = true;
            this.rdbSi.Location = new System.Drawing.Point(111, 134);
            this.rdbSi.Name = "rdbSi";
            this.rdbSi.Size = new System.Drawing.Size(521, 17);
            this.rdbSi.TabIndex = 154;
            this.rdbSi.Text = "Sí : Incluye Contratos Suspendidos (No Suma Importes)  / Sin Convenio / Sin Autor" +
    "ización de Descuento";
            this.rdbSi.UseVisualStyleBackColor = true;
            // 
            // rdbNo
            // 
            this.rdbNo.AutoSize = true;
            this.rdbNo.Checked = true;
            this.rdbNo.Location = new System.Drawing.Point(111, 159);
            this.rdbNo.Name = "rdbNo";
            this.rdbNo.Size = new System.Drawing.Size(524, 17);
            this.rdbNo.TabIndex = 155;
            this.rdbNo.TabStop = true;
            this.rdbNo.Text = "No : Incluye Contratos Suspendidos (No Suma Importes)  / Sin Convenio / Sin Autor" +
    "ización de Descuento";
            this.rdbNo.UseVisualStyleBackColor = true;
            // 
            // REPORTE_CARTERA_TOTAL_PROYECTADA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 555);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gb1);
            this.Name = "REPORTE_CARTERA_TOTAL_PROYECTADA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PROYECCION DE COBRANZAS - MES VENCIDO (POR PESONA)";
            this.Load += new System.EventHandler(this.REPORTE_CARTERA_TOTAL_PROYECTADA_Load);
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gb1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.ComboBox cboPeriodoDesde;
        internal System.Windows.Forms.DateTimePicker dtpFecAprobHasta;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.DateTimePicker dtpFecAprobDesde;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.ComboBox cboPrograma;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.GroupBox gb1;
        internal System.Windows.Forms.Button btn_impresion;
        internal System.Windows.Forms.Button btn_pantalla;
        internal System.Windows.Forms.Button btn_salir;
        private System.Windows.Forms.TabPage tabPage3;
        internal System.Windows.Forms.ComboBox cboSubUbicacion;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.ComboBox cboGrupoUbicacion;
        internal System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lblUbicacion;
        internal System.Windows.Forms.ComboBox cboUbicacion;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label lblSubUbicacion;
        internal System.Windows.Forms.Label lblGrupoUbicacion;
        private System.Windows.Forms.Label label5;
        internal System.Windows.Forms.ComboBox cboPuntoCobranza;
        private System.Windows.Forms.RadioButton rdb2D1;
        private System.Windows.Forms.CheckBox chbSuspendido;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdbDetalladoXCont;
        private System.Windows.Forms.RadioButton rdbResumen;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rdbPV;
        private System.Windows.Forms.RadioButton rdbPD;
        private System.Windows.Forms.RadioButton rdbPP;
        private System.Windows.Forms.RadioButton rdbTodos;
        private System.Windows.Forms.RadioButton rdb2D2;
        private System.Windows.Forms.RadioButton rdb2D3;
        internal System.Windows.Forms.DateTimePicker dtpFecReporte;
        internal System.Windows.Forms.Label label10;
        private System.Windows.Forms.RadioButton rdvPtoCob;
        private System.Windows.Forms.RadioButton rdbNo;
        private System.Windows.Forms.RadioButton rdbSi;
    }
}