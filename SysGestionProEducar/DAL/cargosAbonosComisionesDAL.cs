using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class cargosAbonosComisionesDAL
    {
        SqlConnection conn;
        public cargosAbonosComisionesDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerCargosAbonosComisionesDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_CARGOS_ABONOS_COMISIONES", conn);
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
        public bool insertarCargosAbonosComisionesDAL(cargosAbonosComisionesTo cacTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_CARGOS_ABONOS_COMISIONES", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_CONCEPTO", cacTo.COD_CONCEPTO);
            cmd.Parameters.AddWithValue("@DESC_CONCEPTO", cacTo.DESC_CONCEPTO);
            cmd.Parameters.AddWithValue("@DESC_CORTA", cacTo.DESC_CORTA);
            cmd.Parameters.AddWithValue("@STATUS_IMPUESTOS", cacTo.STATUS_IMPUESTOS);
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
        public bool modificarCargosAbonosComisionesDAL(cargosAbonosComisionesTo cacTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_CARGOS_ABONOS_COMISIONES", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_CONCEPTO", cacTo.COD_CONCEPTO);
            cmd.Parameters.AddWithValue("@DESC_CONCEPTO", cacTo.DESC_CONCEPTO);
            cmd.Parameters.AddWithValue("@DESC_CORTA", cacTo.DESC_CORTA);
            cmd.Parameters.AddWithValue("@STATUS_IMPUESTOS", cacTo.STATUS_IMPUESTOS);
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

        public bool eliminarCargosAbonosComisionesDAL(cargosAbonosComisionesTo cacTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_CARGOS_ABONOS_COMISIONES", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_CONCEPTO", cacTo.COD_CONCEPTO);

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
