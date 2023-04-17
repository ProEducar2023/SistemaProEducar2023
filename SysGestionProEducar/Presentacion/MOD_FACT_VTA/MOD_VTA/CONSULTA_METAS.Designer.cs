namespace Presentacion.MOD_FACT_VTA.MOD_VTA
{
    partial class CONSULTA_METAS
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CONSULTA_METAS));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel_per2 = new System.Windows.Forms.Panel();
            this.dgw_per2 = new System.Windows.Forms.DataGridView();
            this.gbGeneral = new System.Windows.Forms.GroupBox();
            this.cbo_nivel = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbo_tipo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboAño = new System.Windows.Forms.ComboBox();
            this.Label23 = new System.Windows.Forms.Label();
            this.cboMes = new System.Windows.Forms.ComboBox();
            this.Label11 = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.cboSucursal = new System.Windows.Forms.ComboBox();
            this.Label7 = new System.Windows.Forms.Label();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txt_desc2 = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.cbo_prog = new System.Windows.Forms.ComboBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_monto = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_blanco = new System.Windows.Forms.TextBox();
            this.panel_per2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw_per2)).BeginInit();
            this.gbGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_per2
            // 
            this.panel_per2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_per2.Controls.Add(this.dgw_per2);
            this.panel_per2.Location = new System.Drawing.Point(13, 182);
            this.panel_per2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel_per2.Name = "panel_per2";
            this.panel_per2.Size = new System.Drawing.Size(588, 138);
            this.panel_per2.TabIndex = 9;
            this.panel_per2.Visible = false;
            // 
            // dgw_per2
            // 
            this.dgw_per2.AllowUserToAddRows = false;
            this.dgw_per2.AllowUserToDeleteRows = false;
            this.dgw_per2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dgw_per2.BackgroundColor = System.Drawing.Color.White;
            this.dgw_per2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgw_per2.DefaultCellStyle = dataGridViewCellStyle6;
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
            this.gbGeneral.Controls.Add(this.txt_blanco);
            this.gbGeneral.Controls.Add(this.cbo_nivel);
            this.gbGeneral.Controls.Add(this.label3);
            this.gbGeneral.Controls.Add(this.cbo_tipo);
            this.gbGeneral.Controls.Add(this.label2);
            this.gbGeneral.Controls.Add(this.cboAño);
            this.gbGeneral.Controls.Add(this.Label23);
            this.gbGeneral.Controls.Add(this.cboMes);
            this.gbGeneral.Controls.Add(this.Label11);
            this.gbGeneral.Controls.Add(this.btnSalir);
            this.gbGeneral.Controls.Add(this.btnConsultar);
            this.gbGeneral.Controls.Add(this.cboSucursal);
            this.gbGeneral.Controls.Add(this.Label7);
            this.gbGeneral.Controls.Add(this.txtDni);
            this.gbGeneral.Controls.Add(this.txtCodigo);
            this.gbGeneral.Controls.Add(this.txt_desc2);
            this.gbGeneral.Controls.Add(this.Label4);
            this.gbGeneral.Controls.Add(this.cbo_prog);
            this.gbGeneral.Controls.Add(this.Label1);
            this.gbGeneral.Location = new System.Drawing.Point(12, 12);
            this.gbGeneral.Name = "gbGeneral";
            this.gbGeneral.Size = new System.Drawing.Size(593, 184);
            this.gbGeneral.TabIndex = 8;
            this.gbGeneral.TabStop = false;
            // 
            // cbo_nivel
            // 
            this.cbo_nivel.BackColor = System.Drawing.Color.White;
            this.cbo_nivel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_nivel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_nivel.FormattingEnabled = true;
            this.cbo_nivel.Location = new System.Drawing.Point(110, 122);
            this.cbo_nivel.Name = "cbo_nivel";
            this.cbo_nivel.Size = new System.Drawing.Size(266, 22);
            this.cbo_nivel.TabIndex = 25;
            this.cbo_nivel.SelectedIndexChanged += new System.EventHandler(this.cbo_nivel_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Nivel";
            // 
            // cbo_tipo
            // 
            this.cbo_tipo.BackColor = System.Drawing.Color.White;
            this.cbo_tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_tipo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_tipo.FormattingEnabled = true;
            this.cbo_tipo.Location = new System.Drawing.Point(110, 96);
            this.cbo_tipo.Name = "cbo_tipo";
            this.cbo_tipo.Size = new System.Drawing.Size(266, 22);
            this.cbo_tipo.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Tipo";
            // 
            // cboAño
            // 
            this.cboAño.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAño.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboAño.FormattingEnabled = true;
            this.cboAño.Items.AddRange(new object[] {
            "1990",
            "1991",
            "1992",
            "1993",
            "1994",
            "1995",
            "1996",
            "1997",
            "1998",
            "1999",
            "2000",
            "2001",
            "2002",
            "2003",
            "2004",
            "2005",
            "2006",
            "2007",
            "2008",
            "2009"});
            this.cboAño.Location = new System.Drawing.Point(298, 14);
            this.cboAño.Name = "cboAño";
            this.cboAño.Size = new System.Drawing.Size(77, 22);
            this.cboAño.TabIndex = 21;
            // 
            // Label23
            // 
            this.Label23.AutoSize = true;
            this.Label23.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label23.Location = new System.Drawing.Point(266, 22);
            this.Label23.Name = "Label23";
            this.Label23.Size = new System.Drawing.Size(27, 14);
            this.Label23.TabIndex = 20;
            this.Label23.Text = "Año";
            // 
            // cboMes
            // 
            this.cboMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMes.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMes.FormattingEnabled = true;
            this.cboMes.Location = new System.Drawing.Point(110, 14);
            this.cboMes.Name = "cboMes";
            this.cboMes.Size = new System.Drawing.Size(92, 22);
            this.cboMes.TabIndex = 19;
            // 
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.Location = new System.Drawing.Point(20, 22);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(27, 13);
            this.Label11.TabIndex = 18;
            this.Label11.Text = "Mes";
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
            this.btnConsultar.TabIndex = 16;
            this.btnConsultar.Text = "&Consultar";
            this.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // cboSucursal
            // 
            this.cboSucursal.BackColor = System.Drawing.Color.White;
            this.cboSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSucursal.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSucursal.FormattingEnabled = true;
            this.cboSucursal.Location = new System.Drawing.Point(109, 41);
            this.cboSucursal.Name = "cboSucursal";
            this.cboSucursal.Size = new System.Drawing.Size(266, 22);
            this.cboSucursal.TabIndex = 1;
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(19, 49);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(48, 13);
            this.Label7.TabIndex = 0;
            this.Label7.Text = "Sucursal";
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
            this.codigo,
            this.nombre,
            this.monto});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgv.Location = new System.Drawing.Point(35, 222);
            this.dgv.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersWidth = 25;
            this.dgv.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dgv.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(547, 197);
            this.dgv.TabIndex = 17;
            this.dgv.TabStop = false;
            // 
            // codigo
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.codigo.DefaultCellStyle = dataGridViewCellStyle7;
            this.codigo.HeaderText = "Codigo";
            this.codigo.Name = "codigo";
            this.codigo.ReadOnly = true;
            this.codigo.Width = 70;
            // 
            // nombre
            // 
            dataGridViewCellStyle8.Format = "d";
            dataGridViewCellStyle8.NullValue = null;
            this.nombre.DefaultCellStyle = dataGridViewCellStyle8;
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            this.nombre.Width = 360;
            // 
            // monto
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.monto.DefaultCellStyle = dataGridViewCellStyle9;
            this.monto.HeaderText = "Monto";
            this.monto.Name = "monto";
            this.monto.ReadOnly = true;
            this.monto.Width = 70;
            // 
            // txt_monto
            // 
            this.txt_monto.BackColor = System.Drawing.Color.White;
            this.txt_monto.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_monto.Location = new System.Drawing.Point(496, 426);
            this.txt_monto.MaxLength = 10;
            this.txt_monto.Name = "txt_monto";
            this.txt_monto.ReadOnly = true;
            this.txt_monto.Size = new System.Drawing.Size(68, 20);
            this.txt_monto.TabIndex = 19;
            this.txt_monto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(463, 431);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 14);
            this.label5.TabIndex = 18;
            this.label5.Text = "Total";
            // 
            // txt_blanco
            // 
            this.txt_blanco.BackColor = System.Drawing.Color.White;
            this.txt_blanco.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_blanco.Location = new System.Drawing.Point(485, 18);
            this.txt_blanco.MaxLength = 10;
            this.txt_blanco.Name = "txt_blanco";
            this.txt_blanco.ReadOnly = true;
            this.txt_blanco.Size = new System.Drawing.Size(12, 20);
            this.txt_blanco.TabIndex = 15;
            this.txt_blanco.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_blanco.Visible = false;
            // 
            // CONSULTA_METAS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 489);
            this.Controls.Add(this.txt_monto);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel_per2);
            this.Controls.Add(this.gbGeneral);
            this.Controls.Add(this.dgv);
            this.Name = "CONSULTA_METAS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CONSULTA METAS";
            this.Load += new System.EventHandler(this.CONSULTA_METAS_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CONSULTA_METAS_KeyDown);
            this.panel_per2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgw_per2)).EndInit();
            this.gbGeneral.ResumeLayout(false);
            this.gbGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Panel panel_per2;
        internal System.Windows.Forms.DataGridView dgw_per2;
        internal System.Windows.Forms.GroupBox gbGeneral;
        internal System.Windows.Forms.ComboBox cbo_nivel;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.ComboBox cbo_tipo;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.ComboBox cboAño;
        internal System.Windows.Forms.Label Label23;
        internal System.Windows.Forms.ComboBox cboMes;
        internal System.Windows.Forms.Label Label11;
        internal System.Windows.Forms.Button btnSalir;
        internal System.Windows.Forms.Button btnConsultar;
        internal System.Windows.Forms.ComboBox cboSucursal;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.TextBox txtDni;
        internal System.Windows.Forms.TextBox txtCodigo;
        internal System.Windows.Forms.TextBox txt_desc2;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.ComboBox cbo_prog;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.DataGridView dgv;
        internal System.Windows.Forms.TextBox txt_monto;
        internal System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn monto;
        internal System.Windows.Forms.TextBox txt_blanco;
    }
}