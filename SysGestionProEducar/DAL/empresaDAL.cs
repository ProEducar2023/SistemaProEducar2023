using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class empresaDAL
    {
        SqlConnection conn2;
        public empresaDAL()
        {
            conn2 = new SqlConnection(conexion.con2);
        }
        public DataTable obtenerTodasEmpresasDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_TODAS_EMPRESAS", conn2);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn2.Open();
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
                conn2.Close();
            }
            return dt;
        }
        public DataTable obtenerEmpresa_x_CodDAL(empresaTo empTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_EMPRESAS_X_COD", conn2);
            cmd.Parameters.AddWithValue("@Cod_Empresa", empTo.Cod_Empresa);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn2.Open();
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
                conn2.Close();
            }
            return dt;
        }
    }
}
