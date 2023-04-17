using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class modalidadVentaDAL
    {
        SqlConnection conn;
        public modalidadVentaDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerModalidadVentaDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_MODALIDAD_VENTA", conn);
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
        public bool insertarModalidadVentaDAL(modalidadVentaTo mvTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_MODALIDAD_VENTA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_TIPO_VENTA", mvTo.COD_TIPO_VENTA);
            cmd.Parameters.AddWithValue("@COD_MODALIDAD_VTA", mvTo.COD_MODALIDAD_VTA);
            cmd.Parameters.AddWithValue("@DESC_MODALIDAD_VTA", mvTo.DESC_MODALIDAD_VTA);
            cmd.Parameters.AddWithValue("@DESC_CORTA", mvTo.DESC_CORTA);
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
        public bool modificarModalidadVentaDAL(modalidadVentaTo mvTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_MODALIDAD_VENTA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_TIPO_VENTA", mvTo.COD_TIPO_VENTA);
            cmd.Parameters.AddWithValue("@COD_MODALIDAD_VTA", mvTo.COD_MODALIDAD_VTA);
            cmd.Parameters.AddWithValue("@DESC_MODALIDAD_VTA", mvTo.DESC_MODALIDAD_VTA);
            cmd.Parameters.AddWithValue("@DESC_CORTA", mvTo.DESC_CORTA);
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
        public bool eliminarModalidadVentaDAL(modalidadVentaTo mvTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_MODALIDAD_VENTA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@COD_TIPO_VENTA", mvTo.COD_TIPO_VENTA);
            cmd.Parameters.AddWithValue("@COD_MODALIDAD_VTA", mvTo.COD_MODALIDAD_VTA);
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
        public bool ValidarModalidadVentaDAL(modalidadVentaTo mvTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("VERIFICAR_MODALIDAD_VENTA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_MODALIDAD_VTA", mvTo.COD_MODALIDAD_VTA);
            cmd.Parameters.AddWithValue("@COD_TIPO_VENTA", mvTo.COD_TIPO_VENTA);
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
        public DataTable obtenerTipoVentaporCodDAL(modalidadVentaTo mvTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_TIPO_VENTA_POR_CODMOD", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_MODALIDAD_VTA", mvTo.COD_MODALIDAD_VTA);
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
