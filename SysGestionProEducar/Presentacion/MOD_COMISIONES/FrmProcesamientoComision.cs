using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Presentacion.HELPERS.GenericMethod;
using static Presentacion.HELPERS.AppearanceUtil;
using static Presentacion.HELPERS.FormatDataGridViewColumns;
using static Presentacion.HELPERS.ErrorPrint;
using static Presentacion.HELPERS.GenericUtil;
using static Presentacion.HELPERS.Constantes;
using Presentacion.HELPERS.Forms;
using BLL;
using Entidades;
using System.Threading;

namespace Presentacion.MOD_COMISIONES
{
    public enum TIPO_BUSQUEDA
    {
        IGUAL = 0,
        LIKE = 1
    }

    public partial class FrmProcesamientoComision : Form
    {
        public FrmProcesamientoComision()
        {
            InitializeComponent();
        }

        private readonly comisionesBLL BLComision = new comisionesBLL();
        private readonly programaBLL BLPrograma = new programaBLL();
        private readonly tipoPlanillaCreacionBLL BLTipoPlanilla = new tipoPlanillaCreacionBLL();
        private readonly institucionesBLL BLInstitucion = new institucionesBLL();
        private readonly nivelBLL BLNivel = new nivelBLL();

        private string feAñoPer, feMesPer;
        private DateTime fechaAprobIni, fechaAprobFin;
        private DateTime fechaCobraIni, fechaCobraFin;
        private DataTable dtPeridoGenerado, dtContSinProces, dtContAprobados, dtContExcluidos;
        private ESTADO_COMISION estadoComision;

        private const string PERIODO_PROCESO_NINGUNO = "-";
        private const string chkText = "Select. Todo ({0})";
        private const string MENSAJE_PENDIENTE = "PENDIENTE POR GRABAR";

        private const string REGISTRO_AGREGADO = "A";
        private const string REGISTRO_GENERADO = null;

        private delegate void DelMostrarMensaje(DataTable dt, Label lblMessage, string mensaje, ESTADO_COMISION estadoComision);

        private void FrmProcesamientoComision_Load(object sender, EventArgs e)
        {
            StartControls();
            CargarPrograma();
            CagarInstitucion();
            CargarTipoVenta();
            CargarNroCuota();
            CargarMeses();
            CargarNivelVenta();
            CargarPeriodoGeneradoComision();
            MostrarPeriodoProceso();
        }

        private void StartControls()
        {
            dtFechaAprobIni.Value = new DateTime(2019, 1, 1);
            dtFechaAprobFin.Value = DateTime.Now;

            btnConsultarCtrats.StyleButtonFlat();
            btnGenerar.StyleButtonFlat();
            btnAgregarContrato.StyleButtonFlat();
            btnEliminarComisGen.StyleButtonFlat();
            btnAprobarComision.StyleButtonFlat();
            btnExcluirContratos.StyleButtonFlat();
            btnQuitarExcluidos.StyleButtonFlat(Color.Teal, Color.White, Color.Teal, Color.White, Color.Teal, 1);
            btnGenerarComExcluidos.StyleButtonFlat(Color.Teal, Color.White, Color.Teal, Color.White, Color.Teal, 1);
            btnRecalcularComision.StyleButtonFlat();
            btnPasarContrAPendientes.StyleButtonFlat();
            btnEliminarComision.StyleButtonFlat(Color.Teal, Color.White, Color.Teal, Color.White, Color.Teal, 1);
            btnEliminarComision2.StyleButtonFlat(Color.Teal, Color.White, Color.Teal, Color.White, Color.Teal, 1);


            FormatCombobox(cboPrograma);
            FormatCombobox(cboInstitucion);
            FormatCombobox(cboTipoVenta);
            FormatCombobox(cboNroCuota);
            FormatCombobox(cboMes);
            FormatCombobox(cboPeriodoGen);
            FormatCombobox(cboNivelVenta);

            dgvContSinProces.Style4(true, false, false, true, false, false, DataGridViewTriState.True, DataGridViewColumnHeadersHeightSizeMode.AutoSize, DataGridViewTriState.True, DataGridViewAutoSizeRowsMode.AllCells,
                Color.Blue, Color.White, DataGridViewSelectionMode.FullRowSelect);
            dgvContAprobados.Style4(true, false, false, true, false, false, DataGridViewTriState.True, DataGridViewColumnHeadersHeightSizeMode.AutoSize, DataGridViewTriState.True, DataGridViewAutoSizeRowsMode.AllCells,
                Color.Blue, Color.White, DataGridViewSelectionMode.FullRowSelect);
            dgvContExcluidos.Style4(true, false, false, true, false, false, DataGridViewTriState.True, DataGridViewColumnHeadersHeightSizeMode.AutoSize, DataGridViewTriState.True, DataGridViewAutoSizeRowsMode.AllCells,
                Color.Blue, Color.White, DataGridViewSelectionMode.FullRowSelect);
        }

        private void FormatCombobox(ComboBox comboBox)
        {
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void CargarPrograma()
        {
            DataTable dt = BLPrograma.obtenerProgramaBLL();
            cboPrograma.DataSource = dt;
            cboPrograma.DisplayMember = "DESC_PROGRAMA";
            cboPrograma.ValueMember = "COD_PROGRAMA";
        }

        private void CagarInstitucion()
        {
            DataTable dt = BLInstitucion.obtenerInstitucionesBLL();
            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow row = dt.NewRow();
                row["COD_INST"] = "00";
                row["DESC_INST"] = "Todos";
                dt.Rows.InsertAt(row, 0);

                cboInstitucion.DataSource = dt;
                cboInstitucion.ValueMember = "COD_INST";
                cboInstitucion.DisplayMember = "DESC_INST";
            }
        }

        private void CargarTipoVenta()
        {
            DataTable dt = BLTipoPlanilla.obtenerTipoPlanillaCreacionBLL().Select("COD_TIPO_PLLA IN('PP', 'PV')").CopyToDataTable();
            if (dt != null)
            {
                foreach (DataColumn column in dt.Columns)
                {
                    column.AllowDBNull = true;
                }
                DataRow row = dt.NewRow();
                row["COD_TIPO_PLLA"] = "00";
                row["DESC_TIPO"] = "Todos";
                dt.Rows.InsertAt(row, 0);

                cboTipoVenta.DataSource = dt;
                cboTipoVenta.ValueMember = "COD_TIPO_PLLA";
                cboTipoVenta.DisplayMember = "DESC_TIPO";
            }
        }

        private void CargarNroCuota()
        {
            var cuotas = UtilNroCuotas();
            cuotas.Insert(0, new { value = "0", name = "Todos" });
            cuotas.Insert(1, new { value = "000", name = "000" });

            cboNroCuota.DisplayMember = "name";
            cboNroCuota.ValueMember = "value";
            cboNroCuota.DataSource = cuotas;
        }

        private void CargarMeses()
        {
            cboMes.ValueMember = "value";
            cboMes.DisplayMember = "name";
            cboMes.DataSource = UtilMeses();
        }

        private void MostrarPeriodoProceso()
        {
            //> string mes = string.IsNullOrEmpty(cboMes.SelectedValue?.ToString()) ? "01" : cboMes.SelectedValue.ToString();
            txtPeriodo.Text = "1"; //> BLComision.ObtenerPeriodoProceso(dtAño.Value.Year.ToString(), mes); => Este método funcona, se quitó por órdenes, ya que indicaron que siempre sería 1
        }

        private void CargarPeriodoGeneradoComision()
        {
            dtPeridoGenerado = BLComision.ObtenerPeriodosGeneradosComision();
            if (dtPeridoGenerado != null && dtPeridoGenerado.Columns.Count > 0)
            {
                DataRow row = dtPeridoGenerado.NewRow();
                row["ID"] = 0;
                row["FE_AÑO_PER"] = "";
                row["FE_MES_PER"] = "";
                row["PERIODO_PROCESO"] = 0;
                row["ESTADO"] = (int)ESTADO_COMISION.NONE;
                row["PERIODO_TEXT"] = "Seleccione";
                dtPeridoGenerado.Rows.InsertAt(row, 0);

                cboPeriodoGen.SelectedValueChanged -= CboPeriodoGen_SelectedValueChanged;
                cboPeriodoGen.ValueMember = "ID";
                cboPeriodoGen.DisplayMember = "PERIODO_TEXT";
                cboPeriodoGen.DataSource = dtPeridoGenerado;
                cboPeriodoGen.SelectedValueChanged += CboPeriodoGen_SelectedValueChanged;
            }
        }

        private void CargarNivelVenta()
        {
            DataTable dt = BLNivel.obtenerNivelBLL();
            cboNivelVenta.DataSource = dt;
            cboNivelVenta.ValueMember = "COD_NIVEL";
            cboNivelVenta.DisplayMember = "DESC_NIVEL";
            cboNivelVenta3.DataSource = dt;
            cboNivelVenta3.ValueMember = "COD_NIVEL";
            cboNivelVenta3.DisplayMember = "DESC_NIVEL";
            cboNivelVenta2.DataSource = dt;
            cboNivelVenta2.ValueMember = "COD_NIVEL";
            cboNivelVenta2.DisplayMember = "DESC_NIVEL";
        }

        private void BtnConsultarCtrats_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
            ListarContratosParaGenerarComision();
            ListarContratosComisionExcluidos();
        }

        private async void ListarContratosParaGenerarComision()
        {
            FrmLoading frmLoading = new FrmLoading()
            {
                Owner = this,
                ShowInTaskbar = false
            };
            frmLoading.Show();
            try
            {
                feAñoPer = dtAño.Value.Year.ToString();
                feMesPer = cboMes.SelectedValue.ToString();
                this.fechaAprobIni = dtFechaAprobIni.Value;
                this.fechaAprobFin = dtFechaAprobFin.Value;
                this.fechaCobraIni = dtFechaCobraIni.Value;
                this.fechaCobraFin = dtFechaCobraFin.Value;

                DateTime fechaAprobIni = dtFechaAprobIni.Value;
                DateTime fechaAprobFin = dtFechaAprobFin.Value;
                DateTime fechaCobraIni = dtFechaCobraIni.Value;
                DateTime fechaCobraFin = dtFechaCobraFin.Value;
                string codPrograma = cboPrograma.SelectedValue.ToString();
                string codInstitucion = cboInstitucion.SelectedValue.ToString();
                string codTipoVenta = cboTipoVenta.SelectedValue.ToString();
                string nroCuota = cboNroCuota.SelectedValue.ToString();
                await Task.Factory.StartNew(() =>
                    ProcesarCargarData1(fechaAprobIni, fechaAprobFin, fechaCobraIni, fechaCobraFin, codPrograma, codInstitucion, codTipoVenta, nroCuota)
                );
                CargarDgv(dgvContSinProces, dtContSinProces);
                MostrarTotalesGenerales(dgvContSinProces);
                ActualizarChkText(chkSelectTodo, dgvContSinProces);
                frmLoading.Close();
            }
            catch (Exception ex)
            {
                feAñoPer = null;
                feMesPer = null;
                frmLoading.Close();
                ex.PrintException();
            }
        }

        private void ProcesarCargarData1(DateTime fechaAprobIni, DateTime fechaAprobFin, DateTime fechaCobraIni, DateTime fechaCobraFin, string codPrograma,
            string codInstitucion, string codTipoVenta, string nroCuota)
        {
            dtContSinProces = BLComision.ListarContratosParaGenerarComision(fechaAprobIni, fechaAprobFin, fechaCobraIni, fechaCobraFin, codPrograma, codInstitucion, codTipoVenta, nroCuota);
            MostrarStatusMensaje(dtContSinProces, lblMessage, MENSAJE_PENDIENTE, ESTADO_COMISION.REGISTRO_PENDIENTE);
        }

        private async void ListarContratosComisionExcluidos()
        {
            DateTime fechaAprobIni = dtFechaAprobIni.Value;
            DateTime fechaAprobFin = dtFechaAprobFin.Value;
            DateTime fechaCobraIni = dtFechaCobraIni.Value;
            DateTime fechaCobraFin = dtFechaCobraFin.Value;
            string codPrograma = cboPrograma.SelectedValue.ToString();
            string codInstitucion = cboInstitucion.SelectedValue.ToString();
            string codTipoVenta = cboTipoVenta.SelectedValue.ToString();
            string nroCuota = cboNroCuota.SelectedValue.ToString();
            dtContExcluidos = await Task.Run(() => BLComision.ListarContratosComisionExcluidos(fechaAprobIni, fechaAprobFin, fechaCobraIni, fechaCobraFin, codPrograma, codInstitucion, codTipoVenta, nroCuota));
            CargarDgv(dgvContExcluidos, dtContExcluidos);
            MostrarTotalesGenerales(dgvContExcluidos);
            ActualizarChkText(chkSelectTodo2, dgvContExcluidos);
        }

        private void MostrarStatusMensaje(DataTable dt, Label lblMessage, string mensaje, ESTADO_COMISION estadoComision)
        {
            if (InvokeRequired)
            {
                DelMostrarMensaje del = new DelMostrarMensaje(MostrarStatusMensaje);
                object[] parameter = new object[] { dt, lblMessage, mensaje, estadoComision };
                _ = Invoke(del, parameter);
            }
            else
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = mensaje;
                    this.estadoComision = estadoComision;
                }
                else
                {
                    this.estadoComision = ESTADO_COMISION.NONE;
                    lblMessage.Visible = false;
                }
            }
        }

        private void CargarDgv(DataGridView dataGrid, DataTable dt)
        {
            dataGrid.Rows.Clear();
            //> bindingSourcerDgv = new BindingSource(dt, null);
            if (dataGrid.Columns.Count == 0)
            {
                dataGrid.AddRangeColumnsDataGridView(dt, false);
                AjsuteColumnas(dataGrid);
            }

            if (dataGrid != null && dataGrid.Columns.Count > 0)
            {
                dataGrid.AddRangeRowsDataGridView(dt);
            }
            //> dataGrid.DataSource = bindingSourcerDgv;
            //> AjsuteColumnas(dataGrid);
        }

        private void AjsuteColumnas(DataGridView dataGrid)
        {
            InvisibleColumn(dataGrid);
            RenamerHeaderText(dataGrid);
            WithColumn(dataGrid);
            AlignTextContentCell(dataGrid);
            ReadOnlyColumns(dataGrid);

            if (dataGrid != null && dataGrid.Columns.Count > 0) dataGrid.Columns["NRO_CUOTA"].Frozen = true;
            dataGrid.ColorCabeceraDataGridView(Color.Teal, Color.White);
            dataGrid.AlingHeaderTextCenter();
        }

        private void InvisibleColumn(DataGridView dataGrid)
        {
            if (dataGrid.Columns.Count > 0)
            {
                dataGrid.InvisibleColumna2("ID_COMISION_VEND");
                dataGrid.InvisibleColumna2("ID_COMISION_SUP");
                dataGrid.InvisibleColumna2("ID_COMISION_DIR_VTAS");
                dataGrid.InvisibleColumna2("ID_COMISION_DIR_NCNAL");
                dataGrid.InvisibleColumna2("COD_SUCURSAL");
                dataGrid.InvisibleColumna2("COD_CLASE");
                dataGrid.InvisibleColumna2("FE_AÑO");
                dataGrid.InvisibleColumna2("FE_MES");
                dataGrid.InvisibleColumna2("FECHA_COBRA_INI");
                dataGrid.InvisibleColumna2("FECHA_COBRA_FIN");
                dataGrid.InvisibleColumna2("ID_PROCESO");
                dataGrid.InvisibleColumna2("ID_CONF_SUP");
                dataGrid.InvisibleColumna2("ID_CONF_DIR_VTAS");
                dataGrid.InvisibleColumna2("ID_CONF_DIR_NCNAL");
                dataGrid.InvisibleColumna2("ID_CONF_VEND");

                if (dataGrid.Name == dgvContSinProces.Name)
                {
                    dataGrid.InvisibleColumna2("PERIODO_PROCESO");
                }
            }
        }

        private void RenamerHeaderText(DataGridView dataGrid)
        {
            if (dataGrid.Columns.Count > 0)
            {
                dataGrid.Columns["CH"].HeaderText = dataGrid.Name == dgvContSinProces.Name ? "¿No Gen. Comisión?" : "Estado";
                dataGrid.Columns["NRO_CONTRATO"].HeaderText = "N° Contrato";
                dataGrid.Columns["FECHA_CONTRATO"].HeaderText = "Fec.Contrato";
                dataGrid.Columns["FECHA_APROBACION"].HeaderText = "Fec.Aprob";
                dataGrid.Columns["PERIODO_PROCESO"].HeaderText = "Periodo";
                dataGrid.Columns["TIPO_PLANILLA"].HeaderText = "Tipo Vta.";
                dataGrid.Columns["CLIENTE"].HeaderText = "Cliente";
                dataGrid.Columns["IMP_DOC"].HeaderText = "Imp. Contrato";
                dataGrid.Columns["TOT_CUOTAS"].HeaderText = "N° Cuotas";
                dataGrid.Columns["IMP_COUTA_MES"].HeaderText = "Imp. Cuota Mensual";
                dataGrid.Columns["FEC_PRIMER_VENC"].HeaderText = "Fec. Primer Vcto";
                dataGrid.Columns["NRO_CUOTA"].HeaderText = "N° Ctas Cobradas";
                dataGrid.Columns["IMP_CTA_COBRADA"].HeaderText = "Imp. Cta Cobrada";
                dataGrid.Columns["FECHA_CUOTA"].HeaderText = "Fec.Ult. Cobro.Cta";
                dataGrid.Columns["PTO_COBRANZA"].HeaderText = "Pto. Cobranza";
                dataGrid.Columns["UBICACION"].HeaderText = "Ubicación";
                dataGrid.Columns["GRUPO_UBICACION"].HeaderText = "Grupo Ubicación";
                dataGrid.Columns["GESTOR"].HeaderText = "Gestor";
                dataGrid.Columns["VENDEDOR"].HeaderText = "Vendedor";
                dataGrid.Columns["IMP_COM_VEND"].HeaderText = "Imp. Comisión Vend.";
                dataGrid.Columns["SUPERVISOR"].HeaderText = "Supervisor";
                dataGrid.Columns["IMP_COM_SUP"].HeaderText = "Imp. Comisión Super.";
                dataGrid.Columns["DIRECTOR_VTAS"].HeaderText = "Director Vtas";
                dataGrid.Columns["IMP_COM_DIR_VTAS"].HeaderText = "Imp. Comisión Dir. Vtas";
                dataGrid.Columns["DIRECTOR_NCNAL"].HeaderText = "Director Nacional";
                dataGrid.Columns["IMP_COM_DIR_NCNAL"].HeaderText = "Imp. Comisión Dir. Nac.";
            }
        }

        private void WithColumn(DataGridView dataGrid)
        {
            if (dataGrid.Columns.Count > 0)
            {
                dataGrid.Columns["CH"].Width = 60;
                dataGrid.Columns["NRO_CONTRATO"].Width = 65;
                dataGrid.Columns["FECHA_CONTRATO"].Width = 70;
                dataGrid.Columns["FECHA_APROBACION"].Width = 70;
                dataGrid.Columns["PERIODO_PROCESO"].Width = 48;
                dataGrid.Columns["TIPO_PLANILLA"].Width = 40;
                dataGrid.Columns["CLIENTE"].Width = 120;
                dataGrid.Columns["IMP_DOC"].Width = 65;
                dataGrid.Columns["TOT_CUOTAS"].Width = 55;
                dataGrid.Columns["IMP_COUTA_MES"].Width = 70;
                dataGrid.Columns["FEC_PRIMER_VENC"].Width = 75;
                dataGrid.Columns["NRO_CUOTA"].Width = 65;
                dataGrid.Columns["IMP_CTA_COBRADA"].Width = 73;
                dataGrid.Columns["FECHA_CUOTA"].Width = 70;
                dataGrid.Columns["PTO_COBRANZA"].Width = 120;
                dataGrid.Columns["UBICACION"].Width = 90;
                dataGrid.Columns["GRUPO_UBICACION"].Width = 90;
                dataGrid.Columns["GESTOR"].Width = 100;
                dataGrid.Columns["VENDEDOR"].Width = 120;
                dataGrid.Columns["IMP_COM_VEND"].Width = 70;
                dataGrid.Columns["SUPERVISOR"].Width = 120;
                dataGrid.Columns["IMP_COM_SUP"].Width = 70;
                dataGrid.Columns["DIRECTOR_VTAS"].Width = 120;
                dataGrid.Columns["IMP_COM_DIR_VTAS"].Width = 75;
                dataGrid.Columns["DIRECTOR_NCNAL"].Width = 120;
                dataGrid.Columns["IMP_COM_DIR_NCNAL"].Width = 75;
            }
        }

        private void AlignTextContentCell(DataGridView dataGrid)
        {
            if (dataGrid.Columns.Count > 0)
            {
                dataGrid.AlignmentTextContent2("TIPO_PLANILLA", DataGridViewContentAlignment.MiddleCenter);
                dataGrid.AlignmentTextContent2("NRO_CONTRATO", DataGridViewContentAlignment.MiddleCenter);
                dataGrid.AlignmentTextContent2("FECHA_CONTRATO", DataGridViewContentAlignment.MiddleCenter);
                dataGrid.AlignmentTextContent2("FECHA_APROBACION", DataGridViewContentAlignment.MiddleCenter);
                dataGrid.AlignmentTextContent2("PERIODO_PROCESO", DataGridViewContentAlignment.MiddleCenter);
                dataGrid.AlignmentTextContent2("TOT_CUOTAS", DataGridViewContentAlignment.MiddleCenter);
                dataGrid.AlignmentTextContent2("NRO_CUOTA", DataGridViewContentAlignment.MiddleCenter);
                dataGrid.AlignmentTextContent2("FEC_PRIMER_VENC", DataGridViewContentAlignment.MiddleCenter);
                dataGrid.AlignmentDecimalColumns();
            }
        }

        private void ReadOnlyColumns(DataGridView dataGrid)
        {
            if (dataGrid != null)
            {
                foreach (DataGridViewColumn column in dataGrid.Columns)
                {
                    if (column.Name != "CH")
                    {
                        column.ReadOnly = true;
                    }
                }
            }
        }

        private void MostrarTotalesGenerales(DataGridView dataGrid)
        {
            decimal totalComisionVendedor = 0;
            decimal totalComisionSupervisor = 0;
            decimal totalComisionDirVtas = 0;
            decimal totalComisionDirNacional = 0;

            foreach (DataGridViewRow row in dataGrid.Rows)
            {
                totalComisionVendedor += string.IsNullOrEmpty(row.Cells["IMP_COM_VEND"].Value.ToString()) ? 0 : Convert.ToDecimal(row.Cells["IMP_COM_VEND"].Value);
                totalComisionSupervisor += string.IsNullOrEmpty(row.Cells["IMP_COM_SUP"].Value.ToString()) ? 0 : Convert.ToDecimal(row.Cells["IMP_COM_SUP"].Value);
                totalComisionDirVtas += string.IsNullOrEmpty(row.Cells["IMP_COM_DIR_VTAS"].Value.ToString()) ? 0 : Convert.ToDecimal(row.Cells["IMP_COM_DIR_VTAS"].Value);
                totalComisionDirNacional += string.IsNullOrEmpty(row.Cells["IMP_COM_DIR_NCNAL"].Value.ToString()) ? 0 : Convert.ToDecimal(row.Cells["IMP_COM_DIR_NCNAL"].Value);
            }

            if (dataGrid.Name == dgvContSinProces.Name)
            {
                lblCantRegistros.Text = string.Concat("Total Contratos: ", dataGrid.Rows.Count.ToString());
                lblTotalVendedores.Text = string.Concat("Total Comisiones --> Vendedores: ", totalComisionVendedor.FormatoMiles());
                lblTotalSupervisores.Text = string.Concat("Supervisores: ", totalComisionSupervisor.FormatoMiles());
                lblTotalDirVtas.Text = string.Concat("Directores de Venta: ", totalComisionDirVtas.FormatoMiles());
                lblTotalDirNacional.Text = string.Concat("Director Nacional: ", totalComisionDirNacional.FormatoMiles());
                lblTotalPeriodo.Text = string.Concat("Total Período: ", (totalComisionVendedor + totalComisionSupervisor + totalComisionDirVtas + totalComisionDirNacional).FormatoMiles());
            }
            else if (dataGrid.Name == dgvContAprobados.Name)
            {
                lblCantRegistros2.Text = string.Concat("Total Contratos: ", dataGrid.Rows.Count.ToString());
                lblTotalVendedores2.Text = string.Concat("Total Comisiones --> Vendedores: ", totalComisionVendedor.FormatoMiles());
                lblTotalSupervisores2.Text = string.Concat("Supervisores: ", totalComisionSupervisor.FormatoMiles());
                lblTotalDirVtas2.Text = string.Concat("Directores de Venta: ", totalComisionDirVtas.FormatoMiles());
                lblTotalDirNacional2.Text = string.Concat("Director Nacional: ", totalComisionDirNacional.FormatoMiles());
                lblTotalPeriodo2.Text = string.Concat("Total Período: ", (totalComisionVendedor + totalComisionSupervisor + totalComisionDirVtas + totalComisionDirNacional).FormatoMiles());
            }
            else if (dataGrid.Name == dgvContExcluidos.Name)
            {
                lblCantRegistros3.Text = string.Concat("Total Contratos: ", dataGrid.Rows.Count.ToString());
                lblTotalVendedores3.Text = string.Concat("Total Comisiones --> Vendedores: ", totalComisionVendedor.FormatoMiles());
                lblTotalSupervisores3.Text = string.Concat("Supervisores: ", totalComisionSupervisor.FormatoMiles());
                lblTotalDirVtas3.Text = string.Concat("Directores de Venta: ", totalComisionDirVtas.FormatoMiles());
                lblTotalDirNacional3.Text = string.Concat("Director Nacional: ", totalComisionDirNacional.FormatoMiles());
                lblTotalPeriodo3.Text = string.Concat("Total Período: ", (totalComisionVendedor + totalComisionSupervisor + totalComisionDirVtas + totalComisionDirNacional).FormatoMiles());
            }
        }

        private async void BtnGenerar_Click(object sender, EventArgs e)
        {
            FrmLoading frmLoading = null;
            if (dgvContSinProces.Rows.Count == 0)
                return;

            if (MessageBox.Show("¿Esta seguro de generar comisiones?", "MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    if (!ValidarDatosGenerarComision())
                        return;

                    VerificarExistenciaComisionVendedores(dgvContSinProces);
                    frmLoading = new FrmLoading()
                    {
                        Owner = this,
                        ShowInTaskbar = false
                    };
                    frmLoading.Show();
                    List<ComisionContrato> lstCom = ObtenerComisionContrato();
                    if (lstCom.Count > 0)
                    {
                        bool result = false;
                        _ = await Task.Run(() => result = BLComision.InsertarComisionContrato(lstCom));
                        frmLoading.Close();
                        _ = result ? MessageBox.Show("Registrado Correctamente", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            : MessageBox.Show("Error al registrar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        //> ListarContratosParaGenerarComision();
                        CargarPeriodoGeneradoComision();
                        DataRow row = dtPeridoGenerado.Select("FE_AÑO_PER = '" + feAñoPer + "' AND FE_MES_PER = '" + feMesPer + "'").Last();
                        if (row != null)
                            cboPeriodoGen.SelectedValue = row["ID"];
                        else
                            dgvContSinProces.Rows.Clear();
                    }
                    if (frmLoading != null)
                        frmLoading.Close();
                }
                catch (Exception ex)
                {
                    if (frmLoading != null)
                        frmLoading.Close();

                    ex.PrintException2();
                }
            }
        }

        private List<ComisionContrato> ObtenerComisionContrato()
        {
            List<ComisionContrato> lista = new List<ComisionContrato>();
            foreach (DataGridViewRow row in dgvContSinProces.Rows)
            {
                if (!Convert.ToBoolean(row.Cells["CH"].Value) && Convert.ToInt32(row.Cells["ID_PROCESO"].Value) == 0)
                {
                    lista.Add(new ComisionContrato
                    {
                        COD_SUCURSAL = row.Cells["COD_SUCURSAL"].Value.ToString(),
                        COD_CLASE = row.Cells["COD_CLASE"].Value.ToString(),
                        NRO_CONTRATO = row.Cells["NRO_CONTRATO"].Value.ToString(),
                        FE_AÑO = row.Cells["FE_AÑO"].Value.ToString(),
                        FE_MES = row.Cells["FE_MES"].Value.ToString(),
                        FE_AÑO_PER = feAñoPer,
                        FE_MES_PER = feMesPer,
                        NRO_CUOTA = row.Cells["NRO_CUOTA"].Value.ToString(),
                        FECHA_APROB_INI = fechaAprobIni,
                        FECHA_APROB_FIN = fechaAprobFin,
                        FECHA_COBRA_INI = fechaCobraIni,
                        FECHA_COBRA_FIN = fechaCobraFin,
                        FE_AÑO_SIS = PeriodoSistema.AÑO,
                        FE_MES_SIS = PeriodoSistema.MES,
                        PERIODO_PROCESO = txtPeriodo.Text,
                        ID_COMISION_VEND = string.IsNullOrEmpty(row.Cells["ID_COMISION_VEND"].Value?.ToString()) ? 0 : Convert.ToInt32(row.Cells["ID_COMISION_VEND"].Value),
                        ID_CONF_VEND = string.IsNullOrEmpty(row.Cells["ID_CONF_VEND"].Value?.ToString()) ? 0 : Convert.ToInt32(row.Cells["ID_CONF_VEND"].Value),
                        ID_COMISION_SUP = string.IsNullOrEmpty(row.Cells["ID_COMISION_SUP"].Value?.ToString()) ? 0 : Convert.ToInt32(row.Cells["ID_COMISION_SUP"].Value),
                        ID_CONF_SUP = string.IsNullOrEmpty(row.Cells["ID_CONF_SUP"].Value?.ToString()) ? 0 : Convert.ToInt32(row.Cells["ID_CONF_SUP"].Value),
                        ID_COMISION_DIR_VTAS = string.IsNullOrEmpty(row.Cells["ID_COMISION_DIR_VTAS"].Value?.ToString()) ? 0 : Convert.ToInt32(row.Cells["ID_COMISION_DIR_VTAS"].Value),
                        ID_CONF_DIR_VTAS = string.IsNullOrEmpty(row.Cells["ID_CONF_DIR_VTAS"].Value?.ToString()) ? 0 : Convert.ToInt32(row.Cells["ID_CONF_DIR_VTAS"].Value),
                        ID_COMISION_DIR_NCNAL = string.IsNullOrEmpty(row.Cells["ID_COMISION_DIR_NCNAL"].Value?.ToString()) ? 0 : Convert.ToInt32(row.Cells["ID_COMISION_DIR_NCNAL"].Value),
                        ID_CONF_DIR_NCNAL = string.IsNullOrEmpty(row.Cells["ID_CONF_DIR_NCNAL"].Value?.ToString()) ? 0 : Convert.ToInt32(row.Cells["ID_CONF_DIR_NCNAL"].Value),
                        USUARIO = UsuarioSistema.Cod_usu,
                        ESTADO = (int)ESTADO_COMISION.REGISTRO_PROCESADO,
                        FLAH = REGISTRO_GENERADO
                    });
                }
            }
            return lista;
        }

        private void VerificarExistenciaComisionVendedores(DataGridView dataGrid)
        {
            List<DataGridViewRow> lista = new List<DataGridViewRow>();
            if (dataGrid.Name == dgvContExcluidos.Name)
                lista = dataGrid.Rows.Cast<DataGridViewRow>().Where(x => string.IsNullOrEmpty(x.Cells["ID_COMISION_VEND"].Value?.ToString()) && Convert.ToBoolean(x.Cells["CH"].Value)).OrderBy(f => f.Cells["VENDEDOR"].Value).ToList();
            else
                lista = dataGrid.Rows.Cast<DataGridViewRow>().Where(x => string.IsNullOrEmpty(x.Cells["ID_COMISION_VEND"].Value?.ToString())).OrderBy(f => f.Cells["VENDEDOR"].Value).ToList();
            if (lista != null && lista.Count > 0)
            {
                StringBuilder nombreVendedor = new StringBuilder();
                //> Descomentar para no mostrar vendedores repetidos
                //> string nombre = string.Empty;
                int io = 0;
                foreach (DataGridViewRow row in lista)
                {
                    //> if (!nombre.Equals(row.Cells["VENDEDOR"].Value))
                    //> {
                    io += 1;
                    _ = nombreVendedor.Append(string.Concat(io, ". ", row.Cells["NRO_CONTRATO"].Value, " - ", row.Cells["TIPO_PLANILLA"].Value, " - ", row.Cells["VENDEDOR"].Value));
                    _ = nombreVendedor.Append("\n");
                    //> nombre = row.Cells["VENDEDOR"].Value.ToString();
                    //> }
                }
                _ = MessageBox.Show(string.Concat("Los siguientes vendedores no tienen comisiones \n", nombreVendedor), "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool ValidarDatosGenerarComision()
        {
            if (txtPeriodo.Text.Length == 0)
            {
                _ = MessageBox.Show("Debe digitar un número en el período de generación", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _ = txtPeriodo.Focus();
                return false;
            }
            if (!int.TryParse(txtPeriodo.Text, out _))
            {
                _ = MessageBox.Show("Debe digitar un número en el período de generación", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPeriodo.Clear();
                _ = txtPeriodo.Focus();
                return false;
            }
            return true;
        }

        private void BtnAgregarContrato_Click(object sender, EventArgs e)
        {
            if (estadoComision == ESTADO_COMISION.NONE || estadoComision == ESTADO_COMISION.REGISTRO_PENDIENTE)
            {
                _ = MessageBox.Show("Seleccione primero un periodo generado de comisión a la cual agregar los contratos", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            FrmAgregarContratoProcesamiento frmAgregarContr = new FrmAgregarContratoProcesamiento(cboPrograma.SelectedValue.ToString(), cboInstitucion.SelectedValue.ToString(),
                cboTipoVenta.SelectedValue.ToString(), cboNroCuota.SelectedValue.ToString(), fechaCobraIni)
            {
                StartPosition = FormStartPosition.CenterParent
            };
            frmAgregarContr.EventPasarData += RecibirData;
            _ = frmAgregarContr.ShowDialog();
        }

        private void RecibirData(DataGridView gridView)
        {
            if (gridView != null && gridView.Rows.Count > 0)
            {
                DataGridViewRow rw = gridView.Rows[0];
                DataGridViewRow row = dgvContSinProces.Rows.Cast<DataGridViewRow>().SingleOrDefault(
                    x => x.Cells["NRO_CONTRATO"].Value.Equals(rw.Cells["NRO_CONTRATO"].Value)
                    && x.Cells["NRO_CUOTA"].Value.Equals(rw.Cells["NRO_CUOTA"].Value));
                if (row is null)
                {
                    if (RegistrarContratoComisionAgregado(rw))
                    {
                        int index = dgvContSinProces.Rows.Add();
                        DataGridViewRow newRow = dgvContSinProces.Rows[index];
                        foreach (DataGridViewColumn column in dgvContSinProces.Columns)
                        {
                            newRow.Cells[column.Name].Value = rw.Cells[column.Name].Value;
                        }
                        ActualizarContrtoAgregado(newRow);
                        MostrarTotalesGenerales(dgvContSinProces);
                    }
                }
                else
                    _ = MessageBox.Show("Este contrato ya esta agregado", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                _ = MessageBox.Show("No se ha seleccionado ningun contrato", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private bool RegistrarContratoComisionAgregado(DataGridViewRow row)
        {
            try
            {
                ComisionContrato com = ObtenerComisionContrato(row);
                if (com != null)
                {
                    bool result = BLComision.InsertarComisionContratoAPeriodoExistente(com);
                    if (!result)
                        _ = MessageBox.Show("Error al insertar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return result;
                }
            }
            catch (Exception ex)
            {
                ex.PrintException2();
            }
            return false;
        }

        private ComisionContrato ObtenerComisionContrato(DataGridViewRow row)
        {
            if (row == null) return null;

            if (!ValidarPeridoSeleccionado(out DataRow rowPeriodo))
                return null;

            string feAñoPer = rowPeriodo["FE_AÑO_PER"].ToString();
            string feMesPer = rowPeriodo["FE_MES_PER"].ToString();
            string periodoProceso = rowPeriodo["PERIODO_PROCESO"].ToString();

            return new ComisionContrato
            {
                COD_SUCURSAL = row.Cells["COD_SUCURSAL"].Value.ToString(),
                COD_CLASE = row.Cells["COD_CLASE"].Value.ToString(),
                NRO_CONTRATO = row.Cells["NRO_CONTRATO"].Value.ToString(),
                FE_AÑO = row.Cells["FE_AÑO"].Value.ToString(),
                FE_MES = row.Cells["FE_MES"].Value.ToString(),
                FE_AÑO_PER = feAñoPer,
                FE_MES_PER = feMesPer,
                NRO_CUOTA = row.Cells["NRO_CUOTA"].Value.ToString(),
                FECHA_APROB_INI = fechaAprobIni,
                FECHA_APROB_FIN = fechaAprobFin,
                FECHA_COBRA_INI = fechaCobraIni,
                FECHA_COBRA_FIN = fechaCobraFin,
                PERIODO_PROCESO = periodoProceso,
                FE_AÑO_SIS = PeriodoSistema.AÑO,
                FE_MES_SIS = PeriodoSistema.MES,
                ID_COMISION_VEND = string.IsNullOrEmpty(row.Cells["ID_COMISION_VEND"].Value?.ToString()) ? 0 : Convert.ToInt32(row.Cells["ID_COMISION_VEND"].Value),
                ID_CONF_VEND = string.IsNullOrEmpty(row.Cells["ID_CONF_VEND"].Value?.ToString()) ? 0 : Convert.ToInt32(row.Cells["ID_CONF_VEND"].Value),
                ID_COMISION_SUP = string.IsNullOrEmpty(row.Cells["ID_COMISION_SUP"].Value?.ToString()) ? 0 : Convert.ToInt32(row.Cells["ID_COMISION_SUP"].Value),
                ID_CONF_SUP = string.IsNullOrEmpty(row.Cells["ID_CONF_SUP"].Value?.ToString()) ? 0 : Convert.ToInt32(row.Cells["ID_CONF_SUP"].Value),
                ID_COMISION_DIR_VTAS = string.IsNullOrEmpty(row.Cells["ID_COMISION_DIR_VTAS"].Value?.ToString()) ? 0 : Convert.ToInt32(row.Cells["ID_COMISION_DIR_VTAS"].Value),
                ID_CONF_DIR_VTAS = string.IsNullOrEmpty(row.Cells["ID_CONF_DIR_VTAS"].Value?.ToString()) ? 0 : Convert.ToInt32(row.Cells["ID_CONF_DIR_VTAS"].Value),
                ID_COMISION_DIR_NCNAL = string.IsNullOrEmpty(row.Cells["ID_COMISION_DIR_NCNAL"].Value?.ToString()) ? 0 : Convert.ToInt32(row.Cells["ID_COMISION_DIR_NCNAL"].Value),
                ID_CONF_DIR_NCNAL = string.IsNullOrEmpty(row.Cells["ID_CONF_DIR_NCNAL"].Value?.ToString()) ? 0 : Convert.ToInt32(row.Cells["ID_CONF_DIR_NCNAL"].Value),
                USUARIO = UsuarioSistema.Cod_usu,
                ESTADO = (int)ESTADO_COMISION.REGISTRO_PROCESADO,
                FLAH = REGISTRO_AGREGADO
            };
        }

        private bool ValidarPeridoSeleccionado(out DataRow rowPeriodo)
        {
            if (estadoComision == ESTADO_COMISION.NONE || estadoComision == ESTADO_COMISION.REGISTRO_PENDIENTE)
            {
                _ = MessageBox.Show("Seleccione primero un periodo generado", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                rowPeriodo = null;
                return false;
            }

            DataRow rw = dtPeridoGenerado.Select("ID = " + Convert.ToInt32(cboPeriodoGen.SelectedValue)).SingleOrDefault();
            if (rw == null || rw.ItemArray.Length == 0)
            {
                _ = MessageBox.Show("No existe un perido generado de comisión", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                rowPeriodo = null;
                return false;
            }
            rowPeriodo = rw;
            return true;
        }

        private void ActualizarContrtoAgregado(DataGridViewRow row)
        {
            if (row != null)
            {
                string codClase = row.Cells["COD_CLASE"].Value.ToString();
                string codSucursal = row.Cells["COD_SUCURSAL"].Value.ToString();
                string nroContrato = row.Cells["NRO_CONTRATO"].Value.ToString();
                string feAño = row.Cells["FE_AÑO"].Value.ToString();
                string feMes = row.Cells["FE_MES"].Value.ToString();
                string nroCuota = row.Cells["NRO_CUOTA"].Value.ToString();
                DataTable dt = BLComision.ObtenerContratoComisionGenerado(codSucursal, codClase, nroContrato, feAño, feMes, nroCuota);
                if (dt != null && dt.Rows.Count == 1)
                {
                    row.Cells["ID_PROCESO"].Value = dt.Rows[0]["ID_PROCESO"];
                    dtContSinProces.AddCloneRowWithValues(dt.Rows[0]);
                }
                else
                    _ = MessageBox.Show("Error al actualizar el contrato agregado", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void TabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            tabControl1.Style1TabPages(e);
        }

        private void DgvContSinProces_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                try
                {
                    if (dgvContSinProces.CurrentRow != null)
                        dgvContSinProces.Rows.RemoveAt(dgvContSinProces.CurrentRow.Index);
                    MostrarTotalesGenerales(dgvContSinProces);
                }
                catch (Exception ex)
                {
                    ex.PrintException();
                }
            }
        }

        private async void BtnEliminarContr_Click(object sender, EventArgs e)
        {
            FrmLoading frmLoading = null;
            try
            {
                if (dgvContSinProces.Rows.Count == 0)
                    return;

                if (MessageBox.Show("¿Esta seguro de revertir todas las comisiones filtradas?", "MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    frmLoading = new FrmLoading()
                    {
                        Owner = this,
                        ShowInTaskbar = false
                    };
                    frmLoading.Show();

                    List<ComisionContrato> comTo = ObtenerComisionesContratoEliminar();
                    Task<bool> task = Task<bool>.Factory.StartNew(() => BLComision.EliminarContratoComision(comTo));
                    bool result = await task;
                    frmLoading.Close();

                    if (result)
                    {
                        dgvContSinProces.Rows.Clear();
                        MostrarTotalesGenerales(dgvContSinProces);
                        lblMessage.Visible = false;
                        _ = MessageBox.Show("Eliminado correctamente", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        _ = MessageBox.Show("Error al eliminar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    CargarPeriodoGeneradoComision();
                }
            }
            catch (Exception ex)
            {
                if (frmLoading != null)
                    frmLoading.Close();

                ex.PrintException();
            }
        }

        private List<ComisionContrato> ObtenerComisionesContratoEliminar()
        {
            List<ComisionContrato> lista = new List<ComisionContrato>();
            foreach (DataGridViewRow row in dgvContSinProces.Rows)
            {
                lista.Add(new ComisionContrato
                {
                    ID_PROCESO = row.Cells["ID_PROCESO"].Value.ToInt32(),
                    COD_SUCURSAL = row.Cells["COD_SUCURSAL"].Value.ToString(),
                    COD_CLASE = row.Cells["COD_CLASE"].Value.ToString(),
                    NRO_CONTRATO = row.Cells["NRO_CONTRATO"].Value.ToString(),
                    FE_AÑO = row.Cells["FE_AÑO"].Value.ToString(),
                    FE_MES = row.Cells["FE_MES"].Value.ToString(),
                    NRO_CUOTA = row.Cells["NRO_CUOTA"].Value.ToString(),
                    ID_COMISION_VEND = string.IsNullOrEmpty(row.Cells["ID_COMISION_VEND"].Value.ToString()) ? 0 : Convert.ToInt32(row.Cells["ID_COMISION_VEND"].Value),
                    ID_COMISION_SUP = string.IsNullOrEmpty(row.Cells["ID_COMISION_SUP"].Value.ToString()) ? 0 : Convert.ToInt32(row.Cells["ID_COMISION_SUP"].Value),
                    ID_COMISION_DIR_VTAS = string.IsNullOrEmpty(row.Cells["ID_COMISION_DIR_VTAS"].Value.ToString()) ? 0 : Convert.ToInt32(row.Cells["ID_COMISION_DIR_VTAS"].Value),
                    ID_COMISION_DIR_NCNAL = string.IsNullOrEmpty(row.Cells["ID_COMISION_DIR_NCNAL"].Value.ToString()) ? 0 : Convert.ToInt32(row.Cells["ID_COMISION_DIR_NCNAL"].Value)
                });
            }
            return lista;
        }

        private void BtnEliminarComision_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridView dataGrid = tabControl1.SelectedTab.Controls.OfType<DataGridView>().First();
                if (dataGrid.Rows.Count == 0)
                    return;

                if (MessageBox.Show("¿Esta seguro de eliminar los registros seleccionados?", "MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    List<ComisionContrato> comTo = ObtenerComisionesContratoEliminarSeleccionados(out DataGridViewRow[] arrRow);
                    if (comTo != null)
                    {
                        bool result = BLComision.EliminarContratoComision(comTo);
                        if (result)
                        {
                            RemoverFilasDgv(dataGrid, arrRow);
                            CargarPeriodoGeneradoComision();
                            MostrarTotalesGenerales(dataGrid);
                            ActualizarChkText(chkSelectTodo, dataGrid);
                            _ = MessageBox.Show("Eliminado correctamente", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            _ = MessageBox.Show("Error al eliminar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.PrintException();
            }
        }

        private List<ComisionContrato> ObtenerComisionesContratoEliminarSeleccionados(out DataGridViewRow[] arrRows)
        {
            try
            {
                DataGridView dataGrid = tabControl1.SelectedTab.Controls.OfType<DataGridView>().First();
                int cantidadSeleccionado = dataGrid.Rows.Cast<DataGridViewRow>().Count(x => Convert.ToBoolean(x.Cells["CH"].Value) && x.Cells["ID_PROCESO"].Value.ToInt32() > 0);
                if (cantidadSeleccionado > 0)
                {
                    List<ComisionContrato> lista = new List<ComisionContrato>();
                    ComisionContrato[] arrCom = new ComisionContrato[cantidadSeleccionado];
                    DataGridViewRow[] arrRow = dataGrid.Rows.Cast<DataGridViewRow>().Where(x => Convert.ToBoolean(x.Cells["CH"].Value) && x.Cells["ID_PROCESO"].Value.ToInt32() > 0).ToArray();
                    int io = 0;
                    foreach (DataGridViewRow row in arrRow)
                    {
                        ComisionContrato comisionContrato = new ComisionContrato
                        {
                            ID_PROCESO = row.Cells["ID_PROCESO"].Value.ToInt32(),
                            COD_SUCURSAL = row.Cells["COD_SUCURSAL"].Value.ToString(),
                            COD_CLASE = row.Cells["COD_CLASE"].Value.ToString(),
                            NRO_CONTRATO = row.Cells["NRO_CONTRATO"].Value.ToString(),
                            FE_AÑO = row.Cells["FE_AÑO"].Value.ToString(),
                            FE_MES = row.Cells["FE_MES"].Value.ToString(),
                            NRO_CUOTA = row.Cells["NRO_CUOTA"].Value.ToString(),
                            ID_COMISION_VEND = string.IsNullOrEmpty(row.Cells["ID_COMISION_VEND"].Value.ToString()) ? 0 : Convert.ToInt32(row.Cells["ID_COMISION_VEND"].Value),
                            ID_COMISION_SUP = string.IsNullOrEmpty(row.Cells["ID_COMISION_SUP"].Value.ToString()) ? 0 : Convert.ToInt32(row.Cells["ID_COMISION_SUP"].Value),
                            ID_COMISION_DIR_VTAS = string.IsNullOrEmpty(row.Cells["ID_COMISION_DIR_VTAS"].Value.ToString()) ? 0 : Convert.ToInt32(row.Cells["ID_COMISION_DIR_VTAS"].Value),
                            ID_COMISION_DIR_NCNAL = string.IsNullOrEmpty(row.Cells["ID_COMISION_DIR_NCNAL"].Value.ToString()) ? 0 : Convert.ToInt32(row.Cells["ID_COMISION_DIR_NCNAL"].Value)
                        };
                        arrCom[io] = comisionContrato;
                        io += 1;
                    }
                    lista.AddRange(arrCom);
                    arrRows = arrRow;
                    return lista;
                }
                arrRows = null;
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void RemoverFilasDgv(DataGridView dataGrid, DataGridViewRow[] arrRow)
        {
            if (arrRow.Any())
            {
                foreach (DataGridViewRow row in arrRow)
                {
                    dataGrid.Rows.Remove(row);
                }
            }
        }

        private void CboMes_SelectedValueChanged(object sender, EventArgs e)
        {
            EstablecerFechaAprob();
            MostrarPeriodoProceso();
        }

        private void DtAño_ValueChanged(object sender, EventArgs e)
        {
            EstablecerFechaAprob();
            MostrarPeriodoProceso();
        }

        private void EstablecerFechaAprob()
        {
            int mes = string.IsNullOrEmpty(cboMes.SelectedValue?.ToString()) ? 1 : Convert.ToInt32(cboMes.SelectedValue);
            DateTime fechaInicio = new DateTime(dtAño.Value.Year, mes, 1);
            DateTime fechaFin = new DateTime(dtAño.Value.Year, mes, DateTime.DaysInMonth(fechaInicio.Year, fechaInicio.Month));
            dtFechaCobraIni.Value = fechaInicio;
            dtFechaCobraFin.Value = fechaFin;
        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnabledDisableButton();
        }

        /// <summary>
        /// Habilita o deshabilita según el tabPage seleccionado
        /// </summary>
        private void EnabledDisableButton()
        {
            btnGenerar.Enabled = tabControl1.SelectedTab == tabPage1;
            btnAgregarContrato.Enabled = tabControl1.SelectedTab == tabPage1;
            btnEliminarComisGen.Enabled = tabControl1.SelectedTab == tabPage1;
            btnExcluirContratos.Enabled = tabControl1.SelectedTab == tabPage1;
        }

        private void CboPeriodoGen_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboPeriodoGen.Items.Count > 0 && Convert.ToInt32(cboPeriodoGen.SelectedValue) != 0)
            {
                DataRow row = ObtenerPeriodoSeleccionado();
                if (row == null || row.ItemArray.Length == 0)
                    return;
                if (row["ESTADO"].ToInt32() == (int)ESTADO_COMISION.REGISTRO_PROCESADO)
                {
                    if (tabControl1.SelectedTab != tabPage1)
                        tabControl1.SelectedTab = tabPage1;
                    ListarComisionContratosProcesados();
                }
                else if (row["ESTADO"].ToInt32() == (int)ESTADO_COMISION.REGISTRO_APROBADO)
                {
                    if (tabControl1.SelectedTab != tabPageAprobados)
                        tabControl1.SelectedTab = tabPageAprobados;
                    ListarComisionContratosAprobados();
                }
                EstablecerFechaXPeriodoGenSeleccionado(row);
            }
        }

        private DataRow ObtenerPeriodoSeleccionado()
        {
            try
            {
                return dtPeridoGenerado.Select("ID = " + Convert.ToInt32(cboPeriodoGen.SelectedValue)).Single();
            }
            catch (ArgumentNullException)
            {
                _ = MessageBox.Show("No se encontró el periodo seleccionado. \n Cierre el formulario y vuelva a intentarlo", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (InvalidOperationException)
            {
                _ = MessageBox.Show("Se identificó dos periodos con el mismo id. \n Cierre el formulario y vuelva a intentarlo", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                ex.PrintException();
            }
            return null;
        }

        private void EstablecerFechaXPeriodoGenSeleccionado(DataRow row)
        {
            if (row != null && row.ItemArray.Length > 0)
            {
                dtAño.Value = new DateTime(row["FE_AÑO_PER"].ToInt32(), row["FE_MES_PER"].ToInt32(), 1);
                cboMes.SelectedValue = row["FE_MES_PER"].ToString();
            }
        }

        private async void ListarComisionContratosProcesados()
        {
            FrmLoading frmLoading = new FrmLoading()
            {
                Owner = this,
                ShowInTaskbar = false
            };
            frmLoading.Show();
            try
            {
                DataRow row = dtPeridoGenerado.Select("ID = " + Convert.ToInt32(cboPeriodoGen.SelectedValue)).Single();
                if (row == null || row.ItemArray.Length == 0)
                    return;

                dtContExcluidos = null;

                string feAñoPer = row["FE_AÑO_PER"].ToString();
                string feMesPer = row["FE_MES_PER"].ToString();
                string periodoProceso = row["PERIODO_PROCESO"].ToString();
                string codPrograma = cboPrograma.SelectedValue.ToString();
                string codInstitucion = cboInstitucion.SelectedValue.ToString();
                string codTipoVenta = cboTipoVenta.SelectedValue.ToString();
                string nroCuota = cboNroCuota.SelectedValue.ToString();

                dtContSinProces = await Task.Run(() => BLComision.ListarContratosGeneradosComisionXPeriodo(feAñoPer, feMesPer, periodoProceso, codPrograma, codInstitucion, codTipoVenta, nroCuota));
                CargarDgv(dgvContSinProces, dtContSinProces);
                MostrarTotalesGenerales(dgvContSinProces);
                if (dtContSinProces != null && dtContSinProces.Rows.Count > 0)
                {
                    fechaAprobIni = dtFechaAprobIni.Value;
                    fechaAprobFin = dtFechaAprobFin.Value;
                    fechaCobraIni = Convert.ToDateTime(dtContSinProces.Rows[0]["FECHA_COBRA_INI"]);
                    fechaCobraFin = Convert.ToDateTime(dtContSinProces.Rows[0]["FECHA_COBRA_FIN"]);
                    dtContExcluidos = await Task.Run(() => BLComision.ListarContratosComisionExcluidos(fechaAprobIni, fechaAprobFin, fechaCobraIni, fechaCobraFin, codPrograma, codInstitucion, codTipoVenta, nroCuota));
                    CargarDgv(dgvContExcluidos, dtContExcluidos);
                    MostrarTotalesGenerales(dgvContExcluidos);
                    lblTextPeriodo.Text = string.Concat("(", fechaCobraIni.ToShortDateString(), " - ", fechaCobraFin.ToShortDateString(), ")");
                }
                else
                {
                    lblTextPeriodo.Text = "(__ - __)";
                }

                MostrarStatusMensaje(dtContSinProces, lblMessage, string.Concat("GENERADO | ", cboPeriodoGen.Text), ESTADO_COMISION.REGISTRO_PROCESADO);
                ActualizarChkText(chkSelectTodo, dgvContSinProces);
                ActualizarChkText(chkSelectTodo2, dgvContExcluidos);

                frmLoading.Close();
            }
            catch (Exception ex)
            {
                frmLoading.Close();
                ex.PrintException();
            }
        }

        private async void ListarComisionContratosAprobados()
        {
            FrmLoading frmLoading = new FrmLoading()
            {
                Owner = this,
                ShowInTaskbar = false
            };
            frmLoading.Show();
            try
            {
                DataRow row = dtPeridoGenerado.Select("ID = " + Convert.ToInt32(cboPeriodoGen.SelectedValue)).Single();
                if (row == null || row.ItemArray.Length == 0)
                    return;

                string feAñoPer = row["FE_AÑO_PER"].ToString();
                string feMesPer = row["FE_MES_PER"].ToString();
                string periodoProceso = row["PERIODO_PROCESO"].ToString();
                string codPrograma = cboPrograma.SelectedValue.ToString();
                string codInstitucion = cboInstitucion.SelectedValue.ToString();
                string codTipoVenta = cboTipoVenta.SelectedValue.ToString();
                string nroCuota = cboNroCuota.SelectedValue.ToString();

                dtContAprobados = await Task.Run(() => BLComision.ListarComisionContratoAprobado(feAñoPer, feMesPer, periodoProceso, codPrograma, codInstitucion, codTipoVenta, nroCuota));
                CargarDgv(dgvContAprobados, dtContAprobados);
                MostrarTotalesGenerales(dgvContAprobados);
                if (dtContAprobados != null && dtContAprobados.Rows.Count > 0)
                {
                    lblTextPeriodo.Text = string.Concat("(", Convert.ToDateTime(dtContAprobados.Rows[0]["FECHA_COBRA_INI"]).ToShortDateString(), " - ",
                        Convert.ToDateTime(dtContAprobados.Rows[0]["FECHA_COBRA_FIN"]).ToShortDateString(), ")");
                }
                else
                {
                    lblTextPeriodo.Text = "(__ - __)";
                }
                MostrarStatusMensaje(dtContAprobados, lblMessage2, string.Concat("CERRADO | ", cboPeriodoGen.Text), ESTADO_COMISION.REGISTRO_APROBADO);
                frmLoading.Close();
            }
            catch (Exception ex)
            {
                frmLoading.Close();
                ex.PrintException();
            }
        }

        private void BtnGenerarReporte_Click(object sender, EventArgs e)
        {
            FrmGenerarReporteComisiones frmReporte = new FrmGenerarReporteComisiones()
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            frmReporte.Show(this);
        }

        private void TxtNombreVendedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string nameColumn;
                string nameImpColumn;
                switch (cboNivelVenta.SelectedValue.ToString())
                {
                    case COD_NIVEL_VENDEDOR: nameColumn = "VENDEDOR"; nameImpColumn = "IMP_COM_VEND"; break;
                    case COD_NIVEL_SUPERVISOR: nameColumn = "SUPERVISOR"; nameImpColumn = "IMP_COM_SUP"; break;
                    case COD_NIVEL_DIR_VENTAS: nameColumn = "DIRECTOR_VTAS"; nameImpColumn = "IMP_COM_DIR_VTAS"; break;
                    case COD_NIVEL_DIR_NACIONAL: nameColumn = "DIRECTOR_NCNAL"; nameImpColumn = "IMP_COM_DIR_NCNAL"; break;
                    default: nameColumn = string.Empty; nameImpColumn = string.Empty; break;
                };

                FiltrarDataGridView(dtContSinProces, dgvContSinProces, TIPO_BUSQUEDA.LIKE, nameColumn, txtNombreVendedor.Text, nameImpColumn);
                ActualizarChkText(chkSelectTodo, dgvContSinProces);
            }
        }

        private void TxtNroCuota_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FormatTxtNroCuota(txtNroCuota);
                FiltrarDataGridView(dtContSinProces, dgvContSinProces, TIPO_BUSQUEDA.IGUAL, "NRO_CUOTA", txtNroCuota.Text);
                ActualizarChkText(chkSelectTodo, dgvContSinProces);
            }
        }

        private void TxtNroContrato_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtNroContrato.TxtContratoFormato();
                FiltrarDataGridView(dtContSinProces, dgvContSinProces, TIPO_BUSQUEDA.IGUAL, "NRO_CONTRATO", txtNroContrato.Text);
                ActualizarChkText(chkSelectTodo, dgvContSinProces);
            }
        }

        private void TxtNombreVendedor2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string nameColumn;
                string nameImpColumn;
                switch (cboNivelVenta2.SelectedValue.ToString())
                {
                    case COD_NIVEL_VENDEDOR: nameColumn = "VENDEDOR"; nameImpColumn = "IMP_COM_VEND"; break;
                    case COD_NIVEL_SUPERVISOR: nameColumn = "SUPERVISOR"; nameImpColumn = "IMP_COM_SUP"; break;
                    case COD_NIVEL_DIR_VENTAS: nameColumn = "DIRECTOR_VTAS"; nameImpColumn = "IMP_COM_DIR_VTAS"; break;
                    case COD_NIVEL_DIR_NACIONAL: nameColumn = "DIRECTOR_NCNAL"; nameImpColumn = "IMP_COM_DIR_NCNAL"; break;
                    default: nameColumn = string.Empty; nameImpColumn = string.Empty; break;
                };
                FiltrarDataGridView(dtContAprobados, dgvContAprobados, TIPO_BUSQUEDA.LIKE, nameColumn, txtNombreVendedor2.Text, nameImpColumn);
            }
        }

        private void TxtNroCuota2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FormatTxtNroCuota(txtNroCuota2);
                FiltrarDataGridView(dtContAprobados, dgvContAprobados, TIPO_BUSQUEDA.IGUAL, "NRO_CUOTA", txtNroCuota2.Text);
            }
        }

        private void TxtNroContrato2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtNroContrato2.TxtContratoFormato();
                FiltrarDataGridView(dtContAprobados, dgvContAprobados, TIPO_BUSQUEDA.IGUAL, "NRO_CONTRATO", txtNroContrato2.Text);
            }
        }

        private void TxtNombreVendedor3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string nameColumn;
                string nameImpColumn;
                switch (cboNivelVenta3.SelectedValue.ToString())
                {
                    case COD_NIVEL_VENDEDOR: nameColumn = "VENDEDOR"; nameImpColumn = "IMP_COM_VEND"; break;
                    case COD_NIVEL_SUPERVISOR: nameColumn = "SUPERVISOR"; nameImpColumn = "IMP_COM_SUP"; break;
                    case COD_NIVEL_DIR_VENTAS: nameColumn = "DIRECTOR_VTAS"; nameImpColumn = "IMP_COM_DIR_VTAS"; break;
                    case COD_NIVEL_DIR_NACIONAL: nameColumn = "DIRECTOR_NCNAL"; nameImpColumn = "IMP_COM_DIR_NCNAL"; break;
                    default: nameColumn = string.Empty; nameImpColumn = string.Empty; break;
                };
                FiltrarDataGridView(dtContExcluidos, dgvContExcluidos, TIPO_BUSQUEDA.LIKE, nameColumn, txtNombreVendedor3.Text, nameImpColumn);
                ActualizarChkText(chkSelectTodo2, dgvContExcluidos);
            }
        }

        private void TxtNroCuota3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FormatTxtNroCuota(txtNroCuota3);
                FiltrarDataGridView(dtContExcluidos, dgvContExcluidos, TIPO_BUSQUEDA.IGUAL, "NRO_CUOTA", txtNroCuota3.Text);
                ActualizarChkText(chkSelectTodo2, dgvContExcluidos);
            }
        }

        private void TxtNroContrato3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtNroContrato3.TxtContratoFormato();
                FiltrarDataGridView(dtContExcluidos, dgvContExcluidos, TIPO_BUSQUEDA.IGUAL, "NRO_CONTRATO", txtNroContrato3.Text);
                ActualizarChkText(chkSelectTodo2, dgvContExcluidos);
            }
        }

        private async void FiltrarDataGridView(DataTable dt, DataGridView dataGrid, TIPO_BUSQUEDA tipoBusqueda, string nombreColumnaBusqueda, string textoFiltrar, string nameImpColumn = null)
        {
            if (dt != null)
            {
                FrmLoading frmLoading = new FrmLoading()
                {
                    Owner = this,
                    ShowInTaskbar = false
                };
                frmLoading.Show();
                dataGrid.Rows.Clear();
                DataView dv = null;
                await Task.Factory.StartNew(() =>
                   {
                       Thread.Sleep(400);

                       string filterText = null;
                       dv = dt.DefaultView;
                       switch (tipoBusqueda)
                       {
                           case TIPO_BUSQUEDA.IGUAL:
                               filterText = string.Concat(nombreColumnaBusqueda, " = '", textoFiltrar, "'");
                               break;
                           case TIPO_BUSQUEDA.LIKE:
                               filterText = string.Concat(nombreColumnaBusqueda, " LIKE '%", textoFiltrar, "%' AND " + nameImpColumn + " > 0");
                               break;
                           default:
                               throw new Exception("No existe este tipo de filtro");
                       }

                       if (!string.IsNullOrEmpty(textoFiltrar))
                           dv.RowFilter = filterText;
                   }
                );
                if (!string.IsNullOrEmpty(textoFiltrar))
                    CargarDgv(dataGrid, dv.ToTable());
                else
                    CargarDgv(dataGrid, dt);

                MostrarTotalesGenerales(dataGrid);
                frmLoading.Close();
            }
        }

        private void FormatTxtNroCuota(TextBox txtNroCuota)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtNroCuota.Text)
                    && int.TryParse(txtNroCuota.Text, out int result))
                {
                    if (result <= 18)
                    {
                        txtNroCuota.Text = result.ToString().PadLeft(3, Convert.ToChar("0"));
                    }
                    else
                    {
                        _ = MessageBox.Show("El numero máximo de cuotas es 18", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtNroCuota.Text = "000";
                    }
                }
                else
                    txtNroCuota.Text = string.Empty;
            }
            catch (Exception ex)
            {
                if (ex is FormatException)
                    txtNroCuota.Text = string.Empty;
            }
        }

        private void BtnExcluirContratos_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvContSinProces.Rows.Count > 0
                    && dgvContSinProces.Rows.Cast<DataGridViewRow>().Count(x => Convert.ToBoolean(x.Cells["CH"].Value)) > 0)
                {
                    if (MessageBox.Show("¿Esta seguro de excluir los contratos seleccionados?", "MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        return;

                    tabControl1.SelectedTab = tabPageExcluidos;

                    if (dgvContExcluidos.Columns.Count == 0)
                    {
                        foreach (DataGridViewColumn column in dgvContSinProces.Columns)
                        {
                            _ = dgvContExcluidos.Columns.Add(column.CloneColumn());
                        }
                    }

                    var lstDataRow = dgvContSinProces.Rows.Cast<DataGridViewRow>().Where(x => Convert.ToBoolean(x.Cells["CH"].Value)).ToArray();
                    var lstDataRow2 = dtContSinProces.Rows.Cast<DataRow>().ToArray();
                    var lstRow = from row in lstDataRow
                                 join row2 in lstDataRow2 on row.Cells["NRO_CONTRATO"].Value.ToString() equals row2["NRO_CONTRATO"].ToString()
                                 where row.Cells["COD_CLASE"].Value.ToString() == row2["COD_CLASE"].ToString() &&
                                 row.Cells["COD_SUCURSAL"].Value.ToString() == row2["COD_SUCURSAL"].ToString() &&
                                 row.Cells["FE_AÑO"].Value.ToString() == row2["FE_AÑO"].ToString() &&
                                 row.Cells["FE_MES"].Value.ToString() == row2["FE_MES"].ToString() &&
                                 row.Cells["NRO_CUOTA"].Value.ToString() == row2["NRO_CUOTA"].ToString()
                                 select row2;

                    if (lstDataRow != null)
                    {
                        GrabarComisionContratoExcluidos(lstDataRow);
                        ActualizarComisionContratoAExcluidos();
                        lstDataRow.Cast<DataGridViewRow>().ToList().ForEach(x => x.Cells["CH"].Value = false);
                        dgvContExcluidos.Rows.AddRange(lstDataRow.CloneWithValues());
                        dgvContExcluidos.Columns["FECHA_CONTRATO"].DefaultCellStyle.Format = "dd/MM/yyyy";
                        dgvContExcluidos.Columns["FECHA_APROBACION"].DefaultCellStyle.Format = "dd/MM/yyyy";
                        dgvContExcluidos.Columns["FEC_PRIMER_VENC"].DefaultCellStyle.Format = "dd/MM/yyyy";
                        if (lstDataRow != null && lstDataRow2 != null)
                        {
                            foreach (DataRow row in lstRow)
                            {
                                dtContSinProces.Rows.Remove(row);
                            }

                            foreach (DataGridViewRow row in lstDataRow)
                            {
                                dgvContSinProces.Rows.Remove(row);
                            }
                        }

                        dtContExcluidos = dgvContExcluidos.ConvertToDataTable();
                        MostrarTotalesGenerales(dgvContExcluidos);
                        MostrarTotalesGenerales(dgvContSinProces);
                        ActualizarChkText(chkSelectTodo, dgvContSinProces);
                        ActualizarChkText(chkSelectTodo2, dgvContExcluidos);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.PrintException();
            }
        }

        private void GrabarComisionContratoExcluidos(DataGridViewRow[] rows)
        {
            try
            {
                List<ComisionContrato> lstCom = ObtenerComisionContratoExcluidos(rows);
                if (lstCom != null && lstCom.Count > 0)
                {
                    bool result = BLComision.InsertarComisionContratoExcluidos(lstCom);
                    if (!result)
                        _ = MessageBox.Show("Error al registrar los contratos excluidos", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                ex.PrintException2();
            }
        }

        private void ActualizarComisionContratoAExcluidos()
        {
            try
            {
                List<ComisionContrato> lstCom = ObtenerComisionContratoParaExcluir();
                if (lstCom != null && lstCom.Count > 0)
                {
                    bool result = BLComision.ActualizarEstadoControComisionAExcluidos(lstCom);
                    if (!result)
                        _ = MessageBox.Show("Error al registrar los contratos excluidos", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                ex.PrintException();
            }
        }

        private List<ComisionContrato> ObtenerComisionContratoParaExcluir()
        {
            DataGridViewRow[] arrRow = dgvContSinProces.Rows.Cast<DataGridViewRow>().Where(x => Convert.ToInt32(x.Cells["ID_PROCESO"].Value) > 0 && Convert.ToBoolean(x.Cells["CH"].Value)).ToArray();
            if (arrRow.Any())
            {
                List<ComisionContrato> lista = new List<ComisionContrato>();
                foreach (DataGridViewRow row in arrRow)
                {
                    lista.Add(new ComisionContrato
                    {
                        COD_SUCURSAL = row.Cells["COD_SUCURSAL"].Value.ToString(),
                        COD_CLASE = row.Cells["COD_CLASE"].Value.ToString(),
                        NRO_CONTRATO = row.Cells["NRO_CONTRATO"].Value.ToString(),
                        FE_AÑO = row.Cells["FE_AÑO"].Value.ToString(),
                        FE_MES = row.Cells["FE_MES"].Value.ToString(),
                        NRO_CUOTA = row.Cells["NRO_CUOTA"].Value.ToString(),
                        USUARIO = UsuarioSistema.Cod_usu,
                        ESTADO = (int)ESTADO_COMISION.REGISTRO_EXCLUIDO
                    });
                }
                return lista;
            }
            return null;
        }

        private List<ComisionContrato> ObtenerComisionContratoExcluidos(DataGridViewRow[] rows)
        {
            if (rows != null)
            {
                DataGridViewRow[] arrRow = rows.Where(x => Convert.ToInt32(x.Cells["ID_PROCESO"].Value) == 0).ToArray();
                if (arrRow.Length == 0)
                    return null;

                List<ComisionContrato> lista = new List<ComisionContrato>();
                foreach (DataGridViewRow row in arrRow)
                {
                    lista.Add(new ComisionContrato
                    {
                        COD_SUCURSAL = row.Cells["COD_SUCURSAL"].Value.ToString(),
                        COD_CLASE = row.Cells["COD_CLASE"].Value.ToString(),
                        NRO_CONTRATO = row.Cells["NRO_CONTRATO"].Value.ToString(),
                        FE_AÑO = row.Cells["FE_AÑO"].Value.ToString(),
                        FE_MES = row.Cells["FE_MES"].Value.ToString(),
                        FE_AÑO_PER = feAñoPer,
                        FE_MES_PER = feMesPer,
                        NRO_CUOTA = row.Cells["NRO_CUOTA"].Value.ToString(),
                        FECHA_APROB_INI = fechaAprobIni,
                        FECHA_APROB_FIN = fechaAprobFin,
                        FECHA_COBRA_INI = fechaCobraIni,
                        FECHA_COBRA_FIN = fechaCobraFin,
                        FE_AÑO_SIS = PeriodoSistema.AÑO,
                        FE_MES_SIS = PeriodoSistema.MES,
                        PERIODO_PROCESO = PERIODO_PROCESO_NINGUNO,
                        ID_COMISION_VEND = string.IsNullOrEmpty(row.Cells["ID_COMISION_VEND"].Value?.ToString()) ? 0 : Convert.ToInt32(row.Cells["ID_COMISION_VEND"].Value),
                        ID_COMISION_SUP = string.IsNullOrEmpty(row.Cells["ID_COMISION_SUP"].Value?.ToString()) ? 0 : Convert.ToInt32(row.Cells["ID_COMISION_SUP"].Value),
                        ID_COMISION_DIR_VTAS = string.IsNullOrEmpty(row.Cells["ID_COMISION_DIR_VTAS"].Value?.ToString()) ? 0 : Convert.ToInt32(row.Cells["ID_COMISION_DIR_VTAS"].Value),
                        ID_COMISION_DIR_NCNAL = string.IsNullOrEmpty(row.Cells["ID_COMISION_DIR_NCNAL"].Value?.ToString()) ? 0 : Convert.ToInt32(row.Cells["ID_COMISION_DIR_NCNAL"].Value),
                        USUARIO = UsuarioSistema.Cod_usu,
                        ESTADO = (int)ESTADO_COMISION.REGISTRO_EXCLUIDO
                    });
                }
                return lista;
            }
            return null;
        }

        private async void BtnQuitarExcluidos_Click(object sender, EventArgs e)
        {
            FrmLoading frmLoading = null;
            try
            {
                if (dgvContExcluidos.RowCount == 0 || dgvContExcluidos.Rows.Cast<DataGridViewRow>().Count(x => Convert.ToBoolean(x.Cells["CH"].Value)) == 0)
                    return;

                if (MessageBox.Show("¿Esta seguro de quitar los contratos de excluidos?", "MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    frmLoading = new FrmLoading()
                    {
                        Owner = this,
                        ShowInTaskbar = false
                    };
                    frmLoading.Show();

                    List<ComisionContrato> comTo = ObtenerComisionesContratoExcluidosEliminar();
                    Task<bool> task = Task<bool>.Factory.StartNew(() => BLComision.EliminarContratoComisionExcluidos(comTo));
                    bool result = await task;
                    frmLoading.Close();

                    if (result)
                    {
                        CargarContratosComisionExcluidosADgvContSinProces();
                        RemoverComisionContratoExcluidosDgv();
                        MostrarTotalesGenerales(dgvContExcluidos);
                        MostrarTotalesGenerales(dgvContSinProces);
                        ActualizarChkText(chkSelectTodo, dgvContSinProces);
                        ActualizarChkText(chkSelectTodo2, dgvContExcluidos);
                        _ = MessageBox.Show("Eliminado correctamente", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        _ = MessageBox.Show("Error al eliminar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                if (frmLoading != null)
                    frmLoading.Close();

                ex.PrintException();
            }
        }

        private List<ComisionContrato> ObtenerComisionesContratoExcluidosEliminar()
        {
            List<ComisionContrato> lista = new List<ComisionContrato>();
            foreach (DataGridViewRow row in dgvContExcluidos.Rows)
            {
                if (Convert.ToBoolean(row.Cells["CH"].Value))
                {
                    lista.Add(new ComisionContrato
                    {
                        COD_SUCURSAL = row.Cells["COD_SUCURSAL"].Value.ToString(),
                        COD_CLASE = row.Cells["COD_CLASE"].Value.ToString(),
                        NRO_CONTRATO = row.Cells["NRO_CONTRATO"].Value.ToString(),
                        FE_AÑO = row.Cells["FE_AÑO"].Value.ToString(),
                        FE_MES = row.Cells["FE_MES"].Value.ToString(),
                        NRO_CUOTA = row.Cells["NRO_CUOTA"].Value.ToString()
                    });
                }
            }
            return lista;
        }

        private void RemoverComisionContratoExcluidosDgv()
        {
            List<DataGridViewRow> lstRow = dgvContExcluidos.Rows.Cast<DataGridViewRow>().Where(x => Convert.ToBoolean(x.Cells["CH"].Value)).ToList();
            foreach (DataGridViewRow row in lstRow)
            {
                dgvContExcluidos.Rows.Remove(row);
            }

            dtContExcluidos = dgvContExcluidos.ConvertToDataTable();
        }

        private void CargarContratosComisionExcluidosADgvContSinProces()
        {
            if (dgvContSinProces.ColumnCount == 0)
                return;

            var lstDataRow = dgvContExcluidos.Rows.Cast<DataGridViewRow>().Where(x => Convert.ToBoolean(x.Cells["CH"].Value)).ToArray();
            var lstDataRow2 = dtContExcluidos.Rows.Cast<DataRow>().ToArray();
            var lstRow = from row in lstDataRow
                         join row2 in lstDataRow2 on row.Cells["NRO_CONTRATO"].Value.ToString() equals row2["NRO_CONTRATO"].ToString()
                         where row.Cells["COD_CLASE"].Value.ToString() == row2["COD_CLASE"].ToString() &&
                         row.Cells["COD_SUCURSAL"].Value.ToString() == row2["COD_SUCURSAL"].ToString() &&
                         row.Cells["FE_AÑO"].Value.ToString() == row2["FE_AÑO"].ToString() &&
                         row.Cells["FE_MES"].Value.ToString() == row2["FE_MES"].ToString() &&
                         row.Cells["NRO_CUOTA"].Value.ToString() == row2["NRO_CUOTA"].ToString()
                         select row2;

            dgvContSinProces.Rows.AddRange(lstDataRow.CloneWithValues());
            dtContSinProces.AddCloneRowsWithValues(lstRow.CopyToDataTable());
        }

        private async void BtnGenerarComExcluidos_Click(object sender, EventArgs e)
        {
            FrmLoading frmLoading = null;
            if (dgvContExcluidos.Rows.Count == 0 || dgvContExcluidos.Rows.Cast<DataGridViewRow>().Count(x => Convert.ToBoolean(x.Cells["CH"].Value)) == 0)
                return;

            if (MessageBox.Show($"¿Esta seguro de comisionar los contratos seleccionados para el período: \n { cboPeriodoGen.Text} ?", "MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    VerificarExistenciaComisionVendedores(dgvContExcluidos);
                    frmLoading = new FrmLoading()
                    {
                        Owner = this,
                        ShowInTaskbar = false
                    };
                    frmLoading.Show();
                    List<ComisionContrato> lstCom = ObtenerComisionContratoExcluidos();
                    if (lstCom != null)
                    {
                        bool result = false;
                        _ = await Task.Run(() => result = BLComision.ActualizarEstadoControComisionAProcesado(lstCom));
                        _ = result ? MessageBox.Show("Registrado Correctamente", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            : MessageBox.Show("Error al registrar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        CargarContratosComisionExcluidosADgvConProcesados();
                        RemoverComisionContratoExcluidosDgv();
                        MostrarTotalesGenerales(dgvContExcluidos);
                        MostrarTotalesGenerales(dgvContSinProces);
                        ActualizarChkText(chkSelectTodo, dgvContSinProces);
                        ActualizarChkText(chkSelectTodo2, dgvContExcluidos);
                    }

                    frmLoading.Close();
                }
                catch (Exception ex)
                {
                    if (frmLoading != null)
                        frmLoading.Close();

                    ex.PrintException2();
                }
            }
        }

        private List<ComisionContrato> ObtenerComisionContratoExcluidos()
        {
            if (!ValidarPeridoSeleccionado(out DataRow rowPeriodo))
                return null;

            string feAñoPer = rowPeriodo["FE_AÑO_PER"].ToString();
            string feMesPer = rowPeriodo["FE_MES_PER"].ToString();
            string periodoProceso = rowPeriodo["PERIODO_PROCESO"].ToString();

            List<ComisionContrato> lista = new List<ComisionContrato>();
            foreach (DataGridViewRow row in dgvContExcluidos.Rows)
            {
                if (Convert.ToBoolean(row.Cells["CH"].Value))
                {
                    lista.Add(new ComisionContrato
                    {
                        COD_SUCURSAL = row.Cells["COD_SUCURSAL"].Value.ToString(),
                        COD_CLASE = row.Cells["COD_CLASE"].Value.ToString(),
                        NRO_CONTRATO = row.Cells["NRO_CONTRATO"].Value.ToString(),
                        FE_AÑO = row.Cells["FE_AÑO"].Value.ToString(),
                        FE_MES = row.Cells["FE_MES"].Value.ToString(),
                        FE_AÑO_PER = feAñoPer,
                        FE_MES_PER = feMesPer,
                        PERIODO_PROCESO = periodoProceso,
                        NRO_CUOTA = row.Cells["NRO_CUOTA"].Value.ToString(),
                        FE_AÑO_SIS = PeriodoSistema.AÑO,
                        FE_MES_SIS = PeriodoSistema.MES,
                        USUARIO = UsuarioSistema.Cod_usu,
                        ESTADO = (int)ESTADO_COMISION.REGISTRO_PROCESADO
                    });
                }
            }
            return lista;
        }

        private void CargarContratosComisionExcluidosADgvConProcesados()
        {
            if (dgvContSinProces.ColumnCount == 0)
                return;

            var lstDataRow = dgvContExcluidos.Rows.Cast<DataGridViewRow>().Where(x => Convert.ToBoolean(x.Cells["CH"].Value)).ToArray();
            var lstDataRow2 = dtContExcluidos.Rows.Cast<DataRow>().ToArray();
            var lstRow = from row in lstDataRow
                         join row2 in lstDataRow2 on row.Cells["NRO_CONTRATO"].Value.ToString() equals row2["NRO_CONTRATO"].ToString()
                         where row.Cells["COD_CLASE"].Value.ToString() == row2["COD_CLASE"].ToString() &&
                         row.Cells["COD_SUCURSAL"].Value.ToString() == row2["COD_SUCURSAL"].ToString() &&
                         row.Cells["FE_AÑO"].Value.ToString() == row2["FE_AÑO"].ToString() &&
                         row.Cells["FE_MES"].Value.ToString() == row2["FE_MES"].ToString() &&
                         row.Cells["NRO_CUOTA"].Value.ToString() == row2["NRO_CUOTA"].ToString()
                         select row2;
            if (lstDataRow.Length > 0)
                lstDataRow.ToList().ForEach(x => x.Cells["CH"].Value = false);
            dgvContSinProces.Rows.AddRange(lstDataRow.CloneWithValues());
            dtContSinProces.AddCloneRowsWithValues(lstRow.CopyToDataTable());
            if (lstDataRow.Length > 0)
                lstDataRow.ToList().ForEach(x => x.Cells["CH"].Value = true);
        }

        private void ChkSelecTodo_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox ch = sender as CheckBox;
            if (ch.Name == chkSelectTodo.Name)
            {

                dgvContSinProces.Rows.Cast<DataGridViewRow>().ToList().ForEach(x => x.Cells["CH"].Value = ch.Checked);
                ActualizarChkText(ch, dgvContSinProces);
            }
            else if (ch.Name == chkSelectTodo2.Name)
            {
                dgvContExcluidos.Rows.Cast<DataGridViewRow>().ToList().ForEach(x => x.Cells["CH"].Value = ch.Checked);
                ActualizarChkText(ch, dgvContExcluidos);
            }
        }

        private void DgvContSinProces_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            DataGridView dataGrid = sender as DataGridView;
            if (dataGrid.IsCurrentCellDirty)
            {
                dataGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void DgvContSinProces_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGrid = sender as DataGridView;
            if (dataGrid.CurrentCell != null)
            {
                if (dataGrid.Columns[e.ColumnIndex].Name == "CH")
                {
                    if (dataGrid.Name == dgvContSinProces.Name)
                        ActualizarChkText(chkSelectTodo, dataGrid);
                    else if (dataGrid.Name == dgvContExcluidos.Name)
                        ActualizarChkText(chkSelectTodo2, dataGrid);
                }
            }
        }

        private void ActualizarChkText(CheckBox ch, DataGridView dataGrid)
        {
            if (dataGrid != null && dataGrid.Rows.Count > 0)
            {
                int cantidad = dataGrid.Rows.Cast<DataGridViewRow>().Count(x => Convert.ToBoolean(x.Cells["CH"].Value));
                ch.Text = string.Format(chkText, cantidad);
            }
            else
                ch.Text = string.Format(chkText, 0);
        }

        /// <summary>
        /// Este método sirve para aprobar y desaprobar comisión, según las condiciones
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAprobarComision_Click(object sender, EventArgs e)
        {
            string message = string.Empty;
            if (estadoComision == ESTADO_COMISION.REGISTRO_PROCESADO)
            {
                if (!ValidarAprobarComision())
                    return;
                message = "¿Esta seguro de cerrar las comisiones del periodo \n";
            }
            else if (estadoComision == ESTADO_COMISION.REGISTRO_APROBADO)
            {
                if (!ValidarDesaprobarComision())
                    return;
                message = "¿Esta seguro de abrir las comisiones del periodo \n";
            }

            if (message.Length == 0)
                return;

            if (MessageBox.Show(string.Concat(message, cboPeriodoGen.Text, "?"), "MESSAGE",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                FrmConfirmar frmConfirmar = new FrmConfirmar(TIPO_CONFIRMAR.COMISION)
                {
                    StartPosition = FormStartPosition.CenterScreen
                };
                frmConfirmar.EventClick += FrmConfirmar_EventClick;
                frmConfirmar.ShowDialog();
            }
        }

        /// <summary>
        /// Este método sirve para aprobar y desaprobar comisión, según las condiciones
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmConfirmar_EventClick(object sender, EventArgs e)
        {
            if (estadoComision == ESTADO_COMISION.REGISTRO_PROCESADO)
                AprobarComision();
            else if (estadoComision == ESTADO_COMISION.REGISTRO_APROBADO)
                DesaprobarComision();
        }

        private void AprobarComision()
        {
            try
            {
                List<ComisionContrato> lstCom = null;
                if (estadoComision == ESTADO_COMISION.REGISTRO_PROCESADO)
                    lstCom = ObtenerComisionContratoParaAprobar();

                if (lstCom != null)
                {
                    _ = BLComision.AprobarComisionesContrato(lstCom)
                        ? MessageBox.Show("Aprobado Correctamente", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        : MessageBox.Show("Error al aprobar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgvContSinProces.Rows.Clear();
                    CargarPeriodoGeneradoComision();
                    MostrarTotalesGenerales(dgvContSinProces);
                    MostrarStatusMensaje(null, lblMessage, string.Empty, ESTADO_COMISION.NONE);
                    ActualizarChkText(chkSelectTodo, dgvContSinProces);
                }
            }
            catch (Exception ex)
            {
                ex.PrintException();
            }
        }

        private void DesaprobarComision()
        {
            try
            {
                List<ComisionContrato> lstCom = null;
                if (estadoComision == ESTADO_COMISION.REGISTRO_APROBADO)
                    lstCom = ObtenerComisionContratoParaDesaprobar();

                if (lstCom != null)
                {
                    _ = BLComision.DesaprobarComisionesContrato(lstCom)
                        ? MessageBox.Show("Desaprobado Correctamente", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        : MessageBox.Show("Error al desaprobar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgvContAprobados.Rows.Clear();
                    CargarPeriodoGeneradoComision();
                    MostrarTotalesGenerales(dgvContAprobados);
                    MostrarStatusMensaje(null, lblMessage2, string.Empty, ESTADO_COMISION.NONE);
                    ActualizarChkText(chkSelectTodo, dgvContAprobados);
                }
            }
            catch (Exception ex)
            {
                ex.PrintException();
            }
        }

        private List<ComisionContrato> ObtenerComisionContratoParaAprobar()
        {
            DataGridViewRow[] arrRow = dgvContSinProces.Rows.Cast<DataGridViewRow>().Where(x => Convert.ToInt32(x.Cells["ID_PROCESO"].Value) > 0).ToArray();
            int cantidad = arrRow.Count();
            if (cantidad == 0) return null;

            List<ComisionContrato> lista = new List<ComisionContrato>();
            ComisionContrato[] arrCom = new ComisionContrato[cantidad];
            int io = 0;
            foreach (DataGridViewRow row in arrRow)
            {
                ComisionContrato com = new ComisionContrato
                {
                    COD_SUCURSAL = row.Cells["COD_SUCURSAL"].Value.ToString(),
                    COD_CLASE = row.Cells["COD_CLASE"].Value.ToString(),
                    NRO_CONTRATO = row.Cells["NRO_CONTRATO"].Value.ToString(),
                    FE_AÑO = row.Cells["FE_AÑO"].Value.ToString(),
                    FE_MES = row.Cells["FE_MES"].Value.ToString(),
                    NRO_CUOTA = row.Cells["NRO_CUOTA"].Value.ToString(),
                    USUARIO = UsuarioSistema.Cod_usu,
                    ESTADO = (int)ESTADO_COMISION.REGISTRO_APROBADO
                };
                arrCom[io] = com;
                io += 1;
            }
            lista.AddRange(arrCom);
            return lista;
        }

        private List<ComisionContrato> ObtenerComisionContratoParaDesaprobar()
        {
            DataGridViewRow[] arrRow = dgvContAprobados.Rows.Cast<DataGridViewRow>().Where(x => Convert.ToInt32(x.Cells["ID_PROCESO"].Value) > 0).ToArray();
            int cantidad = arrRow.Count();
            if (cantidad == 0) return null;

            List<ComisionContrato> lista = new List<ComisionContrato>();
            ComisionContrato[] arrCom = new ComisionContrato[cantidad];
            int io = 0;
            foreach (DataGridViewRow row in arrRow)
            {
                ComisionContrato com = new ComisionContrato
                {
                    COD_SUCURSAL = row.Cells["COD_SUCURSAL"].Value.ToString(),
                    COD_CLASE = row.Cells["COD_CLASE"].Value.ToString(),
                    NRO_CONTRATO = row.Cells["NRO_CONTRATO"].Value.ToString(),
                    FE_AÑO = row.Cells["FE_AÑO"].Value.ToString(),
                    FE_MES = row.Cells["FE_MES"].Value.ToString(),
                    NRO_CUOTA = row.Cells["NRO_CUOTA"].Value.ToString(),
                    USUARIO = UsuarioSistema.Cod_usu,
                    ESTADO = (int)ESTADO_COMISION.REGISTRO_PROCESADO
                };
                arrCom[io] = com;
                io += 1;
            }
            lista.AddRange(arrCom);
            return lista;
        }

        private bool ValidarAprobarComision()
        {
            if (dgvContSinProces.Rows.Count == 0 || tabControl1.SelectedTab != tabPage1)
                return false;

            if (estadoComision == ESTADO_COMISION.NONE || estadoComision == ESTADO_COMISION.REGISTRO_PENDIENTE)
            {
                _ = MessageBox.Show("Seleccione primero un periodo generado de comisión para aprobar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            DataRow rw = dtPeridoGenerado.Select("ID = " + Convert.ToInt32(cboPeriodoGen.SelectedValue)).Single();
            if (rw == null || rw.ItemArray.Length == 0)
            {
                _ = MessageBox.Show("No existe un perido generado de comisión donde aprobar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private bool ValidarDesaprobarComision()
        {
            if (dgvContAprobados.Rows.Count == 0 || tabControl1.SelectedTab != tabPageAprobados)
                return false;

            if (estadoComision == ESTADO_COMISION.NONE || estadoComision == ESTADO_COMISION.REGISTRO_PENDIENTE)
            {
                _ = MessageBox.Show("Seleccione primero un periodo generado de comisión para aprobar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            DataRow rw = dtPeridoGenerado.Select("ID = " + Convert.ToInt32(cboPeriodoGen.SelectedValue)).Single();
            if (rw == null || rw.ItemArray.Length == 0)
            {
                _ = MessageBox.Show("No existe un perido generado de comisión donde aprobar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private async void BtnRecalcularComision_Click(object sender, EventArgs e)
        {
            FrmLoading frmLoading = null;
            try
            {
                if (MessageBox.Show("Esta seguro de recalcular comisión", "MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    return;

                frmLoading = new FrmLoading()
                {
                    Owner = this,
                    ShowInTaskbar = false,
                };
                frmLoading.Show();
                _ = await RecalcularComision();
                ListarComisionContratosProcesados();

                if (frmLoading != null)
                    frmLoading.Close();
            }
            catch (Exception ex)
            {
                ex.PrintException();
                if (frmLoading != null)
                    frmLoading.Close();
            }
        }

        private async Task<bool> RecalcularComision()
        {
            if (ValidarRecalcularComision())
            {
                DataTable dt = ObtenerDataRecalcularComision();
                if (dt != null && dt.Rows.Count > 0)
                {
                    bool result = await Task.Run(() => BLComision.RecalcularComisionContrato(dt, fechaCobraIni));
                    bool result2 = await Task.Run(() => BLComision.RecalcularComisionContrato2(dt, fechaCobraIni));

                    _ = result || result2 ? MessageBox.Show("Recalculado correctamente", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    : MessageBox.Show("No se recalculó ningún registro", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return result || result2;
                }
            }
            return true;
        }

        private bool ValidarRecalcularComision()
        {
            var eDataGridView = tabControl1.SelectedTab.Controls.OfType<DataGridView>();
            DataGridView dgv = eDataGridView.Any() ? eDataGridView.First() : null;
            if (dgv == null || dgv.Rows.Cast<DataGridViewRow>().Count(x => x.Cells["CH"].Value.ToBoolean()) == 0)
                return false;
            return true;
        }

        private DataTable ObtenerDataRecalcularComision()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("COD_SUCURSAL", typeof(string));
            dt.Columns.Add("COD_CLASE", typeof(string));
            dt.Columns.Add("NRO_CONTRATO", typeof(string));
            dt.Columns.Add("FE_AÑO", typeof(string));
            dt.Columns.Add("FE_MES", typeof(string));
            dt.Columns.Add("NRO_CUOTA", typeof(string));
            DataGridView dgv = tabControl1.SelectedTab.Controls.OfType<DataGridView>().First();
            DataGridViewRow[] arrRow = dgv.Rows.Cast<DataGridViewRow>().Where(x => x.Cells["CH"].Value.ToBoolean()).ToArray();
            foreach (DataGridViewRow row in arrRow)
            {
                DataRow rw = dt.NewRow();
                foreach (DataColumn column in dt.Columns)
                {
                    rw[column.ColumnName] = row.Cells[column.ColumnName].Value;
                }
                dt.Rows.Add(rw);
            }
            return dt;
        }

        private async void BtnPasarContrAPendientes_Click(object sender, EventArgs e)
        {
            try
            {
                //> Falta actualizar todo este procedimiento por eso esta deshabilitado el botton
                DataTable dtPeriodoGen = BLComision.ObtenerPeriodosGeneradosComision();
                if (dtPeriodoGen != null && dtPeridoGenerado.Rows.Count > 0)
                {
                    FrmLoading frmLoading = new FrmLoading()
                    {
                        Owner = this,
                        ShowInTaskbar = false
                    };
                    frmLoading.Show();

                    DataRow row = dtPeriodoGen.Rows[dtPeriodoGen.Rows.Count - 1];
                    int fe_año = row["FE_AÑO_PER"].ToInt32();
                    int fe_mes = row["FE_MES_PER"].ToInt32();
                    DateTime fechaAprobIni = new DateTime(2019, 1, 1);
                    DateTime fechaAprobFin = DateTime.Now;
                    DateTime fechaCobraIni = new DateTime(fe_año, fe_mes, 1);
                    DateTime fechaCobraFin = new DateTime(fe_año, fe_mes, DateTime.DaysInMonth(fe_año, fe_mes));
                    string codPrograma = cboPrograma.SelectedValue.ToString();
                    string codInstitucion = cboInstitucion.SelectedValue.ToString();
                    string codTipoPlla = cboTipoVenta.SelectedValue.ToString();
                    string nroCuota = cboNroCuota.SelectedValue.ToString();
                    DataTable dt = await Task.Run(() => BLComision.ListarContratosPendientes(fechaAprobFin, fechaCobraFin, codPrograma, codInstitucion, codTipoPlla, nroCuota));
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        List<ComisionContrato> lstCom = ObtenerComisionContratoExcluidos(dt, fechaAprobIni, fechaAprobFin, fechaCobraIni, fechaCobraFin);
                        if (lstCom != null && lstCom.Count > 0)
                        {
                            bool result = await Task.Run(() => BLComision.InsertarComisionContratoExcluidos(lstCom));
                            if (result)
                                _ = MessageBox.Show($"Registrado correctamente: {dt.Rows.Count}", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                _ = MessageBox.Show("Error al registrar los contratos excluidos", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }
                    else
                        _ = MessageBox.Show("No se encontraron contratos para registrar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmLoading.Close();
                }
            }
            catch (Exception ex)
            {
                ex.PrintException2();
            }
        }

        private List<ComisionContrato> ObtenerComisionContratoExcluidos(DataTable dt, DateTime fechAprobIni, DateTime fechAprobFin, DateTime fechCobraIni, DateTime fechCobraFin)
        {
            if (dt != null)
            {
                if (dt.Rows.Count == 0)
                    return null;

                List<ComisionContrato> lista = new List<ComisionContrato>();
                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(new ComisionContrato
                    {
                        COD_SUCURSAL = row["COD_SUCURSAL"].ToString(),
                        COD_CLASE = row["COD_CLASE"].ToString(),
                        NRO_CONTRATO = row["NRO_CONTRATO"].ToString(),
                        FE_AÑO = row["FE_AÑO"].ToString(),
                        FE_MES = row["FE_MES"].ToString(),
                        FE_AÑO_PER = fechCobraFin.Year.ToString(),
                        FE_MES_PER = fechCobraFin.Month <= 9 ? string.Concat("0", fechCobraFin.Month.ToString()) : fechCobraFin.Month.ToString(),
                        NRO_CUOTA = row["NRO_CUOTA"].ToString(),
                        FECHA_APROB_INI = fechAprobIni,
                        FECHA_APROB_FIN = fechAprobFin,
                        FECHA_COBRA_INI = fechCobraIni,
                        FECHA_COBRA_FIN = fechCobraFin,
                        FE_AÑO_SIS = PeriodoSistema.AÑO,
                        FE_MES_SIS = PeriodoSistema.MES,
                        PERIODO_PROCESO = PERIODO_PROCESO_NINGUNO,
                        ID_COMISION_VEND = string.IsNullOrEmpty(row["ID_COMISION_VEND"]?.ToString()) ? 0 : Convert.ToInt32(row["ID_COMISION_VEND"]),
                        ID_COMISION_SUP = string.IsNullOrEmpty(row["ID_COMISION_SUP"]?.ToString()) ? 0 : Convert.ToInt32(row["ID_COMISION_SUP"]),
                        ID_COMISION_DIR_VTAS = string.IsNullOrEmpty(row["ID_COMISION_DIR_VTAS"]?.ToString()) ? 0 : Convert.ToInt32(row["ID_COMISION_DIR_VTAS"]),
                        ID_COMISION_DIR_NCNAL = string.IsNullOrEmpty(row["ID_COMISION_DIR_NCNAL"]?.ToString()) ? 0 : Convert.ToInt32(row["ID_COMISION_DIR_NCNAL"]),
                        USUARIO = UsuarioSistema.Cod_usu,
                        ESTADO = (int)ESTADO_COMISION.REGISTRO_EXCLUIDO
                    });
                }
                return lista;
            }
            return null;
        }

        private void CboNivelVenta_SelectionChangeCommitted(object sender, EventArgs e)
        {
            _ = txtNombreVendedor.Focus();
        }

        private void TipoFechaVigenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTipoFechaVigenciaComision frmTipoVigencia = FrmTipoFechaVigenciaComision.Instancia();
            frmTipoVigencia.Owner = this;
            frmTipoVigencia.ShowDialog();
        }
    }
}
