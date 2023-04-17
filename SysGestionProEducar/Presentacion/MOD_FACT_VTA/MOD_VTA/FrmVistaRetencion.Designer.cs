
namespace Presentacion.MOD_FACT_VTA.MOD_VTA
{
    partial class FrmVistaRetencion
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
            this.dgvRetencion = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRetencion)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRetencion
            // 
            this.dgvRetencion.AllowUserToAddRows = false;
            this.dgvRetencion.AllowUserToDeleteRows = false;
            this.dgvRetencion.BackgroundColor = System.Drawing.Color.White;
            this.dgvRetencion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRetencion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRetencion.Location = new System.Drawing.Point(0, 0);
            this.dgvRetencion.Name = "dgvRetencion";
            this.dgvRetencion.ReadOnly = true;
            this.dgvRetencion.Size = new System.Drawing.Size(1104, 288);
            this.dgvRetencion.TabIndex = 0;
            // 
            // FrmVistaRetencion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1104, 288);
            this.Controls.Add(this.dgvRetencion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmVistaRetencion";
            this.Text = "Retenciones";
            this.Load += new System.EventHandler(this.FrmVistaRetencion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRetencion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRetencion;
    }
}