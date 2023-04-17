using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Presentacion.MOD_ALM.Reportes.Formulario
{
    public partial class DEVOLUCION_DE_MERCADERIAS : Form
    {
        string AÑO = "", MES = "", COD_MOD = "", COD_USU = "", TIPO_USU = "";
        DateTime FECHA_INI, FECHA_GRAL;
        inventariosBLL invBLL = new inventariosBLL();
        inventariosTo invTo = new inventariosTo();
        public DEVOLUCION_DE_MERCADERIAS(string AÑO, string MES, DateTime FECHA_INI, DateTime FECHA_GRAL, string COD_MOD, string TIPO_USU, string COD_USU)
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
        private void DEVOLUCION_DE_MERCADERIAS_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            CARGAR_PROGRAMAS();
            //dtp_desde.Value = Convert.ToDateTime(DateTime.Now.Day + "/" + FECHA_INI.Month + "/" + FECHA_INI.Year);
            dtp_desde.Value = HelpersBLL.validaFecha(MES, AÑO, FECHA_GRAL);
            //dtp_hasta.Value = Convert.ToDateTime(DateTime.Now.Day + "/" + FECHA_INI.Month + "/" + FECHA_INI.Year);
            dtp_hasta.Value = dtp_desde.Value;
        }
        private void CARGAR_PROGRAMAS()
        {
            programaBLL prgBLL = new programaBLL();
            DataTable dt = prgBLL.obtenerProgramaBLL();
            cbo_prog.ValueMember = "COD_PROGRAMA";
            cbo_prog.DisplayMember = "DESC_PROGRAMA";
            cbo_prog.DataSource = dt;
            cbo_prog.SelectedIndex = 0;
        }
        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btn_pantalla_Click(object sender, EventArgs e)
        {
            invTo.COD_PROGRAMA = cbo_prog.SelectedValue.ToString();
            invTo.FE_DESDE = dtp_desde.Value;
            invTo.FE_HASTA = dtp_hasta.Value;
            DataTable dt = invBLL.obtenerReporteDevolucionMercaderiaBLL(invTo);
            if (dt.Rows.Count > 0)
            {
                List<inventariosTo> linv = new List<inventariosTo>();
                foreach (DataRow rw in dt.Rows)
                {
                    inventariosTo inv = new inventariosTo();
                    inv.NRO_PEDIDO = rw["NRO_PEDIDO"].ToString();
                    inv.FECHA_DOC = Convert.ToDateTime(rw["FECHA_DOC"]);
                    inv.NRO_DOC_INV = rw["NRO_DOC_INV"].ToString();
                    inv.FECHA_DOC_INV = Convert.ToDateTime(rw["FECHA_DOC_INV"]);
                    inv.CONTRATO = rw["NRO_PRESUPUESTO"].ToString();
                    inv.CLIENTE = rw["CLIE"].ToString();
                    inv.VENDEDOR = rw["VEND"].ToString();
                    inv.TOTAL_CONTRATO = Convert.ToDecimal(rw["TOTAL_CONTRATO"]);
                    inv.SALDO2 = Convert.ToDecimal(rw["SALDO"].ToString());
                    inv.DESC_PTO_COB = rw["DESC_PTO_COB"].ToString();
                    inv.FE_CONTRATO = Convert.ToDateTime(rw["FECHA_PRE"]);
                    inv.MOTIVO = rw["MOTIVO"].ToString();
                    linv.Add(inv);
                }
                MOD_ALM.Reportes.FormularioRep.REP_DEVOLUCION_DE_MERCADERIAS frm = new FormularioRep.REP_DEVOLUCION_DE_MERCADERIAS();
                frm.fec_del = dtp_desde.Value.ToShortDateString();
                frm.fec_al = dtp_hasta.Value.ToShortDateString();
                frm.prog = cbo_prog.Text;
                frm.lstinv = linv;
                frm.Show();
            }
            else
            {
                MessageBox.Show("No existen datos !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_prog.Focus();
            }
        }
    }
}
