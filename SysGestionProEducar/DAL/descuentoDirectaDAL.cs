using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class descuentoDirectaDAL
    {
        SqlConnection conn;
        public descuentoDirectaDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerDescuentoDirectaDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("obtenerDescuentoDirecta", conn);
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
        public bool insertarDescuentoDirectaDAL(descuentoDirectaTo ddTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_DESCUENTO_DIRECTA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", ddTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@FE_AÑO", ddTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", ddTo.FE_MES);
            cmd.Parameters.AddWithValue("@COD_PERSONA", ddTo.COD_PERSONA);
            cmd.Parameters.AddWithValue("@FECHA_CONTRATO", ddTo.FECHA_CONTRATO);
            cmd.Parameters.AddWithValue("@COD_SECTORISTA", ddTo.COD_SECTORISTA);
            cmd.Parameters.AddWithValue("@COD_GESTOR", ddTo.COD_GESTOR);
            cmd.Parameters.AddWithValue("@MESES_MOROSIDAD", ddTo.MESES_MOROSIDAD);
            cmd.Parameters.AddWithValue("@FECHA_LLAMADA", ddTo.FECHA_LLAMADA);
            if (ddTo.FECHA_NUEVA_LLAMADA == null)
                cmd.Parameters.AddWithValue("@FECHA_NUEVA_LLAMADA", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@FECHA_NUEVA_LLAMADA", ddTo.FECHA_NUEVA_LLAMADA);
            cmd.Parameters.AddWithValue("@COD_USU_CREA", ddTo.COD_USU_CREA);
            cmd.Parameters.AddWithValue("@FECHA_USU_CREA", ddTo.FECHA_USU_CREA);
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
        public DataTable obtenerContratos_x_AsignarDAL(descuentoDirectaTo ddTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("OBTENER_CONTRATOS_VENCIDOS_PARA_COBRANZA_DIRECTA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MESES_MOROSIDAD", ddTo.MESES_MOROSIDAD);
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
        public DataTable obtenerContratos_x_Asignar_CuotasDAL(descuentoDirectaTo ddTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("OBTENER_CONTRATOS_VENCIDOS_PARA_COBRANZA_DIRECTA_CUOTA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MESES_MOROSIDAD", ddTo.MESES_MOROSIDAD);
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
        public DataTable obtenerKardexContratosDirectosDAL(descuentoDirectaTo ddTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_KARDEX_X_CONTRATOS_DIRECTOS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MESES_MOROSIDAD", ddTo.MESES_MOROSIDAD);
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
        public DataTable obtenerSeguimiento_x_NroCotratoDAL(descuentoDirectaTo ddTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_LLAMADA_SEGUIMIENTO_X_NRO_CONTRATO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_GESTOR", ddTo.COD_GESTOR);
            cmd.Parameters.AddWithValue("@FECHA_LLAMADA", ddTo.FECHA_LLAMADA);
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
        public DataTable obtenerContratos_x_LlamarDAL(descuentoDirectaTo ddTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_CONTRATOS_PARA_LLAMADAS_DESCUENTO_COBRANZA_DIRECTA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_GESTOR", ddTo.COD_GESTOR);
            cmd.Parameters.AddWithValue("@FECHA_LLAMADA", ddTo.FECHA_LLAMADA);
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
        public DataTable obtenerCantidadGestoresporLlamarDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_CANTIDAD_GESTORES_X_LLAMAR", conn);
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
        public bool modificaDescuentoDirectaporCierreDAL(descuentoDirectaTo ddTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICA_DESCUENTO_DIRECTA_X_CIERRE", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@NRO_CONTRATO", ddTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@FECHA_LLAMADA", ddTo.FECHA_LLAMADA);
            cmd.Parameters.AddWithValue("@COD_USU_MOD", ddTo.COD_USU_MOD);
            cmd.Parameters.AddWithValue("@FECHA_USU_MOD", ddTo.FECHA_USU_MOD);
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
        public bool modificarDescuentoDirectaxLlamadasDAL(descuentoDirectaTo ddTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICA_DESCUENTO_DIRECTA_X_LLAMADAS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", ddTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@COD_MOTIVO_LLAMADA", ddTo.COD_MOTIVO_LLAMADA);
            cmd.Parameters.AddWithValue("@FECHA_NUEVA_LLAMADA", ddTo.FECHA_NUEVA_LLAMADA);
            cmd.Parameters.AddWithValue("@COD_USU_MOD", ddTo.COD_USU_MOD);
            cmd.Parameters.AddWithValue("@FECHA_USU_MOD", ddTo.FECHA_USU_MOD);
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
        public bool modificaDescuentoDirectaporStatusCanceladoDAL(descuentoDirectaTo ddTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICA_DESCUENTO_DIRECTA_STATUS_CANCELADO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FECHA_LLAMADA", ddTo.FECHA_LLAMADA);
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
        public bool esFeriadoDAL(DateTime fec, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("VERIFICA_EXISTE_FERIADO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Fecha", fec);
            cmd.Parameters.AddWithValue("@TIPO", "D");
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
        public DataTable obtenerContratosparaCierrexFechaActivaDAL(descuentoDirectaTo ddTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("OBTENER_CONTRATOS_DESCUENTO_DIRECTA_PARA_CIERRE_X_FECHA_LLAMADA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FECHA_LLAMADA", ddTo.FECHA_LLAMADA);
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
        public bool modificarDescuentoDirectaxVerificacionDAL(descuentoDirectaTo ddTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICA_DESCUENTO_DIRECTA_X_VERIFICACION", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", ddTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@COD_PERSONA", ddTo.COD_PERSONA);
            cmd.Parameters.AddWithValue("@FECHA_LLAMADA", ddTo.FECHA_LLAMADA);
            cmd.Parameters.AddWithValue("@COD_USU_MOD", ddTo.COD_USU_MOD);
            cmd.Parameters.AddWithValue("@FECHA_USU_MOD", ddTo.FECHA_USU_MOD);
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
