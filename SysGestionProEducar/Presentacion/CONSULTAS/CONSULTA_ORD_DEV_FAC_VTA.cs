using BLL;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;

namespace Presentacion.CONSULTAS
{
    public partial class CONSULTA_ORD_DEV_FAC_VTA : Form
    {
        public string COD_CLASE;
        public string COD_DOC;
        public string COD_PER;
        public string COD_SUCURSAL;
        public string tipo_ori;

        public CONSULTA_ORD_DEV_FAC_VTA()
        {
            InitializeComponent();
        }

        private void BTN_CANCELAR_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Hide();
        }
        public void CARGAR_CONTRATO(string FE_AÑO, string FE_MES)
        {
            DGW_CAB.Rows.Clear();
            DGW_DET.Rows.Clear();
            CONSULTA_ORD_DEV_FAC_VTA ofrm = new CONSULTA_ORD_DEV_FAC_VTA();
            ofrm.Text = "Contratos";
            tipo_ori = "C";
            contratoCabeceraBLL ccBLL = new contratoCabeceraBLL();
            contratoCabeceraTo ccTo = new contratoCabeceraTo();
            ccTo.COD_SUCURSAL = COD_SUCURSAL;
            ccTo.COD_CLASE = COD_CLASE;
            ccTo.COD_PER = COD_PER;
            //DGW_CAB.Rows.Clear();
            DataTable dt = ccBLL.obtenerFacturacionCabeceraparaConsultaOrdDevFactporContratoBLL(ccTo);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow rw in dt.Rows)
                {
                    int rowId = DGW_CAB.Rows.Add();
                    DataGridViewRow row = DGW_CAB.Rows[rowId];
                    row.Cells[0].Value = rw["NRO_PRESUPUESTO"].ToString();
                    row.Cells[1].Value = string.Format("{0:dd/MM/yyyy}", rw["FECHA_PRE"]); ;// rw["FECHA_DOC"].ToString().Substring(0, 10);
                    row.Cells[2].Value = string.Format(rw["TOTAL_CONTRATO"].ToString(), "###,###,##0.00");
                    row.Cells[3].Value = rw["COD_MONEDA"].ToString();
                    row.Cells[4].Value = rw["TIPO_CAMBIO"].ToString();
                    row.Cells[5].Value = rw["OBSERVACION"].ToString();
                    row.Cells[6].Value = rw["FE_AÑO"].ToString();
                    row.Cells[7].Value = rw["FE_MES"].ToString();
                    //row.Cells[8].Value = rw["COD_DOC"].ToString();
                    row.Cells[9].Value = rw["NRO_DOC_VTA"].ToString();

                    row.Cells[10].Value = rw["NRO_PRESUPUESTO"].ToString();
                    row.Cells[11].Value = rw["FECHA_PRE"].ToString();
                    row.Cells[12].Value = rw["COD_MONEDA"].ToString();
                    row.Cells[13].Value = rw["TIPO_CAMBIO"].ToString();
                    row.Cells[14].Value = rw["FORMA_PAGO"].ToString();
                    row.Cells[15].Value = rw["STATUS_PV"].ToString();
                    row.Cells[16].Value = rw["NRO_DIAS"].ToString();
                    row.Cells[17].Value = rw["COD_PER_ELAB"].ToString();
                    row.Cells[18].Value = rw["COD_PER_APROB"].ToString();
                    row.Cells[19].Value = rw["STATUS_ANUL"].ToString();
                    row.Cells[20].Value = rw["STATUS_CIERRE"].ToString();
                    row.Cells[21].Value = rw["COD_VENDEDOR"].ToString();
                    row.Cells[22].Value = rw["CONDICION_VENTA"].ToString();
                    row.Cells[23].Value = rw["COD_CONTACTO"].ToString();
                    row.Cells[24].Value = rw["FECHA_APROB"].ToString();
                    row.Cells[25].Value = rw["TIPO_PRECIO"].ToString();
                    row.Cells[26].Value = rw["OBSERVACION"].ToString();
                    row.Cells[27].Value = rw["COD_MOV"].ToString();
                    row.Cells[28].Value = rw["NRO_REPORTE"].ToString();
                    row.Cells[29].Value = rw["FEC_REPORTE"].ToString();
                    row.Cells[30].Value = rw["COD_PROGRAMA"].ToString();
                    row.Cells[31].Value = rw["PERIODO"].ToString();
                    row.Cells[32].Value = rw["NRO_SEMANA"].ToString();
                    row.Cells[33].Value = rw["TIPO_PLANILLA"].ToString();
                    row.Cells[34].Value = rw["COD_ALMACEN"].ToString();
                    row.Cells[35].Value = rw["COD_NIVEL1"].ToString();
                    row.Cells[36].Value = rw["COD_NIVEL2"].ToString();
                    row.Cells[37].Value = rw["COD_NIVEL3"].ToString();
                    row.Cells[38].Value = rw["SUELDO_NETO"].ToString();
                    row.Cells[39].Value = rw["PRESTAMOS"].ToString();
                    row.Cells[40].Value = rw["OTROS_DSCTOS"].ToString();

                    row.Cells[41].Value = rw["JUDICIALES"].ToString();
                    row.Cells[42].Value = rw["NETO_COBRAR"].ToString();
                    row.Cells[43].Value = rw["NRO_CUOTAS"].ToString();
                    row.Cells[44].Value = rw["IMP_COUTA_MES"].ToString();
                    row.Cells[45].Value = rw["FEC_PRIMER_VENC"].ToString();
                    row.Cells[46].Value = rw["NRO_DIAS_VENC"].ToString();
                    row.Cells[47].Value = rw["FEC_CUO_MEN"].ToString();
                    row.Cells[48].Value = rw["STATUS_FAC"].ToString();
                    row.Cells[49].Value = rw["TIPO_PEDIDO"].ToString();
                    row.Cells[50].Value = rw["STATUS_GUIA"].ToString();
                    row.Cells[51].Value = rw["COD_REF"].ToString();
                    row.Cells[52].Value = rw["NRO_REF"].ToString();

                    row.Cells[53].Value = rw["STATUS_CTA"].ToString();
                    row.Cells[54].Value = rw["COD_SUB_PTO_VEN"].ToString();
                    row.Cells[55].Value = rw["COD_CANAL_DSCTO"].ToString();
                    row.Cells[56].Value = rw["COD_PTO_COB"].ToString();
                    row.Cells[57].Value = rw["COD_TIPO_VENTA"].ToString();
                    row.Cells[58].Value = rw["COD_MODALIDAD_VTA"].ToString();
                    row.Cells[59].Value = rw["STATUS_APROB"].ToString();
                    row.Cells[60].Value = rw["IMP_CUOTA_INICIAL"].ToString();
                    row.Cells["COD_KIT"].Value = rw["COD_KIT"].ToString();
                }
            }

        }
        public void CARGAR_FACTURACION(string FE_AÑO, string FE_MES)
        {
            DGW_CAB.Rows.Clear();
            DGW_DET.Rows.Clear();
            CONSULTA_ORD_DEV_FAC_VTA ofrm = new CONSULTA_ORD_DEV_FAC_VTA();
            ofrm.Text = "Facturaciones";
            tipo_ori = "F";
            facturacionVtaCabeceraBLL fvtaBLL = new facturacionVtaCabeceraBLL();
            facturacionVtaCabeceraTo fvtaTo = new facturacionVtaCabeceraTo();
            fvtaTo.COD_SUCURSAL = COD_SUCURSAL;
            fvtaTo.COD_CLASE = COD_CLASE;
            fvtaTo.COD_DOC = COD_DOC;
            fvtaTo.COD_PER = COD_PER;
            //DGW_CAB.Rows.Clear();
            DataTable dt = fvtaBLL.obtenerFacturacionCabeceraparaConsultaOrdDevFactBLL(fvtaTo);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow rw in dt.Rows)
                {
                    int rowId = DGW_CAB.Rows.Add();
                    DataGridViewRow row = DGW_CAB.Rows[rowId];
                    row.Cells[0].Value = rw["NRO_DOC"].ToString();
                    row.Cells[1].Value = string.Format("{0:dd/MM/yyyy}", rw["FECHA_DOC"]); ;// rw["FECHA_DOC"].ToString().Substring(0, 10);
                    row.Cells[2].Value = string.Format(rw["TOTAL_CONTRATO"].ToString(), "###,###,##0.00");
                    row.Cells[3].Value = rw["COD_MONEDA"].ToString();
                    row.Cells[4].Value = rw["TIPO_CAMBIO"].ToString();
                    row.Cells[5].Value = rw["OBSERVACION"].ToString();
                    row.Cells[6].Value = rw["FE_AÑO"].ToString();
                    row.Cells[7].Value = rw["FE_MES"].ToString();
                    row.Cells[8].Value = rw["COD_DOC"].ToString();
                    row.Cells[9].Value = rw["NRO_DOC_VTA"].ToString();

                    row.Cells[10].Value = rw["NRO_PRESUPUESTO"].ToString();
                    row.Cells[11].Value = rw["FECHA_PRE"].ToString();
                    row.Cells[12].Value = rw["COD_MONEDA"].ToString();
                    row.Cells[13].Value = rw["TIPO_CAMBIO"].ToString();
                    row.Cells[14].Value = rw["FORMA_PAGO"].ToString();
                    row.Cells[15].Value = rw["STATUS_PV"].ToString();
                    row.Cells[16].Value = rw["NRO_DIAS"].ToString();
                    row.Cells[17].Value = rw["COD_PER_ELAB"].ToString();
                    row.Cells[18].Value = rw["COD_PER_APROB"].ToString();
                    row.Cells[19].Value = rw["STATUS_ANUL"].ToString();
                    row.Cells[20].Value = rw["STATUS_CIERRE"].ToString();
                    row.Cells[21].Value = rw["COD_VENDEDOR"].ToString();
                    row.Cells[22].Value = rw["CONDICION_VENTA"].ToString();
                    row.Cells[23].Value = rw["COD_CONTACTO"].ToString();
                    row.Cells[24].Value = rw["FECHA_APROB"].ToString();
                    row.Cells[25].Value = rw["TIPO_PRECIO"].ToString();
                    row.Cells[26].Value = rw["OBSERVACION"].ToString();
                    row.Cells[27].Value = rw["COD_MOV"].ToString();
                    row.Cells[28].Value = rw["NRO_REPORTE"].ToString();
                    row.Cells[29].Value = rw["FEC_REPORTE"].ToString();
                    row.Cells[30].Value = rw["COD_PROGRAMA"].ToString();
                    row.Cells[31].Value = rw["PERIODO"].ToString();
                    row.Cells[32].Value = rw["NRO_SEMANA"].ToString();
                    row.Cells[33].Value = rw["TIPO_PLANILLA"].ToString();
                    row.Cells[34].Value = rw["COD_ALMACEN"].ToString();
                    row.Cells[35].Value = rw["COD_NIVEL1"].ToString();
                    row.Cells[36].Value = rw["COD_NIVEL2"].ToString();
                    row.Cells[37].Value = rw["COD_NIVEL3"].ToString();
                    row.Cells[38].Value = rw["SUELDO_NETO"].ToString();
                    row.Cells[39].Value = rw["PRESTAMOS"].ToString();
                    row.Cells[40].Value = rw["OTROS_DSCTOS"].ToString();

                    row.Cells[41].Value = rw["JUDICIALES"].ToString();
                    row.Cells[42].Value = rw["NETO_COBRAR"].ToString();
                    row.Cells[43].Value = rw["NRO_CUOTAS"].ToString();
                    row.Cells[44].Value = rw["IMP_COUTA_MES"].ToString();
                    row.Cells[45].Value = rw["FEC_PRIMER_VENC"].ToString();
                    row.Cells[46].Value = rw["NRO_DIAS_VENC"].ToString();
                    row.Cells[47].Value = rw["FEC_CUO_MEN"].ToString();
                    row.Cells[48].Value = rw["STATUS_FAC"].ToString();
                    row.Cells[49].Value = rw["TIPO_PEDIDO"].ToString();
                    row.Cells[50].Value = rw["STATUS_GUIA"].ToString();
                    row.Cells[51].Value = rw["COD_REF"].ToString();
                    row.Cells[52].Value = rw["NRO_REF"].ToString();

                    row.Cells[53].Value = rw["STATUS_CTA"].ToString();
                    row.Cells[54].Value = rw["COD_SUB_PTO_VEN"].ToString();
                    row.Cells[55].Value = rw["COD_CANAL_DSCTO"].ToString();
                    row.Cells[56].Value = rw["COD_PTO_COB"].ToString();
                    row.Cells[57].Value = rw["COD_TIPO_VENTA"].ToString();
                    row.Cells[58].Value = rw["COD_MODALIDAD_VTA"].ToString();
                    row.Cells[59].Value = rw["STATUS_APROB"].ToString();
                    row.Cells[60].Value = rw["IMP_CUOTA_INICIAL"].ToString();
                    row.Cells[62].Value = rw["ST_TIP_VTA"].ToString();
                    row.Cells["COD_KIT"].Value = rw["COD_KIT"].ToString();
                }
            }
        }
        private void DGW_CAB_SelectionChanged(object sender, EventArgs e)
        {
            //string nro_pedido = DGW_CAB.CurrentRow.Cells["NRO_PEDIDO"].Value.ToString();
            //CARGAR_DETALLES_FACT(nro_pedido);
        }
        private void DGW_CAB_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (DGW_CAB.Rows.Count > 0 && DGW_CAB.CurrentRow.Cells["NRO_DOC_VTA"].Value != null)
            {
                string nro_pedido;
                if (tipo_ori == "F")
                {
                    nro_pedido = DGW_CAB.CurrentRow.Cells[0].Value.ToString();
                    CARGAR_DETALLES_FACT(nro_pedido);
                }
                else if (tipo_ori == "C")
                {
                    nro_pedido = DGW_CAB.CurrentRow.Cells[0].Value.ToString();
                    CARGAR_DETALLES_CONTRATO(nro_pedido);
                }

            }

        }
        private void CARGAR_DETALLES_FACT(string nro_pedido)
        {
            contratoDetalleBLL condBLL = new contratoDetalleBLL();
            contratoDetalleTo condTo = new contratoDetalleTo();
            condTo.NRO_DOC = nro_pedido;
            DataTable dt = condBLL.obtenerContratoDetalleporConsultaOrdDevFacVtaBLL(condTo);
            if (dt.Rows.Count > 0)
            {
                DGW_DET.Rows.Clear();
                foreach (DataRow rw in dt.Rows)
                {
                    int rowId = DGW_DET.Rows.Add();
                    DataGridViewRow row = DGW_DET.Rows[rowId];
                    row.Cells[0].Value = rw["ITEM"].ToString();
                    row.Cells[1].Value = rw["COD_ARTICULO"].ToString();
                    row.Cells[2].Value = rw["DESC_ARTICULO"].ToString();
                    row.Cells[3].Value = rw["CANTIDAD"].ToString();
                    row.Cells[4].Value = rw["PRECIO_UNITARIO"].ToString();
                    row.Cells[5].Value = rw["VALOR_COMPRA"].ToString();
                    row.Cells[6].Value = rw["POR_IGV"].ToString();
                    row.Cells[7].Value = rw["POR_DSCTO"].ToString();
                    row.Cells[8].Value = rw["VALOR_IGV"].ToString();
                    row.Cells[9].Value = rw["VALOR_DSCTO"].ToString();
                    row.Cells["ST_VALOR_REFERENCIAL"].Value = rw["ST_TIP_VTA"].ToString() == "PU" ? "0" : "1";
                }
            }
        }
        private void CARGAR_DETALLES_CONTRATO(string nro_pedido)
        {
            DGW_DET.Rows.Clear();
            contratoDetalleBLL condBLL = new contratoDetalleBLL();
            contratoDetalleTo condTo = new contratoDetalleTo();
            condTo.NRO_PRESUPUESTO = nro_pedido;
            DataTable dt = condBLL.obtenerContratoDetalleporConsultaOrdDevFacVtaporContratoBLL(condTo);
            if (dt.Rows.Count > 0)
            {
                //DGW_DET.Rows.Clear();
                foreach (DataRow rw in dt.Rows)
                {
                    int rowId = DGW_DET.Rows.Add();
                    DataGridViewRow row = DGW_DET.Rows[rowId];
                    row.Cells[0].Value = rw["ITEM"].ToString();
                    row.Cells[1].Value = rw["COD_ARTICULO"].ToString();
                    row.Cells[2].Value = rw["DESC_ARTICULO"].ToString();
                    row.Cells[3].Value = rw["CANTIDAD_PED"].ToString();
                    row.Cells[4].Value = rw["PRECIO_UNIT"].ToString();
                    row.Cells[5].Value = rw["VALOR_COMPRA"].ToString();
                    row.Cells[6].Value = rw["POR_IGV"].ToString();
                    row.Cells[7].Value = rw["POR_DSCTO"].ToString();
                    row.Cells[8].Value = rw["VALOR_IGV"].ToString();
                    row.Cells[9].Value = rw["VALOR_DSCTO"].ToString();
                    row.Cells["ST_VALOR_REFERENCIAL"].Value = rw["ST_VALOR_REFERENCIAL"].ToString();
                }
            }

        }

    }
}
