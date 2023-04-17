using BLL;
using Entidades;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static Presentacion.HELPERS.GenericUtil;

namespace Presentacion.MOD_CXC.Reportes.Formulario
{
    public partial class REPORTE_DE_CTAS_X_COBRAR : Form
    {
        private readonly cambioTipoPllaHistoricoBLL cphBLL = new cambioTipoPllaHistoricoBLL();
        private readonly cambioTipoPllaHistoricoTo cphTo = new cambioTipoPllaHistoricoTo();
        private readonly canjeICtasxCobrarBLL BLCtasCobrar = new canjeICtasxCobrarBLL();
        private readonly personaMaestroBLL BLMaestroPersona = new personaMaestroBLL();

        public REPORTE_DE_CTAS_X_COBRAR()
        {
            InitializeComponent();
        }

        private void REPORTE_DE_COBRANZA_X_UBICACION_Load(object sender, EventArgs e)
        {
            CARGAR_PROGRAMAS();
            CARGAR_UBICACION();
            CARGAR_GRUPO_UBICACION();
            CARGAR_GESTOR(null);
            CargarPuntoCobranza();
            CargarCategoriaPer();
            CargarInistitucion();
            CargarSubNivelInstitucion();
            CargarDetpartamento();
            CargarPuntoCobranzaXInstitucion();
            CargarInistitucion2();
            CargarSubNivelInstitucion2();
            dtFechaVenIni.Value = new DateTime(2019, 1, 1);
            dtpFecAprobDesde.Value = new DateTime(2019, 1, 1);
            dtFechaVentaIni.Value = new DateTime(2019, 1, 1);
            rdbDetalle.Checked = true;
            rdbS1.Checked = true;
            rdbS1.Visible = false;
            rdbS2.Visible = false;
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

        private void CargarPuntoCobranza()
        {
            puntoCobranzaBLL BLPuntoCobranza = new puntoCobranzaBLL();
            DataTable dt = BLPuntoCobranza.obtenerTodosPuntosCobranzaBLL();
            DataView dv = dt.DefaultView;
            dv.Sort = "DESC_PTO_COB ASC";
            DataTable dtSort = dv.ToTable();
            DataRow row = dtSort.NewRow();
            row["COD_PTO_COB"] = "000";
            row["DESC_PTO_COB"] = "Todos";
            dtSort.Rows.InsertAt(row, 0);
            cboPuntoCobranza.DataSource = dtSort;
            cboPuntoCobranza.ValueMember = "COD_PTO_COB";
            cboPuntoCobranza.DisplayMember = "DESC_PTO_COB";

            cboPCobranza2.DataSource = dtSort;
            cboPCobranza2.ValueMember = "COD_PTO_COB";
            cboPCobranza2.DisplayMember = "DESC_PTO_COB";

            cboPCobranza3.DataSource = dtSort;
            cboPCobranza3.ValueMember = "COD_PTO_COB";
            cboPCobranza3.DisplayMember = "DESC_PTO_COB";
        }

        private void CargarCategoriaPer()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("COD_CATEGORIA", typeof(string));
            dt.Columns.Add("DESC_CATEGORIA", typeof(string));

            DataRow row = dt.NewRow();
            row["COD_CATEGORIA"] = "01";
            row["DESC_CATEGORIA"] = "Director General";

            DataRow row2 = dt.NewRow();
            row2["COD_CATEGORIA"] = "02";
            row2["DESC_CATEGORIA"] = "Director Ventas";

            DataRow row3 = dt.NewRow();
            row3["COD_CATEGORIA"] = "03";
            row3["DESC_CATEGORIA"] = "Supervisor";

            DataRow row4 = dt.NewRow();
            row4["COD_CATEGORIA"] = "04";
            row4["DESC_CATEGORIA"] = "Vendedor";

            dt.Rows.Add(row);
            dt.Rows.Add(row2);
            dt.Rows.Add(row3);
            dt.Rows.Add(row4);

            cboCategoria.ValueMember = "COD_CATEGORIA";
            cboCategoria.DisplayMember = "DESC_CATEGORIA";
            cboCategoria.DataSource = dt;
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

                cboUbicacion3.DataSource = dt;
                cboUbicacion3.ValueMember = "COD_TIPO_PLLA";
                cboUbicacion3.DisplayMember = "UBICACION";

                cboGrupoUbicacion.Enabled = cboUbicacion.SelectedValue.ToString() == "PD";
                cboSubUbicacion.Enabled = cboUbicacion.SelectedValue.ToString() == "PD";
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

        private void CargarDetpartamento()
        {
            DepartamentoBLL BLDepartamento = new DepartamentoBLL();
            DataTable dt = BLDepartamento.ListarDepartamento(EmpresaSistema.CodPais);
            if (dt.Rows.Count > 0)
            {
                DataRow rw = dt.NewRow();
                rw["COD_DEP"] = "0";
                rw["DESC_DEP"] = "Todos";
                dt.Rows.InsertAt(rw, 0);
                cboDepartamento.ValueMember = "COD_DEP";
                cboDepartamento.DisplayMember = "DESC_DEP";
                cboDepartamento.DataSource = dt;

                cboDepartamento2.ValueMember = "COD_DEP";
                cboDepartamento2.DisplayMember = "DESC_DEP";
                cboDepartamento2.DataSource = dt;

                cboDepartamento3.ValueMember = "COD_DEP";
                cboDepartamento3.DisplayMember = "DESC_DEP";
                cboDepartamento3.DataSource = dt;
            }
        }

        private void CargarInistitucion()
        {
            institucionesBLL BLInititucion = new institucionesBLL();
            DataTable dt = BLInititucion.obtenerInstitucionesBLL();
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.NewRow();
                row["COD_INST"] = "00";
                row["DESC_INST"] = "Todos";

                dt.Rows.InsertAt(row, 0);
                cboInstitucion.DataSource = dt;
                cboInstitucion.ValueMember = "COD_INST";
                cboInstitucion.DisplayMember = "DESC_INST";
            }
        }

        private void CargarPuntoCobranzaXInstitucion()
        {
            puntoCobranzaBLL BLLPuntoCobranza = new puntoCobranzaBLL();
            DataTable dt = BLLPuntoCobranza.obtenerPuntosCobranza_x_Inst_BLL(new puntoCobranzaTo { COD_INSTITUCION = cboInstitucion.SelectedValue.ToString(), STATUS_CONSOLIDADO = null });
            DataRow row = dt.NewRow();
            row["COD_PTO_COB"] = "000";
            row["DESC_PTO_COB"] = "Todos";
            dt.Rows.InsertAt(row, 0);

            cboPuntoCobranzaInst.DataSource = dt;
            cboPuntoCobranzaInst.ValueMember = "COD_PTO_COB";
            cboPuntoCobranzaInst.DisplayMember = "DESC_PTO_COB";
        }

        private void CargarSubNivelInstitucion()
        {
            try
            {
                institucionesBLL BLInititucion = new institucionesBLL();
                DataTable dt = BLInititucion.ObtenerSubNivelInstituciones(cboInstitucion.SelectedValue.ToString());

                DataRow row = dt.NewRow();
                row["CODIGO"] = "0";
                row["COD_INSTITUCION"] = "00";
                row["DESCRIPCION"] = "Todos";

                dt.Rows.InsertAt(row, 0);
                cboNivelInst.DataSource = dt;
                cboNivelInst.ValueMember = "CODIGO";
                cboNivelInst.DisplayMember = "DESCRIPCION";

                cboNivelInst.Enabled = cboInstitucion.SelectedValue.ToString() != "00";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CargarInistitucion2()
        {
            institucionesBLL BLInititucion = new institucionesBLL();
            DataTable dt = BLInititucion.obtenerInstitucionesBLL();
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.NewRow();
                row["COD_INST"] = "00";
                row["DESC_INST"] = "Todos";

                dt.Rows.InsertAt(row, 0);
                cboInstitucion2.DataSource = dt;
                cboInstitucion2.ValueMember = "COD_INST";
                cboInstitucion2.DisplayMember = "DESC_INST";
            }
        }

        private void CargarSubNivelInstitucion2()
        {
            try
            {
                institucionesBLL BLInititucion = new institucionesBLL();
                DataTable dt = BLInititucion.ObtenerSubNivelInstituciones(cboInstitucion2.SelectedValue.ToString());

                DataRow row = dt.NewRow();
                row["CODIGO"] = "0";
                row["COD_INSTITUCION"] = "00";
                row["DESCRIPCION"] = "Todos";

                dt.Rows.InsertAt(row, 0);
                cboNivelInst2.DataSource = dt;
                cboNivelInst2.ValueMember = "CODIGO";
                cboNivelInst2.DisplayMember = "DESCRIPCION";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

        private void Btn_pantalla_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarDatos())
                {
                    DataTable dt = null;
                    string localReport = null;
                    string title = null;
                    string programs = cboPrograma.Text;
                    string parDateApprobation = dtpFecAprobDesde.Value.ToString("dd/MM/yyyy") + " - " + dtpFecAprobHasta.Value.ToString("dd/MM/yyyy");
                    string parDateExpiration = dtFechaVenIni.Value.ToString("dd/MM/yyyy") + " - " + dtFechaVenFin.Value.ToString("dd/MM/yyyy");
                    string[] parameter = new string[] { };
                    if (tabControl1.SelectedTab == tabPage1)
                    {
                        int act = -1;
                        if (rdbDetalle.Checked)
                        {
                            act = 0;
                            title = "CUENTAS POR COBRAR X Puntos de Cobranza - " + rdbDetalle.Text;
                            parameter = new string[] { title, programs, parDateApprobation, parDateExpiration, cboPuntoCobranza.Text };
                            localReport = "Presentacion.MOD_CXC.Reportes.ReportViewer.REP_CTAS_X_COBRAR_MES_PCOBRANZA_TODOS.rdlc";
                        }
                        else if (rdbResumen.Checked)
                        {
                            act = 0;
                            title = "CUENTAS POR COBRAR X Puntos de Cobranza - " + rdbResumen.Text;
                            parameter = new string[] { title, programs, parDateApprobation, parDateExpiration, cboPuntoCobranza.Text };
                            localReport = "Presentacion.MOD_CXC.Reportes.ReportViewer.REP_CTAS_X_COBRAR_MES_PCOBRANZA_RESUMEN.rdlc";
                        }
                        else if (rdbDetalladoXCont.Checked)
                        {
                            act = 2;
                            title = "CUENTAS POR COBRAR X Puntos de Cobranza - " + rdbDetalladoXCont.Text;
                            parameter = new string[] { title, programs, parDateApprobation, parDateExpiration, cboPuntoCobranza.Text };
                            if (rdbS1.Checked)
                                localReport = "Presentacion.MOD_CXC.Reportes.ReportViewer.REP_CTAS_X_COBRAR_MES_PCOBRANZA_DETALLE.rdlc";
                            else
                                localReport = "Presentacion.MOD_CXC.Reportes.ReportViewer.REP_CTAS_X_COBRAR_MES_PCOBRANZA_DETALLE2.rdlc";
                        }
                        else
                            return;
                        string puntoCobranza = cboPuntoCobranza.SelectedValue.ToString();
                        dt = BLCtasCobrar.RptCuentasXCobrarMesXPuntoCobranza(cboPrograma.SelectedValue.ToString(), dtFechaVentaIni.Value, dtFechaVentaFin.Value,
                                dtpFecAprobDesde.Value, dtpFecAprobHasta.Value, dtFechaVenIni.Value, dtFechaVenFin.Value, puntoCobranza, act);
                    }
                    else if (tabControl1.SelectedTab == tabPage2)
                    {
                        int act = -1;
                        if (rdbDetalle.Checked)
                        {
                            act = 0;
                            title = "CUENTAS POR COBRAR X Nivel de Venta - " + rdbDetalle.Text;
                            localReport = "Presentacion.MOD_CXC.Reportes.ReportViewer.REP_CTAS_X_COBRAR_MES_TODOS_C4.rdlc";
                        }
                        else if (rdbResumen.Checked)
                        {
                            act = 1;
                            title = "CUENTAS POR COBRAR X Nivel de Venta - " + rdbResumen.Text;
                            localReport = "Presentacion.MOD_CXC.Reportes.ReportViewer.REP_CTAS_X_COBRAR_MES_C4_RESUMEN.rdlc";
                        }
                        else if (rdbDetalladoXCont.Checked)
                        {
                            act = 2;
                            title = "CUENTAS POR COBRAR X Nivel de Venta - " + rdbDetalladoXCont.Text;
                            if (rdbS1.Checked)
                                localReport = "Presentacion.MOD_CXC.Reportes.ReportViewer.REP_CTAS_X_COBRAR_MES_TODOS_C4_DETALLE2.rdlc";
                            else
                                localReport = "Presentacion.MOD_CXC.Reportes.ReportViewer.REP_CTAS_X_COBRAR_MES_TODOS_C4_DETALLE3.rdlc";
                        }
                        else
                            return;
                        parameter = new string[] { title, programs, parDateApprobation, parDateExpiration, cboSubCategoria.Text, cboCategoria.Text };
                        string nivelVenta = cboSubCategoria.SelectedValue.ToString();
                        dt = BLCtasCobrar.RptCuentasXCobrarC4(dtFechaVentaIni.Value, dtFechaVentaFin.Value, dtpFecAprobDesde.Value, dtpFecAprobHasta.Value, dtFechaVenIni.Value, dtFechaVenFin.Value,
                                cboPrograma.SelectedValue.ToString(), cboCategoria.SelectedValue.ToString(), nivelVenta, act);
                    }
                    else if (tabControl1.SelectedTab == tabPage3)
                    {
                        int act = -1;
                        if (rdbDetalle.Checked)
                        {
                            act = 0;
                            title = "CUENTAS POR COBRAR - X Ubicación - " + rdbDetalle.Text;
                            localReport = "Presentacion.MOD_CXC.Reportes.ReportViewer.REP_CTAS_X_COBRAR_MES_UBICACION_TODOS.rdlc";
                        }
                        else if (rdbResumen.Checked)
                        {
                            act = 1;
                            title = "UENTAS POR COBRAR - X Ubicación - " + rdbResumen.Text;
                            //> localReport = "Presentacion.MOD_CXC.Reportes.ReportViewer.REP_CTAS_X_COBRAR_MES_UBICACION.rdlc";
                            localReport = "Presentacion.MOD_CXC.Reportes.ReportViewer.REP_CTAS_X_COBRAR_MES_UBICACION_RESUMEN.rdlc";
                        }
                        else if (rdbDetalladoXCont.Checked)
                        {
                            act = 2;
                            title = "UENTAS POR COBRAR - X Ubicación - " + rdbDetalladoXCont.Text;
                            if (rdbS1.Checked)
                                localReport = "Presentacion.MOD_CXC.Reportes.ReportViewer.REP_CTAS_X_COBRAR_MES_UBICACION_DETALLE.rdlc";
                            else
                                localReport = "Presentacion.MOD_CXC.Reportes.ReportViewer.REP_CTAS_X_COBRAR_MES_UBICACION_DETALLE2.rdlc";
                        }
                        else if (rdbSoloResumen.Checked)
                        {
                            act = 0;
                            title = "CUENTAS POR COBRAR - X Ubicación - " + rdbSoloResumen.Text;
                            localReport = "Presentacion.MOD_CXC.Reportes.ReportViewer.REP_CTAS_X_COBRAR_MES_UBICACION_TODOS_RESUMEN.rdlc";
                        }
                        parameter = new string[] { title, programs, parDateApprobation, parDateExpiration, cboUbicacion.Text, cboGrupoUbicacion.Text, cboSubUbicacion.Text };
                        string codSubUbicacion = cboSubUbicacion.SelectedValue.ToString();
                        dt = BLCtasCobrar.RptCuentasXCobrarC5(dtFechaVentaIni.Value, dtFechaVentaFin.Value, dtpFecAprobDesde.Value, dtpFecAprobHasta.Value, dtFechaVenIni.Value, dtFechaVenFin.Value,
                                cboPrograma.SelectedValue.ToString(), cboUbicacion.SelectedValue.ToString(), cboGrupoUbicacion.SelectedValue.ToString(), codSubUbicacion, act);
                    }
                    else if (tabControl1.SelectedTab == tabPage4)
                    {
                        int act = -1;
                        if (rdbDetalle.Checked)
                        {
                            act = 0;
                            title = "CUENTAS POR COBRAR X Institución - " + rdbDetalle.Text;
                            localReport = "Presentacion.MOD_CXC.Reportes.ReportViewer.REP_CTAS_X_COBRAR_MES_INSTITUCION_TODOS.rdlc";
                            //> localReport = "Presentacion.MOD_CXC.Reportes.ReportViewer.REP_CTAS_X_COBRAR_MES_INSTITUCION_TODOS_1.rdlc";
                        }
                        else if (rdbResumen.Checked)
                        {
                            act = 2;
                            title = "CUENTAS POR COBRAR X Institución - " + rdbResumen.Text;
                            localReport = "Presentacion.MOD_CXC.Reportes.ReportViewer.REP_CTAS_X_COBRAR_MES_INSTITUCION_RESUMEN.rdlc";
                        }
                        else if (rdbDetalladoXCont.Checked)
                        {
                            act = 3;
                            title = "CUENTAS POR COBRAR X Institución - " + rdbDetalladoXCont.Text;
                            if (rdbS1.Checked)
                                localReport = "Presentacion.MOD_CXC.Reportes.ReportViewer.REP_CTAS_X_COBRAR_MES_INSTITUCION_DETALLE.rdlc";
                            else
                                localReport = "Presentacion.MOD_CXC.Reportes.ReportViewer.REP_CTAS_X_COBRAR_MES_INSTITUCION_DETALLE2.rdlc";
                        }
                        else
                            return;
                        parameter = new string[] { title, programs, parDateApprobation, parDateExpiration, cboInstitucion.Text, cboNivelInst.Text };
                        string institucion = cboInstitucion.SelectedValue.ToString();
                        string subNivelInstitucion = cboNivelInst.SelectedValue.ToString();
                        dt = BLCtasCobrar.RptCuentasXCobrarC6(dtFechaVentaIni.Value, dtFechaVentaFin.Value, dtpFecAprobDesde.Value, dtpFecAprobHasta.Value, dtFechaVenIni.Value, dtFechaVenFin.Value,
                                cboPrograma.SelectedValue.ToString(), institucion, subNivelInstitucion, act);
                    }
                    else if (tabControl1.SelectedTab == tabPage5)
                    {
                        int act = -1;
                        if (rdbDetalle.Checked)
                        {
                            act = 0;
                            title = "COBRAR X Departamento e Institución - " + rdbDetalle.Text;
                            localReport = "Presentacion.MOD_CXC.Reportes.ReportViewer.REP_CTAS_X_COBRAR_MES_DEPARTAMENTO_TODOS.rdlc";
                        }
                        else if (rdbResumen.Checked)
                        {
                            act = 0;
                            title = "CUENTAS POR COBRAR X Departamento e Insitución - " + rdbResumen.Text;
                            localReport = "Presentacion.MOD_CXC.Reportes.ReportViewer.REP_CTAS_X_COBRAR_MES_DEPARTAMENTO.rdlc";
                        }
                        else
                            return;
                        string departamento = cboDepartamento.Text;
                        parameter = new string[] { title, programs, parDateApprobation, parDateExpiration, departamento, cboInstitucion2.Text, cboNivelInst2.Text };
                        string codDepartamento = cboDepartamento.SelectedValue.ToString();
                        dt = BLCtasCobrar.RptCuentasXCobrarC7(dtFechaVentaIni.Value, dtFechaVentaFin.Value, dtpFecAprobDesde.Value, dtpFecAprobHasta.Value, dtFechaVenIni.Value, dtFechaVenFin.Value,
                                cboPrograma.SelectedValue.ToString(), codDepartamento, cboInstitucion2.SelectedValue.ToString(), cboNivelInst2.SelectedValue.ToString(), act);
                    }
                    else if (tabControl1.SelectedTab == tabPage6)
                    {
                        int act = -1;
                        if (rdbDetalle.Checked)
                        {
                            act = 0;
                            title = "CUENTAS POR COBRAR X Departamento y P.Cobranza - " + rdbDetalle.Text;
                            localReport = "Presentacion.MOD_CXC.Reportes.ReportViewer.REP_CTAS_X_COBRAR_MES_DEPARTAMENTO_3.rdlc";
                        }
                        else if (rdbResumen.Checked)
                        {
                            act = 0;
                            title = "CUENTAS POR COBRAR X Departamento y P.Cobranza - " + rdbResumen.Text;
                            localReport = "Presentacion.MOD_CXC.Reportes.ReportViewer.REP_CTAS_X_COBRAR_MES_DEPARTAMENTO_2.rdlc";
                        }
                        else
                            return;
                        string departamento = cboDepartamento2.Text;
                        parameter = new string[] { title, programs, parDateApprobation, parDateExpiration, departamento, cboPCobranza2.Text };
                        dt = BLCtasCobrar.RptCuentasXCobrarC7_1(dtFechaVentaIni.Value, dtFechaVentaFin.Value, dtpFecAprobDesde.Value, dtpFecAprobHasta.Value, dtFechaVenIni.Value, dtFechaVenFin.Value,
                                cboPrograma.SelectedValue.ToString(), cboDepartamento2.SelectedValue.ToString(), cboPCobranza2.SelectedValue.ToString(), act);
                    }
                    else if (tabControl1.SelectedTab == tabPage7)
                    {
                        int act = -1;
                        if (rdbDetalle.Checked)
                        {
                            act = 0;
                            title = "CUENTAS POR COBRAR X Departamento y P.Cobranza - " + rdbDetalle.Text;
                            localReport = "Presentacion.MOD_CXC.Reportes.ReportViewer.REP_CTAS_X_COBRAR_MES_DEPARTAMENTO_4.rdlc";
                        }
                        else if (rdbResumen.Checked)
                        {
                            act = 0;
                            title = "CUENTAS POR COBRAR X Departamento y P.Cobranza - " + rdbResumen.Text;
                            localReport = "Presentacion.MOD_CXC.Reportes.ReportViewer.REP_CTAS_X_COBRAR_MES_DEPARTAMENTO_5.rdlc";
                        }
                        else if (rdbDetalladoXCont.Checked)
                        {
                            act = 1;
                            title = "CUENTAS POR COBRAR X Departamento y P.Cobranza - " + rdbDetalladoXCont.Text;
                            if (rdbS1.Checked)
                                localReport = "Presentacion.MOD_CXC.Reportes.ReportViewer.REP_CTAS_X_COBRAR_MES_DEPARTAMENTO_DETALLE.rdlc";
                            else
                                localReport = "Presentacion.MOD_CXC.Reportes.ReportViewer.REP_CTAS_X_COBRAR_MES_DEPARTAMENTO_DETALLE2.rdlc";
                        }
                        else
                            return;
                        parameter = new string[] { title, programs, parDateApprobation, parDateExpiration, cboDepartamento3.Text };
                        dt = BLCtasCobrar.RptCuentasXCobrarC7_1(dtFechaVentaIni.Value, dtFechaVentaFin.Value, dtpFecAprobDesde.Value, dtpFecAprobHasta.Value, dtFechaVenIni.Value, dtFechaVenFin.Value,
                                cboPrograma.SelectedValue.ToString(), cboDepartamento3.SelectedValue.ToString(), "000", act);
                    }
                    else if (tabControl1.SelectedTab == tabPage8)
                    {
                        int act = -1;
                        if (rdbResumen.Checked)
                        {
                            act = 1;
                            title = "CUENTAS POR COBRAR X P.Cobranza y Ubicación - " + rdbResumen.Text;
                            localReport = "Presentacion.MOD_CXC.Reportes.ReportViewer.REP_CTAS_X_COBRAR_MES_PCOBRANZAUBICACION.rdlc";
                        }
                        else if (rdbDetalladoXCont.Checked)
                        {
                            act = 2;
                            title = "CUENTAS POR COBRAR X P.Cobranza y Ubicación - " + rdbDetalladoXCont.Text;
                            if (rdbS1.Checked)
                                localReport = "Presentacion.MOD_CXC.Reportes.ReportViewer.REP_CTAS_X_COBRAR_MES_PCOBRANZAUBICACION2.rdlc";
                            else
                                localReport = "Presentacion.MOD_CXC.Reportes.ReportViewer.REP_CTAS_X_COBRAR_MES_PCOBRANZAUBICACION3.rdlc";
                        }
                        else
                            return;
                        parameter = new string[] { title, programs, parDateApprobation, parDateExpiration, cboUbicacion3.Text, cboPCobranza3.Text };
                        dt = BLCtasCobrar.RptCuentasXCobrarC8(dtFechaVentaIni.Value, dtFechaVentaFin.Value, dtpFecAprobDesde.Value, dtpFecAprobHasta.Value, dtFechaVenIni.Value, dtFechaVenFin.Value,
                                cboPrograma.SelectedValue.ToString(), cboPCobranza3.SelectedValue.ToString(), cboUbicacion3.SelectedValue.ToString(), act);
                    }
                    else
                        throw new ArgumentNullException();

                    FormRep.REP_CTAS_X_COBRAR frm = new FormRep.REP_CTAS_X_COBRAR()
                    {
                        LocalReport = localReport,
                        Data = dt,
                        Parameters = parameter,
                        StartPosition = FormStartPosition.CenterScreen
                    };
                    frm.WindowState = FormWindowState.Maximized;
                    frm.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace, "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarDatos()
        {
            bool result = true;

            return result;
        }

        private void CboCategoria_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cboCategoria.SelectedValue?.ToString()))
            {
                DataTable dt = BLMaestroPersona.ListarMaestroPersonaXNivel(cboCategoria.SelectedValue.ToString());
                CargarComboboxSubCategoria(dt);
                lblSubnivel.Text = cboCategoria.Text;
                string categoria = cboCategoria.SelectedValue.ToString();
                switch (categoria)
                {
                    case "01":
                    case "02":
                        lblSubnivel.Location = new Point { X = 32, Y = 57 };
                        break;
                    case "03":
                        lblSubnivel.Location = new Point { X = 59, Y = 57 };
                        break;
                    case "04":
                        lblSubnivel.Location = new Point { X = 63, Y = 57 };
                        break;
                    default:
                        new ArgumentNullException();
                        break;
                }
            }
        }

        private void CargarComboboxSubCategoria(DataTable dt)
        {
            DataRow row = dt.NewRow();
            row["COD_PER"] = "0";
            row["DESC_PER"] = "Todos";
            dt.Rows.InsertAt(row, 0);

            cboSubCategoria.DataSource = dt;
            cboSubCategoria.ValueMember = "COD_PER";
            cboSubCategoria.DisplayMember = "DESC_PER";
        }

        private void ChkPcT_Click(object sender, EventArgs e)
        {
            CheckBox chk = sender as CheckBox;
            TabPage page = tabControl1.SelectedTab;
            if (chk.Checked)
            {
                foreach (CheckBox control in page.Controls.OfType<CheckBox>().ToList())
                {
                    if (control.Name != chk.Name)
                        control.Checked = false;
                }
            }
        }

        private void CboUbicacion_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CARGAR_GRUPO_UBICACION();
            CARGAR_GESTOR(null);
            cboGrupoUbicacion.Enabled = cboUbicacion.SelectedValue.ToString() == "PD";
            cboSubUbicacion.Enabled = cboUbicacion.SelectedValue.ToString() == "PD";
        }

        private void CboGrupoUbicacion_SelectionChangeCommitted(object sender, EventArgs e)
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

        private void CboInstitucion_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CargarSubNivelInstitucion();
            CargarPuntoCobranzaXInstitucion();
        }

        private void CboInstitucion2_SelectedValueChanged(object sender, EventArgs e)
        {
            CargarSubNivelInstitucion2();
        }

        private void RdbDetalladoXCont_CheckedChanged(object sender, EventArgs e)
        {
            cboDepartamento.Enabled = !rdbDetalladoXCont.Checked;
            cboInstitucion2.Enabled = !rdbDetalladoXCont.Checked;
            cboNivelInst2.Enabled = !rdbDetalladoXCont.Checked;
            cboDepartamento2.Enabled = !rdbDetalladoXCont.Checked;
            cboPCobranza2.Enabled = !rdbDetalladoXCont.Checked;
            rdbS1.Visible = rdbDetalladoXCont.Checked;
            rdbS2.Visible = rdbDetalladoXCont.Checked;
            //> rdbS1.Checked = true;
        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //> rdbDetalle.Enabled = tabControl1.SelectedTab != tabPage8;
            //> rdbResumen.Checked = true;
        }
    }
}
