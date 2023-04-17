using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class articuloClaseDAL
    {
        SqlConnection conn;
        public articuloClaseDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerArticuloClaseDAL(articuloClaseTo arcTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_ARTICULO_CLASE", conn);
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
        public DataTable obtenerArticuloClaseparaInventarioDAL(articuloClaseTo arcTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_DGW_ARTICULOS_CLASE", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_CLASE", arcTo.COD_CLASE);
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
        public bool insertaArticuloClaseDAL(articuloClaseTo arcTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_ARTICULO_CLASE", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_articulo", arcTo.COD_ARTICULO);
            cmd.Parameters.AddWithValue("@COD_CLASE", arcTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_grupo", arcTo.COD_GRUPO);
            cmd.Parameters.AddWithValue("@COD_subgrupo", arcTo.COD_SUBGRUPO);
            cmd.Parameters.AddWithValue("@min", arcTo.STOCK_MINIMO);
            cmd.Parameters.AddWithValue("@max", arcTo.STOCK_MAXIMO);
            cmd.Parameters.AddWithValue("@F_CONV1", arcTo.FACTOR_CONVERSION1);
            cmd.Parameters.AddWithValue("@U_MEDIDA1", arcTo.U_MEDIDA1);
            cmd.Parameters.AddWithValue("@F_CONV2", arcTo.FACTOR_CONVERSION2);
            cmd.Parameters.AddWithValue("@U_MEDIDA2", arcTo.U_MEDIDA2);
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
        public bool eliminaArticuloClaseDAL(string COD_ARTICULO, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_ARTICULO_CLASE", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_articulo", COD_ARTICULO);

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
        public DataTable obtenerDGW_Articulos_ClaseDAL(articuloClaseTo arcTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_DGW_ARTICULOS_CLASE", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_CLASE", arcTo.COD_CLASE);
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
            return dt;
        }
        public DataTable MOSTRAR_DGW_ARTICULOS_CLASE_GRUPO_DAL(articuloClaseTo arcTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_DGW_ARTICULOS_CLASE_GRUPO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_CLASE", arcTo.COD_CLASE);
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
            return dt;
        }
        public DataTable obtenerArticuloClaseparaCostosDAL(articuloClaseTo arcTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("CBO_CLASE", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_USU", arcTo.COD_USU);
            cmd.Parameters.AddWithValue("@TIPO_USU", arcTo.TIPO_USU);
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
        public DataTable obtenerArticuloClaseparaCostoPromedioDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("CBO_CLASE0", conn);
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
        public DataTable obtenerArticuloClaseparaCostoPromedioUMDAL(articuloClaseTo arcTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_DGW_ARTICULOS_CLASE_UM", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_CLASE", arcTo.COD_CLASE);
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
