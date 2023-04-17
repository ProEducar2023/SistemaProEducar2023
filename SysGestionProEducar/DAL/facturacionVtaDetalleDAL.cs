using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class facturacionVtaDetalleDAL
    {
        SqlConnection conn;
        public facturacionVtaDetalleDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerFacturacionVtaDetalleDAL(facturacionVtaDetalleTo dfvtaTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_T_FACT_DETALLES_VTA_TRANS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_CLASE", dfvtaTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", dfvtaTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_PER", dfvtaTo.COD_PER);
            cmd.Parameters.AddWithValue("@COD_DOC", dfvtaTo.COD_DOC);
            cmd.Parameters.AddWithValue("@NRO_DOC", dfvtaTo.NRO_DOC);
            cmd.Parameters.AddWithValue("@FE_AÑO", dfvtaTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", dfvtaTo.FE_MES);
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
        public DataTable obtenerFacturacionVtaDetalleDI_DAL(facturacionVtaDetalleTo dfvtaTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_TFACT_VTA_SER", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_CLASE", dfvtaTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", dfvtaTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_PER", dfvtaTo.COD_PER);
            cmd.Parameters.AddWithValue("@COD_DOC", dfvtaTo.COD_DOC);
            cmd.Parameters.AddWithValue("@NRO_DOC", dfvtaTo.NRO_DOC);
            cmd.Parameters.AddWithValue("@FE_AÑO", dfvtaTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", dfvtaTo.FE_MES);
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
        public bool insertarFacturacionVtaDetalleDAL(facturacionVtaDetalleTo dfvtaTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", dfvtaTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_CLASE", dfvtaTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_DOC", dfvtaTo.COD_DOC);
            cmd.Parameters.AddWithValue("@NRO_DOC", dfvtaTo.NRO_DOC);
            cmd.Parameters.AddWithValue("@COD_PER", dfvtaTo.COD_PER);
            cmd.Parameters.AddWithValue("@FE_AÑO", dfvtaTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", dfvtaTo.FE_MES);
            cmd.Parameters.AddWithValue("@ITEM", dfvtaTo.ITEM);
            cmd.Parameters.AddWithValue("@COD_DOC_GUIA", dfvtaTo.COD_DOC_GUIA);
            cmd.Parameters.AddWithValue("@NRO_DOC_GUIA", dfvtaTo.NRO_DOC_GUIA);
            cmd.Parameters.AddWithValue("@NRO_PEDIDO", dfvtaTo.NRO_PEDIDO);
            cmd.Parameters.AddWithValue("@COD_ARTICULO", dfvtaTo.COD_ARTICULO);
            cmd.Parameters.AddWithValue("@CANTIDAD", dfvtaTo.CANTIDAD);
            cmd.Parameters.AddWithValue("@COD_D_H", dfvtaTo.COD_D_H);
            cmd.Parameters.AddWithValue("@COD_MONEDA", dfvtaTo.COD_MONEDA);
            cmd.Parameters.AddWithValue("@PRECIO_UNITARIO", dfvtaTo.PRECIO_UNITARIO);
            cmd.Parameters.AddWithValue("@VALOR_COMPRA", dfvtaTo.VALOR_COMPRA);
            cmd.Parameters.AddWithValue("@POR_IGV", dfvtaTo.POR_IGV);
            cmd.Parameters.AddWithValue("@POR_DSCTO", dfvtaTo.POR_DSCTO);
            cmd.Parameters.AddWithValue("@STATUS_IGV", dfvtaTo.STATUS_IGV);
            cmd.Parameters.AddWithValue("@VALOR_IGV", dfvtaTo.VALOR_IGV);
            cmd.Parameters.AddWithValue("@VALOR_DSCTO", dfvtaTo.VALOR_DSCTO);
            cmd.Parameters.AddWithValue("@AJUSTE_IGV", dfvtaTo.AJUSTE_IGV);
            cmd.Parameters.AddWithValue("@AJUSTE_BI", dfvtaTo.AJUSTE_BI);
            cmd.Parameters.AddWithValue("@NRO_ITEM", dfvtaTo.NRO_ITEM);
            cmd.Parameters.AddWithValue("@OBSERVACION", dfvtaTo.OBSERVACION);
            cmd.Parameters.AddWithValue("@NRO_SALIDA", dfvtaTo.NRO_SALIDA);
            cmd.Parameters.AddWithValue("@TIPO_PRECIO", dfvtaTo.TIPO_PRECIO);
            cmd.Parameters.AddWithValue("@NRO_INGRESO", dfvtaTo.NRO_INGRESO);
            cmd.Parameters.AddWithValue("@VALOR_REFERENCIAL", dfvtaTo.VALOR_REFERENCIAL);
            cmd.Parameters.AddWithValue("@VALOR_IGV_REF", dfvtaTo.VALOR_IGV_REF);
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
        public bool modificarFacturacionVtaDetalleDAL(facturacionVtaDetalleTo dfvtaTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", dfvtaTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_CLASE", dfvtaTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_DOC", dfvtaTo.COD_DOC);
            cmd.Parameters.AddWithValue("@NRO_DOC", dfvtaTo.NRO_DOC);
            cmd.Parameters.AddWithValue("@COD_PER", dfvtaTo.COD_PER);
            cmd.Parameters.AddWithValue("@FE_AÑO", dfvtaTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", dfvtaTo.FE_MES);
            cmd.Parameters.AddWithValue("@ITEM", dfvtaTo.ITEM);
            cmd.Parameters.AddWithValue("@COD_DOC_GUIA", dfvtaTo.COD_DOC_GUIA);
            cmd.Parameters.AddWithValue("@NRO_DOC_GUIA", dfvtaTo.NRO_DOC_GUIA);
            cmd.Parameters.AddWithValue("@NRO_PEDIDO", dfvtaTo.NRO_PEDIDO);
            cmd.Parameters.AddWithValue("@COD_ARTICULO", dfvtaTo.COD_ARTICULO);
            cmd.Parameters.AddWithValue("@CANTIDAD", dfvtaTo.CANTIDAD);
            cmd.Parameters.AddWithValue("@COD_D_H", dfvtaTo.COD_D_H);
            cmd.Parameters.AddWithValue("@COD_MONEDA", dfvtaTo.COD_MONEDA);
            cmd.Parameters.AddWithValue("@PRECIO_UNITARIO", dfvtaTo.PRECIO_UNITARIO);
            cmd.Parameters.AddWithValue("@VALOR_COMPRA", dfvtaTo.VALOR_COMPRA);
            cmd.Parameters.AddWithValue("@POR_IGV", dfvtaTo.POR_IGV);
            cmd.Parameters.AddWithValue("@POR_DSCTO", dfvtaTo.POR_DSCTO);
            cmd.Parameters.AddWithValue("@STATUS_IGV", dfvtaTo.STATUS_IGV);
            cmd.Parameters.AddWithValue("@VALOR_IGV", dfvtaTo.VALOR_IGV);
            cmd.Parameters.AddWithValue("@VALOR_DSCTO", dfvtaTo.VALOR_DSCTO);
            cmd.Parameters.AddWithValue("@AJUSTE_IGV", dfvtaTo.AJUSTE_IGV);
            cmd.Parameters.AddWithValue("@AJUSTE_BI", dfvtaTo.AJUSTE_BI);
            cmd.Parameters.AddWithValue("@NRO_ITEM", dfvtaTo.NRO_ITEM);
            cmd.Parameters.AddWithValue("@OBSERVACION", dfvtaTo.OBSERVACION);
            cmd.Parameters.AddWithValue("@NRO_SALIDA", dfvtaTo.NRO_SALIDA);
            cmd.Parameters.AddWithValue("@TIPO_PRECIO", dfvtaTo.TIPO_PRECIO);
            cmd.Parameters.AddWithValue("@NRO_INGRESO", dfvtaTo.NRO_INGRESO);
            cmd.Parameters.AddWithValue("@VALOR_REFERENCIAL", dfvtaTo.VALOR_REFERENCIAL);
            cmd.Parameters.AddWithValue("@VALOR_IGV_REF", dfvtaTo.VALOR_IGV_REF);
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
        public bool eliminarFacturacionVtaDetalleDAL(facturacionVtaDetalleTo dfvtaTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", dfvtaTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_CLASE", dfvtaTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_DOC", dfvtaTo.COD_DOC);
            cmd.Parameters.AddWithValue("@NRO_DOC", dfvtaTo.NRO_DOC);
            cmd.Parameters.AddWithValue("@COD_PER", dfvtaTo.COD_PER);
            cmd.Parameters.AddWithValue("@FE_AÑO", dfvtaTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", dfvtaTo.FE_MES);
            cmd.Parameters.AddWithValue("@ITEM", dfvtaTo.ITEM);

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
