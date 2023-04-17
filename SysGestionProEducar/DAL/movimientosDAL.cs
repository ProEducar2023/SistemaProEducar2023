using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class movimientosDAL
    {
        SqlConnection conn;
        public movimientosDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerMovimientosDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_MOVIMIENTOS", conn);
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
        public DataTable obtenerMovimientosparaPedidoDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("CBO_MOVIMIENTOS_PEDIDO", conn);
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
        public DataTable obtenerMovimientosparaInventarioDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("CBO_MOVIMIENTOS_INGRESO_DI", conn);
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
        public DataTable obtenerMovimientosparaTransferenciaDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("CBO_MOVIMIENTOS_TRANS", conn);
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
        public DataTable obtenerMovimientosparaInventarioSalidaDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("CBO_MOVIMIENTOS_SALIDA_DI", conn);
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
        public bool insertarMovimientosDAL(movimientosTo movTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_MOVIMIENTOS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_MOV", movTo.COD_MOV);
            cmd.Parameters.AddWithValue("@DESC_MOV", movTo.DESC_MOV);
            cmd.Parameters.AddWithValue("@DESC_CORTA", movTo.DESC_CORTA);
            cmd.Parameters.AddWithValue("@TIPO_OPERACION", movTo.TIPO_OPERACION);
            cmd.Parameters.AddWithValue("@CLASE_PERSONA", movTo.CLASE_PERSONA);
            cmd.Parameters.AddWithValue("@TIPO_MOV", movTo.TIPO_MOV);
            cmd.Parameters.AddWithValue("@STATUS_AREA", movTo.STATUS_AREA);
            cmd.Parameters.AddWithValue("@STATUS_OP", movTo.STATUS_OP);
            cmd.Parameters.AddWithValue("@STATUS_MAQ", movTo.STATUS_MAQ);
            cmd.Parameters.AddWithValue("@STATUS_PARTE", movTo.STATUS_PARTE);
            cmd.Parameters.AddWithValue("@STATUS_VC", movTo.STATUS_VALOR_COSTOS);
            cmd.Parameters.AddWithValue("@COD_TC", movTo.COD_TIPO_CONTROL);
            cmd.Parameters.AddWithValue("@COD_SUNAT", movTo.COD_SUNAT);
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
        public bool modificarMovimientosDAL(movimientosTo movTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_MOVIMIENTOS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_MOV", movTo.COD_MOV);
            cmd.Parameters.AddWithValue("@DESC_MOV", movTo.DESC_MOV);
            cmd.Parameters.AddWithValue("@DESC_CORTA", movTo.DESC_CORTA);
            cmd.Parameters.AddWithValue("@TIPO_OPERACION", movTo.TIPO_OPERACION);
            cmd.Parameters.AddWithValue("@CLASE_PERSONA", movTo.CLASE_PERSONA);
            cmd.Parameters.AddWithValue("@TIPO_MOV", movTo.TIPO_MOV);
            cmd.Parameters.AddWithValue("@STATUS_AREA", movTo.STATUS_AREA);
            cmd.Parameters.AddWithValue("@STATUS_OP", movTo.STATUS_OP);
            cmd.Parameters.AddWithValue("@STATUS_MAQ", movTo.STATUS_MAQ);
            cmd.Parameters.AddWithValue("@STATUS_PARTE", movTo.STATUS_PARTE);
            cmd.Parameters.AddWithValue("@STATUS_VC", movTo.STATUS_VALOR_COSTOS);
            cmd.Parameters.AddWithValue("@COD_TC", movTo.COD_TIPO_CONTROL);
            cmd.Parameters.AddWithValue("@COD_SUNAT", movTo.COD_SUNAT);
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
        public bool eliminarMovimientosDAL(movimientosTo movTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_MOVIMIENTOS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_MOV", movTo.COD_MOV);

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
        public string HALLAR_STATUS_COSTOS_DAL(movimientosTo movTo)
        {
            string val = "";
            SqlCommand cmd = new SqlCommand("HALLAR_STATUS_COSTOS_MOV", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_MOV", movTo.COD_MOV);
            try
            {
                conn.Open();
                val = cmd.ExecuteScalar().ToString();
            }
            catch (Exception e)
            {
                val = e.Message;
            }
            finally
            {
                conn.Close();
            }
            return val;
        }
        public DataTable obtenerMovimientosCostosDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("CBO_MOVIMIENTOS", conn);
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
        public string obtenerTipoOperacionDAL(movimientosTo movTo)
        {
            string val = "";
            SqlCommand cmd = new SqlCommand("MOV_TIPO_OPERACION", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_MOV", movTo.COD_MOV);
            try
            {
                conn.Open();
                val = cmd.ExecuteScalar().ToString();
            }
            catch (Exception e)
            {
                val = e.Message;
            }
            finally
            {
                conn.Close();
            }
            return val;
        }
        public DataTable obtenerMovimientosCostosPromedioDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOVXOPERACION_VALORCOSTO", conn);
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
