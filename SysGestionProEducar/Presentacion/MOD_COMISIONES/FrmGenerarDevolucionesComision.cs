using BLL;
using Entidades;
using Presentacion.HELPERS.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Presentacion.HELPERS.AppearanceUtil;
using static Presentacion.HELPERS.ErrorPrint;
using static Presentacion.HELPERS.FormatDataGridViewColumns;
using static Presentacion.HELPERS.GenericMethod;
using static Presentacion.HELPERS.GenericUtil;

namespace Presentacion.MOD_COMISIONES
{
    public partial class FrmGenerarDevolucionesComision : Form
    {
        public FrmGenerarDevolucionesComision()
        {
            InitializeComponent();
        }

        private readonly comisionesBLL BLComision = new comisionesBLL();
        private readonly programaBLL BLPrograma = new programaBLL();
        private readonly institucionesBLL BLInstitucion = new institucionesBLL();
        private readonly directorioBLL BLDirectorio = new directorioBLL();
        private readonly nivelBLL BLNivel = new nivelBLL();

        private DataTable dtDevolucionContrato, dtDevolucionCancelado, dtDevolucionAnulado, dtPeridoGenerado;
        private List<directorioTo> lstDir;
        private string feAñoPer, feMesPer, feMesPerName;
        private TIPO_REGISTRO tipoLista;
        private ESTADO_REGISTRO estadoRegistro;
        private string siNoValorAnterior;
        private delegate void DelMostrarMensaje(DataTable dt, Label lblMessage, string mensaje);

        private const string NAME_COLUMN1 = "IMPORTE_DESCONTAR";
        private const string NAME_COLUMN2 = "COD_MOTIVO_NO_DSCTO_COMBO";
        private const string NAME_COLUMN3 = "SI_NO_DESCONTAR";
        private const string NAME_COLUMN4 = "IMP_DSCTADO_ACUMULADO";
        private const string SI_DESCONTAR = "S";
        private const string NO_DESCONTAR = "N";
        private const string COD_NIVEL_VENDEDOR = "04";
        private const string COD_NIVEL_SUPERVISOR = "03";
        private const string COD_NIVEL_DIR_VENTAS = "02";
        private const string COD_NIVEL_DIR_NACIONAL = "01";
        private const string MENSAJE_GENERADO = "GENERADO | {0}";
        private const string MENSAJE_CERRADO = "CERRADO | {0}";
        private const string MENSAJE_PENDIENTE = "PENDIENTE POR GENERAR";
        private const string COD_MOTIVO_NO_DSCTO_900 = "900";

        private void FrmGenerarDevolucionesComision_Load(object sender, EventArgs e)
        {
            StartControls();
            CargarPrograma();
            CagarInstitucion();
            CargarMeses();
            CargarPeriodoGeneradoDevolucion();
            CargarNivelVenta();
        }

        private void StartControls()
        {
            dtFechaAprobIni.Value = new DateTime(2019, 1, 1);
            dtFechaAprobFin.Value = DateTime.Now;
            //> dtFechaDevolIni.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            //> dtFechaDevolFin.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));

            btnConsultarCtrats.StyleButtonFlat();
            btnGenerar.StyleButtonFlat();
            btnAprobarComision.StyleButtonFlat();
            btnRegistrarCuotaVigencia.StyleButtonFlat();
            btnRevertirDevPeriodo.StyleButtonFlat();
            btnEliminarDev.StyleButtonFlat();
            btnBuscarDevContrato.StyleButtonFlat();

            FormatCombobox(cboPrograma);
            FormatCombobox(cboInstitucion);
            FormatCombobox(cboPeriodoGen);
            FormatCombobox(cboMes);
            FormatCombobox(cboNivelVenta);
            FormatCombobox(cboNivelVenta2);
            FormatCombobox(cboNivelVenta3);

            dgvDevolucionCom.Style5(false, false, false, false, false, DataGridViewTriState.True, DataGridViewColumnHeadersHeightSizeMode.AutoSize, DataGridViewTriState.True, DataGridViewAutoSizeRowsMode.AllCells,
                 DataGridViewSelectionMode.FullRowSelect);
            dgvDevolucionCancelado.Style5(false, false, false, false, false, DataGridViewTriState.True, DataGridViewColumnHeadersHeightSizeMode.AutoSize, DataGridViewTriState.True, DataGridViewAutoSizeRowsMode.AllCells,
                 DataGridViewSelectionMode.FullRowSelect);
            dgvDevolucionAnulado.Style5(false, false, false, false, false, DataGridViewTriState.True, DataGridViewColumnHeadersHeightSizeMode.AutoSize, DataGridViewTriState.True, DataGridViewAutoSizeRowsMode.AllCells,
                 DataGridViewSelectionMode.FullRowSelect);
            btnButton.StyleButtonFlat(Color.Teal, Color.White, Color.Teal, 1);

            estadoRegistro = ESTADO_REGISTRO.NONE;
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

        private void CargarMeses()
        {
            cboMes.ValueMember = "value";
            cboMes.DisplayMember = "name";
            cboMes.DataSource = UtilMeses();
        }

        private void CargarPeriodoGeneradoDevolucion()
        {
            dtPeridoGenerado = BLComision.ObtenerPeriodosDevolucionComisionGenerados();
            if (dtPeridoGenerado != null && dtPeridoGenerado.Columns.Count > 0)
            {
                DataRow row = dtPeridoGenerado.NewRow();
                row["ID"] = 0;
                row["FE_AÑO_PER"] = "";
                row["FE_MES_PER"] = "";
                row["ESTADO"] = (int)ESTADO_REGISTRO.NONE;
                row["PERIODO_TEXT"] = "Seleccione";
                dtPeridoGenerado.Rows.InsertAt(row, 0);

                cboPeriodoGen.SelectedValueChanged -= CboPeriodoGen_SelectedValueChanged;
                cboPeriodoGen.ValueMember = "ID";
                cboPeriodoGen.DisplayMember = "PERIODO_TEXT";
                cboPeriodoGen.DataSource = dtPeridoGenerado;
                cboPeriodoGen.SelectedValueChanged += CboPeriodoGen_SelectedValueChanged;
            }
        }

        private void ActualizarDtPeridoGenerado()
        {
            dtPeridoGenerado = BLComision.ObtenerPeriodosDevolucionComisionGenerados();
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
            ListarContratosParaGenerarDevolucionComision();
            estadoRegistro = ESTADO_REGISTRO.REGISTRO_PENDIENTE;
        }

        private async void ListarContratosParaGenerarDevolucionComision()
        {
            FrmLoading frmLoading = null;
            try
            {
                frmLoading = frmLoading.StartLoadingForm(this);
                tipoLista = TIPO_REGISTRO.NUEVO;
                feAñoPer = dtAño.Value.Year.ToString();
                feMesPer = cboMes.SelectedValue.ToString();
                feMesPerName = cboMes.Text;
                DateTime fechaAprobIni = dtFechaAprobIni.Value;
                DateTime fechaAprobFin = dtFechaAprobFin.Value;
                DateTime fechaDevolIni = dtFechaDevolIni.Value;
                DateTime fechaDevolFin = dtFechaDevolFin.Value;
                string codPrograma = cboPrograma.SelectedValue.ToString();
                string codInstitucion = cboInstitucion.SelectedValue.ToString();
                Task<DataTable> task = Task<DataTable>.Factory.StartNew(()
                    => BLComision.ListarDevolucionComisionContratos(fechaAprobIni, fechaAprobFin, fechaDevolIni, fechaDevolFin, codPrograma, codInstitucion));
                dtDevolucionContrato = await task;
                dgvDevolucionCom.CellValueChanged -= DgvDevolucionCom_CellValueChanged;
                CargarDgv(dgvDevolucionCom, dtDevolucionContrato);
                dgvDevolucionCom.CellValueChanged += DgvDevolucionCom_CellValueChanged;
                MostrarTotalesGenerales(dgvDevolucionCom);
                VerificarParaMostrarMensaje(dtDevolucionContrato);
                frmLoading.CloseLoadingForm();
                MostrarMensaje(dtDevolucionContrato);
            }
            catch (Exception ex)
            {
                frmLoading.CloseLoadingForm();
                ex.PrintException();
            }

            void MostrarMensaje(DataTable dt)
            {
                if (dt == null || dt.Rows.Count == 0)
                    _ = MessageBox.Show($"No existe devuluciones en este período: {feMesPer.ToInt32().NombreMes()} - {feAñoPer}", "MESSAGE",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void ListarDevolucionComisionGenerados()
        {
            FrmLoading frmLoading = new FrmLoading()
            {
                Owner = this,
                ShowInTaskbar = false
            };
            frmLoading.Show();
            try
            {
                tipoLista = TIPO_REGISTRO.EXISTENTE;
                DataRow row = ObtenerPeriodoSeleccionado();
                if (row == null || row.ItemArray.Length == 0)
                    return;
                string feAñoPer = row["FE_AÑO_PER"].ToString();
                string feMesPer = row["FE_MES_PER"].ToString();
                this.feAñoPer = feAñoPer;
                this.feMesPer = feMesPer;
                feMesPerName = new DateTime(this.feAñoPer.ToInt32(), this.feMesPer.ToInt32(), 1).ToString("MMM");
                Task<DataTable> task = Task<DataTable>.Factory.StartNew(()
                    => BLComision.ListarDevolucionComisionContratosGenerados(feAñoPer, feMesPer));
                dtDevolucionContrato = await task;
                dgvDevolucionCom.CellValueChanged -= DgvDevolucionCom_CellValueChanged;
                CargarDgv(dgvDevolucionCom, dtDevolucionContrato);
                AgregarFilaNuevoPeriodo(dgvDevolucionCom);
                ReafactorizarDatosDgv(dgvDevolucionCom);
                dgvDevolucionCom.CellValueChanged += DgvDevolucionCom_CellValueChanged;
                MostrarTotalesGenerales(dgvDevolucionCom);
                ActualizarDatosSegunCerrarAbrirPeriodo();
                frmLoading.Close();
            }
            catch (Exception ex)
            {
                frmLoading.Close();
                ex.PrintException();
            }
        }

        private async void ListarDevolucionComisionGenCancelado()
        {
            FrmLoading frmLoading = null;
            try
            {
                frmLoading = frmLoading.StartLoadingForm(this);
                DevolucionComisionITo to = new DevolucionComisionITo
                {
                    FE_AÑO_PER = feAñoPer,
                    FE_MES_PER = feMesPer
                };

                
                Task<DataTable> task = Task<DataTable>.Factory.StartNew(()
                    => BLComision.ListarDevolucionComisionGenCancelados(to));
                dtDevolucionCancelado = await task;
                CargarDgv(dgvDevolucionCancelado, dtDevolucionCancelado);
                AgregarFilaNuevoPeriodo(dgvDevolucionCancelado);
                ReafactorizarDatosDgv(dgvDevolucionCancelado);
                MostrarTotalesGenerales(dgvDevolucionCancelado);
                frmLoading.CloseLoadingForm();
            }
            catch (Exception ex)
            {
                frmLoading.CloseLoadingForm();
                ex.PrintException();
            }
        }

        private async void ListarDevolucionComisionGenAnulados()
        {
            FrmLoading frmLoading = null;
            try
            {
                frmLoading = frmLoading.StartLoadingForm(this);
                DevolucionComisionITo to = new DevolucionComisionITo
                {
                    FE_AÑO_PER = feAñoPer,
                    FE_MES_PER = feMesPer
                };
                Task<DataTable> task = Task<DataTable>.Factory.StartNew(()
                    => BLComision.ListarDevolucionComisionGenAnulados(to));
                dtDevolucionAnulado = await task;
                CargarDgv(dgvDevolucionAnulado, dtDevolucionAnulado);
                AgregarFilaNuevoPeriodo(dgvDevolucionAnulado);
                ReafactorizarDatosDgv(dgvDevolucionAnulado);
                MostrarTotalesGenerales(dgvDevolucionAnulado);
                frmLoading.CloseLoadingForm();
            }
            catch (Exception ex)
            {
                frmLoading.CloseLoadingForm();
                ex.PrintException();
            }
        }

        private void CargarDgv(DataGridView dataGrid, DataTable dt)
        {
            dataGrid.Rows.Clear();
            if (dataGrid.Columns.Count == 0)
            {
                AddRangeColumnsDataGridView(dataGrid, dt, false);
                AgregarColumnaCombobox(dataGrid);
                AjusteColumnas(dataGrid);
            }

            dataGrid.AddRangeRowsDataGridView(dt);
            EstablecerValorSelectCombobox(dataGrid);
        }

        public void AddRangeColumnsDataGridView(DataGridView dataGrid, DataTable dt, bool defaulDataType)
        {
            if (dt != null)
            {
                if (dataGrid.Columns.Count == 0)
                {
                    DataGridViewColumn[] arrColumns = new DataGridViewColumn[dt.Columns.Count];
                    DataGridViewColumn col;
                    int io = 0;
                    foreach (DataColumn column in dt.Columns)
                    {
                        if (column.DataType == typeof(bool))
                            col = new DataGridViewCheckBoxColumn
                            {
                                Name = column.ColumnName,
                                ValueType = column.DataType
                            };
                        else if (column.ColumnName == NAME_COLUMN4)
                        {
                            col = new DataGridViewLinkColumn
                            {
                                Name = column.ColumnName,
                                ValueType = defaulDataType ? typeof(string) : column.DataType,
                                LinkColor = Color.DarkGreen,
                                ActiveLinkColor = Color.DarkGreen,
                                VisitedLinkColor = Color.DarkGreen
                            };
                        }
                        else
                            col = new DataGridViewTextBoxColumn
                            {
                                Name = column.ColumnName,
                                ValueType = defaulDataType ? typeof(string) : column.DataType
                            };
                        arrColumns[io] = col;
                        io += 1;
                    }
                    dataGrid.Columns.AddRange(arrColumns);
                }
            }
        }

        /// <summary>
        /// Aplica color de fondo de cada contrato, actualiza el saldo por cada grupo de fila y borra datos de celdas para no mostrar
        /// </summary>
        /// <param name="dataGrid"></param>
        private void ReafactorizarDatosDgv(DataGridView dataGrid)
        {
            if (dataGrid != null)
            {
                Color color = Color.LightGray;
                decimal saldo = 0;
                string nroContrato = "";
                foreach (DataGridViewRow row in dataGrid.Rows)
                {
                    ColorFondoDgv(row, ref nroContrato, ref color);
                    CalcularSaldos(row, ref saldo);
                    AsignarValorNuloComboboxMotivoDescto(row);
                    if (row.Cells["X"].Value.ToInt32() != 1)
                    {
                        

                        row.Cells["NRO_CONTRATO"].Tag = row.Cells["NRO_CONTRATO"].Value;
                        row.Cells["NRO_CONTRATO"].Value = string.Empty;
                        row.Cells["FECHA_CONTRATO"].Tag = row.Cells["FECHA_CONTRATO"].Value;
                        row.Cells["FECHA_CONTRATO"].Value = string.Empty;
                        row.Cells["FECHA_APROBACION"].Tag = row.Cells["FECHA_APROBACION"].Value;
                        row.Cells["FECHA_APROBACION"].Value = string.Empty;
                        row.Cells["CANT_CUOTA_PAGADA"].Value = string.Empty;
                        row.Cells["IMP_COUTA_MES"].Value = string.Empty;
                        row.Cells["TOTAL_CUOTA_PAGADA"].Value = string.Empty;
                        row.Cells["FECHA_DEVOLUCION"].Tag = row.Cells["FECHA_DEVOLUCION"].Value;
                        row.Cells["FECHA_DEVOLUCION"].Value = string.Empty;
                        row.Cells["NRO_PLANILLA_DEV"].Tag = row.Cells["NRO_PLANILLA_DEV"].Value;
                        row.Cells["NRO_PLANILLA_DEV"].Value = string.Empty;
                        row.Cells["NIVEL_VENTA"].Value = string.Empty;
                        row.Cells["DESC_NIVEL_VENTA"].Value = string.Empty;
                    }

                    if (row.Cells["X"].Value.ToInt32() != 0)
                    {
                        row.Cells["IMP_DSCTADO_ACUMULADO"].Value = string.Empty;
                        row.Cells["IMPORTE_DESCONTAR"].Value = string.Empty;
                        row.Cells["PERIODO_DSCTO"].Value = string.Empty;
                        row.Cells["SALDO_COMISION_XDESCONTAR"].Value = string.Empty;
                        row.Cells["SI_NO_DESCONTAR"].Value = string.Empty;
                        row.Cells["COD_MOTIVO_NO_DSCTO_COMBO"].Value = null;
                    }

                    if (row.Cells["X"].Value.ToInt32() > 1)
                    {
                        row.Cells["CLIENTE"].Tag = row.Cells["CLIENTE"].Value;
                        row.Cells["CLIENTE"].Value = string.Empty;
                    }
                }
            }
        }

        /// <summary>
        /// Pinta con un color cada fila por cada número de contrato
        /// </summary>
        /// <param name="row"></param>
        /// <param name="nroContrato"></param>
        /// <param name="color"></param>
        private void ColorFondoDgv(DataGridViewRow row, ref string nroContrato, ref Color color)
        {
            color = row.Cells["NRO_CONTRATO"].Value.ToString() == nroContrato ? color : color == Color.White ? Color.LightGray : Color.White;
            nroContrato = row.Cells["NRO_CONTRATO"].Value.ToString();
            row.DefaultCellStyle.BackColor = color;
        }

        /// <summary>
        /// Muestra el saldo actual por cada fila
        /// </summary>
        /// <param name="row"></param>
        /// <param name="saldo"></param>
        private void CalcularSaldos(DataGridViewRow row, ref decimal saldo)
        {
            if (row.Cells["X"].Value.ToInt32() == 0)
                saldo = row.Cells["IMPORTE_COMISION"].Value.ToDecimal() - row.Cells["IMP_DSCTADO_ACUMULADO"].Value.ToDecimal() - row.Cells["IMPORTE_DESCONTAR"].Value.ToDecimal();

            row.Cells["SALDO_COMISION_XDESCONTAR"].Value = saldo;
        }

        private void AgregarFilaNuevoPeriodo(DataGridView dataGrid)
        {
            bool acces = false;
            int countRow = dataGrid.Rows.Count;
            decimal importeComisionTot = 0, importeDesctoAcumulado = 0, importeDescontar = 0;
            int io = 0;
            do
            {
                if (acces)
                {
                    DataGridViewRow row = dataGrid.Rows[io - 1].CloneWithValues();
                    ActualizarNuevasFilas(row);
                    if (countRow != io)
                        dataGrid.Rows.Insert(io, row);
                    if (countRow == io)
                        _ = dataGrid.Rows.Add(row);
                    io += 1;
                    countRow = dataGrid.Rows.Count;
                }
                io += 1;
                if (io <= countRow)
                {
                    importeComisionTot += dataGrid.Rows[io - 1].Cells["IMPORTE_COMISION"].Value.ToDecimal();
                    importeDesctoAcumulado += dataGrid.Rows[io - 1].Cells["IMP_DSCTADO_ACUMULADO"].Value.ToDecimal();
                    importeDescontar += dataGrid.Rows[io - 1].Cells["IMPORTE_DESCONTAR"].Value.ToDecimal();
                }
                if (io < countRow)
                {
                    acces = dataGrid.Rows[io].Cells["X"].Value.ToInt32() == 1;
                }
                acces = io == countRow || acces;
            }
            while (io <= countRow);

            void ActualizarNuevasFilas(DataGridViewRow row)
            {
                int indexTag = dataGrid.Rows[io - 1].Cells["TAG"].ColumnIndex;
                int indexX = dataGrid.Rows[io - 1].Cells["X"].ColumnIndex;
                int indexFeMesPerT = dataGrid.Rows[io - 1].Cells["FE_MES_PER_T"].ColumnIndex;
                int indexFeAñoPerT = dataGrid.Rows[io - 1].Cells["FE_AÑO_PER_T"].ColumnIndex;
                int indexPeriodoDscto = dataGrid.Rows[io - 1].Cells["PERIODO_DSCTO"].ColumnIndex;
                int indexImportecomision = dataGrid.Rows[io - 1].Cells["IMPORTE_COMISION"].ColumnIndex;
                int indexImDestadoAcumulado = dataGrid.Rows[io - 1].Cells["IMP_DSCTADO_ACUMULADO"].ColumnIndex;
                int indexImpDescontar = dataGrid.Rows[io - 1].Cells["IMPORTE_DESCONTAR"].ColumnIndex;
                int indexNroCuota = dataGrid.Rows[io - 1].Cells["NRO_CUOTA"].ColumnIndex;
                int indexFechaPllaComision = dataGrid.Rows[io - 1].Cells["FECHA_PLLA_COMISION"].ColumnIndex;
                int indexCliente = dataGrid.Rows[io - 1].Cells["CLIENTE"].ColumnIndex;

                DataRow rPeriodo = ObtenerPeriodoSeleccionado();
                if (dataGrid.Rows[io - 1].Cells["FE_AÑO_PER_T"].Value.ToString() != rPeriodo["FE_AÑO_PER"].ToString()
                    || dataGrid.Rows[io - 1].Cells["FE_MES_PER_T"].Value.ToString() != rPeriodo["FE_MES_PER"].ToString())
                    row.Cells[indexTag].Value = (int)TIPO_REGISTRO.NUEVO;
                else row.Cells[indexTag].Value = (int)TIPO_REGISTRO.EXISTENTE;

                row.DefaultCellStyle.ForeColor = Color.Blue;
                row.Cells[indexX].Value = 0;
                row.Cells[indexFeAñoPerT].Value = feAñoPer;
                row.Cells[indexFeMesPerT].Value = feMesPer;
                row.Cells[indexPeriodoDscto].Value = string.Concat(feMesPer, " - ", feAñoPer);
                row.Cells[indexImpDescontar].Value = importeDescontar;
                row.Cells[indexImportecomision].Value = importeComisionTot;
                row.Cells[indexImDestadoAcumulado].Value = importeDesctoAcumulado;
                row.Cells[indexNroCuota].Value = string.Empty;
                row.Cells[indexFechaPllaComision].Value = string.Empty;
                row.Cells[indexCliente].Value = "Total Devolución >>";
                importeComisionTot = 0;
                importeDesctoAcumulado = 0;
                importeDescontar = 0;
            }
        }

        private void AjusteColumnas(DataGridView dataGrid)
        {
            InvisibleColumn(dataGrid);
            RenamerHeaderText(dataGrid);
            WithColumn(dataGrid);
            AlignTextContentCell(dataGrid);
            ReadOnlyColumns(dataGrid);
            dataGrid.Columns["CLIENTE"].Frozen = true;
            dataGrid.ColorCabeceraDataGridView(Color.Teal, Color.White);
            dataGrid.AlingHeaderTextCenter();
            SortModeColumns(dataGrid);
        }

        private void InvisibleColumn(DataGridView dataGrid)
        {
            if (dataGrid.Columns.Count > 0)
            {
                string[] nameColumns = { "ID_PROCESO", "COD_SUCURSAL", "COD_CLASE", "FE_AÑO", "FE_MES", "COD_CANAL_DSCTO_DEV",
                "COD_INSTITUCION_DEV", "FE_AÑO_DEV", "FE_MES_DEV", "ID_DEVOLUCION", "COD_NIVEL", "COD_PER", "TAG",
                "X", "TIPO_PLANILLA_DEV", "FE_AÑO_PER_T", "FE_MES_PER_T", "MOTIVO_DEVOLUCION",
                "COD_MOTIVO_NO_DSCTO", "IDT_DEVOLUCION" };
                dataGrid.InvisibleColumna(nameColumns);
            }
        }

        private void RenamerHeaderText(DataGridView dataGrid)
        {
            if (dataGrid.Columns.Count > 0)
            {
                dataGrid.Columns["NRO_CONTRATO"].HeaderText = "N° Contrato";
                dataGrid.Columns["FECHA_CONTRATO"].HeaderText = "Fec.Contrato";
                dataGrid.Columns["FECHA_APROBACION"].HeaderText = "Fec.Aprob";
                dataGrid.Columns["NRO_PLANILLA_DEV"].HeaderText = "Nº Plla. Devoluc. Mercadería";
                dataGrid.Columns["CLIENTE"].HeaderText = "Cliente";
                dataGrid.Columns["CANT_CUOTA_PAGADA"].HeaderText = "Cant. Cuotas Pagadas";
                dataGrid.Columns["IMP_COUTA_MES"].HeaderText = "Imp. Cuota Mensual";
                dataGrid.Columns["TOTAL_CUOTA_PAGADA"].HeaderText = "Tot. Importe Pagado";
                dataGrid.Columns["NRO_CUOTA"].HeaderText = "N° Cta. Comisión Generada";
                dataGrid.Columns["FECHA_DEVOLUCION"].HeaderText = "Fec. Plla. Devoluc. Mercadería";
                dataGrid.Columns["MOTIVO_DEVOLUCION"].HeaderText = "Motivo Devolución";
                dataGrid.Columns["NIVEL_VENTA"].HeaderText = "Nivel Venta";
                dataGrid.Columns["DESC_NIVEL_VENTA"].HeaderText = "Nombres Nivel Venta";
                dataGrid.Columns["IMPORTE_COMISION"].HeaderText = "Imp. Comisión Generada";
                dataGrid.Columns["NRO_PLLA_COMISION"].HeaderText = "Nº Plla. Comisíón Generada";
                dataGrid.Columns["FECHA_PLLA_COMISION"].HeaderText = "Periodo Comisíón Generada";
                dataGrid.Columns["SI_NO_DESCONTAR"].HeaderText = "¿Saldo Comis. se Descontará?";
                dataGrid.Columns["IMP_DSCTADO_ACUMULADO"].HeaderText = "Imp. Descdo. Acumulado";
                dataGrid.Columns["IMPORTE_DESCONTAR"].HeaderText = "Imp. a Descontar";
                dataGrid.Columns["PERIODO_DSCTO"].HeaderText = "Período Dscto";
                dataGrid.Columns["SALDO_COMISION_XDESCONTAR"].HeaderText = "Saldo por Descontar";
            }
        }

        private void WithColumn(DataGridView dataGrid)
        {
            if (dataGrid.Columns.Count > 0)
            {
                dataGrid.Columns["NRO_CONTRATO"].Width = 60;
                dataGrid.Columns["FECHA_CONTRATO"].Width = 70;
                dataGrid.Columns["FECHA_APROBACION"].Width = 70;
                dataGrid.Columns["NRO_PLANILLA_DEV"].Width = 70;
                dataGrid.Columns["CLIENTE"].Width = 120;
                dataGrid.Columns["CANT_CUOTA_PAGADA"].Width = 60;
                dataGrid.Columns["IMP_COUTA_MES"].Width = 60;
                dataGrid.Columns["TOTAL_CUOTA_PAGADA"].Width = 60;
                dataGrid.Columns["NRO_CUOTA"].Width = 60;
                dataGrid.Columns["FECHA_DEVOLUCION"].Width = 70;
                dataGrid.Columns["MOTIVO_DEVOLUCION"].Width = 120;
                dataGrid.Columns["NIVEL_VENTA"].Width = 80;
                dataGrid.Columns["DESC_NIVEL_VENTA"].Width = 120;
                dataGrid.Columns["IMPORTE_COMISION"].Width = 70;
                dataGrid.Columns["NRO_PLLA_COMISION"].Width = 80;
                dataGrid.Columns["FECHA_PLLA_COMISION"].Width = 80;
                dataGrid.Columns["SI_NO_DESCONTAR"].Width = 70;
                dataGrid.Columns["IMP_DSCTADO_ACUMULADO"].Width = 70;
                dataGrid.Columns["IMPORTE_DESCONTAR"].Width = 70;
                dataGrid.Columns["SALDO_COMISION_XDESCONTAR"].Width = 70;
                dataGrid.Columns["PERIODO_DSCTO"].Width = 65;
            }
        }

        private void AlignTextContentCell(DataGridView dataGrid)
        {
            string[] columns = { "NRO_CONTRATO", "FECHA_CONTRATO", "FECHA_APROBACION", "FECHA_DEVOLUCION", "NRO_CUOTA",
            "SI_NO_DESCONTAR", "PERIODO_DSCTO", "CANT_CUOTA_PAGADA", "NRO_PLLA_COMISION", "FECHA_PLLA_COMISION"};
            dataGrid.ColumnasAlinear(columns, DataGridViewContentAlignment.MiddleCenter);
            string[] columns2 = { "TOTAL_CUOTA_PAGADA", "IMPORTE_DESCONTAR" };
            dataGrid.ColumnasAlinear(columns2, DataGridViewContentAlignment.MiddleRight);
            dataGrid.AlignmentDecimalColumns();
        }

        private void ReadOnlyColumns(DataGridView dataGrid)
        {
            if (dataGrid.Name == dgvDevolucionCom.Name)
                ReadOnlyDgvDevolucionCom();
            if (dataGrid.Name == dgvDevolucionCancelado.Name)
                ReadOnlyDgvDevolucionCancelado();
            if (dataGrid.Name == dgvDevolucionAnulado.Name)
                ReadOnlyDgvDevolucionAnulado();
        }

        private void ReadOnlyDgvDevolucionCom()
        {
            if (dgvDevolucionCom.Columns.Count > 0)
            {
                string[] arrColumns =
                {
                    "SI_NO_DESCONTAR",
                    "IMPORTE_DESCONTAR",
                    "COD_MOTIVO_NO_DSCTO_COMBO"
                };

                foreach (DataGridViewColumn column in dgvDevolucionCom.Columns)
                {
                    column.ReadOnly = true;
                }

                foreach (string columnName in arrColumns)
                {
                    dgvDevolucionCom.Columns[columnName].ReadOnly = false;
                }
            }
        }

        private void ReadOnlyDgvDevolucionCancelado()
        {
            if (dgvDevolucionCancelado.Columns.Count > 0)
            {
                foreach (DataGridViewColumn column in dgvDevolucionCancelado.Columns)
                {
                    column.ReadOnly = true;
                }
            }
        }

        private void ReadOnlyDgvDevolucionAnulado()
        {
            if (dgvDevolucionAnulado.Columns.Count > 0)
            {
                foreach (DataGridViewColumn column in dgvDevolucionAnulado.Columns)
                {
                    column.ReadOnly = true;
                }
            }
        }

        private void SortModeColumns(DataGridView dataGrid)
        {
            foreach (DataGridViewColumn column in dataGrid.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Programmatic;
            }
        }

        private void AgregarColumnaCombobox(DataGridView dataGrid)
        {
            const string TABLA_COD = "DEVEX";
            const string TIPO = "D";
            directorioTo dir = new directorioTo { TABLA_COD = TABLA_COD, TIPO = TIPO };
            lstDir = BLDirectorio.ListarDirectorioXParametros(dir);
            lstDir.Insert(0, new directorioTo { CODIGO = "0", DESCRIPCION = "Sin motivo" });
            DataGridViewComboBoxColumn col = new DataGridViewComboBoxColumn
            {
                Name = "COD_MOTIVO_NO_DSCTO_COMBO",
                HeaderText = "Motivo no Dscto",
                FlatStyle = FlatStyle.Flat,
                Width = 168,
                DropDownWidth = 180,
                DataSource = lstDir,
                ValueMember = "CODIGO",
                DisplayMember = "DESCRIPCION"
            };
            dataGrid.Columns.Add(col);
        }

        private void EstablecerValorSelectCombobox(DataGridView dataGrid)
        {
            foreach (DataGridViewRow row in dataGrid.Rows)
            {
                row.Cells["COD_MOTIVO_NO_DSCTO_COMBO"].Value = string.IsNullOrEmpty(row.Cells["COD_MOTIVO_NO_DSCTO"].Value?.ToString()) ? "0" : row.Cells["COD_MOTIVO_NO_DSCTO"].Value;
            }
        }

        private void MostrarTotalesGenerales(DataGridView dataGrid)
        {
            decimal totalComisionVendedor = 0;
            decimal totalComisionSupervisor = 0;
            decimal totalComisionDirVtas = 0;
            decimal totalComisionDirNacional = 0;
            decimal totalDescontar = 0;
            decimal saldoDescontar = 0;
            decimal totalComisionPagada = 0;
            decimal desctoAcumulado = 0;

            foreach (DataGridViewRow row in dataGrid.Rows)
            {
                if (row.Cells["X"].Value.ToInt32() != 0)
                {
                    totalComisionVendedor += row.Cells["COD_NIVEL"].Value?.ToString() == COD_NIVEL_VENDEDOR ? Convert.ToDecimal(row.Cells["IMPORTE_COMISION"].Value) : 0;
                    totalComisionSupervisor += row.Cells["COD_NIVEL"].Value?.ToString() == COD_NIVEL_SUPERVISOR ? Convert.ToDecimal(row.Cells["IMPORTE_COMISION"].Value) : 0;
                    totalComisionDirVtas += row.Cells["COD_NIVEL"].Value?.ToString() == COD_NIVEL_DIR_VENTAS ? Convert.ToDecimal(row.Cells["IMPORTE_COMISION"].Value) : 0;
                    totalComisionDirNacional += row.Cells["COD_NIVEL"].Value?.ToString() == COD_NIVEL_DIR_NACIONAL ? Convert.ToDecimal(row.Cells["IMPORTE_COMISION"].Value) : 0;
                    totalComisionPagada += row.Cells["IMPORTE_COMISION"].Value.ToDecimal();
                }

                if (row.Cells["X"].Value.ToInt32() == 0)
                {
                    totalDescontar += row.Cells["IMPORTE_DESCONTAR"].Value.ToDecimal();
                    saldoDescontar += row.Cells["SALDO_COMISION_XDESCONTAR"].Value.ToDecimal();
                    desctoAcumulado += row.Cells["IMP_DSCTADO_ACUMULADO"].Value.ToDecimal();
                }
            }

            if (dataGrid.Name == dgvDevolucionCom.Name)
            {
                lblCantRegistros.Text = string.Concat("Total Cttos: ", ObtenerCantidadFilas());
                lblTotalVendedores.Text = string.Concat("Vendedor: ", totalComisionVendedor.FormatoMiles());
                lblTotalSupervisores.Text = string.Concat("Supervisor: ", totalComisionSupervisor.FormatoMiles());
                lblTotalDirVtas.Text = string.Concat("Direct. Vntas.: ", totalComisionDirVtas.FormatoMiles());
                lblTotalDirNacional.Text = string.Concat("Dir. Nacional: ", totalComisionDirNacional.FormatoMiles());
                lblTotalComPagada.Text = string.Concat("Total Comisión Generada: ", totalComisionPagada.FormatoMiles());
                lblDesctoAcumulado.Text = string.Concat("Imp. Descdo. Acumulado: ", desctoAcumulado.FormatoMiles());
                lblTotalDescontar.Text = string.Concat("Imp. a Descontar.: ", totalDescontar.FormatoMiles());
                lblSaldoDescontar.Text = string.Concat("Saldo x Descontar: ", saldoDescontar.FormatoMiles());
            }

            if (dataGrid.Name == dgvDevolucionCancelado.Name)
            {
                lblCantRegistros2.Text = string.Concat("Total Cttos: ", ObtenerCantidadFilas());
                lblTotalVendedores2.Text = string.Concat("Vendedor: ", totalComisionVendedor.FormatoMiles());
                lblTotalSupervisores2.Text = string.Concat("Supervisor: ", totalComisionSupervisor.FormatoMiles());
                lblTotalDirVtas2.Text = string.Concat("Direct. Vntas.: ", totalComisionDirVtas.FormatoMiles());
                lblTotalDirNacional2.Text = string.Concat("Dir. Nacional: ", totalComisionDirNacional.FormatoMiles());
                lblTotalComPagada2.Text = string.Concat("Total Comisión Generada: ", totalComisionPagada.FormatoMiles());
                lblDesctoAcumulado2.Text = string.Concat("Imp. Descdo. Acumulado: ", desctoAcumulado.FormatoMiles());
                lblTotalDescontar2.Text = string.Concat("Imp. a Descontar.: ", totalDescontar.FormatoMiles());
                lblSaldoDescontar2.Text = string.Concat("Saldo x Descontar: ", saldoDescontar.FormatoMiles());
            }

            if (dataGrid.Name == dgvDevolucionAnulado.Name)
            {
                lblCantRegistros3.Text = string.Concat("Total Cttos: ", ObtenerCantidadFilas());
                lblTotalVendedores3.Text = string.Concat("Vendedor: ", totalComisionVendedor.FormatoMiles());
                lblTotalSupervisores3.Text = string.Concat("Supervisor: ", totalComisionSupervisor.FormatoMiles());
                lblTotalDirVtas3.Text = string.Concat("Direct. Vntas.: ", totalComisionDirVtas.FormatoMiles());
                lblTotalDirNacional3.Text = string.Concat("Dir. Nacional: ", totalComisionDirNacional.FormatoMiles());
                lblTotalComPagada3.Text = string.Concat("Total Comisión Generada: ", totalComisionPagada.FormatoMiles());
                lblDesctoAcumulado3.Text = string.Concat("Imp. Descdo. Acumulado: ", desctoAcumulado.FormatoMiles());
                lblTotalDescontar3.Text = string.Concat("Imp. a Descontar.: ", totalDescontar.FormatoMiles());
                lblSaldoDescontar3.Text = string.Concat("Saldo x Descontar: ", saldoDescontar.FormatoMiles());
            }

            //> Obtiene la cantidad de contratros sin incluir los repetidos
            int ObtenerCantidadFilas()
            {
                if (dataGrid.Rows.Count == 0)
                    return 0;
                return (from DataGridViewRow row in dataGrid.Rows
                        where row.Cells["X"].Value.ToInt32() == 1
                        select row.Cells["NRO_CONTRATO"].Value).Distinct().Count();
            }
        }

        private void DgvDevolucionCom_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (estadoRegistro == ESTADO_REGISTRO.NONE || estadoRegistro == ESTADO_REGISTRO.REGISTRO_PENDIENTE)
            {
                _ = MessageBox.Show("Genere primero la lista de contratos o seleccione un periodo generado de devolución", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }

            if (dgvDevolucionCom.CurrentRow.Cells["X"].Value.ToInt32() != 0)
                e.Cancel = true;

            if (dgvDevolucionCom.Columns[e.ColumnIndex].Name == NAME_COLUMN1 && dgvDevolucionCom[NAME_COLUMN3, e.RowIndex].Value.ToString() == NO_DESCONTAR)
                e.Cancel = true;

            if (dgvDevolucionCom.Columns[e.ColumnIndex].Name == NAME_COLUMN3)
            {
                siNoValorAnterior = dgvDevolucionCom[e.ColumnIndex, e.RowIndex].Value.ToString().Trim();
            }
        }

        private void DgvContSinProces_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDevolucionCom.Columns[e.ColumnIndex].Name == NAME_COLUMN1)
            {
                ImporteDescontarCellEndEdit(e);
                MostrarTotalesGenerales(dgvDevolucionCom);
                GrabarComisionDevolucionCellEndEdit();
            }

            if (dgvDevolucionCom.Columns[e.ColumnIndex].Name == NAME_COLUMN3)
            {
                if (RestriccionesNameColumn3(e))
                {
                    dgvDevolucionCom[e.ColumnIndex, e.RowIndex].Value = dgvDevolucionCom[e.ColumnIndex, e.RowIndex].Value.ToString().Trim().ToUpper();
                    AsignarValorComboboxMotivoDescto(e);
                    AsignarValorNuloComboboxMotivoDescto(dgvDevolucionCom.Rows[e.RowIndex]);
                    GrabarComisionDevolucionCellEndEdit();
                }
            }
        }

        private bool RestriccionesNameColumn3(DataGridViewCellEventArgs e)
        {
            if (dgvDevolucionCom[e.ColumnIndex, e.RowIndex].Value.ToString().Trim().ToUpper() != SI_DESCONTAR
                && dgvDevolucionCom[e.ColumnIndex, e.RowIndex].Value.ToString().Trim().ToUpper() != NO_DESCONTAR)
            {
                _ = MessageBox.Show("Debe ingresar S o N " +
                    "\n Dónde S significa que va seguir descontandose a este contrato en los meses posteriores y N para dejar de descontar", "MENSAGE",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dgvDevolucionCom[e.ColumnIndex, e.RowIndex].Value = siNoValorAnterior;
                return false;
            }
            return true;
        }

        private void ImporteDescontarCellEndEdit(DataGridViewCellEventArgs e)
        {
            decimal importeComision = dgvDevolucionCom.CurrentRow.Cells["IMPORTE_COMISION"].Value.ToDecimal();
            decimal importeDesctoAcumulado = Convert.ToDecimal(dgvDevolucionCom.CurrentRow.Cells["IMP_DSCTADO_ACUMULADO"].Value);
            decimal importeDescontar = Convert.ToDecimal(dgvDevolucionCom.CurrentRow.Cells[e.ColumnIndex].Value);
            decimal saldo = importeComision - importeDesctoAcumulado - importeDescontar;
            if (saldo >= 0)
            {
                dgvDevolucionCom.CurrentRow.Cells["SALDO_COMISION_XDESCONTAR"].Value = saldo;
                if (importeDescontar > 0)
                {
                    dgvDevolucionCom.CurrentRow.Cells["SI_NO_DESCONTAR"].Value = SI_DESCONTAR;
                    //> dgvDevolucionCom.CurrentRow.Cells["COD_MOTIVO_NO_DSCTO_COMBO"].Value = "0";
                }
            }
            else
            {
                dgvDevolucionCom.CurrentRow.Cells[e.ColumnIndex].Value = 0.0;
                saldo = importeComision - importeDesctoAcumulado;
                dgvDevolucionCom.CurrentRow.Cells["SALDO_COMISION_XDESCONTAR"].Value = saldo;
                _ = MessageBox.Show("El importe a descontar es superior al saldo", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void GrabarComisionDevolucionCellEndEdit()
        {
            try
            {
                DataGridViewRow row = dgvDevolucionCom.CurrentRow;
                List<DevolucionComisionITo> lstDev = ObtenerDevolucionComisionITo();
                bool result = false;
                if (lstDev.Count > 0)
                {
                    result = await Task.Run(() => BLComision.GenerarDevolucionComisionCabDet(lstDev));
                    if (!result)
                    {
                        _ = MessageBox.Show("Ocurrió un error, que puede ser por los siguientes casos: \n" +
                            "1. Otro usuario cerró este periodo \n" +
                            "2. Otro usuario eliminó este registro \n" +
                            "Por favor, cierre el formulario y vuelva abrir e intente nuevamente, si persiste el problema, comuníquese con el administrador del sistema", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    ActualizarRegistroActual(row);
                }
            }
            catch (Exception ex)
            {
                ex.PrintException();
            }
        }

        private List<DevolucionComisionITo> ObtenerDevolucionComisionITo()
        {
            try
            {
                DataGridViewRow row = dgvDevolucionCom.CurrentRow;
                DevolucionComisionITo devTo = new DevolucionComisionITo
                {
                    COD_SUCURSAL = row.Cells["COD_SUCURSAL"].Value.ToString(),
                    COD_CLASE = row.Cells["COD_CLASE"].Value.ToString(),
                    NRO_CONTRATO = row.Cells["NRO_CONTRATO"].Tag.ToString(),
                    FE_AÑO = row.Cells["FE_AÑO"].Value.ToString(),
                    FE_MES = row.Cells["FE_MES"].Value.ToString(),
                    COD_NIVEL = row.Cells["COD_NIVEL"].Value.ToString(),
                    COD_PER = row.Cells["COD_PER"].Value.ToString(),
                    DevolucionComisionTTo = new DevolucionComisionTTo
                    {
                        FE_AÑO_PER = row.Cells["FE_AÑO_PER_T"].Value.ToString(),
                        FE_MES_PER = row.Cells["FE_MES_PER_T"].Value.ToString(),
                    }
                };
                List<DevolucionComisionITo> lstDevolucionI = BLComision.ObtenerTDevolucionComisionReg(devTo);
                //if (row.Cells["TAG"].Value.ToInt32() == (int)TIPO_REGISTRO.EXISTENTE)
                //    return ObtenerDatosValue(row);
                return ObtenerDatosTag(row, lstDevolucionI);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Obtiene DevolucionComisionITo por cada cuota del contrato, ya que acutalmente se registra un solo importe por todas las cuotas
        /// que pertenecen a un mismo contrato y a un mismo nivel de venta
        /// </summary>
        /// <param name="row"></param>
        /// <param name="lstDevolucionT">Lista de devoluciones detalle para poder repartir el importe ingresado a cada detalle</param>
        /// <returns></returns>
        private List<DevolucionComisionITo> ObtenerDatosTag(DataGridViewRow row, List<DevolucionComisionITo> lstDevolucionI)
        {
            List<DevolucionComisionITo> lista = new List<DevolucionComisionITo>();
            decimal saldo = row.Cells["IMPORTE_DESCONTAR"].Value.ToDecimal();
            foreach (DevolucionComisionITo item in lstDevolucionI)
            {
                DevolucionComisionITo devTo = new DevolucionComisionITo
                {
                    ID_DEVOLUCION = row.Cells["ID_DEVOLUCION"].Value.ToInt32(),
                    ID_PROCESO = row.Cells["ID_PROCESO"].Value.ToInt32(),
                    COD_SUCURSAL = row.Cells["COD_SUCURSAL"].Value.ToString(),
                    COD_CLASE = row.Cells["COD_CLASE"].Value.ToString(),
                    NRO_CONTRATO = row.Cells["NRO_CONTRATO"].Tag.ToString(),
                    FE_AÑO = row.Cells["FE_AÑO"].Value.ToString(),
                    FE_MES = row.Cells["FE_MES"].Value.ToString(),
                    COD_NIVEL = row.Cells["COD_NIVEL"].Value.ToString(),
                    COD_PER = row.Cells["COD_PER"].Value.ToString(),
                    TIPO_REGISTRO = (TIPO_REGISTRO)row.Cells["TAG"].Value.ToInt32(),
                    IMPORTE_COMISION = row.Cells["IMPORTE_COMISION"].Value.ToDecimal(),
                    SALDO = item.SALDO,
                    USUARIO_CREA = UsuarioSistema.Cod_usu,
                    DevolucionComisionTTo = item.DevolucionComisionTTo,
                };
                devTo.DevolucionComisionTTo.FE_AÑO_PER = row.Cells["FE_AÑO_PER_T"].Value.ToString();
                devTo.DevolucionComisionTTo.FE_MES_PER = row.Cells["FE_MES_PER_T"].Value.ToString();
                devTo.DevolucionComisionTTo.SI_NO_DESCONTAR = row.Cells["SI_NO_DESCONTAR"].Value.ToString();
                devTo.DevolucionComisionTTo.COD_MOTIVO_NO_DSCTO = devTo.DevolucionComisionTTo.SI_NO_DESCONTAR == SI_DESCONTAR || row.Cells["COD_MOTIVO_NO_DSCTO_COMBO"].Value.ToString() == "0"
                    ? null : row.Cells["COD_MOTIVO_NO_DSCTO_COMBO"].Value.ToString();
                devTo.DevolucionComisionTTo.USUARIO_CREA = UsuarioSistema.Cod_usu;
                EstablecerImportePorDetalle(devTo, ref saldo);
                lista.Add(devTo);
            }
            return lista;
        }

        private void EstablecerImportePorDetalle(DevolucionComisionITo to, ref decimal saldo)
        {
            decimal importeDeconstar = to.SALDO <= saldo ? to.SALDO : saldo;
            to.DevolucionComisionTTo.IMPORTE_DESCONTAR = importeDeconstar;
            saldo -= importeDeconstar;
        }

        private void ActualizarRegistroActual(DataGridViewRow row)
        {
            row.Cells["TAG"].Value = (int)TIPO_REGISTRO.EXISTENTE;
            //DataTable dt = BLComision.ObtenerDevolucionComisionContratosGenerado(to);
            //if (dt != null && dt.Rows.Count == 1)
            //{
            //    row.Cells["ID_DEVOLUCION"].Value = dt.Rows[0]["ID_DEVOLUCION"];
            //    row.Cells["TAG"].Value = dt.Rows[0]["TAG"];
            //}
            //else
            //    _ = MessageBox.Show("Error al obtener la fila actual - " + dt.Rows.Count, "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void DgvContSinProces_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (dgvDevolucionCom.Columns[e.ColumnIndex].Name == NAME_COLUMN1)
            {
                MessageBox.Show("Ingrese valores numéricos o decimales", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (e.Exception is ConstraintException)
            {
                DataGridView view = (DataGridView)sender;
                view.Rows[e.RowIndex].ErrorText = "an error";
                view.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "an error";

                e.ThrowException = false;
            }
        }

        private void CboMes_SelectedValueChanged(object sender, EventArgs e)
        {
            EstablecerFechaDevolucion();
        }

        private void DtAño_ValueChanged(object sender, EventArgs e)
        {
            EstablecerFechaDevolucion();
        }

        private void EstablecerFechaDevolucion()
        {
            int mes = string.IsNullOrEmpty(cboMes.SelectedValue?.ToString()) ? 1 : Convert.ToInt32(cboMes.SelectedValue);
            DateTime fechaInicio = new DateTime(dtAño.Value.Year, mes, 1);
            DateTime fechaFin = new DateTime(dtAño.Value.Year, mes, DateTime.DaysInMonth(fechaInicio.Year, fechaInicio.Month));
            dtFechaDevolIni.Value = fechaInicio;
            dtFechaDevolFin.Value = fechaFin;
        }

        private async void BtnGenerar_Click(object sender, EventArgs e)
        {
            FrmLoading frm = null;
            try
            {
                if (!ValidarGenerarDevolucion())
                    return;

                if (MessageBox.Show($"Esta seguro de generar devoluciones del periodo: { feMesPerName } - { feAñoPer}",
                    "MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    frm = frm.StartLoadingForm(this);
                    List<DevolucionComisionITo> lstDev = ObtenerDevolucionComision();
                    bool result = false;
                    if (lstDev != null && lstDev.Count > 0)
                    {
                        result = await Task.Run(() => BLComision.GenerarDevolucionComisionCabDet(lstDev));
                        frm.CloseLoadingForm();
                        _ = result
                            ? MessageBox.Show("Registrado Correctamente", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            : MessageBox.Show("Error al registrar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    ListarDevolucionesRecienGenerados();
                }
            }
            catch (Exception ex)
            {
                frm.CloseLoadingForm();
                ex.PrintException2();
            }
        }

        private void ListarDevolucionesRecienGenerados()
        {
            if (tipoLista == TIPO_REGISTRO.NUEVO)
            {
                CargarPeriodoGeneradoDevolucion();
                DataRow row = dtPeridoGenerado.Select("FE_AÑO_PER = '" + feAñoPer + "' AND FE_MES_PER = '" + feMesPer + "'").Last();
                if (row != null)
                    cboPeriodoGen.SelectedValue = row["ID"];
                else
                    dgvDevolucionCom.Rows.Clear();
            }
        }

        private List<DevolucionComisionITo> ObtenerDevolucionComision()
        {
            try
            {
                List<DevolucionComisionITo> list = new List<DevolucionComisionITo>();
                DataGridViewRow[] arrRow = dgvDevolucionCom.Rows.Cast<DataGridViewRow>().ToArray();
                DevolucionComisionITo[] arrDevolucion = new DevolucionComisionITo[arrRow.Length];
                for (int io = 0; io < arrRow.Length; io++)
                {
                    DevolucionComisionITo devTo = new DevolucionComisionITo
                    {
                        ID_DEVOLUCION = arrRow[io].Cells["ID_DEVOLUCION"].Value.ToInt32(),
                        ID_PROCESO = arrRow[io].Cells["ID_PROCESO"].Value.ToInt32(),
                        COD_SUCURSAL = arrRow[io].Cells["COD_SUCURSAL"].Value.ToString(),
                        COD_CLASE = arrRow[io].Cells["COD_CLASE"].Value.ToString(),
                        NRO_CONTRATO = arrRow[io].Cells["NRO_CONTRATO"].Value.ToString(),
                        FE_AÑO = arrRow[io].Cells["FE_AÑO"].Value.ToString(),
                        FE_MES = arrRow[io].Cells["FE_MES"].Value.ToString(),
                        FE_AÑO_PER = feAñoPer,
                        FE_MES_PER = feMesPer,
                        FECHA_DEV_INI = dtFechaDevolIni.Value,
                        FECHA_DEV_FIN = dtFechaDevolFin.Value,
                        NRO_CUOTA = arrRow[io].Cells["NRO_CUOTA"].Value.ToString(),
                        COD_NIVEL = arrRow[io].Cells["COD_NIVEL"].Value.ToString(),
                        COD_PER = arrRow[io].Cells["COD_PER"].Value.ToString(),
                        TIPO_REGISTRO = (TIPO_REGISTRO)arrRow[io].Cells["TAG"].Value.ToInt32(),
                        IMPORTE_COMISION = arrRow[io].Cells["IMPORTE_COMISION"].Value.ToDecimal(),
                        USUARIO_CREA = UsuarioSistema.Cod_usu,
                        DevolucionComisionTTo = new DevolucionComisionTTo
                        {
                            ID_DEVOLUCION = arrRow[io].Cells["ID_DEVOLUCION"].Value.ToInt32(),
                            FE_AÑO_PER = feAñoPer,
                            FE_MES_PER = feMesPer,
                            NRO_PLANILLA_DEV = arrRow[io].Cells["NRO_PLANILLA_DEV"].Value.ToString(),
                            COD_INSTITUCION_DEV = arrRow[io].Cells["COD_INSTITUCION_DEV"].Value.ToString(),
                            COD_CANAL_DSCTO_DEV = arrRow[io].Cells["COD_CANAL_DSCTO_DEV"].Value.ToString(),
                            FE_AÑO_DEV = arrRow[io].Cells["FE_AÑO_DEV"].Value.ToString(),
                            FE_MES_DEV = arrRow[io].Cells["FE_MES_DEV"].Value.ToString(),
                            TIPO_PLANILLA_DEV = arrRow[io].Cells["TIPO_PLANILLA_DEV"].Value.ToString(),
                            IMPORTE_DESCONTAR = arrRow[io].Cells["IMPORTE_DESCONTAR"].Value.ToDecimal(),
                            SI_NO_DESCONTAR = arrRow[io].Cells["SI_NO_DESCONTAR"].Value.ToString(),
                            COD_MOTIVO_NO_DSCTO = arrRow[io].Cells["COD_MOTIVO_NO_DSCTO_COMBO"].Value.ToString() == "0" ? null : arrRow[io].Cells["COD_MOTIVO_NO_DSCTO_COMBO"].Value.ToString(),
                            USUARIO_CREA = UsuarioSistema.Cod_usu
                        }
                    };
                    arrDevolucion[io] = devTo;
                }
                list.AddRange(arrDevolucion);
                return list;
            }
            catch
            {
                throw;
            }
        }

        private bool ValidarGenerarDevolucion()
        {
            if (dgvDevolucionCom.Rows.Count == 0)
                return false;

            if (estadoRegistro == ESTADO_REGISTRO.REGISTRO_APROBADO)
            {
                _ = MessageBox.Show("Este periodo esta cerrado, no se puede generar nuevamente", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void BtnRegistrarCuotaVigencia_Click(object sender, EventArgs e)
        {
            FrmCuotaVigenciaDevolucion frmCuotaVigencia = FrmCuotaVigenciaDevolucion.Instancia();
            frmCuotaVigencia.Owner = this;
            frmCuotaVigencia.Show();
        }

        private void TabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            tabControl1.Style1TabPages(e);
        }

        private void CboPeriodoGen_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboPeriodoGen.Items.Count > 0 && Convert.ToInt32(cboPeriodoGen.SelectedValue) != 0)
            {
                DataRow row = ObtenerPeriodoSeleccionado();
                if (row == null || row.ItemArray.Length == 0)
                    return;
                if (row["ESTADO"].ToInt32() == (int)ESTADO_REGISTRO.REGISTRO_PROCESADO || row["ESTADO"].ToInt32() == (int)ESTADO_REGISTRO.REGISTRO_APROBADO)
                {
                    if (tabControl1.SelectedTab != tbDevoluciones)
                        tabControl1.SelectedTab = tbDevoluciones;
                    ListarDevolucionComisionGenerados();
                    ListarDevolucionComisionGenCancelado();
                    ListarDevolucionComisionGenAnulados();
                    EstablcerEstadoRegistro();
                }
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

        private void DgvDevolucionCom_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            DataGridView dataGrid = sender as DataGridView;
            if (dataGrid.IsCurrentCellDirty)
            {
                dataGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void DgvDevolucionCom_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDevolucionCom.Columns[e.ColumnIndex].Name == NAME_COLUMN2)
            {
                DataGridViewComboBoxCell cb = (DataGridViewComboBoxCell)dgvDevolucionCom.Rows[e.RowIndex].Cells[NAME_COLUMN2];
                if (cb.Value != null)
                {
                    GrabarComisionDevolucionCellEndEdit();
                    dgvDevolucionCom.Invalidate();
                }
            }
        }

        private void MostrarStatusMensaje(DataTable dt, Label lblMessage, string mensaje)
        {
            if (InvokeRequired)
            {
                DelMostrarMensaje del = new DelMostrarMensaje(MostrarStatusMensaje);
                object[] parameter = new object[] { dt, lblMessage, mensaje };
                _ = Invoke(del, parameter);
            }
            else
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = mensaje;
                }
                else
                {
                    lblMessage.Visible = false;
                }
            }
        }

        private void VerificarParaMostrarMensaje(DataTable dt)
        {
            if (dt == null)
                return;
            bool status = true;
            foreach (DataRow row in dt.Rows)
            {
                if (row["ID_DEVOLUCION"].ToInt32() == 0 || (TIPO_REGISTRO)row["TAG"].ToInt32() == TIPO_REGISTRO.NUEVO)
                {
                    status = false;
                    break;
                }
            }
            if (status)
                MostrarStatusMensaje(dt, lblMessage, string.Format(MENSAJE_GENERADO, string.Concat(feAñoPer, " ", cboMes.Text.Substring(0, 3))));
            else
                MostrarStatusMensaje(dt, lblMessage, MENSAJE_PENDIENTE);
        }

        private void BtnGenerarReporte_Click(object sender, EventArgs e)
        {
            Reportes.Formulario.FrmRptDevolucionComision frm = Reportes.Formulario.FrmRptDevolucionComision.Instancia();
            frm.Owner = this;
            frm.Show();
        }

        /// <summary>
        /// Cierra o abre el período según el estado actual del periodo seleccionado,
        /// si el periodo esta cerrado entonces abre de lo contrario cierra
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAprobarComision_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarCerrarAbrirDevolucion())
                    return;
                FrmConfirmar frmConfirmar = new FrmConfirmar(TIPO_CONFIRMAR.DEVOLUCION_COMISION)
                {
                    StartPosition = FormStartPosition.CenterScreen
                };
                frmConfirmar.EventClick += FrmConfirmar_EventClick;
                frmConfirmar.ShowDialog();
            }
            catch (Exception ex)
            {
                ex.PrintException();
            }
        }

        private void FrmConfirmar_EventClick(object sender, EventArgs e)
        {
            if (estadoRegistro == ESTADO_REGISTRO.REGISTRO_PROCESADO)
            {
                CerrarPeriodoGenerado();
                return;
            }
            if (estadoRegistro == ESTADO_REGISTRO.REGISTRO_APROBADO)
            {
                AbrirPeriodoGenerado();
                return;
            }
        }

        private void CerrarPeriodoGenerado()
        {
            string nombreMesPer = feMesPer.ToInt32().NombreMesCorta();
            if (MessageBox.Show($"¿Esta seguro de cerrar este período: {nombreMesPer} - {feAñoPer}?", "MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                == DialogResult.Yes)
            {
                DevolucionComisionTTo to = ObtenerDatosCerrarAbrirDevolucion();
                if (BLComision.CerrarPeriodoAdelantoComision(to))
                {
                    _ = MessageBox.Show("Período cerrado", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ActualizarDtPeridoGenerado();
                    ActualizarDatosSegunCerrarAbrirPeriodo();
                    EstablcerEstadoRegistro();
                }
                else
                    _ = MessageBox.Show("Error al cerrar el período", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AbrirPeriodoGenerado()
        {
            string nombreMesPer = feMesPer.ToInt32().NombreMesCorta();
            if (MessageBox.Show($"¿Esta seguro de abrir este período: {nombreMesPer} - {feAñoPer}?", "MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                == DialogResult.Yes)
            {
                DevolucionComisionTTo to = ObtenerDatosCerrarAbrirDevolucion();
                if (BLComision.AbrirPeriodoAdelantoComision(to))
                {
                    _ = MessageBox.Show("Período abierto", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ActualizarDtPeridoGenerado();
                    ActualizarDatosSegunCerrarAbrirPeriodo();
                    EstablcerEstadoRegistro();
                }
                else
                    _ = MessageBox.Show("Error al abrir el período", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DevolucionComisionTTo ObtenerDatosCerrarAbrirDevolucion()
        {
            DataRow row = ObtenerPeriodoSeleccionado();
            return new DevolucionComisionTTo
            {
                FE_AÑO_PER = row["FE_AÑO_PER"].ToString(),
                FE_MES_PER = row["FE_MES_PER"].ToString()
            };
        }

        private bool ValidarCerrarAbrirDevolucion()
        {
            if (dtDevolucionContrato == null || dtDevolucionContrato.Rows.Count == 0)
                return false;

            DataRow row = ObtenerPeriodoSeleccionado();
            if (row == null || row.ItemArray.Length == 0)
            {
                _ = MessageBox.Show("Primero consulte el periodo a cerrar seleccionado de la lista de periodos", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (estadoRegistro != ESTADO_REGISTRO.REGISTRO_PROCESADO && estadoRegistro != ESTADO_REGISTRO.REGISTRO_APROBADO)
            {
                _ = MessageBox.Show("Primero consulte el periodo a cerrar, seleccionado de la lista de periodos", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void DgvDevolucionCom_EstablecerAccesos()
        {
            DataRow row = ObtenerPeriodoSeleccionado();
            if (row["ESTADO"].ToInt32() == (int)ESTADO_REGISTRO.REGISTRO_APROBADO)
                dgvDevolucionCom.ReadOnly = true;
            if (row["ESTADO"].ToInt32() == (int)ESTADO_REGISTRO.REGISTRO_PROCESADO)
                dgvDevolucionCom.ReadOnly = false;
        }

        /// <summary>
        /// Actualiza datos según si el período esta abierto o cerrado
        /// </summary>
        private void ActualizarDatosSegunCerrarAbrirPeriodo()
        {
            DataRow row = ObtenerPeriodoSeleccionado();
            if (row["ESTADO"].ToInt32() == (int)ESTADO_REGISTRO.REGISTRO_APROBADO)
                MostrarStatusMensaje(dtDevolucionContrato, lblMessage, string.Format(MENSAJE_CERRADO, string.Concat(feAñoPer, " ", cboMes.Text.Substring(0, 3))));

            if (row["ESTADO"].ToInt32() == (int)ESTADO_REGISTRO.REGISTRO_PROCESADO)
                MostrarStatusMensaje(dtDevolucionContrato, lblMessage, string.Format(MENSAJE_GENERADO, string.Concat(feAñoPer, " ", cboMes.Text.Substring(0, 3))));
            DgvDevolucionCom_EstablecerAccesos();
        }

        private void BtnRevertirPeriodo_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarRevertirDevolucion())
                    return;
                string nombreMesPer = feMesPer.ToInt32().NombreMesCorta();
                if (MessageBox.Show($"¿Esta seguro de revertir todas las devolucines del periodo {nombreMesPer} - {feAñoPer}", "MESSAGE",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    List<DevolucionComisionTTo> lstTo = ObtenerDatosRevertirDevolucion();
                    if (lstTo != null)
                    {
                        _ = BLComision.RevertirDevolucionComision(lstTo)
                            ? MessageBox.Show("Eliminado correctamente", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            : MessageBox.Show("Error al eliminar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        CargarPeriodoGeneradoDevolucion();
                        dgvDevolucionCom.Rows.Clear();
                        dtDevolucionContrato.Rows.Clear();
                        MostrarTotalesGenerales(dgvDevolucionCom);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.PrintException();
            }
        }

        private List<DevolucionComisionTTo> ObtenerDatosRevertirDevolucion()
        {
            try
            {
                List<DevolucionComisionTTo> lista = new List<DevolucionComisionTTo>();
                DataTable dt = dtDevolucionContrato.Rows.Cast<DataRow>().Where(x => x["FE_AÑO_PER_T"].ToString() == feAñoPer
                                && x["FE_MES_PER_T"].ToString() == feMesPer).CopyToDataTable();
                if (dt == null || dt.Rows.Count == 0)
                    return null;
                DevolucionComisionTTo[] arrTo = new DevolucionComisionTTo[dt.Rows.Count];
                for (int io = 0; io < dt.Rows.Count; io++)
                {
                    DevolucionComisionTTo to = new DevolucionComisionTTo
                    {
                        ID_DEVOLUCION = dt.Rows[io]["ID_DEVOLUCION"].ToInt32(),
                        FE_AÑO_PER = feAñoPer,
                        FE_MES_PER = feMesPer
                    };
                    arrTo[io] = to;
                }
                lista.AddRange(arrTo);
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool ValidarRevertirDevolucion()
        {
            if (estadoRegistro == ESTADO_REGISTRO.REGISTRO_APROBADO)
            {
                _ = MessageBox.Show("Este periodo esta cerrado, no se puede revertir", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (estadoRegistro != ESTADO_REGISTRO.REGISTRO_PROCESADO)
            {
                _ = MessageBox.Show("Primero consulte el periodo a eliminar seleccionado de la lista de periodos", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (dtDevolucionContrato == null || dtDevolucionContrato.Rows.Count == 0)
                return false;

            return true;
        }

        private void BtnEliminarPeriodo_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarEliminarDevolucion())
                    return;
                string añoPer = dgvDevolucionCom.CurrentRow.Cells["FE_AÑO_PER_T"].Value.ToString();
                string nombreMesPer = dgvDevolucionCom.CurrentRow.Cells["FE_MES_PER_T"].Value.ToInt32().NombreMesCorta();
                if (MessageBox.Show($"¿Esta seguro de eliminar la devolución del periodo: {nombreMesPer} - {añoPer}", "MESSAGE",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    DevolucionComisionTTo to = ObtenerDatosEliminarDevolucion();
                    if (to != null)
                    {
                        if (BLComision.EliminarDevolucionComision(to))
                        {
                            BorrarFilaEliminaDgv();
                            MostrarTotalesGenerales(dgvDevolucionCom);
                            MessageBox.Show("Eliminado correctamente", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else MessageBox.Show("Error al eliminar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.PrintException();
            }
        }

        private DevolucionComisionTTo ObtenerDatosEliminarDevolucion()
        {
            try
            {
                DevolucionComisionTTo to = new DevolucionComisionTTo
                {
                    ID_DEVOLUCION = dgvDevolucionCom.CurrentRow.Cells["ID_DEVOLUCION"].Value.ToInt32(),
                    FE_AÑO_PER = dgvDevolucionCom.CurrentRow.Cells["FE_AÑO_PER_T"].Value.ToString(),
                    FE_MES_PER = dgvDevolucionCom.CurrentRow.Cells["FE_MES_PER_T"].Value.ToString()
                };
                return to;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool ValidarEliminarDevolucion()
        {
            if (dgvDevolucionCom == null || dgvDevolucionCom.Rows.Count == 0)
                return false;

            if (estadoRegistro == ESTADO_REGISTRO.REGISTRO_APROBADO)
            {
                _ = MessageBox.Show("Este periodo esta cerrado, no se puede eliminar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (estadoRegistro != ESTADO_REGISTRO.REGISTRO_PROCESADO)
            {
                _ = MessageBox.Show("Primero consulte el periodo a eliminar seleccionado de la lista de periodos", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (dgvDevolucionCom.CurrentCell == null)
            {
                _ = MessageBox.Show("Seleccione una fila a eliminar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Elimina las filas del periodo eliminado del dtDevolucionContrato y también del dataGridView dgvDevolucionCom
        /// </summary>
        private void BorrarFilaEliminaDgv()
        {
            DataRow row = dtDevolucionContrato.Rows.Cast<DataRow>().Where(x => x["IDT_DEVOLUCION"].ToInt32() == dgvDevolucionCom.CurrentRow.Cells["IDT_DEVOLUCION"].Value.ToInt32()).SingleOrDefault();
            if (row != null)
                dtDevolucionContrato.Rows.Remove(row);
            dgvDevolucionCom.Rows.RemoveAt(dgvDevolucionCom.CurrentRow.Index);
        }

        private void BtnBuscarDevContrato_Click(object sender, EventArgs e)
        {
            FrmConsultaDevolucionContrato frm = new FrmConsultaDevolucionContrato()
            {
                Owner = this,
                StartPosition = FormStartPosition.CenterScreen
            };
            frm.Show();
        }

        /// <summary>
        /// Asigna valor nulo al combobox COD_MOTIVO_NO_DSCTO_COMBO cuando el valor de SI_NO_DESCONTAR = S
        /// </summary>
        /// <param name="e"></param>
        private void AsignarValorNuloComboboxMotivoDescto(DataGridViewRow row)
        {
            if (row.Cells[NAME_COLUMN3].Value?.ToString() == SI_DESCONTAR)
            {
                DataGridViewComboBoxCell cell = row.Cells["COD_MOTIVO_NO_DSCTO_COMBO"] as DataGridViewComboBoxCell;
                cell.DataSource = null;
                cell.ReadOnly = true;
            }
        }

        /// <summary>
        /// Asigna data al combobox COD_MOTIVO_NO_DSCTO_COMBO cuando el valor de SI_NO_DESCONTAR = N
        /// </summary>
        /// <param name="e"></param>
        private void AsignarValorComboboxMotivoDescto(DataGridViewCellEventArgs e)
        {
            if (dgvDevolucionCom[e.ColumnIndex, e.RowIndex].Value?.ToString() == NO_DESCONTAR)
            {
                DataGridViewComboBoxCell cell = dgvDevolucionCom["COD_MOTIVO_NO_DSCTO_COMBO", e.RowIndex] as DataGridViewComboBoxCell;
                cell.DataSource = lstDir;
                cell.ValueMember = "CODIGO";
                cell.DisplayMember = "DESCRIPCION";
                cell.Value = COD_MOTIVO_NO_DSCTO_900;
                cell.ReadOnly = false;
            }
        }

        /// <summary>
        /// Evento cell click para los tres dataGridViews(dgvDevolucionCom, dgvDevolucionAnulado, dgvDevolucionCancelado)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgvDevolucionCom_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGrid = sender as DataGridView;
            if (dataGrid.Columns[e.ColumnIndex].Name == NAME_COLUMN4)
            {
                if (dataGrid[e.ColumnIndex, e.RowIndex].Value?.ToString().Length == 0)
                    return;
                FrmConsultaDevolucionContrato frmDevolucion = new FrmConsultaDevolucionContrato
                {
                    Owner = this,
                    StartPosition = FormStartPosition.CenterScreen,
                };
                frmDevolucion.txtNroContrato.Text = dataGrid["NRO_CONTRATO", e.RowIndex].Tag?.ToString();
                frmDevolucion.txtNroContrato.Enabled = false;
                frmDevolucion.BtnBuscar_Click(sender, e);
                frmDevolucion.Show();
            }
        }

        private void TxtNombreNivelPer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string nameColumn = "DESC_NIVEL_VENTA";
                string nameColumn2 = "COD_NIVEL";
                string filterText = txtNombreNivelPer.Text.Trim().Length > 0
                    ? string.Concat(nameColumn, " LIKE '%", txtNombreNivelPer.Text, "%' AND ", nameColumn2, " = '", cboNivelVenta.SelectedValue.ToString(), "'")
                    : string.Empty;
                FiltrarDataGridView(dtDevolucionContrato, dgvDevolucionCom, filterText);
            }
        }

        private void TxtNroContrato_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtNroContrato.TxtContratoFormato();
                string nombreColumna = "NRO_CONTRATO";
                string filterText = txtNroContrato.Text.Trim().Length > 0
                    ? string.Concat(nombreColumna, " = '", txtNroContrato.Text, "'")
                    : string.Empty;
                FiltrarDataGridView(dtDevolucionContrato, dgvDevolucionCom, filterText);
            }
        }

        private void TxtNombreNivelPer2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string nameColumn = "DESC_NIVEL_VENTA";
                string nameColumn2 = "COD_NIVEL";
                string filterText = txtNombreNivelPer2.Text.Trim().Length > 0
                    ? string.Concat(nameColumn, " LIKE '%", txtNombreNivelPer2.Text, "%' AND ", nameColumn2, " = '", cboNivelVenta2.SelectedValue.ToString(), "'")
                    : string.Empty;
                FiltrarDataGridView(dtDevolucionCancelado, dgvDevolucionCancelado, filterText);
            }
        }

        private void TxtNroContrato2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtNroContrato2.TxtContratoFormato();
                string nombreColumna = "NRO_CONTRATO";
                string filterText = txtNroContrato2.Text.Trim().Length > 0
                    ? string.Concat(nombreColumna, " = '", txtNroContrato2.Text, "'")
                    : string.Empty;
                FiltrarDataGridView(dtDevolucionCancelado, dgvDevolucionCancelado, filterText);
            }
        }

        private void TxtNombreNivelPer3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string nameColumn = "DESC_NIVEL_VENTA";
                string nameColumn2 = "COD_NIVEL";
                string filterText = txtNombreNivelPer3.Text.Trim().Length > 0
                    ? string.Concat(nameColumn, " LIKE '%", txtNombreNivelPer3.Text, "%' AND ", nameColumn2, " = '", cboNivelVenta3.SelectedValue.ToString(), "'")
                    : string.Empty;
                FiltrarDataGridView(dtDevolucionAnulado, dgvDevolucionAnulado, filterText);
            }
        }

        private void TxtNroContrato3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtNroContrato3.TxtContratoFormato();
                string nombreColumna = "NRO_CONTRATO";
                string filterText = txtNroContrato3.Text.Trim().Length > 0
                    ? string.Concat(nombreColumna, " = '", txtNroContrato3.Text, "'")
                    : string.Empty;
                FiltrarDataGridView(dtDevolucionAnulado, dgvDevolucionAnulado, filterText);
            }
        }

        /// <summary>
        /// Permite filtrar de la lista consultada mediante un query
        /// </summary>
        /// <param name="dt">Origen de datos de dónde se va filtrar</param>
        /// <param name="dataGrid">DataGridView a dónde se va cargar la data filtrada</param>
        /// <param name="filterText">Query para filtrar</param>
        private async void FiltrarDataGridView(DataTable dt, DataGridView dataGrid, string filterText)
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

                    dv = dt.DefaultView;

                    if (!string.IsNullOrEmpty(filterText))
                        dv.RowFilter = filterText;
                }
                );
                if (dataGrid.Name == dgvDevolucionCom.Name)
                    dgvDevolucionCom.CellValueChanged -= DgvDevolucionCom_CellValueChanged;
                if (!string.IsNullOrEmpty(filterText))
                    CargarDgv(dataGrid, dv.ToTable());
                else
                    CargarDgv(dataGrid, dt);
                if (estadoRegistro != ESTADO_REGISTRO.NONE && estadoRegistro != ESTADO_REGISTRO.REGISTRO_PENDIENTE)
                {
                    AgregarFilaNuevoPeriodo(dataGrid);
                    ReafactorizarDatosDgv(dataGrid);
                }
                MostrarTotalesGenerales(dataGrid);
                frmLoading.Close();
                if (dataGrid.Name == dgvDevolucionCom.Name)
                    dgvDevolucionCom.CellValueChanged += DgvDevolucionCom_CellValueChanged;
            }
        }

        /// <summary>
        /// Establece el valor de la variable [estadoRegistro] según el estado del período
        /// </summary>
        private void EstablcerEstadoRegistro()
        {
            DataRow row = ObtenerPeriodoSeleccionado();
            if (row != null && row.ItemArray.Length > 0)
            {
                estadoRegistro = (ESTADO_REGISTRO)row["ESTADO"].ToInt32();
            }
            else
                estadoRegistro = ESTADO_REGISTRO.NONE;
        }
    }
}
