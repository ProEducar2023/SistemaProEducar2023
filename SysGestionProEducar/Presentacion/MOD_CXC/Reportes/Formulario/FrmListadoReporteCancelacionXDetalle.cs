using System;
using Presentacion.HELPERS;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using BLL;

namespace Presentacion.MOD_CXC.Reportes.Formulario
{

    public partial class FrmListadoReporteCancelacionXDetalle : Form
    {

        private readonly DataTable dt1;
        private readonly ComboBox cboTipo_cancelacion;
        private readonly ComboBox cboprogramas;

        private readonly DateTimePicker dtFECHA1;
        private readonly DateTimePicker dtFECHA2;


        private readonly cambioTipoPllaHistoricoBLL cambioTipoPllaHistoricoBLL = new cambioTipoPllaHistoricoBLL();

        public FrmListadoReporteCancelacionXDetalle(DataTable dt, ComboBox cboTipo_cancelacion, ComboBox cboprogramas, DateTimePicker dtFECHA1, DateTimePicker dtFECHA2)
        {
            InitializeComponent();
            dt1 = dt;

            this.cboTipo_cancelacion = cboTipo_cancelacion;
            this.cboprogramas = cboprogramas;

            this.dtFECHA1 = dtFECHA1;
            this.dtFECHA2 = dtFECHA2;
        }

        private void FrmListadoPlanillasParaContratos_Load(object sender, EventArgs e)
        {
            MostrarListaPlanilla();
            FormatColumns();
            MostrarTotales();
        }

        private void MostrarListaPlanilla()
        {
            dgvPlanilla.DataSource = dt1;
        }


        private void MostrarTotales()
        {
            

            //para mostrar los datos en el txt
            txtCantidadPlanilla.Text = Convert.ToString(dgvPlanilla.Rows.Count);  //cuenta el total de planillas

            decimal importeTotal = 0;
            foreach (DataGridViewRow row in dgvPlanilla.Rows)
            {
                importeTotal += Convert.ToDecimal(row.Cells["IMP_DOC"].Value);
            }
            txtTotalPlanilla.Text = importeTotal.ToString("N2");

            txtPeriodo.Text = Convert.ToString(dtFECHA1.Text);

            txtTipoPlanilla.Text = cboTipo_cancelacion.SelectedValue.ToString() == "PP" ? cboTipo_cancelacion.Text + " EJECUTADA" : cboTipo_cancelacion.Text;
        }



        private void FormatColumns()
        {
            //REALIZAR LOS 3 PARA PODER MOTRAR EL NOMBRE Y POSICION DE UNA COLUMNA 
            dgvPlanilla.Columns["NRO_PLANILLA_COB"].HeaderText = "NRO DE PLANILLA";     //NOMBRE DE LA COLUMNA
            dgvPlanilla.Columns["NRO_PLANILLA_COB"].Width = 200;         //ANCHO  DE LA COLUMNA
            //dgvPlanilla.Columns["NRO_PLANILLA_COB"].Visible = false;         // para que no se visualice la columna en un reporte
            dgvPlanilla.Columns["NRO_PLANILLA_COB"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;  //POCICION DE LA COLUMNA


            dgvPlanilla.Columns["FECHA_PLANILLA_COB"].HeaderText = "FECHA DE PLANILLA";
            dgvPlanilla.Columns["FECHA_PLANILLA_COB"].Width = 200;
            dgvPlanilla.Columns["FECHA_PLANILLA_COB"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dgvPlanilla.Columns["IMP_DOC"].HeaderText = "IMPORTE DE PLANILLA";
            dgvPlanilla.Columns["IMP_DOC"].Width = 200;
            dgvPlanilla.Columns["IMP_DOC"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dgvPlanilla.Columns["DESC_PTO_COB"].HeaderText = "PUNTO DE COBRANZA";
            dgvPlanilla.Columns["DESC_PTO_COB"].Width = 250;
            //dgvPlanilla.Columns["DESC_PTO_COB"].Visible = false;   
            dgvPlanilla.Columns["DESC_PTO_COB"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dgvPlanilla.SelectionMode = DataGridViewSelectionMode.FullRowSelect;  //es para que se seleccione toda la fila 
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (dgvPlanilla.CurrentCell != null)
            {
                string nroPlanilla = dgvPlanilla.CurrentRow.Cells["NRO_PLANILLA_COB"].Value.ToString();

                //capturar los reportes
                string n_planilla = "N° Planilla : " + dgvPlanilla.CurrentRow.Cells["NRO_PLANILLA_COB"].Value.ToString();
                string punto_cobranza = "Pto Cobranza : " + dgvPlanilla.CurrentRow.Cells["DESC_PTO_COB"].Value.ToString();

                string programa = "Programa : " + cboprogramas.Text;
                string tipoPlanilla = "Tipo planilla : " + cboTipo_cancelacion.Text;
                string periodo = "Periodo : " + dtFECHA1.Text + " - " + dtFECHA2.Text;

                string reporte1 = GenericUtil.ObtenerRutaReporteTareaje_MOD_CXC("Report9DetalleContrato-PP"); //PP
                string reporte2 = GenericUtil.ObtenerRutaReporteTareaje_MOD_CXC("Report10DetalleContrato-PV"); //PV
                string reporte3 = GenericUtil.ObtenerRutaReporteTareaje_MOD_CXC("Report11DetalleContrato-PD"); //PD

                string reporte4 = GenericUtil.ObtenerRutaReporteTareaje_MOD_CXC("Report12DetalleContrato-DM"); //DM
                string reporte5 = GenericUtil.ObtenerRutaReporteTareaje_MOD_CXC("Report13DetalleContrato-DR"); //DR
                string reporte6 = GenericUtil.ObtenerRutaReporteTareaje_MOD_CXC("Report14DetalleContrato-PE"); //PE
                string reporte7 = GenericUtil.ObtenerRutaReporteTareaje_MOD_CXC("Report15DetalleContrato-DE"); //DE
                string reporte8 = GenericUtil.ObtenerRutaReporteTareaje_MOD_CXC("Report16DetalleContrato-DX");  //DX

                string select;
                if (cboTipo_cancelacion.SelectedValue.ToString() == "PP")
                    select = reporte1;
                else if (cboTipo_cancelacion.SelectedValue.ToString() == "PV")
                    select = reporte2;
                else if (cboTipo_cancelacion.SelectedValue.ToString() == "PD")
                    select = reporte3;
                else if (cboTipo_cancelacion.SelectedValue.ToString() == "DM")
                    select = reporte4;
                else if (cboTipo_cancelacion.SelectedValue.ToString() == "DR")
                    select = reporte5;
                else if (cboTipo_cancelacion.SelectedValue.ToString() == "PE")
                    select = reporte6;
                else if (cboTipo_cancelacion.SelectedValue.ToString() == "DE")
                    select = reporte7;
                else
                    select = reporte8;

                string dataSetName = "DataSet1";

                //>object[] reportParam = new object[] { titulo, cboPrograma.Text, periodo, cboPuntoCobranza.Text };
                DataTable dt = cambioTipoPllaHistoricoBLL.ObtenerReportesContratosTodos(nroPlanilla, cboTipo_cancelacion.SelectedValue.ToString(), cboprogramas.SelectedValue.ToString());
                object[] reportParam = new object[] {  programa, tipoPlanilla,periodo, punto_cobranza, n_planilla };
                Form frm = GenericUtil.CreateReportForm(select, dataSetName, dt, reportParam);
                frm.Show();


            }
            else
            {
                _ = MessageBox.Show("Seleccione un registro válida");
            }
        }
    }
}
