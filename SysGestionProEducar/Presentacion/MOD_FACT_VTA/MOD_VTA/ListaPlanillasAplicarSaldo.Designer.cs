
namespace Presentacion.MOD_FACT_VTA.MOD_VTA
{
    partial class ListaPlanillasAplicarSaldo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListaPlanillasAplicarSaldo));
            this.dgvPlanillas = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnGuardar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnEliminar = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNroPlanillaOri = new System.Windows.Forms.TextBox();
            this.txtPeriodoOri = new System.Windows.Forms.TextBox();
            this.numSaldoActual = new System.Windows.Forms.NumericUpDown();
            this.numSaldoDisponible = new System.Windows.Forms.NumericUpDown();
            this.plDatosPagos = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanillas)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSaldoActual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSaldoDisponible)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPlanillas
            // 
            this.dgvPlanillas.AllowUserToAddRows = false;
            this.dgvPlanillas.AllowUserToDeleteRows = false;
            this.dgvPlanillas.BackgroundColor = System.Drawing.Color.White;
            this.dgvPlanillas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlanillas.Location = new System.Drawing.Point(518, 32);
            this.dgvPlanillas.Name = "dgvPlanillas";
            this.dgvPlanillas.Size = new System.Drawing.Size(616, 449);
            this.dgvPlanillas.TabIndex = 0;
            this.dgvPlanillas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvPlanillas_CellContentClick);
            this.dgvPlanillas.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvPlanillas_CellEndEdit);
            this.dgvPlanillas.CurrentCellDirtyStateChanged += new System.EventHandler(this.DgvPlanillas_CurrentCellDirtyStateChanged);
            this.dgvPlanillas.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.DgvPlanillas_DataError);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Honeydew;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnGuardar,
            this.toolStripSeparator1,
            this.btnEliminar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 487);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1136, 26);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnGuardar.BackColor = System.Drawing.Color.Teal;
            this.btnGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(68, 23);
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 26);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnEliminar.BackColor = System.Drawing.Color.Teal;
            this.btnEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(67, 23);
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(371, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "N° Plla Origen";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(551, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Periodo Origen";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(707, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Saldo Cheque";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(886, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Saldo Cheque Disponible";
            // 
            // txtNroPlanillaOri
            // 
            this.txtNroPlanillaOri.Location = new System.Drawing.Point(448, 6);
            this.txtNroPlanillaOri.Name = "txtNroPlanillaOri";
            this.txtNroPlanillaOri.Size = new System.Drawing.Size(100, 20);
            this.txtNroPlanillaOri.TabIndex = 6;
            this.txtNroPlanillaOri.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPeriodoOri
            // 
            this.txtPeriodoOri.Location = new System.Drawing.Point(634, 6);
            this.txtPeriodoOri.Name = "txtPeriodoOri";
            this.txtPeriodoOri.Size = new System.Drawing.Size(66, 20);
            this.txtPeriodoOri.TabIndex = 7;
            this.txtPeriodoOri.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // numSaldoActual
            // 
            this.numSaldoActual.DecimalPlaces = 2;
            this.numSaldoActual.Location = new System.Drawing.Point(787, 6);
            this.numSaldoActual.Name = "numSaldoActual";
            this.numSaldoActual.Size = new System.Drawing.Size(94, 20);
            this.numSaldoActual.TabIndex = 8;
            this.numSaldoActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numSaldoDisponible
            // 
            this.numSaldoDisponible.DecimalPlaces = 2;
            this.numSaldoDisponible.Location = new System.Drawing.Point(1013, 6);
            this.numSaldoDisponible.Name = "numSaldoDisponible";
            this.numSaldoDisponible.Size = new System.Drawing.Size(94, 20);
            this.numSaldoDisponible.TabIndex = 9;
            this.numSaldoDisponible.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // plDatosPagos
            // 
            this.plDatosPagos.Location = new System.Drawing.Point(0, 32);
            this.plDatosPagos.Name = "plDatosPagos";
            this.plDatosPagos.Size = new System.Drawing.Size(514, 449);
            this.plDatosPagos.TabIndex = 10;
            // 
            // ListaPlanillasAplicarSaldo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 513);
            this.Controls.Add(this.plDatosPagos);
            this.Controls.Add(this.dgvPlanillas);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.numSaldoDisponible);
            this.Controls.Add(this.numSaldoActual);
            this.Controls.Add(this.txtPeriodoOri);
            this.Controls.Add(this.txtNroPlanillaOri);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ListaPlanillasAplicarSaldo";
            this.Text = "LISTA DE PLANILLAS";
            this.Load += new System.EventHandler(this.ListaPlanillasAplicarSaldo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanillas)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSaldoActual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSaldoDisponible)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPlanillas;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnGuardar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNroPlanillaOri;
        private System.Windows.Forms.TextBox txtPeriodoOri;
        private System.Windows.Forms.NumericUpDown numSaldoActual;
        private System.Windows.Forms.NumericUpDown numSaldoDisponible;
        private System.Windows.Forms.Panel plDatosPagos;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnEliminar;
    }
}