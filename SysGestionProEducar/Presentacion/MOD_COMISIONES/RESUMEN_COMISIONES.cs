using BLL;
using Entidades;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Presentacion.MOD_COMISIONES
{
    public partial class RESUMEN_COMISIONES : Form
    {
        string AÑO = "", MES = "", COD_MOD, TIPO_USU, COD_USU;
        DateTime FECHA_INI, FECHA_GRAL;
        HelpersBLL helBLL = new HelpersBLL();
        HelpersTo helTo = new HelpersTo();
        pLiquidacionBLL pliqBLL = new pLiquidacionBLL();
        pLiquidacionTo pliqTo = new pLiquidacionTo();
        DataTable dtGeneral, dtAdelanto, dtDevolucion, dtOtros;
        decimal sumaRetencion = 0;
        CONSULTA_ADELANTO_COMISIONES_PARA_RESUMEN frmAde = new CONSULTA_ADELANTO_COMISIONES_PARA_RESUMEN();

        public RESUMEN_COMISIONES(string AÑO, string MES, DateTime FECHA_INI, DateTime FECHA_GRAL, string COD_MOD, string TIPO_USU, string COD_USU)
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

        private void RESUMEN_COMISIONES_Load(object sender, EventArgs e)
        {
            CARGAR_SUCURSAL();
            CARGAR_AÑO();
            CARGAR_MES();
        }
        private void CARGAR_AÑO()
        {
            periodoBLL perBLL = new periodoBLL();
            periodoTo perTo = new periodoTo();
            cbo_año.Items.Clear();
            perTo.COD_MODULO = "COM";
            DataTable dt = perBLL.obtenerAñoPeriodoBLL(perTo);
            cbo_año.ValueMember = "AÑO";
            cbo_año.DisplayMember = "AÑO";
            cbo_año.DataSource = dt;
        }
        private void CARGAR_MES()
        {
            var months1 = new[] {new { cod = "01", val = "ENERO" }, new { cod = "02", val = "FEBRERO" },
                                new { cod = "03", val = "MARZO" }, new { cod = "04", val = "ABRIL" },
                                new { cod = "05", val = "MAYO" }, new { cod = "06", val = "JUNIO" },
                                new { cod = "07", val = "JULIO" }, new { cod = "08", val = "AGOSTO" },
                                new { cod = "09", val = "SEPTIEMBRE" }, new { cod = "10", val = "OCTUBRE" },
                                new { cod = "11", val = "NOVIEMBRE" }, new { cod = "12", val = "DICIEMBRE" }};

            cbo_mes.ValueMember = "cod";
            cbo_mes.DisplayMember = "val";
            cbo_mes.DataSource = months1;
            //cbo_mes.SelectedIndex = -1;
        }
        private void CARGAR_SUCURSAL()
        {
            helTo.CODIGO = COD_USU;
            DataTable dt = helBLL.CBO_SUCURSALBLL(helTo);
            cbo_sucursal.ValueMember = "COD_SUCURSAL";
            cbo_sucursal.DisplayMember = "DESC_sucursal";
            cbo_sucursal.DataSource = dt;
            //cbo_sucursal.SelectedIndex = -1;
        }
        private void RESUMEN_COMISIONES_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            pLiqAdelantoBLL plaBLL = new pLiqAdelantoBLL();
            pLiqAdelantoTo plaTo = new pLiqAdelantoTo();
            pLiqDevolucionBLL pldBLL = new pLiqDevolucionBLL();
            pLiqDevolucionTo pldTo = new pLiqDevolucionTo();
            otrosCargosComisionesBLL occBLL = new otrosCargosComisionesBLL();
            otrosCargosComisionesTo occTo = new otrosCargosComisionesTo();
            pliqTo.FE_AÑO = cbo_año.SelectedValue.ToString();
            pliqTo.FE_MES = cbo_mes.SelectedValue.ToString();
            plaTo.FE_AÑO = pliqTo.FE_AÑO;
            plaTo.FE_MES = pliqTo.FE_MES;
            pldTo.FE_AÑO = pliqTo.FE_AÑO;
            pldTo.FE_MES = pliqTo.FE_MES;
            occTo.FE_AÑO = pliqTo.FE_AÑO;
            occTo.FE_MES = pliqTo.FE_MES;
            dtGeneral = pliqBLL.obtenerLiquidacionpara_P_ResumenBLL(pliqTo);
            dtDevolucion = pldBLL.obtenerPLiqDevolucionxPeriodoparaResumenBLL(pldTo);
            dtAdelanto = plaBLL.obtenerPLiqAdelantoxPeriodoparaResumenBLL(plaTo);
            dtOtros = occBLL.obtenerOtrosCargosComisionesxPeriodoparaResumenBLL(occTo);
            dgw1.Rows.Clear();
            dgwComisionDet.Rows.Clear();
            if (dtGeneral.Rows.Count > 0)
            {
                DataTable dt1 = dtGeneral.AsEnumerable()
                   .GroupBy(r => new
                   {
                       Col01 = r["COD_COMISIONANTE"],
                       Col02 = r["TIPO_VTA"],
                       Col03 = r["COD_PROGRAMA"]
                       //Col04 = r["COD_NIVEL"],
                       //Col05 = r["FE_MES"],
                       //Col06 = r["FE_AÑO"],

                   })
                   .Select(g => g.OrderBy(r => r["COD_COMISIONANTE"]).First())
                   .CopyToDataTable();
                //
                if (dt1.Rows.Count > 0)
                {
                    foreach (DataRow rw in dt1.Rows)
                    {
                        sumaRetencion = 0;
                        int rowId = dgw1.Rows.Add();
                        DataGridViewRow row = dgw1.Rows[rowId];
                        row.Cells["TIPO_VTA"].Value = rw["TIPO_VTA"].ToString();
                        row.Cells["COD_PROGRAMA"].Value = rw["COD_PROGRAMA"].ToString();
                        row.Cells["DESC_PROGRAMA"].Value = rw["DESC_PROGRAMA"].ToString();
                        row.Cells["COD_COMISIONANTE"].Value = rw["COD_COMISIONANTE"].ToString();
                        row.Cells["DESC_PER"].Value = rw["DESC_PER"].ToString();
                        row.Cells["NRO_CONTRATO"].Value = rw["NRO_CONTRATO"].ToString();
                        row.Cells["NRO_LETRA"].Value = rw["NRO_LETRA"].ToString();
                        row.Cells["COD_NIVEL"].Value = rw["COD_NIVEL"].ToString();
                        row.Cells["DESC_NIVEL"].Value = rw["DESC_NIVEL"].ToString();
                        row.Cells["FE_AÑO"].Value = rw["FE_AÑO"].ToString();
                        row.Cells["FE_MES"].Value = rw["FE_MES"].ToString();
                        row.Cells["IMP_INI"].Value = sumaImpComisionxComisionista(rw["COD_COMISIONANTE"].ToString());
                        row.Cells["IMP_ADELANTO"].Value = sumaImpAdelantoxComisionista(rw["COD_COMISIONANTE"].ToString());
                        row.Cells["IMP_DEVOLUCION"].Value = sumaImpDevolucionxComisionista(rw["COD_COMISIONANTE"].ToString());
                        row.Cells["IMP_OTROS"].Value = sumaImpOtrosxComisionista(rw["COD_COMISIONANTE"].ToString());
                        row.Cells["IMP_CANCELADO"].Value = Convert.ToDecimal(row.Cells["IMP_INI"].Value) - Convert.ToDecimal(row.Cells["IMP_ADELANTO"].Value) - Convert.ToDecimal(row.Cells["IMP_DEVOLUCION"].Value) - Convert.ToDecimal(row.Cells["IMP_OTROS"].Value);
                        row.Cells["IMP_RETENCION"].Value = sumaRetencion;
                        row.Cells["IMP_NETO"].Value = Convert.ToDecimal(row.Cells["IMP_INI"].Value) - Convert.ToDecimal(row.Cells["IMP_ADELANTO"].Value) - Convert.ToDecimal(row.Cells["IMP_DEVOLUCION"].Value) - Convert.ToDecimal(row.Cells["IMP_OTROS"].Value) - Convert.ToDecimal(row.Cells["IMP_RETENCION"].Value);
                    }
                }
            }
            else
            {
                MessageBox.Show("No se encontraron registros !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            dgw1.Select();

        }
        private decimal sumaImpOtrosxComisionista(string cod_comi)
        {
            decimal sum = 0;
            foreach (DataRow rw in dtOtros.Rows)
            {
                if (rw["COD_PER"].ToString() == cod_comi)
                {
                    if (!Convert.ToBoolean(rw["STATUS_IMPUESTOS"]))
                    {
                        if (rw["COD_D_H"].ToString() == "D")
                            sum += Convert.ToDecimal(rw["IMPORTE"]);
                        else if (rw["COD_D_H"].ToString() == "H")
                            sum -= Convert.ToDecimal(rw["IMPORTE"]);
                    }
                    else
                    {
                        sumaRetencion = Convert.ToDecimal(rw["IMPORTE"]);//solo hay un registro por Retencion para cada Comisionista, eso dice Don Miguel
                    }

                }
            }
            if (sum < 0)
                sum = (-1) * sum;
            return sum;
        }
        private decimal sumaImpDevolucionxComisionista(string cod_comi)
        {
            decimal sum = 0;
            foreach (DataRow rw in dtDevolucion.Rows)
            {
                if (rw["COD_COMISIONANTE"].ToString() == cod_comi)
                {
                    sum += Convert.ToDecimal(rw["IMPORTE"]);
                }
            }
            return sum;
        }
        private decimal sumaImpAdelantoxComisionista(string cod_comi)
        {
            decimal sum = 0;
            foreach (DataRow rw in dtAdelanto.Rows)
            {
                if (rw["COD_PER"].ToString() == cod_comi)
                {
                    sum += Convert.ToDecimal(rw["IMP_DOC"]);
                }
            }
            return sum;
        }
        private decimal sumaImpComisionxComisionista(string cod_comi)
        {
            decimal sum = 0;
            foreach (DataRow rw in dtGeneral.Rows)
            {
                if (rw["COD_COMISIONANTE"].ToString() == cod_comi)
                {
                    sum += Convert.ToDecimal(rw["IMP_INI"]);
                }
            }
            return sum;
        }
        private void dgw1_SelectionChanged(object sender, EventArgs e)
        {
            if (dgw1.CurrentRow.Cells["COD_COMISIONANTE"].Value != null)
            {
                llenaDetalleComision();
                llenaDetalleDevolucion();
                //llenaDetalleAdelanto();
                llenaDetalleOtros();
            }
        }

        private void dgw1_Click(object sender, EventArgs e)
        {
            if (dgw1.Rows.Count > 0)
            {
                llenaDetalleComision();
                llenaDetalleDevolucion();
                llenaDetalleAdelanto();
                llenaDetalleOtros();
            }
        }
        private void llenaDetalleAdelanto()
        {
            dgwAdelantoDet.Rows.Clear();
            string cod_comisionista = dgw1.CurrentRow.Cells["COD_COMISIONANTE"].Value.ToString();
            DataTable dtDetalle = null;
            if (dtAdelanto.Rows.Count > 0)
            {
                DataRow[] fila = dtAdelanto.Select("COD_PER = '" + cod_comisionista + "'");
                if (fila.Length > 0)
                {
                    dtDetalle = fila.CopyToDataTable();
                    if (dtDetalle.Rows.Count > 0)
                    {
                        foreach (DataRow rw in dtDetalle.Rows)
                        {
                            int rowId = dgwAdelantoDet.Rows.Add();
                            DataGridViewRow row = dgwAdelantoDet.Rows[rowId];
                            row.Cells["COD_COMISIONANTE3"].Value = rw["COD_PER"].ToString();
                            row.Cells["DESC_PER3"].Value = rw["DESC_PER"].ToString();
                            row.Cells["NRO_DOC3"].Value = rw["NRO_DOC"].ToString();
                            //row.Cells["COD_D_H3"].Value = rw["COD_D_H"].ToString();
                            //row.Cells["COD_CPTO3"].Value = rw["COD_CPTO"].ToString();
                            row.Cells["FECHA_DOC3"].Value = rw["FECHA_DOC"].ToString().Substring(0, 10);
                            row.Cells["IMP_DOC3"].Value = rw["IMP_DOC"].ToString();
                            row.Cells["OBSERVACIONES3"].Value = rw["OBSERVACION"].ToString();
                        }
                    }
                }
                else
                    dgwAdelantoDet.Rows.Clear();
            }
            else
                dgwAdelantoDet.Rows.Clear();
        }
        private void llenaDetalleOtros()
        {
            dgwOtrosDet.Rows.Clear();
            string cod_comisionista = dgw1.CurrentRow.Cells["COD_COMISIONANTE"].Value.ToString();
            DataTable dtDetalle = null;
            if (dtOtros.Rows.Count > 0)
            {
                DataRow[] fila = dtOtros.Select("COD_PER = '" + cod_comisionista + "'");
                if (fila.Length > 0)
                {
                    dtDetalle = fila.CopyToDataTable();
                    if (dtDetalle.Rows.Count > 0)
                    {
                        foreach (DataRow rw in dtDetalle.Rows)
                        {
                            int rowId = dgwOtrosDet.Rows.Add();
                            DataGridViewRow row = dgwOtrosDet.Rows[rowId];
                            row.Cells["COD_COMISIONANTE2"].Value = rw["COD_PER"].ToString();
                            row.Cells["DESC_PER2"].Value = rw["DESC_PER"].ToString();
                            row.Cells["NRO_DOC2"].Value = rw["NRO_DOC"].ToString();
                            row.Cells["COD_D_H2"].Value = rw["COD_D_H"].ToString();
                            row.Cells["COD_CPTO2"].Value = rw["COD_CPTO"].ToString();
                            row.Cells["DESCRIPCION2"].Value = rw["DESCRIPCION"].ToString();
                            row.Cells["IMPORTE2"].Value = rw["IMPORTE"].ToString();
                            row.Cells["OBSERVACIONES2"].Value = rw["OBSERVACIONES"].ToString();
                        }
                    }
                }
                else
                    dgwOtrosDet.Rows.Clear();
            }
            else
                dgwOtrosDet.Rows.Clear();
        }
        private void llenaDetalleDevolucion()
        {
            dgwDevolucionDet.Rows.Clear();
            string tipo_vta = dgw1.CurrentRow.Cells["TIPO_VTA"].Value.ToString();
            string cod_programa = dgw1.CurrentRow.Cells["COD_PROGRAMA"].Value.ToString();
            string cod_comisionista = dgw1.CurrentRow.Cells["COD_COMISIONANTE"].Value.ToString();
            DataTable dtDetalle = null;
            if (dtDevolucion.Rows.Count > 0)
            {
                DataRow[] fila = dtDevolucion.Select("TIPO_VTA = '" + tipo_vta + "' AND COD_PROGRAMA = '" + cod_programa + "' AND COD_COMISIONANTE = '" + cod_comisionista + "'");
                if (fila.Length > 0)
                {
                    dtDetalle = fila.CopyToDataTable();
                    if (dtDetalle.Rows.Count > 0)
                    {
                        foreach (DataRow rw in dtDetalle.Rows)
                        {
                            int rowId = dgwDevolucionDet.Rows.Add();
                            DataGridViewRow row = dgwDevolucionDet.Rows[rowId];
                            row.Cells["COD_COMISIONISTA4"].Value = rw["COD_COMISIONANTE"].ToString();
                            row.Cells["DESC_PER4"].Value = rw["DESC_PER"].ToString();
                            row.Cells["NRO_CONTRATO4"].Value = rw["NRO_CONTRATO"].ToString();
                            row.Cells["NRO_LETRA4"].Value = rw["NRO_LETRA"].ToString();
                            row.Cells["COD_NIVEL4"].Value = rw["COD_NIVEL"].ToString();
                            row.Cells["DESC_NIVEL4"].Value = rw["DESC_NIVEL"].ToString();
                            row.Cells["IMP_INI4"].Value = rw["IMPORTE"].ToString();
                        }
                    }
                }
                else
                    dgwDevolucionDet.Rows.Clear();
            }
            else
                dgwDevolucionDet.Rows.Clear();
        }
        private void llenaDetalleComision()
        {
            dgwComisionDet.Rows.Clear();
            string nro_contrato = dgw1.CurrentRow.Cells["COD_COMISIONANTE"].Value.ToString();
            DataTable dtDetalle = null;
            if (dtGeneral.Rows.Count > 0)
            {
                DataRow[] fila = dtGeneral.Select("COD_COMISIONANTE = '" + nro_contrato + "'");
                if (fila.Length > 0)
                {
                    dtDetalle = fila.CopyToDataTable();
                    if (dtDetalle.Rows.Count > 0)
                    {
                        foreach (DataRow rw in dtDetalle.Rows)
                        {
                            int rowId = dgwComisionDet.Rows.Add();
                            DataGridViewRow row = dgwComisionDet.Rows[rowId];
                            row.Cells["COD_COMISIONANTE1"].Value = rw["COD_COMISIONANTE"].ToString();
                            row.Cells["DESC_PER1"].Value = rw["DESC_PER"].ToString();
                            row.Cells["NRO_CONTRATO1"].Value = rw["NRO_CONTRATO"].ToString();
                            row.Cells["NRO_LETRA1"].Value = rw["NRO_LETRA"].ToString();
                            row.Cells["COD_NIVEL1"].Value = rw["COD_NIVEL"].ToString();
                            row.Cells["DESC_NIVEL1"].Value = rw["DESC_NIVEL"].ToString();
                            row.Cells["IMP_INI1"].Value = rw["IMP_INI"].ToString();
                        }
                    }
                }
                else
                    dgwComisionDet.Rows.Clear();
            }
            else
                dgwComisionDet.Rows.Clear();
        }

        //private void lkl_adelanto_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    frmAde.mostrarAdelantosPendientes(dgw1.CurrentRow.Cells["COD_COMISIONANTE"].Value.ToString());
        //    frmAde.ShowDialog();
        //    if (frmAde.DialogResult == DialogResult.OK)
        //    {
        //        dgw1.CurrentRow.Cells["IMP_ADELANTO"].Value = sumaAdelanto();
        //        calculo_Imp_Cancelado();
        //    }
        //}
        private void calculo_Imp_Cancelado()
        {
            dgw1.CurrentRow.Cells["IMP_CANCELADO"].Value = Convert.ToDecimal(dgw1.CurrentRow.Cells["IMP_INI"].Value) - Convert.ToDecimal(dgw1.CurrentRow.Cells["IMP_ADELANTO"].Value) - Convert.ToDecimal(dgw1.CurrentRow.Cells["IMP_DEVOLUCION"].Value) - Convert.ToDecimal(dgw1.CurrentRow.Cells["IMP_OTROS"].Value);
        }
        private decimal sumaAdelanto()
        {
            decimal ade = 0;
            int num = frmAde.dgw1.Rows.Count - 1;
            int i = 0;
            while (i <= num)
            {
                if (Convert.ToBoolean(frmAde.dgw1.Rows[i].Cells["X"].Value))
                {
                    ade += Convert.ToDecimal(frmAde.dgw1.Rows[i].Cells["IMP_DOC"].Value);
                }
                i++;
            }
            return ade;
        }
        //private void lkl_otros_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    CONSULTA_OTROS_COMISIONES_PARA_RESUMEN frmResu = new CONSULTA_OTROS_COMISIONES_PARA_RESUMEN(cbo_sucursal.SelectedValue.ToString(), dgw1.CurrentRow.Cells["FE_AÑO"].Value.ToString(), dgw1.CurrentRow.Cells["FE_MES"].Value.ToString(), dgw1.CurrentRow.Cells["COD_COMISIONANTE"].Value.ToString());
        //    frmResu.ShowDialog();
        //    if (frmResu.DialogResult == DialogResult.OK)
        //    {
        //        dgw1.CurrentRow.Cells["IMP_OTROS"].Value = sumaImpOtrosDescuentos(frmResu.dgw1);
        //        calculo_Imp_Cancelado();
        //    }
        //}
        private decimal sumaImpOtrosDescuentos(DataGridView dgw0)
        {
            decimal sum = 0;
            foreach (DataGridViewRow rw in dgw0.Rows)
            {
                sum += Convert.ToDecimal(rw.Cells["importe"].Value);
            }
            return sum;
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
