using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class pAdelantoDAL
    {
        SqlConnection conn;
        public pAdelantoDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerP_AdelantoDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_P_ADELANTO_POR_COMISIONISTA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@COD_PER",padeTo.COD_PER);
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
        public bool modificarPAdelantoporLiquidacionDAL(pAdelantoTo padeTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_PADELANTO_POR_LIQUIDACION", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", padeTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@FE_AÑO", padeTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", padeTo.FE_MES);
            cmd.Parameters.AddWithValue("@COD_PER", padeTo.COD_PER);
            cmd.Parameters.AddWithValue("@NRO_DOC", padeTo.NRO_DOC);
            cmd.Parameters.AddWithValue("@IMP_DOC", padeTo.IMP_DOC);
            cmd.Parameters.AddWithValue("@OBSERVACION", padeTo.OBSERVACION);
            cmd.Parameters.AddWithValue("@STATUS_LIQUIDADO", padeTo.STATUS_LIQUIDADO);
            cmd.Parameters.AddWithValue("@STATUS_CANCELADO", padeTo.STATUS_CANCELADO);
            cmd.Parameters.AddWithValue("@COD_USU_MOD", padeTo.COD_USU_MOD);
            cmd.Parameters.AddWithValue("@FECHA_MOD", padeTo.FECHA_MOD);
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
        public bool modificarPAdelantoporLiquidacion2DAL(pAdelantoTo padeTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_PADELANTO_POR_LIQUIDACION_2", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", padeTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@FE_AÑO", padeTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", padeTo.FE_MES);
            cmd.Parameters.AddWithValue("@COD_PER", padeTo.COD_PER);
            cmd.Parameters.AddWithValue("@NRO_DOC", padeTo.NRO_DOC);
            cmd.Parameters.AddWithValue("@IMP_DOC", padeTo.IMP_DOC);
            cmd.Parameters.AddWithValue("@OBSERVACION", padeTo.OBSERVACION);
            cmd.Parameters.AddWithValue("@STATUS_LIQUIDADO", padeTo.STATUS_LIQUIDADO);
            cmd.Parameters.AddWithValue("@STATUS_CANCELADO", padeTo.STATUS_CANCELADO);
            cmd.Parameters.AddWithValue("@COD_USU_MOD", padeTo.COD_USU_MOD);
            cmd.Parameters.AddWithValue("@FECHA_MOD", padeTo.FECHA_MOD);
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
        public bool revertirPAdelantoporLiquidacionDAL(pAdelantoTo padeTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("REVERTIR_PADELANTO_POR_LIQUIDACION", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", padeTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@FE_AÑO", padeTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", padeTo.FE_MES);
            cmd.Parameters.AddWithValue("@COD_PER", padeTo.COD_PER);
            cmd.Parameters.AddWithValue("@NRO_DOC", padeTo.NRO_DOC);
            cmd.Parameters.AddWithValue("@IMP_DOC", padeTo.IMP_DOC);
            cmd.Parameters.AddWithValue("@STATUS_LIQUIDADO", padeTo.STATUS_LIQUIDADO);
            //cmd.Parameters.AddWithValue("@OBSERVACION", padeTo.OBSERVACION);
            cmd.Parameters.AddWithValue("@COD_USU_MOD", padeTo.COD_USU_MOD);
            cmd.Parameters.AddWithValue("@FECHA_MOD", padeTo.FECHA_MOD);
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
        public bool validaCierrePeriodoAdelantoGeneradoDAL(pAdelantoTo padeTo, ref bool val, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("VALIDA_TODOS_ADELANTOS_GENERADOS_DEL_PERIODO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FE_AÑO", padeTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", padeTo.FE_MES);
            try
            {
                conn.Open();
                val = Convert.ToBoolean(cmd.ExecuteScalar());
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
