using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class articuloContenidoMovimientoDAL
    {
        SqlConnection conn;
        public articuloContenidoMovimientoDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerArticuloContenidoMovimientoDAL(articuloContenidoMovimientoTo acmTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_ARTICULO_CONTENIDO_MOVIMIENTO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_NOTA_ING", acmTo.NRO_NOTA_ING);
            cmd.Parameters.AddWithValue("@COD_ARTICULO", acmTo.COD_ARTICULO);

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
        public DataTable obtenerArticuloContenidoMovimientoxNroNotaIngDAL(articuloContenidoMovimientoTo acmTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_ARTICULO_CONTENIDO_MOVIMIENTO_X_NRO_NOTA_ING", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_NOTA_ING", acmTo.NRO_NOTA_ING);

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
        public bool insertarArticuloContenidoMovimientoDAL(articuloContenidoMovimientoTo acmTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_ARTICULO_CONTENIDO_MOVIMIENTO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_NOTA_ING", acmTo.NRO_NOTA_ING);
            cmd.Parameters.AddWithValue("@COD_ARTICULO", acmTo.COD_ARTICULO);
            cmd.Parameters.AddWithValue("@COD_ART_CONTENIDO", acmTo.COD_ART_CONTENIDO);
            cmd.Parameters.AddWithValue("@CANTIDAD", acmTo.CANTIDAD);
            cmd.Parameters.AddWithValue("@SITUACION", acmTo.SITUACION);
            cmd.Parameters.AddWithValue("@COD_USU_CREA", acmTo.COD_USU_CREA);
            cmd.Parameters.AddWithValue("@FECHA_CREA", acmTo.FECHA_CREA);

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
        public bool modificarArticuloContenidoMovimientoDAL(articuloContenidoMovimientoTo acmTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_ARTICULO_CONTENIDO_MOVIMIENTO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_NOTA_ING", acmTo.NRO_NOTA_ING);
            cmd.Parameters.AddWithValue("@COD_ARTICULO", acmTo.COD_ARTICULO);
            cmd.Parameters.AddWithValue("@COD_ART_CONTENIDO", acmTo.COD_ART_CONTENIDO);
            cmd.Parameters.AddWithValue("@CANTIDAD", acmTo.CANTIDAD);
            cmd.Parameters.AddWithValue("@SITUACION", acmTo.SITUACION);
            cmd.Parameters.AddWithValue("@COD_USU_CREA", acmTo.COD_USU_CREA);
            cmd.Parameters.AddWithValue("@FECHA_CREA", acmTo.FECHA_CREA);

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
        public bool eliminarArticuloContenidoMovimientoDAL(articuloContenidoMovimientoTo acmTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_ARTICULO_CONTENIDO_MOVIMIENTO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_NOTA_ING", acmTo.NRO_NOTA_ING);
            cmd.Parameters.AddWithValue("@COD_ARTICULO", acmTo.COD_ARTICULO);

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
        public bool eliminarArticuloDevolucionContenidoMovimientoDAL(articuloContenidoMovimientoTo acmTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_ARTICULO_DEVOLUCION_CONTENIDO_MOVIMIENTO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_NOTA_ING", acmTo.NRO_NOTA_ING);

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
        public DataTable obtenerResumenArticuloContenidoMovimientoDAL(articuloContenidoMovimientoTo acmTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_RESUMEN_ARTICULO_CONTENIDO_MOVIMIENTO_X_SITUACION", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_ARTICULO", acmTo.COD_ARTICULO);
            cmd.Parameters.AddWithValue("@FE_DESDE", acmTo.FE_DESDE);
            cmd.Parameters.AddWithValue("@FE_HASTA", acmTo.FE_HASTA);
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
