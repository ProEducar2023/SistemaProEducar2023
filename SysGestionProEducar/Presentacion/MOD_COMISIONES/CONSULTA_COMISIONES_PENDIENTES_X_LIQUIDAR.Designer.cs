namespace Presentacion.MOD_COMISIONES
{
    partial class CONSULTA_COMISIONES_PENDIENTES_X_LIQUIDAR
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CONSULTA_COMISIONES_PENDIENTES_X_LIQUIDAR));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbo_prog = new System.Windows.Forms.ComboBox();
            this.cbo_tipo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_consulta1 = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.cbo_año = new System.Windows.Forms.ComboBox();
            this.cbo_mes = new System.Windows.Forms.ComboBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.GroupBox8 = new System.Windows.Forms.GroupBox();
            this.btn_sgt = new System.Windows.Forms.Button();
            this.ch_nc = new System.Windows.Forms.RadioButton();
            this.btn_buscar = new System.Windows.Forms.Button();
            this.ch_ca = new System.Windows.Forms.RadioButton();
            this.ch_rs = new System.Windows.Forms.RadioButton();
            this.ch_cod = new System.Windows.Forms.RadioButton();
            this.txt_letra = new System.Windows.Forms.TextBox();
            this.dgw1 = new System.Windows.Forms.DataGridView();
            this.NRO_PRESUPUESTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COD_VENDEDOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VEND = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FECHA_PRE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FECHA_APROB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COD_PER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESC_PER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ST_APROB = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ST_PRE_APROB = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.COD_PROGRAMA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TIPO_VTA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupBox1.SuspendLayout();
            this.GroupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw1)).BeginInit();
            this.SuspendLayout();
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.label2);
            this.GroupBox1.Controls.Add(this.cbo_prog);
            this.GroupBox1.Controls.Add(this.cbo_tipo);
            this.GroupBox1.Controls.Add(this.label4);
            this.GroupBox1.Controls.Add(this.btn_consulta1);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Controls.Add(this.cbo_año);
            this.GroupBox1.Controls.Add(this.cbo_mes);
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox1.Location = new System.Drawing.Point(138, 0);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(662, 77);
            this.GroupBox1.TabIndex = 39;
            this.GroupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(157, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 14);
            this.label2.TabIndex = 58;
            this.label2.Text = "Programa";
            // 
            // cbo_prog
            // 
            this.cbo_prog.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_prog.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_prog.FormattingEnabled = true;
            this.cbo_prog.Items.AddRange(new object[] {
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
            this.cbo_prog.Location = new System.Drawing.Point(220, 16);
            this.cbo_prog.Name = "cbo_prog";
            this.cbo_prog.Size = new System.Drawing.Size(140, 22);
            this.cbo_prog.TabIndex = 6;
            // 
            // cbo_tipo
            // 
            this.cbo_tipo.BackColor = System.Drawing.Color.White;
            this.cbo_tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_tipo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_tipo.FormattingEnabled = true;
            this.cbo_tipo.Location = new System.Drawing.Point(41, 15);
            this.cbo_tipo.Name = "cbo_tipo";
            this.cbo_tipo.Size = new System.Drawing.Size(107, 22);
            this.cbo_tipo.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 14);
            this.label4.TabIndex = 57;
            this.label4.Text = "Tipo";
            // 
            // btn_consulta1
            // 
            this.btn_consulta1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_consulta1.Image = ((System.Drawing.Image)(resources.GetObject("btn_consulta1.Image")));
            this.btn_consulta1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_consulta1.Location = new System.Drawing.Point(282, 44);
            this.btn_consulta1.Name = "btn_consulta1";
            this.btn_consulta1.Size = new System.Drawing.Size(77, 27);
            this.btn_consulta1.TabIndex = 10;
            this.btn_consulta1.Text = "&Buscar";
            this.btn_consulta1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_consulta1.UseVisualStyleBackColor = true;
            this.btn_consulta1.Click += new System.EventHandler(this.btn_consulta1_Click);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(537, 18);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(27, 14);
            this.Label1.TabIndex = 54;
            this.Label1.Text = "Año";
            // 
            // cbo_año
            // 
            this.cbo_año.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_año.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_año.FormattingEnabled = true;
            this.cbo_año.Items.AddRange(new object[] {
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
            this.cbo_año.Location = new System.Drawing.Point(567, 15);
            this.cbo_año.Name = "cbo_año";
            this.cbo_año.Size = new System.Drawing.Size(82, 22);
            this.cbo_año.TabIndex = 8;
            // 
            // cbo_mes
            // 
            this.cbo_mes.BackColor = System.Drawing.Color.White;
            this.cbo_mes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_mes.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_mes.FormattingEnabled = true;
            this.cbo_mes.Location = new System.Drawing.Point(410, 14);
            this.cbo_mes.Name = "cbo_mes";
            this.cbo_mes.Size = new System.Drawing.Size(107, 22);
            this.cbo_mes.TabIndex = 7;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(378, 18);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(27, 14);
            this.Label3.TabIndex = 51;
            this.Label3.Text = "Mes";
            // 
            // btnSalir
            // 
            this.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(818, 595);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(84, 27);
            this.btnSalir.TabIndex = 45;
            this.btnSalir.Text = "&SALIR";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // GroupBox8
            // 
            this.GroupBox8.Controls.Add(this.btn_sgt);
            this.GroupBox8.Controls.Add(this.ch_nc);
            this.GroupBox8.Controls.Add(this.btn_buscar);
            this.GroupBox8.Controls.Add(this.ch_ca);
            this.GroupBox8.Controls.Add(this.ch_rs);
            this.GroupBox8.Controls.Add(this.ch_cod);
            this.GroupBox8.Controls.Add(this.txt_letra);
            this.GroupBox8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox8.Location = new System.Drawing.Point(26, 564);
            this.GroupBox8.Name = "GroupBox8";
            this.GroupBox8.Size = new System.Drawing.Size(639, 61);
            this.GroupBox8.TabIndex = 46;
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
            this.btn_sgt.Location = new System.Drawing.Point(531, 11);
            this.btn_sgt.Name = "btn_sgt";
            this.btn_sgt.Size = new System.Drawing.Size(64, 26);
            this.btn_sgt.TabIndex = 7;
            this.btn_sgt.Text = "&Sgte.";
            this.btn_sgt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_sgt.UseVisualStyleBackColor = true;
            this.btn_sgt.Click += new System.EventHandler(this.btn_sgt_Click);
            // 
            // ch_nc
            // 
            this.ch_nc.AutoSize = true;
            this.ch_nc.Font = new System.Drawing.Font("Arial", 8.25F);
            this.ch_nc.Location = new System.Drawing.Point(207, 40);
            this.ch_nc.Name = "ch_nc";
            this.ch_nc.Size = new System.Drawing.Size(72, 18);
            this.ch_nc.TabIndex = 4;
            this.ch_nc.Text = "Vendedor";
            this.ch_nc.UseVisualStyleBackColor = true;
            this.ch_nc.CheckedChanged += new System.EventHandler(this.ch_nc_CheckedChanged);
            // 
            // btn_buscar
            // 
            this.btn_buscar.Enabled = false;
            this.btn_buscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_buscar.Font = new System.Drawing.Font("Arial", 8.25F);
            this.btn_buscar.Image = ((System.Drawing.Image)(resources.GetObject("btn_buscar.Image")));
            this.btn_buscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_buscar.Location = new System.Drawing.Point(451, 11);
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
            this.ch_ca.Location = new System.Drawing.Point(451, 40);
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
            this.ch_rs.Location = new System.Drawing.Point(117, 40);
            this.ch_rs.Name = "ch_rs";
            this.ch_rs.Size = new System.Drawing.Size(57, 18);
            this.ch_rs.TabIndex = 3;
            this.ch_rs.Text = "Cliente";
            this.ch_rs.UseVisualStyleBackColor = true;
            this.ch_rs.CheckedChanged += new System.EventHandler(this.ch_rs_CheckedChanged);
            // 
            // ch_cod
            // 
            this.ch_cod.AutoSize = true;
            this.ch_cod.Font = new System.Drawing.Font("Arial", 8.25F);
            this.ch_cod.Location = new System.Drawing.Point(14, 40);
            this.ch_cod.Name = "ch_cod";
            this.ch_cod.Size = new System.Drawing.Size(66, 18);
            this.ch_cod.TabIndex = 2;
            this.ch_cod.Text = "Contrato";
            this.ch_cod.UseVisualStyleBackColor = true;
            this.ch_cod.CheckedChanged += new System.EventHandler(this.ch_cod_CheckedChanged);
            // 
            // txt_letra
            // 
            this.txt_letra.Font = new System.Drawing.Font("Arial", 8.25F);
            this.txt_letra.Location = new System.Drawing.Point(14, 14);
            this.txt_letra.Name = "txt_letra";
            this.txt_letra.Size = new System.Drawing.Size(414, 20);
            this.txt_letra.TabIndex = 0;
            this.txt_letra.TextChanged += new System.EventHandler(this.txt_letra_TextChanged);
            // 
            // dgw1
            // 
            this.dgw1.AllowUserToAddRows = false;
            this.dgw1.AllowUserToDeleteRows = false;
            this.dgw1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dgw1.BackgroundColor = System.Drawing.Color.White;
            this.dgw1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NRO_PRESUPUESTO,
            this.COD_VENDEDOR,
            this.VEND,
            this.FECHA_PRE,
            this.FECHA_APROB,
            this.COD_PER,
            this.DESC_PER,
            this.ST_APROB,
            this.ST_PRE_APROB,
            this.COD_PROGRAMA,
            this.TIPO_VTA});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgw1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgw1.Location = new System.Drawing.Point(26, 82);
            this.dgw1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dgw1.MultiSelect = false;
            this.dgw1.Name = "dgw1";
            this.dgw1.RowHeadersWidth = 25;
            this.dgw1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dgw1.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.dgw1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgw1.Size = new System.Drawing.Size(876, 482);
            this.dgw1.TabIndex = 47;
            // 
            // NRO_PRESUPUESTO
            // 
            this.NRO_PRESUPUESTO.HeaderText = "Nª Contrato";
            this.NRO_PRESUPUESTO.Name = "NRO_PRESUPUESTO";
            this.NRO_PRESUPUESTO.ReadOnly = true;
            // 
            // COD_VENDEDOR
            // 
            this.COD_VENDEDOR.HeaderText = "COD_VENDEDOR";
            this.COD_VENDEDOR.Name = "COD_VENDEDOR";
            this.COD_VENDEDOR.ReadOnly = true;
            this.COD_VENDEDOR.Visible = false;
            // 
            // VEND
            // 
            this.VEND.HeaderText = "Vendedor";
            this.VEND.Name = "VEND";
            this.VEND.ReadOnly = true;
            this.VEND.Width = 230;
            // 
            // FECHA_PRE
            // 
            this.FECHA_PRE.HeaderText = "F Contrato";
            this.FECHA_PRE.Name = "FECHA_PRE";
            this.FECHA_PRE.ReadOnly = true;
            this.FECHA_PRE.Width = 80;
            // 
            // FECHA_APROB
            // 
            this.FECHA_APROB.HeaderText = "F Aprob";
            this.FECHA_APROB.Name = "FECHA_APROB";
            this.FECHA_APROB.ReadOnly = true;
            this.FECHA_APROB.Width = 80;
            // 
            // COD_PER
            // 
            this.COD_PER.HeaderText = "COD_PER";
            this.COD_PER.Name = "COD_PER";
            this.COD_PER.ReadOnly = true;
            this.COD_PER.Visible = false;
            // 
            // DESC_PER
            // 
            this.DESC_PER.HeaderText = "Cliente";
            this.DESC_PER.Name = "DESC_PER";
            this.DESC_PER.ReadOnly = true;
            this.DESC_PER.Width = 230;
            // 
            // ST_APROB
            // 
            this.ST_APROB.HeaderText = "Aprob";
            this.ST_APROB.Name = "ST_APROB";
            this.ST_APROB.ReadOnly = true;
            this.ST_APROB.Width = 50;
            // 
            // ST_PRE_APROB
            // 
            this.ST_PRE_APROB.HeaderText = "Pre-Apr";
            this.ST_PRE_APROB.Name = "ST_PRE_APROB";
            this.ST_PRE_APROB.ReadOnly = true;
            this.ST_PRE_APROB.Width = 50;
            // 
            // COD_PROGRAMA
            // 
            this.COD_PROGRAMA.HeaderText = "COD_PROGRAMA";
            this.COD_PROGRAMA.Name = "COD_PROGRAMA";
            this.COD_PROGRAMA.Visible = false;
            // 
            // TIPO_VTA
            // 
            this.TIPO_VTA.HeaderText = "TIPO_VTA";
            this.TIPO_VTA.Name = "TIPO_VTA";
            this.TIPO_VTA.Visible = false;
            // 
            // CONSULTA_COMISIONES_PENDIENTES_X_LIQUIDAR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 628);
            this.Controls.Add(this.dgw1);
            this.Controls.Add(this.GroupBox8);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.GroupBox1);
            this.Name = "CONSULTA_COMISIONES_PENDIENTES_X_LIQUIDAR";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta Comisiones Pendiente x Comisionar";
            this.Load += new System.EventHandler(this.CONSULTA_COMISIONES_PENDIENTES_X_LIQUIDAR_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CONSULTA_COMISIONES_PENDIENTES_X_LIQUIDAR_KeyDown);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.GroupBox8.ResumeLayout(false);
            this.GroupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Button btn_consulta1;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.ComboBox cbo_año;
        internal System.Windows.Forms.ComboBox cbo_mes;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.ComboBox cbo_prog;
        internal System.Windows.Forms.ComboBox cbo_tipo;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Button btnSalir;
        internal System.Windows.Forms.GroupBox GroupBox8;
        internal System.Windows.Forms.Button btn_sgt;
        internal System.Windows.Forms.RadioButton ch_nc;
        internal System.Windows.Forms.Button btn_buscar;
        internal System.Windows.Forms.RadioButton ch_ca;
        internal System.Windows.Forms.RadioButton ch_rs;
        internal System.Windows.Forms.RadioButton ch_cod;
        internal System.Windows.Forms.TextBox txt_letra;
        internal System.Windows.Forms.DataGridView dgw1;
        private System.Windows.Forms.DataGridViewTextBoxColumn NRO_PRESUPUESTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn COD_VENDEDOR;
        private System.Windows.Forms.DataGridViewTextBoxColumn VEND;
        private System.Windows.Forms.DataGridViewTextBoxColumn FECHA_PRE;
        private System.Windows.Forms.DataGridViewTextBoxColumn FECHA_APROB;
        private System.Windows.Forms.DataGridViewTextBoxColumn COD_PER;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESC_PER;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ST_APROB;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ST_PRE_APROB;
        private System.Windows.Forms.DataGridViewTextBoxColumn COD_PROGRAMA;
        private System.Windows.Forms.DataGridViewTextBoxColumn TIPO_VTA;
    }
}