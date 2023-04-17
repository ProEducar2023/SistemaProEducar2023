using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using BLL;
using static Presentacion.HELPERS.FormatDataGridViewColumns;

namespace Presentacion.MOD_FACT_VTA.MOD_VTA
{
    public partial class FrmVerRetenciones : Form
    {
        private readonly ChequeBLL BLCheque;
        private readonly string nroDocumento;
        public FrmVerRetenciones(string nroDocumento)
        {
            InitializeComponent();
            BLCheque = new ChequeBLL();

            this.nroDocumento = nroDocumento;
        }

        private void FrmVerRetenciones_Load(object sender, EventArgs e)
        {
            ListarRetenciones();
            FormatColumns();
        }

        private void ListarRetenciones()
        {
            DataTable dt = BLCheque.ObtenerRetencionesDeUnDocumento(nroDocumento);
            dgvRetenciones.DataSource = dt;
        }

        private void FormatColumns()
        {
            InvisibleColumnas();
            SizeWithColumns();
            NameColumnChanged();

            dgvRetenciones.AlingHeaderTextCenter();
        }

        private void InvisibleColumnas()
        {
            InvisibleColumna(dgvRetenciones, "ID_SEGUIMIENTO");
            InvisibleColumna(dgvRetenciones, "ID_RENTENCION");
            InvisibleColumna(dgvRetenciones, "COD_PTO_COB");
            InvisibleColumna(dgvRetenciones, "TIPO_PLANILLA_DOC");
        }

        private void SizeWithColumns()
        {
            dgvRetenciones.Columns["DESC_PTO_COB"].Width = 240;
            dgvRetenciones.Columns["NRO_PLANILLA"].Width = 80;
            dgvRetenciones.Columns["NRO_PLANILLA_DOC"].Width = 80;
            dgvRetenciones.Columns["NRO_PLANILLA_COB"].Width = 80;
            dgvRetenciones.Columns["PERIODO"].Width = 60;
            dgvRetenciones.Columns["DESC_TIPO"].Width = 140;
            dgvRetenciones.Columns["COD_PER"].Width = 50;
            dgvRetenciones.Columns["DESC_PER"].Width = 220;
            dgvRetenciones.Columns["IMP_INI"].Width = 50;
            dgvRetenciones.Columns["IMP_RETENIDO"].Width = 50;
        }

        private void NameColumnChanged()
        {
            dgvRetenciones.Columns["DESC_PTO_COB"].HeaderText = "Pto. Cobranza";
            dgvRetenciones.Columns["NRO_PLANILLA"].HeaderText = "N° Plla";
            dgvRetenciones.Columns["NRO_PLANILLA_DOC"].HeaderText = "N°Plla.Ret";
            dgvRetenciones.Columns["NRO_PLANILLA_COB"].HeaderText = "N° Document";
            dgvRetenciones.Columns["DESC_TIPO"].HeaderText = "Tipo Planilla";
            dgvRetenciones.Columns["PERIODO"].HeaderText = "Periodo";
            dgvRetenciones.Columns["COD_PER"].HeaderText = "Codigo";
            dgvRetenciones.Columns["DESC_PER"].HeaderText = "Cliente";
            dgvRetenciones.Columns["IMP_INI"].HeaderText = "Imp.Ini";
            dgvRetenciones.Columns["IMP_RETENIDO"].HeaderText = "Imp.Ret";
        }
    }
}
