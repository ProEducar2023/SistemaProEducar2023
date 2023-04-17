using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class tLiquidacionDAL
    {
        SqlConnection conn;
        public tLiquidacionDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerTLiquidacionDAL()
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
        public bool insertarTLiquidacionDAL(tLiquidacionTo tliqTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_T_LIQUIDACION", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TIPO_VTA", tliqTo.TIPO_VTA);
            cmd.Parameters.AddWithValue("@COD_PROGRAMA", tliqTo.COD_PROGRAMA);
            cmd.Parameters.AddWithValue("@COD_COMISIONANTE", tliqTo.COD_COMISIONANTE);
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", tliqTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@NRO_LETRA", tliqTo.NRO_LETRA);
            cmd.Parameters.AddWithValue("@COD_NIVEL", tliqTo.COD_NIVEL);
            cmd.Parameters.AddWithValue("@FE_DOC", tliqTo.FE_DOC);
            if (tliqTo.FE_PAGO == null)
                cmd.Parameters.AddWithValue("@FE_PAGO", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@FE_PAGO", tliqTo.FE_PAGO);
            cmd.Parameters.AddWithValue("@IMPORTE", tliqTo.IMPORTE);
            cmd.Parameters.AddWithValue("@COD_VENDEDOR", tliqTo.COD_VENDEDOR);
            cmd.Parameters.AddWithValue("@TIPO_OPE", tliqTo.TIPO_OPE);
            cmd.Parameters.AddWithValue("@COD_D_H", tliqTo.COD_D_H);
            cmd.Parameters.AddWithValue("@COD_CREA", tliqTo.COD_CREA);
            cmd.Parameters.AddWithValue("@FECHA_CREA", tliqTo.FECHA_CREA);
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
        public bool eliminarTLiquidacionDAL(tLiquidacionTo tliqTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_TLIQUIDACION", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TIPO_VTA", tliqTo.TIPO_VTA);
            cmd.Parameters.AddWithValue("@COD_PROGRAMA", tliqTo.COD_PROGRAMA);
            //cmd.Parameters.AddWithValue("@COD_COMISIONANTE", tliqTo.COD_COMISIONANTE);
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", tliqTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@NRO_LETRA", tliqTo.NRO_LETRA);
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
