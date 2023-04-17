using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class iCostosDAL
    {
        SqlConnection conn;
        public iCostosDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerICostosDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
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
        public bool insertarICostosDAL(iCostosTo icosTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", icosTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_CLASE", icosTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_DOC", icosTo.COD_DOC);
            cmd.Parameters.AddWithValue("@NRO_DOC", icosTo.NRO_DOC);
            cmd.Parameters.AddWithValue("@COD_PER", icosTo.COD_PER);
            cmd.Parameters.AddWithValue("@COD_MOV", icosTo.COD_MOV);
            cmd.Parameters.AddWithValue("@COD_DOC_INV", icosTo.COD_DOC_INV);
            cmd.Parameters.AddWithValue("@NRO_DOC_INV", icosTo.NRO_DOC_INV);
            cmd.Parameters.AddWithValue("@FE_AÑO", icosTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", icosTo.FE_MES);
            cmd.Parameters.AddWithValue("@FECHA_DOC_INV", icosTo.FECHA_DOC_INV);
            cmd.Parameters.AddWithValue("@FECHA_DOC", icosTo.FECHA_DOC);
            cmd.Parameters.AddWithValue("@COD_MONEDA", icosTo.COD_MONEDA);
            cmd.Parameters.AddWithValue("@TIPO_CAMBIO", icosTo.TIPO_CAMBIO);
            cmd.Parameters.AddWithValue("@OBSERVACION", icosTo.OBSERVACION);
            cmd.Parameters.AddWithValue("@STATUS_CIERRE", icosTo.STATUS_CIERRE);
            cmd.Parameters.AddWithValue("@STATUS_PROCESO", icosTo.STATUS_PROCESO);
            cmd.Parameters.AddWithValue("@STATUS_VAL", icosTo.STATUS_VAL);
            cmd.Parameters.AddWithValue("@STATUS_COSTOS", icosTo.STATUS_COSTOS);
            cmd.Parameters.AddWithValue("@STATUS_TRANSF_INV", icosTo.STATUS_TRANSF_INV);
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
        public bool modificarICostosDAL(iCostosTo icosTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", icosTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_CLASE", icosTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_DOC", icosTo.COD_DOC);
            cmd.Parameters.AddWithValue("@NRO_DOC", icosTo.NRO_DOC);
            cmd.Parameters.AddWithValue("@COD_PER", icosTo.COD_PER);
            cmd.Parameters.AddWithValue("@COD_MOV", icosTo.COD_MOV);
            cmd.Parameters.AddWithValue("@COD_DOC_INV", icosTo.COD_DOC_INV);
            cmd.Parameters.AddWithValue("@NRO_DOC_INV", icosTo.NRO_DOC_INV);
            cmd.Parameters.AddWithValue("@FE_AÑO", icosTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", icosTo.FE_MES);
            cmd.Parameters.AddWithValue("@FECHA_DOC_INV", icosTo.FECHA_DOC_INV);
            cmd.Parameters.AddWithValue("@FECHA_DOC", icosTo.FECHA_DOC);
            cmd.Parameters.AddWithValue("@COD_MONEDA", icosTo.COD_MONEDA);
            cmd.Parameters.AddWithValue("@TIPO_CAMBIO", icosTo.TIPO_CAMBIO);
            cmd.Parameters.AddWithValue("@OBSERVACION", icosTo.OBSERVACION);
            cmd.Parameters.AddWithValue("@STATUS_CIERRE", icosTo.STATUS_CIERRE);
            cmd.Parameters.AddWithValue("@STATUS_PROCESO", icosTo.STATUS_PROCESO);
            cmd.Parameters.AddWithValue("@STATUS_VAL", icosTo.STATUS_VAL);
            cmd.Parameters.AddWithValue("@STATUS_COSTOS", icosTo.STATUS_COSTOS);
            cmd.Parameters.AddWithValue("@STATUS_TRANSF_INV", icosTo.STATUS_TRANSF_INV);
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
        public bool inicialCostoPromedioDAL(iCostosTo cosTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INICIAL_COSTO_PROMEDIO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FE_AÑO", cosTo.FE_AÑO);
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
        public bool VALIDAR_NEGATIVOS_DAL(iCostosTo cosTo, ref string errMensaje)
        {
            bool flag = false;
            decimal imp = 0;
            SqlCommand cmd = new SqlCommand("VALIDAR_NEGATIVOS_COSTO_PROMEDIO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FE_AÑO", cosTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", cosTo.FE_MES);
            cmd.Parameters.AddWithValue("@COD_CLASE", cosTo.COD_CLASE);
            try
            {
                conn.Open();
                imp = Convert.ToDecimal(cmd.ExecuteScalar());
                if (imp >= 0)
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
        public string CALCULAR_COSTO_PROMEDIO(iCostosTo cosTo)
        {
            string val = "";
            SqlCommand cmd = new SqlCommand("CALCULAR_COSTO_PROMEDIO0", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FE_AÑO", cosTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", cosTo.FE_MES);
            cmd.Parameters.AddWithValue("@FE_AÑO_ANT", cosTo.FE_AÑOI.ToString("0000"));
            cmd.Parameters.AddWithValue("@FE_MES_ANT", cosTo.FE_MESI.ToString("00"));
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
        public string CALCULAR_COSTO_PROMEDIO2(iCostosTo cosTo)
        {
            string val = "";
            SqlCommand cmd = new SqlCommand("CALCULAR_COSTO_PROMEDIO_XDIA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FE_AÑO", cosTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", cosTo.FE_MES);
            cmd.Parameters.AddWithValue("@FE_AÑO_ANT", cosTo.FE_AÑOI.ToString("0000"));
            cmd.Parameters.AddWithValue("@FE_MES_ANT", cosTo.FE_MESI.ToString("00"));
            cmd.Parameters.AddWithValue("@COD_CLASE0", cosTo.COD_CLASE);
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
        public string CALCULAR_COSTO_PROMEDIO_ARTICULO(iCostosTo cosTo)
        {
            string val = "";
            SqlCommand cmd = new SqlCommand("CALCULAR_COSTO_PROMEDIO0_ARTICULO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FE_AÑO", cosTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", cosTo.FE_MES);
            cmd.Parameters.AddWithValue("@FE_AÑO_ANT", cosTo.FE_AÑOI.ToString("0000"));
            cmd.Parameters.AddWithValue("@FE_MES_ANT", cosTo.FE_MESI.ToString("00"));
            cmd.Parameters.AddWithValue("@COD_CLASE", cosTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_ARTICULO", cosTo.COD_ARTICULO);
            try
            {
                conn.Open();
                //cmd.CommandTimeout = 5000;
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
        public string CALCULAR_COSTO_PROMEDIO_MOV(iCostosTo cosTo)
        {
            string val = "";
            SqlCommand cmd = new SqlCommand("CALCULAR_COSTO_PROMEDIO0_ARTICULO_MOV", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FE_AÑO", cosTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", cosTo.FE_MES);
            cmd.Parameters.AddWithValue("@FE_AÑO_ANT", cosTo.FE_AÑOI.ToString("0000"));
            cmd.Parameters.AddWithValue("@FE_MES_ANT", cosTo.FE_MESI.ToString("00"));
            cmd.Parameters.AddWithValue("@COD_CLASE", cosTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_MOV", cosTo.COD_MOV);
            try
            {
                conn.Open();
                //cmd.CommandTimeout = 5000;
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
        public DataTable MOSTRAR_I_COSTOS_DEVOLUCION(iCostosTo cosTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_I_COSTOS_DEVOLUCION", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("FE_AÑO", cosTo.FE_AÑO);
            cmd.Parameters.AddWithValue("FE_MES", cosTo.FE_MES);
            cmd.Parameters.AddWithValue("COD_CLASE", cosTo.COD_CLASE);
            cmd.Parameters.AddWithValue("COD_MOV", cosTo.COD_MOV);
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
