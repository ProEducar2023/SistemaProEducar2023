using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class personaContactoDAL
    {
        SqlConnection conn;
        public personaContactoDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerPersonaContactoDAL(personaContactoTo percTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_CONTACTOS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PER", percTo.COD_PER);
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
        public bool insertarPesonaContactoDAL(personaContactoTo percTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_CONTACTOS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PER", percTo.COD_PER);
            cmd.Parameters.AddWithValue("@ITEM", percTo.ITEM);
            cmd.Parameters.AddWithValue("@NOMBRE", percTo.NOMBRE);
            cmd.Parameters.AddWithValue("@DNI", percTo.DNI);
            cmd.Parameters.AddWithValue("@TELEFONO", percTo.TELEFONO);
            cmd.Parameters.AddWithValue("@MAIL", percTo.MAIL);
            cmd.Parameters.AddWithValue("@OBSERVACION", percTo.OBSERVACION);
            cmd.Parameters.AddWithValue("@STATUS_FE", percTo.STATUS_FE);
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
        public bool modificarPesonaContactoDAL(personaContactoTo percTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_CONTACTOS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PER", percTo.COD_PER);
            cmd.Parameters.AddWithValue("@ITEM", percTo.ITEM);
            cmd.Parameters.AddWithValue("@NOMBRE", percTo.NOMBRE);
            cmd.Parameters.AddWithValue("@MAIL", percTo.MAIL);
            cmd.Parameters.AddWithValue("@OBSERVACION", percTo.OBSERVACION);
            cmd.Parameters.AddWithValue("@STATUS_FE", percTo.STATUS_FE);
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
        public bool eliminarPesonaContactoDAL(personaContactoTo percTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_CONTACTO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PER", percTo.COD_PER);
            //cmd.Parameters.AddWithValue("@ITEM", percTo.ITEM);
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
