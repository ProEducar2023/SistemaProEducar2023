using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class tComisonDAL
    {
        SqlConnection conn;
        public tComisonDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerTComisionDAL(tComisionTo tcomTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("", tcomTo.COD_VENDEDOR);
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
        public bool insertarTComisionDAL(tComisionTo tcomTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_TCOMISION", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TIPO_VTA", tcomTo.TIPO_VTA);
            cmd.Parameters.AddWithValue("@COD_PROGRAMA", tcomTo.COD_PROGRAMA);
            cmd.Parameters.AddWithValue("@COD_VENDEDOR", tcomTo.COD_VENDEDOR);
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", tcomTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@FE_AÑO", tcomTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", tcomTo.FE_MES);
            cmd.Parameters.AddWithValue("@FE_DOC", tcomTo.FE_DOC);
            if (tcomTo.FE_CANC == null)
                cmd.Parameters.AddWithValue("@FE_CANC", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@FE_CANC", tcomTo.FE_CANC);
            if (tcomTo.FE_APROB == null)
                cmd.Parameters.AddWithValue("@FE_APROB", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@FE_APROB", tcomTo.FE_APROB);
            cmd.Parameters.AddWithValue("@COD_PER", tcomTo.COD_PER);
            cmd.Parameters.AddWithValue("@IMPORTE", tcomTo.IMPORTE);
            cmd.Parameters.AddWithValue("@NRO_LETRA", tcomTo.NRO_LETRA);
            cmd.Parameters.AddWithValue("@COD_NIVEL", tcomTo.COD_NIVEL);
            cmd.Parameters.AddWithValue("@TIPO_OPE", tcomTo.TIPO_OPE);
            cmd.Parameters.AddWithValue("@COD_PER_SUP", tcomTo.COD_PER_SUP);
            cmd.Parameters.AddWithValue("@COD_D_H", tcomTo.COD_D_H);
            cmd.Parameters.AddWithValue("@COD_CREA", tcomTo.COD_CREA);
            cmd.Parameters.AddWithValue("@FECHA_CREA", tcomTo.FECHA_CREA);
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
        public bool modificarTComisionDAL(tComisionTo tcomTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_VENDEDOR", tcomTo.COD_VENDEDOR);
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", tcomTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@FE_DOC", tcomTo.FE_DOC);
            cmd.Parameters.AddWithValue("@FE_CANC", tcomTo.FE_CANC);
            cmd.Parameters.AddWithValue("@FE_APROB", tcomTo.FE_APROB);
            cmd.Parameters.AddWithValue("@COD_PER", tcomTo.COD_PER);
            cmd.Parameters.AddWithValue("@IMPORTE", tcomTo.IMPORTE);
            cmd.Parameters.AddWithValue("@NRO_LETRA", tcomTo.NRO_LETRA);
            cmd.Parameters.AddWithValue("@COD_NIVEL", tcomTo.COD_NIVEL);
            cmd.Parameters.AddWithValue("@TIPO_OPE", tcomTo.TIPO_OPE);
            cmd.Parameters.AddWithValue("@NRO_PLANILLA", tcomTo.NRO_PLANILLA);
            cmd.Parameters.AddWithValue("@FE_PLANILLA", tcomTo.FE_PLANILLA);
            cmd.Parameters.AddWithValue("@COD_CREA", tcomTo.COD_CREA);
            cmd.Parameters.AddWithValue("@FECHA_CREA", tcomTo.FECHA_CREA);
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
        public bool eliminarTComisionDAL(tComisionTo tcomTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_TCOMISION_POR_NRO_CONTRATO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", tcomTo.NRO_CONTRATO);
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
        public bool eliminarTComisionxLiqComisionDAL(tComisionTo tcomTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_TCOMISION", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TIPO_VTA", tcomTo.TIPO_VTA);
            cmd.Parameters.AddWithValue("@COD_PROGRAMA", tcomTo.COD_PROGRAMA);
            cmd.Parameters.AddWithValue("@COD_VENDEDOR", tcomTo.COD_VENDEDOR);
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", tcomTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@NRO_LETRA", tcomTo.NRO_LETRA);
            cmd.Parameters.AddWithValue("@COD_NIVEL", tcomTo.COD_NIVEL);
            cmd.Parameters.AddWithValue("@TIPO_OPE", tcomTo.TIPO_OPE);
            cmd.Parameters.AddWithValue("@COD_PER_SUP", tcomTo.COD_PER_SUP);

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
