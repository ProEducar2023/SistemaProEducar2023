using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class eq_vta_nivel_progDAL
    {
        SqlConnection conn;
        public eq_vta_nivel_progDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerEquipoDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_EQ_VTA_NIVEL_PROG", conn);
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
        public DataTable obtenerEquipoCobDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_EQ_COB_NIVEL_PROG", conn);
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
        public bool insertarEquipoDAL(eq_vta_nivel_progTo eqvTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_EQ_VTA_NIVEL_PROG", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_EQVTA", eqvTo.COD_EQVTA);
            cmd.Parameters.AddWithValue("@TIP_DOC", eqvTo.TIP_DOC);
            cmd.Parameters.AddWithValue("@NRO_DOC", eqvTo.NRO_DOC);
            cmd.Parameters.AddWithValue("@DESC_EQVTA", eqvTo.DESC_EQVTA);
            cmd.Parameters.AddWithValue("@NOMBRE", eqvTo.NOMBRE);
            cmd.Parameters.AddWithValue("@PATERNO", eqvTo.PATERNO);
            cmd.Parameters.AddWithValue("@MATERNO", eqvTo.MATERNO);
            cmd.Parameters.AddWithValue("@MAIL", eqvTo.MAIL);
            cmd.Parameters.AddWithValue("@ACTIVO", eqvTo.ACTIVO);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception e)
            {
                errMensaje = e.Message;
            }
            finally
            {
                conn.Close();
            }
            return flag;
        }
        public bool modificarEquipoDAL(eq_vta_nivel_progTo eqvTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_EQ_VTA_NIVEL_PROG", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_EQVTA", eqvTo.COD_EQVTA);
            cmd.Parameters.AddWithValue("@TIP_DOC", eqvTo.TIP_DOC);
            cmd.Parameters.AddWithValue("@NRO_DOC", eqvTo.NRO_DOC);
            cmd.Parameters.AddWithValue("@DESC_EQVTA", eqvTo.DESC_EQVTA);
            cmd.Parameters.AddWithValue("@NOMBRE", eqvTo.NOMBRE);
            cmd.Parameters.AddWithValue("@PATERNO", eqvTo.PATERNO);
            cmd.Parameters.AddWithValue("@MATERNO", eqvTo.MATERNO);
            cmd.Parameters.AddWithValue("@MAIL", eqvTo.MAIL);
            cmd.Parameters.AddWithValue("@ACTIVO", eqvTo.ACTIVO);
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
        public bool eliminarEquipoDAL(eq_vta_nivel_progTo eqvTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_EQ_VTA_NIVEL_PROG", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_EQVTA", eqvTo.COD_EQVTA);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception e)
            {
                errMensaje = e.Message;
            }
            finally
            {
                conn.Close();
            }
            return flag;
        }
        public bool insertarEquipoCobranzaDAL(eq_vta_nivel_progTo eqvTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_EQ_COB_NIVEL_PROG", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_EQCOB", eqvTo.COD_EQVTA);
            cmd.Parameters.AddWithValue("@TIP_DOC", eqvTo.TIP_DOC);
            cmd.Parameters.AddWithValue("@NRO_DOC", eqvTo.NRO_DOC);
            cmd.Parameters.AddWithValue("@DESC_EQVTA", eqvTo.DESC_EQVTA);
            cmd.Parameters.AddWithValue("@NOMBRE", eqvTo.NOMBRE);
            cmd.Parameters.AddWithValue("@PATERNO", eqvTo.PATERNO);
            cmd.Parameters.AddWithValue("@MATERNO", eqvTo.MATERNO);
            cmd.Parameters.AddWithValue("@MAIL", eqvTo.MAIL);
            cmd.Parameters.AddWithValue("@ACTIVO", eqvTo.ACTIVO);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception e)
            {
                errMensaje = e.Message;
            }
            finally
            {
                conn.Close();
            }
            return flag;
        }
        public bool modificarEquipoCobranzaDAL(eq_vta_nivel_progTo eqvTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_EQ_VTA_NIVEL_PROG_COBRANZA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_EQCOB", eqvTo.COD_EQVTA);
            cmd.Parameters.AddWithValue("@TIP_DOC", eqvTo.TIP_DOC);
            cmd.Parameters.AddWithValue("@NRO_DOC", eqvTo.NRO_DOC);
            cmd.Parameters.AddWithValue("@DESC_EQVTA", eqvTo.DESC_EQVTA);
            cmd.Parameters.AddWithValue("@NOMBRE", eqvTo.NOMBRE);
            cmd.Parameters.AddWithValue("@PATERNO", eqvTo.PATERNO);
            cmd.Parameters.AddWithValue("@MATERNO", eqvTo.MATERNO);
            cmd.Parameters.AddWithValue("@MAIL", eqvTo.MAIL);
            cmd.Parameters.AddWithValue("@ACTIVO", eqvTo.ACTIVO);
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
        public bool eliminaEqCobranzaNivProgDAL(eq_vta_nivel_progTo eqvTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_EQ_COB_NIVEL_PROG", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_EQCOB", eqvTo.COD_EQVTA);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception e)
            {
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
