using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class personaIndebidaDAL
    {
        SqlConnection conn;
        public personaIndebidaDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerPersonaIndebidaDAL(personaIndebidaTo pibTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_PERSONA_INDEBIDA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_PLANILLA_COB", pibTo.NRO_PLANILLA_COB);
            cmd.Parameters.AddWithValue("@COD_INSTITUCION", pibTo.COD_INSTITUCION);
            cmd.Parameters.AddWithValue("@COD_PTO_COB_CONSOLIDADO", pibTo.COD_PTO_COB_CONSOLIDADO);
            cmd.Parameters.AddWithValue("@COD_CANAL_DSCTO", pibTo.COD_CANAL_DSCTO);
            cmd.Parameters.AddWithValue("@FE_AÑO", pibTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", pibTo.FE_MES);
            cmd.Parameters.AddWithValue("@DESC_PER", pibTo.DESC_PER);
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
    }
}
