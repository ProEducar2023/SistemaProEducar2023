namespace Presentacion.MOD_CXC
{
    partial class CONTRATOS_VENCIDOS_PD
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CONTRATOS_VENCIDOS_PD));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DGW = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_aceptar = new System.Windows.Forms.Button();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.lbl_venc = new System.Windows.Forms.Label();
            this.NRO_CONTRATO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESC_PER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FECHA_CONTRATO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FECHA_VEN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NRO_DOC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LETRA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IMP_INI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ok = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.COD_SECTORISTA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COD_PER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DGW)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DGW
            // 
            this.DGW.AllowUserToAddRows = false;
            this.DGW.AllowUserToDeleteRows = false;
            this.DGW.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGW.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGW.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGW.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NRO_CONTRATO,
            this.DESC_PER,
            this.FECHA_CONTRATO,
            this.FECHA_VEN,
            this.NRO_DOC,
            this.LETRA,
            this.IMP_INI,
            this.ok,
            this.COD_SECTORISTA,
            this.COD_PER});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 8.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGW.DefaultCellStyle = dataGridViewCellStyle3;
            this.DGW.Location = new System.Drawing.Point(11, 26);
            this.DGW.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.DGW.MultiSelect = false;
            this.DGW.Name = "DGW";
            this.DGW.RowHeadersWidth = 25;
            this.DGW.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.DGW.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.DGW.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGW.Size = new System.Drawing.Size(665, 329);
            this.DGW.TabIndex = 3;
            this.DGW.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_aceptar);
            this.groupBox1.Controls.Add(this.btn_cancelar);
            this.groupBox1.Location = new System.Drawing.Point(12, 361);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(663, 52);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // btn_aceptar
            // 
            this.btn_aceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_aceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_aceptar.Image = ((System.Drawing.Image)(resources.GetObject("btn_aceptar.Image")));
            this.btn_aceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_aceptar.Location = new System.Drawing.Point(481, 15);
            this.btn_aceptar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_aceptar.Name = "btn_aceptar";
            this.btn_aceptar.Size = new System.Drawing.Size(77, 27);
            this.btn_aceptar.TabIndex = 36;
            this.btn_aceptar.Text = "&Aceptar";
            this.btn_aceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_aceptar.UseVisualStyleBackColor = true;
            this.btn_aceptar.Click += new System.EventHandler(this.btn_aceptar_Click);
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancelar.Image = ((System.Drawing.Image)(resources.GetObject("btn_cancelar.Image")));
            this.btn_cancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_cancelar.Location = new System.Drawing.Point(562, 15);
            this.btn_cancelar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(77, 27);
            this.btn_cancelar.TabIndex = 37;
            this.btn_cancelar.Text = "&Cancelar";
            this.btn_cancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_cancelar.UseVisualStyleBackColor = true;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // lbl_venc
            // 
            this.lbl_venc.AutoSize = true;
            this.lbl_venc.Font = new System.Drawing.Font("Arial", 8.25F);
            this.lbl_venc.Location = new System.Drawing.Point(21, 6);
            this.lbl_venc.Name = "lbl_venc";
            this.lbl_venc.Size = new System.Drawing.Size(51, 14);
            this.lbl_venc.TabIndex = 5;
            this.lbl_venc.Text = "vencidos";
            // 
            // NRO_CONTRATO
            // 
            this.NRO_CONTRATO.HeaderText = "Contrato";
            this.NRO_CONTRATO.Name = "NRO_CONTRATO";
            this.NRO_CONTRATO.ReadOnly = true;
            this.NRO_CONTRATO.Width = 70;
            // 
            // DESC_PER
            // 
            this.DESC_PER.HeaderText = "Cliente";
            this.DESC_PER.Name = "DESC_PER";
            this.DESC_PER.ReadOnly = true;
            this.DESC_PER.Width = 220;
            // 
            // FECHA_CONTRATO
            // 
            this.FECHA_CONTRATO.HeaderText = "FECHA_CONTRATO";
            this.FECHA_CONTRATO.Name = "FECHA_CONTRATO";
            this.FECHA_CONTRATO.ReadOnly = true;
            this.FECHA_CONTRATO.Visible = false;
            // 
            // FECHA_VEN
            // 
            this.FECHA_VEN.HeaderText = "F Venc";
            this.FECHA_VEN.Name = "FECHA_VEN";
            this.FECHA_VEN.Width = 75;
            // 
            // NRO_DOC
            // 
            this.NRO_DOC.HeaderText = "Doc";
            this.NRO_DOC.Name = "NRO_DOC";
            this.NRO_DOC.ReadOnly = true;
            this.NRO_DOC.Width = 80;
            // 
            // LETRA
            // 
            this.LETRA.HeaderText = "Letra";
            this.LETRA.Name = "LETRA";
            this.LETRA.ReadOnly = true;
            this.LETRA.Width = 70;
            // 
            // IMP_INI
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.IMP_INI.DefaultCellStyle = dataGridViewCellStyle2;
            this.IMP_INI.HeaderText = "Importe";
            this.IMP_INI.Name = "IMP_INI";
            this.IMP_INI.ReadOnly = true;
            this.IMP_INI.Width = 80;
            // 
            // ok
            // 
            this.ok.HeaderText = "X";
            this.ok.Name = "ok";
            this.ok.Width = 30;
            // 
            // COD_SECTORISTA
            // 
            this.COD_SECTORISTA.HeaderText = "COD_SECTORISTA";
            this.COD_SECTORISTA.Name = "COD_SECTORISTA";
            this.COD_SECTORISTA.Visible = false;
            // 
            // COD_PER
            // 
            this.COD_PER.HeaderText = "COD_PER";
            this.COD_PER.Name = "COD_PER";
            this.COD_PER.Visible = false;
            // 
            // CONTRATOS_VENCIDOS_PD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 425);
            this.Controls.Add(this.lbl_venc);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.DGW);
            this.Name = "CONTRATOS_VENCIDOS_PD";
            this.Text = "CONTRATOS POR VENCER";
            this.Load += new System.EventHandler(this.CONTRATOS_VENCIDOS_PD_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGW)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.DataGridView DGW;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.Button btn_aceptar;
        internal System.Windows.Forms.Button btn_cancelar;
        internal System.Windows.Forms.Label lbl_venc;
        private System.Windows.Forms.DataGridViewTextBoxColumn NRO_CONTRATO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESC_PER;
        private System.Windows.Forms.DataGridViewTextBoxColumn FECHA_CONTRATO;
        private System.Windows.Forms.DataGridViewTextBoxColumn FECHA_VEN;
        private System.Windows.Forms.DataGridViewTextBoxColumn NRO_DOC;
        private System.Windows.Forms.DataGridViewTextBoxColumn LETRA;
        private System.Windows.Forms.DataGridViewTextBoxColumn IMP_INI;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ok;
        private System.Windows.Forms.DataGridViewTextBoxColumn COD_SECTORISTA;
        private System.Windows.Forms.DataGridViewTextBoxColumn COD_PER;
    }
}