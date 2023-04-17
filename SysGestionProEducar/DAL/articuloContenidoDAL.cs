using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class articuloContenidoDAL
    {
        SqlConnection conn;
        public articuloContenidoDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerArticuloContenidoDAL(articuloContenidoTo arcTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_ARTICULO_CONTENIDO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_ARTICULO", arcTo.COD_ARTICULO);
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
        public bool insertaArticuloContenidoDAL(articuloContenidoTo arcTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_ARTICULO_CONTENIDO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_ARTICULO", arcTo.COD_ARTICULO);
            cmd.Parameters.AddWithValue("@COD_ART_CONTENIDO", arcTo.COD_ART_CONTENIDO);
            cmd.Parameters.AddWithValue("@DESC_ARTICULO", arcTo.DESC_ARTICULO);
            cmd.Parameters.AddWithValue("@ST_SUSPENDIDO", arcTo.ST_SUSPENDIDO);
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
        public bool modificaArticuloContenidoDAL(articuloContenidoTo arcTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_ARTICULO_CONTENIDO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_ARTICULO", arcTo.COD_ARTICULO);
            cmd.Parameters.AddWithValue("@COD_ART_CONTENIDO", arcTo.COD_ART_CONTENIDO);
            cmd.Parameters.AddWithValue("@DESC_ARTICULO", arcTo.DESC_ARTICULO);
            cmd.Parameters.AddWithValue("@ST_SUSPENDIDO", arcTo.ST_SUSPENDIDO);
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
        public bool eliminaArticuloContenidoDAL(articuloContenidoTo arcTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_ARTICULO_CONTENIDO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_ARTICULO", arcTo.COD_ARTICULO);
            //cmd.Parameters.AddWithValue("@COD_ART_CONTENIDO", arcTo.COD_ART_CONTENIDO);
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
