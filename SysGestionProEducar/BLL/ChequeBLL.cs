using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Transactions;

namespace BLL
{
    public class ChequeBLL
    {
        private readonly ChequeDAL DALCheque = new ChequeDAL();
        private readonly planillaCabeceraOtrasDevDsctosBLL BLPlanillaCabecera = new planillaCabeceraOtrasDevDsctosBLL();
        private readonly tipoDocInvBLL tdiBLL = new tipoDocInvBLL();
        private readonly devPCtasCobrarBLL BLDevPcTasCobrar = new devPCtasCobrarBLL();
        private readonly devTCtasCobrarBLL BLDevTcTasCobrar = new devTCtasCobrarBLL();

        public const string TIPO_PLLA_RETENCION = "RT";

        public DataTable ObtenerEnvioChequeXIdSeguimiento(int idSeguimiento, int idEnvio)
        {
            return DALCheque.ObtenerEnvioChequeXIdSeguimiento(idSeguimiento, idEnvio);
        }

        public DataTable ObtenerRecepcionChequeXIdSeguimiento(int idSeguimiento, int idEnvio)
        {
            return DALCheque.ObtenerRecepcionChequeXIdSeguimiento(idSeguimiento, idEnvio);
        }

        /// <summary>
        /// Obtiene el depósito de una planilla por ID_SEGUIMIENTO y ID_ENVIO(Id del depósito)
        /// </summary>
        /// <param name="idSeguimiento"></param>
        /// <param name="idEnvio"></param>
        /// <returns></returns>
        public DataTable ObtenerDespositoChequeXIdSeguimiento(int idSeguimiento, int idEnvio)
        {
            return DALCheque.ObtenerDespositoChequeXIdSeguimiento(idSeguimiento, idEnvio);
        }

        public DataTable ObtenerTransChequeXIdSeguimiento(int idSeguimiento, int idTransferencia)
        {
            return DALCheque.ObtenerTransChequeXIdSeguimiento(idSeguimiento, idTransferencia);
        }

        public DataTable ListarPlanillasPendientesCheque(string codPtoCob)
        {
            return DALCheque.ListarPlanillasPendientesCheque(codPtoCob);
        }

        public DataTable ListarPlanillasPendientesChequeCerrados(string codPtoCob)
        {
            return DALCheque.ListarPlanillasPendientesChequeCerrados(codPtoCob);
        }

        public bool RegistrarChequePlanilla(ChequesPlanillaTo cheque, Tipo_Movimiento_Cheque tipo)
        {
            return DALCheque.RegistrarChequePlanilla(cheque, tipo);
        }

        public bool EliminarCheque(ChequesPlanillaTo cheque)
        {
            return DALCheque.EliminarCheque(cheque);
        }

        public bool AprobarTransferenciaSegui(ChequesPlanillaTo to, bool acces)
        {
            return DALCheque.AprobarTransferenciaSegui(to, acces);
        }



        public bool ActualizarTransferenciaCheque(ChequesPlanillaTo cheque)
        {
            return DALCheque.ActualizarTransferenciaCheque(cheque);
        }

        public bool ActualizarChequeTransporteCourier(ChequesPlanillaTo cheque)
        {
            return DALCheque.ActualizarChequeTransporteCourier(cheque);
        }

        public bool ActualizarChequeDeposito(ChequesPlanillaTo cheque)
        {
            return DALCheque.ActualizarChequeDeposito(cheque);
        }

        public bool AprobarChequeDeposito(ChequesPlanillaTo cheque, bool acces)
        {
            return DALCheque.AprobarChequeDeposito(cheque, acces);
        }

        public DataTable ListarSeguimientoCheque(string año, string mes)
        {
            return DALCheque.ListarSeguimientoCheque(año, mes);
        }

        public DataTable ListarSeguimientoChequeXIdSeguimiento(int idSeguimiento)
        {
            return DALCheque.ListarSeguimientoChequeXIdSeguimiento(idSeguimiento);
        }

        public DataTable ListarClientesPllDscto(string codPtoCob)
        {
            return DALCheque.ListarClientesPllDscto(codPtoCob);
        }

        public DataTable ObtenerContratosXCodPer(string codPer)
        {
            return DALCheque.ObtenerContratosXCodPer(codPer);
        }

        public bool InsertarPlanillasOtrasDevDsctosBLL(int idSeguimiento, string usuario, decimal importeReembolso, decimal importeRetenido, decimal importeAjuste,
            decimal importeVerificado, decimal saldoXCobrar, decimal importeExceso, bool eSCierre,
            List<planillaCabeceraOtrasDevDsctosTo> lstPlcTo, List<devPCtasCobrarTo> lstDevPctasCobrar, List<devTCtasCobrarTo> lstDevTctasCobrar, DataTable dtDetalle, DataTable dtEliminar, List<planillaCabeceraOtrasDevDsctosTo> lstPlanillasEliminadas,
            DataTable dtAplicacionesEliminar, DataTable dtReembolso, List<planillaCabeceraOtrasDevDsctosTo> lstReembolsosCab, List<planillaCabeceraOtrasDevDsctosTo> lstEliminarReembolso, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions
            {
                IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted,
                Timeout = new TimeSpan(0, 2, 0)
            };
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                /*if (DALCheque.VerificarPlanillaCerrada(idSeguimiento))
                {
                    errMensaje = "Esta planilla ya fue cerrado por otro usuario";
                    return false;
                }*/

                Tipo_APL_SALDO tipo_APL_SALDO = importeExceso > 0 ? Tipo_APL_SALDO.Planilla_Imp_Exceso : Tipo_APL_SALDO.Planilla_Imp_x_cobrar;

                if (!DALCheque.FinalizarCobranzaPlanillas(idSeguimiento, importeAjuste, importeVerificado, saldoXCobrar, importeExceso, eSCierre))
                    return false;

                if (eSCierre)
                {
                    if (!DALCheque.ActualizarOtrosImportesRPlanilla(idSeguimiento, importeAjuste))
                        return false;

                    if (!DALCheque.ActualizarImpRetencionRPlanilla(dtDetalle))
                        return false;
                }

                if (lstPlanillasEliminadas != null) //> Eliminar
                {
                    foreach (planillaCabeceraOtrasDevDsctosTo item in lstPlanillasEliminadas)
                    {
                        if (!EliminarPlanillaOtrasDevDsctos(item, ref errMensaje))
                            return false;
                    }
                }

                if (dtEliminar != null) //> Eliminamos Retención
                {
                    if (!DALCheque.EliminarRetencion(idSeguimiento, dtEliminar))
                        return false;

                    if (!DALCheque.ActualizarRetencionSeguimientoPlanilla(dtEliminar))
                        return false;

                    if (!DALCheque.EliminarDevPctasTctasCobrar(dtEliminar))
                        return false;
                }

                if (lstDevPctasCobrar != null && lstDevTctasCobrar != null && lstDevPctasCobrar.Count > 0 && lstDevTctasCobrar.Count > 0)
                {
                    foreach (devPCtasCobrarTo item in lstDevPctasCobrar)
                    {
                        if (!BLDevPcTasCobrar.insertarDevPCtasCobrarBLL(item, ref errMensaje))
                            return false;
                    }

                    foreach (devTCtasCobrarTo item in lstDevTctasCobrar)
                    {
                        if (!BLDevTcTasCobrar.insertarDevTCtasCobrarBLL(item, ref errMensaje))
                            return false;
                    }
                }

                int index = 0;
                string COD_DOC;
                string nro_planilla_doc;
                DataTable dt = null;
                DataTable dtCorrelativoDoc, dtParam;
                if (dtDetalle.Select("TAG = '-'").Length > 0)
                    dt = dtDetalle.Select("TAG = '-'").CopyToDataTable(); //> Copiamos solo los registros nuevos
                if (lstPlcTo != null && dt != null) //> Registros nuevos
                {
                    foreach (planillaCabeceraOtrasDevDsctosTo plcTo in lstPlcTo)
                    {
                        //I
                        DataRow[] dtRow = new DataRow[] { dt.Rows[index] };
                        dtParam = dtRow.CopyToDataTable();
                        //> Obtenermos el Correlativo

                        COD_DOC = tdiBLL.obtieneCodDocInvxTipoDocBLL(new tipoDocInvTo { TIPO_DOC = dtRow[0]["TIPO_PLANILLA_DOC"].ToString() });
                        dtCorrelativoDoc = HelpersBLL.obtieneNroPlanilla(dtRow[0]["COD_SUCURSAL"].ToString(), "0", COD_DOC);
                        if (dtCorrelativoDoc.Rows.Count == 0)
                            throw new ArgumentNullException("No hay correlativo para este documento");
                        nro_planilla_doc = dtCorrelativoDoc.Rows[0]["SERIE"].ToString() + '-' + dtCorrelativoDoc.Rows[0]["NUMERO"].ToString();
                        //> Asginamos el NRO_PLANILLA_DOC correlativo
                        dtParam.Rows[0]["NRO_PLANILLA_DOC"] = nro_planilla_doc;
                        plcTo.NRO_PLANILLA_DOC = nro_planilla_doc;
                        plcTo.COD_DOC = COD_DOC;

                        //> Al importe total lo pasamos el valor del importe retenido
                        plcTo.IMPORTE_TOTAL = Convert.ToDecimal(dtParam.Rows[0]["IMP_RETENCION"]);

                        if (!DALCheque.InsertarRetencion(usuario, dtParam))
                            return false;

                        if (!DALCheque.ActualizarRetencionSeguimientoPlanilla(dtParam))
                            return false;

                        if (!BLPlanillaCabecera.insertarPlanillaCabeceraOtrasDevDsctosBLL(plcTo, ref errMensaje))
                            return false;
                        //T
                        if (!BLPlanillaCabecera.ingresarPlanillaDetalleOtrasDevDsctosBLL(plcTo, dtParam, ref errMensaje))
                            return false;
                        //adiciona en uno el contador
                        if (!HelpersBLL.estableceNuevoNumeroContador(plcTo.COD_SUCURSAL, plcTo.COD_DOC, plcTo.STATUS_DOC, plcTo.SERIE, ref errMensaje))
                            return false;
                        //if (plcTo.TIPO_PLANILLA_DOC != "PD")//si es directa es que no ha venido de un ingreso de otras dev y dsctos
                        //{
                        //    //actualiza DEV_PCTAS_COBRAR, status_generado=1
                        //    //> plcTo.TIPO_PLANILLA_DOC = plcTo.TIPO_PLANILLA_ORI;
                        //    if (!BLPlanillaCabecera.actualizaDevPCtasBLL(plcTo, dtParam, ref errMensaje))
                        //        return false;
                        //}
                        index += 1;
                    }
                }

                DataTable dtUpdate = null;
                if (dtDetalle.Select("TAG = '*'").Length > 0)
                    dtUpdate = dtDetalle.Select("TAG = '*'").CopyToDataTable(); //> Copiamos solo los registros existentes
                if (dtUpdate != null) //> Registros Existentes
                {
                    if (!DALCheque.ActualizarPlanillaCabeceraOtrasDevDscto(dtUpdate)) //> Actualizamos solo la cabecera
                        return false;

                    if (!DALCheque.ActualizarPlanillaDetalleOtrasDevDscto(dtUpdate))
                        return false;

                    if (!DALCheque.ActualizarRetencion(dtUpdate)) //> Actualizamos la retención
                        return false;

                    if (!DALCheque.ActualizarRetencionSeguimientoPlanilla(dtUpdate))
                        return false;

                    if (!DALCheque.ActualizarDevPctasCobrarRT(dtUpdate))
                        return false;

                    if (!DALCheque.ActualizarDevTctasCobrarRT(dtUpdate))
                        return false;
                }

                if (!DALCheque.EliminarAplicaciones(dtAplicacionesEliminar, tipo_APL_SALDO))
                    return false;

                if (!DALCheque.GrabarReembolsosEntidad(dtReembolso, idSeguimiento, lstReembolsosCab, lstEliminarReembolso))
                    return false;

                if (!DALCheque.ActualizarSaldoExcesoPlanilla(idSeguimiento, 0, importeReembolso, ref errMensaje))
                    return false;

                ts.Complete();
                return true;
            }
        }

        private bool EliminarPlanillaOtrasDevDsctos(planillaCabeceraOtrasDevDsctosTo plcTo, ref string errMensaje)
        {
            if (!BLPlanillaCabecera.eliminarPlanillaCabeceraOtrasDevDsctosBLL(plcTo, ref errMensaje))
                return false;
            //T
            if (!BLPlanillaCabecera.eliminarPlanillaDetalleOtrasDevDsctosBLL(plcTo, ref errMensaje))
                return false;
            if (plcTo.TIPO_PLANILLA_DOC != "PD")
            {
                //Actualiza DEV_PCTAS_COBRAR
                //> plcTo.TIPO_PLANILLA_DOC = plcTo.TIPO_PLANILLA_ORI;
                //if (!BLPlanillaCabecera.actualizaDevPctasCobrarxEliminacionPllaBLL(plcTo, ref errMensaje))
                //    return false;
                //Elimina DEV_TCTAS_COBRAR
                //if (!BLPlanillaCabecera.eliminaDevTctasCobrarxEliminacionPllaBLL(plcTo, ref errMensaje))
                //    return false;
            }
            return true;
        }

        public DataTable ObtenerDatosCierreCobrazaPlla(string nroPlanillaEnv, string nroPlanilla, string entPagChe)
        {
            return DALCheque.ObtenerDatosCierreCobrazaPlla(nroPlanillaEnv, nroPlanilla, entPagChe);
        }

        public DataTable ListarLlamdasPendientesCheque()
        {
            return DALCheque.ListarLlamdasPendientesCheque();
        }

        public bool EliminarCobranzaPlanilla(ChequesPlanillaTo to)
        {
            using (SqlConnection cn = new SqlConnection(conexion.con))
            {
                cn.Open();
                SqlTransaction tr = cn.BeginTransaction();
                try
                {
                    if (!DALCheque.EliminarCobranzaPlanilla(to, cn, tr))
                    {
                        tr.Rollback();
                        return false;
                    }

                    if (to.FL_GEN_APL)
                    {
                        if (!ActualizarExcesoPllaSel(to, cn, tr))
                        {
                            tr.Rollback();
                            return false;
                        }

                        if (!DALCheque.EliminarAplicacionOtrasPlanillas(to, cn, tr))
                        {
                            tr.Rollback();
                            return false;
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
            }
        }

        private bool ActualizarExcesoPllaSel(ChequesPlanillaTo to, SqlConnection cn, SqlTransaction tr)
        {
            int idSeguimientoSel = DALCheque.ObtenerIdSeguimientoSel(to, cn, tr);
            return DALCheque.ActualizarSaldoExcesoPlanilla(idSeguimientoSel, to.DepositoChequeTo.IMPORTE, 0, cn, tr);
        }

        public DataTable ListarPlanillasDsctosPendienteXCodPtoCob(string codPtoCob)
        {
            return DALCheque.ListarPlanillasDsctosPendienteXCodPtoCob(codPtoCob);
        }

        public DataTable ListarPlanillasDsctosPendienteXCodPtoCobRetencion(string codPtoCob, string nroPlanillaCob, string feAño, string feMes, string tipoPlanilla)
        {
            return DALCheque.ListarPlanillasDsctosPendienteXCodPtoCobRetencion(codPtoCob, nroPlanillaCob, feAño, feMes, tipoPlanilla);
        }

        public decimal ObtenerTotalRetencion(string nroPlanillaCob, string codInstitucion, string codCanalDscto, string codSucursal,
            string codPer, string nroContrato)
        {
            return DALCheque.ObtenerTotalRetencion(nroPlanillaCob, codInstitucion, codCanalDscto, codSucursal, codPer, nroContrato);
        }

        public DataTable ListarPlanillasExcCobranzaAplicar(string codPtoCob)
        {
            return DALCheque.ListarPlanillasExcCobranzaAplicar(codPtoCob);
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
            return DALCheque.ListarPlanillasSaldoXCobrarAplicar(codPtoCob, idSeguimiento);
        }

        public DataTable ObtenerPlanillasAplicEnvio(int idSeguimiento)
        {
            return DALCheque.ObtenerPlanillasAplicEnvio(idSeguimiento);
        }
        public DataTable ListarDetalleDevoluciones(int ID_SEGUIMIENTO, int ID_PAGO)
        {
            return DALCheque.ListarDetalleDevoluciones(ID_SEGUIMIENTO, ID_PAGO);
        }
        public DataTable ObtenerPlanillasAplicRecibo(int idSeguimiento)
        {
            return DALCheque.ObtenerPlanillasAplicRecibo(idSeguimiento);
        }

        public decimal ObtenerTotalAplicado(int idSeguimiento)
        {
            return DALCheque.ObtenerTotalAplicado(idSeguimiento);
        }

        public DataTable SeguimientoCobranzaAplicacion(string año, string mes)
        {
            return DALCheque.SeguimientoCobranzaAplicacion(año, mes);
        }

        public decimal ObtenerImporteTotalSELAPL(int idSeguimiento, Tipo_APL_SALDO apl)
        {
            return DALCheque.ObtenerImporteTotalSELAPL(idSeguimiento, apl);
        }

        public DataTable ObtenerDetalleAplicacionSaldos(int idSeguimiento, Tipo_APL_SALDO apl)
        {
            return DALCheque.ObtenerDetalleAplicacionSaldos(idSeguimiento, apl);
        }

        public DataTable ObtenerReembolsosXIdSeguimiento(int idSeguimiento)
        {
            return DALCheque.ObtenerReembolsosXIdSeguimiento(idSeguimiento);
        }

        public DataTable ObtenerPlanillasPendientesCheque(string codPtoCob, string nroPlanillaEnv, int idSeguimiento)
        {
            return DALCheque.ObtenerPlanillasPendientesCheque(codPtoCob, nroPlanillaEnv, idSeguimiento);
        }

        public DataTable ObtenerRetencionesDeUnDocumento(string nroDocumento)
        {
            return DALCheque.ObtenerRetencionesDeUnDocumento(nroDocumento);
        }

        public DataTable ObtenerDatosParaRetencionSinPrePlanilla(string nroContrato, string feAño, string feMes, string nroPlanilla)
        {
            return DALCheque.ObtenerDatosParaRetencionSinPrePlanilla(nroContrato, feAño, feMes, nroPlanilla);
        }

        public bool ValidarExistenciaPlanillaDEV_PCTAS_COBRAR(string nroPlanillaCob, string codSucursal, string codClase, string nroContrato, string feAño, string feMes)
        {
            return DALCheque.ValidarExistenciaPlanillaDEV_PCTAS_COBRAR(nroPlanillaCob, codSucursal, codClase, nroContrato, feAño, feMes);
        }

        public DataTable ResumenSeguimientoCheque(string feAño, string feMes, string codPais)
        {
            return DALCheque.ResumenSeguimientoCheque(feAño, feMes, codPais);
        }

        public DataTable RptResumenSeguimientoCheque(string codPrograma, string codPtoCob, string feAño, string feMes)
        {
            return DALCheque.RptResumenSeguimientoCheque(codPrograma, codPtoCob, feAño, feMes);
        }

        /// <summary>
        /// Registra un depósito para las planillas que tienen saldo por cobrar, a partir de planillas que tienen exceso(pagos de más).
        /// Además, genera un registro de aplicación de excesos de pago
        /// </summary>
        /// <returns></returns>
        public bool GrabarAplicacionExcesoOtrasPlanillas(List<ChequesPlanillaTo> listaRegistrar, List<ChequesPlanillaTo> listaActualizar, DataTable dtAplicacionReg,
            DataTable dtAplicacionAct, SeguimientoPlanillaTo se)
        {
            using (SqlConnection cn = new SqlConnection(conexion.con))
            {
                cn.Open();
                SqlTransaction tr = cn.BeginTransaction();
                try
                {
                    if (!InsertarDepositoCheque(listaRegistrar, tr, cn))
                    {
                        tr.Rollback();
                        return false;
                    }

                    if (!RegistrarAplicacionExcesoOtrasPllas(dtAplicacionReg, listaRegistrar, tr, cn))
                    {
                        tr.Rollback();
                        return false;
                    }

                    if (!AprobarChequeDeposito(listaRegistrar, tr, cn))
                    {
                        tr.Rollback();
                        return false;
                    }

                    if (!DALCheque.ActualizarSaldoXCobrarYImporteExceso(se, cn, tr))
                    {
                        tr.Rollback();
                        return false;
                    }

                    if (!ActualizarDepositoCheque(listaActualizar, tr, cn))
                    {
                        tr.Rollback();
                        return false;
                    }

                    if (!ActualizarAplicacionExcesoOtrasPllas(dtAplicacionAct, tr, cn))
                    {
                        tr.Rollback();
                        return false;
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
            }
        }





        public bool ActualizaDevolucionDepositoPlla(List<DevolucionExcesoEntidad> listaRegistrar)
        {
            using (SqlConnection cn = new SqlConnection(conexion.con))
            {
                cn.Open();
                SqlTransaction tr = cn.BeginTransaction();
                try
                {
                    if (!ActualizaDevolucionDepositoPlla(listaRegistrar, tr, cn))
                    {
                        tr.Rollback();
                        return false;
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
            }
        }



        public bool GrabarDevolucionDepositoPlla(List<DevolucionExcesoEntidad> listaRegistrar, DataTable dtDetDevolucionReg)
        {
            using (SqlConnection cn = new SqlConnection(conexion.con))
            {
                cn.Open();
                SqlTransaction tr = cn.BeginTransaction();
                try
                {
                    if (!InsertarDevolucionExcesoCab(listaRegistrar, dtDetDevolucionReg, tr, cn))
                    {
                        tr.Rollback();
                        return false;
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
            }
        }

        private bool InsertarDepositoCheque(List<ChequesPlanillaTo> lista, SqlTransaction tr, SqlConnection cn)
        {
            foreach (ChequesPlanillaTo item in lista)
            {
                if (!DALCheque.InsertarDepositoCheque(item, tr, cn))
                    return false;
            }
            return true;
        }

        private bool ActualizaDevolucionDepositoPlla(List<DevolucionExcesoEntidad> lista, SqlTransaction tr, SqlConnection cn)
        {
            foreach (DevolucionExcesoEntidad item in lista)
            {
                if (!DALCheque.ActualizaDevolucionExcesoEntCab(item, tr, cn))
                    return false;
            }
            return true;
        }

        private bool InsertarDevolucionExcesoCab(List<DevolucionExcesoEntidad> lista, DataTable dtDevolReg, SqlTransaction tr, SqlConnection cn)
        {
            foreach (DevolucionExcesoEntidad item in lista)
            {
                if (!DALCheque.InsertarDevolucionExcesoEntCab(item, dtDevolReg, tr, cn))
                    return false;
            }
            return true;
        }
        private bool RegistrarAplicacionExcesoOtrasPllas(DataTable dtAplicacionReg, List<ChequesPlanillaTo> lista, SqlTransaction tr, SqlConnection cn)
        {
            for (int i = 0; i < lista.Count; i++)
            {
                dtAplicacionReg.Rows[i]["ID_ENVIO_APL"] = lista[i].DepositoChequeTo.ID_DEPOSITO;
            }
            if (!DALCheque.InsertarSaldoAplicaPlanilla(dtAplicacionReg, tr, cn))
                return false;
            return true;
        }

        private bool AprobarChequeDeposito(List<ChequesPlanillaTo> lista, SqlTransaction tr, SqlConnection cn)
        {
            foreach (ChequesPlanillaTo item in lista)
            {
                if (item.TIPO_PAGO == Tipo_Movimiento_Cheque.Deposito)
                {
                    if (!DALCheque.AprobarChequeDeposito(item, true, cn, tr))
                        return false;
                }
                else if (item.TIPO_PAGO == Tipo_Movimiento_Cheque.Transferencia)
                {
                    if (!DALCheque.AprobarChequeDeposito(item, true, cn, tr))
                        return false;
                }
                else return false;
            }
            return true;
        }

        private bool ActualizarDepositoCheque(List<ChequesPlanillaTo> lista, SqlTransaction tr, SqlConnection cn)
        {
            foreach (ChequesPlanillaTo item in lista)
            {
                if (!DALCheque.ActualizarImporteAplicadoDeposito(item, cn, tr))
                    return false;
            }
            return true;
        }

        private bool ActualizarAplicacionExcesoOtrasPllas(DataTable dtAplicacionAct, SqlTransaction tr, SqlConnection cn)
        {
            if (!DALCheque.ActualizaSaldoAplicaPlanilla(dtAplicacionAct, tr, cn))
                return false;
            return true;
        }

        /// <summary>
        /// Verificamos si el depósito se encuentra ya registrdo en tesoreria. 
        /// Retorna true si esta reistrado, de lo contratio false
        /// </summary>
        /// <param name="idDeposito"></param>
        /// <returns></returns>
        public bool VerificarSiDepositoRegistradoTesoreria(int idDeposito)
        {
            return DALCheque.VerificarSiDepositoRegistradoTesoreria(idDeposito);
        }

        /// <summary>
        /// Verificamos si el depósito se encuentra ya registrdo en tesoreria. 
        /// </summary>
        /// <param name="idTransferencia"></param>
        /// <returns>Retorna true si esta reistrado, de lo contratio false</returns>
        public bool VerificarSiTransferenciaRegistradoTesoreria(int idTransferencia)
        {
            return DALCheque.VerificarSiTransferenciaRegistradoTesoreria(idTransferencia);
        }

        public string VerificarDevoluciones(int ID_SEGUIMIENTO, int ID_PAGO, string TIPO_PAGO)
        {
            return DALCheque.VerificarSiVerificarDevoluciones(ID_SEGUIMIENTO, ID_PAGO, TIPO_PAGO);
        }

        public bool EliminarDevolucionExcesoEntidad(List<DevolucionExcesoEntidad> to)
        {
            using (SqlConnection cn = new SqlConnection(conexion.con))
            {
                cn.Open();
                SqlTransaction tr = cn.BeginTransaction();
                try
                {
                    if (!EliminarDevolucionExceso(to, cn, tr))
                    {
                        tr.Rollback();
                        return false;
                    }

                    tr.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }



        public bool EliminarAplicacionOtrasPllas(SeguimientoPlanillaTo se, List<ChequesPlanillaTo> to)
        {
            using (SqlConnection cn = new SqlConnection(conexion.con))
            {
                cn.Open();
                SqlTransaction tr = cn.BeginTransaction();
                try
                {
                    if (!EliminarCobranzaPlanilla(to, cn, tr))
                    {
                        tr.Rollback();
                        return false;
                    }

                    if (!EliminarAplicacionOtrasPlanillas(to, cn, tr))
                    {
                        tr.Rollback();
                        return false;
                    }

                    decimal importeAnterior = to.Sum(x => x.DepositoChequeTo.IMPORTE);
                    if (!DALCheque.ActualizarSaldoExcesoPlanilla(se.ID_SEGUIMIENTO, importeAnterior, 0, cn, tr))
                    {
                        tr.Rollback();
                        return false;
                    }

                    tr.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        private bool EliminarCobranzaPlanilla(List<ChequesPlanillaTo> to, SqlConnection cn, SqlTransaction tr)
        {
            foreach (ChequesPlanillaTo item in to)
            {
                if (!DALCheque.EliminarCobranzaPlanilla(item, cn, tr))
                    return false;
            }
            return true;
        }

        private bool EliminarDevolucionExceso(List<DevolucionExcesoEntidad> to, SqlConnection cn, SqlTransaction tr)
        {
            foreach (DevolucionExcesoEntidad item in to)
            {
                if (!DALCheque.EliminarDevolucionExcesoE(item, cn, tr))
                    return false;
            }
            return true;
        }

        private bool EliminarAplicacionOtrasPlanillas(List<ChequesPlanillaTo> to, SqlConnection cn, SqlTransaction tr)
        {
            foreach (ChequesPlanillaTo item in to)
            {
                if (!DALCheque.EliminarAplicacionOtrasPlanillas(item, cn, tr))
                    return false;
            }
            return true;
        }

        public bool ActualizarSaldoXCobrarYImporteExceso()
        {
            List<SeguimientoPlanillaTo> lista = new List<SeguimientoPlanillaTo>();
            using (SqlConnection cn = new SqlConnection(conexion.con))
            {
                SqlTransaction tr = cn.BeginTransaction();
                foreach (SeguimientoPlanillaTo item in lista)
                {
                    if (!DALCheque.ActualizarSaldoXCobrarYImporteExceso(item, cn, tr))
                    {
                        tr.Rollback();
                        return false;
                    }
                }

                tr.Commit();
                return true;
            }
        }
    }
}
