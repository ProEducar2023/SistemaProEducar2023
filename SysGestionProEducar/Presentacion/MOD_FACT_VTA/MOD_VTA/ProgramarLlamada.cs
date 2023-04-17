using BLL;
using Entidades;
using Presentacion.MOD_FACT_VTA.MOD_VTA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static Entidades.ConstClass;

namespace SysSeguimiento
{
    public partial class ProgramarLlamada : Form
    {
        private readonly string nroPlanilla, estado, titulo, tipoLlamada, nombrePuntoCobranza, nroPllaEnv;
        private readonly int idSeguimiento, idEstado;
        private int idPersona;
        private readonly int idOption, idLlamadaBase;
        private int idLlamada;
        private int ac, acces;
        public int act;
        private DateTime fecha;

        public ProgramarLlamada(int idOption, string titulo, int idSeguimiento, int idEstado, string nroPlanilla, string namePuntoCobranza, string estado, int idLlamadaBase, string tipoLlamada = "", int idPersona = 0, int act = 0)
        {
            InitializeComponent();
            KeyDown += NextControl;
            this.nroPlanilla = nroPlanilla;
            this.estado = estado;
            this.idSeguimiento = idSeguimiento;
            this.idEstado = idEstado;
            this.idOption = idOption;
            this.idLlamadaBase = idLlamadaBase;
            this.idPersona = idPersona;
            this.titulo = titulo;
            this.act = act;
            this.tipoLlamada = tipoLlamada;
            nombrePuntoCobranza = namePuntoCobranza;
            NumInputs();
            CambiarTamañoForm(idOption, idEstado);
        }

        public ProgramarLlamada(int idOption, string titulo, int idSeguimiento, int idEstado, string nroPlanilla, string nroPllaEnv, string namePuntoCobranza, string estado, int idLlamadaBase, string tipoLlamada = "", int idPersona = 0, int act = 0)
        {
            InitializeComponent();
            KeyDown += NextControl;
            this.nroPlanilla = nroPlanilla;
            this.estado = estado;
            this.idSeguimiento = idSeguimiento;
            this.idEstado = idEstado;
            this.idOption = idOption;
            this.idLlamadaBase = idLlamadaBase;
            this.idPersona = idPersona;
            this.titulo = titulo;
            this.act = act;
            this.tipoLlamada = tipoLlamada;
            this.nroPllaEnv = nroPllaEnv;
            nombrePuntoCobranza = namePuntoCobranza;
            NumInputs();
            CambiarTamañoForm(idOption, idEstado);
        }

        private readonly SeguimientoPlanillasBLL BLSeguimiento = new SeguimientoPlanillasBLL();

        public LLamadas LlamadaResultado;
        private static bool cerrado, _acc;
        public bool Ejecutado { get; set; }
        public bool SiEjecutado { get; set; }
        private decimal importeListado, importeCasilleroAuto, impOtrosDescuentos, porcentajeCasillero, importeCasilleroMan, impEjecutado;
        private DataGridView dgvImporteListado;

        private void ProgramarLlamada_Load(object sender, EventArgs e)
        {
            StartControls();
            Titulo();
        }

        private void StartControls()
        {
            pnlImporte.Visible = false;
            lblNroPlanilla.Text += nroPlanilla;
            lblEstado.Text += estado;
            btnRegistrarLlamada.Cursor = Cursors.Hand;
            lblRecepcion.Visible = false;
            chkSi.Visible = false;
            chkNo.Visible = false;
            dgvLlamadas.Visible = false;
            chkEst.Checked = true;
            chkEst.Visible = false;
            btnRegistrarLlamada2.Visible = false;
            btnRegistrarLlamada2.Cursor = Cursors.Hand;
            gbDatosDscto.Visible = false;
            panel3.Visible = false;
            chkOtros.Visible = false;
            label20.Visible = false;
            numOtrosDescto.Visible = false;
            label23.Visible = false;
            numImpListado.Visible = false;
            dtFechaTrans.Visible = false;
            lblFechaTrans.Visible = false;
            numImpCasilleroAuto.ReadOnly = true;
            numImpCasilleroMan.ReadOnly = true;
            numImpEjec.ReadOnly = true;
            dgvLlamadas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            if (idOption == Programado || idOption == Reprogramado || idOption == OtrosResultados)
            {
                pnButtons.Visible = false;
                //> chkEst.Enabled = true;
                //> gbReceptor.Enabled = false;
                gbReceptor.Text = "        A quien se va llamar";
                //> gbLlamadaProgramada.Visible = false;
                lblRecepcion.Visible = false;
                if (idOption == Programado || idOption == Reprogramado)
                {
                    ListarLlamadasPendientes();
                    MostrarDatosEnvio();
                    dgvLlamadas.Visible = true;
                }
                if (idEstado == RECEPCIONADA && idOption == Reprogramado && act == 1)
                {
                    panel1.Size = new Size { Width = 890, Height = 27 };
                    lblEstado.Location = new Point { X = 550, Y = 6 };
                    panel4.Visible = false;
                    gbLlamadaProgramada.Visible = false;
                    gbLlamadas.Location = gbLlamadaProgramada.Location;
                }
                else if (idEstado == RECEPCIONADA && (idOption == Reprogramado || idOption == Programado))
                {
                    panel1.Size = new Size { Width = 710, Height = 27 };
                    lblEstado.Location = new Point { X = 500, Y = 6 };
                    gbContent.Size = new Size { Width = 352, Height = 385 };
                    gbLlamadaProgramada.Size = gbContent.Size;
                    btnRegistrarLlamada.Location = new Point { X = 55, Y = 343 };
                    btnRegistrarLlamada2.Visible = true;
                }
                else if ((idEstado == PROCESADA || idEstado == DESCONTADA || idEstado == DESCONTADA_CERRADA || idEstado == DESCONTADO_CONFIRMADO || idEstado == NO_EJECUTADO)
                    && (idOption == Reprogramado || idOption == Programado))
                {
                    panel1.Size = new Size { Width = 890, Height = 27 };
                    lblEstado.Location = new Point { X = 550, Y = 6 };
                    panel4.Visible = false;
                    gbLlamadaProgramada.Visible = false;
                    gbLlamadas.Location = gbLlamadaProgramada.Location;
                    if (idEstado == DESCONTADA_CERRADA)
                        lblTitulo.Location = new Point { X = 94, Y = 6 };
                    //> gbInstitucion.Text = "Otros Datos";
                }
                else if ((idEstado == CHEQUE_ENVIADO || idEstado == CHEQUE_RECEPCIONADO || idEstado == CHEQUE_DEPOSITADO || idEstado == CHEQUE_CONFIRMADO) && (idOption == Reprogramado || idOption == Programado))
                {
                    panel1.Size = new Size { Width = 890, Height = 27 };
                    lblEstado.Location = new Point { X = 550, Y = 6 };
                    panel4.Visible = false;
                    gbLlamadaProgramada.Visible = false;
                    gbLlamadas.Location = gbLlamadaProgramada.Location;
                    if (idEstado == CHEQUE_ENVIADO)
                        lblEstado.Visible = false;
                }

                if (idOption == OtrosResultados)
                {
                    label4.Text = "Fecha : ";
                    dtFecha.Location = new Point { X = 92, Y = 31 };
                    label5.Text = "Hora : ";
                    dtHora.Location = new Point { X = 92, Y = 59 };
                    gbLlamadaProgramada.Visible = false;
                    panel4.Visible = false;
                    btnRegistrarLlamada.Location = new Point { X = 43, Y = 341 };
                }
            }
            else if (idOption == Resultado)
            {
                pnButtons.Visible = false;
                //> chkEst.Checked = true;
                //> chkEst.Enabled = false;
                gbLlamadas.Visible = false;
                panel1.Size = new Size { Width = 710, Height = 27 };
                lblEstado.Location = new Point { X = 550, Y = 6 };
                gbContent.Location = gbLlamadaProgramada.Location;
                gbLlamadaProgramada.Location = new Point { X = 9, Y = 37 };
                btnRegistrarLlamada.Location = new Point { X = 43, Y = 365 };
                panel4.Location = panel2.Location;
                panel2.Location = new Point { X = 386, Y = 34 };
                MostrarDatos2(idLlamadaBase);
                lblRecepcion.Visible = true;
                chkSi.Visible = true;
                chkNo.Visible = true;
                txtArea.Text = txtArea2.Text;
                txtNombre.Text = txtNombre2.Text;
                txtTelefono.Text = txtTlf2.Text;
                txtNombreInst.Text = txtNombreInst2.Text;
                txtTlfInst.Text = txtTlfInst2.Text;
                label4.Text = "Fecha Resultado : ";
                dtFecha.Location = new Point { X = 147, Y = 33 };
                label5.Text = "Hora Resultado : ";
                dtHora.Location = new Point { X = 147, Y = 58 };
                if (idEstado == PROCESADA)
                {
                    lblTitulo2.Location = new Point { X = 56, Y = 6 };
                    lblRecepcion.Text = "¿Procesada?";
                }
                else if (idEstado == DESCONTADA || idEstado == DESCONTADA_CERRADA || idEstado == NO_EJECUTADO)
                {
                    gbDatosDscto.Visible = true;
                    panel3.Visible = true;
                    pnlImporte.Enabled = false;
                    pnlImporte.Visible = true;
                    chkSi.Checked = false;
                    lblTitulo2.Location = new Point { X = 56, Y = 6 };
                    //> lblRecepcion.Text = "¿Descontada?";
                    panel1.Size = new Size { Width = 1067, Height = 27 };
                    gbContent.Size = new Size { Height = 410, Width = gbContent.Size.Width };
                    gbLlamadaProgramada.Size = gbContent.Size;
                    //> btnRegistrarLlamada.Location = new Point { X = 43, Y = 400 };
                    gbDatosDscto.Controls.Add(chkNo);
                    gbDatosDscto.Controls.Add(chkSi);
                    chkSi.Location = chkNoSal.Location;
                    chkNo.Location = new Point { X = 18, Y = 39 };
                    chkNoSal.Location = new Point { X = 18, Y = 64 };
                    lblRecepcion.Visible = false;
                    pnlImporte.Enabled = true;
                    if (idEstado == DESCONTADA)
                    {
                        chkSi.Text = "Si salió descuento";
                        chkNo.Text = "Aún no esta procesado (Reprogramar)";
                        label21.Visible = false;
                        numImpCasilleroAuto.Visible = false;
                        label22.Location = label23.Location;
                        numImpNeto.Location = numImpListado.Location;
                        label19.Location = new Point { X = 15, Y = 250 };
                        txtMotivo.Location = new Point { X = 18, Y = 269 };
                        numImpNeto.Visible = false;
                        label22.Visible = false;
                    }

                    if (idEstado == DESCONTADA_CERRADA)
                    {
                        label23.Visible = true;
                        numImpListado.Visible = true;
                        label20.Visible = true;
                        numOtrosDescto.Visible = true;
                        chkNoSal.Visible = false;
                        chkOtros.Visible = true;
                        label21.Visible = true;
                        numImpCasilleroAuto.Visible = true;
                        chkSi.Text = "Si se recibió el listado de descuento";
                        chkNo.Text = "Aún sigue pendiente (Reprogramar)";
                        gbDatosDscto.Controls.Add(chkOtros);
                        chkOtros.Location = new Point { X = 18, Y = 64 };
                        lblFechaTrans.Visible = true;
                        dtFechaTrans.Visible = true;
                    }
                    else if (idEstado == NO_EJECUTADO)
                    {
                        numImpCasilleroAuto.ReadOnly = false;
                        numImpCasilleroMan.ReadOnly = false;
                        label23.Visible = true;
                        numImpListado.Visible = true;
                        label20.Visible = true;
                        numOtrosDescto.Visible = true;
                        chkNoSal.Visible = false;
                        chkOtros.Visible = true;
                        label21.Visible = true;
                        numImpCasilleroAuto.Visible = true;
                        chkSi.Text = "Si se recibió el listado de descuento";
                        chkNo.Text = "Aún sigue pendiente (Reprogramar)";
                        gbDatosDscto.Controls.Add(chkOtros);
                        chkOtros.Location = new Point { X = 18, Y = 64 };
                        lblFechaTrans.Visible = true;
                        dtFechaTrans.Visible = true;
                    }
                }
                else if (idEstado == DESCONTADO_CONFIRMADO)
                {
                    lblTitulo2.Location = new Point { X = 56, Y = 6 };
                    lblRecepcion.Text = "¿Depositada?";
                }
                else if (idEstado == CHEQUE_ENVIADO)
                {
                    lblRecepcion.Text = "Regist. Cheque";
                }
                else if (idEstado == CHEQUE_RECEPCIONADO || idEstado == CHEQUE_DEPOSITADO || idEstado == CHEQUE_CONFIRMADO)
                {
                    chkSi.Visible = false;
                    chkNo.Visible = false;
                    lblRecepcion.Visible = false;
                }
                ReadOnly(true);
            }
            else if (idOption == ProgramadoCerrado)
            {
                MostrarDatos(idLlamadaBase);
                gbLlamadaProgramada.Visible = false;
                panel4.Visible = false;
                btnRegistrarLlamada.Visible = false;
                pnButtons.Location = new Point { X = 6, Y = 341 };
            }
            else if (idOption == ActualizarResultado)
            {
                btnRegistrarLlamada.Visible = false;
                panel1.Size = new Size { Width = 710, Height = 27 };
                lblEstado.Location = new Point { X = 500, Y = 6 };
                gbContent.Location = gbLlamadaProgramada.Location;
                gbLlamadaProgramada.Location = new Point { X = 9, Y = 37 };
                btnRegistrarLlamada.Location = new Point { X = 97, Y = 367 };
                panel4.Location = panel2.Location;
                panel2.Location = new Point { X = 386, Y = 34 };
                MostrarDatos(idLlamadaBase);
                MostrarDatos2(idLlamada);
                label4.Text = "Fecha Resultado : ";
                dtFecha.Location = new Point { X = 147, Y = 33 };
                label5.Text = "Hora Resultado : ";
                dtHora.Location = new Point { X = 147, Y = 58 };
                ReadOnly(true);
                gbLlamadas.Visible = false;
                pnButtons.Location = new Point { X = 6, Y = 341 };
                gbContent.Size = new Size { Width = 352, Height = 388 };
                gbLlamadaProgramada.Size = gbContent.Size;

                if (idEstado == DESCONTADA || idEstado == DESCONTADA_CERRADA || idEstado == NO_EJECUTADO)
                {
                    gbDatosDscto.Visible = true;
                    panel3.Visible = true;
                    pnlImporte.Visible = true;
                    lblTitulo2.Location = new Point { X = 56, Y = 6 };
                    lblRecepcion.Visible = true;
                    //> lblRecepcion.Text = "¿Descontada?";
                    chkSi.Visible = true;
                    chkNo.Visible = true;
                    gbContent.Size = new Size { Height = 410, Width = gbContent.Size.Width };
                    gbLlamadaProgramada.Size = gbContent.Size;
                    panel1.Size = new Size { Width = 1067, Height = 27 };
                    gbDatosDscto.Controls.Add(chkNo);
                    gbDatosDscto.Controls.Add(chkSi);
                    chkSi.Location = chkNoSal.Location;
                    chkNo.Location = new Point { X = 18, Y = 39 };
                    chkNoSal.Location = new Point { X = 18, Y = 64 };
                    lblRecepcion.Visible = false;
                    pnlImporte.Enabled = true;
                    if (idEstado == DESCONTADA)
                    {
                        chkSi.Text = "Si salió descuento";
                        chkNo.Text = "Aún no esta procesado (Reprogramar)";
                        label21.Visible = false;
                        numImpCasilleroAuto.Visible = false;
                        label22.Location = label23.Location;
                        numImpNeto.Location = numImpListado.Location;
                        label19.Location = new Point { X = 15, Y = 250 };
                        txtMotivo.Location = new Point { X = 18, Y = 269 };
                    }

                    if (idEstado == DESCONTADA_CERRADA)
                    {
                        //numImpCasilleroAuto.ReadOnly = false;
                        //numImpCasilleroMan.ReadOnly = false;
                        label23.Visible = true;
                        numImpListado.Visible = true;
                        label20.Visible = true;
                        numOtrosDescto.Visible = true;
                        chkNoSal.Visible = false;
                        chkOtros.Visible = true;
                        label21.Visible = true;
                        numImpCasilleroAuto.Visible = true;
                        chkSi.Text = "Si se recibió el listado de descuento";
                        chkNo.Text = "Aún sigue pendiente (Reprogramar)";
                        gbDatosDscto.Controls.Add(chkOtros);
                        chkOtros.Location = new Point { X = 18, Y = 64 };
                        lblFechaTrans.Visible = true;
                        dtFechaTrans.Visible = true;
                    }
                    else if (idEstado == NO_EJECUTADO)
                    {
                        label23.Visible = true;
                        numImpListado.Visible = true;
                        label20.Visible = true;
                        numOtrosDescto.Visible = true;
                        chkNoSal.Visible = false;
                        chkOtros.Visible = true;
                        label21.Visible = true;
                        numImpCasilleroAuto.Visible = true;
                        chkSi.Text = "Si se recibió el listado de descuento";
                        chkNo.Text = "Aún sigue pendiente (Reprogramar)";
                        gbDatosDscto.Controls.Add(chkOtros);
                        chkOtros.Location = new Point { X = 18, Y = 64 };
                        lblFechaTrans.Visible = true;
                        dtFechaTrans.Visible = true;
                    }
                }
            }

            if (idEstado == DESCONTADA_CERRADA || idEstado == DESCONTADO_CONFIRMADO || idEstado == NO_DESCONTADO || idEstado == NO_EJECUTADO)
            {
                chkOtros.Visible = false;
                chkNoSal.Visible = false;
                chkNoProcesado.Visible = false;
                chkSi.Visible = false;
            }
            _ = txtObservacion.Focus();

            btnImporteListado.Text = btnImporteListado.Tag.ToString() == "1" || btnImporteListado.Tag.ToString() == "2" ? "Insertar" : "Ver";
        }

        public void ObtenerOtrosDsctos()
        {
            SeguimientoPlanillaTo se = BLSeguimiento.ObtenerSeguimientoPlanillaTo(idSeguimiento);
            DataTable dt = BLSeguimiento.ObtenerPlanillasXGrupo(se);
            if (dt != null && dt.Rows.Count > 0)
            {
                if (btnImporteListado.Tag.ToString() == "2" || btnImporteListado.Tag.ToString() == "3")
                {
                    decimal totalCasilleroManual = 0;
                    decimal totalCasilleroAuto = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        totalCasilleroAuto += ObtenerCasilleroAuto
                                            (
                                                Convert.ToDecimal(row["USO_CASILLERO_IMPORTE"]),
                                                Convert.ToDecimal(row["USO_CASILLERO_PORCENTAJE"]),
                                                Convert.ToDecimal(row["IMPORTE_EJECUTADO"]),
                                                Convert.ToBoolean(row["APROBAR_RECEPCIONADO"])
                                            );
                        totalCasilleroManual += Convert.ToDecimal(row["IMPORTE_CASILLERO_MAN"]);

                    }
                    label21.Text = "Casillero Auto. % : ";
                    porcentajeCasillero = totalCasilleroAuto;
                    numImpCasilleroAuto.Value = totalCasilleroAuto;
                    numImpCasilleroMan.Value = totalCasilleroManual;
                    importeCasilleroMan = totalCasilleroManual;
                    importeCasilleroAuto = totalCasilleroAuto;
                }
            }
        }

        private void NextControl(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.SendWait("{TAB}");
            }
        }

        private void Titulo()
        {
            if (idEstado == RECEPCIONADA && tipoLlamada == TipoProgramadoCorreo)
            {
                lblTitulo.Text = titulo + " - Correo";
                lblTitulo2.Text = "Llamada Programada - Correo";
                lblTitulo2.Location = new Point { X = 58, Y = 6 };
            }
            else if (idEstado == RECEPCIONADA && tipoLlamada == TipoProgramadoCorresp)
            {
                lblTitulo.Text = titulo + " - Correspondencia";
                lblTitulo.Location = new Point { X = 28, Y = 6 };
                lblTitulo2.Text = "Llamada Programada - Correspondencia";
            }
            else if (idEstado == RECEPCIONADA && tipoLlamada == TipoProgramadoOtros)
            {
                lblTitulo.Text = titulo;
                lblTitulo.Location = new Point { X = 93, Y = 6 };
            }
            else if (idEstado == RECEPCIONADA && (idOption == Reprogramado || idOption == Programado))
            {
                lblTitulo.Text = titulo + " - Correo";
                lblTitulo2.Text = "Programar Llamada - Correspondencia";
            }
            else if (idEstado == RECEPCIONADA && idOption == Resultado)
            {
                lblTitulo.Text = titulo + " - Correo";
                lblTitulo2.Text = "Llamada Programada - Correspondencia";
            }
            else if (idEstado == PROCESADA)
            {
                lblTitulo.Text = titulo + " - Proceso";
                lblTitulo2.Text = "Llamada Programada - Proceso";
            }
            else if (idEstado == DESCONTADA)
            {
                lblTitulo.Text = titulo + " - Descuento";
                lblTitulo2.Text = "Llamada Programada - Descuento";
            }
            else if (idEstado == DESCONTADA_CERRADA || idEstado == NO_EJECUTADO)
            {
                lblTitulo2.Text = "Llamada Programada";
                if (idOption == Programado || idOption == Reprogramado)
                    lblTitulo.Text = "Programar Llamada";
                else
                    lblTitulo.Text = "Resultado Llamada";
            }
            else if (idEstado == DESCONTADO_CONFIRMADO)
            {
                EstablecerTitulos(titulo, "Llamada Programada", new Point { X = 94, Y = 6 }, new Point { X = 85, Y = 6 }, false);
            }
            else if (idEstado == CHEQUE_ENVIADO)
            {
                EstablecerTitulos(titulo, "Llamada Programada", new Point { X = 94, Y = 6 }, new Point { X = 85, Y = 6 }, false);
            }

            if (idOption != OtrosResultados)
            {
                lblPuntoCobranza.Text += nombrePuntoCobranza;
                lblPuntoCobranza.Location = new Point { X = lblNroPlanilla.Location.X + (panel1.Size.Width / 2) - 100, Y = 6 };
                lblEstado.Location = new Point { X = panel1.Size.Width - 180, Y = 6 };
                lblPuntoCobranza.Visible = true;
            }
        }

        private void EstablecerTitulos(string titulo1, string titulo2, Point titulo1Ubicacion, Point titulo2Ubicacion, bool lblVisibleEstado)
        {
            lblTitulo.Text = titulo1;
            lblTitulo2.Text = titulo2;
            lblEstado.Visible = lblVisibleEstado;
            lblTitulo.Location = titulo1Ubicacion;
            lblTitulo2.Location = titulo2Ubicacion;
        }

        private void NumInputs()
        {
            numImporte.Maximum = decimal.MaxValue;
            numEnvio.Maximum = decimal.MaxValue;
            numImpNeto.Maximum = decimal.MaxValue;
            numImpCasilleroAuto.Maximum = decimal.MaxValue;
            numImpNeto.Minimum = decimal.MinValue;
            numImporte.DecimalPlaces = 2;
            numImporte.ThousandsSeparator = true;
            numEnvio.ReadOnly = true;
            numEnvio.DecimalPlaces = 2;
            numEnvio.ThousandsSeparator = true;
            numImpCasilleroAuto.ThousandsSeparator = true;
            numImpCasilleroAuto.DecimalPlaces = 2;
            numImpNeto.ThousandsSeparator = true;
            numImpNeto.DecimalPlaces = 2;
            numImpNeto.ReadOnly = true;
            numOtrosDescto.ThousandsSeparator = true;
            numOtrosDescto.DecimalPlaces = 2;
            numOtrosDescto.Maximum = decimal.MaxValue;
            numImpListado.ThousandsSeparator = true;
            numImpListado.DecimalPlaces = 2;
            numImpListado.Maximum = decimal.MaxValue;
            dtFechaTrans.Checked = false;
            numImpEjec.DecimalPlaces = 2;
            numImpEjec.ThousandsSeparator = true;
            numImpEjec.Maximum = decimal.MaxValue;
            numImpCasilleroMan.DecimalPlaces = 2;
            numImpCasilleroMan.ThousandsSeparator = true;
            numImpCasilleroMan.Maximum = decimal.MaxValue;
        }

        private void ChkEst_CheckedChanged(object sender, EventArgs e)
        {
            //> gbReceptor.Enabled = chkEst.Checked;
        }

        private void BtnRegistrarLlamada_Click(object sender, EventArgs e)
        {
            Button btnRegistrar = sender as Button;
            string message = "¿Esta seguro de que desea grabar?";
            if (ValidarDatos(btnRegistrar) && ValidarFechaTransferencia())
            {
                if (idEstado == DESCONTADA_CERRADA && idOption == Resultado && dtFechaTrans.Checked && (chkSi.Checked || chkOtros.Checked))
                {
                    _ = MessageBox.Show("Se ha ingresado la fecha de entrega de listado al área de planillas, por lo tanto, no se podrá ya modificar esta planilla", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                DialogResult dr = MessageBox.Show(idOption == Reprogramado && VerificarFechaProgramada(btnRegistrar, ref message) ? message : message, "MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        if (idOption == Reprogramado && LlamadaResultado != null)
                        {
                            ac = 1;
                            _ = BLSeguimiento.ResultadoYProgramarLlamada(ObtenerListLlamadasGrabar())
                                ? _ = MessageBox.Show("Registrado correctamente", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                : _ = MessageBox.Show("Ocurrió un problema al grabar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Close();
                        }
                        else
                        {
                            LLamadas llamada1 = btnRegistrar.Name == btnRegistrarLlamada.Name ? ObtenerDatosGrabar1() : ObtenerDatosGrabar2();
                            if (idEstado != DESCONTADA_CERRADA && idEstado != NO_EJECUTADO && idEstado != PROCESADA && idEstado != DESCONTADA)
                            {
                                _ = BLSeguimiento.ProgramarLlamada(llamada1)
                                    ? _ = MessageBox.Show("Registrado correctamente", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    : _ = MessageBox.Show("Ocurrió un problema al grabar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else if (idOption == Resultado && chkSi.Checked && idEstado == DESCONTADA)
                            {
                                _ = BLSeguimiento.ResultadoLlamadaYDescuento(llamada1)
                                 ? _ = MessageBox.Show("Registrado correctamente", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                 : _ = MessageBox.Show("Ocurrió un problema al grabar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else if ((idEstado == DESCONTADA_CERRADA || idEstado == NO_EJECUTADO) && idOption == Resultado) // && (chkSi.Checked || chkOtros.Checked || chkNoProcesado.Checked)
                            {
                                DateTime fechaTrans = dtFechaTrans.Checked ? dtFechaTrans.Value : DateTime.Now;
                                _ = BLSeguimiento.ProgramarLlamadaConfirmarDescuento(llamada1, fechaTrans, dtFechaTrans.Checked, ObtenerImporteListado())
                                    ? _ = MessageBox.Show("Registrado correctamente", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    : _ = MessageBox.Show("Ocurrió un problema al grabar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                _ = BLSeguimiento.ProgramarLlamada(llamada1, chkSi.Checked, chkNoSal.Checked)
                                    ? _ = MessageBox.Show("Registrado correctamente", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    : _ = MessageBox.Show("Ocurrió un problema al grabar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            ListarLlamadasPendientes();
                            if (idOption == Resultado)
                            {
                                cerrado = true;
                                Close();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        _ = MessageBox.Show(ex.Message, "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    chkSi.Checked = false;
                }
            }
        }

        private bool ValidarDatos(Button button)
        {
            ValidarVaciosNumImputs();
            if (button.Name == btnRegistrarLlamada.Name)
            {
                if (idOption == 1 && DateTime.Parse(dtFecha.Value.ToShortDateString()) < DateTime.Parse(DateTime.Now.ToShortDateString()))
                {
                    _ = MessageBox.Show("La fecha programa debe ser mayor o igual a la fecha actual", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                else if (DateTime.Parse(dtFecha.Value.ToShortDateString()) < DateTime.Parse(DateTime.Now.ToShortDateString()))
                {
                    _ = MessageBox.Show("La fecha a registrar debe ser mayor o igual a la fecha actual", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                DataTable dt2 = BLSeguimiento.ObtenerLlamadasXId(idLlamadaBase);

                if (dt2 != null && dt2.Rows.Count > 0 && Convert.ToDateTime(Convert.ToDateTime(dt2.Rows[0]["FECHA_LLAMADA"]).ToShortDateString() + " " + dt2.Rows[0]["HORA_LLAMADA"].ToString()) > Convert.ToDateTime(dtFecha.Value.ToShortDateString() + " " + dtHora.Value.ToString("HH:mm:ss")))
                {
                    _ = MessageBox.Show("La fecha seleccionada debe ser mayor o igual a la fecha programada : " + Convert.ToDateTime(dt2.Rows[0]["FECHA_LLAMADA"]).ToShortDateString() + " " + dt2.Rows[0]["HORA_LLAMADA"].ToString(), "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else if (chkEst.Checked && string.IsNullOrEmpty(txtNombre.Text.Trim()))
                {
                    _ = MessageBox.Show("Digite el nombre de la persona", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    _ = txtNombre.Focus();
                    return false;
                }
                else if (chkEst.Checked && string.IsNullOrEmpty(txtArea.Text.Trim()))
                {
                    _ = MessageBox.Show("Digite el área de labor de la persona", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    _ = txtArea.Focus();
                    return false;
                }
                else if (idOption == Resultado && idEstado == DESCONTADA && !chkSi.Checked && !chkNo.Checked && !chkNoSal.Checked)
                {
                    _ = MessageBox.Show("Seleccione si la planilla se ha descontado", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                //else if (chkSi.Checked && idEstado == DESCONTADA_CERRADA && numImporte.Value == 0)
                //{
                //    _ = MessageBox.Show("Digite el importe descontado", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return false;
                //}
                else if (!chkNo.Checked && !chkSi.Checked && idEstado == RECEPCIONADA && idOption != Programado && idOption != Reprogramado)
                {
                    _ = MessageBox.Show("Seleccione si la planilla ha sido recepcionada", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else if (!chkNo.Checked && !chkSi.Checked && idEstado == PROCESADA && idOption != Programado && idOption != Reprogramado)
                {
                    _ = MessageBox.Show("Seleccione si la planilla ha sido procesada", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else if (idOption == Reprogramado && fecha > Convert.ToDateTime(dtFecha.Value.ToShortDateString() + " " + dtHora.Value.ToString("HH:mm:ss")))
                {
                    _ = MessageBox.Show("La fecha de reprogramación debe ser mayor o igual a la fecha del resultado(" + fecha + ")", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                //else if (idOption == Resultado && !chkSi.Checked && !chkOtros.Checked && !chkNoProcesado.Checked && idEstado == DESCONTADA_CERRADA)
                //{
                //    _ = MessageBox.Show("Seleccione si se recibio el listado de descuento", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return false;
                //}
                else if (idOption == Resultado && chkSi.Checked && idEstado == DESCONTADA_CERRADA && numImpListado.Value == 0)
                {
                    _ = MessageBox.Show("Ingrese el importe de listado", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            else
            {
                if (idOption == 1 && DateTime.Parse(dtFecha2.Value.ToShortDateString()) < DateTime.Parse(DateTime.Now.ToShortDateString()))
                {
                    _ = MessageBox.Show("La fecha programa debe ser mayor o igual a la fecha actual", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                else if (DateTime.Parse(dtFecha2.Value.ToShortDateString()) < DateTime.Parse(DateTime.Now.ToShortDateString()))
                {
                    _ = MessageBox.Show("La fecha a registrar debe ser mayor o igual a la fecha actual", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                DataTable dt2 = BLSeguimiento.ObtenerLlamadasXId(idLlamadaBase);

                if (dt2 != null && dt2.Rows.Count > 0 && Convert.ToDateTime(Convert.ToDateTime(dt2.Rows[0]["FECHA_LLAMADA"]).ToShortDateString() + " " + dt2.Rows[0]["HORA_LLAMADA"].ToString()) > Convert.ToDateTime(dtFecha2.Value.ToShortDateString() + " " + dtHora2.Value.ToString("HH:mm:ss")))
                {
                    _ = MessageBox.Show("La fecha seleccionada debe ser mayor o igual a la fecha programada : " + Convert.ToDateTime(dt2.Rows[0]["FECHA_LLAMADA"]).ToShortDateString() + " " + dt2.Rows[0]["HORA_LLAMADA"].ToString(), "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else if (chkEst.Checked && string.IsNullOrEmpty(txtNombre2.Text.Trim()))
                {
                    _ = MessageBox.Show("Digite el nombre de la persona", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    _ = txtNombre.Focus();
                    return false;
                }
                else if (chkEst.Checked && string.IsNullOrEmpty(txtArea2.Text.Trim()))
                {
                    _ = MessageBox.Show("Digite el área de labor de la persona", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    _ = txtArea.Focus();
                    return false;
                }
            }
            return true;
        }

        private void ValidarVaciosNumImputs()
        {
            foreach (NumericUpDown num in pnlImporte.Controls.OfType<NumericUpDown>().ToList())
            {
                if (string.IsNullOrEmpty(num.Value.ToString()))
                    num.Value = 0;
            }
        }

        private bool VerificarFechaProgramada(Button btn, ref string message)
        {
            foreach (DataRow row in BLSeguimiento.ListarLlamadasPendientesXIdSeguimiento(idSeguimiento).Rows)
            {
                if (btn.Name == btnRegistrarLlamada.Name)
                {
                    if (Convert.ToDateTime(Convert.ToDateTime(row["FECHA_LLAMADA"]).ToShortDateString()) == Convert.ToDateTime(dtFecha.Value.ToShortDateString()))
                    {
                        message = string.Format("Ya existe llamada(s) programada(s) para la fecha {0}. \n Ver lista de llamadas \n ¿Esta seguro de que desea grabar?", dtFecha.Value.ToShortDateString());
                        return true;
                    }
                }
                else
                {
                    if (Convert.ToDateTime(Convert.ToDateTime(row["FECHA_LLAMADA"]).ToShortDateString()) == Convert.ToDateTime(dtFecha2.Value.ToShortDateString()))
                    {
                        message = string.Format("Ya existe una llamada(s) programada(s) para la fecha seleccionada. \n ¿Esta seguro de que desea grabar?", dtFecha2.Value.ToShortDateString());
                        return true;
                    }
                }
            }
            return false;
        }

        private bool ValidarFechaTransferencia()
        {
            if (dtFechaTrans.Checked && idEstado == DESCONTADA_CERRADA)
            {
                if (dgvImporteListado != null)
                {
                    foreach (DataGridViewRow row in dgvImporteListado.Rows)
                    {
                        if (!Convert.ToBoolean(row.Cells["ST_LISTADO"].Value) && !Convert.ToBoolean(row.Cells["ST_NO_PROCESADO"].Value))
                        {
                            _ = MessageBox.Show("Debe seleccionar la opción de: Se recibió el listado o No se ha procesado", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }

                        if (Convert.ToBoolean(row.Cells["ST_LISTADO"].Value) && string.IsNullOrEmpty(row.Cells["FECHA_LISTADO"].Value?.ToString()))
                        {
                            _ = MessageBox.Show("Ingrese la fecha de entrega de lista de las planillas", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }

                        if (Convert.ToBoolean(row.Cells["ST_LISTADO"].Value) && Convert.ToDateTime(row.Cells["FECHA_LISTADO"].Value) > dtFechaTrans.Value)
                        {
                            _ = MessageBox.Show("La fecha de entrega de lista de las planillas debe ser menor o igual a la fecha de hoy!!!!", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                }
                else
                {
                    SeguimientoPlanillaTo se = BLSeguimiento.ObtenerSeguimientoPlanillaTo(idSeguimiento);
                    DataTable dt = BLSeguimiento.ObtenerPlanillasXGrupo(se);
                    foreach (DataRow row in dt.Rows)
                    {
                        if (!Convert.ToBoolean(string.IsNullOrEmpty(row["ST_LISTADO"]?.ToString()) ? false : row["ST_LISTADO"])
                            && !Convert.ToBoolean(string.IsNullOrEmpty(row["ST_NO_PROCESO"]?.ToString()) ? false : row["ST_NO_PROCESO"]))
                        {
                            _ = MessageBox.Show("Debe seleccionar la opción de: Se recibió el listado o No se ha procesado", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }

                        if (!string.IsNullOrEmpty(row["ST_LISTADO"]?.ToString()) && Convert.ToBoolean(row["ST_LISTADO"]) && string.IsNullOrEmpty(row["FEC_RETOR_PLAN"]?.ToString()))
                        {
                            _ = MessageBox.Show("Ingrese la fecha de entrega de lista de las planillas", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }

                        if (!string.IsNullOrEmpty(row["ST_LISTADO"]?.ToString()) && Convert.ToBoolean(row["ST_LISTADO"]) && Convert.ToDateTime(row["FEC_RETOR_PLAN"]) > dtFechaTrans.Value)
                        {
                            _ = MessageBox.Show("La fecha de entrega de lista de las planillas debe ser menor o igual a la fecha de hoy!!!!", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private LLamadas ObtenerDatosGrabar1()
        {
            return new LLamadas
            {
                ID_LLAMADA_BASE = idLlamadaBase,
                ESTADO = idOption,
                FECHA_LLAMADA = dtFecha.Value,
                HORA_LLAMADA = dtHora.Value.ToString("HH:mm:ss"),
                NOMBRE_INST = txtNombreInst.Text,
                TLF_INST = txtTlfInst.Text,
                TIPO = tipoLlamada.Length == 0 ? TipoProgramadoCorreo : tipoLlamada,
                OBSERVACION = txtObservacion.Text,
                MOTIVO = idEstado == DESCONTADA_CERRADA && chkSi.Checked || chkOtros.Checked ? txtMotivo.Text : string.Empty,
                USUARIO_CREACION = SeguimientoPlanilla.COD_USUARIO ?? SeguimientoCheques.COD_USUARIO,
                REC_LIST_DESCTO = idEstado == DESCONTADA_CERRADA ? (chkSi.Checked ? "SI" : chkOtros.Checked ? "NO" : null) : null,
                DESCUENTO = idEstado == DESCONTADA ? (chkSi.Checked ? "SI" : chkNoSal.Checked ? "NO" : null) : null,
                PROCESO_RESULT = idOption == Resultado && idEstado == PROCESADA ? chkSi.Checked ? "SI" : "NO" : null,
                SeguimientoPlanillaTo = new SeguimientoPlanillaTo
                {
                    ID_SEGUIMIENTO = idSeguimiento,
                    ID_ESTADO = idEstado,
                    IMPORTE_DESCUENTO = numEnvio.Value,
                    PORCENTAJE_CASILLERO = porcentajeCasillero > 0 ? porcentajeCasillero : (decimal?)null,
                    IMPORTE_CASILLERO = numImpCasilleroAuto.Value,
                    IMPORTE_RETENIDO = numImpNeto.Value,
                    OTROS_DSCTOS = numOtrosDescto.Value,
                    IMPORTE_LISTADO = numImpListado.Value,
                    OBSERVACION = (idEstado == DESCONTADA_CERRADA && chkOtros.Checked) || (idEstado == DESCONTADA && chkNoSal.Checked) ? txtMotivo.Text : string.Empty,
                    ST_NO_PROCESADO = chkNoProcesado.Checked,
                    ST_NO_PROCESADO_OBS = chkNoProcesado.Checked ? txtMotivo.Text : string.Empty,
                    USUARIO_CREA = SeguimientoPlanilla.COD_USUARIO ?? SeguimientoCheques.COD_USUARIO
                },
                PersonaEnvioTo = !chkEst.Checked
                ? null
                : new PersonaEnvioTo
                {
                    ID_PERSONA = txtNombre2.Text.Trim() == txtNombre.Text.Trim() && txtArea2.Text.Trim() == txtArea.Text.Trim() ? idPersona : 0,
                    NOMBRE = txtNombre.Text,
                    AREA_LABOR = txtArea.Text,
                    TELEFONO = txtTelefono.Text,
                    APELLIDO = string.Empty,
                    CORREO = string.Empty
                }
            };
        }

        private LLamadas ObtenerDatosGrabar2()
        {
            return new LLamadas
            {
                ID_LLAMADA_BASE = idLlamadaBase,
                ESTADO = idOption,
                FECHA_LLAMADA = dtFecha2.Value,
                HORA_LLAMADA = dtHora2.Value.ToString("HH:mm:ss"),
                NOMBRE_INST = txtNombreInst2.Text,
                TLF_INST = txtTlfInst2.Text,
                TIPO = TipoProgramadoCorresp,
                OBSERVACION = txtObservacion2.Text,
                MOTIVO = txtMotivo.Text,
                USUARIO_CREACION = SeguimientoPlanilla.COD_USUARIO ?? SeguimientoCheques.COD_USUARIO,
                SeguimientoPlanillaTo = new SeguimientoPlanillaTo
                {
                    ID_SEGUIMIENTO = idSeguimiento,
                    ID_ESTADO = idEstado
                },
                PersonaEnvioTo = !chkEst.Checked
                ? null
                : new PersonaEnvioTo
                {
                    ID_PERSONA = 0, //> nombrePersona.Trim() == txtNombre2.Text.Trim() && areaPersona.Trim() == txtArea2.Text.Trim() ? idPersona : 0,
                    NOMBRE = txtNombre2.Text,
                    AREA_LABOR = txtArea2.Text,
                    TELEFONO = txtTlf2.Text,
                    APELLIDO = string.Empty,
                    CORREO = string.Empty
                }
            };
        }

        private List<SeguimientoPlanillaTo> ObtenerImporteListado()
        {
            List<SeguimientoPlanillaTo> lista = new List<SeguimientoPlanillaTo>();
            if (dgvImporteListado != null)
            {
                foreach (DataGridViewRow row in dgvImporteListado.Rows)
                {
                    lista.Add(new SeguimientoPlanillaTo
                    {
                        NRO_PLANILLA = row.Cells["NRO_PLANILLA_COB"].Value.ToString(),
                        FE_AÑO = row.Cells["FE_AÑO"].Value.ToString(),
                        FE_MES = row.Cells["FE_MES"].Value.ToString(),
                        COD_INSTITUCION = row.Cells["COD_INSTITUCION"].Value.ToString(),
                        COD_CANAL_DSCTO = row.Cells["COD_CANAL_DSCTO"].Value.ToString(),
                        TIPO_PLANILLA = row.Cells["TIPO_PLANILLA"].Value.ToString(),
                        COD_PTO_COB_CONSOLIDADO = row.Cells["COD_PTO_COB_CONSOLIDADO"].Value.ToString(),
                        CAB_GRUPO = Convert.ToBoolean(row.Cells["CAB_GRUPO"].Value),
                        COD_GRUPO = row.Cells["COD_GRUPO"].Value.ToString(),
                        ID_ESTADO = idEstado,
                        IMPORTE_DESCUENTO = Convert.ToDecimal(row.Cells["IMPORTE_ENVIADO"].Value),
                        IMPORTE_NETO = 0,
                        IMPORTE_LISTADO = Convert.ToDecimal(row.Cells["IMPORTE_LISTADO"].Value),
                        IMPORTE_EJECUTADO = 0,
                        IMPORTE_NETO_GRUPO = 0,
                        IMPORTE_CASILLERO_MAN = 0,
                        IMPORTE_CASILLERO = 0,
                        PORCENTAJE_CASILLERO = 0,
                        FEC_RETOR_PLAN = string.IsNullOrEmpty(row.Cells["FECHA_LISTADO"].Value?.ToString()) ? (DateTime?)null : Convert.ToDateTime(row.Cells["FECHA_LISTADO"].Value),
                        ST_LISTADO = Convert.ToBoolean(row.Cells["ST_LISTADO"].Value),
                        ST_NO_PROCESADO = Convert.ToBoolean(row.Cells["ST_NO_PROCESADO"].Value)
                    });
                }
            }
            return lista;
        }

        private List<LLamadas> ObtenerListLlamadasGrabar()
        {
            List<LLamadas> lista = new List<LLamadas>
            {
                LlamadaResultado,
                ObtenerDatosGrabar1()
            };
            return lista;
        }

        private void MostrarDatos(int idLlamada)
        {
            string res = null;
            string rec_list_dscto = null;
            foreach (DataRow row in BLSeguimiento.ObtenerLlamadasXId(idLlamada).Rows)
            {
                acces = 1;
                //> if (string.IsNullOrEmpty(row["ID_PERSONA"].ToString()))
                gbReceptor.Enabled = chkEst.Checked;
                //> else
                //> chkEst.Checked = true;
                dtFecha.Value = Convert.ToDateTime(row["FECHA_LLAMADA"]);
                dtHora.Value = Convert.ToDateTime("2000-1-1 " + row["HORA_LLAMADA"].ToString());
                txtArea.Text = row["AREA_LABOR"].ToString();
                txtNombre.Text = row["NOMBRE"].ToString();
                txtObservacion.Text = row["OBSERVACION"].ToString();
                txtTelefono.Text = row["TELEFONO"].ToString();
                txtNombreInst.Text = row["NOMBRE_INST"].ToString();
                txtTlfInst.Text = row["TLF_INST"].ToString();
                idPersona = string.IsNullOrEmpty(row["ID_PERSONA"].ToString()) ? 0 : Convert.ToInt32(row["ID_PERSONA"]);
                if (idEstado == DESCONTADA_CERRADA && !chkNoProcesado.Checked)
                    txtMotivo.Text = row["MOTIVO"]?.ToString();
                //> numImporte.Value = row["IMPORTE_DESCUENTO"] == null || row["IMPORTE_DESCUENTO"] == DBNull.Value ? 0 : Convert.ToDecimal(row["IMPORTE_DESCUENTO"]);
                this.idLlamada = Convert.ToInt32(row["ID_LLAMADA_BASE"]);
                res = row["DESCUENTO"]?.ToString();
                rec_list_dscto = row["REC_LIST_DESCTO"]?.ToString();
            }

            if (idEstado == DESCONTADA)
            {
                chkSi.Checked = res == "SI";
                chkNo.Checked = res == null || res.Length == 0;
                numImporte.ReadOnly = !chkSi.Checked;
            }
            else if (idEstado == DESCONTADA_CERRADA)
            {
                //> chkSi.Checked = rec_list_dscto == "SI";
                //> chkOtros.Checked = rec_list_dscto == "NO";
            }
        }

        private void MostrarDatos2(int idLlamada)
        {
            DataTable dt = BLSeguimiento.ObtenerLlamadasXId(idLlamada);
            if (dt != null && dt.Rows.Count > 0)
            {
                dtFecha2.Value = Convert.ToDateTime(dt.Rows[0]["FECHA_LLAMADA"].ToString());
                dtHora2.Value = Convert.ToDateTime("2000-1-1 " + dt.Rows[0]["HORA_LLAMADA"].ToString());
                txtNombre2.Text = dt.Rows[0]["NOMBRE"].ToString();
                txtArea2.Text = dt.Rows[0]["AREA_LABOR"].ToString();
                txtTlf2.Text = dt.Rows[0]["TELEFONO"].ToString();
                txtObservacion2.Text = dt.Rows[0]["OBSERVACION"].ToString();
                txtNombreInst2.Text = dt.Rows[0]["NOMBRE_INST"].ToString();
                txtTlfInst2.Text = dt.Rows[0]["TLF_INST"].ToString();
            }
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            if (ValidarDatosActualizar() && ValidarFechaTransferencia())
            {
                ChequeBLL BLCheque = new ChequeBLL();
                DataTable dtEnvio = BLCheque.ObtenerEnvioChequeXIdSeguimiento(idSeguimiento, 0);
                DataTable dtTransferencia = BLCheque.ObtenerTransChequeXIdSeguimiento(idSeguimiento, 0);
                DataTable dtDeposito = BLCheque.ObtenerDespositoChequeXIdSeguimiento(idSeguimiento, 0);

                if (dtEnvio.Rows.Count > 0 || dtTransferencia.Rows.Count > 0 || dtDeposito.Rows.Count > 0)
                {
                    _ = MessageBox.Show("Esta planilla tiene cheques registrados, no se puede actualizar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (idOption == ActualizarResultado && idEstado == DESCONTADA_CERRADA && dtFechaTrans.Checked && (chkSi.Checked || chkOtros.Checked) && !Ejecutado)
                {
                    _ = MessageBox.Show("Se ha ingresado la fecha de entrega de listado al área de planillas, por lo tanto, no se podrá ya modificar esta planilla", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                if (Ejecutado && !SiEjecutado)
                {
                    _ = MessageBox.Show("No se puede actualizar porque la planilla aún no ha sido ejecutado", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult dr = MessageBox.Show("¿Esta seguro de actualizar esta llamada?", "MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        LLamadas llamada = ObtenerDatosActualizar();
                        if (idOption == ActualizarResultado && idEstado == DESCONTADA)
                        {
                            _ = BLSeguimiento.ModifiacaLlamadaYDescuento(llamada, chkNo.Checked, chkNoSal.Checked)
                                ? _ = MessageBox.Show("Actualizado correctamente", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                : _ = MessageBox.Show("Ocurrió un problema al actualizar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (idOption == ActualizarResultado && (idEstado == DESCONTADA_CERRADA || idEstado == NO_EJECUTADO))
                        {
                            if (!ValidarPlanillasEjecutadasAprobadas())
                                return;
                            bool chkSiNo = chkSi.Checked || chkOtros.Checked;
                            if (numImpEjec.Value > 0)
                                llamada.SeguimientoPlanillaTo.ID_ESTADO = NO_EJECUTADO;
                            DateTime fechaTrans = dtFechaTrans.Checked ? dtFechaTrans.Value : DateTime.Now;
                            _ = BLSeguimiento.ModifiacaLlamadaEtapaLista(llamada, chkSiNo, dtFechaTrans.Checked, fechaTrans, ObtenerImporteNetoYEjecutado())
                                ? _ = MessageBox.Show("Registrado correctamente", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                : _ = MessageBox.Show("Ocurrió un problema al grabar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            _ = BLSeguimiento.ModificarLlamada(llamada)
                                ? _ = MessageBox.Show("Actualizado correctamente", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                : _ = MessageBox.Show("Ocurrió un problema al actualizar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        Close();
                    }
                    catch (Exception ex)
                    {
                        _ = MessageBox.Show(ex.Message, "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private LLamadas ObtenerDatosActualizar()
        {
            return new LLamadas
            {
                ID_LLAMADA_BASE = idLlamadaBase,
                ESTADO = idOption, //> 1 => Llamada programada, 2 => Llamada registrada
                FECHA_LLAMADA = dtFecha.Value,
                HORA_LLAMADA = dtHora.Value.ToString("HH:mm:ss"),
                NOMBRE_INST = txtNombreInst.Text,
                TLF_INST = txtTlfInst.Text,
                OBSERVACION = txtObservacion.Text,
                MOTIVO = (idEstado == DESCONTADA_CERRADA || idEstado == DESCONTADA) && chkSi.Checked || chkOtros.Checked ? txtMotivo.Text : string.Empty,
                REC_LIST_DESCTO = idEstado == DESCONTADA_CERRADA ? (chkSi.Checked ? "SI" : chkOtros.Checked ? "NO" : null) : null,
                DESCUENTO = idEstado == DESCONTADA ? (chkSi.Checked ? "SI" : chkNoSal.Checked ? "NO" : null) : null,
                PROCESO_RESULT = idOption == Resultado && idEstado == PROCESADA ? chkSi.Checked ? "SI" : "NO" : null,
                USUARIO_CREACION = SeguimientoPlanilla.COD_USUARIO ?? SeguimientoCheques.COD_USUARIO,
                SeguimientoPlanillaTo = new SeguimientoPlanillaTo
                {
                    ID_SEGUIMIENTO = idSeguimiento,
                    ID_ESTADO = idEstado,
                    IMPORTE_DESCUENTO = numEnvio.Value, //> no se mantiene
                    IMPORTE_CASILLERO = numImpCasilleroAuto.Value, //> si mantiene
                    IMPORTE_RETENIDO = numImpNeto.Value, //> no se mantiene
                    OTROS_DSCTOS = numOtrosDescto.Value, //> si se mantiene
                    IMPORTE_LISTADO = numImpListado.Value, //> no se mantiene
                    IMPORTE_CASILLERO_MAN = numImpCasilleroMan.Value, //> si se mantiene
                    IMPORTE_EJECUTADO = numImpEjec.Value, //> no se mantiene
                    OBSERVACION = (idEstado == DESCONTADA_CERRADA && chkOtros.Checked) || (idEstado == DESCONTADA && chkNoSal.Checked) ? txtMotivo.Text : string.Empty,
                    ST_NO_PROCESADO = chkNoProcesado.Checked,
                    ST_NO_PROCESADO_OBS = chkNoProcesado.Checked ? txtMotivo.Text : string.Empty,
                    USUARIO_CREA = SeguimientoPlanilla.COD_USUARIO ?? SeguimientoCheques.COD_USUARIO,
                    PersonaEnvio = new PersonaEnvioTo
                    {
                        ID_PERSONA = idPersona
                    }
                },
                PersonaEnvioTo = !chkEst.Checked
                ? null
                : new PersonaEnvioTo
                {
                    ID_PERSONA = idPersona,
                    NOMBRE = txtNombre.Text,
                    AREA_LABOR = txtArea.Text,
                    TELEFONO = txtTelefono.Text,
                    APELLIDO = string.Empty,
                    CORREO = string.Empty
                }
            };
        }

        private List<SeguimientoPlanillaTo> ObtenerImporteNetoYEjecutado()
        {
            SeguimientoPlanillaTo se = BLSeguimiento.ObtenerSeguimientoPlanillaTo(idSeguimiento);
            DataTable dt = BLSeguimiento.ObtenerPlanillasXGrupo(se);
            List<SeguimientoPlanillaTo> lista = new List<SeguimientoPlanillaTo>();
            if (dgvImporteListado != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    foreach (DataGridViewRow row2 in dgvImporteListado.Rows)
                    {
                        if (row["NRO_PLANILLA_COB"].ToString() == row2.Cells["NRO_PLANILLA_COB"].Value.ToString())
                        {
                            lista.Add(new SeguimientoPlanillaTo
                            {
                                ID_SEGUIMIENTO = Convert.ToInt32(row["ID_SEGUIMIENTO"]),
                                NRO_PLANILLA = row["NRO_PLANILLA_COB"].ToString(),
                                FE_AÑO = row["FE_AÑO"].ToString(),
                                FE_MES = row["FE_MES"].ToString(),
                                COD_PTO_COB_CONSOLIDADO = row["COD_PTO_COB_CONSOLIDADO"].ToString(),
                                TIPO_PLANILLA = row["TIPO_PLANILLA"].ToString(),
                                COD_CANAL_DSCTO = row["COD_CANAL_DSCTO"].ToString(),
                                COD_INSTITUCION = row["COD_INSTITUCION"].ToString(),
                                IMPORTE_DESCUENTO = Convert.ToDecimal(row["IMP_ENVIO"]),
                                IMPORTE_LISTADO = Convert.ToDecimal(row2.Cells["IMPORTE_LISTADO"].Value),
                                IMPORTE_EJECUTADO = Convert.ToBoolean(row2.Cells["APROBAR_RECEPCIONADO"].Value) && Convert.ToBoolean(row2.Cells["ST_LISTADO"].Value) ? Convert.ToDecimal(row["IMPORTE_EJECUTADO"]) : 0,
                                IMPORTE_NETO = Convert.ToBoolean(row2.Cells["APROBAR_RECEPCIONADO"].Value) && Convert.ToBoolean(row2.Cells["ST_LISTADO"].Value) ? Convert.ToDecimal(row2.Cells["IMPORTE_NETO"].Value) : 0,
                                IMPORTE_NETO_GRUPO = numImpNeto.Value,
                                COD_GRUPO = row["COD_GRUPO"].ToString(),
                                CAB_GRUPO = se.NRO_PLANILLA == row["NRO_PLANILLA_COB"].ToString() || Convert.ToBoolean(row["CAB_GRUPO"]),
                                IMPORTE_CASILLERO_MAN = Convert.ToDecimal(row2.Cells["CASILLERO_MAN"].Value),
                                IMPORTE_CASILLERO = Convert.ToDecimal(row2.Cells["CASILLERO_AUTO"].Value),
                                PORCENTAJE_CASILLERO = Convert.ToDecimal(row["USO_CASILLERO_PORCENTAJE"]),
                                FEC_RETOR_PLAN = string.IsNullOrEmpty(row2.Cells["FECHA_LISTADO"].Value?.ToString()) ? (DateTime?)null : Convert.ToDateTime(row2.Cells["FECHA_LISTADO"].Value),
                                ST_NO_PROCESADO = Convert.ToBoolean(row2.Cells["ST_NO_PROCESADO"].Value),
                                ST_LISTADO = Convert.ToBoolean(row2.Cells["ST_LISTADO"].Value)
                            });
                            break;
                        }
                    }
                }
            }
            else
            {
                decimal casilleroMan = 0;
                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(new SeguimientoPlanillaTo
                    {
                        ID_SEGUIMIENTO = Convert.ToInt32(row["ID_SEGUIMIENTO"]),
                        NRO_PLANILLA = row["NRO_PLANILLA_COB"].ToString(),
                        FE_AÑO = row["FE_AÑO"].ToString(),
                        FE_MES = row["FE_MES"].ToString(),
                        COD_PTO_COB_CONSOLIDADO = row["COD_PTO_COB_CONSOLIDADO"].ToString(),
                        TIPO_PLANILLA = row["TIPO_PLANILLA"].ToString(),
                        COD_CANAL_DSCTO = row["COD_CANAL_DSCTO"].ToString(),
                        COD_INSTITUCION = row["COD_INSTITUCION"].ToString(),
                        IMPORTE_DESCUENTO = Convert.ToDecimal(row["IMP_ENVIO"]),
                        IMPORTE_LISTADO = Convert.ToDecimal(row["IMP_LISTADO"]),
                        IMPORTE_EJECUTADO = Convert.ToBoolean(row["APROBAR_RECEPCIONADO"]) && Convert.ToBoolean(row["ST_LISTADO"]) ? Convert.ToDecimal(row["IMPORTE_EJECUTADO"]) : 0,
                        IMPORTE_NETO = Convert.ToBoolean(row["APROBAR_RECEPCIONADO"]) && Convert.ToBoolean(row["ST_LISTADO"]) ? decimal.Round(Convert.ToDecimal(row["IMPORTE_EJECUTADO"]) - (ObtenerCasilleroAuto
                                            (
                                                Convert.ToDecimal(row["USO_CASILLERO_IMPORTE"]),
                                                Convert.ToDecimal(row["USO_CASILLERO_PORCENTAJE"]),
                                                Convert.ToDecimal(row["IMPORTE_EJECUTADO"]),
                                                Convert.ToBoolean(row["APROBAR_RECEPCIONADO"])
                                            ) +
                                            casilleroMan), 2) : 0,
                        IMPORTE_NETO_GRUPO = numImpNeto.Value,
                        COD_GRUPO = row["COD_GRUPO"].ToString(),
                        CAB_GRUPO = Convert.ToBoolean(row["CAB_GRUPO"]),
                        IMPORTE_CASILLERO_MAN = 0,
                        IMPORTE_CASILLERO = ObtenerCasilleroAuto
                                            (
                                                Convert.ToDecimal(row["USO_CASILLERO_IMPORTE"]),
                                                Convert.ToDecimal(row["USO_CASILLERO_PORCENTAJE"]),
                                                Convert.ToDecimal(row["IMPORTE_EJECUTADO"]),
                                                Convert.ToBoolean(row["APROBAR_RECEPCIONADO"])
                                            ),
                        PORCENTAJE_CASILLERO = Convert.ToDecimal(row["USO_CASILLERO_PORCENTAJE"]),
                        FEC_RETOR_PLAN = string.IsNullOrEmpty(row["FEC_RETOR_PLAN"]?.ToString()) ? (DateTime?)null : Convert.ToDateTime(row["FEC_RETOR_PLAN"]),
                        ST_NO_PROCESADO = !string.IsNullOrEmpty(row["ST_NO_PROCESO"]?.ToString()) && Convert.ToBoolean(row["ST_NO_PROCESO"]),
                        ST_LISTADO = !string.IsNullOrEmpty(row["ST_LISTADO"]?.ToString()) && Convert.ToBoolean(row["ST_LISTADO"])
                    });
                }
            }
            return lista;
        }

        private decimal ObtenerCasilleroAuto(decimal importeCasillero, decimal casilleroPorcentaje, decimal importeEjecutado, bool st_aprob_recep)
        {
            //if (importeCasillero > 0)
            //    return decimal.Round(importeCasillero, 2);
            //else if (st_aprob_recep)
            //{
            //    return decimal.Round(importeEjecutado / 100 * casilleroPorcentaje, 2);
            //}
            //return 0;
            if (st_aprob_recep)
                return decimal.Round(importeEjecutado / 100 * casilleroPorcentaje, 2);
            return 0;
        }

        private void ChkNo_CheckedChanged(object sender, EventArgs e)
        {
            txtMotivo.Text = chkNoProcesado.Checked ? string.Empty : txtMotivo.Text;
            chkSi.Checked = false;
            chkNoSal.Checked = false;
            chkOtros.Checked = false;
            chkNoProcesado.Checked = false;
            if (acces == 0 && chkNo.Checked && idOption != ActualizarResultado)
            {
                if (idEstado != DESCONTADA_CERRADA)
                    numImporte.Value = 0;
                DataTable dt2 = BLSeguimiento.ObtenerLlamadasXId(this.idLlamadaBase);
                if (dt2 != null && dt2.Rows.Count > 0 && Convert.ToDateTime(Convert.ToDateTime(dt2.Rows[0]["FECHA_LLAMADA"]).ToShortDateString() + " " + dt2.Rows[0]["HORA_LLAMADA"].ToString()) > Convert.ToDateTime(dtFecha.Value.ToShortDateString() + " " + dtHora.Value.ToString("HH:mm:ss")))
                {
                    chkSi.Checked = true;
                    chkNo.Checked = false;
                    _ = MessageBox.Show("La fecha seleccionada debe ser mayor o igual a la fecha programada : " + Convert.ToDateTime(dt2.Rows[0]["FECHA_LLAMADA"]).ToShortDateString() + " " + dt2.Rows[0]["HORA_LLAMADA"].ToString(), "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idOption = Reprogramado;
                int idLlamadaBase = 0;
                ProgramarLlamada llamada = new ProgramarLlamada(idOption, TituloReprogramar, idSeguimiento, idEstado, nroPlanilla, nombrePuntoCobranza, estado, idLlamadaBase, tipoLlamada, act: 1)
                {
                    StartPosition = FormStartPosition.CenterScreen
                };
                llamada.LlamadaResultado = ObtenerDatosGrabar1();
                llamada.acces = 1;
                llamada.chkNo.Checked = true;
                llamada.fecha = Convert.ToDateTime(dtFecha.Value.ToShortDateString() + " " + dtHora.Value.ToString("HH:mm:ss"));
                _ = llamada.ShowDialog();
                ac = llamada.ac;
                if (ac == 1)
                    Close();
                else
                    chkNo.Checked = false;
            }
            acces = 0;
        }

        private bool ValidarDatosActualizar()
        {
            ValidarVaciosNumImputs();
            DataTable dt = BLSeguimiento.ObtenerLlamadaXIdLlamadaBase(idLlamadaBase);
            if (dt != null && dt.Rows.Count > 0)
            {
                DateTime f1 = Convert.ToDateTime(Convert.ToDateTime(dt.Rows[0]["FECHA_LLAMADA"]).ToShortDateString() + " " + dt.Rows[0]["HORA_LLAMADA"].ToString());
                DateTime f2 = Convert.ToDateTime(dtFecha.Value.ToShortDateString() + " " + dtHora.Value.ToString("HH:mm:ss"));
                if (f1 < f2)
                {
                    _ = MessageBox.Show("La fecha seleccionada debe ser menor o igual a " + f1, "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else
                    return Result();
            }
            return Result();

            bool Result()
            {
                if (idLlamada != 0)
                {
                    DataTable dt2 = BLSeguimiento.ObtenerLlamadasXId(idLlamada);

                    if (dt2 != null && dt2.Rows.Count > 0 && Convert.ToDateTime(Convert.ToDateTime(dt2.Rows[0]["FECHA_LLAMADA"]).ToShortDateString() + " " + dt2.Rows[0]["HORA_LLAMADA"].ToString()) > Convert.ToDateTime(dtFecha.Value.ToShortDateString() + " " + dtHora.Value.ToString("HH:mm:ss")))
                    {
                        _ = MessageBox.Show("La fecha seleccionada debe ser mayor o igual a " + Convert.ToDateTime(dt2.Rows[0]["FECHA_LLAMADA"]).ToShortDateString() + " " + dt2.Rows[0]["HORA_LLAMADA"].ToString(), "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    else
                        return Result2();
                }
                return Result2();
            }

            bool Result2()
            {
                if (chkEst.Checked && string.IsNullOrEmpty(txtNombre.Text))
                {
                    _ = MessageBox.Show("Digite el nombre de la persona", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else if (chkEst.Checked && string.IsNullOrEmpty(txtArea.Text))
                {
                    _ = MessageBox.Show("Digite el área de labor de la persona", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                //else if (chkSi.Checked && pnlImporte.Visible && idEstado == DESCONTADA && numImporte.Value == 0)
                //{
                //    _ = MessageBox.Show("Digite el importe descontado", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return false;
                //}
                else if (chkNoSal.Checked && idOption == ActualizarResultado && idEstado == DESCONTADA)
                {
                    if (BLSeguimiento.ListarLlamadasPendientesXIdSeguimiento(idSeguimiento).Rows.Count > 0)
                    {
                        _ = MessageBox.Show("No se puede actualizar esta llamada como estado NO DESCONTADO, ya que tiene aún llamadas programadas pendientes", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                //else if (idOption == ActualizarResultado && !chkNo.Checked && !chkSi.Checked && !chkOtros.Checked && !chkNoProcesado.Checked && idEstado == DESCONTADA_CERRADA)
                //{
                //    _ = MessageBox.Show("Seleccione si se recibio el listado de descuento", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return false;
                //}
                else if (idOption == ActualizarResultado && chkSi.Checked && idEstado == DESCONTADA_CERRADA && numImpListado.Value == 0)
                {
                    _ = MessageBox.Show("Ingrese el importe de listado", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                return true;
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (ValidarDatosEliminar())
            {
                ChequeBLL BLCheque = new ChequeBLL();
                DataTable dtEnvio = BLCheque.ObtenerEnvioChequeXIdSeguimiento(idSeguimiento, 0);
                DataTable dtTransferencia = BLCheque.ObtenerTransChequeXIdSeguimiento(idSeguimiento, 0);
                DataTable dtDeposito = BLCheque.ObtenerDespositoChequeXIdSeguimiento(idSeguimiento, 0);

                if (dtEnvio.Rows.Count > 0 || dtTransferencia.Rows.Count > 0 || dtDeposito.Rows.Count > 0)
                {
                    _ = MessageBox.Show("Esta planilla tiene cheques registrados, no se puede eliminar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult dr = MessageBox.Show("¿Esta seguro de elimianar esta llamada?", "MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        LLamadas llamada = ObtenerDatosActualizar();
                        _ = BLSeguimiento.EliminarLlamada(llamada)
                            ? _ = MessageBox.Show("Eliminado correctamente", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            : _ = MessageBox.Show("Ocurrió un problema al eliminar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Close();
                    }
                    catch (Exception ex)
                    {
                        _ = MessageBox.Show(ex.Message, "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void BtnImporteListado_Click(object sender, EventArgs e)
        {
            SeguimientoPlanillaTo se = BLSeguimiento.ObtenerSeguimientoPlanillaTo(idSeguimiento);
            FrmInsertarImporteListado frmImporteListado = new FrmInsertarImporteListado(se, dgvImporteListado, idEstado, btnImporteListado.Tag.ToString())
            {
                StartPosition = FormStartPosition.CenterParent
            };
            frmImporteListado.EventPasarTotal += FrmImporteListado_PasarTotal;
            _ = frmImporteListado.ShowDialog();
        }

        private void FrmImporteListado_PasarTotal(DataGridView gridView)
        {
            dgvImporteListado = gridView;
            decimal total = 0;
            decimal totalCasilleroManual = 0;
            foreach (DataGridViewRow row in gridView.Rows)
            {
                total += Convert.ToDecimal(row.Cells["IMPORTE_LISTADO"].Value);
                totalCasilleroManual += Convert.ToDecimal(row.Cells["CASILLERO_MAN"].Value);
            }
            numImpListado.Value = total;
            if (btnImporteListado.Tag.ToString() == "2" || btnImporteListado.Tag.ToString() == "3")
                numImpCasilleroMan.Value = totalCasilleroManual;
        }

        private void ChkNoProcesado_Click(object sender, EventArgs e)
        {
            chkSi.Checked = false;
            numImporte.Value = 0;
            numImporte.Enabled = false;
            chkNo.Checked = false;
            numImpCasilleroAuto.Value = 0;
            numImpNeto.Value = 0;
            chkNoSal.Checked = false;
            chkOtros.Checked = false;
            txtMotivo.Text = "No se a procesado";
            numImpListado.Value = 0;
        }

        private bool ValidarDatosEliminar()
        {
            DataTable dt = BLSeguimiento.ObtenerLlamadaXIdLlamadaBase(idLlamadaBase);
            if (dt != null && dt.Rows.Count > 0)
            {
                _ = MessageBox.Show("Este registro no se puede eliminar, ya que tiene llamadas asociadas", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void CambiarTamañoForm(int idOption, int idEstado)
        {
            if (idOption == ProgramadoCerrado || idOption == OtrosResultados)
            {
                Size = new Size { Width = 387, Height = 470 };
            }
            else if (idOption == Reprogramado || idOption == Programado)
            {
                if (idOption == Reprogramado && idEstado != CHEQUE_ENVIADO)
                {
                    if (idEstado == RECEPCIONADA && act == 1)
                    {
                        Size = new Size { Height = 496, Width = 924 };
                    }
                    else if (idEstado == PROCESADA && idOption == Reprogramado && act == 1)
                    {
                        Size = new Size { Height = 496, Width = 924 };
                    }
                    else if (idEstado == PROCESADA && idOption == Reprogramado && act == 0)
                    {
                        Size = new Size { Height = 496, Width = 924 };
                    }
                    else if (idEstado == DESCONTADA_CERRADA && idOption == Reprogramado && act == 1)
                    {
                        Size = new Size { Height = 496, Width = 924 };
                    }
                }
                else if (idEstado == PROCESADA || idEstado == DESCONTADA || idEstado == DESCONTADO_CONFIRMADO
                        || idEstado == NO_EJECUTADO)
                {
                    Size = new Size { Height = 496, Width = 924 };
                }
                else if (idEstado == DESCONTADA_CERRADA || idEstado == NO_DESCONTADO)
                {
                    Size = new Size { Height = 496, Width = 924 };
                }
                else if (idEstado == CHEQUE_ENVIADO || idEstado == CHEQUE_RECEPCIONADO || idEstado == CHEQUE_DEPOSITADO || idEstado == CHEQUE_CONFIRMADO)
                {
                    Size = new Size { Height = 496, Width = 924 };
                }
            }
            else if (idOption == Resultado || idOption == ActualizarResultado)
            {
                if (idOption == Resultado)
                {
                    if (idEstado == DESCONTADA_CERRADA || idEstado == NO_EJECUTADO)
                    {
                        Size = new Size { Width = 1150, Height = 490 };
                    }
                    else if (idEstado != DESCONTADA && idEstado != DESCONTADA_CERRADA)
                    {
                        Size = new Size { Width = 743, Height = 495 };
                    }
                }
                else if (idOption == ActualizarResultado)
                {
                    if (idEstado == RECEPCIONADA || idEstado == PROCESADA || idEstado == DESCONTADO_CONFIRMADO)
                    {
                        Size = new Size { Width = 743, Height = 480 };
                    }
                    else if (idEstado == DESCONTADA || idEstado == DESCONTADA_CERRADA || idEstado == NO_EJECUTADO)
                    {
                        Size = new Size { Width = 1150, Height = 490 };
                    }
                }
                else
                {
                    Size = new Size { Width = 743, Height = 480 };
                }
            }
        }

        private void DtFechaTrans_ValueChanged(object sender, EventArgs e)
        {
            dtFechaTrans.CustomFormat = "dd/MM/yyyy";
            if (dtFechaTrans.Value > DateTime.Now)
            {
                _ = MessageBox.Show("La fecha de entrega de lista debe ser menor o igual a la fecha de hoy!!!!", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtFechaTrans.Value = DateTime.Now;
            }
        }

        private void ChkSi_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkSi.Checked && idEstado == RECEPCIONADA && idOption == Resultado)
                {
                    btnRegistrarLlamada.PerformClick();
                    if (cerrado)
                    {
                        DataTable dtPlanilla = SeguimientoPlanilla.Instancia?.ObtenerPlanillaRecepcion();
                        MantenedorRecepcionPlanilla recepcion = new MantenedorRecepcionPlanilla("Recepción", dtPlanilla)
                        {
                            StartPosition = FormStartPosition.CenterScreen
                        };
                        recepcion.NombrePuntoCobranza = nombrePuntoCobranza;
                        _ = recepcion.ShowDialog();
                    }
                }
                else if (chkSi.Checked && idEstado == CHEQUE_ENVIADO && idOption == Resultado)
                {
                    btnRegistrarLlamada.PerformClick();
                    if (cerrado)
                    {
                        RegistroCheque cheque = new RegistroCheque(-1, idSeguimiento, nombrePuntoCobranza, nroPlanilla, nroPllaEnv)
                        {
                            StartPosition = FormStartPosition.CenterScreen
                        };
                        _ = cheque.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show(ex.Message, "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChkNoSal_Click(object sender, EventArgs e)
        {
            chkSi.Checked = false;
            numImporte.Value = 0;
            numImporte.Enabled = false;
            chkNo.Checked = false;
            numImpCasilleroAuto.Value = 0;
            numImpNeto.Value = 0;
            chkNoProcesado.Checked = false;
            txtMotivo.Text = string.Empty;
        }

        private void NumImporte_ValueChanged(object sender, EventArgs e)
        {
            if (!_acc && idEstado == DESCONTADA_CERRADA)
            {
                importeListado = numImpListado.Value;
                importeCasilleroAuto = numImpCasilleroAuto.Value;
                impOtrosDescuentos = numOtrosDescto.Value;
                importeCasilleroMan = numImpCasilleroMan.Value;
                impEjecutado = numImpEjec.Value;
            }
            numImpNeto.Value = decimal.Round(numImpEjec.Value - (numImpCasilleroAuto.Value + numImpCasilleroMan.Value), 2);
        }

        private void ChkOtros_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOtros.Checked)
            {
                _acc = true;
                chkSi.Checked = !chkOtros.Checked;
                chkNo.Checked = false;
                chkNoProcesado.Checked = false;
                numImpListado.Value = 0;
                numImpCasilleroAuto.Value = 0;
                numOtrosDescto.Value = 0;
                if (idEstado == DESCONTADA_CERRADA)
                {
                    numImporte.ReadOnly = true;
                    numImpListado.ReadOnly = true;
                    numImpCasilleroAuto.ReadOnly = true;
                    numOtrosDescto.ReadOnly = true;
                }
            }
        }

        private void ChkSi_Click(object sender, EventArgs e)
        {
            chkNo.Checked = false;
            chkNoSal.Checked = false;
            numImporte.Enabled = true;
            chkOtros.Checked = false;
            chkNoProcesado.Checked = false;
            if (idEstado == DESCONTADA)
                numImporte.ReadOnly = !chkSi.Checked;
            if (chkSi.Checked && idEstado == DESCONTADA_CERRADA)
            {
                numImporte.ReadOnly = false;
                //> numImpListado.ReadOnly = false;
                //> numImpCasilleroAuto.ReadOnly = false;
                numOtrosDescto.ReadOnly = false;
                _acc = true;
                numImpListado.Value = importeListado;
                numImpCasilleroAuto.Value = importeCasilleroAuto;
                numOtrosDescto.Value = impOtrosDescuentos;
                numImpCasilleroMan.Value = importeCasilleroMan;
                numImpEjec.Value = impEjecutado;
                _acc = false;
            }
        }

        private void MostrarDatosEnvio()
        {
            DataTable dt;
            if (tipoLlamada.Length == 0)
            {
                dt1(EnvioCorreo);
                dt2(EnvioFisico);
            }
            else if (tipoLlamada == TipoProgramadoCorreo)
            {
                dt1(EnvioCorreo);
            }
            else if (tipoLlamada == TipoProgramadoCorresp)
            {
                dt1(EnvioFisico);
            }

            void dt1(string tipoEnvio)
            {
                dt = BLSeguimiento.ListarEnvioSeguimientoPlanillaXTipoEnvio(idSeguimiento, tipoEnvio);
                if (dt != null && dt.Rows.Count > 0)
                {
                    //> chkEst.Checked = true;
                    txtNombre.Text = dt.Rows[0]["NOMBRE"].ToString();
                    txtArea.Text = dt.Rows[0]["AREA_LABOR"].ToString();
                    txtTelefono.Text = dt.Rows[0]["TELEFONO"].ToString();
                    txtNombreInst.Text = dt.Rows[0]["NOMBRE_INST"].ToString();
                    txtTlfInst.Text = dt.Rows[0]["TLF_INST"].ToString();
                    gbContent.Enabled = true;
                }
                else if (idOption == RECEPCIONADA)
                    gbContent.Enabled = false;
            }

            void dt2(string tipoEnvio)
            {
                dt = BLSeguimiento.ListarEnvioSeguimientoPlanillaXTipoEnvio(idSeguimiento, tipoEnvio);
                if (dt != null && dt.Rows.Count > 0)
                {
                    //> chkEst.Checked = true;
                    txtNombre2.Text = dt.Rows[0]["NOMBRE"].ToString();
                    txtArea2.Text = dt.Rows[0]["AREA_LABOR"].ToString();
                    txtTlf2.Text = dt.Rows[0]["TELEFONO"].ToString();
                    txtNombreInst2.Text = dt.Rows[0]["NOMBRE_INST"].ToString();
                    txtTlfInst2.Text = dt.Rows[0]["TLF_INST"].ToString();
                    gbLlamadaProgramada.Enabled = true;
                }
                else
                    gbLlamadaProgramada.Enabled = false;
            }

            dgvLlamadas.AutoResizeColumns();
            dgvLlamadas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void ListarLlamadasPendientes()
        {
            dgvLlamadas.DataSource = BLSeguimiento.ListarLlamadasPendientesXIdSeguimiento(idSeguimiento);
            if (dgvLlamadas != null)
            {
                dgvLlamadas.Columns["ID_LLAMADA"].Visible = false;
                dgvLlamadas.Columns["ID_LLAMADA_BASE"].Visible = false;
                dgvLlamadas.Columns["ID_SEGUIMIENTO"].Visible = false;
                dgvLlamadas.Columns["ID_ESTADO"].Visible = false;
                dgvLlamadas.Columns["ID_PERSONA"].Visible = false;
                dgvLlamadas.Columns["NOMBRE_INST"].Visible = false;
                dgvLlamadas.Columns["TLF_INST"].Visible = false;
                dgvLlamadas.Columns["OBSERVACION"].Visible = false;
                dgvLlamadas.Columns["TIPO"].Visible = false;
                dgvLlamadas.Columns["DESC_TIPO"].HeaderText = "TIPO";
            }
        }

        public void EnabledButtons(bool act)
        {
            if (act)
            {
                btnActualizar.Enabled = false;
                btnEliminar.Enabled = false;
                btnRegistrarLlamada.Enabled = false;
                ReadOnly();
            }

            if (idEstado == DESCONTADA_CERRADA)
                btnEliminar.Enabled = false;

            lblPuntoCobranza.Visible = false;
        }

        private void ReadOnly(bool read)
        {
            foreach (Control control in gbLlamadaProgramada.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.ReadOnly = read;
                    textBox.BackColor = Color.White;
                }

                if (control is GroupBox gb)
                {
                    foreach (TextBox text in gb.Controls.OfType<TextBox>().ToList())
                    {
                        text.ReadOnly = read;
                        text.BackColor = Color.White;
                    }
                }
            }
        }

        private void ReadOnly()
        {
            foreach (Control control in gbContent.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.ReadOnly = true;
                    textBox.BackColor = Color.White;
                }

                if (control is GroupBox gb)
                {
                    foreach (TextBox text in gb.Controls.OfType<TextBox>().ToList())
                    {
                        text.ReadOnly = true;
                        text.BackColor = Color.White;
                    }
                }
            }
        }

        private bool ValidarPlanillasEjecutadasAprobadas()
        {
            if (idEstado == DESCONTADA_CERRADA)
            {
                SeguimientoPlanillaTo se = BLSeguimiento.ObtenerSeguimientoPlanillaTo(idSeguimiento);
                DataTable dt = BLSeguimiento.ObtenerPlanillasXGrupo(se);
                foreach (DataRow row in dt.Rows)
                {
                    if (!Convert.ToBoolean(row["APROBAR_RECEPCIONADO"]) && Convert.ToBoolean(row["ST_LISTADO"]))
                    {
                        _ = MessageBox.Show("La planilla N° " + row["NRO_PLANILLA_COB"].ToString() + " debe estar aprobada para cerrar esta etapa", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
