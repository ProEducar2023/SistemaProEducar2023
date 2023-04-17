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
    public partial class REPORTE_CARTERA_TOTAL_PROYECTADA : Form
    {
        string AÑO; string MES;
        private readonly cambioTipoPllaHistoricoBLL ctpBLL = new cambioTipoPllaHistoricoBLL();
        private readonly cambioTipoPllaHistoricoTo ctpTo = new cambioTipoPllaHistoricoTo();
        private const string tabla1 = "GXUBI";
        private const string tipo1 = "D";
        private const string codNivel1 = "01";
        string siPD = "Sí : Incluye Contratos Suspendidos (No Suma Importes) / Sin Convenio / Sin Autorización de Descuento";
        string noPD = "No : Incluye Contratos Suspendidos (No Suma Importes) / Sin Convenio / Sin Autorización de Descuento";
        string siOtro = "Sí : Incluye Contratos Suspendidos / Sin Convenio / Sin Autorización de Descuento";
        string noOtro = "No : Incluye Contratos Suspendidos / Sin Convenio / Sin Autorización de Descuento";
        public REPORTE_CARTERA_TOTAL_PROYECTADA(string AÑO, string MES)
        {
            InitializeComponent();
            this.AÑO = AÑO;
            this.MES = MES;
        }

        private void REPORTE_CARTERA_TOTAL_PROYECTADA_Load(object sender, EventArgs e)
        {
            CARGAR_PROGRAMAS();
            MOSTRAR_PERIODO();
            dtpFecAprobDesde.Value = Convert.ToDateTime("01/01/2019");
            CARGAR_UBICACION("todos");
            CARGAR_GRUPO_UBICACION("todos");
            CARGAR_GESTOR(null, "todos");
            CargarPuntoCobranza();
            rdbDetalladoXCont.Enabled = false;
            rdbResumen.Enabled = true;
            fechaReporte();

            rdbTodos_CheckedChanged(sender, e);
        }
        private void fechaReporte()
        {
            DateTime inicio = new DateTime(Convert.ToInt32(cboPeriodoDesde.SelectedValue.ToString().Substring(3, 4)), Convert.ToInt32(cboPeriodoDesde.SelectedValue.ToString().Substring(0, 2)), 1);
            //dtpFecReporte.Value = inicio.AddMonths(1).AddDays(-1);
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
            }
        }
        private void CARGAR_UBICACION(string op)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("COD_TIPO_PLLA");
            dt.Columns.Add("UBICACION");
            if (op == "todos_todos")
            {
                //DataRow rw = dt.NewRow();
                //rw["COD_TIPO_PLLA"] = "00";
                //rw["UBICACION"] = "Todos";
                //dt.Rows.InsertAt(rw, 0);
                //cboUbicacion.ValueMember = "COD_TIPO_PLLA";
                //cboUbicacion.DisplayMember = "UBICACION";
                //cboUbicacion.DataSource = dt;

                tipoPlanillaCreacionBLL tpcBLL = new tipoPlanillaCreacionBLL();
                dt = tpcBLL.obtenerTipoPlanillaUbicacionBLL();
                if (dt.Rows.Count > 0)
                {
                    DataRow rw = dt.NewRow();
                    rw["COD_TIPO_PLLA"] = "00";
                    rw["UBICACION"] = "Todos";
                    dt.Rows.InsertAt(rw, 0);
                    cboUbicacion.ValueMember = "COD_TIPO_PLLA";
                    cboUbicacion.DisplayMember = "UBICACION";
                    cboUbicacion.DataSource = dt;
                    cboUbicacion.SelectedValue = "00";
                }
            }
            else if (op=="todos")
            {
                DataRow rw = dt.NewRow();
                rw["COD_TIPO_PLLA"] = "00";
                rw["UBICACION"] = "Todos";
                dt.Rows.InsertAt(rw, 0);
                cboUbicacion.ValueMember = "COD_TIPO_PLLA";
                cboUbicacion.DisplayMember = "UBICACION";
                cboUbicacion.DataSource = dt;
            }
            else
            {
                tipoPlanillaCreacionBLL tpcBLL = new tipoPlanillaCreacionBLL();
                dt = tpcBLL.obtenerTipoPlanillaUbicacionBLL();
                if (dt.Rows.Count > 0)
                {
                    cboUbicacion.ValueMember = "COD_TIPO_PLLA";
                    cboUbicacion.DisplayMember = "UBICACION";
                    cboUbicacion.DataSource = dt;
                    cboUbicacion.SelectedValue = "PD";
                    //cboGrupoUbicacion.Enabled = cboUbicacion.SelectedValue.ToString() == "PD";
                    //cboSubUbicacion.Enabled = cboUbicacion.SelectedValue.ToString() == "PD";
                }
            }
            
        }
        private void CARGAR_GRUPO_UBICACION_PD(string op = "")
        {
            directorioBLL dirBLL = new directorioBLL();
            directorioTo dirTo = new directorioTo();
            dirTo.TABLA_COD = "GXUBI";
            dirTo.TIPO = "D";
            DataTable dt0 = dirBLL.obtenerCodigoDescripcionDirectorioDirectaBLL(dirTo);//GrupoUbicacion
            DataRow rw = dt0.NewRow();
            rw["CODIGO"] = "0";
            rw["DESCRIPCION"] = "Todos";
            dt0.Rows.InsertAt(rw, 0);
            cboGrupoUbicacion.ValueMember = "CODIGO";
            cboGrupoUbicacion.DisplayMember = "DESCRIPCION";
            cboGrupoUbicacion.DataSource = dt0;

        }
        private void CARGAR_GRUPO_UBICACION_DIRECTA(string op = "")
        {
            if (op == "todos")
            {
                cboSubUbicacion.DataSource = null;
                DataTable dt0 = new DataTable();
                dt0.Columns.Add("CODIGO");
                dt0.Columns.Add("DESCRIPCION");
                DataRow rw = dt0.NewRow();
                rw["CODIGO"] = "0";
                rw["DESCRIPCION"] = "Todos";
                dt0.Rows.InsertAt(rw, 0);
                cboSubUbicacion.ValueMember = "CODIGO";
                cboSubUbicacion.DisplayMember = "DESCRIPCION";
                cboSubUbicacion.DataSource = dt0;
            }
        }
            private void CARGAR_GRUPO_UBICACION(string op="")
        {
            if(op=="todos")
            {
                DataTable dt0 = new DataTable();
                dt0.Columns.Add("CODIGO");
                dt0.Columns.Add("DESCRIPCION");
                DataRow rw = dt0.NewRow();
                rw["CODIGO"] = "0";
                rw["DESCRIPCION"] = "Todos";
                dt0.Rows.InsertAt(rw, 0);
                cboGrupoUbicacion.ValueMember = "CODIGO";
                cboGrupoUbicacion.DisplayMember = "DESCRIPCION";
                cboGrupoUbicacion.DataSource = dt0;
            }
            else
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
                        //DataRow rw = dt1.NewRow();
                        //rw["CODIGO"] = "0";
                        //rw["DESCRIPCION"] = "Todos";
                        //dt1.Rows.InsertAt(rw, 0);
                        cboGrupoUbicacion.DataSource = dt1;
                        cboGrupoUbicacion.ValueMember = "CODIGO";
                        cboGrupoUbicacion.DisplayMember = "DESCRIPCION";
                    }
                }
                else if (Convert.ToString(cboUbicacion.SelectedValue) == "PP")
                {
                    if (dt2.Rows.Count > 0)
                    {
                        //DataRow rw = dt2.NewRow();
                        //rw["CODIGO"] = "0";
                        //rw["DESCRIPCION"] = "No existe";
                        //dt2.Rows.InsertAt(rw, 0);
                        cboGrupoUbicacion.DataSource = dt2;
                        cboGrupoUbicacion.ValueMember = "CODIGO";
                        cboGrupoUbicacion.DisplayMember = "DESCRIPCION";
                    }
                }
                else if (Convert.ToString(cboUbicacion.SelectedValue) == "PV")
                {
                    if (dt3.Rows.Count > 0)
                    {
                        //DataRow rw = dt3.NewRow();
                        //rw["CODIGO"] = "0";
                        //rw["DESCRIPCION"] = "No existe";
                        //dt3.Rows.InsertAt(rw, 0);
                        cboGrupoUbicacion.DataSource = dt3;
                        cboGrupoUbicacion.ValueMember = "CODIGO";
                        cboGrupoUbicacion.DisplayMember = "DESCRIPCION";
                    }
                }
                else
                {
                    //DataRow rw = dt1.NewRow();
                    //rw["CODIGO"] = "0";
                    //rw["DESCRIPCION"] = "Todos";
                    //dt1.Rows.InsertAt(rw, 0);
                    cboGrupoUbicacion.DataSource = dt1;
                    cboGrupoUbicacion.ValueMember = "CODIGO";
                    cboGrupoUbicacion.DisplayMember = "DESCRIPCION";
                }
            }
           
        }
        private void CARGAR_GESTOR_PD(string CODIGO)   // -- cambio no existia
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
        private void CARGAR_GESTOR_DIRECTA(string CODIGO, string op = "")
        {
            cboGrupoUbicacion.DataSource = null;
            DataTable dt = new DataTable();
            dt.Columns.Add("COD_PER");
            dt.Columns.Add("DESC_PER");
            if (op == "todos")
            {
                DataRow rw = dt.NewRow();
                rw["COD_PER"] = "0";
                rw["DESC_PER"] = "Todos";
                dt.Rows.InsertAt(rw, 0);
                cboGrupoUbicacion.ValueMember = "COD_PER";
                cboGrupoUbicacion.DisplayMember = "DESC_PER";
                cboGrupoUbicacion.DataSource = dt;
            }
            else
            {
                personaBLL perBLL = new personaBLL();
                personaTo perTo = new personaTo();
                //perTo.CODIGO = CODIGO;
                dt = perBLL.obtenerGestoresUbicacionDirectaBLL();
                if (dt.Rows.Count > 0)
                {
                    //DataRow rw = dt.NewRow();
                    //rw["COD_PER"] = "0";
                    //rw["DESC_PER"] = cboUbicacion.SelectedValue.ToString() == "PD" || cboUbicacion.SelectedValue.ToString() == "00" ? "Todos" : "No existe";
                    //dt.Rows.InsertAt(rw, 0);
                    cboGrupoUbicacion.DataSource = dt;
                    cboGrupoUbicacion.ValueMember = "COD_PER";
                    cboGrupoUbicacion.DisplayMember = "DESC_PER";
                    //cboGestor.SelectedIndex = -1;
                }
            }

        }
        private void CARGAR_GESTOR(string CODIGO, string op = "")
        {
            cboSubUbicacion.DataSource = null;
            DataTable dt = new DataTable();
            dt.Columns.Add("COD_PER");
            dt.Columns.Add("DESC_PER");
            if (op=="todos")
            {
                DataRow rw = dt.NewRow();
                rw["COD_PER"] = "0";
                rw["DESC_PER"] = "Todos";
                dt.Rows.InsertAt(rw, 0);
                cboSubUbicacion.ValueMember = "COD_PER";
                cboSubUbicacion.DisplayMember = "DESC_PER";
                cboSubUbicacion.DataSource = dt;
            }
            else
            {
                personaBLL perBLL = new personaBLL();
                personaTo perTo = new personaTo();
                perTo.CODIGO = CODIGO;
                dt = perBLL.obtenerGestoresUbicacionBLL(perTo);
                if (dt.Rows.Count > 0)
                {
                    //DataRow rw = dt.NewRow();
                    //rw["COD_PER"] = "0";
                    //rw["DESC_PER"] = cboUbicacion.SelectedValue.ToString() == "PD" || cboUbicacion.SelectedValue.ToString() == "00" ? "Todos" : "No existe";
                    //dt.Rows.InsertAt(rw, 0);
                    cboSubUbicacion.DataSource = dt;
                    cboSubUbicacion.ValueMember = "COD_PER";
                    cboSubUbicacion.DisplayMember = "DESC_PER";
                    //cboGestor.SelectedIndex = -1;
                }
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
            if(!rdvPtoCob.Checked)
            {
                if (rdb2D1.Checked)
                {
                    if (rdbPD.Checked)
                    {
                        CARGAR_GESTOR_DIRECTA(null, "Elije 1");
                        CARGAR_GRUPO_UBICACION_DIRECTA();
                        cboSubUbicacion.Enabled = false;
                        //CARGAR_GRUPO_UBICACION_PD();
                        //CargarSubUbicacion(tabla1, tipo1, cboGrupoUbicacion.SelectedValue?.ToString(), codNivel1);
                        //cboSubUbicacion.Enabled = true;
                    }
                    else
                    {
                        CARGAR_GRUPO_UBICACION();
                        //CARGAR_GRUPO_UBICACION();
                        //CARGAR_GESTOR(Convert.ToString(cboGrupoUbicacion.SelectedValue));
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
                    }
                }
                else if (rdb2D2.Checked)
                {
                    if (rdbPD.Checked)
                    {
                        CARGAR_GESTOR_DIRECTA(null, "todos");
                        CARGAR_GRUPO_UBICACION_DIRECTA();
                    }
                    else
                    {
                        CARGAR_GRUPO_UBICACION();
                        CARGAR_GESTOR(null, "todos");
                    }


                    //if (rdbPD.Checked)
                    //    CARGAR_GRUPO_UBICACION_PD();
                    //else
                    //    CARGAR_GRUPO_UBICACION();
                    //CARGAR_GESTOR(null,"todos");

                }
                else if (rdb2D3.Checked)
                {
                    CARGAR_GRUPO_UBICACION();
                    CARGAR_GESTOR(null, "todos");

                }
                //CARGAR_GRUPO_UBICACION();
                //CARGAR_GESTOR(null);
                ////cboGrupoUbicacion.Enabled = cboUbicacion.SelectedValue.ToString() == "PD";
                ////cboSubUbicacion.Enabled = cboUbicacion.SelectedValue.ToString() == "PD";
            }
        }

        private void cboGrupoUbicacion_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!rdb2D2.Checked) //!rdb2D2  -- cambio
            {
                if(rdbPD.Checked)
                    CARGAR_GRUPO_UBICACION_DIRECTA("todos");
                else
                {
                    if (Convert.ToString(cboGrupoUbicacion.SelectedValue) != "0" && cboUbicacion.SelectedValue.ToString() != "PP")
                    {
                        CARGAR_GESTOR(Convert.ToString(cboGrupoUbicacion.SelectedValue));
                        if (cboSubUbicacion.DataSource != null)
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
                }
            }
            //if (rdb2D1.Checked)       // -- cambio no existia
            //{
            //    CARGAR_GESTOR_PD(Convert.ToString(cboGrupoUbicacion.SelectedValue));
            //    cboSubUbicacion.SelectedIndex = 0;
            //    cboSubUbicacion.Enabled = true;
            //}
            //else if (rdb2D3.Checked) //!rdb2D2  -- cambio
            //{
            //    if (Convert.ToString(cboGrupoUbicacion.SelectedValue) != "0" && cboUbicacion.SelectedValue.ToString() != "PP")
            //    {
            //        CARGAR_GESTOR(Convert.ToString(cboGrupoUbicacion.SelectedValue));
            //        cboSubUbicacion.SelectedIndex = 0;
            //        cboSubUbicacion.Enabled = true;
            //    }
            //    else if (Convert.ToString(cboGrupoUbicacion.SelectedValue) != "0")
            //    {
            //        CargarSubUbicacion(tabla1, tipo1, cboGrupoUbicacion.SelectedValue?.ToString(), codNivel1);
            //        cboSubUbicacion.Enabled = true;
            //    }
            //    else
            //    {
            //        cboSubUbicacion.SelectedIndex = 0;
            //        cboSubUbicacion.Enabled = false;
            //    }
            //}
        }
        private void CargarSubUbicacion(string table, string tipo, string codigo, string codNivel)
        {
            personaBLL perBLL = new personaBLL();
            DataTable dt = perBLL.ObtenerSubUbicacion(table, tipo, codigo, codNivel);
            if (dt.Rows.Count > 0)
            {
                //DataRow rw = dt.NewRow();
                //rw["COD_PER"] = "0";
                //rw["DESC_PER"] = "Todos";
                //dt.Rows.InsertAt(rw, 0);
                //var query = from order in dt.AsEnumerable()
                //            orderby order.Field<DateTime>("DESC_PER")
                //            select order;
                //DataView view = query.AsDataView();

                cboSubUbicacion.DataSource = dt;
                cboSubUbicacion.ValueMember = "COD_PER";
                cboSubUbicacion.DisplayMember = "DESC_PER";


            }
        }
        private bool validaImprimir()
        {
            bool result = true;
            DateTime start = new DateTime(Convert.ToInt32(cboPeriodoDesde.SelectedValue.ToString().Substring(3, 4)), Convert.ToInt32(cboPeriodoDesde.SelectedValue.ToString().Substring(0,2)), 1);
            DateTime end = start.AddMonths(1);
            if(!(dtpFecReporte.Value>=start && dtpFecReporte.Value<end))
            {
                MessageBox.Show("La Fecha de Reporte debe estar dentro del Mes de Proyeccion !!!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            string parPeriodoCobranza = cboPeriodoDesde.Text;
            string PuntoCobranza = cboPuntoCobranza.Text;
            string Ubicacion = Convert.ToString(cboUbicacion.Text);
            string GrupoUbicacion = rdbPD.Checked == false ? Convert.ToString(cboGrupoUbicacion.Text) : Convert.ToString(cboSubUbicacion.Text);
            string SubUbicacion = rdbPD.Checked == false ? Convert.ToString(cboSubUbicacion.Text) : Convert.ToString(cboGrupoUbicacion.Text);
            //string OpSuspendido = chbSuspendido.Checked ? "Incluye Sin Convenio / Sin Autorización de Descuento / Contratos Suspendidos : Sí" : "Incluye Sin Convenio / Sin Autorización de Descuento / Contratos Suspendidos : No";
            //string OpSuspendido = chbSuspendido.Text;
            string OpSuspendido;
            string reporte = "";
            string modelo = "";
            string fechaReporte = dtpFecReporte.Value.ToShortDateString();
            string opDirecta;
            //


            //string dataSetName = "DataSet1";
            ctpTo.COD_PROGRAMA = Convert.ToString(cboPrograma.SelectedValue) != "0" ? Convert.ToString(cboPrograma.SelectedValue) : null;
            ctpTo.FECHA_APROB_DESDE = dtpFecAprobDesde.Value.Date;
            ctpTo.FECHA_APROB_HASTA = dtpFecAprobHasta.Value.Date;
            ctpTo.PERIODO_DESDE = Convert.ToString(cboPeriodoDesde.SelectedValue);
            ctpTo.PERIODO_HASTA = Convert.ToString(cboPeriodoDesde.SelectedValue);
            ctpTo.COD_UBICACION = Convert.ToString(cboUbicacion.SelectedValue) != "00" ? Convert.ToString(cboUbicacion.SelectedValue) : null;
            if(!rdbPD.Checked)
            {
                ctpTo.COD_GRUPO_UBICACION = Convert.ToString(cboGrupoUbicacion.SelectedValue) != "0" ? Convert.ToString(cboGrupoUbicacion.SelectedValue) : null;
                ctpTo.COD_SUB_UBICACION = Convert.ToString(cboSubUbicacion.SelectedValue) != "0" ? Convert.ToString(cboSubUbicacion.SelectedValue) : null;
                opDirecta = "";
                OpSuspendido = rdbSi.Checked ? siOtro : noOtro;
            }
            else
            {
                ctpTo.COD_SUB_UBICACION = Convert.ToString(cboGrupoUbicacion.SelectedValue) != "0" ? Convert.ToString(cboGrupoUbicacion.SelectedValue) : null;
                ctpTo.COD_GRUPO_UBICACION = Convert.ToString(cboSubUbicacion.SelectedValue) != "0" ? Convert.ToString(cboSubUbicacion.SelectedValue) : null;
                //opDirecta = "DIRECTA: Los Contratos Suspendidos no acumulan el importe a proyectar, solo cuentan cantidad de contratos";
                opDirecta = "";
                OpSuspendido = rdbSi.Checked ? siPD : noPD;
            }
            //ctpTo.COD_PTO_COB = Convert.ToString(cboPuntoCobranza.SelectedValue) != "0" ? Convert.ToString(cboPuntoCobranza.SelectedValue) : null;
            ctpTo.COD_PTO_COB = null;
            //ctpTo.OP1 = chbSuspendido.Checked;
            ctpTo.OP1 = rdbSi.Checked;
            ctpTo.FECHA_ORIGEN = dtpFecReporte.Value;
            //DataTable dt = ctpBLL.MOSTRAR_REPORTE_PROYECCION_COBRANZA_BLL(ctpTo);
            if (rdb2D1.Checked)
                modelo = "(2 D 1)";
            else if (rdb2D2.Checked)
                modelo = "(2 D 2)";
            else if (rdb2D3.Checked)
                modelo = "(2 D 3)";
            DataTable dt1 = null; //DataTable dt2 = null; DataTable dt3 = null; DataTable dt4 = null;
            string dataSetName1 = "DataSet1"; //string dataSetName2 = "";
            Form frm = null;
            object[] reportParam = null;
            if (rdbDetalladoXCont.Checked)
            {
                if (!rdbPD.Checked)
                {
                    reporte = GenericUtil.ObtenerRutaReporteTareaje_MOD_CXC("REP_CARTERA_TOTAL_PROYECTADA_X_PUNTO_COBRANZA_DETALLE");
                    title = "CARTERA TOTAL PROYECTADA POR PUNTO DE COBRANZA - MES MÁS ANTIGUO PROYECCIÓN A 1 MES - POR UBICACIÓN - Detalle";
                }
                else
                {
                    reporte = GenericUtil.ObtenerRutaReporteTareaje_MOD_CXC("REP_CARTERA_TOTAL_PROYECTADA_X_PUNTO_COBRANZA_DETALLE_2");
                    title = "CARTERA TOTAL PROYECTADA POR PUNTO DE COBRANZA - MES MÁS ANTIGUO PROYECCIÓN A 1 MES - POR UBICACIÓN - Detalle";
                }
                //reporte = GenericUtil.ObtenerRutaReporteTareaje_MOD_CXC("REP_CARTERA_TOTAL_PROYECTADA_X_PUNTO_COBRANZA_DETALLE");
                //title = "CARTERA TOTAL PROYECTADA POR PUNTO DE COBRANZA - MES MÁS ANTIGUO PROYECCIÓN A 1 MES - POR UBICACIÓN - Detalle";
                dt1 = ctpBLL.CARTERA_TOTAL_PROYECTADA_X_PUNTO_COBRANZA_BLL(ctpTo);
                reportParam = new object[] { title, programa, parDateApprobation, parPeriodoCobranza, Ubicacion, GrupoUbicacion, SubUbicacion, PuntoCobranza, OpSuspendido, modelo, fechaReporte, opDirecta };
            }
            else if (rdbResumen.Checked)
            {
                if(rdb2D3.Checked)
                    reporte = GenericUtil.ObtenerRutaReporteTareaje_MOD_CXC("REP_CARTERA_TOTAL_PROYECTADA_X_PUNTO_COBRANZA_RESUMEN_2_D_3");
                else if(rdb2D1.Checked || rdb2D2.Checked)
                {
                    if(rdbPD.Checked)
                        reporte = GenericUtil.ObtenerRutaReporteTareaje_MOD_CXC("REP_CARTERA_TOTAL_PROYECTADA_X_PUNTO_COBRANZA_RESUMEN_PD");
                    else
                        reporte = GenericUtil.ObtenerRutaReporteTareaje_MOD_CXC("REP_CARTERA_TOTAL_PROYECTADA_X_PUNTO_COBRANZA_RESUMEN");
                }
                else
                    reporte = GenericUtil.ObtenerRutaReporteTareaje_MOD_CXC("REP_CARTERA_TOTAL_PROYECTADA_X_PUNTO_COBRANZA_RESUMEN");
                title = "CARTERA TOTAL PROYECTADA POR PUNTO DE COBRANZA - MES MÁS ANTIGUO PROYECCIÓN A 1 MES - POR UBICACIÓN - Resumen";
                //reporte = GenericUtil.ObtenerRutaReporteTareaje_MOD_CXC("REP_CARTERA_TOTAL_PROYECTADA_X_PUNTO_COBRANZA_RESUMEN");
                dt1 = ctpBLL.CARTERA_TOTAL_PROYECTADA_X_PUNTO_COBRANZA_BLL(ctpTo);
                reportParam = new object[] { title, programa, parDateApprobation, parPeriodoCobranza, Ubicacion, GrupoUbicacion, SubUbicacion, PuntoCobranza, OpSuspendido, modelo, fechaReporte, opDirecta };
            }
            frm = GenericUtil.CreateReportForm(reporte, dataSetName1, dt1, reportParam);
            frm.Show();
        }
        private void funcion2D1()
        { 
            if(rdbPD.Checked)
            {
                CARGAR_UBICACION("elige_1");
                CARGAR_GESTOR_DIRECTA(Convert.ToString(cboGrupoUbicacion.SelectedValue));
                CARGAR_GRUPO_UBICACION_DIRECTA("elige_1");
            }
            else
            {
                CARGAR_UBICACION("elige_1");
                CARGAR_GRUPO_UBICACION("elige_1");
                //CARGAR_GESTOR(Convert.ToString(cboGrupoUbicacion.SelectedValue), "todos");//sin todos --cambio
                CARGAR_GESTOR(Convert.ToString(cboGrupoUbicacion.SelectedValue));
            }

            rdbDetalladoXCont.Enabled = true;
            rdbResumen.Enabled = true;
            cboUbicacion.Enabled = false;
            cboGrupoUbicacion.Enabled = true;
            cboSubUbicacion.Enabled = true;
            rdbDetalladoXCont.Checked = false;
            rdbResumen.Checked = true;
        }
        private void funcion2D2()
        {
            if(rdbPD.Checked)
            {
                CARGAR_UBICACION("elige_1");
                CARGAR_GESTOR_DIRECTA(null, "todos");
                CARGAR_GRUPO_UBICACION_DIRECTA("todos");
                rdbDetalladoXCont.Enabled = true;
            }
            else
            {
                CARGAR_UBICACION("elige_1");
                //CARGAR_GRUPO_UBICACION("todos");//cambio
                CARGAR_GRUPO_UBICACION("elige_1");
                CARGAR_GESTOR(null, "todos");
                rdbDetalladoXCont.Enabled = false;
            }
            //if(rdbPD.Checked)
            //    rdbDetalladoXCont.Enabled = true;
            //else
            //    rdbDetalladoXCont.Enabled = false;
            rdbResumen.Enabled = true;
            cboUbicacion.Enabled = false;
            cboGrupoUbicacion.Enabled = true;
            cboSubUbicacion.Enabled = false;
            rdbDetalladoXCont.Checked = false;
            rdbResumen.Checked = true;
        }
        private void funcionPtoCob()
        {
            CARGAR_UBICACION("todos_todos");
            CARGAR_GRUPO_UBICACION("todos");
            CARGAR_GESTOR(null, "todos");
            rdbDetalladoXCont.Enabled = true;
            rdbResumen.Enabled = true;
            cboUbicacion.Enabled = true;
            cboGrupoUbicacion.Enabled = false;
            cboSubUbicacion.Enabled = false;
            rdbDetalladoXCont.Checked = true;
            rdbDetalladoXCont.Checked = true;
        }
        private void funcion2D3()
        {
            CARGAR_UBICACION("todos");
            CARGAR_GRUPO_UBICACION("todos");
            CARGAR_GESTOR(null, "todos");
            rdbDetalladoXCont.Enabled = false;
            rdbResumen.Enabled = true;
            cboUbicacion.Enabled = false;
            cboGrupoUbicacion.Enabled = false;
            cboSubUbicacion.Enabled = false;
            rdbDetalladoXCont.Checked = false;
            rdbResumen.Checked = true;
        }
        private void rdb2D1_CheckedChanged(object sender, EventArgs e)
        {

            funcion2D1();
            if (rdbPP.Checked)
                cboUbicacion.SelectedValue = "PP";
            else if (rdbPV.Checked)
                cboUbicacion.SelectedValue = "PV";
            cboUbicacion_SelectionChangeCommitted(sender, e);
        }

        private void rdb2D2_CheckedChanged(object sender, EventArgs e)
        {
            funcion2D2();
            if (rdbPP.Checked)
                cboUbicacion.SelectedValue = "PP";
            else if (rdbPV.Checked)
                cboUbicacion.SelectedValue = "PV";
            cboUbicacion_SelectionChangeCommitted(sender, e);
        }

        private void rdb2D3_CheckedChanged(object sender, EventArgs e)
        {
            funcion2D3();
        }

        private void rdbTodos_CheckedChanged(object sender, EventArgs e)
        {
            etiquetasUbicacion();
            rdb2D1.Enabled = false;
            rdb2D2.Enabled = false;
            rdb2D3.Enabled = true;
            rdb2D3.Checked = true;
            funcion2D3();
            rdb2D1.Text = "Ubicación       : Elije 1 \nGrupo Ubic.     : Elije 1 \nSub Ubicación : Elije 1";
            rdb2D2.Text = "Ubicación       : Elije 1 \nGrupo Ubic.     : Elije 1 \nSub Ubicación : Todos";
            //chbSuspendido.Checked = false;
            //chbSuspendido.Enabled = true;
            //chbSuspendido.Font = new System.Drawing.Font(chbSuspendido.Font, FontStyle.Regular);
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

        private void rdbPP_CheckedChanged(object sender, EventArgs e)
        {
            etiquetasUbicacion();
            rdb2D1.Enabled = true;
            rdb2D2.Enabled = true;
            rdb2D3.Enabled = false;
            rdb2D2.Checked = true;
            funcion2D2();
            cboUbicacion.SelectedValue = "PP";
            cboUbicacion_SelectionChangeCommitted(sender, e);
            rdb2D1.Text = "Ubicación       : " + rdbPP.Text + "\nGrupo Ubic.     : Elije 1 \nSub Ubicación : Elije 1";
            rdb2D2.Text = "Ubicación       : " + rdbPP.Text + "\nGrupo Ubic.     : Elije 1 \nSub Ubicación : Todos";
            //chbSuspendido.Checked = false;
            //chbSuspendido.Enabled = true;
            //chbSuspendido.Font = new System.Drawing.Font(chbSuspendido.Font, FontStyle.Regular);
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

        private void rdbPD_CheckedChanged(object sender, EventArgs e)
        {
            etiquetasUbicacion();
            rdb2D1.Enabled = true;
            rdb2D2.Enabled = true;
            rdb2D3.Enabled = false;
            rdb2D2.Checked = true;
            funcion2D2();
            cboUbicacion.SelectedValue = "PD";
            cboUbicacion_SelectionChangeCommitted(sender, e);
            rdb2D1.Text = "Ubicación       : " + rdbPD.Text + "\nGrupo Ubic.     : Todos \nSub Ubicación : Elije 1";//Elije 1  --cambio
            rdb2D2.Text = "Ubicación       : " + rdbPD.Text + "\nGrupo Ubic.     : Todos \nSub Ubicación : Todos";
            //chbSuspendido.Checked = true;
            //chbSuspendido.Enabled = false;
            //chbSuspendido.Font = new System.Drawing.Font(chbSuspendido.Font, FontStyle.Bold);
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

        private void rdbPV_CheckedChanged(object sender, EventArgs e)
        {
            etiquetasUbicacion();
            rdb2D1.Enabled = true;
            rdb2D2.Enabled = true;
            rdb2D3.Enabled = false;
            rdb2D2.Checked = true;
            funcion2D2();
            cboUbicacion.SelectedValue = "PV";
            cboUbicacion_SelectionChangeCommitted(sender, e);
            rdb2D1.Text = "Ubicación       : " + rdbPV.Text + "\nGrupo Ubic.     : Elije 1 \nSub Ubicación : Elije 1";
            rdb2D2.Text = "Ubicación       : " + rdbPV.Text + "\nGrupo Ubic.     : Elije 1 \nSub Ubicación : Todos";
            //chbSuspendido.Checked = false;
            //chbSuspendido.Enabled = true;
            //chbSuspendido.Font = new System.Drawing.Font(chbSuspendido.Font, FontStyle.Regular);
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

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cboPeriodoDesde_SelectionChangeCommitted(object sender, EventArgs e)
        {
            fechaReporte();
        }
        private void etiquetasUbicacion()
        {
            if(rdbPD.Checked)
            {
                lblGrupoUbicacion.Text = "Sub Ubicación ";
                lblSubUbicacion.Text = "Grupo Ubicación ";
            }
            else
            {
                lblGrupoUbicacion.Text = "Grupo Ubicación ";
                lblSubUbicacion.Text = "Sub Ubicación ";
            }
            
        }

        private void chbSuspendido_CheckedChanged(object sender, EventArgs e)
        {
            if( chbSuspendido.Checked)
            {
                //chbSuspendido.Font = new System.Drawing.Font(chbSuspendido.Font, FontStyle.Bold);
                chbSuspendido.Text = "Sí : Incluye Contratos Suspendidos (No Suma Importes) / Sin Convenio / Sin Autorización de Descuento";
            }
            else if (!chbSuspendido.Checked)
            {
                //chbSuspendido.Font = new System.Drawing.Font(chbSuspendido.Font, FontStyle.Regular);
                chbSuspendido.Text = "No : Incluye Contratos Suspendidos (No Suma Importes) / Sin Convenio / Sin Autorización de Descuento";
            }
        }

        private void rdvPtoCob_CheckedChanged(object sender, EventArgs e)
        {
            etiquetasUbicacion();
            rdb2D1.Enabled = false;
            rdb2D2.Enabled = false;
            rdb2D3.Enabled = true;
            rdb2D3.Checked = true;
            funcionPtoCob();
            rdb2D1.Text = "Ubicación       : Elije 1 \nGrupo Ubic.     : Elije 1 \nSub Ubicación : Elije 1";
            rdb2D2.Text = "Ubicación       : Elije 1 \nGrupo Ubic.     : Elije 1 \nSub Ubicación : Todos";
            chbSuspendido.Checked = false;
            chbSuspendido.Enabled = true;
            chbSuspendido.Font = new System.Drawing.Font(chbSuspendido.Font, FontStyle.Regular);
        }
    }
}
