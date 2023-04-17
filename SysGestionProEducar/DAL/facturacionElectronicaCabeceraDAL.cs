using Entidades;
using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Globalization;
using System.Text;
namespace DAL
{
    public class facturacionElectronicaCabeceraDAL
    {
        SqlConnection conn;
        StringBuilder sb = new StringBuilder();

        public facturacionElectronicaCabeceraDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerFacturaCabeceraDBF_DAL(facturacionElectronicaCabeceraTo faeTo, string ruta)
        {
            var culture = new CultureInfo("en-us");//para dar formato a la fecha
            sb.Append("provider=Microsoft.Jet.OLEDB.4.0;");
            sb.AppendFormat("data source={0};", ruta);
            sb.Append("extended properties=dbase III");

            DataTable dt = new DataTable();
            try
            {
                using (OleDbConnection cnn = new OleDbConnection(sb.ToString()))
                {
                    string sql = obtieneCabeceraContratoSQL(faeTo);

                    OleDbCommand cmd = new OleDbCommand();
                    cmd.CommandType = CommandType.Text;
                    var da = new OleDbDataAdapter(sql.ToString(), cnn);
                    da.Fill(dt);
                }
            }
            catch (Exception)
            {
                dt = null;
            }

            return dt;
        }
        public string obtieneCabeceraContratoSQL(facturacionElectronicaCabeceraTo faeTo)
        {
            var culture = new CultureInfo("en-us");//para dar formato a la fecha
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT ");
            sql.Append("A.NUDOC, ");
            sql.Append("A.CDCTE, ");
            sql.Append("A.CDVEN, ");
            sql.Append("A.CDT_V, ");
            sql.Append("A.STORI, ");
            sql.Append("A.DSC_E, ");
            sql.Append("A.CDMON, ");
            sql.Append("A.FOPAG, ");
            sql.Append("A.NUDIA, ");
            sql.Append("A.FECTE, ");
            sql.Append("A.TOCTE, ");
            sql.Append("A.DSOBS ");
            sql.Append("FROM IINV1r A ");
            //sql.Append("WHERE (A.FEDOC >= #" + faeTo.FE_INI.ToString("d", culture) + "# AND A.FEDOC <=#" + faeTo.FE_FIN.ToString("d", culture) + "#) ");
            sql.Append("WHERE A.CDCTE = '" + faeTo.CDCTE + "'");
            return sql.ToString();
        }
        public DataTable obtenerFacturaDetalleDBF_DAL(facturacionElectronicaCabeceraTo faeTo, string ruta)
        {
            var culture = new CultureInfo("en-us");//para dar formato a la fecha
            sb.Append("provider=Microsoft.Jet.OLEDB.4.0;");
            sb.AppendFormat("data source={0};", ruta);
            sb.Append("extended properties=dbase III");

            DataTable dt = new DataTable();
            try
            {
                using (OleDbConnection cnn = new OleDbConnection(sb.ToString()))
                {
                    string sql = obtieneDetalleContratoSQL(faeTo);

                    OleDbCommand cmd = new OleDbCommand();
                    cmd.CommandType = CommandType.Text;
                    var da = new OleDbDataAdapter(sql.ToString(), cnn);
                    da.Fill(dt);
                }
            }
            catch (Exception)
            {
                dt = null;
            }

            return dt;
        }
        public string obtieneDetalleContratoSQL(facturacionElectronicaCabeceraTo faeTo)
        {
            var culture = new CultureInfo("en-us");//para dar formato a la fecha
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT ");
            sql.Append("A.NUDOC, ");
            sql.Append("A.NUIT1, ");
            sql.Append("A.FEDOC, ");
            sql.Append("A.CDART, ");
            sql.Append("A.DSART, ");
            sql.Append("A.CADOC, ");
            sql.Append("A.PRVAC, ");
            sql.Append("A.PODES, ");
            sql.Append("A.POIGV, ");
            sql.Append("A.VANET, ");
            sql.Append("A.VADES, ");
            sql.Append("A.VAIGV, ");
            sql.Append("A.CDCTE, ");
            sql.Append("A.FECTE, ");
            sql.Append("A.CDD_H, ");
            sql.Append("A.DSOBS ");
            sql.Append("FROM TINV1R A ");
            //sql.Append("WHERE (A.FEDOC >= #" + faeTo.FE_INI.ToString("d", culture) + "# AND A.FEDOC <=#" + faeTo.FE_FIN.ToString("d", culture) + "#) ");
            sql.Append("WHERE A.CDCTE = '" + faeTo.CDCTE + "'");
            return sql.ToString();
        }
    }
}
