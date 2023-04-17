using BLL;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;

namespace Presentacion.MOD_ADM
{
    public partial class RELACION_EQ_COBRANZA : Form
    {
        string BOTON; DataTable dtEqc;
        int fila;
        DataTable dtR = new DataTable();
        progNivelRelacionBLL prnirBLL = new progNivelRelacionBLL();
        progNivelRelacionTo prnirTo = new progNivelRelacionTo();
        public RELACION_EQ_COBRANZA()
        {
            InitializeComponent();
        }

        private void RELACION_EQ_COBRANZA_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            cargaGrid();
            creadtR();
        }
        private void creadtR()
        {
            dtR.Columns.Add("COD_PROG", typeof(string));
            dtR.Columns.Add("COD_COB", typeof(string));
            dtR.Columns.Add("COD_SUPERIOR", typeof(string));
            dtR.Columns.Add("COD_NIVEL", typeof(string));
            //dtR.Columns.Add("COD_ALM", typeof(string));
        }
        private void cargaGrid()
        {
            progNivelBLL prnBLL = new progNivelBLL();
            dtEqc = prnBLL.obtenerSectoristasparaCrearEqCobradoresBLL("01");//02 Cobradores
            if (dtEqc.Rows.Count > 0)
            {
                for (int i = 0; i < dtEqc.Rows.Count; i++)
                {
                    int rowId = dgw.Rows.Add();
                    DataGridViewRow row = dgw.Rows[rowId];
                    dgw.Rows[i].Cells["cod"].Value = dtEqc.Rows[i]["COD_EQCOB"].ToString();
                    dgw.Rows[i].Cells["desc"].Value = dtEqc.Rows[i]["DESC_EQVTA"].ToString();
                    dgw.Rows[i].Cells["dni"].Value = dtEqc.Rows[i]["NRO_DOC"].ToString();
                    dgw.Rows[i].Cells["codpr"].Value = dtEqc.Rows[i]["COD_PROGRAMA"].ToString();
                    dgw.Rows[i].Cells["descpro"].Value = dtEqc.Rows[i]["DESC_PROGRAMA"].ToString();

                }
            }
        }
        private void RELACION_EQ_COBRANZA_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void dgw_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)//Asociar
            {
                int idx = dgw.CurrentRow.Index;
                DIALOGOS.frmRelacionarCobradorSuperior frm = new DIALOGOS.frmRelacionarCobradorSuperior();
                frm.codni = "01";//01 es el Sectorista y traerá todos los que no sean  01, ahora hay 02 cobradorea y 03 gestores(para cobranza directa)
                frm.codprog = dgw[3, idx].Value.ToString();
                frm.codsup = dgw[0, idx].Value.ToString();
                DataTable dt1 = prnirBLL.obtenerPrograNivelRelacionCobSupBLL(dgw.Rows[idx].Cells["cod"].Value.ToString());
                frm.CargarDatos(dt1);
                frm.ShowDialog();
            }
        }

        private void btn_consultar_Click(object sender, EventArgs e)
        {
            BOTON = "MODIFICAR";
            TabControl1.SelectedTab = TabPage2;
            int idx = dgw.CurrentRow.Index;
            lblsectorista.Text = dgw.Rows[idx].Cells["desc"].Value.ToString();
            CARGAR_DETALLES_DGW(idx);
        }
        private void CARGAR_DETALLES_DGW(int idx)
        {
            dgw1.DataSource = null;
            DataTable dt = prnirBLL.obtenerPrograNivelRelacionCobSupBLL(dgw.Rows[idx].Cells["cod"].Value.ToString());
            if (dt.Rows.Count > 0)
            {
                dgw1.DataSource = dt;
                dgw1.Columns[0].HeaderText = "Codigo";
                dgw1.Columns[0].Width = 100;
                dgw1.Columns[1].HeaderText = "Nombre";
                dgw1.Columns[1].Width = 280;
                dgw1.Columns[2].HeaderText = "Dni";
                dgw1.Columns[2].Width = 120;
                dgw1.Columns[3].HeaderText = "Email";
                dgw1.Columns[3].Width = 100;
            }
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            TabControl1.SelectedTab = TabPage1;
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
            else if (ch_dni.Checked)
            {
                txt_letra.Focus();
                for (i = 0; i < dgw.Rows.Count; i++)
                {
                    if (txt_letra.TextLength <= dgw[2, i].Value.ToString().Length)
                    {
                        if (txt_letra.Text.ToLower() == dgw[2, i].Value.ToString().Substring(0, txt_letra.TextLength).ToLower())
                        {
                            dgw.CurrentCell = dgw.Rows[i].Cells[2];
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
        private void ch_dni_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_dni.Checked)
            {
                dgw.Sort(dgw.Columns[2], System.ComponentModel.ListSortDirection.Ascending);
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
                    dgw1.DataSource = null;
                    //CARGAR_SUSTITUTO();
                    if (dgw.Rows.Count == 0)
                    {
                    }
                    else
                    {
                        int id = dgw.CurrentRow.Index;
                        lblsectorista.Text = dgw.Rows[id].Cells["desc"].Value.ToString();
                        CARGAR_DETALLES_DGW(id);
                    }

                }
            }
        }
    }
}
