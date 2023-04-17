using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class lugarVentaDAL
    {
        SqlConnection conn;
        public lugarVentaDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerLugarVentaDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_LUGAR_VENTA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@COD_INSTITUCION",lgvTo.COD_INSTITUCION);
            //cmd.Parameters.AddWithValue("@COD_PTO_VTA", lgvTo.COD_PTO_VTA);
            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr, LoadOption.Upsert);
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
        public bool insertarLugarVentaDAL(lugarVentaTo lgvTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_LUGAR_VENTA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_INSTITUCION", lgvTo.COD_INSTITUCION);
            cmd.Parameters.AddWithValue("@COD_PTO_VTA", lgvTo.COD_PTO_VTA);
            cmd.Parameters.AddWithValue("@COD_LUG_VTA", lgvTo.COD_LUG_VTA);
            cmd.Parameters.AddWithValue("@DESC_LUG_VTA", lgvTo.DESC_LUG_VTA);
            cmd.Parameters.AddWithValue("@DIRECCION", lgvTo.DIRECCION);
            cmd.Parameters.AddWithValue("@LOCALIDAD", lgvTo.LOCALIDAD);
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
        public bool modificarLugarVentaDAL(lugarVentaTo lgvTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_LUGAR_VENTA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_INSTITUCION", lgvTo.COD_INSTITUCION);
            cmd.Parameters.AddWithValue("@COD_PTO_VTA", lgvTo.COD_PTO_VTA);
            cmd.Parameters.AddWithValue("@COD_LUG_VTA", lgvTo.COD_LUG_VTA);
            cmd.Parameters.AddWithValue("@DESC_LUG_VTA", lgvTo.DESC_LUG_VTA);
            cmd.Parameters.AddWithValue("@DIRECCION", lgvTo.DIRECCION);
            cmd.Parameters.AddWithValue("@LOCALIDAD", lgvTo.LOCALIDAD);
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
        public string obtenerCodLugVenBLL(lugarVentaTo lgvTo)
        {
            string val = "";
            SqlCommand cmd = new SqlCommand("OBTENER_NUEVO_COD_LUG_VTA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_INSTITUCION", lgvTo.COD_INSTITUCION);
            cmd.Parameters.AddWithValue("@COD_PTO_VTA", lgvTo.COD_PTO_VTA);
            try
            {
                conn.Open();
                val = cmd.ExecuteScalar().ToString();
            }
            catch (Exception)
            {
                val = "";
            }
            finally
            {
                conn.Close();
            }
            return val;
        }
        public bool eliminarLugarVentaDAL(lugarVentaTo lgvTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_LUGAR_VENTA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_INSTITUCION", lgvTo.COD_INSTITUCION);
            cmd.Parameters.AddWithValue("@COD_PTO_VTA", lgvTo.COD_PTO_VTA);
            cmd.Parameters.AddWithValue("@COD_LUG_VTA", lgvTo.COD_LUG_VTA);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception e)
            {
                errMensaje = e.Message;
                flag = false;
            }
            finally
            {
                conn.Close();
            }
            return flag;
        }
        public DataTable obtenerLugarVentaCodInsCodPtoVtaDAL(lugarVentaTo lgvTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_LUGAR_VENTA_X_INST_PTO_VTA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_INSTITUCION", lgvTo.COD_INSTITUCION);
            cmd.Parameters.AddWithValue("@COD_PTO_VTA", lgvTo.COD_PTO_VTA);
            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr, LoadOption.Upsert);
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
        public DataTable obtenerLugVentaPtoVentaDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_LUG_VTA_PTO_VTA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr, LoadOption.Upsert);
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
