namespace Presentacion.REPORTES.FORM_REPORTES
{
    partial class REPORTE_GRUPO
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
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.cbo_g = new System.Windows.Forms.ComboBox();
            this.btn_aceptar = new System.Windows.Forms.Button();
            this.ch_g = new System.Windows.Forms.CheckBox();
            this.cbo_clase = new System.Windows.Forms.ComboBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.btn_salir = new System.Windows.Forms.Button();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.cbo_g);
            this.GroupBox1.Controls.Add(this.btn_aceptar);
            this.GroupBox1.Controls.Add(this.ch_g);
            this.GroupBox1.Controls.Add(this.cbo_clase);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Controls.Add(this.btn_salir);
            this.GroupBox1.Location = new System.Drawing.Point(68, 56);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(445, 200);
            this.GroupBox1.TabIndex = 1;
            this.GroupBox1.TabStop = false;
            // 
            // cbo_g
            // 
            this.cbo_g.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_g.FormattingEnabled = true;
            this.cbo_g.Location = new System.Drawing.Point(128, 53);
            this.cbo_g.Name = "cbo_g";
            this.cbo_g.Size = new System.Drawing.Size(248, 21);
            this.cbo_g.TabIndex = 3;
            // 
            // btn_aceptar
            // 
            this.btn_aceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_aceptar.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_aceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_aceptar.Location = new System.Drawing.Point(216, 143);
            this.btn_aceptar.Name = "btn_aceptar";
            this.btn_aceptar.Size = new System.Drawing.Size(77, 27);
            this.btn_aceptar.TabIndex = 4;
            this.btn_aceptar.Text = "&Aceptar";
            this.btn_aceptar.UseVisualStyleBackColor = true;
            // 
            // ch_g
            // 
            this.ch_g.AutoSize = true;
            this.ch_g.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ch_g.Location = new System.Drawing.Point(107, 55);
            this.ch_g.Name = "ch_g";
            this.ch_g.Size = new System.Drawing.Size(15, 14);
            this.ch_g.TabIndex = 2;
            this.ch_g.UseVisualStyleBackColor = true;
            // 
            // cbo_clase
            // 
            this.cbo_clase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_clase.FormattingEnabled = true;
            this.cbo_clase.Items.AddRange(new object[] {
            "Natural",
            "Juridica"});
            this.cbo_clase.Location = new System.Drawing.Point(128, 23);
            this.cbo_clase.Name = "cbo_clase";
            this.cbo_clase.Size = new System.Drawing.Size(248, 21);
            this.cbo_clase.TabIndex = 1;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(32, 26);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(34, 14);
            this.Label2.TabIndex = 3;
            this.Label2.Text = "Clase";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(32, 56);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(37, 14);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Grupo";
            // 
            // btn_salir
            // 
            this.btn_salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_salir.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_salir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_salir.Location = new System.Drawing.Point(299, 143);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(77, 27);
            this.btn_salir.TabIndex = 5;
            this.btn_salir.Text = "&Salir";
            this.btn_salir.UseVisualStyleBackColor = true;
            // 
            // REPORTE_GRUPO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 312);
            this.Controls.Add(this.GroupBox1);
            this.Name = "REPORTE_GRUPO";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte de Clase de Grupos ";
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.ComboBox cbo_g;
        internal System.Windows.Forms.Button btn_aceptar;
        internal System.Windows.Forms.CheckBox ch_g;
        internal System.Windows.Forms.ComboBox cbo_clase;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Button btn_salir;
    }
}