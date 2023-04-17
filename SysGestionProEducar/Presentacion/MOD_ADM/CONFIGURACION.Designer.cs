namespace Presentacion.MOD_ADM
{
    partial class CONFIGURACION
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
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.dgw1 = new System.Windows.Forms.DataGridView();
            this.BTN_ELIMINAR = new System.Windows.Forms.Button();
            this.btn_salir = new System.Windows.Forms.Button();
            this.btn_nuevo = new System.Windows.Forms.Button();
            this.btn_modificar = new System.Windows.Forms.Button();
            this.TabPage2 = new System.Windows.Forms.TabPage();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.TIPO_DOC = new System.Windows.Forms.CheckBox();
            this.CBO_TIPO_DOC = new System.Windows.Forms.ComboBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.txt_desc = new System.Windows.Forms.TextBox();
            this.txt_cod = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.btn_guardar = new System.Windows.Forms.Button();
            this.btn_Cancelar = new System.Windows.Forms.Button();
            this.btn_modificar2 = new System.Windows.Forms.Button();
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
            this.TabControl1.ItemSize = new System.Drawing.Size(240, 20);
            this.TabControl1.Location = new System.Drawing.Point(0, 0);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(573, 297);
            this.TabControl1.TabIndex = 1;
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.dgw1);
            this.TabPage1.Controls.Add(this.BTN_ELIMINAR);
            this.TabPage1.Controls.Add(this.btn_salir);
            this.TabPage1.Controls.Add(this.btn_nuevo);
            this.TabPage1.Controls.Add(this.btn_modificar);
            this.TabPage1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabPage1.Location = new System.Drawing.Point(4, 24);
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage1.Size = new System.Drawing.Size(565, 269);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "Lista de Documentos";
            this.TabPage1.UseVisualStyleBackColor = true;
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
            this.dgw1.Location = new System.Drawing.Point(49, 20);
            this.dgw1.MultiSelect = false;
            this.dgw1.Name = "dgw1";
            this.dgw1.ReadOnly = true;
            this.dgw1.RowHeadersWidth = 25;
            this.dgw1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dgw1.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.dgw1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgw1.Size = new System.Drawing.Size(375, 200);
            this.dgw1.TabIndex = 0;
            // 
            // BTN_ELIMINAR
            // 
            this.BTN_ELIMINAR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_ELIMINAR.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTN_ELIMINAR.Location = new System.Drawing.Point(450, 102);
            this.BTN_ELIMINAR.Name = "BTN_ELIMINAR";
            this.BTN_ELIMINAR.Size = new System.Drawing.Size(85, 35);
            this.BTN_ELIMINAR.TabIndex = 3;
            this.BTN_ELIMINAR.Text = "&Eliminar";
            this.BTN_ELIMINAR.UseVisualStyleBackColor = true;
            // 
            // btn_salir
            // 
            this.btn_salir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_salir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_salir.Location = new System.Drawing.Point(450, 143);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(85, 35);
            this.btn_salir.TabIndex = 4;
            this.btn_salir.Text = "&Salir";
            this.btn_salir.UseVisualStyleBackColor = true;
            // 
            // btn_nuevo
            // 
            this.btn_nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_nuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_nuevo.Location = new System.Drawing.Point(450, 20);
            this.btn_nuevo.Name = "btn_nuevo";
            this.btn_nuevo.Size = new System.Drawing.Size(85, 35);
            this.btn_nuevo.TabIndex = 1;
            this.btn_nuevo.Text = "&Nuevo";
            this.btn_nuevo.UseVisualStyleBackColor = true;
            // 
            // btn_modificar
            // 
            this.btn_modificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_modificar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_modificar.Location = new System.Drawing.Point(450, 61);
            this.btn_modificar.Name = "btn_modificar";
            this.btn_modificar.Size = new System.Drawing.Size(85, 35);
            this.btn_modificar.TabIndex = 2;
            this.btn_modificar.Text = "&Modificar";
            this.btn_modificar.UseVisualStyleBackColor = true;
            // 
            // TabPage2
            // 
            this.TabPage2.Controls.Add(this.GroupBox1);
            this.TabPage2.Location = new System.Drawing.Point(4, 24);
            this.TabPage2.Name = "TabPage2";
            this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage2.Size = new System.Drawing.Size(565, 269);
            this.TabPage2.TabIndex = 1;
            this.TabPage2.Text = "Detalles";
            this.TabPage2.UseVisualStyleBackColor = true;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.TIPO_DOC);
            this.GroupBox1.Controls.Add(this.CBO_TIPO_DOC);
            this.GroupBox1.Controls.Add(this.Label5);
            this.GroupBox1.Controls.Add(this.txt_desc);
            this.GroupBox1.Controls.Add(this.txt_cod);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Controls.Add(this.btn_guardar);
            this.GroupBox1.Controls.Add(this.btn_Cancelar);
            this.GroupBox1.Controls.Add(this.btn_modificar2);
            this.GroupBox1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox1.Location = new System.Drawing.Point(63, 37);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(464, 186);
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            // 
            // TIPO_DOC
            // 
            this.TIPO_DOC.AutoSize = true;
            this.TIPO_DOC.Location = new System.Drawing.Point(328, 39);
            this.TIPO_DOC.Name = "TIPO_DOC";
            this.TIPO_DOC.Size = new System.Drawing.Size(117, 18);
            this.TIPO_DOC.TabIndex = 9;
            this.TIPO_DOC.Text = "Documentos Sunat";
            this.TIPO_DOC.UseVisualStyleBackColor = true;
            // 
            // CBO_TIPO_DOC
            // 
            this.CBO_TIPO_DOC.BackColor = System.Drawing.Color.White;
            this.CBO_TIPO_DOC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBO_TIPO_DOC.FormattingEnabled = true;
            this.CBO_TIPO_DOC.Location = new System.Drawing.Point(103, 37);
            this.CBO_TIPO_DOC.Name = "CBO_TIPO_DOC";
            this.CBO_TIPO_DOC.Size = new System.Drawing.Size(219, 22);
            this.CBO_TIPO_DOC.TabIndex = 10;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(14, 40);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(84, 14);
            this.Label5.TabIndex = 11;
            this.Label5.Text = "Tipo Documento";
            // 
            // txt_desc
            // 
            this.txt_desc.BackColor = System.Drawing.Color.White;
            this.txt_desc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_desc.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_desc.Location = new System.Drawing.Point(104, 92);
            this.txt_desc.MaxLength = 60;
            this.txt_desc.Name = "txt_desc";
            this.txt_desc.Size = new System.Drawing.Size(333, 20);
            this.txt_desc.TabIndex = 5;
            // 
            // txt_cod
            // 
            this.txt_cod.BackColor = System.Drawing.Color.White;
            this.txt_cod.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_cod.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_cod.Location = new System.Drawing.Point(104, 65);
            this.txt_cod.MaxLength = 6;
            this.txt_cod.Name = "txt_cod";
            this.txt_cod.Size = new System.Drawing.Size(70, 20);
            this.txt_cod.TabIndex = 1;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(17, 95);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(64, 14);
            this.Label2.TabIndex = 4;
            this.Label2.Text = "Descripción";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(17, 68);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(40, 14);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Codigo";
            // 
            // btn_guardar
            // 
            this.btn_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_guardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_guardar.Location = new System.Drawing.Point(263, 132);
            this.btn_guardar.Name = "btn_guardar";
            this.btn_guardar.Size = new System.Drawing.Size(77, 27);
            this.btn_guardar.TabIndex = 7;
            this.btn_guardar.Text = "&Guardar";
            this.btn_guardar.UseVisualStyleBackColor = true;
            // 
            // btn_Cancelar
            // 
            this.btn_Cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Cancelar.Location = new System.Drawing.Point(346, 132);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Size = new System.Drawing.Size(77, 27);
            this.btn_Cancelar.TabIndex = 8;
            this.btn_Cancelar.Text = "&Cancelar";
            this.btn_Cancelar.UseVisualStyleBackColor = true;
            // 
            // btn_modificar2
            // 
            this.btn_modificar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_modificar2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_modificar2.Location = new System.Drawing.Point(263, 132);
            this.btn_modificar2.Name = "btn_modificar2";
            this.btn_modificar2.Size = new System.Drawing.Size(77, 27);
            this.btn_modificar2.TabIndex = 6;
            this.btn_modificar2.Text = "&Modifcar";
            this.btn_modificar2.UseVisualStyleBackColor = true;
            // 
            // CONFIGURACION
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 297);
            this.Controls.Add(this.TabControl1);
            this.Name = "CONFIGURACION";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuracion de Opciones";
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
        internal System.Windows.Forms.DataGridView dgw1;
        internal System.Windows.Forms.Button BTN_ELIMINAR;
        internal System.Windows.Forms.Button btn_salir;
        internal System.Windows.Forms.Button btn_nuevo;
        internal System.Windows.Forms.Button btn_modificar;
        internal System.Windows.Forms.TabPage TabPage2;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.CheckBox TIPO_DOC;
        internal System.Windows.Forms.ComboBox CBO_TIPO_DOC;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.TextBox txt_desc;
        internal System.Windows.Forms.TextBox txt_cod;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Button btn_guardar;
        internal System.Windows.Forms.Button btn_Cancelar;
        internal System.Windows.Forms.Button btn_modificar2;
    }
}