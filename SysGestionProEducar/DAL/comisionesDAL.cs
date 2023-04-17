using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class comisionesDAL
    {
        SqlConnection conn;
        public comisionesDAL()
        {
            conn = new SqlConnection(conexion.con);
        }

        private const int TIME_OUT_2 = 2000;
        private const int TIME_OUT_4 = 4000;

        public DataTable obtenerComisionesDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_MANTENIMIENTO_COMISIONES", conn);
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
        public bool insertarComisionesDAL(comisionesTo comTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_MAESTRO_COMISIONES", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TIPO", comTo.TIPO);
            cmd.Parameters.AddWithValue("@COD_PROGRAMA", comTo.COD_PROGRAMA);
            cmd.Parameters.AddWithValue("@COD_PER", comTo.COD_PER);
            cmd.Parameters.AddWithValue("@COD_INSTITUCION", comTo.COD_INSTITUCION);
            cmd.Parameters.AddWithValue("@COD_NIVEL_INSTITUCION", comTo.COD_NIVEL_INSTITUCION);
            cmd.Parameters.AddWithValue("@NOM_PER", comTo.NOM_PER);
            cmd.Parameters.AddWithValue("@FECHA", comTo.FECHA);
            cmd.Parameters.AddWithValue("@MONTO_PROPIO", comTo.MONTO_PROPIO);
            cmd.Parameters.AddWithValue("@MONTO_TERCEROS", comTo.MONTO_TERCEROS);
            cmd.Parameters.AddWithValue("@COD_CREA", comTo.COD_CREA);
            cmd.Parameters.AddWithValue("@FECHA_CREA", comTo.FECHA_CREA);
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
        public bool modificarComisionesDAL(comisionesTo comTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_MAESTRO_COMISIONES", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TIPO", comTo.TIPO);
            cmd.Parameters.AddWithValue("@COD_PROGRAMA", comTo.COD_PROGRAMA);
            cmd.Parameters.AddWithValue("@COD_PER", comTo.COD_PER);
            cmd.Parameters.AddWithValue("@COD_INSTITUCION", comTo.COD_INSTITUCION);
            cmd.Parameters.AddWithValue("@COD_NIVEL_INSTITUCION", comTo.COD_NIVEL_INSTITUCION);
            cmd.Parameters.AddWithValue("@MONTO_PROPIO", comTo.MONTO_PROPIO);
            cmd.Parameters.AddWithValue("@MONTO_TERCEROS", comTo.MONTO_TERCEROS);
            cmd.Parameters.AddWithValue("@COD_MOD", comTo.COD_MOD);
            cmd.Parameters.AddWithValue("@FECHA_MOD", comTo.FECHA_MOD);
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

        public bool eliminarComisionesDAL(comisionesTo comTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_MAESTRO_COMISIONES", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TIPO", comTo.TIPO);
            cmd.Parameters.AddWithValue("@COD_PROGRAMA", comTo.COD_PROGRAMA);
            cmd.Parameters.AddWithValue("@COD_PER", comTo.COD_PER);
            cmd.Parameters.AddWithValue("@COD_INSTITUCION", comTo.COD_INSTITUCION);
            cmd.Parameters.AddWithValue("@COD_NIVEL_INSTITUCION", comTo.COD_NIVEL_INSTITUCION);
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
        public DataTable obtenerComisionistasparaConsultaDAL(comisionesTo comTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_COMISIONISTAS_PARA_CONSULTA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TIPO_VTA", comTo.TIPO);
            cmd.Parameters.AddWithValue("@COD_PROGRAMA", comTo.COD_PROGRAMA);
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

        public DataTable ListarComisiones(string codDirNacional, string codDirVentas, string codSupervisor, string codNivelMostrar, string codPerMostrar,
            string codTipoPlanilla)
        {
            const string procedure = "dsp_ListarComisiones"; // dsp_ListarComisiones";
            try
            {
                SqlCommand cmd = new SqlCommand(procedure, conn)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 4000
                };

                _ = cmd.Parameters.AddWithValue("@COD_DIR_NACIONAL", codDirNacional);
                _ = cmd.Parameters.AddWithValue("@COD_DIR_VNTAS", codDirVentas);
                _ = cmd.Parameters.AddWithValue("@COD_SUPERVISOR", codSupervisor);
                _ = cmd.Parameters.AddWithValue("@COD_NIVEL_MOSTRAR", codNivelMostrar);
                _ = cmd.Parameters.AddWithValue("@COD_PER_MOSTRAR", codPerMostrar);
                _ = cmd.Parameters.AddWithValue("@COD_TIPO_PLANILLA", codTipoPlanilla);

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
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        public DataTable ListarTipoComision()
        {
            const string function = "SELECT * FROM TIPO_COMISION";
            try
            {
                SqlCommand cmd = new SqlCommand(function, conn)
                {
                    CommandType = CommandType.Text
                };

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
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        public bool GrabarComision(ComisionTo comTo)
        {
            try
            {
                conn.Open();
                using (SqlTransaction tr = conn.BeginTransaction())
                {
                    if (!InsertarComision(tr, comTo))
                    {
                        tr.Rollback();
                        return false;
                    }
                    if (!InsertarComisionOtrasFechas(tr, comTo))
                    {
                        tr.Rollback();
                        return false;
                    }
                    if (!InsertarComisionOtros(tr, comTo))
                    {
                        tr.Rollback();
                        return false;
                    }

                    tr.Commit();
                }
                return true;
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

        private bool InsertarComision(SqlTransaction tr, ComisionTo comTo)
        {
            const string procedure = "dps_InsertarComision";
            try
            {
                foreach (personaTo item in comTo.LstMaestroPersonaTo)
                {
                    foreach (tipoPlanillaCreacionTo item2 in comTo.LstTipoPlanillaTo)
                    {
                        SqlCommand cmd = new SqlCommand(procedure, conn, tr)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        _ = cmd.Parameters.AddWithValue("@COD_PER", item.COD_PER);
                        _ = cmd.Parameters.AddWithValue("@COD_NIVEL", comTo.NivelTo.COD_NIVEL);
                        _ = cmd.Parameters.AddWithValue("@NRO_CUOTA", comTo.NroCuota);
                        _ = cmd.Parameters.AddWithValue("@FECHA_INI_VIGENCIA", comTo.FechaIniVigencia);
                        _ = cmd.Parameters.AddWithValue("@FECHA_FIN_VIGENCIA", comTo.FechaFinVigencia);
                        _ = cmd.Parameters.AddWithValue("@IMPORTE", comTo.Importe);
                        _ = cmd.Parameters.AddWithValue("@PORCENTAJE", comTo.Porcentaje);
                        _ = cmd.Parameters.AddWithValue("@BASE_IMPONIBLE", comTo.BaseImponible);
                        _ = cmd.Parameters.AddWithValue("@CODIGO", item2.CODIGO);
                        _ = cmd.Parameters.AddWithValue("@COD_TIPO_PLLA", item2.COD_TIPO_PLLA);
                        _ = cmd.Parameters.AddWithValue("@ID_TIPO_COMISION", comTo.TipoComisionTo.IdTipoComision);
                        _ = cmd.Parameters.AddWithValue("@USUARIO_CREA", comTo.UsuarioCrea);

                        if (cmd.ExecuteNonQuery() <= 0)
                            return false;
                    }
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool InsertarComisionOtrasFechas(SqlTransaction tr, ComisionTo comTo)
        {
            const string procedure = "dps_InsertarComision";
            try
            {
                DataTable dtFechasApertura = ObtenerFechaAperturaComision(tr, comTo);
                if (dtFechasApertura != null)
                {
                    foreach (DataRow row in dtFechasApertura.Rows)
                    {
                        if (!string.IsNullOrEmpty(row["COD_PER"].ToString()))
                        {
                            foreach (tipoPlanillaCreacionTo item2 in comTo.LstTipoPlanillaTo)
                            {
                                SqlCommand cmd = new SqlCommand(procedure, conn, tr)
                                {
                                    CommandType = CommandType.StoredProcedure
                                };

                                _ = cmd.Parameters.AddWithValue("@COD_PER", row["COD_PER"]);
                                _ = cmd.Parameters.AddWithValue("@COD_NIVEL", comTo.NivelTo.COD_NIVEL);
                                _ = cmd.Parameters.AddWithValue("@NRO_CUOTA", comTo.NroCuota);
                                _ = cmd.Parameters.AddWithValue("@FECHA_INI_VIGENCIA", row["FECHA_INI_VIGENCIA"]);
                                _ = cmd.Parameters.AddWithValue("@FECHA_FIN_VIGENCIA", comTo.FechaFinVigencia);
                                _ = cmd.Parameters.AddWithValue("@IMPORTE", comTo.Importe);
                                _ = cmd.Parameters.AddWithValue("@PORCENTAJE", comTo.Porcentaje);
                                _ = cmd.Parameters.AddWithValue("@BASE_IMPONIBLE", comTo.BaseImponible);
                                _ = cmd.Parameters.AddWithValue("@CODIGO", item2.CODIGO);
                                _ = cmd.Parameters.AddWithValue("@COD_TIPO_PLLA", item2.COD_TIPO_PLLA);
                                _ = cmd.Parameters.AddWithValue("@ID_TIPO_COMISION", comTo.TipoComisionTo.IdTipoComision);
                                _ = cmd.Parameters.AddWithValue("@USUARIO_CREA", comTo.UsuarioCrea);

                                if (cmd.ExecuteNonQuery() <= 0)
                                    return false;
                            }
                        }
                    }
                }

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool InsertarComisionOtros(SqlTransaction tr, ComisionTo comTo)
        {
            const string procedure = "dps_InsertarComision";
            try
            {
                DataTable dt = ObtenerDatosComisionRegistrar(tr, comTo);
                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        SqlCommand cmd = new SqlCommand(procedure, conn, tr)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        _ = cmd.Parameters.AddWithValue("@COD_PER", row["COD_PER"]);
                        _ = cmd.Parameters.AddWithValue("@COD_NIVEL", row["COD_NIVEL"]);
                        _ = cmd.Parameters.AddWithValue("@NRO_CUOTA", row["NRO_CUOTA"]);
                        _ = cmd.Parameters.AddWithValue("@FECHA_INI_VIGENCIA", comTo.FechaIniVigencia);
                        _ = cmd.Parameters.AddWithValue("@FECHA_FIN_VIGENCIA", comTo.FechaFinVigencia);
                        _ = cmd.Parameters.AddWithValue("@IMPORTE", row["IMPORTE"]);
                        _ = cmd.Parameters.AddWithValue("@PORCENTAJE", row["PORCENTAJE"]);
                        _ = cmd.Parameters.AddWithValue("@BASE_IMPONIBLE", row["BASE_IMPONIBLE"]);
                        _ = cmd.Parameters.AddWithValue("@CODIGO", row["CODIGO"]);
                        _ = cmd.Parameters.AddWithValue("@COD_TIPO_PLLA", row["COD_TIPO_PLLA"]);
                        _ = cmd.Parameters.AddWithValue("@ID_TIPO_COMISION", row["ID_TIPO_COMISION"]);
                        _ = cmd.Parameters.AddWithValue("@USUARIO_CREA", comTo.UsuarioCrea);

                        if (cmd.ExecuteNonQuery() <= 0)
                            return false;
                    }
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private DataTable ObtenerDatosComisionRegistrar(SqlTransaction tr, ComisionTo comTo)
        {
            const string procedure = "usp_ObtenerDatosComisionRegistrar";
            try
            {
                string codPer = string.Empty;
                foreach (personaTo item in comTo.LstMaestroPersonaTo)
                {
                    codPer += item.COD_PER + ",";
                }

                string codTipoPlla = string.Empty;
                foreach (tipoPlanillaCreacionTo item in comTo.LstTipoPlanillaTo)
                {
                    codTipoPlla += item.COD_TIPO_PLLA + ",";
                }

                SqlCommand cmd = new SqlCommand(procedure, conn, tr)
                {
                    CommandType = CommandType.StoredProcedure
                };

                _ = cmd.Parameters.AddWithValue("@FECHA_INI_VIGENCIA", comTo.FechaIniVigencia);
                _ = cmd.Parameters.AddWithValue("@COD_PER", codPer);
                _ = cmd.Parameters.AddWithValue("@COD_NIVEL", comTo.NivelTo.COD_NIVEL);
                _ = cmd.Parameters.AddWithValue("@COD_TIPO_PLLA", codTipoPlla);
                _ = cmd.Parameters.AddWithValue("@NRO_CUOTA", comTo.NroCuota);

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
        }

        private DataTable ObtenerFechaAperturaComision(SqlTransaction tr, ComisionTo comTo)
        {
            const string procedure = "usp_ObtenerFechasAperturaComision";

            try
            {
                string codPer = string.Empty;
                foreach (personaTo item in comTo.LstMaestroPersonaTo)
                {
                    codPer += item.COD_PER + ",";
                }

                SqlCommand cmd = new SqlCommand(procedure, conn, tr)
                {
                    CommandType = CommandType.StoredProcedure
                };

                _ = cmd.Parameters.AddWithValue("@FECHA_INI_VIGENCIA", comTo.FechaIniVigencia);
                _ = cmd.Parameters.AddWithValue("@COD_PER", codPer);

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
        }

        public bool ActualizarImpoteComisionMain(ComisionTo comTo)
        {
            try
            {
                conn.Open();
                using (SqlTransaction tr = conn.BeginTransaction())
                {
                    if (ValidarExistenciaComision(tr, comTo))
                    {
                        if (!ActualizarImporteComision(tr, comTo))
                        {
                            tr.Rollback();
                            return false;
                        }
                    }
                    else
                    {
                        if (!InsertarComision(tr, comTo))
                        {
                            tr.Rollback();
                            return false;
                        }
                    }

                    tr.Commit();
                    return true;
                }
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

        private bool ActualizarImporteComision(SqlTransaction tr, ComisionTo comTo)
        {
            const string procedure = "dsp_ActualizarImporteComision";
            try
            {
                SqlCommand cmd = new SqlCommand(procedure, conn, tr)
                {
                    CommandType = CommandType.StoredProcedure
                };

                _ = cmd.Parameters.AddWithValue("@COD_PER", comTo.PersonaTo.COD_PER);
                _ = cmd.Parameters.AddWithValue("@COD_NIVEL", comTo.NivelTo.COD_NIVEL);
                _ = cmd.Parameters.AddWithValue("@NRO_CUOTA", comTo.NroCuota);
                _ = cmd.Parameters.AddWithValue("@FECHA_INI_VIGENCIA", comTo.FechaIniVigencia);
                _ = cmd.Parameters.AddWithValue("@ID_TIPO_COMISION", comTo.TipoComisionTo.IdTipoComision);
                _ = cmd.Parameters.AddWithValue("@ID_TIPO_PLLA", comTo.TipoPlanillaTo.CODIGO);
                _ = cmd.Parameters.AddWithValue("@COD_TIPO_PLLA", comTo.TipoPlanillaTo.COD_TIPO_PLLA);
                _ = cmd.Parameters.AddWithValue("@IMPORTE", comTo.Importe);
                _ = cmd.Parameters.AddWithValue("@USUARIO_MODIFICA", comTo.UsuarioCrea);

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool ValidarExistenciaComision(SqlTransaction tr, ComisionTo comTo)
        {
            const string select = "dsp_ValidarExistenciaComision";
            try
            {
                SqlCommand cmd = new SqlCommand(select, conn, tr)
                {
                    CommandType = CommandType.StoredProcedure
                };

                _ = cmd.Parameters.AddWithValue("@COD_PER", comTo.PersonaTo.COD_PER);
                _ = cmd.Parameters.AddWithValue("@COD_NIVEL", comTo.NivelTo.COD_NIVEL);
                _ = cmd.Parameters.AddWithValue("@NRO_CUOTA", comTo.NroCuota);
                _ = cmd.Parameters.AddWithValue("@FECHA_INI_VIGENCIA", comTo.FechaIniVigencia);
                _ = cmd.Parameters.AddWithValue("@ID_TIPO_COMISION", comTo.TipoComisionTo.IdTipoComision);
                _ = cmd.Parameters.AddWithValue("@ID_TIPO_PLLA", comTo.LstTipoPlanillaTo[0].CODIGO);
                _ = cmd.Parameters.AddWithValue("@COD_TIPO_PLLA", comTo.LstTipoPlanillaTo[0].COD_TIPO_PLLA);

                SqlDataReader dr = cmd.ExecuteReader();
                bool result = dr.Read();
                dr.Close();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool EliminarComision(ComisionTo com)
        {
            const string procedure = "dsp_EliminarComision";
            try
            {
                SqlCommand cmd = new SqlCommand(procedure, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                _ = cmd.Parameters.AddWithValue("@COD_PER", com.PersonaTo.COD_PER);
                _ = cmd.Parameters.AddWithValue("@COD_NIVEL", com.NivelTo.COD_NIVEL);
                _ = cmd.Parameters.AddWithValue("@NRO_CUOTA", com.NroCuota);
                _ = cmd.Parameters.AddWithValue("@ID_TIPO_COMISION", com.TipoComisionTo.IdTipoComision);
                _ = cmd.Parameters.AddWithValue("@ID_TIPO_PLLA", com.TipoPlanillaTo.CODIGO);
                _ = cmd.Parameters.AddWithValue("@COD_TIPO_PLLA", com.TipoPlanillaTo.COD_TIPO_PLLA);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
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

        public int EliminarComisionXNroCuota(List<ComisionTo> lstComision, string nroCuota)
        {
            const string procedure = "dsp_EliminarComisionXNroCuota";
            SqlTransaction tr = null;
            try
            {
                conn.Open();
                tr = conn.BeginTransaction();
                int count = 0;
                foreach (ComisionTo item in lstComision)
                {
                    SqlCommand cmd = new SqlCommand(procedure, conn, tr)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    _ = cmd.Parameters.AddWithValue("@COD_PER", item.PersonaTo.COD_PER);
                    _ = cmd.Parameters.AddWithValue("@COD_NIVEL", item.NivelTo.COD_NIVEL);
                    _ = cmd.Parameters.AddWithValue("@NRO_CUOTA", nroCuota);
                    _ = cmd.Parameters.AddWithValue("@ID_TIPO_PLLA", item.TipoPlanillaTo.CODIGO);
                    _ = cmd.Parameters.AddWithValue("@COD_TIPO_PLLA", item.TipoPlanillaTo.COD_TIPO_PLLA);

                    count += cmd.ExecuteNonQuery();
                }
                tr.Commit();
                return count;
            }
            catch (Exception)
            {
                if (tr != null)
                    tr.Rollback();
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public int EliminarComisionXFechaVigencia(List<ComisionTo> lstComision, DateTime fechaVigencia)
        {
            const string procedure = "dsp_EliminarComisionXFechaVigencia";
            SqlTransaction tr = null;
            try
            {
                conn.Open();
                tr = conn.BeginTransaction();
                int count = 0;
                foreach (ComisionTo item in lstComision)
                {
                    SqlCommand cmd = new SqlCommand(procedure, conn, tr)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    _ = cmd.Parameters.AddWithValue("@COD_PER", item.PersonaTo.COD_PER);
                    _ = cmd.Parameters.AddWithValue("@COD_NIVEL", item.NivelTo.COD_NIVEL);
                    _ = cmd.Parameters.AddWithValue("@FECHA_INI_VIGENCIA", fechaVigencia);
                    _ = cmd.Parameters.AddWithValue("@ID_TIPO_PLLA", item.TipoPlanillaTo.CODIGO);
                    _ = cmd.Parameters.AddWithValue("@COD_TIPO_PLLA", item.TipoPlanillaTo.COD_TIPO_PLLA);

                    count += cmd.ExecuteNonQuery();
                }
                tr.Commit();
                return count;
            }
            catch (Exception)
            {
                if (tr != null)
                    tr.Rollback();
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public DataTable RptComisionXNivelVenta(string codTipoVenta, string nivelVenta, string codPer, DateTime fechaIniVigencia, DateTime fechaFinVigencia)
        {
            const string procedure = "dsp_RptComsionesXNivelVenta";
            try
            {
                SqlCommand cmd = new SqlCommand(procedure, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                _ = cmd.Parameters.AddWithValue("@COD_TIPO_PLLA", codTipoVenta);
                _ = cmd.Parameters.AddWithValue("@COD_NIVEL", nivelVenta);
                _ = cmd.Parameters.AddWithValue("@COD_PER", codPer);
                _ = cmd.Parameters.AddWithValue("@FECHA_INI_VIGENCIA", fechaIniVigencia);
                _ = cmd.Parameters.AddWithValue("@FECHA_FIN_VIGENCIA", fechaFinVigencia);

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
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        public DataTable RptComisionVendedoresXNivelVenta(string codTipoVenta, string nivelVenta, string codPer, DateTime fechaIniVigencia, DateTime fechaFinVigencia)
        {
            const string procedure = "usp_RptComisionesVendedoresXNivelVenta";
            try
            {
                SqlCommand cmd = new SqlCommand(procedure, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                _ = cmd.Parameters.AddWithValue("@COD_SUPERIOR", codPer);
                _ = cmd.Parameters.AddWithValue("@COD_NIVEL", nivelVenta);
                _ = cmd.Parameters.AddWithValue("@COD_TIPO_PLLA", codTipoVenta);
                _ = cmd.Parameters.AddWithValue("@FECHA_INI_VIGENCIA", fechaIniVigencia);
                _ = cmd.Parameters.AddWithValue("@FECHA_FIN_VIGENCIA", fechaFinVigencia);

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
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        public DataTable RptComisionXVendedor(string codTipoVenta, string codPer, DateTime fechaIniVigencia, DateTime fechaFinVigencia)
        {
            const string procedure = "usp_RptComisionesXVendedores";
            try
            {
                SqlCommand cmd = new SqlCommand(procedure, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                _ = cmd.Parameters.AddWithValue("@COD_PER", codPer);
                _ = cmd.Parameters.AddWithValue("@COD_TIPO_PLLA", codTipoVenta);
                _ = cmd.Parameters.AddWithValue("@FECHA_INI_VIGENCIA", fechaIniVigencia);
                _ = cmd.Parameters.AddWithValue("@FECHA_FIN_VIGENCIA", fechaFinVigencia);

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
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        public bool EliminarSoloUnaComision(ComisionTo com)
        {
            const string procedure = "dsp_EliminarSoloUnaComision";
            try
            {
                SqlCommand cmd = new SqlCommand(procedure, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                _ = cmd.Parameters.AddWithValue("@COD_PER", com.PersonaTo.COD_PER);
                _ = cmd.Parameters.AddWithValue("@COD_NIVEL", com.NivelTo.COD_NIVEL);
                _ = cmd.Parameters.AddWithValue("@NRO_CUOTA", com.NroCuota);
                _ = cmd.Parameters.AddWithValue("@FECHA_INI_VIGENCIA", com.FechaIniVigencia);
                _ = cmd.Parameters.AddWithValue("@ID_TIPO_COMISION", com.TipoComisionTo.IdTipoComision);
                _ = cmd.Parameters.AddWithValue("@ID_TIPO_PLLA", com.TipoPlanillaTo.CODIGO);
                _ = cmd.Parameters.AddWithValue("@COD_TIPO_PLLA", com.TipoPlanillaTo.COD_TIPO_PLLA);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
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

        public DataTable RptComisionResumen(string codTipoVenta, DateTime fechaIniVigencia, DateTime fechaFinVigencia)
        {
            const string procedure = "dsp_RptComisionesResumen";
            try
            {
                SqlCommand cmd = new SqlCommand(procedure, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                _ = cmd.Parameters.AddWithValue("@COD_TIPO_PLLA", codTipoVenta);
                _ = cmd.Parameters.AddWithValue("@FECHA_INI_VIGENCIA", fechaIniVigencia);
                _ = cmd.Parameters.AddWithValue("@FECHA_FIN_VIGENCIA", fechaFinVigencia);

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
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        public DataTable ListarContratosParaGenerarComision(DateTime fechaAprobIni, DateTime fechaAprobFin, DateTime fechaCobraIni, DateTime fechaCobraFin,
            string codPrograma, string codInstitucion, string codTipoPlla, string nroCuota)
        {
            const string procedure = "dsp_ListaContratosParaGenerarComision";
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion.con))
                {
                    SqlCommand cmd = new SqlCommand(procedure, cn)
                    {
                        CommandType = CommandType.StoredProcedure,
                        CommandTimeout = 7000
                    };

                    _ = cmd.Parameters.AddWithValue("@FECHA_APROBACION_INI", fechaAprobIni);
                    _ = cmd.Parameters.AddWithValue("@FECHA_APROBACION_FIN", fechaAprobFin);
                    _ = cmd.Parameters.AddWithValue("@FECHA_COBRANZA_INI", fechaCobraIni);
                    _ = cmd.Parameters.AddWithValue("@FECHA_COBRANZA_FIN", fechaCobraFin);
                    _ = cmd.Parameters.AddWithValue("@COD_PROGRAMA", codPrograma);
                    _ = cmd.Parameters.AddWithValue("@COD_INSTITUCION", codInstitucion);
                    _ = cmd.Parameters.AddWithValue("@COD_TIPO_PLLA", codTipoPlla);
                    _ = cmd.Parameters.AddWithValue("@NRO_CUOTA", nroCuota);
                    cn.Open();
                    DataTable dt = new DataTable();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        dt.Load(dr, LoadOption.Upsert);
                    }
                    return dt;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable ListarContratosGeneradosComisionXPeriodo(string feAñoPer, string feMesPer, string periodoProceso, string codPrograma, string codInstitucion, string codTipoPlla, string nroCuota)
        {
            const string procedure = "dsp_ListaContratosComisionGenerados";
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion.con))
                {
                    SqlCommand cmd = new SqlCommand(procedure, cn)
                    {
                        CommandType = CommandType.StoredProcedure,
                        CommandTimeout = 7000
                    };

                    _ = cmd.Parameters.AddWithValue("@FE_AÑO_PER", feAñoPer);
                    _ = cmd.Parameters.AddWithValue("@FE_MES_PER", feMesPer);
                    _ = cmd.Parameters.AddWithValue("@PERIODO_PROCESO", periodoProceso);
                    _ = cmd.Parameters.AddWithValue("@COD_PROGRAMA", codPrograma);
                    _ = cmd.Parameters.AddWithValue("@COD_INSTITUCION", codInstitucion);
                    _ = cmd.Parameters.AddWithValue("@COD_TIPO_PLLA", codTipoPlla);
                    _ = cmd.Parameters.AddWithValue("@NRO_CUOTA", nroCuota);

                    cn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(dr, LoadOption.Upsert);
                        return dt;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable ObtenerNroCuota()
        {
            const string procedure = "dsp_ObtenerNroCuota";
            try
            {
                SqlCommand cmd = new SqlCommand(procedure, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

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
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        public bool InsertarComisionContrato(List<ComisionContrato> lstCom)
        {
            //> Obtiene el último número proceso generado de un periodo, se quitó esta funcionalidad por ordenes
            //> string periodoProceso = ObtenerPeriodoProceso(lstCom[0].FE_AÑO_PER, lstCom[0].FE_MES_PER);
            conn.Open();
            using (SqlTransaction transaction = conn.BeginTransaction())
            {
                try
                {
                    const string procedure = "dsp_InsertarComisionCopntrato";
                    foreach (ComisionContrato item in lstCom)
                    {
                        using (var cmd = new SqlCommand())
                        {
                            cmd.Connection = conn;
                            cmd.Transaction = transaction;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = procedure;
                            _ = cmd.Parameters.AddWithValue("@COD_SUCURSAL", item.COD_SUCURSAL);
                            _ = cmd.Parameters.AddWithValue("@COD_CLASE", item.COD_CLASE);
                            _ = cmd.Parameters.AddWithValue("@NRO_CONTRATO", item.NRO_CONTRATO);
                            _ = cmd.Parameters.AddWithValue("@FE_AÑO", item.FE_AÑO);
                            _ = cmd.Parameters.AddWithValue("@FE_MES", item.FE_MES);
                            _ = cmd.Parameters.AddWithValue("@NRO_CUOTA", item.NRO_CUOTA);
                            _ = cmd.Parameters.AddWithValue("@FE_AÑO_PER", item.FE_AÑO_PER);
                            _ = cmd.Parameters.AddWithValue("@FE_MES_PER", item.FE_MES_PER);
                            _ = cmd.Parameters.AddWithValue("@FECHA_APROB_INI", item.FECHA_APROB_INI);
                            _ = cmd.Parameters.AddWithValue("@FECHA_APROB_FIN", item.FECHA_APROB_FIN);
                            _ = cmd.Parameters.AddWithValue("@FECHA_COBRA_INI", item.FECHA_COBRA_INI);
                            _ = cmd.Parameters.AddWithValue("@FECHA_COBRA_FIN", item.FECHA_COBRA_FIN);
                            _ = cmd.Parameters.AddWithValue("@PERIODO_PROCESO", item.PERIODO_PROCESO);
                            _ = cmd.Parameters.AddWithValue("@FE_AÑO_SIS", item.FE_AÑO_SIS);
                            _ = cmd.Parameters.AddWithValue("@FE_MES_SIS", item.FE_MES_SIS);
                            if (item.ID_COMISION_VEND == 0)
                                _ = cmd.Parameters.AddWithValue("@ID_COMISION_VEND", DBNull.Value);
                            else
                                _ = cmd.Parameters.AddWithValue("@ID_COMISION_VEND", item.ID_COMISION_VEND);
                            if (item.ID_CONF_VEND == 0)
                                _ = cmd.Parameters.AddWithValue("@ID_CONF_VEND", DBNull.Value);
                            else
                                _ = cmd.Parameters.AddWithValue("@ID_CONF_VEND", item.ID_CONF_VEND);
                            if (item.ID_COMISION_SUP == 0)
                                _ = cmd.Parameters.AddWithValue("@ID_COMISION_SUP", DBNull.Value);
                            else
                                _ = cmd.Parameters.AddWithValue("@ID_COMISION_SUP", item.ID_COMISION_SUP);
                            if (item.ID_CONF_SUP == 0)
                                _ = cmd.Parameters.AddWithValue("@ID_CONF_SUP", DBNull.Value);
                            else
                                _ = cmd.Parameters.AddWithValue("@ID_CONF_SUP", item.ID_CONF_SUP);
                            if (item.ID_COMISION_DIR_VTAS == 0)
                                _ = cmd.Parameters.AddWithValue("@ID_COMISION_DIR_VTAS", DBNull.Value);
                            else
                                _ = cmd.Parameters.AddWithValue("@ID_COMISION_DIR_VTAS", item.ID_COMISION_DIR_VTAS);
                            if (item.ID_CONF_DIR_VTAS == 0)
                                _ = cmd.Parameters.AddWithValue("@ID_CONF_DIR_VTAS", DBNull.Value);
                            else
                                _ = cmd.Parameters.AddWithValue("@ID_CONF_DIR_VTAS", item.ID_CONF_DIR_VTAS);
                            if (item.ID_COMISION_DIR_NCNAL == 0)
                                _ = cmd.Parameters.AddWithValue("@ID_COMISION_DIR_NCNAL", DBNull.Value);
                            else
                                _ = cmd.Parameters.AddWithValue("@ID_COMISION_DIR_NCNAL", item.ID_COMISION_DIR_NCNAL);
                            if (item.ID_CONF_DIR_NCNAL == 0)
                                _ = cmd.Parameters.AddWithValue("@ID_CONF_DIR_NCNAL", DBNull.Value);
                            else
                                _ = cmd.Parameters.AddWithValue("@ID_CONF_DIR_NCNAL", item.ID_CONF_DIR_NCNAL);
                            _ = cmd.Parameters.AddWithValue("@USUARIO_CREA", item.USUARIO);
                            _ = cmd.Parameters.AddWithValue("@FLAH", item.FLAH);
                            _ = cmd.Parameters.AddWithValue("@ESTADO", item.ESTADO);
                            if (cmd.ExecuteNonQuery() <= 0)
                            {
                                transaction.Rollback();
                                conn.Close();
                                return false;
                            }
                        }
                    }
                    transaction.Commit();
                    conn.Close();
                    return true;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    conn.Close();
                    throw;
                }
            }
        }

        public bool InsertarComisionContratoExcluidos(List<ComisionContrato> lstCom)
        {
            conn.Open();
            using (SqlTransaction transaction = conn.BeginTransaction())
            {
                try
                {
                    const string procedure = "dsp_InsertarComisionCopntrato";
                    foreach (ComisionContrato item in lstCom)
                    {
                        using (var cmd = new SqlCommand())
                        {
                            cmd.Connection = conn;
                            cmd.Transaction = transaction;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = procedure;
                            _ = cmd.Parameters.AddWithValue("@COD_SUCURSAL", item.COD_SUCURSAL);
                            _ = cmd.Parameters.AddWithValue("@COD_CLASE", item.COD_CLASE);
                            _ = cmd.Parameters.AddWithValue("@NRO_CONTRATO", item.NRO_CONTRATO);
                            _ = cmd.Parameters.AddWithValue("@FE_AÑO", item.FE_AÑO);
                            _ = cmd.Parameters.AddWithValue("@FE_MES", item.FE_MES);
                            _ = cmd.Parameters.AddWithValue("@NRO_CUOTA", item.NRO_CUOTA);
                            _ = cmd.Parameters.AddWithValue("@FE_AÑO_PER", item.FE_AÑO_PER);
                            _ = cmd.Parameters.AddWithValue("@FE_MES_PER", item.FE_MES_PER);
                            _ = cmd.Parameters.AddWithValue("@FECHA_APROB_INI", item.FECHA_APROB_INI);
                            _ = cmd.Parameters.AddWithValue("@FECHA_APROB_FIN", item.FECHA_APROB_FIN);
                            _ = cmd.Parameters.AddWithValue("@FECHA_COBRA_INI", item.FECHA_COBRA_INI);
                            _ = cmd.Parameters.AddWithValue("@FECHA_COBRA_FIN", item.FECHA_COBRA_FIN);
                            _ = cmd.Parameters.AddWithValue("@PERIODO_PROCESO", item.PERIODO_PROCESO);
                            _ = cmd.Parameters.AddWithValue("@FE_AÑO_SIS", item.FE_AÑO_SIS);
                            _ = cmd.Parameters.AddWithValue("@FE_MES_SIS", item.FE_MES_SIS);
                            if (item.ID_COMISION_VEND == 0)
                                _ = cmd.Parameters.AddWithValue("@ID_COMISION_VEND", DBNull.Value);
                            else
                                _ = cmd.Parameters.AddWithValue("@ID_COMISION_VEND", item.ID_COMISION_VEND);
                            if (item.ID_COMISION_SUP == 0)
                                _ = cmd.Parameters.AddWithValue("@ID_COMISION_SUP", DBNull.Value);
                            else
                                _ = cmd.Parameters.AddWithValue("@ID_COMISION_SUP", item.ID_COMISION_SUP);
                            if (item.ID_COMISION_DIR_VTAS == 0)
                                _ = cmd.Parameters.AddWithValue("@ID_COMISION_DIR_VTAS", DBNull.Value);
                            else
                                _ = cmd.Parameters.AddWithValue("@ID_COMISION_DIR_VTAS", item.ID_COMISION_DIR_VTAS);
                            if (item.ID_COMISION_DIR_NCNAL == 0)
                                _ = cmd.Parameters.AddWithValue("@ID_COMISION_DIR_NCNAL", DBNull.Value);
                            else
                                _ = cmd.Parameters.AddWithValue("@ID_COMISION_DIR_NCNAL", item.ID_COMISION_DIR_NCNAL);
                            _ = cmd.Parameters.AddWithValue("@USUARIO_CREA", item.USUARIO);
                            _ = cmd.Parameters.AddWithValue("@ESTADO", item.ESTADO);
                            if (cmd.ExecuteNonQuery() <= 0)
                            {
                                transaction.Rollback();
                                conn.Close();
                                return false;
                            }
                        }
                    }
                    transaction.Commit();
                    conn.Close();
                    return true;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    conn.Close();
                    throw;
                }
            }
        }

        public string ObtenerPeriodoProceso(string feAñoPer, string feMesPer)
        {
            try
            {
                const string select = "SELECT ISNULL(CONVERT(INT, MAX(PERIODO_PROCESO)), 0) + 1 FROM COMISION_CONTRATO WHERE FE_AÑO_PER = @FE_AÑO_PER AND FE_MES_PER = @FE_MES_PER";
                SqlCommand cmd = new SqlCommand(select, conn)
                {
                    CommandType = CommandType.Text
                };

                _ = cmd.Parameters.Add("@FE_AÑO_PER", SqlDbType.Char, 4).Value = feAñoPer;
                _ = cmd.Parameters.AddWithValue("@FE_MES_PER", feMesPer);

                conn.Open();
                string result = cmd.ExecuteScalar()?.ToString();
                return string.IsNullOrEmpty(result) ? "1" : result;
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

        public DataTable ObtenerContratoParaGenerarComision(string nroContrato, string codPrograma, string codInstitucion, string codTipoPlla, string nroCuota,
            DateTime fechaCobranzaIni)
        {
            const string procedure = "dsp_ObtenerContratoParaGenerarComision";
            try
            {
                SqlCommand cmd = new SqlCommand(procedure, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                _ = cmd.Parameters.AddWithValue("@NRO_CONTRATO", nroContrato);
                _ = cmd.Parameters.AddWithValue("@COD_PROGRAMA", codPrograma);
                _ = cmd.Parameters.AddWithValue("@COD_INSTITUCION", codInstitucion);
                _ = cmd.Parameters.AddWithValue("@COD_TIPO_PLLA", codTipoPlla);
                _ = cmd.Parameters.AddWithValue("@NRO_CUOTA", nroCuota);
                _ = cmd.Parameters.AddWithValue("@FECHA_COBRANZA_INI", fechaCobranzaIni);

                conn.Open();
                DataTable dt = new DataTable();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    dt.Load(dr, LoadOption.Upsert);
                }
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        public DataTable ObtenerContratoMostrarAgregarComision(string nroContrato, string codPrograma, string codInstitucion, string codTipoPlla, string nroCuota)
        {
            const string procedure = "dsp_ObtenerContratoMostrarAgregarComision";
            try
            {
                SqlCommand cmd = new SqlCommand(procedure, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                _ = cmd.Parameters.AddWithValue("@NRO_CONTRATO", nroContrato);
                _ = cmd.Parameters.AddWithValue("@COD_PROGRAMA", codPrograma);
                _ = cmd.Parameters.AddWithValue("@COD_INSTITUCION", codInstitucion);
                _ = cmd.Parameters.AddWithValue("@COD_TIPO_PLLA", codTipoPlla);
                _ = cmd.Parameters.AddWithValue("@NRO_CUOTA", nroCuota);

                conn.Open();
                DataTable dt = new DataTable();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    dt.Load(dr, LoadOption.Upsert);
                }
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        public bool EliminarContratoComision(ComisionContrato comTo)
        {
            const string procedure = "dsp_EliminarComisionContrato";
            conn.Open();
            using (SqlTransaction transaction = conn.BeginTransaction())
            {
                try
                {
                    using (var cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.Transaction = transaction;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = procedure;

                        _ = cmd.Parameters.AddWithValue("@COD_SUCURSAL", comTo.COD_SUCURSAL);
                        _ = cmd.Parameters.AddWithValue("@COD_CLASE", comTo.COD_CLASE);
                        _ = cmd.Parameters.AddWithValue("@NRO_CONTRATO", comTo.NRO_CONTRATO);
                        _ = cmd.Parameters.AddWithValue("@FE_AÑO", comTo.FE_AÑO);
                        _ = cmd.Parameters.AddWithValue("@FE_MES", comTo.FE_MES);
                        _ = cmd.Parameters.AddWithValue("@NRO_CUOTA", comTo.NRO_CUOTA);
                        if (comTo.ID_COMISION_VEND == 0)
                            _ = cmd.Parameters.AddWithValue("@ID_COMISION_VEND", DBNull.Value);
                        else
                            _ = cmd.Parameters.AddWithValue("@ID_COMISION_VEND", comTo.ID_COMISION_VEND);
                        if (comTo.ID_COMISION_SUP == 0)
                            _ = cmd.Parameters.AddWithValue("@ID_COMISION_SUP", DBNull.Value);
                        else
                            _ = cmd.Parameters.AddWithValue("@ID_COMISION_SUP", comTo.ID_COMISION_SUP);
                        if (comTo.ID_COMISION_DIR_VTAS == 0)
                            _ = cmd.Parameters.AddWithValue("@ID_COMISION_DIR_VTAS", DBNull.Value);
                        else
                            _ = cmd.Parameters.AddWithValue("@ID_COMISION_DIR_VTAS", comTo.ID_COMISION_DIR_VTAS);
                        if (comTo.ID_COMISION_DIR_NCNAL == 0)
                            _ = cmd.Parameters.AddWithValue("@ID_COMISION_DIR_NCNAL", DBNull.Value);
                        else
                            _ = cmd.Parameters.AddWithValue("@ID_COMISION_DIR_NCNAL", comTo.ID_COMISION_DIR_NCNAL);
                        int result = cmd.ExecuteNonQuery();
                        if (result <= 0 || result > 1)
                        {
                            transaction.Rollback();
                            return false;
                        }
                    }
                    transaction.Commit();
                    conn.Close();
                    return true;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    conn.Close();
                    throw;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public bool EliminarContratoComision(List<ComisionContrato> lstCom)
        {
            const string procedure = "dsp_EliminarComisionContrato";
            conn.Open();
            using (SqlTransaction transaction = conn.BeginTransaction())
            {
                try
                {
                    foreach (ComisionContrato item in lstCom)
                    {
                        using (var cmd = new SqlCommand())
                        {
                            cmd.Connection = conn;
                            cmd.Transaction = transaction;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = procedure;

                            _ = cmd.Parameters.AddWithValue("@ID_PROCESO", item.ID_PROCESO);
                            _ = cmd.Parameters.AddWithValue("@COD_SUCURSAL", item.COD_SUCURSAL);
                            _ = cmd.Parameters.AddWithValue("@COD_CLASE", item.COD_CLASE);
                            _ = cmd.Parameters.AddWithValue("@NRO_CONTRATO", item.NRO_CONTRATO);
                            _ = cmd.Parameters.AddWithValue("@FE_AÑO", item.FE_AÑO);
                            _ = cmd.Parameters.AddWithValue("@FE_MES", item.FE_MES);
                            _ = cmd.Parameters.AddWithValue("@NRO_CUOTA", item.NRO_CUOTA);
                            if (item.ID_COMISION_VEND == 0)
                                _ = cmd.Parameters.AddWithValue("@ID_COMISION_VEND", DBNull.Value);
                            else
                                _ = cmd.Parameters.AddWithValue("@ID_COMISION_VEND", item.ID_COMISION_VEND);
                            if (item.ID_COMISION_SUP == 0)
                                _ = cmd.Parameters.AddWithValue("@ID_COMISION_SUP", DBNull.Value);
                            else
                                _ = cmd.Parameters.AddWithValue("@ID_COMISION_SUP", item.ID_COMISION_SUP);
                            if (item.ID_COMISION_DIR_VTAS == 0)
                                _ = cmd.Parameters.AddWithValue("@ID_COMISION_DIR_VTAS", DBNull.Value);
                            else
                                _ = cmd.Parameters.AddWithValue("@ID_COMISION_DIR_VTAS", item.ID_COMISION_DIR_VTAS);
                            if (item.ID_COMISION_DIR_NCNAL == 0)
                                _ = cmd.Parameters.AddWithValue("@ID_COMISION_DIR_NCNAL", DBNull.Value);
                            else
                                _ = cmd.Parameters.AddWithValue("@ID_COMISION_DIR_NCNAL", item.ID_COMISION_DIR_NCNAL);

                            int result = cmd.ExecuteNonQuery();
                            if (result <= 0 || result > 1)
                            {
                                transaction.Rollback();
                                return false;
                            }
                        }
                    }
                    transaction.Commit();
                    return true;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    conn.Close();
                    throw;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public DataTable ObtenerPeriodosGeneradosComision()
        {
            const string procedure = "dsp_ObtenerPeridosGeneradosComision";
            try
            {
                SqlCommand cmd = new SqlCommand(procedure, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                if (conn.State == ConnectionState.Closed) conn.Open();
                DataTable dt = new DataTable();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    dt.Load(dr, LoadOption.Upsert);
                }
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

        public DataTable ObtenerPeriodosExcluidosComision()
        {
            const string procedure = "dsp_ObtenerPeridosExcluidosComision";
            try
            {
                SqlCommand cmd = new SqlCommand(procedure, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                if (conn.State == ConnectionState.Closed) conn.Open();
                DataTable dt = new DataTable();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    dt.Load(dr, LoadOption.Upsert);
                }
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

        public DataTable RptContratosComisionGeneradosXSuperior(string feAñoPer, string feMesPer, string periodoProceso, string codPrograma,
            string codSuperior, string codNivelVenta)
        {
            const string procedure = "dsp_RptContratosComisionGeneradosXSuperior";
            try
            {
                SqlCommand cmd = new SqlCommand(procedure, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                _ = cmd.Parameters.AddWithValue("@FE_AÑO_PER", feAñoPer);
                _ = cmd.Parameters.AddWithValue("@FE_MES_PER", feMesPer);
                _ = cmd.Parameters.AddWithValue("@PERIODO_PROCESO", periodoProceso);
                _ = cmd.Parameters.AddWithValue("@COD_PROGRAMA", codPrograma);
                _ = cmd.Parameters.AddWithValue("@COD_SUPERIOR", codSuperior);
                _ = cmd.Parameters.AddWithValue("@NIVEL_SUPERIOR", codNivelVenta);

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

        public DataTable RptContratosComisionGeneradosXVendedor(string feAñoPer, string feMesPer, string periodoProceso, string codPrograma, string codVendedor)
        {
            const string procedure = "dsp_RptContratosComisionGeneradosXVendedor";
            try
            {
                SqlCommand cmd = new SqlCommand(procedure, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                _ = cmd.Parameters.AddWithValue("@FE_AÑO_PER", feAñoPer);
                _ = cmd.Parameters.AddWithValue("@FE_MES_PER", feMesPer);
                _ = cmd.Parameters.AddWithValue("@PERIODO_PROCESO", periodoProceso);
                _ = cmd.Parameters.AddWithValue("@COD_PROGRAMA", codPrograma);
                _ = cmd.Parameters.AddWithValue("@COD_VENDEDOR", codVendedor);

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

        public DataTable RptContratosComisionExcluidosXSuperior(string feAñoPer, string feMesPer, string periodoProceso, string codPrograma,
            string codSuperior, string codNivelVenta)
        {
            const string procedure = "dsp_RptContratosComisionExcluidosXSuperior";
            try
            {
                SqlCommand cmd = new SqlCommand(procedure, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                _ = cmd.Parameters.AddWithValue("@FE_AÑO_PER", feAñoPer);
                _ = cmd.Parameters.AddWithValue("@FE_MES_PER", feMesPer);
                _ = cmd.Parameters.AddWithValue("@PERIODO_PROCESO", periodoProceso);
                _ = cmd.Parameters.AddWithValue("@COD_PROGRAMA", codPrograma);
                _ = cmd.Parameters.AddWithValue("@COD_SUPERIOR", codSuperior);
                _ = cmd.Parameters.AddWithValue("@NIVEL_SUPERIOR", codNivelVenta);

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


        public DataTable RptContratosComisionExcluidosXVendedor(string feAñoPer, string feMesPer, string periodoProceso, string codPrograma, string codVendedor)
        {
            const string procedure = "dsp_RptContratosComisionExcluidosXVendedor";
            try
            {
                SqlCommand cmd = new SqlCommand(procedure, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                _ = cmd.Parameters.AddWithValue("@FE_AÑO_PER", feAñoPer);
                _ = cmd.Parameters.AddWithValue("@FE_MES_PER", feMesPer);
                _ = cmd.Parameters.AddWithValue("@PERIODO_PROCESO", periodoProceso);
                _ = cmd.Parameters.AddWithValue("@COD_PROGRAMA", codPrograma);
                _ = cmd.Parameters.AddWithValue("@COD_VENDEDOR", codVendedor);

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

        public DataTable ListarDevolucionComisionContratos(DateTime fechaAprobIni, DateTime fechaAprobFin, DateTime fechaDevolIni, DateTime fechaDevolFin, string codPrograma, string codInstitucion)
        {
            const string procedure = "dsp_ListarDevolucionComisionContratos";
            try
            {
                SqlCommand cmd = new SqlCommand(procedure, conn)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 7000
                };

                _ = cmd.Parameters.AddWithValue("@FECHA_APROBACION_INI", fechaAprobIni);
                _ = cmd.Parameters.AddWithValue("@FECHA_APROBACION_FIN", fechaAprobFin);
                _ = cmd.Parameters.AddWithValue("@FECHA_DEVOLUCION_INI", fechaDevolIni);
                _ = cmd.Parameters.AddWithValue("@FECHA_DEVOLUCION_FIN", fechaDevolFin);
                _ = cmd.Parameters.AddWithValue("@COD_PROGRAMA", codPrograma);
                _ = cmd.Parameters.AddWithValue("@COD_INSTITUCION", codInstitucion);

                if (conn.State == ConnectionState.Closed)
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


        public DataTable RPTHISTORICOCOMISIONESAPROBADAS(DateTime fechaAprobIni, DateTime fechaAprobFin, string codVendedor, string tipobusfecha, string fechaActper, string fechaActmes)
        {
            const string procedure = "RPT_REPORTEHISTORICOCOMISIONES"; //RPT_HISTORICOCOMISIONESAPROBADAS";
            try
            {
                SqlCommand cmd = new SqlCommand(procedure, conn)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 7000
                };

                _ = cmd.Parameters.AddWithValue("@FECHA_APROBACION_INI", fechaAprobIni);
                _ = cmd.Parameters.AddWithValue("@FECHA_APROBACION_FIN", fechaAprobFin);
                _ = cmd.Parameters.AddWithValue("@COD_VENDEDOR", codVendedor);
                _ = cmd.Parameters.AddWithValue("@tipobusfecha", tipobusfecha);
                _ = cmd.Parameters.AddWithValue("@FE_AÑO_PER_AC", fechaActper);
                _ = cmd.Parameters.AddWithValue("@FE_MES_PER_AC", fechaActmes);

                if (conn.State == ConnectionState.Closed)
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



        public DataTable ListarDevolucionComisionContratosGenerados(string feAñoPer, string feMesPer)
        {
            const string procedure = "dsp_ListarDevolucionComisionContratosGenerados";
            try
            {
                SqlCommand cmd = new SqlCommand(procedure, conn)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 7000
                };

                _ = cmd.Parameters.AddWithValue("@FE_AÑO_PER", feAñoPer);
                _ = cmd.Parameters.AddWithValue("@FE_MES_PER", feMesPer);

                if (conn.State == ConnectionState.Closed)
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

        public DataTable ObtenerContratoComisonGenerado(string nroContrato)
        {
            const string procedure = "dsp_ObtenerContratoComisonGenerado";
            try
            {
                SqlCommand cmd = new SqlCommand(procedure, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                _ = cmd.Parameters.AddWithValue("@NRO_CONTRATO", nroContrato);

                conn.Open();
                DataTable dt = new DataTable();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    dt.Load(dr, LoadOption.Upsert);
                }
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        public DataTable ListarContratosComisionExcluidos(DateTime fechaAprobIni, DateTime fechaAprobFin, DateTime fechaCobraIni, DateTime fechaCobraFin,
            string codPrograma, string codInstitucion, string codTipoPlla, string nroCuota)
        {
            const string procedure = "dsp_ListaContratosComisionExcluidos";
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion.con))
                {
                    SqlCommand cmd = new SqlCommand(procedure, cn)
                    {
                        CommandType = CommandType.StoredProcedure,
                        CommandTimeout = 7000
                    };

                    _ = cmd.Parameters.AddWithValue("@FECHA_APROBACION_INI", fechaAprobIni);
                    _ = cmd.Parameters.AddWithValue("@FECHA_APROBACION_FIN", fechaAprobFin);
                    _ = cmd.Parameters.AddWithValue("@FECHA_COBRANZA_INI", fechaCobraIni);
                    _ = cmd.Parameters.AddWithValue("@FECHA_COBRANZA_FIN", fechaCobraFin);
                    _ = cmd.Parameters.AddWithValue("@COD_PROGRAMA", codPrograma);
                    _ = cmd.Parameters.AddWithValue("@COD_INSTITUCION", codInstitucion);
                    _ = cmd.Parameters.AddWithValue("@COD_TIPO_PLLA", codTipoPlla);
                    _ = cmd.Parameters.AddWithValue("@NRO_CUOTA", nroCuota);

                    cn.Open();
                    DataTable dt = new DataTable();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        dt.Load(dr, LoadOption.Upsert);
                    }
                    return dt;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool EliminarContratoComisionExcluidos(List<ComisionContrato> lstCom)
        {
            const string procedure = "dsp_EliminarContratosExcluidos";
            conn.Open();
            using (SqlTransaction transaction = conn.BeginTransaction())
            {
                try
                {
                    foreach (ComisionContrato item in lstCom)
                    {
                        using (var cmd = new SqlCommand())
                        {
                            cmd.Connection = conn;
                            cmd.Transaction = transaction;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = procedure;

                            _ = cmd.Parameters.AddWithValue("@COD_SUCURSAL", item.COD_SUCURSAL);
                            _ = cmd.Parameters.AddWithValue("@COD_CLASE", item.COD_CLASE);
                            _ = cmd.Parameters.AddWithValue("@NRO_CONTRATO", item.NRO_CONTRATO);
                            _ = cmd.Parameters.AddWithValue("@FE_AÑO", item.FE_AÑO);
                            _ = cmd.Parameters.AddWithValue("@FE_MES", item.FE_MES);
                            _ = cmd.Parameters.AddWithValue("@NRO_CUOTA", item.NRO_CUOTA);

                            int result = cmd.ExecuteNonQuery();
                            if (result <= 0 || result > 1)
                            {
                                transaction.Rollback();
                                return false;
                            }
                        }
                    }
                    transaction.Commit();
                    conn.Close();
                    return true;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    conn.Close();
                    throw;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public bool ActualizarEstadoControComisionAProcesado(List<ComisionContrato> lstCom)
        {
            conn.Open();
            using (SqlTransaction transaction = conn.BeginTransaction())
            {
                try
                {
                    const string procedure = "dsp_ActualizarEstadoControComisionAProcesado";
                    foreach (ComisionContrato item in lstCom)
                    {
                        using (var cmd = new SqlCommand())
                        {
                            cmd.Connection = conn;
                            cmd.Transaction = transaction;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = procedure;
                            _ = cmd.Parameters.AddWithValue("@COD_SUCURSAL", item.COD_SUCURSAL);
                            _ = cmd.Parameters.AddWithValue("@COD_CLASE", item.COD_CLASE);
                            _ = cmd.Parameters.AddWithValue("@NRO_CONTRATO", item.NRO_CONTRATO);
                            _ = cmd.Parameters.AddWithValue("@FE_AÑO", item.FE_AÑO);
                            _ = cmd.Parameters.AddWithValue("@FE_MES", item.FE_MES);
                            _ = cmd.Parameters.AddWithValue("@NRO_CUOTA", item.NRO_CUOTA);
                            _ = cmd.Parameters.AddWithValue("@FE_AÑO_PER", item.FE_AÑO_PER);
                            _ = cmd.Parameters.AddWithValue("@FE_MES_PER", item.FE_MES_PER);
                            _ = cmd.Parameters.AddWithValue("@PERIODO_PROCESO", item.PERIODO_PROCESO);
                            _ = cmd.Parameters.AddWithValue("@USUARIO_MODIFICA", item.USUARIO);
                            if (cmd.ExecuteNonQuery() <= 0)
                            {
                                transaction.Rollback();
                                conn.Close();
                                return false;
                            }
                        }
                    }
                    transaction.Commit();
                    conn.Close();
                    return true;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    conn.Close();
                    throw;
                }
            }
        }

        public bool ActualizarEstadoControComisionAExcluidos(List<ComisionContrato> lstCom)
        {
            conn.Open();
            using (SqlTransaction transaction = conn.BeginTransaction())
            {
                try
                {
                    const string procedure = "dsp_ActualizarEstadoControComisionAExcluido";
                    foreach (ComisionContrato item in lstCom)
                    {
                        using (var cmd = new SqlCommand())
                        {
                            cmd.Connection = conn;
                            cmd.Transaction = transaction;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = procedure;
                            _ = cmd.Parameters.AddWithValue("@COD_SUCURSAL", item.COD_SUCURSAL);
                            _ = cmd.Parameters.AddWithValue("@COD_CLASE", item.COD_CLASE);
                            _ = cmd.Parameters.AddWithValue("@NRO_CONTRATO", item.NRO_CONTRATO);
                            _ = cmd.Parameters.AddWithValue("@FE_AÑO", item.FE_AÑO);
                            _ = cmd.Parameters.AddWithValue("@FE_MES", item.FE_MES);
                            _ = cmd.Parameters.AddWithValue("@NRO_CUOTA", item.NRO_CUOTA);
                            _ = cmd.Parameters.AddWithValue("@USUARIO_MODIFICA", item.USUARIO);
                            if (cmd.ExecuteNonQuery() <= 0)
                            {
                                transaction.Rollback();
                                conn.Close();
                                return false;
                            }
                        }
                    }
                    transaction.Commit();
                    conn.Close();
                    return true;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    conn.Close();
                    throw;
                }
            }
        }

        public bool InsertarComisionContratoAPeriodoExistente(List<ComisionContrato> lstCom)
        {
            conn.Open();
            using (SqlTransaction transaction = conn.BeginTransaction())
            {
                try
                {
                    const string procedure = "dsp_InsertarComisionCopntrato";
                    foreach (ComisionContrato item in lstCom)
                    {
                        using (var cmd = new SqlCommand())
                        {
                            cmd.Connection = conn;
                            cmd.Transaction = transaction;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = procedure;
                            _ = cmd.Parameters.AddWithValue("@COD_SUCURSAL", item.COD_SUCURSAL);
                            _ = cmd.Parameters.AddWithValue("@COD_CLASE", item.COD_CLASE);
                            _ = cmd.Parameters.AddWithValue("@NRO_CONTRATO", item.NRO_CONTRATO);
                            _ = cmd.Parameters.AddWithValue("@FE_AÑO", item.FE_AÑO);
                            _ = cmd.Parameters.AddWithValue("@FE_MES", item.FE_MES);
                            _ = cmd.Parameters.AddWithValue("@NRO_CUOTA", item.NRO_CUOTA);
                            _ = cmd.Parameters.AddWithValue("@FE_AÑO_PER", item.FE_AÑO_PER);
                            _ = cmd.Parameters.AddWithValue("@FE_MES_PER", item.FE_MES_PER);
                            _ = cmd.Parameters.AddWithValue("@FECHA_APROB_INI", item.FECHA_APROB_INI);
                            _ = cmd.Parameters.AddWithValue("@FECHA_APROB_FIN", item.FECHA_APROB_FIN);
                            _ = cmd.Parameters.AddWithValue("@FECHA_COBRA_INI", item.FECHA_COBRA_INI);
                            _ = cmd.Parameters.AddWithValue("@FECHA_COBRA_FIN", item.FECHA_COBRA_FIN);
                            _ = cmd.Parameters.AddWithValue("@PERIODO_PROCESO", item.PERIODO_PROCESO);
                            _ = cmd.Parameters.AddWithValue("@FE_AÑO_SIS", item.FE_AÑO_SIS);
                            _ = cmd.Parameters.AddWithValue("@FE_MES_SIS", item.FE_MES_SIS);
                            if (item.ID_COMISION_VEND == 0)
                                _ = cmd.Parameters.AddWithValue("@ID_COMISION_VEND", DBNull.Value);
                            else
                                _ = cmd.Parameters.AddWithValue("@ID_COMISION_VEND", item.ID_COMISION_VEND);
                            if (item.ID_COMISION_SUP == 0)
                                _ = cmd.Parameters.AddWithValue("@ID_COMISION_SUP", DBNull.Value);
                            else
                                _ = cmd.Parameters.AddWithValue("@ID_COMISION_SUP", item.ID_COMISION_SUP);
                            if (item.ID_CONF_SUP == 0)
                                _ = cmd.Parameters.AddWithValue("@ID_CONF_SUP", DBNull.Value);
                            else
                                _ = cmd.Parameters.AddWithValue("@ID_CONF_SUP", item.ID_CONF_SUP);
                            if (item.ID_COMISION_DIR_VTAS == 0)
                                _ = cmd.Parameters.AddWithValue("@ID_COMISION_DIR_VTAS", DBNull.Value);
                            else
                                _ = cmd.Parameters.AddWithValue("@ID_COMISION_DIR_VTAS", item.ID_COMISION_DIR_VTAS);
                            if (item.ID_CONF_DIR_VTAS == 0)
                                _ = cmd.Parameters.AddWithValue("@ID_CONF_DIR_VTAS", DBNull.Value);
                            else
                                _ = cmd.Parameters.AddWithValue("@ID_CONF_DIR_VTAS", item.ID_CONF_DIR_VTAS);
                            if (item.ID_COMISION_DIR_NCNAL == 0)
                                _ = cmd.Parameters.AddWithValue("@ID_COMISION_DIR_NCNAL", DBNull.Value);
                            else
                                _ = cmd.Parameters.AddWithValue("@ID_COMISION_DIR_NCNAL", item.ID_COMISION_DIR_NCNAL);
                            if (item.ID_CONF_DIR_NCNAL == 0)
                                _ = cmd.Parameters.AddWithValue("@ID_CONF_DIR_NCNAL", DBNull.Value);
                            else
                                _ = cmd.Parameters.AddWithValue("@ID_CONF_DIR_NCNAL", item.ID_CONF_DIR_NCNAL);
                            _ = cmd.Parameters.AddWithValue("@USUARIO_CREA", item.USUARIO);
                            _ = cmd.Parameters.AddWithValue("@ESTADO", item.ESTADO);
                            if (cmd.ExecuteNonQuery() <= 0)
                            {
                                transaction.Rollback();
                                conn.Close();
                                return false;
                            }
                        }
                    }
                    transaction.Commit();
                    conn.Close();
                    return true;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    conn.Close();
                    throw;
                }
            }
        }

        public bool InsertarComisionContratoAPeriodoExistente(ComisionContrato com)
        {
            conn.Open();
            using (SqlTransaction transaction = conn.BeginTransaction())
            {
                try
                {
                    const string procedure = "dsp_InsertarComisionCopntrato";

                    using (var cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.Transaction = transaction;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = procedure;
                        _ = cmd.Parameters.AddWithValue("@COD_SUCURSAL", com.COD_SUCURSAL);
                        _ = cmd.Parameters.AddWithValue("@COD_CLASE", com.COD_CLASE);
                        _ = cmd.Parameters.AddWithValue("@NRO_CONTRATO", com.NRO_CONTRATO);
                        _ = cmd.Parameters.AddWithValue("@FE_AÑO", com.FE_AÑO);
                        _ = cmd.Parameters.AddWithValue("@FE_MES", com.FE_MES);
                        _ = cmd.Parameters.AddWithValue("@NRO_CUOTA", com.NRO_CUOTA);
                        _ = cmd.Parameters.AddWithValue("@FE_AÑO_PER", com.FE_AÑO_PER);
                        _ = cmd.Parameters.AddWithValue("@FE_MES_PER", com.FE_MES_PER);
                        _ = cmd.Parameters.AddWithValue("@FECHA_APROB_INI", com.FECHA_APROB_INI);
                        _ = cmd.Parameters.AddWithValue("@FECHA_APROB_FIN", com.FECHA_APROB_FIN);
                        _ = cmd.Parameters.AddWithValue("@FECHA_COBRA_INI", com.FECHA_COBRA_INI);
                        _ = cmd.Parameters.AddWithValue("@FECHA_COBRA_FIN", com.FECHA_COBRA_FIN);
                        _ = cmd.Parameters.AddWithValue("@PERIODO_PROCESO", com.PERIODO_PROCESO);
                        _ = cmd.Parameters.AddWithValue("@FE_AÑO_SIS", com.FE_AÑO_SIS);
                        _ = cmd.Parameters.AddWithValue("@FE_MES_SIS", com.FE_MES_SIS);
                        if (com.ID_COMISION_VEND == 0)
                            _ = cmd.Parameters.AddWithValue("@ID_COMISION_VEND", DBNull.Value);
                        else
                            _ = cmd.Parameters.AddWithValue("@ID_COMISION_VEND", com.ID_COMISION_VEND);
                        if (com.ID_CONF_VEND == 0)
                            _ = cmd.Parameters.AddWithValue("@ID_CONF_VEND", DBNull.Value);
                        else
                            _ = cmd.Parameters.AddWithValue("@ID_CONF_VEND", com.ID_CONF_VEND);
                        if (com.ID_COMISION_SUP == 0)
                            _ = cmd.Parameters.AddWithValue("@ID_COMISION_SUP", DBNull.Value);
                        else
                            _ = cmd.Parameters.AddWithValue("@ID_COMISION_SUP", com.ID_COMISION_SUP);
                        if (com.ID_CONF_SUP == 0)
                            _ = cmd.Parameters.AddWithValue("@ID_CONF_SUP", DBNull.Value);
                        else
                            _ = cmd.Parameters.AddWithValue("@ID_CONF_SUP", com.ID_CONF_SUP);
                        if (com.ID_COMISION_DIR_VTAS == 0)
                            _ = cmd.Parameters.AddWithValue("@ID_COMISION_DIR_VTAS", DBNull.Value);
                        else
                            _ = cmd.Parameters.AddWithValue("@ID_COMISION_DIR_VTAS", com.ID_COMISION_DIR_VTAS);
                        if (com.ID_CONF_DIR_VTAS == 0)
                            _ = cmd.Parameters.AddWithValue("@ID_CONF_DIR_VTAS", DBNull.Value);
                        else
                            _ = cmd.Parameters.AddWithValue("@ID_CONF_DIR_VTAS", com.ID_CONF_DIR_VTAS);
                        if (com.ID_COMISION_DIR_NCNAL == 0)
                            _ = cmd.Parameters.AddWithValue("@ID_COMISION_DIR_NCNAL", DBNull.Value);
                        else
                            _ = cmd.Parameters.AddWithValue("@ID_COMISION_DIR_NCNAL", com.ID_COMISION_DIR_NCNAL);
                        if (com.ID_CONF_DIR_NCNAL == 0)
                            _ = cmd.Parameters.AddWithValue("@ID_CONF_DIR_NCNAL", DBNull.Value);
                        else
                            _ = cmd.Parameters.AddWithValue("@ID_CONF_DIR_NCNAL", com.ID_CONF_DIR_NCNAL);
                        _ = cmd.Parameters.AddWithValue("@USUARIO_CREA", com.USUARIO);
                        _ = cmd.Parameters.AddWithValue("@FLAH", com.FLAH);
                        _ = cmd.Parameters.AddWithValue("@ESTADO", com.ESTADO);
                        if (cmd.ExecuteNonQuery() <= 0)
                        {
                            transaction.Rollback();
                            conn.Close();
                            return false;
                        }
                    }
                    transaction.Commit();
                    conn.Close();
                    return true;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    conn.Close();
                    throw;
                }
            }
        }

        public DataTable ObtenerContratoComisionGenerado(string codSucursal, string codClase, string nroContrato, string feAño, string feMes, string nroCuota)
        {
            const string procedure = "dsp_ObtenerContratosComisionGenerados";
            try
            {
                SqlCommand cmd = new SqlCommand(procedure, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                _ = cmd.Parameters.AddWithValue("@COD_SUCURSAL", codSucursal);
                _ = cmd.Parameters.AddWithValue("@COD_CLASE", codClase);
                _ = cmd.Parameters.AddWithValue("@NRO_CONTRATO", nroContrato);
                _ = cmd.Parameters.AddWithValue("@FE_AÑO", feAño);
                _ = cmd.Parameters.AddWithValue("@FE_MES", feMes);
                _ = cmd.Parameters.AddWithValue("@NRO_CUOTA", nroCuota);

                conn.Open();
                DataTable dt = new DataTable();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    dt.Load(dr, LoadOption.Upsert);
                }
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        public bool AprobarComisionesContrato(List<ComisionContrato> lstCom)
        {
            conn.Open();
            using (SqlTransaction transaction = conn.BeginTransaction())
            {
                try
                {
                    const string procedure = "dsp_AprobarComisionContrato";
                    foreach (ComisionContrato item in lstCom)
                    {
                        using (var cmd = new SqlCommand())
                        {
                            cmd.Connection = conn;
                            cmd.Transaction = transaction;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = procedure;
                            _ = cmd.Parameters.AddWithValue("@COD_SUCURSAL", item.COD_SUCURSAL);
                            _ = cmd.Parameters.AddWithValue("@COD_CLASE", item.COD_CLASE);
                            _ = cmd.Parameters.AddWithValue("@NRO_CONTRATO", item.NRO_CONTRATO);
                            _ = cmd.Parameters.AddWithValue("@FE_AÑO", item.FE_AÑO);
                            _ = cmd.Parameters.AddWithValue("@FE_MES", item.FE_MES);
                            _ = cmd.Parameters.AddWithValue("@NRO_CUOTA", item.NRO_CUOTA);
                            _ = cmd.Parameters.AddWithValue("@USUARIO_MODIFICA", item.USUARIO);
                            if (cmd.ExecuteNonQuery() <= 0)
                            {
                                transaction.Rollback();
                                conn.Close();
                                return false;
                            }
                        }
                    }
                    transaction.Commit();
                    conn.Close();
                    return true;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    conn.Close();
                    throw;
                }
            }
        }

        public DataTable ListarComisionContratoAprobado(string feAñoPer, string feMesPer, string periodoProceso, string codPrograma, string codInstitucion, string codTipoPlla, string nroCuota)
        {
            const string procedure = "dsp_ListaContratosComisionAprobados";
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion.con))
                {
                    SqlCommand cmd = new SqlCommand(procedure, cn)
                    {
                        CommandType = CommandType.StoredProcedure,
                        CommandTimeout = 7000
                    };

                    _ = cmd.Parameters.AddWithValue("@FE_AÑO_PER", feAñoPer);
                    _ = cmd.Parameters.AddWithValue("@FE_MES_PER", feMesPer);
                    _ = cmd.Parameters.AddWithValue("@PERIODO_PROCESO", periodoProceso);
                    _ = cmd.Parameters.AddWithValue("@COD_PROGRAMA", codPrograma);
                    _ = cmd.Parameters.AddWithValue("@COD_INSTITUCION", codInstitucion);
                    _ = cmd.Parameters.AddWithValue("@COD_TIPO_PLLA", codTipoPlla);
                    _ = cmd.Parameters.AddWithValue("@NRO_CUOTA", nroCuota);

                    cn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(dr, LoadOption.Upsert);
                        return dt;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool RecalcularComisionContrato(DataTable dt, DateTime fechaCobranzaIni)
        {
            conn.Open();
            try
            {
                const string procedure = "dsp_RecalcularComisionContrato";
                using (SqlTransaction tr = conn.BeginTransaction())
                {
                    SqlCommand cmd = new SqlCommand(procedure, conn, tr)
                    {
                        CommandType = CommandType.StoredProcedure,
                        CommandTimeout = 5000
                    };
                    _ = cmd.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@TYPE_COMISION_CONTRATO",
                        SqlDbType = SqlDbType.Structured,
                        TypeName = "TYPE_COMISION_CONTRATO",
                        Value = dt,
                    });
                    _ = cmd.Parameters.AddWithValue("@FECHA_COBRANZA_INI", fechaCobranzaIni);
                    bool result = cmd.ExecuteNonQuery() > 0;
                    tr.Commit();
                    return result;
                }
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

        public bool RecalcularComisionContrato2(DataTable dt, DateTime fechaCobranzaIni)
        {
            conn.Open();
            try
            {
                const string procedure = "dsp_RecalcularComisionContrato2";
                using (SqlTransaction tr = conn.BeginTransaction())
                {
                    SqlCommand cmd = new SqlCommand(procedure, conn, tr)
                    {
                        CommandType = CommandType.StoredProcedure,
                        CommandTimeout = 5000
                    };
                    _ = cmd.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@TYPE_COMISION_CONTRATO",
                        SqlDbType = SqlDbType.Structured,
                        TypeName = "TYPE_COMISION_CONTRATO",
                        Value = dt,
                    });
                    _ = cmd.Parameters.AddWithValue("@FECHA_COBRANZA_INI", fechaCobranzaIni);
                    bool result = cmd.ExecuteNonQuery() > 0;
                    tr.Commit();
                    return result;
                }
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

        public DataTable ObtenerContratoComisonExcluido(string nroContrato)
        {
            const string procedure = "dsp_ObtenerContratoComisonExcluido";
            try
            {
                SqlCommand cmd = new SqlCommand(procedure, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                _ = cmd.Parameters.AddWithValue("@NRO_CONTRATO", nroContrato);

                conn.Open();
                DataTable dt = new DataTable();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    dt.Load(dr, LoadOption.Upsert);
                }
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        public DataTable ListarContratosPendientes(DateTime fechaAprobFin, DateTime fechaCobraFin, string codPrograma,
            string codInstitucion, string codTipoPlla, string nroCuota)
        {
            const string procedure = "dsp_ListarContratosPendientes";
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion.con))
                {
                    SqlCommand cmd = new SqlCommand(procedure, cn)
                    {
                        CommandType = CommandType.StoredProcedure,
                        CommandTimeout = 7000
                    };

                    _ = cmd.Parameters.AddWithValue("@FECHA_APROBACION_FIN", fechaAprobFin);
                    _ = cmd.Parameters.AddWithValue("@FECHA_COBRANZA_FIN", fechaCobraFin);
                    _ = cmd.Parameters.AddWithValue("@COD_PROGRAMA", codPrograma);
                    _ = cmd.Parameters.AddWithValue("@COD_INSTITUCION", codInstitucion);
                    _ = cmd.Parameters.AddWithValue("@COD_TIPO_PLLA", codTipoPlla);
                    _ = cmd.Parameters.AddWithValue("@NRO_CUOTA", nroCuota);

                    cn.Open();
                    DataTable dt = new DataTable();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        dt.Load(dr, LoadOption.Upsert);
                    }
                    return dt;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DesaprobarComisionesContrato(List<ComisionContrato> lstCom)
        {
            conn.Open();
            using (SqlTransaction transaction = conn.BeginTransaction())
            {
                try
                {
                    const string procedure = "dsp_DesaprobarComisionContrato";
                    foreach (ComisionContrato item in lstCom)
                    {
                        using (var cmd = new SqlCommand())
                        {
                            cmd.Connection = conn;
                            cmd.Transaction = transaction;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = procedure;
                            _ = cmd.Parameters.AddWithValue("@COD_SUCURSAL", item.COD_SUCURSAL);
                            _ = cmd.Parameters.AddWithValue("@COD_CLASE", item.COD_CLASE);
                            _ = cmd.Parameters.AddWithValue("@NRO_CONTRATO", item.NRO_CONTRATO);
                            _ = cmd.Parameters.AddWithValue("@FE_AÑO", item.FE_AÑO);
                            _ = cmd.Parameters.AddWithValue("@FE_MES", item.FE_MES);
                            _ = cmd.Parameters.AddWithValue("@NRO_CUOTA", item.NRO_CUOTA);
                            _ = cmd.Parameters.AddWithValue("@USUARIO_MODIFICA", item.USUARIO);
                            if (cmd.ExecuteNonQuery() <= 0)
                            {
                                transaction.Rollback();
                                conn.Close();
                                return false;
                            }
                        }
                    }
                    transaction.Commit();
                    conn.Close();
                    return true;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    conn.Close();
                    throw;
                }
            }
        }

        public bool InsertarIDevolucionComision(List<DevolucionComisionITo> lstCom, SqlTransaction tr, SqlConnection cn)
        {
            try
            {
                const string procedure = "dsp_InsertarIDevolucionComision";
                foreach (DevolucionComisionITo item in lstCom)
                {
                    using (var cmd = new SqlCommand())
                    {
                        cmd.Connection = cn;
                        cmd.Transaction = tr;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = procedure;
                        _ = cmd.Parameters.AddWithValue("@ID_PROCESO", item.ID_PROCESO);
                        _ = cmd.Parameters.AddWithValue("@COD_SUCURSAL", item.COD_SUCURSAL);
                        _ = cmd.Parameters.AddWithValue("@COD_CLASE", item.COD_CLASE);
                        _ = cmd.Parameters.AddWithValue("@NRO_CONTRATO", item.NRO_CONTRATO);
                        _ = cmd.Parameters.AddWithValue("@FE_AÑO", item.FE_AÑO);
                        _ = cmd.Parameters.AddWithValue("@FE_MES", item.FE_MES);
                        _ = cmd.Parameters.AddWithValue("@FE_AÑO_PER", item.FE_AÑO_PER);
                        _ = cmd.Parameters.AddWithValue("@FE_MES_PER", item.FE_MES_PER);
                        _ = cmd.Parameters.AddWithValue("@FECHA_DEV_INI", item.FECHA_DEV_INI);
                        _ = cmd.Parameters.AddWithValue("@FECHA_DEV_FIN", item.FECHA_DEV_FIN);
                        _ = cmd.Parameters.AddWithValue("@NRO_CUOTA", item.NRO_CUOTA);
                        _ = cmd.Parameters.AddWithValue("@COD_NIVEL", item.COD_NIVEL);
                        _ = cmd.Parameters.AddWithValue("@COD_PER", item.COD_PER);
                        _ = cmd.Parameters.AddWithValue("@IMPORTE_COMISION", item.IMPORTE_COMISION);
                        _ = cmd.Parameters.AddWithValue("@USUARIO_CREA", item.USUARIO_CREA);
                        SqlParameter parameter = new SqlParameter("@ID_DEVOLUCION", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        _ = cmd.Parameters.Add(parameter);

                        if (cmd.ExecuteNonQuery() <= 0)
                            return false;
                        if (item.DevolucionComisionTTo != null)
                            item.DevolucionComisionTTo.ID_DEVOLUCION = Convert.ToInt32(parameter.Value);
                    }
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool InsertarTDevolucionComision(List<DevolucionComisionITo> lstCom, SqlTransaction tr, SqlConnection cn)
        {
            try
            {
                const string procedure = "dsp_InsertarTDevolucionComision";
                foreach (DevolucionComisionITo item in lstCom)
                {
                    if (item.DevolucionComisionTTo is null)
                        continue;
                    using (var cmd = new SqlCommand())
                    {
                        cmd.Connection = cn;
                        cmd.Transaction = tr;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = procedure;
                        _ = cmd.Parameters.AddWithValue("@ID_DEVOLUCION", item.DevolucionComisionTTo.ID_DEVOLUCION);
                        _ = cmd.Parameters.AddWithValue("@FE_AÑO_PER", item.DevolucionComisionTTo.FE_AÑO_PER);
                        _ = cmd.Parameters.AddWithValue("@FE_MES_PER", item.DevolucionComisionTTo.FE_MES_PER);
                        _ = cmd.Parameters.AddWithValue("@NRO_PLANILLA_DEV", item.DevolucionComisionTTo.NRO_PLANILLA_DEV);
                        _ = cmd.Parameters.AddWithValue("@COD_INSTITUCION_DEV", item.DevolucionComisionTTo.COD_INSTITUCION_DEV);
                        _ = cmd.Parameters.AddWithValue("@COD_CANAL_DSCTO_DEV", item.DevolucionComisionTTo.COD_CANAL_DSCTO_DEV);
                        _ = cmd.Parameters.AddWithValue("@FE_AÑO_DEV", item.DevolucionComisionTTo.FE_AÑO_DEV);
                        _ = cmd.Parameters.AddWithValue("@FE_MES_DEV", item.DevolucionComisionTTo.FE_MES_DEV);
                        _ = cmd.Parameters.AddWithValue("@TIPO_PLANILLA_DEV", item.DevolucionComisionTTo.TIPO_PLANILLA_DEV);
                        _ = cmd.Parameters.AddWithValue("@IMPORTE_DESCONTAR", item.DevolucionComisionTTo.IMPORTE_DESCONTAR);
                        _ = cmd.Parameters.AddWithValue("@SI_NO_DESCONTAR", item.DevolucionComisionTTo.SI_NO_DESCONTAR);
                        _ = cmd.Parameters.AddWithValue("@COD_MOTIVO_NO_DSCTO", item.DevolucionComisionTTo.COD_MOTIVO_NO_DSCTO);
                        _ = cmd.Parameters.AddWithValue("@USUARIO_CREA", item.DevolucionComisionTTo.USUARIO_CREA);

                        if (cmd.ExecuteNonQuery() <= 0)
                            return false;
                    }
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ActualizarTDevolucionComision(List<DevolucionComisionITo> lstCom, SqlTransaction tr, SqlConnection cn)
        {
            try
            {
                const string procedure = "dsp_ActualizarTDevolucionComision";
                foreach (DevolucionComisionITo item in lstCom)
                {
                    using (var cmd = new SqlCommand())
                    {
                        cmd.Connection = cn;
                        cmd.Transaction = tr;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = procedure;
                        _ = cmd.Parameters.AddWithValue("@ID_DEVOLUCION", item.DevolucionComisionTTo.ID_DEVOLUCION);
                        _ = cmd.Parameters.AddWithValue("@FE_AÑO_PER", item.DevolucionComisionTTo.FE_AÑO_PER);
                        _ = cmd.Parameters.AddWithValue("@FE_MES_PER", item.DevolucionComisionTTo.FE_MES_PER);
                        _ = cmd.Parameters.AddWithValue("@NRO_PLANILLA_DEV", item.DevolucionComisionTTo.NRO_PLANILLA_DEV);
                        _ = cmd.Parameters.AddWithValue("@COD_INSTITUCION_DEV", item.DevolucionComisionTTo.COD_INSTITUCION_DEV);
                        _ = cmd.Parameters.AddWithValue("@COD_CANAL_DSCTO_DEV", item.DevolucionComisionTTo.COD_CANAL_DSCTO_DEV);
                        _ = cmd.Parameters.AddWithValue("@FE_AÑO_DEV", item.DevolucionComisionTTo.FE_AÑO_DEV);
                        _ = cmd.Parameters.AddWithValue("@FE_MES_DEV", item.DevolucionComisionTTo.FE_MES_DEV);
                        _ = cmd.Parameters.AddWithValue("@TIPO_PLANILLA_DEV", item.DevolucionComisionTTo.TIPO_PLANILLA_DEV);
                        _ = cmd.Parameters.AddWithValue("@IMPORTE_DESCONTAR", item.DevolucionComisionTTo.IMPORTE_DESCONTAR);
                        _ = cmd.Parameters.AddWithValue("@SI_NO_DESCONTAR", item.DevolucionComisionTTo.SI_NO_DESCONTAR);
                        _ = cmd.Parameters.AddWithValue("@COD_MOTIVO_NO_DSCTO", item.DevolucionComisionTTo.COD_MOTIVO_NO_DSCTO);
                        _ = cmd.Parameters.AddWithValue("@USUARIO_MODIFICA", item.DevolucionComisionTTo.USUARIO_CREA);

                        if (cmd.ExecuteNonQuery() <= 0)
                            return false;
                    }
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable ListarDescuentoCuotaVigencia()
        {
            const string procedure = "dsp_ListarDescuentoCuotaVigencia";
            try
            {
                SqlCommand cmd = new SqlCommand(procedure, conn)
                {
                    CommandType = CommandType.StoredProcedure,
                };

                conn.Open();
                DataTable dt = new DataTable();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    dt.Load(dr, LoadOption.Upsert);
                }
                conn.Close();
                return dt;
            }
            catch (Exception)
            {
                conn.Close();
                throw;
            }
        }

        public bool InsertarDescuentoCuotaVigencia(DescuentoCuotaVigenciaTo to, SqlTransaction tr, SqlConnection cn)
        {
            try
            {
                const string procedure = "dsp_InsertarDescuentoCuotaVigencia";
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = cn;
                    cmd.Transaction = tr;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = procedure;
                    _ = cmd.Parameters.AddWithValue("@NRO_CUOTA", to.NRO_CUOTA);
                    _ = cmd.Parameters.AddWithValue("@FECHA_INI_VIGENCIA", to.FECHA_INI_VIGENCIA);
                    _ = cmd.Parameters.AddWithValue("@FECHA_FIN_VIGENCIA", to.FECHA_FIN_VIGENCIA);
                    _ = cmd.Parameters.AddWithValue("@USUARIO_CREA", to.USUARIO_CREA);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ActualizarDescuentoCuotaVigencia(DescuentoCuotaVigenciaTo to, SqlTransaction tr, SqlConnection cn)
        {
            try
            {
                const string procedure = "dsp_ActualizarDescuentoCuotaVigencia";
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = cn;
                    cmd.Transaction = tr;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = procedure;
                    _ = cmd.Parameters.AddWithValue("@ID", to.ID);
                    _ = cmd.Parameters.AddWithValue("@NRO_CUOTA", to.NRO_CUOTA);
                    _ = cmd.Parameters.AddWithValue("@FECHA_INI_VIGENCIA", to.FECHA_INI_VIGENCIA);
                    _ = cmd.Parameters.AddWithValue("@FECHA_FIN_VIGENCIA", to.FECHA_FIN_VIGENCIA);
                    _ = cmd.Parameters.AddWithValue("USUARIO_MODIFICA", to.USUARIO_MODIFICA);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool EliminarDescuentoCuotaVigencia(DescuentoCuotaVigenciaTo to)
        {
            try
            {
                const string procedure = "dsp_EliminarDescuentoCuotaVigencia";
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = procedure;
                    _ = cmd.Parameters.AddWithValue("@ID", to.ID);
                    conn.Open();
                    bool result = cmd.ExecuteNonQuery() > 0;
                    conn.Close();
                    return result;
                }
            }
            catch (Exception)
            {
                conn.Close();
                throw;
            }
        }

        public bool ValidarExistenciaDescCuotaVigencia(DescuentoCuotaVigenciaTo to)
        {
            try
            {
                const string query = "SELECT '' FROM DESCUENTO_CUOTA_VIGENCIA WHERE FECHA_INI_VIGENCIA = @FECHA_INI_VIGENCIA";
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    _ = cmd.Parameters.Add("@FECHA_INI_VIGENCIA", SqlDbType.Date).Value = to.FECHA_INI_VIGENCIA;
                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        bool result = dr.Read();
                        conn.Close();
                        return result;
                    }
                }
            }
            catch (Exception)
            {
                conn.Close();
                throw;
            }
        }

        public DescuentoCuotaVigenciaTo ObtenerDescuentoFechaVigenciaMenor(DescuentoCuotaVigenciaTo to)
        {
            const string procedure = "dsp_ObtenerDescuentoFechaVigenciaMen";
            try
            {
                SqlCommand cmd = new SqlCommand(procedure, conn)
                {
                    CommandType = CommandType.StoredProcedure,
                };

                _ = cmd.Parameters.AddWithValue("@FECHA_INI_VIGENCIA", to.FECHA_INI_VIGENCIA);

                conn.Open();
                DescuentoCuotaVigenciaTo en = null;
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        en = new DescuentoCuotaVigenciaTo
                        {
                            ID = Convert.ToInt32(dr["ID"]),
                            NRO_CUOTA = dr["NRO_CUOTA"].ToString(),
                            FECHA_INI_VIGENCIA = Convert.ToDateTime(dr["FECHA_INI_VIGENCIA"]),
                            FECHA_FIN_VIGENCIA = Convert.ToDateTime(dr["FECHA_FIN_VIGENCIA"])
                        };
                    }
                }
                conn.Close();
                return en;
            }
            catch (Exception)
            {
                conn.Close();
                throw;
            }
        }

        public DescuentoCuotaVigenciaTo ObtenerDescuentoFechaVigenciaMayor(DescuentoCuotaVigenciaTo to)
        {
            const string procedure = "dsp_ObtenerDescuentoFechaVigenciaMay";
            try
            {
                SqlCommand cmd = new SqlCommand(procedure, conn)
                {
                    CommandType = CommandType.StoredProcedure,
                };

                _ = cmd.Parameters.AddWithValue("@FECHA_INI_VIGENCIA", to.FECHA_INI_VIGENCIA);

                conn.Open();
                DescuentoCuotaVigenciaTo en = null;
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        en = new DescuentoCuotaVigenciaTo
                        {
                            ID = Convert.ToInt32(dr["ID"]),
                            NRO_CUOTA = dr["NRO_CUOTA"].ToString(),
                            FECHA_INI_VIGENCIA = Convert.ToDateTime(dr["FECHA_INI_VIGENCIA"]),
                            FECHA_FIN_VIGENCIA = Convert.ToDateTime(dr["FECHA_FIN_VIGENCIA"])
                        };
                    }
                }
                conn.Close();
                return en;
            }
            catch (Exception)
            {
                conn.Close();
                throw;
            }
        }

        public DescuentoCuotaVigenciaTo ObtenerDescuentoFechaVigenciaMenor(DateTime fechaVigencia)
        {
            const string procedure = "dsp_ObtenerDescuentoFechaVigenciaMen";
            try
            {
                SqlCommand cmd = new SqlCommand(procedure, conn)
                {
                    CommandType = CommandType.StoredProcedure,
                };

                _ = cmd.Parameters.AddWithValue("@FECHA_INI_VIGENCIA", fechaVigencia);

                conn.Open();
                DescuentoCuotaVigenciaTo en = null;
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        en = new DescuentoCuotaVigenciaTo
                        {
                            ID = Convert.ToInt32(dr["ID"]),
                            NRO_CUOTA = dr["NRO_CUOTA"].ToString(),
                            FECHA_INI_VIGENCIA = Convert.ToDateTime(dr["FECHA_INI_VIGENCIA"]),
                            FECHA_FIN_VIGENCIA = Convert.ToDateTime(dr["FECHA_FIN_VIGENCIA"])
                        };
                    }
                }
                conn.Close();
                return en;
            }
            catch (Exception)
            {
                conn.Close();
                throw;
            }
        }

        public DescuentoCuotaVigenciaTo ObtenerDescuentoFechaVigenciaMayor(DateTime fechaVigencia)
        {
            const string procedure = "dsp_ObtenerDescuentoFechaVigenciaMay";
            try
            {
                SqlCommand cmd = new SqlCommand(procedure, conn)
                {
                    CommandType = CommandType.StoredProcedure,
                };

                _ = cmd.Parameters.AddWithValue("@FECHA_INI_VIGENCIA", fechaVigencia);

                conn.Open();
                DescuentoCuotaVigenciaTo en = null;
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        en = new DescuentoCuotaVigenciaTo
                        {
                            ID = Convert.ToInt32(dr["ID"]),
                            NRO_CUOTA = dr["NRO_CUOTA"].ToString(),
                            FECHA_INI_VIGENCIA = Convert.ToDateTime(dr["FECHA_INI_VIGENCIA"]),
                            FECHA_FIN_VIGENCIA = Convert.ToDateTime(dr["FECHA_FIN_VIGENCIA"])
                        };
                    }
                }
                conn.Close();
                return en;
            }
            catch (Exception)
            {
                conn.Close();
                throw;
            }
        }

        public DataTable ObtenerPeriodosDevolucionComisionGenerados()
        {
            const string procedure = "dsp_ObtenerPeridosDevolucionComisionGenerados";
            try
            {
                SqlCommand cmd = new SqlCommand(procedure, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                if (conn.State == ConnectionState.Closed) conn.Open();
                DataTable dt = new DataTable();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    dt.Load(dr, LoadOption.Upsert);
                }
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

        public DataTable ObtenerDevolucionComisionContratosGenerado(DevolucionComisionITo to)
        {
            const string procedure = "dsp_ObtenerDevolucionComisionContratosGenerado";
            try
            {
                SqlCommand cmd = new SqlCommand(procedure, conn)
                {
                    CommandType = CommandType.StoredProcedure,
                };

                _ = cmd.Parameters.AddWithValue("@COD_SUCURSAL", to.COD_SUCURSAL);
                _ = cmd.Parameters.AddWithValue("@COD_CLASE", to.COD_CLASE);
                _ = cmd.Parameters.AddWithValue("@NRO_CONTRATO", to.NRO_CONTRATO);
                _ = cmd.Parameters.AddWithValue("@FE_AÑO", to.FE_AÑO);
                _ = cmd.Parameters.AddWithValue("@FE_MES", to.FE_MES);
                _ = cmd.Parameters.AddWithValue("@NRO_CUOTA", to.NRO_CUOTA);
                _ = cmd.Parameters.AddWithValue("@COD_NIVEL", to.COD_NIVEL);
                _ = cmd.Parameters.AddWithValue("@COD_PER", to.COD_PER);
                _ = cmd.Parameters.AddWithValue("@FE_AÑO_PER", to.FE_AÑO_PER);
                _ = cmd.Parameters.AddWithValue("@FE_MES_PER", to.FE_MES_PER);

                conn.Open();
                DataTable dt = new DataTable();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    dt.Load(dr, LoadOption.Upsert);
                }
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

        public DataTable RptDevolucionLiquidacionComisiones(string codPrograma, DateTime fechaAprobIni, DateTime fechaAprobFin, DateTime fechaDevIni, DateTime fechaDevFin)
        {
            const string procedure = "dsp_RptDevolucionLiquidacionComisiones";
            try
            {
                SqlCommand cmd = new SqlCommand(procedure, conn)
                {
                    CommandType = CommandType.StoredProcedure,
                };

                _ = cmd.Parameters.AddWithValue("@COD_PROGRAMA", codPrograma);
                _ = cmd.Parameters.AddWithValue("@FECHA_APROB_INI", fechaAprobIni);
                _ = cmd.Parameters.AddWithValue("@FECHA_APROB_FIN", fechaAprobFin);
                _ = cmd.Parameters.AddWithValue("@FECHA_DEV_INI", fechaDevIni);
                _ = cmd.Parameters.AddWithValue("@FECHA_DEV_FIN", fechaDevFin);

                conn.Open();
                DataTable dt = new DataTable();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    dt.Load(dr, LoadOption.Upsert);
                }
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

        public bool InsertarComisionConfig(ComisionConfigTo comTo, SqlTransaction tr, SqlConnection cn)
        {
            const string procedure = "dps_InsertarComisionConfiguracion";
            try
            {
                foreach (personaTo item in comTo.LstVendedores)
                {
                    foreach (tipoPlanillaCreacionTo item2 in comTo.LstTipoPlanillaTo)
                    {
                        using (SqlCommand cmd = new SqlCommand(procedure, cn, tr))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            _ = cmd.Parameters.AddWithValue("@COD_VEND", item.COD_PER);
                            _ = cmd.Parameters.AddWithValue("@COD_NIVEL_VEND", item.NivelTo.COD_NIVEL);
                            if (comTo.PersonaSuperiTo == null)
                            {
                                _ = cmd.Parameters.AddWithValue("@COD_SUPERI", DBNull.Value);
                                _ = cmd.Parameters.AddWithValue("@COD_NIVEL_SUPERI", DBNull.Value);
                            }
                            else
                            {
                                _ = cmd.Parameters.AddWithValue("@COD_SUPERI", comTo.PersonaSuperiTo.COD_PER);
                                _ = cmd.Parameters.AddWithValue("@COD_NIVEL_SUPERI", comTo.PersonaSuperiTo.NivelTo.COD_NIVEL);
                            }
                            if (comTo.InstitucionTo == null)
                                _ = cmd.Parameters.AddWithValue("@COD_INSTITUCION", DBNull.Value);
                            else
                                _ = cmd.Parameters.AddWithValue("@COD_INSTITUCION", comTo.InstitucionTo.COD_INST);
                            _ = cmd.Parameters.AddWithValue("@NRO_CUOTA", comTo.NroCuota);
                            _ = cmd.Parameters.AddWithValue("@FECHA_INI_VIGENCIA", comTo.FechaIniVigencia);
                            _ = cmd.Parameters.AddWithValue("@FECHA_FIN_VIGENCIA", comTo.FechaFinVigencia);
                            _ = cmd.Parameters.AddWithValue("@IMPORTE", comTo.Importe);
                            _ = cmd.Parameters.AddWithValue("@PORCENTAJE", comTo.Porcentaje);
                            _ = cmd.Parameters.AddWithValue("@BASE_IMPONIBLE", comTo.BaseImponible);
                            _ = cmd.Parameters.AddWithValue("@CODIGO", item2.CODIGO);
                            _ = cmd.Parameters.AddWithValue("@COD_TIPO_PLLA", item2.COD_TIPO_PLLA);
                            _ = cmd.Parameters.AddWithValue("@ID_TIPO_COMISION", comTo.TipoComisionTo.IdTipoComision);
                            _ = cmd.Parameters.AddWithValue("@SI_COMISIONA", comTo.SiComisiona);
                            _ = cmd.Parameters.AddWithValue("@USUARIO_CREA", comTo.UsuarioCrea);

                            if (cmd.ExecuteNonQuery() <= 0)
                                return false;
                        }
                    }
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ActualizarComisionConfig(ComisionConfigTo comTo)
        {
            const string procedure = "dps_ActualizarComisionConfiguracion";
            try
            {
                SqlCommand cmd = new SqlCommand(procedure, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                _ = cmd.Parameters.AddWithValue("@ID_COMISION_CONF", comTo.IdComisionConfig);
                _ = cmd.Parameters.AddWithValue("@IMPORTE", comTo.Importe);
                _ = cmd.Parameters.AddWithValue("@PORCENTAJE", comTo.Porcentaje);
                _ = cmd.Parameters.AddWithValue("@BASE_IMPONIBLE", comTo.BaseImponible);
                _ = cmd.Parameters.AddWithValue("@SI_COMISIONA", comTo.SiComisiona);
                _ = cmd.Parameters.AddWithValue("@USUARIO_MODIFICA", comTo.UsuarioModifica);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public DataTable ListarConfiguracionComision(ComisionConfigTo to)
        {
            try
            {
                const string procedure = "dsp_ListarConfiguracionComision";
                SqlCommand cmd = new SqlCommand(procedure, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                _ = cmd.Parameters.AddWithValue("@FECHA_INI_VIGENCIA", to.FechaIniVigencia);
                _ = cmd.Parameters.AddWithValue("@COD_SUPERIOR", to.PersonaSuperiTo.COD_PER);
                _ = cmd.Parameters.AddWithValue("@COD_NIVEL_SUPERIOR", to.PersonaSuperiTo.NivelTo.COD_NIVEL);
                _ = cmd.Parameters.AddWithValue("@COD_TIPO_PLLA", to.TipoPlanillaTo.COD_TIPO_PLLA);

                conn.Open();
                DataTable dt = new DataTable();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    dt.Load(dr, LoadOption.Upsert);
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Obtiene las fechas vigencia de un determinado nivel de venta (SUPERIVISOR, DIRECTOR VENTA O NACIONAL)
        /// </summary>
        /// <param name="codSuperi">Código de persona de nivel venta(SUPERIVISOR, DIRECTOR VENTA O NACIONAL)</param>
        /// <param name="codNivelSuperi">Código de nivel de venta(SUPERIVISOR, DIRECTOR VENTA O NACIONAL)</param>
        /// <returns></returns>
        public DataTable ObtenerFechaIniVigenciaConfigComision(string codSuperi, string codNivelSuperi)
        {
            try
            {
                const string procedure = "dsp_ObtenerFechaIniVigenciaConfigComision";
                SqlCommand cmd = new SqlCommand(procedure, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                _ = cmd.Parameters.AddWithValue("@COD_SUPERI", codSuperi);
                _ = cmd.Parameters.AddWithValue("@COD_NIVEL_SUPERI", codNivelSuperi);

                conn.Open();
                DataTable dt = new DataTable();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    dt.Load(dr, LoadOption.Upsert);
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public DataTable ListarTipoFechaVigenciaComision()
        {
            const string procedure = "dsp_ListarTipoFechaVigenciaComision";
            try
            {
                SqlCommand cmd = new SqlCommand(procedure, conn)
                {
                    CommandType = CommandType.StoredProcedure,
                };

                conn.Open();
                DataTable dt = new DataTable();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    dt.Load(dr, LoadOption.Upsert);
                }
                conn.Close();
                return dt;
            }
            catch (Exception)
            {
                conn.Close();
                throw;
            }
        }

        public bool InsertarTipoFechaVigenciaComision(TipoVigenciaComision to, SqlTransaction tr, SqlConnection cn)
        {
            try
            {
                const string procedure = "dsp_InsertarTipoFechaVigenciaComision";
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = cn;
                    cmd.Transaction = tr;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = procedure;
                    _ = cmd.Parameters.AddWithValue("@TIPO_FECHA", to.TIPO_FECHA);
                    _ = cmd.Parameters.AddWithValue("@DESC_TIPO_FECHA", to.DESC_TIPO_FECHA);
                    _ = cmd.Parameters.AddWithValue("@FECHA_INI_VIGENCIA", to.FECHA_INI_VIGENCIA);
                    _ = cmd.Parameters.AddWithValue("@FECHA_FIN_VIGENCIA", to.FECHA_FIN_VIGENCIA);
                    _ = cmd.Parameters.AddWithValue("@USUARIO_CREA", to.USUARIO_CREA);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ActualizarTipoFechaVigenciaComision(TipoVigenciaComision to, SqlTransaction tr, SqlConnection cn)
        {
            try
            {
                const string procedure = "dsp_ActualizarTipoFechaVigenciaComision";
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = cn;
                    cmd.Transaction = tr;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = procedure;
                    _ = cmd.Parameters.AddWithValue("@ID", to.ID);
                    _ = cmd.Parameters.AddWithValue("@TIPO_FECHA", to.TIPO_FECHA);
                    _ = cmd.Parameters.AddWithValue("@DESC_TIPO_FECHA", to.DESC_TIPO_FECHA);
                    _ = cmd.Parameters.AddWithValue("@FECHA_INI_VIGENCIA", to.FECHA_INI_VIGENCIA);
                    _ = cmd.Parameters.AddWithValue("@FECHA_FIN_VIGENCIA", to.FECHA_FIN_VIGENCIA);
                    _ = cmd.Parameters.AddWithValue("USUARIO_MODIFICA", to.USUARIO_MODIFICA);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool EliminarTipoFechaVigenciaComision(TipoVigenciaComision to)
        {
            try
            {
                const string procedure = "dsp_EliminarTipoFechaVigenciaComision";
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = procedure;
                    _ = cmd.Parameters.AddWithValue("@ID", to.ID);
                    conn.Open();
                    bool result = cmd.ExecuteNonQuery() > 0;
                    conn.Close();
                    return result;
                }
            }
            catch (Exception)
            {
                conn.Close();
                throw;
            }
        }

        public TipoVigenciaComision ObtenerTipoFechaVigenciaComisionMayor(TipoVigenciaComision to)
        {
            const string procedure = "dsp_ObtenerTipoFechaVigenciaComisionMay";
            try
            {
                SqlCommand cmd = new SqlCommand(procedure, conn)
                {
                    CommandType = CommandType.StoredProcedure,
                };

                _ = cmd.Parameters.AddWithValue("@FECHA_INI_VIGENCIA", to.FECHA_INI_VIGENCIA);

                conn.Open();
                TipoVigenciaComision en = null;
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        en = new TipoVigenciaComision
                        {
                            ID = Convert.ToInt32(dr["ID"]),
                            TIPO_FECHA = Convert.ToInt32(dr["TIPO_FECHA"]),
                            DESC_TIPO_FECHA = dr["DESC_TIPO_FECHA"].ToString(),
                            FECHA_INI_VIGENCIA = Convert.ToDateTime(dr["FECHA_INI_VIGENCIA"]),
                            FECHA_FIN_VIGENCIA = DateTime.TryParse(dr["FECHA_FIN_VIGENCIA"].ToString(), out _) ? Convert.ToDateTime(dr["FECHA_FIN_VIGENCIA"]) : (DateTime?)null
                        };
                    }
                }
                conn.Close();
                return en;
            }
            catch (Exception)
            {
                conn.Close();
                throw;
            }
        }

        public TipoVigenciaComision ObtenerTipoFechaVigenciaComisionMenor(TipoVigenciaComision to)
        {
            const string procedure = "dsp_ObtenerTipoFechaVigenciaComisionMen";
            try
            {
                SqlCommand cmd = new SqlCommand(procedure, conn)
                {
                    CommandType = CommandType.StoredProcedure,
                };

                _ = cmd.Parameters.AddWithValue("@FECHA_INI_VIGENCIA", to.FECHA_INI_VIGENCIA);

                conn.Open();
                TipoVigenciaComision en = null;
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        en = new TipoVigenciaComision
                        {
                            ID = Convert.ToInt32(dr["ID"]),
                            TIPO_FECHA = Convert.ToInt32(dr["TIPO_FECHA"]),
                            DESC_TIPO_FECHA = dr["DESC_TIPO_FECHA"].ToString(),
                            FECHA_INI_VIGENCIA = Convert.ToDateTime(dr["FECHA_INI_VIGENCIA"]),
                            FECHA_FIN_VIGENCIA = DateTime.TryParse(dr["FECHA_FIN_VIGENCIA"].ToString(), out _) ? Convert.ToDateTime(dr["FECHA_FIN_VIGENCIA"]) : (DateTime?)null
                        };
                    }
                }
                conn.Close();
                return en;
            }
            catch (Exception)
            {
                conn.Close();
                throw;
            }
        }

        public TipoVigenciaComision ObtenerTipoFechaVigenciaComisionMenor(DateTime fechaIniVigencia)
        {
            const string procedure = "dsp_ObtenerTipoFechaVigenciaComisionMen";
            try
            {
                SqlCommand cmd = new SqlCommand(procedure, conn)
                {
                    CommandType = CommandType.StoredProcedure,
                };

                _ = cmd.Parameters.AddWithValue("@FECHA_INI_VIGENCIA", fechaIniVigencia);

                conn.Open();
                TipoVigenciaComision en = null;
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        en = new TipoVigenciaComision
                        {
                            ID = Convert.ToInt32(dr["ID"]),
                            TIPO_FECHA = Convert.ToInt32(dr["TIPO_FECHA"]),
                            DESC_TIPO_FECHA = dr["DESC_TIPO_FECHA"].ToString(),
                            FECHA_INI_VIGENCIA = Convert.ToDateTime(dr["FECHA_INI_VIGENCIA"]),
                            FECHA_FIN_VIGENCIA = DateTime.TryParse(dr["FECHA_FIN_VIGENCIA"].ToString(), out _) ? Convert.ToDateTime(dr["FECHA_FIN_VIGENCIA"]) : (DateTime?)null
                        };
                    }
                }
                conn.Close();
                return en;
            }
            catch (Exception)
            {
                conn.Close();
                throw;
            }
        }

        public DataTable ListarDevolucionComisionGenCancelados(DevolucionComisionITo to)
        {
            const string procedure = "dsp_ListarDevolucionComisionGenCancelados";
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion.con))
                {
                    SqlCommand cmd = new SqlCommand(procedure, cn)
                    {
                        CommandType = CommandType.StoredProcedure,
                        CommandTimeout = 7000
                    };

                    _ = cmd.Parameters.AddWithValue("@FE_AÑO_PER", to.FE_AÑO_PER);
                    _ = cmd.Parameters.AddWithValue("@FE_MES_PER", to.FE_MES_PER);
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr, LoadOption.Upsert);
                    dr.Close();
                    return dt;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable ListarDevolucionComisionGenAnulados(DevolucionComisionITo to)
        {
            const string procedure = "dsp_ListarDevolucionComisionGenAnulado";
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion.con))
                {
                    SqlCommand cmd = new SqlCommand(procedure, cn)
                    {
                        CommandType = CommandType.StoredProcedure,
                        CommandTimeout = 7000
                    };

                    _ = cmd.Parameters.AddWithValue("@FE_AÑO_PER", to.FE_AÑO_PER);
                    _ = cmd.Parameters.AddWithValue("@FE_MES_PER", to.FE_MES_PER);
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr, LoadOption.Upsert);
                    dr.Close();
                    return dt;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool RevertirDevolucionComision(List<DevolucionComisionTTo> lstTo)
        {
            const string procedure = "dsp_EliminarDevolucionComision";
            using (SqlConnection cn = new SqlConnection(conexion.con))
            {
                cn.Open();
                SqlTransaction tr = cn.BeginTransaction();
                try
                {
                    foreach (DevolucionComisionTTo item in lstTo)
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.Connection = cn;
                            cmd.Transaction = tr;
                            cmd.CommandText = procedure;
                            cmd.CommandType = CommandType.StoredProcedure;

                            _ = cmd.Parameters.AddWithValue("@ID_DEVOLUCION", item.ID_DEVOLUCION);
                            _ = cmd.Parameters.AddWithValue("@FE_AÑO_PER", item.FE_AÑO_PER);
                            _ = cmd.Parameters.AddWithValue("@FE_MES_PER", item.FE_MES_PER);

                            if (cmd.ExecuteNonQuery() <= 0)
                            {
                                tr.Rollback();
                                return false;
                            }
                        }
                    }
                    tr.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    tr?.Rollback();
                    throw ex;
                }
            }
        }

        public bool EliminarDevolucionComision(DevolucionComisionTTo to)
        {
            const string procedure = "dsp_EliminarDevolucionComision";
            using (SqlConnection cn = new SqlConnection(conexion.con))
            {
                cn.Open();
                try
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = cn;
                        cmd.CommandText = procedure;
                        cmd.CommandType = CommandType.StoredProcedure;

                        _ = cmd.Parameters.AddWithValue("@ID_DEVOLUCION", to.ID_DEVOLUCION);
                        _ = cmd.Parameters.AddWithValue("@FE_AÑO_PER", to.FE_AÑO_PER);
                        _ = cmd.Parameters.AddWithValue("@FE_MES_PER", to.FE_MES_PER);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public DataTable ObtenerDevolucionComisionXContrato(string nroContrato)
        {
            const string procedure = "dsp_ObtenerDevolucionComisionXContrato";
            try
            {
                SqlCommand cmd = new SqlCommand(procedure, conn)
                {
                    CommandType = CommandType.StoredProcedure,
                };

                _ = cmd.Parameters.AddWithValue("@NRO_CONTRATO", nroContrato);

                conn.Open();
                DataTable dt = new DataTable();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    dt.Load(dr, LoadOption.PreserveChanges);
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public List<DevolucionComisionITo> ObtenerTDevolucionComisionReg(DevolucionComisionITo to)
        {
            const string procedure = "dsp_ObtenerTDevolucionComision";
            try
            {
                List<DevolucionComisionITo> lista = new List<DevolucionComisionITo>();
                SqlCommand cmd = new SqlCommand(procedure, conn)
                {
                    CommandType = CommandType.StoredProcedure,
                };

                _ = cmd.Parameters.AddWithValue("@COD_SUCURSAL", to.COD_SUCURSAL);
                _ = cmd.Parameters.AddWithValue("@COD_CLASE", to.COD_CLASE);
                _ = cmd.Parameters.AddWithValue("@NRO_CONTRATO", to.NRO_CONTRATO);
                _ = cmd.Parameters.AddWithValue("@FE_AÑO", to.FE_AÑO);
                _ = cmd.Parameters.AddWithValue("@FE_MES", to.FE_MES);
                _ = cmd.Parameters.AddWithValue("@COD_NIVEL", to.COD_NIVEL);
                _ = cmd.Parameters.AddWithValue("@COD_PER", to.COD_PER);
                _ = cmd.Parameters.AddWithValue("@FE_AÑO_PER", to.DevolucionComisionTTo.FE_AÑO_PER);
                _ = cmd.Parameters.AddWithValue("@FE_MES_PER", to.DevolucionComisionTTo.FE_MES_PER);

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new DevolucionComisionITo
                        {
                            SALDO = Convert.ToDecimal(dr["SALDO"]),
                            DevolucionComisionTTo = new DevolucionComisionTTo
                            {
                                ID_DEVOLUCION = Convert.ToInt32(dr["ID_DEVOLUCION"]),
                                FE_AÑO_PER = dr["FE_AÑO_PER"].ToString(),
                                FE_MES_PER = dr["FE_MES_PER"].ToString(),
                                NRO_PLANILLA_DEV = dr["NRO_PLANILLA_DEV"].ToString(),
                                COD_INSTITUCION_DEV = dr["COD_INSTITUCION_DEV"].ToString(),
                                COD_CANAL_DSCTO_DEV = dr["COD_CANAL_DSCTO_DEV"].ToString(),
                                FE_AÑO_DEV = dr["FE_AÑO_DEV"].ToString(),
                                FE_MES_DEV = dr["FE_MES_DEV"].ToString(),
                                TIPO_PLANILLA_DEV = dr["TIPO_PLANILLA_DEV"].ToString(),
                                SI_NO_DESCONTAR = dr["SI_NO_DESCONTAR"].ToString(),
                            }
                        });
                    }
                }
                return lista;
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

        /// <summary>
        /// Obtiene la lista de vendedores con sus respectivos totales de comisiones, devoluciones, otros ingresos y egresos
        /// </summary>
        /// <param name="feAñoPer">Año del periodo</param>
        /// <param name="feMesPer">mes del periodo</param>
        /// <returns></returns>
        public DataTable ListarVendedoresComisionIngreEgre(string feAñoPer, string feMesPer)
        {
            const string procedure = "dsp_ListarVendedoresComisionIngreEgre";
            try
            {
                SqlCommand cmd = new SqlCommand(procedure, conn)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = TIME_OUT_2
                };

                _ = cmd.Parameters.AddWithValue("@FE_AÑO_PER", feAñoPer);
                _ = cmd.Parameters.AddWithValue("@FE_MES_PER", feMesPer);

                conn.Open();
                DataTable dt = new DataTable();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    dt.Load(dr, LoadOption.PreserveChanges);
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Obtiene los periodos generedos de comisiones y devoluciones
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable ObtenerPeriodoGeneradosComisionYDevolucion()
        {
            const string procedure = "dsp_ObtenerPeridosGeneradosComisionyDevolucion";
            try
            {
                SqlCommand cmd = new SqlCommand(procedure, conn)
                {
                    CommandType = CommandType.StoredProcedure,
                };

                conn.Open();
                DataTable dt = new DataTable();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    dt.Load(dr, LoadOption.PreserveChanges);
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Obtiene la lista de otros movimientos que tiene el vendedor como: adelantos, premios, bonos, penalidad, multa, etc.
        /// </summary>
        /// <param name="codVendedor">Código del vendedor</param>
        /// <returns>DataTable</returns>
        public DataTable ListarOtrosMovimientosXVendedor(MovimientosNivelVentaTo to)
        {
            const string procedure = "dsp_ListarMovimientosVendedor";
            try
            {
                SqlCommand cmd = new SqlCommand(procedure, conn)
                {
                    CommandType = CommandType.StoredProcedure,
                };

                _ = cmd.Parameters.AddWithValue("@COD_PER", to.COD_PER);
                _ = cmd.Parameters.AddWithValue("@FE_AÑO_PER", to.FE_AÑO_PER);
                _ = cmd.Parameters.AddWithValue("@FE_MES_PER", to.FE_MES_PER);

                conn.Open();
                DataTable dt = new DataTable();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    dt.Load(dr, LoadOption.PreserveChanges);
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Inserta movimientos de niveles de venta como adelantos, bonos, premios, sanciones
        /// </summary>
        /// <param name="to">Objeto MovimientsNivelVentaTo</param>
        /// <returns>true si se insertó correctamente, de lo contrario false</returns>
        public bool InsertarMovimientosNivelVenta(MovimientosNivelVentaTo to, SqlConnection cn, SqlTransaction tr)
        {
            const string procedure = "dsp_InsertarMovimientosNivelVenta";
            try
            {
                using (SqlCommand cmd = new SqlCommand(procedure, cn, tr))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    _ = cmd.Parameters.AddWithValue("@COD_PER", to.COD_PER);
                    _ = cmd.Parameters.AddWithValue("@COD_NIVEL", to.COD_NIVEL);
                    _ = cmd.Parameters.AddWithValue("@FECHA_MOVIMIENTO", to.FECHA_MOVIMIENTO);
                    _ = cmd.Parameters.AddWithValue("@FE_AÑO_PER", to.FE_AÑO_PER);
                    _ = cmd.Parameters.AddWithValue("@FE_MES_PER", to.FE_MES_PER);
                    _ = cmd.Parameters.AddWithValue("@TABLA_CON", to.TABLA_CON);
                    _ = cmd.Parameters.AddWithValue("@TIPO_CON", to.TIPO_CON);
                    _ = cmd.Parameters.AddWithValue("@CODIGO_CON", to.CODIGO_CON);
                    _ = cmd.Parameters.AddWithValue("@DESC_CON", to.DESC_CON);
                    _ = cmd.Parameters.AddWithValue("@TIPO_MOVIMIENTO", to.TIPO_MOVIMIENTO);
                    _ = cmd.Parameters.AddWithValue("@IMPORTE", to.IMPORTE);
                    _ = cmd.Parameters.AddWithValue("@USUARIO_CREA", to.USUARIO_CREA);
                    SqlParameter param = new SqlParameter("@ID_MOVIMIENTO", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    _ = cmd.Parameters.Add(param);

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        to.ID_MOVIMIENTO = Convert.ToInt32(param.Value);
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Elimina las configuraciones establecidas de la tabla CONFIGURACION_COMISION por ID_COMISION_CONF
        /// </summary>
        /// <param name="lstTo">Lista de ComisionConfigTo a eliminar</param>
        /// <returns>Un boolean, si se se eliminó correctamente es true de lo contrario false</returns>
        public bool EliminarConfiguracionComision(List<ComisionConfigTo> lstTo)
        {
            const string procedure = "dps_EliminarComisionConfiguracion";
            conn.Open();
            SqlTransaction tr = conn.BeginTransaction();
            try
            {
                foreach (ComisionConfigTo item in lstTo)
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = procedure;
                        cmd.Connection = conn;
                        cmd.Transaction = tr;
                        cmd.CommandType = CommandType.StoredProcedure;

                        _ = cmd.Parameters.AddWithValue("@ID_COMISION_CONF", item.IdComisionConfig);

                        if (cmd.ExecuteNonQuery() <= 0)
                        {
                            tr.Rollback();
                            return false;
                        }
                    }
                }
                tr.Commit();
                return true;
            }
            catch (Exception ex)
            {
                if (tr != null)
                    tr.Rollback();
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Actualiza movimientos de niveles de venta como adelantos, bonos, premios, sanciones
        /// </summary>
        /// <param name="to">Objeto MovimientsNivelVentaTo</param>
        /// <returns>true si se actualió correctamente, de lo contrario false</returns>
        public bool ActualizarMovimientosNivelVenta(MovimientosNivelVentaTo to, SqlConnection cn, SqlTransaction tr)
        {
            const string procedure = "dsp_ActualizarMovimientosNivelVenta";
            try
            {
                using (SqlCommand cmd = new SqlCommand(procedure, cn, tr))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    _ = cmd.Parameters.AddWithValue("@ID_MOVIMIENTO", to.ID_MOVIMIENTO);
                    _ = cmd.Parameters.AddWithValue("@TABLA_CON", to.TABLA_CON);
                    _ = cmd.Parameters.AddWithValue("@TIPO_CON", to.TIPO_CON);
                    _ = cmd.Parameters.AddWithValue("@CODIGO_CON", to.CODIGO_CON);
                    _ = cmd.Parameters.AddWithValue("@DESC_CON", to.DESC_CON);
                    _ = cmd.Parameters.AddWithValue("@TIPO_MOVIMIENTO", to.TIPO_MOVIMIENTO);
                    _ = cmd.Parameters.AddWithValue("@IMPORTE", to.IMPORTE);
                    _ = cmd.Parameters.AddWithValue("@USUARIO_MODIFICA", to.USUARIO_MODIFICA);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Elimina registro de la tabla MOVIMIENTOS_NIVEL_VENTA por ID_MOVIMIENTO
        /// </summary>
        /// <param name="to">Obteto MovimientosNivelVentaTo</param>
        /// <returns>true si se eliminó correctamente, false si no se eliminó correctamente</returns>
        public bool EliminarMovimientosNivelVenta(MovimientosNivelVentaTo to)
        {
            const string procedure = "dsp_EliminarMovimientosNivelVenta";
            conn.Open();
            try
            {
                using (SqlCommand cmd = new SqlCommand(procedure, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    _ = cmd.Parameters.AddWithValue("@ID_MOVIMIENTO", to.ID_MOVIMIENTO);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Inserta la liquidación(Comisión, devolución, otros ingresos, otros egresos)
        /// </summary>
        /// <param name="to">LiquidacionTo</param>
        /// <param name="cn">SqlConnection</param>
        /// <param name="tr">SqlTransaction</param>
        /// <returns></returns>
        public bool InsertarLiquidacionNivelVenta(LiquidacionTo to, SqlConnection cn, SqlTransaction tr)
        {
            const string procedure = "dsp_InsertarLiquidacion";
            try
            {
                using (SqlCommand cmd = new SqlCommand(procedure, cn, tr))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    _ = cmd.Parameters.AddWithValue("@NRO_LIQUIDACION", to.NRO_LIQUIDACION);
                    _ = cmd.Parameters.AddWithValue("@TIPO_LIQUIDACION", to.ID_TIPO_LIQUIDACION);
                    _ = cmd.Parameters.AddWithValue("@COD_PER", to.COD_PER);
                    _ = cmd.Parameters.AddWithValue("@FE_AÑO_PER", to.FE_AÑO_PER);
                    _ = cmd.Parameters.AddWithValue("@FE_MES_PER", to.FE_MES_PER);
                    _ = cmd.Parameters.AddWithValue("@IMPORTE", to.IMPORTE);
                    _ = cmd.Parameters.AddWithValue("@USUARIO_CREA", to.USUARIO_CREA);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Inserta la relación de número de liquidacion que corresponde a cada registro de la tabla COMISION_CONTRATO
        /// </summary>
        /// <param name="to">ComisionContrato</param>
        /// <param name="cn">SqlConnection</param>
        /// <param name="tr">SqlTransaction</param>
        /// <returns>true si se registró correctamente, de lo contrario false</returns>
        public bool InsertarComisionLiquidacionDet(ComisionLiquidacionDetTo to, SqlConnection cn, SqlTransaction tr)
        {
            const string procedure = "dsp_InsertarComisionLiquidacionDet";
            try
            {
                using (SqlCommand cmd = new SqlCommand(procedure, cn, tr))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    _ = cmd.Parameters.AddWithValue("@ID_PROCESO", to.ID_PROCESO);
                    _ = cmd.Parameters.AddWithValue("@NRO_LIQUIDACION", to.NRO_LIQUIDACION);
                    _ = cmd.Parameters.AddWithValue("@ID_TIPO_LIQUIDACION", to.ID_TIPO_LIQUIDACION);
                    _ = cmd.Parameters.AddWithValue("@USUARIO_CREA", to.USUARIO_CREA);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Elimina todo los registros de la tabla DETALLE_COMISION_LIQUIDACION por NRO_LIQUIDACION y ID_TIPO_LIQUIDACION
        /// </summary>
        /// <param name="to">ComisionLiquidacionDetTo</param>
        /// <param name="cn">SqlConnection</param>
        /// <param name="tr">SqlTransaction</param>
        /// <returns></returns>
        public bool EliminarComisionLiquidacionDet(ComisionLiquidacionDetTo to, SqlConnection cn, SqlTransaction tr)
        {
            const string procedure = "dsp_EliminarComisionLiquidacionDet";
            try
            {
                using (SqlCommand cmd = new SqlCommand(procedure, cn, tr))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    _ = cmd.Parameters.AddWithValue("@NRO_LIQUIDACION", to.NRO_LIQUIDACION);
                    _ = cmd.Parameters.AddWithValue("@ID_TIPO_LIQUIDACION", to.ID_TIPO_LIQUIDACION);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Obtien la lista de registro de comisiones para poder actualizarlos y relacionarlos con el
        /// número de liquidación que corresponde
        /// </summary>
        /// <param name="to">ComisionContrato</param>
        /// <param name="cn">SqlConnection</param>
        /// <param name="tr">SqlTransaction</param>
        /// <returns></returns>
        public List<ComisionContrato> ObtenerComisionToParaLiqui(ComisionContrato to, SqlConnection cn, SqlTransaction tr)
        {
            const string procedure = "dsp_ObtenerComisionParaLiqui";
            try
            {
                List<ComisionContrato> lista = new List<ComisionContrato>();
                SqlCommand cmd = new SqlCommand(procedure, cn, tr)
                {
                    CommandType = CommandType.StoredProcedure,
                };

                _ = cmd.Parameters.AddWithValue("@FE_AÑO_PER", to.FE_AÑO_PER);
                _ = cmd.Parameters.AddWithValue("@FE_MES_PER", to.FE_MES_PER);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new ComisionContrato
                        {
                            ID_PROCESO = Convert.ToInt32(dr["ID_PROCESO"]),
                            NRO_CONTRATO = dr["NRO_CONTRATO"].ToString(),
                            NRO_CUOTA = dr["NRO_CUOTA"].ToString(),
                            FE_AÑO_PER = dr["FE_AÑO_PER"].ToString(),
                            FE_MES_PER = dr["FE_MES_PER"].ToString(),
                            ComisionTo = new ComisionTo
                            {
                                PersonaTo = new personaTo
                                {
                                    COD_PER = dr["COD_PER"].ToString()
                                },
                                NivelTo = new nivelTo
                                {
                                    COD_NIVEL = dr["COD_NIVEL"].ToString()
                                }
                            },
                            Vendedor = new vendedorTo
                            {
                                COD_VEND = dr["COD_PER"].ToString(),
                            },
                            ComisionLiquidacionDetTo = new ComisionLiquidacionDetTo
                            {
                                ID_PROCESO = Convert.ToInt32(dr["ID_PROCESO"]),
                                TIPO_LIQUIDACION = (TIPO_LIQUIDACION)Convert.ToInt32(dr["TIPO_LIQUIDACION"])
                            }
                        });
                    }
                }
                return lista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Inserta el número de liquidacion que corresponde a cada registro de la tabla T_DEVOLUCION_COMISION
        /// </summary>
        /// <param name="to"></param>
        /// <param name="cn"></param>
        /// <param name="tr"></param>
        /// <returns>true si se registró correctamente, de lo contrario false</returns>
        public bool InsertarNroLiquidacionEnTDevolucionContrato(DevolucionComisionITo to, SqlConnection cn, SqlTransaction tr)
        {
            const string procedure = "dsp_InsertarNroLiquidacionTDevolucionContrato";
            try
            {
                using (SqlCommand cmd = new SqlCommand(procedure, cn, tr))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    _ = cmd.Parameters.AddWithValue("@IDT_DEVOLUCION", to.DevolucionComisionTTo.IDT_DEVOLUCION);
                    _ = cmd.Parameters.AddWithValue("@NRO_LIQUIDACION", to.DevolucionComisionTTo.NRO_LIQUIDACION);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Obtien la lista de registro de devoluciones para poder actualizarlos y relacionarlos con el
        /// número de liquidación que corresponde
        /// </summary>
        /// <param name="to">DevolucionComisionITo</param>
        /// <param name="cn">SqlConnection</param>
        /// <param name="tr">SqlTransaction</param>
        /// <returns></returns>
        public List<DevolucionComisionITo> ObtenerDevolucionComisionIToParaLiqui(DevolucionComisionITo to, SqlConnection cn, SqlTransaction tr)
        {
            const string procedure = "dsp_ObtenerDevolucionVendedorParaLiqui";
            try
            {
                List<DevolucionComisionITo> lista = new List<DevolucionComisionITo>();
                SqlCommand cmd = new SqlCommand(procedure, cn, tr)
                {
                    CommandType = CommandType.StoredProcedure,
                };

                _ = cmd.Parameters.AddWithValue("@FE_AÑO_PER", to.FE_AÑO_PER);
                _ = cmd.Parameters.AddWithValue("@FE_MES_PER", to.FE_MES_PER);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new DevolucionComisionITo
                        {
                            ID_DEVOLUCION = Convert.ToInt32(dr["ID_DEVOLUCION"]),
                            NRO_CONTRATO = dr["NRO_CONTRATO"].ToString(),
                            NRO_CUOTA = dr["NRO_CUOTA"].ToString(),
                            FE_AÑO_PER = dr["FE_AÑO_PER"].ToString(),
                            FE_MES_PER = dr["FE_MES_PER"].ToString(),
                            COD_PER = dr["COD_PER"].ToString(),
                            COD_NIVEL = dr["COD_NIVEL"].ToString(),
                            DevolucionComisionTTo = new DevolucionComisionTTo
                            {
                                IDT_DEVOLUCION = Convert.ToInt32(dr["IDT_DEVOLUCION"]),
                                IMPORTE_DESCONTAR = Convert.ToDecimal(dr["IMPORTE_DESCONTAR"])
                            }
                        });
                    }
                }
                return lista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Inserta el número de liquidacion que corresponde a cada registro de la tabla MOVIMIENTOS_NIVEL_VENTA
        /// </summary>
        /// <param name="to">MovimientosNivelVentaTo</param>
        /// <param name="cn">SqlConnection</param>
        /// <param name="tr">SqlTransaction</param>
        /// <returns>true si se registró correctamente, de lo contrario false</returns>
        public bool InsertarNroLiquidacionEnMovimientosNivelVenta(MovimientosNivelVentaTo to, SqlConnection cn, SqlTransaction tr)
        {
            const string procedure = "dsp_InsertarNroLiquidacionMovimientosNivelVenta";
            try
            {
                using (SqlCommand cmd = new SqlCommand(procedure, cn, tr))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    _ = cmd.Parameters.AddWithValue("@ID_MOVIMIENTO", to.ID_MOVIMIENTO);
                    _ = cmd.Parameters.AddWithValue("@NRO_LIQUIDACION", to.NRO_LIQUIDACION);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Obtien la lista de registro de otros ingresos y egresos de vendedores para poder actualizarlos y relacionarlos con el
        /// número de liquidación que corresponde
        /// </summary>
        /// <param name="to">MovimientosNivelVentaTo</param>
        /// <param name="cn">SqlConnection</param>
        /// <param name="tr">SqlTransaction</param>
        /// <returns></returns>
        public List<MovimientosNivelVentaTo> ObtenerOtrosMovimientosVendedorParaLiqui(MovimientosNivelVentaTo to, SqlConnection cn, SqlTransaction tr)
        {
            const string procedure = "dsp_ObtenerMovimientosVendedorParaLiqui";
            try
            {
                List<MovimientosNivelVentaTo> lista = new List<MovimientosNivelVentaTo>();
                SqlCommand cmd = new SqlCommand(procedure, cn, tr)
                {
                    CommandType = CommandType.StoredProcedure,
                };

                _ = cmd.Parameters.AddWithValue("@FE_AÑO_PER", to.FE_AÑO_PER);
                _ = cmd.Parameters.AddWithValue("@FE_MES_PER", to.FE_MES_PER);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new MovimientosNivelVentaTo
                        {
                            ID_MOVIMIENTO = Convert.ToInt32(dr["ID_MOVIMIENTO"]),
                            FE_AÑO_PER = dr["FE_AÑO_PER"].ToString(),
                            FE_MES_PER = dr["FE_MES_PER"].ToString(),
                            COD_PER = dr["COD_PER"].ToString(),
                            COD_NIVEL = dr["COD_NIVEL"].ToString(),
                            TIPO_MOVIMIENTO = Convert.ToInt32(dr["TIPO_MOVIMIENTO"]),
                            IMPORTE = Convert.ToDecimal(dr["IMPORTE"])
                        });
                    }
                }
                return lista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable ListarLiquidacionGenerada(LiquidacionTo to)
        {
            const string procedure = "dsp_ListarLiquidacionGenerada";
            try
            {
                SqlCommand cmd = new SqlCommand(procedure, conn)
                {
                    CommandType = CommandType.StoredProcedure,
                };

                _ = cmd.Parameters.AddWithValue("@FE_AÑO_PER", to.FE_AÑO_PER);
                _ = cmd.Parameters.AddWithValue("@FE_MES_PER", to.FE_MES_PER);

                conn.Open();
                DataTable dt = new DataTable();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    dt.Load(dr, LoadOption.Upsert);
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Obtiene Liquidacion generada por periodo
        /// </summary>
        /// <param name="to">LiquidacionTo</param>
        /// <returns>List<LiquidacionTo></returns>
        public List<LiquidacionTo> ListarLiquidacionGeneradaXPeriodo(LiquidacionTo to)
        {
            const string procedure = "dsp_ListarLiquidacionGenerada";
            try
            {
                List<LiquidacionTo> lista = new List<LiquidacionTo>();
                SqlCommand cmd = new SqlCommand(procedure, conn)
                {
                    CommandType = CommandType.StoredProcedure,
                };

                _ = cmd.Parameters.AddWithValue("@FE_AÑO_PER", to.FE_AÑO_PER);
                _ = cmd.Parameters.AddWithValue("@FE_MES_PER", to.FE_MES_PER);

                conn.Open();
                DataTable dt = new DataTable();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new LiquidacionTo
                        {
                            NRO_LIQUIDACION = dr["NRO_LIQUIDACION"].ToString(),
                            TIPO_LIQUIDACION = (TIPO_LIQUIDACION)Convert.ToInt32(dr["TIPO_LIQUIDACION"]),
                            COD_PER = dr["COD_PER"].ToString(),
                            FE_AÑO_PER = dr["FE_AÑO_PER"].ToString(),
                            FE_MES_PER = dr["FE_MES_PER"].ToString(),
                            IMPORTE = Convert.ToDecimal(dr["IMPORTE"]),
                            ID_TBANCO = !string.IsNullOrEmpty(Convert.ToString(dr["ID_TBANCO"])) ? Convert.ToInt32(dr["ID_TBANCO"]) : 0,
                            ESTADO = Convert.ToInt32(dr["ESTADO"])
                        });
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool EliminarLiquidacionNivelVenta(LiquidacionTo to, SqlConnection cn, SqlTransaction tr)
        {
            const string procedure = "dsp_EliminarLiquidacionNivelVentaXPeriodo";
            try
            {
                using (SqlCommand cmd = new SqlCommand(procedure, cn, tr))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    _ = cmd.Parameters.AddWithValue("@FE_AÑO_PER", to.FE_AÑO_PER);
                    _ = cmd.Parameters.AddWithValue("@FE_MES_PER", to.FE_MES_PER);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Obtiene liquidacion por persona, periodo y tipo de liquidacion
        /// </summary>
        /// <param name="to">Objeto LiquidacionTo</param>
        /// <param name="cn">SqlConnection</param>
        /// <param name="tr">SqlTransaction</param>
        /// <returns>Si existe entonces retorna un ojecto LiquidacionTo, de lo contrario null</returns>
        public LiquidacionTo ObtieneLiquidacionXPersonaTipoLiqu(LiquidacionTo to, SqlConnection cn, SqlTransaction tr)
        {
            const string procedure = "dsp_ObtenerLiquidacionTipoVenta";
            try
            {
                using (SqlCommand cmd = new SqlCommand(procedure, cn, tr))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    //> COD_PER, FE_AÑO_PER, FE_MES_PER, TIPO_LIQUIDACION => esto datos son únicos por cada periodo y persona
                    _ = cmd.Parameters.AddWithValue("@COD_PER", to.COD_PER);
                    _ = cmd.Parameters.AddWithValue("@FE_AÑO_PER", to.FE_AÑO_PER);
                    _ = cmd.Parameters.AddWithValue("@FE_MES_PER", to.FE_MES_PER);
                    _ = cmd.Parameters.AddWithValue("@TIPO_LIQUIDACION", to.ID_TIPO_LIQUIDACION);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            return new LiquidacionTo
                            {
                                NRO_LIQUIDACION = dr["NRO_LIQUIDACION"].ToString(),
                                TIPO_LIQUIDACION = (TIPO_LIQUIDACION)Convert.ToInt32(dr["TIPO_LIQUIDACION"]),
                                COD_PER = dr["COD_PER"].ToString(),
                                FE_AÑO_PER = dr["FE_AÑO_PER"].ToString(),
                                FE_MES_PER = dr["FE_MES_PER"].ToString(),
                                IMPORTE = Convert.ToDecimal(dr["IMPORTE"]),
                                ID_TBANCO = !string.IsNullOrEmpty(Convert.ToString(dr["ID_TBANCO"])) ? Convert.ToInt32(dr["ID_TBANCO"]) : 0,
                                ESTADO = Convert.ToInt32(dr["ESTADO"])
                            };
                        }
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Actualiza las liquidaciones por nro de liquidación
        /// </summary>
        /// <param name="to">LiquidacionTo</param>
        /// <param name="cn">SqlConnection</param>
        /// <param name="tr">SqlTransaction</param>
        /// <returns>true si se actualizó correctamente, de lo contrario false</returns>
        public bool ActualizarLiquidacionNivelVenta(LiquidacionTo to, SqlConnection cn, SqlTransaction tr)
        {
            const string procedure = "dsp_ActualizarLiquidacionNivelVenta";
            try
            {
                using (SqlCommand cmd = new SqlCommand(procedure, cn, tr))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    _ = cmd.Parameters.AddWithValue("@NRO_LIQUIDACION", to.NRO_LIQUIDACION);
                    _ = cmd.Parameters.AddWithValue("@USUARIO_MODIFICA", to.USUARIO_MODIFICA);
                    _ = cmd.Parameters.AddWithValue("@IMPORTE", to.IMPORTE);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Inserta nulo en la columna NRO_LIQUIDACION de la tabla T_DEVOLUCION_COMISION para desasociar con la liquidación generada
        /// ya que se va eliminar
        /// </summary>
        /// <param name="to"></param>
        /// <param name="cn"></param>
        /// <param name="tr"></param>
        /// <returns></returns>
        public bool EliminarNroLiquidacionDevolucion(DevolucionComisionTTo to, SqlConnection cn, SqlTransaction tr)
        {
            const string procedure = "dsp_EliminarNroLiquidacionDevolucion";
            try
            {
                using (SqlCommand cmd = new SqlCommand(procedure, cn, tr))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    _ = cmd.Parameters.AddWithValue("@NRO_LIQUIDACION", to.NRO_LIQUIDACION);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Inserta nulo en la columna NRO_LIQUIDACION de la tabla MOVIMIENTOS_NIVEL_VENTA para desasociar con la liquidación generada
        /// ya que se va eliminar
        /// </summary>
        /// <param name="to"></param>
        /// <param name="cn"></param>
        /// <param name="tr"></param>
        /// <returns></returns>
        public bool EliminarNroLiquidacionMovimientoNivVenta(MovimientosNivelVentaTo to, SqlConnection cn, SqlTransaction tr)
        {
            const string procedure = "dsp_EliminarNroLiquidacionMovimientoNivVenta";
            try
            {
                using (SqlCommand cmd = new SqlCommand(procedure, cn, tr))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    _ = cmd.Parameters.AddWithValue("@NRO_LIQUIDACION", to.NRO_LIQUIDACION);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Reporte de todas las liquidaciones(comisiones, devoluciones, otros ingresos, otros egresos) por persona de un periodo
        /// </summary>
        /// <param name="to">Objeto dónde se envía el periodo para filtrar</param>
        /// <returns>DataTable</returns>
        public DataTable RptLiquidacionResumenXPersona(LiquidacionTo to)
        {
            const string procedure = "dsp_RptLiquidacionResumenXPersona";
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion.con))
                {
                    SqlCommand cmd = new SqlCommand(procedure, cn)
                    {
                        CommandType = CommandType.StoredProcedure,
                        CommandTimeout = TIME_OUT_2
                    };

                    _ = cmd.Parameters.AddWithValue("@FE_AÑO_PER", to.FE_AÑO_PER);
                    _ = cmd.Parameters.AddWithValue("@FE_MES_PER", to.FE_MES_PER);
                    _ = cmd.Parameters.AddWithValue("@COD_PER", to.COD_PER);

                    cn.Open();
                    DataTable dt = new DataTable();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        dt.Load(dr, LoadOption.Upsert);
                    }
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Obtiene un DataTable con todos los movimientos necesarios para calcular el saldo anterior(comisiones, devoluciones, otros ingresos, otros egresos) por persona de un periodo
        /// </summary>
        /// <param name="to">Objeto dónde se envía el periodo para filtrar</param>
        /// <returns>DataTable</returns>
        public DataTable LiquidacionSaldoAnteriorXPersona(LiquidacionTo to)
        {
            const string procedure = "dsp_RptLiquidacionResumenXPersona2";
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion.con))
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand(procedure, cn)
                    {
                        CommandType = CommandType.StoredProcedure,
                        CommandTimeout = TIME_OUT_2
                    };

                    _ = cmd.Parameters.AddWithValue("@FE_AÑO_PER", to.FE_AÑO_PER);
                    _ = cmd.Parameters.AddWithValue("@FE_MES_PER", to.FE_MES_PER);
                    _ = cmd.Parameters.AddWithValue("@COD_PER", to.COD_PER);

                    DataTable dt = new DataTable();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        dt.Load(dr, LoadOption.Upsert);
                    }
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Obtiene un dataTable solo de las fechas de vigencia de configuración comisión por institución
        /// </summary>
        /// <param name="codInstitucion">Código de institución</param>
        /// <returns>DataTable</returns>
        public DataTable ObtenerFechaIniVigenciaConfigComisionInstitu(string codInstitucion)
        {
            try
            {
                const string procedure = "dsp_ObtenerFechaIniVigenciaConfigComisionInstitu";
                SqlCommand cmd = new SqlCommand(procedure, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                _ = cmd.Parameters.AddWithValue("@COD_INSTITUCION", codInstitucion);

                conn.Open();
                DataTable dt = new DataTable();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    dt.Load(dr, LoadOption.Upsert);
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Obtiene la comisión de vendedores y superiores(supervisor, director de venta, director nacional) por institución
        /// </summary>
        /// <param name="to">Objeto ComisionConfigTo dónde se pasa la fecha de vigencia, codigo de istitución y tipo de venta para filtrar</param>
        /// <returns></returns>
        public DataTable ListarConfiguracionComisionInstitu(ComisionConfigTo to)
        {
            try
            {
                const string procedure = "dsp_ListarConfiguracionComisionInstitu";
                SqlCommand cmd = new SqlCommand(procedure, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                _ = cmd.Parameters.AddWithValue("@FECHA_INI_VIGENCIA", to.FechaIniVigencia);
                _ = cmd.Parameters.AddWithValue("@COD_INSTITUCION", to.InstitucionTo.COD_INST);
                _ = cmd.Parameters.AddWithValue("@COD_TIPO_PLLA", to.TipoPlanillaTo.COD_TIPO_PLLA);

                conn.Open();
                DataTable dt = new DataTable();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    dt.Load(dr, LoadOption.Upsert);
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Obtiene una lista de vendedores con el total de comisiones de contratos sin aprobar generados, total adelanto y total saldo
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable ListarVendedoresAdelantoComision(string codPrograma)
        {
            const string procedure = "dsp_ListarVendedoresAdelantoComision";
            try
            {
                SqlCommand cmd = new SqlCommand(procedure, conn)
                {
                    CommandType = CommandType.StoredProcedure,
                };

                _ = cmd.Parameters.AddWithValue("@COD_PROGRAMA", codPrograma);

                conn.Open();
                DataTable dt = new DataTable();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    dt.Load(dr, LoadOption.PreserveChanges);
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Obtiene una lista de contratos sin aprobar para realizar su adelanto de comisión
        /// </summary>
        /// <param name="codPrograma">Programas que dicta la empresa como inglés</param>
        /// <param name="codVendedor">Código del vendedor</param>
        /// <returns>DataTable</returns>
        public DataTable ListarContratosParaAdelantoComision(string codPrograma, string codVendedor, int nroAdelanto)
        {
            const string procedure = "dsp_ListarContratosParaAdelantoComision";
            try
            {
                SqlCommand cmd = new SqlCommand(procedure, conn)
                {
                    CommandType = CommandType.StoredProcedure,
                };

                _ = cmd.Parameters.AddWithValue("@COD_PROGRAMA", codPrograma);
                _ = cmd.Parameters.AddWithValue("@COD_VENDEDOR", codVendedor);
                _ = cmd.Parameters.AddWithValue("@NRO_ADELANTO", nroAdelanto);

                conn.Open();
                DataTable dt = new DataTable();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    dt.Load(dr, LoadOption.PreserveChanges);
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Inserta un nuevo registro en la tabla de adelanto comisiones(COMISION_ADELANTO)
        /// </summary>
        /// <param name="to">Objeto a registrar</param>
        /// <param name="cn">SqlConnection</param>
        /// <param name="tr">SqlTransaction</param>
        /// <returns></returns>
        public bool InsertarAdelantoComision(ComisionAdelantoTo to, SqlConnection cn, SqlTransaction tr)
        {
            const string procedure = "dsp_InsertarAdelantoComision";
            try
            {
                using (SqlCommand cmd = new SqlCommand(procedure, cn, tr))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    _ = cmd.Parameters.AddWithValue("@COD_CLIENTE", to.COD_CLIENTE);
                    _ = cmd.Parameters.AddWithValue("@COD_SUCURSAL", to.COD_SUCURSAL);
                    _ = cmd.Parameters.AddWithValue("@COD_CLASE", to.COD_CLASE);
                    _ = cmd.Parameters.AddWithValue("@NRO_CONTRATO", to.NRO_CONTRATO);
                    _ = cmd.Parameters.AddWithValue("@FE_AÑO", to.FE_AÑO);
                    _ = cmd.Parameters.AddWithValue("@FE_MES", to.FE_MES);
                    _ = cmd.Parameters.AddWithValue("@NRO_CUOTA", to.NRO_CUOTA);
                    _ = cmd.Parameters.AddWithValue("@COD_PER", to.COD_PER);
                    _ = cmd.Parameters.AddWithValue("@COD_NIVEL", to.COD_NIVEL);
                    _ = cmd.Parameters.AddWithValue("@TIPO", to.TIPO);
                    _ = cmd.Parameters.AddWithValue("@NRO_ADELANTO", to.NRO_ADELANTO);
                    _ = cmd.Parameters.AddWithValue("@IMPORTE_COMISION", to.IMPORTE_COMISION);
                    _ = cmd.Parameters.AddWithValue("@IMPORTE_ADELANTO", to.IMPORTE_ADELANTO);
                    _ = cmd.Parameters.AddWithValue("@USUARIO_CREA", to.USUARIO_CREA);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Actualiza un registro de adelanto comisión
        /// </summary>
        /// <param name="to"></param>
        /// <param name="cn"></param>
        /// <param name="tr"></param>
        /// <returns></returns>
        public bool ActualizarAdelantoComision(ComisionAdelantoTo to, SqlConnection cn, SqlTransaction tr)
        {
            const string procedure = "dsp_ActualizarAdelantoComision";
            try
            {
                using (SqlCommand cmd = new SqlCommand(procedure, cn, tr))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    _ = cmd.Parameters.AddWithValue("@ID_PROCESO", to.ID_PROCESO);
                    _ = cmd.Parameters.AddWithValue("@NRO_ADELANTO", to.NRO_ADELANTO);
                    _ = cmd.Parameters.AddWithValue("@IMPORTE_COMISION", to.IMPORTE_COMISION);
                    _ = cmd.Parameters.AddWithValue("@IMPORTE_ADELANTO", to.IMPORTE_ADELANTO);
                    _ = cmd.Parameters.AddWithValue("@USUARIO_MODIFICA", to.USUARIO_MODIFICA);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Elimina un registro de adelanto comisión
        /// </summary>
        /// <param name="to"></param>
        /// <returns></returns>
        public bool EliminarAdelantoComision(ComisionAdelantoTo to)
        {
            const string procedure = "dsp_EliminarAdelantoComision";
            try
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(procedure, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    _ = cmd.Parameters.AddWithValue("@ID_PROCESO", to.ID_PROCESO);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Cierra(es lo mismo que aprobar) un período de devolución de comisiones para que no se puedan modificar
        /// </summary>
        /// <param name="to">Objecto DevolucionComisionTTo dónde se pasa el periodo a cerrar</param>
        /// <returns></returns>
        public bool CerrarPeriodoAdelantoComision(DevolucionComisionTTo to)
        {
            const string procedure = "dsp_ActualizarEstadoTDevoluciones";
            try
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(procedure, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    _ = cmd.Parameters.AddWithValue("@ESTADO", (int)ESTADO_REGISTRO.REGISTRO_APROBADO);
                    _ = cmd.Parameters.AddWithValue("@FE_AÑO_PER", to.FE_AÑO_PER);
                    _ = cmd.Parameters.AddWithValue("@FE_MES_PER", to.FE_MES_PER);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Abre un período de devolución de comisiones para que se puedan modificar
        /// </summary>
        /// <param name="to">Objecto DevolucionComisionTTo dónde se pasa el periodo a cerrar</param>
        /// <returns></returns>
        public bool AbrirPeriodoAdelantoComision(DevolucionComisionTTo to)
        {
            const string procedure = "dsp_ActualizarEstadoTDevoluciones";
            try
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(procedure, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    _ = cmd.Parameters.AddWithValue("@ESTADO", (int)ESTADO_REGISTRO.REGISTRO_PROCESADO);
                    _ = cmd.Parameters.AddWithValue("@FE_AÑO_PER", to.FE_AÑO_PER);
                    _ = cmd.Parameters.AddWithValue("@FE_MES_PER", to.FE_MES_PER);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Inserta un nuevo registro de período de liquidación
        /// </summary>
        /// <param name="to">Objecto LiquidacionTo dónde se pasa el periodo a registrar</param>
        /// <returns></returns>
        public bool InsertarPeriodoLiquidacion(LiquidacionTo to)
        {
            const string procedure = "dsp_InsertarPeridoLiquidacion";
            try
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(procedure, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    _ = cmd.Parameters.AddWithValue("@FE_AÑO_PER", to.FE_AÑO_PER);
                    _ = cmd.Parameters.AddWithValue("@FE_MES_PER", to.FE_MES_PER);
                    _ = cmd.Parameters.AddWithValue("@USUARIO_CREA", to.USUARIO_CREA);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public DataTable ObtenerPeriodoLiquidacion(LiquidacionTo to)
        {
            const string sentencia = "SELECT * FROM PERIODO_LIQUIDACION WHERE FE_AÑO_PER = @FE_AÑO_PER AND FE_MES_PER = @FE_MES_PER";
            try
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sentencia, conn))
                {
                    cmd.CommandType = CommandType.Text;

                    _ = cmd.Parameters.AddWithValue("@FE_AÑO_PER", to.FE_AÑO_PER);
                    _ = cmd.Parameters.AddWithValue("@FE_MES_PER", to.FE_MES_PER);

                    DataTable dt = new DataTable();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        dt.Load(dr, LoadOption.Upsert);
                    }
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Cierra(es lo mismo que aprobar) un período de devolución de comisiones para que no se puedan modificar
        /// </summary>
        /// <param name="to">Objecto LiquidacionTo dónde se pasa el periodo a cerrar</param>
        /// <returns></returns>
        public bool CerrarPeriodoLiquidacion(LiquidacionTo to)
        {
            const string procedure = "dsp_ActualizarEstadoPeridoLiquidacion";
            try
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(procedure, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    _ = cmd.Parameters.AddWithValue("@ESTADO", (int)ESTADO_REGISTRO.REGISTRO_APROBADO);
                    _ = cmd.Parameters.AddWithValue("@FE_AÑO_PER", to.FE_AÑO_PER);
                    _ = cmd.Parameters.AddWithValue("@FE_MES_PER", to.FE_MES_PER);
                    _ = cmd.Parameters.AddWithValue("@USUARIO_MODIFICA", to.USUARIO_MODIFICA);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Abre un período de devolución de comisiones para que no se puedan modificar
        /// </summary>
        /// <param name="to">Objecto LiquidacionTo dónde se pasa el periodo a cerrar</param>
        /// <returns></returns>
        public bool AbrirPeriodoLiquidacion(LiquidacionTo to)
        {
            const string procedure = "dsp_ActualizarEstadoPeridoLiquidacion";
            try
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(procedure, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    _ = cmd.Parameters.AddWithValue("@ESTADO", (int)ESTADO_REGISTRO.REGISTRO_PROCESADO);
                    _ = cmd.Parameters.AddWithValue("@FE_AÑO_PER", to.FE_AÑO_PER);
                    _ = cmd.Parameters.AddWithValue("@FE_MES_PER", to.FE_MES_PER);
                    _ = cmd.Parameters.AddWithValue("@USUARIO_MODIFICA", to.USUARIO_MODIFICA);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool InsertarAsociarConceptoTesoreria(int idAsociar, string descripcion, int idConcepto, string usuarioCrea)
        {
            const string procedure = "dsp_InsertarAsociarConceptoTesoreria";
            try
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(procedure, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    _ = cmd.Parameters.AddWithValue("@ID_ASOCIAR", idAsociar);
                    _ = cmd.Parameters.AddWithValue("@DESCRIPCION", descripcion);
                    _ = cmd.Parameters.AddWithValue("@ID_CONCEPTO", idConcepto);
                    _ = cmd.Parameters.AddWithValue("@USUARIO_CREA", usuarioCrea);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool ActualizarAsociarConceptoTesoreria(int idAsociar, string descripcion, string usuarioModifica)
        {
            const string procedure = "dsp_ActualizarAsociarConceptoTesoreria";
            try
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(procedure, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    _ = cmd.Parameters.AddWithValue("@ID_ASOCIAR", idAsociar);
                    _ = cmd.Parameters.AddWithValue("@DESCRIPCION", descripcion);
                    _ = cmd.Parameters.AddWithValue("@USUARIO_MODIFICA", usuarioModifica);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool EliminarAsociarConceptoTesoreria(int idAsociar)
        {
            const string procedure = "dsp_EliminarAsociarConceptoTesoreria";
            try
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(procedure, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    _ = cmd.Parameters.AddWithValue("@ID_ASOCIAR", idAsociar);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool EliminarAsociarConceptoTesoreria(int idAsociar, int idConcepto)
        {
            const string procedure = "dsp_EliminarAsociarConceptoTesoreria2";
            try
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(procedure, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    _ = cmd.Parameters.AddWithValue("@ID_ASOCIAR", idAsociar);
                    _ = cmd.Parameters.AddWithValue("@ID_CONCEPTO", idConcepto);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public int ObtenerCorrelativoIdAsociar()
        {
            const string sentencia = "SELECT MAX(ID_ASOCIAR) FROM ASOCIAR_CONCEPTO_TESORERIA";
            try
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sentencia, conn))
                {
                    cmd.CommandType = CommandType.Text;

                    var result = cmd.ExecuteScalar();
                    return int.TryParse(Convert.ToString(result), out int val) ? val + 1 : 1;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool ValidarExistenciaAsociarConceptoTesoreria(int idAsociar)
        {
            const string sentencia = "SELECT '' FROM ASOCIAR_CONCEPTO_TESORERIA WHERE ID_ASOCIAR = @ID_ASOCIAR";
            try
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sentencia, conn))
                {
                    cmd.CommandType = CommandType.Text;

                    _ = cmd.Parameters.AddWithValue("@ID_ASOCIAR", idAsociar);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public DataTable ListarAsociarConceptoTesoreria()
        {
            const string sentencia = "SELECT ID_ASOCIAR, DESCRIPCION FROM ASOCIAR_CONCEPTO_TESORERIA GROUP BY ID_ASOCIAR, DESCRIPCION";
            try
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sentencia, conn))
                {
                    cmd.CommandType = CommandType.Text;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(dr, LoadOption.Upsert);
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public DataTable ListarAsociarConceptoTesoreriaXIdAsociar(int idAsociar)
        {
            const string sentencia = "SELECT ID_ASOCIAR, DESCRIPCION, ID_CONCEPTO FROM ASOCIAR_CONCEPTO_TESORERIA WHERE ID_ASOCIAR = @ID_ASOCIAR";
            try
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sentencia, conn))
                {
                    cmd.CommandType = CommandType.Text;

                    _ = cmd.Parameters.AddWithValue("@ID_ASOCIAR", idAsociar);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(dr, LoadOption.Upsert);
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Lista de adelanto de comisiones de contratos que faltan aprobar
        /// </summary>
        /// <param name="to">Objeto ComisionAdelantoTo dónde se pasa los parámetors de filtro</param>
        /// <returns></returns>
        public DataTable RptAdelantoComisionContratosSinAprobar(ComisionAdelantoTo to)
        {
            const string procedure = "dsp_RptAdelantoComisionContratosSinAprobar";
            try
            {
                SqlCommand cmd = new SqlCommand(procedure, conn)
                {
                    CommandType = CommandType.StoredProcedure,
                };

                _ = cmd.Parameters.AddWithValue("@COD_PROGRAMA", to.ProgramaTo.COD_PROGRAMA);
                _ = cmd.Parameters.AddWithValue("@COD_PER", to.COD_PER);
                _ = cmd.Parameters.AddWithValue("@NRO_ADELANTO", to.NRO_ADELANTO);

                conn.Open();
                DataTable dt = new DataTable();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    dt.Load(dr, LoadOption.PreserveChanges);
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }


        /// <summary>
        /// Generar una planilla de adelanto comisión para poder registrar en tesorería
        /// </summary>
        /// <param name="to">RComisionAdelantoTo</param>
        /// <param name="cn">SqlConnection</param>
        /// <param name="tr">SqlTransaction</param>
        /// <returns></returns>
        public bool InsertarRAdelantoComision(RComisionAdelantoTo to, SqlConnection cn, SqlTransaction tr)
        {
            const string procedure = "dsp_InsertarRAdelantoComisionTo";
            try
            {
                using (SqlCommand cmd = new SqlCommand(procedure, cn, tr))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    _ = cmd.Parameters.AddWithValue("@NRO_PLANILLA_DOC", to.NRO_PLANILLA_DOC);
                    _ = cmd.Parameters.AddWithValue("@COD_PER", to.COD_PER);
                    _ = cmd.Parameters.AddWithValue("@COD_NIVEL", to.COD_NIVEL);
                    _ = cmd.Parameters.AddWithValue("@IMPORTE_COMISION", to.IMPORTE_COMISION);
                    _ = cmd.Parameters.AddWithValue("@IMPORTE_ADELANTO", to.IMPORTE_ADELANTO);
                    _ = cmd.Parameters.AddWithValue("@NRO_ENVIO", to.NRO_ENVIO);
                    _ = cmd.Parameters.AddWithValue("@USUARIO_CREA", to.USUARIO_CREA);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Actuliza una planilla de adelanto comisión para poder registrar en tesorería
        /// </summary>
        /// <param name="to">RComisionAdelantoTo</param>
        /// <param name="cn">SqlConnection</param>
        /// <param name="tr">SqlTransaction</param>
        /// <returns></returns>
        public bool ActualizarRAdelantoComision(RComisionAdelantoTo to, SqlConnection cn, SqlTransaction tr)
        {
            const string procedure = "dsp_ActualizarRAdelantoComisionTo";
            try
            {
                using (SqlCommand cmd = new SqlCommand(procedure, cn, tr))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    _ = cmd.Parameters.AddWithValue("@NRO_PLANILLA_DOC", to.NRO_PLANILLA_DOC);
                    _ = cmd.Parameters.AddWithValue("@IMPORTE_COMISION", to.IMPORTE_COMISION);
                    _ = cmd.Parameters.AddWithValue("@IMPORTE_ADELANTO", to.IMPORTE_ADELANTO);
                    _ = cmd.Parameters.AddWithValue("@USUARIO_MODIFICA", to.USUARIO_MODIFICA);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Obtiene el último número de envio mas un incremento en 1, esto es un contador para saber cuantos envíos de adelanto comisión en tesoreria tiene este vendedor
        /// </summary>
        /// <param name="to"></param>
        /// <param name="cn"></param>
        /// <param name="tr"></param>
        /// <returns></returns>
        public int ObtenerSiguienteNroEnvioXPersona(RComisionAdelantoTo to, SqlConnection cn, SqlTransaction tr)
        {
            const string sentencia = "SELECT MAX(NRO_ENVIO) + 1 FROM R_COMISION_ADELANTO WHERE COD_PER = @COD_PER AND COD_NIVEL = @COD_NIVEL";
            try
            {
                using (SqlCommand cmd = new SqlCommand(sentencia, cn, tr))
                {
                    cmd.CommandType = CommandType.Text;

                    _ = cmd.Parameters.Add("@COD_PER", SqlDbType.Int).Value = to.COD_PER;
                    _ = cmd.Parameters.Add("@COD_NIVEL", SqlDbType.VarChar).Value = to.COD_NIVEL;

                    object result = cmd.ExecuteScalar();
                    return int.TryParse(result?.ToString(), out int val) ? val : 1;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Inserta un NRO_PLANILLA_DOC en COMISION_ADELANTO para realacionar con R_COMISION_ADELANTO, 
        /// también se conciderea esto como un cierre, ya que no se podrá modificar después de esto
        /// </summary>
        /// <param name="to">RComisionAdelantoTo</param>
        /// <param name="cn">SqlConnection</param>
        /// <param name="tr">SqlTransaction</param>
        /// <returns></returns>
        public bool CerrarAdelantoComisionTo(RComisionAdelantoTo to, SqlConnection cn, SqlTransaction tr)
        {
            const string sentencia = "UPDATE COMISION_ADELANTO SET NRO_PLANILLA_DOC = @NRO_PLANILLA_DOC, ESTADO = @ESTADO WHERE ID_PROCESO = @ID_PROCESO";
            try
            {
                if (to.ComisionAdelantoTo == null || to.ComisionAdelantoTo.Count == 0)
                    return false;
                foreach (ComisionAdelantoTo item in to.ComisionAdelantoTo)
                {
                    using (SqlCommand cmd = new SqlCommand(sentencia, cn, tr))
                    {
                        cmd.CommandType = CommandType.Text;

                        _ = cmd.Parameters.Add("@ID_PROCESO", SqlDbType.Int).Value = item.ID_PROCESO;
                        _ = cmd.Parameters.Add("@NRO_PLANILLA_DOC", SqlDbType.VarChar).Value = to.NRO_PLANILLA_DOC;
                        _ = cmd.Parameters.Add("@ESTADO", SqlDbType.Int).Value = item.ESTADO;

                        if (cmd.ExecuteNonQuery() <= 0)
                            return false;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Obtiene el ultimo número de adelanto de comisión por persona y nivel, si en caso no existe retorna 0
        /// </summary>
        /// <returns></returns>
        public int ObtenerUltimoNroAdelanto(ComisionAdelantoTo to)
        {
            const string sentencia = "SELECT MAX(NRO_ADELANTO) FROM COMISION_ADELANTO WHERE COD_PER = @COD_PER AND COD_NIVEL = @COD_NIVEL";
            try
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sentencia, conn))
                {
                    cmd.CommandType = CommandType.Text;

                    _ = cmd.Parameters.AddWithValue("@COD_PER", to.COD_PER);
                    _ = cmd.Parameters.AddWithValue("@COD_NIVEL", to.COD_NIVEL);

                    var result = cmd.ExecuteScalar();
                    return int.TryParse(Convert.ToString(result), out int val) ? val : 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Obtiene una lista de grupo de número de adelantos de comisión
        /// </summary>
        /// <param name="to"></param>
        /// <returns></returns>
        public DataTable ListaNroAdelantoComision(ComisionAdelantoTo to)
        {
            const string procedure = "dsp_ListaNroAdelantoComision";
            try
            {
                SqlCommand cmd = new SqlCommand(procedure, conn)
                {
                    CommandType = CommandType.StoredProcedure,
                };

                _ = cmd.Parameters.AddWithValue("@COD_NIVEL", to.COD_NIVEL);

                conn.Open();
                DataTable dt = new DataTable();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    dt.Load(dr, LoadOption.PreserveChanges);
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Obtiene el total de comisión, adelanto, saldo
        /// </summary>
        /// <param name="nroAdelanto">Nro de adelanto</param>
        /// <returns></returns>
        public DataTable ObtenerTotalesAdelantoComisionXNroAdelanto(int nroAdelanto)
        {
            const string procedure = "dsp_ObtenerTotalesAdelantoComisionXNroAdelanto";
            try
            {
                SqlCommand cmd = new SqlCommand(procedure, conn)
                {
                    CommandType = CommandType.StoredProcedure,
                };

                _ = cmd.Parameters.AddWithValue("@NRO_ADELANTO", nroAdelanto);

                conn.Open();
                DataTable dt = new DataTable();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    dt.Load(dr, LoadOption.PreserveChanges);
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Obtiene vendedores que tienen nro de adelanto igual al pasado por parámetro [nroAdelanto]
        /// </summary>
        /// <param name="nroAdelanto">Número de adelanto</param>
        /// <returns></returns>
        public DataTable ObtenerVendedoresConNroAdelanto(int nroAdelanto)
        {
            const string sentencia = "SELECT DISTINCT COD_PER, COD_NIVEL FROM COMISION_ADELANTO " +
                "WHERE NRO_ADELANTO = @NRO_ADELANTO";
            try
            {
                SqlCommand cmd = new SqlCommand(sentencia, conn)
                {
                    CommandType = CommandType.Text,
                };

                _ = cmd.Parameters.AddWithValue("@NRO_ADELANTO", nroAdelanto);

                conn.Open();
                DataTable dt = new DataTable();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    dt.Load(dr, LoadOption.PreserveChanges);
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Abre los adelantos de comisiones para ser modificados
        /// </summary>
        /// <param name="to"></param>
        /// <param name="cn"></param>
        /// <param name="tr"></param>
        /// <returns></returns>
        public bool AbrirComisionAdelanto(ComisionAdelantoTo to, SqlConnection cn, SqlTransaction tr)
        {
            const string sentencia = "UPDATE COMISION_ADELANTO SET ESTADO = 1 WHERE ID_PROCESO = @ID_PROCESO AND ESTADO = 3";
            try
            {
                using (SqlCommand cmd = new SqlCommand(sentencia, cn, tr))
                {
                    cmd.CommandType = CommandType.Text;

                    _ = cmd.Parameters.Add("@ID_PROCESO", SqlDbType.Int).Value = to.ID_PROCESO;

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Obtiene Comisiones por contrato junto con sus adelantos para determinar cuanto comisión va recibir la persona
        /// </summary>
        /// <param name="feAñoPer"></param>
        /// <param name="feMesPer"></param>
        /// <param name="codPer"></param>
        /// <returns></returns>
        public DataTable RptComisionesDetalleXVendedor(string feAñoPer, string feMesPer, string codPer)
        {
            const string sentencia = "dsp_RptComisionesDetalleXVendedor";
            try
            {
                using(SqlConnection cn = new SqlConnection(conexion.con))
                {
                    SqlCommand cmd = new SqlCommand(sentencia, cn)
                    {
                        CommandType = CommandType.StoredProcedure,
                    };

                    _ = cmd.Parameters.AddWithValue("@FE_AÑO_PER", feAñoPer);
                    _ = cmd.Parameters.AddWithValue("@FE_MES_PER", feMesPer);
                    _ = cmd.Parameters.AddWithValue("@COD_PER", codPer);

                    cn.Open();
                    DataTable dt = new DataTable();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        dt.Load(dr, LoadOption.PreserveChanges);
                    }
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Obtiene Comisiones por contrato junto con sus adelantos para determinar cuanto comisión va recibir la persona
        /// </summary>
        /// <param name="feAñoPer"></param>
        /// <param name="feMesPer"></param>
        /// <param name="codPer"></param>
        /// <param name="codNivel"></param>
        /// <returns></returns>
        public DataTable RptComisionesDetalleXSuperior(string feAñoPer, string feMesPer, string codPer, string codNivel)
        {
            const string sentencia = "dsp_RptComisionesDetalleXSuperior";
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion.con))
                {
                    SqlCommand cmd = new SqlCommand(sentencia, cn)
                    {
                        CommandType = CommandType.StoredProcedure,
                    };

                    _ = cmd.Parameters.AddWithValue("@FE_AÑO_PER", feAñoPer);
                    _ = cmd.Parameters.AddWithValue("@FE_MES_PER", feMesPer);
                    _ = cmd.Parameters.AddWithValue("@COD_PER", codPer);
                    _ = cmd.Parameters.AddWithValue("@COD_NIVEL", codNivel);
                    cn.Open();
                    DataTable dt = new DataTable();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        dt.Load(dr, LoadOption.PreserveChanges);
                    }
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Obtiene detalle de devoluciones de mercadería y descuentos de comisiones
        /// </summary>
        /// <param name="feAñoPer"></param>
        /// <param name="feMesPer"></param>
        /// <param name="codPer"></param>
        /// <returns></returns>
        public DataTable RptDevolucionDetalle(string feAñoPer, string feMesPer, string codPer, string codNivel)
        {
            const string sentencia = "dps_RptDevolucionComisionDetalle";
            try
            {
                using(SqlConnection cn = new SqlConnection(conexion.con))
                {
                    SqlCommand cmd = new SqlCommand(sentencia, cn)
                    {
                        CommandType = CommandType.StoredProcedure,
                    };

                    _ = cmd.Parameters.AddWithValue("@FE_AÑO_PER", feAñoPer);
                    _ = cmd.Parameters.AddWithValue("@FE_MES_PER", feMesPer);
                    _ = cmd.Parameters.AddWithValue("@COD_PER", codPer);
                    _ = cmd.Parameters.AddWithValue("@COD_NIVEL", codNivel);

                    cn.Open();
                    DataTable dt = new DataTable();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        dt.Load(dr, LoadOption.PreserveChanges);
                    }
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Obtiene un detalle de otros ingresos y egresos de vendedores
        /// </summary>
        /// <param name="codPer">Código del vendedor</param>
        /// <param name="feAñoPer">Año del periodo en la que se registró los movimientos</param>
        /// <param name="feMesPer">Mes del periodo en la que se registró los movimientos</param>
        /// <returns></returns>
        public DataTable RptOtrosCargosAbonosXVendedorDetalle(string codPer, string feAñoPer, string feMesPer)
        {
            const string sentencia = "dsp_RptOtrosIngresosEgresosXVendedor";
            try
            {
                using(SqlConnection cn = new SqlConnection(conexion.con))
                {
                    SqlCommand cmd = new SqlCommand(sentencia, cn)
                    {
                        CommandType = CommandType.StoredProcedure,
                    };

                    _ = cmd.Parameters.AddWithValue("@COD_PER", codPer);
                    _ = cmd.Parameters.AddWithValue("@FE_AÑO_PER", feAñoPer);
                    _ = cmd.Parameters.AddWithValue("@FE_MES_PER", feMesPer);

                    cn.Open();
                    DataTable dt = new DataTable();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        dt.Load(dr, LoadOption.PreserveChanges);
                    }
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Obtiene el AÑO y MES en que se registró los movimientos del vendedor
        /// </summary>
        /// <returns></returns>
        public DataTable ObtenerPeriodosRegistradosOtrosIngresosEgresosVendedor()
        {
            const string sentencia = "dsp_ObtenerPeriodosOtrosCargosAbonosVendedor";
            try
            {
                SqlCommand cmd = new SqlCommand(sentencia, conn)
                {
                    CommandType = CommandType.StoredProcedure,
                };

                conn.Open();
                DataTable dt = new DataTable();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    dt.Load(dr, LoadOption.PreserveChanges);
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Obtiene contratos que no estan aprobados con o sin adelanto comisión de vendedores
        /// </summary>
        /// <param name="codPrograma">Código del programa (inglés, etc.)</param>
        /// <param name="codVendedor">Código del vendedor</param>
        /// <param name="fechaContrato">fecha del contrato</param>
        /// <returns></returns>
        public DataTable RptContratosXGenerarYGeneradosAdelantoComision(string codPrograma, string codVendedor, DateTime fechaContrato)
        {
            const string sentencia = "dsp_RptContratosXGenerarYGeneradosAdelantoComision";
            try
            {
                using(SqlConnection cn = new SqlConnection(conexion.con))
                {
                    SqlCommand cmd = new SqlCommand(sentencia, cn)
                    {
                        CommandType = CommandType.StoredProcedure,
                        CommandTimeout = TIME_OUT_4
                    };

                    _ = cmd.Parameters.AddWithValue("@COD_PROGRAMA", codPrograma);
                    _ = cmd.Parameters.AddWithValue("@COD_VENDEDOR", codVendedor);
                    _ = cmd.Parameters.AddWithValue("@FECHA_CONTRATO", fechaContrato);
         

                    cn.Open();
                    DataTable dt = new DataTable();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        dt.Load(dr, LoadOption.PreserveChanges);
                    }
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable RptContratosXGenerarYGeneradosAdelantoComisionSoloVenedor(string codPrograma, string codVendedor, DateTime fechaContrato, DateTime fechaAprobIni, DateTime fechaAprobFin)
        {
            const string sentencia = "dsp_RptContratosXGenerarYGeneradosAdelantoComisionSoloVenedor";
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion.con))
                {
                    SqlCommand cmd = new SqlCommand(sentencia, cn)
                    {
                        CommandType = CommandType.StoredProcedure,
                        CommandTimeout = TIME_OUT_4
                    };

                    _ = cmd.Parameters.AddWithValue("@COD_PROGRAMA", codPrograma);
                    _ = cmd.Parameters.AddWithValue("@COD_VENDEDOR", codVendedor);
                    _ = cmd.Parameters.AddWithValue("@FECHA_CONTRATO", fechaContrato);
                    _ = cmd.Parameters.AddWithValue("@fechaAprobIni", fechaAprobIni);
                    _ = cmd.Parameters.AddWithValue("@fechaAprobFin", fechaAprobFin);

                    cn.Open();
                    DataTable dt = new DataTable();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        dt.Load(dr, LoadOption.PreserveChanges);
                    }
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Obtiene contratos que no estan aprobados por nivel venta(supervisor, director de ventas, director nacional)
        /// </summary>
        /// <param name="codPrograma"></param>
        /// <param name="codPer"></param>
        /// <param name="codNivelVenta"></param>
        /// <param name="fechaContrato"></param>
        /// <returns></returns>
        public DataTable RptContratosXGenerarYGeneradosAdelantoComision(string codPrograma, string codPer, string codNivelVenta, DateTime fechaContrato)
        {
            const string sentencia = "dsp_RptContratosXGenerarYGeneradosAdelantoComision2";
            try
            {
                using(SqlConnection cn = new SqlConnection(conexion.con))
                {
                    SqlCommand cmd = new SqlCommand(sentencia, cn)
                    {
                        CommandType = CommandType.StoredProcedure,
                        CommandTimeout = TIME_OUT_4
                    };

                    _ = cmd.Parameters.AddWithValue("@COD_PROGRAMA", codPrograma);
                    _ = cmd.Parameters.AddWithValue("@COD_PER", codPer);
                    _ = cmd.Parameters.AddWithValue("@COD_NIVEL", codNivelVenta);
                    _ = cmd.Parameters.AddWithValue("@FECHA_CONTRATO", fechaContrato);

                    cn.Open();
                    DataTable dt = new DataTable();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        dt.Load(dr, LoadOption.PreserveChanges);
                    }
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public DataTable RptContratosXGenerarYGeneradosAdelantoComisionDirector(string codPrograma, string codPer, string codNivelVenta, DateTime fechaContrato, DateTime fechaAprobIni, DateTime fechaAprobFin)
        {                             
            const string sentencia = "dsp_RptContratosXGenerarYGeneradosAdelantoComisionDirector";
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion.con))
                {
                    SqlCommand cmd = new SqlCommand(sentencia, cn)
                    {
                        CommandType = CommandType.StoredProcedure,
                        CommandTimeout = TIME_OUT_4
                    };

                    _ = cmd.Parameters.AddWithValue("@COD_PROGRAMA", codPrograma);
                    _ = cmd.Parameters.AddWithValue("@COD_PER", codPer);
                    _ = cmd.Parameters.AddWithValue("@COD_NIVEL", codNivelVenta);
                    _ = cmd.Parameters.AddWithValue("@FECHA_CONTRATO", fechaContrato);
                    _ = cmd.Parameters.AddWithValue("@fechaAprobIni", fechaAprobIni);
                    _ = cmd.Parameters.AddWithValue("@fechaAprobFin", fechaAprobFin);

                    cn.Open();
                    DataTable dt = new DataTable();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        dt.Load(dr, LoadOption.PreserveChanges);
                    }
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Obtiene contratos que estan pendientes por generar comisión menores o iguales a la [fechaAproba] de vendedores
        /// </summary>
        /// <param name="codPrograma"></param>
        /// <param name="codVendedor"></param>
        /// <param name="fechaAproba"></param>
        /// <returns></returns>
        public DataTable RptContratosPendientesGenerarComisionVendedor(string codPrograma, string codVendedor, DateTime fechaAproba)
        {
            const string sentencia = "dsp_RptContratosPendientesGenerarComisionVendedor";
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion.con))
                {
                    SqlCommand cmd = new SqlCommand(sentencia, cn)
                    {
                        CommandType = CommandType.StoredProcedure,
                        CommandTimeout = TIME_OUT_4

                    };

                    _ = cmd.Parameters.AddWithValue("@COD_PROGRAMA", codPrograma);
                    _ = cmd.Parameters.AddWithValue("@COD_VENDEDOR", codVendedor);
                    _ = cmd.Parameters.AddWithValue("@FECHA_APROB", fechaAproba);
                


                    cn.Open();
                    DataTable dt = new DataTable();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        dt.Load(dr, LoadOption.PreserveChanges);
                    }
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable RptContratosPendientesGenerarComisionSoloVendedor(string codPrograma, string codVendedor, DateTime fechaAproba, DateTime fechaAprobIni, DateTime fechaAprobFin)
        {
            const string sentencia = "dsp_RptContratosPendientesGenerarComisionSoloVendedor";
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion.con))
                {
                    SqlCommand cmd = new SqlCommand(sentencia, cn)
                    {
                        CommandType = CommandType.StoredProcedure,
                        CommandTimeout = TIME_OUT_4

                    };

                    _ = cmd.Parameters.AddWithValue("@COD_PROGRAMA", codPrograma);
                    _ = cmd.Parameters.AddWithValue("@COD_VENDEDOR", codVendedor);
                    _ = cmd.Parameters.AddWithValue("@FECHA_APROB", fechaAproba);
                    _ = cmd.Parameters.AddWithValue("@fechaAprobIni", fechaAprobIni);
                    _ = cmd.Parameters.AddWithValue("@fechaAprobFin", fechaAprobFin);


                    cn.Open();
                    DataTable dt = new DataTable();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        dt.Load(dr, LoadOption.PreserveChanges);
                    }
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Obtiene contratos que estén pendietes por generar comisión menores o iguales a la fecha [fechaAprob] de nivel Venta(supervisor, director de ventas, director nacional)
        /// </summary>
        /// <param name="codPrograma"></param>
        /// <param name="codPer"></param>
        /// <param name="codNivelVenta"></param>
        /// <param name="fechaAproba"></param>
        /// <returns></returns>
        public DataTable RptContratosPendientesGenerarComisionSuperior(string codPrograma, string codPer, string codNivelVenta, DateTime fechaAproba)
        {
            const string sentencia = "dsp_RptContratosPendientesGenerarComisionSuperior";
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion.con))
                {
                    SqlCommand cmd = new SqlCommand(sentencia, cn)
                    {
                        CommandType = CommandType.StoredProcedure,
                    };

                    _ = cmd.Parameters.AddWithValue("@COD_PROGRAMA", codPrograma);
                    _ = cmd.Parameters.AddWithValue("@COD_PER", codPer);
                    _ = cmd.Parameters.AddWithValue("@COD_NIVEL", codNivelVenta);
                    _ = cmd.Parameters.AddWithValue("@FECHA_APROB", fechaAproba);

                    cn.Open();
                    DataTable dt = new DataTable();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        dt.Load(dr, LoadOption.PreserveChanges);
                    }
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public DataTable RptContratosPendientesGenerarComisionSuperiorDirector(string codPrograma, string codPer, string codNivelVenta, DateTime fechaAproba, DateTime fechaAprobIni, DateTime fechaAprobFin)
        {
            const string sentencia = "dsp_RptContratosPendientesGenerarComisionSuperiorDirector";
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion.con))
                {
                    SqlCommand cmd = new SqlCommand(sentencia, cn)
                    {
                        CommandType = CommandType.StoredProcedure,
                        CommandTimeout = 51000
                    };

                    _ = cmd.Parameters.AddWithValue("@COD_PROGRAMA", codPrograma);
                    _ = cmd.Parameters.AddWithValue("@COD_PER", codPer);
                    _ = cmd.Parameters.AddWithValue("@COD_NIVEL", codNivelVenta);
                    _ = cmd.Parameters.AddWithValue("@FECHA_APROB", fechaAproba);
                    _ = cmd.Parameters.AddWithValue("@fechaAprobIni", fechaAprobIni);
                    _ = cmd.Parameters.AddWithValue("@fechaAprobFin", fechaAprobFin);

                    cn.Open();
                    DataTable dt = new DataTable();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        dt.Load(dr, LoadOption.PreserveChanges);
                    }
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
