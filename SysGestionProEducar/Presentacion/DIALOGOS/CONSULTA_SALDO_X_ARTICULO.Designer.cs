namespace Presentacion.DIALOGOS
{
    partial class CONSULTA_SALDO_X_ARTICULO
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CONSULTA_SALDO_X_ARTICULO));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.CBO_CLASE = new System.Windows.Forms.ComboBox();
            this.TXT_UM = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.dgw1 = new System.Windows.Forms.DataGridView();
            this.TXT_ART = new System.Windows.Forms.TextBox();
            this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.OK_Button = new System.Windows.Forms.Button();
            this.Cancel_Button = new System.Windows.Forms.Button();
            this.Label3 = new System.Windows.Forms.Label();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgw1)).BeginInit();
            this.TableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CBO_CLASE
            // 
            this.CBO_CLASE.BackColor = System.Drawing.Color.White;
            this.CBO_CLASE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBO_CLASE.FormattingEnabled = true;
            this.CBO_CLASE.Location = new System.Drawing.Point(69, 2);
            this.CBO_CLASE.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.CBO_CLASE.Name = "CBO_CLASE";
            this.CBO_CLASE.Size = new System.Drawing.Size(291, 21);
            this.CBO_CLASE.TabIndex = 33;
            this.CBO_CLASE.SelectedIndexChanged += new System.EventHandler(this.CBO_CLASE_SelectedIndexChanged);
            // 
            // TXT_UM
            // 
            this.TXT_UM.BackColor = System.Drawing.Color.White;
            this.TXT_UM.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXT_UM.Location = new System.Drawing.Point(401, 2);
            this.TXT_UM.Name = "TXT_UM";
            this.TXT_UM.ReadOnly = true;
            this.TXT_UM.Size = new System.Drawing.Size(39, 20);
            this.TXT_UM.TabIndex = 30;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(365, 5);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(30, 14);
            this.Label1.TabIndex = 29;
            this.Label1.Text = "U.M.";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.Location = new System.Drawing.Point(11, 5);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(41, 14);
            this.Label5.TabIndex = 28;
            this.Label5.Text = "Clase:";
            // 
            // dgw1
            // 
            this.dgw1.AllowUserToAddRows = false;
            this.dgw1.AllowUserToDeleteRows = false;
            this.dgw1.BackgroundColor = System.Drawing.Color.White;
            this.dgw1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column4,
            this.Column7});
            this.dgw1.Location = new System.Drawing.Point(6, 50);
            this.dgw1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dgw1.MultiSelect = false;
            this.dgw1.Name = "dgw1";
            this.dgw1.ReadOnly = true;
            this.dgw1.RowHeadersWidth = 25;
            this.dgw1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dgw1.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.dgw1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgw1.Size = new System.Drawing.Size(435, 124);
            this.dgw1.TabIndex = 27;
            // 
            // TXT_ART
            // 
            this.TXT_ART.BackColor = System.Drawing.Color.White;
            this.TXT_ART.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXT_ART.Location = new System.Drawing.Point(68, 27);
            this.TXT_ART.Name = "TXT_ART";
            this.TXT_ART.ReadOnly = true;
            this.TXT_ART.Size = new System.Drawing.Size(373, 20);
            this.TXT_ART.TabIndex = 26;
            // 
            // TableLayoutPanel1
            // 
            this.TableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TableLayoutPanel1.ColumnCount = 2;
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel1.Controls.Add(this.OK_Button, 0, 0);
            this.TableLayoutPanel1.Controls.Add(this.Cancel_Button, 1, 0);
            this.TableLayoutPanel1.Location = new System.Drawing.Point(273, 201);
            this.TableLayoutPanel1.Name = "TableLayoutPanel1";
            this.TableLayoutPanel1.RowCount = 1;
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel1.Size = new System.Drawing.Size(162, 31);
            this.TableLayoutPanel1.TabIndex = 24;
            // 
            // OK_Button
            // 
            this.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.OK_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OK_Button.Image = ((System.Drawing.Image)(resources.GetObject("OK_Button.Image")));
            this.OK_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.OK_Button.Location = new System.Drawing.Point(3, 3);
            this.OK_Button.Name = "OK_Button";
            this.OK_Button.Size = new System.Drawing.Size(75, 25);
            this.OK_Button.TabIndex = 0;
            this.OK_Button.Text = "Aceptar";
            this.OK_Button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.OK_Button.Click += new System.EventHandler(this.OK_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Cancel_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Cancel_Button.Image = ((System.Drawing.Image)(resources.GetObject("Cancel_Button.Image")));
            this.Cancel_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Cancel_Button.Location = new System.Drawing.Point(84, 3);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(75, 25);
            this.Cancel_Button.TabIndex = 1;
            this.Cancel_Button.Text = "Cancelar";
            this.Cancel_Button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(12, 27);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(50, 14);
            this.Label3.TabIndex = 25;
            this.Label3.Text = "Articulo";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "cod_almacen";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Visible = false;
            // 
            // Column4
            // 
            this.Column4.FillWeight = 125.33F;
            this.Column4.HeaderText = "Almacen";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 280;
            // 
            // Column7
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            this.Column7.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column7.FillWeight = 68.07103F;
            this.Column7.HeaderText = "Saldo";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 90;
            // 
            // CONSULTA_SALDO_X_ARTICULO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 253);
            this.ControlBox = false;
            this.Controls.Add(this.CBO_CLASE);
            this.Controls.Add(this.TXT_UM);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.dgw1);
            this.Controls.Add(this.TXT_ART);
            this.Controls.Add(this.TableLayoutPanel1);
            this.Controls.Add(this.Label3);
            this.Name = "CONSULTA_SALDO_X_ARTICULO";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta de Saldos por Artículo";
            this.Load += new System.EventHandler(this.CONSULTA_SALDO_X_ARTICULO_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgw1)).EndInit();
            this.TableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ComboBox CBO_CLASE;
        internal System.Windows.Forms.TextBox TXT_UM;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.DataGridView dgw1;
        internal System.Windows.Forms.TextBox TXT_ART;
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
        internal System.Windows.Forms.Button OK_Button;
        internal System.Windows.Forms.Button Cancel_Button;
        internal System.Windows.Forms.Label Label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
    }
}