using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class articuloUbicacionDAL
    {
        SqlConnection conn;
        public articuloUbicacionDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerArticuloUbicacionDAL(articuloUbicacionTo aruTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_ARTICULO_UBICACION", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_ARTICULO", aruTo.COD_ARTICULO);
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
        public string obtenerArticuloUbicacionparaInventarioDAL(articuloUbicacionTo aruTo)
        {
            string valor = "";
            SqlCommand cmd = new SqlCommand("OBTENER_UBICACION_ARTICULO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_ALMACEN", aruTo.COD_ALMACEN);
            cmd.Parameters.AddWithValue("@COD_ARTICULO", aruTo.COD_ARTICULO);
            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr != null && dr.HasRows)
                {
                    while (dr.Read())
                    {
                        valor += string.Format("{0} / ", dr[0].ToString().Trim());
                    }
                }
                if (valor.Length > 0)
                {
                    valor = valor.Trim().Substring(0, valor.Trim().Length - 2);
                }
                dr.Close();
            }
            catch (Exception)
            {
                valor = "";
            }
            finally
            {
                conn.Close();
            }
            return valor;
        }
        public bool insertaArticuloUbicacionDAL(articuloUbicacionTo aruTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_ARTICULO_UBICACION", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_ARTICULO", aruTo.COD_ARTICULO);
            cmd.Parameters.AddWithValue("@COD_ALMACEN", aruTo.COD_ALMACEN);
            cmd.Parameters.AddWithValue("@ITEM", aruTo.ITEM);
            cmd.Parameters.AddWithValue("@CAMPO1", aruTo.CAMPO1);
            cmd.Parameters.AddWithValue("@CAMPO2", aruTo.CAMPO2);
            cmd.Parameters.AddWithValue("@CAMPO3", aruTo.CAMPO3);
            cmd.Parameters.AddWithValue("@CAMPO4", aruTo.CAMPO4);
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
        public bool eliminaArticuloUbicacionDAL(string COD_ARTICULO, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_ARTICULO_UBICACION", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_ARTICULO", COD_ARTICULO);

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
