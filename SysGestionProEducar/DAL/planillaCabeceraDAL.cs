using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading;

namespace DAL
{
    public class planillaCabeceraDAL
    {
        SqlConnection conn;
        public planillaCabeceraDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtener_I_Planilla_Cabecera_DAL(planillaCabeceraTo plcTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_I_PLANILLA_COB", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FE_AÑO", plcTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", plcTo.FE_MES);
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
        public bool insertar_I_Planilla_Cabecera_DAL(planillaCabeceraTo plaTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_I_PLANILLA_COB", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            //SqlParameter param = new SqlParameter("@NRO_PLANILLA_COB", SqlDbType.VarChar,20,plaTo.NRO_PLANILLA_COB);
            //param.Direction = ParameterDirection.Output;
            //cmd.Parameters.Add(param);
            cmd.Parameters.AddWithValue("@NRO_PLANILLA_COB", plaTo.NRO_PLANILLA_COB);
            cmd.Parameters.AddWithValue("@COD_INSTITUCION", plaTo.COD_INSTITUCION);
            cmd.Parameters.AddWithValue("@COD_PTO_COB_CONSOLIDADO", plaTo.COD_PTO_COB_CONSOLIDADO);
            cmd.Parameters.AddWithValue("@COD_CANAL_DSCTO", plaTo.COD_CANAL_DSCTO);
            cmd.Parameters.AddWithValue("@FE_AÑO", plaTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", plaTo.FE_MES);
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", plaTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_PTO_COB", plaTo.COD_PTO_COB);
            cmd.Parameters.AddWithValue("@COD_SECTORISTA", plaTo.COD_SECTORISTA);
            cmd.Parameters.AddWithValue("@COD_COBRADOR", plaTo.COD_COBRADOR);
            cmd.Parameters.AddWithValue("@FECHA_PLANILLA_COB", plaTo.FECHA_PLANILLA_COB);
            cmd.Parameters.AddWithValue("@FECHA_VEN_AL", plaTo.FECHA_VEN_AL);
            if (plaTo.FECHA_APROBACION == null)
                cmd.Parameters.AddWithValue("@FECHA_APROBACION", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@FECHA_APROBACION", plaTo.FECHA_APROBACION);
            if (plaTo.FECHA_ENVIO == null)
                cmd.Parameters.AddWithValue("@FECHA_ENVIO", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@FECHA_ENVIO", plaTo.FECHA_ENVIO);
            if (plaTo.FECHA_RECEPCION == null)
                cmd.Parameters.AddWithValue("@FECHA_RECEPCION", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@FECHA_RECEPCION", plaTo.FECHA_RECEPCION);
            if (plaTo.FECHA_PAGO == null)
                cmd.Parameters.AddWithValue("@FECHA_PAGO", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@FECHA_PAGO", plaTo.FECHA_PAGO);
            cmd.Parameters.AddWithValue("@STATUTS_APROBADO", plaTo.STATUTS_APROBADO);
            cmd.Parameters.AddWithValue("@STATUS_ENVIO", plaTo.STATUS_ENVIO);
            cmd.Parameters.AddWithValue("@STATUS_RECEPCION", plaTo.STATUS_RECEPCION);
            cmd.Parameters.AddWithValue("@STATUS_PAGO", plaTo.STATUS_PAGO);
            cmd.Parameters.AddWithValue("@OBSERVACION", plaTo.OBSERVACION);
            cmd.Parameters.AddWithValue("@TIPO_PLANILLA", plaTo.TIPO_PLANILLA);
            cmd.Parameters.AddWithValue("@COD_CREACION", plaTo.COD_CREACION);
            cmd.Parameters.AddWithValue("@FECHA_CREACION", plaTo.FECHA_CREACION);
            cmd.Parameters.AddWithValue("@COD_DOC", plaTo.COD_DOC);
            cmd.Parameters.AddWithValue("@SERIE", plaTo.SERIE);
            cmd.Parameters.AddWithValue("@STATUS_DOC", plaTo.STATUS_DOC);
            cmd.Parameters.AddWithValue("@STATUS_NO_ENVIADO", plaTo.STATUS_NO_ENVIADO);
            cmd.Parameters.AddWithValue("@CANT_CONTRATOS", plaTo.CANT_CONTRATOS);
            cmd.Parameters.AddWithValue("@IMP_ENVIO", plaTo.IMP_ENVIO);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                //plaTo.NRO_PLANILLA_COB = param.Value.ToString();
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
        public DataTable obtenerPCtasCobrar_para_PlanillaDAL(planillaCabeceraTo plcTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_GENERACION_DE_PLANILLA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FECHA_VEN", plcTo.FECHA_VEN_AL);
            cmd.Parameters.AddWithValue("@COD_PTO_COB_CONSOLIDADO", plcTo.COD_PTO_COB_CONSOLIDADO);
            cmd.Parameters.AddWithValue("@COD_CANAL_DSCTO", plcTo.COD_CANAL_DSCTO);
            cmd.Parameters.AddWithValue("@COD_INSTITUCION", plcTo.COD_INSTITUCION);
            cmd.Parameters.AddWithValue("@TIPO_PLANILLA", plcTo.TIPO_PLANILLA);
            cmd.Parameters.AddWithValue("@COD_PROGRAMA", plcTo.COD_PROGRAMA);
            cmd.CommandTimeout = 120;//segundos
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
        public DataTable obtenerClientesparaPlanillaCob()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_CLIENTES_PLANILLA_COB", conn);
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
        public bool modificar_I_Planilla_Cabecera_DAL(planillaCabeceraTo plaTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_I_PLANILLA_COB", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            //SqlParameter param = new SqlParameter("@NRO_PLANILLA_COB", SqlDbType.VarChar,20,plaTo.NRO_PLANILLA_COB);
            //param.Direction = ParameterDirection.Output;
            //cmd.Parameters.Add(param);
            cmd.Parameters.AddWithValue("@NRO_PLANILLA_COB", plaTo.NRO_PLANILLA_COB);
            cmd.Parameters.AddWithValue("@COD_INSTITUCION", plaTo.COD_INSTITUCION);
            cmd.Parameters.AddWithValue("@COD_PTO_COB_CONSOLIDADO", plaTo.COD_PTO_COB_CONSOLIDADO);
            cmd.Parameters.AddWithValue("@COD_CANAL_DSCTO", plaTo.COD_CANAL_DSCTO);
            cmd.Parameters.AddWithValue("@FE_AÑO", plaTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", plaTo.FE_MES);
            cmd.Parameters.AddWithValue("@COD_SECTORISTA", plaTo.COD_SECTORISTA);
            cmd.Parameters.AddWithValue("@COD_COBRADOR", plaTo.COD_COBRADOR);
            cmd.Parameters.AddWithValue("@FECHA_PLANILLA_COB", plaTo.FECHA_PLANILLA_COB);
            cmd.Parameters.AddWithValue("@FECHA_VEN_AL", plaTo.FECHA_VEN_AL);
            //if (plaTo.FECHA_APROBACION == null)
            //    cmd.Parameters.AddWithValue("@FECHA_APROBACION", DBNull.Value);
            //else
            //    cmd.Parameters.AddWithValue("@FECHA_APROBACION", plaTo.FECHA_APROBACION);
            //if (plaTo.FECHA_ENVIO == null)
            //    cmd.Parameters.AddWithValue("@FECHA_ENVIO", DBNull.Value);
            //else
            //    cmd.Parameters.AddWithValue("@FECHA_ENVIO", plaTo.FECHA_ENVIO);
            //if (plaTo.FECHA_RECEPCION == null)
            //    cmd.Parameters.AddWithValue("@FECHA_RECEPCION", DBNull.Value);
            //else
            //    cmd.Parameters.AddWithValue("@FECHA_RECEPCION", plaTo.FECHA_RECEPCION);
            //if (plaTo.FECHA_PAGO == null)
            //    cmd.Parameters.AddWithValue("@FECHA_PAGO", DBNull.Value);
            //else
            //    cmd.Parameters.AddWithValue("@FECHA_PAGO", plaTo.FECHA_PAGO);
            //cmd.Parameters.AddWithValue("@STATUTS_APROBADO", plaTo.STATUTS_APROBADO);
            //cmd.Parameters.AddWithValue("@STATUS_ENVIO", plaTo.STATUS_ENVIO);
            //cmd.Parameters.AddWithValue("@STATUS_RECEPCION", plaTo.STATUS_RECEPCION);
            //cmd.Parameters.AddWithValue("@STATUS_PAGO", plaTo.STATUS_PAGO);
            cmd.Parameters.AddWithValue("@OBSERVACION", plaTo.OBSERVACION);
            //cmd.Parameters.AddWithValue("@TIPO_PLANILLA", plaTo.TIPO_PLANILLA);
            cmd.Parameters.AddWithValue("@COD_MOD", plaTo.COD_MOD);
            cmd.Parameters.AddWithValue("@FECHA_MOD", plaTo.FECHA_MOD);
            cmd.Parameters.AddWithValue("@IMP_ENVIO", plaTo.IMP_ENVIO);
            //cmd.Parameters.AddWithValue("@COD_DOC", plaTo.COD_DOC);
            //cmd.Parameters.AddWithValue("@SERIE", plaTo.SERIE);
            //cmd.Parameters.AddWithValue("@STATUS_DOC", plaTo.STATUS_DOC);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                //plaTo.NRO_PLANILLA_COB = param.Value.ToString();
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
        public bool eliminar_I_Planilla_Cabecera_DAL(planillaCabeceraTo plaTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_I_PLANILLA_COB", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@NRO_PLANILLA_COB", plaTo.NRO_PLANILLA_COB);
            cmd.Parameters.AddWithValue("@COD_INSTITUCION", plaTo.COD_INSTITUCION);
            cmd.Parameters.AddWithValue("@COD_PTO_COB_CONSOLIDADO", plaTo.COD_PTO_COB_CONSOLIDADO);
            cmd.Parameters.AddWithValue("@COD_CANAL_DSCTO", plaTo.COD_CANAL_DSCTO);
            cmd.Parameters.AddWithValue("@FE_AÑO", plaTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", plaTo.FE_MES);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                //plaTo.NRO_PLANILLA_COB = param.Value.ToString();
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
        public bool anular_I_Planilla_Cabecera_DAL(planillaCabeceraTo plaTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ANULAR_I_PLANILLA_COB", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@NRO_PLANILLA_COB", plaTo.NRO_PLANILLA_COB);
            cmd.Parameters.AddWithValue("@COD_INSTITUCION", plaTo.COD_INSTITUCION);
            cmd.Parameters.AddWithValue("@COD_PTO_COB_CONSOLIDADO", plaTo.COD_PTO_COB_CONSOLIDADO);
            cmd.Parameters.AddWithValue("@COD_CANAL_DSCTO", plaTo.COD_CANAL_DSCTO);
            cmd.Parameters.AddWithValue("@FE_AÑO", plaTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", plaTo.FE_MES);
            cmd.Parameters.AddWithValue("@COD_MOD", plaTo.COD_MOD);
            cmd.Parameters.AddWithValue("@FECHA_MOD", plaTo.FECHA_MOD);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                //plaTo.NRO_PLANILLA_COB = param.Value.ToString();
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
        public bool aprobarPlanillaCobDAL(planillaCabeceraTo plaTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("APROBAR_I_PLANILLA_COB", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@NRO_PLANILLA_COB", plaTo.NRO_PLANILLA_COB);
            cmd.Parameters.AddWithValue("@COD_INSTITUCION", plaTo.COD_INSTITUCION);
            cmd.Parameters.AddWithValue("@COD_PTO_COB_CONSOLIDADO", plaTo.COD_PTO_COB_CONSOLIDADO);
            cmd.Parameters.AddWithValue("@COD_CANAL_DSCTO", plaTo.COD_CANAL_DSCTO);
            cmd.Parameters.AddWithValue("@FE_AÑO", plaTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", plaTo.FE_MES);
            cmd.Parameters.AddWithValue("@FECHA_APROBACION", plaTo.FECHA_APROBACION);
            cmd.Parameters.AddWithValue("@COD_MOD", plaTo.COD_MOD);
            cmd.Parameters.AddWithValue("@FECHA_MOD", plaTo.FECHA_MOD);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                //plaTo.NRO_PLANILLA_COB = param.Value.ToString();
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
        public DataTable obtener_Envio_I_Planilla_Cabecera_DAL(planillaCabeceraTo plcTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_ENVIO_I_PLANILLA_COB", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FE_AÑO", plcTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", plcTo.FE_MES);
            cmd.Parameters.AddWithValue("@STATUS_ENVIO", plcTo.STATUS_ENVIO);
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
        public DataTable obtener_Recepcion_I_Planilla_Cabecera_DAL(planillaCabeceraTo plcTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_RECEPCION_I_PLANILLA_COB", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FE_AÑO", plcTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", plcTo.FE_MES);
            cmd.Parameters.AddWithValue("@STATUS_RECEPCION", plcTo.STATUS_RECEPCION);
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
        public DataTable obtener_Cancelacion_R_Planilla_Cabecera_DAL(planillaCabeceraTo plcTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_CANCELACION_I_PLANILLA_COB", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@FE_AÑO", plcTo.FE_AÑO);
            //cmd.Parameters.AddWithValue("@FE_MES", plcTo.FE_MES);
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
        public bool generar_I_Planilla_Cabecera_DAL(planillaCabeceraTo plaTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_GENERAR_I_PLANILLA_COB", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            //SqlParameter param = new SqlParameter("@NRO_PLANILLA_COB", SqlDbType.VarChar,20,plaTo.NRO_PLANILLA_COB);
            //param.Direction = ParameterDirection.Output;
            //cmd.Parameters.Add(param);
            cmd.Parameters.AddWithValue("@NRO_PLANILLA_COB", plaTo.NRO_PLANILLA_COB);
            cmd.Parameters.AddWithValue("@COD_INSTITUCION", plaTo.COD_INSTITUCION);
            cmd.Parameters.AddWithValue("@COD_PTO_COB_CONSOLIDADO", plaTo.COD_PTO_COB_CONSOLIDADO);
            cmd.Parameters.AddWithValue("@COD_CANAL_DSCTO", plaTo.COD_CANAL_DSCTO);
            cmd.Parameters.AddWithValue("@FE_AÑO", plaTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", plaTo.FE_MES);
            cmd.Parameters.AddWithValue("@FECHA_ENVIO", plaTo.FECHA_ENVIO);
            cmd.Parameters.AddWithValue("@COD_MOD", plaTo.COD_MOD);
            cmd.Parameters.AddWithValue("@FECHA_MOD", plaTo.FECHA_MOD);
            cmd.Parameters.AddWithValue("@IMP_ENVIO", plaTo.IMP_ENVIO);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                //plaTo.NRO_PLANILLA_COB = param.Value.ToString();
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
        public bool Actualiza_Recepciona_I_Planilla_Cabecera_DAL(planillaCabeceraTo plaTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_RECEPCIONA_I_PLANILLA_COB", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_PLANILLA_COB", plaTo.NRO_PLANILLA_COB);
            cmd.Parameters.AddWithValue("@COD_INSTITUCION", plaTo.COD_INSTITUCION);
            cmd.Parameters.AddWithValue("@COD_PTO_COB_CONSOLIDADO", plaTo.COD_PTO_COB_CONSOLIDADO);
            cmd.Parameters.AddWithValue("@COD_CANAL_DSCTO", plaTo.COD_CANAL_DSCTO);
            cmd.Parameters.AddWithValue("@FE_AÑO", plaTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", plaTo.FE_MES);
            cmd.Parameters.AddWithValue("@FECHA_RECEPCION", plaTo.FECHA_RECEPCION);
            cmd.Parameters.AddWithValue("@COD_MOD", plaTo.COD_MOD);
            cmd.Parameters.AddWithValue("@FECHA_MOD", plaTo.FECHA_MOD);
            cmd.Parameters.AddWithValue("@STATUS_RECEPCIONADO", plaTo.STATUS_RECEPCIONADO);

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
        public bool Aprobar_Actualiza_Repciona_I_Planilla_Cabecera_DAL(planillaCabeceraTo plaTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_APROBAR_RECEPCIONA_I_PLANILLA_COB", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_PLANILLA_COB", plaTo.NRO_PLANILLA_COB);
            cmd.Parameters.AddWithValue("@COD_INSTITUCION", plaTo.COD_INSTITUCION);
            cmd.Parameters.AddWithValue("@COD_PTO_COB_CONSOLIDADO", plaTo.COD_PTO_COB_CONSOLIDADO);
            cmd.Parameters.AddWithValue("@COD_CANAL_DSCTO", plaTo.COD_CANAL_DSCTO);
            cmd.Parameters.AddWithValue("@FE_AÑO", plaTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", plaTo.FE_MES);
            cmd.Parameters.AddWithValue("@FECHA_RECEPCION", plaTo.FECHA_RECEPCION);
            cmd.Parameters.AddWithValue("@COD_MOD", plaTo.COD_MOD);
            cmd.Parameters.AddWithValue("@FECHA_MOD", plaTo.FECHA_MOD);

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
        public bool Aprueba_Actualiza_Repciona_I_Planilla_Cabecera_DAL(planillaCabeceraTo plaTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_I_CTAS_COBRAR_POR_APROBAR_RECEPCION_COBRANZA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", plaTo.COD_SUCURSAL);
            //cmd.Parameters.AddWithValue("@NRO_CONTRATO", plaTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@COD_PTO_COB_CONSOLIDADO", plaTo.COD_PTO_COB_CONSOLIDADO);
            cmd.Parameters.AddWithValue("@COD_CANAL_DSCTO", plaTo.COD_CANAL_DSCTO);
            cmd.Parameters.AddWithValue("@FE_AÑO", plaTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", plaTo.FE_MES);
            cmd.Parameters.AddWithValue("@FECHA_RECEPCION", plaTo.FECHA_RECEPCION);
            cmd.Parameters.AddWithValue("@COD_MOD", plaTo.COD_MOD);
            cmd.Parameters.AddWithValue("@FECHA_MOD", plaTo.FECHA_MOD);

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
        public bool Aprueba_Actualiza_Repciona_I_PLANILLA_DAL(planillaCabeceraTo plaTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_I_PLANILLA_POR_APROBAR_RECEPCION_COBRANZA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IMP_RECEPCION_CTA_CTE", plaTo.IMP_RECEPCION_CTA_CTE);
            cmd.Parameters.AddWithValue("@IMP_RECEPCION_DEV", plaTo.IMP_RECEPCION_DEV);
            cmd.Parameters.AddWithValue("@NRO_PLANILLA_COB", plaTo.NRO_PLANILLA_COB);
            cmd.Parameters.AddWithValue("@COD_INSTITUCION", plaTo.COD_INSTITUCION);
            cmd.Parameters.AddWithValue("@COD_PTO_COB_CONSOLIDADO", plaTo.COD_PTO_COB_CONSOLIDADO);
            cmd.Parameters.AddWithValue("@COD_CANAL_DSCTO", plaTo.COD_CANAL_DSCTO);
            cmd.Parameters.AddWithValue("@COD_MOD", plaTo.COD_MOD);
            cmd.Parameters.AddWithValue("@FECHA_MOD", plaTo.FECHA_MOD);

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
        public bool Aprueba_Adiciona_Recepciona_R_Planilla_DAL(planillaCabeceraTo plcTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_RECEPCIONA_R_PLANILLA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_PLANILLA_COB", plcTo.NRO_PLANILLA_COB);
            cmd.Parameters.AddWithValue("@COD_INSTITUCION", plcTo.COD_INSTITUCION);
            cmd.Parameters.AddWithValue("@COD_PTO_COB_CONSOLIDADO", plcTo.COD_PTO_COB_CONSOLIDADO);
            cmd.Parameters.AddWithValue("@COD_CANAL_DSCTO", plcTo.COD_CANAL_DSCTO);
            cmd.Parameters.AddWithValue("@FE_AÑO", plcTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", plcTo.FE_MES);
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", plcTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_PTO_COB", plcTo.COD_PTO_COB);
            cmd.Parameters.AddWithValue("@FECHA_PLANILLA_COB", plcTo.FECHA_PLANILLA_COB);
            cmd.Parameters.AddWithValue("@FECHA_RECEPCION", plcTo.FECHA_RECEPCION);
            //if (plcTo.FECHA_PAGO == null)
            //    cmd.Parameters.AddWithValue("FECHA_PAGO",DBNull.Value);
            //else
            //    cmd.Parameters.AddWithValue("@FECHA_PAGO", plcTo.FECHA_PAGO);
            //cmd.Parameters.AddWithValue("@STATUS_PAGO", plcTo.STATUS_PAGO);
            cmd.Parameters.AddWithValue("@OBSERVACION", plcTo.OBSERVACION);
            cmd.Parameters.AddWithValue("@TIPO_PLANILLA", plcTo.TIPO_PLANILLA);
            cmd.Parameters.AddWithValue("@COD_MOD", plcTo.COD_MONEDA);
            cmd.Parameters.AddWithValue("@IMP_ENV", plcTo.IMP_ENVIO);
            cmd.Parameters.AddWithValue("@IMP_RECEPCION_INI", plcTo.IMP_RECEPCION_INI);
            cmd.Parameters.AddWithValue("@IMP_RECEPCION_DOC", plcTo.IMP_RECEPCION_DOC);
            cmd.Parameters.AddWithValue("@IMP_RECEPCION_DEV", plcTo.IMP_RECEPCION_DEV);
            cmd.Parameters.AddWithValue("@COD_CREACION", plcTo.COD_MOD);
            cmd.Parameters.AddWithValue("@FECHA_CREACION", plcTo.FECHA_MOD);

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
        public DataTable obtener_Consulta_I_Planilla_DAL(planillaCabeceraTo plcTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_CONSULTA_I_PLANILLA_COB", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FE_AÑO", plcTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", plcTo.FE_MES);
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
        public DataTable obtener_R_Planilla_DAL(planillaCabeceraTo plcTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_CONSULTA_R_PLANILLA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_PLANILLA_COB", plcTo.NRO_PLANILLA_COB);
            cmd.Parameters.AddWithValue("@COD_INSTITUCION", plcTo.COD_INSTITUCION);
            cmd.Parameters.AddWithValue("@COD_PTO_COB_CONSOLIDADO", plcTo.COD_PTO_COB_CONSOLIDADO);
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
        public DataTable obtenerPtosCobranzaConsolidadosGeneradosXmesDAL(string MES, string AÑO)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_PTOS_COB_CONS_X_MES", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FECHA_MES", MES);
            cmd.Parameters.AddWithValue("@FECHA_AÑO", AÑO);
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
        public bool Retornar_a_Generacion_DAL(planillaCabeceraTo plaTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("RETORNAR_A_GENERACION_I_PLANILLA_COB", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@NRO_PLANILLA_COB", plaTo.NRO_PLANILLA_COB);
            cmd.Parameters.AddWithValue("@COD_INSTITUCION", plaTo.COD_INSTITUCION);
            cmd.Parameters.AddWithValue("@COD_PTO_COB_CONSOLIDADO", plaTo.COD_PTO_COB_CONSOLIDADO);
            cmd.Parameters.AddWithValue("@COD_CANAL_DSCTO", plaTo.COD_CANAL_DSCTO);
            cmd.Parameters.AddWithValue("@FE_AÑO", plaTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", plaTo.FE_MES);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                //plaTo.NRO_PLANILLA_COB = param.Value.ToString();
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
        public bool Aprobar_R_PlanillaDAL(planillaCabeceraTo plaTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("APROBAR_R_PLANILLA", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@NRO_PLANILLA_COB", plaTo.NRO_PLANILLA_COB);
            cmd.Parameters.AddWithValue("@COD_INSTITUCION", plaTo.COD_INSTITUCION);
            cmd.Parameters.AddWithValue("@COD_PTO_COB_CONSOLIDADO", plaTo.COD_PTO_COB_CONSOLIDADO);
            cmd.Parameters.AddWithValue("@COD_CANAL_DSCTO", plaTo.COD_CANAL_DSCTO);
            cmd.Parameters.AddWithValue("@FE_AÑO", plaTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", plaTo.FE_MES);
            cmd.Parameters.AddWithValue("@COD_PTO_COB", plaTo.COD_PTO_COB);
            cmd.Parameters.AddWithValue("@COD_MOD", plaTo.COD_MOD);
            cmd.Parameters.AddWithValue("@FECHA_MOD", plaTo.FECHA_MOD);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                //plaTo.NRO_PLANILLA_COB = param.Value.ToString();
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
        public DataTable obtenerPlanillaNoEnviadaBLLporPtoCobranzaDAL(planillaCabeceraTo plcTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_PLANILLA_NO_ENVIADA_POR_PUNTO_COBRANZA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PTO_COB_CONSOLIDADO", plcTo.COD_PTO_COB_CONSOLIDADO);
            cmd.Parameters.AddWithValue("@TIPO_PLANILLA", plcTo.TIPO_PLANILLA);
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
        public DataTable obtenerPlanillaInformativaDAL(planillaCabeceraTo plcTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_T_PLANILLA_INFORMATIVA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_INSTITUCION", plcTo.COD_INSTITUCION);
            cmd.Parameters.AddWithValue("@COD_PTO_COB_CONSOLIDADO", plcTo.COD_PTO_COB);
            cmd.Parameters.AddWithValue("@COD_CANAL_DSCTO", plcTo.COD_CANAL_DSCTO);
            cmd.Parameters.AddWithValue("@FE_AÑO", plcTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", plcTo.FE_MES);
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
        public DataTable obtenerNroPlanillaparaRepEnviadosDAL(planillaCabeceraTo plcTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_NRO_PLANILLA_PARA_REP_ENVIADOS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_INSTITUCION", plcTo.COD_INSTITUCION);
            cmd.Parameters.AddWithValue("@COD_CANAL_DSCTO", plcTo.COD_CANAL_DSCTO);
            cmd.Parameters.AddWithValue("@FE_AÑO", plcTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", plcTo.FE_MES);
            cmd.Parameters.AddWithValue("@OP", plcTo.OP);
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
        public bool adicionaTablaParametrosDAL(string nro_planilla, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_TABLA_PARAM_PLANILLA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PARAMETROS", nro_planilla);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                //plaTo.NRO_PLANILLA_COB = param.Value.ToString();
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
        public bool eliminaTablaParamPlanillaDAL(ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_TABLA_PARAM_PLANILLA", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                //plaTo.NRO_PLANILLA_COB = param.Value.ToString();
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
        public DataTable obtenerReportePlanillaCobInternaEnviadaDetalleDAL(planillaCabeceraTo plcTo)
        {
            DataTable dt = new DataTable();
            //SqlCommand cmd = new SqlCommand("REPORTE_PLANILLA_COBRANZA_ENVIADA_DETALLE", conn);
            SqlCommand cmd = new SqlCommand("REPORTE_PLANILLA_COBRANZA_ENVIADA_DETALLE_MOTIVOS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@OP", plcTo.OP);
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
        public DataTable reportePlanillaInformativaDAL(planillaCabeceraTo plcTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("REPORTE_T_PLANILLA_INFORMATIVA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_INSTITUCION", plcTo.COD_INSTITUCION);
            cmd.Parameters.AddWithValue("@COD_PTO_COB_CONSOLIDADO", plcTo.COD_PTO_COB);
            cmd.Parameters.AddWithValue("@COD_CANAL_DSCTO", plcTo.COD_CANAL_DSCTO);
            cmd.Parameters.AddWithValue("@FE_AÑO", plcTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", plcTo.FE_MES);
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
        public DataTable obtenerPlanillaDescuentoCabeceraxNroPllaDAL(planillaCabeceraTo plcTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_RECEPCION_I_PLANILLA_COB_X_NRO_CONTRATO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_PLANILLA_COB", plcTo.NRO_PLANILLA_COB);
            cmd.Parameters.AddWithValue("@TIPO_PLANILLA", plcTo.TIPO_PLANILLA);
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

        public DataTable AnalisisCarteraXTrabajar(CancellationToken cancellationToken, DateTime fechaReporte)
        {
            try
            {
                const string sentencia = "dsp_RptCarteraTotalXTrabjar";
                using (SqlConnection cn = new SqlConnection(conexion.con))
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand(sentencia, cn)
                    {
                        CommandType = CommandType.StoredProcedure,
                        CommandTimeout = 5000
                    };

                    _ = cmd.Parameters.AddWithValue("@FECHA_REPORTE", fechaReporte);

                    using (SqlDataReader dr = cmd.ExecuteReaderAsync(cancellationToken).Result)
                    {
                        if (dr.HasRows)
                        {
                            DataTable dt = new DataTable();
                            dt.Load(dr, LoadOption.OverwriteChanges);
                            return dt;
                        }
                        return null;
                    }
                }
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
