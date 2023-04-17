using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TipoDocumentoDAL
    {
        private readonly SqlConnection conn;
        public TipoDocumentoDAL()
        {
            conn = new SqlConnection(conexion.con);
        }

        public DataTable ListarTipoDocumento()
        {
            const string function = "SELECT * FROM fn_ObtenerTioDocumento()";
            SqlCommand cmd = new SqlCommand(function, conn)
            {
                CommandType = CommandType.Text
            };

            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr, LoadOption.Upsert);
                dr.Close();
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

    }
}
