using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class mArticuloDAL
    {
        SqlConnection conn;
        public mArticuloDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public bool insertarArticuloaAlmacenDAL(mArticuloTo marTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_ARTICULO_A_ALMACEN", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_CLASE", marTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_ALMACEN", marTo.COD_ALMACEN);
            cmd.Parameters.AddWithValue("@COD_ARTICULO", marTo.COD_ARTICULO);
            cmd.Parameters.AddWithValue("@SALDO_ACT", marTo.SALDO_ACT);
            cmd.Parameters.AddWithValue("@FECHA_DOC", marTo.FECHA_DOC);

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
        public bool verificarStockAlmacenesDAL(mArticuloTo marTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("VERIFICA_STOCK_ALMACEN_X_NRO_PRESUPUESTO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_PRESUPUESTO", marTo.NRO_PRESUPUESTO);

            try
            {
                conn.Open();
                flag = Convert.ToBoolean(cmd.ExecuteScalar());
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
        public bool adicionarSaldoxCambioAlmacenesDAL(mArticuloTo marTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ADICIONAR_SALDO_X_CAMBIO_ALMACENES", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_CLASE", marTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_ALMACEN", marTo.COD_ALMACEN);
            cmd.Parameters.AddWithValue("@COD_ARTICULO", marTo.COD_ARTICULO);
            cmd.Parameters.AddWithValue("@SALDO_ACT", marTo.SALDO_ACT);
            cmd.Parameters.AddWithValue("@FECHA_DOC", marTo.FECHA_DOC);

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
        public bool restarSaldoxCambioAlmacenesDAL(mArticuloTo marTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("RESTAR_SALDO_X_CAMBIO_ALMACENES", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_CLASE", marTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_ALMACEN", marTo.COD_ALMACEN);
            cmd.Parameters.AddWithValue("@COD_ARTICULO", marTo.COD_ARTICULO);
            cmd.Parameters.AddWithValue("@SALDO_ACT", marTo.SALDO_ACT);
            cmd.Parameters.AddWithValue("@FECHA_DOC", marTo.FECHA_DOC);

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
