using BLL;
using Entidades;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
namespace Presentacion.MOD_ADM
{
    public partial class PUNTO_COBRANZA_CONSOLIDADOS : Form
    {
        string boton; int op = 0;
        int fila, fila1;
        puntoCobranzaBLL ptoBLL = new puntoCobranzaBLL();
        puntoCobranzaTo ptoTo = new puntoCobranzaTo();
        puntoVentaBLL ptoVenBLL = new puntoVentaBLL();
        puntoVentaTo ptoVenTo = new puntoVentaTo();
        int opTabPage;
        string val1;
        string cod_inst;
        int opk;
        public PUNTO_COBRANZA_CONSOLIDADOS(string val1, string cod_inst, int opk)
        {
            InitializeComponent();
            this.val1 = val1;
            this.cod_inst = cod_inst;
            this.opk = opk;
        }

        private void PUNTO_COBRANZA_CONSOLIDADOS_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            DATAGRID();
            //CARGAR_PUNTO_COBRANZA();
            DATAGRID1();
            //CARGAR_PUNTO_COBRANZA1();
            opTabPage = 1;
            op = 1;
            if (opk == 1)
            {
                TabControl1.SelectedTab = TabPage1;
                ubicaFila();
                btn_modificar_Click(sender, e);
            }
            else if (opk == 2)
            {
                TabControl1.SelectedTab = tabPage3;
                ubicaFila1();
                btn_modificar1_Click(sender, e);
            }
            //CARGAR_SUCURSALES();
            //CARGAR_INSTITUCIONES();
            //CARGAR_CANALES_DSCTO();
            //btn_nuevo.Select();
        }
        private void ubicaFila()
        {
            for (int i = 0; i < dgw.Rows.Count; i++)
            {
                if (val1 == dgw.Rows[i].Cells[0].Value.ToString())
                {
                    dgw.Rows[i].Selected = true;
                    dgw.CurrentCell = dgw.Rows[i].Cells[1];
                    break;
                }
            }
        }
        private void ubicaFila1()
        {
            for (int i = 0; i < dgw1.Rows.Count; i++)
            {
                if (val1 == dgw1.Rows[i].Cells[0].Value.ToString())
                {
                    dgw1.Rows[i].Selected = true;
                    dgw1.CurrentCell = dgw1.Rows[i].Cells[1];
                    break;
                }
            }
        }
        private void CARGAR_PUNTO_COBRANZA()
        {
            cboptocob.DataSource = null;
            ptoTo.STATUS_CONSOLIDADO = true;//false;
            ptoTo.COD_INSTITUCION = cod_inst;
            DataTable dt = ptoBLL.obtenerPuntosCobranza_x_Inst_BLL(ptoTo);
            if (dt.Rows.Count > 0)
            {
                cboptocob.ValueMember = "COD_PTO_COB";
                cboptocob.DisplayMember = "DESC_PTO_COB";
                cboptocob.DataSource = dt;
            }
        }
        private void CARGAR_PUNTO_VENTA()
        {
            cboptocob.DataSource = null;
            ptoVenTo.COD_INSTITUCION = cod_inst;
            DataTable dt = ptoVenBLL.obtenerPuntosVentasBLL(ptoVenTo);
            if (dt.Rows.Count > 0)
            {
                cboptocob.ValueMember = "COD_PTO_VEN";
                cboptocob.DisplayMember = "DESC_PTO_VEN";
                cboptocob.DataSource = dt;
            }
        }
        private void CARGAR_PUNTO_COBRANZA1()
        {
            cboptocob.DataSource = null;
            ptoTo.STATUS_CONSOLIDADO_INFORMATIVO = false;
            ptoTo.COD_INSTITUCION = cod_inst;
            DataTable dt = ptoBLL.obtenerPuntosCobranzaConsolidadoInformativo_x_Inst_BLL(ptoTo);
            cboptocob.ValueMember = "COD_PTO_COB";
            cboptocob.DisplayMember = "DESC_PTO_COB";
            cboptocob.DataSource = dt;

        }
        private void PUNTO_COBRANZA_CONSOLIDADOS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void DATAGRID()
        {
            ptoTo.STATUS_CONSOLIDADO = true;
            ptoTo.COD_INSTITUCION = cod_inst;
            DataTable dt = ptoBLL.obtenerPuntosCobranzaBLL(ptoTo);
            dgw.DataSource = dt;
            dgw.Columns[0].Visible = false;
            dgw.Columns[1].HeaderText = "Punto de Cobranza Consolidado Proceso";
            dgw.Columns[1].Width = 240;
            dgw.Columns[2].Visible = false;
            dgw.Columns[3].HeaderText = "Canal de Descuento";
            dgw.Columns[3].Width = 220;
            dgw.Columns[4].Visible = false;
            dgw.Columns[5].Visible = false;
            dgw.Columns[6].Visible = false;
        }
        private void DATAGRID1()
        {
            ptoTo.STATUS_CONSOLIDADO_INFORMATIVO = true;
            ptoTo.COD_INSTITUCION = cod_inst;
            DataTable dt = ptoBLL.obtenerPuntosCobranzaConsolidadoInformativoBLL(ptoTo);
            dgw1.DataSource = dt;
            dgw1.Columns[0].Visible = false;
            dgw1.Columns[1].HeaderText = "Punto de Cobranza Consolidado Informativo";
            dgw1.Columns[1].Width = 240;
            dgw1.Columns[2].Visible = false;
            dgw1.Columns[3].HeaderText = "Canal de Descuento";
            dgw1.Columns[3].Width = 220;
            dgw1.Columns[4].Visible = false;
            dgw1.Columns[5].Visible = false;
            dgw1.Columns[6].Visible = false;
        }
        private void btn_modificar_Click(object sender, EventArgs e)
        {
            boton = "MODIFICAR";
            LIMPIAR_CABECERA();
            //btn_guardar.Visible = false;
            btn_modificar2.Visible = true;
            //CARGAR_CABECERA();
            CARGAR_DETALLES();
            //CARGAR_PUNTO_COBRANZA();
            CARGAR_PUNTO_VENTA();
            cboptocob.Enabled = false;
            panel3.Visible = false;
            //btn_agregar2.Visible = true;
            //btn_eliminar3.Visible = true;
            TabControl1.SelectedTab = TabPage2;
            TabPage4.Text = "Puntos de Venta";
            btn_agregar2.Visible = false;
            btn_eliminar3.Visible = false;
            btn_modificar2.Visible = false;
            op = 1;
            //cboptocob.Focus();
        }
        private void LIMPIAR_CABECERA()
        {
            cboptocob.SelectedIndex = -1;
            cboptocob.Enabled = true;
            DGW2.Rows.Clear();
            panel3.Visible = false;
        }
        private void CARGAR_DETALLES()
        {
            //CARGAR_DETALLES_PTO_COB();
            CARGAR_DETALLES_PTO_VEN();

        }
        private void CARGAR_DETALLES1()
        {
            CARGAR_DETALLES_PTO_COB1();
        }
        private void CARGAR_DETALLES_PTO_VEN()
        {
            if (dgw.Rows.Count > 0)
            {
                int idx = dgw.CurrentRow.Index;
                DGW2.Rows.Clear();
                ptoVenTo.COD_INSTITUCION = cod_inst;
                ptoVenTo.COD_PTO_COB = dgw[0, idx].Value.ToString();
                DataTable dt = ptoVenBLL.obtenerPuntoVentaVinculadosDetalleBLL(ptoVenTo);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow rw in dt.Rows)
                    {
                        int rowId = DGW2.Rows.Add();
                        DataGridViewRow row = DGW2.Rows[rowId];
                        row.Cells[0].Value = rw["COD_INSTITUCION"].ToString();
                        row.Cells[1].Value = rw["COD_PTO_VEN"].ToString();
                        row.Cells[2].Value = rw["DESC_PTO_VEN"].ToString();
                    }
                }
            }
        }
        private void CARGAR_DETALLES_PTO_COB()
        {
            if (dgw.Rows.Count > 0)
            {
                int idx = dgw.CurrentRow.Index;
                DGW2.Rows.Clear();
                ptoTo.COD_PTO_COB = dgw[0, idx].Value.ToString();
                DataTable dt = ptoBLL.obtenerPuntoCobranzaVinculadosBLL(ptoTo);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow rw in dt.Rows)
                    {
                        int rowId = DGW2.Rows.Add();
                        DataGridViewRow row = DGW2.Rows[rowId];
                        row.Cells[0].Value = rw["COD_PTO_COB_CONS"].ToString();
                        row.Cells[1].Value = rw["COD_PTO_COB"].ToString();
                        row.Cells[2].Value = rw["DESC_PTO_COB"].ToString();
                    }
                }
            }
        }
        private void CARGAR_DETALLES_PTO_COB1()
        {
            if (dgw1.Rows.Count > 0)
            {
                int idx = dgw1.CurrentRow.Index;
                DGW2.Rows.Clear();
                ptoTo.COD_PTO_COB = dgw1[0, idx].Value.ToString();
                DataTable dt = ptoBLL.obtenerPuntoCobranzaVinculadosInformativoBLL(ptoTo);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow rw in dt.Rows)
                    {
                        int rowId = DGW2.Rows.Add();
                        DataGridViewRow row = DGW2.Rows[rowId];
                        row.Cells[0].Value = rw["COD_PTO_COB_CONS"].ToString();
                        row.Cells[1].Value = rw["COD_PTO_COB"].ToString();
                        row.Cells[2].Value = rw["DESC_PTO_COB"].ToString();
                    }
                }
            }
        }
        private void btn_agregar2_Click(object sender, EventArgs e)
        {
            LIMPIAR_PTO_COB();
            btn_guardar31.Visible = true;
            //btn_mod21.Visible = false;
            panel3.Visible = true;
            cboptocob.Focus();
        }
        private void LIMPIAR_PTO_COB()
        {
            cboptocob.SelectedIndex = -1;
            cboptocob.Enabled = true;
        }
        private void btn_guardar31_Click(object sender, EventArgs e)
        {
            int idx = 0; string cod_pto_cob = "";
            if (op == 1)
            {
                idx = dgw.CurrentRow.Index;
                cod_pto_cob = dgw[0, idx].Value.ToString();
            }
            else if (op == 2)
            {
                idx = dgw1.CurrentRow.Index;
                cod_pto_cob = dgw1[0, idx].Value.ToString();
            }
            var query = from DataGridViewRow row in DGW2.Rows
                        where row.Cells["codx"].Value.ToString() == cboptocob.SelectedValue.ToString()
                        select row;
            if (!(query.Count() > 0))
            {
                DGW2.Rows.Add(cod_pto_cob, cboptocob.SelectedValue.ToString(), cboptocob.Text);
                panel3.Visible = false;
            }
            else
            {
                MessageBox.Show("Punto de Cobranza ya seleccionado !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btn_eliminar3_Click(object sender, EventArgs e)
        {
            if (DGW2.Rows.Count > 0)
                DGW2.Rows.RemoveAt(DGW2.CurrentRow.Index);
        }

        private void btn_modificar2_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("¿ Esta seguro de vincular un nuevo Punto de Cobranza ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                ptoTo.op = op;
                ptoTo.COD_PTO_COB_CONS = op == 1 ? dgw.CurrentRow.Cells[0].Value.ToString() : dgw1.CurrentRow.Cells[0].Value.ToString();
                //ptoTo.COD_INSTITUCION = op == 1 ? dgw.CurrentRow.Cells["COD_INSTITUCION"].Value.ToString() : dgw1.CurrentRow.Cells["COD_INSTITUCION"].Value.ToString();
                DataTable dtPtoCobDetalle = obtieneDTPtoCobDetalle();

                if (!ptoBLL.insertarPtoCobVinculadosBLL(ptoTo, dtPtoCobDetalle, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Se adicionó correctamente los elementos Vinculados !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //
                    ////dgw1.Rows.Add(cbo_año.Value.ToString(), cbo_mes.SelectedItem.ToString(), dtp1.Value.ToShortDateString(), dtp2.Value.ToShortDateString(), true);
                    //if(op == 1)
                    //    TabControl1.SelectedTab = TabPage1;
                    //else if(op == 2)
                    //    TabControl1.SelectedTab = tabPage3;
                }
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            //if (op == 1)
            //    TabControl1.SelectedTab = TabPage1;
            //else if (op == 2)
            //    TabControl1.SelectedTab = tabPage3;
            this.Dispose();
        }

        private void btn_cancelar31_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private DataTable obtieneDTPtoCobDetalle()
        {
            DataTable table = new DataTable();
            foreach (DataGridViewColumn column in DGW2.Columns)
            {
                table.Columns.Add(column.Name, typeof(string));
            }
            foreach (DataGridViewRow row in DGW2.Rows)
            {
                DataRow dataRow = table.NewRow();
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    dataRow[i] = row.Cells[i].Value != null ? row.Cells[i].Value : DBNull.Value;
                }
                table.Rows.Add(dataRow);
            }
            return table;
        }

        private void txt_letra_TextChanged(object sender, EventArgs e)
        {
            int i;
            if (ch_cod.Checked)
            {
                txt_letra.Focus();
                for (i = 0; i < dgw.Rows.Count; i++)
                {
                    if (txt_letra.TextLength <= dgw[1, i].Value.ToString().Length)
                    {
                        if (txt_letra.Text.ToLower() == dgw[1, i].Value.ToString().Substring(0, txt_letra.TextLength).ToLower())
                        {
                            dgw.CurrentCell = dgw.Rows[i].Cells[1];
                            break;
                        }
                    }

                }
            }
            else if (ch_rs.Checked)
            {
                txt_letra.Focus();
                for (i = 0; i < dgw.Rows.Count; i++)
                {
                    if (txt_letra.TextLength <= dgw[3, i].Value.ToString().Length)
                    {
                        if (txt_letra.Text.ToLower() == dgw[3, i].Value.ToString().Substring(0, txt_letra.TextLength).ToLower())
                        {
                            dgw.CurrentCell = dgw.Rows[i].Cells[3];
                            break;
                        }
                    }
                }
            }
        }

        private void ch_cod_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_cod.Checked)
            {
                dgw.Sort(dgw.Columns[1], System.ComponentModel.ListSortDirection.Ascending);
                btn_buscar.Enabled = false;
                btn_sgt.Enabled = false;
                txt_letra.Clear();
                txt_letra.Focus();
            }
        }

        private void ch_rs_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_rs.Checked)
            {
                dgw.Sort(dgw.Columns[3], System.ComponentModel.ListSortDirection.Ascending);
                btn_buscar.Enabled = false;
                btn_sgt.Enabled = false;
                txt_letra.Clear();
                txt_letra.Focus();
            }
        }

        private void ch_ca_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_ca.Checked)
            {
                btn_buscar.Enabled = true;
                txt_letra.Clear();
                txt_letra.Focus();
            }
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            int i, f;
            txt_letra.Focus();
            btn_sgt.Enabled = true;
            for (i = 0; i < dgw.Rows.Count; i++)
            {
                for (f = 0; f <= dgw[1, i].Value.ToString().Length - txt_letra.TextLength; f++)
                {
                    if (txt_letra.TextLength <= dgw[1, i].Value.ToString().Length)
                    {
                        if (txt_letra.Text.ToLower() == dgw[1, i].Value.ToString().Substring(f, txt_letra.TextLength).ToLower())
                        {
                            dgw.CurrentCell = dgw.Rows[i].Cells[1];
                            fila = i + 1;
                            return;
                        }
                    }
                }
            }
        }

        private void btn_sgt_Click(object sender, EventArgs e)
        {
            int i, f;//antes de dar a siguiente primero se hace buscar para que lo ubique en la primera coincidencia luego se da siguiente, siguiente..., hasta encontrar el valor buscado.
            for (i = fila; i < dgw.Rows.Count; i++)
            {
                for (f = 0; f <= dgw[1, i].Value.ToString().Length - txt_letra.TextLength; f++)
                {
                    if (txt_letra.TextLength <= dgw[1, i].Value.ToString().Length)
                    {
                        if (txt_letra.Text.ToLower() == dgw[1, i].Value.ToString().Substring(f, txt_letra.TextLength).ToLower())
                        {
                            dgw.CurrentCell = dgw.Rows[i].Cells[1];
                            fila = i + 1;
                            return;
                        }
                    }
                }
            }
            MessageBox.Show("Ya no existen más registros !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btn_modificar1_Click(object sender, EventArgs e)
        {
            boton = "MODIFICAR";
            LIMPIAR_CABECERA();
            //btn_guardar.Visible = false;
            btn_modificar2.Visible = true;
            //CARGAR_CABECERA();
            CARGAR_DETALLES1();
            CARGAR_PUNTO_COBRANZA1();
            cboptocob.Enabled = false;
            panel3.Visible = false;
            btn_agregar2.Visible = true;
            btn_eliminar3.Visible = true;
            btn_modificar2.Visible = true;
            TabControl1.SelectedTab = TabPage2;
            TabPage4.Text = "Puntos de Cobranza";
            op = 2;
            //cboptocob.Focus();
        }

        private void txt_letra1_TextChanged(object sender, EventArgs e)
        {
            int i;
            if (ch_cod1.Checked)
            {
                txt_letra1.Focus();
                for (i = 0; i < dgw1.Rows.Count; i++)
                {
                    if (txt_letra1.TextLength <= dgw1[1, i].Value.ToString().Length)
                    {
                        if (txt_letra1.Text.ToLower() == dgw1[1, i].Value.ToString().Substring(0, txt_letra1.TextLength).ToLower())
                        {
                            dgw1.CurrentCell = dgw1.Rows[i].Cells[1];
                            break;
                        }
                    }

                }
            }
            else if (ch_rs1.Checked)
            {
                txt_letra1.Focus();
                for (i = 0; i < dgw1.Rows.Count; i++)
                {
                    if (txt_letra1.TextLength <= dgw1[3, i].Value.ToString().Length)
                    {
                        if (txt_letra1.Text.ToLower() == dgw1[3, i].Value.ToString().Substring(0, txt_letra1.TextLength).ToLower())
                        {
                            dgw1.CurrentCell = dgw1.Rows[i].Cells[3];
                            break;
                        }
                    }
                }
            }
        }

        private void ch_cod1_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_cod1.Checked)
            {
                dgw1.Sort(dgw1.Columns[1], System.ComponentModel.ListSortDirection.Ascending);
                btn_buscar1.Enabled = false;
                btn_sgt1.Enabled = false;
                txt_letra1.Clear();
                txt_letra1.Focus();
            }
        }

        private void ch_rs1_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_rs1.Checked)
            {
                dgw1.Sort(dgw1.Columns[3], System.ComponentModel.ListSortDirection.Ascending);
                btn_buscar1.Enabled = false;
                btn_sgt1.Enabled = false;
                txt_letra1.Clear();
                txt_letra1.Focus();
            }
        }

        private void ch_ca1_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_ca1.Checked)
            {
                btn_buscar1.Enabled = true;
                txt_letra1.Clear();
                txt_letra1.Focus();
            }
        }

        private void btn_buscar1_Click(object sender, EventArgs e)
        {
            int i, f;
            txt_letra1.Focus();
            btn_sgt1.Enabled = true;
            for (i = 0; i < dgw1.Rows.Count; i++)
            {
                for (f = 0; f <= dgw1[1, i].Value.ToString().Length - txt_letra1.TextLength; f++)
                {
                    if (txt_letra1.TextLength <= dgw1[1, i].Value.ToString().Length)
                    {
                        if (txt_letra1.Text.ToLower() == dgw1[1, i].Value.ToString().Substring(f, txt_letra1.TextLength).ToLower())
                        {
                            dgw1.CurrentCell = dgw1.Rows[i].Cells[1];
                            fila1 = i + 1;
                            return;
                        }
                    }
                }
            }
        }

        private void btn_sgt1_Click(object sender, EventArgs e)
        {
            int i, f;//antes de dar a siguiente primero se hace buscar para que lo ubique en la primera coincidencia luego se da siguiente, siguiente..., hasta encontrar el valor buscado.
            for (i = fila1; i < dgw1.Rows.Count; i++)
            {
                for (f = 0; f <= dgw1[1, i].Value.ToString().Length - txt_letra1.TextLength; f++)
                {
                    if (txt_letra1.TextLength <= dgw1[1, i].Value.ToString().Length)
                    {
                        if (txt_letra1.Text.ToLower() == dgw1[1, i].Value.ToString().Substring(f, txt_letra1.TextLength).ToLower())
                        {
                            dgw1.CurrentCell = dgw1.Rows[i].Cells[1];
                            fila1 = i + 1;
                            return;
                        }
                    }
                }
            }
            MessageBox.Show("Ya no existen más registros !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btn_salir1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TabControl1.SelectedTab == TabPage1)
            {
                opTabPage = 1;
                op = 1;
            }
            else if (TabControl1.SelectedTab == tabPage3)
            {
                opTabPage = 2;
                op = 2;
            }
            //////////////////////////
            if (TabControl1.SelectedTab == TabPage2)
            {
                if (opTabPage == 1)
                {
                    if (boton == "NUEVO")
                    {
                        boton = "DETALLES1";
                    }
                    else if (boton == "MODIFICAR")
                    {
                        boton = "DETALLES2";
                    }
                    else
                    {
                        boton = "DETALLES";
                        LIMPIAR_CABECERA();
                        if (dgw1.Rows.Count == 0)
                        {
                        }
                        else
                            CARGAR_DETALLES();

                        btn_agregar2.Visible = false;
                        btn_eliminar3.Visible = false;
                        btn_modificar2.Visible = false;
                    }
                }
                else if (opTabPage == 2)
                {
                    if (boton == "NUEVO")
                    {
                        boton = "DETALLES1";
                    }
                    else if (boton == "MODIFICAR")
                    {
                        boton = "DETALLES2";
                    }
                    else
                    {
                        boton = "DETALLES";
                        LIMPIAR_CABECERA();
                        if (dgw1.Rows.Count == 0)
                        {
                        }
                        else
                            CARGAR_DETALLES1();

                        btn_agregar2.Visible = false;
                        btn_eliminar3.Visible = false;
                        btn_modificar2.Visible = false;
                    }
                }

            }
        }
    }
}
