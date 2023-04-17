using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class numeroReporteAutomaticoDAL
    {
        SqlConnection conn;
        public numeroReporteAutomaticoDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public string obtener_Numero_Reporte_AutomaticoDAL()
        {
            string val = "";
            SqlCommand cmd = new SqlCommand("MOSTRAR_NUMERO_REPORTE_AUTOMATICO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                val = Convert.ToString(cmd.ExecuteScalar());

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
        public bool actualizar_Numero_Reporte_AutomaticoDAL(numeroReporteAutomaticoTo nraTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ACTUALIZAR_NUMERO_REPORTE_AUTOMATICO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_REPORTE", nraTo.NRO_REPORTE);
            cmd.Parameters.AddWithValue("@COD_MODIFICAR", nraTo.COD_MODIFICAR);
            cmd.Parameters.AddWithValue("@FECHA_MODIFICAR", nraTo.FECHA_MODIFICAR);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception e)
            {
                errMensaje = e.Message;
                flag = false;
            }
            finally
            {
                conn.Close();
            }
            return flag;
        }
    }
}
