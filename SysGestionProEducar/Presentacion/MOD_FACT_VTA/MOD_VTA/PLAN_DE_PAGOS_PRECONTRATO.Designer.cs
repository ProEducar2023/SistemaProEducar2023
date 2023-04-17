namespace Presentacion.MOD_FACT_VTA.MOD_VTA
{
    partial class PLAN_DE_PAGOS_PRECONTRATO
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PLAN_DE_PAGOS_PRECONTRATO));
            this.txtncuo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtcuotas = new System.Windows.Forms.TextBox();
            this.OK_Button = new System.Windows.Forms.Button();
            this.Cancel_Button = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dtp_fmen = new System.Windows.Forms.DateTimePicker();
            this.txt_ndvcto = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblsaldo = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_tot = new System.Windows.Forms.TextBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.Label42 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_ci = new System.Windows.Forms.TextBox();
            this.dtp_vcto = new System.Windows.Forms.DateTimePicker();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtncuo
            // 
            this.txtncuo.BackColor = System.Drawing.Color.White;
            this.txtncuo.Location = new System.Drawing.Point(123, 18);
            this.txtncuo.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtncuo.Name = "txtncuo";
            this.txtncuo.Size = new System.Drawing.Size(54, 20);
            this.txtncuo.TabIndex = 14;
            this.txtncuo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Total de Cuotas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(253, 125);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Importe por Cuota";
            // 
            // txtcuotas
            // 
            this.txtcuotas.BackColor = System.Drawing.Color.White;
            this.txtcuotas.Location = new System.Drawing.Point(346, 122);
            this.txtcuotas.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtcuotas.Name = "txtcuotas";
            this.txtcuotas.Size = new System.Drawing.Size(54, 20);
            this.txtcuotas.TabIndex = 26;
            this.txtcuotas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtcuotas.Leave += new System.EventHandler(this.txtcuotas_Leave);
            // 
            // OK_Button
            // 
            this.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.OK_Button.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OK_Button.Image = ((System.Drawing.Image)(resources.GetObject("OK_Button.Image")));
            this.OK_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.OK_Button.Location = new System.Drawing.Point(141, 182);
            this.OK_Button.Name = "OK_Button";
            this.OK_Button.Size = new System.Drawing.Size(75, 27);
            this.OK_Button.TabIndex = 28;
            this.OK_Button.Text = "Aceptar";
            this.OK_Button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.OK_Button.Click += new System.EventHandler(this.OK_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Cancel_Button.Image = ((System.Drawing.Image)(resources.GetObject("Cancel_Button.Image")));
            this.Cancel_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Cancel_Button.Location = new System.Drawing.Point(222, 182);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(75, 27);
            this.Cancel_Button.TabIndex = 30;
            this.Cancel_Button.Text = "Cancelar";
            this.Cancel_Button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 128);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 32;
            this.label4.Text = "Fec Vto 2da Cuota";
            // 
            // dtp_fmen
            // 
            this.dtp_fmen.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_fmen.Location = new System.Drawing.Point(123, 124);
            this.dtp_fmen.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dtp_fmen.Name = "dtp_fmen";
            this.dtp_fmen.Size = new System.Drawing.Size(86, 20);
            this.dtp_fmen.TabIndex = 24;
            // 
            // txt_ndvcto
            // 
            this.txt_ndvcto.BackColor = System.Drawing.Color.White;
            this.txt_ndvcto.Location = new System.Drawing.Point(344, 17);
            this.txt_ndvcto.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_ndvcto.Name = "txt_ndvcto";
            this.txt_ndvcto.Size = new System.Drawing.Size(54, 20);
            this.txt_ndvcto.TabIndex = 16;
            this.txt_ndvcto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_ndvcto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_ndvcto_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(249, 21);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 13);
            this.label5.TabIndex = 34;
            this.label5.Text = "N° Dias por Cuota";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblsaldo);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txt_tot);
            this.groupBox2.Controls.Add(this.Label8);
            this.groupBox2.Controls.Add(this.Label42);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txt_ci);
            this.groupBox2.Controls.Add(this.dtp_vcto);
            this.groupBox2.Controls.Add(this.txtncuo);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txt_ndvcto);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtcuotas);
            this.groupBox2.Controls.Add(this.dtp_fmen);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(14, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(420, 155);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            // 
            // lblsaldo
            // 
            this.lblsaldo.AutoSize = true;
            this.lblsaldo.Location = new System.Drawing.Point(358, 100);
            this.lblsaldo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblsaldo.Name = "lblsaldo";
            this.lblsaldo.Size = new System.Drawing.Size(28, 13);
            this.lblsaldo.TabIndex = 42;
            this.lblsaldo.Text = "0.00";
            this.lblsaldo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(307, 100);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 41;
            this.label6.Text = "Saldo";
            // 
            // txt_tot
            // 
            this.txt_tot.BackColor = System.Drawing.Color.White;
            this.txt_tot.Location = new System.Drawing.Point(344, 44);
            this.txt_tot.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_tot.Name = "txt_tot";
            this.txt_tot.ReadOnly = true;
            this.txt_tot.Size = new System.Drawing.Size(54, 20);
            this.txt_tot.TabIndex = 18;
            this.txt_tot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Location = new System.Drawing.Point(272, 48);
            this.Label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(69, 13);
            this.Label8.TabIndex = 40;
            this.Label8.Text = "Importe Total";
            // 
            // Label42
            // 
            this.Label42.AutoSize = true;
            this.Label42.Location = new System.Drawing.Point(27, 74);
            this.Label42.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label42.Name = "Label42";
            this.Label42.Size = new System.Drawing.Size(93, 13);
            this.Label42.TabIndex = 39;
            this.Label42.Text = "Fec Vto 1ra Cuota";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(251, 75);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 38;
            this.label3.Text = "Importe 1ra Cuota";
            // 
            // txt_ci
            // 
            this.txt_ci.BackColor = System.Drawing.Color.White;
            this.txt_ci.Location = new System.Drawing.Point(344, 71);
            this.txt_ci.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_ci.Name = "txt_ci";
            this.txt_ci.Size = new System.Drawing.Size(54, 20);
            this.txt_ci.TabIndex = 22;
            this.txt_ci.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_ci.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_ci_KeyDown);
            this.txt_ci.Leave += new System.EventHandler(this.txt_ci_Leave_1);
            // 
            // dtp_vcto
            // 
            this.dtp_vcto.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_vcto.Location = new System.Drawing.Point(123, 71);
            this.dtp_vcto.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dtp_vcto.Name = "dtp_vcto";
            this.dtp_vcto.Size = new System.Drawing.Size(86, 20);
            this.dtp_vcto.TabIndex = 20;
            this.dtp_vcto.ValueChanged += new System.EventHandler(this.dtp_vcto_ValueChanged);
            // 
            // PLAN_DE_PAGOS_PRECONTRATO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 225);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.OK_Button);
            this.Controls.Add(this.Cancel_Button);
            this.KeyPreview = true;
            this.Name = "PLAN_DE_PAGOS_PRECONTRATO";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ventana de Registro de Plan de Pagos";
            this.Load += new System.EventHandler(this.PLAN_DE_PAGOS_PRECONTRATO_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PLAN_DE_PAGOS_PRECONTRATO_KeyDown);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TextBox txtncuo;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox txtcuotas;
        internal System.Windows.Forms.Button OK_Button;
        internal System.Windows.Forms.Button Cancel_Button;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.DateTimePicker dtp_fmen;
        internal System.Windows.Forms.TextBox txt_ndvcto;
        internal System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.TextBox txt_tot;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.Label Label42;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox txt_ci;
        internal System.Windows.Forms.DateTimePicker dtp_vcto;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.Label lblsaldo;
    }
}