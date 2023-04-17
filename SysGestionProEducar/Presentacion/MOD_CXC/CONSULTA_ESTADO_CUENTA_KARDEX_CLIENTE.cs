using BLL;
using Entidades;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace Presentacion.MOD_CXC
{
    public partial class CONSULTA_ESTADO_CUENTA_KARDEX_CLIENTE : Form
    {
        canjeICtasxCobrarBLL ictasBLL = new canjeICtasxCobrarBLL();
        canjeICtasxCobrarTo ictasTo = new canjeICtasxCobrarTo();
        canjePCtasxCobrarBLL pctasBLL = new canjePCtasxCobrarBLL();
        canjePCtasxCobrarTo pctasTo = new canjePCtasxCobrarTo();
        DataTable dtDetalle = new DataTable();
        DataTable dtPersona;
        DataTable dtComprometidas;
        contratosSuspendidosBLL csBLL = new contratosSuspendidosBLL();
        HelpersBLL helBLL = new HelpersBLL();
        contratosSuspendidosTo csTo = new contratosSuspendidosTo();
        //HelpersTo helTo = new HelpersTo();
        string AÑO; string MES; DateTime FECHA_INI; DateTime FECHA_GRAL;
        DataTable dtSuspendidos;
        public CONSULTA_ESTADO_CUENTA_KARDEX_CLIENTE(string AÑO, string MES, DateTime FECHA_INI, DateTime FECHA_GRAL)
        {
            InitializeComponent();
            this.AÑO = AÑO;
            this.MES = MES;
            this.FECHA_INI = FECHA_INI;
            this.FECHA_GRAL = FECHA_GRAL;
        }
        private void CONSULTA_ESTADO_CUENTA_KARDEX_CLIENTE_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            CARGAR_PERSONAS();
            DGW_DET.EnableHeadersVisualStyles = false;
            colorearColumnas(DGW_DET);
            tlt_kardex_cliente.SetToolTip(btn_ve_exc_suspendido, "Descontado en el Periodo Suspendido");
            tlt_kardex_cliente.SetToolTip(btn_periodos_suspendidos, "Historial de Suspensiones");
        }
        private void CARGAR_PERSONAS()
        {
            //helTo.CODIGO = "04";//VENDEDORES
            dtPersona = helBLL.MOSTRAR_PERSONAS_X_CONSULTA_KARDEX_BLL();
            if (dtPersona.Rows.Count > 0)
            {
                dgw_per.DataSource = dtPersona;
                dgw_per.Columns["COD_PER"].HeaderText = "Codigo";
                dgw_per.Columns["COD_PER"].Width = 50;
                dgw_per.Columns["DESC_PER"].HeaderText = "Nombre de Persona";
                dgw_per.Columns["DESC_PER"].Width = 230;
                dgw_per.Columns["NRO_DOC"].HeaderText = "Dni / Ruc";
                dgw_per.Columns["NRO_DOC"].Width = 70;
                dgw_per.Columns["NRO_PRESUPUESTO"].HeaderText = "Contrato";
                dgw_per.Columns["NRO_PRESUPUESTO"].Width = 60;
                dgw_per.Columns["DESC_PROGRAMA"].HeaderText = "Programa";
                dgw_per.Columns["DESC_PROGRAMA"].Width = 120;
                dgw_per.Columns["DESC_INST"].HeaderText = "Institucion";
                dgw_per.Columns["DESC_INST"].Width = 120;
                dgw_per.Columns["COD_PROGRAMA"].Visible = false;
                dgw_per.Columns["COD_INSTITUCION"].Visible = false;
            }

        }
        private void colorearColumnas(DataGridView dgv)
        {
            for (int i = 0; i <= 6; i++)//Cuota Ejecutadas
            {
                dgv.Columns[i].HeaderCell.Style.BackColor = Color.LightGreen;
            }
            for (int i = 10; i <= 14; i++)//Cuota Devueltas o Aplicadas
            {
                dgv.Columns[i].HeaderCell.Style.BackColor = Color.LightSteelBlue;
            }
        }
        private void CONSULTA_ESTADO_CUENTA_KARDEX_CLIENTE_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }
        private void txt_nro_contrato_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //txt_nro_contrato.Text = txt_nro_contrato.Text.PadLeft(7, '0');
                buscarEstadoCuenta();
            }
        }
        private void buscarEstadoCuenta()
        {
            ictasTo.NRO_CONTRATO = txt_nro_contrato.Text;
            DataTable dt = ictasBLL.ConsultaEstadoCuentaKardexClienteBLL(ictasTo);
            if (dt.Rows.Count > 0)
            {
                txt_fec_contrato.Text = dt.Rows[0]["FECHA_PRE"].ToString().Substring(0, 10);
                txt_aprobado.Text = dt.Rows[0]["STATUS_APROB"].ToString() == "1" ? "SI" : "NO";
                txt_fe_apr.Text = txt_aprobado.Text == "SI" ? dt.Rows[0]["FECHA_APROB"].ToString().Substring(0, 10) : "";
                txt_cliente.Text = dt.Rows[0]["CLIENTE"].ToString();
                txt_dep_cli.Text = dt.Rows[0]["DEPT_CASA"].ToString();
                txt_prov_cli.Text = dt.Rows[0]["PROV_CASA"].ToString();
                txt_dist_cli.Text = dt.Rows[0]["DIST_CASA"].ToString();
                txt_dir_cli.Text = dt.Rows[0]["DIR_CASA"].ToString();
                txt_telf_fijo_cli.Text = dt.Rows[0]["FONO_FIJO_DOM"].ToString();
                txt_telf_cel_cli.Text = dt.Rows[0]["FONO_CEL_DOM"].ToString();
                txt_nom_trabajo.Text = dt.Rows[0]["TRABAJO"].ToString();
                txt_dep_tbjo.Text = dt.Rows[0]["DEPT_TBJO"].ToString();
                txt_prov_tbjo.Text = dt.Rows[0]["PROV_TBJO"].ToString();
                txt_dist_tbjo.Text = dt.Rows[0]["DIST_TBJO"].ToString();
                txt_dir_tbjo.Text = dt.Rows[0]["DIR_TBJO"].ToString();
                txt_telf_fijo_tbjo.Text = dt.Rows[0]["FONO_FIJO_TBJO"].ToString();
                txt_telf_cel_tbjo.Text = dt.Rows[0]["FONO_CEL_TBJO"].ToString();
                lbl_pto_cob.Text = dt.Rows[0]["PTO_COB"].ToString();
                lbl_pto_ven.Text = dt.Rows[0]["PTO_VEN"].ToString();

                lbl_almacen.Text = dt.Rows[0]["ALM"].ToString();
                lbl_vendedor.Text = dt.Rows[0]["VENDEDOR"].ToString();
                lbl_total.Text = string.Format("{0:N2}", dt.Rows[0]["TOTAL"]);
                if (Convert.ToDecimal(dt.Rows[0]["TOTAL"]) < Convert.ToDecimal(dt.Rows[0]["CANCELADO"]))//EXCESO DE CONTRATO
                {
                    lbl_cancelado.Text = string.Format("{0:N2}", dt.Rows[0]["TOTAL"]);
                    lbl_saldo.Text = "0.00";
                }
                else
                {
                    lbl_cancelado.Text = string.Format("{0:N2}", dt.Rows[0]["CANCELADO"]);
                    lbl_saldo.Text = (Convert.ToDecimal(lbl_total.Text) - Convert.ToDecimal(lbl_cancelado.Text)).ToString("###,###,##0.00");
                }
                lbl_aut_dscto.Text = txt_aprobado.Text == "SI" ? "NO" : "SI";
                lbl_fe_aut.Text = txt_aprobado.Text == "NO" ? dt.Rows[0]["FECHA_APROB"].ToString().Substring(0, 10) : "";
                lbl_area.Text = dt.Rows[0]["TIPO_PLANILLA"].ToString().Trim() == "P" ? "DESCUENTO" : dt.Rows[0]["TIPO_PLANILLA"].ToString().Trim() == "D" ? "DIRECTA" : "";
                lbl_situacion.Text = dt.Rows[0]["SITUACION"].ToString();
                dtDetalle.Rows.Clear();
                dtDetalle = ictasBLL.ConsultaEstadoCuentaKardexClienteDetalleBLL(ictasTo);
                csTo.NRO_CONTRATO = txt_nro_contrato.Text;
                csTo.ST_ANULACION = "0";
                dtSuspendidos = csBLL.obtenerContratosSuspendidosxContratoBLL(csTo);
                DGW_DET.Rows.Clear();
                int dias_morosidad = 0; int sum_dias_morosidad = 0;
                if (dtDetalle.Rows.Count > 0)
                {
                    foreach (DataRow rw in dtDetalle.Rows)
                    {
                        int rowId = DGW_DET.Rows.Add();
                        DataGridViewRow row = DGW_DET.Rows[rowId];
                        row.Cells["CUOTA"].Value = rw["CUOTA"].ToString();
                        row.Cells["IMP_DOC"].Value = string.Format("{0:N2}", rw["IMP_DOC"]);
                        row.Cells["SALDO"].Value = rw["COD_D_H"].ToString() == "H" ? string.Format("{0:N2}", rw["SALDO"]) : "0.00";
                        row.Cells["FECHA_VEN"].Value = rw["FECHA_VEN"].ToString().Substring(0, 10);
                        row.Cells["FECHA_DOC"].Value = rw["FECHA_PLANILLA"].ToString() != "" ? rw["FECHA_PLANILLA"].ToString().Substring(0, 10) : "";//rw["FECHA_DOC"].ToString().Substring(0,10);
                        //row.Cells["DIAS_MOROSIDAD"].Value = rw["FECHA_PLANILLA"].ToString() != "" ? (Convert.ToDateTime(row.Cells["FECHA_DOC"].Value) - (Convert.ToDateTime(row.Cells["FECHA_VEN"].Value))).ToString("dd") : "";
                        if (rw["FECHA_PLANILLA"].ToString() != "")
                        {
                            if (Convert.ToDateTime(row.Cells["FECHA_DOC"].Value) > Convert.ToDateTime(row.Cells["FECHA_VEN"].Value))
                            {
                                row.Cells["DIAS_MOROSIDAD"].Value = (Convert.ToDateTime(row.Cells["FECHA_DOC"].Value) - (Convert.ToDateTime(row.Cells["FECHA_VEN"].Value))).ToString("dd");
                                dias_morosidad = Convert.ToInt32(row.Cells["DIAS_MOROSIDAD"].Value);
                                sum_dias_morosidad += dias_morosidad;
                            }
                            else
                                row.Cells["DIAS_MOROSIDAD"].Value = "";//row.Cells["DIAS_MOROSIDAD"].Value = "-" + (Convert.ToDateTime(row.Cells["FECHA_DOC"].Value) - (Convert.ToDateTime(row.Cells["FECHA_VEN"].Value))).ToString("dd");
                        }
                        else
                            row.Cells["DIAS_MOROSIDAD"].Value = "";
                        row.Cells["NRO_PLANILLA"].Value = rw["NRO_PLANILLA"].ToString();
                        //row.Cells["FECHA_PLANILLA"].Value = rw["FECHA_PLANILLA"].ToString() != "" ? rw["FECHA_PLANILLA"].ToString().Substring(0,10) : "";
                        row.Cells["DESC_PTO_COB"].Value = rw["DESC_PTO_COB"].ToString();
                        row.Cells["EXC_CUOTA"].Value = rw["EXC_CUOTA"].ToString();//Convert.ToDecimal(lbl_saldo.Text) > 0 ? rw["EXC_CUOTA"].ToString() : "";
                        row.Cells["TIPO_PLA_COBRANZA"].Value = rw["TIPO_PLA_COBRANZA"].ToString();
                        row.Cells["DESC_TIPO"].Value = rw["DESC_TIPO"].ToString();
                        row.Cells["COD_D_H"].Value = rw["COD_D_H"].ToString();
                        row.Cells["SUSPENDIDOS"].Value = "";
                        ////para los comprometidos
                        //row.Cells["IMP_COMPROMETIDO_PLLA"].Value = rw["IMP_COMPROMETIDO_PLLA"].ToString();
                        //row.Cells["SALDO_DISP_ENV"].Value = rw["SALDO_DISP_ENV"].ToString();
                        //row.Cells["NRO_PLLA_ENV"].Value = rw["NRO_PLLA_ENV"].ToString();
                        //row.Cells["FE_PLLA_ENV"].Value = rw["FE_PLLA_ENV"].ToString() != "" ? rw["FE_PLLA_ENV"].ToString().Substring(0, 10) : "";
                    }
                    //para las cuotas comprometidas
                    dtComprometidas = ictasBLL.obtenerCuotasComprometidasxContratoBLL(ictasTo);
                    if (dtComprometidas.Rows.Count > 0)
                    {
                        for (int m = 0; m < dtComprometidas.Rows.Count; m++)
                        {
                            for (int n = 0; n < DGW_DET.Rows.Count; n++)
                            {
                                if (dtComprometidas.Rows[m]["CUOTA"].ToString() == DGW_DET.Rows[n].Cells["CUOTA"].Value.ToString())
                                {
                                    //if(DGW_DET.Rows[n].Cells["COD_D_H"].Value.ToString()=="H")
                                    //{
                                    DGW_DET.Rows[n].Cells["IMP_COMPROMETIDO_PLLA"].Value = dtComprometidas.Rows[m]["IMP_COMPROMETIDO_PLLA"].ToString();
                                    DGW_DET.Rows[n].Cells["SALDO_DISP_ENV"].Value = dtComprometidas.Rows[m]["SALDO_DISP_ENV"].ToString();
                                    DGW_DET.Rows[n].Cells["NRO_PLLA_ENV"].Value = dtComprometidas.Rows[m]["NRO_PLLA_ENV"].ToString();
                                    DGW_DET.Rows[n].Cells["FE_PLLA_ENV"].Value = dtComprometidas.Rows[m]["FE_PLLA_ENV"].ToString().Substring(0, 10);
                                    break;
                                    //}
                                }
                            }
                        }
                    }
                    lbl_tot_morosidad.Text = sum_dias_morosidad.ToString();
                    colorearFilas();
                }
                //SUSPENDIDOS
                ponerEtiquetaSuspendidos(dtSuspendidos);
                //estado
                if (Convert.ToDecimal(dt.Rows[0]["TOTAL"]) <= Convert.ToDecimal(dt.Rows[0]["IMP_DOC_ACUMULADO"]))
                {
                    string total_atraso = suma_total_atraso(DGW_DET);
                    lbl_estado.Text = "PAGADO EN SU TOTALIDAD ATRASO " + total_atraso + " DIAS (Suma de días de Morosidad)";
                }
                else
                {
                    pctasTo.COD_SUCURSAL = dt.Rows[0]["COD_SUCURSAL"].ToString();
                    pctasTo.COD_CLASE = dt.Rows[0]["COD_CLASE"].ToString();
                    pctasTo.NRO_CONTRATO = txt_nro_contrato.Text;
                    //DataTable dtT = tctasBLL.obtenerTctasxKardexContratoBLL(tctasTo);
                    DateTime fec_ult_venc = pctasBLL.obtenerPCtasxKardexContratoBLL(pctasTo);
                    if (fec_ult_venc <= DateTime.Now.Date)
                        lbl_estado.Text = "PAGANDO PARCIALMENTE ATRASO " + (DateTime.Now.Date - fec_ult_venc).ToString("dd") + " DIAS (Fe Actual - Fe Ult Cuota x vencer)";
                    else
                        lbl_estado.Text = "PAGANDO PARCIALMENTE";
                }
                //EXCESO DE CONTRATO
                if (Convert.ToDecimal(dt.Rows[0]["TOTAL"]) < Convert.ToDecimal(dt.Rows[0]["IMP_DOC_ACUMULADO"]))
                {
                    btn_ver_ex_contrato.Enabled = true;
                    lbl_exceso_contrato.Visible = true;
                    string errMensaje = "";
                    devPCtasCobrarBLL dvpBLL = new devPCtasCobrarBLL();
                    devPCtasCobrarTo dvpTo = new devPCtasCobrarTo();
                    dvpTo.NRO_CONTRATO = txt_nro_contrato.Text;
                    lbl_exceso_contrato.Text = "Total Exceso Contrato : " + dvpBLL.mostrar_suma_exceso_contrato_kardexBLL(dvpTo, ref errMensaje).ToString("###,###,##0.00");
                }
                else
                {
                    btn_ver_ex_contrato.Enabled = false;
                    lbl_exceso_contrato.Visible = false;
                }
                //DEVOLUCION X RECLAMOS
            }
            else
                MessageBox.Show("No existen registros con ese Nro de Contrato !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        private void colorearFilas() //colorea y pone saldos
        {
            int m = 0; decimal saldo = 0;
            for (int i = 0; i < DGW_DET.Rows.Count; i++)
            {
                if (i == DGW_DET.Rows.Count - 1)
                {
                    if (saldo == 0)
                    {
                        for (int j = m; j <= i; j++)
                        {
                            DGW_DET.Rows[j].DefaultCellStyle.ForeColor = Color.Black;
                            DGW_DET.Rows[j].DefaultCellStyle.BackColor = Color.FromArgb(255, 204, 204);
                        }
                    }
                    saldo = Convert.ToDecimal(DGW_DET.Rows[i].Cells["IMP_DOC"].Value);
                    DGW_DET.Rows[i].Cells["SALDO"].Value = saldo;
                    break;
                }
                if (DGW_DET.Rows[i].Cells["COD_D_H"].Value.ToString() == "D")
                {
                    m = i;
                    saldo = Convert.ToDecimal(DGW_DET.Rows[i].Cells["IMP_DOC"].Value);
                    DGW_DET.Rows[i].Cells["SALDO"].Value = saldo;
                    DGW_DET.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                    DGW_DET.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(255, 102, 255);
                }
                if (DGW_DET.Rows[i].Cells["CUOTA"].Value.ToString() == DGW_DET.Rows[i + 1].Cells["CUOTA"].Value.ToString())
                {
                    saldo = saldo - Convert.ToDecimal(DGW_DET.Rows[i + 1].Cells["IMP_DOC"].Value);
                    DGW_DET.Rows[i + 1].Cells["SALDO"].Value = saldo;
                    DGW_DET.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                    DGW_DET.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(255, 102, 255);
                }
                else
                {
                    if (saldo == Convert.ToDecimal(DGW_DET.Rows[i].Cells["IMP_DOC"].Value))
                    {
                        DGW_DET.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                        DGW_DET.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 255);
                    }
                    else if (saldo > 0)
                    {
                        DGW_DET.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                        DGW_DET.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(255, 102, 255);
                    }
                    else if (saldo == 0)
                    {
                        for (int j = m; j <= i; j++)
                        {
                            DGW_DET.Rows[j].DefaultCellStyle.ForeColor = Color.Black;
                            DGW_DET.Rows[j].DefaultCellStyle.BackColor = Color.FromArgb(255, 204, 204);
                        }
                    }
                }
            }
        }
        private void ponerEtiquetaSuspendidos(DataTable dt)
        {
            lbl_suspendido.Visible = false;
            //btn_periodos_suspendidos.Enabled = false;
            foreach (DataRow rw in dt.Rows)
            {
                if (Convert.ToDateTime(rw["FECHA_INI_SUS"]) <= FECHA_INI.Date && Convert.ToDateTime(rw["FECHA_FIN_SUS"]) >= FECHA_GRAL.Date && rw["ST_ANULACION"].ToString() == "0")
                {
                    lbl_suspendido.Text = "Este contrato está suspendido en el Presente Periodo";
                    lbl_suspendido.Visible = true;
                    //btn_periodos_suspendidos.Enabled = true;
                    break;
                }
            }
        }
        private string suma_total_atraso(DataGridView dw)
        {
            string sum = "";
            decimal suma = 0;
            foreach (DataGridViewRow row in dw.Rows)
            {
                if (row.Cells["DIAS_MOROSIDAD"].Value.ToString() != "")
                    suma += Convert.ToDecimal(row.Cells["DIAS_MOROSIDAD"].Value);
            }
            return sum = suma.ToString();
        }
        private void txt_nro_contrato_Leave(object sender, EventArgs e)
        {
            //txt_nro_contrato.Text = txt_nro_contrato.Text.PadLeft(7, '0');
        }

        private void CONSULTA_ESTADO_CUENTA_KARDEX_CLIENTE_Shown(object sender, EventArgs e)
        {
            txt_nro_contrato.Focus();
        }

        private void btn_ver_ex_contrato_Click(object sender, EventArgs e)
        {
            MOD_CXC.CONSULTA_EXCESO_CONTRATO frm = new CONSULTA_EXCESO_CONTRATO(txt_nro_contrato.Text);
            frm.ShowDialog();
        }

        private void btn_ver_dev_recl_Click(object sender, EventArgs e)
        {
            MOD_CXC.CONSULTA_DEV_X_RECLAMOS frm = new CONSULTA_DEV_X_RECLAMOS(txt_nro_contrato.Text);
            frm.ShowDialog();
        }

        private void btn_ver_cancelados_Click(object sender, EventArgs e)
        {
            var query = from item in Datos().AsEnumerable()
                        group item by item["DESC_TIPO"].ToString() into g
                        select new TablaCancelados
                        {
                            DESC_TIPO = g.Key,
                            CantRegistros = g.Count(),
                            Total = g.Sum(x => Convert.ToDecimal(x["IMP_DOC"]))
                        };

            DataTable resultado = query.CopyToDataTableT<TablaCancelados>();//CopyToDataTableT es un codigo de una clase que copié de internet
            foreach (DataRow rw in resultado.Rows)
            {
                rw["DESC_TIPO"] = rw["DESC_TIPO"].ToString().Substring(0, rw["DESC_TIPO"].ToString().Length - 14);
            }
            var query2 = from item in resultado.AsEnumerable()
                         group item by item["DESC_TIPO"].ToString() into g
                         select new TablaCancelados
                         {
                             DESC_TIPO = g.Key,
                             CantRegistros = g.Count(),
                             Total = g.Sum(x => Convert.ToDecimal(x["Total"]))
                         };
            DataTable resultado2 = query2.CopyToDataTableT<TablaCancelados>();//CopyToDataTableT es un codigo de una clase que copié de internet
            MOD_CXC.RESUMEN_CANCELADOS_X_TIPO_PLANILLA frm = new RESUMEN_CANCELADOS_X_TIPO_PLANILLA(resultado2);
            frm.ShowDialog();
        }

        private DataTable Datos()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("DESC_TIPO");
            dt.Columns.Add("IMP_DOC");
            if (dtDetalle.Rows.Count > 0)
            {
                foreach (DataRow rw in dtDetalle.Rows)
                {
                    if (rw["COD_D_H"].ToString() == "H")
                    {
                        DataRow row = dt.NewRow();
                        row["DESC_TIPO"] = rw["TIPO_PLA_COBRANZA"].ToString() + " - " + rw["DESC_TIPO"].ToString() + " - " + rw["NRO_PLANILLA"].ToString();
                        row["IMP_DOC"] = rw["IMP_DOC"].ToString();
                        dt.Rows.Add(row);
                    }
                }
            }
            return dt;
        }

        private void DGW_DET_DoubleClick(object sender, EventArgs e)
        {

        }

        private void DGW_DET_SelectionChanged(object sender, EventArgs e)
        {
            DGW_DET.ClearSelection();
        }

        private void dgw_per_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_nro_contrato.Text = dgw_per.CurrentRow.Cells["NRO_PRESUPUESTO"].Value.ToString();
                buscarEstadoCuenta();
                Panel_PER.Visible = false;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Panel_PER.Visible = false;

            }
        }

        private void txt_cliente_Leave(object sender, EventArgs e)
        {
            if (txt_cliente.Text == "")
            {
                txt_cliente.Focus();
            }
            else
            {
                if (dgw_per.Rows.Count > 0)
                {
                    dgw_per.Sort(dgw_per.Columns[1], System.ComponentModel.ListSortDirection.Ascending);
                    int i = 0, num2 = 0;
                    num2 = dgw_per.Rows.Count;
                    do
                    {
                        if (dgw_per[1, i].Value.ToString().Length >= txt_cliente.TextLength)
                        {
                            if (txt_cliente.Text.ToLower() == dgw_per[1, i].Value.ToString().ToLower().Substring(0, txt_cliente.TextLength).ToLower())
                            {
                                dgw_per.CurrentCell = dgw_per.Rows[i].Cells[0];
                                break;
                            }
                        }
                        dgw_per.CurrentCell = dgw_per.Rows[0].Cells[0];
                        i += 1;
                    }
                    while (i < num2);
                    Panel_PER.Visible = true;
                    dgw_per.Visible = true;
                    dgw_per.Focus();
                }
            }
        }

        private void btn_ve_exc_suspendido_Click(object sender, EventArgs e)
        {
            MOD_CXC.CONSULTA_CONTRATOS_SUSPENDIDOS_X_APLICAR_O_DEVOLVER frm = new CONSULTA_CONTRATOS_SUSPENDIDOS_X_APLICAR_O_DEVOLVER(txt_nro_contrato.Text);
            frm.ShowDialog();
        }

        private void btn_periodos_suspendidos_Click(object sender, EventArgs e)
        {
            MOD_CXC.HISTORIAL_CONTRATOS_SUSPENDIDOS frm = new HISTORIAL_CONTRATOS_SUSPENDIDOS(dtSuspendidos);
            frm.ShowDialog();
        }
        private void DGW_DET_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            decimal num = 0;
            if (e.RowIndex > -1 && e.ColumnIndex == 9)
            {
                if (decimal.TryParse(DGW_DET.CurrentRow.Cells["EXC_CUOTA"].Value.ToString(), out num))
                {
                    MOD_CXC.CONSULTA_EXC_CUOTA frm = new CONSULTA_EXC_CUOTA(DGW_DET.CurrentRow.Cells["NRO_PLANILLA"].Value.ToString(), txt_nro_contrato.Text);
                    frm.ShowDialog();
                }
            }
            else if (e.ColumnIndex == 6)
            {
                if (DGW_DET.CurrentRow.Cells["NRO_PLANILLA"].Value.ToString() != "")
                {
                    //MOD_CXC.RECEPCION_I_PLANILLAS frm = new RECEPCION_I_PLANILLAS();
                    string nro_planilla = DGW_DET.CurrentRow.Cells["NRO_PLANILLA"].Value.ToString();
                    string tipo_plla = DGW_DET.CurrentRow.Cells["TIPO_PLA_COBRANZA"].Value.ToString();
                    MOD_CXC.CONSULTA_PLANILLA_DESCUENTO_X_NRO_PLANILLA frm = new CONSULTA_PLANILLA_DESCUENTO_X_NRO_PLANILLA(nro_planilla, tipo_plla);
                    frm.Show();
                }
            }
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            MOD_CXC.HISTORIAL_TRANSFERENCIA_TIPO_PLANILLA frm = new HISTORIAL_TRANSFERENCIA_TIPO_PLANILLA(txt_nro_contrato.Text);
            frm.ShowDialog();
        }
    }

    public class TablaCancelados
    {
        //public string NRO_PLANILLA { get; set; }
        public string DESC_TIPO { get; set; }
        public int CantRegistros { get; set; }
        public decimal Total { get; set; }

    }
}
