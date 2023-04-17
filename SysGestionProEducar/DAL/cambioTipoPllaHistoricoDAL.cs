using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace DAL
{
    public class cambioTipoPllaHistoricoDAL
    {
        SqlConnection conn;
        public cambioTipoPllaHistoricoDAL()
        {
            conn = new SqlConnection(conexion.con);
        }

        private const int TIME_OUT_RPTCARTERA = 2000;

        public DataTable obtenerCambioTipoPllaHistoricoDAL(cambioTipoPllaHistoricoTo ctpTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_CAMBIO_TIPO_PLANILLA_HISTORICO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", ctpTo.NRO_CONTRATO);
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

        public DataTable Institucion()
        {

            SqlDataAdapter da = new SqlDataAdapter("Select * from INSTITUCIONES", conn);
            DataTable tb = new DataTable();
            da.Fill(tb);
            DataRow rw = tb.NewRow();
            rw["COD_INST"] = "00";
            rw["DESC_INST"] = "Todos";
            tb.Rows.InsertAt(rw, 0);
            return tb;
        }

        public DataTable planillaCancel()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select*from TIPOS_PLANILLA_CREACION where COD_TIPO_PLLA  in ('PP','PV','PD','PE','DM','DE','DX', 'DR') ", conn);
            DataTable tb = new DataTable();
            da.Fill(tb);

            DataRow rw = tb.NewRow();
            rw["COD_TIPO_PLLA"] = "0";
            rw["DESC_TIPO"] = "Todos";
            tb.Rows.InsertAt(rw, 0);

            return tb;
        }

        public DataTable ObtenerPersonaXInstitucion(string codInst)
        {
            const string select = "SELECT  B.COD_INST, ISNULL(B.DESC_INST, 'Sin Código')[DESC_INST], COUNT(*)[CANT] " +
                "FROM MAESTRO_PERSONAS A " +
                "LEFT JOIN INSTITUCIONES B ON A.COD_INSTITUCION = B.COD_INST where COD_INSTITUCION = @COD_INST OR @COD_INST = '00'" +
                "GROUP BY B.COD_INST, B.DESC_INST";
            try
            {
                SqlCommand cmd = new SqlCommand(select, conn)

                {
                    CommandType = CommandType.Text
                };

                _ = cmd.Parameters.AddWithValue("@COD_INST", codInst);

                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr, LoadOption.OverwriteChanges);
                dr.Close();
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public DataTable ObtenerPersonasSinCodiga()
        {
            const string select = "SELECT A.COD_PER, A.NOMBRE, A.PATERNO, A.MATERNO, A.COD_TIPO_DOC, A.NRO_DOC " +
                "FROM MAESTRO_PERSONAS A " +
                "LEFT JOIN INSTITUCIONES B ON A.COD_INSTITUCION=B.COD_INST " +
                "where b.COD_INST IS NULL";
            try
            {
                SqlCommand cmd = new SqlCommand(select, conn)

                {
                    CommandType = CommandType.Text
                };

                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr, LoadOption.OverwriteChanges);
                dr.Close();
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public DataTable Programas()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select*from PROGRAMA", conn);
            DataTable tb = new DataTable();
            da.Fill(tb);
            return tb;
        }

        public DataTable planillatipo(bool estado)
        {
            string query;
            if (estado)
                query = "Select * from TIPOS_PLANILLA_CREACION where COD_TIPO_PLLA  in ('PP','PD','PV')";
            else
                query = "Select * from TIPOS_PLANILLA_CREACION where COD_TIPO_PLLA  in ('PE','DM','DE','DX', 'DR')";

            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataTable tb = new DataTable();
            da.Fill(tb);

            DataRow rw = tb.NewRow();
            rw["COD_TIPO_PLLA"] = "0";
            rw["DESC_TIPO"] = "Todos";
            tb.Rows.InsertAt(rw, 0);

            return tb;
        }

        public DataTable RptMovimientosXUbicacion(DateTime fechaAprobIni, DateTime fechaAproFin, DateTime fechaCobraIni, DateTime fechaCobraFin,
        string codPrograma, string tipoUbicacion, string codGrupoUbicacion, string codSubUbicacion)
        {
            const string procedure = "dsp_RptCarteraContratosMovXUbicacion";
            try
            {
                SqlCommand cmd = new SqlCommand(procedure, conn)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = TIME_OUT_RPTCARTERA
                };

                cmd.Parameters.AddWithValue("@FECHA_APROBACION_INI", fechaAprobIni);
                cmd.Parameters.AddWithValue("@FECHA_APROBACION_FIN", fechaAproFin);
                cmd.Parameters.AddWithValue("@FECHA_COBRANZA_INI", fechaCobraIni);
                cmd.Parameters.AddWithValue("@FECHA_COBRANZA_FIN", fechaCobraFin);
                cmd.Parameters.AddWithValue("@TIPO_UBICACION", tipoUbicacion);
                cmd.Parameters.AddWithValue("@COD_PROGRAMA", codPrograma);
                cmd.Parameters.AddWithValue("@COD_GRUPO_UBICACION", codGrupoUbicacion);
                cmd.Parameters.AddWithValue("@COD_SUB_UBICACION", codSubUbicacion);

                conn.Open();
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
                conn.Close();
            }
        }

        public DataTable RptMovimientoCarteraComparativoMes(DateTime fechaAprobIni, DateTime fechaAproFin, DateTime fechaCobraIni, DateTime fechaCobraFin,
        string codPrograma, string tipoUbicacion, string codGrupoUbicacion, string codSubUbicacion)
        {
            string procedure;
            switch (tipoUbicacion)
            {
                case "PD":
                    procedure = "usp_MovimientoCarteraUbicacionComparativoDir";
                    break;
                default:
                    procedure = "usp_MovimientoCarteraUbicacionComparativo";
                    break;
            }

            try
            {
                SqlCommand cmd = new SqlCommand(procedure, conn)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = TIME_OUT_RPTCARTERA
                };

                cmd.Parameters.AddWithValue("@FECHA_APROBACION_INI", fechaAprobIni);
                cmd.Parameters.AddWithValue("@FECHA_APROBACION_FIN", fechaAproFin);
                cmd.Parameters.AddWithValue("@FECHA_COBRANZA_INI", fechaCobraIni);
                cmd.Parameters.AddWithValue("@FECHA_COBRANZA_FIN", fechaCobraFin);
                cmd.Parameters.AddWithValue("@TIPO_UBICACION", tipoUbicacion);
                cmd.Parameters.AddWithValue("@COD_PROGRAMA", codPrograma);
                cmd.Parameters.AddWithValue("@COD_GRUPO_UBICACION", codGrupoUbicacion);
                cmd.Parameters.AddWithValue("@COD_SUB_UBICACION", codSubUbicacion);

                conn.Open();
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
                conn.Close();
            }
        }

        public DataTable RptCobrazaUbicacionDetalleDir(CancellationToken cancelToken, DateTime fechaAproIni, DateTime fechaAproFin, DateTime fechaCobraIni,
        DateTime fechaCobraFin, string codUbicacion, string codPrograma, string codGrupoUbicacion, string codSubUbicacion)
        {
            const string procedure = "dsp_RptCarteraContratosDirecta";
            SqlCommand cmd = new SqlCommand(procedure, conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.CommandTimeout = TIME_OUT_RPTCARTERA;

            cmd.Parameters.AddWithValue("@FECHA_APROBACION_INI", fechaAproIni);
            cmd.Parameters.AddWithValue("@FECHA_APROBACION_FIN", fechaAproFin);
            cmd.Parameters.AddWithValue("@FECHA_COBRANZA_INI", fechaCobraIni);
            cmd.Parameters.AddWithValue("@FECHA_COBRANZA_FIN", fechaCobraFin);
            cmd.Parameters.AddWithValue("@TIPO_UBICACION", codUbicacion);
            cmd.Parameters.AddWithValue("@COD_PROGRAMA", codPrograma);
            cmd.Parameters.AddWithValue("@COD_GRUPO_UBICACION", codGrupoUbicacion);
            cmd.Parameters.AddWithValue("@COD_SUB_UBICACION", codSubUbicacion);

            try
            {
                conn.Open();
                Task<SqlDataReader> drAsync = cmd.ExecuteReaderAsync(cancelToken);
                SqlDataReader dr = drAsync.Result;
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
                conn.Close();
            }
        }

        public DataTable RptCobrazaUbicacionDetalle(CancellationToken cancelToken, DateTime fechaAproIni, DateTime fechaAproFin, DateTime fechaCobraIni,
                DateTime fechaCobraFin, string codUbicacion, string codPrograma, string codGrupoUbicacion, string codSubUbicacion)
        {
            const string procedure = "dsp_RptCarteraContratos";
            SqlCommand cmd = new SqlCommand(procedure, conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.CommandTimeout = TIME_OUT_RPTCARTERA;
            cmd.Parameters.AddWithValue("@FECHA_APROBACION_INI", fechaAproIni);
            cmd.Parameters.AddWithValue("@FECHA_APROBACION_FIN", fechaAproFin);
            cmd.Parameters.AddWithValue("@FECHA_COBRANZA_INI", fechaCobraIni);
            cmd.Parameters.AddWithValue("@FECHA_COBRANZA_FIN", fechaCobraFin);
            cmd.Parameters.AddWithValue("@TIPO_UBICACION", codUbicacion);
            cmd.Parameters.AddWithValue("@COD_PROGRAMA", codPrograma);
            cmd.Parameters.AddWithValue("@COD_GRUPO_UBICACION", codGrupoUbicacion);
            cmd.Parameters.AddWithValue("@COD_SUB_UBICACION", codSubUbicacion);

            try
            {
                conn.Open();
                Task<SqlDataReader> drAsync = cmd.ExecuteReaderAsync(cancelToken);
                SqlDataReader dr = drAsync.Result;
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
                conn.Close();
            }
        }

        public DataTable RptMovimientosXUbicacion2(DateTime fechaAprobIni, DateTime fechaAproFin, DateTime fechaCobraIni, DateTime fechaCobraFin,
            string codPrograma, string tipoUbicacion, string codGrupoUbicacion, string codSubUbicacion)
        {
            const string procedure = "dsp_RptCarteraContratosMovXUbicacion2";
            try
            {
                SqlCommand cmd = new SqlCommand(procedure, conn)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = TIME_OUT_RPTCARTERA
                };

                cmd.Parameters.AddWithValue("@FECHA_APROBACION_INI", fechaAprobIni);
                cmd.Parameters.AddWithValue("@FECHA_APROBACION_FIN", fechaAproFin);
                cmd.Parameters.AddWithValue("@FECHA_COBRANZA_INI", fechaCobraIni);
                cmd.Parameters.AddWithValue("@FECHA_COBRANZA_FIN", fechaCobraFin);
                cmd.Parameters.AddWithValue("@TIPO_UBICACION", tipoUbicacion);
                cmd.Parameters.AddWithValue("@COD_PROGRAMA", codPrograma);
                cmd.Parameters.AddWithValue("@COD_GRUPO_UBICACION", codGrupoUbicacion);
                cmd.Parameters.AddWithValue("@COD_SUB_UBICACION", codSubUbicacion);

                conn.Open();
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
                conn.Close();
            }
        }

        public DataTable RptMovimientoXUbicacionDirecta2(DateTime fechaAprobIni, DateTime fechaAproFin, DateTime fechaCobraIni, DateTime fechaCobraFin,
        string codPrograma, string tipoUbicacion, string codGrupoUbicacion, string codSubUbicacion)
        {
            const string procedure = "dsp_RptCarteraContratosDirectaMovXUbicacion2";
            try
            {
                SqlCommand cmd = new SqlCommand(procedure, conn)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = TIME_OUT_RPTCARTERA
                };

                cmd.Parameters.AddWithValue("@FECHA_APROBACION_INI", fechaAprobIni);
                cmd.Parameters.AddWithValue("@FECHA_APROBACION_FIN", fechaAproFin);
                cmd.Parameters.AddWithValue("@FECHA_COBRANZA_INI", fechaCobraIni);
                cmd.Parameters.AddWithValue("@FECHA_COBRANZA_FIN", fechaCobraFin);
                cmd.Parameters.AddWithValue("@TIPO_UBICACION", tipoUbicacion);
                cmd.Parameters.AddWithValue("@COD_PROGRAMA", codPrograma);
                cmd.Parameters.AddWithValue("@COD_GRUPO_UBICACION", codGrupoUbicacion);
                cmd.Parameters.AddWithValue("@COD_SUB_UBICACION", codSubUbicacion);

                conn.Open();
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
                conn.Close();
            }
        }

        public DataTable RptMovimientoXUbicacionDirecta(DateTime fechaAprobIni, DateTime fechaAproFin, DateTime fechaCobraIni, DateTime fechaCobraFin,
                string codPrograma, string tipoUbicacion, string codGrupoUbicacion, string codSubUbicacion)
        {
            const string procedure = "dsp_RptCarteraContratosDirectaMovXUbicacion";
            try
            {
                SqlCommand cmd = new SqlCommand(procedure, conn)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = TIME_OUT_RPTCARTERA
                };

                cmd.Parameters.AddWithValue("@FECHA_APROBACION_INI", fechaAprobIni);
                cmd.Parameters.AddWithValue("@FECHA_APROBACION_FIN", fechaAproFin);
                cmd.Parameters.AddWithValue("@FECHA_COBRANZA_INI", fechaCobraIni);
                cmd.Parameters.AddWithValue("@FECHA_COBRANZA_FIN", fechaCobraFin);
                cmd.Parameters.AddWithValue("@TIPO_UBICACION", tipoUbicacion);
                cmd.Parameters.AddWithValue("@COD_PROGRAMA", codPrograma);
                cmd.Parameters.AddWithValue("@COD_GRUPO_UBICACION", codGrupoUbicacion);
                cmd.Parameters.AddWithValue("@COD_SUB_UBICACION", codSubUbicacion);

                conn.Open();
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
                conn.Close();
            }
        }

        public DataTable ObtenerPlanilla(string PROGRAMAS, DateTime FECHA_INI, DateTime FECHA_FIN, string TIPO_PLANILLA)
        {
            string select;
            try
            {
                if (TIPO_PLANILLA == "0")
                    select = "planilla_todos";

                else if (TIPO_PLANILLA == "PP")
                    select = "PLANILLA_DESCUENTO_2021";
                else if (TIPO_PLANILLA == "PV")
                    select = "dsp_RptPlanillaVisaDet_2021";
                else
                    select = "PLANILLA_DIRECTA_2021";

                SqlCommand cmd = new SqlCommand(select, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                _ = cmd.Parameters.AddWithValue("@PROGRAMAS", PROGRAMAS);
                _ = cmd.Parameters.AddWithValue("@FECHA_INI", FECHA_INI);
                _ = cmd.Parameters.AddWithValue("@FECHA_FIN", FECHA_FIN);
                _ = cmd.Parameters.AddWithValue("@TIPO_PLANILLA", TIPO_PLANILLA);

                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr, LoadOption.OverwriteChanges);
                dr.Close();
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public DataTable ObtenerReportesContratos(string NRO_PLANILLA, string TIPO_PLANILLA, string PROGRAMAS)
        {
            const string select = "PLANILLA_DESCUENTO_CONTRATOS";
            try
            {
                SqlCommand cmd = new SqlCommand(select, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                _ = cmd.Parameters.AddWithValue("@NRO_PLANILLA", NRO_PLANILLA);
                _ = cmd.Parameters.AddWithValue("@TIPO_PLANILLA", TIPO_PLANILLA);
                _ = cmd.Parameters.AddWithValue("@PROGRAMAS", PROGRAMAS);

                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr, LoadOption.OverwriteChanges);
                dr.Close();
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public DataTable ObtenerReportesContratosTodos(string NRO_PLANILLA, string TIPO_PLANILLA, string PROGRAMAS)
        {
            string select;

            if (TIPO_PLANILLA == "0" || TIPO_PLANILLA == "01")
                select = "";

            else if (TIPO_PLANILLA == "PP")
                select = "PLANILLA_DESCUENTO_CONTRATOS";
            else if (TIPO_PLANILLA == "PV")
                select = "PLANILLA_VISA_CONTRATOS";
            else
                select = "PLANILLA_DIRECTA_CONTRATOS";
            try
            {
                SqlCommand cmd = new SqlCommand(select, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                _ = cmd.Parameters.AddWithValue("@NRO_PLANILLA", NRO_PLANILLA);
                _ = cmd.Parameters.AddWithValue("@TIPO_PLANILLA", TIPO_PLANILLA);
                _ = cmd.Parameters.AddWithValue("@PROGRAMAS", PROGRAMAS);

                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr, LoadOption.OverwriteChanges);
                dr.Close();
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public DataTable ObtenerResumenXtipo(string PROGRAMAS, DateTime FECHA_INI, DateTime FECHA_FIN, string TIPO_PLANILLA)
        {
            const string select = "PLANILLA_2021_CAMBIO";
            try
            {
                SqlCommand cmd = new SqlCommand(select, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                _ = cmd.Parameters.AddWithValue("@PROGRAMAS", PROGRAMAS);
                _ = cmd.Parameters.AddWithValue("@FECHA_INI", FECHA_INI);
                _ = cmd.Parameters.AddWithValue("@FECHA_FIN", FECHA_FIN);
                _ = cmd.Parameters.AddWithValue("@TIPO_PLANILLA", TIPO_PLANILLA);

                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr, LoadOption.OverwriteChanges);
                dr.Close();
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public DataTable ObtenerGreedXtipo(string PROGRAMAS, DateTime FECHA_INI, DateTime FECHA_FIN, string TIPO_PLANILLA)
        {
            string select;
            try
            {
                if (TIPO_PLANILLA == "0" || TIPO_PLANILLA == "01")
                    select = "PLANILLA_TODOS_GREED";

                else if (TIPO_PLANILLA == "PP")
                    select = "PLANILLA_DESCUENTO_GREED_CAMBIO";
                else if (TIPO_PLANILLA == "PV")
                    select = "dsp_RptPlanillaVisaDet_Greed_CAMBIO";
                else
                    select = "PLANILLA_DIRECTA_GREED_CAMBIO";

                SqlCommand cmd = new SqlCommand(select, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                _ = cmd.Parameters.AddWithValue("@PROGRAMAS", PROGRAMAS);
                _ = cmd.Parameters.AddWithValue("@FECHA_INI", FECHA_INI);
                _ = cmd.Parameters.AddWithValue("@FECHA_FIN", FECHA_FIN);
                _ = cmd.Parameters.AddWithValue("@TIPO_PLANILLA", TIPO_PLANILLA);

                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr, LoadOption.OverwriteChanges);
                dr.Close();
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public DataTable ObtenerPlanillaResumenXtipo(string PROGRAMAS, DateTime FECHA_INI, DateTime FECHA_FIN, string TIPO_PLANILLA)
        {
            string select;
            try
            {
                if (TIPO_PLANILLA == "0" || TIPO_PLANILLA == "01")
                    select = "PLANILLA_TODOS_CAMBIO";
                else if (TIPO_PLANILLA == "PP")
                    select = "PLANILLA_DESCUENTO_2021_CAMBIO";
                else if (TIPO_PLANILLA == "PV")
                    select = "dsp_RptPlanillaVisaDet_2021_CAMBIO";
                else
                    select = "PLANILLA_DIRECTA_2021_CAMBIO";

                SqlCommand cmd = new SqlCommand(select, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                _ = cmd.Parameters.AddWithValue("@PROGRAMAS", PROGRAMAS);
                _ = cmd.Parameters.AddWithValue("@FECHA_INI", FECHA_INI);
                _ = cmd.Parameters.AddWithValue("@FECHA_FIN", FECHA_FIN);
                _ = cmd.Parameters.AddWithValue("@TIPO_PLANILLA", TIPO_PLANILLA);

                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr, LoadOption.OverwriteChanges);
                dr.Close();
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public DataTable ObtenerResumen(string PROGRAMAS, DateTime FECHA_INI, DateTime FECHA_FIN, string TIPO_PLANILLA)
        {
            const string select = "PLANILLA_2021";
            try
            {
                SqlCommand cmd = new SqlCommand(select, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                _ = cmd.Parameters.AddWithValue("@PROGRAMAS", PROGRAMAS);
                _ = cmd.Parameters.AddWithValue("@FECHA_INI", FECHA_INI);
                _ = cmd.Parameters.AddWithValue("@FECHA_FIN", FECHA_FIN);
                _ = cmd.Parameters.AddWithValue("@TIPO_PLANILLA", TIPO_PLANILLA);

                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr, LoadOption.OverwriteChanges);
                dr.Close();
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public string obtenerNroCambioTipoPllaHistoricoDAL(cambioTipoPllaHistoricoTo ctpTo)
        {
            string val = "";
            SqlCommand cmd = new SqlCommand("MOSTRAR_NRO_CAMBIO_TIPO_PLANILLA_HISTORICO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", ctpTo.NRO_CONTRATO);
            try
            {
                conn.Open();
                val = cmd.ExecuteScalar() == null ? "0" : cmd.ExecuteScalar().ToString();
            }
            catch (Exception)
            {
                val = "error";
            }
            finally
            {
                conn.Close();
            }
            return val;
        }
        public bool insertarCambioTipoPllaHistoricoDAL(cambioTipoPllaHistoricoTo ctpTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_CAMBIO_TIPO_PLANILLA_HISTORICO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", ctpTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@FECHA_CAMBIO", ctpTo.FECHA_CAMBIO);
            cmd.Parameters.AddWithValue("@TIPO_PLANILLA_CAMBIADA", ctpTo.TIPO_PLANILLA_CAMBIADA);
            cmd.Parameters.AddWithValue("@COD_MOTIVO", ctpTo.COD_MOTIVO);
            cmd.Parameters.AddWithValue("@COD_AUTORIZADOR", ctpTo.COD_AUTORIZADOR);
            cmd.Parameters.AddWithValue("@CUOTAS_CAMBIADAS", ctpTo.CUOTAS_CAMBIADAS);
            cmd.Parameters.AddWithValue("@OBSERVACIONES", ctpTo.OBSERVACIONES);
            cmd.Parameters.AddWithValue("@COD_CREAR", ctpTo.COD_CREAR);
            cmd.Parameters.AddWithValue("@FECHA_CREAR", ctpTo.FECHA_CREAR);
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
        public DataTable obtenerCambioUbicacionparaNroCambiosDAL(cambioTipoPllaHistoricoTo ctpTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_CAMBIO_UBICACION_PARA_NRO_CAMBIOS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FECHA_DESDE", ctpTo.FECHA_DESDE);
            cmd.Parameters.AddWithValue("@FECHA_HASTA", ctpTo.FECHA_HASTA);
            cmd.Parameters.AddWithValue("@COD_PTO_COB", ctpTo.COD_PTO_COB);
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
        public decimal obtenerSaldoxCobrarDAL(cambioTipoPllaHistoricoTo ctpTo)
        {
            decimal val = -1;
            SqlCommand cmd = new SqlCommand("MOSTRAR_SALDOxCOBRAR", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", ctpTo.NRO_CONTRATO);

            try
            {
                conn.Open();
                val = cmd.ExecuteScalar() == null ? 0 : Convert.ToDecimal(cmd.ExecuteScalar());
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
        public int obtenerNroCuotasPendientesDAL(cambioTipoPllaHistoricoTo ctpTo)
        {
            int val = -1;
            SqlCommand cmd = new SqlCommand("MOSTRAR_NUMERO_CUOTAS_PENDIENTES", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", ctpTo.NRO_CONTRATO);

            try
            {
                conn.Open();
                val = cmd.ExecuteScalar() == null ? 0 : Convert.ToInt32(cmd.ExecuteScalar());
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
        public DateTime? obtenerFechaUltCambioDAL(cambioTipoPllaHistoricoTo ctpTo)
        {
            DateTime? val = null;
            SqlCommand cmd = new SqlCommand("MOSTRAR_FECHA_ULT_CAMBIO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", ctpTo.NRO_CONTRATO);

            try
            {
                conn.Open();
                val = cmd.ExecuteScalar() == null ? (DateTime?)null : Convert.ToDateTime(cmd.ExecuteScalar());
            }
            catch (Exception)
            {
                val = null;
            }
            finally
            {
                conn.Close();
            }
            return val;
        }
        public int obtenerNroCambiosDAL(cambioTipoPllaHistoricoTo ctpTo)
        {
            int val = -1;
            SqlCommand cmd = new SqlCommand("MOSTRAR_NRO_CAMBIOS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", ctpTo.NRO_CONTRATO);

            try
            {
                conn.Open();
                val = cmd.ExecuteScalar() == null ? 0 : Convert.ToInt32(cmd.ExecuteScalar());
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

        public DataTable RptDetalladoXContratoFecIdenPago(string codPrograma, string codAreaTrabajo, string codGestor, DateTime fechaIdenIni, DateTime fechaIdenFin, bool incluyeSinFecha)
        {
            const string procedure = "dsp_RptContratosFecIdenPago";
            SqlCommand cmd = new SqlCommand(procedure, conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.CommandTimeout = 700;

            cmd.Parameters.AddWithValue("@COD_PROGRAMA", codPrograma);
            cmd.Parameters.AddWithValue("@COD_AREA_TRABAJO", codAreaTrabajo);
            cmd.Parameters.AddWithValue("@COD_GESTOR", codGestor);
            cmd.Parameters.AddWithValue("@FECHA_IDEN_INI", fechaIdenIni);
            cmd.Parameters.AddWithValue("@FECHA_IDEN_FIN", fechaIdenFin);
            cmd.Parameters.AddWithValue("@INCLUIR_SIN_FECHA", incluyeSinFecha);

            try
            {
                conn.Open();
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
                conn.Close();
            }
        }


        public DataTable ObtenerPlanilla_J(string PROGRAMAS, DateTime FECHA_INI, DateTime FECHA_FIN, string TIPO_PLANILLA)
        {
            string select;
            try
            {
                if (TIPO_PLANILLA == "0" || TIPO_PLANILLA == "01")
                    select = "PLANILLA_TODOS_CAMBIO";
                else if (TIPO_PLANILLA == "PP")
                    select = "PLANILLA_DESCUENTO_2021_CAMBIO_J";
                else if (TIPO_PLANILLA == "PV")
                    select = "dsp_RptPlanillaVisaDet_2021_CAMBIO";
                else
                    select = "PLANILLA_DIRECTA_2021_CAMBIO_J";

                SqlCommand cmd = new SqlCommand(select, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                _ = cmd.Parameters.AddWithValue("@PROGRAMAS", PROGRAMAS);
                _ = cmd.Parameters.AddWithValue("@FECHA_INI", FECHA_INI);
                _ = cmd.Parameters.AddWithValue("@FECHA_FIN", FECHA_FIN);
                _ = cmd.Parameters.AddWithValue("@TIPO_PLANILLA", TIPO_PLANILLA);

                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr, LoadOption.OverwriteChanges);
                dr.Close();
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }
        public DataTable MOSTRAR_REPORTE_PROYECCION_COBRANZA_DAL(cambioTipoPllaHistoricoTo ctpTo)
        {
            string errMensaje = "";
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_REPORTE_PROYECCION_COBRANZA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 1200;
            if (ctpTo.COD_PROGRAMA == null)
                cmd.Parameters.AddWithValue("@COD_PROGRAMA", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@COD_PROGRAMA", ctpTo.COD_PROGRAMA);
            cmd.Parameters.AddWithValue("@FECHA_APROB_DESDE", ctpTo.FECHA_APROB_DESDE);
            cmd.Parameters.AddWithValue("@FECHA_APROB_HASTA", ctpTo.FECHA_APROB_HASTA);
            cmd.Parameters.AddWithValue("@PER_PROY_DESDE", ctpTo.PERIODO_DESDE);
            cmd.Parameters.AddWithValue("@PER_PROY_HASTA", ctpTo.PERIODO_HASTA);
            if (ctpTo.COD_UBICACION == null)
                cmd.Parameters.AddWithValue("@COD_UBICACION", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@COD_UBICACION", ctpTo.COD_UBICACION);
            if (ctpTo.COD_GRUPO_UBICACION == null)
                cmd.Parameters.AddWithValue("@COD_GRUPO_UBICACION", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@COD_GRUPO_UBICACION", ctpTo.COD_GRUPO_UBICACION);
            if (ctpTo.COD_SUB_UBICACION == null)
                cmd.Parameters.AddWithValue("@COD_SUB_UBICACION", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@COD_SUB_UBICACION", ctpTo.COD_SUB_UBICACION);
            cmd.Parameters.AddWithValue("@FEC_REPORTE", ctpTo.FECHA_ORIGEN);
            cmd.Parameters.AddWithValue("@OP_SUSPENDIDOS", ctpTo.OP1);
            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr, LoadOption.Upsert);
                dr.Close();
            }
            catch (Exception e)
            {
                errMensaje = e.Message;
                dt = null;
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }
        public DataTable MOSTRAR_REPORTE_PROYECCION_COBRANZA_RESUMEN_DAL(cambioTipoPllaHistoricoTo ctpTo)
        {
            string errMensaje = "";
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_REPORTE_PROYECCION_COBRANZA_RESUMEN", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 600;
            if (ctpTo.COD_PROGRAMA == null)
                cmd.Parameters.AddWithValue("@COD_PROGRAMA", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@COD_PROGRAMA", ctpTo.COD_PROGRAMA);
            cmd.Parameters.AddWithValue("@FECHA_APROB_DESDE", ctpTo.FECHA_APROB_DESDE);
            cmd.Parameters.AddWithValue("@FECHA_APROB_HASTA", ctpTo.FECHA_APROB_HASTA);
            cmd.Parameters.AddWithValue("@PER_PROY_DESDE", ctpTo.PERIODO_DESDE);
            cmd.Parameters.AddWithValue("@PER_PROY_HASTA", ctpTo.PERIODO_HASTA);
            if (ctpTo.COD_UBICACION == null)
                cmd.Parameters.AddWithValue("@COD_UBICACION", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@COD_UBICACION", ctpTo.COD_UBICACION);
            if (ctpTo.COD_GRUPO_UBICACION == null)
                cmd.Parameters.AddWithValue("@COD_GRUPO_UBICACION", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@COD_GRUPO_UBICACION", ctpTo.COD_GRUPO_UBICACION);
            if (ctpTo.COD_SUB_UBICACION == null)
                cmd.Parameters.AddWithValue("@COD_SUB_UBICACION", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@COD_SUB_UBICACION", ctpTo.COD_SUB_UBICACION);
            cmd.Parameters.AddWithValue("@FEC_REPORTE", ctpTo.FECHA_ORIGEN);
            cmd.Parameters.AddWithValue("@OP_SUSPENDIDOS", ctpTo.OP1);
            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr, LoadOption.Upsert);
                dr.Close();
            }
            catch (Exception e)
            {
                errMensaje = e.Message;
                dt = null;
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }
        public DataTable MOSTRAR_REPORTE_PROYECCION_COBRANZA_RESUMEN_PUNTO_COBRANZA_DAL(cambioTipoPllaHistoricoTo ctpTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_REPORTE_PROYECCION_COBRANZA_RESUMEN_PUNTO_COBRANZA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 600;
            if (ctpTo.COD_PROGRAMA == null)
                cmd.Parameters.AddWithValue("@COD_PROGRAMA", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@COD_PROGRAMA", ctpTo.COD_PROGRAMA);
            cmd.Parameters.AddWithValue("@FECHA_APROB_DESDE", ctpTo.FECHA_APROB_DESDE);
            cmd.Parameters.AddWithValue("@FECHA_APROB_HASTA", ctpTo.FECHA_APROB_HASTA);
            cmd.Parameters.AddWithValue("@PER_PROY_DESDE", ctpTo.PERIODO_DESDE);
            cmd.Parameters.AddWithValue("@PER_PROY_HASTA", ctpTo.PERIODO_HASTA);
            if (ctpTo.COD_PTO_COB == null)
                cmd.Parameters.AddWithValue("@COD_PTO_COB", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@COD_PTO_COB", ctpTo.COD_PTO_COB);
            cmd.Parameters.AddWithValue("@FEC_REPORTE", ctpTo.FECHA_ORIGEN);
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
        public DataTable CARTERA_TOTAL_PROYECTADA_X_PUNTO_COBRANZA_DAL(cambioTipoPllaHistoricoTo ctpTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("CARTERA_TOTAL_PROYECTADA_X_PUNTO_COBRANZA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 600;
            if (ctpTo.COD_PROGRAMA == null)
                cmd.Parameters.AddWithValue("@COD_PROGRAMA", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@COD_PROGRAMA", ctpTo.COD_PROGRAMA);
            cmd.Parameters.AddWithValue("@FECHA_APROB_DESDE", ctpTo.FECHA_APROB_DESDE);
            cmd.Parameters.AddWithValue("@FECHA_APROB_HASTA", ctpTo.FECHA_APROB_HASTA);
            cmd.Parameters.AddWithValue("@PER_PROY_DESDE", ctpTo.PERIODO_DESDE);
            cmd.Parameters.AddWithValue("@PER_PROY_HASTA", ctpTo.PERIODO_HASTA);
            if (ctpTo.COD_PTO_COB == null)
                cmd.Parameters.AddWithValue("@COD_PTO_COB", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@COD_PTO_COB", ctpTo.COD_PTO_COB);
            if (ctpTo.COD_UBICACION == null)
                cmd.Parameters.AddWithValue("@COD_UBICACION", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@COD_UBICACION", ctpTo.COD_UBICACION);
            if (ctpTo.COD_GRUPO_UBICACION == null)
                cmd.Parameters.AddWithValue("@COD_GRUPO_UBICACION", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@COD_GRUPO_UBICACION", ctpTo.COD_GRUPO_UBICACION);
            if (ctpTo.COD_SUB_UBICACION == null)
                cmd.Parameters.AddWithValue("@COD_SUB_UBICACION", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@COD_SUB_UBICACION", ctpTo.COD_SUB_UBICACION);
            cmd.Parameters.AddWithValue("@OP_SUSPENDIDOS", ctpTo.OP1);
            cmd.Parameters.AddWithValue("@FEC_REPORTE", ctpTo.FECHA_ORIGEN);
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
