namespace Presentacion.MOD_ADM
{
    partial class RELACION_EQ_VENTA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RELACION_EQ_VENTA));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.btn_salir = new System.Windows.Forms.Button();
            this.GroupBox8 = new System.Windows.Forms.GroupBox();
            this.btn_sgt = new System.Windows.Forms.Button();
            this.btn_buscar = new System.Windows.Forms.Button();
            this.ch_ca = new System.Windows.Forms.RadioButton();
            this.ch_rs = new System.Windows.Forms.RadioButton();
            this.ch_cod = new System.Windows.Forms.RadioButton();
            this.txt_letra = new System.Windows.Forms.TextBox();
            this.dgw = new System.Windows.Forms.DataGridView();
            this.cod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codpr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descpro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.asoc = new System.Windows.Forms.DataGridViewLinkColumn();
            this.n1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.n2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.n3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codalm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cod_enc_num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grabar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.TabControl1.SuspendLayout();
            this.TabPage1.SuspendLayout();
            this.GroupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw)).BeginInit();
            this.SuspendLayout();
            // 
            // TabControl1
            // 
            this.TabControl1.Controls.Add(this.TabPage1);
            this.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabControl1.Location = new System.Drawing.Point(0, 0);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(931, 508);
            this.TabControl1.TabIndex = 3;
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.btn_salir);
            this.TabPage1.Controls.Add(this.GroupBox8);
            this.TabPage1.Controls.Add(this.dgw);
            this.TabPage1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabPage1.Location = new System.Drawing.Point(4, 23);
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage1.Size = new System.Drawing.Size(923, 481);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "Lista de Vendedores";
            this.TabPage1.UseVisualStyleBackColor = true;
            // 
            // btn_salir
            // 
            this.btn_salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_salir.Font = new System.Drawing.Font("Arial", 8.25F);
            this.btn_salir.Image = ((System.Drawing.Image)(resources.GetObject("btn_salir.Image")));
            this.btn_salir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_salir.Location = new System.Drawing.Point(814, 399);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(74, 26);
            this.btn_salir.TabIndex = 6;
            this.btn_salir.Text = "&Salir";
            this.btn_salir.UseVisualStyleBackColor = true;
            this.btn_salir.Click += new System.EventHandler(this.btn_salir_Click);
            // 
            // GroupBox8
            // 
            this.GroupBox8.Controls.Add(this.btn_sgt);
            this.GroupBox8.Controls.Add(this.btn_buscar);
            this.GroupBox8.Controls.Add(this.ch_ca);
            this.GroupBox8.Controls.Add(this.ch_rs);
            this.GroupBox8.Controls.Add(this.ch_cod);
            this.GroupBox8.Controls.Add(this.txt_letra);
            this.GroupBox8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox8.Location = new System.Drawing.Point(29, 380);
            this.GroupBox8.Name = "GroupBox8";
            this.GroupBox8.Size = new System.Drawing.Size(679, 72);
            this.GroupBox8.TabIndex = 5;
            this.GroupBox8.TabStop = false;
            this.GroupBox8.Text = "Buscado por:";
            // 
            // btn_sgt
            // 
            this.btn_sgt.Enabled = false;
            this.btn_sgt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_sgt.Font = new System.Drawing.Font("Arial", 8.25F);
            this.btn_sgt.Image = ((System.Drawing.Image)(resources.GetObject("btn_sgt.Image")));
            this.btn_sgt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_sgt.Location = new System.Drawing.Point(576, 19);
            this.btn_sgt.Name = "btn_sgt";
            this.btn_sgt.Size = new System.Drawing.Size(64, 26);
            this.btn_sgt.TabIndex = 7;
            this.btn_sgt.Text = "&Sgte.";
            this.btn_sgt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_sgt.UseVisualStyleBackColor = true;
            this.btn_sgt.Click += new System.EventHandler(this.btn_sgt_Click);
            // 
            // btn_buscar
            // 
            this.btn_buscar.Enabled = false;
            this.btn_buscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_buscar.Font = new System.Drawing.Font("Arial", 8.25F);
            this.btn_buscar.Image = ((System.Drawing.Image)(resources.GetObject("btn_buscar.Image")));
            this.btn_buscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_buscar.Location = new System.Drawing.Point(496, 19);
            this.btn_buscar.Name = "btn_buscar";
            this.btn_buscar.Size = new System.Drawing.Size(74, 26);
            this.btn_buscar.TabIndex = 1;
            this.btn_buscar.Text = "&Buscar";
            this.btn_buscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_buscar.UseVisualStyleBackColor = true;
            this.btn_buscar.Click += new System.EventHandler(this.btn_buscar_Click);
            // 
            // ch_ca
            // 
            this.ch_ca.AutoSize = true;
            this.ch_ca.Font = new System.Drawing.Font("Arial", 8.25F);
            this.ch_ca.Location = new System.Drawing.Point(496, 48);
            this.ch_ca.Name = "ch_ca";
            this.ch_ca.Size = new System.Drawing.Size(62, 18);
            this.ch_ca.TabIndex = 6;
            this.ch_ca.Text = "Cadena";
            this.ch_ca.UseVisualStyleBackColor = true;
            this.ch_ca.CheckedChanged += new System.EventHandler(this.ch_ca_CheckedChanged);
            // 
            // ch_rs
            // 
            this.ch_rs.AutoSize = true;
            this.ch_rs.Font = new System.Drawing.Font("Arial", 8.25F);
            this.ch_rs.Location = new System.Drawing.Point(76, 45);
            this.ch_rs.Name = "ch_rs";
            this.ch_rs.Size = new System.Drawing.Size(62, 18);
            this.ch_rs.TabIndex = 3;
            this.ch_rs.Text = "Nombre";
            this.ch_rs.UseVisualStyleBackColor = true;
            this.ch_rs.CheckedChanged += new System.EventHandler(this.ch_rs_CheckedChanged);
            // 
            // ch_cod
            // 
            this.ch_cod.AutoSize = true;
            this.ch_cod.Font = new System.Drawing.Font("Arial", 8.25F);
            this.ch_cod.Location = new System.Drawing.Point(6, 45);
            this.ch_cod.Name = "ch_cod";
            this.ch_cod.Size = new System.Drawing.Size(58, 18);
            this.ch_cod.TabIndex = 2;
            this.ch_cod.Text = "Código";
            this.ch_cod.UseVisualStyleBackColor = true;
            this.ch_cod.CheckedChanged += new System.EventHandler(this.ch_cod_CheckedChanged);
            // 
            // txt_letra
            // 
            this.txt_letra.Font = new System.Drawing.Font("Arial", 8.25F);
            this.txt_letra.Location = new System.Drawing.Point(6, 19);
            this.txt_letra.Name = "txt_letra";
            this.txt_letra.Size = new System.Drawing.Size(438, 20);
            this.txt_letra.TabIndex = 0;
            this.txt_letra.TextChanged += new System.EventHandler(this.txt_letra_TextChanged);
            // 
            // dgw
            // 
            this.dgw.AllowUserToAddRows = false;
            this.dgw.AllowUserToDeleteRows = false;
            this.dgw.AllowUserToOrderColumns = true;
            this.dgw.AllowUserToResizeRows = false;
            this.dgw.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgw.BackgroundColor = System.Drawing.Color.White;
            this.dgw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgw.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cod,
            this.desc,
            this.codpr,
            this.descpro,
            this.asoc,
            this.n1,
            this.n2,
            this.n3,
            this.codalm,
            this.cod_enc_num,
            this.grabar});
            this.dgw.Location = new System.Drawing.Point(16, 15);
            this.dgw.MultiSelect = false;
            this.dgw.Name = "dgw";
            this.dgw.ReadOnly = true;
            this.dgw.RowHeadersWidth = 25;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            this.dgw.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgw.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dgw.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.dgw.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgw.Size = new System.Drawing.Size(891, 345);
            this.dgw.TabIndex = 0;
            this.dgw.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgw_CellContentClick);
            // 
            // cod
            // 
            this.cod.HeaderText = "Codigo";
            this.cod.Name = "cod";
            this.cod.ReadOnly = true;
            this.cod.Width = 60;
            // 
            // desc
            // 
            this.desc.HeaderText = "Nombre";
            this.desc.Name = "desc";
            this.desc.ReadOnly = true;
            this.desc.Width = 300;
            // 
            // codpr
            // 
            this.codpr.HeaderText = "codpr";
            this.codpr.Name = "codpr";
            this.codpr.ReadOnly = true;
            this.codpr.Visible = false;
            // 
            // descpro
            // 
            this.descpro.HeaderText = "Programa";
            this.descpro.Name = "descpro";
            this.descpro.ReadOnly = true;
            // 
            // asoc
            // 
            this.asoc.ActiveLinkColor = System.Drawing.Color.Blue;
            this.asoc.HeaderText = "Asociar";
            this.asoc.Name = "asoc";
            this.asoc.ReadOnly = true;
            this.asoc.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.asoc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.asoc.Text = "Asociar";
            this.asoc.UseColumnTextForLinkValue = true;
            this.asoc.VisitedLinkColor = System.Drawing.Color.Blue;
            this.asoc.Width = 70;
            // 
            // n1
            // 
            this.n1.HeaderText = "Nivel 1";
            this.n1.Name = "n1";
            this.n1.ReadOnly = true;
            this.n1.Width = 65;
            // 
            // n2
            // 
            this.n2.HeaderText = "Nivel 2";
            this.n2.Name = "n2";
            this.n2.ReadOnly = true;
            this.n2.Width = 65;
            // 
            // n3
            // 
            this.n3.HeaderText = "Nivel 3";
            this.n3.Name = "n3";
            this.n3.ReadOnly = true;
            this.n3.Width = 65;
            // 
            // codalm
            // 
            this.codalm.HeaderText = "Alm";
            this.codalm.Name = "codalm";
            this.codalm.ReadOnly = true;
            this.codalm.Width = 50;
            // 
            // cod_enc_num
            // 
            this.cod_enc_num.HeaderText = "Encargado Numeracion";
            this.cod_enc_num.Name = "cod_enc_num";
            this.cod_enc_num.ReadOnly = true;
            this.cod_enc_num.Visible = false;
            this.cod_enc_num.Width = 66;
            // 
            // grabar
            // 
            this.grabar.HeaderText = "Grabar";
            this.grabar.Name = "grabar";
            this.grabar.ReadOnly = true;
            this.grabar.Text = "Grabar";
            this.grabar.UseColumnTextForButtonValue = true;
            this.grabar.Width = 60;
            // 
            // RELACION_EQ_VENTA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 508);
            this.Controls.Add(this.TabControl1);
            this.Name = "RELACION_EQ_VENTA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RELACIONAR EQUIPO DE VENTA";
            this.Load += new System.EventHandler(this.RELACION_EQ_VENTA_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RELACION_EQ_VENTA_KeyDown);
            this.TabControl1.ResumeLayout(false);
            this.TabPage1.ResumeLayout(false);
            this.GroupBox8.ResumeLayout(false);
            this.GroupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TabControl TabControl1;
        internal System.Windows.Forms.TabPage TabPage1;
        internal System.Windows.Forms.GroupBox GroupBox8;
        internal System.Windows.Forms.Button btn_sgt;
        internal System.Windows.Forms.Button btn_buscar;
        internal System.Windows.Forms.RadioButton ch_ca;
        internal System.Windows.Forms.RadioButton ch_rs;
        internal System.Windows.Forms.RadioButton ch_cod;
        internal System.Windows.Forms.TextBox txt_letra;
        internal System.Windows.Forms.DataGridView dgw;
        internal System.Windows.Forms.Button btn_salir;
        private System.Windows.Forms.DataGridViewTextBoxColumn cod;
        private System.Windows.Forms.DataGridViewTextBoxColumn desc;
        private System.Windows.Forms.DataGridViewTextBoxColumn codpr;
        private System.Windows.Forms.DataGridViewTextBoxColumn descpro;
        private System.Windows.Forms.DataGridViewLinkColumn asoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn n1;
        private System.Windows.Forms.DataGridViewTextBoxColumn n2;
        private System.Windows.Forms.DataGridViewTextBoxColumn n3;
        private System.Windows.Forms.DataGridViewTextBoxColumn codalm;
        private System.Windows.Forms.DataGridViewTextBoxColumn cod_enc_num;
        private System.Windows.Forms.DataGridViewButtonColumn grabar;
    }
}