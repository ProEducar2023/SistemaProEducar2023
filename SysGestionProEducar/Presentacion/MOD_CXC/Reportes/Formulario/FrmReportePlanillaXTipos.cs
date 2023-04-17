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
    public partial class FrmReportePlanillaTipos : Form
    {
        private readonly cambioTipoPllaHistoricoBLL BLcancelacionPlanilla = new cambioTipoPllaHistoricoBLL();

        public FrmReportePlanillaTipos()
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
            rdConMov.Checked = true;
        }

        private void rdConMov_CheckedChanged(object sender, EventArgs e)
        {
            DataTable dt;
            if (rdConMov.Checked == true)
            {
                dt = BLcancelacionPlanilla.planillatipo(true);
                cboTipo_cancelacion.DataSource = dt;
                cboTipo_cancelacion.DisplayMember = "DESC_TIPO"; 
                cboTipo_cancelacion.ValueMember = "COD_TIPO_PLLA";
            }
            else
            {
                dt = BLcancelacionPlanilla.planillatipo(false);

                cboTipo_cancelacion.DataSource = dt;
                cboTipo_cancelacion.DisplayMember = "DESC_TIPO";
                cboTipo_cancelacion.ValueMember = "COD_TIPO_PLLA"; 
            }
        }


        private void btnImprimir_Click(object sender, EventArgs e)
        {
            DateTime F2 = dtFECHA2.Value;
            string codigoPrograma = cboprogramas.SelectedValue.ToString();
            int tipoOrden;
            string programa = "Programa : " + cboprogramas.Text;
            string periodo = "Periodo : " + dtFECHA1.Text + " - " + dtFECHA2.Text;
            string tipoPlanilla = "Tipo Planilla : " + cboTipo_cancelacion.Text;

            string tipoPla;
            if (rdSinMov.Checked == true && cboTipo_cancelacion.SelectedValue.ToString() == "0")
                tipoPla = "01";
            else
                tipoPla = cboTipo_cancelacion.SelectedValue.ToString();


            if (radioButton1.Checked == true)
                tipoOrden = 1;
            else if (radioButton2.Checked == true)
                tipoOrden = 2;
            else
                tipoOrden = 3;

            string reporte = GenericUtil.ObtenerRutaReporteTareaje_MOD_CXC("Report7PlanilaXTipos");
            string dataSetName = "DataSet1";
            DataTable dt = BLcancelacionPlanilla.ObtenerPlanillaResumenXtipo(codigoPrograma, dtFECHA1.Value, F2, tipoPla);
            object[] reportParam = new object[] { tipoOrden, programa, periodo, tipoPlanilla };

            Form frm = GenericUtil.CreateReportForm(reporte, dataSetName, dt, reportParam);
            frm.Show();
        }

        private void btnImprimir2_Click(object sender, EventArgs e)
        {
            DateTime F2 = dtFECHA2.Value;
            string codigoPrograma = cboprogramas.SelectedValue.ToString();
            int tipoOrden;
            string programa = "Programa : " + cboprogramas.Text;
            string periodo = "Periodo : " + dtFECHA1.Text + " - " + dtFECHA2.Text;

            //============================================//
            //SENTENCIA PARA PODER OBTENER LA OPCION TODOS//
            //============================================//

            //string tipoPla;
            //if (rdSinMov.Checked == true && cboTipo_cancelacion.SelectedValue.ToString() == "0")
            //    tipoPla = "01";
            //else
            //    tipoPla = cboTipo_cancelacion.SelectedValue.ToString();


            if (radioButton1.Checked == true)
                tipoOrden = 1;
            else if (radioButton2.Checked == true)
                tipoOrden = 2;
            else
                tipoOrden = 3;

            string reporte = GenericUtil.ObtenerRutaReporteTareaje_MOD_CXC("Report8ResumenComparativo");
            string dataSetName = "DataSet1";
            DataTable dt = BLcancelacionPlanilla.ObtenerResumenXtipo(codigoPrograma, dtFECHA1.Value, F2, cboTipo_cancelacion.SelectedValue.ToString());
            //>object[] reportParam = new object[] { titulo, cboPrograma.Text, periodo, cboPuntoCobranza.Text };

            Form frm = GenericUtil.CreateReportForm(reporte, dataSetName, dt, tipoOrden, programa, periodo);
            frm.Show();
        }

        private void btnOpcion3_Click(object sender, EventArgs e)
        {
            DateTime F2 = dtFECHA2.Value;
            string codigoPrograma = cboprogramas.SelectedValue.ToString();

            DataTable dt = BLcancelacionPlanilla.ObtenerGreedXtipo(codigoPrograma, dtFECHA1.Value, F2, cboTipo_cancelacion.SelectedValue.ToString());
            //PARA PASAR LOS DATOS DE UN BOTON A UN DATA GREDVIEW
            FrmListadoReporteCancelacionXDetalle frm = new FrmListadoReporteCancelacionXDetalle(dt, cboTipo_cancelacion, cboprogramas, dtFECHA1, dtFECHA2)
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            frm.Show();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            DateTime F2 = dtFECHA2.Value;
            string codigoPrograma = cboprogramas.SelectedValue.ToString();
            int tipoOrden;
            string programa = "Programa : " + cboprogramas.Text;
            string periodo = "Periodo : " + dtFECHA1.Text + " - " + dtFECHA2.Text;
            string tipoPlanilla = "Tipo Planilla : " + cboTipo_cancelacion.Text;

            string tipoPla;
            if (rdSinMov.Checked == true && cboTipo_cancelacion.SelectedValue.ToString() == "0")
                tipoPla = "01";
            else
                tipoPla = cboTipo_cancelacion.SelectedValue.ToString();


            if (radioButton1.Checked == true)
                tipoOrden = 1;
            else if (radioButton2.Checked == true)
                tipoOrden = 2;
            else
                tipoOrden = 3;

            string reporte = GenericUtil.ObtenerRutaReporteTareaje_MOD_CXC("Report18PlanilaXTipos");
            string reporte1 = GenericUtil.ObtenerRutaReporteTareaje_MOD_CXC("Report19PlanilaXTipos");

            string select;
            if (cboTipo_cancelacion.SelectedValue.ToString() == "PP")
                select = reporte;
            else if (cboTipo_cancelacion.SelectedValue.ToString() == "PV")
                select = reporte1;
            else
                select = reporte1;

            string dataSetName = "DataSet1";
            DataTable dt = BLcancelacionPlanilla.ObtenerPlanilla_J(codigoPrograma, dtFECHA1.Value, F2, tipoPla);
            object[] reportParam = new object[] { tipoOrden, programa, periodo, tipoPlanilla };

            Form frm = GenericUtil.CreateReportForm(select,dataSetName, dt, reportParam);
            frm.Show();
        }

        private void btnCuadreResumen_Click(object sender, EventArgs e)
        {
            DateTime F2 = dtFECHA2.Value;
            string codigoPrograma = cboprogramas.SelectedValue.ToString();
            int tipoOrden;
            string programa = "Programa : " + cboprogramas.Text;
            string periodo = "Periodo : " + dtFECHA1.Text + " - " + dtFECHA2.Text;
            string tipoPlanilla = "Tipo Planilla : " + cboTipo_cancelacion.Text;

            string tipoPla;
            if (rdSinMov.Checked == true && cboTipo_cancelacion.SelectedValue.ToString() == "0")
                tipoPla = "01";
            else
                tipoPla = cboTipo_cancelacion.SelectedValue.ToString();


            if (radioButton1.Checked == true)
                tipoOrden = 1;
            else if (radioButton2.Checked == true)
                tipoOrden = 2;
            else
                tipoOrden = 3;

            string reporte = GenericUtil.ObtenerRutaReporteTareaje_MOD_CXC("RptCuadreResumenPlanilla");
            string reporte1 = GenericUtil.ObtenerRutaReporteTareaje_MOD_CXC("RptCuadreResumenPlanilla");

            string select;
            if (cboTipo_cancelacion.SelectedValue.ToString() == "PP")
                select = reporte;
            else if (cboTipo_cancelacion.SelectedValue.ToString() == "PV")
                select = reporte1;
            else
                select = reporte1;

            string dataSetName = "DataSet1";
            DataTable dt = BLcancelacionPlanilla.ObtenerPlanilla_J(codigoPrograma, dtFECHA1.Value, F2, tipoPla);
            object[] reportParam = new object[] { tipoOrden, programa, periodo, tipoPlanilla };

            Form frm = GenericUtil.CreateReportForm(select, dataSetName, dt, reportParam);
            frm.Show();
        }
    }
}
