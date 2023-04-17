using BLL;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;

namespace Presentacion.MOD_ADM
{
    public partial class RELACION_EQ_VENTA : Form
    {
        string BOTON; DataTable dtEqv, dtReEq;
        int fila;
        DataTable dtR = new DataTable();
        progNivelRelacionBLL prnirBLL = new progNivelRelacionBLL();
        progNivelRelacionTo prnirTo = new progNivelRelacionTo();
        //DIALOGOS.frmListar frm = new DIALOGOS.frmListar();
        public RELACION_EQ_VENTA()
        {
            InitializeComponent();
        }

        private void RELACION_EQ_VENTA_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            cargaGrid();
            creadtR();
        }
        private void creadtR()
        {
            dtR.Columns.Add("COD_PROG", typeof(string));
            dtR.Columns.Add("COD_VEND", typeof(string));
            dtR.Columns.Add("COD_SUPERIOR", typeof(string));
            dtR.Columns.Add("COD_NIVEL", typeof(string));
            dtR.Columns.Add("COD_ALM", typeof(string));
            //dtR.Columns.Add("COD_ENC_NUM_CONTRATO", typeof(string));
        }
        private void cargaGrid()
        {
            progNivelBLL prnBLL = new progNivelBLL();
            //progNivelRelacionBLL prniBLL = new progNivelRelacionBLL();
            dtEqv = prnBLL.obtenerVendedoresparaCrearEqVentasBLL();
            if (dtEqv.Rows.Count > 0)
            {
                for (int i = 0; i < dtEqv.Rows.Count; i++)
                {
                    int rowId = dgw.Rows.Add();
                    DataGridViewRow row = dgw.Rows[rowId];
                    dgw.Rows[i].Cells["cod"].Value = dtEqv.Rows[i]["COD_PER"].ToString();
                    dgw.Rows[i].Cells["desc"].Value = dtEqv.Rows[i]["DESC_PER"].ToString();
                    dgw.Rows[i].Cells["codpr"].Value = dtEqv.Rows[i]["COD_PROGRAMA"].ToString();
                    dgw.Rows[i].Cells["descpro"].Value = dtEqv.Rows[i]["DESC_PROGRAMA"].ToString();
                    prnirTo.COD_PROG = dgw.Rows[i].Cells["codpr"].Value.ToString();
                    prnirTo.COD_VEND = dgw.Rows[i].Cells["cod"].Value.ToString();

                    dtReEq = prnirBLL.obtenerRelacionVendSupBLL(prnirTo);
                    if (dtReEq.Rows.Count > 0)
                    {
                        dgw.Rows[i].Cells["n1"].Value = dtReEq.Rows[0]["COD_SUPERIOR"].ToString();
                        dgw.Rows[i].Cells["n2"].Value = dtReEq.Rows[1]["COD_SUPERIOR"].ToString();
                        dgw.Rows[i].Cells["n3"].Value = dtReEq.Rows[2]["COD_SUPERIOR"].ToString();
                        dgw.Rows[i].Cells["codalm"].Value = dtReEq.Rows[0]["COD_ALM"].ToString();
                        //dgw.Rows[i].Cells["cod_enc_num"].Value = dtReEq.Rows[0]["COD_ENC_NUM_CONTRATO"].ToString();
                    }
                }
            }
        }
        private void RELACION_EQ_VENTA_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void dgw_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)//Asociar
            {
                DIALOGOS.frmRelacionarVendedorJefe frm = new DIALOGOS.frmRelacionarVendedorJefe();
                frm.codpro = dgw.CurrentRow.Cells["codpr"].Value.ToString();
                frm.CargarDatos(dgw.CurrentRow);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    int i = -1, j = -1, k = -1;
                    foreach (DataGridViewRow row in frm.dgw.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells["op"].Value))
                        {
                            if (row.Cells["codn"].Value.ToString() == "01")
                            {
                                dgw[5, dgw.CurrentRow.Index].Value = row.Cells["cod"].Value;
                                i++;
                            }
                            if (row.Cells["codn"].Value.ToString() == "02")
                            {
                                dgw[6, dgw.CurrentRow.Index].Value = row.Cells["cod"].Value;
                                j++;
                            }
                            if (row.Cells["codn"].Value.ToString() == "03")
                            {
                                dgw[7, dgw.CurrentRow.Index].Value = row.Cells["cod"].Value;
                                k++;
                            }
                        }
                    }
                    if (frm.cbo_alm.SelectedValue != null)
                        dgw[8, dgw.CurrentRow.Index].Value = frm.cbo_alm.SelectedValue.ToString();

                    //if (frm.cbo_enc_num_contrato.SelectedValue != null)
                    //    dgw[9, dgw.CurrentRow.Index].Value = frm.cbo_enc_num_contrato.SelectedValue.ToString();

                    if (i > 0 || j > 0 || k > 0)
                    {
                        MessageBox.Show("ALGUN NIVEL ESTA REPETIDO HÁGALO DE NUEVO !!!");
                        dgw[5, dgw.CurrentRow.Index].Value = "";
                        dgw[6, dgw.CurrentRow.Index].Value = "";
                        dgw[7, dgw.CurrentRow.Index].Value = "";
                        dgw[8, dgw.CurrentRow.Index].Value = "";
                        //dgw[9, dgw.CurrentRow.Index].Value = "";
                    }
                }
            }
            else if (e.ColumnIndex == 10)//Grabar
            {
                if (!valida())
                    return;
                DialogResult rs = MessageBox.Show("¿ Esta seguro de grabar este registro ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    string errMensaje = string.Empty;
                    int idx = dgw.CurrentRow.Index;
                    obtieneDTRelacion();
                    if (!prnirBLL.adicionaProgNivelRelacionBLL(dtR, ref errMensaje))
                        MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        MessageBox.Show("Se grabó este registro correctamente !!!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dtR.Rows.Clear();
                    }
                }
            }
        }
        private bool valida()
        {
            bool result = true;
            if (dgw.Rows.Count > 0)
            {
                if (dgw[5, dgw.CurrentRow.Index].Value == null || dgw[6, dgw.CurrentRow.Index].Value == null || dgw[7, dgw.CurrentRow.Index].Value == null)
                {
                    MessageBox.Show("Ingrese correctamente los niveles,\n se deben de crear los 4 niveles o completar con Nivel de Oficina!!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return result = false;
                }
                else if (dgw[5, dgw.CurrentRow.Index].Value.ToString() == "" || dgw[6, dgw.CurrentRow.Index].Value.ToString() == "" || dgw[7, dgw.CurrentRow.Index].Value.ToString() == "")
                {
                    MessageBox.Show("Ingrese correctamente los niveles,\n se deben de crear los 4 niveles o completar con Nivel de Oficina!!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return result = false;
                }
                else if (dgw[8, dgw.CurrentRow.Index].Value == null)
                {
                    MessageBox.Show("Elija el Almacen !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return result = false;
                }
            }
            return result;
        }
        private void obtieneDTRelacion()
        {
            DataRow rw = dtR.NewRow();
            rw["COD_PROG"] = dgw[2, dgw.CurrentRow.Index].Value.ToString();
            rw["COD_VEND"] = dgw[0, dgw.CurrentRow.Index].Value.ToString();
            rw["COD_SUPERIOR"] = dgw[5, dgw.CurrentRow.Index].Value.ToString();
            rw["COD_NIVEL"] = "01";
            rw["COD_ALM"] = dgw[8, dgw.CurrentRow.Index].Value.ToString();
            //rw["COD_ENC_NUM_CONTRATO"] = dgw[9, dgw.CurrentRow.Index].Value.ToString();
            dtR.Rows.Add(rw);

            DataRow rw1 = dtR.NewRow();
            rw1["COD_PROG"] = dgw[2, dgw.CurrentRow.Index].Value.ToString();
            rw1["COD_VEND"] = dgw[0, dgw.CurrentRow.Index].Value.ToString();
            rw1["COD_SUPERIOR"] = dgw[6, dgw.CurrentRow.Index].Value.ToString();
            rw1["COD_NIVEL"] = "02";
            rw1["COD_ALM"] = dgw[8, dgw.CurrentRow.Index].Value.ToString();
            //rw1["COD_ENC_NUM_CONTRATO"] = dgw[9, dgw.CurrentRow.Index].Value.ToString();
            dtR.Rows.Add(rw1);

            DataRow rw2 = dtR.NewRow();
            rw2["COD_PROG"] = dgw[2, dgw.CurrentRow.Index].Value.ToString();
            rw2["COD_VEND"] = dgw[0, dgw.CurrentRow.Index].Value.ToString();
            rw2["COD_SUPERIOR"] = dgw[7, dgw.CurrentRow.Index].Value.ToString();
            rw2["COD_NIVEL"] = "03";
            rw2["COD_ALM"] = dgw[8, dgw.CurrentRow.Index].Value.ToString();
            //rw2["COD_ENC_NUM_CONTRATO"] = dgw[9, dgw.CurrentRow.Index].Value.ToString();
            dtR.Rows.Add(rw2);
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
                    if (txt_letra.TextLength <= dgw[0, i].Value.ToString().Length)
                    {
                        if (txt_letra.Text.ToLower() == dgw[0, i].Value.ToString().Substring(0, txt_letra.TextLength).ToLower())
                        {
                            dgw.CurrentCell = dgw.Rows[i].Cells[0];
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
                dgw.Sort(dgw.Columns[0], System.ComponentModel.ListSortDirection.Ascending);
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
