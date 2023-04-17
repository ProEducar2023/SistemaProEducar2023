using System;
using System.Data;
using System.Data.SqlClient;
using static System.Data.CommandType;

namespace DAL
{
    public class ReportesDAL
    {
        SqlConnection con;
        public ReportesDAL()
        {
            con = new SqlConnection(conexion.con);
        }

        public DataTable RptEfectividadComparativa(string codPrograma, string codPtoCob, string codDepartemento, string codInstitucion, 
             string codPais, DateTime fechaInicio, DateTime fechaFin)
        {
            const string procedure = "dsp_ReporteEfectividadComparativa";
            try
            {
                SqlCommand cmd = new SqlCommand(procedure, con)
                {
                    CommandType = StoredProcedure
                };

                _ = cmd.Parameters.AddWithValue("@COD_PROGRAMA", codPrograma);
                _ = cmd.Parameters.AddWithValue("@COD_PTO_COB", codPtoCob);
                _ = cmd.Parameters.AddWithValue("@COD_DEPARTAMENTO", codDepartemento);
                _ = cmd.Parameters.AddWithValue("@COD_INSTITUCION", codInstitucion);
                _ = cmd.Parameters.AddWithValue("@FECHA_INICIO", fechaInicio);
                _ = cmd.Parameters.AddWithValue("@FECHA_FIN", fechaFin);
                _ = cmd.Parameters.AddWithValue("@COD_PAIS", codPais);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr, LoadOption.Upsert);
                dr.Close();
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public DataTable RptEfectividadComparativaGenEnv(string codPrograma, string codPtoCob, string codDepartemento, string codInstitucion,
            string codPais, DateTime fechaInicio, DateTime fechaFin)
        {
            const string procedure = "dsp_ReporteEfectividadComparativaPllaEnvGen";
            try
            {
                SqlCommand cmd = new SqlCommand(procedure, con)
                {
                    CommandType = StoredProcedure
                };

                _ = cmd.Parameters.AddWithValue("@COD_PROGRAMA", codPrograma);
                _ = cmd.Parameters.AddWithValue("@COD_PTO_COB", codPtoCob);
                _ = cmd.Parameters.AddWithValue("@COD_DEPARTAMENTO", codDepartemento);
                _ = cmd.Parameters.AddWithValue("@COD_INSTITUCION", codInstitucion);
                _ = cmd.Parameters.AddWithValue("@FECHA_INICIO", fechaInicio);
                _ = cmd.Parameters.AddWithValue("@FECHA_FIN", fechaFin);
                _ = cmd.Parameters.AddWithValue("@COD_PAIS", codPais);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr, LoadOption.Upsert);
                dr.Close();
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public DataTable RptEfectividadComparativaGenEnv2(string codPrograma, string codPtoCob, string codDepartemento, string codInstitucion,
            string codPais, DateTime fechaInicio, DateTime fechaFin)
        {
            const string procedure = "dsp_ReporteEfectividadComparativaPllaEnvGen2";
            try
            {
                SqlCommand cmd = new SqlCommand(procedure, con)
                {
                    CommandType = StoredProcedure
                };

                _ = cmd.Parameters.AddWithValue("@COD_PROGRAMA", codPrograma);
                _ = cmd.Parameters.AddWithValue("@COD_PTO_COB", codPtoCob);
                _ = cmd.Parameters.AddWithValue("@COD_DEPARTAMENTO", codDepartemento);
                _ = cmd.Parameters.AddWithValue("@COD_INSTITUCION", codInstitucion);
                _ = cmd.Parameters.AddWithValue("@FECHA_INICIO", fechaInicio);
                _ = cmd.Parameters.AddWithValue("@FECHA_FIN", fechaFin);
                _ = cmd.Parameters.AddWithValue("@COD_PAIS", codPais);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr, LoadOption.Upsert);
                dr.Close();
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }
    }
}
