using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class tipoVentaDAL
    {
        SqlConnection conn;
        public tipoVentaDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerTipoVentaDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_TIPO_VENTA", conn);
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
        public bool verificaTipoVentaDAL(tipoVentaTo tvTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("VERIFICAR_TIPO_VENTA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_TIPO_VENTA", tvTo.COD_TIPO_VENTA);
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
        public bool insertarTipoVentaDAL(tipoVentaTo tvTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_TIPO_VENTA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_TIPO_VENTA", tvTo.COD_TIPO_VENTA);
            cmd.Parameters.AddWithValue("@DESC_TIPO_VENTA", tvTo.DESC_TIPO_VENTA);
            cmd.Parameters.AddWithValue("@DESC_CORTA", tvTo.DESC_CORTA);
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
        public bool modificarTipoVentaDAL(tipoVentaTo tvTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_TIPO_VENTA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_TIPO_VENTA", tvTo.COD_TIPO_VENTA);
            cmd.Parameters.AddWithValue("@DESC_TIPO_VENTA", tvTo.DESC_TIPO_VENTA);
            cmd.Parameters.AddWithValue("@DESC_CORTA", tvTo.DESC_CORTA);
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
        public bool eliminarTipoVentaDAL(tipoVentaTo tvTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_TIPO_VENTA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_TIPO_VENTA", tvTo.COD_TIPO_VENTA);
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
