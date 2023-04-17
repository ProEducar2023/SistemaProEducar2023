using BLL;
using System;
using System.Windows.Forms;

namespace Presentacion.MOD_CXC
{
    public partial class frm_Consulta_TotalxCobrar_Recepcion_Planilla_Descuento : Form
    {
        decimal sum_descontado_cli = 0, sum_exc_cuota_dev_o_aplic = 0, sum_indebido = 0, sum_exceso_contrato = 0;
        public frm_Consulta_TotalxCobrar_Recepcion_Planilla_Descuento(decimal sum_descontado_cli, decimal sum_exc_cuota_dev_o_aplic, decimal sum_indebido, decimal sum_exceso_contrato)
        {
            InitializeComponent();
            this.sum_descontado_cli = sum_descontado_cli;
            this.sum_exc_cuota_dev_o_aplic = sum_exc_cuota_dev_o_aplic;
            this.sum_indebido = sum_indebido;
            this.sum_exceso_contrato = sum_exceso_contrato;
        }

        private void frm_Consulta_TotalxCobrar_Recepcion_Planilla_Descuento_Load(object sender, EventArgs e)
        {
            txt_tot_descon_clie.Text = sum_descontado_cli.ToString();//descontado
            txt_tot_descon_clie.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(txt_tot_descon_clie.Text);
            txt_tot_exc_dev_apli.Text = sum_exc_cuota_dev_o_aplic.ToString();//exceso cuot x devolver
            txt_tot_exc_dev_apli.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(txt_tot_exc_dev_apli.Text);
            txt_tot_desc_indeb.Text = sum_indebido.ToString();//descuento indebido / exceso contrato
            txt_tot_desc_indeb.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(txt_tot_desc_indeb.Text);
            txt_tot_exc_contrato.Text = sum_exceso_contrato.ToString();
            txt_tot_exc_contrato.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(txt_tot_exc_contrato.Text);
            txt_tot_cobrar.Text = (sum_descontado_cli + sum_exc_cuota_dev_o_aplic + sum_indebido + sum_exceso_contrato).ToString();//descuento indebido / exceso contrato
            txt_tot_cobrar.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(txt_tot_cobrar.Text);
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
