using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace Presentacion.MOD_CXC
{
    public partial class GENERACION_I_PLANILLAS : Form
    {
        string AÑO = "", MES = "", COD_MOD = "", COD_USU = "", TIPO_USU = "";
        DateTime FECHA_INI, FECHA_GRAL;
        string boton; int fila;
        HelpersBLL helBLL = new HelpersBLL();
        planillaCabeceraBLL plcBLL = new planillaCabeceraBLL();
        planillaCabeceraTo plcTo = new planillaCabeceraTo();
        devPCtasCobrarBLL dpcBLL = new devPCtasCobrarBLL();
        devPCtasCobrarTo dpcTo = new devPCtasCobrarTo();
        DIALOGOS.CONSULTA_PCTAS_COBRAR_POR_NROCONTRATO OFR = new DIALOGOS.CONSULTA_PCTAS_COBRAR_POR_NROCONTRATO();
        //DIALOGOS.CONSULTA_PARA_GENERACION_PLANILLA_COB OFR1 = new DIALOGOS.CONSULTA_PARA_GENERACION_PLANILLA_COB();
        DataTable dtDet = new DataTable();
        StringBuilder stb = new StringBuilder();
        DataTable dtTablaImpExcesoCuota = new DataTable();
        tipoDocInvBLL tdiBLL = new tipoDocInvBLL();
        tipoDocInvTo tdiTo = new tipoDocInvTo();
        string COD_DOCU = "";
        DataTable dtAnt;
        public GENERACION_I_PLANILLAS(string AÑO, string MES, DateTime FECHA_INI, DateTime FECHA_GRAL, string COD_MOD, string TIPO_USU, string COD_USU)
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

        private void GENERACION_I_PLANILLAS_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            DATAGRID();
            CARGAR_SUCURSAL();
            CARGAR_CANAL_DSCTO();
            CARGAR_INSTITUCIONES();
            //CARGAR_PTO_COBRANZA_CONSOLIDADO();
            //CARGAR_SECTORISTA();
            INICIAR_CABECERA_GRID_DETALLE();
            CARGAR_TIPO_PLANILLA();
            CARGAR_PROGRAMAS();
            //dtp_generacion.Value = Convert.ToDateTime(DateTime.Now.Day + "/" + MES + "/" + AÑO);
            DateTime fe_plla = DateTime.Now;
            if (DateTime.TryParse((DateTime.Now.Day + "/" + MES + "/" + AÑO), out fe_plla))
                dtp_generacion.Value = Convert.ToDateTime(DateTime.Now.Day + "/" + MES + "/" + AÑO);
            else
                dtp_generacion.Value = FECHA_GRAL;
            //dtp_fecven.Value = Convert.ToDateTime(DateTime.Now.Day + "/" + MES + "/" + AÑO);
            dtp_fecven.Value = Convert.ToDateTime(FECHA_GRAL);
        }
        private void CARGAR_PROGRAMAS()
        {
            programaBLL prgBLL = new programaBLL();
            DataTable dt = prgBLL.obtenerProgramaBLL();
            cbo_programa.ValueMember = "COD_PROGRAMA";
            cbo_programa.DisplayMember = "DESC_PROGRAMA";
            cbo_programa.DataSource = dt;
            cbo_programa.SelectedIndex = 0;
        }
        private void INICIAR_CABECERA_GRID_DETALLE()
        {
            DGW_DET.Columns[0].HeaderText = "Contrato";
            DGW_DET.Columns[0].Width = 60;
            DGW_DET.Columns[0].ReadOnly = true;
            DGW_DET.Columns[1].HeaderText = "Codigo";
            DGW_DET.Columns[1].Width = 50;
            DGW_DET.Columns[1].ReadOnly = true;
            DGW_DET.Columns[2].HeaderText = "Cod Modular";
            DGW_DET.Columns[2].Width = 80;
            DGW_DET.Columns[2].ReadOnly = true;
            DGW_DET.Columns[3].HeaderText = "Cod Pago";
            DGW_DET.Columns[3].Width = 80;
            DGW_DET.Columns[3].ReadOnly = true;
            DGW_DET.Columns[4].HeaderText = "Nombre Cliente";
            DGW_DET.Columns[4].Width = 240;
            DGW_DET.Columns[4].ReadOnly = true;
            DGW_DET.Columns[5].HeaderText = "DNI/Ruc";
            DGW_DET.Columns[5].Width = 80;
            DGW_DET.Columns[5].ReadOnly = true;
            DGW_DET.Columns[6].Visible = false;
            DGW_DET.Columns[7].HeaderText = "N° Doc";
            DGW_DET.Columns[7].Width = 60;
            DGW_DET.Columns[7].ReadOnly = true;
            DGW_DET.Columns[8].HeaderText = "Fec Ven";
            DGW_DET.Columns[8].Width = 70;
            DGW_DET.Columns[8].ReadOnly = true;
            DGW_DET.Columns[8].DefaultCellStyle.Format = "dd/MM/yyyy";
            DGW_DET.Columns[9].HeaderText = "Imp Cuota";
            DGW_DET.Columns[9].Width = 65;
            DGW_DET.Columns[9].ReadOnly = true;
            DGW_DET.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DGW_DET.Columns[10].HeaderText = "ImpxEnviar";
            DGW_DET.Columns[10].Width = 65;
            DGW_DET.Columns[10].ReadOnly = false;
            DGW_DET.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DGW_DET.Columns[11].HeaderText = "Letra";
            DGW_DET.Columns[11].Width = 50;
            DGW_DET.Columns[11].ReadOnly = true;
            DGW_DET.Columns[12].HeaderText = "Tot Let";
            DGW_DET.Columns[12].Width = 55;
            DGW_DET.Columns[12].ReadOnly = true;
            DGW_DET.Columns[13].HeaderText = "Observaciones";
            DGW_DET.Columns[13].Width = 110;
            DGW_DET.Columns[13].ReadOnly = false;
            DGW_DET.Columns[15].HeaderText = "Punto de Cobranza";
            DGW_DET.Columns[15].Width = 220;
            DGW_DET.Columns[15].ReadOnly = false;
            DGW_DET.Columns[17].HeaderText = "Punto de Venta";
            DGW_DET.Columns[17].Width = 220;
            DGW_DET.Columns[17].ReadOnly = false;
            DGW_DET.Columns[18].ReadOnly = false;
        }
        private void CARGAR_CANAL_DSCTO()
        {
            canalDescuentoBLL cdscBLL = new canalDescuentoBLL();
            DataTable dt = cdscBLL.ObtenerCanalDescuentoBLL();
            cbo_canaldscto.ValueMember = "COD_CANAL_DSCTO";
            cbo_canaldscto.DisplayMember = "DESCRIPCION";
            cbo_canaldscto.DataSource = dt;
            cbo_canaldscto.SelectedIndex = -1;
        }
        private void CARGAR_TIPO_PLANILLA()
        {
            //var planilla = new[] {  new { val = "DESCUENTO", cod = "P" }
            //                      };
            //cbo_tipo_planilla.ValueMember = "cod";
            //cbo_tipo_planilla.DisplayMember = "val";
            //cbo_tipo_planilla.DataSource = planilla;
            //cbo_tipo_planilla.SelectedValue = "P";
            ////cbo_tipo_planilla.SelectedIndex = 0;

            tipoPlanillaCreacionBLL tpllaBLL = new tipoPlanillaCreacionBLL();
            tipoPlanillaCreacionTo tpllaTo = new tipoPlanillaCreacionTo();
            //tpllaTo.STATUS_GENERACION = "1";
            tpllaTo.STATUS_CTACTE = "1";
            tpllaTo.COD_VENTA = "VTA";
            //DataTable dtTipoPlla = tpllaBLL.obtenerTipoPlanillaCreacionxStGeneracionBLL(tpllaTo);
            DataTable dtTipoPlla = tpllaBLL.obtenerTipoPlanillaCreacionGeneracionPllaBLL(tpllaTo);
            if (dtTipoPlla.Rows.Count > 0)
            {
                cbo_tipo_planilla.ValueMember = "COD_TIPO_PLLA";
                cbo_tipo_planilla.DisplayMember = "DESC_TIPO";
                cbo_tipo_planilla.DataSource = dtTipoPlla;
                cbo_tipo_planilla.SelectedIndex = 0;
            }
        }
        private void CARGAR_PTO_COBRANZA_CONSOLIDADO()
        {
            puntoCobranzaBLL ptoBLL = new puntoCobranzaBLL();
            puntoCobranzaTo ptoTo = new puntoCobranzaTo();
            ptoTo.STATUS_CONSOLIDADO = true;
            ptoTo.COD_INSTITUCION = cbo_institucion.SelectedValue.ToString();
            DataTable dt = ptoBLL.obtenerPuntosCobranzaBLL(ptoTo);
            cbo_ptoCobranza.ValueMember = "COD_PTO_COB";
            cbo_ptoCobranza.DisplayMember = "DESC_PTO_COB";
            cbo_ptoCobranza.DataSource = dt;
            cbo_ptoCobranza.SelectedIndex = -1;
        }
        private void obtieneNroPlanilla()
        {
            if (cbo_sucursal.SelectedValue != null && cbo_tipo_planilla.SelectedValue != null)
            {
                tdiTo.TIPO_DOC = cbo_tipo_planilla.SelectedValue.ToString();
                COD_DOCU = tdiBLL.obtieneCodDocInvxTipoDocBLL(tdiTo);
                DataTable dt = HelpersBLL.obtieneNroPlanilla(cbo_sucursal.SelectedValue.ToString(), "0", COD_DOCU);
                txt_ser.Text = dt.Rows[0]["SERIE"].ToString();
                txt_num.Text = dt.Rows[0]["NUMERO"].ToString();
            }
        }
        private void GENERACION_I_PLANILLAS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void DATAGRID()
        {
            plcTo.FE_AÑO = AÑO;
            plcTo.FE_MES = MES;
            DataTable dt = plcBLL.obtener_I_Planilla_Cabecera_BLL(plcTo);
            if (dt.Rows.Count > 0)
            {
                dgw1.DataSource = dt;
                dgw1.Columns["TIPO_PLANILLA"].HeaderText = "Tip";
                dgw1.Columns["TIPO_PLANILLA"].Width = 30;
                dgw1.Columns["TIPO_PLANILLA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgw1.Columns["NRO_PLANILLA_COB"].HeaderText = "Nro Planilla";
                dgw1.Columns["NRO_PLANILLA_COB"].Width = 80;
                dgw1.Columns["FECHA_PLANILLA_COB"].HeaderText = "Fec Planilla";
                dgw1.Columns["FECHA_PLANILLA_COB"].Width = 70;
                dgw1.Columns["FECHA_PLANILLA_COB"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgw1.Columns["FECHA_ENVIO"].HeaderText = "Fec Envio";
                dgw1.Columns["FECHA_ENVIO"].Width = 70;
                dgw1.Columns["FECHA_ENVIO"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgw1.Columns["COD_INSTITUCION"].Visible = false;
                dgw1.Columns["DESC_INST"].HeaderText = "Institucion";
                dgw1.Columns["DESC_INST"].Width = 160;
                dgw1.Columns["COD_PTO_COB_CONSOLIDADO"].Visible = false;
                dgw1.Columns["DESC_PTO_COB"].HeaderText = "Punto Cobranza Consolidado";
                dgw1.Columns["DESC_PTO_COB"].Width = 200;
                dgw1.Columns["COD_CANAL_DSCTO"].Visible = false;
                dgw1.Columns["DESCRIPCION"].HeaderText = "Canal Descuento";
                dgw1.Columns["DESCRIPCION"].Width = 160;
                dgw1.Columns["COD_SUCURSAL"].Visible = false;
                dgw1.Columns["COD_PTO_COB"].Visible = false;
                dgw1.Columns["COD_SECTORISTA"].Visible = false;
                dgw1.Columns["DESC_EQVTA"].HeaderText = "Sectorista";
                dgw1.Columns["DESC_EQVTA"].Width = 160;
                dgw1.Columns["COD_COBRADOR"].Visible = false;
                dgw1.Columns["COBR"].Visible = false;
                dgw1.Columns["FECHA_VEN_AL"].Visible = false;
                dgw1.Columns["STATUS_ANULADO"].Visible = false;
                dgw1.Columns["FECHA_APROBACION"].Visible = false;
                dgw1.Columns["OBSERVACION"].Visible = false;
                //dgw1.Columns["TIPO_PLANILLA"].Visible = false;
                dgw1.Columns["COD_FORMATO"].Visible = false;
                dgw1.Columns["STATUTS_APROBADO"].HeaderText = "Aprobado";
                dgw1.Columns["STATUTS_APROBADO"].Width = 60;
                //dgw1.Columns["STATUTS_APROBADO"].Visible = false;
                dgw1.Columns["STATUS_NO_ENVIADO"].Visible = false;
                //dgw1.Columns["IMP_ENVIO"].Visible = false;
                dgw1.Columns["CANT_CONTRATOS"].Visible = false;
                dgw1.Columns["FE_MES"].Visible = false;
                dgw1.Columns["FE_AÑO"].Visible = false;
                dgw1.Columns["IMP_ENVIO"].HeaderText = "Imp Plla";
                dgw1.Columns["IMP_ENVIO"].Width = 70;
                dgw1.Columns["IMP_ENVIO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgw1.Columns["IMP_ENVIO"].DefaultCellStyle.Format = "###,###,##0.00";
                dgw1.Columns["COD_TIPO_OPERACION"].Visible = false;
            }
        }
        private void CARGAR_SECTORISTA()
        {
            progNivelBLL prnBLL = new progNivelBLL();
            DataTable dtEqc = prnBLL.obtenerSectoristasparaCrearEqCobradoresBLL("01");//02 Cobradores
            cbo_sectorista.ValueMember = "COD_EQCOB";
            cbo_sectorista.DisplayMember = "DESC_EQVTA";
            cbo_sectorista.DataSource = dtEqc;
        }
        private void CARGAR_INSTITUCIONES()
        {
            institucionesBLL insBLL = new institucionesBLL();
            DataTable dtInst = insBLL.obtenerInstitucionesBLL();
            cbo_institucion.ValueMember = "COD_INST";
            cbo_institucion.DisplayMember = "DESC_INST";
            cbo_institucion.DataSource = dtInst;
        }
        private void CARGAR_SUCURSAL()
        {
            HelpersBLL helBLL = new HelpersBLL();
            HelpersTo helTo = new HelpersTo();
            helTo.CODIGO = COD_USU;
            DataTable dt = helBLL.CBO_SUCURSALBLL(helTo);
            cbo_sucursal.ValueMember = "COD_SUCURSAL";
            cbo_sucursal.DisplayMember = "DESC_sucursal";
            cbo_sucursal.DataSource = dt;
            cbo_sucursal.SelectedIndex = -1;
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            boton = "NUEVO";
            BTN_GRABAR.Visible = true;
            btn_grabar2.Visible = false;
            btn_generar.Enabled = true;
            //cbo_ni.Visible = true;
            txt_ser.Visible = true;
            TabControl1.SelectedTab = (TabPage2);
            LIMPIAR_CABECERA();
            DGW_DET.Rows.Clear();
            Panel1.Visible = true;
            Panel0.Enabled = true;
            BTN_GRABAR.Enabled = true;
            gb_oc.Enabled = true;
            gb_pt.Enabled = true;
            panel2.Enabled = true;
            Panel0.Enabled = true;
            BTN_GRABAR.Enabled = true;
            btn_grabar2.Enabled = true;
            CH_PV.Enabled = true;
            dtDet.Rows.Clear();
            VER_PTOS_COB_CONSOLIDADOS();
            //cbo_tipo_planilla.SelectedValue = "P";
            cbo_sucursal.Focus();
        }
        private void VER_PTOS_COB_CONSOLIDADOS()
        {
            frmPTO_COB_CONSOLIDADO frm = new frmPTO_COB_CONSOLIDADO(MES, AÑO, FECHA_GRAL);
            this.Hide();
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                if (HACER_COINCIDIR_COMBOS(frm))
                {
                    frm.Hide();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Elija un Punto de Cobranza Consolidado nuevo !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //frm.ShowDialog();
                    frm.Hide();
                    this.Show();
                    TabControl1.SelectedTab = TabPage1;
                }
            }
            else
            {
                frm.Hide();
                this.Show();
                TabControl1.SelectedTab = TabPage1;
            }
        }
        private bool HACER_COINCIDIR_COMBOS(frmPTO_COB_CONSOLIDADO frm)
        {
            bool x = false;
            foreach (DataGridViewRow rw in frm.dgw.Rows)
            {
                if (Convert.ToBoolean(rw.Cells["op"].Value) == true && rw.Cells["flag"].Value.ToString() == "0")
                {
                    cbo_sucursal.SelectedValue = rw.Cells["COD_SUCURSAL"].Value;
                    cbo_institucion.SelectedValue = frm.cbo_institucion.SelectedValue;//rw.Cells["COD_INSTITUCION"].Value;
                    cbo_ptoCobranza.SelectedValue = rw.Cells["cod_pto_cob_cons"].Value;
                    cbo_canaldscto.SelectedValue = frm.cbo_canaldscto.SelectedValue;//rw.Cells["cod_canal_dscto"].Value;
                    cbo_tipo_planilla.SelectedValue = frm.cbo_tipo_planilla.SelectedValue;
                    x = true;
                    break;
                }
            }
            return x;
        }
        private void CARGAR_GRID()
        {
            DGW_DET.Rows.Clear();
            plcTo.FECHA_VEN_AL = dtp_fecven.Value;
            plcTo.COD_PTO_COB_CONSOLIDADO = cbo_ptoCobranza.SelectedValue.ToString();
            plcTo.COD_CANAL_DSCTO = cbo_canaldscto.SelectedValue.ToString();
            plcTo.COD_INSTITUCION = cbo_institucion.SelectedValue.ToString();
            plcTo.TIPO_PLANILLA = cbo_tipo_planilla.SelectedValue.ToString();
            plcTo.COD_PROGRAMA = cbo_programa.SelectedValue.ToString();
            DataTable dt = plcBLL.obtenerPCtasCobrar_para_PlanillaBLL(plcTo);
            DataTable dtReal = obtenerDtTrabajado(dt);
            if (dtReal.Rows.Count > 0)
            {
                //DGW_DET.Rows.Clear(); //NO SE DEBE DE LIMPIAR PUES PUEDE SER QUE HAYA MODIFICADO LOS VALORES ORIGINALES QUE TRAE EL GENERAR, AHORA SI PUES CUANDO MODIFICA ESTE BOTON ESTA DESHABILITADO
                foreach (DataRow rw in dtReal.Rows)
                {
                    //if (!validaExistencia(rw[0].ToString()))
                    //    continue;
                    int rowId = DGW_DET.Rows.Add();
                    DataGridViewRow row = DGW_DET.Rows[rowId];
                    row.Cells["NRO_CONTRATO"].Value = rw["NRO_CONTRATO"].ToString();
                    row.Cells["COD_PER"].Value = rw["COD_PER"].ToString();//nro contrato
                    row.Cells["DES_IDENTIDAD"].Value = rw["DES_IDENTIDAD"].ToString().Trim();//
                    row.Cells["DES_PROCESO"].Value = rw["DES_PROCESO"].ToString().Trim();//
                    row.Cells["DESC_PER"].Value = rw["DESC_PER"].ToString();
                    row.Cells["DNI"].Value = rw["DNI"].ToString();
                    row.Cells["COD_DOC"].Value = rw["COD_DOC"].ToString();
                    row.Cells["NRO_DOC"].Value = rw["NRO_DOC"].ToString().Trim();
                    row.Cells["FECHA_VEN"].Value = rw["FECHA_VEN"].ToString().Substring(0, 10);
                    row.Cells["IMP_INI"].Value = rw["IMP_INI"].ToString();
                    row.Cells["SAL_IMP"].Value = rw["SAL_IMP"].ToString();
                    row.Cells["NRO_LETRA"].Value = rw["NRO_LETRA"].ToString();
                    row.Cells["TOTAL_LETRA"].Value = rw["TOTAL_LETRA"].ToString();//nro letra
                    row.Cells["OBSERVACION"].Value = rw["OBSERVACION"].ToString();
                    row.Cells["COD_PTO_COB"].Value = rw["COD_PTO_COB"].ToString();
                    row.Cells["DESC_PTO_COB"].Value = rw["DESC_PTO_COB"].ToString();
                    row.Cells["COD_SUB_PTO_VEN"].Value = rw["COD_SUB_PTO_VEN"].ToString();
                    row.Cells["DESC_PTO_VEN"].Value = rw["DESC_PTO_VEN"].ToString();
                    row.Cells["NRO_CONTRATO_NRO_LETRA"].Value = rw["NRO_CONTRATO"].ToString() + rw["NRO_LETRA"].ToString();//para ordenar por este campo
                    //
                }
                dtDet = obtenerDT();//OBTIENE DEL GRID CON LOS CAMBIOS HECHOS HASTA EL MOMENTO
            }
            MOSTRAR_CANTIDAD_REGISTROS();
            HALLAR_TOTALES();
            HALLAR_NRO_CONTRATOS();
        }
        private void MOSTRAR_CANTIDAD_REGISTROS()
        {
            lbl_reg.Text = "Cantidad de Registros : " + DGW_DET.Rows.Count.ToString();
        }
        private DataTable obtenerDtTrabajado(DataTable dt)
        {
            //elimina registros de contratos suspendidos
            contratosSuspendidosBLL csBLL = new contratosSuspendidosBLL();
            contratosSuspendidosTo csTo = new contratosSuspendidosTo();
            csTo.COD_SUCURSAL = cbo_sucursal.SelectedValue.ToString();
            csTo.COD_INSTITUCION = cbo_institucion.SelectedValue.ToString();
            csTo.COD_PTO_COB = cbo_ptoCobranza.SelectedValue.ToString();
            DataTable dtContSus = csBLL.obtenerContratosSuspendidosxPtoCobBLL(csTo);
            if (dtContSus.Rows.Count > 0)
            {
                for (int k = dt.Rows.Count - 1; k >= 0; k--)
                {
                    for (int m = dtContSus.Rows.Count - 1; m >= 0; m--)
                    {
                        if (dt.Rows[k]["NRO_CONTRATO"].ToString() == dtContSus.Rows[m]["NRO_CONTRATO"].ToString())
                        {
                            if (dtp_generacion.Value >= Convert.ToDateTime(dtContSus.Rows[m]["FECHA_INI_SUS"]) && dtp_generacion.Value <= Convert.ToDateTime(dtContSus.Rows[m]["FECHA_FIN_SUS"]))
                            {
                                dt.Rows.RemoveAt(k);
                                break;
                            }
                        }
                    }
                }
            }
            //////////////////////////////
            foreach (DataColumn col in dt.Columns)
            {
                col.ReadOnly = false;
            }
            decimal imp = 0; int j = 0; int p = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (i == dt.Rows.Count - 1)
                    break;

                if (dt.Rows[i]["NRO_CONTRATO"].ToString() == dt.Rows[i + 1]["NRO_CONTRATO"].ToString())
                {
                    j = 0; p = 0;
                    imp = Convert.ToDecimal(dt.Rows[i]["IMP_COUTA_MES"]);

                    while (imp > 0)
                    {
                        if (imp > Convert.ToDecimal(dt.Rows[i + j]["SAL_IMP"]))
                            dt.Rows[i + j]["SAL_IMP"] = dt.Rows[i + j]["SAL_IMP"];
                        else if (imp < Convert.ToDecimal(dt.Rows[i + j]["SAL_IMP"]))
                            dt.Rows[i + j]["SAL_IMP"] = imp;
                        imp = imp - Convert.ToDecimal(dt.Rows[i + j]["SAL_IMP"]);
                        j++;
                        p = i + j;
                        if (p == dt.Rows.Count)
                            break;
                    }

                    //if (p < dt.Rows.Count)
                    //{
                    //    if ((dt.Rows[i]["NRO_CONTRATO"].ToString() == dt.Rows[p]["NRO_CONTRATO"].ToString()) && j > 1)
                    //    {
                    //        dt.Rows.RemoveAt(p);
                    //    }
                    //}
                    if (p < dt.Rows.Count)//aqui ocurre un error cuando hay una cuota completa 
                    {
                        if ((dt.Rows[i]["NRO_CONTRATO"].ToString() == dt.Rows[p]["NRO_CONTRATO"].ToString() && Convert.ToDecimal(dt.Rows[i]["SAL_IMP"]) == Convert.ToDecimal(dt.Rows[i]["IMP_COUTA_MES"])) ||
                            ((dt.Rows[i]["NRO_CONTRATO"].ToString() == dt.Rows[p]["NRO_CONTRATO"].ToString()) && j > 1))
                        {
                            dt.Rows.RemoveAt(p);
                        }
                    }
                    i = p - 1;
                }
                else
                {
                    //table.ImportRow(dt.Rows[i]);
                }
            }
            return dt;
        }
        private bool validaExistencia(string nrocontrato)
        {
            bool result = true;
            var query = from DataGridViewRow row in DGW_DET.Rows
                        where (row.Cells[0].Value.ToString() == nrocontrato)
                        select row;
            if (query.Count() > 0)
                result = false;
            return result;
        }
        private void LIMPIAR_CABECERA()
        {
            cbo_sucursal.SelectedIndex = -1;
            cbo_institucion.SelectedIndex = -1;
            cbo_ptoCobranza.SelectedIndex = -1;
            cbo_sectorista.SelectedIndex = -1;
            cbo_canaldscto.SelectedIndex = -1;
            txt_ser.Clear();
            txt_num.Clear();
            txt_obs.Clear();
            cbo_pto_cob.DataSource = null;
            cbo_tipo_planilla.SelectedIndex = -1;
            cbo_cobrador.SelectedIndex = -1;
            txt_totimp.Clear();
            txt_ctas.Clear();
        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            if (DGW_DET.Rows.Count > 0)
            {
                //dgw1.CurrentCell = dgw1.Rows[i].Cells["NRO_PLANILLA_COB"];
                //List<DataGridViewRow> rows = (from item in DGW_DET.Rows.Cast<DataGridViewRow>()
                //                let nro_contrato = Convert.ToString(item.Cells["Column1"].Value ?? string.Empty)
                //                where nro_contrato.Contains(DGW_DET.Rows[DGW_DET.CurrentRow.Index].Cells[0].Value.ToString())
                //                select item).ToList<DataGridViewRow>();
                int idx = DGW_DET.CurrentRow.Index;
                for (int i = idx; i <= DGW_DET.Rows.Count; i++)
                {
                    idx = i;
                    if (i == DGW_DET.Rows.Count - 1)
                        break;

                    if (DGW_DET.Rows[i].Cells["NRO_CONTRATO"].Value.ToString() != DGW_DET.Rows[i + 1].Cells["NRO_CONTRATO"].Value.ToString())
                    {
                        break;
                    }
                }
                DGW_DET.CurrentCell = DGW_DET.Rows[idx].Cells["NRO_CONTRATO"];
                DataTable dt = dtDet.AsEnumerable().Where(x => x.Field<string>("NRO_CONTRATO") == DGW_DET.Rows[DGW_DET.CurrentRow.Index].Cells["NRO_CONTRATO"].Value.ToString()).CopyToDataTable();
                OFR.MOSTRAR_DATOS(dt, DGW_DET.Rows[DGW_DET.CurrentRow.Index].Cells["NRO_CONTRATO"].Value.ToString(), DGW_DET.Rows[DGW_DET.CurrentRow.Index].Cells["NRO_LETRA"].Value.ToString());
                if (OFR.DGW_CAB.Rows.Count > 0)
                {
                    OFR.ShowDialog();
                    if (OFR.DialogResult == DialogResult.OK)
                    {
                        if (Convert.ToDecimal(DGW_DET.CurrentRow.Cells["IMP_INI"].Value) == Convert.ToDecimal(DGW_DET.CurrentRow.Cells["SAL_IMP"].Value))
                            INSERTAR_NUEVAS_CUOTAS();
                        else
                            INSERTAR_NUEVAS_CUOTAS_PARCIALES();
                        MOSTRAR_CANTIDAD_REGISTROS();
                        HALLAR_TOTALES();
                        HALLAR_NRO_CONTRATOS();
                        OFR.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("No se encontraron más cuotas pendientes !!!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }//
        private void HALLAR_TOTALES()
        {
            int num = DGW_DET.Rows.Count - 1;
            decimal sum = 0;
            int i = 0;
            while (i <= num)
            {
                sum = decimal.Add(sum, Convert.ToDecimal(DGW_DET.Rows[i].Cells["SAL_IMP"].Value));//10
                i++;
            }
            txt_totimp.Text = sum.ToString();
            txt_totimp.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(txt_totimp.Text);
            //txt_ctas.Text = DGW_DET.Rows.Count.ToString();
        }
        private void INSERTAR_NUEVAS_CUOTAS()
        {
            int idx = DGW_DET.CurrentRow.Index;
            int num = OFR.DGW_CAB.Rows.Count - 1;
            int num3 = num;
            int i = 0;
            while (i <= num3)
            {
                if (Convert.ToBoolean(OFR.DGW_CAB[7, i].Value))
                {
                    DGW_DET.Rows.Add(DGW_DET.Rows[idx].Cells["NRO_CONTRATO"].Value.ToString(),
                    DGW_DET.Rows[idx].Cells["COD_PER"].Value.ToString(), DGW_DET.Rows[idx].Cells["DES_IDENTIDAD"].Value.ToString(), DGW_DET.Rows[idx].Cells["DES_PROCESO"].Value.ToString(),
                    DGW_DET.Rows[idx].Cells["DESC_PER"].Value.ToString(), DGW_DET.Rows[idx].Cells["DNI"].Value.ToString(),
                    OFR.DGW_CAB[0, i].Value.ToString(),
                    OFR.DGW_CAB[1, i].Value.ToString().Trim(), OFR.DGW_CAB[2, i].Value.ToString(), OFR.DGW_CAB[3, i].Value.ToString(),//3 imp_ini
                    OFR.DGW_CAB[4, i].Value.ToString(), OFR.DGW_CAB[5, i].Value.ToString(), OFR.DGW_CAB[6, i].Value.ToString(), "",//4 imp_sal
                    OFR.DGW_CAB[8, i].Value.ToString(), OFR.DGW_CAB[9, i].Value.ToString(), OFR.DGW_CAB[10, i].Value.ToString(),
                    OFR.DGW_CAB[11, i].Value.ToString(), DGW_DET.Rows[idx].Cells["NRO_CONTRATO"].Value.ToString() + OFR.DGW_CAB[5, i].Value.ToString());
                }
                i++;
            }
            DGW_DET.Sort(DGW_DET.Columns["NRO_CONTRATO_NRO_LETRA"], System.ComponentModel.ListSortDirection.Ascending);
            int x = DGW_DET.Rows.Cast<DataGridViewRow>().Where(r => r.Cells["NRO_CONTRATO"].Value.ToString() == DGW_DET.Rows[idx].Cells["NRO_CONTRATO"].Value.ToString()).Count();
            DGW_DET.CurrentCell = DGW_DET.Rows[x + idx - 1].Cells["NRO_CONTRATO"];
            dtDet = obtenerDT();//OBTIENE DEL GRID CON LOS CAMBIOS HECHOS HASTA EL MOMENTO
        }
        private void INSERTAR_NUEVAS_CUOTAS_PARCIALES()
        {
            int idx = DGW_DET.CurrentRow.Index;
            DataTable dtx = HelpersBLL.obtenerDTXY(OFR.DGW_CAB, 5);
            int num = dtx.Rows.Count - 1;
            int num3 = num;
            int i = 0;
            int j = 0;
            decimal imp_sal = Convert.ToDecimal(DGW_DET.CurrentRow.Cells["SAL_IMP"].Value);
            decimal imp_final = 0;
            while (i <= num3)
            {
                if (j == 0)
                {
                    DGW_DET.CurrentRow.Cells["SAL_IMP"].Value = dtx.Rows[i][4].ToString();
                    j++;
                }
                if (i == num3)
                {
                    if (dtx.Rows[i][5].ToString() == dtx.Rows[i][6].ToString())
                        imp_final = Convert.ToDecimal(dtx.Rows[i][4]);
                    else
                        imp_final = imp_sal;
                    DGW_DET.Rows.Add(DGW_DET.Rows[idx].Cells["NRO_CONTRATO"].Value.ToString(),
                    DGW_DET.Rows[idx].Cells["COD_PER"].Value.ToString(), DGW_DET.Rows[idx].Cells["DES_IDENTIDAD"].Value.ToString(), DGW_DET.Rows[idx].Cells["DES_PROCESO"].Value.ToString(),
                    DGW_DET.Rows[idx].Cells["DESC_PER"].Value.ToString(), DGW_DET.Rows[idx].Cells["DNI"].Value.ToString(),
                    dtx.Rows[i][0].ToString(),
                    dtx.Rows[i][1].ToString().Trim(), dtx.Rows[i][2].ToString(), dtx.Rows[i][3].ToString(),//3 imp_ini
                    imp_final, dtx.Rows[i][5].ToString(), dtx.Rows[i][6].ToString(), "",//4 imp_sal
                    dtx.Rows[i][8].ToString(), dtx.Rows[i][9].ToString(), dtx.Rows[i][10].ToString(),
                    dtx.Rows[i][11].ToString(), DGW_DET.Rows[idx].Cells["NRO_CONTRATO"].Value.ToString() + dtx.Rows[i][5].ToString());
                }
                else
                {
                    DGW_DET.Rows.Add(DGW_DET.Rows[idx].Cells["NRO_CONTRATO"].Value.ToString(),
                    DGW_DET.Rows[idx].Cells["COD_PER"].Value.ToString(), DGW_DET.Rows[idx].Cells["DES_IDENTIDAD"].Value.ToString(), DGW_DET.Rows[idx].Cells["DES_PROCESO"].Value.ToString(),
                    DGW_DET.Rows[idx].Cells["DESC_PER"].Value.ToString(), DGW_DET.Rows[idx].Cells["DNI"].Value.ToString(),
                    dtx.Rows[i][0].ToString(),
                    dtx.Rows[i][1].ToString().Trim(), dtx.Rows[i][2].ToString(), dtx.Rows[i][3].ToString(),//3 imp_ini
                    dtx.Rows[i][4].ToString(), dtx.Rows[i][5].ToString(), dtx.Rows[i][6].ToString(), "",//4 imp_sal
                    dtx.Rows[i][8].ToString(), dtx.Rows[i][9].ToString(), dtx.Rows[i][10].ToString(),
                    dtx.Rows[i][11].ToString(), DGW_DET.Rows[idx].Cells["NRO_CONTRATO"].Value.ToString() + dtx.Rows[i][5].ToString());
                }

                //}
                i++;
            }
            DGW_DET.Sort(DGW_DET.Columns["NRO_CONTRATO_NRO_LETRA"], System.ComponentModel.ListSortDirection.Ascending);
            int x = DGW_DET.Rows.Cast<DataGridViewRow>().Where(r => r.Cells["NRO_CONTRATO"].Value.ToString() == DGW_DET.Rows[idx].Cells["NRO_CONTRATO"].Value.ToString()).Count();
            DGW_DET.CurrentCell = DGW_DET.Rows[x + idx - 3].Cells["NRO_CONTRATO"];
            dtDet = obtenerDT();//OBTIENE DEL GRID CON LOS CAMBIOS HECHOS HASTA EL MOMENTO
        }

        private void btn_eliminar2_Click(object sender, EventArgs e)
        {
            if (DGW_DET.Rows.Count > 0)
            {
                DGW_DET.Rows.RemoveAt(DGW_DET.CurrentRow.Index);
                MOSTRAR_CANTIDAD_REGISTROS();
                HALLAR_TOTALES();
                HALLAR_NRO_CONTRATOS();
                dtDet = obtenerDT();//OBTIENE DEL GRID CON LOS CAMBIOS HECHOS HASTA EL MOMENTO
            }
        }

        private void DGW_DET_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 10)
            {
                HALLAR_TOTALES();
                //HALLAR_NRO_CONTRATOS();
            }
        }

        private void cbo_sucursal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_sucursal.SelectedValue != null)
            {
                //obtieneNroPlanilla();
            }
        }

        private void BTN_GRABAR_Click(object sender, EventArgs e)
        {
            if (!validaAdicionar())
                return;

            DialogResult rs = MessageBox.Show("¿ Esta seguro de adicionar una nueva Planilla ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                plcTo.NRO_PLANILLA_COB = txt_ser.Text + "-" + txt_num.Text;
                plcTo.SERIE = txt_ser.Text;
                plcTo.COD_INSTITUCION = cbo_institucion.SelectedValue.ToString();
                plcTo.COD_PTO_COB_CONSOLIDADO = cbo_ptoCobranza.SelectedValue.ToString();
                plcTo.COD_CANAL_DSCTO = cbo_canaldscto.SelectedValue.ToString();
                plcTo.FE_AÑO = AÑO;
                plcTo.FE_MES = MES;
                plcTo.COD_SUCURSAL = cbo_sucursal.SelectedValue.ToString();
                //plcTo.COD_PTO_COB = cbo_tipo_planilla.SelectedValue.ToString() != "P" ? cbo_pto_cob.SelectedValue.ToString() : "";
                plcTo.COD_PTO_COB = cbo_ptoCobranza.SelectedValue.ToString();
                plcTo.COD_SECTORISTA = cbo_sectorista.SelectedValue.ToString();
                plcTo.COD_COBRADOR = cbo_cobrador.SelectedValue.ToString();
                plcTo.FECHA_PLANILLA_COB = dtp_generacion.Value;
                plcTo.FECHA_VEN_AL = dtp_fecven.Value;
                plcTo.FECHA_APROBACION = null;
                plcTo.FECHA_ENVIO = null;
                plcTo.FECHA_RECEPCION = null;
                plcTo.FECHA_PAGO = null;
                plcTo.STATUTS_APROBADO = "0";
                plcTo.STATUS_ENVIO = "0";
                plcTo.STATUS_RECEPCION = "0";
                plcTo.STATUS_PAGO = "0";
                plcTo.OBSERVACION = txt_obs.Text;
                plcTo.TIPO_PLANILLA = cbo_tipo_planilla.SelectedValue.ToString();
                plcTo.COD_CREACION = COD_USU;
                plcTo.FECHA_CREACION = DateTime.Now;
                //plcTo.COD_DOC = "43";//esto es para planilla cobranza, en el futuro ponerlo en una enumeración
                plcTo.SERIE = txt_ser.Text;
                plcTo.STATUS_DOC = "0";
                plcTo.STATUS_NO_ENVIADO = CH_PV.Checked ? "1" : "0";
                plcTo.CANT_CONTRATOS = Convert.ToInt32(txt_ctas.Text);
                plcTo.IMP_ENVIO = Convert.ToDecimal(txt_totimp.Text);
                //tdiTo.TIPO_DOC = cbo_tipo_planilla.SelectedValue.ToString();
                //COD_DOCU = tdiBLL.obtieneCodDocInvxTipoDocBLL(tdiTo);
                plcTo.COD_DOC = COD_DOCU;
                DataTable dtDetalle = obtenerDT();

                if (!plcBLL.adicionaNuevaPlanillaBLL(plcTo, dtDetalle, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("La planilla se creo correctamente", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TabControl1.SelectedTab = TabPage1;
                    DATAGRID();
                    FOCO_NUEVO_REG();
                }
            }
        }
        private DataTable obtenerDT()
        {
            DataTable table = new DataTable();
            foreach (DataGridViewColumn column in DGW_DET.Columns)
            {
                table.Columns.Add(column.Name, typeof(string));
            }
            foreach (DataGridViewRow row in DGW_DET.Rows)
            {
                DataRow dataRow = table.NewRow();
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    dataRow[i] = row.Cells[i].Value != null ? row.Cells[i].Value : DBNull.Value;
                }
                table.Rows.Add(dataRow);
            }
            return table;
        }
        private bool validaAdicionar()
        {
            bool result = true;
            if (cbo_sucursal.SelectedIndex == -1)
            {
                MessageBox.Show("Elija la Sucursal !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_sucursal.Focus();
                return result = false;
            }
            if (cbo_institucion.SelectedIndex == -1)
            {
                MessageBox.Show("Elija la Institucion !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_institucion.Focus();
                return result = false;
            }
            if (cbo_ptoCobranza.SelectedIndex == -1)
            {
                MessageBox.Show("Elija el Punto de Cobranza Consolidado !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_ptoCobranza.Focus();
                return result = false;
            }
            if (cbo_canaldscto.SelectedIndex == -1)
            {
                MessageBox.Show("Elija el Canal de Descuento !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_canaldscto.Focus();
                return result = false;
            }
            if (cbo_tipo_planilla.SelectedIndex == -1)
            {
                MessageBox.Show("Elija el Tipo !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_tipo_planilla.Focus();
                return result = false;
            }
            if (cbo_cobrador.SelectedIndex == -1)
            {
                MessageBox.Show("Elija el Cobrador !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_cobrador.Focus();
                return result = false;
            }
            if (DGW_DET.Rows.Count == 0)
            {
                MessageBox.Show("Ingrese registros de detalle !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return result = false;
            }
            if (CH_PV.Checked && txt_obs.Text == "")
            {
                MessageBox.Show("Ingrese la observacion !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return result = false;
            }
            return result;
        }

        private void btn_generar_Click(object sender, EventArgs e)
        {
            if (!validaCargar_Grid())
                return;
            CARGAR_GRID();
            MUESTRA_CONTRATOS_EXCESO_CUOTA();
            if (stb.ToString() != "")
            {
                DialogResult rs = MessageBox.Show("Los siguientes contratos tienen exceso de cuota deben ser aplicados o devueltos " + stb.ToString() + "\n Desea imprimir el Listado ?", "ADVERTENCIA", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (rs == DialogResult.Yes)
                {
                    if (dtTablaImpExcesoCuota.Rows.Count > 0)
                    {
                        List<personaTo> lper = new List<personaTo>();
                        foreach (DataRow rw in dtTablaImpExcesoCuota.Rows)
                        {
                            personaTo per = new personaTo();
                            per.contrato = rw["contrato"].ToString();
                            per.cod_modular = rw["cod_modular"].ToString();
                            per.cod_pago = rw["cod_pago"].ToString();
                            per.nom_clie = rw["nom_clie"].ToString();
                            per.dni_ruc = rw["dni_ruc"].ToString();
                            per.nro_planilla = rw["nro_planilla"].ToString();
                            per.monto_dev = Convert.ToDecimal(rw["monto_dev"]);
                            lper.Add(per);
                        }
                        MOD_CXC.Reportes.FormRep.REP_LISTA_EXCESO_CUOTA frm = new Reportes.FormRep.REP_LISTA_EXCESO_CUOTA();
                        frm.pto_cob_consolidado = cbo_ptoCobranza.Text;
                        frm.lstper = lper;
                        frm.Show();
                    }
                }
            }
            dtTablaImpExcesoCuota.Reset();
        }
        private void MUESTRA_CONTRATOS_EXCESO_CUOTA()
        {
            string errMensaje = "";
            string s = "";
            stb.Clear();
            crearTablaparaImpresionExcesoCuota();
            for (int i = 0; i < DGW_DET.Rows.Count; i++)
            {
                if (i == DGW_DET.Rows.Count - 1)
                {
                    s = ".";
                    Contratos_Exceso_Cuota(i, s, ref errMensaje);
                    break;
                }
                else
                    s = "-";
                if (DGW_DET.Rows[i].Cells["NRO_CONTRATO"].Value.ToString() != DGW_DET.Rows[i + 1].Cells["NRO_CONTRATO"].Value.ToString())
                    Contratos_Exceso_Cuota(i, s, ref errMensaje);
            }
        }
        private void crearTablaparaImpresionExcesoCuota()
        {
            dtTablaImpExcesoCuota.Columns.Add("contrato");
            dtTablaImpExcesoCuota.Columns.Add("cod_modular");
            dtTablaImpExcesoCuota.Columns.Add("cod_pago");
            dtTablaImpExcesoCuota.Columns.Add("nom_clie");
            dtTablaImpExcesoCuota.Columns.Add("dni_ruc");
            dtTablaImpExcesoCuota.Columns.Add("nro_planilla");
            dtTablaImpExcesoCuota.Columns.Add("monto_dev");
        }
        private void Contratos_Exceso_Cuota(int i, string s, ref string errMensaje)
        {
            dpcTo.NRO_CONTRATO = DGW_DET.Rows[i].Cells["NRO_CONTRATO"].Value.ToString();
            if (dpcBLL.Verifica_Contratos_Exceso_CuotaBLL(dpcTo, ref errMensaje))
            {
                stb.Append(dpcTo.NRO_CONTRATO + " " + s + " ");
                DataTable dt = dpcBLL.obtenerDevPCtasCobrarContratosExcesoCuotaBLL(dpcTo);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        DataRow rw = dtTablaImpExcesoCuota.NewRow();
                        rw["contrato"] = DGW_DET.Rows[i].Cells["NRO_CONTRATO"].Value.ToString();
                        rw["cod_modular"] = DGW_DET.Rows[i].Cells["DES_IDENTIDAD"].Value.ToString();
                        rw["cod_pago"] = DGW_DET.Rows[i].Cells["DES_PROCESO"].Value.ToString();
                        rw["nom_clie"] = DGW_DET.Rows[i].Cells["DESC_PER"].Value.ToString();
                        rw["dni_ruc"] = DGW_DET.Rows[i].Cells["DNI"].Value.ToString();
                        rw["nro_planilla"] = row["NRO_PLANILLA_COB"].ToString();
                        rw["monto_dev"] = Convert.ToDecimal(row["IMP_DOC"]).ToString("###,###,##0.00");
                        dtTablaImpExcesoCuota.Rows.Add(rw);
                    }
                }
            }
            else
            {
                if (errMensaje != "")
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool validaCargar_Grid()
        {
            bool result = true;
            if (cbo_ptoCobranza.SelectedIndex <= -1)
            {
                MessageBox.Show("Elija Punto de Cobranza Consolidado !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_ptoCobranza.Focus();
                return result = false;
            }
            return result;
        }
        private void btn_grabar2_Click(object sender, EventArgs e)
        {
            if (!validaModificar())
                return;

            DialogResult rs = MessageBox.Show("¿ Esta seguro de modificar la Planilla ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                plcTo.NRO_PLANILLA_COB = txt_ser.Text + "-" + txt_num.Text;
                plcTo.COD_INSTITUCION = cbo_institucion.SelectedValue.ToString();
                plcTo.COD_PTO_COB_CONSOLIDADO = cbo_ptoCobranza.SelectedValue.ToString();
                plcTo.COD_CANAL_DSCTO = cbo_canaldscto.SelectedValue.ToString();
                plcTo.FE_AÑO = AÑO;//dtp_generacion.Value.ToShortDateString().Substring(6,4);
                plcTo.FE_MES = MES; dtp_generacion.Value.ToShortDateString().Substring(3, 2);
                plcTo.COD_SUCURSAL = cbo_sucursal.SelectedValue.ToString();
                //plcTo.COD_PTO_COB = CH_PV.Checked == true ? cbo_pto_cob.SelectedValue.ToString() : "";
                plcTo.COD_SECTORISTA = cbo_sectorista.SelectedValue.ToString();
                plcTo.COD_COBRADOR = cbo_cobrador.SelectedValue.ToString();
                plcTo.FECHA_PLANILLA_COB = dtp_generacion.Value;
                plcTo.FECHA_VEN_AL = dtp_fecven.Value;
                plcTo.FECHA_APROBACION = null;
                plcTo.FECHA_ENVIO = null;
                plcTo.FECHA_RECEPCION = null;
                plcTo.FECHA_PAGO = null;
                plcTo.STATUTS_APROBADO = "0";
                plcTo.STATUS_ENVIO = "0";
                plcTo.STATUS_RECEPCION = "0";
                plcTo.STATUS_PAGO = "0";
                plcTo.OBSERVACION = txt_obs.Text;
                plcTo.TIPO_PLANILLA = cbo_tipo_planilla.SelectedValue.ToString();
                plcTo.COD_CREACION = COD_USU;
                plcTo.FECHA_CREACION = dtp_generacion.Value;
                plcTo.COD_MOD = COD_USU;
                plcTo.FECHA_MOD = DateTime.Now;
                plcTo.COD_DOC = COD_DOCU;//"43";//esto es para planilla cobranza, en el futuro ponerlo en una enumeración
                plcTo.SERIE = txt_ser.Text;
                plcTo.STATUS_DOC = "0";
                plcTo.STATUS_NO_ENVIADO = CH_PV.Checked ? "1" : "0";
                plcTo.CANT_CONTRATOS = Convert.ToInt32(txt_ctas.Text);
                plcTo.IMP_ENVIO = Convert.ToDecimal(txt_totimp.Text);
                DataTable dtDetalle = obtenerDT();

                if (!plcBLL.modificaActualizaPlanillaBLL(plcTo, dtAnt, dtDetalle, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("La planilla se modificó correctamente", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TabControl1.SelectedTab = TabPage1;
                    DATAGRID();
                    FOCO_NUEVO_REG();
                }
            }
        }
        private void FOCO_NUEVO_REG()
        {
            int i, cont = 0;
            cont = dgw1.Columns.Count - 1;
            string nrocon = txt_ser.Text + "-" + txt_num.Text.Trim();
            for (i = 0; i <= cont; i++)
            {
                if (nrocon == dgw1.Rows[i].Cells["NRO_PLANILLA_COB"].Value.ToString().ToLower())
                {
                    dgw1.CurrentCell = dgw1.Rows[i].Cells["NRO_PLANILLA_COB"];
                    return;
                }
            }
        }
        private bool validaModificar()
        {
            bool result = true;
            int idx = dgw1.CurrentRow.Index;
            if (dgw1.Rows[idx].Cells["STATUS_ANULADO"].Value.ToString() == "1")
            {
                MessageBox.Show("No se puede Anular, pues ya esta anulado !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return result = false;
            }
            if (cbo_cobrador.SelectedIndex == -1)
            {
                MessageBox.Show("Elija el Cobrador !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_cobrador.Focus();
                return result = false;
            }
            return result;
        }
        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            TabControl1.SelectedTab = TabPage1;
            dtDet.Rows.Clear();
        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            if (!validaBotonModificar())
                return;
            boton = "MODIFICAR";
            BTN_GRABAR.Visible = false;
            btn_grabar2.Visible = true;
            btn_generar.Enabled = false;
            //cbo_ni.Visible = true;
            txt_ser.Visible = true;
            TabControl1.SelectedTab = (TabPage2);
            LIMPIAR_CABECERA();
            DGW_DET.Rows.Clear();
            Panel1.Visible = true;
            Panel0.Enabled = true;
            BTN_GRABAR.Enabled = true;
            btn_grabar2.Enabled = true;
            //BTN_GRABAR.Enabled = true;
            CARGAR_CABECERA();
            CARGAR_DETALLE();
            gb_oc.Enabled = false;
            gb_pt.Enabled = false;
            panel2.Enabled = true;
            CH_PV.Enabled = false;
            cbo_sucursal.Focus();
        }
        private bool validaBotonModificar()
        {
            bool result = true;
            int idx = dgw1.CurrentRow.Index;
            if (dgw1.Rows[idx].Cells["STATUS_ANULADO"].Value.ToString() == "1")
            {
                MessageBox.Show("No se puede modificar porque el registro esta Anulado !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return result = false;
            }
            if (Convert.ToBoolean(dgw1.Rows[idx].Cells["STATUTS_APROBADO"].Value))
            {
                MessageBox.Show("No se puede modificar porque el registro ya esta Aprobado !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return result = false;
            }
            if (dgw1.Rows[idx].Cells["STATUS_NO_ENVIADO"].Value.ToString() == "1")
            {
                MessageBox.Show("No se puede modificar porque no ha sido enviado, puedo consultarlo !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return result = false;
            }
            return result;
        }
        private void CARGAR_CABECERA()
        {
            int idx = dgw1.CurrentRow.Index;
            cbo_sucursal.SelectedValue = dgw1.Rows[idx].Cells["COD_SUCURSAL"].Value;
            cbo_institucion.SelectedValue = dgw1.Rows[idx].Cells["COD_INSTITUCION"].Value;
            cbo_ptoCobranza.SelectedValue = dgw1.Rows[idx].Cells["COD_PTO_COB_CONSOLIDADO"].Value;
            cbo_canaldscto.SelectedValue = dgw1.Rows[idx].Cells["COD_CANAL_DSCTO"].Value;
            if (dgw1.Rows[idx].Cells["COD_PTO_COB"].Value.ToString() != "")
            {
                llena_Pto_Cobranza_X_PtoCobConsolidado();
            }
            else
            {
                cbo_pto_cob.DataSource = null;
            }
            cbo_sectorista.SelectedValue = dgw1.Rows[idx].Cells["COD_SECTORISTA"].Value;
            txt_obs.Text = dgw1.Rows[idx].Cells["OBSERVACION"].Value.ToString();

            dtp_generacion.Value = Convert.ToDateTime(dgw1.Rows[idx].Cells["FECHA_PLANILLA_COB"].Value);
            dtp_fecven.Value = Convert.ToDateTime(dgw1.Rows[idx].Cells["FECHA_VEN_AL"].Value);
            cbo_tipo_planilla.SelectedValue = dgw1.Rows[idx].Cells["TIPO_PLANILLA"].Value.ToString().Trim();
            txt_ser.Text = dgw1.Rows[idx].Cells["NRO_PLANILLA_COB"].Value.ToString().Substring(0, 3);
            txt_num.Text = dgw1.Rows[idx].Cells["NRO_PLANILLA_COB"].Value.ToString().Substring(4, 7);
            if (dgw1.Rows[idx].Cells["COD_COBRADOR"].Value.ToString() != "")
            {
                llena_Cobradores();
                cbo_cobrador.SelectedValue = dgw1.Rows[idx].Cells["COD_COBRADOR"].Value;
            }
        }
        private void CARGAR_DETALLE()
        {
            planillaDetalleBLL pldBLL = new planillaDetalleBLL();
            planillaDetalleTo pldTo = new planillaDetalleTo();
            int idx = dgw1.CurrentRow.Index;
            pldTo.NRO_PLANILLA_COB = dgw1.Rows[idx].Cells["NRO_PLANILLA_COB"].Value.ToString();
            pldTo.COD_INSTITUCION = dgw1.Rows[idx].Cells["COD_INSTITUCION"].Value.ToString();
            pldTo.COD_PTO_COB_CONSOLIDADO = dgw1.Rows[idx].Cells["COD_PTO_COB_CONSOLIDADO"].Value.ToString();
            pldTo.COD_CANAL_DSCTO = dgw1.Rows[idx].Cells["COD_CANAL_DSCTO"].Value.ToString();
            pldTo.FE_AÑO = AÑO;
            pldTo.FE_MES = MES;
            dtAnt = pldBLL.obtener_I_Planilla_Detalle_BLL(pldTo);
            if (dtAnt.Rows.Count > 0)
            {
                DGW_DET.Rows.Clear();
                foreach (DataRow rw in dtAnt.Rows)
                {
                    int rowId = DGW_DET.Rows.Add();
                    DataGridViewRow row = DGW_DET.Rows[rowId];
                    row.Cells["NRO_CONTRATO"].Value = rw["NRO_CONTRATO"].ToString();
                    row.Cells["COD_PER"].Value = rw["COD_PER"].ToString();
                    row.Cells["DES_IDENTIDAD"].Value = rw["DES_IDENTIDAD"].ToString().Trim();
                    row.Cells["DES_PROCESO"].Value = rw["DES_PROCESO"].ToString().Trim();
                    row.Cells["DESC_PER"].Value = rw["DESC_PER"].ToString();
                    row.Cells["DNI"].Value = rw["DNI"].ToString();
                    row.Cells["COD_DOC"].Value = rw["COD_DOC"].ToString();
                    row.Cells["NRO_DOC"].Value = rw["NRO_DOC"].ToString().Trim();
                    row.Cells["FECHA_VEN"].Value = rw["FECHA_VEN"].ToString() == "" ? "" : rw["FECHA_VEN"].ToString().Substring(0, 10);
                    row.Cells["IMP_INI"].Value = rw["IMP_INI"].ToString();
                    row.Cells["SAL_IMP"].Value = rw["SAL_IMP"].ToString();
                    row.Cells["NRO_LETRA"].Value = rw["NRO_LETRA"].ToString();
                    row.Cells["TOTAL_LETRA"].Value = rw["TOT_LETRA"].ToString();
                    row.Cells["OBSERVACION"].Value = rw["OBSERVACION"].ToString();
                    row.Cells["COD_PTO_COB"].Value = rw["COD_PTO_COB"].ToString();
                    row.Cells["DESC_PTO_COB"].Value = rw["DESC_PTO_COB"].ToString();
                    row.Cells["COD_SUB_PTO_VEN"].Value = rw["COD_SUB_PTO_VEN"].ToString();
                    row.Cells["DESC_PTO_VEN"].Value = rw["DESC_PTO_VEN"].ToString();
                    row.Cells["NRO_CONTRATO_NRO_LETRA"].Value = rw["NRO_CONTRATO"].ToString() + rw["NRO_LETRA"].ToString();
                }
                dtDet = obtenerDT();//OBTIENE DEL GRID CON LOS CAMBIOS HECHOS HASTA EL MOMENTO
            }
            HALLAR_TOTALES();
            HALLAR_NRO_CONTRATOS();
            MOSTRAR_CANTIDAD_REGISTROS();
        }

        private void btn_adicionar_Click(object sender, EventArgs e)
        {
            DIALOGOS.CONSULTA_PARA_GENERACION_PLANILLA_COB OFR1 = new DIALOGOS.CONSULTA_PARA_GENERACION_PLANILLA_COB(cbo_ptoCobranza.SelectedValue.ToString(), dtp_generacion.Value);
            OFR1.ShowDialog();
            if (OFR1.DialogResult == DialogResult.Yes)
            {
                if (OFR1.DGW_CAB.Rows.Count > 0)
                {
                    //DGW_DET.Rows.Clear(); //NO SE DEBE DE LIMPIAR PUES PUEDE SER QUE HAYA MODIFICADO LOS VALORES ORIGINALES QUE TRAE EL GENERAR, AHORA SI PUES CUANDO MODIFICA ESTE BOTON ESTA DESHABILITADO
                    foreach (DataGridViewRow rw in OFR1.DGW_CAB.Rows)
                    {
                        if (Convert.ToBoolean(rw.Cells["OK"].Value))
                        {
                            int fil = 0;
                            if (!validaRegistroenelGrid(rw.Cells["NRO_CONTRATO"].Value.ToString(), ref fil))
                            {
                                MessageBox.Show("El contrato consultado ya se encuentra en la Planilla !!!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                DGW_DET.CurrentCell = DGW_DET.Rows[fil].Cells["NRO_CONTRATO"];
                                DGW_DET.BeginEdit(true);
                                return;
                            }
                            int rowId = DGW_DET.Rows.Add();
                            DataGridViewRow row = DGW_DET.Rows[rowId];
                            row.Cells["NRO_CONTRATO"].Value = rw.Cells["NRO_CONTRATO"].Value.ToString();
                            row.Cells["COD_PER"].Value = rw.Cells["COD_PER2"].Value.ToString();
                            row.Cells["DES_IDENTIDAD"].Value = rw.Cells["DES_IDENTIDAD"].Value.ToString().Trim();//
                            row.Cells["DES_PROCESO"].Value = rw.Cells["DES_PROCESO"].Value.ToString().Trim();//
                            row.Cells["DESC_PER"].Value = rw.Cells["DESC_PER2"].Value.ToString();
                            row.Cells["DNI"].Value = rw.Cells["DNI"].Value.ToString();
                            row.Cells["COD_DOC"].Value = rw.Cells["COD_DOC"].Value.ToString();
                            row.Cells["NRO_DOC"].Value = rw.Cells["NRO_DOCU"].Value.ToString().Trim();
                            row.Cells["FECHA_VEN"].Value = rw.Cells["FECHA_VEN"].Value.ToString().Substring(0, 10);
                            row.Cells["IMP_INI"].Value = rw.Cells["IMP_INI"].Value.ToString();
                            row.Cells["SAL_IMP"].Value = rw.Cells["IMP_DOC"].Value.ToString();
                            row.Cells["NRO_LETRA"].Value = rw.Cells["NRO_LETRA"].Value.ToString();
                            row.Cells["TOTAL_LETRA"].Value = rw.Cells["TOTAL_LETRA"].Value.ToString();
                            row.Cells["OBSERVACION"].Value = rw.Cells["OBSERVACION"].Value.ToString();
                            row.Cells["COD_PTO_COB"].Value = rw.Cells["COD_PTO_COB2"].Value.ToString();
                            row.Cells["DESC_PTO_COB"].Value = rw.Cells["DESC_PTO_COB"].Value.ToString();
                            row.Cells["COD_SUB_PTO_VEN"].Value = rw.Cells["COD_SUB_PTO_VEN"].Value.ToString();
                            row.Cells["DESC_PTO_VEN"].Value = rw.Cells["DESC_PTO_VEN"].Value.ToString();
                            row.Cells["NRO_CONTRATO_NRO_LETRA"].Value = rw.Cells["NRO_CONTRATO"].Value.ToString() + rw.Cells["NRO_LETRA"].Value.ToString();//para ordenar por este campo
                        }
                    }
                    dtDet = obtenerDT();//OBTIENE DEL GRID CON LOS CAMBIOS HECHOS HASTA EL MOMENTO
                }
                OFR1.Hide();
            }
            MOSTRAR_CANTIDAD_REGISTROS();
            HALLAR_TOTALES();
            HALLAR_NRO_CONTRATOS();
        }
        private bool validaRegistroenelGrid(string nro_contrato, ref int fil)
        {
            bool result = true;
            foreach (DataGridViewRow row in DGW_DET.Rows)
            {
                if (row.Cells["NRO_CONTRATO"].Value.ToString() == nro_contrato)
                {
                    fil = row.Cells["NRO_CONTRATO"].RowIndex;
                    return result = false;

                }
            }
            return result;
        }
        private void ELIMINA_REPETIDOS()
        {
            int m = 0;  // Apunta a la fila actual
            int n = DGW_DET.Rows.Count - 1;  // cantidad de filas en el DataGridView
            int k;
            string estaFila, unaFila;

            while (m < n)
            {
                k = 1;
                estaFila = String.Empty;

                // Relleno la cadena con los datos de toda la fila
                //for (int i = 0; i < DGW_DET.Columns.Count; i++)
                //estaFila = String.Concat(estaFila, DGW_DET.Rows[m].Cells[i].Value.ToString());
                estaFila = DGW_DET.Rows[m].Cells["NRO_CONTRATO"].Value.ToString();

                while (k < n)
                {
                    unaFila = String.Empty;  // Fila a comparar

                    //for (int i = 0; i < DGW_DET.Columns.Count; i++)
                    //    unaFila = String.Concat(unaFila, DGW_DET.Rows[k].Cells[i].Value.ToString());
                    unaFila = DGW_DET.Rows[k].Cells["NRO_CONTRATO"].Value.ToString();

                    if (String.Compare(estaFila, unaFila) == 0 && k != m)
                    {
                        DGW_DET.Rows.RemoveAt(k); // Si son iguales remuevo unaFila solamente
                        n--;     // Tamaño actual del DataGridView, al remover disminuye en uno
                    }
                    k++;
                }
                m++;
            }
        }

        private void btn_nuevo3_Click(object sender, EventArgs e)
        {
            gb_oc.Enabled = true;
            gb_pt.Enabled = true;
            BTN_GRABAR.Enabled = true;
            btn_grabar2.Enabled = true;
            LIMPIAR_CABECERA();
            txt_totimp.Clear();
            txt_ctas.Clear();
            DGW_DET.Rows.Clear();
            CH_PV.Enabled = true;
            VER_PTOS_COB_CONSOLIDADOS();
            dtDet.Rows.Clear();
        }

        private void btn_consulta_Click(object sender, EventArgs e)
        {
            if (dgw1.Rows.Count > 0)
            {
                if (!validaBotonConsulta())
                    return;
                boton = "CONSULTAR";
                gb_oc.Enabled = false;
                gb_pt.Enabled = false;
                panel2.Enabled = false;
                Panel0.Enabled = false;
                BTN_GRABAR.Enabled = false;
                btn_grabar2.Enabled = false;
                LIMPIAR_CABECERA();
                DGW_DET.Rows.Clear();
                CARGAR_CABECERA();
                CARGAR_DETALLE();
                TabControl1.SelectedTab = TabPage2;
                CH_PV.Enabled = false;
                PARA_NO_ENVIADOS();
                cbo_sucursal.Focus();
            }
        }
        private void PARA_NO_ENVIADOS()
        {
            int idx = dgw1.CurrentRow.Index;
            if (dgw1.Rows[idx].Cells["STATUS_NO_ENVIADO"].Value.ToString() == "1")
            {
                txt_totimp.Text = dgw1.Rows[idx].Cells["IMP_ENVIO"].Value.ToString();
                txt_ctas.Text = dgw1.Rows[idx].Cells["CANT_CONTRATOS"].Value.ToString();
            }
        }
        private bool validaBotonConsulta()
        {
            bool result = true;
            int idx = dgw1.CurrentRow.Index;
            if (dgw1.Rows[idx].Cells["STATUS_ANULADO"].Value.ToString() == "1")
            {
                MessageBox.Show("El registro esta Anulado !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return result = false;
            }
            return result;
        }
        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (!validaBotonEliminar())
                return;
            DialogResult rs = MessageBox.Show("¿ Esta seguro de eliminar esta Planilla ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                int idx = dgw1.CurrentRow.Index;
                plcTo.NRO_PLANILLA_COB = dgw1.Rows[idx].Cells["NRO_PLANILLA_COB"].Value.ToString();
                plcTo.COD_INSTITUCION = dgw1.Rows[idx].Cells["COD_INSTITUCION"].Value.ToString();
                plcTo.COD_PTO_COB_CONSOLIDADO = dgw1.Rows[idx].Cells["COD_PTO_COB_CONSOLIDADO"].Value.ToString();
                plcTo.COD_CANAL_DSCTO = dgw1.Rows[idx].Cells["COD_CANAL_DSCTO"].Value.ToString();
                plcTo.FE_AÑO = dgw1.Rows[idx].Cells["FE_AÑO"].Value.ToString();
                plcTo.FE_MES = dgw1.Rows[idx].Cells["FE_MES"].Value.ToString();
                plcTo.COD_MOD = COD_USU;
                plcTo.FECHA_MOD = DateTime.Now;
                DataTable dtDetalle = obtenerDT();

                planillaDetalleBLL pldBLL = new planillaDetalleBLL();
                planillaDetalleTo pldTo = new planillaDetalleTo();
                pldTo.NRO_PLANILLA_COB = plcTo.NRO_PLANILLA_COB;
                pldTo.COD_INSTITUCION = plcTo.COD_INSTITUCION;
                pldTo.COD_PTO_COB_CONSOLIDADO = plcTo.COD_PTO_COB_CONSOLIDADO;
                pldTo.COD_CANAL_DSCTO = plcTo.COD_CANAL_DSCTO;
                pldTo.FE_AÑO = plcTo.FE_AÑO;
                pldTo.FE_MES = plcTo.FE_MES;
                DataTable dtDet = pldBLL.obtener_I_Planilla_Detalle_BLL(pldTo);

                if (!plcBLL.eliminaPlanillaCobBLL(plcTo, dtDet, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("La planilla se eliminó correctamente", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TabControl1.SelectedTab = TabPage1;
                    DATAGRID();
                }
            }
        }
        private bool validaBotonEliminar()
        {
            bool result = true;
            int idx = dgw1.CurrentRow.Index;
            if (dgw1.Rows[idx].Cells["STATUS_ANULADO"].Value.ToString() == "1")
            {
                MessageBox.Show("No se puede eliminar porque el registro esta Anulado !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return result = false;
            }
            if (Convert.ToBoolean(dgw1.Rows[idx].Cells["STATUTS_APROBADO"].Value))
            {
                MessageBox.Show("No se puede eliminar porque el registro ya esta Aprobado !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return result = false;
            }
            return result;
        }
        private void btn_anul_Click(object sender, EventArgs e)
        {
            if (!validaBotonAnular())
                return;
            DialogResult rs = MessageBox.Show("¿ Esta seguro de anular esta Planilla ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                int idx = dgw1.CurrentRow.Index;
                plcTo.NRO_PLANILLA_COB = dgw1.Rows[idx].Cells["NRO_PLANILLA_COB"].Value.ToString();
                plcTo.COD_INSTITUCION = dgw1.Rows[idx].Cells["COD_INSTITUCION"].Value.ToString();
                plcTo.COD_PTO_COB_CONSOLIDADO = dgw1.Rows[idx].Cells["COD_PTO_COB_CONSOLIDADO"].Value.ToString();
                plcTo.COD_CANAL_DSCTO = dgw1.Rows[idx].Cells["COD_CANAL_DSCTO"].Value.ToString();
                plcTo.FE_AÑO = dgw1.Rows[idx].Cells["FE_AÑO"].Value.ToString();
                plcTo.FE_MES = dgw1.Rows[idx].Cells["FE_MES"].Value.ToString();
                plcTo.COD_MOD = COD_USU;
                plcTo.FECHA_MOD = DateTime.Now;

                if (!plcBLL.anulaPlanillaCobBLL(plcTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("La planilla se anuló correctamente", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TabControl1.SelectedTab = TabPage1;
                    DATAGRID();
                }
            }
        }
        private bool validaBotonAnular()
        {
            bool result = true;
            int idx = dgw1.CurrentRow.Index;
            if (dgw1.Rows[idx].Cells["STATUS_ANULADO"].Value.ToString() == "1")
            {
                MessageBox.Show("El registro ya esta Anulado !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return result = false;
            }
            if (dgw1.Rows[idx].Cells["STATUTS_APROBADO"].Value.ToString() == "1")
            {
                MessageBox.Show("El registro ya esta Aprobado !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return result = false;
            }
            return result;
        }
        private void cbo_ptoCobranza_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_ptoCobranza.SelectedValue != null)
            {
                llena_Pto_Cobranza_X_PtoCobConsolidado();
                CARGAR_SECTORISTA();
                llena_Sectorista();
                llena_Cobradores();
            }
        }
        private void llena_Sectorista()
        {
            puntoCobranzaBLL ptoBLL = new puntoCobranzaBLL();
            puntoCobranzaTo ptoTo = new puntoCobranzaTo();
            ptoTo.COD_PTO_COB = cbo_ptoCobranza.SelectedValue.ToString();
            DataTable dt = ptoBLL.obtenerSectoristaPuntosCobranzaBLL(ptoTo);
            cbo_sectorista.SelectedValue = dt.Rows[0]["COD_SECTORISTA"];
        }

        private void cbo_sectorista_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_sectorista.SelectedValue != null)
                llena_Sectorista();
        }
        private void llena_Cobradores()
        {
            progNivelBLL prnBLL = new progNivelBLL();
            progNivelTo prnTo = new progNivelTo();
            prnTo.COD_PER = cbo_sectorista.SelectedValue.ToString();
            prnTo.COD_NIVEL = "02";//02 cobrador, 03 gestor
            DataTable dt = prnBLL.obtenerCobradoresxSectoristaBLL(prnTo);
            cbo_cobrador.ValueMember = "COD_EQCOB";
            cbo_cobrador.DisplayMember = "DESC_EQVTA";
            cbo_cobrador.DataSource = dt;
            //cbo_cobrador.SelectedIndex = -1;
            cbo_cobrador.Text = "OFICINA OFICINA OFICINA";
        }
        private void llena_Pto_Cobranza_X_PtoCobConsolidado()
        {
            if (cbo_ptoCobranza.SelectedValue != null)
            {
                puntoCobranzaBLL ptoBLL = new puntoCobranzaBLL();
                puntoCobranzaTo ptoTo = new puntoCobranzaTo();
                ptoTo.COD_PTO_COB = cbo_ptoCobranza.SelectedValue.ToString();
                DataTable dt = ptoBLL.obtenerPtoCobranzaxPtoCobConsolidadoBLL(ptoTo);
                cbo_pto_cob.ValueMember = "COD_PTO_COB";
                cbo_pto_cob.DisplayMember = "DESC_PTO_COB";
                DataRow rw = dt.NewRow();
                rw["COD_PTO_COB"] = "0";
                rw["DESC_PTO_COB"] = "TODOS";
                dt.Rows.InsertAt(rw, 0);
                cbo_pto_cob.DataSource = dt;
                cbo_pto_cob.SelectedIndex = 0;
            }
        }

        private void btnAprobar_Click(object sender, EventArgs e)
        {
            if (!validaBotonAprobar())
                return;
            DialogResult rs = MessageBox.Show("¿ Esta seguro de aprobar esta Planilla ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                int idx = dgw1.CurrentRow.Index;
                plcTo.NRO_PLANILLA_COB = dgw1.Rows[idx].Cells["NRO_PLANILLA_COB"].Value.ToString();
                plcTo.COD_INSTITUCION = dgw1.Rows[idx].Cells["COD_INSTITUCION"].Value.ToString();
                plcTo.COD_PTO_COB_CONSOLIDADO = dgw1.Rows[idx].Cells["COD_PTO_COB_CONSOLIDADO"].Value.ToString();
                plcTo.COD_CANAL_DSCTO = dgw1.Rows[idx].Cells["COD_CANAL_DSCTO"].Value.ToString();
                plcTo.FE_AÑO = dgw1.Rows[idx].Cells["FE_AÑO"].Value.ToString();
                plcTo.FE_MES = dgw1.Rows[idx].Cells["FE_MES"].Value.ToString();
                plcTo.FECHA_APROBACION = DateTime.Now;
                plcTo.FECHA_ENVIO = plcTo.FECHA_APROBACION;//si es planilla directa
                plcTo.IMP_ENVIO = Convert.ToDecimal(dgw1.Rows[idx].Cells["IMP_ENVIO"].Value);//si es planilla directa
                plcTo.COD_MOD = COD_USU;
                plcTo.FECHA_MOD = DateTime.Now;
                plcTo.COD_TIPO_OPERACION = dgw1.Rows[idx].Cells["COD_TIPO_OPERACION"].Value.ToString();
                DataTable dtDetalle = null;
                if (plcTo.COD_TIPO_OPERACION == "D")//AQUI NUNCA ENTRA, COD_TIPO_OPERACION ES PP 
                {
                    CARGAR_DETALLE();
                    dtDetalle = HelpersBLL.obtenerDT(DGW_DET);
                    dtDetalle.Columns["NRO_CONTRATO"].ColumnName = "NRO_CONTRATO_Det";
                    dtDetalle.Columns["NRO_DOC"].ColumnName = "NRO_DOC_Det";
                }
                if (!plcBLL.aprobarPlanillaCobranzaBLL(plcTo, dtDetalle, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("La planilla se aprobó correctamente", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TabControl1.SelectedTab = TabPage1;
                    DATAGRID();
                }
            }
        }
        private bool validaBotonAprobar()
        {
            bool result = true;
            int idx = dgw1.CurrentRow.Index;
            if (dgw1.Rows[idx].Cells["STATUS_ANULADO"].Value.ToString() == "1")
            {
                MessageBox.Show("No se puede aprobar porque el registro esta Anulado !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return result = false;
            }
            if (Convert.ToBoolean(dgw1.Rows[idx].Cells["STATUTS_APROBADO"].Value))
            {
                MessageBox.Show("El registro ya está Aprobado !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return result = false;
            }
            return result;
        }
        private void HALLAR_NRO_CONTRATOS()
        {
            int n = 0; //int j = 0;
            if (DGW_DET.Rows.Count > 0)
            {
                DataTable dtN = obtenerDT();
                n = dtN.AsEnumerable().Where(x => x.Field<string>("NRO_CONTRATO") != "0000000").Select(x => x.Field<string>("NRO_CONTRATO")).Distinct().Count();
                txt_ctas.Text = n.ToString();
            }
            else
                txt_ctas.Text = "0";
        }

        private void cbo_tipo_planilla_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_tipo_planilla.SelectedValue != null)
            {
                lbl_cod_tipo_plla.Text = cbo_tipo_planilla.SelectedValue.ToString();
                obtieneNroPlanilla();
            }
        }

        private void CH_PV_CheckedChanged(object sender, EventArgs e)
        {
            if (CH_PV.Checked)
                txt_obs.Focus();
        }

        private void cbo_pto_cob_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_pto_cob.SelectedValue != null)
            {
                if (dtDet.Rows.Count > 0)
                {
                    //dtDet = obtenerDT();
                    DataView dv;
                    if (cbo_pto_cob.SelectedIndex != 0)//Column14
                        dv = new DataView(dtDet, "COD_PTO_COB = '" + cbo_pto_cob.SelectedValue.ToString() + "'", "COD_PTO_COB Asc", DataViewRowState.CurrentRows);
                    else
                        dv = new DataView(dtDet);
                    DGW_DET.Rows.Clear();
                    foreach (DataRow rw in dv.ToTable().Rows)
                    {
                        int rowId = DGW_DET.Rows.Add();
                        DataGridViewRow row = DGW_DET.Rows[rowId];
                        row.Cells["NRO_CONTRATO"].Value = rw["NRO_CONTRATO"].ToString();
                        row.Cells["COD_PER"].Value = rw["COD_PER"].ToString();
                        row.Cells["DES_IDENTIDAD"].Value = rw["DES_IDENTIDAD"].ToString().Trim();
                        row.Cells["DES_PROCESO"].Value = rw["DES_PROCESO"].ToString().Trim();
                        row.Cells["DESC_PER"].Value = rw["DESC_PER"].ToString();
                        row.Cells["DNI"].Value = rw["DNI"].ToString();
                        row.Cells["COD_DOC"].Value = rw["COD_DOC"].ToString();
                        row.Cells["NRO_DOC"].Value = rw["NRO_DOC"].ToString().Trim();
                        row.Cells["FECHA_VEN"].Value = rw["FECHA_VEN"].ToString() == "" ? "" : rw["FECHA_VEN"].ToString().Substring(0, 10);
                        row.Cells["IMP_INI"].Value = rw["IMP_INI"].ToString();
                        row.Cells["SAL_IMP"].Value = rw["SAL_IMP"].ToString();
                        row.Cells["NRO_LETRA"].Value = rw["NRO_LETRA"].ToString();
                        row.Cells["TOTAL_LETRA"].Value = rw["TOTAL_LETRA"].ToString();
                        row.Cells["OBSERVACION"].Value = rw["OBSERVACION"].ToString();
                        row.Cells["COD_PTO_COB"].Value = rw["COD_PTO_COB"].ToString();
                        row.Cells["DESC_PTO_COB"].Value = rw["DESC_PTO_COB"].ToString();
                        row.Cells["COD_SUB_PTO_VEN"].Value = rw["COD_SUB_PTO_VEN"].ToString();
                        row.Cells["DESC_PTO_VEN"].Value = rw["DESC_PTO_VEN"].ToString();
                        row.Cells["NRO_CONTRATO_NRO_LETRA"].Value = rw["NRO_CONTRATO"].ToString() + rw["NRO_LETRA"].ToString();
                    }
                    HALLAR_TOTALES();
                    HALLAR_NRO_CONTRATOS();
                }
            }
        }

        private void txt_letra_TextChanged(object sender, EventArgs e)
        {
            int i;
            if (ch_cod.Checked)
            {
                txt_letra.Focus();
                for (i = 0; i < dgw1.Rows.Count; i++)
                {
                    if (txt_letra.TextLength <= dgw1[0, i].Value.ToString().Length)
                    {
                        if (txt_letra.Text.ToLower() == dgw1[0, i].Value.ToString().Substring(0, txt_letra.TextLength).ToLower())
                        {
                            dgw1.CurrentCell = dgw1.Rows[i].Cells[0];
                            break;
                        }
                    }

                }
            }
            else if (ch_rs.Checked)
            {
                txt_letra.Focus();
                for (i = 0; i < dgw1.Rows.Count; i++)
                {
                    if (txt_letra.TextLength <= dgw1[5, i].Value.ToString().Length)
                    {
                        if (txt_letra.Text.ToLower() == dgw1[5, i].Value.ToString().Substring(0, txt_letra.TextLength).ToLower())
                        {
                            dgw1.CurrentCell = dgw1.Rows[i].Cells[5];
                            break;
                        }
                    }
                }
            }
        }

        private void ch_cod_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_cod.Checked)
            {
                dgw1.Sort(dgw1.Columns[0], System.ComponentModel.ListSortDirection.Ascending);
                btn_buscar.Enabled = false;
                btn_sgt.Enabled = false;
                txt_letra.Clear();
                txt_letra.Focus();
            }
        }

        private void ch_rs_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_rs.Checked)
            {
                dgw1.Sort(dgw1.Columns[5], System.ComponentModel.ListSortDirection.Ascending);
                btn_buscar.Enabled = false;
                btn_sgt.Enabled = false;
                txt_letra.Clear();
                txt_letra.Focus();
            }
        }

        private void ch_ca_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_ca.Checked)
            {
                btn_buscar.Enabled = true;
                txt_letra.Clear();
                txt_letra.Focus();
            }
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            int i, f;
            txt_letra.Focus();
            btn_sgt.Enabled = true;
            for (i = 0; i < dgw1.Rows.Count; i++)
            {
                for (f = 0; f <= dgw1[0, i].Value.ToString().Length - txt_letra.TextLength; f++)
                {
                    if (txt_letra.TextLength <= dgw1[0, i].Value.ToString().Length)
                    {
                        if (txt_letra.Text.ToLower() == dgw1[0, i].Value.ToString().Substring(f, txt_letra.TextLength).ToLower())
                        {
                            dgw1.CurrentCell = dgw1.Rows[i].Cells[0];
                            fila = i + 1;
                            return;
                        }
                    }
                }
            }
        }

        private void btn_sgt_Click(object sender, EventArgs e)
        {
            int i, f;//antes de dar a siguiente primero se hace buscar para que lo ubique en la primera coincidencia luego se da siguiente, siguiente..., hasta encontrar el valor buscado.
            for (i = fila; i < dgw1.Rows.Count; i++)
            {
                for (f = 0; f <= dgw1[0, i].Value.ToString().Length - txt_letra.TextLength; f++)
                {
                    if (txt_letra.TextLength <= dgw1[0, i].Value.ToString().Length)
                    {
                        if (txt_letra.Text.ToLower() == dgw1[0, i].Value.ToString().Substring(f, txt_letra.TextLength).ToLower())
                        {
                            dgw1.CurrentCell = dgw1.Rows[i].Cells[0];
                            fila = i + 1;
                            return;
                        }
                    }
                }
            }
            MessageBox.Show("Ya no existen más registros !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        public class DGVComparer : System.Collections.IComparer
        {
            public int Compare(object x, object y)
            {
                DataGridViewRow row1 = (DataGridViewRow)x;
                DataGridViewRow row2 = (DataGridViewRow)y;

                int compareResult = string.Compare(
                    (string)row1.Cells[0].Value,
                    (string)row2.Cells[0].Value);

                if (compareResult == 0)
                {
                    compareResult = ((int)row1.Cells[1].Value).CompareTo((int)row2.Cells[1].Value);
                }

                return compareResult;
            }
        }
        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (TabControl1.SelectedTab == TabPage2)
            //{
            //    if (boton == "NUEVO")
            //    {
            //        //boton = "DETALLES1";
            //    }
            //    else if (boton == "MODIFICAR")
            //    {
            //        //boton = "DETALLES2";
            //    }
            //    else
            //    {
            //        boton = "DETALLES";
            //        if (dgw1.Rows.Count > 0)
            //        {
            //            LIMPIAR_CABECERA();
            //            CARGAR_CABECERA();
            //            DGW_DET.Rows.Clear();
            //            CARGAR_DETALLE();
            //        }
            //        Panel1.Visible = true;
            //        Panel1.Enabled = false;
            //        btn_cancelar.Enabled = true;
            //        btn_nuevo3.Enabled = true;
            //        btn_Imprimir.Enabled = true;
            //    }
            //}
            //else
            //    btn_nuevo.Select();

        }

        private void cbo_institucion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_institucion.SelectedValue != null)
                CARGAR_PTO_COBRANZA_CONSOLIDADO();
        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            personaMaestroBLL pBLL = new personaMaestroBLL();
            personaMaestroTo pTo = new personaMaestroTo();
            pTo.COD_PER = DGW_DET.CurrentRow.Cells["COD_PER"].Value.ToString();
            DataTable dt = pBLL.obtenerMaestroPersonaporCOD_PERBLL(pTo);
            if (dt.Rows.Count > 0)
            {
                DGW_DET.CurrentRow.Cells["DES_IDENTIDAD"].Value = dt.Rows[0]["DES_IDENTIDAD"].ToString().Trim();
                DGW_DET.CurrentRow.Cells["DES_PROCESO"].Value = dt.Rows[0]["DES_PROCESO"].ToString().Trim();
                DGW_DET.CurrentRow.Cells["DESC_PER"].Value = dt.Rows[0]["Razon Social"].ToString().Trim();
                DGW_DET.CurrentRow.Cells["DNI"].Value = dt.Rows[0]["Nroº Doc."].ToString().Trim();
            }

        }

        private void txt_letra1_TextChanged(object sender, EventArgs e)
        {
            int i;
            if (ch_cod1.Checked)
            {
                txt_letra1.Focus();
                for (i = 0; i < DGW_DET.Rows.Count; i++)
                {
                    if (txt_letra1.TextLength <= DGW_DET[0, i].Value.ToString().Length)
                    {
                        if (txt_letra1.Text.ToLower() == DGW_DET[0, i].Value.ToString().Substring(0, txt_letra1.TextLength).ToLower())
                        {
                            DGW_DET.CurrentCell = DGW_DET.Rows[i].Cells[0];
                            break;
                        }
                    }

                }
            }
            else if (ch_rs1.Checked)
            {
                txt_letra1.Focus();
                for (i = 0; i < DGW_DET.Rows.Count; i++)
                {
                    if (txt_letra1.TextLength <= DGW_DET[4, i].Value.ToString().Length)
                    {
                        if (txt_letra1.Text.ToLower() == DGW_DET[4, i].Value.ToString().Substring(0, txt_letra1.TextLength).ToLower())
                        {
                            DGW_DET.CurrentCell = DGW_DET.Rows[i].Cells[4];
                            break;
                        }
                    }
                }
            }
        }

        private void ch_cod1_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_cod1.Checked)
            {
                DGW_DET.Sort(DGW_DET.Columns[0], System.ComponentModel.ListSortDirection.Ascending);
                btn_buscar1.Enabled = false;
                btn_sgt1.Enabled = false;
                txt_letra1.Clear();
                txt_letra1.Focus();
            }
        }

        private void ch_rs1_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_rs1.Checked)
            {
                DGW_DET.Sort(DGW_DET.Columns[4], System.ComponentModel.ListSortDirection.Ascending);
                btn_buscar1.Enabled = false;
                btn_sgt1.Enabled = false;
                txt_letra1.Clear();
                txt_letra1.Focus();
            }
        }

        private void ch_ca1_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_ca1.Checked)
            {
                btn_buscar1.Enabled = true;
                txt_letra1.Clear();
                txt_letra1.Focus();
            }
        }

        private void btn_buscar1_Click(object sender, EventArgs e)
        {
            int i, f;
            txt_letra1.Focus();
            btn_sgt1.Enabled = true;
            for (i = 0; i < DGW_DET.Rows.Count; i++)
            {
                for (f = 0; f <= DGW_DET[4, i].Value.ToString().Length - txt_letra1.TextLength; f++)
                {
                    if (txt_letra1.TextLength <= DGW_DET[4, i].Value.ToString().Length)
                    {
                        if (txt_letra1.Text.ToLower() == DGW_DET[4, i].Value.ToString().Substring(f, txt_letra1.TextLength).ToLower())
                        {
                            DGW_DET.CurrentCell = DGW_DET.Rows[i].Cells[4];
                            fila = i + 1;
                            return;
                        }
                    }
                }
            }
        }

        private void btn_sgt1_Click(object sender, EventArgs e)
        {
            int i, f;//antes de dar a siguiente primero se hace buscar para que lo ubique en la primera coincidencia luego se da siguiente, siguiente..., hasta encontrar el valor buscado.
            for (i = fila; i < DGW_DET.Rows.Count; i++)
            {
                for (f = 0; f <= DGW_DET[4, i].Value.ToString().Length - txt_letra1.TextLength; f++)
                {
                    if (txt_letra1.TextLength <= DGW_DET[4, i].Value.ToString().Length)
                    {
                        if (txt_letra1.Text.ToLower() == DGW_DET[4, i].Value.ToString().Substring(f, txt_letra1.TextLength).ToLower())
                        {
                            DGW_DET.CurrentCell = DGW_DET.Rows[i].Cells[4];
                            fila = i + 1;
                            return;
                        }
                    }
                }
            }
            MessageBox.Show("Ya no existen más registros !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

    }
}
