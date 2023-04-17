using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class planillaDirectaVariosDetalleDAL
    {
        SqlConnection conn;
        public planillaDirectaVariosDetalleDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtener_T_Planilla_Directa_Varios_Detalle_DAL(planillaDirectaVariosDetalleTo pdvdTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_T_PLANILLA_DIRECTA_VARIOS_DETALLE", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_PLANILLA_COB", pdvdTo.NRO_PLANILLA_COB);
            cmd.Parameters.AddWithValue("@TIPO_PLANILLA", pdvdTo.TIPO_PLANILLA);
            //cmd.Parameters.AddWithValue("@FE_AÑO", pdvdTo.FE_AÑO);
            //cmd.Parameters.AddWithValue("@FE_MES", pdvdTo.FE_MES);

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
        public DataTable obtener_T_Dev_Planilla_Directa_Varios_Detalle_DAL(planillaDirectaVariosDetalleTo pdvdTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_T_DEV_PLANILLA_DIRECTA_VARIOS_DETALLE", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_PLANILLA_COB", pdvdTo.NRO_PLANILLA_COB);
            cmd.Parameters.AddWithValue("@TIPO_PLANILLA", pdvdTo.TIPO_PLANILLA);
            //cmd.Parameters.AddWithValue("@FE_AÑO", pdvdTo.FE_AÑO);
            //cmd.Parameters.AddWithValue("@FE_MES", pdvdTo.FE_MES);

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
        public bool insertar_T_Planilla_Directa_Varios_Detalle_DAL(planillaDirectaVariosDetalleTo pdvdTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_T_PLANILLA_DIRECTA_VARIOS_DETALLE", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_PLANILLA_COB", pdvdTo.NRO_PLANILLA_COB);
            cmd.Parameters.AddWithValue("@TIPO_PLANILLA", pdvdTo.TIPO_PLANILLA);
            cmd.Parameters.AddWithValue("@FE_AÑO", pdvdTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", pdvdTo.FE_MES);
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", pdvdTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@COD_PER", pdvdTo.COD_PER);
            cmd.Parameters.AddWithValue("@TIPO_TARJETA", pdvdTo.TIPO_TARJETA);
            cmd.Parameters.AddWithValue("@FE_1ER_PROCESO", pdvdTo.FE_1ER_PROCESO);
            cmd.Parameters.AddWithValue("@MONTO_CUOTA", pdvdTo.MONTO_CUOTA);
            cmd.Parameters.AddWithValue("@DSCTO_TARJETA", pdvdTo.DSCTO_TARJETA);
            cmd.Parameters.AddWithValue("@PAGO_RECIBIDO", pdvdTo.PAGO_RECIBIDO);
            cmd.Parameters.AddWithValue("@COD_CREACION", pdvdTo.COD_CREACION);
            cmd.Parameters.AddWithValue("@FECHA_CREACION", pdvdTo.FECHA_CREACION);

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
        public bool insertar_T_DEV_Planilla_Directa_Varios_Detalle_DAL(planillaDirectaVariosDetalleTo pdvdTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_T_DEV_PLANILLA_DIRECTA_VARIOS_DETALLE", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_PLANILLA_COB", pdvdTo.NRO_PLANILLA_COB);
            cmd.Parameters.AddWithValue("@TIPO_PLANILLA", pdvdTo.TIPO_PLANILLA);
            cmd.Parameters.AddWithValue("@FE_AÑO", pdvdTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", pdvdTo.FE_MES);
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", pdvdTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@COD_PER", pdvdTo.COD_PER);
            cmd.Parameters.AddWithValue("@IMP_DEV", pdvdTo.IMP_DEV);
            cmd.Parameters.AddWithValue("@COD_CREACION", pdvdTo.COD_CREACION);
            cmd.Parameters.AddWithValue("@FECHA_CREACION", pdvdTo.FECHA_CREACION);

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
        public bool eliminar_T_PLANILLA_DIRECTA_VARIOS_DAL(planillaDirectaVariosDetalleTo pdvdTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_T_PLANILLA_DIRECTA_VARIOS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_PLANILLA_COB", pdvdTo.NRO_PLANILLA_COB);
            cmd.Parameters.AddWithValue("@TIPO_PLANILLA", pdvdTo.TIPO_PLANILLA);
            cmd.Parameters.AddWithValue("@FE_AÑO", pdvdTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", pdvdTo.FE_MES);


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
        public bool eliminar_T_DEV_PLANILLA_DIRECTA_VARIOS_DAL(planillaDirectaVariosDetalleTo pdvdTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_T_DEV_PLANILLA_DIRECTA_VARIOS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_PLANILLA_COB", pdvdTo.NRO_PLANILLA_COB);
            cmd.Parameters.AddWithValue("@TIPO_PLANILLA", pdvdTo.TIPO_PLANILLA);
            cmd.Parameters.AddWithValue("@FE_AÑO", pdvdTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", pdvdTo.FE_MES);


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
