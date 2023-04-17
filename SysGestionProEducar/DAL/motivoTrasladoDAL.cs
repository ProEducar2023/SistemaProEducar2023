using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class motivoTrasladoDAL
    {
        SqlConnection conn;
        public motivoTrasladoDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerMotivoTrasladoDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_MOT_TRASLADO", conn);
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
        public bool insertarMotivoTrasladoDAL(motivoTrasladoTo mtdTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_MOT_TRASLADO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_MOT", mtdTo.COD_MOT);
            cmd.Parameters.AddWithValue("@DESC_MOT", mtdTo.DESC_MOT);
            cmd.Parameters.AddWithValue("@COD_FORMATO", mtdTo.COD_FORMATO);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception e)
            {
                errMensaje = e.Message;
            }
            finally
            {
                conn.Close();
            }
            return flag;
        }
        public bool modificarMotivoTrasladoDAL(motivoTrasladoTo mtdTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_MOT_TRASLADO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_MOT", mtdTo.COD_MOT);
            cmd.Parameters.AddWithValue("@DESC_MOT", mtdTo.DESC_MOT);
            cmd.Parameters.AddWithValue("@COD_FORMATO", mtdTo.COD_FORMATO);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception e)
            {
                errMensaje = e.Message;
            }
            finally
            {
                conn.Close();
            }
            return flag;
        }
        public bool eliminarMotivoTrasladoDAL(motivoTrasladoTo mtdTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_MOT_TRASLADO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_MOT", mtdTo.COD_MOT);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception e)
            {
                errMensaje = e.Message;
            }
            finally
            {
                conn.Close();
            }
            return flag;
        }
        public int verificaMotivoTrasladoDAL(motivoTrasladoTo mtdTo)
        {
            int val = -1;
            SqlCommand cmd = new SqlCommand("VERIFICAR_MOTIVO_TRASLADO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_MOT", mtdTo.COD_MOT);
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
