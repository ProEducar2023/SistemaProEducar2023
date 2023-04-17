namespace Presentacion.MOD_CXC
{
    partial class frm_IngresoVerificacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_IngresoVerificacion));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chk_fec_deposito = new System.Windows.Forms.CheckBox();
            this.cbo_motivo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbo_banco = new System.Windows.Forms.ComboBox();
            this.Label29 = new System.Windows.Forms.Label();
            this.txt_nro_operacion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtp_fec_deposito = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_observaciones = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_grabar = new System.Windows.Forms.Button();
            this.btn_modificar = new System.Windows.Forms.Button();
            this.btn_salir = new System.Windows.Forms.Button();
            this.dtp_fec_com_pago = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_imp_pago = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.chk_fec_deposito);
            this.groupBox1.Controls.Add(this.cbo_motivo);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cbo_banco);
            this.groupBox1.Controls.Add(this.Label29);
            this.groupBox1.Controls.Add(this.txt_nro_operacion);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dtp_fec_deposito);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txt_observaciones);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.dtp_fec_com_pago);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt_imp_pago);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(27, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(483, 352);
            this.groupBox1.TabIndex = 139;
            this.groupBox1.TabStop = false;
            // 
            // chk_fec_deposito
            // 
            this.chk_fec_deposito.AutoSize = true;
            this.chk_fec_deposito.Location = new System.Drawing.Point(219, 189);
            this.chk_fec_deposito.Name = "chk_fec_deposito";
            this.chk_fec_deposito.Size = new System.Drawing.Size(15, 14);
            this.chk_fec_deposito.TabIndex = 150;
            this.chk_fec_deposito.UseVisualStyleBackColor = true;
            // 
            // cbo_motivo
            // 
            this.cbo_motivo.BackColor = System.Drawing.Color.White;
            this.cbo_motivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_motivo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_motivo.FormattingEnabled = true;
            this.cbo_motivo.Location = new System.Drawing.Point(137, 18);
            this.cbo_motivo.Name = "cbo_motivo";
            this.cbo_motivo.Size = new System.Drawing.Size(317, 22);
            this.cbo_motivo.TabIndex = 8;
            this.cbo_motivo.SelectedIndexChanged += new System.EventHandler(this.cbo_motivo_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 8.25F);
            this.label6.Location = new System.Drawing.Point(17, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 14);
            this.label6.TabIndex = 148;
            this.label6.Text = "Motivo";
            // 
            // cbo_banco
            // 
            this.cbo_banco.BackColor = System.Drawing.Color.White;
            this.cbo_banco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_banco.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_banco.FormattingEnabled = true;
            this.cbo_banco.Location = new System.Drawing.Point(137, 240);
            this.cbo_banco.Name = "cbo_banco";
            this.cbo_banco.Size = new System.Drawing.Size(317, 22);
            this.cbo_banco.TabIndex = 20;
            // 
            // Label29
            // 
            this.Label29.AutoSize = true;
            this.Label29.Font = new System.Drawing.Font("Arial", 8.25F);
            this.Label29.Location = new System.Drawing.Point(15, 244);
            this.Label29.Name = "Label29";
            this.Label29.Size = new System.Drawing.Size(101, 14);
            this.Label29.TabIndex = 146;
            this.Label29.Text = "Institución Bancaria";
            // 
            // txt_nro_operacion
            // 
            this.txt_nro_operacion.BackColor = System.Drawing.Color.White;
            this.txt_nro_operacion.Location = new System.Drawing.Point(136, 209);
            this.txt_nro_operacion.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_nro_operacion.Name = "txt_nro_operacion";
            this.txt_nro_operacion.Size = new System.Drawing.Size(318, 20);
            this.txt_nro_operacion.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(14, 212);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 14);
            this.label5.TabIndex = 144;
            this.label5.Text = "N° de Operación";
            // 
            // dtp_fec_deposito
            // 
            this.dtp_fec_deposito.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_fec_deposito.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_fec_deposito.Location = new System.Drawing.Point(137, 183);
            this.dtp_fec_deposito.Name = "dtp_fec_deposito";
            this.dtp_fec_deposito.Size = new System.Drawing.Size(75, 20);
            this.dtp_fec_deposito.TabIndex = 16;
            this.dtp_fec_deposito.ValueChanged += new System.EventHandler(this.dtp_fec_deposito_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 14);
            this.label4.TabIndex = 142;
            this.label4.Text = "Fecha de Depósito";
            // 
            // txt_observaciones
            // 
            this.txt_observaciones.BackColor = System.Drawing.Color.White;
            this.txt_observaciones.Location = new System.Drawing.Point(136, 80);
            this.txt_observaciones.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_observaciones.Multiline = true;
            this.txt_observaciones.Name = "txt_observaciones";
            this.txt_observaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_observaciones.Size = new System.Drawing.Size(318, 59);
            this.txt_observaciones.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 14);
            this.label3.TabIndex = 140;
            this.label3.Text = "Observaciones";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btn_grabar);
            this.panel2.Controls.Add(this.btn_modificar);
            this.panel2.Controls.Add(this.btn_salir);
            this.panel2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(272, 281);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(182, 55);
            this.panel2.TabIndex = 139;
            this.panel2.TabStop = true;
            // 
            // btn_grabar
            // 
            this.btn_grabar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_grabar.Image = ((System.Drawing.Image)(resources.GetObject("btn_grabar.Image")));
            this.btn_grabar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_grabar.Location = new System.Drawing.Point(13, 13);
            this.btn_grabar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_grabar.Name = "btn_grabar";
            this.btn_grabar.Size = new System.Drawing.Size(77, 27);
            this.btn_grabar.TabIndex = 22;
            this.btn_grabar.Text = "   &Grabar";
            this.btn_grabar.UseVisualStyleBackColor = true;
            this.btn_grabar.Click += new System.EventHandler(this.btn_grabar_Click);
            // 
            // btn_modificar
            // 
            this.btn_modificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_modificar.Image = ((System.Drawing.Image)(resources.GetObject("btn_modificar.Image")));
            this.btn_modificar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_modificar.Location = new System.Drawing.Point(13, 13);
            this.btn_modificar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_modificar.Name = "btn_modificar";
            this.btn_modificar.Size = new System.Drawing.Size(77, 27);
            this.btn_modificar.TabIndex = 149;
            this.btn_modificar.Text = "   &Modificar";
            this.btn_modificar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_modificar.UseVisualStyleBackColor = true;
            // 
            // btn_salir
            // 
            this.btn_salir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_salir.Image = ((System.Drawing.Image)(resources.GetObject("btn_salir.Image")));
            this.btn_salir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_salir.Location = new System.Drawing.Point(95, 12);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(77, 27);
            this.btn_salir.TabIndex = 24;
            this.btn_salir.Text = "&Salir";
            this.btn_salir.UseVisualStyleBackColor = true;
            // 
            // dtp_fec_com_pago
            // 
            this.dtp_fec_com_pago.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_fec_com_pago.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_fec_com_pago.Location = new System.Drawing.Point(137, 51);
            this.dtp_fec_com_pago.Name = "dtp_fec_com_pago";
            this.dtp_fec_com_pago.Size = new System.Drawing.Size(75, 20);
            this.dtp_fec_com_pago.TabIndex = 10;
            this.dtp_fec_com_pago.ValueChanged += new System.EventHandler(this.dtp_fec_com_pago_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 14);
            this.label1.TabIndex = 134;
            this.label1.Text = "Fecha Nueva Llamada";
            // 
            // txt_imp_pago
            // 
            this.txt_imp_pago.BackColor = System.Drawing.Color.White;
            this.txt_imp_pago.Location = new System.Drawing.Point(136, 152);
            this.txt_imp_pago.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_imp_pago.Name = "txt_imp_pago";
            this.txt_imp_pago.Size = new System.Drawing.Size(76, 20);
            this.txt_imp_pago.TabIndex = 14;
            this.txt_imp_pago.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 14);
            this.label2.TabIndex = 136;
            this.label2.Text = "Importe de Pago";
            // 
            // frm_IngresoVerificacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 390);
            this.Controls.Add(this.groupBox1);
            this.Name = "frm_IngresoVerificacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ingreso Datos para Verificacion";
            this.Load += new System.EventHandler(this.frm_IngresoVerificacion_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_IngresoVerificacion_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chk_fec_deposito;
        internal System.Windows.Forms.ComboBox cbo_motivo;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.ComboBox cbo_banco;
        internal System.Windows.Forms.Label Label29;
        internal System.Windows.Forms.TextBox txt_nro_operacion;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.DateTimePicker dtp_fec_deposito;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.TextBox txt_observaciones;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Panel panel2;
        internal System.Windows.Forms.Button btn_grabar;
        internal System.Windows.Forms.Button btn_modificar;
        internal System.Windows.Forms.Button btn_salir;
        internal System.Windows.Forms.DateTimePicker dtp_fec_com_pago;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txt_imp_pago;
        internal System.Windows.Forms.Label label2;
    }
}