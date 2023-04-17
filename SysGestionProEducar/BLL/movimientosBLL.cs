using DAL;
using Entidades;
using System;
using System.Data;
using System.Transactions;
namespace BLL
{
    public class movimientosBLL
    {
        movimientosDAL movDAL = new movimientosDAL();

        public DataTable obtenerMovimientosBLL()
        {
            return movDAL.obtenerMovimientosDAL();
        }
        public DataTable obtenerMovimientosparaPedidoBLL()
        {
            return movDAL.obtenerMovimientosparaPedidoDAL();
        }
        public DataTable obtenerMovimientosparaInventarioBLL()
        {
            return movDAL.obtenerMovimientosparaInventarioDAL();
        }
        public DataTable obtenerMovimientosparaTransferenciaBLL()
        {
            return movDAL.obtenerMovimientosparaTransferenciaDAL();
        }
        public DataTable obtenerMovimientosparaInventarioSalidaBLL()
        {
            return movDAL.obtenerMovimientosparaInventarioSalidaDAL();
        }
        public bool adicionaInsertaMovimientosBLL(movimientosTo movTo, DataTable dtSerMov, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                //adiciona en Movimientos
                if (!insertarMovimientosBLL(movTo, ref errMensaje))
                    return result = false;
                //adiciona en Serie_Documentos
                if (!insertaMovimientoSerieBLL(dtSerMov, movTo.COD_MOV, ref errMensaje))
                    return result = false;
                ts.Complete();
                return result;
            }
        }

        private bool insertaMovimientoSerieBLL(DataTable dt, string COD_MOV, ref string errMensaje)
        {
            movimientoSerieBLL mosBLL = new movimientoSerieBLL();
            movimientoSerieTo mosTo = new movimientoSerieTo();
            bool result = true; string op;
            foreach (DataRow rw in dt.Rows)
            {
                mosTo.COD_SUCURSAL = rw["codsuc"].ToString();
                mosTo.COD_MOV = COD_MOV;
                mosTo.COD_DOC = rw["coddoc"].ToString();
                //mosTo.STATUS_DOC = Convert.ToBoolean(rw["stadoc"]) == true ? "1" : "0";
                if (rw["stadoc"].ToString() == "True" || rw["stadoc"].ToString() == "1")
                    op = "1";
                else
                    op = "0";
                mosTo.STATUS_DOC = op;
                mosTo.SERIE = rw["ser"].ToString();

                if (!mosBLL.insertarMovimientoSerieBLL(mosTo, ref errMensaje))
                    return result = false;
            }
            return result;
        }
        public bool insertarMovimientosBLL(movimientosTo movTo, ref string errMensaje)
        {
            bool result = true;
            if (!movDAL.insertarMovimientosDAL(movTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificarMovimientosBLL(movimientosTo movTo, ref string errMensaje)
        {
            bool result = true;
            if (!movDAL.modificarMovimientosDAL(movTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminarMovimientosBLL(movimientosTo movTo, ref string errMensaje)
        {
            bool result = true;
            if (!movDAL.eliminarMovimientosDAL(movTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool actualizaModificaMovimientosBLL(movimientosTo movTo, DataTable dtSerMov, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                //adiciona en Movimientos
                if (!modificarMovimientosBLL(movTo, ref errMensaje))
                    return result = false;
                //elimina Serie_Documentos con COD_MOV, SE ELIMINA EN MODIFICAR MOVIMIENTOS

                //adiciona en Serie_Documentos
                if (!insertaMovimientoSerieBLL(dtSerMov, movTo.COD_MOV, ref errMensaje))
                    return result = false;
                ts.Complete();
                return result;
            }
        }
        public string HALLAR_STATUS_COSTOS_BLL(movimientosTo movTo)
        {
            return movDAL.HALLAR_STATUS_COSTOS_DAL(movTo);
        }
        public DataTable obtenerMovimientosCostosBLL()
        {
            return movDAL.obtenerMovimientosCostosDAL();
        }
        public string obtenerTipoOperacionBLL(movimientosTo movTo)
        {
            return movDAL.obtenerTipoOperacionDAL(movTo);
        }
        public DataTable obtenerMovimientosCostosPromedioBLL()
        {
            return movDAL.obtenerMovimientosCostosPromedioDAL();
        }
    }
}
