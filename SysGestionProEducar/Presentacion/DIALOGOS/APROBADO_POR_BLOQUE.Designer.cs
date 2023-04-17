namespace Presentacion.DIALOGOS
{
    partial class APROBADO_POR_BLOQUE
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(APROBADO_POR_BLOQUE));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chk_preAprob = new System.Windows.Forms.CheckBox();
            this.cbo_movimiento = new System.Windows.Forms.ComboBox();
            this.Label35 = new System.Windows.Forms.Label();
            this.chk_Todos = new System.Windows.Forms.CheckBox();
            this.btn_ver = new System.Windows.Forms.Button();
            this.txt_nrep1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CBO_PERSONAL1 = new System.Windows.Forms.ComboBox();
            this.DTP_DOC = new System.Windows.Forms.DateTimePicker();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.dgw_x_aprobar = new System.Windows.Forms.DataGridView();
            this.Contrato = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COD_SUCURSAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COD_CLASE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COD_PER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CLIENTE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FE_AÑO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FE_MES = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TOTAL_CONTRATO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FEC_PRIMER_VENC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IMP_CUOTA_INICIAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FEC_CUO_MEN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IMP_CUOTA_MES = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STATUS_PRE_APROB = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.X = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbl_mensaje_aprobado = new System.Windows.Forms.Label();
            this.lbl_nro_contrato = new System.Windows.Forms.Label();
            this.btn_aceptar = new System.Windows.Forms.Button();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.lbl_cantidad_registros = new System.Windows.Forms.Label();
            this.lbl_suma_registros = new System.Windows.Forms.Label();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw_x_aprobar)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.label3);
            this.GroupBox1.Controls.Add(this.chk_preAprob);
            this.GroupBox1.Controls.Add(this.cbo_movimiento);
            this.GroupBox1.Controls.Add(this.Label35);
            this.GroupBox1.Controls.Add(this.chk_Todos);
            this.GroupBox1.Controls.Add(this.btn_ver);
            this.GroupBox1.Controls.Add(this.txt_nrep1);
            this.GroupBox1.Controls.Add(this.label2);
            this.GroupBox1.Controls.Add(this.CBO_PERSONAL1);
            this.GroupBox1.Controls.Add(this.DTP_DOC);
            this.GroupBox1.Controls.Add(this.Label5);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Location = new System.Drawing.Point(25, 2);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(865, 95);
            this.GroupBox1.TabIndex = 12;
            this.GroupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(509, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 14);
            this.label3.TabIndex = 36;
            this.label3.Text = "Pre-Apr : Pre-Aprobado";
            // 
            // chk_preAprob
            // 
            this.chk_preAprob.AutoSize = true;
            this.chk_preAprob.Location = new System.Drawing.Point(743, 16);
            this.chk_preAprob.Name = "chk_preAprob";
            this.chk_preAprob.Size = new System.Drawing.Size(82, 17);
            this.chk_preAprob.TabIndex = 35;
            this.chk_preAprob.Text = "Pre-Aprobar";
            this.chk_preAprob.UseVisualStyleBackColor = true;
            this.chk_preAprob.Visible = false;
            // 
            // cbo_movimiento
            // 
            this.cbo_movimiento.BackColor = System.Drawing.Color.White;
            this.cbo_movimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_movimiento.FormattingEnabled = true;
            this.cbo_movimiento.Location = new System.Drawing.Point(417, 40);
            this.cbo_movimiento.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cbo_movimiento.Name = "cbo_movimiento";
            this.cbo_movimiento.Size = new System.Drawing.Size(270, 21);
            this.cbo_movimiento.TabIndex = 6;
            // 
            // Label35
            // 
            this.Label35.AutoSize = true;
            this.Label35.Location = new System.Drawing.Point(353, 44);
            this.Label35.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label35.Name = "Label35";
            this.Label35.Size = new System.Drawing.Size(61, 13);
            this.Label35.TabIndex = 34;
            this.Label35.Text = "Movimiento";
            // 
            // chk_Todos
            // 
            this.chk_Todos.AutoSize = true;
            this.chk_Todos.Location = new System.Drawing.Point(639, 69);
            this.chk_Todos.Name = "chk_Todos";
            this.chk_Todos.Size = new System.Drawing.Size(56, 17);
            this.chk_Todos.TabIndex = 14;
            this.chk_Todos.Text = "Todos";
            this.chk_Todos.UseVisualStyleBackColor = true;
            this.chk_Todos.CheckedChanged += new System.EventHandler(this.chk_Todos_CheckedChanged);
            // 
            // btn_ver
            // 
            this.btn_ver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ver.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ver.Image = ((System.Drawing.Image)(resources.GetObject("btn_ver.Image")));
            this.btn_ver.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_ver.Location = new System.Drawing.Point(356, 60);
            this.btn_ver.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_ver.Name = "btn_ver";
            this.btn_ver.Size = new System.Drawing.Size(59, 26);
            this.btn_ver.TabIndex = 10;
            this.btn_ver.Text = "&Ver";
            this.btn_ver.UseVisualStyleBackColor = true;
            this.btn_ver.Click += new System.EventHandler(this.btn_ver_Click);
            // 
            // txt_nrep1
            // 
            this.txt_nrep1.Location = new System.Drawing.Point(237, 65);
            this.txt_nrep1.Name = "txt_nrep1";
            this.txt_nrep1.Size = new System.Drawing.Size(83, 20);
            this.txt_nrep1.TabIndex = 8;
            this.txt_nrep1.Leave += new System.EventHandler(this.txt_nrep1_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(171, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 14);
            this.label2.TabIndex = 29;
            this.label2.Text = "N° Reporte";
            // 
            // CBO_PERSONAL1
            // 
            this.CBO_PERSONAL1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBO_PERSONAL1.FormattingEnabled = true;
            this.CBO_PERSONAL1.Location = new System.Drawing.Point(237, 14);
            this.CBO_PERSONAL1.Name = "CBO_PERSONAL1";
            this.CBO_PERSONAL1.Size = new System.Drawing.Size(450, 21);
            this.CBO_PERSONAL1.TabIndex = 1;
            // 
            // DTP_DOC
            // 
            this.DTP_DOC.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DTP_DOC.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTP_DOC.Location = new System.Drawing.Point(237, 40);
            this.DTP_DOC.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.DTP_DOC.Name = "DTP_DOC";
            this.DTP_DOC.Size = new System.Drawing.Size(83, 20);
            this.DTP_DOC.TabIndex = 4;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.Location = new System.Drawing.Point(139, 43);
            this.Label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(95, 14);
            this.Label5.TabIndex = 27;
            this.Label5.Text = "Fecha Aprobacion";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(140, 14);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(74, 14);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Aprobado por";
            // 
            // dgw_x_aprobar
            // 
            this.dgw_x_aprobar.AllowUserToAddRows = false;
            this.dgw_x_aprobar.AllowUserToDeleteRows = false;
            this.dgw_x_aprobar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgw_x_aprobar.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgw_x_aprobar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgw_x_aprobar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Contrato,
            this.COD_SUCURSAL,
            this.COD_CLASE,
            this.COD_PER,
            this.CLIENTE,
            this.FE_AÑO,
            this.FE_MES,
            this.Fecha,
            this.TOTAL_CONTRATO,
            this.FEC_PRIMER_VENC,
            this.IMP_CUOTA_INICIAL,
            this.FEC_CUO_MEN,
            this.IMP_CUOTA_MES,
            this.STATUS_PRE_APROB,
            this.X});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 8.25F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgw_x_aprobar.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgw_x_aprobar.Location = new System.Drawing.Point(23, 118);
            this.dgw_x_aprobar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dgw_x_aprobar.MultiSelect = false;
            this.dgw_x_aprobar.Name = "dgw_x_aprobar";
            this.dgw_x_aprobar.RowHeadersWidth = 25;
            this.dgw_x_aprobar.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dgw_x_aprobar.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.dgw_x_aprobar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgw_x_aprobar.Size = new System.Drawing.Size(867, 406);
            this.dgw_x_aprobar.TabIndex = 137;
            this.dgw_x_aprobar.TabStop = false;
            // 
            // Contrato
            // 
            this.Contrato.HeaderText = "Contrato";
            this.Contrato.Name = "Contrato";
            this.Contrato.ReadOnly = true;
            this.Contrato.Width = 70;
            // 
            // COD_SUCURSAL
            // 
            this.COD_SUCURSAL.HeaderText = "COD_SUCURSAL";
            this.COD_SUCURSAL.Name = "COD_SUCURSAL";
            this.COD_SUCURSAL.Visible = false;
            // 
            // COD_CLASE
            // 
            this.COD_CLASE.HeaderText = "COD_CLASE";
            this.COD_CLASE.Name = "COD_CLASE";
            this.COD_CLASE.Visible = false;
            // 
            // COD_PER
            // 
            this.COD_PER.HeaderText = "COD_PER";
            this.COD_PER.Name = "COD_PER";
            this.COD_PER.Visible = false;
            // 
            // CLIENTE
            // 
            this.CLIENTE.HeaderText = "Cliente";
            this.CLIENTE.Name = "CLIENTE";
            this.CLIENTE.ReadOnly = true;
            this.CLIENTE.Width = 240;
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
            // Fecha
            // 
            this.Fecha.HeaderText = "Fe Contrato";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            this.Fecha.Width = 70;
            // 
            // TOTAL_CONTRATO
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.TOTAL_CONTRATO.DefaultCellStyle = dataGridViewCellStyle2;
            this.TOTAL_CONTRATO.HeaderText = "Imp Total";
            this.TOTAL_CONTRATO.Name = "TOTAL_CONTRATO";
            this.TOTAL_CONTRATO.ReadOnly = true;
            this.TOTAL_CONTRATO.Width = 60;
            // 
            // FEC_PRIMER_VENC
            // 
            this.FEC_PRIMER_VENC.HeaderText = "Fec 1er Ven";
            this.FEC_PRIMER_VENC.Name = "FEC_PRIMER_VENC";
            this.FEC_PRIMER_VENC.ReadOnly = true;
            this.FEC_PRIMER_VENC.Width = 75;
            // 
            // IMP_CUOTA_INICIAL
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.IMP_CUOTA_INICIAL.DefaultCellStyle = dataGridViewCellStyle3;
            this.IMP_CUOTA_INICIAL.HeaderText = "Imp 1er Ven";
            this.IMP_CUOTA_INICIAL.Name = "IMP_CUOTA_INICIAL";
            this.IMP_CUOTA_INICIAL.ReadOnly = true;
            this.IMP_CUOTA_INICIAL.Width = 75;
            // 
            // FEC_CUO_MEN
            // 
            this.FEC_CUO_MEN.HeaderText = "Fec 2do Ven";
            this.FEC_CUO_MEN.Name = "FEC_CUO_MEN";
            this.FEC_CUO_MEN.ReadOnly = true;
            this.FEC_CUO_MEN.Width = 75;
            // 
            // IMP_CUOTA_MES
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.IMP_CUOTA_MES.DefaultCellStyle = dataGridViewCellStyle4;
            this.IMP_CUOTA_MES.HeaderText = "Imp 2do Ven";
            this.IMP_CUOTA_MES.Name = "IMP_CUOTA_MES";
            this.IMP_CUOTA_MES.ReadOnly = true;
            this.IMP_CUOTA_MES.Width = 75;
            // 
            // STATUS_PRE_APROB
            // 
            this.STATUS_PRE_APROB.HeaderText = "Pre-Apr";
            this.STATUS_PRE_APROB.Name = "STATUS_PRE_APROB";
            this.STATUS_PRE_APROB.Width = 50;
            // 
            // X
            // 
            this.X.HeaderText = "X";
            this.X.Name = "X";
            this.X.Width = 25;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbl_mensaje_aprobado);
            this.groupBox2.Controls.Add(this.lbl_nro_contrato);
            this.groupBox2.Controls.Add(this.btn_aceptar);
            this.groupBox2.Controls.Add(this.btn_cancelar);
            this.groupBox2.Location = new System.Drawing.Point(25, 525);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(865, 55);
            this.groupBox2.TabIndex = 138;
            this.groupBox2.TabStop = false;
            // 
            // lbl_mensaje_aprobado
            // 
            this.lbl_mensaje_aprobado.AutoSize = true;
            this.lbl_mensaje_aprobado.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_mensaje_aprobado.Location = new System.Drawing.Point(740, 23);
            this.lbl_mensaje_aprobado.Name = "lbl_mensaje_aprobado";
            this.lbl_mensaje_aprobado.Size = new System.Drawing.Size(104, 14);
            this.lbl_mensaje_aprobado.TabIndex = 11;
            this.lbl_mensaje_aprobado.Text = "mensaje aprobacion";
            this.lbl_mensaje_aprobado.Visible = false;
            // 
            // lbl_nro_contrato
            // 
            this.lbl_nro_contrato.AutoSize = true;
            this.lbl_nro_contrato.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_nro_contrato.Location = new System.Drawing.Point(682, 23);
            this.lbl_nro_contrato.Name = "lbl_nro_contrato";
            this.lbl_nro_contrato.Size = new System.Drawing.Size(47, 14);
            this.lbl_nro_contrato.TabIndex = 10;
            this.lbl_nro_contrato.Text = "contrato";
            this.lbl_nro_contrato.Visible = false;
            // 
            // btn_aceptar
            // 
            this.btn_aceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_aceptar.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_aceptar.Image = ((System.Drawing.Image)(resources.GetObject("btn_aceptar.Image")));
            this.btn_aceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_aceptar.Location = new System.Drawing.Point(261, 16);
            this.btn_aceptar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_aceptar.Name = "btn_aceptar";
            this.btn_aceptar.Size = new System.Drawing.Size(77, 29);
            this.btn_aceptar.TabIndex = 8;
            this.btn_aceptar.Text = "&Aprobar";
            this.btn_aceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_aceptar.UseVisualStyleBackColor = true;
            this.btn_aceptar.Click += new System.EventHandler(this.btn_aceptar_Click);
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancelar.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancelar.Image = ((System.Drawing.Image)(resources.GetObject("btn_cancelar.Image")));
            this.btn_cancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_cancelar.Location = new System.Drawing.Point(454, 16);
            this.btn_cancelar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(77, 29);
            this.btn_cancelar.TabIndex = 9;
            this.btn_cancelar.Text = "&Cancelar";
            this.btn_cancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_cancelar.UseVisualStyleBackColor = true;
            // 
            // lbl_cantidad_registros
            // 
            this.lbl_cantidad_registros.AutoSize = true;
            this.lbl_cantidad_registros.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_cantidad_registros.Location = new System.Drawing.Point(776, 100);
            this.lbl_cantidad_registros.Name = "lbl_cantidad_registros";
            this.lbl_cantidad_registros.Size = new System.Drawing.Size(97, 14);
            this.lbl_cantidad_registros.TabIndex = 139;
            this.lbl_cantidad_registros.Text = "Nro de Registros 0";
            // 
            // lbl_suma_registros
            // 
            this.lbl_suma_registros.AutoSize = true;
            this.lbl_suma_registros.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_suma_registros.Location = new System.Drawing.Point(24, 100);
            this.lbl_suma_registros.Name = "lbl_suma_registros";
            this.lbl_suma_registros.Size = new System.Drawing.Size(103, 14);
            this.lbl_suma_registros.TabIndex = 140;
            this.lbl_suma_registros.Text = "Suma Imp Total S/. 0";
            // 
            // APROBADO_POR_BLOQUE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 588);
            this.Controls.Add(this.lbl_suma_registros);
            this.Controls.Add(this.lbl_cantidad_registros);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dgw_x_aprobar);
            this.Controls.Add(this.GroupBox1);
            this.Name = "APROBADO_POR_BLOQUE";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Load += new System.EventHandler(this.APROBADO_POR_BLOQUE_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.APROBADO_POR_BLOQUE_KeyDown);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw_x_aprobar)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.ComboBox CBO_PERSONAL1;
        internal System.Windows.Forms.DateTimePicker DTP_DOC;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.DataGridView dgw_x_aprobar;
        internal System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.Button btn_aceptar;
        internal System.Windows.Forms.Button btn_cancelar;
        internal System.Windows.Forms.Button btn_ver;
        private System.Windows.Forms.TextBox txt_nrep1;
        internal System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chk_Todos;
        internal System.Windows.Forms.ComboBox cbo_movimiento;
        internal System.Windows.Forms.Label Label35;
        private System.Windows.Forms.CheckBox chk_preAprob;
        internal System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Contrato;
        private System.Windows.Forms.DataGridViewTextBoxColumn COD_SUCURSAL;
        private System.Windows.Forms.DataGridViewTextBoxColumn COD_CLASE;
        private System.Windows.Forms.DataGridViewTextBoxColumn COD_PER;
        private System.Windows.Forms.DataGridViewTextBoxColumn CLIENTE;
        private System.Windows.Forms.DataGridViewTextBoxColumn FE_AÑO;
        private System.Windows.Forms.DataGridViewTextBoxColumn FE_MES;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn TOTAL_CONTRATO;
        private System.Windows.Forms.DataGridViewTextBoxColumn FEC_PRIMER_VENC;
        private System.Windows.Forms.DataGridViewTextBoxColumn IMP_CUOTA_INICIAL;
        private System.Windows.Forms.DataGridViewTextBoxColumn FEC_CUO_MEN;
        private System.Windows.Forms.DataGridViewTextBoxColumn IMP_CUOTA_MES;
        private System.Windows.Forms.DataGridViewCheckBoxColumn STATUS_PRE_APROB;
        private System.Windows.Forms.DataGridViewCheckBoxColumn X;
        internal System.Windows.Forms.Label lbl_nro_contrato;
        internal System.Windows.Forms.Label lbl_cantidad_registros;
        internal System.Windows.Forms.Label lbl_suma_registros;
        internal System.Windows.Forms.Label lbl_mensaje_aprobado;
    }
}