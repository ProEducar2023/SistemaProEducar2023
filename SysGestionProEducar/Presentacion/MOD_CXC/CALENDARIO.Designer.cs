namespace Presentacion.MOD_CXC
{
    partial class CALENDARIO
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CALENDARIO));
            this.dgvCalendario = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_modificar = new System.Windows.Forms.Button();
            this.btn_salir = new System.Windows.Forms.Button();
            this.btn_nuevo = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_Grabar = new System.Windows.Forms.Button();
            this.numAño = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboMes = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbMes = new System.Windows.Forms.GroupBox();
            this.chkDia31 = new System.Windows.Forms.CheckBox();
            this.chkDia29 = new System.Windows.Forms.CheckBox();
            this.chkDia30 = new System.Windows.Forms.CheckBox();
            this.chkDia28 = new System.Windows.Forms.CheckBox();
            this.chkDia27 = new System.Windows.Forms.CheckBox();
            this.chkDia26 = new System.Windows.Forms.CheckBox();
            this.chkDia24 = new System.Windows.Forms.CheckBox();
            this.chkDia25 = new System.Windows.Forms.CheckBox();
            this.chkDia23 = new System.Windows.Forms.CheckBox();
            this.chkDia22 = new System.Windows.Forms.CheckBox();
            this.chkDia21 = new System.Windows.Forms.CheckBox();
            this.chkDia8 = new System.Windows.Forms.CheckBox();
            this.chkDia18 = new System.Windows.Forms.CheckBox();
            this.chkDia1 = new System.Windows.Forms.CheckBox();
            this.chkDia19 = new System.Windows.Forms.CheckBox();
            this.chkDia2 = new System.Windows.Forms.CheckBox();
            this.chkDia17 = new System.Windows.Forms.CheckBox();
            this.chkDia3 = new System.Windows.Forms.CheckBox();
            this.chkDia16 = new System.Windows.Forms.CheckBox();
            this.chkDia5 = new System.Windows.Forms.CheckBox();
            this.chkDia15 = new System.Windows.Forms.CheckBox();
            this.chkDia4 = new System.Windows.Forms.CheckBox();
            this.chkDia13 = new System.Windows.Forms.CheckBox();
            this.chkDia6 = new System.Windows.Forms.CheckBox();
            this.chkDia14 = new System.Windows.Forms.CheckBox();
            this.chkDia7 = new System.Windows.Forms.CheckBox();
            this.chkDia12 = new System.Windows.Forms.CheckBox();
            this.chkDia10 = new System.Windows.Forms.CheckBox();
            this.chkDia11 = new System.Windows.Forms.CheckBox();
            this.chkDia9 = new System.Windows.Forms.CheckBox();
            this.chkDia20 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalendario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAño)).BeginInit();
            this.gbMes.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvCalendario
            // 
            this.dgvCalendario.AllowUserToAddRows = false;
            this.dgvCalendario.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            this.dgvCalendario.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCalendario.BackgroundColor = System.Drawing.Color.White;
            this.dgvCalendario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCalendario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column1,
            this.Column3});
            this.dgvCalendario.Location = new System.Drawing.Point(9, 21);
            this.dgvCalendario.Margin = new System.Windows.Forms.Padding(2);
            this.dgvCalendario.MultiSelect = false;
            this.dgvCalendario.Name = "dgvCalendario";
            this.dgvCalendario.ReadOnly = true;
            this.dgvCalendario.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvCalendario.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dgvCalendario.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.dgvCalendario.RowTemplate.Height = 20;
            this.dgvCalendario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCalendario.Size = new System.Drawing.Size(239, 310);
            this.dgvCalendario.TabIndex = 15;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Mes";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Visible = false;
            this.Column2.Width = 70;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Mes";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 120;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.HeaderText = "Año";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // btn_modificar
            // 
            this.btn_modificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_modificar.Image = ((System.Drawing.Image)(resources.GetObject("btn_modificar.Image")));
            this.btn_modificar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_modificar.Location = new System.Drawing.Point(90, 336);
            this.btn_modificar.Name = "btn_modificar";
            this.btn_modificar.Size = new System.Drawing.Size(77, 27);
            this.btn_modificar.TabIndex = 17;
            this.btn_modificar.Text = "&Modificar";
            this.btn_modificar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_modificar.UseVisualStyleBackColor = true;
            // 
            // btn_salir
            // 
            this.btn_salir.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_salir.Image = ((System.Drawing.Image)(resources.GetObject("btn_salir.Image")));
            this.btn_salir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_salir.Location = new System.Drawing.Point(171, 336);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(77, 27);
            this.btn_salir.TabIndex = 18;
            this.btn_salir.Text = "&Salir";
            this.btn_salir.UseVisualStyleBackColor = true;
            // 
            // btn_nuevo
            // 
            this.btn_nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_nuevo.Image = ((System.Drawing.Image)(resources.GetObject("btn_nuevo.Image")));
            this.btn_nuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_nuevo.Location = new System.Drawing.Point(9, 336);
            this.btn_nuevo.Name = "btn_nuevo";
            this.btn_nuevo.Size = new System.Drawing.Size(77, 27);
            this.btn_nuevo.TabIndex = 16;
            this.btn_nuevo.Text = "&Nuevo";
            this.btn_nuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_nuevo.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(697, 300);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(77, 27);
            this.button1.TabIndex = 50;
            this.button1.Text = "&Salir";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btn_Grabar
            // 
            this.btn_Grabar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Grabar.Image = ((System.Drawing.Image)(resources.GetObject("btn_Grabar.Image")));
            this.btn_Grabar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Grabar.Location = new System.Drawing.Point(614, 300);
            this.btn_Grabar.Name = "btn_Grabar";
            this.btn_Grabar.Size = new System.Drawing.Size(77, 27);
            this.btn_Grabar.TabIndex = 49;
            this.btn_Grabar.Text = "&Grabar";
            this.btn_Grabar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Grabar.UseVisualStyleBackColor = true;
            // 
            // numAño
            // 
            this.numAño.Location = new System.Drawing.Point(514, 49);
            this.numAño.Margin = new System.Windows.Forms.Padding(2);
            this.numAño.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.numAño.Minimum = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            this.numAño.Name = "numAño";
            this.numAño.Size = new System.Drawing.Size(67, 20);
            this.numAño.TabIndex = 43;
            this.numAño.Value = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(483, 72);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 48;
            this.label3.Text = "Mes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(483, 51);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 47;
            this.label2.Text = "Año";
            // 
            // cboMes
            // 
            this.cboMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMes.FormattingEnabled = true;
            this.cboMes.Location = new System.Drawing.Point(514, 70);
            this.cboMes.Margin = new System.Windows.Forms.Padding(2);
            this.cboMes.Name = "cboMes";
            this.cboMes.Size = new System.Drawing.Size(102, 21);
            this.cboMes.TabIndex = 44;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label1.Location = new System.Drawing.Point(350, 109);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 13);
            this.label1.TabIndex = 46;
            this.label1.Text = "Seleccione los días feriados";
            // 
            // gbMes
            // 
            this.gbMes.Controls.Add(this.chkDia31);
            this.gbMes.Controls.Add(this.chkDia29);
            this.gbMes.Controls.Add(this.chkDia30);
            this.gbMes.Controls.Add(this.chkDia28);
            this.gbMes.Controls.Add(this.chkDia27);
            this.gbMes.Controls.Add(this.chkDia26);
            this.gbMes.Controls.Add(this.chkDia24);
            this.gbMes.Controls.Add(this.chkDia25);
            this.gbMes.Controls.Add(this.chkDia23);
            this.gbMes.Controls.Add(this.chkDia22);
            this.gbMes.Controls.Add(this.chkDia21);
            this.gbMes.Controls.Add(this.chkDia8);
            this.gbMes.Controls.Add(this.chkDia18);
            this.gbMes.Controls.Add(this.chkDia1);
            this.gbMes.Controls.Add(this.chkDia19);
            this.gbMes.Controls.Add(this.chkDia2);
            this.gbMes.Controls.Add(this.chkDia17);
            this.gbMes.Controls.Add(this.chkDia3);
            this.gbMes.Controls.Add(this.chkDia16);
            this.gbMes.Controls.Add(this.chkDia5);
            this.gbMes.Controls.Add(this.chkDia15);
            this.gbMes.Controls.Add(this.chkDia4);
            this.gbMes.Controls.Add(this.chkDia13);
            this.gbMes.Controls.Add(this.chkDia6);
            this.gbMes.Controls.Add(this.chkDia14);
            this.gbMes.Controls.Add(this.chkDia7);
            this.gbMes.Controls.Add(this.chkDia12);
            this.gbMes.Controls.Add(this.chkDia10);
            this.gbMes.Controls.Add(this.chkDia11);
            this.gbMes.Controls.Add(this.chkDia9);
            this.gbMes.Controls.Add(this.chkDia20);
            this.gbMes.Location = new System.Drawing.Point(352, 131);
            this.gbMes.Margin = new System.Windows.Forms.Padding(2);
            this.gbMes.Name = "gbMes";
            this.gbMes.Padding = new System.Windows.Forms.Padding(2);
            this.gbMes.Size = new System.Drawing.Size(423, 143);
            this.gbMes.TabIndex = 45;
            this.gbMes.TabStop = false;
            // 
            // chkDia31
            // 
            this.chkDia31.AutoSize = true;
            this.chkDia31.Location = new System.Drawing.Point(24, 113);
            this.chkDia31.Margin = new System.Windows.Forms.Padding(2);
            this.chkDia31.Name = "chkDia31";
            this.chkDia31.Size = new System.Drawing.Size(38, 17);
            this.chkDia31.TabIndex = 74;
            this.chkDia31.Text = "31";
            this.chkDia31.UseVisualStyleBackColor = true;
            // 
            // chkDia29
            // 
            this.chkDia29.AutoSize = true;
            this.chkDia29.Location = new System.Drawing.Point(330, 81);
            this.chkDia29.Margin = new System.Windows.Forms.Padding(2);
            this.chkDia29.Name = "chkDia29";
            this.chkDia29.Size = new System.Drawing.Size(38, 17);
            this.chkDia29.TabIndex = 73;
            this.chkDia29.Text = "29";
            this.chkDia29.UseVisualStyleBackColor = true;
            // 
            // chkDia30
            // 
            this.chkDia30.AutoSize = true;
            this.chkDia30.Location = new System.Drawing.Point(370, 81);
            this.chkDia30.Margin = new System.Windows.Forms.Padding(2);
            this.chkDia30.Name = "chkDia30";
            this.chkDia30.Size = new System.Drawing.Size(38, 17);
            this.chkDia30.TabIndex = 72;
            this.chkDia30.Text = "30";
            this.chkDia30.UseVisualStyleBackColor = true;
            // 
            // chkDia28
            // 
            this.chkDia28.AutoSize = true;
            this.chkDia28.Location = new System.Drawing.Point(289, 81);
            this.chkDia28.Margin = new System.Windows.Forms.Padding(2);
            this.chkDia28.Name = "chkDia28";
            this.chkDia28.Size = new System.Drawing.Size(38, 17);
            this.chkDia28.TabIndex = 71;
            this.chkDia28.Text = "28";
            this.chkDia28.UseVisualStyleBackColor = true;
            // 
            // chkDia27
            // 
            this.chkDia27.AutoSize = true;
            this.chkDia27.Location = new System.Drawing.Point(251, 81);
            this.chkDia27.Margin = new System.Windows.Forms.Padding(2);
            this.chkDia27.Name = "chkDia27";
            this.chkDia27.Size = new System.Drawing.Size(38, 17);
            this.chkDia27.TabIndex = 70;
            this.chkDia27.Text = "27";
            this.chkDia27.UseVisualStyleBackColor = true;
            // 
            // chkDia26
            // 
            this.chkDia26.AutoSize = true;
            this.chkDia26.Location = new System.Drawing.Point(214, 81);
            this.chkDia26.Margin = new System.Windows.Forms.Padding(2);
            this.chkDia26.Name = "chkDia26";
            this.chkDia26.Size = new System.Drawing.Size(38, 17);
            this.chkDia26.TabIndex = 69;
            this.chkDia26.Text = "26";
            this.chkDia26.UseVisualStyleBackColor = true;
            // 
            // chkDia24
            // 
            this.chkDia24.AutoSize = true;
            this.chkDia24.Location = new System.Drawing.Point(135, 81);
            this.chkDia24.Margin = new System.Windows.Forms.Padding(2);
            this.chkDia24.Name = "chkDia24";
            this.chkDia24.Size = new System.Drawing.Size(38, 17);
            this.chkDia24.TabIndex = 68;
            this.chkDia24.Text = "24";
            this.chkDia24.UseVisualStyleBackColor = true;
            // 
            // chkDia25
            // 
            this.chkDia25.AutoSize = true;
            this.chkDia25.Location = new System.Drawing.Point(175, 81);
            this.chkDia25.Margin = new System.Windows.Forms.Padding(2);
            this.chkDia25.Name = "chkDia25";
            this.chkDia25.Size = new System.Drawing.Size(38, 17);
            this.chkDia25.TabIndex = 67;
            this.chkDia25.Text = "25";
            this.chkDia25.UseVisualStyleBackColor = true;
            // 
            // chkDia23
            // 
            this.chkDia23.AutoSize = true;
            this.chkDia23.Location = new System.Drawing.Point(98, 81);
            this.chkDia23.Margin = new System.Windows.Forms.Padding(2);
            this.chkDia23.Name = "chkDia23";
            this.chkDia23.Size = new System.Drawing.Size(38, 17);
            this.chkDia23.TabIndex = 66;
            this.chkDia23.Text = "23";
            this.chkDia23.UseVisualStyleBackColor = true;
            // 
            // chkDia22
            // 
            this.chkDia22.AutoSize = true;
            this.chkDia22.Location = new System.Drawing.Point(63, 81);
            this.chkDia22.Margin = new System.Windows.Forms.Padding(2);
            this.chkDia22.Name = "chkDia22";
            this.chkDia22.Size = new System.Drawing.Size(38, 17);
            this.chkDia22.TabIndex = 65;
            this.chkDia22.Text = "22";
            this.chkDia22.UseVisualStyleBackColor = true;
            // 
            // chkDia21
            // 
            this.chkDia21.AutoSize = true;
            this.chkDia21.Location = new System.Drawing.Point(24, 81);
            this.chkDia21.Margin = new System.Windows.Forms.Padding(2);
            this.chkDia21.Name = "chkDia21";
            this.chkDia21.Size = new System.Drawing.Size(38, 17);
            this.chkDia21.TabIndex = 64;
            this.chkDia21.Text = "21";
            this.chkDia21.UseVisualStyleBackColor = true;
            // 
            // chkDia8
            // 
            this.chkDia8.AutoSize = true;
            this.chkDia8.Location = new System.Drawing.Point(289, 22);
            this.chkDia8.Margin = new System.Windows.Forms.Padding(2);
            this.chkDia8.Name = "chkDia8";
            this.chkDia8.Size = new System.Drawing.Size(32, 17);
            this.chkDia8.TabIndex = 51;
            this.chkDia8.Text = "8";
            this.chkDia8.UseVisualStyleBackColor = true;
            // 
            // chkDia18
            // 
            this.chkDia18.AutoSize = true;
            this.chkDia18.Location = new System.Drawing.Point(289, 51);
            this.chkDia18.Margin = new System.Windows.Forms.Padding(2);
            this.chkDia18.Name = "chkDia18";
            this.chkDia18.Size = new System.Drawing.Size(38, 17);
            this.chkDia18.TabIndex = 63;
            this.chkDia18.Text = "18";
            this.chkDia18.UseVisualStyleBackColor = true;
            // 
            // chkDia1
            // 
            this.chkDia1.AutoSize = true;
            this.chkDia1.Location = new System.Drawing.Point(24, 22);
            this.chkDia1.Margin = new System.Windows.Forms.Padding(2);
            this.chkDia1.Name = "chkDia1";
            this.chkDia1.Size = new System.Drawing.Size(32, 17);
            this.chkDia1.TabIndex = 44;
            this.chkDia1.Text = "1";
            this.chkDia1.UseVisualStyleBackColor = true;
            // 
            // chkDia19
            // 
            this.chkDia19.AutoSize = true;
            this.chkDia19.Location = new System.Drawing.Point(330, 51);
            this.chkDia19.Margin = new System.Windows.Forms.Padding(2);
            this.chkDia19.Name = "chkDia19";
            this.chkDia19.Size = new System.Drawing.Size(38, 17);
            this.chkDia19.TabIndex = 62;
            this.chkDia19.Text = "19";
            this.chkDia19.UseVisualStyleBackColor = true;
            // 
            // chkDia2
            // 
            this.chkDia2.AutoSize = true;
            this.chkDia2.Location = new System.Drawing.Point(63, 22);
            this.chkDia2.Margin = new System.Windows.Forms.Padding(2);
            this.chkDia2.Name = "chkDia2";
            this.chkDia2.Size = new System.Drawing.Size(32, 17);
            this.chkDia2.TabIndex = 45;
            this.chkDia2.Text = "2";
            this.chkDia2.UseVisualStyleBackColor = true;
            // 
            // chkDia17
            // 
            this.chkDia17.AutoSize = true;
            this.chkDia17.Location = new System.Drawing.Point(251, 51);
            this.chkDia17.Margin = new System.Windows.Forms.Padding(2);
            this.chkDia17.Name = "chkDia17";
            this.chkDia17.Size = new System.Drawing.Size(38, 17);
            this.chkDia17.TabIndex = 61;
            this.chkDia17.Text = "17";
            this.chkDia17.UseVisualStyleBackColor = true;
            // 
            // chkDia3
            // 
            this.chkDia3.AutoSize = true;
            this.chkDia3.Location = new System.Drawing.Point(98, 22);
            this.chkDia3.Margin = new System.Windows.Forms.Padding(2);
            this.chkDia3.Name = "chkDia3";
            this.chkDia3.Size = new System.Drawing.Size(32, 17);
            this.chkDia3.TabIndex = 46;
            this.chkDia3.Text = "3";
            this.chkDia3.UseVisualStyleBackColor = true;
            // 
            // chkDia16
            // 
            this.chkDia16.AutoSize = true;
            this.chkDia16.Location = new System.Drawing.Point(214, 51);
            this.chkDia16.Margin = new System.Windows.Forms.Padding(2);
            this.chkDia16.Name = "chkDia16";
            this.chkDia16.Size = new System.Drawing.Size(38, 17);
            this.chkDia16.TabIndex = 60;
            this.chkDia16.Text = "16";
            this.chkDia16.UseVisualStyleBackColor = true;
            // 
            // chkDia5
            // 
            this.chkDia5.AutoSize = true;
            this.chkDia5.Location = new System.Drawing.Point(175, 22);
            this.chkDia5.Margin = new System.Windows.Forms.Padding(2);
            this.chkDia5.Name = "chkDia5";
            this.chkDia5.Size = new System.Drawing.Size(32, 17);
            this.chkDia5.TabIndex = 47;
            this.chkDia5.Text = "5";
            this.chkDia5.UseVisualStyleBackColor = true;
            // 
            // chkDia15
            // 
            this.chkDia15.AutoSize = true;
            this.chkDia15.Location = new System.Drawing.Point(175, 51);
            this.chkDia15.Margin = new System.Windows.Forms.Padding(2);
            this.chkDia15.Name = "chkDia15";
            this.chkDia15.Size = new System.Drawing.Size(38, 17);
            this.chkDia15.TabIndex = 59;
            this.chkDia15.Text = "15";
            this.chkDia15.UseVisualStyleBackColor = true;
            // 
            // chkDia4
            // 
            this.chkDia4.AutoSize = true;
            this.chkDia4.Location = new System.Drawing.Point(135, 22);
            this.chkDia4.Margin = new System.Windows.Forms.Padding(2);
            this.chkDia4.Name = "chkDia4";
            this.chkDia4.Size = new System.Drawing.Size(32, 17);
            this.chkDia4.TabIndex = 48;
            this.chkDia4.Text = "4";
            this.chkDia4.UseVisualStyleBackColor = true;
            // 
            // chkDia13
            // 
            this.chkDia13.AutoSize = true;
            this.chkDia13.Location = new System.Drawing.Point(98, 51);
            this.chkDia13.Margin = new System.Windows.Forms.Padding(2);
            this.chkDia13.Name = "chkDia13";
            this.chkDia13.Size = new System.Drawing.Size(38, 17);
            this.chkDia13.TabIndex = 58;
            this.chkDia13.Text = "13";
            this.chkDia13.UseVisualStyleBackColor = true;
            // 
            // chkDia6
            // 
            this.chkDia6.AutoSize = true;
            this.chkDia6.Location = new System.Drawing.Point(214, 22);
            this.chkDia6.Margin = new System.Windows.Forms.Padding(2);
            this.chkDia6.Name = "chkDia6";
            this.chkDia6.Size = new System.Drawing.Size(32, 17);
            this.chkDia6.TabIndex = 49;
            this.chkDia6.Text = "6";
            this.chkDia6.UseVisualStyleBackColor = true;
            // 
            // chkDia14
            // 
            this.chkDia14.AutoSize = true;
            this.chkDia14.Location = new System.Drawing.Point(135, 51);
            this.chkDia14.Margin = new System.Windows.Forms.Padding(2);
            this.chkDia14.Name = "chkDia14";
            this.chkDia14.Size = new System.Drawing.Size(38, 17);
            this.chkDia14.TabIndex = 57;
            this.chkDia14.Text = "14";
            this.chkDia14.UseVisualStyleBackColor = true;
            // 
            // chkDia7
            // 
            this.chkDia7.AutoSize = true;
            this.chkDia7.Location = new System.Drawing.Point(251, 22);
            this.chkDia7.Margin = new System.Windows.Forms.Padding(2);
            this.chkDia7.Name = "chkDia7";
            this.chkDia7.Size = new System.Drawing.Size(32, 17);
            this.chkDia7.TabIndex = 50;
            this.chkDia7.Text = "7";
            this.chkDia7.UseVisualStyleBackColor = true;
            // 
            // chkDia12
            // 
            this.chkDia12.AutoSize = true;
            this.chkDia12.Location = new System.Drawing.Point(63, 51);
            this.chkDia12.Margin = new System.Windows.Forms.Padding(2);
            this.chkDia12.Name = "chkDia12";
            this.chkDia12.Size = new System.Drawing.Size(38, 17);
            this.chkDia12.TabIndex = 56;
            this.chkDia12.Text = "12";
            this.chkDia12.UseVisualStyleBackColor = true;
            // 
            // chkDia10
            // 
            this.chkDia10.AutoSize = true;
            this.chkDia10.Location = new System.Drawing.Point(370, 22);
            this.chkDia10.Margin = new System.Windows.Forms.Padding(2);
            this.chkDia10.Name = "chkDia10";
            this.chkDia10.Size = new System.Drawing.Size(38, 17);
            this.chkDia10.TabIndex = 52;
            this.chkDia10.Text = "10";
            this.chkDia10.UseVisualStyleBackColor = true;
            // 
            // chkDia11
            // 
            this.chkDia11.AutoSize = true;
            this.chkDia11.Location = new System.Drawing.Point(24, 51);
            this.chkDia11.Margin = new System.Windows.Forms.Padding(2);
            this.chkDia11.Name = "chkDia11";
            this.chkDia11.Size = new System.Drawing.Size(38, 17);
            this.chkDia11.TabIndex = 55;
            this.chkDia11.Text = "11";
            this.chkDia11.UseVisualStyleBackColor = true;
            // 
            // chkDia9
            // 
            this.chkDia9.AutoSize = true;
            this.chkDia9.Location = new System.Drawing.Point(330, 22);
            this.chkDia9.Margin = new System.Windows.Forms.Padding(2);
            this.chkDia9.Name = "chkDia9";
            this.chkDia9.Size = new System.Drawing.Size(32, 17);
            this.chkDia9.TabIndex = 53;
            this.chkDia9.Text = "9";
            this.chkDia9.UseVisualStyleBackColor = true;
            // 
            // chkDia20
            // 
            this.chkDia20.AutoSize = true;
            this.chkDia20.Location = new System.Drawing.Point(370, 51);
            this.chkDia20.Margin = new System.Windows.Forms.Padding(2);
            this.chkDia20.Name = "chkDia20";
            this.chkDia20.Size = new System.Drawing.Size(38, 17);
            this.chkDia20.TabIndex = 54;
            this.chkDia20.Text = "20";
            this.chkDia20.UseVisualStyleBackColor = true;
            // 
            // CALENDARIO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1124, 376);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_Grabar);
            this.Controls.Add(this.numAño);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboMes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gbMes);
            this.Controls.Add(this.btn_modificar);
            this.Controls.Add(this.btn_salir);
            this.Controls.Add(this.btn_nuevo);
            this.Controls.Add(this.dgvCalendario);
            this.Name = "CALENDARIO";
            this.Text = "CALENDARIO";
            this.Load += new System.EventHandler(this.CALENDARIO_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalendario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAño)).EndInit();
            this.gbMes.ResumeLayout(false);
            this.gbMes.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCalendario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        internal System.Windows.Forms.Button btn_modificar;
        internal System.Windows.Forms.Button btn_salir;
        internal System.Windows.Forms.Button btn_nuevo;
        internal System.Windows.Forms.Button button1;
        internal System.Windows.Forms.Button btn_Grabar;
        private System.Windows.Forms.NumericUpDown numAño;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboMes;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.GroupBox gbMes;
        private System.Windows.Forms.CheckBox chkDia31;
        private System.Windows.Forms.CheckBox chkDia29;
        private System.Windows.Forms.CheckBox chkDia30;
        private System.Windows.Forms.CheckBox chkDia28;
        private System.Windows.Forms.CheckBox chkDia27;
        private System.Windows.Forms.CheckBox chkDia26;
        private System.Windows.Forms.CheckBox chkDia24;
        private System.Windows.Forms.CheckBox chkDia25;
        private System.Windows.Forms.CheckBox chkDia23;
        private System.Windows.Forms.CheckBox chkDia22;
        private System.Windows.Forms.CheckBox chkDia21;
        private System.Windows.Forms.CheckBox chkDia8;
        private System.Windows.Forms.CheckBox chkDia18;
        private System.Windows.Forms.CheckBox chkDia1;
        private System.Windows.Forms.CheckBox chkDia19;
        private System.Windows.Forms.CheckBox chkDia2;
        private System.Windows.Forms.CheckBox chkDia17;
        private System.Windows.Forms.CheckBox chkDia3;
        private System.Windows.Forms.CheckBox chkDia16;
        private System.Windows.Forms.CheckBox chkDia5;
        private System.Windows.Forms.CheckBox chkDia15;
        private System.Windows.Forms.CheckBox chkDia4;
        private System.Windows.Forms.CheckBox chkDia13;
        private System.Windows.Forms.CheckBox chkDia6;
        private System.Windows.Forms.CheckBox chkDia14;
        private System.Windows.Forms.CheckBox chkDia7;
        private System.Windows.Forms.CheckBox chkDia12;
        private System.Windows.Forms.CheckBox chkDia10;
        private System.Windows.Forms.CheckBox chkDia11;
        private System.Windows.Forms.CheckBox chkDia9;
        private System.Windows.Forms.CheckBox chkDia20;
    }
}