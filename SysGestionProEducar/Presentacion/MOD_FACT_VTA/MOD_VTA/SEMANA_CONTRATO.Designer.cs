namespace Presentacion.MOD_VTA
{
    partial class SEMANA_CONTRATO
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SEMANA_CONTRATO));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.btn_salir = new System.Windows.Forms.Button();
            this.btn_eliminar = new System.Windows.Forms.Button();
            this.btn_modificar = new System.Windows.Forms.Button();
            this.btn_nuevo = new System.Windows.Forms.Button();
            this.dgw1 = new System.Windows.Forms.DataGridView();
            this.cod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.femes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.feannio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nrosem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomsem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fedel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.feal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sem_con = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nro_repo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.btn_modificar2 = new System.Windows.Forms.Button();
            this.btn_guardar = new System.Windows.Forms.Button();
            this.grvDatos = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_nro_repo = new System.Windows.Forms.TextBox();
            this.lblsemana = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtp_al = new System.Windows.Forms.DateTimePicker();
            this.cbo_semana = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Label42 = new System.Windows.Forms.Label();
            this.dtp_del = new System.Windows.Forms.DateTimePicker();
            this.cboannio = new System.Windows.Forms.ComboBox();
            this.cbomes = new System.Windows.Forms.ComboBox();
            this.label32 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.TabControl1.SuspendLayout();
            this.TabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw1)).BeginInit();
            this.TabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grvDatos.SuspendLayout();
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
            this.TabControl1.Size = new System.Drawing.Size(567, 288);
            this.TabControl1.TabIndex = 4;
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
            this.TabPage1.Size = new System.Drawing.Size(559, 261);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "Lista";
            this.TabPage1.UseVisualStyleBackColor = true;
            // 
            // btn_salir
            // 
            this.btn_salir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_salir.Image = ((System.Drawing.Image)(resources.GetObject("btn_salir.Image")));
            this.btn_salir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_salir.Location = new System.Drawing.Point(464, 147);
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
            this.btn_eliminar.Location = new System.Drawing.Point(464, 106);
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
            this.btn_modificar.Location = new System.Drawing.Point(464, 65);
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
            this.btn_nuevo.Location = new System.Drawing.Point(464, 24);
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
            this.femes,
            this.feannio,
            this.nrosem,
            this.nomsem,
            this.fedel,
            this.feal,
            this.sem_con,
            this.nro_repo});
            this.dgw1.Location = new System.Drawing.Point(5, 24);
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
            this.dgw1.Size = new System.Drawing.Size(453, 200);
            this.dgw1.TabIndex = 0;
            // 
            // cod
            // 
            this.cod.FillWeight = 51.27419F;
            this.cod.HeaderText = "Mes";
            this.cod.MinimumWidth = 100;
            this.cod.Name = "cod";
            this.cod.ReadOnly = true;
            // 
            // femes
            // 
            this.femes.HeaderText = "femes";
            this.femes.Name = "femes";
            this.femes.ReadOnly = true;
            this.femes.Visible = false;
            // 
            // feannio
            // 
            this.feannio.FillWeight = 149.2386F;
            this.feannio.HeaderText = "feannio";
            this.feannio.Name = "feannio";
            this.feannio.ReadOnly = true;
            this.feannio.Visible = false;
            // 
            // nrosem
            // 
            this.nrosem.HeaderText = "nrosem";
            this.nrosem.Name = "nrosem";
            this.nrosem.ReadOnly = true;
            this.nrosem.Visible = false;
            // 
            // nomsem
            // 
            this.nomsem.FillWeight = 99.48723F;
            this.nomsem.HeaderText = "Semana Del Al";
            this.nomsem.MinimumWidth = 180;
            this.nomsem.Name = "nomsem";
            this.nomsem.ReadOnly = true;
            this.nomsem.Width = 180;
            // 
            // fedel
            // 
            this.fedel.HeaderText = "fedel";
            this.fedel.Name = "fedel";
            this.fedel.ReadOnly = true;
            this.fedel.Visible = false;
            // 
            // feal
            // 
            this.feal.HeaderText = "feal";
            this.feal.Name = "feal";
            this.feal.ReadOnly = true;
            this.feal.Visible = false;
            // 
            // sem_con
            // 
            this.sem_con.HeaderText = "Semana";
            this.sem_con.Name = "sem_con";
            this.sem_con.ReadOnly = true;
            this.sem_con.Width = 120;
            // 
            // nro_repo
            // 
            this.nro_repo.HeaderText = "Rep";
            this.nro_repo.Name = "nro_repo";
            this.nro_repo.ReadOnly = true;
            this.nro_repo.Visible = false;
            this.nro_repo.Width = 40;
            // 
            // TabPage2
            // 
            this.TabPage2.Controls.Add(this.groupBox1);
            this.TabPage2.Controls.Add(this.grvDatos);
            this.TabPage2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabPage2.Location = new System.Drawing.Point(4, 23);
            this.TabPage2.Name = "TabPage2";
            this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage2.Size = new System.Drawing.Size(559, 261);
            this.TabPage2.TabIndex = 1;
            this.TabPage2.Text = "Detalles";
            this.TabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_cancelar);
            this.groupBox1.Controls.Add(this.btn_modificar2);
            this.groupBox1.Controls.Add(this.btn_guardar);
            this.groupBox1.Location = new System.Drawing.Point(59, 179);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(423, 48);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancelar.Image = ((System.Drawing.Image)(resources.GetObject("btn_cancelar.Image")));
            this.btn_cancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_cancelar.Location = new System.Drawing.Point(206, 11);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(77, 27);
            this.btn_cancelar.TabIndex = 11;
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
            this.btn_modificar2.Location = new System.Drawing.Point(125, 11);
            this.btn_modificar2.Name = "btn_modificar2";
            this.btn_modificar2.Size = new System.Drawing.Size(77, 27);
            this.btn_modificar2.TabIndex = 3;
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
            this.btn_guardar.Location = new System.Drawing.Point(125, 11);
            this.btn_guardar.Name = "btn_guardar";
            this.btn_guardar.Size = new System.Drawing.Size(77, 27);
            this.btn_guardar.TabIndex = 10;
            this.btn_guardar.Text = "&Guardar";
            this.btn_guardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_guardar.UseVisualStyleBackColor = true;
            this.btn_guardar.Click += new System.EventHandler(this.btn_guardar_Click);
            // 
            // grvDatos
            // 
            this.grvDatos.Controls.Add(this.label4);
            this.grvDatos.Controls.Add(this.txt_nro_repo);
            this.grvDatos.Controls.Add(this.lblsemana);
            this.grvDatos.Controls.Add(this.label3);
            this.grvDatos.Controls.Add(this.label2);
            this.grvDatos.Controls.Add(this.dtp_al);
            this.grvDatos.Controls.Add(this.cbo_semana);
            this.grvDatos.Controls.Add(this.label1);
            this.grvDatos.Controls.Add(this.Label42);
            this.grvDatos.Controls.Add(this.dtp_del);
            this.grvDatos.Controls.Add(this.cboannio);
            this.grvDatos.Controls.Add(this.cbomes);
            this.grvDatos.Controls.Add(this.label32);
            this.grvDatos.Controls.Add(this.label31);
            this.grvDatos.Location = new System.Drawing.Point(59, 33);
            this.grvDatos.Name = "grvDatos";
            this.grvDatos.Size = new System.Drawing.Size(423, 144);
            this.grvDatos.TabIndex = 1;
            this.grvDatos.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(261, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 14);
            this.label4.TabIndex = 39;
            this.label4.Text = "Nº Reporte";
            this.label4.Visible = false;
            // 
            // txt_nro_repo
            // 
            this.txt_nro_repo.BackColor = System.Drawing.Color.White;
            this.txt_nro_repo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_nro_repo.Location = new System.Drawing.Point(335, 41);
            this.txt_nro_repo.Name = "txt_nro_repo";
            this.txt_nro_repo.Size = new System.Drawing.Size(57, 20);
            this.txt_nro_repo.TabIndex = 7;
            this.txt_nro_repo.Visible = false;
            // 
            // lblsemana
            // 
            this.lblsemana.AutoSize = true;
            this.lblsemana.Location = new System.Drawing.Point(106, 107);
            this.lblsemana.Name = "lblsemana";
            this.lblsemana.Size = new System.Drawing.Size(46, 14);
            this.lblsemana.TabIndex = 36;
            this.lblsemana.Text = "Semana";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 14);
            this.label3.TabIndex = 35;
            this.label3.Text = "Semana";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(243, 75);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 14);
            this.label2.TabIndex = 34;
            this.label2.Text = "Fecha Al";
            // 
            // dtp_al
            // 
            this.dtp_al.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_al.Location = new System.Drawing.Point(315, 70);
            this.dtp_al.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dtp_al.Name = "dtp_al";
            this.dtp_al.Size = new System.Drawing.Size(77, 20);
            this.dtp_al.TabIndex = 9;
            this.dtp_al.ValueChanged += new System.EventHandler(this.dtp_al_ValueChanged);
            // 
            // cbo_semana
            // 
            this.cbo_semana.BackColor = System.Drawing.Color.White;
            this.cbo_semana.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_semana.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_semana.FormattingEnabled = true;
            this.cbo_semana.Location = new System.Drawing.Point(90, 42);
            this.cbo_semana.Name = "cbo_semana";
            this.cbo_semana.Size = new System.Drawing.Size(121, 22);
            this.cbo_semana.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 14);
            this.label1.TabIndex = 32;
            this.label1.Text = "Semana";
            // 
            // Label42
            // 
            this.Label42.AutoSize = true;
            this.Label42.Location = new System.Drawing.Point(18, 75);
            this.Label42.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label42.Name = "Label42";
            this.Label42.Size = new System.Drawing.Size(55, 14);
            this.Label42.TabIndex = 30;
            this.Label42.Text = "Fecha Del";
            // 
            // dtp_del
            // 
            this.dtp_del.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_del.Location = new System.Drawing.Point(91, 72);
            this.dtp_del.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dtp_del.Name = "dtp_del";
            this.dtp_del.Size = new System.Drawing.Size(77, 20);
            this.dtp_del.TabIndex = 8;
            // 
            // cboannio
            // 
            this.cboannio.BackColor = System.Drawing.Color.White;
            this.cboannio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboannio.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboannio.FormattingEnabled = true;
            this.cboannio.Location = new System.Drawing.Point(335, 15);
            this.cboannio.Name = "cboannio";
            this.cboannio.Size = new System.Drawing.Size(57, 22);
            this.cboannio.TabIndex = 5;
            this.cboannio.SelectedIndexChanged += new System.EventHandler(this.cboannio_SelectedIndexChanged);
            // 
            // cbomes
            // 
            this.cbomes.BackColor = System.Drawing.Color.White;
            this.cbomes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbomes.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbomes.FormattingEnabled = true;
            this.cbomes.Location = new System.Drawing.Point(90, 13);
            this.cbomes.Name = "cbomes";
            this.cbomes.Size = new System.Drawing.Size(121, 22);
            this.cbomes.TabIndex = 4;
            this.cbomes.SelectedIndexChanged += new System.EventHandler(this.cbomes_SelectedIndexChanged);
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(291, 20);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(27, 14);
            this.label32.TabIndex = 18;
            this.label32.Text = "Año";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(23, 18);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(27, 14);
            this.label31.TabIndex = 16;
            this.label31.Text = "Mes";
            // 
            // SEMANA_CONTRATO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 288);
            this.ControlBox = false;
            this.Controls.Add(this.TabControl1);
            this.Name = "SEMANA_CONTRATO";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SEMANA CONTRATO";
            this.Load += new System.EventHandler(this.SEMANA_CONTRATO_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SEMANA_CONTRATO_KeyDown);
            this.TabControl1.ResumeLayout(false);
            this.TabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgw1)).EndInit();
            this.TabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.grvDatos.ResumeLayout(false);
            this.grvDatos.PerformLayout();
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
        internal System.Windows.Forms.GroupBox grvDatos;
        internal System.Windows.Forms.ComboBox cboannio;
        internal System.Windows.Forms.ComboBox cbomes;
        internal System.Windows.Forms.Label label32;
        internal System.Windows.Forms.Label label31;
        internal System.Windows.Forms.Button btn_guardar;
        internal System.Windows.Forms.Button btn_modificar2;
        internal System.Windows.Forms.Button btn_cancelar;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.DateTimePicker dtp_al;
        internal System.Windows.Forms.ComboBox cbo_semana;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label Label42;
        internal System.Windows.Forms.DateTimePicker dtp_del;
        internal System.Windows.Forms.Label lblsemana;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.TextBox txt_nro_repo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cod;
        private System.Windows.Forms.DataGridViewTextBoxColumn femes;
        private System.Windows.Forms.DataGridViewTextBoxColumn feannio;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrosem;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomsem;
        private System.Windows.Forms.DataGridViewTextBoxColumn fedel;
        private System.Windows.Forms.DataGridViewTextBoxColumn feal;
        private System.Windows.Forms.DataGridViewTextBoxColumn sem_con;
        private System.Windows.Forms.DataGridViewTextBoxColumn nro_repo;

    }
}