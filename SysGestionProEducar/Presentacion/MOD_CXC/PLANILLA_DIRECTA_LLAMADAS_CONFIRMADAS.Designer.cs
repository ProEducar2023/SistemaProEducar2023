namespace Presentacion.MOD_CXC
{
    partial class PLANILLA_DIRECTA_LLAMADAS_CONFIRMADAS
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PLANILLA_DIRECTA_LLAMADAS_CONFIRMADAS));
            this.DGW_DETALLE = new System.Windows.Forms.DataGridView();
            this.nrocontrato = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codpersona = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coddoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nrodoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechacontrato = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechallamada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.letra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_venc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.respuesta = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.fechaconfirmada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tip_pla_co = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.observaciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_aceptar = new System.Windows.Forms.Button();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.btn_Rehacer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGW_DETALLE)).BeginInit();
            this.SuspendLayout();
            // 
            // DGW_DETALLE
            // 
            this.DGW_DETALLE.AllowUserToAddRows = false;
            this.DGW_DETALLE.AllowUserToDeleteRows = false;
            this.DGW_DETALLE.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGW_DETALLE.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGW_DETALLE.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGW_DETALLE.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nrocontrato,
            this.codpersona,
            this.coddoc,
            this.nrodoc,
            this.fechacontrato,
            this.fechallamada,
            this.importe,
            this.letra,
            this.fecha_venc,
            this.respuesta,
            this.fechaconfirmada,
            this.tip_pla_co,
            this.observaciones});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 8.25F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGW_DETALLE.DefaultCellStyle = dataGridViewCellStyle4;
            this.DGW_DETALLE.Location = new System.Drawing.Point(13, 21);
            this.DGW_DETALLE.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.DGW_DETALLE.MultiSelect = false;
            this.DGW_DETALLE.Name = "DGW_DETALLE";
            this.DGW_DETALLE.RowHeadersWidth = 25;
            this.DGW_DETALLE.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.DGW_DETALLE.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.DGW_DETALLE.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGW_DETALLE.Size = new System.Drawing.Size(783, 203);
            this.DGW_DETALLE.TabIndex = 31;
            this.DGW_DETALLE.TabStop = false;
            this.DGW_DETALLE.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGW_DETALLE_CellClick);
            this.DGW_DETALLE.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.DGW_DETALLE_ColumnWidthChanged);
            this.DGW_DETALLE.Scroll += new System.Windows.Forms.ScrollEventHandler(this.DGW_DETALLE_Scroll);
            // 
            // nrocontrato
            // 
            this.nrocontrato.HeaderText = "nrocontrato";
            this.nrocontrato.Name = "nrocontrato";
            this.nrocontrato.Visible = false;
            // 
            // codpersona
            // 
            this.codpersona.HeaderText = "codpersona";
            this.codpersona.Name = "codpersona";
            this.codpersona.Visible = false;
            // 
            // coddoc
            // 
            this.coddoc.HeaderText = "coddoc";
            this.coddoc.Name = "coddoc";
            this.coddoc.Visible = false;
            // 
            // nrodoc
            // 
            this.nrodoc.HeaderText = "nrodoc";
            this.nrodoc.Name = "nrodoc";
            this.nrodoc.Visible = false;
            // 
            // fechacontrato
            // 
            this.fechacontrato.HeaderText = "fechacontrato";
            this.fechacontrato.Name = "fechacontrato";
            this.fechacontrato.Visible = false;
            // 
            // fechallamada
            // 
            this.fechallamada.HeaderText = "fechallamada";
            this.fechallamada.Name = "fechallamada";
            this.fechallamada.Visible = false;
            // 
            // importe
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.importe.DefaultCellStyle = dataGridViewCellStyle2;
            this.importe.HeaderText = "IMPORTE";
            this.importe.Name = "importe";
            this.importe.ReadOnly = true;
            this.importe.Width = 65;
            // 
            // letra
            // 
            this.letra.HeaderText = "LETRA";
            this.letra.Name = "letra";
            this.letra.ReadOnly = true;
            this.letra.Width = 60;
            // 
            // fecha_venc
            // 
            this.fecha_venc.HeaderText = "FE_VEN";
            this.fecha_venc.Name = "fecha_venc";
            this.fecha_venc.Width = 80;
            // 
            // respuesta
            // 
            this.respuesta.HeaderText = "RESPUESTA";
            this.respuesta.Name = "respuesta";
            this.respuesta.Width = 160;
            // 
            // fechaconfirmada
            // 
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.fechaconfirmada.DefaultCellStyle = dataGridViewCellStyle3;
            this.fechaconfirmada.HeaderText = "FECHA";
            this.fechaconfirmada.Name = "fechaconfirmada";
            this.fechaconfirmada.Width = 80;
            // 
            // tip_pla_co
            // 
            this.tip_pla_co.HeaderText = "T";
            this.tip_pla_co.Name = "tip_pla_co";
            this.tip_pla_co.Width = 30;
            // 
            // observaciones
            // 
            this.observaciones.HeaderText = "OBSERVACIONES";
            this.observaciones.Name = "observaciones";
            this.observaciones.Width = 260;
            // 
            // btn_aceptar
            // 
            this.btn_aceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_aceptar.Image = ((System.Drawing.Image)(resources.GetObject("btn_aceptar.Image")));
            this.btn_aceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_aceptar.Location = new System.Drawing.Point(499, 235);
            this.btn_aceptar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_aceptar.Name = "btn_aceptar";
            this.btn_aceptar.Size = new System.Drawing.Size(77, 27);
            this.btn_aceptar.TabIndex = 32;
            this.btn_aceptar.Text = "&Aceptar";
            this.btn_aceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_aceptar.UseVisualStyleBackColor = true;
            this.btn_aceptar.Click += new System.EventHandler(this.btn_aceptar_Click);
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancelar.Image = ((System.Drawing.Image)(resources.GetObject("btn_cancelar.Image")));
            this.btn_cancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_cancelar.Location = new System.Drawing.Point(580, 235);
            this.btn_cancelar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(77, 27);
            this.btn_cancelar.TabIndex = 33;
            this.btn_cancelar.Text = "&Cancelar";
            this.btn_cancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_cancelar.UseVisualStyleBackColor = true;
            // 
            // btn_Rehacer
            // 
            this.btn_Rehacer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Rehacer.Image = ((System.Drawing.Image)(resources.GetObject("btn_Rehacer.Image")));
            this.btn_Rehacer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Rehacer.Location = new System.Drawing.Point(418, 235);
            this.btn_Rehacer.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_Rehacer.Name = "btn_Rehacer";
            this.btn_Rehacer.Size = new System.Drawing.Size(77, 27);
            this.btn_Rehacer.TabIndex = 34;
            this.btn_Rehacer.Text = "&Rehacer";
            this.btn_Rehacer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Rehacer.UseVisualStyleBackColor = true;
            this.btn_Rehacer.Click += new System.EventHandler(this.btn_Rehacer_Click);
            // 
            // PLANILLA_DIRECTA_LLAMADAS_CONFIRMADAS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 273);
            this.Controls.Add(this.btn_Rehacer);
            this.Controls.Add(this.btn_aceptar);
            this.Controls.Add(this.btn_cancelar);
            this.Controls.Add(this.DGW_DETALLE);
            this.Location = new System.Drawing.Point(740, 200);
            this.Name = "PLANILLA_DIRECTA_LLAMADAS_CONFIRMADAS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LLAMADAS PARA CONFIRMAR";
            this.Load += new System.EventHandler(this.PLANILLA_DIRECTA_LLAMADAS_CONFIRMADAS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGW_DETALLE)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.DataGridView DGW_DETALLE;
        internal System.Windows.Forms.Button btn_aceptar;
        internal System.Windows.Forms.Button btn_cancelar;
        internal System.Windows.Forms.Button btn_Rehacer;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrocontrato;
        private System.Windows.Forms.DataGridViewTextBoxColumn codpersona;
        private System.Windows.Forms.DataGridViewTextBoxColumn coddoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrodoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechacontrato;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechallamada;
        private System.Windows.Forms.DataGridViewTextBoxColumn importe;
        private System.Windows.Forms.DataGridViewTextBoxColumn letra;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_venc;
        private System.Windows.Forms.DataGridViewComboBoxColumn respuesta;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaconfirmada;
        private System.Windows.Forms.DataGridViewTextBoxColumn tip_pla_co;
        private System.Windows.Forms.DataGridViewTextBoxColumn observaciones;
    }
}