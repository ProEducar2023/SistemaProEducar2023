using FacturacionElectronica;
using FacturacionElectronica.intercambio;
using FacturacionElectronica.modelos;
using FacturacionElectronica.service.implement;
using FacturacionElectronica.service.interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.MOD_FACT_VTA
{
    public partial class frmEnvioFacturasEFact : Form
    {
        #region . Variables .
        IIFacVtaService ifactService;
        ITFacVtaService tfactService;
        IDirectorioService iDirectorioService;
        List<dynamic> invoicesPending;
        List<dynamic> invoicesEnviados;
        string RutaPdf;
        string RutaXml;
        string RutaCdr;
        string smtp;
        int puertoSmtp;
        string ClaveSol;
        string UsuarioSol;
        string CertificadoDigital;
        string ClaveCertificado;
        string RutaImagen;
        string UrlSunatEnvio;
        string EmailEmisor;
        string claveEmailEmisor;
        string EmailContacto;
        string cuentaBanco;

        bool envioCorreoAutomatico;
        List<Mensaje> mensajes;
        #endregion

        #region structure
        struct Mensaje
        {
            public string descripcion;
            public string icon;
        }
        #endregion

        #region . Metodos .
        private void LoadYears()
        {
            try
            {
                var lista = ifactService.LoadYears();
                cboAño.Items.Clear();
                foreach (var item in lista)
                {
                    cboAño.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// Initialize controls events
        /// </summary>
        private void InitializeEvents()
        {
            dgvPendingInvoice.CellContentClick += new DataGridViewCellEventHandler(Ok);
            btnSendSunat.Click += new EventHandler(SendSunat);
        }

        /// <summary>
        /// Initialize services
        /// </summary>
        private void InitializeServices()
        {
            ifactService = Injector.Get<IFacVtaServiceImpl>();
            tfactService = Injector.Get<TFacVtaServiceImpl>();
            iDirectorioService = Injector.Get<DirectorioServiceImpl>();

        }

        /// <summary>
        /// List pending invoices
        /// </summary>
        private void ListPendingInvoice()
        {
            invoicesPending = ifactService.ListPendingInvoice();
            dgvPendingInvoice.Rows.Clear();
            foreach (var item in invoicesPending)
            {
                dgvPendingInvoice.Rows.Add(item.Id, item.CoSucursal, item.DesSucursal, item.CodClase, item.DesClase, item.CodDoc, item.NroDoc, item.FechaDoc, item.CodCliente, item.DesCliente, item.DocCliente, false, item.Observacion);
            }
        }


        /// <summary>
        /// List sending invoices
        /// </summary>
        private void ListSendInvoice(string año, string mes)
        {
            invoicesEnviados = ifactService.ListSendingInvoice(año, mes);
            dgvSendingInvoice.Rows.Clear();

            foreach (var item in invoicesEnviados)
            {
                dgvSendingInvoice.Rows.Add(item.Id, item.CoSucursal, item.DesSucursal, item.CodClase, item.DesClase, item.CodDoc, item.NroDoc, item.FechaDoc, item.CodCliente, item.DesCliente, item.DocCliente, "Consultar sunat", "Ver pdf", "Enviar correo", "Descargar archivos");
            }
        }


        /// <summary>
        /// validate before send
        /// </summary>
        /// <returns>true: valid , false: invalid</returns>
        private bool ValidSend()
        {
            if (dgvPendingInvoice.CurrentCell == null)
            {
                MessageBox.Show("Debe seleccionar al menos una factura", "Factura electrónica", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }


        private void LoadParameter()
        {
            var listParamater = iDirectorioService.getAll();
            RutaPdf = listParamater.Where(x => x.Codigo == "FILPDF").SingleOrDefault().Descripcion;
            RutaXml = listParamater.Where(x => x.Codigo == "FILXML").SingleOrDefault().Descripcion;
            RutaCdr = listParamater.Where(x => x.Codigo == "FILCDR").SingleOrDefault().Descripcion;
            smtp = listParamater.Where(x => x.Codigo == "SMTP").SingleOrDefault().Descripcion;
            puertoSmtp = Convert.ToInt32(listParamater.Where(x => x.Codigo == "SMTPPT").SingleOrDefault().Descripcion);
            ClaveSol = listParamater.Where(x => x.Codigo == "PASSOL").SingleOrDefault().Descripcion;
            UsuarioSol = listParamater.Where(x => x.Codigo == "USUSOL").SingleOrDefault().Descripcion;
            CertificadoDigital = listParamater.Where(x => x.Codigo == "FIRDIG").SingleOrDefault().Descripcion;
            ClaveCertificado = listParamater.Where(x => x.Codigo == "PASSFD").SingleOrDefault().Descripcion;
            RutaImagen = listParamater.Where(x => x.Codigo == "IMALOG").SingleOrDefault().Descripcion;
            EmailEmisor = listParamater.Where(x => x.Codigo == "CORRFE").SingleOrDefault().Descripcion;
            claveEmailEmisor = listParamater.Where(x => x.Codigo == "PASSFE").SingleOrDefault().Descripcion;
            EmailContacto = listParamater.Where(x => x.Codigo == "CONTFE").SingleOrDefault().Descripcion;
            envioCorreoAutomatico = listParamater.Where(x => x.Codigo == "AUTCOR").SingleOrDefault().Descripcion == "SI";
            cuentaBanco = listParamater.Where(x => x.Codigo == "NUM_BN").SingleOrDefault().Descripcion;
            UrlSunatEnvio = ConfigurationManager.AppSettings["UrlSunatEnvio"];
        }

        private async Task<bool> GenerateXml(dynamic invoice, List<dynamic> lines, string codCliente)
        {
            btnSendSunat.Enabled = false;
            HttpResponseMessage response;
            var proxy = new HttpClient { BaseAddress = new Uri(ConfigurationManager.AppSettings["UrlElectronicInvoiceApi"]) };

            DocumentoElectronico documento = ifactService.generateElectronicInvoice(invoice, lines);
            documento.CuentaBancoNacion = cuentaBanco;

            string metodoApi;
            switch (documento.TipoDocumento)
            {
                case "07":
                    metodoApi = "api/GenerarNotaCredito";
                    break;
                case "08":
                    metodoApi = "api/GenerarNotaDebito";
                    break;
                default:
                    metodoApi = "api/GenerarFactura";
                    break;
            }

            response = await proxy.PostAsJsonAsync(metodoApi, documento);

            if (response.IsSuccessStatusCode)
            {
                var documentoResponse = await response.Content.ReadAsAsync<DocumentoResponse>();

                if (documentoResponse.Exito)
                {
                    metodoApi = "api/Firmar";
                    FirmadoRequest firmadoRequest = new FirmadoRequest
                    {
                        CertificadoDigital = Convert.ToBase64String(File.ReadAllBytes(CertificadoDigital)),
                        PasswordCertificado = ClaveCertificado,
                        RucEmisor = documento.Emisor.NroDocumento,
                        TramaXmlSinFirma = documentoResponse.TramaXmlSinFirma,
                        UnSoloNodoExtension = true
                    };

                    response = await proxy.PostAsJsonAsync(metodoApi, firmadoRequest);

                    if (response.IsSuccessStatusCode)
                    {
                        var firmadoResponse = await response.Content.ReadAsAsync<FirmadoResponse>();

                        if (firmadoResponse.Exito)
                        {
                            //Gurdamos el archivo
                            string path = string.Format(@"{0}\{1}-{2}.xml", RutaXml, documento.IdDocumento, documento.TipoDocumento);
                            File.WriteAllBytes(path, Convert.FromBase64String(firmadoResponse.TramaXmlFirmado));

                            switch (documento.TipoDocumento)
                            {
                                case "07":
                                    metodoApi = "api/GenerarNotaCreditoPdf";
                                    break;
                                case "08":
                                    metodoApi = "api/GenerarNotaDebitoPdf";
                                    break;
                                case "03":
                                    metodoApi = "api/GenerarBoletaPdf";
                                    break;
                                case "01":
                                    metodoApi = "api/GenerarFacturaPdf";
                                    break;
                            }

                            PdfRequest pdfRequest = new PdfRequest
                            {
                                ClaveCertificado = ClaveCertificado,
                                Documento = documento,
                                ResumenFirma = firmadoResponse.ResumenFirma,
                                RutaCertificado = CertificadoDigital,
                                RutaImagen = RutaImagen,
                                RutaPdf = RutaPdf,
                                ValorFirma = firmadoResponse.ValorFirma
                            };

                            response = await proxy.PostAsJsonAsync(metodoApi, pdfRequest);

                            if (response.IsSuccessStatusCode)
                            {
                                var pdfResponse = await response.Content.ReadAsAsync<PdfResponse>();

                                if (pdfResponse.Exito)
                                {
                                    metodoApi = "api/EnviarDocumento";
                                    EnviarDocumentoRequest enviarDocumentoRequest = new EnviarDocumentoRequest
                                    {
                                        ClaveSol = ClaveSol,
                                        Ruc = documento.Emisor.NroDocumento,
                                        TipoDocumento = documento.TipoDocumento,
                                        IdDocumento = documento.IdDocumento,
                                        TramaXmlFirmado = firmadoResponse.TramaXmlFirmado,
                                        UsuarioSol = UsuarioSol,
                                        EndPointUrl = UrlSunatEnvio,
                                        RutaXml = RutaXml,
                                        RutaCdr = RutaCdr,
                                        RutaPdf = RutaPdf,
                                        NombreEmpresa = documento.Emisor.NombreLegal,
                                        EmailEmisor = EmailEmisor,
                                        EmailCliente = "",
                                        WebEmpresa = "",
                                        FechaEmision = documento.FechaEmision,
                                        PasswordEmisor = claveEmailEmisor,
                                        RutaImagen = RutaImagen,
                                        TotalDocumento = documento.TotalVenta,
                                        Moneda = documento.Moneda,
                                        PuertoSmtp = puertoSmtp,
                                        Smpt = smtp,
                                        EsConexionsegura = false
                                    };

                                    response = await proxy.PostAsJsonAsync(metodoApi, enviarDocumentoRequest);

                                    if (response.IsSuccessStatusCode)
                                    {
                                        var enviarDocumentoResponse = await response.Content.ReadAsAsync<EnviarDocumentoResponse>();

                                        if (enviarDocumentoResponse.Exito)
                                        {
                                            mensajes.Add(new Mensaje
                                            {
                                                descripcion = string.Format("{0}-{1} :{2}", documento.IdDocumento, documento.TipoDocumento, enviarDocumentoResponse.MensajeRespuesta),
                                                icon = "Info.png"
                                            });

                                            //guardamos el cdr
                                            File.WriteAllBytes(string.Format(@"{0}\{1}-{2}.xml", RutaCdr, documento.IdDocumento, documento.TipoDocumento), Convert.FromBase64String(enviarDocumentoResponse.TramaZipCdr));

                                            //Actualizar Estado Envio
                                            ifactService.UpdateStateSend(invoice);

                                            if (envioCorreoAutomatico)
                                            {
                                                metodoApi = "api/EnviarMail";
                                                List<string> listEmailCliente = new List<string>();

                                                if (ConfigurationManager.AppSettings["EsPrueba"].ToUpper() == "TRUE")
                                                {
                                                    listEmailCliente.Add(ConfigurationManager.AppSettings["EmailsPrueba"]);
                                                }
                                                else
                                                {
                                                    listEmailCliente = ifactService.getemailsCustomer(codCliente);
                                                    listEmailCliente.Add(EmailContacto);
                                                }


                                                enviarDocumentoRequest.EmailCliente = string.Join(",", listEmailCliente.ToArray());

                                                response = await proxy.PostAsJsonAsync(metodoApi, enviarDocumentoRequest);

                                                if (response.IsSuccessStatusCode)
                                                {
                                                    var responseGenerador = await response.Content.ReadAsAsync<ResponseGenerador>();

                                                    if (!responseGenerador.Exito)
                                                    {
                                                        mensajes.Add(new Mensaje
                                                        {
                                                            descripcion = string.Format("{0}-{1} : {2}", documento.IdDocumento, documento.TipoDocumento, responseGenerador.MensajeError),
                                                            icon = "error.png"
                                                        });
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (string.IsNullOrEmpty(enviarDocumentoResponse.MensajeRespuesta))
                                                mensajes.Add(new Mensaje
                                                {
                                                    descripcion = string.Format("{0}-{1} : {2} - {3}", documento.IdDocumento, documento.TipoDocumento, enviarDocumentoResponse.CodigoRespuesta, enviarDocumentoResponse.MensajeError),
                                                    icon = "error.png"
                                                });
                                            else
                                                mensajes.Add(new Mensaje
                                                {
                                                    descripcion = string.Format("{0}-{1} : {2} - {3}", documento.IdDocumento, documento.TipoDocumento, enviarDocumentoResponse.CodigoRespuesta, enviarDocumentoResponse.MensajeRespuesta),
                                                    icon = "error.png"
                                                });

                                        }
                                    }
                                }
                                else
                                {
                                    mensajes.Add(new Mensaje
                                    {
                                        descripcion = string.Format("{0}-{1} : {2}", documento.IdDocumento, documento.TipoDocumento, pdfResponse.MensajeError),
                                        icon = "error.png"
                                    });
                                }
                            }
                        }
                        else
                        {
                            mensajes.Add(new Mensaje
                            {
                                descripcion = string.Format("{0}-{1} : {2}", documento.IdDocumento, documento.TipoDocumento, firmadoResponse.MensajeError),
                                icon = "error.png"
                            });
                        }
                    }
                }
                else
                {
                    mensajes.Add(new Mensaje
                    {
                        descripcion = string.Format("{0}-{1} : {2}", documento.IdDocumento, documento.TipoDocumento, documentoResponse.MensajeError),
                        icon = "error.png"
                    });
                }
            }
            btnSendSunat.Enabled = true;
            return true;
        }

        public void MostrarMensajes()
        {
            if (mensajes.Count == 0) return;

            Form frm = new Form();
            DataGridView dgv = new DataGridView();
            dgv.Columns.Add("Mensaje", "Mensaje");

            dgv.Columns[0].Width = 800;

            DataGridViewImageColumn img = new DataGridViewImageColumn();
            dgv.Columns.Add(img);
            img.HeaderText = " ";
            img.Name = "img";
            dgv.Columns[1].Width = 30;



            foreach (var item in mensajes)
            {
                dgv.Rows.Add(item.descripcion, item.icon != "error.png" ? Properties.Resources.comprobar : Properties.Resources.Remove);

            }

            dgv.Dock = DockStyle.Fill;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;

            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Size = new Size(900, 300);

            frm.Controls.Add(dgv);
            frm.Text = "Mensajes";
            frm.ShowDialog();
        }
        #endregion

        #region . Constructor .
        public frmEnvioFacturasEFact()
        {
            InitializeComponent();
            InitializeServices();
            InitializeEvents();
            LoadParameter();
            ListPendingInvoice();
            LoadYears();
        }

        #endregion

        #region . Events .
        private void Ok(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            if (dgv.Name.Equals(dgvPendingInvoice.Name))
            {
                if (e.ColumnIndex == 11)
                {
                    dgv[e.ColumnIndex, e.RowIndex].Value = !Convert.ToBoolean(dgv[e.ColumnIndex, e.RowIndex].Value);
                }
            }
        }

        private async void SendSunat(object sender, EventArgs e)
        {
            ssPrincipal.Visible = true;
            mensajes = new List<Mensaje>();

            if (!ValidSend()) return;

            foreach (DataGridViewRow row in dgvPendingInvoice.Rows)
            {
                bool ok = Convert.ToBoolean(row.Cells[11].Value);

                if (ok)
                {
                    int Id = Convert.ToInt32(row.Cells[0].Value);
                    string codCliente = row.Cells[0].Value.ToString();
                    dynamic invoice = invoicesPending.Where(x => x.Id == Id).SingleOrDefault();
                    var lines = tfactService.getDetails(invoice);
                    bool rpt = await GenerateXml(invoice, lines, codCliente);

                }
            }


            MostrarMensajes();
            ssPrincipal.Visible = false;
            ListPendingInvoice();

        }

        private void chkSeleccionarTodos_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvPendingInvoice.Rows)
            {
                row.Cells["seleccion"].Value = chkSeleccionarTodos.Checked;
            }
        }


        private void btnLoadImvoices_Click(object sender, EventArgs e)
        {
            string año = cboAño.Text;
            string mes = (cboMes.SelectedIndex + 1).ToString("00");

            ListSendInvoice(año, mes);
        }

        private async void dgvSendingInvoice_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Consultar a sunat
            if (e.ColumnIndex == 11)
            {
                HttpResponseMessage response;

                int Id = Convert.ToInt32(dgvSendingInvoice[0, e.RowIndex].Value);
                dynamic invoice = invoicesEnviados.Where(x => x.Id == Id).SingleOrDefault();
                dynamic emisor = ifactService.GetDataSupplier();

                var proxy = new HttpClient { BaseAddress = new Uri(ConfigurationManager.AppSettings["UrlElectronicInvoiceApi"]) };

                string metodoApi = "api/ConsultarCdr";

                var request = new ConsultaConstanciaRequest
                {
                    ClaveSol = ClaveSol,
                    UsuarioSol = UsuarioSol,
                    Ruc = emisor.Ruc,
                    EndPointUrl = ConfigurationManager.AppSettings["UrlSunatConsulta"],
                    TipoDocumento = invoice.CodDoc,
                    Serie = invoice.NroDoc.ToString().Split('-')[0],
                    Numero = Convert.ToInt32(invoice.NroDoc.ToString().Split('-')[1])
                };

                response = await proxy.PostAsJsonAsync(metodoApi, request);

                var enviarDocumentoResponse = await response.Content.ReadAsAsync<EnviarDocumentoResponse>();

                if (!enviarDocumentoResponse.Exito)
                {
                    MessageBox.Show(string.IsNullOrEmpty(enviarDocumentoResponse.MensajeError) ? enviarDocumentoResponse.MensajeRespuesta : enviarDocumentoResponse.MensajeError, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //guardamos el cdr
                File.WriteAllBytes(string.Format(@"{0}\{1}-{2}", RutaCdr, invoice.NroDoc, invoice.CodDoc), Convert.FromBase64String(enviarDocumentoResponse.TramaZipCdr));

                MessageBox.Show(enviarDocumentoResponse.MensajeRespuesta, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //ver Pdf
            else if (e.ColumnIndex == 12)
            {
                int Id = Convert.ToInt32(dgvSendingInvoice[0, e.RowIndex].Value);
                dynamic invoice = invoicesEnviados.Where(x => x.Id == Id).SingleOrDefault();

                string rutaArchivo = string.Format(@"{0}\{1}-{2}.pdf", RutaPdf, invoice.NroDoc, invoice.CodDoc);
                if (!File.Exists(rutaArchivo))
                {
                    MessageBox.Show("No existe el pdf", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (var form = new Form())
                {
                    var wb = new WebBrowser();
                    wb.Dock = DockStyle.Fill;
                    wb.Url = new Uri(rutaArchivo);
                    form.Controls.Add(wb);
                    form.WindowState = FormWindowState.Maximized;
                    form.ShowDialog();
                }
            }
            //Enviar correos
            else if (e.ColumnIndex == 13)
            {
                HttpResponseMessage response;
                var proxy = new HttpClient { BaseAddress = new Uri(ConfigurationManager.AppSettings["UrlElectronicInvoiceApi"]) };
                int Id = Convert.ToInt32(dgvSendingInvoice[0, e.RowIndex].Value);
                dynamic invoice = invoicesEnviados.Where(x => x.Id == Id).SingleOrDefault();
                var lines = tfactService.getDetails(invoice);

                DocumentoElectronico documento = ifactService.generateElectronicInvoice(invoice, lines);

                string rutaArchivo = string.Format(@"{0}\{1}-{2}.xml", RutaPdf, invoice.NroDoc, invoice.CodDoc);

                string metodoApi = "api/EnviarMail";

                dynamic emisor = ifactService.GetDataSupplier();
                var listEmailCliente = ifactService.getemailsCustomer(invoice.CodCliente);
                if (!string.IsNullOrEmpty(EmailContacto))
                    listEmailCliente.Add(EmailContacto);


                var FrmEnviarCorreos = new FrmEnviarCorreos(string.Join(",", listEmailCliente.ToArray()));
                FrmEnviarCorreos.ShowDialog();

                string emailCliente = FrmEnviarCorreos.correo1;

                if (!FrmEnviarCorreos.Ok) return;

                var EnviarDocumentoRequest = new EnviarDocumentoRequest
                {
                    RutaPdf = RutaPdf,
                    RutaXml = RutaXml,
                    RutaCdr = RutaCdr,
                    IdDocumento = invoice.NroDoc,
                    TipoDocumento = invoice.CodDoc,
                    NombreEmpresa = emisor.RazonSocial,
                    Ruc = emisor.Ruc,
                    EmailEmisor = EmailEmisor,
                    EmailCliente = emailCliente,
                    FechaEmision = invoice.FechaDoc.ToString("yyyy-MM-dd"),
                    PasswordEmisor = claveEmailEmisor,
                    RutaImagen = RutaImagen,
                    TotalDocumento = documento.TotalVenta,
                    Moneda = invoice.CodMoneda,
                    PuertoSmtp = puertoSmtp,
                    Smpt = smtp,
                    EsConexionsegura = false,
                    WebEmpresa = ""

                };

                response = await proxy.PostAsJsonAsync(metodoApi, EnviarDocumentoRequest);

                var responseGenerador = await response.Content.ReadAsAsync<ResponseGenerador>();

                if (!responseGenerador.Exito)
                {
                    MessageBox.Show(responseGenerador.MensajeError, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                MessageBox.Show("Correo enviado correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //Desacrgar archivos
            else if (e.ColumnIndex == 14)
            {
                int Id = Convert.ToInt32(dgvSendingInvoice[0, e.RowIndex].Value);
                dynamic invoice = invoicesEnviados.Where(x => x.Id == Id).SingleOrDefault();

                string nombreArchivo = string.Format("{1}-{2}", RutaPdf, invoice.NroDoc, invoice.CodDoc);


                string archivoPdf = string.Format(@"{0}\{1}.pdf", RutaPdf, nombreArchivo);
                string archivoXml = string.Format(@"{0}\{1}.xml", RutaXml, nombreArchivo);
                string archivoCdr = string.Format(@"{0}\{1}.zip", RutaCdr, nombreArchivo);

                using (var fbd = new FolderBrowserDialog())
                {
                    DialogResult result = fbd.ShowDialog();

                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    {
                        string directorio = string.Format(@"{0}\{1}", fbd.SelectedPath, nombreArchivo);

                        if (!Directory.Exists(directorio))
                            Directory.CreateDirectory(directorio);

                        string archivoPdfNew = string.Format(@"{0}\{1}.pdf", directorio, nombreArchivo);
                        string archivoXmlNew = string.Format(@"{0}\{1}.xml", directorio, nombreArchivo);
                        string archivoCdrNew = string.Format(@"{0}\{1}.zip", directorio, nombreArchivo);

                        if (File.Exists(archivoPdf))
                            File.Copy(archivoPdf, archivoPdfNew, true);

                        if (File.Exists(archivoXml))
                            File.Copy(archivoXml, archivoXmlNew, true);

                        if (File.Exists(archivoCdr))
                            File.Copy(archivoCdr, archivoCdrNew, true);

                        MessageBox.Show(string.Format("Los archivos fueron descargados en: {0}", directorio), "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void txt_letra1_TextChanged(object sender, EventArgs e)
        {
            int rowIndex = -1;

            DataGridViewRow row = dgvSendingInvoice.Rows
                .Cast<DataGridViewRow>()
                .Where(r => r.Cells[6].Value.ToString().ToUpper().Contains(txt_letra1.Text.ToUpper()))
                .FirstOrDefault();

            if (row == null)
            {
                dgvSendingInvoice.ClearSelection();
                return;
            }

            rowIndex = row.Index;

            dgvSendingInvoice.Rows[rowIndex].Selected = true;
            dgvSendingInvoice.CurrentCell = dgvSendingInvoice.Rows[rowIndex].Cells[4];
        }

        private void txt_letra_TextChanged(object sender, EventArgs e)
        {
            int rowIndex = -1;
            dgvPendingInvoice.ClearSelection();
            DataGridViewRow row = dgvPendingInvoice.Rows
                .Cast<DataGridViewRow>()
                .Where(r => r.Cells[6].Value.ToString().ToUpper().Contains(txt_letra.Text.ToUpper()))
                .FirstOrDefault();

            if (row == null)
            {
                dgvPendingInvoice.ClearSelection();
                return;
            }

            rowIndex = row.Index;

            dgvPendingInvoice.Rows[rowIndex].Selected = true;
            dgvPendingInvoice.CurrentCell = dgvPendingInvoice.Rows[rowIndex].Cells[4];
        }

        #endregion
    }
}
