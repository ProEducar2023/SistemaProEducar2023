namespace Presentacion.MOD_ALM.Reportes.Formulario
{
    partial class KARDEX_INVENTARIO_HISTORICO
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KARDEX_INVENTARIO_HISTORICO));
            this.Pan_art = new System.Windows.Forms.Panel();
            this.dgw_art = new System.Windows.Forms.DataGridView();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_archivo = new System.Windows.Forms.Button();
            this.btn_imprimir = new System.Windows.Forms.Button();
            this.btn_pantalla = new System.Windows.Forms.Button();
            this.btn_resumen = new System.Windows.Forms.Button();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.chk_art = new System.Windows.Forms.CheckBox();
            this.btn_salir2 = new System.Windows.Forms.Button();
            this.dtp_al = new System.Windows.Forms.DateTimePicker();
            this.dtp_del = new System.Windows.Forms.DateTimePicker();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.txt_cod_art = new System.Windows.Forms.TextBox();
            this.txt_des_art = new System.Windows.Forms.TextBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.cbo_alm = new System.Windows.Forms.ComboBox();
            this.chk_alm = new System.Windows.Forms.CheckBox();
            this.Label10 = new System.Windows.Forms.Label();
            this.cbo_clase = new System.Windows.Forms.ComboBox();
            this.cbo_suc = new System.Windows.Forms.ComboBox();
            this.Label14 = new System.Windows.Forms.Label();
            this.Label16 = new System.Windows.Forms.Label();
            this.Pan_art.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw_art)).BeginInit();
            this.GroupBox2.SuspendLayout();
            this.GroupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // Pan_art
            // 
            this.Pan_art.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Pan_art.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Pan_art.Controls.Add(this.dgw_art);
            this.Pan_art.Location = new System.Drawing.Point(117, 152);
            this.Pan_art.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Pan_art.Name = "Pan_art";
            this.Pan_art.Size = new System.Drawing.Size(412, 138);
            this.Pan_art.TabIndex = 5;
            this.Pan_art.Visible = false;
            // 
            // dgw_art
            // 
            this.dgw_art.AllowUserToAddRows = false;
            this.dgw_art.AllowUserToDeleteRows = false;
            this.dgw_art.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgw_art.BackgroundColor = System.Drawing.Color.White;
            this.dgw_art.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgw_art.Location = new System.Drawing.Point(5, -1);
            this.dgw_art.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dgw_art.MultiSelect = false;
            this.dgw_art.Name = "dgw_art";
            this.dgw_art.ReadOnly = true;
            this.dgw_art.RowHeadersWidth = 25;
            this.dgw_art.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dgw_art.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.dgw_art.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgw_art.Size = new System.Drawing.Size(401, 134);
            this.dgw_art.TabIndex = 0;
            this.dgw_art.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgw_art_KeyDown);
            // 
            // GroupBox2
            // 
            this.GroupBox2.BackColor = System.Drawing.Color.White;
            this.GroupBox2.Controls.Add(this.btn_archivo);
            this.GroupBox2.Controls.Add(this.btn_imprimir);
            this.GroupBox2.Controls.Add(this.btn_pantalla);
            this.GroupBox2.Controls.Add(this.btn_resumen);
            this.GroupBox2.Location = new System.Drawing.Point(13, 234);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(522, 60);
            this.GroupBox2.TabIndex = 6;
            this.GroupBox2.TabStop = false;
            // 
            // btn_archivo
            // 
            this.btn_archivo.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_archivo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_archivo.Image = ((System.Drawing.Image)(resources.GetObject("btn_archivo.Image")));
            this.btn_archivo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_archivo.Location = new System.Drawing.Point(353, 19);
            this.btn_archivo.Name = "btn_archivo";
            this.btn_archivo.Size = new System.Drawing.Size(77, 27);
            this.btn_archivo.TabIndex = 2;
            this.btn_archivo.Text = "&Archivo";
            this.btn_archivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_archivo.UseVisualStyleBackColor = false;
            // 
            // btn_imprimir
            // 
            this.btn_imprimir.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_imprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_imprimir.Image = ((System.Drawing.Image)(resources.GetObject("btn_imprimir.Image")));
            this.btn_imprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_imprimir.Location = new System.Drawing.Point(270, 19);
            this.btn_imprimir.Name = "btn_imprimir";
            this.btn_imprimir.Size = new System.Drawing.Size(77, 27);
            this.btn_imprimir.TabIndex = 1;
            this.btn_imprimir.Text = "&Imprimir";
            this.btn_imprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_imprimir.UseVisualStyleBackColor = false;
            // 
            // btn_pantalla
            // 
            this.btn_pantalla.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_pantalla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_pantalla.Image = ((System.Drawing.Image)(resources.GetObject("btn_pantalla.Image")));
            this.btn_pantalla.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_pantalla.Location = new System.Drawing.Point(104, 19);
            this.btn_pantalla.Name = "btn_pantalla";
            this.btn_pantalla.Size = new System.Drawing.Size(77, 27);
            this.btn_pantalla.TabIndex = 0;
            this.btn_pantalla.Text = "&Detalle";
            this.btn_pantalla.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_pantalla.UseVisualStyleBackColor = false;
            this.btn_pantalla.Click += new System.EventHandler(this.btn_pantalla_Click);
            // 
            // btn_resumen
            // 
            this.btn_resumen.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_resumen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_resumen.Image = ((System.Drawing.Image)(resources.GetObject("btn_resumen.Image")));
            this.btn_resumen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_resumen.Location = new System.Drawing.Point(187, 19);
            this.btn_resumen.Name = "btn_resumen";
            this.btn_resumen.Size = new System.Drawing.Size(77, 27);
            this.btn_resumen.TabIndex = 3;
            this.btn_resumen.Text = "&Resumen";
            this.btn_resumen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_resumen.UseVisualStyleBackColor = false;
            this.btn_resumen.Click += new System.EventHandler(this.btn_resumen_Click);
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.chk_art);
            this.GroupBox3.Controls.Add(this.btn_salir2);
            this.GroupBox3.Controls.Add(this.dtp_al);
            this.GroupBox3.Controls.Add(this.dtp_del);
            this.GroupBox3.Controls.Add(this.Label5);
            this.GroupBox3.Controls.Add(this.Label6);
            this.GroupBox3.Controls.Add(this.txt_cod_art);
            this.GroupBox3.Controls.Add(this.txt_des_art);
            this.GroupBox3.Controls.Add(this.Label8);
            this.GroupBox3.Controls.Add(this.cbo_alm);
            this.GroupBox3.Controls.Add(this.chk_alm);
            this.GroupBox3.Controls.Add(this.Label10);
            this.GroupBox3.Controls.Add(this.cbo_clase);
            this.GroupBox3.Controls.Add(this.cbo_suc);
            this.GroupBox3.Controls.Add(this.Label14);
            this.GroupBox3.Controls.Add(this.Label16);
            this.GroupBox3.Location = new System.Drawing.Point(13, 19);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(522, 210);
            this.GroupBox3.TabIndex = 4;
            this.GroupBox3.TabStop = false;
            // 
            // chk_art
            // 
            this.chk_art.AutoSize = true;
            this.chk_art.Location = new System.Drawing.Point(86, 118);
            this.chk_art.Name = "chk_art";
            this.chk_art.Size = new System.Drawing.Size(15, 14);
            this.chk_art.TabIndex = 10;
            this.chk_art.UseVisualStyleBackColor = true;
            this.chk_art.CheckedChanged += new System.EventHandler(this.chk_art_CheckedChanged);
            // 
            // btn_salir2
            // 
            this.btn_salir2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_salir2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_salir2.Image = ((System.Drawing.Image)(resources.GetObject("btn_salir2.Image")));
            this.btn_salir2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_salir2.Location = new System.Drawing.Point(391, 140);
            this.btn_salir2.Name = "btn_salir2";
            this.btn_salir2.Size = new System.Drawing.Size(77, 27);
            this.btn_salir2.TabIndex = 18;
            this.btn_salir2.TabStop = false;
            this.btn_salir2.Text = "&Salir";
            this.btn_salir2.UseVisualStyleBackColor = true;
            this.btn_salir2.Click += new System.EventHandler(this.btn_salir2_Click);
            // 
            // dtp_al
            // 
            this.dtp_al.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_al.Location = new System.Drawing.Point(216, 143);
            this.dtp_al.Name = "dtp_al";
            this.dtp_al.Size = new System.Drawing.Size(77, 20);
            this.dtp_al.TabIndex = 17;
            // 
            // dtp_del
            // 
            this.dtp_del.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_del.Location = new System.Drawing.Point(110, 143);
            this.dtp_del.Name = "dtp_del";
            this.dtp_del.Size = new System.Drawing.Size(77, 20);
            this.dtp_del.TabIndex = 15;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(193, 146);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(16, 13);
            this.Label5.TabIndex = 16;
            this.Label5.Text = "Al";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(23, 146);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(57, 13);
            this.Label6.TabIndex = 14;
            this.Label6.Text = "Fecha del ";
            // 
            // txt_cod_art
            // 
            this.txt_cod_art.BackColor = System.Drawing.Color.White;
            this.txt_cod_art.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_cod_art.Location = new System.Drawing.Point(110, 112);
            this.txt_cod_art.MaxLength = 10;
            this.txt_cod_art.Name = "txt_cod_art";
            this.txt_cod_art.Size = new System.Drawing.Size(77, 20);
            this.txt_cod_art.TabIndex = 12;
            this.txt_cod_art.Leave += new System.EventHandler(this.txt_cod_art_Leave);
            // 
            // txt_des_art
            // 
            this.txt_des_art.BackColor = System.Drawing.Color.White;
            this.txt_des_art.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_des_art.Location = new System.Drawing.Point(187, 112);
            this.txt_des_art.MaxLength = 60;
            this.txt_des_art.Name = "txt_des_art";
            this.txt_des_art.Size = new System.Drawing.Size(279, 20);
            this.txt_des_art.TabIndex = 13;
            this.txt_des_art.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_des_art_KeyDown);
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label8.Location = new System.Drawing.Point(23, 116);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(44, 14);
            this.Label8.TabIndex = 9;
            this.Label8.Text = "Artículo";
            // 
            // cbo_alm
            // 
            this.cbo_alm.BackColor = System.Drawing.Color.White;
            this.cbo_alm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_alm.Enabled = false;
            this.cbo_alm.FormattingEnabled = true;
            this.cbo_alm.Location = new System.Drawing.Point(110, 89);
            this.cbo_alm.Name = "cbo_alm";
            this.cbo_alm.Size = new System.Drawing.Size(266, 21);
            this.cbo_alm.TabIndex = 8;
            // 
            // chk_alm
            // 
            this.chk_alm.AutoSize = true;
            this.chk_alm.Location = new System.Drawing.Point(86, 93);
            this.chk_alm.Name = "chk_alm";
            this.chk_alm.Size = new System.Drawing.Size(15, 14);
            this.chk_alm.TabIndex = 7;
            this.chk_alm.UseVisualStyleBackColor = true;
            this.chk_alm.CheckedChanged += new System.EventHandler(this.chk_alm_CheckedChanged);
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.Location = new System.Drawing.Point(23, 93);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(48, 13);
            this.Label10.TabIndex = 6;
            this.Label10.Text = "Almacén";
            // 
            // cbo_clase
            // 
            this.cbo_clase.BackColor = System.Drawing.Color.White;
            this.cbo_clase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_clase.FormattingEnabled = true;
            this.cbo_clase.Location = new System.Drawing.Point(110, 41);
            this.cbo_clase.Name = "cbo_clase";
            this.cbo_clase.Size = new System.Drawing.Size(266, 21);
            this.cbo_clase.TabIndex = 3;
            this.cbo_clase.SelectedIndexChanged += new System.EventHandler(this.cbo_clase_SelectedIndexChanged);
            // 
            // cbo_suc
            // 
            this.cbo_suc.BackColor = System.Drawing.Color.White;
            this.cbo_suc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_suc.FormattingEnabled = true;
            this.cbo_suc.Location = new System.Drawing.Point(110, 65);
            this.cbo_suc.Name = "cbo_suc";
            this.cbo_suc.Size = new System.Drawing.Size(266, 21);
            this.cbo_suc.TabIndex = 5;
            this.cbo_suc.SelectedIndexChanged += new System.EventHandler(this.cbo_suc_SelectedIndexChanged);
            // 
            // Label14
            // 
            this.Label14.AutoSize = true;
            this.Label14.Location = new System.Drawing.Point(23, 72);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(48, 13);
            this.Label14.TabIndex = 4;
            this.Label14.Text = "Sucursal";
            // 
            // Label16
            // 
            this.Label16.AutoSize = true;
            this.Label16.Location = new System.Drawing.Point(24, 47);
            this.Label16.Name = "Label16";
            this.Label16.Size = new System.Drawing.Size(33, 13);
            this.Label16.TabIndex = 0;
            this.Label16.Text = "Clase";
            // 
            // KARDEX_INVENTARIO_HISTORICO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 316);
            this.Controls.Add(this.Pan_art);
            this.Controls.Add(this.GroupBox3);
            this.Controls.Add(this.GroupBox2);
            this.Name = "KARDEX_INVENTARIO_HISTORICO";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kardex Inventario Historico";
            this.Load += new System.EventHandler(this.KARDEX_INVENTARIO_HISTORICO_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KARDEX_INVENTARIO_HISTORICO_KeyDown);
            this.Pan_art.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgw_art)).EndInit();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel Pan_art;
        internal System.Windows.Forms.DataGridView dgw_art;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.Button btn_archivo;
        internal System.Windows.Forms.Button btn_imprimir;
        internal System.Windows.Forms.Button btn_pantalla;
        internal System.Windows.Forms.GroupBox GroupBox3;
        internal System.Windows.Forms.Button btn_salir2;
        internal System.Windows.Forms.DateTimePicker dtp_al;
        internal System.Windows.Forms.DateTimePicker dtp_del;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.TextBox txt_cod_art;
        internal System.Windows.Forms.TextBox txt_des_art;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.ComboBox cbo_alm;
        internal System.Windows.Forms.CheckBox chk_alm;
        internal System.Windows.Forms.Label Label10;
        internal System.Windows.Forms.ComboBox cbo_clase;
        internal System.Windows.Forms.ComboBox cbo_suc;
        internal System.Windows.Forms.Label Label14;
        internal System.Windows.Forms.Label Label16;
        internal System.Windows.Forms.CheckBox chk_art;
        internal System.Windows.Forms.Button btn_resumen;
    }
}