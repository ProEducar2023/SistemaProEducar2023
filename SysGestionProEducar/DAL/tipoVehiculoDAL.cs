using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class tipoVehiculoDAL
    {
        SqlConnection conn;
        public tipoVehiculoDAL()
        {
            conn = new SqlConnection(conexion.con);
        }

        public DataTable obtenerTipoVehiculoDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("aesObtenerTipoVehiculo", conn);
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
        public bool insertarTipoVehiculoDAL(tipoVehiculoTo tpvTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("aesInsertarTipoVehiculo", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_VEHICULO", tpvTo.COD_VEHICULO);
            cmd.Parameters.AddWithValue("@DESC_VEHICULO", tpvTo.DESC_VEHICULO);
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
        public bool modificarTipoVehiculoDAL(tipoVehiculoTo tpvTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("aesModificarTipoVehiculo", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_VEHICULO", tpvTo.COD_VEHICULO);
            cmd.Parameters.AddWithValue("@DESC_VEHICULO", tpvTo.DESC_VEHICULO);
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
        public bool eliminarTipoVehiculoDAL(tipoVehiculoTo tpvTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("aesEliminarTipoVehiculo", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_VEHICULO", tpvTo.COD_VEHICULO);
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
        public int verificaTipoVehiculoDAL(tipoVehiculoTo tpvTo)
        {
            int val = -1;
            SqlCommand cmd = new SqlCommand("VERIFICAR_TIPO_VEHICULO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_VEHICULO", tpvTo.COD_VEHICULO);
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
