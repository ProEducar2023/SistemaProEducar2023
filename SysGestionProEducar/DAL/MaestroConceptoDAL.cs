using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class MaestroConceptoDAL
    {
        private readonly SqlConnection conn;
        public MaestroConceptoDAL()
        {
            conn = new SqlConnection(conexion.con);
        }

        public DataTable ListarSegundoNivel()
        {
            const string sentencia = "SELECT * FROM VMaestroConcepto WHERE LEN(CODIGO) = 5";
            try
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sentencia, conn))
                {
                    cmd.CommandType = CommandType.Text;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(dr, LoadOption.Upsert);
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public DataTable ListarPrimerNivel()
        {
            const string sentencia = "SELECT * FROM VMaestroConcepto WHERE LEN(CODIGO) = 3";
            try
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sentencia, conn))
                {
                    cmd.CommandType = CommandType.Text;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(dr, LoadOption.Upsert);
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
