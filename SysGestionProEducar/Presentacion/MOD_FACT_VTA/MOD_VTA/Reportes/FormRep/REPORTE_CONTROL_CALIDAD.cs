using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Presentacion.MOD_FACT_VTA.MOD_VTA.Reportes.FormRep
{
    public partial class REPORTE_CONTROL_CALIDAD : Form
    {
        precontratoCabeceraBLL pccBLL = new precontratoCabeceraBLL();
        precontratoCabeceraTo pccTo = new precontratoCabeceraTo();
        semanaContratoBLL semBLL = new semanaContratoBLL();
        semanaContratoTo semTo = new semanaContratoTo();
        string MES; string AÑO; DateTime FECHA_GRAL;
        public REPORTE_CONTROL_CALIDAD(string MES, string AÑO, DateTime FECHA_GRAL)
        {
            InitializeComponent();
            this.MES = MES;
            this.AÑO = AÑO;
            this.FECHA_GRAL = FECHA_GRAL;
        }

        private void REPORTE_CONTROL_CALIDAD_Load(object sender, EventArgs e)
        {
            //dtp_desde_fr.Value = Convert.ToDateTime(DateTime.Now.Day + "/" + MES + "/" + AÑO);
            //dtp_hasta_fr.Value = Convert.ToDateTime(DateTime.Now.Day + "/" + MES + "/" + AÑO);
            this.KeyPreview = true;
            dtp_desde_fr.Value = HelpersBLL.validaFecha(MES, AÑO, FECHA_GRAL);
            dtp_hasta_fr.Value = dtp_desde_fr.Value;//HelpersBLL.validaFecha(MES, AÑO, FECHA_GRAL);
            dtp_fecha_desde_contrato.Value = HelpersBLL.validaFecha(MES, AÑO, FECHA_GRAL);
            dtp_fecha_hasta_contrato.Value = dtp_fecha_desde_contrato.Value;
            CARGAR_PROGRAMAS();
            CARGAR_PROGRAMAS_X_PERIODO();
            llenacomboMes();
            llenacomboAnnio();
            rbt_fecha_reporte.Checked = true;
            rbt_fecha_contrato.Checked = false;
            dtp_fecha_desde_contrato.Enabled = false;
            dtp_fecha_hasta_contrato.Enabled = false;
            obtenerSemanaContrato();
            txt_nro_rep.Focus();
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
        private void CARGAR_PROGRAMAS_X_PERIODO()
        {
            programaBLL prgBLL = new programaBLL();
            DataTable dt = prgBLL.obtenerProgramaBLL();
            cboProgramaxPeriodo.ValueMember = "COD_PROGRAMA";
            cboProgramaxPeriodo.DisplayMember = "DESC_PROGRAMA";
            cboProgramaxPeriodo.DataSource = dt;
            cboProgramaxPeriodo.SelectedIndex = 0;
        }
        private void REPORTE_CONTROL_CALIDAD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }
        private void llenacomboMes()
        {
            cbo_ini_mes.ValueMember = "cod";
            cbo_ini_mes.DisplayMember = "nom";
            cbo_ini_mes.DataSource = HelpersBLL.OBTENER_MESES();
            cbo_ini_mes.SelectedValue = MES;
        }
        private void llenacomboAnnio()
        {
            cbo_ini_annio.ValueMember = "cod";
            cbo_ini_annio.DisplayMember = "nom";
            cbo_ini_annio.DataSource = HelpersBLL.OBTENER_AÑOS();
            cbo_ini_annio.SelectedValue = AÑO;
        }
        private bool validaPantalla()
        {
            bool result = true;
            if (txt_nro_rep.Text == "" && txt_nro_con.Text == "")
            {
                MessageBox.Show("Ingres alguna entrada !!!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_nro_rep.Focus();
                return result = false;
            }
            return result;
        }
        private void btn_pantalla_Click(object sender, EventArgs e)
        {
            if (!validaPantalla())
                return;
            pccTo.NRO_REPORTE = txt_nro_rep.Text == "" ? null : txt_nro_rep.Text.Trim();
            pccTo.NRO_PRESUPUESTO = txt_nro_con.Text == "" ? null : txt_nro_con.Text.Trim();
            DataTable dt = pccBLL.obtenerReporteControlCalidadBLL(pccTo);
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
                    pcc.IMP_CUOTA_MES = Convert.ToDecimal(rw["IMP_CUOTA_MES"]);
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
                    pcc.FEC_REPORTE = Convert.ToDateTime(rw["FEC_REPORTE"]);
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
                REP_CONTROL_CALIDAD frm = new REP_CONTROL_CALIDAD();
                frm.nro_rep = dt.Rows[0]["NRO_REPORTE"].ToString();//txt_nro_rep.Text;
                //frm.nro_con = txt_nro_con.Text;
                frm.digitado_por = dt.Rows[0]["DIGITADOR"].ToString();
                frm.fec_digitador = dt.Rows[0]["FECHA_CREA"].ToString().Substring(0, 10);
                frm.programacion = dt.Rows[0]["DESC_PROGRAMA"].ToString();
                frm.fec_reporte = dt.Rows[0]["FEC_REPORTE"].ToString().Substring(0, 10);
                frm.sem_reporte = dt.Rows[0]["NOM_SEMANA"].ToString();
                frm.lstpcc = lpcc;
                frm.Show();
            }
            else
            {
                MessageBox.Show("No existen datos !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_nro_rep.Focus();
            }
        }

        private void txt_nro_rep_Leave(object sender, EventArgs e)
        {
            if (txt_nro_rep.Text != "")
                txt_nro_rep.Text = txt_nro_rep.Text.PadLeft(6, '0');
            //if (txt_nro_rep.Text == "000000")
            //    txt_nro_rep.Text = "";
        }

        private void txt_nro_con_Leave(object sender, EventArgs e)
        {
            if (txt_nro_con.Text != "")
                txt_nro_con.Text = txt_nro_con.Text.PadLeft(7, '0');
            //if (txt_nro_con.Text == "0000000")
            //    txt_nro_con.Text = "";
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void REPORTE_CONTROL_CALIDAD_Shown(object sender, EventArgs e)
        {
            txt_nro_rep.Focus();
        }

        private void btn_pantalla2_Click(object sender, EventArgs e)
        {
            pccTo.STATUS_REPORTE = rbt_fecha_reporte.Checked;
            pccTo.FECHA_REPORTE_DESDE = dtp_desde_fr.Value.Date;
            pccTo.FECHA_REPORTE_HASTA = dtp_hasta_fr.Value.Date;
            pccTo.STATUS_CONTRATO = rbt_fecha_contrato.Checked;
            pccTo.FECHA_CONTRATO_DESDE = dtp_fecha_desde_contrato.Value.Date;
            pccTo.FECHA_CONTRATO_HASTA = dtp_fecha_hasta_contrato.Value.Date;
            pccTo.COD_PROGRAMA = cboPrograma.SelectedValue.ToString();
            DataTable dt = pccBLL.obtenerReporteControlCalidadxFechaReporteBLL(pccTo);
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
                    pcc.IMP_CUOTA_MES = Convert.ToDecimal(rw["IMP_CUOTA_MES"]);
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
                REP_CONTROL_CALIDAD_X_FECHAS frm = new REP_CONTROL_CALIDAD_X_FECHAS();
                frm.programacion = cboPrograma.Text;//dt.Rows[0]["DESC_PROGRAMA"].ToString();
                frm.titulo = rbt_fecha_reporte.Checked ? "CONTROL DE CALIDAD POR FECHA DE REPORTE" : "CONTROL DE CALIDAD POR FECHA DE CONTRATO";
                frm.rango_fechas = rbt_fecha_reporte.Checked ? "Fecha de Reporte Desde : " + dtp_desde_fr.Value.ToShortDateString() + " Hasta : " + dtp_hasta_fr.Value.ToShortDateString() :
                    "Fecha de Contrato Desde : " + dtp_fecha_desde_contrato.Value.ToShortDateString() + " Hasta : " + dtp_fecha_hasta_contrato.Value.ToShortDateString();
                frm.lstpcc = lpcc;
                frm.Show();
            }
            else
            {
                MessageBox.Show("No existen datos !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_nro_rep.Focus();
            }
        }

        private void btn_salir2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btn_pantalla3_Click(object sender, EventArgs e)
        {
            pccTo.FE_MES = cbo_ini_mes.SelectedValue.ToString();
            pccTo.FE_AÑO = cbo_ini_annio.SelectedValue.ToString();
            pccTo.COD_PROGRAMA = cboProgramaxPeriodo.SelectedValue.ToString();
            pccTo.NRO_SEMANA = cbo_semana.SelectedValue.ToString() == "0" ? null : cbo_semana.SelectedValue.ToString();
            DataTable dt = pccBLL.obtenerReporteControlCalidadxPeriodo_y_Semana_ContratoBLL(pccTo);
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
                    pcc.IMP_CUOTA_MES = Convert.ToDecimal(rw["IMP_CUOTA_MES"]);
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
                REP_CONTROL_CALIDAD_X_PERIODO_Y_SEMANA_CONTRATO frm = new REP_CONTROL_CALIDAD_X_PERIODO_Y_SEMANA_CONTRATO();
                frm.programa = cboProgramaxPeriodo.Text;//dt.Rows[0]["DESC_PROGRAMA"].ToString();
                frm.periodo = "PERIODO " + cbo_ini_mes.Text + " " + cbo_ini_annio.Text;
                frm.semana = "SEMANA   " + cbo_semana.Text;
                frm.lstpcc = lpcc;
                frm.Show();
            }
            else
            {
                MesangeNoExiste();
            }
        }
        private void MesangeNoExiste()
        {
            MessageBox.Show("No existen datos !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            txt_nro_rep.Focus();
        }
        private void btn_salir3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void rbt_fecha_reporte_CheckedChanged(object sender, EventArgs e)
        {
            dtp_fecha_desde_contrato.Enabled = false;
            dtp_fecha_hasta_contrato.Enabled = false;
            dtp_desde_fr.Enabled = true;
            dtp_hasta_fr.Enabled = true;
        }

        private void rbt_fecha_contrato_CheckedChanged(object sender, EventArgs e)
        {
            dtp_desde_fr.Enabled = false;
            dtp_hasta_fr.Enabled = false;
            dtp_fecha_desde_contrato.Enabled = true;
            dtp_fecha_hasta_contrato.Enabled = true;
        }

        private void cbo_ini_mes_SelectionChangeCommitted(object sender, EventArgs e)
        {
            obtenerSemanaContrato();
        }

        private void cbo_ini_annio_SelectionChangeCommitted(object sender, EventArgs e)
        {
            obtenerSemanaContrato();
        }
        private void obtenerSemanaContrato()
        {
            if (cbo_ini_mes.SelectedValue != null && cbo_ini_annio.SelectedValue != null)
            {
                semTo.FE_MES = cbo_ini_mes.SelectedValue.ToString();
                semTo.FE_AÑO = cbo_ini_annio.SelectedValue.ToString();
                DataTable dt = semBLL.obtenerSemanaContratoparaPreventaBLL(semTo);
                if (dt.Rows.Count > 0)
                {
                    DataRow rw = dt.NewRow();
                    rw["NRO_SEMANA"] = "0";
                    rw["NOM_SEMANA"] = "TODAS";
                    dt.Rows.InsertAt(rw, 0);
                    cbo_semana.ValueMember = "NRO_SEMANA";
                    cbo_semana.DisplayMember = "NOM_SEMANA";
                    cbo_semana.DataSource = dt;
                }


            }
        }

        private void btn_impresion_Click(object sender, EventArgs e)
        {

        }
    }
}
