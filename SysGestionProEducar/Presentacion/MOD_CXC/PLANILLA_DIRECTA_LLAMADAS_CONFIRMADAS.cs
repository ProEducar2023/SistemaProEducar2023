using BLL;
using Entidades;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Presentacion.MOD_CXC
{
    public partial class PLANILLA_DIRECTA_LLAMADAS_CONFIRMADAS : Form
    {
        string nro_contrato; DateTime fecha_ven; string COD_USU, TIPO;
        DateTimePicker dtp = new DateTimePicker();
        Rectangle _Rectangle;
        planillaDirectaBLL pldBLL = new planillaDirectaBLL();
        planillaDirectaTo pldTo = new planillaDirectaTo();
        cobranzaDirectaBLL codBLL = new cobranzaDirectaBLL();
        cobranzaDirectaTo codTo = new cobranzaDirectaTo();
        public PLANILLA_DIRECTA_LLAMADAS_CONFIRMADAS(string nro_contrato, DateTime fecha_ven, string COD_USU, string TIPO)
        {
            InitializeComponent();
            this.nro_contrato = nro_contrato;
            this.fecha_ven = fecha_ven;
            this.COD_USU = COD_USU;
            this.TIPO = TIPO;
            dtp.Value = fecha_ven;
            DGW_DETALLE.Controls.Add(dtp);
            dtp.Visible = false;
            dtp.Format = DateTimePickerFormat.Custom;
            dtp.TextChanged += new EventHandler(dtp_TextChanged);
        }

        private void PLANILLA_DIRECTA_LLAMADAS_CONFIRMADAS_Load(object sender, EventArgs e)
        {
            DATAGRID();
            CARGA_COMBO_RESPUESTA_TELEFONICA();
        }
        private void CARGA_DATAGRID_CON_LLAMADAS_REALIZADAS()
        {
            DataTable dtDet = obtenerDT();
        }
        private void DATAGRID()
        {
            pldTo.NRO_CONTRATO = nro_contrato;
            pldTo.FECHA_VEN = fecha_ven;
            pldTo.TIPO = TIPO;
            DataTable dtCobDir, dtCobDir2;
            DataTable dt = pldBLL.Mostrar_Cobranza_Planilla_por_Llamada_BLL(pldTo);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow rw in dt.Rows)
                {
                    int rowId = DGW_DETALLE.Rows.Add();
                    DataGridViewRow row = DGW_DETALLE.Rows[rowId];
                    row.Cells["nrocontrato"].Value = codTo.NRO_CONTRATO = rw["NRO_CONTRATO"].ToString();
                    row.Cells["codpersona"].Value = codTo.COD_PERSONA = rw["COD_PER"].ToString();
                    row.Cells["coddoc"].Value = codTo.COD_DOC = rw["COD_DOC"].ToString();
                    row.Cells["nrodoc"].Value = codTo.NRO_DOC = rw["NRO_DOC"].ToString();
                    row.Cells["fechacontrato"].Value = rw["FECHA_CONTRATO"].ToString();
                    row.Cells["fechallamada"].Value = fecha_ven;
                    row.Cells["importe"].Value = rw["IMP_INI"].ToString();
                    row.Cells["letra"].Value = rw["NRO_LETRA"].ToString();
                    row.Cells["fecha_venc"].Value = rw["FECHA_VEN"].ToString();
                    row.Cells["tip_pla_co"].Value = rw["TIPO_PLA_COBRANZA"].ToString();
                    if (TIPO == "D")
                    {


                        dtCobDir = codBLL.obtenerCobranzaDirectaporLlaveBLL(codTo);
                        if (dtCobDir.Rows.Count > 0)
                        {
                            row.Cells["fechaconfirmada"].Value = dtCobDir.Rows[0]["FECHA_CONFIRMADA"].ToString();
                            row.Cells["respuesta"].Value = "01";
                            row.Cells["observaciones"].Value = dtCobDir.Rows[0]["OBSERVACIONES"].ToString();
                        }
                        else
                        {
                            pldTo.COD_PERSONA = rw["COD_PER"].ToString();
                            dtCobDir2 = pldBLL.obtenerPlanillaDirectaporLlaveBLL(pldTo);
                            if (dtCobDir2.Rows.Count > 0)
                            {
                                row.Cells["fechaconfirmada"].Value = dtCobDir2.Rows[0]["FECHA_NUEVA_LLAMADA"].ToString();
                                row.Cells["respuesta"].Value = dtCobDir2.Rows[0]["COD_LLAMADA"].ToString();
                                row.Cells["observaciones"].Value = dtCobDir2.Rows[0]["OBSERVACIONES"].ToString();
                            }
                        }
                    }
                    else if (TIPO == "P")
                    {
                        pldTo.COD_PERSONA = rw["COD_PER"].ToString();
                        pldTo.TIPO = TIPO;
                        dtCobDir2 = pldBLL.obtenerPlanillaDirectaporLlaveBLL(pldTo);
                        if (dtCobDir2.Rows.Count > 0)
                        {
                            row.Cells["fechaconfirmada"].Value = dtCobDir2.Rows[0]["FECHA_NUEVA_LLAMADA"].ToString();
                            row.Cells["respuesta"].Value = dtCobDir2.Rows[0]["COD_LLAMADA"].ToString();
                            row.Cells["observaciones"].Value = dtCobDir2.Rows[0]["OBSERVACIONES"].ToString();
                        }
                    }
                }
            }

        }

        private void CARGA_COMBO_RESPUESTA_TELEFONICA()
        {
            DataGridViewComboBoxColumn comboboxColumn = DGW_DETALLE.Columns["respuesta"] as DataGridViewComboBoxColumn;
            directorioBLL dirBLL = new directorioBLL();
            directorioTo dirTo = new directorioTo();
            dirTo.TABLA_COD = "TPLAD";
            DataTable dt = dirBLL.MOSTRAR_DIRECTORIO_DATO_BLL(dirTo);
            DataRow rw = dt.NewRow();
            rw["Descripción"] = "";
            rw["Codigo"] = "";
            dt.Rows.InsertAt(rw, 0);
            comboboxColumn.DataSource = dt;
            comboboxColumn.DisplayMember = "Descripción";
            comboboxColumn.ValueMember = "Codigo";
            // bindeo los datos de los productos a la grilla
            //
            DGW_DETALLE.AutoGenerateColumns = false;
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            if (DGW_DETALLE.Rows.Count > 0)
            {
                if (!validaAceptar())
                    return;
                DialogResult rs = MessageBox.Show("¿ Esta seguro de lo que va a hacer ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    string errMensaje = "";
                    pldTo.FECHA_LLAMADA = fecha_ven;//es la fecha de llamada o fecha activa
                    pldTo.COD_CREACION = COD_USU;
                    pldTo.FECHA_MOD = DateTime.Now;
                    DataTable dtDetalle = obtenerDT();
                    if (!pldBLL.crearPlanillaDirectaBLL(pldTo, dtDetalle, ref errMensaje))
                        MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        this.Dispose();
                    }
                }
            }
        }
        private DataTable obtenerDT()
        {
            DataTable table = new DataTable();
            foreach (DataGridViewColumn column in DGW_DETALLE.Columns)
            {
                table.Columns.Add(column.Name, typeof(string));
            }
            foreach (DataGridViewRow row in DGW_DETALLE.Rows)
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
            DateTime fec_conf = DateTime.Now;
            foreach (DataGridViewRow rw in DGW_DETALLE.Rows)
            {
                if (rw.Cells["respuesta"].Value.ToString() != "")
                {
                    if (rw.Cells["respuesta"].Value.ToString() == "01")
                    {
                        if (!DateTime.TryParse(rw.Cells["fechaconfirmada"].Value.ToString(), out fec_conf))
                        {
                            MessageBox.Show("La fecha no es valida !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            rw.Cells["fechaconfirmada"].Selected = true;
                            return result = false;
                        }
                        if (Convert.ToDateTime(rw.Cells["fechaconfirmada"].Value) < Convert.ToDateTime(rw.Cells["fechallamada"].Value))
                        {
                            MessageBox.Show("La fecha de confirmacion de pago debe ser mayor \nque la fecha en la que se llama !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            rw.Cells["fechaconfirmada"].Selected = true;
                            return result = false;
                        }
                    }
                    else if (rw.Cells["respuesta"].Value.ToString() == "02")
                    {
                        if (!DateTime.TryParse(rw.Cells["fechaconfirmada"].Value.ToString(), out fec_conf))
                        {
                            MessageBox.Show("La fecha no es valida !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            rw.Cells["fechaconfirmada"].Selected = true;
                            return result = false;
                        }
                        if (Convert.ToDateTime(rw.Cells["fechaconfirmada"].Value) <= Convert.ToDateTime(rw.Cells["fechallamada"].Value))
                        {
                            MessageBox.Show("La fecha de la nueva llamada debe ser mayor \nque la fecha en la que se llama !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            rw.Cells["fechaconfirmada"].Selected = true;
                            return result = false;
                        }
                    }
                }
            }
            return result;
        }

        private void btn_Rehacer_Click(object sender, EventArgs e)
        {
            if (DGW_DETALLE.Rows.Count > 0)
            {
                DialogResult rs = MessageBox.Show("¿ Esta seguro de rehacerlo de nuevo ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    string errMensaje = "";
                    //pldTo.FECHA_LLAMADA = fecha_ven;//es la fecha de llamada
                    pldTo.COD_CREACION = COD_USU;
                    pldTo.FECHA_MOD = DateTime.Now;
                    DataTable dtReg = obtenerDT();
                    if (!pldBLL.modificarRehacerBLL(pldTo, dtReg, ref errMensaje))
                        MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        this.Dispose();
                    }
                }
            }
        }

        private void DGW_DETALLE_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (DGW_DETALLE.Columns[e.ColumnIndex].Name)
            {
                case "fechaconfirmada":
                    _Rectangle = DGW_DETALLE.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                    dtp.Size = new Size(_Rectangle.Width, _Rectangle.Height);
                    dtp.Location = new Point(_Rectangle.X, _Rectangle.Y);
                    dtp.Visible = true;
                    break;
                default:
                    dtp.Visible = false;
                    break;
            }
        }
        private void dtp_TextChanged(object sender, EventArgs e)
        {
            DGW_DETALLE.CurrentCell.Value = dtp.Text.ToString();
        }

        private void DGW_DETALLE_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            dtp.Visible = false;
        }

        private void DGW_DETALLE_Scroll(object sender, ScrollEventArgs e)
        {
            dtp.Visible = false;
        }

        private void DGW_DETALLE_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            dtp.Text = DGW_DETALLE.CurrentCell.Value.ToString();
            DGW_DETALLE.CurrentCell.Value = dtp.Text.ToString();
        }
    }
}
