using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class cambioPuntoCobranzaDAL
    {
        SqlConnection conn;
        public cambioPuntoCobranzaDAL()
        {
            conn = new SqlConnection(conexion.con);
        }

        public DataTable obtenerCambioPuntoCobranzaDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_CAMBIO_PUNTO_COBRANZA", conn);
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
        public DataTable obtenerCambioPuntoCobranzaxPersonaDAL(cambioPuntoCobranzaTo cpcTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_CAMBIO_PUNTO_COBRANZA_X_PERSONA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PER", cpcTo.COD_PER);
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
        public bool insertarCambioPuntoCobranzaDAL(cambioPuntoCobranzaTo cpcTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_CAMBIO_PUNTO_COBRANZA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            //SqlParameter param = new SqlParameter("@COD_CAMBIO_PTO_COB", SqlDbType.Int);
            //param.Direction = ParameterDirection.Output;
            //cmd.Parameters.Add(param);
            cmd.Parameters.AddWithValue("@COD_PER", cpcTo.COD_PER);
            cmd.Parameters.AddWithValue("@COD_PTO_COB", cpcTo.COD_PTO_COB);
            cmd.Parameters.AddWithValue("@FE_COD_PTO_COB", cpcTo.FE_COD_PTO_COB);
            cmd.Parameters.AddWithValue("@AUTORIZADO", cpcTo.AUTORIZADO);
            cmd.Parameters.AddWithValue("@OBSERVACIONES", cpcTo.OBSERVACIONES);
            cmd.Parameters.AddWithValue("@COD_USU_CREA", cpcTo.COD_USU_CREA);
            cmd.Parameters.AddWithValue("@FECHA_USU_CREA", cpcTo.FECHA_USU_CREA);
            cmd.Parameters.AddWithValue("@COD_PTO_COB_ANT", cpcTo.COD_PTO_COB_ANT);
            cmd.Parameters.AddWithValue("@COD_DESCUENTO", cpcTo.COD_DESCUENTO);
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
        public bool modificarCambioPuntoCobranzaDAL(cambioPuntoCobranzaTo cpcTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_CAMBIO_PUNTO_COBRANZA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_CAMBIO_PTO_COB", cpcTo.ID_CAMBIO_PTO_COB);
            cmd.Parameters.AddWithValue("@COD_PER", cpcTo.COD_PER);
            cmd.Parameters.AddWithValue("@COD_PTO_COB", cpcTo.COD_PTO_COB);
            cmd.Parameters.AddWithValue("@FE_COD_PTO_COB", cpcTo.FE_COD_PTO_COB);
            cmd.Parameters.AddWithValue("@AUTORIZADO", cpcTo.AUTORIZADO);
            cmd.Parameters.AddWithValue("@OBSERVACIONES", cpcTo.OBSERVACIONES);
            cmd.Parameters.AddWithValue("@COD_USU_MOD", cpcTo.COD_USU_CREA);
            cmd.Parameters.AddWithValue("@FECHA_USU_MOD", cpcTo.FECHA_USU_CREA);
            cmd.Parameters.AddWithValue("@COD_DESCUENTO", cpcTo.COD_DESCUENTO);
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
        public bool eliminarCambioPuntoCobranzaDAL(cambioPuntoCobranzaTo cpcTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_CAMBIO_PUNTO_COBRANZA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PER", cpcTo.COD_PER);
            cmd.Parameters.AddWithValue("@COD_PTO_COB", cpcTo.COD_PTO_COB);
            cmd.Parameters.AddWithValue("@FE_COD_PTO_COB", cpcTo.FE_COD_PTO_COB);
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
