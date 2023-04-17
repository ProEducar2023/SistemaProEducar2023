namespace Presentacion.MOD_VTA
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Panel_PER = new System.Windows.Forms.Panel();
            this.btn_sgt2 = new System.Windows.Forms.Button();
            this.btn_cadena2 = new System.Windows.Forms.Button();
            this.dgw_per = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.txt_doc_per = new System.Windows.Forms.TextBox();
            this.TXT_DESC = new System.Windows.Forms.TextBox();
            this.TXT_COD = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbo_canaldscto = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.cbo_tipo_planilla = new System.Windows.Forms.ComboBox();
            this.cbo_institucion = new System.Windows.Forms.ComboBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.lbl_cod_tipo_plla = new System.Windows.Forms.Label();
            this.txt_ser = new System.Windows.Forms.TextBox();
            this.txt_num = new System.Windows.Forms.TextBox();
            this.dtp_generacion = new System.Windows.Forms.DateTimePicker();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.cbo_sucursal = new System.Windows.Forms.ComboBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.Panel_PER.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw_per)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel_PER
            // 
            this.Panel_PER.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel_PER.Controls.Add(this.btn_sgt2);
            this.Panel_PER.Controls.Add(this.btn_cadena2);
            this.Panel_PER.Controls.Add(this.dgw_per);
            this.Panel_PER.Location = new System.Drawing.Point(52, 164);
            this.Panel_PER.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Panel_PER.Name = "Panel_PER";
            this.Panel_PER.Size = new System.Drawing.Size(545, 277);
            this.Panel_PER.TabIndex = 206;
            this.Panel_PER.Visible = false;
            // 
            // btn_sgt2
            // 
            this.btn_sgt2.Enabled = false;
            this.btn_sgt2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_sgt2.Image = ((System.Drawing.Image)(resources.GetObject("btn_sgt2.Image")));
            this.btn_sgt2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_sgt2.Location = new System.Drawing.Point(2, 29);
            this.btn_sgt2.Name = "btn_sgt2";
            this.btn_sgt2.Size = new System.Drawing.Size(64, 24);
            this.btn_sgt2.TabIndex = 55;
            this.btn_sgt2.Text = "&Sgte.";
            this.btn_sgt2.UseVisualStyleBackColor = true;
            // 
            // btn_cadena2
            // 
            this.btn_cadena2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cadena2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_cadena2.Location = new System.Drawing.Point(2, 3);
            this.btn_cadena2.Name = "btn_cadena2";
            this.btn_cadena2.Size = new System.Drawing.Size(64, 24);
            this.btn_cadena2.TabIndex = 54;
            this.btn_cadena2.Text = "&Cadena";
            this.btn_cadena2.UseVisualStyleBackColor = true;
            // 
            // dgw_per
            // 
            this.dgw_per.AllowUserToAddRows = false;
            this.dgw_per.AllowUserToDeleteRows = false;
            this.dgw_per.BackgroundColor = System.Drawing.Color.White;
            this.dgw_per.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgw_per.Location = new System.Drawing.Point(66, 2);
            this.dgw_per.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dgw_per.MultiSelect = false;
            this.dgw_per.Name = "dgw_per";
            this.dgw_per.ReadOnly = true;
            this.dgw_per.RowHeadersWidth = 25;
            this.dgw_per.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dgw_per.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.dgw_per.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgw_per.Size = new System.Drawing.Size(462, 266);
            this.dgw_per.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btn_refresh);
            this.groupBox1.Controls.Add(this.txt_doc_per);
            this.groupBox1.Controls.Add(this.TXT_DESC);
            this.groupBox1.Controls.Add(this.TXT_COD);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbo_canaldscto);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.cbo_tipo_planilla);
            this.groupBox1.Controls.Add(this.cbo_institucion);
            this.groupBox1.Controls.Add(this.Label1);
            this.groupBox1.Controls.Add(this.lbl_cod_tipo_plla);
            this.groupBox1.Controls.Add(this.txt_ser);
            this.groupBox1.Controls.Add(this.txt_num);
            this.groupBox1.Controls.Add(this.dtp_generacion);
            this.groupBox1.Controls.Add(this.Label6);
            this.groupBox1.Controls.Add(this.Label4);
            this.groupBox1.Controls.Add(this.cbo_sucursal);
            this.groupBox1.Controls.Add(this.Label2);
            this.groupBox1.Location = new System.Drawing.Point(11, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(959, 196);
            this.groupBox1.TabIndex = 205;
            this.groupBox1.TabStop = false;
            // 
            // btn_refresh
            // 
            this.btn_refresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_refresh.Image = ((System.Drawing.Image)(resources.GetObject("btn_refresh.Image")));
            this.btn_refresh.Location = new System.Drawing.Point(537, 90);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(15, 20);
            this.btn_refresh.TabIndex = 207;
            this.btn_refresh.TabStop = false;
            this.btn_refresh.UseVisualStyleBackColor = true;
            // 
            // txt_doc_per
            // 
            this.txt_doc_per.BackColor = System.Drawing.Color.White;
            this.txt_doc_per.Location = new System.Drawing.Point(434, 90);
            this.txt_doc_per.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_doc_per.MaxLength = 20;
            this.txt_doc_per.Name = "txt_doc_per";
            this.txt_doc_per.Size = new System.Drawing.Size(100, 20);
            this.txt_doc_per.TabIndex = 206;
            // 
            // TXT_DESC
            // 
            this.TXT_DESC.BackColor = System.Drawing.Color.White;
            this.TXT_DESC.Location = new System.Drawing.Point(130, 90);
            this.TXT_DESC.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.TXT_DESC.MaxLength = 60;
            this.TXT_DESC.Name = "TXT_DESC";
            this.TXT_DESC.Size = new System.Drawing.Size(303, 20);
            this.TXT_DESC.TabIndex = 205;
            // 
            // TXT_COD
            // 
            this.TXT_COD.BackColor = System.Drawing.Color.White;
            this.TXT_COD.Location = new System.Drawing.Point(79, 90);
            this.TXT_COD.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.TXT_COD.MaxLength = 5;
            this.TXT_COD.Name = "TXT_COD";
            this.TXT_COD.Size = new System.Drawing.Size(51, 20);
            this.TXT_COD.TabIndex = 204;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 93);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 202;
            this.label3.Text = "Cliente";
            // 
            // cbo_canaldscto
            // 
            this.cbo_canaldscto.BackColor = System.Drawing.Color.White;
            this.cbo_canaldscto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_canaldscto.FormattingEnabled = true;
            this.cbo_canaldscto.Location = new System.Drawing.Point(78, 64);
            this.cbo_canaldscto.Name = "cbo_canaldscto";
            this.cbo_canaldscto.Size = new System.Drawing.Size(322, 21);
            this.cbo_canaldscto.TabIndex = 42;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(9, 69);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(65, 13);
            this.label15.TabIndex = 44;
            this.label15.Text = "Canal Dscto";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(534, 68);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(64, 13);
            this.label17.TabIndex = 43;
            this.label17.Text = "Tipo Planilla";
            // 
            // cbo_tipo_planilla
            // 
            this.cbo_tipo_planilla.BackColor = System.Drawing.Color.White;
            this.cbo_tipo_planilla.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_tipo_planilla.FormattingEnabled = true;
            this.cbo_tipo_planilla.Location = new System.Drawing.Point(600, 64);
            this.cbo_tipo_planilla.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cbo_tipo_planilla.Name = "cbo_tipo_planilla";
            this.cbo_tipo_planilla.Size = new System.Drawing.Size(129, 21);
            this.cbo_tipo_planilla.TabIndex = 40;
            // 
            // cbo_institucion
            // 
            this.cbo_institucion.BackColor = System.Drawing.Color.White;
            this.cbo_institucion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_institucion.FormattingEnabled = true;
            this.cbo_institucion.Location = new System.Drawing.Point(78, 39);
            this.cbo_institucion.Name = "cbo_institucion";
            this.cbo_institucion.Size = new System.Drawing.Size(321, 21);
            this.cbo_institucion.TabIndex = 41;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(11, 42);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(55, 13);
            this.Label1.TabIndex = 39;
            this.Label1.Text = "Institucion";
            // 
            // lbl_cod_tipo_plla
            // 
            this.lbl_cod_tipo_plla.AutoSize = true;
            this.lbl_cod_tipo_plla.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_cod_tipo_plla.ForeColor = System.Drawing.Color.Blue;
            this.lbl_cod_tipo_plla.Location = new System.Drawing.Point(565, 18);
            this.lbl_cod_tipo_plla.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_cod_tipo_plla.Name = "lbl_cod_tipo_plla";
            this.lbl_cod_tipo_plla.Size = new System.Drawing.Size(21, 14);
            this.lbl_cod_tipo_plla.TabIndex = 38;
            this.lbl_cod_tipo_plla.Text = "XX";
            // 
            // txt_ser
            // 
            this.txt_ser.BackColor = System.Drawing.Color.White;
            this.txt_ser.Location = new System.Drawing.Point(587, 15);
            this.txt_ser.Name = "txt_ser";
            this.txt_ser.ReadOnly = true;
            this.txt_ser.Size = new System.Drawing.Size(30, 20);
            this.txt_ser.TabIndex = 35;
            // 
            // txt_num
            // 
            this.txt_num.BackColor = System.Drawing.Color.White;
            this.txt_num.Location = new System.Drawing.Point(619, 15);
            this.txt_num.Name = "txt_num";
            this.txt_num.ReadOnly = true;
            this.txt_num.Size = new System.Drawing.Size(77, 20);
            this.txt_num.TabIndex = 36;
            this.txt_num.TabStop = false;
            // 
            // dtp_generacion
            // 
            this.dtp_generacion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_generacion.Location = new System.Drawing.Point(568, 41);
            this.dtp_generacion.Name = "dtp_generacion";
            this.dtp_generacion.Size = new System.Drawing.Size(80, 20);
            this.dtp_generacion.TabIndex = 33;
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(512, 44);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(55, 13);
            this.Label6.TabIndex = 37;
            this.Label6.Text = "Fe Planilla";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(462, 18);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(103, 13);
            this.Label4.TabIndex = 34;
            this.Label4.Text = "N° Planilla Cobranza";
            // 
            // cbo_sucursal
            // 
            this.cbo_sucursal.BackColor = System.Drawing.Color.White;
            this.cbo_sucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_sucursal.FormattingEnabled = true;
            this.cbo_sucursal.Location = new System.Drawing.Point(78, 14);
            this.cbo_sucursal.Name = "cbo_sucursal";
            this.cbo_sucursal.Size = new System.Drawing.Size(321, 21);
            this.cbo_sucursal.TabIndex = 31;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(11, 17);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(48, 13);
            this.Label2.TabIndex = 32;
            this.Label2.Text = "Sucursal";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 490);
            this.Controls.Add(this.Panel_PER);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Panel_PER.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgw_per)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel Panel_PER;
        internal System.Windows.Forms.Button btn_sgt2;
        internal System.Windows.Forms.Button btn_cadena2;
        internal System.Windows.Forms.DataGridView dgw_per;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.Button btn_refresh;
        internal System.Windows.Forms.TextBox txt_doc_per;
        internal System.Windows.Forms.TextBox TXT_DESC;
        internal System.Windows.Forms.TextBox TXT_COD;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.ComboBox cbo_canaldscto;
        internal System.Windows.Forms.Label label15;
        internal System.Windows.Forms.Label label17;
        internal System.Windows.Forms.ComboBox cbo_tipo_planilla;
        internal System.Windows.Forms.ComboBox cbo_institucion;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label lbl_cod_tipo_plla;
        internal System.Windows.Forms.TextBox txt_ser;
        internal System.Windows.Forms.TextBox txt_num;
        internal System.Windows.Forms.DateTimePicker dtp_generacion;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.ComboBox cbo_sucursal;
        internal System.Windows.Forms.Label Label2;


    }
}