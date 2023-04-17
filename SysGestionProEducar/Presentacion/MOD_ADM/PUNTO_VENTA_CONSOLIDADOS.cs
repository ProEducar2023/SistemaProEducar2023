using BLL;
using Entidades;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
namespace Presentacion.MOD_ADM
{
    public partial class PUNTO_VENTA_CONSOLIDADOS : Form
    {
        puntoVentaBLL ptvBLL = new puntoVentaBLL();
        puntoVentaTo ptvTo = new puntoVentaTo();
        int fila;
        public PUNTO_VENTA_CONSOLIDADOS()
        {
            InitializeComponent();
        }

        private void PUNTO_VENTA_CONSOLIDADOS_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            DATAGRID();
            CARGAR_PUNTO_VENTA();
            //btn_nuevo.Select();
        }

        private void PUNTO_VENTA_CONSOLIDADOS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void DATAGRID()
        {
            ptvTo.STATUS_CONSOLIDADO = true;
            DataTable dt = ptvBLL.obtenerPuntosVentasBLL(ptvTo);
            dgw.DataSource = dt;
            dgw.Columns[0].Visible = false;
            dgw.Columns[1].HeaderText = "Descripcion";
            dgw.Columns[1].Width = 230;
            dgw.Columns[2].Visible = false;
            dgw.Columns[3].HeaderText = "Institucion";
            dgw.Columns[3].Width = 200;
        }
        private void CARGAR_PUNTO_VENTA()
        {
            ptvTo.STATUS_CONSOLIDADO = false;
            DataTable dt = ptvBLL.obtenerPuntosVentasBLL(ptvTo);
            cboptocob.ValueMember = "COD_PTO_VEN";
            cboptocob.DisplayMember = "DESC_PTO_VEN";
            cboptocob.DataSource = dt;
        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            LIMPIAR_CABECERA();
            //btn_guardar.Visible = false;
            btn_modificar2.Visible = true;
            //CARGAR_CABECERA();
            CARGAR_DETALLES();
            cboptocob.Enabled = false;
            Panel2.Visible = false;
            TabControl1.SelectedTab = TabPage2;
            //cboptocob.Focus();
        }
        private void LIMPIAR_CABECERA()
        {
            cboptocob.SelectedIndex = -1;
            cboptocob.Enabled = true;
            DGW2.Rows.Clear();
            Panel2.Visible = false;
        }
        private void CARGAR_DETALLES()
        {
            int idx = dgw.CurrentRow.Index;
            DGW2.Rows.Clear();
            ptvTo.COD_PTO_VEN_CONS = dgw[0, idx].Value.ToString();
            DataTable dt = ptvBLL.obtenerPuntoVentaVinculadosBLL(ptvTo);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow rw in dt.Rows)
                {
                    int rowId = DGW2.Rows.Add();
                    DataGridViewRow row = DGW2.Rows[rowId];
                    row.Cells[0].Value = rw["COD_PTO_VEN_CONS"].ToString();
                    row.Cells[1].Value = rw["COD_PTO_VEN"].ToString();
                    row.Cells[2].Value = rw["DESC_PTO_VEN"].ToString();
                }
            }
        }

        private void btn_agregar2_Click(object sender, EventArgs e)
        {
            LIMPIAR_FONO();
            btn_guardar31.Visible = true;
            //btn_mod21.Visible = false;
            Panel2.Visible = true;
            cboptocob.Focus();
        }
        private void LIMPIAR_FONO()
        {
            cboptocob.SelectedIndex = -1;
            cboptocob.Enabled = true;
        }

        private void btn_guardar31_Click(object sender, EventArgs e)
        {
            int idx = dgw.CurrentRow.Index;
            var query = from DataGridViewRow row in DGW2.Rows
                        where row.Cells["codx"].Value.ToString() == cboptocob.SelectedValue.ToString()
                        select row;
            if (!(query.Count() > 0))
            {
                DGW2.Rows.Add(dgw[0, idx].Value.ToString(), cboptocob.SelectedValue.ToString(), cboptocob.Text);
                Panel2.Visible = false;
            }
            else
            {
                MessageBox.Show("Punto de venta ya seleccionado !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btn_eliminar3_Click(object sender, EventArgs e)
        {
            if (DGW2.Rows.Count > 0)
                DGW2.Rows.RemoveAt(DGW2.CurrentRow.Index);
        }

        private void btn_modificar2_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("¿ Esta seguro de vincular un nuevo Punto de Venta ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                DataTable dtDetalle = obtieneDTDetalle();
                if (!ptvBLL.insertarPtoVenVinculadosBLL(dtDetalle, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Se adicionó correctamente el Punto de Venta Vinculado !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //
                    //dgw1.Rows.Add(cbo_año.Value.ToString(), cbo_mes.SelectedItem.ToString(), dtp1.Value.ToShortDateString(), dtp2.Value.ToShortDateString(), true);
                    TabControl1.SelectedTab = TabPage1;
                }
            }
        }
        private DataTable obtieneDTDetalle()
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

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            TabControl1.SelectedTab = TabPage1;
        }

        private void btn_cancelar31_Click(object sender, EventArgs e)
        {
            Panel2.Visible = false;
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Dispose();
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
    }
}
