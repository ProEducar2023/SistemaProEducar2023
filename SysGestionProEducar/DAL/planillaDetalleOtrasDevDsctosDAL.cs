using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class planillaDetalleOtrasDevDsctosDAL
    {
        SqlConnection conn;
        public planillaDetalleOtrasDevDsctosDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerPlanillaDetalleOtrasDevDsctosPendientesDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_PLANILLA_DETALLE_OTRAS_DEV_DSCTOS_PENDIENTES", conn);
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
        public DataTable obtenerPlanillaDetalleOtrasDevDsctosDAL(planillaDetalleOtrasDevDsctosTo pldTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_PLANILLA_DETALLE_OTRAS_DEV_DSCTOS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_PLANILLA_DOC", pldTo.NRO_PLANILLA_DOC);
            cmd.Parameters.AddWithValue("@COD_INSTITUCION", pldTo.COD_INSTITUCION);
            cmd.Parameters.AddWithValue("@COD_CANAL_DSCTO", pldTo.COD_CANAL_DSCTO);
            cmd.Parameters.AddWithValue("@FE_AÑO", pldTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", pldTo.FE_MES);
            cmd.Parameters.AddWithValue("@TIPO_PLANILLA_DOC", pldTo.TIPO_PLANILLA_DOC);
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
        public bool insertarPlanillaDetalleOtrasDevDsctosDAL(planillaDetalleOtrasDevDsctosTo pldTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_PLANILLA_DETALLE_OTRAS_DEV_DSCTOS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_PLANILLA_DOC", pldTo.NRO_PLANILLA_DOC);
            cmd.Parameters.AddWithValue("@COD_INSTITUCION", pldTo.COD_INSTITUCION);
            cmd.Parameters.AddWithValue("@COD_CANAL_DSCTO", pldTo.COD_CANAL_DSCTO);
            cmd.Parameters.AddWithValue("@FE_AÑO", pldTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", pldTo.FE_MES);
            cmd.Parameters.AddWithValue("@TIPO_PLANILLA_DOC", pldTo.TIPO_PLANILLA_DOC);
            cmd.Parameters.AddWithValue("@NRO_PLANILLA_COB", pldTo.NRO_PLANILLA_COB);
            cmd.Parameters.AddWithValue("@NRO_DOC", pldTo.NRO_DOC);
            cmd.Parameters.AddWithValue("@IMP_DOC", pldTo.IMP_DOC);
            cmd.Parameters.AddWithValue("@MOTIVO_OTRAS_DEV_DSCTOS", pldTo.MOTIVO_OTRAS_DEV_DSCTOS);
            cmd.Parameters.AddWithValue("@COD_CREA", pldTo.COD_CREA);
            cmd.Parameters.AddWithValue("@FECHA_CREA", pldTo.FECHA_CREA);
            cmd.Parameters.AddWithValue("@NRO_LETRA", pldTo.NRO_LETRA);
            cmd.Parameters.AddWithValue("@IMP_DEV", pldTo.IMP_DEV);
            cmd.Parameters.AddWithValue("@NRO_PLLA_ORIGEN", pldTo.NRO_PLLA_ORIGEN);
            cmd.Parameters.AddWithValue("@TIPO_PLLA_ORIGEN", pldTo.TIPO_PLLA_ORIGEN);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception e)
            {
                errMensaje = e.Message;
                flag = false;
            }
            finally
            {
                conn.Close();
            }
            return flag;
        }
        public bool modificarPlanillaDetalleOtrasDevDsctosDAL(planillaDetalleOtrasDevDsctosTo pldTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_PLANILLA_DETALLE_OTRAS_DEV_DSCTOS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_PLANILLA_DOC", pldTo.NRO_PLANILLA_DOC);
            cmd.Parameters.AddWithValue("@COD_INSTITUCION", pldTo.COD_INSTITUCION);
            cmd.Parameters.AddWithValue("@COD_CANAL_DSCTO", pldTo.COD_CANAL_DSCTO);
            cmd.Parameters.AddWithValue("@FE_AÑO", pldTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", pldTo.FE_MES);
            cmd.Parameters.AddWithValue("@NRO_PLANILLA_COB", pldTo.NRO_PLANILLA_COB);
            cmd.Parameters.AddWithValue("@IMP_DOC", pldTo.IMP_DOC);
            cmd.Parameters.AddWithValue("@MOTIVO_OTRAS_DEV_DSCTOS", pldTo.MOTIVO_OTRAS_DEV_DSCTOS);
            cmd.Parameters.AddWithValue("@COD_MOD", pldTo.COD_MOD);
            cmd.Parameters.AddWithValue("@FECHA_MOD", pldTo.FECHA_MOD);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception e)
            {
                errMensaje = e.Message;
                flag = false;
            }
            finally
            {
                conn.Close();
            }
            return flag;
        }
        public bool eliminarPlanillaDetalleOtrasDevDsctosDAL(planillaDetalleOtrasDevDsctosTo pldTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_PLANILLA_DETALLE_OTRAS_DEV_DSCTOS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_PLANILLA_DOC", pldTo.NRO_PLANILLA_DOC);
            cmd.Parameters.AddWithValue("@COD_INSTITUCION", pldTo.COD_INSTITUCION);
            cmd.Parameters.AddWithValue("@COD_CANAL_DSCTO", pldTo.COD_CANAL_DSCTO);
            cmd.Parameters.AddWithValue("@FE_AÑO", pldTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", pldTo.FE_MES);
            cmd.Parameters.AddWithValue("@TIPO_PLANILLA_DOC", pldTo.TIPO_PLANILLA_DOC);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception e)
            {
                errMensaje = e.Message;
                flag = false;
            }
            finally
            {
                conn.Close();
            }
            return flag;
        }
        public DataTable obtenerPlanillaDetalleDstoDirectaDAL(planillaDetalleOtrasDevDsctosTo pldTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_PLLA_DETALLE_DSCTO_DIRECTA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_PLANILLA_DOC", pldTo.NRO_PLANILLA_DOC);
            cmd.Parameters.AddWithValue("@COD_INSTITUCION", pldTo.COD_INSTITUCION);
            cmd.Parameters.AddWithValue("@COD_CANAL_DSCTO", pldTo.COD_CANAL_DSCTO);
            cmd.Parameters.AddWithValue("@FE_AÑO", pldTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", pldTo.FE_MES);
            cmd.Parameters.AddWithValue("@NRO_PLANILLA_COB", pldTo.NRO_PLANILLA_COB);
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
