using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class personaFonoDAL
    {
        SqlConnection conn;
        public personaFonoDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerPersonaFonoDAL(personaFonoTo pefTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_FONOS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PER", pefTo.COD_PER);
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
        public bool insertarPersonaFonoDAL(personaFonoTo pefTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_FONO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PER", pefTo.COD_PER);
            cmd.Parameters.AddWithValue("@COD_TIPO", pefTo.COD_TIPO_FONO);
            cmd.Parameters.AddWithValue("@ITEM", pefTo.ITEM);
            cmd.Parameters.AddWithValue("@NRO_FONO", pefTo.NRO_FONO);
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
        public bool eliminarPersonaFonoDAL(personaFonoTo pefTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_FONO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PER", pefTo.COD_PER);
            //cmd.Parameters.AddWithValue("@COD_TIPO_FONO", pefTo.COD_TIPO_FONO);
            //cmd.Parameters.AddWithValue("@ITEM", pefTo.ITEM);
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

        public DataTable ObtenerTelefonoPuntoCobranzaFono(string codPtoCob)
        {
            DataTable dt = new DataTable();
            const string consulta = "SELECT TOP(1) f.* FROM MAESTRO_PERSONAS ma " +
            "INNER JOIN PERSONA_CLASE c ON(c.COD_PER = ma.COD_PER) " +
            "INNER JOIN PERSONA_FONO f ON(f.COD_PER = ma.COD_PER) " +
            "WHERE ma.NRO_DOC = @COD_PTO_COB AND c.COD_CAT = 'D'";

            SqlCommand cmd = new SqlCommand(consulta, conn)
            {
                CommandType = CommandType.Text
            };
            _ = cmd.Parameters.AddWithValue("@COD_PTO_COB", codPtoCob);

            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr, LoadOption.Upsert);
                dr.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }
    }
}
