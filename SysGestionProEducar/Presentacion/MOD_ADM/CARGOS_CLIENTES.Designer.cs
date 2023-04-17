namespace Presentacion.MOD_ADM
{
    partial class CARGOS_CLIENTES
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CARGOS_CLIENTES));
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.btn_salir = new System.Windows.Forms.Button();
            this.btn_eliminar = new System.Windows.Forms.Button();
            this.btn_modificar = new System.Windows.Forms.Button();
            this.btn_nuevo = new System.Windows.Forms.Button();
            this.dgw1 = new System.Windows.Forms.DataGridView();
            this.cod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TabPage2 = new System.Windows.Forms.TabPage();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.txtdescc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_desc = new System.Windows.Forms.TextBox();
            this.txt_cod = new System.Windows.Forms.TextBox();
            this.btn_guardar = new System.Windows.Forms.Button();
            this.btn_modificar2 = new System.Windows.Forms.Button();
            this.btn_cancelar = new System.Windows.Forms.Button();
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
            this.TabControl1.Size = new System.Drawing.Size(556, 288);
            this.TabControl1.TabIndex = 2;
            this.TabControl1.SelectedIndexChanged += new System.EventHandler(this.TabControl1_SelectedIndexChanged);
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
            this.TabPage1.Size = new System.Drawing.Size(548, 261);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "Lista de Cargos del Cliente";
            this.TabPage1.UseVisualStyleBackColor = true;
            // 
            // btn_salir
            // 
            this.btn_salir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_salir.Image = ((System.Drawing.Image)(resources.GetObject("btn_salir.Image")));
            this.btn_salir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_salir.Location = new System.Drawing.Point(412, 147);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(85, 35);
            this.btn_salir.TabIndex = 4;
            this.btn_salir.Text = "&Salir";
            this.btn_salir.UseVisualStyleBackColor = true;
            this.btn_salir.Click += new System.EventHandler(this.btn_salir_Click);
            // 
            // btn_eliminar
            // 
            this.btn_eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_eliminar.Image = ((System.Drawing.Image)(resources.GetObject("btn_eliminar.Image")));
            this.btn_eliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_eliminar.Location = new System.Drawing.Point(412, 106);
            this.btn_eliminar.Name = "btn_eliminar";
            this.btn_eliminar.Size = new System.Drawing.Size(85, 35);
            this.btn_eliminar.TabIndex = 3;
            this.btn_eliminar.Text = "&Eliminar";
            this.btn_eliminar.UseVisualStyleBackColor = true;
            this.btn_eliminar.Click += new System.EventHandler(this.btn_eliminar_Click);
            // 
            // btn_modificar
            // 
            this.btn_modificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_modificar.Image = ((System.Drawing.Image)(resources.GetObject("btn_modificar.Image")));
            this.btn_modificar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_modificar.Location = new System.Drawing.Point(412, 65);
            this.btn_modificar.Name = "btn_modificar";
            this.btn_modificar.Size = new System.Drawing.Size(85, 35);
            this.btn_modificar.TabIndex = 2;
            this.btn_modificar.Text = "&Modificar";
            this.btn_modificar.UseVisualStyleBackColor = true;
            this.btn_modificar.Click += new System.EventHandler(this.btn_modificar_Click);
            // 
            // btn_nuevo
            // 
            this.btn_nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_nuevo.Image = ((System.Drawing.Image)(resources.GetObject("btn_nuevo.Image")));
            this.btn_nuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_nuevo.Location = new System.Drawing.Point(412, 24);
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
            this.dgw1.AllowUserToResizeRows = false;
            this.dgw1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgw1.BackgroundColor = System.Drawing.Color.White;
            this.dgw1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgw1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cod,
            this.desc,
            this.descc});
            this.dgw1.Location = new System.Drawing.Point(78, 24);
            this.dgw1.MultiSelect = false;
            this.dgw1.Name = "dgw1";
            this.dgw1.ReadOnly = true;
            this.dgw1.RowHeadersWidth = 25;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            this.dgw1.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgw1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dgw1.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.dgw1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgw1.Size = new System.Drawing.Size(259, 200);
            this.dgw1.TabIndex = 0;
            // 
            // cod
            // 
            this.cod.FillWeight = 50.76142F;
            this.cod.HeaderText = "Cod";
            this.cod.Name = "cod";
            this.cod.ReadOnly = true;
            // 
            // desc
            // 
            this.desc.FillWeight = 149.2386F;
            this.desc.HeaderText = "Descripcion";
            this.desc.Name = "desc";
            this.desc.ReadOnly = true;
            // 
            // descc
            // 
            this.descc.HeaderText = "descc";
            this.descc.Name = "descc";
            this.descc.ReadOnly = true;
            this.descc.Visible = false;
            // 
            // TabPage2
            // 
            this.TabPage2.Controls.Add(this.GroupBox1);
            this.TabPage2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabPage2.Location = new System.Drawing.Point(4, 23);
            this.TabPage2.Name = "TabPage2";
            this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage2.Size = new System.Drawing.Size(548, 261);
            this.TabPage2.TabIndex = 1;
            this.TabPage2.Text = "Detalles";
            this.TabPage2.UseVisualStyleBackColor = true;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.txtdescc);
            this.GroupBox1.Controls.Add(this.label3);
            this.GroupBox1.Controls.Add(this.txt_desc);
            this.GroupBox1.Controls.Add(this.txt_cod);
            this.GroupBox1.Controls.Add(this.btn_guardar);
            this.GroupBox1.Controls.Add(this.btn_modificar2);
            this.GroupBox1.Controls.Add(this.btn_cancelar);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Location = new System.Drawing.Point(87, 52);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(364, 149);
            this.GroupBox1.TabIndex = 1;
            this.GroupBox1.TabStop = false;
            // 
            // txtdescc
            // 
            this.txtdescc.BackColor = System.Drawing.Color.White;
            this.txtdescc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtdescc.Location = new System.Drawing.Point(90, 71);
            this.txtdescc.MaxLength = 10;
            this.txtdescc.Name = "txtdescc";
            this.txtdescc.Size = new System.Drawing.Size(243, 20);
            this.txtdescc.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 14);
            this.label3.TabIndex = 5;
            this.label3.Text = "Desc. Corta";
            // 
            // txt_desc
            // 
            this.txt_desc.BackColor = System.Drawing.Color.White;
            this.txt_desc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_desc.Location = new System.Drawing.Point(90, 48);
            this.txt_desc.MaxLength = 20;
            this.txt_desc.Name = "txt_desc";
            this.txt_desc.Size = new System.Drawing.Size(243, 20);
            this.txt_desc.TabIndex = 2;
            // 
            // txt_cod
            // 
            this.txt_cod.BackColor = System.Drawing.Color.White;
            this.txt_cod.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_cod.Location = new System.Drawing.Point(90, 25);
            this.txt_cod.MaxLength = 3;
            this.txt_cod.Name = "txt_cod";
            this.txt_cod.Size = new System.Drawing.Size(30, 20);
            this.txt_cod.TabIndex = 1;
            // 
            // btn_guardar
            // 
            this.btn_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_guardar.Image = ((System.Drawing.Image)(resources.GetObject("btn_guardar.Image")));
            this.btn_guardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_guardar.Location = new System.Drawing.Point(174, 100);
            this.btn_guardar.Name = "btn_guardar";
            this.btn_guardar.Size = new System.Drawing.Size(77, 27);
            this.btn_guardar.TabIndex = 4;
            this.btn_guardar.Text = "&Guardar";
            this.btn_guardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_guardar.UseVisualStyleBackColor = true;
            this.btn_guardar.Click += new System.EventHandler(this.btn_guardar_Click);
            // 
            // btn_modificar2
            // 
            this.btn_modificar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_modificar2.Image = ((System.Drawing.Image)(resources.GetObject("btn_modificar2.Image")));
            this.btn_modificar2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_modificar2.Location = new System.Drawing.Point(174, 100);
            this.btn_modificar2.Name = "btn_modificar2";
            this.btn_modificar2.Size = new System.Drawing.Size(77, 27);
            this.btn_modificar2.TabIndex = 3;
            this.btn_modificar2.Text = "&Modificar";
            this.btn_modificar2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_modificar2.UseVisualStyleBackColor = true;
            this.btn_modificar2.Click += new System.EventHandler(this.btn_modificar2_Click);
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancelar.Image = ((System.Drawing.Image)(resources.GetObject("btn_cancelar.Image")));
            this.btn_cancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_cancelar.Location = new System.Drawing.Point(255, 100);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(77, 27);
            this.btn_cancelar.TabIndex = 5;
            this.btn_cancelar.Text = "&Cancelar";
            this.btn_cancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_cancelar.UseVisualStyleBackColor = true;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(19, 51);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(64, 14);
            this.Label2.TabIndex = 1;
            this.Label2.Text = "Descripción";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(19, 28);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(40, 14);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Codigo";
            // 
            // CARGOS_CLIENTES
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 288);
            this.ControlBox = false;
            this.Controls.Add(this.TabControl1);
            this.Name = "CARGOS_CLIENTES";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cargos del Cliente";
            this.Load += new System.EventHandler(this.CARGOS_CLIENTES_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CARGOS_CLIENTES_KeyDown);
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
        internal System.Windows.Forms.TextBox txt_desc;
        internal System.Windows.Forms.TextBox txt_cod;
        internal System.Windows.Forms.Button btn_guardar;
        internal System.Windows.Forms.Button btn_modificar2;
        internal System.Windows.Forms.Button btn_cancelar;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cod;
        private System.Windows.Forms.DataGridViewTextBoxColumn desc;
        private System.Windows.Forms.DataGridViewTextBoxColumn descc;
        internal System.Windows.Forms.TextBox txtdescc;
        internal System.Windows.Forms.Label label3;
    }
}