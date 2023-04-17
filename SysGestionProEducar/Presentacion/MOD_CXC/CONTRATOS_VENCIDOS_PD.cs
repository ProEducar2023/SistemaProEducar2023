using BLL;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;
namespace Presentacion.MOD_CXC
{
    public partial class CONTRATOS_VENCIDOS_PD : Form
    {
        planillaDirectaBLL pldBLL = new planillaDirectaBLL();
        planillaDirectaTo pldTo = new planillaDirectaTo();
        string COD_USU; DateTime fecha_llamada; DateTime fecha_ven;
        public CONTRATOS_VENCIDOS_PD()
        {
            InitializeComponent();
        }

        private void CONTRATOS_VENCIDOS_PD_Load(object sender, EventArgs e)
        {

        }
        public void MOSTRAR_DATOS(DateTime fec_ini, DateTime fecha_ven, string COD_USU)
        {
            canjePCtasxCobrarBLL pctaBLL = new canjePCtasxCobrarBLL();
            canjePCtasxCobrarTo pctaTo = new canjePCtasxCobrarTo();
            this.COD_USU = COD_USU;
            pctaTo.FECHA_CREA = fec_ini;
            pctaTo.FECHA_VEN = fecha_ven.Date;
            fecha_llamada = fec_ini;
            this.fecha_ven = fec_ini;
            DataTable dt = pctaBLL.obtener_PCtasCobrar_por_Fecha_Ven_BLL(pctaTo);
            if (dt.Rows.Count > 0)
            {
                DGW.Rows.Clear();
                //DGW.Refresh();
                //LimpiarGrid();
                foreach (DataRow rw in dt.Rows)
                {
                    int rowId = DGW.Rows.Add();
                    DataGridViewRow row = DGW.Rows[rowId];
                    row.Cells["NRO_CONTRATO"].Value = rw["NRO_CONTRATO"].ToString();
                    row.Cells["DESC_PER"].Value = rw["DESC_PER"].ToString();
                    row.Cells["FECHA_CONTRATO"].Value = rw["FECHA_CONTRATO"].ToString();
                    row.Cells["FECHA_VEN"].Value = rw["FECHA_VEN"].ToString();
                    row.Cells["NRO_DOC"].Value = rw["NRO_DOC"].ToString().Trim();
                    row.Cells["LETRA"].Value = rw["LETRA"].ToString();
                    row.Cells["IMP_INI"].Value = rw["IMP_INI"].ToString();
                    row.Cells["COD_SECTORISTA"].Value = rw["COD_SECTORISTA"].ToString();
                    row.Cells["COD_PER"].Value = rw["COD_PER"].ToString();
                }
            }
            lbl_venc.Text = "Contratos vencidos al dia : " + fecha_ven.ToShortDateString();
        }
        private void LimpiarGrid()
        {
            if (DGW.Rows.Count > 1)
            {
                for (int i = DGW.Rows.Count - 2; i >= 0; i--)
                {
                    DGW.Rows.RemoveAt(i);
                }
            }
        }
        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("¿ Esta seguro de lo que va a hacer ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                pldTo.FECHA_LLAMADA = fecha_llamada;//es la fecha de llamada
                pldTo.FECHA_VEN = fecha_ven;
                pldTo.COD_CREACION = COD_USU;
                pldTo.FECHA_CREACION = DateTime.Now;
                DataTable dtDetalle = obtenerDT();
                if (!pldBLL.crearPlanillaDirectaContratosporVencerBLL(pldTo, dtDetalle, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    this.Close();
                }
            }
        }

        private DataTable obtenerDT()
        {
            DataTable table = new DataTable();
            foreach (DataGridViewColumn column in DGW.Columns)
            {
                table.Columns.Add(column.Name, typeof(string));
            }
            foreach (DataGridViewRow row in DGW.Rows)
            {
                if (Convert.ToBoolean(row.Cells["ok"].Value))
                {
                    DataRow dataRow = table.NewRow();
                    for (int i = 0; i < table.Columns.Count; i++)
                    {
                        dataRow[i] = row.Cells[i].Value != null ? row.Cells[i].Value : DBNull.Value;
                    }
                    table.Rows.Add(dataRow);
                }
            }
            return table;
        }
        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
