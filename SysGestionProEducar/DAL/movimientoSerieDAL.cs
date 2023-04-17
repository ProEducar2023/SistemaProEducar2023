using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class movimientoSerieDAL
    {
        SqlConnection conn;
        public movimientoSerieDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerMovimientoSerieDAL(string COD_MOV)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_MOVIMIENTO_SERIE", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_MOV", COD_MOV);
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
        public bool insertarMovimientoSerieDAL(movimientoSerieTo mosTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_MOVIMIENTOS_SERIE", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", mosTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_MOV", mosTo.COD_MOV);
            cmd.Parameters.AddWithValue("@COD_DOC", mosTo.COD_DOC);
            cmd.Parameters.AddWithValue("@STATUS_DOC", mosTo.STATUS_DOC);
            cmd.Parameters.AddWithValue("@SERIE", mosTo.SERIE);
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
        public bool eliminarMovimientoSerieDAL(movimientoSerieTo mosTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_MOVIMIENTOS_SERIE", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_MOV", mosTo.COD_MOV);
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
        public DataTable obtenerMovimientoSerieparaInventarioDAL(movimientoSerieTo mosTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("CBO_NRO_MOVIMIENTO_SERIE", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", mosTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_MOV", mosTo.COD_MOV);
            cmd.Parameters.AddWithValue("@STATUS_DOC", mosTo.STATUS_DOC);
            cmd.Parameters.AddWithValue("@COD_DOC", mosTo.COD_DOC);
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
        public DataTable CBO_NRO_MOVIMIENTO_SERIE_DAL(movimientoSerieTo mosTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("CBO_NRO_MOVIMIENTO_SERIE", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", mosTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_MOV", mosTo.COD_MOV);
            cmd.Parameters.AddWithValue("@STATUS_DOC", mosTo.STATUS_DOC);
            cmd.Parameters.AddWithValue("@COD_DOC", mosTo.COD_DOC);
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
