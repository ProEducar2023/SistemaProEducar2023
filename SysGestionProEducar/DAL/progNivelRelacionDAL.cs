using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class progNivelRelacionDAL
    {
        SqlConnection conn;
        public progNivelRelacionDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerPrograNivelRelacionDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_PROG_NIVEL_RELACION", conn);
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
        public DataTable obtenerPrograNivelRelacionCobSupDAL(string codsup)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_RELACION_SUP_COB", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUPERIOR", codsup);
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
        public bool insertarProgNivelRelacionDAL(progNivelRelacionTo prnirTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_PROG_NIVEL_RELACION", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PROG", prnirTo.COD_PROG);
            cmd.Parameters.AddWithValue("@COD_VEND", prnirTo.COD_VEND);
            cmd.Parameters.AddWithValue("@COD_SUPERIOR", prnirTo.COD_SUPERIOR);
            cmd.Parameters.AddWithValue("@COD_NIVEL", prnirTo.COD_NIVEL);
            cmd.Parameters.AddWithValue("@COD_ALM", prnirTo.COD_ALM);
            //cmd.Parameters.AddWithValue("@COD_ENC_NUM_CONTRATO", prnirTo.COD_ENC_NUM_CONTRATO);
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
        public bool insertarProgNivelRelacionCobranzaDAL(progNivelRelacionTo prnirTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_PROG_NIVEL_RELACION_COBRANZA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PROG", prnirTo.COD_PROG);
            cmd.Parameters.AddWithValue("@COD_COB", prnirTo.COD_VEND);
            cmd.Parameters.AddWithValue("@COD_SUPERIOR", prnirTo.COD_SUPERIOR);
            cmd.Parameters.AddWithValue("@COD_NIVEL", prnirTo.COD_NIVEL);
            //cmd.Parameters.AddWithValue("@COD_ALM", prnirTo.COD_ALM);
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
        public DataTable obtenerRelacionVendSupDAL(progNivelRelacionTo prnirTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_RELACION_VEND_SUP", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PROG", prnirTo.COD_PROG);
            cmd.Parameters.AddWithValue("@COD_VEND", prnirTo.COD_VEND);
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
        public bool eliminarProgNivelRelacionDAL(progNivelRelacionTo prnirTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_PROG_NIVEL_RELACION", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PROG", prnirTo.COD_PROG);
            cmd.Parameters.AddWithValue("@COD_VEND", prnirTo.COD_VEND);
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
        public bool eliminarProgNivelRelacion2DAL(progNivelRelacionTo prnirTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_PROG_NIVEL_RELACION2", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_VEND", prnirTo.COD_VEND);
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
        public bool eliminarProgNivelRelacionCobranzaDAL(progNivelRelacionTo prnirTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_PROG_NIVEL_RELACION_COBRANZA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PROG", prnirTo.COD_PROG);
            //cmd.Parameters.AddWithValue("@COD_COB", prnirTo.COD_VEND);
            cmd.Parameters.AddWithValue("@COD_SUPERIOR", prnirTo.COD_SUPERIOR);
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
        public bool eliminarProgNivelCobranzaDAL(progNivelRelacionTo prnirTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_PROG_NIVEL_COBRANZA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PER", prnirTo.COD_VEND);
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
        public DataTable obtenerNivelesSuperioresVendedorDAL(progNivelRelacionTo prnirTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_RELACION_VEND_SUP_PRECONTRATO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PROG", prnirTo.COD_PROG);
            cmd.Parameters.AddWithValue("@COD_VEND", prnirTo.COD_VEND);
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
    }
}
