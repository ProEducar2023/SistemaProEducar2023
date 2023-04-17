using BLL;
using Entidades;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Presentacion.MOD_CXC
{
    public partial class CONSULTA_EXC_CUOTA : Form
    {
        string nro_contrato; string nro_planilla; string tipo_pla_cob;
        public CONSULTA_EXC_CUOTA(string nro_planilla, string nro_contrato)
        {
            InitializeComponent();
            this.nro_planilla = nro_planilla;
            this.nro_contrato = nro_contrato;
        }
        public CONSULTA_EXC_CUOTA(string nro_planilla, string nro_contrato, string tipo_pla_cob)
        {
            InitializeComponent();
            this.nro_planilla = nro_planilla;
            this.nro_contrato = nro_contrato;
            this.tipo_pla_cob = tipo_pla_cob;
        }

        private void CONSULTA_EXC_CUOTA_Load(object sender, EventArgs e)
        {
            DataTable dt = null;
            devTCtasCobrarBLL dtcBLL = new devTCtasCobrarBLL();
            devTCtasCobrarTo dtcTo = new devTCtasCobrarTo();
            dtcTo.NRO_PLANILLA = nro_planilla;
            dtcTo.NRO_CONTRATO = nro_contrato;
            dtcTo.TIPO_PLA_COBRANZA = tipo_pla_cob;
            if (nro_planilla != "")
            {
                dt = dtcBLL.obtenerDevTCtasCobrar_plla_cont_BLL(dtcTo);
                lbl_imp.Text = "Importe de Exceso Cuota";
            }
            else if (tipo_pla_cob != "")
            {
                dt = dtcBLL.obtenerDevTCtasCobrar_tipo_cont_BLL(dtcTo);
                lbl_imp.Text = "Descontado en Periodos Suspendidos";
            }

            if (dt.Rows.Count > 0)
            {
                DataTable dtQ = dt.AsEnumerable().Where(x => x.Field<string>("COD_D_H") == "D").CopyToDataTable();
                lbl_importe.Text = Convert.ToDecimal(dtQ.Rows[0]["IMP_DOC"]).ToString("###,###,##0.00");
                int cant = dt.AsEnumerable().Where(x => x.Field<string>("COD_D_H") != "D").Count();
                if (cant > 0)
                {
                    DataTable dtQuery = dt.AsEnumerable().Where(x => x.Field<string>("COD_D_H") != "D").CopyToDataTable();
                    foreach (DataRow rw in dtQuery.Rows)
                    {
                        int rowId = DGW_DEV_EXC_CUOTA.Rows.Add();
                        DataGridViewRow row = DGW_DEV_EXC_CUOTA.Rows[rowId];
                        row.Cells["NRO_PLLA"].Value = rw["NRO_PLANILLA"].ToString();
                        row.Cells["FECHA_PLLA"].Value = rw["FECHA_PLANILLA"].ToString().Substring(0, 10);
                        row.Cells["TIPO_PLA_COBRANZA"].Value = rw["TIPO_PLA_COBRANZA"].ToString() + " - " + rw["DESC_TIPO"].ToString();
                        row.Cells["IMP_DOC"].Value = Convert.ToDecimal(rw["IMP_DOC"]).ToString("###,###,##0.00");
                        row.Cells["NRO_DOCUMENTO_PAGO"].Value = rw["NRO_DOCUMENTO_PAGO"].ToString();
                        row.Cells["FECHA_PAGO"].Value = rw["FECHA_PAGO"].ToString() != "" ? rw["FECHA_PAGO"].ToString().Substring(0, 10) : "";
                    }
                }
            }
        }
    }
}
