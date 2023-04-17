using BLL;
using Entidades;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Presentacion.MOD_CXC
{
    public partial class I_LLAMADAS_R_PLANILLA : Form
    {
        string AÑO = "", MES = "", COD_MOD = "", COD_USU = "", TIPO_USU = "", AÑO1 = "", MES1 = "";
        DateTime FECHA_INI, FECHA_GRAL;
        DataTable dtPendientes, dtGenerados, dtPtoCob;
        string cod_pto_cob, cod_canal_dscto, cod_institucion, cod_sucursal, serie, numero;
        decimal tipo_cambio = 0;
        descuentoDirectaSeguimientoBLL dsBLL = new descuentoDirectaSeguimientoBLL();
        descuentoDirectaSeguimientoTo dsTo = new descuentoDirectaSeguimientoTo();
        planillaCabeceraBLL plcBLL = new planillaCabeceraBLL();
        planillaCabeceraTo plcTo = new planillaCabeceraTo();
        serieDocumentoBLL sdoBLL = new serieDocumentoBLL();
        serieDocumentosTo sdoTo = new serieDocumentosTo();
        public I_LLAMADAS_R_PLANILLA(string AÑO, string MES, DateTime FECHA_INI, DateTime FECHA_GRAL, string COD_MOD, string TIPO_USU, string COD_USU)
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

        private void I_LLAMADAS_R_PLANILLA_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            CARGAR_MES_MOROSIDAD_DEFAULT();
            //CARGAR_CANAL_DESCUENTO();
            //CARGAR_SUCURSAL();
            CARGAR_DATOS_PUNTO_COBRANZA_DEFAULT();
            LLENA_GRID_PLANILLA_DESCUENTO_GENERADAS();
            LLENA_GRID_PLANILLA_DESCUENTO_PENDIENTES();
        }
        private void CARGAR_MES_MOROSIDAD_DEFAULT()
        {
            string mes = HelpersBLL.OBTENER_DES_DIRECTORIO(null, "TMORM");
            txt_mes_mor.Text = mes;
        }
        private void CARGAR_DATOS_PUNTO_COBRANZA_DEFAULT()
        {
            puntoCobranzaBLL ptBLL = new puntoCobranzaBLL();
            puntoCobranzaTo ptTo = new puntoCobranzaTo();
            ptTo.COD_PTO_COB = "000";
            dtPtoCob = ptBLL.obtenerPtoCobranzaxPtoCobBLL(ptTo);
            if (dtPtoCob.Rows.Count > 0)
            {
                cod_pto_cob = dtPtoCob.Rows[0]["COD_PTO_COB"].ToString();
                cod_canal_dscto = dtPtoCob.Rows[0]["COD_CANAL_DSCTO"].ToString();
                cod_institucion = dtPtoCob.Rows[0]["COD_INSTITUCION"].ToString();
                cod_sucursal = dtPtoCob.Rows[0]["COD_SUCURSAL"].ToString();
            }

        }
        //private void CARGAR_CANAL_DESCUENTO()
        //{
        //    canalDescuentoBLL cdBLL = new canalDescuentoBLL();
        //    DataTable dt = cdBLL.ObtenerCanalDescuentoBLL();
        //    if(dt.Rows.Count > 0)
        //    {
        //        cbo_canal_descuento.ValueMember = "COD_CANAL_DESCUENTO";
        //        cbo_canal_descuento.DisplayMember = "DESCRIPCION";
        //        cbo_canal_descuento.DataSource = dt;
        //        cbo_canal_descuento.SelectedIndex = 0;
        //    }
        //}
        //private void CARGAR_SUCURSAL()
        //{
        //    sucursalBLL suBLL = new sucursalBLL();
        //    DataTable dt = suBLL.obtenerSucursalBLL();
        //    if(dt.Rows.Count > 0)
        //    {
        //        cbo_sucursal.ValueMember = "Cod";
        //        cbo_sucursal.DisplayMember = "Descripción";
        //        cbo_sucursal.DataSource = dt;
        //        cbo_sucursal.SelectedIndex = 0;
        //    }
        //}
        private void LLENA_GRID_PLANILLA_DESCUENTO_PENDIENTES()
        {
            dgw_pendientes.Rows.Clear();
            dgw_generados_det.Rows.Clear();
            dsTo.MESES_MOROSIDAD = txt_mes_mor.Text;
            dtPendientes = dsBLL.obtener_llamadas_seguimiento_para_R_PlanillaBLL(dsTo);
            if (dtPendientes.Rows.Count > 0)
            {
                DataTable dt1 = dtPendientes.AsEnumerable()
                   .GroupBy(r => new
                   {
                       Col01 = r["NRO_CONTRATO"],
                       Col02 = r["FECHA_CONTRATO"],
                       Col03 = r["COD_PER"],
                       Col04 = r["DESC_PER"],
                   })
                   .Select(g => g.OrderBy(r => r["NRO_CONTRATO"]).First())
                   .CopyToDataTable();
                //
                if (dt1.Rows.Count > 0)
                {
                    foreach (DataRow rw in dt1.Rows)
                    {
                        int rowId = dgw_pendientes.Rows.Add();
                        DataGridViewRow row = dgw_pendientes.Rows[rowId];
                        row.Cells["NRO_CONTRATO1"].Value = rw["NRO_CONTRATO"].ToString();
                        row.Cells["FECHA_CONTRATO1"].Value = rw["FECHA_CONTRATO"].ToString().Substring(0, 10);
                        row.Cells["COD_PERSONA"].Value = rw["COD_PER"].ToString();
                        row.Cells["DESC_PER"].Value = rw["DESC_PER"].ToString();
                        row.Cells["IMP_DOC2"].Value = rw["IMP_DOC"].ToString();
                        row.Cells["NRO_CUOTAS"].Value = rw["NRO_CUOTAS"].ToString();
                        row.Cells["IMPORTE_PAGO"].Value = rw["IMPORTE_PAGO"].ToString();
                        row.Cells["COD_CLASE1"].Value = rw["COD_CLASE"].ToString();
                        row.Cells["NRO_DOC1"].Value = rw["NRO_DOC"].ToString();
                        row.Cells["COD_GESTOR"].Value = rw["COD_GESTOR"].ToString();
                        row.Cells["COD_SECTORISTA"].Value = rw["COD_SECTORISTA"].ToString();
                    }
                }
            }
            else
            {
                MessageBox.Show("No se encontraron registros !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }
        private void LLENA_GRID_PLANILLA_DESCUENTO_GENERADAS()
        {

        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = TabPage2;
        }

        private void dgw_pendientes_Click(object sender, EventArgs e)
        {
            if (dgw_pendientes.Rows.Count > 0)
            {
                llenaDetallePendientes();
            }
        }

        private void dgw_pendientes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgw_pendientes.Rows.Count > 0)
            {
                if (dgw_pendientes.CurrentRow.Cells["NRO_CONTRATO1"].Value != null)
                    llenaDetallePendientes();
            }
        }
        private void llenaDetallePendientes()
        {
            dgw_pendientes_det.Rows.Clear();
            string nro_contrato = dgw_pendientes.CurrentRow.Cells["NRO_CONTRATO1"].Value.ToString();//cabecera Comisiones Generadas
            DataTable dtDetalle = null;
            if (dtPendientes.Rows.Count > 0)
            {
                DataRow[] fila = dtPendientes.Select("NRO_CONTRATO = '" + nro_contrato + "'");
                if (fila.Length > 0)
                {
                    dtDetalle = fila.CopyToDataTable();
                    if (dtDetalle.Rows.Count > 0)
                    {
                        foreach (DataRow rw in dtDetalle.Rows)
                        {
                            int rowId = dgw_pendientes_det.Rows.Add();
                            DataGridViewRow row = dgw_pendientes_det.Rows[rowId];
                            row.Cells["NRO_CONTRATO"].Value = rw["NRO_CONTRATO"].ToString();
                            row.Cells["COD_PER"].Value = rw["COD_PER"].ToString();
                            row.Cells["LETRA"].Value = rw["LETRA"].ToString();
                            row.Cells["COD_DOC"].Value = "30";
                            row.Cells["COD_CLASE"].Value = rw["COD_CLASE"].ToString();
                            row.Cells["NRO_DOC"].Value = rw["NRO_DOC"].ToString();
                            row.Cells["FECHA_CONTRATO"].Value = rw["FECHA_CONTRATO"].ToString();
                            row.Cells["FECHA_RECEPCION"].Value = DateTime.Now;
                            row.Cells["FECHA_VEN"].Value = rw["FECHA_VEN"].ToString().Substring(0, 10);
                            row.Cells["COD_PTO_COB1"].Value = cod_pto_cob;//AQUI SE DEBE CAMBIAR A COD_PTO_COB
                            row.Cells["COD_COBRADOR"].Value = dgw_pendientes.CurrentRow.Cells["COD_GESTOR"].Value.ToString();
                            row.Cells["NRO_PLANILLA_COB"].Value = "";
                            row.Cells["FECHA_PLANILLA_COB"].Value = DateTime.Now;
                            row.Cells["TIPO_CAMBIO1"].Value = tipo_cambio;
                            row.Cells["IMP_COB"].Value = Convert.ToDecimal(rw["IMP_DOC"]);
                            row.Cells["OBSERVACION"].Value = "";
                            row.Cells["NRO_LETRA"].Value = rw["LETRA"].ToString().Substring(0, 3);
                            row.Cells["TOT_LETRA"].Value = rw["LETRA"].ToString().Substring(4, 3);
                            row.Cells["FE_AÑO"].Value = AÑO;
                            row.Cells["FE_MES"].Value = MES;
                        }
                    }
                }
                else
                    dgw_pendientes_det.Rows.Clear();
            }
            else
                dgw_pendientes_det.Rows.Clear();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = TabPage1;
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btn_grabar_Click(object sender, EventArgs e)
        {
            if (!valida())
                return;

            DialogResult rs = MessageBox.Show("¿ Está seguro de grabar este registro con el contrato " + dgw_pendientes.CurrentRow.Cells["NRO_CONTRATO1"].Value.ToString() + " ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                plcTo.NRO_PLANILLA_COB = obtieneNroPlanilla();
                plcTo.COD_INSTITUCION = cod_institucion;
                plcTo.COD_PTO_COB_CONSOLIDADO = cod_pto_cob;
                plcTo.COD_CANAL_DSCTO = cod_canal_dscto;
                plcTo.FE_AÑO = AÑO;
                plcTo.FE_MES = MES;
                plcTo.COD_MOD = COD_USU;
                plcTo.FECHA_MOD = DateTime.Now;
                plcTo.COD_SUCURSAL = cod_sucursal;
                plcTo.COD_CLASE = "001";
                plcTo.COD_SECTORISTA = dgw_pendientes.CurrentRow.Cells["COD_SECTORISTA"].Value.ToString();
                plcTo.FECHA_PLANILLA_COB = DateTime.Now;
                plcTo.FECHA_RECEPCION = DateTime.Now;
                plcTo.OBSERVACION = dgw_pendientes.CurrentRow.Cells["NRO_CONTRATO1"].Value.ToString();
                plcTo.TIPO_PLANILLA = "D";

                DataTable dtDetalle = HelpersBLL.obtenerDT(dgw_pendientes_det);
                decimal IMP_RECEPCION_CTA_CTE = dtDetalle.AsEnumerable().Sum(x => x.Field<decimal>("IMP_COB"));
                plcTo.IMP_RECEPCION_CTA_CTE = IMP_RECEPCION_CTA_CTE;
                decimal IMPORTE_PAGO = Convert.ToDecimal(dgw_pendientes.CurrentRow.Cells["IMPORTE_PAGO"].Value);
                plcTo.IMP_RECEPCION_DEV = IMPORTE_PAGO - IMP_RECEPCION_CTA_CTE;

            }
        }
        private string obtieneNroPlanilla()
        {
            sdoTo.COD_SUCURSAL = cod_sucursal;
            sdoTo.STATUS_DOC = "0";
            sdoTo.COD_DOC = "43";//planilla de cobranza
            //txt_nro_ini.Text = sdoBLL.obtenerNro_Ing2BLL(sdoTo);
            serie = sdoBLL.OBTENER_SERIE_NRO_BLL(sdoTo).Rows[1]["SERIE"].ToString();
            numero = sdoBLL.OBTENER_SERIE_NRO_BLL(sdoTo).Rows[1]["NUMERO"].ToString();
            return serie + "-" + numero;
        }
        private bool valida()
        {
            bool result = true;

            return result;
        }
    }
}
