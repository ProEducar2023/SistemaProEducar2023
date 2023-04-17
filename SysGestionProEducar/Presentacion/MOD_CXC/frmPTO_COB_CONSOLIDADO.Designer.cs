namespace Presentacion.MOD_CXC
{
    partial class frmPTO_COB_CONSOLIDADO
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPTO_COB_CONSOLIDADO));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgw = new System.Windows.Forms.DataGridView();
            this.cod_pto_cob_cons = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desc_pto_cob_cons = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.op = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cod_sucursal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cod_institucion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cod_canal_dscto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_nuevo = new System.Windows.Forms.Button();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbo_programa = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbo_tipo_planilla = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbo_institucion = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_ver = new System.Windows.Forms.Button();
            this.cbo_sectorista = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbo_canaldscto = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgw);
            this.groupBox1.Location = new System.Drawing.Point(25, 118);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(542, 329);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // dgw
            // 
            this.dgw.AllowUserToAddRows = false;
            this.dgw.AllowUserToDeleteRows = false;
            this.dgw.AllowUserToOrderColumns = true;
            this.dgw.AllowUserToResizeRows = false;
            this.dgw.BackgroundColor = System.Drawing.Color.White;
            this.dgw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgw.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cod_pto_cob_cons,
            this.desc_pto_cob_cons,
            this.op,
            this.cod_sucursal,
            this.cod_institucion,
            this.cod_canal_dscto,
            this.flag});
            this.dgw.Location = new System.Drawing.Point(13, 14);
            this.dgw.MultiSelect = false;
            this.dgw.Name = "dgw";
            this.dgw.RowHeadersWidth = 25;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            this.dgw.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgw.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dgw.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.dgw.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgw.Size = new System.Drawing.Size(516, 309);
            this.dgw.TabIndex = 1;
            this.dgw.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgw_CurrentCellDirtyStateChanged);
            // 
            // cod_pto_cob_cons
            // 
            this.cod_pto_cob_cons.HeaderText = "Codigo";
            this.cod_pto_cob_cons.Name = "cod_pto_cob_cons";
            this.cod_pto_cob_cons.ReadOnly = true;
            this.cod_pto_cob_cons.Width = 70;
            // 
            // desc_pto_cob_cons
            // 
            this.desc_pto_cob_cons.HeaderText = "Descripcion";
            this.desc_pto_cob_cons.Name = "desc_pto_cob_cons";
            this.desc_pto_cob_cons.ReadOnly = true;
            this.desc_pto_cob_cons.Width = 350;
            // 
            // op
            // 
            this.op.HeaderText = "X";
            this.op.Name = "op";
            this.op.Width = 40;
            // 
            // cod_sucursal
            // 
            this.cod_sucursal.HeaderText = "cod_suc";
            this.cod_sucursal.Name = "cod_sucursal";
            this.cod_sucursal.Visible = false;
            // 
            // cod_institucion
            // 
            this.cod_institucion.HeaderText = "cod_ins";
            this.cod_institucion.Name = "cod_institucion";
            this.cod_institucion.Visible = false;
            // 
            // cod_canal_dscto
            // 
            this.cod_canal_dscto.HeaderText = "cod_can_dscto";
            this.cod_canal_dscto.Name = "cod_canal_dscto";
            this.cod_canal_dscto.Visible = false;
            // 
            // flag
            // 
            this.flag.HeaderText = "flag";
            this.flag.Name = "flag";
            this.flag.Visible = false;
            // 
            // btn_nuevo
            // 
            this.btn_nuevo.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_nuevo.Image = ((System.Drawing.Image)(resources.GetObject("btn_nuevo.Image")));
            this.btn_nuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_nuevo.Location = new System.Drawing.Point(402, 448);
            this.btn_nuevo.Name = "btn_nuevo";
            this.btn_nuevo.Size = new System.Drawing.Size(77, 27);
            this.btn_nuevo.TabIndex = 2;
            this.btn_nuevo.Text = "&Aceptar";
            this.btn_nuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_nuevo.UseVisualStyleBackColor = true;
            this.btn_nuevo.Click += new System.EventHandler(this.btn_nuevo_Click);
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancelar.Image = ((System.Drawing.Image)(resources.GetObject("btn_cancelar.Image")));
            this.btn_cancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_cancelar.Location = new System.Drawing.Point(491, 448);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(77, 27);
            this.btn_cancelar.TabIndex = 23;
            this.btn_cancelar.Text = "&Cancelar";
            this.btn_cancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_cancelar.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbo_programa);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cbo_tipo_planilla);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cbo_institucion);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btn_ver);
            this.groupBox2.Controls.Add(this.cbo_sectorista);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cbo_canaldscto);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Location = new System.Drawing.Point(25, -2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(542, 114);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            // 
            // cbo_programa
            // 
            this.cbo_programa.BackColor = System.Drawing.Color.White;
            this.cbo_programa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_programa.FormattingEnabled = true;
            this.cbo_programa.Location = new System.Drawing.Point(340, 86);
            this.cbo_programa.Name = "cbo_programa";
            this.cbo_programa.Size = new System.Drawing.Size(177, 21);
            this.cbo_programa.TabIndex = 39;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(284, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 40;
            this.label4.Text = "Programa";
            // 
            // cbo_tipo_planilla
            // 
            this.cbo_tipo_planilla.BackColor = System.Drawing.Color.White;
            this.cbo_tipo_planilla.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_tipo_planilla.FormattingEnabled = true;
            this.cbo_tipo_planilla.Location = new System.Drawing.Point(81, 86);
            this.cbo_tipo_planilla.Name = "cbo_tipo_planilla";
            this.cbo_tipo_planilla.Size = new System.Drawing.Size(177, 21);
            this.cbo_tipo_planilla.TabIndex = 37;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 38;
            this.label3.Text = "Tipo Venta";
            // 
            // cbo_institucion
            // 
            this.cbo_institucion.BackColor = System.Drawing.Color.White;
            this.cbo_institucion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_institucion.FormattingEnabled = true;
            this.cbo_institucion.Location = new System.Drawing.Point(81, 10);
            this.cbo_institucion.Name = "cbo_institucion";
            this.cbo_institucion.Size = new System.Drawing.Size(359, 21);
            this.cbo_institucion.TabIndex = 35;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 36;
            this.label2.Text = "Institucion";
            // 
            // btn_ver
            // 
            this.btn_ver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ver.Image = ((System.Drawing.Image)(resources.GetObject("btn_ver.Image")));
            this.btn_ver.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_ver.Location = new System.Drawing.Point(467, 55);
            this.btn_ver.Name = "btn_ver";
            this.btn_ver.Size = new System.Drawing.Size(50, 27);
            this.btn_ver.TabIndex = 34;
            this.btn_ver.Text = "&Ver";
            this.btn_ver.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_ver.UseVisualStyleBackColor = true;
            this.btn_ver.Click += new System.EventHandler(this.btn_ver_Click);
            // 
            // cbo_sectorista
            // 
            this.cbo_sectorista.BackColor = System.Drawing.Color.White;
            this.cbo_sectorista.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_sectorista.FormattingEnabled = true;
            this.cbo_sectorista.Location = new System.Drawing.Point(81, 35);
            this.cbo_sectorista.Name = "cbo_sectorista";
            this.cbo_sectorista.Size = new System.Drawing.Size(359, 21);
            this.cbo_sectorista.TabIndex = 32;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "Sectorista";
            // 
            // cbo_canaldscto
            // 
            this.cbo_canaldscto.BackColor = System.Drawing.Color.White;
            this.cbo_canaldscto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_canaldscto.FormattingEnabled = true;
            this.cbo_canaldscto.Location = new System.Drawing.Point(81, 61);
            this.cbo_canaldscto.Name = "cbo_canaldscto";
            this.cbo_canaldscto.Size = new System.Drawing.Size(359, 21);
            this.cbo_canaldscto.TabIndex = 30;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(12, 66);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(65, 13);
            this.label15.TabIndex = 31;
            this.label15.Text = "Canal Dscto";
            // 
            // frmPTO_COB_CONSOLIDADO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 483);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btn_cancelar);
            this.Controls.Add(this.btn_nuevo);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmPTO_COB_CONSOLIDADO";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Puntos de Cobranza Consolidado";
            this.Load += new System.EventHandler(this.frmPTO_COB_CONSOLIDADO_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgw)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.DataGridView dgw;
        internal System.Windows.Forms.Button btn_nuevo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cod_pto_cob_cons;
        private System.Windows.Forms.DataGridViewTextBoxColumn desc_pto_cob_cons;
        private System.Windows.Forms.DataGridViewCheckBoxColumn op;
        private System.Windows.Forms.DataGridViewTextBoxColumn cod_sucursal;
        private System.Windows.Forms.DataGridViewTextBoxColumn cod_institucion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cod_canal_dscto;
        private System.Windows.Forms.DataGridViewTextBoxColumn flag;
        internal System.Windows.Forms.Button btn_cancelar;
        private System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.Button btn_ver;
        internal System.Windows.Forms.ComboBox cbo_sectorista;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.ComboBox cbo_canaldscto;
        internal System.Windows.Forms.Label label15;
        internal System.Windows.Forms.ComboBox cbo_institucion;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.ComboBox cbo_tipo_planilla;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.ComboBox cbo_programa;
        internal System.Windows.Forms.Label label4;
    }
}