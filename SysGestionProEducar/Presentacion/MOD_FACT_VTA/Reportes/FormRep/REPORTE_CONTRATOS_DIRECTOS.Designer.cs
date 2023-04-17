namespace Presentacion.MOD_FACT_VTA.Reportes.FormRep
{
    partial class REPORTE_CONTRATOS_DIRECTOS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(REPORTE_CONTRATOS_DIRECTOS));
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.cbo_sucursal = new System.Windows.Forms.ComboBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.cbo_año = new System.Windows.Forms.ComboBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.cbo_clase = new System.Windows.Forms.ComboBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.cbo_mes = new System.Windows.Forms.ComboBox();
            this.gb1 = new System.Windows.Forms.GroupBox();
            this.btn_imprimir = new System.Windows.Forms.Button();
            this.BTN_SALIR = new System.Windows.Forms.Button();
            this.GroupBox1.SuspendLayout();
            this.gb1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.cbo_sucursal);
            this.GroupBox1.Controls.Add(this.Label4);
            this.GroupBox1.Controls.Add(this.cbo_año);
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Controls.Add(this.cbo_clase);
            this.GroupBox1.Controls.Add(this.Label5);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.cbo_mes);
            this.GroupBox1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox1.Location = new System.Drawing.Point(20, 3);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(439, 114);
            this.GroupBox1.TabIndex = 29;
            this.GroupBox1.TabStop = false;
            // 
            // cbo_sucursal
            // 
            this.cbo_sucursal.BackColor = System.Drawing.Color.White;
            this.cbo_sucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_sucursal.FormattingEnabled = true;
            this.cbo_sucursal.Location = new System.Drawing.Point(85, 23);
            this.cbo_sucursal.Name = "cbo_sucursal";
            this.cbo_sucursal.Size = new System.Drawing.Size(324, 22);
            this.cbo_sucursal.TabIndex = 118;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(29, 29);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(50, 14);
            this.Label4.TabIndex = 120;
            this.Label4.Text = "Sucursal";
            // 
            // cbo_año
            // 
            this.cbo_año.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_año.FormattingEnabled = true;
            this.cbo_año.Location = new System.Drawing.Point(84, 79);
            this.cbo_año.Name = "cbo_año";
            this.cbo_año.Size = new System.Drawing.Size(73, 22);
            this.cbo_año.TabIndex = 114;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(33, 82);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(27, 14);
            this.Label3.TabIndex = 112;
            this.Label3.Text = "Año";
            // 
            // cbo_clase
            // 
            this.cbo_clase.BackColor = System.Drawing.Color.White;
            this.cbo_clase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_clase.FormattingEnabled = true;
            this.cbo_clase.Items.AddRange(new object[] {
            "2",
            "3",
            "8"});
            this.cbo_clase.Location = new System.Drawing.Point(85, 51);
            this.cbo_clase.Name = "cbo_clase";
            this.cbo_clase.Size = new System.Drawing.Size(324, 22);
            this.cbo_clase.TabIndex = 1;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.Location = new System.Drawing.Point(29, 57);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(37, 14);
            this.Label5.TabIndex = 34;
            this.Label5.Text = "Clase ";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(249, 83);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(27, 14);
            this.Label2.TabIndex = 5;
            this.Label2.Text = "Mes";
            // 
            // cbo_mes
            // 
            this.cbo_mes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_mes.FormattingEnabled = true;
            this.cbo_mes.Items.AddRange(new object[] {
            "ENERO",
            "FEBRERO",
            "MARZO",
            "ABRIL",
            "MAYO",
            "JUNIO",
            "JULIO",
            "AGOSTO",
            "SETIEMBRE",
            "OCTUBRE",
            "NOVIEMBRE",
            "DICIEMBRE"});
            this.cbo_mes.Location = new System.Drawing.Point(281, 79);
            this.cbo_mes.Name = "cbo_mes";
            this.cbo_mes.Size = new System.Drawing.Size(126, 22);
            this.cbo_mes.TabIndex = 3;
            // 
            // gb1
            // 
            this.gb1.BackColor = System.Drawing.Color.White;
            this.gb1.Controls.Add(this.BTN_SALIR);
            this.gb1.Controls.Add(this.btn_imprimir);
            this.gb1.Location = new System.Drawing.Point(110, 134);
            this.gb1.Name = "gb1";
            this.gb1.Size = new System.Drawing.Size(261, 56);
            this.gb1.TabIndex = 30;
            this.gb1.TabStop = false;
            // 
            // btn_imprimir
            // 
            this.btn_imprimir.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_imprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_imprimir.Image = ((System.Drawing.Image)(resources.GetObject("btn_imprimir.Image")));
            this.btn_imprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_imprimir.Location = new System.Drawing.Point(38, 17);
            this.btn_imprimir.Name = "btn_imprimir";
            this.btn_imprimir.Size = new System.Drawing.Size(77, 27);
            this.btn_imprimir.TabIndex = 1;
            this.btn_imprimir.Text = "&Imprimir";
            this.btn_imprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_imprimir.UseVisualStyleBackColor = false;
            this.btn_imprimir.Click += new System.EventHandler(this.btn_imprimir_Click);
            // 
            // BTN_SALIR
            // 
            this.BTN_SALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BTN_SALIR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_SALIR.Image = ((System.Drawing.Image)(resources.GetObject("BTN_SALIR.Image")));
            this.BTN_SALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTN_SALIR.Location = new System.Drawing.Point(150, 17);
            this.BTN_SALIR.Name = "BTN_SALIR";
            this.BTN_SALIR.Size = new System.Drawing.Size(77, 27);
            this.BTN_SALIR.TabIndex = 6;
            this.BTN_SALIR.TabStop = false;
            this.BTN_SALIR.Text = "&Salir";
            this.BTN_SALIR.UseVisualStyleBackColor = true;
            this.BTN_SALIR.Click += new System.EventHandler(this.BTN_SALIR_Click);
            // 
            // REPORTE_CONTRATOS_DIRECTOS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 215);
            this.Controls.Add(this.gb1);
            this.Controls.Add(this.GroupBox1);
            this.Name = "REPORTE_CONTRATOS_DIRECTOS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte de Contratos Directos";
            this.Load += new System.EventHandler(this.REPORTE_CONTRATOS_DIRECTOS_Load);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.gb1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.ComboBox cbo_sucursal;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.ComboBox cbo_año;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.ComboBox cbo_clase;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.ComboBox cbo_mes;
        internal System.Windows.Forms.GroupBox gb1;
        internal System.Windows.Forms.Button btn_imprimir;
        internal System.Windows.Forms.Button BTN_SALIR;
    }
}