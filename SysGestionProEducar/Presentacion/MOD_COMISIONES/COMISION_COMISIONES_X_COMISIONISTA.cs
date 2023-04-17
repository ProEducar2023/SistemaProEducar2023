using BLL;
using Entidades;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
namespace Presentacion.MOD_COMISIONES
{
    public partial class COMISION_COMISIONES_X_COMISIONISTA : Form
    {
        string AÑO = "", MES = "", COD_MOD = "", COD_USU = "", TIPO_USU = "", AÑO1 = "", MES1 = "";
        DateTime FECHA_INI, FECHA_GRAL;
        string tipo_pla, cod_prog, año, mes, cuota, preaprob;
        DataTable dtContratos, dtLiq = new DataTable();
        DataTable dtGeneral, dtPenLiq, dtTipoPlla = null;
        contratoCabeceraBLL conBLL = new contratoCabeceraBLL();
        contratoCabeceraTo conTo = new contratoCabeceraTo();
        pComisionBLL comBLL = new pComisionBLL();
        pComisionBLL pcoBLL = new pComisionBLL();
        pComisionTo comTo = new pComisionTo();
        pComisionTo pcoTo = new pComisionTo();
        pLiquidacionBLL liqBLL = new pLiquidacionBLL();
        pLiquidacionTo liqTo = new pLiquidacionTo();
        public COMISION_COMISIONES_X_COMISIONISTA(string AÑO, string MES, DateTime FECHA_INI, DateTime FECHA_GRAL, string COD_MOD, string TIPO_USU, string COD_USU)
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

        private void COMISION_COMISIONES_X_COMISIONISTA_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            CARGAR_AÑO();
            CARGAR_MES();
            TIPO_PLANILLA_GENERACION();
            TIPO_PLANILLA();
            CARGAR_PROGRAMAS_GENERACION();
            CARGAR_PROGRAMAS();
            CARGAR_CUOTA();
            LLENA_GRID_COMISIONES_GENERADAS();
            LLENA_GRID_COMISIONES_LIQUIDADAS();
            tabPage1.Text = "Generación de Comisiones " + HelpersBLL.OBTENER_NOM_MES(MES) + " " + AÑO;
            tabPage2.Text = "Liquidación de Comisiones " + HelpersBLL.OBTENER_NOM_MES(MES) + " " + AÑO;
            chkTodos.Enabled = false;
            cbo_mes.Focus();
        }
        private void TIPO_PLANILLA()
        {
            tipoPlanillaCreacionBLL tpllaBLL = new tipoPlanillaCreacionBLL();
            tipoPlanillaCreacionTo tpllaTo = new tipoPlanillaCreacionTo();
            tpllaTo.STATUS_GENERACION = "1";
            tpllaTo.COD_VENTA = "VTA";
            dtTipoPlla = tpllaBLL.obtenerTipoPlanillaCreacionxStGeneracionBLL(tpllaTo);
            if (dtTipoPlla.Rows.Count > 0)
            {
                cbo_tipo.ValueMember = "COD_TIPO_PLLA";
                cbo_tipo.DisplayMember = "DESC_TIPO";
                cbo_tipo.DataSource = dtTipoPlla;
                cbo_tipo.SelectedIndex = 0;
            }
        }
        private void TIPO_PLANILLA_GENERACION()
        {
            tipoPlanillaCreacionBLL tpllaBLL = new tipoPlanillaCreacionBLL();
            tipoPlanillaCreacionTo tpllaTo = new tipoPlanillaCreacionTo();
            tpllaTo.STATUS_GENERACION = "1";
            tpllaTo.COD_VENTA = "VTA";
            dtTipoPlla = tpllaBLL.obtenerTipoPlanillaCreacionxStGeneracionBLL(tpllaTo);
            DataRow rw = dtTipoPlla.NewRow();
            rw["COD_TIPO_PLLA"] = "0";
            rw["DESC_TIPO"] = "TODAS";
            rw["CODIGO"] = "";
            rw["COD_TIPO_OPERACION"] = "";
            rw["DESC_CORTA"] = "";
            rw["OBSERVACION"] = "";
            rw["STATUS_GENERACION"] = "";
            dtTipoPlla.Rows.InsertAt(rw, 0);
            if (dtTipoPlla.Rows.Count > 0)
            {
                cboTipoPlanilla.ValueMember = "COD_TIPO_PLLA";
                cboTipoPlanilla.DisplayMember = "DESC_TIPO";
                cboTipoPlanilla.DataSource = dtTipoPlla;
                cboTipoPlanilla.SelectedIndex = 0;
            }
        }
        //private void TIPO_PLANILLA()
        //{
        //    var items = new[] { new { cod = "P", val = "PLANILLA" }, new { cod = "D", val = "DIRECTA" } };
        //    cbo_tipo.ValueMember = "cod";
        //    cbo_tipo.DisplayMember = "val";
        //    cbo_tipo.DataSource = items;
        //    cbo_tipo.SelectedIndex = 0;
        //}
        private void CARGAR_PROGRAMAS_GENERACION()
        {
            programaBLL prgBLL = new programaBLL();
            DataTable dt = prgBLL.obtenerProgramaBLL();
            cboPrograma.ValueMember = "COD_PROGRAMA";
            cboPrograma.DisplayMember = "DESC_PROGRAMA";
            cboPrograma.DataSource = dt;
            cboPrograma.SelectedIndex = 0;
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
            LLENA_GRID_COMISIONES_PENDIENTES_X_GENERAR();//para llenar grid de los no comisionados aún 
            //DATAGRID_INI_DGW();//para llenar grid de los ya comisionados o generados en el periodo (mes) elegido
            //lbltitulo.Text = "COMISIONES X CADA VENTA " + HelpersBLL.OBTENER_NOM_MES(cbo_mes.SelectedValue.ToString()) + " " + cbo_año.SelectedValue.ToString();
        }
        private void LLENA_GRID_COMISIONES_PENDIENTES_X_GENERAR()
        {
            conTo.FE_AÑO = AÑO1;
            conTo.FE_MES = MES1;
            conTo.COD_PROGRAMA = cboPrograma.SelectedValue.ToString();
            conTo.TIPO_PLANILLA = cboTipoPlanilla.SelectedValue.ToString() == "0" ? null : cboTipoPlanilla.SelectedValue.ToString();
            //trae contratos que no estan comisionados status_comision=0 y lo muestra en Pendientes por generar
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
        private void LLENA_GRID_COMISIONES_GENERADAS()
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
        private void btn_grabar_Click(object sender, EventArgs e)
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
                    //TabControl1.SelectedTab = TabPage2;
                    //DATAGRID_DGW();//adiciona el regitro comisionado en el grid de Comisiones del Periodo
                    LLENA_GRID_COMISIONES_GENERADAS();//adiciona el regitro comisionado en el grid de Comisiones del Periodo
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

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl2.SelectedTab = tabPage3;
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

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            tabControl2.SelectedTab = tabPage4;
        }

        private void dgw_SelectionChanged(object sender, EventArgs e)
        {
            if (dgw.Rows.Count > 0)
            {
                if (dgw.CurrentRow.Cells["NRO_CONTRATO"].Value != null)
                    llenaDetalleComisionesGeneradas();
            }
        }

        private void dgw_Click(object sender, EventArgs e)
        {
            if (dgw.Rows.Count > 0)
            {
                llenaDetalleComisionesGeneradas();
            }
        }
        private void llenaDetalleComisionesGeneradas()
        {
            dgw2.Rows.Clear();//detalle Comisiones Generadas
            string nro_contrato = dgw.CurrentRow.Cells["NRO_CONTRATO"].Value.ToString();//cabecera Comisiones Generadas
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
                    //DATAGRID_ADICIONAR_DGW1(comTo);
                    ////TabControl1.SelectedTab = TabPage1;
                    //DATAGRID_ELIMINAR_DGW(comTo);
                    LLENA_GRID_COMISIONES_PENDIENTES_X_GENERAR();
                    LLENA_GRID_COMISIONES_GENERADAS();
                }
            }
        }
        private bool validaEliminar()
        {
            bool result = true;
            string errMensaje = "";
            bool val = false;
            comTo.NRO_CONTRATO = dgw.CurrentRow.Cells["NRO_CONTRATO"].Value.ToString();
            if (!comBLL.verificaExisteNroContratoLiquidadoBLL(comTo, ref val, ref errMensaje))
            {
                MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return result = false;
            }
            else
            {
                if (val)
                {
                    MessageBox.Show("El contrato ya fue Liquidado", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return result = false;
                }
            }

            return result;
        }
        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btn_consulta1_Click(object sender, EventArgs e)
        {
            tipo_pla = cbo_tipo.SelectedValue.ToString();
            cod_prog = cbo_prog.SelectedValue.ToString();
            año = AÑO;//cbo_año.SelectedValue.ToString();
            mes = MES;//cbo_mes1.SelectedValue.ToString();
            cuota = cbo_cuota.SelectedValue.ToString();//txt_cuota.Text;
            preaprob = chk_preaprob.Checked ? "1" : "0";
            LLENA_GRID_COMISIONES_PENDIENTES_X_LIQUIDAR(tipo_pla, cod_prog, año, mes, cuota, preaprob);//dgw1
            //LLENA_GRID_COMISIONES_LIQUIDADAS(tipo_pla, cod_prog, año, mes);//esto era antes, pero debe verse todo lo que está pendiente por liquidar
            dgw1.Select();
        }
        private void LLENA_GRID_COMISIONES_PENDIENTES_X_LIQUIDAR(string TIPO_VTA, string COD_PROG, string AÑO, string MES, string LETRA, string PRE_APROB)
        {
            pcoTo.TIPO_VTA = TIPO_VTA;
            pcoTo.COD_PROGRAMA = COD_PROG;
            pcoTo.FE_AÑO = AÑO;
            pcoTo.FE_MES = MES;
            pcoTo.NRO_LETRA = LETRA;
            pcoTo.STATUS_PRE_APROB = PRE_APROB;
            dgwComPenLiq.Rows.Clear();
            dgwComPenLiqDet.Rows.Clear();
            if (pcoTo.NRO_LETRA == "000")
                dtPenLiq = pcoBLL.obtenerPComisionPorPeriodoBLL(pcoTo);
            else
                dtPenLiq = pcoBLL.obtenerPComisionDif000BLL(pcoTo);
            //
            if (dtPenLiq.Rows.Count > 0)
            {
                DataTable dt1 = dtPenLiq.AsEnumerable()
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
                        int rowId = dgwComPenLiq.Rows.Add();
                        DataGridViewRow row = dgwComPenLiq.Rows[rowId];
                        row.Cells["TIPO_VTA_P"].Value = rw["TIPO_VTA"].ToString();
                        row.Cells["COD_PROGRAMA_P"].Value = rw["COD_PROGRAMA"].ToString();
                        row.Cells["COD_VENDEDOR_P"].Value = rw["COD_VENDEDOR"].ToString();
                        row.Cells["DESC_PER_P"].Value = rw["DESC_PER"].ToString();
                        row.Cells["NRO_CONTRATO_P"].Value = rw["NRO_CONTRATO"].ToString();
                        row.Cells["FE_CONTRATO_P"].Value = rw["FE_CONTRATO"].ToString().Substring(0, 10);
                        row.Cells["FE_AÑO_P"].Value = rw["FE_AÑO"].ToString();
                        row.Cells["FE_MES_P"].Value = rw["FE_MES"].ToString();
                        row.Cells["COD_PER_P"].Value = rw["COD_PER"].ToString();
                        row.Cells["NOMCLI_P"].Value = rw["NOMCLI"].ToString();
                        row.Cells["NRO_LETRA_P"].Value = rw["NRO_LETRA"].ToString();
                        row.Cells["STATUS_PRE_APROB_P"].Value = rw["STATUS_PRE_APROB"].ToString() == "0" ? "A" : "P";//Aprobado y Pre-Aprobado
                        row.Cells["COD_PER_SUP_P"].Value = rw["COD_PER_SUP"].ToString();
                        row.Cells["IMP_FIN_P"].Value = rw["IMP_FIN"].ToString();
                        row.Cells["COD_NIVEL_P"].Value = rw["COD_NIVEL"].ToString();
                        row.Cells["X_P"].Value = true;
                    }
                }
            }
            else
            {
                MessageBox.Show("No se encontraron registros !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        //private void LLENA_GRID_COMISIONES_LIQUIDADAS(string TIPO_VTA, string COD_PROG, string AÑO, string MES)
        private void LLENA_GRID_COMISIONES_LIQUIDADAS()
        {
            //pcoTo.TIPO_VTA = TIPO_VTA;
            //pcoTo.COD_PROGRAMA = COD_PROG;
            pcoTo.FE_AÑO = AÑO;
            pcoTo.FE_MES = MES;
            dtLiq = pcoBLL.obtenerPLiquidacionporPeriodoBLL(pcoTo);
            dgwComLiq.Rows.Clear();
            if (dtLiq.Rows.Count > 0)
            {
                DataTable dt1 = dtLiq.AsEnumerable()
                   .GroupBy(r => new
                   {
                       Col01 = r["TIPO_VTA"],
                       Col02 = r["COD_PROGRAMA"],
                       Col05 = r["NRO_CONTRATO"],
                       Col11 = r["NRO_LETRA"]
                   })
                   .Select(g => g.OrderBy(r => r["NRO_CONTRATO"]).First())
                   .CopyToDataTable();
                //
                if (dt1.Rows.Count > 0)
                {
                    foreach (DataRow rw in dt1.Rows)
                    {
                        int rowId = dgwComLiq.Rows.Add();
                        DataGridViewRow row = dgwComLiq.Rows[rowId];
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
        private void dgwComPenLiq_SelectionChanged(object sender, EventArgs e)
        {
            if (dgwComPenLiq.Rows.Count > 0)
            {
                if (dgwComPenLiq.CurrentRow.Cells["NRO_CONTRATO_P"].Value != null)
                    llenaDetalleComisionesxLiquidar();
            }
        }

        private void dgwComPenLiq_Click(object sender, EventArgs e)
        {
            if (dgwComPenLiq.Rows.Count > 0)
            {
                llenaDetalleComisionesxLiquidar();
            }
        }
        private void llenaDetalleComisionesxLiquidar()
        {
            dgwComPenLiqDet.Rows.Clear();
            string nro_contrato = dgwComPenLiq.CurrentRow.Cells["NRO_CONTRATO_P"].Value.ToString();
            DataTable dtDetalle = null;
            if (dtPenLiq.Rows.Count > 0)
            {
                DataRow[] fila = dtPenLiq.Select("NRO_CONTRATO = '" + nro_contrato + "'");
                if (fila.Length > 0)
                {
                    dtDetalle = fila.CopyToDataTable();
                    if (dtDetalle.Rows.Count > 0)
                    {
                        foreach (DataRow rw in dtDetalle.Rows)
                        {
                            int rowId = dgwComPenLiqDet.Rows.Add();
                            DataGridViewRow row = dgwComPenLiqDet.Rows[rowId];
                            row.Cells["TIPO_VTA1_P"].Value = rw["TIPO_VTA"].ToString();
                            row.Cells["COD_PROGRAMA1_P"].Value = rw["COD_PROGRAMA"].ToString();
                            row.Cells["COD_PER_SUP1_P"].Value = rw["COD_PER_SUP"].ToString();
                            row.Cells["NOM_PER_SUP1_P"].Value = rw["NOMSUP"].ToString();
                            row.Cells["NRO_CONTRATO1_P"].Value = rw["NRO_CONTRATO"].ToString();
                            row.Cells["NRO_LETRA1_P"].Value = rw["NRO_LETRA"].ToString();
                            row.Cells["IMP_FIN1_P"].Value = rw["IMP_FIN"].ToString();
                            row.Cells["COD_NIVEL1_P"].Value = rw["COD_NIVEL"].ToString();
                            row.Cells["DESC_NIVEL1_P"].Value = rw["DESC_NIVEL"].ToString();
                        }
                    }
                }
                else
                    dgwComPenLiqDet.Rows.Clear();
            }
            else
                dgwComPenLiqDet.Rows.Clear();
        }
        private void btn_nuevo2_Click(object sender, EventArgs e)
        {
            tabControl3.SelectedTab = tabPage6;
        }

        private void btn_grabar2_Click(object sender, EventArgs e)
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
                    //OBTENER_L_LIQUIDADO_POR_PERIODO(tipo_pla, cod_prog, año, mes);//dgw3 el grid de fondo Liquidaciones del Periodo
                    LLENA_GRID_COMISIONES_LIQUIDADAS();
                    QUITAR_FILAS_MARCADAS();
                    dgwComPenLiqDet.Rows.Clear();
                    //txt_cuota.Clear();
                    cbo_cuota.SelectedIndex = 0;
                    chk_preaprob.Checked = false;
                    //txt_cuota.Focus();
                    cbo_cuota.Focus();
                }
            }
        }
        private void QUITAR_FILAS_MARCADAS()
        {
            for (int i = dgwComPenLiq.Rows.Count - 1; i >= 0; i--)
            {
                if (Convert.ToBoolean(dgwComPenLiq.Rows[i].Cells["X_P"].Value))
                    dgwComPenLiq.Rows.RemoveAt(dgwComPenLiq.Rows[i].Index);
            }
        }
        private DataTable OBTENER_COMISIONES_PARA_LIQUIDAR()
        {
            DataTable dt = dtPenLiq.Copy();
            dt.Columns.Add("op");
            string nro_contrato;
            foreach (DataGridViewRow row in dgwComPenLiq.Rows)
            {
                if (Convert.ToBoolean(row.Cells["X_P"].Value))
                {
                    nro_contrato = row.Cells["NRO_CONTRATO_P"].Value.ToString();
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

        private void dgwComLiq_SelectionChanged(object sender, EventArgs e)
        {
            if (dgwComLiq.Rows.Count > 0)
            {
                if (dgwComLiq.CurrentRow.Cells["NRO_CONTRATO2"].Value != null)
                    llenaDetalleComisionesLiquidadas();
            }
        }

        private void dgwComLiq_Click(object sender, EventArgs e)
        {
            if (dgwComLiq.Rows.Count > 0)
            {
                llenaDetalleComisionesLiquidadas();
            }
        }
        private void llenaDetalleComisionesLiquidadas()
        {
            dgwComLiqDet.Rows.Clear();
            string nro_contrato = dgwComLiq.CurrentRow.Cells["NRO_CONTRATO2"].Value.ToString();
            string nro_letra = dgwComLiq.CurrentRow.Cells["NRO_LETRA2"].Value.ToString();
            DataTable dtDetalle = null;
            if (dtLiq.Rows.Count > 0)
            {
                DataRow[] fila = dtLiq.Select("NRO_CONTRATO = '" + nro_contrato + "' AND NRO_LETRA = '" + nro_letra + "'");
                if (fila.Length > 0)
                {
                    dtDetalle = fila.CopyToDataTable();
                    if (dtDetalle.Rows.Count > 0)
                    {
                        foreach (DataRow rw in dtDetalle.Rows)
                        {
                            int rowId = dgwComLiqDet.Rows.Add();
                            DataGridViewRow row = dgwComLiqDet.Rows[rowId];
                            row.Cells["TIPO_VTA1_D"].Value = rw["TIPO_VTA"].ToString();
                            row.Cells["COD_PROGRAMA1_D"].Value = rw["COD_PROGRAMA"].ToString();
                            row.Cells["COD_PER_SUP1_D"].Value = rw["COD_PER_SUP"].ToString();
                            row.Cells["NOM_PER_SUP1_D"].Value = rw["NOMSUP"].ToString();
                            row.Cells["NRO_CONTRATO1_D"].Value = rw["NRO_CONTRATO"].ToString();
                            row.Cells["NRO_LETRA1_D"].Value = rw["NRO_LETRA"].ToString();
                            row.Cells["IMP_FIN1_D"].Value = rw["IMP_FIN"].ToString();
                            row.Cells["COD_NIVEL1_D"].Value = rw["COD_NIVEL"].ToString();
                            row.Cells["DESC_NIVEL1_D"].Value = rw["DESC_NIVEL"].ToString();
                        }
                    }
                }
                else
                    dgwComLiqDet.Rows.Clear();
            }
            else
                dgwComLiqDet.Rows.Clear();
        }

        private void btn_cancelar2_Click(object sender, EventArgs e)
        {
            tabControl3.SelectedTab = tabPage5;
        }

        private void btn_salir2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btn_eliminar2_Click(object sender, EventArgs e)
        {
            if (!validaEliminar())
                return;

            DialogResult rs = MessageBox.Show("¿ Esta seguro de Eliminar las Liquidaciones del Contrato " + dgwComLiq.CurrentRow.Cells["NRO_CONTRATO2"].Value.ToString() + "\n con Nro de Cuota " + dgwComLiq.CurrentRow.Cells["NRO_LETRA2"].Value.ToString() + " ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                liqTo.TIPO_VTA = dgwComLiq.CurrentRow.Cells["TIPO_VTA2"].Value.ToString();
                liqTo.COD_PROGRAMA = dgwComLiq.CurrentRow.Cells["COD_PROGRAMA2"].Value.ToString();
                liqTo.COD_COMISIONANTE = dgwComLiq.CurrentRow.Cells["COD_PROGRAMA2"].Value.ToString();
                liqTo.NRO_CONTRATO = dgwComLiq.CurrentRow.Cells["NRO_CONTRATO2"].Value.ToString();
                liqTo.NRO_LETRA = dgwComLiq.CurrentRow.Cells["NRO_LETRA2"].Value.ToString();
                liqTo.COD_NIVEL = dgwComLiq.CurrentRow.Cells["COD_NIVEL2"].Value.ToString();
                liqTo.STATUS_PRE_APROB = dgwComLiq.CurrentRow.Cells["STATUS_PRE_APROB2"].Value.ToString();
                liqTo.FE_AÑO = dgwComLiq.CurrentRow.Cells["FE_AÑO2"].Value.ToString();
                liqTo.FE_MES = dgwComLiq.CurrentRow.Cells["FE_MES2"].Value.ToString();
                liqTo.IMPORTE = Convert.ToDecimal(dgwComLiq.CurrentRow.Cells["IMP_FIN2"].Value);
                liqTo.COD_VENDEDOR = dgwComLiq.CurrentRow.Cells["COD_VENDEDOR2"].Value.ToString();
                liqTo.COD_PER_SUP = dgwComLiq.CurrentRow.Cells["COD_PER_SUP2"].Value.ToString();
                liqTo.COD_MODIF = COD_USU;
                liqTo.COD_CREA = COD_USU;
                liqTo.FECHA_MODIF = DateTime.Now;
                liqTo.FECHA_CREA = DateTime.Now;

                if (!liqBLL.eliminaLiquidacionxCuotaBLL(liqTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Las Liquidaciones se eliminaron correctamente !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //DATAGRID_ELIMINAR_DGW();
                    LLENA_GRID_COMISIONES_LIQUIDADAS();
                    dgwComLiqDet.Rows.Clear();
                }
            }
        }

        private void btn_kardex_Click(object sender, EventArgs e)
        {
            if (dgwComPenLiq.Rows.Count > 0)
            {
                string nro_contrato = dgwComPenLiq.CurrentRow.Cells["NRO_CONTRATO_P"].Value.ToString();
                CONSULTA_KARDEX_X_CONTRATO frm = new CONSULTA_KARDEX_X_CONTRATO(nro_contrato);
                frm.ShowDialog();
            }
        }

        private void dgwComPenLiqDet_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataRow rw in dtPenLiq.Rows)
            {
                if (dgwComPenLiqDet.Rows[e.RowIndex].Cells["TIPO_VTA1_P"].Value.ToString() == rw["TIPO_VTA"].ToString() && dgwComPenLiqDet.Rows[e.RowIndex].Cells["COD_PROGRAMA1_P"].Value.ToString() == rw["COD_PROGRAMA"].ToString() &&
                        dgwComPenLiqDet.Rows[e.RowIndex].Cells["NRO_CONTRATO1_P"].Value.ToString() == rw["NRO_CONTRATO"].ToString() && dgwComPenLiqDet.Rows[e.RowIndex].Cells["COD_PER_SUP1_P"].Value.ToString() == rw["COD_PER_SUP"].ToString() &&
                        dgwComPenLiqDet.Rows[e.RowIndex].Cells["NRO_LETRA1_P"].Value.ToString() == rw["NRO_LETRA"].ToString() && dgwComPenLiqDet.Rows[e.RowIndex].Cells["COD_NIVEL1_P"].Value.ToString() == rw["COD_NIVEL"].ToString())
                {
                    rw["IMP_FIN"] = dgwComPenLiqDet.Rows[e.RowIndex].Cells["IMP_FIN1_P"].Value;
                    break;
                }
            }

            //int i = 0;
            //i = e.RowIndex;
            //if (i != dgwComPenLiqDet.Rows.Count - 1)
            //{
            //    dgwComPenLiqDet.Rows[i].Selected = true;
            //    dgwComPenLiqDet.CurrentCell = dgwComPenLiqDet.Rows[i + 1].Cells[0];

            //}

        }

        private void cbo_tipo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
