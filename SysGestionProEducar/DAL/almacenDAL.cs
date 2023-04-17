using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class almacenDAL
    {
        SqlConnection conn;
        public almacenDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        //PARA TIPO ALMACEN
        public DataTable obtenerTipoAlmacenesDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_TIPO_ALMACEN", conn);
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
        public bool insertaTipoAlmacenDAL(almacenTo almTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_TIPO_ALMACEN", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_TIPO", almTo.COD_TIPO);
            cmd.Parameters.AddWithValue("@DESC_TIPO", almTo.DESC_TIPO);
            cmd.Parameters.AddWithValue("@DESC_CORTA", almTo.DESC_CORTA);
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
        public bool modificaTipoAlmacenDAL(almacenTo almTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_TIPO_ALMACEN", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_TIPO", almTo.COD_TIPO);
            cmd.Parameters.AddWithValue("@DESC_TIPO", almTo.DESC_TIPO);
            cmd.Parameters.AddWithValue("@DESC_CORTA", almTo.DESC_CORTA);
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
        public bool eliminaTipoAlmacenDAL(almacenTo almTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_TIPO_ALMACEN", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_TIPO", almTo.COD_TIPO);
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
        public int verificaTipoAlmacenDAL(almacenTo almTo, ref string errMensaje)
        {
            int cant = -1;
            SqlCommand cmd = new SqlCommand("VERIFICAR_TIPO_ALMACEN", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_TIPO", almTo.COD_TIPO);
            try
            {
                conn.Open();
                cant = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception e)
            {
                errMensaje = e.Message;
                cant = -1;
            }
            finally
            {
                conn.Close();
            }
            return cant;
        }
        //PARA ALMACEN
        public DataTable obtenerAlmacenesDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_ALMACEN", conn);
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
        public bool insertaAlmacenDAL(almacenTo almTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_ALMACEN", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_ALMACEN", almTo.COD_ALMACEN);
            cmd.Parameters.AddWithValue("@DESC_ALMACEN", almTo.DESC_ALMACEN);
            cmd.Parameters.AddWithValue("@DESC_CORTA", almTo.DESC_CORTA);
            cmd.Parameters.AddWithValue("@COD_TIPO", almTo.COD_TIPO);
            cmd.Parameters.AddWithValue("@COD_CLASE", almTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@STATUS_SUCURSAL", almTo.STATUS_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", almTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@LOCALIDAD", almTo.LOCALIDAD);
            cmd.Parameters.AddWithValue("@DIRECCION", almTo.DIRECCION);
            cmd.Parameters.AddWithValue("@TELEFONO", almTo.TELEFONO);
            cmd.Parameters.AddWithValue("@STATUS_PICKING", almTo.STATUS_PICKING);
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
        public bool modificaAlmacenDAL(almacenTo almTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_ALMACEN", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_ALMACEN", almTo.COD_ALMACEN);
            cmd.Parameters.AddWithValue("@DESC_ALMACEN", almTo.DESC_ALMACEN);
            cmd.Parameters.AddWithValue("@DESC_CORTA", almTo.DESC_CORTA);
            cmd.Parameters.AddWithValue("@COD_TIPO", almTo.COD_TIPO);
            cmd.Parameters.AddWithValue("@COD_CLASE", almTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@STATUS_SUCURSAL", almTo.STATUS_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", almTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@LOCALIDAD", almTo.LOCALIDAD);
            cmd.Parameters.AddWithValue("@DIRECCION", almTo.DIRECCION);
            cmd.Parameters.AddWithValue("@TELEFONO", almTo.TELEFONO);
            cmd.Parameters.AddWithValue("@STATUS_PICKING", almTo.STATUS_PICKING);
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
        public bool eliminaAlmacenDAL(almacenTo almTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_ALMACEN", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_ALMACEN", almTo.COD_ALMACEN);
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
        public int verificaAlmacenDAL(almacenTo almTo, ref string errMensaje)
        {
            int cant = -1;
            SqlCommand cmd = new SqlCommand("VERIFICAR_ALMACEN", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_ALMACEN", almTo.COD_ALMACEN);
            try
            {
                conn.Open();
                cant = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception e)
            {
                errMensaje = e.Message;
                cant = -1;
            }
            finally
            {
                conn.Close();
            }
            return cant;
        }
        public DataTable obtenerAlmacenesparaArticuloDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("CBO_ALMACEN2", conn);
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
        public DataTable obtenerAlmacenesparaInventarioDAL(almacenTo almTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("CBO_ALMACEN", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_CLASE", almTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", almTo.COD_SUCURSAL);
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
        public DataTable obtenerUbicacionArticuloDAL(almacenTo almTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("CBO_ALMACEN", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_CLASE", almTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", almTo.COD_SUCURSAL);
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
