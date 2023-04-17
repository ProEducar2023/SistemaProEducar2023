using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class kitDAL
    {
        SqlConnection conn;
        public kitDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerKitDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_KIT", conn);
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
        public DataTable obtenerKitDAL(kitTo kiTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_KIT_X_GRUPO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("COD_GRUPO", kiTo.COD_GRUPO);
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
        public bool insertarKitDAL(kitTo kiTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_KIT", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("COD_KIT", kiTo.COD_KIT);
            cmd.Parameters.AddWithValue("DESC_KIT", kiTo.DESC_KIT);
            cmd.Parameters.AddWithValue("COD_CLASE", kiTo.COD_CLASE);
            cmd.Parameters.AddWithValue("COD_GRUPO", kiTo.COD_GRUPO);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception e)
            {
                flag = false;
                errMensaje = e.Message;
            }
            finally
            {
                conn.Close();
            }
            return flag;
        }
        public bool modificarKitDAL(kitTo kiTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_KIT2", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("COD_KIT", kiTo.COD_KIT);
            cmd.Parameters.AddWithValue("DESC_KIT", kiTo.DESC_KIT);
            cmd.Parameters.AddWithValue("COD_CLASE", kiTo.COD_CLASE);
            cmd.Parameters.AddWithValue("COD_GRUPO", kiTo.COD_GRUPO);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception e)
            {
                flag = false;
                errMensaje = e.Message;
            }
            finally
            {
                conn.Close();
            }
            return flag;
        }
        public bool eliminarKitDAL(kitTo kiTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_KIT", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("COD_KIT", kiTo.COD_KIT);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception e)
            {
                flag = false;
                errMensaje = e.Message;
            }
            finally
            {
                conn.Close();
            }
            return flag;
        }
    }
}
