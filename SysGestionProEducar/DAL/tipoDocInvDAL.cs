using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class tipoDocInvDAL
    {
        SqlConnection conn, conn2;
        public tipoDocInvDAL()
        {
            conn = new SqlConnection(conexion.con);
            conn2 = new SqlConnection(conexion.con2);

        }
        public DataTable obtenerTipoDocInvDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_DOC_INV", conn);
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
        public bool insertarTipoDocInvDAL(tipoDocInvTo tdiTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_DOC_INV", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_DOC_INV", tdiTo.COD_DOC_INV);
            cmd.Parameters.AddWithValue("@DESC_DOC_INV", tdiTo.DESC_DOC_INV);
            cmd.Parameters.AddWithValue("@DESC_CORTA", tdiTo.DESC_CORTA);
            cmd.Parameters.AddWithValue("@COD_D_H", tdiTo.COD_D_H);
            cmd.Parameters.AddWithValue("@TIPO_DOC", tdiTo.TIPO_DOC);
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
        public bool modificarTipoDocInvDAL(tipoDocInvTo tdiTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_DOC_INV", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_DOC_INV", tdiTo.COD_DOC_INV);
            cmd.Parameters.AddWithValue("@DESC_DOC_INV", tdiTo.DESC_DOC_INV);
            cmd.Parameters.AddWithValue("@DESC_CORTA", tdiTo.DESC_CORTA);
            cmd.Parameters.AddWithValue("@COD_D_H", tdiTo.COD_D_H);
            cmd.Parameters.AddWithValue("@TIPO_DOC", tdiTo.TIPO_DOC);
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
        public bool eliminarTipoDocInvDAL(string COD_DOC_INV, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_DOC_INV", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_DOC_INV", COD_DOC_INV);
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
        public DataTable obtenerTipoDocGestionDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_DOC_GESTION2", conn2);
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
        public int ValidarTipoDocumentoInventarioDAL(tipoDocInvTo tdiTo)
        {
            int val = -1;
            SqlCommand cmd = new SqlCommand("VERIFICAR_TIPO_DOC_INV", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_DOC_INV", tdiTo.COD_DOC_INV);
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
        public string obtieneCodDocInvxTipoDocDAL(tipoDocInvTo tdiTo)
        {
            string val = "";
            SqlCommand cmd = new SqlCommand("MOSTRAR_COD_DOC_X_TIPO_DOC", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TIPO_DOC", tdiTo.TIPO_DOC);
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
    }
}
