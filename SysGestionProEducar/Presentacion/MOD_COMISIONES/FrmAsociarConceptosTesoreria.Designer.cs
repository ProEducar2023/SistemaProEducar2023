
namespace Presentacion.MOD_COMISIONES
{
    partial class FrmAsociarConceptosTesoreria
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.cboTipoAsociar = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvConceptoAsoc = new System.Windows.Forms.DataGridView();
            this.dgvConcepto = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.dgvTipoAsociacion = new System.Windows.Forms.DataGridView();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConceptoAsoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConcepto)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTipoAsociacion)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(3, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(826, 532);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.TabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.cboTipoAsociar);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.dgvConceptoAsoc);
            this.tabPage1.Controls.Add(this.dgvConcepto);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(818, 506);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Asociar Conceptos";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Conceptos de Tesorería";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboTipoAsociar
            // 
            this.cboTipoAsociar.FormattingEnabled = true;
            this.cboTipoAsociar.Location = new System.Drawing.Point(495, 29);
            this.cboTipoAsociar.Name = "cboTipoAsociar";
            this.cboTipoAsociar.Size = new System.Drawing.Size(317, 21);
            this.cboTipoAsociar.TabIndex = 3;
            this.cboTipoAsociar.SelectedValueChanged += new System.EventHandler(this.CboTipoAsociar_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(416, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Asociar con";
            // 
            // dgvConceptoAsoc
            // 
            this.dgvConceptoAsoc.AllowDrop = true;
            this.dgvConceptoAsoc.BackgroundColor = System.Drawing.Color.White;
            this.dgvConceptoAsoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConceptoAsoc.Location = new System.Drawing.Point(419, 53);
            this.dgvConceptoAsoc.Name = "dgvConceptoAsoc";
            this.dgvConceptoAsoc.Size = new System.Drawing.Size(393, 445);
            this.dgvConceptoAsoc.TabIndex = 1;
            this.dgvConceptoAsoc.DragDrop += new System.Windows.Forms.DragEventHandler(this.DgvConcepto2_DragDrop);
            this.dgvConceptoAsoc.DragEnter += new System.Windows.Forms.DragEventHandler(this.DgvConcepto2_DragEnter);
            this.dgvConceptoAsoc.DragOver += new System.Windows.Forms.DragEventHandler(this.DgvConcepto2_DragOver);
            this.dgvConceptoAsoc.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DgvConcepto2_MouseDown);
            this.dgvConceptoAsoc.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DgvConcepto2_MouseMove);
            // 
            // dgvConcepto
            // 
            this.dgvConcepto.AllowDrop = true;
            this.dgvConcepto.BackgroundColor = System.Drawing.Color.White;
            this.dgvConcepto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConcepto.Location = new System.Drawing.Point(6, 50);
            this.dgvConcepto.Name = "dgvConcepto";
            this.dgvConcepto.Size = new System.Drawing.Size(393, 445);
            this.dgvConcepto.TabIndex = 0;
            this.dgvConcepto.DragDrop += new System.Windows.Forms.DragEventHandler(this.DgvConcepto_DragDrop);
            this.dgvConcepto.DragEnter += new System.Windows.Forms.DragEventHandler(this.DgvConcepto_DragEnter);
            this.dgvConcepto.DragOver += new System.Windows.Forms.DragEventHandler(this.DgvConcepto_DragOver);
            this.dgvConcepto.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DgvConcepto_MouseDown);
            this.dgvConcepto.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DgvConcepto_MouseMove);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnActualizar);
            this.tabPage2.Controls.Add(this.btnNuevo);
            this.tabPage2.Controls.Add(this.dgvTipoAsociacion);
            this.tabPage2.Controls.Add(this.btnCancelar);
            this.tabPage2.Controls.Add(this.btnGuardar);
            this.tabPage2.Controls.Add(this.txtDescripcion);
            this.tabPage2.Controls.Add(this.txtCodigo);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(818, 506);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Mantenedor";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(331, 110);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(85, 36);
            this.btnActualizar.TabIndex = 8;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.BtnActualizar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(250, 110);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(75, 36);
            this.btnNuevo.TabIndex = 7;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.BtnNuevo_Click);
            // 
            // dgvTipoAsociacion
            // 
            this.dgvTipoAsociacion.BackgroundColor = System.Drawing.Color.White;
            this.dgvTipoAsociacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTipoAsociacion.Location = new System.Drawing.Point(101, 174);
            this.dgvTipoAsociacion.Name = "dgvTipoAsociacion";
            this.dgvTipoAsociacion.Size = new System.Drawing.Size(601, 312);
            this.dgvTipoAsociacion.TabIndex = 6;
            this.dgvTipoAsociacion.SelectionChanged += new System.EventHandler(this.DgvTipoAsociacion_SelectionChanged);
            this.dgvTipoAsociacion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DgvTipoAsociacion_KeyDown);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(513, 110);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 36);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(422, 110);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(85, 36);
            this.btnGuardar.TabIndex = 4;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(316, 62);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(298, 20);
            this.txtDescripcion.TabIndex = 3;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(316, 36);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(113, 20);
            this.txtCodigo.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(247, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Descripción";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(247, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código";
            // 
            // FrmAsociarConceptosTesoreria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 536);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "FrmAsociarConceptosTesoreria";
            this.Text = "CONCEPTOS DE TESORERÍA PARA LIQUIDACIÓN";
            this.Load += new System.EventHandler(this.FrmAsociarConceptosTesoreria_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConceptoAsoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConcepto)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTipoAsociacion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ComboBox cboTipoAsociar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvConceptoAsoc;
        private System.Windows.Forms.DataGridView dgvConcepto;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.DataGridView dgvTipoAsociacion;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
    }
}