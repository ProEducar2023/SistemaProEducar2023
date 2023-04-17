using BLL;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;

namespace Presentacion.MOD_ADM
{
    public partial class SALDO_INICIAL : Form
    {
        string AÑO = "", MES = "", COD_MOD = "", COD_USU = "", TIPO_USU = "";
        DateTime FECHA_INI, FECHA_GRAL;
        HelpersBLL helBLL = new HelpersBLL();
        HelpersTo helTo = new HelpersTo();
        public SALDO_INICIAL(string AÑO, string MES, DateTime FECHA_INI, DateTime FECHA_GRAL, string COD_MOD, string TIPO_USU, string COD_USU)
        {
            InitializeComponent();
            this.AÑO = AÑO;
            this.MES = MES;
            this.FECHA_INI = FECHA_INI;
            this.FECHA_GRAL = FECHA_GRAL;
            this.COD_MOD = COD_MOD;
            this.TIPO_USU = TIPO_USU;
            this.COD_USU = COD_USU;
        }

        private void SALDO_INICIAL_Load(object sender, EventArgs e)
        {
            cbo_año.Text = (DateTime.Now.Year - 1).ToString();
            cbo_año2.Text = (DateTime.Now.Year - 1).ToString();
            cbo_año21.Text = (DateTime.Now.Year - 1).ToString();
            cbo_año22.Text = (DateTime.Now.Year - 1).ToString();
            CARGAR_CLASE();
            CARGAR_SUCURSAL();
        }
        private void CARGAR_SUCURSAL()
        {
            helTo.CODIGO = COD_USU;
            DataTable dt = helBLL.CBO_SUCURSALBLL(helTo);
            cbo_sucursal.ValueMember = "COD_SUCURSAL";
            cbo_sucursal.DisplayMember = "DESC_sucursal";
            cbo_sucursal.DataSource = dt;
            cbo_sucursal.SelectedIndex = -1;
            //
            cbo_sucursal1.ValueMember = "COD_SUCURSAL";
            cbo_sucursal1.DisplayMember = "DESC_sucursal";
            cbo_sucursal1.DataSource = dt;
            cbo_sucursal1.SelectedIndex = -1;
        }
        private void CARGAR_CLASE()
        {
            DataTable DT = new DataTable();
            claseBLL clsBLL = new claseBLL();
            DT = clsBLL.obtenerClaseArticuloparaGrupoBLL();
            if (DT.Rows.Count > 0)
            {
                cbo_clase1.DataSource = DT;
                cbo_clase1.DisplayMember = "DESC_CLASE";
                cbo_clase1.ValueMember = "COD_CLASE";
                cbo_clase1.SelectedIndex = -1;

                cbo_clase2.DataSource = DT;
                cbo_clase2.DisplayMember = "DESC_CLASE";
                cbo_clase2.ValueMember = "COD_CLASE";
                cbo_clase2.SelectedIndex = -1;
            }

        }

        private void btn_pucallpa_Click(object sender, EventArgs e)
        {
            if (!validaSaldoIni1())
                return;

            DialogResult rs = MessageBox.Show("¿ Esta seguro de Grabar ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                iCostosBLL cosBLL = new iCostosBLL();
                iCostosTo cosTo = new iCostosTo();
                cosTo.FE_AÑO = cbo_año.Text;
                cosTo.FE_AÑO2 = cbo_año2.Text;
                cosTo.FE_MES = "12";
                cosTo.COD_PER = "00000";
                cosTo.COD_CLASE = cbo_clase1.SelectedValue.ToString();
                cosTo.COD_SUCURSAL = cbo_sucursal.SelectedValue.ToString();
                if (!cosBLL.creaSaldoInicialBLL(cosTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Se guardó exitosamente !!!", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
        }
        private bool validaSaldoIni1()
        {
            bool result = true;
            if (cbo_clase1.SelectedIndex <= -1)
            {
                MessageBox.Show("Elija la clase !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_clase1.Focus();
                return result = false;
            }
            return result;
        }
        private bool validaSaldoIni2()
        {
            bool result = true;
            if (cbo_clase2.SelectedIndex <= -1)
            {
                MessageBox.Show("Elija la clase !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_clase2.Focus();
                return result = false;
            }
            return result;
        }

        private void btn_des_Click(object sender, EventArgs e)
        {
            if (!validaSaldoIni2())
                return;

            DialogResult rs = MessageBox.Show("¿ Esta seguro de DesTransferir ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                iCostosBLL cosBLL = new iCostosBLL();
                iCostosTo cosTo = new iCostosTo();
                cosTo.FE_AÑO = cbo_año21.Text;
                cosTo.FE_AÑO2 = cbo_año22.Text;
                cosTo.FE_MES = "12";
                cosTo.COD_PER = "00000";
                cosTo.COD_CLASE = cbo_clase2.SelectedValue.ToString();
                cosTo.COD_SUCURSAL = cbo_sucursal1.SelectedValue.ToString();
                if (!cosBLL.descreaSaldoInicialBLL(cosTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Operación ejecutada exitosamente !!!", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
        }

        private void BTN_SALIR_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btn_sal2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
