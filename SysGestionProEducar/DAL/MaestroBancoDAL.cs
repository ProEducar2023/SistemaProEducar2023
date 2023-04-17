using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MaestroBancoDAL
    {
        private SqlConnection conn;

        public MaestroBancoDAL()
        {
            conn = new SqlConnection(conexion.con);
        }

        public DataTable ListarMaestroBanco()
        {
            const string function = "SELECT * FROM fn_ListarBanco()";
            SqlCommand cmd = new SqlCommand(function, conn)
            {
                CommandType = CommandType.Text
            };

            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr, LoadOption.OverwriteChanges);
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

        public DataTable ObtenerMaestroBancoXCodBanco(string codBanco)
        {
            const string function = "SELECT * FROM fn_ListarBanco() WHERE Codigo = @CODIGO";
            SqlCommand cmd = new SqlCommand(function, conn)
            {
                CommandType = CommandType.Text
            };

            _ = cmd.Parameters.AddWithValue("@CODIGO", codBanco);

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
