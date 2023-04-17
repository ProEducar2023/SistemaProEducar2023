using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class otrosCargosComisionesDAL
    {
        SqlConnection conn;
        public otrosCargosComisionesDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerOtrosCargosComisionesDAL(otrosCargosComisionesTo occTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_OTROS_CARGOS_DEL_PERIODO_X_PERSONA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FE_AÑO", occTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", occTo.FE_MES);
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
        public DataTable obtenerOtrosCargosComisionesDetalleDAL(otrosCargosComisionesTo occTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_OTROS_CARGOS_DEL_PERIODO_X_PERSONA_DETALLE", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", occTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@FE_AÑO", occTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", occTo.FE_MES);
            cmd.Parameters.AddWithValue("@COD_PER", occTo.COD_PER);
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
        public bool insertarOtrosCargosComisionesDAL(otrosCargosComisionesTo occTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_OTROS_CARGOS_COMISIONES", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", occTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@FE_AÑO", occTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", occTo.FE_MES);
            cmd.Parameters.AddWithValue("@COD_PER", occTo.COD_PER);
            cmd.Parameters.AddWithValue("@NRO_DOC", occTo.NRO_DOC);
            cmd.Parameters.AddWithValue("@FECHA_DOC", occTo.FECHA_DOC);
            cmd.Parameters.AddWithValue("@COD_CPTO", occTo.COD_CPTO);
            cmd.Parameters.AddWithValue("@COD_D_H", occTo.COD_D_H);
            cmd.Parameters.AddWithValue("@IMPORTE", occTo.IMPORTE);
            cmd.Parameters.AddWithValue("@OBSERVACIONES", occTo.OBSERVACIONES);
            cmd.Parameters.AddWithValue("@IMP_RETENCION", occTo.IMP_RETENCION);
            cmd.Parameters.AddWithValue("@COD_CREA", occTo.COD_CREA);
            cmd.Parameters.AddWithValue("@FECHA_CREA", occTo.FECHA_CREA);
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
        public DataTable obtenerOtrosCargosComisionesxPeriodoparaResumenDAL(otrosCargosComisionesTo occTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_OTROS_CARGOS_COMISIONES_X_PERIODO_PARA_RESUMEN", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FE_AÑO", occTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", occTo.FE_MES);
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
        public decimal sumaOtrosCargos_Comisiones_X_Periodo_X_ComisionistaDAL(otrosCargosComisionesTo occTo)
        {
            decimal sum = 0;
            SqlCommand cmd = new SqlCommand("SUMAR_OTROS_CARGOS_COMISIONES_X_PERIODO_X_COMISIONISTA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FE_AÑO", occTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", occTo.FE_MES);
            cmd.Parameters.AddWithValue("@COD_PER", occTo.COD_PER);
            try
            {
                conn.Open();
                sum = Convert.ToDecimal(cmd.ExecuteScalar());
            }
            catch (Exception)
            {
                sum = 0;
            }
            finally
            {
                conn.Close();
            }
            return sum;
        }
        public DataTable obtenerOtrosCargos_Comisiones_X_Periodo_X_ComisionistaDAL(otrosCargosComisionesTo occTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_OTROS_CARGOS_COMISIONES_X_PERIODO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FE_AÑO", occTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", occTo.FE_MES);
            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr, LoadOption.Upsert);
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
        public bool quitarOtrosCargosComisionesDAL(otrosCargosComisionesTo occTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_OTROS_CARGOS_COMISIONES", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", occTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@FE_AÑO", occTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", occTo.FE_MES);
            cmd.Parameters.AddWithValue("@COD_PER", occTo.COD_PER);

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
        public bool eliminarOtrosCargosComisionesDAL(otrosCargosComisionesTo occTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", occTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@FE_AÑO", occTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", occTo.FE_MES);
            cmd.Parameters.AddWithValue("@COD_PER", occTo.COD_PER);

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
