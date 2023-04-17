
namespace Presentacion.MOD_FACT_VTA.MOD_VTA
{
    partial class FrmInsertarImporteListado
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
            this.dgvPlanillas = new System.Windows.Forms.DataGridView();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.lblTotalNeto = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.lblTotalCasMan = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.lblTotalCasAuto = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.lblTotalEjecutado = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.lblTotalListado = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.lblTotalEnviado = new System.Windows.Forms.ToolStripLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanillas)).BeginInit();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvPlanillas
            // 
            this.dgvPlanillas.AllowUserToAddRows = false;
            this.dgvPlanillas.AllowUserToDeleteRows = false;
            this.dgvPlanillas.BackgroundColor = System.Drawing.Color.White;
            this.dgvPlanillas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlanillas.Location = new System.Drawing.Point(3, 3);
            this.dgvPlanillas.Name = "dgvPlanillas";
            this.dgvPlanillas.Size = new System.Drawing.Size(1129, 272);
            this.dgvPlanillas.TabIndex = 0;
            this.dgvPlanillas.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.DgvPlanillas_CellBeginEdit);
            this.dgvPlanillas.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvPlanillas_CellEndEdit);
            this.dgvPlanillas.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DgvPlanillas_CellFormatting);
            this.dgvPlanillas.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvPlanillas_CellValueChanged);
            this.dgvPlanillas.CurrentCellDirtyStateChanged += new System.EventHandler(this.DgvPlanillas_CurrentCellDirtyStateChanged);
            this.dgvPlanillas.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DgvPlanillas_EditingControlShowing);
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.Teal;
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.ForeColor = System.Drawing.Color.White;
            this.btnAceptar.Location = new System.Drawing.Point(891, 309);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 1;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Teal;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(1030, 309);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Controls.Add(this.dgvPlanillas);
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1135, 303);
            this.panel1.TabIndex = 3;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.LightGray;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblTotalNeto,
            this.toolStripSeparator5,
            this.lblTotalCasMan,
            this.toolStripSeparator4,
            this.lblTotalCasAuto,
            this.toolStripSeparator3,
            this.lblTotalEjecutado,
            this.toolStripSeparator1,
            this.lblTotalListado,
            this.toolStripSeparator2,
            this.lblTotalEnviado});
            this.toolStrip1.Location = new System.Drawing.Point(0, 278);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1135, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // lblTotalNeto
            // 
            this.lblTotalNeto.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblTotalNeto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalNeto.Name = "lblTotalNeto";
            this.lblTotalNeto.Size = new System.Drawing.Size(81, 22);
            this.lblTotalNeto.Tag = "Total Neto : ";
            this.lblTotalNeto.Text = "Total Neto : 0";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // lblTotalCasMan
            // 
            this.lblTotalCasMan.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblTotalCasMan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalCasMan.Name = "lblTotalCasMan";
            this.lblTotalCasMan.Size = new System.Drawing.Size(101, 22);
            this.lblTotalCasMan.Tag = "Total Cas. Man : ";
            this.lblTotalCasMan.Text = "Total Cas. Man : 0";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // lblTotalCasAuto
            // 
            this.lblTotalCasAuto.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblTotalCasAuto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalCasAuto.Name = "lblTotalCasAuto";
            this.lblTotalCasAuto.Size = new System.Drawing.Size(104, 22);
            this.lblTotalCasAuto.Tag = "Total Cas. Auto : ";
            this.lblTotalCasAuto.Text = "Total Cas. Auto : 0";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // lblTotalEjecutado
            // 
            this.lblTotalEjecutado.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblTotalEjecutado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalEjecutado.Name = "lblTotalEjecutado";
            this.lblTotalEjecutado.Size = new System.Drawing.Size(107, 22);
            this.lblTotalEjecutado.Tag = "Total Ejecutado : ";
            this.lblTotalEjecutado.Text = "Total Ejecutado : 0";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // lblTotalListado
            // 
            this.lblTotalListado.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblTotalListado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalListado.Name = "lblTotalListado";
            this.lblTotalListado.Size = new System.Drawing.Size(92, 22);
            this.lblTotalListado.Tag = "Total Listado : ";
            this.lblTotalListado.Text = "Total Listado : 0";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // lblTotalEnviado
            // 
            this.lblTotalEnviado.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblTotalEnviado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalEnviado.Name = "lblTotalEnviado";
            this.lblTotalEnviado.Size = new System.Drawing.Size(96, 22);
            this.lblTotalEnviado.Tag = "Total Enviado : ";
            this.lblTotalEnviado.Text = "Total Enviado : 0";
            // 
            // FrmInsertarImporteListado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 339);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmInsertarImporteListado";
            this.Text = "Importe Listado";
            this.Load += new System.EventHandler(this.FrmInsertarImporteListado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanillas)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPlanillas;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel lblTotalListado;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel lblTotalEjecutado;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel lblTotalEnviado;
        private System.Windows.Forms.ToolStripLabel lblTotalNeto;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripLabel lblTotalCasMan;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripLabel lblTotalCasAuto;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}