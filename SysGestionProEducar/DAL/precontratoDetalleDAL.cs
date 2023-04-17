using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class precontratoDetalleDAL
    {
        SqlConnection conn;
        public precontratoDetalleDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerPreContratoDetalleDAL(precontratoDetalleTo pcdTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_DETALLES_T_PRESUPUESTO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_CLASE", pcdTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", pcdTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_PER", pcdTo.COD_PER);
            cmd.Parameters.AddWithValue("@NRO_PRESUPUESTO", pcdTo.NRO_PRESUPUESTO);
            cmd.Parameters.AddWithValue("@FE_AÑO", pcdTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", pcdTo.FE_MES);
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
        public bool insertarPreContratoDetalleDAL(precontratoDetalleTo pcdTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("", pcdTo.COD_CLASE);

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
        public bool actualizaPreContratoDetalleCantidadAtendDAL(precontratoDetalleTo pcdTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ACTUALIZA_PRECONTRATO_DETALLE_CANTIDAD_ATEND", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_PRESUPUESTO", pcdTo.NRO_PRESUPUESTO);

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
        public DataTable obtenerPreContratoCabeceraparaCrearContratoDetalleDAL(precontratoDetalleTo pcdTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_PRECONTRATO_CABECERA_PARA_CREAR_CONTRATO_DETALLE", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", pcdTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_CLASE", pcdTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_PER", pcdTo.COD_PER);
            cmd.Parameters.AddWithValue("@NRO_PRESUPUESTO", pcdTo.NRO_PRESUPUESTO);
            cmd.Parameters.AddWithValue("@FE_AÑO", pcdTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", pcdTo.FE_MES);
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
        public DataTable obtenerPreContratoDetalleparaDesaprobarContratoDAL(precontratoDetalleTo pcdTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_PRECONTRATO_DETALLE_PARA_DESAPROBAR_CONTRATO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", pcdTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_CLASE", pcdTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_PER", pcdTo.COD_PER);
            cmd.Parameters.AddWithValue("@NRO_PRESUPUESTO", pcdTo.NRO_PRESUPUESTO);
            cmd.Parameters.AddWithValue("@FE_AÑO", pcdTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", pcdTo.FE_MES);
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
    }
}
