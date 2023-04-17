using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class devTCtasCobrarDAL
    {
        SqlConnection conn;
        public devTCtasCobrarDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerDevTCtasCobrarDAL(devTCtasCobrarTo dtcTo)
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
        public bool insertarDevTCtasCobrarDAL(devTCtasCobrarTo dtcTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_DEV_TCTAS_COBRAR", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_PLANILLA_COB", dtcTo.NRO_PLANILLA_COB);
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", dtcTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_CLASE", dtcTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", dtcTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@FE_AÑO", dtcTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", dtcTo.FE_MES);
            cmd.Parameters.AddWithValue("@COD_PER", dtcTo.COD_PER);
            cmd.Parameters.AddWithValue("@DESC_PER", dtcTo.DESC_PER);
            cmd.Parameters.AddWithValue("@COD_DOC", dtcTo.COD_DOC);
            cmd.Parameters.AddWithValue("@NRO_DOC", dtcTo.NRO_DOC);
            if (dtcTo.FECHA_CONTRATO == null)
                cmd.Parameters.AddWithValue("@FECHA_CONTRATO", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@FECHA_CONTRATO", dtcTo.FECHA_CONTRATO);
            cmd.Parameters.AddWithValue("@FECHA_DOC", dtcTo.FECHA_DOC);
            if (dtcTo.FECHA_VEN == null)
                cmd.Parameters.AddWithValue("FECHA_VEN", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@FECHA_VEN", dtcTo.FECHA_VEN);
            cmd.Parameters.AddWithValue("@COD_P_COBRANZA", dtcTo.COD_P_COBRANZA);
            cmd.Parameters.AddWithValue("@COD_COBRADOR", dtcTo.COD_COBRADOR);
            cmd.Parameters.AddWithValue("@NRO_PLANILLA", dtcTo.NRO_PLANILLA);
            cmd.Parameters.AddWithValue("@FECHA_PLANILLA", dtcTo.FECHA_PLANILLA);
            cmd.Parameters.AddWithValue("@COD_MOTIVO_NO_DESCONTADO", dtcTo.COD_MOTIVO_NO_DESCONTADO);
            cmd.Parameters.AddWithValue("@COD_D_H", dtcTo.COD_D_H);
            cmd.Parameters.AddWithValue("@COD_MONEDA", dtcTo.COD_MONEDA);
            cmd.Parameters.AddWithValue("@TIPO_CAMBIO", dtcTo.TIPO_CAMBIO);
            cmd.Parameters.AddWithValue("@IMP_DOC", dtcTo.IMP_DOC);
            cmd.Parameters.AddWithValue("@OBSERVACION", dtcTo.OBSERVACION);
            cmd.Parameters.AddWithValue("@TIPO_OPE", dtcTo.TIPO_OPE);
            cmd.Parameters.AddWithValue("@NRO_LETRA", dtcTo.NRO_LETRA);
            cmd.Parameters.AddWithValue("@TOTAL_LETRA", dtcTo.TOTAL_LETRA);
            cmd.Parameters.AddWithValue("@COD_CONCEPTO", dtcTo.COD_CONCEPTO);
            cmd.Parameters.AddWithValue("@TIPO_PLA_ORIGEN", dtcTo.TIPO_PLA_ORIGEN);
            cmd.Parameters.AddWithValue("@TIPO_PLA_COBRANZA", dtcTo.TIPO_PLA_COBRANZA);
            cmd.Parameters.AddWithValue("@TIPO_PLANILLA_ORIGEN", dtcTo.TIPO_PLANILLA_ORIGEN);
            cmd.Parameters.AddWithValue("@COD_USU_CREA", dtcTo.COD_USU_CREA);
            cmd.Parameters.AddWithValue("@FECHA_CREA", dtcTo.FECHA_CREA);
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
        public bool modificarDevTCtasCobrarDAL(devTCtasCobrarTo dtcTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_DEV_TCTAS_COBRAR", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_PLANILLA_COB", dtcTo.NRO_PLANILLA_COB);
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", dtcTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_CLASE", dtcTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", dtcTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@FE_AÑO", dtcTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", dtcTo.FE_MES);
            cmd.Parameters.AddWithValue("@COD_PER", dtcTo.COD_PER);
            cmd.Parameters.AddWithValue("@DESC_PER", dtcTo.DESC_PER);
            cmd.Parameters.AddWithValue("@COD_DOC", dtcTo.COD_DOC);
            cmd.Parameters.AddWithValue("@NRO_DOC", dtcTo.NRO_DOC);
            if (dtcTo.FECHA_CONTRATO == null)
                cmd.Parameters.AddWithValue("@FECHA_CONTRATO", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@FECHA_CONTRATO", dtcTo.FECHA_CONTRATO);
            cmd.Parameters.AddWithValue("@FECHA_DOC", dtcTo.FECHA_DOC);
            if (dtcTo.FECHA_VEN == null)
                cmd.Parameters.AddWithValue("FECHA_VEN", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@FECHA_VEN", dtcTo.FECHA_VEN);
            cmd.Parameters.AddWithValue("@COD_P_COBRANZA", dtcTo.COD_P_COBRANZA);
            cmd.Parameters.AddWithValue("@COD_COBRADOR", dtcTo.COD_COBRADOR);
            cmd.Parameters.AddWithValue("@NRO_PLANILLA", dtcTo.NRO_PLANILLA);
            cmd.Parameters.AddWithValue("@FECHA_PLANILLA", dtcTo.FECHA_PLANILLA);
            cmd.Parameters.AddWithValue("@COD_MOTIVO_NO_DESCONTADO", dtcTo.COD_MOTIVO_NO_DESCONTADO);
            cmd.Parameters.AddWithValue("@COD_D_H", dtcTo.COD_D_H);
            cmd.Parameters.AddWithValue("@COD_MONEDA", dtcTo.COD_MONEDA);
            cmd.Parameters.AddWithValue("@TIPO_CAMBIO", dtcTo.TIPO_CAMBIO);
            cmd.Parameters.AddWithValue("@IMP_DOC", dtcTo.IMP_DOC);
            cmd.Parameters.AddWithValue("@OBSERVACION", dtcTo.OBSERVACION);
            //cmd.Parameters.AddWithValue("@TIPO_OPE", dtcTo.TIPO_OPE);
            cmd.Parameters.AddWithValue("@NRO_LETRA", dtcTo.NRO_LETRA);
            //cmd.Parameters.AddWithValue("@TOTAL_LETRA", dtcTo.TOTAL_LETRA);
            //cmd.Parameters.AddWithValue("@COD_CONCEPTO", dtcTo.COD_CONCEPTO);
            //cmd.Parameters.AddWithValue("@TIPO_PLA_ORIGEN", dtcTo.TIPO_PLA_ORIGEN);
            cmd.Parameters.AddWithValue("@TIPO_PLA_COBRANZA", dtcTo.TIPO_PLA_COBRANZA);
            cmd.Parameters.AddWithValue("@COD_USU_MOD", dtcTo.COD_USU_MOD);
            cmd.Parameters.AddWithValue("@FECHA_MOD", dtcTo.FECHA_MOD);
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
        public bool eliminarDevTCtasCobrarDAL(devTCtasCobrarTo dtcTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_DEV_TCTAS_COBRAR", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_PLANILLA_COB", dtcTo.NRO_PLANILLA_COB);
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", dtcTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_CLASE", dtcTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", dtcTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@FE_AÑO", dtcTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", dtcTo.FE_MES);
            cmd.Parameters.AddWithValue("@COD_D_H", dtcTo.COD_D_H);
            cmd.Parameters.AddWithValue("@NRO_LETRA", dtcTo.NRO_LETRA);

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
        public DataTable obtenerDevTCtasCobrar_plla_cont_DAL(devTCtasCobrarTo dtcTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_PLLAS_EXC_CUOTA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_PLANILLA_COB", dtcTo.NRO_PLANILLA);
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", dtcTo.NRO_CONTRATO);
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
        public DataTable obtenerDevTCtasCobrar_tipo_cont_DAL(devTCtasCobrarTo dtcTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_PLLAS_EXC_CUOTA_SUSPENDIDOS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", dtcTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@TIPO_PLA_COBRANZA", dtcTo.TIPO_PLA_COBRANZA);
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
        public DataTable obtenerContratoSuspendidoxApliDevDetalleDAL(devTCtasCobrarTo dtcTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_CONTRATO_SUSPENDIDO_X_APLICAR_DEVOLVER_DETALLE", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", dtcTo.NRO_CONTRATO);
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
        public DataTable obtenerContratoSuspendidoxApliDevDAL(devTCtasCobrarTo dtcTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_CONTRATO_SUSPENDIDO_X_APLICAR_DEVOLVER", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", dtcTo.NRO_CONTRATO);
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
