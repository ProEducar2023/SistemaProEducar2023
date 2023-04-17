using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class semanaContratoDAL
    {
        SqlConnection conn;
        public semanaContratoDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerSemanaContratoDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_SEMANA_CONTRATO", conn);
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
        public DataTable obtenerSemanaContratoparaPreventaDAL(semanaContratoTo scTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_SEMANA_CONTRATO_PARA_PREVENTA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FE_MES", scTo.FE_MES);
            cmd.Parameters.AddWithValue("@FE_AÑO", scTo.FE_AÑO);
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
        public bool insertarSemanaContratoDAL(semanaContratoTo scTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_SEMANA_CONTRATO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FE_MES", scTo.FE_MES);
            cmd.Parameters.AddWithValue("@FE_AÑO", scTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@NRO_SEMANA", scTo.NRO_SEMANA);
            cmd.Parameters.AddWithValue("@NOM_SEMANA", scTo.NOM_SEMANA);
            cmd.Parameters.AddWithValue("@FE_DEL", scTo.FE_DEL);
            cmd.Parameters.AddWithValue("@FE_AL", scTo.FE_AL);
            cmd.Parameters.AddWithValue("@NRO_REPORTE", scTo.NRO_REPORTE);
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
        public bool modificarSemanaContratoDAL(semanaContratoTo scTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_SEMANA_CONTRATO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FE_MES", scTo.FE_MES);
            cmd.Parameters.AddWithValue("@FE_AÑO", scTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@NRO_SEMANA", scTo.NRO_SEMANA);
            cmd.Parameters.AddWithValue("@NOM_SEMANA", scTo.NOM_SEMANA);
            cmd.Parameters.AddWithValue("@FE_DEL", scTo.FE_DEL);
            cmd.Parameters.AddWithValue("@FE_AL", scTo.FE_AL);
            cmd.Parameters.AddWithValue("@NRO_REPORTE", scTo.NRO_REPORTE);
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
        public bool eliminarSemanaContratoDAL(semanaContratoTo scTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_SEMANA_CONTRATO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FE_MES", scTo.FE_MES);
            cmd.Parameters.AddWithValue("@FE_AÑO", scTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@NRO_SEMANA", scTo.NRO_SEMANA);
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
