using BLL;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;

namespace Presentacion.MOD_CXC
{
    public partial class CIERRE_DESCUENTO_DIRECTA : Form
    {
        string AÑO, MES, COD_MOD, TIPO_USU, COD_USU, TIPO;
        DateTime FECHA_INI, FECHA_GRAL; DateTime fec_cierre;
        calendarioBLL calBLL = new calendarioBLL();
        calendarioTo calTo = new calendarioTo();
        descuentoDirectoBLL ddBLL = new descuentoDirectoBLL();
        descuentoDirectaTo ddTo = new descuentoDirectaTo();
        public CIERRE_DESCUENTO_DIRECTA(string AÑO, string MES, DateTime FECHA_INI, DateTime FECHA_GRAL, string COD_MOD, string TIPO_USU, string COD_USU, string TIPO)
        {
            InitializeComponent();
            this.AÑO = AÑO;
            this.MES = MES;
            this.FECHA_INI = FECHA_INI;
            this.FECHA_GRAL = FECHA_GRAL;
            this.COD_MOD = COD_MOD;
            this.TIPO_USU = TIPO_USU;
            this.COD_USU = COD_USU;
            this.TIPO = TIPO;
        }

        private void CIERRE_DESCUENTO_DIRECTA_Load(object sender, EventArgs e)
        {
            calTo.TIPO = TIPO;
            fec_cierre = Convert.ToDateTime(calBLL.obtenerFechaActivaBLL(calTo));
            lblfec_cierre.Text = fec_cierre.ToShortDateString();
        }

        private void btn_Cierre_Click(object sender, EventArgs e)
        {
            if (!validaCierre())
                return;
            DialogResult rs = MessageBox.Show("¿ Esta seguro de Cerrar  ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                ddTo.FECHA_LLAMADA = fec_cierre.Date;
                ddTo.COD_USU_MOD = COD_USU;
                ddTo.FECHA_USU_MOD = DateTime.Now;
                if (!ddBLL.cierraDescuentoDirectaBLL(ddTo, ref errMensaje))
                {
                    if (errMensaje == "0000")
                    {
                        MessageBox.Show("No hay Contratos con fecha de Vencimiento " + ddTo.FECHA_LLAMADA.ToShortDateString(), "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    calTo.TIPO = TIPO;
                    fec_cierre = Convert.ToDateTime(calBLL.obtenerFechaActivaBLL(calTo));
                    MessageBox.Show("La planilla se cerro correctamente. \n La nueva fecha activa es " + fec_cierre.ToShortDateString(), "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //DATAGRID();
                    this.Dispose();
                }
            }
        }
        private bool validaCierre()
        {
            bool result = true;
            ddTo.FECHA_LLAMADA = fec_cierre.Date;
            DataTable dtContratos = ddBLL.obtenerContratosparaCierrexFechaActivaBLL(ddTo);
            foreach (DataRow rw in dtContratos.Rows)
            {
                if (rw["COD_MOTIVO_LLAMADA"].ToString() == "")
                {
                    MessageBox.Show("El gestor : " + rw["DESC_PER"] + "\n no ha completado sus llamadas !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return result = false;
                    //break;
                }
                if (Convert.ToDateTime(rw["FECHA_NUEVA_LLAMADA"]) <= fec_cierre.Date)
                {
                    MessageBox.Show("El gestor : " + rw["DESC_PER"] + "\n no ha elegido bien la fecha de Nueva Llamada para \n Contrato : " + rw["NRO_CONTRATO"].ToString() +
                        "\n Cliente : " + rw["CLIENTE"].ToString() + " !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return result = false;
                }
            }
            return result;
        }
    }
}
