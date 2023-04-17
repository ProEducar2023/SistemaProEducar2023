using DAL;
using Entidades;
using System;
using System.Data;
using System.Transactions;
namespace BLL
{
    public class canjeICtasxCobrarBLL
    {
        public canjeICtasxCobrarDAL cicxDAL = new canjeICtasxCobrarDAL();
        canjePCtasxCobrarBLL cpcxBLL = new canjePCtasxCobrarBLL();
        canjeTCtasxCobrarTo ctcxTo = new canjeTCtasxCobrarTo();
        canjeTCtasxCobrarBLL ctxcBLL = new canjeTCtasxCobrarBLL();
        canjePCtasxCobrarDAL ctpxDAL = new canjePCtasxCobrarDAL();
        canjeTCtasxCobrarDAL cttxDAL = new canjeTCtasxCobrarDAL();
        serieDocumentoBLL sdoBLL = new serieDocumentoBLL();
        serieDocumentosTo sdoTo = new serieDocumentosTo();
        inventariosBLL invBLL = new inventariosBLL();
        inventariosTo invTo = new inventariosTo();
        public DataTable obtenerCanjeICtasxCobrarBLL(canjeICtasxCobrarTo cicxTo)
        {
            return cicxDAL.obtenerCanjeICtasxCobrarDAL(cicxTo);
        }
        public DataTable obtenerCanjeICtasxCobrarxBloqueBLL(canjeICtasxCobrarTo cicxTo)
        {
            return cicxDAL.obtenerCanjeICtasxCobrarxBloqueDAL(cicxTo);
        }

        public bool insertaAdicionaCanjeICtasxCobrarBLL(canjeICtasxCobrarTo cicxTo, DataTable dtPT, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                //I
                if (!insertarCanjeICtasxCobrarBLL(cicxTo, ref errMensaje))
                    return result = false;
                //P y T
                if (!insertarCanjePTCtasxCobrarBLL(dtPT, ref errMensaje))
                    return result = false;
                ////T
                //if (!insertarCanjeTCtasxCobrarBLL(dtT, ref errMensaje))
                //    return result = false;
                ////actualiza 
                if (!actualizaPedido_Status_Cta_BLL(cicxTo.COD_SUCURSAL, cicxTo.NRO_CONTRATO, ref errMensaje))
                    return result = false;
                ts.Complete();
                return result;
            }
        }

        public bool actualizaPedido_Status_Cta_BLL(string COD_SUCURSAL, string NRO_PRESUPUESTO, ref string errMensaje)
        {
            contratoCabeceraBLL ccBLL = new contratoCabeceraBLL();
            bool result = true;
            if (!ccBLL.actualizaPedido_Status_Cta_BLL(COD_SUCURSAL, NRO_PRESUPUESTO, ref errMensaje))
                return result = false;
            return result;
        }
        private bool insertarCanjeTCtasxCobrarBLL(DataTable dtT, ref string errMensaje)
        {
            bool result = true;
            if (!ctxcBLL.insertarCanjeTCtasxCobrarBLL(dtT, ref errMensaje))
                return result = false;
            return result;
        }
        public bool insertarCanjeICtasxCobrarBLL(canjeICtasxCobrarTo cicxTo, ref string errMensaje)
        {
            bool result = true;
            if (!cicxDAL.insertarCanjeICtasxCobrarDAL(cicxTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool insertarCanjePTCtasxCobrarBLL(DataTable dtPT, ref string errMensaje)
        {
            bool result = true;
            if (!adicionaCanjePTCtasxCobrarBLL(dtPT, ref errMensaje))
                return result = false;
            return result;
        }
        public bool insertarCanjePCtasxCobrarBLL(DataTable dtP, ref string errMensaje)
        {
            bool result = true;
            if (!cpcxBLL.insertarCanjePCtasxCobrarBLL(dtP, ref errMensaje))
                return result = false;
            return result;
        }
        public bool adicionaCanjePTCtasxCobrarBLL(DataTable dtPT, ref string errMensaje)
        {
            bool result = true;
            sdoTo.COD_SUCURSAL = dtPT.Rows[0]["COD_SUCURSAL"].ToString();
            sdoTo.STATUS_DOC = "0";
            sdoTo.COD_DOC = "42";
            sdoTo.SERIE = "001";
            foreach (DataRow rw in dtPT.Rows)
            {
                ctcxTo.COD_SUCURSAL = rw["COD_SUCURSAL"].ToString();
                ctcxTo.COD_CLASE = rw["COD_CLASE"].ToString();
                ctcxTo.NRO_CONTRATO = rw["NRO_CONTRATO"].ToString();
                ctcxTo.FE_AÑO = rw["FE_AÑO"].ToString();
                ctcxTo.FE_MES = rw["FE_MES"].ToString();
                ctcxTo.COD_PER = rw["COD_PER"].ToString();
                ctcxTo.COD_DOC = rw["COD_DOC"].ToString();
                ctcxTo.NRO_DOC = sdoBLL.OBTENER_SERIE_NRO_BLL(sdoTo).Rows[0]["NUMERO"].ToString();
                ctcxTo.FECHA_CONTRATO = Convert.ToDateTime(rw["FECHA_CONTRATO"]);
                ctcxTo.FECHA_DOC = Convert.ToDateTime(rw["FECHA_DOC"]);
                ctcxTo.FECHA_VEN = Convert.ToDateTime(rw["FECHA_VEN"]);
                ctcxTo.COD_P_COBRANZA = rw["COD_P_COBRANZA"].ToString();
                ctcxTo.IMP_INI = Convert.ToDecimal(rw["IMP_INI"]);
                ctcxTo.COD_COBRADOR = rw["COD_COBRADOR"].ToString();
                ctcxTo.NRO_PLANILLA = rw["NRO_PLANILLA"].ToString();
                ctcxTo.FECHA_PLANILLA = Convert.ToDateTime(rw["FECHA_PLANILLA"]);
                ctcxTo.COD_D_H = rw["COD_D_H"].ToString();
                ctcxTo.COD_MONEDA = rw["COD_MONEDA"].ToString();
                ctcxTo.TIPO_CAMBIO = Convert.ToDecimal(rw["TIPO_CAMBIO"]);
                ctcxTo.IMP_DOC = Convert.ToDecimal(rw["IMP_INI"]);//Convert.ToDecimal(rw["IMP_DOC"]);//Esto se cambió a pedido de Don Miguel 11.01.18
                ctcxTo.OBSERVACION = rw["OBSERVACION"].ToString();
                ctcxTo.TIPO_OPE = rw["TIPO_OPE"].ToString();
                ctcxTo.NRO_LETRA = rw["NRO_LETRA"].ToString();
                ctcxTo.TOTAL_LETRA = rw["TOTAL_LETRA"].ToString();
                ctcxTo.COD_CONCEPTO = rw["COD_CONCEPTO"].ToString();
                ctcxTo.COD_USU_CREA = rw["COD_USU_CREA"].ToString();
                ctcxTo.FECHA_CREA = Convert.ToDateTime(rw["FECHA_CREA"]);

                //INSERTA EN P
                if (!ctpxDAL.insertarCanjePCtasxCobrarDAL(ctcxTo, ref errMensaje))//SE ADICIONO DOS CAMPOS NUEVOS TIPO_PLA_ORIGEN Y COBRANZA, EL VALOR SE AGREGA DIRECTAMENTE EN EL PROCEDURE
                    return result = false;
                //INSERTA EN T
                if (!cttxDAL.insertarCanjeTCtasxCobrarDAL(ctcxTo, ref errMensaje))//SE ADICIONO DOS CAMPOS NUEVOS TIPO_PLA_ORIGEN Y COBRANZA, EL VALOR SE AGREGA DIRECTAMENTE EN EL PROCEDURE
                    return result = false;
                //ACTUALIZA EL NUMERO EN SERIE_DOCUMENTO
                if (!sdoBLL.adicionaNroSerieBLL(sdoTo, ref errMensaje))
                    return result = false;
            }

            return result;
        }
        public bool ELIMINAR_I_CTAS_COBRAR_CANJE_BLL(canjeICtasxCobrarTo cicxcTo, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                //elimina ctacte del contrato
                if (!cicxDAL.ELIMINAR_I_CTAS_COBRAR_CANJE_DAL(cicxcTo, ref errMensaje))
                    return result = false;
                //elimina ventas del contrato cabecera
                contratoCabeceraBLL ccBLL = new contratoCabeceraBLL();
                contratoCabeceraTo ccTo = new contratoCabeceraTo();
                ccTo.NRO_PRESUPUESTO = cicxcTo.NRO_CONTRATO;
                if (!ccBLL.ELIMINAR_PEDID_X_NRO_CONTRATO_BLL(ccTo, ref errMensaje))
                    return result = false;
                //elimina ventas del contrato detalle
                contratoDetalleBLL dcBLL = new contratoDetalleBLL();
                contratoDetalleTo dcTo = new contratoDetalleTo();
                dcTo.NRO_PRESUPUESTO = cicxcTo.NRO_CONTRATO;
                if (!dcBLL.ELIMINAR_PEDIDO_X_NRO_CONTRATO_BLL(dcTo, ref errMensaje))
                    return result = false;
                //actualiza I_Presupuesto
                precontratoCabeceraBLL pcBLL = new precontratoCabeceraBLL();
                precontratoCabeceraTo pcTo = new precontratoCabeceraTo();
                pcTo.NRO_PRESUPUESTO = cicxcTo.NRO_CONTRATO;
                if (!pcBLL.actualizaPreContratoStatusCierre_x_NroContrato_BLL(pcTo, ref errMensaje))
                    return result = false;
                //actualiza T_Presupuesto
                precontratoDetalleBLL pdcBLL = new precontratoDetalleBLL();
                precontratoDetalleTo pdcTo = new precontratoDetalleTo();
                pdcTo.NRO_PRESUPUESTO = cicxcTo.NRO_CONTRATO;
                if (!pdcBLL.actualizaPreContratoDetalleCantidadAtendBLL(pdcTo, ref errMensaje))
                    return result = false;
                //elimina salida de almacen
                invTo.COD_SUCURSAL = cicxcTo.COD_SUCURSAL;
                invTo.COD_CLASE = cicxcTo.COD_CLASE;
                invTo.COD_PER = cicxcTo.COD_PER;
                invTo.COD_DOC_INV = "02";
                invTo.NRO_DOC_INV = cicxcTo.NRO_DOC_INV;
                invTo.FE_AÑO = cicxcTo.FE_AÑO;
                invTo.FE_MES = cicxcTo.FE_MES;
                if (!invBLL.ELIMINAR_NOTA_SALIDA_BLL(invTo, ref errMensaje))
                    return result = false;
                ts.Complete();
                return result;
            }
        }
        public bool Aprueba_Actualiza_Repciona_I_Planilla_I_CTAS_COBRAR_BLL(canjeICtasxCobrarTo cicxcTo, DataTable dt, ref string errMensaje)
        {
            bool result = true;
            DataTable dtPT = dt.AsEnumerable().Where(x => x.Field<string>("NRO_CONTRATO") != "0000000").CopyToDataTable();
            foreach (DataRow rw in dtPT.Rows)
            {
                cicxcTo.NRO_CONTRATO = rw["NRO_CONTRATO"].ToString();
                cicxcTo.FE_AÑO = rw["AÑO"].ToString();
                cicxcTo.FE_MES = rw["MES"].ToString();
                cicxcTo.IMP_DOC = Convert.ToDecimal(rw["IMP_COB"]);
                if (!cicxDAL.Aprueba_Actualiza_Repciona_I_Planilla_I_CTAS_COBRAR_DAL(cicxcTo, ref errMensaje))
                    return result = false;
            }
            return result;
        }
        public bool actualizaICtasCobrarxCobranzaDirectaBLL(canjeICtasxCobrarTo cicxcTo, ref string errMensaje)
        {
            bool result = true;
            if (!cicxDAL.actualizaICtasCobrarxCobranzaDirectaDAL(cicxcTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool insertaAdicionaCanjeICtasxCobrarxBloqueBLL(DataTable dtPT, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                canjeICtasxCobrarTo ccixcTo = new canjeICtasxCobrarTo();
                //CREAR_DT_PTCTAS();//se crea un datable con las columnas necesarias para llenar P y T Cuentas
                foreach (DataRow rw in dtPT.Rows)
                {
                    ccixcTo.COD_SUCURSAL = rw["COD_SUCURSAL"].ToString();// del combo
                    ccixcTo.COD_CLASE = rw["COD_CLASE"].ToString();
                    ccixcTo.NRO_CONTRATO = rw["NRO_PRESUPUESTO"].ToString();
                    ccixcTo.FE_AÑO = rw["AÑO"].ToString();
                    ccixcTo.FE_MES = rw["MES"].ToString();
                    ccixcTo.FECHA_CONTRATO = Convert.ToDateTime(rw["FECHA_PRE"]);
                    ccixcTo.FECHA_APROBACION = null;
                    ccixcTo.NRO_REPORTE = rw["NRO_REPORTE"].ToString();
                    ccixcTo.FECHA_REPORTE = Convert.ToDateTime(rw["FEC_REPORTE"]);
                    ccixcTo.COD_MONEDA = rw["COD_MONEDA"].ToString();
                    ccixcTo.TIPO_CAMBIO = Convert.ToDecimal(rw["TIPO_CAMBIO"]);
                    ccixcTo.IMP_DOC = Convert.ToDecimal(rw["TOTAL_CONTRATO"]);
                    ccixcTo.OBSERVACION = "";
                    ccixcTo.TIPO_OPE = "GF";
                    ccixcTo.COD_PER = rw["COD_PER"].ToString();
                    ccixcTo.NRO_CUOTAS = rw["NRO_CUOTAS"].ToString();
                    ccixcTo.IMP_DEVOLUCION = 0;
                    ccixcTo.FECHA_DEVOLUCION = null;
                    ccixcTo.COD_VENDEDOR = rw["COD_VENDEDOR"].ToString();
                    ccixcTo.COD_NIVEL1 = rw["COD_NIVEL1"].ToString();
                    ccixcTo.COD_NIVEL2 = rw["COD_NIVEL2"].ToString();
                    ccixcTo.COD_NIVEL3 = rw["COD_NIVEL3"].ToString();
                    ccixcTo.COD_PTO_COB = rw["COD_PTO_COB"].ToString();
                    ccixcTo.COD_USU_CREA = rw["COD_USU"].ToString();//
                    ccixcTo.FECHA_CREA = DateTime.Now;
                    ccixcTo.COD_SECTORISTA = rw["COD_SECTORISTA"].ToString();
                    ccixcTo.COD_TIPO_VENTA = rw["COD_TIPO_VENTA"].ToString();
                    ccixcTo.COD_MODALIDAD_VTA = rw["COD_MODALIDAD_VTA"].ToString();
                    ccixcTo.STATUS_PRE_APROB = "0";
                    ccixcTo.FECHA_DOC = Convert.ToDateTime(rw["FECHA_DOC"]);// fecha en la que se hace el proceso de crear las cuentas corrientes
                    ccixcTo.FECHA_VEN = Convert.ToDateTime(rw["FEC_PRIMER_VENC"]);
                    ccixcTo.IMP_INI = Convert.ToDecimal(rw["IMP_CUOTA_INICIAL"]);
                    ccixcTo.FECHA_VEN2 = Convert.ToDateTime(rw["FEC_CUO_MES"]);
                    ccixcTo.IMP_INI2 = Convert.ToDecimal(rw["IMP_CUOTA_MES"]);
                    //I
                    if (!insertarCanjeICtasxCobrarBLL(ccixcTo, ref errMensaje))
                        return result = false;
                    //P y T
                    if (!insertarCanjePTCtasxCobrarxBloqueBLL(ccixcTo, ref errMensaje))//dtPT se crea desde aqui
                        return result = false;
                    ////actualiza 
                    if (!actualizaPedido_Status_Cta_BLL(ccixcTo.COD_SUCURSAL, ccixcTo.NRO_CONTRATO, ref errMensaje))
                        return result = false;
                }

                ts.Complete();
                return result;
            }
        }
        public bool insertarCanjePTCtasxCobrarxBloqueBLL(canjeICtasxCobrarTo ccixcTo, ref string errMensaje)
        {
            //obtener numero cuota
            bool result = true;
            sdoTo.COD_SUCURSAL = ccixcTo.COD_SUCURSAL;
            sdoTo.STATUS_DOC = "0";
            sdoTo.COD_DOC = "42";
            sdoTo.SERIE = "001";
            //string nro_cuota = sdoBLL.OBTENER_SERIE_NRO_BLL(sdoTo).Rows[0]["NUMERO"].ToString();//obtenerNroCuota(ccixcTo.COD_SUCURSAL);
            int cant_cuotas = Convert.ToInt32(ccixcTo.NRO_CUOTAS);
            int i; decimal imp_ini = 0; DateTime fec_ven = DateTime.Now; decimal imp_final = 0;
            for (int j = 0; j < cant_cuotas; j++)
            {
                i = j + 1;
                ctcxTo.COD_SUCURSAL = ccixcTo.COD_SUCURSAL;
                ctcxTo.COD_CLASE = ccixcTo.COD_CLASE;
                ctcxTo.NRO_CONTRATO = ccixcTo.NRO_CONTRATO;
                ctcxTo.FE_AÑO = ccixcTo.FE_AÑO;
                ctcxTo.FE_MES = ccixcTo.FE_MES;
                ctcxTo.COD_PER = ccixcTo.COD_PER;
                ctcxTo.COD_DOC = "30";
                ctcxTo.NRO_DOC = sdoBLL.OBTENER_SERIE_NRO_BLL(sdoTo).Rows[0]["NUMERO"].ToString();// nro_cuota;
                ctcxTo.FECHA_CONTRATO = ccixcTo.FECHA_CONTRATO;
                ctcxTo.FECHA_DOC = ccixcTo.FECHA_DOC;
                ctcxTo.COD_P_COBRANZA = ccixcTo.COD_PTO_COB;
                if (i == 1)
                {
                    ctcxTo.FECHA_VEN = Convert.ToDateTime(ccixcTo.FECHA_VEN);
                    ctcxTo.IMP_INI = Convert.ToDecimal(ccixcTo.IMP_INI);
                    imp_ini += ctcxTo.IMP_INI;
                }
                else if (i == 2)
                {
                    ctcxTo.FECHA_VEN = Convert.ToDateTime(ccixcTo.FECHA_VEN2);
                    ctcxTo.IMP_INI = Convert.ToDecimal(ccixcTo.IMP_INI2);
                    imp_ini += ctcxTo.IMP_INI;
                    fec_ven = ctcxTo.FECHA_VEN.Value;
                }
                else if (i == cant_cuotas)
                {
                    fec_ven = fec_ven.AddDays(30);
                    ctcxTo.FECHA_VEN = fec_ven;
                    imp_final = ccixcTo.IMP_DOC;//total
                    ctcxTo.IMP_INI = imp_final - imp_ini;
                }
                else
                {
                    fec_ven = fec_ven.AddDays(30);
                    ctcxTo.FECHA_VEN = fec_ven;
                    ctcxTo.IMP_INI = Convert.ToDecimal(ccixcTo.IMP_INI2);
                    imp_ini += ctcxTo.IMP_INI;
                }
                ctcxTo.COD_COBRADOR = "";
                ctcxTo.NRO_PLANILLA = "";
                ctcxTo.FECHA_PLANILLA = Convert.ToDateTime(ccixcTo.FECHA_REPORTE);//solo lo pongo porque necesito una fecha deberia ser null
                ctcxTo.COD_D_H = "D";
                ctcxTo.COD_MONEDA = ccixcTo.COD_MONEDA;
                ctcxTo.TIPO_CAMBIO = ccixcTo.TIPO_CAMBIO;
                ctcxTo.IMP_DOC = Convert.ToDecimal(ctcxTo.IMP_INI);
                ctcxTo.OBSERVACION = "";
                ctcxTo.TIPO_OPE = ccixcTo.TIPO_OPE;
                ctcxTo.NRO_LETRA = i.ToString().PadLeft(3, '0');
                ctcxTo.TOTAL_LETRA = cant_cuotas.ToString().PadLeft(3, '0');
                ctcxTo.COD_CONCEPTO = "";
                ctcxTo.COD_USU_CREA = ccixcTo.COD_USU_CREA;
                ctcxTo.FECHA_CREA = Convert.ToDateTime(ccixcTo.FECHA_CREA);
                ctcxTo.TIPO_PLA_ORIGEN = ccixcTo.TIPO_PLA_ORIGEN;
                ctcxTo.TIPO_PLA_COBRANZA = ccixcTo.TIPO_PLA_COBRANZA;
                //INSERTA EN P
                if (!ctpxDAL.insertarCanjePCtasxCobrarDAL(ctcxTo, ref errMensaje))//SE ADICIONO DOS CAMPOS NUEVOS TIPO_PLA_ORIGEN Y COBRANZA, EL VALOR SE AGREGA DIRECTAMENTE EN EL PROCEDURE
                    return result = false;
                //INSERTA EN T
                if (!cttxDAL.insertarCanjeTCtasxCobrarDAL(ctcxTo, ref errMensaje))//SE ADICIONO DOS CAMPOS NUEVOS TIPO_PLA_ORIGEN Y COBRANZA, EL VALOR SE AGREGA DIRECTAMENTE EN EL PROCEDURE
                    return result = false;
                //ACTUALIZA EL NUMERO EN SERIE_DOCUMENTO
                if (!sdoBLL.adicionaNroSerieBLL(sdoTo, ref errMensaje))
                    return result = false;
            }
            return result;
        }

        public DataTable RptCuentasXCobrarMesXPuntoCobranza(string codPrograma, DateTime fechaVentaIni, DateTime fechaVentaFin, DateTime fechaAprobIni, DateTime fechaAproFin,
            DateTime fechaVenIni, DateTime fechaVenFin, string codPtoCob, int act)
        {
            return cicxDAL.RptCuentasXCobrarMesXPuntoCobranza(codPrograma, fechaVentaIni, fechaVentaFin, fechaAprobIni, fechaAproFin, fechaVenIni, fechaVenFin, codPtoCob, act);
        }

        public DataTable RptCuentasXCobrarC4(DateTime fechaVentaIni, DateTime fechaVentaFin, DateTime fechaAprobacionIni, DateTime fechaAprobacionFin, DateTime fechaVencimientoIni,
             DateTime fechaVencimientoFin, string codPrograma, string codCategoria, string codPer, int act)
        {
            return cicxDAL.RptCuentasXCobrarC4(fechaVentaIni, fechaVentaFin, fechaAprobacionIni, fechaAprobacionFin, fechaVencimientoIni, fechaVencimientoFin, codPrograma, codCategoria, codPer, act);
        }

        private string obtenerNroCuota(string COD_SUCURSAL)
        {
            sdoTo.COD_SUCURSAL = COD_SUCURSAL;
            //sdoTo.SERIE = "000";
            //sdoTo.COD_DOC = "41";
            sdoTo.STATUS_DOC = "0";
            sdoTo.COD_DOC = "42";
            //txt_nro_ini.Text = sdoBLL.obtenerNro_Ing2BLL(sdoTo);
            return sdoBLL.OBTENER_SERIE_NRO_BLL(sdoTo).Rows[0]["NUMERO"].ToString();
        }
        public bool VerificaExisteNroContratoEnviadoBLL(canjeICtasxCobrarTo cicxTo, ref string errMensaje)
        {
            bool result = true;
            if (!cicxDAL.VerificaExisteNroContratoEnviadoDAL(cicxTo, ref errMensaje))
                return result = false;
            return result;
        }
        public DataTable ConsultaEstadoCuentaKardexClienteBLL(canjeICtasxCobrarTo cicxTo)
        {
            return cicxDAL.ConsultaEstadoCuentaKardexClienteDAL(cicxTo);
        }
        public DataTable ConsultaEstadoCuentaKardexClienteDetalleBLL(canjeICtasxCobrarTo cicxTo)
        {
            return cicxDAL.ConsultaEstadoCuentaKardexClienteDetalleDAL(cicxTo);
        }
        public DataTable obtenerCuotasComprometidasxContratoBLL(canjeICtasxCobrarTo cicxTo)
        {
            return cicxDAL.obtenerCuotasComprometidasxContratoDAL(cicxTo);
        }
        public bool modificarICtasxCambioPtoCobBLL(canjeICtasxCobrarTo cicxTo, ref string errMensaje)
        {
            bool result = true;
            if (!cicxDAL.modificarICtasxCambioPtoCobDAL(cicxTo, ref errMensaje))
                return result = false;
            return result;
        }

        public DataTable RptCuentasXCobrarC5(DateTime fechaVentaIni, DateTime fechaVentaFin, DateTime fechaAprobacionIni, DateTime fechaAprobacionFin, DateTime fechaVencimientoIni,
            DateTime fechaVencimientoFin, string codPrograma, string codUbicacion, string codGrupoUbicacion, string codSubUbicacion, int act)
        {
            return cicxDAL.RptCuentasXCobrarC5(fechaVentaIni, fechaVentaFin, fechaAprobacionIni, fechaAprobacionFin, fechaVencimientoIni, fechaVencimientoFin, codPrograma, codUbicacion, codGrupoUbicacion, codSubUbicacion, act);
        }

        public bool eliminarICtasCobrarBLL(canjeICtasxCobrarTo cicxTo, ref string errMensaje)
        {
            bool result = true;
            if (!cicxDAL.eliminarICtasCobrarDAL(cicxTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool verifica_Movimiento_ContratoBLL(canjeICtasxCobrarTo cicxTo, ref string errMensaje)
        {
            bool result = true;
            if (!cicxDAL.verifica_Movimiento_ContratoDAL(cicxTo, ref errMensaje))
                return result = false;
            return result;
        }

        public DataTable RptCuentasXCobrarC6(DateTime fechaVentaIni, DateTime fechaVentaFin, DateTime fechaAprobacionIni, DateTime fechaAprobacionFin, DateTime fechaVencimientoIni,
            DateTime fechaVencimientoFin, string codPrograma, string codInstitucion, string subNivelInstitucion, int act)
        {
            return cicxDAL.RptCuentasXCobrarC6(fechaVentaIni, fechaVentaFin, fechaAprobacionIni, fechaAprobacionFin, fechaVencimientoIni, fechaVencimientoFin, codPrograma, codInstitucion, subNivelInstitucion, act);
        }

        public DataTable RptCuentasXCobrarC7(DateTime fechaVentaIni, DateTime fechaVentaFin, DateTime fechaAprobacionIni, DateTime fechaAprobacionFin, DateTime fechaVencimientoIni,
            DateTime fechaVencimientoFin, string codPrograma, string codDepartamento, string codInstitucion, string codNivelInst, int act)
        {
            return cicxDAL.RptCuentasXCobrarC7(fechaVentaIni, fechaVentaFin, fechaAprobacionIni, fechaAprobacionFin, fechaVencimientoIni, fechaVencimientoFin, codPrograma, codDepartamento, codInstitucion, codNivelInst, act);
        }

        public DataTable RptCuentasXCobrarC7_1(DateTime fechaVentaIni, DateTime fechaVentaFin, DateTime fechaAprobacionIni, DateTime fechaAprobacionFin, DateTime fechaVencimientoIni,
            DateTime fechaVencimientoFin, string codPrograma, string codDepartamento, string cod_pto_cob, int act)
        {
            return cicxDAL.RptCuentasXCobrarC7_1(fechaVentaIni, fechaVentaFin, fechaAprobacionIni, fechaAprobacionFin, fechaVencimientoIni, fechaVencimientoFin, codPrograma, codDepartamento, cod_pto_cob, act);
        }

        public DataTable RptCuentasXCobrarC8(DateTime fechaVentaIni, DateTime fechaVentaFin, DateTime fechaAprobacionIni, DateTime fechaAprobacionFin, DateTime fechaVencimientoIni,
            DateTime fechaVencimientoFin, string codPrograma, string codPtoCob, string codUbicacion, int act)
        {
            return cicxDAL.RptCuentasXCobrarC8(fechaVentaIni, fechaVentaFin, fechaAprobacionIni, fechaAprobacionFin, fechaVencimientoIni, fechaVencimientoFin, codPrograma, codPtoCob, codUbicacion, act);
        }
    }
}
