using System;
using System.Data;
using System.Windows.Forms;
using BLL;
using static Presentacion.HELPERS.GenericUtil;
using static Presentacion.HELPERS.ErrorPrint;

namespace Presentacion.MOD_FACT_VTA.MOD_VTA.Reportes.ReporteODR
{
    public partial class FrmRptEfectividadComparativa : Form
    {
        private readonly programaBLL BLPrograma = new programaBLL();
        private readonly puntoCobranzaBLL BLPuntoCobranza = new puntoCobranzaBLL();
        private readonly DepartamentoBLL BLDepartamento = new DepartamentoBLL();
        private readonly ReportesBLL BLReportes = new ReportesBLL();
        private readonly institucionesBLL BLInstitucion = new institucionesBLL();

        private bool act = true;

        public FrmRptEfectividadComparativa()
        {
            InitializeComponent();
        }

        private void FrmRptEfectividadComparativa_Load(object sender, EventArgs e)
        {
            StartControls();
            CargarComboboxPrograma();
            CargarCoboboxPuntoCobranza();
            CargarComboboxDepartamento();
            CargarComboboxInstitucion();
        }

        private void StartControls()
        {
            chkPCobranza.Checked = true;
            cboPCobranza.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboPCobranza.AutoCompleteSource = AutoCompleteSource.ListItems;
            cboDetartamento.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboDetartamento.AutoCompleteSource = AutoCompleteSource.ListItems;
            cboInstitucion.DropDownStyle = ComboBoxStyle.DropDownList;

            dtFechaInicio.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtFechaFin.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            rdbOp1.Checked = true;
        }

        private void CargarComboboxPrograma()
        {
            DataTable dt = BLPrograma.obtenerProgramaBLL();
            cboPrograma.DataSource = dt;
            cboPrograma.DisplayMember = "DESC_PROGRAMA";
            cboPrograma.ValueMember = "COD_PROGRAMA";
        }

        private void CargarCoboboxPuntoCobranza()
        {
            DataTable dtPuntoCobranza = BLPuntoCobranza.ListarPtoCobranza();
            DataRow row = dtPuntoCobranza.NewRow();
            row["COD_PTO_COB"] = "000";
            row["DESC_PTO_COB"] = "TODOS";
            dtPuntoCobranza.Rows.InsertAt(row, 0);
            cboPCobranza.DisplayMember = "DESC_PTO_COB";
            cboPCobranza.ValueMember = "COD_PTO_COB";
            cboPCobranza.DataSource = dtPuntoCobranza;
        }

        private void CargarComboboxDepartamento()
        {
            DataTable dt = BLDepartamento.ListarDepartamentos();
            DataRow row = dt.NewRow();
            row["COD_DEP"] = "00";
            row["DESC_DEP"] = "TODOS";
            dt.Rows.InsertAt(row, 0);
            cboDetartamento.DataSource = dt;
            cboDetartamento.DisplayMember = "DESC_DEP";
            cboDetartamento.ValueMember = "COD_DEP";
        }

        private void CargarComboboxInstitucion()
        {
            DataTable dt = BLInstitucion.obtenerInstitucionesBLL();
            DataRow row = dt.NewRow();
            row["COD_INST"] = "00";
            row["DESC_INST"] = "TODOS";
            dt.Rows.InsertAt(row, 0);
            cboInstitucion.DataSource = dt;
            cboInstitucion.DisplayMember = "DESC_INST";
            cboInstitucion.ValueMember = "COD_INST";
        }


        private void ChkPCobranza_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = sender as CheckBox;
            if (chk.Name == chkPCobranza.Name && act)
            {
                act = false;
                chkDepartamento.Checked = false;
                chkInstitucion.Checked = false;
                chk.Checked = chk.Checked ? chk.Checked : !chk.Checked;
                act = true;
            }
            else if (chk.Name == chkDepartamento.Name && act)
            {
                act = false;
                chkPCobranza.Checked = false;
                chkInstitucion.Checked = false;
                chk.Checked = chk.Checked ? chk.Checked : !chk.Checked;
                act = true;
            }
            else if (chk.Name == chkInstitucion.Name && act)
            {
                act = false;
                chkDepartamento.Checked = false;
                chkPCobranza.Checked = false;
                chk.Checked = chk.Checked ? chk.Checked : !chk.Checked;
                act = true;
            }
        }

        private void BtnConsular_Click(object sender, EventArgs e)
        {
            try
            {
                string codPtoCob = chkPCobranza.Checked ? cboPCobranza.SelectedValue.ToString() : string.Empty;
                string codDepartamento = chkDepartamento.Checked ? cboDetartamento.SelectedValue.ToString() : string.Empty;
                DataTable dt;
                const string dataSetName = "DataSet1";
                string p1 = chkPCobranza.Checked ? "PUNTO DE COBRANZA" : chkDepartamento.Checked ? "DEPARTAMENTO" : "INSTITUCIÓN";
                string titulo;
                string programa = cboPrograma.Text.ToString();
                string nameFil = chkPCobranza.Checked ? "Punto Cobranaza : " + cboPCobranza.Text : chkDepartamento.Checked ? "Departamento : " + cboDetartamento.Text : "Institución : " + cboInstitucion.Text;
                string periodo = dtFechaInicio.Text + " - " + dtFechaFin.Text;
                int acces = chkPCobranza.Checked ? 1 : chkDepartamento.Checked ? 2 : 3;
                string reportSource;
                string codPais = EmpresaSistema.CodPais;
                if (rdbOp1.Checked)
                {
                    dt = BLReportes.RptEfectividadComparativa(cboPrograma.SelectedValue.ToString(), codPtoCob,
                     codDepartamento, cboInstitucion.SelectedValue.ToString(), codPais, dtFechaInicio.Value, dtFechaFin.Value);
                    titulo = "REPORTE DE EFECTIVIDAD COMPARATIVA MES A MES EN % POR " + p1;
                    reportSource = chkPCobranza.Checked ? ObtenerRutaReporteTareaje_MOD_CXC("RptEfectividadComparativa") : chkDepartamento.Checked ? ObtenerRutaReporteTareaje_MOD_CXC("RptEfectividadComparativaDepartamento") : ObtenerRutaReporteTareaje_MOD_CXC("RptEfectividadComparativaInstitucion");
                }
                else if (rdbOp2.Checked)
                {
                    dt = BLReportes.RptEfectividadComparativaGenEnv(cboPrograma.SelectedValue.ToString(), codPtoCob,
                     codDepartamento, cboInstitucion.SelectedValue.ToString(), codPais, dtFechaInicio.Value, dtFechaFin.Value);
                    titulo = "REPORTE DE EFECTIVIDAD DE PLANILLA GENERADO Y ENVIADO VS. DESCONTADO POR " + p1;
                    reportSource = chkPCobranza.Checked ? ObtenerRutaReporteTareaje_MOD_CXC("RptEfectividadComparativaPllaEnvGen") : chkDepartamento.Checked ? ObtenerRutaReporteTareaje_MOD_CXC("RptEfectividadComparativaEnvGenDepartamento") : ObtenerRutaReporteTareaje_MOD_CXC("RptEfectividadComparativaPllaEnvGenInstitucion");
                }
                else if (rdbOp3.Checked)
                {
                    dt = BLReportes.RptEfectividadComparativaGenEnv2(cboPrograma.SelectedValue.ToString(), codPtoCob,
                     codDepartamento, cboInstitucion.SelectedValue.ToString(), codPais, dtFechaInicio.Value, dtFechaFin.Value);
                    titulo = "REPORTE DE EFECTIVIDAD DE PLANILLA GENERADO Y ENVIADO VS. DESCONTADO COMPARATIVO MES A MES POR " + p1;
                    reportSource = chkPCobranza.Checked ? ObtenerRutaReporteTareaje_MOD_CXC("RptEfectividadComparativaPllaEnvGen2") : chkDepartamento.Checked ? ObtenerRutaReporteTareaje_MOD_CXC("RptEfectividadComparativaPllaEnvGen2Departamento") : ObtenerRutaReporteTareaje_MOD_CXC("RptEfectividadComparativaPllaEnvGen2Institucion");
                }
                else
                    throw new ArgumentNullException();

                Form frm = CreateReportForm
                    (
                        reportSource,
                        dataSetName,
                        dt,
                        titulo,
                        programa,
                        nameFil,
                        periodo,
                        acces
                    );
                _ = frm.ShowDialog();
            }
            catch (Exception ex)
            {
                ex.PrintException();
            }
        }

        private void CboPCobranza_TextChanged(object sender, EventArgs e)
        {
            //if (dtPuntoCobranza != null)
            //{
            //    if (string.IsNullOrEmpty(cboPCobranza.Text.Trim()))
            //        CargarCoboboxPuntoCobranza();
            //    else
            //    {
            //        cboPCobranza.DisplayMember = "DESC_PTO_COB";
            //        cboPCobranza.ValueMember = "COD_PTO_COB";
            //        cboPCobranza.DataSource = dtPuntoCobranza.Select("DESC_PTO_COB LIKE '%" + cboPCobranza.Text + "%'").CopyToDataTable();
            //    }
            //}
        }
    }
}
