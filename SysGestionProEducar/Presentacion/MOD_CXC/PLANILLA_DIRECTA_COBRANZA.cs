using BLL;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;

namespace Presentacion.MOD_CXC
{
    public partial class PLANILLA_DIRECTA_COBRANZA : Form
    {
        cobranzaDirectaBLL codBLL = new cobranzaDirectaBLL();
        cobranzaDirectaTo codTo = new cobranzaDirectaTo();
        public string COD_USU;
        public PLANILLA_DIRECTA_COBRANZA(string COD_USU)
        {
            InitializeComponent();
            this.COD_USU = COD_USU;
        }

        private void PLANILLA_DIRECTA_COBRANZA_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            DATAGRID();
        }

        private void PLANILLA_DIRECTA_COBRANZA_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        public void DATAGRID()
        {
            codTo.COD_LLAMADA = "01";
            codTo.STATUS_CONFIRMACION = "1";
            DataTable dt = codBLL.obtenerCobranzaDirectaparaCobranzaBLL(codTo);
            if (dt.Rows.Count > 0)
            {
                DGW.DataSource = dt;
                DGW.Columns["NRO_CONTRATO"].HeaderText = "Contrato";
                DGW.Columns["NRO_CONTRATO"].Width = 80;
                DGW.Columns["NRO_CONTRATO"].ReadOnly = true;
                DGW.Columns["COD_PERSONA"].Visible = false;
                DGW.Columns["DESC_PER"].HeaderText = "Cliente";
                DGW.Columns["DESC_PER"].Width = 200;
                DGW.Columns["DESC_PER"].ReadOnly = true;
                DGW.Columns["NRO_DOC"].HeaderText = "Doc";
                DGW.Columns["NRO_DOC"].Width = 60;
                DGW.Columns["NRO_DOC"].ReadOnly = true;
                DGW.Columns["FECHA_CONFIRMADA"].HeaderText = "F Conf";
                DGW.Columns["FECHA_CONFIRMADA"].Width = 70;
                DGW.Columns["FECHA_CONFIRMADA"].DefaultCellStyle.Format = "dd/MM/yyyy";
                DGW.Columns["FECHA_CONFIRMADA"].ReadOnly = true;
                DGW.Columns["IMPORTE_PAGO"].HeaderText = "Importe";
                DGW.Columns["IMPORTE_PAGO"].Width = 70;
                DGW.Columns["IMPORTE_PAGO"].DefaultCellStyle.Format = string.Format("###,###,##0.00");
                DGW.Columns["IMPORTE_PAGO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                DGW.Columns["IMPORTE_PAGO"].ReadOnly = true;
                DGW.Columns["IMPORTE_DEPOSITADO"].HeaderText = "Imp Dptdo";
                DGW.Columns["IMPORTE_DEPOSITADO"].Width = 70;
                DGW.Columns["IMPORTE_DEPOSITADO"].DefaultCellStyle.Format = string.Format("###,###,##0.00");
                DGW.Columns["IMPORTE_DEPOSITADO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                DGW.Columns["IMPORTE_DEPOSITADO"].ReadOnly = true;
                DGW.Columns["NRO_OPERACION"].HeaderText = "N° Operac";
                DGW.Columns["NRO_OPERACION"].Width = 70;
                DGW.Columns["NRO_OPERACION"].ReadOnly = false;
                DGW.Columns["FECHA_OPERACION"].HeaderText = "F Operac";
                DGW.Columns["FECHA_OPERACION"].Width = 70;
                DGW.Columns["FECHA_OPERACION"].ReadOnly = false;
                DGW.Columns["COD_BANCO"].Visible = false;
                DGW.Columns["DESC_BANCO"].HeaderText = "Banco";
                DGW.Columns["DESC_BANCO"].Width = 120;
                DGW.Columns["OBSERVACIONES"].Visible = false;
                TOTALES();
            }
        }
        private void TOTALES()
        {
            decimal sum = 0;
            foreach (DataGridViewRow row in DGW.Rows)
            {
                sum += Convert.ToDecimal(row.Cells["IMPORTE_DEPOSITADO"].Value);
            }
            txt_tot_importe.Text = sum.ToString("###,###,##0.00");
        }
        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
