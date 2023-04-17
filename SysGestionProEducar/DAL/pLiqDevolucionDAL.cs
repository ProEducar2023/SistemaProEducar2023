using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class pLiqDevolucionDAL
    {
        SqlConnection conn;
        public pLiqDevolucionDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerPLiqDevolucionDAL(pLiqDevolucionTo pldTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("", conn);
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
        public bool insertarPLiqDevolucionDAL(pLiqDevolucionTo pldTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_P_LIQ_DEVOLUCION", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TIPO_VTA", pldTo.TIPO_VTA);
            cmd.Parameters.AddWithValue("@COD_PROGRAMA", pldTo.COD_PROGRAMA);
            cmd.Parameters.AddWithValue("@COD_COMISIONANTE", pldTo.COD_COMISIONANTE);
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", pldTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@NRO_LETRA", pldTo.NRO_LETRA);
            cmd.Parameters.AddWithValue("@COD_NIVEL", pldTo.COD_NIVEL);
            cmd.Parameters.AddWithValue("@FE_DOC", pldTo.FE_DOC);
            cmd.Parameters.AddWithValue("@COD_VENDEDOR", pldTo.COD_VENDEDOR);
            cmd.Parameters.AddWithValue("@FE_CONTRATO", pldTo.FE_CONTRATO);
            cmd.Parameters.AddWithValue("@FE_AÑO", pldTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", pldTo.FE_MES);
            cmd.Parameters.AddWithValue("@COD_PER", pldTo.COD_PER);
            cmd.Parameters.AddWithValue("@IMP_INI", pldTo.IMPORTE);
            cmd.Parameters.AddWithValue("@IMPORTE", pldTo.IMPORTE);
            cmd.Parameters.AddWithValue("@STATUS_CANCELADO", pldTo.STATUS_CANCELADO);
            cmd.Parameters.AddWithValue("@STATUS_CIERRE", pldTo.STATUS_CIERRE);
            cmd.Parameters.AddWithValue("@NRO_DOC_PAG", pldTo.NRO_DOC_PAG);
            if (pldTo.FECHA_DOC_PAG == null)
                cmd.Parameters.AddWithValue("@FECHA_DOC_PAG", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@FECHA_DOC_PAG", pldTo.FECHA_DOC_PAG);
            cmd.Parameters.AddWithValue("@COD_CONCEPTO", pldTo.COD_CONCEPTO);
            cmd.Parameters.AddWithValue("@COD_BANCO", pldTo.COD_BANCO);
            cmd.Parameters.AddWithValue("@COD_CREA", pldTo.COD_CREA);
            cmd.Parameters.AddWithValue("@FECHA_CREA", pldTo.FECHA_CREA);
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
        public DataTable obtenerDevolucionesLiquidadasDAL(pLiqDevolucionTo pldTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_DEVOLUCIONES_LIQUIDADAS_X_PERIODO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FE_AÑO", pldTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", pldTo.FE_MES);
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
        public DataTable obtenerPLiqDevolucionxPeriodoparaResumenDAL(pLiqDevolucionTo pldTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_P_LIQ_DEVOLUCION_X_PERIODO_PARA_RESUMEN", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FE_AÑO", pldTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", pldTo.FE_MES);
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
        public decimal sumaDevolucion_Comisiones_X_Periodo_X_ComisionistaDAL(pLiqDevolucionTo pldTo)
        {
            decimal sum = 0;
            SqlCommand cmd = new SqlCommand("SUMAR_DEVOLUCIONES_COMISIONES_X_PERIODO_X_COMISIONISTA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FE_AÑO", pldTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", pldTo.FE_MES);
            cmd.Parameters.AddWithValue("@COD_COMISIONANTE", pldTo.COD_COMISIONANTE);
            try
            {
                conn.Open();
                sum = Convert.ToDecimal(cmd.ExecuteScalar());

            }
            catch (Exception)
            {
                sum = 0;
            }
            finally
            {
                conn.Close();
            }
            return sum;
        }
        public bool eliminarPLiqDevolucionDAL(pLiqDevolucionTo pldTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_P_LIQ_DEVOLUCION", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TIPO_VTA", pldTo.TIPO_VTA);
            cmd.Parameters.AddWithValue("@COD_PROGRAMA", pldTo.COD_PROGRAMA);
            cmd.Parameters.AddWithValue("@COD_COMISIONANTE", pldTo.COD_COMISIONANTE);
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", pldTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@NRO_LETRA", pldTo.NRO_LETRA);
            cmd.Parameters.AddWithValue("@COD_NIVEL", pldTo.COD_NIVEL);

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
        public DataTable obtenerDevolucion_Comisiones_X_Periodo_X_ComisionistaDAL(pLiqDevolucionTo pldTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_DEVOLUCION_COMISIONES_X_PERIODO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FE_AÑO", pldTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", pldTo.FE_MES);
            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr, LoadOption.Upsert);
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
