using DAL;
using Entidades;
using System;
using System.Data;
using System.Transactions;
namespace BLL
{
    public class puntoVentaBLL
    {
        puntoVentaDAL ptvDAL = new puntoVentaDAL();
        puntoVentaTo ptvTo = new puntoVentaTo();
        public DataTable obtenerPuntoVentaBLL()
        {
            return ptvDAL.obtenerPuntoVentaDAL();
        }
        public bool insertarPuntoVentaBLL(puntoVentaTo ptvTo, ref string errMensaje)
        {
            bool result = true;
            if (!ptvDAL.insertarPuntoVentaDAL(ptvTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificarPuntoVentaBLL(puntoVentaTo ptvTo, ref string errMensaje)
        {
            bool result = true;
            if (!ptvDAL.modificarPuntoVentaDAL(ptvTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminaPuntoVentayRelacionesBLL(puntoVentaTo ptvTo, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                //eliminar relacion para consolidados
                if (!eliminarPuntoVentaVinculadosRelacionadosBLL(ptvTo, ref errMensaje))
                    return result = false;
                //elimina punto de venta
                if (!eliminarPuntoVentaBLL(ptvTo, ref errMensaje))
                    return result = false;

                ts.Complete();
                return result;
            }
        }
        private bool eliminarPuntoVentaVinculadosRelacionadosBLL(puntoVentaTo ptvTo, ref string errMensaje)
        {
            bool result = true;
            if (!ptvDAL.eliminaPuntoVentaRelacionadosDAL(ptvTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminarPuntoVentaBLL(puntoVentaTo ptvTo, ref string errMensaje)
        {
            bool result = true;
            if (!ptvDAL.eliminarPuntoVentaDAL(ptvTo, ref errMensaje))
                return result = false;
            return result;
        }
        public DataTable obtenerPuntosVentasBLL(puntoVentaTo ptvTo)
        {
            return ptvDAL.obtenerPuntosVentasDAL(ptvTo);
        }
        public DataTable obtenerPuntoVentaVinculadosDetalleBLL(puntoVentaTo ptvTo)
        {
            return ptvDAL.obtenerPuntoVentaVinculadosDetalleDAL(ptvTo);
        }
        public bool insertarPtoVenVinculadosBLL(DataTable dt, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                //eliminar
                if (!eliminarPuntoVentaVinculadosBLL(dt.Rows[0][0].ToString(), ref errMensaje))
                    return result = false;
                //adicionar
                if (!insertaPuntoVentaConsolidadoBLL(dt, ref errMensaje))
                    return result = false;
                //
                ts.Complete();
                return result;
            }
        }
        private bool eliminarPuntoVentaVinculadosBLL(string cod_cons, ref string errMensaje)
        {
            bool result = true;
            if (!ptvDAL.eliminaPuntoVentaVinculadosDAL(cod_cons, ref errMensaje))
                return result = false;
            return result;
        }
        private bool insertaPuntoVentaConsolidadoBLL(DataTable dt, ref string errMensaje)
        {
            bool result = true;
            foreach (DataRow rw in dt.Rows)
            {
                ptvTo.COD_PTO_VEN_CONS = rw[0].ToString();
                ptvTo.COD_PTO_VEN = rw[1].ToString();
                if (!ptvDAL.insertarPtoVenVinculadosDAL(ptvTo, ref errMensaje))
                    return result = false;
            }
            return result;
        }
        public DataTable obtenerPuntoVentaConsolidadoBLL(puntoVentaTo ptvTo)
        {
            return ptvDAL.obtenerPuntoVentaConsolidadoDAL(ptvTo);
        }
        public int verificaPuntoVentaBLL(puntoVentaTo ptvTo)
        {
            return ptvDAL.verificaPuntoVentaDAL(ptvTo);
        }
        public bool validaHistoricoPedidoBLL(puntoVentaTo ptvTo, ref string errMensaje)
        {
            bool result = true;
            if (!ptvDAL.validaHistoricoPedidoDAL(ptvTo, ref errMensaje))
                return result = false;
            return result;
        }
        public DataTable obtenerPuntoVentaVinculadosBLL(puntoVentaTo ptvTo)
        {
            return ptvDAL.obtenerPuntoVentaVinculadosDAL(ptvTo);
        }
        public bool modificaPuntoVentaDetalleBLL(puntoVentaTo ptvTo, ref string errMensaje)
        {
            bool result = true;
            if (!ptvDAL.modificaPuntoVentaDetalleDAL(ptvTo, ref errMensaje))
                return result = false;
            return result;
        }
    }
}
