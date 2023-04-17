using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class motivoLlamadasDescCobDirDAL
    {
        SqlConnection conn;
        public motivoLlamadasDescCobDirDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerMotivoLlamadasDescCobDirDAL(motivoLlamadasDescCobDirTo mlTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_MOTIVO_LLAMADAS_DESC_COB_DIR", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            if (mlTo.CATEGORIA == null)
                cmd.Parameters.AddWithValue("@CATEGORIA", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@CATEGORIA", mlTo.CATEGORIA);
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
        public bool insertarMotivoLlamadaDescCobDirDAL(motivoLlamadasDescCobDirTo mlTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_MOTIVO_LLAMADAS_DESCUENTO_COBRANZA_DIRECTA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_MOTIVO", mlTo.COD_MOTIVO);
            cmd.Parameters.AddWithValue("@DESC_MOTIVO", mlTo.DESC_MOTIVO);
            cmd.Parameters.AddWithValue("@TIPO_MOTIVO", mlTo.TIPO_MOTIVO);
            cmd.Parameters.AddWithValue("@CATEGORIA", mlTo.CATEGORIA);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception e)
            {
                errMensaje = e.Message;
                flag = false;
            }
            finally
            {
                conn.Close();
            }
            return flag;
        }
        public bool modificarMotivoLlamadaDescCobDirDAL(motivoLlamadasDescCobDirTo mlTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_MOTIVO_LLAMADAS_DESCUENTO_COBRANZA_DIRECTA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_MOTIVO", mlTo.COD_MOTIVO);
            cmd.Parameters.AddWithValue("@DESC_MOTIVO", mlTo.DESC_MOTIVO);
            cmd.Parameters.AddWithValue("@TIPO_MOTIVO", mlTo.TIPO_MOTIVO);
            cmd.Parameters.AddWithValue("@CATEGORIA", mlTo.CATEGORIA);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception e)
            {
                errMensaje = e.Message;
                flag = false;
            }
            finally
            {
                conn.Close();
            }
            return flag;
        }
        public bool eliminarMotivoLlamadaDescCobDirDAL(motivoLlamadasDescCobDirTo mlTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_MOTIVO_LLAMADAS_DESCUENTO_COBRANZA_DIRECTA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_MOTIVO", mlTo.COD_MOTIVO);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception e)
            {
                errMensaje = e.Message;
                flag = false;
            }
            finally
            {
                conn.Close();
            }
            return flag;
        }
        public int verificaMotivoLlamadaDescCobDirDAL(motivoLlamadasDescCobDirTo mlTo, ref string errMensaje)
        {
            int cant = -1;
            SqlCommand cmd = new SqlCommand("VERIFICAR_MOTIVO_LLAMADA_DESCUENTO_COBRANZA_DIRECTA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_MOTIVO", mlTo.COD_MOTIVO);
            try
            {
                conn.Open();
                cant = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception e)
            {
                cant = -1;
                errMensaje = e.Message;
            }
            finally
            {
                conn.Close();
            }
            return cant;
        }
    }
}
