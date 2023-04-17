using BLL;
using Entidades;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Presentacion.MOD_CXC
{
    public partial class TRANSFERENCIA_DOCUMENTO_VENCIDOS_DIRECTA : Form
    {
        string AÑO = "", MES = "", COD_MOD = "", COD_USU = "", TIPO_USU = "";
        DateTime FECHA_INI, FECHA_GRAL;
        DataTable dtGestores;
        DataTable dtContratosxVencer, dtContratosxVencerCuotas, dtKardexHistorico, dtGestor;
        string BOTON;
        Rectangle _Rectangle;
        DateTimePicker dtp = new DateTimePicker();
        progNivelBLL prnBLL = new progNivelBLL();
        progNivelTo prnTo = new progNivelTo();
        descuentoDirectoBLL ddBLL = new descuentoDirectoBLL();
        descuentoDirectaTo ddTo = new descuentoDirectaTo();
        calendarioBLL calBLL = new calendarioBLL();
        calendarioTo calTo = new calendarioTo();
        DateTime fec_activa;
        public TRANSFERENCIA_DOCUMENTO_VENCIDOS_DIRECTA(string AÑO, string MES, DateTime FECHA_INI, DateTime FECHA_GRAL, string COD_MOD, string TIPO_USU, string COD_USU)
        {
            InitializeComponent();
            this.AÑO = AÑO;
            this.MES = MES;
            this.FECHA_INI = FECHA_INI;
            this.FECHA_GRAL = FECHA_GRAL;
            this.COD_MOD = COD_MOD;
            this.TIPO_USU = TIPO_USU;
            this.COD_USU = COD_USU;
            calTo.TIPO = "D";
            fec_activa = Convert.ToDateTime(calBLL.obtenerFechaActivaBLL(calTo));
            dtp.Value = fec_activa;//para que por defecto muestre la fecha activa
            dgwComPenLiq.Controls.Add(dtp);
            dtp.Visible = false;
            dtp.Format = DateTimePickerFormat.Custom;
            dtp.TextChanged += new EventHandler(dtp_TextChanged);
        }

        private void TRANSFERENCIA_DOCUMENTO_VENCIDOS_DIRECTA_Load(object sender, EventArgs e)
        {
            CARGAR_MES_MOROSIDAD_DEFAULT();
            CONTRATOS_ASIGNADOS();
            CARGAR_SECTORISTAS();
            CARGAR_GESTORES();
        }
        private void CONTRATOS_ASIGNADOS()
        {

        }
        private void CONTRATOS_X_ASIGNAR()
        {
            ddTo.MESES_MOROSIDAD = Convert.ToInt32(txt_mes_mor.Text);
            dtContratosxVencer = ddBLL.obtenerContratos_x_AsignarBLL(ddTo);
            if (dtContratosxVencer.Rows.Count > 0)
            {
                dgwComPenLiq.Rows.Clear();
                foreach (DataRow rw in dtContratosxVencer.Rows)
                {
                    int rowId = dgwComPenLiq.Rows.Add();
                    DataGridViewRow row = dgwComPenLiq.Rows[rowId];
                    row.Cells["COD_SUCURSAL"].Value = rw["COD_SUCURSAL"].ToString();
                    row.Cells["COD_CLASE"].Value = rw["COD_CLASE"].ToString();
                    row.Cells["COD_PER"].Value = rw["COD_PER"].ToString();
                    row.Cells["DESC_PER"].Value = rw["DESC_PER"].ToString();
                    row.Cells["COD_DOC"].Value = rw["NRO_DOC"].ToString();
                    row.Cells["NRO_CONTRATO"].Value = rw["NRO_CONTRATO"].ToString();
                    row.Cells["FE_CONTRATO"].Value = rw["FECHA_CONTRATO"].ToString().Substring(0, 10);
                    row.Cells["NRO_CUOTAS"].Value = rw["NRO_CUOTAS"].ToString();
                    row.Cells["FEC_LLAMADA1"].Value = fec_activa.ToShortDateString();
                    row.Cells["X"].Value = false;
                }
            }
            dtContratosxVencerCuotas = ddBLL.obtenerContratos_x_Asignar_CuotasBLL(ddTo);
            dtKardexHistorico = ddBLL.obtenerKardexContratosDirectosBLL(ddTo);
            LLENA_CANTIDAD_GESTORES_X_LLAMAR();
            //foreach (DataGridViewRow row in dgwComPenLiq.Rows) ///para cambiar de color de fondo
            //    row.DefaultCellStyle.BackColor = Color.LightCyan;
            dgwComPenLiq.Select();
            //dgwComPenLiqDet.CurrentCell = dgwComPenLiq.Rows[0].Cells[2];
        }
        private void LLENA_CANTIDAD_GESTORES_X_LLAMAR()
        {
            dtGestor = ddBLL.obtenerCantidadGestoresporLlamarBLL();
            if (dtGestor.Rows.Count > 0)
            {
                dgwGestores.Rows.Clear();
                foreach (DataRow rw in dtGestor.Rows)
                {
                    int rowId = dgwGestores.Rows.Add();
                    DataGridViewRow row = dgwGestores.Rows[rowId];
                    row.Cells["COD_PERSONA"].Value = rw["COD_PER"].ToString();
                    row.Cells["NOM_PERSONA"].Value = rw["DESC_PER"].ToString();
                    row.Cells["CANT"].Value = rw["CANT"].ToString();
                }
            }
        }
        private void CARGAR_SECTORISTAS()
        {
            //prnTo.COD_NIVEL = "01";//sectoristas
            DataTable dt = prnBLL.obtenerSectoristasparaCrearEqCobradoresBLL("01");
            if (dt.Rows.Count > 0)
            {
                cbo_sectorista.ValueMember = "COD_EQCOB";
                cbo_sectorista.DisplayMember = "DESC_EQVTA";
                cbo_sectorista.DataSource = dt;
            }
        }
        private void CARGAR_GESTORES()
        {
            DataGridViewComboBoxColumn comboboxColumn = dgwComPenLiq.Columns["COD_GESTOR"] as DataGridViewComboBoxColumn;
            prnTo.COD_PER = null;//cbo_sectorista.SelectedValue.ToString();//desde aqui se puede relacionar con un sectorista.
            prnTo.COD_NIVEL = "03";//02 cobrador, 03 gestor
            dtGestores = prnBLL.obtenerCobradoresxSectoristaBLL(prnTo);
            comboboxColumn.DataSource = dtGestores;
            comboboxColumn.DisplayMember = "DESC_EQVTA";
            comboboxColumn.ValueMember = "COD_EQCOB";
            // bindeo los datos de los productos a la grilla
            dgwComPenLiq.AutoGenerateColumns = false;
        }
        private void CARGAR_MES_MOROSIDAD_DEFAULT()
        {
            string mes = HelpersBLL.OBTENER_DES_DIRECTORIO(null, "TMORM");
            txt_mes_mor.Text = mes;
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            BOTON = "NUEVO";
            TabControl1.SelectedTab = TabPage2;

        }

        private void dgwComPenLiq_Click(object sender, EventArgs e)
        {
            if (dgwComPenLiq.Rows.Count > 0)
            {
                llenaDetalleContratosVencidosxTransferir();
                llenaDetalleKardexContratosDirectos();
            }
        }

        private void dgwComPenLiq_SelectionChanged(object sender, EventArgs e)
        {
            if (dgwComPenLiq.Rows.Count > 0)
            {
                if (dgwComPenLiq.CurrentRow.Cells["NRO_CONTRATO"].Value != null)
                {
                    llenaDetalleContratosVencidosxTransferir();
                    llenaDetalleKardexContratosDirectos();
                }
            }
        }
        private void llenaDetalleContratosVencidosxTransferir()
        {
            dgwComPenLiqDet.Rows.Clear();//detalle Comisiones Generadas
            string nro_contrato = dgwComPenLiq.CurrentRow.Cells["NRO_CONTRATO"].Value.ToString();//cabecera Comisiones Generadas
            DataTable dtDetalle = null;
            if (dtContratosxVencerCuotas.Rows.Count > 0)
            {
                DataRow[] fila = dtContratosxVencerCuotas.Select("NRO_CONTRATO = '" + nro_contrato + "'");
                if (fila.Length > 0)
                {
                    dtDetalle = fila.CopyToDataTable();
                    if (dtDetalle.Rows.Count > 0)
                    {
                        foreach (DataRow rw in dtDetalle.Rows)
                        {
                            int rowId = dgwComPenLiqDet.Rows.Add();
                            DataGridViewRow row = dgwComPenLiqDet.Rows[rowId];
                            row.Cells["NRO_CONTRATO1"].Value = rw["NRO_CONTRATO"].ToString();
                            row.Cells["FECHA_VENCIMIENTO1"].Value = rw["FECHA_VEN"].ToString().Substring(0, 10);
                            row.Cells["IMP_DOC1"].Value = rw["IMP_DOC"].ToString();
                            row.Cells["NRO_CUOTA1"].Value = rw["LETRA"].ToString();
                        }
                    }
                }
                else
                    dgwComPenLiqDet.Rows.Clear();
            }
            else
                dgwComPenLiqDet.Rows.Clear();
        }
        private void llenaDetalleKardexContratosDirectos()
        {
            dgwKardexContratos.Rows.Clear();//detalle Comisiones Generadas
            string nro_contrato = dgwComPenLiq.CurrentRow.Cells["NRO_CONTRATO"].Value.ToString();//cabecera Comisiones Generadas
            DataTable dtDetalle = null;
            if (dtKardexHistorico.Rows.Count > 0)
            {
                DataRow[] fila = dtKardexHistorico.Select("NRO_CONTRATO = '" + nro_contrato + "'");
                if (fila.Length > 0)
                {
                    dtDetalle = fila.CopyToDataTable();
                    if (dtDetalle.Rows.Count > 0)
                    {
                        foreach (DataRow rw in dtDetalle.Rows)
                        {
                            int rowId = dgwKardexContratos.Rows.Add();
                            DataGridViewRow row = dgwKardexContratos.Rows[rowId];
                            row.Cells["NRO_CONTRATO2"].Value = rw["NRO_CONTRATO"].ToString();
                            row.Cells["NRO_DOC"].Value = rw["NRO_DOC"].ToString().Substring(0, 7);
                            row.Cells["FECHA_DOC"].Value = rw["FECHA_DOC"].ToString().Substring(0, 10);
                            row.Cells["FECHA_VEN"].Value = rw["FECHA_VEN"].ToString().Substring(0, 10);
                            row.Cells["CUOTA"].Value = rw["CUOTA"].ToString();
                            row.Cells["COD_D_H"].Value = rw["COD_D_H"].ToString();
                            row.Cells["IMP_DOC"].Value = rw["IMP_DOC"].ToString();
                            row.Cells["OBSERVACION"].Value = rw["OBSERVACION"].ToString();
                        }
                    }
                }
                else
                    dgwKardexContratos.Rows.Clear();
            }
            else
                dgwKardexContratos.Rows.Clear();
        }
        private void dgwComPenLiq_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (dgwComPenLiq.Columns[e.ColumnIndex].Name)
            {
                case "FEC_LLAMADA1":
                    _Rectangle = dgwComPenLiq.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                    dtp.Size = new Size(_Rectangle.Width, _Rectangle.Height);
                    dtp.Location = new Point(_Rectangle.X, _Rectangle.Y);
                    dtp.Visible = true;
                    dtp.Value = fec_activa;
                    break;
                default:
                    dtp.Visible = false;
                    break;
            }
        }
        private void dtp_TextChanged(object sender, EventArgs e)
        {
            dgwComPenLiq.CurrentCell.Value = dtp.Text.ToString();
            //if (Convert.ToBoolean(dgwComPenLiq.CurrentRow.Cells[10].Value))
            //    dtp.Enabled = false;
            //else
            //    dtp.Enabled = true;
        }

        private void dgwComPenLiq_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            dtp.Visible = false;
        }

        private void dgwComPenLiq_Scroll(object sender, ScrollEventArgs e)
        {
            dtp.Visible = false;
        }

        private void btn_Traer_Datos_Click(object sender, EventArgs e)
        {
            dgwComPenLiq.Rows.Clear();
            dgwComPenLiqDet.Rows.Clear();
            dgwKardexContratos.Rows.Clear();
            CONTRATOS_X_ASIGNAR();
        }

        private void dgwComPenLiq_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 10)
            {
                if (dgwComPenLiq.CurrentRow != null)
                {
                    if (Convert.ToBoolean(dgwComPenLiq.CurrentRow.Cells[10].Value))
                    {
                        if (dgwComPenLiq.CurrentRow.Cells["COD_GESTOR"].Value == null)
                        {
                            MessageBox.Show("Elija el gestor antes !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            dgwComPenLiq.CurrentRow.Cells[10].Value = false;
                            return;
                        }
                        if (dgwComPenLiq.CurrentRow.Cells["COD_GESTOR"].Value != null)
                        {
                            dgwComPenLiq[8, e.RowIndex].ReadOnly = true;
                            dgwComPenLiq[9, e.RowIndex].ReadOnly = true;
                            //dtp.Enabled = false;
                            sumaGestor(dgwComPenLiq.CurrentRow.Cells["COD_GESTOR"].Value.ToString());
                        }
                    }
                    else if (!Convert.ToBoolean(dgwComPenLiq.CurrentRow.Cells[10].Value))
                    {
                        if (dgwComPenLiq.CurrentRow.Cells["COD_GESTOR"].Value != null)
                        {
                            if (dgwComPenLiq.CurrentRow.Cells["COD_GESTOR"].Value != null)
                            {
                                dgwComPenLiq[8, e.RowIndex].ReadOnly = false;
                                dgwComPenLiq[9, e.RowIndex].ReadOnly = false;
                                //dtp.Enabled = true;
                                restaGestor(dgwComPenLiq.CurrentRow.Cells["COD_GESTOR"].Value.ToString());
                            }

                        }
                    }
                    else
                    {
                        dgwComPenLiq[8, e.RowIndex].ReadOnly = false;
                        dgwComPenLiq[9, e.RowIndex].ReadOnly = false;
                        //dtp.Enabled = false;
                    }
                }
            }

        }
        private void sumaGestor(string cod_gestor)
        {
            int id = dgwGestores.CurrentRow.Index;
            foreach (DataGridViewRow row in dgwGestores.Rows)
            {
                if (row.Cells["COD_PERSONA"].Value.ToString() == cod_gestor)
                {
                    row.Cells["CANT"].Value = Convert.ToInt32(row.Cells["CANT"].Value) + 1;
                }
            }
        }
        private void restaGestor(string cod_gestor)
        {
            int id = dgwGestores.CurrentRow.Index;
            foreach (DataGridViewRow row in dgwGestores.Rows)
            {
                if (row.Cells["COD_PERSONA"].Value.ToString() == cod_gestor)
                {
                    row.Cells["CANT"].Value = Convert.ToInt32(row.Cells["CANT"].Value) - 1;
                }
            }
        }
        private void btn_grabar_Click(object sender, EventArgs e)
        {
            if (!validaGrabar())
                return;

            DialogResult rs = MessageBox.Show("¿ Esta seguro de hacer el traslado ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                ddTo.FE_AÑO = AÑO;
                ddTo.FE_MES = MES;
                ddTo.COD_SECTORISTA = cbo_sectorista.SelectedValue.ToString();
                ddTo.MESES_MOROSIDAD = Convert.ToInt32(txt_mes_mor.Text);
                ddTo.COD_USU_CREA = COD_USU;
                ddTo.FECHA_USU_CREA = DateTime.Now;
                DataTable dtDetalle = HelpersBLL.obtenerDTX(dgwComPenLiq);
                if (!ddBLL.adiciona_ILlamadas_CobranzaDirectaBLL(ddTo, dtDetalle, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Los contratos se trasladaron correctamente !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TabControl1.SelectedTab = TabPage1;
                    CONTRATOS_X_ASIGNAR();
                }
            }
        }
        private bool validaGrabar()
        {
            bool result = true;

            return result;
        }

        private void dgwComPenLiq_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgwComPenLiq.IsCurrentCellDirty)
            {
                dgwComPenLiq.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

    }
}
