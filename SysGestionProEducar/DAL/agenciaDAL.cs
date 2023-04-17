using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class agenciaDAL
    {
        SqlConnection conn;
        public agenciaDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerAgenciaDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_AGENCIA", conn);
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
        public bool insertarAgenciaDAL(agenciaTo ageTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_AGENCIA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_AGENCIA", ageTo.COD_AGENCIA);
            cmd.Parameters.AddWithValue("@NOMBRE", ageTo.NOMBRE);
            cmd.Parameters.AddWithValue("@DIRECCION", ageTo.DIRECCION);
            cmd.Parameters.AddWithValue("@RUC", ageTo.RUC);
            cmd.Parameters.AddWithValue("@TELEFONO", ageTo.TELEFONO);
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
        public bool modificarAgenciaDAL(agenciaTo ageTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_AGENCIA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_AGENCIA", ageTo.COD_AGENCIA);
            cmd.Parameters.AddWithValue("@NOMBRE", ageTo.NOMBRE);
            cmd.Parameters.AddWithValue("@DIRECCION", ageTo.DIRECCION);
            cmd.Parameters.AddWithValue("@RUC", ageTo.RUC);
            cmd.Parameters.AddWithValue("@TELEFONO", ageTo.TELEFONO);
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
        public bool eliminarAgenciaDAL(agenciaTo ageTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_AGENCIA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_AGENCIA", ageTo.COD_AGENCIA);
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
        public int verificarAgenciaDAL(agenciaTo ageTo)
        {
            int val = -1;
            SqlCommand cmd = new SqlCommand("VERIFICAR_AGENCIA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_AGENCIA", ageTo.COD_AGENCIA);
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
