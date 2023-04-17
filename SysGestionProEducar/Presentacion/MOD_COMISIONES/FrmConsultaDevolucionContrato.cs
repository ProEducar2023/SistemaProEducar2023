using System;
using System.Data;
using System.Windows.Forms;
using static Presentacion.HELPERS.FormatDataGridViewColumns;
using static Presentacion.HELPERS.GenericMethod;
using static Presentacion.HELPERS.AppearanceUtil;
using BLL;
using System.Drawing;

namespace Presentacion.MOD_COMISIONES
{
    public partial class FrmConsultaDevolucionContrato : Form
    {
        public FrmConsultaDevolucionContrato()
        {
            InitializeComponent();
        }

        private readonly comisionesBLL BLComision = new comisionesBLL();

        private void FrmConsultaDevolucionContrato_Load(object sender, EventArgs e)
        {
            StartControls();
        }

        private void StartControls()
        {
            _ = txtNroContrato.Focus();
            btnBuscar.StyleButtonFlat();
            dgvDevolContratos.Style1();
        }

        internal void BtnBuscar_Click(object sender, EventArgs e)
        {
            BuscarDevolucionComision();
            AjusteColumnas();
            RefactoriazarSaldos();
        }

        private void TxtNroContrato_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtNroContrato.TxtContratoFormato();
                BuscarDevolucionComision();
                AjusteColumnas();
                RefactoriazarSaldos();
            }
        }

        private void BuscarDevolucionComision()
        {
            DataTable dt = BLComision.ObtenerDevolucionComisionXContrato(txtNroContrato.Text);
            dgvDevolContratos.DataSource = dt;
            NoModoLecturaColumnas(dt);
        }

        private void NoModoLecturaColumnas(DataTable dt)
        {
            string[] columns = { "IMPORTE_COMISION", "IMP_DSCTADO_ACUMULADO", "SALDO_COMISION_XDESCONTAR" };
            foreach (string column in columns)
            {
                dt.Columns[column].ReadOnly = false;
            }
        }

        private void AjusteColumnas()
        {
            InvisibleColumn();
            InvisibleColumn();
            RenamerHeaderText();
            WithColumn();
            AlignTextContentCell();
            dgvDevolContratos.ColorCabeceraDataGridView(Color.Teal, Color.White);
            dgvDevolContratos.AlingHeaderTextCenter();
        }

        private void InvisibleColumn()
        {
            string[] arrColumns = {
                "COD_MOTIVO_NO_DSCTO", "X", "TIPO_PLANILLA_DEV",
            };

            if (dgvDevolContratos.Columns.Count > 0)
            {
                foreach (string item in arrColumns)
                {
                    dgvDevolContratos.InvisibleColumna2(item);
                }
            }
        }

        private void RenamerHeaderText()
        {
            if (dgvDevolContratos.Columns.Count > 0)
            {
                dgvDevolContratos.Columns["NRO_CONTRATO"].HeaderText = "N° Contrato";
                dgvDevolContratos.Columns["FECHA_CONTRATO"].HeaderText = "Fec.Contrato";
                dgvDevolContratos.Columns["FECHA_APROBACION"].HeaderText = "Fec.Aprob";
                dgvDevolContratos.Columns["CLIENTE"].HeaderText = "Cliente";
                dgvDevolContratos.Columns["TIPO_PLANILLA_DEV"].HeaderText = "Nº Plla. Devoluc.";
                dgvDevolContratos.Columns["FECHA_DEVOLUCION"].HeaderText = "Fec. Plla. Devoluc. Mercadería";
                dgvDevolContratos.Columns["NRO_PLANILLA_DEV"].HeaderText = "Nº Plla. Devoluc. Mercadería";
                dgvDevolContratos.Columns["NIVEL_VENTA"].HeaderText = "Nivel Venta";
                dgvDevolContratos.Columns["DESC_NIVEL_VENTA"].HeaderText = "Nombres Nivel Venta";
                dgvDevolContratos.Columns["NRO_CUOTA"].HeaderText = "N° Cuota Generada";
                dgvDevolContratos.Columns["IMPORTE_COMISION"].HeaderText = "Imp. Comisión Generada";
                dgvDevolContratos.Columns["IMP_DSCTADO_ACUMULADO"].HeaderText = "Imp. Descdo. Acumulado";
                dgvDevolContratos.Columns["IMPORTE_DESCONTAR"].HeaderText = "Imp. a Descontar";
                dgvDevolContratos.Columns["PERIODO_DSCTO"].HeaderText = "Período Dscto";
                dgvDevolContratos.Columns["SALDO_COMISION_XDESCONTAR"].HeaderText = "Saldo por Descontar";
                dgvDevolContratos.Columns["SI_NO_DESCONTAR"].HeaderText = "¿Saldo Comis. se Descontará?";
            }
        }

        private void WithColumn()
        {
            if (dgvDevolContratos.Columns.Count > 0)
            {
                dgvDevolContratos.Columns["NRO_CONTRATO"].Width = 70;
                dgvDevolContratos.Columns["FECHA_CONTRATO"].Width = 70;
                dgvDevolContratos.Columns["FECHA_APROBACION"].Width = 70;
                dgvDevolContratos.Columns["CLIENTE"].Width = 140;
                dgvDevolContratos.Columns["TIPO_PLANILLA_DEV"].Width = 70;
                dgvDevolContratos.Columns["FECHA_DEVOLUCION"].Width = 70;
                dgvDevolContratos.Columns["NRO_PLANILLA_DEV"].Width = 80;
                dgvDevolContratos.Columns["NIVEL_VENTA"].Width = 80;
                dgvDevolContratos.Columns["DESC_NIVEL_VENTA"].Width = 120;
                dgvDevolContratos.Columns["NRO_CUOTA"].Width = 60;
                dgvDevolContratos.Columns["IMPORTE_COMISION"].Width = 70;
                dgvDevolContratos.Columns["IMP_DSCTADO_ACUMULADO"].Width = 70;
                dgvDevolContratos.Columns["IMPORTE_DESCONTAR"].Width = 70;
                dgvDevolContratos.Columns["PERIODO_DSCTO"].Width = 65;
                dgvDevolContratos.Columns["SALDO_COMISION_XDESCONTAR"].Width = 70;
                dgvDevolContratos.Columns["SI_NO_DESCONTAR"].Width = 70;
            }
        }

        private void AlignTextContentCell()
        {
            string[] columnas = { "NRO_CONTRATO", "FECHA_CONTRATO" , "FECHA_APROBACION", "TIPO_PLANILLA_DEV", "FECHA_DEVOLUCION", "NRO_PLANILLA_DEV",
            "PERIODO_DSCTO", "SI_NO_DESCONTAR", "NRO_CUOTA"};
            dgvDevolContratos.ColumnasAlinear(columnas, DataGridViewContentAlignment.MiddleCenter);
            string[] columns2 = { "SALDO_COMISION_XDESCONTAR", "IMP_DSCTADO_ACUMULADO" };
            dgvDevolContratos.ColumnasAlinear(columns2, DataGridViewContentAlignment.MiddleRight);
            dgvDevolContratos.AlignmentDecimalColumns();
        }

        private void RefactoriazarSaldos()
        {
            foreach (DataGridViewRow row in dgvDevolContratos.Rows)
            {
                decimal saldo = row.Cells["IMPORTE_COMISION"].Value.ToDecimal() - row.Cells["IMP_DSCTADO_ACUMULADO"].Value.ToDecimal() - row.Cells["IMPORTE_DESCONTAR"].Value.ToDecimal();
                row.Cells["SALDO_COMISION_XDESCONTAR"].Value = saldo;
            }
        }
    }
}
