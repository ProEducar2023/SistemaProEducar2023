namespace Presentacion.MOD_ADM
{
    partial class CPTO_PORCENTAJE
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.dgw1 = new System.Windows.Forms.DataGridView();
            this.btn_salir = new System.Windows.Forms.Button();
            this.btn_nuevo = new System.Windows.Forms.Button();
            this.btn_eliminar = new System.Windows.Forms.Button();
            this.btn_modificar = new System.Windows.Forms.Button();
            this.TabPage2 = new System.Windows.Forms.TabPage();
            this.panel_cpto = new System.Windows.Forms.Panel();
            this.dgw_cpto = new System.Windows.Forms.DataGridView();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.dgw_det = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_guardar = new System.Windows.Forms.Button();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_cod_cpto = new System.Windows.Forms.TextBox();
            this.txt_desc_cpto = new System.Windows.Forms.TextBox();
            this.Label10 = new System.Windows.Forms.Label();
            this.K1 = new System.Windows.Forms.TextBox();
            this.TabControl1.SuspendLayout();
            this.TabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw1)).BeginInit();
            this.TabPage2.SuspendLayout();
            this.panel_cpto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw_cpto)).BeginInit();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw_det)).BeginInit();
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
            this.TabControl1.Size = new System.Drawing.Size(581, 375);
            this.TabControl1.TabIndex = 7;
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.dgw1);
            this.TabPage1.Controls.Add(this.btn_salir);
            this.TabPage1.Controls.Add(this.btn_nuevo);
            this.TabPage1.Controls.Add(this.btn_eliminar);
            this.TabPage1.Controls.Add(this.btn_modificar);
            this.TabPage1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabPage1.Location = new System.Drawing.Point(4, 23);
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage1.Size = new System.Drawing.Size(573, 348);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "Lista de Conceptos";
            this.TabPage1.UseVisualStyleBackColor = true;
            // 
            // dgw1
            // 
            this.dgw1.AllowUserToAddRows = false;
            this.dgw1.AllowUserToDeleteRows = false;
            this.dgw1.BackgroundColor = System.Drawing.Color.White;
            this.dgw1.Location = new System.Drawing.Point(66, 38);
            this.dgw1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dgw1.MultiSelect = false;
            this.dgw1.Name = "dgw1";
            this.dgw1.ReadOnly = true;
            this.dgw1.RowHeadersWidth = 18;
            this.dgw1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dgw1.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.dgw1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgw1.Size = new System.Drawing.Size(355, 266);
            this.dgw1.TabIndex = 13;
            // 
            // btn_salir
            // 
            this.btn_salir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_salir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_salir.Location = new System.Drawing.Point(454, 161);
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
            this.btn_nuevo.Location = new System.Drawing.Point(454, 38);
            this.btn_nuevo.Name = "btn_nuevo";
            this.btn_nuevo.Size = new System.Drawing.Size(85, 35);
            this.btn_nuevo.TabIndex = 1;
            this.btn_nuevo.Text = "&Nuevo";
            this.btn_nuevo.UseVisualStyleBackColor = true;
            // 
            // btn_eliminar
            // 
            this.btn_eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_eliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_eliminar.Location = new System.Drawing.Point(454, 120);
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
            this.btn_modificar.Location = new System.Drawing.Point(454, 79);
            this.btn_modificar.Name = "btn_modificar";
            this.btn_modificar.Size = new System.Drawing.Size(85, 35);
            this.btn_modificar.TabIndex = 2;
            this.btn_modificar.Text = "&Modificar";
            this.btn_modificar.UseVisualStyleBackColor = true;
            // 
            // TabPage2
            // 
            this.TabPage2.Controls.Add(this.panel_cpto);
            this.TabPage2.Controls.Add(this.Panel1);
            this.TabPage2.Controls.Add(this.GroupBox1);
            this.TabPage2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabPage2.Location = new System.Drawing.Point(4, 23);
            this.TabPage2.Name = "TabPage2";
            this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage2.Size = new System.Drawing.Size(573, 348);
            this.TabPage2.TabIndex = 1;
            this.TabPage2.Text = "Detalles";
            this.TabPage2.UseVisualStyleBackColor = true;
            // 
            // panel_cpto
            // 
            this.panel_cpto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_cpto.Controls.Add(this.dgw_cpto);
            this.panel_cpto.Location = new System.Drawing.Point(60, 69);
            this.panel_cpto.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel_cpto.Name = "panel_cpto";
            this.panel_cpto.Size = new System.Drawing.Size(468, 131);
            this.panel_cpto.TabIndex = 62;
            this.panel_cpto.Visible = false;
            // 
            // dgw_cpto
            // 
            this.dgw_cpto.AllowUserToAddRows = false;
            this.dgw_cpto.AllowUserToDeleteRows = false;
            this.dgw_cpto.AllowUserToOrderColumns = true;
            this.dgw_cpto.AllowUserToResizeRows = false;
            this.dgw_cpto.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgw_cpto.BackgroundColor = System.Drawing.Color.White;
            this.dgw_cpto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgw_cpto.Location = new System.Drawing.Point(37, -1);
            this.dgw_cpto.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dgw_cpto.MultiSelect = false;
            this.dgw_cpto.Name = "dgw_cpto";
            this.dgw_cpto.ReadOnly = true;
            this.dgw_cpto.RowHeadersWidth = 25;
            this.dgw_cpto.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dgw_cpto.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.dgw_cpto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgw_cpto.Size = new System.Drawing.Size(419, 120);
            this.dgw_cpto.TabIndex = 0;
            this.dgw_cpto.TabStop = false;
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.btn_cancelar);
            this.Panel1.Controls.Add(this.dgw_det);
            this.Panel1.Controls.Add(this.btn_guardar);
            this.Panel1.Location = new System.Drawing.Point(2, 123);
            this.Panel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(575, 223);
            this.Panel1.TabIndex = 1;
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_cancelar.Location = new System.Drawing.Point(486, 105);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(77, 27);
            this.btn_cancelar.TabIndex = 11;
            this.btn_cancelar.Text = "&Cancelar";
            this.btn_cancelar.UseVisualStyleBackColor = true;
            // 
            // dgw_det
            // 
            this.dgw_det.AllowUserToAddRows = false;
            this.dgw_det.AllowUserToDeleteRows = false;
            this.dgw_det.AllowUserToOrderColumns = true;
            this.dgw_det.AllowUserToResizeRows = false;
            this.dgw_det.BackgroundColor = System.Drawing.Color.White;
            this.dgw_det.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column3,
            this.Column4});
            this.dgw_det.Location = new System.Drawing.Point(26, 0);
            this.dgw_det.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dgw_det.MultiSelect = false;
            this.dgw_det.Name = "dgw_det";
            this.dgw_det.RowHeadersWidth = 25;
            this.dgw_det.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dgw_det.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.dgw_det.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgw_det.Size = new System.Drawing.Size(455, 223);
            this.dgw_det.TabIndex = 300;
            this.dgw_det.TabStop = false;
            // 
            // Column1
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column1.HeaderText = "Cód.CC.";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 65;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Descripción Centro de Costos";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 260;
            // 
            // Column4
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "n2";
            this.Column4.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column4.HeaderText = "           %";
            this.Column4.Name = "Column4";
            this.Column4.Width = 90;
            // 
            // btn_guardar
            // 
            this.btn_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_guardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_guardar.Location = new System.Drawing.Point(486, 72);
            this.btn_guardar.Name = "btn_guardar";
            this.btn_guardar.Size = new System.Drawing.Size(77, 27);
            this.btn_guardar.TabIndex = 10;
            this.btn_guardar.Text = "&Guardar";
            this.btn_guardar.UseVisualStyleBackColor = true;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.txt_cod_cpto);
            this.GroupBox1.Controls.Add(this.txt_desc_cpto);
            this.GroupBox1.Controls.Add(this.Label10);
            this.GroupBox1.Controls.Add(this.K1);
            this.GroupBox1.Location = new System.Drawing.Point(28, 23);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(500, 83);
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            // 
            // txt_cod_cpto
            // 
            this.txt_cod_cpto.BackColor = System.Drawing.Color.White;
            this.txt_cod_cpto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_cod_cpto.Location = new System.Drawing.Point(69, 25);
            this.txt_cod_cpto.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_cod_cpto.MaxLength = 10;
            this.txt_cod_cpto.Name = "txt_cod_cpto";
            this.txt_cod_cpto.Size = new System.Drawing.Size(84, 20);
            this.txt_cod_cpto.TabIndex = 0;
            // 
            // txt_desc_cpto
            // 
            this.txt_desc_cpto.BackColor = System.Drawing.Color.White;
            this.txt_desc_cpto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_desc_cpto.Location = new System.Drawing.Point(152, 25);
            this.txt_desc_cpto.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_desc_cpto.Name = "txt_desc_cpto";
            this.txt_desc_cpto.Size = new System.Drawing.Size(337, 20);
            this.txt_desc_cpto.TabIndex = 1;
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.Location = new System.Drawing.Point(10, 31);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(53, 14);
            this.Label10.TabIndex = 61;
            this.Label10.Text = "Concepto";
            // 
            // K1
            // 
            this.K1.BackColor = System.Drawing.Color.White;
            this.K1.Location = new System.Drawing.Point(292, 25);
            this.K1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.K1.Name = "K1";
            this.K1.Size = new System.Drawing.Size(10, 20);
            this.K1.TabIndex = 2;
            this.K1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // CPTO_PORCENTAJE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 375);
            this.Controls.Add(this.TabControl1);
            this.Name = "CPTO_PORCENTAJE";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento de Conceptos  %";
            this.TabControl1.ResumeLayout(false);
            this.TabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgw1)).EndInit();
            this.TabPage2.ResumeLayout(false);
            this.panel_cpto.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgw_cpto)).EndInit();
            this.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgw_det)).EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TabControl TabControl1;
        internal System.Windows.Forms.TabPage TabPage1;
        internal System.Windows.Forms.DataGridView dgw1;
        internal System.Windows.Forms.Button btn_salir;
        internal System.Windows.Forms.Button btn_nuevo;
        internal System.Windows.Forms.Button btn_eliminar;
        internal System.Windows.Forms.Button btn_modificar;
        internal System.Windows.Forms.TabPage TabPage2;
        internal System.Windows.Forms.Panel panel_cpto;
        internal System.Windows.Forms.DataGridView dgw_cpto;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Button btn_cancelar;
        internal System.Windows.Forms.DataGridView dgw_det;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        internal System.Windows.Forms.Button btn_guardar;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.TextBox txt_cod_cpto;
        internal System.Windows.Forms.TextBox txt_desc_cpto;
        internal System.Windows.Forms.Label Label10;
        internal System.Windows.Forms.TextBox K1;
    }
}