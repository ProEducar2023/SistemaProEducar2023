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

namespace Presentacion.MOD_CXC.Reportes.Formulario
{
    public partial class FrmCancelacionXPlanilla : Form
    {
        private readonly cambioTipoPllaHistoricoBLL BLcancelacionPlanilla = new cambioTipoPllaHistoricoBLL();

        public FrmCancelacionXPlanilla()
        {
            InitializeComponent();
        }

        private void FrmCancelacionXPlanilla_Load(object sender, EventArgs e)
        {
            cboprogramas.DataSource = BLcancelacionPlanilla.Programas();
            cboprogramas.DisplayMember = "DESC_PROGRAMA"; //campo a listar
            cboprogramas.ValueMember = "COD_PROGRAMA"; //value



            cboTipo_cancelacion.DataSource = BLcancelacionPlanilla.planillaCancel();
            cboTipo_cancelacion.DisplayMember = "DESC_TIPO"; //campo a listar
            cboTipo_cancelacion.ValueMember = "COD_TIPO_PLLA"; //value

            StartControls();
        }


        private void StartControls()
        {
            dtFECHA1.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtFECHA2.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        }


        private void btnImprimir_Click(object sender, EventArgs e)
        {
            DateTime F2 = dtFECHA2.Value;
            string codigoPrograma = cboprogramas.SelectedValue.ToString();

            int tipoOrden;
            string programa = "Programa : " + cboprogramas.Text;
            string periodo = "Periodo : " + dtFECHA1.Text + " - " + dtFECHA2.Text;
            string tipoPlanilla = "Tipo Planilla : " + cboTipo_cancelacion.Text;
            object[] reportParam ;
            string reporte;
            string dataSetName;
            if (cboTipo_cancelacion.SelectedValue.ToString() == "0")
            {
                if (radioButton1.Checked == true)
                    tipoOrden = 1;
                else if (radioButton2.Checked == true)
                    tipoOrden = 2;
                else
                    tipoOrden = 3;

                reporte = GenericUtil.ObtenerRutaReporteTareaje_MOD_CXC("Report5");
                dataSetName = "DataSet1";

                reportParam = new object[] { tipoOrden, programa, periodo, tipoPlanilla };
            }
            else
            {
                if (radioButton1.Checked == true)
                    tipoOrden = 1;
                else if (radioButton2.Checked == true)
                    tipoOrden = 2;
                else
                    tipoOrden = 3;

                reporte = GenericUtil.ObtenerRutaReporteTareaje_MOD_CXC("Report3");
                dataSetName = "DataSet1";

                reportParam = new object[] { tipoOrden, programa, periodo, tipoPlanilla };
            }

            DataTable dt = BLcancelacionPlanilla.ObtenerPlanilla(codigoPrograma, dtFECHA1.Value, F2, cboTipo_cancelacion.SelectedValue.ToString());
            Form frm = GenericUtil.CreateReportForm(reporte, dataSetName, dt, reportParam);
            frm.Show();


        }

        private void btnImprimir2_Click(object sender, EventArgs e)
        {

            DateTime F2 = dtFECHA2.Value;
            string codigoPrograma = cboprogramas.SelectedValue.ToString();
            int tipoOrden;
            string programa = "Programa : " + cboprogramas.Text;
            string periodo = "Periodo : " + dtFECHA1.Text+ " - " + dtFECHA2.Text;

            if (radioButton1.Checked == true)
                tipoOrden = 1;
            else if (radioButton2.Checked == true)
                tipoOrden = 2;
            else
                tipoOrden = 3;

            string reporte = GenericUtil.ObtenerRutaReporteTareaje_MOD_CXC("Report4");
            string dataSetName = "DataSet1";
            DataTable dt = BLcancelacionPlanilla.ObtenerResumen(codigoPrograma, dtFECHA1.Value, F2, cboTipo_cancelacion.SelectedValue.ToString());
            //>object[] reportParam = new object[] { titulo, cboPrograma.Text, periodo, cboPuntoCobranza.Text };

            Form frm = GenericUtil.CreateReportForm(reporte, dataSetName, dt, tipoOrden, programa, periodo);
            frm.Show();
        }

      

        private void btnImprimir3_Click(object sender, EventArgs e)
        {
            DateTime F2 = dtFECHA2.Value;
            string codigoPrograma = cboprogramas.SelectedValue.ToString();

            DataTable dt = BLcancelacionPlanilla.ObtenerPlanilla(codigoPrograma, dtFECHA1.Value, F2, cboTipo_cancelacion.SelectedValue.ToString());
            //PARA PASAR LOS DATOS DE UN BOTON A UN DATA GREDVIEW
            FrmListadoPlanillasParaContratos frm = new FrmListadoPlanillasParaContratos(dt, cboTipo_cancelacion, cboprogramas, dtFECHA1, dtFECHA2)
            {
                StartPosition = FormStartPosition.CenterParent
            };
            frm.Show();
        }
    }
}
