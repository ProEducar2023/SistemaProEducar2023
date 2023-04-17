using BLL;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;

namespace Presentacion.DIALOGOS
{
    public partial class CONSULTA_PARA_GENERACION_PLANILLA_COB : Form
    {
        string COD_PTO_COB; //string COD_SECTORISTA; string COD_CANAL_DCTO; string TIPO_PLLA;
        DateTime FECHA_PLANILLA;
        DataTable dtPersona;
        HelpersBLL helBLL = new HelpersBLL();
        HelpersTo helTo = new HelpersTo();
        public CONSULTA_PARA_GENERACION_PLANILLA_COB(string COD_PTO_COB, DateTime FECHA_PLANILLA)
        {
            InitializeComponent();
            this.COD_PTO_COB = COD_PTO_COB;
            this.FECHA_PLANILLA = FECHA_PLANILLA;
            //this.COD_SECTORISTA = COD_SECTORISTA;
            //this.COD_CANAL_DSCTO = COD_CANAL_DSCTO;
            //this.TIPO_PLLA = TIPO_PLLA;
        }

        private void CONSULTA_PARA_GENERACION_PLANILLA_COB_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            CARGAR_PERSONAS();

        }
        private void CARGAR_PERSONAS()
        {
            dgw_per.Rows.Clear();
            helTo.CODIGO = COD_PTO_COB;
            //helTo.CODIGO2 = COD_SECTORISTA;
            //helTo.CODIGO3 = COD_CANAL_DSCTO;
            //helTo.CODIGO4 = TIPO_PLLA;
            dtPersona = helBLL.MOSTRAR_PERSONAS_X_AUMENTAR_CUOTA_BLL(helTo);
            if (dtPersona.Rows.Count > 0)
            {
                foreach (DataRow rw in dtPersona.Rows)
                {
                    int rowId = dgw_per.Rows.Add();
                    DataGridViewRow row = dgw_per.Rows[rowId];
                    row.Cells["COD_PER"].Value = rw["COD_PER"].ToString();
                    row.Cells["DESC_PER"].Value = rw["DESC_PER"].ToString();
                    row.Cells["NRO_DOC"].Value = rw["NRO_DOC"].ToString();
                    row.Cells["NRO_PRESUPUESTO"].Value = rw["NRO_PRESUPUESTO"].ToString();
                    row.Cells["COD_SUCURSAL"].Value = rw["COD_SUCURSAL"].ToString();
                    row.Cells["COD_INSTITUCION"].Value = rw["COD_INSTITUCION"].ToString();
                    row.Cells["COD_CANAL_DSCTO"].Value = rw["COD_CANAL_DSCTO"].ToString();
                }
            }
        }
        private void CONSULTA_PARA_GENERACION_PLANILLA_COB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void TXT_COD_Leave(object sender, EventArgs e)
        {
            if (TXT_COD.Text.Trim() != "")
            {
                if (dgw_per.Rows.Count > 0)
                {
                    dgw_per.Sort(dgw_per.Columns[0], System.ComponentModel.ListSortDirection.Ascending);
                    int i = 0, num2 = 0;
                    num2 = dgw_per.Rows.Count - 1;
                    do
                    {
                        if (TXT_COD.Text.ToLower() == dgw_per[0, i].Value.ToString().ToLower())
                        {
                            TXT_COD.Text = dgw_per[0, i].Value.ToString();
                            TXT_DESC.Text = dgw_per[1, i].Value.ToString();
                            txt_doc_per.Text = dgw_per[2, i].Value.ToString();
                            txt_contrato.Text = dgw_per.Rows[i].Cells["NRO_PRESUPUESTO"].Value.ToString();
                            txt_contrato.Focus();
                            return;
                        }
                        if (TXT_COD.Text.ToLower() == dgw_per[0, i].Value.ToString().ToLower().Substring(0, TXT_COD.TextLength))
                        {
                            dgw_per.CurrentCell = dgw_per.Rows[i].Cells[0];
                            break;
                        }
                        dgw_per.CurrentCell = dgw_per.Rows[0].Cells[0];
                        i += 1;
                    }
                    while (i <= num2);
                    Panel_PER.BringToFront();
                    Panel_PER.Visible = true;
                    dgw_per.Visible = true;
                    dgw_per.Focus();
                }
            }
        }
        private void TXT_DESC_Leave(object sender, EventArgs e)
        {
            if (TXT_DESC.Text == "")
            {
                txt_doc_per.Focus();
            }
            else
            {
                if (dgw_per.Rows.Count > 0)
                {
                    dgw_per.Sort(dgw_per.Columns[1], System.ComponentModel.ListSortDirection.Ascending);
                    int i = 0, num2 = 0;
                    num2 = dgw_per.Rows.Count;
                    do
                    {
                        if (dgw_per[1, i].Value.ToString().Length >= TXT_DESC.TextLength)
                        {
                            if (TXT_DESC.Text.ToLower() == dgw_per[1, i].Value.ToString().ToLower().Substring(0, TXT_DESC.TextLength).ToLower())
                            {
                                dgw_per.CurrentCell = dgw_per.Rows[i].Cells[0];
                                break;
                            }
                        }
                        dgw_per.CurrentCell = dgw_per.Rows[0].Cells[0];
                        i += 1;
                    }
                    while (i < num2);
                    Panel_PER.Visible = true;
                    dgw_per.Visible = true;
                    dgw_per.Focus();
                }
            }
        }
        private void txt_doc_per_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_doc_per.Text.Trim() == "")
                {
                    Panel_PER.Visible = false;
                }//Gestion Comercial/compras/servicio/requiriento de servicio
                else if (dgw_per.Rows.Count > 0)
                {
                    DataRow[] rs = dtPersona.Select("NRO_DOC = '" + txt_doc_per.Text.Trim() + "'");
                    if (rs.Length > 0)
                    {
                        dgw_per.Sort(dgw_per.Columns[2], System.ComponentModel.ListSortDirection.Ascending);
                        int i = 0, num2 = 0;
                        num2 = dgw_per.Rows.Count;
                        do
                        {
                            if (dgw_per[2, i].Value.ToString().Length >= txt_doc_per.TextLength)
                            {
                                if (txt_doc_per.Text.ToLower() == dgw_per[2, i].Value.ToString().ToLower().Substring(0, txt_doc_per.TextLength).ToLower())
                                {
                                    dgw_per.CurrentCell = dgw_per.Rows[i].Cells[0];
                                    break;
                                }
                            }
                            dgw_per.CurrentCell = dgw_per.Rows[0].Cells[0];
                            i += 1;
                        }
                        while (i < num2);
                        Panel_PER.Visible = true;
                        dgw_per.Visible = true;
                        dgw_per.Focus();
                    }
                    else
                    {
                        Panel_PER.Visible = false;
                    }
                }
            }
        }
        private void dgw_per_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int idx = dgw_per.CurrentRow.Index;
                TXT_COD.Text = dgw_per[0, idx].Value.ToString();
                TXT_DESC.Text = dgw_per[1, idx].Value.ToString();
                txt_doc_per.Text = dgw_per[2, idx].Value.ToString();
                txt_contrato.Text = dgw_per[3, idx].Value.ToString();
                MOSTRAR_DATOS_GRID();
                Panel_PER.Visible = false;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Panel_PER.Visible = false;
                TXT_COD.Focus();
                TXT_COD.Clear();
                TXT_DESC.Clear();
                txt_doc_per.Clear();
                txt_contrato.Clear();
            }
        }
        private void MOSTRAR_DATOS_GRID()
        {
            DGW_CAB.Rows.Clear();
            string errMensaje = "";
            canjePCtasxCobrarBLL pctaBLL = new canjePCtasxCobrarBLL();
            canjePCtasxCobrarTo pctaTo = new canjePCtasxCobrarTo();
            contratosSuspendidosBLL csBLL = new contratosSuspendidosBLL();
            contratosSuspendidosTo csTo = new contratosSuspendidosTo();
            csTo.NRO_CONTRATO = txt_contrato.Text;
            csTo.FECHA_SUSPENSION = FECHA_PLANILLA;
            if (csBLL.verificaExistenciaContratoSuspendidoBLL(csTo, ref errMensaje))
            {
                MessageBox.Show("Contrato Suspendido para este periodo !!!");
                return;
            }
            pctaTo.NRO_CONTRATO = txt_contrato.Text;
            DataTable dt = pctaBLL.obtener_PCtasCobrar_por_CodPerBLL(pctaTo);

            foreach (DataRow rw in dt.Rows)
            {
                int idx = DGW_CAB.Rows.Add();
                DataGridViewRow row = DGW_CAB.Rows[idx];
                row.Cells["NRO_CONTRATO"].Value = rw["NRO_CONTRATO"].ToString();
                row.Cells["COD_DOC"].Value = rw["COD_DOC"].ToString();
                row.Cells["NRO_DOCU"].Value = rw["NRO_DOCU"].ToString();
                row.Cells["FECHA_VEN"].Value = rw["FECHA_VEN"].ToString().Substring(0, 10);
                row.Cells["IMP_DOC"].Value = rw["IMP_DOC"].ToString();
                row.Cells["NRO_LETRA"].Value = rw["NRO_LETRA"].ToString();
                row.Cells["TOTAL_LETRA"].Value = rw["TOTAL_LETRA"].ToString();
                row.Cells["OK"].Value = true;//antes era false y sin break
                row.Cells["COD_PTO_COB2"].Value = rw["COD_PTO_COB"].ToString();
                row.Cells["COD_PER2"].Value = rw["COD_PER"].ToString();
                row.Cells["DES_IDENTIDAD"].Value = rw["DES_IDENTIDAD"].ToString();
                row.Cells["DES_PROCESO"].Value = rw["DES_PROCESO"].ToString();
                row.Cells["DESC_PER2"].Value = rw["DESC_PER"].ToString();
                row.Cells["DNI"].Value = rw["DNI"].ToString();
                row.Cells["IMP_INI"].Value = rw["IMP_INI"].ToString();
                row.Cells["DESC_PTO_COB"].Value = rw["DESC_PTO_COB"].ToString();
                row.Cells["COD_SUB_PTO_VEN"].Value = rw["COD_SUB_PTO_VEN"].ToString();
                row.Cells["DESC_PTO_VEN"].Value = rw["DESC_PTO_VEN"].ToString();
                row.Cells["OBSERVACION"].Value = rw["OBSERVACION"].ToString();
                break;
            }
        }
        private void CONSULTA_PARA_GENERACION_PLANILLA_COB_Shown(object sender, EventArgs e)
        {
            TXT_COD.Focus();
        }

        private void OK_Button_Click(object sender, EventArgs e)
        {
            if (validaExistenciadeRegistro())
            {
                MessageBox.Show("Debe elejir alguna cuota !!!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            DialogResult = MessageBox.Show("¿ Estas seguro de adelantar un contrato ?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
        private bool validaExistenciadeRegistro()
        {
            bool result = true;
            foreach (DataGridViewRow row in DGW_CAB.Rows)
            {
                if (Convert.ToBoolean(row.Cells["OK"].Value))
                    return result = false;
            }

            return result;
        }
    }
}
