using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class motivos_Otros_Dev_DsctosDAL
    {
        SqlConnection conn;
        public motivos_Otros_Dev_DsctosDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerMotivosOtrosDevDsctosDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_MOTIVOS_OTROS_DEV_DSCTOS", conn);
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
