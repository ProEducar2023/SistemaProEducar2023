using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class pDevolucionDAL
    {
        SqlConnection conn;
        public pDevolucionDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerPDevolucionDAL(pDevolucionTo pdevTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_P_DEVOLUCION_POR_PERIODO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("FE_AÑO", pdevTo.FE_AÑO);
            cmd.Parameters.AddWithValue("FE_MES", pdevTo.FE_MES);
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
        public bool insertarPDevolucionDAL(pDevolucionTo pdevTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_PDEVOLUCION", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TIPO_VTA", pdevTo.TIPO_VTA);
            cmd.Parameters.AddWithValue("@COD_PROGRAMA", pdevTo.COD_PROGRAMA);
            cmd.Parameters.AddWithValue("@COD_VENDEDOR", pdevTo.COD_VENDEDOR);
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", pdevTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@FE_CONTRATO", pdevTo.FE_CONTRATO);
            cmd.Parameters.AddWithValue("@FE_AÑO", pdevTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", pdevTo.FE_MES);
            cmd.Parameters.AddWithValue("@FE_DOC", pdevTo.FE_DOC);
            cmd.Parameters.AddWithValue("@COD_PER", pdevTo.COD_PER);
            cmd.Parameters.AddWithValue("@NRO_LETRA", pdevTo.NRO_LETRA);
            cmd.Parameters.AddWithValue("@IMPORTE", pdevTo.IMPORTE);
            cmd.Parameters.AddWithValue("@IMP_INI", pdevTo.IMP_INI);
            cmd.Parameters.AddWithValue("@COD_NIVEL", pdevTo.COD_NIVEL);
            cmd.Parameters.AddWithValue("@COD_PER_SUP", pdevTo.COD_PER_SUP);
            cmd.Parameters.AddWithValue("@STATUS_LIQUIDADO", pdevTo.STATUS_LIQUIDADO);
            cmd.Parameters.AddWithValue("@STATUS_CIERRE", pdevTo.STATUS_CIERRE);
            cmd.Parameters.AddWithValue("@NRO_FAC_PRE_UNI", pdevTo.NRO_FAC_PRE_UNI);
            cmd.Parameters.AddWithValue("@COD_CREA", pdevTo.COD_CREA);
            cmd.Parameters.AddWithValue("@FECHA_CREA", pdevTo.FECHA_CREA);
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
        public DataTable obtenerContratosporPeriodoDAL(pDevolucionTo pdevTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_CONTRATOS_POR_PERIODO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FE_AÑO", pdevTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", pdevTo.FE_MES);
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", pdevTo.NRO_CONTRATO);
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
        public bool eliminarPDevolucionDAL(pDevolucionTo pdevTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_PDEVOLUCION_POR_NRO_CONTRATO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", pdevTo.NRO_CONTRATO);
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
        public DataTable obtenerDevolucionesPendientesxLiquidarDAL(pDevolucionTo pdevTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_DEVOLUCIONES_PENDIENTES_X_LIQUIDAR", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FE_AÑO", pdevTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", pdevTo.FE_MES);
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

        public bool modificarPDevolucionxLiqDevolucionDAL(pDevolucionTo pdevTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_P_DEVOLUCION_X_P_LIQ_DEVOLUCION", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TIPO_VTA", pdevTo.TIPO_VTA);
            cmd.Parameters.AddWithValue("@COD_PROGRAMA", pdevTo.COD_PROGRAMA);
            cmd.Parameters.AddWithValue("@COD_VENDEDOR", pdevTo.COD_VENDEDOR);
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", pdevTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@NRO_LETRA", pdevTo.NRO_LETRA);
            cmd.Parameters.AddWithValue("@COD_NIVEL", pdevTo.COD_NIVEL);
            cmd.Parameters.AddWithValue("@COD_PER_SUP", pdevTo.COD_PER_SUP);
            cmd.Parameters.AddWithValue("@IMPORTE", pdevTo.IMPORTE);
            cmd.Parameters.AddWithValue("@STATUS_LIQUIDADO", pdevTo.STATUS_LIQUIDADO);
            cmd.Parameters.AddWithValue("@COD_MODIF", pdevTo.COD_MODIF);
            cmd.Parameters.AddWithValue("@FECHA_MODIF", pdevTo.FECHA_MODIF);
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
        public bool verificaExisteNroContratoLiquidadoDAL(pDevolucionTo pdevTo, ref bool val, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("VERIFICA_EXISTE_NRO_CONTRATO_DEVOLUCION_LIQUIDADA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", pdevTo.NRO_CONTRATO);
            try
            {
                conn.Open();
                val = Convert.ToBoolean(cmd.ExecuteScalar());
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
        public bool validaCierrePeriodoDevolucionGeneradaDAL(pDevolucionTo pdevTo, ref bool val, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("VALIDA_TODOS_CONTRATOS_DEVOLUCIONES_GENERADOS_DEL_PERIODO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FE_AÑO", pdevTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", pdevTo.FE_MES);
            try
            {
                conn.Open();
                val = Convert.ToBoolean(cmd.ExecuteScalar());
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
        public DataTable obtenerDevxExcesoContratoDAL(pDevolucionTo pdevTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_EXCESO_CONTRATO_KARDEX", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", pdevTo.NRO_CONTRATO);
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
        public DataTable obtenerDevxReclamoDAL(pDevolucionTo pdevTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_DEVOLUCION_X_RECLAMO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", pdevTo.NRO_CONTRATO);
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
