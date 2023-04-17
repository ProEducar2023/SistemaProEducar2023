using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class pLiqAdelantoDAL
    {
        SqlConnection conn;
        public pLiqAdelantoDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerPLiqAdelantoDAL(pLiqAdelantoTo lqaTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_P_LIQ_ADELANTO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FE_AÑO", lqaTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", lqaTo.FE_MES);
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
        public bool insertarPLiqAdelantoDAL(pLiqAdelantoTo lqaTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_P_LIQ_ADELANTO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", lqaTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@FE_AÑO", lqaTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", lqaTo.FE_MES);
            cmd.Parameters.AddWithValue("@COD_PER", lqaTo.COD_PER);
            cmd.Parameters.AddWithValue("@COD_DOC", lqaTo.COD_DOC);
            cmd.Parameters.AddWithValue("@NRO_DOC", lqaTo.NRO_DOC);
            cmd.Parameters.AddWithValue("@FECHA_DOC", lqaTo.FECHA_DOC);
            cmd.Parameters.AddWithValue("@IMP_DOC", lqaTo.IMP_DOC);
            cmd.Parameters.AddWithValue("@OBSERVACION", lqaTo.OBSERVACION);
            cmd.Parameters.AddWithValue("@COD_MONEDA", lqaTo.COD_MONEDA);
            cmd.Parameters.AddWithValue("@NRO_DOC_PAG", lqaTo.NRO_DOC_PAG);
            if (lqaTo.FECHA_DOC_PAG == null)
                cmd.Parameters.AddWithValue("@FECHA_DOC_PAG", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@FECHA_DOC_PAG", lqaTo.FECHA_DOC_PAG);
            cmd.Parameters.AddWithValue("@COD_CONCEPTO", lqaTo.COD_CONCEPTO);
            cmd.Parameters.AddWithValue("@COD_BANCO", lqaTo.COD_BANCO);
            cmd.Parameters.AddWithValue("@COD_USU_CREA", lqaTo.COD_USU_CREA);
            cmd.Parameters.AddWithValue("@FECHA_CREA", lqaTo.FECHA_CREA);
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
        public bool insertarPLiqAdelanto3DAL(pLiqAdelantoTo lqaTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_P_LIQ_ADELANTO_2", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", lqaTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@FE_AÑO", lqaTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", lqaTo.FE_MES);
            cmd.Parameters.AddWithValue("@COD_PER", lqaTo.COD_PER);
            //cmd.Parameters.AddWithValue("@COD_DOC", lqaTo.COD_DOC);
            cmd.Parameters.AddWithValue("@NRO_DOC", lqaTo.NRO_DOC);
            //cmd.Parameters.AddWithValue("@FECHA_DOC", lqaTo.FECHA_DOC);
            cmd.Parameters.AddWithValue("@IMP_DOC", lqaTo.IMP_DOC);

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
        public bool eliminar_P_Liq_AdelantoDAL(pLiqAdelantoTo lqaTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_P_LIQ_ADELANTO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", lqaTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@FE_AÑO", lqaTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", lqaTo.FE_MES);
            cmd.Parameters.AddWithValue("@COD_PER", lqaTo.COD_PER);
            cmd.Parameters.AddWithValue("@COD_DOC", lqaTo.COD_DOC);
            cmd.Parameters.AddWithValue("@NRO_DOC", lqaTo.NRO_DOC);

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
        public DataTable obtenerPLiqAdelantoxPeriodoparaResumenDAL(pLiqAdelantoTo lqaTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_P_LIQ_ADELANTO_X_PERIODO_PARA_RESUMEN", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FE_AÑO", lqaTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", lqaTo.FE_MES);
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
        public decimal sumaAdelanto_Comisiones_X_Periodo_X_ComisionistaDAL(pLiqAdelantoTo lqaTo)
        {
            decimal sum = 0;
            SqlCommand cmd = new SqlCommand("SUMAR_ADELANTO_COMISIONES_X_PERIODO_X_COMISIONISTA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FE_AÑO", lqaTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", lqaTo.FE_MES);
            cmd.Parameters.AddWithValue("@COD_PER", lqaTo.COD_PER);
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
        public DataTable obtenerAdelanto_Comisiones_X_Periodo_X_ComisionistaDAL(pLiqAdelantoTo lqaTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_ADELANTO_COMISIONES_X_PERIODO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FE_AÑO", lqaTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", lqaTo.FE_MES);
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
        public bool verifica_existe_P_AdelantoDAL(pLiqAdelantoTo lqaTo, ref bool valor, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("VERIFICA_EXISTE_P_ADELANTO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", lqaTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@FE_AÑO", lqaTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", lqaTo.FE_MES);
            cmd.Parameters.AddWithValue("@COD_PER", lqaTo.COD_PER);
            cmd.Parameters.AddWithValue("@NRO_DOC", lqaTo.NRO_DOC);
            try
            {
                conn.Open();
                valor = Convert.ToBoolean(cmd.ExecuteScalar());
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
