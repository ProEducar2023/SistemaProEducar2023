using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Presentacion.MOD_CXC
{
    public partial class PLANILLA_DESCUENTO_INFORMATIVA : Form
    {
        string AÑO = "", MES = "", COD_MOD = "", COD_USU = "", TIPO_USU = "";
        DateTime FECHA_INI, FECHA_GRAL;
        puntoCobranzaBLL ptoBLL = new puntoCobranzaBLL();
        puntoCobranzaTo ptoTo = new puntoCobranzaTo();
        planillaCabeceraBLL plcBLL = new planillaCabeceraBLL();
        planillaCabeceraTo plcTo = new planillaCabeceraTo();
        public PLANILLA_DESCUENTO_INFORMATIVA(string AÑO, string MES, DateTime FECHA_INI, DateTime FECHA_GRAL, string COD_MOD, string TIPO_USU, string COD_USU)
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

        private void PLANILLA_DESCUENTO_INFORMATIVA_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            CARGAR_INSTITUCIONES();
            CARGAR_CANAL_DSCTO();
        }

        private void PLANILLA_DESCUENTO_INFORMATIVA_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void CARGAR_INSTITUCIONES()
        {
            institucionesBLL insBLL = new institucionesBLL();
            DataTable dtInst = insBLL.obtenerInstitucionesBLL();
            cbo_institucion.ValueMember = "COD_INST";
            cbo_institucion.DisplayMember = "DESC_INST";
            cbo_institucion.DataSource = dtInst;
        }
        private void CARGAR_CANAL_DSCTO()
        {
            canalDescuentoBLL cdscBLL = new canalDescuentoBLL();
            DataTable dt = cdscBLL.ObtenerCanalDescuentoBLL();
            cbo_canal_dscto.ValueMember = "COD_CANAL_DSCTO";
            cbo_canal_dscto.DisplayMember = "DESCRIPCION";
            cbo_canal_dscto.DataSource = dt;
            //cbo_canal_dscto.SelectedIndex = -1;
        }
        private void CARGAR_PTOS_COBRANZA_INFORMATIVOS()
        {
            cbo_pto_cob_inf.DataSource = null;
            ptoTo.STATUS_CONSOLIDADO_INFORMATIVO = true;
            ptoTo.COD_INSTITUCION = cbo_institucion.SelectedValue.ToString();
            DataTable dt = ptoBLL.obtenerPuntosCobranzaConsolidadoInformativo_x_Inst_BLL(ptoTo);
            cbo_pto_cob_inf.ValueMember = "COD_PTO_COB";
            cbo_pto_cob_inf.DisplayMember = "DESC_PTO_COB";
            cbo_pto_cob_inf.DataSource = dt;
        }
        private void cbo_institucion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_institucion.SelectedValue != null)
                CARGAR_PTOS_COBRANZA_INFORMATIVOS();
        }

        private void btn_ejecutar_Click(object sender, EventArgs e)
        {
            plcTo.COD_INSTITUCION = cbo_institucion.SelectedValue.ToString();
            plcTo.COD_CANAL_DSCTO = cbo_canal_dscto.SelectedValue.ToString();
            plcTo.COD_PTO_COB = cbo_pto_cob_inf.SelectedValue.ToString();
            plcTo.FE_AÑO = AÑO;
            plcTo.FE_MES = MES;
            plcTo.TIPO_PLANILLA = "P";
            DataTable dt = plcBLL.obtenerPlanillaInformativaBLL(plcTo);
            if (dt.Rows.Count > 0)
            {
                FolderBrowserDialog ofbd = new FolderBrowserDialog();
                if (ofbd.ShowDialog() == DialogResult.OK)
                {
                    string errMensaje = "";
                    plcTo.DESC_PTO_COB = cbo_pto_cob_inf.Text;

                    if (!plcBLL.generaPlanillaInformativaBLL(plcTo, ofbd.SelectedPath, dt, ref errMensaje))
                        MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        MessageBox.Show("El archivo de Planilla Informativa se generó !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btn_pantalla_Click(object sender, EventArgs e)
        {
            plcTo.COD_INSTITUCION = cbo_institucion.SelectedValue.ToString();
            plcTo.COD_PTO_COB = cbo_pto_cob_inf.SelectedValue.ToString();
            plcTo.COD_CANAL_DSCTO = cbo_canal_dscto.SelectedValue.ToString();
            plcTo.FE_AÑO = AÑO;
            plcTo.FE_MES = MES;
            DataTable dtPlaInf = plcBLL.reportePlanillaInformativaBLL(plcTo);
            if (dtPlaInf.Rows.Count > 0)
            {
                List<planillaDetalleTo> lpld = new List<planillaDetalleTo>();
                foreach (DataRow rw in dtPlaInf.Rows)
                {
                    planillaDetalleTo pld = new planillaDetalleTo();
                    pld.NRO_PLANILLA_COB = rw["NRO_PLANILLA_COB"].ToString();
                    pld.FECHA_PLANILLA_COB = Convert.ToDateTime(rw["FECHA_PLANILLA_COB"]);
                    pld.COD_PTO_COB_CONSOLIDADO = rw["COD_PTO_COB_CONSOLIDADO"].ToString();
                    pld.DESC_PTO_COB = rw["DESC_PTO_COB"].ToString();
                    pld.NRO_CONTRATO = rw["NRO_CONTRATO"].ToString();
                    pld.FECHA_CONTRATO = Convert.ToDateTime(rw["FECHA_CONTRATO"]);
                    pld.COD_PER = rw["COD_PER"].ToString();
                    pld.CLIENTE = rw["CLIENTE"].ToString();
                    pld.DNI = rw["DNI"].ToString();
                    //pld.COD_PTO_VEN = rw["COD_SUB_PTO_VEN"].ToString();
                    //pld.DESC_PTO_VEN = rw["DESC_PTO_VEN"].ToString();
                    pld.IMP_DOC = Convert.ToDecimal(rw["IMP_DOC"]);
                    pld.CUOTA = rw["CUOTA"].ToString();
                    pld.IMP_COB = Convert.ToDecimal(rw["IMP_COB"]);
                    pld.IMP_DEV = Convert.ToDecimal(rw["IMP_DEV"]);
                    //pld.IMP_COB_CTA_CTE = Convert.ToDecimal(rw["IMP_COB_CTA_CTE"]);
                    //pld.CATEGORIA = rw["CATEGORIA"].ToString();
                    //pld.MONTO_RECIBIDO = pld.IMP_COB;
                    //pld.IMP_ENVIO = Convert.ToDecimal(rw["IMP_ENVIO"]);
                    if (pld.COD_PER != "")//esto para que no aprezcan los indebidos en 
                        lpld.Add(pld);

                }
                MOD_CXC.Reportes.FormRep.REP_PLANILLA_DESCUENTO_INFORMATIVA frm = new Reportes.FormRep.REP_PLANILLA_DESCUENTO_INFORMATIVA();
                frm.institucion = cbo_institucion.Text;
                frm.canal_dscto = cbo_canal_dscto.Text;
                frm.pto_cob_consolidado = cbo_pto_cob_inf.Text;
                frm.annio = AÑO;
                frm.mes = HelpersBLL.OBTENER_NOM_MES(MES);
                frm.lstpll = lpld;
                frm.Show();
            }
            else
            {
                MessageBox.Show("No existen datos !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
