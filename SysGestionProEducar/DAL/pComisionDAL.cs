using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class pComisionDAL
    {
        SqlConnection conn;
        public pComisionDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerPComisionDAL(pComisionTo pcomTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_COMISION_POR_PERIODO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("FE_AÑO", pcomTo.FE_AÑO);
            cmd.Parameters.AddWithValue("FE_MES", pcomTo.FE_MES);
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
        public bool insertarPComisionDAL(pComisionTo pcomTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_PCOMISION", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TIPO_VTA", pcomTo.TIPO_VTA);
            cmd.Parameters.AddWithValue("@COD_PROGRAMA", pcomTo.COD_PROGRAMA);
            cmd.Parameters.AddWithValue("@COD_VENDEDOR", pcomTo.COD_VENDEDOR);
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", pcomTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@FE_CONTRATO", pcomTo.FE_CONTRATO);
            cmd.Parameters.AddWithValue("@FE_AÑO", pcomTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", pcomTo.FE_MES);
            cmd.Parameters.AddWithValue("@FE_DOC", pcomTo.FE_DOC);
            if (pcomTo.FE_APROB == null)
                cmd.Parameters.AddWithValue("@FE_APROB", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@FE_APROB", pcomTo.FE_APROB);
            cmd.Parameters.AddWithValue("@COD_PER", pcomTo.COD_PER);
            cmd.Parameters.AddWithValue("@NRO_LETRA", pcomTo.NRO_LETRA);
            cmd.Parameters.AddWithValue("@IMPORTE", pcomTo.IMPORTE);
            cmd.Parameters.AddWithValue("@IMP_FIN", pcomTo.IMP_FIN);
            cmd.Parameters.AddWithValue("@COD_NIVEL", pcomTo.COD_NIVEL);
            cmd.Parameters.AddWithValue("@COD_PER_SUP", pcomTo.COD_PER_SUP);
            cmd.Parameters.AddWithValue("@STATUS_PRE_APROB", pcomTo.STATUS_PRE_APROB);
            cmd.Parameters.AddWithValue("@COD_CREA", pcomTo.COD_CREA);
            cmd.Parameters.AddWithValue("@FECHA_CREA", pcomTo.FECHA_CREA);
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
        public bool modificarPComisionDAL(pComisionTo pcomTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_VENDEDOR", pcomTo.COD_VENDEDOR);
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", pcomTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@FE_CONTRATO", pcomTo.FE_CONTRATO);
            cmd.Parameters.AddWithValue("@FE_AÑO", pcomTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", pcomTo.FE_MES);
            cmd.Parameters.AddWithValue("@FE_DOC", pcomTo.FE_DOC);
            cmd.Parameters.AddWithValue("@FE_APROB", pcomTo.FE_APROB);
            cmd.Parameters.AddWithValue("@COD_PER", pcomTo.COD_PER);
            cmd.Parameters.AddWithValue("@NRO_LETRA", pcomTo.NRO_LETRA);
            cmd.Parameters.AddWithValue("@IMPORTE", pcomTo.IMPORTE);
            cmd.Parameters.AddWithValue("@COD_NIVEL", pcomTo.COD_NIVEL);
            cmd.Parameters.AddWithValue("@COD_CREA", pcomTo.COD_CREA);
            cmd.Parameters.AddWithValue("@FECHA_CREA", pcomTo.FECHA_CREA);
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
        public DataTable obtenerContratosporPeriodoDAL(pComisionTo pcomTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_CONTRATOS_POR_PERIODO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FE_AÑO", pcomTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", pcomTo.FE_MES);
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", pcomTo.NRO_CONTRATO);
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
        public bool eliminarPComisionDAL(pComisionTo pcomTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_PCOMISION_POR_NRO_CONTRATO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", pcomTo.NRO_CONTRATO);
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
        public DataTable obtenerPComisionPorPeriodoDAL(pComisionTo pcomTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_CUOTA_000_POR_PERIODO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TIPO_VTA", pcomTo.TIPO_VTA);
            cmd.Parameters.AddWithValue("@COD_PROGRAMA", pcomTo.COD_PROGRAMA);
            cmd.Parameters.AddWithValue("@FE_AÑO", pcomTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", pcomTo.FE_MES);
            cmd.Parameters.AddWithValue("@NRO_LETRA", pcomTo.NRO_LETRA);
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
        public DataTable obtenerPComisionDif000DAL(pComisionTo pcomTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_CUOTAS_POR_PERIODO_PARA_LIQUIDACION", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TIPO_VTA", pcomTo.TIPO_VTA);
            cmd.Parameters.AddWithValue("@COD_PROGRAMA", pcomTo.COD_PROGRAMA);
            cmd.Parameters.AddWithValue("@FE_AÑO", pcomTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", pcomTo.FE_MES);
            cmd.Parameters.AddWithValue("@NRO_LETRA", pcomTo.NRO_LETRA);
            cmd.Parameters.AddWithValue("@STATUS_PRE_APROB", pcomTo.STATUS_PRE_APROB);
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
        public bool modificarPComisionxLiqComisionDAL(pComisionTo pcomTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_P_COMISION_X_LIQ_COMISION", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", pcomTo.NRO_CONTRATO);
            //cmd.Parameters.AddWithValue("@FE_CONTRATO", pcomTo.FE_CONTRATO);
            cmd.Parameters.AddWithValue("@FE_AÑO", pcomTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", pcomTo.FE_MES);
            cmd.Parameters.AddWithValue("@NRO_LETRA", pcomTo.NRO_LETRA);
            cmd.Parameters.AddWithValue("@IMP_FIN", pcomTo.IMP_FIN);
            cmd.Parameters.AddWithValue("@COD_NIVEL", pcomTo.COD_NIVEL);
            cmd.Parameters.AddWithValue("@COD_MODIF", pcomTo.COD_MODIF);
            cmd.Parameters.AddWithValue("@FECHA_MODIF", pcomTo.FECHA_MODIF);
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
        public bool modificarPComisionxLiqComision_EliminarDAL(pComisionTo pcomTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_P_COMISION_X_LIQ_COMISION_ELIMINAR", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FE_AÑO", pcomTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", pcomTo.FE_MES);
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", pcomTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@NRO_LETRA", pcomTo.NRO_LETRA);
            cmd.Parameters.AddWithValue("@IMP_FIN", pcomTo.IMP_FIN);
            //cmd.Parameters.AddWithValue("@COD_NIVEL", pcomTo.COD_NIVEL);
            cmd.Parameters.AddWithValue("@COD_MODIF", pcomTo.COD_MODIF);
            cmd.Parameters.AddWithValue("@FECHA_MODIF", pcomTo.FECHA_MODIF);
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
        public DataTable obtenerComisionesPendientesDAL(pComisionTo pcomTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_COMISIONES_PENDIENTES", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TIPO_VTA", pcomTo.TIPO_VTA);
            cmd.Parameters.AddWithValue("@COD_PROGRAMA", pcomTo.COD_PROGRAMA);
            cmd.Parameters.AddWithValue("@FE_AÑO", pcomTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", pcomTo.FE_MES);
            cmd.Parameters.AddWithValue("@FE_AL", pcomTo.FE_AL);
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
        public DataTable obtenerComisionesHistoricosDAL(pComisionTo pcomTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_COMISIONES_PENDIENTES_HISTORICOS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TIPO_VTA", pcomTo.TIPO_VTA);
            cmd.Parameters.AddWithValue("@COD_PROGRAMA", pcomTo.COD_PROGRAMA);
            cmd.Parameters.AddWithValue("@FE_AÑO_AL", pcomTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES_AL", pcomTo.FE_MES);
            cmd.Parameters.AddWithValue("@COD_PER_SUP", pcomTo.COD_PER_SUP);
            cmd.Parameters.AddWithValue("@FE_DEL", pcomTo.FE_DEL);
            cmd.Parameters.AddWithValue("@FE_AL", pcomTo.FE_AL);
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
        public DataTable obtenerComisionesPendientesxContratoDAL(pComisionTo pcomTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_CONTRATOS_PENDIENTES_PARA_COMISIONES", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@TIPO_VTA", pcomTo.TIPO_VTA);
            //cmd.Parameters.AddWithValue("@COD_PROGRAMA", pcomTo.COD_PROGRAMA);
            cmd.Parameters.AddWithValue("@FE_AÑO", pcomTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", pcomTo.FE_MES);
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
        public DataTable obtenerPLiquidacionporPeriodoDAL(pComisionTo pcomTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_CUOTAS_LIQUIDADAS_PARA_LIQUIDACION", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@TIPO_VTA", pcomTo.TIPO_VTA);
            //cmd.Parameters.AddWithValue("@COD_PROGRAMA", pcomTo.COD_PROGRAMA);
            cmd.Parameters.AddWithValue("@FE_AÑO", pcomTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", pcomTo.FE_MES);

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
        public bool verificaExisteNroContratoLiquidadoDAL(pComisionTo pcomTo, ref bool val, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("VERIFICA_EXISTE_NRO_CONTRATO_LIQUIDADO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", pcomTo.NRO_CONTRATO);
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
        public bool validaCierrePeriodoComisionGeneradaDAL(pComisionTo pcomTo, ref bool val, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("VALIDA_TODOS_CONTRATOS_COMISIONES_GENERADOS_DEL_PERIODO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FE_AÑO", pcomTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", pcomTo.FE_MES);
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
    }
}
