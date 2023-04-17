
namespace Presentacion.MOD_COMISIONES
{
    partial class FrmEliminarComision
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.txtNroCuota = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nro Cuota";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(119, 144);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(151, 35);
            this.btnEliminar.TabIndex = 1;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // txtNroCuota
            // 
            this.txtNroCuota.Location = new System.Drawing.Point(117, 71);
            this.txtNroCuota.Name = "txtNroCuota";
            this.txtNroCuota.Size = new System.Drawing.Size(164, 20);
            this.txtNroCuota.TabIndex = 3;
            this.txtNroCuota.Text = "000";
            this.txtNroCuota.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNroCuota.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtNroCuota_KeyDown);
            this.txtNroCuota.Leave += new System.EventHandler(this.TxtNroCuota_Leave);
            // 
            // FrmEliminarComision
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 228);
            this.Controls.Add(this.txtNroCuota);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmEliminarComision";
            this.Text = "Eliminar Comisión";
            this.Load += new System.EventHandler(this.FrmEliminarComision_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNroCuota;
        internal System.Windows.Forms.Button btnEliminar;
    }
}