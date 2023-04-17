using BLL;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;

namespace Presentacion.MOD_CXC
{
    public partial class CONSULTA_PLANILLA_DESCUENTO_X_NRO_PLANILLA : Form
    {
        planillaCabeceraBLL plcBLL = new planillaCabeceraBLL();
        planillaCabeceraTo plcTo = new planillaCabeceraTo();
        string NRO_PLANILLA; string TIPO_PLANILLA;
        public CONSULTA_PLANILLA_DESCUENTO_X_NRO_PLANILLA(string NRO_PLANILLA, string TIPO_PLANILLA)
        {
            InitializeComponent();
            this.NRO_PLANILLA = NRO_PLANILLA;
            this.TIPO_PLANILLA = TIPO_PLANILLA;
        }

        private void CONSULTA_PLANILLA_DESCUENTO_X_NRO_PLANILLA_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            LIMPIAR_CABECERA();
            DGW_DET.Rows.Clear();
            plcTo.NRO_PLANILLA_COB = NRO_PLANILLA;
            plcTo.TIPO_PLANILLA = TIPO_PLANILLA;
            DataTable dtPlanilla = plcBLL.obtenerPlanillaDescuentoCabeceraxNroPllaBLL(plcTo);
            if (dtPlanilla.Rows.Count > 0)
            {
                CARGAR_CABECERA(dtPlanilla);
            }
        }
        private void CARGAR_CABECERA(DataTable dt)
        {
            foreach (DataRow rw in dt.Rows)
            {
                lbl_sucursal.Text = rw["DESC_SUCURSAL"].ToString();
                lbl_institucion.Text = rw["DESC_INST"].ToString();
                lbl_pto_cobranza.Text = rw["DESC_PTO_COB"].ToString();
                lbl_sectorista.Text = rw["DESC_EQVTA"].ToString();
                lbl_nro_planilla.Text = NRO_PLANILLA;
                lbl_cod_tipo_plla.Text = TIPO_PLANILLA;
                lbl_pto_cob_consolidado.Text = rw["DESC_PTO_COB"].ToString();
                lbl_canal_dscto.Text = rw["DESCRIPCION"].ToString();
                lbl_observacion.Text = rw["OBSERVACION"].ToString();
                lbl_fec_recepcion.Text = rw["FECHA_RECEPCION"].ToString().Substring(0, 10);
                lbl_tipo_cobranza.Text = rw["DESC_TIPO"].ToString();
                lbl_cobrador.Text = rw["DESC_EQVTA"].ToString();
            }
        }
        private void LIMPIAR_CABECERA()
        {
            lbl_sucursal.Text = "";
            lbl_institucion.Text = "";
            lbl_pto_cobranza.Text = "";
            lbl_sectorista.Text = "";
            lbl_cod_tipo_plla.Text = "";
            lbl_pto_cob_consolidado.Text = "";
            lbl_canal_dscto.Text = "";
            lbl_observacion.Text = "";
            lbl_fec_recepcion.Text = "";
            lbl_tipo_cobranza.Text = "";
            lbl_cobrador.Text = "";
        }
    }
}
