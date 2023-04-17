using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class multiUsoDAL
    {
        SqlConnection conn;
        public multiUsoDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerTablaPorGrupoDAL(multiUsoTo mulTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_TABLA_POR_GRUPO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_GRUPO", mulTo.COD_GRUPO);
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
        public bool insertarTablaPorGrupoDAL(multiUsoTo mulTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_TABLA_POR_GRUPO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_GRUPO", mulTo.COD_GRUPO);
            cmd.Parameters.AddWithValue("@DES_GRUPO", mulTo.DES_GRUPO);
            cmd.Parameters.AddWithValue("@COD_SUBGRUPO", mulTo.COD_SUBGRUPO);
            cmd.Parameters.AddWithValue("@DES_SUBGRUPO", mulTo.DES_SUBGRUPO);
            cmd.Parameters.AddWithValue("@DES_CORTA", mulTo.DES_CORTA);
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
        public bool modificarTablaPorGrupoDAL(multiUsoTo mulTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_TABLA_POR_GRUPO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_GRUPO", mulTo.COD_GRUPO);
            cmd.Parameters.AddWithValue("@DES_GRUPO", mulTo.DES_GRUPO);
            cmd.Parameters.AddWithValue("@COD_SUBGRUPO", mulTo.COD_SUBGRUPO);
            cmd.Parameters.AddWithValue("@DES_SUBGRUPO", mulTo.DES_SUBGRUPO);
            cmd.Parameters.AddWithValue("@DES_CORTA", mulTo.DES_CORTA);
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
        public bool eliminarTablaPorGrupoDAL(multiUsoTo mulTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_TABLA_POR_GRUPO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_GRUPO", mulTo.COD_GRUPO);
            cmd.Parameters.AddWithValue("@COD_SUBGRUPO", mulTo.COD_SUBGRUPO);
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
