using DAL;
using Entidades;
using System;
using System.Data;
using System.Transactions;
namespace BLL
{
    public class periodoBLL
    {
        periodoDAL prdDAL = new periodoDAL();
        public DataTable obtenerPeriodoBLL(periodoTo prdTo)
        {
            return prdDAL.obtenerPeriodoDAL(prdTo);
        }
        public bool insertarPeriodoBLL(periodoTo prdTo, ref string errMensaje)
        {
            bool result = true;
            if (!prdDAL.insertarPeriodoDAL(prdTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificarPeriodoBLL(periodoTo prdTo, ref string errMensaje)
        {
            bool result = true;
            if (!prdDAL.modificarPeriodoDAL(prdTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminarPeriodoBLL(periodoTo prdTo, ref string errMensaje)
        {
            bool result = true;
            if (!prdDAL.eliminarPeriodoDAL(prdTo, ref errMensaje))
                return result = false;
            return result;
        }
        public DataTable hallarActivoBLL(periodoTo prdTo)
        {
            return prdDAL.hallarActivoDAL(prdTo);
        }
        public bool activarPeriodoBLL(periodoTo prdTo, ref string errMensaje)
        {
            bool result = true;
            if (!prdDAL.activarPeriodoDAL(prdTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool cerrarPeriodoBLL(periodoTo prdTo, ref string errMensaje)
        {
            bool result = true;
            if (!prdDAL.cerrarPeriodoDAL(prdTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool regresarCerrarPeriodoBLL(periodoTo prdTo, ref string errMensaje)
        {
            bool result = true;
            if (!prdDAL.regresarCerrarPeriodoDAL(prdTo, ref errMensaje))
                return result = false;
            return result;
        }

        public bool verificaFechaParaCierreAñoBLL(periodoTo prdTo, ref string errMensaje)
        {
            bool result = true;
            if (!prdDAL.verificaFechaParaCierreAñoDAL(prdTo, ref errMensaje))
                return result = false;
            return result;
        }
        public DataTable MOSTRAR_ACTIVO_BLL(string COD_MODULO)
        {
            return prdDAL.MOSTRAR_ACTIVO_DAL(COD_MODULO);
        }
        public bool VERIFICAR_CIERRE_PERIODO_BLL(periodoTo prdTo, ref string errMensaje)
        {
            bool result = true;
            if (prdDAL.VERIFICAR_CIERRE_PERIODO_DAL(prdTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool cerrarCierreAñoBLL(periodoTo prdTo, ref string errMensaje)
        {
            bool result = true;
            if (!prdDAL.cerrarCierreAñoDAL(prdTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool regresarCierreAñoBLL(periodoTo prdTo, ref string errMensaje)
        {
            bool result = true;
            if (!prdDAL.regresarCierreAñoDAL(prdTo, ref errMensaje))
                return result = false;
            return result;
        }
        public DataTable obtenerAñoPeriodoBLL(periodoTo prdTo)
        {
            return prdDAL.obtenerAñoPeriodoDAL(prdTo);
        }
        public bool procesoCerrarPeriodoBLL(periodoTo prdTo, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                //
                if (prdTo.COD_MODULO == "1")
                {

                }
                else if (prdTo.COD_MODULO == "2")
                {

                }
                else if (prdTo.COD_MODULO == "COM")
                {
                    //Periodo
                    if (!cerrarPeriodoBLL(prdTo, ref errMensaje))
                        return result = false;
                    //Resumen
                    if (!crea_P_ResumenBLL(prdTo, ref errMensaje))
                        return result = false;
                }
                else if (prdTo.COD_MODULO == "4")
                {

                }
                else if (prdTo.COD_MODULO == "5")
                {

                }
                else if (prdTo.COD_MODULO == "6")
                {

                }
                else if (prdTo.COD_MODULO == "7")
                {
                    //Periodo
                    if (!cerrarPeriodoBLL(prdTo, ref errMensaje))
                        return result = false;
                }

                ts.Complete();
                return result;
            }
        }
        private bool crea_P_ResumenBLL(periodoTo prdTo, ref string errMensaje)
        {
            bool result = true;
            DataTable dtResumen = new DataTable();
            dtResumen.Columns.Add("TIPO_VTA");
            dtResumen.Columns.Add("COD_PROGRAMA");
            dtResumen.Columns.Add("FE_AÑO");
            dtResumen.Columns.Add("FE_MES");
            dtResumen.Columns.Add("COD_PER");
            dtResumen.Columns.Add("IMPORTE");
            ////
            pLiquidacionBLL pliqBLL = new pLiquidacionBLL();
            pLiquidacionTo pliqTo = new pLiquidacionTo();
            pLiqAdelantoBLL plaBLL = new pLiqAdelantoBLL();
            pLiqAdelantoTo plaTo = new pLiqAdelantoTo();
            pLiqDevolucionBLL pldBLL = new pLiqDevolucionBLL();
            pLiqDevolucionTo pldTo = new pLiqDevolucionTo();
            otrosCargosComisionesBLL occBLL = new otrosCargosComisionesBLL();
            otrosCargosComisionesTo occTo = new otrosCargosComisionesTo();
            pliqTo.FE_AÑO = prdTo.AÑO;
            pliqTo.FE_MES = prdTo.MES;
            plaTo.FE_AÑO = pliqTo.FE_AÑO;
            plaTo.FE_MES = pliqTo.FE_MES;
            pldTo.FE_AÑO = pliqTo.FE_AÑO;
            pldTo.FE_MES = pliqTo.FE_MES;
            occTo.FE_AÑO = pliqTo.FE_AÑO;
            occTo.FE_MES = pliqTo.FE_MES;
            ///
            DataTable dtComision = pliqBLL.obtenerComision_Comisiones_X_Periodo_X_ComisionistaBLL(pliqTo);
            DataTable dtDevolucion = pldBLL.obtenerDevolucion_Comisiones_X_Periodo_X_ComisionistaBLL(pldTo);
            DataTable dtAdelanto = plaBLL.obtenerAdelanto_Comisiones_X_Periodo_X_ComisionistaBLL(plaTo);
            DataTable dtOtros = occBLL.obtenerOtrosCargos_Comisiones_X_Periodo_X_ComisionistaBLL(occTo);
            /////
            decimal imp_comi, imp_devo, imp_ade, imp_otros;

            foreach (DataRow rwC in dtComision.Rows)
            {
                DataRow rwR = dtResumen.NewRow();
                rwR["TIPO_VTA"] = rwC["TIPO_VTA"].ToString();
                rwR["COD_PROGRAMA"] = rwC["COD_PROGRAMA"].ToString();
                rwR["COD_PER"] = rwC["COD_COMISIONANTE"];
                imp_comi = Convert.ToDecimal(rwC["IMPORTE"]);
                foreach (DataRow rwD in dtDevolucion.Rows)
                {
                    if (rwC["COD_COMISIONANTE"].ToString() == rwD["COD_COMISIONANTE"].ToString())
                    {
                        imp_devo = Convert.ToDecimal(rwD["IMPORTE"]);
                        imp_comi -= imp_devo;
                        break;
                    }
                }
                foreach (DataRow rwA in dtAdelanto.Rows)
                {
                    if (rwC["COD_COMISIONANTE"].ToString() == rwA["COD_PER"].ToString())
                    {
                        imp_ade = Convert.ToDecimal(rwA["IMPORTE"]);
                        imp_comi -= imp_ade;
                        break;
                    }
                }
                foreach (DataRow rwO in dtOtros.Rows)
                {
                    if (rwC["COD_COMISIONANTE"].ToString() == rwO["COD_PER"].ToString())
                    {
                        imp_otros = Convert.ToDecimal(rwO["IMPORTE"]);
                        imp_comi -= imp_otros;
                        break;
                    }
                }
                rwR["IMPORTE"] = imp_comi;
                dtResumen.Rows.Add(rwR);
            }
            pResumenComisionBLL presBLL = new pResumenComisionBLL();
            pResumenComisionTo presTo = new pResumenComisionTo();

            foreach (DataRow rw in dtResumen.Rows)
            {
                presTo.TIPO_VTA = rw["TIPO_VTA"].ToString();
                presTo.COD_PROGRAMA = rw["COD_PROGRAMA"].ToString();
                presTo.FE_AÑO = prdTo.AÑO;
                presTo.FE_MES = prdTo.MES;
                presTo.COD_PER = rw["COD_PER"].ToString();
                presTo.IMPORTE = Convert.ToDecimal(rw["IMPORTE"]);
                presTo.COD_CREA = prdTo.COD_USU;
                presTo.FECHA_CREA = DateTime.Now;
                if (!presBLL.insertarResumenComisionBLL(presTo, ref errMensaje))
                    return result = false;

            }
            return result;
        }
        public DataTable obtenerPeriodoPllasNoTransferidasBLL()
        {
            return prdDAL.obtenerPeriodoPllasNoTransferidasDAL();
        }
    }
}
