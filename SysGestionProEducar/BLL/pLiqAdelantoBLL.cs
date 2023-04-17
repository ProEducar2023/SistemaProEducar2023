using DAL;
using Entidades;
using System;
using System.Data;
using System.Transactions;
namespace BLL
{
    public class pLiqAdelantoBLL
    {
        pLiqAdelantoDAL lqaDAL = new pLiqAdelantoDAL();

        public DataTable obtenerPLiqAdelantoBLL(pLiqAdelantoTo lqaTo)
        {
            return lqaDAL.obtenerPLiqAdelantoDAL(lqaTo);
        }
        public bool insertarPLiqAdelantoBLL(pLiqAdelantoTo lqaTo, ref string errMensaje)
        {
            bool result = true;
            if (!lqaDAL.insertarPLiqAdelantoDAL(lqaTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificarPLiqAdelanto3BLL(pLiqAdelantoTo lqaTo, ref string errMensaje)
        {
            bool result = true;
            if (!lqaDAL.insertarPLiqAdelanto3DAL(lqaTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool liquidacionAdelantosBLL(pLiqAdelantoTo lqaTo, DataTable dtAde, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                foreach (DataRow rw in dtAde.Rows)
                {
                    lqaTo.COD_SUCURSAL = rw["COD_SUCURSAL"].ToString();
                    lqaTo.COD_PER = rw["COD_PER"].ToString();
                    lqaTo.COD_DOC = rw["COD_DOC"].ToString();
                    lqaTo.NRO_DOC = rw["NRO_DOC"].ToString();
                    lqaTo.FECHA_DOC = Convert.ToDateTime(rw["FECHA_DOC"]);
                    lqaTo.IMP_DOC = Convert.ToDecimal(rw["IMP_DOC"]);
                    lqaTo.OBSERVACION = rw["OBSERVACION"].ToString();
                    lqaTo.COD_USU_MOD = lqaTo.COD_USU_CREA;
                    lqaTo.FECHA_MOD = lqaTo.FECHA_CREA;
                    lqaTo.COD_MONEDA = rw["COD_MONEDA"].ToString();
                    lqaTo.NRO_DOC_PAG = "";
                    lqaTo.FECHA_DOC_PAG = null;
                    lqaTo.COD_CONCEPTO = "";
                    lqaTo.COD_BANCO = "";
                    lqaTo.STATUS_LIQUIDADO = "1";
                    lqaTo.STATUS_CANCELADO = "0";

                    //P_ADELANTO
                    if (!modificarPAdelantoBLL(lqaTo, ref errMensaje))//se modifica en P_Adelantos solo cuando se paga todo lo que está en P_Adelantos
                        return result = false;
                    ////T_ADELANTO   //esto se crea desde Tesorería
                    //if (!insertarTAdelantoporLiquidacionBLL(lqaTo, ref errMensaje))
                    //    return result = false;
                    //P_LIQ_ADELANTO
                    if (!adicionaPLiqAdelantoBLL(lqaTo, ref errMensaje))
                        return result = false;
                    //bool valor = false;
                    //if (verifica_existe_P_AdelantoBLL(lqaTo,ref valor, ref errMensaje))
                    //{
                    //    if(valor)
                    //    {
                    //        //P_ADELANTO
                    //        if (!modificarPAdelanto2BLL(lqaTo, ref errMensaje))//se modifica en P_Adelantos solo cuando se paga todo lo que está en P_Adelantos
                    //            return result = false;
                    //        ////T_ADELANTO   //esto se crea desde Tesorería
                    //        //if (!insertarTAdelantoporLiquidacionBLL(lqaTo, ref errMensaje))
                    //        //    return result = false;
                    //        //P_LIQ_ADELANTO
                    //        if (!modificarPLiqAdelanto_3BLL(lqaTo, ref errMensaje))
                    //            return result = false;
                    //    }
                    //    else
                    //    {
                    //        //P_ADELANTO
                    //        if (!modificarPAdelantoBLL(lqaTo, ref errMensaje))//se modifica en P_Adelantos solo cuando se paga todo lo que está en P_Adelantos
                    //            return result = false;
                    //        ////T_ADELANTO   //esto se crea desde Tesorería
                    //        //if (!insertarTAdelantoporLiquidacionBLL(lqaTo, ref errMensaje))
                    //        //    return result = false;
                    //        //P_LIQ_ADELANTO
                    //        if (!adicionaPLiqAdelantoBLL(lqaTo, ref errMensaje))
                    //            return result = false;
                    //    }
                    //}
                    //else
                    //{
                    //    return result = false;
                    //}

                }
                ts.Complete();
                return result;
            }
        }
        private bool verifica_existe_P_AdelantoBLL(pLiqAdelantoTo lqaTo, ref bool valor, ref string errMensaje)
        {
            bool result = true;
            if (!lqaDAL.verifica_existe_P_AdelantoDAL(lqaTo, ref valor, ref errMensaje))
                return result = false;
            return result;
        }
        public bool adicionaPLiqAdelantoBLL(pLiqAdelantoTo lqaTo, ref string errMensaje)
        {
            bool result = true;
            if (!insertarPLiqAdelantoBLL(lqaTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificarPLiqAdelanto_3BLL(pLiqAdelantoTo lqaTo, ref string errMensaje)
        {
            bool result = true;
            if (!modificarPLiqAdelanto3BLL(lqaTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificarPAdelantoBLL(pLiqAdelantoTo lqaTo, ref string errMensaje)
        {
            bool result = true;
            pAdelantoBLL padeBLL = new pAdelantoBLL();
            pAdelantoTo padeTo = new pAdelantoTo();
            padeTo.COD_SUCURSAL = lqaTo.COD_SUCURSAL;
            padeTo.FE_AÑO = lqaTo.FE_AÑO;
            padeTo.FE_MES = lqaTo.FE_MES;
            padeTo.COD_PER = lqaTo.COD_PER;
            padeTo.NRO_DOC = lqaTo.NRO_DOC;
            padeTo.IMP_DOC = lqaTo.IMP_DOC;
            padeTo.OBSERVACION = lqaTo.OBSERVACION;
            padeTo.STATUS_LIQUIDADO = lqaTo.STATUS_LIQUIDADO;
            padeTo.STATUS_CANCELADO = lqaTo.STATUS_CANCELADO;
            padeTo.COD_USU_MOD = lqaTo.COD_USU_MOD;
            padeTo.FECHA_MOD = lqaTo.FECHA_MOD;

            if (!padeBLL.modificarPAdelantoporLiquidacionBLL(padeTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificarPAdelanto2BLL(pLiqAdelantoTo lqaTo, ref string errMensaje)
        {
            bool result = true;
            pAdelantoBLL padeBLL = new pAdelantoBLL();
            pAdelantoTo padeTo = new pAdelantoTo();
            padeTo.COD_SUCURSAL = lqaTo.COD_SUCURSAL;
            padeTo.FE_AÑO = lqaTo.FE_AÑO;
            padeTo.FE_MES = lqaTo.FE_MES;
            padeTo.COD_PER = lqaTo.COD_PER;
            padeTo.NRO_DOC = lqaTo.NRO_DOC;
            padeTo.IMP_DOC = lqaTo.IMP_DOC;
            padeTo.OBSERVACION = lqaTo.OBSERVACION;
            padeTo.STATUS_LIQUIDADO = lqaTo.STATUS_LIQUIDADO;
            padeTo.STATUS_CANCELADO = lqaTo.STATUS_CANCELADO;
            padeTo.COD_USU_MOD = lqaTo.COD_USU_MOD;
            padeTo.FECHA_MOD = lqaTo.FECHA_MOD;

            if (!padeBLL.modificarPAdelantoporLiquidacion2BLL(padeTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool insertarTAdelantoporLiquidacionBLL(pLiqAdelantoTo lqaTo, ref string errMensaje)
        {
            bool result = true;
            tAdelantoBLL tadeBLL = new tAdelantoBLL();
            tAdelantoTo tadeTo = new tAdelantoTo();
            tadeTo.COD_SUCURSAL = lqaTo.COD_SUCURSAL;
            tadeTo.FE_AÑO = lqaTo.FE_AÑO;
            tadeTo.FE_MES = lqaTo.FE_MES;
            tadeTo.COD_PER = lqaTo.COD_PER;
            tadeTo.COD_D_H = "H";
            tadeTo.COD_DOC = lqaTo.COD_DOC;
            tadeTo.NRO_DOC = lqaTo.NRO_DOC;
            tadeTo.FECHA_DOC = lqaTo.FECHA_DOC;
            tadeTo.COD_MONEDA = lqaTo.COD_MONEDA;//preguntar de donde sale este valor, se está poniendo por defecto ""
            tadeTo.TIPO_CAMBIO = 0;//preguntar de donde sale este valor, se está poniendo por defecto 0
            tadeTo.IMP_DOC = lqaTo.IMP_DOC;
            tadeTo.OBSERVACION = lqaTo.OBSERVACION;
            tadeTo.TIPO_OPE = "CC";
            tadeTo.COD_USU_CREA = lqaTo.COD_USU_CREA;
            tadeTo.FECHA_CREA = lqaTo.FECHA_CREA;
            if (!tadeBLL.insertarTAdelantoBLL(tadeTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminarPLiqAdelantoBLL(pLiqAdelantoTo lqaTo, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;


                //P_ADELANTO
                if (!revertirPAdelantoBLL(lqaTo, ref errMensaje))
                    return result = false;
                ////T_ADELANTO
                //if (!eliminar_T_Adelanto_por_LiquidacionBLL(lqaTo, ref errMensaje))
                //    return result = false;
                //P_LIQ_ADELANTO
                if (!eliminar_P_Liq_AdelantoBLL(lqaTo, ref errMensaje))
                    return result = false;

                ts.Complete();
                return result;
            }
        }
        public bool eliminar_P_Liq_AdelantoBLL(pLiqAdelantoTo lqaTo, ref string errMensaje)
        {
            bool result = true;
            if (!lqaDAL.eliminar_P_Liq_AdelantoDAL(lqaTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminar_T_Adelanto_por_LiquidacionBLL(pLiqAdelantoTo lqaTo, ref string errMensaje)
        {
            bool result = true;
            tAdelantoBLL tadeBLL = new tAdelantoBLL();
            tAdelantoTo tadeTo = new tAdelantoTo();
            tadeTo.COD_SUCURSAL = lqaTo.COD_SUCURSAL;
            tadeTo.FE_AÑO = lqaTo.FE_AÑO;
            tadeTo.FE_MES = lqaTo.FE_MES;
            tadeTo.COD_PER = lqaTo.COD_PER;
            tadeTo.COD_D_H = "H";
            tadeTo.COD_DOC = lqaTo.COD_DOC;
            tadeTo.NRO_DOC = lqaTo.NRO_DOC;
            tadeTo.FECHA_DOC = lqaTo.FECHA_DOC;
            tadeTo.COD_MONEDA = lqaTo.COD_MONEDA;//preguntar de donde sale este valor, se está poniendo por defecto ""
            tadeTo.TIPO_CAMBIO = 0;//preguntar de donde sale este valor, se está poniendo por defecto 0
            tadeTo.IMP_DOC = lqaTo.IMP_DOC;
            tadeTo.OBSERVACION = lqaTo.OBSERVACION;
            tadeTo.TIPO_OPE = "CC";
            tadeTo.COD_USU_CREA = lqaTo.COD_USU_CREA;
            tadeTo.FECHA_CREA = lqaTo.FECHA_CREA;
            if (!tadeBLL.eliminarTAdelantoBLL(tadeTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool revertirPAdelantoBLL(pLiqAdelantoTo lqaTo, ref string errMensaje)
        {
            bool result = true;
            pAdelantoBLL padeBLL = new pAdelantoBLL();
            pAdelantoTo padeTo = new pAdelantoTo();
            padeTo.COD_SUCURSAL = lqaTo.COD_SUCURSAL;
            padeTo.FE_AÑO = lqaTo.FE_AÑO;
            padeTo.FE_MES = lqaTo.FE_MES;
            padeTo.COD_PER = lqaTo.COD_PER;
            padeTo.NRO_DOC = lqaTo.NRO_DOC;
            padeTo.IMP_DOC = lqaTo.IMP_DOC;
            padeTo.STATUS_LIQUIDADO = "0";
            //padeTo.OBSERVACION = lqaTo.OBSERVACION;
            padeTo.COD_USU_MOD = lqaTo.COD_USU_MOD;
            padeTo.FECHA_MOD = lqaTo.FECHA_MOD;

            if (!padeBLL.revertirPAdelantoporLiquidacionBLL(padeTo, ref errMensaje))
                return result = false;
            return result;
        }
        public DataTable obtenerPLiqAdelantoxPeriodoparaResumenBLL(pLiqAdelantoTo lqaTo)
        {
            return lqaDAL.obtenerPLiqAdelantoxPeriodoparaResumenDAL(lqaTo);
        }
        public decimal sumaAdelanto_Comisiones_X_Periodo_X_ComisionistaBLL(pLiqAdelantoTo lqaTo)
        {
            return lqaDAL.sumaAdelanto_Comisiones_X_Periodo_X_ComisionistaDAL(lqaTo);
        }
        public DataTable obtenerAdelanto_Comisiones_X_Periodo_X_ComisionistaBLL(pLiqAdelantoTo lqaTo)
        {
            return lqaDAL.obtenerAdelanto_Comisiones_X_Periodo_X_ComisionistaDAL(lqaTo);
        }
    }
}
