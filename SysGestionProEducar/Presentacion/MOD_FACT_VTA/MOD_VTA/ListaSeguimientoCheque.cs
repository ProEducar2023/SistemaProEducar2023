using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using BLL;
using Entidades;
using static Presentacion.HELPERS.FormatDataGridViewColumns;

namespace Presentacion.MOD_FACT_VTA.MOD_VTA
{
    public partial class ListaSeguimientoCheque : Form
    {
        public static string FE_AÑO, FE_MES;
        public ListaSeguimientoCheque(string feAño, string feMes)
        {
            InitializeComponent();
            FE_AÑO = feAño;
            FE_MES = feMes;
        }

        private readonly ChequeBLL BLCheque = new ChequeBLL();
        //> private static readonly CultureInfo culture = CultureInfo.CreateSpecificCulture("en-CA");

        private const string V = "N2", F = "dd/MM/yyyy";
        private static readonly Color[] colorBack = new Color[]
        {
            Color.PaleTurquoise, Color.MediumSpringGreen,
            Color.Tan, Color.PeachPuff, Color.LightSalmon,
            Color.Orange, Color.DarkSeaGreen
        };

        private void ListaSeguimientoCheque_Load(object sender, EventArgs e)
        {
            StartControls();
            AddColumns();
            CargarMes();
            BackColorLeyeda();
            StyleHeaderTextDataGridView();
        }

        private void StartControls()
        {
            numAño.Maximum = decimal.MaxValue;
            numAño2.Maximum = decimal.MaxValue;
            cboMes.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMes2.DropDownStyle = ComboBoxStyle.DropDownList;

            StyleGridView(dgvPlanillasCheques);
            StyleGridView(dgvAplicacionCab);
        }

        private void StyleGridView(DataGridView dataGridView)
        {
            if (dataGridView != null)
            {
                dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView.DefaultCellStyle.SelectionBackColor = Color.White;
                dataGridView.DefaultCellStyle.SelectionForeColor = Color.Blue;
                dataGridView.EnableHeadersVisualStyles = false;
            }
        }

        private void CargarMes()
        {
            var mes_año = new[]
            {
                new { value = "01", name = "ENERO"},
                new { value = "02", name = "FEBRERO"},
                new { value = "03", name = "MARZO"},
                new { value = "04", name = "ABRIL"},
                new { value = "05", name = "MAYO"},
                new { value = "06", name = "JUNIO"},
                new { value = "07", name = "JULIO"},
                new { value = "08", name = "AGOSTO"},
                new { value = "09", name = "SEPTIEMBRE"},
                new { value = "10", name = "OCTUBRE"},
                new { value = "11", name = "NOVIEMBRE"},
                new { value = "12", name = "DICIEMBRE"}
            };

            cboMes.DataSource = mes_año;
            cboMes.DisplayMember = "name";
            cboMes.ValueMember = "value";
            cboMes.SelectedValue = FE_MES;
            numAño.Value = Convert.ToDecimal(FE_AÑO);

            cboMes2.DataSource = mes_año;
            cboMes2.DisplayMember = "name";
            cboMes2.ValueMember = "value";
            cboMes2.SelectedValue = FE_MES;
            numAño2.Value = Convert.ToInt32(FE_AÑO);
        }

        private void ListarSegumientoCheques(string año, string mes)
        {
            try
            {
                DataTable dt = BLCheque.ListarSeguimientoCheque(año, mes);

                if (dgvPlanillasCheques.Columns.Count == 0)
                {
                    AddColumns();
                    CentrarColumnas(dgvPlanillasCheques);
                }

                int countNewRow = 1;
                AddRows();

                if (dgvPlanillasCheques.Columns.Count > 0)
                {
                    dgvPlanillasCheques.Columns["NRO_PLANILLA"].Frozen = true;
                    dgvPlanillasCheques.Columns["TIPO_OPERACION"].HeaderText = "T.OPERACIÓN";
                    dgvPlanillasCheques.Columns["TIPO_OPERACION"].Width = 100;
                    dgvPlanillasCheques.Columns["ID_SEGUIMIENTO"].Visible = false;
                    dgvPlanillasCheques.Columns["Desc_dep"].HeaderText = "DEPARTAMENTO";
                    dgvPlanillasCheques.Columns["Desc_dep"].Width = 110;
                    dgvPlanillasCheques.Columns["COD_PTO_COB"].Visible = false;
                    dgvPlanillasCheques.Columns["DESC_PTO_COB"].HeaderText = "PUNTO COBRANZA";
                    dgvPlanillasCheques.Columns["DESC_PTO_COB"].Width = 140;
                    dgvPlanillasCheques.Columns["NRO_PLANILLA"].HeaderText = "N° PLANILLA";
                    dgvPlanillasCheques.Columns["NRO_PLANILLA"].Width = 80;
                    dgvPlanillasCheques.Columns["NRO_DOC_ENV"].HeaderText = "N° DOC ENVIO";
                    dgvPlanillasCheques.Columns["NRO_DOC_ENV"].Width = 90;
                    dgvPlanillasCheques.Columns["EMPRESA_ENV"].HeaderText = "EMPRESA - COURIER ENVI";
                    dgvPlanillasCheques.Columns["EMPRESA_ENV"].Width = 100;
                    dgvPlanillasCheques.Columns["REPRE_ENV"].HeaderText = "ENVIADO POR";
                    dgvPlanillasCheques.Columns["REPRE_ENV"].Width = 100;
                    dgvPlanillasCheques.Columns["T_TRANSCURRIDO_ENV"].HeaderText = "DÍAS TRANS";
                    dgvPlanillasCheques.Columns["T_TRANSCURRIDO_ENV"].Width = 60;
                    dgvPlanillasCheques.Columns["T_TRANSCURRIDO_ENV"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvPlanillasCheques.Columns["T_TRANSCURRIDO_REC"].HeaderText = "DÍAS TRANS";
                    dgvPlanillasCheques.Columns["T_TRANSCURRIDO_REC"].Width = 60;
                    dgvPlanillasCheques.Columns["T_TRANSCURRIDO_REC"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvPlanillasCheques.Columns["BANCO_DEP"].HeaderText = "BANCO DEPÓSITO";
                    dgvPlanillasCheques.Columns["BANCO_DEP"].Width = 80;
                    dgvPlanillasCheques.Columns["NRO_CUENTA_DEP"].HeaderText = "N° CUENTA DEPÓSITO";
                    dgvPlanillasCheques.Columns["NRO_CUENTA_DEP"].Width = 90;
                    dgvPlanillasCheques.Columns["NRO_CHEQUE_DEP"].HeaderText = "N° CHEQUE DEPÓSITO";
                    dgvPlanillasCheques.Columns["NRO_CHEQUE_DEP"].Width = 90;
                    dgvPlanillasCheques.Columns["BANCO_ORIGEN"].HeaderText = "BANCO ORIGEN DEPÓSITO";
                    dgvPlanillasCheques.Columns["BANCO_ORIGEN"].Width = 100;
                    dgvPlanillasCheques.Columns["T_TRANSCURRIDO_DEP"].HeaderText = "DÍAS TRANS";
                    dgvPlanillasCheques.Columns["T_TRANSCURRIDO_DEP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvPlanillasCheques.Columns["T_TRANSCURRIDO_DEP"].Width = 60;
                    dgvPlanillasCheques.Columns["NRO_OPERACION_TRA"].HeaderText = "N° OPERACIÓN TRANSFERENCIA";
                    dgvPlanillasCheques.Columns["NRO_OPERACION_TRA"].Width = 100;
                    dgvPlanillasCheques.Columns["T_TRANSCURRIDO_TRA"].HeaderText = "DÍAS TRANS";
                    dgvPlanillasCheques.Columns["T_TRANSCURRIDO_TRA"].Width = 60;
                    dgvPlanillasCheques.Columns["T_TRANSCURRIDO_TRA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvPlanillasCheques.Columns["BANCO_DEST_TRA"].HeaderText = "BANCO DESTINO TRANFERENCIA";
                    dgvPlanillasCheques.Columns["BANCO_DEST_TRA"].Width = 100;
                    dgvPlanillasCheques.Columns["NRO_CTA_TRA"].HeaderText = "N° CTA TRANSFERENCIA";
                    dgvPlanillasCheques.Columns["NRO_CTA_TRA"].Width = 100;
                    dgvPlanillasCheques.Columns["T_TRANSCURRIDO_VER"].HeaderText = "DÍAS TRANS";
                    dgvPlanillasCheques.Columns["T_TRANSCURRIDO_VER"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvPlanillasCheques.Columns["T_TRANSCURRIDO_VER"].Width = 60;
                    dgvPlanillasCheques.Columns["BANCO_VERIFICADO"].HeaderText = "BANCO VERIFICADO";
                    dgvPlanillasCheques.Columns["BANCO_VERIFICADO"].Width = 80;
                    dgvPlanillasCheques.Columns["NRO_CUENTA_VERIF"].HeaderText = "N° CTA VERIFICADO";
                    dgvPlanillasCheques.Columns["NRO_CUENTA_VERIF"].Width = 90;

                    FormatoColumnaFecha(dgvPlanillasCheques, "FECHA_ENVIO_PLLA", "F.ENVÍO PLLA", 70);
                    FormatoColumnaFecha(dgvPlanillasCheques, "FECHA_ENVIO", "FECHA ENVÍO", 70);
                    FormatoColumnaFecha(dgvPlanillasCheques, "FECHA_RECEPCION", "FECHA RECEPCIÓN", 70);
                    FormatoColumnaFecha(dgvPlanillasCheques, "FECHA_DEP", "FECHA DEPÓSITO", 70);
                    FormatoColumnaFecha(dgvPlanillasCheques, "FECHA_VERIFICADO", "FECHA VERIFICADP", 80);
                    FormatoColumnaFecha(dgvPlanillasCheques, "FECHA_TRANSFERENCIA", "FECHA TRANSFER", 70);

                    FormatoColumnaImporte(dgvPlanillasCheques, "IMPORTE_NETO", "IMPORTE NETO", 70);
                    FormatoColumnaImporte(dgvPlanillasCheques, "IMPORTE_EJECUTADO_NETO", "IMPORTE EJECUT", 70);
                    FormatoColumnaImporte(dgvPlanillasCheques, "IMPORTE_CHEQUE", "IMPORTE CHEQUE", 70);
                    FormatoColumnaImporte(dgvPlanillasCheques, "IMPORTE_CHEQUE_DEP", "IMPORTE DEPOSITO", 70);
                    FormatoColumnaImporte(dgvPlanillasCheques, "IMPORTE_TRA", "IMPORTE TRANSFER", 70);
                    FormatoColumnaImporte(dgvPlanillasCheques, "IMPORTE_VERI_COB", "IMPORTE VERIFICADO", 80);
                    FormatoColumnaImporte(dgvPlanillasCheques, "IMPORTE_RETENIDO", "IMPORTE RETENIDO", 70);
                    FormatoColumnaImporte(dgvPlanillasCheques, "IMPORTE_AJUSTE", "IMPORTE AJUSTE", 70);
                    FormatoColumnaImporte(dgvPlanillasCheques, "IMPORTE_APLICADO", "IMPORTE APLICADO", 70);
                    FormatoColumnaImporte(dgvPlanillasCheques, "SALDO_COBRAR", "SALDO", 70);
                    FormatoColumnaImporte(dgvPlanillasCheques, "IMPORTE_NETO", "IMPORTE NETO", 70);
                    FormatoColumnaImporte(dgvPlanillasCheques, "IMPORTE_INICIAL", "IMPORTE X COBRAR", 70);
                    FormatoColumnaImporte(dgvPlanillasCheques, "IMP_SAL", "IMPORTE VERIFICADO", 80);


                    InvisibleColumns(dgvPlanillasCheques, "IMP_COBRADO");
                    InvisibleColumns(dgvPlanillasCheques, "IMPORTE_EXC_INI");
                    InvisibleColumns(dgvPlanillasCheques, "FECHA_CREACION");
                }

                MostarTotales();

                void AddColumns()
                {
                    if (dt != null)
                    {
                        foreach (DataColumn column in dt.Columns)
                        {
                            _ = dgvPlanillasCheques.Columns.Add(new DataGridViewTextBoxColumn
                            {
                                Name = column.ColumnName,
                                SortMode = DataGridViewColumnSortMode.NotSortable
                            });
                        }
                    }
                }

                void AddRows()
                {
                    dgvPlanillasCheques.Rows.Clear();
                    if (dt != null)
                    {
                        int rowIndex, dtIndex = 0;
                        int idSeguimiento = 0;
                        decimal importeNeto = 0;
                        bool act = false;
                        foreach (DataRow rows in dt.Rows)
                        {
                            dtIndex++;
                            rowIndex = dgvPlanillasCheques.Rows.Add();
                            DataGridViewRow row = dgvPlanillasCheques.Rows[rowIndex];
                            if (idSeguimiento != Convert.ToInt32(rows["ID_SEGUIMIENTO"]))
                            {
                                act = true;
                                ActualizarFilaAnterior(rowIndex);
                                idSeguimiento = Convert.ToInt32(rows["ID_SEGUIMIENTO"]);
                                importeNeto = Convert.ToDecimal(rows["IMPORTE_NETO"]);
                            }

                            foreach (DataGridViewColumn column in dgvPlanillasCheques.Columns)
                            {
                                if (column.Name == "SALDO_COBRAR")
                                {
                                    row.Cells[column.Name].Value = importeNeto - Convert.ToDecimal(rows["IMPORTE_VERI_COB"]);
                                    importeNeto -= Convert.ToDecimal(rows["IMPORTE_VERI_COB"]);
                                    if (act)
                                        row.Cells["IMPORTE_INICIAL"].Value = row.Cells["IMPORTE_NETO"].Value;

                                    if (dt.Rows.Count == dtIndex)
                                    {
                                        row.Cells["IMPORTE_AJUSTE"].Value = rows["IMPORTE_AJUSTE"];
                                        row.Cells["IMPORTE_RETENIDO"].Value = rows["IMPORTE_RETENIDO"];
                                        row.Cells[column.Name].Value = Convert.ToDecimal(row.Cells[column.Name].Value) -
                                            (Convert.ToDecimal(rows["IMPORTE_AJUSTE"]) + Convert.ToDecimal(rows["IMPORTE_RETENIDO"]));
                                        InsertRowTotales(dgvPlanillasCheques.RowCount);
                                    }
                                    act = false;
                                }
                                else if (column.Name != "IMPORTE_RETENIDO" && column.Name != "IMPORTE_AJUSTE" && column.Name != "IMPORTE_INICIAL"
                                    && column.Name != "SALDO_APLICADO" && column.Name != "SALDO_XAPLICAR" && column.Name != "IMPORTE_APLICADO")
                                    row.Cells[column.Name].Value = rows[column.Name];
                            }
                        }
                    }
                }

                void ActualizarFilaAnterior(int filaActual)
                {
                    if (filaActual > 0)
                    {
                        int index = (filaActual - countNewRow - 1) < 0 ? 0 : (filaActual - countNewRow - 1);
                        DataGridViewRow row = dgvPlanillasCheques.Rows[filaActual - 1];
                        row.Cells["IMPORTE_AJUSTE"].Value = dt.Rows[index]["IMPORTE_AJUSTE"];
                        row.Cells["IMPORTE_RETENIDO"].Value = dt.Rows[index]["IMPORTE_RETENIDO"];
                        row.Cells["SALDO_COBRAR"].Value = Convert.ToDecimal(row.Cells["SALDO_COBRAR"].Value)
                            - (Convert.ToDecimal(dt.Rows[index]["IMPORTE_AJUSTE"]) + Convert.ToDecimal(dt.Rows[index]["IMPORTE_RETENIDO"]));
                        InsertRowTotales(filaActual);
                    }
                }

                void InsertRowTotales(int filaActual)
                {
                    countNewRow++;
                    DataGridViewRow row = dgvPlanillasCheques.Rows[filaActual - 1];
                    Tipo_APL_SALDO tipSaldoApl = Convert.ToDecimal(row.Cells["IMPORTE_EXC_INI"].Value) > 0 ? Tipo_APL_SALDO.Planilla_Imp_Exceso : Tipo_APL_SALDO.Planilla_Imp_x_cobrar;
                    dgvPlanillasCheques.Rows.Insert(filaActual, new DataGridViewRow());
                    DataGridViewRow row2 = dgvPlanillasCheques.Rows[filaActual];
                    row2.DefaultCellStyle.BackColor = Color.LightGreen;
                    row2.Cells["NRO_PLANILLA"].Value = row.Cells["NRO_PLANILLA"].Value;
                    row2.Cells["DESC_DEP"].Value = row.Cells["DESC_DEP"].Value;
                    row2.Cells["DESC_PTO_COB"].Value = row.Cells["DESC_PTO_COB"].Value;
                    row2.Cells["TIPO_OPERACION"].Value = "TOTALES";
                    row2.Cells["IMPORTE_INICIAL"].Value = row.Cells["IMPORTE_NETO"].Value;
                    row2.Cells["IMPORTE_VERI_COB"].Value = row.Cells["IMP_COBRADO"].Value;
                    row2.Cells["IMPORTE_AJUSTE"].Value = row.Cells["IMPORTE_AJUSTE"].Value;
                    row2.Cells["IMPORTE_APLICADO"].Value = BLCheque.ObtenerImporteTotalSELAPL(Convert.ToInt32(row.Cells["ID_SEGUIMIENTO"].Value), tipSaldoApl);
                    row2.Cells["IMPORTE_RETENIDO"].Value = row.Cells["IMPORTE_RETENIDO"].Value;
                    if (tipSaldoApl == Tipo_APL_SALDO.Planilla_Imp_Exceso)
                        row2.Cells["SALDO_COBRAR"].Value = Convert.ToDecimal(row.Cells["SALDO_COBRAR"].Value) + Convert.ToDecimal(row2.Cells["IMPORTE_APLICADO"].Value);
                    else
                        row2.Cells["SALDO_COBRAR"].Value = Convert.ToDecimal(row.Cells["SALDO_COBRAR"].Value) - Convert.ToDecimal(row2.Cells["IMPORTE_APLICADO"].Value);
                }
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show(ex.Message + "\n" + ex.StackTrace, "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatoColumnaImporte(DataGridView gridView, string nameColumn, string headerText, int width)
        {
            if (gridView != null)
            {
                if (headerText != null)
                    gridView.Columns[nameColumn].HeaderText = headerText;
                gridView.Columns[nameColumn].Width = width;
                gridView.Columns[nameColumn].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                gridView.Columns[nameColumn].DefaultCellStyle.Format = V;
            }
        }

        private void FormatoColumnaFecha(DataGridView gridView, string nameColumn, string headerText, int width)
        {
            if (gridView != null)
            {
                if (headerText != null)
                    gridView.Columns[nameColumn].HeaderText = headerText;
                gridView.Columns[nameColumn].Width = width;
                gridView.Columns[nameColumn].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                gridView.Columns[nameColumn].DefaultCellStyle.Format = F;
            }
        }

        private void InvisibleColumns(DataGridView gridView, string nameColumn)
        {
            if (gridView != null)
            {
                gridView.Columns[nameColumn].Visible = false;
            }
        }

        private void CentrarColumnas(DataGridView gridView)
        {
            if (gridView != null)
            {
                foreach (DataGridViewColumn column in gridView.Columns)
                {
                    column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
        }

        private void AddColumns()
        {
            Dictionary<string, string> dicColumnsCab = new Dictionary<string, string>
            {
                { "ID_SEGUIMIENTO", "ID_SEGUIMIENTO" },
                { "DESC_DEP", "DEPARTAMENTO" },
                { "COD_PTO_COB", "COD_PTO_COB" },
                { "DESC_PTO_COB", "P.COBRANZA"},
                { "NRO_PLANILLA", "N° PLLA ENVIO"},
                { "FECHA_PLANILLA_ENVIO", "F.ENVÍO PLLA"},
                { "FE_AÑO", "FE_AÑO" },
                { "FE_MES", "FE_MES" },
                { "PERIODO", "PERIODO" },
                { "IMPORTE_NETO", "IMPORTE NETO"},
                { "IMPORTE_EJECUTADO", "IMPORTE EJECUT" },
                { "IMPORTE_VERIFICADO", "IMPORTE VERIFICADO" },
                { "IMPORTE_RETENIDO", "IMPORTE RETENIDO" },
                { "IMPORTE_AJUSTE", "IMPORTE AJUSTE" },
                { "SALDO_X_COBRAR_INI", "IMPORTE X COBRAR"},
                { "IMPORTE_EXC_INI", "IMPORTE EXCESO" },
                { "IMPORTE_APLICADO", "IMPORTE APLICADO"},
                { "SALDO", "SALDO" },
                { "NRO_PLLA_REEMBOLSO", "N° PLLA REEBLSO" },
                { "FECHA_PLLA_REEMBOLSO", "F. PLLA REEBLSO" },
                { "IMPORTE_REEMBOLSO", "IMP. REEBLSO" },
                { "SALDO_EXC_COB", "SALDO EXC COBRA" },
                { "SALDO_COBRAR", "SALDO X COBRAR" },
                { "OBSERVACIONES", "OBSERVACIONES" },
                { "TIPO_APL", "TIPO_APL" }
            };

            foreach (KeyValuePair<string, string> col in dicColumnsCab)
            {
                _ = dgvAplicacionCab.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = col.Key,
                    HeaderText = col.Value
                });
            }

            dgvAplicacionCab.Columns["NRO_PLANILLA"].Frozen = true;

            FormatoColumnaImporte(dgvAplicacionCab, "IMPORTE_NETO", null, 80);
            FormatoColumnaImporte(dgvAplicacionCab, "IMPORTE_EJECUTADO", null, 80);
            FormatoColumnaImporte(dgvAplicacionCab, "IMPORTE_VERIFICADO", null, 80);
            FormatoColumnaImporte(dgvAplicacionCab, "IMPORTE_RETENIDO", null, 80);
            FormatoColumnaImporte(dgvAplicacionCab, "IMPORTE_AJUSTE", null, 80);
            FormatoColumnaImporte(dgvAplicacionCab, "SALDO_X_COBRAR_INI", null, 80);
            FormatoColumnaImporte(dgvAplicacionCab, "IMPORTE_EXC_INI", null, 80);
            FormatoColumnaImporte(dgvAplicacionCab, "IMPORTE_APLICADO", null, 80);
            FormatoColumnaImporte(dgvAplicacionCab, "SALDO", null, 70);

            InvisibleColumns(dgvAplicacionCab, "ID_SEGUIMIENTO");
            InvisibleColumns(dgvAplicacionCab, "COD_PTO_COB");
            InvisibleColumns(dgvAplicacionCab, "FE_AÑO");
            InvisibleColumns(dgvAplicacionCab, "FE_MES");
            InvisibleColumns(dgvAplicacionCab, "TIPO_APL");

            FormatoColumnaFecha(dgvAplicacionCab, "FECHA_PLANILLA_ENVIO", "F.ENVÍO PLLA", 70);
            FormatoColumnaFecha(dgvAplicacionCab, "FECHA_PLLA_REEMBOLSO", "FECHA PLLA REEMBOLSO", 70);

            CentrarColumnas(dgvAplicacionCab);

            Dictionary<string, string> dicColumnsDet = new Dictionary<string, string>
            {
                { "ID_SEGUIMIENTO", "ID_SEGUIMIENTO" },
                { "NRO_PLANILLA", "N° PLANILLA" },
                { "FE_AÑO", "FE_AÑO" },
                { "FE_MES", "FE_MES" },
                { "PERIODO", "PERIODO" },
                { "FECHA_APLICACION", "F.APLICADO" },
                { "SALDO_INICIAL", ""},
                { "IMPORTE_APLICADO", "IMPORTE APLICADO" },
                { "SALDO", "SALDO" }
            };

            foreach (KeyValuePair<string, string> col in dicColumnsDet)
            {
                _ = dgvAplicacionDet.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = col.Key,
                    HeaderText = col.Value
                });
            }

            FormatoColumnaFecha(dgvAplicacionDet, "FECHA_APLICACION", null, 70);

            InvisibleColumns(dgvAplicacionDet, "ID_SEGUIMIENTO");
            InvisibleColumns(dgvAplicacionDet, "FE_AÑO");
            InvisibleColumns(dgvAplicacionDet, "FE_MES");
            InvisibleColumns(dgvAplicacionDet, "SALDO");
            InvisibleColumns(dgvAplicacionDet, "SALDO_INICIAL");

            AjusteColumnasDecimal(dgvAplicacionDet, "IMPORTE_APLICADO", 70);

            AlignmentTextContent(dgvAplicacionDet, "PERIODO", DataGridViewContentAlignment.MiddleCenter);

            CentrarColumnas(dgvAplicacionDet);
        }

        private void ListarSeguimientoAplicacion(string año, string mes)
        {
            try
            {
                dgvAplicacionCab.Rows.Clear();
                DataTable dt = BLCheque.SeguimientoCobranzaAplicacion(año, mes);
                int indexRow;
                foreach (DataRow row in dt.Rows)
                {
                    indexRow = dgvAplicacionCab.Rows.Add();
                    DataGridViewRow rw = dgvAplicacionCab.Rows[indexRow];
                    rw.Cells["ID_SEGUIMIENTO"].Value = row["ID_SEGUIMIENTO"];
                    rw.Cells["DESC_DEP"].Value = row["DESC_DEP"];
                    rw.Cells["COD_PTO_COB"].Value = row["COD_PTO_COB"];
                    rw.Cells["DESC_PTO_COB"].Value = row["DESC_PTO_COB"];
                    rw.Cells["FE_AÑO"].Value = row["FE_AÑO"];
                    rw.Cells["FE_MES"].Value = row["FE_MES"];
                    rw.Cells["PERIODO"].Value = row["PERIODO"];
                    rw.Cells["NRO_PLANILLA"].Value = row["NRO_PLANILLA"];
                    rw.Cells["FECHA_PLANILLA_ENVIO"].Value = row["FECHA_ENVIO"];
                    rw.Cells["IMPORTE_NETO"].Value = row["IMPORTE_NETO"];
                    rw.Cells["IMPORTE_EJECUTADO"].Value = row["IMP_EJECUTADO"];
                    rw.Cells["IMPORTE_VERIFICADO"].Value = row["IMPORTE_VERIFICADO"];
                    rw.Cells["IMPORTE_AJUSTE"].Value = row["IMPORTE_AJUSTE"];
                    rw.Cells["IMPORTE_RETENIDO"].Value = row["IMPORTE_RETENIDO"];
                    rw.Cells["SALDO_X_COBRAR_INI"].Value = row["SALDO_X_COBRAR_INI"];
                    rw.Cells["IMPORTE_EXC_INI"].Value = row["IMPORTE_EXC_INI"];
                    rw.Cells["IMPORTE_APLICADO"].Value = row["IMPORTE_APLICADO"];
                    rw.Cells["SALDO"].Value = row["SALDO"];
                    rw.Cells["TIPO_APL"].Value = row["TIPO_APL"];
                }
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show(ex.Message + "\n" + ex.StackTrace, "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void StyleHeaderTextDataGridView()
        {
            foreach (DataGridViewColumn column in dgvPlanillasCheques.Columns)
            {
                if (column.Index <= 4)
                    column.HeaderCell.Style.BackColor = Color.White;
                else if (column.Index <= 8)
                    column.HeaderCell.Style.BackColor = colorBack[0];
                else if (column.Index <= 14)
                    column.HeaderCell.Style.BackColor = colorBack[1];
                else if (column.Index <= 16)
                    column.HeaderCell.Style.BackColor = colorBack[2];
                else if (column.Index <= 23)
                    column.HeaderCell.Style.BackColor = colorBack[3];
                else if (column.Index <= 29)
                    column.HeaderCell.Style.BackColor = colorBack[4];
                else if (column.Index <= 34)
                    column.HeaderCell.Style.BackColor = colorBack[5];
                else
                    column.HeaderCell.Style.BackColor = colorBack[6];
            }
        }

        private void BackColorLeyeda()
        {
            lblEtap1.BackColor = colorBack[0];
            lblEtapa2.BackColor = colorBack[1];
            lblEtapa3.BackColor = colorBack[2];
            lblEtapa4.BackColor = colorBack[3];
            lblEtapa5.BackColor = colorBack[4];
            lblEtapa6.BackColor = colorBack[5];
            lblEtapa7.BackColor = colorBack[6];

            lblTot1.BackColor = colorBack[0];
            lblTot2.BackColor = colorBack[1];
            lblTot3.BackColor = colorBack[2];
            lblTot4.BackColor = colorBack[4];
            lblTot5.BackColor = colorBack[4];
            lblTot6.BackColor = colorBack[4];
            lblTot7.BackColor = colorBack[4];
        }

        private void MostarTotales()
        {
            decimal impTot1 = 0;
            decimal impTot2 = 0;
            decimal impTot3 = 0;
            decimal impTot4 = 0;
            decimal impTot5 = 0;
            decimal impTot6 = 0;
            decimal impTot7 = 0;
            //foreach (DataGridViewRow row in dgvPlanillasCheques.Rows)
            //{
            //    impTot1 += string.IsNullOrEmpty(row.Cells["IMPORTE_CHEQUE"].Value.ToString()) ? 0 : Convert.ToDecimal(row.Cells["IMPORTE_CHEQUE"].Value, culture);
            //    impTot2 += string.IsNullOrEmpty(row.Cells["IMP_TRANSFERENCIA"].Value.ToString()) ? 0 : Convert.ToDecimal(row.Cells["IMP_TRANSFERENCIA"].Value, culture);
            //    impTot3 += string.IsNullOrEmpty(row.Cells["IMPORTE_RECEPCION"].Value.ToString()) ? 0 : Convert.ToDecimal(row.Cells["IMPORTE_RECEPCION"].Value, culture);
            //    impTot4 += string.IsNullOrEmpty(row.Cells["IMPORTE_NETO"].Value.ToString()) ? 0 : Convert.ToDecimal(row.Cells["IMPORTE_NETO"].Value, culture);
            //    impTot5 += string.IsNullOrEmpty(row.Cells["IMPORTE_VERIFICADO"].Value.ToString()) ? 0 : Convert.ToDecimal(row.Cells["IMPORTE_VERIFICADO"].Value, culture);
            //    impTot6 += string.IsNullOrEmpty(row.Cells["SALDO_CHEQUE"].Value.ToString()) ? 0 : Convert.ToDecimal(row.Cells["SALDO_CHEQUE"].Value, culture);
            //    impTot7 += string.IsNullOrEmpty(row.Cells["RETENCION_ENTIDAD"].Value.ToString()) ? 0 : Convert.ToDecimal(row.Cells["RETENCION_ENTIDAD"].Value, culture);
            //}

            lblTot1.Text = "Imp.Cheque : " + impTot1.ToString("N2");
            lblTot2.Text = "Imp.Trans : " + impTot2.ToString("N2");
            lblTot3.Text = "Imp.Recep : " + impTot3.ToString("N2");
            lblTot4.Text = "Plla.Cob.Neta : " + impTot4.ToString("N2");
            lblTot5.Text = "Imp.Banco : " + impTot5.ToString("N2");
            lblTot6.Text = "Sal. X Cob : " + impTot6.ToString("N2");
            lblTot7.Text = "Retención : " + impTot7.ToString("N2");
        }

        private void DgvPlanillasCheques_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPlanillasCheques.CurrentCell != null)
            {
                if (dgvPlanillasCheques.CurrentRow.Cells["TIPO_OPERACION"].Value?.ToString() == "TOTALES")
                    dgvPlanillasCheques.DefaultCellStyle.SelectionBackColor = Color.LightGreen;
                else
                    dgvPlanillasCheques.DefaultCellStyle.SelectionBackColor = Color.White;
            }
        }

        private void CboMes2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string mes = cboMes2.SelectedValue.ToString();
            ListarSeguimientoAplicacion(numAño2.Value.ToString(), mes);
        }

        private void NumAño2_ValueChanged(object sender, EventArgs e)
        {
            string mes = cboMes2.SelectedValue.ToString();
            ListarSeguimientoAplicacion(numAño2.Value.ToString(), mes);
        }

        private void DgvAplicacionCab_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAplicacionCab.CurrentCell != null)
            {
                int idSegumiento = Convert.ToInt32(dgvAplicacionCab.CurrentRow.Cells["ID_SEGUIMIENTO"].Value);
                Tipo_APL_SALDO apl = Convert.ToInt32(dgvAplicacionCab.CurrentRow.Cells["TIPO_APL"].Value) == 1
                    ? Tipo_APL_SALDO.Planilla_Imp_x_cobrar : Tipo_APL_SALDO.Planilla_Imp_Exceso;
                lblTituloDetalle.Text = apl == Tipo_APL_SALDO.Planilla_Imp_x_cobrar ? "Planilla con Exceso para Aplicar - Detalle" : "Planillas Aplicadas - Detalle";
                lblTituloDetalle.Location = apl == Tipo_APL_SALDO.Planilla_Imp_x_cobrar ? new Point { X = 15, Y = 4 } : new Point { X = 53, Y = 4 };
                dgvAplicacionDet.Columns["SALDO_INICIAL"].HeaderText = apl == Tipo_APL_SALDO.Planilla_Imp_x_cobrar ? "IMPORTE EXCESO" : "IMPORTE X COBRAR";
                CargarDataDetalle(idSegumiento, apl);
            }

        }

        private void CargarDataDetalle(int idSeguimiento, Tipo_APL_SALDO apl)
        {
            DataTable dt = BLCheque.ObtenerDetalleAplicacionSaldos(idSeguimiento, apl);
            dgvAplicacionDet.Rows.Clear();
            if (dt != null)
            {
                int indexRow;
                foreach (DataRow row in dt.Rows)
                {
                    indexRow = dgvAplicacionDet.Rows.Add();
                    DataGridViewRow rw = dgvAplicacionDet.Rows[indexRow];
                    rw.Cells["ID_SEGUIMIENTO"].Value = row["ID_SEGUIMIENTO"];
                    rw.Cells["NRO_PLANILLA"].Value = row["NRO_PLANILLA"];
                    rw.Cells["PERIODO"].Value = row["PERIODO"];
                    rw.Cells["FECHA_APLICACION"].Value = row["FECHA_APLICADO"];
                    rw.Cells["SALDO_INICIAL"].Value = row["SALDO_INICIAL"];
                    rw.Cells["IMPORTE_APLICADO"].Value = row["IMPORTE_APLICADO"];
                    rw.Cells["SALDO"].Value = row["SALDO"];
                }
            }
        }

        private void NumAño_ValueChanged(object sender, EventArgs e)
        {
            string mes = cboMes.SelectedValue.ToString();
            ListarSegumientoCheques(numAño.Value.ToString(), mes);
        }

        private void CboMes_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string mes = cboMes.SelectedValue.ToString();
            ListarSegumientoCheques(numAño.Value.ToString(), mes);
        }
    }
}
