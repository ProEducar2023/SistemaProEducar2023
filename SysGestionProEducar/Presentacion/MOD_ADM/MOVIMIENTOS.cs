using BLL;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;
namespace Presentacion.MOD_ADM
{
    public partial class MOVIMIENTOS : Form
    {
        string BOTON;
        DataTable dtMov, dtMovSerie;
        movimientosBLL movBLL = new movimientosBLL();
        movimientosTo movTo = new movimientosTo();
        public MOVIMIENTOS()
        {
            InitializeComponent();
        }

        private void MOVIMIENTOS_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            dtMov = movBLL.obtenerMovimientosBLL();
            cargaDataGrid();
            llenaComboTipoOperacion();
            llenaComboTipoMov();
            btn_nuevo.Select();
        }
        private void llenaComboTipoOperacion()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("cod", typeof(string));
            dt.Columns.Add("des", typeof(string));
            DataRow rw = dt.NewRow();
            rw["cod"] = "V";
            rw["des"] = "Ventas";
            dt.Rows.Add(rw);
            DataRow rw1 = dt.NewRow();
            rw1["cod"] = "P";
            rw1["des"] = "Producción";
            dt.Rows.Add(rw1);
            DataRow rw2 = dt.NewRow();
            rw2["cod"] = "I";
            rw2["des"] = "Inventario";
            dt.Rows.Add(rw2);
            DataRow rw3 = dt.NewRow();
            rw3["cod"] = "N";
            rw3["des"] = "Interno";
            dt.Rows.Add(rw3);
            DataRow rw4 = dt.NewRow();
            rw4["cod"] = "C";
            rw4["des"] = "Compras";
            dt.Rows.Add(rw4);
            CBO_OPE.ValueMember = "cod";
            CBO_OPE.DisplayMember = "des";
            CBO_OPE.DataSource = dt;
        }
        private void llenaComboTipoMov()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("cod", typeof(string));
            dt.Columns.Add("des", typeof(string));
            DataRow rw = dt.NewRow();
            rw["cod"] = "D";
            rw["des"] = "Ingreso";
            dt.Rows.Add(rw);
            DataRow rw1 = dt.NewRow();
            rw1["cod"] = "H";
            rw1["des"] = "Salida";
            dt.Rows.Add(rw1);
            DataRow rw2 = dt.NewRow();
            rw2["cod"] = "A";
            rw2["des"] = "Transferencia";
            dt.Rows.Add(rw2);
            cbo_tipo_mov.ValueMember = "cod";
            cbo_tipo_mov.DisplayMember = "des";
            cbo_tipo_mov.DataSource = dt;
        }
        private void cargaDataGrid()
        {
            if (dtMov.Rows.Count > 0)
            {
                dgw1.Rows.Clear();
                foreach (DataRow rw in dtMov.Rows)
                {
                    int rowId = dgw1.Rows.Add();
                    DataGridViewRow row = dgw1.Rows[rowId];
                    row.Cells["cod"].Value = rw["Cod"].ToString();
                    row.Cells["desc"].Value = rw["Descripción"].ToString();
                    row.Cells["abr"].Value = rw["Abrev."].ToString();
                    row.Cells["ope"].Value = rw["Operación"].ToString();
                    row.Cells["codsunat"].Value = rw["Cod Sunat"].ToString();
                    row.Cells["tipmov"].Value = rw["Mov."].ToString();
                    row.Cells["valcost"].Value = rw["STATUS_VALOR_COSTOS"].ToString();
                }
            }
        }
        private void MOVIMIENTOS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            BOTON = "NUEVO";
            LIMPIAR();
            btn_guardar.Visible = true;
            btn_modificar2.Visible = false;
            TabControl1.SelectedTab = TabPage2;
            txt_cod.Focus();
        }
        private void LIMPIAR()
        {
            txt_cod.Clear();
            txt_desc.Clear();
            txt_desc2.Clear();
            CBO_OPE.SelectedIndex = -1;
            cbo_tipo_mov.SelectedIndex = -1;
            cbo_tipo_per.SelectedIndex = -1;
            //cbo_tipo_control.SelectedIndex = -1;
            txt_cod.ReadOnly = false;
            txt_desc.ReadOnly = false;
            txt_desc2.ReadOnly = false;
            CBO_OPE.Enabled = true;
            cbo_tipo_mov.Enabled = true;
            cbo_tipo_per.Enabled = true;
            //cbo_tipo_control.Enabled = true;
            //CH_CC.Checked = false;
            ch_vc.Checked = false;
            //CH_OP.Checked = false;
            //CH_MAQ.Checked = false;
            //CH_PARTE.Checked = false;
            //CH_CC.Enabled = true;
            //CH_OP.Enabled = true;
            //CH_MAQ.Enabled = true;
            //CH_PARTE.Enabled = false;
            ch_vc.Enabled = true;
            gbCabecera.Enabled = true;
            gbSeries.Enabled = true;
            dgvSeriesDocumento.Rows.Clear();
        }

        private void BTN_MODIFICAR_Click(object sender, EventArgs e)
        {
            BOTON = "MODIFICAR";
            btn_guardar.Visible = false;
            btn_modificar2.Visible = true;
            LIMPIAR();
            CARGAR_DATOS();
            txt_cod.ReadOnly = true;
            TabControl1.SelectedTab = TabPage2;
            txt_desc.Focus();
        }
        private void CARGAR_DATOS()
        {
            int i = dgw1.CurrentRow.Index;
            txt_cod.Text = dgw1[0, i].Value.ToString();
            txt_desc.Text = dgw1[1, i].Value.ToString();
            txt_desc2.Text = dgw1[2, i].Value.ToString();
            CBO_OPE.Text = dgw1[3, i].Value.ToString();
            txtCodSunat.Text = dgw1[4, i].Value.ToString();
            cbo_tipo_mov.Text = dgw1[5, i].Value.ToString();
            ch_vc.Checked = dgw1[6, i].Value.ToString() == "1" ? true : false;
            CargarSeries();
        }
        private void CargarSeries()
        {
            movimientoSerieBLL mosBLL = new movimientoSerieBLL();
            dtMovSerie = mosBLL.obtenerMovimientoSerieBLL(txt_cod.Text);
            foreach (DataRow rw in dtMovSerie.Rows)
            {
                int rowId = dgvSeriesDocumento.Rows.Add();
                DataGridViewRow row = dgvSeriesDocumento.Rows[rowId];
                row.Cells["codsuc"].Value = rw["COD_SUCURSAL"].ToString();
                row.Cells["suc"].Value = rw["Sucursal"].ToString();
                row.Cells["coddoc"].Value = rw["Cod Doc"].ToString();
                row.Cells["doc"].Value = rw["Documento"].ToString();
                row.Cells["stadoc"].Value = rw["STATUS_DOC"].ToString();
                row.Cells["ser"].Value = rw["Serie"].ToString();
            }
        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            frmSerieDocumentos frm = new frmSerieDocumentos(txt_desc.Text, dgvSeriesDocumento);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                dgvSeriesDocumento.Rows.Clear();
                int CantidadFilas = frm.dgvSeriesDocumento.Rows.Count - 1;
                int i = 0; int j = 0;
                if (frm.dgvSeriesDocumento.Rows.Count > 0)
                {
                    while (i <= CantidadFilas)
                    {
                        if (Convert.ToBoolean(frm.dgvSeriesDocumento[6, i].Value))
                        {
                            j = 0;
                            dgvSeriesDocumento.Rows.Add(frm.dgvSeriesDocumento[0, i].Value, frm.dgvSeriesDocumento[1, i].Value, frm.dgvSeriesDocumento[2, i].Value,
                                frm.dgvSeriesDocumento[3, i].Value, frm.dgvSeriesDocumento[4, i].Value, frm.dgvSeriesDocumento[5, i].Value);
                        }
                        i = i + 1;
                    }
                }
            }
        }

        private void btn_eliminar2_Click(object sender, EventArgs e)
        {
            if (dgvSeriesDocumento.Rows.Count > 0)
                dgvSeriesDocumento.Rows.RemoveAt(dgvSeriesDocumento.CurrentRow.Index);
        }
        private bool validaGuardarModificar()
        {
            bool result = true;
            if (txt_cod.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el Codigo !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_cod.Focus();
                return result = false;
            }
            if (txt_desc.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese la Descripcion !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_desc.Focus();
                return result = false;
            }
            if (txt_desc2.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese la Descripcion corta !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_desc2.Focus();
                return result = false;
            }
            if (CBO_OPE.SelectedIndex < 0)
            {
                MessageBox.Show("Elija el Tipo de Operacion !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                CBO_OPE.Focus();
                return result = false;
            }
            if (cbo_tipo_mov.SelectedIndex < 0)
            {
                MessageBox.Show("Elija el Tipo de Movimiento !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_tipo_mov.Focus();
                return result = false;
            }
            if (dgvSeriesDocumento.Rows.Count <= 0)
            {
                MessageBox.Show("Ingrese un documento !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btn_agregar.Focus();
                return result = false;
            }
            return result;
        }
        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (!validaGuardarModificar())
                return;
            DialogResult rs = MessageBox.Show("¿ ESTA SEGURO DE ADICIONAR UN NUEVO MOVIMIENTO ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                //
                movTo.COD_MOV = txt_cod.Text;
                movTo.DESC_MOV = txt_desc.Text;
                movTo.DESC_CORTA = txt_desc2.Text;
                movTo.TIPO_OPERACION = CBO_OPE.SelectedValue.ToString();
                movTo.CLASE_PERSONA = "";
                movTo.TIPO_MOV = cbo_tipo_mov.SelectedValue.ToString();
                movTo.STATUS_AREA = "0";
                movTo.STATUS_OP = "0";
                movTo.STATUS_MAQ = "0";
                movTo.STATUS_PARTE = "0";
                movTo.STATUS_VALOR_COSTOS = ch_vc.Checked == true ? "1" : "0";
                movTo.COD_TIPO_CONTROL = "";
                movTo.COD_SUNAT = txtCodSunat.Text;
                dtMovSerie = obtieneDTSerDoc();
                if (!movBLL.adicionaInsertaMovimientosBLL(movTo, dtMovSerie, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("SE ADICIONÓ CORRECTAMENTE EL MOVIMIENTO !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //
                    dgw1.Rows.Add(txt_cod.Text, txt_desc.Text, txt_desc2.Text, CBO_OPE.Text, txtCodSunat.Text, cbo_tipo_mov.Text, movTo.STATUS_VALOR_COSTOS);
                    LIMPIAR();
                    txt_cod.Focus();
                }
            }
        }
        private DataTable obtieneDTSerDoc()
        {
            DataTable table = new DataTable();
            foreach (DataGridViewColumn column in dgvSeriesDocumento.Columns)
            {
                table.Columns.Add(column.Name, typeof(string));
            }
            foreach (DataGridViewRow row in dgvSeriesDocumento.Rows)
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
        private void btn_modificar2_Click(object sender, EventArgs e)
        {
            if (!validaGuardarModificar())
                return;
            DialogResult rs = MessageBox.Show("¿ ESTA SEGURO DE MODIFICAR EL MOVIMIENTO ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                //
                movTo.COD_MOV = txt_cod.Text;
                movTo.DESC_MOV = txt_desc.Text;
                movTo.DESC_CORTA = txt_desc2.Text;
                movTo.TIPO_OPERACION = CBO_OPE.SelectedValue.ToString();
                movTo.CLASE_PERSONA = "";
                movTo.TIPO_MOV = cbo_tipo_mov.SelectedValue.ToString();
                movTo.STATUS_AREA = "0";
                movTo.STATUS_OP = "0";
                movTo.STATUS_MAQ = "0";
                movTo.STATUS_PARTE = "0";
                movTo.STATUS_VALOR_COSTOS = ch_vc.Checked == true ? "1" : "0";
                movTo.COD_TIPO_CONTROL = "";
                movTo.COD_SUNAT = txtCodSunat.Text;
                dtMovSerie = obtieneDTSerDoc();
                if (!movBLL.actualizaModificaMovimientosBLL(movTo, dtMovSerie, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("SE MODIFICÓ CORRECTAMENTE EL MOVIMIENTO !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //
                    int i = dgw1.CurrentRow.Index;
                    //txt_cod.Text = dgw1[0, i].Value.ToString();
                    dgw1[1, i].Value = txt_desc.Text;
                    dgw1[2, i].Value = txt_desc2.Text;
                    dgw1[3, i].Value = CBO_OPE.Text;
                    dgw1[4, i].Value = txtCodSunat.Text;
                    dgw1[5, i].Value = cbo_tipo_mov.Text;
                    dgw1[6, i].Value = ch_vc.Checked == true ? "1" : "0";
                    TabControl1.SelectedTab = TabPage1;
                    btn_nuevo.Select();
                }
            }
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("¿ ESTA SEGURO DE ELIMINAR EL MOVIMIENTO ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                //
                movTo.COD_MOV = dgw1.CurrentRow.Cells["cod"].Value.ToString();

                if (!movBLL.eliminarMovimientosBLL(movTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("SE ELIMINÓ CORRECTAMENTE EL MOVIMIENTO !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //
                    dgw1.Rows.RemoveAt(dgw1.CurrentRow.Index);
                }
            }
        }
        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            TabControl1.SelectedTab = TabPage1;
            btn_nuevo.FindForm();
        }
        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TabControl1.SelectedTab == TabPage2)
            {
                if (BOTON == "NUEVO")
                {
                    BOTON = "DETALLES1";
                }
                else if (BOTON == "MODIFICAR")
                {
                    BOTON = "DETALLES2";
                }
                else
                {
                    BOTON = "DETALLES";
                    LIMPIAR();
                    if (dgw1.Rows.Count == 0)
                    { }
                    else
                        CARGAR_DATOS();

                    //txt_cod.ReadOnly = true;
                    //txt_desc.ReadOnly = true;
                    gbCabecera.Enabled = false;
                    gbSeries.Enabled = false;
                    btn_guardar.Visible = false;
                    btn_modificar2.Visible = false;
                }
            }
            else
                btn_nuevo.Select();
        }
        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
