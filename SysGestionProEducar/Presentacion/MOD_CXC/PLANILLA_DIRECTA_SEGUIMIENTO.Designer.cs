namespace Presentacion.MOD_CXC
{
    partial class PLANILLA_DIRECTA_SEGUIMIENTO
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PLANILLA_DIRECTA_SEGUIMIENTO));
            this.DGW_DETALLE = new System.Windows.Forms.DataGridView();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.tip_llamada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FECHA_LLAMADA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NRO_CUOTA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DES_LLAMADA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FECHA_NUEVA_LLAMADA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OBS_LLAMADA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbl_nro_llama = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGW_DETALLE)).BeginInit();
            this.SuspendLayout();
            // 
            // DGW_DETALLE
            // 
            this.DGW_DETALLE.AllowUserToAddRows = false;
            this.DGW_DETALLE.AllowUserToDeleteRows = false;
            this.DGW_DETALLE.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGW_DETALLE.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGW_DETALLE.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGW_DETALLE.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tip_llamada,
            this.FECHA_LLAMADA,
            this.NRO_CUOTA,
            this.DES_LLAMADA,
            this.FECHA_NUEVA_LLAMADA,
            this.OBS_LLAMADA});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGW_DETALLE.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGW_DETALLE.Location = new System.Drawing.Point(11, 19);
            this.DGW_DETALLE.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.DGW_DETALLE.MultiSelect = false;
            this.DGW_DETALLE.Name = "DGW_DETALLE";
            this.DGW_DETALLE.RowHeadersWidth = 25;
            this.DGW_DETALLE.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.DGW_DETALLE.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.DGW_DETALLE.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGW_DETALLE.Size = new System.Drawing.Size(701, 203);
            this.DGW_DETALLE.TabIndex = 32;
            this.DGW_DETALLE.TabStop = false;
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancelar.Image = ((System.Drawing.Image)(resources.GetObject("btn_cancelar.Image")));
            this.btn_cancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_cancelar.Location = new System.Drawing.Point(634, 233);
            this.btn_cancelar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(77, 27);
            this.btn_cancelar.TabIndex = 34;
            this.btn_cancelar.Text = "&Salir";
            this.btn_cancelar.UseVisualStyleBackColor = true;
            // 
            // tip_llamada
            // 
            this.tip_llamada.HeaderText = "Tip";
            this.tip_llamada.Name = "tip_llamada";
            this.tip_llamada.Width = 30;
            // 
            // FECHA_LLAMADA
            // 
            this.FECHA_LLAMADA.HeaderText = "F Llamada";
            this.FECHA_LLAMADA.Name = "FECHA_LLAMADA";
            this.FECHA_LLAMADA.Width = 80;
            // 
            // NRO_CUOTA
            // 
            this.NRO_CUOTA.HeaderText = "Cuota";
            this.NRO_CUOTA.Name = "NRO_CUOTA";
            this.NRO_CUOTA.Width = 60;
            // 
            // DES_LLAMADA
            // 
            this.DES_LLAMADA.HeaderText = "Respuesta";
            this.DES_LLAMADA.Name = "DES_LLAMADA";
            this.DES_LLAMADA.Width = 140;
            // 
            // FECHA_NUEVA_LLAMADA
            // 
            this.FECHA_NUEVA_LLAMADA.HeaderText = "F Nueva Llamada";
            this.FECHA_NUEVA_LLAMADA.Name = "FECHA_NUEVA_LLAMADA";
            // 
            // OBS_LLAMADA
            // 
            this.OBS_LLAMADA.HeaderText = "Observaciones";
            this.OBS_LLAMADA.Name = "OBS_LLAMADA";
            this.OBS_LLAMADA.Width = 250;
            // 
            // lbl_nro_llama
            // 
            this.lbl_nro_llama.AutoSize = true;
            this.lbl_nro_llama.Font = new System.Drawing.Font("Arial", 8.25F);
            this.lbl_nro_llama.Location = new System.Drawing.Point(105, 240);
            this.lbl_nro_llama.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_nro_llama.Name = "lbl_nro_llama";
            this.lbl_nro_llama.Size = new System.Drawing.Size(43, 14);
            this.lbl_nro_llama.TabIndex = 36;
            this.lbl_nro_llama.Text = "llamada";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 8.25F);
            this.label10.Location = new System.Drawing.Point(12, 240);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(92, 14);
            this.label10.TabIndex = 35;
            this.label10.Text = "Nro de LLamadas";
            // 
            // PLANILLA_DIRECTA_SEGUIMIENTO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 269);
            this.Controls.Add(this.lbl_nro_llama);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btn_cancelar);
            this.Controls.Add(this.DGW_DETALLE);
            this.Name = "PLANILLA_DIRECTA_SEGUIMIENTO";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HISTORIAL DE LLAMADAS";
            ((System.ComponentModel.ISupportInitialize)(this.DGW_DETALLE)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.DataGridView DGW_DETALLE;
        internal System.Windows.Forms.Button btn_cancelar;
        private System.Windows.Forms.DataGridViewTextBoxColumn tip_llamada;
        private System.Windows.Forms.DataGridViewTextBoxColumn FECHA_LLAMADA;
        private System.Windows.Forms.DataGridViewTextBoxColumn NRO_CUOTA;
        private System.Windows.Forms.DataGridViewTextBoxColumn DES_LLAMADA;
        private System.Windows.Forms.DataGridViewTextBoxColumn FECHA_NUEVA_LLAMADA;
        private System.Windows.Forms.DataGridViewTextBoxColumn OBS_LLAMADA;
        internal System.Windows.Forms.Label lbl_nro_llama;
        internal System.Windows.Forms.Label label10;
    }
}