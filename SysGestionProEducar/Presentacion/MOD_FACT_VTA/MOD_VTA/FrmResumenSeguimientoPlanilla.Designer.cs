
namespace Presentacion.MOD_FACT_VTA.MOD_VTA
{
    partial class FrmResumenSeguimientoPlanilla
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
            this.dgvResumenSeguiPlla = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numAño = new System.Windows.Forms.NumericUpDown();
            this.cboMes = new System.Windows.Forms.ComboBox();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnRptResumCheque = new System.Windows.Forms.Button();
            this.dgvResumenSeguiCheque = new System.Windows.Forms.DataGridView();
            this.numAño2 = new System.Windows.Forms.NumericUpDown();
            this.cboMes2 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResumenSeguiPlla)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAño)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResumenSeguiCheque)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAño2)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvResumenSeguiPlla
            // 
            this.dgvResumenSeguiPlla.AllowUserToAddRows = false;
            this.dgvResumenSeguiPlla.AllowUserToDeleteRows = false;
            this.dgvResumenSeguiPlla.BackgroundColor = System.Drawing.Color.White;
            this.dgvResumenSeguiPlla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResumenSeguiPlla.Location = new System.Drawing.Point(6, 52);
            this.dgvResumenSeguiPlla.Name = "dgvResumenSeguiPlla";
            this.dgvResumenSeguiPlla.ReadOnly = true;
            this.dgvResumenSeguiPlla.Size = new System.Drawing.Size(1290, 475);
            this.dgvResumenSeguiPlla.TabIndex = 0;
            this.dgvResumenSeguiPlla.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvResumen_CellDoubleClick);
            this.dgvResumenSeguiPlla.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.DgvResumen_RowPostPaint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Año";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(213, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mes";
            // 
            // numAño
            // 
            this.numAño.Location = new System.Drawing.Point(50, 26);
            this.numAño.Name = "numAño";
            this.numAño.Size = new System.Drawing.Size(103, 20);
            this.numAño.TabIndex = 3;
            this.numAño.ValueChanged += new System.EventHandler(this.NumAño_ValueChanged);
            // 
            // cboMes
            // 
            this.cboMes.FormattingEnabled = true;
            this.cboMes.Location = new System.Drawing.Point(246, 25);
            this.cboMes.Name = "cboMes";
            this.cboMes.Size = new System.Drawing.Size(154, 21);
            this.cboMes.TabIndex = 4;
            this.cboMes.SelectionChangeCommitted += new System.EventHandler(this.CboMes_SelectionChangeCommitted);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Location = new System.Drawing.Point(1159, 13);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(127, 28);
            this.btnImprimir.TabIndex = 5;
            this.btnImprimir.Text = "Reporte";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.BtnImprimir_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1310, 559);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvResumenSeguiPlla);
            this.tabPage1.Controls.Add(this.btnImprimir);
            this.tabPage1.Controls.Add(this.numAño);
            this.tabPage1.Controls.Add(this.cboMes);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1302, 533);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Resumen Seguimiento Planillas";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnRptResumCheque);
            this.tabPage2.Controls.Add(this.dgvResumenSeguiCheque);
            this.tabPage2.Controls.Add(this.numAño2);
            this.tabPage2.Controls.Add(this.cboMes2);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1302, 533);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Resumen Seguimiento Cheques";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnRptResumCheque
            // 
            this.btnRptResumCheque.Location = new System.Drawing.Point(1159, 13);
            this.btnRptResumCheque.Name = "btnRptResumCheque";
            this.btnRptResumCheque.Size = new System.Drawing.Size(127, 28);
            this.btnRptResumCheque.TabIndex = 10;
            this.btnRptResumCheque.Text = "Reporte";
            this.btnRptResumCheque.UseVisualStyleBackColor = true;
            this.btnRptResumCheque.Click += new System.EventHandler(this.BtnRptResumCheque_Click);
            // 
            // dgvResumenSeguiCheque
            // 
            this.dgvResumenSeguiCheque.AllowUserToAddRows = false;
            this.dgvResumenSeguiCheque.AllowUserToDeleteRows = false;
            this.dgvResumenSeguiCheque.BackgroundColor = System.Drawing.Color.White;
            this.dgvResumenSeguiCheque.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResumenSeguiCheque.Location = new System.Drawing.Point(6, 52);
            this.dgvResumenSeguiCheque.Name = "dgvResumenSeguiCheque";
            this.dgvResumenSeguiCheque.ReadOnly = true;
            this.dgvResumenSeguiCheque.Size = new System.Drawing.Size(1290, 475);
            this.dgvResumenSeguiCheque.TabIndex = 9;
            this.dgvResumenSeguiCheque.SelectionChanged += new System.EventHandler(this.DgvResumenSeguiCheque_SelectionChanged);
            // 
            // numAño2
            // 
            this.numAño2.Location = new System.Drawing.Point(50, 26);
            this.numAño2.Name = "numAño2";
            this.numAño2.Size = new System.Drawing.Size(103, 20);
            this.numAño2.TabIndex = 7;
            this.numAño2.ValueChanged += new System.EventHandler(this.NumAño2_ValueChanged);
            // 
            // cboMes2
            // 
            this.cboMes2.FormattingEnabled = true;
            this.cboMes2.Location = new System.Drawing.Point(246, 25);
            this.cboMes2.Name = "cboMes2";
            this.cboMes2.Size = new System.Drawing.Size(154, 21);
            this.cboMes2.TabIndex = 8;
            this.cboMes2.SelectionChangeCommitted += new System.EventHandler(this.CboMes2_SelectionChangeCommitted);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Año";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(213, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Mes";
            // 
            // FrmResumenSeguimientoPlanilla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1334, 583);
            this.Controls.Add(this.tabControl1);
            this.Name = "FrmResumenSeguimientoPlanilla";
            this.Text = "Resumen Seguimiento";
            this.Load += new System.EventHandler(this.FrmResumenSeguimientoPlanilla_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResumenSeguiPlla)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAño)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResumenSeguiCheque)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAño2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvResumenSeguiPlla;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numAño;
        private System.Windows.Forms.ComboBox cboMes;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnRptResumCheque;
        private System.Windows.Forms.DataGridView dgvResumenSeguiCheque;
        private System.Windows.Forms.NumericUpDown numAño2;
        private System.Windows.Forms.ComboBox cboMes2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}