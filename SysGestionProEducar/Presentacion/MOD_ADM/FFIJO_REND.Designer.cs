namespace Presentacion.MOD_ADM
{
    partial class FFIJO_REND
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.btn_salir = new System.Windows.Forms.Button();
            this.btn_eliminar = new System.Windows.Forms.Button();
            this.btn_modificar = new System.Windows.Forms.Button();
            this.btn_nuevo = new System.Windows.Forms.Button();
            this.dgw1 = new System.Windows.Forms.DataGridView();
            this.TabPage2 = new System.Windows.Forms.TabPage();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.cbo_tipo_cc = new System.Windows.Forms.ComboBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.cbo_tipo = new System.Windows.Forms.ComboBox();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.btn_modificar2 = new System.Windows.Forms.Button();
            this.btn_guardar = new System.Windows.Forms.Button();
            this.txt_desc2 = new System.Windows.Forms.TextBox();
            this.txt_desc = new System.Windows.Forms.TextBox();
            this.txt_cod = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.TabControl1.SuspendLayout();
            this.TabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw1)).BeginInit();
            this.TabPage2.SuspendLayout();
            this.GroupBox1.SuspendLayout();
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
            this.TabControl1.Size = new System.Drawing.Size(580, 297);
            this.TabControl1.TabIndex = 1;
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
            this.TabPage1.Size = new System.Drawing.Size(572, 270);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "Lista de Áreas";
            this.TabPage1.UseVisualStyleBackColor = true;
            // 
            // btn_salir
            // 
            this.btn_salir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_salir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_salir.Location = new System.Drawing.Point(456, 147);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(85, 35);
            this.btn_salir.TabIndex = 4;
            this.btn_salir.Text = "&Salir";
            this.btn_salir.UseVisualStyleBackColor = true;
            // 
            // btn_eliminar
            // 
            this.btn_eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_eliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_eliminar.Location = new System.Drawing.Point(456, 106);
            this.btn_eliminar.Name = "btn_eliminar";
            this.btn_eliminar.Size = new System.Drawing.Size(85, 35);
            this.btn_eliminar.TabIndex = 3;
            this.btn_eliminar.Text = "&Eliminar";
            this.btn_eliminar.UseVisualStyleBackColor = true;
            // 
            // btn_modificar
            // 
            this.btn_modificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_modificar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_modificar.Location = new System.Drawing.Point(456, 65);
            this.btn_modificar.Name = "btn_modificar";
            this.btn_modificar.Size = new System.Drawing.Size(85, 35);
            this.btn_modificar.TabIndex = 2;
            this.btn_modificar.Text = "&Modificar";
            this.btn_modificar.UseVisualStyleBackColor = true;
            // 
            // btn_nuevo
            // 
            this.btn_nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_nuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_nuevo.Location = new System.Drawing.Point(456, 24);
            this.btn_nuevo.Name = "btn_nuevo";
            this.btn_nuevo.Size = new System.Drawing.Size(85, 35);
            this.btn_nuevo.TabIndex = 1;
            this.btn_nuevo.Text = "&Nuevo";
            this.btn_nuevo.UseVisualStyleBackColor = true;
            // 
            // dgw1
            // 
            this.dgw1.AllowUserToAddRows = false;
            this.dgw1.AllowUserToDeleteRows = false;
            this.dgw1.AllowUserToOrderColumns = true;
            this.dgw1.AllowUserToResizeRows = false;
            this.dgw1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgw1.BackgroundColor = System.Drawing.Color.White;
            this.dgw1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgw1.Location = new System.Drawing.Point(39, 24);
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
            this.dgw1.Size = new System.Drawing.Size(367, 220);
            this.dgw1.TabIndex = 0;
            // 
            // TabPage2
            // 
            this.TabPage2.Controls.Add(this.GroupBox1);
            this.TabPage2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabPage2.Location = new System.Drawing.Point(4, 23);
            this.TabPage2.Name = "TabPage2";
            this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage2.Size = new System.Drawing.Size(572, 270);
            this.TabPage2.TabIndex = 1;
            this.TabPage2.Text = "Detalles";
            this.TabPage2.UseVisualStyleBackColor = true;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.Label5);
            this.GroupBox1.Controls.Add(this.cbo_tipo_cc);
            this.GroupBox1.Controls.Add(this.Label4);
            this.GroupBox1.Controls.Add(this.cbo_tipo);
            this.GroupBox1.Controls.Add(this.btn_cancelar);
            this.GroupBox1.Controls.Add(this.btn_modificar2);
            this.GroupBox1.Controls.Add(this.btn_guardar);
            this.GroupBox1.Controls.Add(this.txt_desc2);
            this.GroupBox1.Controls.Add(this.txt_desc);
            this.GroupBox1.Controls.Add(this.txt_cod);
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Location = new System.Drawing.Point(56, 41);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(461, 203);
            this.GroupBox1.TabIndex = 1;
            this.GroupBox1.TabStop = false;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(17, 131);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(50, 14);
            this.Label5.TabIndex = 10;
            this.Label5.Text = "Tipo C.C.";
            // 
            // cbo_tipo_cc
            // 
            this.cbo_tipo_cc.BackColor = System.Drawing.Color.White;
            this.cbo_tipo_cc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_tipo_cc.FormattingEnabled = true;
            this.cbo_tipo_cc.Items.AddRange(new object[] {
            "PRODUCCIÓN",
            "ADMINISTRACIÓN",
            "ALMACÉN",
            "VENTAS",
            "SERVICIOS"});
            this.cbo_tipo_cc.Location = new System.Drawing.Point(94, 128);
            this.cbo_tipo_cc.Name = "cbo_tipo_cc";
            this.cbo_tipo_cc.Size = new System.Drawing.Size(123, 22);
            this.cbo_tipo_cc.TabIndex = 4;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(17, 51);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(27, 14);
            this.Label4.TabIndex = 8;
            this.Label4.Text = "Tipo";
            // 
            // cbo_tipo
            // 
            this.cbo_tipo.BackColor = System.Drawing.Color.White;
            this.cbo_tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_tipo.FormattingEnabled = true;
            this.cbo_tipo.Items.AddRange(new object[] {
            "FONDO FIJO",
            "RENDICIONES",
            "REQUISICIÓN"});
            this.cbo_tipo.Location = new System.Drawing.Point(94, 48);
            this.cbo_tipo.Name = "cbo_tipo";
            this.cbo_tipo.Size = new System.Drawing.Size(90, 22);
            this.cbo_tipo.TabIndex = 1;
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_cancelar.Location = new System.Drawing.Point(367, 155);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(77, 27);
            this.btn_cancelar.TabIndex = 6;
            this.btn_cancelar.Text = "&Cancelar";
            this.btn_cancelar.UseVisualStyleBackColor = true;
            // 
            // btn_modificar2
            // 
            this.btn_modificar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_modificar2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_modificar2.Location = new System.Drawing.Point(284, 155);
            this.btn_modificar2.Name = "btn_modificar2";
            this.btn_modificar2.Size = new System.Drawing.Size(77, 27);
            this.btn_modificar2.TabIndex = 5;
            this.btn_modificar2.Text = "&Guardar";
            this.btn_modificar2.UseVisualStyleBackColor = true;
            // 
            // btn_guardar
            // 
            this.btn_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_guardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_guardar.Location = new System.Drawing.Point(284, 155);
            this.btn_guardar.Name = "btn_guardar";
            this.btn_guardar.Size = new System.Drawing.Size(77, 27);
            this.btn_guardar.TabIndex = 5;
            this.btn_guardar.Text = "&Guardar";
            this.btn_guardar.UseVisualStyleBackColor = true;
            // 
            // txt_desc2
            // 
            this.txt_desc2.BackColor = System.Drawing.Color.White;
            this.txt_desc2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_desc2.Location = new System.Drawing.Point(94, 102);
            this.txt_desc2.MaxLength = 30;
            this.txt_desc2.Name = "txt_desc2";
            this.txt_desc2.Size = new System.Drawing.Size(250, 20);
            this.txt_desc2.TabIndex = 3;
            // 
            // txt_desc
            // 
            this.txt_desc.BackColor = System.Drawing.Color.White;
            this.txt_desc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_desc.Location = new System.Drawing.Point(94, 76);
            this.txt_desc.MaxLength = 60;
            this.txt_desc.Name = "txt_desc";
            this.txt_desc.Size = new System.Drawing.Size(350, 20);
            this.txt_desc.TabIndex = 2;
            // 
            // txt_cod
            // 
            this.txt_cod.BackColor = System.Drawing.Color.White;
            this.txt_cod.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_cod.Location = new System.Drawing.Point(94, 24);
            this.txt_cod.MaxLength = 2;
            this.txt_cod.Name = "txt_cod";
            this.txt_cod.Size = new System.Drawing.Size(30, 20);
            this.txt_cod.TabIndex = 0;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(17, 105);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(57, 14);
            this.Label3.TabIndex = 2;
            this.Label3.Text = "Abreviado";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(17, 79);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(64, 14);
            this.Label2.TabIndex = 1;
            this.Label2.Text = "Descripción";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(17, 27);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(40, 14);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Codigo";
            // 
            // FFIJO_REND
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 297);
            this.Controls.Add(this.TabControl1);
            this.Name = "FFIJO_REND";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento de Área";
            this.TabControl1.ResumeLayout(false);
            this.TabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgw1)).EndInit();
            this.TabPage2.ResumeLayout(false);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
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
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.ComboBox cbo_tipo_cc;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.ComboBox cbo_tipo;
        internal System.Windows.Forms.Button btn_cancelar;
        internal System.Windows.Forms.Button btn_modificar2;
        internal System.Windows.Forms.Button btn_guardar;
        internal System.Windows.Forms.TextBox txt_desc2;
        internal System.Windows.Forms.TextBox txt_desc;
        internal System.Windows.Forms.TextBox txt_cod;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
    }
}