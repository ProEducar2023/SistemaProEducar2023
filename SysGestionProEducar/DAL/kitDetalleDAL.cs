using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class kitDetalleDAL
    {
        SqlConnection conn;
        public kitDetalleDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerKitDetalleDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_KIT_DETALLE", conn);
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
        public DataTable obtenerKitDetalleporCodKitDAL(kitDetalleTo kiTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_KIT_DETALLE", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_KIT", kiTo.COD_KIT);
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
        public bool insertarKitDetalleDAL(kitDetalleTo dkiTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_KIT_DETALLE", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_KIT", dkiTo.COD_KIT);
            cmd.Parameters.AddWithValue("@COD_ARTICULO", dkiTo.COD_ARTICULO);
            cmd.Parameters.AddWithValue("@CANTIDAD", dkiTo.CANTIDAD);
            cmd.Parameters.AddWithValue("@PRECIO_UNITARIO", dkiTo.PRECIO_UNITARIO);
            cmd.Parameters.AddWithValue("@FEC_ACTUALIZACION", dkiTo.FEC_ACTUALIZACION);
            cmd.Parameters.AddWithValue("@ST_SUSPENDIDO", dkiTo.ST_SUSPENDIDO);
            cmd.Parameters.AddWithValue("@ST_VALOR_REFERENCIAL", dkiTo.ST_VALOR_REFERENCIAL);
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
        public bool insertarListaPreciosDAL(kitDetalleTo dkiTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_LISTA_PRECIOS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_KIT", dkiTo.COD_KIT);
            cmd.Parameters.AddWithValue("@COD_ARTICULO", dkiTo.COD_ARTICULO);
            //cmd.Parameters.AddWithValue("@CANTIDAD", dkiTo.CANTIDAD);
            cmd.Parameters.AddWithValue("@PRECIO_UNITARIO", dkiTo.PRECIO_UNITARIO);
            cmd.Parameters.AddWithValue("@FEC_ACTUALIZACION", dkiTo.FEC_ACTUALIZACION);
            //cmd.Parameters.AddWithValue("@ST_SUSPENDIDO", dkiTo.ST_SUSPENDIDO);
            //cmd.Parameters.AddWithValue("@ST_VALOR_REFERENCIAL", dkiTo.ST_VALOR_REFERENCIAL);
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
        public bool modificarKitDetalleDAL(kitDetalleTo dkiTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_KIT", dkiTo.COD_KIT);
            cmd.Parameters.AddWithValue("@COD_ARTICULO", dkiTo.COD_ARTICULO);
            cmd.Parameters.AddWithValue("@CANTIDAD", dkiTo.CANTIDAD);
            cmd.Parameters.AddWithValue("@PRECIO_UNITARIO", dkiTo.PRECIO_UNITARIO);
            cmd.Parameters.AddWithValue("@FEC_ACTUALIZACION", dkiTo.FEC_ACTUALIZACION);
            cmd.Parameters.AddWithValue("@ST_SUSPENDIDO", dkiTo.ST_SUSPENDIDO);
            cmd.Parameters.AddWithValue("@ST_VALOR_REFERENCIAL", dkiTo.ST_VALOR_REFERENCIAL);
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
        public bool eliminarKitDetalleDAL(kitDetalleTo dkiTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_KIT_DETALLE", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_KIT", dkiTo.COD_KIT);
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
        public bool eliminarKitDetalleCompletoDAL(kitDetalleTo dkiTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_KIT_DETALLE_COMPLETO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_KIT", dkiTo.COD_KIT);
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
        public DataTable obtenerKitDetalleporCodKit_FechaDAL(kitDetalleTo kiTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_KIT_DETALLE_PORCOD_FECHA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_KIT", kiTo.COD_KIT);
            cmd.Parameters.AddWithValue("@DESDE", kiTo.DESDE);
            cmd.Parameters.AddWithValue("@HASTA", kiTo.HASTA);
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
