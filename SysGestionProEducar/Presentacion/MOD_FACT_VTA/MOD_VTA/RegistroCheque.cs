using System;
using System.Data;
using System.Windows.Forms;
using BLL;
using Entidades;
using static Entidades.ConstClass;

namespace Presentacion.MOD_FACT_VTA.MOD_VTA
{
    public partial class RegistroCheque : Form
    {
        private readonly int ID_SEGUIMIENTO, ID;
        private readonly string nombrePC, nroPlanilla, nroPllaEnv, codPtoCob;
        private readonly Tipo_Movimiento_Cheque tipoMovimientoCheque;
        public RegistroCheque(int id, Tipo_Movimiento_Cheque tipo, int idSeguimiento, string nombrePC, string nroPlanilla, string nroPllaEnv, string codPtoCob)
        {
            InitializeComponent();
            KeyDown += new KeyEventHandler(NextControl);
            ID_SEGUIMIENTO = idSeguimiento;
            ID = id;
            tipoMovimientoCheque = tipo;
            this.nombrePC = nombrePC;
            this.nroPlanilla = nroPlanilla;
            this.nroPllaEnv = nroPllaEnv;
            this.codPtoCob = codPtoCob;
        }

        public RegistroCheque(int id, int idSeguimiento, string nombrePC, string nroPlanilla, string nroPllaEnv)
        {
            InitializeComponent();
            KeyDown += new KeyEventHandler(NextControl);
            ID_SEGUIMIENTO = idSeguimiento;
            this.nombrePC = nombrePC;
            this.nroPlanilla = nroPlanilla;
            this.nroPllaEnv = nroPllaEnv;
            ID = id;
        }

        private static readonly TipoMonedaBLL BLTipoMoneda = new TipoMonedaBLL();
        private static readonly TipoDocumentoBLL BLTipoDocumento = new TipoDocumentoBLL();
        private static readonly MaestroBancoBLL BLMaestroBanco = new MaestroBancoBLL();
        private static readonly ChequeBLL BLCheque = new ChequeBLL();


        public int Pas { get; set; }


        private CRUD crud = CRUD.Insertar;
        private Tipo_Movimiento_Cheque tipo = Tipo_Movimiento_Cheque.Envio;
        private int ID_ENVIO, ID_RECEPCION, ID_DEPOSITO, ID_TRANSFERENCIA;
        private int ID_ESTADO_CHEQUE = CHEQUE_ENVIADO;
        private int ac;
        private Resultado_Cheque resulCheque;
        private static decimal IMPORTE;

        private void RegistroCheque_Load(object sender, EventArgs e)
        {
            StartControls();
            InitControls();
            CargarTipoMoneda();
            CargarTipoDocumento();
            CargarBanco();
            ObtenerChequeXPlanilla();
        }

        private void StartControls()
        {
            numImporteDep1.DecimalPlaces = 2;
            numImporteDep1.Maximum = decimal.MaxValue;
            numImporteDep1.ThousandsSeparator = true;
            numImporteRecep.DecimalPlaces = 2;
            numImporteRecep.Maximum = decimal.MaxValue;
            numImporteRecep.ThousandsSeparator = true;
            numImporteTrans.Maximum = decimal.MaxValue;
            numImporteTrans.ThousandsSeparator = true;
            numImporteTrans.DecimalPlaces = 2;
            numImporteDep2.DecimalPlaces = 2;
            numImporteDep2.Maximum = decimal.MaxValue;
            numImporteDep2.ThousandsSeparator = true;
            numImpVer1.DecimalPlaces = 2;
            numImpVer1.Maximum = decimal.MaxValue;
            numImpVer1.ThousandsSeparator = true;
            numImpVer2.DecimalPlaces = 2;
            numImpVer2.Maximum = decimal.MaxValue;
            numImpVer2.ThousandsSeparator = true;
            numImpVer3.DecimalPlaces = 2;
            numImpVer3.Maximum = decimal.MaxValue;
            numImpVer3.ThousandsSeparator = true;
            numDiferencia1.DecimalPlaces = 2;
            numDiferencia1.ThousandsSeparator = true;
            numDiferencia1.Maximum = decimal.MaxValue;
            numDiferencia1.Minimum = decimal.MinValue;
            numDiferencia1.ReadOnly = true;
            numDiferencia2.DecimalPlaces = 2;
            numDiferencia2.ThousandsSeparator = true;
            numDiferencia2.Maximum = decimal.MaxValue;
            numDiferencia2.Minimum = decimal.MinValue;
            numDiferencia2.ReadOnly = true;
            numDiferencia3.DecimalPlaces = 2;
            numDiferencia3.ThousandsSeparator = true;
            numDiferencia3.Maximum = decimal.MaxValue;
            numDiferencia3.Minimum = decimal.MinValue;
            numDiferencia3.ReadOnly = true;

            FormatDecimal(numImpPlla1);
            FormatDecimal(numImpPlla2);
            FormatDecimal(numImpPlla3);

            cboMonedaDep1.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMonedaRecep.DropDownStyle = ComboBoxStyle.DropDownList;
            cboBancoDep1.DropDownStyle = ComboBoxStyle.DropDownList;
            cboBancoDep2.DropDownStyle = ComboBoxStyle.DropDownList;
            cboBancoDestTran.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMonedaDep2.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMonedaTrans.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTipoDocEnvio.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMonedaDep1.Enabled = false;
            cboMonedaDep2.Enabled = false;
            cboMonedaTrans.Enabled = false;

            btnEliminar.Visible = false;
            btnEliminar2.Visible = false;
            btnEliminarTrans.Visible = false;
            btnActualizar1.Visible = false;
            btnActualizar2.Visible = false;
            btnActualizarTran.Visible = false;

            gbRecepcion.Enabled = false;
            gbDeposito.Enabled = false;
            gbVerficacion1.Enabled = false;
            gbVerificacion2.Enabled = false;
            gbVerificacion3.Enabled = false;

            chkNo1.Checked = true;
            chkNo2.Checked = true;
            chkNo3.Checked = true;

            txtNroCuentaDep1.ReadOnly = true;
            txtNroCuentaDep2.ReadOnly = true;
            txtNroCtaDstTran.ReadOnly = true;
        }

        private void InitControls()
        {
            txtRepresentateDep1.Text = nombrePC;
            txtRepresentanteEnvio.Text = nombrePC;
            txtRepresentanteTrans.Text = nombrePC;
            Text = "REGISTRO CHEQUE           Punto de Cobranza : " + nombrePC + "       Nro Planilla : " + nroPlanilla;
        }

        private void NextControl(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.SendWait("{TAB}");
            }
        }

        private void FormatDecimal(NumericUpDown numeric)
        {
            numeric.DecimalPlaces = 2;
            numeric.Maximum = decimal.MaxValue;
            numeric.ThousandsSeparator = true;
        }

        private void CargarTipoMoneda()
        {
            DataTable dt = BLTipoMoneda.ListaMoneda();
            cboMonedaDep1.DataSource = dt;
            cboMonedaDep1.DisplayMember = "Desc_moneda";
            cboMonedaDep1.ValueMember = "IdMoneda";

            cboMonedaRecep.DataSource = dt;
            cboMonedaRecep.DisplayMember = "Desc_moneda";
            cboMonedaRecep.ValueMember = "IdMoneda";

            cboMonedaDep2.DataSource = dt;
            cboMonedaDep2.DisplayMember = "Desc_moneda";
            cboMonedaDep2.ValueMember = "IdMoneda";

            cboMonedaTrans.DataSource = dt;
            cboMonedaTrans.DisplayMember = "Desc_moneda";
            cboMonedaTrans.ValueMember = "IdMoneda";

            cboMonedaDep1.SelectedValue = 4;
            cboMonedaRecep.SelectedValue = 4;
            cboMonedaDep2.SelectedValue = 4;
            cboMonedaTrans.SelectedValue = 4;
        }

        private void CargarTipoDocumento()
        {
            cboTipoDocEnvio.DataSource = BLTipoDocumento.ListarTipoDocumento();
            cboTipoDocEnvio.ValueMember = "idDocumento";
            cboTipoDocEnvio.DisplayMember = "desc_doc";
        }

        private void CargarBanco()
        {
            DataTable dt = BLMaestroBanco.ListarMaestroBanco();
            DataTable dt2 = dt.Copy();
            DataTable dt3 = dt.Copy();

            cboBancoDep1.ValueMember = "codigo";
            cboBancoDep1.DisplayMember = "Descripcion";
            cboBancoDep1.DataSource = dt;

            cboBancoDep2.ValueMember = "codigo";
            cboBancoDep2.DisplayMember = "Descripcion";
            cboBancoDep2.DataSource = dt2;

            cboBancoDestTran.ValueMember = "codigo";
            cboBancoDestTran.DisplayMember = "Descripcion";
            cboBancoDestTran.DataSource = dt3;
        }

        private void ObtenerChequeXPlanilla()
        {
            try
            {
                if (tipoMovimientoCheque == Tipo_Movimiento_Cheque.Envio)
                {
                    MostrarDatosEnvioRecepcion();
                    MostrarDatosDeposito();
                }
                else if (tipoMovimientoCheque == Tipo_Movimiento_Cheque.Deposito)
                {
                    MostrarDatosDeposito();
                }
                else if (tipoMovimientoCheque == Tipo_Movimiento_Cheque.Transferencia)
                {
                    MostrarDatosTransferencia();
                }

                if (Pas == 1 || tipoMovimientoCheque == 0)
                {
                    btnActualizar1.Visible = Pas == 1;
                    btnActualizar2.Visible = Pas == 1;
                    btnActualizarTran.Visible = Pas == 1;
                    btnAprobarDep1.Visible = Pas == 1;
                    btnAprobarDep2.Visible = Pas == 1;
                    btnAprobarTrans.Visible = Pas == 1;
                }
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show(ex.Message + "\n" + ex.StackTrace, "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarDatosEnvioRecepcion()
        {
            DataTable dtEnvio = BLCheque.ObtenerEnvioChequeXIdSeguimiento(ID_SEGUIMIENTO, ID);
            DataTable dtRecepcion = BLCheque.ObtenerRecepcionChequeXIdSeguimiento(ID_SEGUIMIENTO, ID);
            txtEmpCourEnvio.Focus();
            if (dtEnvio != null && dtEnvio.Rows.Count > 0)
            {
                tipo = Tipo_Movimiento_Cheque.Recepcion;
                ac = 1;
                ID_ESTADO_CHEQUE = CHEQUE_RECEPCIONADO;
                plNumImpPlla3.SelectedIndex = 1;
                ID_ENVIO = Convert.ToInt32(dtEnvio.Rows[0]["ID_ENVIO"]);
                dtFechaEnvio.Value = Convert.ToDateTime(dtEnvio.Rows[0]["FECHA_ENVIO"]);
                txtEmpCourEnvio.Text = dtEnvio.Rows[0]["EMPRESA"].ToString();
                cboTipoDocEnvio.SelectedValue = dtEnvio.Rows[0]["ID_DOCUMENTO"];
                txtNroDocEnvio.Text = dtEnvio.Rows[0]["NRO_DOCUMENTO"].ToString();
                txtRepresentanteEnvio.Text = dtEnvio.Rows[0]["REPRESENTANTE"].ToString();
                txtResponsableEnvio.Text = dtEnvio.Rows[0]["RESPONSABLE"].ToString();
                txtRepreRecep.Text = dtEnvio.Rows[0]["REPRESENTANTE"].ToString();
                txtRespRecep.Text = dtEnvio.Rows[0]["RESPONSABLE"].ToString();
                gbRecepcion.Enabled = true;
                txtNroChequeRecep.Focus();
            }

            if (dtRecepcion != null && dtRecepcion.Rows.Count > 0)
            {
                tipo = Tipo_Movimiento_Cheque.Deposito;
                ID_ESTADO_CHEQUE = CHEQUE_DEPOSITADO;
                ID_RECEPCION = Convert.ToInt32(dtRecepcion.Rows[0]["ID_RECEPCION"]);
                dtFechaRecepcion.Value = Convert.ToDateTime(dtRecepcion.Rows[0]["FECHA_RECEPCION"]);
                txtBancoRecep.Text = dtRecepcion.Rows[0]["BANCO_ORIGEN"].ToString();
                txtNroChequeRecep.Text = dtRecepcion.Rows[0]["NRO_CHEQUE"].ToString();
                cboMonedaRecep.SelectedValue = dtRecepcion.Rows[0]["ID_MONEDA"];
                numImporteRecep.Value = Convert.ToDecimal(dtRecepcion.Rows[0]["IMPORTE"]);
                txtRepreRecep.Text = dtRecepcion.Rows[0]["REPRESENTANTE"].ToString();
                txtRespRecep.Text = dtRecepcion.Rows[0]["RESPONSABLE"].ToString();
                txtResponsableDep2.Text = dtRecepcion.Rows[0]["RESPONSABLE"].ToString();
                numImporteDep2.Value = Convert.ToDecimal(dtRecepcion.Rows[0]["IMPORTE"]);
                gbDeposito.Enabled = true;
                txtNroOperacionDep2.Focus();
            }
        }

        private void MostrarDatosDeposito()
        {
            DataTable dtDeposito = BLCheque.ObtenerDespositoChequeXIdSeguimiento(ID_SEGUIMIENTO, ID);
            if (dtDeposito != null && dtDeposito.Rows.Count > 0)
            {
                btnRegistrar2.Visible = false;
                btnRegistrar.Visible = false;
                if (ac == 0)
                {
                    plNumImpPlla3.SelectedIndex = 0;
                    ac = 2;
                }
                ID_ESTADO_CHEQUE = CHEQUE_CONFIRMADO;
                ID_DEPOSITO = Convert.ToInt32(dtDeposito.Rows[0]["ID_DEPOSITO"]);
                IMPORTE = Convert.ToDecimal(dtDeposito.Rows[0]["IMPORTE"]);
                resulCheque = Convert.ToInt32(dtDeposito.Rows[0]["ESTADO"]) == 1 ? Resultado_Cheque.Pendiente
                    : Convert.ToInt32(dtDeposito.Rows[0]["ESTADO"]) == 2 ? Resultado_Cheque.Aprobar : Resultado_Cheque.Desaprobar;
                if (plNumImpPlla3.SelectedIndex == 0)
                {
                    dtFechaDep1.Value = Convert.ToDateTime(dtDeposito.Rows[0]["FECHA"]);
                    cboBancoDep1.SelectedValue = dtDeposito.Rows[0]["COD_BANCO"];
                    txtNroOperacionDep1.Text = dtDeposito.Rows[0]["NRO_OPERACION"].ToString();
                    cboMonedaDep1.SelectedValue = dtDeposito.Rows[0]["ID_MONEDA"];
                    numImporteDep1.Value = Convert.ToDecimal(dtDeposito.Rows[0]["IMPORTE"]);
                    txtRepresentateDep1.Text = dtDeposito.Rows[0]["REPRESENTANTE"].ToString();
                    txtObservacionDep1.Text = dtDeposito.Rows[0]["OBSERVACION"].ToString();
                    numImpVer1.Value = string.IsNullOrEmpty(dtDeposito.Rows[0]["IMPORTE_VERIFICADO"].ToString()) ? 0 : Convert.ToDecimal(dtDeposito.Rows[0]["IMPORTE_VERIFICADO"]);
                    if (Pas == 0)
                        btnActualizar1.Visible = true;
                    gbVerficacion1.Enabled = true;
                }
                else if (plNumImpPlla3.SelectedIndex == 1)
                {
                    dtFechaDep2.Value = Convert.ToDateTime(dtDeposito.Rows[0]["FECHA"]);
                    cboBancoDep2.SelectedValue = dtDeposito.Rows[0]["COD_BANCO"];
                    txtNroOperacionDep2.Text = dtDeposito.Rows[0]["NRO_OPERACION"].ToString();
                    cboMonedaDep2.SelectedValue = dtDeposito.Rows[0]["ID_MONEDA"];
                    numImporteDep2.Value = Convert.ToDecimal(dtDeposito.Rows[0]["IMPORTE"]);
                    txtResponsableDep2.Text = dtDeposito.Rows[0]["RESPONSABLE"].ToString();
                    numImpVer2.Value = string.IsNullOrEmpty(dtDeposito.Rows[0]["IMPORTE_VERIFICADO"].ToString()) ? 0 : Convert.ToDecimal(dtDeposito.Rows[0]["IMPORTE_VERIFICADO"]);
                    if (Pas == 0)
                        btnActualizar2.Visible = true;
                    gbVerificacion2.Enabled = true;
                }
            }
            else
            {
                btnAprobarDep1.Visible = false;
                btnAprobarDep2.Visible = false;
            }
        }

        private void MostrarDatosTransferencia()
        {
            DataTable dtTransferencia = BLCheque.ObtenerTransChequeXIdSeguimiento(ID_SEGUIMIENTO, ID);
            if (dtTransferencia != null && dtTransferencia.Rows.Count > 0)
            {
                ac = 3;
                plNumImpPlla3.SelectedIndex = 2;
                btnRegistrarTrans.Visible = false;
                ID_TRANSFERENCIA = Convert.ToInt32(dtTransferencia.Rows[0]["ID_TRANSFERENCIA"]);
                IMPORTE = Convert.ToDecimal(dtTransferencia.Rows[0]["IMPORTE"]);
                resulCheque = Convert.ToInt32(dtTransferencia.Rows[0]["ESTADO"]) == 1
                    ? Resultado_Cheque.Pendiente
                    : Convert.ToInt32(dtTransferencia.Rows[0]["ESTADO"]) == 2
                    ? Resultado_Cheque.Aprobar
                    : Resultado_Cheque.Desaprobar;
                txtBancoOriTran.Text = dtTransferencia.Rows[0]["BANCO_ORIGEN"].ToString();
                txtNroCtaOriTran.Text = dtTransferencia.Rows[0]["NRO_CUENTA_ORIGEN"].ToString();
                cboBancoDestTran.SelectedValue = dtTransferencia.Rows[0]["COD_BANCO_DEST"];
                txtNroOperTrans.Text = dtTransferencia.Rows[0]["NRO_OPERACION"].ToString();
                dtFechaTrans.Value = Convert.ToDateTime(dtTransferencia.Rows[0]["FECHA_TRANSFERENCIA"]);
                cboMonedaTrans.SelectedValue = dtTransferencia.Rows[0]["ID_MONEDA"];
                numImporteTrans.Value = Convert.ToDecimal(dtTransferencia.Rows[0]["IMPORTE"]);
                txtRepresentanteTrans.Text = dtTransferencia.Rows[0]["REPRESENTANTE"].ToString();
                txtObsTrans.Text = dtTransferencia.Rows[0]["OBSERVACION"].ToString();
                numImpVer3.Value = string.IsNullOrEmpty(dtTransferencia.Rows[0]["IMPORTE_VERIFICADO"].ToString()) ? 0 : Convert.ToDecimal(dtTransferencia.Rows[0]["IMPORTE_VERIFICADO"]);
                btnActualizarTran.Visible = true;
                gbVerificacion3.Enabled = true;
            }
            else
                btnAprobarTrans.Visible = false;
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                ToolStripButton button = sender as ToolStripButton;
                if (ValidarDatosGrabar(button))
                {
                    DialogResult dr = MessageBox.Show("¿Esta seguro de grabar?", "MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dr == DialogResult.Yes)
                    {
                        if (plNumImpPlla3.SelectedIndex == 0)
                        {
                            tipo = Tipo_Movimiento_Cheque.Deposito;
                            ID_ESTADO_CHEQUE = CHEQUE_DEPOSITADO;
                        }
                        ChequesPlanillaTo cheque = ObtenerDatosGrabar();
                        if (crud == CRUD.Insertar)
                        {
                            _ = BLCheque.RegistrarChequePlanilla(cheque, tipo)
                                ? MessageBox.Show("Cheque registrado correctamente", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                : MessageBox.Show("Ocurrió un error al registrar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show(ex.Message + "\n" + ex.StackTrace, "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private ChequesPlanillaTo ObtenerDatosGrabar()
        {
            return new ChequesPlanillaTo
            {
                USUARIO_CREA = SeguimientoCheques.COD_USUARIO,
                TIPO_PAGO = tipo,
                EnvioChequeTo = new EnvioChequeTo
                {
                    ID_ENVIO = ID_ENVIO,
                    FECHA_ENVIO = dtFechaEnvio.Value,
                    EMPRESA = txtEmpCourEnvio.Text,
                    ID_DOCUMENTO = Convert.ToInt32(cboTipoDocEnvio.SelectedValue),
                    NRO_DOCUMENTO = txtNroDocEnvio.Text,
                    REPRESENTANTE = txtRepresentanteEnvio.Text,
                    RESPONSABLE = txtResponsableEnvio.Text
                },
                RecepcionChequeTo = new RecepcionChequeTo
                {
                    ID_RECEPCION = ID_RECEPCION,
                    FECHA_RECEPCION = dtFechaRecepcion.Value,
                    BANCO_ORIGEN = txtBancoRecep.Text,
                    NRO_CHEQUE = txtNroChequeRecep.Text,
                    ID_MONEDA = Convert.ToInt32(cboMonedaRecep.SelectedValue),
                    IMPORTE = numImporteRecep.Value,
                    REPRESENTANTE = txtRepreRecep.Text,
                    RESPONSABLE = txtRespRecep.Text
                },
                DepositoChequeTo = plNumImpPlla3.SelectedIndex == 1 ? new DepositoChequeTo
                {
                    ID_DEPOSITO = ID_DEPOSITO,
                    COD_BANCO = cboBancoDep2.SelectedValue.ToString(),
                    NRO_CHEQUE = txtNroChequeRecep.Text,
                    NRO_OPERACION = txtNroOperacionDep2.Text,
                    FECHA_DEPOSITO = dtFechaDep2.Value,
                    ID_MONEDA = Convert.ToInt32(cboMonedaDep2.SelectedValue),
                    IMPORTE = numImporteDep2.Value,
                    REPRESENTANTE = txtRepreRecep.Text,
                    RESPONSABLE = txtResponsableDep2.Text,
                    OBSERVACION = txtObservacionDep1.Text
                }
                : new DepositoChequeTo
                {
                    ID_DEPOSITO = ID_DEPOSITO,
                    COD_BANCO = cboBancoDep1.SelectedValue.ToString(),
                    NRO_CHEQUE = string.Empty,
                    NRO_OPERACION = txtNroOperacionDep1.Text,
                    FECHA_DEPOSITO = dtFechaDep1.Value,
                    ID_MONEDA = Convert.ToInt32(cboMonedaDep1.SelectedValue),
                    IMPORTE = numImporteDep1.Value,
                    REPRESENTANTE = txtRepresentateDep1.Text,
                    RESPONSABLE = txtRepresentateDep1.Text,
                    OBSERVACION = txtObservacionDep1.Text
                },
                SeguimientoPlanillaTo = new SeguimientoPlanillaTo
                {
                    ID_SEGUIMIENTO = ID_SEGUIMIENTO,
                    NRO_PLANILLA = nroPlanilla,
                    NRO_PLLA_ENV = nroPllaEnv,
                    ID_ESTADO = ID_ESTADO_CHEQUE,
                    USUARIO_CREA = SeguimientoCheques.COD_USUARIO
                }
            };
        }

        private bool ValidarDatosGrabar(ToolStripButton button)
        {
            if (button.Name == btnRegistrar.Name || button.Name == btnAprobarDep1.Name || button.Name == btnActualizar1.Name)
            {
                if (string.IsNullOrEmpty(txtNroOperacionDep1.Text.Trim()))
                {
                    _ = MessageBox.Show("Digite el número de operación", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    _ = txtNroOperacionDep1.Focus();
                    return false;
                }
                else if (Convert.ToInt32(cboMonedaDep1.SelectedValue) == 0)
                {
                    _ = MessageBox.Show("Seleccione el tipo de moneda", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    _ = cboMonedaDep1.Focus();
                    return false;
                }
                else if (numImporteDep1.Value == 0)
                {
                    _ = MessageBox.Show("Digite el importe", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    _ = numImporteDep1.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(txtRepresentateDep1.Text))
                {
                    _ = MessageBox.Show("Digite el representante", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    _ = txtRepresentateDep1.Focus();
                    return false;
                }
            }
            else
            {
                if (tipo == Tipo_Movimiento_Cheque.Envio)
                {
                    if (string.IsNullOrEmpty(txtEmpCourEnvio.Text.Trim()))
                    {
                        _ = MessageBox.Show("Digite el nombre de la empresa o courier", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        _ = txtEmpCourEnvio.Focus();
                        return false;
                    }
                    else if (string.IsNullOrEmpty(txtNroDocEnvio.Text.Trim()))
                    {
                        _ = MessageBox.Show("Digite el número del tipo de documento", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        _ = txtNroDocEnvio.Focus();
                        return false;
                    }
                    else if (string.IsNullOrEmpty(txtRepresentanteEnvio.Text))
                    {
                        _ = MessageBox.Show("Digite el representante", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        _ = txtRepresentanteEnvio.Focus();
                        return false;
                    }
                    else if (string.IsNullOrEmpty(txtResponsableEnvio.Text))
                    {
                        _ = MessageBox.Show("Digite el responsable", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        _ = txtResponsableEnvio.Focus();
                        return false;
                    }
                }
                else if (tipo == Tipo_Movimiento_Cheque.Recepcion)
                {
                    if (string.IsNullOrEmpty(txtBancoRecep.Text))
                    {
                        _ = MessageBox.Show("Digite el banco emisor", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        _ = txtBancoRecep.Focus();
                        return false;
                    }
                    else if (string.IsNullOrEmpty(txtNroChequeRecep.Text))
                    {
                        _ = MessageBox.Show("Digite el número de cheque", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        _ = txtNroChequeRecep.Focus();
                        return false;
                    }
                    else if (Convert.ToInt32(cboMonedaRecep.SelectedValue) == 0)
                    {
                        _ = MessageBox.Show("Seleccione el tipo moneda", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        _ = cboMonedaRecep.Focus();
                        return false;
                    }
                    else if (numImporteRecep.Value == 0)
                    {
                        _ = MessageBox.Show("Digite el importe de recepción", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        _ = numImporteRecep.Focus();
                        return false;
                    }
                    else if (string.IsNullOrEmpty(txtRepreRecep.Text))
                    {
                        _ = MessageBox.Show("Digite el representante de recepción", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        _ = txtRepreRecep.Focus();
                        return false;
                    }
                    else if (string.IsNullOrEmpty(txtRespRecep.Text))
                    {
                        _ = MessageBox.Show("Digite el responsable de recepción", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        _ = txtRespRecep.Focus();
                        return false;
                    }
                }
                else if (tipo == Tipo_Movimiento_Cheque.Deposito)
                {
                    if (string.IsNullOrEmpty(txtNroOperacionDep2.Text))
                    {
                        _ = MessageBox.Show("Didite el número de operación", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        _ = txtNroOperacionDep2.Focus();
                        return false;
                    }
                    else if (Convert.ToInt32(cboMonedaDep2.SelectedValue) == 0)
                    {
                        _ = MessageBox.Show("Seleccione el tipo de moneda", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        _ = cboMonedaDep2.Focus();
                        return false;
                    }
                    else if (numImporteDep2.Value == 0)
                    {
                        _ = MessageBox.Show("Digite el importe", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        _ = numImporteDep2.Focus();
                        return false;
                    }
                    else if (numImporteDep2.Value != numImporteRecep.Value)
                    {
                        _ = MessageBox.Show("El importe de depósito debe ser igual al importe recepcionado", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        _ = numImporteDep2.Focus();
                        return false;
                    }
                    else if (string.IsNullOrEmpty(txtResponsableDep2.Text))
                    {
                        _ = MessageBox.Show("Digite el responsable del depósito", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        _ = txtResponsableDep2.Focus();
                        return false;
                    }
                }
            }
            return true;
        }

        private bool ValidarAprobarCheque()
        {
            if (numImpPlla2.Value == 0)
            {
                _ = MessageBox.Show("Digite el importe cobrado para esta planilla", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private bool ValidarAprobarDeposito()
        {
            if (numImpPlla1.Value == 0)
            {
                _ = MessageBox.Show("El importe cobrado para esta planilla es cero", "!ALERTA¡", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            return true;
        }

        private bool ValidarAprobarTransferencia()
        {
            if (numImpPlla3.Value == 0)
            {
                _ = MessageBox.Show("Digite el importe cobrado para esta planilla", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (DialogResult.Yes == MessageBox.Show("¿Esta seguro que desea eliminar este cheque?", "MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    ChequesPlanillaTo cheque = ObtenerDatosEliminar();
                    _ = BLCheque.EliminarCheque(cheque)
                        ? MessageBox.Show("Cheque eliminado correctamente", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        : MessageBox.Show("Ocurrió un error al actualizar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    crud = CRUD.Insertar;
                    LimpiarControles();
                    if (plNumImpPlla3.SelectedIndex == 0)
                    {
                        btnEliminar.Visible = false;
                        btnRegistrar.Text = "Registrar";
                    }
                    else
                    {
                        btnEliminar2.Visible = false;
                        btnRegistrar2.Text = "Registrar";
                    }
                }
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show(ex.Message + "\n" + ex.StackTrace, "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private ChequesPlanillaTo ObtenerDatosEliminar()
        {
            return new ChequesPlanillaTo
            {
                SeguimientoPlanillaTo = new SeguimientoPlanillaTo
                {
                    ID_SEGUIMIENTO = ID_SEGUIMIENTO,
                    ID_ESTADO = CHEQUE_DEPOSITADO
                }
            };
        }

        private void LimpiarControles()
        {
            foreach (Control control in plNumImpPlla3.TabPages[plNumImpPlla3.SelectedIndex].Controls)
            {
                if (control is TextBox text)
                {
                    text.Clear();
                }
                if (control is NumericUpDown num)
                    num.Value = 0;
            }
        }

        private void BtnAprobarTrans_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarDatosTrans() && ValidarAprobarTransferencia())
                {
                    if (chkSi3.Checked)
                        _ = MessageBox.Show("El importe transferido es igual al importe verificado, por lo tanto se aprobará el cheque", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                        _ = MessageBox.Show("El importe transferido es diferente al importe verificado, por lo tanto no se aprobará este cheque", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    if (ID_TRANSFERENCIA != 0
                    && DialogResult.Yes == MessageBox.Show("¿Esta seguro de grabar?", "MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {
                        ChequesPlanillaTo cheque = ObtenerDatosAprobarTrans();
                        if (cheque != null)
                        {
                            _ = BLCheque.AprobarTransferenciaSegui(cheque, chkSi3.Checked)
                                ? MessageBox.Show("Transferencia grabado correctamente", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                : MessageBox.Show("Ocurrió un erro inesperado", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    Close();
                }
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show(ex.Message + "\n" + ex.StackTrace, "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private ChequesPlanillaTo ObtenerDatosAprobarTrans()
        {
            DataTable dt = BLCheque.ObtenerPlanillasPendientesCheque(codPtoCob, nroPllaEnv, ID_SEGUIMIENTO);
            if (dt is null || dt.Rows.Count != 1)
            {
                _ = MessageBox.Show("Error al obtener datos de la planilla. \n Comuniquese con el administrador de sistemas",
                    "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            return new ChequesPlanillaTo
            {
                USUARIO_CREA = SeguimientoCheques.COD_USUARIO,
                TransferenciaSeguiTo = new TransferenciaSeguiTo
                {
                    ID_TRANSFERENCIA = ID_TRANSFERENCIA,
                    IMPORTE_VERIFICADO = numImpVer3.Value,
                    IMPORTE_PROPIO_PLLA = numImpPlla3.Value
                },
                SeguimientoPlanillaTo = new SeguimientoPlanillaTo
                {
                    ID_SEGUIMIENTO = ID_SEGUIMIENTO,
                    ID_ESTADO = CHEQUE_CONFIRMADO,
                    IMPORTE_EXC_INI = ObtenerImporteExcesoIni(),
                    IMPORTE_EXC_DOC = ObtenerImporteExcesoDoc(),
                    IMPORTE_VERIFICADO = ObtenerImporteTotalVerificado(),
                    SALDO_X_COBRAR = ObtenerSaldoXCobrar(),
                    USUARIO_CREA = SeguimientoCheques.COD_USUARIO
                }
            };

            decimal ObtenerImporteExcesoIni()
            {
                decimal saldo = Convert.ToDecimal(dt.Rows[0]["IMPORTE_NETO_ENTIDAD"]) - Convert.ToDecimal(dt.Rows[0]["IMP_VERIFICADO"]) -
                    numImpVer3.Value;
                return saldo >= 0 ? 0 : saldo * -1;
            }

            decimal ObtenerImporteExcesoDoc()
            {
                decimal saldo = Convert.ToDecimal(dt.Rows[0]["IMPORTE_NETO_ENTIDAD"]) - Convert.ToDecimal(dt.Rows[0]["IMP_VERIFICADO"]) -
                    numImpVer3.Value - Convert.ToDecimal(dt.Rows[0]["IMPORTE_APLICADO_REC"])
                    + Convert.ToDecimal(dt.Rows[0]["IMPORTE_APLICADO_ENV"]) + Convert.ToDecimal(dt.Rows[0]["IMPORTE_REEMBOLSO"]);
                return saldo >= 0 ? 0 : saldo * -1;
            }

            decimal ObtenerImporteTotalVerificado()
            {
                return Convert.ToDecimal(dt.Rows[0]["IMP_VERIFICADO"]) + numImpVer3.Value;
            }

            decimal ObtenerSaldoXCobrar()
            {
                decimal saldo = Convert.ToDecimal(dt.Rows[0]["IMPORTE_NETO_ENTIDAD"]) - Convert.ToDecimal(dt.Rows[0]["IMP_VERIFICADO"]) -
                    numImpVer3.Value - Convert.ToDecimal(dt.Rows[0]["IMPORTE_APLICADO_REC"])
                    + Convert.ToDecimal(dt.Rows[0]["IMPORTE_APLICADO_ENV"]) + Convert.ToDecimal(dt.Rows[0]["IMPORTE_REEMBOLSO"]);
                return saldo >= 0 ? saldo : 0;
            }
        }

        private void BtnRegistrarTrans_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarDatosTrans())
                {
                    DialogResult dr = MessageBox.Show("¿Esta seguro de grabar?", "MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dr == DialogResult.Yes)
                    {
                        ChequesPlanillaTo cheque = ObtenerDatosTransferencia();
                        if (crud == CRUD.Insertar)
                        {
                            _ = BLCheque.RegistrarChequePlanilla(cheque, Tipo_Movimiento_Cheque.Transferencia)
                                ? MessageBox.Show("Cheque registrado correctamente", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                : MessageBox.Show("Ocurrió un error al registrar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show(ex.Message + "\n" + ex.StackTrace, "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private ChequesPlanillaTo ObtenerDatosTransferencia()
        {
            return new ChequesPlanillaTo
            {
                TIPO_PAGO = Tipo_Movimiento_Cheque.Transferencia,
                USUARIO_CREA = SeguimientoCheques.COD_USUARIO,
                TransferenciaSeguiTo = new TransferenciaSeguiTo
                {
                    ID_TRANSFERENCIA = ID_TRANSFERENCIA,
                    NRO_OPERACION = txtNroOperTrans.Text,
                    BANCO_ORIGEN = txtBancoOriTran.Text,
                    NRO_CTA_ORIGEN = txtNroCtaOriTran.Text,
                    COD_BANCO_DEST = cboBancoDestTran.SelectedValue.ToString(),
                    FECHA_TRANSFERENCIA = dtFechaTrans.Value,
                    ID_MONEDA = Convert.ToInt32(cboMonedaTrans.SelectedValue),
                    IMPORTE = numImporteTrans.Value,
                    REPRESENTANTE = txtRepresentanteTrans.Text,
                    OBSERVACION = txtObsTrans.Text
                },
                SeguimientoPlanillaTo = new SeguimientoPlanillaTo
                {
                    ID_SEGUIMIENTO = ID_SEGUIMIENTO,
                    NRO_PLANILLA = nroPlanilla,
                    NRO_PLLA_ENV = nroPllaEnv,
                    ID_ESTADO = CHEQUE_TRANS,
                    USUARIO_CREA = SeguimientoCheques.COD_USUARIO
                }
            };
        }

        private bool ValidarDatosTrans()
        {
            if (string.IsNullOrEmpty(txtBancoOriTran.Text))
            {
                _ = MessageBox.Show("Digite el banco origen", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _ = txtBancoOriTran.Focus();
                return false;
            }
            else if (Convert.ToInt32(cboMonedaTrans.SelectedValue) == 0)
            {
                _ = MessageBox.Show("Seleccione el tipo de moneda", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _ = cboMonedaTrans.Focus();
                return false;
            }
            else if (numImporteTrans.Value == 0)
            {
                _ = MessageBox.Show("Digite el importe", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _ = numImporteTrans.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtRepresentanteTrans.Text))
            {
                _ = MessageBox.Show("Digite el representante", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _ = txtRepresentanteTrans.Focus();
                return false;
            }
            return true;
        }

        private void CboBancoDep1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboBancoDep1.DataSource != null)
            {
                DataTable dt = BLMaestroBanco.ObtenerMaestroBancoXCodBanco(cboBancoDep1.SelectedValue.ToString());
                txtNroCuentaDep1.Text = dt.Rows[0]["NROCUENTA"].ToString();
                cboMonedaDep1.SelectedValue = Convert.ToInt32(dt.Rows[0]["IdMoneda"]);
            }
        }

        private void CboBancoDep2_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboBancoDep2.DataSource != null)
            {
                DataTable dt = BLMaestroBanco.ObtenerMaestroBancoXCodBanco(cboBancoDep2.SelectedValue.ToString());
                txtNroCuentaDep2.Text = dt.Rows[0]["NROCUENTA"].ToString();
                cboMonedaDep2.SelectedValue = Convert.ToInt32(dt.Rows[0]["IdMoneda"]);
            }
        }

        private void CboBancoDestTran_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboBancoDestTran.DataSource != null)
            {
                DataTable dt = BLMaestroBanco.ObtenerMaestroBancoXCodBanco(cboBancoDestTran.SelectedValue.ToString());
                txtNroCtaDstTran.Text = dt.Rows[0]["NROCUENTA"].ToString();
                cboMonedaTrans.SelectedValue = Convert.ToInt32(dt.Rows[0]["IdMoneda"]);
            }
        }

        private void BtnActualizarTran_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarDatosTrans())
                {
                    if (Pas == 1)
                    {
                        HELPERS.Forms.FrmConfirmar frmConfirmar = new HELPERS.Forms.FrmConfirmar(TIPO_CONFIRMAR.OTROS)
                        {
                            StartPosition = FormStartPosition.CenterParent
                        };
                        frmConfirmar.EventClick += FrmConfirmar3_EventClick;
                        frmConfirmar.ShowDialog();
                    }
                    else
                    {
                        FrmConfirmar3_EventClick(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show(ex.Message + "\n" + ex.StackTrace, "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmConfirmar3_EventClick(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("¿Esta seguro de actualizar esta transferencia?", "MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                ChequesPlanillaTo cheque = ObtenerDatosTransferencia();
                _ = BLCheque.ActualizarTransferenciaCheque(cheque)
                    ? MessageBox.Show("Transferencia actualizado correctamente", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    : MessageBox.Show("Ocurrió un error al actualizar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MostrarDatosTransferencia();
            }
        }

        private void BtnActualizar2_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarDatosEnvioRecepDepos())
                {
                    if (Pas == 1)
                    {
                        HELPERS.Forms.FrmConfirmar frmConfirmar = new HELPERS.Forms.FrmConfirmar(TIPO_CONFIRMAR.OTROS)
                        {
                            StartPosition = FormStartPosition.CenterParent
                        };
                        frmConfirmar.EventClick += FrmConfirmar2_EventClick;
                        frmConfirmar.ShowDialog();
                    }
                    else
                    {
                        FrmConfirmar2_EventClick(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show(ex.Message + "\n" + ex.StackTrace, "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmConfirmar2_EventClick(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("¿Esta seguro de actualizar este cheque?", "MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                ChequesPlanillaTo cheque = ObtenerDatosGrabar();
                _ = BLCheque.ActualizarChequeTransporteCourier(cheque)
                    ? MessageBox.Show("Cheque actualizado correctamente", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    : MessageBox.Show("Ocurrió un error al actualizar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MostrarDatosEnvioRecepcion();
                MostrarDatosDeposito();
            }
        }

        private bool ValidarDatosEnvioRecepDepos()
        {
            if (string.IsNullOrEmpty(txtEmpCourEnvio.Text.Trim()))
            {
                _ = MessageBox.Show("Digite el nombre de la empresa o courier", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _ = txtEmpCourEnvio.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtNroDocEnvio.Text.Trim()))
            {
                _ = MessageBox.Show("Digite el número del tipo de documento", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _ = txtNroDocEnvio.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtRepresentanteEnvio.Text))
            {
                _ = MessageBox.Show("Digite el representante", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _ = txtRepresentanteEnvio.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtResponsableEnvio.Text))
            {
                _ = MessageBox.Show("Digite el responsable", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _ = txtResponsableEnvio.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtBancoRecep.Text))
            {
                _ = MessageBox.Show("Digite el banco emisor", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _ = txtBancoRecep.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtNroChequeRecep.Text))
            {
                _ = MessageBox.Show("Digite el número de cheque", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _ = txtNroChequeRecep.Focus();
                return false;
            }
            else if (Convert.ToInt32(cboMonedaRecep.SelectedValue) == 0)
            {
                _ = MessageBox.Show("Seleccione el tipo moneda", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _ = cboMonedaRecep.Focus();
                return false;
            }
            else if (numImporteRecep.Value == 0)
            {
                _ = MessageBox.Show("Digite el importe de recepción", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _ = numImporteRecep.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtRepreRecep.Text))
            {
                _ = MessageBox.Show("Digite el representante de recepción", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _ = txtRepreRecep.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtRespRecep.Text))
            {
                _ = MessageBox.Show("Digite el responsable de recepción", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _ = txtRespRecep.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtNroOperacionDep2.Text))
            {
                _ = MessageBox.Show("Didite el número de operación", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _ = txtNroOperacionDep2.Focus();
                return false;
            }
            else if (Convert.ToInt32(cboMonedaDep2.SelectedValue) == 0)
            {
                _ = MessageBox.Show("Seleccione el tipo de moneda", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _ = cboMonedaDep2.Focus();
                return false;
            }
            else if (numImporteDep2.Value == 0)
            {
                _ = MessageBox.Show("Digite el importe", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _ = numImporteDep2.Focus();
                return false;
            }
            else if (numImporteDep2.Value != numImporteRecep.Value)
            {
                _ = MessageBox.Show("El importe depositado debe ser igual al importe recepcionado", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _ = numImporteDep2.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtResponsableDep2.Text))
            {
                _ = MessageBox.Show("Digite el responsable del depósito", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _ = txtResponsableDep2.Focus();
                return false;
            }
            return true;
        }

        private void BtnActualizar1_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarDatosGrabar(btnActualizar1))
                {
                    if(Pas == 1)
                    {
                        HELPERS.Forms.FrmConfirmar frmConfirmar = new HELPERS.Forms.FrmConfirmar(TIPO_CONFIRMAR.OTROS)
                        {
                            StartPosition = FormStartPosition.CenterParent
                        };
                        frmConfirmar.EventClick += FrmConfirmar_EventClick;
                        frmConfirmar.ShowDialog();
                    }
                    else
                    {
                        FrmConfirmar_EventClick(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show(ex.Message + "\n" + ex.StackTrace, "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmConfirmar_EventClick(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("¿Esta seguro de actualizar este cheque?", "MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                ChequesPlanillaTo cheque = ObtenerDatosGrabar();
                _ = BLCheque.ActualizarChequeDeposito(cheque)
                    ? MessageBox.Show("Cheque actualizado correctamente", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    : MessageBox.Show("Ocurrió un error al actualizar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MostrarDatosDeposito();
            }
        }

        private void ChkSi1_Click(object sender, EventArgs e)
        {
            fac = true;
            if (chkSi1.Checked)
            {
                chkNo1.Checked = false;
                numImpVer1.Value = IMPORTE;
                numImpVer1.ReadOnly = true;
            }
            else
                chkSi1.Checked = true;
        }

        private void ChkNo1_Click(object sender, EventArgs e)
        {
            if (chkNo1.Checked)
            {
                chkSi1.Checked = false;
                numImpVer1.ReadOnly = false;
            }
            else
                chkNo1.Checked = true;
        }

        private void NumImpVer1_ValueChanged(object sender, EventArgs e)
        {
            DiferenciaImportes(chkSi1, chkNo1, numImpVer1, numDiferencia1, IMPORTE);
        }

        private void ChkSi2_Click(object sender, EventArgs e)
        {
            fac = true;
            if (chkSi2.Checked)
            {
                chkNo2.Checked = false;
                numImpVer2.Value = IMPORTE;
                numImpVer2.ReadOnly = true;
            }
            else
                chkSi2.Checked = true;
        }

        private void ChkNo2_Click(object sender, EventArgs e)
        {
            if (chkNo2.Checked)
            {
                chkSi2.Checked = false;
                numImpVer2.ReadOnly = false;
            }
            else
                chkNo2.Checked = true;
        }

        private void NumImpVer2_ValueChanged(object sender, EventArgs e)
        {
            DiferenciaImportes(chkSi2, chkNo2, numImpVer2, numDiferencia2, IMPORTE);
        }

        private void ChkSi3_Click(object sender, EventArgs e)
        {
            fac = true;
            if (chkSi3.Checked)
            {
                chkNo3.Checked = false;
                numImpVer3.Value = IMPORTE;
                numImpVer3.ReadOnly = true;
            }
            else
                chkSi3.Checked = true;
        }

        private void ChkNo3_Click(object sender, EventArgs e)
        {
            if (chkNo3.Checked)
            {
                chkSi3.Checked = false;
                numImpVer3.ReadOnly = false;
            }
            else
                chkNo3.Checked = true;
        }

        private void NumImpVer3_ValueChanged(object sender, EventArgs e)
        {
            DiferenciaImportes(chkSi3, chkNo3, numImpVer3, numDiferencia3, IMPORTE);
        }

        private bool fac;
        private void DiferenciaImportes(CheckBox si, CheckBox no, NumericUpDown numImporteVerificado, NumericUpDown numDiferencia, decimal importe)
        {
            si.Checked = importe == numImporteVerificado.Value;
            no.Checked = !si.Checked;
            numDiferencia.Value = importe - numImporteVerificado.Value;
            if (!fac && no.Checked && resulCheque == Resultado_Cheque.Pendiente)
            {
                no.Checked = true;
                si.Checked = false;
            }
            numImporteVerificado.ReadOnly = si.Checked;
            fac = true;
        }

        private void BtnAprobarDep1_Click(object sender, EventArgs e)
        {
            if (ValidarDatosGrabar(btnAprobarDep1) && ValidarAprobarDeposito())
            {
                if (chkSi1.Checked)
                    _ = MessageBox.Show("El importe depositado es igual al importe verificado, por lo tanto se aprobará el cheque", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    _ = MessageBox.Show("El importe depositado es diferente al importe verificado, por lo tanto no se aprobará este cheque", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                if (DialogResult.Yes == MessageBox.Show("¿Esta seguro de grabar?", "MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    ChequesPlanillaTo cheque = ObtenerDatosAprobarRecep();
                    if (cheque != null)
                    {
                        _ = BLCheque.AprobarChequeDeposito(cheque, chkSi1.Checked)
                        ? MessageBox.Show("Cheque grabado correctamente", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        : MessageBox.Show("Ocurrió un erro inesperado", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                Close();
            }
        }

        private void BtnAprobarDep2_Click(object sender, EventArgs e)
        {
            if (ValidarDatosEnvioRecepDepos() && ValidarAprobarCheque())
            {
                if (chkSi2.Checked)
                    _ = MessageBox.Show("El importe depositado es igual al importe verificado, por lo tanto se aprobará el cheque", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    _ = MessageBox.Show("El importe de depositado es diferente al importe verificado, por lo tanto no se aprobará este cheque", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                if (DialogResult.Yes == MessageBox.Show("¿Esta seguro de grabar?", "MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    ChequesPlanillaTo cheque = ObtenerDatosAprobarRecep();
                    if (cheque != null)
                    {
                        _ = BLCheque.AprobarChequeDeposito(cheque, chkSi2.Checked)
                            ? MessageBox.Show("Cheque grabado correctamente", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            : MessageBox.Show("Ocurrió un erro inesperado", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                Close();
            }
        }

        private ChequesPlanillaTo ObtenerDatosAprobarRecep()
        {
            DataTable dt = BLCheque.ObtenerPlanillasPendientesCheque(codPtoCob, nroPllaEnv, ID_SEGUIMIENTO);
            if (dt is null || dt.Rows.Count != 1)
            {
                _ = MessageBox.Show("Error al obtener datos de la planilla. \n Comuniquese con el administrador de sistemas",
                    "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            return new ChequesPlanillaTo
            {
                USUARIO_CREA = SeguimientoCheques.COD_USUARIO,
                ESTADO = Resultado_Cheque.Aprobar,
                EnvioChequeTo = new EnvioChequeTo
                {
                    ID_ENVIO = ID_ENVIO
                },
                DepositoChequeTo = new DepositoChequeTo
                {
                    ID_DEPOSITO = ID_DEPOSITO,
                    IMPORTE_VERIFICADO = plNumImpPlla3.SelectedIndex == 0 ? numImpVer1.Value : numImpVer2.Value,
                    IMPORTE_PROPIO_PLLA = plNumImpPlla3.SelectedIndex == 0 ? numImpPlla1.Value : numImpPlla2.Value
                },
                SeguimientoPlanillaTo = new SeguimientoPlanillaTo
                {
                    ID_SEGUIMIENTO = ID_SEGUIMIENTO,
                    ID_ESTADO = CHEQUE_CONFIRMADO,
                    IMPORTE_EXC_INI = ObtenerImporteExcesoIni(),
                    IMPORTE_EXC_DOC = ObtenerImporteExcesoDoc(),
                    IMPORTE_VERIFICADO = ObtenerImporteTotalVerificado(),
                    SALDO_X_COBRAR = ObtenerSaldoXCobrar(),
                    USUARIO_CREA = SeguimientoCheques.COD_USUARIO
                }
            };

            decimal ObtenerImporteExcesoIni()
            {
                decimal saldo = Convert.ToDecimal(dt.Rows[0]["IMPORTE_NETO_ENTIDAD"]) - Convert.ToDecimal(dt.Rows[0]["IMP_VERIFICADO"]) -
                    (plNumImpPlla3.SelectedIndex == 0 ? numImpVer1.Value : numImpVer2.Value);
                return saldo >= 0 ? 0 : saldo * -1;
            }

            decimal ObtenerImporteExcesoDoc()
            {
                decimal saldo = Convert.ToDecimal(dt.Rows[0]["IMPORTE_NETO_ENTIDAD"]) - Convert.ToDecimal(dt.Rows[0]["IMP_VERIFICADO"]) -
                    (plNumImpPlla3.SelectedIndex == 0 ? numImpVer1.Value : numImpVer2.Value) - Convert.ToDecimal(dt.Rows[0]["IMPORTE_APLICADO_REC"])
                    + Convert.ToDecimal(dt.Rows[0]["IMPORTE_APLICADO_ENV"]) + Convert.ToDecimal(dt.Rows[0]["IMPORTE_REEMBOLSO"]);
                return saldo >= 0 ? 0 : saldo * -1;
            }

            decimal ObtenerImporteTotalVerificado()
            {
                return Convert.ToDecimal(dt.Rows[0]["IMP_VERIFICADO"]) +
                    (plNumImpPlla3.SelectedIndex == 0 ? numImpVer1.Value : numImpVer2.Value);
            }

            decimal ObtenerSaldoXCobrar()
            {
                decimal saldo = Convert.ToDecimal(dt.Rows[0]["IMPORTE_NETO_ENTIDAD"]) - Convert.ToDecimal(dt.Rows[0]["IMP_VERIFICADO"]) -
                    (plNumImpPlla3.SelectedIndex == 0 ? numImpVer1.Value : numImpVer2.Value) - Convert.ToDecimal(dt.Rows[0]["IMPORTE_APLICADO_REC"])
                    + Convert.ToDecimal(dt.Rows[0]["IMPORTE_APLICADO_ENV"]) + Convert.ToDecimal(dt.Rows[0]["IMPORTE_REEMBOLSO"]);
                return saldo >= 0 ? saldo : 0;
            }
        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ac > 0)
            {
                if (ac == 1)
                {
                    if (plNumImpPlla3.SelectedIndex == 0)
                    {
                        plNumImpPlla3.SelectedIndex = 1;
                    }
                    else if (plNumImpPlla3.SelectedIndex == 2)
                    {
                        plNumImpPlla3.SelectedIndex = 1;
                    }
                }
                else if (ac == 2)
                {
                    if (plNumImpPlla3.SelectedIndex == 1)
                    {
                        plNumImpPlla3.SelectedIndex = 0;
                    }
                    else if (plNumImpPlla3.SelectedIndex == 2)
                    {
                        plNumImpPlla3.SelectedIndex = 0;
                    }
                }
                else if (ac == 3)
                {
                    if (plNumImpPlla3.SelectedIndex == 0)
                    {
                        plNumImpPlla3.SelectedIndex = 2;
                    }
                    else if (plNumImpPlla3.SelectedIndex == 1)
                    {
                        plNumImpPlla3.SelectedIndex = 2;
                    }
                }
            }
        }
    }
}
