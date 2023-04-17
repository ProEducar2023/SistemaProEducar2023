
namespace Presentacion.MOD_COMISIONES
{
    partial class FrmRegistroOtrosIngresosEgresosVendedores
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnCerrarAbrir = new System.Windows.Forms.Button();
            this.btnEliminarLiqu = new System.Windows.Forms.Button();
            this.btnConsultarLiqu = new System.Windows.Forms.Button();
            this.btnLiqidar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cboPeriodoGen = new System.Windows.Forms.ComboBox();
            this.dgvVendedores = new System.Windows.Forms.DataGridView();
            this.dgvIngreEgre = new System.Windows.Forms.DataGridView();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.lstvTotales = new System.Windows.Forms.ListView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.lblTotEgreso = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.lblTotIngreso = new System.Windows.Forms.ToolStripLabel();
            this.lblCantRegistro2 = new System.Windows.Forms.ToolStripLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lstvTotalesVendedores = new System.Windows.Forms.ListView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendedores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngreEgre)).BeginInit();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblMessage);
            this.groupBox1.Controls.Add(this.btnCerrarAbrir);
            this.groupBox1.Controls.Add(this.btnEliminarLiqu);
            this.groupBox1.Controls.Add(this.btnConsultarLiqu);
            this.groupBox1.Controls.Add(this.btnLiqidar);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cboPeriodoGen);
            this.groupBox1.Location = new System.Drawing.Point(5, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1343, 61);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.Red;
            this.lblMessage.Location = new System.Drawing.Point(75, 45);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(70, 13);
            this.lblMessage.TabIndex = 44;
            this.lblMessage.Text = "lblMessage";
            this.lblMessage.Visible = false;
            // 
            // btnCerrarAbrir
            // 
            this.btnCerrarAbrir.Location = new System.Drawing.Point(1216, 11);
            this.btnCerrarAbrir.Name = "btnCerrarAbrir";
            this.btnCerrarAbrir.Size = new System.Drawing.Size(96, 41);
            this.btnCerrarAbrir.TabIndex = 15;
            this.btnCerrarAbrir.Text = "Cerrar/Abrir Liquidación";
            this.btnCerrarAbrir.UseVisualStyleBackColor = true;
            this.btnCerrarAbrir.Click += new System.EventHandler(this.BtnCerrarAbrir_Click);
            // 
            // btnEliminarLiqu
            // 
            this.btnEliminarLiqu.Location = new System.Drawing.Point(1012, 11);
            this.btnEliminarLiqu.Name = "btnEliminarLiqu";
            this.btnEliminarLiqu.Size = new System.Drawing.Size(96, 41);
            this.btnEliminarLiqu.TabIndex = 13;
            this.btnEliminarLiqu.Text = "Eliminar Pllas. Liquidación";
            this.btnEliminarLiqu.UseVisualStyleBackColor = true;
            this.btnEliminarLiqu.Visible = false;
            this.btnEliminarLiqu.Click += new System.EventHandler(this.BtnEliminarLiqu_Click);
            // 
            // btnConsultarLiqu
            // 
            this.btnConsultarLiqu.Location = new System.Drawing.Point(1114, 11);
            this.btnConsultarLiqu.Name = "btnConsultarLiqu";
            this.btnConsultarLiqu.Size = new System.Drawing.Size(96, 41);
            this.btnConsultarLiqu.TabIndex = 12;
            this.btnConsultarLiqu.Text = "Consultar Pllas. Liquidación";
            this.btnConsultarLiqu.UseVisualStyleBackColor = true;
            this.btnConsultarLiqu.Visible = false;
            this.btnConsultarLiqu.Click += new System.EventHandler(this.BtnConsultarLiqu_Click);
            // 
            // btnLiqidar
            // 
            this.btnLiqidar.Location = new System.Drawing.Point(910, 11);
            this.btnLiqidar.Name = "btnLiqidar";
            this.btnLiqidar.Size = new System.Drawing.Size(96, 41);
            this.btnLiqidar.TabIndex = 11;
            this.btnLiqidar.Text = "Gener. Pllas Liquidación";
            this.btnLiqidar.UseVisualStyleBackColor = true;
            this.btnLiqidar.Visible = false;
            this.btnLiqidar.Click += new System.EventHandler(this.BtnLiqidar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Período";
            // 
            // cboPeriodoGen
            // 
            this.cboPeriodoGen.FormattingEnabled = true;
            this.cboPeriodoGen.Location = new System.Drawing.Point(78, 14);
            this.cboPeriodoGen.Name = "cboPeriodoGen";
            this.cboPeriodoGen.Size = new System.Drawing.Size(126, 21);
            this.cboPeriodoGen.TabIndex = 0;
            this.cboPeriodoGen.SelectionChangeCommitted += new System.EventHandler(this.CboPeriodoGen_SelectionChangeCommitted);
            // 
            // dgvVendedores
            // 
            this.dgvVendedores.BackgroundColor = System.Drawing.Color.White;
            this.dgvVendedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVendedores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVendedores.Location = new System.Drawing.Point(0, 0);
            this.dgvVendedores.Name = "dgvVendedores";
            this.dgvVendedores.Size = new System.Drawing.Size(864, 501);
            this.dgvVendedores.TabIndex = 1;
            this.dgvVendedores.SelectionChanged += new System.EventHandler(this.DgvVendedores_SelectionChanged);
            // 
            // dgvIngreEgre
            // 
            this.dgvIngreEgre.BackgroundColor = System.Drawing.Color.White;
            this.dgvIngreEgre.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIngreEgre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvIngreEgre.Location = new System.Drawing.Point(0, 0);
            this.dgvIngreEgre.Name = "dgvIngreEgre";
            this.dgvIngreEgre.Size = new System.Drawing.Size(472, 309);
            this.dgvIngreEgre.TabIndex = 2;
            this.dgvIngreEgre.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.DgvIngreEgre_CellBeginEdit);
            this.dgvIngreEgre.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvIngreEgre_CellClick);
            this.dgvIngreEgre.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvIngreEgre_CellEndEdit);
            this.dgvIngreEgre.CurrentCellDirtyStateChanged += new System.EventHandler(this.DgvIngreEgre_CurrentCellDirtyStateChanged);
            this.dgvIngreEgre.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.DgvIngreEgre_DataError);
            // 
            // btnGrabar
            // 
            this.btnGrabar.Location = new System.Drawing.Point(875, 419);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 35);
            this.btnGrabar.TabIndex = 4;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.BtnGrabar_Click);
            this.btnGrabar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnGrabar_MouseDown);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(957, 419);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 35);
            this.btnEliminar.TabIndex = 6;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            this.btnEliminar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnGrabar_MouseDown);
            // 
            // lstvTotales
            // 
            this.lstvTotales.HideSelection = false;
            this.lstvTotales.Location = new System.Drawing.Point(874, 501);
            this.lstvTotales.Name = "lstvTotales";
            this.lstvTotales.Size = new System.Drawing.Size(474, 113);
            this.lstvTotales.TabIndex = 7;
            this.lstvTotales.UseCompatibleStateImageBehavior = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvIngreEgre);
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Location = new System.Drawing.Point(876, 79);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(472, 334);
            this.panel1.TabIndex = 8;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Teal;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblTotEgreso,
            this.toolStripSeparator1,
            this.lblTotIngreso,
            this.lblCantRegistro2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 309);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(472, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // lblTotEgreso
            // 
            this.lblTotEgreso.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblTotEgreso.ForeColor = System.Drawing.Color.White;
            this.lblTotEgreso.Name = "lblTotEgreso";
            this.lblTotEgreso.Size = new System.Drawing.Size(71, 22);
            this.lblTotEgreso.Text = "lblTotEgreso";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // lblTotIngreso
            // 
            this.lblTotIngreso.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblTotIngreso.ForeColor = System.Drawing.Color.White;
            this.lblTotIngreso.Name = "lblTotIngreso";
            this.lblTotIngreso.Size = new System.Drawing.Size(75, 22);
            this.lblTotIngreso.Text = "lblTotIngreso";
            // 
            // lblCantRegistro2
            // 
            this.lblCantRegistro2.ForeColor = System.Drawing.Color.White;
            this.lblCantRegistro2.Name = "lblCantRegistro2";
            this.lblCantRegistro2.Size = new System.Drawing.Size(88, 22);
            this.lblCantRegistro2.Text = "lblCantRegistro";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvVendedores);
            this.panel2.Location = new System.Drawing.Point(4, 79);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(864, 501);
            this.panel2.TabIndex = 9;
            // 
            // lstvTotalesVendedores
            // 
            this.lstvTotalesVendedores.HideSelection = false;
            this.lstvTotalesVendedores.Location = new System.Drawing.Point(5, 582);
            this.lstvTotalesVendedores.Name = "lstvTotalesVendedores";
            this.lstvTotalesVendedores.Size = new System.Drawing.Size(863, 31);
            this.lstvTotalesVendedores.TabIndex = 10;
            this.lstvTotalesVendedores.UseCompatibleStateImageBehavior = false;
            // 
            // FrmRegistroOtrosIngresosEgresosVendedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1354, 626);
            this.Controls.Add(this.lstvTotalesVendedores);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lstvTotales);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmRegistroOtrosIngresosEgresosVendedores";
            this.Text = "REGISTRO DE OTROS CARGOS Y ABONOS";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmRegistroOtrosIngresosEgresosVendedores_FormClosing);
            this.Load += new System.EventHandler(this.FrmRegistroOtrosIngresosEgresosVendedores_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendedores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngreEgre)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboPeriodoGen;
        private System.Windows.Forms.DataGridView dgvVendedores;
        private System.Windows.Forms.DataGridView dgvIngreEgre;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.ListView lstvTotales;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel lblTotEgreso;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel lblTotIngreso;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripLabel lblCantRegistro2;
        private System.Windows.Forms.ListView lstvTotalesVendedores;
        private System.Windows.Forms.Button btnLiqidar;
        private System.Windows.Forms.Button btnConsultarLiqu;
        private System.Windows.Forms.Button btnEliminarLiqu;
        private System.Windows.Forms.Button btnCerrarAbrir;
        private System.Windows.Forms.Label lblMessage;
    }
}