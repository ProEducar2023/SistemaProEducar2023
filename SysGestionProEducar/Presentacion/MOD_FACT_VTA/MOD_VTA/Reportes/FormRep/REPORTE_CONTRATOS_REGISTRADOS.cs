using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Presentacion.MOD_FACT_VTA.MOD_VTA.Reportes.FormRep
{
    public partial class REPORTE_CONTRATOS_REGISTRADOS : Form
    {
        semanaContratoBLL semBLL = new semanaContratoBLL();
        semanaContratoTo semTo = new semanaContratoTo();
        contratoCabeceraBLL ccBLL = new contratoCabeceraBLL();
        contratoCabeceraTo ccTo = new contratoCabeceraTo();
        puntoCobranzaBLL pcBLL = new puntoCobranzaBLL();
        puntoCobranzaTo pcTo = new puntoCobranzaTo();
        DataTable dtPtoCob;
        public REPORTE_CONTRATOS_REGISTRADOS()
        {
            InitializeComponent();
        }

        private void REPORTE_CONTRATOS_REGISTRADOS_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            llenacomboMes();
            llenacomboAnnio();
            cargaInstituciones();
        }
        private void llenacomboMes()
        {
            cbomes.ValueMember = "cod";
            cbomes.DisplayMember = "nom";
            cbomes.DataSource = HelpersBLL.OBTENER_MESES();
        }
        private void llenacomboAnnio()
        {
            cboannio.ValueMember = "cod";
            cboannio.DisplayMember = "nom";
            cboannio.DataSource = HelpersBLL.OBTENER_AÑOS();
        }

        private void REPORTE_CONTRATOS_REGISTRADOS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void cbomes_SelectedIndexChanged(object sender, EventArgs e)
        {
            obtenerSemanaContrato();
        }
        private void obtenerSemanaContrato()
        {
            if (cbomes.SelectedValue != null && cboannio.SelectedValue != null)
            {
                semTo.FE_MES = cbomes.SelectedValue.ToString();
                semTo.FE_AÑO = cboannio.SelectedValue.ToString();
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
        private void cargaInstituciones()
        {
            institucionesBLL insBLL = new institucionesBLL();
            DataTable dtInstitucion = insBLL.obtenerInstitucionesBLL();

            cbo_institucion.ValueMember = "COD_INST";
            cbo_institucion.DisplayMember = "DESC_INST";
            cbo_institucion.DataSource = dtInstitucion;
        }
        private void cboannio_SelectedIndexChanged(object sender, EventArgs e)
        {
            obtenerSemanaContrato();
        }

        private void BTN_SALIR_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btn_pantalla1_Click(object sender, EventArgs e)
        {
            //bool val = false; 
            DataTable dt = null;
            ccTo.COD_INSTITUCION = cbo_institucion.SelectedValue.ToString();
            ccTo.COD_PTO_COB = cbo_cobranza.SelectedValue.ToString() != "0" ? cbo_cobranza.SelectedValue.ToString() : null;
            ccTo.FE_AÑO = cboannio.SelectedValue.ToString();
            ccTo.FE_MES = cbomes.SelectedValue.ToString();
            ccTo.NRO_SEMANA = cbo_semana.SelectedValue.ToString() != "0" ? cbo_semana.SelectedValue.ToString() : null;
            //DataRow[] rs = dtPtoCob.Select("COD_PTO_COB='" + cbo_cobranza.SelectedValue.ToString() + "'");
            //foreach (DataRow r in rs)
            //    val = Convert.ToBoolean(r["STATUS_CONSOLIDADO"]);
            //if (val)
            //    dt = ccBLL.repContratosRegistrados_x_PtoCons_BLL(ccTo);
            //else
            //    dt = ccBLL.repContratosRegistradosBLL(ccTo);
            dt = ccBLL.repContratosRegistradosBLL(ccTo);
            if (dt.Rows.Count > 0)
            {
                List<contratoCabeceraTo> lcc = new List<contratoCabeceraTo>();
                foreach (DataRow rw in dt.Rows)
                {
                    contratoCabeceraTo cc = new contratoCabeceraTo();
                    cc.NroOrden = rw["NroOrden"].ToString().PadLeft(2, '0');
                    cc.NRO_PRESUPUESTO = rw["NRO_PRESUPUESTO"].ToString();
                    cc.FECHA_PRE = Convert.ToDateTime(rw["FECHA_PRE"]);
                    cc.DESC_PTO_COB = rw["DESC_PTO_COB"].ToString();
                    cc.DESC_PTO_VEN = rw["DESC_PTO_VEN"].ToString();
                    cc.NOM_CLI = rw["NOM_CLI"].ToString();
                    cc.TOTAL_CONTRATO = Convert.ToDecimal(rw["TOTAL_CONTRATO"]);
                    cc.FEC_PRIMER_VENC = Convert.ToDateTime(rw["FEC_PRIMER_VENC"]);
                    cc.IMP_CUOTA_INICIAL = Convert.ToDecimal(rw["IMP_CUOTA_INICIAL"]);
                    cc.FEC_CUO_MEN = Convert.ToDateTime(rw["FEC_CUO_MEN"]);
                    cc.IMP_CUOTA_MES = Convert.ToDecimal(rw["IMP_COUTA_MES"]);
                    cc.NOM_VEN = rw["NOM_VEN"].ToString();
                    cc.NRO_CUOTAS = Convert.ToInt32(rw["NRO_CUOTAS"]);
                    cc.DESC_LUG_VTA = rw["DESC_LUG_VTA"].ToString();
                    cc.NRO_REPORTE = rw["NRO_REPORTE"].ToString();
                    cc.DES_IDENTIDAD = rw["DES_IDENTIDAD"].ToString();
                    cc.DES_PROCESO = rw["DES_PROCESO"].ToString();
                    lcc.Add(cc);
                }
                REP_CONTRATOS_REGISTRADOS frm = new REP_CONTRATOS_REGISTRADOS();
                frm.Institucion = cbo_institucion.Text;
                frm.Nom_semana = cbo_semana.Text;
                frm.Periodo = cbomes.Text + " " + cboannio.Text;
                frm.lstcc = lcc;
                frm.Show();
            }
            else
            {
                MessageBox.Show("No existen datos !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_cobranza.Focus();
            }
        }


        private void cbo_institucion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_institucion.SelectedValue != null)
            {
                pcTo.COD_INSTITUCION = cbo_institucion.SelectedValue.ToString();
                pcTo.STATUS_CONSOLIDADO = null;
                dtPtoCob = pcBLL.obtenerPuntosCobranza_x_Inst_BLL(pcTo);
                if (dtPtoCob.Rows.Count > 0)
                {
                    DataRow rw = dtPtoCob.NewRow();
                    rw["COD_PTO_COB"] = "0";
                    rw["DESC_PTO_COB"] = "TODOS";
                    dtPtoCob.Rows.InsertAt(rw, 0);
                    cbo_cobranza.ValueMember = "COD_PTO_COB";
                    cbo_cobranza.DisplayMember = "DESC_PTO_COB";
                    cbo_cobranza.DataSource = dtPtoCob;
                }
            }
        }

        private void btnResumen_Click(object sender, EventArgs e)
        {
            //bool val = false; 
            DataTable dt = null;
            ccTo.COD_INSTITUCION = cbo_institucion.SelectedValue.ToString();
            ccTo.COD_PTO_COB = cbo_cobranza.SelectedValue.ToString() != "0" ? cbo_cobranza.SelectedValue.ToString() : null;
            ccTo.FE_AÑO = cboannio.SelectedValue.ToString();
            ccTo.FE_MES = cbomes.SelectedValue.ToString();
            ccTo.NRO_SEMANA = cbo_semana.SelectedValue.ToString() != "0" ? cbo_semana.SelectedValue.ToString() : null;
            //DataRow[] rs = dtPtoCob.Select("COD_PTO_COB='" + cbo_cobranza.SelectedValue.ToString() + "'");
            //foreach (DataRow r in rs)
            //    val = Convert.ToBoolean(r["STATUS_CONSOLIDADO"]);
            //if (val)
            //    dt = ccBLL.repContratosRegistrados_x_PtoCons_Resumen_BLL(ccTo);
            //else
            //    dt = ccBLL.repContratosRegistrados_Resumen_BLL(ccTo);
            dt = ccBLL.repContratosRegistrados_Resumen_BLL(ccTo);
            if (dt.Rows.Count > 0)
            {
                List<contratoCabeceraTo> lcc = new List<contratoCabeceraTo>();
                foreach (DataRow rw in dt.Rows)
                {
                    contratoCabeceraTo cc = new contratoCabeceraTo();
                    cc.DESC_PTO_COB = rw["DESC_PTO_COB"].ToString();
                    cc.DESC_PTO_VEN = rw["DESC_PTO_VEN"].ToString();
                    cc.CANT_CONTRATOS = Convert.ToInt32(rw["CANT_CONTRATOS"]);
                    cc.SUM_TOTAL_CONTRATO = Convert.ToDecimal(rw["SUM_TOTAL_CONTRATO"]);
                    cc.SUM_IMP_CUOTA_INICIAL = Convert.ToDecimal(rw["SUM_IMP_CUOTA_INICIAL"]);
                    cc.SUM_IMP_CUOTA_MES = Convert.ToDecimal(rw["SUM_IMP_CUOTA_MES"]);
                    lcc.Add(cc);
                }
                REP_CONTRATOS_REGISTRADOS_RESUMEN frm = new REP_CONTRATOS_REGISTRADOS_RESUMEN();
                frm.Institucion = cbo_institucion.Text;
                frm.Nom_semana = cbo_semana.Text;
                frm.periodo = cbomes.Text + " " + cboannio.Text;
                frm.lstcc = lcc;
                frm.Show();
            }
            else
            {
                MessageBox.Show("No existen datos !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_cobranza.Focus();
            }
        }

    }
}
