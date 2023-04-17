using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class TipoMonedaDAL
    {
        private readonly SqlConnection conn;

        public TipoMonedaDAL()
        {
            conn = new SqlConnection(conexion.con2);
        }


        public DataTable ListaMoneda()
        {
            const string select = "SELECT * FROM MONEDA";
            SqlCommand cmd = new SqlCommand(select, conn)
            {
                CommandType = CommandType.Text
            };

            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr, LoadOption.Upsert);
                DataRow row = dt.NewRow();
                row["IdMoneda"] = 0;
                row["Desc_moneda"] = "Seleccione";
                row["Cod_moneda"] = string.Empty;
                dt.Rows.InsertAt(row, 0);
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
