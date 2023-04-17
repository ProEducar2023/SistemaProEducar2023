using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class periodoDAL
    {
        SqlConnection conn;
        public periodoDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerPeriodoDAL(periodoTo prdTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_PERIODO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_MODULO", prdTo.COD_MODULO);
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
        public bool insertarPeriodoDAL(periodoTo prdTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_PERIODO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_MODULO", prdTo.COD_MODULO);
            cmd.Parameters.AddWithValue("@AÑO", prdTo.AÑO);
            cmd.Parameters.AddWithValue("@MES", prdTo.MES);
            cmd.Parameters.AddWithValue("@FECHA_INICIO", prdTo.FECHA_INICIO);
            cmd.Parameters.AddWithValue("@FECHA_CIERRE", prdTo.FECHA_CIERRE);
            //cmd.Parameters.AddWithValue("@STATUS_ACTIVO", prdTo.STATUS_ACTIVO);
            //cmd.Parameters.AddWithValue("@STATUS_CIERRE", prdTo.STATUS_CIERRE);
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
        public bool modificarPeriodoDAL(periodoTo prdTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_PERIODO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_MODULO", prdTo.COD_MODULO);
            cmd.Parameters.AddWithValue("@AÑO", prdTo.AÑO);
            cmd.Parameters.AddWithValue("@MES", prdTo.MES);
            cmd.Parameters.AddWithValue("@FECHA_INICIO", prdTo.FECHA_INICIO);
            cmd.Parameters.AddWithValue("@FECHA_CIERRE", prdTo.FECHA_CIERRE);
            //cmd.Parameters.AddWithValue("@STATUS_ACTIVO", prdTo.STATUS_ACTIVO);
            //cmd.Parameters.AddWithValue("@STATUS_CIERRE", prdTo.STATUS_CIERRE);
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
        public bool eliminarPeriodoDAL(periodoTo prdTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_PERIODO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_MODULO", prdTo.COD_MODULO);
            cmd.Parameters.AddWithValue("@AÑO", prdTo.AÑO);
            cmd.Parameters.AddWithValue("@MES", prdTo.MES);
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
        public DataTable hallarActivoDAL(periodoTo prdTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("HALLAR_ACTIVO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_MODULO", prdTo.COD_MODULO);
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
        public bool activarPeriodoDAL(periodoTo prdTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ACTIVAR_PERIODO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_MODULO", prdTo.COD_MODULO);
            cmd.Parameters.AddWithValue("@AÑO", prdTo.AÑO);
            cmd.Parameters.AddWithValue("@MES", prdTo.MES);
            //cmd.Parameters.AddWithValue("@STATUS_ACTIVO", prdTo.STATUS_ACTIVO);
            //cmd.Parameters.AddWithValue("@STATUS_CIERRE", prdTo.STATUS_CIERRE);
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
        public bool cerrarPeriodoDAL(periodoTo prdTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("CERRAR_PERIODO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_MODULO", prdTo.COD_MODULO);
            cmd.Parameters.AddWithValue("@FE_AÑO", prdTo.AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", prdTo.MES);
            cmd.Parameters.AddWithValue("@TIPO_MODULO", prdTo.TIPO_MODULO);
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
        public bool regresarCerrarPeriodoDAL(periodoTo prdTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("REGRESAR_CERRAR_PERIODO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_MODULO", prdTo.COD_MODULO);
            cmd.Parameters.AddWithValue("@FE_AÑO", prdTo.AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", prdTo.MES);
            cmd.Parameters.AddWithValue("@TIPO_MODULO", prdTo.TIPO_MODULO);
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

        public bool verificaFechaParaCierreAñoDAL(periodoTo prdTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("VERIFICAR_FECHA_CIERRE_AÑO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_MODULO", prdTo.COD_MODULO);
            try
            {
                conn.Open();
                flag = Convert.ToBoolean(cmd.ExecuteScalar());
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
        public DataTable MOSTRAR_ACTIVO_DAL(string COD_MODULO)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("HALLAR_ACTIVO", conn);
            cmd.Parameters.AddWithValue("@COD_MODULO", COD_MODULO);
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
        public bool VERIFICAR_CIERRE_PERIODO_DAL(periodoTo perTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("VERIFICAR_CIERRE_PERIODO_AES", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_MODULO", perTo.COD_MODULO);
            cmd.Parameters.AddWithValue("@AÑO", perTo.AÑO);
            cmd.Parameters.AddWithValue("@MES", perTo.MES);
            try
            {
                conn.Open();
                flag = Convert.ToBoolean(cmd.ExecuteScalar());
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
        public bool cerrarCierreAñoDAL(periodoTo perTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("CIERRE_AÑO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FE_AÑO", perTo.AÑO);
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
        public bool regresarCierreAñoDAL(periodoTo perTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("REGRESAR_CIERRE_AÑO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FE_AÑO", perTo.AÑO);
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
        public DataTable obtenerAñoPeriodoDAL(periodoTo perTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("CARGAR_AÑO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_MODULO", perTo.COD_MODULO);
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
        public DataTable obtenerPeriodoPllasNoTransferidasDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_PERIODO_PLLAS_NO_TRANSFERIDAS", conn);
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
    }
}
