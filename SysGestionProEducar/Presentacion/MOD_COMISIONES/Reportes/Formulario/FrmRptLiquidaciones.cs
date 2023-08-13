using BLL;
using Entidades;
using Presentacion.HELPERS;
using Presentacion.HELPERS.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Presentacion.HELPERS.GenericUtil;
using static Presentacion.HELPERS.Constantes;
using Microsoft.Reporting.WinForms;
using System.Globalization;

namespace Presentacion.MOD_COMISIONES.Reportes.Formulario
{
    public partial class FrmRptLiquidaciones : Form
    {
        public FrmRptLiquidaciones()
        {
            InitializeComponent();
        }

        private readonly comisionesBLL BLComision = new comisionesBLL();
        private readonly personaBLL BLPersona = new personaBLL();
        private readonly nivelBLL BLNivel = new nivelBLL();

        private DataTable dtPeriodoGenerado, dtPeriodoGeneradoDev, dtPeriodoGeneradoOtrosIngrEgr;
        private DataTable dtPersonaConsolidado, dtLiquidacionMensualSaldoAnterior, dtLiquidacionMensual, dtComisionesDetalle, dtDevolucionesDetalle, dtDefaultSubReport, dtOtrosCargosAbonosDetalle, dtXComisionarDetalle;
        private string nivelVenta6;

        private delegate string[] ObtenerParametrosRpt();
        private delegate string DelObtenerNivelVenta();
        private delegate object[] ObtenerParametrosRpt2();

        private void FrmRptLiquidaciones_Load(object sender, EventArgs e)
        {
            StartControsl();
            CargarNivelVenta();
            CargarPeriodoGenerado();
            CargarPersonaNivelVenta();
            CargarPeriodoGeneradoDevolucion();
            CargarPeriodoGeneradoOtrosIngresosEgresos();
            CargarVendedor();
        }

        private void StartControsl()
        {
            cboPersona.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPeriodoGen.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNivelVenta2.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPersona2.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPeriodoGen2.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPersona3.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPeriodoGen3.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPersona4.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPeriodoGen4.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNivelVenta6.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPersona6.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPeriodoGen6.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNivelVenta3.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNivelVenta4.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPersona5.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNivelVenta5.DropDownStyle = ComboBoxStyle.DropDownList;
            cboVendedor.DropDownStyle = ComboBoxStyle.DropDownList;
            btnImprimir.StyleButtonFlat();
        }

        private void CargarPeriodoGenerado()
        {
            dtPeriodoGenerado = BLComision.ObtenerPeriodoGeneradosComisionYDevolucion();
            if (dtPeriodoGenerado != null && dtPeriodoGenerado.Columns.Count > 0)
            {
                DataRow row = dtPeriodoGenerado.NewRow();
                row["ID"] = 0;
                row["FE_AÑO_PER"] = "";
                row["FE_MES_PER"] = "";
                row["PERIODO_TEXT"] = "Seleccione";
                dtPeriodoGenerado.Rows.InsertAt(row, 0);

                cboPeriodoGen.ValueMember = "ID";
                cboPeriodoGen.DisplayMember = "PERIODO_TEXT";
                cboPeriodoGen.DataSource = dtPeriodoGenerado;

                cboPeriodoGen2.ValueMember = "ID";
                cboPeriodoGen2.DisplayMember = "PERIODO_TEXT";
                cboPeriodoGen2.DataSource = dtPeriodoGenerado.Copy();

                cboPeriodoGen6.ValueMember = "ID";
                cboPeriodoGen6.DisplayMember = "PERIODO_TEXT";
                cboPeriodoGen6.DataSource = dtPeriodoGenerado.Copy();
            }
        }

        private void CargarPersonaNivelVenta()
        {
            DataTable dt = BLPersona.ObtenerMaestroPersonaProgNivel();
            if (dt != null)
            {
                dynamic selector(DataRow x) => new { COD_PER = x.Field<string>("COD_PER"), DESC_PER = x.Field<string>("DESC_PER") };
                List<dynamic> lista = dt.AsEnumerable().OrderBy(x => x.Field<string>("DESC_PER")).CopyToDataTable().ToDistinct(selector);
                lista.Insert(0, new { COD_PER = "", DESC_PER = "Todos" });
                cboPersona.DataSource = lista;
                cboPersona.ValueMember = "COD_PER";
                cboPersona.DisplayMember = "DESC_PER";
            }
        }
        private void CargarVendedor()
        {
            DataTable dt = BLPersona.ObtenerMaestroPersonaXNivel("04");
            if (dt != null)
            {
                dynamic selector(DataRow x) => new { COD_PER = x.Field<string>("COD_PER"), DESC_PER = x.Field<string>("DESC_PER") };
                List<dynamic> lista = dt.AsEnumerable().OrderBy(x => x.Field<string>("DESC_PER")).CopyToDataTable().ToDistinct(selector);
                lista.Insert(0, new { COD_PER = "", DESC_PER = "Todos" });
                cboVendedor.DataSource = lista;
                cboVendedor.ValueMember = "COD_PER";
                cboVendedor.DisplayMember = "DESC_PER";
            }
        }
        private void CargarNivelVenta()
        {
            DataTable dt = BLNivel.obtenerNivelBLL().Select("COD_NIVEL IN ('01', '02', '03', '04')").CopyToDataTable();
            cboNivelVenta2.ValueMember = "COD_NIVEL";
            cboNivelVenta2.DisplayMember = "DESC_NIVEL";
            cboNivelVenta2.DataSource = dt;

            cboNivelVenta3.ValueMember = "COD_NIVEL";
            cboNivelVenta3.DisplayMember = "DESC_NIVEL";
            cboNivelVenta3.DataSource = dt.Copy();

            cboNivelVenta4.ValueMember = "COD_NIVEL";
            cboNivelVenta4.DisplayMember = "DESC_NIVEL";
            cboNivelVenta4.DataSource = dt.Copy();

            cboNivelVenta5.ValueMember = "COD_NIVEL";
            cboNivelVenta5.DisplayMember = "DESC_NIVEL";
            cboNivelVenta5.DataSource = dt.Copy();

            cboNivelVenta6.ValueMember = "COD_NIVEL";
            cboNivelVenta6.DisplayMember = "DESC_NIVEL";
            cboNivelVenta6.DataSource = dt.Copy();
        }

        private void CargarPeriodoGeneradoDevolucion()
        {
            dtPeriodoGeneradoDev = BLComision.ObtenerPeriodosDevolucionComisionGenerados();
            if (dtPeriodoGeneradoDev != null && dtPeriodoGeneradoDev.Columns.Count > 0)
            {
                DataRow row = dtPeriodoGeneradoDev.NewRow();
                row["ID"] = 0;
                row["FE_AÑO_PER"] = "";
                row["FE_MES_PER"] = "";
                row["ESTADO"] = (int)ESTADO_REGISTRO.NONE;
                row["PERIODO_TEXT"] = "Seleccione";
                dtPeriodoGeneradoDev.Rows.InsertAt(row, 0);

                cboPeriodoGen3.ValueMember = "ID";
                cboPeriodoGen3.DisplayMember = "PERIODO_TEXT";
                cboPeriodoGen3.DataSource = dtPeriodoGeneradoDev;
            }
        }

        private void CargarPeriodoGeneradoOtrosIngresosEgresos()
        {
            dtPeriodoGeneradoOtrosIngrEgr = BLComision.ObtenerPeriodosRegistradosOtrosIngresosEgresosVendedor();
            if (dtPeriodoGeneradoOtrosIngrEgr != null && dtPeriodoGeneradoOtrosIngrEgr.Columns.Count > 0)
            {
                DataRow row = dtPeriodoGeneradoOtrosIngrEgr.NewRow();
                row["ID"] = 0;
                row["FE_AÑO_PER"] = "";
                row["FE_MES_PER"] = "";
                row["PERIODO_TEXT"] = "Seleccione";
                dtPeriodoGeneradoOtrosIngrEgr.Rows.InsertAt(row, 0);

                cboPeriodoGen4.ValueMember = "ID";
                cboPeriodoGen4.DisplayMember = "PERIODO_TEXT";
                cboPeriodoGen4.DataSource = dtPeriodoGeneradoOtrosIngrEgr;
            }
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            if (rdbLiquidacion.Checked)
                GenerarReporteLiquidacion();
            else if (rdbDetalleComision.Checked)
                GenerarReporteDetalleComision();
            else if (rdbDevolucionDetalle.Checked)
                GenerarReporteDetalleDevolucion();
            else if (rdbOtrosCargosAbonos.Checked)
                GenerarReporteDetalleOtrosCargosAbonos();
            else if (rdbPorComisionarDetalle.Checked)
                GenerarReporteXComisionarDetalle();
            else if (rdbConsolidado.Checked)
                GenerarReporteConsolidado();
            else if (radioButton1.Checked)
                GenerarReporteHistoricoComisiones();
        }

        private async void GenerarReporteHistoricoComisiones()
        {
            FrmLoading frmLoading = null;
            try
            {
                if (!ValidarGenerarReporteHistoricoComisiones())
                    return;
                //GenerarReporteDetalleComision
                frmLoading = frmLoading.StartLoadingForm(this);

                string codVendedor = cboVendedor.SelectedValue?.ToString();
                DateTime fechaAprobIni = dtFechaAprobacion1.Value;
                DateTime fechaAprobFin = dtFechaAprobacion2.Value;
                String fechaActper = dtFechaActualizado.Value.Year.ToString();
                String fechaActmes = dtFechaActualizado.Value.Month.ToString();
                String tipobusfecha = "";

                if (rbFecAprob.Checked)
                    tipobusfecha = "FA";
                else if (rbFecReg.Checked)
                    tipobusfecha = "FR";


                Task<DataTable> task1 = Task.Run(() => BLComision.RPTHISTORICOCOMISIONESAPROBADAS(fechaAprobIni, fechaAprobFin, codVendedor, tipobusfecha, fechaActper, fechaActmes));
                
                DataTable tblData = await task1;
                //DataTable dt = await ObtenerDevolucionDetalle();
                const string data_set_name = "DataSet1";
                string reporte = ObtenerRutaReporteTareaje("rptHistoricoComisiones11", Modulo.MOD_COMISIONES);
                string periodoText = string.Concat("Fecha " + (rbFecAprob.Checked ? "Aprobación" : "Registro") + " : ", fechaAprobIni.ToString("dd/MM/yyyy"), " - ", fechaAprobFin.ToString("dd/MM/yyyy"));
                string titulo = string.Concat("REPORTE HISTORICO DE COMISIONES - APROBADAS", "\n", periodoText + "\n" + "Actualizado al : " + dtFechaActualizado.Value.ToString("dd/MM/yyyy"));

                string lblVendedor = string.Concat("PROGRAMA : Curso de Inglés" , "\nVENDEDOR   : ", cboVendedor.Text);
                object[] parameters = { titulo, lblVendedor, codVendedor=="" ? "Todos" : codVendedor };
                frmLoading.CloseLoadingForm();
                ReportViewer rpt = null;
                Form frm = CreateReportForm(ref rpt, reporte, data_set_name, tblData, parameters);
                rpt.SetDisplayMode(DisplayMode.Normal);
                rpt.RefreshReport();
                frm.Show();
            }
            catch (Exception ex)
            {
                frmLoading.CloseLoadingForm();
                ex.PrintException();
            }
        }


        private async void GenerarReporteXComisionarDetalle()
        {
            FrmLoading frmLoading = null;
            try
            {
                
               if (!ValidarPorComisionarDetalle())
                    return;

                frmLoading = frmLoading.StartLoadingForm(this);
                DataTable dt;
                DataTable dt2;
                DateTime fechaAprobIni = dtpComisionar1.Value;
                DateTime fechaAprobFin = dtpComisionar2.Value;
                if (cboNivelVenta5.SelectedValue.ToString() == "02") {
                    dt = await ObtenerDatosXComisionarDetalle2();
                }
                else
                {

                 dt = await ObtenerDatosXComisionarDetalle();
                 dt2 = await ObtenerDatosXComisionarDetalle2();
                if (dt != null)
                    
                    dt.Merge(dt2);
                else dt = dt2;

                }
               
                frmLoading.CloseLoadingForm();

                string reporte = ObtenerModeloReporteXComisionarDetalle();
                const string data_set_name = "DataSet1";
                


                string periodoText = string.Concat("Fecha Registro : ", fechaAprobIni.ToString("MMMM - yyyy"), " al ", fechaAprobFin.ToString("MMMM - yyyy"));
                string titulo = string.Concat("REPORTE DE CONTRATOS POR COMISIONAR - POR ", cboNivelVenta5.Text, "\n", periodoText + "\n");

                
                //string titulo = string.Concat("REPORTE DE COMISIONES POR GENERAR POR ");



                string fechaText = string.Concat("Contratos por Comisionar al : ", dtFechaContrato5.Value.ToShortDateString());
                object[] parameters = cboNivelVenta5.SelectedValue.ToString() == COD_NIVEL_VENDEDOR
                    ? new object[] { titulo, fechaText }
                    : new object[] { titulo, fechaText, cboNivelVenta5.Text };
                
                Form frm = CreateReportForm(reporte, data_set_name, dt, parameters);
                frm.Show();
            }
            catch (Exception ex)
            {
                frmLoading.CloseLoadingForm();
                ex.PrintException();
            }
        }



        private async void GenerarReporteDetalleComision()
        {
            FrmLoading frmLoading = null;
            try
            {
                if (!ValidarGenerarReporteDetalleComision())
                    return;

                frmLoading = frmLoading.StartLoadingForm(this);
                string feAñoPer = PeriodoSeleccionado["FE_AÑO_PER"].ToString();
                string feMesPer = PeriodoSeleccionado["FE_MES_PER"].ToString();
                string codPer = cboPersona2.SelectedValue?.ToString();
                string codNivel = cboNivelVenta2.SelectedValue?.ToString();
                DataTable dt = await ObtenerComionesDetalle();
                const string data_set_name = "DataSet1";
                string reporte = ObtenerModeloReporteComision();
                string titulo = ObtenerTituloReporte();
                string periodoText = string.Concat("Periodo: ", Convert.ToInt32(PeriodoSeleccionado["FE_MES_PER"]).NombreMes(), " - ", PeriodoSeleccionado["FE_AÑO_PER"].ToString());
                object[] parameters = { titulo, periodoText };
                frmLoading.CloseLoadingForm();
                Form frm = CreateReportForm(reporte, data_set_name, dt, parameters);
                frm.Show();
            }
            catch (Exception ex)
            {
                frmLoading.CloseLoadingForm();
                ex.PrintException();
            }
        }

        private bool ValidarGenerarReporteDetalleComision()
        {
            if (string.IsNullOrEmpty(cboNivelVenta2.SelectedValue?.ToString()))
            {
                _ = MessageBox.Show("Seleccione un nivel de venta", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cboPersona2.SelectedValue == null)
            {
                _ = MessageBox.Show("Seleccione una persona", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(cboPeriodoGen2.SelectedValue?.ToString()) || (PeriodoSeleccionado != null && PeriodoSeleccionado["ID"].ToInt32() == 0))
            {
                _ = MessageBox.Show("Seleccione un período", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }


        private async void GenerarReporteLiquidacion()
        {
            FrmLoading frmLoading = null;
            try
            {
                if (!ValidarGenerarReporteLiquidacion())
                    return;

                frmLoading = frmLoading.StartLoadingForm(this);
                DataRow row = ObtenerPeriodoSeleccionado();
                LiquidacionTo to = new LiquidacionTo
                {
                    FE_AÑO_PER = row["FE_AÑO_PER"].ToString(),
                    FE_MES_PER = row["FE_MES_PER"].ToString(),
                    COD_PER = cboPersona.SelectedValue?.ToString()
                };
                Task<DataTable> task1 = ObtenerSaldoAnterior();
                Task<DataTable> task2 = Task.Run(() => BLComision.RptLiquidacionResumenXPersona(to));
                DataTable dtSaldoAnterior = await task1;
                DataTable dtMesActual = await task2;
                if (dtSaldoAnterior != null)
                    dtMesActual.Merge(dtSaldoAnterior);
                frmLoading.CloseLoadingForm();
                string reporte = ObtenerModeloReporte();
                const string dataSetName = "DataSet1";
                const string titulo = "LIQUIDACIÓN DE COMISIONES";
                string programa = "-";
                string periodoText = string.Concat("Periodo: ", Convert.ToInt32(to.FE_MES_PER).NombreMes(), "-", to.FE_AÑO_PER);
                object[] parameters = { titulo, programa, periodoText };
                Form frm = CreateReportForm(reporte, dataSetName, dtMesActual, parameters);
                frm.Show();
            }
            catch (Exception ex)
            {
                frmLoading.CloseLoadingForm();
                ex.PrintException();
            }
        }

        private async Task<DataTable> ObtenerSaldoAnterior()
        {
            DataRow row = ObtenerPeriodoSeleccionado();
            LiquidacionTo to = new LiquidacionTo
            {
                FE_AÑO_PER = row["FE_AÑO_PER"].ToString(),
                FE_MES_PER = row["FE_MES_PER"].ToString(),
                COD_PER = cboPersona.SelectedValue?.ToString()
            };
            DataTable dt = await Task.Run(() => BLComision.LiquidacionSaldoAnteriorXPersona(to));
            var rowOnlyCodPersona = dt?.AsEnumerable().GroupBy(x => x.Field<string>("A"));
            if (dt == null)
                return null;
            DataTable dtDetalle = new DataTable();
            foreach (DataColumn column in dt.Columns)
            {
                dtDetalle.Columns.Add(column.ColumnName, column.DataType);
            }
            Task<DataTable> task2 = new TaskFactory<DataTable>().StartNew(() =>
            {
                DataTable dtPersona = null;
                decimal saldo_anterior = 0;
                decimal comisiones_vetas_propias = 0;
                decimal comisiones_ventas_tercero = 0;
                decimal devoluciones_ventas = 0;
                decimal comisiones_netas = 0;
                decimal otras_adiciones = 0;
                decimal total_ingresos = 0;
                decimal pago_cuenta_corriente = 0;
                decimal otras_deducciones = 0;
                decimal total_deducciones = otras_deducciones;
                decimal saldo_mes = 0;
                decimal saldo_pagar_fin_mes = 0;
                decimal cancelacion_cta_cte = 0;
                decimal saldo_final = 0;

                foreach (var group in rowOnlyCodPersona)
                {
                    DataRow rw = group.First();
                    dtPersona = dt.AsEnumerable().Where(x => x.Field<string>("A") == rw.Field<string>("A")).CopyToDataTable();
                    saldo_anterior = 0;
                    comisiones_vetas_propias = Convert.ToDecimal(dtPersona.AsEnumerable().SingleOrDefault(x => x.Field<int>("Z") == 1 && x.Field<int>("F") == 1)?.Field<decimal>("E"));
                    comisiones_ventas_tercero = Convert.ToDecimal(dtPersona.AsEnumerable().SingleOrDefault(x => x.Field<int>("Z") == 1 && x.Field<int>("F") == 2)?.Field<decimal>("E"));
                    devoluciones_ventas = Convert.ToDecimal(dtPersona.AsEnumerable().SingleOrDefault(x => x.Field<int>("Z") == 2)?.Field<decimal>("E"));
                    comisiones_netas = comisiones_vetas_propias + comisiones_ventas_tercero - devoluciones_ventas;
                    otras_adiciones = (decimal)(dtPersona.AsEnumerable().Where(x => x.Field<int>("Z") == 3 && x.Field<int>("D") == 1)?.Sum(f => f.Field<decimal>("E")));
                    total_ingresos = comisiones_netas + otras_adiciones;
                    pago_cuenta_corriente = Convert.ToDecimal(dtPersona.AsEnumerable().SingleOrDefault(x => x.Field<int>("Z") == 4)?.Field<decimal>("E"));
                    otras_deducciones = (decimal)(dtPersona.AsEnumerable().Where(x => x.Field<int>("Z") == 3 && x.Field<int>("D") == 2)?.Sum(f => f.Field<decimal>("E")));
                    total_deducciones = pago_cuenta_corriente + otras_deducciones;
                    saldo_mes = total_ingresos - total_deducciones;
                    saldo_pagar_fin_mes = saldo_anterior + saldo_mes;
                    cancelacion_cta_cte = Convert.ToDecimal(dtPersona.AsEnumerable().SingleOrDefault(x => x.Field<int>("Z") == 7 && x.Field<int>("F") == 3)?.Field<decimal>("E"));
                    saldo_final = saldo_pagar_fin_mes - cancelacion_cta_cte;

                    DataRow nrw = dtDetalle.NewRow();
                    nrw["Z"] = 0;
                    nrw["A"] = rw["A"];
                    nrw["B"] = dtPersona.Rows[0]["B"];
                    nrw["C"] = string.Empty;
                    nrw["D"] = 0;
                    nrw["F"] = 0;
                    nrw["E"] = saldo_final;
                    dtDetalle.Rows.Add(nrw);
                }
                return dtDetalle;
            });
            return await task2;
        }

        private string ObtenerModeloReporte()
        {
            return ObtenerRutaReporteTareaje("RptLiquidacionesResumen", Modulo.MOD_COMISIONES);
        }

        private DataRow ObtenerPeriodoSeleccionado()
        {
            try
            {
                if (dtPeriodoGenerado != null)
                    return dtPeriodoGenerado.Select("ID = " + Convert.ToInt32(cboPeriodoGen.SelectedValue)).First();
            }
            catch (ArgumentNullException)
            {
                _ = MessageBox.Show("No se encontró el periodo seleccionado. \n Cierre el formulario y vuelva a intentarlo", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (InvalidOperationException)
            {
                _ = MessageBox.Show("Se identificó dos periodos con el mismo id. \n Cierre el formulario y vuelva a intentarlo", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                ex.PrintException();
            }
            return null;
        }

        private bool ValidarGenerarReporteLiquidacion()
        {
            DataRow row = ObtenerPeriodoSeleccionado();
            if (row == null || cboPeriodoGen.SelectedValue.ToInt32() == 0)
            {
                _ = MessageBox.Show("Seleccione un periodo", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void CboNivelVenta_SelectedValueChanged(object sender, EventArgs e)
        {
            CargarPersonaXNivelVenta(cboNivelVenta2, cboPersona2);
        }

        private void CboNivelVenta3_SelectedValueChanged(object sender, EventArgs e)
        {
            CargarPersonaXNivelVenta(cboNivelVenta3, cboPersona3);
        }

        private void CboNivelVenta4_SelectedValueChanged(object sender, EventArgs e)
        {
            CargarPersonaXNivelVenta(cboNivelVenta4, cboPersona4);
        }

        private void CboNivelVenta5_SelectedValueChanged(object sender, EventArgs e)
        {
            CargarPersonaXNivelVenta(cboNivelVenta5, cboPersona5);
        }

        private void CboNivelVenta6_SelectedValueChanged(object sender, EventArgs e)
        {
            CargarPersonaXNivelVenta(cboNivelVenta6, cboPersona6);
        }

        private void CargarPersonaXNivelVenta(ComboBox cboNivelVenta, ComboBox cboPersona)
        {
            if (cboNivelVenta.SelectedValue != null)
            {
                DataTable dt = BLPersona.ObtenerMaestroPersonaXNivel(cboNivelVenta.SelectedValue.ToString());
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow row = dt.NewRow();
                    row["COD_PER"] = "";
                    row["DESC_PER"] = "Todos";
                    row["COD_NIVEL"] = "00";
                    dt.Rows.InsertAt(row, 0);

                    cboPersona.ValueMember = "COD_PER";
                    cboPersona.DisplayMember = "DESC_PER";
                    cboPersona.DataSource = dt;
                }
            }
        }

   

        private async Task<DataTable> ObtenerComionesDetalle()
        {
            string[] parameters = ObtenerParametrosReporte();
            string feAñoPer = parameters[0];
            string feMesPer = parameters[1];
            string codPer = parameters[2];
            string codNivel = parameters[3];
            Task<DataTable> dt = Task.Run(() =>
            {
                switch (codNivel)
                {
                    case COD_NIVEL_VENDEDOR: return BLComision.RptComisionesDetalleXVendedor(feAñoPer, feMesPer, codPer);
                    default: return BLComision.RptComisionesDetalleXSuperior(feAñoPer, feMesPer, codPer, codNivel);
                }
            });
            return await dt;
        }

        private string[] ObtenerParametrosReporte()
        {
            string[] parameters = null;
            if (InvokeRequired)
            {
                ObtenerParametrosRpt del = new ObtenerParametrosRpt(ObtenerParametrosReporte);
                _ = Invoke(del, parameters);
            }
            else
            {
                string feAñoPer = PeriodoSeleccionado["FE_AÑO_PER"].ToString();
                string feMesPer = PeriodoSeleccionado["FE_MES_PER"].ToString();
                string codPer = cboPersona2.SelectedValue?.ToString();
                string codNivel = cboNivelVenta2.SelectedValue?.ToString();
                parameters = new[] { feAñoPer, feMesPer, codPer, codNivel };
            }
            return parameters;
        }

        private async void GenerarReporteDetalleDevolucion()
        {
            FrmLoading frmLoading = null;
            try
            {
                if (!ValidarGenerarReporteDevolucionDetalle())
                    return;

                frmLoading = frmLoading.StartLoadingForm(this);
                string feAñoPer = PeriodoSeleccionadoDev["FE_AÑO_PER"].ToString();
                string feMesPer = PeriodoSeleccionadoDev["FE_MES_PER"].ToString();
                string codPer = cboPersona3.SelectedValue?.ToString();
                DataTable dt = await ObtenerDevolucionDetalle();
                const string data_set_name = "DataSet1";
                string reporte = ObtenerRutaReporteTareaje("RptDevolucionesDetalle", Modulo.MOD_COMISIONES);
                string titulo = string.Concat("DETALLE DE DEVOLUCIÓN DE MERCADERÍA Y DESCUENTO DE COMISIÓN - POR ", cboNivelVenta3.Text);
                string periodoText = string.Concat("Periodo: ", Convert.ToInt32(feMesPer).NombreMes(), " - ", feAñoPer);
                string vendedorText = string.Concat($"{ cboNivelVenta3.Text }: ", cboPersona3.Text);
                object[] parameters = { titulo, periodoText, vendedorText };
                frmLoading.CloseLoadingForm();
                Form frm = CreateReportForm(reporte, data_set_name, dt, parameters);
                frm.Show();
            }
            catch (Exception ex)
            {
                frmLoading.CloseLoadingForm();
                ex.PrintException();
            }
        }

        private async Task<DataTable> ObtenerDevolucionDetalle()
        {
            string[] parameters = ObtenerParametrosReporte2();
            string feAñoPer = parameters[0];
            string feMesPer = parameters[1];
            string codPer = parameters[2];
            string nivelVenta = parameters[3];
            Task<DataTable> dt = Task.Run(() =>
            {
                return BLComision.RptDevolucionDetalle(feAñoPer, feMesPer, codPer, nivelVenta);
            });
            return await dt;
        }

        private string[] ObtenerParametrosReporte2()
        {
            string[] parameters = null;
            if (InvokeRequired)
            {
                ObtenerParametrosRpt del = new ObtenerParametrosRpt(ObtenerParametrosReporte2);
                _ = Invoke(del, parameters);
            }
            else
            {
                string feAñoPer = PeriodoSeleccionadoDev["FE_AÑO_PER"].ToString();
                string feMesPer = PeriodoSeleccionadoDev["FE_MES_PER"].ToString();
                string codPer = cboPersona3.SelectedValue?.ToString();
                string nivelVenta = cboNivelVenta3.SelectedValue?.ToString();
                parameters = new[] { feAñoPer, feMesPer, codPer, nivelVenta };
            }
            return parameters;
        }

        private bool ValidarGenerarReporteDevolucionDetalle()
        {
            if (cboPersona3.SelectedValue == null)
            {
                _ = MessageBox.Show("Seleccione una persona", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if ((PeriodoSeleccionadoDev == null) || (PeriodoSeleccionadoDev != null && PeriodoSeleccionadoDev["ID"].ToInt32() == 0))
            {
                _ = MessageBox.Show("Seleccione un período", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }


        private bool ValidarGenerarReporteHistoricoComisiones()
        {
            DateTime fechaini1;
            DateTime fechafin1;

           
            fechaini1 = Convert.ToDateTime(dtFechaAprobacion1.Value, new CultureInfo("es-ES"));
         
            fechafin1 = Convert.ToDateTime(dtFechaAprobacion2.Value, new CultureInfo("es-ES"));



            //var difrango = dtFechaAprobacion1.Value - dtFechaAprobacion2.Value;(difrango.TotalDays < 0)
            //int difrango = DateTime.Compare( dtFechaAprobacion2.Value, dtFechaAprobacion1.Value);
            //if (cboVendedor.SelectedValue == null)
            //{
            //    _ = MessageBox.Show("Seleccione una persona", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return false;
            //}

            //(DateTime.Now - fecharegistro).TotalHours;

            TimeSpan dif = fechafin1.Subtract(fechaini1);
            if (dif.Days < 0)
            {
                _ = MessageBox.Show("La fecha hasta debe ser menor a la inicial ", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private bool ValidarPorComisionarDetalle()
        {
            DateTime fechaini1;
            DateTime fechafin1;
            DateTime contratohasta;

            fechaini1 = Convert.ToDateTime(dtpComisionar1.Value, new CultureInfo("es-ES"));

            fechafin1 = Convert.ToDateTime(dtpComisionar2.Value, new CultureInfo("es-ES"));

            contratohasta = Convert.ToDateTime(dtFechaContrato5.Value, new CultureInfo("es-ES"));
            
            //var difrango = dtFechaAprobacion1.Value - dtFechaAprobacion2.Value;(difrango.TotalDays < 0)
            //int difrango = DateTime.Compare( dtFechaAprobacion2.Value, dtFechaAprobacion1.Value);
            //if (cboVendedor.SelectedValue == null)
            //{
            //    _ = MessageBox.Show("Seleccione una persona", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return false;
            //}

            //(DateTime.Now - fecharegistro).TotalHours;

            TimeSpan dif = fechafin1.Subtract(fechaini1);

            TimeSpan difcontini = contratohasta.Subtract(fechaini1);
            TimeSpan difcontfin = contratohasta.Subtract(fechafin1);

            if (dif.Days < 0)
            {
                _ = MessageBox.Show("La fecha de reporte hasta debe ser menor a la inicial ", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (difcontini.Days < 0)
            {
                _ = MessageBox.Show("La fecha del contrato debe ser mayor a la fecha de registro inicial ", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (difcontfin.Days < 0)
            {
                _ = MessageBox.Show("La fecha del contrato debe ser mayor a la fecha de registro final ", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private async void GenerarReporteDetalleOtrosCargosAbonos()
        {
            FrmLoading frmLoading = null;
            try
            {
                if (!ValidarGenerarReporteCargosAbonoDetalle())
                    return;
                frmLoading = frmLoading.StartLoadingForm(this);
                DataTable dt = await ObtenerOtrosCargosAbonosDetalle();
                string reporte = ObtenerRutaReporteTareaje("RptOtrosCargosAbonosDetalle", Modulo.MOD_COMISIONES);
                const string data_set_name = "DataSet1";
                const string titulo = "REPORTE DE OTROS CARGOS Y ABONOS POR VENDEDOR";
                int feMesPer = PeriodoGeneradoOtrosIngEgr["FE_MES_PER"].ToInt32();
                int feAñoPer = PeriodoGeneradoOtrosIngEgr["FE_AÑO_PER"].ToInt32();
                string periodoText = string.Concat("Periodo: ", feMesPer.NombreMes(), " - ", feAñoPer);
                object[] parameters = { titulo, periodoText };
                frmLoading.CloseLoadingForm();
                Form frm = CreateReportForm(reporte, data_set_name, dt, parameters);
                frm.Show();
            }
            catch (Exception ex)
            {
                frmLoading.CloseLoadingForm();
                ex.PrintException();
            }
        }

        private async Task<DataTable> ObtenerOtrosCargosAbonosDetalle()
        {
            string[] parameters = ObtenerParametrosReporte3();
            string codVendedor = parameters[0];
            string feAñoPer = parameters[1];
            string feMesPer = parameters[2];
            DataTable dt = await Task.Run(() => BLComision.RptOtrosCargosAbonosXVendedorDetalle(codVendedor, feAñoPer, feMesPer));
            return dt;
        }

        private string[] ObtenerParametrosReporte3()
        {
            string[] parameters = null;
            if (InvokeRequired)
            {
                ObtenerParametrosRpt deParameter = new ObtenerParametrosRpt(ObtenerParametrosReporte3);
                _ = Invoke(deParameter);
            }
            else
            {
                string codVendedor = cboPersona4.SelectedValue?.ToString();
                string feAñoPer = PeriodoGeneradoOtrosIngEgr["FE_AÑO_PER"].ToString();
                string feMesPer = PeriodoGeneradoOtrosIngEgr["FE_MES_PER"].ToString();
                parameters = new[] { codVendedor, feAñoPer, feMesPer };
            }
            return parameters;
        }

        private bool ValidarGenerarReporteCargosAbonoDetalle()
        {
            if (cboPersona4.SelectedValue == null)
            {
                _ = MessageBox.Show("Seleccione una persona", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if ((PeriodoGeneradoOtrosIngEgr == null) || (PeriodoGeneradoOtrosIngEgr != null && PeriodoGeneradoOtrosIngEgr["ID"].ToInt32() == 0))
            {
                _ = MessageBox.Show("Seleccione un período", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private async void GenerarReporteConsolidado()
        {
            FrmLoading frmLoading = null;
            try
            {
                if (!ValidarGenerarReporteConsolidado())
                    return;

                frmLoading = frmLoading.StartLoadingForm(this);
                //> Filtros
                string feAñoPer = PeriodoSeleccionadoConsolidado["FE_AÑO_PER"].ToString();
                string feMesPer = PeriodoSeleccionadoConsolidado["FE_MES_PER"].ToString();
                string codPer = cboPersona6.SelectedValue?.ToString();
                string codNivel = cboNivelVenta6.SelectedValue?.ToString();
                DateTime fechaContrato = dtFechaContrato6.Value;
                nivelVenta6 = codNivel;
                //> Datos para los subReportes
                LiquidacionTo to = new LiquidacionTo
                {
                    FE_AÑO_PER = feAñoPer,
                    FE_MES_PER = feMesPer,
                    COD_PER = codPer
                };
                Task<DataTable> task1 = ObtenerSaldoAnterior(to);
                Task<DataTable> task2 = Task.Run(() => BLComision.RptLiquidacionResumenXPersona(to));
                Task<DataTable> taskComisionesDetalle = Task.Run(() =>
                {
                    switch (codNivel)
                    {
                        case COD_NIVEL_VENDEDOR: return BLComision.RptComisionesDetalleXVendedor(feAñoPer, feMesPer, codPer);
                        default: return BLComision.RptComisionesDetalleXSuperior(feAñoPer, feMesPer, codPer, codNivel);
                    }
                });
                Task<DataTable> taskDevolucionesDetalle = Task.Run(() => BLComision.RptDevolucionDetalle(feAñoPer, feMesPer, codPer, codNivel));
                Task<DataTable> taskOtrosCargosAbonosDetalle = Task.Run(() => BLComision.RptOtrosCargosAbonosXVendedorDetalle(codPer, feAñoPer, feMesPer));
                Task<DataTable> taskXComisionarDetalle = Task.Run(() =>
                {
                    switch (codNivel)
                    {
                        case COD_NIVEL_VENDEDOR: return BLComision.RptContratosXGenerarYGeneradosAdelantoComision(COD_PROGRAMA_INGLES, codPer, fechaContrato);
                        default: return BLComision.RptContratosXGenerarYGeneradosAdelantoComision(COD_PROGRAMA_INGLES, codPer, codNivel, fechaContrato);
                    }
                });
                Task<DataTable> taskXComisionarDetalle2 = Task.Run(() =>
                {
                    switch (codNivel)
                    {
                        case COD_NIVEL_VENDEDOR: return BLComision.RptContratosPendientesGenerarComisionVendedor(COD_PROGRAMA_INGLES, codPer, fechaContrato);
                        default: return BLComision.RptContratosPendientesGenerarComisionSuperior(COD_PROGRAMA_INGLES, codPer, codNivel, fechaContrato);
                    }
                });

                dtLiquidacionMensualSaldoAnterior = await task1;
                dtLiquidacionMensual = await task2;
                if (dtLiquidacionMensualSaldoAnterior != null)
                    dtLiquidacionMensual.Merge(dtLiquidacionMensualSaldoAnterior);
                dtComisionesDetalle = await taskComisionesDetalle;
                dtDevolucionesDetalle = await taskDevolucionesDetalle;
                dtOtrosCargosAbonosDetalle = await taskOtrosCargosAbonosDetalle;
                dtXComisionarDetalle = await taskXComisionarDetalle;
                DataTable dt = await taskXComisionarDetalle2;
                if (dtXComisionarDetalle != null)
                {
                    if (dt != null)
                        dtXComisionarDetalle.Merge(dt);
                }
                else dtXComisionarDetalle = dt;

                //> Datos para el reporte consolidado RptConsolidado1.rdlc
                //> dynamic selector(DataRow x) => new { COD_PER = x.Field<string>("A"), DESC_PER = x.Field<string>("B") };
                //> List<dynamic> lstCodPer = dtLiquidacionMensual.ToDistinct(selector);
                //> List<dynamic> lstCodPer2 = dtComisionesDetalle.ToDistinct(selector);
                //> List<dynamic> lstCodPer3 = dtDevolucionesDetalle.ToDistinct(selector);
                //> List<dynamic> lstCodPer4 = dtOtrosCargosAbonosDetalle.ToDistinct(selector);
                //> List<dynamic> lstCodPer5 = dtXComisionarDetalle.ToDistinct(selector);
                //> Esto se realizó con el objetivo de imprimir solo las personas de un determinado grupo(niveles de venta)
                dtPersonaConsolidado = ObtenerCodPerUnicos(BLPersona.ObtenerMaestroPersonaXNivelSinAnonimos(cboNivelVenta6.SelectedValue?.ToString())); //> ObtenerCodPerUnicos(lstCodPer, lstCodPer2, lstCodPer3, lstCodPer4, lstCodPer5);
                const string data_set_name = "DataSet1";
                string reporte = ObtenerRutaReporteTareaje("RptConsolidado1", Modulo.MOD_COMISIONES);
                //> Parámetros del reporte
                string vendedorText = string.Concat("Vendedor: ", cboPersona2.Text);
                string periodoText = string.Concat("Periodo: ", feMesPer.ToInt32().NombreMes(), "-", feAñoPer);
                string nivelVentaText = cboNivelVenta6.Text;
                string fechaText = string.Concat("Contratos por Comisionar al: ", dtFechaContrato6.Value.ToShortDateString());
                object[] parameters = { periodoText, vendedorText, nivelVentaText, codNivel, fechaText };

                //> Crea formulario y muestra el reporte
                frmLoading.CloseLoadingForm();
                ReportViewer reportViewer = null;
                Form frm = CreateReportForm(ref reportViewer, reporte, data_set_name, dtPersonaConsolidado, parameters);
                reportViewer.LocalReport.SubreportProcessing += LocalReport_SubreportProcessing;
                reportViewer.SetDisplayMode(DisplayMode.Normal);
                reportViewer.RefreshReport();
                frm.Show();
            }
            catch (Exception ex)
            {
                frmLoading.CloseLoadingForm();
                ex.PrintException();
            }
        }

        private void LocalReport_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
        {
            string codPer = e.Parameters[0].Values[0].ToString();
            dtDefaultSubReport = dtDefaultSubReport ?? CrearDatosVaciosSubReporte();
            dtDefaultSubReport.Rows[0]["B"] = dtPersonaConsolidado.AsEnumerable().First(x => x.Field<string>("A") == codPer)["B"];
            if (e.ReportPath == "subRepLiquidacionResum")
            {
                DataTable dtLiquidacionMensualGroup = null;
                if (dtLiquidacionMensual != null && dtLiquidacionMensual.Rows.Count > 0)
                {
                    EnumerableRowCollection<DataRow> rows = dtLiquidacionMensual.AsEnumerable().Where(x => x.Field<string>("A") == codPer);
                    if (rows.Count() > 0)
                        dtLiquidacionMensualGroup = rows.CopyToDataTable();
                }
                var dtLiquidacionMen = new ReportDataSource() { Name = "DataSet1", Value = dtLiquidacionMensualGroup ?? dtDefaultSubReport };
                e.DataSources.Add(dtLiquidacionMen);
            }
            if (e.ReportPath == "subRepComisionesDet" && nivelVenta6 == COD_NIVEL_VENDEDOR)
            {
                DataTable dtComisionesGroup = null;
                if (dtComisionesDetalle != null && dtComisionesDetalle.Rows.Count > 0)
                {
                    EnumerableRowCollection<DataRow> rows = dtComisionesDetalle.AsEnumerable().Where(x => x.Field<string>("A") == codPer);
                    if (rows.Count() > 0)
                        dtComisionesGroup = rows.CopyToDataTable();
                }
                var dtComisionesDet = new ReportDataSource() { Name = "DataSet1", Value = dtComisionesGroup ?? dtDefaultSubReport };
                e.DataSources.Add(dtComisionesDet);
            }
            if (e.ReportPath == "subRepComisionesDet2" && nivelVenta6 != COD_NIVEL_VENDEDOR)
            {
                DataTable dtComisionesGroup = null;
                if (dtComisionesDetalle != null && dtComisionesDetalle.Rows.Count > 0)
                {
                    EnumerableRowCollection<DataRow> rows = dtComisionesDetalle.AsEnumerable().Where(x => x.Field<string>("A") == codPer);
                    if (rows.Count() > 0)
                        dtComisionesGroup = rows.CopyToDataTable();
                }
                var dtComisionesDet = new ReportDataSource() { Name = "DataSet1", Value = dtComisionesGroup ?? dtDefaultSubReport };
                e.DataSources.Add(dtComisionesDet);
            }
            if (e.ReportPath == "subRepDevolucionesDet")
            {
                DataTable dtDevolucionesGroup = null;
                if (dtDevolucionesDetalle != null && dtDevolucionesDetalle.Rows.Count > 0)
                {
                    EnumerableRowCollection<DataRow> rows = dtDevolucionesDetalle.AsEnumerable().Where(x => x.Field<string>("A") == codPer);
                    if (rows.Count() > 0)
                        dtDevolucionesGroup = rows.CopyToDataTable();
                }
                var dtDevolucionesDet = new ReportDataSource() { Name = "DataSet1", Value = dtDevolucionesGroup ?? dtDefaultSubReport };
                e.DataSources.Add(dtDevolucionesDet);
            }
            if (e.ReportPath == "subRepOtrosCargosAbonosDet")
            {
                DataTable dtOtrosCargosAbonosGroup = null;
                if (dtOtrosCargosAbonosDetalle != null && dtOtrosCargosAbonosDetalle.Rows.Count > 0)
                {
                    EnumerableRowCollection<DataRow> rows = dtOtrosCargosAbonosDetalle.AsEnumerable().Where(x => x.Field<string>("A") == codPer);
                    if (rows.Count() > 0)
                        dtOtrosCargosAbonosGroup = rows.CopyToDataTable();
                }
                var dtOtrosCargosAbonosDet = new ReportDataSource() { Name = "DataSet1", Value = dtOtrosCargosAbonosGroup ?? dtDefaultSubReport };
                e.DataSources.Add(dtOtrosCargosAbonosDet);
            }
            if (e.ReportPath == "subRepXComisionarDetalle" && nivelVenta6 == COD_NIVEL_VENDEDOR)
            {
                DataTable dtXComisionarGroup = null;
                if (dtXComisionarDetalle != null && dtXComisionarDetalle.Rows.Count > 0)
                {
                    EnumerableRowCollection<DataRow> rows = dtXComisionarDetalle.AsEnumerable().Where(x => x.Field<string>("A") == codPer);
                    if (rows.Count() > 0)
                        dtXComisionarGroup = rows.CopyToDataTable();
                }
                var dtXComisionarDet = new ReportDataSource() { Name = "DataSet1", Value = dtXComisionarGroup ?? dtDefaultSubReport };
                e.DataSources.Add(dtXComisionarDet);
            }
            if (e.ReportPath == "subRepXComisionarDetalle2" && nivelVenta6 != COD_NIVEL_VENDEDOR)
            {
                DataTable dtXComisionarGroup = null;
                if (dtXComisionarDetalle != null && dtXComisionarDetalle.Rows.Count > 0)
                {
                    EnumerableRowCollection<DataRow> rows = dtXComisionarDetalle.AsEnumerable().Where(x => x.Field<string>("A") == codPer);
                    if (rows.Count() > 0)
                        dtXComisionarGroup = rows.CopyToDataTable();
                }
                var dtXComisionarDet = new ReportDataSource() { Name = "DataSet1", Value = dtXComisionarGroup ?? dtDefaultSubReport };
                e.DataSources.Add(dtXComisionarDet);
            }
        }

        /// <summary>
        /// Creamos datos vacios para los sub reportes que no tengan datos.
        /// Todos los reportes tienen la misma estructura de datos que es el objeto RptAll, por eso lo pasamos el mismo a todos.
        /// </summary>
        private DataTable CrearDatosVaciosSubReporte()
        {
            List<RptAll> lista = new List<RptAll>()
            {
                new RptAll()
            };
            return lista.ToDataTable();
        }

        /// <summary>
        /// Esto se realizó con el objetivo de imprimir solo las personas de un determinado grupo(niveles de venta)
        /// </summary>
        /// <param name="dtPersona"></param>
        /// <returns></returns>
        private DataTable ObtenerCodPerUnicos(DataTable dtPersona)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("A", typeof(string));
            dt.Columns.Add("B", typeof(string));

            if (cboPersona6.SelectedValue.ToString() != "0" && cboPersona6.SelectedValue.ToString() != string.Empty)
            {
                DataRow rw = dtPersona.AsEnumerable().FirstOrDefault(x => x.Field<string>("COD_PER") == cboPersona6.SelectedValue?.ToString());
                DataRow row = dt.NewRow();
                row["A"] = rw["COD_PER"].ToString();
                row["B"] = rw["DESC_PER"].ToString();
                dt.Rows.Add(row);
                return dt;
            }

            foreach (DataRow item in dtPersona.Rows)
            {
                DataRow row = dt.NewRow();
                row["A"] = item["COD_PER"].ToString();
                row["B"] = item["DESC_PER"].ToString();
                dt.Rows.Add(row);
            }
            return dt;
        }

        private async Task<DataTable> ObtenerSaldoAnterior(LiquidacionTo to)
        {
            DataRow row = ObtenerPeriodoSeleccionado();
            DataTable dt = await Task.Run(() => BLComision.LiquidacionSaldoAnteriorXPersona(to));
            var rowOnlyCodPersona = dt?.AsEnumerable().GroupBy(x => x.Field<string>("A"));
            if (dt == null)
                return null;
            DataTable dtDetalle = new DataTable();
            foreach (DataColumn column in dt.Columns)
            {
                dtDetalle.Columns.Add(column.ColumnName, column.DataType);
            }
            Task<DataTable> task2 = new TaskFactory<DataTable>().StartNew(() =>
            {
                DataTable dtPersona = null;
                decimal saldo_anterior = 0;
                decimal comisiones_vetas_propias = 0;
                decimal comisiones_ventas_tercero = 0;
                decimal devoluciones_ventas = 0;
                decimal comisiones_netas = 0;
                decimal otras_adiciones = 0;
                decimal total_ingresos = 0;
                decimal pago_cuenta_corriente = 0;
                decimal otras_deducciones = 0;
                decimal total_deducciones = otras_deducciones;
                decimal saldo_mes = 0;
                decimal saldo_pagar_fin_mes = 0;
                decimal cancelacion_cta_cte = 0;
                decimal saldo_final = 0;

                foreach (var group in rowOnlyCodPersona)
                {
                    DataRow rw = group.First();
                    dtPersona = dt.AsEnumerable().Where(x => x.Field<string>("A") == rw.Field<string>("A")).CopyToDataTable();
                    saldo_anterior = 0;
                    comisiones_vetas_propias = Convert.ToDecimal(dtPersona.AsEnumerable().SingleOrDefault(x => x.Field<int>("Z") == 1 && x.Field<int>("F") == 1)?.Field<decimal>("E"));
                    comisiones_ventas_tercero = Convert.ToDecimal(dtPersona.AsEnumerable().SingleOrDefault(x => x.Field<int>("Z") == 1 && x.Field<int>("F") == 2)?.Field<decimal>("E"));
                    devoluciones_ventas = Convert.ToDecimal(dtPersona.AsEnumerable().SingleOrDefault(x => x.Field<int>("Z") == 2)?.Field<decimal>("E"));
                    comisiones_netas = comisiones_vetas_propias + comisiones_ventas_tercero - devoluciones_ventas;
                    otras_adiciones = (decimal)(dtPersona.AsEnumerable().Where(x => x.Field<int>("Z") == 3 && x.Field<int>("D") == 1)?.Sum(f => f.Field<decimal>("E")));
                    total_ingresos = comisiones_netas + otras_adiciones;
                    pago_cuenta_corriente = Convert.ToDecimal(dtPersona.AsEnumerable().SingleOrDefault(x => x.Field<int>("Z") == 4)?.Field<decimal>("E"));
                    otras_deducciones = (decimal)(dtPersona.AsEnumerable().Where(x => x.Field<int>("Z") == 3 && x.Field<int>("D") == 2)?.Sum(f => f.Field<decimal>("E")));
                    total_deducciones = pago_cuenta_corriente + otras_deducciones;
                    saldo_mes = total_ingresos - total_deducciones;
                    saldo_pagar_fin_mes = saldo_anterior + saldo_mes;
                    cancelacion_cta_cte = Convert.ToDecimal(dtPersona.AsEnumerable().SingleOrDefault(x => x.Field<int>("Z") == 7 && x.Field<int>("F") == 3)?.Field<decimal>("E"));
                    saldo_final = saldo_pagar_fin_mes - cancelacion_cta_cte;

                    DataRow nrw = dtDetalle.NewRow();
                    nrw["Z"] = 0;
                    nrw["A"] = rw["A"];
                    nrw["B"] = dtPersona.Rows[0]["B"];
                    nrw["C"] = string.Empty;
                    nrw["D"] = 0;
                    nrw["F"] = 0;
                    nrw["E"] = saldo_final;
                    dtDetalle.Rows.Add(nrw);
                }
                return dtDetalle;
            });
            return await task2;
        }


        private bool ValidarGenerarReporteConsolidado()
        {
            if (string.IsNullOrEmpty(cboNivelVenta6.SelectedValue?.ToString()))
            {
                _ = MessageBox.Show("Seleccione un nivel de venta", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cboPersona6.SelectedValue == null)
            {
                _ = MessageBox.Show("Seleccione una persona", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(cboPeriodoGen6.SelectedValue?.ToString()) || (PeriodoSeleccionadoConsolidado != null && PeriodoSeleccionadoConsolidado["ID"].ToInt32() == 0))
            {
                _ = MessageBox.Show("Seleccione un período", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

       

        /// <summary>
        /// Obtiene contratos que no estan aprobados por nivel venta(supervisor, director de ventas, director nacional). 
        /// También obtiene contratos que no estan aprobados con o sin adelanto comisión
        /// </summary>
        /// <returns></returns>
        private Task<DataTable> ObtenerDatosXComisionarDetalle()
        {
            object[] parameters = ObtenerParametrosReporte4();
            string codPrograma = parameters[0].ToString();
            string codPer = parameters[1].ToString();
            DateTime fechaContrato = parameters[2].ToDateTime();
            string codNivelVenta = parameters[3].ToString();
            DateTime fechaAprobIni = parameters[4].ToDateTime();
            DateTime fechaAprobFin = parameters[5].ToDateTime();
            const string DIRECTOR = "02";
            Task<DataTable> dt = Task.Run(() =>
            {
                switch (codNivelVenta)
                {
                    case COD_NIVEL_VENDEDOR: 
                        return BLComision.RptContratosXGenerarYGeneradosAdelantoComisionSoloVenedor(codPrograma, codPer, fechaContrato, fechaAprobIni, fechaAprobFin);
                       
                    case DIRECTOR:
                        return BLComision.RptContratosXGenerarYGeneradosAdelantoComisionDirector(codPrograma, codPer, codNivelVenta, fechaContrato, fechaAprobIni, fechaAprobFin);

                    default: return BLComision.RptContratosXGenerarYGeneradosAdelantoComision(codPrograma, codPer, codNivelVenta, fechaContrato);
                }
            });
            return dt;
        }

        /// <summary>
        /// Obtiene contratos que estén pendietes por generar comisión menores o iguales a la fecha [fechaAprob] de nivel Venta(supervisor, director de ventas, director nacional).
        /// También obtiene contratos que estan pendientes por generar comisión menores o iguales a la [fechaAproba] de vendedores
        /// </summary>
        /// <returns></returns>
        private Task<DataTable> ObtenerDatosXComisionarDetalle2()
        {
            object[] parameters = ObtenerParametrosReporte4();
            string codPrograma = parameters[0].ToString();
            string codPer = parameters[1].ToString();
            DateTime fechaAproba = parameters[2].ToDateTime();
            string codNivelVenta = parameters[3].ToString();
            DateTime fechaAprobIni = parameters[4].ToDateTime();
            DateTime fechaAprobFin = parameters[5].ToDateTime();
            const string DIRECTOR = "02";
            Task<DataTable> dt = Task.Run(() =>
            {
                switch (codNivelVenta)
                {
                    case COD_NIVEL_VENDEDOR: return BLComision.RptContratosPendientesGenerarComisionSoloVendedor(codPrograma, codPer, fechaAproba, fechaAprobIni, fechaAprobFin);
                    case DIRECTOR:
                        return BLComision.RptContratosPendientesGenerarComisionSuperiorDirector(codPrograma, codPer, codNivelVenta, fechaAproba, fechaAprobIni, fechaAprobFin);

                    default: return BLComision.RptContratosPendientesGenerarComisionSuperior(codPrograma, codPer, codNivelVenta, fechaAproba);
                }
            });
            return dt;
        }

        private object[] ObtenerParametrosReporte4()
        {
            object[] parameters = null;
            if (InvokeRequired)
            {
                ObtenerParametrosRpt2 delParam = new ObtenerParametrosRpt2(ObtenerParametrosReporte4);
                _ = Invoke(delParam);
            }
            else
            {
                string codPrograma = COD_PROGRAMA_INGLES;
                string codPer = cboPersona5.SelectedValue?.ToString();
                DateTime fechaContrato = dtFechaContrato5.Value;
                string codNivelVenta = cboNivelVenta5.SelectedValue?.ToString();
                DateTime fechaAprobIni = dtpComisionar1.Value;
                DateTime fechaAprobFin = dtpComisionar2.Value;


                parameters = new object[] { codPrograma, codPer, fechaContrato, codNivelVenta, fechaAprobIni , fechaAprobFin };
            }
            return parameters;
        }

        private string ObtenerModeloReporteComision()
        {
            switch (cboNivelVenta2.SelectedValue?.ToString())
            {
                case COD_NIVEL_VENDEDOR: return ObtenerRutaReporteTareaje("RptComisionesDetalle", Modulo.MOD_COMISIONES);
                default: return ObtenerRutaReporteTareaje("RptComisionesDetalle2", Modulo.MOD_COMISIONES);
            }
        }

        private string ObtenerTituloReporte()
        {
            switch (cboNivelVenta2.SelectedValue?.ToString())
            {
                case COD_NIVEL_VENDEDOR: return "REPORTE DE COMISIONES VENTAS PROPIAS - POR VENDEDOR";
                default: return string.Concat("REPORTE DE COMISIONES POR TERCEROS - POR ", cboNivelVenta2.Text);
            }
        }

        private string ObtenerModeloReporteXComisionarDetalle()
        {
            switch (cboNivelVenta5.SelectedValue?.ToString())
            {
                //case COD_NIVEL_VENDEDOR: return ObtenerRutaReporteTareaje("RptXComisionarDetalle", Modulo.MOD_COMISIONES);
                case COD_NIVEL_VENDEDOR: return ObtenerRutaReporteTareaje("RptPorComisionarDetalle", Modulo.MOD_COMISIONES);
                //default: return ObtenerRutaReporteTareaje("RptXComisionarDetalle2", Modulo.MOD_COMISIONES);
                default: return ObtenerRutaReporteTareaje("RptPorComisionarDetalle2", Modulo.MOD_COMISIONES);
            }
        }

        private void rdbLiquidacion_CheckedChanged(object sender, EventArgs e)
        {
            grpLiquidacion.Visible = true;
            grpDetalleComision.Visible = false;
            grpDetalleDevolucion.Visible = false;
            grpConsolidado.Visible = false;
            grpOtrosCargos.Visible = false;
            grpComisionarDet.Visible = false;
            grpVentasHistoricas.Visible = false;
        }

        private void rdbDetalleComision_CheckedChanged(object sender, EventArgs e)
        {
            grpLiquidacion.Visible = false;
            grpDetalleComision.Visible = true;
            grpDetalleDevolucion.Visible = false;
            grpConsolidado.Visible = false;
            grpOtrosCargos.Visible = false;
            grpComisionarDet.Visible = false;
            grpVentasHistoricas.Visible = false;
        }

        private void rdbOtrosCargosAbonos_CheckedChanged(object sender, EventArgs e)
        {
            grpLiquidacion.Visible = false;
            grpDetalleComision.Visible = false;
            grpDetalleDevolucion.Visible = false;
            grpConsolidado.Visible = false;
            grpOtrosCargos.Visible = true;
            grpComisionarDet.Visible = false;
            grpVentasHistoricas.Visible = false;
        }

        private DataRow PeriodoSeleccionado
        {
            get
            {
                if (dtPeriodoGenerado != null && dtPeriodoGenerado.Rows.Count > 0)
                    return dtPeriodoGenerado.Select("ID = " + Convert.ToInt32(cboPeriodoGen2.SelectedValue)).FirstOrDefault();
                return null;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            grpLiquidacion.Visible = false;
            grpDetalleComision.Visible = false;
            grpDetalleDevolucion.Visible = false;
            grpConsolidado.Visible = false;
            grpOtrosCargos.Visible = false;
            grpComisionarDet.Visible = false;
            grpVentasHistoricas.Visible = true;
        }

        private DataRow PeriodoSeleccionadoDev
        {
            get
            {
                if (dtPeriodoGeneradoDev != null && dtPeriodoGeneradoDev.Rows.Count > 0)
                    return dtPeriodoGeneradoDev.Select("ID = " + Convert.ToInt32(cboPeriodoGen3.SelectedValue)).FirstOrDefault();
                return null;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            grpLiquidacion.Visible = false;
            grpDetalleComision.Visible = false;
            grpDetalleDevolucion.Visible = false;
            grpConsolidado.Visible = false;
            grpOtrosCargos.Visible = false;
            grpComisionarDet.Visible = false;
            grpVentasHistoricas.Visible = true;
        }

        private void rdbPorComisionarDetalle_CheckedChanged(object sender, EventArgs e)
        {
            grpLiquidacion.Visible = false;
            grpDetalleComision.Visible = false;
            grpDetalleDevolucion.Visible = false;
            grpConsolidado.Visible = false;
            grpOtrosCargos.Visible = false;
            grpComisionarDet.Visible = true;
            grpVentasHistoricas.Visible = false;
        }

        private void RdbDevolucionDetalle_CheckedChanged(object sender, EventArgs e)
        {
            grpLiquidacion.Visible = false;
            grpDetalleComision.Visible = false;
            grpDetalleDevolucion.Visible = true;
            grpConsolidado.Visible = false;
            grpOtrosCargos.Visible = false;
            grpComisionarDet.Visible = false;
            grpVentasHistoricas.Visible = false;
        }

        private void RdbComisionesHist_CheckedChanged(object sender, EventArgs e)
        {

            //tabControl1.SelectedTab = tpVentasAprobadas;
            grpLiquidacion.Visible = false;
            grpDetalleComision.Visible = false;
            grpDetalleDevolucion.Visible = false;
            grpConsolidado.Visible = false;
            grpOtrosCargos.Visible = false;
            grpComisionarDet.Visible = false;
            grpVentasHistoricas.Visible = true;
        }

        private void tpLiquidacion_Click(object sender, EventArgs e)
        {

        }

        private void rdbConsolidado_CheckedChanged(object sender, EventArgs e)
        {

        }

        private DataRow PeriodoGeneradoOtrosIngEgr
        {
            get
            {
                if (dtPeriodoGeneradoOtrosIngrEgr != null && dtPeriodoGeneradoOtrosIngrEgr.Rows.Count > 0)
                    return dtPeriodoGeneradoOtrosIngrEgr.AsEnumerable().FirstOrDefault(x => x["ID"].ToInt32() == cboPeriodoGen4.SelectedValue.ToInt32());
                return null;
            }
        }

        private DataRow PeriodoSeleccionadoConsolidado
        {
            get
            {
                if (dtPeriodoGenerado != null && dtPeriodoGenerado.Rows.Count > 0)
                    return dtPeriodoGenerado.Select("ID = " + Convert.ToInt32(cboPeriodoGen6.SelectedValue)).FirstOrDefault();
                return null;
            }
        }

        //private void RdbLiquidacion_Click(object sender, EventArgs e)
        //{
        //    tabControl1.SelectedTab = tpLiquidacion;
        //}

        //private void RdbDetalleComision_Click(object sender, EventArgs e)
        //{
        //    tabControl1.SelectedTab = tpDetalleComision;
        //}

        //private void RdbDevolucionDetalle_Click(object sender, EventArgs e)
        //{
        //    tabControl1.SelectedTab = tpDevolucionDetalle;
        //}

        //private void RdbCargosAbonos_Click(object sender, EventArgs e)
        //{
        //    tabControl1.SelectedTab = tpOtrosCargosAbonosDetalle;
        //}

        //private void RdbConsolidado_Click(object sender, EventArgs e)
        //{
        //    tabControl1.SelectedTab = tpConsolidado;
        //}

        //private void RdbPorComisionarDetalle_Click(object sender, EventArgs e)
        //{
        //    tabControl1.SelectedTab = tpXComisionarDetalle;
        //}

        //private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    rdbLiquidacion.Checked = tabControl1.SelectedTab == tpLiquidacion;
        //    rdbDetalleComision.Checked = tabControl1.SelectedTab == tpDetalleComision;
        //    rdbDevolucionDetalle.Checked = tabControl1.SelectedTab == tpDevolucionDetalle;
        //    rdbOtrosCargosAbonos.Checked = tabControl1.SelectedTab == tpOtrosCargosAbonosDetalle;
        //    rdbConsolidado.Checked = tabControl1.SelectedTab == tpConsolidado;
        //    rdbPorComisionarDetalle.Checked = tabControl1.SelectedTab == tpXComisionarDetalle;
        //    rdbComisionesHist.Checked = tabControl1.SelectedTab == tpVentasAprobadas;
        //}
    }
}
