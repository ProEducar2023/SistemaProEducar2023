using System.Data.SqlClient;
namespace DAL
{
    public class pedidosDAL
    {
        SqlConnection conn;
        public pedidosDAL()
        {
            conn = new SqlConnection(conexion.con);
        }

    }
}
