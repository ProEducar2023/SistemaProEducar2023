using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class planillaDetalleDAL
    {
        SqlConnection conn;
        public planillaDetalleDAL()
        {
            conn = new SqlConnection(conexion.con);
        }

        public DataTable obtener_I_Planilla_Detalle_DAL(planillaDetalleTo pldTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_T_PLANILLA_COB_DETALLE", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_PLANILLA_COB", pldTo.NRO_PLANILLA_COB);
            cmd.Parameters.AddWithValue("@COD_INSTITUCION", pldTo.COD_INSTITUCION);
            cmd.Parameters.AddWithValue("@COD_PTO_COB_CONSOLIDADO", pldTo.COD_PTO_COB_CONSOLIDADO);
            cmd.Parameters.AddWithValue("@COD_CANAL_DSCTO", pldTo.COD_CANAL_DSCTO);
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
        public bool insertar_T_Planilla_Detalle_DAL(planillaDetalleTo pldTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_I_PLANILLA_COB_DETALLE", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_PLANILLA_COB", pldTo.NRO_PLANILLA_COB);
            cmd.Parameters.AddWithValue("@COD_INSTITUCION", pldTo.COD_INSTITUCION);
            cmd.Parameters.AddWithValue("@COD_PTO_COB_CONSOLIDADO", pldTo.COD_PTO_COB_CONSOLIDADO);
            cmd.Parameters.AddWithValue("@COD_CANAL_DSCTO", pldTo.COD_CANAL_DSCTO);
            cmd.Parameters.AddWithValue("@FE_AÑO", pldTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", pldTo.FE_MES);
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", pldTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@COD_PER", pldTo.COD_PER);
            cmd.Parameters.AddWithValue("@COD_DOC", pldTo.COD_DOC);
            cmd.Parameters.AddWithValue("@NRO_DOC", pldTo.NRO_DOC);
            if (pldTo.FECHA_VEN == null)
                cmd.Parameters.AddWithValue("@FECHA_VEN", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@FECHA_VEN", pldTo.FECHA_VEN);
            cmd.Parameters.AddWithValue("@IMP_DOC", pldTo.IMP_DOC);
            cmd.Parameters.AddWithValue("@IMP_COB", pldTo.IMP_COB);
            cmd.Parameters.AddWithValue("@IMP_COB_CTA_CTE", pldTo.IMP_COB_CTA_CTE);
            cmd.Parameters.AddWithValue("@IMP_DEV", pldTo.IMP_DEV);
            cmd.Parameters.AddWithValue("@NRO_LETRA", pldTo.NRO_LETRA);
            cmd.Parameters.AddWithValue("@TOT_LETRA", pldTo.TOT_LETRA);
            cmd.Parameters.AddWithValue("@TIPO_PLANILLA", pldTo.TIPO_PLANILLA);
            cmd.Parameters.AddWithValue("@TIPO_GENERACION", pldTo.TIPO_GENERACION);
            cmd.Parameters.AddWithValue("@COD_MOTIVO_NO_DESCONTADO", pldTo.COD_MOTIVO_NO_DESCONTADO);
            cmd.Parameters.AddWithValue("@OBSERVACION", pldTo.OBSERVACION);
            cmd.Parameters.AddWithValue("@COD_PTO_COB", pldTo.COD_PTO_COB);
            cmd.Parameters.AddWithValue("@COD_PTO_VEN", pldTo.COD_PTO_VEN);
            cmd.Parameters.AddWithValue("@COD_CREACION", pldTo.COD_CREACION);
            cmd.Parameters.AddWithValue("@FECHA_CREACION", pldTo.FECHA_CREACION);
            cmd.Parameters.AddWithValue("@OK", pldTo.OK);

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
        public bool eliminar_I_Planilla_Detalle_DAL(planillaCabeceraTo plcTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINA_T_PLANILLA_COB_DETALLE", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_PLANILLA_COB", plcTo.NRO_PLANILLA_COB);
            cmd.Parameters.AddWithValue("@COD_INSTITUCION", plcTo.COD_INSTITUCION);
            cmd.Parameters.AddWithValue("@COD_PTO_COB_CONSOLIDADO", plcTo.COD_PTO_COB_CONSOLIDADO);
            cmd.Parameters.AddWithValue("@COD_CANAL_DSCTO", plcTo.COD_CANAL_DSCTO);
            cmd.Parameters.AddWithValue("@FE_AÑO", plcTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", plcTo.FE_MES);

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
        public DataTable obtener_I_Planilla_Detalle_Envio_DAL(planillaDetalleTo pldTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_T_PLANILLA_COB_DETALLE_ENVIO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_PLANILLA_COB", pldTo.NRO_PLANILLA_COB);
            cmd.Parameters.AddWithValue("@COD_INSTITUCION", pldTo.COD_INSTITUCION);
            cmd.Parameters.AddWithValue("@COD_PTO_COB_CONSOLIDADO", pldTo.COD_PTO_COB_CONSOLIDADO);
            cmd.Parameters.AddWithValue("@COD_CANAL_DSCTO", pldTo.COD_CANAL_DSCTO);
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
        public bool Actualiza_Repciona_T_Planilla_Detalle_DAL(planillaDetalleTo pldTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_RECEPCIONA_T_PLANILLA_COB", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_PLANILLA_COB", pldTo.NRO_PLANILLA_COB);
            cmd.Parameters.AddWithValue("@COD_INSTITUCION", pldTo.COD_INSTITUCION);
            cmd.Parameters.AddWithValue("@COD_PTO_COB_CONSOLIDADO", pldTo.COD_PTO_COB_CONSOLIDADO);
            cmd.Parameters.AddWithValue("@COD_CANAL_DSCTO", pldTo.COD_CANAL_DSCTO);
            cmd.Parameters.AddWithValue("@FE_AÑO", pldTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", pldTo.FE_MES);
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", pldTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@NRO_DOC", pldTo.NRO_DOC);
            cmd.Parameters.AddWithValue("@IMP_COB", pldTo.IMP_COB);
            cmd.Parameters.AddWithValue("@IMP_COB_CTA_CTE", pldTo.IMP_COB_CTA_CTE);
            cmd.Parameters.AddWithValue("@IMP_DEV", pldTo.IMP_DEV);
            cmd.Parameters.AddWithValue("@COD_MOD", pldTo.COD_MOD);
            cmd.Parameters.AddWithValue("@FECHA_MOD", pldTo.FECHA_MOD);
            cmd.Parameters.AddWithValue("@COD_PER", pldTo.COD_PER);
            cmd.Parameters.AddWithValue("@COD_DOC", pldTo.COD_DOC);
            if (pldTo.FECHA_VEN == null)
                cmd.Parameters.AddWithValue("@FECHA_VEN", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@FECHA_VEN", pldTo.FECHA_VEN);
            cmd.Parameters.AddWithValue("@IMP_DOC", pldTo.IMP_DOC);
            cmd.Parameters.AddWithValue("@NRO_LETRA", pldTo.NRO_LETRA);
            cmd.Parameters.AddWithValue("@TOT_LETRA", pldTo.TOT_LETRA);
            cmd.Parameters.AddWithValue("@TIPO_PLANILLA", pldTo.TIPO_PLANILLA);
            cmd.Parameters.AddWithValue("@TIPO_GENERACION", pldTo.TIPO_GENERACION);
            cmd.Parameters.AddWithValue("@COD_MOTIVO_NO_DESCONTADO", pldTo.COD_MOTIVO_NO_DESCONTADO);
            cmd.Parameters.AddWithValue("@OBSERVACION", pldTo.OBSERVACION);
            cmd.Parameters.AddWithValue("@COD_PTO_COB", pldTo.COD_PTO_COB);
            cmd.Parameters.AddWithValue("@COD_CREACION", pldTo.COD_CREACION);
            cmd.Parameters.AddWithValue("@FECHA_CREACION", pldTo.FECHA_CREACION);
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", pldTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@OK", pldTo.OK);

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
        public DataTable obtener_I_Planilla_Detalle_para_Recepcion_DAL(planillaDetalleTo pldTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_T_PLANILLA_COB_DETALLE_PARA_RECEPCION", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_PLANILLA_COB", pldTo.NRO_PLANILLA_COB);
            cmd.Parameters.AddWithValue("@COD_INSTITUCION", pldTo.COD_INSTITUCION);
            cmd.Parameters.AddWithValue("@COD_PTO_COB_CONSOLIDADO", pldTo.COD_PTO_COB_CONSOLIDADO);
            cmd.Parameters.AddWithValue("@COD_CANAL_DSCTO", pldTo.COD_CANAL_DSCTO);
            cmd.Parameters.AddWithValue("@FE_AÑO", pldTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", pldTo.FE_MES);
            //cmd.Parameters.AddWithValue("@COD_PTO_COB", pldTo.COD_PTO_COB);
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
        public DataTable obtener_I_Planilla_Detalle_para_Recepcion_Consolidado_DAL(planillaDetalleTo pldTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_T_PLANILLA_COB_DETALLE_PARA_RECEPCION_CONSOLIDADO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_PLANILLA_COB", pldTo.NRO_PLANILLA_COB);
            cmd.Parameters.AddWithValue("@COD_INSTITUCION", pldTo.COD_INSTITUCION);
            cmd.Parameters.AddWithValue("@COD_PTO_COB_CONSOLIDADO", pldTo.COD_PTO_COB_CONSOLIDADO);
            cmd.Parameters.AddWithValue("@COD_CANAL_DSCTO", pldTo.COD_CANAL_DSCTO);
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
        public DataTable obtener_I_Planilla_Detalle_para_Aprobar_Recepcion_Planilla_DAL(planillaDetalleTo pldTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_T_PLANILLA_COB_DETALLE_PARA_APROBAR_RECEPCION_PLANILLA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_PLANILLA_COB", pldTo.NRO_PLANILLA_COB);
            cmd.Parameters.AddWithValue("@COD_INSTITUCION", pldTo.COD_INSTITUCION);
            cmd.Parameters.AddWithValue("@COD_PTO_COB_CONSOLIDADO", pldTo.COD_PTO_COB_CONSOLIDADO);
            cmd.Parameters.AddWithValue("@COD_CANAL_DSCTO", pldTo.COD_CANAL_DSCTO);
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
        public DataTable obtener_I_Planilla_Detalle_para_Cancelacion_DAL(planillaDetalleTo pldTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_T_PLANILLA_COB_DETALLE_PARA_CANCELACION", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_PLANILLA_COB", pldTo.NRO_PLANILLA_COB);
            cmd.Parameters.AddWithValue("@COD_INSTITUCION", pldTo.COD_INSTITUCION);
            cmd.Parameters.AddWithValue("@COD_PTO_COB", pldTo.COD_PTO_COB);
            cmd.Parameters.AddWithValue("@COD_CANAL_DSCTO", pldTo.COD_CANAL_DSCTO);
            //cmd.Parameters.AddWithValue("@FE_AÑO", pldTo.FE_AÑO);
            //cmd.Parameters.AddWithValue("@FE_MES", pldTo.FE_MES);
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
        public bool eliminar_T_Planilla_Detalle_Modificar_BLL(planillaDetalleTo pldTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINA_T_PLANILLA_DETALLE_MODIFICAR", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_PLANILLA_COB", pldTo.NRO_PLANILLA_COB);
            cmd.Parameters.AddWithValue("@COD_INSTITUCION", pldTo.COD_INSTITUCION);
            cmd.Parameters.AddWithValue("@COD_PTO_COB_CONSOLIDADO", pldTo.COD_PTO_COB_CONSOLIDADO);
            cmd.Parameters.AddWithValue("@COD_CANAL_DSCTO", pldTo.COD_CANAL_DSCTO);
            cmd.Parameters.AddWithValue("@FE_AÑO", pldTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", pldTo.FE_MES);

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
        public bool insertarPersonaIndebidaPlanillaDAL(planillaDetalleTo pldTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_PERSONA_INDEBIDA_PLANILLA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_PLANILLA_COB", pldTo.NRO_PLANILLA_COB);
            cmd.Parameters.AddWithValue("@COD_INSTITUCION", pldTo.COD_INSTITUCION);
            cmd.Parameters.AddWithValue("@COD_PTO_COB_CONSOLIDADO", pldTo.COD_PTO_COB_CONSOLIDADO);
            cmd.Parameters.AddWithValue("@COD_CANAL_DSCTO", pldTo.COD_CANAL_DSCTO);
            cmd.Parameters.AddWithValue("@FE_AÑO", pldTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", pldTo.FE_MES);
            cmd.Parameters.AddWithValue("@DESC_PER", pldTo.CLIENTE);
            cmd.Parameters.AddWithValue("@DNI_RUC", pldTo.DNI);
            cmd.Parameters.AddWithValue("@FECHA_PLANILLA_COB", pldTo.FECHA_PLANILLA_COB);
            cmd.Parameters.AddWithValue("@IMP_COB", pldTo.IMP_COB);
            cmd.Parameters.AddWithValue("@COD_CREA", pldTo.COD_CREACION);
            cmd.Parameters.AddWithValue("@FECHA_CREA", pldTo.FECHA_CREACION);
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
