using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class subGrupoDAL
    {
        SqlConnection conn;
        public subGrupoDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerSubGrupoDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_SUBGRUPO", conn);
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
        public bool insertaSubGrupoDAL(subGrupoTo sgruTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_SUBGRUPO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_CLASE", sgruTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_GRUPO", sgruTo.COD_GRUPO);
            cmd.Parameters.AddWithValue("@COD_SUBGRUPO", sgruTo.COD_SUBGRUPO);
            cmd.Parameters.AddWithValue("@DESC_SUBGRUPO", sgruTo.DESC_SUBGRUPO);
            cmd.Parameters.AddWithValue("@DESC_CORTA", sgruTo.DESC_CORTA);
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
        public bool modificaSubGrupoDAL(subGrupoTo sgruTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_SUBGRUPO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_CLASE", sgruTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_GRUPO", sgruTo.COD_GRUPO);
            cmd.Parameters.AddWithValue("@COD_SUBGRUPO", sgruTo.COD_SUBGRUPO);
            cmd.Parameters.AddWithValue("@DESC_SUBGRUPO", sgruTo.DESC_SUBGRUPO);
            cmd.Parameters.AddWithValue("@DESC_CORTA", sgruTo.DESC_CORTA);
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
        public bool eliminaSubGrupoDAL(subGrupoTo sgruTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_SUBGRUPO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_CLASE", sgruTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_GRUPO", sgruTo.COD_GRUPO);
            cmd.Parameters.AddWithValue("@COD_SUBGRUPO", sgruTo.COD_SUBGRUPO);
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
        public string obtenerCodSubGrupoDAL(string codcla, string codgru)
        {
            string codsgru = "";
            SqlCommand cmd = new SqlCommand("SGT_SUBGRUPO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_CLASE", codcla);
            cmd.Parameters.AddWithValue("@COD_GRUPO", codgru);
            try
            {
                conn.Open();
                codsgru = cmd.ExecuteScalar().ToString();
            }
            catch (Exception)
            {
                codsgru = "";
            }
            finally
            {
                conn.Close();
            }
            return codsgru;
        }
        public DataTable obtenerSubGrupoClaseGrupoDAL(subGrupoTo sgruTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("CBO_SUBGRUPO_CLASE_GRUPO2", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_CLASE", sgruTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_GRUPO", sgruTo.COD_GRUPO);
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
        public int ValidarSubGrupoDAL(subGrupoTo sgruTo)
        {
            int codsgru = -1;
            SqlCommand cmd = new SqlCommand("VERIFICAR_SUBGRUPO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_CLASE", sgruTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_GRUPO", sgruTo.COD_GRUPO);
            cmd.Parameters.AddWithValue("@COD_SUBGRUPO", sgruTo.COD_SUBGRUPO);
            try
            {
                conn.Open();
                codsgru = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception)
            {
                codsgru = -1;
            }
            finally
            {
                conn.Close();
            }
            return codsgru;
        }
    }
}
