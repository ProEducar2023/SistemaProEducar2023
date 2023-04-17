using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class planillaDirectaSeguimientoDAL
    {
        SqlConnection conn;
        public planillaDirectaSeguimientoDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerPlanillaDirectaSeguimientoLlamadaDAL(planillaDirectaSeguimientoTo plsTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_PLANILLA_DIRECTA_SEGUIMIENTO_POR_LLAMADA", conn);
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", plsTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@COD_PERSONA", plsTo.COD_PERSONA);
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
        public DataTable obtenerPlanillaDirectaSeguimientoConfirmacionPagoDAL(planillaDirectaSeguimientoTo plsTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_PLANILLA_DIRECTA_SEGUIMIENTO_POR_CONFIRMACION_PAGO", conn);
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", plsTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@COD_PERSONA", plsTo.COD_PERSONA);
            cmd.Parameters.AddWithValue("@NRO_CUOTA", plsTo.NRO_CUOTA);
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
        public bool insertarPlanillaDirectaSeguimientoDAL(planillaDirectaSeguimientoTo plsTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_PLANILLA_DIRECTA_SEGUIMIENTO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", plsTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@COD_PERSONA", plsTo.COD_PERSONA);
            cmd.Parameters.AddWithValue("@NRO_CUOTA", plsTo.NRO_CUOTA);
            cmd.Parameters.AddWithValue("@TIPO", plsTo.TIPO);
            cmd.Parameters.AddWithValue("@FECHA_LLAMADA", plsTo.FECHA_LLAMADA);
            cmd.Parameters.AddWithValue("@COD_LLAMADA_LL ", plsTo.COD_LLAMADA_LL);
            cmd.Parameters.AddWithValue("@DES_LLAMADA_LL ", plsTo.DES_LLAMADA_LL);
            if (plsTo.FECHA_NUEVA_LLAMADA_LL == null)
                cmd.Parameters.AddWithValue("@FECHA_NUEVA_LLAMADA_LL", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@FECHA_NUEVA_LLAMADA_LL", plsTo.FECHA_NUEVA_LLAMADA_LL);
            cmd.Parameters.AddWithValue("@OBS_LLAMADA_LL", plsTo.OBS_LLAMADA_LL);
            cmd.Parameters.AddWithValue("@COD_LLAMADA_CO", plsTo.COD_LLAMADA_CO);
            cmd.Parameters.AddWithValue("@DES_LLAMADA_CO", plsTo.DES_LLAMADA_CO);
            if (plsTo.FECHA_NUEVA_LLAMADA_CO == null)
                cmd.Parameters.AddWithValue("@FECHA_NUEVA_LLAMADA_CO", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@FECHA_NUEVA_LLAMADA_CO", plsTo.FECHA_NUEVA_LLAMADA_CO);
            cmd.Parameters.AddWithValue("@OBS_LLAMADA_CO", plsTo.OBS_LLAMADA_CO);
            cmd.Parameters.AddWithValue("@FECHA_ACTIVA", plsTo.FECHA_ACTIVA);
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
        public bool ExisteDAL(planillaDirectaSeguimientoTo plsTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("VERIFICA_EXISTE_PLANILLA_DIRECTA_SEGUIMIENTO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", plsTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@COD_PERSONA", plsTo.COD_PERSONA);
            cmd.Parameters.AddWithValue("@NRO_CUOTA", plsTo.NRO_CUOTA);
            cmd.Parameters.AddWithValue("@TIPO", plsTo.TIPO);
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
        public bool eliminarPlanillaDirectaSeguimientoDAL(planillaDirectaSeguimientoTo plsTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_PLANILLA_DIRECTA_SEGUIMIENTO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", plsTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@COD_PERSONA", plsTo.COD_PERSONA);
            cmd.Parameters.AddWithValue("@NRO_CUOTA", plsTo.NRO_CUOTA);
            cmd.Parameters.AddWithValue("@TIPO", plsTo.TIPO);
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
