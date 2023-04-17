using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Presentacion.HELPERS.GenericUtil;
using static Presentacion.HELPERS.ErrorPrint;

namespace Presentacion.MOD_FACT_VTA.MOD_VTA.Reportes.ReporteODR
{
    public partial class FrmRptEfectividadComparativaEnvGen : Form
    {
        private readonly programaBLL BLPrograma = new programaBLL();
        private readonly puntoCobranzaBLL BLPuntoCobranza = new puntoCobranzaBLL();
        private readonly DepartamentoBLL BLDepartamento = new DepartamentoBLL();
        private readonly ReportesBLL BLReportes = new ReportesBLL();
        private readonly institucionesBLL BLInstitucion = new institucionesBLL();

        private bool act = true;

        public FrmRptEfectividadComparativaEnvGen()
        {
            InitializeComponent();
        }

        private void FrmRptEfectividadComparativaEnvGen_Load(object sender, EventArgs e)
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
                string codPais = EmpresaSistema.CodPais;
                DataTable dt = BLReportes.RptEfectividadComparativaGenEnv(cboPrograma.SelectedValue.ToString(), codPtoCob,
                     codDepartamento, cboInstitucion.SelectedValue.ToString(), codPais, dtFechaInicio.Value, dtFechaFin.Value);
                const string dataSetName = "DataSet1";
                string p1 = chkPCobranza.Checked ? "PUNTO DE COBRANZA" : chkDepartamento.Checked ? "DEPARTAMENTO" : "INSTITUCIÓN" ;
                string titulo = "REPORTE DE EFECTIVIDAD DE PLANILLA GENERADA Y ENVIADA VS. EJECUTADA POR " + p1;
                string programa = cboPrograma.Text.ToString();
                string nameFil = chkPCobranza.Checked ? "Punto Cobranaza : " + cboPCobranza.Text : chkDepartamento.Checked ? "Departamento : " + cboDetartamento.Text : "Institución : " + cboInstitucion.Text;
                string periodo = dtFechaInicio.Text + " - " + dtFechaFin.Text;
                int acces = chkPCobranza.Checked ? 1 : chkDepartamento.Checked ? 2 : 3;
                string reportSource = chkPCobranza.Checked ? ObtenerRutaReporteTareaje_MOD_CXC("RptEfectividadComparativaPllaEnvGen") : chkDepartamento.Checked ? ObtenerRutaReporteTareaje_MOD_CXC("RptEfectividadComparativaEnvGenDepartamento") : ObtenerRutaReporteTareaje_MOD_CXC("RptEfectividadComparativaPllaEnvGenInstitucion");
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
    }
}
