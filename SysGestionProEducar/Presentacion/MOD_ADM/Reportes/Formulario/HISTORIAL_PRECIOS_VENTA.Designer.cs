namespace Presentacion.MOD_ADM.Reportes.Formulario
{
    partial class HISTORIAL_PRECIOS_VENTA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HISTORIAL_PRECIOS_VENTA));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbo_kit = new System.Windows.Forms.ComboBox();
            this.cbo_grupo = new System.Windows.Forms.ComboBox();
            this.dtp_al = new System.Windows.Forms.DateTimePicker();
            this.dtp_del = new System.Windows.Forms.DateTimePicker();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Label29 = new System.Windows.Forms.Label();
            this.gb1 = new System.Windows.Forms.GroupBox();
            this.btn_impresion = new System.Windows.Forms.Button();
            this.btn_pantalla = new System.Windows.Forms.Button();
            this.btn_salir = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.gb1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbo_kit);
            this.groupBox1.Controls.Add(this.cbo_grupo);
            this.groupBox1.Controls.Add(this.dtp_al);
            this.groupBox1.Controls.Add(this.dtp_del);
            this.groupBox1.Controls.Add(this.Label5);
            this.groupBox1.Controls.Add(this.Label6);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.Label29);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(412, 102);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // cbo_kit
            // 
            this.cbo_kit.BackColor = System.Drawing.Color.White;
            this.cbo_kit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_kit.FormattingEnabled = true;
            this.cbo_kit.Location = new System.Drawing.Point(69, 69);
            this.cbo_kit.Name = "cbo_kit";
            this.cbo_kit.Size = new System.Drawing.Size(328, 21);
            this.cbo_kit.TabIndex = 9;
            // 
            // cbo_grupo
            // 
            this.cbo_grupo.BackColor = System.Drawing.Color.White;
            this.cbo_grupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_grupo.FormattingEnabled = true;
            this.cbo_grupo.Location = new System.Drawing.Point(69, 42);
            this.cbo_grupo.Name = "cbo_grupo";
            this.cbo_grupo.Size = new System.Drawing.Size(328, 21);
            this.cbo_grupo.TabIndex = 7;
            this.cbo_grupo.SelectedIndexChanged += new System.EventHandler(this.cbo_grupo_SelectedIndexChanged);
            // 
            // dtp_al
            // 
            this.dtp_al.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_al.Location = new System.Drawing.Point(178, 16);
            this.dtp_al.Name = "dtp_al";
            this.dtp_al.Size = new System.Drawing.Size(80, 20);
            this.dtp_al.TabIndex = 5;
            // 
            // dtp_del
            // 
            this.dtp_del.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_del.Location = new System.Drawing.Point(70, 16);
            this.dtp_del.Name = "dtp_del";
            this.dtp_del.Size = new System.Drawing.Size(80, 20);
            this.dtp_del.TabIndex = 3;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(155, 19);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(16, 13);
            this.Label5.TabIndex = 50;
            this.Label5.Text = "Al";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(11, 19);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(57, 13);
            this.Label6.TabIndex = 48;
            this.Label6.Text = "Fecha del ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 13);
            this.label1.TabIndex = 44;
            this.label1.Text = "Kit";
            // 
            // Label29
            // 
            this.Label29.AutoSize = true;
            this.Label29.Location = new System.Drawing.Point(11, 47);
            this.Label29.Name = "Label29";
            this.Label29.Size = new System.Drawing.Size(52, 13);
            this.Label29.TabIndex = 43;
            this.Label29.Text = "Programa";
            // 
            // gb1
            // 
            this.gb1.BackColor = System.Drawing.Color.White;
            this.gb1.Controls.Add(this.btn_impresion);
            this.gb1.Controls.Add(this.btn_pantalla);
            this.gb1.Controls.Add(this.btn_salir);
            this.gb1.Location = new System.Drawing.Point(12, 127);
            this.gb1.Name = "gb1";
            this.gb1.Size = new System.Drawing.Size(412, 54);
            this.gb1.TabIndex = 5;
            this.gb1.TabStop = false;
            // 
            // btn_impresion
            // 
            this.btn_impresion.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_impresion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_impresion.Image = ((System.Drawing.Image)(resources.GetObject("btn_impresion.Image")));
            this.btn_impresion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_impresion.Location = new System.Drawing.Point(165, 15);
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
            this.btn_pantalla.Location = new System.Drawing.Point(72, 15);
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
            this.btn_salir.Location = new System.Drawing.Point(259, 15);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(75, 26);
            this.btn_salir.TabIndex = 19;
            this.btn_salir.Text = "&Salir";
            this.btn_salir.UseVisualStyleBackColor = true;
            this.btn_salir.Click += new System.EventHandler(this.btn_salir_Click);
            // 
            // HISTORIAL_PRECIOS_VENTA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 192);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gb1);
            this.Name = "HISTORIAL_PRECIOS_VENTA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Historial Precios de Venta";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HISTORIAL_PRECIOS_VENTA_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gb1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label Label29;
        internal System.Windows.Forms.GroupBox gb1;
        internal System.Windows.Forms.Button btn_impresion;
        internal System.Windows.Forms.Button btn_pantalla;
        internal System.Windows.Forms.Button btn_salir;
        internal System.Windows.Forms.DateTimePicker dtp_al;
        internal System.Windows.Forms.DateTimePicker dtp_del;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.ComboBox cbo_kit;
        internal System.Windows.Forms.ComboBox cbo_grupo;
    }
}