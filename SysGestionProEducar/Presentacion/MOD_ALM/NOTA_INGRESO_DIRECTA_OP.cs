using System;
using System.Windows.Forms;

namespace Presentacion.MOD_ALM
{
    public partial class NOTA_INGRESO_DIRECTA_OP : Form
    {
        string boton;
        public NOTA_INGRESO_DIRECTA_OP()
        {
            InitializeComponent();
        }

        private void NOTA_INGRESO_DIRECTA_OP_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            dgw1.Rows.Add("SUCURSAL 1", "MERCADERIAS", "15451", "SUAREZ GALVEZ MARTIN", DateTime.Now.Date, "000154", "S", false);
        }

        private void NOTA_INGRESO_DIRECTA_OP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            boton = "MODIFICAR";
            btn_Imprimir.Enabled = false;
            TabControl1.SelectedTab = (TabPage2);
            LIMPIAR_CABECERA();
            btn_grabar2.Visible = true;
            btn_grabar2.Enabled = true;
            gb_oc.Enabled = false;
            GB2.Enabled = false;
            DGW_DET.Enabled = true;
            CARGAR_DATOS();

            //'AGREGADO POR CAMBIO DE IGV

            CARGAR_DETALLES_DGW();
            Panel1.Visible = true;
            Panel2.Visible = false;
            Panel0.Enabled = true;
            cbo_ni.Visible = false;
            TXT_NI.Visible = true;
            cbo_tipo_doc.Enabled = false;
            txt_nro_doc.Enabled = false;
            dtp_doc.Enabled = false;
            CBO_MONEDA.Enabled = false;
            TXT_TC.Enabled = false;
            CH_PV.Enabled = false;
            //HALLAR_TOTAL_OC()
            cbo_sucursal.Focus();
        }
        private void LIMPIAR_CABECERA()
        {
            TXT_COD.Clear();
            TXT_DESC.Clear();
            txt_doc_per.Clear();
            txt_obs.Clear();
            txt_nro_doc.Clear();
            DGW_DET.Rows.Clear();
            gb_oc.Enabled = true;
            GB2.Enabled = true;
            TXT_TB.Text = "0.00";
            TXT_TD.Text = "0.00";
            TXT_TN.Text = "0.00";
            TXT_TT.Text = "0.00";
            TXT_TIGV.Text = "0.00";
            btn_mod.Enabled = true;
            //COD_MONEDA = obj.DIR_TABLA_DESC("MONCXP", "TDEFA")
            //CBO_MONEDA.Text = obj.desc_MONEDA(COD_MONEDA)
        }

        private void CARGAR_DATOS()
        {
            cbo_sucursal.SelectedIndex = 0;
            TXT_NI.Text = "001";
            txt_numero.Text = "002512";
            cbo_mov.SelectedIndex = 0;
            cbo_clase.SelectedIndex = 0;
            TXT_COD.Text = "005";
            TXT_DESC.Text = "SUAREZ GALVEZ MARTIN";
            txt_doc_per.Text = "21025126";
            cbo_tipo_doc.SelectedIndex = 0;
            txt_nro_doc.Text = "15452";
            CBO_MONEDA.SelectedIndex = 0;

        }
        private void CARGAR_DETALLES_DGW()
        {
            DGW_DET.Rows.Add("01", "002", "DESCRIPCION 1", "15", "20", "300", "18", "", "", "", "");
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            TabControl1.SelectedTab = (TabPage1);
            btn_modificar.Focus();
        }

        private void btn_grabar2_Click(object sender, EventArgs e)
        {
            dgw1.Rows.Add(cbo_sucursal.SelectedItem.ToString(), cbo_clase.SelectedItem.ToString(), "001-" + txt_numero.Text, TXT_DESC.Text, dtp_inv.Value.ToShortDateString(), txt_nro_doc.Text, "S", false);

            Panel1.Visible = true;
            Panel2.Visible = false;
            Panel0.Enabled = false;
            //btn_grabar2.Enabled = false;
            //btn_Imprimir.Enabled = true;
            TabControl1.SelectedTab = (TabPage1);
            btn_modificar.Focus();

        }
    }
}
