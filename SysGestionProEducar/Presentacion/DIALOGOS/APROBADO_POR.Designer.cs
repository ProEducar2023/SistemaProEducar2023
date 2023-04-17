namespace Presentacion.DIALOGOS
{
    partial class APROBADO_POR
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(APROBADO_POR));
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.BTN_DES = new System.Windows.Forms.Button();
            this.CBO_PERSONAL1 = new System.Windows.Forms.ComboBox();
            this.btn_aceptar = new System.Windows.Forms.Button();
            this.DTP_DOC = new System.Windows.Forms.DateTimePicker();
            this.Label5 = new System.Windows.Forms.Label();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.cbo_movimiento = new System.Windows.Forms.ComboBox();
            this.Label35 = new System.Windows.Forms.Label();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.cbo_movimiento);
            this.GroupBox1.Controls.Add(this.Label35);
            this.GroupBox1.Controls.Add(this.BTN_DES);
            this.GroupBox1.Controls.Add(this.CBO_PERSONAL1);
            this.GroupBox1.Controls.Add(this.btn_aceptar);
            this.GroupBox1.Controls.Add(this.DTP_DOC);
            this.GroupBox1.Controls.Add(this.Label5);
            this.GroupBox1.Controls.Add(this.btn_cancelar);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Location = new System.Drawing.Point(8, 13);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(522, 135);
            this.GroupBox1.TabIndex = 11;
            this.GroupBox1.TabStop = false;
            // 
            // BTN_DES
            // 
            this.BTN_DES.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_DES.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_DES.Image = ((System.Drawing.Image)(resources.GetObject("BTN_DES.Image")));
            this.BTN_DES.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTN_DES.Location = new System.Drawing.Point(327, 96);
            this.BTN_DES.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.BTN_DES.Name = "BTN_DES";
            this.BTN_DES.Size = new System.Drawing.Size(90, 29);
            this.BTN_DES.TabIndex = 6;
            this.BTN_DES.Text = "&Desaprobar";
            this.BTN_DES.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTN_DES.UseVisualStyleBackColor = true;
            this.BTN_DES.Click += new System.EventHandler(this.BTN_DES_Click);
            // 
            // CBO_PERSONAL1
            // 
            this.CBO_PERSONAL1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBO_PERSONAL1.FormattingEnabled = true;
            this.CBO_PERSONAL1.Location = new System.Drawing.Point(101, 18);
            this.CBO_PERSONAL1.Name = "CBO_PERSONAL1";
            this.CBO_PERSONAL1.Size = new System.Drawing.Size(397, 21);
            this.CBO_PERSONAL1.TabIndex = 28;
            // 
            // btn_aceptar
            // 
            this.btn_aceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_aceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_aceptar.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_aceptar.Image = ((System.Drawing.Image)(resources.GetObject("btn_aceptar.Image")));
            this.btn_aceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_aceptar.Location = new System.Drawing.Point(246, 96);
            this.btn_aceptar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_aceptar.Name = "btn_aceptar";
            this.btn_aceptar.Size = new System.Drawing.Size(77, 29);
            this.btn_aceptar.TabIndex = 5;
            this.btn_aceptar.Text = "&Aprobar";
            this.btn_aceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_aceptar.UseVisualStyleBackColor = true;
            this.btn_aceptar.Click += new System.EventHandler(this.btn_aceptar_Click);
            // 
            // DTP_DOC
            // 
            this.DTP_DOC.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DTP_DOC.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTP_DOC.Location = new System.Drawing.Point(101, 44);
            this.DTP_DOC.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.DTP_DOC.Name = "DTP_DOC";
            this.DTP_DOC.Size = new System.Drawing.Size(83, 20);
            this.DTP_DOC.TabIndex = 4;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.Location = new System.Drawing.Point(5, 47);
            this.Label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(95, 14);
            this.Label5.TabIndex = 27;
            this.Label5.Text = "Fecha Aprobacion";
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancelar.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancelar.Image = ((System.Drawing.Image)(resources.GetObject("btn_cancelar.Image")));
            this.btn_cancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_cancelar.Location = new System.Drawing.Point(421, 96);
            this.btn_cancelar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(77, 29);
            this.btn_cancelar.TabIndex = 7;
            this.btn_cancelar.Text = "&Cancelar";
            this.btn_cancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_cancelar.UseVisualStyleBackColor = true;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(5, 18);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(74, 14);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Aprobado por";
            // 
            // cbo_movimiento
            // 
            this.cbo_movimiento.BackColor = System.Drawing.Color.White;
            this.cbo_movimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_movimiento.FormattingEnabled = true;
            this.cbo_movimiento.Location = new System.Drawing.Point(101, 68);
            this.cbo_movimiento.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cbo_movimiento.Name = "cbo_movimiento";
            this.cbo_movimiento.Size = new System.Drawing.Size(247, 21);
            this.cbo_movimiento.TabIndex = 29;
            // 
            // Label35
            // 
            this.Label35.AutoSize = true;
            this.Label35.Location = new System.Drawing.Point(6, 72);
            this.Label35.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label35.Name = "Label35";
            this.Label35.Size = new System.Drawing.Size(61, 13);
            this.Label35.TabIndex = 30;
            this.Label35.Text = "Movimiento";
            // 
            // APROBADO_POR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 160);
            this.Controls.Add(this.GroupBox1);
            this.Name = "APROBADO_POR";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "APROBADO_POR";
            this.Load += new System.EventHandler(this.APROBADO_POR_Load);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Button BTN_DES;
        internal System.Windows.Forms.ComboBox CBO_PERSONAL1;
        internal System.Windows.Forms.Button btn_aceptar;
        internal System.Windows.Forms.DateTimePicker DTP_DOC;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Button btn_cancelar;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.ComboBox cbo_movimiento;
        internal System.Windows.Forms.Label Label35;
    }
}