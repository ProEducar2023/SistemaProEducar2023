namespace Presentacion.CONSULTAS
{
    partial class CONSULTA_FACT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CONSULTA_FACT));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DGW_CAB = new System.Windows.Forms.DataGridView();
            this.GroupBox8 = new System.Windows.Forms.GroupBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.txt_letra = new System.Windows.Forms.TextBox();
            this.BTN_ACEPTAR = new System.Windows.Forms.Button();
            this.BTN_CANCELAR = new System.Windows.Forms.Button();
            this.NRO_DOC1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FECHA_DOC1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FECHA_VEN1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IMPORTE1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COD_MONEDA1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Desc_moneda1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TIPO_CAMBIO1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OBSERVACION1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FE_AÑO1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FE_MES1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COD_DOC1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COD_CLASE1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DGW_CAB)).BeginInit();
            this.GroupBox8.SuspendLayout();
            this.SuspendLayout();
            // 
            // DGW_CAB
            // 
            this.DGW_CAB.AllowUserToAddRows = false;
            this.DGW_CAB.AllowUserToDeleteRows = false;
            this.DGW_CAB.BackgroundColor = System.Drawing.Color.White;
            this.DGW_CAB.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NRO_DOC1,
            this.FECHA_DOC1,
            this.FECHA_VEN1,
            this.IMPORTE1,
            this.COD_MONEDA1,
            this.Desc_moneda1,
            this.TIPO_CAMBIO1,
            this.OBSERVACION1,
            this.FE_AÑO1,
            this.FE_MES1,
            this.COD_DOC1,
            this.COD_CLASE1});
            this.DGW_CAB.Location = new System.Drawing.Point(12, 13);
            this.DGW_CAB.Name = "DGW_CAB";
            this.DGW_CAB.ReadOnly = true;
            this.DGW_CAB.RowHeadersWidth = 25;
            this.DGW_CAB.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.DGW_CAB.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.DGW_CAB.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGW_CAB.Size = new System.Drawing.Size(681, 206);
            this.DGW_CAB.TabIndex = 51;
            // 
            // GroupBox8
            // 
            this.GroupBox8.Controls.Add(this.Label1);
            this.GroupBox8.Controls.Add(this.txt_letra);
            this.GroupBox8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox8.Location = new System.Drawing.Point(12, 225);
            this.GroupBox8.Name = "GroupBox8";
            this.GroupBox8.Size = new System.Drawing.Size(257, 50);
            this.GroupBox8.TabIndex = 54;
            this.GroupBox8.TabStop = false;
            this.GroupBox8.Text = "Buscado por:";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(6, 27);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(84, 14);
            this.Label1.TabIndex = 51;
            this.Label1.Text = "Nº Documento";
            // 
            // txt_letra
            // 
            this.txt_letra.Font = new System.Drawing.Font("Arial", 8.25F);
            this.txt_letra.Location = new System.Drawing.Point(96, 21);
            this.txt_letra.Name = "txt_letra";
            this.txt_letra.Size = new System.Drawing.Size(138, 20);
            this.txt_letra.TabIndex = 0;
            this.txt_letra.TextChanged += new System.EventHandler(this.txt_letra_TextChanged);
            // 
            // BTN_ACEPTAR
            // 
            this.BTN_ACEPTAR.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BTN_ACEPTAR.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BTN_ACEPTAR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_ACEPTAR.Image = ((System.Drawing.Image)(resources.GetObject("BTN_ACEPTAR.Image")));
            this.BTN_ACEPTAR.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTN_ACEPTAR.Location = new System.Drawing.Point(531, 247);
            this.BTN_ACEPTAR.Name = "BTN_ACEPTAR";
            this.BTN_ACEPTAR.Size = new System.Drawing.Size(78, 29);
            this.BTN_ACEPTAR.TabIndex = 52;
            this.BTN_ACEPTAR.Text = "&Agregar ";
            this.BTN_ACEPTAR.Click += new System.EventHandler(this.BTN_ACEPTAR_Click);
            // 
            // BTN_CANCELAR
            // 
            this.BTN_CANCELAR.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BTN_CANCELAR.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BTN_CANCELAR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_CANCELAR.Image = ((System.Drawing.Image)(resources.GetObject("BTN_CANCELAR.Image")));
            this.BTN_CANCELAR.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTN_CANCELAR.Location = new System.Drawing.Point(615, 246);
            this.BTN_CANCELAR.Name = "BTN_CANCELAR";
            this.BTN_CANCELAR.Size = new System.Drawing.Size(78, 29);
            this.BTN_CANCELAR.TabIndex = 53;
            this.BTN_CANCELAR.Text = "&Salir";
            // 
            // NRO_DOC1
            // 
            this.NRO_DOC1.HeaderText = "Nº Documento";
            this.NRO_DOC1.Name = "NRO_DOC1";
            this.NRO_DOC1.ReadOnly = true;
            this.NRO_DOC1.Width = 90;
            // 
            // FECHA_DOC1
            // 
            dataGridViewCellStyle4.Format = "d";
            this.FECHA_DOC1.DefaultCellStyle = dataGridViewCellStyle4;
            this.FECHA_DOC1.HeaderText = "Fecha";
            this.FECHA_DOC1.Name = "FECHA_DOC1";
            this.FECHA_DOC1.ReadOnly = true;
            this.FECHA_DOC1.Width = 80;
            // 
            // FECHA_VEN1
            // 
            dataGridViewCellStyle5.Format = "d";
            this.FECHA_VEN1.DefaultCellStyle = dataGridViewCellStyle5;
            this.FECHA_VEN1.HeaderText = "Vcto.";
            this.FECHA_VEN1.Name = "FECHA_VEN1";
            this.FECHA_VEN1.ReadOnly = true;
            this.FECHA_VEN1.Width = 80;
            // 
            // IMPORTE1
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle6.Format = "N2";
            this.IMPORTE1.DefaultCellStyle = dataGridViewCellStyle6;
            this.IMPORTE1.HeaderText = "Importe";
            this.IMPORTE1.Name = "IMPORTE1";
            this.IMPORTE1.ReadOnly = true;
            // 
            // COD_MONEDA1
            // 
            this.COD_MONEDA1.HeaderText = "Mon";
            this.COD_MONEDA1.Name = "COD_MONEDA1";
            this.COD_MONEDA1.ReadOnly = true;
            this.COD_MONEDA1.Width = 35;
            // 
            // Desc_moneda1
            // 
            this.Desc_moneda1.HeaderText = "Des Mon";
            this.Desc_moneda1.Name = "Desc_moneda1";
            this.Desc_moneda1.ReadOnly = true;
            // 
            // TIPO_CAMBIO1
            // 
            this.TIPO_CAMBIO1.HeaderText = "T.Cambio";
            this.TIPO_CAMBIO1.Name = "TIPO_CAMBIO1";
            this.TIPO_CAMBIO1.ReadOnly = true;
            // 
            // OBSERVACION1
            // 
            this.OBSERVACION1.HeaderText = "Observación";
            this.OBSERVACION1.Name = "OBSERVACION1";
            this.OBSERVACION1.ReadOnly = true;
            this.OBSERVACION1.Width = 150;
            // 
            // FE_AÑO1
            // 
            this.FE_AÑO1.HeaderText = "Año";
            this.FE_AÑO1.Name = "FE_AÑO1";
            this.FE_AÑO1.ReadOnly = true;
            this.FE_AÑO1.Width = 40;
            // 
            // FE_MES1
            // 
            this.FE_MES1.HeaderText = "Mes";
            this.FE_MES1.Name = "FE_MES1";
            this.FE_MES1.ReadOnly = true;
            this.FE_MES1.Width = 40;
            // 
            // COD_DOC1
            // 
            this.COD_DOC1.HeaderText = "Doc";
            this.COD_DOC1.Name = "COD_DOC1";
            this.COD_DOC1.ReadOnly = true;
            this.COD_DOC1.Width = 30;
            // 
            // COD_CLASE1
            // 
            this.COD_CLASE1.HeaderText = "Clase";
            this.COD_CLASE1.Name = "COD_CLASE1";
            this.COD_CLASE1.ReadOnly = true;
            // 
            // CONSULTA_FACT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 288);
            this.Controls.Add(this.DGW_CAB);
            this.Controls.Add(this.GroupBox8);
            this.Controls.Add(this.BTN_ACEPTAR);
            this.Controls.Add(this.BTN_CANCELAR);
            this.Name = "CONSULTA_FACT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CONSULTA_FACT";
            ((System.ComponentModel.ISupportInitialize)(this.DGW_CAB)).EndInit();
            this.GroupBox8.ResumeLayout(false);
            this.GroupBox8.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.DataGridView DGW_CAB;
        internal System.Windows.Forms.GroupBox GroupBox8;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox txt_letra;
        internal System.Windows.Forms.Button BTN_ACEPTAR;
        internal System.Windows.Forms.Button BTN_CANCELAR;
        private System.Windows.Forms.DataGridViewTextBoxColumn NRO_DOC1;
        private System.Windows.Forms.DataGridViewTextBoxColumn FECHA_DOC1;
        private System.Windows.Forms.DataGridViewTextBoxColumn FECHA_VEN1;
        private System.Windows.Forms.DataGridViewTextBoxColumn IMPORTE1;
        private System.Windows.Forms.DataGridViewTextBoxColumn COD_MONEDA1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Desc_moneda1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TIPO_CAMBIO1;
        private System.Windows.Forms.DataGridViewTextBoxColumn OBSERVACION1;
        private System.Windows.Forms.DataGridViewTextBoxColumn FE_AÑO1;
        private System.Windows.Forms.DataGridViewTextBoxColumn FE_MES1;
        private System.Windows.Forms.DataGridViewTextBoxColumn COD_DOC1;
        private System.Windows.Forms.DataGridViewTextBoxColumn COD_CLASE1;
    }
}