namespace Presentacion.MOD_FACT_VTA
{
    partial class FrmConsultarTicketSunat
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
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dpHasta = new System.Windows.Forms.DateTimePicker();
            this.dpDe = new System.Windows.Forms.DateTimePicker();
            this.btnListar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnEnviarSunat = new System.Windows.Forms.Button();
            this.dgvResumenBoletas = new System.Windows.Forms.DataGridView();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dpHastaBajasBoleta = new System.Windows.Forms.DateTimePicker();
            this.dpDeBajasBoleta = new System.Windows.Forms.DateTimePicker();
            this.btnListarBoletasBajas = new System.Windows.Forms.Button();
            this.btnSalir2 = new System.Windows.Forms.Button();
            this.btnConsultarSunatBoletaBajas = new System.Windows.Forms.Button();
            this.dgvBoletaBajas = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewLinkColumn1 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.dataGridViewLinkColumn2 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dpHasta3 = new System.Windows.Forms.DateTimePicker();
            this.dpDe3 = new System.Windows.Forms.DateTimePicker();
            this.btnListarFacturasBajas = new System.Windows.Forms.Button();
            this.btnSalir3 = new System.Windows.Forms.Button();
            this.btnConsultarFacturasBajas = new System.Windows.Forms.Button();
            this.dgvFacturasBaja = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewLinkColumn3 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.dataGridViewLinkColumn4 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TabControl1.SuspendLayout();
            this.TabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResumenBoletas)).BeginInit();
            this.TabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBoletaBajas)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturasBaja)).BeginInit();
            this.SuspendLayout();
            // 
            // TabControl1
            // 
            this.TabControl1.Controls.Add(this.TabPage1);
            this.TabControl1.Controls.Add(this.TabPage2);
            this.TabControl1.Controls.Add(this.tabPage3);
            this.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl1.Location = new System.Drawing.Point(0, 0);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(821, 521);
            this.TabControl1.TabIndex = 47;
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.groupBox1);
            this.TabPage1.Controls.Add(this.btnSalir);
            this.TabPage1.Controls.Add(this.btnEnviarSunat);
            this.TabPage1.Controls.Add(this.dgvResumenBoletas);
            this.TabPage1.Location = new System.Drawing.Point(4, 22);
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage1.Size = new System.Drawing.Size(813, 495);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "Resumen Diario Boletas y notas";
            this.TabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dpHasta);
            this.groupBox1.Controls.Add(this.dpDe);
            this.groupBox1.Controls.Add(this.btnListar);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(10, 435);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(363, 54);
            this.groupBox1.TabIndex = 49;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Consultar";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(127, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 54;
            this.label2.Text = "Hasta:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 53;
            this.label1.Text = "De:";
            // 
            // dpHasta
            // 
            this.dpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpHasta.Location = new System.Drawing.Point(171, 23);
            this.dpHasta.Name = "dpHasta";
            this.dpHasta.Size = new System.Drawing.Size(89, 20);
            this.dpHasta.TabIndex = 52;
            // 
            // dpDe
            // 
            this.dpDe.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpDe.Location = new System.Drawing.Point(32, 22);
            this.dpDe.Name = "dpDe";
            this.dpDe.Size = new System.Drawing.Size(89, 20);
            this.dpDe.TabIndex = 51;
            // 
            // btnListar
            // 
            this.btnListar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnListar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnListar.Location = new System.Drawing.Point(278, 12);
            this.btnListar.Name = "btnListar";
            this.btnListar.Size = new System.Drawing.Size(74, 36);
            this.btnListar.TabIndex = 50;
            this.btnListar.Text = "Listar";
            this.btnListar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnListar.UseVisualStyleBackColor = true;
            this.btnListar.Click += new System.EventHandler(this.btnListar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.Location = new System.Drawing.Point(597, 446);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(71, 36);
            this.btnSalir.TabIndex = 48;
            this.btnSalir.Text = "   Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnEnviarSunat
            // 
            this.btnEnviarSunat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnviarSunat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnviarSunat.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEnviarSunat.Location = new System.Drawing.Point(675, 446);
            this.btnEnviarSunat.Name = "btnEnviarSunat";
            this.btnEnviarSunat.Size = new System.Drawing.Size(132, 36);
            this.btnEnviarSunat.TabIndex = 47;
            this.btnEnviarSunat.Text = "   Consultar Sunat";
            this.btnEnviarSunat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEnviarSunat.UseVisualStyleBackColor = true;
            this.btnEnviarSunat.Click += new System.EventHandler(this.btnEnviarSunat_Click);
            // 
            // dgvResumenBoletas
            // 
            this.dgvResumenBoletas.AllowUserToAddRows = false;
            this.dgvResumenBoletas.AllowUserToDeleteRows = false;
            this.dgvResumenBoletas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvResumenBoletas.BackgroundColor = System.Drawing.Color.White;
            this.dgvResumenBoletas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column11,
            this.Column4,
            this.Column2,
            this.Column5,
            this.Column6,
            this.Column7});
            this.dgvResumenBoletas.Location = new System.Drawing.Point(6, 6);
            this.dgvResumenBoletas.Name = "dgvResumenBoletas";
            this.dgvResumenBoletas.ReadOnly = true;
            this.dgvResumenBoletas.RowHeadersWidth = 25;
            this.dgvResumenBoletas.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dgvResumenBoletas.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.dgvResumenBoletas.RowTemplate.Height = 24;
            this.dgvResumenBoletas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResumenBoletas.Size = new System.Drawing.Size(803, 423);
            this.dgvResumenBoletas.TabIndex = 42;
            this.dgvResumenBoletas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvResumenBoletas_CellContentClick);
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Nro. Ticket";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 120;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "Fecha Envio";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Estado";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 320;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Detalle";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 80;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Descargar archivos";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 150;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "xml";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column6.Visible = false;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "cdr";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column7.Visible = false;
            // 
            // TabPage2
            // 
            this.TabPage2.Controls.Add(this.groupBox2);
            this.TabPage2.Controls.Add(this.btnSalir2);
            this.TabPage2.Controls.Add(this.btnConsultarSunatBoletaBajas);
            this.TabPage2.Controls.Add(this.dgvBoletaBajas);
            this.TabPage2.Location = new System.Drawing.Point(4, 22);
            this.TabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.TabPage2.Name = "TabPage2";
            this.TabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.TabPage2.Size = new System.Drawing.Size(813, 495);
            this.TabPage2.TabIndex = 1;
            this.TabPage2.Text = "Resumen de boletas y notas de baja";
            this.TabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.dpHastaBajasBoleta);
            this.groupBox2.Controls.Add(this.dpDeBajasBoleta);
            this.groupBox2.Controls.Add(this.btnListarBoletasBajas);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(9, 435);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(363, 54);
            this.groupBox2.TabIndex = 53;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Consultar";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(127, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 54;
            this.label3.Text = "Hasta:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 13);
            this.label4.TabIndex = 53;
            this.label4.Text = "De:";
            // 
            // dpHastaBajasBoleta
            // 
            this.dpHastaBajasBoleta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpHastaBajasBoleta.Location = new System.Drawing.Point(171, 23);
            this.dpHastaBajasBoleta.Name = "dpHastaBajasBoleta";
            this.dpHastaBajasBoleta.Size = new System.Drawing.Size(89, 20);
            this.dpHastaBajasBoleta.TabIndex = 52;
            // 
            // dpDeBajasBoleta
            // 
            this.dpDeBajasBoleta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpDeBajasBoleta.Location = new System.Drawing.Point(32, 22);
            this.dpDeBajasBoleta.Name = "dpDeBajasBoleta";
            this.dpDeBajasBoleta.Size = new System.Drawing.Size(89, 20);
            this.dpDeBajasBoleta.TabIndex = 51;
            // 
            // btnListarBoletasBajas
            // 
            this.btnListarBoletasBajas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnListarBoletasBajas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListarBoletasBajas.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnListarBoletasBajas.Location = new System.Drawing.Point(278, 12);
            this.btnListarBoletasBajas.Name = "btnListarBoletasBajas";
            this.btnListarBoletasBajas.Size = new System.Drawing.Size(74, 36);
            this.btnListarBoletasBajas.TabIndex = 50;
            this.btnListarBoletasBajas.Text = "Listar";
            this.btnListarBoletasBajas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnListarBoletasBajas.UseVisualStyleBackColor = true;
            this.btnListarBoletasBajas.Click += new System.EventHandler(this.btnListarBoletasBajas_Click);
            // 
            // btnSalir2
            // 
            this.btnSalir2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir2.Location = new System.Drawing.Point(596, 446);
            this.btnSalir2.Name = "btnSalir2";
            this.btnSalir2.Size = new System.Drawing.Size(71, 36);
            this.btnSalir2.TabIndex = 52;
            this.btnSalir2.Text = "   Salir";
            this.btnSalir2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir2.UseVisualStyleBackColor = true;
            this.btnSalir2.Click += new System.EventHandler(this.btnSalir2_Click);
            // 
            // btnConsultarSunatBoletaBajas
            // 
            this.btnConsultarSunatBoletaBajas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConsultarSunatBoletaBajas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsultarSunatBoletaBajas.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConsultarSunatBoletaBajas.Location = new System.Drawing.Point(674, 446);
            this.btnConsultarSunatBoletaBajas.Name = "btnConsultarSunatBoletaBajas";
            this.btnConsultarSunatBoletaBajas.Size = new System.Drawing.Size(132, 36);
            this.btnConsultarSunatBoletaBajas.TabIndex = 51;
            this.btnConsultarSunatBoletaBajas.Text = "   Consultar Sunat";
            this.btnConsultarSunatBoletaBajas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConsultarSunatBoletaBajas.UseVisualStyleBackColor = true;
            this.btnConsultarSunatBoletaBajas.Click += new System.EventHandler(this.btnConsultarSunatBoletaBajas_Click);
            // 
            // dgvBoletaBajas
            // 
            this.dgvBoletaBajas.AllowUserToAddRows = false;
            this.dgvBoletaBajas.AllowUserToDeleteRows = false;
            this.dgvBoletaBajas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBoletaBajas.BackgroundColor = System.Drawing.Color.White;
            this.dgvBoletaBajas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewLinkColumn1,
            this.dataGridViewLinkColumn2,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.dgvBoletaBajas.Location = new System.Drawing.Point(5, 6);
            this.dgvBoletaBajas.Name = "dgvBoletaBajas";
            this.dgvBoletaBajas.ReadOnly = true;
            this.dgvBoletaBajas.RowHeadersWidth = 25;
            this.dgvBoletaBajas.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dgvBoletaBajas.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.dgvBoletaBajas.RowTemplate.Height = 24;
            this.dgvBoletaBajas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBoletaBajas.Size = new System.Drawing.Size(803, 423);
            this.dgvBoletaBajas.TabIndex = 50;
            this.dgvBoletaBajas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBoletaBajas_CellContentClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Nro. Ticket";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 120;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Fecha Envio";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Estado";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 320;
            // 
            // dataGridViewLinkColumn1
            // 
            this.dataGridViewLinkColumn1.HeaderText = "Detalle";
            this.dataGridViewLinkColumn1.Name = "dataGridViewLinkColumn1";
            this.dataGridViewLinkColumn1.ReadOnly = true;
            this.dataGridViewLinkColumn1.Width = 80;
            // 
            // dataGridViewLinkColumn2
            // 
            this.dataGridViewLinkColumn2.HeaderText = "Descargar archivos";
            this.dataGridViewLinkColumn2.Name = "dataGridViewLinkColumn2";
            this.dataGridViewLinkColumn2.ReadOnly = true;
            this.dataGridViewLinkColumn2.Width = 150;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "xml";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "cdr";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn5.Visible = false;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox3);
            this.tabPage3.Controls.Add(this.btnSalir3);
            this.tabPage3.Controls.Add(this.btnConsultarFacturasBajas);
            this.tabPage3.Controls.Add(this.dgvFacturasBaja);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(813, 495);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Facturas y notas asociadas de baja";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.dpHasta3);
            this.groupBox3.Controls.Add(this.dpDe3);
            this.groupBox3.Controls.Add(this.btnListarFacturasBajas);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(9, 435);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(363, 54);
            this.groupBox3.TabIndex = 57;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Consultar";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(127, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 54;
            this.label5.Text = "Hasta:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 13);
            this.label6.TabIndex = 53;
            this.label6.Text = "De:";
            // 
            // dpHasta3
            // 
            this.dpHasta3.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpHasta3.Location = new System.Drawing.Point(171, 23);
            this.dpHasta3.Name = "dpHasta3";
            this.dpHasta3.Size = new System.Drawing.Size(89, 20);
            this.dpHasta3.TabIndex = 52;
            // 
            // dpDe3
            // 
            this.dpDe3.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpDe3.Location = new System.Drawing.Point(32, 22);
            this.dpDe3.Name = "dpDe3";
            this.dpDe3.Size = new System.Drawing.Size(89, 20);
            this.dpDe3.TabIndex = 51;
            // 
            // btnListarFacturasBajas
            // 
            this.btnListarFacturasBajas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnListarFacturasBajas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListarFacturasBajas.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnListarFacturasBajas.Location = new System.Drawing.Point(278, 12);
            this.btnListarFacturasBajas.Name = "btnListarFacturasBajas";
            this.btnListarFacturasBajas.Size = new System.Drawing.Size(74, 36);
            this.btnListarFacturasBajas.TabIndex = 50;
            this.btnListarFacturasBajas.Text = "Listar";
            this.btnListarFacturasBajas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnListarFacturasBajas.UseVisualStyleBackColor = true;
            this.btnListarFacturasBajas.Click += new System.EventHandler(this.btnListarFacturasBajas_Click);
            // 
            // btnSalir3
            // 
            this.btnSalir3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir3.Location = new System.Drawing.Point(596, 446);
            this.btnSalir3.Name = "btnSalir3";
            this.btnSalir3.Size = new System.Drawing.Size(71, 36);
            this.btnSalir3.TabIndex = 56;
            this.btnSalir3.Text = "   Salir";
            this.btnSalir3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir3.UseVisualStyleBackColor = true;
            this.btnSalir3.Click += new System.EventHandler(this.btnSalir3_Click);
            // 
            // btnConsultarFacturasBajas
            // 
            this.btnConsultarFacturasBajas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConsultarFacturasBajas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsultarFacturasBajas.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConsultarFacturasBajas.Location = new System.Drawing.Point(674, 446);
            this.btnConsultarFacturasBajas.Name = "btnConsultarFacturasBajas";
            this.btnConsultarFacturasBajas.Size = new System.Drawing.Size(132, 36);
            this.btnConsultarFacturasBajas.TabIndex = 55;
            this.btnConsultarFacturasBajas.Text = "   Consultar Sunat";
            this.btnConsultarFacturasBajas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConsultarFacturasBajas.UseVisualStyleBackColor = true;
            this.btnConsultarFacturasBajas.Click += new System.EventHandler(this.btnConsultarFacturasBajas_Click);
            // 
            // dgvFacturasBaja
            // 
            this.dgvFacturasBaja.AllowUserToAddRows = false;
            this.dgvFacturasBaja.AllowUserToDeleteRows = false;
            this.dgvFacturasBaja.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFacturasBaja.BackgroundColor = System.Drawing.Color.White;
            this.dgvFacturasBaja.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewLinkColumn3,
            this.dataGridViewLinkColumn4,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10});
            this.dgvFacturasBaja.Location = new System.Drawing.Point(5, 6);
            this.dgvFacturasBaja.Name = "dgvFacturasBaja";
            this.dgvFacturasBaja.ReadOnly = true;
            this.dgvFacturasBaja.RowHeadersWidth = 25;
            this.dgvFacturasBaja.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dgvFacturasBaja.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.dgvFacturasBaja.RowTemplate.Height = 24;
            this.dgvFacturasBaja.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFacturasBaja.Size = new System.Drawing.Size(803, 423);
            this.dgvFacturasBaja.TabIndex = 54;
            this.dgvFacturasBaja.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFacturasBaja_CellContentClick);
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Nro. Ticket";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 120;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Fecha Envio";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "Estado";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 320;
            // 
            // dataGridViewLinkColumn3
            // 
            this.dataGridViewLinkColumn3.HeaderText = "Detalle";
            this.dataGridViewLinkColumn3.Name = "dataGridViewLinkColumn3";
            this.dataGridViewLinkColumn3.ReadOnly = true;
            this.dataGridViewLinkColumn3.Width = 80;
            // 
            // dataGridViewLinkColumn4
            // 
            this.dataGridViewLinkColumn4.HeaderText = "Descargar archivos";
            this.dataGridViewLinkColumn4.Name = "dataGridViewLinkColumn4";
            this.dataGridViewLinkColumn4.ReadOnly = true;
            this.dataGridViewLinkColumn4.Width = 150;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "xml";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn9.Visible = false;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "cdr";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn10.Visible = false;
            // 
            // FrmConsultarTicketSunat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 521);
            this.Controls.Add(this.TabControl1);
            this.Name = "FrmConsultarTicketSunat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta de Documentos - Ticket";
            this.TabControl1.ResumeLayout(false);
            this.TabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResumenBoletas)).EndInit();
            this.TabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBoletaBajas)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturasBaja)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TabControl TabControl1;
        internal System.Windows.Forms.TabPage TabPage1;
        internal System.Windows.Forms.Button btnSalir;
        internal System.Windows.Forms.Button btnEnviarSunat;
        internal System.Windows.Forms.DataGridView dgvResumenBoletas;
        internal System.Windows.Forms.TabPage TabPage2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewLinkColumn Column2;
        private System.Windows.Forms.DataGridViewLinkColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dpHasta;
        private System.Windows.Forms.DateTimePicker dpDe;
        internal System.Windows.Forms.Button btnListar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dpHastaBajasBoleta;
        private System.Windows.Forms.DateTimePicker dpDeBajasBoleta;
        internal System.Windows.Forms.Button btnListarBoletasBajas;
        internal System.Windows.Forms.Button btnSalir2;
        internal System.Windows.Forms.Button btnConsultarSunatBoletaBajas;
        internal System.Windows.Forms.DataGridView dgvBoletaBajas;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewLinkColumn dataGridViewLinkColumn1;
        private System.Windows.Forms.DataGridViewLinkColumn dataGridViewLinkColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dpHasta3;
        private System.Windows.Forms.DateTimePicker dpDe3;
        internal System.Windows.Forms.Button btnListarFacturasBajas;
        internal System.Windows.Forms.Button btnSalir3;
        internal System.Windows.Forms.Button btnConsultarFacturasBajas;
        internal System.Windows.Forms.DataGridView dgvFacturasBaja;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewLinkColumn dataGridViewLinkColumn3;
        private System.Windows.Forms.DataGridViewLinkColumn dataGridViewLinkColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
    }
}