using BLL;
using Entidades;
using System;
using System.Windows.Forms;
namespace Presentacion.MOD_CXC
{
    public partial class CIERRE_PLANILLA_DIRECTA : Form
    {
        planillaDirectaBLL pldBLL = new planillaDirectaBLL();
        planillaDirectaTo pldTo = new planillaDirectaTo();
        calendarioBLL calBLL = new calendarioBLL();
        calendarioTo calTo = new calendarioTo();
        string AÑO, MES, COD_MOD, TIPO_USU, COD_USU, TIPO;
        DateTime FECHA_INI, FECHA_GRAL; DateTime fec_cierre;
        public CIERRE_PLANILLA_DIRECTA(string AÑO, string MES, DateTime FECHA_INI, DateTime FECHA_GRAL, string COD_MOD, string TIPO_USU, string COD_USU, string TIPO)
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
        private void CIERRE_PLANILLA_DIRECTA_Load(object sender, EventArgs e)
        {
            calTo.TIPO = TIPO;
            fec_cierre = Convert.ToDateTime(calBLL.obtenerFechaActivaBLL(calTo));
            lblfec_cierre.Text = fec_cierre.ToShortDateString();
        }
        private void btn_Cierre_Click(object sender, EventArgs e)
        {
            if (!validaCierre())
                return;
            DialogResult rs = MessageBox.Show("¿ Esta seguro de Cerrar la Planilla,\n Primero se debe de crear los Reportes del dia ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                //pldTo.FECHA_VEN = DateTime.Now.AddMonths(6);
                pldTo.FECHA_VEN = fec_cierre;
                pldTo.FECHA_LLAMADA = fec_cierre.Date;
                pldTo.COD_CREACION = COD_USU;
                pldTo.FECHA_CREACION = DateTime.Now;
                pldTo.TIPO = TIPO;
                if (!pldBLL.cierraPlanillaDirectaBLL(pldTo, ref errMensaje))
                {
                    if (errMensaje == "0000")
                    {
                        MessageBox.Show("No hay Contratos con fecha de Vencimiento " + pldTo.FECHA_VEN.ToShortDateString(), "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            return true;
        }


    }
}
