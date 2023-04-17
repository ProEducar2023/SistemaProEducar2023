namespace Presentacion.CONSULTAS
{
    partial class frmConsultaRuc
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
            this.pbCaptcha = new System.Windows.Forms.PictureBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnTrasladar = new System.Windows.Forms.Button();
            this.StatusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslMensaje = new System.Windows.Forms.ToolStripStatusLabel();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.chkAgente = new System.Windows.Forms.CheckBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.txtSituacion = new System.Windows.Forms.TextBox();
            this.txtTipo = new System.Windows.Forms.TextBox();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label8 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.txtNombreComercial = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtCodigoCaptcha = new System.Windows.Forms.TextBox();
            this.txtRuc = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbCaptcha)).BeginInit();
            this.StatusStrip1.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbCaptcha
            // 
            this.pbCaptcha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbCaptcha.Location = new System.Drawing.Point(456, 2);
            this.pbCaptcha.Name = "pbCaptcha";
            this.pbCaptcha.Size = new System.Drawing.Size(128, 48);
            this.pbCaptcha.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCaptcha.TabIndex = 38;
            this.pbCaptcha.TabStop = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(456, 161);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(128, 27);
            this.btnCancelar.TabIndex = 37;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnTrasladar
            // 
            this.btnTrasladar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrasladar.Location = new System.Drawing.Point(456, 128);
            this.btnTrasladar.Name = "btnTrasladar";
            this.btnTrasladar.Size = new System.Drawing.Size(128, 27);
            this.btnTrasladar.TabIndex = 36;
            this.btnTrasladar.Text = "Actualizar";
            this.btnTrasladar.UseVisualStyleBackColor = true;
            this.btnTrasladar.Click += new System.EventHandler(this.btnTrasladar_Click);
            // 
            // StatusStrip1
            // 
            this.StatusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslMensaje});
            this.StatusStrip1.Location = new System.Drawing.Point(0, 340);
            this.StatusStrip1.Name = "StatusStrip1";
            this.StatusStrip1.Size = new System.Drawing.Size(596, 22);
            this.StatusStrip1.TabIndex = 35;
            this.StatusStrip1.Text = "StatusStrip1";
            // 
            // tsslMensaje
            // 
            this.tsslMensaje.Name = "tsslMensaje";
            this.tsslMensaje.Size = new System.Drawing.Size(0, 17);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.chkAgente);
            this.GroupBox1.Controls.Add(this.Label5);
            this.GroupBox1.Controls.Add(this.Label4);
            this.GroupBox1.Controls.Add(this.Label7);
            this.GroupBox1.Controls.Add(this.txtEstado);
            this.GroupBox1.Controls.Add(this.txtSituacion);
            this.GroupBox1.Controls.Add(this.txtTipo);
            this.GroupBox1.Location = new System.Drawing.Point(12, 159);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(428, 136);
            this.GroupBox1.TabIndex = 34;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Otros datos:";
            // 
            // chkAgente
            // 
            this.chkAgente.AutoSize = true;
            this.chkAgente.Enabled = false;
            this.chkAgente.Location = new System.Drawing.Point(226, 83);
            this.chkAgente.Name = "chkAgente";
            this.chkAgente.Size = new System.Drawing.Size(142, 17);
            this.chkAgente.TabIndex = 6;
            this.chkAgente.Text = "Agente Retención (IGV):";
            this.chkAgente.UseVisualStyleBackColor = true;
            this.chkAgente.Visible = false;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(6, 87);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(43, 13);
            this.Label5.TabIndex = 4;
            this.Label5.Text = "Estado:";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(6, 58);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(54, 13);
            this.Label4.TabIndex = 2;
            this.Label4.Text = "Situación:";
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(6, 29);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(31, 13);
            this.Label7.TabIndex = 0;
            this.Label7.Text = "Tipo:";
            // 
            // txtEstado
            // 
            this.txtEstado.BackColor = System.Drawing.Color.White;
            this.txtEstado.Enabled = false;
            this.txtEstado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEstado.Location = new System.Drawing.Point(71, 79);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(149, 23);
            this.txtEstado.TabIndex = 5;
            // 
            // txtSituacion
            // 
            this.txtSituacion.BackColor = System.Drawing.Color.White;
            this.txtSituacion.Enabled = false;
            this.txtSituacion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSituacion.Location = new System.Drawing.Point(71, 50);
            this.txtSituacion.Name = "txtSituacion";
            this.txtSituacion.Size = new System.Drawing.Size(149, 23);
            this.txtSituacion.TabIndex = 3;
            // 
            // txtTipo
            // 
            this.txtTipo.BackColor = System.Drawing.Color.White;
            this.txtTipo.Enabled = false;
            this.txtTipo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipo.Location = new System.Drawing.Point(71, 21);
            this.txtTipo.Name = "txtTipo";
            this.txtTipo.Size = new System.Drawing.Size(351, 23);
            this.txtTipo.TabIndex = 1;
            // 
            // btnConsultar
            // 
            this.btnConsultar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsultar.Location = new System.Drawing.Point(456, 95);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(128, 27);
            this.btnConsultar.TabIndex = 27;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(12, 98);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(55, 13);
            this.Label3.TabIndex = 32;
            this.Label3.Text = "Dirección:";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(12, 77);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(96, 13);
            this.Label6.TabIndex = 30;
            this.Label6.Text = "Nombre Comercial:";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(12, 48);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(73, 13);
            this.Label2.TabIndex = 28;
            this.Label2.Text = "Razón Social:";
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Location = new System.Drawing.Point(453, 53);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(80, 13);
            this.Label8.TabIndex = 23;
            this.Label8.Text = "Ingrese código:";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(12, 20);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(70, 13);
            this.Label1.TabIndex = 24;
            this.Label1.Text = "Numero Ruc:";
            // 
            // txtDireccion
            // 
            this.txtDireccion.BackColor = System.Drawing.Color.White;
            this.txtDireccion.Enabled = false;
            this.txtDireccion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccion.Location = new System.Drawing.Point(108, 98);
            this.txtDireccion.Multiline = true;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(332, 55);
            this.txtDireccion.TabIndex = 33;
            // 
            // txtNombreComercial
            // 
            this.txtNombreComercial.BackColor = System.Drawing.Color.White;
            this.txtNombreComercial.Enabled = false;
            this.txtNombreComercial.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreComercial.Location = new System.Drawing.Point(108, 69);
            this.txtNombreComercial.Name = "txtNombreComercial";
            this.txtNombreComercial.Size = new System.Drawing.Size(332, 23);
            this.txtNombreComercial.TabIndex = 31;
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.Color.White;
            this.txtNombre.Enabled = false;
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(108, 40);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(332, 23);
            this.txtNombre.TabIndex = 29;
            // 
            // txtCodigoCaptcha
            // 
            this.txtCodigoCaptcha.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodigoCaptcha.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoCaptcha.Location = new System.Drawing.Point(456, 69);
            this.txtCodigoCaptcha.MaxLength = 11;
            this.txtCodigoCaptcha.Name = "txtCodigoCaptcha";
            this.txtCodigoCaptcha.Size = new System.Drawing.Size(128, 23);
            this.txtCodigoCaptcha.TabIndex = 25;
            this.txtCodigoCaptcha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtRuc
            // 
            this.txtRuc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRuc.Location = new System.Drawing.Point(108, 11);
            this.txtRuc.MaxLength = 11;
            this.txtRuc.Name = "txtRuc";
            this.txtRuc.Size = new System.Drawing.Size(121, 23);
            this.txtRuc.TabIndex = 26;
            // 
            // frmConsultaRuc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 362);
            this.Controls.Add(this.pbCaptcha);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnTrasladar);
            this.Controls.Add(this.StatusStrip1);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label8);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.txtNombreComercial);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtCodigoCaptcha);
            this.Controls.Add(this.txtRuc);
            this.Name = "frmConsultaRuc";
            this.Text = "frmConsultaRuc";
            this.Load += new System.EventHandler(this.frmConsultaRuc_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmConsultaRuc_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pbCaptcha)).EndInit();
            this.StatusStrip1.ResumeLayout(false);
            this.StatusStrip1.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.PictureBox pbCaptcha;
        internal System.Windows.Forms.Button btnCancelar;
        internal System.Windows.Forms.Button btnTrasladar;
        internal System.Windows.Forms.StatusStrip StatusStrip1;
        internal System.Windows.Forms.ToolStripStatusLabel tsslMensaje;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.CheckBox chkAgente;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.TextBox txtEstado;
        internal System.Windows.Forms.TextBox txtSituacion;
        internal System.Windows.Forms.TextBox txtTipo;
        internal System.Windows.Forms.Button btnConsultar;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox txtDireccion;
        internal System.Windows.Forms.TextBox txtNombreComercial;
        internal System.Windows.Forms.TextBox txtNombre;
        internal System.Windows.Forms.TextBox txtCodigoCaptcha;
        internal System.Windows.Forms.TextBox txtRuc;
    }
}