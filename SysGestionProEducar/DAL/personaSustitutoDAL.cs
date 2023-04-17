using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class personaSustitutoDAL
    {
        SqlConnection conn;
        public personaSustitutoDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerPersonaSustitutoDAL(personaSustitutoTo pesTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_PERSONA_SUSTITUTO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PER", pesTo.COD_PER);
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
        public bool insertarPersonaSustitutoDAL(personaSustitutoTo pesTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_PERSONA_SUSTITUTO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PER", pesTo.COD_PER);
            cmd.Parameters.AddWithValue("@DNI_SUS", pesTo.DNI_SUS);
            cmd.Parameters.AddWithValue("@NOMBRE_SUS", pesTo.NOMBRE_SUS);
            cmd.Parameters.AddWithValue("@DIRECCION_SUS", pesTo.DIRECCION_SUS);
            cmd.Parameters.AddWithValue("@TELEFONO_SUS", pesTo.TELEFONO_SUS);
            cmd.Parameters.AddWithValue("@EMAIL_SUS", pesTo.EMAIL_SUS);
            cmd.Parameters.AddWithValue("@OBS_SUS", pesTo.OBS_SUS);
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
        public bool modificarPersonaSustitutoDAL(personaSustitutoTo pesTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_PERSONA_SUSTITUTO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PER", pesTo.COD_PER);
            cmd.Parameters.AddWithValue("@NOMBRE_SUS", pesTo.NOMBRE_SUS);
            cmd.Parameters.AddWithValue("@DIRECCION_SUS", pesTo.DIRECCION_SUS);
            cmd.Parameters.AddWithValue("@TELEFONO_SUS", pesTo.TELEFONO_SUS);
            cmd.Parameters.AddWithValue("@EMAIL_SUS", pesTo.EMAIL_SUS);
            cmd.Parameters.AddWithValue("@OBS_SUS", pesTo.OBS_SUS);
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
        public bool eliminarPersonaSustitutoDAL(personaSustitutoTo pesTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_PERSONA_SUSTITUTO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PER", pesTo.COD_PER);
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
