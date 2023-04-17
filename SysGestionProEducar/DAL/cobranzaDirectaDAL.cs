using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class cobranzaDirectaDAL
    {
        SqlConnection conn;
        public cobranzaDirectaDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public bool insertarCobranzaDirectaDAL(cobranzaDirectaTo codTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_COBRANZA_DIRECTA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", codTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@COD_PERSONA", codTo.COD_PERSONA);
            cmd.Parameters.AddWithValue("@COD_DOC", codTo.COD_DOC);
            cmd.Parameters.AddWithValue("@NRO_DOC", codTo.NRO_DOC);
            cmd.Parameters.AddWithValue("@FECHA_CONTRATO", codTo.FECHA_CONTRATO);
            if (codTo.FECHA_LLAMADA == null)
                cmd.Parameters.AddWithValue("@FECHA_LLAMADA", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@FECHA_LLAMADA", codTo.FECHA_LLAMADA);
            if (codTo.FECHA_CONFIRMADA == null)
                cmd.Parameters.AddWithValue("@FECHA_CONFIRMADA", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@FECHA_CONFIRMADA", codTo.FECHA_CONFIRMADA);
            cmd.Parameters.AddWithValue("@IMPORTE_PAGO", codTo.IMPORTE_PAGO);
            cmd.Parameters.AddWithValue("@TIPO_PLA_ORIGEN", codTo.TIPO_PLA_ORIGEN);
            cmd.Parameters.AddWithValue("@TIPO_PLA_COBRANZA", codTo.TIPO_PLA_COBRANZA);
            cmd.Parameters.AddWithValue("@NRO_LETRA", codTo.NRO_LETRA);
            cmd.Parameters.AddWithValue("@TOTAL_LETRA", codTo.TOTAL_LETRA);
            cmd.Parameters.AddWithValue("@OBSERVACIONES", codTo.OBSERVACIONES);
            cmd.Parameters.AddWithValue("@COD_CREACION", codTo.COD_CREACION);
            cmd.Parameters.AddWithValue("@FECHA_CREACION", codTo.FECHA_CREACION);
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
        public bool eliminarCobranzaDirectaDAL(cobranzaDirectaTo codTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_COBRANZA_DIRECTA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", codTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@COD_PERSONA", codTo.COD_PERSONA);
            cmd.Parameters.AddWithValue("@COD_DOC", codTo.COD_DOC);
            cmd.Parameters.AddWithValue("@NRO_DOC", codTo.NRO_DOC);

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
        public DataTable obtenerCobranzaDirectaporLlaveDAL(cobranzaDirectaTo codTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_COBRANZA_DIRECTA_POR_LLAVE", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", codTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@COD_PERSONA", codTo.COD_PERSONA);
            cmd.Parameters.AddWithValue("@COD_DOC", codTo.COD_DOC);
            cmd.Parameters.AddWithValue("@NRO_DOC", codTo.NRO_DOC);
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
        public bool modificarCobranzaDirectaDAL(cobranzaDirectaTo codTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", codTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@COD_PERSONA", codTo.COD_PERSONA);
            cmd.Parameters.AddWithValue("@COD_DOC", codTo.COD_DOC);
            cmd.Parameters.AddWithValue("@NRO_DOC", codTo.NRO_DOC);
            cmd.Parameters.AddWithValue("@FECHA_CONTRATO", codTo.FECHA_CONTRATO);
            cmd.Parameters.AddWithValue("@FECHA_LLAMADA", codTo.FECHA_LLAMADA);
            cmd.Parameters.AddWithValue("@FECHA_CONFIRMADA", codTo.FECHA_CONFIRMADA);
            cmd.Parameters.AddWithValue("@IMPORTE_PAGO", codTo.IMPORTE_PAGO);
            cmd.Parameters.AddWithValue("@TIPO_PLA_ORIGEN", codTo.TIPO_PLA_ORIGEN);
            cmd.Parameters.AddWithValue("@TIPO_PLA_COBRANZA", codTo.TIPO_PLA_COBRANZA);
            cmd.Parameters.AddWithValue("@NRO_LETRA", codTo.NRO_LETRA);
            cmd.Parameters.AddWithValue("@TOTAL_LETRA", codTo.TOTAL_LETRA);
            cmd.Parameters.AddWithValue("@OBSERVACIONES", codTo.OBSERVACIONES);
            cmd.Parameters.AddWithValue("@COD_CREACION", codTo.COD_CREACION);
            cmd.Parameters.AddWithValue("@FECHA_CREACION", codTo.FECHA_CREACION);
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
        public DataTable obtenerCobranzaDirectaparaConfirmacionDAL(cobranzaDirectaTo codTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_COBRANZA_DIRECTA_PARA_CONFIRMACION", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FECHA_CONFIRMADA", codTo.FECHA_CONFIRMADA);
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
        public DataTable MOSTRAR_CUENTA_BANCO_DAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_CUENTA_BANCO", conn);
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
        public bool modificaTCobranzaDirectaporCorfirmacionDAL(cobranzaDirectaTo codTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_COBRANZA_DIRECTA_POR_CONFIRMACION", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", codTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@NRO_DOC", codTo.NRO_DOC);
            if (codTo.NRO_OPERACION == null)
                cmd.Parameters.AddWithValue("@NRO_OPERACION", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@NRO_OPERACION", codTo.NRO_OPERACION);
            if (codTo.FECHA_OPERACION == null)
                cmd.Parameters.AddWithValue("FECHA_OPERACION", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@FECHA_OPERACION", codTo.FECHA_OPERACION);
            if (codTo.COD_BANCO == null)
                cmd.Parameters.AddWithValue("@COD_BANCO", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@COD_BANCO", codTo.COD_BANCO);
            if (codTo.COD_LLAMADA == null)
                cmd.Parameters.AddWithValue("@COD_LLAMADA", codTo.COD_LLAMADA);
            else
                cmd.Parameters.AddWithValue("@COD_LLAMADA", codTo.COD_LLAMADA);
            if (codTo.FECHA_NUEVA_LLAMADA == null)
                cmd.Parameters.AddWithValue("@FECHA_NUEVA_LLAMADA", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@FECHA_NUEVA_LLAMADA", codTo.FECHA_NUEVA_LLAMADA);
            if (codTo.IMPORTE_DEPOSITADO == null)
                cmd.Parameters.AddWithValue("@IMPORTE_DEPOSITADO", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@IMPORTE_DEPOSITADO", codTo.IMPORTE_DEPOSITADO);
            if (codTo.OBSERVACIONES == null)
                cmd.Parameters.AddWithValue("@OBSERVACIONES", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@OBSERVACIONES", codTo.OBSERVACIONES);
            cmd.Parameters.AddWithValue("@COD_MOD", codTo.COD_MOD);
            cmd.Parameters.AddWithValue("@FECHA_MOD", codTo.FECHA_MOD);
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
        public bool modificaTCobranzaDirectaporCierreDAL(cobranzaDirectaTo codTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_T_COBRANZA_DIRECTA_POR_CIERRE", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", codTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@NRO_DOC", codTo.NRO_DOC);
            if (codTo.FECHA_CONFIRMADA == null)
                cmd.Parameters.AddWithValue("@FECHA_CONFIRMADA", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@FECHA_CONFIRMADA", codTo.FECHA_CONFIRMADA);
            if (codTo.FECHA_NUEVA_LLAMADA == null)
                cmd.Parameters.AddWithValue("@FECHA_NUEVA_LLAMADA", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@FECHA_NUEVA_LLAMADA", codTo.FECHA_NUEVA_LLAMADA);
            if (codTo.STATUS_CONFIRMACION == null)
                cmd.Parameters.AddWithValue("@STATUS_CONFIRMACION", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@STATUS_CONFIRMACION", codTo.STATUS_CONFIRMACION);
            cmd.Parameters.AddWithValue("@COD_MOD", codTo.COD_MOD);
            cmd.Parameters.AddWithValue("@FECHA_MOD", codTo.FECHA_MOD);
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
        public DataTable obtenerCobranzaDirectaparaCobranzaDAL(cobranzaDirectaTo codTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_T_COBRANZA_DIRECTA_PARA_COBRANZA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_LLAMADA", codTo.COD_LLAMADA);
            cmd.Parameters.AddWithValue("@STATUS_CONFIRMACION", codTo.STATUS_CONFIRMACION);
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
        public bool exiseTCobranzaDirectaDAL(cobranzaDirectaTo codTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("VERIFICA_EXISTE_T_COBRANZA_DIRECTA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", codTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@COD_PERSONA", codTo.COD_PERSONA);
            cmd.Parameters.AddWithValue("@COD_DOC", codTo.COD_DOC);
            cmd.Parameters.AddWithValue("@NRO_DOC", codTo.NRO_DOC);
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
    }
}
