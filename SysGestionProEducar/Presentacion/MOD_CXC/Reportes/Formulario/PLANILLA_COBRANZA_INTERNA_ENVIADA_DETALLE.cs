using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Presentacion.MOD_CXC.Reportes.FormRep
{
    public partial class PLANILLA_COBRANZA_INTERNA_ENVIADA_DETALLE : Form
    {
        tipoCambioBLL tpcBLL = new tipoCambioBLL();
        planillaCabeceraBLL plcBLL = new planillaCabeceraBLL();
        planillaCabeceraTo plcTo = new planillaCabeceraTo();
        string titulo; int op;
        string AÑO; string MES;
        public PLANILLA_COBRANZA_INTERNA_ENVIADA_DETALLE(string titulo, int op, string AÑO, string MES)
        {
            InitializeComponent();
            this.titulo = titulo;
            this.Text = titulo;
            this.op = op;
            this.AÑO = AÑO;
            this.MES = MES;
        }

        private void PLANILLA_COBRANZA_INTERNA_ENVIADA_DETALLE_Load(object sender, EventArgs e)
        {
            CARGAR_INSTITUCIONES();
            CARGAR_CANAL_DSCTO();
            cargar_mes();
            cargar_año();
        }
        private void CARGAR_CANAL_DSCTO()
        {
            canalDescuentoBLL cdscBLL = new canalDescuentoBLL();
            DataTable dt = cdscBLL.ObtenerCanalDescuentoBLL();
            cbo_canal_dscto.ValueMember = "COD_CANAL_DSCTO";
            cbo_canal_dscto.DisplayMember = "DESCRIPCION";
            cbo_canal_dscto.DataSource = dt;
        }
        private void CARGAR_INSTITUCIONES()
        {
            institucionesBLL insBLL = new institucionesBLL();
            DataTable dtInst = insBLL.obtenerInstitucionesBLL();
            cbo_institucion.ValueMember = "COD_INST";
            cbo_institucion.DisplayMember = "DESC_INST";
            cbo_institucion.DataSource = dtInst;
        }
        private void cargar_año()
        {
            DataTable dt = tpcBLL.obtenerAnnioBLL();
            if (dt.Rows.Count > 0)
            {
                cbo_año.ValueMember = "año";
                cbo_año.DisplayMember = "año";
                cbo_año.DataSource = dt;
                cbo_año.SelectedIndex = -1;
                cbo_año.SelectedValue = AÑO;
            }
            else
            {
                var aa = new[] { new { cod = DateTime.Now.Year, val = DateTime.Now.Year } };
                cbo_año.ValueMember = "cod";
                cbo_año.DisplayMember = "val";
                cbo_año.DataSource = aa;
                cbo_año.SelectedIndex = -1;
                cbo_año.SelectedValue = AÑO;
            }
        }
        private void cargar_mes()
        {
            var months = new[] { new { cod = "01", val = "ENERO" }, new { cod = "02", val = "FEBRERO" },
                                new { cod = "03", val = "MARZO" }, new { cod = "04", val = "ABRIL" },
                                new { cod = "05", val = "MAYO" }, new { cod = "06", val = "JUNIO" },
                                new { cod = "07", val = "JULIO" }, new { cod = "08", val = "AGOSTO" },
                                new { cod = "09", val = "SEPTIEMBRE" }, new { cod = "10", val = "OCTUBRE" },
                                new { cod = "11", val = "NOVIEMBRE" }, new { cod = "12", val = "DICIEMBRE" }};
            cbo_mes.ValueMember = "cod";
            cbo_mes.DisplayMember = "val";
            cbo_mes.DataSource = months;
            cbo_mes.SelectedValue = MES;
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            dgw_pto_cob.Rows.Clear();
            plcTo.COD_INSTITUCION = cbo_institucion.SelectedValue.ToString();
            plcTo.COD_CANAL_DSCTO = cbo_canal_dscto.SelectedValue.ToString();
            plcTo.FE_MES = cbo_mes.SelectedValue.ToString();
            plcTo.FE_AÑO = cbo_año.SelectedValue.ToString();
            plcTo.OP = op;
            DataTable dt = plcBLL.obtenerNroPlanillaparaRepEnviadosBLL(plcTo);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow rw in dt.Rows)
                {
                    int rowId = dgw_pto_cob.Rows.Add();
                    DataGridViewRow row = dgw_pto_cob.Rows[rowId];
                    row.Cells["NRO_PLANILLA_COB"].Value = rw["NRO_PLANILLA_COB"].ToString();
                    row.Cells["DESC_PTO_COB"].Value = rw["DESC_PTO_COB"].ToString();
                }
            }
        }

        private void btn_pantalla_Click(object sender, EventArgs e)
        {
            string errMensaje = "";
            DataTable dt = HelpersBLL.obtenerDTX(dgw_pto_cob);
            if (!plcBLL.adicionaBucleTablaParametrosBLL(dt, ref errMensaje))
            {
                MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                eliminaTablaParamPlanilla();
            }
            else
            {
                plcTo.OP = op;
                DataTable dtPla = plcBLL.obtenerReportePlanillaCobInternaEnviadaDetalleBLL(plcTo);
                if (dtPla.Rows.Count > 0)
                {
                    List<planillaDetalleTo> lpld = new List<planillaDetalleTo>();
                    foreach (DataRow rw in dtPla.Rows)
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
                        pld.COD_PTO_VEN = rw["COD_SUB_PTO_VEN"].ToString();
                        pld.DESC_PTO_VEN = rw["DESC_PTO_VEN"].ToString();
                        pld.IMP_DOC = Convert.ToDecimal(rw["IMP_DOC"]);
                        pld.CUOTA = rw["CUOTA"].ToString();
                        pld.IMP_COB = Convert.ToDecimal(rw["IMP_COB"]);
                        pld.IMP_DEV = Convert.ToDecimal(rw["IMP_DEV"]);
                        pld.IMP_COB_CTA_CTE = Convert.ToDecimal(rw["IMP_COB_CTA_CTE"]);
                        pld.NOM_MOTIVO_NO_DESCONTADO = op == 2 ? "2.1) DESCONTADO CLIENTES" : "DESCONTADO CLIENTES";//"DESCONTADO CLIENTES";
                        pld.CATEG_MOTIVO = op == 2 ? "" : " DESCONTADO";//"2) DESCONTADO";
                        pld.CATEGORIA = rw["CATEGORIA"].ToString();
                        pld.MONTO_RECIBIDO = pld.IMP_COB;
                        pld.IMP_ENVIO = Convert.ToDecimal(rw["IMP_ENVIO"]);
                        if (op == 1)
                        {
                            if (pld.IMP_DOC > 0)//if(pld.COD_PER != "")//esto para que no aprezcan los indebidos ni los exceso de contrato
                                lpld.Add(pld);
                        }
                        else if (((rw["CATEGORIA"].ToString() == "01" || rw["CATEGORIA"].ToString() == "02") && pld.IMP_COB > 0) ||
                            (rw["CATEGORIA"].ToString() == "03" && rw["COD_MOTIVO_NO_DESCONTADO"].ToString() == "004") ||
                            (rw["CATEGORIA"].ToString() == "03" && rw["COD_MOTIVO_NO_DESCONTADO"].ToString() == "006" && rw["NRO_DOC"].ToString() != "0000000"))
                            //(rw["CATEGORIA"].ToString() == "03" && rw["COD_MOTIVO_NO_DESCONTADO"].ToString() == "007"))
                            lpld.Add(pld);
                        if (op == 2)
                        {
                            if (rw["CATEGORIA"].ToString() == "01" || rw["CATEGORIA"].ToString() == "03")
                            {
                                planillaDetalleTo pld2 = new planillaDetalleTo();
                                pld2.NRO_PLANILLA_COB = rw["NRO_PLANILLA_COB"].ToString();
                                pld2.FECHA_PLANILLA_COB = Convert.ToDateTime(rw["FECHA_PLANILLA_COB"]);
                                pld2.COD_PTO_COB_CONSOLIDADO = rw["COD_PTO_COB_CONSOLIDADO"].ToString();
                                pld2.DESC_PTO_COB = rw["DESC_PTO_COB"].ToString();
                                pld2.NRO_CONTRATO = rw["NRO_CONTRATO"].ToString();
                                pld2.FECHA_CONTRATO = Convert.ToDateTime(rw["FECHA_CONTRATO"]);
                                pld2.COD_PER = rw["COD_PER"].ToString();
                                pld2.CLIENTE = rw["CLIENTE"].ToString();
                                pld2.DNI = rw["DNI"].ToString();//row.Cells[4].Value.ToString();
                                pld2.COD_PTO_VEN = rw["COD_SUB_PTO_VEN"].ToString();
                                pld2.DESC_PTO_VEN = rw["DESC_PTO_VEN"].ToString();
                                pld2.CUOTA = rw["CUOTA"].ToString();
                                if (rw["COD_MOTIVO_NO_DESCONTADO"].ToString() == "001" || rw["COD_MOTIVO_NO_DESCONTADO"].ToString() == "003")//DESCUENTO EN PARTES, POR AVERIGUAR
                                {
                                    pld2.IMP_COB = pld.IMP_DOC - (pld.IMP_COB + pld.IMP_DEV);
                                    pld2.IMP_COB = pld2.IMP_COB < 0 ? (-1) * pld2.IMP_COB : pld2.IMP_COB;
                                    pld2.CATEG_MOTIVO = "3) " + rw["CATEG_MOTIVO"].ToString();//7
                                    pld2.NOM_MOTIVO_NO_DESCONTADO = rw["NOM_MOTIVO_NO_DESCONTADO"].ToString();
                                    pld2.MONTO_RECIBIDO = 0;
                                }
                                else if (rw["COD_MOTIVO_NO_DESCONTADO"].ToString() == "004")
                                {
                                    pld2.IMP_COB = pld.IMP_COB_CTA_CTE;
                                    //pld2.CATEG_MOTIVO = "3) " + rw["CATEG_MOTIVO"].ToString();
                                    pld2.CATEG_MOTIVO = "";
                                    pld2.NOM_MOTIVO_NO_DESCONTADO = "2.2) " + rw["NOM_MOTIVO_NO_DESCONTADO"].ToString();//4
                                    pld2.MONTO_RECIBIDO = pld.IMP_COB;
                                }
                                else if (rw["COD_MOTIVO_NO_DESCONTADO"].ToString() == "005")
                                {
                                    pld2.IMP_COB = pld.IMP_COB;
                                    //pld2.CATEG_MOTIVO = "4) " + rw["CATEG_MOTIVO"].ToString();
                                    pld2.CATEG_MOTIVO = "";
                                    pld2.NOM_MOTIVO_NO_DESCONTADO = "2.3) " + rw["NOM_MOTIVO_NO_DESCONTADO"].ToString();//5
                                    pld2.MONTO_RECIBIDO = pld.IMP_COB;
                                }
                                else if (rw["COD_MOTIVO_NO_DESCONTADO"].ToString() == "006")
                                {
                                    //pld2.IMP_COB = pld.IMP_COB;
                                    pld2.IMP_COB = pld.IMP_DEV;
                                    //pld2.CATEG_MOTIVO = "5) " + rw["CATEG_MOTIVO"].ToString();
                                    pld2.CATEG_MOTIVO = "";
                                    pld2.NOM_MOTIVO_NO_DESCONTADO = "2.4) " + rw["NOM_MOTIVO_NO_DESCONTADO"].ToString();//6
                                    pld2.MONTO_RECIBIDO = pld.IMP_COB;
                                }
                                else if (rw["COD_MOTIVO_NO_DESCONTADO"].ToString() == "007")
                                {
                                    pld2.IMP_COB = pld.IMP_COB_CTA_CTE;
                                    //pld2.CATEG_MOTIVO = "3) " + rw["CATEG_MOTIVO"].ToString();
                                    pld2.CATEG_MOTIVO = "";
                                    pld2.NOM_MOTIVO_NO_DESCONTADO = "2.5) " + rw["NOM_MOTIVO_NO_DESCONTADO"].ToString();//4
                                    pld2.MONTO_RECIBIDO = pld.IMP_COB;
                                }
                                pld2.IMP_DEV = Convert.ToDecimal(rw["IMP_DEV"]);
                                pld2.CATEGORIA = rw["CATEGORIA"].ToString();
                                pld2.IMP_ENVIO = Convert.ToDecimal(rw["IMP_ENVIO"]);//antes decia pld.IMP_ENVIO sin el 2
                                //pld2.NOM_MOTIVO_NO_DESCONTADO = rw["NOM_MOTIVO_NO_DESCONTADO"].ToString();
                                //pld2.CATEG_MOTIVO = rw["CATEG_MOTIVO"].ToString();
                                lpld.Add(pld2);
                            }
                        }
                        else if (op == 3)
                        {
                            if (rw["CATEGORIA"].ToString() == "01" || rw["CATEGORIA"].ToString() == "03")
                            {
                                planillaDetalleTo pld2 = new planillaDetalleTo();
                                pld2.NRO_PLANILLA_COB = rw["NRO_PLANILLA_COB"].ToString();
                                pld2.FECHA_PLANILLA_COB = Convert.ToDateTime(rw["FECHA_PLANILLA_COB"]);
                                pld2.COD_PTO_COB_CONSOLIDADO = rw["COD_PTO_COB_CONSOLIDADO"].ToString();
                                pld2.DESC_PTO_COB = rw["DESC_PTO_COB"].ToString();
                                pld2.NRO_CONTRATO = rw["NRO_CONTRATO"].ToString();
                                pld2.FECHA_CONTRATO = Convert.ToDateTime(rw["FECHA_CONTRATO"]);
                                pld2.COD_PER = rw["COD_PER"].ToString();
                                pld2.CLIENTE = rw["CLIENTE"].ToString();
                                pld2.DNI = rw["DNI"].ToString();//row.Cells[4].Value.ToString();
                                pld2.COD_PTO_VEN = rw["COD_SUB_PTO_VEN"].ToString();
                                pld2.DESC_PTO_VEN = rw["DESC_PTO_VEN"].ToString();
                                pld2.CUOTA = rw["CUOTA"].ToString();
                                if (rw["COD_MOTIVO_NO_DESCONTADO"].ToString() == "001" || rw["COD_MOTIVO_NO_DESCONTADO"].ToString() == "003")//DESCUENTO EN PARTES, POR AVERIGUAR
                                {
                                    pld2.IMP_COB = pld.IMP_DOC - (pld.IMP_COB + pld.IMP_DEV);
                                    pld2.IMP_COB = pld2.IMP_COB < 0 ? (-1) * pld2.IMP_COB : pld2.IMP_COB;
                                    pld2.CATEG_MOTIVO = rw["CATEG_MOTIVO"].ToString();
                                    pld2.NOM_MOTIVO_NO_DESCONTADO = rw["NOM_MOTIVO_NO_DESCONTADO"].ToString();
                                }
                                else if (rw["COD_MOTIVO_NO_DESCONTADO"].ToString() == "004")
                                {
                                    pld2.IMP_COB = pld.IMP_COB_CTA_CTE;
                                    //pld2.CATEG_MOTIVO = "3) " + rw["CATEG_MOTIVO"].ToString();
                                    pld2.CATEG_MOTIVO = "EXCESOS";
                                    pld2.NOM_MOTIVO_NO_DESCONTADO = " " + rw["NOM_MOTIVO_NO_DESCONTADO"].ToString();
                                }
                                else if (rw["COD_MOTIVO_NO_DESCONTADO"].ToString() == "005")
                                {
                                    pld2.IMP_COB = pld.IMP_COB;
                                    //pld2.CATEG_MOTIVO = "4) " + rw["CATEG_MOTIVO"].ToString();
                                    pld2.CATEG_MOTIVO = "EXCESOS";
                                    pld2.NOM_MOTIVO_NO_DESCONTADO = " " + rw["NOM_MOTIVO_NO_DESCONTADO"].ToString();
                                }
                                else if (rw["COD_MOTIVO_NO_DESCONTADO"].ToString() == "006")
                                {
                                    pld2.IMP_COB = pld.IMP_DEV;
                                    //pld2.CATEG_MOTIVO = "5) " + rw["CATEG_MOTIVO"].ToString();
                                    pld2.CATEG_MOTIVO = "EXCESOS";
                                    pld2.NOM_MOTIVO_NO_DESCONTADO = " " + rw["NOM_MOTIVO_NO_DESCONTADO"].ToString();
                                }
                                else if (rw["COD_MOTIVO_NO_DESCONTADO"].ToString() == "007")
                                {
                                    pld2.IMP_COB = pld.IMP_COB_CTA_CTE;
                                    //pld2.CATEG_MOTIVO = "5) " + rw["CATEG_MOTIVO"].ToString();
                                    pld2.CATEG_MOTIVO = "EXCESOS";
                                    pld2.NOM_MOTIVO_NO_DESCONTADO = " " + rw["NOM_MOTIVO_NO_DESCONTADO"].ToString();
                                }
                                pld2.IMP_DEV = Convert.ToDecimal(rw["IMP_DEV"]);
                                pld2.CATEGORIA = rw["CATEGORIA"].ToString();
                                pld2.IMP_ENVIO = Convert.ToDecimal(rw["IMP_ENVIO"]);
                                //pld2.NOM_MOTIVO_NO_DESCONTADO = rw["NOM_MOTIVO_NO_DESCONTADO"].ToString();
                                //pld2.CATEG_MOTIVO = rw["CATEG_MOTIVO"].ToString();
                                lpld.Add(pld2);
                            }
                        }
                        //    pld.NOM_MOTIVO_NO_DESCONTADO = rw["NOM_MOTIVO_NO_DESCONTADO"].ToString();
                        //lpld.Add(pld);
                    }
                    if (op == 1)
                    {
                        MOD_CXC.Reportes.FormRep.REP_PLANILLA_COBRANZA_INTERNA_ENVIADA_DETALLE frm = new FormRep.REP_PLANILLA_COBRANZA_INTERNA_ENVIADA_DETALLE();
                        frm.lstpll = lpld;
                        frm.Show();
                    }
                    else if (op == 2)
                    {
                        MOD_CXC.Reportes.FormRep.REP_PLANILLA_COBRANZA_INTERNA_EJECUTADA_DETALLE frm = new FormRep.REP_PLANILLA_COBRANZA_INTERNA_EJECUTADA_DETALLE();
                        //frm.mensaje = dtPla.AsEnumerable().Where(x =>x.Field<string>("COD_MOTIVO")=="").Sum(x => x.Field<decimal>("IMP_DOC")).ToString();
                        frm.lstpll = lpld;
                        frm.Show();
                    }
                    else if (op == 3)
                    {
                        MOD_CXC.Reportes.FormRep.REP_PLANILLA_COBRANZA_INTERNA_EJECUTADA_RESUMEN frm = new FormRep.REP_PLANILLA_COBRANZA_INTERNA_EJECUTADA_RESUMEN();
                        frm.lstpll = lpld;
                        frm.Show();
                    }

                }
                else
                {
                    MessageBox.Show("No existen datos !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //cbo_suc.Focus();
                }
                eliminaTablaParamPlanilla();
            }
        }
        private void eliminaTablaParamPlanilla()
        {
            string errMensaje = "";
            if (!plcBLL.eliminaTablaParamPlanillaBLL(ref errMensaje))
                MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void chk_Todos_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_Todos.Checked)
            {
                foreach (DataGridViewRow row in dgw_pto_cob.Rows)
                    row.Cells["X"].Value = true;
            }
            else
            {
                foreach (DataGridViewRow row in dgw_pto_cob.Rows)
                    row.Cells["X"].Value = false;
            }
        }
    }
}
