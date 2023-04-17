using DAL;
using Entidades;
using System;
using System.Data;
using System.Transactions;
namespace BLL
{
    public class tCostosBLL
    {
        tCostosDAL tcosDAL = new tCostosDAL();
        tCostosTo tcosTo = new tCostosTo();
        public DataTable obtenerTCostosBLL()
        {
            return tcosDAL.obtenerTCostosDAL();
        }
        public bool insertarTCostosBLL(tCostosTo tcosTo, ref string errMensaje)
        {
            bool result = true;
            if (!tcosDAL.insertarTCostosDAL(tcosTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificarTCostosBLL(tCostosTo tcosTo, ref string errMensaje)
        {
            bool result = true;
            if (!tcosDAL.modificarTCostosDAL(tcosTo, ref errMensaje))
                return result = false;
            return result;
        }
        public DataTable VERIFICA_ORDEN_PT_COS(tCostosTo tcosTo)
        {
            //return tcosDAL.VERIFICA_ORDEN_PT_COS(tcosTo);
            return null;
        }
        public DataTable MOSTRAR_T_COSTOS_DEVOLUCION(tCostosTo tcosTo)
        {
            return tcosDAL.MOSTRAR_T_COSTOS_DEVOLUCION(tcosTo);
        }
        public bool ACTUALIZAR_T_COSTOS_DEVOLUCION(iCostosTo cosTo, DataTable dt, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                //Actualiza tCostos
                if (!ACTUALIZAR_T_COSTOS_DEVOLUCION_BLL(cosTo, dt, ref errMensaje))
                    return result = false;
                //Actualiza Invetarios
                if (!ACTUALIZAR_GESTION_BLL(cosTo, dt, ref errMensaje))
                    return result = false;
                ts.Complete();
                return result;
            }
        }
        public bool ACTUALIZAR_GESTION_BLL(iCostosTo cosTo, DataTable dt, ref string errMensaje)
        {
            bool result = true;
            inventariosBLL invBLL = new inventariosBLL();
            inventariosTo invTo = new inventariosTo();
            foreach (DataRow rw in dt.Rows)
            {
                invTo.COD_SUCURSAL = cosTo.COD_SUCURSAL;
                invTo.COD_CLASE = cosTo.COD_CLASE;
                invTo.COD_MOV = cosTo.COD_MOV;
                invTo.COD_DOC_INV = cosTo.COD_DOC_INV;
                invTo.NRO_DOC_INV = cosTo.NRO_DOC_INV;
                invTo.COD_PER = cosTo.COD_PER;
                invTo.FE_AÑO = cosTo.FE_AÑO;
                invTo.FE_MES = cosTo.FE_MES;
                invTo.NRO_ITEM = rw[0].ToString();
                invTo.PRECIO_CON = Convert.ToDecimal(rw[5]);
                invTo.VALOR_CON = Convert.ToDecimal(rw[6]);
                if (!invBLL.ACTUALIZAR_INVENTARIOS_DETALLE_BLL(invTo, ref errMensaje))
                    return result = false;
            }
            return result;
        }
        private bool ACTUALIZAR_T_COSTOS_DEVOLUCION_BLL(iCostosTo cosTo, DataTable dt, ref string errMensaje)
        {
            bool result = true;
            foreach (DataRow rw in dt.Rows)
            {
                if (rw[5].ToString() == rw[11].ToString())
                {
                    tcosTo.COD_SUCURSAL = cosTo.COD_SUCURSAL;
                    tcosTo.COD_CLASE = cosTo.COD_CLASE;
                    tcosTo.COD_MOV = cosTo.COD_MOV;
                    tcosTo.COD_DOC_INV = cosTo.COD_DOC_INV;
                    tcosTo.NRO_DOC_INV = cosTo.NRO_DOC_INV;
                    tcosTo.COD_PER = cosTo.COD_PER;
                    tcosTo.FE_AÑO = cosTo.FE_AÑO;
                    tcosTo.FE_MES = cosTo.FE_MES;
                    tcosTo.ITEM = rw[0].ToString();
                    tcosTo.PRECIO_CON = Convert.ToDecimal(rw[5]);
                    tcosTo.VALOR_CON = Convert.ToDecimal(rw[6]);
                    if (!tcosDAL.ACTUALIZAR_T_COSTOS_DEVOLUCION_DAL(tcosTo, ref errMensaje))
                        return result = false;
                }
            }
            return result;
        }
        public DataTable CONSULTA_KARDEX_SALDO_ARTICULO(tCostosTo tcosTo)
        {
            return tcosDAL.CONSULTA_KARDEX_SALDO_ARTICULO(tcosTo);
        }
    }
}
