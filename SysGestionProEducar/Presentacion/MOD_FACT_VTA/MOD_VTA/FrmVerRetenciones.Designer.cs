
namespace Presentacion.MOD_FACT_VTA.MOD_VTA
{
    partial class FrmVerRetenciones
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
            this.dgvRetenciones = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRetenciones)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRetenciones
            // 
            this.dgvRetenciones.AllowUserToAddRows = false;
            this.dgvRetenciones.AllowUserToDeleteRows = false;
            this.dgvRetenciones.BackgroundColor = System.Drawing.Color.White;
            this.dgvRetenciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRetenciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRetenciones.Location = new System.Drawing.Point(0, 0);
            this.dgvRetenciones.Name = "dgvRetenciones";
            this.dgvRetenciones.ReadOnly = true;
            this.dgvRetenciones.Size = new System.Drawing.Size(1105, 327);
            this.dgvRetenciones.TabIndex = 0;
            // 
            // FrmVerRetenciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1105, 327);
            this.Controls.Add(this.dgvRetenciones);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmVerRetenciones";
            this.Text = "Retenciones";
            this.Load += new System.EventHandler(this.FrmVerRetenciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRetenciones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRetenciones;
    }
}