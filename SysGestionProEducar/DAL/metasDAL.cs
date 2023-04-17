using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class metasDAL
    {
        SqlConnection conn;
        public metasDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerPreventasMetasMensualDAL(metasTo mtTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_PREVENTAS_METAS_MENSUAL", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FE_MES", mtTo.FE_MES);
            cmd.Parameters.AddWithValue("@FE_AÑO", mtTo.FE_AÑO);
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
        public bool insertarMetasDAL(metasTo mtTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_PREVENTAS_METAS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SUCURSAL", mtTo.SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_PROGRMA", mtTo.COD_PROGRAMA);
            cmd.Parameters.AddWithValue("@TIPO_PLANILLA", mtTo.TIPO_PLANILLA);
            cmd.Parameters.AddWithValue("@FE_MES", mtTo.FE_MES);
            cmd.Parameters.AddWithValue("@FE_AÑO", mtTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@COD_PER", mtTo.COD_PER);
            cmd.Parameters.AddWithValue("@NOM_PER", mtTo.NOM_PER);
            cmd.Parameters.AddWithValue("@FECHA", mtTo.FECHA);
            cmd.Parameters.AddWithValue("@CANTIDAD", mtTo.CANTIDAD);
            cmd.Parameters.AddWithValue("@MONTO", mtTo.MONTO);
            cmd.Parameters.AddWithValue("@FECHA_CREA", mtTo.FECHA_CREA);
            cmd.Parameters.AddWithValue("@COD_CREA", mtTo.COD_CREA);
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
        public bool modificarMetasDAL(metasTo mtTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_PREVENTA_METAS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SUCURSAL", mtTo.SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_PROGRMA", mtTo.COD_PROGRAMA);
            cmd.Parameters.AddWithValue("@TIPO_PLANILLA", mtTo.TIPO_PLANILLA);
            cmd.Parameters.AddWithValue("@FE_MES", mtTo.FE_MES);
            cmd.Parameters.AddWithValue("@FE_AÑO", mtTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@COD_PER", mtTo.COD_PER);
            cmd.Parameters.AddWithValue("@NOM_PER", mtTo.NOM_PER);
            cmd.Parameters.AddWithValue("@FECHA", mtTo.FECHA);
            cmd.Parameters.AddWithValue("@CANTIDAD", mtTo.CANTIDAD);
            cmd.Parameters.AddWithValue("@MONTO", mtTo.MONTO);
            cmd.Parameters.AddWithValue("@FECHA_MOD", mtTo.FECHA_MOD);
            cmd.Parameters.AddWithValue("@COD_MOD", mtTo.COD_MOD);
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
        public bool eliminarMetasDAL(metasTo mtTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_PREVENTA_METAS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SUCURSAL", mtTo.SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_PROGRMA", mtTo.COD_PROGRAMA);
            cmd.Parameters.AddWithValue("@TIPO_PLANILLA", mtTo.TIPO_PLANILLA);
            cmd.Parameters.AddWithValue("@FE_MES", mtTo.FE_MES);
            cmd.Parameters.AddWithValue("@FE_AÑO", mtTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@COD_PER", mtTo.COD_PER);

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
        public DataTable obtenerPreventaMetasparaConsultaDAL(metasTo mtTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_CONSULTA_METAS_POR_NIVEL", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FE_AÑO", mtTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", mtTo.FE_MES);
            cmd.Parameters.AddWithValue("@COD_PER", mtTo.COD_PER);
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
        public DataTable obtenerPreventaMetasparaConsultaVendedorDAL(metasTo mtTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_CONSULTA_METAS_POR_NIVEL_VENDEDOR", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SUCURSAL", mtTo.SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_PROGRAMA", mtTo.COD_PROGRAMA);
            cmd.Parameters.AddWithValue("@TIPO_PLANILLA", mtTo.TIPO_PLANILLA);
            cmd.Parameters.AddWithValue("@FE_MES", mtTo.FE_MES);
            cmd.Parameters.AddWithValue("@FE_AÑO", mtTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@COD_PER", mtTo.COD_PER);
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
