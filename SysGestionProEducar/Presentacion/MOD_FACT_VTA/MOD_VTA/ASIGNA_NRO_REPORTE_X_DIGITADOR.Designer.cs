namespace Presentacion.MOD_FACT_VTA.MOD_VTA
{
    partial class ASIGNA_NRO_REPORTE_X_DIGITADOR
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ASIGNA_NRO_REPORTE_X_DIGITADOR));
            this.cboDigitador = new System.Windows.Forms.ComboBox();
            this.label44 = new System.Windows.Forms.Label();
            this.dgw_det = new System.Windows.Forms.DataGridView();
            this.btn_grabar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.NRO_PRESUPUESTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESC_PER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgw_det)).BeginInit();
            this.SuspendLayout();
            // 
            // cboDigitador
            // 
            this.cboDigitador.BackColor = System.Drawing.Color.White;
            this.cboDigitador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDigitador.FormattingEnabled = true;
            this.cboDigitador.Location = new System.Drawing.Point(102, 23);
            this.cboDigitador.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cboDigitador.Name = "cboDigitador";
            this.cboDigitador.Size = new System.Drawing.Size(313, 21);
            this.cboDigitador.TabIndex = 217;
            this.cboDigitador.SelectionChangeCommitted += new System.EventHandler(this.cboDigitador_SelectionChangeCommitted);
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(36, 28);
            this.label44.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(49, 13);
            this.label44.TabIndex = 218;
            this.label44.Text = "Digitador";
            // 
            // dgw_det
            // 
            this.dgw_det.AllowUserToAddRows = false;
            this.dgw_det.AllowUserToDeleteRows = false;
            this.dgw_det.AllowUserToOrderColumns = true;
            this.dgw_det.AllowUserToResizeRows = false;
            this.dgw_det.BackgroundColor = System.Drawing.Color.White;
            this.dgw_det.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NRO_PRESUPUESTO,
            this.DESC_PER});
            this.dgw_det.Location = new System.Drawing.Point(11, 53);
            this.dgw_det.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dgw_det.MultiSelect = false;
            this.dgw_det.Name = "dgw_det";
            this.dgw_det.RowHeadersWidth = 25;
            this.dgw_det.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dgw_det.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.dgw_det.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgw_det.ShowCellErrors = false;
            this.dgw_det.ShowRowErrors = false;
            this.dgw_det.Size = new System.Drawing.Size(435, 214);
            this.dgw_det.TabIndex = 219;
            // 
            // btn_grabar
            // 
            this.btn_grabar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_grabar.Image = ((System.Drawing.Image)(resources.GetObject("btn_grabar.Image")));
            this.btn_grabar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_grabar.Location = new System.Drawing.Point(281, 273);
            this.btn_grabar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_grabar.Name = "btn_grabar";
            this.btn_grabar.Size = new System.Drawing.Size(84, 27);
            this.btn_grabar.TabIndex = 220;
            this.btn_grabar.Text = "&Grabar";
            this.btn_grabar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_grabar.UseVisualStyleBackColor = true;
            this.btn_grabar.Click += new System.EventHandler(this.btn_grabar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(369, 273);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(77, 27);
            this.btnCancelar.TabIndex = 221;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // NRO_PRESUPUESTO
            // 
            this.NRO_PRESUPUESTO.HeaderText = "Contrato";
            this.NRO_PRESUPUESTO.MinimumWidth = 50;
            this.NRO_PRESUPUESTO.Name = "NRO_PRESUPUESTO";
            this.NRO_PRESUPUESTO.Width = 70;
            // 
            // DESC_PER
            // 
            this.DESC_PER.HeaderText = "Cliente";
            this.DESC_PER.MinimumWidth = 200;
            this.DESC_PER.Name = "DESC_PER";
            this.DESC_PER.Width = 310;
            // 
            // ASIGNA_NRO_REPORTE_X_DIGITADOR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 315);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btn_grabar);
            this.Controls.Add(this.dgw_det);
            this.Controls.Add(this.cboDigitador);
            this.Controls.Add(this.label44);
            this.Name = "ASIGNA_NRO_REPORTE_X_DIGITADOR";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asigna Numero de Reporte x Digitador";
            this.Load += new System.EventHandler(this.ASIGNA_NRO_REPORTE_X_DIGITADOR_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgw_det)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ComboBox cboDigitador;
        internal System.Windows.Forms.Label label44;
        internal System.Windows.Forms.DataGridView dgw_det;
        internal System.Windows.Forms.Button btn_grabar;
        internal System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DataGridViewTextBoxColumn NRO_PRESUPUESTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESC_PER;
    }
}