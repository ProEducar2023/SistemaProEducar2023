using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class grupoDAL
    {
        SqlConnection conn;
        public grupoDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerGrupoDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_GRUPO", conn);
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
        public bool insertarGrupoDAL(grupoTo gruTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_GRUPO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_CLASE", gruTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_GRUPO", gruTo.COD_GRUPO);
            cmd.Parameters.AddWithValue("@DESC_GRUPO", gruTo.DESC_GRUPO);
            cmd.Parameters.AddWithValue("@DESC_CORTA", gruTo.DESC_CORTA);
            cmd.Parameters.AddWithValue("@COD_SUNAT", gruTo.COD_SUNAT);
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
        public bool modificaGrupoDAL(grupoTo gruTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_GRUPO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_CLASE", gruTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_GRUPO", gruTo.COD_GRUPO);
            cmd.Parameters.AddWithValue("@DESC_GRUPO", gruTo.DESC_GRUPO);
            cmd.Parameters.AddWithValue("@DESC_CORTA", gruTo.DESC_CORTA);
            cmd.Parameters.AddWithValue("@COD_SUNAT", gruTo.COD_SUNAT);
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
        public bool eliminaGrupoDAL(grupoTo gruTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_GRUPO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_CLASE", gruTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_GRUPO", gruTo.COD_GRUPO);
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
        public DataTable obtenerGrupoClaseDAL(string codclase)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("CBO_GRUPO_CLASE2", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_CLASE", codclase);
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
        public string obtieneCodGrupoDAL(string desgrupo, string codclase)
        {
            string codgrupo = "";
            SqlCommand cmd = new SqlCommand("COD_GRUPO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_CLASE", codclase);
            cmd.Parameters.AddWithValue("@DESC_GRUPO", desgrupo);
            try
            {
                conn.Open();
                codgrupo = cmd.ExecuteScalar().ToString();

            }
            catch (Exception)
            {
                codgrupo = "";
            }
            finally
            {
                conn.Close();
            }
            return codgrupo;
        }
        public int VerificarGrupoDAL(grupoTo gruTo)
        {
            int codgrupo = -1;
            SqlCommand cmd = new SqlCommand("VERIFICAR_GRUPO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_CLASE", gruTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_GRUPO", gruTo.COD_GRUPO);
            try
            {
                conn.Open();
                codgrupo = Convert.ToInt32(cmd.ExecuteScalar());

            }
            catch (Exception)
            {
                codgrupo = -1;
            }
            finally
            {
                conn.Close();
            }
            return codgrupo;
        }
    }


}
