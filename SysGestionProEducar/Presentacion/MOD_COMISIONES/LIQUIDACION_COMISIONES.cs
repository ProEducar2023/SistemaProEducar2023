using BLL;
using Entidades;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
namespace Presentacion.MOD_COMISIONES
{
    public partial class LIQUIDACION_COMISIONES : Form
    {
        pLiquidacionBLL liqBLL = new pLiquidacionBLL();
        pLiquidacionTo liqTo = new pLiquidacionTo();
        pComisionBLL pcoBLL = new pComisionBLL();
        pComisionTo pcoTo = new pComisionTo();
        //string COD_USU = "";
        string AÑO = "", MES = "", COD_MOD = "", COD_USU = "", TIPO_USU = "", AÑO1 = "", MES1 = "";
        DateTime FECHA_INI, FECHA_GRAL;
        //DIALOGOS.CONSULTA_PARA_COMISIONES_000 frmCon_000 = new DIALOGOS.CONSULTA_PARA_COMISIONES_000();
        string tipo_pla, cod_prog, año, mes, cuota, preaprob;
        DataTable dtGeneral = null;
        DataTable dtLiq = null;
        public LIQUIDACION_COMISIONES(string AÑO, string MES, DateTime FECHA_INI, DateTime FECHA_GRAL, string COD_MOD, string TIPO_USU, string COD_USU)
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
        private void LIQUIDACION_COMISIONES_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void LIQUIDACION_COMISIONES_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            TIPO_PLANILLA();
            CARGAR_PROGRAMAS();
            CARGAR_AÑO();
            CARGAR_MES();
            CARGAR_CUOTA();
            dgw1.Columns["FE_CONTRATO"].DefaultCellStyle.Format = "dd/MM/yyyy";
        }
        private void TIPO_PLANILLA()
        {
            var items = new[] { new { cod = "P", val = "PLANILLA" }, new { cod = "D", val = "DIRECTA" } };
            cbo_tipo.ValueMember = "cod";
            cbo_tipo.DisplayMember = "val";
            cbo_tipo.DataSource = items;
            cbo_tipo.SelectedIndex = 0;
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
        private void CARGAR_CUOTA()
        {
            comisionesDetalleBLL codBLL = new comisionesDetalleBLL();
            comisionesDetalleTo codTo = new comisionesDetalleTo();
            DataTable dt = codBLL.obtenerComisionesDetalleDistintosBLL();
            DataRow rw = dt.NewRow();
            rw["CUOTA"] = "001";
            dt.Rows.InsertAt(rw, 1);
            cbo_cuota.ValueMember = "CUOTA";
            cbo_cuota.DisplayMember = "CUOTA";
            cbo_cuota.DataSource = dt;
        }
        private void CARGAR_AÑO()
        {
            periodoBLL perBLL = new periodoBLL();
            periodoTo perTo = new periodoTo();
            //
            cbo_año.Items.Clear();
            perTo.COD_MODULO = "COM";
            DataTable dt = perBLL.obtenerAñoPeriodoBLL(perTo);
            cbo_año.ValueMember = "AÑO";
            cbo_año.DisplayMember = "AÑO";
            cbo_año.DataSource = dt;
        }
        private void CARGAR_MES()
        {
            var months1 = new[] {new { cod = "01", val = "ENERO" }, new { cod = "02", val = "FEBRERO" },
                                new { cod = "03", val = "MARZO" }, new { cod = "04", val = "ABRIL" },
                                new { cod = "05", val = "MAYO" }, new { cod = "06", val = "JUNIO" },
                                new { cod = "07", val = "JULIO" }, new { cod = "08", val = "AGOSTO" },
                                new { cod = "09", val = "SEPTIEMBRE" }, new { cod = "10", val = "OCTUBRE" },
                                new { cod = "11", val = "NOVIEMBRE" }, new { cod = "12", val = "DICIEMBRE" }};

            cbo_mes1.ValueMember = "cod";
            cbo_mes1.DisplayMember = "val";
            cbo_mes1.DataSource = months1;
            //cbo_mes.SelectedIndex = -1;
        }
        private void btn_consulta1_Click(object sender, EventArgs e)
        {
            tipo_pla = cbo_tipo.SelectedValue.ToString();
            cod_prog = cbo_prog.SelectedValue.ToString();
            año = cbo_año.SelectedValue.ToString();
            mes = cbo_mes1.SelectedValue.ToString();
            cuota = cbo_cuota.SelectedValue.ToString();//txt_cuota.Text;
            preaprob = chk_preaprob.Checked ? "1" : "0";
            OBTENER_P_COMISION_POR_PERIODO(tipo_pla, cod_prog, año, mes, cuota, preaprob);//dgw1
            OBTENER_L_LIQUIDADO_POR_PERIODO(tipo_pla, cod_prog, año, mes);//dgw3 el grid de fondo Liquidaciones del Periodo
            dgw1.Select();
        }
        private void OBTENER_L_LIQUIDADO_POR_PERIODO(string TIPO_VTA, string COD_PROG, string AÑO, string MES)
        {
            pcoTo.TIPO_VTA = TIPO_VTA;
            pcoTo.COD_PROGRAMA = COD_PROG;
            pcoTo.FE_AÑO = AÑO;
            pcoTo.FE_MES = MES;
            dtLiq = pcoBLL.obtenerPLiquidacionporPeriodoBLL(pcoTo);
            dgw3.Rows.Clear();
            if (dtLiq.Rows.Count > 0)
            {
                DataTable dt1 = dtLiq.AsEnumerable()
                   .GroupBy(r => new
                   {
                       Col01 = r["TIPO_VTA"],
                       Col02 = r["COD_PROGRAMA"],
                       Col03 = r["COD_VENDEDOR"],
                       Col04 = r["DESC_PER"],
                       Col05 = r["NRO_CONTRATO"],
                       Col06 = r["FE_CONTRATO"],
                       Col07 = r["FE_AÑO"],
                       Col08 = r["FE_MES"],
                       Col09 = r["COD_PER"],
                       Col10 = r["NOMCLI"],
                       Col11 = r["NRO_LETRA"]
                   })
                   .Select(g => g.OrderBy(r => r["NRO_CONTRATO"]).First())
                   .CopyToDataTable();
                //
                if (dt1.Rows.Count > 0)
                {
                    foreach (DataRow rw in dt1.Rows)
                    {
                        int rowId = dgw3.Rows.Add();
                        DataGridViewRow row = dgw3.Rows[rowId];
                        row.Cells["TIPO_VTA2"].Value = rw["TIPO_VTA"].ToString();
                        row.Cells["COD_PROGRAMA2"].Value = rw["COD_PROGRAMA"].ToString();
                        row.Cells["COD_VENDEDOR2"].Value = rw["COD_VENDEDOR"].ToString();
                        row.Cells["DESC_PER2"].Value = rw["DESC_PER"].ToString();
                        row.Cells["NRO_CONTRATO2"].Value = rw["NRO_CONTRATO"].ToString();
                        row.Cells["FE_CONTRATO2"].Value = rw["FE_CONTRATO"].ToString().Substring(0, 10);
                        row.Cells["FE_AÑO2"].Value = rw["FE_AÑO"].ToString();
                        row.Cells["FE_MES2"].Value = rw["FE_MES"].ToString();
                        row.Cells["COD_PER2"].Value = rw["COD_PER"].ToString();
                        row.Cells["NOMCLI2"].Value = rw["NOMCLI"].ToString();
                        row.Cells["NRO_LETRA2"].Value = rw["NRO_LETRA"].ToString();
                        row.Cells["STATUS_PRE_APROB2"].Value = rw["STATUS_PRE_APROB"].ToString() == "0" ? "A" : "P";//Aprobado y Pre-Aprobado
                        row.Cells["COD_PER_SUP2"].Value = rw["COD_PER_SUP"].ToString();
                        row.Cells["IMP_FIN2"].Value = rw["IMP_FIN"].ToString();
                        row.Cells["COD_NIVEL2"].Value = rw["COD_NIVEL"].ToString();
                        //row.Cells["X"].Value = true;
                    }
                }
            }
            //else
            //{
            //    MessageBox.Show("No se encontraron registros !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //}
        }
        private void OBTENER_P_COMISION_POR_PERIODO(string TIPO_VTA, string COD_PROG, string AÑO, string MES, string LETRA, string PRE_APROB)
        {
            pcoTo.TIPO_VTA = TIPO_VTA;
            pcoTo.COD_PROGRAMA = COD_PROG;
            pcoTo.FE_AÑO = AÑO;
            pcoTo.FE_MES = MES;
            pcoTo.NRO_LETRA = LETRA;
            pcoTo.STATUS_PRE_APROB = PRE_APROB;
            dgw1.Rows.Clear();
            dgw2.Rows.Clear();
            if (pcoTo.NRO_LETRA == "000")
                dtGeneral = pcoBLL.obtenerPComisionPorPeriodoBLL(pcoTo);
            else
                dtGeneral = pcoBLL.obtenerPComisionDif000BLL(pcoTo);
            //
            if (dtGeneral.Rows.Count > 0)
            {
                DataTable dt1 = dtGeneral.AsEnumerable()
                   .GroupBy(r => new
                   {
                       Col01 = r["TIPO_VTA"],
                       Col02 = r["COD_PROGRAMA"],
                       Col03 = r["COD_VENDEDOR"],
                       Col04 = r["DESC_PER"],
                       Col05 = r["NRO_CONTRATO"],
                       Col06 = r["FE_CONTRATO"],
                       Col07 = r["FE_AÑO"],
                       Col08 = r["FE_MES"],
                       Col09 = r["COD_PER"],
                       Col10 = r["NOMCLI"],
                       Col11 = r["NRO_LETRA"]
                   })
                   .Select(g => g.OrderBy(r => r["NRO_CONTRATO"]).First())
                   .CopyToDataTable();
                //
                if (dt1.Rows.Count > 0)
                {
                    foreach (DataRow rw in dt1.Rows)
                    {
                        int rowId = dgw1.Rows.Add();
                        DataGridViewRow row = dgw1.Rows[rowId];
                        row.Cells["TIPO_VTA"].Value = rw["TIPO_VTA"].ToString();
                        row.Cells["COD_PROGRAMA"].Value = rw["COD_PROGRAMA"].ToString();
                        row.Cells["COD_VENDEDOR"].Value = rw["COD_VENDEDOR"].ToString();
                        row.Cells["DESC_PER"].Value = rw["DESC_PER"].ToString();
                        row.Cells["NRO_CONTRATO"].Value = rw["NRO_CONTRATO"].ToString();
                        row.Cells["FE_CONTRATO"].Value = rw["FE_CONTRATO"].ToString().Substring(0, 10);
                        row.Cells["FE_AÑO"].Value = rw["FE_AÑO"].ToString();
                        row.Cells["FE_MES"].Value = rw["FE_MES"].ToString();
                        row.Cells["COD_PER"].Value = rw["COD_PER"].ToString();
                        row.Cells["NOMCLI"].Value = rw["NOMCLI"].ToString();
                        row.Cells["NRO_LETRA"].Value = rw["NRO_LETRA"].ToString();
                        row.Cells["STATUS_PRE_APROB"].Value = rw["STATUS_PRE_APROB"].ToString() == "0" ? "A" : "P";//Aprobado y Pre-Aprobado
                        row.Cells["COD_PER_SUP"].Value = rw["COD_PER_SUP"].ToString();
                        row.Cells["IMP_FIN"].Value = rw["IMP_FIN"].ToString();
                        row.Cells["COD_NIVEL"].Value = rw["COD_NIVEL"].ToString();
                        row.Cells["X"].Value = true;
                    }
                }
            }
            else
            {
                MessageBox.Show("No se encontraron registros !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void btn_grabar_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("¿ Esta seguro de Liquidar las Comisiones para estas personas ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                liqTo.FE_AÑO = AÑO;//cbo_año.SelectedValue.ToString();
                liqTo.FE_MES = MES;//cbo_mes1.SelectedValue.ToString();
                liqTo.COD_CREA = COD_USU;
                liqTo.FE_DOC = DateTime.Now;
                liqTo.FECHA_CREA = DateTime.Now;
                //DataTable dtComision = OBTENER_COMISIONES_REALES();
                DataTable dtComision = OBTENER_COMISIONES_PARA_LIQUIDAR();// HelpersBLL.obtenerDTX(dgw1);
                //DataTable dt = new DataTable();

                if (!liqBLL.liquidacionComisionesBLL(liqTo, dtComision, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Las Comisiones se liquidaron correctamente !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //dgw1.Rows.Clear();
                    //ENVIAR_FILAS_LIQUIDADAS();
                    OBTENER_L_LIQUIDADO_POR_PERIODO(tipo_pla, cod_prog, año, mes);//dgw3 el grid de fondo Liquidaciones del Periodo
                    QUITAR_FILAS_MARCADAS();
                    dgw2.Rows.Clear();
                    //txt_cuota.Clear();
                    cbo_cuota.SelectedIndex = 0;
                    chk_preaprob.Checked = false;
                    //txt_cuota.Focus();
                    cbo_cuota.Focus();
                }
            }
        }
        private void ENVIAR_FILAS_LIQUIDADAS()
        {
            foreach (DataGridViewRow rw in dgw1.Rows)
            {
                if (Convert.ToBoolean(rw.Cells["X"].Value))
                {
                    int rowId = dgw3.Rows.Add();
                    DataGridViewRow row = dgw3.Rows[rowId];
                    row.Cells["TIPO_VTA2"].Value = rw.Cells["TIPO_VTA"].Value.ToString();
                    row.Cells["COD_PROGRAMA2"].Value = rw.Cells["COD_PROGRAMA"].Value.ToString();
                    row.Cells["COD_VENDEDOR2"].Value = rw.Cells["COD_VENDEDOR"].Value.ToString();
                    row.Cells["DESC_PER2"].Value = rw.Cells["DESC_PER"].Value.ToString();
                    row.Cells["NRO_CONTRATO2"].Value = rw.Cells["NRO_CONTRATO"].Value.ToString();
                    row.Cells["FE_CONTRATO2"].Value = rw.Cells["FE_CONTRATO"].Value.ToString().Substring(0, 10);
                    row.Cells["FE_AÑO2"].Value = rw.Cells["FE_AÑO"].Value.ToString();
                    row.Cells["FE_MES2"].Value = rw.Cells["FE_MES"].Value.ToString();
                    row.Cells["COD_PER2"].Value = rw.Cells["COD_PER"].Value.ToString();
                    row.Cells["NOMCLI2"].Value = rw.Cells["NOMCLI"].Value.ToString();
                    row.Cells["NRO_LETRA2"].Value = rw.Cells["NRO_LETRA"].Value.ToString();
                    row.Cells["STATUS_PRE_APROB2"].Value = rw.Cells["STATUS_PRE_APROB"].Value.ToString();//Aprobado y Pre-Aprobado
                    row.Cells["COD_PER_SUP2"].Value = rw.Cells["COD_PER_SUP"].Value.ToString();
                    row.Cells["IMP_FIN2"].Value = rw.Cells["IMP_FIN"].Value.ToString();
                    row.Cells["COD_NIVEL2"].Value = rw.Cells["COD_NIVEL"].Value.ToString();
                    //row.Cells["X"].Value = true;
                }
            }
        }
        private DataTable OBTENER_COMISIONES_PARA_LIQUIDAR()
        {
            DataTable dt = dtGeneral.Copy();
            dt.Columns.Add("op");
            string nro_contrato;
            foreach (DataGridViewRow row in dgw1.Rows)
            {
                if (Convert.ToBoolean(row.Cells["X"].Value))
                {
                    nro_contrato = row.Cells["NRO_CONTRATO"].Value.ToString();
                    foreach (DataRow rw in dt.Rows)
                    {
                        if (rw["NRO_CONTRATO"].ToString() == nro_contrato)
                            rw["op"] = "1";
                    }
                }
            }
            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {
                if (dt.Rows[i]["op"].ToString() != "1")
                    dt.Rows.Remove(dt.Rows[i]);
            }
            return dt;
        }
        private void QUITAR_FILAS_MARCADAS()
        {
            for (int i = dgw1.Rows.Count - 1; i >= 0; i--)
            {
                if (Convert.ToBoolean(dgw1.Rows[i].Cells["X"].Value))
                    dgw1.Rows.RemoveAt(dgw1.Rows[i].Index);
            }
        }
        private void dgw1_SelectionChanged(object sender, EventArgs e)
        {
            if (dgw1.Rows.Count > 0)
            {
                if (dgw1.CurrentRow.Cells["NRO_CONTRATO"].Value != null)
                    llenaDetalle();
            }
        }
        private void dgw1_Click(object sender, EventArgs e)
        {
            llenaDetalle();
        }
        private void llenaDetalle()
        {
            dgw2.Rows.Clear();
            string nro_contrato = dgw1.CurrentRow.Cells["NRO_CONTRATO"].Value.ToString();
            DataTable dtDetalle = null;
            if (dtGeneral.Rows.Count > 0)
            {
                DataRow[] fila = dtGeneral.Select("NRO_CONTRATO = '" + nro_contrato + "'");
                if (fila.Length > 0)
                {
                    dtDetalle = fila.CopyToDataTable();
                    if (dtDetalle.Rows.Count > 0)
                    {
                        foreach (DataRow rw in dtDetalle.Rows)
                        {
                            int rowId = dgw2.Rows.Add();
                            DataGridViewRow row = dgw2.Rows[rowId];
                            row.Cells["TIPO_VTA1"].Value = rw["TIPO_VTA"].ToString();
                            row.Cells["COD_PROGRAMA1"].Value = rw["COD_PROGRAMA"].ToString();
                            row.Cells["COD_PER_SUP1"].Value = rw["COD_PER_SUP"].ToString();
                            row.Cells["NOM_PER_SUP1"].Value = rw["NOMSUP"].ToString();
                            row.Cells["NRO_CONTRATO1"].Value = rw["NRO_CONTRATO"].ToString();
                            row.Cells["NRO_LETRA1"].Value = rw["NRO_LETRA"].ToString();
                            row.Cells["IMP_FIN1"].Value = rw["IMP_FIN"].ToString();
                            row.Cells["COD_NIVEL1"].Value = rw["COD_NIVEL"].ToString();
                            row.Cells["DESC_NIVEL1"].Value = rw["DESC_NIVEL"].ToString();
                        }
                    }
                }
                else
                    dgw2.Rows.Clear();
            }
            else
                dgw2.Rows.Clear();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (!validaEliminar())
                return;

            DialogResult rs = MessageBox.Show("¿ Esta seguro de Eliminar las Liquidaciones del Contrato " + dgw3.CurrentRow.Cells["NRO_CONTRATO2"].Value.ToString() + "\n con Nro de Cuota " + dgw3.CurrentRow.Cells["NRO_LETRA2"].Value.ToString() + " ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                liqTo.TIPO_VTA = dgw3.CurrentRow.Cells["TIPO_VTA2"].Value.ToString();
                liqTo.COD_PROGRAMA = dgw3.CurrentRow.Cells["COD_PROGRAMA2"].Value.ToString();
                liqTo.COD_COMISIONANTE = dgw3.CurrentRow.Cells["COD_PROGRAMA2"].Value.ToString();
                liqTo.NRO_CONTRATO = dgw3.CurrentRow.Cells["NRO_CONTRATO2"].Value.ToString();
                liqTo.NRO_LETRA = dgw3.CurrentRow.Cells["NRO_LETRA2"].Value.ToString();
                liqTo.COD_NIVEL = dgw3.CurrentRow.Cells["COD_NIVEL2"].Value.ToString();
                liqTo.STATUS_PRE_APROB = dgw3.CurrentRow.Cells["STATUS_PRE_APROB2"].Value.ToString();
                liqTo.FE_AÑO = dgw3.CurrentRow.Cells["FE_AÑO2"].Value.ToString();
                liqTo.FE_MES = dgw3.CurrentRow.Cells["FE_MES2"].Value.ToString();
                liqTo.IMPORTE = Convert.ToDecimal(dgw3.CurrentRow.Cells["IMP_FIN2"].Value);
                liqTo.COD_VENDEDOR = dgw3.CurrentRow.Cells["COD_VENDEDOR2"].Value.ToString();
                liqTo.COD_PER_SUP = dgw3.CurrentRow.Cells["COD_PER_SUP2"].Value.ToString();
                liqTo.COD_MODIF = COD_USU;
                liqTo.COD_CREA = COD_USU;
                liqTo.FECHA_MODIF = DateTime.Now;
                liqTo.FECHA_CREA = DateTime.Now;

                if (!liqBLL.eliminaLiquidacionxCuotaBLL(liqTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Las Liquidaciones se eliminaron correctamente !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //OBTENER_P_COMISION_POR_PERIODO(tipo_pla, cod_prog, año, mes, cuota, preaprob);//dgw1
                    //DATAGRID_ADICIONAR_DGW1(liqTo);
                    ////TabControl1.SelectedTab = TabPage1;
                    DATAGRID_ELIMINAR_DGW();
                }
            }
        }
        private void DATAGRID_ELIMINAR_DGW()
        {
            dgw3.Rows.Remove(dgw3.CurrentRow);
        }
        private bool validaEliminar()
        {
            bool result = true;
            return result;
        }
        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
        }

        private void dgw3_Click(object sender, EventArgs e)
        {
            llenaDetalle2();
        }
        private void dgw3_SelectionChanged(object sender, EventArgs e)
        {
            if (dgw3.Rows.Count > 0)
            {
                if (dgw3.CurrentRow.Cells["NRO_CONTRATO2"].Value != null)
                    llenaDetalle2();
            }
        }
        private void llenaDetalle2()
        {
            dgw4.Rows.Clear();
            string nro_contrato = dgw3.CurrentRow.Cells["NRO_CONTRATO2"].Value.ToString();
            string nro_letra = dgw3.CurrentRow.Cells["NRO_LETRA2"].Value.ToString();
            DataTable dtDetalle = null;
            if (dtLiq.Rows.Count > 0)//hay que traer la data
            {
                DataRow[] fila = dtLiq.Select("NRO_CONTRATO = '" + nro_contrato + "' AND NRO_LETRA = '" + nro_letra + "'");
                if (fila.Length > 0)
                {
                    dtDetalle = fila.CopyToDataTable();
                    if (dtDetalle.Rows.Count > 0)
                    {
                        foreach (DataRow rw in dtDetalle.Rows)
                        {
                            int rowId = dgw4.Rows.Add();
                            DataGridViewRow row = dgw4.Rows[rowId];
                            row.Cells["TIPO_VTA3"].Value = rw["TIPO_VTA"].ToString();
                            row.Cells["COD_PROGRAMA3"].Value = rw["COD_PROGRAMA"].ToString();
                            row.Cells["COD_PER_SUP3"].Value = rw["COD_PER_SUP"].ToString();
                            row.Cells["NOM_PER_SUP3"].Value = rw["NOMSUP"].ToString();
                            row.Cells["NRO_CONTRATO3"].Value = rw["NRO_CONTRATO"].ToString();
                            row.Cells["NRO_LETRA3"].Value = rw["NRO_LETRA"].ToString();
                            row.Cells["IMP_FIN3"].Value = rw["IMP_FIN"].ToString();
                            row.Cells["COD_NIVEL3"].Value = rw["COD_NIVEL"].ToString();
                            row.Cells["DESC_NIVEL3"].Value = rw["DESC_NIVEL"].ToString();
                        }
                    }
                }
                else
                    dgw4.Rows.Clear();
            }
            else
                dgw4.Rows.Clear();
        }
    }
}
