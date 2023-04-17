using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class numeracionComprobanteDAL
    {
        SqlConnection conn;
        public numeracionComprobanteDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerNumeracionComprobanteDAL(numeracionComprobanteTo ncTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_NUMERACION_COMPROBANTE", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ST_SUSPENDIDO", ncTo.ST_SUSPENDIDO);
            cmd.Parameters.AddWithValue("@AÑO", ncTo.AÑO);
            cmd.Parameters.AddWithValue("@MES", ncTo.MES);
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

        public bool insertarNumeracionComprobanteDAL(numeracionComprobanteTo ncTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_NUMERACION_COMPROBANTE", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_VEN", ncTo.COD_VEN);
            cmd.Parameters.AddWithValue("@NOM_VEN", ncTo.NOM_VEN);
            cmd.Parameters.AddWithValue("@FEC_COMPROBANTE", ncTo.FEC_COMPROBANTE);
            cmd.Parameters.AddWithValue("@NRO_INI", ncTo.NRO_INI);
            cmd.Parameters.AddWithValue("@NRO_FIN", ncTo.NRO_FIN);
            cmd.Parameters.AddWithValue("@ST_SUSPENDIDO", ncTo.ST_SUSPENDIDO);
            cmd.Parameters.AddWithValue("@AÑO", ncTo.AÑO);
            cmd.Parameters.AddWithValue("@MES", ncTo.MES);
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
        public bool modificarNumeracionComprobanteDAL(numeracionComprobanteTo ncTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_NUMERACION_COMPROBANTE", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_VEN", ncTo.COD_VEN);
            cmd.Parameters.AddWithValue("@NOM_VEN", ncTo.NOM_VEN);
            cmd.Parameters.AddWithValue("@FEC_COMPROBANTE", ncTo.FEC_COMPROBANTE);
            cmd.Parameters.AddWithValue("@NRO_INI", ncTo.NRO_INI);
            cmd.Parameters.AddWithValue("@NRO_FIN", ncTo.NRO_FIN);
            cmd.Parameters.AddWithValue("@ST_SUSPENDIDO", ncTo.ST_SUSPENDIDO);
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
        public bool eliminarNumeracionComprobanteDAL(numeracionComprobanteTo ncTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_NUMERACION_COMPROBANTE", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_VEN", ncTo.COD_VEN);
            cmd.Parameters.AddWithValue("@FEC_COMPROBANTE", ncTo.FEC_COMPROBANTE);
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
        public DataTable obtenerNumeracionporVendedorDAL(numeracionComprobanteTo ncTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_NUMERACION_POR_VENDEDOR", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_VEN", ncTo.COD_VEN);
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
        public DataTable obtenerTodasNumeracionesDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_TODAS_NUMERACIONES", conn);
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
        public DataTable obtenerNumeracionporVendedorconNumeracionVendedorDAL(numeracionComprobanteTo ncTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_NUMERACION_POR_VENDEDOR_CON_NUMERACION_VENDEDOR", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_VEN", ncTo.COD_VEN);
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
        public DataTable obtenerNumeracionporDirectorDAL(numeracionComprobanteTo ncTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_DIRECTORES_PARA_CREAR_EQVENTAS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_VEN", ncTo.COD_VEN);
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
        public int verificaNumeracionComprobanteDAL(numeracionComprobanteTo ncTo)
        {
            int val = -1;
            SqlCommand cmd = new SqlCommand("VERIFICA_NUMERACION_COMPROBANTE", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_VEN", ncTo.COD_VEN);
            cmd.Parameters.AddWithValue("@FEC_COMPROBANTE", ncTo.FEC_COMPROBANTE);
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
        public bool desSustituirNumeracionComprobanteDAL(numeracionComprobanteTo ncTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("DESSUSTITUIR_NUMERACION_COMPROBANTE", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_VEN", ncTo.COD_VEN);
            cmd.Parameters.AddWithValue("@FEC_COMPROBANTE", ncTo.FEC_COMPROBANTE);
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
