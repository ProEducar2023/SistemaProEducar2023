using BLL;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;

namespace Presentacion.MOD_COMISIONES
{
    public partial class CONSULTA_MAESTRO_COMISIONES : Form
    {
        comisionesDetalleBLL codBLL = new comisionesDetalleBLL();
        comisionesDetalleTo codTo = new comisionesDetalleTo();
        public CONSULTA_MAESTRO_COMISIONES()
        {
            InitializeComponent();
        }

        private void CONSULTA_MAESTRO_COMISIONES_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            //CARGAR_PERSONAS();
            CARGAR_PROGRAMAS();
            CARGAR_NIVEL();
            TIPO_PLANILLA();
        }
        private void CONSULTA_MAESTRO_COMISIONES_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void CARGAR_NIVEL()
        {
            nivelBLL niBLL = new nivelBLL();
            DataTable dt = niBLL.obtenerNivelBLL();
            cbo_nivel.ValueMember = "COD_NIVEL";
            cbo_nivel.DisplayMember = "DESC_NIVEL";
            cbo_nivel.DataSource = dt;
            cbo_nivel.SelectedIndex = 0;
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
        private void CARGAR_PERSONAS()
        {
            progNivelBLL prnBLL = new progNivelBLL();
            progNivelTo prnTo = new progNivelTo();
            prnTo.COD_NIVEL = cbo_nivel.SelectedValue.ToString();
            DataTable dt = prnBLL.obtenerPersonasParaConsultaMetasBLL(prnTo);
            dgw_per2.DataSource = dt;
            dgw_per2.Columns[0].Width = 55;
            dgw_per2.Columns[1].Width = 240;
            dgw_per2.Columns[2].Width = 70;
            dgw_per2.Columns[3].Visible = false;
            dgw_per2.Columns[4].Visible = false;
        }

        private void cbo_nivel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_nivel.SelectedValue != null)
                CARGAR_PERSONAS();
        }

        private void txtCodigo_Leave(object sender, EventArgs e)
        {
            if (txtCodigo.Text.Trim() != "")
            {
                if (dgw_per2.Rows.Count > 0)
                {
                    dgw_per2.Sort(dgw_per2.Columns[0], System.ComponentModel.ListSortDirection.Ascending);
                    int i = 0, num2 = 0;
                    num2 = dgw_per2.Rows.Count - 1;
                    do
                    {
                        if (txtCodigo.Text.ToLower() == dgw_per2[0, i].Value.ToString().ToLower())
                        {
                            txtCodigo.Text = dgw_per2[0, i].Value.ToString();
                            txt_desc2.Text = dgw_per2[1, i].Value.ToString();
                            txtDni.Text = dgw_per2[2, i].Value.ToString();
                            return;
                        }
                        if (txtCodigo.Text.ToLower() == dgw_per2[0, i].Value.ToString().ToLower().Substring(0, txtCodigo.TextLength))
                        {
                            dgw_per2.CurrentCell = dgw_per2.Rows[i].Cells[0];
                            break;
                        }
                        dgw_per2.CurrentCell = dgw_per2.Rows[0].Cells[0];
                        i += 1;
                    }
                    while (i <= num2);
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
                txtCodigo.Focus();
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
                txtCodigo.Text = dgw_per2[0, idx].Value.ToString();
                txt_desc2.Text = dgw_per2[1, idx].Value.ToString();
                txtDni.Text = dgw_per2[2, idx].Value.ToString();
                panel_per2.Visible = false;
                //btnConsultar.Select();
                gbGeneral.Focus();
                //VerificaNumeracionContrato();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                //Panel_PER.Visible = false;
                panel_per2.Visible = false;
                txtCodigo.Clear();
                txt_desc2.Clear();
                //txt_doc_per.Clear();
                //txt_cod2.Focus();

            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            dgv.Rows.Clear();
            decimal tot = 0;
            DataTable dt;
            //if (cbo_nivel.SelectedValue.ToString() == "04")
            //{
            //    mtTo.SUCURSAL = cboSucursal.SelectedValue.ToString();
            //    mtTo.COD_PROGRAMA = cbo_prog.SelectedValue.ToString();
            //    mtTo.TIPO_PLANILLA = cbo_tipo.SelectedValue.ToString();
            //    mtTo.FE_MES = cboMes.SelectedValue.ToString();
            //    mtTo.FE_AÑO = cboAño.SelectedValue.ToString();
            //    mtTo.COD_PER = txtCodigo.Text;
            //    dt = mtBLL.obtenerPreventaMetasparaConsultaVendedorBLL(mtTo);

            //}
            //else
            //{
            //    mtTo.COD_PER = txtCodigo.Text;
            //    dt = mtBLL.obtenerPreventaMetasparaConsultaBLL(mtTo);

            //}
            codTo.TIPO = cbo_tipo.SelectedValue.ToString();
            codTo.COD_PROGRAMA = cbo_prog.SelectedValue.ToString();
            codTo.COD_PER = txtCodigo.Text;
            dt = codBLL.mostrarMaestroDetalleBLL(codTo);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow rw in dt.Rows)
                {
                    int rowId = dgv.Rows.Add();
                    DataGridViewRow row = dgv.Rows[rowId];
                    row.Cells["tipo"].Value = rw["TIPO"].ToString();
                    row.Cells["cod_programa"].Value = rw["COD_PROGRAMA"].ToString();
                    row.Cells["cod_per"].Value = rw["COD_PER_SUP"].ToString();
                    row.Cells["nombre"].Value = rw["NOM_PER_SUP"].ToString();
                    row.Cells["cod_nivel"].Value = rw["COD_NIVEL"].ToString();
                    row.Cells["nom_nivel"].Value = rw["NOM_NIVEL"].ToString();
                    row.Cells["monto"].Value = rw["IMPORTE"].ToString();
                    row.Cells["cuota"].Value = rw["CUOTA"].ToString();
                    tot += Convert.ToDecimal(rw["IMPORTE"]);
                }
            }
            txt_monto.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(tot.ToString());
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }


    }
}
