using BLL;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;

namespace Presentacion.MOD_ADM
{
    public partial class CIERRE_AÑO : Form
    {
        periodoBLL perBLL = new periodoBLL();
        periodoTo perTo = new periodoTo();
        string AÑO00, MES00;
        public CIERRE_AÑO()
        {
            InitializeComponent();
        }

        private void CIERRE_AÑO_Load(object sender, EventArgs e)
        {
            string errMensaje = "";
            string cod_modulo = "COS";
            if (!MOSTRAR_FECHA(cod_modulo, ref errMensaje))
            {
                if (errMensaje != "")
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Verifique los datos del periodo activo.\nVuelva a intentarlo.", "Cierre de año.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    GroupBox1.Enabled = false;
                }
            }
            else
            {
                DataTable dt = perBLL.MOSTRAR_ACTIVO_BLL(cod_modulo);
                if (dt.Rows.Count > 0)
                {
                    AÑO00 = dt.Rows[0]["AÑO"].ToString();
                    MES00 = dt.Rows[0]["MES"].ToString();
                }
            }
        }
        private bool MOSTRAR_FECHA(string cod_modulo, ref string errMensaje)
        {
            bool result = true;
            perTo.COD_MODULO = cod_modulo;
            if (!perBLL.verificaFechaParaCierreAñoBLL(perTo, ref errMensaje))
                return result = false;
            return result;
        }

        private void btn_Cerrar_Click(object sender, EventArgs e)
        {
            if (!validaCerrar())
                return;

            DialogResult rs = MessageBox.Show("Se va a cerrar el año " + AÑO00 + "\n¿Está ud. de acuerdo?.", "Cierre de año.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;

                perTo.AÑO = AÑO00;
                if (!perBLL.cerrarCierreAñoBLL(perTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "Cierre de año", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("El cierre de año se realizó correctamente. !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private bool validaCerrar()
        {
            bool result = true;
            string errMensaje = "";
            if (MES00 != "12")
            {
                MessageBox.Show("El cierre se debe efectuar al final del periodo(Diciembre).\nVuelva a intentarlo.", "Cierre de año", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return result = false;
            }
            if (!VERIFICAR_CIERRE_PERIODO(AÑO00, "12", "COS", ref errMensaje))
            {
                if (errMensaje != "")
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Verifique el cierre mensual para el mes de Diciembre. \nVuelva a intentarlo.", "Cierre de año.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return result = false;
                }
            }
            return result;
        }
        private bool VERIFICAR_CIERRE_PERIODO(string AÑO0, string MES0, string MOD0, ref string errMensaje)
        {
            bool result = true;
            perTo.AÑO = AÑO0;
            perTo.MES = MES0;
            perTo.COD_MODULO = MOD0;
            if (!perBLL.VERIFICAR_CIERRE_PERIODO_BLL(perTo, ref errMensaje))
                return result = false;
            return result;
        }

        private void BTN_CIERRE2_Click(object sender, EventArgs e)
        {
            if (!cancelarCierre())
                return;

            DialogResult rs = MessageBox.Show("Se va a cancelar el cierre del año " + AÑO00 + "\n¿Está ud. de acuerdo?.", "Cierre de año.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;

                perTo.AÑO = AÑO00;
                if (!perBLL.regresarCierreAñoBLL(perTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "Cierre de año", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("El cancelación de año se realizó correctamente. !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private bool cancelarCierre()
        {
            bool result = true;
            if (MES00 != "12")
            {
                MessageBox.Show("La cancelación se debe efectuar al final del periodo(Diciembre).\nVuelva a intentarlo.", "Cierre de año", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return result = false;
            }
            return result;
        }

        private void BTN_SALIR_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
