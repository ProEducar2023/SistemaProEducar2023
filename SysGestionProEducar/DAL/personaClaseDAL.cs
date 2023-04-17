using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class personaClaseDAL
    {
        SqlConnection conn;
        public personaClaseDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerPersonaClaseDAL(personaClaseTo pecTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_CLASES", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PER", pecTo.COD_PER);

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
        public bool insertarPersonaClaseDAL(personaClaseTo pecTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_CLASES", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PER", pecTo.COD_PER);
            cmd.Parameters.AddWithValue("@COD_CLASE", pecTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_CAT", pecTo.COD_CAT);
            cmd.Parameters.AddWithValue("@linea", pecTo.LINEA_CRED);
            cmd.Parameters.AddWithValue("@FORMA_PAGO", pecTo.FORMA_PAGO);
            cmd.Parameters.AddWithValue("@CONDICION_VENTA", pecTo.CONDICION_VENTA);
            cmd.Parameters.AddWithValue("@NRO_DIAS", pecTo.NRO_DIAS);
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
        public bool eliminarPersonaClaseDAL(personaClaseTo pecTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_PERSONA_CLASE", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PER", pecTo.COD_PER);

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
