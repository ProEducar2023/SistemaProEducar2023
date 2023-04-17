using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Presentacion.MOD_ALM.Reportes.Formulario
{
    public partial class KARDEX_INVENTARIO_HISTORICO : Form
    {
        string AÑO = "", MES = "", COD_MOD = "", COD_USU = "", TIPO_USU = "";
        string COD_CLASE = "", COD_SUCURSAL = "", COD_ALMACEN = "", COD_ARTICULO = "";
        DateTime FECHA_INI, FECHA_GRAL;
        HelpersBLL helBLL = new HelpersBLL();
        HelpersTo helTo = new HelpersTo();
        inventariosBLL invBLL = new inventariosBLL();
        inventariosTo invTo = new inventariosTo();
        public KARDEX_INVENTARIO_HISTORICO(string AÑO, string MES, DateTime FECHA_INI, DateTime FECHA_GRAL, string COD_MOD, string TIPO_USU, string COD_USU)
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

        private void KARDEX_INVENTARIO_HISTORICO_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            CARGAR_CLASE();
            CARGAR_SUCURSAL();
            CARGAR_PRODUCTOS();
            txt_cod_art.ReadOnly = true;
            txt_des_art.ReadOnly = true;
            //dtp_del.Value = Convert.ToDateTime(DateTime.Now.Day + "/" + FECHA_INI.Month + "/" + FECHA_INI.Year);
            dtp_del.Value = HelpersBLL.validaFecha(MES, AÑO, FECHA_GRAL);
            //dtp_al.Value = Convert.ToDateTime(DateTime.Now.Day + "/" + FECHA_INI.Month + "/" + FECHA_INI.Year);
            dtp_al.Value = dtp_del.Value;
        }

        private void KARDEX_INVENTARIO_HISTORICO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }
        private void CARGAR_CLASE()
        {
            //string TIPO_USU = "MS";
            //string COD_USU = "0000";
            bool validarTipo = true;
            string tipo = "P";
            bool validarDebeHaber = true;
            string debeHaber = "H";

            helTo.CODIGO = TIPO_USU;
            helTo.CODIGO2 = COD_USU;
            helTo.CODIGO3 = validarTipo == true ? "0" : "1";
            helTo.CODIGO4 = tipo;
            helTo.CODIGO5 = validarDebeHaber == true ? "0" : "1";
            helTo.CODIGO6 = debeHaber;
            DataTable dt = helBLL.CBO_CLASE_USU_TIPO_BLL(helTo);
            cbo_clase.ValueMember = "COD_CLASE";
            cbo_clase.DisplayMember = "DESC_CLASE";
            cbo_clase.DataSource = dt;
            cbo_clase.SelectedIndex = 0;
        }
        private void CARGAR_SUCURSAL()
        {
            //string COD_USU = "0000";
            helTo.CODIGO = COD_USU;
            DataTable dt = helBLL.CBO_SUCURSALBLL(helTo);
            cbo_suc.ValueMember = "COD_SUCURSAL";
            cbo_suc.DisplayMember = "DESC_sucursal";
            cbo_suc.DataSource = dt;
            cbo_suc.SelectedIndex = 0;
        }
        private void CARGAR_ALMACEN()
        {
            if (COD_CLASE != "" && COD_SUCURSAL != "")
            {
                almacenesBLL almBLL = new almacenesBLL();
                almacenTo almTo = new almacenTo();
                almTo.COD_CLASE = COD_CLASE;
                almTo.COD_SUCURSAL = COD_SUCURSAL;
                cbo_alm.ValueMember = "COD_ALMACEN";
                cbo_alm.DisplayMember = "DESC_CORTA";
                cbo_alm.DataSource = almBLL.obtenerAlmacenesparaInventarioBLL(almTo);
                cbo_alm.SelectedIndex = -1;
            }

        }
        private void CARGAR_PRODUCTOS()
        {
            articuloClaseBLL arcBLL = new articuloClaseBLL();
            articuloClaseTo arcTo = new articuloClaseTo();
            arcTo.COD_CLASE = COD_CLASE;
            dgw_art.DataSource = arcBLL.obtenerArticuloClaseparaInventarioBLL(arcTo);
            dgw_art.Columns[2].Visible = false;
            dgw_art.Columns[3].Visible = false;
            dgw_art.Columns[4].Visible = false;
        }
        private void cbo_clase_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_clase.SelectedValue != null)
            {
                COD_CLASE = cbo_clase.SelectedValue.ToString();
                CARGAR_PRODUCTOS();
                if (cbo_suc.SelectedIndex > -1)
                    CARGAR_ALMACEN();
            }
        }

        private void cbo_suc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_suc.SelectedValue != null)
            {
                COD_SUCURSAL = cbo_suc.SelectedValue.ToString();
                CARGAR_ALMACEN();
            }
        }

        private void chk_alm_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_alm.Checked)
            {
                cbo_alm.Enabled = true;
                cbo_alm.SelectedIndex = 0;
            }
            else
            {
                cbo_alm.Enabled = false;
                cbo_alm.SelectedIndex = -1;
            }
        }

        private void chk_art_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_art.Checked)
            {
                txt_cod_art.ReadOnly = false;
                txt_des_art.ReadOnly = false;
                txt_des_art.Clear();
                txt_cod_art.Clear();

            }
            else
            {
                txt_cod_art.ReadOnly = true;
                txt_des_art.ReadOnly = true;
                txt_cod_art.Clear();
                txt_des_art.Clear();
            }
        }

        private void txt_cod_art_Leave(object sender, EventArgs e)
        {
            if (txt_cod_art.Text.Trim() != "")
            {
                if (dgw_art.Rows.Count > 0)
                {
                    dgw_art.Sort(dgw_art.Columns[0], System.ComponentModel.ListSortDirection.Ascending);
                    int i = 0, num2 = 0;
                    num2 = dgw_art.Rows.Count - 1;
                    do
                    {
                        if (txt_cod_art.Text.ToLower() == dgw_art[0, i].Value.ToString().ToLower())
                        {
                            txt_cod_art.Text = dgw_art[0, i].Value.ToString();
                            txt_des_art.Text = dgw_art[1, i].Value.ToString();
                            Pan_art.Visible = false;
                            return;
                        }
                        if (dgw_art[0, i].Value.ToString().Length >= txt_cod_art.TextLength)
                        {
                            if (txt_cod_art.Text.ToLower() == dgw_art[0, i].Value.ToString().ToLower().Substring(0, txt_cod_art.TextLength).ToLower())
                            {
                                dgw_art.CurrentCell = dgw_art.Rows[i].Cells[0];
                                break;
                            }
                        }
                        dgw_art.CurrentCell = dgw_art.Rows[0].Cells[0];
                        i += 1;
                    }
                    while (i <= num2);
                    Pan_art.Visible = true;
                    dgw_art.Visible = true;
                    dgw_art.Focus();
                }
                else
                {
                    MessageBox.Show("No existen productos de la clase " + cbo_clase.Text, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void dgw_art_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int idx = dgw_art.CurrentRow.Index;
                txt_cod_art.Text = dgw_art[0, idx].Value.ToString();
                txt_des_art.Text = dgw_art[1, idx].Value.ToString();
                Pan_art.Visible = false;
                txt_des_art.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Pan_art.Visible = false;
                txt_cod_art.Clear();
                txt_des_art.Clear();
                txt_cod_art.Focus();
            }
        }

        private void txt_des_art_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txt_des_art.Text.Trim() != "")
            {
                if (dgw_art.Rows.Count > 0)
                {
                    dgw_art.Sort(dgw_art.Columns[1], System.ComponentModel.ListSortDirection.Ascending);
                    int i = 0, num2 = 0;
                    num2 = dgw_art.Rows.Count - 1;
                    do
                    {

                        if (txt_des_art.Text.ToLower() == dgw_art[1, i].Value.ToString().ToLower().Substring(0, txt_des_art.TextLength).ToLower())
                        {
                            dgw_art.CurrentCell = dgw_art.Rows[i].Cells[0];
                            break;
                        }
                        dgw_art.CurrentCell = dgw_art.Rows[0].Cells[0];
                        i += 1;
                    }
                    while (i <= num2);
                    Pan_art.Visible = true;
                    dgw_art.Visible = true;
                    dgw_art.Focus();
                }
                else
                {
                    MessageBox.Show("No existen productos de la clase " + cbo_clase.Text, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void btn_pantalla_Click(object sender, EventArgs e)
        {
            impresionKardexHistorico();
        }
        private void btn_resumen_Click(object sender, EventArgs e)
        {
            impresionKardexHistorico(1);
        }
        private void impresionKardexHistorico(int op = 0)
        {
            invTo.COD_CLASE = cbo_clase.SelectedValue.ToString();
            invTo.COD_SUCURSAL = cbo_suc.SelectedValue.ToString();
            invTo.COD_ALMACEN1 = chk_alm.Checked ? cbo_alm.SelectedValue.ToString() : null;
            invTo.COD_ARTICULO = chk_art.Checked ? txt_cod_art.Text : null;
            invTo.FE_DEL = dtp_del.Value.ToShortDateString();
            invTo.FE_AL = dtp_al.Value.ToShortDateString();
            DataTable dt = invBLL.obtenerReporteKardexInventarioHistoricoBLL(invTo);
            if (dt.Rows.Count > 0)
            {
                List<inventariosTo> linv = new List<inventariosTo>();
                foreach (DataRow rw in dt.Rows)
                {
                    inventariosTo inv = new inventariosTo();
                    inv.COD_ARTICULO = rw["COD_ARTICULO"].ToString();
                    inv.DESC_ARTICULO = rw["DESC_ARTICULO"].ToString();
                    inv.COD_DOC_INV = rw["COD_DOC_INV"].ToString();
                    inv.COMPROBANTE = rw["COMPROBANTE"].ToString();
                    inv.NUMERO = rw["NUMERO"].ToString();
                    inv.FECHA = Convert.ToDateTime(rw["FECHA"]);
                    inv.INGRESO = rw["INGRESO"].ToString();
                    inv.SALIDA = rw["SALIDA"].ToString();
                    inv.SALDO = rw["SALDO"].ToString();
                    inv.CONTRATO = rw["CONTRATO"].ToString();
                    inv.COD_ALMACEN = rw["COD_ALMACEN"].ToString();
                    inv.ORIGEN = rw["ORIGEN"].ToString();
                    inv.ORIGEN2 = rw["ORIGEN2"].ToString();
                    inv.DESTINO = rw["DESTINO"].ToString();
                    inv.TIPO_MOV = rw["TIPO_MOV"].ToString();
                    inv.DESC_PTO_VEN = rw["DESC_PTO_VEN"].ToString();
                    linv.Add(inv);
                }
                if (op != 1)
                {
                    MOD_ALM.Reportes.FormularioRep.REP_KARDEX_INVENTARIO frm = new FormularioRep.REP_KARDEX_INVENTARIO();
                    frm.fec_del = dtp_del.Value.ToShortDateString();
                    frm.fec_al = dtp_al.Value.ToShortDateString();
                    frm.suc = cbo_suc.Text;
                    frm.lstinv = linv;
                    frm.Show();
                }
                else
                {
                    MOD_ALM.Reportes.FormularioRep.REP_KARDEX_INVENTARIO_HISTORICO_RESUMEN fr = new FormularioRep.REP_KARDEX_INVENTARIO_HISTORICO_RESUMEN();
                    fr.fec_del = dtp_del.Value.ToShortDateString();
                    fr.fec_al = dtp_al.Value.ToShortDateString();
                    fr.suc = cbo_suc.Text;
                    fr.lstinv = linv;
                    fr.Show();
                }

            }
            else
            {
                MessageBox.Show("No existen datos !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_suc.Focus();
            }
        }
        private void btn_salir2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }


    }
}
