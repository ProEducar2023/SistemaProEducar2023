using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class cuentaBancariaDAL
    {
        SqlConnection conn;
        public cuentaBancariaDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerCuentasBancariasDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_CUENTAS_BANCARIAS", conn);
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
        public bool insertarCuentasBancariasDAL(cuentaBancariaTo cbcTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_CUENTAS_BANCARIAS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_CUENTA", cbcTo.COD_CUENTA);
            cmd.Parameters.AddWithValue("@COD_BANCO", cbcTo.COD_BANCO);
            cmd.Parameters.AddWithValue("@TIPO_CTA", cbcTo.TIPO_CTA);
            cmd.Parameters.AddWithValue("@COD_MONEDA", cbcTo.COD_MONEDA);
            cmd.Parameters.AddWithValue("@NRO_CTA", cbcTo.NRO_CTA);
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", cbcTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@CTA_CONTABLE", cbcTo.CTA_CONTABLE);
            cmd.Parameters.AddWithValue("@CTA_PAGAR", cbcTo.CTA_PAGAR);
            cmd.Parameters.AddWithValue("@CTA_AUX", cbcTo.CTA_AUX);
            cmd.Parameters.AddWithValue("@CTA_COM", cbcTo.CTA_COM);
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
        public bool modificarCuentasBancariasDAL(cuentaBancariaTo cbcTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_CUENTA", cbcTo.COD_CUENTA);
            cmd.Parameters.AddWithValue("@COD_BANCO", cbcTo.COD_BANCO);
            cmd.Parameters.AddWithValue("@TIPO_CTA", cbcTo.TIPO_CTA);
            cmd.Parameters.AddWithValue("@COD_MONEDA", cbcTo.COD_MONEDA);
            cmd.Parameters.AddWithValue("@NRO_CTA", cbcTo.NRO_CTA);
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", cbcTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@CTA_CONTABLE", cbcTo.CTA_CONTABLE);
            cmd.Parameters.AddWithValue("@CTA_PAGAR", cbcTo.CTA_PAGAR);
            cmd.Parameters.AddWithValue("@CTA_AUX", cbcTo.CTA_AUX);
            cmd.Parameters.AddWithValue("@CTA_COM", cbcTo.CTA_COM);
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
        public bool eliminarCuentasBancariasDAL(cuentaBancariaTo cbcTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_CUENTA", cbcTo.COD_CUENTA);
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
