using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL;
using Entidades;
using System.Threading;
using Presentacion.HELPERS;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Presentacion.MOD_CXC.Reportes.Formulario
{
    public partial class REPORTE_DE_COBRANZA_X_UBICACION : Form
    {
        private readonly cambioTipoPllaHistoricoBLL cphBLL = new cambioTipoPllaHistoricoBLL();
        private readonly cambioTipoPllaHistoricoTo cphTo = new cambioTipoPllaHistoricoTo();
        private DataTable dtReporte;
        private CancellationTokenSource cancelTokenSource;
        private CancellationToken cancelToken;

        private const string tabla1 = "GXUBI";
        private const string tipo1 = "D";
        private const string codNivel1 = "01";

        private delegate DataTable DelProceso(DateTime fechaAproIni, DateTime fechaAproFin, DateTime fechaCobraIni,
                DateTime fechaCobraFin, string codUbicacion, string codPrograma, string codGrupoUbicacion, string codSubUbicacion);

        public REPORTE_DE_COBRANZA_X_UBICACION()
        {
            InitializeComponent();
        }

        private void REPORTE_DE_COBRANZA_X_UBICACION_Load(object sender, EventArgs e)
        {
            CARGAR_PROGRAMAS();
            CARGAR_UBICACION();
            cboUbicacion.SelectedValue = "PD";
            CARGAR_GRUPO_UBICACION();
            CARGAR_GESTOR(null);
            cboSubUbicacion.Enabled = false;
            //rdbDetalle.Enabled = false;
            rdbDetalle.Enabled = true;
            dtpFecAprobDesde.Value = new DateTime(2019, 1, 1);
            dtpFecDesde.Value = new DateTime(2019, 1, 1);
            lblMessage.Visible = false;
            rdbIngreOtraUbicacion.Checked = true;
            rdbResumenComp.Checked = true;
        }
        private void CREAR_TABLA()
        {
            dtReporte.Columns.Add("NRO");
            dtReporte.Columns.Add("NOM_UBICACION");
            dtReporte.Columns.Add("SALDO_ANTERIOR");
            dtReporte.Columns.Add("INGRESAN_CLIENTES_OTRA_UBICACION");
            dtReporte.Columns.Add("PLANILLA_DEV_MERCADERIA");
            dtReporte.Columns.Add("PLANILLA_DESC_PRONTO_PAGO");
            dtReporte.Columns.Add("PASAN_CLIENTES_OTRA_UBICACION");
            dtReporte.Columns.Add("COBRANZA_CLIENTES");
            dtReporte.Columns.Add("SALDO_FINAL");
        }
        private void CARGAR_PROGRAMAS()
        {
            programaBLL prgBLL = new programaBLL();
            DataTable dt = prgBLL.obtenerProgramaBLL();
            cboPrograma.ValueMember = "COD_PROGRAMA";
            cboPrograma.DisplayMember = "DESC_PROGRAMA";
            cboPrograma.DataSource = dt;
            cboPrograma.SelectedIndex = 0;
        }

        private void CARGAR_UBICACION()
        {
            tipoPlanillaCreacionBLL tpcBLL = new tipoPlanillaCreacionBLL();
            DataTable dt = tpcBLL.obtenerTipoPlanillaUbicacionBLL();
            if (dt.Rows.Count > 0)
            {
                //DataRow rw = dt.NewRow();
                //rw["COD_TIPO_PLLA"] = "0";
                //rw["UBICACION"] = "Todos";
                //dt.Rows.InsertAt(rw, 0);
                cboUbicacion.ValueMember = "COD_TIPO_PLLA";
                cboUbicacion.DisplayMember = "UBICACION";
                cboUbicacion.DataSource = dt;
                cboUbicacion.SelectedValue.ToString();
            }
        }

        private void CARGAR_GRUPO_UBICACION()
        {
            directorioBLL dirBLL = new directorioBLL();
            directorioTo dirTo = new directorioTo();
            dirTo.TABLA_COD = "GXUBI";
            dirTo.TIPO = "D";
            DataTable dt = dirBLL.obtenerCodigoDescripcionDirectorioBLL(dirTo);//GrupoUbicacion
            DataTable dt1 = new DataTable();
            dt1.Columns.Add("CODIGO");
            dt1.Columns.Add("DESCRIPCION");
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("CODIGO");
            dt2.Columns.Add("DESCRIPCION");
            DataTable dt3 = new DataTable();
            dt3.Columns.Add("CODIGO");
            dt3.Columns.Add("DESCRIPCION");
            foreach (DataRow row in dt.Rows)
            {
                if (Convert.ToString(row["CODIGO"]) == "GDI1" || Convert.ToString(row["CODIGO"]) == "GDI2" || Convert.ToString(row["CODIGO"]) == "GDI3"
                    || row["CODIGO"].ToString() == "GDI4" || row["CODIGO"].ToString() == "GDI5" || row["CODIGO"].ToString() == "TRA4"
                    || row["CODIGO"].ToString() == "TRA2" || row["CODIGO"].ToString() == "TRA3" || row["CODIGO"].ToString() == "TRA1")
                {
                    DataRow r = dt1.NewRow();
                    r["CODIGO"] = row["CODIGO"];
                    r["DESCRIPCION"] = row["DESCRIPCION"];
                    dt1.Rows.Add(r);
                }
                else if (Convert.ToString(row["CODIGO"]) == "GPD1" || Convert.ToString(row["CODIGO"]) == "GPD2")
                {
                    DataRow r = dt2.NewRow();
                    r["CODIGO"] = row["CODIGO"];
                    r["DESCRIPCION"] = row["DESCRIPCION"];
                    dt2.Rows.Add(r);
                }
                else if (Convert.ToString(row["CODIGO"]) == "GVI1")
                {
                    DataRow r = dt3.NewRow();
                    r["CODIGO"] = row["CODIGO"];
                    r["DESCRIPCION"] = row["DESCRIPCION"];
                    dt3.Rows.Add(r);
                }
            }
            if (Convert.ToString(cboUbicacion.SelectedValue) == "PD")
            {
                if (dt1.Rows.Count > 0)
                {
                    DataRow rw = dt1.NewRow();
                    rw["CODIGO"] = "0";
                    rw["DESCRIPCION"] = "Todos";
                    dt1.Rows.InsertAt(rw, 0);
                    cboGrupoUbicacion.DataSource = dt1;
                    cboGrupoUbicacion.ValueMember = "CODIGO";
                    cboGrupoUbicacion.DisplayMember = "DESCRIPCION";
                }
            }
            else if (Convert.ToString(cboUbicacion.SelectedValue) == "PP")
            {
                if (dt2.Rows.Count > 0)
                {
                    DataRow rw = dt2.NewRow();
                    rw["CODIGO"] = "0";
                    rw["DESCRIPCION"] = "Todos";
                    dt2.Rows.InsertAt(rw, 0);
                    cboGrupoUbicacion.DataSource = dt2;
                    cboGrupoUbicacion.ValueMember = "CODIGO";
                    cboGrupoUbicacion.DisplayMember = "DESCRIPCION";
                }
                cboSubUbicacion.Enabled = false;
            }
            else if (Convert.ToString(cboUbicacion.SelectedValue) == "PV")
            {
                if (dt3.Rows.Count > 0)
                {
                    DataRow rw = dt3.NewRow();
                    rw["CODIGO"] = "0";
                    rw["DESCRIPCION"] = "Todos";
                    dt3.Rows.InsertAt(rw, 0);
                    cboGrupoUbicacion.DataSource = dt3;
                    cboGrupoUbicacion.ValueMember = "CODIGO";
                    cboGrupoUbicacion.DisplayMember = "DESCRIPCION";
                }
                cboSubUbicacion.Enabled = false;
            }
        }
        private void cboUbicacion_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cboGrupoUbicacion.SelectedIndex = 0;
            //cboGestor.SelectedIndex = 0;
            cboGrupoUbicacion.Enabled = true;
            cboSubUbicacion.Enabled = true;
            CARGAR_GRUPO_UBICACION();
        }

        private void cboGrupoUbicacion_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (Convert.ToString(cboGrupoUbicacion.SelectedValue) != "0" && cboUbicacion.SelectedValue.ToString() != "PP")
            {
                CARGAR_GESTOR(Convert.ToString(cboGrupoUbicacion.SelectedValue));
                cboSubUbicacion.SelectedIndex = 0;
                cboSubUbicacion.Enabled = true;
            }
            else if (Convert.ToString(cboGrupoUbicacion.SelectedValue) != "0")
            {
                CargarSubUbicacion(tabla1, tipo1, cboGrupoUbicacion.SelectedValue?.ToString(), codNivel1);
                cboSubUbicacion.Enabled = true;
            }
            else
            {
                cboSubUbicacion.SelectedIndex = 0;
                cboSubUbicacion.Enabled = false;
            }
            MOSTRAR_RBT_DETALLE();
        }
        private void CARGAR_GESTOR(string CODIGO)
        {
            personaBLL perBLL = new personaBLL();
            personaTo perTo = new personaTo();
            perTo.CODIGO = CODIGO;
            DataTable dt = perBLL.obtenerGestoresUbicacionBLL(perTo);
            if (dt.Rows.Count > 0)
            {
                DataRow rw = dt.NewRow();
                rw["COD_PER"] = "0";
                rw["DESC_PER"] = "Todos";
                dt.Rows.InsertAt(rw, 0);
                cboSubUbicacion.DataSource = dt;
                cboSubUbicacion.ValueMember = "COD_PER";
                cboSubUbicacion.DisplayMember = "DESC_PER";
                //cboGestor.SelectedIndex = -1;
            }
        }

        private void CargarSubUbicacion(string table, string tipo, string codigo, string codNivel)
        {
            personaBLL perBLL = new personaBLL();
            DataTable dt = perBLL.ObtenerSubUbicacion(table, tipo, codigo, codNivel);
            if (dt.Rows.Count > 0)
            {
                DataRow rw = dt.NewRow();
                rw["COD_PER"] = "0";
                rw["DESC_PER"] = "Todos";
                dt.Rows.InsertAt(rw, 0);
                cboSubUbicacion.DataSource = dt;
                cboSubUbicacion.ValueMember = "COD_PER";
                cboSubUbicacion.DisplayMember = "DESC_PER";
            }
        }

        private void btn_pantalla_Click(object sender, EventArgs e)
        {
            try
            {
                cancelTokenSource = new CancellationTokenSource();
                DataTable dt = null;
                string report, dataSetName, title;
                object[] parameters;
                string fechaAprobacion = dtpFecAprobDesde.Value.ToShortDateString() + " - " + dtpFecAprobHasta.Value.ToShortDateString();
                string fechaCobranza = dtpFecDesde.Value.ToShortDateString() + " - " + dtpFecHasta.Value.ToShortDateString();
                if (tabControl1.SelectedTab == tabPage1)
                {
                    if (rdbImportes.Checked)
                        reporteImportes();
                    else if (rdbCantidades.Checked)
                        reporteCantidades();
                    else if (rdbDetalle.Checked && rdbDetalle.Enabled)
                        reporteDetalle();
                    else if (rdbResumenDetallado.Checked)
                        reporteResumenDetallado();
                }
                else if (tabControl1.SelectedTab == tabPage2)
                {
                    if (rdbIngreOtraUbicacion.Checked)
                    {
                        report = GenericUtil.ObtenerRutaReporteTareaje_MOD_CXC("REP_COBRANZA_UBICACION_X_PERIODO_DETALLE_MOVIMIENTOS");
                        dataSetName = "cobranzaUbicacionDetalle";
                        dt = cboUbicacion.SelectedValue.ToString() == "PD"
                           ? cphBLL.RptMovimientoXUbicacionDirecta(dtpFecAprobDesde.Value, dtpFecAprobHasta.Value, dtpFecDesde.Value, dtpFecHasta.Value,
                           cboPrograma.SelectedValue.ToString(), cboUbicacion.SelectedValue.ToString(), cboGrupoUbicacion.SelectedValue.ToString(), cboSubUbicacion.SelectedValue.ToString())
                           : cphBLL.RptMovimientosXUbicacion(dtpFecAprobDesde.Value, dtpFecAprobHasta.Value, dtpFecDesde.Value, dtpFecHasta.Value,
                           cboPrograma.SelectedValue.ToString(), cboUbicacion.SelectedValue.ToString(), cboGrupoUbicacion.SelectedValue.ToString(), cboSubUbicacion.SelectedValue.ToString());
                        title = "MOVIMIENTOS DE CARTERA X UBICACIÓN - " + rdbIngreOtraUbicacion.Text;
                        parameters = new object[] { title, cboPrograma.Text, cboUbicacion.Text, fechaAprobacion, fechaCobranza, cboGrupoUbicacion.Text, cboSubUbicacion.Text };
                    }
                    else if (rdbSalidaOtrUbicacion.Checked)
                    {
                        report = GenericUtil.ObtenerRutaReporteTareaje_MOD_CXC("REP_COBRANZA_UBICACION_X_PERIODO_DETALLE_MOVIMIENTOS4");
                        dataSetName = "cobranzaUbicacionDetalle";
                        dt = cboUbicacion.SelectedValue.ToString() == "PD"
                           ? cphBLL.RptMovimientoXUbicacionDirecta(dtpFecAprobDesde.Value, dtpFecAprobHasta.Value, dtpFecDesde.Value, dtpFecHasta.Value,
                           cboPrograma.SelectedValue.ToString(), cboUbicacion.SelectedValue.ToString(), cboGrupoUbicacion.SelectedValue.ToString(), cboSubUbicacion.SelectedValue.ToString())
                           : cphBLL.RptMovimientosXUbicacion(dtpFecAprobDesde.Value, dtpFecAprobHasta.Value, dtpFecDesde.Value, dtpFecHasta.Value,
                           cboPrograma.SelectedValue.ToString(), cboUbicacion.SelectedValue.ToString(), cboGrupoUbicacion.SelectedValue.ToString(), cboSubUbicacion.SelectedValue.ToString());
                        title = "MOVIMIENTOS DE CARTERA X UBICACIÓN - " + rdbSalidaOtrUbicacion.Text;
                        parameters = new object[] { title, cboPrograma.Text, cboUbicacion.Text, fechaAprobacion, fechaCobranza, cboGrupoUbicacion.Text, cboSubUbicacion.Text };
                    }
                    else if (rdbCancelCobOtrUbicacion.Checked)
                    {
                        report = cboUbicacion.SelectedValue.ToString() == "PD"
                            ? GenericUtil.ObtenerRutaReporteTareaje_MOD_CXC("REP_COBRANZA_UBICACION_X_PERIODO_DETALLE_MOVIMIENTOS2")
                            : GenericUtil.ObtenerRutaReporteTareaje_MOD_CXC("REP_COBRANZA_UBICACION_X_PERIODO_DETALLE_MOVIMIENTOS8");
                        dataSetName = "cobranzaUbicacionDetalle";
                        dt = dt = cboUbicacion.SelectedValue.ToString() == "PD"
                           ? cphBLL.RptMovimientoXUbicacionDirecta2(dtpFecAprobDesde.Value, dtpFecAprobHasta.Value, dtpFecDesde.Value, dtpFecHasta.Value,
                           cboPrograma.SelectedValue.ToString(), cboUbicacion.SelectedValue.ToString(), cboGrupoUbicacion.SelectedValue.ToString(), cboSubUbicacion.SelectedValue.ToString())
                           : cphBLL.RptMovimientosXUbicacion2(dtpFecAprobDesde.Value, dtpFecAprobHasta.Value, dtpFecDesde.Value, dtpFecHasta.Value,
                           cboPrograma.SelectedValue.ToString(), cboUbicacion.SelectedValue.ToString(), cboGrupoUbicacion.SelectedValue.ToString(), cboSubUbicacion.SelectedValue.ToString());
                        title = "AMOVIMIENTOS DE CARTERA X UBICACIÓN - " + rdbCancelCobOtrUbicacion.Text;
                        parameters = new object[] { title, cboPrograma.Text, cboUbicacion.Text, fechaAprobacion, fechaCobranza, cboGrupoUbicacion.Text, cboSubUbicacion.Text, cboUbicacion.SelectedValue.ToString() };
                    }
                    else if (rdbCancelEstaUbicacion.Checked)
                    {
                        report = GenericUtil.ObtenerRutaReporteTareaje_MOD_CXC("REP_COBRANZA_UBICACION_X_PERIODO_DETALLE_MOVIMIENTOS3");
                        dataSetName = "cobranzaUbicacionDetalle";
                        dt = dt = cboUbicacion.SelectedValue.ToString() == "PD"
                           ? cphBLL.RptMovimientoXUbicacionDirecta2(dtpFecAprobDesde.Value, dtpFecAprobHasta.Value, dtpFecDesde.Value, dtpFecHasta.Value,
                           cboPrograma.SelectedValue.ToString(), cboUbicacion.SelectedValue.ToString(), cboGrupoUbicacion.SelectedValue.ToString(), cboSubUbicacion.SelectedValue.ToString())
                           : cphBLL.RptMovimientosXUbicacion2(dtpFecAprobDesde.Value, dtpFecAprobHasta.Value, dtpFecDesde.Value, dtpFecHasta.Value,
                           cboPrograma.SelectedValue.ToString(), cboUbicacion.SelectedValue.ToString(), cboGrupoUbicacion.SelectedValue.ToString(), cboSubUbicacion.SelectedValue.ToString());
                        title = "MOVIMIENTOS DE CARTERA X UBICACIÓN - " + rdbCancelEstaUbicacion.Text;
                        parameters = new object[] { title, cboPrograma.Text, cboUbicacion.Text, fechaAprobacion, fechaCobranza, cboGrupoUbicacion.Text, cboSubUbicacion.Text, cboUbicacion.SelectedValue.ToString() };
                    }
                    else if (rdbCancelDevolMercaderia.Checked)
                    {
                        report = GenericUtil.ObtenerRutaReporteTareaje_MOD_CXC("REP_COBRANZA_UBICACION_X_PERIODO_DETALLE_MOVIMIENTOS5");
                        dataSetName = "cobranzaUbicacionDetalle";
                        dt = dt = cboUbicacion.SelectedValue.ToString() == "PD"
                           ? cphBLL.RptMovimientoXUbicacionDirecta2(dtpFecAprobDesde.Value, dtpFecAprobHasta.Value, dtpFecDesde.Value, dtpFecHasta.Value,
                           cboPrograma.SelectedValue.ToString(), cboUbicacion.SelectedValue.ToString(), cboGrupoUbicacion.SelectedValue.ToString(), cboSubUbicacion.SelectedValue.ToString())
                           : cphBLL.RptMovimientosXUbicacion2(dtpFecAprobDesde.Value, dtpFecAprobHasta.Value, dtpFecDesde.Value, dtpFecHasta.Value,
                           cboPrograma.SelectedValue.ToString(), cboUbicacion.SelectedValue.ToString(), cboGrupoUbicacion.SelectedValue.ToString(), cboSubUbicacion.SelectedValue.ToString());
                        title = "MOVIMIENTOS DE CARTERA X UBICACIÓN - " + rdbCancelDevolMercaderia.Text;
                        parameters = new object[] { title, cboPrograma.Text, cboUbicacion.Text, fechaAprobacion, fechaCobranza, cboGrupoUbicacion.Text, cboSubUbicacion.Text, cboUbicacion.SelectedValue.ToString() };
                    }
                    else if (rdbCancelProPago.Checked)
                    {
                        report = GenericUtil.ObtenerRutaReporteTareaje_MOD_CXC("REP_COBRANZA_UBICACION_X_PERIODO_DETALLE_MOVIMIENTOS7");
                        dataSetName = "cobranzaUbicacionDetalle";
                        dt = dt = cboUbicacion.SelectedValue.ToString() == "PD"
                           ? cphBLL.RptMovimientoXUbicacionDirecta2(dtpFecAprobDesde.Value, dtpFecAprobHasta.Value, dtpFecDesde.Value, dtpFecHasta.Value,
                           cboPrograma.SelectedValue.ToString(), cboUbicacion.SelectedValue.ToString(), cboGrupoUbicacion.SelectedValue.ToString(), cboSubUbicacion.SelectedValue.ToString())
                           : cphBLL.RptMovimientosXUbicacion2(dtpFecAprobDesde.Value, dtpFecAprobHasta.Value, dtpFecDesde.Value, dtpFecHasta.Value,
                           cboPrograma.SelectedValue.ToString(), cboUbicacion.SelectedValue.ToString(), cboGrupoUbicacion.SelectedValue.ToString(), cboSubUbicacion.SelectedValue.ToString());
                        title = "MOVIMIENTOS DE CARTERA X UBICACIÓN - " + rdbCancelProPago.Text;
                        parameters = new object[] { title, cboPrograma.Text, cboUbicacion.Text, fechaAprobacion, fechaCobranza, cboGrupoUbicacion.Text, cboSubUbicacion.Text, cboUbicacion.SelectedValue.ToString() };
                    }
                    else
                        throw new ArgumentNullException();
                    Form frm = GenericUtil.CreateReportForm(report, dataSetName, dt, parameters);
                    frm.Show();
                }
                else if (tabControl1.SelectedTab == tabPage3)
                {
                    if (rdbResumenComp.Checked)
                    {
                        report = GenericUtil.ObtenerRutaReporteTareaje_MOD_CXC("REP_COBRANZA_UBICACION_X_PERIODO_DETALLE_MOVIMIENTOS_COMP");
                        dataSetName = "cobranzaUbicacionDetalle";
                        title = "MOVIMIENTOS DE CARTERA X UBICACIÓN - " + rdbResumenComp.Text;
                        parameters = new object[] { title, cboPrograma.Text, cboUbicacion.Text, fechaAprobacion, fechaCobranza, cboGrupoUbicacion.Text, cboSubUbicacion.Text, cboUbicacion.SelectedValue.ToString() };
                        dt = AnalisisCarteraComparativo();
                        // >cphBLL.RptMovimientoCarteraComparativoMes(dtpFecAprobDesde.Value, dtpFecAprobHasta.Value, dtpFecDesde.Value, dtpFecHasta.Value,
                        //> cboPrograma.SelectedValue.ToString(), cboUbicacion.SelectedValue.ToString(), cboGrupoUbicacion.SelectedValue.ToString(), cboSubUbicacion.SelectedValue.ToString());
                    }
                    else if (rdbCompCant.Checked)
                    {
                        report = GenericUtil.ObtenerRutaReporteTareaje_MOD_CXC("REP_COBRANZA_UBICACION_X_PERIODO_DETALLE_MOVIMIENTOS_COMP2");
                        dataSetName = "cobranzaUbicacionDetalle";
                        title = "MOVIMIENTOS DE CARTERA X UBICACIÓN - " + rdbCompCant.Text;
                        parameters = new object[] { title, cboPrograma.Text, cboUbicacion.Text, fechaAprobacion, fechaCobranza, cboGrupoUbicacion.Text, cboSubUbicacion.Text, cboUbicacion.SelectedValue.ToString() };
                        dt = AnalisisCarteraComparativoCant();
                    }
                    else
                        throw new ArgumentNullException();
                    Form frm = GenericUtil.CreateReportForm(report, dataSetName, dt, parameters);
                    frm.Show();
                }
            }
            catch (Exception ex)
            {
                ex.PrintException();
            }
        }

        private DataTable AnalisisCarteraComparativo()
        {
            DataTable dt = cphBLL.RptMovimientoCarteraComparativoMes(dtpFecAprobDesde.Value, dtpFecAprobHasta.Value, dtpFecDesde.Value, dtpFecHasta.Value,
                           cboPrograma.SelectedValue.ToString(), cboUbicacion.SelectedValue.ToString(), cboGrupoUbicacion.SelectedValue.ToString(), cboSubUbicacion.SelectedValue.ToString());
            if (dt != null)
            {
                dt.Columns["SALDO_ANTERIOR"].ReadOnly = false;
                dt.Columns["SALDO_FINAL"].ReadOnly = false;
                double saldo = 0.0;
                double saldoInicial = 0;
                int año = 0;
                int mes = 0;
                bool act = true;

                foreach (DataRow rw in dt.Rows)
                {
                    if (Convert.ToInt32(rw["W"]) == 1)
                        saldoInicial += Convert.ToDouble(rw["E"]);
                }

                foreach (DataRow row in dt.Rows)
                {
                    if (string.IsNullOrEmpty(row["A"].ToString()))
                        continue;

                    if (año == 0 && mes == 0)
                    {
                        año = Convert.ToInt32(row["B"]);
                        mes = Convert.ToInt32(row["C"]);
                    }

                    if (Convert.ToInt32(row["B"]) != año || Convert.ToInt32(row["C"]) != mes)
                    {
                        act = true;
                        saldoInicial = saldo;
                        saldo = 0;
                        año = Convert.ToInt32(row["B"]);
                        mes = Convert.ToInt32(row["C"]);
                    }

                    if (Convert.ToInt32(row["B"]) == año && Convert.ToInt32(row["C"]) == mes)
                    {
                        saldoInicial = act ? saldoInicial : 0;
                        saldo += saldoInicial + Convert.ToDouble(row["INGRESO_CLIENTES_OTRA_UBICACION"])
                            - Convert.ToDouble(row["CANCELACION_X_PLLA_DEV_MERCADERIA"]) - Convert.ToDouble(row["CANCELACION_X_PLLA_PRONTO_PAGO"])
                            - Convert.ToDouble(row["COBRANZA_CLIENTES"]) - Convert.ToDouble(row["COBRANZA_OTROS_CLIENTES"])
                            - Convert.ToDouble(row["J"]) - Convert.ToDouble(row["PASAN_CLIENTES_OTRA_UBICACION"]);
                        row["SALDO_ANTERIOR"] = saldoInicial;
                        row["SALDO_FINAL"] = saldo;
                        act = false;
                    }
                }
            }
            return dt;
        }

        private DataTable AnalisisCarteraComparativoCant()
        {
            DataTable dt = cphBLL.RptMovimientoCarteraComparativoMes(dtpFecAprobDesde.Value, dtpFecAprobHasta.Value, dtpFecDesde.Value, dtpFecHasta.Value,
                           cboPrograma.SelectedValue.ToString(), cboUbicacion.SelectedValue.ToString(), cboGrupoUbicacion.SelectedValue.ToString(), cboSubUbicacion.SelectedValue.ToString());
            if (dt != null)
            {
                dt.Columns["SALDO_ANTERIOR"].ReadOnly = false;
                dt.Columns["SALDO_FINAL"].ReadOnly = false;
                int saldo = 0;
                int saldoInicial = 0;
                int año = 0;
                int mes = 0;
                bool act = true;
                int a1, a2, a3, a4, a5, a6, a7;

                foreach (DataRow rw in dt.Rows)
                {
                    if (Convert.ToInt32(rw["W"]) == 1)
                        saldoInicial += Convert.ToDouble(rw["E"]) > 0 ? 1 : 0;
                }

                foreach (DataRow row in dt.Rows)
                {
                    if (string.IsNullOrEmpty(row["A"].ToString()))
                        continue;

                    if (año == 0 && mes == 0)
                    {
                        año = Convert.ToInt32(row["B"]);
                        mes = Convert.ToInt32(row["C"]);
                    }

                    if (Convert.ToInt32(row["B"]) != año || Convert.ToInt32(row["C"]) != mes)
                    {
                        act = true;
                        saldoInicial = saldo;
                        saldo = 0;
                        año = Convert.ToInt32(row["B"]);
                        mes = Convert.ToInt32(row["C"]);
                    }

                    if (Convert.ToInt32(row["B"]) == año && Convert.ToInt32(row["C"]) == mes)
                    {
                        saldoInicial = act ? saldoInicial : 0;
                        a1 = Convert.ToDouble(row["INGRESO_CLIENTES_OTRA_UBICACION"]) > 0 ? 1 : 0;
                        a2 = Convert.ToDouble(row["CANCELACION_X_PLLA_DEV_MERCADERIA"]) > 0 ? 1 : 0;
                        a3 = Convert.ToDouble(row["CANCELACION_X_PLLA_PRONTO_PAGO"]) > 0 ? 1 : 0;
                        a4 = Convert.ToDouble(row["COBRANZA_CLIENTES"]) > 0 ? 1 : 0;
                        a5 = Convert.ToDouble(row["COBRANZA_OTROS_CLIENTES"]) > 0 ? 1 : 0;
                        a6 = Convert.ToDouble(row["J"]) > 0 ? 1 : 0;
                        a7 = Convert.ToDouble(row["PASAN_CLIENTES_OTRA_UBICACION"]) > 0 ? 1 : 0;
                        saldo += saldoInicial + a1 - a2 - a3 - a4 - a5 - a6 - a7;
                        row["SALDO_ANTERIOR"] = saldoInicial;
                        row["SALDO_FINAL"] = saldo;
                        act = false;
                    }
                }
            }
            return dt;
        }

        private bool validaPantalla()
        {
            bool result = true;
            if (Convert.ToString(cboUbicacion.SelectedValue) == "0")
            {
                MessageBox.Show("ELija la Nueva Ubicacion !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboUbicacion.Focus();
                return result = false;
            }
            if (Convert.ToString(cboGrupoUbicacion.SelectedValue) == "PD")
            {
                if (Convert.ToString(cboGrupoUbicacion.SelectedValue) == "0")
                {
                    MessageBox.Show("Elija el Grupo de Ubicacion !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cboGrupoUbicacion.Focus();
                    return result = false;
                }
                if (Convert.ToString(cboSubUbicacion.SelectedValue) == "0")
                {
                    MessageBox.Show("Elija la Sub Ubicacion !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cboSubUbicacion.Focus();
                    return result = false;
                }
            }
            return result;
        }
        private async void reporteImportes()
        {
            HELPERS.Forms.FrmLoading frmLoading = null;
            try
            {
                if (!validaPantalla())
                    return;

                DateTime fechaAproIni = dtpFecAprobDesde.Value;
                DateTime fechaAproFin = dtpFecAprobHasta.Value;
                DateTime fechaCobraIni = dtpFecDesde.Value;
                DateTime fechaCobraFin = dtpFecHasta.Value;
                string codUbicacion = cboUbicacion.SelectedValue.ToString();
                string codPrograma = cboPrograma.SelectedValue.ToString();
                string codGrupoUbicacion = cboGrupoUbicacion.SelectedValue.ToString();
                string codSubUbicacion = cboSubUbicacion.SelectedValue.ToString();

                frmLoading = new HELPERS.Forms.FrmLoading()
                {
                    Owner = this,
                    ShowInTaskbar = false
                };
                frmLoading.Show();
                cancelToken = cancelTokenSource.Token;
                Task<DataTable> task1 = Task<DataTable>.Factory.StartNew(() => ObtenerData(fechaAproIni, fechaAproFin,
                    fechaCobraIni, fechaCobraFin, codUbicacion, codPrograma, codGrupoUbicacion, codSubUbicacion), cancelTokenSource.Token);
                _ = await task1;
                DataTable dtUbicaciones = task1.Result;
                frmLoading.Close();

                if (dtUbicaciones.Rows.Count > 0)
                {
                    FormRep.REP_DE_COBRANZA_X_UBICACION frm = new FormRep.REP_DE_COBRANZA_X_UBICACION(dtUbicaciones);
                    frm.nombre_reporte = "MOVIMIENTOS DE CARTERA X UBICACIÓN - Resumen por Importes";
                    frm.programa = cboPrograma.Text;
                    frm.ubicacion = cboUbicacion.Text; //+ " - " + cboGrupoUbicacion.Text + " - " + cboSubUbicacion.Text;
                    frm.grupo = cboGrupoUbicacion.Text;
                    frm.sub_ubicacion = cboSubUbicacion.Text;
                    frm.fechaAprobacion = "De " + dtpFecAprobDesde.Value.ToShortDateString() + " Al " + dtpFecAprobHasta.Value.ToShortDateString();
                    frm.fechaCobranzas = "De " + dtpFecDesde.Value.ToShortDateString() + " Al " + dtpFecHasta.Value.ToShortDateString();
                    //> frm.lstcph = lcph;
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("No existen datos !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 0 && cancelToken.IsCancellationRequested)
                {
                    frmLoading.CloseLoadingForm();
                    _ = MessageBox.Show("Proceso cancelado", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cancelTokenSource.Dispose();
                }
                else
                    ex.PrintException();
            }
            catch (Exception ex)
            {
                if (frmLoading != null)
                    frmLoading.Close();
                ex.PrintException();
            }
        }

        private async void reporteCantidades()
        {
            HELPERS.Forms.FrmLoading frmLoading = null;
            try
            {
                if (!validaPantalla())
                    return;

                DateTime fechaAproIni = dtpFecAprobDesde.Value;
                DateTime fechaAproFin = dtpFecAprobHasta.Value;
                DateTime fechaCobraIni = dtpFecDesde.Value;
                DateTime fechaCobraFin = dtpFecHasta.Value;
                string codUbicacion = cboUbicacion.SelectedValue.ToString();
                string codPrograma = cboPrograma.SelectedValue.ToString();
                string codGrupoUbicacion = cboGrupoUbicacion.SelectedValue.ToString();
                string codSubUbicacion = cboSubUbicacion.SelectedValue.ToString();

                frmLoading = new HELPERS.Forms.FrmLoading()
                {
                    Owner = this,
                    ShowInTaskbar = false
                };
                frmLoading.Show();
                cancelToken = cancelTokenSource.Token;
                Task<DataTable> task1 = Task<DataTable>.Factory.StartNew(() => ObtenerData(fechaAproIni, fechaAproFin,
                    fechaCobraIni, fechaCobraFin, codUbicacion, codPrograma, codGrupoUbicacion, codSubUbicacion), cancelTokenSource.Token);
                _ = await task1;
                DataTable dtUbicaciones = task1.Result;
                frmLoading.Close();


                if (dtUbicaciones.Rows.Count > 0)
                {
                    FormRep.REP_DE_COBRANZA_X_UBICACION_CANTIDADES frm = new FormRep.REP_DE_COBRANZA_X_UBICACION_CANTIDADES(dtUbicaciones);
                    frm.nombre_reporte = "MOVIMIENTOS DE CARTERA X UBICACIÓN - Resumen por Cantidad";
                    frm.programa = cboPrograma.Text;
                    frm.ubicacion = cboUbicacion.Text; //+ " - " + cboGrupoUbicacion.Text + " - " + cboSubUbicacion.Text;
                    frm.grupo = cboGrupoUbicacion.Text;
                    frm.sub_ubicacion = cboSubUbicacion.Text;
                    frm.fechaAprobacion = "De " + dtpFecAprobDesde.Value.ToShortDateString() + " Al " + dtpFecAprobHasta.Value.ToShortDateString();
                    frm.fechaCobranzas = "De " + dtpFecDesde.Value.ToShortDateString() + " Al " + dtpFecHasta.Value.ToShortDateString();
                    //> frm.lstcph = lcph;
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("No existen datos !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 0 && cancelToken.IsCancellationRequested)
                {
                    frmLoading.CloseLoadingForm();
                    _ = MessageBox.Show("Proceso cancelado", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cancelTokenSource.Dispose();
                }
                else
                    ex.PrintException();
            }
            catch (Exception ex)
            {
                if (frmLoading != null)
                    frmLoading.Close();
                ex.PrintException();
            }
        }

        private async void reporteDetalle()
        {
            HELPERS.Forms.FrmLoading frmLoading = null;
            if (!validaPantalla())
                return;
            try
            {
                DateTime fechaAproIni = dtpFecAprobDesde.Value;
                DateTime fechaAproFin = dtpFecAprobHasta.Value;
                DateTime fechaCobraIni = dtpFecDesde.Value;
                DateTime fechaCobraFin = dtpFecHasta.Value;
                string codUbicacion = cboUbicacion.SelectedValue.ToString();
                string codPrograma = cboPrograma.SelectedValue.ToString();
                string codGrupoUbicacion = cboGrupoUbicacion.SelectedValue.ToString();
                string codSubUbicacion = cboSubUbicacion.SelectedValue.ToString();

                frmLoading = new HELPERS.Forms.FrmLoading()
                {
                    Owner = this,
                    ShowInTaskbar = false
                };
                frmLoading.Show();
                cancelToken = cancelTokenSource.Token;
                Task<DataTable> task1 = Task<DataTable>.Factory.StartNew(() => ObtenerData(fechaAproIni, fechaAproFin,
                    fechaCobraIni, fechaCobraFin, codUbicacion, codPrograma, codGrupoUbicacion, codSubUbicacion), cancelTokenSource.Token);
                _ = await task1;
                DataTable dtObtenerReporteCobranzaUbicacionDetalle = task1.Result;
                frmLoading.Close();

                //DataTable dtObtenerReporteCobranzaUbicacionDetalle;
                if (dtObtenerReporteCobranzaUbicacionDetalle.Rows.Count > 0)
                {
                    FormRep.REP_DE_COBRANZA_X_UBICACION_DETALLE frm = new FormRep.REP_DE_COBRANZA_X_UBICACION_DETALLE(dtObtenerReporteCobranzaUbicacionDetalle)
                    {
                        nombre_reporte = "MOVIMIENTOS DE CARTERA X UBICACIÓN - Detallado por Contratos",
                        programa = cboPrograma.Text,
                        ubicacion = cboUbicacion.Text, //+ " - " + cboGrupoUbicacion.Text + " - " + cboSubUbicacion.Text;
                        grupo = cboGrupoUbicacion.Text,
                        sub_ubicacion = cboSubUbicacion.Text,
                        fechaAprobacion = "De " + dtpFecAprobDesde.Value.ToShortDateString() + " Al " + dtpFecAprobHasta.Value.ToShortDateString(),
                        fechaCobranzas = "De " + dtpFecDesde.Value.ToShortDateString() + " Al " + dtpFecHasta.Value.ToShortDateString(),
                        //frm.lstcph = lcph;
                        act = cboUbicacion.SelectedValue.ToString() != "PD" ? 0 : 1
                    };
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("No existen datos !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 0 && cancelToken.IsCancellationRequested)
                {
                    frmLoading.CloseLoadingForm();
                    _ = MessageBox.Show("Proceso cancelado", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cancelTokenSource.Dispose();
                }
                else
                    ex.PrintException();
            }
            catch (Exception ex)
            {
                if (frmLoading != null)
                    frmLoading.Close();
                ex.PrintException();
            }
        }

        private async void reporteResumenDetallado()
        {
            HELPERS.Forms.FrmLoading frmLoading = null;
            try
            {
                if (!validaPantalla())
                    return;

                DateTime fechaAproIni = dtpFecAprobDesde.Value;
                DateTime fechaAproFin = dtpFecAprobHasta.Value;
                DateTime fechaCobraIni = dtpFecDesde.Value;
                DateTime fechaCobraFin = dtpFecHasta.Value;
                string codUbicacion = cboUbicacion.SelectedValue.ToString();
                string codPrograma = cboPrograma.SelectedValue.ToString();
                string codGrupoUbicacion = cboGrupoUbicacion.SelectedValue.ToString();
                string codSubUbicacion = cboSubUbicacion.SelectedValue.ToString();

                frmLoading = new HELPERS.Forms.FrmLoading()
                {
                    Owner = this,
                    ShowInTaskbar = false
                };
                frmLoading.Show();
                cancelToken = cancelTokenSource.Token;
                Task<DataTable> task1 = Task<DataTable>.Factory.StartNew(() => ObtenerData(fechaAproIni, fechaAproFin,
                    fechaCobraIni, fechaCobraFin, codUbicacion, codPrograma, codGrupoUbicacion, codSubUbicacion), cancelTokenSource.Token);
                _ = await task1;
                DataTable dtReporteCobranzaUbicacionResumenDetallado = task1.Result;
                frmLoading.Close();

                if (dtReporteCobranzaUbicacionResumenDetallado.Rows.Count > 0)
                {
                    FormRep.REP_DE_COBRANZA_X_UBICACION_RESUMEN_DETALLADO frm = new FormRep.REP_DE_COBRANZA_X_UBICACION_RESUMEN_DETALLADO(dtReporteCobranzaUbicacionResumenDetallado);
                    frm.nombre_reporte = "MOVIMIENTOS DE CARTERA X UBICACIÓN - Resumen Detallado";
                    frm.programa = cboPrograma.Text;
                    frm.ubicacion = cboUbicacion.Text; //+ " - " + cboGrupoUbicacion.Text + " - " + cboSubUbicacion.Text;
                    frm.grupo = cboGrupoUbicacion.Text;
                    frm.sub_ubicacion = cboSubUbicacion.Text;
                    frm.fechaAprobacion = "De " + dtpFecAprobDesde.Value.ToShortDateString() + " Al " + dtpFecAprobHasta.Value.ToShortDateString();
                    frm.fechaCobranzas = "De " + dtpFecDesde.Value.ToShortDateString() + " Al " + dtpFecHasta.Value.ToShortDateString();
                    //> frm.lstcph = lcph;
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("No existen datos !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 0 && cancelToken.IsCancellationRequested)
                {
                    frmLoading.CloseLoadingForm();
                    _ = MessageBox.Show("Proceso cancelado", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cancelTokenSource.Dispose();
                }
                else
                    ex.PrintException();
            }
            catch (Exception ex)
            {
                if (frmLoading != null)
                    frmLoading.Close();
                ex.PrintException();
            }
        }

        private DataTable ObtenerData(DateTime fechaAproIni, DateTime fechaAproFin, DateTime fechaCobraIni,
                DateTime fechaCobraFin, string codUbicacion, string codPrograma, string codGrupoUbicacion, string codSubUbicacion)
        {
            DataTable dtObtenerReporteCobranzaUbicacionDetalle = codUbicacion != "PD"
                            ? cphBLL.RptCobrazaUbicacionDetalle(cancelToken, fechaAproIni, fechaAproFin,
                            fechaCobraIni, fechaCobraFin, codUbicacion, codPrograma, codGrupoUbicacion, codSubUbicacion)
                            : cphBLL.RptCobrazaUbicacionDetalleDir(cancelToken, fechaAproIni, fechaAproFin,
                            fechaCobraIni, fechaCobraFin, codUbicacion, codPrograma, codGrupoUbicacion, codSubUbicacion);

            return dtObtenerReporteCobranzaUbicacionDetalle;
        }

        private void cboSubUbicacion_SelectionChangeCommitted(object sender, EventArgs e)
        {
            MOSTRAR_RBT_DETALLE();
        }
        private void MOSTRAR_RBT_DETALLE()
        {
            if (Convert.ToString(cboUbicacion.SelectedValue) == "PD" && Convert.ToString(cboGrupoUbicacion.SelectedValue) == "GDI1" && Convert.ToString(cboSubUbicacion.SelectedValue) != "0")
                rdbDetalle.Enabled = true;
            else
                rdbDetalle.Enabled = true; //rdbDetalle.Enabled = false;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cancelTokenSource != null)
                    cancelTokenSource.Cancel();
            }
            catch (ObjectDisposedException)
            {

            }
        }
    }
}
