using DAL;
using Entidades;
using System;
using System.Data;
using System.Transactions;
namespace BLL
{
    public class otrosCargosComisionesBLL
    {
        otrosCargosComisionesDAL occDAL = new otrosCargosComisionesDAL();

        public DataTable obtenerOtrosCargosComisionesBLL(otrosCargosComisionesTo occTo)
        {
            return occDAL.obtenerOtrosCargosComisionesDAL(occTo);
        }
        public DataTable obtenerOtrosCargosComisionesDetalleBLL(otrosCargosComisionesTo occTo)
        {
            return occDAL.obtenerOtrosCargosComisionesDetalleDAL(occTo);
        }
        public bool insertarOtrosCargosComisionesBLL(otrosCargosComisionesTo occTo, ref string errMensaje)
        {
            bool result = true;
            if (!occDAL.insertarOtrosCargosComisionesDAL(occTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool grabarOtrosCargosComisionesBLL(otrosCargosComisionesTo occTo, DataTable dt, ref string errMensaje)
        {
            bool result = true;
            foreach (DataRow rw in dt.Rows)
            {
                occTo.NRO_DOC = rw["NRO_DOC"].ToString();
                occTo.COD_D_H = rw["COD_D_H"].ToString();
                occTo.COD_CPTO = rw["COD_CPTO"].ToString();
                occTo.IMPORTE = Convert.ToDecimal(rw["importe"]);
                occTo.OBSERVACIONES = rw["obs"].ToString();
                occTo.IMP_RETENCION = rw["IMP_RETENCION"].ToString() == "" ? 0 : Convert.ToDecimal(rw["IMP_RETENCION"]);
                if (!insertarOtrosCargosComisionesBLL(occTo, ref errMensaje))
                    return result = false;
            }
            return result;
        }
        public DataTable obtenerOtrosCargosComisionesxPeriodoparaResumenBLL(otrosCargosComisionesTo occTo)
        {
            return occDAL.obtenerOtrosCargosComisionesxPeriodoparaResumenDAL(occTo);
        }
        public decimal sumaOtrosCargos_Comisiones_X_Periodo_X_ComisionistaBLL(otrosCargosComisionesTo occTo)
        {
            return occDAL.sumaOtrosCargos_Comisiones_X_Periodo_X_ComisionistaDAL(occTo);
        }
        public DataTable obtenerOtrosCargos_Comisiones_X_Periodo_X_ComisionistaBLL(otrosCargosComisionesTo occTo)
        {
            return occDAL.obtenerOtrosCargos_Comisiones_X_Periodo_X_ComisionistaDAL(occTo);
        }
        public bool modificarOtrosCargosComisionesBLL(otrosCargosComisionesTo occTo, DataTable dt, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;

                //eliminar
                if (!quitarOtrosCargosComisionesBLL(occTo, ref errMensaje))
                    return result = false;
                //insertar
                if (!grabarOtrosCargosComisionesBLL(occTo, dt, ref errMensaje))
                    return result = false;

                ts.Complete();
                return result;
            }
        }
        public bool quitarOtrosCargosComisionesBLL(otrosCargosComisionesTo occTo, ref string errMensaje)
        {
            bool result = true;
            //occTo.COD_SUCURSAL = rw["COD_SUCURSAL"].ToString();
            //occTo.FE_AÑO = rw["FE_AÑO"].ToString();
            //occTo.FE_MES = rw["FE_MES"].ToString();
            //occTo.COD_PER = rw["COD_PER"].ToString();
            if (!occDAL.quitarOtrosCargosComisionesDAL(occTo, ref errMensaje))
                return result = false;
            return result;
        }
        private bool eliminarOtrosCargosComisionesBLL(otrosCargosComisionesTo occTo, ref string errMensaje)
        {
            bool result = true;
            if (!occDAL.eliminarOtrosCargosComisionesDAL(occTo, ref errMensaje))
                return result = false;
            return result;
        }
    }
}
