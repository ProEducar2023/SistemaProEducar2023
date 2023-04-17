using System;
using Presentacion.HELPERS;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using BLL;

namespace Presentacion.MOD_CXC.Reportes.Formulario
{
    public partial class FrmListadoPlanillasParaContratos : Form
    {

        private readonly DataTable dt1;
        private readonly ComboBox cboTipo_cancelacion;
        private readonly ComboBox cboprogramas;
        private readonly DateTimePicker dtFECHA1;
        private readonly DateTimePicker dtFECHA2;

        private readonly cambioTipoPllaHistoricoBLL cambioTipoPllaHistoricoBLL = new cambioTipoPllaHistoricoBLL();

        public FrmListadoPlanillasParaContratos(DataTable dt, ComboBox cboTipo_cancelacion, ComboBox cboprogramas, DateTimePicker dtFECHA1, DateTimePicker dtFECHA2)
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
            txtCantidadPlanilla.Text = Convert.ToString(dgvPlanilla.Rows.Count);

            decimal importeTotal = 0;
            foreach (DataGridViewRow row in dgvPlanilla.Rows)
            {
                importeTotal += Convert.ToDecimal(row.Cells["IMP_DOC"].Value);
            }

            txtTotalPlanilla.Text = Convert.ToString(importeTotal);

            txtPeriodo.Text = Convert.ToString(dtFECHA1.Text);

            txtTipoPlanilla.Text = Convert.ToString(cboTipo_cancelacion.Text);

        }



        private void FormatColumns()
        {
            //REALIZAR LOS 3 PARA PODER MOTRAR EL NOMBRE Y POSICION DE UNA COLUMNA 
            dgvPlanilla.Columns["NRO_PLANILLA_COB"].HeaderText = "NRO DE PLANILLA";     //NOMBRE DE LA COLUMNA
            dgvPlanilla.Columns["NRO_PLANILLA_COB"].Width = 200;         //ANCHO  DE LA COLUMNA
            dgvPlanilla.Columns["NRO_PLANILLA_COB"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;  //POCICION DE LA COLUMNA


            dgvPlanilla.Columns["FECHA_PLANILLA_COB"].HeaderText = "FECHA DE PLANILLA";
            dgvPlanilla.Columns["FECHA_PLANILLA_COB"].Width = 200;
            dgvPlanilla.Columns["FECHA_PLANILLA_COB"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dgvPlanilla.Columns["IMP_DOC"].HeaderText = "IMPORTE DE PLANILLA";
            dgvPlanilla.Columns["IMP_DOC"].Width = 200;
            dgvPlanilla.Columns["IMP_DOC"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dgvPlanilla.Columns["DESC_PTO_COB"].HeaderText = "PUNTO DE COBRANZA";
            dgvPlanilla.Columns["DESC_PTO_COB"].Width = 250;
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

                string reporte = GenericUtil.ObtenerRutaReporteTareaje_MOD_CXC("Report6");
                string dataSetName = "DataSet1";

                //>object[] reportParam = new object[] { titulo, cboPrograma.Text, periodo, cboPuntoCobranza.Text };
                DataTable dt = cambioTipoPllaHistoricoBLL.ObtenerReportesContratos(nroPlanilla, cboTipo_cancelacion.SelectedValue.ToString(), cboprogramas.SelectedValue.ToString());
                object[] reportParam = new object[] { programa, tipoPlanilla, periodo, punto_cobranza, n_planilla };
                Form frm = GenericUtil.CreateReportForm(reporte, dataSetName, dt, reportParam);
                frm.Show();


            }
            else
            {
                _ = MessageBox.Show("Seleccione un registro válida");
            }
        }
    }
}
