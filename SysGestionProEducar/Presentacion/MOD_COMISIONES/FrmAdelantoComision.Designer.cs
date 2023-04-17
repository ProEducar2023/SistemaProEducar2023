
namespace Presentacion.MOD_COMISIONES
{
    partial class FrmAdelantoComision
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvVendedores = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvContratos = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAbrirAdelantoComision = new System.Windows.Forms.Button();
            this.btnNuevoAdelanto = new System.Windows.Forms.Button();
            this.btnCerrarAdelantoComision = new System.Windows.Forms.Button();
            this.btnGenerarReporte = new System.Windows.Forms.Button();
            this.btnEliminarComision = new System.Windows.Forms.Button();
            this.btnGenAdelComision = new System.Windows.Forms.Button();
            this.lstvTotalesVendedores = new System.Windows.Forms.ListView();
            this.lstTotalCotratos = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvTotalAdelantoComision = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.cboNroAdelanto = new System.Windows.Forms.ComboBox();
            this.lblNroAdelanto = new System.Windows.Forms.Label();
            this.lstTotalGeneralXGrupo = new System.Windows.Forms.ListView();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendedores)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContratos)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTotalAdelantoComision)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvVendedores);
            this.panel2.Location = new System.Drawing.Point(5, 86);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(465, 503);
            this.panel2.TabIndex = 14;
            // 
            // dgvVendedores
            // 
            this.dgvVendedores.BackgroundColor = System.Drawing.Color.White;
            this.dgvVendedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVendedores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVendedores.Location = new System.Drawing.Point(0, 0);
            this.dgvVendedores.Name = "dgvVendedores";
            this.dgvVendedores.Size = new System.Drawing.Size(465, 503);
            this.dgvVendedores.TabIndex = 1;
            this.dgvVendedores.SelectionChanged += new System.EventHandler(this.DgvVendedores_SelectionChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvContratos);
            this.panel1.Location = new System.Drawing.Point(476, 105);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(747, 314);
            this.panel1.TabIndex = 13;
            // 
            // dgvContratos
            // 
            this.dgvContratos.BackgroundColor = System.Drawing.Color.White;
            this.dgvContratos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContratos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvContratos.Location = new System.Drawing.Point(0, 0);
            this.dgvContratos.Name = "dgvContratos";
            this.dgvContratos.Size = new System.Drawing.Size(747, 314);
            this.dgvContratos.TabIndex = 2;
            this.dgvContratos.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.DgvContratos_CellBeginEdit);
            this.dgvContratos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvContratos_CellContentClick);
            this.dgvContratos.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvContratos_CellEndEdit);
            this.dgvContratos.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.DgvContratos_CellValidating);
            this.dgvContratos.CurrentCellDirtyStateChanged += new System.EventHandler(this.DgvContratos_CurrentCellDirtyStateChanged);
            this.dgvContratos.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.DgvContratos_DataError);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAbrirAdelantoComision);
            this.groupBox1.Controls.Add(this.btnNuevoAdelanto);
            this.groupBox1.Controls.Add(this.btnCerrarAdelantoComision);
            this.groupBox1.Controls.Add(this.btnGenerarReporte);
            this.groupBox1.Controls.Add(this.btnEliminarComision);
            this.groupBox1.Controls.Add(this.btnGenAdelComision);
            this.groupBox1.Location = new System.Drawing.Point(6, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1217, 61);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // btnAbrirAdelantoComision
            // 
            this.btnAbrirAdelantoComision.Location = new System.Drawing.Point(1010, 14);
            this.btnAbrirAdelantoComision.Name = "btnAbrirAdelantoComision";
            this.btnAbrirAdelantoComision.Size = new System.Drawing.Size(103, 41);
            this.btnAbrirAdelantoComision.TabIndex = 17;
            this.btnAbrirAdelantoComision.Text = "Abrir Adelanto Comisiones";
            this.btnAbrirAdelantoComision.UseVisualStyleBackColor = true;
            this.btnAbrirAdelantoComision.Click += new System.EventHandler(this.BtnAbrirAdelantoComision_Click);
            // 
            // btnNuevoAdelanto
            // 
            this.btnNuevoAdelanto.Location = new System.Drawing.Point(698, 14);
            this.btnNuevoAdelanto.Name = "btnNuevoAdelanto";
            this.btnNuevoAdelanto.Size = new System.Drawing.Size(92, 41);
            this.btnNuevoAdelanto.TabIndex = 16;
            this.btnNuevoAdelanto.Text = "Nuevo Adelanto";
            this.btnNuevoAdelanto.UseVisualStyleBackColor = true;
            this.btnNuevoAdelanto.Click += new System.EventHandler(this.BtnNuevoAdelanto_Click);
            // 
            // btnCerrarAdelantoComision
            // 
            this.btnCerrarAdelantoComision.Location = new System.Drawing.Point(905, 14);
            this.btnCerrarAdelantoComision.Name = "btnCerrarAdelantoComision";
            this.btnCerrarAdelantoComision.Size = new System.Drawing.Size(103, 41);
            this.btnCerrarAdelantoComision.TabIndex = 15;
            this.btnCerrarAdelantoComision.Text = "Cerrar Adelanto Comisiones";
            this.btnCerrarAdelantoComision.UseVisualStyleBackColor = true;
            this.btnCerrarAdelantoComision.Click += new System.EventHandler(this.BtnCerrarAdelantoComision_Click);
            // 
            // btnGenerarReporte
            // 
            this.btnGenerarReporte.Location = new System.Drawing.Point(1119, 14);
            this.btnGenerarReporte.Name = "btnGenerarReporte";
            this.btnGenerarReporte.Size = new System.Drawing.Size(92, 41);
            this.btnGenerarReporte.TabIndex = 14;
            this.btnGenerarReporte.Text = "Reporte";
            this.btnGenerarReporte.UseVisualStyleBackColor = true;
            this.btnGenerarReporte.Click += new System.EventHandler(this.BtnGenerarReporte_Click);
            // 
            // btnEliminarComision
            // 
            this.btnEliminarComision.Location = new System.Drawing.Point(596, 14);
            this.btnEliminarComision.Name = "btnEliminarComision";
            this.btnEliminarComision.Size = new System.Drawing.Size(96, 41);
            this.btnEliminarComision.TabIndex = 13;
            this.btnEliminarComision.Text = "Eliminar Comisión";
            this.btnEliminarComision.UseVisualStyleBackColor = true;
            this.btnEliminarComision.Visible = false;
            this.btnEliminarComision.Click += new System.EventHandler(this.BtnEliminarComision_Click);
            // 
            // btnGenAdelComision
            // 
            this.btnGenAdelComision.Location = new System.Drawing.Point(796, 14);
            this.btnGenAdelComision.Name = "btnGenAdelComision";
            this.btnGenAdelComision.Size = new System.Drawing.Size(103, 41);
            this.btnGenAdelComision.TabIndex = 11;
            this.btnGenAdelComision.Text = "Grabar Adelanto Comisión";
            this.btnGenAdelComision.UseVisualStyleBackColor = true;
            this.btnGenAdelComision.Click += new System.EventHandler(this.BtnGenAdelComision_Click);
            // 
            // lstvTotalesVendedores
            // 
            this.lstvTotalesVendedores.HideSelection = false;
            this.lstvTotalesVendedores.Location = new System.Drawing.Point(5, 590);
            this.lstvTotalesVendedores.Name = "lstvTotalesVendedores";
            this.lstvTotalesVendedores.Size = new System.Drawing.Size(465, 31);
            this.lstvTotalesVendedores.TabIndex = 15;
            this.lstvTotalesVendedores.UseCompatibleStateImageBehavior = false;
            // 
            // lstTotalCotratos
            // 
            this.lstTotalCotratos.HideSelection = false;
            this.lstTotalCotratos.Location = new System.Drawing.Point(476, 422);
            this.lstTotalCotratos.Name = "lstTotalCotratos";
            this.lstTotalCotratos.Size = new System.Drawing.Size(747, 31);
            this.lstTotalCotratos.TabIndex = 16;
            this.lstTotalCotratos.UseCompatibleStateImageBehavior = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "LISTA DE VENDEDORES";
            // 
            // dgvTotalAdelantoComision
            // 
            this.dgvTotalAdelantoComision.BackgroundColor = System.Drawing.Color.White;
            this.dgvTotalAdelantoComision.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTotalAdelantoComision.GridColor = System.Drawing.Color.White;
            this.dgvTotalAdelantoComision.Location = new System.Drawing.Point(476, 460);
            this.dgvTotalAdelantoComision.Name = "dgvTotalAdelantoComision";
            this.dgvTotalAdelantoComision.Size = new System.Drawing.Size(747, 129);
            this.dgvTotalAdelantoComision.TabIndex = 19;
            this.dgvTotalAdelantoComision.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvTotalAdelantoComision_CellEndEdit);
            this.dgvTotalAdelantoComision.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.DgvTotalAdelantoComision_CellValidating);
            this.dgvTotalAdelantoComision.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.DgvTotalAdelantoComision_DataError);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(987, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Nro de Adelantos";
            // 
            // cboNroAdelanto
            // 
            this.cboNroAdelanto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboNroAdelanto.FormattingEnabled = true;
            this.cboNroAdelanto.Location = new System.Drawing.Point(1082, 78);
            this.cboNroAdelanto.Name = "cboNroAdelanto";
            this.cboNroAdelanto.Size = new System.Drawing.Size(136, 21);
            this.cboNroAdelanto.TabIndex = 21;
            this.cboNroAdelanto.SelectionChangeCommitted += new System.EventHandler(this.CboNroAdelanto_SelectionChangeCommitted);
            // 
            // lblNroAdelanto
            // 
            this.lblNroAdelanto.AutoSize = true;
            this.lblNroAdelanto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNroAdelanto.ForeColor = System.Drawing.Color.Blue;
            this.lblNroAdelanto.Location = new System.Drawing.Point(473, 86);
            this.lblNroAdelanto.Name = "lblNroAdelanto";
            this.lblNroAdelanto.Size = new System.Drawing.Size(163, 13);
            this.lblNroAdelanto.TabIndex = 22;
            this.lblNroAdelanto.Text = "Nro adelanto a generar: {0}";
            // 
            // lstTotalGeneralXGrupo
            // 
            this.lstTotalGeneralXGrupo.HideSelection = false;
            this.lstTotalGeneralXGrupo.Location = new System.Drawing.Point(476, 590);
            this.lstTotalGeneralXGrupo.Name = "lstTotalGeneralXGrupo";
            this.lstTotalGeneralXGrupo.Size = new System.Drawing.Size(747, 31);
            this.lstTotalGeneralXGrupo.TabIndex = 23;
            this.lstTotalGeneralXGrupo.UseCompatibleStateImageBehavior = false;
            // 
            // FrmAdelantoComision
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1230, 626);
            this.Controls.Add(this.lstTotalGeneralXGrupo);
            this.Controls.Add(this.lblNroAdelanto);
            this.Controls.Add(this.cboNroAdelanto);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvTotalAdelantoComision);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lstTotalCotratos);
            this.Controls.Add(this.lstvTotalesVendedores);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmAdelantoComision";
            this.Text = "ADELANTO DE COMISIONES DE CONTRATO POR APROBAR";
            this.Load += new System.EventHandler(this.FrmAdelantoComision_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendedores)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvContratos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTotalAdelantoComision)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvVendedores;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvContratos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnEliminarComision;
        private System.Windows.Forms.Button btnGenAdelComision;
        private System.Windows.Forms.ListView lstvTotalesVendedores;
        private System.Windows.Forms.ListView lstTotalCotratos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGenerarReporte;
        private System.Windows.Forms.DataGridView dgvTotalAdelantoComision;
        private System.Windows.Forms.Button btnCerrarAdelantoComision;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboNroAdelanto;
        private System.Windows.Forms.Button btnNuevoAdelanto;
        private System.Windows.Forms.Label lblNroAdelanto;
        private System.Windows.Forms.ListView lstTotalGeneralXGrupo;
        private System.Windows.Forms.Button btnAbrirAdelantoComision;
    }
}