using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class planillaDirectaDAL
    {
        SqlConnection conn;
        public planillaDirectaDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable mostrar_Contratos_Vencidos_a_la_FechaDAL(planillaDirectaTo pldTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("GENERAR_PLANILLA_DIRECTA", conn);
            cmd.Parameters.AddWithValue("@FECHA_VEN", pldTo.FECHA_VEN);
            cmd.Parameters.AddWithValue("@TIPO", pldTo.TIPO);
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
        public DataTable obtenerPlanillaDirectaDAL(planillaDirectaTo pldTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_PLANILLA_DIRECTA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FECHA_LLAMADA", pldTo.FECHA_LLAMADA);
            cmd.Parameters.AddWithValue("@TIPO", pldTo.TIPO);
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
        public DataTable obtenerPlanillaDirectaporLlaveDAL(planillaDirectaTo pldTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_PLANILLA_DIRECTA_POR_LLAVE", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", pldTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@COD_PERSONA", pldTo.COD_PERSONA);
            cmd.Parameters.AddWithValue("@TIPO", pldTo.TIPO);
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
        public bool generaPlanillaDirectaDAL(planillaDirectaTo pldTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_T_PLANILLA_DIRECTA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FECHA_VEN", pldTo.FECHA_VEN);
            cmd.Parameters.AddWithValue("@COD_CREACION", pldTo.COD_CREACION);
            cmd.Parameters.AddWithValue("@FECHA_CREACION", pldTo.FECHA_CREACION);
            // AQUI VAN MAS COSAS





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
        public bool modificaPCtasCobrarporLlamadaConfirmadaDAL(planillaDirectaTo pldTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_PCTAS_COBRAR_POR_LLAMADA_CONFIRMADA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FECHA_VEN", pldTo.FECHA_VEN);
            cmd.Parameters.AddWithValue("@COD_MOD", pldTo.COD_CREACION);
            cmd.Parameters.AddWithValue("@FECHA_MOD", pldTo.FECHA_CREACION);
            cmd.Parameters.AddWithValue("@TIPO", pldTo.TIPO);
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
        public DataTable Mostrar_Cobranza_Planilla_por_Llamada_DAL(planillaDirectaTo pldTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_COBRANZA_PLANILLA_POR_LLAMADA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", pldTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@FECHA_VEN", pldTo.FECHA_VEN);
            cmd.Parameters.AddWithValue("@TIPO", pldTo.TIPO);
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
        public bool modificarPlanillaDirectaDAL(planillaDirectaTo pldTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_PLANILLA_DIRECTA_POR_EVALUACION_LLAMADA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", pldTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@COD_PERSONA", pldTo.COD_PERSONA);
            cmd.Parameters.AddWithValue("@COD_LLAMADA", pldTo.COD_LLAMADA);
            if (pldTo.FECHA_NUEVA_LLAMADA == null)
                cmd.Parameters.AddWithValue("@FECHA_NUEVA_LLAMADA", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@FECHA_NUEVA_LLAMADA", pldTo.FECHA_NUEVA_LLAMADA);
            if (pldTo.OBSERVACIONES == null)
                cmd.Parameters.AddWithValue("@OBSERVACIONES", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@OBSERVACIONES", pldTo.OBSERVACIONES);
            cmd.Parameters.AddWithValue("@COD_MOD", pldTo.COD_MOD);
            cmd.Parameters.AddWithValue("@FECHA_MOD", pldTo.FECHA_MOD);
            if (pldTo.VISTO_CONFIRMADO == null)
                cmd.Parameters.AddWithValue("@VISTO_CONFIRMADO", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@VISTO_CONFIRMADO", pldTo.VISTO_CONFIRMADO);
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
        public bool modificarPlanillaDirectaRehacerDAL(planillaDirectaTo pldTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_PLANILLA_DIRECTA_POR_EVALUACION_LLAMADA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", pldTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@COD_PERSONA", pldTo.COD_PERSONA);
            if (pldTo.COD_LLAMADA == null)
                cmd.Parameters.AddWithValue("@COD_LLAMADA", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@COD_LLAMADA", pldTo.COD_LLAMADA);
            if (pldTo.FECHA_NUEVA_LLAMADA == null)
                cmd.Parameters.AddWithValue("@FECHA_NUEVA_LLAMADA", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@FECHA_NUEVA_LLAMADA", pldTo.FECHA_NUEVA_LLAMADA);
            if (pldTo.OBSERVACIONES == null)
                cmd.Parameters.AddWithValue("@OBSERVACIONES", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@OBSERVACIONES", pldTo.OBSERVACIONES);
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
                flag = false;
                errMensaje = e.Message;
            }
            finally
            {
                conn.Close();
            }
            return flag;
        }
        public bool modificarPlanillaDirectaporLlamadaDAL(planillaDirectaTo pldTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_PLANILLA_DIRECTA_POR_LLAMADA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", pldTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@COD_PERSONA", pldTo.COD_PERSONA);
            cmd.Parameters.AddWithValue("@IMPORTE_CUOTA", pldTo.IMPORTE_CUOTA);
            //cmd.Parameters.AddWithValue("@FECHA_NUEVA_LLAMADA", pldTo.FECHA_NUEVA_LLAMADA);
            //cmd.Parameters.AddWithValue("@OBSERVACIONES", pldTo.OBSERVACIONES);
            cmd.Parameters.AddWithValue("@COD_MOD", pldTo.COD_CREACION);
            cmd.Parameters.AddWithValue("@FECHA_MOD", pldTo.FECHA_MOD);
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
        public bool modificarPlanillaDirectaporLlamadaRehacerDAL(planillaDirectaTo pldTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_PLANILLA_DIRECTA_POR_LLAMADA_REHACER", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", pldTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@COD_PERSONA", pldTo.COD_PERSONA);
            cmd.Parameters.AddWithValue("@IMPORTE_CUOTA", pldTo.IMPORTE_CUOTA);
            //cmd.Parameters.AddWithValue("@OBSERVACIONES", pldTo.OBSERVACIONES);
            cmd.Parameters.AddWithValue("@COD_MOD", pldTo.COD_CREACION);
            cmd.Parameters.AddWithValue("@FECHA_MOD", pldTo.FECHA_MOD);
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
        public bool existeTPlanillaDirectaDAL(planillaDirectaTo pldTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("VERIFICA_EXISTE_T_PLANILLA_DIRECTA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", pldTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@COD_PERSONA", pldTo.COD_PERSONA);
            cmd.Parameters.AddWithValue("@TIPO", pldTo.TIPO);
            try
            {
                conn.Open();
                flag = Convert.ToBoolean(cmd.ExecuteScalar());
                //flag = true;
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
        public bool modificaTPlanillaDirectaporContratosporVencerDAL(planillaDirectaTo pldTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_T_PLANILLA_DIRECTA_POR_CONTRATOS_POR_VENCER", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", pldTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@COD_PERSONA", pldTo.COD_PERSONA);
            cmd.Parameters.AddWithValue("@IMPORTE_CUOTA", pldTo.IMPORTE_CUOTA);
            cmd.Parameters.AddWithValue("@COD_MOD", pldTo.COD_CREACION);
            cmd.Parameters.AddWithValue("@FECHA_MOD", pldTo.FECHA_CREACION);
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
        public bool modificaTPlanillaDirectaporContratosporCierreDAL(planillaDirectaTo pldTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_T_PLANILLA_DIRECTA_POR_CONTRATOS_POR_CIERRE", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", pldTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@COD_PERSONA", pldTo.COD_PERSONA);
            cmd.Parameters.AddWithValue("@FECHA_LLAMADA", pldTo.FECHA_NUEVA_LLAMADA);//se pone la nueva fecha activa
            cmd.Parameters.AddWithValue("@IMPORTE_CUOTA", pldTo.IMPORTE_CUOTA);
            cmd.Parameters.AddWithValue("@COD_MOD", pldTo.COD_CREACION);
            cmd.Parameters.AddWithValue("@FECHA_MOD", pldTo.FECHA_CREACION);
            cmd.Parameters.AddWithValue("@TIPO", pldTo.TIPO);
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
        public bool insertaTPlanillaDirectaporContratosporVencerDAL(planillaDirectaTo pldTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_T_PLANILLA_DIRECTA_POR_CONTRATOS_POR_VENCER", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", pldTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@COD_PERSONA", pldTo.COD_PERSONA);
            cmd.Parameters.AddWithValue("@FECHA_CONTRATO", pldTo.FECHA_CONTRATO);
            cmd.Parameters.AddWithValue("@FECHA_LLAMADA", pldTo.FECHA_NUEVA_LLAMADA);//esta es la nueva fecha activa del dia siguiente
            cmd.Parameters.AddWithValue("@CANT_CUOTA", pldTo.CANT_CUOTA);
            cmd.Parameters.AddWithValue("@IMPORTE_CUOTA", pldTo.IMPORTE_CUOTA);
            cmd.Parameters.AddWithValue("@COD_CREACION", pldTo.COD_CREACION);
            cmd.Parameters.AddWithValue("@FECHA_CREACION", pldTo.FECHA_CREACION);
            cmd.Parameters.AddWithValue("@TIPO", pldTo.TIPO);
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
        public bool actualizaTPlanillaDirectaporConfirmacionDAL(planillaDirectaTo pldTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_T_PLANILLA_DIRECTA_POR_CONFIRMACION", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", pldTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@COD_PERSONA", pldTo.COD_PERSONA);
            //cmd.Parameters.AddWithValue("@FECHA_NUEVA_LLAMADA", pldTo.FECHA_NUEVA_LLAMADA);
            //cmd.Parameters.AddWithValue("@OBSERVACIONES", pldTo.OBSERVACIONES);
            cmd.Parameters.AddWithValue("@COD_MOD", pldTo.COD_CREACION);
            cmd.Parameters.AddWithValue("@FECHA_MOD", pldTo.FECHA_MOD);
            cmd.Parameters.AddWithValue("@TIPO", pldTo.TIPO);
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
        public bool esFeriadoDAL(DateTime fec, planillaDirectaTo pldTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("VERIFICA_EXISTE_FERIADO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Fecha", fec);
            cmd.Parameters.AddWithValue("@TIPO", pldTo.TIPO);
            try
            {
                conn.Open();
                flag = Convert.ToBoolean(cmd.ExecuteScalar());
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
        public bool modificaTPlanillaDirectaporCierre1BLL(planillaDirectaTo pldTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_T_PLANILLA_DIRECTA_POR_CIERRE_DEL_DIA1", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FECHA_LLAMADA", pldTo.FECHA_LLAMADA);
            cmd.Parameters.AddWithValue("@COD_MOD", pldTo.COD_CREACION);
            cmd.Parameters.AddWithValue("@FECHA_MOD", pldTo.FECHA_CREACION);
            cmd.Parameters.AddWithValue("@TIPO", pldTo.TIPO);
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
        public bool modificaTPlanillaDirectaporCierre2BLL(planillaDirectaTo pldTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_T_PLANILLA_DIRECTA_POR_CIERRE_DEL_DIA2", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FECHA_LLAMADA", pldTo.FECHA_LLAMADA);
            cmd.Parameters.AddWithValue("@FECHA_NUEVA_LLAMADA", pldTo.FECHA_NUEVA_LLAMADA);
            cmd.Parameters.AddWithValue("@COD_MOD", pldTo.COD_CREACION);
            cmd.Parameters.AddWithValue("@FECHA_MOD", pldTo.FECHA_CREACION);
            cmd.Parameters.AddWithValue("@TIPO", pldTo.TIPO);
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
