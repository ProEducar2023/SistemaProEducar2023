using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DepartamentoDAL
    {
        SqlConnection conn;
        SqlConnection conGeneral;
        public DepartamentoDAL()
        {
            conn = new SqlConnection(conexion.con);
            conGeneral = new SqlConnection(conexion.con2);
        }

        public DataTable ListarDepartamentos()
        {
            const string query = "SELECT * FROM DEPARTAMENTO";
            try
            {
                SqlCommand cmd = new SqlCommand(query, conGeneral)
                {
                    CommandType = CommandType.Text
                };
                conGeneral.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr, LoadOption.Upsert);
                dr.Close();
                return dt;
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                conGeneral.Close();
            }
        }

        public DataTable ListarDepartamento(string codPais)
        {
            const string select = "SELECT COD_DEP, DESC_DEP FROM BD_GENERAL_COI..DEPARTAMENTO WHERE COD_PAIS = @COD_PAIS";
            try
            {
                SqlCommand cmd = new SqlCommand(select, conn)
                {
                    CommandType = CommandType.Text
                };

                _ = cmd.Parameters.AddWithValue("@COD_PAIS", codPais);

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
