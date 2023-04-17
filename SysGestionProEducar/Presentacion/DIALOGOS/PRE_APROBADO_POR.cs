using BLL;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;

namespace Presentacion.DIALOGOS
{
    public partial class PRE_APROBADO_POR : Form
    {
        public string a_COD_CLASE3, a_COD_PER3, a_COD_SUCURSAL3, a_NRO_DOC3, AÑO0, MES0;
        DateTime FECHA_INI, FECHA_GRAL;
        string TIPO_USU;
        contratoCabeceraBLL ccBLL = new contratoCabeceraBLL();
        contratoCabeceraTo ccTo = new contratoCabeceraTo();
        public PRE_APROBADO_POR(DateTime FECHA_INI, DateTime FECHA_GRAL, string TIPO_USU)
        {
            InitializeComponent();
            this.FECHA_INI = FECHA_INI;
            this.FECHA_GRAL = FECHA_GRAL;
            this.TIPO_USU = TIPO_USU;
        }
        private void PRE_APROBADO_POR_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            LIMPIAR();
            CARGAR_PERSONAL();
        }
        private void LIMPIAR()
        {
            CBO_PERSONAL1.SelectedIndex = -1;
        }
        private void CARGAR_PERSONAL()
        {
            CBO_PERSONAL1.Items.Clear();
            personaBLL perBLL = new personaBLL();
            DataTable dt = perBLL.obtenerPersonalPedidoBLL();
            CBO_PERSONAL1.ValueMember = "CODIGO";
            CBO_PERSONAL1.DisplayMember = "DESCRIPCION";
            CBO_PERSONAL1.DataSource = dt;
            CBO_PERSONAL1.SelectedIndex = -1;
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            if (!validaCombo())
                return;
            DialogResult rs = MessageBox.Show("¿ Está seguro de Pre-Aprobar el documento ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                ccTo.COD_SUCURSAL = a_COD_SUCURSAL3;
                ccTo.COD_CLASE = a_COD_CLASE3;
                ccTo.COD_PER = a_COD_PER3;
                ccTo.NRO_DOC = a_NRO_DOC3;
                ccTo.FE_AÑO = AÑO0;
                ccTo.FE_MES = MES0;
                ccTo.COD_PER_APROB = CBO_PERSONAL1.SelectedValue.ToString();
                ccTo.FECHA_APROB = DTP_DOC.Value;
                if (!ccBLL.modificaPreApruebaContratoBLL(ccTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("EL Documento se aprobó con éxito !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Dispose();
                }
            }
        }
        private bool validaCombo()
        {
            bool result = true;
            if (CBO_PERSONAL1.SelectedIndex <= -1)
            {
                MessageBox.Show("Debes elegir la persona", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                CBO_PERSONAL1.Focus();
                return result = false;
            }
            //if(DateTime.Compare(DTP_DOC.Value.Date,FECHA_INI.Date) < 0 || DateTime.Compare(DTP_DOC.Value.Date,FECHA_GRAL.Date) > 0)
            //{
            //    MessageBox.Show("EL PRECONTRATO DEBE SER APROBADO ENTRE "+ FECHA_INI.Date + " Y "+ FECHA_GRAL.Date +"", "LA FECHA NO ESTA DENTRO DEL PERIODO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    DTP_DOC.Focus();
            //    return result = false;
            //}

            return result;
        }

        private void BTN_DES_Click(object sender, EventArgs e)
        {
            string errMensaje = "";
            bool flag2 = false;
            if (!VALIDAR_DES(ref flag2, ref errMensaje))
            {
                MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (!flag2)
            {
                MessageBox.Show("Los detalles del Pre-Contrato han sido ingresados parcialmente, no se puede desaprobar !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DESAPRUEBA_CONTRATO(errMensaje);
        }
        private void DESAPRUEBA_CONTRATO(string errMensaje)
        {
            personaBLL perBLL = new personaBLL();
            PRE_DESAPROBADO_POR fdp = new PRE_DESAPROBADO_POR();
            fdp.cboUsuario.Items.Clear();
            fdp.cargar_usuario("VTA");
            if (fdp.ShowDialog() == DialogResult.OK)
            {
                string pass = fdp.txtContraseña.Text;
                string claveEncriptada = HelpersBLL.ENCRIPTAR(pass.ToUpper());
                string codigo = perBLL.ValidarUsuarioEliminacionAnulacionBLL(claveEncriptada, fdp.cboUsuario.Text);
                int RSLT = perBLL.ValidarDirectorioDesaprobarBLL(codigo, "VTA");
                if (RSLT > 0)
                {
                    ccTo.COD_SUCURSAL = a_COD_SUCURSAL3;
                    ccTo.COD_CLASE = a_COD_CLASE3;
                    ccTo.COD_PER = a_COD_PER3;
                    ccTo.NRO_PRESUPUESTO = a_NRO_DOC3;
                    ccTo.FE_AÑO = AÑO0;
                    ccTo.FE_MES = MES0;
                    if (!ccBLL.DESPREAPROBAR_PEDIDOBLL(ccTo, ref errMensaje))
                    {
                        MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        MessageBox.Show("El Contrato se encuentra desaprobado !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Dispose();
                }
                else
                    MessageBox.Show("USTED NO TIENE PERMISOS !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (!ccBLL.DESPREAPROBAR_PEDIDOBLL(ccTo, ref errMensaje))
                {
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("El contrato está desaprobado !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Dispose();
            }
        }
        private bool VALIDAR_DES(ref bool flag2, ref string errMensaje)
        {
            bool result = true;
            ccTo.COD_SUCURSAL = a_COD_SUCURSAL3;
            ccTo.COD_CLASE = a_COD_CLASE3;
            ccTo.COD_PER = a_COD_PER3;
            ccTo.NRO_PRESUPUESTO = a_NRO_DOC3;
            ccTo.FE_AÑO = AÑO0;
            ccTo.FE_MES = MES0;
            if (!ccBLL.VALIDAR_DESPREAPROBAR_CONTRATOBLL(ccTo, ref flag2, ref errMensaje))
                return result = false;
            return result;
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }


    }
}
