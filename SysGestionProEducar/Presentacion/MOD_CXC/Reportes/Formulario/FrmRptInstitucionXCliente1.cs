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
    public partial class FrmRptInstitucionXCliente1 : Form
    {
        private readonly cambioTipoPllaHistoricoBLL BLCambioPlanilla = new  cambioTipoPllaHistoricoBLL();

        public FrmRptInstitucionXCliente1()
        {
            InitializeComponent();
        }

        private void FrmRptInstitucionXCliente1_Load(object sender, EventArgs e)
        {
            cboINSTITUCIONES.DataSource = BLCambioPlanilla.Institucion(); //cargar las categorias
            cboINSTITUCIONES.DisplayMember = "DESC_INST"; //a visualizar
            cboINSTITUCIONES.ValueMember = "COD_INST";//valor
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string reporte = GenericUtil.ObtenerRutaReporteTareaje_MOD_CXC("Report1");
            string dataSetName = "DataSet1";
            DataTable dt = BLCambioPlanilla.ObtenerPersonaXInstitucion(cboINSTITUCIONES.SelectedValue.ToString());
            //>object[] reportParam = new object[] { titulo, cboPrograma.Text, periodo, cboPuntoCobranza.Text };
            Form frm = GenericUtil.CreateReportForm(reporte, dataSetName, dt, null);
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string reporte = GenericUtil.ObtenerRutaReporteTareaje_MOD_CXC("Report2");
            string dataSetName = "DataSet1";
            DataTable dt = BLCambioPlanilla.ObtenerPersonasSinCodiga();
            Form frm = GenericUtil.CreateReportForm(reporte, dataSetName, dt, null);
            frm.Show();
        }
    }
}
