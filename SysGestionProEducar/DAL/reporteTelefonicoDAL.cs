using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class reporteTelefonicoDAL
    {
        SqlConnection conn;
        public reporteTelefonicoDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerReporteTelefonicoMensualDAL(reporteTelefonicoTo rtTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_REPORTE_TELEFONICO_MENSUAL", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FE_MES", rtTo.FE_MES);
            cmd.Parameters.AddWithValue("@FE_AÑO", rtTo.FE_AÑO);

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
        public DataTable obtenerReporteTelefonicoDAL(reporteTelefonicoTo rtTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_REPORTE_TELEFONICO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FE_MES", rtTo.FE_MES);
            cmd.Parameters.AddWithValue("@FE_AÑO", rtTo.FE_AÑO);
            //cmd.Parameters.AddWithValue("@COD_PER", rtTo.COD_PER);//NO SE USA ESTE METODO

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
        public bool insertarReporteTelefonicoDAL(reporteTelefonicoTo rtTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_REPORTE_TELEFONICO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SUCURSAL", rtTo.SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_PROGRAMA", rtTo.COD_PROGRAMA);
            cmd.Parameters.AddWithValue("@TIPO_PLANILLA", rtTo.TIPO_PLANILLA);
            cmd.Parameters.AddWithValue("@FE_MES", rtTo.FE_MES);
            cmd.Parameters.AddWithValue("@FE_AÑO", rtTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@COD_SEMANA", rtTo.COD_SEMANA);
            cmd.Parameters.AddWithValue("@NOM_SEMANA", rtTo.NOM_SEMANA);
            cmd.Parameters.AddWithValue("@FECHA", rtTo.FECHA);
            cmd.Parameters.AddWithValue("@CANTIDAD_TOT", rtTo.CANTIDAD_TOT);
            cmd.Parameters.AddWithValue("@MONTO_TOT", rtTo.MONTO_TOTAL);
            cmd.Parameters.AddWithValue("@FECHA_CREA", rtTo.FECHA_CREA);
            cmd.Parameters.AddWithValue("@COD_CREA", rtTo.COD_CREA);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception e)
            {
                flag = false; ;
                errMensaje = e.Message;
            }
            finally
            {
                conn.Close();
            }
            return flag;
        }
        public bool modificarReporteTelefonicoDAL(reporteTelefonicoTo rtTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_REPORTE_TELEFONICO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SUCURSAL", rtTo.SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_PROGRAMA", rtTo.COD_PROGRAMA);
            cmd.Parameters.AddWithValue("@TIPO_PLANILLA", rtTo.TIPO_PLANILLA);
            cmd.Parameters.AddWithValue("@FE_MES", rtTo.FE_MES);
            cmd.Parameters.AddWithValue("@FE_AÑO", rtTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@COD_SEMANA", rtTo.COD_SEMANA);
            cmd.Parameters.AddWithValue("@NOM_SEMANA", rtTo.NOM_SEMANA);
            cmd.Parameters.AddWithValue("@FECHA", rtTo.FECHA);
            cmd.Parameters.AddWithValue("@CANTIDAD_TOT", rtTo.CANTIDAD_TOT);
            cmd.Parameters.AddWithValue("@MONTO_TOT", rtTo.MONTO_TOTAL);
            cmd.Parameters.AddWithValue("@FECHA_MOD", rtTo.FECHA_MOD);
            cmd.Parameters.AddWithValue("@COD_MOD", rtTo.COD_MOD);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception e)
            {
                flag = false; ;
                errMensaje = e.Message;
            }
            finally
            {
                conn.Close();
            }
            return flag;
        }
        public bool eliminarReporteTelefonicoDAL(reporteTelefonicoTo rtTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINA_REPORTE_TELEFONICO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SUCURSAL", rtTo.SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_PROGRAMA", rtTo.COD_PROGRAMA);
            cmd.Parameters.AddWithValue("@TIPO_PLANILLA", rtTo.TIPO_PLANILLA);
            cmd.Parameters.AddWithValue("@FE_MES", rtTo.FE_MES);
            cmd.Parameters.AddWithValue("@FE_AÑO", rtTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@COD_SEMANA", rtTo.COD_SEMANA);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception e)
            {
                flag = false; ;
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
