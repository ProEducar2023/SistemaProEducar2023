using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class resumenTPlanillaDevolucionDAL
    {
        SqlConnection conn;
        public resumenTPlanillaDevolucionDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerResumenTPlanillaDevolucionDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("", conn);
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
        public bool insertarResumenTPlanillaDevolucionDAL(resumenTPlanillaDevolucionTo rtpTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_RESUMEN_TPLANILLA_DEVOLUCION", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_PLANILLA_DOC", rtpTo.NRO_PLANILLA_DOC);
            cmd.Parameters.AddWithValue("@COD_INSTITUCION", rtpTo.COD_INSTITUCION);
            cmd.Parameters.AddWithValue("@COD_PTO_COB_CONSOLIDADO", rtpTo.COD_PTO_COB_CONSOLIDADO);
            cmd.Parameters.AddWithValue("@COD_CANAL_DSCTO", rtpTo.COD_CANAL_DSCTO);
            cmd.Parameters.AddWithValue("@FE_AÑO", rtpTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", rtpTo.FE_MES);
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", rtpTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@FECHA_PLANILLA_DOC", rtpTo.FECHA_PLANILLA_DOC);
            cmd.Parameters.AddWithValue("@COD_DOCUMENTO_PAGO", rtpTo.COD_DOCUMENTO_PAGO);
            cmd.Parameters.AddWithValue("@NRO_DOCUMENTO_PAGO", rtpTo.NRO_DOCUMENTO_PAGO);
            if (rtpTo.FECHA_PAGO == null)
                cmd.Parameters.AddWithValue("@FECHA_PAGO", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@FECHA_PAGO", rtpTo.FECHA_PAGO);
            cmd.Parameters.AddWithValue("@OBSERVACIONES", rtpTo.OBSERVACIONES);
            cmd.Parameters.AddWithValue("@TIPO_PLANILLA", rtpTo.TIPO_PLANILLA);
            cmd.Parameters.AddWithValue("@COD_MONEDA", rtpTo.COD_MONEDA);
            cmd.Parameters.AddWithValue("@IMP_DOC", rtpTo.IMP_DOC);
            cmd.Parameters.AddWithValue("@COD_D_H", rtpTo.COD_D_H);
            cmd.Parameters.AddWithValue("@TIPO_OPE", rtpTo.TIPO_OPE);
            cmd.Parameters.AddWithValue("@COD_CREACION", rtpTo.COD_CREACION);
            cmd.Parameters.AddWithValue("@FECHA_CREACION", rtpTo.FECHA_CREACION);

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
        public bool modificarResumenTPlanillaDevolucionDAL(resumenTPlanillaDevolucionTo rtpTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_RESUMEN_TPLANILLA_DEVOLUCION", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_PLANILLA_DOC", rtpTo.NRO_PLANILLA_DOC);
            cmd.Parameters.AddWithValue("@COD_INSTITUCION", rtpTo.COD_INSTITUCION);
            cmd.Parameters.AddWithValue("@COD_PTO_COB_CONSOLIDADO", rtpTo.COD_PTO_COB_CONSOLIDADO);
            cmd.Parameters.AddWithValue("@COD_CANAL_DSCTO", rtpTo.COD_CANAL_DSCTO);
            cmd.Parameters.AddWithValue("@FE_AÑO", rtpTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", rtpTo.FE_MES);
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", rtpTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@FECHA_PLANILLA_DOC", rtpTo.FECHA_PLANILLA_DOC);
            cmd.Parameters.AddWithValue("@COD_DOCUMENTO_PAGO", rtpTo.COD_DOCUMENTO_PAGO);
            cmd.Parameters.AddWithValue("@NRO_DOCUMENTO_PAGO", rtpTo.NRO_DOCUMENTO_PAGO);
            cmd.Parameters.AddWithValue("@FECHA_PAGO", rtpTo.FECHA_PAGO);
            cmd.Parameters.AddWithValue("@OBSERVACIONES", rtpTo.OBSERVACIONES);
            cmd.Parameters.AddWithValue("@TIPO_PLANILLA", rtpTo.TIPO_PLANILLA);
            cmd.Parameters.AddWithValue("@COD_MONEDA", rtpTo.COD_MONEDA);
            cmd.Parameters.AddWithValue("@IMP_DOC", rtpTo.IMP_DOC);
            cmd.Parameters.AddWithValue("@COD_D_H", rtpTo.COD_D_H);
            cmd.Parameters.AddWithValue("@TIPO_OPE", rtpTo.TIPO_OPE);
            cmd.Parameters.AddWithValue("@COD_MODIFICACION", rtpTo.COD_MODIFICACION);
            cmd.Parameters.AddWithValue("@FECHA_MODIFICACION", rtpTo.FECHA_MODIFICACION);

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
