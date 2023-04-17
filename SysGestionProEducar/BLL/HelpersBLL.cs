using DAL;
using Entidades;
using System;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
namespace BLL
{
    public class HelpersBLL
    {
        HelpersDAL helDAL = new HelpersDAL();

        public DataTable obtenerTipo_Doc_PersonalBLL()
        {
            return helDAL.obtenerTipo_Doc_PersonalDAL();
        }
        public DataTable obtenerTipo_PersonaBLL()
        {
            return helDAL.obtenerTipo_PersonaDAL();
        }
        public DataTable obtenerTipo_FonoBLL()
        {
            return helDAL.obtenerTipo_FonoDAL();
        }
        public DataTable obtenerPaisBLL()
        {
            return helDAL.obtenerPaisDAL();
        }
        public DataTable obtenerDepartamentoBLL()
        {
            return helDAL.obtenerDepartamentoDAL();
        }
        public DataTable obtenerPro_PaisBLL(HelpersTo helTo)
        {
            return helDAL.obtenerPro_PaisDAL(helTo);
        }
        public DataTable obtenerDist_Pro_PaisBLL(HelpersTo helTo)
        {
            return helDAL.obtenerDist_Pro_PaisDAL(helTo);
        }
        public DataTable obtenerTIpo_DirBLL()
        {
            return helDAL.obtenerTIpo_DirDAL();
        }
        public DataTable obtenerClaseBLL()
        {
            return helDAL.obtenerClaseDAL();
        }
        public DataTable obtenerCategoriaBLL()
        {
            return helDAL.obtenerCategoriaDAL();
        }
        public DataTable obtenerFormaPagoBLL()
        {
            return helDAL.obtenerFormaPagoDAL();
        }
        public DataTable obtenerCondicionVentaBLL()
        {
            return helDAL.obtenerCondicionVentaDAL();
        }
        public DataTable obtenerFormaPago_PER_CL_CAT_BLL(HelpersTo helTo)
        {
            return helDAL.obtenerFormaPago_PER_CL_CAT_DAL(helTo);
        }
        public DataTable CBO_CLASE_USU_TIPO_BLL(HelpersTo helTo)
        {
            return helDAL.CBO_CLASE_USU_TIPO_DAL(helTo);
        }
        public DataTable CBO_SUCURSALBLL(HelpersTo helTo)
        {
            return helDAL.CBO_SUCURSALDAL(helTo);
        }
        public DataTable MOSTRAR_PERSONAS_XCOBRAR_BLL(HelpersTo helTo)
        {
            return helDAL.MOSTRAR_PERSONAS_XCOBRAR_DAL(helTo);
        }
        public DataTable MOSTRAR_PERSONAS_XPAGAR_BLL()
        {
            return helDAL.MOSTRAR_PERSONAS_XPAGAR_DAL();
        }
        public DataTable MOSTRAR_PERSONAS_XPAGAR_PERSONAL_BLL()
        {
            return helDAL.MOSTRAR_PERSONAS_XPAGAR_PERSONAL_DAL();
        }
        ///
        public static Boolean IsNumeric(string valor)
        {
            decimal result;
            return decimal.TryParse(valor, out result);
        }
        //////
        public static object PRECIO_UNITARIO(object CADENA)
        {
            //return Format(CDec(CADENA), "###,###,###,##0.000")
            return string.Format("###,###,###,##0.000", Convert.ToDecimal(CADENA));
        }
        public static string OBTIENE_PRECIO_TRES_DECIMALES(string text)
        {
            decimal n1 = -1; string num = ""; double n;
            if (decimal.TryParse(text, out n1))
            {
                n = Convert.ToDouble(text);
                num = n.ToString("###,###,##0.000");
            }
            else
            {
                num = "0.000";
            }
            return num;
        }
        public static string OBTIENE_PRECIO_DOS_DECIMALES(string text)
        {
            decimal n1 = -1; string num = ""; double n;
            if (decimal.TryParse(text, out n1))
            {
                n = Convert.ToDouble(text);
                num = n.ToString("###,###,##0.00");
            }
            else
            {
                num = "0.00";
            }
            return num;
        }
        public static string OBTIENE_PRECIO_CUATRO_DECIMALES(string text)
        {
            decimal n1 = -1; string num = ""; double n;
            if (decimal.TryParse(text, out n1))
            {
                n = Convert.ToDouble(text);
                num = n.ToString("###,###,##0.0000");
            }
            else
            {
                num = "";
            }
            return num;
        }
        public static string OBTIENE_CODIGO(int i, string num)
        {
            int n1 = -1; string valor = "";
            if (int.TryParse(num, out n1))
            {
                string ite = (num).ToString();
                valor = ite.PadLeft(i, '0');
            }
            else
            {
                valor = "";
            }
            return valor;
        }
        public DataTable obtenerMonedaBLL()
        {
            return helDAL.obtenerMonedaDAL();
        }
        public string obtenerTipoCambioBLL(string annio, string mes, string dia, string cod_mon)
        {
            return helDAL.obtenerTipoCambioDAL(annio, mes, dia, cod_mon);
        }
        public decimal obtenerImpuestoBLL(string CODIGO)
        {
            return helDAL.obtenerImpuestoDAL(CODIGO);
        }
        public bool insertarBulkCopyBLL(DataTable dt, ref string errMensaje)
        {
            bool result = true;
            if (!helDAL.insertarBulkCopyDAL(dt, ref errMensaje))
                return result = false;
            return result;
        }
        public static string ENCRIPTAR(string valor)
        {
            UTF8Encoding encod = new UTF8Encoding();
            Byte[] buffer = encod.GetBytes(valor);
            Byte[] result;
            SHA1CryptoServiceProvider sha = new SHA1CryptoServiceProvider();
            //        'Implementación de la clase Abstracta SHA1.
            result = sha.ComputeHash(buffer);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i <= result.Length - 1; i++)
            {
                if (result[i] < 16)
                    sb.Append("0");
                else
                    sb.Append(result[i].ToString("x"));
            }
            return sb.ToString().ToUpper();
        }

        public static string Encriptar(string value)
        {
            //Crear clave SHA1
            UTF8Encoding encod = new UTF8Encoding();
            byte[] buffer = encod.GetBytes(value);
            byte[] result;
            using (SHA1CryptoServiceProvider sha = new SHA1CryptoServiceProvider())
            {
                //Implementación de la clase Abstracta SHA1.
                result = sha.ComputeHash(buffer);

                /* Convertir los valores en hexadecimal, Si tiene una cifra se
                 * rellena con cero para para que ocupe dos dígitos */
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i <= result.Length - 1; i++)
                {
                    if (result[i] < 16)
                    {
                        sb.Append("0");
                    }
                    sb.Append(result[i].ToString("x"));
                }
                return sb.ToString().ToUpper();
            }
        }

        public string NRO_DIAS_CONDICION_VENTABLL(string cod_ven)
        {
            return helDAL.NRO_DIAS_CONDICION_VENTADAL(cod_ven);
        }
        public DataTable obtenerDesc_Doc_GestionBLL()
        {
            return helDAL.obtenerDesc_Doc_GestionDAL();
        }
        public string SACAR_CAMBIO(string annio, string mes, string dia, string tipo)
        {
            return helDAL.SACAR_CAMBIO(annio, mes, dia, tipo);
        }
        public static string VALIDAR_FECHA(DateTime fec, DateTime FECHA_GRAL, DateTime FECHA_INI, ref string mss)
        {
            if (fec.Date > FECHA_GRAL.Date)
            {
                mss = "La fecha elegida es mayor a la fecha de proceso";
                return "0";
            }
            else if (fec.Date < FECHA_INI.Date)
            {
                mss = "La fecha elegida es menor a la fecha de proceso";
                return "0";
            }
            else
            {
                mss = "";
                return "1";
            }

        }
        public bool ELIMINAR_TEMPORAL(string tipo, string nombre_pc, ref string errMensaje)
        {
            bool result = true;
            if (!helDAL.ELIMINAR_TEMPORAL(tipo, nombre_pc, ref errMensaje))
                return result = false;
            return result;
        }
        public string ValidarUsuarioEliminacionAnulacionBLL(string claveEncriptada, string usuarioNick)
        {
            return helDAL.ValidarUsuarioEliminacionAnulacionDAL(claveEncriptada, usuarioNick);
        }
        public int ValidarDirectorioDesaprobarBLL(string codigo, string MODULO)
        {
            return helDAL.ValidarDirectorioDesaprobarDAL(codigo, MODULO);
        }
        public DataTable CARGAR_LABEL()
        {
            return helDAL.CARGAR_LABEL();
        }
        public DataTable CBO_CLASE_USU_TIPO(bool validarTipo, string TIPO_USU, string COD_USU, string tipo)
        {
            return helDAL.CBO_CLASE_USU_TIPO(validarTipo, TIPO_USU, COD_USU, tipo);
        }
        public string COD_D_H(string COD_DOC)
        {
            return helDAL.COD_D_H(COD_DOC);
        }
        public static DataTable obtenerDT(DataGridView DGW_DET)
        {
            DataTable table = new DataTable();
            foreach (DataGridViewColumn column in DGW_DET.Columns)
            {
                table.Columns.Add(column.Name, typeof(string));
            }
            foreach (DataGridViewRow row in DGW_DET.Rows)
            {
                DataRow dataRow = table.NewRow();
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    dataRow[i] = row.Cells[i].Value != null ? row.Cells[i].Value : DBNull.Value;
                }
                table.Rows.Add(dataRow);
            }
            return table;
        }
        public static DataTable obtenerDTX(DataGridView DGW_DET)//obtiene DT con filas de la ultima columna checkbox esten chequeadas
        {
            DataTable table = new DataTable();
            foreach (DataGridViewColumn column in DGW_DET.Columns)
            {
                table.Columns.Add(column.Name, typeof(string));
            }
            foreach (DataGridViewRow row in DGW_DET.Rows)
            {
                if (Convert.ToBoolean(row.Cells[table.Columns.Count - 1].Value))
                {
                    DataRow dataRow = table.NewRow();
                    for (int i = 0; i < table.Columns.Count; i++)
                    {
                        dataRow[i] = row.Cells[i].Value != null ? row.Cells[i].Value : DBNull.Value;
                    }
                    table.Rows.Add(dataRow);
                }
            }
            return table;
        }
        public static DataTable obtenerDTXY(DataGridView DGW_DET, int j)//obtiene DT con filas de la ultima columna checkbox esten chequeadas
        {
            DataTable table = new DataTable();
            foreach (DataGridViewColumn column in DGW_DET.Columns)
            {
                table.Columns.Add(column.Name, typeof(string));
            }
            foreach (DataGridViewRow row in DGW_DET.Rows)
            {
                if (Convert.ToBoolean(row.Cells[table.Columns.Count - j].Value))
                {
                    DataRow dataRow = table.NewRow();
                    for (int i = 0; i < table.Columns.Count; i++)
                    {
                        dataRow[i] = row.Cells[i].Value != null ? row.Cells[i].Value : DBNull.Value;
                    }
                    table.Rows.Add(dataRow);
                }
            }
            return table;
        }
        public static DataTable obtenerEstructuraGrid(DataGridView DGW_DET)//obtiene DT con filas de la ultima columna checkbox esten chequeadas
        {
            DataTable table = new DataTable();
            foreach (DataGridViewColumn column in DGW_DET.Columns)
            {
                table.Columns.Add(column.Name, typeof(string));
            }

            return table;
        }
        public static string OBTENER_NOM_MES(string m)
        {
            string mes = "";
            switch (m)
            {
                case "01": mes = "ENERO"; break;
                case "02": mes = "FEBRERO"; break;
                case "03": mes = "MARZO"; break;
                case "04": mes = "ABRIL"; break;
                case "05": mes = "MAYO"; break;
                case "06": mes = "JUNIO"; break;
                case "07": mes = "JULIO"; break;
                case "08": mes = "AGOSTO"; break;
                case "09": mes = "SEPTIEMBRE"; break;
                case "10": mes = "OCTUBRE"; break;
                case "11": mes = "NOVIEMBRE"; break;
                case "12": mes = "DICIEMBRE"; break;
            }
            return mes;
        }
        public static string OBTENER_DES_DIRECTORIO(string CODIGO, string TABLA_COD)
        {
            directorioBLL dirBLL = new directorioBLL();
            directorioTo dirTo = new directorioTo();
            dirTo.TABLA_COD = TABLA_COD;
            dirTo.CODIGO = CODIGO;
            string descripcion = dirBLL.DIR_TABLA_DESC(dirTo);
            return descripcion;
        }

        public static string HALLAR_TIPO_OP_MOV(string COD_MOV)
        {
            movimientosBLL movBLL = new movimientosBLL();
            movimientosTo movTo = new movimientosTo();
            movTo.COD_MOV = COD_MOV;
            string tipo_operacion = movBLL.obtenerTipoOperacionBLL(movTo);
            return tipo_operacion;
        }
        public static DataTable OBTENER_UNA_COLUMNA()//un vector de una sola columna
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("uno");
            return dt;
        }
        public static DateTime OBTENER_FECHA_INI_DE_NOMBRE_MES_AÑO(string mes, string año)
        {
            string fecha_ini;
            fecha_ini = "01/" + mes + "/" + año;
            return Convert.ToDateTime(fecha_ini);
        }
        public static DateTime OBTENER_FECHA_FIN_DE_NOMBRE_MES_AÑO(string mes, string año)
        {
            DateTime fecha_fin;
            fecha_fin = OBTENER_FECHA_INI_DE_NOMBRE_MES_AÑO(mes, año);
            return fecha_fin.AddMonths(1);
        }
        public static DataTable OBTENER_MESES()
        {
            DataTable dtmes = new DataTable();
            dtmes.Columns.Add("cod", typeof(string));
            dtmes.Columns.Add("nom", typeof(string));

            for (int i = 1; i <= 12; i++)
            {
                DataRow rw = dtmes.NewRow();
                rw["cod"] = i.ToString().PadLeft(2, '0');
                rw["nom"] = obtMes(i);
                dtmes.Rows.Add(rw);
            }
            return dtmes;
        }
        private static string obtMes(int m)
        {
            string mes = "";
            switch (m)
            {
                case 1: mes = "ENERO"; break;
                case 2: mes = "FEBRERO"; break;
                case 3: mes = "MARZO"; break;
                case 4: mes = "ABRIL"; break;
                case 5: mes = "MAYO"; break;
                case 6: mes = "JUNIO"; break;
                case 7: mes = "JULIO"; break;
                case 8: mes = "AGOSTO"; break;
                case 9: mes = "SEPTIEMBRE"; break;
                case 10: mes = "OCTUBRE"; break;
                case 11: mes = "NOVIEMBRE"; break;
                case 12: mes = "DICIEMBRE"; break;
            }
            return mes;
        }
        public static DataTable OBTENER_AÑOS()
        {
            int anio = DateTime.Now.Year;
            DataTable dtannio = new DataTable();
            dtannio.Columns.Add("cod", typeof(int));
            dtannio.Columns.Add("nom", typeof(string));

            for (int i = anio; i >= anio - 3; i--)
            {
                DataRow rw = dtannio.NewRow();
                rw["cod"] = i;
                rw["nom"] = i;
                dtannio.Rows.Add(rw);
            }
            return dtannio;
        }

        public DataTable MOSTRAR_PERSONAS_X_DEVOLUCION_BLL()
        {
            return helDAL.MOSTRAR_PERSONAS_X_DEVOLUCION_DAL();
        }
        public DataTable MOSTRAR_PERSONAS_X_DEVOLUCION_TODOS_BLL()
        {
            return helDAL.MOSTRAR_PERSONAS_X_DEVOLUCION_TODOS_DAL();
        }
        public DataTable MOSTRAR_PERSONAS_X_DSCTO_DIRECTA_BLL()
        {
            return helDAL.MOSTRAR_PERSONAS_X_DSCTO_DIRECTA_DAL();
        }
        public DataTable MOSTRAR_PERSONAS_PARA_CAMBIO_PTO_COB_BLL()
        {
            return helDAL.MOSTRAR_PERSONAS_PARA_CAMBIO_PTO_COB_DAL();
        }
        public DataTable MOSTRAR_PERSONAS_X_AUMENTAR_CUOTA_BLL(HelpersTo helTo)
        {
            return helDAL.MOSTRAR_PERSONAS_X_AUMENTAR_CUOTA_DAL(helTo);
        }
        public static bool estableceNuevoNumeroContador(string cod_sucursal, string cod_doc, string status_doc, string serie, ref string errMensaje)
        {
            bool result = true;
            serieDocumentoBLL sdBLL = new serieDocumentoBLL();
            serieDocumentosTo sdTo = new serieDocumentosTo();
            sdTo.COD_SUCURSAL = cod_sucursal;
            sdTo.COD_DOC = cod_doc;
            sdTo.STATUS_DOC = status_doc;
            sdTo.SERIE = serie;
            if (!sdBLL.adicionaNroSerieBLL(sdTo, ref errMensaje))
                return result = false;
            return result;
        }
        public static DataTable obtieneNroPlanilla(string cod_sucursal, string status_doc, string cod_doc)
        {
            DataTable dt;
            serieDocumentoBLL sdoBLL = new serieDocumentoBLL();
            serieDocumentosTo sdoTo = new serieDocumentosTo();
            sdoTo.COD_SUCURSAL = cod_sucursal;
            sdoTo.STATUS_DOC = status_doc;
            sdoTo.COD_DOC = cod_doc;//OTRAS DEVOLUC ó DESCTOS
            return dt = sdoBLL.OBTENER_SERIE_NRO_BLL(sdoTo);
            //txt_ser.Text = sdoBLL.OBTENER_SERIE_NRO_BLL(sdoTo).Rows[0]["SERIE"].ToString();
            //txt_num.Text = sdoBLL.OBTENER_SERIE_NRO_BLL(sdoTo).Rows[0]["NUMERO"].ToString();
        }
        public DataTable MOSTRAR_PERSONAS_X_CONSULTA_KARDEX_BLL()
        {
            return helDAL.MOSTRAR_PERSONAS_X_CONSULTA_KARDEX_DAL();
        }
        public static DateTime FECHA_INI_DESCRIPCION_BLL(string mes, string annio)
        {
            DateTime fe_ini;
            fe_ini = Convert.ToDateTime("01/" + mes + "/" + annio);
            return fe_ini;
        }
        public static DateTime FECHA_FIN_DESCRIPCION_BLL(string mes, string annio)
        {
            DateTime fe_fin;
            string mes_fin = ""; string annio_fin = "";
            if (mes != "12")
            {
                mes_fin = (Convert.ToInt32(mes) + 1).ToString();
                annio_fin = annio;
            }
            else
            {
                mes_fin = "01";
                annio_fin = (Convert.ToInt32(annio) + 1).ToString();
            }
            fe_fin = Convert.ToDateTime("01/" + mes_fin + "/" + annio_fin).AddDays(-1);
            return fe_fin;
        }
        public static string OBTENER_PERIODOS_BLL(string fecha_ini_sus, string fecha_fin_sus)
        {
            string periodos = "";
            periodos = HelpersBLL.OBTENER_NOM_MES(fecha_ini_sus.Substring(3, 2)) + " " + fecha_ini_sus.Substring(6, 4) + "  a  " + HelpersBLL.OBTENER_NOM_MES(fecha_fin_sus.Substring(3, 2)) + " " + fecha_fin_sus.Substring(6, 4);
            return periodos;
        }
        public static bool esNumeroDecimal(string valor, bool incluyeCero)
        {
            bool result = false;
            decimal val = 0;
            if (decimal.TryParse(valor, out val))
            {
                if (incluyeCero)
                {
                    if (Convert.ToDecimal(valor) >= 0)
                        return result = true;
                }
                else
                {
                    if (Convert.ToDecimal(valor) > 0)
                        return result = true;
                }
            }
            return result;
        }
        public static bool esFecha(string valor)
        {
            bool result = false;
            DateTime val = DateTime.Now;
            if (DateTime.TryParse(valor, out val))
            {
                return result = true;
            }
            return result;
        }
        public static DateTime validaFecha(string MES, string AÑO, DateTime FECHA_GRAL)
        {
            try
            {
                DateTime.Parse(Convert.ToDateTime(DateTime.Now.Day + "/" + MES + "/" + AÑO).ToShortDateString());
                return Convert.ToDateTime(DateTime.Now.Day + "/" + MES + "/" + AÑO);
            }
            catch
            {
                return FECHA_GRAL;
            }
        }
    }
}