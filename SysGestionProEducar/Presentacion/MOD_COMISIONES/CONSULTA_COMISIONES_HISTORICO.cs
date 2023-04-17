using BLL;
using Entidades;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Presentacion.MOD_COMISIONES
{
    public partial class CONSULTA_COMISIONES_HISTORICO : Form
    {
        pComisionBLL pcoBLL = new pComisionBLL();
        pComisionTo pcoTo = new pComisionTo();
        comisionesBLL comBLL = new comisionesBLL();
        comisionesTo comTo = new comisionesTo();
        DataTable dtGeneral, dtGeneral2 = null;
        int fila = 0;
        public CONSULTA_COMISIONES_HISTORICO()
        {
            InitializeComponent();
        }

        private void CONSULTA_COMISIONES_HISTORICO_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            TIPO_PLANILLA();
            CARGAR_PROGRAMAS();
            CARGAR_AÑO();
            CARGAR_MES();
            CARGAR_COMISIONISTAS();
        }

        private void CONSULTA_COMISIONES_HISTORICO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }
        private void TIPO_PLANILLA()
        {
            var items = new[] { new { cod = "P", val = "PLANILLA" }, new { cod = "D", val = "DIRECTA" } };
            var items1 = new[] { new { cod = "P", val = "PLANILLA" }, new { cod = "D", val = "DIRECTA" } };
            cbo_tipo.ValueMember = "cod";
            cbo_tipo.DisplayMember = "val";
            cbo_tipo.DataSource = items;
            cbo_tipo.SelectedIndex = 0;
            //
            cbo_tipo1.ValueMember = "cod";
            cbo_tipo1.DisplayMember = "val";
            cbo_tipo1.DataSource = items1;
            cbo_tipo1.SelectedIndex = 0;
        }
        private void CARGAR_PROGRAMAS()
        {
            programaBLL prgBLL = new programaBLL();
            DataTable dt = prgBLL.obtenerProgramaBLL();
            DataTable dt1 = prgBLL.obtenerProgramaBLL();
            cbo_prog.ValueMember = "COD_PROGRAMA";
            cbo_prog.DisplayMember = "DESC_PROGRAMA";
            cbo_prog.DataSource = dt;
            cbo_prog.SelectedIndex = 0;
            //
            cbo_prog1.ValueMember = "COD_PROGRAMA";
            cbo_prog1.DisplayMember = "DESC_PROGRAMA";
            cbo_prog1.DataSource = dt1;
            cbo_prog1.SelectedIndex = 0;
        }
        private void CARGAR_AÑO()
        {
            periodoBLL perBLL = new periodoBLL();
            periodoTo perTo = new periodoTo();
            //
            cbo_año.Items.Clear();
            perTo.COD_MODULO = "COM";
            DataTable dt = perBLL.obtenerAñoPeriodoBLL(perTo);
            DataTable dt1 = perBLL.obtenerAñoPeriodoBLL(perTo);
            DataTable dt2 = perBLL.obtenerAñoPeriodoBLL(perTo);
            cbo_año.ValueMember = "AÑO";
            cbo_año.DisplayMember = "AÑO";
            cbo_año.DataSource = dt;
            //
            cbo_año_del1.ValueMember = "AÑO";
            cbo_año_del1.DisplayMember = "AÑO";
            cbo_año_del1.DataSource = dt1;
            //
            cbo_año_al1.ValueMember = "AÑO";
            cbo_año_al1.DisplayMember = "AÑO";
            cbo_año_al1.DataSource = dt2;
        }
        private void CARGAR_MES()
        {
            var months1 = new[] {new { cod = "01", val = "ENERO" }, new { cod = "02", val = "FEBRERO" },
                                new { cod = "03", val = "MARZO" }, new { cod = "04", val = "ABRIL" },
                                new { cod = "05", val = "MAYO" }, new { cod = "06", val = "JUNIO" },
                                new { cod = "07", val = "JULIO" }, new { cod = "08", val = "AGOSTO" },
                                new { cod = "09", val = "SEPTIEMBRE" }, new { cod = "10", val = "OCTUBRE" },
                                new { cod = "11", val = "NOVIEMBRE" }, new { cod = "12", val = "DICIEMBRE" }};

            var months2 = new[] {new { cod = "01", val = "ENERO" }, new { cod = "02", val = "FEBRERO" },
                                new { cod = "03", val = "MARZO" }, new { cod = "04", val = "ABRIL" },
                                new { cod = "05", val = "MAYO" }, new { cod = "06", val = "JUNIO" },
                                new { cod = "07", val = "JULIO" }, new { cod = "08", val = "AGOSTO" },
                                new { cod = "09", val = "SEPTIEMBRE" }, new { cod = "10", val = "OCTUBRE" },
                                new { cod = "11", val = "NOVIEMBRE" }, new { cod = "12", val = "DICIEMBRE" }};

            var months3 = new[] {new { cod = "01", val = "ENERO" }, new { cod = "02", val = "FEBRERO" },
                                new { cod = "03", val = "MARZO" }, new { cod = "04", val = "ABRIL" },
                                new { cod = "05", val = "MAYO" }, new { cod = "06", val = "JUNIO" },
                                new { cod = "07", val = "JULIO" }, new { cod = "08", val = "AGOSTO" },
                                new { cod = "09", val = "SEPTIEMBRE" }, new { cod = "10", val = "OCTUBRE" },
                                new { cod = "11", val = "NOVIEMBRE" }, new { cod = "12", val = "DICIEMBRE" }};

            cbo_mes.ValueMember = "cod";
            cbo_mes.DisplayMember = "val";
            cbo_mes.DataSource = months1;
            //cbo_mes.SelectedIndex = -1;
            cbo_mes_del1.ValueMember = "cod";
            cbo_mes_del1.DisplayMember = "val";
            cbo_mes_del1.DataSource = months2;
            //
            cbo_mes_al1.ValueMember = "cod";
            cbo_mes_al1.DisplayMember = "val";
            cbo_mes_al1.DataSource = months3;
        }
        private void CARGAR_COMISIONISTAS()
        {
            comTo.TIPO = cbo_tipo1.SelectedValue.ToString();
            comTo.COD_PROGRAMA = cbo_prog1.SelectedValue.ToString();
            DataTable dt = comBLL.obtenerComisionistasparaConsultaBLL(comTo);
            dgw_per2.DataSource = dt;
            dgw_per2.Columns[0].HeaderText = "Código";
            dgw_per2.Columns[0].Width = 80;
            dgw_per2.Columns[1].HeaderText = "Apellidos y Nombres";
            dgw_per2.Columns[1].Width = 260;
            dgw_per2.Columns[2].HeaderText = "DNI";
            dgw_per2.Columns[2].Width = 100;
        }
        private void btn_buscar_Click(object sender, EventArgs e)
        {
            pcoTo.TIPO_VTA = cbo_tipo.SelectedValue.ToString();
            pcoTo.COD_PROGRAMA = cbo_prog.SelectedValue.ToString();
            pcoTo.FE_AÑO = cbo_año.SelectedValue.ToString();
            pcoTo.FE_MES = cbo_mes.SelectedValue.ToString();
            pcoTo.FE_AL = HelpersBLL.OBTENER_FECHA_FIN_DE_NOMBRE_MES_AÑO(cbo_mes.SelectedValue.ToString(), cbo_año.SelectedValue.ToString());
            dtGeneral = pcoBLL.obtenerComisionesPendientesBLL(pcoTo);
            dgw1.Rows.Clear();
            dgw2.Rows.Clear();

            if (dtGeneral.Rows.Count > 0)
            {
                DataTable dt1 = dtGeneral.AsEnumerable()
                   .GroupBy(r => new
                   {
                       Col01 = r["TIPO_VTA"],
                       Col02 = r["COD_PROGRAMA"],
                       Col03 = r["COD_VENDEDOR"],
                       Col04 = r["DESC_PER"],
                       Col05 = r["NRO_CONTRATO"],
                       Col06 = r["FE_CONTRATO"],
                       Col07 = r["FE_AÑO"],
                       Col08 = r["FE_MES"],
                       Col09 = r["COD_PER"],
                       Col10 = r["NOMCLI"]
                       //Col11 = r["NRO_LETRA"]
                   })
                   .Select(g => g.OrderBy(r => r["NRO_CONTRATO"]).First())
                   .CopyToDataTable();
                //
                if (dt1.Rows.Count > 0)
                {
                    foreach (DataRow rw in dt1.Rows)
                    {
                        int rowId = dgw1.Rows.Add();
                        DataGridViewRow row = dgw1.Rows[rowId];
                        row.Cells["TIPO_VTA"].Value = rw["TIPO_VTA"].ToString();
                        row.Cells["COD_PROGRAMA"].Value = rw["COD_PROGRAMA"].ToString();
                        row.Cells["COD_VENDEDOR"].Value = rw["COD_VENDEDOR"].ToString();
                        row.Cells["DESC_PER"].Value = rw["DESC_PER"].ToString();
                        row.Cells["NRO_CONTRATO"].Value = rw["NRO_CONTRATO"].ToString();
                        row.Cells["FE_CONTRATO"].Value = rw["FE_CONTRATO"].ToString().Substring(0, 10);
                        row.Cells["FE_AÑO"].Value = rw["FE_AÑO"].ToString();
                        row.Cells["FE_MES"].Value = rw["FE_MES"].ToString();
                        row.Cells["COD_PER"].Value = rw["COD_PER"].ToString();
                        row.Cells["NOMCLI"].Value = rw["NOMCLI"].ToString();
                        row.Cells["NRO_LETRA"].Value = rw["NRO_LETRA"].ToString();
                        //row.Cells["STATUS_PRE_APROB"].Value = rw["STATUS_PRE_APROB"].ToString() == "0" ? "A" : "P";//Aprobado y Pre-Aprobado
                    }
                }
            }
            else
            {
                MessageBox.Show("No se encontraron registros !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            dgw1.Select();
        }

        private void dgw1_SelectionChanged(object sender, EventArgs e)
        {
            if (dgw1.CurrentRow.Cells["NRO_CONTRATO"].Value != null)
            {
                llenaDetalle();
            }
        }

        private void dgw1_Click(object sender, EventArgs e)
        {
            llenaDetalle();
        }
        private void llenaDetalle()
        {
            dgw2.Rows.Clear();
            string nro_contrato = dgw1.CurrentRow.Cells["NRO_CONTRATO"].Value.ToString();
            DataTable dtDetalle = null;
            if (dtGeneral.Rows.Count > 0)
            {
                DataRow[] fila = dtGeneral.Select("NRO_CONTRATO = '" + nro_contrato + "'");
                if (fila.Length > 0)
                {
                    dtDetalle = fila.CopyToDataTable();
                    if (dtDetalle.Rows.Count > 0)
                    {
                        foreach (DataRow rw in dtDetalle.Rows)
                        {
                            int rowId = dgw2.Rows.Add();
                            DataGridViewRow row = dgw2.Rows[rowId];
                            row.Cells["TIPO_VTA1"].Value = rw["TIPO_VTA"].ToString();
                            row.Cells["COD_PROGRAMA1"].Value = rw["COD_PROGRAMA"].ToString();
                            row.Cells["COD_PER_SUP1"].Value = rw["COD_PER_SUP"].ToString();
                            row.Cells["NOM_PER_SUP1"].Value = rw["NOMSUP"].ToString();
                            row.Cells["NRO_CONTRATO1"].Value = rw["NRO_CONTRATO"].ToString();
                            row.Cells["NRO_LETRA1"].Value = rw["NRO_LETRA"].ToString();
                            row.Cells["IMP_FIN1"].Value = rw["IMP_FIN"].ToString();
                            row.Cells["COD_NIVEL1"].Value = rw["COD_NIVEL"].ToString();
                            row.Cells["DESC_NIVEL1"].Value = rw["DESC_NIVEL"].ToString();
                            row.Cells["STATUS_PRE_APROB"].Value = rw["STATUS_PRE_APROB"].ToString() == "0" ? "A" : "P";//Aprobado y Pre-Aprobado
                        }
                    }
                }
                else
                    dgw2.Rows.Clear();
            }
            else
                dgw2.Rows.Clear();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txt_letra_TextChanged(object sender, EventArgs e)
        {
            int i;
            if (ch_cod.Checked)
            {
                txt_letra.Focus();
                for (i = 0; i < dgw1.Rows.Count; i++)
                {
                    if (txt_letra.TextLength <= dgw1[2, i].Value.ToString().Length)
                    {
                        if (txt_letra.Text.ToLower() == dgw1[2, i].Value.ToString().Substring(0, txt_letra.TextLength).ToLower())
                        {
                            dgw1.CurrentCell = dgw1.Rows[i].Cells[2];
                            break;
                        }
                    }

                }
            }
            else if (ch_rs.Checked)
            {
                txt_letra.Focus();
                for (i = 0; i < dgw1.Rows.Count; i++)
                {
                    if (txt_letra.TextLength <= dgw1[7, i].Value.ToString().Length)
                    {
                        if (txt_letra.Text.ToLower() == dgw1[7, i].Value.ToString().Substring(0, txt_letra.TextLength).ToLower())
                        {
                            dgw1.CurrentCell = dgw1.Rows[i].Cells[7];
                            break;
                        }
                    }
                }
            }
            else if (ch_nc.Checked)
            {
                txt_letra.Focus();
                for (i = 0; i < dgw1.Rows.Count; i++)
                {
                    if (txt_letra.TextLength <= dgw1[11, i].Value.ToString().Length)
                    {
                        if (txt_letra.Text.ToLower() == dgw1[11, i].Value.ToString().Substring(0, txt_letra.TextLength).ToLower())
                        {
                            dgw1.CurrentCell = dgw1.Rows[i].Cells[11];
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
                dgw1.Sort(dgw1.Columns[2], System.ComponentModel.ListSortDirection.Ascending);
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
                dgw1.Sort(dgw1.Columns[7], System.ComponentModel.ListSortDirection.Ascending);
                btn_buscar.Enabled = false;
                btn_sgt.Enabled = false;
                txt_letra.Clear();
                txt_letra.Focus();
            }
        }

        private void ch_nc_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_nc.Checked)
            {
                dgw1.Sort(dgw1.Columns[11], System.ComponentModel.ListSortDirection.Ascending);
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
                btn_busq.Enabled = true;
                txt_letra.Clear();
                txt_letra.Focus();
            }
        }
        private void btn_busq_Click(object sender, EventArgs e)
        {
            int i, f;
            txt_letra.Focus();
            btn_sgt.Enabled = true;
            for (i = 0; i < dgw1.Rows.Count; i++)
            {
                for (f = 0; f <= dgw1[7, i].Value.ToString().Length - txt_letra.TextLength; f++)
                {
                    if (txt_letra.TextLength <= dgw1[7, i].Value.ToString().Length)
                    {
                        if (txt_letra.Text.ToLower() == dgw1[7, i].Value.ToString().Substring(f, txt_letra.TextLength).ToLower())
                        {
                            dgw1.CurrentCell = dgw1.Rows[i].Cells[7];
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
            for (i = fila; i < dgw1.Rows.Count; i++)
            {
                for (f = 0; f <= dgw1[7, i].Value.ToString().Length - txt_letra.TextLength; f++)
                {
                    if (txt_letra.TextLength <= dgw1[7, i].Value.ToString().Length)
                    {
                        if (txt_letra.Text.ToLower() == dgw1[7, i].Value.ToString().Substring(f, txt_letra.TextLength).ToLower())
                        {
                            dgw1.CurrentCell = dgw1.Rows[i].Cells[7];
                            fila = i + 1;
                            return;
                        }
                    }
                }
            }
            MessageBox.Show("Ya no existen más registros !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void txt_cod2_Leave(object sender, EventArgs e)
        {
            if (txt_cod2.Text.Trim() != "")
            {
                if (dgw_per2.Rows.Count > 0)
                {
                    dgw_per2.Sort(dgw_per2.Columns[0], System.ComponentModel.ListSortDirection.Ascending);
                    int i = 0, num2 = 0;
                    num2 = dgw_per2.Rows.Count - 1;
                    do
                    {
                        if (txt_cod2.Text.ToLower() == dgw_per2[0, i].Value.ToString().ToLower())
                        {
                            txt_cod2.Text = dgw_per2[0, i].Value.ToString();
                            txt_desc2.Text = dgw_per2[1, i].Value.ToString();
                            txt_doc_per2.Text = dgw_per2[4, i].Value.ToString();
                            return;
                        }
                        if (txt_cod2.Text.ToLower() == dgw_per2[0, i].Value.ToString().ToLower().Substring(0, txt_cod2.TextLength))
                        {
                            dgw_per2.CurrentCell = dgw_per2.Rows[i].Cells[0];
                            break;
                        }
                        dgw_per2.CurrentCell = dgw_per2.Rows[0].Cells[0];
                        i += 1;
                    }
                    while (i <= num2);

                    panel_per2.BringToFront();
                    panel_per2.Visible = true;
                    dgw_per2.Visible = true;
                    dgw_per2.Focus();
                }
            }
        }

        private void txt_desc2_Leave(object sender, EventArgs e)
        {
            if (txt_desc2.Text == "")
            {
                txt_doc_per2.Focus();
            }
            else
            {
                if (dgw_per2.Rows.Count > 0)
                {
                    dgw_per2.Sort(dgw_per2.Columns[1], System.ComponentModel.ListSortDirection.Ascending);
                    int i = 0, num2 = 0;
                    num2 = dgw_per2.Rows.Count;
                    do
                    {
                        if (dgw_per2[1, i].Value.ToString().Length >= txt_desc2.TextLength)
                        {
                            if (txt_desc2.Text.ToLower() == dgw_per2[1, i].Value.ToString().ToLower().Substring(0, txt_desc2.TextLength).ToLower())
                            {
                                dgw_per2.CurrentCell = dgw_per2.Rows[i].Cells[0];
                                break;
                            }
                        }
                        dgw_per2.CurrentCell = dgw_per2.Rows[0].Cells[0];
                        i += 1;
                    }
                    while (i < num2);
                    panel_per2.Visible = true;
                    dgw_per2.Visible = true;
                    dgw_per2.Focus();
                }
            }
        }

        private void dgw_per2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int idx = dgw_per2.CurrentRow.Index;
                txt_cod2.Text = dgw_per2[0, idx].Value.ToString();
                txt_desc2.Text = dgw_per2[1, idx].Value.ToString();
                //lblnivel.Text = dgw_per2[3, idx].Value.ToString();
                txt_doc_per2.Text = dgw_per2[2, idx].Value.ToString();
                panel_per2.Visible = false;
                //lblnivel.Visible = true;
                txt_doc_per2.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                panel_per2.Visible = false;
                txt_cod2.Clear();
                txt_desc2.Clear();
                //lblnivel.Text = "";
                txt_doc_per2.Clear();
                //lblnivel.Visible = false;
                txt_cod2.Focus();
            }
        }

        private void txt_doc_per2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_doc_per2.Text.Trim() == "")
                {

                }
                else if (dgw_per2.Rows.Count > 0)
                {
                    dgw_per2.Sort(dgw_per2.Columns[2], System.ComponentModel.ListSortDirection.Ascending);
                    int i = 0, num2 = 0;
                    num2 = dgw_per2.Rows.Count;
                    do
                    {
                        if (dgw_per2[2, i].Value.ToString().Length >= txt_doc_per2.TextLength)
                        {
                            if (txt_doc_per2.Text.ToLower() == dgw_per2[2, i].Value.ToString().ToLower().Substring(0, txt_doc_per2.TextLength).ToLower())
                            {
                                dgw_per2.CurrentCell = dgw_per2.Rows[i].Cells[0];
                                break;
                            }
                        }
                        dgw_per2.CurrentCell = dgw_per2.Rows[0].Cells[0];
                        i += 1;
                    }
                    while (i < num2);
                    panel_per2.Visible = true;
                    dgw_per2.Visible = true;
                    dgw_per2.Focus();
                }
            }
        }
        /*---------------------------------------------------------------------------------------------------------*/
        private void btn_buscar2_Click(object sender, EventArgs e)
        {
            pcoTo.FE_DEL = HelpersBLL.OBTENER_FECHA_INI_DE_NOMBRE_MES_AÑO(cbo_mes_del1.SelectedValue.ToString(), cbo_año_del1.SelectedValue.ToString());
            pcoTo.FE_AL = HelpersBLL.OBTENER_FECHA_FIN_DE_NOMBRE_MES_AÑO(cbo_mes_al1.SelectedValue.ToString(), cbo_año_al1.SelectedValue.ToString());
            if (!validaHistorico(pcoTo))
                return;
            pcoTo.TIPO_VTA = cbo_tipo1.SelectedValue.ToString();
            pcoTo.COD_PROGRAMA = cbo_prog1.SelectedValue.ToString();
            pcoTo.FE_AÑO = cbo_año_del1.SelectedValue.ToString();
            pcoTo.FE_MES = cbo_mes_del1.SelectedValue.ToString();

            pcoTo.COD_PER_SUP = txt_cod2.Text;
            dtGeneral2 = pcoBLL.obtenerComisionesHistoricosBLL(pcoTo);
            dgw11.Rows.Clear();
            dgw12.Rows.Clear();

            if (dtGeneral2.Rows.Count > 0)
            {
                DataTable dt1 = dtGeneral2.AsEnumerable()
                   .GroupBy(r => new
                   {
                       Col01 = r["TIPO_VTA"],
                       Col02 = r["COD_PROGRAMA"],
                       Col03 = r["COD_VENDEDOR"],
                       Col04 = r["DESC_PER"],
                       Col05 = r["NRO_CONTRATO"],
                       Col06 = r["FE_CONTRATO"],
                       Col07 = r["FE_AÑO"],
                       Col08 = r["FE_MES"],
                       Col09 = r["COD_PER"],
                       Col10 = r["NOMCLI"]
                       //Col11 = r["NRO_LETRA"]
                   })
                   .Select(g => g.OrderBy(r => r["NRO_CONTRATO"]).First())
                   .CopyToDataTable();
                //
                if (dt1.Rows.Count > 0)
                {
                    foreach (DataRow rw in dt1.Rows)
                    {
                        int rowId = dgw11.Rows.Add();
                        DataGridViewRow row = dgw11.Rows[rowId];
                        row.Cells["TIPO_VTA2"].Value = rw["TIPO_VTA"].ToString();
                        row.Cells["COD_PROGRAMA2"].Value = rw["COD_PROGRAMA"].ToString();
                        row.Cells["COD_VENDEDOR2"].Value = rw["COD_VENDEDOR"].ToString();
                        row.Cells["DESC_PER2"].Value = rw["DESC_PER"].ToString();
                        row.Cells["NRO_CONTRATO2"].Value = rw["NRO_CONTRATO"].ToString();
                        row.Cells["FE_CONTRATO2"].Value = rw["FE_CONTRATO"].ToString().Substring(0, 10);
                        row.Cells["FE_AÑO2"].Value = rw["FE_AÑO"].ToString();
                        row.Cells["FE_MES2"].Value = rw["FE_MES"].ToString();
                        row.Cells["COD_PER2"].Value = rw["COD_PER"].ToString();
                        row.Cells["NOMCLI2"].Value = rw["NOMCLI"].ToString();
                        row.Cells["NRO_LETRA2"].Value = rw["NRO_LETRA"].ToString();
                        //row.Cells["STATUS_PRE_APROB"].Value = rw["STATUS_PRE_APROB"].ToString() == "0" ? "A" : "P";//Aprobado y Pre-Aprobado
                    }
                }
            }
            else
            {
                MessageBox.Show("No se encontraron registros !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            dgw11.Select();
        }

        private void dgw11_SelectionChanged(object sender, EventArgs e)
        {
            if (dgw11.CurrentRow.Cells["NRO_CONTRATO2"].Value != null)
            {
                llenaDetalle2();
            }
        }

        private void dgw11_Click(object sender, EventArgs e)
        {
            llenaDetalle2();
        }
        private void llenaDetalle2()
        {
            dgw12.Rows.Clear();
            string nro_contrato = dgw11.CurrentRow.Cells["NRO_CONTRATO2"].Value.ToString();
            DataTable dtDetalle = null;
            if (dtGeneral2.Rows.Count > 0)
            {
                DataRow[] fila = dtGeneral2.Select("NRO_CONTRATO = '" + nro_contrato + "'", "NRO_LETRA,COD_D_H");
                if (fila.Length > 0)
                {
                    dtDetalle = fila.CopyToDataTable();
                    if (dtDetalle.Rows.Count > 0)
                    {
                        foreach (DataRow rw in dtDetalle.Rows)
                        {
                            int rowId = dgw12.Rows.Add();
                            DataGridViewRow row = dgw12.Rows[rowId];
                            row.Cells["TIPO_VTA3"].Value = rw["TIPO_VTA"].ToString();
                            row.Cells["COD_PROGRAMA3"].Value = rw["COD_PROGRAMA"].ToString();
                            row.Cells["COD_PER_SUP3"].Value = rw["COD_PER_SUP"].ToString();
                            row.Cells["NOM_PER_SUP3"].Value = rw["NOMSUP"].ToString();
                            row.Cells["NRO_CONTRATO3"].Value = rw["NRO_CONTRATO"].ToString();
                            row.Cells["NRO_LETRA3"].Value = rw["NRO_LETRA"].ToString();
                            row.Cells["IMP_FIN3"].Value = rw["IMPORTE"].ToString();
                            row.Cells["COD_NIVEL3"].Value = rw["COD_NIVEL"].ToString();
                            row.Cells["DESC_NIVEL3"].Value = rw["DESC_NIVEL"].ToString();
                            row.Cells["STATUS_PRE_APROB3"].Value = rw["STATUS_PRE_APROB"].ToString() == "0" ? "A" : "P";//Aprobado y Pre-Aprobado
                            row.Cells["COD_D_H"].Value = rw["COD_D_H"].ToString();
                            row.Cells["FE_DOC"].Value = rw["FE_DOC"].ToString().Substring(0, 10);
                            row.Cells["TIPO_OPE"].Value = rw["TIPO_OPE"].ToString();
                        }
                    }
                }
                else
                    dgw12.Rows.Clear();
            }
            else
                dgw12.Rows.Clear();
        }
        private bool validaHistorico(pComisionTo pcoTo)
        {
            bool result = true;
            if (pcoTo.FE_DEL >= pcoTo.FE_AL)
            {
                MessageBox.Show("Verifique el rango de fechas !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_mes_del1.Focus();
                return result = false;
            }
            if (txt_cod2.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese los datos del Comisionista !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_cod2.Focus();
                return result = false;
            }
            if (txt_desc2.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese los datos del Comisionista !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_desc2.Focus();
                return result = false;
            }
            if (txt_doc_per2.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese los datos del Comisionista !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_doc_per2.Focus();
                return result = false;
            }
            return result;
        }
        private void btnSalir2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
