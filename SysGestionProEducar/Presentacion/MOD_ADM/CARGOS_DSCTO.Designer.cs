namespace Presentacion.MOD_ADM
{
    partial class CARGOS_DSCTO
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
            this.dgw1 = new System.Windows.Forms.DataGridView();
            this.btn_salir = new System.Windows.Forms.Button();
            this.btn_modificar = new System.Windows.Forms.Button();
            this.btn_eliminar = new System.Windows.Forms.Button();
            this.btn_nuevo = new System.Windows.Forms.Button();
            this.TabPage2 = new System.Windows.Forms.TabPage();
            this.GB1 = new System.Windows.Forms.GroupBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.cbo_mov = new System.Windows.Forms.ComboBox();
            this.btn_guardar = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.btn_modificar2 = new System.Windows.Forms.Button();
            this.cbo_doc = new System.Windows.Forms.ComboBox();
            this.txt_desc2 = new System.Windows.Forms.TextBox();
            this.txt_desc = new System.Windows.Forms.TextBox();
            this.txt_cod = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.ch_cc = new System.Windows.Forms.CheckBox();
            this.ch_proyecto = new System.Windows.Forms.CheckBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
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
            this.TabControl1.Size = new System.Drawing.Size(602, 346);
            this.TabControl1.TabIndex = 2;
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.dgw1);
            this.TabPage1.Controls.Add(this.btn_salir);
            this.TabPage1.Controls.Add(this.btn_modificar);
            this.TabPage1.Controls.Add(this.btn_eliminar);
            this.TabPage1.Controls.Add(this.btn_nuevo);
            this.TabPage1.Font = new System.Drawing.Font("Arial", 8.25F);
            this.TabPage1.Location = new System.Drawing.Point(4, 23);
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage1.Size = new System.Drawing.Size(594, 319);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "Lista de Cargos /  Abonos";
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
            this.dgw1.Location = new System.Drawing.Point(26, 29);
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
            this.dgw1.Size = new System.Drawing.Size(413, 245);
            this.dgw1.TabIndex = 5;
            // 
            // btn_salir
            // 
            this.btn_salir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_salir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_salir.Location = new System.Drawing.Point(465, 165);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(85, 35);
            this.btn_salir.TabIndex = 4;
            this.btn_salir.Text = "&Salir";
            this.btn_salir.UseVisualStyleBackColor = true;
            // 
            // btn_modificar
            // 
            this.btn_modificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_modificar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_modificar.Location = new System.Drawing.Point(465, 82);
            this.btn_modificar.Name = "btn_modificar";
            this.btn_modificar.Size = new System.Drawing.Size(85, 35);
            this.btn_modificar.TabIndex = 2;
            this.btn_modificar.Text = "&Modificar";
            this.btn_modificar.UseVisualStyleBackColor = true;
            // 
            // btn_eliminar
            // 
            this.btn_eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_eliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_eliminar.Location = new System.Drawing.Point(465, 124);
            this.btn_eliminar.Name = "btn_eliminar";
            this.btn_eliminar.Size = new System.Drawing.Size(85, 35);
            this.btn_eliminar.TabIndex = 3;
            this.btn_eliminar.Text = "&Eliminar";
            this.btn_eliminar.UseVisualStyleBackColor = true;
            // 
            // btn_nuevo
            // 
            this.btn_nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_nuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_nuevo.Location = new System.Drawing.Point(465, 41);
            this.btn_nuevo.Name = "btn_nuevo";
            this.btn_nuevo.Size = new System.Drawing.Size(85, 35);
            this.btn_nuevo.TabIndex = 1;
            this.btn_nuevo.Text = "&Nuevo";
            this.btn_nuevo.UseVisualStyleBackColor = true;
            // 
            // TabPage2
            // 
            this.TabPage2.Controls.Add(this.GB1);
            this.TabPage2.Font = new System.Drawing.Font("Arial", 8.25F);
            this.TabPage2.Location = new System.Drawing.Point(4, 23);
            this.TabPage2.Name = "TabPage2";
            this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage2.Size = new System.Drawing.Size(594, 319);
            this.TabPage2.TabIndex = 1;
            this.TabPage2.Text = "Detalles";
            this.TabPage2.UseVisualStyleBackColor = true;
            // 
            // GB1
            // 
            this.GB1.Controls.Add(this.Label2);
            this.GB1.Controls.Add(this.btn_cancelar);
            this.GB1.Controls.Add(this.cbo_mov);
            this.GB1.Controls.Add(this.btn_guardar);
            this.GB1.Controls.Add(this.Label1);
            this.GB1.Controls.Add(this.btn_modificar2);
            this.GB1.Controls.Add(this.cbo_doc);
            this.GB1.Controls.Add(this.txt_desc2);
            this.GB1.Controls.Add(this.txt_desc);
            this.GB1.Controls.Add(this.txt_cod);
            this.GB1.Controls.Add(this.Label3);
            this.GB1.Controls.Add(this.ch_cc);
            this.GB1.Controls.Add(this.ch_proyecto);
            this.GB1.Controls.Add(this.Label5);
            this.GB1.Controls.Add(this.Label6);
            this.GB1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GB1.Location = new System.Drawing.Point(52, 65);
            this.GB1.Name = "GB1";
            this.GB1.Size = new System.Drawing.Size(504, 214);
            this.GB1.TabIndex = 11;
            this.GB1.TabStop = false;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Arial", 8.25F);
            this.Label2.Location = new System.Drawing.Point(10, 137);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(60, 14);
            this.Label2.TabIndex = 8;
            this.Label2.Text = "Movimiento";
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancelar.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_cancelar.Location = new System.Drawing.Point(410, 165);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(77, 27);
            this.btn_cancelar.TabIndex = 6;
            this.btn_cancelar.Text = "&Cancelar";
            this.btn_cancelar.UseVisualStyleBackColor = true;
            // 
            // cbo_mov
            // 
            this.cbo_mov.BackColor = System.Drawing.Color.White;
            this.cbo_mov.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_mov.Font = new System.Drawing.Font("Arial", 8.25F);
            this.cbo_mov.FormattingEnabled = true;
            this.cbo_mov.Items.AddRange(new object[] {
            "Cargo",
            "Abono"});
            this.cbo_mov.Location = new System.Drawing.Point(78, 132);
            this.cbo_mov.Name = "cbo_mov";
            this.cbo_mov.Size = new System.Drawing.Size(143, 22);
            this.cbo_mov.TabIndex = 4;
            // 
            // btn_guardar
            // 
            this.btn_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_guardar.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_guardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_guardar.Location = new System.Drawing.Point(327, 165);
            this.btn_guardar.Name = "btn_guardar";
            this.btn_guardar.Size = new System.Drawing.Size(77, 27);
            this.btn_guardar.TabIndex = 5;
            this.btn_guardar.Text = "&Guardar";
            this.btn_guardar.UseVisualStyleBackColor = true;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Arial", 8.25F);
            this.Label1.Location = new System.Drawing.Point(10, 110);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(61, 14);
            this.Label1.TabIndex = 6;
            this.Label1.Text = "Documento";
            // 
            // btn_modificar2
            // 
            this.btn_modificar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_modificar2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_modificar2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_modificar2.Location = new System.Drawing.Point(327, 165);
            this.btn_modificar2.Name = "btn_modificar2";
            this.btn_modificar2.Size = new System.Drawing.Size(77, 27);
            this.btn_modificar2.TabIndex = 5;
            this.btn_modificar2.Text = "&Modificar";
            this.btn_modificar2.UseVisualStyleBackColor = true;
            // 
            // cbo_doc
            // 
            this.cbo_doc.BackColor = System.Drawing.Color.White;
            this.cbo_doc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_doc.Font = new System.Drawing.Font("Arial", 8.25F);
            this.cbo_doc.FormattingEnabled = true;
            this.cbo_doc.Items.AddRange(new object[] {
            "Compras",
            "Ventas"});
            this.cbo_doc.Location = new System.Drawing.Point(78, 104);
            this.cbo_doc.Name = "cbo_doc";
            this.cbo_doc.Size = new System.Drawing.Size(143, 22);
            this.cbo_doc.TabIndex = 3;
            // 
            // txt_desc2
            // 
            this.txt_desc2.BackColor = System.Drawing.Color.White;
            this.txt_desc2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_desc2.Font = new System.Drawing.Font("Arial", 8.25F);
            this.txt_desc2.Location = new System.Drawing.Point(78, 78);
            this.txt_desc2.MaxLength = 30;
            this.txt_desc2.Name = "txt_desc2";
            this.txt_desc2.Size = new System.Drawing.Size(200, 20);
            this.txt_desc2.TabIndex = 2;
            // 
            // txt_desc
            // 
            this.txt_desc.BackColor = System.Drawing.Color.White;
            this.txt_desc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_desc.Font = new System.Drawing.Font("Arial", 8.25F);
            this.txt_desc.Location = new System.Drawing.Point(78, 52);
            this.txt_desc.MaxLength = 60;
            this.txt_desc.Name = "txt_desc";
            this.txt_desc.Size = new System.Drawing.Size(409, 20);
            this.txt_desc.TabIndex = 1;
            // 
            // txt_cod
            // 
            this.txt_cod.BackColor = System.Drawing.Color.White;
            this.txt_cod.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_cod.Font = new System.Drawing.Font("Arial", 8.25F);
            this.txt_cod.Location = new System.Drawing.Point(78, 26);
            this.txt_cod.MaxLength = 10;
            this.txt_cod.Name = "txt_cod";
            this.txt_cod.Size = new System.Drawing.Size(95, 20);
            this.txt_cod.TabIndex = 0;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Arial", 8.25F);
            this.Label3.Location = new System.Drawing.Point(10, 83);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(64, 14);
            this.Label3.TabIndex = 0;
            this.Label3.Text = "Abreviatura";
            // 
            // ch_cc
            // 
            this.ch_cc.AutoSize = true;
            this.ch_cc.Font = new System.Drawing.Font("Arial", 8.25F);
            this.ch_cc.Location = new System.Drawing.Point(287, 100);
            this.ch_cc.Name = "ch_cc";
            this.ch_cc.Size = new System.Drawing.Size(109, 18);
            this.ch_cc.TabIndex = 10;
            this.ch_cc.TabStop = false;
            this.ch_cc.Text = "Centro de costos";
            this.ch_cc.UseVisualStyleBackColor = true;
            // 
            // ch_proyecto
            // 
            this.ch_proyecto.AutoSize = true;
            this.ch_proyecto.Font = new System.Drawing.Font("Arial", 8.25F);
            this.ch_proyecto.Location = new System.Drawing.Point(287, 124);
            this.ch_proyecto.Name = "ch_proyecto";
            this.ch_proyecto.Size = new System.Drawing.Size(69, 18);
            this.ch_proyecto.TabIndex = 11;
            this.ch_proyecto.TabStop = false;
            this.ch_proyecto.Text = "Proyecto";
            this.ch_proyecto.UseVisualStyleBackColor = true;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Arial", 8.25F);
            this.Label5.Location = new System.Drawing.Point(10, 56);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(64, 14);
            this.Label5.TabIndex = 0;
            this.Label5.Text = "Descripción";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Font = new System.Drawing.Font("Arial", 8.25F);
            this.Label6.Location = new System.Drawing.Point(10, 29);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(40, 14);
            this.Label6.TabIndex = 0;
            this.Label6.Text = "Código";
            // 
            // CARGOS_DSCTO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 346);
            this.Controls.Add(this.TabControl1);
            this.Name = "CARGOS_DSCTO";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cargos Descuento";
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
        internal System.Windows.Forms.DataGridView dgw1;
        internal System.Windows.Forms.Button btn_salir;
        internal System.Windows.Forms.Button btn_modificar;
        internal System.Windows.Forms.Button btn_eliminar;
        internal System.Windows.Forms.Button btn_nuevo;
        internal System.Windows.Forms.TabPage TabPage2;
        internal System.Windows.Forms.GroupBox GB1;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Button btn_cancelar;
        internal System.Windows.Forms.ComboBox cbo_mov;
        internal System.Windows.Forms.Button btn_guardar;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Button btn_modificar2;
        internal System.Windows.Forms.ComboBox cbo_doc;
        internal System.Windows.Forms.TextBox txt_desc2;
        internal System.Windows.Forms.TextBox txt_desc;
        internal System.Windows.Forms.TextBox txt_cod;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.CheckBox ch_cc;
        internal System.Windows.Forms.CheckBox ch_proyecto;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label6;
    }
}