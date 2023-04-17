
namespace Presentacion.MOD_COMISIONES
{
    partial class FrmConsultaDevolucionContrato
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
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtNroContrato = new System.Windows.Forms.TextBox();
            this.dgvDevolContratos = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevolContratos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(1114, 12);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(78, 35);
            this.btnBuscar.TabIndex = 7;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // txtNroContrato
            // 
            this.txtNroContrato.Location = new System.Drawing.Point(72, 12);
            this.txtNroContrato.Name = "txtNroContrato";
            this.txtNroContrato.Size = new System.Drawing.Size(129, 20);
            this.txtNroContrato.TabIndex = 6;
            this.txtNroContrato.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNroContrato.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtNroContrato_KeyDown);
            // 
            // dgvDevolContratos
            // 
            this.dgvDevolContratos.BackgroundColor = System.Drawing.Color.White;
            this.dgvDevolContratos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDevolContratos.GridColor = System.Drawing.Color.DimGray;
            this.dgvDevolContratos.Location = new System.Drawing.Point(8, 56);
            this.dgvDevolContratos.Name = "dgvDevolContratos";
            this.dgvDevolContratos.Size = new System.Drawing.Size(1184, 281);
            this.dgvDevolContratos.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Contrato";
            // 
            // FrmConsultaDevolucionContrato
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1197, 340);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtNroContrato);
            this.Controls.Add(this.dgvDevolContratos);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmConsultaDevolucionContrato";
            this.Text = "Devoluciones por contrato";
            this.Load += new System.EventHandler(this.FrmConsultaDevolucionContrato_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevolContratos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView dgvDevolContratos;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txtNroContrato;
    }
}