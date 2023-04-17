using DAL;
using Entidades;
using System;
using System.Data;
using System.Transactions;

namespace BLL
{
    public class iCostosBLL
    {

        iCostosDAL icosDAL = new iCostosDAL();
        periodoBLL perBLL = new periodoBLL();
        periodoTo perTo = new periodoTo();
        mCostosBLL mCosBLL = new mCostosBLL();
        mCostosTo mCosTo = new mCostosTo();
        aCostosBLL aCosBLL = new aCostosBLL();
        aCostosTo aCosTo = new aCostosTo();
        inventariosBLL invBLL = new inventariosBLL();
        inventariosTo invTo = new inventariosTo();
        public DataTable obtenerICostosBLL()
        {
            return icosDAL.obtenerICostosDAL();
        }
        public bool insertarICostosBLL(iCostosTo icosTo, ref string errMensaje)
        {
            bool result = true;
            if (!icosDAL.insertarICostosDAL(icosTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificarICostosBLL(iCostosTo icosTo, ref string errMensaje)
        {
            bool result = true;
            if (!icosDAL.modificarICostosDAL(icosTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool VERIFICAR_PROCESO_PERIODO_BLL(iCostosTo cosTo, ref string errMensaje)
        {
            bool result = true;
            perTo.COD_MODULO = "COS";
            perTo.AÑO = cosTo.FE_AÑO;
            perTo.MES = cosTo.FE_MES;
            if (perBLL.VERIFICAR_CIERRE_PERIODO_BLL(perTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool inicialCostoPromedioBLL(iCostosTo cosTo, ref string errMensaje)
        {
            bool result = true;
            if (!icosDAL.inicialCostoPromedioDAL(cosTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool VALIDAR_NEGATIVOS_BLL(iCostosTo cosTo, ref string errMensaje)
        {
            bool result = true;

            if (!icosDAL.VALIDAR_NEGATIVOS_DAL(cosTo, ref errMensaje))
                return result = false;
            return result;
        }
        public string CALCULAR_COSTO_PROMEDIO(iCostosTo cosTo)
        {
            string val = "EXITO";
            if (icosDAL.CALCULAR_COSTO_PROMEDIO(cosTo) == "FALLO")
                return val = "FALLO";
            return val;
        }
        public string CALCULAR_COSTO_PROMEDIO2(iCostosTo cosTo)
        {
            string val = "EXITO";
            if (icosDAL.CALCULAR_COSTO_PROMEDIO2(cosTo) == "FALLO")
                return val = "FALLO";
            return val;
        }
        public string CALCULAR_COSTO_PROMEDIO_ARTICULO(iCostosTo cosTo)
        {
            string val = "EXITO";
            if (icosDAL.CALCULAR_COSTO_PROMEDIO_ARTICULO(cosTo) == "FALLO")
                return val = "FALLO";
            return val;
        }
        public string CALCULAR_COSTO_PROMEDIO_MOV(iCostosTo cosTo)
        {
            string val = "EXITO";
            if (icosDAL.CALCULAR_COSTO_PROMEDIO_MOV(cosTo) == "FALLO")
                return val = "FALLO";
            return val;
        }
        public DataTable MOSTRAR_I_COSTOS_DEVOLUCION(iCostosTo cosTo)
        {
            return icosDAL.MOSTRAR_I_COSTOS_DEVOLUCION(cosTo);
        }
        public bool creaSaldoInicialBLL(iCostosTo cosTo, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                //M_COSTOS
                mCosTo.FE_AÑO = cosTo.FE_AÑO;
                mCosTo.FE_AÑO2 = cosTo.FE_AÑO2;
                mCosTo.FE_MES = cosTo.FE_MES;
                mCosTo.COD_CLASE = cosTo.COD_CLASE;
                //A_COSTO
                aCosTo.FE_AÑO = cosTo.FE_AÑO;
                aCosTo.FE_AÑO2 = cosTo.FE_AÑO2;
                aCosTo.FE_MES = cosTo.FE_MES;
                aCosTo.COD_CLASE = cosTo.COD_CLASE;
                aCosTo.COD_SUCURSAL = cosTo.COD_SUCURSAL;
                //INVENTARIO
                invTo.FE_AÑO = cosTo.FE_AÑO;
                invTo.FE_AÑO2 = cosTo.FE_AÑO2;
                invTo.FE_MES = cosTo.FE_MES;
                invTo.COD_PER = cosTo.COD_PER;
                invTo.COD_CLASE = cosTo.COD_CLASE;
                //
                if (!mCosBLL.modificaMCostosSaldoInicialBLL(mCosTo, ref errMensaje))
                    return result = false;
                //INI_M_COSTOS
                if (!mCosBLL.eliminaIniMCostosSaldoInicialBLL(ref errMensaje))
                    return result = false;
                //A_COSTOS 
                if (!aCosBLL.modificarACostosSaldoInicialBLL(aCosTo, ref errMensaje))
                    return result = false;
                //INI_A_COSTOS
                if (!aCosBLL.eliminaIniACostosSaldoInicialBLL(aCosTo, ref errMensaje))
                    return result = false;
                //insert INI_M_COSTOS
                if (!mCosBLL.insertarIniMCostosSaldoInicialBLL(mCosTo, ref errMensaje))
                    return result = false;
                //insert INI_A_COSTOS
                if (!aCosBLL.insertarIniACostosSaldoInicialBLL(aCosTo, ref errMensaje))
                    return result = false;
                // SALDO_INICIAL_COSTO
                if (!aCosBLL.saldoInicialCostoBLL(aCosTo, ref errMensaje))
                    return result = false;
                //INVENTARIOS
                if (!invBLL.modificaInventarioSaldoInicialBLL(invTo, ref errMensaje))
                    return result = false;
                ts.Complete();
                return result;
            }
        }
        public bool descreaSaldoInicialBLL(iCostosTo cosTo, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                //M_COSTOS
                mCosTo.FE_AÑO = cosTo.FE_AÑO;
                mCosTo.FE_AÑO2 = cosTo.FE_AÑO2;
                mCosTo.FE_MES = cosTo.FE_MES;
                mCosTo.COD_CLASE = cosTo.COD_CLASE;
                //A_COSTO
                aCosTo.FE_AÑO = cosTo.FE_AÑO;
                aCosTo.FE_AÑO2 = cosTo.FE_AÑO2;
                aCosTo.FE_MES = cosTo.FE_MES;
                aCosTo.COD_CLASE = cosTo.COD_CLASE;
                aCosTo.COD_SUCURSAL = cosTo.COD_SUCURSAL;
                //INVENTARIO
                invTo.FE_AÑO = cosTo.FE_AÑO;
                invTo.FE_AÑO2 = cosTo.FE_AÑO2;
                invTo.FE_MES = cosTo.FE_MES;
                invTo.COD_PER = cosTo.COD_PER;
                invTo.COD_CLASE = cosTo.COD_CLASE;
                //
                if (!mCosBLL.modificadesMCostosSaldoInicialBLL(mCosTo, ref errMensaje))
                    return result = false;
                //INI_M_COSTOS
                if (!mCosBLL.eliminaIniMCostosSaldoInicialBLL(ref errMensaje))
                    return result = false;
                //A_COSTOS 
                if (!aCosBLL.modificarACostosSaldoInicialBLL(aCosTo, ref errMensaje))
                    return result = false;
                //INI_A_COSTOS
                if (!aCosBLL.eliminaIniACostosSaldoInicialBLL(aCosTo, ref errMensaje))
                    return result = false;
                //////insert INI_M_COSTOS
                ////if (!mCosBLL.insertarIniMCostosSaldoInicialBLL(mCosTo, ref errMensaje))
                ////    return result = false;
                //////insert INI_A_COSTOS
                ////if (!aCosBLL.insertarIniACostosSaldoInicialBLL(aCosTo, ref errMensaje))
                ////    return result = false;
                ////// SALDO_INICIAL_COSTO
                ////if (!aCosBLL.saldoInicialCostoBLL(aCosTo, ref errMensaje))
                ////    return result = false;
                //INVENTARIOS
                if (!invBLL.modificaDesInventarioSaldoInicialBLL(invTo, ref errMensaje))
                    return result = false;
                ts.Complete();
                return result;
            }
        }
    }
}
