using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;


namespace DAL
{
    public class contratoComisionDAL
    {
        SqlConnection conn;
        public contratoComisionDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerContratoComisionDAL(contratoComisionTo ccnTo)
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
        public bool insertarContratoComisionDAL(contratoComisionTo ccnTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_CONTRATO_COMISION", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PER", ccnTo.COD_PER);
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", ccnTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@MONTO", ccnTo.MONTO);
            cmd.Parameters.AddWithValue("@PORCENTAJE", ccnTo.PORCENTAJE);
            cmd.Parameters.AddWithValue("@STATUS_IMPORTE", ccnTo.STATUS_IMPORTE);
            cmd.Parameters.AddWithValue("@CUOTA", ccnTo.CUOTA);
            cmd.Parameters.AddWithValue("@COD_CREAR", ccnTo.COD_CREAR);
            cmd.Parameters.AddWithValue("@FECHA_CREA", ccnTo.FECHA_CREA);
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
