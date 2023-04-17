using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ChequeDAL
    {
        private readonly SqlConnection conn;

        private readonly SeguimientoPlanillasDAL DALSeguimiento = new SeguimientoPlanillasDAL();
        private readonly serieDocumentosDAL DALSerieDocumento = new serieDocumentosDAL();
        private readonly tipoDocInvDAL DALTipoDoc = new tipoDocInvDAL();
        private const string REGISTRO_GRABADO = "*";
        private const string REGISTRO_NUEVO = "-";

        public ChequeDAL()
        {
            conn = new SqlConnection(conexion.con);
        }


        public DataTable ObtenerEnvioChequeXIdSeguimiento(int idSeguimiento, int idEnvio)
        {
            const string function = "SELECT * FROM fn_ObtenerEnvioChequeXIdSeguimiento(@ID_SEGUIMIENTO,@ID_ENVIO)";
            SqlCommand cmd = new SqlCommand(function, conn)
            {
                CommandType = CommandType.Text
            };

            _ = cmd.Parameters.AddWithValue("@ID_SEGUIMIENTO", idSeguimiento);
            _ = cmd.Parameters.AddWithValue("@ID_ENVIO", idEnvio);

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

        public DataTable ObtenerRecepcionChequeXIdSeguimiento(int idSeguimiento, int idEnvio)
        {
            const string function = "SELECT * FROM fn_ObtenerRecepcionChequeXIdSeguimiento(@ID_SEGUIMIENTO,@ID_ENVIO)";
            SqlCommand cmd = new SqlCommand(function, conn)
            {
                CommandType = CommandType.Text
            };

            _ = cmd.Parameters.AddWithValue("@ID_SEGUIMIENTO", idSeguimiento);
            _ = cmd.Parameters.AddWithValue("@ID_ENVIO", idEnvio);

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

        /// <summary>
        /// Obtiene el depósito de una planilla por ID_SEGUIMIENTO y ID_ENVIO(Id del depósito)
        /// </summary>
        /// <param name="idSeguimiento"></param>
        /// <param name="idEnvio"></param>
        /// <returns></returns>
        public DataTable ObtenerDespositoChequeXIdSeguimiento(int idSeguimiento, int idEnvio)
        {
            const string function = "SELECT * FROM fn_ObtenerDepositoChequeXIdSeguimiento(@ID_SEGUIMIENTO,@ID_ENVIO)";
            SqlCommand cmd = new SqlCommand(function, conn)
            {
                CommandType = CommandType.Text
            };

            _ = cmd.Parameters.AddWithValue("@ID_SEGUIMIENTO", idSeguimiento);
            _ = cmd.Parameters.AddWithValue("@ID_ENVIO", idEnvio);

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

        public DataTable ObtenerTransChequeXIdSeguimiento(int idSeguimiento, int idTransferencia)
        {
            const string function = "SELECT * FROM fn_ObtenerTransferenciaXIdSeguimiento(@ID_SEGUIMIENTO,@ID_TRANSFERENCIA)";
            SqlCommand cmd = new SqlCommand(function, conn)
            {
                CommandType = CommandType.Text
            };

            _ = cmd.Parameters.AddWithValue("@ID_SEGUIMIENTO", idSeguimiento);
            _ = cmd.Parameters.AddWithValue("@ID_TRANSFERENCIA", idTransferencia);

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

        public DataTable ListarPlanillasPendientesCheque(string codPtoCob)
        {
            const string function = "usp_ListarPlanillaXPtoCob_SeguiCheque";
            SqlCommand cmd = new SqlCommand(function, conn)
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

        public DataTable ListarPlanillasPendientesChequeCerrados(string codPtoCob)
        {
            const string function = "usp_ListarPlanillaXPtoCob_SeguiChequeCerrados";
            SqlCommand cmd = new SqlCommand(function, conn)
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

        public bool RegistrarChequePlanilla(ChequesPlanillaTo cheque, Tipo_Movimiento_Cheque tipo)
        {
            conn.Open();
            SqlTransaction sqlTrans = conn.BeginTransaction();
            try
            {
                switch (tipo)
                {
                    case Tipo_Movimiento_Cheque.Envio:
                        if (InsertarEnvioCheque(cheque, sqlTrans, conn))
                        {
                            sqlTrans.Commit();
                            return true;
                        }
                        break;
                    case Tipo_Movimiento_Cheque.Recepcion:
                        //> Actualizo envio
                        if (InsertarRecepcionCheque(cheque, sqlTrans, conn))
                        {
                            sqlTrans.Commit();
                            return true;
                        }
                        break;
                    case Tipo_Movimiento_Cheque.Deposito:
                        //> Actualizo envio
                        //> Actualizo recepción
                        if (InsertarDepositoCheque(cheque, sqlTrans, conn))
                        {
                            sqlTrans.Commit();
                            return true;
                        }
                        break;
                    case Tipo_Movimiento_Cheque.Transferencia:
                        if (InsertarTransferenciaCheque(cheque, sqlTrans, conn))
                        {
                            sqlTrans.Commit();
                            return true;
                        }
                        break;
                }
                sqlTrans.Rollback();
                return false;
            }
            catch (Exception)
            {
                sqlTrans.Rollback();
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        private bool InsertarEnvioCheque(ChequesPlanillaTo cheque, SqlTransaction sqlTran, SqlConnection cn)
        {
            const string procedure = "usp_InsertarEnvioCheque";
            SqlCommand cmd = new SqlCommand(procedure, cn, sqlTran)
            {
                CommandType = CommandType.StoredProcedure
            };

            SqlParameter parameter = new SqlParameter("@ID_ENVIO", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };

            _ = cmd.Parameters.Add(parameter);
            _ = cmd.Parameters.AddWithValue("@FECHA_ENVIO", cheque.EnvioChequeTo.FECHA_ENVIO);
            _ = cmd.Parameters.AddWithValue("@EMPRESA", cheque.EnvioChequeTo.EMPRESA);
            _ = cmd.Parameters.AddWithValue("@ID_DOCUMENTO", cheque.EnvioChequeTo.ID_DOCUMENTO);
            _ = cmd.Parameters.AddWithValue("@NRO_DOCUMENTO", cheque.EnvioChequeTo.NRO_DOCUMENTO);
            _ = cmd.Parameters.AddWithValue("@REPRESENTANTE", cheque.EnvioChequeTo.REPRESENTANTE);
            _ = cmd.Parameters.AddWithValue("@RESPONSABLE", cheque.EnvioChequeTo.RESPONSABLE);
            _ = cmd.Parameters.AddWithValue("@USUARIO_CREA", cheque.USUARIO_CREA);

            try
            {
                if (cmd.ExecuteNonQuery() > 0)
                {
                    cheque.EnvioChequeTo.ID_ENVIO = Convert.ToInt32(parameter.Value);
                    return InsertarDetalleChequeSegui(cheque, sqlTran, cn);
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool InsertarRecepcionCheque(ChequesPlanillaTo cheque, SqlTransaction sqlTran, SqlConnection cn)
        {
            const string procedure = "usp_InsertarRecepcionCheque";
            SqlCommand cmd = new SqlCommand(procedure, cn, sqlTran)
            {
                CommandType = CommandType.StoredProcedure
            };

            SqlParameter parameter = new SqlParameter("@ID_RECEPCION", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            _ = cmd.Parameters.Add(parameter);
            _ = cmd.Parameters.AddWithValue("@ID_ENVIO", cheque.EnvioChequeTo.ID_ENVIO);
            _ = cmd.Parameters.AddWithValue("@FECHA_RECEPCION", cheque.RecepcionChequeTo.FECHA_RECEPCION);
            _ = cmd.Parameters.AddWithValue("@BANCO_ORIGEN", cheque.RecepcionChequeTo.BANCO_ORIGEN);
            _ = cmd.Parameters.AddWithValue("@NRO_CHEQUE", cheque.RecepcionChequeTo.NRO_CHEQUE);
            _ = cmd.Parameters.AddWithValue("@ID_MONEDA", cheque.RecepcionChequeTo.ID_MONEDA);
            _ = cmd.Parameters.AddWithValue("@IMPORTE", cheque.RecepcionChequeTo.IMPORTE);
            _ = cmd.Parameters.AddWithValue("@REPRESENTANTE", cheque.RecepcionChequeTo.REPRESENTANTE);
            _ = cmd.Parameters.AddWithValue("@RESPONSABLE", cheque.RecepcionChequeTo.RESPONSABLE);
            _ = cmd.Parameters.AddWithValue("@USUARIO_CREA", cheque.USUARIO_CREA);

            try
            {
                if (cmd.ExecuteNonQuery() > 0)
                {
                    cheque.RecepcionChequeTo.ID_RECEPCION = Convert.ToInt32(parameter.Value);
                    return InsertarDetalleChequeSegui(cheque, sqlTran, cn);
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public decimal ObtenerTotalAplicado(int idSeguimiento)
        {
            try
            {
                string query = string.Format("SELECT ISNULL(SUM(IMPORTE_APLICADO),0) FROM SALDO_APLICA_PLANILLA WHERE ID_SEGUIMIENTO_APL = {0}", idSeguimiento);
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.CommandType = CommandType.Text;
                DataTable dt = new DataTable();
                da.Fill(dt);
                return Convert.ToDecimal(dt.Rows[0][0]);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool InsertarDepositoCheque(ChequesPlanillaTo cheque, SqlTransaction sqlTran, SqlConnection cn)
        {
            const string procedure = "usp_InsertarDespositoCheque";
            SqlCommand cmd = new SqlCommand(procedure, cn, sqlTran)
            {
                CommandType = CommandType.StoredProcedure
            };

            SqlParameter parameter = new SqlParameter("@ID_DEPOSITO", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            _ = cmd.Parameters.Add(parameter);
            _ = cmd.Parameters.AddWithValue("@ID_ENVIO", cheque.EnvioChequeTo.ID_ENVIO);
            _ = cmd.Parameters.AddWithValue("@COD_BANCO", cheque.DepositoChequeTo.COD_BANCO);
            _ = cmd.Parameters.AddWithValue("@NRO_CHEQUE", cheque.DepositoChequeTo.NRO_CHEQUE);
            _ = cmd.Parameters.AddWithValue("@NRO_OPERACION", cheque.DepositoChequeTo.NRO_OPERACION);
            _ = cmd.Parameters.AddWithValue("@FECHA", cheque.DepositoChequeTo.FECHA_DEPOSITO);
            _ = cmd.Parameters.AddWithValue("@ID_MONEDA", cheque.DepositoChequeTo.ID_MONEDA);
            _ = cmd.Parameters.AddWithValue("@IMPORTE", cheque.DepositoChequeTo.IMPORTE);
            _ = cmd.Parameters.AddWithValue("@REPRESENTANTE", cheque.DepositoChequeTo.REPRESENTANTE);
            _ = cmd.Parameters.AddWithValue("@RESPONSABLE", cheque.DepositoChequeTo.RESPONSABLE);
            _ = cmd.Parameters.AddWithValue("@OBSERVACION", cheque.DepositoChequeTo.OBSERVACION);
            _ = cmd.Parameters.AddWithValue("@FL_GEN_APL", cheque.DepositoChequeTo.FL_GEN_APL);
            _ = cmd.Parameters.AddWithValue("@USUARIO_CREA", cheque.USUARIO_CREA);

            try
            {
                if (cmd.ExecuteNonQuery() > 0)
                {
                    cheque.DepositoChequeTo.ID_DEPOSITO = Convert.ToInt32(parameter.Value);
                    return InsertarDetalleChequeSegui(cheque, sqlTran, cn);
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool InsertarDevolucionExcesoEntCab(DevolucionExcesoEntidad dev, DataTable dtDevolReg, SqlTransaction sqlTran, SqlConnection cn)
        {
            const string procedure = "usp_InsertarDevolucionExcesoEntidad_Cab";
            SqlCommand cmd = new SqlCommand(procedure, cn, sqlTran)
            {
                CommandType = CommandType.StoredProcedure
            };
            
            SqlParameter parameter = new SqlParameter("@ID_DEVOLUCION_EXC", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            _ = cmd.Parameters.Add(parameter);
            _ = cmd.Parameters.AddWithValue("@ID_SEGUIMIENTO", dev.ID_SEGUIMIENTO);
            _ = cmd.Parameters.AddWithValue("@ID_PAGO", dev.ID_PAGO);
            _ = cmd.Parameters.AddWithValue("@TIPO_PAGO", dev.TIPO_PAGO);
            _ = cmd.Parameters.AddWithValue("@FE_AÑO_SIS", dev.FE_AÑO_SIS);
            _ = cmd.Parameters.AddWithValue("@FE_MES_SIS", dev.FE_MES_SIS);
            _ = cmd.Parameters.AddWithValue("@IMPORTE_DEVOLVER_ENTIDAD", dev.IMPORTE_DEVOLVER_ENTIDAD);
            _ = cmd.Parameters.AddWithValue("@OBSERVACION", dev.OBSERVACION);
            _ = cmd.Parameters.AddWithValue("@ID_ESTADO", dev.ID_ESTADO);
            _ = cmd.Parameters.AddWithValue("@USUARIO_CREA", dev.USUARIO_CREA);
            _ = cmd.Parameters.AddWithValue("@USUARIO_MODIFICA", dev.USUARIO_MODIFICA);
  
   
                //DevolucionExcesoEntidad
            try
            {
                if (cmd.ExecuteNonQuery() > 0)
                {
                    dev.ID_DEVOLUCION_EXC = Convert.ToInt32(parameter.Value);
                    //return true;
                    return InsertarDevolucionDetalle(dtDevolReg, dev.ID_DEVOLUCION_EXC, sqlTran, cn);   //InsertarDetalleChequeSegui(cheque, sqlTran, cn);
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool InsertarDevolucionDetalle(DataTable dt,int id_devolucion_exc, SqlTransaction tr, SqlConnection cn)
        {
            const string procedure = "usp_InsertarDetalle_Devolucion";
            try
            {
                int fila = 1;
                if (dt == null)
                    return true;
                foreach (DataRow row in dt.Rows)
                {

                    using (SqlCommand cmd = new SqlCommand(procedure, cn, tr))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        _ = cmd.Parameters.AddWithValue("@IDTIPOENVIO", Convert.ToInt32(row["IDTIPOENVIO"]));
                        _ = cmd.Parameters.AddWithValue("@IMPORTE_APLICADO", Convert.ToDecimal(row["IMPORTE_APLICADO"]));
                        _ = cmd.Parameters.AddWithValue("@ID_SEGUIMIENTO_SEL", Convert.ToInt32(row["ID_SEGUIMIENTO_SEL"]));
                        _ = cmd.Parameters.AddWithValue("@ID_SEGUIMIENTO_APL", Convert.ToInt32(row["ID_SEGUIMIENTO_APL"]));
                        _ = cmd.Parameters.AddWithValue("@ID_ENVIO_SEL", Convert.ToInt32(row["ID_ENVIO_SEL"]));
                        _ = cmd.Parameters.AddWithValue("@ID_ENVIO_APL", Convert.ToInt32(row["ID_ENVIO_APL"]));
                        _ = cmd.Parameters.AddWithValue("@IMPORTE_VERIFICADO", Convert.ToDecimal(row["IMPORTE_VERIFICADO"]));
                        _ = cmd.Parameters.AddWithValue("@SUMA_PAGO_PLL", Convert.ToDecimal(row["SUMA_PAGO_PLL"]));

                        if (fila == 1)
                        {
                            _ = cmd.Parameters.AddWithValue("@RECALCULA_SEG_PLL", 1);
                            fila++;
                        }
                        else
                        {

                            _ = cmd.Parameters.AddWithValue("@RECALCULA_SEG_PLL", 0);
                        }
                        

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



        private bool InsertarTransferenciaCheque(ChequesPlanillaTo cheque, SqlTransaction sqlTran, SqlConnection cn)
        {
            const string procedure = "usp_InsertarTransferenciaSegui";
            SqlCommand cmd = new SqlCommand(procedure, cn, sqlTran)
            {
                CommandType = CommandType.StoredProcedure
            };


            SqlParameter parameter = new SqlParameter("@ID_TRANSFERENCIA", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };

            _ = cmd.Parameters.Add(parameter);
            _ = cmd.Parameters.AddWithValue("@BANCO_ORIGEN", cheque.TransferenciaSeguiTo.BANCO_ORIGEN);
            _ = cmd.Parameters.AddWithValue("@NRO_CUENTA_ORIGEN", cheque.TransferenciaSeguiTo.NRO_CTA_ORIGEN);
            _ = cmd.Parameters.AddWithValue("@COD_BANCO_DEST", cheque.TransferenciaSeguiTo.COD_BANCO_DEST);
            _ = cmd.Parameters.AddWithValue("@NRO_OPERACION", cheque.TransferenciaSeguiTo.NRO_OPERACION);
            _ = cmd.Parameters.AddWithValue("@FECHA_TRANSFERENCIA", cheque.TransferenciaSeguiTo.FECHA_TRANSFERENCIA);
            _ = cmd.Parameters.AddWithValue("@ID_MONEDA", cheque.TransferenciaSeguiTo.ID_MONEDA);
            _ = cmd.Parameters.AddWithValue("@IMPORTE", cheque.TransferenciaSeguiTo.IMPORTE);
            _ = cmd.Parameters.AddWithValue("@REPRESENTANTE", cheque.TransferenciaSeguiTo.REPRESENTANTE);
            _ = cmd.Parameters.AddWithValue("@OBSERVACION", cheque.TransferenciaSeguiTo.OBSERVACION);
            _ = cmd.Parameters.AddWithValue("@USUARIO_CREA", cheque.USUARIO_CREA);

            try
            {
                if (cmd.ExecuteNonQuery() > 0)
                {
                    cheque.TransferenciaSeguiTo.ID_TRANSFERENCIA = Convert.ToInt32(parameter.Value);
                    return InsertarDetalleChequeSegui(cheque, sqlTran, cn);
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool InsertarDetalleChequeSegui(ChequesPlanillaTo cheque, SqlTransaction tran, SqlConnection cn)
        {
            try
            {
                const string procedure = "usp_InsertarDetalleChequeSegui";
                SqlCommand cmd = new SqlCommand(procedure, cn, tran)
                {
                    CommandType = CommandType.StoredProcedure
                };
                switch (cheque.TIPO_PAGO)
                {
                    case Tipo_Movimiento_Cheque.Envio:
                        _ = cmd.Parameters.AddWithValue("@ID_ENVIO", cheque.EnvioChequeTo.ID_ENVIO);
                        break;
                    case Tipo_Movimiento_Cheque.Recepcion:
                        _ = cmd.Parameters.AddWithValue("@ID_ENVIO", cheque.RecepcionChequeTo.ID_RECEPCION);
                        break;
                    case Tipo_Movimiento_Cheque.Deposito:
                        _ = cmd.Parameters.AddWithValue("@ID_ENVIO", cheque.DepositoChequeTo.ID_DEPOSITO);
                        break;
                    case Tipo_Movimiento_Cheque.Transferencia:
                        _ = cmd.Parameters.AddWithValue("@ID_ENVIO", cheque.TransferenciaSeguiTo.ID_TRANSFERENCIA);
                        break;
                    default:
                        throw new ArgumentException();
                }

                _ = cmd.Parameters.AddWithValue("@ID_SEGUIMIENTO", cheque.SeguimientoPlanillaTo.ID_SEGUIMIENTO);
                _ = cmd.Parameters.AddWithValue("@TIPO_ENVIO", cheque.TIPO_ENVIO_CHEQUE);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    return InsertarHistorialSeguiPago(cheque, tran, cn);
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool EliminarCheque(ChequesPlanillaTo cheque)
        {
            const string procedure = "usp_EliminarChequePlanilla";
            conn.Open();
            SqlTransaction sqlTrans = conn.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand(procedure, conn, sqlTrans)
                {
                    CommandType = CommandType.StoredProcedure
                };

                if (cmd.ExecuteNonQuery() > 0)
                {
                    sqlTrans.Commit();
                    return true;
                }
                sqlTrans.Rollback();
                return false;
            }
            catch (Exception)
            {
                sqlTrans.Rollback();
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        

        //public bool ActualizaDevolucionExcesoEntCab(DevolucionExcesoEntidad to)
        //{
        //    const string procedure = "usp_ActualizarDevolucionExcesoE";
        //    conn.Open();
        //    SqlTransaction transaction = conn.BeginTransaction();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand(procedure, conn, transaction)
        //        {
        //            CommandType = CommandType.StoredProcedure
        //        };

        //        _ = cmd.Parameters.AddWithValue("@ID_TRANSFERENCIA", to.TransferenciaSeguiTo.ID_TRANSFERENCIA);
        //        _ = cmd.Parameters.AddWithValue("@IMPORTE_VERIFICADO", to.TransferenciaSeguiTo.IMPORTE_VERIFICADO);
        //        _ = cmd.Parameters.AddWithValue("@IMPORTE_PROPIO_PLLA", to.TransferenciaSeguiTo.IMPORTE_PROPIO_PLLA);
        //        _ = cmd.Parameters.AddWithValue("@ESTADO", acces ? (int)Resultado_Cheque.Aprobar : (int)Resultado_Cheque.Pendiente);

        //        if (cmd.ExecuteNonQuery() > 0)
        //        {
                   
        //                transaction.Commit();
        //                return true;
                    
        //        }

        //        transaction.Rollback();
        //        return false;
        //    }
        //    catch (Exception)
        //    {
        //        transaction.Rollback();
        //        throw;
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //}

        public bool ActualizaDevolucionExcesoEntCab(DevolucionExcesoEntidad dev, SqlTransaction sqlTran, SqlConnection cn)
        {
            const string procedure = "usp_ActualizarDevolucionExcesoE";
            SqlCommand cmd = new SqlCommand(procedure, cn, sqlTran)
            {
                CommandType = CommandType.StoredProcedure
            };

         
            _ = cmd.Parameters.AddWithValue("@ID_SEGUIMIENTO", dev.ID_SEGUIMIENTO);
            _ = cmd.Parameters.AddWithValue("@ID_PAGO", dev.ID_PAGO);
            _ = cmd.Parameters.AddWithValue("@TIPO_PAGO", dev.TIPO_PAGO);
            _ = cmd.Parameters.AddWithValue("@FE_AÑO_SIS", dev.FE_AÑO_SIS);
            _ = cmd.Parameters.AddWithValue("@FE_MES_SIS", dev.FE_MES_SIS);
            _ = cmd.Parameters.AddWithValue("@IMPORTE_DEVOLVER_ENTIDAD", dev.IMPORTE_DEVOLVER_ENTIDAD);
            _ = cmd.Parameters.AddWithValue("@OBSERVACION", dev.OBSERVACION);
            _ = cmd.Parameters.AddWithValue("@ID_ESTADO", dev.ID_ESTADO);
            _ = cmd.Parameters.AddWithValue("@USUARIO_CREA", dev.USUARIO_CREA);
            _ = cmd.Parameters.AddWithValue("@USUARIO_MODIFICA", dev.USUARIO_MODIFICA);


            //DevolucionExcesoEntidad
            try
            {
                if (cmd.ExecuteNonQuery() > 0)
                {
                    
                    return true;
                    //return InsertarDevolucionExcesoEntDet(cheque, sqlTran, cn);   InsertarDetalleChequeSegui(cheque, sqlTran, cn);
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool AprobarTransferenciaSegui(ChequesPlanillaTo to, bool acces)
        {
            const string procedure = "usp_ActualizarEstadoTransSegui";
            conn.Open();
            SqlTransaction transaction = conn.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand(procedure, conn, transaction)
                {
                    CommandType = CommandType.StoredProcedure
                };

                _ = cmd.Parameters.AddWithValue("@ID_TRANSFERENCIA", to.TransferenciaSeguiTo.ID_TRANSFERENCIA);
                _ = cmd.Parameters.AddWithValue("@IMPORTE_VERIFICADO", to.TransferenciaSeguiTo.IMPORTE_VERIFICADO);
                _ = cmd.Parameters.AddWithValue("@IMPORTE_PROPIO_PLLA", to.TransferenciaSeguiTo.IMPORTE_PROPIO_PLLA);
                _ = cmd.Parameters.AddWithValue("@ESTADO", acces ? (int)Resultado_Cheque.Aprobar : (int)Resultado_Cheque.Pendiente);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    if (ActualizarSaldoXCobrarYImporteExceso(to.SeguimientoPlanillaTo, transaction))
                    {
                        transaction.Commit();
                        return true;
                    }
                }

                transaction.Rollback();
                return false;
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool ActualizarTransferenciaCheque(ChequesPlanillaTo cheque)
        {
            const string procedure = "usp_ActualizarTransferenciaSegui";
            SqlCommand cmd = new SqlCommand(procedure, conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            _ = cmd.Parameters.AddWithValue("@ID_TRANSFERENCIA", cheque.TransferenciaSeguiTo.ID_TRANSFERENCIA);
            _ = cmd.Parameters.AddWithValue("@BANCO_ORIGEN", cheque.TransferenciaSeguiTo.BANCO_ORIGEN);
            _ = cmd.Parameters.AddWithValue("@NRO_CUENTA_ORIGEN", cheque.TransferenciaSeguiTo.NRO_CTA_ORIGEN);
            _ = cmd.Parameters.AddWithValue("@COD_BANCO_DEST", cheque.TransferenciaSeguiTo.COD_BANCO_DEST);
            _ = cmd.Parameters.AddWithValue("@NRO_OPERACION", cheque.TransferenciaSeguiTo.NRO_OPERACION);
            _ = cmd.Parameters.AddWithValue("@FECHA_TRANSFERENCIA", cheque.TransferenciaSeguiTo.FECHA_TRANSFERENCIA);
            _ = cmd.Parameters.AddWithValue("@ID_MONEDA", cheque.TransferenciaSeguiTo.ID_MONEDA);
            _ = cmd.Parameters.AddWithValue("@IMPORTE", cheque.TransferenciaSeguiTo.IMPORTE);
            _ = cmd.Parameters.AddWithValue("@REPRESENTANTE", cheque.TransferenciaSeguiTo.REPRESENTANTE);
            _ = cmd.Parameters.AddWithValue("@OBSERVACION", cheque.TransferenciaSeguiTo.OBSERVACION);
            _ = cmd.Parameters.AddWithValue("@USUARIO_MODIFICA", cheque.USUARIO_CREA);

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

        public bool ActualizarChequeTransporteCourier(ChequesPlanillaTo cheque)
        {
            conn.Open();
            SqlTransaction transaction = conn.BeginTransaction();
            try
            {
                if (ActualizarEnvioCheque(cheque, transaction, conn))
                {
                    if (ActualizarRecepcionCheque(cheque, transaction, conn))
                    {
                        if (ActualizarChequeDeposito(cheque, transaction, conn))
                        {
                            transaction.Commit();
                            return true;
                        }
                    }
                }
                transaction.Rollback();
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

        private bool ActualizarEnvioCheque(ChequesPlanillaTo cheque, SqlTransaction sqlTran, SqlConnection cn)
        {
            const string procedure = "usp_ActualizarEnvioCheque";
            SqlCommand cmd = new SqlCommand(procedure, cn, sqlTran)
            {
                CommandType = CommandType.StoredProcedure
            };

            _ = cmd.Parameters.AddWithValue("@ID_ENVIO", cheque.EnvioChequeTo.ID_ENVIO);
            _ = cmd.Parameters.AddWithValue("@FECHA_ENVIO", cheque.EnvioChequeTo.FECHA_ENVIO);
            _ = cmd.Parameters.AddWithValue("@EMPRESA", cheque.EnvioChequeTo.EMPRESA);
            _ = cmd.Parameters.AddWithValue("@ID_DOCUMENTO", cheque.EnvioChequeTo.ID_DOCUMENTO);
            _ = cmd.Parameters.AddWithValue("@NRO_DOCUMENTO", cheque.EnvioChequeTo.NRO_DOCUMENTO);
            _ = cmd.Parameters.AddWithValue("@REPRESENTANTE", cheque.EnvioChequeTo.REPRESENTANTE);
            _ = cmd.Parameters.AddWithValue("@RESPONSABLE", cheque.EnvioChequeTo.RESPONSABLE);
            _ = cmd.Parameters.AddWithValue("@USUARIO_MODIFICA", cheque.USUARIO_CREA);

            try
            {
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool ActualizarRecepcionCheque(ChequesPlanillaTo cheque, SqlTransaction sqlTran, SqlConnection cn)
        {
            const string procedure = "usp_ActualizarRecepcionCheque";
            SqlCommand cmd = new SqlCommand(procedure, cn, sqlTran)
            {
                CommandType = CommandType.StoredProcedure
            };

            _ = cmd.Parameters.AddWithValue("@ID_RECEPCION", cheque.RecepcionChequeTo.ID_RECEPCION);
            _ = cmd.Parameters.AddWithValue("@ID_ENVIO", cheque.EnvioChequeTo.ID_ENVIO);
            _ = cmd.Parameters.AddWithValue("@FECHA_RECEPCION", cheque.RecepcionChequeTo.FECHA_RECEPCION);
            _ = cmd.Parameters.AddWithValue("@BANCO_ORIGEN", cheque.RecepcionChequeTo.BANCO_ORIGEN);
            _ = cmd.Parameters.AddWithValue("@NRO_CHEQUE", cheque.RecepcionChequeTo.NRO_CHEQUE);
            _ = cmd.Parameters.AddWithValue("@ID_MONEDA", cheque.RecepcionChequeTo.ID_MONEDA);
            _ = cmd.Parameters.AddWithValue("@IMPORTE", cheque.RecepcionChequeTo.IMPORTE);
            _ = cmd.Parameters.AddWithValue("@REPRESENTANTE", cheque.RecepcionChequeTo.REPRESENTANTE);
            _ = cmd.Parameters.AddWithValue("@RESPONSABLE", cheque.RecepcionChequeTo.RESPONSABLE);
            _ = cmd.Parameters.AddWithValue("@USUARIO_MODIFICA", cheque.USUARIO_CREA);

            try
            {
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ActualizarChequeDeposito(ChequesPlanillaTo cheque, SqlTransaction sqlTran, SqlConnection cn)
        {
            const string procedure = "usp_ActualizarChequeDepositadoSegui";
            SqlCommand cmd = new SqlCommand(procedure, cn, sqlTran)
            {
                CommandType = CommandType.StoredProcedure
            };

            _ = cmd.Parameters.AddWithValue("@ID_DEPOSITO", cheque.DepositoChequeTo.ID_DEPOSITO);
            _ = cmd.Parameters.AddWithValue("@ID_ENVIO", cheque.EnvioChequeTo.ID_ENVIO);
            _ = cmd.Parameters.AddWithValue("@COD_BANCO", cheque.DepositoChequeTo.COD_BANCO);
            _ = cmd.Parameters.AddWithValue("@NRO_CHEQUE", cheque.DepositoChequeTo.NRO_CHEQUE);
            _ = cmd.Parameters.AddWithValue("@NRO_OPERACION", cheque.DepositoChequeTo.NRO_OPERACION);
            _ = cmd.Parameters.AddWithValue("@FECHA_DEPOSITO", cheque.DepositoChequeTo.FECHA_DEPOSITO);
            _ = cmd.Parameters.AddWithValue("@ID_MONEDA", cheque.DepositoChequeTo.ID_MONEDA);
            _ = cmd.Parameters.AddWithValue("@IMPORTE", cheque.DepositoChequeTo.IMPORTE);
            _ = cmd.Parameters.AddWithValue("@REPRESENTANTE", cheque.DepositoChequeTo.REPRESENTANTE);
            _ = cmd.Parameters.AddWithValue("@OBSERVACION", cheque.DepositoChequeTo.OBSERVACION);
            _ = cmd.Parameters.AddWithValue("@USUARIO_MODIFICA", cheque.USUARIO_CREA);

            try
            {
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ActualizarChequeDeposito(ChequesPlanillaTo cheque)
        {
            const string procedure = "usp_ActualizarChequeDepositadoSegui";
            SqlCommand cmd = new SqlCommand(procedure, conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            _ = cmd.Parameters.AddWithValue("@ID_DEPOSITO", cheque.DepositoChequeTo.ID_DEPOSITO);
            _ = cmd.Parameters.AddWithValue("@ID_ENVIO", cheque.EnvioChequeTo.ID_ENVIO);
            _ = cmd.Parameters.AddWithValue("@COD_BANCO", cheque.DepositoChequeTo.COD_BANCO);
            _ = cmd.Parameters.AddWithValue("@NRO_CHEQUE", cheque.DepositoChequeTo.NRO_CHEQUE);
            _ = cmd.Parameters.AddWithValue("@NRO_OPERACION", cheque.DepositoChequeTo.NRO_OPERACION);
            _ = cmd.Parameters.AddWithValue("@FECHA_DEPOSITO", cheque.DepositoChequeTo.FECHA_DEPOSITO);
            _ = cmd.Parameters.AddWithValue("@ID_MONEDA", cheque.DepositoChequeTo.ID_MONEDA);
            _ = cmd.Parameters.AddWithValue("@IMPORTE", cheque.DepositoChequeTo.IMPORTE);
            _ = cmd.Parameters.AddWithValue("@REPRESENTANTE", cheque.DepositoChequeTo.REPRESENTANTE);
            _ = cmd.Parameters.AddWithValue("@OBSERVACION", cheque.DepositoChequeTo.OBSERVACION);
            _ = cmd.Parameters.AddWithValue("@USUARIO_MODIFICA", cheque.USUARIO_CREA);

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

        public bool AprobarChequeDeposito(ChequesPlanillaTo to, bool acces)
        {
            const string procedure = "usp_ActualizarEstadoDepositoSegui";
            conn.Open();
            SqlTransaction transaction = conn.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand(procedure, conn, transaction)
                {
                    CommandType = CommandType.StoredProcedure
                };

                _ = cmd.Parameters.AddWithValue("@ID_ENVIO", to.EnvioChequeTo.ID_ENVIO);
                _ = cmd.Parameters.AddWithValue("@ID_DEPOSITO", to.DepositoChequeTo.ID_DEPOSITO);
                _ = cmd.Parameters.AddWithValue("@IMPORTE_VERIFICADO", to.DepositoChequeTo.IMPORTE_VERIFICADO);
                _ = cmd.Parameters.AddWithValue("@IMPORTE_PROPIO_PLLA", to.DepositoChequeTo.IMPORTE_PROPIO_PLLA);
                _ = cmd.Parameters.AddWithValue("@ESTADO", acces ? (int)Resultado_Cheque.Aprobar : (int)Resultado_Cheque.Pendiente);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    if (ActualizarSaldoXCobrarYImporteExceso(to.SeguimientoPlanillaTo, transaction))
                    {
                        transaction.Commit();
                        return true;
                    }
                }
                transaction.Rollback();
                return false;
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool AprobarChequeDeposito(ChequesPlanillaTo to, bool acces, SqlConnection cn, SqlTransaction tr)
        {
            const string procedure = "usp_ActualizarEstadoDepositoSegui";
            try
            {
                SqlCommand cmd = new SqlCommand(procedure, cn, tr)
                {
                    CommandType = CommandType.StoredProcedure
                };

                _ = cmd.Parameters.AddWithValue("@ID_ENVIO", to.EnvioChequeTo.ID_ENVIO);
                _ = cmd.Parameters.AddWithValue("@ID_DEPOSITO", to.DepositoChequeTo.ID_DEPOSITO);
                _ = cmd.Parameters.AddWithValue("@IMPORTE_VERIFICADO", to.DepositoChequeTo.IMPORTE_VERIFICADO);
                _ = cmd.Parameters.AddWithValue("@IMPORTE_PROPIO_PLLA", to.DepositoChequeTo.IMPORTE_PROPIO_PLLA);
                _ = cmd.Parameters.AddWithValue("@ESTADO", acces ? (int)Resultado_Cheque.Aprobar : (int)Resultado_Cheque.Pendiente);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    if (ActualizarSaldoXCobrarYImporteExceso(to.SeguimientoPlanillaTo, cn, tr))
                        return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ActualizarSaldoXCobrarYImporteExceso(SeguimientoPlanillaTo se, SqlConnection cn, SqlTransaction sqlTransac)
        {
            const string procedure = "dsp_ActualizarImportesSeguimientoPlanilla";
            try
            {
                SqlCommand cmd = new SqlCommand(procedure, cn, sqlTransac)
                {
                    CommandType = CommandType.StoredProcedure
                };

                _ = cmd.Parameters.AddWithValue("@ID_SEGUIMIENTO", se.ID_SEGUIMIENTO);
                _ = cmd.Parameters.AddWithValue("@IMPORTE_EXC_INI", se.IMPORTE_EXC_INI);
                _ = cmd.Parameters.AddWithValue("@IMPORTE_EXC_DOC", se.IMPORTE_EXC_DOC);
                _ = cmd.Parameters.AddWithValue("@IMPORTE_COBRADO", se.IMPORTE_VERIFICADO);
                _ = cmd.Parameters.AddWithValue("@SALDO_X_COBRAR", se.SALDO_X_COBRAR);

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable ListarSeguimientoCheque(string año, string mes)
        {
            SqlCommand cmd = new SqlCommand("usp_ListarSeguimientoCheque", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            _ = cmd.Parameters.AddWithValue("@FE_AÑO", año);
            _ = cmd.Parameters.AddWithValue("@FE_MES", mes);

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

        public DataTable ListarSeguimientoChequeXIdSeguimiento(int idSeguimiento)
        {
            const string procedure = "usp_ObtenerMovimientosChequeXIdSeguimiento";
            SqlCommand cmd = new SqlCommand(procedure, conn)
            {
                CommandType = CommandType.StoredProcedure
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

        public DataTable ListarClientesPllDscto(string codPtoCob)
        {
            const string function = "SELECT * FROM fn_ObtenerClientesPllaDescto(@COD_PTO_COB)";
            SqlCommand cmd = new SqlCommand(function, conn)
            {
                CommandType = CommandType.Text
            };

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

        public DataTable ObtenerContratosXCodPer(string codPer)
        {
            const string function = "SELECT NRO_PRESUPUESTO, FECHA_PRE, FE_AÑO, FE_MES FROM I_PEDIDO WHERE COD_PER = @COD_PER";
            SqlCommand cmd = new SqlCommand(function, conn)
            {
                CommandType = CommandType.Text
            };

            _ = cmd.Parameters.AddWithValue("@COD_PER", codPer);
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


        public bool FinalizarCobranzaPlanillas(int idSegumiento, decimal importeAjuste,
            decimal importeVerificado, decimal saldoXCobrar, decimal importeExceso, bool tipoRe)
        {
            const string procedure1 = "usp_CierreCobranzaPlanilla";
            const string procedure2 = "usp_RegistrarCobranzaPlanilla";
            conn.Open();
            try
            {
                string procedure = tipoRe ? procedure1 : procedure2;
                SqlCommand cmd = new SqlCommand(procedure, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                _ = cmd.Parameters.AddWithValue("@ID_SEGUIMIENTO", idSegumiento);
                _ = cmd.Parameters.AddWithValue("@IMPORTE_AJUSTE", importeAjuste);
                _ = cmd.Parameters.AddWithValue("@IMPORTE_VERIFICADO", importeVerificado);
                _ = cmd.Parameters.AddWithValue("@SALDO_X_COBRAR", saldoXCobrar);
                _ = cmd.Parameters.AddWithValue("@IMPORTE_EXC_INI", importeExceso);

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

        public bool InsertarRetencion(string usuario, DataTable dtRetencion)
        {
            const string procedure = "usp_InsertarRetencion";
            try
            {
                bool result = true;
                conn.Open();
                foreach (DataRow row in dtRetencion.Rows)
                {
                    SqlCommand cmd = new SqlCommand(procedure, conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    _ = cmd.Parameters.AddWithValue("@ID_SEGUIMIENTO", row["ID_SEGUIMIENTO"]);
                    _ = cmd.Parameters.AddWithValue("@NRO_PLANILLA_DOC", row["NRO_PLANILLA_DOC"]);
                    _ = cmd.Parameters.AddWithValue("@NRO_PLANILLA_COB", row["NRO_PLANILLA_COB"]);
                    _ = cmd.Parameters.AddWithValue("@COD_PTO_COB", row["COD_PTO_COB"]);
                    _ = cmd.Parameters.AddWithValue("@COD_INSTITUCION", row["COD_INSTITUCION"]);
                    _ = cmd.Parameters.AddWithValue("@COD_CANAL_DSCTO", row["COD_CANAL_DSCTO"]);
                    _ = cmd.Parameters.AddWithValue("@FE_AÑO", row["FE_AÑO"]);
                    _ = cmd.Parameters.AddWithValue("@FE_MES", row["FE_MES"]);
                    _ = cmd.Parameters.AddWithValue("@FE_AÑO_REF", row["FE_AÑO_REF"]);
                    _ = cmd.Parameters.AddWithValue("@FE_MES_REF", row["FE_MES_REF"]);
                    _ = cmd.Parameters.AddWithValue("@TIPO_PLANILLA_DOC", row["TIPO_PLANILLA_DOC"]);
                    _ = cmd.Parameters.AddWithValue("@COD_SUCURSAL", row["COD_SUCURSAL"]);
                    _ = cmd.Parameters.AddWithValue("@IMP_PLANILLA", Convert.ToDecimal(row["IMPORTE"]));
                    _ = cmd.Parameters.AddWithValue("@COD_PER", row["COD_PER"].ToString());
                    _ = cmd.Parameters.AddWithValue("@NRO_CONTRATO", row["NRO_CONTRATO"].ToString());
                    _ = cmd.Parameters.AddWithValue("@IMP_RETENIDO", Convert.ToDecimal(row["IMP_RETENCION"]));
                    _ = cmd.Parameters.AddWithValue("@USUARIO_CREA", usuario);

                    if (cmd.ExecuteNonQuery() == 0)
                    {
                        result = false;
                        break;
                    }
                }
                return result;
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

        public bool ActualizarRetencion(DataTable dtRetenActualizar)
        {
            const string procedure = "usp_ActualizarRetencion";
            try
            {
                conn.Open();
                foreach (DataRow row in dtRetenActualizar.Rows)
                {
                    SqlCommand cmd = new SqlCommand(procedure, conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    _ = cmd.Parameters.AddWithValue("@ID_SEGUIMIENTO", row["ID_SEGUIMIENTO"]);
                    _ = cmd.Parameters.AddWithValue("@ID_RETENCION", row["ID_RETENCION"]);
                    _ = cmd.Parameters.AddWithValue("@IMPORTE_PLANILLA", row["IMPORTE"]);
                    _ = cmd.Parameters.AddWithValue("@IMPORTE_RETENIDO", Convert.ToDecimal(row["IMP_RETENCION"]));

                    if (cmd.ExecuteNonQuery() == 0)
                        return false;
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

        public bool EliminarRetencion(int idSeguimiento, DataTable dtRetenEliminados)
        {
            const string procedure = "usp_EliminarRetencion";
            try
            {
                conn.Open();
                foreach (DataRow row in dtRetenEliminados.Rows)
                {
                    SqlCommand cmd = new SqlCommand(procedure, conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    _ = cmd.Parameters.AddWithValue("@ID_SEGUIMIENTO", row["ID_SEGUIMIENTO"]);
                    _ = cmd.Parameters.AddWithValue("@ID_RETENCION", row["ID_RETENCION"]);

                    if (cmd.ExecuteNonQuery() == 0)
                        return false;
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

        public DataTable ObtenerDatosCierreCobrazaPlla(string nroPlanillaEnv, string nroPlanilla, string entPagChe)
        {
            const string procedure = "usp_ObtenerDatosCierreCobrazaPlla";
            SqlCommand cmd = new SqlCommand(procedure, conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            _ = cmd.Parameters.AddWithValue("@NRO_PLLA_ENV", nroPlanillaEnv);
            _ = cmd.Parameters.AddWithValue("@NRO_PLANILLA", nroPlanilla);
            _ = cmd.Parameters.AddWithValue("@ENT_PAG_CHEQ", entPagChe);

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

        public DataTable ListarLlamdasPendientesCheque()
        {
            const string procedure = "usp_ListarLlamadasPendientesCheque";
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

        public bool EliminarCobranzaPlanilla(ChequesPlanillaTo to, SqlConnection cn, SqlTransaction tr)
        {
            try
            {
                if (EliminarHistorialSeguiPago(to, tr, cn))
                {
                    const string procedure = "usp_EliminarCobranzaPlanilla";
                    SqlCommand cmd = new SqlCommand(procedure, cn, tr)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    _ = cmd.Parameters.AddWithValue("@ID", to.ID_PAGO);
                    _ = cmd.Parameters.AddWithValue("@ID_SEGUIMIENTO", to.SeguimientoPlanillaTo.ID_SEGUIMIENTO);
                    _ = cmd.Parameters.AddWithValue("@TIPO_OPERACION", (int)to.TipoOperacionCobranza);

                    SqlParameter parameter = new SqlParameter("@RESULT", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    _ = cmd.Parameters.Add(parameter);

                    if (cmd.ExecuteNonQuery() > 0 && Convert.ToInt32(parameter.Value) == 1)
                    {
                        if ((int)to.ESTADO == 1)//> 1 => pendiente, 2 => aprobado
                            return true;
                        else if ((int)to.ESTADO == 2 && ActualizarSaldoXCobrarYImporteExceso(to.SeguimientoPlanillaTo, cn, tr))
                            return true;
                    }
                    return false;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool EliminarDevolucionExcesoE(DevolucionExcesoEntidad to, SqlConnection cn, SqlTransaction tr)
        {
            try
            {
                
                    const string procedure = "usp_EliminarDevolucionExcesoE";
                    SqlCommand cmd = new SqlCommand(procedure, cn, tr)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    _ = cmd.Parameters.AddWithValue("@ID_SEGUIMIENTO", to.ID_SEGUIMIENTO);
                    _ = cmd.Parameters.AddWithValue("@ID_PAGO", (int)to.ID_PAGO);
                    _ = cmd.Parameters.AddWithValue("@TIPO_PAGO", to.TIPO_PAGO);

                    SqlParameter parameter = new SqlParameter("@RESULT", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    _ = cmd.Parameters.Add(parameter);

                    if (cmd.ExecuteNonQuery() > 0 && Convert.ToInt32(parameter.Value) == 1)
                    {
                            return true;
                            //if ((int)to.ESTADO == 1)//> 1 => pendiente, 2 => aprobado
                            //    return true;
                            //else if ((int)to.ESTADO == 2 && ActualizarSaldoXCobrarYImporteExceso(to.SeguimientoPlanillaTo, cn, tr))
                            //    return true;
                    }
                    return false;
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Elimina un registro de la tabla [SALDO_APLICA_PLANILLA], mediante el ID_ENVIO_APL(Depósito/Transferencia), 
        /// ID_SEGUIMIENTO_APL(Id al cual se aplicó el exceso de pago y a la cual pertenece el ID_ENVIO_APL) y TIPO_ENVIO_APL(Depósito/Transferencia)
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="tr"></param>
        /// <returns></returns>
        public bool EliminarAplicacionOtrasPlanillas(ChequesPlanillaTo to, SqlConnection cn, SqlTransaction tr)
        {
            const string sentencia = "DELETE SALDO_APLICA_PLANILLA WHERE ID_ENVIO_APL = @ID_ENVIO_APL AND TIPO_ENVIO_APL = @TIPO_ENVIO_APL AND ID_SEGUIMIENTO_APL = @ID_SEGUIMIENTO_APL";
            try
            {
                SqlCommand cmd = new SqlCommand(sentencia, cn, tr)
                {
                    CommandType = CommandType.Text
                };

                _ = cmd.Parameters.AddWithValue("@ID_SEGUIMIENTO_APL", to.SeguimientoPlanillaTo.ID_SEGUIMIENTO);
                _ = cmd.Parameters.AddWithValue("@ID_ENVIO_APL", to.ID_PAGO);
                _ = cmd.Parameters.AddWithValue("@TIPO_ENVIO_APL", to.TIPO_PAGO_TXT);

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable ListarPlanillasDsctosPendienteXCodPtoCob(string codPtoCob)
        {
            const string procedure = "MOSTRAR_PLANILLA_CABECERA_OTRAS_DEV_DSCTOS_PENDIENTES_X_PTO_COB";
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

        public DataTable ListarPlanillasDsctosPendienteXCodPtoCobRetencion(string codPtoCob, string nroPlanillaCob, string feAño, string feMes, string tipoPlanilla)
        {
            const string procedure = "MOSTRAR_PLANILLA_CABECERA_OTRAS_DEV_DSCTOS_PENDIENTES_X_PTO_COB_RETENCION";
            SqlCommand cmd = new SqlCommand(procedure, conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            _ = cmd.Parameters.AddWithValue("@COD_PTO_COB", codPtoCob);
            _ = cmd.Parameters.AddWithValue("@NRO_PLANILLA_COB", nroPlanillaCob);
            _ = cmd.Parameters.AddWithValue("@FE_AÑO", feAño);
            _ = cmd.Parameters.AddWithValue("@FE_MES", feMes);
            _ = cmd.Parameters.AddWithValue("@TIPO_PLANILLA", tipoPlanilla);
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

        public bool ActualizarPlanillaCabeceraOtrasDevDscto(DataTable dt)
        {
            const string procedure = "UPDATE_PLANILLA_CABECERA_OTRAS_DEV_DSCTOS";
            try
            {
                int result;
                conn.Open();
                foreach (DataRow row in dt.Rows)
                {
                    SqlCommand cmd = new SqlCommand(procedure, conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    _ = cmd.Parameters.AddWithValue("@IMPORTE_DOC", Convert.ToDecimal(row["IMP_RETENCION"]));
                    _ = cmd.Parameters.AddWithValue("@NRO_PLANILLA_DOC", row["NRO_PLANILLA_DOC"]);
                    _ = cmd.Parameters.AddWithValue("@COD_INSTITUCION", row["COD_INSTITUCION"]);
                    _ = cmd.Parameters.AddWithValue("@COD_CANAL_DSCTO", row["COD_CANAL_DSCTO"]);
                    _ = cmd.Parameters.AddWithValue("@FE_AÑO", row["FE_AÑO"]);
                    _ = cmd.Parameters.AddWithValue("@FE_MES", row["FE_MES"]);
                    _ = cmd.Parameters.AddWithValue("@TIPO_PLANILLA_DOC", row["TIPO_PLANILLA_DOC"]);
                    result = cmd.ExecuteNonQuery();
                    if (result == 0 || result > 1)
                        return false;
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

        public bool ActualizarPlanillaDetalleOtrasDevDscto(DataTable dt)
        {
            const string procedure = "UPDATE_PLANILLA_DETALLE_OTRAS_DEV_DSCTOS";
            try
            {
                int result;
                conn.Open();
                foreach (DataRow row in dt.Rows)
                {
                    SqlCommand cmd = new SqlCommand(procedure, conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    _ = cmd.Parameters.AddWithValue("@IMPORTE_DOC", Convert.ToDecimal(row["IMP_RETENCION"]));
                    _ = cmd.Parameters.AddWithValue("@NRO_PLANILLA_DOC", row["NRO_PLANILLA_DOC"]);
                    _ = cmd.Parameters.AddWithValue("@COD_INSTITUCION", row["COD_INSTITUCION"]);
                    _ = cmd.Parameters.AddWithValue("@COD_CANAL_DSCTO", row["COD_CANAL_DSCTO"]);
                    _ = cmd.Parameters.AddWithValue("@FE_AÑO", row["FE_AÑO"]);
                    _ = cmd.Parameters.AddWithValue("@FE_MES", row["FE_MES"]);
                    _ = cmd.Parameters.AddWithValue("@TIPO_PLANILLA_DOC", row["TIPO_PLANILLA_DOC"]);

                    result = cmd.ExecuteNonQuery();
                    if (result == 0 || result > 1)
                        return false;
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

        public decimal ObtenerTotalRetencion(string nroPlanillaCob, string codInstitucion, string codCanalDscto, string codSucursal,
            string codPer, string nroContrato)
        {
            const string function = "SELECT dbo.fn_ObtenerImporteRetenidosXPlanilla(@NRO_PLANILLA_COB,@COD_INSTITUCION,@COD_CANAL_DSCTO,@COD_SUCURSAL,@COD_PER,@NRO_CONTRATO)";
            SqlCommand cmd = new SqlCommand(function, conn)
            {
                CommandType = CommandType.Text
            };

            _ = cmd.Parameters.AddWithValue("@NRO_PLANILLA_COB", nroPlanillaCob);
            _ = cmd.Parameters.AddWithValue("@COD_INSTITUCION", codInstitucion);
            _ = cmd.Parameters.AddWithValue("@COD_CANAL_DSCTO", codCanalDscto);
            _ = cmd.Parameters.AddWithValue("@COD_SUCURSAL", codSucursal);
            _ = cmd.Parameters.AddWithValue("@COD_PER", codPer);
            _ = cmd.Parameters.AddWithValue("@NRO_CONTRATO", nroContrato);

            try
            {
                conn.Open();
                string result = cmd.ExecuteScalar().ToString();
                return string.IsNullOrEmpty(result) ? 0 : Convert.ToDecimal(result);
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

        public DataTable ListarPlanillasExcCobranzaAplicar(string codPtoCob)
        {
            const string procedure = "usp_ListarPlanillasExcCobranzaAplicar";
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

        /// <summary>
        /// Obtiene planillas que tienen saldo por cobrar, para poder aplicar un importe  a estas de la planilla seleccionada que tiene el exceso de pago.
        /// idSeguimiento es id tiene el propósito de mostrar cuanto importe se aplicó a las planillas de este idSeguimiento seleccionado, ya que una plnilla
        /// puede ser aplicado por otras planillas
        /// </summary>
        /// <param name="codPtoCob">codPtoCob de la planilla que tiene exceso de pago</param>
        /// <param name="idSeguimiento">IdSeguimiento de la planilla seleccionada para aplicar  a otras planillas, es decir, esta idSeguimiento
        /// pertenece a la planilla que tiene exceso de pago
        /// </param>
        /// <returns></returns>
        public DataTable ListarPlanillasSaldoXCobrarAplicar(string codPtoCob, int idSeguimiento)
        {
            const string procedure = "usp_ListarPlanillasSaldoXCobrarAplicar";
            SqlCommand cmd = new SqlCommand(procedure, conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            _ = cmd.Parameters.AddWithValue("@COD_PTO_COB", codPtoCob);
            _ = cmd.Parameters.AddWithValue("@ID_SEGUIMIENTO", idSeguimiento);

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
        
        public DataTable ListarDetalleDevoluciones(int idSeguimiento, int id_pago)
        {
            const string procedure = "usp_ListarDetalleDevoluciones";
            SqlCommand cmd = new SqlCommand(procedure, conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            _ = cmd.Parameters.AddWithValue("@ID_SEGUIMIENTO", idSeguimiento);
            _ = cmd.Parameters.AddWithValue("@ID_PAGO", id_pago);
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
        public DataTable ObtenerPlanillasAplicEnvio(int idSeguimiento)
        {
            const string procedure = "usp_ObtenerPlanillasAplicEnv";
            SqlCommand cmd = new SqlCommand(procedure, conn)
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

        public DataTable ObtenerPlanillasAplicRecibo(int idSeguimiento)
        {
            const string procedure = "usp_ObtenerPlanillasAplicRec";
            SqlCommand cmd = new SqlCommand(procedure, conn)
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

        public bool InsertarSaldoAplicaPlanilla(DataTable dt, Tipo_APL_SALDO tipo_APL_SALDO, ref string errMessage)
        {
            const string procedure = "usp_InsertarSaldoAplicaPlla";
            try
            {
                serieDocumentosTo serieDocumentosTo = null;
                if (dt.Select("TAG = '*'").ToArray().Length > 0 && tipo_APL_SALDO == Tipo_APL_SALDO.Planilla_Imp_x_cobrar) //> Eliminamos las planillas existentes, para volver a insertarlos con los datos actualizados
                    EliminarAplicacionesXIdSeguimientoApl(Convert.ToInt32(dt.Rows[0]["ID_SEGUIMIENTO_APL"]), tipo_APL_SALDO);
                else if (dt.Select("TAG = '*'").ToArray().Length > 0 && tipo_APL_SALDO == Tipo_APL_SALDO.Planilla_Imp_Exceso)
                    EliminarAplicacionesXIdSeguimientoApl(Convert.ToInt32(dt.Rows[0]["ID_SEGUIMIENTO_SEL"]), tipo_APL_SALDO);

                conn.Open();
                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        SqlCommand cmd = new SqlCommand(procedure, conn)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        if (row["TAG"].ToString() == REGISTRO_NUEVO)
                            serieDocumentosTo = DALSerieDocumento.ObtenerSerieDocumentoTo(row["TIPO_DOC"].ToString(), conn);

                        _ = cmd.Parameters.AddWithValue("@NRO_DOCUMENTO", row["TAG"].ToString() == REGISTRO_GRABADO ? row["NRO_DOCUMENTO"].ToString() : serieDocumentosTo.CORRELATIVO);
                        _ = cmd.Parameters.AddWithValue("@FE_AÑO", row["FE_AÑO"].ToString());
                        _ = cmd.Parameters.AddWithValue("@FE_MES", row["FE_MES"]).ToString();
                        _ = cmd.Parameters.AddWithValue("@TIPO_DOC", row["TIPO_DOC"].ToString());
                        _ = cmd.Parameters.AddWithValue("@ID_SEGUIMIENTO_APL", Convert.ToInt32(row["ID_SEGUIMIENTO_APL"]));
                        _ = cmd.Parameters.AddWithValue("@ID_SEGUIMIENTO_SEL", Convert.ToInt32(row["ID_SEGUIMIENTO_SEL"]));
                        _ = cmd.Parameters.AddWithValue("@IMPORTE_APLICADO", Convert.ToDecimal(row["IMPORTE_APLICADO"]));
                        _ = cmd.Parameters.AddWithValue("@USUARIO_CREA", row["USUARIO_CREA"].ToString());

                        if (cmd.ExecuteNonQuery() <= 0)
                            return false;
                        if (row["TAG"].ToString() == REGISTRO_NUEVO)
                        {
                            if (!DALSerieDocumento.adicionaNroSerieDAL(serieDocumentosTo, conn, ref errMessage))
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
            finally
            {
                conn.Close();
            }
        }

        public bool InsertarSaldoAplicaPlanilla(DataTable dt, SqlTransaction tr, SqlConnection cn)
        {
            const string procedure = "usp_InsertarSaldoAplicaPlla";
            try
            {
                if (dt == null)
                    return true;
                foreach (DataRow row in dt.Rows)
                {
                    using (SqlCommand cmd = new SqlCommand(procedure, cn, tr))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        serieDocumentosTo serieDocumentosTo = DALSerieDocumento.ObtenerSerieDocumentoTo(row["TIPO_DOC"].ToString(), cn, tr);

                        _ = cmd.Parameters.AddWithValue("@NRO_DOCUMENTO", serieDocumentosTo.CORRELATIVO);
                        _ = cmd.Parameters.AddWithValue("@FE_AÑO", row["FE_AÑO"].ToString());
                        _ = cmd.Parameters.AddWithValue("@FE_MES", row["FE_MES"]).ToString();
                        _ = cmd.Parameters.AddWithValue("@TIPO_DOC", row["TIPO_DOC"].ToString());
                        _ = cmd.Parameters.AddWithValue("@ID_SEGUIMIENTO_APL", Convert.ToInt32(row["ID_SEGUIMIENTO_APL"]));
                        _ = cmd.Parameters.AddWithValue("@ID_SEGUIMIENTO_SEL", Convert.ToInt32(row["ID_SEGUIMIENTO_SEL"]));
                        _ = cmd.Parameters.AddWithValue("@ID_ENVIO_APL", Convert.ToInt32(row["ID_ENVIO_APL"]));
                        _ = cmd.Parameters.AddWithValue("@TIPO_ENVIO_APL", Convert.ToString(row["TIPO_ENVIO_APL"]));
                        _ = cmd.Parameters.AddWithValue("@ID_ENVIO_SEL", Convert.ToInt32(row["ID_ENVIO_SEL"]));
                        _ = cmd.Parameters.AddWithValue("@TIPO_ENVIO_SEL", Convert.ToString(row["TIPO_ENVIO_SEL"]));
                        _ = cmd.Parameters.AddWithValue("@IMPORTE_APLICADO", Convert.ToDecimal(row["IMPORTE_APLICADO"]));
                        _ = cmd.Parameters.AddWithValue("@USUARIO_CREA", row["USUARIO_CREA"].ToString());

                        if (cmd.ExecuteNonQuery() <= 0)
                            return false;
                        if (!DALSerieDocumento.AdicionaNroSerieDAL(serieDocumentosTo, cn, tr))
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

        public bool ActualizaSaldoAplicaPlanilla(DataTable dt, SqlTransaction tr, SqlConnection cn)
        {
            const string sentencia = "UPDATE SALDO_APLICA_PLANILLA " +
                                     "SET IMPORTE_APLICADO = @IMPORTE_APLICADO, USUARIO_MODIFICA = @USUARIO_MODIFICA, FECHA_MODIFICA = GETDATE() " +
                                     "WHERE NRO_DOCUMENTO = @NRO_DOCUMENTO AND FE_AÑO = @FE_AÑO AND FE_MES = @FE_MES " +
                                     "AND TIPO_DOC = @TIPO_DOC";
            try
            {
                if (dt == null)
                    return true;
                foreach (DataRow row in dt.Rows)
                {
                    using (SqlCommand cmd = new SqlCommand(sentencia, cn, tr))
                    {
                        cmd.CommandType = CommandType.Text;

                        _ = cmd.Parameters.Add("@NRO_DOCUMENTO", SqlDbType.VarChar).Value = row["NRO_DOCUMENTO"].ToString();
                        _ = cmd.Parameters.Add("@FE_AÑO", SqlDbType.VarChar).Value = row["FE_AÑO"].ToString();
                        _ = cmd.Parameters.Add("@FE_MES", SqlDbType.VarChar).Value = row["FE_MES"].ToString();
                        _ = cmd.Parameters.Add("@TIPO_DOC", SqlDbType.VarChar).Value = row["TIPO_DOC"].ToString();
                        _ = cmd.Parameters.Add("@IMPORTE_APLICADO", SqlDbType.Decimal).Value = Convert.ToDecimal(row["IMPORTE_APLICADO"]);
                        _ = cmd.Parameters.Add("@USUARIO_MODIFICA", SqlDbType.VarChar).Value = row["USUARIO_MODIFICA"].ToString();

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

        public bool ActualizarSaldoXCobrarPlanillaAplicaciones(DataTable dt, ref string errMessage)
        {
            const string procedure = "usp_ActualizarSaldoXCobrarPlanilla";

            try
            {
                conn.Open();
                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        SqlCommand cmd = new SqlCommand(procedure, conn)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        _ = cmd.Parameters.AddWithValue("@ID_SEGUIMIENTO", Convert.ToInt32(row["ID_SEGUIMIENTO_APL"]));
                        _ = cmd.Parameters.AddWithValue("@IMPORTE_OLD", Convert.ToDecimal(row["IMPORTE_APLICADO_OLD"]));
                        _ = cmd.Parameters.AddWithValue("@IMPORTE_APLICADO", Convert.ToDecimal(row["IMPORTE_APLICADO"]));

                        int result = cmd.ExecuteNonQuery();
                        if (result <= 0)
                        {
                            errMessage = result < 0 ? "Problemas con saldo, vuelva a intentarlo" : "No se pudo insertar";
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
            finally
            {
                conn.Close();
            }
        }


        public bool ActualizarImporteExcesoPlanillaAplicaciones(DataTable dt, Tipo_APL_SALDO tipo_APL_SALDO, ref string errMessage)
        {
            const string procedure = "usp_ActualizarImporteExcesoPlanilla";

            try
            {
                conn.Open();
                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        SqlCommand cmd = new SqlCommand(procedure, conn)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        _ = cmd.Parameters.AddWithValue("@ID_SEGUIMIENTO", Convert.ToInt32(row["ID_SEGUIMIENTO_SEL"]));
                        _ = cmd.Parameters.AddWithValue("@IMPORTE_OLD", tipo_APL_SALDO == Tipo_APL_SALDO.Planilla_Imp_x_cobrar ? Convert.ToDecimal(row["IMPORTE_APLICADO_OLD"]) : 0);
                        _ = cmd.Parameters.AddWithValue("@IMPORTE_APLICADO", Convert.ToDecimal(row["IMPORTE_APLICADO"]));

                        int result = cmd.ExecuteNonQuery();
                        if (result <= 0)
                        {
                            errMessage = result < 0 ? "Problemas con saldo, vuelva a intentarlo" : "No se pudo insertar";
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
            finally
            {
                conn.Close();
            }
        }

        public bool ActualizarSaldoExcesoPlanilla(int idSeguimiento, decimal importeOld, decimal importeAplicado, ref string errMessage)
        {
            const string procedure = "usp_ActualizarImporteExcesoPlanilla";
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(procedure, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                _ = cmd.Parameters.AddWithValue("@ID_SEGUIMIENTO", idSeguimiento);
                _ = cmd.Parameters.AddWithValue("@IMPORTE_OLD", importeOld);
                _ = cmd.Parameters.AddWithValue("@IMPORTE_APLICADO", importeAplicado);
                int result = cmd.ExecuteNonQuery();
                if (result <= 0)
                {
                    errMessage = result < 0 ? "Problemas con saldo, vuelva a intentarlo" : "No se pudo insertar";
                    return false;
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

        public bool ActualizarSaldoExcesoPlanilla(int idSeguimiento, decimal importeOld, decimal importeAplicado, SqlConnection cn, SqlTransaction tr)
        {
            const string procedure = "usp_ActualizarImporteExcesoPlanilla";
            try
            {
                SqlCommand cmd = new SqlCommand(procedure, cn, tr)
                {
                    CommandType = CommandType.StoredProcedure
                };

                _ = cmd.Parameters.AddWithValue("@ID_SEGUIMIENTO", idSeguimiento);
                _ = cmd.Parameters.AddWithValue("@IMPORTE_OLD", importeOld);
                _ = cmd.Parameters.AddWithValue("@IMPORTE_APLICADO", importeAplicado);
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable SeguimientoCobranzaAplicacion(string año, string mes)
        {
            const string procedure = "usp_SeguimientoCobranzaAplicacion";
            SqlCommand cmd = new SqlCommand(procedure, conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            _ = cmd.Parameters.AddWithValue("@FE_AÑO", año);
            _ = cmd.Parameters.AddWithValue("@FE_MES", mes);

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

        public decimal ObtenerImporteTotalSELAPL(int idSeguimiento, Tipo_APL_SALDO apl)
        {
            const string function = "SELECT dbo.fn_ObtenerImporteTotalSELAPLXIdSeguimiento(@ID_SEGUIMIENTO,@TIPO_APL)";
            SqlCommand cmd = new SqlCommand(function, conn)
            {
                CommandType = CommandType.Text
            };

            _ = cmd.Parameters.AddWithValue("@ID_SEGUIMIENTO", idSeguimiento);
            _ = cmd.Parameters.AddWithValue("@TIPO_APL", (int)apl);

            try
            {
                conn.Open();
                return Convert.ToDecimal(cmd.ExecuteScalar());
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

        public DataTable ObtenerDetalleAplicacionSaldos(int idSeguimiento, Tipo_APL_SALDO apl)
        {
            const string procedure = "usp_ObtenerDetalleAplicacionSaldos";
            SqlCommand cmd = new SqlCommand(procedure, conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            _ = cmd.Parameters.AddWithValue("@ID_SEGUIMIENTO", idSeguimiento);
            _ = cmd.Parameters.AddWithValue("@TIPO_APL", (int)apl);

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

        public bool EliminarAplicaciones(DataTable dtAplicaciones, Tipo_APL_SALDO tipo_APL_SALDO)
        {
            const string function = "usp_EliminarAplicaciones";
            try
            {
                conn.Open();
                if (dtAplicaciones != null)
                {
                    foreach (DataRow row in dtAplicaciones.Rows)
                    {
                        SqlCommand cmd = new SqlCommand(function, conn)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        _ = cmd.Parameters.AddWithValue("@ID_SEGUIMIENTO_APL", Convert.ToInt32(row["ID_SEGUIMIENTO_APL"]));
                        _ = cmd.Parameters.AddWithValue("@ID_SEGUIMIENTO_SEL", Convert.ToInt32(row["ID_SEGUIMIENTO_SEL"]));
                        _ = cmd.Parameters.AddWithValue("@TIPO_APL", (int)tipo_APL_SALDO);

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
            finally
            {
                conn.Close();
            }
        }

        public bool EliminarAplicacionesXIdSeguimientoApl(int idSeguimiento, Tipo_APL_SALDO tipo_APL_SALDO)
        {
            const string function = "usp_EliminarAplicacionesXIdSeguimientoApl";
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(function, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                _ = cmd.Parameters.AddWithValue("@ID_SEGUIMIENTO", idSeguimiento);
                _ = cmd.Parameters.AddWithValue("@TIPO_APL", tipo_APL_SALDO);

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

        public bool GrabarReembolsosEntidad(DataTable dtReembolsos, int idSeguimiento, List<planillaCabeceraOtrasDevDsctosTo> lstReembolsosCab,
            List<planillaCabeceraOtrasDevDsctosTo> lstEliminarReembolso)
        {
            try
            {
                if (!Eliminar_T_PLANILLA_OTRAS_DEV_DSCTOS_REE(lstEliminarReembolso))
                    return false;

                if (!Actualizar_I_PLANILLA_OTRAS_DEV_DSCTOS_REE(lstReembolsosCab))
                    return false;

                if (!Actualizar_T_PLANILLA_OTRAS_DEV_DSCTOS_REE(lstReembolsosCab))
                    return false;

                if (!InsertarReembolso_I_PLANILLA_OTRAS_DEV_DSCTOS(lstReembolsosCab))
                    return false;

                if (!InsertarReembolso_T_PLANILLA_OTRAS_DEV_DSCTOS(lstReembolsosCab))
                    return false;

                if (!InsertarReembolsos(dtReembolsos, idSeguimiento, lstReembolsosCab))
                    return false;

                if (lstEliminarReembolso != null)
                {
                    if (!Eliminar_I_PLANILLA_OTRAS_DEV_DSCTOS_REE(lstEliminarReembolso))
                        return false;
                    //if (o is null)
                    //{
                    //    if (!EliminarReembolsoXIdSeguimiento(idSeguimiento))
                    //        return false;
                    //}
                }

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool InsertarReembolsos(DataTable dtReembolsos, int idSeguimiento, List<planillaCabeceraOtrasDevDsctosTo> lstReembolsoCab)
        {
            const string procedure = "usp_InsertarReembolso";
            try
            {
                //if (ObtenerReembolsosIdSeguimiento(idSeguimiento, cn).Rows.Count > 0)
                //{
                //    if (!EliminarReembolsoXIdSeguimiento(idSeguimiento))
                //        return false;
                //}
                _ = EliminarReembolsoXIdSeguimiento(idSeguimiento);
                int io = 0;
                if (dtReembolsos != null)
                {
                    conn.Open();
                    foreach (DataRow row in dtReembolsos.Rows)
                    {
                        SqlCommand cmd = new SqlCommand(procedure, conn)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        _ = cmd.Parameters.AddWithValue("@ID_SEGUIMIENTO", Convert.ToInt32(row["ID_SEGUIMIENTO"]));
                        _ = cmd.Parameters.AddWithValue("@NRO_PLANILLA_DOC", lstReembolsoCab[io].NRO_PLANILLA_DOC);
                        _ = cmd.Parameters.AddWithValue("@FE_AÑO", row["FE_AÑO"].ToString());
                        _ = cmd.Parameters.AddWithValue("@FE_MES", row["FE_MES"].ToString());
                        _ = cmd.Parameters.AddWithValue("@IMPORTE_REEMBOLSO", Convert.ToDecimal(row["IMPORTE"]));
                        _ = cmd.Parameters.AddWithValue("@USUARIO_CREA", row["USUARIO_CREA"].ToString());

                        if (cmd.ExecuteNonQuery() == 0)
                            return false;
                        io += 1;
                    }
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

        private bool EliminarReembolsoXIdSeguimiento(int idSeguimiento)
        {
            const string procedure = "usp_EliminarReembolso";
            try
            {
                SqlCommand cmd = new SqlCommand(procedure, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                _ = cmd.Parameters.AddWithValue("@ID_SEGUIMIENTO", idSeguimiento);

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

        public DataTable ObtenerReembolsosXIdSeguimiento(int idSeguimiento)
        {
            const string function = "SELECT * FROM fn_ObtenerReembolsoXIdSeguimiento(@ID_SEGUIMIENTO)";
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(function, conn)
                {
                    CommandType = CommandType.Text
                };

                _ = cmd.Parameters.AddWithValue("@ID_SEGUIMIENTO", idSeguimiento);

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

        private bool InsertarReembolso_I_PLANILLA_OTRAS_DEV_DSCTOS(List<planillaCabeceraOtrasDevDsctosTo> lstReembolsoCab)
        {
            const string procedure = "SP_INSERTAR_I_PLANILLA_OTRAS_DEV_DSCTOS";
            try
            {
                if (lstReembolsoCab != null)
                {
                    foreach (planillaCabeceraOtrasDevDsctosTo item in lstReembolsoCab)
                    {
                        if (string.IsNullOrEmpty(item.NRO_PLANILLA_DOC))
                        {
                            string COD_DOC = DALTipoDoc.obtieneCodDocInvxTipoDocDAL(new tipoDocInvTo { TIPO_DOC = item.TIPO_PLANILLA_DOC });
                            DataTable dtCorrelativoDoc = DALSerieDocumento.OBTENER_SERIE_NRO_DAL(new serieDocumentosTo { COD_SUCURSAL = item.COD_SUCURSAL, STATUS_DOC = "0", COD_DOC = COD_DOC });
                            string nro_planilla_doc = dtCorrelativoDoc.Rows[0]["SERIE"].ToString() + '-' + dtCorrelativoDoc.Rows[0]["NUMERO"].ToString();
                            //> Asginamos el NRO_PLANILLA_DOC correlativo
                            item.NRO_PLANILLA_DOC = nro_planilla_doc;
                            string message = "";
                            if (!DALSerieDocumento.adicionaNroSerieDAL(new serieDocumentosTo { COD_SUCURSAL = item.COD_SUCURSAL, COD_DOC = COD_DOC, STATUS_DOC = "0", SERIE = dtCorrelativoDoc.Rows[0]["SERIE"].ToString() }, ref message))
                                return false;

                            SqlCommand cmd = new SqlCommand(procedure, conn)
                            {
                                CommandType = CommandType.StoredProcedure
                            };

                            _ = cmd.Parameters.AddWithValue("@NRO_PLANILLA_DOC", item.NRO_PLANILLA_DOC);
                            _ = cmd.Parameters.AddWithValue("@COD_INSTITUCION", item.COD_INSTITUCION);
                            _ = cmd.Parameters.AddWithValue("@COD_CANAL_DSCTO", item.COD_CANAL_DSCTO);
                            _ = cmd.Parameters.AddWithValue("@TIPO_PLANILLA_DOC", item.TIPO_PLANILLA_DOC);
                            _ = cmd.Parameters.AddWithValue("@FE_AÑO", item.FE_AÑO);
                            _ = cmd.Parameters.AddWithValue("@FE_MES", item.FE_MES);
                            _ = cmd.Parameters.AddWithValue("@COD_SUCURSAL", item.COD_SUCURSAL);
                            _ = cmd.Parameters.AddWithValue("@FECHA_PLANILLA_DOC", item.FECHA_PLANILLA_DOC);
                            _ = cmd.Parameters.AddWithValue("@IMPORTE_TOTAL", item.IMPORTE_TOTAL);
                            _ = cmd.Parameters.AddWithValue("@OBSERVACIONES", item.OBSERVACIONES);
                            _ = cmd.Parameters.AddWithValue("@COD_GESTOR", item.COD_GESTOR);
                            _ = cmd.Parameters.AddWithValue("@ORIG_OTRAS_PLLAS", item.ORIG_OTRAS_PLLAS);
                            _ = cmd.Parameters.AddWithValue("@COD_PER", item.COD_PER);
                            _ = cmd.Parameters.AddWithValue("@DESC_PER", item.DESC_PER);
                            _ = cmd.Parameters.AddWithValue("@DNI", item.DNI);
                            _ = cmd.Parameters.AddWithValue("@NRO_CONTRATO", item.NRO_CONTRATO);
                            _ = cmd.Parameters.AddWithValue("@COD_UBICACION", item.COD_UBICACION);
                            _ = cmd.Parameters.AddWithValue("@COD_MOTIVO_NO_DESCONTADO", item.COD_MOTIVO_NO_DESCONTADO);
                            _ = cmd.Parameters.AddWithValue("@COD_PTO_COB", item.COD_PTO_COB);
                            _ = cmd.Parameters.AddWithValue("@COD_AREA_TRABAJO", item.COD_AREA_TRABAJO);
                            _ = cmd.Parameters.AddWithValue("@COD_CREA", item.COD_CREA);

                            if (conn.State == ConnectionState.Closed)
                                conn.Open();
                            if (cmd.ExecuteNonQuery() <= 0)
                                return false;
                            if (conn.State == ConnectionState.Open)
                                conn.Close();
                        }
                    }
                }
                return true;
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

        private bool InsertarReembolso_T_PLANILLA_OTRAS_DEV_DSCTOS(List<planillaCabeceraOtrasDevDsctosTo> lstReembolsoCab)
        {
            const string procedure = "SP_INSERTAR_T_PLANILLA_OTRAS_DEV_DSCTOS";
            try
            {
                if (lstReembolsoCab != null)
                {
                    _ = Eliminar_T_PLANILLA_OTRAS_DEV_DSCTOS_REE(lstReembolsoCab);

                    conn.Open();
                    foreach (planillaCabeceraOtrasDevDsctosTo item in lstReembolsoCab)
                    {
                        SqlCommand cmd = new SqlCommand(procedure, conn)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        _ = cmd.Parameters.AddWithValue("@NRO_PLANILLA_DOC", item.NRO_PLANILLA_DOC);
                        _ = cmd.Parameters.AddWithValue("@NRO_PLANILLA_COB", item.PlanillaDetalleOtrasDevDsctos.NRO_PLANILLA_COB);
                        _ = cmd.Parameters.AddWithValue("@COD_INSTITUCION", item.COD_INSTITUCION);
                        _ = cmd.Parameters.AddWithValue("@COD_CANAL_DSCTO", item.COD_CANAL_DSCTO);
                        _ = cmd.Parameters.AddWithValue("@FE_AÑO", item.FE_AÑO);
                        _ = cmd.Parameters.AddWithValue("@FE_MES", item.FE_MES);
                        _ = cmd.Parameters.AddWithValue("@TIPO_PLANILLA_DOC", item.TIPO_PLANILLA_DOC);
                        _ = cmd.Parameters.AddWithValue("@IMP_DOC", item.PlanillaDetalleOtrasDevDsctos.IMP_DOC);
                        _ = cmd.Parameters.AddWithValue("@IMP_DEV", item.PlanillaDetalleOtrasDevDsctos.IMP_DEV);
                        _ = cmd.Parameters.AddWithValue("@NRO_LETRA", item.PlanillaDetalleOtrasDevDsctos.NRO_LETRA);
                        _ = cmd.Parameters.AddWithValue("@MOTIVO_OTRAS_DEV_DSCTOS", item.PlanillaDetalleOtrasDevDsctos.MOTIVO_OTRAS_DEV_DSCTOS);
                        _ = cmd.Parameters.AddWithValue("@NRO_PLLA_ORIGEN", item.PlanillaDetalleOtrasDevDsctos.NRO_PLLA_ORIGEN);
                        _ = cmd.Parameters.AddWithValue("@TIPO_PLLA_ORIGEN", item.PlanillaDetalleOtrasDevDsctos.TIPO_PLLA_ORIGEN);
                        _ = cmd.Parameters.AddWithValue("@COD_CREA", item.COD_CREA);

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
            finally
            {
                conn.Close();
            }
        }

        private bool Eliminar_I_PLANILLA_OTRAS_DEV_DSCTOS_REE(List<planillaCabeceraOtrasDevDsctosTo> lstEliminarReembolso)
        {
            try
            {
                const string procedure = "SP_ELIMINAR_I_PLANILLA_OTRAS_DEV_DSCTOS_REE";
                if (lstEliminarReembolso != null)
                {
                    conn.Open();
                    foreach (planillaCabeceraOtrasDevDsctosTo item in lstEliminarReembolso)
                    {
                        SqlCommand cmd = new SqlCommand(procedure, conn)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        _ = cmd.Parameters.AddWithValue("@NRO_PLANILLA_DOC", item.NRO_PLANILLA_DOC);
                        _ = cmd.Parameters.AddWithValue("@COD_INSTITUCION", item.COD_INSTITUCION);
                        _ = cmd.Parameters.AddWithValue("@COD_CANAL_DSCTO", item.COD_CANAL_DSCTO);
                        _ = cmd.Parameters.AddWithValue("@FE_AÑO", item.FE_AÑO);
                        _ = cmd.Parameters.AddWithValue("@FE_MES", item.FE_MES);
                        _ = cmd.Parameters.AddWithValue("@TIPO_PLANILLA_DOC", item.TIPO_PLANILLA_DOC);

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
            finally
            {
                conn.Close();
            }
        }

        private bool Eliminar_T_PLANILLA_OTRAS_DEV_DSCTOS_REE(List<planillaCabeceraOtrasDevDsctosTo> lstReembolsoCab)
        {
            try
            {
                const string procedure = "SP_ELIMINAR_T_PLANILLA_OTRAS_DEV_DSCTOS_REE";

                if (lstReembolsoCab != null)
                {
                    conn.Open();
                    foreach (planillaCabeceraOtrasDevDsctosTo item in lstReembolsoCab)
                    {
                        SqlCommand cmd = new SqlCommand(procedure, conn)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        _ = cmd.Parameters.AddWithValue("@NRO_PLANILLA_DOC", item.NRO_PLANILLA_DOC);
                        _ = cmd.Parameters.AddWithValue("@TIPO_PLANILLA_DOC", item.TIPO_PLANILLA_DOC);
                        _ = cmd.Parameters.AddWithValue("@NRO_PLLA_ORIGEN", item.PlanillaDetalleOtrasDevDsctos.NRO_PLLA_ORIGEN);
                        _ = cmd.Parameters.AddWithValue("@TIPO_PLLA_ORIGEN", item.PlanillaDetalleOtrasDevDsctos.TIPO_PLLA_ORIGEN);

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
            finally
            {
                conn.Close();
            }
        }

        private bool Actualizar_I_PLANILLA_OTRAS_DEV_DSCTOS_REE(List<planillaCabeceraOtrasDevDsctosTo> lstReembolsoCab)
        {
            try
            {
                const string procedure = "SP_ACTUALIZAR_I_PLANILLA_OTRAS_DEV_DSCTOS_REE";
                if (lstReembolsoCab != null)
                {
                    conn.Open();
                    foreach (planillaCabeceraOtrasDevDsctosTo item in lstReembolsoCab)
                    {
                        if (!string.IsNullOrEmpty(item.NRO_PLANILLA_DOC))
                        {
                            SqlCommand cmd = new SqlCommand(procedure, conn)
                            {
                                CommandType = CommandType.StoredProcedure
                            };

                            _ = cmd.Parameters.AddWithValue("@NRO_PLANILLA_DOC", item.NRO_PLANILLA_DOC);
                            _ = cmd.Parameters.AddWithValue("@COD_INSTITUCION", item.COD_INSTITUCION);
                            _ = cmd.Parameters.AddWithValue("@COD_CANAL_DSCTO", item.COD_CANAL_DSCTO);
                            _ = cmd.Parameters.AddWithValue("@FE_AÑO", item.FE_AÑO);
                            _ = cmd.Parameters.AddWithValue("@FE_MES", item.FE_MES);
                            _ = cmd.Parameters.AddWithValue("@TIPO_PLANILLA_DOC", item.TIPO_PLANILLA_DOC);
                            _ = cmd.Parameters.AddWithValue("@IMPORTE_TOTAL", item.IMPORTE_TOTAL);

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
            finally
            {
                conn.Close();
            }
        }

        private bool Actualizar_T_PLANILLA_OTRAS_DEV_DSCTOS_REE(List<planillaCabeceraOtrasDevDsctosTo> lstReembolsoCab)
        {
            try
            {
                const string procedure = "SP_ACTUALIZAR_T_PLANILLA_OTRAS_DEV_DSCTOS_REE";
                if (lstReembolsoCab != null)
                {
                    conn.Open();
                    foreach (planillaCabeceraOtrasDevDsctosTo item in lstReembolsoCab)
                    {
                        if (!string.IsNullOrEmpty(item.NRO_PLANILLA_DOC)) //> Verificamos que sean registros existentes
                        {
                            SqlCommand cmd = new SqlCommand(procedure, conn)
                            {
                                CommandType = CommandType.StoredProcedure
                            };

                            _ = cmd.Parameters.AddWithValue("@NRO_PLANILLA_DOC", item.PlanillaDetalleOtrasDevDsctos.NRO_PLANILLA_DOC);
                            _ = cmd.Parameters.AddWithValue("@TIPO_PLANILLA_DOC", item.PlanillaDetalleOtrasDevDsctos.TIPO_PLANILLA_DOC);
                            _ = cmd.Parameters.AddWithValue("@NRO_PLLA_ORIGEN", item.PlanillaDetalleOtrasDevDsctos.NRO_PLLA_ORIGEN);
                            _ = cmd.Parameters.AddWithValue("@TIPO_PLLA_ORIGEN", item.PlanillaDetalleOtrasDevDsctos.TIPO_PLLA_ORIGEN);
                            _ = cmd.Parameters.AddWithValue("@IMPORTE_DEV", item.PlanillaDetalleOtrasDevDsctos.IMP_DEV);

                            if (cmd.ExecuteNonQuery() == 0)
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
            finally
            {
                conn.Close();
            }
        }

        private bool InsertarHistorialSeguiPago(ChequesPlanillaTo cheque, SqlTransaction sqlTran, SqlConnection cn)
        {
            const string procedure = "usp_InsertarHistorialSeguiPago";
            try
            {
                DataTable dt = ObtenerPlanillasPorGrupoTipo(cheque.SeguimientoPlanillaTo.NRO_PLLA_ENV, cheque.SeguimientoPlanillaTo.NRO_PLANILLA, sqlTran, cn);
                if (dt == null || dt.Rows.Count == 0)
                    throw new ArgumentNullException();

                foreach (DataRow row in dt.Rows)
                {
                    SqlCommand cmd = new SqlCommand(procedure, cn, sqlTran)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    _ = cmd.Parameters.AddWithValue("@ID_SEGUIMIENTO", row["ID_SEGUIMIENTO"]);
                    switch (cheque.TIPO_PAGO)
                    {
                        case Tipo_Movimiento_Cheque.Envio:
                            _ = cmd.Parameters.AddWithValue("@ID_PAGO", cheque.EnvioChequeTo.ID_ENVIO);
                            break;
                        case Tipo_Movimiento_Cheque.Recepcion:
                            _ = cmd.Parameters.AddWithValue("@ID_PAGO", cheque.RecepcionChequeTo.ID_RECEPCION);
                            break;
                        case Tipo_Movimiento_Cheque.Deposito:
                            _ = cmd.Parameters.AddWithValue("@ID_PAGO", cheque.DepositoChequeTo.ID_DEPOSITO);
                            break;
                        case Tipo_Movimiento_Cheque.Transferencia:
                            _ = cmd.Parameters.AddWithValue("@ID_PAGO", cheque.TransferenciaSeguiTo.ID_TRANSFERENCIA);
                            break;
                        default:
                            throw new ArgumentException();
                    }
                    _ = cmd.Parameters.AddWithValue("@TIPO_PAGO", cheque.TIPO_ENVIO_CHEQUE);
                    _ = cmd.Parameters.AddWithValue("@USUARIO_CREA", cheque.USUARIO_CREA);
                    if (cmd.ExecuteNonQuery() == 0)
                        return false;
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private DataTable ObtenerPlanillasPorGrupoTipo(string nroPllaEnv, string nroPllaInd, SqlTransaction sqlTransaction, SqlConnection cn)
        {
            const string procedure = "usp_ObtenerPlanillaXGrupoTipo";
            try
            {
                SqlCommand cmd = new SqlCommand(procedure, cn, sqlTransaction)
                {
                    CommandType = CommandType.StoredProcedure
                };

                _ = cmd.Parameters.AddWithValue("@NRO_PLLA_ENV", nroPllaEnv);
                _ = cmd.Parameters.AddWithValue("@NRO_PLLA_IND", nroPllaInd);

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

        private bool EliminarHistorialSeguiPago(ChequesPlanillaTo to, SqlTransaction sqlTran, SqlConnection cn)
        {
            const string procedure = "usp_EliminarHistorialPago";
            try
            {
                DataTable dt = ObtenerPlanillasPorGrupoTipo(to.SeguimientoPlanillaTo.NRO_PLLA_ENV, to.SeguimientoPlanillaTo.NRO_PLANILLA, sqlTran, cn);
                if (dt == null || dt.Rows.Count == 0)
                    throw new ArgumentNullException();

                foreach (DataRow row in dt.Rows)
                {
                    SqlCommand cmd = new SqlCommand(procedure, cn, sqlTran)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    _ = cmd.Parameters.AddWithValue("@ID_SEGUIMIENTO", row["ID_SEGUIMIENTO"]);
                    _ = cmd.Parameters.AddWithValue("@ID_PAGO", to.ID_PAGO);
                    _ = cmd.Parameters.AddWithValue("@TIPO_PAGO", (int)to.TipoOperacionCobranza);
                    if (cmd.ExecuteNonQuery() <= 0)
                        return false;
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable ObtenerPlanillasPendientesCheque(string codPtoCob, string nroPlanillaEnv, int idSeguimiento)
        {
            const string function = "usp_ObtenerPlanillaXPtoCob_SeguiCheque";
            SqlCommand cmd = new SqlCommand(function, conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            _ = cmd.Parameters.AddWithValue("@COD_PTO_COB", codPtoCob);
            _ = cmd.Parameters.AddWithValue("@NRO_PLLA_ENV", nroPlanillaEnv);
            _ = cmd.Parameters.AddWithValue("@ID_SEGUIMIENTO", idSeguimiento);

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

        public DataTable ObtenerRetencionesDeUnDocumento(string nroDocumento)
        {
            const string procedure = "SELECT * FROM fn_ObtenerRetencionesDeUnDocumento(@NRO_DOCUMENTO)";
            SqlCommand cmd = new SqlCommand(procedure, conn)
            {
                CommandType = CommandType.Text
            };

            _ = cmd.Parameters.AddWithValue("@NRO_DOCUMENTO", nroDocumento);

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

        public DataTable ObtenerDatosParaRetencionSinPrePlanilla(string nroContrato, string feAño, string feMes, string nroPlanilla)
        {
            const string procedure = "usp_ObtenerDatosParaRetencionSinPrePlla";
            SqlCommand cmd = new SqlCommand(procedure, conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            _ = cmd.Parameters.AddWithValue("@NRO_CONTRATO", nroContrato);
            _ = cmd.Parameters.AddWithValue("@FE_AÑO", feAño);
            _ = cmd.Parameters.AddWithValue("@FE_MES", feMes);
            _ = cmd.Parameters.AddWithValue("@NRO_PLANILLA", nroPlanilla);

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

        public bool ActualizarDevPctasCobrarRT(DataTable dt)
        {
            const string procedure = "usp_ActualizarDevPctasCobrar";
            try
            {
                int result;
                conn.Open();
                foreach (DataRow row in dt.Rows)
                {
                    if (row["TIPO_PLANILLA_DOC"].ToString() == "RT")
                    {
                        SqlCommand cmd = new SqlCommand(procedure, conn)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        _ = cmd.Parameters.AddWithValue("@NRO_PLANILLA_COB", row["NRO_PLANILLA_COB"]);
                        _ = cmd.Parameters.AddWithValue("@NRO_CONTRATO", row["NRO_CONTRATO"]);
                        _ = cmd.Parameters.AddWithValue("@FE_AÑO", row["FE_AÑO_REF"]);
                        _ = cmd.Parameters.AddWithValue("@FE_MES", row["FE_MES_REF"]);
                        _ = cmd.Parameters.AddWithValue("@TIPO_PLLA_COBRANZA", row["TIPO_PLANILLA_DOC"]);
                        _ = cmd.Parameters.AddWithValue("@IMP_DOC", row["IMP_DOC"]);
                        _ = cmd.Parameters.AddWithValue("@IMP_INI", row["IMPORTE"]);

                        result = cmd.ExecuteNonQuery();
                        if (result == 0 || result > 1)
                            return false;
                    }
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

        public bool ActualizarDevTctasCobrarRT(DataTable dt)
        {
            const string procedure = "usp_ActualizarDevTctasCobrar";
            try
            {
                conn.Open();
                int result;
                foreach (DataRow row in dt.Rows)
                {
                    if (row["TIPO_PLANILLA_DOC"].ToString() == "RT")
                    {
                        SqlCommand cmd = new SqlCommand(procedure, conn)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        _ = cmd.Parameters.AddWithValue("@NRO_PLANILLA_COB", row["NRO_PLANILLA_COB"]);
                        _ = cmd.Parameters.AddWithValue("@NRO_CONTRATO", row["NRO_CONTRATO"]);
                        _ = cmd.Parameters.AddWithValue("@FE_AÑO", row["FE_AÑO_REF"]);
                        _ = cmd.Parameters.AddWithValue("@FE_MES", row["FE_MES_REF"]);
                        _ = cmd.Parameters.AddWithValue("@TIPO_PLLA_COBRANZA", row["TIPO_PLANILLA_DOC"]);
                        _ = cmd.Parameters.AddWithValue("@IMP_DOC", row["IMP_DOC"]);

                        result = cmd.ExecuteNonQuery();
                        if (result == 0 || result > 1)
                            return false;
                    }
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

        public bool ActualizarOtrosImportesRPlanilla(int idSeguimiento, decimal importeAjuste)
        {
            const string procedure = "usp_ActualizarOtrosImportesRPlanilla";
            try
            {
                conn.Open();
                int result;
                SqlCommand cmd = new SqlCommand(procedure, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                _ = cmd.Parameters.AddWithValue("@ID_SEGUIMIENTO", idSeguimiento);
                _ = cmd.Parameters.AddWithValue("@IMPORTE_AJUSTE", importeAjuste);

                result = cmd.ExecuteNonQuery();
                if (result <= 0 || result > 1)
                    return false;
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

        public bool ActualizarRetencionSeguimientoPlanilla(DataTable dtRetencion)
        {
            string query;
            try
            {
                bool result = true;
                conn.Open();
                foreach (DataRow row in dtRetencion.Rows)
                {
                    query = "UPDATE SEGUIMIENTO_PLANILLA SET IMPORTE_RETENIDO = (SELECT ISNULL(SUM(IMP_RETENIDO),0) FROM RETENCION_CHEQUE_SEGUI WHERE ID_SEGUIMIENTO = @ID_SEGUIMIENTO) WHERE ID_SEGUIMIENTO = @ID_SEGUIMIENTO";
                    SqlCommand cmd = new SqlCommand(query, conn)
                    {
                        CommandType = CommandType.Text
                    };

                    _ = cmd.Parameters.AddWithValue("@ID_SEGUIMIENTO", row["ID_SEGUIMIENTO"]);

                    if (cmd.ExecuteNonQuery() == 0)
                    {
                        result = false;
                        break;
                    }
                }
                return result;
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

        public bool ActualizarImpRetencionRPlanilla(DataTable dtRetencion)
        {
            const string procedure = "usp_ActualizarImpRetencionRPlanilla";
            try
            {
                int result;
                conn.Open();
                foreach (DataRow row in dtRetencion.Rows)
                {
                    SqlCommand cmd = new SqlCommand(procedure, conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    _ = cmd.Parameters.AddWithValue("@ID_SEGUIMIENTO", row["ID_SEGUIMIENTO"]);
                    _ = cmd.Parameters.AddWithValue("@IMPORTE_RETENCION", Convert.ToDecimal(row["IMP_RETENCION"]));

                    result = cmd.ExecuteNonQuery();
                    if (result <= 0 || result > 1)
                        return false;
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

        public bool ValidarExistenciaPlanillaDEV_PCTAS_COBRAR(string nroPlanillaCob, string codSucursal, string codClase, string nroContrato, string feAño, string feMes)
        {
            const string function = "SELECT dbo.fn_ValidarExistenciaPlanilla_DEV_PCTAS_COBRAR(@NRO_PLANILLA_COB,@COD_SUCURSAL,@COD_CLASE,@NRO_CONTRATO,@FE_AÑO,@FE_MES)";
            try
            {
                SqlCommand cmd = new SqlCommand(function, conn)
                {
                    CommandType = CommandType.Text
                };

                _ = cmd.Parameters.AddWithValue("@NRO_PLANILLA_COB", nroPlanillaCob);
                _ = cmd.Parameters.AddWithValue("@COD_SUCURSAL", codSucursal);
                _ = cmd.Parameters.AddWithValue("@COD_CLASE", codClase);
                _ = cmd.Parameters.AddWithValue("@NRO_CONTRATO", nroContrato);
                _ = cmd.Parameters.AddWithValue("@FE_AÑO", feAño);
                _ = cmd.Parameters.AddWithValue("@FE_MES", feMes);

                conn.Open();
                return Convert.ToBoolean(cmd.ExecuteScalar());
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

        public bool EliminarDevPctasTctasCobrar(DataTable dt)
        {
            const string procedure = "dsp_EliminarDevolucionesCabDet";
            try
            {
                conn.Open();
                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["TIPO_PLANILLA"].ToString() == "RT")
                        {
                            SqlCommand cmd = new SqlCommand(procedure, conn)
                            {
                                CommandType = CommandType.StoredProcedure
                            };

                            _ = cmd.Parameters.AddWithValue("@NRO_PLANILLA_COB", row["NRO_PLANILLA_COB"]);
                            _ = cmd.Parameters.AddWithValue("@COD_SUCURSAL", row["COD_SUCURSAL"]);
                            _ = cmd.Parameters.AddWithValue("@COD_CLASE", row["COD_CLASE"]);
                            _ = cmd.Parameters.AddWithValue("@NRO_CONTRATO", row["NRO_CONTRATO"]);
                            _ = cmd.Parameters.AddWithValue("@FE_AÑO", row["FE_AÑO_REF"]);
                            _ = cmd.Parameters.AddWithValue("@FE_MES", row["FE_MES_REF"]);
                            _ = cmd.Parameters.AddWithValue("@TIPO_PLANILLA", row["TIPO_PLANILLA"]);

                            if (cmd.ExecuteNonQuery() == 0)
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
            finally
            {
                conn.Close();
            }
        }

        private bool ActualizarSaldoXCobrarYImporteExceso(SeguimientoPlanillaTo se, SqlTransaction sqlTransac)
        {
            const string procedure = "dsp_ActualizarImportesSeguimientoPlanilla";
            try
            {
                SqlCommand cmd = new SqlCommand(procedure, conn, sqlTransac)
                {
                    CommandType = CommandType.StoredProcedure
                };

                _ = cmd.Parameters.AddWithValue("@ID_SEGUIMIENTO", se.ID_SEGUIMIENTO);
                _ = cmd.Parameters.AddWithValue("@IMPORTE_EXC_INI", se.IMPORTE_EXC_INI);
                _ = cmd.Parameters.AddWithValue("@IMPORTE_EXC_DOC", se.IMPORTE_EXC_DOC);
                _ = cmd.Parameters.AddWithValue("@IMPORTE_COBRADO", se.IMPORTE_VERIFICADO);
                _ = cmd.Parameters.AddWithValue("@SALDO_X_COBRAR", se.SALDO_X_COBRAR);

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable ResumenSeguimientoCheque(string fe_año, string fe_mes, string codPais)
        {
            const string procedure = "dsp_ListaResumenSeguimientoCheques";
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

        public DataTable RptResumenSeguimientoCheque(string codPrograma, string codPtoCob, string fe_año, string fe_mes)
        {
            const string procedure = "dsp_RptSeguimientoCheques";
            SqlCommand cmd = new SqlCommand(procedure, conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            _ = cmd.Parameters.AddWithValue("@FE_AÑO", fe_año);
            _ = cmd.Parameters.AddWithValue("@FE_MES", fe_mes);
            _ = cmd.Parameters.AddWithValue("@COD_PROGRAMA", codPrograma);
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

        public bool VerificarPlanillaCerrada(int idSeguimiento)
        {
            string select = string.Format("SELECT FECHA_CIERRE_COBRANZA FROM SEGUIMIENTO_PLANILLA WHERE ID_SEGUIMIENTO = {0}", idSeguimiento);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(select, conn)
                {
                    CommandType = CommandType.Text
                };

                _ = cmd.Parameters.AddWithValue("@ID_SEGUIMIENTO", idSeguimiento);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    return !string.IsNullOrEmpty(dr["FECHA_CIERRE_COBRANZA"]?.ToString());
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

        public bool ActualizarImporteAplicadoDeposito(ChequesPlanillaTo to, SqlConnection cn, SqlTransaction tr)
        {
            try
            {
                const string sentence = "UPDATE CHEQUE_DEPOSITO_SEGUI SET IMPORTE = @IMPORTE, FECHA_VERIFICADO = GETDATE(), IMPORTE_VERIFICADO = @IMPORTE_VERIFICADO," +
                                        "IMPORTE_PROPIO_PLLA = @IMPORTE_PROPIO_PLLA " +
                                        "WHERE ID_DEPOSITO = @ID_DEPOSITO AND FL_GEN_APL = 1";
                using (SqlCommand cmd = new SqlCommand(sentence, cn, tr))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add("@IMPORTE", SqlDbType.Decimal).Value = to.DepositoChequeTo.IMPORTE;
                    cmd.Parameters.Add("@IMPORTE_VERIFICADO", SqlDbType.Decimal).Value = to.DepositoChequeTo.IMPORTE;
                    cmd.Parameters.Add("@IMPORTE_PROPIO_PLLA", SqlDbType.Decimal).Value = to.DepositoChequeTo.IMPORTE;
                    cmd.Parameters.Add("@ID_DEPOSITO", SqlDbType.Decimal).Value = to.DepositoChequeTo.ID_DEPOSITO;

                    if (cmd.ExecuteNonQuery() > 0)
                        return ActualizarSaldoXCobrarYImporteExceso(to.SeguimientoPlanillaTo, cn, tr);
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Verificamos si el depósito se encuentra ya registrdo en tesoreria. 
        /// Retorna true si esta reistrado, de lo contratio false
        /// </summary>
        /// <param name="idDeposito"></param>
        /// <returns></returns>
        public bool VerificarSiDepositoRegistradoTesoreria(int idDeposito)
        {
            try
            {
                const string sentence = "SELECT '' FROM MOVIMIENTOS_CHEQUE WHERE ID_DEPOSITO = @ID_DEPOSITO";
                using (SqlCommand cmd = new SqlCommand(sentence, conn))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add("@ID_DEPOSITO", SqlDbType.Decimal).Value = idDeposito;
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


        public string VerificarSiVerificarDevoluciones(int ID_SEGUIMIENTO, int ID_PAGO, string TIPO_PAGO)
        {
            try
            {
                const string sentence = "SELECT cast(ID_DEVOLUCION_EXC as varchar) + '-' + cast(IMPORTE_DEVOLVER_ENTIDAD as varchar)  FROM DEVOLUCION_EXCESO_ENTIDAD WHERE ID_SEGUIMIENTO = @ID_SEGUIMIENTO and ID_PAGO = @ID_PAGO and TIPO_PAGO = @TIPO_PAGO";
                using (SqlCommand cmd = new SqlCommand(sentence, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("@ID_SEGUIMIENTO", SqlDbType.Int).Value = ID_SEGUIMIENTO;
                    cmd.Parameters.Add("@ID_PAGO", SqlDbType.Int).Value = ID_PAGO;
                    cmd.Parameters.Add("@TIPO_PAGO", SqlDbType.Char).Value = TIPO_PAGO;

                    conn.Open();
                    var result = cmd.ExecuteScalar();
                    //return int.TryParse(result?.ToString(), out int id) ? id : 0;
                    return result == null ? "" : result.ToString();
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
        /// Obtiene el idSeguimiento seleccionado (Planilla que tiene el exceso), mediante el [ID_ENVIO_APL], [TIPO_ENVIO_APL] y [ID_SEGUIMIENTO_APL]
        /// </summary>
        /// <param name="to"></param>
        /// <param name="cn"></param>
        /// <param name="tr"></param>
        /// <returns></returns>
        public int ObtenerIdSeguimientoSel(ChequesPlanillaTo to, SqlConnection cn, SqlTransaction tr)
        {
            const string sentencia = "SELECT ID_SEGUIMIENTO_SEL FROM SALDO_APLICA_PLANILLA WHERE ID_ENVIO_APL = @ID_ENVIO_APL AND TIPO_ENVIO_APL = @TIPO_ENVIO_APL AND ID_SEGUIMIENTO_APL = @ID_SEGUIMIENTO_APL";
            try
            {
                using (SqlCommand cmd = new SqlCommand(sentencia, cn, tr))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add("@ID_ENVIO_APL", SqlDbType.Int).Value = to.ID_PAGO;
                    cmd.Parameters.Add("@TIPO_ENVIO_APL", SqlDbType.Char).Value = to.TIPO_PAGO_TXT;
                    cmd.Parameters.Add("@ID_SEGUIMIENTO_APL", SqlDbType.Int).Value = to.SeguimientoPlanillaTo.ID_SEGUIMIENTO;
                    var result = cmd.ExecuteScalar();
                    return int.TryParse(result?.ToString(), out int id) ? id : 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
