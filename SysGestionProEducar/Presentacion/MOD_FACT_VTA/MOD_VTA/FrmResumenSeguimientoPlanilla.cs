using BLL;
using SysSeguimiento;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Presentacion.MOD_FACT_VTA.MOD_VTA.Reportes.FormularioRep;
using static Presentacion.HELPERS.FormatDataGridViewColumns;
using static Entidades.ConstClass;
using static Presentacion.HELPERS.GenericMethod;
using static Presentacion.HELPERS.GenericUtil;
using static Presentacion.HELPERS.AppearanceUtil;
using System.Linq;

namespace Presentacion.MOD_FACT_VTA.MOD_VTA
{
    public partial class FrmResumenSeguimientoPlanilla : Form
    {
        private readonly SeguimientoPlanillasBLL BLSeguimiento;
        private readonly ChequeBLL BLCheque;

        private static string AÑO, MES;
        private const string NAME_ENVIO = "ENVIO";
        private const string NAME_RECEPCION = "RECEPCION";
        private const string TEXT_RECEPCION = "RECEPCIÓN";
        private const string NAME_LISTADO = "LISTADO";
        private const string NAME_EJECUTADO = "EJECUTADO";
        private const string NAME_PROCESO = "PROCESO";
        private readonly CultureInfo culture = CultureInfo.CreateSpecificCulture("en-CA");

        private bool accColor = false;

        public FrmResumenSeguimientoPlanilla(string año, string mes)
        {
            InitializeComponent();
            BLSeguimiento = new SeguimientoPlanillasBLL();
            BLCheque = new ChequeBLL();
            AÑO = año;
            MES = mes;
        }

        private void FrmResumenSeguimientoPlanilla_Load(object sender, EventArgs e)
        {
            StartCotrols();
            CargarMes();
            FormatDataGridView();
            FormatDataGridView2();
            StyleHeaderDataGridView();
            StyleHeaderDataGridView2();
        }

        private void StartCotrols()
        {
            numAño.DecimalPlaces = 0;
            numAño.Maximum = decimal.MaxValue;
            numAño2.DecimalPlaces = 0;
            numAño2.Maximum = decimal.MaxValue;
            cboMes.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMes2.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void CargarMes()
        {
            var mes = new[]
            {
                new { value = "01", name = "ENERO" },
                new { value = "02", name = "FEBRERO" },
                new { value = "03", name = "MARZO" },
                new { value = "04", name = "ABRIL" },
                new { value = "05", name = "MAYO" },
                new { value = "06", name = "JUNIO" },
                new { value = "07", name = "JULIO" },
                new { value = "08", name = "AGOSTO" },
                new { value = "09", name = "SEPTIEMBRE" },
                new { value = "10", name = "OCTUBRE" },
                new { value = "11", name = "NOVIEMBRE" },
                new { value = "12", name = "DICIEMBRE" }
            };

            cboMes.DataSource = mes;
            cboMes.DisplayMember = "name";
            cboMes.ValueMember = "value";
            cboMes.SelectedValue = MES;

            cboMes2.DataSource = mes;
            cboMes2.DisplayMember = "name";
            cboMes2.ValueMember = "value";
            cboMes2.SelectedValue = MES;

            numAño.Value = Convert.ToInt32(AÑO);
            numAño2.Value = Convert.ToInt32(AÑO);
        }

        private void ResumenSeguimientoPlanilla()
        {
            dgvResumenSeguiPlla.DataSource = BLSeguimiento.ResumenSeguimientoPlanilla(numAño.Value.ToString(), cboMes.SelectedValue.ToString(), EmpresaSistema.CodPais);
        }

        private void ResumenSeguimientoCheque()
        {
            accColor = false;
            DataTable dt = BLCheque.ResumenSeguimientoCheque(numAño2.Value.ToString(), cboMes2.SelectedValue.ToString(), EmpresaSistema.CodPais);
            dgvResumenSeguiCheque.AddRangeColumnsDataGridView(dt, false);
            dgvResumenSeguiCheque.AddRowsAndTotalesDataGridView(dt, "NRO_PLLA_ENV", "DESC_PTO_COB", "TOTALES");
            accColor = true;
            if (dgvResumenSeguiCheque.Rows.Count == 1)
                dgvResumenSeguiCheque.Rows.Clear();
        }


        private void SizeWithColumnsGridView()
        {
            dgvResumenSeguiPlla.Columns["Desc_dep"].Width = 100;
            dgvResumenSeguiPlla.Columns["DESC_PTO_COB"].Width = 140;
            dgvResumenSeguiPlla.Columns["PERIODO"].Width = 60;
            dgvResumenSeguiPlla.Columns["NRO_PLANILLA_COB"].Width = 80;
            dgvResumenSeguiPlla.Columns["IMP_ENVIO"].Width = 80;
            dgvResumenSeguiPlla.Columns["ENVIO"].Width = 50;
            dgvResumenSeguiPlla.Columns["RECEPCION"].Width = 50;
            dgvResumenSeguiPlla.Columns["PROCESO"].Width = 50;
            dgvResumenSeguiPlla.Columns["LISTADO"].Width = 50;
            dgvResumenSeguiPlla.Columns["IMPORTE_EJECUTADO"].Width = 70;
            dgvResumenSeguiPlla.Columns["EJECUTADO"].Width = 50;
            dgvResumenSeguiPlla.Columns["IMP_NETO"].Width = 80;
            dgvResumenSeguiPlla.Columns["IMP_CASILLERO"].Width = 70;
            dgvResumenSeguiPlla.Columns["IMPORTE_RETENIDO"].Width = 80;
            dgvResumenSeguiPlla.Columns["X_COBRAR_ENTIDAD"].Width = 85;
            dgvResumenSeguiPlla.Columns["COBRADO_ENTIDAD"].Width = 70;
            dgvResumenSeguiPlla.Columns["SALDO_COBRAR_ENTIDAD"].Width = 80;
            dgvResumenSeguiPlla.Columns["EXCESO_COBRANZA"].Width = 75;
            dgvResumenSeguiPlla.Columns["IMPORTE_APLICADO_ENV"].Width = 70;
            dgvResumenSeguiPlla.Columns["IMPORTE_APLICADO_REC"].Width = 70;
            dgvResumenSeguiPlla.Columns["IMPORTE_REEMBOLSO"].Width = 75;
            dgvResumenSeguiPlla.Columns["SALDO_FINAL"].Width = 70;
            dgvResumenSeguiPlla.Columns["IMPORTE_AJUSTE"].Width = 60;
        }

        private void SizeWithColumnsGridView2()
        {
            dgvResumenSeguiCheque.Columns["#"].Width = 30;
            dgvResumenSeguiCheque.Columns["CAB_GRUPO"].Width = 50;
            dgvResumenSeguiCheque.Columns["DESC_DEP"].Width = 100;
            dgvResumenSeguiCheque.Columns["ENT_PAG_CHEQ"].Width = 50;
            dgvResumenSeguiCheque.Columns["DESC_PTO_COB"].Width = 140;
            dgvResumenSeguiCheque.Columns["IMP_ENVIO"].Width = 80;
            dgvResumenSeguiCheque.Columns["FECHA_ENVIO"].Width = 70;
            dgvResumenSeguiCheque.Columns["NRO_PLANILLA"].Width = 80;
            dgvResumenSeguiCheque.Columns["NRO_PLLA_ENV"].Width = 80;
            dgvResumenSeguiCheque.Columns["IMPORTE_EJECUTADO"].Width = 70;
            dgvResumenSeguiCheque.Columns["IMPORTE_CASILLERO"].Width = 70;
            dgvResumenSeguiCheque.Columns["IMPORTE_RETENIDO"].Width = 70;
            dgvResumenSeguiCheque.Columns["IMPORTE_AJUSTE"].Width = 70;
            dgvResumenSeguiCheque.Columns["XCOBRAR_ENTIDAD"].Width = 80;
            dgvResumenSeguiCheque.Columns["COBRADO_ENTIDAD"].Width = 75;
            dgvResumenSeguiCheque.Columns["SALDO_X_COBRAR"].Width = 70;
            dgvResumenSeguiCheque.Columns["IMPORTE_EXC_INI"].Width = 70;
            dgvResumenSeguiCheque.Columns["FECHA_ENVIO_CHE"].Width = 70;
            dgvResumenSeguiCheque.Columns["EMPRESA_ENVIO_CHE"].Width = 90;
            dgvResumenSeguiCheque.Columns["IMPORTE_ENVIO_CHE"].Width = 70;
            dgvResumenSeguiCheque.Columns["FECHA_RECEP_CHE"].Width = 70;
            dgvResumenSeguiCheque.Columns["RESPONSABLE_RECEP_CHE"].Width = 120;
            dgvResumenSeguiCheque.Columns["IMPORTE_RECEP_CHE"].Width = 70;
            dgvResumenSeguiCheque.Columns["FECHA_DEPOS_CHE"].Width = 70;
            dgvResumenSeguiCheque.Columns["IMPORTE_DEPOS_CHE"].Width = 70;
            dgvResumenSeguiCheque.Columns["FECHA_TRANS_CHE"].Width = 70;
            dgvResumenSeguiCheque.Columns["IMPORTE_TRANS_CHE"].Width = 70;
            dgvResumenSeguiCheque.Columns["FECHA_VERIF_CHE"].Width = 70;
            dgvResumenSeguiCheque.Columns["IMPORTE_VERIF_CHE"].Width = 70;
            dgvResumenSeguiCheque.Columns["BANCO_ORIG_TRANS_CHE"].Width = 120;
            dgvResumenSeguiCheque.Columns["NRO_DOCUMENTO_APL_ENV"].Width = 75;
            dgvResumenSeguiCheque.Columns["FECHA_APL_ENV"].Width = 70;
            dgvResumenSeguiCheque.Columns["NRO_PLANILLA_ENV"].Width = 75;
            dgvResumenSeguiCheque.Columns["IMPORTE_APL_ENV"].Width = 70;
            dgvResumenSeguiCheque.Columns["IMPORTE_EXC_ENV"].Width = 70;
            dgvResumenSeguiCheque.Columns["NRO_DOCUMENTO_APL_REC"].Width = 75;
            dgvResumenSeguiCheque.Columns["FECHA_APL_REC"].Width = 70;
            dgvResumenSeguiCheque.Columns["NRO_PLANILLA_APL_REC"].Width = 75;
            dgvResumenSeguiCheque.Columns["IMPORTE_APL_REC"].Width = 70;
            dgvResumenSeguiCheque.Columns["SALDO_X_COBRAR_REC"].Width = 70;
        }

        private void RenameColumnsDataGridView()
        {
            dgvResumenSeguiPlla.Columns["DESC_DEP"].HeaderText = "DEPARTAMENTO";
            dgvResumenSeguiPlla.Columns["DESC_PTO_COB"].HeaderText = "PUNTO COBRANZA";
            dgvResumenSeguiPlla.Columns["NRO_PLANILLA_COB"].HeaderText = "N° PLLA";
            dgvResumenSeguiPlla.Columns["NRO_PLLA_ENV"].HeaderText = "N° PLLA ENV";
            dgvResumenSeguiPlla.Columns["IMP_ENVIO"].HeaderText = "IMP PLLA";
            dgvResumenSeguiPlla.Columns["IMP_NETO"].HeaderText = "NETO A COBRAR";
            dgvResumenSeguiPlla.Columns["IMPORTE_EJECUTADO"].HeaderText = "IMP.EJEC";
            dgvResumenSeguiPlla.Columns["IMP_CASILLERO"].HeaderText = "IMP.CASILL";
            dgvResumenSeguiPlla.Columns["IMPORTE_RETENIDO"].HeaderText = "RET.ENT.CLI";
            dgvResumenSeguiPlla.Columns["X_COBRAR_ENTIDAD"].HeaderText = "X COBRAR ENTIDAD";
            dgvResumenSeguiPlla.Columns["COBRADO_ENTIDAD"].HeaderText = "COBRADO ENTIDAD";
            dgvResumenSeguiPlla.Columns["SALDO_COBRAR_ENTIDAD"].HeaderText = "SALDO X COBRAR";
            dgvResumenSeguiPlla.Columns["EXCESO_COBRANZA"].HeaderText = "EXCESO COBRANZA";
            dgvResumenSeguiPlla.Columns["IMPORTE_APLICADO_ENV"].HeaderText = "APLIC.ENV";
            dgvResumenSeguiPlla.Columns["IMPORTE_APLICADO_REC"].HeaderText = "APLIC.REC";
            dgvResumenSeguiPlla.Columns["IMPORTE_REEMBOLSO"].HeaderText = "REEMBOLSO";
            dgvResumenSeguiPlla.Columns["IMPORTE_AJUSTE"].HeaderText = "AJUSTE";
            dgvResumenSeguiPlla.Columns["ENVIO"].HeaderText = "ENV";
            dgvResumenSeguiPlla.Columns["RECEPCION"].HeaderText = "RECEP";
            dgvResumenSeguiPlla.Columns["PROCESO"].HeaderText = "PROCES";
            dgvResumenSeguiPlla.Columns["LISTADO"].HeaderText = "LIST";
            dgvResumenSeguiPlla.Columns["EJECUTADO"].HeaderText = "EJEC";
        }

        private void RenameColumnsDataGridView2()
        {
            dgvResumenSeguiCheque.Columns["CAB_GRUPO"].HeaderText = "Punto Envío";
            dgvResumenSeguiCheque.Columns["ENT_PAG_CHEQ"].HeaderText = "PAGO CHEQUE";
            dgvResumenSeguiCheque.Columns["DESC_DEP"].HeaderText = "DEPARTAMENTO";
            dgvResumenSeguiCheque.Columns["DESC_PTO_COB"].HeaderText = "Pto COBRANZA";
            dgvResumenSeguiCheque.Columns["IMP_ENVIO"].HeaderText = "IMPORTE ENVIO";
            dgvResumenSeguiCheque.Columns["FECHA_ENVIO"].HeaderText = "FECHA PLLA";
            dgvResumenSeguiCheque.Columns["NRO_PLANILLA"].HeaderText = "N° PLLA GENERADA";
            dgvResumenSeguiCheque.Columns["NRO_PLLA_ENV"].HeaderText = "N° PLLA ENVIADA";
            dgvResumenSeguiCheque.Columns["IMPORTE_EJECUTADO"].HeaderText = "IMPORTE EJECUTADO";
            dgvResumenSeguiCheque.Columns["IMPORTE_CASILLERO"].HeaderText = "IMPORTE CASILL";
            dgvResumenSeguiCheque.Columns["IMPORTE_RETENIDO"].HeaderText = "RETEN.ENT CLIENTE";
            dgvResumenSeguiCheque.Columns["IMPORTE_AJUSTE"].HeaderText = "IMPORTE AJUSTE";
            dgvResumenSeguiCheque.Columns["XCOBRAR_ENTIDAD"].HeaderText = "X COBRAR ENTIDAD";
            dgvResumenSeguiCheque.Columns["COBRADO_ENTIDAD"].HeaderText = "COBRADO ENTIDAD";
            dgvResumenSeguiCheque.Columns["SALDO_X_COBRAR"].HeaderText = "SALDO X COBRAR";
            dgvResumenSeguiCheque.Columns["IMPORTE_EXC_INI"].HeaderText = "EXCESO COBRANZA";
            dgvResumenSeguiCheque.Columns["FECHA_ENVIO_CHE"].HeaderText = "FEC.ENV CHEQUE";
            dgvResumenSeguiCheque.Columns["EMPRESA_ENVIO_CHE"].HeaderText = "EMPRESA.ENV CHEQUE";
            dgvResumenSeguiCheque.Columns["IMPORTE_ENVIO_CHE"].HeaderText = "IMP.ENV CHEQUE";
            dgvResumenSeguiCheque.Columns["FECHA_RECEP_CHE"].HeaderText = "FEC.RECEP CHEQUE";
            dgvResumenSeguiCheque.Columns["RESPONSABLE_RECEP_CHE"].HeaderText = "RECIBIDO POR";
            dgvResumenSeguiCheque.Columns["IMPORTE_RECEP_CHE"].HeaderText = "IMP.RECEP CHEQUE";
            dgvResumenSeguiCheque.Columns["FECHA_DEPOS_CHE"].HeaderText = "FEC.DEPOS CHEQUE";
            dgvResumenSeguiCheque.Columns["IMPORTE_DEPOS_CHE"].HeaderText = "IMP.DEPOS CHEQUE";
            dgvResumenSeguiCheque.Columns["FECHA_TRANS_CHE"].HeaderText = "FEC.TRANS";
            dgvResumenSeguiCheque.Columns["IMPORTE_TRANS_CHE"].HeaderText = "IMP.TRANS";
            dgvResumenSeguiCheque.Columns["FECHA_VERIF_CHE"].HeaderText = "FECHA VERIF";
            dgvResumenSeguiCheque.Columns["IMPORTE_VERIF_CHE"].HeaderText = "IMPORTE VERIF";
            dgvResumenSeguiCheque.Columns["BANCO_ORIG_TRANS_CHE"].HeaderText = "BANCO ORIGEN TRANS";
            dgvResumenSeguiCheque.Columns["NRO_DOCUMENTO_APL_ENV"].HeaderText = "N° PLLA APL";
            dgvResumenSeguiCheque.Columns["FECHA_APL_ENV"].HeaderText = "FECHA APL";
            dgvResumenSeguiCheque.Columns["NRO_PLANILLA_ENV"].HeaderText = "N° PLLA DESTINO";
            dgvResumenSeguiCheque.Columns["IMPORTE_APL_ENV"].HeaderText = "IMPORTE APL";
            dgvResumenSeguiCheque.Columns["IMPORTE_EXC_ENV"].HeaderText = "SALDO EXCESO";
            dgvResumenSeguiCheque.Columns["NRO_DOCUMENTO_APL_REC"].HeaderText = "N° PLLA APL";
            dgvResumenSeguiCheque.Columns["FECHA_APL_REC"].HeaderText = "FECHA APL";
            dgvResumenSeguiCheque.Columns["NRO_PLANILLA_APL_REC"].HeaderText = "N° PLLA ORIGEN";
            dgvResumenSeguiCheque.Columns["IMPORTE_APL_REC"].HeaderText = "IMPORTE APL";
            dgvResumenSeguiCheque.Columns["SALDO_X_COBRAR_REC"].HeaderText = "SALDO X COBRAR";
        }

        private void InvisibleColumns()
        {
            dgvResumenSeguiPlla.Columns["ID_SEGUIMIENTO"].Visible = false;
            dgvResumenSeguiPlla.Columns["COD_DEP"].Visible = false;
            dgvResumenSeguiPlla.Columns["COD_PTO_COB"].Visible = false;
            dgvResumenSeguiPlla.Columns["FEC_RETOR_PLAN"].Visible = false;
            dgvResumenSeguiPlla.Columns["IMP_DESCUENTO"].Visible = false;
            dgvResumenSeguiPlla.Columns["IMP_LISTADO"].Visible = false;
            dgvResumenSeguiPlla.Columns["PORCENTAJE_CASILLERO"].Visible = false;
            dgvResumenSeguiPlla.Columns["OTROS_DSCTOS"].Visible = false;
        }

        private void InvisibleColumns2()
        {
            dgvResumenSeguiCheque.Columns["COD_PTO_COB"].Visible = false;
        }

        private void StyleHeaderDataGridView()
        {
            Color backColor1 = BackColorColumn;
            Color foreColor1 = ForeColorColumnDefault;
            Color backColor2 = BackColorColumnPrimary;
            Color foreColor2 = ForeColorColumnPrimary;
            int[] arrIndexColumns = { 13, 26 };
            dgvResumenSeguiPlla.ColorCabeceraDataGridView(arrIndexColumns, backColor1, foreColor1, backColor2, foreColor2);
        }

        private void StyleHeaderDataGridView2()
        {
            Color backColor1 = BackColorColumn;
            Color foreColor1 = ForeColorColumnDefault;
            Color backColor2 = BackColorColumnPrimary;
            Color foreColor2 = ForeColorColumnPrimary;
            int[] arrIndexColumns = { 9, 17, 20, 23, 25, 28, 30, 35 };
            dgvResumenSeguiCheque.ColorCabeceraDataGridView(arrIndexColumns, backColor1, foreColor1, backColor2, foreColor2);
        }

        private void FormatDataGridView()
        {
            dgvResumenSeguiPlla.EnableHeadersVisualStyles = false;
            dgvResumenSeguiPlla.Columns["NRO_PLANILLA_COB"].Frozen = true;
            dgvResumenSeguiPlla.AlignmentTextContent2("PERIODO", DataGridViewContentAlignment.MiddleCenter);
            dgvResumenSeguiPlla.AlignmentTextContent2("ENVIO", DataGridViewContentAlignment.MiddleCenter);
            dgvResumenSeguiPlla.AlignmentTextContent2("RECEPCION", DataGridViewContentAlignment.MiddleCenter);
            dgvResumenSeguiPlla.AlignmentTextContent2("PROCESO", DataGridViewContentAlignment.MiddleCenter);
            dgvResumenSeguiPlla.AlignmentTextContent2("LISTADO", DataGridViewContentAlignment.MiddleCenter);
            dgvResumenSeguiPlla.AlignmentTextContent2("EJECUTADO", DataGridViewContentAlignment.MiddleCenter);
            dgvResumenSeguiPlla.AlignmentTextContent2("NRO_PLANILLA_COB", DataGridViewContentAlignment.MiddleCenter);
            dgvResumenSeguiPlla.AlignmentTextContent2("NRO_PLLA_ENV", DataGridViewContentAlignment.MiddleCenter);
            dgvResumenSeguiPlla.AlignmentTextContent2("IMP_ENVIO", DataGridViewContentAlignment.MiddleRight);
            dgvResumenSeguiPlla.AlignmentTextContent2("IMP_NETO", DataGridViewContentAlignment.MiddleRight);
            dgvResumenSeguiPlla.AlignmentTextContent2("IMPORTE_EJECUTADO", DataGridViewContentAlignment.MiddleRight);
            dgvResumenSeguiPlla.AlignmentTextContent2("IMP_CASILLERO", DataGridViewContentAlignment.MiddleRight);
            dgvResumenSeguiPlla.AlignmentTextContent2("IMPORTE_RETENIDO", DataGridViewContentAlignment.MiddleRight);
            dgvResumenSeguiPlla.AlignmentTextContent2("X_COBRAR_ENTIDAD", DataGridViewContentAlignment.MiddleRight);
            dgvResumenSeguiPlla.AlignmentTextContent2("COBRADO_ENTIDAD", DataGridViewContentAlignment.MiddleRight);
            dgvResumenSeguiPlla.AlignmentTextContent2("IMPORTE_AJUSTE", DataGridViewContentAlignment.MiddleRight);

            RenameColumnsDataGridView();
            InvisibleColumns();
            SizeWithColumnsGridView();
            dgvResumenSeguiPlla.AlingHeaderTextCenter();
            dgvResumenSeguiPlla.Style4(false, false, false, false, false, false, DataGridViewTriState.True, DataGridViewColumnHeadersHeightSizeMode.AutoSize, DataGridViewTriState.False, DataGridViewAutoSizeRowsMode.None, Color.Blue, Color.White, DataGridViewSelectionMode.CellSelect);
            //> dgvResumen.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void FormatDataGridView2()
        {
            dgvResumenSeguiCheque.Columns["NRO_PLLA_ENV"].Frozen = true;
            dgvResumenSeguiCheque.FormatColumnasFecha("FECHA_ENVIO");
            dgvResumenSeguiCheque.FormatColumnasFecha("FECHA_ENVIO_CHE");
            dgvResumenSeguiCheque.FormatColumnasFecha("FECHA_RECEP_CHE");
            dgvResumenSeguiCheque.FormatColumnasFecha("FECHA_DEPOS_CHE");
            dgvResumenSeguiCheque.FormatColumnasFecha("FECHA_TRANS_CHE");
            dgvResumenSeguiCheque.FormatColumnasFecha("FECHA_VERIF_CHE");
            dgvResumenSeguiCheque.FormatColumnasFecha("FECHA_APL_ENV");
            dgvResumenSeguiCheque.FormatColumnasFecha("FECHA_APL_REC");

            dgvResumenSeguiCheque.AlignmentDecimalColumns();

            dgvResumenSeguiCheque.AlingHeaderTextCenter();
            dgvResumenSeguiCheque.Style5(false, false, false, false, false, DataGridViewTriState.True, DataGridViewColumnHeadersHeightSizeMode.AutoSize,
                DataGridViewTriState.True, DataGridViewAutoSizeRowsMode.AllCells, DataGridViewSelectionMode.FullRowSelect);
            dgvResumenSeguiCheque.NotSort();
            RenameColumnsDataGridView2();
            SizeWithColumnsGridView2();
            InvisibleColumns2();
        }

        private void CboMes_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ResumenSeguimientoPlanilla();
        }

        private void NumAño_ValueChanged(object sender, EventArgs e)
        {
            ResumenSeguimientoPlanilla();
        }

        private void NumAño2_ValueChanged(object sender, EventArgs e)
        {
            ResumenSeguimientoCheque();
        }

        private void CboMes2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ResumenSeguimientoCheque();
        }

        private void DgvResumen_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {

        }

        private void DgvResumen_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvResumenSeguiPlla.CurrentCell != null)
            {
                if (dgvResumenSeguiPlla.Columns[e.ColumnIndex].Name == NAME_ENVIO)
                    Enviada();
                else if (dgvResumenSeguiPlla.Columns[e.ColumnIndex].Name == NAME_RECEPCION)
                    Recepcion();
                else if (dgvResumenSeguiPlla.Columns[e.ColumnIndex].Name == NAME_PROCESO)
                    Proceso();
                else if (dgvResumenSeguiPlla.Columns[e.ColumnIndex].Name == NAME_LISTADO)
                    Listado();
                else if (dgvResumenSeguiPlla.Columns[e.ColumnIndex].Name == NAME_EJECUTADO)
                    Ejecutado();
            }
        }

        private void Enviada()
        {
            string estado = NAME_ENVIO;
            DataTable dtPlanilla = ObtenerPlanilla();
            MantenedorEnvioPlanillas envio = new MantenedorEnvioPlanillas(estado, dtPlanilla)
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            envio.NombrePuntoCobranza = dgvResumenSeguiPlla.CurrentRow.Cells["DESC_PTO_COB"].Value.ToString();
            envio.EnabledButtons(true, 1);
            envio.Size = new Size { Height = envio.Height, Width = 871 };
            _ = envio.ShowDialog();
        }

        private void Recepcion()
        {
            string estado = TEXT_RECEPCION;
            DataTable dtPlanilla = ObtenerPlanilla();
            MantenedorRecepcionPlanilla recepcion = new MantenedorRecepcionPlanilla(estado, dtPlanilla)
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            recepcion.EnabledButtons(true);
            recepcion.NombrePuntoCobranza = dgvResumenSeguiPlla.CurrentRow.Cells["DESC_PTO_COB"].Value.ToString();
            recepcion.Size = new Size { Height = recepcion.Size.Height, Width = 847 };
            _ = recepcion.ShowDialog();
        }

        private DataTable ObtenerPlanilla()
        {
            DataTable dtPlanilla = new DataTable();
            _ = dtPlanilla.Columns.Add("ID_SEGUIMIENTO", typeof(string));
            _ = dtPlanilla.Columns.Add("NRO_PLANILLA_COB", typeof(string));
            _ = dtPlanilla.Columns.Add("COD_PTO_COB_CONSOLIDADO", typeof(string)); ;

            DataRow row = dtPlanilla.NewRow();
            row["ID_SEGUIMIENTO"] = dgvResumenSeguiPlla.CurrentRow.Cells["ID_SEGUIMIENTO"].Value;
            row["NRO_PLANILLA_COB"] = dgvResumenSeguiPlla.CurrentRow.Cells["NRO_PLANILLA_COB"].Value;
            row["COD_PTO_COB_CONSOLIDADO"] = dgvResumenSeguiPlla.CurrentRow.Cells["COD_PTO_COB"].Value;

            dtPlanilla.Rows.Add(row);
            return dtPlanilla;
        }

        private void Proceso()
        {
            string estadoText = NAME_PROCESO;
            string titulo = "Resultado Llamada";
            int idOption = 7;
            int idEstado = PROCESADA;
            int idSeguimiento = Convert.ToInt32(dgvResumenSeguiPlla.CurrentRow.Cells["ID_SEGUIMIENTO"].Value);
            string nroPlanilla = dgvResumenSeguiPlla.CurrentRow.Cells["NRO_PLANILLA_COB"].Value.ToString();
            string nombrePuntoCobranza = dgvResumenSeguiPlla.CurrentRow.Cells["DESC_PTO_COB"].Value.ToString();
            int idLlamada = 0;
            DataTable dt = BLSeguimiento.ObtenerUltimaLlamada(idSeguimiento, PROCESADA);
            if (dt.Rows.Count > 0)
                idLlamada = Convert.ToInt32(dt.Rows[0]["ID_LLAMADA"]);
            ProgramarLlamada llamada = new ProgramarLlamada(idOption, titulo, idSeguimiento, idEstado, nroPlanilla, nombrePuntoCobranza, estadoText, idLlamada)
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            llamada.EnabledButtons(true);
            _ = llamada.ShowDialog();
        }

        private void Listado()
        {
            string estadoText = NAME_LISTADO;
            string titulo = "Resultado Llamada";
            int idOption = 7;
            int idEstado = DESCONTADA_CERRADA;
            int idSeguimiento = Convert.ToInt32(dgvResumenSeguiPlla.CurrentRow.Cells["ID_SEGUIMIENTO"].Value);
            string nroPlanilla = dgvResumenSeguiPlla.CurrentRow.Cells["NRO_PLANILLA_COB"].Value.ToString();
            string nombrePuntoCobranza = dgvResumenSeguiPlla.CurrentRow.Cells["DESC_PTO_COB"].Value.ToString();
            int idLlamada = 0;
            DataTable dt = BLSeguimiento.ObtenerUltimaLlamada(idSeguimiento, DESCONTADA_CERRADA);
            if (dt.Rows.Count > 0)
                idLlamada = Convert.ToInt32(dt.Rows[0]["ID_LLAMADA"]);
            ProgramarLlamada llamada = new ProgramarLlamada(idOption, titulo, idSeguimiento, idEstado, nroPlanilla, nombrePuntoCobranza, estadoText, idLlamada)
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            llamada.EnabledButtons(true);
            llamada.numEnvio.Value = Convert.ToDecimal(dgvResumenSeguiPlla.CurrentRow.Cells["IMP_ENVIO"].Value, culture);
            llamada.numImporte.Value = Convert.ToDecimal(string.IsNullOrEmpty(dgvResumenSeguiPlla.CurrentRow.Cells["IMP_DESCUENTO"].Value?.ToString()) ? 0 : dgvResumenSeguiPlla.CurrentRow.Cells["IMP_DESCUENTO"].Value, culture);
            llamada.numImpListado.Value = Convert.ToDecimal(string.IsNullOrEmpty(dgvResumenSeguiPlla.CurrentRow.Cells["IMP_LISTADO"].Value?.ToString()) ? 0 : dgvResumenSeguiPlla.CurrentRow.Cells["IMP_LISTADO"].Value, culture);
            llamada.label21.Text = string.IsNullOrEmpty(dgvResumenSeguiPlla.CurrentRow.Cells["PORCENTAJE_CASILLERO"].Value?.ToString()) ? llamada.label21.Text : "Casillero Auto. " + dgvResumenSeguiPlla.CurrentRow.Cells["PORCENTAJE_CASILLERO"].Value.ToString() + "% :";
            llamada.numImpCasilleroAuto.Value = Convert.ToDecimal(string.IsNullOrEmpty(dgvResumenSeguiPlla.CurrentRow.Cells["IMP_CASILLERO"].Value?.ToString()) ? 0 : dgvResumenSeguiPlla.CurrentRow.Cells["IMP_CASILLERO"].Value, culture);
            llamada.numOtrosDescto.Value = Convert.ToDecimal(string.IsNullOrEmpty(dgvResumenSeguiPlla.CurrentRow.Cells["OTROS_DSCTOS"].Value?.ToString()) ? 0 : dgvResumenSeguiPlla.CurrentRow.Cells["OTROS_DSCTOS"].Value, culture);
            llamada.numImpNeto.Value = 0;
            llamada.btnImporteListado.Tag = 0;
            llamada.Ejecutado = true;
            llamada.chkNoSal.Checked = true;
            llamada.numImpListado.ReadOnly = true;
            llamada.numImpCasilleroAuto.ReadOnly = true;
            llamada.numOtrosDescto.ReadOnly = true;
            llamada.dtFechaTrans.Checked = true;
            llamada.dtFechaTrans.Value = Convert.ToDateTime(dgvResumenSeguiPlla.CurrentRow.Cells["FEC_RETOR_PLAN"].Value);
            _ = llamada.ShowDialog();
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            FrmRptResumenSeguimientoPlanillas frm = new FrmRptResumenSeguimientoPlanillas(numAño.Value.ToString(), cboMes.SelectedValue.ToString(), true)
            {
                StartPosition = FormStartPosition.CenterParent,
            };
            _ = frm.ShowDialog();
        }

        private void BtnRptResumCheque_Click(object sender, EventArgs e)
        {
            FrmRptResumenSeguimientoPlanillas frm = new FrmRptResumenSeguimientoPlanillas(numAño2.Value.ToString(), cboMes2.SelectedValue.ToString(), false)
            {
                StartPosition = FormStartPosition.CenterParent,
            };
            _ = frm.ShowDialog();
        }

        private void DgvResumenSeguiCheque_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvResumenSeguiCheque.CurrentCell != null && accColor)
            {
                dgvResumenSeguiCheque.MantenerColorSeleccionado(Color.Blue);
            }
        }

        private void Ejecutado()
        {
            string estadoText = NAME_EJECUTADO;
            string titulo = "Resultado Llamada";
            int idOption = 7;
            int idEstado = DESCONTADA_CERRADA;
            int idSeguimiento = Convert.ToInt32(dgvResumenSeguiPlla.CurrentRow.Cells["ID_SEGUIMIENTO"].Value);
            string nroPlanilla = dgvResumenSeguiPlla.CurrentRow.Cells["NRO_PLANILLA_COB"].Value.ToString();
            string nombrePuntoCobranza = dgvResumenSeguiPlla.CurrentRow.Cells["DESC_PTO_COB"].Value.ToString();
            int idLlamada = 0;
            DataTable dt = BLSeguimiento.ObtenerUltimaLlamada(idSeguimiento, DESCONTADA_CERRADA);
            if (dt.Rows.Count > 0)
                idLlamada = Convert.ToInt32(dt.Rows[0]["ID_LLAMADA"]);
            ProgramarLlamada llamada = new ProgramarLlamada(idOption, titulo, idSeguimiento, idEstado, nroPlanilla, nombrePuntoCobranza, estadoText, idLlamada)
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            llamada.EnabledButtons(true);
            llamada.numEnvio.Value = Convert.ToDecimal(dgvResumenSeguiPlla.CurrentRow.Cells["IMP_ENVIO"].Value, culture);
            llamada.numImporte.Value = Convert.ToDecimal(string.IsNullOrEmpty(dgvResumenSeguiPlla.CurrentRow.Cells["IMP_DESCUENTO"].Value?.ToString()) ? 0 : dgvResumenSeguiPlla.CurrentRow.Cells["IMP_DESCUENTO"].Value, culture);
            llamada.numImpListado.Value = Convert.ToDecimal(string.IsNullOrEmpty(dgvResumenSeguiPlla.CurrentRow.Cells["IMP_LISTADO"].Value?.ToString()) ? 0 : dgvResumenSeguiPlla.CurrentRow.Cells["IMP_LISTADO"].Value, culture);
            llamada.label21.Text = string.IsNullOrEmpty(dgvResumenSeguiPlla.CurrentRow.Cells["PORCENTAJE_CASILLERO"].Value?.ToString()) ? llamada.label21.Text : "Casillero Auto. " + dgvResumenSeguiPlla.CurrentRow.Cells["PORCENTAJE_CASILLERO"].Value.ToString() + "% :";
            llamada.numImpCasilleroAuto.Value = Convert.ToDecimal(string.IsNullOrEmpty(dgvResumenSeguiPlla.CurrentRow.Cells["IMP_CASILLERO"].Value?.ToString()) ? 0 : dgvResumenSeguiPlla.CurrentRow.Cells["IMP_CASILLERO"].Value, culture);
            llamada.numOtrosDescto.Value = Convert.ToDecimal(string.IsNullOrEmpty(dgvResumenSeguiPlla.CurrentRow.Cells["OTROS_DSCTOS"].Value?.ToString()) ? 0 : dgvResumenSeguiPlla.CurrentRow.Cells["OTROS_DSCTOS"].Value, culture);
            llamada.numImpNeto.Value = Convert.ToDecimal(string.IsNullOrEmpty(dgvResumenSeguiPlla.CurrentRow.Cells["IMP_NETO"].Value?.ToString()) ? 0 : dgvResumenSeguiPlla.CurrentRow.Cells["IMP_NETO"].Value, culture);
            llamada.numImpEjec.Value = dgvResumenSeguiPlla.CurrentCell != null ? Convert.ToDecimal(dgvResumenSeguiPlla.CurrentRow.Cells["IMPORTE_EJECUTADO"].Value, culture) : 0;
            llamada.btnImporteListado.Tag = 0;
            llamada.numImpListado.ReadOnly = true;
            llamada.dtFechaTrans.Value = Convert.ToDateTime(dgvResumenSeguiPlla.CurrentRow.Cells["FEC_RETOR_PLAN"].Value);
            if (dgvResumenSeguiPlla.CurrentCell != null && !string.IsNullOrEmpty(dgvResumenSeguiPlla.CurrentRow.Cells["FEC_RETOR_PLAN"].Value?.ToString()))
            {
                llamada.dtFechaTrans.Checked = true;
                llamada.dtFechaTrans.Value = Convert.ToDateTime(dgvResumenSeguiPlla.CurrentRow.Cells["FEC_RETOR_PLAN"].Value);
            }
            llamada.btnImporteListado.Tag = 0;
            llamada.chkNoSal.Checked = true;
            llamada.numImpListado.ReadOnly = true;
            llamada.numImpCasilleroAuto.ReadOnly = true;
            llamada.numOtrosDescto.ReadOnly = true;
            llamada.ObtenerOtrosDsctos();
            _ = llamada.ShowDialog();
        }
    }
}
