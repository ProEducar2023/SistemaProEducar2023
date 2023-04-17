namespace Presentacion.MOD_COMISIONES
{
    partial class CONSULTA_KARDEX_X_CONTRATO
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgw = new System.Windows.Forms.DataGridView();
            this.NRO_CONTRATO1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NRO_DOC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FECHA_DOC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FECHA_VEN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CUOTA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COD_D_H = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IMP_DOC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SALDO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OBSERVACION = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.NRO_CONTRATO1,
            this.NRO_DOC,
            this.FECHA_DOC,
            this.FECHA_VEN,
            this.CUOTA,
            this.COD_D_H,
            this.IMP_DOC,
            this.SALDO,
            this.OBSERVACION});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgw.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgw.Location = new System.Drawing.Point(11, 12);
            this.dgw.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dgw.MultiSelect = false;
            this.dgw.Name = "dgw";
            this.dgw.ReadOnly = true;
            this.dgw.RowHeadersWidth = 25;
            this.dgw.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dgw.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.dgw.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgw.Size = new System.Drawing.Size(650, 396);
            this.dgw.TabIndex = 50;
            this.dgw.SelectionChanged += new System.EventHandler(this.dgw_SelectionChanged);
            // 
            // NRO_CONTRATO1
            // 
            this.NRO_CONTRATO1.HeaderText = "NRO_CONTRATO1";
            this.NRO_CONTRATO1.Name = "NRO_CONTRATO1";
            this.NRO_CONTRATO1.ReadOnly = true;
            this.NRO_CONTRATO1.Visible = false;
            // 
            // NRO_DOC
            // 
            this.NRO_DOC.HeaderText = "Nro Docu";
            this.NRO_DOC.Name = "NRO_DOC";
            this.NRO_DOC.ReadOnly = true;
            this.NRO_DOC.Width = 70;
            // 
            // FECHA_DOC
            // 
            this.FECHA_DOC.HeaderText = "Fe Docu";
            this.FECHA_DOC.Name = "FECHA_DOC";
            this.FECHA_DOC.ReadOnly = true;
            this.FECHA_DOC.Width = 70;
            // 
            // FECHA_VEN
            // 
            this.FECHA_VEN.HeaderText = "Fe Venci";
            this.FECHA_VEN.Name = "FECHA_VEN";
            this.FECHA_VEN.ReadOnly = true;
            this.FECHA_VEN.Width = 70;
            // 
            // CUOTA
            // 
            this.CUOTA.HeaderText = "Cuota";
            this.CUOTA.Name = "CUOTA";
            this.CUOTA.ReadOnly = true;
            this.CUOTA.Width = 60;
            // 
            // COD_D_H
            // 
            this.COD_D_H.HeaderText = "D/H";
            this.COD_D_H.Name = "COD_D_H";
            this.COD_D_H.ReadOnly = true;
            this.COD_D_H.Width = 40;
            // 
            // IMP_DOC
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.IMP_DOC.DefaultCellStyle = dataGridViewCellStyle1;
            this.IMP_DOC.HeaderText = "Importe";
            this.IMP_DOC.Name = "IMP_DOC";
            this.IMP_DOC.ReadOnly = true;
            this.IMP_DOC.Width = 70;
            // 
            // SALDO
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.SALDO.DefaultCellStyle = dataGridViewCellStyle2;
            this.SALDO.HeaderText = "Saldo";
            this.SALDO.Name = "SALDO";
            this.SALDO.ReadOnly = true;
            this.SALDO.Width = 70;
            // 
            // OBSERVACION
            // 
            this.OBSERVACION.HeaderText = "Obs";
            this.OBSERVACION.Name = "OBSERVACION";
            this.OBSERVACION.ReadOnly = true;
            this.OBSERVACION.Width = 150;
            // 
            // CONSULTA_KARDEX_X_CONTRATO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 430);
            this.Controls.Add(this.dgw);
            this.Name = "CONSULTA_KARDEX_X_CONTRATO";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kardex Historico por Contrato";
            this.Load += new System.EventHandler(this.CONSULTA_KARDEX_X_CONTRATO_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgw)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.DataGridView dgw;
        private System.Windows.Forms.DataGridViewTextBoxColumn NRO_CONTRATO1;
        private System.Windows.Forms.DataGridViewTextBoxColumn NRO_DOC;
        private System.Windows.Forms.DataGridViewTextBoxColumn FECHA_DOC;
        private System.Windows.Forms.DataGridViewTextBoxColumn FECHA_VEN;
        private System.Windows.Forms.DataGridViewTextBoxColumn CUOTA;
        private System.Windows.Forms.DataGridViewTextBoxColumn COD_D_H;
        private System.Windows.Forms.DataGridViewTextBoxColumn IMP_DOC;
        private System.Windows.Forms.DataGridViewTextBoxColumn SALDO;
        private System.Windows.Forms.DataGridViewTextBoxColumn OBSERVACION;
    }
}