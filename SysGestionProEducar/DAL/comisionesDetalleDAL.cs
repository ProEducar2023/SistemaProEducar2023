using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class comisionesDetalleDAL
    {
        SqlConnection conn;
        public comisionesDetalleDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerComisionesDetalleDAL(comisionesDetalleTo comTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_COMISIONES_DETALLE", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TIPO", comTo.TIPO);
            cmd.Parameters.AddWithValue("@COD_PROGRAMA", comTo.COD_PROGRAMA);
            cmd.Parameters.AddWithValue("@COD_PER", comTo.COD_PER);
            cmd.Parameters.AddWithValue("@COD_INSTITUCION", comTo.COD_INSTITUCION);
            cmd.Parameters.AddWithValue("@COD_NIVEL_INSTITUCION", comTo.COD_NIVEL_INSTITUCION);
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
        public bool insertarComisionesDetalleDAL(comisionesDetalleTo comTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_MAESTRO_COMISIONES_DETALLE", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TIPO", comTo.TIPO);
            cmd.Parameters.AddWithValue("@COD_PROGRAMA", comTo.COD_PROGRAMA);
            cmd.Parameters.AddWithValue("@COD_PER", comTo.COD_PER);
            cmd.Parameters.AddWithValue("@COD_INSTITUCION", comTo.COD_INSTITUCION);
            cmd.Parameters.AddWithValue("@COD_NIVEL_INSTITUCION", comTo.COD_NIVEL_INSTITUCION);
            cmd.Parameters.AddWithValue("@COD_NIVEL", comTo.COD_NIVEL);
            cmd.Parameters.AddWithValue("@NOM_NIVEL", comTo.NOM_NIVEL);
            cmd.Parameters.AddWithValue("@COD_PER_SUP", comTo.COD_PER_SUP);
            cmd.Parameters.AddWithValue("@NOM_PER_SUP", comTo.NOM_PER_SUP);
            cmd.Parameters.AddWithValue("@IMPORTE", comTo.IMPORTE);
            cmd.Parameters.AddWithValue("@PORCENTAJE", comTo.PORCENTAJE);
            cmd.Parameters.AddWithValue("@CUOTA", comTo.CUOTA);
            cmd.Parameters.AddWithValue("@COD_CREA", comTo.COD_CREA);
            cmd.Parameters.AddWithValue("@FECHA_CREA", comTo.FECHA_CREA);
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
        public bool modificarComisionesDetalleDAL(comisionesDetalleTo comTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TIPO", comTo.TIPO);
            cmd.Parameters.AddWithValue("@COD_PROGRAMA", comTo.COD_PROGRAMA);
            cmd.Parameters.AddWithValue("@COD_PER", comTo.COD_PER);
            cmd.Parameters.AddWithValue("@COD_NIVEL", comTo.COD_NIVEL);
            cmd.Parameters.AddWithValue("@NOM_NIVEL", comTo.NOM_NIVEL);
            cmd.Parameters.AddWithValue("@COD_PER_SUP", comTo.COD_PER_SUP);
            cmd.Parameters.AddWithValue("@NOM_PER_SUP", comTo.NOM_PER_SUP);
            cmd.Parameters.AddWithValue("@IMPORTE", comTo.IMPORTE);
            cmd.Parameters.AddWithValue("@CUOTA", comTo.CUOTA);
            cmd.Parameters.AddWithValue("@COD_CREA", comTo.COD_CREA);
            cmd.Parameters.AddWithValue("@FECHA_CREA", comTo.FECHA_CREA);
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
        public bool eliminarComisionesDetalleDAL(comisionesDetalleTo comTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_MAESTRO_DETALLE", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TIPO", comTo.TIPO);
            cmd.Parameters.AddWithValue("@COD_PROGRAMA", comTo.COD_PROGRAMA);
            cmd.Parameters.AddWithValue("@COD_PER", comTo.COD_PER);
            cmd.Parameters.AddWithValue("@COD_INSTITUCION", comTo.COD_INSTITUCION);
            cmd.Parameters.AddWithValue("@COD_NIVEL_INSTITUCION", comTo.COD_NIVEL_INSTITUCION);
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
        public DataTable mostrarMaestroDetalleDAL(comisionesDetalleTo codTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_CONSULTA_MAESTRO_COMISIONES", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TIPO", codTo.TIPO);
            cmd.Parameters.AddWithValue("@COD_PROGRAMA", codTo.COD_PROGRAMA);
            cmd.Parameters.AddWithValue("@COD_PER", codTo.COD_PER);
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
        public DataTable obtenerComisionesDetalleDistintosDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_COMISIONES_DETALLE_DISTINTOS", conn);
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
        public DataTable obtener_Detalle_Comisiones_x_PersonaDAL(comisionesDetalleTo codTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_DETALLE_COMISIONES_X_PERSONA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            if (codTo.COD_PER_SUP == null)
                cmd.Parameters.AddWithValue("@COD_PER_SUP", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@COD_PER_SUP", codTo.COD_PER_SUP);
            cmd.Parameters.AddWithValue("@COD_NIVEL", codTo.COD_NIVEL);
            cmd.Parameters.AddWithValue("@COD_PROGRAMA", codTo.COD_PROGRAMA);
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
