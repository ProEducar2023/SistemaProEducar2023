using FacturacionElectronica;
using FacturacionElectronica.intercambio;
using FacturacionElectronica.modelos;
using FacturacionElectronica.service.implement;
using FacturacionElectronica.service.interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.MOD_FACT_VTA
{
    public partial class FrmEnvioResumenDiario : Form
    {
        #region . Variables .
        IIFacVtaService ifactService;
        ITFacVtaService tfactService;
        IDirectorioService iDirectorioService;
        ITicketSunatServices iTicketSunatServices;
        List<dynamic> invoicesPending;
        List<dynamic> invoicesVoided;
        List<dynamic> listParamater;
        string RutaXml;
        string ClaveSol;
        string UsuarioSol;
        string CertificadoDigital;
        string ClaveCertificado;
        string UrlSunatEnvio;
        #endregion

        #region . Constructor .
        public FrmEnvioResumenDiario()
        {
            InitializeComponent();
            InitializeServices();
            LoadParameter();
            ListPendingInvoice();
            ListVoidedInvoice();
        }
        #endregion

        #region . Metodos .
        private void LoadParameter()
        {
            listParamater = iDirectorioService.getAll();
            RutaXml = listParamater.Where(x => x.Codigo == "FILXML").SingleOrDefault().Descripcion;
            ClaveSol = listParamater.Where(x => x.Codigo == "PASSOL").SingleOrDefault().Descripcion;
            UsuarioSol = listParamater.Where(x => x.Codigo == "USUSOL").SingleOrDefault().Descripcion;
            CertificadoDigital = listParamater.Where(x => x.Codigo == "FIRDIG").SingleOrDefault().Descripcion;
            ClaveCertificado = listParamater.Where(x => x.Codigo == "PASSFD").SingleOrDefault().Descripcion;
            UrlSunatEnvio = ConfigurationManager.AppSettings["UrlSunatEnvio"];
        }

        /// <summary>
        /// Initialize services
        /// </summary>
        private void InitializeServices()
        {
            ifactService = Injector.Get<IFacVtaServiceImpl>();
            tfactService = Injector.Get<TFacVtaServiceImpl>();
            iDirectorioService = Injector.Get<DirectorioServiceImpl>();
            iTicketSunatServices = Injector.Get<TicketSunatServicesImpl>();
        }

        /// <summary>
        /// List pending invoices
        /// </summary>
        private void ListPendingInvoice()
        {
            invoicesPending = ifactService.ListPendingInvoiceBoleta();
            dgvPendingInvoice.Rows.Clear();
            foreach (var item in invoicesPending)
            {
                dgvPendingInvoice.Rows.Add(item.Id, item.CoSucursal, item.DesSucursal, item.CodClase, item.DesClase, item.CodDoc, item.NroDoc, item.FechaDoc, item.CodCliente, item.DesCliente, item.DocCliente, false, item.Observacion);
            }
        }

        /// <summary>
        /// List voided invoices
        /// </summary>
        private void ListVoidedInvoice()
        {
            invoicesVoided = ifactService.ListPendingInvoiceBoletaBajas();
            dgvVoided.Rows.Clear();
            foreach (var item in invoicesVoided)
            {
                dgvVoided.Rows.Add(item.Id, item.CoSucursal, item.DesSucursal, item.CodClase, item.DesClase, item.CodDoc, item.NroDoc, item.FechaDoc, item.CodCliente, item.DesCliente, item.DocCliente, false, item.Observacion);
            }
        }

        private async Task<bool> Validar()
        {
            var task = Task.Factory.StartNew(() =>
            {
                bool exito = true;
                bool estaSeleccionado = false;
                bool primeraVuelta = true;

                DateTime fecha = new DateTime();
                DateTime fechaAnt = new DateTime();


                foreach (DataGridViewRow row in dgvPendingInvoice.Rows)
                {
                    bool Ok = Convert.ToBoolean(row.Cells[11].Value);

                    if (Ok)
                    {
                        estaSeleccionado = true;

                        fecha = Convert.ToDateTime(row.Cells[7].Value).Date;

                        if (primeraVuelta)
                        {
                            fechaAnt = fecha;
                            primeraVuelta = false;
                        }

                        if (DateTime.Compare(fecha, fechaAnt) != 0)
                        {
                            exito = false;
                            MessageBox.Show("Debe seleccionar comprobantes con fechas iguales", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        }
                        fechaAnt = fecha;
                    }
                }

                if (!estaSeleccionado)
                {
                    exito = false;
                    MessageBox.Show("No ha Seleccionado ningún registro", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }


                return exito;
            });

            return await task;
        }

        private async Task<bool> ValidarBajas()
        {
            var task = Task.Factory.StartNew(() =>
            {
                bool exito = true;
                bool estaSeleccionado = false;
                bool primeraVuelta = true;

                DateTime fecha = new DateTime();
                DateTime fechaAnt = new DateTime();


                foreach (DataGridViewRow row in dgvVoided.Rows)
                {
                    bool Ok = Convert.ToBoolean(row.Cells[11].Value);

                    if (Ok)
                    {
                        estaSeleccionado = true;

                        fecha = Convert.ToDateTime(row.Cells[7].Value).Date;

                        if (primeraVuelta)
                        {
                            fechaAnt = fecha;
                            primeraVuelta = false;
                        }

                        if (DateTime.Compare(fecha, fechaAnt) != 0)
                        {
                            exito = false;
                            MessageBox.Show("Debe seleccionar comprobantes con fechas iguales", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        }
                        fechaAnt = fecha;
                    }
                }

                if (!estaSeleccionado)
                {
                    exito = false;
                    MessageBox.Show("No ha Seleccionado nningún registro", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }


                return exito;
            });

            return await task;
        }
        #endregion

        #region . Eventos .
        private void chkSelecionar_CheckedChanged(object sender, EventArgs e)
        {
            var date = dpDia.Value.Date;

            foreach (DataGridViewRow row in dgvPendingInvoice.Rows)
            {
                if (Convert.ToDateTime(row.Cells[7].Value).Date.CompareTo(date) == 0)
                {
                    row.Cells[11].Value = chkSelecionar.Checked;
                }
            }
        }

        private void dgvPendingInvoice_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 11)
            {
                dgvPendingInvoice[e.ColumnIndex, e.RowIndex].Value = !Convert.ToBoolean(dgvPendingInvoice[e.ColumnIndex, e.RowIndex].Value);
            }
        }

        private async void btnEnviarSunat_Click(object sender, EventArgs e)
        {
            try
            {
                btnEnviarSunat.Enabled = false;
                bool esValido = await Validar();
                if (!esValido) return;

                string metodoApi = "api/GenerarResumenDiario";
                List<dynamic> invoices = new List<dynamic>();
                ResumenDiarioNuevo resumen = new ResumenDiarioNuevo();
                var emisor = ifactService.GetDataSupplier();

                resumen.Emisor = new Contribuyente
                {
                    Departamento = emisor.Departamento,
                    Direccion = emisor.Direccion,
                    Distrito = emisor.Distrito,
                    NombreComercial = emisor.RazonSocial,
                    NombreLegal = emisor.RazonSocial,
                    NroDocumento = emisor.Ruc,
                    Provincia = emisor.Provincia,
                    TipoDocumento = "6",
                    Ubigeo = emisor.Ubigeo,
                    Urbanizacion = ""
                };

                DateTime fechaReferencia = new DateTime();
                resumen.FechaEmision = DateTime.Now.ToShortDateString();
                string numeroCorrelativo = listParamater.Where(x => x.Codigo == "CORRES").SingleOrDefault().Descripcion;
                resumen.IdDocumento = string.Format("RC-{0}-{1}", DateTime.Now.ToString("yyyyMMdd"), int.Parse(numeroCorrelativo));
                var ListaGrupoResumenNuevo = new List<GrupoResumenNuevo>();
                int linea = 1;
                foreach (DataGridViewRow row in dgvPendingInvoice.Rows)
                {
                    bool ok = Convert.ToBoolean(row.Cells[11].Value);

                    if (ok)
                    {
                        int Id = Convert.ToInt32(row.Cells[0].Value);
                        string codCliente = row.Cells[0].Value.ToString();
                        dynamic invoice = invoicesPending.Where(x => x.Id == Id).SingleOrDefault();
                        invoices.Add(invoice);
                        List<dynamic> lines = tfactService.getDetails(invoice);
                        decimal gratuitas = 0;
                        decimal gravadas = 0;
                        decimal totalVenta = 0;
                        decimal totalIgv = 0;
                        decimal totalDescuentos = 0;
                        decimal inafectas = 0;
                        fechaReferencia = invoice.FechaDoc;
                        var customer = ifactService.GetDataCustomer(invoice.CodCliente);

                        foreach (var item in lines)
                        {
                            gratuitas += item.ValorReferencial + item.ValorIgvReferencial;
                            totalIgv += item.ValorIgv;
                            totalDescuentos += item.ValorDcto;

                            if (item.TipoAfectacion.StartsWith("3"))
                                inafectas += item.PrecioVenta;

                            if (item.TipoAfectacion.StartsWith("1"))
                                gravadas += item.ValorVenta;


                        }

                        totalVenta = gratuitas > 0 ? 0 : gravadas + inafectas + totalIgv;

                        string tipoDocumentoEReceptor = "";
                        string tipoDoc = customer.Tipodocumento;
                        switch (tipoDoc)
                        {
                            case "01":
                                tipoDocumentoEReceptor = "1";
                                break;
                            case "06":
                                tipoDocumentoEReceptor = "6";
                                break;
                            case "00":
                                tipoDocumentoEReceptor = "0";
                                break;
                        }

                        ListaGrupoResumenNuevo.Add(new GrupoResumenNuevo
                        {
                            CodigoEstadoItem = 1,
                            Id = linea,
                            TipoDocumento = invoice.CodDoc,
                            IdDocumento = invoice.NroDoc,
                            NroDocumentoReceptor = customer.Ruc,
                            TipoDocumentoReceptor = tipoDocumentoEReceptor,
                            DocumentoRelacionado = invoice.NroRef,
                            TipoDocumentoRelacionado = invoice.CodRef,
                            Moneda = invoice.CodMoneda,
                            Gratuitas = gratuitas,
                            Gravadas = gravadas,
                            TotalVenta = totalVenta,
                            TotalIgv = totalIgv,
                            TotalDescuentos = totalDescuentos,
                            Inafectas = inafectas
                        });
                        linea++;
                    }
                }

                resumen.Resumenes = ListaGrupoResumenNuevo;
                resumen.FechaReferencia = fechaReferencia.ToShortDateString();

                HttpResponseMessage response;
                var proxy = new HttpClient { BaseAddress = new Uri(ConfigurationManager.AppSettings["UrlElectronicInvoiceApi"]) };

                response = await proxy.PostAsJsonAsync(metodoApi, resumen);

                var documentoResponse = await response.Content.ReadAsAsync<DocumentoResponse>();

                if (!documentoResponse.Exito)
                {
                    MessageBox.Show(documentoResponse.MensajeError, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var FirmadoRequest = new FirmadoRequest
                {
                    CertificadoDigital = Convert.ToBase64String(File.ReadAllBytes(CertificadoDigital)),
                    PasswordCertificado = ClaveCertificado,
                    RucEmisor = resumen.Emisor.NroDocumento,
                    TramaXmlSinFirma = documentoResponse.TramaXmlSinFirma,
                    UnSoloNodoExtension = true
                };

                metodoApi = "api/Firmar";
                response = await proxy.PostAsJsonAsync(metodoApi, FirmadoRequest);
                var firmadoResponse = await response.Content.ReadAsAsync<FirmadoResponse>();

                if (!firmadoResponse.Exito)
                {
                    MessageBox.Show(firmadoResponse.MensajeError, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                File.WriteAllBytes(string.Format(@"{0}\{1}.xml", RutaXml, resumen.IdDocumento), Convert.FromBase64String(firmadoResponse.TramaXmlFirmado));

                var EnviarDocumentoRequest = new EnviarDocumentoRequest
                {
                    Ruc = resumen.Emisor.NroDocumento,
                    IdDocumento = resumen.IdDocumento,
                    ClaveSol = ClaveSol,
                    UsuarioSol = UsuarioSol,
                    TramaXmlFirmado = firmadoResponse.TramaXmlFirmado,
                    EndPointUrl = UrlSunatEnvio
                };

                metodoApi = "api/EnviarResumen";
                response = await proxy.PostAsJsonAsync(metodoApi, EnviarDocumentoRequest);
                var enviarResumenResponse = await response.Content.ReadAsAsync<EnviarResumenResponse>();

                if (!enviarResumenResponse.Exito)
                {
                    MessageBox.Show(string.Format("{0} : {1}", resumen.IdDocumento, enviarResumenResponse.MensajeError), "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                MessageBox.Show(string.Format("{0} : Su número de ticket es {1}", resumen.IdDocumento, enviarResumenResponse.NroTicket), "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);


                //Actualizar estado de envio e insertar ticket
                foreach (var item in invoices)
                {
                    ifactService.UpdateStateSend(item);
                    dynamic ticketSunat = new ExpandoObject();
                    ticketSunat.NroTicket = enviarResumenResponse.NroTicket;
                    ticketSunat.TipoDoc = item.CodDoc;
                    ticketSunat.NroDoc = item.NroDoc;
                    ticketSunat.Tipo = "R";
                    ticketSunat.Estado = "";
                    ticketSunat.ArchivoXml = string.Format("{0}.xml", resumen.IdDocumento);
                    ticketSunat.ArchivoCdr = "";
                    iTicketSunatServices.Insertar(ticketSunat);
                }

                //Actualizar Correlativo
                iDirectorioService.UpdateIdResumen("CORRES");
                ListPendingInvoice();
                btnEnviarSunat.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnEnviarSunat.Enabled = true;
            }

        }

        private async void btnEnviarBajas_Click(object sender, EventArgs e)
        {
            bool esValido = await ValidarBajas();
            if (!esValido) return;

            string metodoApi = "api/GenerarResumenDiario";
            List<dynamic> invoices = new List<dynamic>();
            ResumenDiarioNuevo resumen = new ResumenDiarioNuevo();
            var emisor = ifactService.GetDataSupplier();

            resumen.Emisor = new Contribuyente
            {
                Departamento = emisor.Departamento,
                Direccion = emisor.Direccion,
                Distrito = emisor.Distrito,
                NombreComercial = emisor.RazonSocial,
                NombreLegal = emisor.RazonSocial,
                NroDocumento = emisor.Ruc,
                Provincia = emisor.Provincia,
                TipoDocumento = "6",
                Ubigeo = emisor.Ubigeo,
                Urbanizacion = ""
            };

            DateTime fechaReferencia = new DateTime();
            resumen.FechaEmision = DateTime.Now.ToShortDateString();
            string numeroCorrelativo = listParamater.Where(x => x.Codigo == "CORRES").SingleOrDefault().Descripcion;
            resumen.IdDocumento = string.Format("RC-{0}-{1}", DateTime.Now.ToString("yyyyMMdd"), int.Parse(numeroCorrelativo));
            var ListaGrupoResumenNuevo = new List<GrupoResumenNuevo>();
            int linea = 1;

            foreach (DataGridViewRow row in dgvVoided.Rows)
            {
                bool ok = Convert.ToBoolean(row.Cells[11].Value);

                if (ok)
                {
                    int Id = Convert.ToInt32(row.Cells[0].Value);
                    string codCliente = row.Cells[0].Value.ToString();
                    dynamic invoice = invoicesVoided.Where(x => x.Id == Id).SingleOrDefault();
                    invoices.Add(invoice);
                    List<dynamic> lines = tfactService.getDetails(invoice);
                    decimal gratuitas = 0;
                    decimal gravadas = 0;
                    decimal totalVenta = 0;
                    decimal totalIgv = 0;
                    decimal totalDescuentos = 0;
                    decimal inafectas = 0;
                    fechaReferencia = invoice.FechaDoc;
                    var customer = ifactService.GetDataCustomer(invoice.CodCliente);

                    foreach (var item in lines)
                    {
                        gratuitas += item.ValorReferencial + item.ValorIgvReferencial;
                        totalIgv += item.ValorIgv;
                        totalDescuentos += item.ValorDcto;

                        if (item.TipoAfectacion.StartsWith("3"))
                            inafectas += item.PrecioVenta;

                        if (item.TipoAfectacion.StartsWith("1"))
                            gravadas += item.ValorVenta;


                    }

                    totalVenta = gratuitas > 0 ? 0 : gravadas + inafectas + totalIgv;

                    string tipoDocumentoEReceptor = "";
                    string tipoDoc = customer.Tipodocumento;
                    switch (tipoDoc)
                    {
                        case "01":
                            tipoDocumentoEReceptor = "1";
                            break;
                        case "06":
                            tipoDocumentoEReceptor = "6";
                            break;
                        case "00":
                            tipoDocumentoEReceptor = "0";
                            break;
                    }

                    ListaGrupoResumenNuevo.Add(new GrupoResumenNuevo
                    {
                        CodigoEstadoItem = 3,
                        Id = linea,
                        TipoDocumento = invoice.CodDoc,
                        IdDocumento = invoice.NroDoc,
                        NroDocumentoReceptor = customer.Ruc,
                        TipoDocumentoReceptor = tipoDocumentoEReceptor,
                        DocumentoRelacionado = invoice.NroRef,
                        TipoDocumentoRelacionado = invoice.CodRef,
                        Moneda = invoice.CodMoneda,
                        Gratuitas = gratuitas,
                        Gravadas = gravadas,
                        TotalVenta = totalVenta,
                        TotalIgv = totalIgv,
                        TotalDescuentos = totalDescuentos,
                        Inafectas = inafectas
                    });
                    linea++;
                }
            }

            resumen.Resumenes = ListaGrupoResumenNuevo;
            resumen.FechaReferencia = fechaReferencia.ToShortDateString();

            HttpResponseMessage response;
            var proxy = new HttpClient { BaseAddress = new Uri(ConfigurationManager.AppSettings["UrlElectronicInvoiceApi"]) };

            response = await proxy.PostAsJsonAsync(metodoApi, resumen);

            var documentoResponse = await response.Content.ReadAsAsync<DocumentoResponse>();

            if (!documentoResponse.Exito)
            {
                MessageBox.Show(documentoResponse.MensajeError, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var FirmadoRequest = new FirmadoRequest
            {
                CertificadoDigital = Convert.ToBase64String(File.ReadAllBytes(CertificadoDigital)),
                PasswordCertificado = ClaveCertificado,
                RucEmisor = resumen.Emisor.NroDocumento,
                TramaXmlSinFirma = documentoResponse.TramaXmlSinFirma,
                UnSoloNodoExtension = true
            };

            metodoApi = "api/Firmar";
            response = await proxy.PostAsJsonAsync(metodoApi, FirmadoRequest);
            var firmadoResponse = await response.Content.ReadAsAsync<FirmadoResponse>();

            if (!firmadoResponse.Exito)
            {
                MessageBox.Show(firmadoResponse.MensajeError, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            File.WriteAllBytes(string.Format(@"{0}\{1}.xml", RutaXml, resumen.IdDocumento), Convert.FromBase64String(firmadoResponse.TramaXmlFirmado));

            var EnviarDocumentoRequest = new EnviarDocumentoRequest
            {
                Ruc = resumen.Emisor.NroDocumento,
                IdDocumento = resumen.IdDocumento,
                ClaveSol = ClaveSol,
                UsuarioSol = UsuarioSol,
                TramaXmlFirmado = firmadoResponse.TramaXmlFirmado,
                EndPointUrl = UrlSunatEnvio
            };

            metodoApi = "api/EnviarResumen";
            response = await proxy.PostAsJsonAsync(metodoApi, EnviarDocumentoRequest);
            var enviarResumenResponse = await response.Content.ReadAsAsync<EnviarResumenResponse>();

            if (!enviarResumenResponse.Exito)
            {
                MessageBox.Show(string.Format("{0} : {1}", resumen.IdDocumento, enviarResumenResponse.MensajeError), "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show(string.Format("{0} : Su número de ticket es {1}", resumen.IdDocumento, enviarResumenResponse.NroTicket), "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);


            //Actualizar estado de envio e insertar ticket
            foreach (var item in invoices)
            {
                ifactService.UpdateStateVoided(item);
                dynamic ticketSunat = new ExpandoObject();
                ticketSunat.NroTicket = enviarResumenResponse.NroTicket;
                ticketSunat.TipoDoc = item.CodDoc;
                ticketSunat.NroDoc = item.NroDoc;
                ticketSunat.Tipo = "B";
                ticketSunat.Estado = "";
                ticketSunat.ArchivoXml = string.Format("{0}.xml", resumen.IdDocumento);
                ticketSunat.ArchivoCdr = "";
                iTicketSunatServices.Insertar(ticketSunat);
            }

            //Actualizar Correlativo
            iDirectorioService.UpdateIdResumen("CORRES");
            ListVoidedInvoice();
        }

        private void dgvVoided_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 11)
            {
                dgvVoided[e.ColumnIndex, e.RowIndex].Value = !Convert.ToBoolean(dgvVoided[e.ColumnIndex, e.RowIndex].Value);
            }
        }

        private void chkSeleccionarAnuladas_CheckedChanged(object sender, EventArgs e)
        {
            var date = dpDias2.Value.Date;

            foreach (DataGridViewRow row in dgvVoided.Rows)
            {
                if (Convert.ToDateTime(row.Cells[7].Value).CompareTo(date) == 0)
                {
                    row.Cells[11].Value = chkSeleccionarAnuladas.Checked;
                }
            }
        }
        #endregion


    }
}
