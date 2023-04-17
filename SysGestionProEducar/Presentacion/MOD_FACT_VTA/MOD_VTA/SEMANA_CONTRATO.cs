using BLL;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;
namespace Presentacion.MOD_VTA
{
    public partial class SEMANA_CONTRATO : Form
    {
        string boton; DataTable dtSeco;
        DataTable dtSemana = new DataTable();
        semanaContratoBLL scBLL = new semanaContratoBLL();
        semanaContratoTo scTo = new semanaContratoTo();
        public SEMANA_CONTRATO()
        {
            InitializeComponent();
        }

        private void SEMANA_CONTRATO_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            llenacomboMes();
            llenacomboAnnio();
            llenaSemanaContrato();
            dtSeco = scBLL.obtenerSemanaContratoBLL();
            cargaDataGrid();
            btn_nuevo.Select();
        }
        private void cargaDataGrid()
        {
            if (dtSeco.Rows.Count > 0)
            {
                dgw1.Rows.Clear();
                //DataRow[] r;
                foreach (DataRow rw in dtSeco.Rows)
                {
                    int rowId = dgw1.Rows.Add();
                    DataGridViewRow row = dgw1.Rows[rowId];
                    row.Cells[0].Value = rw["MES"].ToString();
                    row.Cells[1].Value = rw["FE_MES"].ToString();
                    row.Cells[2].Value = rw["FE_AÑO"].ToString();
                    row.Cells[3].Value = rw["NRO_SEMANA"].ToString();
                    row.Cells[4].Value = rw["NOM_SEMANA"].ToString();
                    row.Cells[5].Value = rw["FE_DEL"].ToString();
                    row.Cells[6].Value = rw["FE_AL"].ToString();
                    row.Cells["nro_repo"].Value = rw["NRO_REPORTE"].ToString();
                    row.Cells["sem_con"].Value = obtenerSemana(rw["NRO_SEMANA"].ToString());
                }
            }
        }
        private string obtenerSemana(string nro)
        {
            string val = "";
            DataRow[] r = dtSemana.Select("cod = '" + nro + "'");
            foreach (DataRow s in r)
                val = s["nom"].ToString();
            return val;
        }
        private void llenaSemanaContrato()
        {
            dtSemana.Columns.Add("cod", typeof(string));
            dtSemana.Columns.Add("nom", typeof(string));
            DataRow rw = dtSemana.NewRow();
            rw["cod"] = "01";
            rw["nom"] = "1ERA SEMANA";
            dtSemana.Rows.Add(rw);
            DataRow rw1 = dtSemana.NewRow();
            rw1["cod"] = "02";
            rw1["nom"] = "2DA SEMANA";
            dtSemana.Rows.Add(rw1);
            DataRow rw2 = dtSemana.NewRow();
            rw2["cod"] = "03";
            rw2["nom"] = "3ERA SEMANA";
            dtSemana.Rows.Add(rw2);
            DataRow rw3 = dtSemana.NewRow();
            rw3["cod"] = "04";
            rw3["nom"] = "4TA SEMANA";
            dtSemana.Rows.Add(rw3);
            DataRow rw4 = dtSemana.NewRow();
            rw4["cod"] = "05";
            rw4["nom"] = "5TA SEMANA";
            dtSemana.Rows.Add(rw4);

            cbo_semana.ValueMember = "cod";
            cbo_semana.DisplayMember = "nom";
            cbo_semana.DataSource = dtSemana;
        }
        private void llenacomboMes()
        {
            DataTable dtmes = new DataTable();
            dtmes.Columns.Add("cod", typeof(string));
            dtmes.Columns.Add("nom", typeof(string));

            for (int i = 1; i <= 12; i++)
            {
                DataRow rw = dtmes.NewRow();
                rw["cod"] = HelpersBLL.OBTIENE_CODIGO(2, i.ToString());
                rw["nom"] = obtMes(i);
                dtmes.Rows.Add(rw);
            }

            cbomes.ValueMember = "cod";
            cbomes.DisplayMember = "nom";
            cbomes.DataSource = dtmes;
        }
        private string obtMes(int m)
        {
            string mes = "";
            switch (m)
            {
                case 1: mes = "ENERO"; break;
                case 2: mes = "FEBRERO"; break;
                case 3: mes = "MARZO"; break;
                case 4: mes = "ABRIL"; break;
                case 5: mes = "MAYO"; break;
                case 6: mes = "JUNIO"; break;
                case 7: mes = "JULIO"; break;
                case 8: mes = "AGOSTO"; break;
                case 9: mes = "SEPTIEMBRE"; break;
                case 10: mes = "OCTUBRE"; break;
                case 11: mes = "NOVIEMBRE"; break;
                case 12: mes = "DICIEMBRE"; break;
            }
            return mes;
        }
        private void llenacomboAnnio()
        {
            int anio = DateTime.Now.Year;
            DataTable dtannio = new DataTable();
            dtannio.Columns.Add("cod", typeof(int));
            dtannio.Columns.Add("nom", typeof(string));

            for (int i = anio; i >= anio - 2; i--)
            {
                DataRow rw = dtannio.NewRow();
                rw["cod"] = i;
                rw["nom"] = i;
                dtannio.Rows.Add(rw);

            }
            cboannio.ValueMember = "cod";
            cboannio.DisplayMember = "nom";
            cboannio.DataSource = dtannio;
        }
        private void SEMANA_CONTRATO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void LIMPIAR()
        {
            cbomes.SelectedIndex = -1;
            cboannio.SelectedIndex = -1;
            cbo_semana.SelectedIndex = -1;
            txt_nro_repo.Text = "";
            dtp_del.Value = DateTime.Now;
            dtp_al.Value = DateTime.Now;
            grvDatos.Enabled = true;
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            boton = "NUEVO";
            btn_guardar.Visible = true;
            btn_modificar2.Visible = false;
            LIMPIAR();
            cbomes.SelectedValue = DateTime.Now.ToString("MM");
            cboannio.SelectedValue = DateTime.Now.ToString("yyyy");
            //txt_cod.Text = dgw1.Rows.Count == 0 ? "01" : obtieneCodigo(Convert.ToInt32(dgw1.Rows[dgw1.Rows.Count - 1].Cells["cod"].Value));
            TabControl1.SelectedTab = TabPage2;
            cbomes.Focus();
        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            int i = dgw1.CurrentRow.Index;
            boton = "MODIFICAR";
            btn_guardar.Visible = false;
            btn_modificar2.Visible = true;
            LIMPIAR();
            CargarDatos();
            TabControl1.SelectedTab = TabPage2;
            cbomes.Focus();
        }
        private void CargarDatos()
        {
            int idx = dgw1.CurrentRow.Index;
            cbomes.SelectedValue = dgw1[1, idx].Value;
            cboannio.SelectedValue = dgw1[2, idx].Value;
            cbo_semana.SelectedValue = dgw1[3, idx].Value;
            dtp_del.Value = Convert.ToDateTime(dgw1[5, idx].Value);
            dtp_al.Value = Convert.ToDateTime(dgw1[6, idx].Value);
            txt_nro_repo.Text = dgw1.Rows[idx].Cells["nro_repo"].Value.ToString();
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (!valida())
                return;
            DialogResult rs = MessageBox.Show("¿ Esta seguro de adicionar una nueva Semana ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                scTo.FE_MES = HelpersBLL.OBTIENE_CODIGO(2, cbomes.SelectedValue.ToString());
                scTo.FE_AÑO = cboannio.Text;
                scTo.NRO_SEMANA = cbo_semana.SelectedValue.ToString();
                //scTo.NOM_SEMANA = cbo_semana.Text;
                scTo.NOM_SEMANA = lblsemana.Text;
                scTo.FE_DEL = dtp_del.Value;
                scTo.FE_AL = dtp_al.Value;
                scTo.NRO_REPORTE = txt_nro_repo.Text;
                if (!scBLL.insertarSemanaContratoBLL(scTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Se adicionó correctamente la Semana !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgw1.Rows.Add(cbomes.Text + " " + cboannio.Text, cbomes.SelectedValue.ToString(), cboannio.Text, cbo_semana.SelectedValue.ToString(), lblsemana.Text,
                        dtp_del.Value.ToShortDateString(), dtp_al.Value.ToShortDateString(), obtenerSemana(cbo_semana.SelectedValue.ToString()), txt_nro_repo.Text);
                    TabControl1.SelectedTab = TabPage1;
                    btn_nuevo.Select();
                }
            }
        }
        private bool valida()
        {
            bool result = true;
            if (cbomes.SelectedIndex < 0)
            {
                MessageBox.Show("Elija el mes !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbomes.Focus();
                return result = false;
            }
            if (cboannio.SelectedIndex < 0)
            {
                MessageBox.Show("Elija el año !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboannio.Focus();
                return result = false;
            }
            if (cbo_semana.SelectedIndex < 0)
            {
                MessageBox.Show("Elija la semana !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_semana.Focus();
                return result = false;
            }
            //if (txt_nro_repo.Text == "")
            //{
            //    MessageBox.Show("Ingrese el Nro de Reporte de esta semana !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    txt_nro_repo.Focus();
            //    return result = false;
            //}
            if (dtp_del.Value >= dtp_al.Value)
            {
                MessageBox.Show("Fecha Al debe ser mayor a Fecha De !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtp_al.Focus();
                return result = false;
            }
            if (btn_guardar.Visible == true)
            {
                foreach (DataGridViewRow row in dgw1.Rows)
                {
                    if (row.Cells[1].Value.ToString() == cbomes.SelectedValue.ToString() && row.Cells[2].Value.ToString() == cboannio.SelectedValue.ToString() &&
                        row.Cells[3].Value.ToString() == cbo_semana.SelectedValue.ToString())
                    {
                        MessageBox.Show("Ya existe el mes, el año y la semana !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        cbomes.Focus();
                        return result = false;
                    }
                }
            }
            if (cbomes.SelectedValue.ToString() != dtp_del.Value.Month.ToString().PadLeft(2, '0'))
            {
                MessageBox.Show("El Mes no corresponde con la fecha elegida !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtp_del.Focus();
                return result = false;
            }
            if (cbomes.SelectedValue.ToString() != dtp_al.Value.Month.ToString().PadLeft(2, '0'))
            {
                MessageBox.Show("El Mes no corresponde con la fecha elegida !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtp_al.Focus();
                return result = false;
            }
            return result;
        }

        private void btn_modificar2_Click(object sender, EventArgs e)
        {
            if (!valida())
                return;
            DialogResult rs = MessageBox.Show("¿ Esta seguro de modificar la semana ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                scTo.FE_MES = HelpersBLL.OBTIENE_CODIGO(2, cbomes.SelectedValue.ToString());
                scTo.FE_AÑO = cboannio.Text;
                scTo.NRO_SEMANA = cbo_semana.SelectedValue.ToString();
                //scTo.NOM_SEMANA = cbo_semana.Text;
                scTo.NOM_SEMANA = lblsemana.Text;
                scTo.FE_DEL = dtp_del.Value;
                scTo.FE_AL = dtp_al.Value;
                scTo.NRO_REPORTE = txt_nro_repo.Text;
                if (!scBLL.modificarSemanaContratoBLL(scTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Se modificó correctamente la semana !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //
                    dgw1.CurrentRow.Cells[0].Value = cbomes.Text + " " + cboannio.Text;
                    dgw1.CurrentRow.Cells[1].Value = cbomes.SelectedValue.ToString();
                    dgw1.CurrentRow.Cells[2].Value = cboannio.Text;
                    dgw1.CurrentRow.Cells[3].Value = cbo_semana.SelectedValue.ToString();
                    dgw1.CurrentRow.Cells[4].Value = lblsemana.Text;
                    dgw1.CurrentRow.Cells[5].Value = dtp_del.Value.ToShortDateString();
                    dgw1.CurrentRow.Cells[6].Value = dtp_al.Value.ToShortDateString();
                    dgw1.CurrentRow.Cells["sem_con"].Value = obtenerSemana(cbo_semana.SelectedValue.ToString());
                    dgw1.CurrentRow.Cells["nro_repo"].Value = txt_nro_repo.Text;
                    TabControl1.SelectedTab = TabPage1;
                    btn_nuevo.Select();
                }
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            TabControl1.SelectedTab = TabPage1;
            btn_nuevo.Select();
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("¿ Esta seguro de eliminar la semana ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                scTo.FE_MES = HelpersBLL.OBTIENE_CODIGO(2, dgw1[1, dgw1.CurrentRow.Index].Value.ToString());
                scTo.FE_AÑO = dgw1[2, dgw1.CurrentRow.Index].Value.ToString();
                scTo.NRO_SEMANA = dgw1[3, dgw1.CurrentRow.Index].Value.ToString();

                if (!scBLL.eliminarSemanaContratoBLL(scTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Sel eliminó correctamene la semana !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //
                    dgw1.Rows.RemoveAt(dgw1.CurrentRow.Index);
                }
            }
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dtp_al_ValueChanged(object sender, EventArgs e)
        {
            lblsemana.Text = "Del " + dtp_del.Value.ToShortDateString() + " al " + dtp_al.Value.ToShortDateString();
        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TabControl1.SelectedTab == TabPage2)
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
                    LIMPIAR();
                    if (dgw1.Rows.Count == 0)
                    {
                    }
                    else
                        CargarDatos();

                    grvDatos.Enabled = false;
                    btn_guardar.Visible = false;
                    btn_modificar2.Visible = false;
                }
            }
            else
                btn_nuevo.Select();
        }

        private void cbomes_SelectedIndexChanged(object sender, EventArgs e)
        {
            estableFecha();
        }
        private void estableFecha()
        {
            if (cbomes.SelectedValue != null && cboannio.SelectedValue != null)
            {
                dtp_del.Value = Convert.ToDateTime("01/" + cbomes.SelectedValue.ToString().PadLeft(2, '0') + "/" + cboannio.SelectedValue.ToString());
                dtp_al.Value = Convert.ToDateTime("01/" + cbomes.SelectedValue.ToString().PadLeft(2, '0') + "/" + cboannio.SelectedValue.ToString());
            }
        }

        private void cboannio_SelectedIndexChanged(object sender, EventArgs e)
        {
            estableFecha();
        }
    }
}
