namespace Presentacion.DIALOGOS
{
    partial class frmDetraccion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDetraccion));
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.txtPorDetraccion = new System.Windows.Forms.TextBox();
            this.lblPorDetraccion = new System.Windows.Forms.Label();
            this.txtValorDetraccion = new System.Windows.Forms.TextBox();
            this.lblValorDetraccion = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.Location = new System.Drawing.Point(212, 79);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(86, 23);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnAceptar
            // 
            this.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAceptar.Location = new System.Drawing.Point(119, 79);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(87, 23);
            this.btnAceptar.TabIndex = 9;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            // 
            // txtPorDetraccion
            // 
            this.txtPorDetraccion.Location = new System.Drawing.Point(130, 43);
            this.txtPorDetraccion.Name = "txtPorDetraccion";
            this.txtPorDetraccion.Size = new System.Drawing.Size(168, 20);
            this.txtPorDetraccion.TabIndex = 8;
            this.txtPorDetraccion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPorDetraccion_KeyDown);
            // 
            // lblPorDetraccion
            // 
            this.lblPorDetraccion.AutoSize = true;
            this.lblPorDetraccion.Location = new System.Drawing.Point(15, 46);
            this.lblPorDetraccion.Name = "lblPorDetraccion";
            this.lblPorDetraccion.Size = new System.Drawing.Size(113, 13);
            this.lblPorDetraccion.TabIndex = 10;
            this.lblPorDetraccion.Text = "Porcentaje Detracción";
            // 
            // txtValorDetraccion
            // 
            this.txtValorDetraccion.Location = new System.Drawing.Point(129, 15);
            this.txtValorDetraccion.Name = "txtValorDetraccion";
            this.txtValorDetraccion.Size = new System.Drawing.Size(169, 20);
            this.txtValorDetraccion.TabIndex = 6;
            this.txtValorDetraccion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtValorDetraccion_KeyDown);
            // 
            // lblValorDetraccion
            // 
            this.lblValorDetraccion.AutoSize = true;
            this.lblValorDetraccion.Location = new System.Drawing.Point(39, 18);
            this.lblValorDetraccion.Name = "lblValorDetraccion";
            this.lblValorDetraccion.Size = new System.Drawing.Size(86, 13);
            this.lblValorDetraccion.TabIndex = 7;
            this.lblValorDetraccion.Text = "Valor Detracción";
            // 
            // frmDetraccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 116);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtPorDetraccion);
            this.Controls.Add(this.lblPorDetraccion);
            this.Controls.Add(this.txtValorDetraccion);
            this.Controls.Add(this.lblValorDetraccion);
            this.Name = "frmDetraccion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detraccion";
            this.Load += new System.EventHandler(this.frmDetraccion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button btnCancelar;
        internal System.Windows.Forms.Button btnAceptar;
        internal System.Windows.Forms.TextBox txtPorDetraccion;
        internal System.Windows.Forms.Label lblPorDetraccion;
        internal System.Windows.Forms.TextBox txtValorDetraccion;
        internal System.Windows.Forms.Label lblValorDetraccion;
    }
}