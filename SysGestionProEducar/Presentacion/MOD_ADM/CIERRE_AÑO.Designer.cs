namespace Presentacion.MOD_ADM
{
    partial class CIERRE_AÑO
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CIERRE_AÑO));
            this.Label1 = new System.Windows.Forms.Label();
            this.BTN_SALIR = new System.Windows.Forms.Button();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.BTN_CIERRE2 = new System.Windows.Forms.Button();
            this.btn_Cerrar = new System.Windows.Forms.Button();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Label1
            // 
            this.Label1.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(22, 131);
            this.Label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(242, 28);
            this.Label1.TabIndex = 9;
            this.Label1.Text = "En cualquier caso sea  transferencia o cancelación, el periodo activo debe ser el" +
    " último del año (Diciembre).";
            // 
            // BTN_SALIR
            // 
            this.BTN_SALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BTN_SALIR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_SALIR.Image = ((System.Drawing.Image)(resources.GetObject("BTN_SALIR.Image")));
            this.BTN_SALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTN_SALIR.Location = new System.Drawing.Point(267, 121);
            this.BTN_SALIR.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.BTN_SALIR.Name = "BTN_SALIR";
            this.BTN_SALIR.Size = new System.Drawing.Size(84, 39);
            this.BTN_SALIR.TabIndex = 8;
            this.BTN_SALIR.Text = "&Salir";
            this.BTN_SALIR.UseVisualStyleBackColor = true;
            this.BTN_SALIR.Click += new System.EventHandler(this.BTN_SALIR_Click);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.BTN_CIERRE2);
            this.GroupBox1.Controls.Add(this.btn_Cerrar);
            this.GroupBox1.Location = new System.Drawing.Point(24, 12);
            this.GroupBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.GroupBox1.Size = new System.Drawing.Size(328, 103);
            this.GroupBox1.TabIndex = 7;
            this.GroupBox1.TabStop = false;
            // 
            // BTN_CIERRE2
            // 
            this.BTN_CIERRE2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_CIERRE2.Image = ((System.Drawing.Image)(resources.GetObject("BTN_CIERRE2.Image")));
            this.BTN_CIERRE2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTN_CIERRE2.Location = new System.Drawing.Point(199, 41);
            this.BTN_CIERRE2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.BTN_CIERRE2.Name = "BTN_CIERRE2";
            this.BTN_CIERRE2.Size = new System.Drawing.Size(110, 37);
            this.BTN_CIERRE2.TabIndex = 7;
            this.BTN_CIERRE2.Text = "&Cancelar Cierre";
            this.BTN_CIERRE2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTN_CIERRE2.UseVisualStyleBackColor = true;
            this.BTN_CIERRE2.Click += new System.EventHandler(this.BTN_CIERRE2_Click);
            // 
            // btn_Cerrar
            // 
            this.btn_Cerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cerrar.Image = ((System.Drawing.Image)(resources.GetObject("btn_Cerrar.Image")));
            this.btn_Cerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Cerrar.Location = new System.Drawing.Point(25, 41);
            this.btn_Cerrar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_Cerrar.Name = "btn_Cerrar";
            this.btn_Cerrar.Size = new System.Drawing.Size(144, 37);
            this.btn_Cerrar.TabIndex = 2;
            this.btn_Cerrar.Text = "&Cierre de año";
            this.btn_Cerrar.UseVisualStyleBackColor = true;
            this.btn_Cerrar.Click += new System.EventHandler(this.btn_Cerrar_Click);
            // 
            // CIERRE_AÑO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 173);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.BTN_SALIR);
            this.Controls.Add(this.GroupBox1);
            this.Name = "CIERRE_AÑO";
            this.Text = "Cerrar Año";
            this.Load += new System.EventHandler(this.CIERRE_AÑO_Load);
            this.GroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Button BTN_SALIR;
        internal System.Windows.Forms.GroupBox GroupBox1;
        private System.Windows.Forms.Button BTN_CIERRE2;
        internal System.Windows.Forms.Button btn_Cerrar;
    }
}