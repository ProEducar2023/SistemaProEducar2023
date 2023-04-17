using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Presentacion.CONSULTAS
{
    public partial class frmConsultaRuc : Form
    {
        private CookieContainer objCookie;
        private delegate void ConsultarRuc(string numeroRuc, string codigoCaptcha);
        string ruc = string.Empty;
        string nombre = string.Empty;
        string nombreComercial = string.Empty;
        string direccion = string.Empty;
        string tipo = string.Empty;
        string estado = string.Empty;
        string situacion = string.Empty;
        string agenteRetencion = string.Empty;
        #region CONSTRUCTORES
        public frmConsultaRuc()
        {
            InitializeComponent();
        }
        private static frmConsultaRuc _instancia;
        public static frmConsultaRuc ObtenerInstancia()
        {
            if (_instancia == null || _instancia.IsDisposed)
            {
                _instancia = new frmConsultaRuc();
            }
            _instancia.BringToFront();
            return _instancia;
        }
        #endregion
        private void frmConsultaRuc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        private Image LeerCaptcha()
        {
            Image captcha = null;
            try
            {

                System.Net.ServicePointManager.ServerCertificateValidationCallback +=
                delegate (object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate,
                                        System.Security.Cryptography.X509Certificates.X509Chain chain,
                                        System.Net.Security.SslPolicyErrors sslPolicyErrors)
                {
                    return true; // **** Always accept
                };
                HttpWebRequest myWebRequest = (HttpWebRequest)(WebRequest.Create("http://www.sunat.gob.pe/cl-ti-itmrconsruc/captcha?accion=image&magic=2"));
                myWebRequest.CookieContainer = objCookie;
                myWebRequest.Proxy = null;
                myWebRequest.Credentials = CredentialCache.DefaultCredentials;
                HttpWebResponse myWebResponse = (HttpWebResponse)(myWebRequest.GetResponse());
                System.IO.Stream myImgStream = myWebResponse.GetResponseStream();
                captcha = Image.FromStream(myImgStream);
            }
            catch (Exception)
            {
            }
            return captcha;
        }
        private bool ValidarCertificado(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate,
        System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
        //private bool CheckForInternetConnection()
        //{
        //    bool IsConnected = false;
        //    try
        //    {
        //        using (WebClient client = null)
        //        {
        //            using (System.IO.Stream stream = client.OpenRead("http://www.google.com"))
        //            {
        //                IsConnected = true;
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        IsConnected = false;   
        //    }
        //    return IsConnected;
        //}
        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (CheckForInternetConnection())
            {
                if (txtRuc.Text.Length == 11)
                {
                    ConsultarRuc oConsulta = new ConsultarRuc(BuscaRuc);
                    oConsulta.BeginInvoke(txtRuc.Text, txtCodigoCaptcha.Text, FinConsulta, null);
                    tsslMensaje.Text = "Consultando datos ...";
                    btnConsultar.Enabled = false;
                    btnTrasladar.Focus();
                }
            }
            else
            {
                MessageBox.Show("Verifique la conexión a internet", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btnCancelar.Focus();
            }
        }
        private void FinConsulta(IAsyncResult iar)
        {
            if (iar.IsCompleted)
            {
                MethodInvoker mi = new MethodInvoker(MostrarDatos);
                this.Invoke(mi);
            }
        }
        private void MostrarDatos()
        {
            if (!string.IsNullOrEmpty(nombre))
            {
                txtNombre.Text = nombre.Trim();
                txtNombreComercial.Text = nombreComercial.Trim();
                txtDireccion.Text = direccion.Trim();
                txtTipo.Text = tipo.Trim();
                txtEstado.Text = estado.Trim();
                txtSituacion.Text = situacion.Trim();
            }
            else
            {
                MessageBox.Show("La consulta no devolvío ningún resultado", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            btnConsultar.Enabled = true;
            tsslMensaje.Text = string.Empty;
        }
        private void BuscaRuc(string numeroRuc, string codigoCaptcha)
        {
            ruc = string.Empty;
            nombre = string.Empty;
            nombreComercial = string.Empty;
            direccion = string.Empty;
            tipo = string.Empty;
            estado = string.Empty;
            situacion = string.Empty;
            try
            {
                string myUrl = string.Format("http://www.sunat.gob.pe/cl-ti-itmrconsruc/jcrS00Alias?accion=consPorRuc&nroRuc={0}&codigo={1}", numeroRuc, codigoCaptcha);
                HttpWebRequest myWebRequest = (HttpWebRequest)WebRequest.Create(myUrl);
                myWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:23.0) Gecko/20100101 Firefox/23.0";
                myWebRequest.CookieContainer = objCookie;
                myWebRequest.Credentials = CredentialCache.DefaultCredentials;
                myWebRequest.Proxy = null;
                HttpWebResponse myHttpWebResponse = (HttpWebResponse)myWebRequest.GetResponse();
                Stream myStream = myHttpWebResponse.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(myStream);
                //'Leemos los datos
                string xDat = WebUtility.HtmlDecode(myStreamReader.ReadToEnd());
                if (xDat.Length < 635)
                    return;

                string[] tabla;
                xDat = xDat.Replace("     ", " ");
                xDat = xDat.Replace("    ", " ");
                xDat = xDat.Replace("   ", " ");
                xDat = xDat.Replace("  ", " ");
                xDat = xDat.Replace("( ", "(");
                xDat = xDat.Replace(" )", ")");
                //'Lo convertimos a tabla o mejor dicho a un arreglo de string como se ve declarado arriba
                tabla = Regex.Split(xDat, "<td class");
                StringBuilder builder = new StringBuilder();
                for (int index = 1; index < tabla.Length - 1; index++)
                {
                    builder.Append(tabla[index]);
                }

                string texto = builder.ToString();
                texto = texto.Replace(Environment.NewLine, "");
                string principio; string final; int posicion1; int posicion2;
                //'======================= Buscar Nombre =======================
                principio = numeroRuc;
                final = "</td>";
                posicion1 = texto.IndexOf(principio);//InStr(texto, principio);
                posicion2 = texto.IndexOf(final, posicion1);//InStr(posicion1, texto, final);
                posicion1 += 14;
                //nombre = Mid(texto, posicion1, posicion2 - posicion1);
                nombre = texto.Substring(posicion1, posicion2 - posicion1);
                //'======================= Buscar Nombre Comercial =======================
                principio = @"Nombre Comercial: </td> =""bg"" colspan=1>";
                final = "</td>";
                posicion1 = texto.IndexOf(principio); //InStr(texto, principio)
                posicion2 = texto.IndexOf(final, posicion1 + 41); //InStr(posicion1 + 41, texto, final)
                posicion1 += 40;
                //nombreComercial = Mid(texto, posicion1, (posicion2 - posicion1))
                nombreComercial = texto.Substring(posicion1, posicion2 - posicion1);
                //'======================= Buscar Dirección =======================
                principio = @"Domicilio Fiscal:</td> =""bg"" colspan=3>";
                final = "</td>";
                posicion1 = texto.IndexOf(principio); //InStr(texto, principio)
                posicion2 = texto.IndexOf(final, posicion1 + 40); //InStr(posicion1 + 40, texto, final)
                posicion1 += 39;
                //direccion = Mid(texto, posicion1, (posicion2 - posicion1))
                direccion = texto.Substring(posicion1, posicion2 - posicion1);
                //'======================= Buscar Tipo =======================
                principio = @"Tipo Contribuyente: </td> =""bg"" colspan=3>";
                final = "</td>";
                posicion1 = texto.IndexOf(principio); //InStr(texto, principio)
                posicion2 = texto.IndexOf(final, posicion1 + 43); //InStr(posicion1 + 43, texto, final)
                posicion1 += 42;
                //tipo = Mid(texto, posicion1, (posicion2 - posicion1))
                tipo = texto.Substring(posicion1, posicion2 - posicion1);
                //'======================= Buscar Estado =======================
                principio = @"Estado del Contribuyente: </td> =""bg"" colspan=1>";
                final = "</td>";
                posicion1 = texto.IndexOf(principio);//InStr(texto, principio)
                posicion2 = texto.IndexOf(final, posicion1 + 49); //InStr(posicion1 + 49, texto, final)
                posicion1 += 48;
                //estado = Mid(texto, posicion1, (posicion2 - posicion1))
                estado = texto.Substring(posicion1, posicion2 - posicion1);

                //'======================= Buscar Situación =======================
                if (!(estado.Contains("SUSPENSION")))
                {
                    principio = @"Condición del Contribuyente:</td> =""bg"" colspan=3>";
                    final = "</td>";
                    posicion1 = texto.IndexOf(principio); //InStr(texto, principio)
                    posicion2 = texto.IndexOf(final, posicion1 + 51); //InStr(posicion1 + 51, texto, final)
                    posicion1 += 50;
                    //situacion = Mid(texto, posicion1, (posicion2 - posicion1))
                    situacion = texto.Substring(posicion1, posicion2 - posicion1);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No se encontrò !!!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //throw;
            }
        }
        private bool CheckForInternetConnection()
        {
            bool IsConnected = false;
            try
            {
                using (WebClient client = new WebClient())
                {
                    using (Stream stream = client.OpenRead("http://www.google.com"))
                    {
                        IsConnected = true;
                    }
                }
            }
            catch (Exception)
            {
                IsConnected = false;
            }
            return IsConnected;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnTrasladar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Hide();
        }
        public void Cargar_Datos(string setRuc, string setEstado = "NUEVO", string actividad = "consulta")
        {
            btnTrasladar.Enabled = actividad == "mantenimiento" ? true : false;
            //btnTrasladar.Enabled = (setEstado == "MODIFICAR" || setEstado == "DETALLES2") ? true : false;
            if (setEstado == "MODIFICAR" || setEstado == "DETALLES2") btnTrasladar.Enabled = true;
            ruc = setRuc;
            estado = setEstado;
            txtRuc.Text = setRuc;
            btnConsultar.Focus();
        }

        private void frmConsultaRuc_Load(object sender, EventArgs e)
        {
            objCookie = null;
            objCookie = new CookieContainer();
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
            this.pbCaptcha.Image = LeerCaptcha();
        }


    }
}
