using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class contratoDetalleDAL
    {
        SqlConnection conn;
        public contratoDetalleDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerContratoDetalleContratoDAL(contratoDetalleTo dccTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_DETALLES_PEDIDO_CONTRATO", conn);
            cmd.Parameters.AddWithValue("@FE_AÑO", dccTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", dccTo.FE_MES);
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", dccTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_CLASE", dccTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_PER", dccTo.COD_PER);
            cmd.Parameters.AddWithValue("@NRO_DOC", dccTo.NRO_DOC);
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
        public DataTable obtenerContratoDetalleDAL(contratoDetalleTo dccTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_DETALLES_PEDIDO", conn);
            cmd.Parameters.AddWithValue("@FE_AÑO", dccTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", dccTo.FE_MES);
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", dccTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_CLASE", dccTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_PER", dccTo.COD_PER);
            cmd.Parameters.AddWithValue("@NRO_DOC", dccTo.NRO_DOC);
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
        public bool insertarContratoDetalleDAL(contratoDetalleTo dccTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_PEDIDO_DETALLE", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", dccTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@NRO_DOC", dccTo.NRO_DOC);
            cmd.Parameters.AddWithValue("@COD_PER", dccTo.COD_PER);
            cmd.Parameters.AddWithValue("@COD_CLASE", dccTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@FE_AÑO", dccTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", dccTo.FE_MES);
            cmd.Parameters.AddWithValue("@ITEM", dccTo.ITEM);
            cmd.Parameters.AddWithValue("@COD_ARTICULO", dccTo.COD_ARTICULO);
            cmd.Parameters.AddWithValue("@CANTIDAD_PED", dccTo.CANTIDAD_PED);
            cmd.Parameters.AddWithValue("@CANTIDAD_ATEN", dccTo.CANTIDAD_ATEN);
            cmd.Parameters.AddWithValue("@CANTIDAD_ANUL", dccTo.CANTIDAD_ANUL);
            cmd.Parameters.AddWithValue("@PRECIO_UNIT", dccTo.PRECIO_UNIT);
            cmd.Parameters.AddWithValue("@VALOR_COMPRA", dccTo.VALOR_COMPRA);
            cmd.Parameters.AddWithValue("@POR_IGV", dccTo.POR_IGV);
            cmd.Parameters.AddWithValue("@POR_DSCTO", dccTo.POR_DSCTO);
            cmd.Parameters.AddWithValue("@STATUS_IGV", dccTo.STATUS_IGV);
            cmd.Parameters.AddWithValue("@VALOR_IGV", dccTo.VALOR_IGV);
            cmd.Parameters.AddWithValue("@VALOR_DSCTO", dccTo.VALOR_DSCTO);
            cmd.Parameters.AddWithValue("@AJUSTE_IGV", dccTo.AJUSTE_IGV);
            cmd.Parameters.AddWithValue("@AJUSTE_BI", dccTo.AJUSTE_BI);
            cmd.Parameters.AddWithValue("@COD_D_H", dccTo.COD_D_H);
            cmd.Parameters.AddWithValue("@OBSERVACION", dccTo.OBSERVACION);
            cmd.Parameters.AddWithValue("@NRO_PRESUPUESTO", dccTo.NRO_PRESUPUESTO);
            cmd.Parameters.AddWithValue("@NRO_ITEM", dccTo.NRO_ITEM);
            cmd.Parameters.AddWithValue("@COD_CONDICION", dccTo.COD_CONDICION);
            cmd.Parameters.AddWithValue("@DESC_ARTICULO", dccTo.DESC_ARTICULO);
            cmd.Parameters.AddWithValue("@TIPO_PRECIO", dccTo.TIPO_PRECIO);
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
        public bool insertarContratoDetalle_dbf_DAL(contratoDetalleTo dccTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_PEDIDO_DETALLE_DBF", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", dccTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@NRO_DOC", dccTo.NRO_DOC);
            cmd.Parameters.AddWithValue("@COD_PER", dccTo.COD_PER);
            cmd.Parameters.AddWithValue("@COD_CLASE", dccTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@FE_AÑO", dccTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", dccTo.FE_MES);
            cmd.Parameters.AddWithValue("@ITEM", dccTo.ITEM);
            cmd.Parameters.AddWithValue("@COD_ARTICULO", dccTo.COD_ARTICULO);
            cmd.Parameters.AddWithValue("@CANTIDAD_PED", dccTo.CANTIDAD_PED);
            cmd.Parameters.AddWithValue("@CANTIDAD_ATEN", dccTo.CANTIDAD_ATEN);
            cmd.Parameters.AddWithValue("@CANTIDAD_ANUL", dccTo.CANTIDAD_ANUL);
            cmd.Parameters.AddWithValue("@PRECIO_UNIT", dccTo.PRECIO_UNIT);
            cmd.Parameters.AddWithValue("@VALOR_COMPRA", dccTo.VALOR_COMPRA);
            cmd.Parameters.AddWithValue("@POR_IGV", dccTo.POR_IGV);
            cmd.Parameters.AddWithValue("@POR_DSCTO", dccTo.POR_DSCTO);
            cmd.Parameters.AddWithValue("@STATUS_IGV", dccTo.STATUS_IGV);
            cmd.Parameters.AddWithValue("@VALOR_IGV", dccTo.VALOR_IGV);
            cmd.Parameters.AddWithValue("@VALOR_DSCTO", dccTo.VALOR_DSCTO);
            cmd.Parameters.AddWithValue("@AJUSTE_IGV", dccTo.AJUSTE_IGV);
            cmd.Parameters.AddWithValue("@AJUSTE_BI", dccTo.AJUSTE_BI);
            cmd.Parameters.AddWithValue("@COD_D_H", dccTo.COD_D_H);
            cmd.Parameters.AddWithValue("@OBSERVACION", dccTo.OBSERVACION);
            cmd.Parameters.AddWithValue("@NRO_PRESUPUESTO", dccTo.NRO_PRESUPUESTO);
            cmd.Parameters.AddWithValue("@NRO_ITEM", dccTo.NRO_ITEM);
            cmd.Parameters.AddWithValue("@COD_CONDICION", dccTo.COD_CONDICION);
            cmd.Parameters.AddWithValue("@DESC_ARTICULO", dccTo.DESC_ARTICULO);
            cmd.Parameters.AddWithValue("@TIPO_PRECIO", dccTo.TIPO_PRECIO);
            cmd.Parameters.AddWithValue("@NRO_FAC_PRE_UNI", dccTo.NRO_FAC_PRE_UNI);
            cmd.Parameters.AddWithValue("@TIPO_ENTR_FAC", dccTo.TIPO_ENTR_FAC);
            cmd.Parameters.AddWithValue("@ST_VALOR_REFERENCIAL", dccTo.ST_VALOR_REFERENCIAL);
            cmd.Parameters.AddWithValue("@COD_KIT", dccTo.COD_KIT);
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
        public DataTable CARGAR_PEDIDO_DETALLES_PTE_DAL(contratoDetalleTo dccTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_DETALLES_PEDIDO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", dccTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_CLASE", dccTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_PER", dccTo.COD_PER);
            cmd.Parameters.AddWithValue("@NRO_DOC", dccTo.NRO_DOC);
            cmd.Parameters.AddWithValue("@FE_AÑO", dccTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", dccTo.FE_MES);

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
        public DataTable CARGAR_PEDIDO_DETALLES_PTE3_DAL(contratoDetalleTo dccTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_DETALLES_PEDIDO3", conn);
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", dccTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_CLASE", dccTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_PER", dccTo.COD_PER);
            cmd.Parameters.AddWithValue("@NRO_DOC", dccTo.NRO_DOC);
            cmd.Parameters.AddWithValue("@FE_AÑO", dccTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", dccTo.FE_MES);
            ;
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
        public DataTable obtenerContratoDetalleporConsultaOrdDevFacVtaDAL(contratoDetalleTo dccTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_FACT_VTA_PARA_CONSULTA_ORD_DEV_FACT_DETALLE", conn);
            cmd.Parameters.AddWithValue("@NRO_PEDIDO", dccTo.NRO_DOC);
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
        public DataTable obtenerOrdenDevVtaDetalleDAL(contratoDetalleTo dccTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("OBTENER_ORDEN_DEV_VTA_DETALLE", conn);
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", dccTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@NRO_PRESUPUESTO", dccTo.NRO_PRESUPUESTO);
            cmd.Parameters.AddWithValue("@COD_PER", dccTo.COD_PER);
            cmd.Parameters.AddWithValue("@COD_CLASE", dccTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@FE_AÑO", dccTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", dccTo.FE_MES);
            //cmd.Parameters.AddWithValue("@COD_D_H", dccTo.COD_D_H);
            cmd.Parameters.AddWithValue("@NRO_FAC_PRE_UNI", dccTo.NRO_FAC_PRE_UNI);
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
        public DataTable obtenerNotaIngresoDevVtaDetalleDAL(contratoDetalleTo dccTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("OBTENER_NOTA_INGRESO_DEV_VTA_DETALLE", conn);
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", dccTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@NRO_PRESUPUESTO", dccTo.NRO_PRESUPUESTO);
            cmd.Parameters.AddWithValue("@COD_PER", dccTo.COD_PER);
            cmd.Parameters.AddWithValue("@COD_CLASE", dccTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@FE_AÑO", dccTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", dccTo.FE_MES);
            //cmd.Parameters.AddWithValue("@COD_D_H", dccTo.COD_D_H);
            cmd.Parameters.AddWithValue("@NRO_FAC_PRE_UNI", dccTo.NRO_FAC_PRE_UNI);
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
        public DataTable obtenerContratoDetalleporConsultaOrdDevFacVtaporContratoDAL(contratoDetalleTo dccTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_FACT_VTA_PARA_CONSULTA_ORD_DEV_FACT_DETALLE_POR_CONTRATO", conn);
            cmd.Parameters.AddWithValue("@NRO_PRESUPUESTO", dccTo.NRO_PRESUPUESTO);
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
        public bool ELIMINAR_PEDIDO_X_NRO_CONTRATO_DAL(contratoDetalleTo dccTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_PEDIDO_X_NRO_CONTRATO_DETALLE", conn);
            cmd.Parameters.AddWithValue("@NRO_PRESUPUESTO", dccTo.NRO_PRESUPUESTO);
            cmd.CommandType = CommandType.StoredProcedure;
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
        public bool eliminarContratoDirectoDAL(contratoDetalleTo dccTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_CONTRATO_DIRECTO", conn);
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", dccTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@NRO_DOC", dccTo.NRO_DOC);
            cmd.Parameters.AddWithValue("@COD_PER", dccTo.COD_PER);
            cmd.Parameters.AddWithValue("@COD_CLASE", dccTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@FE_AÑO", dccTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", dccTo.FE_MES);
            cmd.CommandType = CommandType.StoredProcedure;
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
