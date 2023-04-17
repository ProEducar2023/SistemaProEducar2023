using BLL;
using Entidades;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Presentacion.MOD_COMISIONES
{
    public partial class DEVOLUCION_COMISIONES_X_COMISIONISTA : Form
    {
        string AÑO = "", MES = "", COD_MOD = "", COD_USU = "", TIPO_USU = "";
        DateTime FECHA_INI, FECHA_GRAL;
        DataTable dtDevPenGen, dtDevGen, dtDevPenLiq, dtDevLiq;
        pDevolucionBLL pdevBLL = new pDevolucionBLL();
        pDevolucionTo pdevTo = new pDevolucionTo();
        pLiqDevolucionBLL pldBLL = new pLiqDevolucionBLL();
        pLiqDevolucionTo pldTo = new pLiqDevolucionTo();
        contratoCabeceraBLL conBLL = new contratoCabeceraBLL();
        contratoCabeceraTo conTo = new contratoCabeceraTo();
        public DEVOLUCION_COMISIONES_X_COMISIONISTA(string AÑO, string MES, DateTime FECHA_INI, DateTime FECHA_GRAL, string COD_MOD, string TIPO_USU, string COD_USU)
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

        private void DEVOLUCION_COMISIONES_X_COMISIONISTA_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            LLENA_GRID_DEVOLUCIONES_PENDIENTES_X_GENERAR();//pendiente de generar devoluciones
            LLENA_GRID_DEVOLUCIONES_GENERADAS();
            LLENA_GRID_DEVOLUCIONES_PENDIENTES_X_LIQUIDAR();
            LLENA_GRID_LIQUIDACIONES_GENERADAS();
        }
        private void LLENA_GRID_LIQUIDACIONES_GENERADAS()
        {
            pldTo.FE_AÑO = AÑO;
            pldTo.FE_MES = MES;
            dtDevLiq = pldBLL.obtenerDevolucionesLiquidadasBLL(pldTo);
            dgwDevLiq.Rows.Clear();

            if (dtDevLiq.Rows.Count > 0)
            {
                DataTable dt1 = dtDevLiq.AsEnumerable()
                   .GroupBy(r => new
                   {
                       Col01 = r["TIPO_VTA"],
                       Col02 = r["COD_PROGRAMA"],
                       Col03 = r["COD_VENDEDOR"],//
                       Col04 = r["VEND"],
                       Col05 = r["NRO_CONTRATO"],//
                       Col06 = r["FE_CONTRATO"],//
                       Col09 = r["COD_PER"],//
                       Col10 = r["NOMCLI"]//
                       //Col11 = r["NRO_LETRA"],
                   })
                   .Select(g => g.OrderBy(r => r["NRO_CONTRATO"]).First())
                   .CopyToDataTable();
                //
                if (dt1.Rows.Count > 0)
                {
                    foreach (DataRow rw in dt1.Rows)
                    {
                        int rowId = dgwDevLiq.Rows.Add();
                        DataGridViewRow row = dgwDevLiq.Rows[rowId];
                        row.Cells["NRO_CONTRATO6"].Value = rw["NRO_CONTRATO"].ToString();
                        row.Cells["COD_VENDEDOR6"].Value = rw["COD_VENDEDOR"].ToString();
                        row.Cells["VEND6"].Value = rw["VEND"].ToString();
                        row.Cells["FE_CONTRATO6"].Value = rw["FE_CONTRATO"].ToString().Substring(0, 10);
                        row.Cells["COD_PER6"].Value = rw["COD_PER"].ToString();
                        row.Cells["NOMCLI6"].Value = rw["NOMCLI"].ToString();
                        row.Cells["COD_PROGRAMA6"].Value = rw["COD_PROGRAMA"].ToString();
                        row.Cells["TIPO_VTA6"].Value = rw["TIPO_VTA"].ToString();
                        row.Cells["NRO_LETRA6"].Value = rw["NRO_LETRA"].ToString();
                        row.Cells["COD_NIVEL6"].Value = rw["COD_NIVEL"].ToString();
                        row.Cells["DESC_NIVEL6"].Value = rw["DESC_NIVEL"].ToString();
                        row.Cells["IMP_INI6"].Value = rw["IMP_INI"].ToString();
                        row.Cells["COD_PER_SUP6"].Value = rw["COD_COMISIONANTE"].ToString();
                        row.Cells["NOMSUP6"].Value = rw["NOMSUP"].ToString();

                    }
                }
            }
            else
            {
                //MessageBox.Show("No se encontraron registros !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void LLENA_GRID_DEVOLUCIONES_PENDIENTES_X_GENERAR()
        {
            dtDevPenGen = conBLL.obtenerContratoCabeceraparaDevolucionesBLL();
            dgwDevPenGen.Rows.Clear();

            if (dtDevPenGen.Rows.Count > 0)
            {
                DataTable dt1 = dtDevPenGen.AsEnumerable()
                   .GroupBy(r => new
                   {
                       Col01 = r["TIPO_PLANILLA"],
                       Col02 = r["COD_PROGRAMA"],
                       Col03 = r["COD_VENDEDOR"],//
                       Col04 = r["DESC_PER"],
                       Col05 = r["NRO_PRESUPUESTO"],//
                       Col06 = r["FECHA_PRE"],//
                       Col09 = r["COD_PER"],//
                       Col10 = r["DESC_PER"]//
                       //Col11 = r["NRO_LETRA"],
                   })
                   .Select(g => g.OrderBy(r => r["NRO_PRESUPUESTO"]).First())
                   .CopyToDataTable();
                //
                if (dt1.Rows.Count > 0)
                {
                    foreach (DataRow rw in dt1.Rows)
                    {
                        int rowId = dgwDevPenGen.Rows.Add();
                        DataGridViewRow row = dgwDevPenGen.Rows[rowId];
                        row.Cells["NRO_PRESUPUESTO"].Value = rw["NRO_PRESUPUESTO"].ToString();
                        row.Cells["COD_VENDEDOR"].Value = rw["COD_VENDEDOR"].ToString();
                        row.Cells["VEND"].Value = rw["VEND"].ToString();
                        row.Cells["FECHA_PRE"].Value = rw["FECHA_PRE"].ToString().Substring(0, 10);
                        row.Cells["COD_PER"].Value = rw["COD_PER"].ToString();
                        row.Cells["DESC_PER"].Value = rw["DESC_PER"].ToString();
                        row.Cells["COD_PROGRAMA"].Value = rw["COD_PROGRAMA"].ToString();
                        row.Cells["TIPO_PLANILLA"].Value = rw["TIPO_PLANILLA"].ToString();
                        row.Cells["NRO_LETRA"].Value = rw["NRO_LETRA"].ToString();
                        row.Cells["COD_NIVEL"].Value = rw["COD_NIVEL"].ToString();
                        row.Cells["DESC_NIVEL"].Value = rw["DESC_NIVEL"].ToString();
                        row.Cells["IMP_INI"].Value = rw["IMP_INI"].ToString();
                        row.Cells["COD_COMISIONANTE"].Value = rw["COD_COMISIONANTE"].ToString();
                        row.Cells["NOMSUP"].Value = rw["NOMSUP"].ToString();
                        row.Cells["NRO_FAC_PRE_UNI"].Value = rw["NRO_FAC_PRE_UNI"].ToString();
                        row.Cells["FECHA_FAC_PRE_UNI"].Value = rw["FECHA_FAC_PRE_UNI"].ToString().Substring(0, 10);
                        row.Cells["X"].Value = true;
                    }
                }
            }
            else
            {
                //MessageBox.Show("No se encontraron registros !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        public void LLENA_GRID_DEVOLUCIONES_GENERADAS()
        {
            pdevTo.FE_AÑO = AÑO;
            pdevTo.FE_MES = MES;
            dtDevGen = pdevBLL.obtenerPDevolucionBLL(pdevTo);

            if (dtDevGen.Rows.Count > 0)
            {
                DataTable dt1 = dtDevGen.AsEnumerable()
                   .GroupBy(r => new
                   {
                       Col01 = r["TIPO_VTA"],
                       Col02 = r["COD_PROGRAMA"],
                       Col03 = r["COD_VENDEDOR"],//
                       Col04 = r["VEND"],
                       Col05 = r["NRO_CONTRATO"]//
                       //Col06 = r["FE_CONTRATO"],//
                       //Col09 = r["COD_PER"],//
                       //Col10 = r["CLIE"]//
                       //Col11 = r["NRO_LETRA"],
                   })
                   .Select(g => g.OrderBy(r => r["NRO_CONTRATO"]).First())
                   .CopyToDataTable();
                //
                if (dt1.Rows.Count > 0)
                {
                    foreach (DataRow rw in dt1.Rows)
                    {
                        int rowId = dgwDevGen.Rows.Add();
                        DataGridViewRow row = dgwDevGen.Rows[rowId];
                        row.Cells["TIPO_PLANILLA2"].Value = rw["TIPO_VTA"].ToString();
                        row.Cells["COD_PROGRAMA2"].Value = rw["COD_PROGRAMA"].ToString();
                        row.Cells["COD_COMISIONANTE2"].Value = rw["COD_PER_SUP"].ToString();
                        row.Cells["NOMCOMI2"].Value = rw["NOM_COMI"].ToString();
                        row.Cells["NRO_CONTRATO2"].Value = rw["NRO_CONTRATO"].ToString();
                        row.Cells["NRO_LETRA2"].Value = rw["NRO_LETRA"].ToString();
                        row.Cells["COD_NIVEL2"].Value = rw["COD_NIVEL"].ToString();
                        row.Cells["DESC_NIVEL2"].Value = rw["DESC_NIVEL"].ToString();
                        row.Cells["COD_VENDEDOR2"].Value = rw["COD_VENDEDOR"].ToString();
                        row.Cells["VEND2"].Value = rw["VEND"].ToString();
                        row.Cells["FE_CONTRATO2"].Value = rw["FE_CONTRATO"].ToString().Substring(0, 10);
                        row.Cells["COD_PER2"].Value = rw["COD_PER"].ToString();
                        row.Cells["NOMCLI2"].Value = rw["CLIE"].ToString();
                        row.Cells["IMPORTE2"].Value = rw["IMPORTE"].ToString();
                        row.Cells["NRO_FAC_PRE_UNI2"].Value = rw["NRO_FAC_PRE_UNI"].ToString();
                    }
                }
            }
            else
            {
                //MessageBox.Show("No se encontraron registros !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        public void LLENA_GRID_DEVOLUCIONES_PENDIENTES_X_LIQUIDAR()
        {
            pdevTo.FE_AÑO = AÑO;
            pdevTo.FE_MES = MES;
            dtDevPenLiq = pdevBLL.obtenerDevolucionesPendientesxLiquidarBLL(pdevTo);
            dgwDevPenLiq.Rows.Clear();

            if (dtDevPenLiq.Rows.Count > 0)
            {
                DataTable dt1 = dtDevPenLiq.AsEnumerable()
                   .GroupBy(r => new
                   {
                       Col01 = r["TIPO_VTA"],
                       Col02 = r["COD_PROGRAMA"],
                       Col03 = r["COD_VENDEDOR"],//
                       Col04 = r["VEND"],
                       Col05 = r["NRO_CONTRATO"],//
                       Col06 = r["FE_CONTRATO"],//
                       Col09 = r["COD_PER"],//
                       Col10 = r["NOMCLI"]//
                       //Col11 = r["NRO_LETRA"],
                   })
                   .Select(g => g.OrderBy(r => r["NRO_CONTRATO"]).First())
                   .CopyToDataTable();
                //
                if (dt1.Rows.Count > 0)
                {
                    foreach (DataRow rw in dt1.Rows)
                    {
                        int rowId = dgwDevPenLiq.Rows.Add();
                        DataGridViewRow row = dgwDevPenLiq.Rows[rowId];
                        row.Cells["NRO_CONTRATO4"].Value = rw["NRO_CONTRATO"].ToString();
                        row.Cells["COD_VENDEDOR4"].Value = rw["COD_VENDEDOR"].ToString();
                        row.Cells["VEND4"].Value = rw["VEND"].ToString();
                        row.Cells["FE_CONTRATO4"].Value = rw["FE_CONTRATO"].ToString().Substring(0, 10);
                        row.Cells["COD_PER4"].Value = rw["COD_PER"].ToString();
                        row.Cells["NOMCLI4"].Value = rw["NOMCLI"].ToString();
                        row.Cells["COD_PROGRAMA4"].Value = rw["COD_PROGRAMA"].ToString();
                        row.Cells["TIPO_VTA4"].Value = rw["TIPO_VTA"].ToString();
                        row.Cells["NRO_LETRA4"].Value = rw["NRO_LETRA"].ToString();
                        row.Cells["COD_NIVEL4"].Value = rw["COD_NIVEL"].ToString();
                        row.Cells["DESC_NIVEL4"].Value = rw["DESC_NIVEL"].ToString();
                        row.Cells["IMP_INI4"].Value = rw["IMP_INI"].ToString();
                        row.Cells["COD_PER_SUP4"].Value = rw["COD_PER_SUP"].ToString();
                        row.Cells["NOMSUP4"].Value = rw["NOMSUP"].ToString();

                    }
                }
            }
            else
            {
                //MessageBox.Show("No se encontraron registros !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void dgwDevPenGen_Click(object sender, EventArgs e)
        {
            if (dgwDevPenGen.Rows.Count > 0)
                llenaDetallePenGen();
        }
        private void dgwDevPenGen_SelectionChanged(object sender, EventArgs e)
        {
            if (dgwDevPenGen.Rows.Count > 0)
            {
                if (dgwDevPenGen.CurrentRow.Cells["NRO_PRESUPUESTO"].Value != null)
                    llenaDetallePenGen();
            }
        }
        private void llenaDetallePenGen()
        {
            dgwDevPenGenDet.Rows.Clear();
            string nro_contrato = dgwDevPenGen.CurrentRow.Cells["NRO_PRESUPUESTO"].Value.ToString();
            DataTable dtDetalle = null;
            if (dtDevPenGen.Rows.Count > 0)
            {
                DataRow[] fila = dtDevPenGen.Select("NRO_PRESUPUESTO = '" + nro_contrato + "'");
                if (fila.Length > 0)
                {
                    dtDetalle = fila.CopyToDataTable();
                    if (dtDetalle.Rows.Count > 0)
                    {
                        foreach (DataRow rw in dtDetalle.Rows)
                        {
                            int rowId = dgwDevPenGenDet.Rows.Add();
                            DataGridViewRow row = dgwDevPenGenDet.Rows[rowId];
                            row.Cells["TIPO_PLANILLA1"].Value = rw["TIPO_PLANILLA"].ToString();
                            row.Cells["COD_PROGRAMA1"].Value = rw["COD_PROGRAMA"].ToString();
                            row.Cells["COD_COMISIONANTE1"].Value = rw["COD_COMISIONANTE"].ToString();
                            row.Cells["NOMSUP1"].Value = rw["NOMSUP"].ToString();
                            row.Cells["NRO_PRESUPUESTO1"].Value = rw["NRO_PRESUPUESTO"].ToString();
                            row.Cells["NRO_LETRA1"].Value = rw["NRO_LETRA"].ToString();
                            row.Cells["IMP_INI1"].Value = rw["IMP_INI"].ToString();
                            row.Cells["COD_NIVEL1"].Value = rw["COD_NIVEL"].ToString();
                            row.Cells["DESC_NIVEL1"].Value = rw["DESC_NIVEL"].ToString();
                        }
                    }
                }
                else
                    dgwDevPenGenDet.Rows.Clear();
            }
            else
                dgwDevPenGenDet.Rows.Clear();
        }
        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            tabControl2.SelectedTab = tabPage4;
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            tabControl2.SelectedTab = tabPage3;
        }

        private void btn_grabar_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("¿ Esta seguro de Generar las Devoluciones para estos Contratos ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";

                pdevTo.FE_AÑO = AÑO;
                pdevTo.FE_MES = MES;
                pdevTo.COD_CREA = COD_USU;
                pdevTo.FE_DOC = DateTime.Now;
                pdevTo.FECHA_CREA = DateTime.Now;
                DataTable dtDevolucion = OBTENER_DEVOLUCIONES_PARA_GENERAR();

                if (!pdevBLL.GeneracionDevolucionBLL(pdevTo, dtDevolucion, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Las Devoluciones se Generaron correctamente !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    QUITAR_FILAS_MARCADAS_DGW_PEN_GENERACION();
                    dgwDevPenGenDet.Rows.Clear();
                    LLENA_GRID_DEVOLUCIONES_GENERADAS();
                    LLENA_GRID_DEVOLUCIONES_PENDIENTES_X_LIQUIDAR();
                }
            }
        }
        private DataTable OBTENER_DEVOLUCIONES_PARA_GENERAR()
        {
            DataTable dt = dtDevPenGen.Copy();
            dt.Columns.Add("op");
            string nro_contrato;
            foreach (DataGridViewRow row in dgwDevPenGen.Rows)
            {
                if (Convert.ToBoolean(row.Cells["X"].Value))
                {
                    nro_contrato = row.Cells["NRO_PRESUPUESTO"].Value.ToString();
                    foreach (DataRow rw in dt.Rows)
                    {
                        if (rw["NRO_PRESUPUESTO"].ToString() == nro_contrato)
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
        private void QUITAR_FILAS_MARCADAS_DGW_PEN_GENERACION()
        {
            dgwDevPenGen.Rows.Remove(dgwDevPenGen.CurrentRow);
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dgwDevGen_Click(object sender, EventArgs e)
        {
            if (dgwDevGen.Rows.Count > 0)
                llenaDetalleGen();
        }

        private void dgwDevGen_SelectionChanged(object sender, EventArgs e)
        {
            if (dgwDevGen.Rows.Count > 0)
            {
                if (dgwDevGen.CurrentRow.Cells["NRO_CONTRATO2"].Value != null)
                    llenaDetalleGen();
            }
        }
        private void llenaDetalleGen()
        {
            dgwDevGenDet.Rows.Clear();
            string nro_contrato = dgwDevGen.CurrentRow.Cells["NRO_CONTRATO2"].Value.ToString();
            DataTable dtDetalle = null;
            if (dtDevGen.Rows.Count > 0)
            {
                DataRow[] fila = dtDevGen.Select("NRO_CONTRATO = '" + nro_contrato + "'");
                if (fila.Length > 0)
                {
                    dtDetalle = fila.CopyToDataTable();
                    if (dtDetalle.Rows.Count > 0)
                    {
                        foreach (DataRow rw in dtDetalle.Rows)
                        {
                            int rowId = dgwDevGenDet.Rows.Add();
                            DataGridViewRow row = dgwDevGenDet.Rows[rowId];
                            row.Cells["TIPO_PLANILLA3"].Value = rw["TIPO_VTA"].ToString();
                            row.Cells["COD_PROGRAMA3"].Value = rw["COD_PROGRAMA"].ToString();
                            row.Cells["COD_COMISIONANTE3"].Value = rw["COD_PER_SUP"].ToString();
                            row.Cells["NOM_SUP3"].Value = rw["NOM_COMI"].ToString();
                            row.Cells["NRO_PRESUPUESTO3"].Value = rw["NRO_CONTRATO"].ToString();
                            row.Cells["NRO_LETRA3"].Value = rw["NRO_LETRA"].ToString();
                            row.Cells["IMP_INI3"].Value = rw["IMPORTE"].ToString();
                            row.Cells["COD_NIVEL3"].Value = rw["COD_NIVEL"].ToString();
                            row.Cells["DESC_NIVEL3"].Value = rw["DESC_NIVEL"].ToString();
                        }
                    }
                }
                else
                    dgwDevGenDet.Rows.Clear();
            }
            else
                dgwDevGenDet.Rows.Clear();
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (!validaEliminarDevolucionesGeneradas())
                return;
            DialogResult rs = MessageBox.Show("¿ Esta seguro de Eliminar la Devolucion Generada " + dgwDevGen.CurrentRow.Cells["NRO_CONTRATO2"].Value.ToString() + " ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                pdevTo.NRO_CONTRATO = dgwDevGen.CurrentRow.Cells["NRO_CONTRATO2"].Value.ToString();
                pdevTo.NRO_FAC_PRE_UNI = dgwDevGen.CurrentRow.Cells["NRO_FAC_PRE_UNI2"].Value.ToString();
                if (!pdevBLL.eliminaDevolucionesGeneradasBLL(pdevTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Las Devoluciones se eliminaron correctamente !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ELIMINAR_FILA_DGWDEVOLUCIONES_GENERADAS();
                    LLENA_GRID_DEVOLUCIONES_PENDIENTES_X_GENERAR();
                }
            }
        }
        private bool validaEliminarDevolucionesGeneradas()
        {
            bool result = true;
            string errMensaje = "";
            bool val = false;
            pdevTo.NRO_CONTRATO = dgwDevGen.CurrentRow.Cells["NRO_CONTRATO2"].Value.ToString();
            if (!pdevBLL.verificaExisteNroContratoLiquidadoBLL(pdevTo, ref val, ref errMensaje))
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
        public void ELIMINAR_FILA_DGWDEVOLUCIONES_GENERADAS()
        {
            dgwDevGen.Rows.Remove(dgwDevGen.CurrentRow);
            dgwDevGenDet.Rows.Clear();
        }
        public void ELIMINAR_FILA_DGWDEVOLUCIONES_LIQUIDADAS()
        {
            dgwDevLiqDet.Rows.Remove(dgwDevLiqDet.CurrentRow);
            //dgwDevGenDet.Rows.Clear();
        }
        private void dgwDevPenLiq_SelectionChanged(object sender, EventArgs e)
        {
            if (dgwDevPenLiq.Rows.Count > 0)
            {
                if (dgwDevPenLiq.CurrentRow.Cells["NRO_CONTRATO4"].Value != null)
                    llenaDetallePenLiq();
            }
        }

        private void dgwDevPenLiq_Click(object sender, EventArgs e)
        {
            if (dgwDevPenLiq.Rows.Count > 0)
                llenaDetallePenLiq();
        }
        private void llenaDetallePenLiq()
        {
            dgwDevPenLiqDet.Rows.Clear();
            string nro_contrato = dgwDevPenLiq.CurrentRow.Cells["NRO_CONTRATO4"].Value.ToString();
            DataTable dtDetalle = null;
            if (dtDevPenLiq.Rows.Count > 0)
            {
                DataRow[] fila = dtDevPenLiq.Select("NRO_CONTRATO = '" + nro_contrato + "'");
                if (fila.Length > 0)
                {
                    dtDetalle = fila.CopyToDataTable();
                    if (dtDetalle.Rows.Count > 0)
                    {
                        foreach (DataRow rw in dtDetalle.Rows)
                        {
                            int rowId = dgwDevPenLiqDet.Rows.Add();
                            DataGridViewRow row = dgwDevPenLiqDet.Rows[rowId];
                            row.Cells["TIPO_VTA5"].Value = rw["TIPO_VTA"].ToString();
                            row.Cells["COD_PROGRAMA5"].Value = rw["COD_PROGRAMA"].ToString();
                            row.Cells["COD_PER_SUP5"].Value = rw["COD_PER_SUP"].ToString();
                            row.Cells["NOMSUP5"].Value = rw["NOMSUP"].ToString();
                            row.Cells["NRO_CONTRATO5"].Value = rw["NRO_CONTRATO"].ToString();
                            row.Cells["NRO_LETRA5"].Value = rw["NRO_LETRA"].ToString();
                            row.Cells["IMP_INI5"].Value = rw["IMP_INI"].ToString();
                            row.Cells["COD_NIVEL5"].Value = rw["COD_NIVEL"].ToString();
                            row.Cells["DESC_NIVEL5"].Value = rw["DESC_NIVEL"].ToString();
                            row.Cells["Y"].Value = true;
                        }
                    }
                }
                else
                    dgwDevPenLiqDet.Rows.Clear();
            }
            else
                dgwDevPenLiqDet.Rows.Clear();
        }

        private void btn_Generar2_Click(object sender, EventArgs e)
        {
            tabControl3.SelectedTab = tabPage6;
        }

        private void btn_grabar2_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("¿ Esta seguro de Liquidar las Devoluciones ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                pldTo.FE_AÑO = AÑO;
                pldTo.FE_MES = MES;
                pldTo.COD_CREA = COD_USU;
                pldTo.FE_DOC = DateTime.Now;
                pldTo.FECHA_CREA = DateTime.Now;
                DataTable dtDevLiq = OBTENER_DEVOLUCIONES_PARA_LIQUIDAR();

                if (!pldBLL.LiquidacionDevolucionBLL(pldTo, dtDevLiq, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Las Devoluciones se Liquidaron correctamente !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //QUITAR_FILAS_MARCADAS_DGW_PEN_LIQUIDACION();
                    dgwDevPenGenDet.Rows.Clear();
                    dgwDevPenGen.Rows.Clear();
                    LLENA_GRID_DEVOLUCIONES_PENDIENTES_X_LIQUIDAR();
                    LLENA_GRID_DEVOLUCIONES_GENERADAS();
                    LLENA_GRID_LIQUIDACIONES_GENERADAS();
                }
            }
        }
        private DataTable OBTENER_DEVOLUCIONES_PARA_LIQUIDAR()
        {
            DataTable dt = dtDevPenLiq.Copy();
            dt.Columns.Add("op");
            string nro_contrato, cod_nivel, nro_letra;
            foreach (DataGridViewRow row in dgwDevPenLiqDet.Rows)
            {
                if (Convert.ToBoolean(row.Cells["Y"].Value))
                {
                    nro_contrato = row.Cells["NRO_CONTRATO5"].Value.ToString();
                    cod_nivel = row.Cells["COD_NIVEL5"].Value.ToString();
                    nro_letra = row.Cells["NRO_LETRA5"].Value.ToString();
                    foreach (DataRow rw in dt.Rows)
                    {
                        if (rw["NRO_CONTRATO"].ToString() == nro_contrato && rw["COD_NIVEL"].ToString() == cod_nivel && rw["NRO_LETRA"].ToString() == nro_letra)
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

        private void dgwDevLiq_SelectionChanged(object sender, EventArgs e)
        {
            if (dgwDevLiq.Rows.Count > 0)
            {
                if (dgwDevLiq.CurrentRow.Cells["NRO_CONTRATO6"].Value != null)
                    llenaDetalleDevLiq();
            }
        }

        private void dgwDevLiq_Click(object sender, EventArgs e)
        {
            if (dgwDevLiq.Rows.Count > 0)
                llenaDetalleDevLiq();
        }
        private void llenaDetalleDevLiq()
        {
            dgwDevLiqDet.Rows.Clear();
            string nro_contrato = dgwDevLiq.CurrentRow.Cells["NRO_CONTRATO6"].Value.ToString();
            DataTable dtDetalle = null;
            if (dtDevLiq.Rows.Count > 0)
            {
                DataRow[] fila = dtDevLiq.Select("NRO_CONTRATO = '" + nro_contrato + "'");
                if (fila.Length > 0)
                {
                    dtDetalle = fila.CopyToDataTable();
                    if (dtDetalle.Rows.Count > 0)
                    {
                        foreach (DataRow rw in dtDetalle.Rows)
                        {
                            int rowId = dgwDevLiqDet.Rows.Add();
                            DataGridViewRow row = dgwDevLiqDet.Rows[rowId];
                            row.Cells["TIPO_VTA7"].Value = rw["TIPO_VTA"].ToString();
                            row.Cells["COD_PROGRAMA7"].Value = rw["COD_PROGRAMA"].ToString();
                            row.Cells["COD_PER_SUP7"].Value = rw["COD_COMISIONANTE"].ToString();
                            row.Cells["NOMSUP7"].Value = rw["NOMSUP"].ToString();
                            row.Cells["NRO_CONTRATO7"].Value = rw["NRO_CONTRATO"].ToString();
                            row.Cells["NRO_LETRA7"].Value = rw["NRO_LETRA"].ToString();
                            row.Cells["IMP_INI7"].Value = rw["IMP_INI"].ToString();
                            row.Cells["COD_NIVEL7"].Value = rw["COD_NIVEL"].ToString();
                            row.Cells["DESC_NIVEL7"].Value = rw["DESC_NIVEL"].ToString();
                            //row.Cells["Y"].Value = true;
                        }
                    }
                }
                else
                    dgwDevLiqDet.Rows.Clear();
            }
            else
                dgwDevLiqDet.Rows.Clear();
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
            DialogResult rs = MessageBox.Show("¿ Esta seguro de Eliminar la Devolucion Liquidada \nNro Contrato " +
                dgwDevLiqDet.CurrentRow.Cells["NRO_CONTRATO7"].Value.ToString() +
                " Letra " + dgwDevLiqDet.CurrentRow.Cells["NRO_LETRA7"].Value.ToString() +
                " Nivel " + dgwDevLiqDet.CurrentRow.Cells["DESC_NIVEL7"].Value.ToString() + " ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                pldTo.TIPO_VTA = dgwDevLiqDet.CurrentRow.Cells["TIPO_VTA7"].Value.ToString();
                pldTo.COD_PROGRAMA = dgwDevLiqDet.CurrentRow.Cells["COD_PROGRAMA7"].Value.ToString();
                pldTo.COD_COMISIONANTE = dgwDevLiqDet.CurrentRow.Cells["COD_PER_SUP7"].Value.ToString();
                pldTo.NRO_CONTRATO = dgwDevLiqDet.CurrentRow.Cells["NRO_CONTRATO7"].Value.ToString();
                pldTo.NRO_LETRA = dgwDevLiqDet.CurrentRow.Cells["NRO_LETRA7"].Value.ToString();
                pldTo.COD_NIVEL = dgwDevLiqDet.CurrentRow.Cells["COD_NIVEL7"].Value.ToString();
                pldTo.COD_VENDEDOR = dgwDevLiq.CurrentRow.Cells["COD_VENDEDOR6"].Value.ToString();
                pldTo.IMPORTE = 0;
                pldTo.COD_CREA = COD_USU;
                pldTo.FECHA_CREA = DateTime.Now;
                if (!pldBLL.eliminaDevolucionesLiquidadasBLL(pldTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Las Devoluciones Liquidadas se eliminaron correctamente !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //ELIMINAR_FILA_DGWDEVOLUCIONES_LIQUIDADAS();
                    //LLENA_GRID_DEVOLUCIONES_PENDIENTES_X_GENERAR();
                    LLENA_GRID_LIQUIDACIONES_GENERADAS();
                }
            }
        }

        private void btn_consulta1_Click(object sender, EventArgs e)
        {
            if (dgwDevPenLiq.Rows.Count > 0)
            {
                string nro_contrato = dgwDevPenLiq.CurrentRow.Cells["NRO_CONTRATO4"].Value.ToString();
                CONSULTA_KARDEX_X_CONTRATO frm = new CONSULTA_KARDEX_X_CONTRATO(nro_contrato);
                frm.ShowDialog();
            }
        }

        private void dgwDevPenLiqDet_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataRow rw in dtDevPenLiq.Rows)
            {
                if (dgwDevPenLiqDet.Rows[e.RowIndex].Cells["TIPO_VTA5"].Value.ToString() == rw["TIPO_VTA"].ToString() && dgwDevPenLiqDet.Rows[e.RowIndex].Cells["COD_PROGRAMA5"].Value.ToString() == rw["COD_PROGRAMA"].ToString() &&
                        dgwDevPenLiqDet.Rows[e.RowIndex].Cells["NRO_CONTRATO5"].Value.ToString() == rw["NRO_CONTRATO"].ToString() && dgwDevPenLiqDet.Rows[e.RowIndex].Cells["COD_PER_SUP5"].Value.ToString() == rw["COD_PER_SUP"].ToString() &&
                        dgwDevPenLiqDet.Rows[e.RowIndex].Cells["NRO_LETRA5"].Value.ToString() == rw["NRO_LETRA"].ToString() && dgwDevPenLiqDet.Rows[e.RowIndex].Cells["COD_NIVEL5"].Value.ToString() == rw["COD_NIVEL"].ToString())
                {
                    rw["IMP_INI"] = dgwDevPenLiqDet.Rows[e.RowIndex].Cells["IMP_INI5"].Value;
                    break;
                }
            }
        }
    }
}
