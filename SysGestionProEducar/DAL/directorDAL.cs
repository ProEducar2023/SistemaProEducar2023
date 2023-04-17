using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class directorDAL
    {
        SqlConnection conn;
        public directorDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerDirectorDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_DIRECTOR", conn);
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
        public bool insertarDirectorDAL(directorTo dirTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_DIRECTOR", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_DIR", dirTo.COD_DIR);
            cmd.Parameters.AddWithValue("@COD_DIRNAC", dirTo.COD_DIRNAC);
            cmd.Parameters.AddWithValue("@DESC_DIR", dirTo.DESC_DIR);
            cmd.Parameters.AddWithValue("@DESC_CORTA", dirTo.DESC_CORTA);
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
        public bool modificarDirectorDAL(directorTo dirTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_DIRECTOR", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_DIR", dirTo.COD_DIR);
            cmd.Parameters.AddWithValue("@COD_DIRNAC", dirTo.COD_DIRNAC);
            cmd.Parameters.AddWithValue("@DESC_DIR", dirTo.DESC_DIR);
            cmd.Parameters.AddWithValue("@DESC_CORTA", dirTo.DESC_CORTA);
            cmd.Parameters.AddWithValue("@STATUS_ACT", dirTo.STATUS_ACT);
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
        public bool eliminarDirectorDAL(directorTo dirTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_DIRECTOR", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_DIR", dirTo.COD_DIR);
            cmd.Parameters.AddWithValue("@COD_DIRNAC", dirTo.COD_DIRNAC);
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
