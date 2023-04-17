using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class planillaDirectaVariosDAL
    {
        SqlConnection conn;
        public planillaDirectaVariosDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtener_I_Planilla_Directa_Varios_DAL(planillaDirectaVariosTo pdvTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_I_PLANILLA_DIRECTA_VARIOS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FE_AÑO", pdvTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", pdvTo.FE_MES);
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
        public bool insertar_I_Planilla_Directa_Varios_DAL(planillaDirectaVariosTo pdvTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_I_PLANILLA_DIRECTA_VARIOS", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@NRO_PLANILLA_COB", pdvTo.NRO_PLANILLA_COB);
            cmd.Parameters.AddWithValue("@TIPO_PLANILLA", pdvTo.TIPO_PLANILLA);
            cmd.Parameters.AddWithValue("@FE_AÑO", pdvTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", pdvTo.FE_MES);
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", pdvTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@CANAL_DSCTO", pdvTo.CANAL_DSCTO);
            cmd.Parameters.AddWithValue("@COD_GESTOR", pdvTo.COD_GESTOR);
            cmd.Parameters.AddWithValue("@PROGRAMA", pdvTo.PROGRAMA);
            cmd.Parameters.AddWithValue("@COD_PTO_COB", pdvTo.COD_PTO_COB);
            cmd.Parameters.AddWithValue("@FECHA_PLANILLA_COB", pdvTo.FECHA_PLANILLA_COB);
            cmd.Parameters.AddWithValue("@NUM_MOVIMIENTO", pdvTo.NUM_MOVIMIENTO);
            cmd.Parameters.AddWithValue("@TOTAL_ENVIADO", pdvTo.TOTAL_ENVIADO);
            cmd.Parameters.AddWithValue("@TOTAL_RECIBIDO", pdvTo.TOTAL_RECIBIDO);
            cmd.Parameters.AddWithValue("@TOTAL_GASTOS_RETENIDOS_X_BANCO", pdvTo.TOTAL_GASTOS_RETENIDOS_X_BANCO);
            cmd.Parameters.AddWithValue("@TOTAL_RETENCION_X_DEV_CLIENTE", pdvTo.TOTAL_RETENCION_X_DEV_CLIENTE);
            cmd.Parameters.AddWithValue("@TOTAL_DEPOSITO", pdvTo.TOTAL_DEPOSITO);
            cmd.Parameters.AddWithValue("@OBSERVACIONES", pdvTo.OBSERVACIONES);
            cmd.Parameters.AddWithValue("@STATUS_APROBADO", pdvTo.STATUS_APROBADO);
            cmd.Parameters.AddWithValue("@COD_CREACION", pdvTo.COD_CREACION);
            cmd.Parameters.AddWithValue("@FECHA_CREACION", pdvTo.FECHA_CREACION);

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
        public bool modificar_I_Planilla_Directa_Varios_DAL(planillaDirectaVariosTo pdvTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_I_PLANILLA_DIRECTA_VARIOS", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@NRO_PLANILLA_COB", pdvTo.NRO_PLANILLA_COB);
            cmd.Parameters.AddWithValue("@TIPO_PLANILLA", pdvTo.TIPO_PLANILLA);
            cmd.Parameters.AddWithValue("@FE_AÑO", pdvTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", pdvTo.FE_MES);
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", pdvTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@CANAL_DSCTO", pdvTo.CANAL_DSCTO);
            cmd.Parameters.AddWithValue("@COD_GESTOR", pdvTo.COD_GESTOR);
            cmd.Parameters.AddWithValue("@PROGRAMA", pdvTo.PROGRAMA);
            cmd.Parameters.AddWithValue("@COD_PTO_COB", pdvTo.COD_PTO_COB);
            cmd.Parameters.AddWithValue("@FECHA_PLANILLA_COB", pdvTo.FECHA_PLANILLA_COB);
            cmd.Parameters.AddWithValue("@NUM_MOVIMIENTO", pdvTo.NUM_MOVIMIENTO);
            cmd.Parameters.AddWithValue("@TOTAL_ENVIADO", pdvTo.TOTAL_ENVIADO);
            cmd.Parameters.AddWithValue("@TOTAL_RECIBIDO", pdvTo.TOTAL_RECIBIDO);
            cmd.Parameters.AddWithValue("@TOTAL_GASTOS_RETENIDOS_X_BANCO", pdvTo.TOTAL_GASTOS_RETENIDOS_X_BANCO);
            cmd.Parameters.AddWithValue("@TOTAL_RETENCION_X_DEV_CLIENTE", pdvTo.TOTAL_RETENCION_X_DEV_CLIENTE);
            cmd.Parameters.AddWithValue("@TOTAL_DEPOSITO", pdvTo.TOTAL_DEPOSITO);
            cmd.Parameters.AddWithValue("@OBSERVACIONES", pdvTo.OBSERVACIONES);
            cmd.Parameters.AddWithValue("@COD_MODIFICACION", pdvTo.COD_MODIFICACION);
            cmd.Parameters.AddWithValue("@FECHA_MODIFICACION", pdvTo.FECHA_MODIFICACION);

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
        public DataTable obtenerPlanillaDetalleDirectoVariosDAL(planillaDirectaVariosTo pdvTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_PLLA_DETALLE_VARIOS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_PLANILLA_COB", pdvTo.NRO_PLANILLA_COB);
            cmd.Parameters.AddWithValue("@TIPO_PLANILLA", pdvTo.TIPO_PLANILLA);
            cmd.Parameters.AddWithValue("@FE_AÑO", pdvTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", pdvTo.FE_MES);
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
        public bool aprueba_Actualiza_I_PLANILLA_DIRECTA_VARIOS_DAL(planillaDirectaVariosTo pdvTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ACTUALIZA_PLANILLA_DIRECTA_VARIOS_X_APROBACION", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@NRO_PLANILLA_COB", pdvTo.NRO_PLANILLA_COB);
            cmd.Parameters.AddWithValue("@TIPO_PLANILLA", pdvTo.TIPO_PLANILLA);
            cmd.Parameters.AddWithValue("@FE_AÑO", pdvTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", pdvTo.FE_MES);

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
