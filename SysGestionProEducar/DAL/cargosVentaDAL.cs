using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class cargosVentaDAL
    {
        SqlConnection conn;
        public cargosVentaDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerCargosVentaDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("aesOBTENER_CARGOS_VENTA", conn);
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
        public bool insertaCargosVentaDAL(cargosVentaTo cavTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("aesINSERTA_CARGOS_VENTA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_CARGO", cavTo.COD_CARGO);
            cmd.Parameters.AddWithValue("@DESC_CARGO", cavTo.DESC_CARGO);
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
        public bool modificaCargosVentaDAL(cargosVentaTo cavTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("aesMODIFICA_CARGOS_VENTA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_CARGO", cavTo.COD_CARGO);
            cmd.Parameters.AddWithValue("@DESC_CARGO", cavTo.DESC_CARGO);
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
        public bool eliminaCargosVentaDAL(cargosVentaTo cavTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("aesELIMINA_CARGOS_VENTA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_CARGO", cavTo.COD_CARGO);
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
