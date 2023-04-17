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
    public partial class frmEnvioBajasEFact : Form
    {
        #region . Variables .
        IIFacVtaService ifactService;
        IDirectorioService iDirectorioService;
        ITicketSunatServices iTicketSunatServices;

        string RutaXml;
        string ClaveSol;
        string UsuarioSol;
        string CertificadoDigital;
        string ClaveCertificado;
        string UrlSunatEnvio;
        List<dynamic> invoicesPending;
        List<dynamic> listParamater;


        #endregion

        #region . Constructor .
        public frmEnvioBajasEFact()
        {
            InitializeComponent();
            InitializeServices();
            LoadParameter();
            ListPendingInvoice();
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
            iDirectorioService = Injector.Get<DirectorioServiceImpl>();
            iTicketSunatServices = Injector.Get<TicketSunatServicesImpl>();

        }

        private void ListPendingInvoice()
        {
            invoicesPending = ifactService.ListPendingInvoiceBajas();
            dgvPendingInvoice.Rows.Clear();
            foreach (var item in invoicesPending)
            {
                dgvPendingInvoice.Rows.Add(item.Id, item.CoSucursal, item.DesSucursal, item.CodClase, item.DesClase, item.CodDoc, item.NroDoc, item.FechaDoc, item.CodCliente, item.DesCliente, item.DocCliente, false, item.Observacion);
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
                    MessageBox.Show("No ha Seleccionado nningún registro", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }


                return exito;
            });

            return await task;
        }
        #endregion

        #region . Eventos .
        private async void btnEnviarSunat_Click(object sender, EventArgs e)
        {
            bool esValido = await Validar();
            if (!esValido) return;

            string metodoApi = "api/GenerarComunicacionBaja";
            List<dynamic> invoices = new List<dynamic>();

            var baja = new ComunicacionBaja();
            var emisor = ifactService.GetDataSupplier();

            baja.Emisor = new Contribuyente
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
            baja.FechaEmision = DateTime.Now.ToShortDateString();
            string numeroCorrelativo = listParamater.Where(x => x.Codigo == "CORBAJ").SingleOrDefault().Descripcion;
            baja.IdDocumento = string.Format("RA-{0}-{1}", DateTime.Now.ToString("yyyyMMdd"), int.Parse(numeroCorrelativo));
            int linea = 1;

            var listaDocumentoBaja = new List<DocumentoBaja>();

            foreach (DataGridViewRow row in dgvPendingInvoice.Rows)
            {
                bool ok = Convert.ToBoolean(row.Cells[11].Value);

                if (ok)
                {
                    int Id = Convert.ToInt32(row.Cells[0].Value);
                    string codCliente = row.Cells[0].Value.ToString();
                    dynamic invoice = invoicesPending.Where(x => x.Id == Id).SingleOrDefault();
                    invoices.Add(invoice);
                    fechaReferencia = invoice.FechaDoc;

                    listaDocumentoBaja.Add(new DocumentoBaja
                    {
                        Id = linea,
                        Serie = invoice.NroDoc.ToString().Split('-')[0],
                        Correlativo = invoice.NroDoc.ToString().Split('-')[1],
                        MotivoBaja = "ANULACIÓN DEL DOCUMENTO",
                        TipoDocumento = invoice.CodDoc
                    });

                    linea++;
                }
            }

            baja.Bajas = listaDocumentoBaja;
            baja.FechaReferencia = fechaReferencia.ToShortDateString();

            HttpResponseMessage response;
            var proxy = new HttpClient { BaseAddress = new Uri(ConfigurationManager.AppSettings["UrlElectronicInvoiceApi"]) };

            response = await proxy.PostAsJsonAsync(metodoApi, baja);

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
                RucEmisor = baja.Emisor.NroDocumento,
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

            File.WriteAllBytes(string.Format(@"{0}\{1}.xml", RutaXml, baja.IdDocumento), Convert.FromBase64String(firmadoResponse.TramaXmlFirmado));

            var EnviarDocumentoRequest = new EnviarDocumentoRequest
            {
                Ruc = baja.Emisor.NroDocumento,
                IdDocumento = baja.IdDocumento,
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
                MessageBox.Show(string.Format("{0} : {1}", baja.IdDocumento, enviarResumenResponse.MensajeError), "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show(string.Format("{0} : Su número de ticket es {1}", baja.IdDocumento, enviarResumenResponse.NroTicket), "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);


            //Actualizar estado de envio e insertar ticket
            foreach (var item in invoices)
            {
                ifactService.UpdateStateVoided(item);
                dynamic ticketSunat = new ExpandoObject();
                ticketSunat.NroTicket = enviarResumenResponse.NroTicket;
                ticketSunat.TipoDoc = item.CodDoc;
                ticketSunat.NroDoc = item.NroDoc;
                ticketSunat.Tipo = "A";
                ticketSunat.Estado = "";
                ticketSunat.ArchivoXml = string.Format("{0}.xml", baja.IdDocumento);
                ticketSunat.ArchivoCdr = "";
                iTicketSunatServices.Insertar(ticketSunat);
            }

            //Actualizar Correlativo
            iDirectorioService.UpdateIdResumen("CORBAJ");
            ListPendingInvoice();

        }
        private void dgvPendingInvoice_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 11)
            {
                dgvPendingInvoice[e.ColumnIndex, e.RowIndex].Value = !Convert.ToBoolean(dgvPendingInvoice[e.ColumnIndex, e.RowIndex].Value);
            }
        }

        #endregion

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
