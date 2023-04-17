using BLL;
using Entidades;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Presentacion.MOD_CXC
{
    public partial class PLANILLA_DIRECTA_CANCELACION : Form
    {
        cobranzaDirectaBLL codBLL = new cobranzaDirectaBLL();
        cobranzaDirectaTo codTo = new cobranzaDirectaTo();
        calendarioBLL calBLL = new calendarioBLL();
        calendarioTo calTo = new calendarioTo();
        DateTimePicker dtp = new DateTimePicker();
        DateTimePicker dtp2 = new DateTimePicker();
        Rectangle _Rectangle;
        Rectangle _Rectangle2;
        string COD_USU, TIPO;
        DateTime fec_llamada_conf;
        public PLANILLA_DIRECTA_CANCELACION(string COD_USU, string TIPO)
        {
            InitializeComponent();
            this.COD_USU = COD_USU;
            this.TIPO = TIPO;
        }

        private void PLANILLA_DIRECTA_CANCELACION_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            calTo.TIPO = TIPO;
            fec_llamada_conf = Convert.ToDateTime(calBLL.obtenerFechaActivaBLL(calTo));
            lbl_fec_llamada_conf.Text = fec_llamada_conf.ToShortDateString();
            DATAGRID();
            CARGA_COMBO_CUENTA_BANCO();
            CARGA_COMBO_RESPUESTA_TELEFONICA();
            DGW.Controls.Add(dtp);
            DGW.Controls.Add(dtp2);
            dtp.Visible = false;
            dtp.Format = DateTimePickerFormat.Custom;
            dtp.TextChanged += new EventHandler(dtp_TextChanged);
            dtp2.Visible = false;
            dtp2.Format = DateTimePickerFormat.Custom;
            dtp2.TextChanged += new EventHandler(dtp_TextChanged2);
        }

        private void PLANILLA_DIRECTA_CANCELACION_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void DATAGRID()
        {
            codTo.FECHA_CONFIRMADA = fec_llamada_conf;
            DataTable dt = codBLL.obtenerCobranzaDirectaparaConfirmacionBLL(codTo);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow rw in dt.Rows)
                {
                    int rowId = DGW.Rows.Add();
                    DataGridViewRow row = DGW.Rows[rowId];
                    row.Cells["NRO_CONTRATO"].Value = rw["NRO_CONTRATO"].ToString();
                    row.Cells["COD_PERSONA"].Value = rw["COD_PERSONA"].ToString();
                    row.Cells["DESC_PER"].Value = rw["DESC_PER"].ToString();
                    row.Cells["NRO_DOC"].Value = rw["NRO_DOC"].ToString();
                    row.Cells["FECHA_CONFIRMADA"].Value = rw["FECHA_CONFIRMADA"].ToString();
                    row.Cells["IMPORTE_PAGO"].Value = rw["IMPORTE_PAGO"].ToString();
                    row.Cells["NRO_OPERACION"].Value = rw["NRO_OPERACION"].ToString();
                    row.Cells["FECHA_OPERACION"].Value = rw["FECHA_OPERACION"].ToString();
                    row.Cells["COD_BANCO"].Value = rw["COD_BANCO"].ToString();
                    row.Cells["COD_LLAMADA"].Value = rw["COD_LLAMADA"].ToString();
                    row.Cells["FECHA_NUEVA_LLAMADA"].Value = rw["FECHA_NUEVA_LLAMADA"].ToString();
                    row.Cells["IMPORTE_DEPOSITADO"].Value = rw["IMPORTE_DEPOSITADO"].ToString();
                    row.Cells["OBSERVACIONES"].Value = rw["OBSERVACIONES"].ToString();
                    row.Cells["NRO_CUOTA"].Value = rw["NRO_CUOTA"].ToString();
                }
                //DGW.DataSource = dt;
                CALCULOS_TOTALES();
            }
        }
        private void CALCULOS_TOTALES()
        {
            //txt_tot_contratos.Text = DGW.Rows.Count.ToString();
            //txt_tot_importe.Text = sumaImporte();
            sumaImporte();
        }
        private void sumaImporte()
        {
            decimal sumI = 0; decimal sumIDep = 0;
            foreach (DataGridViewRow row in DGW.Rows)
            {
                sumI += Convert.ToDecimal(row.Cells["IMPORTE_PAGO"].Value);
                sumIDep += row.Cells["IMPORTE_DEPOSITADO"].Value.ToString().Trim() == "" ? 0 : Convert.ToDecimal(row.Cells["IMPORTE_DEPOSITADO"].Value);
            }
            txt_tot_importe.Text = sumI.ToString("###,###,##0.00");
            txt_tot_importe_dptdo.Text = sumIDep.ToString("###,###,##0.00");
        }
        private void CARGA_COMBO_RESPUESTA_TELEFONICA()
        {
            DataGridViewComboBoxColumn comboboxColumn = DGW.Columns["COD_LLAMADA"] as DataGridViewComboBoxColumn;
            directorioBLL dirBLL = new directorioBLL();
            directorioTo dirTo = new directorioTo();
            dirTo.TABLA_COD = "TPLAC";
            DataTable dt = dirBLL.MOSTRAR_DIRECTORIO_DATO_BLL(dirTo);
            DataRow rw = dt.NewRow();
            rw["Descripción"] = "";
            rw["Codigo"] = "";
            dt.Rows.InsertAt(rw, 0);
            comboboxColumn.DataSource = dt;
            comboboxColumn.DisplayMember = "Descripción";
            comboboxColumn.ValueMember = "Codigo";
            // bindeo los datos de los productos a la grilla
            DGW.AutoGenerateColumns = false;
        }
        private void CARGA_COMBO_CUENTA_BANCO()
        {
            DataGridViewComboBoxColumn comboboxColumn = DGW.Columns["COD_BANCO"] as DataGridViewComboBoxColumn;
            DataTable dt = codBLL.MOSTRAR_CUENTA_BANCO_BLL();
            DataRow rw = dt.NewRow();
            rw["DESCRIPCION"] = "";
            rw["COD_BANCO"] = "";
            dt.Rows.InsertAt(rw, 0);
            comboboxColumn.DataSource = dt;
            comboboxColumn.DisplayMember = "DESCRIPCION";
            comboboxColumn.ValueMember = "COD_BANCO";
            // bindeo los datos de los productos a la grilla
            DGW.AutoGenerateColumns = false;
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            if (!validaAceptar())
                return;
            DialogResult rs = MessageBox.Show("¿ Esta seguro de Confirmar este registro ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                //var query = from DataGridViewRow row in DGW.Rows
                //            where row.Cells["COD_BANCO"].Value.ToString() != ""
                //            select row;

                codTo.COD_MOD = COD_USU;
                codTo.FECHA_MOD = DateTime.Now;
                //DataTable dtFil = obtenerDTFiltrado();

                codTo.NRO_CONTRATO = DGW.CurrentRow.Cells["NRO_CONTRATO"].Value.ToString();
                codTo.COD_PERSONA = DGW.CurrentRow.Cells["COD_PERSONA"].Value.ToString();
                codTo.NRO_DOC = DGW.CurrentRow.Cells["NRO_DOC"].Value.ToString();
                codTo.NRO_OPERACION = DGW.CurrentRow.Cells["NRO_OPERACION"].Value == null ? null : DGW.CurrentRow.Cells["NRO_OPERACION"].Value.ToString();
                codTo.FECHA_OPERACION = DGW.CurrentRow.Cells["FECHA_OPERACION"].Value.ToString() == "" ? (DateTime?)null : Convert.ToDateTime(DGW.CurrentRow.Cells["FECHA_OPERACION"].Value);
                codTo.COD_BANCO = DGW.CurrentRow.Cells["COD_BANCO"].Value == null ? null : DGW.CurrentRow.Cells["COD_BANCO"].Value.ToString();
                codTo.COD_LLAMADA = DGW.CurrentRow.Cells["COD_LLAMADA"].Value == null ? null : DGW.CurrentRow.Cells["COD_LLAMADA"].Value.ToString();
                codTo.FECHA_NUEVA_LLAMADA = DGW.CurrentRow.Cells["FECHA_NUEVA_LLAMADA"].Value.ToString() == "" ? (DateTime?)null : Convert.ToDateTime(DGW.CurrentRow.Cells["FECHA_NUEVA_LLAMADA"].Value);
                codTo.IMPORTE_DEPOSITADO = DGW.CurrentRow.Cells["IMPORTE_DEPOSITADO"].Value.ToString() == "" ? (Decimal?)null : Convert.ToDecimal(DGW.CurrentRow.Cells["IMPORTE_DEPOSITADO"].Value);
                codTo.OBSERVACIONES = DGW.CurrentRow.Cells["OBSERVACIONES"].Value.ToString();
                codTo.NRO_CUOTA = DGW.CurrentRow.Cells["NRO_CUOTA"].Value.ToString();
                codTo.FECHA_LLAMADA = fec_llamada_conf;
                if (!codBLL.modificaTCobranzaDirectaporCorfirmacionBLL(codTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Se confirmo correctamente este registro !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
        private DataTable obtenerDTFiltrado()
        {
            DataTable dt = obtenerDT();
            DataTable dti = dt.Clone();

            foreach (DataRow rw in dt.Rows)
            {
                if (rw["COD_BANCO"].ToString() != "")
                {
                    DataRow row = dti.NewRow();
                    row["NRO_CONTRATO"] = rw["NRO_CONTRATO"];
                    row["NRO_DOC"] = rw["NRO_DOC"];
                    row["NRO_OPERACION"] = rw["NRO_OPERACION"];
                    row["FECHA_OPERACION"] = rw["FECHA_OPERACION"];
                    row["COD_BANCO"] = rw["COD_BANCO"];
                    row["COD_LLAMADA"] = rw["COD_LLAMADA"];
                    row["FECHA_NUEVA_LLAMADA"] = rw["FECHA_NUEVA_LLAMADA"];
                    row["IMPORTE_DEPOSITADO"] = rw["IMPORTE_DEPOSITADO"];
                    dti.Rows.Add(row);
                }
            }
            return dti;
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
                DataRow dataRow = table.NewRow();
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    dataRow[i] = row.Cells[i].Value != null ? row.Cells[i].Value : DBNull.Value;
                }
                table.Rows.Add(dataRow);
            }
            return table;
        }
        private bool validaAceptar()
        {
            bool result = true;
            if (DGW.Rows.Count <= 0)
            {
                MessageBox.Show(" No existen registros para procesar !!!", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                return result = false;
            }
            return result;
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void DGW_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (DGW.Columns[e.ColumnIndex].Name)
            {
                //case "COD_LLAMADA" :
                //    if(DGW.CurrentRow.Cells["COD_LLAMADA"].Value.ToString()=="")
                //    {
                //        DGW.CurrentRow.Cells["FECHA_OPERACION"].Value = null;
                //        DGW.CurrentRow.Cells["FECHA_NUEVA_LLAMADA"].Value = null;
                //    }
                //    break;
                case "FECHA_OPERACION":
                    _Rectangle = DGW.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                    dtp.Size = new Size(_Rectangle.Width, _Rectangle.Height);
                    dtp.Location = new Point(_Rectangle.X, _Rectangle.Y);
                    dtp.Visible = true;
                    dtp2.Visible = false;
                    break;
                case "FECHA_NUEVA_LLAMADA":
                    _Rectangle2 = DGW.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                    dtp2.Size = new Size(_Rectangle2.Width, _Rectangle2.Height);
                    dtp2.Location = new Point(_Rectangle2.X, _Rectangle2.Y);
                    dtp2.Visible = true;
                    dtp.Visible = false;
                    break;
                default:
                    dtp.Visible = false;
                    dtp2.Visible = false;
                    break;
            }
        }
        private void dtp_TextChanged(object sender, EventArgs e)
        {
            DGW.CurrentCell.Value = dtp.Text.ToString();
        }
        private void dtp_TextChanged2(object sender, EventArgs e)
        {
            DGW.CurrentCell.Value = dtp2.Text.ToString();
        }
        private void DGW_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            dtp.Visible = false;
            dtp2.Visible = false;
        }

        private void DGW_Scroll(object sender, ScrollEventArgs e)
        {
            dtp.Visible = false;
            dtp2.Visible = false;
        }

        private void btn_Historial_Click(object sender, EventArgs e)
        {
            if (DGW.Rows.Count > 0)
            {
                ////DIALOGOS.Dialog3 obs = new DIALOGOS.Dialog3();
                ////obs.txt_obs.Text = DGW.CurrentRow.Cells["OBSERVACIONES"].Value.ToString();
                ////obs.ShowDialog();
                //DIALOGOS.Dialog3 obs = new DIALOGOS.Dialog3();
                //planillaDirectaSeguimientoBLL plsBLL = new planillaDirectaSeguimientoBLL();
                //planillaDirectaSeguimientoTo plsTo = new planillaDirectaSeguimientoTo();
                //plsTo.NRO_CONTRATO = DGW.CurrentRow.Cells["NRO_CONTRATO"].Value.ToString();
                //plsTo.COD_PERSONA = DGW.CurrentRow.Cells["COD_PERSONA"].Value.ToString();
                //plsTo.NRO_CUOTA = DGW.CurrentRow.Cells["NRO_CUOTA"].Value.ToString();
                //DataTable dt = plsBLL.obtenerPlanillaDirectaSeguimientoConfirmacionPagoBLL(plsTo);
                //if (dt.Rows.Count > 0)
                //{
                //    StringBuilder sb = new StringBuilder();
                //    foreach (DataRow rw in dt.Rows)
                //    {
                //        if (rw["TIPO"].ToString() == "1")//1 O 2
                //        {
                //            sb.Append(@"FECHA LLAMADA : " + Convert.ToDateTime(rw["FECHA_LLAMADA"]).ToShortDateString() + Environment.NewLine);
                //            sb.Append(@"CUOTA : " + rw["NRO_CUOTA"].ToString() + Environment.NewLine);
                //            sb.Append(@"RESPUESTA : " + rw["DES_LLAMADA_LL"].ToString() + Environment.NewLine);
                //            sb.Append(@"NUEVA FECHA : " + Convert.ToDateTime(rw["FECHA_NUEVA_LLAMADA_LL"]).ToShortDateString() + Environment.NewLine);
                //            sb.Append(@"OBSERVACIONES : " + rw["OBS_LLAMADA_LL"].ToString() + Environment.NewLine + Environment.NewLine);
                //        }
                //        else
                //        {
                //            sb.Append(@"FECHA LLAMADA : " + Convert.ToDateTime(rw["FECHA_LLAMADA"]).ToShortDateString() + Environment.NewLine);
                //            sb.Append(@"CUOTA : " + rw["NRO_CUOTA"].ToString() + Environment.NewLine);
                //            sb.Append(@"RESPUESTA : " + rw["DES_LLAMADA_CO"].ToString() + Environment.NewLine);
                //            sb.Append(@"NUEVA FECHA : " + Convert.ToDateTime(rw["FECHA_NUEVA_LLAMADA_CO"]).ToShortDateString() + Environment.NewLine);
                //            sb.Append(@"OBSERVACIONES : " + rw["OBS_LLAMADA_CO"].ToString() + Environment.NewLine + Environment.NewLine);
                //        }
                //    }
                //    obs.Text = "HISTORIAL DE LLAMADAS";
                //    obs.txt_obs.ScrollBars = ScrollBars.Vertical;
                //    obs.txt_obs.ReadOnly = true;
                //    obs.txt_obs.Text = sb.ToString();
                //    obs.ShowDialog();
                //}

                PLANILLA_DIRECTA_SEGUIMIENTO frm = new PLANILLA_DIRECTA_SEGUIMIENTO();
                planillaDirectaSeguimientoBLL plsBLL = new planillaDirectaSeguimientoBLL();
                planillaDirectaSeguimientoTo plsTo = new planillaDirectaSeguimientoTo();
                plsTo.NRO_CONTRATO = DGW.CurrentRow.Cells["NRO_CONTRATO"].Value.ToString();
                plsTo.COD_PERSONA = DGW.CurrentRow.Cells["COD_PERSONA"].Value.ToString();
                plsTo.NRO_CUOTA = DGW.CurrentRow.Cells["NRO_CUOTA"].Value.ToString();
                DataTable dt = plsBLL.obtenerPlanillaDirectaSeguimientoConfirmacionPagoBLL(plsTo);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow rw in dt.Rows)
                    {
                        if (rw["TIPO"].ToString() == "L" || rw["TIPO"].ToString() == "T")//1 O 2
                        {
                            int rowId = frm.DGW_DETALLE.Rows.Add();
                            DataGridViewRow row = frm.DGW_DETALLE.Rows[rowId];
                            row.Cells["tip_llamada"].Value = rw["TIPO"].ToString();
                            row.Cells["FECHA_LLAMADA"].Value = Convert.ToDateTime(rw["FECHA_LLAMADA"]).ToShortDateString();
                            row.Cells["NRO_CUOTA"].Value = rw["NRO_CUOTA"].ToString();
                            row.Cells["DES_LLAMADA"].Value = rw["DES_LLAMADA_LL"].ToString();
                            row.Cells["FECHA_NUEVA_LLAMADA"].Value = rw["FECHA_NUEVA_LLAMADA_LL"] == DBNull.Value ? null : Convert.ToDateTime(rw["FECHA_NUEVA_LLAMADA_LL"]).ToShortDateString();//Convert.ToDateTime(rw["FECHA_NUEVA_LLAMADA_LL"]).ToShortDateString();
                            row.Cells["OBS_LLAMADA"].Value = rw["OBS_LLAMADA_LL"].ToString();
                        }
                        else if (rw["TIPO"].ToString() == "C")
                        {
                            int rowId = frm.DGW_DETALLE.Rows.Add();
                            DataGridViewRow row = frm.DGW_DETALLE.Rows[rowId];
                            row.Cells["tip_llamada"].Value = rw["TIPO"].ToString();
                            row.Cells["FECHA_LLAMADA"].Value = Convert.ToDateTime(rw["FECHA_LLAMADA"]).ToShortDateString();
                            row.Cells["NRO_CUOTA"].Value = rw["NRO_CUOTA"].ToString();
                            row.Cells["DES_LLAMADA"].Value = rw["DES_LLAMADA_CO"].ToString();
                            row.Cells["FECHA_NUEVA_LLAMADA"].Value = rw["FECHA_NUEVA_LLAMADA_CO"] == DBNull.Value ? null : Convert.ToDateTime(rw["FECHA_NUEVA_LLAMADA_CO"]).ToShortDateString();//rw["FECHA_NUEVA_LLAMADA_CO"].ToString() == "" ? null : Convert.ToDateTime(rw["FECHA_NUEVA_LLAMADA_CO"]).ToShortDateString();
                            row.Cells["OBS_LLAMADA"].Value = rw["OBS_LLAMADA_CO"].ToString();
                        }
                    }
                    frm.lbl_nro_llama.Text = dt.Rows.Count.ToString();
                    frm.ShowDialog();
                }
            }
        }

        private void btn_cierre_Click(object sender, EventArgs e)
        {
            if (!validaCierre())
                return;
            DialogResult rs = MessageBox.Show("¿ Esta seguro de realizar el Cierre para el dia de hoy ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";

                codTo.COD_MOD = COD_USU;
                codTo.FECHA_MOD = DateTime.Now;
                DataTable dtFil = obtenerDT();

                if (!codBLL.modificaTCobranzaDirectaporCierreBLL(codTo, dtFil, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    //preguntar si se graba status
                    MessageBox.Show("¿ Se cerro correctamente !!!?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    this.Dispose();
                }

            }
        }
        private bool validaCierre()
        {
            bool result = true;

            return result;
        }
        //private void DISEÑO_GRID()
        //{
        //    DGW.Columns["NRO_CONTRATO"].HeaderText = "Contrato";
        //    DGW.Columns["NRO_CONTRATO"].Width = 80;
        //    DGW.Columns["NRO_CONTRATO"].ReadOnly = true;
        //    DGW.Columns["DESC_PER"].HeaderText = "Cliente";
        //    DGW.Columns["DESC_PER"].Width = 200;
        //    DGW.Columns["DESC_PER"].ReadOnly = true;
        //    DGW.Columns["NRO_DOC"].HeaderText = "Doc";
        //    DGW.Columns["NRO_DOC"].Width = 60;
        //    DGW.Columns["NRO_DOC"].ReadOnly = true;
        //    DGW.Columns["FECHA_CONFIRMADA"].HeaderText = "F Confirmada";
        //    DGW.Columns["FECHA_CONFIRMADA"].Width = 70;
        //    DGW.Columns["FECHA_CONFIRMADA"].DefaultCellStyle.Format = "dd/MM/yyyy";
        //    DGW.Columns["FECHA_CONFIRMADA"].ReadOnly = true;
        //    DGW.Columns["IMPORTE_PAGO"].HeaderText = "Importe";
        //    DGW.Columns["IMPORTE_PAGO"].Width = 70;
        //    DGW.Columns["IMPORTE_PAGO"].DefaultCellStyle.Format = string.Format("###,###,##0.00");
        //    DGW.Columns["IMPORTE_PAGO"].ReadOnly = true;
        //    DGW.Columns["NRO_OPERACION"].HeaderText = "N° Operacion";
        //    DGW.Columns["NRO_OPERACION"].Width = 70;
        //    DGW.Columns["NRO_OPERACION"].ReadOnly = false;
        //    DGW.Columns["FECHA_OPERACION"].HeaderText = "F Operacion";
        //    DGW.Columns["FECHA_OPERACION"].Width = 70;
        //    DGW.Columns["FECHA_OPERACION"].ReadOnly = false;
        //    DGW.Columns["COD_BANCO"].HeaderText = "Banco";
        //    DGW.Columns["COD_BANCO"].Width = 120;

        //}

    }
}
