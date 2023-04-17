using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class reporteTelefonicoDetalleDAL
    {
        SqlConnection conn;
        public reporteTelefonicoDetalleDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerReporteTelefonicoDetalleDAL(reporteTelefonicoDetalleTo rtdTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_REPORTE_TELEFONICO_DETALLE_MENSUAL", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SUCURSAL", rtdTo.SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_PROGRMA", rtdTo.COD_PROGRAMA);
            cmd.Parameters.AddWithValue("@TIPO_PLANILLA", rtdTo.TIPO_PLANILLA);
            cmd.Parameters.AddWithValue("@FE_MES", rtdTo.FE_MES);
            cmd.Parameters.AddWithValue("@FE_AÑO", rtdTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@COD_SEMANA", rtdTo.COD_SEMANA);

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
        public bool insertarReporteTelefonicoDetalleDAL(reporteTelefonicoDetalleTo rtdTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_REPORTE_TELEFONICO_DETALLE", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SUCURSAL", rtdTo.SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_PROGRMA", rtdTo.COD_PROGRAMA);
            cmd.Parameters.AddWithValue("@TIPO_PLANILLA", rtdTo.TIPO_PLANILLA);
            cmd.Parameters.AddWithValue("@FE_MES", rtdTo.FE_MES);
            cmd.Parameters.AddWithValue("@FE_AÑO", rtdTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@COD_SEMANA", rtdTo.COD_SEMANA);
            cmd.Parameters.AddWithValue("@COD_PER", rtdTo.COD_PER);
            cmd.Parameters.AddWithValue("@NOM_PER", rtdTo.NOM_PER);
            cmd.Parameters.AddWithValue("@FECHA", rtdTo.FECHA);
            cmd.Parameters.AddWithValue("@CANTIDAD", rtdTo.CANTIDAD);
            cmd.Parameters.AddWithValue("@MONTO", rtdTo.MONTO);
            cmd.Parameters.AddWithValue("@FECHA_CREA", rtdTo.FECHA_CREA);
            cmd.Parameters.AddWithValue("@COD_CREA", rtdTo.COD_CREA);
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
        public bool modificarReporteTelefonicoDetalleDAL(reporteTelefonicoDetalleTo rtdTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FE_MES", rtdTo.FE_MES);
            cmd.Parameters.AddWithValue("@FE_AÑO", rtdTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@COD_PER", rtdTo.COD_PER);
            cmd.Parameters.AddWithValue("@COD_SEMANA", rtdTo.COD_SEMANA);
            //cmd.Parameters.AddWithValue("@NOM_SEMANA", rtdTo.NOM_SEMANA);
            //cmd.Parameters.AddWithValue("@NRO_CONTRATO", rtdTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@MONTO", rtdTo.MONTO);
            cmd.Parameters.AddWithValue("@FECHA_CREA", rtdTo.FECHA_CREA);
            cmd.Parameters.AddWithValue("@COD_CREA", rtdTo.COD_CREA);
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
        public bool eliminarReporteTelefonicoDetalleDAL(reporteTelefonicoDetalleTo rtdTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINA_REPORTE_TELEFONICO_DETALLE", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SUCURSAL", rtdTo.SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_PROGRMA", rtdTo.COD_PROGRAMA);
            cmd.Parameters.AddWithValue("@TIPO_PLANILLA", rtdTo.TIPO_PLANILLA);
            cmd.Parameters.AddWithValue("@FE_MES", rtdTo.FE_MES);
            cmd.Parameters.AddWithValue("@FE_AÑO", rtdTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@COD_SEMANA", rtdTo.COD_SEMANA);

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
