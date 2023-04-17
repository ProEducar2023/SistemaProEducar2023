using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BLL;
using Entidades;
using static Presentacion.HELPERS.FormatDataGridViewColumns;
using static Presentacion.HELPERS.GenericMethod;
using static Presentacion.HELPERS.GenericUtil;
using static Entidades.ConstClass;

namespace Presentacion.MOD_FACT_VTA.MOD_VTA
{
    public partial class ListaPlanillasAplicarSaldo : Form
    {
        private readonly DataGridView gridView;
        private readonly bool modoInsertar;
        private readonly int idSeguimiento;
        private readonly Tipo_APL_SALDO tipoPlanillaAplic;
        private readonly SeguimientoPlanillaTo se;
        private readonly int idPago;
        private readonly Tipo_Operacion_Cobranza tipoOperacionCobranza;

        public ListaPlanillasAplicarSaldo(bool modoInsertar, Tipo_APL_SALDO tipoPlanillaAplic, SeguimientoPlanillaTo se, int idPago, Tipo_Operacion_Cobranza tipoOperacionCobranza)
        {
            InitializeComponent();
            this.modoInsertar = modoInsertar;
            this.tipoPlanillaAplic = tipoPlanillaAplic;
            this.se = se;
            this.idPago = idPago;
            this.tipoOperacionCobranza = tipoOperacionCobranza;
        }

        public ListaPlanillasAplicarSaldo(bool modoInsertar, int idSeguimiento, Tipo_APL_SALDO tipoPlanillaAplic)
        {
            InitializeComponent();
            this.modoInsertar = modoInsertar;
            this.idSeguimiento = idSeguimiento;
            this.tipoPlanillaAplic = tipoPlanillaAplic;
        }


        private readonly ChequeBLL BLCheque = new ChequeBLL();
        private readonly SeguimientoPlanillasBLL BLSeguimiento = new SeguimientoPlanillasBLL();

        private const string A = "N2";
        private const string NAME_IMPORTE_APLICAR = "IMPORTE_APLICAR";

        public new DialogResult DialogResult { get; private set; }

        internal delegate void pasarData(DataTable dt, Tipo_APL_SALDO tipo_APL_SALDO);
        internal event pasarData EventPasarData;
        
        private void ListaPlanillasAplicarSaldo_Load(object sender, EventArgs e)
        {
            StartControls();
            CargarFrmPagos();
            AddColumns();
            ListarPlanillas();
            MostrarDatosOrigen();
            ColorCabeceraDataGridView();
            ActualizarSaldoDisponible();
        }

        private void StartControls()
        {
            btnGuardar.Visible = modoInsertar;
            numSaldoActual.Maximum = decimal.MaxValue;
            numSaldoDisponible.Maximum = decimal.MaxValue;
            numSaldoActual.ReadOnly = true;
            numSaldoDisponible.ReadOnly = true;
            txtNroPlanillaOri.ReadOnly = true;
            txtPeriodoOri.ReadOnly = true;
            EstablecerTituloForm();
            EstablecerTamañoForm();
        }

        private void EstablecerTituloForm()
        {
            if (!modoInsertar)
                Text = tipoPlanillaAplic == Tipo_APL_SALDO.Planilla_Imp_Exceso ? "LISTA DE APLICACIÓN ENVIADAS A OTRAS PLLAS" : "LISTA DE APLICACIÓN RECIBIDAS DE OTRAS PLANILLAS";
            else
                Text = tipoPlanillaAplic == Tipo_APL_SALDO.Planilla_Imp_Exceso ? "LISTA DE PLANILLAS CON SALDO POR COBRAR" : "LISTA DE PLANILLAS CON EXCESO DE COBRANZA";
        }

        private void EstablecerTamañoForm()
        {
            if (!modoInsertar)
            {
                dgvPlanillas.Size = new Size { Width = 697, Height = 463 };
                dgvPlanillas.Location = new Point { X = 0, Y = 0 };
            }
        }

        private void MostrarDatosOrigen()
        {
            if (modoInsertar)
            {
                txtNroPlanillaOri.Text = se.NRO_PLANILLA;
                txtPeriodoOri.Text = se.FE_MES + "-" + se.FE_AÑO;
                numSaldoActual.Value = se.IMPORTE_EXC_DOC;
                numSaldoDisponible.Value = se.IMPORTE_EXC_DOC;
            }
        }

        private void AddColumns()
        {
            if (modoInsertar)
            {
                if (tipoPlanillaAplic == Tipo_APL_SALDO.Planilla_Imp_x_cobrar)
                    AddColumns2();
                else if (tipoPlanillaAplic == Tipo_APL_SALDO.Planilla_Imp_Exceso)
                    AddColumns3();
            }
            else
                AddColumns4();
        }

        private void AddColumns2()
        {
            _ = dgvPlanillas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ID_SEGUIMIENTO",
                Visible = false
            });
            _ = dgvPlanillas.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "CH",
                HeaderText = " ",
                Width = 40
            });

            _ = dgvPlanillas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NRO_PLANILLA",
                HeaderText = "N° PLANILLA",
                Width = 80,
                ReadOnly = true
            });
            _ = dgvPlanillas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FE_AÑO",
                Visible = false
            });
            _ = dgvPlanillas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FE_MES",
                Visible = false
            });
            _ = dgvPlanillas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "PERIODO",
                HeaderText = "PERIODO",
                Width = 70,
                ReadOnly = true
            });
            _ = dgvPlanillas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IMPORTE_EXC_INI",
                HeaderText = "IMPORTE EXCESO",
                Width = 70,
                ReadOnly = true
            });
            _ = dgvPlanillas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IMPORTE_APLICADO",
                HeaderText = "IMPORTE APLICADO",
                Width = 70,
                ReadOnly = true
            });
            _ = dgvPlanillas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IMPORTE_EXC_DOC",
                HeaderText = "SALDO",
                Width = 70,
                ReadOnly = true
            });


            dgvPlanillas.Columns["PERIODO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPlanillas.Columns["NRO_PLANILLA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            FormatDecimalColumns("IMPORTE_EXC_DOC");
            FormatDecimalColumns("IMPORTE_APLICADO");
            FormatDecimalColumns("IMPORTE_EXC_INI");
        }

        private void AddColumns3()
        {
            _ = dgvPlanillas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ID_SEGUIMIENTO",
                Visible = false
            });
            _ = dgvPlanillas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NRO_PLLA_ENV",
                Visible = false
            });
            _ = dgvPlanillas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NRO_DOCUMENTO",
                Visible = false
            });
            _ = dgvPlanillas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ID_ENVIO_APL",
                Visible = false
            });
            _ = dgvPlanillas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TIPO_ENVIO_APL",
                Visible = false
            });
            _ = dgvPlanillas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TAG",
                Visible = false
            });
            _ = dgvPlanillas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "COD_PTO_COB_CONSOLIDADO",
                HeaderText = "COD_PTO_COB_CONSOLIDADO",
                Width = 80,
                ReadOnly = true,
                Visible = false
            });
            _ = dgvPlanillas.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "CH",
                HeaderText = " ",
                Width = 40
            });
            _ = dgvPlanillas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NRO_PLANILLA",
                HeaderText = "N° PLANILLA DESTINO",
                Width = 80,
                ReadOnly = true
            });
            _ = dgvPlanillas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FE_AÑO",
                Visible = false
            });
            _ = dgvPlanillas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FE_MES",
                Visible = false
            });
            _ = dgvPlanillas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "PERIODO",
                HeaderText = "PERIODO DESTINO",
                Width = 70,
                ReadOnly = true
            });
            _ = dgvPlanillas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IMPORTE_APLICADO",
                HeaderText = "IMPORTE APLICADO",
                Width = 70,
                ReadOnly = true
            });
            _ = dgvPlanillas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IMPORTE_APLICAR",
                HeaderText = "IMPORTE A APLICAR",
                Width = 70,
                ValueType = typeof(decimal)
            });
            _ = dgvPlanillas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "SALDO_X_COBRAR",
                HeaderText = "SALDO X COBRAR",
                Width = 70,
                ReadOnly = true
            });


            dgvPlanillas.Columns["PERIODO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPlanillas.Columns["NRO_PLANILLA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPlanillas.Columns["IMPORTE_APLICADO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPlanillas.Columns["IMPORTE_APLICAR"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            FormatDecimalColumns("IMPORTE_APLICADO");
            FormatDecimalColumns("SALDO_X_COBRAR");
            FormatDecimalColumns("IMPORTE_APLICAR");
        }

        private void AddColumns4()
        {
            _ = dgvPlanillas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ID_SEGUIMIENTO",
                Visible = false
            });
            _ = dgvPlanillas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NRO_DOCUMENTO",
                HeaderText = "N° APLICACIÓN",
                Width = 80,
                ReadOnly = true
            });
            _ = dgvPlanillas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "PERIODO_APL",
                HeaderText = "PERIODO APLICACIÓN",
                Width = 80,
                ReadOnly = true
            });
            _ = dgvPlanillas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FECHA_CREA",
                HeaderText = "FECHA APLICACIÓN",
                Width = 120,
                ReadOnly = true
            });
            _ = dgvPlanillas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IMPORTE_APLICADO",
                HeaderText = "IMPORTE APLICADO",
                Width = 70,
                ReadOnly = true
            });
            _ = dgvPlanillas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NRO_PLANILLA",
                HeaderText = "N° PLANILLA",
                Width = 80,
                ReadOnly = true
            });
            _ = dgvPlanillas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FE_AÑO",
                Visible = false
            });
            _ = dgvPlanillas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FE_MES",
                Visible = false
            });
            _ = dgvPlanillas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "PERIODO",
                HeaderText = "PERIODO",
                Width = 80,
                ReadOnly = true
            });

            dgvPlanillas.AlignmentTextContent2("NRO_PLANILLA", DataGridViewContentAlignment.MiddleCenter);
            dgvPlanillas.AlignmentTextContent2("PERIODO", DataGridViewContentAlignment.MiddleCenter);
            dgvPlanillas.AlignmentTextContent2("PERIODO_APL", DataGridViewContentAlignment.MiddleCenter);
            dgvPlanillas.AlignmentTextContent2("IMPORTE_APLICADO", DataGridViewContentAlignment.MiddleRight);
            dgvPlanillas.FormatColumnasFecha("FECHA_CREA");
            FormatDecimalColumns("IMPORTE_APLICADO");
            dgvPlanillas.AlingHeaderTextCenter();
            CambiarTituloColumnasXTipoAplicacion(tipoPlanillaAplic);
            dgvPlanillas.Style4(true, false, false, false, false, false, DataGridViewTriState.True, DataGridViewColumnHeadersHeightSizeMode.AutoSize,
                DataGridViewTriState.False, DataGridViewAutoSizeRowsMode.None, Color.Blue, Color.White, DataGridViewSelectionMode.CellSelect);
        }

        private void CambiarTituloColumnasXTipoAplicacion(Tipo_APL_SALDO tipo_APL_SALDO)
        {
            if (tipo_APL_SALDO == Tipo_APL_SALDO.Planilla_Imp_x_cobrar)
            {
                dgvPlanillas.Columns["NRO_PLANILLA"].HeaderText = "N° PLLA ORIGEN";
                dgvPlanillas.Columns["PERIODO"].HeaderText = "PERIODO ORIGEN";
            }
            else if (tipo_APL_SALDO == Tipo_APL_SALDO.Planilla_Imp_Exceso)
            {
                dgvPlanillas.Columns["NRO_PLANILLA"].HeaderText = "N° PLLA DESTINO";
                dgvPlanillas.Columns["PERIODO"].HeaderText = "PERIODO DESTINO";
            }
        }


        private void FormatDecimalColumns(string nameColumn)
        {
            dgvPlanillas.Columns[nameColumn].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPlanillas.Columns[nameColumn].DefaultCellStyle.Format = A;
        }

        private void ListarPlanillas()
        {
            if (modoInsertar)
            {
                if (tipoPlanillaAplic == Tipo_APL_SALDO.Planilla_Imp_x_cobrar)
                {
                    ListarPlanillasConExceso();
                }
                else if (tipoPlanillaAplic == Tipo_APL_SALDO.Planilla_Imp_Exceso)
                {
                    ListarPlanillasSaldoXCobrar();
                }
            }
            else
            {
                ListarAplicacionesEnviadasORecibidas();
            }
        }

        private void ListarPlanillasConExceso()
        {
            DataTable dt = BLCheque.ListarPlanillasExcCobranzaAplicar(se.COD_PTO_COB_CONSOLIDADO);
            int indexRow;
            foreach (DataRow row in dt.Rows)
            {
                indexRow = dgvPlanillas.Rows.Add();
                DataGridViewRow rw = dgvPlanillas.Rows[indexRow];
                rw.Cells["ID_SEGUIMIENTO"].Value = row["ID_SEGUIMIENTO"];
                rw.Cells["NRO_PLANILLA"].Value = row["NRO_PLANILLA"];
                rw.Cells["FE_AÑO"].Value = row["FE_AÑO"];
                rw.Cells["FE_MES"].Value = row["FE_MES"];
                rw.Cells["PERIODO"].Value = row["FE_MES"].ToString() + " - " + row["FE_AÑO"].ToString();
                rw.Cells["IMPORTE_EXC_INI"].Value = row["IMPORTE_EXC_INI"];
                rw.Cells["IMPORTE_APLICADO"].Value = row["IMPORTE_APLICADO"];
                rw.Cells["IMPORTE_EXC_DOC"].Value = row["IMPORTE_EXC_DOC"];
            }
        }

        private void ListarPlanillasSaldoXCobrar()
        {
            DataTable dt = BLCheque.ListarPlanillasSaldoXCobrarAplicar(se.COD_PTO_COB_CONSOLIDADO, se.ID_SEGUIMIENTO);
            dgvPlanillas.Rows.Clear();
            int indexRow;
            foreach (DataRow row in dt.Rows)
            {
                indexRow = dgvPlanillas.Rows.Add();
                DataGridViewRow rw = dgvPlanillas.Rows[indexRow];
                rw.Cells["ID_SEGUIMIENTO"].Value = row["ID_SEGUIMIENTO"];
                rw.Cells["NRO_PLLA_ENV"].Value = row["NRO_PLLA_ENV"];
                rw.Cells["NRO_DOCUMENTO"].Value = row["NRO_DOCUMENTO"];
                rw.Cells["ID_ENVIO_APL"].Value = row["ID_ENVIO_APL"];
                rw.Cells["TIPO_ENVIO_APL"].Value = row["TIPO_ENVIO_APL"];
                rw.Cells["TAG"].Value = row["TAG"];
                rw.Cells["CH"].Value = row["TAG"].ToBoolean();
                rw.Cells["COD_PTO_COB_CONSOLIDADO"].Value = row["COD_PTO_COB_CONSOLIDADO"];
                rw.Cells["NRO_PLANILLA"].Value = row["NRO_PLANILLA"];
                rw.Cells["FE_AÑO"].Value = row["FE_AÑO"];
                rw.Cells["FE_MES"].Value = row["FE_MES"];
                rw.Cells["PERIODO"].Value = row["FE_MES"].ToString() + " - " + row["FE_AÑO"].ToString();
                rw.Cells["IMPORTE_APLICADO"].Value = row["IMPORTE_APLICADO"];
                rw.Cells["IMPORTE_APLICAR"].Value = row["IMPORTE_APLICAR"];
                rw.Cells["IMPORTE_APLICAR"].Tag = row["IMPORTE_APLICAR"];
                rw.Cells["SALDO_X_COBRAR"].Value = row["SALDO_X_COBRAR"];
            }
        }

        private void ListarAplicacionesEnviadasORecibidas()
        {
            DataTable dt = tipoPlanillaAplic == Tipo_APL_SALDO.Planilla_Imp_Exceso ? BLCheque.ObtenerPlanillasAplicEnvio(idSeguimiento) : BLCheque.ObtenerPlanillasAplicRecibo(idSeguimiento);
            int indexRow;
            foreach (DataRow row in dt.Rows)
            {
                indexRow = dgvPlanillas.Rows.Add();
                DataGridViewRow rw = dgvPlanillas.Rows[indexRow];
                rw.Cells["ID_SEGUIMIENTO"].Value = row["ID_SEGUIMIENTO"];
                rw.Cells["NRO_DOCUMENTO"].Value = row["NRO_DOCUMENTO"];
                rw.Cells["PERIODO_APL"].Value = row["PERIODO_APL"];
                rw.Cells["FECHA_CREA"].Value = row["FECHA_CREA"];
                rw.Cells["IMPORTE_APLICADO"].Value = row["IMPORTE_APLICADO"];
                rw.Cells["NRO_PLANILLA"].Value = row["NRO_PLANILLA"];
                rw.Cells["FE_AÑO"].Value = row["FE_AÑO"];
                rw.Cells["FE_MES"].Value = row["FE_MES"];
                rw.Cells["PERIODO"].Value = row["FE_MES"].ToString() + " - " + row["FE_AÑO"].ToString();
            }
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarAceptar())
                    return;
                if (tipoOperacionCobranza == Tipo_Operacion_Cobranza.Env_Rec_Dep || tipoOperacionCobranza == Tipo_Operacion_Cobranza.Deposito)
                {
                    List<ChequesPlanillaTo> listaRegistrar = ObtenerDatosDepositoOtrasPllasRegistrar();
                    List<ChequesPlanillaTo> listaActualizar = ObtenerDatosDepositoOtrasPllasActualizar();
                    DataTable dtAplicacionReg = ObtenerDatosAplicacionRegistrar();
                    DataTable dtAplicacionAct = ObtenerDatosAplicacionActualizar();
                    ActualizarSaldosPlanillaSel();
                    if (BLCheque.GrabarAplicacionExcesoOtrasPlanillas(listaRegistrar, listaActualizar, dtAplicacionReg, dtAplicacionAct, se))
                    {
                        DialogResult = DialogResult.OK;
                        ListarPlanillasSaldoXCobrar();
                        dgvPlanillas.RefreshEdit();
                        _ = MessageBox.Show("Aplicación grabado correctamente", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        _ = MessageBox.Show("Error al grabar.\n Comuníquese con el administrador del sistema", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show(ex.Message + "\n" + ex.StackTrace, "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool ValidarAceptar()
        {
            if (dgvPlanillas.Rows.Count == 0)
            {
                _ = MessageBox.Show("No hay planillas seleccionadas", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!dgvPlanillas.Rows.Cast<DataGridViewRow>().Where(x => Convert.ToBoolean(x.Cells["CH"].Value)).Any())
            {
                _ = MessageBox.Show("No hay planillas seleccionadas", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!VerificarSiDepositoRegistradoTesoreria())
                return false;

            if (!ValidarImportesDigitados())
                return false;

            return true;
        }

        private bool VerificarSiDepositoRegistradoTesoreria()
        {
            foreach (DataGridViewRow row in dgvPlanillas.Rows)
            {
                bool result = BLCheque.VerificarSiDepositoRegistradoTesoreria(row.Cells["ID_ENVIO_APL"].Value.ToInt32());
                if (result)
                {
                    string message = tipoOperacionCobranza != Tipo_Operacion_Cobranza.Transferencia ? "Este depósito" : "Esta transferencia";
                    _ = MessageBox.Show($"{message} ya se encuentra registrado en tesorería, no se puede actualizar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            return true;
        }

        private bool ValidarImportesDigitados()
        {
            DataGridViewRow[] arrRow = dgvPlanillas.Rows.Cast<DataGridViewRow>().Where(x => x.Cells["CH"].Value.ToBoolean()).ToArray();
            foreach (DataGridViewRow row in arrRow)
            {
                if (row.Cells["IMPORTE_APLICAR"].Value.ToDecimal() <= 0)
                {
                    _ = MessageBox.Show($"El importe a aplicar de la planilla {row.Cells["NRO_PLANILLA"].Value} debe ser mayor a cero", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Obtiene depósitos que se van a registrar al realizar la aplicación. Estos depósitos son de las planillas(Pllas con saldo por cobrar > 0) 
        /// que estan siendo aplicados
        /// </summary>
        /// <returns></returns>
        private List<ChequesPlanillaTo> ObtenerDatosDepositoOtrasPllasRegistrar()
        {
            DataTable dtDeposito = BLCheque.ObtenerDespositoChequeXIdSeguimiento(se.ID_SEGUIMIENTO, idPago);
            List<ChequesPlanillaTo> lista = new List<ChequesPlanillaTo>();
            if (dtDeposito != null && dtDeposito.Rows.Count > 0)
            {
                DataGridViewRow[] arrRow = dgvPlanillas.Rows.Cast<DataGridViewRow>().Where(x => x.Cells["CH"].Value.ToBoolean() && !x.Cells["TAG"].Value.ToBoolean()).ToArray();
                foreach (DataGridViewRow row in arrRow)
                {
                    DataTable dt = BLCheque.ObtenerPlanillasPendientesCheque(row.Cells["COD_PTO_COB_CONSOLIDADO"].Value.ToString(), row.Cells["NRO_PLLA_ENV"].Value.ToString(), row.Cells["ID_SEGUIMIENTO"].Value.ToInt32());
                    lista.Add(new ChequesPlanillaTo
                    {
                        TIPO_PAGO = Tipo_Movimiento_Cheque.Deposito,
                        USUARIO_CREA = SeguimientoCheques.COD_USUARIO,
                        EnvioChequeTo = new EnvioChequeTo
                        {
                            ID_ENVIO = 0
                        },
                        DepositoChequeTo = new DepositoChequeTo
                        {
                            ID_DEPOSITO = dtDeposito.Rows[0]["ID_DEPOSITO"].ToInt32(),
                            COD_BANCO = dtDeposito.Rows[0]["COD_BANCO"].ToString(),
                            NRO_CHEQUE = dtDeposito.Rows[0]["NRO_CHEQUE"].ToString(),
                            NRO_OPERACION = dtDeposito.Rows[0]["NRO_OPERACION"].ToString(),
                            FECHA_DEPOSITO = dtDeposito.Rows[0]["FECHA"].ToDateTime(),
                            ID_MONEDA = dtDeposito.Rows[0]["ID_MONEDA"].ToInt32(),
                            IMPORTE = row.Cells["IMPORTE_APLICAR"].Value.ToDecimal(),
                            IMPORTE_VERIFICADO = row.Cells["IMPORTE_APLICAR"].Value.ToDecimal(),
                            IMPORTE_PROPIO_PLLA = row.Cells["IMPORTE_APLICAR"].Value.ToDecimal(),
                            REPRESENTANTE = dtDeposito.Rows[0]["REPRESENTANTE"].ToString(),
                            RESPONSABLE = dtDeposito.Rows[0]["RESPONSABLE"].ToString(),
                            FL_GEN_APL = true,
                            OBSERVACION = "Depósito generado x aplicación de exceso",
                        },
                        SeguimientoPlanillaTo = new SeguimientoPlanillaTo
                        {
                            ID_SEGUIMIENTO = row.Cells["ID_SEGUIMIENTO"].Value.ToInt32(),
                            NRO_PLLA_ENV = row.Cells["NRO_PLLA_ENV"].Value.ToString(),
                            NRO_PLANILLA = row.Cells["NRO_PLANILLA"].Value.ToString(),
                            ID_ESTADO = CHEQUE_CONFIRMADO,
                            IMPORTE_EXC_INI = ObtenerImporteExcesoIni(dt, row.Cells["IMPORTE_APLICAR"].Value.ToDecimal()),
                            IMPORTE_EXC_DOC = ObtenerImporteExcesoDoc(dt, row.Cells["IMPORTE_APLICAR"].Value.ToDecimal()),
                            IMPORTE_VERIFICADO = ObtenerImporteTotalVerificado(dt, row.Cells["IMPORTE_APLICAR"].Value.ToDecimal()),
                            SALDO_X_COBRAR = ObtenerSaldoXCobrar(dt, row.Cells["IMPORTE_APLICAR"].Value.ToDecimal()),
                            USUARIO_CREA = SeguimientoCheques.COD_USUARIO
                        }
                    });
                }
                return lista;
            }
            throw new Exception("No se encontró datos del depósito");
        }

        private DataTable ObtenerDatosAplicacionRegistrar()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("NRO_DOCUMENTO", typeof(string));
            dt.Columns.Add("FE_AÑO", typeof(string));
            dt.Columns.Add("FE_MES", typeof(string));
            dt.Columns.Add("TIPO_DOC", typeof(string));
            dt.Columns.Add("ID_SEGUIMIENTO_SEL", typeof(int));
            dt.Columns.Add("ID_SEGUIMIENTO_APL", typeof(int));
            dt.Columns.Add("ID_ENVIO_SEL", typeof(int));
            dt.Columns.Add("TIPO_ENVIO_SEL", typeof(string));
            dt.Columns.Add("ID_ENVIO_APL", typeof(int));
            dt.Columns.Add("TIPO_ENVIO_APL", typeof(string));
            dt.Columns.Add("IMPORTE_APLICADO", typeof(string));
            dt.Columns.Add("USUARIO_CREA", typeof(string));
            dt.Columns.Add("USUARIO_MODIFICA", typeof(string));

            string tipoEnvio;
            switch (tipoOperacionCobranza)
            {
                case Tipo_Operacion_Cobranza.Env_Rec_Dep:
                case Tipo_Operacion_Cobranza.Deposito:
                    tipoEnvio = Deposito;
                    break;
                case Tipo_Operacion_Cobranza.Transferencia:
                    tipoEnvio = Transferencia;
                    break;
                default:
                    throw new ArgumentNullException($"Error de tipo de envio Tipo_Operacion_Cobranza. No existe {tipoOperacionCobranza}");
            }

            DataGridViewRow[] arrRow = dgvPlanillas.Rows.Cast<DataGridViewRow>().Where(x => x.Cells["CH"].Value.ToBoolean() && !x.Cells["TAG"].Value.ToBoolean()).ToArray();
            foreach (DataGridViewRow rw in arrRow)
            {
                DataRow row = dt.NewRow();
                row["NRO_DOCUMENTO"] = string.Empty;
                row["FE_AÑO"] = rw.Cells["FE_AÑO"].Value;
                row["FE_MES"] = rw.Cells["FE_MES"].Value;
                row["TIPO_DOC"] = TIPO_DOC_APLICACION;
                row["ID_SEGUIMIENTO_SEL"] = se.ID_SEGUIMIENTO;
                row["ID_SEGUIMIENTO_APL"] = rw.Cells["ID_SEGUIMIENTO"].Value;
                row["ID_ENVIO_SEL"] = idPago;
                row["TIPO_ENVIO_SEL"] = tipoEnvio;
                row["ID_ENVIO_APL"] = 0;
                row["TIPO_ENVIO_APL"] = tipoEnvio;
                row["IMPORTE_APLICADO"] = rw.Cells["IMPORTE_APLICAR"].Value;
                row["USUARIO_CREA"] = UsuarioSistema.Cod_usu;
                row["USUARIO_MODIFICA"] = UsuarioSistema.Cod_usu;

                dt.Rows.Add(row);
            }
            return dt;
        }

        private List<ChequesPlanillaTo> ObtenerDatosDepositoOtrasPllasActualizar()
        {
            DataTable dtDeposito = BLCheque.ObtenerDespositoChequeXIdSeguimiento(se.ID_SEGUIMIENTO, idPago);
            List<ChequesPlanillaTo> lista = new List<ChequesPlanillaTo>();
            if (dtDeposito != null && dtDeposito.Rows.Count > 0)
            {
                DataGridViewRow[] arrRow = dgvPlanillas.Rows.Cast<DataGridViewRow>().Where(x => x.Cells["CH"].Value.ToBoolean() && x.Cells["TAG"].Value.ToBoolean()).ToArray();
                foreach (DataGridViewRow row in arrRow)
                {
                    DataTable dt = BLCheque.ObtenerPlanillasPendientesCheque(row.Cells["COD_PTO_COB_CONSOLIDADO"].Value.ToString(), row.Cells["NRO_PLLA_ENV"].Value.ToString(), row.Cells["ID_SEGUIMIENTO"].Value.ToInt32());
                    lista.Add(new ChequesPlanillaTo
                    {
                        TIPO_PAGO = Tipo_Movimiento_Cheque.Deposito,
                        USUARIO_CREA = SeguimientoCheques.COD_USUARIO,
                        EnvioChequeTo = new EnvioChequeTo
                        {
                            ID_ENVIO = 0
                        },
                        DepositoChequeTo = new DepositoChequeTo
                        {
                            ID_DEPOSITO = row.Cells["ID_ENVIO_APL"].Value.ToInt32(),
                            IMPORTE = row.Cells["IMPORTE_APLICAR"].Value.ToDecimal(),
                            IMPORTE_VERIFICADO = row.Cells["IMPORTE_APLICAR"].Value.ToDecimal(),
                            IMPORTE_PROPIO_PLLA = row.Cells["IMPORTE_APLICAR"].Value.ToDecimal(),
                            FL_GEN_APL = true,
                            OBSERVACION = "Depósito generado x aplicación de exceso",
                        },
                        SeguimientoPlanillaTo = new SeguimientoPlanillaTo
                        {
                            ID_SEGUIMIENTO = row.Cells["ID_SEGUIMIENTO"].Value.ToInt32(),
                            NRO_PLLA_ENV = row.Cells["NRO_PLLA_ENV"].Value.ToString(),
                            NRO_PLANILLA = row.Cells["NRO_PLANILLA"].Value.ToString(),
                            ID_ESTADO = CHEQUE_CONFIRMADO,
                            IMPORTE_EXC_INI = ObtenerImporteExcesoIni(dt, row.Cells["IMPORTE_APLICAR"].Value.ToDecimal() - row.Cells["IMPORTE_APLICAR"].Tag.ToDecimal()),
                            IMPORTE_EXC_DOC = ObtenerImporteExcesoDoc(dt, row.Cells["IMPORTE_APLICAR"].Value.ToDecimal() - row.Cells["IMPORTE_APLICAR"].Tag.ToDecimal()),
                            IMPORTE_VERIFICADO = ObtenerImporteTotalVerificado(dt, row.Cells["IMPORTE_APLICAR"].Value.ToDecimal() - row.Cells["IMPORTE_APLICAR"].Tag.ToDecimal()),
                            SALDO_X_COBRAR = ObtenerSaldoXCobrar(dt, row.Cells["IMPORTE_APLICAR"].Value.ToDecimal() - row.Cells["IMPORTE_APLICAR"].Tag.ToDecimal()),
                            USUARIO_CREA = SeguimientoCheques.COD_USUARIO
                        }
                    });
                }
                return lista;
            }
            throw new Exception("No se encontró datos del depósito");
        }

        private DataTable ObtenerDatosAplicacionActualizar()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("NRO_DOCUMENTO", typeof(string));
            dt.Columns.Add("FE_AÑO", typeof(string));
            dt.Columns.Add("FE_MES", typeof(string));
            dt.Columns.Add("TIPO_DOC", typeof(string));
            dt.Columns.Add("IMPORTE_APLICADO", typeof(string));
            dt.Columns.Add("USUARIO_MODIFICA", typeof(string));

            DataGridViewRow[] arrRow = dgvPlanillas.Rows.Cast<DataGridViewRow>().Where(x => x.Cells["CH"].Value.ToBoolean() && x.Cells["TAG"].Value.ToBoolean()).ToArray();
            foreach (DataGridViewRow rw in arrRow)
            {
                DataRow row = dt.NewRow();
                row["NRO_DOCUMENTO"] = rw.Cells["NRO_DOCUMENTO"].Value;
                row["FE_AÑO"] = rw.Cells["FE_AÑO"].Value;
                row["FE_MES"] = rw.Cells["FE_MES"].Value;
                row["TIPO_DOC"] = TIPO_DOC_APLICACION;
                row["IMPORTE_APLICADO"] = rw.Cells["IMPORTE_APLICAR"].Value;
                row["USUARIO_MODIFICA"] = UsuarioSistema.Cod_usu;

                dt.Rows.Add(row);
            }
            return dt;
        }

        private void ActualizarSaldosPlanillaSel()
        {
            decimal importeAplicado = dgvPlanillas.Rows.Cast<DataGridViewRow>().Where(x => x.Cells["CH"].Value.ToBoolean()).Sum(x => x.Cells["IMPORTE_APLICAR"].Value.ToDecimal());
            DataTable dt = BLCheque.ObtenerPlanillasPendientesCheque(se.COD_PTO_COB_CONSOLIDADO, se.NRO_PLLA_ENV, se.ID_SEGUIMIENTO);
            se.IMPORTE_EXC_INI = ObtenerImporteExcesoIni(dt, 0);
            se.IMPORTE_EXC_DOC = ObtenerImporteExcesoDoc2(dt, importeAplicado);
            se.IMPORTE_VERIFICADO = ObtenerImporteTotalVerificado(dt, 0);
            se.SALDO_X_COBRAR = ObtenerSaldoXCobrar(dt, 0);
        }

        decimal ObtenerImporteExcesoIni(DataTable dt, decimal importeVerificado)
        {
            decimal saldo = Convert.ToDecimal(dt.Rows[0]["IMPORTE_NETO_ENTIDAD"]) - Convert.ToDecimal(dt.Rows[0]["IMP_VERIFICADO"]) -
                importeVerificado;
            return saldo >= 0 ? 0 : saldo * -1;
        }

        decimal ObtenerImporteExcesoDoc(DataTable dt, decimal importeVerificado)
        {
            decimal saldo = Convert.ToDecimal(dt.Rows[0]["IMPORTE_NETO_ENTIDAD"]) - Convert.ToDecimal(dt.Rows[0]["IMP_VERIFICADO"]) -
                importeVerificado + Convert.ToDecimal(dt.Rows[0]["IMPORTE_REEMBOLSO"]);
            return saldo >= 0 ? 0 : saldo * -1;
        }

        decimal ObtenerImporteExcesoDoc2(DataTable dt, decimal importeAplicado)
        {
            decimal saldo = Convert.ToDecimal(dt.Rows[0]["IMPORTE_NETO_ENTIDAD"]) - Convert.ToDecimal(dt.Rows[0]["IMP_VERIFICADO"])
                + importeAplicado + Convert.ToDecimal(dt.Rows[0]["IMPORTE_REEMBOLSO"]);
            return saldo >= 0 ? 0 : saldo * -1;
        }

        decimal ObtenerImporteTotalVerificado(DataTable dt, decimal importeVerificado)
        {
            return Convert.ToDecimal(dt.Rows[0]["IMP_VERIFICADO"]) +
                importeVerificado;
        }

        decimal ObtenerSaldoXCobrar(DataTable dt, decimal importeVerificado)
        {
            decimal saldo = Convert.ToDecimal(dt.Rows[0]["IMPORTE_NETO_ENTIDAD"]) - Convert.ToDecimal(dt.Rows[0]["IMP_VERIFICADO"]) -
                importeVerificado + Convert.ToDecimal(dt.Rows[0]["IMPORTE_REEMBOLSO"]);
            return saldo >= 0 ? saldo : 0;
        }

        private void DgvPlanillas_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvPlanillas.IsCurrentCellDirty)
                dgvPlanillas.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void DgvPlanillas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPlanillas.Columns[e.ColumnIndex].Name == "CH")
            {
                ActualizarSaldoDisponible();
                _ = dgvPlanillas.RefreshEdit();
            }
        }

        private void ActualizarSaldoDisponible()
        {
            decimal importe = 0;
            foreach (DataGridViewRow row in dgvPlanillas.Rows)
            {
                if (Convert.ToBoolean(row.Cells["CH"].Value))
                {
                    importe += Convert.ToDecimal(row.Cells[NAME_IMPORTE_APLICAR].Value);
                }

                if (!Convert.ToBoolean(row.Cells["CH"].Value) && Convert.ToBoolean(row.Cells["TAG"].Value))
                {
                    importe += Convert.ToDecimal(row.Cells[NAME_IMPORTE_APLICAR].Tag);
                }
            }
            if (numSaldoActual.Value - importe < 0)
            {
                dgvPlanillas.CurrentRow.Cells[NAME_IMPORTE_APLICAR].Value = 0.00;
                _ = dgvPlanillas.CommitEdit(DataGridViewDataErrorContexts.Commit);
                _ = MessageBox.Show("Los importes a aplicar es superior al saldo disponible", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                numSaldoDisponible.Value = numSaldoActual.Value - importe;
        }

        private void DgvPlanillas_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPlanillas.Columns[e.ColumnIndex].Name == NAME_IMPORTE_APLICAR)
            {
                if (Convert.ToDecimal(dgvPlanillas[e.ColumnIndex, e.RowIndex].Value) <= 0)
                {
                    dgvPlanillas.CurrentRow.Cells[NAME_IMPORTE_APLICAR].Value = 0.00;
                    _ = MessageBox.Show("Debe ingresar valores mayores a cero", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (!dgvPlanillas["TAG", e.RowIndex].Value.ToBoolean() && Convert.ToDecimal(dgvPlanillas[e.ColumnIndex, e.RowIndex].Value) > Convert.ToDecimal(dgvPlanillas["SALDO_X_COBRAR", e.RowIndex].Value))
                {
                    dgvPlanillas.CurrentRow.Cells[NAME_IMPORTE_APLICAR].Value = 0.00;
                    _ = MessageBox.Show("El importe a aplicar es superior al sado por cobrar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (dgvPlanillas["TAG", e.RowIndex].Value.ToBoolean())
                {
                    decimal importeAplRegistrado = dgvPlanillas[e.ColumnIndex, e.RowIndex].Tag.ToDecimal();
                    decimal importeAplicar = dgvPlanillas[e.ColumnIndex, e.RowIndex].Value.ToDecimal();
                    decimal saldoXCobrar = dgvPlanillas["SALDO_X_COBRAR", e.RowIndex].Value.ToDecimal();
                    if (importeAplicar > importeAplRegistrado + saldoXCobrar)
                    {
                        dgvPlanillas.CurrentRow.Cells[NAME_IMPORTE_APLICAR].Value = importeAplRegistrado;
                        _ = MessageBox.Show("El importe a aplicar es superior al sado por cobrar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                ActualizarSaldoDisponible();
            }
        }

        private void DgvPlanillas_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void ColorCabeceraDataGridView()
        {
            foreach (DataGridViewColumn column in dgvPlanillas.Columns)
            {
                column.HeaderCell.Style.BackColor = Color.SkyBlue;
            }
        }

        private void CargarFrmPagos()
        {
            UserControl frmPago = null;
            switch (tipoOperacionCobranza)
            {
                case Tipo_Operacion_Cobranza.Env_Rec_Dep:
                case Tipo_Operacion_Cobranza.Deposito:
                    frmPago = new FrmPagoDepositoPlla(se.ID_SEGUIMIENTO, idPago);
                    break;
                case Tipo_Operacion_Cobranza.Transferencia:
                    break;
                default: throw new ArgumentNullException($"Este {tipoOperacionCobranza} no esta implementado");
            }

            plDatosPagos.Controls.Add(frmPago);
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (!ValidarEliminarPago())
                return;

            DialogResult dr = MessageBox.Show("¿Esta seguro de eliminar las aplicaciones seleccionadas?", "MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                List<ChequesPlanillaTo> to = ObtenerChequesPlanillaToEliminar();
                if (BLCheque.EliminarAplicacionOtrasPllas(se, to))
                {
                    DialogResult = DialogResult.OK;
                    ListarPlanillasSaldoXCobrar();
                    ActualizarSaldoDisponible();
                    _ = MessageBox.Show("Eliminado Correctamente", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    _ = MessageBox.Show("Error al eliminar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<ChequesPlanillaTo> ObtenerChequesPlanillaToEliminar()
        {
            List<ChequesPlanillaTo> lista = new List<ChequesPlanillaTo>();
            DataGridViewRow[] arrRow = dgvPlanillas.Rows.Cast<DataGridViewRow>().Where(x => x.Cells["TAG"].Value.ToBoolean() && x.Cells["CH"].Value.ToBoolean()).ToArray();
            foreach (DataGridViewRow row in arrRow)
            {
                lista.Add(new ChequesPlanillaTo
                {
                    TIPO_PAGO_TXT = row.Cells["TIPO_ENVIO_APL"].Value.ToString(),
                    ESTADO = Resultado_Cheque.Aprobar,
                    ID_PAGO = Convert.ToInt32(row.Cells["ID_ENVIO_APL"].Value),
                    FL_GEN_APL = true,
                    DepositoChequeTo = new DepositoChequeTo
                    {
                        IMPORTE = row.Cells["IMPORTE_APLICAR"].Value.ToDecimal()
                    },
                    SeguimientoPlanillaTo = ObtenerSegumientoPlanillaParaEliminarCheque(row)
                });
            }
            return lista;
        }

        private SeguimientoPlanillaTo ObtenerSegumientoPlanillaParaEliminarCheque(DataGridViewRow row)
        {
            int idSeguimiento = Convert.ToInt32(row.Cells["ID_SEGUIMIENTO"].Value);
            DataTable dtSeguimientoPlla = BLSeguimiento.ObtenerSeguimientoPlanillaXIdSeguimiento(idSeguimiento);
            string nroPlanilla = dtSeguimientoPlla.Rows[0]["NRO_PLANILLA"].ToString();
            string nroPllaEnv = dtSeguimientoPlla.Rows[0]["NRO_PLLA_ENV"].ToString();
            string codPtoCob = dtSeguimientoPlla.Rows[0]["COD_PTO_COB_CONSOLIDADO"].ToString();
            DataTable dt = BLCheque.ObtenerPlanillasPendientesCheque(codPtoCob, nroPllaEnv, idSeguimiento);
            decimal importeAplicado = Convert.ToDecimal(row.Cells["IMPORTE_APLICAR"].Value);

            if (dt is null || dt.Rows.Count != 1)
            {
                _ = MessageBox.Show("Error al obtener datos de la planilla N°obts(" + dt.Rows.Count.ToString() + ")." + "\n Comuniquese con el administrador de sistemas",
                    "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            return new SeguimientoPlanillaTo
            {
                ID_SEGUIMIENTO = idSeguimiento,
                NRO_PLANILLA = nroPlanilla,
                NRO_PLLA_ENV = nroPllaEnv,
                ID_ESTADO = CHEQUE_CONFIRMADO,
                IMPORTE_EXC_INI = ObtenerImporteExcesoIni(),
                IMPORTE_EXC_DOC = ObtenerImporteExcesoDoc(),
                IMPORTE_VERIFICADO = ObtenerImporteTotalVerificado(),
                SALDO_X_COBRAR = ObtenerSaldoXCobrar()
            };

            decimal ObtenerImporteExcesoIni()
            {
                decimal saldo = Convert.ToDecimal(dt.Rows[0]["IMPORTE_NETO_ENTIDAD"]) - (Convert.ToDecimal(dt.Rows[0]["IMP_VERIFICADO"]) - importeAplicado);
                return saldo >= 0 ? 0 : saldo * -1;
            }

            decimal ObtenerImporteExcesoDoc()
            {
                decimal saldo = Convert.ToDecimal(dt.Rows[0]["IMPORTE_NETO_ENTIDAD"]) - (Convert.ToDecimal(dt.Rows[0]["IMP_VERIFICADO"]) - importeAplicado)
                    + Convert.ToDecimal(dt.Rows[0]["IMPORTE_REEMBOLSO"]);
                return saldo >= 0 ? 0 : saldo * -1;
            }

            decimal ObtenerImporteTotalVerificado()
            {
                return Convert.ToDecimal(dt.Rows[0]["IMP_VERIFICADO"]) - importeAplicado;
            }

            decimal ObtenerSaldoXCobrar()
            {
                decimal saldo = Convert.ToDecimal(dt.Rows[0]["IMPORTE_NETO_ENTIDAD"]) - (Convert.ToDecimal(dt.Rows[0]["IMP_VERIFICADO"]) - importeAplicado)
                    + Convert.ToDecimal(dt.Rows[0]["IMPORTE_REEMBOLSO"]);
                return saldo >= 0 ? saldo : 0;
            }
        }

        private bool ValidarEliminarPago()
        {
            DataGridViewRow[] arrRow = dgvPlanillas.Rows.Cast<DataGridViewRow>().Where(x => x.Cells["CH"].Value.ToBoolean()).ToArray();
            foreach (DataGridViewRow row in arrRow)
            {
                int id = Convert.ToInt32(row.Cells["ID_ENVIO_APL"].Value);
                if (BLCheque.VerificarSiDepositoRegistradoTesoreria(id))
                {
                    _ = MessageBox.Show($"El pago de la planilla: {row.Cells["NRO_PLANILLA"].Value}, ya se encuentra registrado en tesorería, no se puede eliminar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                return true;
            }
            return false;
        }
    }
}
