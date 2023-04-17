using System;
using System.Windows.Forms;

namespace Presentacion.MOD_ADM
{
    public partial class PUNTO_COBRANZA_CONSOLIDADO : Form
    {
        public PUNTO_COBRANZA_CONSOLIDADO()
        {
            InitializeComponent();
        }

        private void PUNTO_COBRANZA_CONSOLIDADO_Load(object sender, EventArgs e)
        {
            KeyPreview = true;

            txtcod.Focus();
        }

        private void PUNTO_COBRANZA_CONSOLIDADO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void btn_cancelar2_Click(object sender, EventArgs e)
        {
            Panel2.Visible = false;
            Panel1.Visible = true;
            btn_salir.Visible = true;
            btn_nuevo2.Select();
        }

        private void btn_nuevo2_Click(object sender, EventArgs e)
        {
            //LIMPIAR_detalle();
            btn_guardar2.Visible = true;
            btn_modificar2.Visible = false;
            Panel1.Visible = false;
            Panel2.Visible = true;
            cbo_subgrupo.Select();
            btn_salir.Visible = false;
        }

        private void btn_mod2_Click(object sender, EventArgs e)
        {
            // LIMPIAR_detalle();
            btn_guardar2.Visible = false;
            btn_modificar2.Visible = true;
            //item1.Text = dgw.CurrentRow.Index.ToString
            Panel1.Visible = false;
            Panel2.Visible = true;
            //CARGAR_DETALLE();
            cbo_subgrupo.Enabled = false;
            btn_salir.Visible = false;
            TXT_CUENTA.Focus();
        }

        private void btn_eliminar2_Click(object sender, EventArgs e)
        {
            dgw.Rows.RemoveAt(dgw.CurrentRow.Index);
        }
    }
}
