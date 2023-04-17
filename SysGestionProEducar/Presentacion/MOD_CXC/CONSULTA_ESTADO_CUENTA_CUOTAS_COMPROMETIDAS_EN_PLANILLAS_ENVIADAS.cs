using BLL;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;

namespace Presentacion.MOD_CXC
{
    public partial class CONSULTA_ESTADO_CUENTA_CUOTAS_COMPROMETIDAS_EN_PLANILLAS_ENVIADAS : Form
    {
        canjeICtasxCobrarBLL ictasBLL = new canjeICtasxCobrarBLL();
        canjeICtasxCobrarTo ictasTo = new canjeICtasxCobrarTo();
        public CONSULTA_ESTADO_CUENTA_CUOTAS_COMPROMETIDAS_EN_PLANILLAS_ENVIADAS()
        {
            InitializeComponent();
        }

        private void CONSULTA_ESTADO_CUENTA_CUOTAS_COMPROMETIDAS_EN_PLANILLAS_ENVIADAS_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
        }

        private void CONSULTA_ESTADO_CUENTA_CUOTAS_COMPROMETIDAS_EN_PLANILLAS_ENVIADAS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void CONSULTA_ESTADO_CUENTA_CUOTAS_COMPROMETIDAS_EN_PLANILLAS_ENVIADAS_Shown(object sender, EventArgs e)
        {
            txt_nro_contrato.Focus();
        }
        private void buscarEstadoCuenta()
        {
            ictasTo.NRO_CONTRATO = txt_nro_contrato.Text;
            DataTable dt = ictasBLL.ConsultaEstadoCuentaKardexClienteBLL(ictasTo);
            if (dt.Rows.Count > 0)
            {
                txt_fec_contrato.Text = dt.Rows[0]["FECHA_PRE"].ToString().Substring(0, 10);
                txt_aprobado.Text = dt.Rows[0]["FECHA_PRE"].ToString() == "1" ? "SI" : "NO";
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
                lbl_estado.Text = "";
                lbl_almacen.Text = dt.Rows[0]["ALM"].ToString();
                lbl_vendedor.Text = dt.Rows[0]["VENDEDOR"].ToString();
                lbl_total.Text = dt.Rows[0]["TOTAL"].ToString();
                lbl_cancelado.Text = dt.Rows[0]["CANCELADO"].ToString();
                lbl_saldo.Text = (Convert.ToDecimal(lbl_total.Text) - Convert.ToDecimal(lbl_cancelado.Text)).ToString();

                DataTable dtDetalle = ictasBLL.ConsultaEstadoCuentaKardexClienteDetalleBLL(ictasTo);
                DGW_DET.Rows.Clear();
                if (dtDetalle.Rows.Count > 0)
                {
                    foreach (DataRow rw in dtDetalle.Rows)
                    {
                        int rowId = DGW_DET.Rows.Add();
                        DataGridViewRow row = DGW_DET.Rows[rowId];
                        row.Cells["CUOTA"].Value = rw["CUOTA"].ToString();
                        row.Cells["IMP_DOC"].Value = rw["IMP_DOC"].ToString();
                        row.Cells["FECHA_VEN"].Value = rw["FECHA_VEN"].ToString().Substring(0, 10);
                        row.Cells["FECHA_DOC"].Value = rw["FECHA_DOC"].ToString().Substring(0, 10);
                        row.Cells["NRO_PLANILLA"].Value = rw["NRO_PLANILLA"].ToString();
                        row.Cells["FECHA_PLANILLA"].Value = rw["FECHA_PLANILLA"].ToString() != "" ? rw["FECHA_PLANILLA"].ToString().Substring(0, 10) : "";
                        //row.Cells["DESC_PTO_COB"].Value = rw["DESC_PTO_COB"].ToString();
                        row.Cells["IMP_COMPROMETIDO_PLLA"].Value = rw["IMP_COMPROMETIDO_PLLA"].ToString();
                        row.Cells["SALDO_DISP_ENV"].Value = rw["SALDO_DISP_ENV"].ToString();
                        row.Cells["NRO_PLLA_ENV"].Value = rw["NRO_PLLA_ENV"].ToString();
                        row.Cells["FE_PLLA_ENV"].Value = rw["FE_PLLA_ENV"].ToString() != "" ? rw["FE_PLLA_ENV"].ToString().Substring(0, 10) : "";
                    }
                }
            }
            else
                MessageBox.Show("No existen registros con ese Nro de Contrato !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void txt_nro_contrato_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_nro_contrato.Text = txt_nro_contrato.Text.PadLeft(7, '0');
                buscarEstadoCuenta();
            }
        }

        private void txt_nro_contrato_Leave(object sender, EventArgs e)
        {
            txt_nro_contrato.Text = txt_nro_contrato.Text.PadLeft(7, '0');
        }
    }
}
