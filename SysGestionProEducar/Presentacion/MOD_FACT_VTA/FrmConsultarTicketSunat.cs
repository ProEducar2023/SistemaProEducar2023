using FacturacionElectronica;
using FacturacionElectronica.intercambio;
using FacturacionElectronica.service.implement;
using FacturacionElectronica.service.interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Windows.Forms;

namespace Presentacion.MOD_FACT_VTA
{
    public partial class FrmConsultarTicketSunat : Form
    {
        #region . Variables .
        IIFacVtaService ifactService;
        ITicketSunatServices iTicketSunatServices;
        IDirectorioService iDirectorioService;
        List<dynamic> listParamater;
        List<dynamic> tickesResumen;
        List<dynamic> tickesResumenBajasBoletas;
        List<dynamic> tickesBajasFactura;
        dynamic emisor;
        string ClaveSol;
        string UsuarioSol;
        string RutaCdr;
        string RutaXml;
        string UrlSunatEnvio;
        #endregion

        #region . Constructor .
        public FrmConsultarTicketSunat()
        {
            InitializeComponent();
            InitializeServices();
            LoadParameter();
        }
        #endregion

        #region . Metodos .
        /// <summary>
        /// Initialize services
        /// </summary>
        private void InitializeServices()
        {
            iTicketSunatServices = Injector.Get<TicketSunatServicesImpl>();
            iDirectorioService = Injector.Get<DirectorioServiceImpl>();
            ifactService = Injector.Get<IFacVtaServiceImpl>();
        }

        private void LoadParameter()
        {
            listParamater = iDirectorioService.getAll();
            RutaCdr = listParamater.Where(x => x.Codigo == "FILCDR").SingleOrDefault().Descripcion;
            RutaXml = listParamater.Where(x => x.Codigo == "FILXML").SingleOrDefault().Descripcion;
            ClaveSol = listParamater.Where(x => x.Codigo == "PASSOL").SingleOrDefault().Descripcion;
            UsuarioSol = listParamater.Where(x => x.Codigo == "USUSOL").SingleOrDefault().Descripcion;
            UrlSunatEnvio = ConfigurationManager.AppSettings["UrlSunatEnvio"];
            emisor = ifactService.GetDataSupplier();
        }

        string RecuperarNombreArchivo(string nombre)
        {

            if (nombre.Contains(".xml"))
                return nombre.Substring(0, nombre.Length - 4) + ".zip";
            else if (nombre.Contains(".zip"))
                return nombre;
            else
                return nombre + ".zip";
        }
        #endregion

        #region . Eventos .
        private void btnListar_Click(object sender, EventArgs e)
        {
            try
            {
                var fechaDe = dpDe.Value.Date;
                var fechaHasta = dpHasta.Value.Date;
                tickesResumen = iTicketSunatServices.Listar("R", fechaDe, fechaHasta);

                var tickesResumenAgrupado = tickesResumen.Select(x => new { x.NroTicket, x.Fecha, x.Estado, x.ArchivoXml, x.ArchivoCdr }).Distinct();

                dgvResumenBoletas.Rows.Clear();
                foreach (var item in tickesResumenAgrupado)
                {
                    dgvResumenBoletas.Rows.Add(item.NroTicket, item.Fecha, item.Estado, "Detalle", "Descargar", item.ArchivoXml, item.ArchivoCdr);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btnEnviarSunat_Click(object sender, EventArgs e)
        {
            if (dgvResumenBoletas.CurrentCell == null) return;

            string metodoApi = "api/ConsultarTicket";
            string numeroTicket = dgvResumenBoletas[0, dgvResumenBoletas.CurrentCell.RowIndex].Value.ToString();

            var ConsultaTicketRequest = new ConsultaTicketRequest
            {
                UsuarioSol = UsuarioSol,
                ClaveSol = ClaveSol,
                EndPointUrl = UrlSunatEnvio,
                Ruc = emisor.Ruc,
                NroTicket = numeroTicket
            };

            HttpResponseMessage response;
            var proxy = new HttpClient { BaseAddress = new Uri(ConfigurationManager.AppSettings["UrlElectronicInvoiceApi"]) };
            List<dynamic> lista;
            response = await proxy.PostAsJsonAsync(metodoApi, ConsultaTicketRequest);
            var EnviarDocumentoResponse = await response.Content.ReadAsAsync<EnviarDocumentoResponse>();
            if (!EnviarDocumentoResponse.Exito)
            {
                MessageBox.Show(string.IsNullOrEmpty(EnviarDocumentoResponse.MensajeError) ? EnviarDocumentoResponse.MensajeRespuesta : EnviarDocumentoResponse.MensajeError, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                //Actualizamos ticket
                lista = tickesResumen.Where(x => x.NroTicket == numeroTicket).ToList();
                foreach (var item in lista)
                {
                    item.ArchivoCdr = "";
                    item.Estado = string.IsNullOrEmpty(EnviarDocumentoResponse.MensajeError) ? EnviarDocumentoResponse.MensajeRespuesta : EnviarDocumentoResponse.MensajeError;
                    iTicketSunatServices.Update(item);
                }

                btnListar.PerformClick();

                return;
            }

            //Guardar el cdr
            File.WriteAllBytes(string.Format(@"{0}\{1}", RutaCdr, RecuperarNombreArchivo(EnviarDocumentoResponse.NombreArchivo)), Convert.FromBase64String(EnviarDocumentoResponse.TramaZipCdr));

            //Actualizamos ticket
            lista = tickesResumen.Where(x => x.NroTicket == numeroTicket).ToList();
            foreach (var item in lista)
            {
                item.ArchivoCdr = RecuperarNombreArchivo(EnviarDocumentoResponse.NombreArchivo);
                item.Estado = EnviarDocumentoResponse.MensajeRespuesta;
                iTicketSunatServices.Update(item);
            }

            btnEnviarSunat.PerformClick();
        }

        private void dgvResumenBoletas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Detalles
            if (e.ColumnIndex == 3)
            {
                string numeroTicket = dgvResumenBoletas[0, dgvResumenBoletas.CurrentCell.RowIndex].Value.ToString();
                var lista = tickesResumen.Where(x => x.NroTicket == numeroTicket).ToList();
                var FrmDetallesDocumentos = new FrmDetallesDocumentos(lista);
                FrmDetallesDocumentos.ShowDialog();
            }
            //Descargar
            else if (e.ColumnIndex == 4)
            {
                string archivoXml = string.Format(@"{0}\{1}", RutaXml, dgvResumenBoletas[5, dgvResumenBoletas.CurrentCell.RowIndex].Value.ToString());
                string archivoCdr = string.Format(@"{0}\{1}", RutaCdr, dgvResumenBoletas[6, dgvResumenBoletas.CurrentCell.RowIndex].Value.ToString());
                string nombreArchivo = dgvResumenBoletas[5, dgvResumenBoletas.CurrentCell.RowIndex].Value.ToString().Substring(0, dgvResumenBoletas[5, dgvResumenBoletas.CurrentCell.RowIndex].Value.ToString().Length - 4);
                using (var fbd = new FolderBrowserDialog())
                {
                    DialogResult result = fbd.ShowDialog();

                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    {
                        string directorio = string.Format(@"{0}\{1}", fbd.SelectedPath, nombreArchivo);

                        if (!Directory.Exists(directorio))
                            Directory.CreateDirectory(directorio);

                        string archivoXmlNew = string.Format(@"{0}\{1}.xml", directorio, nombreArchivo);
                        string archivoCdrNew = string.Format(@"{0}\{1}.zip", directorio, nombreArchivo);


                        if (File.Exists(archivoXml))
                            File.Copy(archivoXml, archivoXmlNew, true);

                        if (File.Exists(archivoCdr))
                            File.Copy(archivoCdr, archivoCdrNew, true);

                        MessageBox.Show(string.Format("Los archivos fueron descargados en: {0}", directorio), "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void btnListarBoletasBajas_Click(object sender, EventArgs e)
        {
            try
            {
                var fechaDe = dpDeBajasBoleta.Value.Date;
                var fechaHasta = dpHastaBajasBoleta.Value.Date;
                tickesResumenBajasBoletas = iTicketSunatServices.Listar("B", fechaDe, fechaHasta);

                var tickesResumenAgrupado = tickesResumenBajasBoletas.Select(x => new { x.NroTicket, x.Fecha, x.Estado, x.ArchivoXml, x.ArchivoCdr }).Distinct();

                dgvBoletaBajas.Rows.Clear();
                foreach (var item in tickesResumenAgrupado)
                {
                    dgvBoletaBajas.Rows.Add(item.NroTicket, item.Fecha, item.Estado, "Detalle", "Descargar", item.ArchivoXml, item.ArchivoCdr);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btnConsultarSunatBoletaBajas_Click(object sender, EventArgs e)
        {
            if (dgvBoletaBajas.CurrentCell == null) return;

            string metodoApi = "api/ConsultarTicket";
            string numeroTicket = dgvBoletaBajas[0, dgvBoletaBajas.CurrentCell.RowIndex].Value.ToString();

            var ConsultaTicketRequest = new ConsultaTicketRequest
            {
                UsuarioSol = UsuarioSol,
                ClaveSol = ClaveSol,
                EndPointUrl = UrlSunatEnvio,
                Ruc = emisor.Ruc,
                NroTicket = numeroTicket
            };

            HttpResponseMessage response;
            var proxy = new HttpClient { BaseAddress = new Uri(ConfigurationManager.AppSettings["UrlElectronicInvoiceApi"]) };
            List<dynamic> lista;
            response = await proxy.PostAsJsonAsync(metodoApi, ConsultaTicketRequest);
            var EnviarDocumentoResponse = await response.Content.ReadAsAsync<EnviarDocumentoResponse>();
            if (!EnviarDocumentoResponse.Exito)
            {
                MessageBox.Show(string.IsNullOrEmpty(EnviarDocumentoResponse.MensajeError) ? EnviarDocumentoResponse.MensajeRespuesta : EnviarDocumentoResponse.MensajeError, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                //Actualizamos ticket
                lista = tickesResumenBajasBoletas.Where(x => x.NroTicket == numeroTicket).ToList();
                foreach (var item in lista)
                {
                    item.ArchivoCdr = "";
                    item.Estado = string.IsNullOrEmpty(EnviarDocumentoResponse.MensajeError) ? EnviarDocumentoResponse.MensajeRespuesta : EnviarDocumentoResponse.MensajeError;
                    iTicketSunatServices.Update(item);
                }

                btnListarBoletasBajas.PerformClick();

                return;
            }

            MessageBox.Show(EnviarDocumentoResponse.MensajeRespuesta, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //Guardar el cdr
            File.WriteAllBytes(string.Format(@"{0}\{1}", RutaCdr, RecuperarNombreArchivo(EnviarDocumentoResponse.NombreArchivo)), Convert.FromBase64String(EnviarDocumentoResponse.TramaZipCdr));

            //Actualizamos ticket
            lista = tickesResumenBajasBoletas.Where(x => x.NroTicket == numeroTicket).ToList();
            foreach (var item in lista)
            {
                item.ArchivoCdr = RecuperarNombreArchivo(EnviarDocumentoResponse.NombreArchivo);
                item.Estado = EnviarDocumentoResponse.MensajeRespuesta;
                iTicketSunatServices.Update(item);
            }

            btnListarBoletasBajas.PerformClick();
        }
        private void dgvBoletaBajas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Detalles
            if (e.ColumnIndex == 3)
            {
                string numeroTicket = dgvBoletaBajas[0, dgvBoletaBajas.CurrentCell.RowIndex].Value.ToString();
                var lista = tickesResumenBajasBoletas.Where(x => x.NroTicket == numeroTicket).ToList();
                var FrmDetallesDocumentos = new FrmDetallesDocumentos(lista);
                FrmDetallesDocumentos.ShowDialog();
            }
            //Descargar
            else if (e.ColumnIndex == 4)
            {
                string archivoXml = string.Format(@"{0}\{1}", RutaXml, dgvBoletaBajas[5, dgvBoletaBajas.CurrentCell.RowIndex].Value.ToString());
                string archivoCdr = string.Format(@"{0}\{1}", RutaCdr, dgvBoletaBajas[6, dgvBoletaBajas.CurrentCell.RowIndex].Value.ToString());
                string nombreArchivo = dgvBoletaBajas[5, dgvBoletaBajas.CurrentCell.RowIndex].Value.ToString().Substring(0, dgvBoletaBajas[5, dgvBoletaBajas.CurrentCell.RowIndex].Value.ToString().Length - 4);
                using (var fbd = new FolderBrowserDialog())
                {
                    DialogResult result = fbd.ShowDialog();

                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    {
                        string directorio = string.Format(@"{0}\{1}", fbd.SelectedPath, nombreArchivo);

                        if (!Directory.Exists(directorio))
                            Directory.CreateDirectory(directorio);

                        string archivoXmlNew = string.Format(@"{0}\{1}.xml", directorio, nombreArchivo);
                        string archivoCdrNew = string.Format(@"{0}\{1}.zip", directorio, nombreArchivo);


                        if (File.Exists(archivoXml))
                            File.Copy(archivoXml, archivoXmlNew, true);

                        if (File.Exists(archivoCdr))
                            File.Copy(archivoCdr, archivoCdrNew, true);

                        MessageBox.Show(string.Format("Los archivos fueron descargados en: {0}", directorio), "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private async void btnConsultarFacturasBajas_Click(object sender, EventArgs e)
        {
            if (dgvFacturasBaja.CurrentCell == null) return;

            string metodoApi = "api/ConsultarTicket";
            string numeroTicket = dgvFacturasBaja[0, dgvFacturasBaja.CurrentCell.RowIndex].Value.ToString();

            var ConsultaTicketRequest = new ConsultaTicketRequest
            {
                UsuarioSol = UsuarioSol,
                ClaveSol = ClaveSol,
                EndPointUrl = UrlSunatEnvio,
                Ruc = emisor.Ruc,
                NroTicket = numeroTicket
            };

            HttpResponseMessage response;
            var proxy = new HttpClient { BaseAddress = new Uri(ConfigurationManager.AppSettings["UrlElectronicInvoiceApi"]) };
            List<dynamic> lista;
            response = await proxy.PostAsJsonAsync(metodoApi, ConsultaTicketRequest);
            var EnviarDocumentoResponse = await response.Content.ReadAsAsync<EnviarDocumentoResponse>();
            if (!EnviarDocumentoResponse.Exito)
            {
                MessageBox.Show(string.IsNullOrEmpty(EnviarDocumentoResponse.MensajeError) ? EnviarDocumentoResponse.MensajeRespuesta : EnviarDocumentoResponse.MensajeError, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                //Actualizamos ticket
                lista = tickesBajasFactura.Where(x => x.NroTicket == numeroTicket).ToList();
                foreach (var item in lista)
                {
                    item.ArchivoCdr = "";
                    item.Estado = string.IsNullOrEmpty(EnviarDocumentoResponse.MensajeError) ? EnviarDocumentoResponse.MensajeRespuesta : EnviarDocumentoResponse.MensajeError;
                    iTicketSunatServices.Update(item);
                }

                btnListarFacturasBajas.PerformClick();

                return;
            }

            MessageBox.Show(EnviarDocumentoResponse.MensajeRespuesta, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //Guardar el cdr
            File.WriteAllBytes(string.Format(@"{0}\{1}", RutaCdr, RecuperarNombreArchivo(EnviarDocumentoResponse.NombreArchivo)), Convert.FromBase64String(EnviarDocumentoResponse.TramaZipCdr));

            //Actualizamos ticket
            lista = tickesBajasFactura.Where(x => x.NroTicket == numeroTicket).ToList();
            foreach (var item in lista)
            {
                item.ArchivoCdr = RecuperarNombreArchivo(EnviarDocumentoResponse.NombreArchivo);
                item.Estado = EnviarDocumentoResponse.MensajeRespuesta;
                iTicketSunatServices.Update(item);
            }

            btnListarFacturasBajas.PerformClick();
        }

        private void btnSalir3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnListarFacturasBajas_Click(object sender, EventArgs e)
        {
            try
            {
                var fechaDe = dpDe3.Value.Date;
                var fechaHasta = dpHasta3.Value.Date;
                tickesBajasFactura = iTicketSunatServices.Listar("A", fechaDe, fechaHasta);

                var tickesResumenAgrupado = tickesBajasFactura.Select(x => new { x.NroTicket, x.Fecha, x.Estado, x.ArchivoXml, x.ArchivoCdr }).Distinct();

                dgvFacturasBaja.Rows.Clear();
                foreach (var item in tickesResumenAgrupado)
                {
                    dgvFacturasBaja.Rows.Add(item.NroTicket, item.Fecha, item.Estado, "Detalle", "Descargar", item.ArchivoXml, item.ArchivoCdr);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvFacturasBaja_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Detalles
            if (e.ColumnIndex == 3)
            {
                string numeroTicket = dgvFacturasBaja[0, dgvFacturasBaja.CurrentCell.RowIndex].Value.ToString();
                var lista = tickesBajasFactura.Where(x => x.NroTicket == numeroTicket).ToList();
                var FrmDetallesDocumentos = new FrmDetallesDocumentos(lista);
                FrmDetallesDocumentos.ShowDialog();
            }
            //Descargar
            else if (e.ColumnIndex == 4)
            {
                string archivoXml = string.Format(@"{0}\{1}", RutaXml, dgvFacturasBaja[5, dgvFacturasBaja.CurrentCell.RowIndex].Value.ToString());
                string archivoCdr = string.Format(@"{0}\{1}", RutaCdr, dgvFacturasBaja[6, dgvFacturasBaja.CurrentCell.RowIndex].Value.ToString());
                string nombreArchivo = dgvFacturasBaja[5, dgvFacturasBaja.CurrentCell.RowIndex].Value.ToString().Substring(0, dgvFacturasBaja[5, dgvFacturasBaja.CurrentCell.RowIndex].Value.ToString().Length - 4);
                using (var fbd = new FolderBrowserDialog())
                {
                    DialogResult result = fbd.ShowDialog();

                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    {
                        string directorio = string.Format(@"{0}\{1}", fbd.SelectedPath, nombreArchivo);

                        if (!Directory.Exists(directorio))
                            Directory.CreateDirectory(directorio);

                        string archivoXmlNew = string.Format(@"{0}\{1}.xml", directorio, nombreArchivo);
                        string archivoCdrNew = string.Format(@"{0}\{1}.zip", directorio, nombreArchivo);


                        if (File.Exists(archivoXml))
                            File.Copy(archivoXml, archivoXmlNew, true);

                        if (File.Exists(archivoCdr))
                            File.Copy(archivoCdr, archivoCdrNew, true);

                        MessageBox.Show(string.Format("Los archivos fueron descargados en: {0}", directorio), "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
        #endregion
    }
}
