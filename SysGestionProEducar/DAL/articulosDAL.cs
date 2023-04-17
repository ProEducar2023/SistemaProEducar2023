using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class articulosDAL
    {
        SqlConnection conn;
        public articulosDAL()
        {
            conn = new SqlConnection(conexion.con);
        }

        //public List<articulosTo> obtenerArticulosAll()
        //{
        //    List<articulosTo> art = new List<articulosTo>();
        //    SqlCommand cmd = new SqlCommand("selectObtenerPedidosporNroped", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    //cmd.Parameters.AddWithValue("@Im21numped", pedTo.Im21numped);


        //    return art;

        //}
        public DataTable obtenerArticulosDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_ARTICULO", conn);
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
        public bool insertaArticuloDAL(articulosTo artTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_ARTICULO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_ARTICULO", artTo.COD_ARTICULO);
            cmd.Parameters.AddWithValue("@DESC_ARTICULO", artTo.DESC_ARTICULO);
            cmd.Parameters.AddWithValue("@NRO_PARTE", artTo.NRO_PARTE);
            cmd.Parameters.AddWithValue("@DESC_APLICACION", artTo.DESC_APLICACION);
            cmd.Parameters.AddWithValue("@UNIDAD_MEDIDA", artTo.UNIDAD_MEDIDA);
            cmd.Parameters.AddWithValue("@IGV", artTo.STATUS_IGV);
            cmd.Parameters.AddWithValue("@SUS", artTo.STATUS_SUSPENDIDO);
            cmd.Parameters.AddWithValue("@OBS", artTo.OBSERVACION);
            cmd.Parameters.AddWithValue("@COD_EQUIVALENTE", artTo.COD_EQUIVALENTE);
            cmd.Parameters.AddWithValue("@STATUS_SERIE", artTo.STATUS_SERIE);
            cmd.Parameters.AddWithValue("@IMAGEN", artTo.IMAGEN);
            cmd.Parameters.AddWithValue("@STATUS_DETALLE", artTo.STATUS_DETALLE);
            //cmd.CommandTimeout = 720;
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
        public bool modificaArticuloDAL(articulosTo artTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_ARTICULO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cod_articulo", artTo.COD_ARTICULO);
            cmd.Parameters.AddWithValue("@DESC_articulo", artTo.DESC_ARTICULO);
            cmd.Parameters.AddWithValue("@NRO_PARTE", artTo.NRO_PARTE);
            cmd.Parameters.AddWithValue("@DESC_APLICACION", artTo.DESC_APLICACION);
            cmd.Parameters.AddWithValue("@UNIDAD_MEDIDA", artTo.UNIDAD_MEDIDA);
            cmd.Parameters.AddWithValue("@IGV", artTo.STATUS_IGV);
            cmd.Parameters.AddWithValue("@SUS", artTo.STATUS_SUSPENDIDO);
            cmd.Parameters.AddWithValue("@OBS", artTo.OBSERVACION);
            cmd.Parameters.AddWithValue("@COD_EQUIVALENTE", artTo.COD_EQUIVALENTE);
            cmd.Parameters.AddWithValue("@STATUS_SERIE", artTo.STATUS_SERIE);
            cmd.Parameters.AddWithValue("@IMAGEN", artTo.IMAGEN);
            cmd.Parameters.AddWithValue("@STATUS_DETALLE", artTo.STATUS_DETALLE);
            //cmd.CommandTimeout = 720;
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
        public bool eliminaArticuloDAL(string COD_ARTICULO, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_ARTICULO", conn);
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
        public string obtenerNuevoCodigoDAL()
        {
            string codi = "";
            SqlCommand cmd = new SqlCommand("SGT_ARTICULO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                codi = cmd.ExecuteScalar().ToString();
            }
            catch (Exception)
            {
                codi = "";
            }
            finally
            {
                conn.Close();
            }
            return codi;
        }
        public string obtenerImagenDAL(articulosTo artTo)
        {
            string cad = string.Empty;
            SqlCommand cmd = new SqlCommand("MOSTRAR_DIRECTORIO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TABLE_COD", artTo.DESC_APLICACION);
            cmd.Parameters.AddWithValue("@CODIGO", artTo.DESC_ARTICULO);
            try
            {
                conn.Open();
                cad = cmd.ExecuteScalar().ToString();
            }
            catch (Exception)
            {
                cad = "";
            }
            finally
            {
                conn.Close();
            }
            return cad;
        }
        public bool adicionaArticuloCaracteristicaDAL(string COD_ARTICULO, string DESC_CARACTERISTICA, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_ARTICULO_CARACTERISTICA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_ARTICULO", COD_ARTICULO);
            cmd.Parameters.AddWithValue("@DESC_CARACTERISTICA", DESC_CARACTERISTICA);
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
        public bool modificaArticuloCaracteristicaDAL(string COD_ARTICULO, string DESC_CARACTERISTICA, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_ARTICULO_CARACTERISTICA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_ARTICULO", COD_ARTICULO);
            cmd.Parameters.AddWithValue("@DESC_CARACTERISTICA", DESC_CARACTERISTICA);
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
        public bool eliminaArticuloCaracteristicaDAL(string COD_ARTICULO, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_ARTICULO_CARACTERISTICA", conn);
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
        public DataTable obtenerArticulosparaKitDAL(articulosTo art)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("DGW_ARTICULO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_CLASE", art.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_GRUPO", art.COD_GRUPO);
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
        public DataTable CARGAR_SALDOS_CLASE_ARTICULO(string CodigoClase, string CodigoArticulo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("CARGAR_SALDOS_CLASE_ARTICULO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_CLASE", CodigoClase);
            cmd.Parameters.AddWithValue("@COD_ARTICULO", CodigoArticulo);
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
        public DataTable MOSTRAR_ARTICULO_APLICACION(string CodigoArticulo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_ARTICULO_APLICACION", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_ARTICULO", CodigoArticulo);
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
        public string HALLAR_UM_ARTICULO_DAL(string codigoArticulo)
        {
            string val = "";
            SqlCommand cmd = new SqlCommand("HALLAR_UM_ARTICULO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_ARTICULO", codigoArticulo);
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
        public string OBTENER_SALDO_DAL(articulosTo artTo)
        {
            string val = "";
            SqlCommand cmd = new SqlCommand("OBTENER_SALDO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_CLASE", artTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_ALMACEN", artTo.COD_ALMACEN);
            cmd.Parameters.AddWithValue("@COD_ARTICULO", artTo.COD_ARTICULO);
            try
            {
                conn.Open();
                val = cmd.ExecuteScalar().ToString();
            }
            catch (Exception e)
            {
                val = "";
            }
            finally
            {
                conn.Close();
            }
            return val;
        }
        public int VerificaArticuloDAL(articulosTo artTo)
        {
            int val = -1;
            SqlCommand cmd = new SqlCommand("VERIFICAR_ARTICULO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_ARTICULO", artTo.COD_ARTICULO);
            try
            {
                conn.Open();
                val = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception)
            {
                val = -1;
            }
            finally
            {
                conn.Close();
            }
            return val;
        }
        public bool validaEliminarArticuloDAL(articulosTo artTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("VERIFICA_ELIMINA_ARTICULO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_ARTICULO", artTo.COD_ARTICULO);
            try
            {
                conn.Open();
                flag = Convert.ToBoolean(cmd.ExecuteScalar());
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
        public string obtenerSaldoProductoxTransferenciaDAL(articulosTo artTo)
        {
            string val = "0.00";
            SqlCommand cmd = new SqlCommand("OBTENER_SALDO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_CLASE", artTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_ALMACEN", artTo.COD_ALMACEN);
            cmd.Parameters.AddWithValue("@COD_ARTICULO", artTo.COD_ARTICULO);
            try
            {
                conn.Open();
                val = cmd.ExecuteScalar().ToString();
            }
            catch (Exception)
            {
                val = "0.00";
            }
            finally
            {
                conn.Close();
            }
            return val;
        }
        public DataTable obtenerArticulos_con_ContenidoDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_ARTICULOS_CON_CONTENIDO", conn);
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
    }
}
