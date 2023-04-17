namespace Presentacion.MOD_ALM.Reportes.Formulario
{
    partial class DEVOLUCION_DE_MERCADERIAS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DEVOLUCION_DE_MERCADERIAS));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbo_prog = new System.Windows.Forms.ComboBox();
            this.Label29 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.gb1 = new System.Windows.Forms.GroupBox();
            this.btn_impresion = new System.Windows.Forms.Button();
            this.btn_pantalla = new System.Windows.Forms.Button();
            this.btn_salir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp_desde = new System.Windows.Forms.DateTimePicker();
            this.dtp_hasta = new System.Windows.Forms.DateTimePicker();
            this.groupBox1.SuspendLayout();
            this.gb1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtp_hasta);
            this.groupBox1.Controls.Add(this.dtp_desde);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbo_prog);
            this.groupBox1.Controls.Add(this.Label29);
            this.groupBox1.Controls.Add(this.Label7);
            this.groupBox1.Location = new System.Drawing.Point(12, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(495, 129);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // cbo_prog
            // 
            this.cbo_prog.BackColor = System.Drawing.Color.White;
            this.cbo_prog.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_prog.FormattingEnabled = true;
            this.cbo_prog.Location = new System.Drawing.Point(89, 31);
            this.cbo_prog.Name = "cbo_prog";
            this.cbo_prog.Size = new System.Drawing.Size(393, 21);
            this.cbo_prog.TabIndex = 59;
            // 
            // Label29
            // 
            this.Label29.AutoSize = true;
            this.Label29.Location = new System.Drawing.Point(10, 36);
            this.Label29.Name = "Label29";
            this.Label29.Size = new System.Drawing.Size(52, 13);
            this.Label29.TabIndex = 60;
            this.Label29.Text = "Programa";
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label7.Location = new System.Drawing.Point(10, 83);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(73, 14);
            this.Label7.TabIndex = 47;
            this.Label7.Text = "Fecha desde ";
            // 
            // gb1
            // 
            this.gb1.BackColor = System.Drawing.Color.White;
            this.gb1.Controls.Add(this.btn_impresion);
            this.gb1.Controls.Add(this.btn_pantalla);
            this.gb1.Controls.Add(this.btn_salir);
            this.gb1.Location = new System.Drawing.Point(12, 149);
            this.gb1.Name = "gb1";
            this.gb1.Size = new System.Drawing.Size(495, 54);
            this.gb1.TabIndex = 9;
            this.gb1.TabStop = false;
            // 
            // btn_impresion
            // 
            this.btn_impresion.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_impresion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_impresion.Image = ((System.Drawing.Image)(resources.GetObject("btn_impresion.Image")));
            this.btn_impresion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_impresion.Location = new System.Drawing.Point(207, 15);
            this.btn_impresion.Name = "btn_impresion";
            this.btn_impresion.Size = new System.Drawing.Size(77, 27);
            this.btn_impresion.TabIndex = 17;
            this.btn_impresion.Text = "&Imprimir";
            this.btn_impresion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_impresion.UseVisualStyleBackColor = false;
            // 
            // btn_pantalla
            // 
            this.btn_pantalla.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_pantalla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_pantalla.Image = ((System.Drawing.Image)(resources.GetObject("btn_pantalla.Image")));
            this.btn_pantalla.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_pantalla.Location = new System.Drawing.Point(114, 15);
            this.btn_pantalla.Name = "btn_pantalla";
            this.btn_pantalla.Size = new System.Drawing.Size(77, 27);
            this.btn_pantalla.TabIndex = 15;
            this.btn_pantalla.Text = "&Pantalla";
            this.btn_pantalla.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_pantalla.UseVisualStyleBackColor = false;
            this.btn_pantalla.Click += new System.EventHandler(this.btn_pantalla_Click);
            // 
            // btn_salir
            // 
            this.btn_salir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_salir.Image = ((System.Drawing.Image)(resources.GetObject("btn_salir.Image")));
            this.btn_salir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_salir.Location = new System.Drawing.Point(301, 15);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(75, 26);
            this.btn_salir.TabIndex = 19;
            this.btn_salir.Text = "&Salir";
            this.btn_salir.UseVisualStyleBackColor = true;
            this.btn_salir.Click += new System.EventHandler(this.btn_salir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(326, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 14);
            this.label1.TabIndex = 61;
            this.label1.Text = "Fecha hasta";
            // 
            // dtp_desde
            // 
            this.dtp_desde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_desde.Location = new System.Drawing.Point(89, 77);
            this.dtp_desde.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dtp_desde.Name = "dtp_desde";
            this.dtp_desde.Size = new System.Drawing.Size(80, 20);
            this.dtp_desde.TabIndex = 62;
            this.dtp_desde.TabStop = false;
            // 
            // dtp_hasta
            // 
            this.dtp_hasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_hasta.Location = new System.Drawing.Point(401, 77);
            this.dtp_hasta.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dtp_hasta.Name = "dtp_hasta";
            this.dtp_hasta.Size = new System.Drawing.Size(80, 20);
            this.dtp_hasta.TabIndex = 63;
            this.dtp_hasta.TabStop = false;
            // 
            // DEVOLUCION_DE_MERCADERIAS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 217);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gb1);
            this.Name = "DEVOLUCION_DE_MERCADERIAS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte de Devolucion de Mercaderías";
            this.Load += new System.EventHandler(this.DEVOLUCION_DE_MERCADERIAS_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gb1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.ComboBox cbo_prog;
        internal System.Windows.Forms.Label Label29;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.GroupBox gb1;
        internal System.Windows.Forms.Button btn_impresion;
        internal System.Windows.Forms.Button btn_pantalla;
        internal System.Windows.Forms.Button btn_salir;
        internal System.Windows.Forms.DateTimePicker dtp_hasta;
        internal System.Windows.Forms.DateTimePicker dtp_desde;

    }
}