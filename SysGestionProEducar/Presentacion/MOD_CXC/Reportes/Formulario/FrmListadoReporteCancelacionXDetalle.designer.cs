
namespace Presentacion.MOD_CXC.Reportes.Formulario
{
    partial class FrmListadoReporteCancelacionXDetalle
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvPlanilla = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.txtCantidadPlanilla = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTotalPlanilla = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPeriodo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTipoPlanilla = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanilla)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPlanilla
            // 
            this.dgvPlanilla.AllowUserToAddRows = false;
            this.dgvPlanilla.AllowUserToDeleteRows = false;
            this.dgvPlanilla.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            this.dgvPlanilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlanilla.Location = new System.Drawing.Point(6, 118);
            this.dgvPlanilla.Name = "dgvPlanilla";
            this.dgvPlanilla.ReadOnly = true;
            this.dgvPlanilla.Size = new System.Drawing.Size(914, 467);
            this.dgvPlanilla.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(765, 37);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(151, 35);
            this.button1.TabIndex = 5;
            this.button1.Text = "Imprimir Detalle Contrato";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // txtCantidadPlanilla
            // 
            this.txtCantidadPlanilla.Enabled = false;
            this.txtCantidadPlanilla.Location = new System.Drawing.Point(176, 52);
            this.txtCantidadPlanilla.Name = "txtCantidadPlanilla";
            this.txtCantidadPlanilla.Size = new System.Drawing.Size(100, 20);
            this.txtCantidadPlanilla.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "CANTIDAD DE PLANILLA:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "MONTO TOTAL DE PLANILLA:";
            // 
            // txtTotalPlanilla
            // 
            this.txtTotalPlanilla.Enabled = false;
            this.txtTotalPlanilla.Location = new System.Drawing.Point(175, 91);
            this.txtTotalPlanilla.Name = "txtTotalPlanilla";
            this.txtTotalPlanilla.Size = new System.Drawing.Size(100, 20);
            this.txtTotalPlanilla.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "PERIODO:";
            // 
            // txtPeriodo
            // 
            this.txtPeriodo.Enabled = false;
            this.txtPeriodo.Location = new System.Drawing.Point(176, 18);
            this.txtPeriodo.Name = "txtPeriodo";
            this.txtPeriodo.Size = new System.Drawing.Size(100, 20);
            this.txtPeriodo.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(310, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "TIPO DE PLANILLA:";
            // 
            // txtTipoPlanilla
            // 
            this.txtTipoPlanilla.Enabled = false;
            this.txtTipoPlanilla.Location = new System.Drawing.Point(431, 91);
            this.txtTipoPlanilla.Name = "txtTipoPlanilla";
            this.txtTipoPlanilla.Size = new System.Drawing.Size(223, 20);
            this.txtTipoPlanilla.TabIndex = 13;
            // 
            // FrmListadoReporteCancelacionXDetalle
            // 
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(928, 589);
            this.Controls.Add(this.txtTipoPlanilla);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPeriodo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTotalPlanilla);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCantidadPlanilla);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvPlanilla);
            this.Name = "FrmListadoReporteCancelacionXDetalle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte de Cancelacion  por tipo de planilla detalle";
            this.Load += new System.EventHandler(this.FrmListadoPlanillasParaContratos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanilla)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPlanilla;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtCantidadPlanilla;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTotalPlanilla;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPeriodo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTipoPlanilla;
    }
}
