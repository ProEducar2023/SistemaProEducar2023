using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class lugarEntregaDAL
    {
        SqlConnection conn;
        public lugarEntregaDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerLugarEntregaDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_LUGAR_ENTREGA", conn);
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
        public bool insertarLugarEntregaDAL(lugarEntregaTo lgeTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_LUGAR_ENTREGA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_LUGAR_ENT", lgeTo.COD_LUGAR_ENT);
            cmd.Parameters.AddWithValue("@DESC_LUGAR_ENT", lgeTo.DESC_LUGAR_ENT);
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
        public bool modificarLugarEntregaDAL(lugarEntregaTo lgeTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_LUGAR_ENTREGA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_LUGAR_ENT", lgeTo.COD_LUGAR_ENT);
            cmd.Parameters.AddWithValue("@DESC_LUGAR_ENT", lgeTo.DESC_LUGAR_ENT);
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
        public bool eliminarLugarEntregaDAL(lugarEntregaTo lgeTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_LUGAR_ENTREGA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_LUGAR_ENT", lgeTo.COD_LUGAR_ENT);
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
        public int verificarLugarEntregaDAL(lugarEntregaTo lgeTo)
        {
            int val = -1;
            SqlCommand cmd = new SqlCommand("VERIFICAR_LUGAR_ENTREGA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_LUGAR_ENT", lgeTo.COD_LUGAR_ENT);
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
