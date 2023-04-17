namespace Presentacion.MOD_CXC.Reportes.FormRep
{
    partial class PLANILLA_COBRANZA_INTERNA_ENVIADA_DETALLE
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PLANILLA_COBRANZA_INTERNA_ENVIADA_DETALLE));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chk_Todos = new System.Windows.Forms.CheckBox();
            this.cbo_institucion = new System.Windows.Forms.ComboBox();
            this.Label29 = new System.Windows.Forms.Label();
            this.dgw_pto_cob = new System.Windows.Forms.DataGridView();
            this.NRO_PLANILLA_COB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESC_PTO_COB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.X = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btn_ok = new System.Windows.Forms.Button();
            this.cbo_año = new System.Windows.Forms.ComboBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.cbo_mes = new System.Windows.Forms.ComboBox();
            this.Label7 = new System.Windows.Forms.Label();
            this.cbo_canal_dscto = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gb1 = new System.Windows.Forms.GroupBox();
            this.btn_impresion = new System.Windows.Forms.Button();
            this.btn_pantalla = new System.Windows.Forms.Button();
            this.btn_salir = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw_pto_cob)).BeginInit();
            this.gb1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chk_Todos);
            this.groupBox1.Controls.Add(this.cbo_institucion);
            this.groupBox1.Controls.Add(this.Label29);
            this.groupBox1.Controls.Add(this.dgw_pto_cob);
            this.groupBox1.Controls.Add(this.btn_ok);
            this.groupBox1.Controls.Add(this.cbo_año);
            this.groupBox1.Controls.Add(this.Label8);
            this.groupBox1.Controls.Add(this.cbo_mes);
            this.groupBox1.Controls.Add(this.Label7);
            this.groupBox1.Controls.Add(this.cbo_canal_dscto);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(495, 332);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // chk_Todos
            // 
            this.chk_Todos.AutoSize = true;
            this.chk_Todos.Location = new System.Drawing.Point(426, 73);
            this.chk_Todos.Name = "chk_Todos";
            this.chk_Todos.Size = new System.Drawing.Size(56, 17);
            this.chk_Todos.TabIndex = 21;
            this.chk_Todos.Text = "Todos";
            this.chk_Todos.UseVisualStyleBackColor = true;
            this.chk_Todos.CheckedChanged += new System.EventHandler(this.chk_Todos_CheckedChanged);
            // 
            // cbo_institucion
            // 
            this.cbo_institucion.BackColor = System.Drawing.Color.White;
            this.cbo_institucion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_institucion.FormattingEnabled = true;
            this.cbo_institucion.Location = new System.Drawing.Point(89, 14);
            this.cbo_institucion.Name = "cbo_institucion";
            this.cbo_institucion.Size = new System.Drawing.Size(393, 21);
            this.cbo_institucion.TabIndex = 59;
            // 
            // Label29
            // 
            this.Label29.AutoSize = true;
            this.Label29.Location = new System.Drawing.Point(10, 19);
            this.Label29.Name = "Label29";
            this.Label29.Size = new System.Drawing.Size(55, 13);
            this.Label29.TabIndex = 60;
            this.Label29.Text = "Institucion";
            // 
            // dgw_pto_cob
            // 
            this.dgw_pto_cob.AllowUserToAddRows = false;
            this.dgw_pto_cob.AllowUserToDeleteRows = false;
            this.dgw_pto_cob.BackgroundColor = System.Drawing.Color.White;
            this.dgw_pto_cob.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgw_pto_cob.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NRO_PLANILLA_COB,
            this.DESC_PTO_COB,
            this.X});
            this.dgw_pto_cob.Location = new System.Drawing.Point(13, 99);
            this.dgw_pto_cob.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dgw_pto_cob.MultiSelect = false;
            this.dgw_pto_cob.Name = "dgw_pto_cob";
            this.dgw_pto_cob.RowHeadersWidth = 20;
            this.dgw_pto_cob.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dgw_pto_cob.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.dgw_pto_cob.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgw_pto_cob.Size = new System.Drawing.Size(469, 227);
            this.dgw_pto_cob.TabIndex = 58;
            // 
            // NRO_PLANILLA_COB
            // 
            this.NRO_PLANILLA_COB.HeaderText = "Planilla";
            this.NRO_PLANILLA_COB.Name = "NRO_PLANILLA_COB";
            this.NRO_PLANILLA_COB.ReadOnly = true;
            this.NRO_PLANILLA_COB.Width = 75;
            // 
            // DESC_PTO_COB
            // 
            this.DESC_PTO_COB.HeaderText = "Punto de Cobranza";
            this.DESC_PTO_COB.Name = "DESC_PTO_COB";
            this.DESC_PTO_COB.ReadOnly = true;
            this.DESC_PTO_COB.Width = 315;
            // 
            // X
            // 
            this.X.HeaderText = "X";
            this.X.Name = "X";
            this.X.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.X.Width = 30;
            // 
            // btn_ok
            // 
            this.btn_ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ok.Image = ((System.Drawing.Image)(resources.GetObject("btn_ok.Image")));
            this.btn_ok.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_ok.Location = new System.Drawing.Point(351, 69);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(64, 24);
            this.btn_ok.TabIndex = 57;
            this.btn_ok.Text = "&OK";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // cbo_año
            // 
            this.cbo_año.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_año.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_año.FormattingEnabled = true;
            this.cbo_año.Location = new System.Drawing.Point(264, 71);
            this.cbo_año.Name = "cbo_año";
            this.cbo_año.Size = new System.Drawing.Size(68, 22);
            this.cbo_año.TabIndex = 45;
            this.cbo_año.TabStop = false;
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label8.Location = new System.Drawing.Point(227, 73);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(27, 14);
            this.Label8.TabIndex = 48;
            this.Label8.Text = "Año";
            // 
            // cbo_mes
            // 
            this.cbo_mes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_mes.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_mes.FormattingEnabled = true;
            this.cbo_mes.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12"});
            this.cbo_mes.Location = new System.Drawing.Point(88, 71);
            this.cbo_mes.Name = "cbo_mes";
            this.cbo_mes.Size = new System.Drawing.Size(121, 22);
            this.cbo_mes.TabIndex = 46;
            this.cbo_mes.TabStop = false;
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label7.Location = new System.Drawing.Point(10, 74);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(30, 14);
            this.Label7.TabIndex = 47;
            this.Label7.Text = "Mes ";
            // 
            // cbo_canal_dscto
            // 
            this.cbo_canal_dscto.BackColor = System.Drawing.Color.White;
            this.cbo_canal_dscto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_canal_dscto.FormattingEnabled = true;
            this.cbo_canal_dscto.Location = new System.Drawing.Point(88, 42);
            this.cbo_canal_dscto.Name = "cbo_canal_dscto";
            this.cbo_canal_dscto.Size = new System.Drawing.Size(394, 21);
            this.cbo_canal_dscto.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 44;
            this.label1.Text = "Canal de Dscto";
            // 
            // gb1
            // 
            this.gb1.BackColor = System.Drawing.Color.White;
            this.gb1.Controls.Add(this.btn_impresion);
            this.gb1.Controls.Add(this.btn_pantalla);
            this.gb1.Controls.Add(this.btn_salir);
            this.gb1.Location = new System.Drawing.Point(12, 334);
            this.gb1.Name = "gb1";
            this.gb1.Size = new System.Drawing.Size(495, 54);
            this.gb1.TabIndex = 7;
            this.gb1.TabStop = false;
            // 
            // btn_impresion
            // 
            this.btn_impresion.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_impresion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_impresion.Image = ((System.Drawing.Image)(resources.GetObject("btn_impresion.Image")));
            this.btn_impresion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_impresion.Location = new System.Drawing.Point(207, 15);
            this.btn_impresion.Name = "btn_impresion";
            this.btn_impresion.Size = new System.Drawing.Size(77, 27);
            this.btn_impresion.TabIndex = 17;
            this.btn_impresion.Text = "&Imprimir";
            this.btn_impresion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_impresion.UseVisualStyleBackColor = false;
            // 
            // btn_pantalla
            // 
            this.btn_pantalla.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_pantalla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_pantalla.Image = ((System.Drawing.Image)(resources.GetObject("btn_pantalla.Image")));
            this.btn_pantalla.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_pantalla.Location = new System.Drawing.Point(114, 15);
            this.btn_pantalla.Name = "btn_pantalla";
            this.btn_pantalla.Size = new System.Drawing.Size(77, 27);
            this.btn_pantalla.TabIndex = 15;
            this.btn_pantalla.Text = "&Pantalla";
            this.btn_pantalla.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_pantalla.UseVisualStyleBackColor = false;
            this.btn_pantalla.Click += new System.EventHandler(this.btn_pantalla_Click);
            // 
            // btn_salir
            // 
            this.btn_salir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_salir.Image = ((System.Drawing.Image)(resources.GetObject("btn_salir.Image")));
            this.btn_salir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_salir.Location = new System.Drawing.Point(301, 15);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(75, 26);
            this.btn_salir.TabIndex = 19;
            this.btn_salir.Text = "&Salir";
            this.btn_salir.UseVisualStyleBackColor = true;
            // 
            // PLANILLA_COBRANZA_INTERNA_ENVIADA_DETALLE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 393);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gb1);
            this.Name = "PLANILLA_COBRANZA_INTERNA_ENVIADA_DETALLE";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Planilla de Cobranza Interna ";
            this.Load += new System.EventHandler(this.PLANILLA_COBRANZA_INTERNA_ENVIADA_DETALLE_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw_pto_cob)).EndInit();
            this.gb1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.ComboBox cbo_canal_dscto;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.GroupBox gb1;
        internal System.Windows.Forms.Button btn_impresion;
        internal System.Windows.Forms.Button btn_pantalla;
        internal System.Windows.Forms.Button btn_salir;
        internal System.Windows.Forms.ComboBox cbo_año;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.ComboBox cbo_mes;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.Button btn_ok;
        internal System.Windows.Forms.DataGridView dgw_pto_cob;
        internal System.Windows.Forms.ComboBox cbo_institucion;
        internal System.Windows.Forms.Label Label29;
        private System.Windows.Forms.CheckBox chk_Todos;
        private System.Windows.Forms.DataGridViewTextBoxColumn NRO_PLANILLA_COB;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESC_PTO_COB;
        private System.Windows.Forms.DataGridViewCheckBoxColumn X;
    }
}