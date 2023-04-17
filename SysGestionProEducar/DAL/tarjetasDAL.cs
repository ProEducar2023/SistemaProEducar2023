using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class tarjetasDAL
    {
        SqlConnection conn;
        public tarjetasDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerTarjetasDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_TARJETAS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr, LoadOption.Upsert);
                dr.Close();
            }
            catch (Exception)
            {
                dt = null;
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }
    }
}
