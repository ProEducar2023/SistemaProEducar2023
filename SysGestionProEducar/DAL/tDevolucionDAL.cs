using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class tDevolucionDAL
    {
        SqlConnection conn;
        public tDevolucionDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerTDevolucionDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("", conn);
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
        public bool insertarTDevolucionDAL(tDevolucionTo tdevTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_T_DEVOLUCION", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TIPO_VTA", tdevTo.TIPO_VTA);
            cmd.Parameters.AddWithValue("@COD_PROGRAMA", tdevTo.COD_PROGRAMA);
            cmd.Parameters.AddWithValue("@COD_VENDEDOR", tdevTo.COD_VENDEDOR);
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", tdevTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@FE_AÑO", tdevTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", tdevTo.FE_MES);
            cmd.Parameters.AddWithValue("@FE_DOC", tdevTo.FE_DOC);
            if (tdevTo.FE_CANC == null)
                cmd.Parameters.AddWithValue("@FE_CANC", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@FE_CANC", tdevTo.FE_CANC);
            cmd.Parameters.AddWithValue("@COD_PER", tdevTo.COD_PER);
            cmd.Parameters.AddWithValue("@IMPORTE", tdevTo.IMPORTE);
            cmd.Parameters.AddWithValue("@NRO_LETRA", tdevTo.NRO_LETRA);
            cmd.Parameters.AddWithValue("@COD_NIVEL", tdevTo.COD_NIVEL);
            cmd.Parameters.AddWithValue("@TIPO_OPE", tdevTo.TIPO_OPE);
            cmd.Parameters.AddWithValue("@COD_PER_SUP", tdevTo.COD_PER_SUP);
            cmd.Parameters.AddWithValue("@COD_D_H", tdevTo.COD_D_H);
            cmd.Parameters.AddWithValue("@COD_CREA", tdevTo.COD_CREA);
            cmd.Parameters.AddWithValue("@FECHA_CREA", tdevTo.FECHA_CREA);
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
        public bool eliminarTDevolucionDAL(tDevolucionTo tdevTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_TDEVOLUCION_POR_NRO_CONTRATO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", tdevTo.NRO_CONTRATO);
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
