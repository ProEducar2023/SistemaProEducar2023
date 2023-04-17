using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Presentacion.MOD_CXC.Reportes.FormRep
{
    public partial class REPORTE_CAMBIO_DE_UBICACION_I : Form
    {
        puntoCobranzaBLL ptoBLL = new puntoCobranzaBLL();
        puntoCobranzaTo ptoTo = new puntoCobranzaTo();
        tipoPlanillaCreacionBLL tpcBLL = new tipoPlanillaCreacionBLL();
        precontratoCabeceraBLL pccBLL = new precontratoCabeceraBLL();
        precontratoCabeceraTo pccTo = new precontratoCabeceraTo();
        cambioTipoPllaHistoricoBLL ctpBLL = new cambioTipoPllaHistoricoBLL();
        cambioTipoPllaHistoricoTo ctpTo = new cambioTipoPllaHistoricoTo();
        public REPORTE_CAMBIO_DE_UBICACION_I()
        {
            InitializeComponent();
        }

        private void REPORTE_CAMBIO_DE_UBICACION_I_Load(object sender, EventArgs e)
        {
            CARGAR_INSTITUCIONES();
            CARGAR_PTO_COBRANZA(Convert.ToString(cboInstitucionA.SelectedValue));
            CARGAR_TIPO_PLANILLA();
        }
        private void CARGAR_INSTITUCIONES()
        {
            institucionesBLL insBLL = new institucionesBLL();
            DataTable dtInst = insBLL.obtenerInstitucionesBLL();
            if (dtInst.Rows.Count > 0)
            {
                DataRow rw = dtInst.NewRow();
                rw["COD_INST"] = "0";
                rw["DESC_INST"] = "TODOS";
                rw["DESC_CORTA"] = "";
                rw["TIPO_PLANILLA"] = "";
                rw["COD_IDENTIDAD"] = "";
                rw["DES_IDENTIDAD"] = "";
                rw["COD_PROCESO"] = "";
                rw["DES_PROCESO"] = "";
                dtInst.Rows.InsertAt(rw, 0);
                cboInstitucionA.ValueMember = "COD_INST";
                cboInstitucionA.DisplayMember = "DESC_INST";
                cboInstitucionA.DataSource = dtInst;
                cboInstitucionA.SelectedValue = "01";
            }
        }

        private void cboInstitucionA_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CARGAR_PTO_COBRANZA(Convert.ToString(cboInstitucionA.SelectedValue));
        }

        private void CARGAR_PTO_COBRANZA(string cod_inst)
        {
            ptoTo.STATUS_CONSOLIDADO = true;
            ptoTo.COD_INSTITUCION = cod_inst;
            DataTable dtPtoCob = ptoBLL.obtenerPuntosCobranzaBLL(ptoTo);
            DataRow rw = dtPtoCob.NewRow();
            rw["COD_PTO_COB"] = "0";
            rw["DESC_PTO_COB"] = "TODOS";
            rw["COD_CANAL_DSCTO"] = "";
            rw["DESC_CANAL_DSCTO"] = "";
            rw["COD_SUCURSAL"] = "";
            rw["COD_INSTITUCION"] = "";
            rw["COD_CANAL_DSCTO"] = "";
            dtPtoCob.Rows.InsertAt(rw, 0);
            cboPtoCobranzaA.DataSource = null;

            if (dtPtoCob.Rows.Count > 0)
            {
                cboPtoCobranzaA.ValueMember = "COD_PTO_COB";
                cboPtoCobranzaA.DisplayMember = "DESC_PTO_COB";
                cboPtoCobranzaA.DataSource = dtPtoCob;
            }
        }
        private void CARGAR_TIPO_PLANILLA()
        {
            DataTable dtTiposPlla = tpcBLL.obtenerTipoPlanillaCreacionxTransferenciaBLL();
            if (dtTiposPlla.Rows.Count > 0)
            {
                DataRow rw = dtTiposPlla.NewRow();
                rw["COD_TIPO_PLLA"] = "0";
                rw["DESC_TIPO"] = "TODOS";
                rw["STATUS_CTACTE"] = "";
                dtTiposPlla.Rows.InsertAt(rw, 0);
                cboUbicacionesA.ValueMember = "COD_TIPO_PLLA";
                cboUbicacionesA.DisplayMember = "DESC_TIPO";
                cboUbicacionesA.DataSource = dtTiposPlla;
                cboUbicacionesA.SelectedValue = "PP";
            }
        }
        private bool validaPantalla()
        {
            bool result = true;
            if (rdbReporteC.Checked)//1
            {
                if (Convert.ToString(cboInstitucionA.SelectedValue) == "0")
                {
                    MessageBox.Show("Elija la Institucion !!!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cboInstitucionA.Focus();
                    return result = false;
                }
                if (Convert.ToString(cboUbicacionesA.SelectedValue) == "0")
                {
                    MessageBox.Show("Elija la Ubicacion !!!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cboUbicacionesA.Focus();
                    return result = false;
                }
                if (Convert.ToString(cboPtoCobranzaA.SelectedValue) == "0")
                {
                    MessageBox.Show("Elija el Punto de Cobranza !!!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cboPtoCobranzaA.Focus();
                    return result = false;
                }
            }
            else if (rdbReporteA.Checked)//2
            {
                if (Convert.ToString(cboInstitucionA.SelectedValue) == "0")
                {
                    MessageBox.Show("Elija la Institucion !!!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cboInstitucionA.Focus();
                    return result = false;
                }
                if (Convert.ToString(cboUbicacionesA.SelectedValue) == "0")
                {
                    MessageBox.Show("Elija la Ubicacion !!!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cboUbicacionesA.Focus();
                    return result = false;
                }
                if (Convert.ToString(cboPtoCobranzaA.SelectedValue) != "0")
                {
                    MessageBox.Show("Elija Punto de Cobranza Todos !!!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cboPtoCobranzaA.Focus();
                    return result = false;
                }

            }
            else if (rdb3.Checked)//3
            {
                if (Convert.ToString(cboInstitucionA.SelectedValue) != "0")
                {
                    MessageBox.Show("Elija Insituciones Todos !!!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cboInstitucionA.Focus();
                    return result = false;
                }
                if (Convert.ToString(cboUbicacionesA.SelectedValue) == "0")
                {
                    MessageBox.Show("Elija la Ubicacion !!!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cboUbicacionesA.Focus();
                    return result = false;
                }

                if (Convert.ToString(cboPtoCobranzaA.SelectedValue) != "0")
                {
                    MessageBox.Show("Elija Punto de Cobranza Todos !!!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cboPtoCobranzaA.Focus();
                    return result = false;
                }

            }
            else if (rdb4.Checked)//4
            {
                if (Convert.ToString(cboInstitucionA.SelectedValue) != "0")
                {
                    MessageBox.Show("Elija Instituciones Todos !!!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cboInstitucionA.Focus();
                    return result = false;
                }
                if (Convert.ToString(cboUbicacionesA.SelectedValue) != "0")
                {
                    MessageBox.Show("Elija Ubicaciones Todos !!!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cboUbicacionesA.Focus();
                    return result = false;
                }

                if (Convert.ToString(cboPtoCobranzaA.SelectedValue) != "0")
                {
                    MessageBox.Show("Elija Punto de Cobranza Todos !!!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cboPtoCobranzaA.Focus();
                    return result = false;
                }

            }
            else if (rdbReporteB.Checked)//5
            {
                if (Convert.ToString(cboInstitucionA.SelectedValue) == "0")
                {
                    MessageBox.Show("Elija la Institucion !!!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cboInstitucionA.Focus();
                    return result = false;
                }
                if (Convert.ToString(cboUbicacionesA.SelectedValue) != "0")
                {
                    MessageBox.Show("Elija Ubicaciones Todas !!!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cboUbicacionesA.Focus();
                    return result = false;
                }
                if (Convert.ToString(cboPtoCobranzaA.SelectedValue) == "0")
                {
                    MessageBox.Show("Elija el Punto de Cobranza !!!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cboPtoCobranzaA.Focus();
                    return result = false;
                }

            }
            else if (rdb6.Checked)//6
            {
                if (Convert.ToString(cboInstitucionA.SelectedValue) == "0")
                {
                    MessageBox.Show("Elija la Institucion !!!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cboInstitucionA.Focus();
                    return result = false;
                }
                if (Convert.ToString(cboUbicacionesA.SelectedValue) != "0")
                {
                    MessageBox.Show("Elija Ubicaciones Todos !!!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cboUbicacionesA.Focus();
                    return result = false;
                }

                if (Convert.ToString(cboPtoCobranzaA.SelectedValue) != "0")
                {
                    MessageBox.Show("Elija Punto de Cobranza Todos !!!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cboPtoCobranzaA.Focus();
                    return result = false;
                }

            }
            return result;
        }
        private void btn_pantalla_Click(object sender, EventArgs e)
        {
            if (rdbDetalle.Checked)
                reporteDetalle();
            else if (rdbResumen.Checked)
                reporteResumen();

        }
        private void reporteDetalle()
        {
            if (!validaPantalla())
                return;
            pccTo.FECHA_REPORTE_DESDE = dtpFechaDesdeA.Value.Date;
            pccTo.FECHA_REPORTE_HASTA = dtpFechaHastaA.Value.Date;
            pccTo.COD_INSTITUCION = Convert.ToString(cboInstitucionA.SelectedValue) == "0" ? null : Convert.ToString(cboInstitucionA.SelectedValue);
            pccTo.COD_PTO_COB = Convert.ToString(cboPtoCobranzaA.SelectedValue) == "0" ? null : Convert.ToString(cboPtoCobranzaA.SelectedValue);
            pccTo.TIPO_PLANILLA = Convert.ToString(cboUbicacionesA.SelectedValue) == "0" ? null : Convert.ToString(cboUbicacionesA.SelectedValue);
            if (rdbPorFecAprobacion.Checked)
            {
                pccTo.OP_APROB = true;
                pccTo.OP_CONTR = false;
            }
            else
            {
                pccTo.OP_APROB = false;
                pccTo.OP_CONTR = true;
            }
            DataTable dtReporteDetalle = pccBLL.obtenerReporteCambioUbicacionABLL(pccTo);
            if (dtReporteDetalle.Rows.Count > 0)
            {
                List<precontratoCabeceraTo> lpcc = new List<precontratoCabeceraTo>();
                foreach (DataRow rw in dtReporteDetalle.Rows)
                {
                    precontratoCabeceraTo pcc = new precontratoCabeceraTo();
                    pcc.NRO_PRESUPUESTO = rw["NRO_PRESUPUESTO"].ToString();
                    pcc.FECHA_PRE = Convert.ToDateTime(rw["FECHA_PRE"]);
                    pcc.FECHA_APROB = Convert.ToDateTime(rw["FECHA_APROB"]);
                    pcc.DESC_PER = Convert.ToString(rw["DESC_PER"]);
                    pcc.FEC_PRIMER_VENC = Convert.ToDateTime(rw["FEC_PRIMER_VENC"]);
                    pcc.TOTAL_CONTRATO = Convert.ToDecimal(rw["TOTAL_CONTRATO"]);
                    ctpTo.NRO_CONTRATO = pcc.NRO_PRESUPUESTO;
                    pcc.SALDOxCOBRA = ctpBLL.obtenerSaldoxCobrarBLL(ctpTo);
                    pcc.NRO_CUOTAS = ctpBLL.obtenerNroCuotasPendientesBLL(ctpTo);
                    pcc.DESC_PTO_COB = Convert.ToString(rw["DESC_PTO_COB"]);//---------
                    pcc.NRO_REPORTE = Convert.ToString(rw["NRO_REPORTE"]);
                    pcc.FEC_REPORTE = Convert.ToDateTime(rw["FEC_REPORTE"]);
                    pcc.COND_CLIE = Convert.ToString(rw["DESCRIPCION"]);
                    pcc.TIPO_PLANILLA = Convert.ToString(rw["DESC_TIPO"]);
                    pcc.FE_ULT_CAMBIO = ctpBLL.obtenerFechaUltCambioBLL(ctpTo);
                    pcc.NRO_DE_CAMBIOS = ctpBLL.obtenerNroCambiosBLL(ctpTo);
                    pcc.DESC_INSTITUCION = Convert.ToString(rw["DESC_INST"]);
                    pcc.INSTITUCION_PTO_COB = Convert.ToString(rw["DESC_INST"]) + " - Punto de Cobranza : " + Convert.ToString(rw["DESC_PTO_COB"]);
                    pcc.INSTITUCION_PTO_COB_UBICACION = Convert.ToString(rw["DESC_INST"]) + "-" + Convert.ToString(rw["DESC_PTO_COB"]) + "-" + Convert.ToString(rw["DESC_TIPO"]);
                    pcc.INSTITUCION_PTO_COB2 = Convert.ToString(rw["DESC_INST"]) + " - " + Convert.ToString(rw["DESC_PTO_COB"]);
                    lpcc.Add(pcc);

                }
                ////ordenamiento
                //if (rdbPorFecAprobacion.Checked)
                //    lpcc.OrderBy(x => x.FECHA_APROB);
                //else
                //    lpcc.OrderBy(x => x.FECHA_PRE);
                //Envio Reporte
                if (rdbDetalle.Checked)
                {
                    if (rdbReporteA.Checked || rdbReporteC.Checked)
                    {
                        MOD_CXC.Reportes.FormRep.REP_CAMBIO_DE_UBICACION_I frm = new MOD_CXC.Reportes.FormRep.REP_CAMBIO_DE_UBICACION_I();
                        if (rdbReporteC.Checked)
                            frm.nombre_reporte = "REPORTE DE CONTRATOS POR UBICACION - DETALLE (1)";
                        else if (rdbReporteA.Checked)
                            frm.nombre_reporte = "REPORTE DE CONTRATOS POR UBICACION - DETALLE (2)";

                        if (rdbPorFecAprobacion.Checked)
                        {
                            frm.fecha_desde_hasta = "Fecha Aprobacion del " + dtpFechaDesdeA.Value.ToShortDateString() + " al " + dtpFechaHastaA.Value.ToShortDateString();
                            frm.ordenamiento = "1";//por aprobacion
                        }
                        else
                        {
                            frm.fecha_desde_hasta = "Fecha Contrato del " + dtpFechaDesdeA.Value.ToShortDateString() + " al " + dtpFechaHastaA.Value.ToShortDateString();
                            frm.ordenamiento = "2";//por contrato
                        }
                        frm.institucion = cboInstitucionA.Text;
                        frm.pto_cobranza = cboPtoCobranzaA.Text;
                        frm.ubicacion = cboUbicacionesA.Text;
                        frm.lstpcc = lpcc;
                        frm.Show();
                    }
                    else if (rdb3.Checked)
                    {
                        MOD_CXC.Reportes.FormRep.REP_CAMBIO_UBICACION_3 frm = new MOD_CXC.Reportes.FormRep.REP_CAMBIO_UBICACION_3();
                        frm.nombre_reporte = "REPORTE DE CONTRATOS POR UBICACION - DETALLE (3)";
                        if (rdbPorFecAprobacion.Checked)
                        {
                            frm.fecha_desde_hasta = "Fecha Aprobacion del " + dtpFechaDesdeA.Value.ToShortDateString() + " al " + dtpFechaHastaA.Value.ToShortDateString();
                            frm.ordenamiento = "1";//por aprobacion
                        }
                        else
                        {
                            frm.fecha_desde_hasta = "Fecha Contrato del " + dtpFechaDesdeA.Value.ToShortDateString() + " al " + dtpFechaHastaA.Value.ToShortDateString();
                            frm.ordenamiento = "2";//por contrato
                        }
                        frm.institucion = cboInstitucionA.Text;
                        frm.pto_cobranza = cboPtoCobranzaA.Text;
                        frm.ubicacion = cboUbicacionesA.Text;
                        frm.lstpcc = lpcc;
                        frm.Show();
                    }
                    else if (rdb4.Checked)
                    {
                        MOD_CXC.Reportes.FormRep.REP_CAMBIO_UBICACION_4 frm = new MOD_CXC.Reportes.FormRep.REP_CAMBIO_UBICACION_4();
                        frm.nombre_reporte = "REPORTE DE CONTRATOS POR UBICACION - DETALLE (4)";
                        if (rdbPorFecAprobacion.Checked)
                        {
                            frm.fecha_desde_hasta = "Fecha Aprobacion del " + dtpFechaDesdeA.Value.ToShortDateString() + " al " + dtpFechaHastaA.Value.ToShortDateString();
                            frm.ordenamiento = "1";//por aprobacion
                        }
                        else
                        {
                            frm.fecha_desde_hasta = "Fecha Contrato del " + dtpFechaDesdeA.Value.ToShortDateString() + " al " + dtpFechaHastaA.Value.ToShortDateString();
                            frm.ordenamiento = "2";//por contrato
                        }
                        frm.institucion = cboInstitucionA.Text;
                        frm.pto_cobranza = cboPtoCobranzaA.Text;
                        frm.ubicacion = cboUbicacionesA.Text;
                        frm.lstpcc = lpcc;
                        frm.Show();
                    }
                    else if (rdb6.Checked)
                    {
                        MOD_CXC.Reportes.FormRep.REP_CAMBIO_UBICACION_6 frm = new MOD_CXC.Reportes.FormRep.REP_CAMBIO_UBICACION_6();
                        frm.nombre_reporte = "REPORTE DE CONTRATOS POR UBICACION - DETALLE (6)";
                        if (rdbPorFecAprobacion.Checked)
                        {
                            frm.fecha_desde_hasta = "Fecha Aprobacion del " + dtpFechaDesdeA.Value.ToShortDateString() + " al " + dtpFechaHastaA.Value.ToShortDateString();
                            frm.ordenamiento = "1";//por aprobacion
                        }
                        else
                        {
                            frm.fecha_desde_hasta = "Fecha Contrato del " + dtpFechaDesdeA.Value.ToShortDateString() + " al " + dtpFechaHastaA.Value.ToShortDateString();
                            frm.ordenamiento = "2";//por contrato
                        }
                        frm.institucion = cboInstitucionA.Text;
                        frm.pto_cobranza = cboPtoCobranzaA.Text;
                        frm.ubicacion = cboUbicacionesA.Text;
                        frm.lstpcc = lpcc;
                        frm.Show();
                    }
                    else if (rdbReporteB.Checked)
                    {
                        MOD_CXC.Reportes.FormRep.REP_CAMBIO_DE_UBICACION_B frm = new MOD_CXC.Reportes.FormRep.REP_CAMBIO_DE_UBICACION_B();
                        frm.nombre_reporte = "REPORTE DE CONTRATOS POR UBICACION - DETALLE (5)";
                        if (rdbPorFecAprobacion.Checked)
                            frm.fecha_desde_hasta = "Fecha Aprobacion del " + dtpFechaDesdeA.Value.ToShortDateString() + " al " + dtpFechaHastaA.Value.ToShortDateString();
                        else
                            frm.fecha_desde_hasta = "Fecha Contrato del " + dtpFechaDesdeA.Value.ToShortDateString() + " al " + dtpFechaHastaA.Value.ToShortDateString();
                        frm.institucion = cboInstitucionA.Text;
                        frm.pto_cobranza = cboPtoCobranzaA.Text;
                        frm.ubicacion = cboUbicacionesA.Text;
                        frm.lstpcc = lpcc;
                        frm.Show();
                    }
                }
            }
            else
            {
                MessageBox.Show("No existen datos !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void reporteResumen()
        {
            //if (!validaPantalla())
            //    return;
            pccTo.FECHA_REPORTE_DESDE = dtpFechaDesdeA.Value.Date;
            pccTo.FECHA_REPORTE_HASTA = dtpFechaHastaA.Value.Date;
            pccTo.COD_INSTITUCION = Convert.ToString(cboInstitucionA.SelectedValue) == "0" ? null : Convert.ToString(cboInstitucionA.SelectedValue);
            pccTo.COD_PTO_COB = Convert.ToString(cboPtoCobranzaA.SelectedValue) == "0" ? null : Convert.ToString(cboPtoCobranzaA.SelectedValue);
            pccTo.TIPO_PLANILLA = Convert.ToString(cboUbicacionesA.SelectedValue) == "0" ? null : Convert.ToString(cboUbicacionesA.SelectedValue);
            if (rdbPorFecAprobacion.Checked)
            {
                pccTo.OP_APROB = true;
                pccTo.OP_CONTR = false;
            }
            else
            {
                pccTo.OP_APROB = false;
                pccTo.OP_CONTR = true;
            }
            DataTable dtReporteResumen = pccBLL.obtenerReporteCambioUbicacionResumenBLL(pccTo);
            if (dtReporteResumen.Rows.Count > 0)
            {
                List<precontratoCabeceraTo> lpcc = new List<precontratoCabeceraTo>();
                foreach (DataRow rw in dtReporteResumen.Rows)
                {
                    precontratoCabeceraTo pcc = new precontratoCabeceraTo();
                    pcc.DESC_INSTITUCION = Convert.ToString(rw["DESC_INST"]);
                    pcc.TIPO_PLANILLA = Convert.ToString(rw["DESC_TIPO"]);
                    pcc.DESC_PTO_COB = Convert.ToString(rw["DESC_PTO_COB"]);
                    pcc.NRO_DIAS = Convert.ToInt32(rw["NRO_CONTRATOS"]);
                    pcc.TOTAL_CONTRATO = Convert.ToDecimal(rw["TOTAL_CONTRATO"]);
                    pcc.SALDOxCOBRA = Convert.ToDecimal(rw["SALDOxCOBRAR"]);
                    lpcc.Add(pcc);

                }
                if (rdbReporteC.Checked || rdbReporteA.Checked || rdb3.Checked)
                {
                    MOD_CXC.Reportes.FormRep.REP_CAMBIO_DE_UBICACION_RESUMENES_VERTICAL frm = new MOD_CXC.Reportes.FormRep.REP_CAMBIO_DE_UBICACION_RESUMENES_VERTICAL();
                    if (rdbReporteC.Checked)
                        frm.nombre_reporte = "RESUMEN - UBICACIÓN DE CONTRATOS (1)";
                    else if (rdbReporteA.Checked)
                        frm.nombre_reporte = "RESUMEN - UBICACIÓN DE CONTRATOS (2)";
                    else if (rdb3.Checked)
                        frm.nombre_reporte = "RESUMEN - UBICACIÓN DE CONTRATOS (3)";
                    if (rdbPorFecAprobacion.Checked)
                        frm.fecha_desde_hasta = "Fecha Aprobacion del " + dtpFechaDesdeA.Value.ToShortDateString() + " al " + dtpFechaHastaA.Value.ToShortDateString();
                    else
                        frm.fecha_desde_hasta = "Fecha Contrato del " + dtpFechaDesdeA.Value.ToShortDateString() + " al " + dtpFechaHastaA.Value.ToShortDateString();
                    frm.institucion = cboInstitucionA.Text;
                    frm.pto_cobranza = cboPtoCobranzaA.Text;
                    frm.ubicacion = cboUbicacionesA.Text;
                    frm.lstpcc = lpcc;
                    frm.Show();
                }
                else if (rdb4.Checked || rdbReporteB.Checked || rdb6.Checked)
                {
                    MOD_CXC.Reportes.FormRep.REP_CAMBIO_UBICACION_I_RESUMEN frm = new MOD_CXC.Reportes.FormRep.REP_CAMBIO_UBICACION_I_RESUMEN();
                    if (rdb4.Checked)
                        frm.nombre_reporte = "RESUMEN - UBICACIÓN DE CONTRATOS (4)";
                    else if (rdbReporteB.Checked)
                        frm.nombre_reporte = "RESUMEN - UBICACIÓN DE CONTRATOS (5)";
                    else if (rdb6.Checked)
                        frm.nombre_reporte = "RESUMEN - UBICACIÓN DE CONTRATOS (6)";
                    if (rdbPorFecAprobacion.Checked)
                        frm.fecha_desde_hasta = "Fecha Aprobacion del " + dtpFechaDesdeA.Value.ToShortDateString() + " al " + dtpFechaHastaA.Value.ToShortDateString();
                    else
                        frm.fecha_desde_hasta = "Fecha Contrato del " + dtpFechaDesdeA.Value.ToShortDateString() + " al " + dtpFechaHastaA.Value.ToShortDateString();
                    frm.institucion = cboInstitucionA.Text;
                    frm.pto_cobranza = cboPtoCobranzaA.Text;
                    frm.ubicacion = cboUbicacionesA.Text;
                    frm.lstpcc = lpcc;
                    frm.Show();
                }
            }
            else
            {
                MessageBox.Show("No existen datos !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        //1
        private void rdbReporteC_CheckedChanged(object sender, EventArgs e)
        {
            cboInstitucionA.SelectedValue = "01";
            cboUbicacionesA.SelectedValue = "PP";
            CARGAR_PTO_COBRANZA(Convert.ToString(cboInstitucionA.SelectedValue));
            cboPtoCobranzaA.SelectedValue = "001";
        }
        //2
        private void rbtReporteA_CheckedChanged(object sender, EventArgs e)
        {
            cboInstitucionA.SelectedValue = "01";
            cboUbicacionesA.SelectedValue = "PP";
            CARGAR_PTO_COBRANZA(Convert.ToString(cboInstitucionA.SelectedValue));
            cboPtoCobranzaA.SelectedValue = "0";
        }
        //3
        private void rdb3_CheckedChanged(object sender, EventArgs e)
        {
            cboInstitucionA.SelectedValue = "0";
            cboUbicacionesA.SelectedValue = "PP";
            CARGAR_PTO_COBRANZA(Convert.ToString(cboInstitucionA.SelectedValue));
            cboPtoCobranzaA.SelectedValue = "0";
        }
        //4
        private void rdb4_CheckedChanged(object sender, EventArgs e)
        {
            cboInstitucionA.SelectedValue = "0";
            cboUbicacionesA.SelectedValue = "0";
            CARGAR_PTO_COBRANZA(Convert.ToString(cboInstitucionA.SelectedValue));
            cboPtoCobranzaA.SelectedValue = "0";
        }
        //5
        private void rdbReporteB_CheckedChanged(object sender, EventArgs e)
        {
            cboInstitucionA.SelectedValue = "01";
            cboUbicacionesA.SelectedValue = "0";
            CARGAR_PTO_COBRANZA(Convert.ToString(cboInstitucionA.SelectedValue));
            cboPtoCobranzaA.SelectedValue = "001";

        }
        //6
        private void rdb6_CheckedChanged(object sender, EventArgs e)
        {
            cboInstitucionA.SelectedValue = "01";
            cboUbicacionesA.SelectedValue = "0";
            CARGAR_PTO_COBRANZA(Convert.ToString(cboInstitucionA.SelectedValue));
            cboPtoCobranzaA.SelectedValue = "0";
        }
        private void rdbDetalle_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbReporteC.Checked)
                rdbReporteC_CheckedChanged(sender, e);
            else if (rdbReporteA.Checked)
                rbtReporteA_CheckedChanged(sender, e);
            else if (rdb3.Checked)
                rdb3_CheckedChanged(sender, e);
            else if (rdb4.Checked)
                rdb4_CheckedChanged(sender, e);
            else if (rdbReporteB.Checked)
                rdbReporteB_CheckedChanged(sender, e);
            else if (rdb6.Checked)
                rdb6_CheckedChanged(sender, e);
        }
        private void rdbResumen_CheckedChanged(object sender, EventArgs e)
        {
            //cboInstitucionA.SelectedValue = "0";
            //cboUbicacionesA.SelectedValue = "0";
            //CARGAR_PTO_COBRANZA(Convert.ToString(cboInstitucionA.SelectedValue));
            //cboPtoCobranzaA.SelectedValue = "0";
        }



    }
}
