using DAL;
using Entidades;
using System;
using System.Data;
using System.Transactions;
namespace BLL
{
    public class reporteTelefonicoBLL
    {
        reporteTelefonicoDAL rtDAL = new reporteTelefonicoDAL();

        public DataTable obtenerReporteTelefonicoMensualBLL(reporteTelefonicoTo rtTo)
        {
            return rtDAL.obtenerReporteTelefonicoMensualDAL(rtTo);
        }
        public DataTable obtenerReporteTelefonicoBLL(reporteTelefonicoTo rtTo)
        {
            return rtDAL.obtenerReporteTelefonicoDAL(rtTo);
        }
        public bool grabarReporteTelefonicoBLL(reporteTelefonicoTo rtTo, DataTable dt, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;

                if (!insertarReporteTelefonicoBLL(rtTo, ref errMensaje))
                    return result = false;
                //detalle
                if (!insertarDetalleReporteTelefonicoBLL(rtTo, dt, ref errMensaje))
                    return result = false;

                ts.Complete();
                return result;
            }
        }
        public bool modificarReporteTelefonicoBLL(reporteTelefonicoTo rtTo, DataTable dt, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                //cabecera
                if (!modificarReporteTelefonicoBLL(rtTo, ref errMensaje))
                    return result = false;
                //elimina detalle
                if (!eliminaReporteTelefonicoDetalleBLL(rtTo, ref errMensaje))
                    return result = false;
                //detalle
                if (!insertarDetalleReporteTelefonicoBLL(rtTo, dt, ref errMensaje))
                    return result = false;

                ts.Complete();
                return result;
            }
        }
        public bool eliminaReporteTelefonicoDetalleBLL(reporteTelefonicoTo rtTo, ref string errMensaje)
        {
            reporteTelefonicoDetalleBLL rtdBLL = new reporteTelefonicoDetalleBLL();
            reporteTelefonicoDetalleTo rtdTo = new reporteTelefonicoDetalleTo();
            rtdTo.SUCURSAL = rtTo.SUCURSAL;
            rtdTo.COD_PROGRAMA = rtTo.COD_PROGRAMA;
            rtdTo.TIPO_PLANILLA = rtTo.TIPO_PLANILLA;
            rtdTo.FE_MES = rtTo.FE_MES;
            rtdTo.FE_AÑO = rtTo.FE_AÑO;
            rtdTo.COD_SEMANA = rtTo.COD_SEMANA;
            bool result = true;
            if (!rtdBLL.eliminarReporteTelefonicoDetalleBLL(rtdTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool insertarReporteTelefonicoBLL(reporteTelefonicoTo rtTo, ref string errMensaje)
        {
            bool result = true;
            if (!rtDAL.insertarReporteTelefonicoDAL(rtTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificarReporteTelefonicoBLL(reporteTelefonicoTo rtTo, ref string errMensaje)
        {
            bool result = true;
            if (!rtDAL.modificarReporteTelefonicoDAL(rtTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminarReporteTelefonicoBLL(reporteTelefonicoTo rtTo, ref string errMensaje)
        {
            bool result = true;
            if (!rtDAL.eliminarReporteTelefonicoDAL(rtTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool insertarDetalleReporteTelefonicoBLL(reporteTelefonicoTo rtTo, DataTable dt, ref string errMensaje)
        {
            reporteTelefonicoDetalleBLL rtdBLL = new reporteTelefonicoDetalleBLL();
            reporteTelefonicoDetalleTo rtdTo = new reporteTelefonicoDetalleTo();
            bool result = true;
            foreach (DataRow rw in dt.Rows)
            {
                rtdTo.SUCURSAL = rtTo.SUCURSAL;
                rtdTo.COD_PROGRAMA = rtTo.COD_PROGRAMA;
                rtdTo.TIPO_PLANILLA = rtTo.TIPO_PLANILLA;
                rtdTo.FE_MES = rtTo.FE_MES;
                rtdTo.FE_AÑO = rtTo.FE_AÑO;
                rtdTo.COD_SEMANA = rtTo.COD_SEMANA;
                rtdTo.COD_PER = rw["cod_per"].ToString();
                rtdTo.NOM_PER = rw["nom_per"].ToString();
                rtdTo.FECHA = rtTo.FECHA;
                rtdTo.CANTIDAD = Convert.ToInt32(rw["cant"]);
                rtdTo.MONTO = Convert.ToDecimal(rw["monto"]);
                rtdTo.FECHA_CREA = rtTo.FECHA_CREA;
                rtdTo.COD_CREA = rtTo.COD_CREA;
                if (!rtdBLL.insertarReporteTelefonicoDetalleDAL(rtdTo, ref errMensaje))
                    return result = false;
            }
            return result;
        }
        public bool finiquitarReporteTelefonicoBLL(reporteTelefonicoTo rtTo, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;

                //elimina detalle
                if (!eliminaReporteTelefonicoDetalleBLL(rtTo, ref errMensaje))
                    return result = false;
                //cabecera
                if (!eliminarReporteTelefonicoBLL(rtTo, ref errMensaje))
                    return result = false;
                ts.Complete();
                return result;
            }
        }
    }
}
