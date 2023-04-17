using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class situacionDAL
    {
        SqlConnection conn;
        public situacionDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerSituacionDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_SITUACION", conn);
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
        public bool insertarSituacionDAL(situacionTo sitTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_SITUACION", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SIT", sitTo.COD_SIT);
            cmd.Parameters.AddWithValue("@DESC_SIT", sitTo.DESC_SIT);
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
        public bool modificarSituacionDAL(situacionTo sitTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_SITUACION", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SIT", sitTo.COD_SIT);
            cmd.Parameters.AddWithValue("@DESC_SIT", sitTo.DESC_SIT);
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
        public bool eliminarSituacionDAL(situacionTo sitTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_SITUACION", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SIT", sitTo.COD_SIT);
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
        public int verificaSituacionDAL(situacionTo sitTo)
        {
            int val = -1;
            SqlCommand cmd = new SqlCommand("VERIFICAR_SITUACION", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SIT", sitTo.COD_SIT);
            try
            {
                conn.Open();
                val = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception)
            {
                val = -1;
            }
            finally
            {
                conn.Close();
            }
            return val;
        }
    }
}
