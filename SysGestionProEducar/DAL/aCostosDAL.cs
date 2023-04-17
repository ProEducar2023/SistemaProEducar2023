using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class aCostosDAL
    {
        SqlConnection conn;
        public aCostosDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerACostosDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("", conn);
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
        public bool insertarACostosDAL(aCostosTo acosTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", acosTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@FE_AÑO", acosTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@COD_CLASE", acosTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_ARTICULO", acosTo.COD_ARTICULO);
            cmd.Parameters.AddWithValue("@COD_ALMACEN", acosTo.COD_ALMACEN);
            cmd.Parameters.AddWithValue("@SALDO_ACTUAL00", acosTo.SALDO_ACTUAL00);
            cmd.Parameters.AddWithValue("@SALDO_ACTUAL01", acosTo.SALDO_ACTUAL01);
            cmd.Parameters.AddWithValue("@SALDO_ACTUAL02", acosTo.SALDO_ACTUAL02);
            cmd.Parameters.AddWithValue("@SALDO_ACTUAL03", acosTo.SALDO_ACTUAL03);
            cmd.Parameters.AddWithValue("@SALDO_ACTUAL04", acosTo.SALDO_ACTUAL04);
            cmd.Parameters.AddWithValue("@SALDO_ACTUAL05", acosTo.SALDO_ACTUAL05);
            cmd.Parameters.AddWithValue("@SALDO_ACTUAL06", acosTo.SALDO_ACTUAL06);
            cmd.Parameters.AddWithValue("@SALDO_ACTUAL07", acosTo.SALDO_ACTUAL07);
            cmd.Parameters.AddWithValue("@SALDO_ACTUAL08", acosTo.SALDO_ACTUAL08);
            cmd.Parameters.AddWithValue("@SALDO_ACTUAL09", acosTo.SALDO_ACTUAL09);
            cmd.Parameters.AddWithValue("@SALDO_ACTUAL10", acosTo.SALDO_ACTUAL10);
            cmd.Parameters.AddWithValue("@SALDO_ACTUAL11", acosTo.SALDO_ACTUAL11);
            cmd.Parameters.AddWithValue("@SALDO_ACTUAL12", acosTo.SALDO_ACTUAL12);
            cmd.Parameters.AddWithValue("@SALDO_ACTUAL13", acosTo.SALDO_ACTUAL13);
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
        public bool modificarACostosSaldoInicialDAL(aCostosTo acosTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICA_A_COSTOS_SALDO_INICIAL", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FE_AÑO2", acosTo.FE_AÑO2);
            cmd.Parameters.AddWithValue("@COD_CLASE", acosTo.COD_CLASE);

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
        public bool eliminaIniACostosSaldoInicialDAL(aCostosTo acosTo, ref string errMensaje)
        {
            bool flag = false;
            string sql = "DELETE FROM INI_A_COSTOS";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;

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
        public bool insertarIniACostosSaldoInicialDAL(aCostosTo acosTo, ref string errMensaje)
        {
            bool flag = false;
            string sql = "INSERT INTO INI_A_COSTOS(COD_SUCURSAL,FE_AÑO,COD_CLASE,COD_ARTICULO,COD_ALMACEN,SALDO_ACTUAL00) " +
                "SELECT DISTINCT  right('00' + ltrim(rtrim(str(cast(MAX(cod_sucursal) as int)))),2), @FE_AÑO2,COD_CLASE,COD_ARTICULO,COD_ALMACEN,SUM(CANTIDAD) " +
                "FROM BD_GCO03.DBO.INVENTARIO_DETALLES  WHERE  FE_AÑO=@FE_AÑO AND FE_MES=@FE_MES AND COD_CLASE=@COD_CLASE " +
                "GROUP BY COD_ARTICULO,COD_CLASE,COD_ARTICULO,FE_AÑO,COD_ALMACEN";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@FE_AÑO", acosTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_AÑO2", acosTo.FE_AÑO2);
            cmd.Parameters.AddWithValue("@FE_MES", acosTo.FE_MES);
            cmd.Parameters.AddWithValue("@COD_CLASE", acosTo.COD_CLASE);
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
        public bool saldoInicialCostoDAL(aCostosTo acosTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("SALDO_INICIAL_COSTO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FE_AÑO", acosTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_AÑO2", acosTo.FE_AÑO2);
            cmd.Parameters.AddWithValue("@SUCURSAL", acosTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_CLASE", acosTo.COD_CLASE);
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
