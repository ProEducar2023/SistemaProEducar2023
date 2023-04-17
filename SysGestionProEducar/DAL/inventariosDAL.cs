using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class inventariosDAL
    {
        SqlConnection conn;
        public inventariosDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerInventariosDAL(inventariosTo invTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_NOTA_INGRESO_DI", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FE_AÑO", invTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", invTo.FE_MES);
            cmd.Parameters.AddWithValue("@TIPO_USU", invTo.TIPO_USU);
            cmd.Parameters.AddWithValue("@COD_USU", invTo.COD_USU);
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
        public DataTable obtenerInventariosSalidaDetalleDAL(inventariosTo invTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_NOTA_SALIDA_DETALLES", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_CLASE", invTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", invTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_PER", invTo.COD_PER);
            cmd.Parameters.AddWithValue("@NRO_DOC_INV", invTo.NRO_DOC_INV);
            cmd.Parameters.AddWithValue("@FE_AÑO", invTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", invTo.FE_MES);

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
        public DataTable obtenerMostrar_Nota_Salida_DAL(inventariosTo invTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_NOTA_SALIDA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FE_AÑO", invTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", invTo.FE_MES);
            cmd.Parameters.AddWithValue("@TIPO_USU", invTo.TIPO_USU);
            cmd.Parameters.AddWithValue("@COD_USU", invTo.COD_USU);
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
        public bool insertarInventarioDAL(inventariosTo invTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_NOTA_INGRESO_DI_CAB", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", invTo.COD_SUCURSAL);//
            cmd.Parameters.AddWithValue("@COD_CLASE", invTo.COD_CLASE);//
            cmd.Parameters.AddWithValue("@COD_PER", invTo.COD_PER);//
            cmd.Parameters.AddWithValue("@COD_DOC_INV", invTo.COD_DOC_INV);//
            cmd.Parameters.AddWithValue("@NRO_DOC_INV", invTo.NRO_DOC_INV);//
            cmd.Parameters.AddWithValue("@FE_AÑO", invTo.FE_AÑO);//
            cmd.Parameters.AddWithValue("@FE_MES", invTo.FE_MES);//
            cmd.Parameters.AddWithValue("@COD_CLASE_PER", invTo.COD_CLASE_PER);//
            cmd.Parameters.AddWithValue("@NRO_DOC_PER", invTo.NRO_DOC_PER);//
            cmd.Parameters.AddWithValue("@COD_MOV", invTo.COD_MOV);//
            cmd.Parameters.AddWithValue("@FECHA_DOC_INV", invTo.FECHA_DOC_INV);//
            cmd.Parameters.AddWithValue("@COD_DOC", invTo.COD_DOC);//
            cmd.Parameters.AddWithValue("@NRO_DOC", invTo.NRO_DOC);//
            if (invTo.FECHA_DOC == null)
                cmd.Parameters.AddWithValue("@FECHA_DOC", DBNull.Value);//
            else
                cmd.Parameters.AddWithValue("@FECHA_DOC", invTo.FECHA_DOC);//
            cmd.Parameters.AddWithValue("@OBSERVACION", invTo.OBSERVACION);//
            cmd.Parameters.AddWithValue("@STATUS_PV", invTo.STATUS_PV);//
            cmd.Parameters.AddWithValue("@NOMBRE_PC", invTo.NOMBRE_PC);//
            cmd.Parameters.AddWithValue("@COD_MONEDA", invTo.COD_MONEDA);//
            cmd.Parameters.AddWithValue("@TIPO_CAMBIO", invTo.TIPO_CAMBIO);//
            cmd.Parameters.AddWithValue("@COD_ELABORADO", invTo.COD_ELABORADO);//
            cmd.Parameters.AddWithValue("@NUMERO", invTo.NUMERO);
            cmd.Parameters.AddWithValue("@SERIE", invTo.SERIE);
            cmd.Parameters.AddWithValue("@COD_USU", invTo.COD_USU);
            cmd.Parameters.AddWithValue("@FECHA", invTo.FECHA);
            cmd.Parameters.AddWithValue("@FECHA_DOC_ARTICULO", invTo.FECHA_DOC_ARTICULO);
            cmd.Parameters.AddWithValue("@COD_MOTIVO_DEVOLUCION", invTo.COD_MOTIVO_DEVOLUCION);
            cmd.Parameters.AddWithValue("@TIPO_ORIGEN", invTo.TIPO_ORIGEN);
            cmd.Parameters.AddWithValue("@NRO_PEDIDO", invTo.NRO_PEDIDO);
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
        public bool transferirInventarioDAL(inventariosTo invTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_NOTA_TRANS_CAB", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", invTo.COD_SUCURSAL);//
            cmd.Parameters.AddWithValue("@COD_CLASE", invTo.COD_CLASE);//
            cmd.Parameters.AddWithValue("@COD_PER", invTo.COD_PER);//
            cmd.Parameters.AddWithValue("@COD_DOC_INV", invTo.COD_DOC_INV);//
            cmd.Parameters.AddWithValue("@NRO_DOC_INV", invTo.NRO_DOC_INV);//
            cmd.Parameters.AddWithValue("@FE_AÑO", invTo.FE_AÑO);//
            cmd.Parameters.AddWithValue("@FE_MES", invTo.FE_MES);//
            cmd.Parameters.AddWithValue("@COD_CLASE_PER", invTo.COD_CLASE_PER);//
            cmd.Parameters.AddWithValue("@NRO_DOC_PER", invTo.NRO_DOC_PER);//
            cmd.Parameters.AddWithValue("@COD_MOV", invTo.COD_MOV);//
            cmd.Parameters.AddWithValue("@FECHA_DOC_INV", invTo.FECHA_DOC_INV);//
            //cmd.Parameters.AddWithValue("@COD_DOC", invTo.COD_DOC);
            //cmd.Parameters.AddWithValue("@NRO_DOC", invTo.NRO_DOC);
            //cmd.Parameters.AddWithValue("@FECHA_DOC", invTo.FECHA_DOC);
            cmd.Parameters.AddWithValue("@OBSERVACION", invTo.OBSERVACION);//
            //cmd.Parameters.AddWithValue("@STATUS_PV", invTo.STATUS_PV);
            cmd.Parameters.AddWithValue("@NOMBRE_PC", invTo.NOMBRE_PC);//
            //cmd.Parameters.AddWithValue("@COD_MONEDA", invTo.COD_MONEDA);
            //cmd.Parameters.AddWithValue("@TIPO_CAMBIO", invTo.TIPO_CAMBIO);
            cmd.Parameters.AddWithValue("@COD_ELAB", invTo.COD_ELABORADO);//
            cmd.Parameters.AddWithValue("@NUMERO", invTo.NUMERO);//
            cmd.Parameters.AddWithValue("@SERIE", invTo.SERIE);//
            cmd.Parameters.AddWithValue("@COD_USU", invTo.COD_USU);//
            cmd.Parameters.AddWithValue("@FECHA", invTo.FECHA);//
            //cmd.Parameters.AddWithValue("@FECHA_DOC_ARTICULO", invTo.FECHA_DOC_ARTICULO);
            //cmd.Parameters.AddWithValue("@COD_MOTIVO_DEVOLUCION", invTo.COD_MOTIVO_DEVOLUCION);
            cmd.Parameters.AddWithValue("@COD_ALMACEN1", invTo.COD_ALMACEN1);//
            cmd.Parameters.AddWithValue("@COD_ALMACEN2", invTo.COD_ALMACEN2);//

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
        public bool insertarInventarioSalidaDAL(inventariosTo invTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_NOTA_SALIDA_CAB", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", invTo.COD_SUCURSAL);//**
            cmd.Parameters.AddWithValue("@COD_CLASE", invTo.COD_CLASE);//**
            cmd.Parameters.AddWithValue("@COD_PER", invTo.COD_PER);//**
            cmd.Parameters.AddWithValue("@NUMERO", invTo.NUMERO);//**
            cmd.Parameters.AddWithValue("@SERIE", invTo.SERIE);//**
            cmd.Parameters.AddWithValue("@NRO_DOC_PER", invTo.NRO_DOC_PER);//**
            cmd.Parameters.AddWithValue("@FE_AÑO", invTo.FE_AÑO);//**
            cmd.Parameters.AddWithValue("@FE_MES", invTo.FE_MES);//**
            cmd.Parameters.AddWithValue("@COD_DOC_INV", invTo.COD_DOC_INV);//**
            cmd.Parameters.AddWithValue("@NRO_DOC_INV", invTo.NRO_DOC_INV);//**
            cmd.Parameters.AddWithValue("@COD_CLASE_PER", invTo.COD_CLASE_PER);//**
            cmd.Parameters.AddWithValue("@COD_MOV", invTo.COD_MOV);//**
            cmd.Parameters.AddWithValue("@FECHA_DOC_INV", invTo.FECHA_DOC_INV);//**
            cmd.Parameters.AddWithValue("@OBSERVACION", invTo.OBSERVACION);//**
            cmd.Parameters.AddWithValue("@NOMBRE_PC", invTo.NOMBRE_PC);//**
            cmd.Parameters.AddWithValue("@COD_USU", invTo.COD_USU);//**
            cmd.Parameters.AddWithValue("@FECHA", invTo.FECHA);//**
            cmd.Parameters.AddWithValue("@COD_ELABORADO", invTo.COD_ELABORADO);//**
            cmd.Parameters.AddWithValue("@AREA", invTo.AREA);//**
            cmd.Parameters.AddWithValue("@TIPO_CAMBIO", invTo.TIPO_CAMBIO);
            cmd.Parameters.AddWithValue("@NRO_DOC", invTo.NRO_DOC);
            cmd.Parameters.AddWithValue("@COD_DOC", invTo.COD_DOC);
            cmd.Parameters.AddWithValue("@NRO_PEDIDO", invTo.NRO_PEDIDO);
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
        public bool modificarInventarioSalidaDAL(inventariosTo invTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_NOTA_SALIDA_CAB", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", invTo.COD_SUCURSAL);//**---
            cmd.Parameters.AddWithValue("@COD_CLASE", invTo.COD_CLASE);//**---
            cmd.Parameters.AddWithValue("@COD_PER", invTo.COD_PER);//**---
            cmd.Parameters.AddWithValue("@COD_DOC_INV", invTo.COD_DOC_INV);//**---
            cmd.Parameters.AddWithValue("@NRO_DOC_INV", invTo.NRO_DOC_INV);//**---
            cmd.Parameters.AddWithValue("@FE_AÑO", invTo.FE_AÑO);//**---
            cmd.Parameters.AddWithValue("@FE_MES", invTo.FE_MES);//**---
            cmd.Parameters.AddWithValue("@COD_CLASE_PER", invTo.COD_CLASE_PER);//**---
            cmd.Parameters.AddWithValue("@NRO_DOC_PER", invTo.NRO_DOC_PER);//**---
            cmd.Parameters.AddWithValue("@COD_MOV", invTo.COD_MOV);//**---
            cmd.Parameters.AddWithValue("@FECHA_DOC_INV", invTo.FECHA_DOC_INV);//**---
            cmd.Parameters.AddWithValue("@OBSERVACION", invTo.OBSERVACION);//**---
            cmd.Parameters.AddWithValue("@NOMBRE_PC", invTo.NOMBRE_PC);//**---
            cmd.Parameters.AddWithValue("@COD_ELABORADO", invTo.COD_ELABORADO);//**---
            //cmd.Parameters.AddWithValue("@AREA", invTo.AREA);//**
            //cmd.Parameters.AddWithValue("@NUMERO", invTo.NUMERO);//**
            //cmd.Parameters.AddWithValue("@SERIE", invTo.SERIE);//**
            cmd.Parameters.AddWithValue("@COD_USU", invTo.COD_USU);//**---
            cmd.Parameters.AddWithValue("@FECHA", invTo.FECHA);//**---

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
        public bool modificarInventarioDAL(inventariosTo invTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_NOTA_INGRESO_DI_CAB", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", invTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_CLASE", invTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_PER", invTo.COD_PER);
            cmd.Parameters.AddWithValue("@COD_DOC_INV", invTo.COD_DOC_INV);
            cmd.Parameters.AddWithValue("@NRO_DOC_INV", invTo.NRO_DOC_INV);
            cmd.Parameters.AddWithValue("@FE_AÑO", invTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", invTo.FE_MES);
            cmd.Parameters.AddWithValue("@COD_USU", invTo.COD_USU);
            //cmd.Parameters.AddWithValue("@NRO_DOC_PER", invTo.NRO_DOC_PER);
            //cmd.Parameters.AddWithValue("@COD_MOV", invTo.COD_MOV);
            //cmd.Parameters.AddWithValue("@FECHA_DOC_INV", invTo.FECHA_DOC_INV);
            cmd.Parameters.AddWithValue("@COD_DOC", invTo.COD_DOC);
            cmd.Parameters.AddWithValue("@NRO_DOC", invTo.NRO_DOC);
            if (invTo.FECHA_DOC == null)
                cmd.Parameters.AddWithValue("@FECHA_DOC", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@FECHA_DOC", invTo.FECHA_DOC);
            cmd.Parameters.AddWithValue("@OBSERVACION", invTo.OBSERVACION);
            //cmd.Parameters.AddWithValue("@STATUS_PV", invTo.STATUS_PV);
            //cmd.Parameters.AddWithValue("@COD_ALMACEN1", invTo.COD_ALMACEN1);
            //cmd.Parameters.AddWithValue("@COD_ALMACEN2", invTo.COD_ALMACEN2);
            //cmd.Parameters.AddWithValue("@COD_MONEDA", invTo.COD_MONEDA);
            //cmd.Parameters.AddWithValue("@TIPO_CAMBIO", invTo.TIPO_CAMBIO);
            //cmd.Parameters.AddWithValue("@COD_USU_CREA", invTo.COD_USU_CREA);
            //cmd.Parameters.AddWithValue("@COD_USU_MOD", invTo.COD_USU_MOD);
            cmd.Parameters.AddWithValue("@FECHA_DOC_ARTICULO", invTo.FECHA_DOC_ARTICULO);
            cmd.Parameters.AddWithValue("@FECHA", invTo.FECHA);
            cmd.Parameters.AddWithValue("@NOMBRE_PC", invTo.NOMBRE_PC);
            //cmd.Parameters.AddWithValue("@STATUS_PEDIDO", invTo.STATUS_PEDIDO);
            //cmd.Parameters.AddWithValue("@STATUS_GUIA", invTo.STATUS_GUIA);
            //cmd.Parameters.AddWithValue("@COD_ALMACENERO", invTo.COD_ALMACENERO);
            //cmd.Parameters.AddWithValue("@COD_VENDEDOR", invTo.COD_VENDEDOR);
            //cmd.Parameters.AddWithValue("@STATUS_TRANS", invTo.STATUS_TRANS);
            cmd.Parameters.AddWithValue("@COD_ELABORADO", invTo.COD_ELABORADO);
            //cmd.Parameters.AddWithValue("@STATUS_ANUL", invTo.STATUS_ANUL);
            //cmd.Parameters.AddWithValue("@NRO_PEDIDO", invTo.NRO_PEDIDO);
            //cmd.Parameters.AddWithValue("@AREA", invTo.AREA);
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
        public bool VERIFICAR_DOC_INVENTARIODAL(inventariosTo invTo, ref bool existe, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("VERIFICAR_DOC_INVENTARIO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", invTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_DOC_INV", invTo.COD_DOC_INV);
            cmd.Parameters.AddWithValue("@NRO_DOC_INV", invTo.NRO_DOC_INV);
            try
            {
                conn.Open();
                int cant = Convert.ToInt32(cmd.ExecuteScalar());
                existe = cant != 0 ? false : true;
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
        public bool insertarBulkCopyInvDetDAL(DataTable dt, ref string errMensaje)
        {
            bool flag = false;
            try
            {
                conn.Open();
                int num = dt.Rows.Count - 1;
                SqlBulkCopy copy = new SqlBulkCopy(conn);
                copy.BatchSize = num;
                copy.DestinationTableName = "dbo.[INVENTARIO_DETALLES2]";
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

        public bool insertarBulkCopyArtSerieDAL(DataTable dt, ref string errMensaje)
        {
            bool flag = false;
            try
            {
                conn.Open();
                int num = dt.Rows.Count - 1;
                SqlBulkCopy copy = new SqlBulkCopy(conn);
                copy.BatchSize = num;
                copy.DestinationTableName = "dbo.[ARTICULO_SERIE_MOVIMIENTO2]";
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
        public DataTable obtenerMostrar_Nota_Ingreso_DetalleDAL(inventariosTo invTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_NOTA_INGRESO_DI_DETALLES", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_CLASE", invTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", invTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_PER", invTo.COD_PER);
            cmd.Parameters.AddWithValue("@NRO_DOC_INV", invTo.NRO_DOC_INV);
            cmd.Parameters.AddWithValue("@FE_AÑO", invTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", invTo.FE_MES);
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
        public DataTable obtenerMostrar_Nota_Ingreso_Detalle_OdevDAL(inventariosTo invTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_NOTA_INGRESO_DI_DETALLES_ODEV", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_CLASE", invTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", invTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_PER", invTo.COD_PER);
            cmd.Parameters.AddWithValue("@NRO_DOC_INV", invTo.NRO_DOC_INV);
            cmd.Parameters.AddWithValue("@FE_AÑO", invTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", invTo.FE_MES);
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
        public DataTable obtenerMostrar_Nota_Transferencia_DetalleDAL(inventariosTo invTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_NOTA_TRANS_DETALLES", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_CLASE", invTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", invTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_PER", invTo.COD_PER);
            cmd.Parameters.AddWithValue("@NRO_DOC_INV", invTo.NRO_DOC_INV);
            cmd.Parameters.AddWithValue("@FE_AÑO", invTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", invTo.FE_MES);
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
        public bool VerificaDetalleDAL(inventariosTo invTo, ref bool flag2, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("VERIFICAR_NOTA_INGRESO_OC_DETALLES", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", invTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_CLASE", invTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_PER", invTo.COD_PER);
            cmd.Parameters.AddWithValue("@COD_DOC_INV", invTo.COD_DOC_INV);
            cmd.Parameters.AddWithValue("@NRO_DOC_INV", invTo.NRO_DOC_INV);
            cmd.Parameters.AddWithValue("@FE_AÑO", invTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", invTo.FE_MES);
            try
            {
                conn.Open();
                flag2 = Convert.ToInt32(cmd.ExecuteScalar()) > 0 ? false : true;
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
        public bool VERIFICAR_MOD_NOTA_INGRESO(inventariosTo invTo, ref string str7, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("VERIFICAR_MOD_NOTA_INGRESO_OC", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", invTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_CLASE", invTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_PER", invTo.COD_PER);
            cmd.Parameters.AddWithValue("@NRO_DOC_INV", invTo.NRO_DOC_INV);
            cmd.Parameters.AddWithValue("@FE_AÑO", invTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", invTo.FE_MES);
            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string str = dr.GetValue(0).ToString();
                    decimal num = Convert.ToDecimal(dr.GetValue(1));
                    decimal num2 = Convert.ToDecimal(dr.GetValue(2));
                    if (decimal.Compare(num, num2) > 0)
                    {
                        str7 = str;
                        return flag = true;
                    }
                }
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
        public bool ELIMINA_NOTA_INGRESO(inventariosTo invTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_NOTA_INGRESO_OC", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", invTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_CLASE", invTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_PER", invTo.COD_PER);
            cmd.Parameters.AddWithValue("@COD_DOC_INV", invTo.COD_DOC_INV);
            cmd.Parameters.AddWithValue("@NRO_DOC_INV", invTo.NRO_DOC_INV);
            cmd.Parameters.AddWithValue("@FE_AÑO", invTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", invTo.FE_MES);
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
        public bool ELIMINA_NOTA_TRANSFERENCIA(inventariosTo invTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_NOTA_TRANS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", invTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_CLASE", invTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_PER", invTo.COD_PER);
            cmd.Parameters.AddWithValue("@COD_DOC_INV", invTo.COD_DOC_INV);
            cmd.Parameters.AddWithValue("@NRO_DOC_INV", invTo.NRO_DOC_INV);
            cmd.Parameters.AddWithValue("@FE_AÑO", invTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", invTo.FE_MES);
            cmd.Parameters.AddWithValue("@STATUS_OC", "0");
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
        public bool ANULA_NOTA_TRANSFERENCIA(inventariosTo invTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ANULAR_NOTA_TRANS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", invTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_CLASE", invTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_PER", invTo.COD_PER);
            cmd.Parameters.AddWithValue("@COD_DOC_INV", invTo.COD_DOC_INV);
            cmd.Parameters.AddWithValue("@NRO_DOC_INV", invTo.NRO_DOC_INV);
            cmd.Parameters.AddWithValue("@FE_AÑO", invTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", invTo.FE_MES);
            cmd.Parameters.AddWithValue("@STATUS_OC", "0");
            cmd.Parameters.AddWithValue("@TIPOUSU", invTo.TIPO_USU);
            cmd.Parameters.AddWithValue("@OBS", invTo.OBSERVACION);
            cmd.Parameters.AddWithValue("@USUMOD", invTo.COD_USU_MOD);
            cmd.Parameters.AddWithValue("@FECMOD", invTo.FECHA_MOD);
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
        public bool ANULA_NOTA_INGRESO(inventariosTo invTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("DES_ANULAR_NOTA_INGRESO_OC", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", invTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_CLASE", invTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_PER", invTo.COD_PER);
            cmd.Parameters.AddWithValue("@COD_DOC_INV", invTo.COD_DOC_INV);
            cmd.Parameters.AddWithValue("@NRO_DOC_INV", invTo.NRO_DOC_INV);
            cmd.Parameters.AddWithValue("@FE_AÑO", invTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", invTo.FE_MES);
            cmd.Parameters.AddWithValue("@ESTADO0", invTo.ESTADO0);
            cmd.Parameters.AddWithValue("@TIPOUSU", invTo.TIPO_USU);
            cmd.Parameters.AddWithValue("@OBS", invTo.OBSERVACION);
            cmd.Parameters.AddWithValue("@USUMOD", invTo.COD_USU_MOD);
            cmd.Parameters.AddWithValue("@FECMOD", invTo.FECHA_MOD);
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
        public bool modificarTransferenciaInventariosDAL(inventariosTo invTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_NOTA_TRANS_CAB", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", invTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_CLASE", invTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_PER", invTo.COD_PER);
            cmd.Parameters.AddWithValue("@COD_CLASE_PER", invTo.COD_CLASE_PER);
            cmd.Parameters.AddWithValue("@NRO_DOC_PER", invTo.NRO_DOC_PER);
            cmd.Parameters.AddWithValue("@COD_DOC_INV", invTo.COD_DOC_INV);
            cmd.Parameters.AddWithValue("@NRO_DOC_INV", invTo.NRO_DOC_INV);
            cmd.Parameters.AddWithValue("@FE_AÑO", invTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", invTo.FE_MES);
            cmd.Parameters.AddWithValue("@COD_MOV", invTo.COD_MOV);
            cmd.Parameters.AddWithValue("@FECHA_DOC_INV", invTo.FECHA_DOC_INV);
            cmd.Parameters.AddWithValue("@OBSERVACION", invTo.OBSERVACION);
            cmd.Parameters.AddWithValue("@STATUS_OC", "0");
            cmd.Parameters.AddWithValue("@COD_ALMACEN1", invTo.COD_ALMACEN1);
            cmd.Parameters.AddWithValue("@COD_ALMACEN2", invTo.COD_ALMACEN2);
            cmd.Parameters.AddWithValue("@NOMBRE_PC", invTo.NOMBRE_PC);
            cmd.Parameters.AddWithValue("@COD_USU", invTo.COD_USU);
            cmd.Parameters.AddWithValue("@FECHA", DateTime.Now);

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
        public bool ELIMINAR_NOTA_SALIDA_DAL(inventariosTo invTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_NOTA_SALIDA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", invTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_CLASE", invTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_PER", invTo.COD_PER);
            cmd.Parameters.AddWithValue("@COD_DOC_INV", invTo.COD_DOC_INV);
            cmd.Parameters.AddWithValue("@NRO_DOC_INV", invTo.NRO_DOC_INV);
            if (invTo.FE_AÑO == null)
                cmd.Parameters.AddWithValue("@FE_AÑO", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@FE_AÑO", invTo.FE_AÑO);
            if (invTo.FE_MES == null)
                cmd.Parameters.AddWithValue("@FE_MES", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@FE_MES", invTo.FE_MES);
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

        public bool ANULAR_NOTA_SALIDA_DAL(inventariosTo invTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ANULAR_NOTA_SALIDA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", invTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_CLASE", invTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_PER", invTo.COD_PER);
            cmd.Parameters.AddWithValue("@COD_DOC_INV", invTo.COD_DOC_INV);
            cmd.Parameters.AddWithValue("@NRO_DOC_INV", invTo.NRO_DOC_INV);
            cmd.Parameters.AddWithValue("@FE_AÑO", invTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", invTo.FE_MES);
            cmd.Parameters.AddWithValue("@TIPOUSU", invTo.TIPO_USU);
            cmd.Parameters.AddWithValue("@OBS", invTo.OBSERVACION);
            cmd.Parameters.AddWithValue("@USUMOD", invTo.COD_USU_MOD);
            cmd.Parameters.AddWithValue("@FECMOD", invTo.FECHA_MOD);
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
        public DataTable Mostrar_Nota_TransferenciaDAL(inventariosTo invTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_NOTA_TRANS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FE_AÑO", invTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", invTo.FE_MES);
            cmd.Parameters.AddWithValue("@TIPO_USU", invTo.TIPO_USU);
            cmd.Parameters.AddWithValue("@COD_USU", invTo.COD_USU);
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
        public DataTable CARGAR_GUIA_DETALLES_PTE2_DAL(inventariosTo invTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("CARGAR_GUIA_DETALLES_PTE2", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FE_AÑO", invTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", invTo.FE_MES);
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", invTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_CLASE", invTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_PER", invTo.COD_PER);
            cmd.Parameters.AddWithValue("@NRO_DOC_INV", invTo.NRO_DOC_INV);
            cmd.Parameters.AddWithValue("@COD_KIT", invTo.COD_KIT);

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
        public DataTable CARGAR_GUIA_DETALLES_PTE3_DAL(inventariosTo invTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("CARGAR_GUIA_DETALLES_PTE3", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FE_AÑO", invTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", invTo.FE_MES);
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", invTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_CLASE", invTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_PER", invTo.COD_PER);
            cmd.Parameters.AddWithValue("@NRO_DOC_INV", invTo.NRO_DOC_INV);
            cmd.Parameters.AddWithValue("@COD_KIT", invTo.COD_KIT);
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
        public DataTable obtenerDetalleparaCostoTransferenciaDAL(inventariosTo invTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_INVENTARIO_PENDIENTE", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_CLASE", invTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_MOV", invTo.COD_MOV);
            cmd.Parameters.AddWithValue("@STATUS_MOV", invTo.STATUS_MOV);
            cmd.Parameters.AddWithValue("@FE_AÑO", invTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", invTo.FE_MES);

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
        public DataTable obtenerDetalleparaCostoTransferencia2DAL(inventariosTo invTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_INVENTARIO_PENDIENTE2", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_CLASE", invTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_MOV", invTo.COD_MOV);
            cmd.Parameters.AddWithValue("@STATUS_MOV", invTo.STATUS_MOV);
            cmd.Parameters.AddWithValue("@FE_AÑO", invTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", invTo.FE_MES);

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
        public DataTable obtenerDetallesCostosDAL(inventariosTo invTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_DETALLES_COSTOS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", invTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_CLASE", invTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_MOV", invTo.COD_MOV);
            cmd.Parameters.AddWithValue("@COD_DOC_INV", invTo.COD_DOC_INV);
            cmd.Parameters.AddWithValue("@NRO_DOC_INV", invTo.NRO_DOC_INV);
            cmd.Parameters.AddWithValue("@COD_PER", invTo.COD_PER);
            cmd.Parameters.AddWithValue("@NRO_DOC_PER", invTo.NRO_DOC_PER);
            //cmd.Parameters.AddWithValue("@COD_MOV", invTo.COD_MOV);
            cmd.Parameters.AddWithValue("@FE_AÑO", invTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", invTo.FE_MES);
            cmd.Parameters.AddWithValue("@FECHA_DOC_INV", invTo.FECHA_DOC_INV);
            cmd.Parameters.AddWithValue("@FECHA_DOC", invTo.FECHA_DOC);
            cmd.Parameters.AddWithValue("@COD_DOC", invTo.COD_DOC);
            cmd.Parameters.AddWithValue("@NRO_DOC", invTo.NRO_DOC);
            cmd.Parameters.AddWithValue("@OBSERVACION", invTo.OBSERVACION);
            cmd.Parameters.AddWithValue("@TIPO_CAMBIO", invTo.TIPO_CAMBIO);
            cmd.Parameters.AddWithValue("@COD_USU", invTo.COD_USU);
            cmd.Parameters.AddWithValue("@FECHA", invTo.FECHA);
            cmd.Parameters.AddWithValue("@COD_MONEDA", invTo.COD_MONEDA);
            cmd.Parameters.AddWithValue("@STATUS_VAL", invTo.STATUS_VAL);
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
        public bool TRANSFERIR_COSTOS(inventariosTo invTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("TRANSFERIR_COSTOS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", invTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_CLASE", invTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_DOC_INV", invTo.COD_DOC_INV);
            cmd.Parameters.AddWithValue("@NRO_DOC_INV", invTo.NRO_DOC_INV);
            cmd.Parameters.AddWithValue("@COD_PER", invTo.COD_PER);
            cmd.Parameters.AddWithValue("@NRO_DOC_PER", invTo.NRO_DOC_PER);
            cmd.Parameters.AddWithValue("@FE_AÑO", invTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", invTo.FE_MES);
            cmd.Parameters.AddWithValue("@ESTADO", invTo.ESTADO);
            cmd.Parameters.AddWithValue("@COD_MOV", invTo.COD_MOV);
            cmd.Parameters.AddWithValue("@COD_DOC", invTo.COD_DOC);
            cmd.Parameters.AddWithValue("@NRO_DOC", invTo.NRO_DOC);
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
        public bool ACTUALIZAR_INVENTARIOS_DETALLE_DAL(inventariosTo invTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ACTUALIZAR_INVENTARIOS_DETALLE", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", invTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_CLASE", invTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_DOC_INV", invTo.COD_DOC_INV);
            cmd.Parameters.AddWithValue("@NRO_DOC_INV", invTo.NRO_DOC_INV);
            cmd.Parameters.AddWithValue("@COD_PER", invTo.COD_PER);
            cmd.Parameters.AddWithValue("@FE_AÑO", invTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", invTo.FE_MES);
            cmd.Parameters.AddWithValue("@NRO_ITEM", invTo.NRO_ITEM);
            cmd.Parameters.AddWithValue("@PRECIO_UNITARIO", invTo.PRECIO_UNITARIO);
            cmd.Parameters.AddWithValue("@VALOR_COMPRA", invTo.VALOR_COMPRA);
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
        public bool modificaInventarioSaldoInicialDAL(inventariosTo invTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_INVENTARIO_SALDO_INICIAL", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FE_AÑO", invTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_AÑO2", invTo.FE_AÑO2);
            cmd.Parameters.AddWithValue("@FE_MES", invTo.FE_MES);
            cmd.Parameters.AddWithValue("@COD_PER", invTo.COD_PER);
            cmd.Parameters.AddWithValue("@COD_CLASE", invTo.COD_CLASE);
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
        public bool modificaDesInventarioSaldoInicialDAL(inventariosTo invTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_DES_INVENTARIO_SALDO_INICIAL", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FE_AÑO", invTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_AÑO2", invTo.FE_AÑO2);
            cmd.Parameters.AddWithValue("@FE_MES", invTo.FE_MES);
            cmd.Parameters.AddWithValue("@COD_PER", invTo.COD_PER);
            cmd.Parameters.AddWithValue("@COD_CLASE", invTo.COD_CLASE);
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
        public DataTable obtenerReporteKardexInventarioHistoricoDAL(inventariosTo invTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("REPORTE_KARDEX_INVENTARIO_HISTORICO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_CLASE", invTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", invTo.COD_SUCURSAL);
            if (invTo.COD_ALMACEN1 == null)
                cmd.Parameters.AddWithValue("@COD_ALMACEN", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@COD_ALMACEN", invTo.COD_ALMACEN1);
            if (invTo.COD_ARTICULO == null)
                cmd.Parameters.AddWithValue("@COD_ARTICULO", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@COD_ARTICULO", invTo.COD_ARTICULO);
            cmd.Parameters.AddWithValue("@FE_DEL", invTo.FE_DEL);
            cmd.Parameters.AddWithValue("@FE_AL", invTo.FE_AL);
            cmd.CommandTimeout = 120;

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
        public DataTable obetenerReporteHistorialPrecioVentaDAL(inventariosTo invTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("REPORTE_HISTORIAL_PRECIO_VENTA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FE_DESDE", invTo.FE_DESDE);
            cmd.Parameters.AddWithValue("@FE_HASTA", invTo.FE_HASTA);
            //cmd.Parameters.AddWithValue("@COD_GRUPO", invTo.COD_GRUPO);
            cmd.Parameters.AddWithValue("@COD_KIT", invTo.COD_KIT);
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
        public DataTable obtenerReporteDevolucionMercaderiaDAL(inventariosTo invTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_REPORTE_DEVOLUCION_MERCADERIA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FECHA_DESDE", invTo.FE_DESDE);
            cmd.Parameters.AddWithValue("@FECHA_HASTA", invTo.FE_HASTA);
            cmd.Parameters.AddWithValue("@COD_PROGRAMA", invTo.COD_PROGRAMA);
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
        public bool eliminaNotaIngresoDetalleDAL(inventariosTo invTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_INVENTARIO_DETALLE", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", invTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_CLASE", invTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_PER", invTo.COD_PER);
            cmd.Parameters.AddWithValue("@COD_DOC_INV", invTo.COD_DOC_INV);
            cmd.Parameters.AddWithValue("@NRO_DOC_INV", invTo.NRO_DOC_INV);
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
        public string obtenerNroDocInventarioDAL(string nro_contrato)
        {
            string nro_doc_inv = "";
            SqlCommand cmd = new SqlCommand("MOSTRAR_NRO_DOC_INV_X_NRO_CONTRATO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_PEDIDO", nro_contrato);
            try
            {
                conn.Open();
                nro_doc_inv = Convert.ToString(cmd.ExecuteScalar());
            }
            catch (Exception)
            {
                nro_doc_inv = "";
            }
            finally
            {
                conn.Close();
            }
            return nro_doc_inv;
        }
    }
}
