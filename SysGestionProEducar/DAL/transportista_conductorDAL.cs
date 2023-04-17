using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class transportista_conductorDAL
    {
        SqlConnection conn;
        public transportista_conductorDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerTransportistaConductorDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("aesOBTENER_CONDUCTORES", conn);
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
        public bool insertaTransportistaConductorDAL(transportista_conductorTo trcTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("aesinsertaTransporteConductor", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_TRANSPORTISTA", trcTo.COD_TRANSPORTISTA);
            cmd.Parameters.AddWithValue("@ITEM", trcTo.ITEM);
            cmd.Parameters.AddWithValue("@NOMBRE_CONDUCTOR", trcTo.NOMBRE_CONDUCTOR);
            cmd.Parameters.AddWithValue("@DIRECCION ", trcTo.DIRECCION);
            cmd.Parameters.AddWithValue("@NRO_LICENCIA", trcTo.NRO_LICENCIA);
            cmd.Parameters.AddWithValue("@NRO_DOCUMENTO", trcTo.NRO_DOCUMENTO);
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
        public bool deleteEliminaTransportistaConductorDAL(ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("aesDeleteEliminaTransportistaConductor", conn);
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
    }
}
