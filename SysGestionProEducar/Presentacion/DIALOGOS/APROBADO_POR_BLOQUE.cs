using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Presentacion.DIALOGOS
{
    public partial class APROBADO_POR_BLOQUE : Form
    {
        //public MODULOS_VENTAS modulos_ventas;
        DataGridView dgw; string TIPO_DOC, COD_USU, MES, AÑO;
        StringBuilder sbAlm = new StringBuilder();
        precontratoCabeceraBLL pccBLL = new precontratoCabeceraBLL();
        precontratoCabeceraTo pccTo = new precontratoCabeceraTo();
        //DataTable dtListaContratos;
        StringBuilder sb = new StringBuilder();
        public APROBADO_POR_BLOQUE(DataGridView dgw, string TIPO_DOC, string COD_USU, string MES, string AÑO)
        {
            InitializeComponent();
            this.dgw = dgw;
            this.TIPO_DOC = TIPO_DOC;
            this.COD_USU = COD_USU;
            this.MES = MES;
            this.AÑO = AÑO;
            //this.modulos_ventas = modulos_ventas;
        }
        private void APROBADO_POR_BLOQUE_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }
        private void APROBADO_POR_BLOQUE_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            LIMPIAR();
            CARGAR_PERSONAL();
            CARGAR_MOVIMIENTO();
            //DTP_DOC.CustomFormat = "dd/MM/yyyy hh:mm:ss";
            //DTP_DOC.Format = DateTimePickerFormat.Custom;
            //DTP_DOC.Value = Convert.ToDateTime(DateTime.Now.Day + "/" + MES + "/" + AÑO + " " + DateTime.Now.Hour+":"+DateTime.Now.Minute+":"+DateTime.Now.Second);
            DTP_DOC.Value = Convert.ToDateTime(DateTime.Now.Day + "/" + MES + "/" + AÑO);
            //dtListaContratos.Columns.Add();
        }
        private void LIMPIAR()
        {
            CBO_PERSONAL1.SelectedIndex = -1;
        }
        private void CARGAR_PERSONAL()
        {
            CBO_PERSONAL1.Items.Clear();
            personaBLL perBLL = new personaBLL();
            DataTable dt = perBLL.obtenerPersonalPedidoBLL();
            CBO_PERSONAL1.ValueMember = "CODIGO";
            CBO_PERSONAL1.DisplayMember = "DESCRIPCION";
            CBO_PERSONAL1.DataSource = dt;
            CBO_PERSONAL1.SelectedIndex = 0;
        }
        private void CARGAR_MOVIMIENTO()
        {
            movimientosBLL movBLL = new movimientosBLL();
            DataTable dt = movBLL.obtenerMovimientosparaPedidoBLL();
            cbo_movimiento.ValueMember = "COD_MOV";
            cbo_movimiento.DisplayMember = "DESC_MOV";
            cbo_movimiento.DataSource = dt;
            cbo_movimiento.SelectedIndex = 1;
        }
        private void CARGAR_GRID()
        {
            dgw_x_aprobar.Rows.Clear();
            decimal sum = 0;
            foreach (DataGridViewRow rw in dgw.Rows)
            {
                if ((txt_nrep1.Text == rw.Cells["NRO_REPORTE"].Value.ToString()) && (!Convert.ToBoolean(rw.Cells["Anul"].Value)))
                {
                    int rowId = dgw_x_aprobar.Rows.Add();
                    DataGridViewRow row = dgw_x_aprobar.Rows[rowId];
                    row.Cells["COD_SUCURSAL"].Value = rw.Cells["COD_SUCURSAL"].Value.ToString();
                    row.Cells["COD_CLASE"].Value = rw.Cells["cod_clase"].Value.ToString();
                    row.Cells["COD_PER"].Value = rw.Cells["cod_per"].Value.ToString();
                    row.Cells["Contrato"].Value = rw.Cells["Contrato"].Value.ToString();
                    row.Cells["FE_AÑO"].Value = rw.Cells["FE_AÑO"].Value.ToString();
                    row.Cells["FE_MES"].Value = rw.Cells["FE_MES"].Value.ToString();
                    row.Cells["Cliente"].Value = rw.Cells["Cliente"].Value.ToString();
                    row.Cells["Fecha"].Value = rw.Cells["Fecha"].Value.ToString().Substring(0, 10);
                    row.Cells["TOTAL_CONTRATO"].Value = string.Format("{0:###,###,##0.00}", rw.Cells["TOTAL_CONTRATO"].Value);
                    row.Cells["FEC_PRIMER_VENC"].Value = rw.Cells["FEC_PRIMER_VENC"].Value.ToString().Substring(0, 10);
                    row.Cells["IMP_CUOTA_INICIAL"].Value = string.Format("{0:N2}", rw.Cells["IMP_CUOTA_INICIAL"].Value);
                    row.Cells["FEC_CUO_MEN"].Value = rw.Cells["FEC_CUO_MEN"].Value.ToString().Substring(0, 10);
                    row.Cells["IMP_CUOTA_MES"].Value = string.Format("{0:N2}", rw.Cells["IMP_CUOTA_MES"].Value);
                    sum += Convert.ToDecimal(row.Cells["TOTAL_CONTRATO"].Value);
                }
            }
            lbl_cantidad_registros.Text = "Nro de Registros " + dgw_x_aprobar.Rows.Count.ToString();
            lbl_suma_registros.Text = string.Format("Suma Imp Total S/. {0:###,###,##0.00}", sum);
        }

        private void btn_ver_Click(object sender, EventArgs e)
        {
            if (!validaCombo("ver"))
                return;
            CARGAR_GRID();
        }

        private void chk_Todos_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_Todos.Checked)
            {
                foreach (DataGridViewRow row in dgw_x_aprobar.Rows)
                    row.Cells["X"].Value = true;
            }
            else
            {
                foreach (DataGridViewRow row in dgw_x_aprobar.Rows)
                    row.Cells["X"].Value = false;
            }
        }
        private bool verificaStock()
        {
            //verifica stock en almacen
            bool result = true;
            sbAlm.Clear();
            string nro_contrato;
            List<string> lstContratos = new List<string>();
            string errMensaje = "";
            for (int i = 0; i < dgw_x_aprobar.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dgw_x_aprobar.Rows[i].Cells["X"].Value))
                {
                    nro_contrato = Convert.ToString(dgw_x_aprobar.Rows[i].Cells["Contrato"].Value);
                    if (verificarStockAlmacenxNroContrato(nro_contrato, ref errMensaje))
                    {
                        lstContratos.Add(nro_contrato);
                    }
                }
            }
            for (int i = 0; i < lstContratos.Count; i++)
            {
                //if (i == lstContratos.Count - 1)
                sbAlm.Append("\n" + lstContratos[i]);
            }
            if (lstContratos.Count > 0)
            {
                MessageBox.Show("Estos son los contratos que no tienen stock : " + sbAlm.ToString(), "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                for (int j = 0; j < lstContratos.Count; j++)
                {
                    for (int i = 0; i < dgw_x_aprobar.Rows.Count; i++)
                    {
                        if (lstContratos[j].ToString().Trim() == dgw_x_aprobar.Rows[i].Cells["Contrato"].Value.ToString())
                        {
                            dgw_x_aprobar.Rows[i].Cells["X"].Value = false;
                        }
                    }
                }
            }
            var query = from DataGridViewRow row in dgw_x_aprobar.Rows
                        where Convert.ToBoolean(row.Cells["X"].Value) == true
                        select row;
            int cant = query.Count();
            if (cant <= 0)
            {
                result = false;
            }
            return result;
        }
        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            if (!validaCombo("grabar"))
                return;
            if (!verificaStock())
                return;
            DialogResult rs = MessageBox.Show("¿ Esta seguro de aprobar los documentos ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                if (TIPO_DOC == "PreContrato")
                {
                    string errMensaje = "";
                    pccTo.COD_PER_APROB = CBO_PERSONAL1.SelectedValue.ToString();
                    pccTo.FECHA_APROB = DTP_DOC.Value;
                    pccTo.COD_MOV = cbo_movimiento.SelectedValue.ToString();
                    pccTo.NOMBRE_PC = System.Environment.MachineName;
                    pccTo.COD_USU = COD_USU;
                    pccTo.STATUS_PRE_APROB = chk_preAprob.Checked ? "1" : "";
                    DataTable dt = HelpersBLL.obtenerDTX(dgw_x_aprobar);
                    if (!pccBLL.modificaApruebaPreContratoBloqueBLL(pccTo, dt, ref errMensaje))
                        MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        MessageBox.Show("Se aprobaron con éxito !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Dispose();
                    }
                }
                else if (TIPO_DOC == "Contrato")
                {

                }
            }
        }
        private bool validaCombo(string op)
        {
            bool result = true;
            if (CBO_PERSONAL1.SelectedIndex <= -1)
            {
                MessageBox.Show("Elegir la persona !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                CBO_PERSONAL1.Focus();
                return result = false;
            }
            int s = 0;
            if (!int.TryParse(txt_nrep1.Text, out s))
            {
                MessageBox.Show("Ingreso un valor válido", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_nrep1.Focus();
                return result = false;
            }
            //if(DTP_DOC.Value < Convert.ToDateTime("01"+"/"+MES+"/"+AÑO))
            //{
            //    MessageBox.Show("Ingreso una fecha de Aprobacion válida", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    DTP_DOC.Focus();
            //    return result = false;
            //}
            if (op == "grabar")
            {
                //verifica que algún contrato haya sido elegido
                for (int i = 0; i < dgw_x_aprobar.Rows.Count; i++)
                {
                    if (i != dgw_x_aprobar.Rows.Count - 1)
                    {
                        if (Convert.ToBoolean(dgw_x_aprobar.Rows[i].Cells["X"].Value))
                            break;
                    }
                    else
                    {
                        if (Convert.ToBoolean(dgw_x_aprobar.Rows[i].Cells["X"].Value))
                            break;
                        MessageBox.Show("Elija algún contrato !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txt_nrep1.Focus();
                        return result = false;
                    }
                }
                //verifica la fecha de primer vencimiento
                for (int i = 0; i < dgw_x_aprobar.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(dgw_x_aprobar.Rows[i].Cells["X"].Value))
                    {
                        if (DTP_DOC.Value.Date > Convert.ToDateTime(dgw_x_aprobar.Rows[i].Cells["FEC_PRIMER_VENC"].Value))
                        {
                            if (i == dgw_x_aprobar.Rows.Count - 1)
                                sb.Append(dgw_x_aprobar.Rows[i].Cells["Contrato"].Value.ToString() + ".");
                            else
                                sb.Append(dgw_x_aprobar.Rows[i].Cells["Contrato"].Value.ToString() + ", ");
                        }
                    }
                }
                if (sb.Length > 0)
                {
                    lbl_mensaje_aprobado.Text = "Modificar Plan de Pagos";
                    lbl_nro_contrato.Text = sb.ToString().Substring(0, 7);
                    MessageBox.Show("Modificar Plan de Pagos 1er Vencimiento para el (los) contrato(s), tomar apunte : \n" + sb.ToString(), "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    DialogResult = DialogResult.OK;
                    return result = false;
                }

            }
            return result;
        }
        private bool verificarStockAlmacenxNroContrato(string nro_contrato, ref string errMensaje)
        {
            bool result = true;
            mArticuloBLL mrtBLL = new mArticuloBLL();
            mArticuloTo mrtTo = new mArticuloTo();
            mrtTo.NRO_PRESUPUESTO = nro_contrato;
            if (!mrtBLL.verificarStockAlmacenesBLL(mrtTo, ref errMensaje))
                return result = false;
            return result;
        }
        private void txt_nrep1_Leave(object sender, EventArgs e)
        {
            if (!validaCombo("ver"))
                return;
            txt_nrep1.Text = txt_nrep1.Text.PadLeft(6, '0');
        }


    }
}
