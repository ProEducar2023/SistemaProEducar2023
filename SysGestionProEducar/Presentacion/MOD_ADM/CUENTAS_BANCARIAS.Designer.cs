namespace Presentacion.MOD_ADM
{
    partial class CUENTAS_BANCARIAS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CUENTAS_BANCARIAS));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.btn_salir = new System.Windows.Forms.Button();
            this.btn_eliminar = new System.Windows.Forms.Button();
            this.btn_modificar = new System.Windows.Forms.Button();
            this.btn_nuevo = new System.Windows.Forms.Button();
            this.dgw1 = new System.Windows.Forms.DataGridView();
            this.TabPage2 = new System.Windows.Forms.TabPage();
            this.GB1 = new System.Windows.Forms.GroupBox();
            this.btn_modificar2 = new System.Windows.Forms.Button();
            this.txt_cta_com = new System.Windows.Forms.TextBox();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.btn_guardar = new System.Windows.Forms.Button();
            this.TXT_COD0 = new System.Windows.Forms.TextBox();
            this.txt_cta_aux = new System.Windows.Forms.TextBox();
            this.Label9 = new System.Windows.Forms.Label();
            this.txt_cta_pagar = new System.Windows.Forms.TextBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.txt_cta_ctable = new System.Windows.Forms.TextBox();
            this.cbo_moneda = new System.Windows.Forms.ComboBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.cbo_tipo_cta = new System.Windows.Forms.ComboBox();
            this.Label7 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Banco = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.cbo_banco = new System.Windows.Forms.ComboBox();
            this.txt_cod = new System.Windows.Forms.TextBox();
            this.cbo_sucursal = new System.Windows.Forms.ComboBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.TabControl1.SuspendLayout();
            this.TabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw1)).BeginInit();
            this.TabPage2.SuspendLayout();
            this.GB1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControl1
            // 
            this.TabControl1.Controls.Add(this.TabPage1);
            this.TabControl1.Controls.Add(this.TabPage2);
            this.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabControl1.Location = new System.Drawing.Point(0, 0);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(592, 273);
            this.TabControl1.TabIndex = 3;
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.btn_salir);
            this.TabPage1.Controls.Add(this.btn_eliminar);
            this.TabPage1.Controls.Add(this.btn_modificar);
            this.TabPage1.Controls.Add(this.btn_nuevo);
            this.TabPage1.Controls.Add(this.dgw1);
            this.TabPage1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabPage1.Location = new System.Drawing.Point(4, 23);
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage1.Size = new System.Drawing.Size(584, 246);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "Lista de Bancos";
            this.TabPage1.UseVisualStyleBackColor = true;
            // 
            // btn_salir
            // 
            this.btn_salir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_salir.Image = ((System.Drawing.Image)(resources.GetObject("btn_salir.Image")));
            this.btn_salir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_salir.Location = new System.Drawing.Point(473, 149);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(85, 35);
            this.btn_salir.TabIndex = 4;
            this.btn_salir.Text = "&Salir";
            this.btn_salir.UseVisualStyleBackColor = true;
            // 
            // btn_eliminar
            // 
            this.btn_eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_eliminar.Image = ((System.Drawing.Image)(resources.GetObject("btn_eliminar.Image")));
            this.btn_eliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_eliminar.Location = new System.Drawing.Point(473, 108);
            this.btn_eliminar.Name = "btn_eliminar";
            this.btn_eliminar.Size = new System.Drawing.Size(85, 35);
            this.btn_eliminar.TabIndex = 3;
            this.btn_eliminar.Text = "&Eliminar";
            this.btn_eliminar.UseVisualStyleBackColor = true;
            // 
            // btn_modificar
            // 
            this.btn_modificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_modificar.Image = ((System.Drawing.Image)(resources.GetObject("btn_modificar.Image")));
            this.btn_modificar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_modificar.Location = new System.Drawing.Point(473, 67);
            this.btn_modificar.Name = "btn_modificar";
            this.btn_modificar.Size = new System.Drawing.Size(85, 35);
            this.btn_modificar.TabIndex = 2;
            this.btn_modificar.Text = "&Modificar";
            this.btn_modificar.UseVisualStyleBackColor = true;
            // 
            // btn_nuevo
            // 
            this.btn_nuevo.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_nuevo.Image = ((System.Drawing.Image)(resources.GetObject("btn_nuevo.Image")));
            this.btn_nuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_nuevo.Location = new System.Drawing.Point(473, 26);
            this.btn_nuevo.Name = "btn_nuevo";
            this.btn_nuevo.Size = new System.Drawing.Size(85, 35);
            this.btn_nuevo.TabIndex = 1;
            this.btn_nuevo.Text = "&Nuevo";
            this.btn_nuevo.UseVisualStyleBackColor = true;
            this.btn_nuevo.Click += new System.EventHandler(this.btn_nuevo_Click);
            // 
            // dgw1
            // 
            this.dgw1.AllowUserToAddRows = false;
            this.dgw1.AllowUserToDeleteRows = false;
            this.dgw1.AllowUserToOrderColumns = true;
            this.dgw1.AllowUserToResizeRows = false;
            this.dgw1.BackgroundColor = System.Drawing.Color.White;
            this.dgw1.Location = new System.Drawing.Point(26, 26);
            this.dgw1.MultiSelect = false;
            this.dgw1.Name = "dgw1";
            this.dgw1.ReadOnly = true;
            this.dgw1.RowHeadersWidth = 25;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            this.dgw1.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgw1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dgw1.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.dgw1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgw1.Size = new System.Drawing.Size(430, 200);
            this.dgw1.TabIndex = 0;
            // 
            // TabPage2
            // 
            this.TabPage2.Controls.Add(this.GB1);
            this.TabPage2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabPage2.Location = new System.Drawing.Point(4, 23);
            this.TabPage2.Name = "TabPage2";
            this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage2.Size = new System.Drawing.Size(584, 246);
            this.TabPage2.TabIndex = 1;
            this.TabPage2.Text = "Detalles";
            this.TabPage2.UseVisualStyleBackColor = true;
            // 
            // GB1
            // 
            this.GB1.Controls.Add(this.btn_modificar2);
            this.GB1.Controls.Add(this.txt_cta_com);
            this.GB1.Controls.Add(this.btn_cancelar);
            this.GB1.Controls.Add(this.btn_guardar);
            this.GB1.Controls.Add(this.TXT_COD0);
            this.GB1.Controls.Add(this.txt_cta_aux);
            this.GB1.Controls.Add(this.Label9);
            this.GB1.Controls.Add(this.txt_cta_pagar);
            this.GB1.Controls.Add(this.Label6);
            this.GB1.Controls.Add(this.txt_cta_ctable);
            this.GB1.Controls.Add(this.cbo_moneda);
            this.GB1.Controls.Add(this.Label8);
            this.GB1.Controls.Add(this.cbo_tipo_cta);
            this.GB1.Controls.Add(this.Label7);
            this.GB1.Controls.Add(this.Label5);
            this.GB1.Controls.Add(this.Label3);
            this.GB1.Controls.Add(this.Banco);
            this.GB1.Controls.Add(this.Label2);
            this.GB1.Controls.Add(this.cbo_banco);
            this.GB1.Controls.Add(this.txt_cod);
            this.GB1.Controls.Add(this.cbo_sucursal);
            this.GB1.Controls.Add(this.Label1);
            this.GB1.Controls.Add(this.Label4);
            this.GB1.Location = new System.Drawing.Point(22, 21);
            this.GB1.Name = "GB1";
            this.GB1.Size = new System.Drawing.Size(533, 193);
            this.GB1.TabIndex = 0;
            this.GB1.TabStop = false;
            // 
            // btn_modificar2
            // 
            this.btn_modificar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_modificar2.Image = ((System.Drawing.Image)(resources.GetObject("btn_modificar2.Image")));
            this.btn_modificar2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_modificar2.Location = new System.Drawing.Point(356, 157);
            this.btn_modificar2.Name = "btn_modificar2";
            this.btn_modificar2.Size = new System.Drawing.Size(77, 27);
            this.btn_modificar2.TabIndex = 11;
            this.btn_modificar2.Text = "&Modificar";
            this.btn_modificar2.UseVisualStyleBackColor = true;
            // 
            // txt_cta_com
            // 
            this.txt_cta_com.BackColor = System.Drawing.Color.White;
            this.txt_cta_com.Location = new System.Drawing.Point(375, 119);
            this.txt_cta_com.MaxLength = 3;
            this.txt_cta_com.Name = "txt_cta_com";
            this.txt_cta_com.Size = new System.Drawing.Size(43, 20);
            this.txt_cta_com.TabIndex = 10;
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancelar.Image = ((System.Drawing.Image)(resources.GetObject("btn_cancelar.Image")));
            this.btn_cancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_cancelar.Location = new System.Drawing.Point(437, 157);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(77, 27);
            this.btn_cancelar.TabIndex = 12;
            this.btn_cancelar.Text = "&Cancelar";
            this.btn_cancelar.UseVisualStyleBackColor = true;
            // 
            // btn_guardar
            // 
            this.btn_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_guardar.Image = ((System.Drawing.Image)(resources.GetObject("btn_guardar.Image")));
            this.btn_guardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_guardar.Location = new System.Drawing.Point(356, 157);
            this.btn_guardar.Name = "btn_guardar";
            this.btn_guardar.Size = new System.Drawing.Size(77, 27);
            this.btn_guardar.TabIndex = 11;
            this.btn_guardar.Text = "&Guardar";
            this.btn_guardar.UseVisualStyleBackColor = true;
            // 
            // TXT_COD0
            // 
            this.TXT_COD0.BackColor = System.Drawing.Color.White;
            this.TXT_COD0.Location = new System.Drawing.Point(94, 23);
            this.TXT_COD0.MaxLength = 4;
            this.TXT_COD0.Name = "TXT_COD0";
            this.TXT_COD0.Size = new System.Drawing.Size(35, 20);
            this.TXT_COD0.TabIndex = 1;
            // 
            // txt_cta_aux
            // 
            this.txt_cta_aux.BackColor = System.Drawing.Color.White;
            this.txt_cta_aux.Location = new System.Drawing.Point(375, 95);
            this.txt_cta_aux.MaxLength = 2;
            this.txt_cta_aux.Name = "txt_cta_aux";
            this.txt_cta_aux.Size = new System.Drawing.Size(43, 20);
            this.txt_cta_aux.TabIndex = 9;
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Location = new System.Drawing.Point(16, 26);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(40, 14);
            this.Label9.TabIndex = 20;
            this.Label9.Text = "Codigo";
            // 
            // txt_cta_pagar
            // 
            this.txt_cta_pagar.BackColor = System.Drawing.Color.White;
            this.txt_cta_pagar.Location = new System.Drawing.Point(375, 71);
            this.txt_cta_pagar.MaxLength = 8;
            this.txt_cta_pagar.Name = "txt_cta_pagar";
            this.txt_cta_pagar.Size = new System.Drawing.Size(75, 20);
            this.txt_cta_pagar.TabIndex = 8;
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(16, 122);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(45, 14);
            this.Label6.TabIndex = 19;
            this.Label6.Text = "Moneda";
            // 
            // txt_cta_ctable
            // 
            this.txt_cta_ctable.BackColor = System.Drawing.Color.White;
            this.txt_cta_ctable.Location = new System.Drawing.Point(375, 47);
            this.txt_cta_ctable.MaxLength = 8;
            this.txt_cta_ctable.Name = "txt_cta_ctable";
            this.txt_cta_ctable.Size = new System.Drawing.Size(75, 20);
            this.txt_cta_ctable.TabIndex = 7;
            // 
            // cbo_moneda
            // 
            this.cbo_moneda.BackColor = System.Drawing.Color.White;
            this.cbo_moneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_moneda.FormattingEnabled = true;
            this.cbo_moneda.Location = new System.Drawing.Point(94, 119);
            this.cbo_moneda.Name = "cbo_moneda";
            this.cbo_moneda.Size = new System.Drawing.Size(147, 22);
            this.cbo_moneda.TabIndex = 5;
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Location = new System.Drawing.Point(261, 122);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(94, 14);
            this.Label8.TabIndex = 3;
            this.Label8.Text = "Tipo Comprobante";
            // 
            // cbo_tipo_cta
            // 
            this.cbo_tipo_cta.BackColor = System.Drawing.Color.White;
            this.cbo_tipo_cta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_tipo_cta.FormattingEnabled = true;
            this.cbo_tipo_cta.Items.AddRange(new object[] {
            "AHORROS",
            "CTA. CORRIENTE",
            "MAESTRA",
            "EFECTIVO"});
            this.cbo_tipo_cta.Location = new System.Drawing.Point(94, 95);
            this.cbo_tipo_cta.Name = "cbo_tipo_cta";
            this.cbo_tipo_cta.Size = new System.Drawing.Size(147, 22);
            this.cbo_tipo_cta.TabIndex = 4;
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(261, 98);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(69, 14);
            this.Label7.TabIndex = 2;
            this.Label7.Text = "Libro Auxiliar";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(16, 98);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(64, 14);
            this.Label5.TabIndex = 16;
            this.Label5.Text = "Tipo de Cta.";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(261, 74);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(72, 14);
            this.Label3.TabIndex = 1;
            this.Label3.Text = "Cuenta Pagar";
            // 
            // Banco
            // 
            this.Banco.AutoSize = true;
            this.Banco.Location = new System.Drawing.Point(16, 74);
            this.Banco.Name = "Banco";
            this.Banco.Size = new System.Drawing.Size(38, 14);
            this.Banco.TabIndex = 15;
            this.Banco.Text = "Banco";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(261, 50);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(86, 14);
            this.Label2.TabIndex = 0;
            this.Label2.Text = "Cuenta Contable";
            // 
            // cbo_banco
            // 
            this.cbo_banco.BackColor = System.Drawing.Color.White;
            this.cbo_banco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_banco.FormattingEnabled = true;
            this.cbo_banco.Location = new System.Drawing.Point(94, 71);
            this.cbo_banco.Name = "cbo_banco";
            this.cbo_banco.Size = new System.Drawing.Size(147, 22);
            this.cbo_banco.TabIndex = 3;
            // 
            // txt_cod
            // 
            this.txt_cod.BackColor = System.Drawing.Color.White;
            this.txt_cod.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_cod.Location = new System.Drawing.Point(375, 23);
            this.txt_cod.MaxLength = 20;
            this.txt_cod.Name = "txt_cod";
            this.txt_cod.Size = new System.Drawing.Size(147, 20);
            this.txt_cod.TabIndex = 6;
            // 
            // cbo_sucursal
            // 
            this.cbo_sucursal.BackColor = System.Drawing.Color.White;
            this.cbo_sucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_sucursal.FormattingEnabled = true;
            this.cbo_sucursal.Location = new System.Drawing.Point(94, 47);
            this.cbo_sucursal.Name = "cbo_sucursal";
            this.cbo_sucursal.Size = new System.Drawing.Size(147, 22);
            this.cbo_sucursal.TabIndex = 2;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(261, 26);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(87, 14);
            this.Label1.TabIndex = 6;
            this.Label1.Text = "Nº Cta. Bancaria";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(16, 50);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(50, 14);
            this.Label4.TabIndex = 12;
            this.Label4.Text = "Sucursal";
            // 
            // CUENTAS_BANCARIAS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 273);
            this.Controls.Add(this.TabControl1);
            this.Name = "CUENTAS_BANCARIAS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento Cuentas - Bancos";
            this.Load += new System.EventHandler(this.CUENTAS_BANCARIAS_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CUENTAS_BANCARIAS_KeyDown);
            this.TabControl1.ResumeLayout(false);
            this.TabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgw1)).EndInit();
            this.TabPage2.ResumeLayout(false);
            this.GB1.ResumeLayout(false);
            this.GB1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TabControl TabControl1;
        internal System.Windows.Forms.TabPage TabPage1;
        internal System.Windows.Forms.Button btn_salir;
        internal System.Windows.Forms.Button btn_eliminar;
        internal System.Windows.Forms.Button btn_modificar;
        internal System.Windows.Forms.Button btn_nuevo;
        internal System.Windows.Forms.DataGridView dgw1;
        internal System.Windows.Forms.TabPage TabPage2;
        internal System.Windows.Forms.GroupBox GB1;
        internal System.Windows.Forms.Button btn_modificar2;
        internal System.Windows.Forms.TextBox txt_cta_com;
        internal System.Windows.Forms.Button btn_cancelar;
        internal System.Windows.Forms.Button btn_guardar;
        internal System.Windows.Forms.TextBox TXT_COD0;
        internal System.Windows.Forms.TextBox txt_cta_aux;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.TextBox txt_cta_pagar;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.TextBox txt_cta_ctable;
        internal System.Windows.Forms.ComboBox cbo_moneda;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.ComboBox cbo_tipo_cta;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Banco;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.ComboBox cbo_banco;
        internal System.Windows.Forms.TextBox txt_cod;
        internal System.Windows.Forms.ComboBox cbo_sucursal;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label Label4;
    }
}