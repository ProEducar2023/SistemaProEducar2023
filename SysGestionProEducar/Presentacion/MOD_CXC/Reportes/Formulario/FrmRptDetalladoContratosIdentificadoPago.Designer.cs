
namespace Presentacion.MOD_CXC.Reportes.Formulario
{
    partial class FrmRptDetalladoContratosIdentificadoPago
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboPrograma = new System.Windows.Forms.ComboBox();
            this.cboAreaTrabajo = new System.Windows.Forms.ComboBox();
            this.cboGestor = new System.Windows.Forms.ComboBox();
            this.dtFechaIdenIni = new System.Windows.Forms.DateTimePicker();
            this.dtFechaIdenFin = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.btnGenerarReporte = new System.Windows.Forms.Button();
            this.chkIncluirSinFecIdenPago = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(87, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Programa";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(71, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Área Trabajo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(101, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Gestor";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Fecha Iden. Abono";
            // 
            // cboPrograma
            // 
            this.cboPrograma.FormattingEnabled = true;
            this.cboPrograma.Location = new System.Drawing.Point(149, 46);
            this.cboPrograma.Name = "cboPrograma";
            this.cboPrograma.Size = new System.Drawing.Size(252, 21);
            this.cboPrograma.TabIndex = 4;
            // 
            // cboAreaTrabajo
            // 
            this.cboAreaTrabajo.FormattingEnabled = true;
            this.cboAreaTrabajo.Location = new System.Drawing.Point(149, 82);
            this.cboAreaTrabajo.Name = "cboAreaTrabajo";
            this.cboAreaTrabajo.Size = new System.Drawing.Size(252, 21);
            this.cboAreaTrabajo.TabIndex = 5;
            this.cboAreaTrabajo.SelectedValueChanged += new System.EventHandler(this.CboAreaTrabajo_SelectedValueChanged);
            // 
            // cboGestor
            // 
            this.cboGestor.FormattingEnabled = true;
            this.cboGestor.Location = new System.Drawing.Point(149, 119);
            this.cboGestor.Name = "cboGestor";
            this.cboGestor.Size = new System.Drawing.Size(252, 21);
            this.cboGestor.TabIndex = 6;
            // 
            // dtFechaIdenIni
            // 
            this.dtFechaIdenIni.CustomFormat = "dd/MM/yyyy";
            this.dtFechaIdenIni.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFechaIdenIni.Location = new System.Drawing.Point(149, 153);
            this.dtFechaIdenIni.Name = "dtFechaIdenIni";
            this.dtFechaIdenIni.Size = new System.Drawing.Size(97, 20);
            this.dtFechaIdenIni.TabIndex = 7;
            // 
            // dtFechaIdenFin
            // 
            this.dtFechaIdenFin.CustomFormat = "dd/MM/yyyy";
            this.dtFechaIdenFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFechaIdenFin.Location = new System.Drawing.Point(270, 153);
            this.dtFechaIdenFin.Name = "dtFechaIdenFin";
            this.dtFechaIdenFin.Size = new System.Drawing.Size(97, 20);
            this.dtFechaIdenFin.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(251, 157);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "al";
            // 
            // btnGenerarReporte
            // 
            this.btnGenerarReporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerarReporte.Location = new System.Drawing.Point(180, 217);
            this.btnGenerarReporte.Name = "btnGenerarReporte";
            this.btnGenerarReporte.Size = new System.Drawing.Size(128, 34);
            this.btnGenerarReporte.TabIndex = 10;
            this.btnGenerarReporte.Text = "Generar Reporte";
            this.btnGenerarReporte.UseVisualStyleBackColor = true;
            this.btnGenerarReporte.Click += new System.EventHandler(this.BtnGenerarReporte_Click);
            // 
            // chkIncluirSinFecIdenPago
            // 
            this.chkIncluirSinFecIdenPago.AutoSize = true;
            this.chkIncluirSinFecIdenPago.Location = new System.Drawing.Point(149, 182);
            this.chkIncluirSinFecIdenPago.Name = "chkIncluirSinFecIdenPago";
            this.chkIncluirSinFecIdenPago.Size = new System.Drawing.Size(224, 17);
            this.chkIncluirSinFecIdenPago.TabIndex = 11;
            this.chkIncluirSinFecIdenPago.Text = "Incluir contratos sin identificación de pago";
            this.chkIncluirSinFecIdenPago.UseVisualStyleBackColor = true;
            // 
            // FrmRptDetalladoContratosIdentificadoPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 329);
            this.Controls.Add(this.chkIncluirSinFecIdenPago);
            this.Controls.Add(this.btnGenerarReporte);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtFechaIdenFin);
            this.Controls.Add(this.dtFechaIdenIni);
            this.Controls.Add(this.cboGestor);
            this.Controls.Add(this.cboAreaTrabajo);
            this.Controls.Add(this.cboPrograma);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmRptDetalladoContratosIdentificadoPago";
            this.Text = "Reporte de Contratos - Identificados Pago";
            this.Load += new System.EventHandler(this.FrmRptDetalladoContratosIdentificadoPago_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboPrograma;
        private System.Windows.Forms.ComboBox cboAreaTrabajo;
        private System.Windows.Forms.ComboBox cboGestor;
        private System.Windows.Forms.DateTimePicker dtFechaIdenIni;
        private System.Windows.Forms.DateTimePicker dtFechaIdenFin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnGenerarReporte;
        private System.Windows.Forms.CheckBox chkIncluirSinFecIdenPago;
    }
}