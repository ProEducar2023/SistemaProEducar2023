using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class planillaCabeceraOtrasDevDsctosDAL
    {
        SqlConnection conn;
        public planillaCabeceraOtrasDevDsctosDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerPlanillaCabeceraOtrasDevDsctosPendientesDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_PLANILLA_CABECERA_OTRAS_DEV_DSCTOS_PENDIENTES", conn);
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
        public DataTable obtenerPlanillaCabeceraOtrasDevDsctosDAL(planillaCabeceraOtrasDevDsctosTo plcTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_PLANILLA_CABECERA_OTRAS_DEV_DSCTOS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FE_AÑO", plcTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", plcTo.FE_MES);
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
        public DataTable obtenerPlanillaCabeceraDescuentoDirectaDAL(planillaCabeceraOtrasDevDsctosTo plcTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_PLANILLA_CABECERA_DSCTO_DIRECTA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FE_AÑO", plcTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", plcTo.FE_MES);
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

        public bool insertarPlanillaCabeceraOtrasDevDsctosDAL(planillaCabeceraOtrasDevDsctosTo plcTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_PLANILLA_CABECERA_OTRAS_DEV_DSCTOS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_PLANILLA_DOC", plcTo.NRO_PLANILLA_DOC);
            cmd.Parameters.AddWithValue("@COD_INSTITUCION", plcTo.COD_INSTITUCION);
            cmd.Parameters.AddWithValue("@COD_CANAL_DSCTO", plcTo.COD_CANAL_DSCTO);
            cmd.Parameters.AddWithValue("@FE_AÑO", plcTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", plcTo.FE_MES);
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", plcTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@FECHA_PLANILLA_DOC", plcTo.FECHA_PLANILLA_DOC);
            cmd.Parameters.AddWithValue("@COD_PER", plcTo.COD_PER);
            cmd.Parameters.AddWithValue("@DESC_PER", plcTo.DESC_PER);
            cmd.Parameters.AddWithValue("@DNI", plcTo.DNI);
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", plcTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@TIPO_PLANILLA_DOC", plcTo.TIPO_PLANILLA_DOC);
            cmd.Parameters.AddWithValue("@IMPORTE_TOTAL", plcTo.IMPORTE_TOTAL);
            cmd.Parameters.AddWithValue("@OBSERVACIONES", plcTo.OBSERVACIONES);
            cmd.Parameters.AddWithValue("@STATUS_CIERRE", plcTo.STATUS_CIERRE);
            cmd.Parameters.AddWithValue("@COD_CREA", plcTo.COD_CREA);
            cmd.Parameters.AddWithValue("@FECHA_CREA", plcTo.FECHA_CREA);
            cmd.Parameters.AddWithValue("@NRO_LETRA", plcTo.NRO_LETRA);
            cmd.Parameters.AddWithValue("@STATUS_COMPROM", plcTo.STATUS_COMPROM);
            cmd.Parameters.AddWithValue("@COD_GESTOR", plcTo.COD_GESTOR);
            cmd.Parameters.AddWithValue("@COD_MOTIVO_NO_DESCONTADO", plcTo.COD_MOTIVO_NO_DESCONTADO);
            cmd.Parameters.AddWithValue("@COD_UBICACION", plcTo.COD_UBICACION);
            cmd.Parameters.AddWithValue("@COD_GRUPO_UBICACION", DBNull.Value);
            cmd.Parameters.AddWithValue("@COD_SUB_UBICACION", DBNull.Value);
            cmd.Parameters.AddWithValue("@ORIG_OTRAS_PLLAS", plcTo.ORIG_OTRAS_PLLAS);
            cmd.Parameters.AddWithValue("@COD_AREA_TRABAJO", plcTo.COD_AREA_TRABAJO);
            cmd.Parameters.AddWithValue("@COD_PTO_COB", plcTo.COD_PTO_COB);
            if (plcTo.FECHA_IDENTIFICACION_PAGO is null)
                cmd.Parameters.AddWithValue("@FECHA_IDENTIFICACION_PAGO", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@FECHA_IDENTIFICACION_PAGO", plcTo.FECHA_IDENTIFICACION_PAGO);
            if (string.IsNullOrEmpty(plcTo.TIPO_VENTA))
                cmd.Parameters.AddWithValue("@TIPO_VENTA", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@TIPO_VENTA", plcTo.TIPO_VENTA);

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
        public bool modificarPlanillaCabeceraOtrasDevDsctosDAL(planillaCabeceraOtrasDevDsctosTo plcTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_PLANILLA_CABECERA_OTRAS_DEV_DSCTOS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_PLANILLA_DOC", plcTo.NRO_PLANILLA_DOC);
            cmd.Parameters.AddWithValue("@COD_INSTITUCION", plcTo.COD_INSTITUCION);
            cmd.Parameters.AddWithValue("@COD_CANAL_DSCTO", plcTo.COD_CANAL_DSCTO);
            cmd.Parameters.AddWithValue("@FE_AÑO", plcTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", plcTo.FE_MES);
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", plcTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@FECHA_PLANILLA_DOC", plcTo.FECHA_PLANILLA_DOC);
            cmd.Parameters.AddWithValue("@COD_PER", plcTo.COD_PER);
            cmd.Parameters.AddWithValue("@DESC_PER", plcTo.DESC_PER);
            cmd.Parameters.AddWithValue("@DNI", plcTo.DNI);
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", plcTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@TIPO_PLANILLA_DOC", plcTo.TIPO_PLANILLA_DOC);
            cmd.Parameters.AddWithValue("@IMPORTE_TOTAL", plcTo.IMPORTE_TOTAL);
            cmd.Parameters.AddWithValue("@OBSERVACIONES", plcTo.OBSERVACIONES);
            cmd.Parameters.AddWithValue("@STATUS_CIERRE", plcTo.STATUS_CIERRE);
            cmd.Parameters.AddWithValue("@COD_MOD", plcTo.COD_CREA);
            cmd.Parameters.AddWithValue("@FECHA_MOD", plcTo.FECHA_CREA);
            cmd.Parameters.AddWithValue("@NRO_LETRA", plcTo.NRO_LETRA);
            cmd.Parameters.AddWithValue("@STATUS_COMPROM", plcTo.STATUS_COMPROM);
            cmd.Parameters.AddWithValue("@COD_GESTOR", plcTo.COD_GESTOR);
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
        public bool eliminarPlanillaCabeceraOtrasDevDsctosDAL(planillaCabeceraOtrasDevDsctosTo plcTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_PLANILLA_CABECERA_OTRAS_DEV_DSCTOS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_PLANILLA_DOC", plcTo.NRO_PLANILLA_DOC);
            cmd.Parameters.AddWithValue("@COD_INSTITUCION", plcTo.COD_INSTITUCION);
            cmd.Parameters.AddWithValue("@COD_CANAL_DSCTO", plcTo.COD_CANAL_DSCTO);
            cmd.Parameters.AddWithValue("@FE_AÑO", plcTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", plcTo.FE_MES);
            cmd.Parameters.AddWithValue("@TIPO_PLANILLA_DOC", plcTo.TIPO_PLANILLA_DOC);
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
        public bool aprueba_Actualiza_I_PLANILLA_OTRAS_DEV_DSCTOS_X_CIERRE_DAL(planillaCabeceraOtrasDevDsctosTo plcTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ACTUALIZA_PLANILLA_CABECERA_OTRAS_DEV_DSCTOS_X_CIERRE", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_PLANILLA_DOC", plcTo.NRO_PLANILLA_DOC);
            cmd.Parameters.AddWithValue("@COD_INSTITUCION", plcTo.COD_INSTITUCION);
            cmd.Parameters.AddWithValue("@COD_CANAL_DSCTO", plcTo.COD_CANAL_DSCTO);
            cmd.Parameters.AddWithValue("@FE_AÑO", plcTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", plcTo.FE_MES);
            cmd.Parameters.AddWithValue("@TIPO_PLANILLA_DOC", plcTo.TIPO_PLANILLA_DOC);
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
    }
}
