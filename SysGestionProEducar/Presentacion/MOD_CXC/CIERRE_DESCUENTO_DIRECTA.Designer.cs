namespace Presentacion.MOD_CXC
{
    partial class CIERRE_DESCUENTO_DIRECTA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CIERRE_DESCUENTO_DIRECTA));
            this.lblfec_cierre = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btn_Cierre = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblfec_cierre
            // 
            this.lblfec_cierre.AutoSize = true;
            this.lblfec_cierre.Font = new System.Drawing.Font("Arial", 8.5F);
            this.lblfec_cierre.Location = new System.Drawing.Point(113, 114);
            this.lblfec_cierre.Name = "lblfec_cierre";
            this.lblfec_cierre.Size = new System.Drawing.Size(44, 15);
            this.lblfec_cierre.TabIndex = 36;
            this.lblfec_cierre.Text = "Fecha ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 8.5F);
            this.label10.Location = new System.Drawing.Point(83, 82);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(118, 15);
            this.label10.TabIndex = 35;
            this.label10.Text = "Fecha de Cierre del ";
            // 
            // btn_Cierre
            // 
            this.btn_Cierre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cierre.Image = ((System.Drawing.Image)(resources.GetObject("btn_Cierre.Image")));
            this.btn_Cierre.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Cierre.Location = new System.Drawing.Point(101, 152);
            this.btn_Cierre.Name = "btn_Cierre";
            this.btn_Cierre.Size = new System.Drawing.Size(77, 27);
            this.btn_Cierre.TabIndex = 34;
            this.btn_Cierre.Text = "&Cierre";
            this.btn_Cierre.UseVisualStyleBackColor = true;
            this.btn_Cierre.Click += new System.EventHandler(this.btn_Cierre_Click);
            // 
            // CIERRE_DESCUENTO_DIRECTA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.lblfec_cierre);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btn_Cierre);
            this.Name = "CIERRE_DESCUENTO_DIRECTA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cierre Descuento Directa";
            this.Load += new System.EventHandler(this.CIERRE_DESCUENTO_DIRECTA_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblfec_cierre;
        internal System.Windows.Forms.Label label10;
        internal System.Windows.Forms.Button btn_Cierre;
    }
}