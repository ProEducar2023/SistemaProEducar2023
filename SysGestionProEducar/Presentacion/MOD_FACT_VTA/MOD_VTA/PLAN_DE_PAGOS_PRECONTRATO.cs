using BLL;
using System;
using System.Windows.Forms;
namespace Presentacion.MOD_FACT_VTA.MOD_VTA
{
    public partial class PLAN_DE_PAGOS_PRECONTRATO : Form
    {
        decimal ttotal = 0;
        int NRO_CUOTAS; decimal IMP_CUOTA_INICIAL; decimal IMP_CUOTA_MES; DateTime? FEC_PRIMER_VENC; int NRO_DIAS_VENC; DateTime FEC_CUO_MEN;
        string MES; string AÑO; DateTime FECHA_GRAL;
        public PLAN_DE_PAGOS_PRECONTRATO(decimal ttotal, int NRO_CUOTAS, decimal IMP_CUOTA_INICIAL, decimal IMP_CUOTA_MES,
            DateTime? FEC_PRIMER_VENC, int NRO_DIAS_VENC, DateTime FEC_CUO_MEN, string MES, string AÑO, DateTime FECHA_GRAL)
        {
            InitializeComponent();
            this.ttotal = ttotal;
            this.NRO_CUOTAS = NRO_CUOTAS;
            this.IMP_CUOTA_INICIAL = IMP_CUOTA_INICIAL;
            this.IMP_CUOTA_MES = IMP_CUOTA_MES;
            this.FEC_PRIMER_VENC = FEC_PRIMER_VENC;
            this.NRO_DIAS_VENC = NRO_DIAS_VENC;
            this.FEC_CUO_MEN = FEC_CUO_MEN;
            this.MES = MES;
            this.AÑO = AÑO;
            this.FECHA_GRAL = FECHA_GRAL;
        }
        private void PLAN_DE_PAGOS_PRECONTRATO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }
        private void PLAN_DE_PAGOS_PRECONTRATO_Load(object sender, EventArgs e)
        {
            txt_tot.Text = string.Format("{0:N2}", ttotal);
            txt_ndvcto.Text = NRO_DIAS_VENC.ToString();
            //dtp_vcto.Value = Convert.ToDateTime(DateTime.Now.Day + "/" + MES + "/" + AÑO);
            DateTime fe_plla = DateTime.Now;
            if (DateTime.TryParse((DateTime.Now.Day + "/" + MES + "/" + AÑO), out fe_plla))
                dtp_vcto.Value = Convert.ToDateTime(DateTime.Now.Day + "/" + MES + "/" + AÑO);
            else
                dtp_vcto.Value = FECHA_GRAL;
            if (IMP_CUOTA_MES > 0)
            {
                txt_ci.Text = IMP_CUOTA_INICIAL.ToString();
                dtp_vcto.Value = FEC_PRIMER_VENC.Value;
                txtncuo.Text = NRO_CUOTAS.ToString();
                dtp_fmen.Value = FEC_CUO_MEN;
                txtcuotas.Text = IMP_CUOTA_MES.ToString();
                txtncuo.Focus();
            }
        }

        private void OK_Button_Click(object sender, EventArgs e)
        {
            if (!validaOK())
                return;
            DialogResult = DialogResult.OK;
            this.Hide();
        }
        private bool validaOK()
        {
            bool result = true;
            if (txt_tot.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el Total !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_tot.Focus();
                return result = false;
            }
            if (txtncuo.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el Nro de Cuotas !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtncuo.Focus();
                return result = false;
            }
            if (txt_ndvcto.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el Nro de dias de Vencimiento !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_ndvcto.Focus();
                return result = false;
            }
            if (txtcuotas.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el Monto Cuota x mes !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtcuotas.Focus();
                return result = false;
            }
            return result;
        }
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Dispose();
        }

        private void txt_ndvcto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!validaPlandeCuentas())
                    return;
                calculo_sin_ci();
            }
        }
        private void calculo_sin_ci()
        {
            decimal ncuota = Convert.ToDecimal(txtncuo.Text.Trim());
            decimal ci = txt_ci.Text.Trim() == "" ? 0 : Convert.ToDecimal(txt_ci.Text.Trim());
            txtcuotas.Text = string.Format("{0:N2}", ttotal / ncuota);
            lblsaldo.Text = Convert.ToString(subtotal(ttotal, ci));
        }
        private void calculo_con_ci()
        {
            decimal ncuota = Convert.ToDecimal(txtncuo.Text.Trim());
            decimal ci = txt_ci.Text.Trim() == "" ? 0 : Convert.ToDecimal(txt_ci.Text.Trim());
            txtcuotas.Text = txt_ci.Text.Trim() == "0.00" ? string.Format("{0:N2}", (subtotal(ttotal, ci)) / ncuota) : string.Format("{0:N2}", (subtotal(ttotal, ci)) / (ncuota - 1));
            lblsaldo.Text = Convert.ToString(subtotal(ttotal, ci));
        }
        private decimal subtotal(decimal total, decimal cuoi)
        {
            decimal val = 0;
            val = total - cuoi;
            return val;
        }
        private bool validaPlandeCuentas()
        {
            bool result = true;

            if (txtncuo.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el numero de cuotas !!!", "ADVERTENCIAS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtncuo.Focus();
                return result = false;
            }
            if (txt_ndvcto.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el numero de dias de vencimiento !!!", "ADVERTENCIAS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtncuo.Focus();
                return result = false;
            }
            return result;
        }
        private void dtp_vcto_ValueChanged(object sender, EventArgs e)
        {
            //if (dtp_vcto.Value == DateTimePicker.MinimumDateTime)
            //{
            //    dtp_vcto.Value = DateTime.Now.AddYears(-10);
            //    dtp_vcto.Format = DateTimePickerFormat.Custom;
            //    dtp_vcto.CustomFormat = " ";
            //}
            //else
            //{
            //    dtp_vcto.Format = DateTimePickerFormat.Short;
            //    dtp_fmen.Value = dtp_vcto.Value.AddMonths(1);
            //}
            dtp_fmen.Value = dtp_vcto.Value.AddMonths(1);
        }

        private void txt_ci_Leave(object sender, EventArgs e)
        {
            txt_ci.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(txt_ci.Text);
            dtp_vcto.Focus();
        }

        private void txt_ci_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!validaPlandeCuentas())
                    return;
                calculo_con_ci();
            }
        }

        private void txt_ci_Leave_1(object sender, EventArgs e)
        {
            txt_ci.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(txt_ci.Text);
        }

        private void txtcuotas_Leave(object sender, EventArgs e)
        {
            txtcuotas.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(txtcuotas.Text);
        }

    }
}
