namespace Presentacion.MOD_FACT_VTA.MOD_VTA
{
    partial class CerrarEtapaDescuento
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblNroPlanilla = new System.Windows.Forms.Label();
            this.gbContent = new System.Windows.Forms.GroupBox();
            this.btnRegistrarLlamada = new System.Windows.Forms.Button();
            this.numImporte = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.gbContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numImporte)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel1.Controls.Add(this.lblEstado);
            this.panel1.Controls.Add(this.lblNroPlanilla);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(373, 27);
            this.panel1.TabIndex = 2;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(215, 6);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(63, 15);
            this.lblEstado.TabIndex = 1;
            this.lblEstado.Text = "Estado : ";
            // 
            // lblNroPlanilla
            // 
            this.lblNroPlanilla.AutoSize = true;
            this.lblNroPlanilla.Location = new System.Drawing.Point(8, 6);
            this.lblNroPlanilla.Name = "lblNroPlanilla";
            this.lblNroPlanilla.Size = new System.Drawing.Size(95, 15);
            this.lblNroPlanilla.TabIndex = 0;
            this.lblNroPlanilla.Text = "Nro Planilla : ";
            // 
            // gbContent
            // 
            this.gbContent.Controls.Add(this.numImporte);
            this.gbContent.Controls.Add(this.label3);
            this.gbContent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbContent.Location = new System.Drawing.Point(12, 45);
            this.gbContent.Name = "gbContent";
            this.gbContent.Size = new System.Drawing.Size(373, 128);
            this.gbContent.TabIndex = 3;
            this.gbContent.TabStop = false;
            // 
            // btnRegistrarLlamada
            // 
            this.btnRegistrarLlamada.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnRegistrarLlamada.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrarLlamada.ForeColor = System.Drawing.Color.White;
            this.btnRegistrarLlamada.Location = new System.Drawing.Point(64, 179);
            this.btnRegistrarLlamada.Name = "btnRegistrarLlamada";
            this.btnRegistrarLlamada.Size = new System.Drawing.Size(265, 38);
            this.btnRegistrarLlamada.TabIndex = 9;
            this.btnRegistrarLlamada.Text = "Grabar";
            this.btnRegistrarLlamada.UseVisualStyleBackColor = false;
            this.btnRegistrarLlamada.Click += new System.EventHandler(this.BtnRegistrarLlamada_Click);
            // 
            // numImporte
            // 
            this.numImporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numImporte.Location = new System.Drawing.Point(186, 52);
            this.numImporte.Name = "numImporte";
            this.numImporte.Size = new System.Drawing.Size(172, 24);
            this.numImporte.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(176, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Importe Descontado : ";
            // 
            // CerrarEtapaDescuento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(394, 236);
            this.Controls.Add(this.gbContent);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnRegistrarLlamada);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CerrarEtapaDescuento";
            this.Text = "Cerrar Etapa Descuento";
            this.Load += new System.EventHandler(this.CerrarEtapaDescuento_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gbContent.ResumeLayout(false);
            this.gbContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numImporte)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblNroPlanilla;
        private System.Windows.Forms.GroupBox gbContent;
        private System.Windows.Forms.Button btnRegistrarLlamada;
        private System.Windows.Forms.NumericUpDown numImporte;
        private System.Windows.Forms.Label label3;
    }
}