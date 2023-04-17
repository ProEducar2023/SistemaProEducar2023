using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class directorNacDAL
    {
        SqlConnection conn;
        public directorNacDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerDirectorNacDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_DIRECTOR_NACIONAL", conn);
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
        public bool insertarDirectorNacDAL(directorNacTo dinTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_DIRECTOR_NACIONAL", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_DIRNAC", dinTo.COD_DIRNAC);
            cmd.Parameters.AddWithValue("@DESC_DIRNAC", dinTo.DESC_DIRNAC);
            cmd.Parameters.AddWithValue("@DESC_CORTA", dinTo.DESC_CORTA);
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
        public bool modificarDirectorNacDAL(directorNacTo dinTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_DIRECTOR_NACIONAL", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_DIRNAC", dinTo.COD_DIRNAC);
            cmd.Parameters.AddWithValue("@DESC_DIRNAC", dinTo.DESC_DIRNAC);
            cmd.Parameters.AddWithValue("@DESC_CORTA", dinTo.DESC_CORTA);
            cmd.Parameters.AddWithValue("@STATUS_ACT", dinTo.STATUS_ACT);
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
        public bool eliminarDirectorNacDAL(directorNacTo dinTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_DIRECTOR_NACIONAL", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_DIRNAC", dinTo.COD_DIRNAC);
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
