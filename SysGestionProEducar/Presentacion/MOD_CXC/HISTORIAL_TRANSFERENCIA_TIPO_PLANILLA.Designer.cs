namespace Presentacion.MOD_CXC
{
    partial class HISTORIAL_TRANSFERENCIA_TIPO_PLANILLA
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txt_nro_contrato = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgwHistorial = new System.Windows.Forms.DataGridView();
            this.FECHA_CAMBIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TIPO_PLANILLA_CAMBIADA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COD_MOTIVO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESC_MOTIVO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COD_AUTORIZADOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESC_AUTORIZADOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CUOTAS_CAMBIADAS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OBSERVACIONES = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbl_nro_reg_docs = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgwHistorial)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_nro_contrato
            // 
            this.txt_nro_contrato.BackColor = System.Drawing.Color.White;
            this.txt_nro_contrato.Location = new System.Drawing.Point(139, 12);
            this.txt_nro_contrato.Name = "txt_nro_contrato";
            this.txt_nro_contrato.ReadOnly = true;
            this.txt_nro_contrato.Size = new System.Drawing.Size(79, 20);
            this.txt_nro_contrato.TabIndex = 61;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 62;
            this.label2.Text = "Nro de Contrato";
            // 
            // dgwHistorial
            // 
            this.dgwHistorial.AllowUserToAddRows = false;
            this.dgwHistorial.AllowUserToDeleteRows = false;
            this.dgwHistorial.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgwHistorial.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 8.25F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgwHistorial.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgwHistorial.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FECHA_CAMBIO,
            this.TIPO_PLANILLA_CAMBIADA,
            this.COD_MOTIVO,
            this.DESC_MOTIVO,
            this.COD_AUTORIZADOR,
            this.DESC_AUTORIZADOR,
            this.CUOTAS_CAMBIADAS,
            this.OBSERVACIONES});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Arial", 8.25F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgwHistorial.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgwHistorial.Location = new System.Drawing.Point(17, 45);
            this.dgwHistorial.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dgwHistorial.MultiSelect = false;
            this.dgwHistorial.Name = "dgwHistorial";
            this.dgwHistorial.RowHeadersWidth = 25;
            this.dgwHistorial.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dgwHistorial.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.dgwHistorial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgwHistorial.Size = new System.Drawing.Size(868, 166);
            this.dgwHistorial.TabIndex = 69;
            this.dgwHistorial.TabStop = false;
            // 
            // FECHA_CAMBIO
            // 
            dataGridViewCellStyle5.Format = "d";
            dataGridViewCellStyle5.NullValue = null;
            this.FECHA_CAMBIO.DefaultCellStyle = dataGridViewCellStyle5;
            this.FECHA_CAMBIO.HeaderText = "Fec Cambio";
            this.FECHA_CAMBIO.Name = "FECHA_CAMBIO";
            this.FECHA_CAMBIO.Width = 80;
            // 
            // TIPO_PLANILLA_CAMBIADA
            // 
            this.TIPO_PLANILLA_CAMBIADA.HeaderText = "Tipo Plla";
            this.TIPO_PLANILLA_CAMBIADA.Name = "TIPO_PLANILLA_CAMBIADA";
            this.TIPO_PLANILLA_CAMBIADA.Width = 55;
            // 
            // COD_MOTIVO
            // 
            this.COD_MOTIVO.HeaderText = "COD_MOTIVO";
            this.COD_MOTIVO.Name = "COD_MOTIVO";
            this.COD_MOTIVO.Visible = false;
            // 
            // DESC_MOTIVO
            // 
            this.DESC_MOTIVO.HeaderText = "Motivo";
            this.DESC_MOTIVO.Name = "DESC_MOTIVO";
            this.DESC_MOTIVO.Width = 150;
            // 
            // COD_AUTORIZADOR
            // 
            this.COD_AUTORIZADOR.HeaderText = "COD_AUTORIZADOR";
            this.COD_AUTORIZADOR.Name = "COD_AUTORIZADOR";
            this.COD_AUTORIZADOR.Visible = false;
            // 
            // DESC_AUTORIZADOR
            // 
            this.DESC_AUTORIZADOR.HeaderText = "Autorizado por";
            this.DESC_AUTORIZADOR.Name = "DESC_AUTORIZADOR";
            this.DESC_AUTORIZADOR.Width = 200;
            // 
            // CUOTAS_CAMBIADAS
            // 
            this.CUOTAS_CAMBIADAS.HeaderText = "Cuotas Cambiadas";
            this.CUOTAS_CAMBIADAS.Name = "CUOTAS_CAMBIADAS";
            this.CUOTAS_CAMBIADAS.Width = 200;
            // 
            // OBSERVACIONES
            // 
            this.OBSERVACIONES.HeaderText = "Observaciones";
            this.OBSERVACIONES.Name = "OBSERVACIONES";
            this.OBSERVACIONES.Width = 200;
            // 
            // lbl_nro_reg_docs
            // 
            this.lbl_nro_reg_docs.AutoSize = true;
            this.lbl_nro_reg_docs.Location = new System.Drawing.Point(781, 15);
            this.lbl_nro_reg_docs.Name = "lbl_nro_reg_docs";
            this.lbl_nro_reg_docs.Size = new System.Drawing.Size(101, 13);
            this.lbl_nro_reg_docs.TabIndex = 71;
            this.lbl_nro_reg_docs.Text = "Nro de Registros : 0";
            // 
            // HISTORIAL_TRANSFERENCIA_TIPO_PLANILLA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 262);
            this.Controls.Add(this.lbl_nro_reg_docs);
            this.Controls.Add(this.dgwHistorial);
            this.Controls.Add(this.txt_nro_contrato);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "HISTORIAL_TRANSFERENCIA_TIPO_PLANILLA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Historial de Cambio de Planillas";
            this.Load += new System.EventHandler(this.HISTORIAL_TRANSFERENCIA_TIPO_PLANILLA_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgwHistorial)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox txt_nro_contrato;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.DataGridView dgwHistorial;
        private System.Windows.Forms.DataGridViewTextBoxColumn FECHA_CAMBIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn TIPO_PLANILLA_CAMBIADA;
        private System.Windows.Forms.DataGridViewTextBoxColumn COD_MOTIVO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESC_MOTIVO;
        private System.Windows.Forms.DataGridViewTextBoxColumn COD_AUTORIZADOR;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESC_AUTORIZADOR;
        private System.Windows.Forms.DataGridViewTextBoxColumn CUOTAS_CAMBIADAS;
        private System.Windows.Forms.DataGridViewTextBoxColumn OBSERVACIONES;
        internal System.Windows.Forms.Label lbl_nro_reg_docs;
    }
}