using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using static Entidades.ConstClass;

namespace DAL
{
    public class SeguimientoPlanillasDAL
    {
        private readonly SqlConnection conn;
        private readonly SqlConnection conn2;
        private readonly SqlConnection conGeneral;
        public SeguimientoPlanillasDAL()
        {
            conn = new SqlConnection(conexion.con);
            conn2 = new SqlConnection(conexion.con);
            conGeneral = new SqlConnection(conexion.con2);
        }

        public DataTable ListarPlanillasPendientesEnviar(string codPtoCob, DateTime fechaInicio, DateTime fechaFin, int acces)
        {
            const string function = "SELECT * FROM fn_ListarPlanillasPendientesEnviar(@CodPtoCob,@FechaEnvioInicio,@FechaEnvioFin,@Acces)";
            SqlCommand cmd = new SqlCommand(function, conn)
            {
                CommandType = CommandType.Text
            };

            _ = cmd.Parameters.AddWithValue("@CodPtoCob", codPtoCob);
            _ = cmd.Parameters.AddWithValue("@FechaEnvioInicio", fechaInicio);
            _ = cmd.Parameters.AddWithValue("@FechaEnvioFin", fechaFin);
            _ = cmd.Parameters.AddWithValue("@Acces", acces);

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

        public DataTable ListarEstadoSeguimientoPlanilla()
        {
            const string query = "SELECT * FROM ESTADO_SEGUIMIENTO_PLANILLA";
            SqlCommand cmd = new SqlCommand(query, conn)
            {
                CommandType = CommandType.Text
            };

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

        public DataTable ObtenerEstadoSeguimientoXId(int idEstado)
        {
            const string query = "SELECT * FROM ESTADO_SEGUIMIENTO_PLANILLA WHERE ID_ESTADO = @ID_ESTADO";
            SqlCommand cmd = new SqlCommand(query, conn)
            {
                CommandType = CommandType.Text
            };

            _ = cmd.Parameters.AddWithValue("@ID_ESTADO", idEstado);

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

        public bool GrabarSeguimientoPlanillaFase1(ref SeguimientoPlanillaTo se, CRUD crud)
        {
            SqlTransaction sqlTransaction = null;
            SqlConnection cn = conn;

            try
            {
                cn.Open();
                sqlTransaction = cn.BeginTransaction("STSeguimiento");
                switch (crud)
                {
                    case CRUD.Insertar:
                        if (RegistrarSeguimientoPlanillaFase1(se, sqlTransaction, cn))
                        {
                            sqlTransaction.Commit();
                            return true;
                        }
                        break;
                    case CRUD.Actualizar:
                        if (ModificarSeguimientoPlanillaFase1(se, sqlTransaction, cn))
                        {
                            sqlTransaction.Commit();
                            return true;
                        }
                        break;
                    case CRUD.Eliminar:
                        if (EliminarEnvioPlanilla(se, sqlTransaction, cn))
                        {
                            sqlTransaction.Commit();
                            return true;
                        }
                        break;
                    default:
                        return true;
                }

                sqlTransaction.Rollback();
                return false;
            }
            catch (Exception)
            {
                sqlTransaction.Rollback();
                throw;
            }
            finally
            {
                cn.Close();
            }
        }

        private bool RegistrarSeguimientoPlanillaFase1(SeguimientoPlanillaTo se, SqlTransaction sqlTransaction, SqlConnection cn)
        {
            try
            {
                DataTable dt = ValidarExistenciaPlaSiguimiento(se, sqlTransaction, cn);
                if (dt == null || dt.Rows.Count == 0)
                {
                    if (InsertarSeguimiento(ref se, sqlTransaction, cn))
                    {
                        if (InsertarPersonaEnvio(ref se, sqlTransaction, cn) && InsertarPersonaEnvio2(ref se, sqlTransaction, cn))
                        {
                            if (InsertarEnvioPlanilla(se, sqlTransaction, cn))
                            {
                                if (InsertarHistorialSeguimiento(se, sqlTransaction, cn))
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
                else
                {
                    se.ID_SEGUIMIENTO = Convert.ToInt32(dt.Rows[0]["ID_SEGUIMIENTO"]);
                    if (InsertarPersonaEnvio(ref se, sqlTransaction, cn) && InsertarPersonaEnvio2(ref se, sqlTransaction, cn))
                    {
                        return InsertarEnvioPlanilla(se, sqlTransaction, cn);
                    }
                }

                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool InsertarSeguimiento(ref SeguimientoPlanillaTo se, SqlTransaction sqlTransaction, SqlConnection cn)
        {
            try
            {
                const string procedure = "usp_InsertarSeguimientoPlanilla";
                DataTable dt = ObtenerPlanillasXGrupo(se, cn, sqlTransaction);
                DataRow rw = ObtenerPlanillaPuntoEnvio(se, cn, sqlTransaction);
                if (dt is null || rw is null)
                    return false;

                foreach (DataRow row in dt.Rows)
                {
                    SqlCommand cmd = new SqlCommand(procedure, cn, sqlTransaction)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    _ = cmd.Parameters.AddWithValue("@ID_ESTADO", se.ID_ESTADO);
                    _ = cmd.Parameters.AddWithValue("@NRO_PLANILLA", row["NRO_PLANILLA_COB"]);
                    _ = cmd.Parameters.AddWithValue("@TIPO_PLANILLA", se.TIPO_PLANILLA);
                    _ = cmd.Parameters.AddWithValue("@FE_AÑO", se.FE_AÑO);
                    _ = cmd.Parameters.AddWithValue("@FE_MES", se.FE_MES);
                    _ = cmd.Parameters.AddWithValue("@COD_PTO_COB_CONSOLIDADO", row["COD_PTO_COB_CONSOLIDADO"]);
                    _ = cmd.Parameters.AddWithValue("@COD_INSTITUCION", row["COD_INSTITUCION"]);
                    _ = cmd.Parameters.AddWithValue("@COD_CANAL_DSCTO", row["COD_CANAL_DSCTO"]);
                    _ = cmd.Parameters.AddWithValue("@COD_PTO_COB_ENVIO", rw["COD_PTO_COB"]);
                    _ = cmd.Parameters.AddWithValue("@CAB_PTO_COB_ENVIO", row["NRO_PLANILLA_COB"].ToString() == se.NRO_PLANILLA.ToString());
                    _ = cmd.Parameters.AddWithValue("@OBSERVACION", se.OBSERVACION);
                    _ = cmd.Parameters.AddWithValue("@COD_GRUPO", row["COD_GRUPO"]);
                    _ = cmd.Parameters.AddWithValue("@CAB_GRUPO", Convert.ToBoolean(row["CAB_GRUPO"]));
                    _ = cmd.Parameters.AddWithValue("@USUARIO_CREA", se.USUARIO_CREA);

                    SqlParameter parameter = new SqlParameter("@ID_SEGUIMIENTO", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };

                    _ = cmd.Parameters.Add(parameter);
                    if (cmd.ExecuteNonQuery() == 0)
                        return false;
                    else if (Convert.ToBoolean(row["CAB_GRUPO"]))
                        se.ID_SEGUIMIENTO = Convert.ToInt32(parameter.Value);
                    else if (row["NRO_PLANILLA_COB"].ToString() == se.NRO_PLANILLA)
                        se.ID_SEGUIMIENTO = Convert.ToInt32(parameter.Value);
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private DataTable ValidarExistenciaPlaSiguimiento(SeguimientoPlanillaTo se, SqlTransaction sqlTransaction, SqlConnection cn)
        {
            const string function = "SELECT * FROM fn_ObtenerPlanillaSeguimientoExist(@NRO_PLANILLA,@TIPO_PLANILLA,@FE_AÑO,@FE_MES,@COD_PTO_COB_CONSOLIDADO)";

            SqlCommand cmd = new SqlCommand(function, cn, sqlTransaction)
            {
                CommandType = CommandType.Text
            };

            _ = cmd.Parameters.AddWithValue("@NRO_PLANILLA", se.NRO_PLANILLA);
            _ = cmd.Parameters.AddWithValue("@TIPO_PLANILLA", se.TIPO_PLANILLA);
            _ = cmd.Parameters.AddWithValue("@FE_AÑO", se.FE_AÑO);
            _ = cmd.Parameters.AddWithValue("@FE_MES", se.FE_MES);
            _ = cmd.Parameters.AddWithValue("@COD_PTO_COB_CONSOLIDADO", se.COD_PTO_COB_CONSOLIDADO);

            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr, LoadOption.Upsert);
                dr.Close();
                return dt;
            }
            catch
            {
                throw;
            }
        }

        private bool InsertarEnvioPlanilla(SeguimientoPlanillaTo se, SqlTransaction sqlTransaction, SqlConnection cn)
        {
            try
            {
                const string procedure = "usp_RegistrarEnvioPlanilla";
                SqlCommand cmd = new SqlCommand(procedure, cn, sqlTransaction)
                {
                    CommandType = CommandType.StoredProcedure
                };

                _ = cmd.Parameters.AddWithValue("@ID_SEGUIMIENTO", se.ID_SEGUIMIENTO);
                _ = cmd.Parameters.AddWithValue("@NRO_PLANILLA", se.NRO_PLANILLA);
                _ = cmd.Parameters.AddWithValue("@FECHA_ENVIO", se.EnvioPlanilla.FECHA_ENVIO);
                _ = cmd.Parameters.AddWithValue("@HORA_ENVIO", se.EnvioPlanilla.HORA_ENVIO);
                if (se.EnvioPlanilla.DOC_ENVIO == null)
                    _ = cmd.Parameters.AddWithValue("@DOC_ENVIO", DBNull.Value);
                else
                    _ = cmd.Parameters.AddWithValue("@DOC_ENVIO", se.EnvioPlanilla.DOC_ENVIO);
                _ = cmd.Parameters.AddWithValue("@TIPO_ENVIO", se.EnvioPlanilla.TIPO_ENVIO);
                _ = cmd.Parameters.AddWithValue("@ID_PERSONA", se.PersonaEnvio.ID_PERSONA);
                _ = cmd.Parameters.AddWithValue("@ID_REMITENTE", se.EmisorTo is null ? 0 : se.EmisorTo.ID_PERSONA);
                _ = cmd.Parameters.AddWithValue("@NOMBRE_INST", se.EnvioPlanilla.NOMBRE_INST);
                _ = cmd.Parameters.AddWithValue("@TLF_INST", se.EnvioPlanilla.TLF_INST);
                _ = cmd.Parameters.AddWithValue("@OBSERVACION", se.OBSERVACION);
                _ = cmd.Parameters.AddWithValue("@ENVIO_CORRESP", se.EnvioPlanilla.ENVIO_CORRESP);
                _ = cmd.Parameters.AddWithValue("@USUARIO_CREA", se.USUARIO_CREA);

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool InsertarPersonaEnvio(ref SeguimientoPlanillaTo se, SqlTransaction sqlTransaction, SqlConnection cn)
        {
            try
            {
                const string procedure = "usp_InsertarPersonaEnvio";
                SqlCommand cmd = new SqlCommand(procedure, cn, sqlTransaction)
                {
                    CommandType = CommandType.StoredProcedure
                };

                if (se.PersonaEnvio.CORREO == null)
                    _ = cmd.Parameters.AddWithValue("@CORREO", DBNull.Value);
                else
                    _ = cmd.Parameters.AddWithValue("@CORREO", se.PersonaEnvio.CORREO);
                _ = cmd.Parameters.AddWithValue("@NOMBRE", se.PersonaEnvio.NOMBRE);
                _ = cmd.Parameters.AddWithValue("@APELLIDO", se.PersonaEnvio.APELLIDO);
                _ = cmd.Parameters.AddWithValue("@TELEFONO", se.PersonaEnvio.TELEFONO);
                _ = cmd.Parameters.AddWithValue("@AREA_LABOR", se.PersonaEnvio.AREA_LABOR);
                if (se.PersonaEnvio.PROVEEDOR_COURIER == null)
                    _ = cmd.Parameters.AddWithValue("@PROVEEDOR_COURIER", DBNull.Value);
                else
                    _ = cmd.Parameters.AddWithValue("@PROVEEDOR_COURIER", se.PersonaEnvio.PROVEEDOR_COURIER);
                if (se.PersonaEnvio.TELEFONO_COURIER == null)
                    _ = cmd.Parameters.AddWithValue("@TELEFONO_COURIER", DBNull.Value);
                else
                    _ = cmd.Parameters.AddWithValue("@TELEFONO_COURIER", se.PersonaEnvio.TELEFONO_COURIER);
                if (se.PersonaEnvio.DIRECCION_COURIER == null)
                    _ = cmd.Parameters.AddWithValue("@DIRECCION_COURIER", DBNull.Value);
                else
                    _ = cmd.Parameters.AddWithValue("@DIRECCION_COURIER", se.PersonaEnvio.DIRECCION_COURIER);

                SqlParameter parameter = new SqlParameter("@ID_PERSONA", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };

                _ = cmd.Parameters.Add(parameter);

                int result = cmd.ExecuteNonQuery();
                se.PersonaEnvio.ID_PERSONA = Convert.ToInt32(parameter.Value);

                return result > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool InsertarPersonaEnvio2(ref SeguimientoPlanillaTo se, SqlTransaction sqlTransaction, SqlConnection cn)
        {
            if (se.EmisorTo is null)
            {
                return true;
            }
            else
            {
                try
                {
                    const string procedure = "usp_InsertarPersonaEnvio";
                    SqlCommand cmd = new SqlCommand(procedure, cn, sqlTransaction)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    if (se.EmisorTo.CORREO == null)
                        _ = cmd.Parameters.AddWithValue("@CORREO", DBNull.Value);
                    else
                        _ = cmd.Parameters.AddWithValue("@CORREO", se.EmisorTo.CORREO);
                    _ = cmd.Parameters.AddWithValue("@NOMBRE", se.EmisorTo.NOMBRE);
                    _ = cmd.Parameters.AddWithValue("@APELLIDO", se.EmisorTo.APELLIDO);
                    _ = cmd.Parameters.AddWithValue("@TELEFONO", se.EmisorTo.TELEFONO);
                    _ = cmd.Parameters.AddWithValue("@AREA_LABOR", se.EmisorTo.AREA_LABOR);
                    if (se.EmisorTo.PROVEEDOR_COURIER == null)
                        _ = cmd.Parameters.AddWithValue("@PROVEEDOR_COURIER", DBNull.Value);
                    else
                        _ = cmd.Parameters.AddWithValue("@PROVEEDOR_COURIER", se.EmisorTo.PROVEEDOR_COURIER);
                    if (se.EmisorTo.TELEFONO_COURIER == null)
                        _ = cmd.Parameters.AddWithValue("@TELEFONO_COURIER", DBNull.Value);
                    else
                        _ = cmd.Parameters.AddWithValue("@TELEFONO_COURIER", se.EmisorTo.TELEFONO_COURIER);
                    if (se.EmisorTo.DIRECCION_COURIER == null)
                        _ = cmd.Parameters.AddWithValue("@DIRECCION_COURIER", DBNull.Value);
                    else
                        _ = cmd.Parameters.AddWithValue("@DIRECCION_COURIER", se.EmisorTo.DIRECCION_COURIER);

                    SqlParameter parameter = new SqlParameter("@ID_PERSONA", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };

                    _ = cmd.Parameters.Add(parameter);

                    int result = cmd.ExecuteNonQuery();
                    se.EmisorTo.ID_PERSONA = Convert.ToInt32(parameter.Value);

                    return result > 0;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public DataTable ListarPlanillasXConfirmRecepcion(string codPtoCob, DateTime fechaInicio, DateTime fechaFin, int acces)
        {
            const string function = "SELECT * FROM fn_ListarPlanillasXConfirmRecepcion(@CodPtoCob,@FechaEnvioInicio,@FechaEnvioFin,@Acces)";
            SqlCommand cmd = new SqlCommand(function, conn)
            {
                CommandType = CommandType.Text
            };

            _ = cmd.Parameters.AddWithValue("@CodPtoCob", codPtoCob);
            _ = cmd.Parameters.AddWithValue("@FechaEnvioInicio", fechaInicio);
            _ = cmd.Parameters.AddWithValue("@FechaEnvioFin", fechaFin);
            _ = cmd.Parameters.AddWithValue("@Acces", acces);

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

        public bool InsertarHistorialSeguimiento(SeguimientoPlanillaTo se, SqlTransaction sqlTransaction, SqlConnection cn)
        {
            try
            {
                const string procedure = "usp_InsertarHistorialSeguimiento";
                SqlCommand cmd = new SqlCommand(procedure, cn, sqlTransaction)
                {
                    CommandType = CommandType.StoredProcedure
                };

                _ = cmd.Parameters.AddWithValue("@ID_SEGUIMIENTO", se.ID_SEGUIMIENTO);
                _ = cmd.Parameters.AddWithValue("@ID_ESTADO", se.ID_ESTADO);
                _ = cmd.Parameters.AddWithValue("@MOTIVO", se.OBSERVACION);
                _ = cmd.Parameters.AddWithValue("@USUARIO_CREA", se.USUARIO_CREA);

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool InsertarHistorialSeguimiento(SeguimientoPlanillaTo se)
        {
            try
            {
                const string procedure = "usp_InsertarHistorialSeguimiento";
                SqlCommand cmd = new SqlCommand(procedure, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                _ = cmd.Parameters.AddWithValue("@ID_SEGUIMIENTO", se.ID_SEGUIMIENTO);
                _ = cmd.Parameters.AddWithValue("@ID_ESTADO", se.ID_ESTADO);
                _ = cmd.Parameters.AddWithValue("@USUARIO_CREA", se.USUARIO_CREA);
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

        public DataTable ListarEnvioSeguimientoPlanillaXTipoEnvio(int idSeguimiento, string tipoEnvio)
        {
            const string function = "SELECT * FROM fn_ListarEnvioSeguimientoPlanilla(@ID_SEGUIMIENTO) WHERE TIPO_ENVIO = @TIPO_ENVIO";

            SqlCommand cmd = new SqlCommand(function, conn)
            {
                CommandType = CommandType.Text
            };

            _ = cmd.Parameters.AddWithValue("@ID_SEGUIMIENTO", idSeguimiento);
            _ = cmd.Parameters.AddWithValue("@TIPO_ENVIO", tipoEnvio);

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

        private bool ModificarSeguimientoPlanillaFase1(SeguimientoPlanillaTo se, SqlTransaction sqlTransaction, SqlConnection cn)
        {
            try
            {
                if (ActualizarEnvioPlanilla(se, sqlTransaction, cn))
                {
                    if (ActualizarPersonaEnvio(se, sqlTransaction, cn))
                    {
                        return ActualizarPersonaEnvio2(se, sqlTransaction, cn);
                    }
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool ActualizarEnvioPlanilla(SeguimientoPlanillaTo se, SqlTransaction sqlTransaction, SqlConnection cn)
        {
            try
            {
                const string procedure = "usp_ActualizarEnvioPlanilla";
                SqlCommand cmd = new SqlCommand(procedure, cn, sqlTransaction)
                {
                    CommandType = CommandType.StoredProcedure
                };

                _ = cmd.Parameters.AddWithValue("@ID_ENVIO", se.EnvioPlanilla.ID_ENVIO);
                _ = cmd.Parameters.AddWithValue("@ID_SEGUIMIENTO", se.ID_SEGUIMIENTO);
                _ = cmd.Parameters.AddWithValue("@FECHA_ENVIO", se.EnvioPlanilla.FECHA_ENVIO);
                _ = cmd.Parameters.AddWithValue("@HORA_ENVIO", se.EnvioPlanilla.HORA_ENVIO);
                if (se.EnvioPlanilla.DOC_ENVIO == null)
                    _ = cmd.Parameters.AddWithValue("@DOC_ENVIO", DBNull.Value);
                else
                    _ = cmd.Parameters.AddWithValue("@DOC_ENVIO", se.EnvioPlanilla.DOC_ENVIO);
                _ = cmd.Parameters.AddWithValue("@TIPO_ENVIO", se.EnvioPlanilla.TIPO_ENVIO);
                _ = cmd.Parameters.AddWithValue("@USUARIO_MODIFICA", se.USUARIO_MODIFICA);
                _ = cmd.Parameters.AddWithValue("@NOMBRE_INST", se.EnvioPlanilla.NOMBRE_INST);
                _ = cmd.Parameters.AddWithValue("@TLF_INST", se.EnvioPlanilla.TLF_INST);
                _ = cmd.Parameters.AddWithValue("@OBSERVACION", se.OBSERVACION);
                _ = cmd.Parameters.AddWithValue("@ENVIO_CORRESP", se.EnvioPlanilla.ENVIO_CORRESP);

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool ActualizarPersonaEnvio(SeguimientoPlanillaTo se, SqlTransaction sqlTransaction, SqlConnection cn)
        {
            try
            {
                const string procedure = "usp_ActualizarPersonaEnvio";
                SqlCommand cmd = new SqlCommand(procedure, cn, sqlTransaction)
                {
                    CommandType = CommandType.StoredProcedure
                };

                _ = cmd.Parameters.AddWithValue("@ID_PERSONA", se.PersonaEnvio.ID_PERSONA);
                if (se.PersonaEnvio.CORREO == null)
                    _ = cmd.Parameters.AddWithValue("@CORREO", DBNull.Value);
                else
                    _ = cmd.Parameters.AddWithValue("@CORREO", se.PersonaEnvio.CORREO);
                _ = cmd.Parameters.AddWithValue("@NOMBRE", se.PersonaEnvio.NOMBRE);
                _ = cmd.Parameters.AddWithValue("@APELLIDO", se.PersonaEnvio.APELLIDO);
                _ = cmd.Parameters.AddWithValue("@TELEFONO", se.PersonaEnvio.TELEFONO);
                _ = cmd.Parameters.AddWithValue("@AREA_LABOR", se.PersonaEnvio.AREA_LABOR);
                if (se.PersonaEnvio.PROVEEDOR_COURIER == null)
                    _ = cmd.Parameters.AddWithValue("@PROVEEDOR_COURIER", DBNull.Value);
                else
                    _ = cmd.Parameters.AddWithValue("@PROVEEDOR_COURIER", se.PersonaEnvio.PROVEEDOR_COURIER);
                if (se.PersonaEnvio.TELEFONO_COURIER == null)
                    _ = cmd.Parameters.AddWithValue("@TELEFONO_COURIER", DBNull.Value);
                else
                    _ = cmd.Parameters.AddWithValue("@TELEFONO_COURIER", se.PersonaEnvio.TELEFONO_COURIER);
                if (se.PersonaEnvio.DIRECCION_COURIER == null)
                    _ = cmd.Parameters.AddWithValue("@DIRECCION_COURIER", DBNull.Value);
                else
                    _ = cmd.Parameters.AddWithValue("@DIRECCION_COURIER", se.PersonaEnvio.DIRECCION_COURIER);

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool ActualizarPersonaEnvio2(SeguimientoPlanillaTo se, SqlTransaction sqlTransaction, SqlConnection cn)
        {
            if (se.EmisorTo is null)
            {
                return true;
            }
            else
            {
                try
                {
                    const string procedure = "usp_ActualizarPersonaEnvio";
                    SqlCommand cmd = new SqlCommand(procedure, cn, sqlTransaction)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    _ = cmd.Parameters.AddWithValue("@ID_PERSONA", se.EmisorTo.ID_PERSONA);
                    if (se.EmisorTo.CORREO == null)
                        _ = cmd.Parameters.AddWithValue("@CORREO", DBNull.Value);
                    else
                        _ = cmd.Parameters.AddWithValue("@CORREO", se.EmisorTo.CORREO);
                    _ = cmd.Parameters.AddWithValue("@NOMBRE", se.EmisorTo.NOMBRE);
                    _ = cmd.Parameters.AddWithValue("@APELLIDO", se.EmisorTo.APELLIDO);
                    _ = cmd.Parameters.AddWithValue("@TELEFONO", se.EmisorTo.TELEFONO);
                    _ = cmd.Parameters.AddWithValue("@AREA_LABOR", se.EmisorTo.AREA_LABOR);
                    if (se.EmisorTo.PROVEEDOR_COURIER == null)
                        _ = cmd.Parameters.AddWithValue("@PROVEEDOR_COURIER", DBNull.Value);
                    else
                        _ = cmd.Parameters.AddWithValue("@PROVEEDOR_COURIER", se.EmisorTo.PROVEEDOR_COURIER);
                    if (se.EmisorTo.TELEFONO_COURIER == null)
                        _ = cmd.Parameters.AddWithValue("@TELEFONO_COURIER", DBNull.Value);
                    else
                        _ = cmd.Parameters.AddWithValue("@TELEFONO_COURIER", se.EmisorTo.TELEFONO_COURIER);
                    if (se.EmisorTo.DIRECCION_COURIER == null)
                        _ = cmd.Parameters.AddWithValue("@DIRECCION_COURIER", DBNull.Value);
                    else
                        _ = cmd.Parameters.AddWithValue("@DIRECCION_COURIER", se.EmisorTo.DIRECCION_COURIER);

                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        private bool EliminarEnvioPlanilla(SeguimientoPlanillaTo se, SqlTransaction sqlTransaction, SqlConnection cn)
        {
            const string procedure = "usp_EliminarEnvioPlanilla";
            try
            {
                SqlCommand cmd = new SqlCommand(procedure, cn, sqlTransaction)
                {
                    CommandType = CommandType.StoredProcedure
                };

                _ = cmd.Parameters.AddWithValue("@ID_ENVIO", se.EnvioPlanilla.ID_ENVIO);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    if (EliminarPersonaEnvio(se, sqlTransaction, cn, 1))
                    {
                        if (se.EmisorTo != null && se.EmisorTo.ID_PERSONA != 0)
                            return EliminarPersonaEnvio(se, sqlTransaction, cn, 2);
                        return true;
                    }
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="se"></param>
        /// <param name="sqlTransaction"></param>
        /// <param name="cn"></param>
        /// <param name="act">Si act == 1, entonces se elimina por el ID_PERSONA, de lo contrario por el ID_REMITENTE</param>
        /// <returns></returns>
        private bool EliminarPersonaEnvio(SeguimientoPlanillaTo se, SqlTransaction sqlTransaction, SqlConnection cn, int act)
        {
            const string procedure = "usp_EliminarPersonaEnvio";
            try
            {
                SqlCommand cmd = new SqlCommand(procedure, cn, sqlTransaction)
                {
                    CommandType = CommandType.StoredProcedure
                };

                _ = cmd.Parameters.AddWithValue("@ID_PERSONA", act == 1 ? se.PersonaEnvio.ID_PERSONA : se.EmisorTo.ID_PERSONA);

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool CerrarSeguimientoPlanilla(SeguimientoPlanillaTo se)
        {
            SqlConnection cn = conn;
            cn.Open();
            SqlTransaction sqlTransaction = cn.BeginTransaction("TCerrarSegui");
            try
            {
                if (InsertarHistorialSeguimiento(se, sqlTransaction, cn))
                {
                    sqlTransaction.Commit();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                sqlTransaction.Rollback();
                throw;
            }
            finally
            {
                cn.Close();
            }
        }

        public int TransferirPlanillas(string status, string año, string mes)
        {
            const string procedure = "usp_TransferirPlanillas";

            SqlCommand cmd = new SqlCommand(procedure, conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            _ = cmd.Parameters.AddWithValue("@ST_SEGUI_PLAN", status);
            _ = cmd.Parameters.AddWithValue("@AÑO", año);
            _ = cmd.Parameters.AddWithValue("@MES", mes);
            try
            {
                conn.Open();
                return cmd.ExecuteNonQuery();
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

        public DataTable ListarPlanillasXPtoCobranza(string codPtoCob, string año, string mes)
        {
            const string function = "SELECT * FROM fn_ListarIPLANILLAS(@COD_PTO_COB_CONSOLIDADO,@AÑO,@MES)";

            SqlCommand cmd = new SqlCommand(function, conn)
            {
                CommandType = CommandType.Text
            };

            _ = cmd.Parameters.AddWithValue("@COD_PTO_COB_CONSOLIDADO", codPtoCob);
            _ = cmd.Parameters.AddWithValue("@AÑO", año);
            _ = cmd.Parameters.AddWithValue("@MES", mes);

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

        public bool ProgramarLlamada(LLamadas llamada1, LLamadas llamada2 = null)
        {
            try
            {
                conn.Open();
                SqlTransaction sqlTransaction = conn.BeginTransaction();
                if (RegistrarLlamada(llamada1, sqlTransaction))
                {
                    if (llamada2 != null)
                    {
                        if (RegistrarLlamada(llamada2, sqlTransaction))
                        {
                            sqlTransaction.Commit();
                            return true;
                        }
                        sqlTransaction.Rollback();
                        return false;
                    }
                    sqlTransaction.Commit();
                    return true;
                }
                sqlTransaction.Rollback();
                return false;
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

        public bool ProgramarLlamada(LLamadas llamada1, bool esProcesada, bool chkNoSal)
        {
            try
            {
                conn.Open();
                SqlTransaction sqlTransaction = conn.BeginTransaction();
                if (RegistrarLlamada(llamada1, sqlTransaction))
                {
                    if (esProcesada || chkNoSal)
                    {
                        llamada1.SeguimientoPlanillaTo.ID_ESTADO = chkNoSal ? 10 : llamada1.SeguimientoPlanillaTo.ID_ESTADO;
                        if (InsertarHistorialSeguimiento(llamada1.SeguimientoPlanillaTo, sqlTransaction, conn))
                        {
                            sqlTransaction.Commit();
                            return true;
                        }
                        sqlTransaction.Rollback();
                        return false;
                    }
                    sqlTransaction.Commit();
                    return true;
                }
                sqlTransaction.Rollback();
                return false;
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

        public bool ProgramarLlamadaConfirmarDescuento(LLamadas llamada1, DateTime fechaTrans, bool showChecked, List<SeguimientoPlanillaTo> lstImporteListado)
        {
            try
            {
                conn.Open();
                SqlTransaction sqlTransaction = conn.BeginTransaction();
                if (RegistrarLlamada(llamada1, sqlTransaction))
                {
                    if (InsertarImporte(llamada1.SeguimientoPlanillaTo, sqlTransaction, conn) && InsertarImportesSeguiPlla(llamada1.SeguimientoPlanillaTo, lstImporteListado, showChecked, sqlTransaction, conn)
                        && InsertarNoProcesoPlla(llamada1.SeguimientoPlanillaTo, lstImporteListado, showChecked, sqlTransaction, conn))
                    {
                        if (showChecked)
                        {
                            //> llamada1.SeguimientoPlanillaTo.ID_ESTADO = DESCONTADO_CONFIRMADO;
                            if (InsertarHistorialSeguimiento(llamada1.SeguimientoPlanillaTo, sqlTransaction, conn))
                            {
                                if (TransferirPlanillasSiDescontadas(llamada1.SeguimientoPlanillaTo.ID_SEGUIMIENTO, fechaTrans, sqlTransaction, conn))
                                {
                                    sqlTransaction.Commit();
                                    return true;
                                }
                            }
                        }
                        else
                        {
                            sqlTransaction.Commit();
                            return true;
                        }
                    }
                }

                sqlTransaction.Rollback();
                return false;
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

        private bool RegistrarLlamada(LLamadas llamada, SqlTransaction sqlTransaction)
        {
            if (llamada.PersonaEnvioTo != null)
            {
                SeguimientoPlanillaTo se = new SeguimientoPlanillaTo
                {
                    PersonaEnvio = llamada.PersonaEnvioTo
                };
                if (llamada.PersonaEnvioTo.ID_PERSONA != 0)
                {
                    if (InsertarLLamada(llamada, sqlTransaction))
                    {
                        if (llamada.ID_LLAMADA_BASE != 0)
                        {
                            return CerrarLlamadaProgramada();
                        }
                        return true;
                    }
                }
                else
                {
                    if (InsertarPersonaEnvio(ref se, sqlTransaction, conn))
                    {
                        if (InsertarLLamada(llamada, sqlTransaction))
                        {
                            if (llamada.ID_LLAMADA_BASE != 0)
                            {
                                return CerrarLlamadaProgramada();
                            }
                            return true;
                        }
                    }
                }
            }
            else
            {
                return InsertarLLamada(llamada, sqlTransaction);
            }

            return false;

            bool CerrarLlamadaProgramada()
            {
                const string procedure = "usp_CerrarLlamadaPendiente";

                SqlCommand cmd = new SqlCommand(procedure, conn, sqlTransaction)
                {
                    CommandType = CommandType.StoredProcedure
                };

                _ = cmd.Parameters.AddWithValue("@ID_LLAMADA", llamada.ID_LLAMADA_BASE);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        private bool InsertarLLamada(LLamadas llamada, SqlTransaction sqlTransaction)
        {
            const string procedure = "usp_InsertarLLamadas";

            SqlCommand cmd = new SqlCommand(procedure, conn, sqlTransaction)
            {
                CommandType = CommandType.StoredProcedure
            };

            _ = cmd.Parameters.AddWithValue("@ID_LLAMADA_BASE", llamada.ID_LLAMADA_BASE);
            _ = cmd.Parameters.AddWithValue("@ID_SEGUIMIENTO", llamada.SeguimientoPlanillaTo.ID_SEGUIMIENTO);
            _ = cmd.Parameters.AddWithValue("@ID_ESTADO", llamada.SeguimientoPlanillaTo.ID_ESTADO);
            if (llamada.PersonaEnvioTo == null)
                _ = cmd.Parameters.AddWithValue("@ID_PERSONA", DBNull.Value);
            else
                _ = cmd.Parameters.AddWithValue("@ID_PERSONA", llamada.PersonaEnvioTo.ID_PERSONA);
            _ = cmd.Parameters.AddWithValue("@FECHA_LLAMADA", llamada.FECHA_LLAMADA);
            _ = cmd.Parameters.AddWithValue("@HORA_LLAMADA", llamada.HORA_LLAMADA);
            _ = cmd.Parameters.AddWithValue("@NOMBRE_INST", llamada.NOMBRE_INST);
            _ = cmd.Parameters.AddWithValue("@TLF_INST", llamada.TLF_INST);
            _ = cmd.Parameters.AddWithValue("@OBSERVACION", llamada.OBSERVACION);
            _ = cmd.Parameters.AddWithValue("@TIPO", llamada.TIPO);
            if (llamada.SeguimientoPlanillaTo.IMPORTE_DESCUENTO == 0)
                _ = cmd.Parameters.AddWithValue("@IMPORTE_DESCUENTO", DBNull.Value);
            else
                _ = cmd.Parameters.AddWithValue("@IMPORTE_DESCUENTO", llamada.SeguimientoPlanillaTo.IMPORTE_DESCUENTO);
            _ = cmd.Parameters.AddWithValue("@MOTIVO", llamada.MOTIVO);
            if (llamada.REC_LIST_DESCTO == null)
                _ = cmd.Parameters.AddWithValue("@REC_LIST_DESCTO", DBNull.Value);
            else
                _ = cmd.Parameters.AddWithValue("@REC_LIST_DESCTO", llamada.REC_LIST_DESCTO);
            if (llamada.DESCUENTO == null)
                _ = cmd.Parameters.AddWithValue("@DESCUENTO", DBNull.Value);
            else
                _ = cmd.Parameters.AddWithValue("@DESCUENTO", llamada.DESCUENTO);
            _ = cmd.Parameters.AddWithValue("@PROCESO_RESULT", llamada.PROCESO_RESULT);
            _ = cmd.Parameters.AddWithValue("@ESTADO", llamada.ESTADO);
            _ = cmd.Parameters.AddWithValue("@USUARIO_CREA", llamada.USUARIO_CREACION);

            return cmd.ExecuteNonQuery() > 0;
        }

        public bool ResultadoYProgramarLlamada(List<LLamadas> lstLlamada)
        {
            conn.Open();
            SqlTransaction sqlTransaction = conn.BeginTransaction();
            bool result = true;
            try
            {
                foreach (LLamadas llamada in lstLlamada)
                {
                    if (!result)
                        break;
                    if (llamada.PersonaEnvioTo != null)
                    {
                        SeguimientoPlanillaTo se = new SeguimientoPlanillaTo
                        {
                            PersonaEnvio = llamada.PersonaEnvioTo
                        };
                        if (llamada.PersonaEnvioTo.ID_PERSONA != 0)
                        {
                            if (InsertarLLamada(llamada, sqlTransaction))
                            {
                                if (llamada.ID_LLAMADA_BASE != 0)
                                {
                                    if (CerrarLlamadaProgramada())
                                    {
                                        result = true;
                                        continue;
                                    }
                                }
                                else
                                {
                                    result = true;
                                    continue;
                                }
                            }
                        }
                        else
                        {
                            if (InsertarPersonaEnvio(ref se, sqlTransaction, conn))
                            {
                                if (InsertarLLamada(llamada, sqlTransaction))
                                {
                                    if (llamada.ID_LLAMADA_BASE != 0)
                                    {
                                        if (CerrarLlamadaProgramada())
                                        {
                                            result = true;
                                            continue;
                                        }
                                    }
                                    else
                                    {
                                        result = true;
                                        continue;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (InsertarLLamada(llamada, sqlTransaction))
                        {
                            result = true;
                            continue;
                        }
                    }
                    result = false;

                    bool CerrarLlamadaProgramada()
                    {
                        const string procedure = "usp_CerrarLlamadaPendiente";

                        SqlCommand cmd = new SqlCommand(procedure, conn, sqlTransaction)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        _ = cmd.Parameters.AddWithValue("@ID_LLAMADA", llamada.ID_LLAMADA_BASE);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }

                if (result)
                    sqlTransaction.Commit();
                else
                    sqlTransaction.Rollback();
            }
            catch (Exception)
            {
                sqlTransaction.Rollback();
                throw;
            }
            finally
            {
                conn.Close();
            }
            return result;
        }

        public bool ModificarLlamada(LLamadas llamada)
        {
            conn.Open();
            SqlTransaction sqlTransaction = conn.BeginTransaction();
            try
            {
                if (llamada.PersonaEnvioTo != null)
                {
                    SeguimientoPlanillaTo seguimiento = new SeguimientoPlanillaTo()
                    {
                        PersonaEnvio = llamada.PersonaEnvioTo
                    };
                    if (llamada.PersonaEnvioTo.ID_PERSONA != 0)
                    {
                        if (ActualizarPersonaEnvio(seguimiento, sqlTransaction, conn))
                        {
                            if (ActualizarLlamada(llamada, sqlTransaction, conn))
                            {
                                sqlTransaction.Commit();
                                return true;
                            }
                        }
                    }
                    else
                    {
                        if (InsertarPersonaEnvio(ref seguimiento, sqlTransaction, conn))
                        {
                            llamada.PersonaEnvioTo.ID_PERSONA = seguimiento.PersonaEnvio.ID_PERSONA;
                            if (ActualizarLlamada(llamada, sqlTransaction, conn))
                            {
                                sqlTransaction.Commit();
                                return true;
                            }
                        }
                    }
                }
                else
                {
                    if (ActualizarLlamada(llamada, sqlTransaction, conn))
                    {
                        if (llamada.SeguimientoPlanillaTo.PersonaEnvio.ID_PERSONA != 0)
                        {
                            if (EliminarPersonaEnvio(llamada.SeguimientoPlanillaTo, sqlTransaction, conn, 1))
                            {
                                sqlTransaction.Commit();
                                return true;
                            }
                        }
                        else
                        {
                            sqlTransaction.Commit();
                            return true;
                        }
                    }
                }
                sqlTransaction.Rollback();
                return false;
            }
            catch (Exception)
            {
                sqlTransaction.Rollback();
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        private bool ActualizarLlamada(LLamadas llamada, SqlTransaction sqlTransaction, SqlConnection cn)
        {
            const string procedure = "usp_ActualizarLlamada";
            try
            {
                SqlCommand cmd = new SqlCommand(procedure, cn, sqlTransaction)
                {
                    CommandType = CommandType.StoredProcedure
                };

                _ = cmd.Parameters.AddWithValue("@ID_LLAMADA", llamada.ID_LLAMADA_BASE);
                _ = cmd.Parameters.AddWithValue("@FECHA_LLAMADA", llamada.FECHA_LLAMADA);
                _ = cmd.Parameters.AddWithValue("@HORA_LLAMADA", llamada.HORA_LLAMADA);
                if (llamada.PersonaEnvioTo == null || llamada.PersonaEnvioTo.ID_PERSONA == 0)
                    _ = cmd.Parameters.AddWithValue("@ID_PERSONA", DBNull.Value);
                else
                    _ = cmd.Parameters.AddWithValue("@ID_PERSONA", llamada.PersonaEnvioTo.ID_PERSONA);
                _ = cmd.Parameters.AddWithValue("@NOMBRE_INST", llamada.NOMBRE_INST);
                _ = cmd.Parameters.AddWithValue("@TLF_INST", llamada.TLF_INST);
                _ = cmd.Parameters.AddWithValue("@OBSERVACION", llamada.OBSERVACION);
                if (llamada.SeguimientoPlanillaTo.IMPORTE_DESCUENTO == 0)
                    _ = cmd.Parameters.AddWithValue("@IMPORTE_DESCUENTO", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@IMPORTE_DESCUENTO", llamada.SeguimientoPlanillaTo.IMPORTE_DESCUENTO);
                if (llamada.DESCUENTO == null)
                    _ = cmd.Parameters.AddWithValue("@DESCUENTO", DBNull.Value);
                else
                    _ = cmd.Parameters.AddWithValue("@DESCUENTO", llamada.DESCUENTO);
                if (llamada.REC_LIST_DESCTO == null)
                    _ = cmd.Parameters.AddWithValue("@REC_LIST_DESCTO", DBNull.Value);
                else
                    _ = cmd.Parameters.AddWithValue("@REC_LIST_DESCTO", llamada.REC_LIST_DESCTO);
                _ = cmd.Parameters.AddWithValue("@USUARIO_MODIFICACION", llamada.USUARIO_CREACION);
                _ = cmd.Parameters.AddWithValue("@MOTIVO", llamada.MOTIVO);

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool EliminarLlamada(LLamadas llamdas)
        {
            const string procedure = "usp_EliminarLlamada";
            conn.Open();
            SqlTransaction sqlTransaction = conn.BeginTransaction();
            SqlCommand cmd = new SqlCommand(procedure, conn, sqlTransaction)
            {
                CommandType = CommandType.StoredProcedure
            };

            _ = cmd.Parameters.AddWithValue("@ID_LLAMADA", llamdas.ID_LLAMADA_BASE);
            try
            {
                int cantPersona = ObtenerLlamadasXIdPersona(llamdas.SeguimientoPlanillaTo.PersonaEnvio.ID_PERSONA, sqlTransaction).Rows.Count;
                if (cmd.ExecuteNonQuery() > 0)
                {
                    if (llamdas.SeguimientoPlanillaTo.PersonaEnvio.ID_PERSONA != 0)
                    {
                        SeguimientoPlanillaTo seguimiento = new SeguimientoPlanillaTo()
                        {
                            PersonaEnvio = llamdas.SeguimientoPlanillaTo.PersonaEnvio
                        };
                        if (cantPersona == 1)
                        {
                            if (EliminarPersonaEnvio(seguimiento, sqlTransaction, conn, 1))
                            {
                                sqlTransaction.Commit();
                                return true;
                            }
                        }
                        else
                        {
                            sqlTransaction.Commit();
                            return true;
                        }
                    }
                    else
                    {
                        sqlTransaction.Commit();
                        return true;
                    }
                }
                sqlTransaction.Rollback();
                return false;
            }
            catch (Exception)
            {
                sqlTransaction.Rollback();
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public DataTable ObtenerHistorialSeguimiento(int idSeguimiento)
        {
            const string function = "usp_ObtenerHistorialSeguimiento";

            SqlCommand cmd = new SqlCommand(function, conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            _ = cmd.Parameters.AddWithValue("@ID_SEGUIMIENTO", idSeguimiento);

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

        public DataTable ListarRecepcionPlanillasXTipoRecepcion(int idSeguimiento, string tipoRecepcion)
        {
            const string function = "SELECT * FROM fn_ListarRecepcionPlanilla(@ID_SEGUIMIENTO) WHERE TIPO_RECEPCION = @TIPO_RECEPCION";
            SqlCommand cmd = new SqlCommand(function, conn)
            {
                CommandType = CommandType.Text
            };

            _ = cmd.Parameters.AddWithValue("@ID_SEGUIMIENTO", idSeguimiento);
            _ = cmd.Parameters.AddWithValue("@TIPO_RECEPCION", tipoRecepcion);
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

        public bool GrabarSeguimientoPlanillaFase2(ref SeguimientoPlanillaTo se, CRUD crud)
        {
            SqlTransaction sqlTransaction = null;
            SqlConnection cn = conn;

            try
            {
                cn.Open();
                sqlTransaction = cn.BeginTransaction("STSeguimiento");
                switch (crud)
                {
                    case CRUD.Insertar:
                        if (RegistrarSeguimientoPlanillaFase2(se, sqlTransaction, cn))
                        {
                            sqlTransaction.Commit();
                            return true;
                        }
                        break;
                    case CRUD.Actualizar:
                        if (ModificarSeguimientoPlanillaFase2(se, sqlTransaction, cn))
                        {
                            sqlTransaction.Commit();
                            return true;
                        }
                        break;
                    case CRUD.Eliminar:
                        if (EliminarRecepcionPlanilla(se, sqlTransaction, cn))
                        {
                            sqlTransaction.Commit();
                            return true;
                        }
                        break;
                    default:
                        return true;
                }

                sqlTransaction.Rollback();
                return false;
            }
            catch (Exception)
            {
                sqlTransaction.Rollback();
                throw;
            }
            finally
            {
                cn.Close();
            }
        }

        private bool RegistrarSeguimientoPlanillaFase2(SeguimientoPlanillaTo se, SqlTransaction sqlTransaction, SqlConnection cn)
        {
            try
            {
                DataTable dt = ValidarExistenciaPlaSiguimiento(se, sqlTransaction, cn);
                if (dt != null && dt.Rows.Count > 0)
                {
                    if (Convert.ToInt32(dt.Rows[0]["ID_ESTADO"]) != RECEPCIONADA && Convert.ToInt32(dt.Rows[0]["ID_ESTADO"]) != RECEPCIONADO_CERRADO && Convert.ToInt32(dt.Rows[0]["ID_ESTADO"]) != PROCESADA)
                    {
                        if (InsertarPersonaEnvio(ref se, sqlTransaction, cn))
                        {
                            if (InsertarRecepcionPlanilla(se, sqlTransaction, cn))
                            {
                                if (InsertarHistorialSeguimiento(se, sqlTransaction, cn))
                                {
                                    return true;
                                }
                            }
                        }
                    }
                    else
                    {
                        se.ID_SEGUIMIENTO = Convert.ToInt32(dt.Rows[0]["ID_SEGUIMIENTO"]);
                        if (InsertarPersonaEnvio(ref se, sqlTransaction, cn))
                        {
                            return InsertarRecepcionPlanilla(se, sqlTransaction, cn);
                        }
                    }
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool InsertarRecepcionPlanilla(SeguimientoPlanillaTo se, SqlTransaction sqlTransaction, SqlConnection cn)
        {
            try
            {
                const string procedure = "usp_InsertarRecepcionPlanilla";
                SqlCommand cmd = new SqlCommand(procedure, cn, sqlTransaction)
                {
                    CommandType = CommandType.StoredProcedure
                };

                _ = cmd.Parameters.AddWithValue("@ID_SEGUIMIENTO", se.ID_SEGUIMIENTO);
                _ = cmd.Parameters.AddWithValue("@FECHA_RECEPCION", se.RecepcionPlanillaTo.FECHA_RECEPCION);
                _ = cmd.Parameters.AddWithValue("@HORA_RECEPCION", se.RecepcionPlanillaTo.HORA_RECEPCION);
                _ = cmd.Parameters.AddWithValue("@AREA_RECEPCION", se.RecepcionPlanillaTo.AREA_RECEPCION);
                _ = cmd.Parameters.AddWithValue("@TIPO_RECEPCION", se.RecepcionPlanillaTo.TIPO_REPCION);
                _ = cmd.Parameters.AddWithValue("@ID_PERSONA", se.PersonaEnvio.ID_PERSONA);
                _ = cmd.Parameters.AddWithValue("@OBSERVACION", se.RecepcionPlanillaTo.OBSERVACION);
                _ = cmd.Parameters.AddWithValue("@USUARIO_CREA", se.USUARIO_CREA);

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool ModificarSeguimientoPlanillaFase2(SeguimientoPlanillaTo se, SqlTransaction sqlTransaction, SqlConnection cn)
        {
            try
            {
                if (ActualizarRecepcionPlanilla(se, sqlTransaction, cn))
                {
                    return ActualizarPersonaEnvio(se, sqlTransaction, cn);
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool ActualizarRecepcionPlanilla(SeguimientoPlanillaTo se, SqlTransaction sqlTransaction, SqlConnection cn)
        {
            try
            {
                const string procedure = "usp_ActualizarRecepcionPlanilla";
                SqlCommand cmd = new SqlCommand(procedure, cn, sqlTransaction)
                {
                    CommandType = CommandType.StoredProcedure
                };

                _ = cmd.Parameters.AddWithValue("@ID_RECEPCION", se.RecepcionPlanillaTo.ID_RECEPCION);
                _ = cmd.Parameters.AddWithValue("@ID_SEGUIMIENTO", se.ID_SEGUIMIENTO);
                _ = cmd.Parameters.AddWithValue("@FECHA_RECEPCION", se.RecepcionPlanillaTo.FECHA_RECEPCION);
                _ = cmd.Parameters.AddWithValue("@HORA_RECEPCION", se.RecepcionPlanillaTo.HORA_RECEPCION);
                _ = cmd.Parameters.AddWithValue("@AREA_RECEPCION", se.RecepcionPlanillaTo.AREA_RECEPCION);
                _ = cmd.Parameters.AddWithValue("@TIPO_RECEPCION", se.RecepcionPlanillaTo.TIPO_REPCION);
                _ = cmd.Parameters.AddWithValue("@USUARIO_MODIFICA", se.USUARIO_MODIFICA);
                _ = cmd.Parameters.AddWithValue("@OBSERVACION", se.RecepcionPlanillaTo.OBSERVACION);

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool EliminarRecepcionPlanilla(SeguimientoPlanillaTo se, SqlTransaction sqlTransaction, SqlConnection cn)
        {
            const string procedure = "usp_EliminarRecepcionPlanilla";
            try
            {
                SqlCommand cmd = new SqlCommand(procedure, cn, sqlTransaction)
                {
                    CommandType = CommandType.StoredProcedure
                };

                _ = cmd.Parameters.AddWithValue("@ID_RECEPCION", se.RecepcionPlanillaTo.ID_RECEPCION);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    return EliminarPersonaEnvio(se, sqlTransaction, cn, 1);
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable ListarLlamadasPendientes()
        {
            const string procedure = "usp_ListarLlamadasPendientes";

            SqlCommand cmd = new SqlCommand(procedure, conn)
            {
                CommandType = CommandType.StoredProcedure
            };

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

        public DataTable ListarLlamadasPendienetesXEtapa(int idEstado)
        {
            const string procedure = "usp_ListarLlamadasPedientesXEtapa";
            SqlCommand cmd = new SqlCommand(procedure, conn)
            {
                CommandType = CommandType.StoredProcedure,
                CommandTimeout = 4000

            };

            _ = cmd.Parameters.AddWithValue("@ID_ESTADO", idEstado);
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

        public bool RegresarEstadoAnterior(int idSeguimiento, int idEstado, int idEstadoAnterior)
        {
            const string procedure = "usp_RegresarEstadoAnterior";
            SqlCommand cmd = new SqlCommand(procedure, conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            _ = cmd.Parameters.AddWithValue("@ID_SEGUIMIENTO", idSeguimiento);
            _ = cmd.Parameters.AddWithValue("@ID_ESTADO", idEstado);
            _ = cmd.Parameters.AddWithValue("@ID_ESTADO_ANTERIOR", idEstadoAnterior);

            try
            {
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

        public bool RegresarEstadoAnteriorTransaction(int idSeguimiento, int idEstado, int idEstadoAnterior, string usuario)
        {
            const string procedure = "usp_RegresarEstadoAnterior";
            conn.Open();
            SqlTransaction sqlTransaction = conn.BeginTransaction();
            SqlCommand cmd = new SqlCommand(procedure, conn, sqlTransaction)
            {
                CommandType = CommandType.StoredProcedure
            };

            _ = cmd.Parameters.AddWithValue("@ID_SEGUIMIENTO", idSeguimiento);
            _ = cmd.Parameters.AddWithValue("@ID_ESTADO", idEstado);
            _ = cmd.Parameters.AddWithValue("@ID_ESTADO_ANTERIOR", idEstadoAnterior);

            try
            {
                if (cmd.ExecuteNonQuery() > 0)
                {
                    SeguimientoPlanillaTo se = new SeguimientoPlanillaTo()
                    {
                        ID_SEGUIMIENTO = idSeguimiento,
                        ID_ESTADO = idEstadoAnterior,
                        USUARIO_CREA = usuario
                    };
                    if (InsertarHistorialSeguimiento(se, sqlTransaction, conn))
                    {
                        sqlTransaction.Commit();
                        return true;
                    }
                }
                sqlTransaction.Rollback();
                return false;
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

        public DataTable ObtenerLlamadasXId(int idLlamada)
        {
            const string function = "SELECT * FROM fn_ObtenerLlamadasXId(@ID_LLAMADA)";
            SqlCommand cmd = new SqlCommand(function, conn)
            {
                CommandType = CommandType.Text
            };

            _ = cmd.Parameters.AddWithValue("@ID_LLAMADA", idLlamada);

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

        public DataTable ObtenerLlamadaXIdLlamadaBase(int idLlamadaBase)
        {
            const string function = "SELECT * FROM fn_ObtenerLlamadasXIdLlamadaBase(@ID_LLAMADA_BASE)";
            SqlCommand cmd = new SqlCommand(function, conn)
            {
                CommandType = CommandType.Text
            };

            _ = cmd.Parameters.AddWithValue("@ID_LLAMADA_BASE", idLlamadaBase);

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

        public DataTable ListarPlanillasXConfirmarProcesamiento(string codPtoCob, DateTime dtFechaInicio, DateTime dtFechaFin, int acces)
        {
            const string function = "SELECT * FROM fn_ListarPlanillasXConfirmProcesamiento(@CodPtoCob,@FechaEnvioInicio,@FechaEnvioInicio,@Acces)";
            SqlCommand cmd = new SqlCommand(function, conn)
            {
                CommandType = CommandType.Text
            };

            _ = cmd.Parameters.AddWithValue("@CodPtoCob", codPtoCob);
            _ = cmd.Parameters.AddWithValue("@FechaEnvioInicio", dtFechaInicio);
            _ = cmd.Parameters.AddWithValue("@FechaEnvioFin", dtFechaFin);
            _ = cmd.Parameters.AddWithValue("@Acces", acces);

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

        public DataTable ListarPlanillasXConfirmarDescuento(string codPtoCob, DateTime dtFechaInicio, DateTime dtFechaFin, int acces)
        {
            const string function = "SELECT * FROM fn_ListarPlanillasXConfirmDescto(@CodPtoCob,@FechaEnvioInicio,@FechaEnvioInicio,@Acces)";
            SqlCommand cmd = new SqlCommand(function, conn)
            {
                CommandType = CommandType.Text
            };

            _ = cmd.Parameters.AddWithValue("@CodPtoCob", codPtoCob);
            _ = cmd.Parameters.AddWithValue("@FechaEnvioInicio", dtFechaInicio);
            _ = cmd.Parameters.AddWithValue("@FechaEnvioFin", dtFechaFin);
            _ = cmd.Parameters.AddWithValue("@Acces", acces);

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

        private DataTable ObtenerLlamadasXIdPersona(int idPersona, SqlTransaction sqlTransaction)
        {
            const string function = "SELECT * FROM fn_ObtenerLlamadasXIdPersona(@ID_PERSONA)";
            SqlCommand cmd = new SqlCommand(function, conn, sqlTransaction)
            {
                CommandType = CommandType.Text
            };

            _ = cmd.Parameters.AddWithValue("@ID_PERSONA", idPersona);

            try
            {
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

        public DataTable ListarLlamadasPendientesXIdSeguimiento(int idSeguimiento)
        {
            const string function = "SELECT * FROM fn_ListarLlamadasPendientesXIdSeguimiento(@ID_SEGUIMIENTO)";
            SqlCommand cmd = new SqlCommand(function, conn)
            {
                CommandType = CommandType.Text,
            };

            _ = cmd.Parameters.AddWithValue("@ID_SEGUIMIENTO", idSeguimiento);

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

        public bool CerrarEtapaDecuento(SeguimientoPlanillaTo se)
        {
            conn.Open();
            SqlTransaction tr = conn.BeginTransaction();
            const string procedure = "usp_CerrarEtapaDescuento";
            try
            {
                SqlCommand cmd = new SqlCommand(procedure, conn, tr)
                {
                    CommandType = CommandType.StoredProcedure
                };

                _ = cmd.Parameters.AddWithValue("@ID_ESTADO", se.ID_ESTADO);
                _ = cmd.Parameters.AddWithValue("@ID_SEGUIMIENTO", se.ID_SEGUIMIENTO);
                _ = cmd.Parameters.AddWithValue("@USUARIO_CREA", se.USUARIO_CREA);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    if (InsertarHistorialSeguimiento(se, tr, conn))
                    {
                        tr.Commit();
                        return true;
                    }
                }
                tr.Rollback();
                return false;
            }
            catch (Exception)
            {
                tr.Rollback();
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool ResultadoLlamadaYDescuento(LLamadas llamada1)
        {
            try
            {
                conn.Open();
                SqlTransaction sqlTransaction = conn.BeginTransaction();
                if (RegistrarLlamada(llamada1, sqlTransaction))
                {
                    if (InsertarHistorialSeguimiento(llamada1.SeguimientoPlanillaTo, sqlTransaction, conn))
                    {
                        if (InsertarImporte(llamada1.SeguimientoPlanillaTo, sqlTransaction, conn))
                        {
                            sqlTransaction.Commit();
                            return true;
                        }
                    }
                }
                sqlTransaction.Rollback();
                return false;
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

        private bool InsertarImporte(SeguimientoPlanillaTo se, SqlTransaction sqlTrans, SqlConnection cn, bool esNullImportes = false)
        {
            const string procedure = "usp_InsertarImporteDescuento";
            SqlCommand cmd = new SqlCommand(procedure, cn, sqlTrans)
            {
                CommandType = CommandType.StoredProcedure
            };

            _ = cmd.Parameters.AddWithValue("@ID_SEGUIMIENTO", se.ID_SEGUIMIENTO);
            if ((se.ID_ESTADO == DESCONTADA || se.ID_ESTADO == PROCESADA_CERRADA) && esNullImportes)
            {
                _ = cmd.Parameters.AddWithValue("@IMPORTE_DESCUENTO", DBNull.Value);
                _ = cmd.Parameters.AddWithValue("@IMPORTE_CASILLERO", DBNull.Value);
                _ = cmd.Parameters.AddWithValue("@IMPORTE_NETO", DBNull.Value);
                _ = cmd.Parameters.AddWithValue("@OTROS_DSCTOS", DBNull.Value);
                _ = cmd.Parameters.AddWithValue("@PORCENTAJE_CASILLERO", DBNull.Value);
                _ = cmd.Parameters.AddWithValue("@IMPORTE_LISTADO", DBNull.Value);
                _ = cmd.Parameters.AddWithValue("@IMPORTE_CASILLERO_MAN", DBNull.Value);
                _ = cmd.Parameters.AddWithValue("@IMPORTE_EJECUTADO", DBNull.Value);
                _ = cmd.Parameters.AddWithValue("@OBSERVACION", string.Empty);
                _ = cmd.Parameters.AddWithValue("@ID_ESTADO", PROCESADA_CERRADA);
            }
            else if (esNullImportes)
            {
                _ = cmd.Parameters.AddWithValue("@IMPORTE_DESCUENTO", DBNull.Value);
                _ = cmd.Parameters.AddWithValue("@IMPORTE_CASILLERO", DBNull.Value);
                _ = cmd.Parameters.AddWithValue("@IMPORTE_NETO", DBNull.Value);
                _ = cmd.Parameters.AddWithValue("@OTROS_DSCTOS", DBNull.Value);
                _ = cmd.Parameters.AddWithValue("@PORCENTAJE_CASILLERO", DBNull.Value);
                _ = cmd.Parameters.AddWithValue("@IMPORTE_LISTADO", DBNull.Value);
                _ = cmd.Parameters.AddWithValue("@IMPORTE_CASILLERO_MAN", DBNull.Value);
                _ = cmd.Parameters.AddWithValue("@IMPORTE_EJECUTADO", DBNull.Value);
                _ = cmd.Parameters.AddWithValue("@OBSERVACION", string.Empty);
                _ = cmd.Parameters.AddWithValue("@ID_ESTADO", se.ID_ESTADO);
            }
            else
            {
                _ = cmd.Parameters.AddWithValue("@IMPORTE_DESCUENTO", se.IMPORTE_DESCUENTO);
                _ = cmd.Parameters.AddWithValue("@IMPORTE_CASILLERO", se.IMPORTE_CASILLERO);
                _ = cmd.Parameters.AddWithValue("@IMPORTE_NETO", se.IMPORTE_RETENIDO);
                _ = cmd.Parameters.AddWithValue("@OTROS_DSCTOS", se.OTROS_DSCTOS);
                _ = cmd.Parameters.AddWithValue("@PORCENTAJE_CASILLERO", se.PORCENTAJE_CASILLERO);
                _ = cmd.Parameters.AddWithValue("@IMPORTE_LISTADO", se.IMPORTE_LISTADO);
                _ = cmd.Parameters.AddWithValue("@IMPORTE_CASILLERO_MAN", se.IMPORTE_CASILLERO_MAN);
                _ = cmd.Parameters.AddWithValue("@IMPORTE_EJECUTADO", se.IMPORTE_EJECUTADO);
                _ = cmd.Parameters.AddWithValue("@OBSERVACION", se.OBSERVACION);
                _ = cmd.Parameters.AddWithValue("@ID_ESTADO", se.ID_ESTADO);
            }

            try
            {
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ModifiacaLlamadaYDescuento(LLamadas llamada, bool chkNo, bool chkNoSel)
        {
            conn.Open();
            SqlTransaction sqlTransaction = conn.BeginTransaction();
            try
            {
                int id_estado = Convert.ToInt32(ObtenerSeguimientoPlanillaXIdSeguimiento(llamada.SeguimientoPlanillaTo.ID_SEGUIMIENTO).Rows[0]["ID_ESTADO"]);
                if (llamada.PersonaEnvioTo != null)
                {
                    SeguimientoPlanillaTo seguimiento = new SeguimientoPlanillaTo()
                    {
                        PersonaEnvio = llamada.PersonaEnvioTo
                    };
                    if (llamada.PersonaEnvioTo.ID_PERSONA != 0)
                    {
                        if (ActualizarPersonaEnvio(seguimiento, sqlTransaction, conn))
                        {
                            if (ActualizarLlamada(llamada, sqlTransaction, conn))
                            {
                                bool esNullImportes = chkNo || chkNoSel;
                                if (InsertarImporte(llamada.SeguimientoPlanillaTo, sqlTransaction, conn, esNullImportes))
                                {
                                    if (chkNo)
                                    {
                                        _ = EliminarHistorialSeguimiento(llamada.SeguimientoPlanillaTo, sqlTransaction, conn);
                                        sqlTransaction.Commit();
                                        return true;
                                    }
                                    else
                                    {
                                        if (chkNoSel || id_estado != DESCONTADA)
                                        {
                                            if (chkNoSel)
                                            {
                                                if (id_estado == DESCONTADA)
                                                    _ = EliminarHistorialSeguimiento(llamada.SeguimientoPlanillaTo, sqlTransaction, conn);
                                                llamada.SeguimientoPlanillaTo.ID_ESTADO = NO_DESCONTADO;
                                            }
                                            if (InsertarHistorialSeguimiento(llamada.SeguimientoPlanillaTo, sqlTransaction, conn))
                                            {
                                                sqlTransaction.Commit();
                                                return true;
                                            }
                                        }
                                        sqlTransaction.Commit();
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (InsertarPersonaEnvio(ref seguimiento, sqlTransaction, conn))
                        {
                            llamada.PersonaEnvioTo.ID_PERSONA = seguimiento.PersonaEnvio.ID_PERSONA;
                            if (ActualizarLlamada(llamada, sqlTransaction, conn))
                            {
                                if (InsertarImporte(llamada.SeguimientoPlanillaTo, sqlTransaction, conn))
                                {
                                    if (chkNo)
                                    {
                                        _ = EliminarHistorialSeguimiento(llamada.SeguimientoPlanillaTo, sqlTransaction, conn);
                                        sqlTransaction.Commit();
                                        return true;

                                    }
                                    else
                                    {
                                        if (id_estado != DESCONTADA)
                                        {
                                            if (InsertarHistorialSeguimiento(llamada.SeguimientoPlanillaTo, sqlTransaction, conn))
                                            {
                                                sqlTransaction.Commit();
                                                return true;
                                            }
                                        }
                                        sqlTransaction.Commit();
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (ActualizarLlamada(llamada, sqlTransaction, conn))
                    {
                        if (llamada.SeguimientoPlanillaTo.PersonaEnvio.ID_PERSONA != 0)
                        {
                            if (EliminarPersonaEnvio(llamada.SeguimientoPlanillaTo, sqlTransaction, conn, 1))
                            {
                                if (InsertarImporte(llamada.SeguimientoPlanillaTo, sqlTransaction, conn))
                                {
                                    if (chkNo)
                                    {
                                        _ = EliminarHistorialSeguimiento(llamada.SeguimientoPlanillaTo, sqlTransaction, conn);
                                        sqlTransaction.Commit();
                                        return true;

                                    }
                                    else
                                    {
                                        if (id_estado != DESCONTADA)
                                        {
                                            if (InsertarHistorialSeguimiento(llamada.SeguimientoPlanillaTo, sqlTransaction, conn))
                                            {
                                                sqlTransaction.Commit();
                                                return true;
                                            }
                                        }
                                        sqlTransaction.Commit();
                                        return true;
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (InsertarImporte(llamada.SeguimientoPlanillaTo, sqlTransaction, conn))
                            {
                                if (chkNo)
                                {
                                    _ = EliminarHistorialSeguimiento(llamada.SeguimientoPlanillaTo, sqlTransaction, conn);
                                    sqlTransaction.Commit();
                                    return true;
                                }
                                else
                                {
                                    if (id_estado != DESCONTADA)
                                    {
                                        if (InsertarHistorialSeguimiento(llamada.SeguimientoPlanillaTo, sqlTransaction, conn))
                                        {
                                            sqlTransaction.Commit();
                                            return true;
                                        }
                                    }
                                    sqlTransaction.Commit();
                                    return true;
                                }
                            }
                        }
                    }
                }
                sqlTransaction.Rollback();
                return false;
            }
            catch (Exception)
            {
                sqlTransaction.Rollback();
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool ModifiacaLlamadaEtapaLista(LLamadas llamada, bool chkSiNo, bool showChecked, DateTime fechaTrans, List<SeguimientoPlanillaTo> lstImportes)
        {
            conn.Open();
            SqlTransaction sqlTransaction = conn.BeginTransaction();
            try
            {
                if (llamada.PersonaEnvioTo != null)
                {
                    SeguimientoPlanillaTo seguimiento = new SeguimientoPlanillaTo()
                    {
                        PersonaEnvio = llamada.PersonaEnvioTo
                    };
                    if (llamada.PersonaEnvioTo.ID_PERSONA != 0)
                    {
                        if (ActualizarPersonaEnvio(seguimiento, sqlTransaction, conn))
                        {
                            if (ActualizarLlamada(llamada, sqlTransaction, conn) && InsertarNoProcesoPlla(llamada.SeguimientoPlanillaTo, lstImportes, showChecked, sqlTransaction, conn))
                            {
                                if (InsertarImporte(llamada.SeguimientoPlanillaTo, sqlTransaction, conn) && InsertarImportesSeguiPlla(llamada.SeguimientoPlanillaTo, lstImportes, showChecked, sqlTransaction, conn))
                                {
                                    if (showChecked)
                                    {
                                        if (llamada.SeguimientoPlanillaTo.ID_ESTADO != NO_EJECUTADO && llamada.SeguimientoPlanillaTo.ID_ESTADO != NO_DESCONTADO)
                                            llamada.SeguimientoPlanillaTo.ID_ESTADO = DESCONTADO_CONFIRMADO;
                                        if (InsertarHistorialSeguimiento(llamada.SeguimientoPlanillaTo, sqlTransaction, conn))
                                        {
                                            if (TransferirPlanillasSiDescontadas(llamada.SeguimientoPlanillaTo.ID_SEGUIMIENTO, fechaTrans, sqlTransaction, conn))
                                            {
                                                sqlTransaction.Commit();
                                                return true;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        sqlTransaction.Commit();
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (InsertarPersonaEnvio(ref seguimiento, sqlTransaction, conn))
                        {
                            llamada.PersonaEnvioTo.ID_PERSONA = seguimiento.PersonaEnvio.ID_PERSONA;
                            if (ActualizarLlamada(llamada, sqlTransaction, conn))
                            {
                                if (InsertarImporte(llamada.SeguimientoPlanillaTo, sqlTransaction, conn) && InsertarImportesSeguiPlla(llamada.SeguimientoPlanillaTo, lstImportes, showChecked, sqlTransaction, conn))
                                {
                                    if (showChecked)
                                    {
                                        if (llamada.SeguimientoPlanillaTo.ID_ESTADO != NO_EJECUTADO)
                                            llamada.SeguimientoPlanillaTo.ID_ESTADO = DESCONTADO_CONFIRMADO;
                                        if (InsertarHistorialSeguimiento(llamada.SeguimientoPlanillaTo, sqlTransaction, conn))
                                        {
                                            if (TransferirPlanillasSiDescontadas(llamada.SeguimientoPlanillaTo.ID_SEGUIMIENTO, fechaTrans, sqlTransaction, conn))
                                            {
                                                sqlTransaction.Commit();
                                                return true;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        sqlTransaction.Commit();
                                        return true;
                                    }
                                }
                                //else
                                //{
                                //    sqlTransaction.Commit();
                                //    return true;
                                //}
                            }
                        }
                    }
                }
                else
                {
                    if (ActualizarLlamada(llamada, sqlTransaction, conn))
                    {
                        if (llamada.SeguimientoPlanillaTo.PersonaEnvio.ID_PERSONA != 0)
                        {
                            if (EliminarPersonaEnvio(llamada.SeguimientoPlanillaTo, sqlTransaction, conn, 1))
                            {
                                if (InsertarImporte(llamada.SeguimientoPlanillaTo, sqlTransaction, conn) && InsertarImportesSeguiPlla(llamada.SeguimientoPlanillaTo, lstImportes, showChecked, sqlTransaction, conn))
                                {
                                    if (showChecked)
                                    {
                                        if (llamada.SeguimientoPlanillaTo.ID_ESTADO != NO_EJECUTADO)
                                            llamada.SeguimientoPlanillaTo.ID_ESTADO = DESCONTADO_CONFIRMADO;
                                        if (InsertarHistorialSeguimiento(llamada.SeguimientoPlanillaTo, sqlTransaction, conn))
                                        {
                                            if (TransferirPlanillasSiDescontadas(llamada.SeguimientoPlanillaTo.ID_SEGUIMIENTO, fechaTrans, sqlTransaction, conn))
                                            {
                                                sqlTransaction.Commit();
                                                return true;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        sqlTransaction.Commit();
                                        return true;
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (InsertarImporte(llamada.SeguimientoPlanillaTo, sqlTransaction, conn) && InsertarImportesSeguiPlla(llamada.SeguimientoPlanillaTo, lstImportes, showChecked, sqlTransaction, conn))
                            {
                                if (showChecked)
                                {
                                    if (llamada.SeguimientoPlanillaTo.ID_ESTADO != NO_EJECUTADO)
                                        llamada.SeguimientoPlanillaTo.ID_ESTADO = DESCONTADO_CONFIRMADO;
                                    if (InsertarHistorialSeguimiento(llamada.SeguimientoPlanillaTo, sqlTransaction, conn))
                                    {
                                        if (TransferirPlanillasSiDescontadas(llamada.SeguimientoPlanillaTo.ID_SEGUIMIENTO, fechaTrans, sqlTransaction, conn))
                                        {
                                            sqlTransaction.Commit();
                                            return true;
                                        }
                                    }
                                }
                                else
                                {
                                    sqlTransaction.Commit();
                                    return true;
                                }
                            }
                        }
                    }
                }
                sqlTransaction.Rollback();
                return false;
            }
            catch (Exception)
            {
                sqlTransaction.Rollback();
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        private bool EliminarHistorialSeguimiento(SeguimientoPlanillaTo se, SqlTransaction sqlTrans, SqlConnection cn)
        {
            const string procedure = "usp_EliminarHistorialSeguimiento";
            SqlCommand cmd = new SqlCommand(procedure, cn, sqlTrans)
            {
                CommandType = CommandType.StoredProcedure
            };

            _ = cmd.Parameters.AddWithValue("@ID_SEGUIMIENTO", se.ID_SEGUIMIENTO);
            _ = cmd.Parameters.AddWithValue("@ID_ESTADO", se.ID_ESTADO);

            try
            {
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable ObtenerSeguimientoPlanillaXIdSeguimiento(int idSeguimiento)
        {
            const string function = "SELECT * FROM fn_ObtenerSeguimientoPlanillaXIdSeguimiento(@ID_SEGUIMIENTO)";
            SqlCommand cmd = new SqlCommand(function, conn2)
            {
                CommandType = CommandType.Text
            };

            _ = cmd.Parameters.AddWithValue("@ID_SEGUIMIENTO", idSeguimiento);

            try
            {
                conn2.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr, LoadOption.Upsert);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn2.Close();
            }
        }

        public DataTable ListarPlanillasDescontadas(string codPtoCob, int acces)
        {
            const string function = "SELECT * FROM fn_ListarPlanillasDescontadas(@CodPtoCob,default,default,@Acces)";
            SqlCommand cmd = new SqlCommand(function, conn)
            {
                CommandType = CommandType.Text
            };

            _ = cmd.Parameters.AddWithValue("@CodPtoCob", codPtoCob);
            _ = cmd.Parameters.AddWithValue("@Acces", acces);

            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr, LoadOption.Upsert);
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

        public DataTable ListarPlanillasNoDescontadas(string codPtoCob, int acces)
        {
            const string function = "SELECT * FROM fn_ListarPlanillasNoDescontadas(@CodPtoCob,default,default,@Acces)";
            SqlCommand cmd = new SqlCommand(function, conn)
            {
                CommandType = CommandType.Text
            };

            _ = cmd.Parameters.AddWithValue("@CodPtoCob", codPtoCob);
            _ = cmd.Parameters.AddWithValue("@Acces", acces);

            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr, LoadOption.Upsert);
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

        public DataTable ListarPlanillasDescontadasConfirmadas(string codPtoCob, int acces)
        {
            const string function = "SELECT * FROM fn_ListarPlanillasDescontadasConfirmadas(@CodPtoCob,default,default,@Acces)";
            SqlCommand cmd = new SqlCommand(function, conn)
            {
                CommandType = CommandType.Text
            };

            _ = cmd.Parameters.AddWithValue("@CodPtoCob", codPtoCob);
            _ = cmd.Parameters.AddWithValue("@Acces", acces);

            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr, LoadOption.Upsert);
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

        public DataTable ListarPlanillasEjecutado(string codPtoCob, int acces)
        {
            const string function = "SELECT * FROM fn_ListarPlanillasEjecutadas(@CodPtoCob,default,default,@Acces)";
            SqlCommand cmd = new SqlCommand(function, conn)
            {
                CommandType = CommandType.Text
            };

            _ = cmd.Parameters.AddWithValue("@CodPtoCob", codPtoCob);
            _ = cmd.Parameters.AddWithValue("@Acces", acces);

            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr, LoadOption.Upsert);
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

        public DataTable ListarPlanillasChequeDepositado(string codPtoCob)
        {
            const string function = "SELECT * FROM fn_ListarPlanillasChequeDepositado(@CodPtoCob)";
            SqlCommand cmd = new SqlCommand(function, conn)
            {
                CommandType = CommandType.Text
            };

            _ = cmd.Parameters.AddWithValue("@CodPtoCob", codPtoCob);

            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr, LoadOption.Upsert);
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

        public DataTable ListarPlanillasChequeEnviado(string codPtoCob)
        {
            const string function = "SELECT * FROM fn_ListarPlanillasChequeEnviado(@CodPtoCob)";
            SqlCommand cmd = new SqlCommand(function, conn)
            {
                CommandType = CommandType.Text
            };

            _ = cmd.Parameters.AddWithValue("@CodPtoCob", codPtoCob);

            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr, LoadOption.Upsert);
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

        public DataTable ListarPlanillasChequeRecepcionado(string codPtoCob)
        {
            const string function = "SELECT * FROM fn_ListarPlanillasChequeRecepcionado(@CodPtoCob)";
            SqlCommand cmd = new SqlCommand(function, conn)
            {
                CommandType = CommandType.Text
            };

            _ = cmd.Parameters.AddWithValue("@CodPtoCob", codPtoCob);

            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr, LoadOption.Upsert);
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

        public bool RevertirTransferencia(List<planillaCabeceraTo> lstPlanillas)
        {
            const string procedure = "usp_RevertirTransferencia";
            conn.Open();
            SqlTransaction sqlTran = conn.BeginTransaction();
            try
            {
                foreach (planillaCabeceraTo pla in lstPlanillas)
                {
                    SqlCommand cmd = new SqlCommand(procedure, conn, sqlTran)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    _ = cmd.Parameters.AddWithValue("@AÑO", pla.FE_AÑO);
                    _ = cmd.Parameters.AddWithValue("@MES", pla.FE_MES);
                    _ = cmd.Parameters.AddWithValue("@NRO_PLANILLA", pla.NRO_PLANILLA_COB);
                    _ = cmd.Parameters.AddWithValue("@COD_PTO_COB", pla.COD_PTO_COB_CONSOLIDADO);
                    _ = cmd.Parameters.AddWithValue("@TIPO_PLANILLA", pla.TIPO_PLANILLA);
                    _ = cmd.Parameters.AddWithValue("@ACES", 1);

                    if (cmd.ExecuteNonQuery() == 0)
                    {
                        sqlTran.Rollback();
                        return false;
                    }
                }
                sqlTran.Commit();
                return true;
            }
            catch (Exception)
            {
                sqlTran.Rollback();
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public int RevertirTransferencia(string año, string mes)
        {
            const string procedure = "usp_RevertirTransferencia";
            conn.Open();
            SqlTransaction sqlTran = conn.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand(procedure, conn, sqlTran)
                {
                    CommandType = CommandType.StoredProcedure
                };

                _ = cmd.Parameters.AddWithValue("@AÑO", año);
                _ = cmd.Parameters.AddWithValue("@MES", mes);
                _ = cmd.Parameters.AddWithValue("@ACES", 0);
                int result = cmd.ExecuteNonQuery();
                sqlTran.Commit();
                return result;
            }
            catch (Exception)
            {
                sqlTran.Rollback();
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public DataTable ObtenerMesAñoTransferidos()
        {
            const string procedure = "SELECT * FROM fn_ObtenerAñoMesTranferidos()";
            SqlCommand cmd = new SqlCommand(procedure, conn)
            {
                CommandType = CommandType.Text
            };

            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr, LoadOption.OverwriteChanges);
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

        public DataTable ObtenerOtrosDsctos(string codPtoCob)
        {
            const string procedure = "usp_ObtenerOtrosDesctos";
            SqlCommand cmd = new SqlCommand(procedure, conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            _ = cmd.Parameters.AddWithValue("@COD_PTO_COB", codPtoCob);
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

        public bool ActualizarCheque(ChequesPlanillaTo cheque, SqlTransaction sqlTransaction)
        {
            const string procedure = "usp_ActualizarChequesPlanilla";
            try
            {
                SqlCommand cmd = new SqlCommand(procedure, conn, sqlTransaction)
                {
                    CommandType = CommandType.StoredProcedure
                };

                _ = cmd.Parameters.AddWithValue("", 1);

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable ListarPlanilasSiDescontadas()
        {
            const string procedure = "usp_ObtenerPlanillasSiDescontadas";
            SqlCommand cmd = new SqlCommand(procedure, conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr, LoadOption.Upsert);
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

        public int TransferirPlanillasSiDescontadas()
        {
            const string procedure = "usp_TransferirPlanillasSiDescontadas";
            conn.Open();
            SqlTransaction sqlTran = conn.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand(procedure, conn, sqlTran)
                {
                    CommandType = CommandType.StoredProcedure
                };

                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    sqlTran.Commit();
                    return result;
                }
                sqlTran.Rollback();
                return result;
            }
            catch (Exception)
            {
                sqlTran.Rollback();
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        private static bool TransferirPlanillasSiDescontadas(int idSeguimiento, DateTime fechaTrans, SqlTransaction sqlTran, SqlConnection cn)
        {
            const string procedure = "usp_TransferirPlanillasSiDescontadasXIdSeguimiento";
            try
            {
                SqlCommand cmd = new SqlCommand(procedure, cn, sqlTran)
                {
                    CommandType = CommandType.StoredProcedure
                };

                _ = cmd.Parameters.AddWithValue("@ID_SEGUIMIENTO", idSeguimiento);
                _ = cmd.Parameters.AddWithValue("@FECHA_TRANS", fechaTrans);

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable ListarPlanillasChequeConfirmado(string codPtoCob)
        {
            const string function = "SELECT * FROM fn_ListarPlanillasChequeConfirmado(@CodPtoCob)";
            SqlCommand cmd = new SqlCommand(function, conn)
            {
                CommandType = CommandType.Text
            };

            _ = cmd.Parameters.AddWithValue("@CodPtoCob", codPtoCob);

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

        public DataTable ListarPlanillaControl(string feAño, string feMes, int acces)
        {
            const string procedure = "usp_ListarPlanillasControl";
            SqlCommand cmd = new SqlCommand(procedure, conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            _ = cmd.Parameters.AddWithValue("@FE_AÑO", feAño);
            _ = cmd.Parameters.AddWithValue("@FE_MES", feMes);
            _ = cmd.Parameters.AddWithValue("@ACCES", acces);

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

        public DataTable ListarSeguimientoPlanillasControl(string feAño, string feMes)
        {
            const string procedure = "usp_ListarSeguimientoPlanillasControl";
            SqlCommand cmd = new SqlCommand(procedure, conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            _ = cmd.Parameters.AddWithValue("@FE_AÑO", feAño);
            _ = cmd.Parameters.AddWithValue("@FE_MES", feMes);
            _ = cmd.Parameters.AddWithValue("@ACCES", 0);

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

        public DataTable ObtenerDatosEjecutados(string nroPlanilla, string codPtoCob, string codInstitucion, string codCanalDscto, string tipoPlanilla, string feAño, string feMes)
        {
            const string procedure = "SELECT * FROM fn_ObtenerDatosEjecutados(@NRO_PLANILLA,@COD_INSTITUCION,@COD_CANAL_DSCTO,@COD_PTO_COB,@TIPO_PLANILLA,@FE_AÑO,@FE_MES)";
            SqlCommand cmd = new SqlCommand(procedure, conn)
            {
                CommandType = CommandType.Text
            };

            _ = cmd.Parameters.AddWithValue("@NRO_PLANILLA", nroPlanilla);
            _ = cmd.Parameters.AddWithValue("@COD_INSTITUCION", codInstitucion);
            _ = cmd.Parameters.AddWithValue("@COD_CANAL_DSCTO", codCanalDscto);
            _ = cmd.Parameters.AddWithValue("@COD_PTO_COB", codPtoCob);
            _ = cmd.Parameters.AddWithValue("@TIPO_PLANILLA", tipoPlanilla);
            _ = cmd.Parameters.AddWithValue("@FE_AÑO", feAño);
            _ = cmd.Parameters.AddWithValue("@FE_MES", feMes);

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

        public DataTable ObtenerLlamdasXIdSeguimiento(int idSeguimiento)
        {
            const string function = "SELECT * FROM fn_ObtenerLlamdasXIdSeguimiento(@ID_SEGUIMIENTO)";
            SqlCommand cmd = new SqlCommand(function, conn)
            {
                CommandType = CommandType.Text
            };

            _ = cmd.Parameters.AddWithValue("@ID_SEGUIMIENTO", idSeguimiento);

            try
            {
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

        public DataTable ListarLlamadasPendientesPlla()
        {
            const string procedure = "usp_ListarLlamadasPendientesPlla";
            SqlCommand cmd = new SqlCommand(procedure, conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            try
            {
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

        public SeguimientoPlanillaTo ObtenerSeguimientoPlanillaTo(int idSeguimiento)
        {
            try
            {
                const string function = "SELECT * FROM FN_OBTENER_SEGUIMIENTO_PLANILLA_ID_SEGUIMIENTO(@ID_SEGUIMIENTO)";
                SqlCommand cmd = new SqlCommand(function, conn)
                {
                    CommandType = CommandType.Text
                };

                _ = cmd.Parameters.AddWithValue("@ID_SEGUIMIENTO", idSeguimiento);

                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    return new SeguimientoPlanillaTo
                    {
                        ID_SEGUIMIENTO = Convert.ToInt32(dr["ID_SEGUIMIENTO"]),
                        ID_ESTADO = Convert.ToInt32(dr["ID_ESTADO"]),
                        NRO_PLANILLA = dr["NRO_PLANILLA"].ToString(),
                        COD_INSTITUCION = dr["COD_INSTITUCION"].ToString(),
                        TIPO_PLANILLA = dr["TIPO_PLANILLA"].ToString(),
                        FE_AÑO = dr["FE_AÑO"].ToString(),
                        FE_MES = dr["FE_MES"].ToString(),
                        COD_PTO_COB_CONSOLIDADO = dr["COD_PTO_COB_CONSOLIDADO"].ToString(),
                        COD_CANAL_DSCTO = dr["COD_CANAL_DSCTO"].ToString(),
                        COD_SUCURSAL = dr["COD_SUCURSAL"].ToString(),
                        IMPORTE_DESCUENTO = string.IsNullOrEmpty(dr["IMPORTE_DESCUENTO"].ToString()) ? 0 : Convert.ToDecimal(dr["IMPORTE_DESCUENTO"]),
                        IMPORTE_LISTADO = string.IsNullOrEmpty(dr["IMPORTE_LISTADO"].ToString()) ? 0 : Convert.ToDecimal(dr["IMPORTE_LISTADO"]),
                        PORCENTAJE_CASILLERO = string.IsNullOrEmpty(dr["PORCENTAJE_CASILLERO"].ToString()) ? 0 : Convert.ToDecimal(dr["PORCENTAJE_CASILLERO"]),
                        IMPORTE_CASILLERO = string.IsNullOrEmpty(dr["IMPORTE_CASILLERO"].ToString()) ? 0 : Convert.ToDecimal(dr["IMPORTE_CASILLERO"]),
                        IMPORTE_CASILLERO_MAN = string.IsNullOrEmpty(dr["IMPORTE_CASILLERO_MAN"].ToString()) ? 0 : Convert.ToDecimal(dr["IMPORTE_CASILLERO_MAN"]),
                        OTROS_DSCTOS = string.IsNullOrEmpty(dr["OTROS_DSCTOS"].ToString()) ? 0 : Convert.ToDecimal(dr["OTROS_DSCTOS"]),
                        IMPORTE_EJECUTADO = string.IsNullOrEmpty(dr["IMPORTE_EJECUTADO"].ToString()) ? 0 : Convert.ToDecimal(dr["IMPORTE_EJECUTADO"]),
                        IMPORTE_NETO = string.IsNullOrEmpty(dr["IMPORTE_NETO"].ToString()) ? 0 : Convert.ToDecimal(dr["IMPORTE_NETO"]),
                        IMPORTE_RETENIDO = string.IsNullOrEmpty(dr["IMPORTE_RETENIDO"].ToString()) ? 0 : Convert.ToDecimal(dr["IMPORTE_RETENIDO"]),
                        IMPORTE_AJUSTE = string.IsNullOrEmpty(dr["IMPORTE_AJUSTE"].ToString()) ? 0 : Convert.ToDecimal(dr["IMPORTE_AJUSTE"]),
                        IMPORTE_VERIFICADO = string.IsNullOrEmpty(dr["IMPORTE_VERIFICADO"].ToString()) ? 0 : Convert.ToDecimal(dr["IMPORTE_VERIFICADO"]),
                        SALDO_X_COBRAR = string.IsNullOrEmpty(dr["SALDO_X_COBRAR"].ToString()) ? 0 : Convert.ToDecimal(dr["SALDO_X_COBRAR"]),
                        IMPORTE_EXC_INI = string.IsNullOrEmpty(dr["IMPORTE_EXC_INI"].ToString()) ? 0 : Convert.ToDecimal(dr["IMPORTE_EXC_INI"]),
                        IMPORTE_EXC_DOC = string.IsNullOrEmpty(dr["IMPORTE_EXC_DOC"].ToString()) ? 0 : Convert.ToDecimal(dr["IMPORTE_EXC_DOC"]),
                        FEC_RETOR_PLAN = string.IsNullOrEmpty(dr["FEC_RETOR_PLAN"].ToString()) ? (DateTime?)null : Convert.ToDateTime(dr["FEC_RETOR_PLAN"]),
                        FECHA_CIERRE_COBRANZA = string.IsNullOrEmpty(dr["FECHA_CIERRE_COBRANZA"].ToString()) ? (DateTime?)null : Convert.ToDateTime(dr["FECHA_CIERRE_COBRANZA"]),
                        ST_NO_PROCESADO = string.IsNullOrEmpty(dr["ST_NO_PROCESO"].ToString()) ? false : Convert.ToBoolean(dr["ST_NO_PROCESO"]),
                        ST_NO_PROCESADO_OBS = dr["ST_NO_PROCESO_OBS"].ToString(),
                        USUARIO_CREA = dr["USUARIO_CREA"].ToString(),
                        FECHA_CREA = Convert.ToDateTime(dr["FECHA_CREA"]),
                        USUARIO_MODIFICA = dr["USUARIO_MODIFICA"].ToString(),
                        FECHA_MODIFICA = string.IsNullOrEmpty(dr["FECHA_CREA"].ToString()) ? (DateTime?)null : Convert.ToDateTime(dr["FECHA_CREA"]),
                    };
                }
                throw new NullReferenceException();
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

        private DataTable ObtenerPlanillasXGrupo(SeguimientoPlanillaTo se, SqlConnection cn, SqlTransaction tr)
        {
            const string procedure = "usp_ObtenerPlanillasXGrupo";
            SqlCommand cmd = new SqlCommand(procedure, cn, tr)
            {
                CommandType = CommandType.StoredProcedure
            };

            _ = cmd.Parameters.AddWithValue("@NRO_PLANILLA_COB", se.NRO_PLANILLA);
            _ = cmd.Parameters.AddWithValue("@FE_AÑO", se.FE_AÑO);
            _ = cmd.Parameters.AddWithValue("@FE_MES", se.FE_MES);
            _ = cmd.Parameters.AddWithValue("@TIPO_PLANILLA", se.TIPO_PLANILLA);
            _ = cmd.Parameters.AddWithValue("@COD_PTO_COB", se.COD_PTO_COB_CONSOLIDADO);

            try
            {
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
        }

        private DataRow ObtenerPlanillaPuntoEnvio(SeguimientoPlanillaTo se, SqlConnection cn, SqlTransaction tr)
        {
            const string select = "SELECT * FROM fn_ObtenerPlanillaGrupoEnvio(@NRO_PLANILLA_COB, @FE_AÑO, @FE_MES, @TIPO_PLANILLA, @COD_PTO_COB) WHERE CAB_GRUPO = 1";
            SqlCommand cmd = new SqlCommand(select, cn, tr)
            {
                CommandType = CommandType.Text
            };

            _ = cmd.Parameters.AddWithValue("@NRO_PLANILLA_COB", se.NRO_PLANILLA);
            _ = cmd.Parameters.AddWithValue("@FE_AÑO", se.FE_AÑO);
            _ = cmd.Parameters.AddWithValue("@FE_MES", se.FE_MES);
            _ = cmd.Parameters.AddWithValue("@TIPO_PLANILLA", se.TIPO_PLANILLA);
            _ = cmd.Parameters.AddWithValue("@COD_PTO_COB", se.COD_PTO_COB_CONSOLIDADO);

            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr, LoadOption.OverwriteChanges);
                dr.Close();
                return dt?.Rows[0];
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable ObtenerPlanillasXGrupo(SeguimientoPlanillaTo se)
        {
            const string procedure = "usp_ObtenerPlanillasXGrupo";
            SqlCommand cmd = new SqlCommand(procedure, conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            _ = cmd.Parameters.AddWithValue("@NRO_PLANILLA_COB", se.NRO_PLANILLA);
            _ = cmd.Parameters.AddWithValue("@FE_AÑO", se.FE_AÑO);
            _ = cmd.Parameters.AddWithValue("@FE_MES", se.FE_MES);
            _ = cmd.Parameters.AddWithValue("@TIPO_PLANILLA", se.TIPO_PLANILLA);
            _ = cmd.Parameters.AddWithValue("@COD_PTO_COB", se.COD_PTO_COB_CONSOLIDADO);

            try
            {
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

        public DataTable ObtenerPlanillasXGrupo2(SeguimientoPlanillaTo se)
        {
            const string procedure = "usp_ObtenerPlanillasXGrupo2";
            SqlCommand cmd = new SqlCommand(procedure, conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            _ = cmd.Parameters.AddWithValue("@NRO_PLANILLA_COB", se.NRO_PLANILLA);
            _ = cmd.Parameters.AddWithValue("@FE_AÑO", se.FE_AÑO);
            _ = cmd.Parameters.AddWithValue("@FE_MES", se.FE_MES);
            _ = cmd.Parameters.AddWithValue("@TIPO_PLANILLA", se.TIPO_PLANILLA);
            _ = cmd.Parameters.AddWithValue("@COD_PTO_COB", se.COD_PTO_COB_CONSOLIDADO);

            try
            {
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

        private bool InsertarImportesSeguiPlla(SeguimientoPlanillaTo se, List<SeguimientoPlanillaTo> lstImportePlanilla, bool showChecked, SqlTransaction sqlTrans, SqlConnection cn)
        {
            const string procedure = "usp_ActualizarImporteSeguiPlla";
            try
            {
                if (lstImportePlanilla.Count > 0 && (se.ID_ESTADO == DESCONTADA_CERRADA || se.ID_ESTADO == DESCONTADO_CONFIRMADO || se.ID_ESTADO == NO_EJECUTADO))
                {
                    foreach (SeguimientoPlanillaTo item in lstImportePlanilla)
                    {
                        SqlCommand cmd = new SqlCommand(procedure, cn, sqlTrans)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        _ = cmd.Parameters.AddWithValue("@NRO_PLANILLA", item.NRO_PLANILLA);
                        _ = cmd.Parameters.AddWithValue("@FE_AÑO", item.FE_AÑO);
                        _ = cmd.Parameters.AddWithValue("@FE_MES", item.FE_MES);
                        _ = cmd.Parameters.AddWithValue("@COD_PTO_COB_CONSOLIDADO", item.COD_PTO_COB_CONSOLIDADO);
                        _ = cmd.Parameters.AddWithValue("@TIPO_PLANILLA", item.TIPO_PLANILLA);
                        _ = cmd.Parameters.AddWithValue("@COD_CANAL_DSCTO", item.COD_CANAL_DSCTO);
                        _ = cmd.Parameters.AddWithValue("@COD_INSTITUCION", item.COD_INSTITUCION);
                        _ = cmd.Parameters.AddWithValue("@ID_ESTADO", se.ID_ESTADO);
                        _ = cmd.Parameters.AddWithValue("@IMPORTE_DESCUENTO", item.IMPORTE_DESCUENTO);
                        _ = cmd.Parameters.AddWithValue("@IMPORTE_LISTADO", item.IMPORTE_LISTADO);
                        _ = cmd.Parameters.AddWithValue("@IMPORTE_EJECUTADO", item.IMPORTE_EJECUTADO);
                        _ = cmd.Parameters.AddWithValue("@IMPORTE_NETO", item.IMPORTE_NETO);
                        _ = cmd.Parameters.AddWithValue("@IMPORTE_CASILLERO", item.IMPORTE_CASILLERO);
                        _ = cmd.Parameters.AddWithValue("@IMPORTE_CASILLERO_MAN", item.IMPORTE_CASILLERO_MAN);
                        _ = cmd.Parameters.AddWithValue("@PORCENTAJE_CASILLERO", item.PORCENTAJE_CASILLERO);
                        _ = cmd.Parameters.AddWithValue("@FEC_RETOR_PLAN", item.FEC_RETOR_PLAN);
                        _ = cmd.Parameters.AddWithValue("@FECHA_CHECK", showChecked);
                        _ = cmd.Parameters.AddWithValue("@ST_LISTADO", item.ST_LISTADO);

                        if (item.CAB_GRUPO)
                            _ = cmd.Parameters.AddWithValue("@IMPORTE_NETO_GRUPO", item.IMPORTE_NETO_GRUPO);
                        else if (se.ID_SEGUIMIENTO == item.ID_SEGUIMIENTO)
                            _ = cmd.Parameters.AddWithValue("@IMPORTE_NETO_GRUPO", item.IMPORTE_NETO_GRUPO);

                        if (cmd.ExecuteNonQuery() == 0)
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

        private bool InsertarNoProcesoPlla(SeguimientoPlanillaTo se, List<SeguimientoPlanillaTo> lstSeguimiento, bool chkShow, SqlTransaction sqlTrans, SqlConnection cn)
        {
            const string procedure = "dsp_InsertarNoProceso";
            try
            {
                //> SeguimientoPlanillaTo se2 = ObtenerSeguimientoPlanillaTo(se.ID_SEGUIMIENTO, sqlTrans, cn);
                //> DataTable dt = ObtenerPlanillasXGrupo(se2, cn, sqlTrans);
                //if (dt is null)
                //    return false;
                int idEstado = 0;
                if (se.ID_ESTADO == DESCONTADA_CERRADA)
                {
                    foreach (SeguimientoPlanillaTo item in lstSeguimiento)
                    {
                        SqlCommand cmd = new SqlCommand(procedure, cn, sqlTrans)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        if (idEstado != DESCONTADO_CONFIRMADO)
                        {
                            if (item.ST_NO_PROCESADO && chkShow) idEstado = NO_DESCONTADO;
                            else if (!item.ST_NO_PROCESADO && chkShow) idEstado = DESCONTADO_CONFIRMADO;
                            else idEstado = DESCONTADA_CERRADA;
                        }
                        if (item.ST_NO_PROCESADO)
                        {
                            _ = cmd.Parameters.AddWithValue("@NRO_PLANILLA", item.NRO_PLANILLA);
                            _ = cmd.Parameters.AddWithValue("@FE_AÑO", item.FE_AÑO);
                            _ = cmd.Parameters.AddWithValue("@FE_MES", item.FE_MES);
                            _ = cmd.Parameters.AddWithValue("@COD_PTO_COB_CONSOLIDADO", item.COD_PTO_COB_CONSOLIDADO);
                            _ = cmd.Parameters.AddWithValue("@TIPO_PLANILLA", item.TIPO_PLANILLA);
                            _ = cmd.Parameters.AddWithValue("@COD_CANAL_DSCTO", item.COD_CANAL_DSCTO);
                            _ = cmd.Parameters.AddWithValue("@COD_INSTITUCION", item.COD_INSTITUCION);
                            _ = cmd.Parameters.AddWithValue("@ID_ESTADO", item.ST_NO_PROCESADO && chkShow ? NO_DESCONTADO : item.ST_LISTADO && chkShow ? DESCONTADO_CONFIRMADO : DESCONTADA_CERRADA);
                            _ = cmd.Parameters.AddWithValue("@ST_NO_PROCESO", item.ST_NO_PROCESADO);
                            _ = cmd.Parameters.AddWithValue("@ST_NO_PROCESO_OBS", item.ST_NO_PROCESADO && chkShow ? item.ST_NO_PROCESADO_OBS : string.Empty);

                            if (cmd.ExecuteNonQuery() == 0)
                                return false;
                        }
                    }
                    se.ID_ESTADO = idEstado;

                    return true;//> InsertarHistorialSeguimiento(se, sqlTrans, cn);
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private SeguimientoPlanillaTo ObtenerSeguimientoPlanillaTo(int idSeguimiento, SqlTransaction sqlTransaction, SqlConnection cn)
        {
            SqlDataReader dr = null;
            try
            {
                const string function = "SELECT * FROM FN_OBTENER_SEGUIMIENTO_PLANILLA_ID_SEGUIMIENTO(@ID_SEGUIMIENTO)";
                SqlCommand cmd = new SqlCommand(function, cn, sqlTransaction)
                {
                    CommandType = CommandType.Text
                };

                _ = cmd.Parameters.AddWithValue("@ID_SEGUIMIENTO", idSeguimiento);

                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    return new SeguimientoPlanillaTo
                    {
                        ID_SEGUIMIENTO = Convert.ToInt32(dr["ID_SEGUIMIENTO"]),
                        ID_ESTADO = Convert.ToInt32(dr["ID_ESTADO"]),
                        NRO_PLANILLA = dr["NRO_PLANILLA"].ToString(),
                        COD_INSTITUCION = dr["COD_INSTITUCION"].ToString(),
                        TIPO_PLANILLA = dr["TIPO_PLANILLA"].ToString(),
                        FE_AÑO = dr["FE_AÑO"].ToString(),
                        FE_MES = dr["FE_MES"].ToString(),
                        COD_PTO_COB_CONSOLIDADO = dr["COD_PTO_COB_CONSOLIDADO"].ToString(),
                        COD_CANAL_DSCTO = dr["COD_CANAL_DSCTO"].ToString(),
                        COD_SUCURSAL = dr["COD_SUCURSAL"].ToString(),
                        IMPORTE_DESCUENTO = string.IsNullOrEmpty(dr["IMPORTE_DESCUENTO"].ToString()) ? 0 : Convert.ToDecimal(dr["IMPORTE_DESCUENTO"]),
                        IMPORTE_LISTADO = string.IsNullOrEmpty(dr["IMPORTE_LISTADO"].ToString()) ? 0 : Convert.ToDecimal(dr["IMPORTE_LISTADO"]),
                        PORCENTAJE_CASILLERO = string.IsNullOrEmpty(dr["PORCENTAJE_CASILLERO"].ToString()) ? 0 : Convert.ToDecimal(dr["PORCENTAJE_CASILLERO"]),
                        IMPORTE_CASILLERO = string.IsNullOrEmpty(dr["IMPORTE_CASILLERO"].ToString()) ? 0 : Convert.ToDecimal(dr["IMPORTE_CASILLERO"]),
                        IMPORTE_CASILLERO_MAN = string.IsNullOrEmpty(dr["IMPORTE_CASILLERO_MAN"].ToString()) ? 0 : Convert.ToDecimal(dr["IMPORTE_CASILLERO_MAN"]),
                        OTROS_DSCTOS = string.IsNullOrEmpty(dr["OTROS_DSCTOS"].ToString()) ? 0 : Convert.ToDecimal(dr["OTROS_DSCTOS"]),
                        IMPORTE_EJECUTADO = string.IsNullOrEmpty(dr["IMPORTE_EJECUTADO"].ToString()) ? 0 : Convert.ToDecimal(dr["IMPORTE_EJECUTADO"]),
                        IMPORTE_NETO = string.IsNullOrEmpty(dr["IMPORTE_NETO"].ToString()) ? 0 : Convert.ToDecimal(dr["IMPORTE_NETO"]),
                        IMPORTE_RETENIDO = string.IsNullOrEmpty(dr["IMPORTE_RETENIDO"].ToString()) ? 0 : Convert.ToDecimal(dr["IMPORTE_RETENIDO"]),
                        IMPORTE_AJUSTE = string.IsNullOrEmpty(dr["IMPORTE_AJUSTE"].ToString()) ? 0 : Convert.ToDecimal(dr["IMPORTE_AJUSTE"]),
                        IMPORTE_VERIFICADO = string.IsNullOrEmpty(dr["IMPORTE_VERIFICADO"].ToString()) ? 0 : Convert.ToDecimal(dr["IMPORTE_VERIFICADO"]),
                        SALDO_X_COBRAR = string.IsNullOrEmpty(dr["SALDO_X_COBRAR"].ToString()) ? 0 : Convert.ToDecimal(dr["SALDO_X_COBRAR"]),
                        IMPORTE_EXC_INI = string.IsNullOrEmpty(dr["IMPORTE_EXC_INI"].ToString()) ? 0 : Convert.ToDecimal(dr["IMPORTE_EXC_INI"]),
                        IMPORTE_EXC_DOC = string.IsNullOrEmpty(dr["IMPORTE_EXC_DOC"].ToString()) ? 0 : Convert.ToDecimal(dr["IMPORTE_EXC_DOC"]),
                        FEC_RETOR_PLAN = string.IsNullOrEmpty(dr["FEC_RETOR_PLAN"].ToString()) ? (DateTime?)null : Convert.ToDateTime(dr["FEC_RETOR_PLAN"]),
                        FECHA_CIERRE_COBRANZA = string.IsNullOrEmpty(dr["FECHA_CIERRE_COBRANZA"].ToString()) ? (DateTime?)null : Convert.ToDateTime(dr["FECHA_CIERRE_COBRANZA"]),
                        USUARIO_CREA = dr["USUARIO_CREA"].ToString(),
                        FECHA_CREA = Convert.ToDateTime(dr["FECHA_CREA"]),
                        USUARIO_MODIFICA = dr["USUARIO_MODIFICA"].ToString(),
                        FECHA_MODIFICA = string.IsNullOrEmpty(dr["FECHA_CREA"].ToString()) ? (DateTime?)null : Convert.ToDateTime(dr["FECHA_CREA"]),
                    };
                }
                throw new NullReferenceException();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (dr != null)
                    dr.Close();
            }
        }

        public DataTable ResumenSeguimientoPlanilla(string fe_año, string fe_mes, string codPais)
        {
            const string procedure = "usp_ResumenSeguimientoPlanillas";
            SqlCommand cmd = new SqlCommand(procedure, conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            _ = cmd.Parameters.AddWithValue("@FE_AÑO", fe_año);
            _ = cmd.Parameters.AddWithValue("@FE_MES", fe_mes);
            _ = cmd.Parameters.AddWithValue("@COD_PAIS", codPais);

            try
            {
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

        public DataTable ObtenerUltimaLlamada(int idSeguimiento, int idEstado)
        {
            const string select = "SELECT TOP(1) * FROM LLAMADAS_SEGUIMIENTO WHERE ID_SEGUIMIENTO = @ID_SEGUIMIENTO AND ID_ESTADO = @ID_ESTADO ORDER BY FECHA_CREACION DESC";
            SqlCommand cmd = new SqlCommand(select, conn)
            {
                CommandType = CommandType.Text,
            };

            _ = cmd.Parameters.AddWithValue("@ID_SEGUIMIENTO", idSeguimiento);
            _ = cmd.Parameters.AddWithValue("@ID_ESTADO", idEstado);

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

        public DataTable RptResumenSeguimientoPlanilla(string codPrograma, string fe_año, string fe_mes, string codPtoCob)
        {
            const string procedure = "usp_RptResumenSeguimientoPlanilla2";
            SqlCommand cmd = new SqlCommand(procedure, conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            _ = cmd.Parameters.AddWithValue("@COD_PROGRAMA", codPrograma);
            _ = cmd.Parameters.AddWithValue("@FE_AÑO", fe_año);
            _ = cmd.Parameters.AddWithValue("@FE_MES", fe_mes);
            _ = cmd.Parameters.AddWithValue("@COD_PTO_COB", codPtoCob);

            try
            {
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

        public List<personaMaestroTo> ObtenerMaestroPersonaCategoriaPllas()
        {
            const string procedure = "	SELECT a.* " +
                "FROM MAESTRO_PERSONAS a " +
                "INNER JOIN PERSONA_CLASE c ON(c.COD_PER = a.COD_PER) " +
                "WHERE c.COD_CAT = 'D'";
            SqlCommand cmd = new SqlCommand(procedure, conn)
            {
                CommandType = CommandType.Text
            };

            try
            {
                List<personaMaestroTo> lista = new List<personaMaestroTo>();
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new personaMaestroTo
                        {
                            COD_PER = dr["COD_PER"].ToString(),
                            NOMBRE = dr["DESC_PER"].ToString(),
                        });
                    }
                    return lista;
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
        /// Obtiene puntos de cobranza que tienen planillas ya ejecutadas [I_PLANILLA.APROBAR_RECEPCIONADO = 1], 
        /// para indicar que ya se puede cerrar la etapa de ejecución las planillas de este punto de cobranza
        /// </summary>
        /// <param name="codPais"></param>
        /// <returns>DataTable</returns>
        public DataTable ObtenerPtoCobranzaConPlanillasEjecutadas(string codPais)
        {
            const string procedure = "dsp_ObtenerPtoCobranzaConPlanillasEjecutadas";
            SqlCommand cmd = new SqlCommand(procedure, conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            _ = cmd.Parameters.AddWithValue("@COD_PAIS", codPais);

            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr, LoadOption.OverwriteChanges);
                dr.Close();
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
        /// Obtiene una lista de planillas por grupo para determinar que grupo ya estan ejecutadas [I_PLANILLA.APROBAR_RECEPCIONADO = 1]
        /// </summary>
        /// <param name="codPais"></param>
        /// <param name="codPtoCob"></param>
        /// <returns>DataTable</returns>
        public DataTable VerificarPlanillasAprobadoRecepcionado(string codPais, string codPtoCob)
        {
            const string procedure = "dsp_VerificarPlanillasAprobadoRecepcionado";
            SqlCommand cmd = new SqlCommand(procedure, conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            _ = cmd.Parameters.AddWithValue("@COD_PAIS", codPais);
            _ = cmd.Parameters.AddWithValue("@COD_PTO_COB", codPtoCob);

            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr, LoadOption.OverwriteChanges);
                dr.Close();
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
        /// Retorna true si la planilla tiene ya cobros registrados (cheques, depósitos, transferencias, etc.) de lo contrario false
        /// </summary>
        /// <param name="idSeguimiento"></param>
        /// <returns>retorna true si tiene cobros registrados, de lo contrario false</returns>
        public bool VerificarSiPlanillaTienePagosRegistrados(int idSeguimiento)
        {
            try
            {
                const string sentencia = "SELECT * FROM DETALLE_CHEQUE_SEGUI WHERE ID_SEGUIMIENTO = @ID_SEGUIMIENTO";
                SqlCommand cmd = new SqlCommand(sentencia, conn)
                {
                    CommandType = CommandType.Text
                };

                _ = cmd.Parameters.Add("@ID_SEGUIMIENTO", SqlDbType.Int).Value = idSeguimiento;

                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                return dr.Read();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Retorna true si esta reistrado, de lo contratio false
        /// Verificamos si la planilla tiene Cheques/Depósitos/Transferencias registrdos en tesoreria. 
        /// </summary>
        /// <param name="idSeguimiento"></param>
        /// <returns></returns>
        public bool VerificarPlanillaTienePagosRegistradosTesoreria(int idSeguimiento)
        {
            try
            {
                const string sentence = "SELECT '' FROM MOVIMIENTOS_CHEQUE WHERE ID_SEGUIMIENTO = @ID_SEGUIMIENTO";
                using (SqlCommand cmd = new SqlCommand(sentence, conn))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add("@ID_SEGUIMIENTO", SqlDbType.Int).Value = idSeguimiento;
                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        return dr.Read();
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
    }
}
