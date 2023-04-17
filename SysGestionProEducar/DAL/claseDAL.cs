using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class claseDAL
    {
        SqlConnection conn;
        public claseDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerClaseArticuloDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_CLASE", conn);
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
        public bool insertaClaseArticuloDAL(claseTo claTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_CLASE", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_CLASE", claTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@DESC_CLASE", claTo.DESC_CLASE);
            cmd.Parameters.AddWithValue("@DESC_CORTA", claTo.DESC_CORTA);
            cmd.Parameters.AddWithValue("@COD_TIPO", claTo.COD_TIPO);
            cmd.Parameters.AddWithValue("@COD_D_H", claTo.COD_D_H);
            cmd.Parameters.AddWithValue("@COD_TIPO_COMPRAS", claTo.COD_TIPO_COMPRAS);
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
        public bool modificaClaseArticuloDAL(claseTo claTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_CLASE", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_CLASE", claTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@DESC_CLASE", claTo.DESC_CLASE);
            cmd.Parameters.AddWithValue("@DESC_CORTA", claTo.DESC_CORTA);
            cmd.Parameters.AddWithValue("@COD_TIPO", claTo.COD_TIPO);
            cmd.Parameters.AddWithValue("@COD_D_H", claTo.COD_D_H);
            cmd.Parameters.AddWithValue("@COD_TIPO_COMPRAS", claTo.COD_TIPO_COMPRAS);
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
        public bool eliminaClaseArticuloDAL(claseTo claTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_CLASE", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_CLASE", claTo.COD_CLASE);
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
        public DataTable obtenerClaseArticuloparaGrupoDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("CBO_CLASE0", conn);
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
        public string HALLAR_CLASE_COD_DAL(string cod_clase)
        {
            string val = "";
            SqlCommand cmd = new SqlCommand("HALLAR_CLASE_COD", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_CLASE", cod_clase);
            try
            {
                conn.Open();
                val = cmd.ExecuteScalar().ToString();
            }
            catch (Exception)
            {
                val = "";
            }
            finally
            {
                conn.Close();
            }
            return val;
        }
        public int ValidaClaseDAL(claseTo claTo)
        {
            int val = -1;
            SqlCommand cmd = new SqlCommand("VERIFICAR_CLASE", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_CLASE", claTo.COD_CLASE);
            try
            {
                conn.Open();
                val = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception)
            {
                val = -1;
            }
            finally
            {
                conn.Close();
            }
            return val;
        }
    }
}
