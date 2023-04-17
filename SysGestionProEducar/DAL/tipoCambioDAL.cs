using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class tipoCambioDAL
    {
        SqlConnection conn2, conn;
        public tipoCambioDAL()
        {
            conn2 = new SqlConnection(conexion.con2);
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerMonedasDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("cargar_moneda2", conn2);
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
        public DataTable obtenerAnnioDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("CARGAR_AÑO_TODO", conn);
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
        public DataTable mostrarTipoCambioDAL(tipoCambioTo tpcTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("Mostrar_cambio", conn2);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@año", tpcTo.Año);
            cmd.Parameters.AddWithValue("@mes", tpcTo.Mes);
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
        public bool insertarTipoCambioDAL(tipoCambioTo tpcTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("insertar_cambio", conn2);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cod_moneda", tpcTo.Cod_Moneda);
            cmd.Parameters.AddWithValue("@año", tpcTo.Año);
            cmd.Parameters.AddWithValue("@mes", tpcTo.Mes);
            cmd.Parameters.AddWithValue("@dia", tpcTo.Dia);
            cmd.Parameters.AddWithValue("@venta", tpcTo.Tipo_Venta);
            cmd.Parameters.AddWithValue("@compra", tpcTo.Tipo_Compra);
            cmd.Parameters.AddWithValue("@venta_paralelo", tpcTo.Tipo_Venta_Paralelo);
            cmd.Parameters.AddWithValue("@compra_paralelo", tpcTo.Tipo_Compra_Paralelo);
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
        public bool VerificarTipoCambioDAL(tipoCambioTo tpcTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("VERIFICAR_TIPO_CAMBIO", conn2);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cod_moneda", tpcTo.Cod_Moneda);
            cmd.Parameters.AddWithValue("@año", tpcTo.Año);
            cmd.Parameters.AddWithValue("@mes", tpcTo.Mes);
            cmd.Parameters.AddWithValue("@dia", tpcTo.Dia);
            try
            {
                conn2.Open();
                flag = Convert.ToBoolean(cmd.ExecuteScalar());
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
        public bool modificarTipoCambioDAL(tipoCambioTo tpcTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("modificar_cambio", conn2);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cod_moneda", tpcTo.Cod_Moneda);
            cmd.Parameters.AddWithValue("@año", tpcTo.Año);
            cmd.Parameters.AddWithValue("@mes", tpcTo.Mes);
            cmd.Parameters.AddWithValue("@dia", tpcTo.Dia);
            cmd.Parameters.AddWithValue("@venta", tpcTo.Tipo_Venta);
            cmd.Parameters.AddWithValue("@compra", tpcTo.Tipo_Compra);
            cmd.Parameters.AddWithValue("@venta_paralelo", tpcTo.Tipo_Venta_Paralelo);
            cmd.Parameters.AddWithValue("@compra_paralelo", tpcTo.Tipo_Compra_Paralelo);
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
        public string SACAR_CAMBIO(tipoCambioTo tpcTo)
        {
            string tc = "";
            SqlCommand cmd = new SqlCommand("sacar_cambio", conn2);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@año", tpcTo.Año);
            cmd.Parameters.AddWithValue("@mes", tpcTo.Mes);
            cmd.Parameters.AddWithValue("@dia", tpcTo.Dia);
            cmd.Parameters.AddWithValue("@tipo", tpcTo.Cod_Moneda);
            try
            {
                conn2.Open();
                tc = cmd.ExecuteScalar().ToString();
            }
            catch (Exception)
            {
                tc = "";
            }
            finally
            {
                conn2.Close();
            }
            return tc;
        }
        public bool eliminaTipodeCambioDAL(tipoCambioTo tpcTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("Eliminar_cambio", conn2);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@año", tpcTo.Año);
            cmd.Parameters.AddWithValue("@mes", tpcTo.Mes);
            cmd.Parameters.AddWithValue("@dia", tpcTo.Dia);
            cmd.Parameters.AddWithValue("@cod_tipo", tpcTo.Cod_Moneda);

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
    }

}
