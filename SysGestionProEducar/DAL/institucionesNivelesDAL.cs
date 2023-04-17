using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class institucionesNivelesDAL
    {
        SqlConnection conn;
        public institucionesNivelesDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerInstitucionesNivelesDAL(institucionesNivelesTo inTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_INSTIUCIONES_NIVELES_X_CODIGO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CODIGO", inTo.CODIGO);
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
        public bool insertarInstitucionesNivelesDAL(institucionesNivelesTo inTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_INSTITUCIONES_NIVELES", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CODIGO", inTo.CODIGO);
            cmd.Parameters.AddWithValue("@COD_INSTITUCION", inTo.COD_INSTITUCION);
            cmd.Parameters.AddWithValue("@DESCRIPCION", inTo.DESCRIPCION);
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
        public bool modificarInstitucionesNivelesDAL(institucionesNivelesTo inTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_INSTITUCIONES_NIVELES", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CODIGO", inTo.CODIGO);
            cmd.Parameters.AddWithValue("@COD_INSTITUCION", inTo.COD_INSTITUCION);
            cmd.Parameters.AddWithValue("@DESCRIPCION", inTo.DESCRIPCION);
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
        public bool eliminarInstitucionesNivelesDAL(institucionesNivelesTo inTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_INSTITUCIONES_NIVELES", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CODIGO", inTo.CODIGO);
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
