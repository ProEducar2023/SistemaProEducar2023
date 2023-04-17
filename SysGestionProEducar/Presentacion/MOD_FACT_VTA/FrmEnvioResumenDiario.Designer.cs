namespace Presentacion.MOD_FACT_VTA
{
    partial class FrmEnvioResumenDiario
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.dpDia = new System.Windows.Forms.DateTimePicker();
            this.chkSelecionar = new System.Windows.Forms.CheckBox();
            this.Button1 = new System.Windows.Forms.Button();
            this.btnEnviarSunat = new System.Windows.Forms.Button();
            this.dgvPendingInvoice = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TabPage2 = new System.Windows.Forms.TabPage();
            this.dpDias2 = new System.Windows.Forms.DateTimePicker();
            this.chkSeleccionarAnuladas = new System.Windows.Forms.CheckBox();
            this.dgvVoided = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Button2 = new System.Windows.Forms.Button();
            this.btnEnviarBajas = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.TabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPendingInvoice)).BeginInit();
            this.TabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVoided)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.TabPage1);
            this.tabControl.Controls.Add(this.TabPage2);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1009, 489);
            this.tabControl.TabIndex = 46;
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.dpDia);
            this.TabPage1.Controls.Add(this.chkSelecionar);
            this.TabPage1.Controls.Add(this.Button1);
            this.TabPage1.Controls.Add(this.btnEnviarSunat);
            this.TabPage1.Controls.Add(this.dgvPendingInvoice);
            this.TabPage1.Location = new System.Drawing.Point(4, 22);
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage1.Size = new System.Drawing.Size(1001, 463);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "Documentos";
            this.TabPage1.UseVisualStyleBackColor = true;
            // 
            // dpDia
            // 
            this.dpDia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dpDia.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpDia.Location = new System.Drawing.Point(524, 429);
            this.dpDia.Name = "dpDia";
            this.dpDia.Size = new System.Drawing.Size(110, 20);
            this.dpDia.TabIndex = 56;
            // 
            // chkSelecionar
            // 
            this.chkSelecionar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSelecionar.AutoSize = true;
            this.chkSelecionar.Location = new System.Drawing.Point(640, 432);
            this.chkSelecionar.Name = "chkSelecionar";
            this.chkSelecionar.Size = new System.Drawing.Size(82, 17);
            this.chkSelecionar.TabIndex = 55;
            this.chkSelecionar.Text = "Seleccionar";
            this.chkSelecionar.UseVisualStyleBackColor = true;
            this.chkSelecionar.CheckedChanged += new System.EventHandler(this.chkSelecionar_CheckedChanged);
            // 
            // Button1
            // 
            this.Button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Button1.Location = new System.Drawing.Point(804, 419);
            this.Button1.Margin = new System.Windows.Forms.Padding(2);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(62, 36);
            this.Button1.TabIndex = 50;
            this.Button1.Text = "  Salir";
            this.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Button1.UseVisualStyleBackColor = true;
            // 
            // btnEnviarSunat
            // 
            this.btnEnviarSunat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnviarSunat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnviarSunat.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEnviarSunat.Location = new System.Drawing.Point(875, 419);
            this.btnEnviarSunat.Name = "btnEnviarSunat";
            this.btnEnviarSunat.Size = new System.Drawing.Size(116, 36);
            this.btnEnviarSunat.TabIndex = 47;
            this.btnEnviarSunat.Text = "   Enviar Sunat";
            this.btnEnviarSunat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEnviarSunat.UseVisualStyleBackColor = true;
            this.btnEnviarSunat.Click += new System.EventHandler(this.btnEnviarSunat_Click);
            // 
            // dgvPendingInvoice
            // 
            this.dgvPendingInvoice.AllowUserToAddRows = false;
            this.dgvPendingInvoice.AllowUserToDeleteRows = false;
            this.dgvPendingInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPendingInvoice.BackgroundColor = System.Drawing.Color.White;
            this.dgvPendingInvoice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column3,
            this.Column4,
            this.Column10,
            this.Column11,
            this.Column12,
            this.Column7,
            this.Column9,
            this.Column5,
            this.Column6,
            this.Column13,
            this.Column14,
            this.Column8});
            this.dgvPendingInvoice.Location = new System.Drawing.Point(6, 6);
            this.dgvPendingInvoice.Name = "dgvPendingInvoice";
            this.dgvPendingInvoice.ReadOnly = true;
            this.dgvPendingInvoice.RowHeadersWidth = 25;
            this.dgvPendingInvoice.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dgvPendingInvoice.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.dgvPendingInvoice.RowTemplate.Height = 24;
            this.dgvPendingInvoice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPendingInvoice.Size = new System.Drawing.Size(987, 406);
            this.dgvPendingInvoice.TabIndex = 42;
            this.dgvPendingInvoice.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPendingInvoice_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Id";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Cod. Suc.";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Visible = false;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Sucursal";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Cod. Clase";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Visible = false;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "Clase";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.Width = 150;
            // 
            // Column12
            // 
            this.Column12.HeaderText = "Doc.";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            this.Column12.Width = 30;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Nº Doc.";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 90;
            // 
            // Column9
            // 
            dataGridViewCellStyle4.Format = "d";
            this.Column9.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column9.HeaderText = "Fecha";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 70;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Cod.";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Visible = false;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Solicitante";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 200;
            // 
            // Column13
            // 
            this.Column13.HeaderText = "Nº Doc.";
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            this.Column13.Width = 90;
            // 
            // Column14
            // 
            this.Column14.HeaderText = "Ok";
            this.Column14.Name = "Column14";
            this.Column14.ReadOnly = true;
            this.Column14.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column14.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column14.Width = 30;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Observación";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 200;
            // 
            // TabPage2
            // 
            this.TabPage2.Controls.Add(this.dpDias2);
            this.TabPage2.Controls.Add(this.chkSeleccionarAnuladas);
            this.TabPage2.Controls.Add(this.dgvVoided);
            this.TabPage2.Controls.Add(this.Button2);
            this.TabPage2.Controls.Add(this.btnEnviarBajas);
            this.TabPage2.Location = new System.Drawing.Point(4, 22);
            this.TabPage2.Name = "TabPage2";
            this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage2.Size = new System.Drawing.Size(1001, 463);
            this.TabPage2.TabIndex = 1;
            this.TabPage2.Text = "Anuladas";
            this.TabPage2.UseVisualStyleBackColor = true;
            // 
            // dpDias2
            // 
            this.dpDias2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dpDias2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpDias2.Location = new System.Drawing.Point(581, 425);
            this.dpDias2.Name = "dpDias2";
            this.dpDias2.Size = new System.Drawing.Size(110, 20);
            this.dpDias2.TabIndex = 58;
            // 
            // chkSeleccionarAnuladas
            // 
            this.chkSeleccionarAnuladas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSeleccionarAnuladas.AutoSize = true;
            this.chkSeleccionarAnuladas.Location = new System.Drawing.Point(697, 428);
            this.chkSeleccionarAnuladas.Name = "chkSeleccionarAnuladas";
            this.chkSeleccionarAnuladas.Size = new System.Drawing.Size(82, 17);
            this.chkSeleccionarAnuladas.TabIndex = 57;
            this.chkSeleccionarAnuladas.Text = "Seleccionar";
            this.chkSeleccionarAnuladas.UseVisualStyleBackColor = true;
            this.chkSeleccionarAnuladas.CheckedChanged += new System.EventHandler(this.chkSeleccionarAnuladas_CheckedChanged);
            // 
            // dgvVoided
            // 
            this.dgvVoided.AllowUserToAddRows = false;
            this.dgvVoided.AllowUserToDeleteRows = false;
            this.dgvVoided.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvVoided.BackgroundColor = System.Drawing.Color.White;
            this.dgvVoided.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewCheckBoxColumn1,
            this.dataGridViewTextBoxColumn12});
            this.dgvVoided.Location = new System.Drawing.Point(3, 3);
            this.dgvVoided.Name = "dgvVoided";
            this.dgvVoided.ReadOnly = true;
            this.dgvVoided.RowHeadersWidth = 25;
            this.dgvVoided.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dgvVoided.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.dgvVoided.RowTemplate.Height = 24;
            this.dgvVoided.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVoided.Size = new System.Drawing.Size(990, 406);
            this.dgvVoided.TabIndex = 54;
            this.dgvVoided.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVoided_CellContentClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Cod. Suc.";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Sucursal";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Cod. Clase";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Clase";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 150;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Doc.";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 30;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Nº Doc.";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 90;
            // 
            // dataGridViewTextBoxColumn8
            // 
            dataGridViewCellStyle3.Format = "d";
            this.dataGridViewTextBoxColumn8.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn8.HeaderText = "Fecha";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 70;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "Cod.";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Visible = false;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "Solicitante";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Width = 200;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.HeaderText = "Nº Doc.";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Width = 90;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.HeaderText = "Ok";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.ReadOnly = true;
            this.dataGridViewCheckBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCheckBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewCheckBoxColumn1.Width = 30;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.HeaderText = "Observación";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.Width = 200;
            // 
            // Button2
            // 
            this.Button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Button2.Location = new System.Drawing.Point(801, 419);
            this.Button2.Margin = new System.Windows.Forms.Padding(2);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(62, 36);
            this.Button2.TabIndex = 53;
            this.Button2.Text = "  Salir";
            this.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Button2.UseVisualStyleBackColor = true;
            // 
            // btnEnviarBajas
            // 
            this.btnEnviarBajas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnviarBajas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnviarBajas.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEnviarBajas.Location = new System.Drawing.Point(874, 419);
            this.btnEnviarBajas.Name = "btnEnviarBajas";
            this.btnEnviarBajas.Size = new System.Drawing.Size(116, 36);
            this.btnEnviarBajas.TabIndex = 52;
            this.btnEnviarBajas.Text = "   Enviar Sunat";
            this.btnEnviarBajas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEnviarBajas.UseVisualStyleBackColor = true;
            this.btnEnviarBajas.Click += new System.EventHandler(this.btnEnviarBajas_Click);
            // 
            // FrmEnvioResumenDiario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 489);
            this.Controls.Add(this.tabControl);
            this.Name = "FrmEnvioResumenDiario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Envio Resumen Diario Boletas";
            this.tabControl.ResumeLayout(false);
            this.TabPage1.ResumeLayout(false);
            this.TabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPendingInvoice)).EndInit();
            this.TabPage2.ResumeLayout(false);
            this.TabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVoided)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TabControl tabControl;
        internal System.Windows.Forms.TabPage TabPage1;
        internal System.Windows.Forms.DateTimePicker dpDia;
        internal System.Windows.Forms.CheckBox chkSelecionar;
        internal System.Windows.Forms.Button Button1;
        internal System.Windows.Forms.Button btnEnviarSunat;
        internal System.Windows.Forms.DataGridView dgvPendingInvoice;
        internal System.Windows.Forms.TabPage TabPage2;
        internal System.Windows.Forms.Button Button2;
        internal System.Windows.Forms.Button btnEnviarBajas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        internal System.Windows.Forms.DataGridView dgvVoided;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        internal System.Windows.Forms.DateTimePicker dpDias2;
        internal System.Windows.Forms.CheckBox chkSeleccionarAnuladas;
    }
}