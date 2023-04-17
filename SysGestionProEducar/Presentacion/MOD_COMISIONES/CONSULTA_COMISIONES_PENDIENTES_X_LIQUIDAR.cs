using BLL;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;

namespace Presentacion.MOD_COMISIONES
{
    public partial class CONSULTA_COMISIONES_PENDIENTES_X_LIQUIDAR : Form
    {
        //comisionesBLL comBLL = new comisionesBLL();
        //comisionesTo comTo = new comisionesTo();
        pComisionBLL pcoBLL = new pComisionBLL();
        pComisionTo pcoTo = new pComisionTo();
        DataTable dtGeneral = null;
        int fila = 0;
        public CONSULTA_COMISIONES_PENDIENTES_X_LIQUIDAR()
        {
            InitializeComponent();
        }

        private void CONSULTA_COMISIONES_PENDIENTES_X_LIQUIDAR_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            TIPO_PLANILLA();
            CARGAR_PROGRAMAS();
            CARGAR_AÑO();
            CARGAR_MES();
        }

        private void CONSULTA_COMISIONES_PENDIENTES_X_LIQUIDAR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void TIPO_PLANILLA()
        {
            var items = new[] { new { cod = "P", val = "PLANILLA" }, new { cod = "D", val = "DIRECTA" } };
            cbo_tipo.ValueMember = "cod";
            cbo_tipo.DisplayMember = "val";
            cbo_tipo.DataSource = items;
            cbo_tipo.SelectedIndex = 0;
        }
        private void CARGAR_PROGRAMAS()
        {
            programaBLL prgBLL = new programaBLL();
            DataTable dt = prgBLL.obtenerProgramaBLL();
            cbo_prog.ValueMember = "COD_PROGRAMA";
            cbo_prog.DisplayMember = "DESC_PROGRAMA";
            cbo_prog.DataSource = dt;
            cbo_prog.SelectedIndex = 0;
        }
        private void CARGAR_AÑO()
        {
            periodoBLL perBLL = new periodoBLL();
            periodoTo perTo = new periodoTo();
            //
            cbo_año.Items.Clear();
            perTo.COD_MODULO = "COM";
            DataTable dt = perBLL.obtenerAñoPeriodoBLL(perTo);
            cbo_año.ValueMember = "AÑO";
            cbo_año.DisplayMember = "AÑO";
            cbo_año.DataSource = dt;
        }
        private void CARGAR_MES()
        {
            var months1 = new[] {new { cod = "01", val = "ENERO" }, new { cod = "02", val = "FEBRERO" },
                                new { cod = "03", val = "MARZO" }, new { cod = "04", val = "ABRIL" },
                                new { cod = "05", val = "MAYO" }, new { cod = "06", val = "JUNIO" },
                                new { cod = "07", val = "JULIO" }, new { cod = "08", val = "AGOSTO" },
                                new { cod = "09", val = "SEPTIEMBRE" }, new { cod = "10", val = "OCTUBRE" },
                                new { cod = "11", val = "NOVIEMBRE" }, new { cod = "12", val = "DICIEMBRE" }};

            cbo_mes.ValueMember = "cod";
            cbo_mes.DisplayMember = "val";
            cbo_mes.DataSource = months1;
            //cbo_mes.SelectedIndex = -1;
        }

        private void btn_consulta1_Click(object sender, EventArgs e)
        {
            pcoTo.TIPO_VTA = cbo_tipo.SelectedValue.ToString();
            pcoTo.COD_PROGRAMA = cbo_prog.SelectedValue.ToString();
            pcoTo.FE_AÑO = cbo_año.SelectedValue.ToString();
            pcoTo.FE_MES = cbo_mes.SelectedValue.ToString();
            dtGeneral = pcoBLL.obtenerComisionesPendientesxContratoBLL(pcoTo);
            dgw1.Rows.Clear();
            //dgw2.Rows.Clear();

            if (dtGeneral.Rows.Count > 0)
            {
                foreach (DataRow rw in dtGeneral.Rows)
                {
                    int rowId = dgw1.Rows.Add();
                    DataGridViewRow row = dgw1.Rows[rowId];
                    row.Cells["TIPO_VTA"].Value = rw["TIPO_PLANILLA"].ToString();
                    row.Cells["COD_PROGRAMA"].Value = rw["COD_PROGRAMA"].ToString();
                    row.Cells["NRO_PRESUPUESTO"].Value = rw["NRO_PRESUPUESTO"].ToString();
                    row.Cells["COD_VENDEDOR"].Value = rw["COD_VENDEDOR"].ToString();
                    row.Cells["VEND"].Value = rw["VEND"].ToString();
                    row.Cells["FECHA_PRE"].Value = rw["FECHA_PRE"].ToString().Substring(0, 10);
                    row.Cells["FECHA_APROB"].Value = rw["FECHA_APROB"].ToString().Substring(0, 10);
                    row.Cells["COD_PER"].Value = rw["COD_PER"].ToString();
                    row.Cells["DESC_PER"].Value = rw["DESC_PER"].ToString();
                    row.Cells["ST_APROB"].Value = rw["ST_APROB"].ToString();
                    row.Cells["ST_PRE_APROB"].Value = rw["ST_PRE_APROB"].ToString();
                    //row.Cells["X"].Value = true;
                }
            }
            else
                MessageBox.Show("No se encontraron registros !!!", "MENSAJES", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            //if (dtGeneral.Rows.Count > 0)
            //{
            //    DataTable dt1 = dtGeneral.AsEnumerable()
            //       .GroupBy(r => new
            //       {
            //           Col01 = r["TIPO_VTA"],
            //           Col02 = r["COD_PROGRAMA"],
            //           Col03 = r["COD_VENDEDOR"],
            //           Col04 = r["DESC_PER"],
            //           Col05 = r["NRO_CONTRATO"],
            //           Col06 = r["FE_CONTRATO"],
            //           Col07 = r["FE_AÑO"],
            //           Col08 = r["FE_MES"],
            //           Col09 = r["COD_PER"],
            //           Col10 = r["NOMCLI"]
            //           //Col11 = r["NRO_LETRA"]
            //       })
            //       .Select(g => g.OrderBy(r => r["NRO_CONTRATO"]).First())
            //       .CopyToDataTable();
            //    //
            //    if (dt1.Rows.Count > 0)
            //    {
            //        foreach (DataRow rw in dt1.Rows)
            //        {
            //            int rowId = dgw1.Rows.Add();
            //            DataGridViewRow row = dgw1.Rows[rowId];
            //            row.Cells["TIPO_VTA"].Value = rw["TIPO_VTA"].ToString();
            //            row.Cells["COD_PROGRAMA"].Value = rw["COD_PROGRAMA"].ToString();
            //            row.Cells["COD_VENDEDOR"].Value = rw["COD_VENDEDOR"].ToString();
            //            row.Cells["DESC_PER"].Value = rw["DESC_PER"].ToString();
            //            row.Cells["NRO_CONTRATO"].Value = rw["NRO_CONTRATO"].ToString();
            //            row.Cells["FE_CONTRATO"].Value = rw["FE_CONTRATO"].ToString().Substring(0, 10);
            //            row.Cells["FE_AÑO"].Value = rw["FE_AÑO"].ToString();
            //            row.Cells["FE_MES"].Value = rw["FE_MES"].ToString();
            //            row.Cells["COD_PER"].Value = rw["COD_PER"].ToString();
            //            row.Cells["NOMCLI"].Value = rw["NOMCLI"].ToString();
            //            row.Cells["NRO_LETRA"].Value = rw["NRO_LETRA"].ToString();
            //            //row.Cells["STATUS_PRE_APROB"].Value = rw["STATUS_PRE_APROB"].ToString() == "0" ? "A" : "P";//Aprobado y Pre-Aprobado
            //        }
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("No se encontraron registros !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //}
            //dgw1.Select();
        }

        private void dgw1_SelectionChanged(object sender, EventArgs e)
        {
            //if (dgw1.CurrentRow.Cells["NRO_CONTRATO"].Value != null)
            //{
            //    llenaDetalle();
            //}
        }
        private void dgw1_Click(object sender, EventArgs e)
        {
            //llenaDetalle();
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

    }
}
