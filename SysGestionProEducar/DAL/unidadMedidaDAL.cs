using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class unidadMedidaDAL
    {
        SqlConnection conn2;
        public unidadMedidaDAL()
        {
            conn2 = new SqlConnection(conexion.con2);
        }
        public DataTable obtenerUnidadMedidaDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_UNIDAD_MEDIDA", conn2);
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
        public bool insertaUnidadMedidaDAL(unidadMedidaTo umTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_UNIDAD", conn2);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CODIGO", umTo.CODIGO);
            cmd.Parameters.AddWithValue("@DESCRIPCION", umTo.DESCRIPCION);
            cmd.Parameters.AddWithValue("@DESC_CORTA", umTo.DESC_CORTA);
            cmd.Parameters.AddWithValue("@COD_SUNAT", umTo.COD_SUNAT);
            try
            {
                conn2.Open();
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
                conn2.Close();
            }
            return flag;
        }
        public bool modificaUnidadMedidaDAL(unidadMedidaTo umTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_UNIDAD", conn2);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CODIGO", umTo.CODIGO);
            cmd.Parameters.AddWithValue("@DESCRIPCION", umTo.DESCRIPCION);
            cmd.Parameters.AddWithValue("@DESC_CORTA", umTo.DESC_CORTA);
            cmd.Parameters.AddWithValue("@COD_SUNAT", umTo.COD_SUNAT);
            try
            {
                conn2.Open();
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
                conn2.Close();
            }
            return flag;
        }
        public bool eliminaUnidadMedidaDAL(unidadMedidaTo umTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_UNIDAD", conn2);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CODIGO", umTo.CODIGO);
            try
            {
                conn2.Open();
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
                conn2.Close();
            }
            return flag;
        }
        public int CONTAR_REGDAL(string CODIGO)
        {
            int qt = -1;
            SqlCommand cmd = new SqlCommand("VERIFICAR_UNIDAD", conn2);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CODIGO", CODIGO);
            try
            {
                conn2.Open();
                qt = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception)
            {
                qt = -1;
            }
            finally
            {
                conn2.Close();
            }
            return qt;
        }
        public int ValidarUnidadMedidaDAL(unidadMedidaTo umTo)
        {
            int qt = -1;
            SqlCommand cmd = new SqlCommand("VERIFICAR_UNIDAD", conn2);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CODIGO", umTo.CODIGO);
            try
            {
                conn2.Open();
                qt = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception)
            {
                qt = -1;
            }
            finally
            {
                conn2.Close();
            }
            return qt;
        }
    }
}
