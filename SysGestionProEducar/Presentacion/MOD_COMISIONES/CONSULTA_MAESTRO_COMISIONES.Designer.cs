namespace Presentacion.MOD_COMISIONES
{
    partial class CONSULTA_MAESTRO_COMISIONES
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CONSULTA_MAESTRO_COMISIONES));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txt_monto = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel_per2 = new System.Windows.Forms.Panel();
            this.dgw_per2 = new System.Windows.Forms.DataGridView();
            this.gbGeneral = new System.Windows.Forms.GroupBox();
            this.cbo_nivel = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txt_desc2 = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.cbo_prog = new System.Windows.Forms.ComboBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.cbo_tipo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cod_programa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cod_per = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cod_nivel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nom_nivel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cod_per_sup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cuota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel_per2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw_per2)).BeginInit();
            this.gbGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_monto
            // 
            this.txt_monto.BackColor = System.Drawing.Color.White;
            this.txt_monto.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_monto.Location = new System.Drawing.Point(496, 441);
            this.txt_monto.MaxLength = 10;
            this.txt_monto.Name = "txt_monto";
            this.txt_monto.ReadOnly = true;
            this.txt_monto.Size = new System.Drawing.Size(68, 20);
            this.txt_monto.TabIndex = 24;
            this.txt_monto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(463, 446);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 14);
            this.label5.TabIndex = 23;
            this.label5.Text = "Total";
            // 
            // panel_per2
            // 
            this.panel_per2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_per2.Controls.Add(this.dgw_per2);
            this.panel_per2.Location = new System.Drawing.Point(13, 197);
            this.panel_per2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel_per2.Name = "panel_per2";
            this.panel_per2.Size = new System.Drawing.Size(588, 138);
            this.panel_per2.TabIndex = 21;
            this.panel_per2.Visible = false;
            // 
            // dgw_per2
            // 
            this.dgw_per2.AllowUserToAddRows = false;
            this.dgw_per2.AllowUserToDeleteRows = false;
            this.dgw_per2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dgw_per2.BackgroundColor = System.Drawing.Color.White;
            this.dgw_per2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgw_per2.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgw_per2.Location = new System.Drawing.Point(108, -1);
            this.dgw_per2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dgw_per2.MultiSelect = false;
            this.dgw_per2.Name = "dgw_per2";
            this.dgw_per2.ReadOnly = true;
            this.dgw_per2.RowHeadersWidth = 25;
            this.dgw_per2.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dgw_per2.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.dgw_per2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgw_per2.Size = new System.Drawing.Size(478, 124);
            this.dgw_per2.TabIndex = 0;
            this.dgw_per2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgw_per2_KeyDown);
            // 
            // gbGeneral
            // 
            this.gbGeneral.Controls.Add(this.cbo_tipo);
            this.gbGeneral.Controls.Add(this.label2);
            this.gbGeneral.Controls.Add(this.cbo_nivel);
            this.gbGeneral.Controls.Add(this.label3);
            this.gbGeneral.Controls.Add(this.btnSalir);
            this.gbGeneral.Controls.Add(this.btnConsultar);
            this.gbGeneral.Controls.Add(this.txtDni);
            this.gbGeneral.Controls.Add(this.txtCodigo);
            this.gbGeneral.Controls.Add(this.txt_desc2);
            this.gbGeneral.Controls.Add(this.Label4);
            this.gbGeneral.Controls.Add(this.cbo_prog);
            this.gbGeneral.Controls.Add(this.Label1);
            this.gbGeneral.Location = new System.Drawing.Point(12, 27);
            this.gbGeneral.Name = "gbGeneral";
            this.gbGeneral.Size = new System.Drawing.Size(593, 184);
            this.gbGeneral.TabIndex = 20;
            this.gbGeneral.TabStop = false;
            // 
            // cbo_nivel
            // 
            this.cbo_nivel.BackColor = System.Drawing.Color.White;
            this.cbo_nivel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_nivel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_nivel.FormattingEnabled = true;
            this.cbo_nivel.Location = new System.Drawing.Point(110, 109);
            this.cbo_nivel.Name = "cbo_nivel";
            this.cbo_nivel.Size = new System.Drawing.Size(266, 22);
            this.cbo_nivel.TabIndex = 25;
            this.cbo_nivel.SelectedIndexChanged += new System.EventHandler(this.cbo_nivel_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Nivel";
            // 
            // btnSalir
            // 
            this.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(503, 42);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(84, 27);
            this.btnSalir.TabIndex = 17;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnConsultar
            // 
            this.btnConsultar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConsultar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsultar.Image = ((System.Drawing.Image)(resources.GetObject("btnConsultar.Image")));
            this.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConsultar.Location = new System.Drawing.Point(503, 14);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(84, 27);
            this.btnConsultar.TabIndex = 2;
            this.btnConsultar.Text = "&Consultar";
            this.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // txtDni
            // 
            this.txtDni.BackColor = System.Drawing.Color.White;
            this.txtDni.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDni.Location = new System.Drawing.Point(485, 147);
            this.txtDni.MaxLength = 10;
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(102, 20);
            this.txtDni.TabIndex = 7;
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.Color.White;
            this.txtCodigo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.Location = new System.Drawing.Point(109, 147);
            this.txtCodigo.MaxLength = 10;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(68, 20);
            this.txtCodigo.TabIndex = 5;
            this.txtCodigo.Leave += new System.EventHandler(this.txtCodigo_Leave);
            // 
            // txt_desc2
            // 
            this.txt_desc2.BackColor = System.Drawing.Color.White;
            this.txt_desc2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_desc2.Location = new System.Drawing.Point(177, 147);
            this.txt_desc2.MaxLength = 60;
            this.txt_desc2.Name = "txt_desc2";
            this.txt_desc2.Size = new System.Drawing.Size(308, 20);
            this.txt_desc2.TabIndex = 6;
            this.txt_desc2.Leave += new System.EventHandler(this.txt_desc2_Leave);
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(19, 153);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(47, 14);
            this.Label4.TabIndex = 4;
            this.Label4.Text = "Persona";
            // 
            // cbo_prog
            // 
            this.cbo_prog.BackColor = System.Drawing.Color.White;
            this.cbo_prog.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_prog.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_prog.FormattingEnabled = true;
            this.cbo_prog.Location = new System.Drawing.Point(109, 69);
            this.cbo_prog.Name = "cbo_prog";
            this.cbo_prog.Size = new System.Drawing.Size(266, 22);
            this.cbo_prog.TabIndex = 3;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(19, 77);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(52, 13);
            this.Label1.TabIndex = 2;
            this.Label1.Text = "Programa";
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToOrderColumns = true;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dgv.BackgroundColor = System.Drawing.Color.White;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tipo,
            this.cod_programa,
            this.cod_per,
            this.cod_nivel,
            this.nom_nivel,
            this.cod_per_sup,
            this.nombre,
            this.cuota,
            this.monto});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgv.Location = new System.Drawing.Point(35, 237);
            this.dgv.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersWidth = 25;
            this.dgv.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dgv.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(547, 197);
            this.dgv.TabIndex = 22;
            this.dgv.TabStop = false;
            // 
            // cbo_tipo
            // 
            this.cbo_tipo.BackColor = System.Drawing.Color.White;
            this.cbo_tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_tipo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_tipo.FormattingEnabled = true;
            this.cbo_tipo.Location = new System.Drawing.Point(109, 29);
            this.cbo_tipo.Name = "cbo_tipo";
            this.cbo_tipo.Size = new System.Drawing.Size(266, 22);
            this.cbo_tipo.TabIndex = 27;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Tipo";
            // 
            // tipo
            // 
            this.tipo.HeaderText = "tipo";
            this.tipo.Name = "tipo";
            this.tipo.ReadOnly = true;
            this.tipo.Visible = false;
            // 
            // cod_programa
            // 
            this.cod_programa.HeaderText = "cod_programa";
            this.cod_programa.Name = "cod_programa";
            this.cod_programa.ReadOnly = true;
            this.cod_programa.Visible = false;
            // 
            // cod_per
            // 
            this.cod_per.HeaderText = "cod_per";
            this.cod_per.Name = "cod_per";
            this.cod_per.ReadOnly = true;
            this.cod_per.Visible = false;
            // 
            // cod_nivel
            // 
            this.cod_nivel.HeaderText = "cod_nivel";
            this.cod_nivel.Name = "cod_nivel";
            this.cod_nivel.ReadOnly = true;
            this.cod_nivel.Visible = false;
            // 
            // nom_nivel
            // 
            this.nom_nivel.HeaderText = "Nivel";
            this.nom_nivel.Name = "nom_nivel";
            this.nom_nivel.ReadOnly = true;
            this.nom_nivel.Width = 120;
            // 
            // cod_per_sup
            // 
            this.cod_per_sup.HeaderText = "cod_per_sup";
            this.cod_per_sup.Name = "cod_per_sup";
            this.cod_per_sup.ReadOnly = true;
            this.cod_per_sup.Visible = false;
            // 
            // nombre
            // 
            dataGridViewCellStyle6.Format = "d";
            dataGridViewCellStyle6.NullValue = null;
            this.nombre.DefaultCellStyle = dataGridViewCellStyle6;
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            this.nombre.Width = 260;
            // 
            // cuota
            // 
            this.cuota.HeaderText = "Cuota";
            this.cuota.Name = "cuota";
            this.cuota.ReadOnly = true;
            this.cuota.Width = 50;
            // 
            // monto
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.monto.DefaultCellStyle = dataGridViewCellStyle7;
            this.monto.HeaderText = "Monto";
            this.monto.Name = "monto";
            this.monto.ReadOnly = true;
            this.monto.Width = 70;
            // 
            // CONSULTA_MAESTRO_COMISIONES
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 489);
            this.Controls.Add(this.txt_monto);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel_per2);
            this.Controls.Add(this.gbGeneral);
            this.Controls.Add(this.dgv);
            this.Name = "CONSULTA_MAESTRO_COMISIONES";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta Maestro de Comisiones";
            this.Load += new System.EventHandler(this.CONSULTA_MAESTRO_COMISIONES_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CONSULTA_MAESTRO_COMISIONES_KeyDown);
            this.panel_per2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgw_per2)).EndInit();
            this.gbGeneral.ResumeLayout(false);
            this.gbGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox txt_monto;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.Panel panel_per2;
        internal System.Windows.Forms.DataGridView dgw_per2;
        internal System.Windows.Forms.GroupBox gbGeneral;
        internal System.Windows.Forms.ComboBox cbo_nivel;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Button btnSalir;
        internal System.Windows.Forms.Button btnConsultar;
        internal System.Windows.Forms.TextBox txtDni;
        internal System.Windows.Forms.TextBox txtCodigo;
        internal System.Windows.Forms.TextBox txt_desc2;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.ComboBox cbo_prog;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.DataGridView dgv;
        internal System.Windows.Forms.ComboBox cbo_tipo;
        internal System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cod_programa;
        private System.Windows.Forms.DataGridViewTextBoxColumn cod_per;
        private System.Windows.Forms.DataGridViewTextBoxColumn cod_nivel;
        private System.Windows.Forms.DataGridViewTextBoxColumn nom_nivel;
        private System.Windows.Forms.DataGridViewTextBoxColumn cod_per_sup;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn cuota;
        private System.Windows.Forms.DataGridViewTextBoxColumn monto;
    }
}