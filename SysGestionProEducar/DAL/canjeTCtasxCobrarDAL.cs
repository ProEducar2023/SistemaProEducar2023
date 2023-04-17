using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class canjeTCtasxCobrarDAL
    {
        SqlConnection conn;
        public canjeTCtasxCobrarDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerCanjeDetalleDAL(canjeTCtasxCobrarTo ctcxTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_CANJE_TCTAS_DET", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", ctcxTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", ctcxTo.NRO_CONTRATO);
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
        public bool insertarCanjeTCtasxCobrarDAL(canjeTCtasxCobrarTo ctcxTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_CANJEA_T_CTAS_X_COBRAR", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", ctcxTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_CLASE", ctcxTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", ctcxTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@FE_AÑO", ctcxTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", ctcxTo.FE_MES);
            cmd.Parameters.AddWithValue("@COD_PER", ctcxTo.COD_PER);
            cmd.Parameters.AddWithValue("@COD_DOC", ctcxTo.COD_DOC);
            cmd.Parameters.AddWithValue("@NRO_DOC", ctcxTo.NRO_DOC);
            cmd.Parameters.AddWithValue("@FECHA_CONTRATO", ctcxTo.FECHA_CONTRATO);
            cmd.Parameters.AddWithValue("@FECHA_DOC", ctcxTo.FECHA_DOC);
            if (ctcxTo.FECHA_VEN != null)
                cmd.Parameters.AddWithValue("@FECHA_VEN", ctcxTo.FECHA_VEN);
            else
                cmd.Parameters.AddWithValue("@FECHA_VEN", DBNull.Value);
            cmd.Parameters.AddWithValue("@COD_P_COBRANZA", ctcxTo.COD_P_COBRANZA);
            cmd.Parameters.AddWithValue("@COD_COBRADOR", ctcxTo.COD_COBRADOR);
            cmd.Parameters.AddWithValue("@NRO_PLANILLA", ctcxTo.NRO_PLANILLA);
            //cmd.Parameters.AddWithValue("@FECHA_PLANILLA", ctcxTo.FECHA_PLANILLA);
            cmd.Parameters.AddWithValue("@FECHA_PLANILLA", DBNull.Value);
            cmd.Parameters.AddWithValue("@COD_D_H", ctcxTo.COD_D_H);
            cmd.Parameters.AddWithValue("@COD_MONEDA", ctcxTo.COD_MONEDA);
            cmd.Parameters.AddWithValue("@TIPO_CAMBIO", ctcxTo.TIPO_CAMBIO);
            cmd.Parameters.AddWithValue("@IMP_DOC", ctcxTo.IMP_DOC);
            cmd.Parameters.AddWithValue("@OBSERVACION", ctcxTo.OBSERVACION);
            cmd.Parameters.AddWithValue("@TIPO_OPE", ctcxTo.TIPO_OPE);
            cmd.Parameters.AddWithValue("@NRO_LETRA", ctcxTo.NRO_LETRA);
            cmd.Parameters.AddWithValue("@TOTAL_LETRA", ctcxTo.TOTAL_LETRA);
            cmd.Parameters.AddWithValue("@TIPO_PLA_ORIGEN", ctcxTo.TIPO_PLA_ORIGEN);
            cmd.Parameters.AddWithValue("@TIPO_PLA_COBRANZA", ctcxTo.TIPO_PLA_COBRANZA);
            cmd.Parameters.AddWithValue("@COD_CONCEPTO", ctcxTo.COD_CONCEPTO);
            cmd.Parameters.AddWithValue("@COD_USU_CREA", ctcxTo.COD_USU_CREA);
            cmd.Parameters.AddWithValue("@FECHA_CREA", ctcxTo.FECHA_CREA);
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
        public bool insertarCanjeTCtasxCobrarRecepcionPlanillaDAL(canjeTCtasxCobrarTo ctcxTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_CANJEA_T_CTAS_X_COBRAR", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", ctcxTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_CLASE", ctcxTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", ctcxTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@FE_AÑO", ctcxTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", ctcxTo.FE_MES);
            cmd.Parameters.AddWithValue("@COD_PER", ctcxTo.COD_PER);
            cmd.Parameters.AddWithValue("@COD_DOC", ctcxTo.COD_DOC);
            cmd.Parameters.AddWithValue("@NRO_DOC", ctcxTo.NRO_DOC);
            cmd.Parameters.AddWithValue("@FECHA_CONTRATO", ctcxTo.FECHA_CONTRATO);
            cmd.Parameters.AddWithValue("@FECHA_DOC", ctcxTo.FECHA_DOC);
            if (ctcxTo.FECHA_VEN != null)
                cmd.Parameters.AddWithValue("@FECHA_VEN", ctcxTo.FECHA_VEN);
            else
                cmd.Parameters.AddWithValue("@FECHA_VEN", DBNull.Value);
            cmd.Parameters.AddWithValue("@COD_P_COBRANZA", ctcxTo.COD_P_COBRANZA);
            cmd.Parameters.AddWithValue("@COD_COBRADOR", ctcxTo.COD_COBRADOR);
            cmd.Parameters.AddWithValue("@NRO_PLANILLA", ctcxTo.NRO_PLANILLA);
            cmd.Parameters.AddWithValue("@FECHA_PLANILLA", ctcxTo.FECHA_PLANILLA);
            //cmd.Parameters.AddWithValue("@FECHA_PLANILLA", DBNull.Value);
            cmd.Parameters.AddWithValue("@COD_D_H", ctcxTo.COD_D_H);
            cmd.Parameters.AddWithValue("@COD_MONEDA", ctcxTo.COD_MONEDA);
            cmd.Parameters.AddWithValue("@TIPO_CAMBIO", ctcxTo.TIPO_CAMBIO);
            cmd.Parameters.AddWithValue("@IMP_DOC", ctcxTo.IMP_DOC);
            cmd.Parameters.AddWithValue("@OBSERVACION", ctcxTo.OBSERVACION);
            cmd.Parameters.AddWithValue("@TIPO_OPE", ctcxTo.TIPO_OPE);
            cmd.Parameters.AddWithValue("@NRO_LETRA", ctcxTo.NRO_LETRA);
            cmd.Parameters.AddWithValue("@TOTAL_LETRA", ctcxTo.TOTAL_LETRA);
            cmd.Parameters.AddWithValue("@TIPO_PLA_ORIGEN", ctcxTo.TIPO_PLA_ORIGEN);
            cmd.Parameters.AddWithValue("@TIPO_PLA_COBRANZA", ctcxTo.TIPO_PLA_COBRANZA);
            cmd.Parameters.AddWithValue("@COD_CONCEPTO", ctcxTo.COD_CONCEPTO);
            cmd.Parameters.AddWithValue("@COD_USU_CREA", ctcxTo.COD_USU_CREA);
            cmd.Parameters.AddWithValue("@FECHA_CREA", ctcxTo.FECHA_CREA);
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
        public DataTable obtenerKardexporContratoDAL(canjeTCtasxCobrarTo ctcxTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_KARDEX_X_CONTRATO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", ctcxTo.NRO_CONTRATO);

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
        public DataTable obtenerTctasxKardexContratoDAL(canjeTCtasxCobrarTo ctcxTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_TCTAS_KARDEX_X_CONTRATO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", ctcxTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_CLASE", ctcxTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", ctcxTo.NRO_CONTRATO);

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
        public decimal obtenerMontoPagadoxContratoDAL(canjeTCtasxCobrarTo ctcxTo, ref string errMensaje)
        {
            decimal suma = 0;
            SqlCommand cmd = new SqlCommand("MOSTRAR_MONTO_PAGADO_X_CONTRATO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", ctcxTo.NRO_CONTRATO);
            try
            {
                conn.Open();
                //suma = Convert.ToDecimal(cmd.ExecuteScalar());
                suma = decimal.TryParse(cmd.ExecuteScalar().ToString(), out suma) ? Convert.ToDecimal(cmd.ExecuteScalar()) : 0;
            }
            catch (Exception e)
            {
                errMensaje = e.Message;
                suma = 0;
            }
            finally
            {
                conn.Close();
            }
            return suma;
        }
        public bool modifica_T_Ctas_por_Transferencia_DAL(canjeTCtasxCobrarTo ctcxTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_TCTAS_COBRAR_TRANSFERENCIA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", ctcxTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@NRO_LETRA", ctcxTo.NRO_LETRA);
            cmd.Parameters.AddWithValue("@TIPO_PLA_COBRANZA", ctcxTo.TIPO_PLA_COBRANZA);
            cmd.Parameters.AddWithValue("@COD_USU_MOD", ctcxTo.COD_USU_MOD);
            cmd.Parameters.AddWithValue("@FECHA_MOD", ctcxTo.FECHA_MOD);
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
        public decimal obtenerSumaImporteComprometidosDAL(canjeTCtasxCobrarTo ctcxTo, ref string errMensaje)
        {
            decimal suma = -1;
            SqlCommand cmd = new SqlCommand("SUMA_IMPORTES_COMPROMETIDOS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", ctcxTo.NRO_CONTRATO);
            try
            {
                conn.Open();
                //suma = decimal.TryParse(cmd.ExecuteScalar().ToString(), out suma) ? Convert.ToDecimal(cmd.ExecuteScalar()) : 0;
                suma = Convert.ToDecimal(cmd.ExecuteScalar());//el procedure tiene isnull y si no hay coincidencia devuelve 0
            }
            catch (Exception e)
            {
                errMensaje = e.Message;
                suma = -1;
            }
            finally
            {
                conn.Close();
            }
            return suma;
        }
        public bool modificarPCtasxCambioPtoCobDAL(canjeTCtasxCobrarTo ctcxTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_TCTAS_COBRAR_X_CAMBIO_PTO_COB", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PER", ctcxTo.COD_PER);
            cmd.Parameters.AddWithValue("@COD_USU_MOD", ctcxTo.COD_USU_MOD);
            cmd.Parameters.AddWithValue("@FECHA_MOD", ctcxTo.FECHA_MOD);
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
        public bool modificarTCtasxRecepcionPlanillaDAL(canjeTCtasxCobrarTo ctcxTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_TCTAS_COBRAR_X_RECEPCION_PLLA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", ctcxTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_CLASE", ctcxTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", ctcxTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@NRO_DOC", ctcxTo.NRO_DOC);
            cmd.Parameters.AddWithValue("@COD_USU_MOD", ctcxTo.COD_USU_CREA);
            cmd.Parameters.AddWithValue("@FECHA_MOD", ctcxTo.FECHA_CREA);
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
        public bool eliminarTCtasCobrarDAL(canjeTCtasxCobrarTo ctcxTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINA_TCTAS_COBRAR", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", ctcxTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_CLASE", ctcxTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", ctcxTo.NRO_CONTRATO);

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
