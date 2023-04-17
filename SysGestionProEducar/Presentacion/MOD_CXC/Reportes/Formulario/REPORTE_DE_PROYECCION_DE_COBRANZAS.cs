using System;
using Presentacion.HELPERS;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using Entidades;

namespace Presentacion.MOD_CXC.Reportes.Formulario
{
    public partial class REPORTE_DE_PROYECCION_DE_COBRANZAS : Form
    {
        string AÑO; string MES;
        private readonly cambioTipoPllaHistoricoBLL ctpBLL = new cambioTipoPllaHistoricoBLL();
        private readonly cambioTipoPllaHistoricoTo ctpTo = new cambioTipoPllaHistoricoTo();
        string siPD = "Sí : Incluye Contratos Suspendidos (No Suma Importes) / Sin Convenio / Sin Autorización de Descuento";
        string noPD = "No : Incluye Contratos Suspendidos (No Suma Importes) / Sin Convenio / Sin Autorización de Descuento";
        string siOtro = "Sí : Incluye Contratos Suspendidos / Sin Convenio / Sin Autorización de Descuento";
        string noOtro = "No : Incluye Contratos Suspendidos / Sin Convenio / Sin Autorización de Descuento";
        public REPORTE_DE_PROYECCION_DE_COBRANZAS(string AÑO, string MES)
        {
            InitializeComponent();
            this.AÑO = AÑO;
            this.MES = MES;
        }

        private void REPORTE_DE_PROYECCION_DE_COBRANZAS_Load(object sender, EventArgs e)
        {
            CARGAR_PROGRAMAS();
            MOSTRAR_PERIODO();
            dtpFecAprobDesde.Value = Convert.ToDateTime("01/01/2019");
            CARGAR_UBICACION();
            CARGAR_GRUPO_UBICACION();
            CARGAR_GESTOR(null);
            CargarPuntoCobranza();
            fechaReporte();
            siDirecta();    
        }
        private void fechaReporte()
        {
            //DateTime inicio = new DateTime(Convert.ToInt32(cboPeriodoHasta.SelectedValue.ToString().Substring(3, 4)), Convert.ToInt32(cboPeriodoHasta.SelectedValue.ToString().Substring(0, 2)), 1);
            //dtpFecReporte.Value = inicio.AddMonths(1).AddDays(-1);
            DateTime inicio = new DateTime(Convert.ToInt32(cboPeriodoDesde.SelectedValue.ToString().Substring(3, 4)), Convert.ToInt32(cboPeriodoDesde.SelectedValue.ToString().Substring(0, 2)), 1);
            dtpFecReporte.Value = inicio;
        }
        private void CARGAR_PROGRAMAS()
        {
            programaBLL prgBLL = new programaBLL();
            DataTable dt = prgBLL.obtenerProgramaBLL();
            DataRow row = dt.NewRow();
            row["COD_PROGRAMA"] = "0";
            row["DESC_PROGRAMA"] = "Todos";
            dt.Rows.InsertAt(row, 0);
            cboPrograma.ValueMember = "COD_PROGRAMA";
            cboPrograma.DisplayMember = "DESC_PROGRAMA";
            cboPrograma.DataSource = dt;
            cboPrograma.SelectedIndex = 0;
        }
        private void MOSTRAR_PERIODO()
        {
            periodoBLL perBLL = new periodoBLL();
            DataTable dtPeriodoDesde, dtPeriodoHasta;
            dtPeriodoDesde = perBLL.obtenerPeriodoPllasNoTransferidasBLL();
            dtPeriodoHasta = dtPeriodoDesde.Copy();
            if (dtPeriodoDesde.Rows.Count > 0)
            {
                cboPeriodoDesde.ValueMember = "MES_AÑO";
                cboPeriodoDesde.DisplayMember = "PERIO";
                cboPeriodoDesde.DataSource = dtPeriodoDesde;
                cboPeriodoDesde.SelectedValue = MES + "-" + AÑO;

                cboPeriodoHasta.ValueMember = "MES_AÑO";
                cboPeriodoHasta.DisplayMember = "PERIO";
                cboPeriodoHasta.DataSource = dtPeriodoHasta;
                cboPeriodoHasta.SelectedValue = MES + "-" + AÑO;
            }
        }
        private void CARGAR_UBICACION()
        {
            tipoPlanillaCreacionBLL tpcBLL = new tipoPlanillaCreacionBLL();
            DataTable dt = tpcBLL.obtenerTipoPlanillaUbicacionBLL();
            if (dt.Rows.Count > 0)
            {
                DataRow rw = dt.NewRow();
                rw["COD_TIPO_PLLA"] = "00";
                rw["UBICACION"] = "Todos";
                dt.Rows.InsertAt(rw, 0);

                cboUbicacion.ValueMember = "COD_TIPO_PLLA";
                cboUbicacion.DisplayMember = "UBICACION";
                cboUbicacion.DataSource = dt;
                cboUbicacion.SelectedValue = "PD";
                cboGrupoUbicacion.Enabled = cboUbicacion.SelectedValue.ToString() == "PD";
                cboSubUbicacion.Enabled = cboUbicacion.SelectedValue.ToString() == "PD";
            }
        }
        private void CargarPuntoCobranza()
        {
            puntoCobranzaBLL BLPuntoCobranza = new puntoCobranzaBLL();
            DataTable dt = BLPuntoCobranza.obtenerTodosPuntosCobranzaBLL();
            DataView dv = dt.DefaultView;
            dv.Sort = "DESC_PTO_COB ASC";
            DataTable dtSort = dv.ToTable();
            DataRow row = dtSort.NewRow();
            row["COD_PTO_COB"] = "0";
            row["DESC_PTO_COB"] = "Todos";
            dtSort.Rows.InsertAt(row, 0);
            cboPuntoCobranza.DataSource = dtSort;
            cboPuntoCobranza.ValueMember = "COD_PTO_COB";
            cboPuntoCobranza.DisplayMember = "DESC_PTO_COB";

        }
        private void cboUbicacion_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CARGAR_GRUPO_UBICACION();
            CARGAR_GESTOR(null);
            cboGrupoUbicacion.Enabled = cboUbicacion.SelectedValue.ToString() == "PD";
            cboSubUbicacion.Enabled = cboUbicacion.SelectedValue.ToString() == "PD";

            if (Convert.ToString(cboUbicacion.SelectedValue) != "PD")
                noDirecta();
            else
                siDirecta();
        }
        private void noDirecta()
        {
            rdbSi.Text = siOtro;
            rdbNo.Text = noOtro;
            rdbSi.Checked = false;
            rdbNo.Checked = true;
            rdbSi.Visible = true;
            rdbNo.Visible = true;
            //rdbSi.Enabled = true;
            //rdbNo.Enabled = true;
            //rdbSi.Font = new System.Drawing.Font(rdbSi.Font, FontStyle.Regular);
            //rdbNo.Font = new System.Drawing.Font(rdbNo.Font, FontStyle.Regular);
        }
        private void siDirecta()
        {
            rdbSi.Text = siPD;
            rdbNo.Text = noPD;
            rdbSi.Checked = true;
            rdbNo.Checked = false;
            rdbSi.Visible = true;
            rdbNo.Visible = false;
            //rdbSi.Enabled = false;
            //rdbNo.Enabled = false;
            //rdbSi.Font = new System.Drawing.Font(rdbSi.Font, FontStyle.Bold);
            //rdbNo.Font = new System.Drawing.Font(rdbNo.Font, FontStyle.Bold);
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
                    || row["CODIGO"].ToString() == "GDI4" || row["CODIGO"].ToString() == "GDI5")
                {
                    DataRow r = dt1.NewRow();
                    r["CODIGO"] = row["CODIGO"];
                    r["DESCRIPCION"] = row["DESCRIPCION"];
                    dt1.Rows.Add(r);
                }
                else if (Convert.ToString(row["CODIGO"]) == "GPD1" || Convert.ToString(row["CODIGO"]) == "GDP2")
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
                    rw["DESCRIPCION"] = "No existe";
                    dt2.Rows.InsertAt(rw, 0);
                    cboGrupoUbicacion.DataSource = dt2;
                    cboGrupoUbicacion.ValueMember = "CODIGO";
                    cboGrupoUbicacion.DisplayMember = "DESCRIPCION";
                }
            }
            else if (Convert.ToString(cboUbicacion.SelectedValue) == "PV")
            {
                if (dt3.Rows.Count > 0)
                {
                    DataRow rw = dt3.NewRow();
                    rw["CODIGO"] = "0";
                    rw["DESCRIPCION"] = "No existe";
                    dt3.Rows.InsertAt(rw, 0);
                    cboGrupoUbicacion.DataSource = dt3;
                    cboGrupoUbicacion.ValueMember = "CODIGO";
                    cboGrupoUbicacion.DisplayMember = "DESCRIPCION";
                }
            }
            else
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
                rw["DESC_PER"] = cboUbicacion.SelectedValue.ToString() == "PD" || cboUbicacion.SelectedValue.ToString() == "00" ? "Todos" : "No existe";
                dt.Rows.InsertAt(rw, 0);
                cboSubUbicacion.DataSource = dt;
                cboSubUbicacion.ValueMember = "COD_PER";
                cboSubUbicacion.DisplayMember = "DESC_PER";
                //cboGestor.SelectedIndex = -1;
            }
        }

        private void cboGrupoUbicacion_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (Convert.ToString(cboGrupoUbicacion.SelectedValue) != "0")
            {
                CARGAR_GESTOR(Convert.ToString(cboGrupoUbicacion.SelectedValue));
                cboSubUbicacion.SelectedIndex = 0;
                cboSubUbicacion.Enabled = true;
            }
            else
            {
                cboSubUbicacion.SelectedIndex = 0;
                cboSubUbicacion.Enabled = false;
            }
        }
        private bool validaImprimir()
        {
            bool result = true;
            DateTime start = new DateTime(Convert.ToInt32(cboPeriodoDesde.SelectedValue.ToString().Substring(3, 4)), Convert.ToInt32(cboPeriodoDesde.SelectedValue.ToString().Substring(0, 2)), 1);
            //DateTime end = start.AddMonths(1);
            DateTime end = new DateTime(Convert.ToInt32(cboPeriodoHasta.SelectedValue.ToString().Substring(3, 4)), Convert.ToInt32(cboPeriodoHasta.SelectedValue.ToString().Substring(0, 2)), 1);
            end = end.AddMonths(1).AddDays(-1);
            if (!(dtpFecReporte.Value >= start && dtpFecReporte.Value.Date <= end))
            {
                MessageBox.Show("La Fecha de Reporte debe estar dentro del Periodo de Proyeccion !!!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtpFecReporte.Focus();
                return false;
            }
            return result;
        }
        private void btn_pantalla_Click(object sender, EventArgs e)
        {
            if (!validaImprimir())
                return;


            string title = "";
            string programa = cboPrograma.Text;
            string parDateApprobation = dtpFecAprobDesde.Value.ToString("dd/MM/yyyy") + " - " + dtpFecAprobHasta.Value.ToString("dd/MM/yyyy");
            string parPeriodoCobranza = cboPeriodoDesde.Text + " - " + cboPeriodoHasta.Text;
            string Ubicacion = Convert.ToString(cboUbicacion.Text);
            string GrupoUbicacion = Convert.ToString(cboGrupoUbicacion.Text);
            string SubUbicacion = Convert.ToString(cboSubUbicacion.Text);
            string FechaCadena = "01/" + Convert.ToString(cboPeriodoDesde.SelectedValue).Substring(0, 2) + "/" + Convert.ToString(cboPeriodoDesde.SelectedValue).Substring(3, 4);
            DateTime fecha_ini = Convert.ToDateTime("01/" + Convert.ToString(cboPeriodoDesde.SelectedValue).Substring(0, 2) + "/" + Convert.ToString(cboPeriodoDesde.SelectedValue).Substring(3, 4));
            DateTime fecha_fin = Convert.ToDateTime("01/" + Convert.ToString(cboPeriodoHasta.SelectedValue).Substring(0, 2) + "/" + Convert.ToString(cboPeriodoHasta.SelectedValue).Substring(3, 4));
            string PuntoCobranza = Convert.ToString(cboPuntoCobranza.Text);

            DateTime start = new DateTime(fecha_ini.Year, fecha_ini.Month, fecha_ini.Day);
            DateTime end = new DateTime(fecha_fin.Year, fecha_fin.Month, fecha_fin.Day);
            int compMonth = (end.Month + end.Year * 12) - (start.Month + start.Year * 12);
            double daysInEndMonth = (end - end.AddMonths(1)).Days;
            double months = compMonth + (start.Day - end.Day) / daysInEndMonth;
            string Meses = (Convert.ToInt32(months) + 1).ToString();
            string reporte="";
            string fechaReporte = dtpFecReporte.Value.ToShortDateString();
            string OpSuspendido;
            if(Convert.ToString(cboUbicacion.SelectedValue) != "PD")
                OpSuspendido = rdbSi.Checked ? siOtro : noOtro;
            else
                OpSuspendido = rdbSi.Checked ? siPD : noPD;

            //string dataSetName = "DataSet1";
            ctpTo.COD_PROGRAMA = Convert.ToString(cboPrograma.SelectedValue) != "0" ? Convert.ToString(cboPrograma.SelectedValue) : null;
            ctpTo.FECHA_APROB_DESDE = dtpFecAprobDesde.Value.Date;
            ctpTo.FECHA_APROB_HASTA = dtpFecAprobHasta.Value.Date;
            ctpTo.PERIODO_DESDE = Convert.ToString(cboPeriodoDesde.SelectedValue);
            ctpTo.PERIODO_HASTA = Convert.ToString(cboPeriodoHasta.SelectedValue);
            ctpTo.COD_UBICACION = Convert.ToString(cboUbicacion.SelectedValue) != "00" ? Convert.ToString(cboUbicacion.SelectedValue) : null;
            ctpTo.COD_GRUPO_UBICACION = Convert.ToString(cboGrupoUbicacion.SelectedValue) != "0" ? Convert.ToString(cboGrupoUbicacion.SelectedValue) : null;
            ctpTo.COD_SUB_UBICACION = Convert.ToString(cboSubUbicacion.SelectedValue) != "0" ? Convert.ToString(cboSubUbicacion.SelectedValue) : null;
            //ctpTo.COD_PTO_COB = null;
            ctpTo.COD_PTO_COB = Convert.ToString(cboPuntoCobranza.SelectedValue) != "0" ? Convert.ToString(cboPuntoCobranza.SelectedValue) : null; ;
            ctpTo.FECHA_ORIGEN = dtpFecReporte.Value;
            ctpTo.OP1 = rdbSi.Checked;
            //DataTable dt = ctpBLL.MOSTRAR_REPORTE_PROYECCION_COBRANZA_BLL(ctpTo);
            DataTable dt1 = null; //DataTable dt2 = null; DataTable dt3 = null; DataTable dt4 = null;
            string dataSetName1 = "DataSet1"; //string dataSetName2 = "";
            Form frm = null;
            object[] reportParam = null;
            if (rdbDetalladoXCont.Checked && tabControl1.SelectedIndex == 0)
            {
                title = "PROYECCION DE COBRANZAS - MES VENCIDO x Ubicación - Detallado x Contrato";
                reporte = GenericUtil.ObtenerRutaReporteTareaje_MOD_CXC("REP_PROYECCION_COBRANZAS_DETALLADO_X_CONTRATO");
                dt1 = ctpBLL.MOSTRAR_REPORTE_PROYECCION_COBRANZA_BLL(ctpTo);
                reportParam = new object[] { title, programa, parDateApprobation, parPeriodoCobranza, Ubicacion, GrupoUbicacion, SubUbicacion, FechaCadena, Meses, fechaReporte, OpSuspendido };
            }
            else if (rdbDetalladoXCont.Checked && tabControl1.SelectedIndex == 1)
            {
                title = "PROYECCION DE COBRANZAS - MES VENCIDO x Punto de Cobranza - Detalle";
                reporte = GenericUtil.ObtenerRutaReporteTareaje_MOD_CXC("REP_PROYECCION_COBRANZAS_DETALLADO_X_PUNTO_COBRANZA");
                dt1 = ctpBLL.MOSTRAR_REPORTE_PROYECCION_COBRANZA_RESUMEN_PUNTO_CONBRANZA_BLL(ctpTo);
                reportParam = new object[] { title, programa, parDateApprobation, parPeriodoCobranza, PuntoCobranza, FechaCadena, Meses, fechaReporte };
            }
            else if (rdbResumen.Checked && tabControl1.SelectedIndex == 0)
            {
                title = "PROYECCION DE COBRANZAS - MES VENCIDO x Ubicación - Resumen";
                reporte = GenericUtil.ObtenerRutaReporteTareaje_MOD_CXC("REP_PROYECCION_COBRANZAS_RESUMEN");
                dt1 = ctpBLL.MOSTRAR_REPORTE_PROYECCION_COBRANZA_RESUMEN_BLL(ctpTo);
                reportParam = new object[] { title, programa, parDateApprobation, parPeriodoCobranza, Ubicacion, GrupoUbicacion, SubUbicacion, FechaCadena, Meses, fechaReporte, OpSuspendido };
            }
            else if (rdbResumen.Checked && tabControl1.SelectedIndex == 1)
            {
                title = "PROYECCION DE COBRANZAS - MES VENCIDO x Punto de Cobranza - Resumen";
                reporte = GenericUtil.ObtenerRutaReporteTareaje_MOD_CXC("REP_PROYECCION_COBRANZAS_RESUMEN_PUNTO_COBRANZA");
                dt1 = ctpBLL.MOSTRAR_REPORTE_PROYECCION_COBRANZA_RESUMEN_PUNTO_CONBRANZA_BLL(ctpTo);
                reportParam = new object[] { title, programa, parDateApprobation, parPeriodoCobranza, PuntoCobranza, FechaCadena, Meses, fechaReporte };
            }
            //object[] reportParam = new object[] { title, programa, parDateApprobation, parPeriodoCobranza, Ubicacion, GrupoUbicacion, SubUbicacion, FechaCadena, Meses };
            frm = GenericUtil.CreateReportForm(reporte, dataSetName1, dt1, reportParam);
            frm.Show();

        }

        private void cboPeriodoDesde_SelectionChangeCommitted(object sender, EventArgs e)
        {
            fechaReporte();
        }
    }
}
