namespace Presentacion.MOD_COMISIONES
{
    partial class CONSULTA_COMISIONES_X_PERSONA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CONSULTA_COMISIONES_X_PERSONA));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_buscar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cboPersona = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboNivel = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboPrograma = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgw1 = new System.Windows.Forms.DataGridView();
            this.SUPERIOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VENDEDOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESC_TIPO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COD_PER_SUP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CUOTA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IMPORTE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_buscar);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cboPersona);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cboNivel);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cboPrograma);
            this.groupBox1.Location = new System.Drawing.Point(12, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(910, 84);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btn_buscar
            // 
            this.btn_buscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_buscar.Font = new System.Drawing.Font("Arial", 8.25F);
            this.btn_buscar.Image = ((System.Drawing.Image)(resources.GetObject("btn_buscar.Image")));
            this.btn_buscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_buscar.Location = new System.Drawing.Point(556, 46);
            this.btn_buscar.Name = "btn_buscar";
            this.btn_buscar.Size = new System.Drawing.Size(74, 26);
            this.btn_buscar.TabIndex = 26;
            this.btn_buscar.Text = "&Buscar";
            this.btn_buscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_buscar.UseVisualStyleBackColor = true;
            this.btn_buscar.Click += new System.EventHandler(this.btn_buscar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 49);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Persona";
            // 
            // cboPersona
            // 
            this.cboPersona.BackColor = System.Drawing.Color.White;
            this.cboPersona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPersona.FormattingEnabled = true;
            this.cboPersona.Location = new System.Drawing.Point(78, 46);
            this.cboPersona.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cboPersona.Name = "cboPersona";
            this.cboPersona.Size = new System.Drawing.Size(337, 21);
            this.cboPersona.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(375, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Nivel";
            // 
            // cboNivel
            // 
            this.cboNivel.BackColor = System.Drawing.Color.White;
            this.cboNivel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNivel.FormattingEnabled = true;
            this.cboNivel.Items.AddRange(new object[] {
            "SAL. VENTA LOCAL",
            "SAL. VENTA EXTERIOR"});
            this.cboNivel.Location = new System.Drawing.Point(414, 19);
            this.cboNivel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cboNivel.Name = "cboNivel";
            this.cboNivel.Size = new System.Drawing.Size(216, 21);
            this.cboNivel.TabIndex = 22;
            this.cboNivel.SelectionChangeCommitted += new System.EventHandler(this.cboNivel_SelectionChangeCommitted);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 22);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Programa";
            // 
            // cboPrograma
            // 
            this.cboPrograma.BackColor = System.Drawing.Color.White;
            this.cboPrograma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPrograma.FormattingEnabled = true;
            this.cboPrograma.Items.AddRange(new object[] {
            "SAL. VENTA LOCAL",
            "SAL. VENTA EXTERIOR"});
            this.cboPrograma.Location = new System.Drawing.Point(78, 19);
            this.cboPrograma.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cboPrograma.Name = "cboPrograma";
            this.cboPrograma.Size = new System.Drawing.Size(216, 21);
            this.cboPrograma.TabIndex = 20;
            this.cboPrograma.SelectedIndexChanged += new System.EventHandler(this.cbo_tipo_planilla_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgw1);
            this.groupBox2.Location = new System.Drawing.Point(13, 88);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(909, 518);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // dgw1
            // 
            this.dgw1.AllowUserToAddRows = false;
            this.dgw1.AllowUserToDeleteRows = false;
            this.dgw1.AllowUserToOrderColumns = true;
            this.dgw1.AllowUserToResizeRows = false;
            this.dgw1.BackgroundColor = System.Drawing.Color.White;
            this.dgw1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgw1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SUPERIOR,
            this.VENDEDOR,
            this.DESC_TIPO,
            this.COD_PER_SUP,
            this.CUOTA,
            this.IMPORTE});
            this.dgw1.Location = new System.Drawing.Point(11, 17);
            this.dgw1.MultiSelect = false;
            this.dgw1.Name = "dgw1";
            this.dgw1.ReadOnly = true;
            this.dgw1.RowHeadersWidth = 25;
            this.dgw1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dgw1.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.dgw1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgw1.Size = new System.Drawing.Size(888, 460);
            this.dgw1.TabIndex = 1;
            // 
            // SUPERIOR
            // 
            this.SUPERIOR.HeaderText = "Superior";
            this.SUPERIOR.Name = "SUPERIOR";
            this.SUPERIOR.ReadOnly = true;
            this.SUPERIOR.Visible = false;
            this.SUPERIOR.Width = 200;
            // 
            // VENDEDOR
            // 
            this.VENDEDOR.HeaderText = "Vendedor";
            this.VENDEDOR.Name = "VENDEDOR";
            this.VENDEDOR.ReadOnly = true;
            this.VENDEDOR.Width = 320;
            // 
            // DESC_TIPO
            // 
            this.DESC_TIPO.HeaderText = "Tipo Venta";
            this.DESC_TIPO.Name = "DESC_TIPO";
            this.DESC_TIPO.ReadOnly = true;
            this.DESC_TIPO.Width = 200;
            // 
            // COD_PER_SUP
            // 
            this.COD_PER_SUP.HeaderText = "COD_PERSONA";
            this.COD_PER_SUP.Name = "COD_PER_SUP";
            this.COD_PER_SUP.ReadOnly = true;
            this.COD_PER_SUP.Visible = false;
            // 
            // CUOTA
            // 
            this.CUOTA.HeaderText = "Cuota";
            this.CUOTA.Name = "CUOTA";
            this.CUOTA.ReadOnly = true;
            this.CUOTA.Width = 80;
            // 
            // IMPORTE
            // 
            this.IMPORTE.HeaderText = "Importe";
            this.IMPORTE.Name = "IMPORTE";
            this.IMPORTE.ReadOnly = true;
            this.IMPORTE.Width = 80;
            // 
            // CONSULTA_COMISIONES_X_PERSONA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 611);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "CONSULTA_COMISIONES_X_PERSONA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CONSULTA_COMISIONES_X_PERSONA";
            this.Load += new System.EventHandler(this.CONSULTA_COMISIONES_X_PERSONA_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgw1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.ComboBox cboPrograma;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.ComboBox cboNivel;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.ComboBox cboPersona;
        private System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.DataGridView dgw1;
        internal System.Windows.Forms.Button btn_buscar;
        private System.Windows.Forms.DataGridViewTextBoxColumn SUPERIOR;
        private System.Windows.Forms.DataGridViewTextBoxColumn VENDEDOR;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESC_TIPO;
        private System.Windows.Forms.DataGridViewTextBoxColumn COD_PER_SUP;
        private System.Windows.Forms.DataGridViewTextBoxColumn CUOTA;
        private System.Windows.Forms.DataGridViewTextBoxColumn IMPORTE;
    }
}