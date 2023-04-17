using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using static Presentacion.HELPERS.AppearanceUtil;
using static Presentacion.HELPERS.ErrorPrint;
using static Presentacion.HELPERS.GenericMethod;
using static Presentacion.HELPERS.GenericUtil;
using static Presentacion.HELPERS.Constantes;

namespace Presentacion.MOD_COMISIONES.Reportes.Formulario
{
    public partial class FrmRptAdelantoComisionContratosSinAprobar : Form
    {
        public FrmRptAdelantoComisionContratosSinAprobar()
        {
            InitializeComponent();
        }

        private static FrmRptAdelantoComisionContratosSinAprobar instancia;
        public static FrmRptAdelantoComisionContratosSinAprobar Instancia()
        {
            instancia = instancia == null || instancia.IsDisposed
                ? new FrmRptAdelantoComisionContratosSinAprobar()
                : instancia;
            return instancia;
        }

        private readonly comisionesBLL BLComision = new comisionesBLL();
        private readonly personaBLL BLPersona = new personaBLL();
        private readonly programaBLL BLPrograma = new programaBLL();

        private void FrmRptAdelantoComisionContratosSinAprobar_Load(object sender, EventArgs e)
        {
            StartControsl();
            CargarPersonaNivelVenta();
            CargarComboboxPrograma();
            CargarComboboxNroAdelanto();
        }

        private void StartControsl()
        {
            cboPersona.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPrograma.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNroAdelanto.DropDownStyle = ComboBoxStyle.DropDownList;
            btnImprimir.StyleButtonFlat();
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

        private void CargarComboboxPrograma()
        {
            DataTable dt = BLPrograma.obtenerProgramaBLL();
            cboPrograma.DataSource = dt;
            cboPrograma.DisplayMember = "DESC_PROGRAMA";
            cboPrograma.ValueMember = "COD_PROGRAMA";
        }

        private void CargarComboboxNroAdelanto()
        {
            ComisionAdelantoTo to = new ComisionAdelantoTo
            {
                COD_NIVEL = COD_NIVEL_VENDEDOR,
            };
            DataTable dt = BLComision.ListaNroAdelantoComision(to);
            cboNroAdelanto.DataSource = dt;
            cboNroAdelanto.ValueMember = "NRO_ADELANTO";
            cboNroAdelanto.DisplayMember = "DESC_NRO_ADELANTO";
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                ComisionAdelantoTo to = new ComisionAdelantoTo
                {
                    COD_PER = cboPersona.SelectedValue?.ToString(),
                    ProgramaTo = new programaTo { COD_PROGRAMA = cboPrograma.SelectedValue?.ToString() },
                    NRO_ADELANTO = int.TryParse(Convert.ToString(cboNroAdelanto.SelectedValue), out int val) ? val : 0
                };
                DataTable dt = BLComision.RptAdelantoComisionContratosSinAprobar(to);
                string reporte = ObtenerRutaReporteTareaje("RptAdelantoComision", Modulo.MOD_COMISIONES);
                const string data_set_name = "DataSet1";
                const string titulo = "ADELANTO DE COMISIONES DE CONTRATOS SIN APROBAR";
                string nombrePrograma = string.Concat("Programa: ", cboPrograma.Text);
                string nroAdelanto = string.Concat("Nro Adelanto: ", cboNroAdelanto.Text);
                object[] parameters = { titulo, nombrePrograma, nroAdelanto};
                Form frm = CreateReportForm(reporte, data_set_name, dt, parameters);
                frm.Show();
            }
            catch (Exception ex)
            {
                ex.PrintException();
            }
        }
    }
}
