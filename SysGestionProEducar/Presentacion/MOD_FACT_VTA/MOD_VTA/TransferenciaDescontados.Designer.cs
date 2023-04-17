namespace Presentacion.MOD_FACT_VTA.MOD_VTA
{
    partial class TransferenciaDescontados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransferenciaDescontados));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnTransferir = new System.Windows.Forms.ToolStripButton();
            this.dgvPlanillasDesc = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanillasDesc)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnTransferir});
            this.toolStrip1.Location = new System.Drawing.Point(0, 422);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(721, 28);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnTransferir
            // 
            this.btnTransferir.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnTransferir.BackColor = System.Drawing.Color.Gray;
            this.btnTransferir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnTransferir.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransferir.ForeColor = System.Drawing.Color.White;
            this.btnTransferir.Image = ((System.Drawing.Image)(resources.GetObject("btnTransferir.Image")));
            this.btnTransferir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTransferir.Name = "btnTransferir";
            this.btnTransferir.Size = new System.Drawing.Size(108, 25);
            this.btnTransferir.Text = "TRANSFERIR";
            // 
            // dgvPlanillasDesc
            // 
            this.dgvPlanillasDesc.AllowUserToAddRows = false;
            this.dgvPlanillasDesc.AllowUserToDeleteRows = false;
            this.dgvPlanillasDesc.BackgroundColor = System.Drawing.Color.White;
            this.dgvPlanillasDesc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlanillasDesc.Location = new System.Drawing.Point(0, 45);
            this.dgvPlanillasDesc.Name = "dgvPlanillasDesc";
            this.dgvPlanillasDesc.ReadOnly = true;
            this.dgvPlanillasDesc.Size = new System.Drawing.Size(720, 377);
            this.dgvPlanillasDesc.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(720, 38);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(274, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Transferencia Planillas";
            // 
            // TransferenciaDescontados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvPlanillasDesc);
            this.Controls.Add(this.toolStrip1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TransferenciaDescontados";
            this.Load += new System.EventHandler(this.TransferenciaDescontados_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanillasDesc)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.DataGridView dgvPlanillasDesc;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripButton btnTransferir;
    }
}