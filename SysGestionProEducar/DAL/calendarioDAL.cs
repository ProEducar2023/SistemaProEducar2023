using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class calendarioDAL
    {
        SqlConnection conn;
        public calendarioDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerCalendarioDAL(calendarioTo calTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MUESTRA_CALENDARIO", conn);
            cmd.Parameters.AddWithValue("TIPO", calTo.TIPO);
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
        public bool insertarCalendarioDAL(calendarioTo calTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_CALENDARIO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NuAño", calTo.NuAño);
            cmd.Parameters.AddWithValue("@NuMes", calTo.NuMes);
            cmd.Parameters.AddWithValue("@NuDia", calTo.NuDia);
            cmd.Parameters.AddWithValue("@FlFeriado", calTo.FlFeriado);
            cmd.Parameters.AddWithValue("@Tipo", calTo.TIPO);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception)
            {
                flag = false;
            }
            finally
            {
                conn.Close();
            }
            return flag;
        }
        public bool modificarCalendarioDAL(calendarioTo calTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_CALENDARIO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NuAño", calTo.NuAño);
            cmd.Parameters.AddWithValue("@NuMes", calTo.NuMes);
            cmd.Parameters.AddWithValue("@NuDia", calTo.NuDia);
            cmd.Parameters.AddWithValue("@FlFeriado", calTo.FlFeriado);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception)
            {
                flag = false;
            }
            finally
            {
                conn.Close();
            }
            return flag;
        }
        public bool eliminarCalendarioDAL(calendarioTo calTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_CALENDARIO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NuAño", calTo.NuAño);
            cmd.Parameters.AddWithValue("@NuMes", calTo.NuMes);
            cmd.Parameters.AddWithValue("@Tipo", calTo.TIPO);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception)
            {
                flag = false;
            }
            finally
            {
                conn.Close();
            }
            return flag;
        }
        public DataTable obtenerCalendarioDiasDAL(calendarioTo calTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MUESTRA_CALENDARIO_POR_MES", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NuAño", calTo.NuAño);
            cmd.Parameters.AddWithValue("@NuMes", calTo.NuMes);
            cmd.Parameters.AddWithValue("@Tipo", calTo.TIPO);
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
        public DateTime? obtenerFechaActivaDAL(calendarioTo calTo)
        {
            DateTime? dtp = null;
            SqlCommand cmd = new SqlCommand("MOSTRAR_FECHA_ACTIVA", conn);
            cmd.Parameters.AddWithValue("@TIPO", calTo.TIPO);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                dtp = cmd.ExecuteScalar() == null ? DateTime.Now : Convert.ToDateTime(cmd.ExecuteScalar());
            }
            catch (Exception)
            {
                dtp = null;
            }
            finally
            {
                conn.Close();
            }
            return dtp;
        }
        public bool modificarFechaActivaDAL(calendarioTo calTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_FECHA_ACTIVA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FECHA_ACTIVA", calTo.FECHA_ACTIVA);
            cmd.Parameters.AddWithValue("@COD_MOD", calTo.COD_MOD);
            cmd.Parameters.AddWithValue("@FECHA_MOD", calTo.FECHA_MOD);
            cmd.Parameters.AddWithValue("@TIPO", calTo.TIPO);
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
        public bool caeFeriadoDAL(calendarioTo calTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("VERIFICAR_FECHA_ACTIVA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Fecha", calTo.FECHA_ACTIVA.Date);
            cmd.Parameters.AddWithValue("@Tipo", calTo.TIPO);
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
    }
}
