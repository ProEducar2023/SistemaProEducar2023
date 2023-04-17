using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class zonasEmpresaDAL
    {
        SqlConnection conn;
        public zonasEmpresaDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerZonasEmpresaDAL(zonasEmpresaTo zonTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_ZONAS_EMPRESA_X_COD_INSTITUCION", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_INSTITUCION", zonTo.COD_INSTITUCION);
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
