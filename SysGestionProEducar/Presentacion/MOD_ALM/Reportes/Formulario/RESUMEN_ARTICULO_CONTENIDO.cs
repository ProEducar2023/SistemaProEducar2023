using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Presentacion.MOD_ALM.Reportes.Formulario
{
    public partial class RESUMEN_ARTICULO_CONTENIDO : Form
    {
        string AÑO = "", MES = "";
        public RESUMEN_ARTICULO_CONTENIDO(string AÑO, string MES)
        {
            InitializeComponent();
            this.AÑO = AÑO;
            this.MES = MES;
        }

        private void RESUMEN_ARTICULO_CONTENIDO_Load(object sender, EventArgs e)
        {
            CARGAR_ARTICULOS_CON_CONTENIDO();
            dtp_al.Value = Convert.ToDateTime(DateTime.Now.Day + "/" + MES + "/" + AÑO);
            dtp_del.Value = Convert.ToDateTime(DateTime.Now.Day + "/" + MES + "/" + AÑO);
        }
        private void CARGAR_ARTICULOS_CON_CONTENIDO()
        {
            articulosBLL artBLL = new articulosBLL();
            DataTable dt = artBLL.obtenerArticulos_con_ContenidoBLL();
            if (dt.Rows.Count > 0)
            {
                cbo_art_contenido.ValueMember = "COD_ARTICULO";
                cbo_art_contenido.DisplayMember = "DESC_ARTICULO";
                cbo_art_contenido.DataSource = dt;
            }
        }

        private void btn_pantalla_Click(object sender, EventArgs e)
        {
            articuloContenidoMovimientoBLL atcBLL = new articuloContenidoMovimientoBLL();
            articuloContenidoMovimientoTo atcTo = new articuloContenidoMovimientoTo();
            atcTo.FE_DESDE = dtp_del.Value;
            atcTo.FE_HASTA = dtp_al.Value;
            atcTo.COD_ARTICULO = cbo_art_contenido.SelectedValue.ToString();
            DataTable dt = atcBLL.obtenerResumenArticuloContenidoMovimientoBLL(atcTo);
            if (dt.Rows.Count > 0)
            {
                List<articuloContenidoMovimientoTo> lacm = new List<articuloContenidoMovimientoTo>();
                foreach (DataRow rw in dt.Rows)
                {
                    articuloContenidoMovimientoTo acm = new articuloContenidoMovimientoTo();
                    acm.COD_ART_CONTENIDO = rw["COD_ART_CONTENIDO"].ToString();
                    acm.DESC_ARTICULO = rw["DESC_ARTICULO"].ToString();
                    acm.SITUACION = rw["SITUACION"].ToString();
                    acm.CANTIDAD = Convert.ToInt32(rw["CANTIDAD"]);
                    lacm.Add(acm);
                }
                MOD_ALM.Reportes.FormularioRep.REP_RESUMEN_ARTICULO_CONTENIDO frm = new FormularioRep.REP_RESUMEN_ARTICULO_CONTENIDO();
                frm.fec_desde = dtp_del.Value.ToShortDateString();
                frm.fec_hasta = dtp_al.Value.ToShortDateString();
                frm.desc_articulo = cbo_art_contenido.Text;
                frm.lacm = lacm;
                frm.Show();

            }
            else
            {
                MessageBox.Show("No existen datos !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_art_contenido.Focus();
            }
        }
    }
}
