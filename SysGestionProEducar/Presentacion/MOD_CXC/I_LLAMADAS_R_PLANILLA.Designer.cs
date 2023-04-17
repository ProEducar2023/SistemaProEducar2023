namespace Presentacion.MOD_CXC
{
    partial class I_LLAMADAS_R_PLANILLA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(I_LLAMADAS_R_PLANILLA));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btn_eliminar2 = new System.Windows.Forms.Button();
            this.btn_salir = new System.Windows.Forms.Button();
            this.btn_nuevo = new System.Windows.Forms.Button();
            this.dgw_generados_det = new System.Windows.Forms.DataGridView();
            this.dgw_generadoss = new System.Windows.Forms.DataGridView();
            this.TabPage2 = new System.Windows.Forms.TabPage();
            this.txt_mes_mor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgw_pendientes_det = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_kardex = new System.Windows.Forms.Button();
            this.btn_grabar = new System.Windows.Forms.Button();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.dgw_pendientes = new System.Windows.Forms.DataGridView();
            this.NRO_PLANILLA_COB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FECHA_PLANILLA_COB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COD_DOC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COD_CLASE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NRO_DOC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NRO_CONTRATO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FECHA_CONTRATO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FECHA_RECEPCION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COD_COBRADOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OBSERVACION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NRO_LETRA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TOT_LETRA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COD_PER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COD_PTO_COB1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TIPO_CAMBIO1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LETRA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IMP_COB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FECHA_VEN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.X = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.FE_AÑO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FE_MES = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NRO_CONTRATO1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COD_SECTORISTA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FECHA_CONTRATO1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COD_PERSONA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESC_PER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IMP_DOC2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IMPORTE_PAGO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NRO_CUOTAS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COD_CLASE1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NRO_DOC1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COD_GESTOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.TabPage1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw_generados_det)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgw_generadoss)).BeginInit();
            this.TabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw_pendientes_det)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw_pendientes)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.TabPage1);
            this.tabControl1.Controls.Add(this.TabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1042, 612);
            this.tabControl1.TabIndex = 0;
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.panel4);
            this.TabPage1.Controls.Add(this.dgw_generados_det);
            this.TabPage1.Controls.Add(this.dgw_generadoss);
            this.TabPage1.Location = new System.Drawing.Point(4, 22);
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage1.Size = new System.Drawing.Size(1034, 586);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "Generados";
            this.TabPage1.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.btn_eliminar2);
            this.panel4.Controls.Add(this.btn_salir);
            this.panel4.Controls.Add(this.btn_nuevo);
            this.panel4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel4.Location = new System.Drawing.Point(807, 481);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(190, 85);
            this.panel4.TabIndex = 57;
            // 
            // btn_eliminar2
            // 
            this.btn_eliminar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_eliminar2.Image = ((System.Drawing.Image)(resources.GetObject("btn_eliminar2.Image")));
            this.btn_eliminar2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_eliminar2.Location = new System.Drawing.Point(96, 13);
            this.btn_eliminar2.Name = "btn_eliminar2";
            this.btn_eliminar2.Size = new System.Drawing.Size(77, 27);
            this.btn_eliminar2.TabIndex = 34;
            this.btn_eliminar2.Text = "&Eliminar";
            this.btn_eliminar2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_eliminar2.UseVisualStyleBackColor = true;
            // 
            // btn_salir
            // 
            this.btn_salir.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_salir.Image = ((System.Drawing.Image)(resources.GetObject("btn_salir.Image")));
            this.btn_salir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_salir.Location = new System.Drawing.Point(96, 46);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(77, 27);
            this.btn_salir.TabIndex = 33;
            this.btn_salir.Text = "&Salir";
            this.btn_salir.UseVisualStyleBackColor = true;
            this.btn_salir.Click += new System.EventHandler(this.btn_salir_Click);
            // 
            // btn_nuevo
            // 
            this.btn_nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_nuevo.Image = ((System.Drawing.Image)(resources.GetObject("btn_nuevo.Image")));
            this.btn_nuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_nuevo.Location = new System.Drawing.Point(13, 13);
            this.btn_nuevo.Name = "btn_nuevo";
            this.btn_nuevo.Size = new System.Drawing.Size(77, 27);
            this.btn_nuevo.TabIndex = 28;
            this.btn_nuevo.Text = "&Pendiente";
            this.btn_nuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_nuevo.UseVisualStyleBackColor = true;
            this.btn_nuevo.Click += new System.EventHandler(this.btn_nuevo_Click);
            // 
            // dgw_generados_det
            // 
            this.dgw_generados_det.AllowUserToAddRows = false;
            this.dgw_generados_det.AllowUserToDeleteRows = false;
            this.dgw_generados_det.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgw_generados_det.BackgroundColor = System.Drawing.Color.White;
            this.dgw_generados_det.Location = new System.Drawing.Point(37, 467);
            this.dgw_generados_det.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dgw_generados_det.MultiSelect = false;
            this.dgw_generados_det.Name = "dgw_generados_det";
            this.dgw_generados_det.ReadOnly = true;
            this.dgw_generados_det.RowHeadersWidth = 25;
            this.dgw_generados_det.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dgw_generados_det.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.dgw_generados_det.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgw_generados_det.Size = new System.Drawing.Size(644, 106);
            this.dgw_generados_det.TabIndex = 56;
            // 
            // dgw_generadoss
            // 
            this.dgw_generadoss.AllowUserToAddRows = false;
            this.dgw_generadoss.AllowUserToDeleteRows = false;
            this.dgw_generadoss.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgw_generadoss.BackgroundColor = System.Drawing.Color.White;
            this.dgw_generadoss.Location = new System.Drawing.Point(37, 14);
            this.dgw_generadoss.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dgw_generadoss.MultiSelect = false;
            this.dgw_generadoss.Name = "dgw_generadoss";
            this.dgw_generadoss.RowHeadersWidth = 25;
            this.dgw_generadoss.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dgw_generadoss.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.dgw_generadoss.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgw_generadoss.Size = new System.Drawing.Size(960, 451);
            this.dgw_generadoss.TabIndex = 55;
            // 
            // TabPage2
            // 
            this.TabPage2.Controls.Add(this.txt_mes_mor);
            this.TabPage2.Controls.Add(this.label1);
            this.TabPage2.Controls.Add(this.dgw_pendientes_det);
            this.TabPage2.Controls.Add(this.panel2);
            this.TabPage2.Controls.Add(this.dgw_pendientes);
            this.TabPage2.Location = new System.Drawing.Point(4, 22);
            this.TabPage2.Name = "TabPage2";
            this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage2.Size = new System.Drawing.Size(1034, 586);
            this.TabPage2.TabIndex = 1;
            this.TabPage2.Text = "Pendientes";
            this.TabPage2.UseVisualStyleBackColor = true;
            // 
            // txt_mes_mor
            // 
            this.txt_mes_mor.BackColor = System.Drawing.Color.White;
            this.txt_mes_mor.Location = new System.Drawing.Point(977, 465);
            this.txt_mes_mor.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_mes_mor.Name = "txt_mes_mor";
            this.txt_mes_mor.ReadOnly = true;
            this.txt_mes_mor.Size = new System.Drawing.Size(19, 20);
            this.txt_mes_mor.TabIndex = 135;
            this.txt_mes_mor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_mes_mor.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(863, 469);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 14);
            this.label1.TabIndex = 134;
            this.label1.Text = "Meses de Morosidad : ";
            this.label1.Visible = false;
            // 
            // dgw_pendientes_det
            // 
            this.dgw_pendientes_det.AllowUserToAddRows = false;
            this.dgw_pendientes_det.AllowUserToDeleteRows = false;
            this.dgw_pendientes_det.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgw_pendientes_det.BackgroundColor = System.Drawing.Color.White;
            this.dgw_pendientes_det.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NRO_PLANILLA_COB,
            this.FECHA_PLANILLA_COB,
            this.COD_DOC,
            this.COD_CLASE,
            this.NRO_DOC,
            this.NRO_CONTRATO,
            this.FECHA_CONTRATO,
            this.FECHA_RECEPCION,
            this.COD_COBRADOR,
            this.OBSERVACION,
            this.NRO_LETRA,
            this.TOT_LETRA,
            this.COD_PER,
            this.COD_PTO_COB1,
            this.TIPO_CAMBIO1,
            this.LETRA,
            this.IMP_COB,
            this.FECHA_VEN,
            this.X,
            this.FE_AÑO,
            this.FE_MES});
            this.dgw_pendientes_det.Location = new System.Drawing.Point(38, 468);
            this.dgw_pendientes_det.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dgw_pendientes_det.MultiSelect = false;
            this.dgw_pendientes_det.Name = "dgw_pendientes_det";
            this.dgw_pendientes_det.RowHeadersWidth = 25;
            this.dgw_pendientes_det.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dgw_pendientes_det.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.dgw_pendientes_det.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgw_pendientes_det.Size = new System.Drawing.Size(644, 106);
            this.dgw_pendientes_det.TabIndex = 63;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btn_kardex);
            this.panel2.Controls.Add(this.btn_grabar);
            this.panel2.Controls.Add(this.btn_cancelar);
            this.panel2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(815, 490);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(182, 80);
            this.panel2.TabIndex = 62;
            this.panel2.TabStop = true;
            // 
            // btn_kardex
            // 
            this.btn_kardex.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_kardex.Image = ((System.Drawing.Image)(resources.GetObject("btn_kardex.Image")));
            this.btn_kardex.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_kardex.Location = new System.Drawing.Point(13, 42);
            this.btn_kardex.Name = "btn_kardex";
            this.btn_kardex.Size = new System.Drawing.Size(77, 27);
            this.btn_kardex.TabIndex = 47;
            this.btn_kardex.Text = "&Consulta";
            this.btn_kardex.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_kardex.UseVisualStyleBackColor = true;
            // 
            // btn_grabar
            // 
            this.btn_grabar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_grabar.Image = ((System.Drawing.Image)(resources.GetObject("btn_grabar.Image")));
            this.btn_grabar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_grabar.Location = new System.Drawing.Point(13, 10);
            this.btn_grabar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_grabar.Name = "btn_grabar";
            this.btn_grabar.Size = new System.Drawing.Size(77, 27);
            this.btn_grabar.TabIndex = 46;
            this.btn_grabar.Text = "   &Grabar";
            this.btn_grabar.UseVisualStyleBackColor = true;
            this.btn_grabar.Click += new System.EventHandler(this.btn_grabar_Click);
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancelar.Image = ((System.Drawing.Image)(resources.GetObject("btn_cancelar.Image")));
            this.btn_cancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_cancelar.Location = new System.Drawing.Point(95, 9);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(77, 27);
            this.btn_cancelar.TabIndex = 22;
            this.btn_cancelar.Text = "&Cancelar";
            this.btn_cancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_cancelar.UseVisualStyleBackColor = true;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // dgw_pendientes
            // 
            this.dgw_pendientes.AllowUserToAddRows = false;
            this.dgw_pendientes.AllowUserToDeleteRows = false;
            this.dgw_pendientes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgw_pendientes.BackgroundColor = System.Drawing.Color.White;
            this.dgw_pendientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NRO_CONTRATO1,
            this.COD_SECTORISTA,
            this.FECHA_CONTRATO1,
            this.COD_PERSONA,
            this.DESC_PER,
            this.IMP_DOC2,
            this.IMPORTE_PAGO,
            this.NRO_CUOTAS,
            this.COD_CLASE1,
            this.NRO_DOC1,
            this.COD_GESTOR});
            this.dgw_pendientes.Location = new System.Drawing.Point(38, 21);
            this.dgw_pendientes.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dgw_pendientes.MultiSelect = false;
            this.dgw_pendientes.Name = "dgw_pendientes";
            this.dgw_pendientes.RowHeadersWidth = 25;
            this.dgw_pendientes.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dgw_pendientes.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.dgw_pendientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgw_pendientes.Size = new System.Drawing.Size(959, 441);
            this.dgw_pendientes.TabIndex = 61;
            this.dgw_pendientes.SelectionChanged += new System.EventHandler(this.dgw_pendientes_SelectionChanged);
            this.dgw_pendientes.Click += new System.EventHandler(this.dgw_pendientes_Click);
            // 
            // NRO_PLANILLA_COB
            // 
            this.NRO_PLANILLA_COB.HeaderText = "NRO_PLANILLA_COB";
            this.NRO_PLANILLA_COB.Name = "NRO_PLANILLA_COB";
            this.NRO_PLANILLA_COB.Visible = false;
            // 
            // FECHA_PLANILLA_COB
            // 
            this.FECHA_PLANILLA_COB.HeaderText = "FECHA_PLANILLA_COB";
            this.FECHA_PLANILLA_COB.Name = "FECHA_PLANILLA_COB";
            this.FECHA_PLANILLA_COB.Visible = false;
            // 
            // COD_DOC
            // 
            this.COD_DOC.HeaderText = "COD_DOC";
            this.COD_DOC.Name = "COD_DOC";
            this.COD_DOC.Visible = false;
            // 
            // COD_CLASE
            // 
            this.COD_CLASE.HeaderText = "COD_CLASE";
            this.COD_CLASE.Name = "COD_CLASE";
            this.COD_CLASE.Visible = false;
            // 
            // NRO_DOC
            // 
            this.NRO_DOC.HeaderText = "NRO_DOC";
            this.NRO_DOC.Name = "NRO_DOC";
            this.NRO_DOC.Visible = false;
            // 
            // NRO_CONTRATO
            // 
            this.NRO_CONTRATO.HeaderText = "Contrato";
            this.NRO_CONTRATO.Name = "NRO_CONTRATO";
            this.NRO_CONTRATO.ReadOnly = true;
            this.NRO_CONTRATO.Width = 80;
            // 
            // FECHA_CONTRATO
            // 
            this.FECHA_CONTRATO.HeaderText = "FECHA_CONTRATO";
            this.FECHA_CONTRATO.Name = "FECHA_CONTRATO";
            this.FECHA_CONTRATO.Visible = false;
            // 
            // FECHA_RECEPCION
            // 
            this.FECHA_RECEPCION.HeaderText = "FECHA_RECEPCION";
            this.FECHA_RECEPCION.Name = "FECHA_RECEPCION";
            this.FECHA_RECEPCION.Visible = false;
            // 
            // COD_COBRADOR
            // 
            this.COD_COBRADOR.HeaderText = "COD_COBRADOR";
            this.COD_COBRADOR.Name = "COD_COBRADOR";
            this.COD_COBRADOR.Visible = false;
            // 
            // OBSERVACION
            // 
            this.OBSERVACION.HeaderText = "OBSERVACION";
            this.OBSERVACION.Name = "OBSERVACION";
            this.OBSERVACION.Visible = false;
            // 
            // NRO_LETRA
            // 
            this.NRO_LETRA.HeaderText = "NRO_LETRA";
            this.NRO_LETRA.Name = "NRO_LETRA";
            this.NRO_LETRA.Visible = false;
            // 
            // TOT_LETRA
            // 
            this.TOT_LETRA.HeaderText = "TOT_LETRA";
            this.TOT_LETRA.Name = "TOT_LETRA";
            this.TOT_LETRA.Visible = false;
            // 
            // COD_PER
            // 
            this.COD_PER.HeaderText = "COD_PER";
            this.COD_PER.Name = "COD_PER";
            this.COD_PER.ReadOnly = true;
            this.COD_PER.Visible = false;
            // 
            // COD_PTO_COB1
            // 
            this.COD_PTO_COB1.HeaderText = "COD_PTO_COB1";
            this.COD_PTO_COB1.Name = "COD_PTO_COB1";
            this.COD_PTO_COB1.Visible = false;
            // 
            // TIPO_CAMBIO1
            // 
            this.TIPO_CAMBIO1.HeaderText = "TIPO_CAMBIO1";
            this.TIPO_CAMBIO1.Name = "TIPO_CAMBIO1";
            this.TIPO_CAMBIO1.Visible = false;
            // 
            // LETRA
            // 
            this.LETRA.HeaderText = "Letra";
            this.LETRA.Name = "LETRA";
            this.LETRA.ReadOnly = true;
            this.LETRA.Width = 70;
            // 
            // IMP_COB
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.IMP_COB.DefaultCellStyle = dataGridViewCellStyle1;
            this.IMP_COB.HeaderText = "Importe";
            this.IMP_COB.Name = "IMP_COB";
            this.IMP_COB.ReadOnly = true;
            this.IMP_COB.Width = 80;
            // 
            // FECHA_VEN
            // 
            this.FECHA_VEN.HeaderText = "Fe Venc";
            this.FECHA_VEN.Name = "FECHA_VEN";
            this.FECHA_VEN.ReadOnly = true;
            this.FECHA_VEN.Width = 80;
            // 
            // X
            // 
            this.X.HeaderText = "X";
            this.X.Name = "X";
            this.X.Width = 40;
            // 
            // FE_AÑO
            // 
            this.FE_AÑO.HeaderText = "FE_AÑO";
            this.FE_AÑO.Name = "FE_AÑO";
            this.FE_AÑO.Visible = false;
            // 
            // FE_MES
            // 
            this.FE_MES.HeaderText = "FE_MES";
            this.FE_MES.Name = "FE_MES";
            this.FE_MES.Visible = false;
            // 
            // NRO_CONTRATO1
            // 
            this.NRO_CONTRATO1.HeaderText = "Contrato";
            this.NRO_CONTRATO1.Name = "NRO_CONTRATO1";
            this.NRO_CONTRATO1.Width = 80;
            // 
            // COD_SECTORISTA
            // 
            this.COD_SECTORISTA.HeaderText = "COD_SECTORISTA";
            this.COD_SECTORISTA.Name = "COD_SECTORISTA";
            this.COD_SECTORISTA.Visible = false;
            // 
            // FECHA_CONTRATO1
            // 
            this.FECHA_CONTRATO1.HeaderText = "Fe Contrato";
            this.FECHA_CONTRATO1.Name = "FECHA_CONTRATO1";
            this.FECHA_CONTRATO1.Width = 80;
            // 
            // COD_PERSONA
            // 
            this.COD_PERSONA.HeaderText = "Codigo";
            this.COD_PERSONA.Name = "COD_PERSONA";
            this.COD_PERSONA.Width = 60;
            // 
            // DESC_PER
            // 
            this.DESC_PER.HeaderText = "Cliente";
            this.DESC_PER.Name = "DESC_PER";
            this.DESC_PER.Width = 320;
            // 
            // IMP_DOC2
            // 
            this.IMP_DOC2.HeaderText = "IMP_DOC2";
            this.IMP_DOC2.Name = "IMP_DOC2";
            this.IMP_DOC2.Visible = false;
            // 
            // IMPORTE_PAGO
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.IMPORTE_PAGO.DefaultCellStyle = dataGridViewCellStyle2;
            this.IMPORTE_PAGO.HeaderText = "Importe";
            this.IMPORTE_PAGO.Name = "IMPORTE_PAGO";
            this.IMPORTE_PAGO.Width = 80;
            // 
            // NRO_CUOTAS
            // 
            this.NRO_CUOTAS.HeaderText = "No Cuotas";
            this.NRO_CUOTAS.Name = "NRO_CUOTAS";
            this.NRO_CUOTAS.Width = 70;
            // 
            // COD_CLASE1
            // 
            this.COD_CLASE1.HeaderText = "COD_CLASE1";
            this.COD_CLASE1.Name = "COD_CLASE1";
            this.COD_CLASE1.Visible = false;
            // 
            // NRO_DOC1
            // 
            this.NRO_DOC1.HeaderText = "NRO_DOC1";
            this.NRO_DOC1.Name = "NRO_DOC1";
            this.NRO_DOC1.Visible = false;
            // 
            // COD_GESTOR
            // 
            this.COD_GESTOR.HeaderText = "COD_GESTOR";
            this.COD_GESTOR.Name = "COD_GESTOR";
            this.COD_GESTOR.Visible = false;
            // 
            // I_LLAMADAS_R_PLANILLA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1042, 611);
            this.Controls.Add(this.tabControl1);
            this.Name = "I_LLAMADAS_R_PLANILLA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "I_LLAMADAS_R_PLANILLA";
            this.Load += new System.EventHandler(this.I_LLAMADAS_R_PLANILLA_Load);
            this.tabControl1.ResumeLayout(false);
            this.TabPage1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgw_generados_det)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgw_generadoss)).EndInit();
            this.TabPage2.ResumeLayout(false);
            this.TabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw_pendientes_det)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgw_pendientes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage TabPage1;
        private System.Windows.Forms.TabPage TabPage2;
        private System.Windows.Forms.Panel panel4;
        internal System.Windows.Forms.Button btn_eliminar2;
        internal System.Windows.Forms.Button btn_salir;
        internal System.Windows.Forms.Button btn_nuevo;
        internal System.Windows.Forms.DataGridView dgw_generados_det;
        internal System.Windows.Forms.DataGridView dgw_generadoss;
        internal System.Windows.Forms.DataGridView dgw_pendientes_det;
        internal System.Windows.Forms.Panel panel2;
        internal System.Windows.Forms.Button btn_kardex;
        internal System.Windows.Forms.Button btn_grabar;
        internal System.Windows.Forms.Button btn_cancelar;
        internal System.Windows.Forms.DataGridView dgw_pendientes;
        internal System.Windows.Forms.TextBox txt_mes_mor;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn NRO_PLANILLA_COB;
        private System.Windows.Forms.DataGridViewTextBoxColumn FECHA_PLANILLA_COB;
        private System.Windows.Forms.DataGridViewTextBoxColumn COD_DOC;
        private System.Windows.Forms.DataGridViewTextBoxColumn COD_CLASE;
        private System.Windows.Forms.DataGridViewTextBoxColumn NRO_DOC;
        private System.Windows.Forms.DataGridViewTextBoxColumn NRO_CONTRATO;
        private System.Windows.Forms.DataGridViewTextBoxColumn FECHA_CONTRATO;
        private System.Windows.Forms.DataGridViewTextBoxColumn FECHA_RECEPCION;
        private System.Windows.Forms.DataGridViewTextBoxColumn COD_COBRADOR;
        private System.Windows.Forms.DataGridViewTextBoxColumn OBSERVACION;
        private System.Windows.Forms.DataGridViewTextBoxColumn NRO_LETRA;
        private System.Windows.Forms.DataGridViewTextBoxColumn TOT_LETRA;
        private System.Windows.Forms.DataGridViewTextBoxColumn COD_PER;
        private System.Windows.Forms.DataGridViewTextBoxColumn COD_PTO_COB1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TIPO_CAMBIO1;
        private System.Windows.Forms.DataGridViewTextBoxColumn LETRA;
        private System.Windows.Forms.DataGridViewTextBoxColumn IMP_COB;
        private System.Windows.Forms.DataGridViewTextBoxColumn FECHA_VEN;
        private System.Windows.Forms.DataGridViewCheckBoxColumn X;
        private System.Windows.Forms.DataGridViewTextBoxColumn FE_AÑO;
        private System.Windows.Forms.DataGridViewTextBoxColumn FE_MES;
        private System.Windows.Forms.DataGridViewTextBoxColumn NRO_CONTRATO1;
        private System.Windows.Forms.DataGridViewTextBoxColumn COD_SECTORISTA;
        private System.Windows.Forms.DataGridViewTextBoxColumn FECHA_CONTRATO1;
        private System.Windows.Forms.DataGridViewTextBoxColumn COD_PERSONA;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESC_PER;
        private System.Windows.Forms.DataGridViewTextBoxColumn IMP_DOC2;
        private System.Windows.Forms.DataGridViewTextBoxColumn IMPORTE_PAGO;
        private System.Windows.Forms.DataGridViewTextBoxColumn NRO_CUOTAS;
        private System.Windows.Forms.DataGridViewTextBoxColumn COD_CLASE1;
        private System.Windows.Forms.DataGridViewTextBoxColumn NRO_DOC1;
        private System.Windows.Forms.DataGridViewTextBoxColumn COD_GESTOR;

    }
}