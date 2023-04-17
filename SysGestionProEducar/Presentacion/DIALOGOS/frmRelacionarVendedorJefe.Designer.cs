namespace Presentacion.DIALOGOS
{
    partial class frmRelacionarVendedorJefe
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
            this.OK_Button = new System.Windows.Forms.Button();
            this.Cancel_Button = new System.Windows.Forms.Button();
            this.dgw = new System.Windows.Forms.DataGridView();
            this.cod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.op = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cbo_alm = new System.Windows.Forms.ComboBox();
            this.Label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgw)).BeginInit();
            this.SuspendLayout();
            // 
            // OK_Button
            // 
            this.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.OK_Button.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OK_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.OK_Button.Location = new System.Drawing.Point(440, 252);
            this.OK_Button.Name = "OK_Button";
            this.OK_Button.Size = new System.Drawing.Size(75, 29);
            this.OK_Button.TabIndex = 5;
            this.OK_Button.Text = "Aceptar";
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Cancel_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Cancel_Button.Location = new System.Drawing.Point(521, 252);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(75, 29);
            this.Cancel_Button.TabIndex = 6;
            this.Cancel_Button.Text = "Cancelar";
            // 
            // dgw
            // 
            this.dgw.AllowUserToAddRows = false;
            this.dgw.AllowUserToDeleteRows = false;
            this.dgw.AllowUserToOrderColumns = true;
            this.dgw.BackgroundColor = System.Drawing.Color.White;
            this.dgw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgw.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cod,
            this.nom,
            this.codn,
            this.desn,
            this.op});
            this.dgw.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgw.Location = new System.Drawing.Point(0, 0);
            this.dgw.MultiSelect = false;
            this.dgw.Name = "dgw";
            this.dgw.RowHeadersWidth = 25;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            this.dgw.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgw.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dgw.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.dgw.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgw.Size = new System.Drawing.Size(600, 244);
            this.dgw.TabIndex = 7;
            // 
            // cod
            // 
            this.cod.HeaderText = "Codigo";
            this.cod.Name = "cod";
            this.cod.ReadOnly = true;
            this.cod.Width = 55;
            // 
            // nom
            // 
            this.nom.HeaderText = "Nombre";
            this.nom.Name = "nom";
            this.nom.ReadOnly = true;
            this.nom.Width = 300;
            // 
            // codn
            // 
            this.codn.HeaderText = "codn";
            this.codn.Name = "codn";
            this.codn.ReadOnly = true;
            this.codn.Visible = false;
            // 
            // desn
            // 
            this.desn.HeaderText = "Nivel";
            this.desn.Name = "desn";
            this.desn.ReadOnly = true;
            this.desn.Width = 160;
            // 
            // op
            // 
            this.op.HeaderText = "Elije";
            this.op.Name = "op";
            this.op.Width = 35;
            // 
            // cbo_alm
            // 
            this.cbo_alm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_alm.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_alm.FormattingEnabled = true;
            this.cbo_alm.Items.AddRange(new object[] {
            "UND",
            "PAQUETE"});
            this.cbo_alm.Location = new System.Drawing.Point(109, 259);
            this.cbo_alm.Name = "cbo_alm";
            this.cbo_alm.Size = new System.Drawing.Size(289, 22);
            this.cbo_alm.TabIndex = 8;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(59, 262);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(49, 14);
            this.Label4.TabIndex = 9;
            this.Label4.Text = "Almacen";
            // 
            // frmRelacionarVendedorJefe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 292);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.cbo_alm);
            this.Controls.Add(this.OK_Button);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.dgw);
            this.Name = "frmRelacionarVendedorJefe";
            this.Text = "Listado";
            this.Load += new System.EventHandler(this.frmRelacionarVendedorJefe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgw)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button OK_Button;
        internal System.Windows.Forms.Button Cancel_Button;
        internal System.Windows.Forms.DataGridView dgw;
        internal System.Windows.Forms.ComboBox cbo_alm;
        internal System.Windows.Forms.Label Label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn cod;
        private System.Windows.Forms.DataGridViewTextBoxColumn nom;
        private System.Windows.Forms.DataGridViewTextBoxColumn codn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn op;
    }
}