using BLL;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using static Presentacion.HELPERS.GenericMethod;
using static Presentacion.HELPERS.FormatDataGridViewColumns;
using static Presentacion.HELPERS.AppearanceUtil;
using static Presentacion.HELPERS.ErrorPrint;
using static Presentacion.HELPERS.GenericUtil;
using static Presentacion.HELPERS.Constantes;
using System.Linq;
using Entidades;
using System.Collections.Generic;
using Presentacion.MOD_COMISIONES.Reportes.Formulario;

namespace Presentacion.MOD_COMISIONES
{
    public partial class FrmAdelantoComision : Form
    {
        public FrmAdelantoComision()
        {
            InitializeComponent();
        }

        private readonly comisionesBLL BLComision = new comisionesBLL();

        private DataTable dtContratosParaAdelComision;
        private CRUD crud;
        private int nroAdelantoCorrelativo;
        private decimal importeAdelanto;

        private const int TIPO_COMISION_ADELANTO_CONTRATOS_SIN_APROBAR = 1;
        private const string COLUMN_NAME1 = "IMPORTE_ADELANTO";
        private const string COLUMN_NAME2 = "IMPORTE_COMISION";
        private const string COLUMN_NAME3 = "SALDO_COMISION";
        private const string COLUMN_NAME4 = "ADELANTO";
        private const string COLUMN_NAME5 = "NRO_PLANILLA_DOC";
        private const string COLUMN_NAME6 = "IMPORTE_ADELANTO_ANT";
        private const string COLUMN_NAME7 = "COD_INST";
        private const string COLUMN_NAME8 = "CH";
        private const string TEXT_NRO_ADELANTO_A_GENERAR = "Grupo adelanto a generar";
        private const string TEXT_NRO_ADELANTO_GENERADO = "Grupo adelanto seleccionado";

        private void FrmAdelantoComision_Load(object sender, EventArgs e)
        {
            StartControls();
            CargarGrupoAdelantoComision();
            DgvTotalAdelantoComision_CrearColumnas();
            ListarVendedores();
            DgvVendedores_MostrarTotales();
            MostrarTotalGeneralXGrupo();
            ActualizarVendedoresConNroAdelanto();
        }

        private void StartControls()
        {
            btnGenAdelComision.StyleButtonFlat();
            btnEliminarComision.StyleButtonFlat();
            btnGenerarReporte.StyleButtonFlat();
            btnCerrarAdelantoComision.StyleButtonFlat();
            btnNuevoAdelanto.StyleButtonFlat();
            btnAbrirAdelantoComision.StyleButtonFlat();
            dgvVendedores.Style5(false, false, true, false, false, DataGridViewTriState.True, DataGridViewColumnHeadersHeightSizeMode.AutoSize, DataGridViewTriState.True,
                DataGridViewAutoSizeRowsMode.AllCells, DataGridViewSelectionMode.FullRowSelect, false);
            dgvContratos.Style5(false, false, true, false, false, DataGridViewTriState.True, DataGridViewColumnHeadersHeightSizeMode.AutoSize, DataGridViewTriState.True,
                DataGridViewAutoSizeRowsMode.AllCells, DataGridViewSelectionMode.CellSelect, true);
            dgvTotalAdelantoComision.Style5(false, false, true, false, false, DataGridViewTriState.True, DataGridViewColumnHeadersHeightSizeMode.AutoSize, DataGridViewTriState.True,
                DataGridViewAutoSizeRowsMode.AllCells, DataGridViewSelectionMode.CellSelect, true);
            lstTotalCotratos.View = View.Details;
            lstvTotalesVendedores.View = View.Details;
            lstTotalGeneralXGrupo.View = View.Details;
            ColorListViewHeader(lstTotalCotratos, Color.Teal, Color.White);
            ColorListViewHeader(lstvTotalesVendedores, Color.Teal, Color.White);
            lstTotalGeneralXGrupo.ColorListViewHeader(Color.DimGray, Color.White);
            cboNroAdelanto.DropDownStyle = ComboBoxStyle.DropDownList;
            crud = CRUD.None;
        }

        private void ListarVendedores()
        {
            DataTable dt = BLComision.ListarVendedoresAdelantoComision(COD_PROGRAMA_INGLES);
            if (dgvVendedores.Columns.Count == 0)
            {
                dgvVendedores.AddRangeColumnsDataGridView(dt, false);
                AjusteColumnas(dgvVendedores);
            }
            dgvVendedores.Rows.Clear();
            dgvVendedores.AddRangeRowsDataGridView(dt);
        }

        private void AjusteColumnas(DataGridView dataGrid)
        {
            InvisibleColumn(dataGrid);
            RenamerHeaderText(dataGrid);
            WithColumn(dataGrid);
            AlignTextContentCell(dataGrid);
            ReadOnlyColumns(dataGrid);
            dataGrid.ColorCabeceraDataGridView(Color.Teal, Color.White);
            dataGrid.AlingHeaderTextCenter();
        }

        private void InvisibleColumn(DataGridView dataGrid)
        {
            if (dataGrid.Columns.Count > 0)
            {
                if (dataGrid.Name == dgvVendedores.Name)
                {
                    string[] nameColumns = { "COD_PER", "COD_NIVEL" };
                    dataGrid.InvisibleColumna(nameColumns);
                }
                if (dataGrid.Name == dgvContratos.Name)
                {
                    string[] nameColumns = { "COD_VENDEDOR", "COD_SUCURSAL", "COD_CLASE", "COD_CLIENTE", "FE_AÑO", "FE_MES", "COD_INST", "NRO_CUOTA", "TOTAL_CONTRATO",
                    "COD_NIVEL", "ID_PROCESO", "NRO_PLANILLA_DOC", "CANT_ADELANTO", "NRO_ADELANTO", "FECHA_CREACION", "ESTADO", "ID_I_BANCO"};
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
                    dataGrid.Columns["TOT_COMISION"].HeaderText = "Comisión Ctto";
                    dataGrid.Columns["TOT_ADELANTO_COMISION"].HeaderText = "Adelanto";
                    dataGrid.Columns["SALDO_COMISION"].HeaderText = "Saldo";
                }

                if (dataGrid.Name == dgvContratos.Name)
                {
                    dataGrid.Columns["NRO_PRESUPUESTO"].HeaderText = "Nro Contrato";
                    dataGrid.Columns["FECHA_CREACION"].HeaderText = "Fecha Adelanto";
                    dataGrid.Columns["FECHA_PRE"].HeaderText = "Fecha Ctto.";
                    dataGrid.Columns["DESC_INST"].HeaderText = "Institución";
                    dataGrid.Columns["TOTAL_CONTRATO"].HeaderText = "Total Imp.Ctto";
                    dataGrid.Columns["IMPORTE_COMISION"].HeaderText = "Imp. Comisión";
                    dataGrid.Columns["IMPORTE_ADELANTO_ANT"].HeaderText = "Imp.Adelanto Anterior";
                    dataGrid.Columns["IMPORTE_ADELANTO"].HeaderText = "Imp. Adelanto";
                    dataGrid.Columns["SALDO_COMISION"].HeaderText = "Saldo";
                    dataGrid.Columns["CH"].HeaderText = "¿Gen. Adelanto Comis.?";
                    dataGrid.Columns["ES_ENVIADO"].HeaderText = "Env. a Tesor.";
                    dataGrid.Columns["ES_REG_TESOR"].HeaderText = "Reg. en Tesor.";
                }
            }
        }

        private void WithColumn(DataGridView dataGrid)
        {
            if (dataGrid.Columns.Count > 0)
            {
                if (dataGrid.Name == dgvVendedores.Name)
                {
                    dataGrid.Columns["DESC_PER"].Width = 150;
                    dataGrid.Columns["TOT_COMISION"].Width = 85;
                    dataGrid.Columns["TOT_ADELANTO_COMISION"].Width = 85;
                    dataGrid.Columns["SALDO_COMISION"].Width = 85;
                    dataGrid.Columns["CH"].Width = 40;
                }

                if (dataGrid.Name == dgvContratos.Name)
                {
                    dataGrid.Columns["NRO_PRESUPUESTO"].Width = 65;
                    dataGrid.Columns["FECHA_CREACION"].Width = 70;
                    dataGrid.Columns["DESC_INST"].Width = 90;
                    dataGrid.Columns["FECHA_PRE"].Width = 70;
                    dataGrid.Columns["TOTAL_CONTRATO"].Width = 70;
                    dataGrid.Columns["IMPORTE_COMISION"].Width = 70;
                    dataGrid.Columns["IMPORTE_ADELANTO_ANT"].Width = 70;
                    dataGrid.Columns["IMPORTE_ADELANTO"].Width = 70;
                    dataGrid.Columns["SALDO_COMISION"].Width = 70;
                    dataGrid.Columns["CH"].Width = 65;
                    dataGrid.Columns["ES_ENVIADO"].Width = 50;
                    dataGrid.Columns["ES_REG_TESOR"].Width = 55;
                }
            }
        }

        private void AlignTextContentCell(DataGridView dataGrid)
        {
            dataGrid.AlignmentDecimalColumns();
            if (dataGrid.Name == dgvContratos.Name)
            {
                string[] columns = { "ES_ENVIADO", "NRO_PRESUPUESTO", "FECHA_CREACION", "ES_REG_TESOR" };
                dataGrid.ColumnasAlinear(columns, DataGridViewContentAlignment.MiddleCenter);
            }
        }

        private void ReadOnlyColumns(DataGridView dataGrid)
        {
            if (dataGrid.Name == dgvContratos.Name)
            {
                string[] nameColumns = { "IMPORTE_ADELANTO", "CH" };
                dataGrid.ColumnsReadOnlyExcept(nameColumns);
            }
        }

        private void DgvVendedores_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvVendedores.CurrentRow != null)
            {
                int nroAdelanto = crud == CRUD.Actualizar || crud == CRUD.None ? NroAdelantoSeleccionado : nroAdelantoCorrelativo;
                ListarContratosSinAprobarParaComsionar(nroAdelanto);
                DgvContratos_MostrarTotales();
                DgvTotalAdelantoComision_CargarData();
                importeAdelanto = IMPORTE_ADELANTO;
            }
        }

        private decimal IMPORTE_ADELANTO { get => dgvContratos.Rows.Cast<DataGridViewRow>().Where(x => x.Cells["ID_PROCESO"].Value.ToInt32() > 0).Sum(x => x.Cells[COLUMN_NAME1].Value.ToDecimal()); }

        /// <summary>
        /// Obtiene una lista de contratos sin aprobar por vendedor para generar su adelanto de comisión
        /// </summary>
        private void ListarContratosSinAprobarParaComsionar(int nroAdelanto)
        {
            string codVendedor = dgvVendedores.CurrentRow.Cells["COD_PER"].Value.ToString();
            const string cod_programa_ingles = "01";
            dtContratosParaAdelComision = BLComision.ListarContratosParaAdelantoComision(cod_programa_ingles, codVendedor, nroAdelanto);
            if (dgvContratos.Columns.Count == 0)
            {
                dgvContratos.AddRangeColumnsDataGridView(dtContratosParaAdelComision, false);
                AjusteColumnas(dgvContratos);
            }
            dgvContratos.Rows.Clear();
            dgvContratos.AddRangeRowsDataGridView(dtContratosParaAdelComision);
        }

        private void DgvVendedores_MostrarTotales()
        {
            decimal cantContrato = dgvVendedores.Rows.Count;
            decimal importeComision = 0;
            decimal importeAdelanto = 0;
            decimal saldoComision;
            foreach (DataGridViewRow row in dgvVendedores.Rows)
            {
                importeComision += decimal.TryParse(row.Cells["TOT_COMISION"].Value?.ToString(), out decimal com) ? com : 0;
                importeAdelanto += decimal.TryParse(row.Cells["TOT_ADELANTO_COMISION"].Value?.ToString(), out decimal com2) ? com2 : 0;
            }
            saldoComision = importeComision - importeAdelanto;

            lstvTotalesVendedores.RemoveColumnsLstvTotales();
            int width1 = dgvVendedores.Columns["DESC_PER"].Width;
            int width2 = dgvVendedores.Columns["TOT_COMISION"].Width;
            int width3 = dgvVendedores.Columns["TOT_ADELANTO_COMISION"].Width;
            int width4 = dgvVendedores.Columns["SALDO_COMISION"].Width;
            StringFormat format = new StringFormat
            {
                Alignment = StringAlignment.Near,
                LineAlignment = StringAlignment.Center
            };
            StringFormat format2 = new StringFormat
            {
                Alignment = StringAlignment.Far,
                LineAlignment = StringAlignment.Center
            };
            var columns = new[]
            {
                new {headerText = string.Concat("Cant. Registros: ", cantContrato), width = width1, stringFormat = format},
                new {headerText = importeComision.FormatoMiles(), width = width2, stringFormat = format2},
                new {headerText = importeAdelanto.FormatoMiles(), width = width3, stringFormat = format2},
                new {headerText = saldoComision.FormatoMiles(), width = width4, stringFormat = format2},
            };
            lstvTotalesVendedores.CrearColumnasLstvTotales(columns);
        }

        #region ListView Totales
        private void DgvContratos_MostrarTotales()
        {
            decimal cantContrato = dgvContratos.Rows.Count;
            decimal importeComision = 0;
            decimal importeAdelantoAnt = 0;
            decimal importeAdelanto = 0;
            decimal saldoComision;
            foreach (DataGridViewRow row in dgvContratos.Rows)
            {
                importeComision += decimal.TryParse(row.Cells["IMPORTE_COMISION"].Value?.ToString(), out decimal com) ? com : 0;
                importeAdelanto += decimal.TryParse(row.Cells["IMPORTE_ADELANTO"].Value?.ToString(), out decimal com2) ? com2 : 0;
                importeAdelantoAnt += decimal.TryParse(row.Cells["IMPORTE_ADELANTO_ANT"].Value?.ToString(), out decimal com3) ? com3 : 0;
            }
            saldoComision = importeComision - importeAdelanto;
            int width1 = dgvContratos.Columns["NRO_PRESUPUESTO"].Width + dgvContratos.Columns["DESC_INST"].Width
                + dgvContratos.Columns["FECHA_PRE"].Width;
            int width2 = dgvContratos.Columns["IMPORTE_COMISION"].Width;
            int width3 = dgvContratos.Columns["IMPORTE_ADELANTO"].Width;
            int width4 = dgvContratos.Columns["SALDO_COMISION"].Width;
            int width5 = dgvContratos.Columns["CH"].Width;
            int width6 = dgvContratos.Columns["IMPORTE_ADELANTO_ANT"].Width;
            StringFormat format = new StringFormat
            {
                Alignment = StringAlignment.Near,
                LineAlignment = StringAlignment.Center
            };
            StringFormat format2 = new StringFormat
            {
                Alignment = StringAlignment.Far,
                LineAlignment = StringAlignment.Center
            };
            var columns = new[]
            {
                new {headerText = string.Concat("Cant. Registros: ", cantContrato), width = width1, stringFormat = format},
                new {headerText = importeComision.FormatoMiles(), width = width2, stringFormat = format2},
                new {headerText = importeAdelantoAnt.FormatoMiles(), width = width6, stringFormat = format2},
                new {headerText = importeAdelanto.FormatoMiles(), width = width3, stringFormat = format2},
                new {headerText = saldoComision.FormatoMiles(), width = width4, stringFormat = format2},
                new {headerText = string.Empty, width = width5, stringFormat = format2},
            };
            lstTotalCotratos.RemoveColumnsLstvTotales();
            lstTotalCotratos.CrearColumnasLstvTotales(columns);
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
        #endregion

        private void DgvContratos_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvContratos.IsCurrentCellDirty)
            {
                dgvContratos.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void BtnGenAdelComision_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarGrabar())
                    return;
                if (MessageBox.Show("¿Esta seguro de guardar?", "MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                    == DialogResult.Yes)
                {
                    List<ComisionAdelantoTo> to = ObtenerComisionAdelantoRegistrar();
                    List<ComisionAdelantoTo> to2 = ObtenerComisionAdelantoActualizar();
                    if (BLComision.GrabarAdelantoComision(to, to2))
                    {
                        if (crud == CRUD.Insertar)
                        {
                            CargarGrupoAdelantoComision();
                            LblNroAdelanto_ActualizarTexto(cboNroAdelanto.Text, TEXT_NRO_ADELANTO_GENERADO);
                        }
                        int nroAdelanto = int.TryParse(cboNroAdelanto.SelectedValue?.ToString(), out int val) ? val : 0;
                        ListarContratosSinAprobarParaComsionar(nroAdelanto);
                        DgvContratos_MostrarTotales();
                        DgvTotalAdelantoComision_CargarData();
                        ActualizarImporteVendedor();
                        DgvContratos_MostrarTotales();
                        MostrarTotalGeneralXGrupo();
                        DgvVendedores_MostrarTotales();
                        importeAdelanto = IMPORTE_ADELANTO;
                        crud = CRUD.Actualizar;
                        _ = MessageBox.Show("Registrado Correctamente", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        _ = MessageBox.Show("Error al guardar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                ex.PrintException2();
            }
        }

        private List<ComisionAdelantoTo> ObtenerComisionAdelantoRegistrar()
        {
            List<ComisionAdelantoTo> lista = new List<ComisionAdelantoTo>();
            DataGridViewRow[] arrRow = dgvContratos.Rows.Cast<DataGridViewRow>().Where(x => x.Cells["CH"].Value.ToBoolean() && x.Cells["ID_PROCESO"].Value.ToInt32() == 0).ToArray();
            if (arrRow == null)
                return null;
            int nroAdelanto = crud == CRUD.Insertar ? NroAdelantoCorrelativo : NroAdelantoSeleccionado;
            foreach (DataGridViewRow row in arrRow)
            {
                lista.Add(new ComisionAdelantoTo
                {
                    COD_CLIENTE = row.Cells["COD_CLIENTE"].Value.ToString(),
                    COD_SUCURSAL = row.Cells["COD_SUCURSAL"].Value.ToString(),
                    COD_CLASE = row.Cells["COD_CLASE"].Value.ToString(),
                    NRO_CONTRATO = row.Cells["NRO_PRESUPUESTO"].Value.ToString(),
                    FE_AÑO = row.Cells["FE_AÑO"].Value.ToString(),
                    FE_MES = row.Cells["FE_MES"].Value.ToString(),
                    NRO_CUOTA = row.Cells["NRO_CUOTA"].Value.ToString(),
                    COD_PER = row.Cells["COD_VENDEDOR"].Value.ToString(),
                    COD_NIVEL = row.Cells["COD_NIVEL"].Value.ToString(),
                    TIPO = TIPO_COMISION_ADELANTO_CONTRATOS_SIN_APROBAR,
                    NRO_ADELANTO = nroAdelanto,
                    IMPORTE_COMISION = row.Cells["IMPORTE_COMISION"].Value.ToDecimal(),
                    IMPORTE_ADELANTO = row.Cells["IMPORTE_ADELANTO"].Value.ToDecimal(),
                    USUARIO_CREA = UsuarioSistema.Cod_usu
                });
            }
            return lista;
        }

        private List<ComisionAdelantoTo> ObtenerComisionAdelantoActualizar()
        {
            if (crud == CRUD.Insertar)
                return null;
            List<ComisionAdelantoTo> lista = new List<ComisionAdelantoTo>();
            DataGridViewRow[] arrRow = dgvContratos.Rows.Cast<DataGridViewRow>().Where(x => x.Cells["CH"].Value.ToBoolean() && x.Cells["ID_PROCESO"].Value.ToInt32() > 0
            && string.IsNullOrEmpty(x.Cells[COLUMN_NAME5].Value?.ToString())).ToArray();
            foreach (DataGridViewRow row in arrRow)
            {
                lista.Add(new ComisionAdelantoTo
                {
                    ID_PROCESO = row.Cells["ID_PROCESO"].Value.ToInt32(),
                    TIPO = TIPO_COMISION_ADELANTO_CONTRATOS_SIN_APROBAR,
                    NRO_ADELANTO = NroAdelantoSeleccionado,
                    IMPORTE_COMISION = row.Cells["IMPORTE_COMISION"].Value.ToDecimal(),
                    IMPORTE_ADELANTO = row.Cells["IMPORTE_ADELANTO"].Value.ToDecimal(),
                    USUARIO_MODIFICA = UsuarioSistema.Cod_usu
                });
            }
            return lista;
        }

        private void ActualizarImporteVendedor()
        {
            decimal importeAdelanto = 0;
            DataGridViewRow[] arrRow = dgvContratos.Rows.Cast<DataGridViewRow>().Where(x => x.Cells["ID_PROCESO"].Value.ToInt32() > 0).ToArray();
            foreach (DataGridViewRow row in arrRow)
            {
                importeAdelanto += decimal.TryParse(row.Cells["IMPORTE_ADELANTO"].Value?.ToString(), out decimal com2) ? com2 : 0;
            }
            decimal importeComision = dgvVendedores.CurrentRow.Cells["TOT_COMISION"].Value.ToDecimal();
            decimal importeAdelantoAgregado = this.importeAdelanto - importeAdelanto;
            dgvVendedores.CurrentRow.Cells["TOT_ADELANTO_COMISION"].Value = dgvVendedores.CurrentRow.Cells["TOT_ADELANTO_COMISION"].Value.ToDecimal() - importeAdelantoAgregado;
            dgvVendedores.CurrentRow.Cells["SALDO_COMISION"].Value = importeComision - dgvVendedores.CurrentRow.Cells["TOT_ADELANTO_COMISION"].Value.ToDecimal();
        }

        private bool ValidarGrabar()
        {
            if (crud == CRUD.None)
            {
                _ = MessageBox.Show("Primero haga click en el boton \"Nuevo Adelanto\" para crear un nuevo adelanto de comisión" +
                    " o seleccione un grupo de adelanto para actualizar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            DataGridViewRow[] arrRow = dgvContratos.Rows.Cast<DataGridViewRow>().Where(x => x.Cells["CH"].Value.ToBoolean()).ToArray();
            if (arrRow == null || arrRow.Length == 0)
            {
                _ = MessageBox.Show("Seleccione los contratos para generar el adelanto de comisión", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            arrRow = dgvContratos.Rows.Cast<DataGridViewRow>().Where(x => x.Cells["CH"].Value.ToBoolean() && x.Cells["ID_PROCESO"].Value.ToInt32() == 0).ToArray();
            DataGridViewRow[] arrRow2 = dgvContratos.Rows.Cast<DataGridViewRow>().Where(x => x.Cells["CH"].Value.ToBoolean() && x.Cells["ID_PROCESO"].Value.ToInt32() > 0
            && string.IsNullOrEmpty(x.Cells[COLUMN_NAME5].Value?.ToString())).ToArray();
            if ((arrRow == null || arrRow.Length == 0) && (arrRow2 == null || arrRow2.Length == 0))
            {
                _ = MessageBox.Show("Los contratos seleccionados ya estan registrados y no pueden ser actualizados porque ya estan cerrados", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            arrRow = dgvContratos.Rows.Cast<DataGridViewRow>().Where(x => x.Cells["CH"].Value.ToBoolean() && x.Cells[COLUMN_NAME1].Value.ToDecimal() <= 0).ToArray();
            if (arrRow != null && arrRow.Length > 0)
            {
                _ = MessageBox.Show("Algunos contratos tienen el importe adelanto menor o igual a cero", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            arrRow = dgvContratos.Rows.Cast<DataGridViewRow>().Where(x => x.Cells["CH"].Value.ToBoolean() && x.Cells[COLUMN_NAME3].Value.ToDecimal() < 0).ToArray();
            if (arrRow != null && arrRow.Length > 0)
            {
                _ = MessageBox.Show("Algunos contratos tienen el saldo en negativo, verifique el importe de adelanto ingresado", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void BtnEliminarComision_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarEliminar())
                    return;

                if (MessageBox.Show("¿Esta seguro de eliminar?", "MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                    == DialogResult.Yes)
                {
                    ComisionAdelantoTo to = ObtenerComisionAdelantoEliminar();
                    if (BLComision.EliminarAdelantoComision(to))
                    {
                        DgvVendedores_SelectionChanged(sender, e);
                        DgvContratos_MostrarTotales();
                        ActualizarImporteVendedor();
                        _ = MessageBox.Show("Eliminado Correctamente", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        _ = MessageBox.Show("Error al eliminar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                ex.PrintException2();
            }
        }

        private ComisionAdelantoTo ObtenerComisionAdelantoEliminar()
        {
            return new ComisionAdelantoTo
            {
                ID_PROCESO = dgvContratos.CurrentRow.Cells["ID_PROCESO"].Value.ToInt32()
            };
        }

        private bool ValidarEliminar()
        {
            if (dgvContratos.CurrentRow.Cells["ID_PROCESO"].Value.ToInt32() == 0)
            {
                _ = MessageBox.Show("No se puede eliminar este registro ya que aún no ha sido registrado", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void DgvContratos_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dgvContratos.Columns[e.ColumnIndex].Name == COLUMN_NAME1)
            {
                if ((ESTADO_REGISTRO)dgvContratos["ESTADO", e.RowIndex].Value.ToInt32() == ESTADO_REGISTRO.REGISTRO_APROBADO ||
                    dgvContratos["ID_I_BANCO", e.RowIndex].Value.ToInt32() > 0)
                {
                    _ = MessageBox.Show("Este contrato ya esta cerrado, no se puede modificar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                }
            }
        }

        private void DgvContratos_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgvContratos.Columns[e.ColumnIndex].Name == COLUMN_NAME1)
            {
                if (!decimal.TryParse(e.FormattedValue?.ToString(), out _))
                {
                    _ = MessageBox.Show("Ingrese un valor numérico o decimal", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                    return;
                }

                if (e.FormattedValue.ToDecimal() > (dgvContratos[COLUMN_NAME2, e.RowIndex].Value.ToDecimal() - dgvContratos[COLUMN_NAME6, e.RowIndex].Value.ToDecimal()))
                {
                    _ = MessageBox.Show("El importe de adelanto es superior al saldo", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    _ = dgvContratos.BeginEdit(true);
                    e.Cancel = true;
                }
            }
        }

        private void DgvContratos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvContratos.Columns[e.ColumnIndex].Name == COLUMN_NAME8)
            {
                if (dgvContratos[e.ColumnIndex, e.RowIndex].Value.ToBoolean() && dgvContratos["NRO_ADELANTO", e.RowIndex].Value.ToInt32() != NroAdelantoSeleccionado &&
                    dgvContratos["CANT_ADELANTO", e.RowIndex].Value.ToInt32() >= 2)
                {
                    _ = MessageBox.Show("Este contrato ya tiene dos adelantos de comisión, solo esta permitido dos adelantos por contrato", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dgvContratos[e.ColumnIndex, e.RowIndex].Value = false;
                    dgvContratos.EndEdit();
                }
            }
        }

        private void DgvContratos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvContratos.Columns[e.ColumnIndex].Name == COLUMN_NAME1)
            {
                if (!decimal.TryParse(dgvContratos[COLUMN_NAME1, e.RowIndex].Value?.ToString(), out _))
                {
                    _ = MessageBox.Show("Ingrese un valor numérico o decimal", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    _ = dgvContratos.BeginEdit(true);
                    return;
                }

                if (dgvContratos[e.ColumnIndex, e.RowIndex].Value.ToDecimal() == 0 && dgvContratos["ID_PROCESO", e.RowIndex].Value.ToInt32() > 0)
                    EliminarComisionCellEndEdit(e);

                decimal importeComision = dgvContratos[COLUMN_NAME2, e.RowIndex].Value.ToDecimal();
                decimal importeAdelantoAnt = dgvContratos[COLUMN_NAME6, e.RowIndex].Value.ToDecimal();
                decimal importeAdelanto = dgvContratos[e.ColumnIndex, e.RowIndex].Value.ToDecimal();
                dgvContratos[COLUMN_NAME3, e.RowIndex].Value = importeComision - importeAdelanto - importeAdelantoAnt;
                string codInst = dgvContratos[COLUMN_NAME7, e.RowIndex].Value.ToString();
                DgvTotalAdelantoComision_ActualizarTotalesXInstitucion(codInst);
                DgvTotalAdelantoComision_ActualizarTotalesFinales();
                //> this.importeAdelanto = IMPORTE_ADELANTO;
            }
        }

        private void EliminarComisionCellEndEdit(DataGridViewCellEventArgs e)
        {
            ComisionAdelantoTo to = new ComisionAdelantoTo
            {
                ID_PROCESO = dgvContratos["ID_PROCESO", e.RowIndex].Value.ToInt32()
            };
            if (BLComision.EliminarAdelantoComision(to))
            {
                dgvContratos["CH", e.RowIndex].Value = false;
                ActualizarImporteVendedor();
            }
            else
                _ = MessageBox.Show("Error al eliminar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void DgvContratos_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void BtnGenerarReporte_Click(object sender, EventArgs e)
        {
            FrmRptAdelantoComisionContratosSinAprobar frmRptAdelantoComision = FrmRptAdelantoComisionContratosSinAprobar.Instancia();
            frmRptAdelantoComision.Owner = this;
            frmRptAdelantoComision.StartPosition = FormStartPosition.CenterScreen;
            frmRptAdelantoComision.Show();
        }

        private void DgvTotalAdelantoComision_CrearColumnas()
        {
            var columns = new[]
            {
                new {name = "COD_INST", headerText = "CODIGO_INSTITUCION", width = 0,  visible = false, readOnly = true, boolean = false, dataType = typeof(string)},
                new {name = "DESC_INST", headerText = "Institución", width = 170,  visible = true, readOnly = true, boolean = false, dataType = typeof(string)},
                new {name = "IMPORTE_COMISION", headerText = "Imp. Comisión", width = 70,  visible = true, readOnly = true, boolean = false, dataType = typeof(decimal)},
                new {name = "IMPORTE_ADELANTO_ANT", headerText = "Imp.Adelanto Anterior", width = 70,  visible = true, readOnly = true, boolean = false, dataType = typeof(decimal)},
                new {name = "IMPORTE_ADELANTO", headerText = "Imp. Adelanto", width = 70,  visible = true, readOnly = true, boolean = false, dataType = typeof(decimal)},
                new {name = "SALDO_COMISION", headerText = "Saldo", width = 70,  visible = true, readOnly = true, boolean = false, dataType = typeof(decimal)},
                new {name = "ADELANTO", headerText = "Adelanto x Ctto.", width = 70,  visible = true, readOnly = false, boolean = false, dataType = typeof(decimal)},
            };

            if (dgvTotalAdelantoComision.Columns.Count == 0)
            {
                DataGridViewColumn column;
                foreach (var item in columns)
                {
                    if (!item.boolean)
                    {
                        column = new DataGridViewTextBoxColumn
                        {
                            Name = item.name,
                            HeaderText = item.headerText,
                            Width = item.width,
                            Visible = item.visible,
                            ReadOnly = item.readOnly,
                            ValueType = item.dataType
                        };
                    }
                    else
                    {
                        column = new DataGridViewCheckBoxColumn
                        {
                            Name = item.name,
                            HeaderText = item.headerText,
                            Width = item.width,
                            Visible = item.visible,
                            ReadOnly = item.readOnly,
                            ValueType = item.dataType
                        };
                    }

                    _ = dgvTotalAdelantoComision.Columns.Add(column);
                }

                dgvTotalAdelantoComision.AlingHeaderTextCenter();
                dgvTotalAdelantoComision.ColorCabeceraDataGridView(Color.Teal, Color.White);
                dgvTotalAdelantoComision.AlignmentDecimalColumns();
            }
        }

        /// <summary>
        /// Carga un resumen de totales por institución a partir del origen de datos [dgvTotalAdelantoComision]
        /// </summary>
        private void DgvTotalAdelantoComision_CargarData()
        {
            if (dgvTotalAdelantoComision.Columns.Count == 0)
                return;
            dgvTotalAdelantoComision.Rows.Clear();
            List<dynamic> lista = ObtenerInstituciones();
            DataGridViewRow row;
            decimal[] arrTotales;
            int index;
            foreach (var item in lista)
            {
                arrTotales = ObtenerTotalXInsitucion(item.COD_INST);
                index = dgvTotalAdelantoComision.Rows.Add();
                row = dgvTotalAdelantoComision.Rows[index];
                row.Cells["COD_INST"].Value = item.COD_INST;
                row.Cells["DESC_INST"].Value = item.DESC_INST;
                row.Cells["IMPORTE_COMISION"].Value = arrTotales[0];
                row.Cells["IMPORTE_ADELANTO_ANT"].Value = arrTotales[3];
                row.Cells["IMPORTE_ADELANTO"].Value = arrTotales[1];
                row.Cells["SALDO_COMISION"].Value = arrTotales[2];
                row.Cells["ADELANTO"].Value = 0;
            }

            AgregarTotal();

            //> Agrega una fila y muestra los totales de totadas las instituciones en dicha fila
            void AgregarTotal()
            {
                decimal totalImporteComision = dgvTotalAdelantoComision.Rows.Cast<DataGridViewRow>().Sum(x => x.Cells["IMPORTE_COMISION"].Value.ToDecimal());
                decimal totalImporteAdelantoAnt = dgvTotalAdelantoComision.Rows.Cast<DataGridViewRow>().Sum(x => x.Cells["IMPORTE_ADELANTO_ANT"].Value.ToDecimal());
                decimal totalImporteAdelanto = dgvTotalAdelantoComision.Rows.Cast<DataGridViewRow>().Sum(x => x.Cells["IMPORTE_ADELANTO"].Value.ToDecimal());
                index = dgvTotalAdelantoComision.Rows.Add();
                row = dgvTotalAdelantoComision.Rows[index];
                row.DefaultCellStyle.BackColor = Color.Teal;
                row.DefaultCellStyle.ForeColor = Color.White;
                row.Cells["COD_INST"].Value = "0";
                row.Cells["DESC_INST"].Value = "Total x Vendedor >>";
                row.Cells["IMPORTE_COMISION"].Value = totalImporteComision;
                row.Cells["IMPORTE_ADELANTO_ANT"].Value = totalImporteAdelantoAnt;
                row.Cells["IMPORTE_ADELANTO"].Value = totalImporteAdelanto;
                row.Cells["SALDO_COMISION"].Value = totalImporteComision - totalImporteAdelanto - totalImporteAdelantoAnt;
                row.Cells["ADELANTO"].Value = 0;
            }
        }


        /// <summary>
        /// Obiene una lista única de solo instituciones a partir del origen de datos[dtContratosParaAdelComision]
        /// </summary>
        /// <returns></returns>
        private List<dynamic> ObtenerInstituciones()
        {
            dynamic selector(DataRow x) => new { COD_INST = x.Field<string>("COD_INST"), DESC_INST = x.Field<string>("DESC_INST") };
            List<dynamic> lista = dtContratosParaAdelComision.ToDistinct(selector);
            return lista;
        }

        /// <summary>
        /// Obtiene totales(IMPORTE_COMISION, IMPORTE_ADELANTO, SALDO) por institución a partir del origen de datos[dtContratosParaAdelComision]
        /// </summary>
        /// <param name="codInstitucion">Código de la institución</param>
        /// <returns></returns>
        private decimal[] ObtenerTotalXInsitucion(string codInstitucion)
        {
            decimal importeComision = 0, importeAdelanto = 0, importeAdelantoAnt = 0, saldo;
            DataRow[] arrRow = dtContratosParaAdelComision.AsEnumerable().Where(x => x.Field<string>("COD_INST") == codInstitucion).ToArray();
            foreach (DataRow row in arrRow)
            {
                importeComision += decimal.TryParse(row["IMPORTE_COMISION"]?.ToString(), out decimal val) ? val : 0;
                importeAdelanto += decimal.TryParse(row["IMPORTE_ADELANTO"]?.ToString(), out decimal val2) ? val2 : 0;
                importeAdelantoAnt += decimal.TryParse(row["IMPORTE_ADELANTO_ANT"]?.ToString(), out decimal val3) ? val3 : 0;
            }
            saldo = importeComision - importeAdelanto - importeAdelantoAnt;
            decimal[] arrDecimal = { importeComision, importeAdelanto, saldo, importeAdelantoAnt };
            return arrDecimal;
        }

        private void DgvTotalAdelantoComision_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void DgvTotalAdelantoComision_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgvTotalAdelantoComision.Columns[e.ColumnIndex].Name == COLUMN_NAME4)
            {
                if (!decimal.TryParse(e.FormattedValue?.ToString(), out _))
                {
                    _ = MessageBox.Show("Ingrese un valor numérico o decimal", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                }
            }
        }

        private void DgvTotalAdelantoComision_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvTotalAdelantoComision.Columns[e.ColumnIndex].Name == COLUMN_NAME4)
            {
                AplicarImporteAdelantoAContratosXInstitucion(e);
                string codInst = dgvTotalAdelantoComision["COD_INST", e.RowIndex].Value.ToString();
                DgvTotalAdelantoComision_ActualizarTotalesXInstitucion(codInst);
                DgvTotalAdelantoComision_ActualizarTotalesFinales();
                DgvContratos_MostrarTotales();
            }
        }

        /// <summary>
        /// Aplica el importe adelanto ingresado en [dgvTotalAdelantoComision] a todos los contratos seleccionados de la institución seleccionada
        /// </summary>
        /// <param name="e"></param>
        private void AplicarImporteAdelantoAContratosXInstitucion(DataGridViewCellEventArgs e)
        {
            string codInst = dgvTotalAdelantoComision["COD_INST", e.RowIndex].Value.ToString();
            DataGridViewRow[] arrRow = dgvContratos.Rows.Cast<DataGridViewRow>().Where(x => x.Cells["CH"].Value.ToBoolean() && x.Cells["COD_INST"].Value.ToString() == codInst && x.Cells["ESTADO"].Value.ToInt32() != (int)ESTADO_REGISTRO.REGISTRO_APROBADO).ToArray();
            decimal importeAdelanto = dgvTotalAdelantoComision[e.ColumnIndex, e.RowIndex].Value.ToDecimal();
            foreach (DataGridViewRow row in arrRow)
            {
                row.Cells[COLUMN_NAME1].Value = importeAdelanto;
                row.Cells[COLUMN_NAME3].Value = row.Cells[COLUMN_NAME2].Value.ToDecimal() - importeAdelanto - row.Cells[COLUMN_NAME6].Value.ToDecimal();
            }
        }

        /// <summary>
        /// Actualiza los totales en [dgvTotalAdelantoComision] por institución luego de haber aplicado los importes de adelanto
        /// </summary>
        /// <param name="e"></param>
        private void DgvTotalAdelantoComision_ActualizarTotalesXInstitucion(string codInst)
        {
            if (codInst != "0")
            {
                decimal[] arrTotal = DgvTotalAdelantoComision_ObtenerTotalXInsitucion(codInst);
                int rowIndex = dgvTotalAdelantoComision.Rows.Cast<DataGridViewRow>().Single(x => x.Cells["COD_INST"].Value.ToString() == codInst).Index;
                dgvTotalAdelantoComision[COLUMN_NAME1, rowIndex].Value = arrTotal[1];
                dgvTotalAdelantoComision[COLUMN_NAME3, rowIndex].Value = arrTotal[2];
            }
        }


        /// <summary>
        /// Obtiene los totales a partir del [dgvContratos]
        /// </summary>
        /// <param name="codInstitucion"></param>
        /// <returns></returns>
        private decimal[] DgvTotalAdelantoComision_ObtenerTotalXInsitucion(string codInstitucion)
        {
            decimal importeComision = 0, importeAdelanto = 0, importeAdelantoAnt = 0, saldo;
            DataGridViewRow[] arrRow = dgvContratos.Rows.Cast<DataGridViewRow>().Where(x => x.Cells["CH"].Value.ToBoolean() && x.Cells["COD_INST"].Value.ToString() == codInstitucion).ToArray();
            foreach (DataGridViewRow row in arrRow)
            {
                importeComision += decimal.TryParse(row.Cells[COLUMN_NAME2].Value?.ToString(), out decimal val) ? val : 0;
                importeAdelanto += decimal.TryParse(row.Cells[COLUMN_NAME1].Value?.ToString(), out decimal val2) ? val2 : 0;
                importeAdelantoAnt += decimal.TryParse(row.Cells[COLUMN_NAME6].Value?.ToString(), out decimal val3) ? val3 : 0;
            }
            saldo = importeComision - importeAdelanto - importeAdelantoAnt;
            decimal[] arrDecimal = { importeComision, importeAdelanto, saldo, importeAdelantoAnt };
            return arrDecimal;
        }

        /// <summary>
        /// Actualizamos los totales finales de [dgvTotalAdelantoComision]
        /// </summary>
        private void DgvTotalAdelantoComision_ActualizarTotalesFinales()
        {
            decimal totalImporteComision = dgvTotalAdelantoComision.Rows.Cast<DataGridViewRow>().Where(x => x.Cells["COD_INST"].Value.ToString() != "0").Sum(x => x.Cells["IMPORTE_COMISION"].Value.ToDecimal());
            decimal totalImporteAdelantoAnt = dgvTotalAdelantoComision.Rows.Cast<DataGridViewRow>().Where(x => x.Cells["COD_INST"].Value.ToString() != "0").Sum(x => x.Cells["IMPORTE_ADELANTO_ANT"].Value.ToDecimal());
            decimal totalImporteAdelanto = dgvTotalAdelantoComision.Rows.Cast<DataGridViewRow>().Where(x => x.Cells["COD_INST"].Value.ToString() != "0").Sum(x => x.Cells["IMPORTE_ADELANTO"].Value.ToDecimal());
            decimal totalAdelanto = dgvTotalAdelantoComision.Rows.Cast<DataGridViewRow>().Where(x => x.Cells["COD_INST"].Value.ToString() != "0").Sum(x => x.Cells["ADELANTO"].Value.ToDecimal());
            DataGridViewRow row = dgvTotalAdelantoComision.Rows[dgvTotalAdelantoComision.Rows.Count - 1];
            row.Cells["IMPORTE_COMISION"].Value = totalImporteComision;
            row.Cells["IMPORTE_ADELANTO"].Value = totalImporteAdelanto;
            row.Cells["SALDO_COMISION"].Value = totalImporteComision - totalImporteAdelanto - totalImporteAdelantoAnt;
            row.Cells["ADELANTO"].Value = totalAdelanto;
        }

        private void BtnCerrarAdelantoComision_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarCerrar())
                    return;
                if (MessageBox.Show("¿Esta seguro de cerrar los adelantos de comisión generados? \n" +
                    "Considere que una vez enviado, no podrá modificar los adelantos de comisión enviados", "ALERTA", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                    == DialogResult.Yes)
                {
                    RComisionAdelantoTo to = ObtenerDatosCerrarRAdelantoComision();
                    List<RComisionAdelantoTo> lstTo = ObtenerDatosCerrarRAdelantoComision2();
                    if (BLComision.GrabarRAdelantoComision(to, lstTo))
                    {
                        int nroAdelanto = int.TryParse(cboNroAdelanto.SelectedValue?.ToString(), out int val) ? val : 0;
                        ListarContratosSinAprobarParaComsionar(nroAdelanto);
                        var a = this.importeAdelanto;
                        DgvContratos_MostrarTotales();
                        DgvTotalAdelantoComision_CargarData();
                        ActualizarImporteVendedor();
                        DgvContratos_MostrarTotales();
                        MostrarTotalGeneralXGrupo();
                        DgvVendedores_MostrarTotales();
                        importeAdelanto = IMPORTE_ADELANTO;
                        crud = CRUD.Actualizar;
                        _ = MessageBox.Show("Registrado Correctamente", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        _ = MessageBox.Show("Error al guardar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                ex.PrintException2();
            }
        }

        /// <summary>
        /// Obtiene comisiones adelanto que se van a cerrar por primera vez
        /// </summary>
        /// <returns></returns>
        private RComisionAdelantoTo ObtenerDatosCerrarRAdelantoComision()
        {
            List<ComisionAdelantoTo> lstComisionAdelantoTo = ObtenerDatosCerrarAdelantoComision();
            if (lstComisionAdelantoTo == null || lstComisionAdelantoTo.Count == 0)
                return null;
            return new RComisionAdelantoTo
            {
                COD_PER = dgvVendedores.CurrentRow.Cells["COD_PER"].Value.ToString(),
                COD_NIVEL = dgvVendedores.CurrentRow.Cells["COD_NIVEL"].Value.ToString(),
                IMPORTE_COMISION = lstComisionAdelantoTo.Sum(x => x.IMPORTE_COMISION),
                IMPORTE_ADELANTO = lstComisionAdelantoTo.Sum(x => x.IMPORTE_ADELANTO),
                ComisionAdelantoTo = lstComisionAdelantoTo,
                ESTADO = (int)ESTADO_REGISTRO.REGISTRO_APROBADO,
                USUARIO_CREA = UsuarioSistema.Cod_usu
            };
        }

        /// <summary>
        /// Obtiene Comisiones adelanto que se van a cerrar por primera vez
        /// </summary>
        /// <returns></returns>
        private List<ComisionAdelantoTo> ObtenerDatosCerrarAdelantoComision()
        {
            List<ComisionAdelantoTo> lista = new List<ComisionAdelantoTo>();
            DataGridViewRow[] arrRow = dgvContratos.Rows.Cast<DataGridViewRow>().Where(x => x.Cells["CH"].Value.ToBoolean() && x.Cells["ID_PROCESO"].Value.ToInt32() > 0 && string.IsNullOrEmpty(x.Cells[COLUMN_NAME5].Value?.ToString())).ToArray();
            foreach (DataGridViewRow row in arrRow)
            {
                lista.Add(new ComisionAdelantoTo
                {
                    ID_PROCESO = row.Cells["ID_PROCESO"].Value.ToInt32(),
                    IMPORTE_COMISION = row.Cells["IMPORTE_COMISION"].Value.ToDecimal(),
                    IMPORTE_ADELANTO = row.Cells["IMPORTE_ADELANTO"].Value.ToDecimal(),
                    ESTADO = (int)ESTADO_REGISTRO.REGISTRO_APROBADO,
                    USUARIO_CREA = UsuarioSistema.Cod_usu
                });
            }
            return lista;
        }

        /// <summary>
        /// Obtiene Comisiones adelanto que se van a volver a cerrar, esto sucede cuando se abre una comisión de adelanto ya cerrado
        /// </summary>
        /// <returns></returns>
        private List<RComisionAdelantoTo> ObtenerDatosCerrarRAdelantoComision2()
        {
            List<RComisionAdelantoTo> lista = new List<RComisionAdelantoTo>();
            List<ComisionAdelantoTo> lstComisionAdelantoTo = ObtenerDatosCerrarAdelantoComision2();
            IEnumerable<string> arrNroPlanillaDoc = lstComisionAdelantoTo.Select(x => x.NRO_PLANILLA_DOC).Distinct();
            List<ComisionAdelantoTo> listaAdelanto;
            foreach (string nroPlanillaDoc in arrNroPlanillaDoc)
            {
                listaAdelanto = lstComisionAdelantoTo.Where(x => x.NRO_PLANILLA_DOC == nroPlanillaDoc).ToList();
                lista.Add(new RComisionAdelantoTo
                {
                    COD_PER = dgvVendedores.CurrentRow.Cells["COD_PER"].Value.ToString(),
                    COD_NIVEL = dgvVendedores.CurrentRow.Cells["COD_NIVEL"].Value.ToString(),
                    NRO_PLANILLA_DOC = nroPlanillaDoc,
                    IMPORTE_COMISION = listaAdelanto.Sum(x => x.IMPORTE_COMISION),
                    IMPORTE_ADELANTO = listaAdelanto.Sum(x => x.IMPORTE_ADELANTO),
                    ComisionAdelantoTo = listaAdelanto,
                    ESTADO = (int)ESTADO_REGISTRO.REGISTRO_APROBADO,
                    USUARIO_MODIFICA = UsuarioSistema.Cod_usu
                });
            }
            return lista;
        }

        /// <summary>
        /// Obtiene Comisiones adelanto que se van a volver a cerrar, esto sucede cuando se abre una comisión de adelanto ya cerrado
        /// </summary>
        /// <returns></returns>
        private List<ComisionAdelantoTo> ObtenerDatosCerrarAdelantoComision2()
        {
            List<ComisionAdelantoTo> lista = new List<ComisionAdelantoTo>();
            DataGridViewRow[] arrRow = dgvContratos.Rows.Cast<DataGridViewRow>().Where(x => x.Cells["CH"].Value.ToBoolean() && x.Cells["ID_PROCESO"].Value.ToInt32() > 0 && !string.IsNullOrEmpty(x.Cells[COLUMN_NAME5].Value?.ToString())
            && x.Cells["ESTADO"].Value.ToInt32() == (int)ESTADO_REGISTRO.REGISTRO_PROCESADO).ToArray();
            foreach (DataGridViewRow row in arrRow)
            {
                lista.Add(new ComisionAdelantoTo
                {
                    ID_PROCESO = row.Cells["ID_PROCESO"].Value.ToInt32(),
                    NRO_PLANILLA_DOC = row.Cells[COLUMN_NAME5].Value.ToString(),
                    NRO_ADELANTO = NroAdelantoSeleccionado,
                    IMPORTE_COMISION = row.Cells["IMPORTE_COMISION"].Value.ToDecimal(),
                    IMPORTE_ADELANTO = row.Cells["IMPORTE_ADELANTO"].Value.ToDecimal(),
                    ESTADO = (int)ESTADO_REGISTRO.REGISTRO_APROBADO,
                    USUARIO_MODIFICA = UsuarioSistema.Cod_usu
                });
            }
            return lista;
        }

        private bool ValidarCerrar()
        {
            if (dgvVendedores.CurrentRow == null)
                return false;
            if (dgvContratos.Rows.Count == 0)
                return false;
            DataGridViewRow[] arrRow = dgvContratos.Rows.Cast<DataGridViewRow>().Where(x => x.Cells["CH"].Value.ToBoolean() && x.Cells["ID_PROCESO"].Value.ToInt32() > 0 && string.IsNullOrEmpty(x.Cells[COLUMN_NAME5].Value?.ToString())).ToArray();
            DataGridViewRow[] arrRow2 = dgvContratos.Rows.Cast<DataGridViewRow>().Where(x => x.Cells["CH"].Value.ToBoolean() && x.Cells["ID_PROCESO"].Value.ToInt32() > 0 && !string.IsNullOrEmpty(x.Cells[COLUMN_NAME5].Value?.ToString())
            && x.Cells["ESTADO"].Value.ToInt32() == (int)ESTADO_REGISTRO.REGISTRO_PROCESADO).ToArray();
            if ((arrRow == null || arrRow.Length == 0) && (arrRow2 == null || arrRow2.Length == 0))
            {
                _ = MessageBox.Show("No existe adelanto de comisiones generadas para cerrar, primero genere un adelanto de comisión", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            arrRow = dgvContratos.Rows.Cast<DataGridViewRow>().Where(x => x.Cells["CH"].Value.ToBoolean() && x.Cells["ID_PROCESO"].Value.ToInt32() > 0 && string.IsNullOrEmpty(x.Cells[COLUMN_NAME5].Value?.ToString()) && x.Cells[COLUMN_NAME1].Value.ToDecimal() <= 0).ToArray();
            if (arrRow != null && arrRow.Length > 0)
            {
                _ = MessageBox.Show("Algunos contratos tienen el importe adelanto en cero. \n" +
                    "Si desea mantener en cero desmarque para no enviar a tesorería", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            arrRow = dgvContratos.Rows.Cast<DataGridViewRow>().Where(x => x.Cells["CH"].Value.ToBoolean() && x.Cells["ID_PROCESO"].Value.ToInt32() > 0 && string.IsNullOrEmpty(x.Cells[COLUMN_NAME5].Value?.ToString()) && x.Cells[COLUMN_NAME3].Value.ToDecimal() < 0).ToArray();
            if (arrRow != null && arrRow.Length > 0)
            {
                _ = MessageBox.Show("Algunos contratos tienen el saldo en negativo, verifique el importe de adelanto ingresado", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void BtnNuevoAdelanto_Click(object sender, EventArgs e)
        {
            crud = CRUD.Insertar;
            nroAdelantoCorrelativo = NroAdelantoCorrelativo;
            LblNroAdelanto_ActualizarTexto(string.Concat("GRUPO ", nroAdelantoCorrelativo), TEXT_NRO_ADELANTO_A_GENERAR);
            ListarContratosSinAprobarParaComsionar(nroAdelantoCorrelativo);
            DgvContratos_MostrarTotales();
            DgvTotalAdelantoComision_CargarData();
        }

        private int NroAdelantoCorrelativo
        {
            get
            {
                ComisionAdelantoTo to = new ComisionAdelantoTo
                {
                    COD_PER = dgvVendedores.CurrentRow.Cells["COD_PER"].Value.ToString(),
                    COD_NIVEL = dgvVendedores.CurrentRow.Cells["COD_NIVEL"].Value.ToString(),
                };
                int nroAdelanto = BLComision.ObtenerUltimoNroAdelanto(to);
                return nroAdelanto + 1;
            }
        }

        private void LblNroAdelanto_ActualizarTexto(object nroAdelanto, string texto) => lblNroAdelanto.Text = $"{texto}: {nroAdelanto}";

        private void CargarGrupoAdelantoComision()
        {
            ComisionAdelantoTo to = new ComisionAdelantoTo
            {
                COD_NIVEL = COD_NIVEL_VENDEDOR,
            };
            DataTable dt = BLComision.ListaNroAdelantoComision(to);
            cboNroAdelanto.ValueMember = "NRO_ADELANTO";
            cboNroAdelanto.DisplayMember = "DESC_NRO_ADELANTO";
            cboNroAdelanto.DataSource = dt;
            if (dt != null && dt.Rows.Count > 0)
            {
                cboNroAdelanto.SelectedValue = dt.Rows[dt.Rows.Count - 1]["NRO_ADELANTO"].ToInt32();
                crud = CRUD.Actualizar;
                LblNroAdelanto_ActualizarTexto(string.Concat("GRUPO ", NroAdelantoSeleccionado), TEXT_NRO_ADELANTO_GENERADO);
            }
        }

        private int NroAdelantoSeleccionado { get => int.TryParse(cboNroAdelanto.SelectedValue?.ToString(), out int val) ? val : 0; }

        private void CboNroAdelanto_SelectionChangeCommitted(object sender, EventArgs e)
        {
            crud = CRUD.Actualizar;
            int nroAdelanto = int.TryParse(cboNroAdelanto.SelectedValue?.ToString(), out int val) ? val : 0;
            LblNroAdelanto_ActualizarTexto(cboNroAdelanto.Text, TEXT_NRO_ADELANTO_GENERADO);
            ListarContratosSinAprobarParaComsionar(nroAdelanto);
            DgvContratos_MostrarTotales();
            DgvTotalAdelantoComision_CargarData();
            MostrarTotalGeneralXGrupo();
            ActualizarVendedoresConNroAdelanto();
            importeAdelanto = IMPORTE_ADELANTO;
        }

        #region ListView Total General x Grupo --> Generic
        private void MostrarTotalGeneralXGrupo()
        {
            DataTable dt = BLComision.ObtenerTotalesAdelantoComisionXNroAdelanto(NroAdelantoSeleccionado);
            decimal importeComision = dt.Rows[0]["TOT_COMISION"].ToDecimal();
            decimal importeAdelantoAnt = dt.Rows[0]["TOT_ADELANTO_ANT"].ToDecimal();
            decimal importeAdelanto = dt.Rows[0]["TOT_ADELANTO_COMISION"].ToDecimal();
            decimal saldoComision = dt.Rows[0]["SALDO_COMISION"].ToDecimal();

            int width1 = dgvTotalAdelantoComision.Columns["DESC_INST"].Width;
            int width2 = dgvTotalAdelantoComision.Columns[COLUMN_NAME2].Width;
            int width3 = dgvTotalAdelantoComision.Columns[COLUMN_NAME6].Width;
            int width4 = dgvTotalAdelantoComision.Columns[COLUMN_NAME1].Width;
            int width5 = dgvTotalAdelantoComision.Columns[COLUMN_NAME3].Width;
            int width6 = dgvTotalAdelantoComision.Columns[COLUMN_NAME4].Width;
            //> StringFormat siver para alinear el texto
            //> format --> izquierda centrado
            StringFormat format = new StringFormat
            {
                Alignment = StringAlignment.Near,
                LineAlignment = StringAlignment.Center
            };
            //> format2 --> derecha centrado
            StringFormat format2 = new StringFormat
            {
                Alignment = StringAlignment.Far,
                LineAlignment = StringAlignment.Center
            };
            var columns = new[]
            {
                new {headerText = $"Total General Grupo {NroAdelantoSeleccionado}", width = width1, stringFormat = format},
                new {headerText = importeComision.FormatoMiles(), width = width2, stringFormat = format2},
                new {headerText = importeAdelantoAnt.FormatoMiles(), width = width3, stringFormat = format2},
                new {headerText = importeAdelanto.FormatoMiles(), width = width4, stringFormat = format2},
                new {headerText = saldoComision.FormatoMiles(), width = width5, stringFormat = format2},
                new {headerText = string.Empty, width = width6, stringFormat = format2},
            };
            lstTotalGeneralXGrupo.RemoveColumnsLstvTotales();
            lstTotalGeneralXGrupo.CrearColumnasLstvTotales(columns);
        }
        #endregion

        /// <summary>
        /// Actualiza la columna [CH](esto indica si un vededor tiene registros en un determinado nro de adelanto) del dgvVendedores
        /// </summary>
        private void ActualizarVendedoresConNroAdelanto()
        {
            DataTable dt = BLComision.ObtenerVendedoresConNroAdelanto(NroAdelantoSeleccionado);
            dgvVendedores.Rows.Cast<DataGridViewRow>().Where(x => x.Cells["CH"].Value.ToBoolean()).ToList().ForEach(x => x.Cells["CH"].Value = false);
            DataGridViewRow rw;
            foreach (DataRow row in dt.Rows)
            {
                rw = dgvVendedores.Rows.Cast<DataGridViewRow>().SingleOrDefault(x => x.Cells["COD_PER"].Value.ToString() == row["COD_PER"].ToString());
                if (rw != null)
                    rw.Cells["CH"].Value = true;
            }
        }

        private void BtnAbrirAdelantoComision_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarAbrirComisionAdelanto())
                    return;
                List<ComisionAdelantoTo> lista = ObtenerComisionAdelantoToAbrir();
                if (BLComision.AbrirAdelantoComision(lista))
                    DgvVendedores_SelectionChanged(sender, e);
                else
                    _ = MessageBox.Show("Error al guardar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ex.PrintException();
            }
        }

        private bool ValidarAbrirComisionAdelanto()
        {
            if (dgvContratos.Rows.Count == 0)
                return false;
            DataGridViewRow[] arrRow = dgvContratos.Rows.Cast<DataGridViewRow>().Where(x => x.Cells[COLUMN_NAME8].Value.ToBoolean() == x.Cells["ID_PROCESO"].Value.ToInt32() > 0 &&
            x.Cells["ESTADO"].Value.ToInt32() == (int)ESTADO_REGISTRO.REGISTRO_APROBADO).ToArray();
            if (arrRow == null || arrRow.Length == 0)
            {
                _ = MessageBox.Show("No hay contratos para abrir", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private List<ComisionAdelantoTo> ObtenerComisionAdelantoToAbrir()
        {
            DataGridViewRow[] arrRow = dgvContratos.Rows.Cast<DataGridViewRow>().Where(x => x.Cells[COLUMN_NAME8].Value.ToBoolean() == x.Cells["ID_PROCESO"].Value.ToInt32() > 0 &&
            x.Cells["ESTADO"].Value.ToInt32() == (int)ESTADO_REGISTRO.REGISTRO_APROBADO).ToArray();
            List<ComisionAdelantoTo> lista = new List<ComisionAdelantoTo>();
            foreach (DataGridViewRow row in arrRow)
            {
                lista.Add(new ComisionAdelantoTo
                {
                    ID_PROCESO = row.Cells["ID_PROCESO"].Value.ToInt32()
                });
            }
            return lista;
        }
    }
}
