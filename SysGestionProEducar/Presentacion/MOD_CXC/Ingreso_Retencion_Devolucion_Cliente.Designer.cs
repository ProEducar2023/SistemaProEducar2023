namespace Presentacion.MOD_CXC
{
    partial class Ingreso_Retencion_Devolucion_Cliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ingreso_Retencion_Devolucion_Cliente));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_adicionar = new System.Windows.Forms.Button();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.txt_doc_per = new System.Windows.Forms.TextBox();
            this.TXT_DESC = new System.Windows.Forms.TextBox();
            this.TXT_COD = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.dgw_dev_cliente = new System.Windows.Forms.DataGridView();
            this.OK_Button = new System.Windows.Forms.Button();
            this.Cancel_Button = new System.Windows.Forms.Button();
            this.Panel_PER = new System.Windows.Forms.Panel();
            this.btn_sgt2 = new System.Windows.Forms.Button();
            this.btn_cadena2 = new System.Windows.Forms.Button();
            this.dgw_per = new System.Windows.Forms.DataGridView();
            this.btn_eliminar = new System.Windows.Forms.Button();
            this.txt_total = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.NRO_CONTRATO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COD_PER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.APENOM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MONTO_DEV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw_dev_cliente)).BeginInit();
            this.Panel_PER.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw_per)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btn_adicionar);
            this.groupBox1.Controls.Add(this.btn_refresh);
            this.groupBox1.Controls.Add(this.txt_doc_per);
            this.groupBox1.Controls.Add(this.TXT_DESC);
            this.groupBox1.Controls.Add(this.TXT_COD);
            this.groupBox1.Controls.Add(this.Label2);
            this.groupBox1.Location = new System.Drawing.Point(9, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(623, 54);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btn_adicionar
            // 
            this.btn_adicionar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_adicionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_adicionar.Image = ((System.Drawing.Image)(resources.GetObject("btn_adicionar.Image")));
            this.btn_adicionar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_adicionar.Location = new System.Drawing.Point(553, 16);
            this.btn_adicionar.Name = "btn_adicionar";
            this.btn_adicionar.Size = new System.Drawing.Size(56, 25);
            this.btn_adicionar.TabIndex = 7;
            this.btn_adicionar.Text = "Add";
            this.btn_adicionar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_adicionar.Click += new System.EventHandler(this.btn_adicionar_Click);
            // 
            // btn_refresh
            // 
            this.btn_refresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_refresh.Image = ((System.Drawing.Image)(resources.GetObject("btn_refresh.Image")));
            this.btn_refresh.Location = new System.Drawing.Point(532, 20);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(15, 20);
            this.btn_refresh.TabIndex = 206;
            this.btn_refresh.TabStop = false;
            this.btn_refresh.UseVisualStyleBackColor = true;
            // 
            // txt_doc_per
            // 
            this.txt_doc_per.BackColor = System.Drawing.Color.White;
            this.txt_doc_per.Location = new System.Drawing.Point(428, 20);
            this.txt_doc_per.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_doc_per.MaxLength = 20;
            this.txt_doc_per.Name = "txt_doc_per";
            this.txt_doc_per.Size = new System.Drawing.Size(100, 20);
            this.txt_doc_per.TabIndex = 5;
            this.txt_doc_per.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_doc_per_KeyDown);
            // 
            // TXT_DESC
            // 
            this.TXT_DESC.BackColor = System.Drawing.Color.White;
            this.TXT_DESC.Location = new System.Drawing.Point(125, 20);
            this.TXT_DESC.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.TXT_DESC.MaxLength = 60;
            this.TXT_DESC.Name = "TXT_DESC";
            this.TXT_DESC.Size = new System.Drawing.Size(303, 20);
            this.TXT_DESC.TabIndex = 3;
            this.TXT_DESC.Leave += new System.EventHandler(this.TXT_DESC_Leave);
            // 
            // TXT_COD
            // 
            this.TXT_COD.BackColor = System.Drawing.Color.White;
            this.TXT_COD.Location = new System.Drawing.Point(74, 20);
            this.TXT_COD.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.TXT_COD.MaxLength = 5;
            this.TXT_COD.Name = "TXT_COD";
            this.TXT_COD.Size = new System.Drawing.Size(51, 20);
            this.TXT_COD.TabIndex = 1;
            this.TXT_COD.Leave += new System.EventHandler(this.TXT_COD_Leave);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(13, 23);
            this.Label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(39, 13);
            this.Label2.TabIndex = 202;
            this.Label2.Text = "Cliente";
            // 
            // dgw_dev_cliente
            // 
            this.dgw_dev_cliente.AllowUserToAddRows = false;
            this.dgw_dev_cliente.AllowUserToDeleteRows = false;
            this.dgw_dev_cliente.AllowUserToOrderColumns = true;
            this.dgw_dev_cliente.AllowUserToResizeRows = false;
            this.dgw_dev_cliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgw_dev_cliente.BackgroundColor = System.Drawing.Color.White;
            this.dgw_dev_cliente.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NRO_CONTRATO,
            this.COD_PER,
            this.APENOM,
            this.MONTO_DEV});
            this.dgw_dev_cliente.Location = new System.Drawing.Point(11, 60);
            this.dgw_dev_cliente.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dgw_dev_cliente.MultiSelect = false;
            this.dgw_dev_cliente.Name = "dgw_dev_cliente";
            this.dgw_dev_cliente.RowHeadersWidth = 25;
            this.dgw_dev_cliente.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dgw_dev_cliente.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.dgw_dev_cliente.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgw_dev_cliente.ShowCellErrors = false;
            this.dgw_dev_cliente.ShowRowErrors = false;
            this.dgw_dev_cliente.Size = new System.Drawing.Size(621, 229);
            this.dgw_dev_cliente.TabIndex = 1;
            this.dgw_dev_cliente.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgw_dev_cliente_CellEndEdit);
            // 
            // OK_Button
            // 
            this.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.OK_Button.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OK_Button.Image = ((System.Drawing.Image)(resources.GetObject("OK_Button.Image")));
            this.OK_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.OK_Button.Location = new System.Drawing.Point(476, 314);
            this.OK_Button.Name = "OK_Button";
            this.OK_Button.Size = new System.Drawing.Size(75, 27);
            this.OK_Button.TabIndex = 33;
            this.OK_Button.Text = "Aceptar";
            this.OK_Button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Cancel_Button.Image = ((System.Drawing.Image)(resources.GetObject("Cancel_Button.Image")));
            this.Cancel_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Cancel_Button.Location = new System.Drawing.Point(557, 314);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(75, 27);
            this.Cancel_Button.TabIndex = 34;
            this.Cancel_Button.Text = "Cancelar";
            this.Cancel_Button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Panel_PER
            // 
            this.Panel_PER.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel_PER.Controls.Add(this.btn_sgt2);
            this.Panel_PER.Controls.Add(this.btn_cadena2);
            this.Panel_PER.Controls.Add(this.dgw_per);
            this.Panel_PER.Location = new System.Drawing.Point(12, 42);
            this.Panel_PER.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Panel_PER.Name = "Panel_PER";
            this.Panel_PER.Size = new System.Drawing.Size(545, 277);
            this.Panel_PER.TabIndex = 35;
            this.Panel_PER.Visible = false;
            // 
            // btn_sgt2
            // 
            this.btn_sgt2.Enabled = false;
            this.btn_sgt2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_sgt2.Image = ((System.Drawing.Image)(resources.GetObject("btn_sgt2.Image")));
            this.btn_sgt2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_sgt2.Location = new System.Drawing.Point(2, 29);
            this.btn_sgt2.Name = "btn_sgt2";
            this.btn_sgt2.Size = new System.Drawing.Size(64, 24);
            this.btn_sgt2.TabIndex = 55;
            this.btn_sgt2.Text = "&Sgte.";
            this.btn_sgt2.UseVisualStyleBackColor = true;
            // 
            // btn_cadena2
            // 
            this.btn_cadena2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cadena2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_cadena2.Location = new System.Drawing.Point(2, 3);
            this.btn_cadena2.Name = "btn_cadena2";
            this.btn_cadena2.Size = new System.Drawing.Size(64, 24);
            this.btn_cadena2.TabIndex = 54;
            this.btn_cadena2.Text = "&Cadena";
            this.btn_cadena2.UseVisualStyleBackColor = true;
            // 
            // dgw_per
            // 
            this.dgw_per.AllowUserToAddRows = false;
            this.dgw_per.AllowUserToDeleteRows = false;
            this.dgw_per.BackgroundColor = System.Drawing.Color.White;
            this.dgw_per.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgw_per.Location = new System.Drawing.Point(70, -1);
            this.dgw_per.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dgw_per.MultiSelect = false;
            this.dgw_per.Name = "dgw_per";
            this.dgw_per.ReadOnly = true;
            this.dgw_per.RowHeadersWidth = 25;
            this.dgw_per.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dgw_per.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.dgw_per.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgw_per.Size = new System.Drawing.Size(462, 266);
            this.dgw_per.TabIndex = 10;
            this.dgw_per.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgw_per_KeyDown);
            // 
            // btn_eliminar
            // 
            this.btn_eliminar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_eliminar.Image = ((System.Drawing.Image)(resources.GetObject("btn_eliminar.Image")));
            this.btn_eliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_eliminar.Location = new System.Drawing.Point(12, 314);
            this.btn_eliminar.Name = "btn_eliminar";
            this.btn_eliminar.Size = new System.Drawing.Size(75, 27);
            this.btn_eliminar.TabIndex = 36;
            this.btn_eliminar.Text = "Eliminar";
            this.btn_eliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_eliminar.Click += new System.EventHandler(this.btn_eliminar_Click);
            // 
            // txt_total
            // 
            this.txt_total.BackColor = System.Drawing.Color.White;
            this.txt_total.Location = new System.Drawing.Point(493, 291);
            this.txt_total.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_total.MaxLength = 20;
            this.txt_total.Name = "txt_total";
            this.txt_total.ReadOnly = true;
            this.txt_total.Size = new System.Drawing.Size(92, 20);
            this.txt_total.TabIndex = 206;
            this.txt_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(459, 295);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 207;
            this.label1.Text = "Total";
            // 
            // NRO_CONTRATO
            // 
            this.NRO_CONTRATO.HeaderText = "Nro Contrato";
            this.NRO_CONTRATO.Name = "NRO_CONTRATO";
            // 
            // COD_PER
            // 
            this.COD_PER.HeaderText = "COD_PER";
            this.COD_PER.Name = "COD_PER";
            this.COD_PER.Visible = false;
            // 
            // APENOM
            // 
            this.APENOM.HeaderText = "Apellidos y Nombres";
            this.APENOM.Name = "APENOM";
            this.APENOM.Width = 350;
            // 
            // MONTO_DEV
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.MONTO_DEV.DefaultCellStyle = dataGridViewCellStyle1;
            this.MONTO_DEV.HeaderText = "Monto Dev";
            this.MONTO_DEV.Name = "MONTO_DEV";
            // 
            // Ingreso_Retencion_Devolucion_Cliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 349);
            this.Controls.Add(this.Panel_PER);
            this.Controls.Add(this.OK_Button);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgw_dev_cliente);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_eliminar);
            this.Controls.Add(this.txt_total);
            this.Name = "Ingreso_Retencion_Devolucion_Cliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ingreso Retencion por Devolucion a Clientes";
            this.Load += new System.EventHandler(this.Ingreso_Retencion_Devolucion_Cliente_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ingreso_Retencion_Devolucion_Cliente_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw_dev_cliente)).EndInit();
            this.Panel_PER.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgw_per)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.DataGridView dgw_dev_cliente;
        internal System.Windows.Forms.Button OK_Button;
        internal System.Windows.Forms.Button Cancel_Button;
        internal System.Windows.Forms.Button btn_refresh;
        internal System.Windows.Forms.TextBox txt_doc_per;
        internal System.Windows.Forms.TextBox TXT_DESC;
        internal System.Windows.Forms.TextBox TXT_COD;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Panel Panel_PER;
        internal System.Windows.Forms.Button btn_sgt2;
        internal System.Windows.Forms.Button btn_cadena2;
        internal System.Windows.Forms.DataGridView dgw_per;
        internal System.Windows.Forms.Button btn_adicionar;
        internal System.Windows.Forms.Button btn_eliminar;
        internal System.Windows.Forms.TextBox txt_total;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn NRO_CONTRATO;
        private System.Windows.Forms.DataGridViewTextBoxColumn COD_PER;
        private System.Windows.Forms.DataGridViewTextBoxColumn APENOM;
        private System.Windows.Forms.DataGridViewTextBoxColumn MONTO_DEV;

    }
}