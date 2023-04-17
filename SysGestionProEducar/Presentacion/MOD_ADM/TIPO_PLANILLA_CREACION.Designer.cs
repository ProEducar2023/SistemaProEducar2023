namespace Presentacion.MOD_ADM
{
    partial class TIPO_PLANILLA_CREACION
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TIPO_PLANILLA_CREACION));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.btn_salir = new System.Windows.Forms.Button();
            this.btn_eliminar = new System.Windows.Forms.Button();
            this.btn_modificar = new System.Windows.Forms.Button();
            this.btn_nuevo = new System.Windows.Forms.Button();
            this.dgw1 = new System.Windows.Forms.DataGridView();
            this.CODIGO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COD_TIPO_PLLA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COD_TIPO_OPERACION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESC_TIPO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESC_CORTA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COD_VENTA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OBSERVACION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STATUS_GENERACION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STATUS_CTACTE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TabPage2 = new System.Windows.Forms.TabPage();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.chk_st_cta_cte = new System.Windows.Forms.CheckBox();
            this.cbo_cod_venta = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbo_tipo_ope = new System.Windows.Forms.ComboBox();
            this.txt_observacion = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chk_st_gen = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_tipo_plla = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
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
            this.TabControl1.Size = new System.Drawing.Size(556, 315);
            this.TabControl1.TabIndex = 4;
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
            this.TabPage1.Size = new System.Drawing.Size(548, 288);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "Lista de Tipos de Planilla";
            this.TabPage1.UseVisualStyleBackColor = true;
            // 
            // btn_salir
            // 
            this.btn_salir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_salir.Image = ((System.Drawing.Image)(resources.GetObject("btn_salir.Image")));
            this.btn_salir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_salir.Location = new System.Drawing.Point(447, 147);
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
            this.btn_eliminar.Location = new System.Drawing.Point(447, 106);
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
            this.btn_modificar.Location = new System.Drawing.Point(447, 65);
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
            this.btn_nuevo.Location = new System.Drawing.Point(447, 24);
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
            this.dgw1.BackgroundColor = System.Drawing.Color.White;
            this.dgw1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgw1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CODIGO,
            this.COD_TIPO_PLLA,
            this.COD_TIPO_OPERACION,
            this.DESC_TIPO,
            this.DESC_CORTA,
            this.COD_VENTA,
            this.OBSERVACION,
            this.STATUS_GENERACION,
            this.STATUS_CTACTE});
            this.dgw1.Location = new System.Drawing.Point(19, 24);
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
            this.dgw1.Size = new System.Drawing.Size(415, 200);
            this.dgw1.TabIndex = 0;
            // 
            // CODIGO
            // 
            this.CODIGO.FillWeight = 50.76142F;
            this.CODIGO.HeaderText = "CODIGO";
            this.CODIGO.Name = "CODIGO";
            this.CODIGO.ReadOnly = true;
            this.CODIGO.Visible = false;
            this.CODIGO.Width = 30;
            // 
            // COD_TIPO_PLLA
            // 
            this.COD_TIPO_PLLA.FillWeight = 149.2386F;
            this.COD_TIPO_PLLA.HeaderText = "Tipo Plla";
            this.COD_TIPO_PLLA.Name = "COD_TIPO_PLLA";
            this.COD_TIPO_PLLA.ReadOnly = true;
            this.COD_TIPO_PLLA.Width = 71;
            // 
            // COD_TIPO_OPERACION
            // 
            this.COD_TIPO_OPERACION.HeaderText = "Tipo Ope";
            this.COD_TIPO_OPERACION.Name = "COD_TIPO_OPERACION";
            this.COD_TIPO_OPERACION.ReadOnly = true;
            this.COD_TIPO_OPERACION.Width = 73;
            // 
            // DESC_TIPO
            // 
            this.DESC_TIPO.HeaderText = "Descripcion";
            this.DESC_TIPO.Name = "DESC_TIPO";
            this.DESC_TIPO.ReadOnly = true;
            this.DESC_TIPO.Width = 220;
            // 
            // DESC_CORTA
            // 
            this.DESC_CORTA.HeaderText = "DESC_CORTA";
            this.DESC_CORTA.Name = "DESC_CORTA";
            this.DESC_CORTA.ReadOnly = true;
            this.DESC_CORTA.Visible = false;
            // 
            // COD_VENTA
            // 
            this.COD_VENTA.HeaderText = "COD_VENTA";
            this.COD_VENTA.Name = "COD_VENTA";
            this.COD_VENTA.ReadOnly = true;
            this.COD_VENTA.Visible = false;
            // 
            // OBSERVACION
            // 
            this.OBSERVACION.HeaderText = "OBSERVACION";
            this.OBSERVACION.Name = "OBSERVACION";
            this.OBSERVACION.ReadOnly = true;
            this.OBSERVACION.Visible = false;
            this.OBSERVACION.Width = 30;
            // 
            // STATUS_GENERACION
            // 
            this.STATUS_GENERACION.HeaderText = "STATUS_GENERACION";
            this.STATUS_GENERACION.Name = "STATUS_GENERACION";
            this.STATUS_GENERACION.ReadOnly = true;
            this.STATUS_GENERACION.Visible = false;
            // 
            // STATUS_CTACTE
            // 
            this.STATUS_CTACTE.HeaderText = "STATUS_CTACTE";
            this.STATUS_CTACTE.Name = "STATUS_CTACTE";
            this.STATUS_CTACTE.ReadOnly = true;
            this.STATUS_CTACTE.Visible = false;
            // 
            // TabPage2
            // 
            this.TabPage2.Controls.Add(this.GroupBox1);
            this.TabPage2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabPage2.Location = new System.Drawing.Point(4, 23);
            this.TabPage2.Name = "TabPage2";
            this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage2.Size = new System.Drawing.Size(548, 288);
            this.TabPage2.TabIndex = 1;
            this.TabPage2.Text = "Detalles";
            this.TabPage2.UseVisualStyleBackColor = true;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.chk_st_cta_cte);
            this.GroupBox1.Controls.Add(this.cbo_cod_venta);
            this.GroupBox1.Controls.Add(this.label7);
            this.GroupBox1.Controls.Add(this.cbo_tipo_ope);
            this.GroupBox1.Controls.Add(this.txt_observacion);
            this.GroupBox1.Controls.Add(this.label6);
            this.GroupBox1.Controls.Add(this.chk_st_gen);
            this.GroupBox1.Controls.Add(this.label5);
            this.GroupBox1.Controls.Add(this.txt_tipo_plla);
            this.GroupBox1.Controls.Add(this.label4);
            this.GroupBox1.Controls.Add(this.txtdescc);
            this.GroupBox1.Controls.Add(this.label3);
            this.GroupBox1.Controls.Add(this.txt_desc);
            this.GroupBox1.Controls.Add(this.txt_cod);
            this.GroupBox1.Controls.Add(this.btn_guardar);
            this.GroupBox1.Controls.Add(this.btn_modificar2);
            this.GroupBox1.Controls.Add(this.btn_cancelar);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Location = new System.Drawing.Point(59, 17);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(423, 253);
            this.GroupBox1.TabIndex = 1;
            this.GroupBox1.TabStop = false;
            // 
            // chk_st_cta_cte
            // 
            this.chk_st_cta_cte.AutoSize = true;
            this.chk_st_cta_cte.Location = new System.Drawing.Point(255, 179);
            this.chk_st_cta_cte.Name = "chk_st_cta_cte";
            this.chk_st_cta_cte.Size = new System.Drawing.Size(95, 18);
            this.chk_st_cta_cte.TabIndex = 14;
            this.chk_st_cta_cte.Text = "Status Cta Cte";
            this.chk_st_cta_cte.UseVisualStyleBackColor = true;
            // 
            // cbo_cod_venta
            // 
            this.cbo_cod_venta.BackColor = System.Drawing.Color.White;
            this.cbo_cod_venta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_cod_venta.FormattingEnabled = true;
            this.cbo_cod_venta.Location = new System.Drawing.Point(110, 132);
            this.cbo_cod_venta.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cbo_cod_venta.Name = "cbo_cod_venta";
            this.cbo_cod_venta.Size = new System.Drawing.Size(102, 22);
            this.cbo_cod_venta.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(29, 136);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 14);
            this.label7.TabIndex = 214;
            this.label7.Text = "Cod Venta";
            // 
            // cbo_tipo_ope
            // 
            this.cbo_tipo_ope.BackColor = System.Drawing.Color.White;
            this.cbo_tipo_ope.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_tipo_ope.FormattingEnabled = true;
            this.cbo_tipo_ope.Location = new System.Drawing.Point(110, 62);
            this.cbo_tipo_ope.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cbo_tipo_ope.Name = "cbo_tipo_ope";
            this.cbo_tipo_ope.Size = new System.Drawing.Size(62, 22);
            this.cbo_tipo_ope.TabIndex = 5;
            // 
            // txt_observacion
            // 
            this.txt_observacion.BackColor = System.Drawing.Color.White;
            this.txt_observacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_observacion.Location = new System.Drawing.Point(110, 157);
            this.txt_observacion.MaxLength = 50;
            this.txt_observacion.Name = "txt_observacion";
            this.txt_observacion.Size = new System.Drawing.Size(243, 20);
            this.txt_observacion.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 14);
            this.label6.TabIndex = 26;
            this.label6.Text = "Observacion";
            // 
            // chk_st_gen
            // 
            this.chk_st_gen.AutoSize = true;
            this.chk_st_gen.Location = new System.Drawing.Point(110, 179);
            this.chk_st_gen.Name = "chk_st_gen";
            this.chk_st_gen.Size = new System.Drawing.Size(116, 18);
            this.chk_st_gen.TabIndex = 13;
            this.chk_st_gen.Text = "Status Generacion";
            this.chk_st_gen.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 14);
            this.label5.TabIndex = 22;
            this.label5.Text = "Tipo Operacion";
            // 
            // txt_tipo_plla
            // 
            this.txt_tipo_plla.BackColor = System.Drawing.Color.White;
            this.txt_tipo_plla.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_tipo_plla.Location = new System.Drawing.Point(110, 40);
            this.txt_tipo_plla.MaxLength = 2;
            this.txt_tipo_plla.Name = "txt_tipo_plla";
            this.txt_tipo_plla.Size = new System.Drawing.Size(62, 20);
            this.txt_tipo_plla.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 14);
            this.label4.TabIndex = 20;
            this.label4.Text = "Tipo Planilla";
            // 
            // txtdescc
            // 
            this.txtdescc.BackColor = System.Drawing.Color.White;
            this.txtdescc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtdescc.Location = new System.Drawing.Point(110, 109);
            this.txtdescc.MaxLength = 10;
            this.txtdescc.Name = "txtdescc";
            this.txtdescc.Size = new System.Drawing.Size(243, 20);
            this.txtdescc.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 14);
            this.label3.TabIndex = 5;
            this.label3.Text = "Desc. Corta";
            // 
            // txt_desc
            // 
            this.txt_desc.BackColor = System.Drawing.Color.White;
            this.txt_desc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_desc.Location = new System.Drawing.Point(110, 86);
            this.txt_desc.MaxLength = 40;
            this.txt_desc.Name = "txt_desc";
            this.txt_desc.Size = new System.Drawing.Size(243, 20);
            this.txt_desc.TabIndex = 7;
            // 
            // txt_cod
            // 
            this.txt_cod.BackColor = System.Drawing.Color.White;
            this.txt_cod.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_cod.Location = new System.Drawing.Point(110, 18);
            this.txt_cod.MaxLength = 2;
            this.txt_cod.Name = "txt_cod";
            this.txt_cod.Size = new System.Drawing.Size(30, 20);
            this.txt_cod.TabIndex = 1;
            // 
            // btn_guardar
            // 
            this.btn_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_guardar.Image = ((System.Drawing.Image)(resources.GetObject("btn_guardar.Image")));
            this.btn_guardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_guardar.Location = new System.Drawing.Point(194, 201);
            this.btn_guardar.Name = "btn_guardar";
            this.btn_guardar.Size = new System.Drawing.Size(77, 27);
            this.btn_guardar.TabIndex = 15;
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
            this.btn_modificar2.Location = new System.Drawing.Point(194, 201);
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
            this.btn_cancelar.Location = new System.Drawing.Point(275, 201);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(77, 27);
            this.btn_cancelar.TabIndex = 17;
            this.btn_cancelar.Text = "&Cancelar";
            this.btn_cancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_cancelar.UseVisualStyleBackColor = true;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(30, 89);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(64, 14);
            this.Label2.TabIndex = 1;
            this.Label2.Text = "Descripción";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(29, 21);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(40, 14);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Codigo";
            // 
            // TIPO_PLANILLA_CREACION
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 315);
            this.Controls.Add(this.TabControl1);
            this.Name = "TIPO_PLANILLA_CREACION";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento Tipos de Planillas";
            this.Load += new System.EventHandler(this.TIPO_PLANILLA_CREACION_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TIPO_PLANILLA_CREACION_KeyDown);
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
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.TextBox txtdescc;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox txt_desc;
        internal System.Windows.Forms.TextBox txt_cod;
        internal System.Windows.Forms.Button btn_guardar;
        internal System.Windows.Forms.Button btn_modificar2;
        internal System.Windows.Forms.Button btn_cancelar;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.TextBox txt_tipo_plla;
        internal System.Windows.Forms.TextBox txt_observacion;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.CheckBox chk_st_gen;
        internal System.Windows.Forms.ComboBox cbo_tipo_ope;
        internal System.Windows.Forms.ComboBox cbo_cod_venta;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.CheckBox chk_st_cta_cte;
        private System.Windows.Forms.DataGridViewTextBoxColumn CODIGO;
        private System.Windows.Forms.DataGridViewTextBoxColumn COD_TIPO_PLLA;
        private System.Windows.Forms.DataGridViewTextBoxColumn COD_TIPO_OPERACION;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESC_TIPO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESC_CORTA;
        private System.Windows.Forms.DataGridViewTextBoxColumn COD_VENTA;
        private System.Windows.Forms.DataGridViewTextBoxColumn OBSERVACION;
        private System.Windows.Forms.DataGridViewTextBoxColumn STATUS_GENERACION;
        private System.Windows.Forms.DataGridViewTextBoxColumn STATUS_CTACTE;
    }
}