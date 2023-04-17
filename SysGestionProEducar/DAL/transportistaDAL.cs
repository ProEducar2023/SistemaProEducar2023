using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class transportistaDAL
    {
        SqlConnection conn;
        public transportistaDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerTransportistaDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("aesOBTENER_TRANSPORTISTA", conn);
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

        public bool insertaTransportistaDAL(transportistaTo traTo, ref string errMensaje)
        {
            bool flat = false;
            SqlCommand cmd = new SqlCommand("aesInsertaTransportista", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_TRANSPORTISTA", traTo.COD_TRANSPORTISTA);
            cmd.Parameters.AddWithValue("@NOMBRE", traTo.NOMBRE);
            cmd.Parameters.AddWithValue("@DIRECCION", traTo.DIRECCION);
            cmd.Parameters.AddWithValue("@RUC", traTo.RUC);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                flat = true;
            }
            catch (Exception e)
            {
                flat = false;
                errMensaje = e.Message;
            }
            finally
            {
                conn.Close();
            }
            return flat;
        }
        public bool deleteEliminaTransportistaDAL(ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("aesDeleteEliminaTransportista", conn);
            cmd.CommandType = CommandType.StoredProcedure;
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
        public int verificaTransportistaDAL(transportistaTo traTo)
        {
            int val = -1;
            SqlCommand cmd = new SqlCommand("VERIFICAR_TRANSPORTISTA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_TRANSPORTISTA", traTo.COD_TRANSPORTISTA);
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
