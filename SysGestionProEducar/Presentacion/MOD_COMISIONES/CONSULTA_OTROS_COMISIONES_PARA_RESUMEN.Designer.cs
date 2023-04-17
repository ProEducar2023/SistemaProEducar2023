namespace Presentacion.MOD_COMISIONES
{
    partial class CONSULTA_OTROS_COMISIONES_PARA_RESUMEN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CONSULTA_OTROS_COMISIONES_PARA_RESUMEN));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btn_eliminar2 = new System.Windows.Forms.Button();
            this.dgw1 = new System.Windows.Forms.DataGridView();
            this.COD_SUCURSAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FE_AÑO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FE_MES = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COD_PER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NRO_DOC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FECHA_DOC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COD_CPTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.concepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.obs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_modificar3 = new System.Windows.Forms.Button();
            this.btn_agregar1 = new System.Windows.Forms.Button();
            this.item1 = new System.Windows.Forms.TextBox();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.GroupBox4 = new System.Windows.Forms.GroupBox();
            this.dtp_fec_doc = new System.Windows.Forms.DateTimePicker();
            this.label45 = new System.Windows.Forms.Label();
            this.txt_nro_doc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbo_concepto = new System.Windows.Forms.ComboBox();
            this.txt_importe = new System.Windows.Forms.TextBox();
            this.btn_cancelar2 = new System.Windows.Forms.Button();
            this.btn_mod1 = new System.Windows.Forms.Button();
            this.txt_obs = new System.Windows.Forms.TextBox();
            this.btn_guardar2 = new System.Windows.Forms.Button();
            this.Label12 = new System.Windows.Forms.Label();
            this.Label11 = new System.Windows.Forms.Label();
            this.Label10 = new System.Windows.Forms.Label();
            this.btn_grabar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgw1)).BeginInit();
            this.Panel1.SuspendLayout();
            this.GroupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_eliminar2
            // 
            this.btn_eliminar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_eliminar2.Image = ((System.Drawing.Image)(resources.GetObject("btn_eliminar2.Image")));
            this.btn_eliminar2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_eliminar2.Location = new System.Drawing.Point(492, 174);
            this.btn_eliminar2.Name = "btn_eliminar2";
            this.btn_eliminar2.Size = new System.Drawing.Size(77, 27);
            this.btn_eliminar2.TabIndex = 139;
            this.btn_eliminar2.Text = "&Eliminar";
            this.btn_eliminar2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_eliminar2.UseVisualStyleBackColor = true;
            this.btn_eliminar2.Click += new System.EventHandler(this.btn_eliminar2_Click);
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
            this.COD_SUCURSAL,
            this.FE_AÑO,
            this.FE_MES,
            this.COD_PER,
            this.NRO_DOC,
            this.FECHA_DOC,
            this.COD_CPTO,
            this.concepto,
            this.importe,
            this.obs});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 8.25F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgw1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgw1.Location = new System.Drawing.Point(24, 29);
            this.dgw1.MultiSelect = false;
            this.dgw1.Name = "dgw1";
            this.dgw1.ReadOnly = true;
            this.dgw1.RowHeadersWidth = 20;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            this.dgw1.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgw1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dgw1.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.dgw1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgw1.Size = new System.Drawing.Size(546, 139);
            this.dgw1.TabIndex = 135;
            this.dgw1.TabStop = false;
            // 
            // COD_SUCURSAL
            // 
            this.COD_SUCURSAL.HeaderText = "COD_SUCURSAL";
            this.COD_SUCURSAL.Name = "COD_SUCURSAL";
            this.COD_SUCURSAL.ReadOnly = true;
            this.COD_SUCURSAL.Visible = false;
            // 
            // FE_AÑO
            // 
            this.FE_AÑO.HeaderText = "FE_AÑO";
            this.FE_AÑO.Name = "FE_AÑO";
            this.FE_AÑO.ReadOnly = true;
            this.FE_AÑO.Visible = false;
            // 
            // FE_MES
            // 
            this.FE_MES.HeaderText = "FE_MES";
            this.FE_MES.Name = "FE_MES";
            this.FE_MES.ReadOnly = true;
            this.FE_MES.Visible = false;
            // 
            // COD_PER
            // 
            this.COD_PER.HeaderText = "COD_PER";
            this.COD_PER.Name = "COD_PER";
            this.COD_PER.ReadOnly = true;
            this.COD_PER.Visible = false;
            // 
            // NRO_DOC
            // 
            this.NRO_DOC.HeaderText = "Nro Docu";
            this.NRO_DOC.Name = "NRO_DOC";
            this.NRO_DOC.ReadOnly = true;
            this.NRO_DOC.Width = 80;
            // 
            // FECHA_DOC
            // 
            this.FECHA_DOC.HeaderText = "Fe Docu";
            this.FECHA_DOC.Name = "FECHA_DOC";
            this.FECHA_DOC.ReadOnly = true;
            this.FECHA_DOC.Width = 75;
            // 
            // COD_CPTO
            // 
            this.COD_CPTO.HeaderText = "COD_CPTO";
            this.COD_CPTO.Name = "COD_CPTO";
            this.COD_CPTO.ReadOnly = true;
            this.COD_CPTO.Visible = false;
            // 
            // concepto
            // 
            this.concepto.HeaderText = "Concepto";
            this.concepto.Name = "concepto";
            this.concepto.ReadOnly = true;
            this.concepto.Width = 160;
            // 
            // importe
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.importe.DefaultCellStyle = dataGridViewCellStyle4;
            this.importe.HeaderText = "Importe";
            this.importe.Name = "importe";
            this.importe.ReadOnly = true;
            this.importe.Width = 60;
            // 
            // obs
            // 
            this.obs.HeaderText = "Observaciones";
            this.obs.Name = "obs";
            this.obs.ReadOnly = true;
            this.obs.Width = 130;
            // 
            // btn_modificar3
            // 
            this.btn_modificar3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_modificar3.Image = ((System.Drawing.Image)(resources.GetObject("btn_modificar3.Image")));
            this.btn_modificar3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_modificar3.Location = new System.Drawing.Point(411, 174);
            this.btn_modificar3.Name = "btn_modificar3";
            this.btn_modificar3.Size = new System.Drawing.Size(77, 27);
            this.btn_modificar3.TabIndex = 138;
            this.btn_modificar3.Text = "&Modificar";
            this.btn_modificar3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_modificar3.UseVisualStyleBackColor = true;
            this.btn_modificar3.Click += new System.EventHandler(this.btn_modificar3_Click);
            // 
            // btn_agregar1
            // 
            this.btn_agregar1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_agregar1.Image = ((System.Drawing.Image)(resources.GetObject("btn_agregar1.Image")));
            this.btn_agregar1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_agregar1.Location = new System.Drawing.Point(330, 174);
            this.btn_agregar1.Name = "btn_agregar1";
            this.btn_agregar1.Size = new System.Drawing.Size(77, 27);
            this.btn_agregar1.TabIndex = 137;
            this.btn_agregar1.Text = "&Agregar";
            this.btn_agregar1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_agregar1.UseVisualStyleBackColor = true;
            this.btn_agregar1.Click += new System.EventHandler(this.btn_agregar1_Click);
            // 
            // item1
            // 
            this.item1.Location = new System.Drawing.Point(283, 181);
            this.item1.Name = "item1";
            this.item1.Size = new System.Drawing.Size(25, 20);
            this.item1.TabIndex = 136;
            this.item1.Visible = false;
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.GroupBox4);
            this.Panel1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Panel1.Location = new System.Drawing.Point(24, 12);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(546, 209);
            this.Panel1.TabIndex = 140;
            this.Panel1.Visible = false;
            // 
            // GroupBox4
            // 
            this.GroupBox4.Controls.Add(this.dtp_fec_doc);
            this.GroupBox4.Controls.Add(this.label45);
            this.GroupBox4.Controls.Add(this.txt_nro_doc);
            this.GroupBox4.Controls.Add(this.label1);
            this.GroupBox4.Controls.Add(this.cbo_concepto);
            this.GroupBox4.Controls.Add(this.txt_importe);
            this.GroupBox4.Controls.Add(this.btn_cancelar2);
            this.GroupBox4.Controls.Add(this.btn_mod1);
            this.GroupBox4.Controls.Add(this.txt_obs);
            this.GroupBox4.Controls.Add(this.btn_guardar2);
            this.GroupBox4.Controls.Add(this.Label12);
            this.GroupBox4.Controls.Add(this.Label11);
            this.GroupBox4.Controls.Add(this.Label10);
            this.GroupBox4.Location = new System.Drawing.Point(43, 9);
            this.GroupBox4.Name = "GroupBox4";
            this.GroupBox4.Size = new System.Drawing.Size(460, 191);
            this.GroupBox4.TabIndex = 1;
            this.GroupBox4.TabStop = false;
            // 
            // dtp_fec_doc
            // 
            this.dtp_fec_doc.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_fec_doc.Location = new System.Drawing.Point(121, 36);
            this.dtp_fec_doc.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dtp_fec_doc.Name = "dtp_fec_doc";
            this.dtp_fec_doc.Size = new System.Drawing.Size(80, 20);
            this.dtp_fec_doc.TabIndex = 12;
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(33, 41);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(76, 14);
            this.label45.TabIndex = 19;
            this.label45.Text = "Fe Documento";
            // 
            // txt_nro_doc
            // 
            this.txt_nro_doc.Location = new System.Drawing.Point(120, 13);
            this.txt_nro_doc.Name = "txt_nro_doc";
            this.txt_nro_doc.Size = new System.Drawing.Size(129, 20);
            this.txt_nro_doc.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 14);
            this.label1.TabIndex = 18;
            this.label1.Text = "Nro Documento";
            // 
            // cbo_concepto
            // 
            this.cbo_concepto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_concepto.FormattingEnabled = true;
            this.cbo_concepto.ItemHeight = 14;
            this.cbo_concepto.Location = new System.Drawing.Point(120, 60);
            this.cbo_concepto.Name = "cbo_concepto";
            this.cbo_concepto.Size = new System.Drawing.Size(245, 22);
            this.cbo_concepto.TabIndex = 14;
            // 
            // txt_importe
            // 
            this.txt_importe.Location = new System.Drawing.Point(120, 86);
            this.txt_importe.Name = "txt_importe";
            this.txt_importe.Size = new System.Drawing.Size(129, 20);
            this.txt_importe.TabIndex = 16;
            this.txt_importe.Leave += new System.EventHandler(this.txt_importe_Leave);
            // 
            // btn_cancelar2
            // 
            this.btn_cancelar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancelar2.Image = ((System.Drawing.Image)(resources.GetObject("btn_cancelar2.Image")));
            this.btn_cancelar2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_cancelar2.Location = new System.Drawing.Point(250, 157);
            this.btn_cancelar2.Name = "btn_cancelar2";
            this.btn_cancelar2.Size = new System.Drawing.Size(77, 27);
            this.btn_cancelar2.TabIndex = 22;
            this.btn_cancelar2.Text = "&Cancelar";
            this.btn_cancelar2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_cancelar2.UseVisualStyleBackColor = true;
            this.btn_cancelar2.Click += new System.EventHandler(this.btn_cancelar2_Click);
            // 
            // btn_mod1
            // 
            this.btn_mod1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_mod1.Image = ((System.Drawing.Image)(resources.GetObject("btn_mod1.Image")));
            this.btn_mod1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_mod1.Location = new System.Drawing.Point(169, 157);
            this.btn_mod1.Name = "btn_mod1";
            this.btn_mod1.Size = new System.Drawing.Size(77, 27);
            this.btn_mod1.TabIndex = 0;
            this.btn_mod1.Text = "&Modificar";
            this.btn_mod1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_mod1.UseVisualStyleBackColor = true;
            this.btn_mod1.Visible = false;
            this.btn_mod1.Click += new System.EventHandler(this.btn_mod1_Click);
            // 
            // txt_obs
            // 
            this.txt_obs.Location = new System.Drawing.Point(120, 110);
            this.txt_obs.Multiline = true;
            this.txt_obs.Name = "txt_obs";
            this.txt_obs.Size = new System.Drawing.Size(313, 40);
            this.txt_obs.TabIndex = 18;
            // 
            // btn_guardar2
            // 
            this.btn_guardar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_guardar2.Image = ((System.Drawing.Image)(resources.GetObject("btn_guardar2.Image")));
            this.btn_guardar2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_guardar2.Location = new System.Drawing.Point(169, 157);
            this.btn_guardar2.Name = "btn_guardar2";
            this.btn_guardar2.Size = new System.Drawing.Size(77, 27);
            this.btn_guardar2.TabIndex = 20;
            this.btn_guardar2.Text = "&Guardar";
            this.btn_guardar2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_guardar2.UseVisualStyleBackColor = true;
            this.btn_guardar2.Click += new System.EventHandler(this.btn_guardar2_Click);
            // 
            // Label12
            // 
            this.Label12.AutoSize = true;
            this.Label12.Location = new System.Drawing.Point(33, 113);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(69, 14);
            this.Label12.TabIndex = 15;
            this.Label12.Text = "Observación";
            // 
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.Location = new System.Drawing.Point(33, 90);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(42, 14);
            this.Label11.TabIndex = 14;
            this.Label11.Text = "Importe";
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.Location = new System.Drawing.Point(33, 65);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(53, 14);
            this.Label10.TabIndex = 13;
            this.Label10.Text = "Concepto";
            // 
            // btn_grabar
            // 
            this.btn_grabar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_grabar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_grabar.Image = ((System.Drawing.Image)(resources.GetObject("btn_grabar.Image")));
            this.btn_grabar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_grabar.Location = new System.Drawing.Point(24, 174);
            this.btn_grabar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_grabar.Name = "btn_grabar";
            this.btn_grabar.Size = new System.Drawing.Size(77, 27);
            this.btn_grabar.TabIndex = 141;
            this.btn_grabar.Text = "&Aceptar";
            this.btn_grabar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_grabar.UseVisualStyleBackColor = true;
            // 
            // CONSULTA_OTROS_COMISIONES_PARA_RESUMEN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 233);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.btn_eliminar2);
            this.Controls.Add(this.dgw1);
            this.Controls.Add(this.btn_modificar3);
            this.Controls.Add(this.btn_agregar1);
            this.Controls.Add(this.item1);
            this.Controls.Add(this.btn_grabar);
            this.Name = "CONSULTA_OTROS_COMISIONES_PARA_RESUMEN";
            this.Text = "Otros Descuentos";
            this.Load += new System.EventHandler(this.CONSULTA_OTROS_COMISIONES_PARA_RESUMEN_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CONSULTA_OTROS_COMISIONES_PARA_RESUMEN_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgw1)).EndInit();
            this.Panel1.ResumeLayout(false);
            this.GroupBox4.ResumeLayout(false);
            this.GroupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button btn_eliminar2;
        internal System.Windows.Forms.DataGridView dgw1;
        internal System.Windows.Forms.Button btn_modificar3;
        internal System.Windows.Forms.Button btn_agregar1;
        internal System.Windows.Forms.TextBox item1;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.GroupBox GroupBox4;
        internal System.Windows.Forms.TextBox txt_importe;
        internal System.Windows.Forms.Button btn_cancelar2;
        internal System.Windows.Forms.Button btn_mod1;
        internal System.Windows.Forms.TextBox txt_obs;
        internal System.Windows.Forms.Button btn_guardar2;
        internal System.Windows.Forms.Label Label12;
        internal System.Windows.Forms.Label Label11;
        internal System.Windows.Forms.Label Label10;
        internal System.Windows.Forms.Button btn_grabar;
        internal System.Windows.Forms.ComboBox cbo_concepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn COD_SUCURSAL;
        private System.Windows.Forms.DataGridViewTextBoxColumn FE_AÑO;
        private System.Windows.Forms.DataGridViewTextBoxColumn FE_MES;
        private System.Windows.Forms.DataGridViewTextBoxColumn COD_PER;
        private System.Windows.Forms.DataGridViewTextBoxColumn NRO_DOC;
        private System.Windows.Forms.DataGridViewTextBoxColumn FECHA_DOC;
        private System.Windows.Forms.DataGridViewTextBoxColumn COD_CPTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn concepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn importe;
        private System.Windows.Forms.DataGridViewTextBoxColumn obs;
        internal System.Windows.Forms.TextBox txt_nro_doc;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.DateTimePicker dtp_fec_doc;
        internal System.Windows.Forms.Label label45;
    }
}