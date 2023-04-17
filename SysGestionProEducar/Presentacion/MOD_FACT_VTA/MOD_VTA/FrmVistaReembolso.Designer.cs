
namespace Presentacion.MOD_FACT_VTA.MOD_VTA
{
    partial class FrmVistaReembolso
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
            this.dgvReembolso = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReembolso)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvReembolso
            // 
            this.dgvReembolso.AllowUserToAddRows = false;
            this.dgvReembolso.AllowUserToDeleteRows = false;
            this.dgvReembolso.BackgroundColor = System.Drawing.Color.White;
            this.dgvReembolso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReembolso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReembolso.Location = new System.Drawing.Point(0, 0);
            this.dgvReembolso.Name = "dgvReembolso";
            this.dgvReembolso.ReadOnly = true;
            this.dgvReembolso.Size = new System.Drawing.Size(599, 493);
            this.dgvReembolso.TabIndex = 1;
            // 
            // FrmVistaReembolso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 493);
            this.Controls.Add(this.dgvReembolso);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmVistaReembolso";
            this.Text = "Listado de Reembolsos";
            this.Load += new System.EventHandler(this.FrmListadoReembolso_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReembolso)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvReembolso;
    }
}