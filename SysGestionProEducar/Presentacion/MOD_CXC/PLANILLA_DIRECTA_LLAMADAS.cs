using BLL;
using Entidades;
using System;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Presentacion.MOD_CXC
{
    public partial class PLANILLA_DIRECTA_LLAMADAS : Form
    {
        planillaDirectaBLL pldBLL = new planillaDirectaBLL();
        planillaDirectaTo pldTo = new planillaDirectaTo();
        calendarioBLL calBLL = new calendarioBLL();
        calendarioTo calTo = new calendarioTo();
        string AÑO, MES, COD_MOD, TIPO_USU, COD_USU, TIPO;
        DateTime FECHA_INI, FECHA_GRAL;
        DataTable dtDet = new DataTable();
        MOD_CXC.CONTRATOS_VENCIDOS_PD frm = new CONTRATOS_VENCIDOS_PD();

        public PLANILLA_DIRECTA_LLAMADAS(string AÑO, string MES, DateTime FECHA_INI, DateTime FECHA_GRAL, string COD_MOD, string TIPO_USU, string COD_USU, string TIPO)
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

        private void PLANILLA_DIRECTA_LLAMADAS_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            //lbl_fec_llamada.Text = DateTime.Now.AddMonths(6).AddDays(1).ToShortDateString();
            calTo.TIPO = TIPO;
            lbl_fec_llamada.Text = Convert.ToDateTime(calBLL.obtenerFechaActivaBLL(calTo)).ToShortDateString();
            dtp_vcto.Value = Convert.ToDateTime(lbl_fec_llamada.Text);
            CARGAR_SECTORISTA();
            DATAGRID();
            btn_Historial.Visible = TIPO == "P" ? true : false;
        }

        private void PLANILLA_DIRECTA_LLAMADAS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void CARGAR_SECTORISTA()
        {
            progNivelBLL prnBLL = new progNivelBLL();
            DataTable dtEqc = prnBLL.obtenerSectoristasparaCrearEqCobradoresBLL("01");//02 Cobradores
            cbo_sectorista.ValueMember = "COD_EQCOB";
            cbo_sectorista.DisplayMember = "DESC_EQVTA";
            DataRow rw = dtEqc.NewRow();
            rw["COD_EQCOB"] = "0";
            rw["DESC_EQVTA"] = "Sectoristas";
            rw["NRO_DOC"] = "";
            rw["COD_PROGRAMA"] = "";
            rw["DESC_PROGRAMA"] = "";
            dtEqc.Rows.InsertAt(rw, 0);
            cbo_sectorista.DataSource = dtEqc;
        }
        private void DATAGRID()
        {
            //pldTo.FECHA_LLAMADA = DateTime.Now.AddMonths(6).AddDays(1);
            pldTo.TIPO = TIPO;
            pldTo.FECHA_LLAMADA = Convert.ToDateTime(calBLL.obtenerFechaActivaBLL(calTo));
            DataTable dt = pldBLL.obtenerPlanillaDirectaBLL(pldTo);
            if (dt.Rows.Count > 0)
            {
                //DGW.DataSource = dt;
                dtDet = dt;
                DGW.Rows.Clear();
                foreach (DataRow rw in dt.Rows)
                {
                    int rowId = DGW.Rows.Add();
                    DataGridViewRow row = DGW.Rows[rowId];
                    row.Cells["NRO_CONTRATO"].Value = rw["NRO_CONTRATO"].ToString();
                    row.Cells["FECHA_CONTRATO"].Value = rw["FECHA_CONTRATO"].ToString();
                    row.Cells["DESC_PER"].Value = rw["DESC_PER"].ToString();
                    row.Cells["CANT_CUOTA"].Value = rw["CANT_CUOTA"].ToString();
                    row.Cells["IMPORTE_CUOTA"].Value = rw["IMPORTE_CUOTA"].ToString();
                    row.Cells["COD_LLAMADA"].Value = rw["COD_LLAMADA"].ToString();
                    row.Cells["VISTO_CONFIRMADO"].Value = rw["VISTO_CONFIRMADO"].ToString() == "True" ? true : false;
                    row.Cells["DESCRIPCION"].Value = rw["DESCRIPCION"].ToString();
                    row.Cells["FECHA_NUEVA_LLAMADA"].Value = rw["FECHA_NUEVA_LLAMADA"].ToString();
                    row.Cells["COD_SECTORISTA"].Value = rw["COD_SECTORISTA"].ToString();
                    row.Cells["FECHA_LLAMADA"].Value = rw["FECHA_LLAMADA"].ToString();
                    row.Cells["OBSERVACIONES"].Value = rw["OBSERVACIONES"].ToString();
                    row.Cells["COD_PERSONA"].Value = rw["COD_PERSONA"].ToString();
                }
                //DISEÑO_GRID();
                CALCULOS_TOTALES();
            }
        }
        private void CALCULOS_TOTALES()
        {
            txt_tot_contratos.Text = DGW.Rows.Count.ToString();
            txt_tot_importe.Text = sumaImporte();
        }
        private void CALCULOS_TOTALES_00()
        {
            txt_tot_contratos.Text = "0";
            txt_tot_importe.Text = "0.00";
        }
        private string sumaImporte()
        {
            decimal sum = 0;
            foreach (DataGridViewRow row in DGW.Rows)
            {
                sum += Convert.ToDecimal(row.Cells["IMPORTE_CUOTA"].Value);
            }
            return sum.ToString("###,###,##0.00");
        }
        private void DISEÑO_GRID()
        {
            DGW.Columns["COD_SECTORISTA"].Visible = false;
            DGW.Columns["FECHA_LLAMADA"].Visible = false;
            DGW.Columns["NRO_CONTRATO"].HeaderText = "Contrato";
            DGW.Columns["NRO_CONTRATO"].Width = 70;
            DGW.Columns["FECHA_CONTRATO"].HeaderText = "F Contrato";
            DGW.Columns["FECHA_CONTRATO"].Width = 75;
            DGW.Columns["FECHA_CONTRATO"].DefaultCellStyle.Format = "dd/MM/yyyy";
            DGW.Columns["DESC_PER"].HeaderText = "Cliente";
            DGW.Columns["DESC_PER"].Width = 200;
            DGW.Columns["CANT_CUOTA"].HeaderText = "Letras";
            DGW.Columns["CANT_CUOTA"].Width = 45;
            DGW.Columns["CANT_CUOTA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGW.Columns["IMPORTE_CUOTA"].HeaderText = "Importe";
            DGW.Columns["IMPORTE_CUOTA"].Width = 60;
            DGW.Columns["IMPORTE_CUOTA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DGW.Columns["IMPORTE_CUOTA"].DefaultCellStyle.Format = string.Format("###,###,##0.00");
            DGW.Columns["COD_LLAMADA"].Visible = false;
            DGW.Columns["DESCRIPCION"].HeaderText = "Respuesta";
            DGW.Columns["DESCRIPCION"].Width = 150;
            DGW.Columns["FECHA_NUEVA_LLAMADA"].HeaderText = "Llamar";
            DGW.Columns["FECHA_NUEVA_LLAMADA"].Width = 75;
            DGW.Columns["FECHA_NUEVA_LLAMADA"].DefaultCellStyle.Format = "dd/MM/yyyy";
            DGW.Columns["OBSERVACIONES"].Visible = false;
        }
        //private void btn_consulta_Click(object sender, EventArgs e)
        //{
        //    if (dtDet.Rows.Count > 0)
        //    {
        //        DataView dv;
        //        if (cbo_sectorista.SelectedIndex != 0)
        //            dv = new DataView(dtDet, "COD_SECTORISTA = '" + cbo_sectorista.SelectedValue.ToString() + "'", "NRO_CONTRATO Asc", DataViewRowState.CurrentRows);
        //        else
        //            dv = new DataView(dtDet);
        //        DGW.DataSource = null;
        //        DGW.DataSource = dv.ToTable();
        //        //DISEÑO_GRID();
        //    }
        //}

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btn_Historial_Click(object sender, EventArgs e)
        {
            if (DGW.Rows.Count > 0)
            {
                //DIALOGOS.Dialog3 obs = new DIALOGOS.Dialog3();
                //planillaDirectaSeguimientoBLL plsBLL = new planillaDirectaSeguimientoBLL();
                //planillaDirectaSeguimientoTo plsTo = new planillaDirectaSeguimientoTo();
                //plsTo.NRO_CONTRATO = DGW.CurrentRow.Cells["NRO_CONTRATO"].Value.ToString();
                //plsTo.COD_PERSONA = DGW.CurrentRow.Cells["COD_PERSONA"].Value.ToString();
                //DataTable dt = plsBLL.obtenerPlanillaDirectaSeguimientoLlamadaBLL(plsTo);
                //if(dt.Rows.Count > 0)
                //{
                //    StringBuilder sb = new StringBuilder();
                //    foreach (DataRow rw in dt.Rows)
                //    {
                //        if (rw["TIPO"].ToString() == "1")//1 O 2
                //        {
                //            sb.Append(@"FECHA LLAMADA : " + Convert.ToDateTime(rw["FECHA_LLAMADA"]).ToShortDateString() + Environment.NewLine);
                //            sb.Append(@"CUOTA : " + rw["NRO_CUOTA"].ToString() + Environment.NewLine);
                //            sb.Append(@"RESPUESTA : " + rw["DES_LLAMADA_LL"].ToString() + Environment.NewLine);
                //            sb.Append(@"NUEVA FECHA : " + Convert.ToDateTime(rw["FECHA_NUEVA_LLAMADA_LL"]).ToShortDateString() + Environment.NewLine);
                //            sb.Append(@"OBSERVACIONES : " + rw["OBS_LLAMADA_LL"].ToString() + Environment.NewLine + Environment.NewLine);
                //        }
                //        else
                //        {
                //            sb.Append(@"FECHA LLAMADA : " + Convert.ToDateTime(rw["FECHA_LLAMADA"]).ToShortDateString() + Environment.NewLine);
                //            sb.Append(@"CUOTA : " + rw["NRO_CUOTA"].ToString() + Environment.NewLine);
                //            sb.Append(@"RESPUESTA : " + rw["DES_LLAMADA_CO"].ToString() + Environment.NewLine);
                //            sb.Append(@"NUEVA FECHA : " + Convert.ToDateTime(rw["FECHA_NUEVA_LLAMADA_CO"]).ToShortDateString() + Environment.NewLine);
                //            sb.Append(@"OBSERVACIONES : " + rw["OBS_LLAMADA_CO"].ToString() + Environment.NewLine + Environment.NewLine);
                //        }
                //    }
                //    obs.Text = "HISTORIAL DE LLAMADAS";
                //    obs.txt_obs.ScrollBars = ScrollBars.Vertical;
                //    obs.txt_obs.ReadOnly = true;
                //    obs.txt_obs.Text = sb.ToString();
                //    obs.ShowDialog();
                //}
                //DIALOGOS.Dialog3 obs = new DIALOGOS.Dialog3();
                PLANILLA_DIRECTA_SEGUIMIENTO frm = new PLANILLA_DIRECTA_SEGUIMIENTO();
                planillaDirectaSeguimientoBLL plsBLL = new planillaDirectaSeguimientoBLL();
                planillaDirectaSeguimientoTo plsTo = new planillaDirectaSeguimientoTo();
                plsTo.NRO_CONTRATO = DGW.CurrentRow.Cells["NRO_CONTRATO"].Value.ToString();
                plsTo.COD_PERSONA = DGW.CurrentRow.Cells["COD_PERSONA"].Value.ToString();
                DataTable dt = plsBLL.obtenerPlanillaDirectaSeguimientoLlamadaBLL(plsTo);
                if (dt.Rows.Count > 0)
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (DataRow rw in dt.Rows)
                    {
                        if (rw["TIPO"].ToString() == "L" || rw["TIPO"].ToString() == "T")
                        {
                            int rowId = frm.DGW_DETALLE.Rows.Add();
                            DataGridViewRow row = frm.DGW_DETALLE.Rows[rowId];
                            row.Cells["tip_llamada"].Value = rw["TIPO"].ToString();
                            row.Cells["FECHA_LLAMADA"].Value = Convert.ToDateTime(rw["FECHA_LLAMADA"]).ToShortDateString();
                            row.Cells["NRO_CUOTA"].Value = rw["NRO_CUOTA"].ToString();
                            row.Cells["DES_LLAMADA"].Value = rw["DES_LLAMADA_LL"].ToString();
                            row.Cells["FECHA_NUEVA_LLAMADA"].Value = rw["FECHA_NUEVA_LLAMADA_LL"] == DBNull.Value ? null : Convert.ToDateTime(rw["FECHA_NUEVA_LLAMADA_LL"]).ToShortDateString();
                            row.Cells["OBS_LLAMADA"].Value = rw["OBS_LLAMADA_LL"].ToString();
                        }
                        else if (rw["TIPO"].ToString() == "C")
                        {
                            int rowId = frm.DGW_DETALLE.Rows.Add();
                            DataGridViewRow row = frm.DGW_DETALLE.Rows[rowId];
                            row.Cells["tip_llamada"].Value = rw["TIPO"].ToString();
                            row.Cells["FECHA_LLAMADA"].Value = Convert.ToDateTime(rw["FECHA_LLAMADA"]).ToShortDateString();
                            row.Cells["NRO_CUOTA"].Value = rw["NRO_CUOTA"].ToString();
                            row.Cells["DES_LLAMADA"].Value = rw["DES_LLAMADA_CO"].ToString();
                            row.Cells["FECHA_NUEVA_LLAMADA"].Value = rw["FECHA_NUEVA_LLAMADA_CO"] == DBNull.Value ? null : Convert.ToDateTime(rw["FECHA_NUEVA_LLAMADA_CO"]).ToShortDateString();
                            row.Cells["OBS_LLAMADA"].Value = rw["OBS_LLAMADA_CO"].ToString();
                        }
                    }
                    frm.lbl_nro_llama.Text = dt.Rows.Count.ToString();
                    frm.ShowDialog();
                }
            }
        }

        private void DGW_DoubleClick(object sender, EventArgs e)
        {
            string nro_contrato = DGW.CurrentRow.Cells["NRO_CONTRATO"].Value.ToString();
            //DateTime fecha_ven = Convert.ToDateTime(DGW.CurrentRow.Cells["FECHA_LLAMADA"].Value);
            DateTime fecha_ven = Convert.ToDateTime(lbl_fec_llamada.Text);
            MOD_CXC.PLANILLA_DIRECTA_LLAMADAS_CONFIRMADAS frm = new PLANILLA_DIRECTA_LLAMADAS_CONFIRMADAS(nro_contrato, fecha_ven, COD_USU, TIPO);
            frm.ShowDialog();
            DATAGRID();
        }

        private void btn_Traer_Click(object sender, EventArgs e)
        {
            DateTime fec_ini = Convert.ToDateTime(lbl_fec_llamada.Text);
            frm.MOSTRAR_DATOS(fec_ini, dtp_vcto.Value, COD_USU);
            if (frm.DGW.Rows.Count > 0)
            {
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    //INSERTAR_EN_GRID();
                    DATAGRID();
                    CALCULOS_TOTALES();
                    frm.Hide();

                }
            }
            //
        }
        private void INSERTAR_EN_GRID()
        {
            int i = 0;
            while (i <= frm.DGW.Rows.Count - 1)
            {
                if (Convert.ToBoolean(frm.DGW.Rows[i].Cells["ok"].Value))
                {
                    DGW.Rows.Add(frm.DGW.Rows[i].Cells["COD_SECTORISTA"].Value.ToString(), "",
                        frm.DGW.Rows[i].Cells["NRO_CONTRATO"].Value.ToString(), frm.DGW.Rows[i].Cells["FECHA_CONTRATO"].Value.ToString(),
                        frm.DGW.Rows[i].Cells["DESC_PER"].Value.ToString(), "",
                        frm.DGW.Rows[i].Cells["IMP_INI"].Value.ToString(), "",
                        "", "",
                        "");
                }
                i++;
            }
        }

        private void cbo_sectorista_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataView dv;
            if (cbo_sectorista.SelectedIndex != 0)
                dv = new DataView(dtDet, "COD_SECTORISTA = '" + cbo_sectorista.SelectedValue.ToString() + "'", "NRO_CONTRATO Asc", DataViewRowState.CurrentRows);
            else
                dv = new DataView(dtDet);
            //DGW.DataSource = null;
            //DGW.DataSource = dv.ToTable();
            //DISEÑO_GRID();
            DGW.Rows.Clear();
            DataTable dtDet1 = dv.ToTable();

            //DGW.DataSource = dt;
            if (dtDet1.Rows.Count > 0)
            {
                foreach (DataRow rw in dtDet1.Rows)
                {
                    int rowId = DGW.Rows.Add();
                    DataGridViewRow row = DGW.Rows[rowId];
                    row.Cells["NRO_CONTRATO"].Value = rw["NRO_CONTRATO"].ToString();
                    row.Cells["FECHA_CONTRATO"].Value = rw["FECHA_CONTRATO"].ToString();
                    row.Cells["DESC_PER"].Value = rw["DESC_PER"].ToString();
                    row.Cells["CANT_CUOTA"].Value = rw["CANT_CUOTA"].ToString();
                    row.Cells["IMPORTE_CUOTA"].Value = rw["IMPORTE_CUOTA"].ToString();
                    row.Cells["COD_LLAMADA"].Value = rw["COD_LLAMADA"].ToString();
                    row.Cells["VISTO_CONFIRMADO"].Value = rw["VISTO_CONFIRMADO"].ToString() == "" ? false : true;
                    row.Cells["DESCRIPCION"].Value = rw["DESCRIPCION"].ToString();
                    row.Cells["FECHA_NUEVA_LLAMADA"].Value = rw["FECHA_NUEVA_LLAMADA"].ToString();
                    row.Cells["COD_SECTORISTA"].Value = rw["COD_SECTORISTA"].ToString();
                    row.Cells["FECHA_LLAMADA"].Value = rw["FECHA_LLAMADA"].ToString();
                    row.Cells["OBSERVACIONES"].Value = rw["OBSERVACIONES"].ToString();
                }
                //DISEÑO_GRID();
                CALCULOS_TOTALES();
            }
            else
                CALCULOS_TOTALES_00();


        }
    }
}
