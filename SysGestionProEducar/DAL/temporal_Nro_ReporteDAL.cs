using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class temporal_Nro_ReporteDAL
    {
        SqlConnection conn;
        public temporal_Nro_ReporteDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtener_Temporal_Nro_ReporteDAL(temporal_Nro_ReporteTo tnrTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_TEMPORAL_NRO_REPORTE", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PER_ELAB", tnrTo.cod_per_elab);

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
        public DataTable obtener_Temporal_Nro_Reporte_x_DigitadorDAL(temporal_Nro_ReporteTo tnrTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_TEMPORAL_NRO_REPORTE_X_DIGITADOR", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PER_ELAB", tnrTo.cod_per_elab);

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
        public bool insertar_Temporal_Nro_ReporteDAL(temporal_Nro_ReporteTo tnrTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_TEMPORAL_NRO_REPORTE", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_PRESUPUESTO", tnrTo.nro_contrato);
            cmd.Parameters.AddWithValue("@COD_PER_ELAB", tnrTo.cod_per_elab);

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
        public bool eliminar_Temporal_Nro_ReporteDAL(temporal_Nro_ReporteTo tnrTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_TEMPORAL_NRO_REPORTE", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PER_ELAB", tnrTo.cod_per_elab);

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
        public bool verifica_existencia_contratos_sin_nro_reporte_x_cod_digitadorDAL(temporal_Nro_ReporteTo tnrTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("VERIFICA_EXISTENCIA_CONTRATOS_SIN_NRO_REPORTE_X_COD_DIGITADOR", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PER_ELAB", tnrTo.cod_per_elab);

            try
            {
                conn.Open();
                flag = Convert.ToBoolean(cmd.ExecuteScalar());

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
    }
}
