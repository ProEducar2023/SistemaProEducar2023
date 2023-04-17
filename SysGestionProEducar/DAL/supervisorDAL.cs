using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class supervisorDAL
    {
        SqlConnection conn;
        public supervisorDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerSupervisorDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_SUPERVISOR", conn);
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
        public bool insertarSupervisorDAL(supervisorTo supTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_SUPERVISOR", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUP", supTo.COD_SUP);
            cmd.Parameters.AddWithValue("@COD_DIRNAC", supTo.COD_DIRNAC);
            cmd.Parameters.AddWithValue("@COD_DIR", supTo.COD_DIR);
            cmd.Parameters.AddWithValue("@DESC_SUP", supTo.DESC_SUP);
            cmd.Parameters.AddWithValue("@DESC_CORTA", supTo.DESC_CORTA);
            cmd.Parameters.AddWithValue("@STATUS_ACT", supTo.STATUS_ACT);
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
        public bool modificarSupervisorDAL(supervisorTo supTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_SUPERVISOR", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUP", supTo.COD_SUP);
            cmd.Parameters.AddWithValue("@COD_DIRNAC", supTo.COD_DIRNAC);
            cmd.Parameters.AddWithValue("@COD_DIR", supTo.COD_DIR);
            cmd.Parameters.AddWithValue("@DESC_SUP", supTo.DESC_SUP);
            cmd.Parameters.AddWithValue("@DESC_CORTA", supTo.DESC_CORTA);
            cmd.Parameters.AddWithValue("@STATUS_ACT", supTo.STATUS_ACT);
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
        public bool eliminarSupervisorDAL(supervisorTo supTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_SUPERVISOR", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUP", supTo.COD_SUP);
            cmd.Parameters.AddWithValue("@COD_DIRNAC", supTo.COD_DIRNAC);
            cmd.Parameters.AddWithValue("@COD_DIR", supTo.COD_DIR);
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
