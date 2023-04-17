using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class sucursalDAL
    {
        SqlConnection conn;
        public sucursalDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerSucursalDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_SUCURSAL", conn);
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
        public bool insertaSucursalDAL(sucursalTo sucTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_SUCURSAL", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", sucTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@DESC_SUCURSAL", sucTo.DESC_SUCURSAL);
            cmd.Parameters.AddWithValue("@DESC_CORTA", sucTo.DESC_CORTA);
            cmd.Parameters.AddWithValue("@TELEFONO", sucTo.TELEFONO);
            cmd.Parameters.AddWithValue("@DIRECCION", sucTo.DIRECCION);
            cmd.Parameters.AddWithValue("@LOCALIDAD", sucTo.LOCALIDAD);
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
        public bool modificaSucursalDAL(sucursalTo sucTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_SUCURSAL", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", sucTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@DESC_SUCURSAL", sucTo.DESC_SUCURSAL);
            cmd.Parameters.AddWithValue("@DESC_CORTA", sucTo.DESC_CORTA);
            cmd.Parameters.AddWithValue("@TELEFONO", sucTo.TELEFONO);
            cmd.Parameters.AddWithValue("@DIRECCION", sucTo.DIRECCION);
            cmd.Parameters.AddWithValue("@LOCALIDAD", sucTo.LOCALIDAD);
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
        public bool eliminaSucursalDAL(sucursalTo sucTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_SUCURSAL", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", sucTo.COD_SUCURSAL);
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
        public int verificaSucursalDAL(sucursalTo sucTo, ref string errMensaje)
        {
            int cant = -1;
            SqlCommand cmd = new SqlCommand("VERIFICAR_SUCURSAL", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", sucTo.COD_SUCURSAL);
            try
            {
                conn.Open();
                cant = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception e)
            {
                cant = -1;
                errMensaje = e.Message;
            }
            finally
            {
                conn.Close();
            }
            return cant;
        }
    }
}
