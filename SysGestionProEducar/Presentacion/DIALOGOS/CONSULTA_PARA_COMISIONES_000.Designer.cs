namespace Presentacion.DIALOGOS
{
    partial class CONSULTA_PARA_COMISIONES_000
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CONSULTA_PARA_COMISIONES_000));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgw = new System.Windows.Forms.DataGridView();
            this.BTN_ACEPTAR = new System.Windows.Forms.Button();
            this.BTN_CANCELAR = new System.Windows.Forms.Button();
            this.TIPO_VTA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COD_PROGRAMA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COD_VENDEDOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESC_PER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NRO_CONTRATO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FE_CONTRATO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FE_AÑO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FE_MES = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FE_DOC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COD_PER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NOMCLI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NRO_LETRA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COD_NIVEL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESC_NIVEL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IMP_FIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COD_PER_SUP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NOMSUP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.X = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgw)).BeginInit();
            this.SuspendLayout();
            // 
            // dgw
            // 
            this.dgw.AllowUserToAddRows = false;
            this.dgw.AllowUserToDeleteRows = false;
            this.dgw.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgw.BackgroundColor = System.Drawing.Color.White;
            this.dgw.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TIPO_VTA,
            this.COD_PROGRAMA,
            this.COD_VENDEDOR,
            this.DESC_PER,
            this.NRO_CONTRATO,
            this.FE_CONTRATO,
            this.FE_AÑO,
            this.FE_MES,
            this.FE_DOC,
            this.COD_PER,
            this.NOMCLI,
            this.NRO_LETRA,
            this.COD_NIVEL,
            this.DESC_NIVEL,
            this.IMP_FIN,
            this.COD_PER_SUP,
            this.NOMSUP,
            this.X});
            this.dgw.Location = new System.Drawing.Point(11, 29);
            this.dgw.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dgw.MultiSelect = false;
            this.dgw.Name = "dgw";
            this.dgw.RowHeadersWidth = 25;
            this.dgw.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dgw.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.dgw.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgw.Size = new System.Drawing.Size(975, 320);
            this.dgw.TabIndex = 14;
            // 
            // BTN_ACEPTAR
            // 
            this.BTN_ACEPTAR.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BTN_ACEPTAR.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BTN_ACEPTAR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_ACEPTAR.Image = ((System.Drawing.Image)(resources.GetObject("BTN_ACEPTAR.Image")));
            this.BTN_ACEPTAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTN_ACEPTAR.Location = new System.Drawing.Point(824, 360);
            this.BTN_ACEPTAR.Name = "BTN_ACEPTAR";
            this.BTN_ACEPTAR.Size = new System.Drawing.Size(76, 27);
            this.BTN_ACEPTAR.TabIndex = 34;
            this.BTN_ACEPTAR.Text = "&Agregar";
            this.BTN_ACEPTAR.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTN_ACEPTAR.Click += new System.EventHandler(this.BTN_ACEPTAR_Click);
            // 
            // BTN_CANCELAR
            // 
            this.BTN_CANCELAR.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BTN_CANCELAR.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BTN_CANCELAR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_CANCELAR.Image = ((System.Drawing.Image)(resources.GetObject("BTN_CANCELAR.Image")));
            this.BTN_CANCELAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTN_CANCELAR.Location = new System.Drawing.Point(910, 360);
            this.BTN_CANCELAR.Name = "BTN_CANCELAR";
            this.BTN_CANCELAR.Size = new System.Drawing.Size(76, 27);
            this.BTN_CANCELAR.TabIndex = 35;
            this.BTN_CANCELAR.Text = "&Salir";
            // 
            // TIPO_VTA
            // 
            this.TIPO_VTA.HeaderText = "TIPO_VTA";
            this.TIPO_VTA.Name = "TIPO_VTA";
            this.TIPO_VTA.Visible = false;
            // 
            // COD_PROGRAMA
            // 
            this.COD_PROGRAMA.HeaderText = "COD_PROGRAMA";
            this.COD_PROGRAMA.Name = "COD_PROGRAMA";
            this.COD_PROGRAMA.Visible = false;
            // 
            // COD_VENDEDOR
            // 
            this.COD_VENDEDOR.HeaderText = "COD_VENDEDOR";
            this.COD_VENDEDOR.Name = "COD_VENDEDOR";
            this.COD_VENDEDOR.Visible = false;
            // 
            // DESC_PER
            // 
            this.DESC_PER.HeaderText = "Vendedor";
            this.DESC_PER.Name = "DESC_PER";
            // 
            // NRO_CONTRATO
            // 
            this.NRO_CONTRATO.HeaderText = "Contrato";
            this.NRO_CONTRATO.Name = "NRO_CONTRATO";
            // 
            // FE_CONTRATO
            // 
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.FE_CONTRATO.DefaultCellStyle = dataGridViewCellStyle1;
            this.FE_CONTRATO.HeaderText = "Fe Contrato";
            this.FE_CONTRATO.Name = "FE_CONTRATO";
            // 
            // FE_AÑO
            // 
            this.FE_AÑO.HeaderText = "FE_AÑO";
            this.FE_AÑO.Name = "FE_AÑO";
            this.FE_AÑO.Visible = false;
            // 
            // FE_MES
            // 
            this.FE_MES.HeaderText = "FE_MES";
            this.FE_MES.Name = "FE_MES";
            this.FE_MES.Visible = false;
            // 
            // FE_DOC
            // 
            this.FE_DOC.HeaderText = "Fe Doc";
            this.FE_DOC.Name = "FE_DOC";
            // 
            // COD_PER
            // 
            this.COD_PER.HeaderText = "COD_PER";
            this.COD_PER.Name = "COD_PER";
            this.COD_PER.Visible = false;
            // 
            // NOMCLI
            // 
            this.NOMCLI.HeaderText = "Cliente";
            this.NOMCLI.Name = "NOMCLI";
            // 
            // NRO_LETRA
            // 
            this.NRO_LETRA.HeaderText = "NRO_LETRA";
            this.NRO_LETRA.Name = "NRO_LETRA";
            // 
            // COD_NIVEL
            // 
            this.COD_NIVEL.HeaderText = "COD_NIVEL";
            this.COD_NIVEL.Name = "COD_NIVEL";
            this.COD_NIVEL.Visible = false;
            // 
            // DESC_NIVEL
            // 
            this.DESC_NIVEL.HeaderText = "Nivel";
            this.DESC_NIVEL.Name = "DESC_NIVEL";
            // 
            // IMP_FIN
            // 
            this.IMP_FIN.HeaderText = "Importe";
            this.IMP_FIN.Name = "IMP_FIN";
            // 
            // COD_PER_SUP
            // 
            this.COD_PER_SUP.HeaderText = "COD_PER_SUP";
            this.COD_PER_SUP.Name = "COD_PER_SUP";
            this.COD_PER_SUP.Visible = false;
            // 
            // NOMSUP
            // 
            this.NOMSUP.HeaderText = "Nivel Per";
            this.NOMSUP.Name = "NOMSUP";
            // 
            // X
            // 
            this.X.HeaderText = "X";
            this.X.Name = "X";
            // 
            // CONSULTA_PARA_COMISIONES_000
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 396);
            this.Controls.Add(this.BTN_ACEPTAR);
            this.Controls.Add(this.BTN_CANCELAR);
            this.Controls.Add(this.dgw);
            this.Name = "CONSULTA_PARA_COMISIONES_000";
            this.Text = "Consulta para Comisiones";
            this.Load += new System.EventHandler(this.CONSULTA_PARA_COMISIONES_000_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgw)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.DataGridView dgw;
        internal System.Windows.Forms.Button BTN_ACEPTAR;
        internal System.Windows.Forms.Button BTN_CANCELAR;
        private System.Windows.Forms.DataGridViewTextBoxColumn TIPO_VTA;
        private System.Windows.Forms.DataGridViewTextBoxColumn COD_PROGRAMA;
        private System.Windows.Forms.DataGridViewTextBoxColumn COD_VENDEDOR;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESC_PER;
        private System.Windows.Forms.DataGridViewTextBoxColumn NRO_CONTRATO;
        private System.Windows.Forms.DataGridViewTextBoxColumn FE_CONTRATO;
        private System.Windows.Forms.DataGridViewTextBoxColumn FE_AÑO;
        private System.Windows.Forms.DataGridViewTextBoxColumn FE_MES;
        private System.Windows.Forms.DataGridViewTextBoxColumn FE_DOC;
        private System.Windows.Forms.DataGridViewTextBoxColumn COD_PER;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOMCLI;
        private System.Windows.Forms.DataGridViewTextBoxColumn NRO_LETRA;
        private System.Windows.Forms.DataGridViewTextBoxColumn COD_NIVEL;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESC_NIVEL;
        private System.Windows.Forms.DataGridViewTextBoxColumn IMP_FIN;
        private System.Windows.Forms.DataGridViewTextBoxColumn COD_PER_SUP;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOMSUP;
        private System.Windows.Forms.DataGridViewCheckBoxColumn X;
    }
}