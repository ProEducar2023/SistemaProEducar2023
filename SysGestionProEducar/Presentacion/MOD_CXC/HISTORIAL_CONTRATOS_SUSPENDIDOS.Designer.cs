namespace Presentacion.MOD_CXC
{
    partial class HISTORIAL_CONTRATOS_SUSPENDIDOS
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
            this.dgw_contratos_suspendidos = new System.Windows.Forms.DataGridView();
            this.FECHA_SUSPENSION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PERIODOS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OBSERVACIONES = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ST_ANULACION = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.FECHA_ANULACION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OBS_ANULACION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESC_ANULACION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgw_contratos_suspendidos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgw_contratos_suspendidos
            // 
            this.dgw_contratos_suspendidos.AllowUserToAddRows = false;
            this.dgw_contratos_suspendidos.AllowUserToDeleteRows = false;
            this.dgw_contratos_suspendidos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgw_contratos_suspendidos.BackgroundColor = System.Drawing.Color.White;
            this.dgw_contratos_suspendidos.ColumnHeadersHeight = 47;
            this.dgw_contratos_suspendidos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FECHA_SUSPENSION,
            this.PERIODOS,
            this.OBSERVACIONES,
            this.ST_ANULACION,
            this.FECHA_ANULACION,
            this.OBS_ANULACION,
            this.DESC_ANULACION});
            this.dgw_contratos_suspendidos.Location = new System.Drawing.Point(11, 12);
            this.dgw_contratos_suspendidos.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dgw_contratos_suspendidos.MultiSelect = false;
            this.dgw_contratos_suspendidos.Name = "dgw_contratos_suspendidos";
            this.dgw_contratos_suspendidos.ReadOnly = true;
            this.dgw_contratos_suspendidos.RowHeadersWidth = 25;
            this.dgw_contratos_suspendidos.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dgw_contratos_suspendidos.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.dgw_contratos_suspendidos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgw_contratos_suspendidos.Size = new System.Drawing.Size(658, 200);
            this.dgw_contratos_suspendidos.TabIndex = 249;
            this.dgw_contratos_suspendidos.TabStop = false;
            // 
            // FECHA_SUSPENSION
            // 
            this.FECHA_SUSPENSION.HeaderText = "Fecha de Suspension";
            this.FECHA_SUSPENSION.Name = "FECHA_SUSPENSION";
            this.FECHA_SUSPENSION.ReadOnly = true;
            this.FECHA_SUSPENSION.Width = 80;
            // 
            // PERIODOS
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.PERIODOS.DefaultCellStyle = dataGridViewCellStyle1;
            this.PERIODOS.HeaderText = "Periodos";
            this.PERIODOS.Name = "PERIODOS";
            this.PERIODOS.ReadOnly = true;
            this.PERIODOS.Width = 230;
            // 
            // OBSERVACIONES
            // 
            this.OBSERVACIONES.HeaderText = "Observaciones";
            this.OBSERVACIONES.Name = "OBSERVACIONES";
            this.OBSERVACIONES.ReadOnly = true;
            this.OBSERVACIONES.Width = 250;
            // 
            // ST_ANULACION
            // 
            this.ST_ANULACION.HeaderText = "Anulado";
            this.ST_ANULACION.Name = "ST_ANULACION";
            this.ST_ANULACION.ReadOnly = true;
            this.ST_ANULACION.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ST_ANULACION.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ST_ANULACION.Width = 50;
            // 
            // FECHA_ANULACION
            // 
            this.FECHA_ANULACION.HeaderText = "Fecha de Anulacion";
            this.FECHA_ANULACION.Name = "FECHA_ANULACION";
            this.FECHA_ANULACION.ReadOnly = true;
            this.FECHA_ANULACION.Width = 80;
            // 
            // OBS_ANULACION
            // 
            this.OBS_ANULACION.HeaderText = "Obs Anulacion";
            this.OBS_ANULACION.Name = "OBS_ANULACION";
            this.OBS_ANULACION.ReadOnly = true;
            this.OBS_ANULACION.Width = 150;
            // 
            // DESC_ANULACION
            // 
            this.DESC_ANULACION.HeaderText = "Anulado por";
            this.DESC_ANULACION.Name = "DESC_ANULACION";
            this.DESC_ANULACION.ReadOnly = true;
            this.DESC_ANULACION.Width = 150;
            // 
            // HISTORIAL_CONTRATOS_SUSPENDIDOS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 224);
            this.Controls.Add(this.dgw_contratos_suspendidos);
            this.Name = "HISTORIAL_CONTRATOS_SUSPENDIDOS";
            this.Text = "Historial Contratos Supendidos";
            this.Load += new System.EventHandler(this.HISTORIAL_CONTRATOS_SUSPENDIDOS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgw_contratos_suspendidos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.DataGridView dgw_contratos_suspendidos;
        private System.Windows.Forms.DataGridViewTextBoxColumn FECHA_SUSPENSION;
        private System.Windows.Forms.DataGridViewTextBoxColumn PERIODOS;
        private System.Windows.Forms.DataGridViewTextBoxColumn OBSERVACIONES;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ST_ANULACION;
        private System.Windows.Forms.DataGridViewTextBoxColumn FECHA_ANULACION;
        private System.Windows.Forms.DataGridViewTextBoxColumn OBS_ANULACION;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESC_ANULACION;
    }
}