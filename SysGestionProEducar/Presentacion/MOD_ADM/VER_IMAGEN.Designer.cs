namespace Presentacion.MOD_ADM
{
    partial class VER_IMAGEN
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
            this.pcb_foto = new System.Windows.Forms.PictureBox();
            this.btn_salir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pcb_foto)).BeginInit();
            this.SuspendLayout();
            // 
            // pcb_foto
            // 
            this.pcb_foto.Location = new System.Drawing.Point(27, 20);
            this.pcb_foto.Name = "pcb_foto";
            this.pcb_foto.Size = new System.Drawing.Size(178, 185);
            this.pcb_foto.TabIndex = 0;
            this.pcb_foto.TabStop = false;
            // 
            // btn_salir
            // 
            this.btn_salir.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_salir.Location = new System.Drawing.Point(130, 213);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(75, 23);
            this.btn_salir.TabIndex = 2;
            this.btn_salir.Text = "Salir";
            this.btn_salir.UseVisualStyleBackColor = true;
            // 
            // VER_IMAGEN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(233, 241);
            this.Controls.Add(this.btn_salir);
            this.Controls.Add(this.pcb_foto);
            this.Name = "VER_IMAGEN";
            this.Text = "Imagen";
            this.Load += new System.EventHandler(this.VER_IMAGEN_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pcb_foto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pcb_foto;
        private System.Windows.Forms.Button btn_salir;
    }
}