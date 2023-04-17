using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class personaDireccionDAL
    {
        SqlConnection conn;
        public personaDireccionDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerPersonalDireccionDAL(personaDireccionTo pedTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_DIRECCIONES", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PER", pedTo.COD_PER);
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
        public bool insertarPersonalDireccionDAL(personaDireccionTo pedTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_DIRECCIONES", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PER", pedTo.COD_PER);
            cmd.Parameters.AddWithValue("@COD_TIPO", pedTo.COD_TIPO);
            cmd.Parameters.AddWithValue("@COD_PAIS", pedTo.COD_PAIS);
            cmd.Parameters.AddWithValue("@COD_DEP", pedTo.COD_DEP);
            cmd.Parameters.AddWithValue("@COD_PRO", pedTo.COD_PRO);
            cmd.Parameters.AddWithValue("@COD_DIST", pedTo.COD_DIST);
            cmd.Parameters.AddWithValue("@DIRECCION", pedTo.DIRECCION);
            cmd.Parameters.AddWithValue("@REFERENCIA", pedTo.REFERENCIA);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception e)
            {
                errMensaje = e.Message;
                flag = false;
            }
            finally
            {
                conn.Close();
            }
            return flag;
        }
        public bool eliminarPersonalDireccionDAL(personaDireccionTo pedTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_DIRECCIONES", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PER", pedTo.COD_PER);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception e)
            {
                errMensaje = e.Message;
                flag = false;
            }
            finally
            {
                conn.Close();
            }
            return flag;
        }
    }
}
