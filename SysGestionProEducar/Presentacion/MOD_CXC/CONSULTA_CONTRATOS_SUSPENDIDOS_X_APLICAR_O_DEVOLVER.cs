using BLL;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;

namespace Presentacion.MOD_CXC
{
    public partial class CONSULTA_CONTRATOS_SUSPENDIDOS_X_APLICAR_O_DEVOLVER : Form
    {
        string nro_contrato;
        DataTable dtCabecera, dtDetalleC = null;
        public CONSULTA_CONTRATOS_SUSPENDIDOS_X_APLICAR_O_DEVOLVER(string nro_contrato)
        {
            InitializeComponent();
            this.nro_contrato = nro_contrato;
        }

        private void CONSULTA_CONTRATOS_SUSPENDIDOS_X_APLICAR_O_DEVOLVER_Load(object sender, EventArgs e)
        {
            devTCtasCobrarBLL dtcBLL = new devTCtasCobrarBLL();
            devTCtasCobrarTo dtcTo = new devTCtasCobrarTo();
            //dtcTo.NRO_PLANILLA = nro_planilla;
            dtcTo.NRO_CONTRATO = nro_contrato;
            //dtcTo.TIPO_PLA_COBRANZA = tipo_pla_cob;
            dtCabecera = dtcBLL.obtenerContratoSuspendidoxApliDevBLL(dtcTo);
            if (dtCabecera.Rows.Count > 0)
            {
                foreach (DataRow rw in dtCabecera.Rows)
                {
                    int rowId = DGW_DEV_EXC_CUOTA.Rows.Add();
                    DataGridViewRow row = DGW_DEV_EXC_CUOTA.Rows[rowId];
                    row.Cells["NRO_PLANILLA_COB"].Value = rw["NRO_PLANILLA_COB"].ToString();
                    row.Cells["FECHA_DOC"].Value = rw["FECHA_DOC"].ToString().Substring(0, 10);
                    row.Cells["IMP_INI"].Value = rw["IMP_INI"].ToString();
                }
            }
            dtDetalleC = dtcBLL.obtenerContratoSuspendidoxApliDevDetalleBLL(dtcTo);
            ////lbl_imp.Text = "Descontado en Periodos Suspendidos";
            //if (dtDetalle.Rows.Count > 0)
            //{
            //    DataTable dtQ = dtDetalle.AsEnumerable().Where(x => x.Field<string>("COD_D_H") == "D").CopyToDataTable();
            //    //lbl_importe.Text = Convert.ToDecimal(dtQ.Rows[0]["IMP_DOC"]).ToString("###,###,##0.00");
            //    int cant = dtDetalle.AsEnumerable().Where(x => x.Field<string>("COD_D_H") != "D").Count();
            //    if (cant > 0)
            //    {
            //        DataTable dtQuery = dtDetalle.AsEnumerable().Where(x => x.Field<string>("COD_D_H") != "D").CopyToDataTable();
            //        foreach (DataRow rw in dtQuery.Rows)
            //        {
            //            int rowId = DGW_DEV_EXC_CUOTA_DETALLE.Rows.Add();
            //            DataGridViewRow row = DGW_DEV_EXC_CUOTA_DETALLE.Rows[rowId];
            //            row.Cells["NRO_PLLA"].Value = rw["NRO_PLANILLA"].ToString();
            //            row.Cells["FECHA_PLLA"].Value = rw["FECHA_PLANILLA"].ToString().Substring(0, 10);
            //            row.Cells["TIPO_PLA_COBRANZA"].Value = rw["TIPO_PLA_COBRANZA"].ToString() + " - " + rw["DESC_TIPO"].ToString();
            //            row.Cells["IMP_DOC"].Value = Convert.ToDecimal(rw["IMP_DOC"]).ToString("###,###,##0.00");
            //            row.Cells["NRO_DOCUMENTO_PAGO"].Value = rw["NRO_DOCUMENTO_PAGO"].ToString();
            //            row.Cells["FECHA_PAGO"].Value = rw["FECHA_PAGO"].ToString() != "" ? rw["FECHA_PAGO"].ToString().Substring(0, 10) : "";
            //        }
            //    }
            //}
        }

        private void DGW_DEV_EXC_CUOTA_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DGW_DEV_EXC_CUOTA_SelectionChanged(object sender, EventArgs e)
        {
            if (DGW_DEV_EXC_CUOTA.Rows.Count > 0)
            {
                if (DGW_DEV_EXC_CUOTA.CurrentRow.Cells["NRO_PLANILLA_COB"].Value != null)
                    llenaDetalleContratosSuspendidos();
            }
        }
        private void llenaDetalleContratosSuspendidos()
        {
            DGW_DEV_EXC_CUOTA_DETALLE.Rows.Clear();
            string nro_plla_cob = DGW_DEV_EXC_CUOTA.CurrentRow.Cells["NRO_PLANILLA_COB"].Value.ToString();
            DataTable dtDetalle = null;
            if (dtCabecera.Rows.Count > 0)
            {
                DataRow[] fila = dtDetalleC.Select("NRO_PLANILLA_COB = '" + nro_plla_cob + "' AND COD_D_H = 'H'");
                if (fila.Length > 0)
                {
                    dtDetalle = fila.CopyToDataTable();
                    if (dtDetalle.Rows.Count > 0)
                    {
                        foreach (DataRow rw in dtDetalle.Rows)
                        {
                            int rowId = DGW_DEV_EXC_CUOTA_DETALLE.Rows.Add();
                            DataGridViewRow row = DGW_DEV_EXC_CUOTA_DETALLE.Rows[rowId];
                            row.Cells["NRO_PLANILLA"].Value = rw["NRO_PLANILLA"].ToString();
                            row.Cells["FECHA_PLANILLA"].Value = rw["FECHA_PLANILLA"].ToString().Substring(0, 10);
                            row.Cells["IMP_DOC"].Value = rw["IMP_DOC"].ToString();
                            row.Cells["DESC_TIPO"].Value = rw["DESC_TIPO"].ToString();
                            row.Cells["NRO_DOCUMENTO_PAGO"].Value = rw["NRO_DOCUMENTO_PAGO"].ToString();
                            row.Cells["FECHA_PAGO"].Value = rw["FECHA_PAGO"].ToString();
                        }
                    }
                }
                else
                    DGW_DEV_EXC_CUOTA_DETALLE.Rows.Clear();
            }
            else
                DGW_DEV_EXC_CUOTA_DETALLE.Rows.Clear();
        }

        private void DGW_DEV_EXC_CUOTA_Click(object sender, EventArgs e)
        {
            if (DGW_DEV_EXC_CUOTA.Rows.Count > 0)
                llenaDetalleContratosSuspendidos();
        }
    }
}
