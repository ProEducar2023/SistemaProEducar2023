using BLL;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;

namespace Presentacion.CONSULTAS
{
    public partial class CONSULTA_FACT : Form
    {
        public string COD_DOC, COD_PER, COD_SUC, NRO_DOC;
        public string codClase = "";
        string AÑO; string MES;
        Form FormPadre = new Form();
        facturacionVtaCabeceraBLL fvcBLL = new facturacionVtaCabeceraBLL();
        facturacionVtaCabeceraTo fvcTo = new facturacionVtaCabeceraTo();
        public Form _FormPadre
        {
            get { return FormPadre; }
            set { FormPadre = value; }
        }
        public CONSULTA_FACT(string AÑO, string MES)
        {
            InitializeComponent();
            this.AÑO = AÑO;
            this.MES = MES;
        }
        public void CARGAR_FACTURACION()
        {
            DGW_CAB.Rows.Clear();
            fvcTo.COD_SUCURSAL = COD_SUC;
            fvcTo.FE_AÑO = AÑO;
            fvcTo.FE_MES = MES;
            fvcTo.COD_DOC = COD_DOC;
            fvcTo.COD_PER = COD_PER;
            fvcTo.NRO_DOC = NRO_DOC;
            DataTable dt = fvcBLL.obtenerFacturacionparaNotaCreditoBLL(fvcTo);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow rw in dt.Rows)
                {
                    int rowId = DGW_CAB.Rows.Add();
                    DataGridViewRow row = DGW_CAB.Rows[rowId];
                    row.Cells["NRO_DOC1"].Value = rw["NRO_DOC"].ToString();
                    row.Cells["FECHA_DOC1"].Value = rw["FECHA_DOC"].ToString();
                    row.Cells["FECHA_VEN1"].Value = rw["FECHA_VEN"].ToString();
                    row.Cells["IMPORTE1"].Value = rw["IMPORTE"].ToString();
                    row.Cells["COD_MONEDA1"].Value = rw["COD_MONEDA"].ToString();
                    row.Cells["Desc_moneda1"].Value = rw["Desc_moneda"].ToString();
                    row.Cells["TIPO_CAMBIO1"].Value = rw["TIPO_CAMBIO"].ToString();
                    row.Cells["OBSERVACION1"].Value = rw["OBSERVACION"].ToString();
                    row.Cells["FE_AÑO1"].Value = rw["FE_AÑO"].ToString();
                    row.Cells["FE_MES1"].Value = rw["FE_MES"].ToString();
                    row.Cells["COD_DOC1"].Value = rw["COD_DOC"].ToString();
                    row.Cells["COD_CLASE1"].Value = rw["COD_CLASE"].ToString();
                }
            }
        }

        private void BTN_ACEPTAR_Click(object sender, EventArgs e)
        {
            //MOD_FACT_VTA.FACTURACION_SERVICIOS frm = new MOD_FACT_VTA.FACTURACION_SERVICIOS(AÑO,MES,DateTime.Now,DateTime.Now,"","","");

            //frm.TXT_NRO_FACT.Text = DGW_CAB.CurrentRow.Cells["NRO_DOC1"].Value.ToString();
            //frm.DTP_FACT.Value = Convert.ToDateTime(DGW_CAB.CurrentRow.Cells["FECHA_DOC1"].Value);
            //frm.CBO_MONEDA_REF.SelectedValue = DGW_CAB.CurrentRow.Cells["COD_MONEDA1"].Value;
            //frm.TXT_TC_REF.Text = DGW_CAB.CurrentRow.Cells["TIPO_CAMBIO1"].Value.ToString();
            //this.DialogResult = DialogResult.OK;
            //this.Close();
            //codClase = "";
        }

        private void txt_letra_TextChanged(object sender, EventArgs e)
        {
            int i;
            txt_letra.Focus();
            for (i = 0; i < DGW_CAB.Rows.Count; i++)
            {
                if (txt_letra.TextLength <= DGW_CAB[0, i].Value.ToString().Length)
                {
                    if (txt_letra.Text.ToLower() == DGW_CAB[0, i].Value.ToString().Substring(0, txt_letra.TextLength).ToLower())
                    {
                        DGW_CAB.CurrentCell = DGW_CAB.Rows[i].Cells[0];
                        break;
                    }
                }
            }
        }
    }
}
