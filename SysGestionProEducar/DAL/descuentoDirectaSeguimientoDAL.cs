using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class descuentoDirectaSeguimientoDAL
    {
        SqlConnection conn;
        public descuentoDirectaSeguimientoDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerDescuentoDirectaSeguimientoDAL(descuentoDirectaSeguimientoTo dsTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", dsTo.NRO_CONTRATO);
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
        public bool ingresarDescuentoDirectaSeguimientoDAL(descuentoDirectaSeguimientoTo dsTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_DESCUENTO_DIRECTA_SEGUIMIENTO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", dsTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@COD_PERSONA", dsTo.COD_PERSONA);
            cmd.Parameters.AddWithValue("@COD_GESTOR", dsTo.COD_GESTOR);
            cmd.Parameters.AddWithValue("@COD_MOTIVO_LLAMADA", dsTo.COD_MOTIVO_LLAMADA);
            cmd.Parameters.AddWithValue("@FECHA_OPERACION_LLAMADA", dsTo.FECHA_OPERACION_LLAMADA);
            cmd.Parameters.AddWithValue("@FE_AÑO", dsTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", dsTo.FE_MES);
            cmd.Parameters.AddWithValue("@FECHA_COMPROMISO_PAGO", dsTo.FECHA_COMPROMISO_PAGO);
            cmd.Parameters.AddWithValue("@OBSERVACIONES", dsTo.OBSERVACIONES);
            cmd.Parameters.AddWithValue("@IMPORTE_PAGO", dsTo.IMPORTE_PAGO);
            if (dsTo.STATUS_CONFIRMACION_PAGO == null)
                cmd.Parameters.AddWithValue("@STATUS_CONFIRMACION_PAGO", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@STATUS_CONFIRMACION_PAGO", dsTo.STATUS_CONFIRMACION_PAGO);
            if (dsTo.FECHA_DEPOSITO == null)
                cmd.Parameters.AddWithValue("@FECHA_DEPOSITO", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@FECHA_DEPOSITO", dsTo.FECHA_DEPOSITO);
            cmd.Parameters.AddWithValue("@NRO_OPERACION", dsTo.NRO_OPERACION);
            cmd.Parameters.AddWithValue("@INSTITUCION_BANCARIA", dsTo.INSTITUCION_BANCARIA);
            //cmd.Parameters.AddWithValue("@NRO_CTA_BANCARIA", dsTo.NRO_CTA_BANCARIA);
            //cmd.Parameters.AddWithValue("@OBS_DATOS_BANCARIOS", dsTo.OBS_DATOS_BANCARIOS);
            cmd.Parameters.AddWithValue("@COD_USU", dsTo.COD_USU);
            cmd.Parameters.AddWithValue("@FEC_COD_USU", dsTo.FEC_COD_USU);
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
        public bool modificarDescuentoDirectaSeguimientoDAL(descuentoDirectaSeguimientoTo dsTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", dsTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@COD_PERSONA", dsTo.COD_PERSONA);
            cmd.Parameters.AddWithValue("@COD_GESTOR", dsTo.COD_GESTOR);
            cmd.Parameters.AddWithValue("@COD_MOTIVO_LLAMADA", dsTo.COD_MOTIVO_LLAMADA);
            cmd.Parameters.AddWithValue("@FECHA_OPERACION_LLAMADA", dsTo.FECHA_OPERACION_LLAMADA);
            cmd.Parameters.AddWithValue("@FECHA_COMPROMISO_PAGO", dsTo.FECHA_COMPROMISO_PAGO);
            cmd.Parameters.AddWithValue("@OBSERVACIONES", dsTo.OBSERVACIONES);
            cmd.Parameters.AddWithValue("@IMPORTE_PAGO", dsTo.IMPORTE_PAGO);
            cmd.Parameters.AddWithValue("@STATUS_CONFIRMACION_PAGO", dsTo.STATUS_CONFIRMACION_PAGO);
            cmd.Parameters.AddWithValue("@FECHA_DEPOSITO", dsTo.FECHA_DEPOSITO);
            cmd.Parameters.AddWithValue("@NRO_OPERACION", dsTo.NRO_OPERACION);
            cmd.Parameters.AddWithValue("@INSTITUCION_BANCARIA", dsTo.INSTITUCION_BANCARIA);
            cmd.Parameters.AddWithValue("@NRO_CTA_BANCARIA", dsTo.NRO_CTA_BANCARIA);
            cmd.Parameters.AddWithValue("@OBS_DATOS_BANCARIOS", dsTo.OBS_DATOS_BANCARIOS);
            cmd.Parameters.AddWithValue("@COD_USU", dsTo.COD_USU);
            cmd.Parameters.AddWithValue("@FEC_COD_USU", dsTo.FEC_COD_USU);
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
        public bool eliminarDescuentoDirectaxLlamadasDAL(descuentoDirectaSeguimientoTo dsTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_I_LLAMADAS_SEGUIMIENTO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", dsTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@COD_PERSONA", dsTo.COD_PERSONA);
            cmd.Parameters.AddWithValue("@COD_GESTOR", dsTo.COD_GESTOR);
            cmd.Parameters.AddWithValue("@COD_MOTIVO_LLAMADA", dsTo.COD_MOTIVO_LLAMADA_ORIGEN);
            cmd.Parameters.AddWithValue("@FECHA_OPERACION_LLAMADA", dsTo.FECHA_OPERACION_LLAMADA);
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
        public DataTable obtenerContratosparaVerificarLlamadasDAL(descuentoDirectaSeguimientoTo dsTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_CONTRATOS_PARA_VERIFICACION_LLAMADAS", conn);
            cmd.Parameters.AddWithValue("@COD_MOTIVO_LLAMADA", dsTo.COD_MOTIVO_LLAMADA);
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
        public bool modificarDescuentoDirectaxSeguimientoVerificacionDAL(descuentoDirectaSeguimientoTo dsTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_I_LLAMADA_SEGUIMIENTO_X_VERIFICACION", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", dsTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@COD_PERSONA", dsTo.COD_PERSONA);
            cmd.Parameters.AddWithValue("@COD_GESTOR", dsTo.COD_GESTOR);
            cmd.Parameters.AddWithValue("@COD_MOTIVO_LLAMADA", dsTo.COD_MOTIVO_LLAMADA_ORIGEN);
            cmd.Parameters.AddWithValue("@COD_MOD", dsTo.COD_USU);
            cmd.Parameters.AddWithValue("@FEC_COD_MOD", dsTo.FEC_COD_USU);
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
        public DataTable obtener_llamadas_seguimiento_para_R_PlanillaDAL(descuentoDirectaSeguimientoTo dsTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_LLAMADAS_SEGUIMIENTO_PARA_R_PLANILLA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MESES_MOROSIDAD", dsTo.MESES_MOROSIDAD);
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
