using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class puntoVentaDAL
    {
        SqlConnection conn;
        public puntoVentaDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerPuntoVentaDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_TODOS_PUNTOS_VENTA", conn);
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
        public bool insertarPuntoVentaDAL(puntoVentaTo ptvTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_PUNTO_VENTA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PTO_VEN", ptvTo.COD_PTO_VEN);
            cmd.Parameters.AddWithValue("@DESC_PTO_VEN", ptvTo.DESC_PTO_VEN);
            cmd.Parameters.AddWithValue("@COD_INSTITUCION", ptvTo.COD_INSTITUCION);
            cmd.Parameters.AddWithValue("@DESC_INSTITUCION", ptvTo.DESC_INSTITUCION);
            cmd.Parameters.AddWithValue("@PAIS", ptvTo.PAIS);
            cmd.Parameters.AddWithValue("@DEPARTAMENTO", ptvTo.DEPARTAMENTO);
            cmd.Parameters.AddWithValue("@PROVINCIA", ptvTo.PROVINCIA);
            cmd.Parameters.AddWithValue("@DISTRITO", ptvTo.DISTRITO);
            cmd.Parameters.AddWithValue("@STATUS_CONSOLIDADO", ptvTo.STATUS_CONSOLIDADO);
            cmd.Parameters.AddWithValue("@TIPO_PLANILLA", ptvTo.TIPO_PLANILLA);
            cmd.Parameters.AddWithValue("@DIRECCION", ptvTo.DIRECCION);
            cmd.Parameters.AddWithValue("@COD_PTO_COB", ptvTo.COD_PTO_COB);
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
        public bool modificarPuntoVentaDAL(puntoVentaTo ptvTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_PUNTO_VENTA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PTO_VEN", ptvTo.COD_PTO_VEN);
            cmd.Parameters.AddWithValue("@DESC_PTO_VEN", ptvTo.DESC_PTO_VEN);
            cmd.Parameters.AddWithValue("@COD_INSTITUCION", ptvTo.COD_INSTITUCION);
            cmd.Parameters.AddWithValue("@DESC_INSTITUCION", ptvTo.DESC_INSTITUCION);
            cmd.Parameters.AddWithValue("@PAIS", ptvTo.PAIS);
            cmd.Parameters.AddWithValue("@DEPARTAMENTO", ptvTo.DEPARTAMENTO);
            cmd.Parameters.AddWithValue("@PROVINCIA", ptvTo.PROVINCIA);
            cmd.Parameters.AddWithValue("@DISTRITO", ptvTo.DISTRITO);
            cmd.Parameters.AddWithValue("@STATUS_CONSOLIDADO", ptvTo.STATUS_CONSOLIDADO);
            cmd.Parameters.AddWithValue("@TIPO_PLANILLA", ptvTo.TIPO_PLANILLA);
            cmd.Parameters.AddWithValue("@DIRECCION", ptvTo.DIRECCION);
            cmd.Parameters.AddWithValue("@COD_PTO_COB", ptvTo.COD_PTO_COB);
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
        public bool eliminarPuntoVentaDAL(puntoVentaTo ptvTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_PUNTO_VENTA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PTO_VEN", ptvTo.COD_PTO_VEN);

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
        public DataTable obtenerPuntosVentasDAL(puntoVentaTo ptvTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_PUNTOS_VENTAS", conn);
            //cmd.Parameters.AddWithValue("@STATUS_CONSOLIDADO", ptvTo.STATUS_CONSOLIDADO);
            cmd.Parameters.AddWithValue("@COD_INSTITUCION", ptvTo.COD_INSTITUCION);
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
        public DataTable obtenerPuntoVentaVinculadosDAL(puntoVentaTo ptvTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_PUNTOS_VENTAS_VINCULADOS", conn);
            cmd.Parameters.AddWithValue("@COD_PTO_VEN_CONS", ptvTo.COD_PTO_VEN_CONS);
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
        public bool eliminaPuntoVentaVinculadosDAL(string cod_cons, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_PUNTO_VENTA_VINCULADO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PTO_VEN_CONS", cod_cons);
            //cmd.Parameters.AddWithValue("@STATUS_CONSOLIDADO", ptvTo.STATUS_CONSOLIDADO);
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
        public bool eliminaPuntoVentaRelacionadosDAL(puntoVentaTo ptvTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_PUNTO_VENTA_VINCULADO_RELACIONADOS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PTO_VEN_CONS", ptvTo.COD_PTO_VEN_CONS);
            cmd.Parameters.AddWithValue("@STATUS_CONSOLIDADO", ptvTo.STATUS_CONSOLIDADO);
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
        public bool insertarPtoVenVinculadosDAL(puntoVentaTo ptvTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_PUNTO_VENTA_VINCULADO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PTO_VEN_CONS", ptvTo.COD_PTO_VEN_CONS);
            cmd.Parameters.AddWithValue("@COD_PTO_VEN", ptvTo.COD_PTO_VEN);
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
        public DataTable obtenerPuntoVentaConsolidadoDAL(puntoVentaTo ptvTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_PUNTOS_VENTA_CONSOLIDADO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PTO_VEN", ptvTo.COD_PTO_VEN);
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
        public int verificaPuntoVentaDAL(puntoVentaTo ptvTo)
        {
            int val = -1;
            SqlCommand cmd = new SqlCommand("VERIFICAR_PUNTO_VENTA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PTO_VEN", ptvTo.COD_PTO_VEN);
            try
            {
                conn.Open();
                val = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception)
            {
                val = -1;
            }
            finally
            {
                conn.Close();
            }
            return val;
        }
        public bool validaHistoricoPedidoDAL(puntoVentaTo ptvTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("VERIFICAR_PUNTO_VENTA_HISTORICO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PTO_VEN", ptvTo.COD_PTO_VEN);
            try
            {
                conn.Open();
                flag = Convert.ToBoolean(cmd.ExecuteScalar());
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
        public DataTable obtenerPuntoVentaVinculadosDetalleDAL(puntoVentaTo ptvTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_PUNTOS_VENTA_VINCULADOS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_INSTITUCION", ptvTo.COD_INSTITUCION);
            cmd.Parameters.AddWithValue("@COD_PTO_COB", ptvTo.COD_PTO_COB);
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
        public bool modificaPuntoVentaDetalleDAL(puntoVentaTo ptvTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PTO_VEN", ptvTo.COD_PTO_VEN);
            try
            {
                conn.Open();
                flag = Convert.ToBoolean(cmd.ExecuteScalar());
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
