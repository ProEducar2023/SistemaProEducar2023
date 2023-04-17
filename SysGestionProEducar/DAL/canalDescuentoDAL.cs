using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class canalDescuentoDAL
    {
        SqlConnection conn;
        public canalDescuentoDAL()
        {
            conn = new SqlConnection(conexion.con);
        }

        public DataTable ObtenerCanalDescuentoDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("aesObtenerCanalDescuento", conn);
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
        public bool insertaCanalDescuentoDAL(canalDescuentoTo canTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("aesInsertaCanalDescuento", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD", canTo.COD);
            cmd.Parameters.AddWithValue("@COD_CANAL_DSCTO", canTo.COD_CANAL_DSCTO);
            cmd.Parameters.AddWithValue("@DESCRIPCION", canTo.DESCRIPCION);
            cmd.Parameters.AddWithValue("@DESC_CORTA", canTo.DESC_CORTA);
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
        public bool actualizaCanalDescuentoDAL(canalDescuentoTo canTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("aesActualizaCanalDescuento", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD", canTo.COD);
            cmd.Parameters.AddWithValue("@COD_CANAL_DSCTO", canTo.COD_CANAL_DSCTO);
            cmd.Parameters.AddWithValue("@DESCRIPCION", canTo.DESCRIPCION);
            cmd.Parameters.AddWithValue("@DESC_CORTA", canTo.DESC_CORTA);
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
        public bool eliminaCanalDescuentoDAL(canalDescuentoTo canTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("aesEliminaCanalDescuento", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD", canTo.COD);

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
