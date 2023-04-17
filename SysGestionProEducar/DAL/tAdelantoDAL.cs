using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class tAdelantoDAL
    {
        SqlConnection conn;
        public tAdelantoDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerTAdelantoDAL(tAdelantoTo tadeTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_T_ADELANTO", conn);
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
        public bool insertarTAdelantoDAL(tAdelantoTo tadeTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_T_ADELANTO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", tadeTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@FE_AÑO", tadeTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", tadeTo.FE_MES);
            cmd.Parameters.AddWithValue("@COD_PER", tadeTo.COD_PER);
            cmd.Parameters.AddWithValue("@COD_D_H", tadeTo.COD_D_H);
            cmd.Parameters.AddWithValue("@COD_DOC", tadeTo.COD_DOC);
            cmd.Parameters.AddWithValue("@NRO_DOC", tadeTo.NRO_DOC);
            cmd.Parameters.AddWithValue("@FECHA_DOC", tadeTo.FECHA_DOC);
            cmd.Parameters.AddWithValue("@COD_MONEDA", tadeTo.COD_MONEDA);
            cmd.Parameters.AddWithValue("@TIPO_CAMBIO", tadeTo.TIPO_CAMBIO);
            cmd.Parameters.AddWithValue("@IMP_DOC", tadeTo.IMP_DOC);
            cmd.Parameters.AddWithValue("@OBSERVACION", tadeTo.OBSERVACION);
            cmd.Parameters.AddWithValue("@TIPO_OPE", tadeTo.TIPO_OPE);
            cmd.Parameters.AddWithValue("@COD_USU_CREA", tadeTo.COD_USU_CREA);
            cmd.Parameters.AddWithValue("@FECHA_CREA", tadeTo.FECHA_CREA);
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
        public bool eliminarTAdelantoDAL(tAdelantoTo tadeTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_T_ADELANTO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", tadeTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@FE_AÑO", tadeTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", tadeTo.FE_MES);
            cmd.Parameters.AddWithValue("@COD_PER", tadeTo.COD_PER);
            cmd.Parameters.AddWithValue("@COD_D_H", tadeTo.COD_D_H);
            cmd.Parameters.AddWithValue("@COD_DOC", tadeTo.COD_DOC);
            cmd.Parameters.AddWithValue("@NRO_DOC", tadeTo.NRO_DOC);
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
