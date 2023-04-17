using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class programaDAL
    {
        SqlConnection conn;
        public programaDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerProgramaDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_PROGRAMAS", conn);
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
        public bool insertarProgramaDAL(programaTo proTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_PROGRAMAS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PROGRAMA", proTo.COD_PROGRAMA);
            cmd.Parameters.AddWithValue("@DESC_PROGRAMA", proTo.DESC_PROGRAMA);
            cmd.Parameters.AddWithValue("@DESC_CORTA", proTo.DESC_CORTA);
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
        public bool modificarProgramaDAL(programaTo proTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_PROGRAMAS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PROGRAMA", proTo.COD_PROGRAMA);
            cmd.Parameters.AddWithValue("@DESC_PROGRAMA", proTo.DESC_PROGRAMA);
            cmd.Parameters.AddWithValue("@DESC_CORTA", proTo.DESC_CORTA);
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
        public bool eliminarProgramaDAL(programaTo proTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_PROGRAMAS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PROGRAMA", proTo.COD_PROGRAMA);
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
