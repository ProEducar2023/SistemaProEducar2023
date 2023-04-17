using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class progNivelDAL
    {
        SqlConnection conn;
        public progNivelDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerProgramaNivelDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_PROGRAMA_NIVEL", conn);
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
        public DataTable obtenerProgramaNivelporCodigoDAL(progNivelTo prniTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_PROGRAMA_NIVEL_POR_COD", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PER", prniTo.COD_PER);
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
        public DataTable obtenerProgramaNivelporCodigoCobranzaDAL(progNivelTo prniTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_PROGRAMA_NIVEL_POR_COD_COBRANZA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PER", prniTo.COD_PER);
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
        public bool insertarProgramaNivelDAL(progNivelTo prniTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_PROGRAMA_NIVEL", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PER", prniTo.COD_PER);
            cmd.Parameters.AddWithValue("@COD_PROGRAMA", prniTo.COD_PROGRAMA);
            cmd.Parameters.AddWithValue("@DESC_PROGRAMA", prniTo.DESC_PROGRAMA);
            cmd.Parameters.AddWithValue("@COD_NIVEL", prniTo.COD_NIVEL);
            cmd.Parameters.AddWithValue("@DESC_NIVEL", prniTo.DESC_NIVEL);
            cmd.Parameters.AddWithValue("@ACTIVIDAD", prniTo.ACTIVIDAD);
            cmd.Parameters.AddWithValue("@TIPO_PLANILLA", prniTo.TIPO_PLANILLA);
            cmd.Parameters.AddWithValue("@NUMERACION", prniTo.NUMERACION);
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
        public bool modificarProgramaNivelDAL(progNivelTo prniTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_PROGRAMA_NIVEL", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PER", prniTo.COD_PER);
            cmd.Parameters.AddWithValue("@COD_PROGRAMA", prniTo.COD_PROGRAMA);
            cmd.Parameters.AddWithValue("@DESC_PROGRAMA", prniTo.DESC_PROGRAMA);
            cmd.Parameters.AddWithValue("@COD_NIVEL", prniTo.COD_NIVEL);
            cmd.Parameters.AddWithValue("@DESC_NIVEL", prniTo.DESC_NIVEL);
            cmd.Parameters.AddWithValue("@ACTIVIDAD", prniTo.ACTIVIDAD);
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
        public bool eliminarProgramaNivelDAL(progNivelTo prniTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_PROGRAMA_NIVEL", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PER", prniTo.COD_PER);
            cmd.Parameters.AddWithValue("@COD_PROGRAMA", prniTo.COD_PROGRAMA);
            cmd.Parameters.AddWithValue("@COD_NIVEL", prniTo.COD_NIVEL);
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
        public bool eliminarProgramaNivelporCodPerDAL(progNivelTo prniTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_PROGRAMA_NIVEL_POR_CODPER", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PER", prniTo.COD_PER);
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
        public DataTable obtenerPersonalparaCrearEqVentaDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_PERSONAL_PARA_CREAR_EQVENTAS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@COD_PER",COD_PER);
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
        public DataTable obtenerPersonalparaCrearEqCobranzaDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_PERSONAL_PARA_CREAR_EQCOBRANZA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@COD_PER",COD_PER);
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
        public DataTable obtenerVendedoresparaCrearEqVentasDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_VENDEDORES_PARA_CREAR_EQVENTAS", conn);
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
        public DataTable obtenerDirectoresparaCrearEqVentasDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_DIRECTORES_PARA_CREAR_EQVENTAS", conn);
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
        public DataTable obtenerPersonasParaConsultaMetasDAL(progNivelTo prnTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_PERSONAS_PARA_CONSULTA_METAS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_NIVEL", prnTo.COD_NIVEL);
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
        public DataTable obtenerPersonalparaRelacionarDAL(string codpro)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_PERSONAL_PARA_RELACIONAR", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PROGRAMA", codpro);
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
        public bool insertarProgramaNivelCobranzaDAL(progNivelTo prniTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_PROGRAMA_NIVEL_COBRANZA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PER", prniTo.COD_PER);
            cmd.Parameters.AddWithValue("@COD_PROGRAMA", prniTo.COD_PROGRAMA);
            cmd.Parameters.AddWithValue("@DESC_PROGRAMA", prniTo.DESC_PROGRAMA);
            cmd.Parameters.AddWithValue("@COD_NIVEL", prniTo.COD_NIVEL);
            cmd.Parameters.AddWithValue("@DESC_NIVEL", prniTo.DESC_NIVEL);
            cmd.Parameters.AddWithValue("@TIPO_PLANILLA", prniTo.TIPO_PLANILLA);
            cmd.Parameters.AddWithValue("@ACTIVIDAD", prniTo.ACTIVIDAD);
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
        public bool eliminarProgramaNivelporCodPerCobranzaDAL(progNivelTo prniTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_PROGRAMA_NIVEL_POR_CODPER_COBRANZA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PER", prniTo.COD_PER);
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
        public DataTable obtenerSectoristasparaCrearEqCobradoresDAL(string codni)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_EQ_COBRADOR_POR_COD_NIVEL", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_NIVEL", codni);
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
        public DataTable obtenerPersonalparaRelacionarCobradoresDAL(string codn)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("OBTENER_PERSONAL_PARA_RELACIONAR_COBRADORES", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_NIVEL", codn);
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
        public DataTable obtenerCobradoresxSectoristaDAL(progNivelTo prniTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_COBRADORES_X_SECTORISTA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            if (prniTo.COD_PER == null)
                cmd.Parameters.AddWithValue("@COD_SECTORISTA", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@COD_SECTORISTA", prniTo.COD_PER);
            cmd.Parameters.AddWithValue("@COD_NIVEL", prniTo.COD_NIVEL);
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
