using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Entidades;
using static Entidades.ConstClass;
using static Presentacion.HELPERS.FormatDataGridViewColumns;
using static Presentacion.HELPERS.ErrorPrint;
using static Presentacion.HELPERS.GenericMethod;

namespace Presentacion.MOD_FACT_VTA.MOD_VTA
{
    public partial class FinalizarCobranzaPlanilla : Form
    {
        private readonly decimal impNetoPlanilla, impCobrado, saldo, impEjec, impCasill, impExceso, impAplicEnv, impAplicRec, impReembolso;
        private readonly string codPtoCob, COD_USUARIO, nroPlanillaCob, feAño, feMes, tipoPlanilla, nroPlanillaEnv, ent_pag_che;
        private readonly int idSeguimiento;
        public FinalizarCobranzaPlanilla(int idSeguimiento, decimal impEjec, decimal impCasill, decimal impNetoPlanilla, decimal impCobrado, decimal saldo,
            decimal impExceso, decimal impAplicEnv, decimal impAplicRec, decimal impReembolso, string codPtoCob, string nroPlanillaEnv, string nroPlanillaCob, string feAño, string feMes, string tipoPlanilla,
            string ent_pag_che, string codUsuario)
        {
            InitializeComponent();
            this.idSeguimiento = idSeguimiento;
            this.impNetoPlanilla = impNetoPlanilla;
            this.impCobrado = impCobrado;
            this.saldo = saldo;
            this.impExceso = impExceso;
            this.impEjec = impEjec;
            this.impCasill = impCasill;
            this.impAplicEnv = impAplicEnv;
            this.impAplicRec = impAplicRec;
            this.impReembolso = impReembolso;
            this.codPtoCob = codPtoCob;
            COD_USUARIO = codUsuario;
            this.nroPlanillaCob = nroPlanillaCob;
            this.feAño = feAño;
            this.feMes = feMes;
            this.tipoPlanilla = tipoPlanilla;
            this.nroPlanillaEnv = nroPlanillaEnv;
            this.ent_pag_che = ent_pag_che;
        }

        public FinalizarCobranzaPlanilla(int idSeguimiento, decimal impEjec, decimal impCasill, decimal impNetoPlanilla, decimal impCobrado, decimal saldo,
            decimal impExceso, decimal impAplicEnv, decimal impAplicRec, decimal impReembolso, string codPtoCob, string nroPlanillaEnv, string nroPlanillaCob,
            string ent_pag_che, string codUsuario)
        {
            InitializeComponent();
            this.idSeguimiento = idSeguimiento;
            this.impNetoPlanilla = impNetoPlanilla;
            this.impCobrado = impCobrado;
            this.saldo = saldo;
            this.impExceso = impExceso;
            this.impEjec = impEjec;
            this.impCasill = impCasill;
            this.impAplicEnv = impAplicEnv;
            this.impAplicRec = impAplicRec;
            this.impReembolso = impReembolso;
            this.codPtoCob = codPtoCob;
            COD_USUARIO = codUsuario;
            this.nroPlanillaEnv = nroPlanillaEnv;
            this.nroPlanillaCob = nroPlanillaCob;
            this.ent_pag_che = ent_pag_che;
        }

        private readonly ChequeBLL BLCheque = new ChequeBLL();
        private readonly HelpersBLL helBLL = new HelpersBLL();
        private readonly canjeTCtasxCobrarTo ctcTo = new canjeTCtasxCobrarTo();
        private readonly canjeTCtasxCobrarBLL ctcBLL = new canjeTCtasxCobrarBLL();
        private readonly SeguimientoPlanillasBLL BLSeguimientoPlla = new SeguimientoPlanillasBLL();
        private readonly tipoDocInvTo tdiTo = new tipoDocInvTo();
        private readonly tipoDocInvBLL tdiBLL = new tipoDocInvBLL();
        private List<planillaCabeceraOtrasDevDsctosTo> lstPlanillaCabecera;
        private List<planillaCabeceraOtrasDevDsctosTo> lstPlanillasEliminadas;
        private List<planillaCabeceraOtrasDevDsctosTo> lstEliminarReembolsos;
        private List<devPCtasCobrarTo> lstDevPctasCobrar;
        private List<devTCtasCobrarTo> lstDevTctasCobrar;

        private decimal monto_pagado, monto_total, monto_total_a_pagar;
        private string COD_UBICACION, COD_DOC, tipoPlanillaCobranza;
        private DataTable dtClientes, dtTipPlla, dtRetencionEliminados, dtPlanillasAplicados, dtAplicacionesEliminar;
        private static bool acc;
        private bool cuota_comprometida;
        private string descPtoCob;
        private const string REGISTROS_GRABADOS = "*";
        private const string REGISTROS_NUEVOS = "-";
        private const string COD_MOTIVO_REEMBOLSO_ENTIDAD = "10";
        private const string COD_MOTIVO_RETENCION = "09";
        private const string COD_AREA_TRABAJO = "015";
        private const string MESSAGE_NULL_PERIODO = "SeguimientoCheques.AÑO - MES NULL Frm FinalizarCobranzaPlanillas";
        private string codSucursal;
        private decimal saldoFinal;
        public bool EsCerrar { get; set; }

        private void FinalizarCobranzaPlanilla_Load(object sender, EventArgs e)
        {
            StartControls();
            AgregarColumnasDgvRetencion();
            AddColumnsReembolso();
            MostrarDatosGenerales();
            CargarSucursal();
            CargarInstitucion();
            CargarCanalDscto();
            CargarMotivos();
            CargarTipoPlanilla();
            ObtenerAplicaciones();
            ListarReembolsos();
            FormatdgvReembolsos();
            //> ListarClientes();
            MostrarDatos();
            DeshabilitarOpciones();
        }

        private void StartControls()
        {
            FormatoNumericUpDown(numNeto);
            FormatoNumericUpDown(numCobrado);
            FormatoNumericUpDown(numRetencion);
            FormatoNumericUpDown(numSaldoXCobrar);
            FormatoNumericUpDown(numSaldoFinal);
            FormatoNumericUpDown(numImpPlla);
            FormatoNumericUpDown(numImpRetenido);
            FormatoNumericUpDown(numAplicRec);
            FormatoNumericUpDown(numAplicEnv);
            FormatoNumericUpDown(numReembolso);
            FormatoNumericUpDown(numXCobrEnt);
            FormatoNumericUpDown(numEjec);
            FormatoNumericUpDown(numCasill);
            FormatoNumericUpDown(numExceCobranza);
            numAjuste.DecimalPlaces = 2;
            numAjuste.Maximum = decimal.MaxValue;
            numAjuste.Minimum = decimal.MinValue;
            numAjuste.ThousandsSeparator = true;

            dtFechaCierre.Enabled = false;
            dtp_generacion.Value = Convert.ToDateTime(1 + "/" + SeguimientoCheques.MES + "/" + SeguimientoCheques.AÑO);
            cboMotivo.Enabled = false;
            cbo_tipo_planilla.Enabled = true;

            StyleDataGridView(dgvRetencion);
            dgw_det.Style3();
            StyleDataGridView(dgvReembolsos);
            StyleDataGridView(dgvAplicaciones);

            gbRetenciones.Controls.Add(dgvRetencion);
            dgvRetencion.Location = new Point { X = 10, Y = 16 };
            dgvRetencion.DefaultCellStyle.Font = new Font(dgvRetencion.Font, FontStyle.Regular);

            Panel_PER.Visible = false;
            groupBox2.Visible = false;
            cbo_tipo_planilla.DropDownStyle = ComboBoxStyle.DropDownList;
            txt_num.Enabled = false;
            txt_ser.Enabled = false;
            txtCodTipoPlanilla.Text = TIPO_PLLA_RETENCION;
        }

        private void DeshabilitarOpciones()
        {
            btnVerRetencion.Visible = impExceso == 0;
            btnRetSinPrePlla.Visible = impExceso == 0;
            btnRetConPrePlla.Visible = impExceso == 0;
            btnNuevoReembolso.Visible = impExceso > 0;
            btnVerApliEnv.Visible = false;
        }

        private void StyleDataGridView(DataGridView grid)
        {
            if (grid != null)
            {
                grid.DefaultCellStyle.Font = new Font(grid.Font, FontStyle.Regular);
                grid.SelectionMode = DataGridViewSelectionMode.CellSelect;
                grid.RowHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
                grid.RowHeadersVisible = false;
            }
        }

        private void FormatoNumericUpDown(NumericUpDown numeric)
        {
            numeric.DecimalPlaces = 2;
            numeric.ThousandsSeparator = true;
            numeric.ReadOnly = true;
            numeric.Maximum = decimal.MaxValue;
            numeric.Minimum = decimal.MinValue;
            numeric.Increment = 0;
            numeric.BackColor = Color.White;
            numeric.TextAlign = HorizontalAlignment.Right;
        }

        private void AgregarColumnasDgvRetencion()
        {
            _ = dgvRetencion.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TAG",
                Visible = false,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            _ = dgvRetencion.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ID_SEGUIMIENTO",
                Visible = false,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            _ = dgvRetencion.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ID_RETENCION",
                Visible = false,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            _ = dgvRetencion.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NRO_PLANILLA_COB",
                HeaderText = "N° Documet.",
                Width = 80,
                ReadOnly = true,
                SortMode = DataGridViewColumnSortMode.NotSortable,
            });
            _ = dgvRetencion.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "COD_PTO_COB",
                Visible = false,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            _ = dgvRetencion.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "COD_INSTITUCION",
                Visible = false,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            _ = dgvRetencion.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "COD_CANAL_DSCTO",
                Visible = false,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            _ = dgvRetencion.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "COD_SUCURSAL",
                Visible = false,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            _ = dgvRetencion.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "COD_CLASE",
                Visible = false,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            _ = dgvRetencion.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FE_AÑO",
                Visible = false,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            _ = dgvRetencion.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FE_MES",
                Visible = false,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            _ = dgvRetencion.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FE_AÑO_REF",
                Visible = false,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            _ = dgvRetencion.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FE_MES_REF",
                Visible = false,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            _ = dgvRetencion.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "PERIODO",
                HeaderText = "Período",
                Width = 58,
                ReadOnly = true,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            _ = dgvRetencion.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TIPO_PLANILLA_DOC",
                Visible = false,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            _ = dgvRetencion.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NRO_DOCU",
                Visible = false,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            _ = dgvRetencion.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "MOTIVO_OTRAS_DEV_DSCTOS",
                Visible = false,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            _ = dgvRetencion.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NRO_LETRA",
                Visible = false,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            _ = dgvRetencion.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IMP_DEV",
                Visible = false,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            _ = dgvRetencion.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NRO_CONTRATO",
                HeaderText = "N° Contrato",
                Width = 80,
                ReadOnly = true,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            _ = dgvRetencion.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "COD_PER",
                HeaderText = "Cod.Per",
                Width = 70,
                ReadOnly = true,
                SortMode = DataGridViewColumnSortMode.NotSortable,
                Visible = false
            });
            _ = dgvRetencion.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DESC_PER",
                HeaderText = "Nombres",
                Width = 190,
                ReadOnly = true,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            _ = dgvRetencion.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TIPO_PLANILLA_DESC",
                HeaderText = "Tipo Planilla",
                Width = 120,
                ReadOnly = true,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            _ = dgvRetencion.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NRO_PLANILLA_DOC",
                HeaderText = "N° Plla.Reten.",
                Width = 95,
                ReadOnly = true,
                SortMode = DataGridViewColumnSortMode.NotSortable,
            });
            _ = dgvRetencion.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IMPORTE",
                HeaderText = "Imp.Ini",
                Width = 60,
                ReadOnly = true,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            _ = dgvRetencion.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IMP_RETENCION_OLD",
                ValueType = typeof(decimal),
                Width = 90,
                SortMode = DataGridViewColumnSortMode.NotSortable,
                Visible = false
            });
            _ = dgvRetencion.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IMP_RETENCION",
                HeaderText = "Imp.Retenido",
                ValueType = typeof(decimal),
                Width = 90,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            _ = dgvRetencion.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IMP_RET_OTRA_PLLA",
                HeaderText = "Imp.Ret.otr.Plla",
                ValueType = typeof(decimal),
                Width = 95,
                ReadOnly = true,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            _ = dgvRetencion.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IMP_DOC",
                Visible = false,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            _ = dgvRetencion.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "SALDO",
                HeaderText = "Sald.X.Ret",
                SortMode = DataGridViewColumnSortMode.NotSortable,
                Width = 75,
                ReadOnly = true
            });
            _ = dgvRetencion.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "STATUS_APROBADO",
                HeaderText = "Aprobado",
                Width = 70,
                SortMode = DataGridViewColumnSortMode.NotSortable,
                ReadOnly = true
            });
            _ = dgvRetencion.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NRO_PLLA_ORIGEN",
                SortMode = DataGridViewColumnSortMode.NotSortable,
                ReadOnly = true,
                Visible = false
            });
            _ = dgvRetencion.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TIPO_PLLA_ORIGEN",
                SortMode = DataGridViewColumnSortMode.NotSortable,
                ReadOnly = true,
                Visible = false
            });

            dgvRetencion.Columns["IMPORTE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvRetencion.Columns["IMP_RETENCION"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvRetencion.Columns["IMP_RET_OTRA_PLLA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvRetencion.Columns["SALDO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvRetencion.Columns["STATUS_APROBADO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void MostrarDatosGenerales()
        {
            numNeto.Value = impNetoPlanilla;
            numSaldoXCobrar.Value = saldo;
            numEjec.Value = impEjec;
            numCasill.Value = impCasill;
            numExceCobranza.Value = impExceso;
            numAplicRec.Value = impAplicRec; //> BLCheque.ObtenerTotalAplicado(idSeguimiento);
            numAplicEnv.Value = impAplicEnv;
            numReembolso.Value = impReembolso;
            numCobrado.Value = impCobrado;
        }

        private void MostrarDatos()
        {
            try
            {
                DataTable dt = BLCheque.ObtenerDatosCierreCobrazaPlla(nroPlanillaEnv, nroPlanillaCob, ent_pag_che);
                dgvRetencion.Rows.Clear();
                numImpPlla.Value = 0;
                if (dt != null && dt.Rows.Count > 0)
                {
                    int index;
                    foreach (DataRow row in dt.Rows)
                    {
                        if (!string.IsNullOrEmpty(row["COD_PER"].ToString()))
                        {
                            index = dgvRetencion.Rows.Add();
                            DataGridViewRow newrow = dgvRetencion.Rows[index];
                            newrow.Cells["TAG"].Value = REGISTROS_GRABADOS;
                            newrow.Cells["ID_SEGUIMIENTO"].Value = row["ID_SEGUIMIENTO"];
                            newrow.Cells["ID_RETENCION"].Value = row["ID_RENTENCION"];
                            newrow.Cells["TIPO_PLANILLA_DESC"].Value = row["TIPO_PLANILLA_DESC"];
                            newrow.Cells["NRO_PLANILLA_DOC"].Value = row["NRO_PLANILLA_DOC"];
                            newrow.Cells["NRO_PLANILLA_COB"].Value = row["NRO_PLANILLA_COB"];
                            newrow.Cells["COD_CANAL_DSCTO"].Value = row["COD_CANAL_DSCTO"];
                            newrow.Cells["COD_INSTITUCION"].Value = row["COD_INSTITUCION"];
                            newrow.Cells["TIPO_PLANILLA_DOC"].Value = row["TIPO_PLANILLA_DOC"];
                            newrow.Cells["COD_SUCURSAL"].Value = row["COD_SUCURSAL"];
                            newrow.Cells["COD_PTO_COB"].Value = row["COD_PTO_COB"];
                            newrow.Cells["MOTIVO_OTRAS_DEV_DSCTOS"].Value = "";
                            newrow.Cells["NRO_LETRA"].Value = "";
                            newrow.Cells["FE_AÑO"].Value = row["FE_AÑO"];
                            newrow.Cells["FE_MES"].Value = row["FE_MES"];
                            newrow.Cells["NRO_CONTRATO"].Value = row["NRO_CONTRATO"];
                            newrow.Cells["COD_PER"].Value = row["COD_PER"];
                            newrow.Cells["DESC_PER"].Value = row["DESC_PER"];
                            newrow.Cells["IMPORTE"].Value = row["IMP_PLANILLA"];
                            newrow.Cells["IMP_DOC"].Value = row["IMP_PLANILLA"];
                            newrow.Cells["IMP_DEV"].Value = 0.00;
                            newrow.Cells["IMP_RETENCION_OLD"].Value = row["IMP_RETENIDO"];
                            newrow.Cells["IMP_RETENCION"].Value = row["IMP_RETENIDO"];
                            newrow.Cells["IMP_RET_OTRA_PLLA"].Value = row["IMP_RET_OTRA_PLLA"];
                            newrow.Cells["PERIODO"].Value = row["FE_MES_REF"].ToString() + " - " + row["FE_AÑO_REF"].ToString();
                            newrow.Cells["SALDO"].Value = Convert.ToDecimal(row["IMP_PLANILLA"]) - Convert.ToDecimal(row["IMP_RETENIDO"]) - Convert.ToDecimal(row["IMP_RET_OTRA_PLLA"]);
                            newrow.Cells["STATUS_APROBADO"].Value = Convert.ToBoolean(row["STATUS_APROBADO"]);
                            newrow.Cells["FE_AÑO_REF"].Value = row["FE_AÑO_REF"];
                            newrow.Cells["FE_MES_REF"].Value = row["FE_MES_REF"];
                            numImpPlla.Value += Convert.ToDecimal(row["IMP_PLANILLA"]);
                        }
                    }

                    ActualizarTotalRetencion();
                    numAjuste.Value = Convert.ToDecimal(dt.Rows[0]["IMPORTE_AJUSTE"]);
                    numXCobrEnt.Value = numNeto.Value - numRetencion.Value - numAjuste.Value;
                    dtFechaCierre.Value = string.IsNullOrEmpty(dt.Rows[0]["FECHA_CIERRE_COBRANZA"].ToString())
                        ? DateTime.Now
                        : Convert.ToDateTime(dt.Rows[0]["FECHA_CIERRE_COBRANZA"]);
                }
            }
            catch (Exception ex)
            {
                ex.PrintException();
            }
        }

        private void ListarClientes()
        {
            dgw_per.Rows.Clear();
            dtClientes = BLCheque.ListarPlanillasDsctosPendienteXCodPtoCobRetencion(codPtoCob, nroPlanillaCob, feAño, feMes, tipoPlanilla);
            if (dtClientes.Rows.Count > 0)
            {
                foreach (DataRow rw in dtClientes.Rows)
                {
                    int rowId = dgw_per.Rows.Add();
                    DataGridViewRow row = dgw_per.Rows[rowId];
                    row.Cells["NRO_PLANILLA_COB1"].Value = rw["NRO_PLANILLA_COB"].ToString();
                    row.Cells["COD_PTO_COB"].Value = rw["COD_PTO_COB"].ToString();
                    row.Cells["DESC_PTO_COB"].Value = rw["DESC_PTO_COB"].ToString();
                    row.Cells["COD_SUCURSAL1"].Value = rw["COD_SUCURSAL"].ToString();
                    row.Cells["FE_AÑO1"].Value = rw["FE_AÑO"].ToString();
                    row.Cells["FE_MES1"].Value = rw["FE_MES"].ToString();
                    row.Cells["COD_PER1"].Value = rw["COD_PER"].ToString();
                    row.Cells["DESC_PER1"].Value = rw["DESC_PER"].ToString();
                    row.Cells["NRO_DOC1"].Value = rw["NRO_DOC"].ToString();
                    row.Cells["DESC_MOTIVO_OT_DEV1"].Value = rw["DESC_MOTIVO_OT_DEV"].ToString();
                    row.Cells["IMP_DOC1"].Value = rw["IMP_DOC"].ToString();
                    row.Cells["COD_MOTIVO_NO_DESCONTADO1"].Value = rw["COD_MOTIVO_NO_DESCONTADO"].ToString();
                    row.Cells["COD_INSTITUCION1"].Value = rw["COD_INSTITUCION"].ToString();
                    row.Cells["COD_CANAL_DSCTO1"].Value = rw["COD_CANAL_DSCTO"].ToString();
                    row.Cells["TIPO_PLA_COBRANZA1"].Value = rw["TIPO_PLA_COBRANZA"].ToString();
                    row.Cells["NRO_PRESUPUESTO1"].Value = rw["NRO_PRESUPUESTO"].ToString();
                    row.Cells["DESC_TIPO1"].Value = rw["DESC_TIPO"].ToString();
                    row.Cells["NRO_LETRA1"].Value = rw["NRO_LETRA"].ToString();
                    row.Cells["TOTAL_CONTRATO"].Value = rw["TOTAL_CONTRATO"].ToString();
                    row.Cells["CUOTA_COMPROMETIDA1"].Value = rw["CUOTA_COMPROMETIDA"].ToString() == "True" ? "1" : "0";
                    row.Cells["COD_UBICACION1"].Value = Convert.ToString(rw["COD_UBICACION"]);
                    row.Cells["PERIODO"].Value = rw["FE_MES"].ToString() + "-" + rw["FE_AÑO"].ToString();
                    row.Cells["IMP_INI"].Value = rw["IMP_INI"];
                    row.Cells["Imp_Aprob"].Value = Convert.ToDecimal(rw["IMP_INI"]) - Convert.ToDecimal(rw["IMP_DOC"]);
                    row.Cells["Imp_X_Aprob"].Value = rw["IMPORTE_X_APROB"];
                    row.Cells["saldo_sin_aprob"].Value = Convert.ToDecimal(rw["IMP_INI"]) - Convert.ToDecimal(rw["IMPORTE_X_APROB"]) - (Convert.ToDecimal(rw["IMP_INI"]) - Convert.ToDecimal(rw["IMP_DOC"]));
                }
            }
        }

        private void ObtenerAplicaciones()
        {
            try
            {
                DataTable dt;
                if (numExceCobranza.Value == 0)
                    dt = BLCheque.ObtenerDetalleAplicacionSaldos(idSeguimiento, Tipo_APL_SALDO.Planilla_Imp_x_cobrar);
                else
                    dt = BLCheque.ObtenerDetalleAplicacionSaldos(idSeguimiento, Tipo_APL_SALDO.Planilla_Imp_Exceso);

                if (dgvAplicaciones.Columns.Count == 0)
                    AddColumns();

                AddRows();
                ObtenerTotalesAplicacion();

                lblTotalImporteAplicado.Text = "Total Importe Aplicar : " + numAplicRec.Value.ToString();

                if (dt != null)
                {
                    dgvAplicaciones.Columns["ID_SEGUIMIENTO"].Visible = false;
                    dgvAplicaciones.Columns["NRO_DOCUMENTO"].HeaderText = "N° Aplicación";
                    dgvAplicaciones.Columns["NRO_PLANILLA"].HeaderText = impExceso > 0 ? "N° Planilla Destino" : "N° Planilla Origen";
                    dgvAplicaciones.Columns["PERIODO"].HeaderText = impExceso > 0 ? "Periodo Destino" : "Periodo Origen";
                    dgvAplicaciones.Columns["FECHA_APLICADO"].HeaderText = "Fecha Aplicación";
                    dgvAplicaciones.Columns["FECHA_APLICADO"].DefaultCellStyle.Format = "dd/MM/yyyy";
                    dgvAplicaciones.Columns["SALDO_INICIAL"].HeaderText = "Exceso Inicial";
                    dgvAplicaciones.Columns["IMPORTE_APLICADO"].HeaderText = "Importe Aplicado";
                    dgvAplicaciones.Columns["IMPORTE_APLICADO"].ReadOnly = false;
                    dgvAplicaciones.Columns["SALDO"].HeaderText = numExceCobranza.Value > 0 ? "Saldo x Cobrar" : "Saldo Exc";
                    dgvAplicaciones.Columns["ID_SEGUIMIENTO_APL"].Visible = false;
                    dgvAplicaciones.Columns["ID_SEGUIMIENTO_SEL"].Visible = false;
                    dgvAplicaciones.Columns["FE_AÑO_REF"].Visible = false;
                    dgvAplicaciones.Columns["FE_MES_REF"].Visible = false;
                    dgvAplicaciones.Columns["FE_AÑO"].Visible = false;
                    dgvAplicaciones.Columns["FE_MES"].Visible = false;
                    dgvAplicaciones.Columns["TIPO_DOC"].Visible = false;
                    dgvAplicaciones.Columns["IMPORTE_APLICADO_OLD"].Visible = false;
                    AlignmentTextContent(dgvAplicaciones, "SALDO", DataGridViewContentAlignment.MiddleRight);
                    AlignmentTextContent(dgvAplicaciones, "IMPORTE_APLICADO", DataGridViewContentAlignment.MiddleRight);
                    AlignmentTextContent(dgvAplicaciones, "SALDO_INICIAL", DataGridViewContentAlignment.MiddleRight);
                    AlignmentTextContent(dgvAplicaciones, "FECHA_APLICADO", DataGridViewContentAlignment.MiddleCenter);
                    AlignmentTextContent(dgvAplicaciones, "PERIODO", DataGridViewContentAlignment.MiddleCenter);
                    if (numExceCobranza.Value > 0)
                        InvisibleColumna(dgvAplicaciones, "SALDO_INICIAL");
                    InvisibleColumna(dgvAplicaciones, "USUARIO_CREA");
                }

                void AddColumns()
                {
                    if (dt != null)
                    {
                        foreach (DataColumn column in dt.Columns)
                        {
                            _ = dgvAplicaciones.Columns.Add(new DataGridViewTextBoxColumn
                            {
                                Name = column.ColumnName,
                                SortMode = DataGridViewColumnSortMode.NotSortable,
                                ReadOnly = true
                            });
                        }
                        _ = dgvAplicaciones.Columns.Add(new DataGridViewTextBoxColumn
                        {
                            Name = "TAG",
                            Visible = false
                        });
                    }
                }

                void AddRows()
                {
                    dgvAplicaciones.Rows.Clear();
                    if (dt != null)
                    {
                        int indexRow;
                        foreach (DataRow row in dt.Rows)
                        {
                            indexRow = dgvAplicaciones.Rows.Add();
                            DataGridViewRow rw = dgvAplicaciones.Rows[indexRow];
                            foreach (DataGridViewColumn column in dgvAplicaciones.Columns)
                            {
                                if (column.Name == "TAG")
                                    rw.Cells[column.Name].Value = REGISTROS_GRABADOS;
                                else
                                    rw.Cells[column.Name].Value = row[column.Name];
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.PrintException();
            }
        }


        private void AddColumnsReembolso()
        {
            var columns = new[]
            {
                new { name = "TAG", headerText = "TAG", readOnly = true },
                new { name = "#", headerText = "#", readOnly = true },
                new { name = "NRO_PLANILLA_DOC", headerText = "N° Reembolso", readOnly = true },
                new { name = "FE_AÑO", headerText = "FE_AÑO", readOnly = true },
                new { name = "FE_MES", headerText = "FE_MES", readOnly = true },
                new { name = "PERIODO", headerText = "Período Reembolso", readOnly = true },
                new { name = "FECHA_REGISTRO", headerText = "Fecha Reembolso", readOnly = true },
                new { name = "IMPORTE", headerText = "Importe" , readOnly = false },
                //> new { name = "FECHA_PLANILLA_DOC", headerText = "Fecha Planilla", readOly = false },
                new { name = "STATUS_APROBADO", headerText = "Aprobado" , readOnly = true }
            };

            foreach (var item in columns)
            {
                if (item.name == "STATUS_APROBADO")
                {
                    dgvReembolsos.Columns.Add(new DataGridViewCheckBoxColumn
                    {
                        Name = item.name,
                        HeaderText = item.headerText,
                        ReadOnly = item.readOnly
                    });
                }
                else
                {
                    dgvReembolsos.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        Name = item.name,
                        HeaderText = item.headerText,
                        ReadOnly = item.readOnly
                    });
                }
            }

            dgvReembolsos.AlingHeaderTextCenter();
            AlignmentTextContent(dgvReembolsos, "#", DataGridViewContentAlignment.MiddleCenter);

            AjusteColumnasDecimal(dgvReembolsos, "IMPORTE", 100);
            AjusteColumnasTextBox(dgvReembolsos, "#", 30);

            //> AjustecolumnasFecha(dgvReembolsos, "FECHA_PLANILLA_DOC", 70);

            InvisibleColumna(dgvReembolsos, "TAG");
            InvisibleColumna(dgvReembolsos, "FE_AÑO");
            InvisibleColumna(dgvReembolsos, "FE_MES");
        }

        private void CargarSucursal()
        {
            HelpersTo helTo = new HelpersTo
            {
                CODIGO = COD_USUARIO
            };
            DataTable dt = helBLL.CBO_SUCURSALBLL(helTo);
            cbo_sucursal.ValueMember = "COD_SUCURSAL";
            cbo_sucursal.DisplayMember = "DESC_sucursal";
            cbo_sucursal.DataSource = dt;
            cbo_sucursal.SelectedIndex = -1;
        }

        private void CargarInstitucion()
        {
            institucionesBLL insBLL = new institucionesBLL();
            DataTable dtInstitucion = insBLL.obtenerInstitucionesBLL();
            cbo_institucion.ValueMember = "COD_INST";
            cbo_institucion.DisplayMember = "DESC_INST";
            cbo_institucion.DataSource = dtInstitucion;
            cbo_institucion.SelectedIndex = -1;
        }

        private void CargarCanalDscto()
        {
            canalDescuentoBLL cdscBLL = new canalDescuentoBLL();
            DataTable dt = cdscBLL.ObtenerCanalDescuentoBLL();
            cbo_canaldscto.ValueMember = "COD_CANAL_DSCTO";
            cbo_canaldscto.DisplayMember = "DESCRIPCION";
            cbo_canaldscto.DataSource = dt;
            cbo_canaldscto.SelectedIndex = -1;
        }

        private void CargarMotivos()
        {
            motivos_Otros_Dev_DsctosBLL movBLL = new motivos_Otros_Dev_DsctosBLL();
            DataTable dt = movBLL.obtenerMotivosOtrosDevDsctosBLL();
            if (dt.Rows.Count > 0)
            {
                cboMotivo.DataSource = dt;
                cboMotivo.ValueMember = "COD_MOTIVO_OT_DEV";
                cboMotivo.DisplayMember = "DESC_MOTIVO_OT_DEV";
                cboMotivo.SelectedIndex = -1;
            }
        }

        private void CargarTipoPlanilla()
        {
            tipoPlanillaCreacionBLL tpcBLL = new tipoPlanillaCreacionBLL();
            dtTipPlla = tpcBLL.obtenerTipoPlanillaCreacionxTransferenciaBLL().Select("COD_TIPO_PLLA IN ('DX','DE','DI')").CopyToDataTable();
            if (dtTipPlla.Rows.Count > 0)
            {
                cbo_tipo_planilla.ValueMember = "COD_TIPO_PLLA";
                cbo_tipo_planilla.DisplayMember = "DESC_TIPO";
                cbo_tipo_planilla.DataSource = dtTipPlla;
                cbo_tipo_planilla.SelectedIndex = -1;
            }
        }

        private void ListarReembolsos()
        {
            try
            {
                DataTable dt = BLCheque.ObtenerReembolsosXIdSeguimiento(idSeguimiento);
                int indexRow;
                dgvReembolsos.Rows.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    indexRow = dgvReembolsos.Rows.Add();
                    DataGridViewRow rw = dgvReembolsos.Rows[indexRow];
                    rw.Cells["TAG"].Value = "*";
                    rw.Cells["#"].Value = ++indexRow;
                    rw.Cells["NRO_PLANILLA_DOC"].Value = row["NRO_PLANILLA_DOC"];
                    rw.Cells["FE_AÑO"].Value = row["FE_AÑO"];
                    rw.Cells["FE_MES"].Value = row["FE_MES"];
                    rw.Cells["PERIODO"].Value = row["FE_MES"].ToString() + " - " + row["FE_AÑO"].ToString();
                    rw.Cells["FECHA_REGISTRO"].Value = Convert.ToDateTime(row["FECHA_CREA"]).ToShortDateString();
                    rw.Cells["IMPORTE"].Value = row["IMPORTE_REEMBOLSO"];
                    rw.Cells["STATUS_APROBADO"].Value = Convert.ToDecimal(row["STATUS_CIERRE"]);
                }

                ObtenerTotalesReembolso();
            }
            catch (Exception ex)
            {
                PrintStackTrace(ex);
            }
        }

        private void FormatdgvReembolsos()
        {
            dgvReembolsos.FormatColumnasFecha("FECHA_REGISTRO");
            dgvReembolsos.AlignmentTextContent2("PERIODO", DataGridViewContentAlignment.MiddleCenter);
            dgvReembolsos.AlignmentTextContent2("FECHA_REGISTRO", DataGridViewContentAlignment.MiddleCenter);
        }

        private void ActualizarTotalRetencion()
        {
            decimal retencion = 0;
            foreach (DataGridViewRow row in dgvRetencion.Rows)
            {
                retencion += Convert.ToDecimal(row.Cells["IMP_RETENCION"].Value);
            }
            numRetencion.Value = retencion;
            numImpRetenido.Value = retencion;
        }

        private void ObtenerTotalImpPlanilla()
        {
            decimal impPlanilla = 0;
            foreach (DataGridViewRow row in dgvRetencion.Rows)
            {
                impPlanilla += Convert.ToDecimal(row.Cells["IMPORTE"].Value);
            }
            numImpPlla.Value = impPlanilla;
            numImpPlla.Value = impPlanilla;
        }

        private void NumRetencion_ValueChanged(object sender, EventArgs e)
        {
            decimal total = numNeto.Value - (numCobrado.Value + numAjuste.Value + numRetencion.Value);
            decimal total2 = numNeto.Value - (numCobrado.Value + numAjuste.Value + numRetencion.Value + numAplicRec.Value)
                + numReembolso.Value + numAplicEnv.Value;
            numSaldoXCobrar.Value = total > 0 ? total : 0;
            saldoFinal = total2;
            numSaldoFinal.Value = total2 >= 0 ? total2 : total2 * -1;
            numExceCobranza.Value = total < 0 ? total * -1 : 0;
        }

        private void TXT_COD_Leave(object sender, EventArgs e)
        {
            if (TXT_COD.Text.Trim() != "")
            {
                if (dgw_per.Rows.Count > 0)
                {
                    //dgw_per.Sort(dgw_per.Columns[0], System.ComponentModel.ListSortDirection.Ascending);
                    dgw_per.Sort(dgw_per.Columns["COD_PER1"], System.ComponentModel.ListSortDirection.Ascending);
                    int i = 0, num2 = dgw_per.Rows.Count - 1;
                    do
                    {
                        //if (TXT_COD.Text.ToLower() == dgw_per[0, i].Value.ToString().ToLower())
                        if (TXT_COD.Text.ToLower() == dgw_per.Rows[i].Cells["COD_PER1"].Value.ToString().ToLower())
                        {
                            TXT_COD.Text = dgw_per.Rows[i].Cells["COD_PER1"].Value.ToString();//dgw_per[0, i].Value.ToString();
                            TXT_DESC.Text = dgw_per.Rows[i].Cells["DESC_PER1"].Value.ToString();//dgw_per[1, i].Value.ToString();
                            txt_doc_per.Text = dgw_per.Rows[i].Cells["NRO_DOC1"].Value.ToString();//dgw_per[2, i].Value.ToString();
                            cbo_sucursal.SelectedValue = dgw_per.Rows[i].Cells["COD_SUCURSAL1"].Value;
                            cbo_institucion.SelectedValue = dgw_per.Rows[i].Cells["COD_INSTITUCION1"].Value;
                            cbo_canaldscto.SelectedValue = dgw_per.Rows[i].Cells["COD_CANAL_DSCTO1"].Value;
                            cbo_tipo_planilla.SelectedValue = dgw_per.Rows[i].Cells["TIPO_PLA_COBRANZA1"].Value;
                            //ingresoDetalle();
                            return;
                        }
                        //f (TXT_COD.Text.ToLower() == dgw_per[0, i].Value.ToString().ToLower().Substring(0, TXT_COD.TextLength))
                        if (TXT_COD.Text.ToLower() == dgw_per.Rows[i].Cells["COD_PER1"].Value.ToString().ToLower().Substring(0, TXT_COD.TextLength))
                        {
                            dgw_per.CurrentCell = dgw_per.Rows[i].Cells["COD_PER1"];//dgw_per.Rows[i].Cells[0];
                            break;
                        }
                        dgw_per.CurrentCell = dgw_per.Rows[0].Cells["COD_PER1"];//dgw_per.Rows[0].Cells[0];
                        i += 1;
                    }
                    while (i <= num2);
                    Panel_PER.BringToFront();
                    Panel_PER.Visible = true;
                    dgw_per.Visible = true;
                    dgw_per.Focus();
                }
            }
        }

        private void TXT_DESC_Leave(object sender, EventArgs e)
        {
            if (dgw_per.Rows.Count > 0)
            {
                //dgw_per.Sort(dgw_per.Columns[1], System.ComponentModel.ListSortDirection.Ascending);
                dgw_per.Sort(dgw_per.Columns["DESC_PER1"], System.ComponentModel.ListSortDirection.Ascending);
                int i = 0, num2 = dgw_per.Rows.Count;
                do
                {
                    //if (dgw_per[1, i].Value.ToString().Length >= TXT_DESC.TextLength)
                    if (dgw_per.Rows[i].Cells["DESC_PER1"].Value.ToString().Length >= TXT_DESC.TextLength)
                    {
                        if (TXT_DESC.Text.ToLower() == dgw_per.Rows[i].Cells["DESC_PER1"].Value.ToString().ToLower().Substring(0, TXT_DESC.TextLength).ToLower())//dgw_per[1, i].Value.ToString().ToLower().Substring(0, TXT_DESC.TextLength).ToLower())
                        {
                            dgw_per.CurrentCell = dgw_per.Rows[i].Cells["COD_PER1"];//dgw_per.Rows[i].Cells[0];
                            break;
                        }
                    }
                    dgw_per.CurrentCell = dgw_per.Rows[0].Cells["COD_PER1"];//dgw_per.Rows[0].Cells[0];
                    i += 1;
                }
                while (i < num2);
                Panel_PER.Visible = true;
                dgw_per.Visible = true;
                dgw_per.Focus();
            }
        }

        private void DgvRetencion_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete)
                {
                    if (MessageBox.Show("¿Esta seguro de eliminar esta retención?", "MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        if (dgvRetencion.CurrentCell != null)
                        {
                            if (dgvRetencion.CurrentRow.Cells["TAG"].Value.ToString() == REGISTROS_GRABADOS)
                            {
                                if (Convert.ToBoolean(dgvRetencion.CurrentRow.Cells["STATUS_APROBADO"].Value))
                                {
                                    _ = MessageBox.Show("Esta planilla esta aprobado, no se puede eliminar ni modificar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                                lstPlanillasEliminadas = lstPlanillasEliminadas ?? new List<planillaCabeceraOtrasDevDsctosTo>();
                                planillaCabeceraOtrasDevDsctosTo plcTo = new planillaCabeceraOtrasDevDsctosTo
                                {
                                    NRO_PLANILLA_DOC = dgvRetencion.CurrentRow.Cells["NRO_PLANILLA_DOC"].Value.ToString(),
                                    COD_INSTITUCION = dgvRetencion.CurrentRow.Cells["COD_INSTITUCION"].Value.ToString(),
                                    COD_CANAL_DSCTO = dgvRetencion.CurrentRow.Cells["COD_CANAL_DSCTO"].Value.ToString(),
                                    FE_AÑO = dgvRetencion.CurrentRow.Cells["FE_AÑO"].Value.ToString(),
                                    FE_MES = dgvRetencion.CurrentRow.Cells["FE_MES"].Value.ToString(),
                                    TIPO_PLANILLA_DOC = dgvRetencion.CurrentRow.Cells["TIPO_PLANILLA_DOC"].Value.ToString(),
                                    COD_SUCURSAL = Convert.ToString(dgvRetencion.CurrentRow.Cells["COD_SUCURSAL"].Value),
                                    COD_CLASE = "01",
                                    NRO_CONTRATO = Convert.ToString(dgvRetencion.CurrentRow.Cells["NRO_CONTRATO"].Value),
                                };
                                lstPlanillasEliminadas.Add(plcTo);

                                if (dtRetencionEliminados is null)
                                {
                                    dtRetencionEliminados = new DataTable();
                                    _ = dtRetencionEliminados.Columns.Add("ID_RETENCION", typeof(int));
                                    _ = dtRetencionEliminados.Columns.Add("ID_SEGUIMIENTO", typeof(int));
                                    _ = dtRetencionEliminados.Columns.Add("FE_AÑO_REF", typeof(string));
                                    _ = dtRetencionEliminados.Columns.Add("FE_MES_REF", typeof(string));
                                    _ = dtRetencionEliminados.Columns.Add("IMP_RETENCION", typeof(decimal));
                                    _ = dtRetencionEliminados.Columns.Add("NRO_PLANILLA_COB", typeof(string));
                                    _ = dtRetencionEliminados.Columns.Add("COD_SUCURSAL", typeof(string));
                                    _ = dtRetencionEliminados.Columns.Add("COD_CLASE", typeof(string));
                                    _ = dtRetencionEliminados.Columns.Add("NRO_CONTRATO", typeof(string));
                                    _ = dtRetencionEliminados.Columns.Add("TIPO_PLANILLA", typeof(string));
                                }

                                DataRow row = dtRetencionEliminados.NewRow();
                                row["ID_RETENCION"] = dgvRetencion.CurrentRow.Cells["ID_RETENCION"].Value;
                                row["ID_SEGUIMIENTO"] = dgvRetencion.CurrentRow.Cells["ID_SEGUIMIENTO"].Value;
                                row["FE_AÑO_REF"] = dgvRetencion.CurrentRow.Cells["FE_AÑO_REF"].Value;
                                row["FE_MES_REF"] = dgvRetencion.CurrentRow.Cells["FE_MES_REF"].Value;
                                row["IMP_RETENCION"] = dgvRetencion.CurrentRow.Cells["IMP_RETENCION"].Value;
                                row["NRO_PLANILLA_COB"] = dgvRetencion.CurrentRow.Cells["NRO_PLANILLA_COB"].Value;
                                row["COD_SUCURSAL"] = dgvRetencion.CurrentRow.Cells["COD_SUCURSAL"].Value;
                                row["COD_CLASE"] = "01";
                                row["NRO_CONTRATO"] = dgvRetencion.CurrentRow.Cells["NRO_CONTRATO"].Value;
                                row["TIPO_PLANILLA"] = dgvRetencion.CurrentRow.Cells["TIPO_PLANILLA_DOC"].Value;
                                dtRetencionEliminados.Rows.Add(row);
                            }
                            else if (dgvRetencion.CurrentRow.Cells["TAG"].Value.ToString() == REGISTROS_NUEVOS) //> - => registros nuevos
                            {
                                int rowCount = dgvRetencion.Rows.Cast<DataGridViewRow>().Where(x => x.Cells["TAG"].Value.ToString() == "*").Count();
                                lstPlanillaCabecera.RemoveAt(dgvRetencion.CurrentCell.RowIndex - rowCount);
                                EliminarListasTipoPlanillaRetencionNuevos();
                            }

                            dgvRetencion.Rows.RemoveAt(dgvRetencion.CurrentCell.RowIndex);

                            ActualizarTotalRetencion();
                            ObtenerTotalImpPlanilla();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.PrintException();
            }
        }

        private void EliminarListasTipoPlanillaRetencionNuevos()
        {
            if (dgvRetencion.CurrentRow.Cells["TIPO_PLANILLA_DOC"].Value.ToString() == TIPO_PLLA_RETENCION)
            {
                int a = lstDevPctasCobrar.RemoveAll(x => x.NRO_PLANILLA_COB == dgvRetencion.CurrentRow.Cells["NRO_PLANILLA_COB"].Value.ToString()
                    && x.NRO_CONTRATO == dgvRetencion.CurrentRow.Cells["NRO_CONTRATO"].Value.ToString() && x.TIPO_PLA_COBRANZA == dgvRetencion.CurrentRow.Cells["TIPO_PLANILLA_DOC"].Value.ToString());
                int a2 = lstDevTctasCobrar.RemoveAll(x => x.NRO_PLANILLA_COB == dgvRetencion.CurrentRow.Cells["NRO_PLANILLA_COB"].Value.ToString()
                    && x.NRO_CONTRATO == dgvRetencion.CurrentRow.Cells["NRO_CONTRATO"].Value.ToString() && x.TIPO_PLA_COBRANZA == dgvRetencion.CurrentRow.Cells["TIPO_PLANILLA_DOC"].Value.ToString());
                if (a > 1 || a2 > 1)
                {
                    _ = MessageBox.Show("Error al eliminar la fila seleccionada, filas eliminadas mas de 1", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Close();
                }
            }
        }

        private void DgvRetencion_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgvRetencion.CurrentCell != null)
            {
                if (dgvRetencion.Columns[e.ColumnIndex].Name == "IMP_RETENCION")
                {
                    if (!decimal.TryParse(dgvRetencion["IMP_RETENCION", e.RowIndex].Value.ToString(), out decimal _))
                    {
                        _ = MessageBox.Show("Debe digitar solo valores numericos o decimales", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        e.Cancel = true;
                    }
                }
            }
        }

        private void DgvRetencion_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (!decimal.TryParse(dgvRetencion["IMP_RETENCION", e.RowIndex].Value.ToString(), out decimal _))
            {
                _ = MessageBox.Show("Debe digitar solo valores numericos o decimales", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
        }

        private void Dgw_det_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (dgw_det.Rows.Count == 0 && !acc)
            {
                foreach (TextBox text in gb_oc.Controls.OfType<TextBox>().ToList())
                {
                    text.Clear();
                }
                cboMotivo.SelectedIndex = -1;
                cbo_canaldscto.SelectedIndex = -1;
                cbo_institucion.SelectedIndex = -1;
                cbo_sucursal.SelectedIndex = -1;
            }
        }

        private void Cbo_sucursal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_sucursal.SelectedValue != null)
            {
                if (cbo_tipo_planilla.SelectedValue != null)
                    ObtieneNroPlla();
            }
        }

        private void TXT_COD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && !Panel_PER.Visible)
            {
                ListarClientes();
                Panel_PER.Visible = true;
                dgw_per.Focus();
            }
        }

        private void Cbo_tipo_planilla_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_tipo_planilla.SelectedValue != null)
            {
                if (chk_op.Checked == false)
                {
                    if (cbo_sucursal.SelectedValue != null)
                    {
                        ObtieneNroPlla();
                        lbl_cod_tipo_plla.Text = cbo_tipo_planilla.SelectedValue.ToString();
                    }
                }
                else
                {
                    if (cbo_tipo_planilla.SelectedValue.ToString() == "DX" || cbo_tipo_planilla.SelectedValue.ToString() == "PA")
                    {
                        if (cbo_sucursal.SelectedValue != null)
                        {
                            ObtieneNroPlla();
                            lbl_cod_tipo_plla.Text = cbo_tipo_planilla.SelectedValue.ToString();
                        }
                    }
                    else if (cbo_tipo_planilla.SelectedValue.ToString() == "DS" || cbo_tipo_planilla.SelectedValue.ToString() == "PS")
                    {
                        if (cbo_sucursal.SelectedValue != null)
                        {
                            ObtieneNroPlla();
                            lbl_cod_tipo_plla.Text = cbo_tipo_planilla.SelectedValue.ToString();
                        }
                    }
                    else
                    {
                        cbo_tipo_planilla.SelectedValue = lbl_cod_tipo_plla.Text;
                    }
                    chk_op.Checked = false;
                }
            }
        }

        private void DgvRetencion_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dgvRetencion.Columns[e.ColumnIndex].Name == "IMP_RETENCION")
            {
                if (Convert.ToBoolean(dgvRetencion.CurrentRow.Cells["STATUS_APROBADO"].Value))
                {
                    _ = MessageBox.Show("Esta planilla esta aprobado, no se puede eliminar ni modificar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                }
            }
        }

        private void DgvRetencion_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvRetencion.Columns[e.ColumnIndex].Name == "IMP_RETENCION")
                {
                    ActualizarTotalRetencion();
                    if (saldoFinal < 0)
                    {
                        dgvRetencion[e.ColumnIndex, e.RowIndex].Value = "0";
                        ActualizarTotalRetencion();
                        _ = MessageBox.Show("El importe ingresado es mayor al saldo", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (dgvRetencion.CurrentRow.Cells["TIPO_PLANILLA_DOC"].Value.ToString() != TIPO_PLLA_RETENCION)
                    {
                        if (!ValidarImporteRetencionAplicado())
                        {
                            dgvRetencion[e.ColumnIndex, e.RowIndex].Value = dgvRetencion.CurrentRow.Cells["IMP_RETENCION_OLD"].Value;
                            _ = MessageBox.Show("El importe a retener debe ser menor o igual al saldo", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    else
                    {
                        ActualizarImptesRetencion();
                        if (dgvRetencion.CurrentRow.Cells["TAG"].Value.ToString() == REGISTROS_NUEVOS)
                        {
                            ActualizarImportesLstDvPctasCobrar();
                            ActualizarImportesLstDvTctasCobrar();
                        }
                    }
                }

                ActualizarTotalRetencion();
            }
            catch (Exception ex)
            {
                ex.PrintException();
            }

            void ActualizarImportesLstDvPctasCobrar()
            {
                if (lstDevPctasCobrar is null || lstDevPctasCobrar.Count == 0)
                {
                    _ = MessageBox.Show("Error al actualizar los importes, no existe datos en listado", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                foreach (devPCtasCobrarTo item in lstDevPctasCobrar)
                {
                    if (item.NRO_PLANILLA_COB == dgvRetencion.CurrentRow.Cells["NRO_PLANILLA_COB"].Value.ToString() && item.NRO_CONTRATO == dgvRetencion.CurrentRow.Cells["NRO_CONTRATO"].Value.ToString()
                        && item.TIPO_PLA_COBRANZA == dgvRetencion.CurrentRow.Cells["TIPO_PLANILLA_DOC"].Value.ToString())
                    {
                        item.IMP_INI = Convert.ToDecimal(dgvRetencion[e.ColumnIndex, e.RowIndex].Value);
                        item.IMP_DOC = Convert.ToDecimal(dgvRetencion[e.ColumnIndex, e.RowIndex].Value);
                    }
                }
            }

            void ActualizarImportesLstDvTctasCobrar()
            {
                if (lstDevTctasCobrar is null || lstDevTctasCobrar.Count == 0)
                {
                    _ = MessageBox.Show("Error al actualizar los importes, no existe datos en listado", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                foreach (devTCtasCobrarTo item in lstDevTctasCobrar)
                {
                    if (item.NRO_PLANILLA_COB == dgvRetencion.CurrentRow.Cells["NRO_PLANILLA_COB"].Value.ToString() && item.NRO_CONTRATO == dgvRetencion.CurrentRow.Cells["NRO_CONTRATO"].Value.ToString()
                        && item.TIPO_PLA_COBRANZA == dgvRetencion.CurrentRow.Cells["TIPO_PLANILLA_DOC"].Value.ToString())
                    {
                        item.IMP_DOC = Convert.ToDecimal(dgvRetencion[e.ColumnIndex, e.RowIndex].Value);
                    }
                }
            }

            void ActualizarImptesRetencion()
            {
                dgvRetencion.CurrentRow.Cells["IMP_DOC"].Value = Convert.ToDecimal(dgvRetencion[e.ColumnIndex, e.RowIndex].Value);
                dgvRetencion.CurrentRow.Cells["IMP_DEV"].Value = Convert.ToDecimal(dgvRetencion[e.ColumnIndex, e.RowIndex].Value);
                dgvRetencion.CurrentRow.Cells["IMPORTE"].Value = Convert.ToDecimal(dgvRetencion[e.ColumnIndex, e.RowIndex].Value);
            }
        }

        private bool ValidarImporteRetencionAplicado()
        {
            decimal importeDoc = Convert.ToDecimal(dgvRetencion.CurrentRow.Cells["SALDO"].Value);
            decimal importeOld = Convert.ToDecimal(dgvRetencion.CurrentRow.Cells["IMP_RETENCION_OLD"].Value);
            decimal importeNew = Convert.ToDecimal(dgvRetencion.CurrentRow.Cells["IMP_RETENCION"].Value);
            decimal saldo = 0;
            return ValidarImporteAplicarSaldo(importeDoc, importeOld, importeNew, ref saldo);
        }

        private void ObtieneNroPlla()
        {
            if (btnRegistrarCobranza.Visible)
            {
                tdiTo.TIPO_DOC = cbo_tipo_planilla.SelectedValue.ToString();
                COD_DOC = tdiBLL.obtieneCodDocInvxTipoDocBLL(tdiTo);
                DataTable dt = HelpersBLL.obtieneNroPlanilla(cbo_sucursal.SelectedValue.ToString(), "0", COD_DOC);
                txt_ser.Text = dt.Rows[0]["SERIE"].ToString();
                txt_num.Text = dt.Rows[0]["NUMERO"].ToString();
            }
        }

        private void Txt_doc_per_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ListarClientes();
                if (txt_doc_per.Text.Trim() == "")
                {
                    Panel_PER.Visible = false;
                }//Gestion Comercial/compras/servicio/requiriento de servicio
                else if (dgw_per.Rows.Count > 0)
                {
                    DataRow[] rs = dtClientes.Select("NRO_DOC = '" + txt_doc_per.Text.Trim() + "'");
                    if (rs.Length > 0)
                    {
                        //dgw_per.Sort(dgw_per.Columns[2], System.ComponentModel.ListSortDirection.Ascending);
                        dgw_per.Sort(dgw_per.Columns["NRO_DOC1"], System.ComponentModel.ListSortDirection.Ascending);
                        int i = 0, num2 = dgw_per.Rows.Count;
                        do
                        {
                            //if (dgw_per[2, i].Value.ToString().Length >= txt_doc_per.TextLength)
                            if (dgw_per.Rows[i].Cells["NRO_DOC1"].Value.ToString().Length >= txt_doc_per.TextLength)
                            {
                                //if (txt_doc_per.Text.ToLower() == dgw_per[2, i].Value.ToString().ToLower().Substring(0, txt_doc_per.TextLength).ToLower())
                                if (txt_doc_per.Text.ToLower() == dgw_per.Rows[i].Cells["NRO_DOC1"].Value.ToString().ToLower().Substring(0, txt_doc_per.TextLength).ToLower())
                                {
                                    dgw_per.CurrentCell = dgw_per.Rows[i].Cells["COD_PER1"];//dgw_per.Rows[i].Cells[0];
                                    break;
                                }
                            }
                            dgw_per.CurrentCell = dgw_per.Rows[0].Cells["COD_PER1"];//dgw_per.Rows[0].Cells[0];
                            i += 1;
                        }
                        while (i < num2);
                        Panel_PER.Visible = true;
                        dgw_per.Visible = true;
                        dgw_per.Focus();
                    }
                    else
                    {
                        Panel_PER.Visible = false;
                    }
                }
            }
        }

        private void Chk_op_CheckedChanged(object sender, EventArgs e)
        {
            cbo_tipo_planilla.Enabled = chk_op.Checked;
        }

        private void Dgw_per_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (dgw_per.CurrentCell != null)
                    {
                        if (Convert.ToInt32(dgw_per.CurrentRow.Cells["FE_AÑO1"].Value) > Convert.ToInt32(SeguimientoCheques.AÑO)
                            || (Convert.ToInt32(dgw_per.CurrentRow.Cells["FE_AÑO1"].Value) == Convert.ToInt32(SeguimientoCheques.AÑO)
                            && Convert.ToInt32(dgw_per.CurrentRow.Cells["FE_MES1"].Value) > Convert.ToInt32(SeguimientoCheques.MES)))
                        {
                            _ = MessageBox.Show("No se puede registrar planillas con periodo posterior al periodo actual", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        int i = dgw_per.CurrentRow.Index;
                        TXT_COD.Text = dgw_per.Rows[i].Cells["COD_PER1"].Value.ToString();//dgw_per[0, i].Value.ToString();
                        TXT_DESC.Text = dgw_per.Rows[i].Cells["DESC_PER1"].Value.ToString();//dgw_per[1, i].Value.ToString();
                        txt_doc_per.Text = dgw_per.Rows[i].Cells["NRO_DOC1"].Value.ToString();//dgw_per[2, i].Value.ToString();
                        cbo_sucursal.SelectedValue = dgw_per.Rows[i].Cells["COD_SUCURSAL1"].Value;
                        cbo_institucion.SelectedValue = dgw_per.Rows[i].Cells["COD_INSTITUCION1"].Value.ToString() == "" ? "01" : dgw_per.Rows[i].Cells["COD_INSTITUCION1"].Value;
                        cbo_canaldscto.SelectedValue = dgw_per.Rows[i].Cells["COD_CANAL_DSCTO1"].Value.ToString() == "" ? "1404" : dgw_per.Rows[i].Cells["COD_CANAL_DSCTO1"].Value;
                        cbo_tipo_planilla.SelectedValue = dgw_per.Rows[i].Cells["TIPO_PLA_COBRANZA1"].Value.ToString() == "PA" ? "DX" : dgw_per.Rows[i].Cells["TIPO_PLA_COBRANZA1"].Value;
                        tipoPlanillaCobranza = dgw_per.Rows[i].Cells["TIPO_PLA_COBRANZA1"].Value.ToString();
                        txt_tot_pagado.Text = Convert.ToDecimal(dgw_per.Rows[i].Cells["IMP_DOC1"].Value).ToString("###,###,##0.00");
                        lbl_cod_tipo_plla.Text = cbo_tipo_planilla.SelectedValue?.ToString();
                        txt_nro_contrato.Text = dgw_per.Rows[i].Cells["NRO_PRESUPUESTO1"].Value.ToString();
                        cboMotivo.SelectedValue = Convert.ToString(dgw_per.Rows[i].Cells["COD_MOTIVO_NO_DESCONTADO1"].Value);
                        cuota_comprometida = dgw_per.Rows[i].Cells["CUOTA_COMPROMETIDA1"].Value.ToString() == "1";
                        COD_UBICACION = Convert.ToString(dgw_per.Rows[i].Cells["COD_UBICACION1"].Value);
                        ctcTo.NRO_CONTRATO = txt_nro_contrato.Text;
                        string errMensaje = "";
                        monto_pagado = ctcBLL.obtenerMontoPagadoxContratoBLL(ctcTo, ref errMensaje);//monto que se ha pagado hasta el momento
                        monto_total = Convert.ToDecimal(dgw_per.CurrentRow.Cells["TOTAL_CONTRATO"].Value);//monto del contrato
                        monto_total_a_pagar = monto_total - monto_pagado;
                        IngresoDetalle();
                        Panel_PER.Visible = false;
                        gb_oc.Focus();
                        txt_doc_per.Focus();
                    }
                }
                else if (e.KeyCode == Keys.Escape)
                {
                    Panel_PER.Visible = false;
                    TXT_COD.Clear();
                    TXT_DESC.Clear();
                    txt_doc_per.Clear();
                    txt_nro_contrato.Clear();
                    txt_tot_pagado.Clear();
                    TXT_COD.Focus();
                    dgw_det.Rows.Clear();
                }
            }
            catch (Exception ex)
            {
                ex.PrintException();
            }
        }

        private void IngresoDetalle()
        {
            acc = true;
            dgw_det.Rows.Clear();
            //solo tiene un registro
            int rowId = dgw_det.Rows.Add();
            DataGridViewRow row = dgw_det.Rows[rowId];
            row.Cells["NRO_PLANILLA_DOC"].Value = txt_ser.Text + "-" + txt_num.Text;
            row.Cells["COD_PTO_COB2"].Value = dgw_per.CurrentRow.Cells["COD_PTO_COB"].Value;
            row.Cells["COD_INSTITUCION"].Value = cbo_institucion.SelectedValue.ToString();
            row.Cells["COD_CANAL_DSCTO"].Value = cbo_canaldscto.SelectedValue.ToString();
            row.Cells["FE_AÑO"].Value = SeguimientoCheques.AÑO ?? throw new ArgumentNullException();
            row.Cells["FE_MES"].Value = SeguimientoCheques.MES ?? throw new ArgumentNullException();
            row.Cells["NRO_PLANILLA_COB"].Value = dgw_per.CurrentRow.Cells["NRO_PLANILLA_COB1"].Value.ToString();
            row.Cells["IMP_DOC"].Value = txt_tot_pagado.Text;
            row.Cells["MOTIVO_OTRAS_DEV_DSCTOS"].Value = dgw_per.CurrentRow.Cells["COD_MOTIVO_NO_DESCONTADO1"].Value.ToString();
            row.Cells["DESC_MOTIVO_OT_DEV"].Value = dgw_per.CurrentRow.Cells["DESC_MOTIVO_OT_DEV1"].Value.ToString();
            row.Cells["NRO_LETRA"].Value = dgw_per.CurrentRow.Cells["NRO_LETRA1"].Value.ToString();
            row.Cells["IMP_DEV"].Value = 0;
            row.Cells["IMP_INI2"].Value = dgw_per.CurrentRow.Cells["IMP_INI"].Value;
            row.Cells["PERIODO2"].Value = dgw_per.CurrentRow.Cells["PERIODO"].Value;
            row.Cells["FE_AÑO_REF"].Value = dgw_per.CurrentRow.Cells["FE_AÑO1"].Value;
            row.Cells["FE_MES_REF"].Value = dgw_per.CurrentRow.Cells["FE_MES1"].Value;
            row.Cells["SALDO2"].Value = Convert.ToDecimal(dgw_per.CurrentRow.Cells["IMP_INI"].Value) - BLCheque.ObtenerTotalRetencion
                (
                    row.Cells["NRO_PLANILLA_COB"].Value.ToString(),
                    row.Cells["COD_INSTITUCION"].Value.ToString(),
                    row.Cells["COD_CANAL_DSCTO"].Value.ToString(),
                    dgw_per.CurrentRow.Cells["COD_SUCURSAL1"].Value.ToString(),
                    TXT_COD.Text,
                    txt_nro_contrato.Text
                );
            row.Cells["IMPORTE_APROBADO"].Value = dgw_per.CurrentRow.Cells["Imp_Aprob"].Value;
            row.Cells["IMPORTE_X_APROBAR"].Value = dgw_per.CurrentRow.Cells["Imp_X_Aprob"].Value;
            //BLCheque.ObtenerTotalRetencion
            //(
            //    row.Cells["NRO_PLANILLA_COB"].Value.ToString(),
            //    row.Cells["COD_INSTITUCION"].Value.ToString(),
            //    row.Cells["COD_CANAL_DSCTO"].Value.ToString(),
            //    dgw_per.CurrentRow.Cells["COD_SUCURSAL1"].Value.ToString(),
            //    TXT_COD.Text,
            //    txt_nro_contrato.Text
            //);
            //
            if (Convert.ToDecimal(txt_tot_pagado.Text) > monto_total_a_pagar) //DEV EXCESO CONTRATO
            {
                row.Cells["IMP_DEV"].Value = Convert.ToDecimal(txt_tot_pagado.Text) - monto_total_a_pagar;// esto es lo que va para DEV EXCESO CONTRATO
            }
            acc = false;
        }

        private void BtnFinalizarCobranza_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            try
            {
                if (ValidarImporteAplicado() && ValidarRetenciones() && ValidarReembolsos())
                {
                    if (btn.Name == btnRegistrarCobranza.Name)
                    {
                        FinalizarCobranza(btn);
                        ObtenerAplicaciones();
                    }
                    else if (btn.Name == btnFinalizarCobranza.Name)
                    {
                        if (ValidarCerrarCobranza())
                        {
                            BackEstadoSeguimiento frmCerrar = new BackEstadoSeguimiento
                            {
                                StartPosition = FormStartPosition.CenterScreen
                            };
                            frmCerrar.EveClick += CerrarCobranza;
                            _ = frmCerrar.ShowDialog();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LimpiarGrabar();
                PrintStackTrace(ex);
            }
        }

        private void FinalizarCobranza(Button btn)
        {
            bool eSCierre = btn.Name == btnFinalizarCobranza.Name;
            string message = eSCierre ? "¿Esta seguro que desea finalizar la cobranza de esta planilla?" : "¿Esta seguro que desea registrar?";
            DialogResult dr = MessageBox.Show(message, "MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                string errMessage = string.Empty;
                decimal saldoXCobrar = saldoFinal < 0 ? 0 : saldoFinal;
                decimal importeExeceso = numExceCobranza.Value;
                DataTable dtRetencion = ObtenerDatosRetencion();
                dtAplicacionesEliminar = null;
                _ = BLCheque.InsertarPlanillasOtrasDevDsctosBLL(idSeguimiento, COD_USUARIO, numReembolso.Value, numRetencion.Value, numAjuste.Value,
                    numCobrado.Value, saldoXCobrar, importeExeceso, eSCierre, lstPlanillaCabecera, lstDevPctasCobrar, lstDevTctasCobrar, dtRetencion, 
                    dtRetencionEliminados, lstPlanillasEliminadas, dtAplicacionesEliminar, ObtenerReembolso(),
                    ObtenerListaReembolsosCab(), lstEliminarReembolsos, ref errMessage)
                    ? MessageBox.Show("Registrado Correctamente", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    : MessageBox.Show("Ocurrió un error inesperado \n " + errMessage, "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LimpiarGrabar();
                ListarReembolsos();
                LimpiarControlesRetencionSinPrePlanilla();
                if (btn.Name == btnFinalizarCobranza.Name)
                    Close();
                else
                    MostrarDatos();
            }
        }

        private void CerrarCobranza()
        {
            FinalizarCobranza(btnFinalizarCobranza);
            EsCerrar = true;
        }

        private void BtnNuevo1_Click(object sender, EventArgs e)
        {
            if (saldoFinal > 0)
            {
                tabControl1.SelectedTab = tabPage1;
                panel1.Visible = false;
                groupBox2.Location = new Point { X = 270, Y = 10 };
                Panel_PER.Location = new Point { X = 373, Y = 58 };
                groupBox2.Controls.Add(dgvRetencion);
                dgvRetencion.Location = new Point { X = 6, Y = 300 };
                groupBox2.Visible = true;
            }
            else
                _ = MessageBox.Show("Esta planilla no necesita nunguna retención", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void BtnNuevo2_Click(object sender, EventArgs e)
        {

        }

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            gbRetenciones.Controls.Add(dgvRetencion);
            dgvRetencion.Location = new Point { X = 10, Y = 16 };
            groupBox2.Visible = false;
            Panel_PER.Visible = false;
            LimpiarControlesRetencionSinPrePlanilla();
        }

        private void DgvAplicaciones_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvAplicaciones.Columns[e.ColumnIndex].Name == "IMPORTE_APLICADO")
            {
                if (!decimal.TryParse(dgvAplicaciones[e.ColumnIndex, e.RowIndex].Value.ToString(), out decimal _))
                {
                    dgvAplicaciones[e.ColumnIndex, e.RowIndex].Value = 0;
                    _ = MessageBox.Show("Debe digitar solo valores numericos o decimales", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (numSaldoXCobrar.Value == 0)
                {
                    ObtenerTotalesAplicacion();
                    if (saldoFinal > 0)
                    {
                        dgvAplicaciones[e.ColumnIndex, e.RowIndex].Value = dgvAplicaciones["IMPORTE_APLICADO_OLD", e.RowIndex].Value;
                        _ = MessageBox.Show("El importe ingresado es mayor al saldo", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (!ValidarImporteAplicar())
                    {
                        dgvAplicaciones[e.ColumnIndex, e.RowIndex].Value = dgvAplicaciones["IMPORTE_APLICADO_OLD", e.RowIndex].Value;
                        _ = MessageBox.Show("El importe ingresado es mayor al saldo", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    if (!ValidarImporteAplicar())
                    {
                        dgvAplicaciones[e.ColumnIndex, e.RowIndex].Value = dgvAplicaciones["IMPORTE_APLICADO_OLD", e.RowIndex].Value;
                        _ = MessageBox.Show("El importe ingresado es mayor al saldo", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                ObtenerTotalesAplicacion();
            }
        }

        private bool ValidarImporteAplicar()
        {
            decimal importeDoc = Convert.ToDecimal(dgvAplicaciones.CurrentRow.Cells["SALDO"].Value);
            decimal importeOld = Convert.ToDecimal(dgvAplicaciones.CurrentRow.Cells["IMPORTE_APLICADO_OLD"].Value);
            decimal importeNew = Convert.ToDecimal(dgvAplicaciones.CurrentRow.Cells["IMPORTE_APLICADO"].Value);
            decimal saldo = 0;
            return ValidarImporteAplicarSaldo(importeDoc, importeOld, importeNew, ref saldo);
        }

        private void DgvAplicaciones_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (MessageBox.Show("¿Esta seguro de eliminar esta aplicación?", "MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (dgvAplicaciones.CurrentCell != null)
                    {
                        if (dgvAplicaciones.CurrentRow.Cells["TAG"].Value?.ToString() == REGISTROS_GRABADOS)
                        {
                            if (dtAplicacionesEliminar is null)
                            {
                                dtAplicacionesEliminar = new DataTable();
                                dtAplicacionesEliminar.Columns.Add("ID_SEGUIMIENTO", typeof(int));
                                dtAplicacionesEliminar.Columns.Add("ID_SEGUIMIENTO_APL", typeof(int));
                                dtAplicacionesEliminar.Columns.Add("ID_SEGUIMIENTO_SEL", typeof(int));
                            }

                            _ = dtAplicacionesEliminar.Rows.Add
                                (
                                    idSeguimiento,
                                    dgvAplicaciones.CurrentRow.Cells["ID_SEGUIMIENTO_APL"].Value,
                                    dgvAplicaciones.CurrentRow.Cells["ID_SEGUIMIENTO_SEL"].Value
                                );
                        }
                        dgvAplicaciones.Rows.RemoveAt(dgvAplicaciones.CurrentRow.Index);
                    }
                }
            }
        }

        private void ObtenerTotalesAplicacion()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dgvAplicaciones.Rows)
            {
                total += Convert.ToDecimal(row.Cells["IMPORTE_APLICADO"].Value);
            }

            lblTotalImporteAplicado.Text = "Total Importe Aplicar : " + total.ToString();
            if (numExceCobranza.Value > 0)
                numAplicEnv.Value = total;
            else
                numAplicRec.Value = total;
        }

        private void FrmPlanillas_EventPasarData(DataTable dt, Tipo_APL_SALDO tipo_APL_SALDO)
        {
            AgregarPlanillasAplicadas(dt, tipo_APL_SALDO);
        }

        private void AgregarPlanillasAplicadas(DataTable dt, Tipo_APL_SALDO tipo_APL_SALDO)
        {
            dtPlanillasAplicados = dtPlanillasAplicados ?? new DataTable();
            dtPlanillasAplicados.Rows.Clear();
            if (dtPlanillasAplicados.Columns.Count == 0)
            {
                _ = dt.Columns.Add("ID_SEGUIMIENTO_APL", typeof(int));
                _ = dt.Columns.Add("IMPORTE_APL", typeof(decimal));
                _ = dt.Columns.Add("USUARIO_CREA", typeof(string));

                foreach (DataColumn column in dt.Columns)
                {
                    _ = dtPlanillasAplicados.Columns.Add(column.ColumnName, column.DataType);
                }
            }

            foreach (DataRow row in dt.Rows)
            {
                if (tipo_APL_SALDO == Tipo_APL_SALDO.Planilla_Imp_x_cobrar)
                    AgregarFilas(row);
                else if (tipo_APL_SALDO == Tipo_APL_SALDO.Planilla_Imp_Exceso)
                {
                    AgregarFilas2(row);
                    ObtenerTotalesAplicacion();
                }
            }

            void AgregarFilas(DataRow row)
            {
                int indexRow = dgvAplicaciones.Rows.Add();
                DataGridViewRow rw = dgvAplicaciones.Rows[indexRow];
                rw.Cells["TAG"].Value = REGISTROS_NUEVOS;
                rw.Cells["NRO_DOCUMENTO"].Value = "";
                rw.Cells["FE_AÑO"].Value = SeguimientoCheques.AÑO ?? throw new ArgumentNullException("NULL SeguimientoCheques.AÑO");
                rw.Cells["FE_MES"].Value = SeguimientoCheques.MES ?? throw new ArgumentNullException("NULL SeguimientoCheques.MES");
                rw.Cells["TIPO_DOC"].Value = TIPO_DOC_APLICACION;
                rw.Cells["ID_SEGUIMIENTO"].Value = row["ID_SEGUIMIENTO"];
                rw.Cells["ID_SEGUIMIENTO_APL"].Value = idSeguimiento;
                rw.Cells["ID_SEGUIMIENTO_SEL"].Value = row["ID_SEGUIMIENTO"];
                rw.Cells["NRO_PLANILLA"].Value = row["NRO_PLANILLA"];
                rw.Cells["PERIODO"].Value = row["PERIODO"];
                rw.Cells["FECHA_APLICADO"].Value = DateTime.Now;
                rw.Cells["SALDO_INICIAL"].Value = row["IMPORTE_EXC_INI"];
                rw.Cells["IMPORTE_APLICADO_OLD"].Value = "0.00";
                rw.Cells["IMPORTE_APLICADO"].Value = "0.00"; ///> row["IMPORTE_APLICADO"];
                rw.Cells["SALDO"].Value = row["IMPORTE_EXC_DOC"];
                rw.Cells["USUARIO_CREA"].Value = COD_USUARIO;
            }

            void AgregarFilas2(DataRow row)
            {
                int indexRow = dgvAplicaciones.Rows.Add();
                DataGridViewRow rw = dgvAplicaciones.Rows[indexRow];
                rw.Cells["TAG"].Value = REGISTROS_NUEVOS;
                rw.Cells["NRO_DOCUMENTO"].Value = "";
                rw.Cells["FE_AÑO"].Value = SeguimientoCheques.AÑO ?? throw new ArgumentNullException("NULL SeguimientoCheques.AÑO");
                rw.Cells["FE_MES"].Value = SeguimientoCheques.MES ?? throw new ArgumentNullException("NULL SeguimientoCheques.MES");
                rw.Cells["TIPO_DOC"].Value = TIPO_DOC_APLICACION;
                rw.Cells["ID_SEGUIMIENTO"].Value = row["ID_SEGUIMIENTO"];
                rw.Cells["ID_SEGUIMIENTO_APL"].Value = row["ID_SEGUIMIENTO"];
                rw.Cells["ID_SEGUIMIENTO_SEL"].Value = idSeguimiento;
                rw.Cells["NRO_PLANILLA"].Value = row["NRO_PLANILLA"];
                rw.Cells["PERIODO"].Value = row["PERIODO"];
                rw.Cells["FECHA_APLICADO"].Value = DateTime.Now;
                rw.Cells["IMPORTE_APLICADO_OLD"].Value = "0.00";
                rw.Cells["IMPORTE_APLICADO"].Value = row["IMPORTE_APLICAR"];
                rw.Cells["SALDO"].Value = row["SALDO_X_COBRAR"];
                rw.Cells["USUARIO_CREA"].Value = COD_USUARIO;
            }

            //decimal ObtenerImporte(DataRow row)
            //{
            //    return (saldoFinal * -1) >= Convert.ToDecimal(row["SALDO_X_COBRAR"]) ? Convert.ToDecimal(row["SALDO_X_COBRAR"]) : saldoFinal * -1;
            //}
        }

        private void DgvAplicaciones_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            ObtenerTotalesAplicacion();
        }

        private void BtnNuevo3_Click(object sender, EventArgs e)
        {
            if (saldoFinal < 0)
            {
                if (dgvReembolsos.Rows.Count < 2)
                {
                    int index = dgvReembolsos.Rows.Add();
                    dgvReembolsos.Rows[index].Cells["TAG"].Value = REGISTROS_NUEVOS;
                    dgvReembolsos.Rows[index].Cells["#"].Value = dgvReembolsos.Rows.Count == 0 ? 1 : dgvReembolsos.Rows.Count;
                    dgvReembolsos.Rows[index].Cells["IMPORTE"].Value = "0";
                    //> dgvReembolsos.Rows[index].Cells["FECHA_PLANILLA_DOC"].Value = DateTime.Now.ToShortDateString();
                }
                else
                    _ = MessageBox.Show("Solo se puede registrar un reebolso por planilla", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                _ = MessageBox.Show("No hay importe a reembolsar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void DgvReembolsos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvReembolsos.Columns[e.ColumnIndex].Name == "IMPORTE")
            {
                if (!decimal.TryParse(dgvReembolsos[e.ColumnIndex, e.RowIndex].Value.ToString(), out _))
                {
                    dgvReembolsos[e.ColumnIndex, e.RowIndex].Value = "0";
                    _ = MessageBox.Show("Debe ingresar valores enteros o decimales", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (Convert.ToDecimal(dgvReembolsos[e.ColumnIndex, e.RowIndex].Value) < 0)
                {
                    dgvReembolsos[e.ColumnIndex, e.RowIndex].Value = "0";
                    _ = MessageBox.Show("Debe ingresar valores enteros o decimales mayores a cero", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    ObtenerTotalesReembolso();
                    if (saldoFinal > 0)
                    {
                        dgvReembolsos[e.ColumnIndex, e.RowIndex].Value = "0";
                        _ = MessageBox.Show("El importe ingresado es mayor al saldo", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                ObtenerTotalesReembolso();
            }
            else if (dgvReembolsos.Columns[e.ColumnIndex].Name == "FECHA_PLANILLA_DOC")
            {
                if (!DateTime.TryParse(dgvReembolsos[e.ColumnIndex, e.RowIndex].Value.ToString(), out _))
                {
                    dgvReembolsos[e.ColumnIndex, e.RowIndex].Value = DateTime.Now.ToShortDateString();
                    _ = MessageBox.Show("Ingrese una fecha válida", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void BtnHistorialRetenciones_Click(object sender, EventArgs e)
        {
            string nroDocumento = "";
            if (dgw_det.CurrentCell != null && sender is Button)
            {
                nroDocumento = dgw_det.CurrentRow.Cells["NRO_PLANILLA_COB"].Value.ToString();
            }
            else if (dgvRetencion.CurrentCell != null && sender is ToolStripButton)
            {
                nroDocumento = dgvRetencion.CurrentRow.Cells["NRO_PLANILLA_COB"].Value.ToString();
            }

            if (nroDocumento != string.Empty)
            {
                FrmVerRetenciones frm = new FrmVerRetenciones(nroDocumento)
                {
                    StartPosition = FormStartPosition.CenterScreen
                };
                frm.ShowDialog();
            }
        }

        private void BtnBuscarPlanilla_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = BLCheque.ObtenerDatosParaRetencionSinPrePlanilla(txtNroContrato.Text, txtFeAño.Text, txtFeMes.Text, txtNroPlanilla.Text);
                if (dt.Rows.Count == 0)
                {
                    CambiarMensaje("No se encontraron datos!!!", Color.Red, 0);
                    _ = MessageBox.Show("No se encontraro datos", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (dt.Rows.Count == 1)
                {
                    txtNroContrato.Text = dt.Rows[0]["NRO_CONTRATO"].ToString();
                    txtNroPlanilla.Text = dt.Rows[0]["NRO_PLANILLA"].ToString();
                    txtFeAño.Text = dt.Rows[0]["FE_AÑO"].ToString();
                    txtFeMes.Text = dt.Rows[0]["FE_MES"].ToString();
                    txtCodCliente.Text = dt.Rows[0]["COD_PER"].ToString();
                    txtDescCliente.Text = dt.Rows[0]["DESC_PER"].ToString();
                    txtCodPtoCob.Text = dt.Rows[0]["COD_PTO_COB"].ToString();
                    txtDescPtoCob.Text = dt.Rows[0]["DESC_PTO_COB"].ToString();
                    codSucursal = dt.Rows[0]["COD_SUCURSAL"].ToString();
                    CambiarMensaje("Los datos son correctos!!!", Color.Blue, 1);
                }
                else
                {
                    LimpiarControlesRetencionSinPrePlanilla();
                    lblValidarDatos.Visible = false;
                    lblValidarDatos.Tag = 0;
                    _ = MessageBox.Show("La consulta optuvo dos planillas, comuniquese con el administrador del sistema", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                ex.PrintException();
            }

            void CambiarMensaje(string message, Color color, int tab)
            {
                lblValidarDatos.Visible = true;
                lblValidarDatos.Text = message;
                lblValidarDatos.ForeColor = color;
                lblValidarDatos.Tag = tab;
            }
        }

        private void LimpiarControlesRetencionSinPrePlanilla()
        {
            txtNroContrato.Clear();
            txtNroPlanilla.Clear();
            txtFeAño.Clear();
            txtFeMes.Clear();
            txtCodCliente.Clear();
            txtDescCliente.Clear();
            txtCodPtoCob.Clear();
            txtDescPtoCob.Clear();
            codSucursal = "";
        }

        private void DgvReembolsos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                try
                {
                    if (MessageBox.Show("¿Esa seguro de eliminar este reembolso?", "MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        if (dgvReembolsos.CurrentCell != null)
                        {
                            if (dgvReembolsos.CurrentRow.Cells["TAG"].Value.ToString() == REGISTROS_GRABADOS)
                            {
                                if (Convert.ToBoolean(dgvReembolsos.CurrentRow.Cells["STATUS_APROBADO"].Value))
                                {
                                    _ = MessageBox.Show("No se puede eliminar este reembolso porque está aprobado!!!", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                                SeguimientoPlanillaTo seguimientoTo = BLSeguimientoPlla.ObtenerSeguimientoPlanillaTo(idSeguimiento);
                                if (lstEliminarReembolsos is null)
                                {
                                    lstEliminarReembolsos = new List<planillaCabeceraOtrasDevDsctosTo>();
                                }

                                planillaCabeceraOtrasDevDsctosTo eliminarReembolsos = new planillaCabeceraOtrasDevDsctosTo
                                {
                                    NRO_PLANILLA_DOC = dgvReembolsos.CurrentRow.Cells["NRO_PLANILLA_DOC"].Value.ToString(),
                                    COD_INSTITUCION = seguimientoTo.COD_INSTITUCION,
                                    FE_AÑO = seguimientoTo.FE_AÑO,
                                    FE_MES = seguimientoTo.FE_MES,
                                    TIPO_PLANILLA_DOC = TIPO_PLLA_REEMBOLSO,
                                    COD_CANAL_DSCTO = seguimientoTo.COD_CANAL_DSCTO,
                                    PlanillaDetalleOtrasDevDsctos = new planillaDetalleOtrasDevDsctosTo
                                    {
                                        NRO_PLANILLA_DOC = dgvReembolsos.CurrentRow.Cells["NRO_PLANILLA_DOC"].Value.ToString(),
                                        TIPO_PLANILLA_DOC = TIPO_PLLA_REEMBOLSO,
                                        NRO_PLLA_ORIGEN = seguimientoTo.NRO_PLANILLA,
                                        TIPO_PLLA_ORIGEN = seguimientoTo.TIPO_PLANILLA
                                    }
                                };

                                lstEliminarReembolsos.Add(eliminarReembolsos);
                                dgvReembolsos.Rows.RemoveAt(dgvReembolsos.CurrentRow.Index);
                                ObtenerTotalesReembolso();
                            }
                            else
                            {
                                dgvReembolsos.Rows.RemoveAt(dgvReembolsos.CurrentRow.Index);
                                ObtenerTotalesReembolso();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    PrintStackTrace(ex);
                }
            }
        }

        private bool ValidarCerrarCobranza()
        {
            foreach (DataGridViewRow row in dgvRetencion.Rows)
            {
                if (!Convert.ToBoolean(row.Cells["STATUS_APROBADO"].Value))
                {
                    _ = MessageBox.Show("Todas las retenciones registradas deben estar aprobadas para finalizar la cobranza", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            if (saldoFinal > 0)
            {
                _ = MessageBox.Show("No debe haber saldo por cobrar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private bool ValidarImporteAplicado()
        {
            foreach (DataGridViewRow row in dgvAplicaciones.Rows)
            {
                if (Convert.ToDecimal(row.Cells["IMPORTE_APLICADO"].Value) <= 0)
                {
                    _ = MessageBox.Show("El importe aplicado no debe ser cero o negativo", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            decimal total = 0;
            foreach (DataGridViewRow row in dgvAplicaciones.Rows)
            {
                total += Convert.ToDecimal(row.Cells["IMPORTE_APLICADO"].Value);
            }

            if (total > 0 && numExceCobranza.Value == 0)
            {
                if (saldoFinal < 0)
                {
                    _ = MessageBox.Show("El total de importe a aplicar es superior al saldo por cobrar de la planilla", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            return true;
        }

        private bool ValidarRetenciones()
        {
            if (dgvRetencion.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvRetencion.Rows)
                {
                    if (Convert.ToDecimal(row.Cells["IMP_RETENCION"].Value) <= 0)
                    {
                        _ = MessageBox.Show("Uno de los importes de las retenciones es cero o negativo, debe ser mayor a cero", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
            }
            return true;
        }

        private bool ValidarReembolsos()
        {
            if (dgvReembolsos.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvReembolsos.Rows)
                {
                    if (Convert.ToDecimal(row.Cells["IMPORTE"].Value) <= 0)
                    {
                        _ = MessageBox.Show("Uno de los importes de los reembolsos es cero o negativo, debe ser mayor a cero", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
            }
            return true;
        }

        private void DgvReembolsos_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dgvReembolsos.Columns[e.ColumnIndex].Name == "IMPORTE")
            {
                if (Convert.ToBoolean(dgvReembolsos.CurrentRow.Cells["STATUS_APROBADO"].Value))
                {
                    e.Cancel = true;
                    _ = MessageBox.Show("No se puede modificar este reembolso porque está aprobado!!!", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void TxtNroContrato_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (!string.IsNullOrEmpty(txtNroContrato.Text))
                {
                    txtNroContrato.Text = txtNroContrato.Text.PadLeft(7, Convert.ToChar("0"));
                    _ = txtNroPlanilla.Focus();
                }
            }
        }

        private void BtnVerApliEnv_Click(object sender, EventArgs e)
        {
            const bool modoInsert = false;
            ListaPlanillasAplicarSaldo frmPlanillas = new ListaPlanillasAplicarSaldo(modoInsert, idSeguimiento, Tipo_APL_SALDO.Planilla_Imp_Exceso)
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            frmPlanillas.EventPasarData += FrmPlanillas_EventPasarData;
            _ = frmPlanillas.ShowDialog();
        }

        private void DgvAplicaciones_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvAplicaciones.Columns[e.ColumnIndex].Name == "IMPORTE_APLICADO")
            {
                if (e.Value != null)
                {
                    decimal a = Convert.ToDecimal(e.Value);
                    e.Value = Convert.ToDecimal(a.ToString("N2"));
                }
            }
        }

        private void TxtNroPlanilla_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _ = txtFeMes.Focus();
            }
        }

        private void TxtFeMes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(txtFeMes.Text))
                    _ = txtFeAño.Focus();
            }
        }

        private void TxtFeAño_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(txtFeAño.Text))
                    btnBuscarPlanilla.PerformClick();
            }
        }

        private void DgvReembolsos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvReembolsos.Columns[e.ColumnIndex].Name == "IMPORTE")
            {
                if (e.Value != null)
                {
                    e.Value = Convert.ToDecimal(e.Value.FormatoMiles());
                }
            }
        }

        private void BtnAgregarPlanilla_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbo_tipo_planilla.SelectedIndex < 0)
                {
                    _ = MessageBox.Show("Seleccione el tipo de Planilla", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (dgw_det.CurrentCell != null)
                {
                    if (dtClientes.Select("COD_PER = '" + TXT_COD.Text + "'").FirstOrDefault() != null)
                    {
                        if (ValidarAgregarPlanilla())
                        {
                            SeguimientoPlanillaTo se = new SeguimientoPlanillaTo
                            {
                                NRO_PLANILLA = nroPlanillaCob,
                                FE_AÑO = feAño,
                                FE_MES = feMes,
                                TIPO_PLANILLA = tipoPlanilla,
                                COD_PTO_COB_CONSOLIDADO = codPtoCob
                            };
                            int indexRow = dgvRetencion.Rows.Add();
                            DataGridViewRow row = dgvRetencion.Rows[indexRow];
                            row.Cells["TAG"].Value = REGISTROS_NUEVOS;
                            row.Cells["ID_SEGUIMIENTO"].Value = BLSeguimientoPlla.ObtenerPlanillasXGrupo(se).Select("COD_PTO_COB_CONSOLIDADO = '" + dgw_det.CurrentRow.Cells["COD_PTO_COB2"].Value.ToString() + "'").SingleOrDefault()["ID_SEGUIMIENTO"].ToString();
                            row.Cells["TIPO_PLANILLA_DESC"].Value = cbo_tipo_planilla.Text;
                            row.Cells["NRO_PLANILLA_DOC"].Value = string.Empty;
                            row.Cells["NRO_PLANILLA_COB"].Value = dgw_det.CurrentRow.Cells["NRO_PLANILLA_COB"].Value;
                            row.Cells["COD_CANAL_DSCTO"].Value = cbo_canaldscto.SelectedValue.ToString();
                            row.Cells["COD_INSTITUCION"].Value = cbo_institucion.SelectedValue.ToString();
                            row.Cells["TIPO_PLANILLA_DOC"].Value = cbo_tipo_planilla.SelectedValue.ToString();
                            row.Cells["COD_SUCURSAL"].Value = cbo_sucursal.SelectedValue.ToString();
                            row.Cells["NRO_DOCU"].Value = dgw_det.CurrentRow.Cells["NRO_DOCU"].Value;
                            row.Cells["COD_PTO_COB"].Value = dgw_det.CurrentRow.Cells["COD_PTO_COB2"].Value;
                            row.Cells["MOTIVO_OTRAS_DEV_DSCTOS"].Value = dgw_det.CurrentRow.Cells["MOTIVO_OTRAS_DEV_DSCTOS"].Value;
                            row.Cells["NRO_LETRA"].Value = dgw_det.CurrentRow.Cells["NRO_LETRA"].Value;
                            row.Cells["FE_AÑO"].Value = dgw_det.CurrentRow.Cells["FE_AÑO"].Value;
                            row.Cells["FE_MES"].Value = dgw_det.CurrentRow.Cells["FE_MES"].Value;
                            row.Cells["PERIODO"].Value = dgw_det.CurrentRow.Cells["FE_MES_REF"].Value.ToString() + " - " + dgw_det.CurrentRow.Cells["FE_AÑO_REF"].Value.ToString();
                            row.Cells["NRO_CONTRATO"].Value = txt_nro_contrato.Text;
                            row.Cells["COD_PER"].Value = TXT_COD.Text;
                            row.Cells["DESC_PER"].Value = TXT_DESC.Text;
                            row.Cells["IMPORTE"].Value = dgw_det.CurrentRow.Cells["IMP_INI2"].Value;
                            row.Cells["IMP_DOC"].Value = dgw_det.CurrentRow.Cells["IMP_DOC"].Value;
                            row.Cells["IMP_DEV"].Value = dgw_det.CurrentRow.Cells["IMP_DEV"].Value;
                            row.Cells["SALDO"].Value = dgw_det.CurrentRow.Cells["SALDO2"].Value;
                            row.Cells["FE_AÑO_REF"].Value = dgw_det.CurrentRow.Cells["FE_AÑO_REF"].Value;
                            row.Cells["FE_MES_REF"].Value = dgw_det.CurrentRow.Cells["FE_MES_REF"].Value;
                            row.Cells["IMP_RETENCION"].Value = 0.00;
                            row.Cells["NRO_PLLA_ORIGEN"].Value = nroPlanillaCob;
                            row.Cells["TIPO_PLLA_ORIGEN"].Value = TIPO_PLLA_DESCUENTO;
                            numImpPlla.Value += Convert.ToDecimal(row.Cells["IMPORTE"].Value);
                            AgregarPlanillaCabeceraDevDescto();
                            dgw_det.Rows.RemoveAt(dgw_det.CurrentCell.RowIndex);
                        }
                    }
                    else
                        _ = MessageBox.Show("El cliente seleccionado es incorrecto", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                ex.PrintException();
            }
        }

        private void BtnAgregarPlanilla2_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarDatosAgregar2() && ValidarPuntoCobranzaPertenescaGruepo())
                {
                    SeguimientoPlanillaTo se = new SeguimientoPlanillaTo
                    {
                        NRO_PLANILLA = nroPlanillaCob,
                        FE_AÑO = feAño,
                        FE_MES = feMes,
                        TIPO_PLANILLA = tipoPlanilla,
                        COD_PTO_COB_CONSOLIDADO = codPtoCob
                    };
                    DataTable dt = BLCheque.ObtenerDatosParaRetencionSinPrePlanilla(txtNroContrato.Text, txtFeAño.Text, txtFeMes.Text, txtNroPlanilla.Text);
                    if (dt.Rows.Count > 0)
                    {
                        int indexRow = dgvRetencion.Rows.Add();
                        DataGridViewRow row = dgvRetencion.Rows[indexRow];
                        row.Cells["TAG"].Value = REGISTROS_NUEVOS;
                        row.Cells["ID_SEGUIMIENTO"].Value = BLSeguimientoPlla.ObtenerPlanillasXGrupo(se).Select("COD_PTO_COB_CONSOLIDADO = '" + txtCodPtoCob.Text + "'").SingleOrDefault()["ID_SEGUIMIENTO"].ToString();
                        row.Cells["TIPO_PLANILLA_DESC"].Value = txtDescTipoPlanilla.Text;
                        row.Cells["NRO_PLANILLA_DOC"].Value = string.Empty;
                        row.Cells["NRO_PLANILLA_COB"].Value = txtNroPlanilla.Text;
                        row.Cells["COD_CANAL_DSCTO"].Value = dt.Rows[0]["COD_CANAL_DSCTO"].ToString();
                        row.Cells["COD_INSTITUCION"].Value = dt.Rows[0]["COD_INSTITUCION"].ToString();
                        row.Cells["TIPO_PLANILLA_DOC"].Value = txtCodTipoPlanilla.Text;
                        row.Cells["COD_SUCURSAL"].Value = dt.Rows[0]["COD_SUCURSAL"].ToString();
                        row.Cells["NRO_DOCU"].Value = string.Empty;
                        row.Cells["COD_PTO_COB"].Value = dt.Rows[0]["COD_PTO_COB"].ToString();
                        row.Cells["MOTIVO_OTRAS_DEV_DSCTOS"].Value = string.Empty;
                        row.Cells["NRO_LETRA"].Value = string.Empty;
                        row.Cells["FE_AÑO"].Value = SeguimientoCheques.AÑO ?? throw new ArgumentNullException(MESSAGE_NULL_PERIODO);
                        row.Cells["FE_MES"].Value = SeguimientoCheques.MES ?? throw new ArgumentNullException(MESSAGE_NULL_PERIODO);
                        row.Cells["FE_AÑO_REF"].Value = txtFeAño.Text;
                        row.Cells["FE_MES_REF"].Value = txtFeMes.Text;
                        row.Cells["PERIODO"].Value = row.Cells["FE_MES_REF"].Value.ToString() + " - " + row.Cells["FE_AÑO_REF"].Value.ToString();
                        row.Cells["NRO_CONTRATO"].Value = dt.Rows[0]["NRO_CONTRATO"].ToString();
                        row.Cells["COD_PER"].Value = dt.Rows[0]["COD_PER"].ToString();
                        row.Cells["DESC_PER"].Value = dt.Rows[0]["DESC_PER"].ToString();
                        row.Cells["IMPORTE"].Value = 0;
                        row.Cells["IMP_DOC"].Value = 0;
                        row.Cells["IMP_DEV"].Value = 0;
                        row.Cells["SALDO"].Value = 0;
                        row.Cells["IMP_RETENCION"].Value = 0.00;
                        row.Cells["NRO_PLLA_ORIGEN"].Value = nroPlanillaCob;
                        row.Cells["TIPO_PLLA_ORIGEN"].Value = TIPO_PLLA_DESCUENTO;
                        numImpPlla.Value += Convert.ToDecimal(row.Cells["IMPORTE"].Value);
                        AgregarPlanillaCabeceraDevDescto(dt);
                        AgregarPlanillaCabeceraDevPCtasCobrar(dt);
                        AgregarPlanillaCabeceraDevTCtasCobrar(dt);
                    }
                    else
                        _ = MessageBox.Show("Error al agregar!!! \n Vuelva a validar los datos", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                ex.PrintException();
            }
        }

        private bool ValidarDatosAgregar2()
        {
            if (Convert.ToInt32(lblValidarDatos.Tag) == 0)
            {
                _ = MessageBox.Show("Los datos a agregar no son correctos, primero valide los datos", "MESSGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            foreach (DataGridViewRow row in dgvRetencion.Rows)
            {
                if (row.Cells["NRO_PLANILLA_COB"].Value.ToString() == txtNroPlanilla.Text
                    && row.Cells["COD_PER"].Value.ToString() == txtCodCliente.Text)
                {
                    _ = MessageBox.Show("Esta planilla ya esta agregado, elija otra planilla", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            if (BLCheque.ValidarExistenciaPlanillaDEV_PCTAS_COBRAR(txtNroPlanilla.Text, codSucursal, "01", txtNroContrato.Text, txtFeAño.Text, txtFeMes.Text))
            {
                _ = MessageBox.Show("Esta planilla ya fue registrado como retención, no se puede volver a registrar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private bool ValidarPuntoCobranzaPertenescaGruepo()
        {
            SeguimientoPlanillaTo se = new SeguimientoPlanillaTo
            {
                NRO_PLANILLA = nroPlanillaCob,
                FE_AÑO = feAño,
                FE_MES = feMes,
                TIPO_PLANILLA = tipoPlanilla,
                COD_PTO_COB_CONSOLIDADO = codPtoCob
            };

            DataRow row = BLSeguimientoPlla.ObtenerPlanillasXGrupo(se).Select("COD_PTO_COB_CONSOLIDADO = '" + txtCodPtoCob.Text + "'").SingleOrDefault();
            if (row is null)
            {
                _ = MessageBox.Show("No puede registrar retenciones de diferentes puntos de cobranza. \n" +
                    "El punto de cobranza de esta planilla " + txtNroPlanilla.Text + " no pertenece al grupo de puntos de cobranza de la planilla " + nroPlanillaCob,
                    "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void BtnRetSinPrePlla_Click(object sender, EventArgs e)
        {
            if (saldoFinal > 0)
            {
                panel1.Visible = false;
                groupBox2.Location = new Point { X = 270, Y = 10 };
                Panel_PER.Location = new Point { X = 373, Y = 58 };
                groupBox2.Controls.Add(dgvRetencion);
                dgvRetencion.Location = new Point { X = 6, Y = 300 };
                groupBox2.Visible = true;
                tabControl1.SelectedTab = tabPage2;
            }
            else
                _ = MessageBox.Show("Esta planilla no necesita nunguna retención", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void AgregarPlanillaCabeceraDevDescto()
        {
            if (lstPlanillaCabecera is null)
                lstPlanillaCabecera = new List<planillaCabeceraOtrasDevDsctosTo>();
            planillaCabeceraOtrasDevDsctosTo plcTo = new planillaCabeceraOtrasDevDsctosTo
            {
                NRO_PLANILLA_DOC = txt_ser.Text + "-" + txt_num.Text,
                SERIE = txt_ser.Text,
                COD_INSTITUCION = cbo_institucion.SelectedValue.ToString(),
                COD_CANAL_DSCTO = cbo_canaldscto.SelectedValue.ToString(),
                FE_AÑO = SeguimientoCheques.AÑO ?? throw new ArgumentNullException(MESSAGE_NULL_PERIODO),
                FE_MES = SeguimientoCheques.MES ?? throw new ArgumentNullException(MESSAGE_NULL_PERIODO),
                COD_SUCURSAL = cbo_sucursal.SelectedValue.ToString(),
                COD_CLASE = "01",
                FECHA_PLANILLA_DOC = dtp_generacion.Value,
                COD_PER = TXT_COD.Text,
                DESC_PER = TXT_DESC.Text,
                DNI = txt_doc_per.Text,
                NRO_CONTRATO = txt_nro_contrato.Text,
                TIPO_PLANILLA_DOC = cbo_tipo_planilla.SelectedValue.ToString(),
                TIPO_PLANILLA_ORI = tipoPlanillaCobranza,
                IMPORTE_TOTAL = Convert.ToDecimal(txt_tot_pagado.Text),
                OBSERVACIONES = txt_observaciones.Text,
                STATUS_CIERRE = "0",
                COD_CREA = COD_USUARIO,
                FECHA_CREA = DateTime.Now,
                COD_DOC = COD_DOC,//tdiBLL.obtieneCodDocInvxTipoDocBLL(tdiTo);
                STATUS_DOC = "0",
                NRO_LETRA = dgw_det.Rows[0].Cells["NRO_LETRA"].Value.ToString(),
                STATUS_COMPROM = cuota_comprometida == true ? "1" : "0",//"0";
                COD_GESTOR = COD_USUARIO,// hay que ver esto!!!!
                COD_MOTIVO_NO_DESCONTADO = Convert.ToString(cboMotivo.SelectedValue),
                COD_UBICACION = COD_UBICACION,
                ORIG_OTRAS_PLLAS = ORIGEN_DEV_PLLA,
                COD_PTO_COB = codPtoCob,
                COD_AREA_TRABAJO = COD_AREA_TRABAJO
            };
            tdiTo.TIPO_DOC = plcTo.TIPO_PLANILLA_DOC;
            lstPlanillaCabecera.Add(plcTo);
        }

        private void AgregarPlanillaCabeceraDevDescto(DataTable dt)
        {
            if (lstPlanillaCabecera is null)
                lstPlanillaCabecera = new List<planillaCabeceraOtrasDevDsctosTo>();
            planillaCabeceraOtrasDevDsctosTo plcTo = new planillaCabeceraOtrasDevDsctosTo
            {
                NRO_PLANILLA_DOC = string.Empty,
                SERIE = "001",
                COD_INSTITUCION = dt.Rows[0]["COD_INSTITUCION"].ToString(),
                COD_CANAL_DSCTO = dt.Rows[0]["COD_CANAL_DSCTO"].ToString(),
                FE_AÑO = SeguimientoCheques.AÑO ?? throw new ArgumentNullException(),
                FE_MES = SeguimientoCheques.MES ?? throw new ArgumentNullException(),
                COD_SUCURSAL = dt.Rows[0]["COD_SUCURSAL"].ToString(),
                COD_CLASE = "01",
                FECHA_PLANILLA_DOC = DateTime.Now,
                COD_PER = dt.Rows[0]["COD_PER"].ToString(),
                DESC_PER = dt.Rows[0]["DESC_PER"].ToString(),
                DNI = dt.Rows[0]["DNI"].ToString(),
                NRO_CONTRATO = dt.Rows[0]["NRO_CONTRATO"].ToString(),
                TIPO_PLANILLA_DOC = txtCodTipoPlanilla.Text,
                TIPO_PLANILLA_ORI = TIPO_PLLA_DESCUENTO,
                IMPORTE_TOTAL = 0,
                OBSERVACIONES = string.Empty,
                STATUS_CIERRE = "0",
                COD_CREA = COD_USUARIO,
                FECHA_CREA = DateTime.Now,
                COD_DOC = string.Empty,//tdiBLL.obtieneCodDocInvxTipoDocBLL(tdiTo);
                STATUS_DOC = "0",
                NRO_LETRA = string.Empty,
                STATUS_COMPROM = "0",
                COD_GESTOR = COD_USUARIO,// hay que ver esto!!!!
                COD_MOTIVO_NO_DESCONTADO = COD_MOTIVO_RETENCION,
                COD_UBICACION = "PP",
                ORIG_OTRAS_PLLAS = ORIGEN_DEV_PLLA,
                COD_PTO_COB = codPtoCob,
                COD_AREA_TRABAJO = COD_AREA_TRABAJO
            };
            tdiTo.TIPO_DOC = plcTo.TIPO_PLANILLA_DOC;
            lstPlanillaCabecera.Add(plcTo);
        }

        private void AgregarPlanillaCabeceraDevPCtasCobrar(DataTable dt)
        {
            if (lstDevPctasCobrar is null)
                lstDevPctasCobrar = new List<devPCtasCobrarTo>();
            devPCtasCobrarTo plcTo = new devPCtasCobrarTo
            {
                NRO_PLANILLA_COB = dt.Rows[0]["NRO_PLANILLA"].ToString(),
                COD_SUCURSAL = dt.Rows[0]["COD_SUCURSAL"].ToString(),
                COD_CLASE = "01",
                NRO_CONTRATO = dt.Rows[0]["NRO_CONTRATO"].ToString(),
                FE_AÑO = dt.Rows[0]["FE_AÑO"].ToString(),
                FE_MES = dt.Rows[0]["FE_MES"].ToString(),
                COD_PER = dt.Rows[0]["COD_PER"].ToString(),
                DESC_PER = dt.Rows[0]["DESC_PER"].ToString(),
                COD_DOC = string.Empty,
                NRO_DOC = string.Empty,
                FECHA_DOC = Convert.ToDateTime(dt.Rows[0]["FECHA_PLANILLA_COB"]),
                IMP_INI = 0,
                IMP_DOC = 0,
                COD_MOTIVO_NO_DESCONTADO = string.Empty,
                COD_D_H = "D",
                OBSERVACION = string.Empty,
                COD_MONEDA = "S",
                TIPO_OPE = "GF",
                NRO_LETRA = string.Empty,
                TOTAL_LETRA = string.Empty,
                STATUS_GENERADO = "0",
                STATUS_CANCELADO = "0",
                TIPO_PLA_ORIGEN = TIPO_PLLA_DESCUENTO,
                TIPO_PLA_COBRANZA = TIPO_PLLA_RETENCION,
                CUOTA_COMPROMETIDA = false,
                TIPO_PLANILLA_ORIGEN = TIPO_PLLA_DESCUENTO,
                COD_USU_CREA = COD_USUARIO,
                FECHA_CREA = DateTime.Now
            };
            lstDevPctasCobrar.Add(plcTo);
        }

        private void AgregarPlanillaCabeceraDevTCtasCobrar(DataTable dt)
        {
            if (lstDevTctasCobrar is null)
                lstDevTctasCobrar = new List<devTCtasCobrarTo>();
            devTCtasCobrarTo plcTo = new devTCtasCobrarTo
            {
                NRO_PLANILLA_COB = dt.Rows[0]["NRO_PLANILLA"].ToString(),
                COD_SUCURSAL = dt.Rows[0]["COD_SUCURSAL"].ToString(),
                COD_CLASE = "01",
                NRO_CONTRATO = dt.Rows[0]["NRO_CONTRATO"].ToString(),
                FE_AÑO = dt.Rows[0]["FE_AÑO"].ToString(),
                FE_MES = dt.Rows[0]["FE_MES"].ToString(),
                COD_PER = dt.Rows[0]["COD_PER"].ToString(),
                DESC_PER = dt.Rows[0]["DESC_PER"].ToString(),
                COD_DOC = string.Empty,
                NRO_DOC = string.Empty,
                FECHA_DOC = Convert.ToDateTime(dt.Rows[0]["FECHA_PLANILLA_COB"]),
                FECHA_CONTRATO = null,
                FECHA_VEN = null,
                COD_P_COBRANZA = string.Empty,
                COD_COBRADOR = string.Empty,
                NRO_PLANILLA = dt.Rows[0]["NRO_PLANILLA"].ToString(),
                FECHA_PLANILLA = Convert.ToDateTime(dt.Rows[0]["FECHA_PLANILLA_COB"]),
                COD_MOTIVO_NO_DESCONTADO = string.Empty,
                COD_D_H = "H",
                COD_MONEDA = "S",
                TIPO_CAMBIO = 0,
                IMP_DOC = 0,
                OBSERVACION = string.Empty,
                TIPO_OPE = "GF",
                NRO_LETRA = string.Empty,
                TOTAL_LETRA = string.Empty,
                COD_CONCEPTO = string.Empty,
                TIPO_PLA_ORIGEN = TIPO_PLLA_DESCUENTO,
                TIPO_PLA_COBRANZA = TIPO_PLLA_RETENCION,
                TIPO_PLANILLA_ORIGEN = TIPO_PLLA_DESCUENTO,
                COD_USU_CREA = COD_USUARIO,
                FECHA_CREA = DateTime.Now
            };
            lstDevTctasCobrar.Add(plcTo);
        }

        private bool ValidarAgregarPlanilla()
        {
            foreach (DataGridViewRow row in dgvRetencion.Rows)
            {
                if (row.Cells["NRO_PLANILLA_COB"].Value.ToString() == dgw_det.CurrentRow.Cells["NRO_PLANILLA_COB"].Value.ToString()
                    && row.Cells["COD_PER"].Value.ToString() == TXT_COD.Text.Trim())
                {
                    _ = MessageBox.Show("Esta planilla ya esta agregado, elija otra planilla", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            return true;
        }

        private DataTable ObtenerDatosRetencion()
        {
            DataTable dtRetencion = new DataTable();
            foreach (DataGridViewColumn column in dgvRetencion.Columns)
            {
                dtRetencion.Columns.Add(column.Name, typeof(string));
            }

            foreach (DataGridViewRow row in dgvRetencion.Rows)
            {
                DataRow rw = dtRetencion.NewRow();
                foreach (DataColumn col in dtRetencion.Columns)
                {
                    rw[col.ColumnName] = row.Cells[col.ColumnName].Value?.ToString();
                }
                dtRetencion.Rows.Add(rw);
            }
            return dtRetencion;
        }

        public void DesactivarOpciones()
        {
            btnRegistrarCobranza.Visible = false;
            btnFinalizarCobranza.Visible = false;
            btnAgregarPlanilla.Enabled = false;
            TXT_COD.Enabled = false;
            TXT_DESC.Enabled = false;
            txt_doc_per.Enabled = false;
            numAjuste.ReadOnly = true;
            btnRetConPrePlla.Visible = false;
            btnRetSinPrePlla.Visible = false;
            btnNuevo2.Visible = false;
            btnNuevoReembolso.Visible = false;
        }

        public void EncabezadoForm(string descPtoCob, string nroPlanilla)
        {
            Text += " | " + "P. Cobranza : " + descPtoCob + " | " + "N° Planilla : " + nroPlanilla;
            this.descPtoCob = descPtoCob;
        }

        private void LimpiarGrabar()
        {
            lstPlanillaCabecera = null;
            lstPlanillasEliminadas = null;
            dtRetencionEliminados = null;
            dtAplicacionesEliminar = null;
            lstEliminarReembolsos = null;
            lstDevPctasCobrar = null;
            lstDevTctasCobrar = null;
            cbo_tipo_planilla.SelectedIndex = -1;
            cboMotivo.SelectedIndex = -1;
            cbo_canaldscto.SelectedIndex = -1;
            cbo_institucion.SelectedIndex = -1;
            cbo_sucursal.SelectedIndex = -1;
        }

        private void ObtenerTotalesReembolso()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dgvReembolsos.Rows)
            {
                total += Convert.ToDecimal(row.Cells["IMPORTE"].Value);
            }

            lblTotalImporteReem.Text = "Total Importe Reembolso : " + total.ToString();

            numReembolso.Value = total;
        }

        private DataTable ObtenerReembolso()
        {
            DataTable dt = new DataTable();
            _ = dt.Columns.Add("TAG", typeof(string));
            _ = dt.Columns.Add("ID_SEGUIMIENTO", typeof(int));
            _ = dt.Columns.Add("COD_PTO_COB", typeof(string));
            _ = dt.Columns.Add("FE_AÑO", typeof(string));
            _ = dt.Columns.Add("FE_MES", typeof(string));
            _ = dt.Columns.Add("IMPORTE", typeof(decimal));
            _ = dt.Columns.Add("USUARIO_CREA", typeof(string));

            foreach (DataGridViewRow row in dgvReembolsos.Rows)
            {
                DataRow rw = dt.NewRow();
                rw["TAG"] = row.Cells["TAG"].Value;
                rw["ID_SEGUIMIENTO"] = idSeguimiento;
                rw["COD_PTO_COB"] = codPtoCob;
                rw["FE_AÑO"] = SeguimientoCheques.AÑO;
                rw["FE_MES"] = SeguimientoCheques.MES;
                rw["IMPORTE"] = row.Cells["IMPORTE"].Value;
                rw["USUARIO_CREA"] = COD_USUARIO;

                dt.Rows.Add(rw);
            }
            return dt;
        }

        private List<planillaCabeceraOtrasDevDsctosTo> ObtenerListaReembolsosCab()
        {
            try
            {
                List<planillaCabeceraOtrasDevDsctosTo> lista = null;
                if (dgvReembolsos.Rows.Count > 0)
                {
                    lista = new List<planillaCabeceraOtrasDevDsctosTo>();
                    SeguimientoPlanillaTo seguimientoTo = BLSeguimientoPlla.ObtenerSeguimientoPlanillaTo(idSeguimiento);
                    foreach (DataGridViewRow row in dgvReembolsos.Rows)
                    {
                        lista.Add(new planillaCabeceraOtrasDevDsctosTo
                        {
                            NRO_PLANILLA_DOC = row.Cells["NRO_PLANILLA_DOC"].Value?.ToString(),
                            TIPO_PLANILLA_DOC = TIPO_PLLA_REEMBOLSO,
                            COD_UBICACION = TIPO_PLLA_REEMBOLSO,
                            COD_CANAL_DSCTO = seguimientoTo.COD_CANAL_DSCTO,
                            COD_INSTITUCION = seguimientoTo.COD_INSTITUCION,
                            FE_AÑO = SeguimientoCheques.AÑO ?? throw new NullReferenceException(MESSAGE_NULL_PERIODO),
                            FE_MES = SeguimientoCheques.MES ?? throw new NullReferenceException(MESSAGE_NULL_PERIODO),
                            COD_SUCURSAL = seguimientoTo.COD_SUCURSAL,
                            COD_PER = string.Empty,
                            DESC_PER = descPtoCob,
                            DNI = string.Empty,
                            NRO_CONTRATO = string.Empty,
                            FECHA_PLANILLA_DOC = DateTime.Now,
                            IMPORTE_TOTAL = Convert.ToDecimal(row.Cells["IMPORTE"].Value),
                            OBSERVACIONES = string.Empty,
                            COD_GESTOR = string.Empty,
                            ORIG_OTRAS_PLLAS = ORIGEN_REE_PLLA,
                            COD_MOTIVO_NO_DESCONTADO = COD_MOTIVO_REEMBOLSO_ENTIDAD,
                            COD_PTO_COB = codPtoCob,
                            COD_AREA_TRABAJO = COD_AREA_TRABAJO,
                            COD_CREA = COD_USUARIO,
                            PlanillaDetalleOtrasDevDsctos = new planillaDetalleOtrasDevDsctosTo
                            {
                                NRO_PLANILLA_DOC = row.Cells["NRO_PLANILLA_DOC"].Value?.ToString(),
                                NRO_PLANILLA_COB = seguimientoTo.NRO_PLANILLA,
                                TIPO_PLANILLA_DOC = TIPO_PLLA_REEMBOLSO,
                                IMP_DOC = Convert.ToDecimal(row.Cells["IMPORTE"].Value),
                                IMP_DEV = Convert.ToDecimal(row.Cells["IMPORTE"].Value),
                                NRO_LETRA = string.Empty,
                                FE_AÑO = SeguimientoCheques.AÑO ?? throw new NullReferenceException(MESSAGE_NULL_PERIODO),
                                FE_MES = SeguimientoCheques.MES ?? throw new NullReferenceException(MESSAGE_NULL_PERIODO),
                                MOTIVO_OTRAS_DEV_DSCTOS = string.Empty,
                                NRO_PLLA_ORIGEN = seguimientoTo.NRO_PLANILLA,
                                TIPO_PLLA_ORIGEN = seguimientoTo.TIPO_PLANILLA,
                                COD_CREA = COD_USUARIO
                            }
                        });
                    }
                }
                return lista;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
