namespace Presentacion.MOD_ADM
{
    partial class PERIODO
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PERIODO));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.btn_modificar = new System.Windows.Forms.Button();
            this.btn_salir = new System.Windows.Forms.Button();
            this.btn_activar = new System.Windows.Forms.Button();
            this.btn_nuevo = new System.Windows.Forms.Button();
            this.dgw1 = new System.Windows.Forms.DataGridView();
            this.annio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ini = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.act = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.mess = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_modificar2 = new System.Windows.Forms.Button();
            this.btn_guardar = new System.Windows.Forms.Button();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.grvDatos = new System.Windows.Forms.GroupBox();
            this.dtp2 = new System.Windows.Forms.DateTimePicker();
            this.dtp1 = new System.Windows.Forms.DateTimePicker();
            this.cbo_mes = new System.Windows.Forms.ComboBox();
            this.cbo_año = new System.Windows.Forms.NumericUpDown();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.TabControl1.SuspendLayout();
            this.TabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw1)).BeginInit();
            this.TabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grvDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_año)).BeginInit();
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
            this.TabControl1.Size = new System.Drawing.Size(542, 273);
            this.TabControl1.TabIndex = 1;
            this.TabControl1.SelectedIndexChanged += new System.EventHandler(this.TabControl1_SelectedIndexChanged);
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.btn_modificar);
            this.TabPage1.Controls.Add(this.btn_salir);
            this.TabPage1.Controls.Add(this.btn_activar);
            this.TabPage1.Controls.Add(this.btn_nuevo);
            this.TabPage1.Controls.Add(this.dgw1);
            this.TabPage1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabPage1.Location = new System.Drawing.Point(4, 23);
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage1.Size = new System.Drawing.Size(534, 246);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "Lista de Periodos";
            this.TabPage1.UseVisualStyleBackColor = true;
            // 
            // btn_modificar
            // 
            this.btn_modificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_modificar.Image = ((System.Drawing.Image)(resources.GetObject("btn_modificar.Image")));
            this.btn_modificar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_modificar.Location = new System.Drawing.Point(415, 63);
            this.btn_modificar.Name = "btn_modificar";
            this.btn_modificar.Size = new System.Drawing.Size(85, 35);
            this.btn_modificar.TabIndex = 2;
            this.btn_modificar.Text = "&Modificar";
            this.btn_modificar.UseVisualStyleBackColor = true;
            this.btn_modificar.Click += new System.EventHandler(this.btn_modificar_Click);
            // 
            // btn_salir
            // 
            this.btn_salir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_salir.Image = ((System.Drawing.Image)(resources.GetObject("btn_salir.Image")));
            this.btn_salir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_salir.Location = new System.Drawing.Point(415, 145);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(85, 35);
            this.btn_salir.TabIndex = 4;
            this.btn_salir.Text = "&Salir";
            this.btn_salir.UseVisualStyleBackColor = true;
            this.btn_salir.Click += new System.EventHandler(this.btn_salir_Click);
            // 
            // btn_activar
            // 
            this.btn_activar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_activar.Image = ((System.Drawing.Image)(resources.GetObject("btn_activar.Image")));
            this.btn_activar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_activar.Location = new System.Drawing.Point(415, 104);
            this.btn_activar.Name = "btn_activar";
            this.btn_activar.Size = new System.Drawing.Size(110, 35);
            this.btn_activar.TabIndex = 3;
            this.btn_activar.Text = "&Activar Periodo";
            this.btn_activar.UseVisualStyleBackColor = true;
            this.btn_activar.Click += new System.EventHandler(this.btn_activar_Click);
            // 
            // btn_nuevo
            // 
            this.btn_nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_nuevo.Image = ((System.Drawing.Image)(resources.GetObject("btn_nuevo.Image")));
            this.btn_nuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_nuevo.Location = new System.Drawing.Point(415, 22);
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
            this.dgw1.AllowUserToOrderColumns = true;
            this.dgw1.AllowUserToResizeRows = false;
            this.dgw1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgw1.BackgroundColor = System.Drawing.Color.White;
            this.dgw1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgw1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.annio,
            this.mes,
            this.ini,
            this.fin,
            this.act,
            this.mess});
            this.dgw1.Location = new System.Drawing.Point(23, 22);
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
            this.dgw1.TabIndex = 0;
            this.dgw1.TabStop = false;
            // 
            // annio
            // 
            this.annio.HeaderText = "Año";
            this.annio.Name = "annio";
            this.annio.ReadOnly = true;
            // 
            // mes
            // 
            this.mes.HeaderText = "Mes";
            this.mes.Name = "mes";
            this.mes.ReadOnly = true;
            // 
            // ini
            // 
            this.ini.HeaderText = "Inicio";
            this.ini.Name = "ini";
            this.ini.ReadOnly = true;
            // 
            // fin
            // 
            this.fin.HeaderText = "Final";
            this.fin.Name = "fin";
            this.fin.ReadOnly = true;
            // 
            // act
            // 
            this.act.HeaderText = "Activo";
            this.act.Name = "act";
            this.act.ReadOnly = true;
            // 
            // mess
            // 
            this.mess.HeaderText = "mess";
            this.mess.Name = "mess";
            this.mess.ReadOnly = true;
            this.mess.Visible = false;
            // 
            // TabPage2
            // 
            this.TabPage2.Controls.Add(this.groupBox2);
            this.TabPage2.Controls.Add(this.grvDatos);
            this.TabPage2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabPage2.Location = new System.Drawing.Point(4, 23);
            this.TabPage2.Name = "TabPage2";
            this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage2.Size = new System.Drawing.Size(534, 246);
            this.TabPage2.TabIndex = 1;
            this.TabPage2.Text = "Detalles";
            this.TabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_modificar2);
            this.groupBox2.Controls.Add(this.btn_guardar);
            this.groupBox2.Controls.Add(this.btn_cancelar);
            this.groupBox2.Location = new System.Drawing.Point(78, 164);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(345, 47);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            // 
            // btn_modificar2
            // 
            this.btn_modificar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_modificar2.Image = ((System.Drawing.Image)(resources.GetObject("btn_modificar2.Image")));
            this.btn_modificar2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_modificar2.Location = new System.Drawing.Point(94, 14);
            this.btn_modificar2.Name = "btn_modificar2";
            this.btn_modificar2.Size = new System.Drawing.Size(77, 27);
            this.btn_modificar2.TabIndex = 5;
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
            this.btn_guardar.Location = new System.Drawing.Point(94, 14);
            this.btn_guardar.Name = "btn_guardar";
            this.btn_guardar.Size = new System.Drawing.Size(77, 27);
            this.btn_guardar.TabIndex = 4;
            this.btn_guardar.Text = "&Guardar";
            this.btn_guardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_guardar.UseVisualStyleBackColor = true;
            this.btn_guardar.Click += new System.EventHandler(this.btn_guardar_Click);
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancelar.Image = ((System.Drawing.Image)(resources.GetObject("btn_cancelar.Image")));
            this.btn_cancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_cancelar.Location = new System.Drawing.Point(175, 14);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(77, 27);
            this.btn_cancelar.TabIndex = 6;
            this.btn_cancelar.Text = "&Cancelar";
            this.btn_cancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_cancelar.UseVisualStyleBackColor = true;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // grvDatos
            // 
            this.grvDatos.Controls.Add(this.dtp2);
            this.grvDatos.Controls.Add(this.dtp1);
            this.grvDatos.Controls.Add(this.cbo_mes);
            this.grvDatos.Controls.Add(this.cbo_año);
            this.grvDatos.Controls.Add(this.Label5);
            this.grvDatos.Controls.Add(this.Label4);
            this.grvDatos.Controls.Add(this.Label3);
            this.grvDatos.Controls.Add(this.Label1);
            this.grvDatos.Location = new System.Drawing.Point(78, 21);
            this.grvDatos.Name = "grvDatos";
            this.grvDatos.Size = new System.Drawing.Size(345, 144);
            this.grvDatos.TabIndex = 14;
            this.grvDatos.TabStop = false;
            // 
            // dtp2
            // 
            this.dtp2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp2.Location = new System.Drawing.Point(141, 103);
            this.dtp2.Name = "dtp2";
            this.dtp2.Size = new System.Drawing.Size(85, 20);
            this.dtp2.TabIndex = 3;
            // 
            // dtp1
            // 
            this.dtp1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp1.Location = new System.Drawing.Point(141, 77);
            this.dtp1.Name = "dtp1";
            this.dtp1.Size = new System.Drawing.Size(85, 20);
            this.dtp1.TabIndex = 2;
            // 
            // cbo_mes
            // 
            this.cbo_mes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_mes.FormattingEnabled = true;
            this.cbo_mes.Location = new System.Drawing.Point(141, 49);
            this.cbo_mes.Name = "cbo_mes";
            this.cbo_mes.Size = new System.Drawing.Size(99, 22);
            this.cbo_mes.TabIndex = 1;
            this.cbo_mes.SelectedIndexChanged += new System.EventHandler(this.cbo_mes_SelectedIndexChanged);
            // 
            // cbo_año
            // 
            this.cbo_año.Location = new System.Drawing.Point(141, 23);
            this.cbo_año.Maximum = new decimal(new int[] {
            2100,
            0,
            0,
            0});
            this.cbo_año.Minimum = new decimal(new int[] {
            1999,
            0,
            0,
            0});
            this.cbo_año.Name = "cbo_año";
            this.cbo_año.Size = new System.Drawing.Size(58, 20);
            this.cbo_año.TabIndex = 0;
            this.cbo_año.Value = new decimal(new int[] {
            2008,
            0,
            0,
            0});
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(38, 52);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(0, 14);
            this.Label5.TabIndex = 9;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(38, 80);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(64, 14);
            this.Label4.TabIndex = 8;
            this.Label4.Text = "Fecha Inicio";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(38, 106);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(84, 14);
            this.Label3.TabIndex = 7;
            this.Label3.Text = "Fecha de Cierre";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(38, 25);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(27, 14);
            this.Label1.TabIndex = 5;
            this.Label1.Text = "Año";
            // 
            // PERIODO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 273);
            this.Controls.Add(this.TabControl1);
            this.Name = "PERIODO";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PERIODO";
            this.Load += new System.EventHandler(this.PERIODO_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PERIODO_KeyDown);
            this.TabControl1.ResumeLayout(false);
            this.TabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgw1)).EndInit();
            this.TabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.grvDatos.ResumeLayout(false);
            this.grvDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_año)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TabControl TabControl1;
        internal System.Windows.Forms.TabPage TabPage1;
        internal System.Windows.Forms.Button btn_modificar;
        internal System.Windows.Forms.Button btn_salir;
        internal System.Windows.Forms.Button btn_activar;
        internal System.Windows.Forms.Button btn_nuevo;
        internal System.Windows.Forms.DataGridView dgw1;
        internal System.Windows.Forms.TabPage TabPage2;
        internal System.Windows.Forms.GroupBox grvDatos;
        internal System.Windows.Forms.DateTimePicker dtp2;
        internal System.Windows.Forms.Button btn_modificar2;
        internal System.Windows.Forms.DateTimePicker dtp1;
        internal System.Windows.Forms.Button btn_cancelar;
        internal System.Windows.Forms.Button btn_guardar;
        internal System.Windows.Forms.ComboBox cbo_mes;
        internal System.Windows.Forms.NumericUpDown cbo_año;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn annio;
        private System.Windows.Forms.DataGridViewTextBoxColumn mes;
        private System.Windows.Forms.DataGridViewTextBoxColumn ini;
        private System.Windows.Forms.DataGridViewTextBoxColumn fin;
        private System.Windows.Forms.DataGridViewCheckBoxColumn act;
        private System.Windows.Forms.DataGridViewTextBoxColumn mess;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}