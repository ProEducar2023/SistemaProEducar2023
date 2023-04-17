using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class usuariosDAL
    {
        SqlConnection conn, conn2;
        public usuariosDAL()
        {
            conn = new SqlConnection(conexion.con);
            conn2 = new SqlConnection(conexion.con2);
        }
        public DataTable obtenerUsuariosparaUsuariosCargoDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_USUARIO1", conn2);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn2.Open();
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
                conn2.Close();
            }
            return dt;
        }
        public DataTable obtenerTodosUsuariosDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_TODOS_USUARIOS", conn2);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn2.Open();
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
                conn2.Close();
            }
            return dt;
        }
        public DataTable obtenerUsuario_x_CodDAL(usuariosTo usuTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_USUARIOS_X_COD", conn2);
            cmd.Parameters.AddWithValue("@Cod_Usu", usuTo.Cod_usu);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn2.Open();
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
                conn2.Close();
            }
            return dt;
        }
    }
}
