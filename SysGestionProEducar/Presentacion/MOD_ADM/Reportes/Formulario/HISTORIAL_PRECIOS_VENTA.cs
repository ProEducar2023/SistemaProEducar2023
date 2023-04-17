using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Presentacion.MOD_ADM.Reportes.Formulario
{
    public partial class HISTORIAL_PRECIOS_VENTA : Form
    {
        public HISTORIAL_PRECIOS_VENTA()
        {
            InitializeComponent();
            CARGAR_GRUPO();

        }
        private void HISTORIAL_PRECIOS_VENTA_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }
        private void CARGAR_GRUPO()
        {
            grupoBLL gruBLL = new grupoBLL();
            DataTable dtGrupo = gruBLL.obtenerGrupoClaseBLL("01");
            cbo_grupo.DisplayMember = "DESC_GRUPO";
            cbo_grupo.ValueMember = "COD_GRUPO";
            cbo_grupo.DataSource = dtGrupo;
        }
        private void CARGAR_KIT()
        {
            kitBLL kitBLL = new kitBLL();
            kitTo kitTo = new kitTo();
            kitTo.COD_GRUPO = cbo_grupo.SelectedValue.ToString();
            DataTable dtKit = kitBLL.obtenerKitxGrupoBLL(kitTo);
            cbo_kit.DisplayMember = "Descripción";
            cbo_kit.ValueMember = "Cod";
            cbo_kit.DataSource = dtKit;
        }
        private void cbo_grupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_grupo.SelectedValue != null)
                CARGAR_KIT();
        }
        private void btn_pantalla_Click(object sender, EventArgs e)
        {
            inventariosBLL invBLL = new inventariosBLL();
            inventariosTo invTo = new inventariosTo();
            invTo.FE_DESDE = dtp_del.Value;
            invTo.FE_HASTA = dtp_al.Value;
            invTo.COD_KIT = cbo_kit.SelectedValue.ToString();
            DataTable dt = invBLL.obetenerReporteHistorialPrecioVentaBLL(invTo);
            if (dt.Rows.Count > 0)
            {
                List<inventariosTo> linv = new List<inventariosTo>();
                foreach (DataRow rw in dt.Rows)
                {
                    inventariosTo inv = new inventariosTo();
                    inv.COD_ARTICULO = rw["COD_ARTICULO"].ToString();
                    inv.DESC_ARTICULO = rw["DESC_ARTICULO"].ToString();
                    inv.STATUS_IGV = rw["STATUS_IGV"].ToString() == "0" ? "N" : "S";
                    inv.FEC_ACTUALIZACION = Convert.ToDateTime(rw["FEC_ACTUALIZACION"]);
                    inv.PRECIO_UNITARIO = Convert.ToDecimal(rw["PRECIO_UNITARIO"]);
                    inv.ST_VALOR_REFERENCIAL = rw["ST_VALOR_REFERENCIAL"].ToString() == "True" ? "S" : "N";
                    linv.Add(inv);
                }
                MOD_ADM.Reportes.FormularioRepp.REP_HISTORIAL_PRECIO_VENTA frm = new FormularioRepp.REP_HISTORIAL_PRECIO_VENTA();
                frm.fec_desde = dtp_del.Value.ToShortDateString();
                frm.fec_hasta = dtp_al.Value.ToShortDateString();
                frm.grupo = cbo_grupo.Text;
                frm.kit = cbo_kit.Text;
                frm.linv = linv;
                frm.Show();
            }
            else
            {
                MessageBox.Show("No existen datos !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtp_del.Focus();
            }
        }
        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }


    }
}
