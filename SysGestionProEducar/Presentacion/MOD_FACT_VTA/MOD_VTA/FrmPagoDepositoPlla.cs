using BLL;
using System;
using System.Data;
using System.Windows.Forms;

namespace Presentacion.MOD_FACT_VTA.MOD_VTA
{
    public partial class FrmPagoDepositoPlla : UserControl
    {
        private readonly int idDeposito;
        private readonly int idSeguimiento;
        public FrmPagoDepositoPlla(int idSeguimiento, int idDeposito)
        {
            InitializeComponent();
            this.idDeposito = idDeposito;
            this.idSeguimiento = idSeguimiento;
        }

        private static readonly ChequeBLL BLCheque = new ChequeBLL();
        private static readonly MaestroBancoBLL BLMaestroBanco = new MaestroBancoBLL();
        private static readonly TipoMonedaBLL BLTipoMoneda = new TipoMonedaBLL();

        private void FrmPagoDepositoPlla_Load(object sender, EventArgs e)
        {
            StartControls();
            CargarBanco();
            CargarTipoMoneda();
            MostrarDatosDeposito();
        }

        private void StartControls()
        {
            ControlesModoLectura(this);
            ControlesModoLectura(groupBox7);
            ControlesModoLectura(gbVerficacion1);
            FormatDecimal(numImporteDep1);
            FormatDecimal(numImpVer1);
            FormatDecimal(numDiferencia1);
            cboBancoDep1.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMonedaDep1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void FormatDecimal(NumericUpDown numeric)
        {
            numeric.DecimalPlaces = 2;
            numeric.Maximum = decimal.MaxValue;
            numeric.ThousandsSeparator = true;
            numeric.Increment = 0;
        }

        private void CargarBanco()
        {
            DataTable dt = BLMaestroBanco.ListarMaestroBanco();

            cboBancoDep1.ValueMember = "codigo";
            cboBancoDep1.DisplayMember = "Descripcion";
            cboBancoDep1.DataSource = dt;
        }

        private void CargarTipoMoneda()
        {
            DataTable dt = BLTipoMoneda.ListaMoneda();
            cboMonedaDep1.DataSource = dt;
            cboMonedaDep1.DisplayMember = "Desc_moneda";
            cboMonedaDep1.ValueMember = "IdMoneda";
        }

        private void MostrarDatosDeposito()
        {
            DataTable dtDeposito = BLCheque.ObtenerDespositoChequeXIdSeguimiento(idSeguimiento, idDeposito);
            if (dtDeposito == null || dtDeposito.Rows.Count == 0)
            {
                _ = MessageBox.Show("Error al buscar el depósito", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dtFechaDep1.Value = Convert.ToDateTime(dtDeposito.Rows[0]["FECHA"]);
            cboBancoDep1.SelectedValue = dtDeposito.Rows[0]["COD_BANCO"];
            txtNroOperacionDep1.Text = dtDeposito.Rows[0]["NRO_OPERACION"].ToString();
            cboMonedaDep1.SelectedValue = dtDeposito.Rows[0]["ID_MONEDA"];
            numImporteDep1.Value = Convert.ToDecimal(dtDeposito.Rows[0]["IMPORTE"]);
            txtRepresentateDep1.Text = dtDeposito.Rows[0]["REPRESENTANTE"].ToString();
            txtObservacionDep1.Text = dtDeposito.Rows[0]["OBSERVACION"].ToString();
            numImpVer1.Value = string.IsNullOrEmpty(dtDeposito.Rows[0]["IMPORTE_VERIFICADO"].ToString()) ? 0 : Convert.ToDecimal(dtDeposito.Rows[0]["IMPORTE_VERIFICADO"]);
            chkSi1.Checked = numImporteDep1.Value == numImpVer1.Value;
            chkNo1.Checked = numImporteDep1.Value != numImpVer1.Value;
        }

        private void CboBancoDep1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboBancoDep1.DataSource != null)
            {
                DataTable dt = BLMaestroBanco.ObtenerMaestroBancoXCodBanco(cboBancoDep1.SelectedValue.ToString());
                txtNroCuentaDep1.Text = dt.Rows[0]["NROCUENTA"].ToString();
                cboMonedaDep1.SelectedValue = Convert.ToInt32(dt.Rows[0]["IdMoneda"]);
            }
        }

        private void ControlesModoLectura(Control control)
        {
            foreach(Control item in control.Controls)
            {
                if (item is TextBox text)
                    text.ReadOnly = true;
                if (item is ComboBox rad)
                    rad.Enabled = false;
                if (item is NumericUpDown num)
                    num.ReadOnly = true;
            }
        }

        private void groupBox7_Enter(object sender, EventArgs e)
        {

        }

        private void txtObservacionDep1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
