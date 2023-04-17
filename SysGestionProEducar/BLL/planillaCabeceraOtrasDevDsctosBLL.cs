using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Transactions;

namespace BLL
{
    public class planillaCabeceraOtrasDevDsctosBLL
    {
        planillaCabeceraOtrasDevDsctosDAL plcDAL = new planillaCabeceraOtrasDevDsctosDAL();
        planillaDetalleOtrasDevDsctosBLL pldBLL = new planillaDetalleOtrasDevDsctosBLL();
        planillaDetalleOtrasDevDsctosTo pldTo = new planillaDetalleOtrasDevDsctosTo();
        devPCtasCobrarBLL dpcBLL = new devPCtasCobrarBLL();
        devPCtasCobrarTo dpcTo = new devPCtasCobrarTo();
        resumenPlanillaDevolucionBLL rpdBLL = new resumenPlanillaDevolucionBLL();
        resumenPlanillaDevolucionTo rpdTo = new resumenPlanillaDevolucionTo();
        DataTable detPlla = new DataTable();
        public DataTable obtenerPlanillaCabeceraOtrasDevDsctosPendientesDAL()
        {
            return plcDAL.obtenerPlanillaCabeceraOtrasDevDsctosPendientesDAL();
        }
        public DataTable obtenerPlanillaCabeceraOtrasDevDsctosDAL(planillaCabeceraOtrasDevDsctosTo plcTo)
        {
            return plcDAL.obtenerPlanillaCabeceraOtrasDevDsctosDAL(plcTo);
        }
        public DataTable obtenerPlanillaCabeceraDescuentoDirectaBLL(planillaCabeceraOtrasDevDsctosTo plcTo)
        {
            return plcDAL.obtenerPlanillaCabeceraDescuentoDirectaDAL(plcTo);
        }
        public bool insertarPlanillasOtrasDevDsctosBLL(planillaCabeceraOtrasDevDsctosTo plcTo, DataTable dtDetalle, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                //I
                if (!insertarPlanillaCabeceraOtrasDevDsctosBLL(plcTo, ref errMensaje))
                    return result = false;
                //T
                if (!ingresarPlanillaDetalleOtrasDevDsctosBLL(plcTo, dtDetalle, ref errMensaje))
                    return result = false;
                //adiciona en uno el contador
                if (!HelpersBLL.estableceNuevoNumeroContador(plcTo.COD_SUCURSAL, plcTo.COD_DOC, plcTo.STATUS_DOC, plcTo.SERIE, ref errMensaje))
                    return result = false;
                if (plcTo.TIPO_PLANILLA_DOC != "PD")//si es directa es que no ha venido de un ingreso de otras dev y dsctos
                {
                    //actualiza DEV_PCTAS_COBRAR, status_generado=1
                    if (!actualizaDevPCtasBLL(plcTo, dtDetalle, ref errMensaje))
                        return result = false;
                }

                ts.Complete();
                return result;
            }
        }

        public bool InsertarPlanillasOtrasDevDsctosBLL(List<planillaCabeceraOtrasDevDsctosTo> lstPlcTo, DataTable dtDetalle, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions
            {
                IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted,
                Timeout = new TimeSpan(0, 2, 0)
            };
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                int index = 0;
                DataTable dt = null;
                foreach (planillaCabeceraOtrasDevDsctosTo plcTo in lstPlcTo)
                {
                    //I
                    if (!insertarPlanillaCabeceraOtrasDevDsctosBLL(plcTo, ref errMensaje))
                        return false;
                    //T
                    dt = dtDetalle.Rows[index].Table;
                    if (!ingresarPlanillaDetalleOtrasDevDsctosBLL(plcTo, dt, ref errMensaje))
                        return false;
                    //adiciona en uno el contador
                    if (!HelpersBLL.estableceNuevoNumeroContador(plcTo.COD_SUCURSAL, plcTo.COD_DOC, plcTo.STATUS_DOC, plcTo.SERIE, ref errMensaje))
                        return false;
                    if (plcTo.TIPO_PLANILLA_DOC != "PD")//si es directa es que no ha venido de un ingreso de otras dev y dsctos
                    {
                        //actualiza DEV_PCTAS_COBRAR, status_generado=1
                        if (!actualizaDevPCtasBLL(plcTo, dt, ref errMensaje))
                            return false;
                    }
                    index += 1;
                }

                ts.Complete();
                return true;
            }
        }

        public bool modificarPlanillasOtrasDevDsctosBLL(planillaCabeceraOtrasDevDsctosTo plcTo, DataTable dtDetalle, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                //I
                if (!modificarPlanillaCabeceraOtrasDevDsctosBLL(plcTo, ref errMensaje))
                    return result = false;
                //elimina T
                if (!eliminarPlanillaDetalleOtrasDevDsctosBLL(plcTo, ref errMensaje))
                    return result = false;
                //T
                if (!ingresarPlanillaDetalleOtrasDevDsctosBLL(plcTo, dtDetalle, ref errMensaje))
                    return result = false;

                ts.Complete();
                return result;
            }
        }
        public bool aprobarPlanillasDescuentoDirectaBLL(planillaCabeceraTo pllcTo, planillaCabeceraOtrasDevDsctosTo plcTo, DataTable dt, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                planillaCabeceraBLL pllacBLL = new planillaCabeceraBLL();
                //aquí cambié el orden como en descuento I, P y T antes era T, P y I
                //I_CTAS
                if (!pllacBLL.Aprueba_Actualiza_Repciona_I_CTAS_COBRAR_BLL(pllcTo, dt, ref errMensaje))
                    return result = false;
                //PCTAS
                if (!pllacBLL.Aprueba_Actualiza_Repciona_PCTAS_COBRAR_Planilla_Detalle_BLL(pllcTo, dt, ref errMensaje))//
                    return result = false;
                //TCTAS
                if (!pllacBLL.Aprueba_Adiciona_Repciona_T_Planilla_Detalle_BLL(pllcTo, dt, ref errMensaje))//
                    return result = false;
                //I_PLANILLA_OTRAS_DEV_DSCTOS
                if (!aprueba_Actualiza_I_PLANILLA_OTRAS_DEV_DSCTOS_BLL(plcTo, ref errMensaje))
                    return result = false;
                // R_PLANILLA y RT_PLANILLA
                if (!pllacBLL.Aprueba_Adiciona_Recepciona_R_Planilla_BLL(pllcTo, dt, ref errMensaje))
                    return result = false;
                //DEV_PCTAS_COBRAR y DEV_TCTAS_COBRAR
                if (!pllacBLL.Aprueba_Adiciona_DEV_PCTAS_COBRAR_BLL(pllcTo, dt, ref errMensaje))
                    return result = false;
                ts.Complete();
                return result;
            }
        }

        public bool aprobarPlanillasOtrasDevDsctosBLL(planillaCabeceraOtrasDevDsctosTo plcTo, DataTable dtDetalle, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                string cuota_comprometida = plcTo.STATUS_COMPROM;
                //TABLAS DE DEVOLUCIONES
                //DEV_TCTAS_COBRAR
                if (!aprueba_Adiciona_DEV_TCTAS_COBRAR_BLL(plcTo, dtDetalle, ref errMensaje))
                    return result = false;
                //DEV_PCTAS_COBRAR
                if (!aprueba_Actualiza_DEV_PCTAS_COBRAR_BLL(plcTo, dtDetalle, ref errMensaje))
                    return result = false;
                //TABLAS DE CUENTA CORRIENTE
                if (plcTo.STATUS_CTACTE == "1")//afecta cuenta corriente
                {
                    //CREAR TABLA DETALLE
                    creaTablaDetalle();
                    //TABLA CON LAS CUOTAS NO CANCELADAS
                    DataTable dtCuotas = obtieneCuotasNoCanceladasBLL(plcTo);
                    DataTable dtComprometidas = null;
                    decimal monto = plcTo.IMPORTE_TOTAL;
                    if (dtCuotas.Rows.Count > 0)
                    {
                        if (plcTo.TIPO_PLANILLA_DOC == "XM")//Devolucion de Mercaderias + importe que se compromete el cliente a realizar de la cuota más antigua
                        {
                            dtCuotas.DefaultView.Sort = "NRO_LETRA DESC";
                            dtCuotas = dtCuotas.DefaultView.ToTable();
                            dtComprometidas = obtenerCuotasComprometidasSoloContrato(plcTo);
                        }
                        else if (plcTo.TIPO_PLANILLA_DOC == "DM")
                            dtComprometidas = obtenerCuotasComprometidasSoloContrato(plcTo);
                        foreach (DataRow rw in dtCuotas.Rows)
                        {
                            if (monto >= 0)
                            {
                                DataRow row = detPlla.NewRow();
                                row["NRO_PLANILLA_COB"] = plcTo.NRO_PLANILLA_DOC;
                                row["COD_INSTITUCION"] = plcTo.COD_INSTITUCION;
                                row["COD_PTO_COB_CONSOLIDADO"] = plcTo.COD_PTO_COB;
                                row["COD_CANAL_DSCTO"] = plcTo.COD_CANAL_DSCTO;
                                row["FE_AÑO"] = plcTo.FE_AÑO;
                                row["FE_MES"] = plcTo.FE_MES;
                                row["NRO_CONTRATO"] = plcTo.NRO_CONTRATO;
                                row["COD_DOC"] = rw["COD_DOC"];
                                row["NRO_DOC"] = rw["NRO_DOC"];
                                row["IMP_DOC"] = rw["IMP_DOC"];
                                if (monto >= Convert.ToDecimal(row["IMP_DOC"]))
                                    row["IMP_COB"] = row["IMP_DOC"];
                                else
                                    row["IMP_COB"] = monto;
                                monto -= Convert.ToDecimal(rw["IMP_DOC"]);
                                row["IMP_COB_CTA_CTE"] = 0;
                                row["IMP_DEV"] = 0;
                                row["NRO_LETRA"] = rw["NRO_LETRA"];
                                row["TOT_LETRA"] = rw["TOTAL_LETRA"];
                                row["COD_PTO_COB"] = row["COD_PTO_COB_CONSOLIDADO"];
                                row["FECHA_RECEPCION"] = plcTo.FECHA_PLANILLA_DOC;
                                row["COD_COBRADOR"] = "";
                                row["FECHA_PLANILLA_COB"] = row["FECHA_RECEPCION"];
                                row["OBSERVACION"] = plcTo.OBSERVACIONES;
                                row["FECHA_VEN"] = rw["FECHA_VEN"];
                                row["FECHA_CONTRATO"] = rw["FECHA_PRE"];
                                row["TIPO_CAMBIO"] = rw["TIPO_CAMBIO"];
                                row["AÑO"] = rw["AÑO"];
                                row["MES"] = rw["MES"];
                                row["COD_MOTIVO_NO_DESCONTADO"] = "";
                                row["DESC_PER"] = "";
                                detPlla.Rows.Add(row);
                            }
                            else
                                break;
                        }
                    }
                    if (dtComprometidas != null)
                    {
                        if (cuota_comprometida == "0")
                        {
                            if (dtComprometidas.Rows.Count > 0 && (plcTo.TIPO_PLANILLA_DOC == "DM" || plcTo.TIPO_PLANILLA_DOC == "XM"))
                            {
                                for (int i = 0; i < dtComprometidas.Rows.Count; i++)
                                {
                                    if (monto > 0)//&& Convert.ToDecimal(dtComprometidas.Rows[i]["IMP_INI"]) == Convert.ToDecimal(dtComprometidas.Rows[i]["IMP_DOC"]))
                                    {
                                        DataRow row = detPlla.NewRow();
                                        row["NRO_PLANILLA_COB"] = plcTo.NRO_PLANILLA_DOC;
                                        row["COD_INSTITUCION"] = plcTo.COD_INSTITUCION;
                                        row["COD_PTO_COB_CONSOLIDADO"] = plcTo.COD_PTO_COB;
                                        row["COD_CANAL_DSCTO"] = plcTo.COD_CANAL_DSCTO;
                                        row["FE_AÑO"] = plcTo.FE_AÑO;
                                        row["FE_MES"] = plcTo.FE_MES;
                                        row["NRO_CONTRATO"] = plcTo.NRO_CONTRATO;
                                        row["COD_DOC"] = dtComprometidas.Rows[i]["COD_DOC"];
                                        row["NRO_DOC"] = dtComprometidas.Rows[i]["NRO_DOC"];
                                        row["IMP_DOC"] = dtComprometidas.Rows[i]["IMP_DOC"];
                                        //row["IMP_COB"] = i != 0 ? dtComprometidas.Rows[i - 1]["IMP_DOC"] : dtComprometidas.Rows[i]["IMP_DOC"];//REVISAR PORQUE LE PUSE ESTO
                                        if (monto >= Convert.ToDecimal(dtComprometidas.Rows[i]["IMP_DOC"]))
                                            row["IMP_COB"] = row["IMP_DOC"];
                                        else
                                            row["IMP_COB"] = monto;
                                        monto -= Convert.ToDecimal(dtComprometidas.Rows[i]["IMP_DOC"]);
                                        row["IMP_COB_CTA_CTE"] = 0;
                                        row["IMP_DEV"] = 0;
                                        row["NRO_LETRA"] = dtComprometidas.Rows[i]["NRO_LETRA"];
                                        row["TOT_LETRA"] = dtComprometidas.Rows[i]["TOTAL_LETRA"];
                                        row["COD_PTO_COB"] = row["COD_PTO_COB_CONSOLIDADO"];
                                        row["FECHA_RECEPCION"] = plcTo.FECHA_PLANILLA_DOC;
                                        row["COD_COBRADOR"] = "";
                                        row["FECHA_PLANILLA_COB"] = row["FECHA_RECEPCION"];
                                        row["OBSERVACION"] = plcTo.OBSERVACIONES;
                                        row["FECHA_VEN"] = dtComprometidas.Rows[i]["FECHA_VEN"];
                                        row["FECHA_CONTRATO"] = dtComprometidas.Rows[i]["FECHA_PRE"];
                                        row["TIPO_CAMBIO"] = dtComprometidas.Rows[i]["TIPO_CAMBIO"];
                                        row["AÑO"] = dtComprometidas.Rows[i]["AÑO"];
                                        row["MES"] = dtComprometidas.Rows[i]["MES"];
                                        row["COD_MOTIVO_NO_DESCONTADO"] = "";
                                        row["DESC_PER"] = "";
                                        detPlla.Rows.Add(row);
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (dtComprometidas.Rows.Count > 0 && (plcTo.TIPO_PLANILLA_DOC == "DM" || plcTo.TIPO_PLANILLA_DOC == "XM"))
                            {
                                for (int i = 0; i < dtComprometidas.Rows.Count; i++)
                                {
                                    if (monto > 0 && Convert.ToDecimal(dtComprometidas.Rows[i]["IMP_INI"]) == Convert.ToDecimal(dtComprometidas.Rows[i]["IMP_DOC"]))
                                    {
                                        DataRow row = detPlla.NewRow();
                                        row["NRO_PLANILLA_COB"] = plcTo.NRO_PLANILLA_DOC;
                                        row["COD_INSTITUCION"] = plcTo.COD_INSTITUCION;
                                        row["COD_PTO_COB_CONSOLIDADO"] = plcTo.COD_PTO_COB;
                                        row["COD_CANAL_DSCTO"] = plcTo.COD_CANAL_DSCTO;
                                        row["FE_AÑO"] = plcTo.FE_AÑO;
                                        row["FE_MES"] = plcTo.FE_MES;
                                        row["NRO_CONTRATO"] = plcTo.NRO_CONTRATO;
                                        row["COD_DOC"] = dtComprometidas.Rows[i]["COD_DOC"];
                                        row["NRO_DOC"] = dtComprometidas.Rows[i]["NRO_DOC"];
                                        row["IMP_DOC"] = dtComprometidas.Rows[i]["IMP_DOC"];
                                        row["IMP_COB"] = i != 0 ? dtComprometidas.Rows[i - 1]["IMP_DOC"] : dtComprometidas.Rows[i]["IMP_DOC"];//REVISAR PORQUE LE PUSE ESTO
                                        //if (monto >= Convert.ToDecimal(dtComprometidas.Rows[i]["IMP_DOC"]))
                                        //    row["IMP_COB"] = row["IMP_DOC"];
                                        //else
                                        //    row["IMP_COB"] = monto;
                                        monto -= Convert.ToDecimal(dtComprometidas.Rows[i]["IMP_DOC"]);
                                        row["IMP_COB_CTA_CTE"] = 0;
                                        row["IMP_DEV"] = 0;
                                        row["NRO_LETRA"] = dtComprometidas.Rows[i]["NRO_LETRA"];
                                        row["TOT_LETRA"] = dtComprometidas.Rows[i]["TOTAL_LETRA"];
                                        row["COD_PTO_COB"] = row["COD_PTO_COB_CONSOLIDADO"];
                                        row["FECHA_RECEPCION"] = plcTo.FECHA_PLANILLA_DOC;
                                        row["COD_COBRADOR"] = "";
                                        row["FECHA_PLANILLA_COB"] = row["FECHA_RECEPCION"];
                                        row["OBSERVACION"] = plcTo.OBSERVACIONES;
                                        row["FECHA_VEN"] = dtComprometidas.Rows[i]["FECHA_VEN"];
                                        row["FECHA_CONTRATO"] = dtComprometidas.Rows[i]["FECHA_PRE"];
                                        row["TIPO_CAMBIO"] = dtComprometidas.Rows[i]["TIPO_CAMBIO"];
                                        row["AÑO"] = dtComprometidas.Rows[i]["AÑO"];
                                        row["MES"] = dtComprometidas.Rows[i]["MES"];
                                        row["COD_MOTIVO_NO_DESCONTADO"] = "";
                                        row["DESC_PER"] = "";
                                        detPlla.Rows.Add(row);
                                    }
                                }
                            }
                        }
                    }

                    //
                    planillaCabeceraBLL pccBLL = new planillaCabeceraBLL();
                    planillaCabeceraTo pccTo = new planillaCabeceraTo();
                    pccTo.NRO_PLANILLA_COB = plcTo.NRO_PLANILLA_DOC;
                    pccTo.COD_INSTITUCION = plcTo.COD_INSTITUCION;
                    pccTo.COD_PTO_COB_CONSOLIDADO = plcTo.COD_PTO_COB;
                    pccTo.COD_CANAL_DSCTO = plcTo.COD_CANAL_DSCTO;
                    pccTo.FE_AÑO = plcTo.FE_AÑO;
                    pccTo.FE_MES = plcTo.FE_MES;
                    pccTo.COD_MOD = plcTo.COD_CREA;
                    pccTo.FECHA_MOD = plcTo.FECHA_CREA;
                    pccTo.COD_SUCURSAL = plcTo.COD_SUCURSAL;
                    pccTo.COD_CLASE = plcTo.COD_CLASE;
                    pccTo.COD_SECTORISTA = "";
                    pccTo.FECHA_PLANILLA_COB = plcTo.FECHA_PLANILLA_DOC;
                    pccTo.FECHA_RECEPCION = pccTo.FECHA_PLANILLA_COB;
                    pccTo.OBSERVACION = plcTo.OBSERVACIONES;
                    pccTo.TIPO_PLANILLA = plcTo.TIPO_PLANILLA_DOC;
                    pccTo.IMP_RECEPCION_CTA_CTE = 0;
                    pccTo.IMP_RECEPCION_DEV = 0;

                    if (detPlla.Rows.Count > 0)
                    {
                        //I_CTAS
                        if (!Aprueba_Actualiza_Repciona_I_CTAS_COBRAR(pccTo, detPlla, ref errMensaje))
                            return result = false;
                        //PCTAS
                        if (!Aprueba_Actualiza_Repciona_PCTAS_COBRAR_Planilla_Detalle(pccTo, detPlla, ref errMensaje))//
                            return result = false;
                        //TCTAS
                        if (!Aprueba_Adiciona_Repciona_T_Planilla_Detalle(pccTo, detPlla, ref errMensaje))//
                            return result = false;
                    }
                    detPlla.Reset();
                }
                if (plcTo.COD_VENTA == "DEV")
                {
                    //RESUMENES DE DEVOLUCION
                    if (!aprueba_Actualiza_Adiciona_Planilla_Devolucion_BLL(plcTo, ref errMensaje))
                        return result = false;
                    //DEV_PCTAS_COBRAR y DEV_TCTAS_COBRAR
                    planillaCabeceraBLL pccBLL = new planillaCabeceraBLL();
                    if (!Aprueba_Adiciona_DEV_PCTAS_COBRAR_BLL(plcTo, dtDetalle, ref errMensaje))
                        return result = false;
                }
                //I_PLANILLA_OTRAS_DEV_DSCTOS
                if (!aprueba_Actualiza_I_PLANILLA_OTRAS_DEV_DSCTOS_BLL(plcTo, ref errMensaje))
                    return result = false;

                ts.Complete();
                return result;
            }
        }
        private bool Aprueba_Adiciona_DEV_PCTAS_COBRAR_BLL(planillaCabeceraOtrasDevDsctosTo plcTo, DataTable dt, ref string errMensaje)
        {
            bool result = true;

            devPCtasCobrarDAL dpxDAL = new devPCtasCobrarDAL();
            devPCtasCobrarTo dpxTo = new devPCtasCobrarTo();
            contratoCabeceraBLL ccBLL = new contratoCabeceraBLL();
            contratoCabeceraTo ccTo = new contratoCabeceraTo();

            ccTo.NRO_PRESUPUESTO = dt.Rows[0]["NRO_CONTRATO"].ToString(); //***** todos son los mismos contratos
            DataTable dtCon = ccBLL.obtenerDatosdeContratoBLL(ccTo);
            if (dtCon.Rows.Count > 0)
            {
                dpxTo.NRO_PLANILLA_COB = dt.Rows[0]["NRO_PLANILLA_COB"].ToString();    //*******
                dpxTo.COD_SUCURSAL = plcTo.COD_SUCURSAL;
                dpxTo.COD_CLASE = plcTo.COD_CLASE;
                dpxTo.NRO_CONTRATO = dt.Rows[0]["NRO_CONTRATO"].ToString();  //******
                dpxTo.FE_AÑO = plcTo.FE_AÑO;
                dpxTo.FE_MES = plcTo.FE_MES;
                dpxTo.COD_PER = dt.Rows[0]["COD_PER"].ToString();//"";   //******* ---------------
                dpxTo.DESC_PER = dtCon.Rows[0]["DESC_PER"].ToString();
                dpxTo.COD_DOC = "";
                dpxTo.NRO_DOC = "0000000";
                dpxTo.FECHA_DOC = Convert.ToDateTime(dt.Rows[0]["FECHA_PLANILLA_COB"]);
                dpxTo.FECHA_VEN = null;   //*****
                dpxTo.IMP_INI = Convert.ToDecimal(dt.Rows[0]["IMP_COB"]);// 0;   //******* 
                dpxTo.IMP_DOC = Convert.ToDecimal(dt.Rows[0]["IMP_COB"]);//aqui estoy poniendo lo que se devolvera aunque creo que era para otra cosa. DEBE SER IMP_DEV
                dpxTo.COD_MOTIVO_NO_DESCONTADO = "006";
                dpxTo.COD_D_H = "D";
                dpxTo.OBSERVACION = "";
                dpxTo.COD_MONEDA = "S";
                dpxTo.TIPO_OPE = "GF";
                dpxTo.NRO_LETRA = "000";
                dpxTo.TOTAL_LETRA = "000";
                dpxTo.STATUS_GENERADO = "0";
                dpxTo.STATUS_CANCELADO = "0";
                dpxTo.TIPO_PLA_ORIGEN = "P";
                dpxTo.TIPO_PLA_COBRANZA = "DE";//devolucion exceso contrato
                dpxTo.COD_USU_CREA = plcTo.COD_CREA;
                dpxTo.FECHA_CREA = plcTo.FECHA_CREA;
                dpxTo.FECHA_CONTRATO = null;
                dpxTo.COD_P_COBRANZA = dtCon.Rows[0]["COD_PTO_COB"].ToString();
                dpxTo.FECHA_PLANILLA = Convert.ToDateTime(dt.Rows[0]["FECHA_PLANILLA_COB"]);    //******

                //DEV_PCTAS_COBRAR
                if (!dpxDAL.insertarDevPCtasCobrarDAL(dpxTo, ref errMensaje))
                    return result = false;
                //DEV_TCTAS_COBRAR
                if (!aprueba_adiciona_DEV_TCTAS_COBRAR_BLL(dpxTo, ref errMensaje))
                    return result = false;

            }

            return result;
        }
        public bool aprueba_adiciona_DEV_TCTAS_COBRAR_BLL(devPCtasCobrarTo dpxTo, ref string errMensaje)
        {
            bool result = true;
            devTCtasCobrarBLL dtxBLL = new devTCtasCobrarBLL();
            devTCtasCobrarTo dtxTo = new devTCtasCobrarTo();
            dtxTo.NRO_PLANILLA_COB = dpxTo.NRO_PLANILLA_COB;
            dtxTo.COD_SUCURSAL = dpxTo.COD_SUCURSAL;
            dtxTo.COD_CLASE = dpxTo.COD_CLASE;
            dtxTo.NRO_CONTRATO = dpxTo.NRO_CONTRATO;
            dtxTo.FE_AÑO = dpxTo.FE_AÑO;
            dtxTo.FE_MES = dpxTo.FE_MES;
            dtxTo.COD_PER = dpxTo.COD_PER;
            dtxTo.DESC_PER = dpxTo.DESC_PER;
            dtxTo.COD_DOC = dpxTo.COD_DOC;
            dtxTo.NRO_DOC = dpxTo.NRO_DOC;
            dtxTo.FECHA_CONTRATO = dpxTo.FECHA_CONTRATO;
            dtxTo.FECHA_DOC = dpxTo.FECHA_DOC;
            dtxTo.FECHA_VEN = dpxTo.FECHA_VEN;
            dtxTo.COD_P_COBRANZA = dpxTo.COD_P_COBRANZA;
            dtxTo.COD_COBRADOR = "";// dpxTo.COD_COBRADOR; por el momento así, parece que no se usa
            dtxTo.NRO_PLANILLA = dpxTo.NRO_PLANILLA_COB;
            dtxTo.FECHA_PLANILLA = dpxTo.FECHA_PLANILLA;
            dtxTo.COD_MOTIVO_NO_DESCONTADO = dpxTo.COD_MOTIVO_NO_DESCONTADO;
            dtxTo.COD_D_H = dpxTo.COD_D_H;
            dtxTo.COD_MONEDA = dpxTo.COD_MONEDA;
            dtxTo.TIPO_CAMBIO = 0;//dpxTo.TIPO_CAMBIO;
            dtxTo.IMP_DOC = dpxTo.IMP_DOC;
            dtxTo.OBSERVACION = dpxTo.OBSERVACION;
            dtxTo.TIPO_OPE = dpxTo.TIPO_OPE;
            dtxTo.NRO_LETRA = dpxTo.NRO_LETRA;
            dtxTo.TOTAL_LETRA = dpxTo.TOTAL_LETRA;
            dtxTo.COD_CONCEPTO = "";//dpxTo.COD_CONCEPTO;
            dtxTo.TIPO_PLA_ORIGEN = dpxTo.TIPO_PLA_ORIGEN;
            dtxTo.TIPO_PLA_COBRANZA = dpxTo.TIPO_PLA_COBRANZA;
            dtxTo.COD_USU_CREA = dpxTo.COD_USU_CREA;
            dtxTo.COD_USU_MOD = dpxTo.COD_USU_MOD;
            dtxTo.FECHA_CREA = DateTime.Now;

            if (!dtxBLL.insertarDevTCtasCobrarBLL(dtxTo, ref errMensaje))
                return result = false;
            return result;
        }
        private bool Aprueba_Adiciona_Recepciona_R_Planilla(planillaCabeceraTo pccTo, DataTable dt, ref string errMensaje)
        {
            bool result = true;
            planillaCabeceraBLL pccBLL = new planillaCabeceraBLL();

            if (!pccBLL.Aprueba_Adiciona_Recepciona_R_Planilla_BLL(pccTo, dt, ref errMensaje))
                return result = false;
            return result;
        }
        private bool Aprueba_Actualiza_Repciona_I_CTAS_COBRAR(planillaCabeceraTo pccTo, DataTable dt, ref string errMensaje)
        {
            bool result = true;
            planillaCabeceraBLL pccBLL = new planillaCabeceraBLL();

            if (!pccBLL.Aprueba_Actualiza_Repciona_I_CTAS_COBRAR_BLL(pccTo, dt, ref errMensaje))
                return result = false;
            return result;
        }
        private bool Aprueba_Actualiza_Repciona_PCTAS_COBRAR_Planilla_Detalle(planillaCabeceraTo pccTo, DataTable dt, ref string errMensaje)
        {
            bool result = true;
            planillaCabeceraBLL pccBLL = new planillaCabeceraBLL();

            if (!pccBLL.Aprueba_Actualiza_Repciona_PCTAS_COBRAR_Planilla_Detalle_BLL(pccTo, dt, ref errMensaje))
                return result = false;
            return result;
        }
        private bool Aprueba_Adiciona_Repciona_T_Planilla_Detalle(planillaCabeceraTo pccTo, DataTable dt, ref string errMensaje)
        {
            bool result = true;
            planillaCabeceraBLL pccBLL = new planillaCabeceraBLL();

            if (!pccBLL.Aprueba_Adiciona_Repciona_T_Planilla_Detalle_BLL(pccTo, dt, ref errMensaje))
                return result = false;
            return result;
        }
        private void creaTablaDetalle()
        {
            detPlla.Columns.Add("NRO_PLANILLA_COB");
            detPlla.Columns.Add("COD_PTO_COB_CONSOLIDADO");
            detPlla.Columns.Add("COD_CANAL_DSCTO");
            detPlla.Columns.Add("FE_AÑO");
            detPlla.Columns.Add("FE_MES");
            detPlla.Columns.Add("NRO_CONTRATO");
            detPlla.Columns.Add("COD_PER");
            detPlla.Columns.Add("COD_DOC");
            detPlla.Columns.Add("COD_INSTITUCION");
            detPlla.Columns.Add("NRO_DOC");
            detPlla.Columns.Add("IMP_DOC", typeof(decimal));
            detPlla.Columns.Add("IMP_COB", typeof(decimal));
            detPlla.Columns.Add("IMP_COB_CTA_CTE", typeof(decimal));
            detPlla.Columns.Add("IMP_DEV", typeof(decimal));
            detPlla.Columns.Add("NRO_LETRA");
            detPlla.Columns.Add("TOT_LETRA");
            detPlla.Columns.Add("COD_PTO_COB");
            detPlla.Columns.Add("FECHA_RECEPCION");
            detPlla.Columns.Add("COD_COBRADOR");
            detPlla.Columns.Add("FECHA_PLANILLA_COB");
            detPlla.Columns.Add("OBSERVACION");
            detPlla.Columns.Add("FECHA_VEN");
            detPlla.Columns.Add("FECHA_CONTRATO");
            detPlla.Columns.Add("TIPO_CAMBIO");
            detPlla.Columns.Add("AÑO");
            detPlla.Columns.Add("MES");
            detPlla.Columns.Add("COD_MOTIVO_NO_DESCONTADO");
            detPlla.Columns.Add("DESC_PER");
        }
        private DataTable obtieneCuotasNoCanceladasBLL(planillaCabeceraOtrasDevDsctosTo plcTo)
        {
            DataTable dt;
            canjePCtasxCobrarBLL pccBLL = new canjePCtasxCobrarBLL();
            canjePCtasxCobrarTo pccTo = new canjePCtasxCobrarTo();
            pccTo.COD_SUCURSAL = plcTo.COD_SUCURSAL;
            pccTo.COD_CLASE = plcTo.COD_CLASE;
            pccTo.NRO_CONTRATO = plcTo.NRO_CONTRATO;
            return dt = pccBLL.obtenerCuotasPendientesxContratoBLL(pccTo);
        }
        private DataTable obtenerCuotasComprometidasSoloContrato(planillaCabeceraOtrasDevDsctosTo plcTo)
        {
            DataTable dt;
            canjePCtasxCobrarBLL pccBLL = new canjePCtasxCobrarBLL();
            canjePCtasxCobrarTo pccTo = new canjePCtasxCobrarTo();
            pccTo.COD_SUCURSAL = plcTo.COD_SUCURSAL;
            pccTo.COD_CLASE = plcTo.COD_CLASE;
            pccTo.NRO_CONTRATO = plcTo.NRO_CONTRATO;
            return dt = pccBLL.obtenerCuotasComprometidasSoloContratoBLL(pccTo);
        }
        private bool aprueba_Actualiza_Adiciona_Planilla_Devolucion_BLL(planillaCabeceraOtrasDevDsctosTo plcTo, ref string errMensaje)
        {
            bool result = true;
            rpdTo.NRO_PLANILLA_DOC = plcTo.NRO_PLANILLA_DOC;
            rpdTo.COD_INSTITUCION = plcTo.COD_INSTITUCION;
            rpdTo.COD_PTO_COB_CONSOLIDADO = "";
            rpdTo.COD_CANAL_DSCTO = plcTo.COD_CANAL_DSCTO;
            rpdTo.FE_AÑO = plcTo.FE_AÑO;
            rpdTo.FE_MES = plcTo.FE_MES;
            rpdTo.COD_SUCURSAL = plcTo.COD_SUCURSAL;
            rpdTo.FECHA_PLANILLA_DOC = plcTo.FECHA_PLANILLA_DOC;
            rpdTo.COD_PER = plcTo.COD_PER;
            rpdTo.DESC_PER = plcTo.DESC_PER;
            rpdTo.DNI = plcTo.DNI;
            rpdTo.OBSERVACIONES = plcTo.OBSERVACIONES;
            rpdTo.TIPO_PLANILLA = plcTo.TIPO_PLANILLA_DOC;
            rpdTo.COD_MONEDA = plcTo.COD_MOD;
            rpdTo.IMP_INI = plcTo.IMPORTE_TOTAL;
            rpdTo.IMP_DOC = rpdTo.IMP_INI;
            rpdTo.STATUS_APROB = false;
            rpdTo.COD_CREACION = plcTo.COD_CREA;
            rpdTo.FECHA_CREACION = plcTo.FECHA_CREA;

            //RESUMEN_PLANILLA_DEVOLUCION
            if (!rpdBLL.insertarResumenPlanillaDevolucionBLL(rpdTo, ref errMensaje))
                return result = false;
            //RESUMEN_TPLANILLA_DEVOLUCION
            if (!aprueba_Adiciona_TPlanilla_Devolucion_BLL(rpdTo, ref errMensaje))
                return result = false;

            return result;
        }
        private bool aprueba_Adiciona_TPlanilla_Devolucion_BLL(resumenPlanillaDevolucionTo rpdTo, ref string errMensaje)
        {
            bool result = true;
            resumenTPlanillaDevolucionBLL rtpBLL = new resumenTPlanillaDevolucionBLL();
            resumenTPlanillaDevolucionTo rtpTo = new resumenTPlanillaDevolucionTo();
            rtpTo.NRO_PLANILLA_DOC = rpdTo.NRO_PLANILLA_DOC;
            rtpTo.COD_INSTITUCION = rpdTo.COD_INSTITUCION;
            rtpTo.COD_PTO_COB_CONSOLIDADO = rpdTo.COD_PTO_COB_CONSOLIDADO;
            rtpTo.COD_CANAL_DSCTO = rpdTo.COD_CANAL_DSCTO;
            rtpTo.FE_AÑO = rpdTo.FE_AÑO;
            rtpTo.FE_MES = rpdTo.FE_MES;
            rtpTo.COD_SUCURSAL = rpdTo.COD_SUCURSAL;
            rtpTo.FECHA_PLANILLA_DOC = rpdTo.FECHA_PLANILLA_DOC;
            rtpTo.COD_DOCUMENTO_PAGO = "";
            rtpTo.NRO_DOCUMENTO_PAGO = "";
            rtpTo.FECHA_PAGO = null;
            rtpTo.OBSERVACIONES = rpdTo.OBSERVACIONES;
            rtpTo.TIPO_PLANILLA = rpdTo.TIPO_PLANILLA;
            rtpTo.COD_MONEDA = rpdTo.COD_MONEDA;
            rtpTo.IMP_DOC = rpdTo.IMP_DOC;
            rtpTo.COD_D_H = "D";
            rtpTo.TIPO_OPE = "GF";
            rtpTo.COD_CREACION = rpdTo.COD_CREACION;
            rtpTo.FECHA_CREACION = rpdTo.FECHA_CREACION;

            if (!rtpBLL.insertarResumenTPlanillaDevolucionBLL(rtpTo, ref errMensaje))
                return result = false;
            return result;
        }
        private bool aprueba_Adiciona_TCTAS_COBRAR_BLL(planillaCabeceraOtrasDevDsctosTo plcTo, ref string errMensaje)
        {
            bool result = true;
            //if (!plcDAL.aprueba_Adiciona_TCTAS_Actualiza_PCTAS_COBRAR_DAL(plcTo, ref errMensaje))
            //    return result = false;
            return result;

        }
        private bool aprueba_Actualiza_I_PLANILLA_OTRAS_DEV_DSCTOS_BLL(planillaCabeceraOtrasDevDsctosTo plcTo, ref string errMensaje)
        {
            bool result = true;
            if (!plcDAL.aprueba_Actualiza_I_PLANILLA_OTRAS_DEV_DSCTOS_X_CIERRE_DAL(plcTo, ref errMensaje))
                return result = false;
            return result;
        }
        private bool aprueba_Actualiza_DEV_PCTAS_COBRAR_BLL(planillaCabeceraOtrasDevDsctosTo plcTo, DataTable dt, ref string errMensaje)
        {
            bool result = true;
            foreach (DataRow rw in dt.Rows)
            {
                dpcTo.NRO_PLANILLA_COB = rw["NRO_PLANILLA_COB"].ToString();
                dpcTo.COD_SUCURSAL = plcTo.COD_SUCURSAL;
                dpcTo.COD_CLASE = "01";
                dpcTo.NRO_CONTRATO = plcTo.NRO_CONTRATO;
                dpcTo.FE_AÑO = plcTo.FE_AÑO;
                dpcTo.FE_MES = plcTo.FE_MES;
                dpcTo.COD_D_H = "D";
                dpcTo.TIPO_PLA_COBRANZA = plcTo.TIPO_PLANILLA_DOC;
                dpcTo.NRO_LETRA = rw["NRO_LETRA"].ToString();//"000";
                dpcTo.COD_USU_MOD = plcTo.COD_CREA;
                dpcTo.FECHA_MOD = plcTo.FECHA_CREA;
                dpcTo.IMP_DOC = plcTo.IMPORTE_TOTAL;
                if (!dpcBLL.actualizaDevPCtasCobrarOtrasDevDsctosxCierreBLL(dpcTo, ref errMensaje))
                    return result = false;
            }
            return result;
        }
        private bool aprueba_Adiciona_DEV_TCTAS_COBRAR_BLL(planillaCabeceraOtrasDevDsctosTo plcTo, DataTable dt, ref string errMensaje)
        {
            bool result = true;
            devTCtasCobrarBLL dtcBLL = new devTCtasCobrarBLL();
            devTCtasCobrarTo dtcTo = new devTCtasCobrarTo();
            foreach (DataRow rw in dt.Rows)
            {
                dtcTo.NRO_PLANILLA_COB = rw["NRO_PLANILLA_COB"].ToString();
                dtcTo.COD_SUCURSAL = plcTo.COD_SUCURSAL;
                dtcTo.COD_CLASE = "01";
                dtcTo.NRO_CONTRATO = plcTo.NRO_CONTRATO;
                dtcTo.FE_AÑO = plcTo.FE_AÑO;
                dtcTo.FE_MES = plcTo.FE_MES;
                dtcTo.COD_PER = plcTo.COD_PER;
                dtcTo.DESC_PER = plcTo.DESC_PER;
                dtcTo.COD_DOC = "60";
                dtcTo.NRO_DOC = "000000";
                dtcTo.FECHA_CONTRATO = null;
                dtcTo.FECHA_DOC = plcTo.FECHA_PLANILLA_DOC.Date + DateTime.Now.TimeOfDay;//plcTo.FECHA_PLANILLA_DOC;
                dtcTo.FECHA_VEN = null;
                dtcTo.COD_P_COBRANZA = "";
                dtcTo.COD_COBRADOR = "";
                dtcTo.NRO_PLANILLA = plcTo.NRO_PLANILLA_DOC;//dtcTo.NRO_PLANILLA_COB;
                dtcTo.FECHA_PLANILLA = dtcTo.FECHA_DOC;
                dtcTo.COD_MOTIVO_NO_DESCONTADO = rw["MOTIVO_OTRAS_DEV_DSCTOS"].ToString();
                dtcTo.COD_D_H = "H";
                dtcTo.COD_MONEDA = "S";
                dtcTo.TIPO_CAMBIO = 0;
                dtcTo.IMP_DOC = plcTo.IMPORTE_TOTAL;
                dtcTo.OBSERVACION = plcTo.OBSERVACIONES;
                dtcTo.TIPO_OPE = "GF";
                dtcTo.NRO_LETRA = "000";
                dtcTo.TOTAL_LETRA = "000";
                dtcTo.COD_CONCEPTO = "";
                dtcTo.TIPO_PLA_ORIGEN = plcTo.TIPO_PLANILLA_DOC.Substring(0, 1);
                dtcTo.TIPO_PLA_COBRANZA = plcTo.TIPO_PLANILLA_DOC;
                dtcTo.COD_USU_CREA = plcTo.COD_CREA;
                dtcTo.FECHA_CREA = plcTo.FECHA_CREA;
                if (!dtcBLL.insertarDevTCtasCobrarBLL(dtcTo, ref errMensaje))
                    return result = false;
            }


            return result;
        }
        public bool eliminarPlanillaDetalleOtrasDevDsctosBLL(planillaCabeceraOtrasDevDsctosTo plcTo, ref string errMensaje)
        {
            bool result = true;
            pldTo.NRO_PLANILLA_DOC = plcTo.NRO_PLANILLA_DOC;
            pldTo.COD_INSTITUCION = plcTo.COD_INSTITUCION;
            pldTo.COD_CANAL_DSCTO = plcTo.COD_CANAL_DSCTO;
            pldTo.FE_AÑO = plcTo.FE_AÑO;
            pldTo.FE_MES = plcTo.FE_MES;
            pldTo.TIPO_PLANILLA_DOC = plcTo.TIPO_PLANILLA_DOC;
            if (!pldBLL.eliminarPlanillaDetalleOtrasDevDsctosBLL(pldTo, ref errMensaje))
                return result = false;
            return result;
        }

        public bool eliminaDevTctasCobrarxEliminacionPllaBLL(planillaCabeceraOtrasDevDsctosTo plcTo, ref string errMensaje)
        {
            bool result = true;
            devPCtasCobrarBLL dpcBLL = new devPCtasCobrarBLL();
            devPCtasCobrarTo dpcTo = new devPCtasCobrarTo();
            dpcTo.NRO_PLANILLA_COB = plcTo.NRO_PLANILLA_DOC;
            dpcTo.COD_SUCURSAL = plcTo.COD_SUCURSAL;
            dpcTo.COD_CLASE = plcTo.COD_CLASE;
            dpcTo.NRO_CONTRATO = plcTo.NRO_CONTRATO;
            dpcTo.COD_D_H = "H";
            dpcTo.TIPO_PLA_COBRANZA = plcTo.TIPO_PLANILLA_DOC;
            dpcTo.IMP_DOC = plcTo.IMPORTE_TOTAL;
            if (!dpcBLL.eliminarDevTctasCobrarxEliminacionPllaBLL(dpcTo, ref errMensaje))
                return result = false;
            return result;
        }

        public bool actualizaDevPctasCobrarxEliminacionPllaBLL(planillaCabeceraOtrasDevDsctosTo plcTo, ref string errMensaje)
        {
            bool result = true;
            devPCtasCobrarBLL dpcBLL = new devPCtasCobrarBLL();
            devPCtasCobrarTo dpcTo = new devPCtasCobrarTo();
            dpcTo.NRO_PLANILLA_COB = plcTo.NRO_PLANILLA_DOC;
            dpcTo.COD_SUCURSAL = plcTo.COD_SUCURSAL;
            dpcTo.COD_CLASE = plcTo.COD_CLASE;
            dpcTo.NRO_CONTRATO = plcTo.NRO_CONTRATO;
            dpcTo.COD_D_H = "D";
            dpcTo.TIPO_PLA_COBRANZA = plcTo.TIPO_PLANILLA_DOC;
            if (!dpcBLL.actualizaDevPctasCobrarxEliminacionPllaBLL(dpcTo, ref errMensaje))
                return result = false;
            return result;
        }

        public bool actualizaDevPCtasBLL(planillaCabeceraOtrasDevDsctosTo plcTo, DataTable dt, ref string errMensaje)
        {
            bool result = true;
            foreach (DataRow rw in dt.Rows)
            {
                dpcTo.NRO_PLANILLA_COB = rw["NRO_PLANILLA_COB"].ToString();
                dpcTo.COD_SUCURSAL = plcTo.COD_SUCURSAL;
                dpcTo.COD_CLASE = "01";
                dpcTo.NRO_CONTRATO = plcTo.NRO_CONTRATO;
                dpcTo.FE_AÑO = plcTo.FE_AÑO;
                dpcTo.FE_MES = plcTo.FE_MES;
                dpcTo.COD_D_H = "D";
                dpcTo.NRO_LETRA = plcTo.NRO_LETRA;//"000";
                dpcTo.TIPO_PLA_COBRANZA = plcTo.TIPO_PLANILLA_DOC;
                if (!dpcBLL.actualizaDevPCtasCobrarOtrasDevDsctosBLL(dpcTo, ref errMensaje))
                    return result = false;
            }
            return result;
        }
        public bool insertarPlanillaCabeceraOtrasDevDsctosBLL(planillaCabeceraOtrasDevDsctosTo plcTo, ref string errMensaje)
        {
            bool result = true;
            if (!plcDAL.insertarPlanillaCabeceraOtrasDevDsctosDAL(plcTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool ingresarPlanillaDetalleOtrasDevDsctosBLL(planillaCabeceraOtrasDevDsctosTo plcTo, DataTable dt, ref string errMensaje)
        {
            bool result = true;
            foreach (DataRow rw in dt.Rows)
            {
                pldTo.NRO_PLANILLA_DOC = plcTo.NRO_PLANILLA_DOC;
                pldTo.COD_INSTITUCION = plcTo.COD_INSTITUCION;
                pldTo.COD_CANAL_DSCTO = plcTo.COD_CANAL_DSCTO;
                pldTo.FE_AÑO = plcTo.FE_AÑO;
                pldTo.FE_MES = plcTo.FE_MES;
                pldTo.TIPO_PLANILLA_DOC = plcTo.TIPO_PLANILLA_DOC;
                pldTo.NRO_PLANILLA_COB = rw["NRO_PLANILLA_COB"].ToString();
                pldTo.NRO_DOC = rw["NRO_DOCU"].ToString();// se lo puse porque agregué una columna NRO_DOC
                pldTo.IMP_DOC = Convert.ToDecimal(rw["IMP_DOC"]);
                pldTo.MOTIVO_OTRAS_DEV_DSCTOS = rw["MOTIVO_OTRAS_DEV_DSCTOS"].ToString();
                pldTo.COD_CREA = plcTo.COD_CREA;
                pldTo.FECHA_CREA = plcTo.FECHA_CREA;
                pldTo.NRO_LETRA = rw["NRO_LETRA"].ToString();//plcTo.NRO_LETRA;
                pldTo.IMP_DEV = Convert.ToDecimal(rw["IMP_DEV"]);
                pldTo.NRO_PLLA_ORIGEN = rw["NRO_PLLA_ORIGEN"].ToString();
                pldTo.TIPO_PLLA_ORIGEN = rw["TIPO_PLLA_ORIGEN"].ToString();

                if (!pldBLL.insertarPlanillaDetalleOtrasDevDsctosBLL(pldTo, ref errMensaje))
                    return result = false;
            }
            return result;
        }
        public bool modificarPlanillaCabeceraOtrasDevDsctosBLL(planillaCabeceraOtrasDevDsctosTo plcTo, ref string errMensaje)
        {
            bool result = true;
            if (!plcDAL.modificarPlanillaCabeceraOtrasDevDsctosDAL(plcTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminarPlanillaCabeceraOtrasDevDsctosBLL(planillaCabeceraOtrasDevDsctosTo plcTo, ref string errMensaje)
        {
            bool result = true;
            if (!plcDAL.eliminarPlanillaCabeceraOtrasDevDsctosDAL(plcTo, ref errMensaje))
                return result = false;
            return result;
        }

        public bool eliminarPlanillaOtrasDevDsctosBLL(planillaCabeceraOtrasDevDsctosTo plcTo, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                //I
                if (!eliminarPlanillaCabeceraOtrasDevDsctosBLL(plcTo, ref errMensaje))
                    return result = false;
                //T
                if (!eliminarPlanillaDetalleOtrasDevDsctosBLL(plcTo, ref errMensaje))
                    return result = false;

                ts.Complete();
                return result;
            }
        }
    }
}
