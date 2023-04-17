using BLL;
using Entidades;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
namespace Presentacion.MOD_COMISIONES
{
    public partial class GENERACION_COMISIONES : Form
    {
        string AÑO = "", MES = "", COD_MOD = "", COD_USU = "", TIPO_USU = "", AÑO1 = "", MES1 = "";
        DateTime FECHA_INI, FECHA_GRAL;
        DataTable dtContratos = new DataTable();
        DataTable dtGeneral = null;
        contratoCabeceraBLL conBLL = new contratoCabeceraBLL();
        contratoCabeceraTo conTo = new contratoCabeceraTo();
        pComisionBLL comBLL = new pComisionBLL();
        pComisionTo comTo = new pComisionTo();
        public GENERACION_COMISIONES(string AÑO, string MES, DateTime FECHA_INI, DateTime FECHA_GRAL, string COD_MOD, string TIPO_USU, string COD_USU)
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

        private void GENERACION_COMISIONES_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            CARGAR_AÑO();
            CARGAR_MES();
            chkTodos.Enabled = false;
            cbo_mes.Focus();
        }
        private void CARGAR_AÑO()
        {
            periodoBLL perBLL = new periodoBLL();
            periodoTo perTo = new periodoTo();
            cbo_año.Items.Clear();
            perTo.COD_MODULO = "VTA";
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

            cbo_mes.ValueMember = "cod";
            cbo_mes.DisplayMember = "val";
            cbo_mes.DataSource = months1;
        }
        private void btn_ok_Click(object sender, EventArgs e)
        {
            AÑO1 = cbo_año.SelectedValue.ToString();
            MES1 = cbo_mes.SelectedValue.ToString();
            DATAGRID();//para llenar grid de los no comisionados aún 
            DATAGRID_INI_DGW();//para llenar grid de los ya comisionados o generados en el periodo (mes) elegido
            lbltitulo.Text = "COMISIONES X CADA VENTA " + HelpersBLL.OBTENER_NOM_MES(cbo_mes.SelectedValue.ToString()) + " " + cbo_año.SelectedValue.ToString();
        }
        private void DATAGRID()
        {
            conTo.FE_AÑO = AÑO1;
            conTo.FE_MES = MES1;
            DataTable dt = conBLL.obtenerContratoCabeceraparaComisionesBLL(conTo);
            dgw1.Rows.Clear();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow rw in dt.Rows)
                {
                    int rowId = dgw1.Rows.Add();
                    DataGridViewRow row = dgw1.Rows[rowId];
                    row.Cells["TIPO_VTA"].Value = rw["TIPO_PLANILLA"].ToString();
                    row.Cells["COD_PROGRAMA"].Value = rw["COD_PROGRAMA"].ToString();
                    row.Cells["NRO_PRESUPUESTO"].Value = rw["NRO_PRESUPUESTO"].ToString();
                    row.Cells["COD_VENDEDOR"].Value = rw["COD_VENDEDOR"].ToString();
                    row.Cells["VEND"].Value = rw["VEND"].ToString();
                    row.Cells["FECHA_PRE"].Value = rw["FECHA_PRE"].ToString().Substring(0, 10);
                    row.Cells["FECHA_APROB"].Value = rw["FECHA_APROB"].ToString() == "" ? "" : rw["FECHA_APROB"].ToString().Substring(0, 10);
                    row.Cells["COD_PER"].Value = rw["COD_PER"].ToString();
                    row.Cells["DESC_PER"].Value = rw["DESC_PER"].ToString();
                    row.Cells["ST_APROB"].Value = rw["ST_APROB"].ToString();
                    row.Cells["ST_PRE_APROB"].Value = rw["ST_PRE_APROB"].ToString();
                    row.Cells["X"].Value = true;
                }
            }
            else
                MessageBox.Show("No se encontraron registros !!!", "MENSAJES", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        private void DATAGRID_INI_DGW()
        {
            comTo.FE_AÑO = AÑO;
            comTo.FE_MES = MES;
            dtGeneral = comBLL.obtenerPComisionBLL(comTo);
            dgw.Rows.Clear();
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
                       Col10 = r["NOM_CLI"],
                       //Col11 = r["NRO_LETRA"]
                   })
                   .Select(g => g.OrderBy(r => r["NRO_CONTRATO"]).First())
                   .CopyToDataTable();
                //
                if (dt1.Rows.Count > 0)
                {
                    foreach (DataRow rw in dt1.Rows)
                    {
                        int rowId = dgw.Rows.Add();
                        DataGridViewRow row = dgw.Rows[rowId];
                        row.Cells["TIPO_VTA1"].Value = rw["TIPO_VTA"].ToString();
                        row.Cells["COD_PROGRAMA1"].Value = rw["COD_PROGRAMA"].ToString();
                        row.Cells["COD_VENDEDOR1"].Value = rw["COD_VENDEDOR"].ToString();
                        row.Cells["DESC_PER1"].Value = rw["DESC_PER"].ToString();
                        row.Cells["NRO_CONTRATO"].Value = rw["NRO_CONTRATO"].ToString();
                        row.Cells["FE_AÑO"].Value = rw["FE_AÑO"].ToString();
                        row.Cells["FE_MES"].Value = rw["FE_MES"].ToString();
                        row.Cells["FE_CONTRATO"].Value = rw["FE_CONTRATO"].ToString().Substring(0, 10);
                        row.Cells["FE_DOC"].Value = rw["FE_DOC"].ToString().Substring(0, 10);
                        row.Cells["FE_APROB"].Value = rw["FE_APROB"].ToString() == "" ? "" : rw["FE_APROB"].ToString().Substring(0, 10);
                        row.Cells["COD_PER1"].Value = rw["COD_PER"].ToString();
                        row.Cells["NOM_CLI"].Value = rw["NOM_CLI"].ToString();
                        row.Cells["NRO_LETRA"].Value = rw["NRO_LETRA"].ToString();
                        row.Cells["IMPORTE"].Value = rw["IMPORTE"].ToString();
                        row.Cells["COD_NIVEL"].Value = rw["COD_NIVEL"].ToString();
                        row.Cells["DESC_NIVEL"].Value = rw["DESC_NIVEL"].ToString();
                        row.Cells["COD_PER_SUP"].Value = rw["COD_PER_SUP"].ToString();
                        row.Cells["NOM_SUP"].Value = rw["NOM_SUP"].ToString();
                        row.Cells["STATUS_PRE_APROB"].Value = rw["STATUS_PRE_APROB"].ToString() == "1" ? "P" : "A";
                    }
                }
            }
            else
            {
                MessageBox.Show("No se encontraron registros !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            if (!validaGenerar())
                return;

            DialogResult rs = MessageBox.Show("¿ Esta seguro de generar las Comisiones para estos Vendedores ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                comTo.FE_AÑO = AÑO1;
                comTo.FE_MES = MES1;
                comTo.COD_CREA = COD_USU;
                comTo.FECHA_CREA = DateTime.Now;
                dtContratos = OBTENER_NRO_CONTRATOS();
                DataTable dt = new DataTable();
                DataTable dtComision = new DataTable();
                //obtiene data
                foreach (DataRow rw in dtContratos.Rows)
                {
                    comTo.NRO_CONTRATO = rw["uno"].ToString();
                    dt = comBLL.obtenerContratosporPeriodoBLL(comTo);
                    dtComision.Merge(dt);
                }
                //
                comTo.FE_AÑO = AÑO;
                comTo.FE_MES = MES;
                if (!comBLL.adicionaNuevaComisionBLL(comTo, dtComision, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Las Comisiones se generaron correctamente !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DATAGRID_DGW1();//quita el registro que se ha Comisionado o generado
                    TabControl1.SelectedTab = TabPage2;
                    //DATAGRID_DGW();//adiciona el regitro comisionado en el grid de Comisiones del Periodo
                    DATAGRID_INI_DGW();//adiciona el regitro comisionado en el grid de Comisiones del Periodo
                }
            }
        }
        private DataTable OBTENER_NRO_CONTRATOS()
        {
            DataTable dt = new DataTable();
            dt = HelpersBLL.OBTENER_UNA_COLUMNA().Clone();
            foreach (DataGridViewRow row in dgw1.Rows)
            {
                if (Convert.ToBoolean(row.Cells["X"].Value))
                {
                    DataRow rw = dt.NewRow();
                    rw["uno"] = row.Cells["NRO_PRESUPUESTO"].Value.ToString();
                    dt.Rows.Add(rw);
                }
            }
            return dt;
        }
        private void DATAGRID_DGW()
        {
            comTo.FE_AÑO = AÑO;
            comTo.FE_MES = MES;
            DataTable dt = comBLL.obtenerPComisionBLL(comTo);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow fila in dtContratos.Rows)
                {
                    foreach (DataRow rw in dt.Rows)
                    {
                        if (fila["uno"].ToString() == rw["NRO_CONTRATO"].ToString())
                        {
                            int rowId = dgw.Rows.Add();
                            DataGridViewRow row = dgw.Rows[rowId];
                            row.Cells["TIPO_VTA1"].Value = rw["TIPO_VTA"].ToString();
                            row.Cells["COD_PROGRAMA1"].Value = rw["COD_PROGRAMA"].ToString();
                            row.Cells["COD_VENDEDOR1"].Value = rw["COD_VENDEDOR"].ToString();
                            row.Cells["DESC_PER1"].Value = rw["DESC_PER"].ToString();
                            row.Cells["NRO_CONTRATO"].Value = rw["NRO_CONTRATO"].ToString();
                            row.Cells["FE_AÑO"].Value = rw["FE_AÑO"].ToString();
                            row.Cells["FE_MES"].Value = rw["FE_MES"].ToString();
                            row.Cells["FE_CONTRATO"].Value = rw["FE_CONTRATO"].ToString().Substring(0, 10);
                            row.Cells["FE_DOC"].Value = rw["FE_DOC"].ToString().Substring(0, 10);
                            row.Cells["FE_APROB"].Value = rw["FE_APROB"].ToString() == "" ? "" : rw["FE_APROB"].ToString().Substring(0, 10);
                            row.Cells["COD_PER1"].Value = rw["COD_PER"].ToString();
                            row.Cells["NOM_CLI"].Value = rw["NOM_CLI"].ToString();
                            row.Cells["NRO_LETRA"].Value = rw["NRO_LETRA"].ToString();
                            row.Cells["IMPORTE"].Value = rw["IMPORTE"].ToString();
                            row.Cells["COD_NIVEL"].Value = rw["COD_NIVEL"].ToString();
                            row.Cells["DESC_NIVEL"].Value = rw["DESC_NIVEL"].ToString();
                            row.Cells["COD_PER_SUP"].Value = rw["COD_PER_SUP"].ToString();
                            row.Cells["NOM_SUP"].Value = rw["NOM_SUP"].ToString();
                            row.Cells["STATUS_PRE_APROB"].Value = rw["STATUS_PRE_APROB"].ToString() == "1" ? "P" : "A";
                        }
                    }
                }
            }
        }
        private void DATAGRID_DGW1()
        {
            for (int i = dgw1.Rows.Count - 1; i >= 0; i--)
            {
                if (Convert.ToBoolean(dgw1.Rows[i].Cells["X"].Value))
                    dgw1.Rows.RemoveAt(dgw1.Rows[i].Index);
            }
        }
        private bool validaGenerar()
        {
            bool result = true;
            return result;
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            TabControl1.SelectedTab = TabPage1;
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void chkTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTodos.Checked)
            {
                foreach (DataGridViewRow row in dgw1.Rows)
                {
                    row.Cells["X"].Value = true;
                }
                chkTodos.Enabled = false;
            }
            //else
            //{
            //    foreach (DataGridViewRow row in dgw1.Rows)
            //    {
            //        row.Cells["X"].Value = false;
            //    }
            //}
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (!validaEliminar())
                return;

            DialogResult rs = MessageBox.Show("¿ Esta seguro de Eliminar todas las Comisiones del Contrato " + dgw.CurrentRow.Cells["NRO_CONTRATO"].Value.ToString() + " ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                comTo.NRO_CONTRATO = dgw.CurrentRow.Cells["NRO_CONTRATO"].Value.ToString();
                if (!comBLL.eliminaComisionBLL(comTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Las Comisiones se eliminaron correctamente !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DATAGRID_ADICIONAR_DGW1(comTo);
                    //TabControl1.SelectedTab = TabPage1;
                    DATAGRID_ELIMINAR_DGW(comTo);
                }
            }
        }
        private void DATAGRID_ADICIONAR_DGW1(pComisionTo comTo)
        {
            conTo.NRO_PRESUPUESTO = comTo.NRO_CONTRATO;
            DataTable dt = conBLL.obtenerContratoCabeceraparaComisionesxNroContratoBLL(conTo);
            dgw1.Rows.Add(dt.Rows[0]["NRO_PRESUPUESTO"].ToString(), dt.Rows[0]["COD_VENDEDOR"].ToString(), dt.Rows[0]["VEND"].ToString(),
                dt.Rows[0]["FECHA_PRE"].ToString().Substring(0, 10), dt.Rows[0]["FECHA_APROB"].ToString() == "" ? "" : dt.Rows[0]["FECHA_APROB"].ToString().Substring(0, 10),
                dt.Rows[0]["COD_PER"].ToString(),
                dt.Rows[0]["DESC_PER"].ToString(), dt.Rows[0]["ST_APROB"].ToString(), dt.Rows[0]["ST_PRE_APROB"].ToString(), false,
                dt.Rows[0]["COD_PROGRAMA"].ToString(), dt.Rows[0]["TIPO_PLANILLA"].ToString());
        }
        private void DATAGRID_ELIMINAR_DGW(pComisionTo comTo)
        {
            for (int i = dgw.Rows.Count - 1; i >= 0; i--)
            {
                if (dgw.Rows[i].Cells["NRO_CONTRATO"].Value.ToString() == comTo.NRO_CONTRATO)
                    dgw.Rows.RemoveAt(dgw.Rows[i].Index);
            }
        }
        private bool validaEliminar()
        {
            bool result = true;
            return result;
        }

        private void btn_consulta_Click(object sender, EventArgs e)
        {
            TabControl1.SelectedTab = TabPage2;
        }

        private void dgw1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if(e.ColumnIndex == 9)
            //{
            //    if (!Convert.ToBoolean(dgw1.CurrentRow.Cells["X"].Value))
            //    {
            //        chkTodos.Checked = false;
            //        chkTodos.Enabled = true;
            //    }
            //    //if (revisaChecks())
            //    //    checkeaTodos();
            //}
        }
        private bool revisaChecks()
        {
            bool result = false;
            foreach (DataGridViewRow row in dgw1.Rows)
            {
                if (!Convert.ToBoolean(row.Cells["X"].Value))
                {
                    return result = true;
                }
            }
            return result;
        }

        private void dgw1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //if(e.ColumnIndex == 9)
            //{
            //    if (!Convert.ToBoolean(dgw1.CurrentRow.Cells["X"].Value))
            //    {
            //        chkTodos.Checked = false;
            //        chkTodos.Enabled = true;
            //    }
            //}
        }

        private void dgw1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgw1.IsCurrentCellDirty)
            {
                dgw1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgw1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 9)
            {
                if (!Convert.ToBoolean(e.RowIndex))
                {
                    chkTodos.Checked = false;
                    chkTodos.Enabled = true;
                }
            }
        }

        private void chkAprob_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAprob.Checked)
            {
                foreach (DataGridViewRow row in dgw1.Rows)
                {
                    if (Convert.ToBoolean(row.Cells["ST_APROB"].Value))
                    {
                        row.Cells["X"].Value = true;
                    }
                }
            }
            else
            {
                foreach (DataGridViewRow row in dgw1.Rows)
                {
                    if (Convert.ToBoolean(row.Cells["ST_APROB"].Value))
                    {
                        row.Cells["X"].Value = false;
                    }
                }
            }
        }

        private void chkPreApr_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPreApr.Checked)
            {
                foreach (DataGridViewRow row in dgw1.Rows)
                {
                    if (Convert.ToBoolean(row.Cells["ST_PRE_APROB"].Value))
                    {
                        row.Cells["X"].Value = true;
                    }
                }
            }
            else
            {
                foreach (DataGridViewRow row in dgw1.Rows)
                {
                    if (Convert.ToBoolean(row.Cells["ST_PRE_APROB"].Value))
                    {
                        row.Cells["X"].Value = false;
                    }
                }
            }
        }

        private void dgw_Click(object sender, EventArgs e)
        {
            llenaDetalle();
        }

        private void dgw_SelectionChanged(object sender, EventArgs e)
        {
            if (dgw.Rows.Count > 0)
            {
                if (dgw.CurrentRow.Cells["NRO_CONTRATO"].Value != null)
                    llenaDetalle();
            }
        }
        private void llenaDetalle()
        {
            dgw2.Rows.Clear();
            string nro_contrato = dgw.CurrentRow.Cells["NRO_CONTRATO"].Value.ToString();
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
                            row.Cells["TIPO_VTA3"].Value = rw["TIPO_VTA"].ToString();
                            row.Cells["COD_PROGRAMA3"].Value = rw["COD_PROGRAMA"].ToString();
                            row.Cells["COD_PER_SUP3"].Value = rw["COD_PER_SUP"].ToString();
                            row.Cells["NOM_PER_SUP3"].Value = rw["NOM_SUP"].ToString();
                            row.Cells["NRO_CONTRATO3"].Value = rw["NRO_CONTRATO"].ToString();
                            row.Cells["NRO_LETRA3"].Value = rw["NRO_LETRA"].ToString();
                            row.Cells["IMP_FIN3"].Value = rw["IMPORTE"].ToString();
                            row.Cells["COD_NIVEL3"].Value = rw["COD_NIVEL"].ToString();
                            row.Cells["DESC_NIVEL3"].Value = rw["DESC_NIVEL"].ToString();
                        }
                    }
                }
                else
                    dgw2.Rows.Clear();
            }
            else
                dgw2.Rows.Clear();
        }

    }
}
