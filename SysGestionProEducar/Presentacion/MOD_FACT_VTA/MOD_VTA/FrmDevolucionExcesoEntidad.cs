using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using Entidades;
using static Presentacion.HELPERS.GenericUtil;
using static Presentacion.HELPERS.FormatDataGridViewColumns;
using static Presentacion.HELPERS.GenericMethod;


namespace Presentacion.MOD_FACT_VTA.MOD_VTA
{

    public partial class FrmDevolucionExcesoEntidad : Form
    {
        private int IDDEVOLUCION_EXC;
        decimal TOTALCHEQUE = 0;
        //private readonly int id_pago;
        private readonly Tipo_Operacion_Cobranza tipoOperacionCobranza;

        private ChequesPlanillaTo chequeplanilla;
        public FrmDevolucionExcesoEntidad(ChequesPlanillaTo chequeplanilla)
        {
            InitializeComponent();

            this.chequeplanilla = chequeplanilla;
        }

        private readonly ChequeBLL BLCheque = new ChequeBLL();
        private CRUD crud;

        private void FrmDevolucionExcesoEntidad_Load(object sender, EventArgs e)
        {
            StartControls();

            CargarFrmPagos();
            VerificarDevoluciones();
            AddColumns();
            ListarDetalleDevoluciones();
            ColorCabeceraDataGridView();
            //inhabilitarcontroles();
            //DataTable dt = BLCheque.ObtenerDespositoChequeXIdSeguimiento(chequeplanilla.SeguimientoPlanillaTo.ID_SEGUIMIENTO, chequeplanilla.ID_PAGO)
        }

        private DataTable ObtenerDatosDetalleDevolucion()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("IDTIPOENVIO", typeof(int));
            dt.Columns.Add("NRO_PLANILLA", typeof(string));
            dt.Columns.Add("TIPOENVIO", typeof(string));
            dt.Columns.Add("NRO_DOCUMENTO", typeof(string));
            dt.Columns.Add("TIPO_DOC", typeof(string));
            dt.Columns.Add("TIPO_ENVIO_SEL", typeof(string));
            dt.Columns.Add("TIPO_ENVIO_APL", typeof(string));
            dt.Columns.Add("IMPORTE_APLICADO", typeof(decimal));
            dt.Columns.Add("CH", typeof(bool));
            dt.Columns.Add("IMPORTE_DEVUELTO", typeof(decimal));
            dt.Columns.Add("FECHA_CREA", typeof(DateTime));
            dt.Columns.Add("TIPO_PAGO", typeof(string));
            dt.Columns.Add("USUARIO", typeof(string));
            dt.Columns.Add("ID_SEGUIMIENTO_SEL", typeof(int));
            dt.Columns.Add("ID_SEGUIMIENTO_APL", typeof(int));
            dt.Columns.Add("ID_ENVIO_SEL", typeof(int));
            dt.Columns.Add("ID_ENVIO_APL", typeof(int));
            dt.Columns.Add("SUMA_PAGO_PLL", typeof(decimal));
            dt.Columns.Add("IMPORTE_VERIFICADO", typeof(decimal));


            DataGridViewRow[] arrRow = dgvPlanillas.Rows.Cast<DataGridViewRow>().Where(x => Convert.ToBoolean(x.Cells["CH"].Value)).ToArray(); //.Where(x => x.Cells["CH"].Value.ToBoolean() && !x.Cells["TAG"].Value.ToBoolean()).ToArray();
            foreach (DataGridViewRow rw in arrRow)
            {
                DataRow row = dt.NewRow();
                row["IDTIPOENVIO"] = rw.Cells["IDTIPOENVIO"].Value;
                row["NRO_PLANILLA"] = rw.Cells["NRO_PLANILLA"].Value;
                row["TIPOENVIO"] = rw.Cells["TIPOENVIO"].Value;
                row["NRO_DOCUMENTO"] = rw.Cells["NRO_DOCUMENTO"].Value;
                row["TIPO_DOC"] = rw.Cells["TIPO_DOC"].Value;
                row["TIPO_ENVIO_SEL"] = rw.Cells["TIPO_ENVIO_SEL"].Value;
                row["TIPO_ENVIO_APL"] = rw.Cells["TIPO_ENVIO_APL"].Value;
                row["IMPORTE_APLICADO"] = rw.Cells["IMPORTE_APLICADO"].Value;
                rw.Cells["CH"].Value = rw.Cells["CH"].Value.ToBoolean();
                row["IMPORTE_DEVUELTO"] = rw.Cells["IMPORTE_DEVUELTO"].Value;
                row["FECHA_CREA"] = rw.Cells["FECHA_CREA"].Value;
                row["TIPO_PAGO"] = rw.Cells["TIPO_PAGO"].Value;
                row["USUARIO"] = rw.Cells["USUARIO"].Value;
                row["ID_SEGUIMIENTO_SEL"] = rw.Cells["ID_SEGUIMIENTO_SEL"].Value;
                row["ID_SEGUIMIENTO_APL"] = rw.Cells["ID_SEGUIMIENTO_APL"].Value;
                row["ID_ENVIO_SEL"] = rw.Cells["ID_ENVIO_SEL"].Value;
                row["ID_ENVIO_APL"] = rw.Cells["ID_ENVIO_APL"].Value;
                row["SUMA_PAGO_PLL"] = numTotalAnular.Value.ToDecimal();
                row["IMPORTE_VERIFICADO"] = rw.Cells["IMPORTE_VERIFICADO"].Value;

                dt.Rows.Add(row);
            }
            return dt;
        }
        private void ListarDetalleDevoluciones()
        {

            DataTable dt = BLCheque.ListarDetalleDevoluciones(chequeplanilla.SeguimientoPlanillaTo.ID_SEGUIMIENTO, chequeplanilla.SeguimientoPlanillaTo.ID_PAGO);
            int indexRow;
            foreach (DataRow row in dt.Rows)
            {
                indexRow = dgvPlanillas.Rows.Add();
                DataGridViewRow rw = dgvPlanillas.Rows[indexRow];
                rw.Cells["IDTIPOENVIO"].Value = row["IDTIPOENVIO"];
                rw.Cells["NRO_PLANILLA"].Value = row["NRO_PLANILLA"];
                rw.Cells["TIPOENVIO"].Value = row["TIPOENVIO"];
                rw.Cells["NRO_DOCUMENTO"].Value = row["NRO_DOCUMENTO"];
                rw.Cells["TIPO_DOC"].Value = row["TIPO_DOC"];
                rw.Cells["TIPO_ENVIO_SEL"].Value = row["TIPO_ENVIO_SEL"];
                rw.Cells["TIPO_ENVIO_APL"].Value = row["TIPO_ENVIO_APL"];
                rw.Cells["IMPORTE_APLICADO"].Value = row["IMPORTE_APLICADO"];
                rw.Cells["IMPORTE_DEVUELTO"].Value = row["IMPORTE_DEVUELTO"];
                rw.Cells["FECHA_CREA"].Value = row["FECHA_CREA"];
                rw.Cells["TIPO_PAGO"].Value = chequeplanilla.SeguimientoPlanillaTo.TIPO_PAGO;
                rw.Cells["USUARIO"].Value = UsuarioSistema.Cod_usu;
                rw.Cells["ID_SEGUIMIENTO_SEL"].Value = row["ID_SEGUIMIENTO_SEL"];
                rw.Cells["ID_SEGUIMIENTO_APL"].Value = row["ID_SEGUIMIENTO_APL"];
                rw.Cells["ID_ENVIO_SEL"].Value = row["ID_ENVIO_SEL"];
                rw.Cells["ID_ENVIO_APL"].Value = row["ID_ENVIO_APL"];
                rw.Cells["IMPORTE_VERIFICADO"].Value = row["IMPORTE_VERIFICADO"];


                TOTALCHEQUE += Convert.ToDecimal(row["IMPORTE_APLICADO"]);
            }

            numTotalAnular.Value = 0;
            // numNuevoSaldo.Value = chequeplanilla.SeguimientoPlanillaTo.IMPORTE_NETO.ToDecimal() - TOTALCHEQUE + chequeplanilla.SeguimientoPlanillaTo.SALDO_X_COBRAR.ToDecimal();
            numNuevoSaldo.Value = chequeplanilla.SeguimientoPlanillaTo.SALDO_X_COBRAR.ToDecimal();

            // numImporteDevolver.Value = numNuevoSaldo.Value - numImporteDevolver.Value;
            numImporteDevolver.Value = chequeplanilla.SeguimientoPlanillaTo.SALDO_X_COBRAR.ToDecimal();
            //numSaldoFinalCheq.Value = numNuevoSaldo.Value.ToDecimal() - numImporteDevolver.Value.ToDecimal();


        }

        private void AddColumns()
        {
            _ = dgvPlanillas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IDTIPOENVIO",
                HeaderText = "IDTIPOENVIO",
                Visible = false
            });
            _ = dgvPlanillas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NRO_PLANILLA",
                HeaderText = "NRO PLANILLA",
                Width = 100,
                ReadOnly = true
            });
            _ = dgvPlanillas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TIPOENVIO",
                HeaderText = "TIPO OPERACION",
                Width = 80,
                ReadOnly = true
            });
            _ = dgvPlanillas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NRO_DOCUMENTO",
                HeaderText = "NRO DOCUMENTO",
                Width = 80,
                Visible = false,
                ReadOnly = true
            });
            _ = dgvPlanillas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TIPO_DOC",
                HeaderText = "TIPO_DOC",
                Visible = false,
            });
            _ = dgvPlanillas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TIPO_ENVIO_SEL",
                HeaderText = "TIPO_ENVIO_SEL",
                Visible = false
            });
            _ = dgvPlanillas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TIPO_ENVIO_APL",
                HeaderText = "TIPO_ENVIO_APL",
                Visible = false
            });
            _ = dgvPlanillas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IMPORTE_APLICADO",
                HeaderText = "IMPORTE APLICADO",
                Width = 100,
                ReadOnly = true
            });
            _ = dgvPlanillas.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "CH",
                HeaderText = " ",
                Width = 40
            });
            _ = dgvPlanillas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IMPORTE_DEVUELTO",
                HeaderText = "IMPORTE DEVUELTO",
                Visible = false
            });
            _ = dgvPlanillas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FECHA_CREA",
                HeaderText = "FECHA CREA",
                Width = 80,
                ReadOnly = true
            });
            _ = dgvPlanillas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TIPO_PAGO",
                Visible = false
            });
            _ = dgvPlanillas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "USUARIO",
                Visible = false
            });
            _ = dgvPlanillas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ID_SEGUIMIENTO_SEL",
                Visible = false
            });
            _ = dgvPlanillas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ID_SEGUIMIENTO_APL",
                Visible = false
            });
            _ = dgvPlanillas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ID_ENVIO_SEL",
                Visible = false
            });
            _ = dgvPlanillas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ID_ENVIO_APL",
                Visible = false
            });
            _ = dgvPlanillas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IMPORTE_VERIFICADO",
                Visible = false
            });


            dgvPlanillas.AlignmentTextContent2("NRO_DOCUMENTO", DataGridViewContentAlignment.MiddleCenter);
            dgvPlanillas.AlignmentTextContent2("TIPO_DOC", DataGridViewContentAlignment.MiddleCenter);
            dgvPlanillas.AlignmentTextContent2("TIPO_ENVIO_SEL", DataGridViewContentAlignment.MiddleCenter);
            dgvPlanillas.AlignmentTextContent2("TIPO_ENVIO_APL", DataGridViewContentAlignment.MiddleCenter);
            dgvPlanillas.AlignmentTextContent2("IMPORTE_APLICADO", DataGridViewContentAlignment.MiddleRight);
            dgvPlanillas.AlignmentTextContent2("IMPORTE_DEVUELTO", DataGridViewContentAlignment.MiddleRight);
            dgvPlanillas.FormatColumnasFecha("FECHA_CREA");
            FormatDecimalColumns("IMPORTE_APLICADO");
            FormatDecimalColumns("IMPORTE_DEVUELTO");
            dgvPlanillas.AlingHeaderTextCenter();

            dgvPlanillas.Style4(true, false, false, false, false, false, DataGridViewTriState.True, DataGridViewColumnHeadersHeightSizeMode.AutoSize,
                DataGridViewTriState.False, DataGridViewAutoSizeRowsMode.None, Color.Blue, Color.White, DataGridViewSelectionMode.CellSelect);
        }
        private void FormatDecimalColumns(string nameColumn)
        {
            dgvPlanillas.Columns[nameColumn].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPlanillas.Columns[nameColumn].DefaultCellStyle.Format = "N2";
        }

        private void ColorCabeceraDataGridView()
        {
            foreach (DataGridViewColumn column in dgvPlanillas.Columns)
            {
                column.HeaderCell.Style.BackColor = Color.SkyBlue;
            }
        }
        private void VerificarDevoluciones()
        {

            string result = BLCheque.VerificarDevoluciones(chequeplanilla.SeguimientoPlanillaTo.ID_SEGUIMIENTO, chequeplanilla.SeguimientoPlanillaTo.ID_PAGO, chequeplanilla.SeguimientoPlanillaTo.TIPO_PAGO);
            if (result.Length > 0)
            {
                string[] valores = result.Split('-');
                IDDEVOLUCION_EXC = Int32.Parse(valores[0]);


                if (chequeplanilla.SeguimientoPlanillaTo.CHEQUE_APLICADO_SALDO == 1)
                {
                    numImporteDevolver.Maximum = decimal.MaxValue;
                    numImporteDevolver.Value = decimal.Parse(valores[1]);

                }
                else
                {
                    numSaldoActual.Maximum = chequeplanilla.SeguimientoPlanillaTo.IMPORTE_NETO;
                    numSaldoActual.Value = 0;

                    numSaldoDisponible.Maximum = chequeplanilla.SeguimientoPlanillaTo.IMPORTE_NETO;
                    numSaldoDisponible.Value = 0;

                    numImporteDevolver.Value = 0;
                    numImporteDevolver.Enabled = false;
                }


                //string message = tipoOperacionCobranza != Tipo_Operacion_Cobranza.Transferencia ? "Este depósito" : "Esta transferencia";
                //_ = MessageBox.Show($"{message} ya se encuentra registrado en tesorería, no se puede actualizar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //return false;
            }
            else
            {
                IDDEVOLUCION_EXC = 0;
            }


        }
        private void StartControls()
        {


            txtNroPlanillaOri.Text = chequeplanilla.SeguimientoPlanillaTo.NRO_PLANILLA;

            txtPeriodoOri.Text = chequeplanilla.SeguimientoPlanillaTo.PERIODO;
            numSaldoActual.Maximum = decimal.MaxValue;
            numSaldoActual.Value = chequeplanilla.SeguimientoPlanillaTo.IMPORTE_EXC_DOC;

            numSaldoDisponible.Maximum = decimal.MaxValue;
            numSaldoDisponible.Value = chequeplanilla.SeguimientoPlanillaTo.IMPORTE_EXC_DOC;

            numImporteDevolver.Maximum = chequeplanilla.SeguimientoPlanillaTo.IMPORTE_EXC_DOC; //decimal.MaxValue;

            numImporteDevolver.Value = 0;




            numTotalAnular.Maximum = chequeplanilla.SeguimientoPlanillaTo.IMPORTE_NETO;
            numNuevoSaldo.Maximum = chequeplanilla.SeguimientoPlanillaTo.IMPORTE_NETO;
            numImporteDevolver.Maximum = chequeplanilla.SeguimientoPlanillaTo.IMPORTE_NETO;
            numSaldoFinalCheq.Maximum = chequeplanilla.SeguimientoPlanillaTo.IMPORTE_NETO;
            numSaldoFinalCheq.Minimum = decimal.MinValue;
            //> 100
            //DataTable dt = BLCheque.ObtenerDespositoChequeXIdSeguimiento(chequeplanilla.SeguimientoPlanillaTo.ID_SEGUIMIENTO, chequeplanilla.ID_PAGO);
            //string a = dt.Rows[0]["hhaha"].ToString();

        }
        private void CargarFrmPagos()
        {
            UserControl frmPago = null;
            //switch (tipoOperacionCobranza)
            //{
            //    case Tipo_Operacion_Cobranza.Env_Rec_Dep:
            //    case Tipo_Operacion_Cobranza.Deposito:

            frmPago = new FrmPagoDepositoPlla(chequeplanilla.SeguimientoPlanillaTo.ID_SEGUIMIENTO, chequeplanilla.SeguimientoPlanillaTo.ID_PAGO);
            //        break;
            //    case Tipo_Operacion_Cobranza.Transferencia:
            //        break;
            //    default: throw new ArgumentNullException($"Este {tipoOperacionCobranza} no esta implementado");
            //}

            plDatosPagos.Controls.Add(frmPago);

            foreach (Control c in plDatosPagos.Controls)
            {

                foreach (Control c2 in c.Controls)
                {
                    //TextBox tb = c2 as TextBox;
                    //if (null != tb)
                    //{

                    //}
                    c2.Visible = false;
                    return;
                }


                // TextBox tb = c as TextBox;
                //if (null != tb)
                //{

                //}
            }
        }


        private void inhabilitarcontroles()
        {
            lblmensaje.Text = chequeplanilla.SeguimientoPlanillaTo.TEXTODESCRIPTIVOGRILLA;

            dgvPlanillas.Enabled = chequeplanilla.SeguimientoPlanillaTo.INHABILITAR;
            txtObservacionDev.Enabled = chequeplanilla.SeguimientoPlanillaTo.INHABILITAR;
            numTotalAnular.Enabled = chequeplanilla.SeguimientoPlanillaTo.INHABILITAR;
            numNuevoSaldo.Enabled = chequeplanilla.SeguimientoPlanillaTo.INHABILITAR;
            numImporteDevolver.Enabled = chequeplanilla.SeguimientoPlanillaTo.INHABILITAR;
            numSaldoFinalCheq.Enabled = chequeplanilla.SeguimientoPlanillaTo.INHABILITAR;

            if (chequeplanilla.SeguimientoPlanillaTo.INHABILITAR == false)
            {
                DialogResult dr = MessageBox.Show("¿Esta seguro de eliminar esta operación?", "MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                  SeguimientoCheques.Del_operacion = 1;
                }else if (dr == DialogResult.No){
                    SeguimientoCheques.Del_operacion = 0;
                }
                DialogResult = DialogResult.OK;
            }
        }

        private List<DevolucionExcesoEntidad> ObtenerDevolucionExcesoEntidad()
        {

            List<DevolucionExcesoEntidad> lista = new List<DevolucionExcesoEntidad>();


            lista.Add(new DevolucionExcesoEntidad
            {
                ID_DEVOLUCION_EXC = IDDEVOLUCION_EXC,
                ID_SEGUIMIENTO = chequeplanilla.SeguimientoPlanillaTo.ID_SEGUIMIENTO,
                ID_PAGO = chequeplanilla.SeguimientoPlanillaTo.ID_PAGO,
                TIPO_PAGO = chequeplanilla.SeguimientoPlanillaTo.TIPO_PAGO,
                FE_AÑO_SIS = PeriodoSistema.AÑO,
                FE_MES_SIS = PeriodoSistema.MES,
                IMPORTE_DEVOLVER_ENTIDAD = numImporteDevolver.Value,
                OBSERVACION = txtObservacionDev.Text.Trim(),
                ID_ESTADO = (int)CRUD.Insertar,
                USUARIO_CREA = UsuarioSistema.Cod_usu,
                USUARIO_MODIFICA = string.Empty
                //TIPO_PAGO = Tipo_Movimiento_Cheque.Deposito,
                //USUARIO_CREA = SeguimientoCheques.COD_USUARIO,
            });
            return lista;
            //throw new Exception("No se encontró datos de la devolución");
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarAceptar())
                    return;
                //if (tipoOperacionCobranza == Tipo_Operacion_Cobranza.Env_Rec_Dep || tipoOperacionCobranza == Tipo_Operacion_Cobranza.Deposito || tipoOperacionCobranza == Tipo_Operacion_Cobranza.Transferencia)
                //{
                List<DevolucionExcesoEntidad> listaRegistrar = ObtenerDevolucionExcesoEntidad();
                DataTable dtDetalleDevuelto = ObtenerDatosDetalleDevolucion();
                if (IDDEVOLUCION_EXC > 0)
                {
                    if (BLCheque.ActualizaDevolucionDepositoPlla(listaRegistrar))
                    {
                        DialogResult = DialogResult.OK;
                        _ = MessageBox.Show("Devolución grabado correctamente", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //if (BLCheque.GrabarAplicacionExcesoOtrasPlanillas(listaRegistrar, listaActualizar, dtAplicacionReg, dtAplicacionAct, se))
                        //    {
                        //        DialogResult = DialogResult.OK;
                        //       // ListarPlanillasSaldoXCobrar();
                        //        dgvPlanillas.RefreshEdit();
                        //        _ = MessageBox.Show("Aplicación grabado correctamente", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //    }
                        //    else
                        //        _ = MessageBox.Show("Error al grabar.\n Comuníquese con el administrador del sistema", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                else
                {
                    if (BLCheque.GrabarDevolucionDepositoPlla(listaRegistrar, dtDetalleDevuelto))
                    {
                        //DialogResult = DialogResult.OK;




                        DialogResult = DialogResult.OK;



                        _ = MessageBox.Show("Devolución grabado correctamente", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //if (BLCheque.GrabarAplicacionExcesoOtrasPlanillas(listaRegistrar, listaActualizar, dtAplicacionReg, dtAplicacionAct, se))
                        //    {
                        //        DialogResult = DialogResult.OK;
                        //       // ListarPlanillasSaldoXCobrar();
                        //        dgvPlanillas.RefreshEdit();
                        //        _ = MessageBox.Show("Aplicación grabado correctamente", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //    }
                        //    else
                        //        _ = MessageBox.Show("Error al grabar.\n Comuníquese con el administrador del sistema", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }


                }



            }
            catch (Exception ex)
            {
                _ = MessageBox.Show(ex.Message + "\n" + ex.StackTrace, "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool ValidarAceptar()
        {
            //if (dgvPlanillas.Rows.Count == 0)
            //{
            //    _ = MessageBox.Show("No hay planillas seleccionadas", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return false;
            //}

            //if (!dgvPlanillas.Rows.Cast<DataGridViewRow>().Where(x => Convert.ToBoolean(x.Cells["CH"].Value)).Any())
            //{
            //    _ = MessageBox.Show("No hay planillas seleccionadas", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return false;
            //}

            //if (!VerificarSiDepositoRegistradoTesoreria())
            //    return false;

            //if (!ValidarImportesDigitados())
            //    return false;

            return true;
        }
        private bool ValidarEliminarPago()
        {
            return true;
            //DataGridViewRow[] arrRow = dgvPlanillas.Rows.Cast<DataGridViewRow>().Where(x => x.Cells["CH"].Value.ToBoolean()).ToArray();
            //foreach (DataGridViewRow row in arrRow)
            //{
            //    int id = Convert.ToInt32(row.Cells["ID_ENVIO_APL"].Value);
            //    if (BLCheque.VerificarSiDepositoRegistradoTesoreria(id))
            //    {
            //        _ = MessageBox.Show($"El pago de la planilla: {row.Cells["NRO_PLANILLA"].Value}, ya se encuentra registrado en tesorería, no se puede eliminar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return false;
            //    }
            //    return true;
            //}
            //return false;
        }

        private List<DevolucionExcesoEntidad> ObtenerDevolucionExcesoEntidadEliminar()
        {
            List<DevolucionExcesoEntidad> lista = new List<DevolucionExcesoEntidad>();

            lista.Add(new DevolucionExcesoEntidad
            {
                ID_SEGUIMIENTO = chequeplanilla.SeguimientoPlanillaTo.ID_SEGUIMIENTO,
                ID_PAGO = chequeplanilla.SeguimientoPlanillaTo.ID_PAGO,
                TIPO_PAGO = chequeplanilla.SeguimientoPlanillaTo.TIPO_PAGO,
            });

            return lista;
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!ValidarEliminarPago())
                return;

            DialogResult dr = MessageBox.Show("¿Esta seguro de eliminar la devolución?", "MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {

                //ID_SEGUIMIENTO = chequeplanilla.SeguimientoPlanillaTo.ID_SEGUIMIENTO,
                //ID_PAGO = chequeplanilla.SeguimientoPlanillaTo.ID_PAGO,
                //TIPO_PAGO = chequeplanilla.SeguimientoPlanillaTo.TIPO_PAGO,

                List<DevolucionExcesoEntidad> reg = ObtenerDevolucionExcesoEntidadEliminar();

                if (BLCheque.EliminarDevolucionExcesoEntidad(reg))
                {
                    DialogResult = DialogResult.OK;
                    //  ListarPlanillasSaldoXCobrar();
                    //ActualizarSaldoDisponible();
                    _ = MessageBox.Show("Eliminado Correctamente", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    _ = MessageBox.Show("Error al eliminar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvPlanillas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dgvPlanillas.Columns[e.ColumnIndex].Name == "CH")
            {
                ActualizarSaldoDisponible();
            }

        }
        private void ActualizarSaldoDisponible()
        {
            decimal importe = 0;
            foreach (DataGridViewRow row in dgvPlanillas.Rows)
            {
                if (Convert.ToBoolean(row.Cells["CH"].Value))
                {
                    importe += Convert.ToDecimal(row.Cells["IMPORTE_APLICADO"].Value);
                }
            }

            numTotalAnular.Value = importe;
            numNuevoSaldo.Value = chequeplanilla.SeguimientoPlanillaTo.IMPORTE_NETO - TOTALCHEQUE + importe;
            if (importe == 0)
            {

                numImporteDevolver.Value = chequeplanilla.SeguimientoPlanillaTo.SALDO_X_COBRAR;
            }
            //////else
            {
                numImporteDevolver.Value = chequeplanilla.SeguimientoPlanillaTo.IMPORTE_NETO - TOTALCHEQUE + importe;
            }

            numSaldoFinalCheq.Value = numNuevoSaldo.Value.ToDecimal() - numImporteDevolver.Value.ToDecimal();
        }


        private void numImporteDevolver_ValueChanged(object sender, EventArgs e)
        {
            //decimal SaldoActual = Convert.ToDecimal(numSaldoActual.Value);
            //decimal ImporteDevolver = Convert.ToDecimal(numImporteDevolver.Value);
            //numSaldoDisponible.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES((SaldoActual - ImporteDevolver).ToString());
            //> numNuevoSaldo.Value = chequeplanilla.SeguimientoPlanillaTo.IMPORTE_NETO - numTotalAnular.Value;
            numSaldoFinalCheq.Value = numNuevoSaldo.Value.ToDecimal() - numImporteDevolver.Value.ToDecimal();
            //decimal ci = txt_ci.Text.Trim() == "" ? 0 : Convert.ToDecimal(txt_ci.Text.Trim());
        }



        private void DgvPlanillas_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvPlanillas.IsCurrentCellDirty)
            {
                dgvPlanillas.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void txtObservacionDev_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmDevolucionExcesoEntidad_Shown(object sender, EventArgs e)
        {
            inhabilitarcontroles();
        }




        //private bool VerificarSiDepositoRegistradoTesoreria()
        //{
        //    foreach (DataGridViewRow row in dgvPlanillas.Rows)
        //    {
        //        bool result = BLCheque.VerificarSiDepositoRegistradoTesoreria(row.Cells["ID_ENVIO_APL"].Value.ToInt32());
        //        if (result)
        //        {
        //            string message = tipoOperacionCobranza != Tipo_Operacion_Cobranza.Transferencia ? "Este depósito" : "Esta transferencia";
        //            _ = MessageBox.Show($"{message} ya se encuentra registrado en tesorería, no se puede actualizar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            return false;
        //        }
        //    }
        //    return true;
        //}
        //private bool ValidarImportesDigitados()
        //{
        //    DataGridViewRow[] arrRow = dgvPlanillas.Rows.Cast<DataGridViewRow>().Where(x => x.Cells["CH"].Value.ToBoolean()).ToArray();
        //    foreach (DataGridViewRow row in arrRow)
        //    {
        //        if (row.Cells["IMPORTE_APLICAR"].Value.ToDecimal() <= 0)
        //        {
        //            _ = MessageBox.Show($"El importe a aplicar de la planilla {row.Cells["NRO_PLANILLA"].Value} debe ser mayor a cero", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            return false;
        //        }
        //    }
        //    return true;
        //}

    }
}