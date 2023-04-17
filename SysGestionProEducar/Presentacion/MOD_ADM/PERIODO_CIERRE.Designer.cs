namespace Presentacion.MOD_ADM
{
    partial class PERIODO_CIERRE
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tcPeriodo = new System.Windows.Forms.TabControl();
            this.tpLista = new System.Windows.Forms.TabPage();
            this.btn_salir = new System.Windows.Forms.Button();
            this.btn_cierre = new System.Windows.Forms.Button();
            this.dgw1 = new System.Windows.Forms.DataGridView();
            this.tpDetalles = new System.Windows.Forms.TabPage();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.cbo_año = new System.Windows.Forms.ComboBox();
            this.dgvModulos = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.dtp2 = new System.Windows.Forms.DateTimePicker();
            this.dtp1 = new System.Windows.Forms.DateTimePicker();
            this.cboMes = new System.Windows.Forms.ComboBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.annio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ini = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tcPeriodo.SuspendLayout();
            this.tpLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw1)).BeginInit();
            this.tpDetalles.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModulos)).BeginInit();
            this.SuspendLayout();
            // 
            // tcPeriodo
            // 
            this.tcPeriodo.Controls.Add(this.tpLista);
            this.tcPeriodo.Controls.Add(this.tpDetalles);
            this.tcPeriodo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcPeriodo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcPeriodo.Location = new System.Drawing.Point(0, 0);
            this.tcPeriodo.Name = "tcPeriodo";
            this.tcPeriodo.SelectedIndex = 0;
            this.tcPeriodo.Size = new System.Drawing.Size(509, 360);
            this.tcPeriodo.TabIndex = 2;
            this.tcPeriodo.SelectedIndexChanged += new System.EventHandler(this.tcPeriodo_SelectedIndexChanged);
            // 
            // tpLista
            // 
            this.tpLista.Controls.Add(this.btn_salir);
            this.tpLista.Controls.Add(this.btn_cierre);
            this.tpLista.Controls.Add(this.dgw1);
            this.tpLista.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpLista.Location = new System.Drawing.Point(4, 23);
            this.tpLista.Name = "tpLista";
            this.tpLista.Padding = new System.Windows.Forms.Padding(3);
            this.tpLista.Size = new System.Drawing.Size(501, 333);
            this.tpLista.TabIndex = 0;
            this.tpLista.Text = "Lista de Periodos";
            this.tpLista.UseVisualStyleBackColor = true;
            // 
            // btn_salir
            // 
            this.btn_salir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_salir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_salir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_salir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_salir.Location = new System.Drawing.Point(383, 47);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(110, 35);
            this.btn_salir.TabIndex = 6;
            this.btn_salir.Text = "&Salir";
            this.btn_salir.UseVisualStyleBackColor = true;
            // 
            // btn_cierre
            // 
            this.btn_cierre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_cierre.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_cierre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cierre.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_cierre.Location = new System.Drawing.Point(383, 6);
            this.btn_cierre.Name = "btn_cierre";
            this.btn_cierre.Size = new System.Drawing.Size(110, 35);
            this.btn_cierre.TabIndex = 4;
            this.btn_cierre.Text = "&Cierre Periodo";
            this.btn_cierre.UseVisualStyleBackColor = true;
            this.btn_cierre.Click += new System.EventHandler(this.btn_cierre_Click);
            // 
            // dgw1
            // 
            this.dgw1.AllowUserToAddRows = false;
            this.dgw1.AllowUserToDeleteRows = false;
            this.dgw1.AllowUserToOrderColumns = true;
            this.dgw1.AllowUserToResizeRows = false;
            this.dgw1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgw1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgw1.BackgroundColor = System.Drawing.Color.White;
            this.dgw1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgw1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.annio,
            this.mes,
            this.ini,
            this.fin});
            this.dgw1.Location = new System.Drawing.Point(8, 6);
            this.dgw1.MultiSelect = false;
            this.dgw1.Name = "dgw1";
            this.dgw1.ReadOnly = true;
            this.dgw1.RowHeadersWidth = 25;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            this.dgw1.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgw1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dgw1.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.dgw1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgw1.Size = new System.Drawing.Size(369, 319);
            this.dgw1.TabIndex = 0;
            this.dgw1.TabStop = false;
            // 
            // tpDetalles
            // 
            this.tpDetalles.Controls.Add(this.GroupBox1);
            this.tpDetalles.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpDetalles.Location = new System.Drawing.Point(4, 23);
            this.tpDetalles.Name = "tpDetalles";
            this.tpDetalles.Padding = new System.Windows.Forms.Padding(3);
            this.tpDetalles.Size = new System.Drawing.Size(501, 333);
            this.tpDetalles.TabIndex = 1;
            this.tpDetalles.Text = "Detalles";
            this.tpDetalles.UseVisualStyleBackColor = true;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.cbo_año);
            this.GroupBox1.Controls.Add(this.dgvModulos);
            this.GroupBox1.Controls.Add(this.btnGuardar);
            this.GroupBox1.Controls.Add(this.btnCancelar);
            this.GroupBox1.Controls.Add(this.dtp2);
            this.GroupBox1.Controls.Add(this.dtp1);
            this.GroupBox1.Controls.Add(this.cboMes);
            this.GroupBox1.Controls.Add(this.Label5);
            this.GroupBox1.Controls.Add(this.Label4);
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Location = new System.Drawing.Point(54, 6);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(363, 281);
            this.GroupBox1.TabIndex = 14;
            this.GroupBox1.TabStop = false;
            // 
            // cbo_año
            // 
            this.cbo_año.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_año.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_año.FormattingEnabled = true;
            this.cbo_año.Location = new System.Drawing.Point(76, 17);
            this.cbo_año.Name = "cbo_año";
            this.cbo_año.Size = new System.Drawing.Size(90, 22);
            this.cbo_año.TabIndex = 28;
            this.cbo_año.TabStop = false;
            // 
            // dgvModulos
            // 
            this.dgvModulos.AllowUserToAddRows = false;
            this.dgvModulos.AllowUserToDeleteRows = false;
            this.dgvModulos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvModulos.BackgroundColor = System.Drawing.Color.White;
            this.dgvModulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvModulos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dgvModulos.Location = new System.Drawing.Point(31, 71);
            this.dgvModulos.Name = "dgvModulos";
            this.dgvModulos.RowHeadersWidth = 25;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            this.dgvModulos.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvModulos.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dgvModulos.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.dgvModulos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvModulos.Size = new System.Drawing.Size(298, 171);
            this.dgvModulos.TabIndex = 12;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "cod_modulo";
            this.Column1.Name = "Column1";
            this.Column1.Visible = false;
            // 
            // Column2
            // 
            this.Column2.FillWeight = 172.5888F;
            this.Column2.HeaderText = "Módulo";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.FillWeight = 27.41116F;
            this.Column3.HeaderText = "Ok";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.FillWeight = 27.41116F;
            this.Column4.HeaderText = "Ok1";
            this.Column4.Name = "Column4";
            this.Column4.Visible = false;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.Location = new System.Drawing.Point(114, 248);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(77, 27);
            this.btnGuardar.TabIndex = 10;
            this.btnGuardar.Text = "&Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.Location = new System.Drawing.Point(197, 248);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(77, 27);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // dtp2
            // 
            this.dtp2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp2.Location = new System.Drawing.Point(262, 45);
            this.dtp2.Name = "dtp2";
            this.dtp2.Size = new System.Drawing.Size(95, 20);
            this.dtp2.TabIndex = 3;
            // 
            // dtp1
            // 
            this.dtp1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp1.Location = new System.Drawing.Point(76, 45);
            this.dtp1.Name = "dtp1";
            this.dtp1.Size = new System.Drawing.Size(90, 20);
            this.dtp1.TabIndex = 2;
            // 
            // cboMes
            // 
            this.cboMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMes.FormattingEnabled = true;
            this.cboMes.Items.AddRange(new object[] {
            "Enero",
            "Febrero",
            "Marzo",
            "Abril",
            "Mayo",
            "Junio",
            "Julio",
            "Agosto",
            "Setiembre",
            "Octubre",
            "Noviembre",
            "Diciembre"});
            this.cboMes.Location = new System.Drawing.Point(262, 17);
            this.cboMes.Name = "cboMes";
            this.cboMes.Size = new System.Drawing.Size(95, 22);
            this.cboMes.TabIndex = 1;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(229, 25);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(27, 14);
            this.Label5.TabIndex = 9;
            this.Label5.Text = "Mes";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(6, 52);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(64, 14);
            this.Label4.TabIndex = 8;
            this.Label4.Text = "Fecha Inicio";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(172, 51);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(84, 14);
            this.Label3.TabIndex = 7;
            this.Label3.Text = "Fecha de Cierre";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(43, 25);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(27, 14);
            this.Label1.TabIndex = 5;
            this.Label1.Text = "Año";
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
            // PERIODO_CIERRE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 360);
            this.Controls.Add(this.tcPeriodo);
            this.Name = "PERIODO_CIERRE";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PERIODO_CIERRE";
            this.Load += new System.EventHandler(this.PERIODO_CIERRE_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PERIODO_CIERRE_KeyDown);
            this.tcPeriodo.ResumeLayout(false);
            this.tpLista.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgw1)).EndInit();
            this.tpDetalles.ResumeLayout(false);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModulos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TabControl tcPeriodo;
        internal System.Windows.Forms.TabPage tpLista;
        internal System.Windows.Forms.Button btn_salir;
        private System.Windows.Forms.Button btn_cierre;
        internal System.Windows.Forms.DataGridView dgw1;
        internal System.Windows.Forms.TabPage tpDetalles;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.ComboBox cbo_año;
        internal System.Windows.Forms.DataGridView dgvModulos;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        internal System.Windows.Forms.DataGridViewCheckBoxColumn Column3;
        internal System.Windows.Forms.DataGridViewCheckBoxColumn Column4;
        internal System.Windows.Forms.Button btnGuardar;
        internal System.Windows.Forms.Button btnCancelar;
        internal System.Windows.Forms.DateTimePicker dtp2;
        internal System.Windows.Forms.DateTimePicker dtp1;
        internal System.Windows.Forms.ComboBox cboMes;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn annio;
        private System.Windows.Forms.DataGridViewTextBoxColumn mes;
        private System.Windows.Forms.DataGridViewTextBoxColumn ini;
        private System.Windows.Forms.DataGridViewTextBoxColumn fin;
    }
}