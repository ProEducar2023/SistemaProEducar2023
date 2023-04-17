using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class transportista_vehiculoDAL
    {
        SqlConnection conn;
        public transportista_vehiculoDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerTransportistaVehiculoDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("aesOBTENER_VEHICULOS", conn);
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
        public bool insertaTransportistaVehiculo(transportista_vehiculoTo trvTo, ref string errMensaje)
        {
            bool flat = false;
            SqlCommand cmd = new SqlCommand("aesinsertaTransportistaVehiculo", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_TRANSPORTISTA", trvTo.COD_TRANSPORTISTA);
            cmd.Parameters.AddWithValue("@ITEM", trvTo.ITEM);
            cmd.Parameters.AddWithValue("@MARCA", trvTo.MARCA);
            cmd.Parameters.AddWithValue("@NRO_PLACA", trvTo.NRO_PLACA);
            cmd.Parameters.AddWithValue("@COD_TIPO", trvTo.COD_TIPO);
            cmd.Parameters.AddWithValue("@CER_INS", trvTo.CER_INS);
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
        public bool deleteEliminaTransportistaVehiculoDAL(ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("aesDeleteEliminaTransportistaVehiculo", conn);
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
