using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class pLiquidacionDAL
    {
        SqlConnection conn;
        public pLiquidacionDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerPLiquidacionDAL(pLiquidacionTo lqcTo)
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
        public bool insertarPLiquidacionDAL(pLiquidacionTo lqcTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_LIQ_COMISION", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TIPO_VTA", lqcTo.TIPO_VTA);
            cmd.Parameters.AddWithValue("@COD_PROGRAMA", lqcTo.COD_PROGRAMA);
            cmd.Parameters.AddWithValue("@COD_COMISIONANTE", lqcTo.COD_COMISIONANTE);
            cmd.Parameters.AddWithValue("@COD_VENDEDOR", lqcTo.COD_VENDEDOR);
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", lqcTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@FE_CONTRATO", lqcTo.FE_CONTRATO);
            cmd.Parameters.AddWithValue("@FE_AÑO", lqcTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", lqcTo.FE_MES);
            cmd.Parameters.AddWithValue("@FE_DOC", lqcTo.FE_DOC);
            cmd.Parameters.AddWithValue("@COD_PER", lqcTo.COD_PER);
            cmd.Parameters.AddWithValue("@NRO_LETRA", lqcTo.NRO_LETRA);
            cmd.Parameters.AddWithValue("@COD_NIVEL", lqcTo.COD_NIVEL);
            cmd.Parameters.AddWithValue("@IMP_INI", lqcTo.IMP_INI);
            cmd.Parameters.AddWithValue("@IMPORTE", lqcTo.IMPORTE);
            cmd.Parameters.AddWithValue("@STATUS_CANCELADO", lqcTo.STATUS_CANCELADO);
            cmd.Parameters.AddWithValue("@STATUS_CIERRE", lqcTo.STATUS_CIERRE);
            cmd.Parameters.AddWithValue("@NRO_DOC_PAG", lqcTo.NRO_DOC_PAG);
            if (lqcTo.FECHA_DOC_PAG == null)
                cmd.Parameters.AddWithValue("@FECHA_DOC_PAG", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@FECHA_DOC_PAG", lqcTo.FECHA_DOC_PAG);
            cmd.Parameters.AddWithValue("@COD_CONCEPTO", lqcTo.COD_CONCEPTO);
            cmd.Parameters.AddWithValue("@COD_BANCO", lqcTo.COD_BANCO);
            cmd.Parameters.AddWithValue("@COD_CREA", lqcTo.COD_CREA);
            cmd.Parameters.AddWithValue("@FECHA_CREA", lqcTo.FECHA_CREA);
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
        public bool modificarLiqComisionDAL(pLiquidacionTo lqcTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PROGRAMA", lqcTo.COD_PROGRAMA);
            cmd.Parameters.AddWithValue("@COD_VENDEDOR", lqcTo.COD_VENDEDOR);
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", lqcTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@FE_CONTRATO", lqcTo.FE_CONTRATO);
            cmd.Parameters.AddWithValue("@FE_AÑO", lqcTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", lqcTo.FE_MES);
            cmd.Parameters.AddWithValue("@FE_DOC", lqcTo.FE_DOC);
            cmd.Parameters.AddWithValue("@COD_PER", lqcTo.COD_PER);
            cmd.Parameters.AddWithValue("@NRO_LETRA", lqcTo.NRO_LETRA);
            cmd.Parameters.AddWithValue("@COD_NIVEL", lqcTo.COD_NIVEL);
            cmd.Parameters.AddWithValue("@NRO_PLANILLA", lqcTo.NRO_PLANILLA);
            cmd.Parameters.AddWithValue("@FE_PLANILLA", lqcTo.FE_PLANILLA);
            cmd.Parameters.AddWithValue("@IMPORTE", lqcTo.IMPORTE);
            cmd.Parameters.AddWithValue("@COD_CREA", lqcTo.COD_CREA);
            cmd.Parameters.AddWithValue("@FECHA_CREA", lqcTo.FECHA_CREA);
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
        public bool eliminarPLiquidacionDAL(pLiquidacionTo lqcTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_PLIQUIDACION", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TIPO_VTA", lqcTo.TIPO_VTA);
            cmd.Parameters.AddWithValue("@COD_PROGRAMA", lqcTo.COD_PROGRAMA);
            //cmd.Parameters.AddWithValue("@COD_COMISIONANTE", lqcTo.COD_COMISIONANTE);
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", lqcTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@NRO_LETRA", lqcTo.NRO_LETRA);
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
        public DataTable obtenerLiquidacionpara_P_ResumenDAL(pLiquidacionTo lqcTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_P_LIQUIDACION_PARA_RESUMEN", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FE_MES", lqcTo.FE_MES);
            cmd.Parameters.AddWithValue("@FE_AÑO", lqcTo.FE_AÑO);
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
        public decimal sumaComision_Comisiones_X_Periodo_X_ComisionistaDAL(pLiquidacionTo lqcTo)
        {
            decimal sum = 0;
            SqlCommand cmd = new SqlCommand("SUMAR_COMISIONES_X_PERIODO_X_COMISIONISTA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FE_AÑO", lqcTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", lqcTo.FE_MES);
            cmd.Parameters.AddWithValue("@COD_COMISIONANTE", lqcTo.COD_COMISIONANTE);
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
        public DataTable obtenerComision_Comisiones_X_Periodo_X_ComisionistaDAL(pLiquidacionTo lqcTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_COMISION_COMISIONES_X_PERIODO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("FE_AÑO", lqcTo.FE_AÑO);
            cmd.Parameters.AddWithValue("FE_MES", lqcTo.FE_MES);
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
