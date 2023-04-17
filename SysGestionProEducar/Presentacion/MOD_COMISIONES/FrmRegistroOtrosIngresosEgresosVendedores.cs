using BLL;
using Entidades;
using Presentacion.HELPERS.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Presentacion.HELPERS.AppearanceUtil;
using static Presentacion.HELPERS.ErrorPrint;
using static Presentacion.HELPERS.FormatDataGridViewColumns;
using static Presentacion.HELPERS.GenericMethod;
using static Presentacion.HELPERS.GenericUtil;

namespace Presentacion.MOD_COMISIONES
{
    public partial class FrmRegistroOtrosIngresosEgresosVendedores : Form
    {
        public FrmRegistroOtrosIngresosEgresosVendedores()
        {
            InitializeComponent();
        }

        private readonly comisionesBLL BLComision = new comisionesBLL();
        private readonly directorioBLL BLDirectorio = new directorioBLL();

        private DataTable dtPeriodoGenerado;
        private DataGridView dgvConcepto;
        private List<directorioTo> lstDir;
        private bool accShowDgvConcepto;
        private ESTADO_REGISTRO estado_registro;

        private const string COLUMN_NAME1 = "CODIGO_CON";
        private const string COLUMN_NAME2 = "INGRESO";
        private const string COLUMN_NAME3 = "EGRESO";
        private const int INGRESO = 1;
        private const int EGRESO = 2;
        private const string TABLA_COD = "OIECO";
        private const string TIPO = "D";
        private const string COD_NIVEL_VENDEDOR = "04";
        private const string CODIGO_INI_EGRESO = "E";
        private const string CODIGO_INI_INGRESO = "I";
        private const string MENSAJE_ABIERTO = "ABIERTO | {0}";
        private const string MENSAJE_CERRADO = "CERRADO | {0}";

        private void FrmRegistroOtrosIngresosEgresosVendedores_Load(object sender, EventArgs e)
        {
            StartControls();
            CargarPeriodoGenerado();
        }

        private void StartControls()
        {
            btnGrabar.StyleButtonFlat();
            btnEliminar.StyleButtonFlat();
            btnLiqidar.StyleButtonFlat();
            btnConsultarLiqu.StyleButtonFlat();
            btnEliminarLiqu.StyleButtonFlat();
            btnCerrarAbrir.StyleButtonFlat();
            ComboBoxFormat(cboPeriodoGen);
            dgvVendedores.Style5(false, false, true, false, false, DataGridViewTriState.True, DataGridViewColumnHeadersHeightSizeMode.AutoSize,
                DataGridViewTriState.True, DataGridViewAutoSizeRowsMode.AllCells, DataGridViewSelectionMode.FullRowSelect);
            dgvIngreEgre.EditMode = DataGridViewEditMode.EditOnEnter;
            lstvTotalesVendedores.View = View.Details;
            ColorListViewHeader(lstvTotalesVendedores, BackColorColumnPrimary, ForeColorColumnPrimary);
        }

        private void ComboBoxFormat(ComboBox comboBox)
        {
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void CargarPeriodoGenerado()
        {
            dtPeriodoGenerado = BLComision.ObtenerPeriodoGeneradosComisionYDevolucion();
            if (dtPeriodoGenerado != null && dtPeriodoGenerado.Columns.Count > 0)
            {
                DataRow row = dtPeriodoGenerado.NewRow();
                row["ID"] = 0;
                row["FE_AÑO_PER"] = "";
                row["FE_MES_PER"] = "";
                row["PERIODO_TEXT"] = "Seleccione";
                dtPeriodoGenerado.Rows.InsertAt(row, 0);

                cboPeriodoGen.ValueMember = "ID";
                cboPeriodoGen.DisplayMember = "PERIODO_TEXT";
                cboPeriodoGen.DataSource = dtPeriodoGenerado;
            }
        }

        private async Task ListarVendedores()
        {
            DataRow row = ObtenerPeriodoSeleccionado();
            if (row != null && row.ItemArray.Length > 0)
            {
                string feAñoPer = row["FE_AÑO_PER"].ToString();
                string feMesPer = row["FE_MES_PER"].ToString();
                DataTable dt = await Task.Run(() => BLComision.ListarVendedoresComisionIngreEgre(feAñoPer, feMesPer));
                if (dgvVendedores.Columns.Count == 0)
                {
                    dgvVendedores.AddRangeColumnsDataGridView(dt, false);
                    AjusteColumnas(dgvVendedores);
                }
                if (dt.Rows.Count > 0)
                {
                    dt.Columns["OTROS_INGRESOS"].ReadOnly = false;
                    dt.Columns["OTROS_EGRESOS"].ReadOnly = false;
                    dt.Columns["SALDO_ANTERIOR"].ReadOnly = false;
                    dt.Columns["SALDO_FINAL"].ReadOnly = false;
                }
                await CalcularSaldoAnterior(dt);
                dgvVendedores.Rows.Clear();
                dgvVendedores.AddRangeRowsDataGridView(dt);
                if (dgvVendedores.Rows.Count > 0)
                {
                    dgvVendedores.CurrentCell = dgvVendedores[2, 0];
                }
            }
            MostrarTotalesVendedores();
        }

        private void AjusteColumnas(DataGridView dataGrid)
        {
            InvisibleColumn(dataGrid);
            RenamerHeaderText(dataGrid);
            WithColumn(dataGrid);
            AlignTextContentCell(dataGrid);
            ReadOnlyColumns(dataGrid);
            if (dataGrid.Name != dgvVendedores.Name)
                dataGrid.ColorCabeceraDataGridView(BackColorColumnPrimary, ForeColorColumnPrimary);
            else
                DgvVendedores_ColorCabecera();
            dataGrid.AlingHeaderTextCenter();
        }

        private void InvisibleColumn(DataGridView dataGrid)
        {
            if (dataGrid.Columns.Count > 0)
            {
                if (dataGrid.Name == dgvVendedores.Name)
                {
                    string[] nameColumns = { "COD_PER" };
                    dataGrid.InvisibleColumna(nameColumns);
                }
                if (dgvConcepto != null && dataGrid.Name == dgvConcepto.Name)
                {
                    string[] nameColumns = { "TABLA_COD", "TIPO", "OBSERVACION", "DESCRIP_CORTA" };
                    dataGrid.InvisibleColumna(nameColumns);
                }
            }
        }

        private void RenamerHeaderText(DataGridView dataGrid)
        {
            if (dataGrid.Columns.Count > 0)
            {
                if (dataGrid.Name == dgvVendedores.Name)
                {
                    dataGrid.Columns["DESC_PER"].HeaderText = "Vendedor";
                    dataGrid.Columns["SALDO_ANTERIOR"].HeaderText = "Saldo Anterior";
                    dataGrid.Columns["COMISION_PROPIO"].HeaderText = "Comis.Vtas. Propias";
                    dataGrid.Columns["COMISION_TERCERO"].HeaderText = "Comis.Vtas. Tercero";
                    dataGrid.Columns["DEVOLUCION"].HeaderText = "Devolución";
                    dataGrid.Columns["OTROS_INGRESOS"].HeaderText = "Otros Ingresos";
                    dataGrid.Columns["OTROS_EGRESOS"].HeaderText = "Otros Egresos";
                    dataGrid.Columns["PAGO_CTA_CTE"].HeaderText = "Pagos. Cta.Cte.";
                    dataGrid.Columns["CANCEL_CTA_CTE"].HeaderText = "Cancel. Cta.Cte.";
                    dataGrid.Columns["SALDO_FINAL"].HeaderText = "Saldo Final";
                    dataGrid.Columns["CH"].HeaderText = "¿Planilla Generada?";
                }
                if (dgvConcepto != null && dataGrid.Name == dgvConcepto.Name)
                {
                    dataGrid.Columns["CODIGO"].HeaderText = "Código";
                    dataGrid.Columns["DESCRIPCION"].HeaderText = "Concepto";
                }
            }
        }

        private void WithColumn(DataGridView dataGrid)
        {
            if (dataGrid.Columns.Count > 0)
            {
                if (dataGrid.Name == dgvVendedores.Name)
                {
                    dataGrid.Columns["DESC_PER"].Width = 180;
                    dataGrid.Columns["SALDO_ANTERIOR"].Width = 70;
                    dataGrid.Columns["COMISION_PROPIO"].Width = 70;
                    dataGrid.Columns["COMISION_TERCERO"].Width = 70;
                    dataGrid.Columns["DEVOLUCION"].Width = 60;
                    dataGrid.Columns["OTROS_INGRESOS"].Width = 60;
                    dataGrid.Columns["OTROS_EGRESOS"].Width = 60;
                    dataGrid.Columns["PAGO_CTA_CTE"].Width = 60;
                    dataGrid.Columns["CANCEL_CTA_CTE"].Width = 60;
                    dataGrid.Columns["SALDO_FINAL"].Width = 70;
                    dataGrid.Columns["CH"].Width = 60;
                }

                if (dataGrid.Name == dgvIngreEgre.Name)
                {
                    dataGrid.Columns["FECHA_MOVIMIENTO"].Width = 70;
                    dataGrid.Columns["CODIGO_CON"].Width = 60;
                    dataGrid.Columns["DESC_CON"].Width = 150;
                    dataGrid.Columns["INGRESO"].Width = 70;
                    dataGrid.Columns["EGRESO"].Width = 70;
                }

                if (dgvConcepto != null && dataGrid.Name == dgvConcepto.Name)
                {
                    dataGrid.Columns["CODIGO"].Width = 50;
                    dataGrid.Columns["DESCRIPCION"].Width = 295;
                }
            }
        }

        private void AlignTextContentCell(DataGridView dataGrid)
        {
            //string[] columns2 = { "TOTAL_CUOTA_PAGADA", "IMPORTE_DESCONTAR" };
            //dataGrid.ColumnasAlinear(columns2, DataGridViewContentAlignment.MiddleRight);
            dataGrid.AlignmentDecimalColumns();
        }

        private void ReadOnlyColumns(DataGridView dataGrid)
        {
            if (dataGrid.Name == dgvVendedores.Name)
            {
                string[] columns = { "CH" };
                dataGrid.ColumnsReadOnlyExcept(columns);
            }

            if (dataGrid.Name == dgvIngreEgre.Name)
            {
                string[] columns = { "FECHA_MOVIMIENTO" };
                dataGrid.ColumnsReadOnly(columns);
            }
        }

        private DataRow ObtenerPeriodoSeleccionado()
        {
            try
            {
                if (dtPeriodoGenerado != null)
                    return dtPeriodoGenerado.Select("ID = " + Convert.ToInt32(cboPeriodoGen.SelectedValue)).First();
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

        private async void CboPeriodoGen_SelectionChangeCommitted(object sender, EventArgs e)
        {
            FrmLoading frm = null;
            frm = frm.StartLoadingForm(this);
            cboPeriodoGen.Enabled = false;
            await ListarVendedores();
            frm.CloseLoadingForm();
            cboPeriodoGen.Enabled = true;
            EstablcerEstadoRegistro();
            ActualizarDatosSegunCerrarAbrirPeriodo();
        }

        private void DgvVendedores_SelectionChanged(object sender, EventArgs e)
        {
            ListarOtrosMovimeintos();
            MostrarTotalesIngresoEgreso();
        }

        private void ListarOtrosMovimeintos()
        {
            DataTable dt = null;
            if (dgvVendedores.CurrentCell != null)
            {
                DataRow row = ObtenerPeriodoSeleccionado();
                MovimientosNivelVentaTo to = new MovimientosNivelVentaTo
                {
                    COD_PER = dgvVendedores.CurrentRow.Cells["COD_PER"].Value?.ToString(),
                    FE_AÑO_PER = row["FE_AÑO_PER"].ToString(),
                    FE_MES_PER = row["FE_MES_PER"].ToString()
                };
                dt = BLComision.ListarOtrosMovimientosXVendedor(to);
            }
            CargarDgv(dt);
        }

        private void CargarDgv(DataTable dt)
        {
            dgvIngreEgre.Rows.Clear();
            if (dgvIngreEgre.Columns.Count == 0)
            {
                AddColumnsRange();
                dgvIngreEgre.EnableHeadersVisualStyles = false;
                AjusteColumnas(dgvIngreEgre);
                dgvIngreEgre.AlingHeaderTextCenter();
            }
            dgvIngreEgre.AddRangeRowsDataGridView(dt);
        }

        private void AddColumnsRange()
        {
            var columns = new[]
            {
                new { name = "ID_MOVIMIENTO", headerText = "ID_MOVIMIENTO", visible = false, readOnly = false, esBool = false},
                new { name = "FECHA_MOVIMIENTO", headerText = "Fecha Movimiento", visible = true, readOnly = true, esBool = false},
                new { name = "CODIGO_CON", headerText = "Cod. Concepto", visible = true, readOnly = false, esBool = false},
                new { name = "DESC_CON", headerText = "Concepto", visible = true, readOnly = false, esBool = false},
                new { name = "INGRESO", headerText = "Ingresos S/", visible = true, readOnly = false, esBool = false},
                new { name = "EGRESO", headerText = "Egresos S/", visible = true, readOnly = false, esBool = false},
            };

            DataGridViewColumn[] arrColumn = new DataGridViewColumn[columns.Length];
            int io = 0;
            foreach (var item in columns)
            {
                if (!item.esBool)
                {
                    arrColumn[io] = new DataGridViewTextBoxColumn
                    {
                        Name = item.name,
                        HeaderText = item.headerText,
                        Visible = item.visible,
                        ReadOnly = item.readOnly
                    };
                }
                else
                {
                    arrColumn[io] = new DataGridViewCheckBoxColumn
                    {
                        Name = item.name,
                        HeaderText = item.headerText,
                        Visible = item.visible,
                        ReadOnly = item.readOnly
                    };
                }
                io++;
            }
            dgvIngreEgre.Columns.AddRange(arrColumn);
            dgvIngreEgre.Columns["INGRESO"].ValueType = typeof(decimal);
            dgvIngreEgre.Columns["EGRESO"].ValueType = typeof(decimal);
            dgvIngreEgre.Columns["FECHA_MOVIMIENTO"].ValueType = typeof(DateTime);

        }

        private void DgvIngreEgre_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            DataGridView dataGrid = sender as DataGridView;
            if (dataGrid.IsCurrentCellDirty)
            {
                dataGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void DgvIngreEgre_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            CellEndEditCodigoConcepto(e);
            ValidarSoloIngresarImporteEgresoOIngreso(e);
            MostrarTotalesIngresoEgreso();
        }

        private void CellEndEditCodigoConcepto(DataGridViewCellEventArgs e)
        {
            if (dgvIngreEgre.Columns[e.ColumnIndex].Name == COLUMN_NAME1)
            {
                if (lstDir != null)
                {
                    string codConceptoUpper = dgvIngreEgre[e.ColumnIndex, e.RowIndex].Value?.ToString().ToUpper();
                    directorioTo dir = lstDir.Where(x => x.CODIGO == codConceptoUpper).FirstOrDefault();
                    dgvIngreEgre[e.ColumnIndex, e.RowIndex].Value = dir?.CODIGO;
                    dgvIngreEgre[e.ColumnIndex + 1, e.RowIndex].Value = dir?.DESCRIPCION;
                    if (dir != null && !accShowDgvConcepto)
                        dgvConcepto.Hide();
                }
            }
        }

        private void ValidarSoloIngresarImporteEgresoOIngreso(DataGridViewCellEventArgs e)
        {
            if (dgvIngreEgre.CurrentCell == null)
                return;

            if (dgvIngreEgre.Columns[e.ColumnIndex].Name != COLUMN_NAME2 && dgvIngreEgre.Columns[e.ColumnIndex].Name != COLUMN_NAME3)
                return;

            if (string.IsNullOrEmpty(dgvIngreEgre.CurrentRow.Cells[COLUMN_NAME1].Value?.ToString()) &&
                decimal.TryParse(dgvIngreEgre.CurrentRow.Cells[e.ColumnIndex].Value?.ToString(), out decimal value) && value > 0)
            {
                dgvIngreEgre.CurrentRow.Cells[e.ColumnIndex].Value = "";
                _ = MessageBox.Show("Primero seleccione el concepto", "MESSSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvIngreEgre.Columns[e.ColumnIndex].Name == COLUMN_NAME2 &&
                dgvIngreEgre.CurrentRow.Cells[COLUMN_NAME1].Value?.ToString().First().ToString() == CODIGO_INI_EGRESO &&
                decimal.TryParse(dgvIngreEgre.CurrentRow.Cells[COLUMN_NAME2].Value?.ToString(), out decimal val) && val > 0)
            {
                dgvIngreEgre.CurrentRow.Cells[COLUMN_NAME2].Value = 0;
                _ = MessageBox.Show("Este concepto es de tipo egreso, ingrese el importe en la columna de egresos", "MESSSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvIngreEgre.Columns[e.ColumnIndex].Name == COLUMN_NAME3 &&
                dgvIngreEgre.CurrentRow.Cells[COLUMN_NAME1].Value?.ToString().First().ToString() == CODIGO_INI_INGRESO &&
                decimal.TryParse(dgvIngreEgre.CurrentRow.Cells[COLUMN_NAME3].Value?.ToString(), out decimal val2) && val2 > 0)
            {
                dgvIngreEgre.CurrentRow.Cells[COLUMN_NAME3].Value = 0;
                _ = MessageBox.Show("Este concepto es de tipo ingreso, ingrese el importe en la columna de ingresos", "MESSSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void DgvIngreEgre_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (lstDir != null)
            {
                directorioTo dir = lstDir.Where(x => x.CODIGO == dgvIngreEgre[e.ColumnIndex, e.RowIndex].Value?.ToString()).FirstOrDefault();
                accShowDgvConcepto = dir != null;
            }

            InitializeDgvConcepto(e);
        }

        private void DgvIngreEgre_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || dgvIngreEgre.Columns[e.ColumnIndex].Name != COLUMN_NAME1)
                HideDgvConcepto();
        }

        private void InitializeDgvConcepto(DataGridViewCellCancelEventArgs e)
        {
            if (e.RowIndex > -1 && dgvIngreEgre.Columns[e.ColumnIndex].Name == COLUMN_NAME1)
            {
                dgvConcepto = dgvConcepto ?? new DataGridView();
                Rectangle cellRectangle = dgvIngreEgre.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                Point c = dgvIngreEgre.PointToScreen(cellRectangle.Location);
                Point r = PointToClient(c);
                dgvConcepto.Name = "dgvConcepto";
                dgvConcepto.Size = new Size { Width = 345, Height = 190 };
                dgvConcepto.Location = new Point { X = r.X, Y = r.Y + cellRectangle.Height };
                if (string.IsNullOrEmpty(dgvConcepto.Tag?.ToString()))
                {
                    InitializeEventsDgvConcepto();
                    CargarConceptos();
                    Controls.Add(dgvConcepto);
                    dgvConcepto.Tag = "1";
                    dgvConcepto.EnableHeadersVisualStyles = false;
                    dgvConcepto.ReadOnly = true;
                    dgvConcepto.BringToFront();
                    dgvConcepto.Style3();
                    dgvConcepto.BackgroundColor = Color.White;
                    AjusteColumnas(dgvConcepto);
                }
                dgvConcepto.Show();
            }
            else HideDgvConcepto();
        }

        private void InitializeEventsDgvConcepto()
        {
            if (dgvConcepto != null)
            {
                dgvConcepto.KeyDown += new KeyEventHandler(DgvConcepto_KeyDow);
                dgvConcepto.DoubleClick += new EventHandler(DgvConcepto_DoubleClick);
            }
        }

        private void DgvConcepto_KeyDow(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                dgvConcepto.Hide();
            }
            if (e.KeyCode == Keys.Enter)
            {
                if (dgvConcepto.CurrentRow != null)
                {
                    dgvIngreEgre.CurrentRow.Cells["CODIGO_CON"].Value = dgvConcepto.CurrentRow.Cells["CODIGO"].Value?.ToString();
                    dgvIngreEgre.CurrentRow.Cells["DESC_CON"].Value = dgvConcepto.CurrentRow.Cells["DESCRIPCION"].Value?.ToString();
                }
                dgvConcepto.Hide();
            }
        }

        private void DgvConcepto_DoubleClick(object sender, EventArgs e)
        {
            if (dgvConcepto.CurrentRow != null)
            {
                dgvIngreEgre.CurrentRow.Cells["CODIGO_CON"].Value = dgvConcepto.CurrentRow.Cells["CODIGO"].Value?.ToString();
                dgvIngreEgre.CurrentRow.Cells["DESC_CON"].Value = dgvConcepto.CurrentRow.Cells["DESCRIPCION"].Value?.ToString();
            }
            dgvConcepto.Hide();
        }

        private void CargarConceptos()
        {
            if (dgvConcepto != null)
            {
                directorioTo dir = new directorioTo { TABLA_COD = TABLA_COD, TIPO = TIPO };
                lstDir = lstDir ?? BLDirectorio.ListarDirectorioXParametros(dir);
                if (lstDir != null)
                {
                    List<directorioTo> lista = lstDir.Where(x => x.CODIGO != "E000" && x.CODIGO != "I000").ToList();
                    dgvConcepto.DataSource = lista;
                }
            }
        }

        private void HideDgvConcepto()
        {
            dgvConcepto?.Hide();
        }

        private void BtnGrabar_Click(object sender, EventArgs e)
        {
            RegistrarMovimientosNivelVenta();
        }

        private void RegistrarMovimientosNivelVenta()
        {
            try
            {
                List<MovimientosNivelVentaTo> lstRegistrar = ObtenerDatosRegistrar();
                List<MovimientosNivelVentaTo> lstActualizar = ObtenerDatosActualizar();
                if (!ValidarGrabar(lstRegistrar, lstActualizar))
                    return;
                if (BLComision.GrabarMovimientosNivelVenta(lstRegistrar, lstActualizar))
                {
                    _ = MessageBox.Show("Registrado correctamente", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ActualizarFilaActual(lstRegistrar);
                    ActualizarFilaActual2();
                }
                else
                    _ = MessageBox.Show("Error al guadar los datos", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                ex.PrintException();
            }
        }

        private List<MovimientosNivelVentaTo> ObtenerDatosRegistrar()
        {
            try
            {
                if (dgvVendedores.CurrentCell == null)
                    return null;

                List<MovimientosNivelVentaTo> lista = new List<MovimientosNivelVentaTo>();
                DataRow row = ObtenerPeriodoSeleccionado();
                int cantDias = DateTime.DaysInMonth(row["FE_AÑO_PER"].ToInt32(), row["FE_MES_PER"].ToInt32());
                foreach (DataGridViewRow item in dgvIngreEgre.Rows)
                {
                    if (int.TryParse(item.Cells["ID_MOVIMIENTO"].Value?.ToString(), out int idMovimiento) && idMovimiento > 0)
                        continue;
                    if (string.IsNullOrEmpty(item.Cells["CODIGO_CON"].Value?.ToString()))
                        continue;
                    lista.Add(new MovimientosNivelVentaTo
                    {
                        COD_PER = dgvVendedores.CurrentRow.Cells["COD_PER"].Value.ToString(),
                        COD_NIVEL = COD_NIVEL_VENDEDOR,
                        FECHA_MOVIMIENTO = new DateTime(row["FE_AÑO_PER"].ToInt32(), row["FE_MES_PER"].ToInt32(), cantDias),
                        FE_MES_PER = row["FE_MES_PER"].ToString(),
                        FE_AÑO_PER = row["FE_AÑO_PER"].ToString(),
                        TABLA_CON = TABLA_COD,
                        TIPO_CON = TIPO,
                        CODIGO_CON = item.Cells["CODIGO_CON"].Value.ToString(),
                        DESC_CON = item.Cells["DESC_CON"].Value.ToString(),
                        TIPO_MOVIMIENTO = ObtenerTipoMovimiento(item),
                        IMPORTE = ObtenerImporteMovimiento(item),
                        USUARIO_CREA = UsuarioSistema.Cod_usu
                    });
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<MovimientosNivelVentaTo> ObtenerDatosActualizar()
        {
            try
            {
                if (dgvVendedores.CurrentCell == null)
                    return null;

                List<MovimientosNivelVentaTo> lista = new List<MovimientosNivelVentaTo>();
                DataRow row = ObtenerPeriodoSeleccionado();
                foreach (DataGridViewRow item in dgvIngreEgre.Rows)
                {
                    if (!int.TryParse(item.Cells["ID_MOVIMIENTO"].Value?.ToString(), out int idMovimiento) && idMovimiento == 0)
                        continue;

                    lista.Add(new MovimientosNivelVentaTo
                    {
                        ID_MOVIMIENTO = item.Cells["ID_MOVIMIENTO"].Value.ToInt32(),
                        TABLA_CON = TABLA_COD,
                        TIPO_CON = TIPO,
                        CODIGO_CON = item.Cells["CODIGO_CON"].Value.ToString(),
                        DESC_CON = item.Cells["DESC_CON"].Value.ToString(),
                        TIPO_MOVIMIENTO = ObtenerTipoMovimiento(item),
                        IMPORTE = ObtenerImporteMovimiento(item),
                        USUARIO_MODIFICA = UsuarioSistema.Cod_usu
                    });
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private int ObtenerTipoMovimiento(DataGridViewRow row)
        {
            if (decimal.TryParse(row.Cells[COLUMN_NAME2].Value?.ToString(), out decimal valor))
            {
                if (valor != 0)
                    return INGRESO;
            }

            if (decimal.TryParse(row.Cells[COLUMN_NAME3].Value?.ToString(), out decimal valor2))
            {
                if (valor2 != 0)
                    return EGRESO;
            }
            return 0;
        }

        private decimal ObtenerImporteMovimiento(DataGridViewRow row)
        {
            if (decimal.TryParse(row.Cells[COLUMN_NAME2].Value?.ToString(), out decimal valor) && valor != 0)
            {
                return valor;
            }

            if (decimal.TryParse(row.Cells[COLUMN_NAME3].Value?.ToString(), out decimal valor2) && valor2 != 0)
            {
                return valor2;
            }
            return 0;
        }

        private bool ValidarGrabar(List<MovimientosNivelVentaTo> lstRegistrar, List<MovimientosNivelVentaTo> lstActualizar)
        {
            if (lstRegistrar.Count == 0 && lstActualizar.Count == 0)
            {
                _ = MessageBox.Show("Ingrese al menos un concepto a registrar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Actualiza las filas del dgvIngreEgre
        /// </summary>
        /// <param name="lstTo">Lista de objecto MovimientosNivelVentaTo</param>
        private void ActualizarFilaActual(List<MovimientosNivelVentaTo> lstTo)
        {
            DataGridViewRow[] rowArr = dgvIngreEgre.Rows.Cast<DataGridViewRow>().Where(x => !int.TryParse(x.Cells["ID_MOVIMIENTO"].Value?.ToString(), out _)
            && x.Cells["CODIGO_CON"].Value?.ToString().Trim().Length > 0).ToArray();
            if (rowArr == null || rowArr.Length != lstTo.Count)
            {
                _ = MessageBox.Show("Error al actualizar el dgv \n Cierre el formulario y vuelva abrir", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            for (int io = 0; io < lstTo.Count(); io++)
            {
                rowArr[io].Cells["ID_MOVIMIENTO"].Value = lstTo[io].ID_MOVIMIENTO;
                rowArr[io].Cells["FECHA_MOVIMIENTO"].Value = lstTo[io].FECHA_MOVIMIENTO;
            }
        }

        /// <summary>
        /// Actualiza las filas del dgvVendedores con los importes ingresados en el dgvIngreEgre
        /// </summary>
        private void ActualizarFilaActual2()
        {
            decimal ingreso = 0, egreso = 0;
            foreach (DataGridViewRow row in dgvIngreEgre.Rows)
            {
                ingreso += decimal.TryParse(row.Cells[COLUMN_NAME2].Value?.ToString(), out decimal value) ? value : 0;
                egreso += decimal.TryParse(row.Cells[COLUMN_NAME3].Value?.ToString(), out decimal value2) ? value2 : 0;
            }
            dgvVendedores.CurrentRow.Cells["OTROS_INGRESOS"].Value = ingreso;
            dgvVendedores.CurrentRow.Cells["OTROS_EGRESOS"].Value = egreso;
            decimal comisionPropia = decimal.TryParse(dgvVendedores.CurrentRow.Cells["COMISION_PROPIO"].Value?.ToString(), out decimal com) ? com : 0;
            decimal comisionTercero = decimal.TryParse(dgvVendedores.CurrentRow.Cells["COMISION_TERCERO"].Value?.ToString(), out decimal com2) ? com2 : 0;
            decimal devolucion = decimal.TryParse(dgvVendedores.CurrentRow.Cells["DEVOLUCION"].Value?.ToString(), out decimal dev) ? dev : 0;
            decimal pagoCtaCte = decimal.TryParse(dgvVendedores.CurrentRow.Cells["PAGO_CTA_CTE"].Value?.ToString(), out decimal value3) ? value3 : 0;
            decimal cancelCtaCte = decimal.TryParse(dgvVendedores.CurrentRow.Cells["CANCEL_CTA_CTE"].Value?.ToString(), out decimal value4) ? value4 : 0;
            decimal saldoAnterior = decimal.TryParse(dgvVendedores.CurrentRow.Cells["SALDO_ANTERIOR"].Value?.ToString(), out decimal value5) ? value5 : 0;

            dgvVendedores.CurrentRow.Cells["SALDO_FINAL"].Value = saldoAnterior + comisionPropia + comisionTercero + ingreso - pagoCtaCte - devolucion - egreso - cancelCtaCte;
        }

        private void DgvIngreEgre_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (dgvIngreEgre.Columns[e.ColumnIndex].Name == COLUMN_NAME2 || dgvIngreEgre.Columns[e.ColumnIndex].Name == COLUMN_NAME3)
            {
                //> _ = MessageBox.Show("Ingrese valores numéricos o decimales", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (e.Exception is ConstraintException)
            {
                DataGridView view = (DataGridView)sender;
                view.Rows[e.RowIndex].ErrorText = "an error";
                view.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "an error";

                e.ThrowException = false;
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            HideDgvConcepto();
            if (!ValidarEliminar()) return;

            if (MessageBox.Show("¿Esta seguro de eliminar el registro seleccionado?", "MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                == DialogResult.Yes)
            {
                MovimientosNivelVentaTo movTo = ObtenerDatosEliminar();
                if (movTo != null)
                {
                    if (BLComision.EliminarMovimientosNivelVenta(movTo))
                    {
                        _ = MessageBox.Show("Eliminado correctamente", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        EliminarDgvRegistroEliminado();
                        ActualizarFilaActual2();
                    }
                    else _ = MessageBox.Show("Error al eliminar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private MovimientosNivelVentaTo ObtenerDatosEliminar()
        {
            return new MovimientosNivelVentaTo
            {
                ID_MOVIMIENTO = dgvIngreEgre.CurrentRow.Cells["ID_MOVIMIENTO"].Value.ToInt32()
            };
        }

        private bool ValidarEliminar()
        {
            if (dgvVendedores.CurrentCell == null)
                return false;
            if (!int.TryParse(dgvIngreEgre.CurrentRow.Cells["ID_MOVIMIENTO"].Value?.ToString(), out int _))
                return false;
            if (int.TryParse(dgvIngreEgre.CurrentRow.Cells["ID_MOVIMIENTO"].Value?.ToString(), out int idMovimeinto) && idMovimeinto == 0)
                return false;
            return true;
        }

        private void EliminarDgvRegistroEliminado()
        {
            dgvIngreEgre.Rows.RemoveAt(dgvIngreEgre.CurrentCell.RowIndex);
        }

        private void BtnGrabar_MouseDown(object sender, MouseEventArgs e)
        {
            HideDgvConcepto();
        }

        private void MostrarTotalesIngresoEgreso()
        {
            decimal ingreso = 0, egreso = 0;
            foreach (DataGridViewRow row in dgvIngreEgre.Rows)
            {
                ingreso += decimal.TryParse(row.Cells[COLUMN_NAME2].Value?.ToString(), out decimal value) ? value : 0;
                egreso += decimal.TryParse(row.Cells[COLUMN_NAME3].Value?.ToString(), out decimal value2) ? value2 : 0;
            }

            lblCantRegistro2.Text = string.Concat("Cant: ", dgvIngreEgre.Rows.Count);
            lblTotIngreso.Text = string.Concat("Ingresos: ", ingreso.FormatoMiles());
            lblTotEgreso.Text = string.Concat("Egresos: ", egreso.FormatoMiles());
        }

        private void MostrarTotalesVendedores()
        {
            decimal ingreso = 0, egreso = 0, comisionPropia = 0, comisionTercero = 0, devolucion = 0, pagoCtaCte = 0, cancelCtaCte = 0, saldoFinal = 0;
            foreach (DataGridViewRow row in dgvVendedores.Rows)
            {
                comisionPropia += decimal.TryParse(row.Cells["COMISION_PROPIO"].Value?.ToString(), out decimal com) ? com : 0;
                comisionTercero += decimal.TryParse(row.Cells["COMISION_TERCERO"].Value?.ToString(), out decimal com2) ? com2 : 0;
                devolucion += decimal.TryParse(row.Cells["DEVOLUCION"].Value?.ToString(), out decimal dev) ? dev : 0;
                ingreso += decimal.TryParse(row.Cells["OTROS_INGRESOS"].Value?.ToString(), out decimal value) ? value : 0;
                egreso += decimal.TryParse(row.Cells["OTROS_EGRESOS"].Value?.ToString(), out decimal value2) ? value2 : 0;
                pagoCtaCte += decimal.TryParse(row.Cells["PAGO_CTA_CTE"].Value?.ToString(), out decimal value3) ? value3 : 0;
                cancelCtaCte += decimal.TryParse(row.Cells["CANCEL_CTA_CTE"].Value?.ToString(), out decimal value4) ? value4 : 0;
                saldoFinal += decimal.TryParse(row.Cells["SALDO_FINAL"].Value?.ToString(), out decimal value5) ? value5 : 0;
            }

            RemoveColumnsLstvTotalesVendedores();
            CrearColumnasLstvTotalesVendedores(saldoFinal, comisionPropia, comisionTercero, devolucion, ingreso, egreso, pagoCtaCte, cancelCtaCte);
        }

        private void RemoveColumnsLstvTotalesVendedores()
        {
            foreach (ColumnHeader column in lstvTotalesVendedores.Columns)
            {
                lstvTotalesVendedores.Columns.Remove(column);
            }
        }

        private void CrearColumnasLstvTotalesVendedores(decimal saldoAnterior, decimal comisionPropia, decimal comisionTercero, decimal devolucion, decimal ingreso, decimal egreso,
            decimal pagoCtaCte, decimal cancelCtaCte)
        {
            decimal saldoFinal = saldoAnterior + (comisionPropia + comisionTercero + ingreso + pagoCtaCte - devolucion - egreso);
            var columns = new[]
            {
                new {name = "CANTIDAD_REGISTRO", headerText = string.Concat("Cant. Registros: ", dgvVendedores.Rows.Count.ToString()), width = 180, textAlign = HorizontalAlignment.Left},
                new {name = "SALDO_ANTERIOR", headerText = saldoAnterior.FormatoMiles(), width = 70, textAlign = HorizontalAlignment.Right},
                new {name = "COMISIONES", headerText = comisionPropia.FormatoMiles(), width = 70, textAlign = HorizontalAlignment.Right},
                new {name = "COMISIONES", headerText = comisionTercero.FormatoMiles(), width = 70, textAlign = HorizontalAlignment.Right},
                new {name = "DEVOLUCIONES", headerText = devolucion.FormatoMiles(), width = 60, textAlign = HorizontalAlignment.Right},
                new {name = "OTROS_INGRESOS", headerText = ingreso.FormatoMiles(), width = 60, textAlign = HorizontalAlignment.Right},
                new {name = "OTROS_EGRESOS", headerText = egreso.FormatoMiles(), width = 60, textAlign = HorizontalAlignment.Right},
                new {name = "PAGO_CTA_CTE", headerText = pagoCtaCte.FormatoMiles(), width = 60, textAlign = HorizontalAlignment.Right},
                new {name = "CANCEL_CTA_CTE", headerText = cancelCtaCte.FormatoMiles(), width = 60, textAlign = HorizontalAlignment.Right},
                new {name = "TOTAL_NETO", headerText = saldoFinal.FormatoMiles(), width = 70, textAlign = HorizontalAlignment.Right},
            };

            if (lstvTotalesVendedores.Columns.Count == 0)
            {
                foreach (var item in columns)
                {
                    _ = lstvTotalesVendedores.Columns.Add(item.name, item.headerText, item.width, item.textAlign, 0);
                }
            }
        }

        private void FrmRegistroOtrosIngresosEgresosVendedores_FormClosing(object sender, FormClosingEventArgs e)
        {
            int cant = dgvIngreEgre.Rows.Cast<DataGridViewRow>().Count(x => string.IsNullOrEmpty(x.Cells["ID_MOVIMIENTO"].Value?.ToString())
            && !string.IsNullOrEmpty(x.Cells["CODIGO_CON"].Value?.ToString()));
            if (cant > 0)
            {
                if (MessageBox.Show("¿Esta seguro de salir sin guardar los cambios?", "MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                    == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        public static void ColorListViewHeader(ListView list, Color backColor, Color foreColor)
        {
            list.OwnerDraw = true;
            list.DrawColumnHeader +=
                new DrawListViewColumnHeaderEventHandler
                (
                    (sender, e) => HeaderDraw(sender, e, backColor, foreColor)
                );
            list.DrawItem += new DrawListViewItemEventHandler(BodyDraw);
        }

        private static void HeaderDraw(object sender, DrawListViewColumnHeaderEventArgs e, Color backColor, Color foreColor)
        {
            using (SolidBrush backBrush = new SolidBrush(backColor))
            {
                e.Graphics.FillRectangle(backBrush, e.Bounds);
            }

            using (SolidBrush foreBrush = new SolidBrush(foreColor))
            {
                using (StringFormat format = new StringFormat())
                {
                    format.Alignment = StringAlignment.Far;
                    format.LineAlignment = StringAlignment.Center;

                    if (e.ColumnIndex > 0)
                        e.Graphics.DrawString(e.Header.Text, e.Font, foreBrush, e.Bounds, format);
                }

                using (StringFormat format = new StringFormat())
                {
                    format.Alignment = StringAlignment.Near;
                    format.LineAlignment = StringAlignment.Center;

                    if (e.ColumnIndex == 0)
                        e.Graphics.DrawString(e.Header.Text, e.Font, foreBrush, e.Bounds, format);
                }
            }
        }

        private static void BodyDraw(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void BtnLiqidar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(string.Concat("¿Esta seguro de liquidar este periodo ", cboPeriodoGen.Text, "?"), "MESSAGE", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    List<LiquidacionTo> lstLiquiComision = ObtenerDatosComision();
                    List<LiquidacionTo> lstLiquiDevolucion = ObtenerDatosDevolucion();
                    List<LiquidacionTo> lstLiquiOtrosIngresos = ObtenerDatosOtrosIngresos();
                    List<LiquidacionTo> lstLiquiOtrosEgresos = ObtenerDatosOtrosEgresos();
                    if (BLComision.GrabarLiquidacionNivelVenta(lstLiquiComision, lstLiquiDevolucion, lstLiquiOtrosIngresos, lstLiquiOtrosEgresos))
                        _ = MessageBox.Show("Registrado Correctamente", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        _ = MessageBox.Show("Error al registrar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ListarVendedores();
                }
            }
            catch (Exception ex)
            {
                ex.PrintException2();
            }
        }

        private List<LiquidacionTo> ObtenerDatosComision()
        {
            List<LiquidacionTo> lista = new List<LiquidacionTo>();
            DataGridViewRow[] arrRow = dgvVendedores.Rows.Cast<DataGridViewRow>().Where(x => x.Cells["COMISION_PROPIO"].Value.ToDecimal() > 0 && !x.Cells["CH"].Value.ToBoolean()).ToArray();
            DataGridViewRow[] arrRow2 = dgvVendedores.Rows.Cast<DataGridViewRow>().Where(x => x.Cells["COMISION_TERCERO"].Value.ToDecimal() > 0 && !x.Cells["CH"].Value.ToBoolean()).ToArray();
            int leng1 = arrRow != null ? arrRow.Length : 0;
            int leng2 = arrRow2 != null ? arrRow2.Length : 0;
            LiquidacionTo[] arrLiqui = new LiquidacionTo[leng1 + leng2];
            DataRow rwPeriodo = ObtenerPeriodoSeleccionado();
            int io = 0;
            //> Comisiones propias son de la persona pero comisiones ganadas como vendedor
            foreach (DataGridViewRow row in arrRow)
            {
                LiquidacionTo to = new LiquidacionTo
                {
                    TIPO_LIQUIDACION = TIPO_LIQUIDACION.COMISIONES_PROPIOS,
                    COD_PER = row.Cells["COD_PER"].Value.ToString(),
                    COD_NIVEL = COD_NIVEL_VENDEDOR,
                    FE_AÑO_PER = rwPeriodo["FE_AÑO_PER"].ToString(),
                    FE_MES_PER = rwPeriodo["FE_MES_PER"].ToString(),
                    IMPORTE = row.Cells["COMISION_PROPIO"].Value.ToDecimal(),
                    USUARIO_CREA = UsuarioSistema.Cod_usu,
                    USUARIO_MODIFICA = UsuarioSistema.Cod_usu
                };
                arrLiqui[io] = to;
                io++;
            }
            //> Comisiones tercero son de la persona pero comisiones ganadas como director de ventas, supervisor, director nacional
            foreach (DataGridViewRow row in arrRow2)
            {
                LiquidacionTo to = new LiquidacionTo
                {
                    TIPO_LIQUIDACION = TIPO_LIQUIDACION.COMISIONES_TERCEROS,
                    COD_PER = row.Cells["COD_PER"].Value.ToString(),
                    COD_NIVEL = COD_NIVEL_VENDEDOR,
                    FE_AÑO_PER = rwPeriodo["FE_AÑO_PER"].ToString(),
                    FE_MES_PER = rwPeriodo["FE_MES_PER"].ToString(),
                    IMPORTE = row.Cells["COMISION_TERCERO"].Value.ToDecimal(),
                    USUARIO_CREA = UsuarioSistema.Cod_usu,
                    USUARIO_MODIFICA = UsuarioSistema.Cod_usu
                };
                arrLiqui[io] = to;
                io++;
            }
            lista.AddRange(arrLiqui);
            return lista;
        }

        private List<LiquidacionTo> ObtenerDatosDevolucion()
        {
            List<LiquidacionTo> lista = new List<LiquidacionTo>();
            DataGridViewRow[] arrRow = dgvVendedores.Rows.Cast<DataGridViewRow>().Where(x => x.Cells["DEVOLUCION"].Value.ToDecimal() > 0 && !x.Cells["CH"].Value.ToBoolean()).ToArray();
            LiquidacionTo[] arrLiqui = new LiquidacionTo[arrRow.Length];
            DataRow rwPeriodo = ObtenerPeriodoSeleccionado();
            int io = 0;
            foreach (DataGridViewRow row in arrRow)
            {
                LiquidacionTo to = new LiquidacionTo
                {
                    TIPO_LIQUIDACION = TIPO_LIQUIDACION.DEVOLUCIONES,
                    COD_PER = row.Cells["COD_PER"].Value.ToString(),
                    COD_NIVEL = COD_NIVEL_VENDEDOR,
                    FE_AÑO_PER = rwPeriodo["FE_AÑO_PER"].ToString(),
                    FE_MES_PER = rwPeriodo["FE_MES_PER"].ToString(),
                    IMPORTE = row.Cells["DEVOLUCION"].Value.ToDecimal(),
                    USUARIO_CREA = UsuarioSistema.Cod_usu,
                    USUARIO_MODIFICA = UsuarioSistema.Cod_usu
                };
                arrLiqui[io] = to;
                io++;
            }
            lista.AddRange(arrLiqui);
            return lista;
        }

        private List<LiquidacionTo> ObtenerDatosOtrosIngresos()
        {
            List<LiquidacionTo> lista = new List<LiquidacionTo>();
            DataGridViewRow[] arrRow = dgvVendedores.Rows.Cast<DataGridViewRow>().Where(x => x.Cells["OTROS_INGRESOS"].Value.ToDecimal() > 0 && !x.Cells["CH"].Value.ToBoolean()).ToArray();
            LiquidacionTo[] arrLiqui = new LiquidacionTo[arrRow.Length];
            DataRow rwPeriodo = ObtenerPeriodoSeleccionado();
            int io = 0;
            foreach (DataGridViewRow row in arrRow)
            {
                LiquidacionTo to = new LiquidacionTo
                {
                    TIPO_LIQUIDACION = TIPO_LIQUIDACION.OTROS_INGRESOS,
                    COD_PER = row.Cells["COD_PER"].Value.ToString(),
                    COD_NIVEL = COD_NIVEL_VENDEDOR,
                    FE_AÑO_PER = rwPeriodo["FE_AÑO_PER"].ToString(),
                    FE_MES_PER = rwPeriodo["FE_MES_PER"].ToString(),
                    IMPORTE = row.Cells["OTROS_INGRESOS"].Value.ToDecimal(),
                    USUARIO_CREA = UsuarioSistema.Cod_usu,
                    USUARIO_MODIFICA = UsuarioSistema.Cod_usu
                };
                arrLiqui[io] = to;
                io++;
            }
            lista.AddRange(arrLiqui);
            return lista;
        }

        private List<LiquidacionTo> ObtenerDatosOtrosEgresos()
        {
            List<LiquidacionTo> lista = new List<LiquidacionTo>();
            DataGridViewRow[] arrRow = dgvVendedores.Rows.Cast<DataGridViewRow>().Where(x => x.Cells["OTROS_EGRESOS"].Value.ToDecimal() > 0 && !x.Cells["CH"].Value.ToBoolean()).ToArray();
            LiquidacionTo[] arrLiqui = new LiquidacionTo[arrRow.Length];
            DataRow rwPeriodo = ObtenerPeriodoSeleccionado();
            int io = 0;
            foreach (DataGridViewRow row in arrRow)
            {
                LiquidacionTo to = new LiquidacionTo
                {
                    TIPO_LIQUIDACION = TIPO_LIQUIDACION.OTROS_EGRESOS,
                    COD_PER = row.Cells["COD_PER"].Value.ToString(),
                    COD_NIVEL = COD_NIVEL_VENDEDOR,
                    FE_AÑO_PER = rwPeriodo["FE_AÑO_PER"].ToString(),
                    FE_MES_PER = rwPeriodo["FE_MES_PER"].ToString(),
                    IMPORTE = row.Cells["OTROS_EGRESOS"].Value.ToDecimal(),
                    USUARIO_CREA = UsuarioSistema.Cod_usu,
                    USUARIO_MODIFICA = UsuarioSistema.Cod_usu
                };
                arrLiqui[io] = to;
                io++;
            }
            lista.AddRange(arrLiqui);
            return lista;
        }

        private void BtnConsultarLiqu_Click(object sender, EventArgs e)
        {
            Form frm = new Form
            {
                Size = new Size { Width = 950, Height = 550 },
                StartPosition = FormStartPosition.CenterScreen
            };

            DataGridView dataGrid = new DataGridView
            {
                Size = new Size { Width = 940, Height = 500 }
            };
            DataRow row = ObtenerPeriodoSeleccionado();
            dataGrid.DataSource = BLComision.ListarLiquidacionGenerada(new LiquidacionTo { FE_AÑO_PER = row["FE_AÑO_PER"].ToString(), FE_MES_PER = row["FE_MES_PER"].ToString() });
            frm.Controls.Add(dataGrid);
            frm.Show();
        }

        private void BtnEliminarLiqu_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow row = ObtenerPeriodoSeleccionado();
                LiquidacionTo to = new LiquidacionTo
                {
                    FE_AÑO_PER = row["FE_AÑO_PER"].ToString(),
                    FE_MES_PER = row["FE_MES_PER"].ToString()
                };
                if (BLComision.EliminarLiquidacionNivelVenta(to))
                    _ = MessageBox.Show("Eliminado correctamente", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    _ = MessageBox.Show("Error al eliminar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListarVendedores();
            }
            catch (Exception ex)
            {
                ex.PrintException2();
            }
        }

        /// <summary>
        /// Calcula el saldo anterior para poder asignar a cada vendedor del dataTable[dtVendedores],
        /// ya que inicialmente el saldo anterior del dataTable [dtVendedores] esta en cero, además actualizamos el saldo final de cada vendedor con el
        /// saldo anterior obtenido
        /// </summary>
        /// <param name="dtVendedores">DataTable que contiene la lista de vendedores a la cual se va actualizar el saldo anterior calculado</param>
        private async Task CalcularSaldoAnterior(DataTable dtVendedores)
        {
            if (dtVendedores == null || dtVendedores.Rows.Count == 0)
                return;
            DataRow row = ObtenerPeriodoSeleccionado();
            LiquidacionTo to = new LiquidacionTo
            {
                FE_AÑO_PER = row["FE_AÑO_PER"].ToString(),
                FE_MES_PER = row["FE_MES_PER"].ToString(),
                COD_PER = string.Empty
            };
            DataTable dt = await Task.Run(() => BLComision.LiquidacionSaldoAnteriorXPersona(to));
            var rowOnlyCodPersona = dt?.AsEnumerable().GroupBy(x => x.Field<string>("A"));
            if (dt == null)
                return;
            Task task2 = new TaskFactory().StartNew(() =>
            {
                DataTable dtPersona = null;
                decimal saldo_anterior = 0;
                decimal comisiones_vetas_propias = 0;
                decimal comisiones_ventas_tercero = 0;
                decimal devoluciones_ventas = 0;
                decimal comisiones_netas = 0;
                decimal otras_adiciones = 0;
                decimal total_ingresos = 0;
                decimal pago_cuenta_corriente = 0;
                decimal otras_deducciones = 0;
                decimal total_deducciones = otras_deducciones;
                decimal saldo_mes = 0;
                decimal saldo_pagar_fin_mes = 0;
                decimal cancelacion_cta_cte = 0;
                decimal saldo_final = 0; //> Representa el saldo anterior del período filtrado en [cboPeriodoGen]

                foreach (var group in rowOnlyCodPersona)
                {
                    DataRow rw = group.First();
                    dtPersona = dt.AsEnumerable().Where(x => x.Field<string>("A") == rw.Field<string>("A")).CopyToDataTable();
                    saldo_anterior = 0;
                    comisiones_vetas_propias = Convert.ToDecimal(dtPersona.AsEnumerable().SingleOrDefault(x => x.Field<int>("Z") == 1 && x.Field<int>("F") == 1)?.Field<decimal>("E"));
                    comisiones_ventas_tercero = Convert.ToDecimal(dtPersona.AsEnumerable().SingleOrDefault(x => x.Field<int>("Z") == 1 && x.Field<int>("F") == 2)?.Field<decimal>("E"));
                    devoluciones_ventas = Convert.ToDecimal(dtPersona.AsEnumerable().SingleOrDefault(x => x.Field<int>("Z") == 2)?.Field<decimal>("E"));
                    comisiones_netas = comisiones_vetas_propias + comisiones_ventas_tercero - devoluciones_ventas;
                    otras_adiciones = (decimal)(dtPersona.AsEnumerable().Where(x => x.Field<int>("Z") == 3 && x.Field<int>("D") == 1)?.Sum(f => f.Field<decimal>("E")));
                    total_ingresos = comisiones_netas + otras_adiciones;
                    pago_cuenta_corriente = Convert.ToDecimal(dtPersona.AsEnumerable().SingleOrDefault(x => x.Field<int>("Z") == 4)?.Field<decimal>("E"));
                    otras_deducciones = (decimal)(dtPersona.AsEnumerable().Where(x => x.Field<int>("Z") == 3 && x.Field<int>("D") == 2)?.Sum(f => f.Field<decimal>("E")));
                    total_deducciones = pago_cuenta_corriente + otras_deducciones;
                    saldo_mes = total_ingresos - total_deducciones;
                    saldo_pagar_fin_mes = saldo_anterior + saldo_mes;
                    cancelacion_cta_cte = Convert.ToDecimal(dtPersona.AsEnumerable().SingleOrDefault(x => x.Field<int>("Z") == 7 && x.Field<int>("F") == 3)?.Field<decimal>("E"));
                    saldo_final = saldo_pagar_fin_mes - cancelacion_cta_cte;

                    DataRow rowVendedor = dtVendedores.AsEnumerable().Where(x => x.Field<string>("COD_PER") == rw.Field<string>("A")).SingleOrDefault();
                    if (rowVendedor != null)
                    {
                        rowVendedor["SALDO_ANTERIOR"] = saldo_final;
                        rowVendedor["SALDO_FINAL"] = rowVendedor["SALDO_ANTERIOR"].ToDecimal() + rowVendedor["SALDO_FINAL"].ToDecimal();
                    }
                }
            });
            await task2;
        }

        private void BtnCerrarAbrir_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarCerrarAbrirLiquidacion())
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
            if (estado_registro == ESTADO_REGISTRO.REGISTRO_PROCESADO)
            {
                CerrarPeriodoGenerado();
                return;
            }
            if (estado_registro == ESTADO_REGISTRO.REGISTRO_APROBADO)
            {
                AbrirPeriodoGenerado();
                return;
            }
        }

        private void CerrarPeriodoGenerado()
        {
            DataRow row = ObtenerPeriodoSeleccionado();
            string nombreMesPer = row["FE_MES_PER"].ToInt32().NombreMesCorta();
            string feAñoPer = row["FE_MES_PER"].ToString();
            if (MessageBox.Show($"¿Esta seguro de cerrar este período: {nombreMesPer} - {feAñoPer}?", "MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                == DialogResult.Yes)
            {
                LiquidacionTo to = ObtenerDatosCerrarAbrirDevolucion();
                if (BLComision.CerrarPeriodoLiquidacion(to))
                {
                    _ = MessageBox.Show("Período cerrado", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ActualizarDatosSegunCerrarAbrirPeriodo();
                    EstablcerEstadoRegistro();
                }
                else
                    _ = MessageBox.Show("Error al cerrar el período", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AbrirPeriodoGenerado()
        {
            DataRow row = ObtenerPeriodoSeleccionado();
            string nombreMesPer = row["FE_MES_PER"].ToInt32().NombreMesCorta();
            string feAñoPer = row["FE_MES_PER"].ToString();
            if (MessageBox.Show($"¿Esta seguro de abrir este período: {nombreMesPer} - {feAñoPer}?", "MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                == DialogResult.Yes)
            {
                LiquidacionTo to = ObtenerDatosCerrarAbrirDevolucion();
                if (BLComision.AbrirPeriodoLiquidacion(to))
                {
                    _ = MessageBox.Show("Período abierto", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ActualizarDatosSegunCerrarAbrirPeriodo();
                    EstablcerEstadoRegistro();
                }
                else
                    _ = MessageBox.Show("Error al abrir el período", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private LiquidacionTo ObtenerDatosCerrarAbrirDevolucion()
        {
            DataRow row = ObtenerPeriodoSeleccionado();
            return new LiquidacionTo
            {
                FE_AÑO_PER = row["FE_AÑO_PER"].ToString(),
                FE_MES_PER = row["FE_MES_PER"].ToString(),
                USUARIO_CREA = UsuarioSistema.Cod_usu,
                USUARIO_MODIFICA = UsuarioSistema.Cod_usu
            };
        }

        private void ActualizarDatosSegunCerrarAbrirPeriodo()
        {
            DataRow row = ObtenerPeriodoSeleccionado();
            LiquidacionTo to = new LiquidacionTo
            {
                FE_AÑO_PER = row["FE_AÑO_PER"].ToString(),
                FE_MES_PER = row["FE_MES_PER"].ToString()
            };
            DataTable dt = BLComision.ObtenerPeriodoLiquidacion(to);
            if (dt != null && dt.Rows.Count > 0 && dt.Rows[0]["ESTADO"].ToInt32() == (int)ESTADO_REGISTRO.REGISTRO_APROBADO)
            {
                MostrarStatusMensaje(string.Format(MENSAJE_CERRADO, cboPeriodoGen.Text));
                btnGrabar.Enabled = false;
                btnEliminar.Enabled = false;
            }
            else
            {
                MostrarStatusMensaje(string.Format(MENSAJE_ABIERTO, cboPeriodoGen.Text));
                btnGrabar.Enabled = true;
                btnEliminar.Enabled = true;
            }
            DgvDevolucionCom_EstablecerAccesos();
        }

        private void DgvDevolucionCom_EstablecerAccesos()
        {
            DataRow row = ObtenerPeriodoSeleccionado();
            LiquidacionTo to = new LiquidacionTo
            {
                FE_AÑO_PER = row["FE_AÑO_PER"].ToString(),
                FE_MES_PER = row["FE_MES_PER"].ToString()
            };
            DataTable dt = BLComision.ObtenerPeriodoLiquidacion(to);
            if (dt != null && dt.Rows.Count > 0 && dt.Rows[0]["ESTADO"].ToInt32() == (int)ESTADO_REGISTRO.REGISTRO_APROBADO)
                dgvIngreEgre.ReadOnly = true;
            else
                dgvIngreEgre.ReadOnly = false;
        }

        private bool ValidarCerrarAbrirLiquidacion()
        {
            if (dgvVendedores.Rows.Count == 0)
                return false;

            DataRow row = ObtenerPeriodoSeleccionado();
            if (row == null || row.ItemArray.Length == 0)
            {
                _ = MessageBox.Show("Primero consulte el periodo a cerrar seleccionado de la lista de periodos", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (estado_registro != ESTADO_REGISTRO.REGISTRO_PROCESADO && estado_registro != ESTADO_REGISTRO.REGISTRO_APROBADO)
            {
                _ = MessageBox.Show("Primero consulte el periodo a cerrar, seleccionado de la lista de periodos", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!VerificarSiComisionesYDevolucionesCerradas())
                return false;

            return true;
        }

        /// <summary>
        /// Verifica si las comisiones generadas y devoluciones de comisiones estan cerradas del periodo seleccionado
        /// </summary>
        /// <returns>True si ambas estan cerradas o no existe el periodo, de lo contrario false</returns>
        private bool VerificarSiComisionesYDevolucionesCerradas()
        {
            DataRow row = ObtenerPeriodoSeleccionado();
            if (estado_registro == ESTADO_REGISTRO.REGISTRO_PROCESADO)
            {
                DataTable dt = BLComision.ObtenerPeriodosGeneradosComision();
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow rw = dt.AsEnumerable().SingleOrDefault(x => x.Field<string>("FE_AÑO_PER") == row["FE_AÑO_PER"].ToString() && x.Field<string>("FE_MES_PER") == row["FE_MES_PER"].ToString());
                    if (rw != null && rw["ESTADO"].ToInt32() != (int)ESTADO_REGISTRO.REGISTRO_APROBADO)
                    {
                        _ = MessageBox.Show($"Primero debe cerrar las comisiones generadas de este periodo: {row["FE_AÑO_PER"]} - {row["FE_MES_PER"].ToInt32().NombreMesCorta()}", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }

                dt = BLComision.ObtenerPeriodosDevolucionComisionGenerados();
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow rw = dt.AsEnumerable().SingleOrDefault(x => x.Field<string>("FE_AÑO_PER") == row["FE_AÑO_PER"].ToString() && x.Field<string>("FE_MES_PER") == row["FE_MES_PER"].ToString());
                    if (rw != null && rw["ESTADO"].ToInt32() != (int)ESTADO_REGISTRO.REGISTRO_APROBADO)
                    {
                        _ = MessageBox.Show($"Primero debe cerrar las devoluciones generadas de este periodo: {row["FE_AÑO_PER"]} - {row["FE_MES_PER"].ToInt32().NombreMesCorta()}", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Establece el valor de la variable [estadoRegistro] según el estado del período
        /// </summary>
        private void EstablcerEstadoRegistro()
        {
            DataRow row = ObtenerPeriodoSeleccionado();
            LiquidacionTo to = new LiquidacionTo
            {
                FE_AÑO_PER = row["FE_AÑO_PER"].ToString(),
                FE_MES_PER = row["FE_MES_PER"].ToString()
            };
            DataTable dt = BLComision.ObtenerPeriodoLiquidacion(to);
            estado_registro = dt != null && dt.Rows.Count > 0 ? (ESTADO_REGISTRO)dt.Rows[0]["ESTADO"].ToInt32() : ESTADO_REGISTRO.REGISTRO_PROCESADO;
        }

        private void MostrarStatusMensaje(string mensaje)
        {
            if (dgvVendedores != null && dgvVendedores.Rows.Count > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = mensaje;
            }
            else
            {
                lblMessage.Visible = false;
            }
        }

        private void DgvVendedores_ColorCabecera()
        {
            Color backColor1 = BackColorColumnDefault;
            Color foreColor1 = ForeColorColumnDefault;
            Color backColor2 = BackColorColumnPrimary;
            Color foreColor2 = ForeColorColumnPrimary;
            int[] arrInt = { 2, 4, 5, 7, 9, 11 };
            dgvVendedores.ColorCabeceraDataGridView(arrInt, backColor1, foreColor1, backColor2, foreColor2);
        }
    }
}
