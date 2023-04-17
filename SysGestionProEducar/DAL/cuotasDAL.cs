using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class cuotasDAL
    {
        SqlConnection conn;
        public cuotasDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable mostrarCuotasDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("", conn);
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
