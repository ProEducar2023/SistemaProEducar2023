using BLL;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;

namespace Presentacion.MOD_CXC
{
    public partial class CANJE_DOC_CXC_X_BLOQUE : Form
    {
        string AÑO = "", MES = "", COD_MOD, TIPO_USU, COD_USU;
        DateTime FECHA_INI, FECHA_GRAL;
        canjeICtasxCobrarBLL ccixcBLL = new canjeICtasxCobrarBLL();
        canjeICtasxCobrarTo ccixcTo = new canjeICtasxCobrarTo();
        canjePCtasxCobrarBLL ccpxcBLL = new canjePCtasxCobrarBLL();
        canjePCtasxCobrarTo ccpxcTo = new canjePCtasxCobrarTo();
        contratoCabeceraBLL ccBLL = new contratoCabeceraBLL();
        contratoCabeceraTo ccTo = new contratoCabeceraTo();
        HelpersBLL helBLL = new HelpersBLL();
        HelpersTo helTo = new HelpersTo();
        DataTable dtPTCTAS = new DataTable();
        progNivelBLL prnirBLL = new progNivelBLL();
        public CANJE_DOC_CXC_X_BLOQUE(string AÑO, string MES, DateTime FECHA_INI, DateTime FECHA_GRAL, string COD_MOD, string TIPO_USU, string COD_USU)
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

        private void CANJE_DOC_CXC_X_BLOQUE_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            CARGAR_SUCURSAL();
            CARGAR_MONEDA();
            CARGAR_SECTORISTA();
            CARGAR_CC_GENERADOS();
            CARGAR_CC_PENDIENTES();
            CREAR_DT_PTCTAS();
            btn_nuevo.Select();
        }
        private void CARGAR_MONEDA()
        {
            DataTable dt = helBLL.obtenerMonedaBLL();
            cbo_moneda.ValueMember = "COD_MONEDA";
            cbo_moneda.DisplayMember = "desc_moneda";
            cbo_moneda.DataSource = dt;
            cbo_moneda.SelectedItem = -1;
        }
        private void CARGAR_SECTORISTA()
        {
            DataTable dt = prnirBLL.obtenerSectoristasparaCrearEqCobradoresBLL("01");
            cbo_sectorista.ValueMember = "COD_EQCOB";
            cbo_sectorista.DisplayMember = "DESC_EQVTA";
            cbo_sectorista.DataSource = dt;
            cbo_sectorista.SelectedIndex = -1;
        }
        private void CARGAR_SUCURSAL()
        {
            //string COD_USU = "0000";
            helTo.CODIGO = COD_USU;
            DataTable dt = helBLL.CBO_SUCURSALBLL(helTo);
            cbo_sucursal.ValueMember = "COD_SUCURSAL";
            cbo_sucursal.DisplayMember = "DESC_sucursal";
            cbo_sucursal.DataSource = dt;
            cbo_sucursal.SelectedIndex = 0;
        }
        private void CREAR_DT_PTCTAS()
        {
            dtPTCTAS.Columns.Add("COD_SUCURSAL");
            dtPTCTAS.Columns.Add("COD_CLASE");
            dtPTCTAS.Columns.Add("NRO_PRESUPUESTO");
            dtPTCTAS.Columns.Add("AÑO");
            dtPTCTAS.Columns.Add("MES");
            dtPTCTAS.Columns.Add("FECHA_PRE");
            dtPTCTAS.Columns.Add("NRO_REPORTE");
            dtPTCTAS.Columns.Add("FEC_REPORTE");
            dtPTCTAS.Columns.Add("COD_MONEDA");
            dtPTCTAS.Columns.Add("TIPO_CAMBIO");
            dtPTCTAS.Columns.Add("TOTAL_CONTRATO");
            dtPTCTAS.Columns.Add("COD_PER");
            dtPTCTAS.Columns.Add("NRO_CUOTAS");
            dtPTCTAS.Columns.Add("COD_VENDEDOR");
            dtPTCTAS.Columns.Add("COD_NIVEL1");
            dtPTCTAS.Columns.Add("COD_NIVEL2");
            dtPTCTAS.Columns.Add("COD_NIVEL3");
            dtPTCTAS.Columns.Add("COD_PTO_COB");
            dtPTCTAS.Columns.Add("COD_USU");
            dtPTCTAS.Columns.Add("COD_SECTORISTA");
            dtPTCTAS.Columns.Add("COD_TIPO_VENTA");
            dtPTCTAS.Columns.Add("COD_MODALIDAD_VTA");
            dtPTCTAS.Columns.Add("FECHA_DOC");
            dtPTCTAS.Columns.Add("FEC_PRIMER_VENC");
            dtPTCTAS.Columns.Add("IMP_CUOTA_INICIAL");
            dtPTCTAS.Columns.Add("FEC_CUO_MES");
            dtPTCTAS.Columns.Add("IMP_CUOTA_MES");
        }
        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }
        private void CARGAR_CC_GENERADOS()
        {
            ccixcTo.FE_AÑO = AÑO;
            ccixcTo.FE_MES = MES;
            ccixcTo.TIPO_USU = TIPO_USU;
            ccixcTo.COD_USU = COD_USU;
            DataTable dtCC_Generadas = ccixcBLL.obtenerCanjeICtasxCobrarxBloqueBLL(ccixcTo);
            //dgw_cc_generada.DataSource = dtCC_Generadas;
            if (dtCC_Generadas.Rows.Count > 0)
            {
                foreach (DataRow rw in dtCC_Generadas.Rows)
                {
                    int rowId = dgw_cc_generada.Rows.Add();
                    DataGridViewRow row = dgw_cc_generada.Rows[rowId];
                    row.Cells["COD_SUCURSAL"].Value = rw["COD_SUCURSAL"].ToString();
                    row.Cells["DESC_SUCURSAL"].Value = rw["DESC_SUCURSAL"].ToString();
                    row.Cells["COD_PER"].Value = rw["COD_PER"].ToString();
                    row.Cells["DESC_PER"].Value = rw["DESC_PER"].ToString();
                    row.Cells["COD_CLASE"].Value = rw["COD_CLASE"].ToString();
                    row.Cells["Ruc_Dni"].Value = rw["Ruc_Dni"].ToString();
                    row.Cells["NRO_CONTRATO"].Value = rw["NRO_CONTRATO"].ToString();
                    row.Cells["FECHA_CONTRATO"].Value = rw["FECHA_CONTRATO"].ToString();
                    row.Cells["NRO_REPORTE"].Value = rw["NRO_REPORTE"].ToString();
                    row.Cells["IMP_DOC"].Value = rw["IMP_DOC"].ToString();
                    row.Cells["FECHA_REPORTE"].Value = rw["FECHA_REPORTE"].ToString();
                    row.Cells["COD_MONEDA"].Value = rw["COD_MONEDA"].ToString();
                    row.Cells["TIPO_CAMBIO"].Value = rw["TIPO_CAMBIO"].ToString();
                    row.Cells["NRO_CUOTAS"].Value = rw["NRO_CUOTAS"].ToString();
                    row.Cells["OBSERVACION"].Value = rw["OBSERVACION"].ToString();
                    row.Cells["FEC_PRIMER_VENC"].Value = rw["FEC_PRIMER_VENC"].ToString();
                    row.Cells["IMP_CUOTA_INICIAL"].Value = rw["IMP_CUOTA_INICIAL"].ToString();
                    row.Cells["NRO_DIAS_VENC"].Value = rw["NRO_DIAS_VENC"].ToString();
                    row.Cells["FEC_CUO_MEN"].Value = rw["FEC_CUO_MEN"].ToString();
                    row.Cells["COD_TIPO_VENTA"].Value = rw["COD_TIPO_VENTA"].ToString();
                    row.Cells["DESC_TIPO_VENTA"].Value = rw["DESC_TIPO_VENTA"].ToString();
                    row.Cells["COD_MODALIDAD_VTA"].Value = rw["COD_MODALIDAD_VTA"].ToString();
                    row.Cells["DESC_MODALIDAD_VTA"].Value = rw["DESC_MODALIDAD_VTA"].ToString();
                    row.Cells["FECHA_DOC"].Value = rw["FECHA_DOC"].ToString();
                    row.Cells["COD_SECTORISTA"].Value = rw["COD_SECTORISTA"].ToString();
                    row.Cells["NRO_DOC_INV"].Value = rw["NRO_DOC_INV"].ToString();
                }
            }
        }
        private void CARGAR_CC_PENDIENTES()
        {
            ccTo.COD_SUCURSAL = cbo_sucursal.SelectedValue.ToString();
            DataTable dtCC_Pendientes = ccBLL.obtenerContratosCuentaCorrienteBLL(ccTo);
            if (dtCC_Pendientes.Rows.Count > 0)
            {
                foreach (DataRow rw in dtCC_Pendientes.Rows)
                {
                    int rowId = dgw_cc_pendiente.Rows.Add();
                    DataGridViewRow row = dgw_cc_pendiente.Rows[rowId];
                    row.Cells["COD_SUCURSAL1"].Value = rw["COD_SUCURSAL"].ToString();
                    row.Cells["COD_CLASE1"].Value = rw["COD_CLASE"].ToString();
                    row.Cells["NRO_PRESUPUESTO1"].Value = rw["NRO_PRESUPUESTO"].ToString();
                    row.Cells["FECHA_PRE1"].Value = rw["FECHA_PRE"].ToString();
                    row.Cells["NRO_REPORTE1"].Value = rw["NRO_REPORTE"].ToString();
                    row.Cells["FEC_REPORTE1"].Value = rw["FEC_REPORTE"].ToString();
                    row.Cells["COD_MONEDA1"].Value = rw["COD_MONEDA"].ToString();
                    row.Cells["TIPO_CAMBIO1"].Value = rw["TIPO_CAMBIO"].ToString();
                    row.Cells["TOTAL_CONTRATO1"].Value = rw["TOTAL_CONTRATO"].ToString();
                    row.Cells["COD_PER1"].Value = rw["COD_PER"].ToString();
                    row.Cells["NRO_CUOTAS1"].Value = rw["NRO_CUOTAS"].ToString();
                    row.Cells["COD_VENDEDOR1"].Value = rw["COD_VENDEDOR"].ToString();
                    row.Cells["COD_NIVEL11"].Value = rw["COD_NIVEL1"].ToString();
                    row.Cells["COD_NIVEL21"].Value = rw["COD_NIVEL2"].ToString();
                    row.Cells["COD_NIVEL31"].Value = rw["COD_NIVEL3"].ToString();
                    row.Cells["COD_PTO_COB1"].Value = rw["COD_PTO_COB"].ToString();
                    row.Cells["COD_SECTORISTA1"].Value = rw["COD_SECTORISTA"].ToString();
                    row.Cells["COD_TIPO_VENTA1"].Value = rw["COD_TIPO_VENTA"].ToString();
                    row.Cells["COD_MODALIDAD_VTA1"].Value = rw["COD_MODALIDAD_VTA"].ToString();
                    row.Cells["FEC_PRIMER_VENC1"].Value = rw["FEC_PRIMER_VENC"].ToString();
                    row.Cells["IMP_CUOTA_INICIAL1"].Value = rw["IMP_CUOTA_INICIAL"].ToString();
                    row.Cells["FEC_CUO_MEN1"].Value = rw["FEC_CUO_MEN"].ToString();
                    row.Cells["IMP_COUTA_MES1"].Value = rw["IMP_COUTA_MES"].ToString();
                }
            }
        }

        private void btn_generacion_Click(object sender, EventArgs e)
        {
            if (!validaGrabar())
                return;
            DialogResult rs = MessageBox.Show("¿ Esta seguro de generar la cuenta corriente para los contratos ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                foreach (DataGridViewRow row in dgw_cc_pendiente.Rows)
                {
                    if (Convert.ToBoolean(row.Cells["X"].Value))
                    {
                        DataRow rw = dtPTCTAS.NewRow();
                        rw["COD_SUCURSAL"] = cbo_sucursal.SelectedValue.ToString();
                        rw["COD_CLASE"] = row.Cells["COD_CLASE1"].Value.ToString();
                        rw["NRO_PRESUPUESTO"] = row.Cells["NRO_PRESUPUESTO1"].Value.ToString();
                        rw["FECHA_PRE"] = row.Cells["FECHA_PRE1"].Value.ToString();
                        rw["AÑO"] = AÑO;
                        rw["MES"] = MES;
                        rw["FECHA_PRE"] = row.Cells["FECHA_PRE1"].Value.ToString();
                        rw["NRO_REPORTE"] = row.Cells["NRO_REPORTE1"].Value.ToString();
                        rw["FEC_REPORTE"] = row.Cells["FEC_REPORTE1"].Value.ToString();
                        rw["COD_MONEDA"] = row.Cells["COD_MONEDA1"].Value.ToString();
                        rw["TIPO_CAMBIO"] = row.Cells["TIPO_CAMBIO1"].Value.ToString();
                        rw["TOTAL_CONTRATO"] = row.Cells["TOTAL_CONTRATO1"].Value.ToString();
                        rw["COD_PER"] = row.Cells["COD_PER1"].Value.ToString();
                        rw["NRO_CUOTAS"] = row.Cells["NRO_CUOTAS1"].Value.ToString();
                        rw["COD_VENDEDOR"] = row.Cells["COD_VENDEDOR1"].Value.ToString();
                        rw["COD_NIVEL1"] = row.Cells["COD_NIVEL11"].Value.ToString();
                        rw["COD_NIVEL2"] = row.Cells["COD_NIVEL21"].Value.ToString();
                        rw["COD_NIVEL3"] = row.Cells["COD_NIVEL31"].Value.ToString();
                        rw["COD_PTO_COB"] = row.Cells["COD_PTO_COB1"].Value.ToString();
                        rw["COD_USU"] = COD_USU;
                        rw["COD_SECTORISTA"] = row.Cells["COD_SECTORISTA1"].Value.ToString();
                        rw["COD_TIPO_VENTA"] = row.Cells["COD_TIPO_VENTA1"].Value.ToString();
                        rw["COD_MODALIDAD_VTA"] = row.Cells["COD_MODALIDAD_VTA1"].Value.ToString();
                        rw["FECHA_DOC"] = dtp_canje.Value;
                        rw["FEC_PRIMER_VENC"] = row.Cells["FEC_PRIMER_VENC1"].Value.ToString();
                        rw["IMP_CUOTA_INICIAL"] = row.Cells["IMP_CUOTA_INICIAL1"].Value.ToString();
                        rw["FEC_CUO_MES"] = row.Cells["FEC_CUO_MEN1"].Value.ToString();
                        rw["IMP_CUOTA_MES"] = row.Cells["IMP_COUTA_MES1"].Value.ToString();
                        dtPTCTAS.Rows.Add(rw);
                    }
                }

                if (!ccixcBLL.insertaAdicionaCanjeICtasxCobrarxBloqueBLL(dtPTCTAS, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Se grabó correctamente !!!", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    foreach (DataGridViewRow row in dgw_cc_pendiente.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells["X"].Value))
                            dgw_cc_pendiente.Rows.Remove(row);
                    }
                    CARGAR_CC_GENERADOS();
                    //elimina las filas con check
                    for (int j = dgw_cc_pendiente.Rows.Count - 1; j >= 0; j--)
                    {
                        if (Convert.ToBoolean(dgw_cc_pendiente.Rows[j].Cells["X"].Value))
                        {
                            dgw_cc_pendiente.Rows.Remove(dgw_cc_pendiente.Rows[j]);
                        }
                    }
                }

            }
        }
        private bool validaGrabar()
        {
            bool result = true;
            if (dgw_cc_pendiente.Rows.Count <= 0)
            {
                return result = false;
            }
            return result;
        }

        private void btn_consulta_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
            CARGAR_CABECERA_CONSULTA();
            CARGAR_DETALLE_CONSULTA();
        }
        private void CARGAR_CABECERA_CONSULTA()
        {
            txt_sucursal.Text = dgw_cc_generada.CurrentRow.Cells["DESC_SUCURSAL"].Value.ToString();
            txt_fec_gen.Text = dgw_cc_generada.CurrentRow.Cells["FECHA_DOC"].Value.ToString().Substring(0, 10);
            txt_cod_per.Text = dgw_cc_generada.CurrentRow.Cells["COD_PER"].Value.ToString();
            txt_desc_per.Text = dgw_cc_generada.CurrentRow.Cells["DESC_PER"].Value.ToString();
            txt_doc_per.Text = dgw_cc_generada.CurrentRow.Cells["Ruc_Dni"].Value.ToString();
            txt_contrato.Text = dgw_cc_generada.CurrentRow.Cells["NRO_CONTRATO"].Value.ToString();
            txt_fec_con.Text = dgw_cc_generada.CurrentRow.Cells["FECHA_CONTRATO"].Value.ToString().Substring(0, 10);
            txt_dia.Text = dgw_cc_generada.CurrentRow.Cells["NRO_DIAS_VENC"].Value.ToString();
            txt_cuota.Text = dgw_cc_generada.CurrentRow.Cells["NRO_CUOTAS"].Value.ToString();
            txt_fec_pri_cuo.Text = dgw_cc_generada.CurrentRow.Cells["FEC_PRIMER_VENC"].Value.ToString().Substring(0, 10);
            cbo_moneda.SelectedValue = dgw_cc_generada.CurrentRow.Cells["COD_MONEDA"].Value.ToString();
            txt_tc.Text = dgw_cc_generada.CurrentRow.Cells["TIPO_CAMBIO"].Value.ToString();
            txt_seg_cuota.Text = dgw_cc_generada.CurrentRow.Cells["FEC_CUO_MEN"].Value.ToString().Substring(0, 10);
            txt_mod_vta.Text = dgw_cc_generada.CurrentRow.Cells["DESC_MODALIDAD_VTA"].Value.ToString();
            txt_tipo_vta.Text = dgw_cc_generada.CurrentRow.Cells["DESC_TIPO_VENTA"].Value.ToString();
            txt_obs.Text = dgw_cc_generada.CurrentRow.Cells["OBSERVACION"].Value.ToString();
            cbo_sectorista.SelectedValue = dgw_cc_generada.CurrentRow.Cells["COD_SECTORISTA"].Value.ToString();
        }
        private void CARGAR_DETALLE_CONSULTA()
        {
            ccpxcTo.COD_SUCURSAL = dgw_cc_generada.CurrentRow.Cells["COD_SUCURSAL"].Value.ToString();
            //ccpxcTo.COD_CLASE = dgw_cc_generada.CurrentRow.Cells["COD_CLASE"].Value.ToString();
            ccpxcTo.NRO_CONTRATO = dgw_cc_generada.CurrentRow.Cells["NRO_CONTRATO"].Value.ToString();
            DataTable dtPctas = ccpxcBLL.obtener_PCtasCobrar_DetalleBLL(ccpxcTo);
            if (dtPctas.Rows.Count > 0)
            {
                DGW_DET2.Rows.Clear();
                int i = 0; decimal sum = 0;
                foreach (DataRow rw in dtPctas.Rows)
                {
                    i++;
                    int rowId = DGW_DET2.Rows.Add();
                    DataGridViewRow row = DGW_DET2.Rows[rowId];
                    row.Cells["nro"].Value = i.ToString().PadLeft(2, '0');
                    row.Cells["nro_letra"].Value = rw["NRO_DOC"].ToString();
                    row.Cells["nro_cuota"].Value = rw["NRO_LETRA"].ToString() + "/" + txt_cuota.Text;
                    row.Cells["fec_vcto"].Value = rw["FECHA_VEN"].ToString().Substring(0, 10);
                    row.Cells["imp"].Value = rw["IMP_INI"].ToString();
                    sum += Convert.ToDecimal(rw["IMP_INI"]);
                }
                txt_total2.Text = sum.ToString();
            }
        }

        private void btn_cancelar2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (!validarEliminar())
                return;

            DialogResult rs = MessageBox.Show("¿ Esta seguro de eliminar la cta corriente ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                int idx = dgw_cc_generada.CurrentRow.Index;
                ccixcTo.COD_SUCURSAL = dgw_cc_generada.Rows[idx].Cells["COD_SUCURSAL"].Value.ToString();//dgw_cc_generada[0, idx].Value.ToString();
                ccixcTo.COD_PER = dgw_cc_generada.Rows[idx].Cells["COD_PER"].Value.ToString();//dgw_cc_generada[2, idx].Value.ToString();
                ccixcTo.NRO_CONTRATO = dgw_cc_generada.Rows[idx].Cells["NRO_CONTRATO"].Value.ToString();//dgw_cc_generada[5, idx].Value.ToString();
                ccixcTo.NRO_DOC_INV = dgw_cc_generada.Rows[idx].Cells["NRO_DOC_INV"].Value.ToString();
                ccixcTo.COD_CLASE = dgw_cc_generada.Rows[idx].Cells["COD_CLASE"].Value.ToString();
                ccixcTo.FE_AÑO = AÑO;
                ccixcTo.FE_MES = MES;
                ccixcTo.FECHA_MOD = DateTime.Now;
                ccixcTo.COD_USU = COD_USU;

                if (!ccixcBLL.ELIMINAR_I_CTAS_COBRAR_CANJE_BLL(ccixcTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    dgw_cc_generada.Rows.Remove(dgw_cc_generada.CurrentRow);//DATAGRID();
                }
            }
        }
        private bool validarEliminar()
        {
            bool result = true;
            string errMensaje = "";
            if (dgw_cc_generada.Rows.Count == 0)
            {
                MessageBox.Show("No existen registros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return result = false;
            }
            //ccixcTo.NRO_CONTRATO = dgw_cc_generada.CurrentRow.Cells["NRO_CONTRATO"].Value.ToString();
            //if (ccixcBLL.VerificaExisteNroContratoEnviadoBLL(ccixcTo, ref errMensaje))
            //{
            //    MessageBox.Show("No se puede eliminar la Cuenta Corriente pues \nel Contrato ya ha sido enviado a la Institucion !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return result = false;
            //}
            //valida que el contrato ya tenga algun pago
            ccpxcTo.NRO_CONTRATO = dgw_cc_generada.CurrentRow.Cells["NRO_CONTRATO"].Value.ToString();
            if (ccpxcBLL.Verifica_Existe_Cuota_pagada_x_contratoBLL(ccpxcTo, ref errMensaje))
            {
                MessageBox.Show("No se puede eliminar la Cuenta Corriente pues \nel Contrato ya tiene al menos un pago efectuado !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return result = false;
            }
            string nro_planilla = ccpxcBLL.Verifica_Existe_Planilla_x_contratoBLL(ccpxcTo);
            if (nro_planilla.Length > 0)
            {
                MessageBox.Show("No se puede eliminar la Cuenta Corriente pues \nse encuentra en la Planilla Elaborada N° " + nro_planilla + "!!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return result = false;
            }
            return result;
        }
    }

}
