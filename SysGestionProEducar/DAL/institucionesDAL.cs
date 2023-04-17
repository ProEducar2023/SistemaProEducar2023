using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class institucionesDAL
    {
        SqlConnection conn;
        public institucionesDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerInstitucionesDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_INSTITUCIONES", conn);
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
        public bool insertarInstitucionesDAL(institucionesTo insTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_INSTITUCIONES", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_INST", insTo.COD_INST);
            cmd.Parameters.AddWithValue("@DESC_INST", insTo.DESC_INST);
            cmd.Parameters.AddWithValue("@DESC_CORTA", insTo.DESC_CORTA);
            cmd.Parameters.AddWithValue("@TIPO_PLANILLA", insTo.TIPO_PLANILLA);
            cmd.Parameters.AddWithValue("@COD_IDENTIDAD", insTo.COD_IDENTIDAD);
            cmd.Parameters.AddWithValue("@DES_IDENTIDAD", insTo.DES_IDENTIDAD);
            cmd.Parameters.AddWithValue("@COD_PROCESO", insTo.COD_PROCESO);
            cmd.Parameters.AddWithValue("@DES_PROCESO", insTo.DES_PROCESO);
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
        public bool modificarInstitucionesDAL(institucionesTo insTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_INSTITUCIONES", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_INST", insTo.COD_INST);
            cmd.Parameters.AddWithValue("@DESC_INST", insTo.DESC_INST);
            cmd.Parameters.AddWithValue("@DESC_CORTA", insTo.DESC_CORTA);
            cmd.Parameters.AddWithValue("@TIPO_PLANILLA", insTo.TIPO_PLANILLA);
            cmd.Parameters.AddWithValue("@COD_IDENTIDAD", insTo.COD_IDENTIDAD);
            cmd.Parameters.AddWithValue("@DES_IDENTIDAD", insTo.DES_IDENTIDAD);
            cmd.Parameters.AddWithValue("@COD_PROCESO", insTo.COD_PROCESO);
            cmd.Parameters.AddWithValue("@DES_PROCESO", insTo.DES_PROCESO);
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
        public bool eliminarInstitucionesDAL(institucionesTo insTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_INSTITUCIONES", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_INST", insTo.COD_INST);
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

        public DataTable ObtenerSubNivelInstituciones(string codInstitucion)
        {
            const string select = "SELECT * FROM INSTITUCIONES_NIVELES WHERE COD_INSTITUCION = @COD_INSTITUCION";
            try
            {
                SqlCommand cmd = new SqlCommand(select, conn)
                {
                    CommandType = CommandType.Text
                };

                cmd.Parameters.AddWithValue("@COD_INSTITUCION", codInstitucion);

                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr, LoadOption.Upsert);
                dr.Close();
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
