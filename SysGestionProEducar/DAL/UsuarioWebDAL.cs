using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class UsuarioWebDAL
    {
        SqlConnection conn;
        public UsuarioWebDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerUsuarioWebDAL(usuarioWebTo uswTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_USUARIOS_WEB", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PER", uswTo.COD_PER);

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
        public bool insertarUsuarioWebDAL(usuarioWebTo uswTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_USUARIO_WEB", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PER", uswTo.COD_PER);
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", uswTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@ITEM", uswTo.ITEM);
            cmd.Parameters.AddWithValue("@USUARIO", uswTo.USUARIO);
            cmd.Parameters.AddWithValue("@PASSWORD", uswTo.PASSWORD);
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
        public bool modificarUsuarioWebDAL(usuarioWebTo uswTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_USUARIO_WEB", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PER", uswTo.COD_PER);
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", uswTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@ITEM", uswTo.ITEM);
            cmd.Parameters.AddWithValue("@USUARIO", uswTo.USUARIO);
            cmd.Parameters.AddWithValue("@PASSWORD", uswTo.PASSWORD);
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
        public bool eliminarUsuarioWebDAL(usuarioWebTo uswTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_USUARIO_WEB", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PER", uswTo.COD_PER);
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", uswTo.NRO_CONTRATO);

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
