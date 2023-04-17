namespace Presentacion.MOD_CXC
{
    partial class PLANILLA_DESCUENTO_INFORMATIVA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PLANILLA_DESCUENTO_INFORMATIVA));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_pantalla = new System.Windows.Forms.Button();
            this.btn_salir = new System.Windows.Forms.Button();
            this.cbo_institucion = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_ejecutar = new System.Windows.Forms.Button();
            this.cbo_canal_dscto = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbo_pto_cob_inf = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_pantalla);
            this.groupBox2.Controls.Add(this.btn_salir);
            this.groupBox2.Controls.Add(this.cbo_institucion);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btn_ejecutar);
            this.groupBox2.Controls.Add(this.cbo_canal_dscto);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cbo_pto_cob_inf);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Location = new System.Drawing.Point(4, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(452, 136);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            // 
            // btn_pantalla
            // 
            this.btn_pantalla.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_pantalla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_pantalla.Image = ((System.Drawing.Image)(resources.GetObject("btn_pantalla.Image")));
            this.btn_pantalla.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_pantalla.Location = new System.Drawing.Point(233, 98);
            this.btn_pantalla.Name = "btn_pantalla";
            this.btn_pantalla.Size = new System.Drawing.Size(77, 27);
            this.btn_pantalla.TabIndex = 38;
            this.btn_pantalla.Text = "&Pantalla";
            this.btn_pantalla.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_pantalla.UseVisualStyleBackColor = false;
            this.btn_pantalla.Click += new System.EventHandler(this.btn_pantalla_Click);
            // 
            // btn_salir
            // 
            this.btn_salir.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_salir.Image = ((System.Drawing.Image)(resources.GetObject("btn_salir.Image")));
            this.btn_salir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_salir.Location = new System.Drawing.Point(363, 98);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(77, 27);
            this.btn_salir.TabIndex = 37;
            this.btn_salir.Text = "&Salir";
            this.btn_salir.UseVisualStyleBackColor = true;
            this.btn_salir.Click += new System.EventHandler(this.btn_salir_Click);
            // 
            // cbo_institucion
            // 
            this.cbo_institucion.BackColor = System.Drawing.Color.White;
            this.cbo_institucion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_institucion.FormattingEnabled = true;
            this.cbo_institucion.Location = new System.Drawing.Point(109, 20);
            this.cbo_institucion.Name = "cbo_institucion";
            this.cbo_institucion.Size = new System.Drawing.Size(331, 21);
            this.cbo_institucion.TabIndex = 2;
            this.cbo_institucion.SelectedIndexChanged += new System.EventHandler(this.cbo_institucion_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 36;
            this.label2.Text = "Institucion";
            // 
            // btn_ejecutar
            // 
            this.btn_ejecutar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ejecutar.Image = ((System.Drawing.Image)(resources.GetObject("btn_ejecutar.Image")));
            this.btn_ejecutar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_ejecutar.Location = new System.Drawing.Point(109, 98);
            this.btn_ejecutar.Name = "btn_ejecutar";
            this.btn_ejecutar.Size = new System.Drawing.Size(74, 27);
            this.btn_ejecutar.TabIndex = 8;
            this.btn_ejecutar.Text = "&Ejecutar";
            this.btn_ejecutar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_ejecutar.UseVisualStyleBackColor = true;
            this.btn_ejecutar.Click += new System.EventHandler(this.btn_ejecutar_Click);
            // 
            // cbo_canal_dscto
            // 
            this.cbo_canal_dscto.BackColor = System.Drawing.Color.White;
            this.cbo_canal_dscto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_canal_dscto.FormattingEnabled = true;
            this.cbo_canal_dscto.Location = new System.Drawing.Point(109, 45);
            this.cbo_canal_dscto.Name = "cbo_canal_dscto";
            this.cbo_canal_dscto.Size = new System.Drawing.Size(331, 21);
            this.cbo_canal_dscto.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "Canal Descuento";
            // 
            // cbo_pto_cob_inf
            // 
            this.cbo_pto_cob_inf.BackColor = System.Drawing.Color.White;
            this.cbo_pto_cob_inf.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_pto_cob_inf.FormattingEnabled = true;
            this.cbo_pto_cob_inf.Location = new System.Drawing.Point(109, 71);
            this.cbo_pto_cob_inf.Name = "cbo_pto_cob_inf";
            this.cbo_pto_cob_inf.Size = new System.Drawing.Size(331, 21);
            this.cbo_pto_cob_inf.TabIndex = 6;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(12, 76);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(91, 13);
            this.label15.TabIndex = 31;
            this.label15.Text = "Ptos Cobranza Inf";
            // 
            // PLANILLA_DESCUENTO_INFORMATIVA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 155);
            this.Controls.Add(this.groupBox2);
            this.Name = "PLANILLA_DESCUENTO_INFORMATIVA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Informativo";
            this.Load += new System.EventHandler(this.PLANILLA_DESCUENTO_INFORMATIVA_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PLANILLA_DESCUENTO_INFORMATIVA_KeyDown);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.ComboBox cbo_institucion;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Button btn_ejecutar;
        internal System.Windows.Forms.ComboBox cbo_canal_dscto;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.ComboBox cbo_pto_cob_inf;
        internal System.Windows.Forms.Label label15;
        internal System.Windows.Forms.Button btn_salir;
        internal System.Windows.Forms.Button btn_pantalla;
    }
}