using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class personaBeneficiarioDAL
    {
        SqlConnection conn;
        public personaBeneficiarioDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerPersonaBeneficiarioDAL(personaBeneficiarioTo pebTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_PERSONA_BENEFICIARIO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PER", pebTo.COD_PER);
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
        public bool insertarPersonaBeneficiarioDAL(personaBeneficiarioTo pebTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_PERSONA_BENEFICIARIO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PER", pebTo.COD_PER);
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", pebTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@ITEM", pebTo.ITEM);
            cmd.Parameters.AddWithValue("@NOMBRE", pebTo.NOMBRE);
            cmd.Parameters.AddWithValue("@DNI", pebTo.DNI);
            cmd.Parameters.AddWithValue("@FE_NAC", pebTo.FE_NAC);
            cmd.Parameters.AddWithValue("@EMAIL", pebTo.EMAIL);
            cmd.Parameters.AddWithValue("@TEL_CONTACTO", pebTo.TEL_CONTACTO);
            cmd.Parameters.AddWithValue("@PLAZO_ACTIVACION", pebTo.PLAZO_ACTIVACION);
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
        public bool eliminarPersonaBeneficiarioDAL(personaBeneficiarioTo pebTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_PERSONA_BENEFICIARIO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PER", pebTo.COD_PER);
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
