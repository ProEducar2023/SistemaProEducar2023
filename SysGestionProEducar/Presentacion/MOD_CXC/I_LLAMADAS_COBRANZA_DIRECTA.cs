using BLL;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;
namespace Presentacion.MOD_CXC
{
    public partial class I_LLAMADAS_COBRANZA_DIRECTA : Form
    {
        calendarioBLL calBLL = new calendarioBLL();
        calendarioTo calTo = new calendarioTo();
        string AÑO, MES, COD_MOD, TIPO_USU, COD_USU;
        DateTime FECHA_INI, FECHA_GRAL;
        DataTable dtDet = new DataTable();
        descuentoDirectoBLL ddBLL = new descuentoDirectoBLL();
        descuentoDirectaTo ddTo = new descuentoDirectaTo();
        descuentoDirectaSeguimientoBLL ddsBLL = new descuentoDirectaSeguimientoBLL();
        descuentoDirectaSeguimientoTo ddsTo = new descuentoDirectaSeguimientoTo();
        progNivelBLL prnBLL = new progNivelBLL();
        progNivelTo prnTo = new progNivelTo();
        DataTable dtContratosxVencerCuotas, dtKardexHistorico, dtGestores, dtSeguimiento;
        DateTime? fec_com_pago = null; string observaciones = "";
        string nro_contrato; string cod_persona; string cod_gestor; string cod_motivo_llamada;
        DateTime fecha_operacion_llamada; DateTime? fecha_compromiso_pago; string observacion; decimal importe_pago;
        DateTime? fecha_deposito; string nro_operacion; string institucion_bancaria; string cod_usu;
        frmI_LlamadasSeguimiento frm;
        DIALOGOS.Dialog3 obs = new DIALOGOS.Dialog3();
        public I_LLAMADAS_COBRANZA_DIRECTA(string AÑO, string MES, DateTime FECHA_INI, DateTime FECHA_GRAL, string COD_MOD, string TIPO_USU, string COD_USU)
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

        private void I_LLAMADAS_COBRANZA_DIRECTA_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            //lbl_fec_llamada.Text = DateTime.Now.AddMonths(6).AddDays(1).ToShortDateString();
            calTo.TIPO = "D";
            lbl_fec_llamada.Text = Convert.ToDateTime(calBLL.obtenerFechaActivaBLL(calTo)).ToShortDateString();
            //dtp_vcto.Value = Convert.ToDateTime(lbl_fec_llamada.Text);
            CARGAR_MES_MOROSIDAD_DEFAULT();
            CARGAR_GESTOR();
        }
        private void CARGAR_MES_MOROSIDAD_DEFAULT()
        {
            string mes = HelpersBLL.OBTENER_DES_DIRECTORIO(null, "TMORM");
            txt_mes_mor.Text = mes;
        }
        public void CARGAR_MOTIVO_LLAMADAS()
        {
            DataGridViewComboBoxColumn comboboxColumn = dgw_llamadas.Columns["COD_MOTIVO"] as DataGridViewComboBoxColumn;
            motivoLlamadasDescCobDirBLL mlBLL = new motivoLlamadasDescCobDirBLL();
            motivoLlamadasDescCobDirTo mlTo = new motivoLlamadasDescCobDirTo();
            mlTo.CATEGORIA = "1";
            DataTable dtMotivo = mlBLL.obtenerMotivoLlamadasDescCobDirBLL(mlTo);
            comboboxColumn.DataSource = dtMotivo;
            comboboxColumn.DisplayMember = "DESC_MOTIVO";
            comboboxColumn.ValueMember = "COD_MOTIVO";
            // bindeo los datos de los productos a la grilla 
            dgw_llamadas.AutoGenerateColumns = false;
        }
        private void CARGAR_GESTOR()
        {
            prnTo.COD_PER = null;//para que aparezcan todos los gestores sin importar el sectorista.
            prnTo.COD_NIVEL = "03";//02 cobrador, 03 gestor
            dtGestores = prnBLL.obtenerCobradoresxSectoristaBLL(prnTo);
            cbo_gestor.DataSource = dtGestores;
            cbo_gestor.DisplayMember = "DESC_EQVTA";
            cbo_gestor.ValueMember = "COD_EQCOB";
            //cbo_gestor.SelectedIndex = 0;
        }
        private void DATAGRID()
        {
            ////pldTo.FECHA_LLAMADA = DateTime.Now.AddMonths(6).AddDays(1);
            //ddTo.TIPO = TIPO;
            dgw_llamadas.Rows.Clear();
            dgwComPenLiqDet.Rows.Clear();
            dgwKardexContratos.Rows.Clear();
            dgw_seguimiento.Rows.Clear();
            ddTo.FECHA_LLAMADA = Convert.ToDateTime(calBLL.obtenerFechaActivaBLL(calTo));
            ddTo.COD_GESTOR = cbo_gestor.SelectedValue.ToString();//dtGestores.Rows[0][0].ToString();
            ddTo.MESES_MOROSIDAD = Convert.ToInt32(txt_mes_mor.Text);
            DataTable dt = ddBLL.obtenerContratos_x_LlamarBLL(ddTo);//pldBLL.obtenerPlanillaDirectaBLL(pldTo);
            if (dt.Rows.Count > 0)
            {
                //DGW.DataSource = dt;
                dtDet = dt;
                dgw_llamadas.Rows.Clear();
                foreach (DataRow rw in dt.Rows)
                {
                    int rowId = dgw_llamadas.Rows.Add();
                    DataGridViewRow row = dgw_llamadas.Rows[rowId];
                    row.Cells["NRO_CONTRATO"].Value = rw["NRO_CONTRATO"].ToString();
                    row.Cells["FECHA_CONTRATO"].Value = rw["FECHA_CONTRATO"].ToString().Substring(0, 10);
                    row.Cells["COD_PERSONA"].Value = rw["COD_PERSONA"].ToString();
                    row.Cells["DESC_PER"].Value = rw["DESC_PER"].ToString();
                    row.Cells["DNI2"].Value = rw["NRO_DOC"].ToString();
                    row.Cells["COD_GESTOR"].Value = rw["COD_GESTOR"].ToString();
                    row.Cells["COD_MOTIVO"].Value = rw["COD_MOTIVO_LLAMADA"].ToString();
                    row.Cells["DESC_MOTIVO"].Value = rw["DESC_MOTIVO_LLAMADA"].ToString();
                    row.Cells["FECHA_OPERACION_LLAMADA"].Value = rw["FECHA_OPERACION_LLAMADA"].ToString();
                    row.Cells["FECHA_COMPROMISO_PAGO"].Value = rw["FECHA_COMPROMISO_PAGO"].ToString() != "" ? rw["FECHA_COMPROMISO_PAGO"].ToString().Substring(0, 10) : rw["FECHA_COMPROMISO_PAGO"].ToString();
                    row.Cells["OBSERVACIONES2"].Value = rw["OBSERVACIONES"].ToString();
                    row.Cells["IMPORTE_PAGO"].Value = rw["IMPORTE_PAGO"].ToString();
                    row.Cells["FECHA_DEPOSITO"].Value = rw["FECHA_DEPOSITO"].ToString();
                    row.Cells["NRO_OPERACIONES"].Value = rw["NRO_OPERACION"].ToString();
                    row.Cells["INSTITUCION_BANCARIA"].Value = rw["INSTITUCION_BANCARIA"].ToString();
                    row.Cells["COD_USU2"].Value = COD_USU;
                    //row.Cells["FECHA_NUEVA_LLAMADA"].Value = rw["FECHA_NUEVA_LLAMADA"].ToString();
                }
                //DISEÑO_GRID();
                //CALCULOS_TOTALES();
            }
            lbl_nro_reg.Text = "Nro de Registros : " + dgw_llamadas.Rows.Count.ToString();
            dtContratosxVencerCuotas = ddBLL.obtenerContratos_x_Asignar_CuotasBLL(ddTo);
            dtKardexHistorico = ddBLL.obtenerKardexContratosDirectosBLL(ddTo);
            dtSeguimiento = ddBLL.obtenerSeguimiento_x_NroCotratoBLL(ddTo);
            dgw_llamadas.Select();
        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dgw_llamadas_Click(object sender, EventArgs e)
        {
            if (dgw_llamadas.Rows.Count > 0)
            {
                llenaDetalleContratosVencidosxTransferir();
                llenaDetalleKardexContratosDirectos();
                llenaSeguimientoxNroContrato();
            }
        }

        private void dgw_llamadas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgw_llamadas.Rows.Count > 0)
            {
                if (dgw_llamadas.CurrentRow.Cells["NRO_CONTRATO"].Value != null)
                {
                    llenaDetalleContratosVencidosxTransferir();
                    llenaDetalleKardexContratosDirectos();
                    llenaSeguimientoxNroContrato();
                }
            }
        }
        private void llenaDetalleContratosVencidosxTransferir()
        {
            dgwComPenLiqDet.Rows.Clear();//detalle Comisiones Generadas
            string contrato = dgw_llamadas.CurrentRow.Cells["NRO_CONTRATO"].Value.ToString();
            DataTable dtDetalle = null;
            if (dtContratosxVencerCuotas.Rows.Count > 0)
            {
                DataRow[] fila = dtContratosxVencerCuotas.Select("NRO_CONTRATO = '" + contrato + "'");
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
            string nro_contrato = dgw_llamadas.CurrentRow.Cells["NRO_CONTRATO"].Value.ToString();//cabecera Comisiones Generadas
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
                            row.Cells["OBS"].Value = rw["OBSERVACION"].ToString();
                        }
                    }
                }
                else
                    dgwKardexContratos.Rows.Clear();
            }
            else
                dgwKardexContratos.Rows.Clear();
        }
        private void llenaSeguimientoxNroContrato()
        {
            dgw_seguimiento.Rows.Clear();//detalle Comisiones Generadas
            string contrato = dgw_llamadas.CurrentRow.Cells["NRO_CONTRATO"].Value.ToString();
            string cod_persona = dgw_llamadas.CurrentRow.Cells["COD_PERSONA"].Value.ToString();
            DataTable dtDetalle = null;
            if (dtSeguimiento.Rows.Count > 0)
            {
                DataRow[] fila = dtSeguimiento.Select("NRO_CONTRATO = '" + contrato + "' AND COD_PERSONA = '" + cod_persona + "'");
                if (fila.Length > 0)
                {
                    dtDetalle = fila.CopyToDataTable();
                    if (dtDetalle.Rows.Count > 0)
                    {
                        foreach (DataRow rw in dtDetalle.Rows)
                        {
                            int rowId = dgw_seguimiento.Rows.Add();
                            DataGridViewRow row = dgw_seguimiento.Rows[rowId];
                            row.Cells["NRO_CONTRATO3"].Value = rw["NRO_CONTRATO"].ToString();
                            row.Cells["COD_PERSONA3"].Value = rw["COD_PERSONA"].ToString();
                            row.Cells["DESC_MOTIVO3"].Value = rw["DESC_MOTIVO"].ToString();
                            row.Cells["FECHA_COMPROMISO_PAGO3"].Value = rw["FECHA_COMPROMISO_PAGO"].ToString().Substring(0, 10);
                            row.Cells["OBSERVACIONES3"].Value = rw["OBSERVACIONES"].ToString();
                            row.Cells["IMPORTE_PAGO3"].Value = rw["IMPORTE_PAGO"].ToString();
                            row.Cells["FECHA_DEPOSITO3"].Value = rw["FECHA_DEPOSITO"].ToString() != "" ? rw["FECHA_DEPOSITO"].ToString().Substring(0, 10) : "";
                            row.Cells["NRO_OPERACION3"].Value = rw["NRO_OPERACION"].ToString();
                            row.Cells["INSTITUCION_BANCARIA3"].Value = rw["INSTITUCION_BANCARIA"].ToString();
                        }
                    }
                }
                else
                    dgw_seguimiento.Rows.Clear();
            }
            else
                dgw_seguimiento.Rows.Clear();
        }

        private void dgw_llamadas_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgw_llamadas.IsCurrentCellDirty)
            {
                dgw_llamadas.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DATAGRID();
        }

        private void dgw_llamadas_DoubleClick(object sender, EventArgs e)
        {
            if (dgw_llamadas.CurrentRow != null)
            {
                DateTime fec_operacion_llamada = Convert.ToDateTime(lbl_fec_llamada.Text);
                DateTime fec_compromiso_pago;
                DateTime fec_deposito;
                decimal imp_pago = 0;
                nro_contrato = dgw_llamadas.CurrentRow.Cells["NRO_CONTRATO"].Value.ToString();
                cod_persona = dgw_llamadas.CurrentRow.Cells["COD_PERSONA"].Value.ToString();
                cod_gestor = dgw_llamadas.CurrentRow.Cells["COD_GESTOR"].Value.ToString() == "" ? cbo_gestor.SelectedValue.ToString() : dgw_llamadas.CurrentRow.Cells["COD_GESTOR"].Value.ToString();
                cod_motivo_llamada = dgw_llamadas.CurrentRow.Cells["COD_MOTIVO"].Value.ToString();
                fecha_operacion_llamada = dgw_llamadas.CurrentRow.Cells["FECHA_OPERACION_LLAMADA"].Value.ToString() != "" ? Convert.ToDateTime(Convert.ToDateTime(dgw_llamadas.CurrentRow.Cells["FECHA_OPERACION_LLAMADA"].Value)) : fec_operacion_llamada;
                fecha_compromiso_pago = DateTime.TryParse(dgw_llamadas.CurrentRow.Cells["FECHA_COMPROMISO_PAGO"].Value.ToString(), out fec_compromiso_pago) ? Convert.ToDateTime(dgw_llamadas.CurrentRow.Cells["FECHA_COMPROMISO_PAGO"].Value) : (DateTime?)null;
                observacion = dgw_llamadas.CurrentRow.Cells["OBSERVACIONES2"].Value.ToString();
                importe_pago = decimal.TryParse(dgw_llamadas.CurrentRow.Cells["IMPORTE_PAGO"].Value.ToString(), out imp_pago) ? Convert.ToDecimal(dgw_llamadas.CurrentRow.Cells["IMPORTE_PAGO"].Value) : 0;
                fecha_deposito = DateTime.TryParse(dgw_llamadas.CurrentRow.Cells["FECHA_DEPOSITO"].Value.ToString(), out fec_deposito) ? Convert.ToDateTime(dgw_llamadas.CurrentRow.Cells["FECHA_DEPOSITO"].Value) : (DateTime?)null;
                nro_operacion = dgw_llamadas.CurrentRow.Cells["NRO_OPERACIONES"].Value.ToString();
                institucion_bancaria = dgw_llamadas.CurrentRow.Cells["INSTITUCION_BANCARIA"].Value.ToString();
                cod_usu = dgw_llamadas.CurrentRow.Cells["COD_USU2"].Value.ToString();
                frm = new frmI_LlamadasSeguimiento(nro_contrato, cod_persona, cod_gestor, cod_motivo_llamada,
                    fecha_operacion_llamada, fecha_compromiso_pago, observacion, importe_pago, fecha_deposito,
                    nro_operacion, institucion_bancaria, cod_usu, AÑO, MES);
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    dgw_llamadas.CurrentRow.Cells["COD_MOTIVO"].Value = frm.cbo_motivo.SelectedValue.ToString();
                    dgw_llamadas.CurrentRow.Cells["DESC_MOTIVO"].Value = frm.cbo_motivo.Text;
                    dgw_llamadas.CurrentRow.Cells["FECHA_COMPROMISO_PAGO"].Value = frm.dtp_fec_com_pago.Value.ToShortDateString();
                    dgw_llamadas.CurrentRow.Cells["OBSERVACIONES2"].Value = frm.txt_observaciones.Text;
                    dgw_llamadas.CurrentRow.Cells["IMPORTE_PAGO"].Value = frm.txt_imp_pago.Text;
                    dgw_llamadas.CurrentRow.Cells["NRO_OPERACIONES"].Value = frm.txt_nro_operacion.Text;
                    dgw_llamadas.CurrentRow.Cells["FECHA_DEPOSITO"].Value = frm.dtp_fec_deposito.Value.ToShortDateString();
                    dgw_llamadas.CurrentRow.Cells["INSTITUCION_BANCARIA"].Value = frm.cbo_banco.SelectedValue != null ? frm.cbo_banco.SelectedValue.ToString() : "";
                    //////
                    ////foreach(DataGridViewRow fila in dgw_llamadas.Rows)
                    ////{
                    ////    if(fila.Cells["NRO_CONTRATO3"].Value.ToString()==nro_contrato && fila.Cells["COD_PERSONA3"].Value.ToString()==cod_persona)
                    ////    {

                    ////    }
                    ////}
                    //int rowId = dgw_seguimiento.Rows.Add();
                    //DataGridViewRow row = dgw_seguimiento.Rows[rowId];
                    //row.Cells["NRO_CONTRATO3"].Value = nro_contrato;
                    //row.Cells["COD_PERSONA3"].Value = cod_persona;
                    //row.Cells["DESC_MOTIVO3"].Value = dgw_llamadas.CurrentRow.Cells["DESC_MOTIVO"].Value.ToString();
                    //row.Cells["FECHA_COMPROMISO_PAGO3"].Value = dgw_llamadas.CurrentRow.Cells["FECHA_COMPROMISO_PAGO"].Value.ToString();
                    //row.Cells["OBSERVACIONES3"].Value = dgw_llamadas.CurrentRow.Cells["OBSERVACIONES2"].Value.ToString();
                    //row.Cells["IMPORTE_PAGO3"].Value = dgw_llamadas.CurrentRow.Cells["IMPORTE_PAGO"].Value.ToString();
                    //row.Cells["FECHA_DEPOSITO3"].Value = dgw_llamadas.CurrentRow.Cells["FECHA_DEPOSITO"].Value.ToString();
                    //row.Cells["INSTITUCION_BANCARIA3"].Value = dgw_llamadas.CurrentRow.Cells["INSTITUCION_BANCARIA"].Value.ToString();
                    //
                    //DataRow rw = dtSeguimiento.NewRow();
                    //rw["NRO_CONTRATO"] = nro_contrato;
                    //rw["COD_PERSONA"] = cod_persona ;
                    //rw["COD_MOTIVO_LLAMADA"] = dgw_llamadas.CurrentRow.Cells["COD_MOTIVO"].Value.ToString();
                    //rw["DESC_MOTIVO"] = dgw_llamadas.CurrentRow.Cells["DESC_MOTIVO"].Value.ToString();
                    //rw["FECHA_COMPROMISO_PAGO"] = dgw_llamadas.CurrentRow.Cells["FECHA_COMPROMISO_PAGO"].Value.ToString().Substring(0,10);
                    //rw["OBSERVACIONES"] = dgw_llamadas.CurrentRow.Cells["OBSERVACIONES2"].Value.ToString();
                    //rw["IMPORTE_PAGO"] = dgw_llamadas.CurrentRow.Cells["IMPORTE_PAGO"].Value.ToString();
                    //rw["FECHA_DEPOSITO"] = dgw_llamadas.CurrentRow.Cells["FECHA_DEPOSITO"].Value.ToString();
                    //rw["NRO_OPERACION"] = dgw_llamadas.CurrentRow.Cells["NRO_OPERACIONES"].Value.ToString();
                    //rw["INSTITUCION_BANCARIA"] = dgw_llamadas.CurrentRow.Cells["INSTITUCION_BANCARIA"].Value.ToString();
                    //dtSeguimiento.Rows.InsertAt(rw, 0);
                    ddTo.FECHA_LLAMADA = Convert.ToDateTime(calBLL.obtenerFechaActivaBLL(calTo));
                    ddTo.COD_GESTOR = cbo_gestor.SelectedValue.ToString();
                    dtSeguimiento = ddBLL.obtenerSeguimiento_x_NroCotratoBLL(ddTo);
                    llenaSeguimientoxNroContrato();
                }
            }
        }

        private void lbl_datos_cliente_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string cod_per = dgw_llamadas.CurrentRow.Cells["COD_PERSONA"].Value.ToString();
            MOD_ADM.PERSONA frm = new MOD_ADM.PERSONA(2, cod_per);
            frm.ShowDialog();
        }
        private void btn_cierre_preliminar_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgw_llamadas.Rows)
            {
                if (row.Cells["DESC_MOTIVO"].Value.ToString() == "")
                {
                    MessageBox.Show("Se encontró un registro sin Motivo !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dgw_llamadas.CurrentCell = row.Cells[0];
                    return;
                }
                if (Convert.ToDateTime(row.Cells["FECHA_COMPROMISO_PAGO"].Value) <= Convert.ToDateTime(lbl_fec_llamada.Text))
                {
                    MessageBox.Show("No se pudo cerrar el dia correctamente\n El gestor : " +
                        cbo_gestor.Text + "\nno ha elegido bien la fecha de Nueva Llamada para \n Contrato : " + row.Cells["NRO_CONTRATO"].Value.ToString() +
                        "\nCliente : " + row.Cells["DESC_PER"].Value.ToString() + " !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            MessageBox.Show("Todas los registros tienen un Motivo !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void dgw_seguimiento_DoubleClick(object sender, EventArgs e)
        {
            if (dgw_seguimiento.Rows.Count > 0)
            {
                obs.txt_obs.Clear();
                obs.txt_obs.Text = dgw_seguimiento.CurrentRow.Cells["OBSERVACIONES3"].Value.ToString();
                obs.ShowDialog();
            }
        }
    }
}
