using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Presentacion.MOD_FACT_VTA.MOD_VTA.Reportes.FormularioRep
{
    public partial class REPORTE_CONTROL_CALIDAD_CONTRATOS : Form
    {
        precontratoCabeceraBLL pccBLL = new precontratoCabeceraBLL();
        precontratoCabeceraTo pccTo = new precontratoCabeceraTo();
        semanaContratoBLL semBLL = new semanaContratoBLL();
        semanaContratoTo semTo = new semanaContratoTo();
        string MES; string AÑO; DateTime FECHA_GRAL;
        public REPORTE_CONTROL_CALIDAD_CONTRATOS(string MES, string AÑO, DateTime FECHA_GRAL)
        {
            InitializeComponent();
            this.MES = MES;
            this.AÑO = AÑO;
            this.FECHA_GRAL = FECHA_GRAL;
        }

        private void REPORTE_CONTROL_CALIDAD_CONTRATOS_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            CARGAR_PROGRAMAS();
        }
        private void CARGAR_PROGRAMAS()
        {
            programaBLL prgBLL = new programaBLL();
            DataTable dt = prgBLL.obtenerProgramaBLL();
            cboPrograma.ValueMember = "COD_PROGRAMA";
            cboPrograma.DisplayMember = "DESC_PROGRAMA";
            cboPrograma.DataSource = dt;
            cboPrograma.SelectedIndex = 0;
        }

        private void REPORTE_CONTROL_CALIDAD_CONTRATOS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void btn_pantalla2_Click(object sender, EventArgs e)
        {
            pccTo.COD_PROGRAMA = cboPrograma.SelectedValue.ToString();
            pccTo.FECHA_REPORTE_DESDE = dtp_desde.Value.Date;
            pccTo.FECHA_REPORTE_HASTA = dtp_hasta.Value.Date;
            if (rbt_fecha_aprobacion.Checked)
            {
                pccTo.OP_APROB = true;
                pccTo.OP_CONTR = false;
                pccTo.OP_REPO = false;
            }
            else if (rbt_fecha_reporte.Checked)
            {
                pccTo.OP_APROB = false;
                pccTo.OP_CONTR = false;
                pccTo.OP_REPO = true;
            }
            else
            {
                pccTo.OP_APROB = false;
                pccTo.OP_CONTR = true;
                pccTo.OP_REPO = false;
            }
            DataTable dt = pccBLL.obtenerReporteControlCalidadContratoxFechaAprobBLL(pccTo);
            if (dt.Rows.Count > 0)
            {
                List<precontratoCabeceraTo> lpcc = new List<precontratoCabeceraTo>();
                foreach (DataRow rw in dt.Rows)
                {
                    precontratoCabeceraTo pcc = new precontratoCabeceraTo();
                    pcc.NRO_PRESUPUESTO = rw["NRO_PRESUPUESTO"].ToString();
                    pcc.DESC_PER = rw["DESC_PER"].ToString();
                    pcc.FECHA_PRE = Convert.ToDateTime(rw["FECHA_PRE"]);
                    pcc.TOTAL_CONTRATO = Convert.ToDecimal(rw["TOTAL_CONTRATO"]);
                    //pcc.STATUS_APROB = rw["STATUS_APROB"].ToString() == "1" ? "SI" : "NO";
                    pcc.STATUS_APROB = rw["STATUS_APROB"].ToString();
                    pcc.APROB_POR = rw["APROB_POR"].ToString();
                    pcc.FECHA_APROB = rw["FECHA_APROB"].ToString() == "" ? (DateTime?)null : Convert.ToDateTime(rw["FECHA_APROB"]);
                    pcc.NRO_CUOTAS = Convert.ToInt32(rw["NRO_CUOTAS"]);
                    pcc.IMP_CUOTA_INICIAL = Convert.ToDecimal(rw["IMP_CUOTA_INICIAL"]);
                    pcc.FEC_PRIMER_VENC = Convert.ToDateTime(rw["FEC_PRIMER_VENC"]);
                    pcc.IMP_CUOTA_MES = Convert.ToDecimal(rw["IMP_COUTA_MES"]);
                    pcc.FEC_CUO_MEN = Convert.ToDateTime(rw["FEC_CUO_MEN"]);
                    pcc.DESC_ALMACEN = rw["DESC_ALMACEN"].ToString();
                    pcc.VENDEDOR = rw["VENDEDOR"].ToString();
                    pcc.DESC_PTO_COB = rw["DESC_PTO_COB"].ToString();
                    pcc.DESC_PTO_VEN = rw["DESC_PTO_VEN"].ToString();
                    pcc.DIR_DOMI = rw["DIR_DOMI"].ToString();
                    pcc.DIST_DOMI = rw["DIST_DOMI"].ToString();
                    pcc.DEP_DOMI = rw["DEP_DOMI"].ToString();
                    pcc.NRO_FONO = rw["NRO_FONO"].ToString();
                    pcc.DIR_TRABAJO = rw["DIR_TRABAJO"].ToString();
                    pcc.DIST_TRABAJO = rw["DIST_TRABAJO"].ToString();
                    pcc.DEP_TRABAJO = rw["DEP_TRABAJO"].ToString();
                    pcc.TLF_CEL = rw["TLF_CEL"].ToString();
                    pcc.CANAL_DSCTO = rw["CANAL_DSCTO"].ToString();
                    pcc.COND_CLIE = rw["COND_CLIE"].ToString();
                    pcc.DESC_KIT = rw["DESC_KIT"].ToString();
                    pcc.COD_USU_CREA = rw["COD_USU_CREA"].ToString();
                    pcc.FECHA_CREA = Convert.ToDateTime(rw["FECHA_CREA"]);
                    pcc.DESC_PROGRAMA = rw["DESC_PROGRAMA"].ToString();
                    pcc.DIGITADOR = rw["DIGITADOR"].ToString();
                    pcc.NRO_REPORTE = rw["NRO_REPORTE"].ToString();
                    pcc.FEC_REPORTE = Convert.ToDateTime(rw["FEC_REPORTE"]).Date;
                    pcc.NOM_SEMANA = rw["NOM_SEMANA"].ToString();
                    pcc.NRO_REPORTE = rw["NRO_REPORTE"].ToString();
                    pcc.NRO_BENEFICIARIOS = rw["NRO_BENEFICIARIOS"].ToString();
                    pcc.DNI = rw["DNI"].ToString();
                    pcc.DES_IDENTIDAD = rw["DES_IDENTIDAD"].ToString();
                    pcc.DES_PROCESO = rw["DES_PROCESO"].ToString();
                    pcc.USUARIO = rw["USUARIO"].ToString();//usuario web
                    pcc.PASSWORD = rw["PASSWORD"].ToString();
                    lpcc.Add(pcc);
                }
                MOD_VTA.Reportes.FormRep.REP_CONTROL_CALIDAD_CONTRATOS frm = new FormRep.REP_CONTROL_CALIDAD_CONTRATOS();
                frm.programacion = cboPrograma.Text;//dt.Rows[0]["DESC_PROGRAMA"].ToString();
                frm.titulo = "CONTROL DE CALIDAD CONTRATOS";
                if (rbt_fecha_aprobacion.Checked)
                    frm.rango_fechas = "Fecha de Aprobacion Desde " + dtp_desde.Value.ToShortDateString() + " Hasta " + dtp_hasta.Value.ToShortDateString();
                else if (rbt_fecha_contrato.Checked)
                    frm.rango_fechas = "Fecha de Contrato Desde " + dtp_desde.Value.ToShortDateString() + " Hasta " + dtp_hasta.Value.ToShortDateString();
                else if (rbt_fecha_reporte.Checked)
                    frm.rango_fechas = "Fecha de Reporte Desde " + dtp_desde.Value.ToShortDateString() + " Hasta " + dtp_hasta.Value.ToShortDateString();
                frm.lstpcc = lpcc;
                frm.Show();
            }
            else
            {
                MessageBox.Show("No existen datos !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //txt_nro_rep.Focus();
            }
        }

    }
}
