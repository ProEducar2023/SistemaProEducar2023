using BLL;
using Entidades;
using System;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Presentacion.MOD_COS
{
    public partial class COSTO_TRANSFERENCIA : Form
    {
        string AÑO = "", MES = "", COD_MOD = "", COD_USU = "", TIPO_USU = "";
        DateTime FECHA_INI, FECHA_GRAL;
        string COD_CLASE, NRO_DOC_INV0, STATUS_VAL0, STATUS_MOV, OBS0, NRO_DOC0, NRO_DOC_PER0, COD_SUCURSAL, COD_PER0, COD_MOV0, COD_DOC_INV0, COD_DOC0, COD_MONEDA0, COD_MOV;
        DateTime FECHA_DOC_INV0, FECHA_DOC0;
        decimal TC0;
        inventariosBLL invBLL = new inventariosBLL();
        inventariosTo invTo = new inventariosTo();
        tCostosBLL tcosBLL = new tCostosBLL();
        tCostosTo tcosTo = new tCostosTo();
        facturacionVtaCabeceraBLL factBLL = new facturacionVtaCabeceraBLL();
        facturacionVtaCabeceraTo fccTo = new facturacionVtaCabeceraTo();
        public COSTO_TRANSFERENCIA(string AÑO, string MES, DateTime FECHA_INI, DateTime FECHA_GRAL, string COD_MOD, string TIPO_USU, string COD_USU)
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

        private void COSTO_TRANSFERENCIA_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            //Dim emp00 As String = OBJ.DIR_TABLA_DESC("GCO_BD", "TDTRA")
            //CON_GCO = New SqlConnection("data source=" & nombre_servidor & ";initial catalog=BD_GCO" & emp00 & ";uid=miguel;pwd=main;")
            CBO_MES.Text = MES;
            CBO_MES2.Text = MES;
            CARGAR_AÑO();
            CBO_AÑO.Text = AÑO;
            CBO_AÑO2.Text = AÑO;
            CARGAR_MOVIMIENTO();
            CARGAR_CLASE_ARTICULO();
            //DGW_DET.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
            //DGW_DET2.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
        }
        private void CARGAR_AÑO()
        {
            periodoBLL perBLL = new periodoBLL();
            periodoTo perTo = new periodoTo();
            //
            CBO_AÑO.Items.Clear();
            CBO_AÑO2.Items.Clear();
            perTo.COD_MODULO = "COS";
            DataTable dt = perBLL.obtenerAñoPeriodoBLL(perTo);
            DataTable dt1 = perBLL.obtenerAñoPeriodoBLL(perTo);
            CBO_AÑO.ValueMember = "AÑO";
            CBO_AÑO.DisplayMember = "AÑO";
            CBO_AÑO.DataSource = dt;
            CBO_AÑO2.ValueMember = "AÑO";
            CBO_AÑO2.DisplayMember = "AÑO";
            CBO_AÑO2.DataSource = dt1;
        }
        private void CARGAR_MOVIMIENTO()
        {
            movimientosBLL movBLL = new movimientosBLL();
            movimientosTo movTo = new movimientosTo();
            //
            cbo_mov.Items.Clear();
            CBO_MOV2.Items.Clear();
            DataTable dt = movBLL.obtenerMovimientosCostosBLL();
            cbo_mov.ValueMember = "COD_MOV";
            cbo_mov.DisplayMember = "DESC_MOV";
            cbo_mov.DataSource = dt;
            cbo_mov.SelectedIndex = -1;
            //
            DataTable dt1 = movBLL.obtenerMovimientosCostosBLL();
            CBO_MOV2.ValueMember = "COD_MOV";
            CBO_MOV2.DisplayMember = "DESC_MOV";
            CBO_MOV2.DataSource = dt1;
            CBO_MOV2.SelectedIndex = -1;
        }
        private void CARGAR_CLASE_ARTICULO()
        {
            articuloClaseBLL clsBLL = new articuloClaseBLL();
            articuloClaseTo clsTo = new articuloClaseTo();
            clsTo.COD_USU = COD_USU;
            clsTo.TIPO_USU = TIPO_USU;
            DataTable dt = clsBLL.obtenerArticuloClaseparaCostosBLL(clsTo);
            DataTable dt1 = clsBLL.obtenerArticuloClaseparaCostosBLL(clsTo);
            cbo_clase.DataSource = dt;
            cbo_clase.DisplayMember = "DESC_CLASE";
            cbo_clase.ValueMember = "COD_CLASE";
            cbo_clase.SelectedIndex = -1;
            CBO_CLASE2.DataSource = dt1;
            CBO_CLASE2.DisplayMember = "DESC_CLASE";
            CBO_CLASE2.ValueMember = "COD_CLASE";
            CBO_CLASE2.SelectedIndex = -1;
        }

        private void CBO_MES_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBO_MES.SelectedIndex > -1)
            {
                LBL_MES.Text = HelpersBLL.OBTENER_NOM_MES(CBO_MES.Text);
            }
        }

        private void CBO_MES2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBO_MES2.SelectedIndex > -1)
            {
                LBL_MES2.Text = HelpersBLL.OBTENER_NOM_MES(CBO_MES2.Text);
            }
        }

        private void ch_mov_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_mov.Checked)
            {
                cbo_mov.Enabled = true;
            }
            else
            {
                cbo_mov.SelectedIndex = -1;
                cbo_mov.Enabled = false;
            }
        }

        private void CH_MOV2_CheckedChanged(object sender, EventArgs e)
        {
            if (CH_MOV2.Checked)
            {
                CBO_MOV2.Enabled = true;
            }
            else
            {
                CBO_MOV2.SelectedIndex = -1;
                CBO_MOV2.Enabled = false;
            }
        }
        private void btn_aceptar1_Click(object sender, EventArgs e)
        {
            if (!validaAceptar("Aceptar"))
                return;

            if (ch_mov.Checked == false)
            {
                STATUS_MOV = "1";
                COD_MOV = "";
            }
            else
            {
                STATUS_MOV = "0";
                COD_MOV = cbo_mov.SelectedValue.ToString();
            }
            CARGAR_DETALLES();
            DGW_DET.Sort(DGW_DET.Columns[4], System.ComponentModel.ListSortDirection.Ascending);
            ch_TODO.Checked = false;
        }
        private void CARGAR_DETALLES()
        {
            DGW_DET.Rows.Clear();
            DataTable dt;
            if (ch_st.Checked)
            {
                fccTo.COD_CLASE = cbo_clase.SelectedValue.ToString();
                fccTo.COD_MOV = ch_mov.Enabled ? COD_MOV : null;
                fccTo.STATUS_MOV = STATUS_MOV;
                fccTo.FE_AÑO = CBO_AÑO.SelectedValue.ToString();
                fccTo.FE_MES = CBO_MES.Text;
                dt = factBLL.obtenerFacturacionparaCostoTransferenciaBLL(fccTo);
            }
            else
            {
                invTo.COD_CLASE = cbo_clase.SelectedValue.ToString();
                invTo.COD_MOV = ch_mov.Enabled ? COD_MOV : null;
                invTo.STATUS_MOV = STATUS_MOV;
                invTo.FE_AÑO = CBO_AÑO.SelectedValue.ToString();
                invTo.FE_MES = CBO_MES.Text;
                dt = invBLL.obtenerDetalleparaCostoTransferenciaBLL(invTo);
            }
            if (dt.Rows.Count > 0)
            {
                DGW_DET.Rows.Clear();
                foreach (DataRow rw in dt.Rows)
                {
                    int rowid = DGW_DET.Rows.Add();
                    DataGridViewRow row = DGW_DET.Rows[rowid];
                    row.Cells[0].Value = rw["COD_DOC_INV"].ToString();
                    row.Cells[1].Value = rw["NRO_DOC_INV"].ToString();
                    row.Cells[2].Value = rw["COD_DOC"].ToString();
                    row.Cells[3].Value = rw["NRO_DOC"].ToString();
                    row.Cells[4].Value = rw["COD_MOV"].ToString();
                    row.Cells[5].Value = rw["COD_PER"].ToString();
                    row.Cells[6].Value = rw["DESC_PER"].ToString();
                    row.Cells[7].Value = false;
                    row.Cells[8].Value = rw["NRO_DOC_PER"].ToString();
                    row.Cells[9].Value = rw["FECHA_DOC_INV"].ToString().Substring(0, 10);
                    row.Cells[10].Value = rw["FECHA_DOC"].ToString().Substring(0, 10);
                    row.Cells[11].Value = rw["COD_MONEDA"].ToString();
                    row.Cells[12].Value = rw["tipo_cambio"];
                    row.Cells[13].Value = rw["OBSERVACION"].ToString();
                    row.Cells[14].Value = rw["valor_booleano"].ToString();
                    row.Cells[15].Value = rw["Tipo"].ToString();
                    row.Cells[16].Value = rw["COD_SUCURSAL"].ToString();
                    row.Cells[17].Value = rw["DESC_SUCURSAL"].ToString();
                }
            }
        }
        private bool validaAceptar(string op)
        {
            string errMensaje = "";
            bool result = true;
            if (CBO_MES.SelectedIndex <= -1)
            {
                MessageBox.Show("Elija el Mes !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                CBO_MES.Focus();
                return result = false;
            }
            if (CBO_AÑO.SelectedIndex <= -1)
            {
                MessageBox.Show("Elija el Año !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                CBO_AÑO.Focus();
                return result = false;
            }
            if (cbo_clase.SelectedIndex <= -1)
            {
                MessageBox.Show("Elija la Clase de Articulos !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_clase.Focus();
                return result = false;
            }
            if (ch_mov.Checked)
            {
                if (cbo_mov.SelectedIndex <= -1)
                {
                    MessageBox.Show("Elija el Movimiento !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cbo_mov.Focus();
                    return result = false;
                }
            }
            if (op == "Aceptar")
            {
                if (!VERIFICAR_CIERRE_PERIODO(CBO_AÑO.SelectedValue.ToString(), CBO_MES.Text, "COS", ref errMensaje))
                {
                    if (errMensaje != "")
                        MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        MessageBox.Show("No se puede realizar ningún proceso, el periodo se encuentra cerrado !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return result = false;
                    }
                }
            }

            return result;
        }
        private bool VERIFICAR_CIERRE_PERIODO(string AÑO0, string MES0, string MOD0, ref string errMensaje)
        {
            bool result = true;

            periodoBLL perBLL = new periodoBLL();
            periodoTo perTo = new periodoTo();
            perTo.AÑO = AÑO0;
            perTo.MES = MES0;
            perTo.COD_MODULO = MOD0;
            if (!perBLL.VERIFICAR_CIERRE_PERIODO_BLL(perTo, ref errMensaje))
                return result = false;
            return result;
        }


        private void ch_TODO_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_TODO.Checked)
            {
                int i = 0;
                int cont = DGW_DET.Rows.Count - 1;
                while (i <= cont)
                {
                    DGW_DET[7, i].Value = true;
                    i++;
                }
            }
            else
            {
                int i = 0;
                int cont = DGW_DET.Rows.Count - 1;
                while (i <= cont)
                {
                    DGW_DET[7, i].Value = false;
                    i++;
                }
            }
        }

        private void btn_TRansf_Click(object sender, EventArgs e)
        {
            if (!validaAceptar("Transferir"))
                return;

            DialogResult rs = MessageBox.Show("¿ Esta seguro de realizar la operación de Transferencia?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.No)
                return;
            int I = 0;
            int CONT = DGW_DET.Rows.Count - 1;
            while (I <= CONT)
            {
                if (Convert.ToBoolean(DGW_DET[7, I].Value))
                {
                    COD_MOV0 = DGW_DET[4, I].Value.ToString();
                    COD_DOC_INV0 = DGW_DET[0, I].Value.ToString();
                    NRO_DOC_INV0 = DGW_DET[1, I].Value.ToString();
                    COD_PER0 = DGW_DET[5, I].Value.ToString();
                    NRO_DOC_PER0 = DGW_DET[8, I].Value.ToString();
                    FECHA_DOC_INV0 = Convert.ToDateTime(DGW_DET[9, I].Value);
                    FECHA_DOC0 = Convert.ToDateTime(DGW_DET[10, I].Value);
                    COD_DOC0 = DGW_DET[2, I].Value.ToString();
                    NRO_DOC0 = DGW_DET[3, I].Value.ToString();
                    OBS0 = DGW_DET[13, I].Value.ToString();
                    TC0 = Convert.ToDecimal(DGW_DET[12, I].Value);
                    COD_MONEDA0 = DGW_DET[11, I].Value.ToString();
                    COD_SUCURSAL = DGW_DET[16, I].Value.ToString();
                    COD_CLASE = cbo_clase.SelectedValue.ToString();
                    STATUS_VAL0 = "0";
                    if (Convert.ToBoolean(DGW_DET[14, I].Value))
                        STATUS_VAL0 = "1";
                    MOSTRAR_DETALLES_COSTOS(CBO_AÑO.SelectedValue.ToString(), CBO_MES.Text);
                    if (VERIFICAR_VALORIZADOS(I) == false)
                    {
                        CARGAR_DETALLES();
                        return;
                    }
                    //if(HelpersBLL.HALLAR_TIPO_OP_MOV(COD_MOV0) == "P")
                    //{
                    //esto era si hubiese orden de produccion
                    //}
                    if (INSERTAR_COSTOS() == "FALLO")
                    {
                        MessageBox.Show("Ocurrió un error.", "Vuelva  a intetarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        CARGAR_DETALLES();
                        return;
                    }

                }
                I++;
            }
            MessageBox.Show("Operación satisfactoria !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private bool ACTUALIZAR_ESTADO(string ESTADO0, string AÑO0, string MES0, string COD_MOV0, string COD_DOC0, string NRO_DOC0, ref string errMensaje)
        {
            bool result = true;
            invTo.COD_SUCURSAL = COD_SUCURSAL;
            invTo.COD_CLASE = COD_CLASE;
            invTo.COD_DOC_INV = COD_DOC_INV0;
            invTo.NRO_DOC_INV = NRO_DOC_INV0;
            invTo.COD_PER = COD_PER0;
            invTo.NRO_DOC_PER = NRO_DOC_PER0;
            invTo.FE_AÑO = AÑO0;
            invTo.FE_MES = MES0;
            invTo.ESTADO = ESTADO0;
            invTo.COD_MOV = COD_MOV0;
            invTo.COD_DOC = COD_DOC0;
            invTo.NRO_DOC = NRO_DOC0;
            if (!invBLL.TRANSFERIR_COSTOS(invTo, ref errMensaje))
                return result = false;
            return result;
        }
        private string INSERTAR_COSTOS()
        {
            string errMensaje = "";
            string ESTADO0 = "EXITO";
            int I = 0;
            int CONT = DGW_DET1.Rows.Count - 1;
            while (I <= CONT)
            {
                decimal PRECIO_CON0 = 0, VALOR_CON0 = 0;
                if (COD_MONEDA0 == "S")
                {
                    PRECIO_CON0 = Convert.ToDecimal(DGW_DET1[3, I].Value);
                    VALOR_CON0 = Convert.ToDecimal(DGW_DET1[4, I].Value);
                }
                else
                {
                    VALOR_CON0 = Math.Round((Convert.ToDecimal(DGW_DET1[4, I].Value)) * (Convert.ToDecimal(TC0)), 2);
                    if (Convert.ToDecimal(DGW_DET1[2, I].Value) != 0)
                    {
                        try
                        {
                            PRECIO_CON0 = Math.Round((VALOR_CON0 / Convert.ToDecimal(DGW_DET1[2, I].Value)), 2);
                        }
                        catch (Exception)
                        {
                            PRECIO_CON0 = 0;
                        }
                    }
                }
                //string cod_act = DGW_DET1[15, I].Value.ToString();         //en el procedure de donde se obtiene esto ha sido modificado y hay menos columnas
                //if (DGW_DET1[11, I].Value.ToString() == "") cod_act = "";
                /////
                if (!insertarTCostos(I, PRECIO_CON0, VALOR_CON0, TC0, ref errMensaje))
                {
                    return ESTADO0 = "FALLO";
                }
                I++;
            }
            //
            if (!ACTUALIZAR_ESTADO("1", CBO_AÑO.Text, CBO_MES.Text, COD_MOV0, COD_DOC0, NRO_DOC0, ref errMensaje))
                return ESTADO0 = "FALLO";
            return ESTADO0;
        }
        private bool insertarTCostos(int I, decimal PRECIO_CON0, decimal VALOR_CON0, decimal TC0, ref string errMensaje)
        {
            bool result = true;
            tcosTo.COD_SUCURSAL = COD_SUCURSAL;
            tcosTo.COD_CLASE = COD_CLASE;
            tcosTo.COD_MOV = COD_MOV0;
            tcosTo.COD_DOC_INV = COD_DOC_INV0;
            tcosTo.NRO_DOC_INV = NRO_DOC_INV0;
            tcosTo.COD_PER = COD_PER0;
            tcosTo.NRO_DOC_PER = NRO_DOC_PER0;
            tcosTo.FE_AÑO = CBO_AÑO.Text;
            tcosTo.FE_MES = CBO_MES.Text;
            tcosTo.FECHA_DOC = FECHA_DOC0;
            tcosTo.FECHA_DOC_INV = FECHA_DOC_INV0;
            tcosTo.COD_DOC = "";// DGW_DET1[9, I].Value.ToString();
            tcosTo.NRO_DOC = DGW_DET1[9, I].Value.ToString();// DGW_DET1[10, I].Value.ToString();
            tcosTo.OBSERVACION = OBS0;
            tcosTo.TIPO_CAMBIO = TC0;
            tcosTo.COD_USU = COD_USU;
            tcosTo.FECHA_CREA = DateTime.Now;
            tcosTo.COD_MONEDA = COD_MONEDA0;
            tcosTo.STATUS_VAL = STATUS_VAL0;
            tcosTo.ITEM = (I + 1).ToString("00");
            tcosTo.NRO_ITEM = DGW_DET1[0, I].Value.ToString();
            tcosTo.COD_ARTICULO = DGW_DET1[1, I].Value.ToString();
            tcosTo.CANTIDAD = Convert.ToDecimal(DGW_DET1[2, I].Value);
            tcosTo.PRECIO_ACTUAL = Convert.ToDecimal(DGW_DET1[3, I].Value);
            tcosTo.VALOR_COSTO = Convert.ToDecimal(DGW_DET1[4, I].Value);
            tcosTo.PRECIO_CON = PRECIO_CON0;
            tcosTo.VALOR_CON = VALOR_CON0;
            tcosTo.COD_D_H = DGW_DET1[7, I].Value.ToString();
            tcosTo.COD_ALMACEN = DGW_DET1[8, I].Value.ToString();
            tcosTo.COD_REF = COD_DOC0;
            tcosTo.NRO_REF = NRO_DOC0;
            tcosTo.COD_CC = DGW_DET1[10, I].Value.ToString();// DGW_DET1[12, I].Value.ToString();
            tcosTo.PRECIO_CPROM = 0;

            if (!tcosBLL.insertarTCostosBLL(tcosTo, ref errMensaje))
                return result = false;
            I++;
            return result;
        }
        private bool VERIFICAR_VALORIZADOS(int I)
        {
            bool result = true;
            int i = 0, CONT = 0;
            CONT = DGW_DET1.Rows.Count - 1;
            for (i = 0; i <= CONT; i++)
            {
                if (STATUS_VAL0 == "1")
                {
                    if (DGW_DET1[4, I].Value.ToString() == "0")
                    {
                        MessageBox.Show("La Nota de Ingreso Nº  " + COD_DOC_INV0 + " - " + NRO_DOC_INV0 + "  del detalle de artículo " + DGW_DET1[1, I].Value.ToString() + " debe estar valorizada.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return result = false;
                    }
                }
            }
            return result;
        }
        private void MOSTRAR_DETALLES_COSTOS(string AÑO0, string MES0)
        {
            invTo.COD_SUCURSAL = COD_SUCURSAL;
            invTo.COD_CLASE = COD_CLASE;
            invTo.COD_MOV = COD_MOV0;
            //invTo.STATUS_MOV = STATUS_MOV;
            invTo.COD_DOC_INV = COD_DOC_INV0;
            invTo.NRO_DOC_INV = NRO_DOC_INV0;
            invTo.COD_PER = COD_PER0;
            invTo.NRO_DOC_PER = NRO_DOC_PER0;
            invTo.FE_AÑO = AÑO;
            invTo.FE_MES = MES0;
            invTo.FECHA_DOC_INV = FECHA_DOC_INV0;
            invTo.FECHA_DOC = FECHA_DOC0;
            invTo.COD_DOC = COD_DOC0;
            invTo.NRO_DOC = NRO_DOC0;
            invTo.OBSERVACION = OBS0;
            invTo.TIPO_CAMBIO = TC0;
            invTo.COD_USU = COD_USU;
            invTo.FECHA = DateTime.Now; ;
            invTo.COD_MONEDA = COD_MONEDA0;
            invTo.STATUS_VAL = STATUS_VAL0;
            DataTable dt = invBLL.obtenerDetallesCostosBLL(invTo);
            if (dt.Rows.Count > 0)
                DGW_DET1.DataSource = dt;

        }
        private void btn_aceptar2_Click(object sender, EventArgs e)
        {
            if (!validaAceptar2("Aceptar"))
                return;

            if (CH_MOV2.Checked == false)
            {
                STATUS_MOV = "1";
                COD_MOV = "";
            }
            else
            {
                STATUS_MOV = "0";
                COD_MOV = CBO_MOV2.SelectedValue.ToString();
            }
            CARGAR_DETALLES2();
            DGW_DET2.Sort(DGW_DET2.Columns[4], System.ComponentModel.ListSortDirection.Ascending);
            CH_TODO2.Checked = false;
        }
        private void CARGAR_DETALLES2()
        {
            DGW_DET2.Rows.Clear();
            invTo.COD_CLASE = CBO_CLASE2.SelectedValue.ToString();
            invTo.COD_MOV = COD_MOV;
            invTo.STATUS_MOV = STATUS_MOV;
            invTo.FE_AÑO = CBO_AÑO2.SelectedValue.ToString();
            invTo.FE_MES = CBO_MES2.Text;
            DataTable dt = invBLL.obtenerDetalleparaCostoTransferencia2BLL(invTo);
            if (dt.Rows.Count > 0)
            {
                DGW_DET2.Rows.Clear();
                foreach (DataRow rw in dt.Rows)
                {
                    int rowid = DGW_DET2.Rows.Add();
                    DataGridViewRow row = DGW_DET2.Rows[rowid];
                    row.Cells[0].Value = rw["COD_DOC_INV"].ToString();
                    row.Cells[1].Value = rw["NRO_DOC_INV"].ToString();
                    row.Cells[2].Value = rw["COD_DOC"].ToString();
                    row.Cells[3].Value = rw["NRO_DOC"].ToString();
                    row.Cells[4].Value = rw["COD_MOV"].ToString();
                    row.Cells[5].Value = rw["COD_PER"].ToString();
                    row.Cells[6].Value = rw["DESC_PER"].ToString();
                    row.Cells[7].Value = false;
                    row.Cells[8].Value = rw["NRO_DOC_PER"].ToString();
                    row.Cells[9].Value = rw["FECHA_DOC_INV"].ToString().Substring(0, 10);
                    row.Cells[10].Value = rw["FECHA_DOC"].ToString().Substring(0, 10);
                    row.Cells[11].Value = rw["COD_MONEDA"].ToString();
                    row.Cells[12].Value = rw["tipo_cambio"];
                    row.Cells[13].Value = rw["OBSERVACION"].ToString();
                    row.Cells[14].Value = rw["valor_booleano"].ToString();
                    row.Cells[15].Value = rw["Tipo"].ToString();
                    row.Cells[16].Value = rw["COD_SUCURSAL"].ToString();
                    row.Cells[17].Value = rw["DESC_SUCURSAL"].ToString();
                }
            }
        }
        private bool validaAceptar2(string op)
        {
            string errMensaje = "";
            bool result = true;
            if (CBO_MES2.SelectedIndex <= -1)
            {
                MessageBox.Show("Elija el Mes !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                CBO_MES2.Focus();
                return result = false;
            }
            if (CBO_AÑO2.SelectedIndex <= -1)
            {
                MessageBox.Show("Elija el Año !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                CBO_AÑO2.Focus();
                return result = false;
            }
            if (CBO_CLASE2.SelectedIndex <= -1)
            {
                MessageBox.Show("Elija la Clase de Articulos !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                CBO_CLASE2.Focus();
                return result = false;
            }
            if (CH_MOV2.Checked)
            {
                if (CBO_MOV2.SelectedIndex <= -1)
                {
                    MessageBox.Show("Elija el Movimiento !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    CBO_MOV2.Focus();
                    return result = false;
                }
            }

            if (op == "Aceptar")
            {
                if (!VERIFICAR_CIERRE_PERIODO(CBO_AÑO2.SelectedValue.ToString(), CBO_MES2.Text, "COS", ref errMensaje))
                {
                    if (errMensaje != "")
                        MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        MessageBox.Show("No se puede realizar ningún proceso, el periodo se encuentra cerrado !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return result = false;
                    }
                }
            }
            if (op == "DesTransferir")
            {
                //if (!VerificaOrdenPT_Costo()) //no esta completo hay revisar y preguntar del código original
                //    return result = false;
            }
            return result;
        }
        private bool VerificaOrdenPT_Costo()
        {
            bool result = true;
            StringBuilder SBCancela = new StringBuilder();
            SBCancela.Remove(0, SBCancela.Length);
            //bool _existe = false;
            tcosTo.FE_AÑO = CBO_AÑO2.Text;
            tcosTo.FE_MES = CBO_MES2.Text;
            tcosTo.COD_CLASE = COD_CLASE;
            DataTable dt = tcosBLL.VERIFICA_ORDEN_PT_COS(tcosTo);

            return result;
        }
        private void CH_TODO2_CheckedChanged(object sender, EventArgs e)
        {
            if (CH_TODO2.Checked)
            {
                int i = 0;
                int cont = DGW_DET2.Rows.Count - 1;
                while (i <= cont)
                {
                    DGW_DET2[7, i].Value = true;
                    i++;
                }
            }
            else
            {
                int i = 0;
                int cont = DGW_DET2.Rows.Count - 1;
                while (i <= cont)
                {
                    DGW_DET2[7, i].Value = false;
                    i++;
                }
            }
        }
        private void BTN_DETRANS_Click(object sender, EventArgs e)
        {
            if (!validaAceptar2("DesTransferir")) //falta verificar una validacion VerificaOrdenPT_Costo
                return;

            DialogResult rs = MessageBox.Show("¿ Esta seguro de realizar la operación de DesTransferencia ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.No)
                return;

            int I = 0;
            int CONT = DGW_DET2.Rows.Count - 1;
            while (I <= CONT)
            {
                if (Convert.ToBoolean(DGW_DET2[7, I].Value))
                {
                    COD_MOV0 = DGW_DET2[4, I].Value.ToString();
                    COD_DOC_INV0 = DGW_DET2[0, I].Value.ToString();
                    NRO_DOC_INV0 = DGW_DET2[1, I].Value.ToString();
                    COD_PER0 = DGW_DET2[5, I].Value.ToString();
                    NRO_DOC_PER0 = DGW_DET2[8, I].Value.ToString();
                    FECHA_DOC_INV0 = Convert.ToDateTime(DGW_DET2[9, I].Value);
                    FECHA_DOC0 = Convert.ToDateTime(DGW_DET2[10, I].Value);
                    COD_DOC0 = DGW_DET2[2, I].Value.ToString();
                    NRO_DOC0 = DGW_DET2[3, I].Value.ToString();
                    OBS0 = DGW_DET2[13, I].Value.ToString();
                    TC0 = Convert.ToDecimal(DGW_DET2[12, I].Value);
                    COD_MONEDA0 = DGW_DET2[11, I].Value.ToString();
                    STATUS_VAL0 = DGW_DET2[14, I].Value.ToString();
                    COD_SUCURSAL = DGW_DET2[16, I].Value.ToString();
                    COD_CLASE = CBO_CLASE2.SelectedValue.ToString();
                    MOSTRAR_DETALLES_COSTOS(CBO_AÑO2.SelectedValue.ToString(), CBO_MES2.Text);

                    if (REGRESAR_COSTOS() == "FALLO")
                    {
                        MessageBox.Show("Ocurrió un error.", "Vuelva  a intetarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        CARGAR_DETALLES2();
                        return;
                    }
                }
                I++;
            }
            MessageBox.Show("Operación satisfactoria de DesTransferencia !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private string REGRESAR_COSTOS()
        {
            string errMensaje = "";
            string ESTADO0 = "EXITO";
            int I = 0;
            int CONT = DGW_DET1.Rows.Count - 1;
            while (I <= CONT)
            {
                decimal PRECIO_CON0 = 0, VALOR_CON0 = 0;
                if (COD_MONEDA0 == "S")
                {
                    PRECIO_CON0 = Convert.ToDecimal(DGW_DET1[3, I].Value);
                    VALOR_CON0 = Convert.ToDecimal(DGW_DET1[4, I].Value);
                }
                else
                {
                    PRECIO_CON0 = Convert.ToDecimal(DGW_DET1[3, I].Value) * Convert.ToDecimal(TC0);
                    VALOR_CON0 = Convert.ToDecimal(DGW_DET1[4, I].Value) * Convert.ToDecimal(TC0);
                }
                //string cod_act = DGW_DET1[15, I].Value.ToString();
                //if (DGW_DET1[11, I].Value.ToString() == "") cod_act = "";
                /////
                if (!modificarTCostos(I, PRECIO_CON0, VALOR_CON0, TC0, ref errMensaje))
                {
                    return ESTADO0 = "FALLO";
                }
                I++;
            }
            //
            if (!ACTUALIZAR_ESTADO("0", CBO_AÑO.Text, CBO_MES.Text, COD_MOV0, COD_DOC0, NRO_DOC0, ref errMensaje))
                return ESTADO0 = "FALLO";
            return ESTADO0;
        }
        private bool modificarTCostos(int I, decimal PRECIO_CON0, decimal VALOR_CON0, decimal TC0, ref string errMensaje)
        {
            ////ESTO ESTA POR VERSE, YA QUE EMPIEZO CON COSTO PROMEDIO
            bool result = true;
            tcosTo.COD_SUCURSAL = COD_SUCURSAL;
            tcosTo.COD_CLASE = COD_CLASE;
            tcosTo.COD_MOV = COD_MOV0;
            tcosTo.COD_DOC_INV = COD_DOC_INV0;
            tcosTo.NRO_DOC_INV = NRO_DOC_INV0;
            tcosTo.COD_PER = COD_PER0;
            tcosTo.NRO_DOC_PER = NRO_DOC_PER0;
            tcosTo.FE_AÑO = CBO_AÑO2.Text;
            tcosTo.FE_MES = CBO_MES2.Text;
            tcosTo.FECHA_DOC = FECHA_DOC0;
            tcosTo.FECHA_DOC_INV = FECHA_DOC_INV0;
            tcosTo.COD_DOC = COD_DOC0;
            tcosTo.NRO_DOC = NRO_DOC0;
            tcosTo.OBSERVACION = OBS0;
            tcosTo.TIPO_CAMBIO = TC0;
            tcosTo.COD_USU = COD_USU;
            tcosTo.FECHA_CREA = DateTime.Now;
            tcosTo.COD_MONEDA = COD_MONEDA0;
            tcosTo.STATUS_VAL = STATUS_VAL0;
            tcosTo.ITEM = (I + 1).ToString("00");
            //tcosTo.NRO_ITEM = DGW_DET1[0, I].Value.ToString();
            tcosTo.COD_ARTICULO = DGW_DET1[1, I].Value.ToString();
            tcosTo.CANTIDAD = Convert.ToDecimal(DGW_DET1[2, I].Value);
            tcosTo.PRECIO_ACTUAL = Convert.ToDecimal(DGW_DET1[3, I].Value);
            tcosTo.VALOR_COSTO = Convert.ToDecimal(DGW_DET1[4, I].Value);
            tcosTo.PRECIO_CON = PRECIO_CON0;
            tcosTo.VALOR_CON = VALOR_CON0;
            tcosTo.COD_D_H = DGW_DET1[7, I].Value.ToString();
            tcosTo.COD_ALMACEN = DGW_DET1[8, I].Value.ToString();
            tcosTo.COD_REF = DGW_DET1[9, I].Value.ToString();// COD_DOC0;
            tcosTo.NRO_REF = DGW_DET1[10, I].Value.ToString();// NRO_DOC0;
            tcosTo.COD_CC = DGW_DET1[12, I].Value.ToString();
            tcosTo.PRECIO_CPROM = 0;

            if (!tcosBLL.modificarTCostosBLL(tcosTo, ref errMensaje))
                return result = false;
            I++;
            return result;
        }
        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void BTN_SALIR2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void COSTO_TRANSFERENCIA_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
    }
}
