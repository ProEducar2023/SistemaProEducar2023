using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class pResumenComisionDAL
    {
        SqlConnection conn;
        public pResumenComisionDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerResumenComisionDAL(pResumenComisionTo presTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", presTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@FE_AÑO", presTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", presTo.FE_MES);
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
        public bool insertarResumenComisionDAL(pResumenComisionTo presTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_P_RESUMEN_COMISION", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TIPO_VTA", presTo.TIPO_VTA);
            cmd.Parameters.AddWithValue("@COD_PROGRAMA", presTo.COD_PROGRAMA);
            cmd.Parameters.AddWithValue("@FE_AÑO", presTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", presTo.FE_MES);
            cmd.Parameters.AddWithValue("@COD_PER", presTo.COD_PER);
            cmd.Parameters.AddWithValue("@IMPORTE", presTo.IMPORTE);
            cmd.Parameters.AddWithValue("@COD_CREA", presTo.COD_CREA);
            cmd.Parameters.AddWithValue("@FECHA_CREA", presTo.FECHA_CREA);
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
