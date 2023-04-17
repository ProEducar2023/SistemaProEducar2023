using DAL;
using Entidades;
using System;
using System.Data;
using System.Transactions;
namespace BLL
{
    public class precontratoCabeceraBLL
    {
        precontratoCabeceraDAL pccDAL = new precontratoCabeceraDAL();
        precontratoDetalleBLL pcdBLL = new precontratoDetalleBLL();
        precontratoDetalleTo pcdTo = new precontratoDetalleTo();
        contratoCabeceraBLL ccBLL = new contratoCabeceraBLL();
        contratoCabeceraDAL ccDAL = new contratoCabeceraDAL();
        contratoCabeceraTo ccTo = new contratoCabeceraTo();
        serieDocumentoBLL sdBLL = new serieDocumentoBLL();
        serieDocumentosTo sdTo = new serieDocumentosTo();
        canjeICtasxCobrarBLL ccixcBLL = new canjeICtasxCobrarBLL();
        canjeICtasxCobrarTo ccixcTo = new canjeICtasxCobrarTo();
        canjePCtasxCobrarBLL ccpxcBLL = new canjePCtasxCobrarBLL();
        canjePCtasxCobrarTo ccpxcTo = new canjePCtasxCobrarTo();
        temporal_Nro_ReporteBLL tnrBLL = new temporal_Nro_ReporteBLL();
        temporal_Nro_ReporteTo tnrTo = new temporal_Nro_ReporteTo();
        numeroReporteAutomaticoBLL nraBLL = new numeroReporteAutomaticoBLL();
        numeroReporteAutomaticoTo nraTo = new numeroReporteAutomaticoTo();
        DataTable DT00 = new DataTable();
        DataTable DT01 = new DataTable();
        public DataTable obtenerPreContratoCabeceraBLL(precontratoCabeceraTo pccTo)
        {
            return pccDAL.obtenerPrecontratoCabeceraDAL(pccTo);
        }
        public DataTable obtenerPreContratoCabeceraTodosPeriodosBLL(precontratoCabeceraTo pccTo)
        {
            return pccDAL.obtenerPrecontratoCabeceraTodosPeriodosDAL(pccTo);
        }
        public bool adicionaPreContratoBLL(precontratoCabeceraTo pccTo, DataTable dt, ref string nro_repo, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                //adiciona en Bulky
                HelpersBLL helBLL = new HelpersBLL();
                if (!helBLL.insertarBulkCopyBLL(dt, ref errMensaje))
                    return result = false;
                //adiciona PreContratoCabecera
                if (!insertarPreContratoCabeceraBLL(pccTo, ref errMensaje))
                    return result = false;
                //TEMPORAL_NRO_REPORTE
                if (pccTo.NRO_REPORTE == "")
                {
                    if (!insertar_Tabla_Temporal_Nro_ReporteBLL(pccTo, ref errMensaje))
                        return result = false;
                }
                //proceso CIERRE NRO REPORTE
                if (pccTo.CERRAR_NRO_REPORTE)
                {
                    if (!proceso_Cerrar_Nro_ReporteBLL(pccTo, ref nro_repo, ref errMensaje))
                        return result = false;
                }

                ts.Complete();
                return result;
            }
        }
        public bool proceso_Cerrar_Nro_ReporteBLL(precontratoCabeceraTo pccTo, ref string nro_repo, ref string errMensaje)
        {
            bool result = true;
            string NRO_REPORTE;
            //obtener Nro_Reporte de la Tabla NUMERO_REPORTE_AUTOMATICO
            NRO_REPORTE = nraBLL.obtener_Numero_Reporte_AutomaticoBLL();
            nro_repo = NRO_REPORTE;
            //obtener Datos de TEMPORAL_NRO_REPORTE
            tnrTo.cod_per_elab = pccTo.COD_PER_ELAB;
            DataTable dtTemporal = tnrBLL.obtener_Temporal_Nro_ReporteBLL(tnrTo);
            //actualizar I_Presupuesto 
            if (!actualizarI_Presupuesto_x_Digitador(pccTo, dtTemporal, NRO_REPORTE, ref errMensaje))
                return result = false;
            //eliminar TEMPORAL_NRO_REPORTE por digitador
            if (!eliminarTemporalNroReporteDigitador(pccTo, ref errMensaje))
                return result = false;
            //actualizar tabla NUMERO_REPORTE_AUTOMATICO
            if (!actualizarTablaNumeroReporteAutomatico(pccTo, NRO_REPORTE, ref errMensaje))
                return result = false;
            return result;
        }
        private bool actualizarTablaNumeroReporteAutomatico(precontratoCabeceraTo pccTo, string nro_reporte, ref string errMensaje)
        {
            bool result = true;
            string nro_reporte_nuevo = (Convert.ToInt32(nro_reporte) + 1).ToString().PadLeft(6, '0');
            nraTo.NRO_REPORTE = nro_reporte_nuevo;
            nraTo.COD_MODIFICAR = pccTo.COD_USU;
            nraTo.FECHA_MODIFICAR = pccTo.FECHA_CREA;
            if (!nraBLL.actualizar_Numero_Reporte_AutomaticoBLL(nraTo, ref errMensaje))
                return result = false;
            return result;
        }
        private bool eliminarTemporalNroReporteDigitador(precontratoCabeceraTo pccTo, ref string errMensaje)
        {
            bool result = true;
            tnrTo.cod_per_elab = pccTo.COD_PER_ELAB;
            if (!tnrBLL.eliminar_Temporal_Nro_ReporteBLL(tnrTo, ref errMensaje))
                return result;
            return result;
        }
        private bool actualizarI_Presupuesto_x_Digitador(precontratoCabeceraTo pccTo, DataTable dt, string NRO_REPORTE, ref string errMensaje)
        {
            bool result = true;
            foreach (DataRow rw in dt.Rows)
            {
                pccTo.NRO_PRESUPUESTO = Convert.ToString(rw["NRO_PRESUPUESTO"]);
                pccTo.COD_PER_ELAB = Convert.ToString(rw["COD_PER_ELAB"]);
                pccTo.NRO_REPORTE = NRO_REPORTE;
                if (!actualizaI_PresupuestoxContratoxDigitadorBLL(pccTo, ref errMensaje))
                    return result;
            }
            return result;
        }
        private bool actualizaI_PresupuestoxContratoxDigitadorBLL(precontratoCabeceraTo pccTo, ref string errMensaje)
        {
            bool result = true;
            if (!pccDAL.actualizaI_PresupuestoxContratoxDigitadorDAL(pccTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool insertar_Tabla_Temporal_Nro_ReporteBLL(precontratoCabeceraTo pccTo, ref string errMensaje)
        {
            bool result = true;
            tnrTo.nro_contrato = pccTo.NRO_PRESUPUESTO;
            tnrTo.cod_per_elab = pccTo.COD_PER_ELAB;
            if (!tnrBLL.insertar_Temporal_Nro_ReporteBLL(tnrTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificaPreContratoBLL(precontratoCabeceraTo pccTo, DataTable dt, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                //adiciona en Bulky
                HelpersBLL helBLL = new HelpersBLL();
                if (!helBLL.insertarBulkCopyBLL(dt, ref errMensaje))
                    return result = false;
                //adiciona PreContratoCabecera
                if (!modificarPreContratoCabeceraBLL(pccTo, ref errMensaje))
                    return result = false;

                ts.Complete();
                return result;
            }
        }
        public bool modificarPreContratoCabeceraBLL(precontratoCabeceraTo pccTo, ref string errMensaje)
        {
            bool result = true;
            if (!pccDAL.modificarPreContratoCabeceraDAL(pccTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool insertarPreContratoCabeceraBLL(precontratoCabeceraTo pccTo, ref string errMensaje)
        {
            bool result = true;
            if (!pccDAL.insertarPreContratoCabeceraDAL(pccTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificaApruebaPreContratoBLL(precontratoCabeceraTo pccTo, ref string errMensaje)
        {
            bool result = true;
            if (!pccDAL.modificaApruebaPreContratoDAL(pccTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificaDesapruebaPreContratoBLL(precontratoCabeceraTo pccTo, ref string errMensaje)
        {
            bool result = true;
            if (!pccDAL.modificaDesapruebaPreContratoDAL(pccTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminaContratoDetalleBLL(precontratoCabeceraTo pccTo, ref string errMensaje)
        {
            bool result = true;
            ccTo.COD_SUCURSAL = pccTo.COD_SUCURSAL;
            ccTo.COD_PER = pccTo.COD_PER;
            ccTo.COD_CLASE = pccTo.COD_CLASE;
            ccTo.NRO_PRESUPUESTO = pccTo.NRO_PRESUPUESTO;
            if (!ccDAL.eliminaContratoDetalleDAL(ccTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminaContratoCabeceraBLL(precontratoCabeceraTo pccTo, ref string errMensaje)
        {
            bool result = true;
            ccTo.COD_SUCURSAL = pccTo.COD_SUCURSAL;
            ccTo.COD_PER = pccTo.COD_PER;
            ccTo.COD_CLASE = pccTo.COD_CLASE;
            ccTo.NRO_PRESUPUESTO = pccTo.NRO_PRESUPUESTO;
            if (!ccDAL.eliminaContratoCabeceraDAL(ccTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool devuelveAlmacenBLL(DataTable dt, ref string errMensaje)
        {
            bool result = true;
            mArticuloBLL marBLL = new mArticuloBLL();
            mArticuloTo marTo = new mArticuloTo();
            foreach (DataRow rw in dt.Rows)
            {
                marTo.COD_CLASE = Convert.ToString(rw["COD_CLASE"]);
                marTo.COD_ALMACEN = Convert.ToString(rw["COD_ALMACEN"]);
                marTo.COD_ARTICULO = Convert.ToString(rw["COD_ARTICULO"]);
                marTo.SALDO_ACT = Convert.ToDecimal(rw["SALDO_ACT"]) + 1M;
                marTo.FECHA_DOC = DateTime.Now;
                if (!marBLL.insertarArticuloaAlmacenBLL(marTo, ref errMensaje))
                    return result = false;
            }
            return result;
        }
        private bool eliminaInventarioActualizaM_ArticuloBLL(precontratoCabeceraTo pccTo, ref string errMensaje)
        {
            bool result = true;
            inventariosBLL invBLL = new inventariosBLL();
            inventariosTo invTo = new inventariosTo();
            string nro_doc_inventario = invBLL.obtenerNroDocInventarioBLL(pccTo.NRO_PRESUPUESTO);
            if (nro_doc_inventario.Length > 0)
            {
                invTo.COD_SUCURSAL = pccTo.COD_SUCURSAL;
                invTo.COD_CLASE = pccTo.COD_CLASE;
                invTo.COD_PER = pccTo.COD_PER;
                invTo.COD_DOC_INV = "02";
                invTo.NRO_DOC_INV = nro_doc_inventario;
                invTo.FE_AÑO = null;
                invTo.FE_MES = null;
                if (!invBLL.ELIMINAR_NOTA_SALIDA_BLL(invTo, ref errMensaje))
                    return result = false;
            }
            return result;
        }
        private bool eliminaTCtasCobrarBLL(precontratoCabeceraTo pccTo, ref string errMensaje)
        {
            bool result = true;
            canjeTCtasxCobrarBLL ctcBLL = new canjeTCtasxCobrarBLL();
            canjeTCtasxCobrarTo ctcTo = new canjeTCtasxCobrarTo();
            ctcTo.COD_SUCURSAL = pccTo.COD_SUCURSAL;
            ctcTo.COD_CLASE = pccTo.COD_CLASE;
            ctcTo.NRO_CONTRATO = pccTo.NRO_PRESUPUESTO;
            if (!ctcBLL.eliminarTCtasCobrarBLL(ctcTo, ref errMensaje))
                return result = false;
            return result;
        }
        private bool eliminaPCtasCobrarBLL(precontratoCabeceraTo pccTo, ref string errMensaje)
        {
            bool result = true;
            canjePCtasxCobrarBLL cpcBLL = new canjePCtasxCobrarBLL();
            canjePCtasxCobrarTo cpcTo = new canjePCtasxCobrarTo();
            cpcTo.COD_SUCURSAL = pccTo.COD_SUCURSAL;
            cpcTo.COD_CLASE = pccTo.COD_CLASE;
            cpcTo.NRO_CONTRATO = pccTo.NRO_PRESUPUESTO;
            if (!cpcBLL.eliminarPCtasCobrarBLL(cpcTo, ref errMensaje))
                return result = false;
            return result;
        }
        private bool eliminaICtasCobrarBLL(precontratoCabeceraTo pccTo, ref string errMensaje)
        {
            bool result = true;
            canjeICtasxCobrarBLL cicBLL = new canjeICtasxCobrarBLL();
            canjeICtasxCobrarTo cicTo = new canjeICtasxCobrarTo();
            cicTo.COD_SUCURSAL = pccTo.COD_SUCURSAL;
            cicTo.COD_CLASE = pccTo.COD_CLASE;
            cicTo.NRO_CONTRATO = pccTo.NRO_PRESUPUESTO;
            if (!cicBLL.eliminarICtasCobrarBLL(cicTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminaContratoVentasBLL(precontratoCabeceraTo pccTo, DataTable dt, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                DataTable dtDetalle;
                foreach (DataRow rw in dt.Rows)
                {
                    pccTo.COD_SUCURSAL = rw["COD_SUCURSAL"].ToString();
                    pccTo.COD_CLASE = rw["COD_CLASE"].ToString();
                    pccTo.COD_PER = rw["COD_PER"].ToString();
                    pccTo.NRO_PRESUPUESTO = rw["NRO_PRESUPUESTO"].ToString();
                    pccTo.FE_AÑO = rw["FE_AÑO"].ToString();
                    pccTo.FE_MES = rw["FE_MES"].ToString();
                    //
                    pcdTo.COD_SUCURSAL = pccTo.COD_SUCURSAL;
                    pcdTo.COD_CLASE = pccTo.COD_CLASE;
                    pcdTo.COD_PER = pccTo.COD_PER;
                    pcdTo.NRO_PRESUPUESTO = pccTo.NRO_PRESUPUESTO;
                    pcdTo.FE_AÑO = pccTo.FE_AÑO;
                    pcdTo.FE_MES = pccTo.FE_MES;
                    dtDetalle = pcdBLL.obtenerPreContratoDetalleparaDesaprobarContratoBLL(pcdTo);
                    //modifica pre-venta  
                    if (!modificaDesapruebaPreContratoBLL(pccTo, ref errMensaje))
                        return result = false;
                    //eliminar Contrato Detalle
                    if (!eliminaContratoDetalleBLL(pccTo, ref errMensaje))
                        return result = false;
                    //eliminar Contrato Cabecera
                    if (!eliminaContratoCabeceraBLL(pccTo, ref errMensaje))
                        return result = false;
                    //eliminar Inventarios Cabecera y Detalle y actualiza M_Articulo
                    if (!eliminaInventarioActualizaM_ArticuloBLL(pccTo, ref errMensaje))
                        return result = false;
                    //eliminar TCtas
                    if (!eliminaTCtasCobrarBLL(pccTo, ref errMensaje))
                        return result = false;
                    //eliminar PCtas
                    if (!eliminaPCtasCobrarBLL(pccTo, ref errMensaje))
                        return result = false;
                    //eliminar I_Ctas
                    if (!eliminaICtasCobrarBLL(pccTo, ref errMensaje))
                        return result = false;

                }

                ts.Complete();
                return result;
            }
        }
        public bool modificaApruebaPreContratoBloqueBLL(precontratoCabeceraTo pccTo, DataTable dt, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                Crea_DT00();
                Crea_DT01();
                DataTable dtCabecera, dtDetalle;
                foreach (DataRow rw in dt.Rows)
                {
                    pccTo.COD_SUCURSAL = rw["COD_SUCURSAL"].ToString();
                    pccTo.COD_CLASE = rw["COD_CLASE"].ToString();
                    pccTo.COD_PER = rw["COD_PER"].ToString();
                    pccTo.NRO_PRESUPUESTO = rw["Contrato"].ToString();
                    pccTo.FE_AÑO = rw["FE_AÑO"].ToString();
                    pccTo.FE_MES = rw["FE_MES"].ToString();
                    pccTo.STATUS_PRE_APROB = rw["STATUS_PRE_APROB"].ToString();
                    //modifica pre-venta  
                    if (!modificaApruebaPreContratoBLL(pccTo, ref errMensaje))
                        return result = false;
                    //obtener cabecera Pre-Venta, se podria ahorrar este paso si de una vez se trae el dt con todas las columnas necesarias
                    dtCabecera = pccDAL.obtenerPreContratoCabeceraparaCrearContratoDAL(pccTo);
                    string status_pre_aprob = pccTo.STATUS_PRE_APROB == "True" ? "1" : "";
                    Contrato_Cabecera(dtCabecera, pccTo.COD_MOV, pccTo.NOMBRE_PC, pccTo.COD_USU, status_pre_aprob, pccTo.FECHA_APROB);
                    //obtener detalle Pre-Venta
                    pcdTo.COD_SUCURSAL = pccTo.COD_SUCURSAL;
                    pcdTo.COD_CLASE = pccTo.COD_CLASE;
                    pcdTo.COD_PER = pccTo.COD_PER;
                    pcdTo.NRO_PRESUPUESTO = pccTo.NRO_PRESUPUESTO;
                    pcdTo.FE_AÑO = pccTo.FE_AÑO;
                    pcdTo.FE_MES = pccTo.FE_MES;
                    dtDetalle = pcdBLL.obtenerPreContratoCabeceraparaCrearContratoDetalleBLL(pcdTo);
                    Contrato_Detalle(dtDetalle, pccTo.NOMBRE_PC);
                    CuentaCorriente(dtCabecera, pccTo.COD_USU, pccTo.FECHA_APROB);
                    //bulkcopy de T_PEDIDO2
                    if (!ccBLL.insertarBulkCopyPedDetBLL(DT00, ref errMensaje))
                        return result = false;
                    //adiciona en Pedido Cabecera
                    if (!ccBLL.insertarContratoBLL(ccTo, ref errMensaje))
                        return result = false;
                    //bulkcopy de INVENTARIO_DETALLE2
                    if (!ccBLL.insertarBulkCopyInventarioDetalleBLL(DT01, ref errMensaje))
                        return result = false;
                    //adiciona en Inventarios Cabecera, Detalle y M_Articulo
                    if (!ccBLL.insertarInventarioBLL(ccTo, ref errMensaje))
                        return result = false;
                    //I_CTAS_COBRAR
                    if (!ccixcBLL.insertarCanjeICtasxCobrarBLL(ccixcTo, ref errMensaje))
                        return result = false;
                    //PCTAS_COBRAR y TCTAS_COBRAR
                    if (!ccixcBLL.insertarCanjePTCtasxCobrarxBloqueBLL(ccixcTo, ref errMensaje))//dtPT se crea desde aqui
                        return result = false;
                    ////actualiza 
                    if (!ccixcBLL.actualizaPedido_Status_Cta_BLL(ccixcTo.COD_SUCURSAL, ccixcTo.NRO_CONTRATO, ref errMensaje))
                        return result = false;
                }
                ts.Complete();
                return result;
            }
        }
        private void CuentaCorriente(DataTable dt, string cod_usu, DateTime? fecha_aprob)
        {
            ccixcTo.COD_SUCURSAL = dt.Rows[0]["COD_SUCURSAL"].ToString();// del combo
            ccixcTo.COD_CLASE = dt.Rows[0]["COD_CLASE"].ToString();
            ccixcTo.NRO_CONTRATO = dt.Rows[0]["NRO_PRESUPUESTO"].ToString();
            ccixcTo.FE_AÑO = Convert.ToString(fecha_aprob.Value.Year);//dt.Rows[0]["FE_AÑO"].ToString();
            ccixcTo.FE_MES = Convert.ToString(fecha_aprob.Value.Month).PadLeft(2, '0');//dt.Rows[0]["FE_MES"].ToString();
            ccixcTo.FECHA_CONTRATO = Convert.ToDateTime(dt.Rows[0]["FECHA_PRE"]);
            ccixcTo.FECHA_APROBACION = null;
            ccixcTo.NRO_REPORTE = dt.Rows[0]["NRO_REPORTE"].ToString();
            ccixcTo.FECHA_REPORTE = Convert.ToDateTime(dt.Rows[0]["FEC_REPORTE"]);
            ccixcTo.COD_MONEDA = dt.Rows[0]["COD_MONEDA"].ToString();
            ccixcTo.TIPO_CAMBIO = Convert.ToDecimal(dt.Rows[0]["TIPO_CAMBIO"]);
            ccixcTo.IMP_DOC = Convert.ToDecimal(dt.Rows[0]["TOTAL_CONTRATO"]);
            ccixcTo.OBSERVACION = "";
            ccixcTo.TIPO_OPE = "GF";
            ccixcTo.COD_PER = dt.Rows[0]["COD_PER"].ToString();
            ccixcTo.NRO_CUOTAS = dt.Rows[0]["NRO_CUOTAS"].ToString();
            ccixcTo.IMP_DEVOLUCION = 0;
            ccixcTo.FECHA_DEVOLUCION = null;
            ccixcTo.COD_VENDEDOR = dt.Rows[0]["COD_VENDEDOR"].ToString();
            ccixcTo.COD_NIVEL1 = dt.Rows[0]["COD_NIVEL1"].ToString();
            ccixcTo.COD_NIVEL2 = dt.Rows[0]["COD_NIVEL2"].ToString();
            ccixcTo.COD_NIVEL3 = dt.Rows[0]["COD_NIVEL3"].ToString();
            ccixcTo.COD_PTO_COB = dt.Rows[0]["COD_PTO_COB"].ToString();
            ccixcTo.COD_USU_CREA = cod_usu;//dt.Rows[0]["COD_USU"].ToString();//
            ccixcTo.FECHA_CREA = DateTime.Now;
            ccixcTo.COD_SECTORISTA = dt.Rows[0]["COD_SECTORISTA"].ToString();
            ccixcTo.COD_TIPO_VENTA = dt.Rows[0]["COD_TIPO_VENTA"].ToString();
            ccixcTo.COD_MODALIDAD_VTA = dt.Rows[0]["COD_MODALIDAD_VTA"].ToString();
            ccixcTo.STATUS_PRE_APROB = "0";
            ccixcTo.FECHA_DOC = Convert.ToDateTime(dt.Rows[0]["FECHA_APROB"]);//DateTime.Now;// Convert.ToDateTime(dt.Rows[0]["FECHA_DOC"]);// fecha en la que se hace el proceso de crear las cuentas corrientes
            ccixcTo.FECHA_VEN = Convert.ToDateTime(dt.Rows[0]["FEC_PRIMER_VENC"]);
            ccixcTo.IMP_INI = Convert.ToDecimal(dt.Rows[0]["IMP_CUOTA_INICIAL"]);
            ccixcTo.FECHA_VEN2 = Convert.ToDateTime(dt.Rows[0]["FEC_CUO_MEN"]);
            ccixcTo.IMP_INI2 = Convert.ToDecimal(dt.Rows[0]["IMP_CUOTA_MES"]);
            ccixcTo.TIPO_PLA_ORIGEN = dt.Rows[0]["TIPO_PLANILLA"].ToString();//P o D
            ccixcTo.TIPO_PLA_COBRANZA = dt.Rows[0]["TIPO_OPERACION"].ToString();//PP,PD,PV

        }
        private string CARGAR_SERIE_NRO(string cod_sucursal)
        {
            string sr = "";
            sdTo.COD_SUCURSAL = cod_sucursal;
            sdTo.COD_DOC = "04";
            sdTo.STATUS_DOC = "0";
            DataTable dt = sdBLL.OBTENER_SERIE_NRO_BLL(sdTo);
            return sr = dt.Rows[0][1].ToString() + "-" + dt.Rows[0][0].ToString();
        }
        private void Contrato_Cabecera(DataTable dt, string cod_mov, string nombre_pc, string cod_usu, string status_pre_aprob, DateTime? fecha_aprob)
        {
            ccTo.COD_SUCURSAL = dt.Rows[0]["COD_SUCURSAL"].ToString();
            ccTo.NRO_DOC = CARGAR_SERIE_NRO(ccTo.COD_SUCURSAL);
            ccTo.COD_PER = dt.Rows[0]["COD_PER"].ToString(); ;
            ccTo.COD_CLASE = dt.Rows[0]["COD_CLASE"].ToString();
            ccTo.FE_AÑO = Convert.ToString(fecha_aprob.Value.Year);//dt.Rows[0]["FE_AÑO"].ToString();//
            ccTo.FE_MES = Convert.ToString(fecha_aprob.Value.Month).PadLeft(2, '0');//dt.Rows[0]["FE_MES"].ToString();//
            ccTo.FECHA_DOC = DateTime.Now;
            ccTo.NRO_PRESUPUESTO = dt.Rows[0]["NRO_PRESUPUESTO"].ToString();
            ccTo.FECHA_PRE = Convert.ToDateTime(dt.Rows[0]["FECHA_PRE"]);
            ccTo.COD_MONEDA = dt.Rows[0]["COD_MONEDA"].ToString();
            ccTo.TIPO_CAMBIO = Convert.ToDecimal(dt.Rows[0]["TIPO_CAMBIO"]);
            ccTo.FORMA_PAGO = dt.Rows[0]["FORMA_PAGO"].ToString();
            ccTo.STATUS_PV = dt.Rows[0]["STATUS_PV"].ToString();
            ccTo.NRO_DIAS = Convert.ToInt32(dt.Rows[0]["NRO_DIAS"]);
            ccTo.COD_PER_ELAB = dt.Rows[0]["COD_PER_ELAB"].ToString();
            ccTo.COD_PER_APROB = dt.Rows[0]["COD_PER_APROB"].ToString();//*
            ccTo.STATUS_APROB = status_pre_aprob == "1" ? "" : "1";//dt.Rows[0]["STATUS_PRE_APROB"].ToString() == "True" ? "" : "1";////"";
            ccTo.STATUS_ANUL = "";
            ccTo.STATUS_CIERRE = "";
            ccTo.COD_VENDEDOR = dt.Rows[0]["COD_VENDEDOR"].ToString();
            ccTo.CONDICION_VENTA = dt.Rows[0]["CONDICION_VENTA"].ToString();
            ccTo.COD_CONTACTO = dt.Rows[0]["COD_CONTACTO"].ToString();
            ccTo.FECHA_APROB = fecha_aprob;//Convert.ToDateTime(dt.Rows[0]["FECHA_APROB"]);//*
            ccTo.TIPO_PRECIO = dt.Rows[0]["TIPO_PRECIO"].ToString();
            ccTo.OBSERVACION = dt.Rows[0]["OBSERVACION"].ToString();
            ccTo.COD_MOV = cod_mov;
            ccTo.NRO_REPORTE = dt.Rows[0]["NRO_REPORTE"].ToString();
            ccTo.FEC_REPORTE = Convert.ToDateTime(dt.Rows[0]["FEC_REPORTE"]);
            ccTo.COD_PROGRAMA = dt.Rows[0]["COD_PROGRAMA"].ToString();
            ccTo.PERIODO = dt.Rows[0]["PERIODO"].ToString();//periodo en que se ingreso el contrato
            ccTo.NRO_SEMANA = dt.Rows[0]["NRO_SEMANA"].ToString();
            ccTo.TIPO_OPERACION = dt.Rows[0]["TIPO_OPERACION"].ToString();
            ccTo.TIPO_PLANILLA = dt.Rows[0]["TIPO_PLANILLA"].ToString();
            ccTo.COD_ALMACEN = dt.Rows[0]["COD_ALMACEN"].ToString();
            ccTo.COD_NIVEL1 = dt.Rows[0]["COD_NIVEL1"].ToString();
            ccTo.COD_NIVEL2 = dt.Rows[0]["COD_NIVEL2"].ToString();
            ccTo.COD_NIVEL3 = dt.Rows[0]["COD_NIVEL3"].ToString();
            ccTo.SUELDO_NETO = Convert.ToDecimal(dt.Rows[0]["SUELDO_BASICO"]);
            ccTo.PRESTAMOS = Convert.ToDecimal(dt.Rows[0]["SUELDO_BRUTO"]);
            ccTo.JUDICIALES = Convert.ToDecimal(dt.Rows[0]["JUDICIALES"]);
            ccTo.OTROS_DSCTOS = Convert.ToDecimal(dt.Rows[0]["OTROS_DSCTOS"]);
            ccTo.IMPORTE_PROTECCION = Convert.ToDecimal(dt.Rows[0]["IMPORTE_PROTECCION"]);
            ccTo.NETO_COBRAR = Convert.ToDecimal(dt.Rows[0]["NETO_COBRAR"]);
            ccTo.TOTAL_CONTRATO = Convert.ToDecimal(dt.Rows[0]["TOTAL_CONTRATO"]);
            ccTo.NRO_CUOTAS = Convert.ToInt32(dt.Rows[0]["NRO_CUOTAS"]);
            ccTo.IMP_CUOTA_INICIAL = Convert.ToDecimal(dt.Rows[0]["IMP_CUOTA_INICIAL"]);
            ccTo.IMP_CUOTA_MES = Convert.ToDecimal(dt.Rows[0]["IMP_CUOTA_MES"]);
            ccTo.FEC_PRIMER_VENC = Convert.ToDateTime(dt.Rows[0]["FEC_PRIMER_VENC"]);
            ccTo.NRO_DIAS_VENC = Convert.ToInt32(dt.Rows[0]["NRO_DIAS_VENC"]);
            ccTo.FEC_CUO_MEN = Convert.ToDateTime(dt.Rows[0]["FEC_CUO_MEN"]);
            ccTo.STATUS_FAC = "";
            ccTo.TIPO_PEDIDO = "";
            ccTo.STATUS_GUIA = "";
            ccTo.COD_REF = "";
            ccTo.NRO_REF = "";
            ccTo.NOMBRE_PC = nombre_pc;
            ccTo.SERIE = ccTo.NRO_DOC.Substring(0, 3);
            ccTo.COD_SUB_PTO_VEN = dt.Rows[0]["COD_SUB_PTO_VEN"].ToString();
            ccTo.COD_CANAL_DSCTO = dt.Rows[0]["COD_CANAL_DSCTO"].ToString();
            ccTo.COD_PTO_COB = dt.Rows[0]["COD_PTO_COB"].ToString();
            ccTo.COD_TIPO_VENTA = dt.Rows[0]["COD_TIPO_VENTA"].ToString();
            ccTo.COD_MODALIDAD_VTA = dt.Rows[0]["COD_MODALIDAD_VTA"].ToString();
            ccTo.COD_LUG_VTA = dt.Rows[0]["COD_LUG_VTA"].ToString();
            ccTo.COD_INSTITUCION = dt.Rows[0]["COD_INSTITUCION"].ToString();
            ccTo.NRO_DOC_INV = HALLAR_NRO_SALIDA(ccTo.COD_SUCURSAL);
            ccTo.COD_USU = cod_usu;
            ccTo.STATUS_PRE_APROB = status_pre_aprob;//dt.Rows[0]["STATUS_PRE_APROB"].ToString() == "True" ? "1" : ""; //status_pre_aprob;
            ccTo.COD_KIT = dt.Rows[0]["COD_KIT"].ToString();
            ccTo.DSCTO_TOTAL = Convert.ToDecimal(dt.Rows[0]["DSCTO_TOTAL"]);
            ccTo.COD_NIVEL_INSTITUCION = Convert.ToString(dt.Rows[0]["COD_NIVEL_INSTITUCION"]);
        }
        public string HALLAR_NRO_SALIDA(string cod_sucursal)
        {
            int sr = -1;
            sdTo.COD_SUCURSAL = cod_sucursal;
            sdTo.SERIE = "001";
            sdTo.COD_DOC = "02";
            sr = sdBLL.obtenerNro_IngBLL(sdTo);
            return "001-" + sr.ToString("0000000");
        }
        private void Contrato_Detalle(DataTable dt, string nombre_pc)
        {
            DT00.Rows.Clear();
            DT01.Rows.Clear();
            int num = dt.Rows.Count - 1;
            int num3 = num;
            int i = 0;
            while (i <= num3)
            {
                DT00.Rows.Add(dt.Rows[i]["COD_SUCURSAL"].ToString(), ccTo.NRO_DOC, "", dt.Rows[i]["COD_PER"].ToString(), dt.Rows[i]["COD_CLASE"].ToString(),
                    dt.Rows[i]["FE_AÑO"].ToString(), dt.Rows[i]["FE_MES"].ToString(), (i + 1).ToString("00"), dt.Rows[i]["COD_ARTICULO"].ToString(), dt.Rows[i]["CANTIDAD_PED"].ToString(), dt.Rows[i]["CANTIDAD_PED"].ToString(), dt.Rows[i]["CANTIDAD_ANUL"].ToString(),//CANTIDAD_ATEN DEBE SER IGUAL A CANTIDAD_PED
                    dt.Rows[i]["PRECIO_UNIT"].ToString(), dt.Rows[i]["VALOR_COMPRA"].ToString(), dt.Rows[i]["POR_IGV"].ToString(), dt.Rows[i]["POR_DSCTO"].ToString(), dt.Rows[i]["STATUS_IGV"].ToString(), dt.Rows[i]["VALOR_IGV"].ToString(), dt.Rows[i]["VALOR_DSCTO"].ToString(), dt.Rows[i]["AJUSTE_IGV"].ToString(),
                    dt.Rows[i]["AJUSTE_BI"].ToString(), dt.Rows[i]["COD_D_H"].ToString(), dt.Rows[i]["OBSERVACION"].ToString(), nombre_pc, dt.Rows[i]["NRO_PRESUPUESTO"].ToString(),
                    dt.Rows[i]["ITEM"].ToString(), dt.Rows[i]["COD_CONDICION"].ToString(), dt.Rows[i]["DESC_ARTICULO"].ToString(), dt.Rows[i]["TIPO_PRECIO"].ToString(), "0",
                    dt.Rows[i]["ST_VALOR_REFERENCIAL"].ToString());
                //
                DT01.Rows.Add(dt.Rows[i]["COD_SUCURSAL"].ToString(), dt.Rows[i]["COD_CLASE"].ToString(), dt.Rows[i]["COD_PER"].ToString(), "02",
                    ccTo.NRO_DOC_INV, dt.Rows[i]["FE_AÑO"].ToString(), dt.Rows[i]["FE_MES"].ToString(), (i + 1).ToString("00"), dt.Rows[i]["ITEM"].ToString(),
                    dt.Rows[i]["COD_ARTICULO"].ToString(), dt.Rows[i]["CANTIDAD_PED"].ToString(), 0, "H", "S", ccTo.COD_ALMACEN, dt.Rows[i]["PRECIO_UNIT"].ToString(),
                    dt.Rows[i]["VALOR_COMPRA"].ToString(), dt.Rows[i]["POR_IGV"].ToString(), dt.Rows[i]["POR_DSCTO"].ToString(), dt.Rows[i]["STATUS_IGV"].ToString(),
                    dt.Rows[i]["VALOR_IGV"].ToString(), dt.Rows[i]["VALOR_DSCTO"].ToString(),
                    dt.Rows[i]["AJUSTE_IGV"].ToString(), dt.Rows[i]["AJUSTE_BI"].ToString(), "", "0", nombre_pc, dt.Rows[i]["NRO_PRESUPUESTO"].ToString(), ccTo.FECHA_PRE, dt.Rows[i]["OBSERVACION"].ToString());
                i++;
            }
        }
        public bool VALIDAR_DESAPROBAR_PRECONTRATOBLL(precontratoCabeceraTo pccTo, ref bool flag2, ref string errMensaje)
        {
            bool result = true;
            if (!pccDAL.VALIDAR_DESAPROBAR_PRECONTRATODAL(pccTo, ref flag2, ref errMensaje))
                return result = false;
            return result;
        }
        public bool DESAPROBAR_PEDIDOBLL(precontratoCabeceraTo pccTo, ref string errMensaje)
        {
            bool result = true;
            if (!pccDAL.DESAPROBAR_PEDIDODAL(pccTo, ref errMensaje))
                return result = false;
            return result;
        }
        //verifica 
        public bool VERIFICA_ORDEN_PEDIDOBLL(precontratoCabeceraTo pccTo, ref bool flag2, ref string errMensaje)
        {
            bool result = true;
            if (!pccDAL.VERIFICA_ORDEN_PEDIDODAL(pccTo, ref flag2, ref errMensaje))
                return result = false;
            return result;
        }
        public bool VERIFICA_NRO_CONTROTATO_BLL(precontratoCabeceraTo pccTo, ref string errMensaje)
        {
            bool result = true;
            if (!pccDAL.VERIFICA_NRO_CONTROTATO_DAL(pccTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool ELIMINAR_PEDIDOBLL(precontratoCabeceraTo pccTo, ref string errMensaje)
        {
            bool result = true;
            if (!pccDAL.ELIMINAR_PEDIDODAL(pccTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool CERRAR_PEDIDOBLL(precontratoCabeceraTo pccTo, ref string errMensaje)
        {
            bool result = true;
            if (!pccDAL.CERRAR_PEDIDODAL(pccTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool ANULAR_PEDIDOBLL(precontratoCabeceraTo pccTo, ref string errMensaje)
        {
            bool result = true;
            if (!pccDAL.ANULAR_PEDIDODAL(pccTo, ref errMensaje))
                return result = false;
            return result;
        }
        public DataTable CARGAR_PRECONTRATOS_PENDIENTESBLL(precontratoCabeceraTo pccTo)
        {
            return pccDAL.CARGAR_PRECONTRATOS_PENDIENTESDAL(pccTo);
        }
        public DataTable MOSTRAR_I_PRESUPUESTO_PARA_CANJE(precontratoCabeceraTo pccTo)
        {
            return pccDAL.MOSTRAR_I_PRESUPUESTO_PARA_CANJE(pccTo);
        }
        public DataTable obtieneRegContratoBLL(precontratoCabeceraTo pccTo)
        {
            return pccDAL.obtieneRegContratoDAL(pccTo);
        }
        public decimal obtenerPorcentajeEvalContratoBLL()
        {
            return pccDAL.obtenerPorcentajeEvalContratoDAL();
        }
        public bool actualizaPreContratoStatusCierreBLL(precontratoCabeceraTo pccTo, ref string errMensaje)
        {
            bool result = true;
            if (!pccDAL.actualizaPreContratoStatusCierreDAL(pccTo, ref errMensaje))
                return result;
            return result;
        }
        public bool actualizaPreContratoStatusCierre_x_NroContrato_BLL(precontratoCabeceraTo pccTo, ref string errMensaje)
        {
            bool result = true;
            if (!pccDAL.actualizaPreContratoStatusCierre_x_NroContrato_DAL(pccTo, ref errMensaje))
                return result;
            return result;
        }
        public DataTable obtenerReporteControlCalidadBLL(precontratoCabeceraTo pccTo)
        {
            return pccDAL.obtenerReporteControlCalidadDAL(pccTo);
        }
        public DataTable obtenerReporteCambioUbicacionABLL(precontratoCabeceraTo pccTo)
        {
            return pccDAL.obtenerReporteCambioUbicacionADAL(pccTo);
        }
        public DataTable obtenerReporteCambioUbicacionResumenBLL(precontratoCabeceraTo pccTo)
        {
            return pccDAL.obtenerReporteCambioUbicacionResumenDAL(pccTo);
        }
        public DataTable obtenerReporteControlCalidadxFechaReporteBLL(precontratoCabeceraTo pccTo)
        {
            return pccDAL.obtenerReporteControlCalidadxFechaReporteDAL(pccTo);
        }
        public DataTable obtenerReporteControlCalidadContratoxFechaAprobBLL(precontratoCabeceraTo pccTo)
        {
            return pccDAL.obtenerReporteControlCalidadContratoxFechaAprobDAL(pccTo);
        }
        public DataTable obtenerReporteControlCalidadxPeriodo_y_Semana_ContratoBLL(precontratoCabeceraTo pccTo)
        {
            return pccDAL.obtenerReporteControlCalidadxPeriodo_y_Semana_ContratoDAL(pccTo);
        }
        public DataTable obtenerReporteControlCalidadxPeriodoBLL(precontratoCabeceraTo pccTo)
        {
            return pccDAL.obtenerReporteControlCalidadxPeriodoDAL(pccTo);
        }
        private void Crea_DT00()// PARA T_PEDIDO
        {
            DT00.Reset();
            DT00.Columns.Add("sucursal");
            DT00.Columns.Add("nro_doc");
            DT00.Columns.Add("NRO_FAC_PRE_UNI");
            DT00.Columns.Add("Cod_per");
            DT00.Columns.Add("cod_clase");
            DT00.Columns.Add("Fe_año");
            DT00.Columns.Add("Fe_mes");
            DT00.Columns.Add("Item");
            DT00.Columns.Add("Articulo");
            DT00.Columns.Add("Cantidad_ped");
            DT00.Columns.Add("Cantidad_aten");
            DT00.Columns.Add("Cantidad_anul");
            DT00.Columns.Add("Precio_Unit");
            DT00.Columns.Add("Valor_Compra");
            DT00.Columns.Add("Por_igv");
            DT00.Columns.Add("Por_Dscto");
            DT00.Columns.Add("Status_igv");
            DT00.Columns.Add("Valor_IGV");
            DT00.Columns.Add("Valor_Dscto");
            DT00.Columns.Add("Ajuste_igv");
            DT00.Columns.Add("Ajuste_Bi");
            DT00.Columns.Add("COD_d_h");
            DT00.Columns.Add("observacion");
            DT00.Columns.Add("Nombre_pc");
            DT00.Columns.Add("NRO_PRESUPUESTO");
            DT00.Columns.Add("NRO_ITEM");
            DT00.Columns.Add("COD_CONDICION");
            DT00.Columns.Add("DESC_ARTICULO");
            DT00.Columns.Add("TIPO_PRECIO");
            DT00.Columns.Add("TIPO_ENTR_FAC");
            DT00.Columns.Add("ST_VALOR_REFERENCIA");
        }
        private void Crea_DT01()//PARA INVENTARIO
        {
            DT01.Reset();
            DT01.Columns.Add("sucursal");
            DT01.Columns.Add("Clase");
            DT01.Columns.Add("Cod_per");
            DT01.Columns.Add("COD_DOC");
            DT01.Columns.Add("NRO_DOC_INV");
            DT01.Columns.Add("Fe_año");
            DT01.Columns.Add("Fe_mes");
            DT01.Columns.Add("Item");
            DT01.Columns.Add("Item2");
            DT01.Columns.Add("Articulo");
            DT01.Columns.Add("Cantidad");
            DT01.Columns.Add("Cantidad_anul");
            DT01.Columns.Add("COD_D_H");
            DT01.Columns.Add("COD_MONEDA");
            DT01.Columns.Add("COD_ALMACEN");
            DT01.Columns.Add("Precio_Unit");
            DT01.Columns.Add("Valor_COmpra");
            DT01.Columns.Add("Por_igv");
            DT01.Columns.Add("Por_Dscto");
            DT01.Columns.Add("Status_igv");
            DT01.Columns.Add("Valor_IGV");
            DT01.Columns.Add("Valor_Dscto");
            DT01.Columns.Add("Ajuste_igv");
            DT01.Columns.Add("Ajuste_Bi");
            DT01.Columns.Add("COD_AREA");
            DT01.Columns.Add("STATUS_FACT");
            DT01.Columns.Add("Nombre_pc");
            DT01.Columns.Add("NRO_PEDIDO");//*****************
            DT01.Columns.Add("FECHA_PEDIDO");//******************
            DT01.Columns.Add("OBSERVACION");
        }
        public bool proceso_Cerrar_Nro_Reporte_x_DigitadorBLL(precontratoCabeceraTo pccTo, ref string nro_repo, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                string NRO_REPORTE;
                //obtener Nro_Reporte de la Tabla NUMERO_REPORTE_AUTOMATICO
                NRO_REPORTE = nraBLL.obtener_Numero_Reporte_AutomaticoBLL();
                nro_repo = NRO_REPORTE;
                //obtener Datos de TEMPORAL_NRO_REPORTE
                tnrTo.cod_per_elab = pccTo.COD_PER_ELAB;
                DataTable dtTemporal = tnrBLL.obtener_Temporal_Nro_ReporteBLL(tnrTo);
                //actualizar I_Presupuesto 
                if (!actualizarI_Presupuesto_x_Digitador(pccTo, dtTemporal, NRO_REPORTE, ref errMensaje))
                    return result = false;
                //eliminar TEMPORAL_NRO_REPORTE por digitador
                if (!eliminarTemporalNroReporteDigitador(pccTo, ref errMensaje))
                    return result = false;
                //actualizar tabla NUMERO_REPORTE_AUTOMATICO
                if (!actualizarTablaNumeroReporteAutomatico(pccTo, NRO_REPORTE, ref errMensaje))
                    return result = false;

                ts.Complete();
                return result;
            }
        }
    }
}
