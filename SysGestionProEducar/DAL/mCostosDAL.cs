using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class mCostosDAL
    {
        SqlConnection conn;
        public mCostosDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public bool modificaMCostosSaldoInicialDAL(mCostosTo mCosTo, ref string errMensaje)
        {
            bool flag = true;
            SqlCommand cmd = new SqlCommand("MODIFICA_M_COSTOS_SALDO_INICIAL", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("FE_AÑO2", mCosTo.FE_AÑO2);//año destino
            cmd.Parameters.AddWithValue("COD_CLASE", mCosTo.COD_CLASE);

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
        public bool modificadesMCostosSaldoInicialDAL(mCostosTo mCosTo, ref string errMensaje)
        {
            bool flag = true;
            SqlCommand cmd = new SqlCommand("MODIFICA_DES_M_COSTOS_SALDO_INICIAL", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("FE_AÑO2", mCosTo.FE_AÑO2);//año destino
            cmd.Parameters.AddWithValue("COD_CLASE", mCosTo.COD_CLASE);

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
        public bool eliminaIniMCostosSaldoInicialDAL(ref string errMensaje)
        {
            bool flag = true;
            string sql = "DELETE FROM INI_M_COSTOS";
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
                errMensaje = e.Message;
            }
            finally
            {
                conn.Close();
            }
            return flag;
        }
        public bool insertarIniMCostosSaldoInicialDAL(mCostosTo mCosTo, ref string errMensaje)
        {
            bool flag = true;
            string sql = "INSERT INTO INI_M_COSTOS(FE_AÑO,COD_CLASE,COD_ARTICULO,SALDO_ACTUAL00,PRECIO_COSTO00)" +
                "SELECT DISTINCT  @FE_AÑO2,COD_CLASE,COD_ARTICULO,SUM(CANTIDAD),(SUM(VALOR_COMPRA-VALOR_DSCTO+AJUSTE_BI)/SUM(CANTIDAD)) FROM " +
                "INVENTARIO_DETALLES  WHERE FE_AÑO=@FE_AÑO AND FE_MES=@FE_MES AND CANTIDAD > 0 AND " +
                "COD_CLASE=@COD_CLASE GROUP BY COD_ARTICULO,COD_CLASE,COD_ARTICULO,FE_AÑO";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@FE_AÑO", mCosTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_AÑO2", mCosTo.FE_AÑO2);
            cmd.Parameters.AddWithValue("@FE_MES", mCosTo.FE_MES);
            cmd.Parameters.AddWithValue("@COD_CLASE", mCosTo.COD_CLASE);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception e)
            {
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
