namespace Presentacion.REPORTES.FORM_REPORTES
{
    partial class REPORTE_RESUMEN_MES
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(REPORTE_RESUMEN_MES));
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.chkAnual = new System.Windows.Forms.CheckBox();
            this.cbo_grupo = new System.Windows.Forms.ComboBox();
            this.ch_gru = new System.Windows.Forms.CheckBox();
            this.TXT_GRUPO = new System.Windows.Forms.TextBox();
            this.Label7 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.CBO_CLASE = new System.Windows.Forms.ComboBox();
            this.cbo_año = new System.Windows.Forms.ComboBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.BTN_SALIR = new System.Windows.Forms.Button();
            this.cbo_mes1 = new System.Windows.Forms.ComboBox();
            this.gb1 = new System.Windows.Forms.GroupBox();
            this.btn_archivo1 = new System.Windows.Forms.Button();
            this.btn_imprimir1 = new System.Windows.Forms.Button();
            this.btn_pantalla1 = new System.Windows.Forms.Button();
            this.GroupBox1.SuspendLayout();
            this.gb1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.chkAnual);
            this.GroupBox1.Controls.Add(this.cbo_grupo);
            this.GroupBox1.Controls.Add(this.ch_gru);
            this.GroupBox1.Controls.Add(this.TXT_GRUPO);
            this.GroupBox1.Controls.Add(this.Label7);
            this.GroupBox1.Controls.Add(this.Label4);
            this.GroupBox1.Controls.Add(this.CBO_CLASE);
            this.GroupBox1.Controls.Add(this.cbo_año);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Controls.Add(this.BTN_SALIR);
            this.GroupBox1.Controls.Add(this.cbo_mes1);
            this.GroupBox1.Location = new System.Drawing.Point(69, 26);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(575, 253);
            this.GroupBox1.TabIndex = 59;
            this.GroupBox1.TabStop = false;
            // 
            // chkAnual
            // 
            this.chkAnual.AutoSize = true;
            this.chkAnual.Location = new System.Drawing.Point(158, 214);
            this.chkAnual.Name = "chkAnual";
            this.chkAnual.Size = new System.Drawing.Size(94, 17);
            this.chkAnual.TabIndex = 113;
            this.chkAnual.Text = "Reporte Anual";
            this.chkAnual.UseVisualStyleBackColor = true;
            // 
            // cbo_grupo
            // 
            this.cbo_grupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_grupo.Enabled = false;
            this.cbo_grupo.FormattingEnabled = true;
            this.cbo_grupo.Location = new System.Drawing.Point(179, 186);
            this.cbo_grupo.Name = "cbo_grupo";
            this.cbo_grupo.Size = new System.Drawing.Size(266, 21);
            this.cbo_grupo.TabIndex = 70;
            // 
            // ch_gru
            // 
            this.ch_gru.AutoSize = true;
            this.ch_gru.Location = new System.Drawing.Point(158, 192);
            this.ch_gru.Name = "ch_gru";
            this.ch_gru.Size = new System.Drawing.Size(15, 14);
            this.ch_gru.TabIndex = 71;
            this.ch_gru.UseVisualStyleBackColor = true;
            this.ch_gru.CheckedChanged += new System.EventHandler(this.ch_gru_CheckedChanged);
            // 
            // TXT_GRUPO
            // 
            this.TXT_GRUPO.Location = new System.Drawing.Point(184, 188);
            this.TXT_GRUPO.MaxLength = 3;
            this.TXT_GRUPO.Name = "TXT_GRUPO";
            this.TXT_GRUPO.ReadOnly = true;
            this.TXT_GRUPO.Size = new System.Drawing.Size(45, 20);
            this.TXT_GRUPO.TabIndex = 73;
            this.TXT_GRUPO.Visible = false;
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(108, 189);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(36, 13);
            this.Label7.TabIndex = 72;
            this.Label7.Text = "Grupo";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(108, 156);
            this.Label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(33, 13);
            this.Label4.TabIndex = 61;
            this.Label4.Text = "Clase";
            // 
            // CBO_CLASE
            // 
            this.CBO_CLASE.BackColor = System.Drawing.Color.White;
            this.CBO_CLASE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBO_CLASE.FormattingEnabled = true;
            this.CBO_CLASE.Location = new System.Drawing.Point(179, 153);
            this.CBO_CLASE.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.CBO_CLASE.Name = "CBO_CLASE";
            this.CBO_CLASE.Size = new System.Drawing.Size(227, 21);
            this.CBO_CLASE.TabIndex = 60;
            this.CBO_CLASE.SelectedIndexChanged += new System.EventHandler(this.CBO_CLASE_SelectedIndexChanged);
            // 
            // cbo_año
            // 
            this.cbo_año.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_año.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_año.FormattingEnabled = true;
            this.cbo_año.Location = new System.Drawing.Point(179, 89);
            this.cbo_año.Name = "cbo_año";
            this.cbo_año.Size = new System.Drawing.Size(69, 22);
            this.cbo_año.TabIndex = 58;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(108, 92);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(26, 13);
            this.Label1.TabIndex = 57;
            this.Label1.Text = "Año";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(108, 124);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(27, 14);
            this.Label3.TabIndex = 55;
            this.Label3.Text = "Mes";
            // 
            // BTN_SALIR
            // 
            this.BTN_SALIR.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTN_SALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BTN_SALIR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_SALIR.Image = ((System.Drawing.Image)(resources.GetObject("BTN_SALIR.Image")));
            this.BTN_SALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTN_SALIR.Location = new System.Drawing.Point(473, 175);
            this.BTN_SALIR.Name = "BTN_SALIR";
            this.BTN_SALIR.Size = new System.Drawing.Size(77, 31);
            this.BTN_SALIR.TabIndex = 56;
            this.BTN_SALIR.Text = "&Salir";
            this.BTN_SALIR.UseVisualStyleBackColor = true;
            this.BTN_SALIR.Click += new System.EventHandler(this.BTN_SALIR_Click);
            // 
            // cbo_mes1
            // 
            this.cbo_mes1.BackColor = System.Drawing.Color.White;
            this.cbo_mes1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_mes1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_mes1.FormattingEnabled = true;
            this.cbo_mes1.Items.AddRange(new object[] {
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
            this.cbo_mes1.Location = new System.Drawing.Point(179, 121);
            this.cbo_mes1.Name = "cbo_mes1";
            this.cbo_mes1.Size = new System.Drawing.Size(120, 22);
            this.cbo_mes1.TabIndex = 53;
            // 
            // gb1
            // 
            this.gb1.BackColor = System.Drawing.Color.White;
            this.gb1.Controls.Add(this.btn_archivo1);
            this.gb1.Controls.Add(this.btn_imprimir1);
            this.gb1.Controls.Add(this.btn_pantalla1);
            this.gb1.Location = new System.Drawing.Point(248, 285);
            this.gb1.Name = "gb1";
            this.gb1.Size = new System.Drawing.Size(261, 65);
            this.gb1.TabIndex = 58;
            this.gb1.TabStop = false;
            // 
            // btn_archivo1
            // 
            this.btn_archivo1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_archivo1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_archivo1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_archivo1.Image = ((System.Drawing.Image)(resources.GetObject("btn_archivo1.Image")));
            this.btn_archivo1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_archivo1.Location = new System.Drawing.Point(172, 17);
            this.btn_archivo1.Name = "btn_archivo1";
            this.btn_archivo1.Size = new System.Drawing.Size(77, 31);
            this.btn_archivo1.TabIndex = 2;
            this.btn_archivo1.Text = "&Archivo";
            this.btn_archivo1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_archivo1.UseVisualStyleBackColor = false;
            this.btn_archivo1.Visible = false;
            // 
            // btn_imprimir1
            // 
            this.btn_imprimir1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_imprimir1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_imprimir1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_imprimir1.Image = ((System.Drawing.Image)(resources.GetObject("btn_imprimir1.Image")));
            this.btn_imprimir1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_imprimir1.Location = new System.Drawing.Point(91, 17);
            this.btn_imprimir1.Name = "btn_imprimir1";
            this.btn_imprimir1.Size = new System.Drawing.Size(77, 31);
            this.btn_imprimir1.TabIndex = 1;
            this.btn_imprimir1.Text = "&Imprimir";
            this.btn_imprimir1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_imprimir1.UseVisualStyleBackColor = false;
            // 
            // btn_pantalla1
            // 
            this.btn_pantalla1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_pantalla1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_pantalla1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_pantalla1.Image = ((System.Drawing.Image)(resources.GetObject("btn_pantalla1.Image")));
            this.btn_pantalla1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_pantalla1.Location = new System.Drawing.Point(10, 17);
            this.btn_pantalla1.Name = "btn_pantalla1";
            this.btn_pantalla1.Size = new System.Drawing.Size(77, 31);
            this.btn_pantalla1.TabIndex = 0;
            this.btn_pantalla1.Text = "&Pantalla";
            this.btn_pantalla1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_pantalla1.UseVisualStyleBackColor = false;
            this.btn_pantalla1.Click += new System.EventHandler(this.btn_pantalla1_Click);
            // 
            // REPORTE_RESUMEN_MES
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 377);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.gb1);
            this.Name = "REPORTE_RESUMEN_MES";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte de Resumen Mensual";
            this.Load += new System.EventHandler(this.REPORTE_RESUMEN_MES_Load);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.gb1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.CheckBox chkAnual;
        internal System.Windows.Forms.ComboBox cbo_grupo;
        internal System.Windows.Forms.CheckBox ch_gru;
        internal System.Windows.Forms.TextBox TXT_GRUPO;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.ComboBox CBO_CLASE;
        internal System.Windows.Forms.ComboBox cbo_año;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Button BTN_SALIR;
        internal System.Windows.Forms.ComboBox cbo_mes1;
        internal System.Windows.Forms.GroupBox gb1;
        internal System.Windows.Forms.Button btn_archivo1;
        internal System.Windows.Forms.Button btn_imprimir1;
        internal System.Windows.Forms.Button btn_pantalla1;
    }
}