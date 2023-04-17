namespace Presentacion.MOD_ADM
{
    partial class frmSerieDocumentos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSerieDocumentos));
            this.StatusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tslMensaje = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.dgvSeriesDocumento = new System.Windows.Forms.DataGridView();
            this.codsuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.suc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coddoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.doc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sunat = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ok = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Cancel_Button = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeriesDocumento)).BeginInit();
            this.SuspendLayout();
            // 
            // StatusStrip1
            // 
            this.StatusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslMensaje,
            this.ToolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.StatusStrip1.Location = new System.Drawing.Point(0, 376);
            this.StatusStrip1.Name = "StatusStrip1";
            this.StatusStrip1.Size = new System.Drawing.Size(469, 22);
            this.StatusStrip1.TabIndex = 36;
            this.StatusStrip1.Text = "StatusStrip1";
            // 
            // tslMensaje
            // 
            this.tslMensaje.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tslMensaje.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.tslMensaje.Name = "tslMensaje";
            this.tslMensaje.Size = new System.Drawing.Size(345, 17);
            this.tslMensaje.Spring = true;
            this.tslMensaje.Text = "[Mensaje]";
            this.tslMensaje.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ToolStripStatusLabel1
            // 
            this.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1";
            this.ToolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // dgvSeriesDocumento
            // 
            this.dgvSeriesDocumento.AllowUserToAddRows = false;
            this.dgvSeriesDocumento.AllowUserToDeleteRows = false;
            this.dgvSeriesDocumento.AllowUserToResizeColumns = false;
            this.dgvSeriesDocumento.AllowUserToResizeRows = false;
            this.dgvSeriesDocumento.BackgroundColor = System.Drawing.Color.White;
            this.dgvSeriesDocumento.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codsuc,
            this.suc,
            this.coddoc,
            this.doc,
            this.sunat,
            this.ser,
            this.ok});
            this.dgvSeriesDocumento.Location = new System.Drawing.Point(11, 6);
            this.dgvSeriesDocumento.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dgvSeriesDocumento.MultiSelect = false;
            this.dgvSeriesDocumento.Name = "dgvSeriesDocumento";
            this.dgvSeriesDocumento.RowHeadersVisible = false;
            this.dgvSeriesDocumento.RowHeadersWidth = 25;
            this.dgvSeriesDocumento.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dgvSeriesDocumento.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.dgvSeriesDocumento.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSeriesDocumento.Size = new System.Drawing.Size(447, 328);
            this.dgvSeriesDocumento.TabIndex = 35;
            // 
            // codsuc
            // 
            this.codsuc.HeaderText = "codsuc";
            this.codsuc.Name = "codsuc";
            this.codsuc.ReadOnly = true;
            this.codsuc.Visible = false;
            // 
            // suc
            // 
            this.suc.HeaderText = "Sucursal";
            this.suc.Name = "suc";
            this.suc.ReadOnly = true;
            this.suc.Width = 170;
            // 
            // coddoc
            // 
            this.coddoc.HeaderText = "coddoc";
            this.coddoc.Name = "coddoc";
            this.coddoc.ReadOnly = true;
            this.coddoc.Visible = false;
            // 
            // doc
            // 
            this.doc.HeaderText = "Documento";
            this.doc.Name = "doc";
            this.doc.ReadOnly = true;
            this.doc.Width = 170;
            // 
            // sunat
            // 
            this.sunat.HeaderText = "sunat";
            this.sunat.Name = "sunat";
            this.sunat.ReadOnly = true;
            this.sunat.Visible = false;
            this.sunat.Width = 40;
            // 
            // ser
            // 
            this.ser.HeaderText = "Serie";
            this.ser.Name = "ser";
            this.ser.ReadOnly = true;
            this.ser.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ser.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ser.Width = 55;
            // 
            // ok
            // 
            this.ok.HeaderText = "Ok";
            this.ok.Name = "ok";
            this.ok.Width = 30;
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Cancel_Button.Image = ((System.Drawing.Image)(resources.GetObject("Cancel_Button.Image")));
            this.Cancel_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Cancel_Button.Location = new System.Drawing.Point(380, 340);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(77, 25);
            this.Cancel_Button.TabIndex = 34;
            this.Cancel_Button.Text = "Cancelar";
            this.Cancel_Button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.Location = new System.Drawing.Point(290, 340);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(84, 25);
            this.btnAceptar.TabIndex = 33;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(109, 17);
            this.toolStripStatusLabel2.Text = "toolStripStatusLabel2";
            // 
            // frmSerieDocumentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 398);
            this.Controls.Add(this.StatusStrip1);
            this.Controls.Add(this.dgvSeriesDocumento);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.btnAceptar);
            this.Name = "frmSerieDocumentos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Serie Documentos";
            this.Load += new System.EventHandler(this.frmSerieDocumentos_Load);
            this.StatusStrip1.ResumeLayout(false);
            this.StatusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeriesDocumento)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.StatusStrip StatusStrip1;
        internal System.Windows.Forms.ToolStripStatusLabel tslMensaje;
        internal System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel1;
        internal System.Windows.Forms.DataGridView dgvSeriesDocumento;
        internal System.Windows.Forms.Button Cancel_Button;
        internal System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.DataGridViewTextBoxColumn codsuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn suc;
        private System.Windows.Forms.DataGridViewTextBoxColumn coddoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn doc;
        private System.Windows.Forms.DataGridViewCheckBoxColumn sunat;
        private System.Windows.Forms.DataGridViewTextBoxColumn ser;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ok;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
    }
}