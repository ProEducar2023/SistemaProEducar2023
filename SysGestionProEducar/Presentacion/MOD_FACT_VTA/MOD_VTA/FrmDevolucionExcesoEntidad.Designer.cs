
namespace Presentacion.MOD_FACT_VTA.MOD_VTA
{
    partial class FrmDevolucionExcesoEntidad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDevolucionExcesoEntidad));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnGuardar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnEliminar = new System.Windows.Forms.ToolStripButton();
            this.plDatosPagos = new System.Windows.Forms.Panel();
            this.numSaldoDisponible = new System.Windows.Forms.NumericUpDown();
            this.numSaldoActual = new System.Windows.Forms.NumericUpDown();
            this.txtPeriodoOri = new System.Windows.Forms.TextBox();
            this.txtNroPlanillaOri = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numImporteDevolver = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvPlanillas = new System.Windows.Forms.DataGridView();
            this.txtObservacionDev = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.numTotalAnular = new System.Windows.Forms.NumericUpDown();
            this.numNuevoSaldo = new System.Windows.Forms.NumericUpDown();
            this.numSaldoFinalCheq = new System.Windows.Forms.NumericUpDown();
            this.lblmensaje = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSaldoDisponible)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSaldoActual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numImporteDevolver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanillas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTotalAnular)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNuevoSaldo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSaldoFinalCheq)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Honeydew;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnGuardar,
            this.toolStripSeparator1,
            this.btnEliminar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 334);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1078, 26);
            this.toolStrip1.TabIndex = 12;
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
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
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
            this.btnEliminar.Visible = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // plDatosPagos
            // 
            this.plDatosPagos.Location = new System.Drawing.Point(13, 10);
            this.plDatosPagos.Name = "plDatosPagos";
            this.plDatosPagos.Size = new System.Drawing.Size(514, 317);
            this.plDatosPagos.TabIndex = 21;
            // 
            // numSaldoDisponible
            // 
            this.numSaldoDisponible.DecimalPlaces = 2;
            this.numSaldoDisponible.Enabled = false;
            this.numSaldoDisponible.Location = new System.Drawing.Point(326, 99);
            this.numSaldoDisponible.Name = "numSaldoDisponible";
            this.numSaldoDisponible.Size = new System.Drawing.Size(137, 20);
            this.numSaldoDisponible.TabIndex = 20;
            this.numSaldoDisponible.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numSaldoActual
            // 
            this.numSaldoActual.DecimalPlaces = 2;
            this.numSaldoActual.Enabled = false;
            this.numSaldoActual.Location = new System.Drawing.Point(326, 73);
            this.numSaldoActual.Name = "numSaldoActual";
            this.numSaldoActual.Size = new System.Drawing.Size(137, 20);
            this.numSaldoActual.TabIndex = 19;
            this.numSaldoActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtPeriodoOri
            // 
            this.txtPeriodoOri.Location = new System.Drawing.Point(326, 46);
            this.txtPeriodoOri.Name = "txtPeriodoOri";
            this.txtPeriodoOri.Size = new System.Drawing.Size(137, 20);
            this.txtPeriodoOri.TabIndex = 18;
            this.txtPeriodoOri.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtNroPlanillaOri
            // 
            this.txtNroPlanillaOri.Location = new System.Drawing.Point(326, 19);
            this.txtNroPlanillaOri.Name = "txtNroPlanillaOri";
            this.txtNroPlanillaOri.Size = new System.Drawing.Size(137, 20);
            this.txtNroPlanillaOri.TabIndex = 17;
            this.txtNroPlanillaOri.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(231, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Importe Devolver";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(194, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Saldo Cheque Disponible";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(243, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Periodo Origen";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(249, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "N° Plla Origen";
            // 
            // numImporteDevolver
            // 
            this.numImporteDevolver.DecimalPlaces = 2;
            this.numImporteDevolver.Location = new System.Drawing.Point(927, 283);
            this.numImporteDevolver.Name = "numImporteDevolver";
            this.numImporteDevolver.Size = new System.Drawing.Size(137, 20);
            this.numImporteDevolver.TabIndex = 23;
            this.numImporteDevolver.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numImporteDevolver.ValueChanged += new System.EventHandler(this.numImporteDevolver_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(199, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Nuevo Saldo Disponible";
            // 
            // dgvPlanillas
            // 
            this.dgvPlanillas.AllowUserToAddRows = false;
            this.dgvPlanillas.AllowUserToDeleteRows = false;
            this.dgvPlanillas.BackgroundColor = System.Drawing.Color.White;
            this.dgvPlanillas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlanillas.Location = new System.Drawing.Point(479, 35);
            this.dgvPlanillas.Name = "dgvPlanillas";
            this.dgvPlanillas.Size = new System.Drawing.Size(585, 192);
            this.dgvPlanillas.TabIndex = 24;
            this.dgvPlanillas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPlanillas_CellContentClick);
            this.dgvPlanillas.CurrentCellDirtyStateChanged += new System.EventHandler(this.DgvPlanillas_CurrentCellDirtyStateChanged);
            // 
            // txtObservacionDev
            // 
            this.txtObservacionDev.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObservacionDev.Location = new System.Drawing.Point(480, 246);
            this.txtObservacionDev.Multiline = true;
            this.txtObservacionDev.Name = "txtObservacionDev";
            this.txtObservacionDev.Size = new System.Drawing.Size(308, 81);
            this.txtObservacionDev.TabIndex = 27;
            this.txtObservacionDev.WordWrap = false;
            this.txtObservacionDev.TextChanged += new System.EventHandler(this.txtObservacionDev_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(477, 230);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 13);
            this.label7.TabIndex = 28;
            this.label7.Text = "Observación : ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(813, 239);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "Total Anular : ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(813, 261);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 13);
            this.label8.TabIndex = 30;
            this.label8.Text = "Nuevo Saldo : ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(813, 285);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 13);
            this.label9.TabIndex = 31;
            this.label9.Text = "Imp. a devolver : ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(813, 308);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(93, 13);
            this.label10.TabIndex = 32;
            this.label10.Text = "Saldo Final Cheq: ";
            // 
            // numTotalAnular
            // 
            this.numTotalAnular.DecimalPlaces = 2;
            this.numTotalAnular.Location = new System.Drawing.Point(927, 239);
            this.numTotalAnular.Name = "numTotalAnular";
            this.numTotalAnular.Size = new System.Drawing.Size(137, 20);
            this.numTotalAnular.TabIndex = 33;
            this.numTotalAnular.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numNuevoSaldo
            // 
            this.numNuevoSaldo.DecimalPlaces = 2;
            this.numNuevoSaldo.Location = new System.Drawing.Point(927, 261);
            this.numNuevoSaldo.Name = "numNuevoSaldo";
            this.numNuevoSaldo.Size = new System.Drawing.Size(137, 20);
            this.numNuevoSaldo.TabIndex = 34;
            this.numNuevoSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numSaldoFinalCheq
            // 
            this.numSaldoFinalCheq.DecimalPlaces = 2;
            this.numSaldoFinalCheq.Location = new System.Drawing.Point(927, 306);
            this.numSaldoFinalCheq.Name = "numSaldoFinalCheq";
            this.numSaldoFinalCheq.Size = new System.Drawing.Size(137, 20);
            this.numSaldoFinalCheq.TabIndex = 35;
            this.numSaldoFinalCheq.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblmensaje
            // 
            this.lblmensaje.AutoSize = true;
            this.lblmensaje.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblmensaje.Location = new System.Drawing.Point(476, 19);
            this.lblmensaje.Name = "lblmensaje";
            this.lblmensaje.Size = new System.Drawing.Size(324, 13);
            this.lblmensaje.TabIndex = 36;
            this.lblmensaje.Text = "Marque los movimientos a anular antes de la \'Devolución a entidad\'";
            // 
            // FrmDevolucionExcesoEntidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 360);
            this.Controls.Add(this.lblmensaje);
            this.Controls.Add(this.txtObservacionDev);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dgvPlanillas);
            this.Controls.Add(this.plDatosPagos);
            this.Controls.Add(this.numSaldoFinalCheq);
            this.Controls.Add(this.numNuevoSaldo);
            this.Controls.Add(this.numTotalAnular);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.numImporteDevolver);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.numSaldoDisponible);
            this.Controls.Add(this.numSaldoActual);
            this.Controls.Add(this.txtPeriodoOri);
            this.Controls.Add(this.txtNroPlanillaOri);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "FrmDevolucionExcesoEntidad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmDevolucionExcesoEntidad";
            this.Load += new System.EventHandler(this.FrmDevolucionExcesoEntidad_Load);
            this.Shown += new System.EventHandler(this.FrmDevolucionExcesoEntidad_Shown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSaldoDisponible)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSaldoActual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numImporteDevolver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanillas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTotalAnular)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNuevoSaldo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSaldoFinalCheq)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnGuardar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnEliminar;
        private System.Windows.Forms.Panel plDatosPagos;
        private System.Windows.Forms.NumericUpDown numSaldoDisponible;
        private System.Windows.Forms.NumericUpDown numSaldoActual;
        private System.Windows.Forms.TextBox txtPeriodoOri;
        private System.Windows.Forms.TextBox txtNroPlanillaOri;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numImporteDevolver;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvPlanillas;
        private System.Windows.Forms.TextBox txtObservacionDev;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numTotalAnular;
        private System.Windows.Forms.NumericUpDown numNuevoSaldo;
        private System.Windows.Forms.NumericUpDown numSaldoFinalCheq;
        private System.Windows.Forms.Label lblmensaje;
    }
}