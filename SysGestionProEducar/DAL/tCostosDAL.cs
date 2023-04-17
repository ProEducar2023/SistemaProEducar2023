using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public class tCostosDAL
    {
        SqlConnection conn;
        public tCostosDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerTCostosDAL()
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
        public bool insertarTCostosDAL(tCostosTo tcosTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_T_COSTOS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", tcosTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_CLASE", tcosTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_MOV", tcosTo.COD_MOV);
            cmd.Parameters.AddWithValue("@COD_DOC_INV", tcosTo.COD_DOC_INV);
            cmd.Parameters.AddWithValue("@NRO_DOC_INV", tcosTo.NRO_DOC_INV);
            cmd.Parameters.AddWithValue("@COD_PER", tcosTo.COD_PER);
            cmd.Parameters.AddWithValue("@NRO_DOC_PER", tcosTo.NRO_DOC_PER);
            cmd.Parameters.AddWithValue("@FE_AÑO", tcosTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", tcosTo.FE_MES);
            cmd.Parameters.AddWithValue("@FECHA_DOC", tcosTo.FECHA_DOC);
            cmd.Parameters.AddWithValue("@FECHA_DOC_INV", tcosTo.FECHA_DOC_INV);
            cmd.Parameters.AddWithValue("@COD_DOC", tcosTo.COD_DOC);
            cmd.Parameters.AddWithValue("@NRO_DOC", tcosTo.NRO_DOC);
            cmd.Parameters.AddWithValue("@OBSERVACION", tcosTo.OBSERVACION);
            cmd.Parameters.AddWithValue("@TIPO_CAMBIO", tcosTo.TIPO_CAMBIO);
            cmd.Parameters.AddWithValue("@COD_USU", tcosTo.COD_USU);
            cmd.Parameters.AddWithValue("@FECHA", tcosTo.FECHA_CREA);
            cmd.Parameters.AddWithValue("@COD_MONEDA", tcosTo.COD_MONEDA);
            cmd.Parameters.AddWithValue("@STATUS_VAL", tcosTo.STATUS_VAL);
            cmd.Parameters.AddWithValue("@ITEM", tcosTo.ITEM);
            cmd.Parameters.AddWithValue("@NRO_ITEM", tcosTo.NRO_ITEM);
            cmd.Parameters.AddWithValue("@COD_ARTICULO", tcosTo.COD_ARTICULO);
            cmd.Parameters.AddWithValue("@CANTIDAD", tcosTo.CANTIDAD);
            cmd.Parameters.AddWithValue("@PRECIO_ACTUAL", tcosTo.PRECIO_ACTUAL);
            cmd.Parameters.AddWithValue("@VALOR_COSTO", tcosTo.VALOR_COSTO);
            cmd.Parameters.AddWithValue("@PRECIO_CON", tcosTo.PRECIO_CON);
            cmd.Parameters.AddWithValue("@VALOR_CON", tcosTo.VALOR_CON);
            cmd.Parameters.AddWithValue("@COD_D_H", tcosTo.COD_D_H);
            cmd.Parameters.AddWithValue("@COD_ALMACEN", tcosTo.COD_ALMACEN);
            cmd.Parameters.AddWithValue("@COD_REF", tcosTo.COD_REF);
            cmd.Parameters.AddWithValue("@NRO_REF", tcosTo.NRO_REF);
            cmd.Parameters.AddWithValue("@COD_CC", tcosTo.COD_CC);
            cmd.Parameters.AddWithValue("@PRECIO_CPROM", tcosTo.PRECIO_CPROM);
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
        public bool modificarTCostosDAL(tCostosTo tcosTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("REGRESAR_T_COSTOS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", tcosTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_CLASE", tcosTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_MOV", tcosTo.COD_MOV);
            cmd.Parameters.AddWithValue("@COD_DOC_INV", tcosTo.COD_DOC_INV);
            cmd.Parameters.AddWithValue("@NRO_DOC_INV", tcosTo.NRO_DOC_INV);
            cmd.Parameters.AddWithValue("@COD_PER", tcosTo.COD_PER);
            cmd.Parameters.AddWithValue("@NRO_DOC_PER", tcosTo.NRO_DOC_PER);
            cmd.Parameters.AddWithValue("@FE_AÑO", tcosTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", tcosTo.FE_MES);
            cmd.Parameters.AddWithValue("@FECHA_DOC", tcosTo.FECHA_DOC);
            cmd.Parameters.AddWithValue("@FECHA_DOC_INV", tcosTo.FECHA_DOC_INV);
            cmd.Parameters.AddWithValue("@COD_DOC", tcosTo.COD_DOC);
            cmd.Parameters.AddWithValue("@NRO_DOC", tcosTo.NRO_DOC);
            cmd.Parameters.AddWithValue("@OBSERVACION", tcosTo.OBSERVACION);
            cmd.Parameters.AddWithValue("@TIPO_CAMBIO", tcosTo.TIPO_CAMBIO);
            cmd.Parameters.AddWithValue("@COD_USU", tcosTo.COD_USU);
            cmd.Parameters.AddWithValue("@FECHA", tcosTo.FECHA_CREA);
            cmd.Parameters.AddWithValue("@COD_MONEDA", tcosTo.COD_MONEDA);
            cmd.Parameters.AddWithValue("@STATUS_VAL", tcosTo.STATUS_VAL);
            cmd.Parameters.AddWithValue("@ITEM", tcosTo.ITEM);
            //cmd.Parameters.AddWithValue("@NRO_ITEM", tcosTo.NRO_ITEM);
            cmd.Parameters.AddWithValue("@COD_ARTICULO", tcosTo.COD_ARTICULO);
            cmd.Parameters.AddWithValue("@CANTIDAD", tcosTo.CANTIDAD);
            cmd.Parameters.AddWithValue("@PRECIO_ACTUAL", tcosTo.PRECIO_ACTUAL);
            cmd.Parameters.AddWithValue("@VALOR_COSTO", tcosTo.VALOR_COSTO);
            cmd.Parameters.AddWithValue("@PRECIO_CON", tcosTo.PRECIO_CON);
            cmd.Parameters.AddWithValue("@VALOR_CON", tcosTo.VALOR_CON);
            cmd.Parameters.AddWithValue("@COD_D_H", tcosTo.COD_D_H);
            cmd.Parameters.AddWithValue("@COD_ALMACEN", tcosTo.COD_ALMACEN);
            cmd.Parameters.AddWithValue("@COD_REF", tcosTo.COD_REF);
            cmd.Parameters.AddWithValue("@NRO_REF", tcosTo.NRO_REF);
            cmd.Parameters.AddWithValue("@COD_CC", tcosTo.COD_CC);
            cmd.Parameters.AddWithValue("@PRECIO_CPROM", tcosTo.PRECIO_CPROM);
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
        public DataTable VERIFICA_ORDEN_PT_COS(tCostosTo tcosTo, ref StringBuilder SBCancela)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("VERIFICA_ORDEN_PT_COS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                //SqlDataReader dr = cmd.ExecuteReader();
                //dt.Load(dr, LoadOption.Upsert);
                //dr.Close();
                IAsyncResult iar = cmd.BeginExecuteReader();
                using (SqlDataReader Reader = cmd.EndExecuteReader(iar))
                {
                    while (Reader.Read())
                    {
                        SBCancela.AppendFormat("{0}{1}{2}", Reader.GetString(0), Reader.GetString(1), Environment.NewLine);
                        //existe = true;
                    }
                }
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
        public DataTable MOSTRAR_T_COSTOS_DEVOLUCION(tCostosTo tcosTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_T_COSTOS_DEVOLUCION", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", tcosTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_CLASE", tcosTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_MOV", tcosTo.COD_MOV);
            cmd.Parameters.AddWithValue("@COD_DOC_INV", tcosTo.COD_DOC_INV);
            cmd.Parameters.AddWithValue("@NRO_DOC_INV", tcosTo.NRO_DOC_INV);
            cmd.Parameters.AddWithValue("@COD_PER", tcosTo.COD_PER);
            cmd.Parameters.AddWithValue("@FE_AÑO", tcosTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", tcosTo.FE_MES);
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
        public bool ACTUALIZAR_T_COSTOS_DEVOLUCION_DAL(tCostosTo tcosTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ACTUALIZAR_T_COSTOS_DEVOLUCION", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", tcosTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_CLASE", tcosTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_MOV", tcosTo.COD_MOV);
            cmd.Parameters.AddWithValue("@COD_DOC_INV", tcosTo.COD_DOC_INV);
            cmd.Parameters.AddWithValue("@NRO_DOC_INV", tcosTo.NRO_DOC_INV);
            cmd.Parameters.AddWithValue("@COD_PER", tcosTo.COD_PER);
            cmd.Parameters.AddWithValue("@FE_AÑO", tcosTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", tcosTo.FE_MES);
            cmd.Parameters.AddWithValue("@ITEM", tcosTo.ITEM);
            cmd.Parameters.AddWithValue("@PRECIO_CON", tcosTo.PRECIO_CON);
            cmd.Parameters.AddWithValue("@VALOR_CON", tcosTo.VALOR_CON);

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
        public DataTable CONSULTA_KARDEX_SALDO_ARTICULO(tCostosTo tcosTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("CONSULTA_KARDEX_SALDO_ARTICULO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("COD_SUCURSAL", tcosTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("COD_CLASE", tcosTo.COD_CLASE);
            cmd.Parameters.AddWithValue("COD_ARTICULO", tcosTo.COD_ARTICULO);
            cmd.Parameters.AddWithValue("MES1", tcosTo.MES1);
            cmd.Parameters.AddWithValue("MES2", tcosTo.MES2);
            cmd.Parameters.AddWithValue("MES_ANTERIOR", tcosTo.MES_ANTERIOR);
            cmd.Parameters.AddWithValue("AÑO", tcosTo.AÑO);
            //cmd.CommandTimeout = 720;
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
