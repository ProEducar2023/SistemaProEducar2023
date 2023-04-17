using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class facturacionVtaCabeceraDAL
    {
        SqlConnection conn;
        public facturacionVtaCabeceraDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerFacturacionCabeceraDAL(facturacionVtaCabeceraTo fvtaTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_I_FACT_CAB_VTA_TRANS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FE_AÑO", fvtaTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", fvtaTo.FE_MES);
            cmd.Parameters.AddWithValue("@TIPO_USU", fvtaTo.TIPO_USU);
            cmd.Parameters.AddWithValue("@COD_USU", fvtaTo.COD_USU);
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
        public bool insertarFacturacionCabeceraDAL(facturacionVtaCabeceraTo fvtaTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_I_FACT_CAB_VTA_TRANS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", fvtaTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_CLASE", fvtaTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_DOC", fvtaTo.COD_DOC);
            cmd.Parameters.AddWithValue("@NRO_DOC", fvtaTo.NRO_DOC);
            cmd.Parameters.AddWithValue("@COD_PER", fvtaTo.COD_PER);
            cmd.Parameters.AddWithValue("@FE_AÑO", fvtaTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", fvtaTo.FE_MES);
            cmd.Parameters.AddWithValue("@NRO_DOC_PER", fvtaTo.NRO_DOC_PER);
            cmd.Parameters.AddWithValue("@FECHA_DOC", fvtaTo.FECHA_DOC);
            cmd.Parameters.AddWithValue("@FECHA_VEN", fvtaTo.FECHA_VEN);
            cmd.Parameters.AddWithValue("@COD_MONEDA", fvtaTo.COD_MONEDA);
            cmd.Parameters.AddWithValue("@TIPO_CAMBIO", fvtaTo.TIPO_CAMBIO);
            cmd.Parameters.AddWithValue("@OBSERVACION", fvtaTo.OBSERVACION);
            cmd.Parameters.AddWithValue("@NOMBRE_PC", fvtaTo.NOMBRE_PC);
            cmd.Parameters.AddWithValue("@TIPO_ORIGEN", fvtaTo.TIPO_ORIGEN);
            cmd.Parameters.AddWithValue("@COD_D_H", fvtaTo.COD_D_H);
            cmd.Parameters.AddWithValue("@STATUS_CIERRE", fvtaTo.STATUS_CIERRE);
            cmd.Parameters.AddWithValue("@NRO_PEDIDO", fvtaTo.NRO_PEDIDO);
            cmd.Parameters.AddWithValue("@NRO_PRESUPUESTO", fvtaTo.NRO_PRESUPUESTO);
            cmd.Parameters.AddWithValue("@STATUS_PV", fvtaTo.STATUS_PV);
            cmd.Parameters.AddWithValue("@COD_VENDEDOR", fvtaTo.COD_VENDEDOR);
            cmd.Parameters.AddWithValue("@ST_TIP_VTA", fvtaTo.ST_TIP_VTA);
            //cmd.Parameters.AddWithValue("@STATUS_ANUL", fvtaTo.STATUS_ANUL);
            if (fvtaTo.COD_REF == null)
                cmd.Parameters.AddWithValue("@COD_REF", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@COD_REF", fvtaTo.COD_REF);
            if (fvtaTo.NRO_REF == null)
                cmd.Parameters.AddWithValue("@NRO_REF", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@NRO_REF", fvtaTo.NRO_REF);
            if (fvtaTo.FECHA_REF == null)
                cmd.Parameters.AddWithValue("@FECHA_REF", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@FECHA_REF", fvtaTo.FECHA_REF);
            //cmd.Parameters.AddWithValue("@NRO_SALIDA", fvtaTo.NRO_SALIDA);
            //cmd.Parameters.AddWithValue("@NRO_GUIA", fvtaTo.NRO_GUIA);
            cmd.Parameters.AddWithValue("@COD_USU_CREA", fvtaTo.COD_USU_CREA);
            cmd.Parameters.AddWithValue("@FECHA_CREA", fvtaTo.FECHA_CREA);
            cmd.Parameters.AddWithValue("@SERIE2", fvtaTo.SERIE2);
            cmd.Parameters.AddWithValue("@COD_MOT_DEV", fvtaTo.COD_MOT_DEV);
            cmd.Parameters.AddWithValue("@COD_MOV", fvtaTo.COD_MOV);
            cmd.Parameters.AddWithValue("@TIPO_FACT", fvtaTo.TIPO_FACT);
            cmd.Parameters.AddWithValue("@VALOR_DETRACCION", fvtaTo.VALOR_DETRACCION);
            cmd.Parameters.AddWithValue("@POR_DETRACCION", fvtaTo.POR_DETRACCION);
            cmd.Parameters.AddWithValue("@STATUS_FE", fvtaTo.STATUS_FE);
            cmd.Parameters.AddWithValue("@STATUS_ENVIO_FE", fvtaTo.STATUS_ENVIO_FE);
            cmd.Parameters.AddWithValue("@TIPO_OPERACION_FE", fvtaTo.TIPO_OPERACION_FE);
            cmd.Parameters.AddWithValue("@STATUS_BAJA_FE", fvtaTo.STATUS_BAJA_FE);
            cmd.Parameters.AddWithValue("@FORMA_PAGO", fvtaTo.FORMA_PAGO);
            cmd.Parameters.AddWithValue("@NRO_DIAS", fvtaTo.NRO_DIAS);
            cmd.Parameters.AddWithValue("@CONDICION_VENTA", fvtaTo.CONDICION_VENTA);
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
        public bool insertarFacturacionCabeceraDI_DAL(facturacionVtaCabeceraTo fvtaTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_I_FACT_CAB_DI_SERVICIO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", fvtaTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_CLASE", fvtaTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_DOC", fvtaTo.COD_DOC);
            cmd.Parameters.AddWithValue("@NRO_DOC", fvtaTo.NRO_DOC);
            cmd.Parameters.AddWithValue("@COD_PER", fvtaTo.COD_PER);
            cmd.Parameters.AddWithValue("@FE_AÑO", fvtaTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", fvtaTo.FE_MES);
            cmd.Parameters.AddWithValue("@NRO_DOC_PER", fvtaTo.NRO_DOC_PER);
            cmd.Parameters.AddWithValue("@FECHA_DOC", fvtaTo.FECHA_DOC);
            cmd.Parameters.AddWithValue("@FECHA_VEN", fvtaTo.FECHA_VEN);
            cmd.Parameters.AddWithValue("@COD_MONEDA", fvtaTo.COD_MONEDA);
            cmd.Parameters.AddWithValue("@TIPO_CAMBIO", fvtaTo.TIPO_CAMBIO);
            cmd.Parameters.AddWithValue("@OBSERVACION", fvtaTo.OBSERVACION);
            cmd.Parameters.AddWithValue("@NOMBRE_PC", fvtaTo.NOMBRE_PC);
            cmd.Parameters.AddWithValue("@TIPO_ORIGEN", fvtaTo.TIPO_ORIGEN);
            cmd.Parameters.AddWithValue("@COD_D_H", fvtaTo.COD_D_H);
            cmd.Parameters.AddWithValue("@STATUS_CIERRE", fvtaTo.STATUS_CIERRE);
            cmd.Parameters.AddWithValue("@NRO_PEDIDO", fvtaTo.NRO_PEDIDO);
            cmd.Parameters.AddWithValue("@NRO_PRESUPUESTO", fvtaTo.NRO_PRESUPUESTO);
            cmd.Parameters.AddWithValue("@STATUS_PV", fvtaTo.STATUS_PV);
            cmd.Parameters.AddWithValue("@COD_VENDEDOR", fvtaTo.COD_VENDEDOR);
            cmd.Parameters.AddWithValue("@ST_TIP_VTA", fvtaTo.ST_TIP_VTA);
            //cmd.Parameters.AddWithValue("@STATUS_ANUL", fvtaTo.STATUS_ANUL);
            if (fvtaTo.COD_REF == null)
                cmd.Parameters.AddWithValue("@COD_REF", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@COD_REF", fvtaTo.COD_REF);
            if (fvtaTo.NRO_REF == null)
                cmd.Parameters.AddWithValue("@NRO_REF", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@NRO_REF", fvtaTo.NRO_REF);
            if (fvtaTo.FECHA_REF == null)
                cmd.Parameters.AddWithValue("@FECHA_REF", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@FECHA_REF", fvtaTo.FECHA_REF);
            //cmd.Parameters.AddWithValue("@NRO_SALIDA", fvtaTo.NRO_SALIDA);
            //cmd.Parameters.AddWithValue("@NRO_GUIA", fvtaTo.NRO_GUIA);
            cmd.Parameters.AddWithValue("@COD_USU_CREA", fvtaTo.COD_USU_CREA);
            cmd.Parameters.AddWithValue("@FECHA_CREA", fvtaTo.FECHA_CREA);
            cmd.Parameters.AddWithValue("@SERIE2", fvtaTo.SERIE2);
            cmd.Parameters.AddWithValue("@COD_MOT_DEV", fvtaTo.COD_MOT_DEV);
            cmd.Parameters.AddWithValue("@COD_MOV", fvtaTo.COD_MOV);
            cmd.Parameters.AddWithValue("@TIPO_FACT", fvtaTo.TIPO_FACT);
            cmd.Parameters.AddWithValue("@VALOR_DETRACCION", fvtaTo.VALOR_DETRACCION);
            cmd.Parameters.AddWithValue("@POR_DETRACCION", fvtaTo.POR_DETRACCION);
            cmd.Parameters.AddWithValue("@STATUS_FE", fvtaTo.STATUS_FE);
            cmd.Parameters.AddWithValue("@STATUS_ENVIO_FE", fvtaTo.STATUS_ENVIO_FE);
            cmd.Parameters.AddWithValue("@TIPO_OPERACION_FE", fvtaTo.TIPO_OPERACION_FE);
            cmd.Parameters.AddWithValue("@STATUS_BAJA_FE", fvtaTo.STATUS_BAJA_FE);
            cmd.Parameters.AddWithValue("@FORMA_PAGO", fvtaTo.FORMA_PAGO);
            cmd.Parameters.AddWithValue("@NRO_DIAS", fvtaTo.NRO_DIAS);
            cmd.Parameters.AddWithValue("@CONDICION_VENTA", fvtaTo.CONDICION_VENTA);
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
        public bool modificarFacturacionCabeceraBLL(facturacionVtaCabeceraTo fvtaTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", fvtaTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_CLASE", fvtaTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_DOC", fvtaTo.COD_DOC);
            cmd.Parameters.AddWithValue("@NRO_DOC", fvtaTo.NRO_DOC);
            cmd.Parameters.AddWithValue("@COD_PER", fvtaTo.COD_PER);
            cmd.Parameters.AddWithValue("@FE_AÑO", fvtaTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", fvtaTo.FE_MES);
            cmd.Parameters.AddWithValue("@NRO_DOC_PER", fvtaTo.NRO_DOC_PER);
            cmd.Parameters.AddWithValue("@FECHA_DOC", fvtaTo.FECHA_DOC);
            cmd.Parameters.AddWithValue("@FECHA_VEN", fvtaTo.FECHA_VEN);
            cmd.Parameters.AddWithValue("@COD_MONEDA", fvtaTo.COD_MONEDA);
            cmd.Parameters.AddWithValue("@TIPO_CAMBIO", fvtaTo.TIPO_CAMBIO);
            cmd.Parameters.AddWithValue("@OBSERVACION", fvtaTo.OBSERVACION);
            cmd.Parameters.AddWithValue("@TIPO_ORIGEN", fvtaTo.TIPO_ORIGEN);
            cmd.Parameters.AddWithValue("@COD_D_H", fvtaTo.COD_D_H);
            cmd.Parameters.AddWithValue("@STATUS_CIERRE", fvtaTo.STATUS_CIERRE);
            cmd.Parameters.AddWithValue("@NRO_PEDIDO", fvtaTo.NRO_PEDIDO);
            cmd.Parameters.AddWithValue("@STATUS_PV", fvtaTo.STATUS_PV);
            cmd.Parameters.AddWithValue("@COD_VENDEDOR", fvtaTo.COD_VENDEDOR);
            cmd.Parameters.AddWithValue("@STATUS_ANUL", fvtaTo.STATUS_ANUL);
            cmd.Parameters.AddWithValue("@COD_REF", fvtaTo.COD_REF);
            cmd.Parameters.AddWithValue("@NRO_REF", fvtaTo.NRO_REF);
            cmd.Parameters.AddWithValue("@FECHA_REF", fvtaTo.FECHA_REF);
            cmd.Parameters.AddWithValue("@NRO_SALIDA", fvtaTo.NRO_SALIDA);
            cmd.Parameters.AddWithValue("@NRO_GUIA", fvtaTo.NRO_GUIA);
            cmd.Parameters.AddWithValue("@COD_USU_CREAL", fvtaTo.COD_USU_CREA);
            cmd.Parameters.AddWithValue("@COD_USU_MOD", fvtaTo.COD_USU_MOD);
            cmd.Parameters.AddWithValue("@FECHA_CREA", fvtaTo.FECHA_CREA);
            cmd.Parameters.AddWithValue("@FECHA_MOD", fvtaTo.FECHA_MOD);
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
        public bool anularFacturacionCabeceraDAL(facturacionVtaCabeceraTo fvtaTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ANULAR_I_FACT_VTA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", fvtaTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_CLASE", fvtaTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_DOC", fvtaTo.COD_DOC);
            cmd.Parameters.AddWithValue("@NRO_DOC", fvtaTo.NRO_DOC);
            cmd.Parameters.AddWithValue("@COD_PER", fvtaTo.COD_PER);
            cmd.Parameters.AddWithValue("@FE_AÑO", fvtaTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", fvtaTo.FE_MES);
            cmd.Parameters.AddWithValue("@TIPOUSU", fvtaTo.TIPO_USU);
            cmd.Parameters.AddWithValue("@OBS", fvtaTo.OBSERVACION);
            cmd.Parameters.AddWithValue("@USUMOD", fvtaTo.COD_USU_MOD);
            cmd.Parameters.AddWithValue("@FECMOD", fvtaTo.FECHA_MOD);
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", fvtaTo.NRO_PRESUPUESTO);
            cmd.Parameters.AddWithValue("@ST_VALOR_REFERENCIAL", fvtaTo.ST_TIP_VTA);
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
        public bool eliminarFacturacionCabeceraDAL(facturacionVtaCabeceraTo fvtaTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_I_FACT_CAB_VTA_TRANS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", fvtaTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_CLASE", fvtaTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_DOC", fvtaTo.COD_DOC);
            cmd.Parameters.AddWithValue("@NRO_DOC", fvtaTo.NRO_DOC);
            cmd.Parameters.AddWithValue("@COD_PER", fvtaTo.COD_PER);
            cmd.Parameters.AddWithValue("@FE_AÑO", fvtaTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", fvtaTo.FE_MES);
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", fvtaTo.NRO_PRESUPUESTO);
            cmd.Parameters.AddWithValue("@ST_VALOR_REFERENCIAL", fvtaTo.ST_TIP_VTA);

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
        public bool insertarBulkCopyFactVtaDetDAL(DataTable dt, ref string errMensaje)
        {
            bool flag = false;
            try
            {
                conn.Open();
                int num = dt.Rows.Count - 1;
                SqlBulkCopy copy = new SqlBulkCopy(conn);
                copy.BatchSize = num;
                copy.DestinationTableName = "dbo.[T_FACT_VTA2]";
                copy.WriteToServer(dt);
                dt.Rows.Clear();
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
        public DataTable obtenerFacturacionCabeceraparaConsultaOrdDevFactDAL(facturacionVtaCabeceraTo fvtaTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_FACT_VTA_PARA_CONSULTA_ORD_DEV_FACT", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", fvtaTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_CLASE", fvtaTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_DOC", fvtaTo.COD_DOC);
            cmd.Parameters.AddWithValue("@COD_PER", fvtaTo.COD_PER);
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

        public bool modificarActualizaFacturacionOrdDevVtaDAL(facturacionVtaCabeceraTo fvtaTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICA_I_FACT_VTA_ORDEN_DEV", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", fvtaTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_CLASE", fvtaTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@NRO_DOC", fvtaTo.NRO_DOC);
            cmd.Parameters.AddWithValue("@COD_PER", fvtaTo.COD_PER);
            cmd.Parameters.AddWithValue("@FE_AÑO", fvtaTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", fvtaTo.FE_MES);

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
        public DataTable obtenerFacturacionparaCostoTransferenciaDAL(facturacionVtaCabeceraTo fccTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_I_FACT_VTA_PENDIENTE", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_CLASE", fccTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_MOV", fccTo.COD_MOV);
            cmd.Parameters.AddWithValue("@STATUS_MOV", fccTo.STATUS_MOV);
            cmd.Parameters.AddWithValue("@FE_AÑO", fccTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", fccTo.FE_MES);

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
        public DataTable MOSTRAR_IFACT_VTA_SER_DAL(facturacionVtaCabeceraTo fccTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_IFACT_VTA_SER", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FE_AÑO", fccTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", fccTo.FE_MES);
            cmd.Parameters.AddWithValue("@TIPO_USU", fccTo.TIPO_USU);
            cmd.Parameters.AddWithValue("@COD_USU", fccTo.COD_USU);

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
        public DataTable obtenerFacturacionparaNotaCreditoDAL(facturacionVtaCabeceraTo fccTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("CARGAR_I_FACT_VTA_NOTACREDITO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", fccTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@FE_AÑO", fccTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", fccTo.FE_MES);
            cmd.Parameters.AddWithValue("@COD_DOC", fccTo.COD_DOC);
            cmd.Parameters.AddWithValue("@COD_PER", fccTo.COD_PER);
            cmd.Parameters.AddWithValue("@NRO_DOC", fccTo.NRO_DOC);

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
        public bool modificarFacturacionCabeceraDI_DAL(facturacionVtaCabeceraTo fvtaTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_I_FACT_VTA_DI_SERV", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", fvtaTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_CLASE", fvtaTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_DOC", fvtaTo.COD_DOC);
            cmd.Parameters.AddWithValue("@NRO_DOC", fvtaTo.NRO_DOC);
            cmd.Parameters.AddWithValue("@COD_PER", fvtaTo.COD_PER);
            cmd.Parameters.AddWithValue("@FE_AÑO", fvtaTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", fvtaTo.FE_MES);
            cmd.Parameters.AddWithValue("@NRO_DOC_PER", fvtaTo.NRO_DOC_PER);
            cmd.Parameters.AddWithValue("@FECHA_DOC", fvtaTo.FECHA_DOC);
            cmd.Parameters.AddWithValue("@FECHA_VEN", fvtaTo.FECHA_VEN);
            cmd.Parameters.AddWithValue("@COD_MONEDA", fvtaTo.COD_MONEDA);
            cmd.Parameters.AddWithValue("@TIPO_CAMBIO", fvtaTo.TIPO_CAMBIO);
            cmd.Parameters.AddWithValue("@OBSERVACION", fvtaTo.OBSERVACION);
            cmd.Parameters.AddWithValue("@NOMBRE_PC", fvtaTo.NOMBRE_PC);
            cmd.Parameters.AddWithValue("@TIPO_ORIGEN", fvtaTo.TIPO_ORIGEN);
            cmd.Parameters.AddWithValue("@COD_D_H", fvtaTo.COD_D_H);
            cmd.Parameters.AddWithValue("@STATUS_CIERRE", fvtaTo.STATUS_CIERRE);
            cmd.Parameters.AddWithValue("@NRO_PEDIDO", fvtaTo.NRO_PEDIDO);
            cmd.Parameters.AddWithValue("@NRO_PRESUPUESTO", fvtaTo.NRO_PRESUPUESTO);
            cmd.Parameters.AddWithValue("@STATUS_PV", fvtaTo.STATUS_PV);
            cmd.Parameters.AddWithValue("@COD_VENDEDOR", fvtaTo.COD_VENDEDOR);
            cmd.Parameters.AddWithValue("@ST_TIP_VTA", fvtaTo.ST_TIP_VTA);
            //cmd.Parameters.AddWithValue("@STATUS_ANUL", fvtaTo.STATUS_ANUL);
            if (fvtaTo.COD_REF == null)
                cmd.Parameters.AddWithValue("@COD_REF", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@COD_REF", fvtaTo.COD_REF);
            if (fvtaTo.NRO_REF == null)
                cmd.Parameters.AddWithValue("@NRO_REF", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@NRO_REF", fvtaTo.NRO_REF);
            if (fvtaTo.FECHA_REF == null)
                cmd.Parameters.AddWithValue("@FECHA_REF", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@FECHA_REF", fvtaTo.FECHA_REF);
            //cmd.Parameters.AddWithValue("@NRO_SALIDA", fvtaTo.NRO_SALIDA);
            //cmd.Parameters.AddWithValue("@NRO_GUIA", fvtaTo.NRO_GUIA);
            cmd.Parameters.AddWithValue("@COD_USU_CREA", fvtaTo.COD_USU_CREA);
            cmd.Parameters.AddWithValue("@FECHA_CREA", fvtaTo.FECHA_CREA);
            cmd.Parameters.AddWithValue("@SERIE2", fvtaTo.SERIE2);
            cmd.Parameters.AddWithValue("@COD_MOT_DEV", fvtaTo.COD_MOT_DEV);
            cmd.Parameters.AddWithValue("@COD_MOV", fvtaTo.COD_MOV);
            cmd.Parameters.AddWithValue("@TIPO_FACT", fvtaTo.TIPO_FACT);
            cmd.Parameters.AddWithValue("@VALOR_DETRACCION", fvtaTo.VALOR_DETRACCION);
            cmd.Parameters.AddWithValue("@POR_DETRACCION", fvtaTo.POR_DETRACCION);
            cmd.Parameters.AddWithValue("@STATUS_FE", fvtaTo.STATUS_FE);
            cmd.Parameters.AddWithValue("@STATUS_ENVIO_FE", fvtaTo.STATUS_ENVIO_FE);
            cmd.Parameters.AddWithValue("@TIPO_OPERACION_FE", fvtaTo.TIPO_OPERACION_FE);
            cmd.Parameters.AddWithValue("@STATUS_BAJA_FE", fvtaTo.STATUS_BAJA_FE);
            cmd.Parameters.AddWithValue("@FORMA_PAGO", fvtaTo.FORMA_PAGO);
            cmd.Parameters.AddWithValue("@NRO_DIAS", fvtaTo.NRO_DIAS);
            cmd.Parameters.AddWithValue("@CONDICION_VENTA", fvtaTo.CONDICION_VENTA);
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
        public bool validaExisteNroDocumentoFacturacionDAL(facturacionVtaCabeceraTo fvtaTo, ref bool val, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("VERIFICAR_NRO_DOCUMENTO_FACTURACION", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_DOC", fvtaTo.NRO_DOC);
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
