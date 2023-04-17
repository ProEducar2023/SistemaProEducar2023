using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class vendedorDAL
    {
        SqlConnection conn;
        public vendedorDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerVendedorDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR__VENDEDOR", conn);
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
        public bool insertarVendedorDAL(vendedorTo venTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_VENDEDOR", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_VEND", venTo.COD_VEND);
            cmd.Parameters.AddWithValue("@COD_DIRNAC", venTo.COD_DIRNAC);
            cmd.Parameters.AddWithValue("@COD_DIR", venTo.COD_DIR);
            cmd.Parameters.AddWithValue("@COD_SUP", venTo.COD_SUP);
            cmd.Parameters.AddWithValue("@DESC_VEND", venTo.DESC_VEND);
            cmd.Parameters.AddWithValue("@DESC_CORTA", venTo.DESC_CORTA);
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
        public bool modificarVendedorDAL(vendedorTo venTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_VENDEDOR", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_VEND", venTo.COD_VEND);
            cmd.Parameters.AddWithValue("@COD_DIRNAC", venTo.COD_DIRNAC);
            cmd.Parameters.AddWithValue("@COD_DIR", venTo.COD_DIR);
            cmd.Parameters.AddWithValue("@COD_SUP", venTo.COD_SUP);
            cmd.Parameters.AddWithValue("@DESC_VEND", venTo.DESC_VEND);
            cmd.Parameters.AddWithValue("@DESC_CORTA", venTo.DESC_CORTA);
            cmd.Parameters.AddWithValue("@STATUS_ACT", venTo.STATUS_ACT);
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
        public bool eliminarVendedorDAL(vendedorTo venTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_VENDEDOR", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_VEND", venTo.COD_VEND);
            cmd.Parameters.AddWithValue("@COD_DIRNAC", venTo.COD_DIRNAC);
            cmd.Parameters.AddWithValue("@COD_DIR", venTo.COD_DIR);
            cmd.Parameters.AddWithValue("@COD_SUP", venTo.COD_SUP);
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
