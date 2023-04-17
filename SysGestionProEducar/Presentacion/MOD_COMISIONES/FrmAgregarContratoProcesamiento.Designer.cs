
namespace Presentacion.MOD_COMISIONES
{
    partial class FrmAgregarContratoProcesamiento
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtNroContrato = new System.Windows.Forms.TextBox();
            this.dgvContratos = new System.Windows.Forms.DataGridView();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.lstvComisionGen = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lstvComisionExcluido = new System.Windows.Forms.ListView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContratos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Contrato";
            // 
            // txtNroContrato
            // 
            this.txtNroContrato.Location = new System.Drawing.Point(76, 39);
            this.txtNroContrato.Name = "txtNroContrato";
            this.txtNroContrato.Size = new System.Drawing.Size(137, 20);
            this.txtNroContrato.TabIndex = 2;
            this.txtNroContrato.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNroContrato.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtContrato_KeyDown);
            // 
            // dgvContratos
            // 
            this.dgvContratos.BackgroundColor = System.Drawing.Color.White;
            this.dgvContratos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContratos.GridColor = System.Drawing.Color.DimGray;
            this.dgvContratos.Location = new System.Drawing.Point(12, 83);
            this.dgvContratos.Name = "dgvContratos";
            this.dgvContratos.Size = new System.Drawing.Size(1070, 153);
            this.dgvContratos.TabIndex = 1;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(996, 39);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(86, 35);
            this.btnBuscar.TabIndex = 3;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(996, 242);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(86, 35);
            this.btnAgregar.TabIndex = 4;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
            // 
            // lstvComisionGen
            // 
            this.lstvComisionGen.HideSelection = false;
            this.lstvComisionGen.Location = new System.Drawing.Point(12, 296);
            this.lstvComisionGen.Name = "lstvComisionGen";
            this.lstvComisionGen.Size = new System.Drawing.Size(1070, 97);
            this.lstvComisionGen.TabIndex = 5;
            this.lstvComisionGen.UseCompatibleStateImageBehavior = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 280);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(195, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Comisiones Generadas de este contrato";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 395);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(188, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Comisiones Excluidos de este contrato";
            // 
            // lstvComisionExcluido
            // 
            this.lstvComisionExcluido.HideSelection = false;
            this.lstvComisionExcluido.Location = new System.Drawing.Point(12, 411);
            this.lstvComisionExcluido.Name = "lstvComisionExcluido";
            this.lstvComisionExcluido.Size = new System.Drawing.Size(1070, 97);
            this.lstvComisionExcluido.TabIndex = 7;
            this.lstvComisionExcluido.UseCompatibleStateImageBehavior = false;
            // 
            // FrmAgregarContratoProcesamiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1094, 515);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lstvComisionExcluido);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lstvComisionGen);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtNroContrato);
            this.Controls.Add(this.dgvContratos);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmAgregarContratoProcesamiento";
            this.Load += new System.EventHandler(this.FrmAgregarContratoProcesamiento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvContratos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNroContrato;
        private System.Windows.Forms.DataGridView dgvContratos;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.ListView lstvComisionGen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView lstvComisionExcluido;
    }
}