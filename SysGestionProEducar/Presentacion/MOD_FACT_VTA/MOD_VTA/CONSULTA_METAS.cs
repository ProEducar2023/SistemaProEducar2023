using BLL;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;
namespace Presentacion.MOD_FACT_VTA.MOD_VTA
{
    public partial class CONSULTA_METAS : Form
    {
        string AÑO = "", MES = "", COD_MOD = "", COD_USU = "", TIPO_USU = "";
        DateTime FECHA_INI, FECHA_GRAL;
        HelpersBLL helBLL = new HelpersBLL();
        HelpersTo helTo = new HelpersTo();
        metasBLL mtBLL = new metasBLL();
        metasTo mtTo = new metasTo();
        public CONSULTA_METAS(string AÑO, string MES, DateTime FECHA_INI, DateTime FECHA_GRAL, string COD_MOD, string TIPO_USU, string COD_USU)
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
        private void CONSULTA_METAS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void CONSULTA_METAS_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            CARGAR_MES();
            CARGAR_AÑO();
            CARGAR_SUCURSAL();
            //CARGAR_PERSONAS();
            CARGAR_PROGRAMAS();
            CARGAR_NIVEL();
            TIPO_PLANILLA();
            cboMes.SelectedValue = MES;
            cboAño.SelectedValue = AÑO;
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
        private void CARGAR_MES()
        {
            var months1 = new[] { new { cod = "01", val = "ENERO" }, new { cod = "02", val = "FEBRERO" },
                                new { cod = "03", val = "MARZO" }, new { cod = "04", val = "ABRIL" },
                                new { cod = "05", val = "MAYO" }, new { cod = "06", val = "JUNIO" },
                                new { cod = "07", val = "JULIO" }, new { cod = "08", val = "AGOSTO" },
                                new { cod = "09", val = "SEPTIEMBRE" }, new { cod = "10", val = "OCTUBRE" },
                                new { cod = "11", val = "NOVIEMBRE" }, new { cod = "12", val = "DICIEMBRE" }};

            cboMes.ValueMember = "cod";
            cboMes.DisplayMember = "val";
            cboMes.DataSource = months1;
            cboMes.SelectedIndex = -1;
        }
        private void CARGAR_AÑO()
        {
            periodoBLL perBLL = new periodoBLL();
            periodoTo perTo = new periodoTo();
            //
            cboAño.Items.Clear();
            perTo.COD_MODULO = "VTA";
            DataTable dt = perBLL.obtenerAñoPeriodoBLL(perTo);
            cboAño.ValueMember = "AÑO";
            cboAño.DisplayMember = "AÑO";
            cboAño.DataSource = dt;
        }
        private void CARGAR_SUCURSAL()
        {
            helTo.CODIGO = COD_USU;
            DataTable dt = helBLL.CBO_SUCURSALBLL(helTo);
            cboSucursal.ValueMember = "COD_SUCURSAL";
            cboSucursal.DisplayMember = "DESC_sucursal";
            cboSucursal.DataSource = dt;
            cboSucursal.SelectedIndex = 0;
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
                txt_blanco.Select();
                //VerificaNumeracionContrato();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                //Panel_PER.Visible = false;
                panel_per2.Visible = false;
                txtCodigo.Clear();
                txt_desc2.Clear();
                txtDni.Clear();
                //txt_doc_per.Clear();
                //txt_cod2.Focus();

            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            dgv.Rows.Clear();
            decimal tot = 0;
            DataTable dt;
            if (cbo_nivel.SelectedValue.ToString() == "04")//vendedor
            {
                mtTo.SUCURSAL = cboSucursal.SelectedValue.ToString();
                mtTo.COD_PROGRAMA = cbo_prog.SelectedValue.ToString();
                mtTo.TIPO_PLANILLA = cbo_tipo.SelectedValue.ToString();
                mtTo.FE_MES = cboMes.SelectedValue.ToString();
                mtTo.FE_AÑO = cboAño.SelectedValue.ToString();
                mtTo.COD_PER = txtCodigo.Text;
                dt = mtBLL.obtenerPreventaMetasparaConsultaVendedorBLL(mtTo);

            }
            else
            {
                mtTo.FE_MES = cboMes.SelectedValue.ToString();
                mtTo.FE_AÑO = cboAño.SelectedValue.ToString();
                mtTo.COD_PER = txtCodigo.Text;
                dt = mtBLL.obtenerPreventaMetasparaConsultaBLL(mtTo);
            }
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow rw in dt.Rows)
                {
                    int rowId = dgv.Rows.Add();
                    DataGridViewRow row = dgv.Rows[rowId];
                    row.Cells["codigo"].Value = rw["COD_PER"].ToString();
                    row.Cells["nombre"].Value = rw["NOM_PER"].ToString();
                    row.Cells["monto"].Value = rw["MONTO"].ToString();
                    tot += Convert.ToDecimal(rw["MONTO"]);
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
