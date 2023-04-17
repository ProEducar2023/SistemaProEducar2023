using DAL;
using Entidades;
using System;
using System.Data;
using System.Transactions;

namespace BLL
{
    public class kitBLL
    {
        kitDAL kiDAL = new kitDAL();
        kitDetalleBLL dkiBLL = new kitDetalleBLL();
        kitDetalleTo dkiTo = new kitDetalleTo();
        public DataTable obtenerKitBLL()
        {
            return kiDAL.obtenerKitDAL();
        }
        public DataTable obtenerKitxGrupoBLL(kitTo kitTo)
        {
            return kiDAL.obtenerKitDAL(kitTo);
        }
        public bool adicionaKitBLL(kitTo kiTo, DataTable dtKDet, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                //inserta kit
                if (!insertarKitBLL(kiTo, ref errMensaje))
                    return result = false;
                //inserta kit detalle
                if (!insertaKitDetBLL(kiTo.COD_KIT, dtKDet, ref errMensaje))
                    return result = false;
                //inserta Lista de Precios Articulos
                if (kiTo.ESTADO == "1")
                {
                    if (!insertaListaPreciosArticulos(kiTo, dtKDet, ref errMensaje))
                        return result = false;
                }
                ts.Complete();
                return result;
            }
        }
        private bool insertaListaPreciosArticulos(kitTo kiTo, DataTable dt, ref string errMensaje)
        {
            bool result = true;
            foreach (DataRow rw in dt.Rows)
            {
                if (!Convert.ToBoolean(rw["st_sus"]))
                {
                    dkiTo.COD_KIT = kiTo.COD_KIT;
                    dkiTo.COD_ARTICULO = rw[0].ToString();
                    //dkiTo.CANTIDAD = Convert.ToDecimal(rw[4]);
                    dkiTo.PRECIO_UNITARIO = Convert.ToDecimal(rw[5]);
                    //dkiTo.ST_VALOR_REFERENCIAL = Convert.ToBoolean(rw[6]);
                    dkiTo.FEC_ACTUALIZACION = kiTo.FEC_ACTUALIZACION;
                    //dkiTo.ST_SUSPENDIDO = Convert.ToBoolean(rw[8]);

                    if (!dkiBLL.insertarListaPreciosBLL(dkiTo, ref errMensaje))
                        return result = false;
                }
            }
            return result;
        }
        private bool insertaKitDetBLL(string COD_KIT, DataTable dt, ref string errMensaje)
        {
            bool result = true;
            foreach (DataRow rw in dt.Rows)
            {
                dkiTo.COD_KIT = COD_KIT;
                dkiTo.COD_ARTICULO = rw[0].ToString();
                dkiTo.CANTIDAD = Convert.ToDecimal(rw[4]);
                dkiTo.PRECIO_UNITARIO = Convert.ToDecimal(rw[5]);
                dkiTo.ST_VALOR_REFERENCIAL = Convert.ToBoolean(rw[6]);
                dkiTo.FEC_ACTUALIZACION = Convert.ToDateTime(rw[7]);
                dkiTo.ST_SUSPENDIDO = Convert.ToBoolean(rw[8]);

                if (!dkiBLL.insertarKitDetalleBLL(dkiTo, ref errMensaje))
                    return result = false;

            }
            return result;
        }
        public bool insertarKitBLL(kitTo kiTo, ref string errMensaje)
        {
            bool result = true;
            if (!kiDAL.insertarKitDAL(kiTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool actualizaModificaKitBLL(kitTo kiTo, DataTable dtPKit, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                //modifica kit
                if (!modificarKitBLL(kiTo, ref errMensaje))
                    return result = false;
                //elimina detalle kit
                if (!eliminaKitDetBLL(kiTo, ref errMensaje))
                    return result = false;
                //inserta detalle kit
                if (!insertaKitDetBLL(kiTo.COD_KIT, dtPKit, ref errMensaje))
                    return result = false;
                //inserta en Lista Precios Articulos
                if (kiTo.ESTADO == "1")
                {
                    if (!insertaListaPreciosArticulos(kiTo, dtPKit, ref errMensaje))
                        return result = false;
                }
                ts.Complete();
                return result;
            }
        }
        public bool eliminaKitDetBLL(kitTo kiTo, ref string errMensaje)
        {
            kitDetalleBLL dkiBLL = new kitDetalleBLL();
            kitDetalleTo dkiTo = new kitDetalleTo();
            bool result = true;
            dkiTo.COD_KIT = kiTo.COD_KIT;
            if (!dkiBLL.eliminarKitDetalleBLL(dkiTo, ref errMensaje))
                return result = false;

            return result;
        }
        public bool modificarKitBLL(kitTo kiTo, ref string errMensaje)
        {
            bool result = true;
            if (!kiDAL.modificarKitDAL(kiTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminarKitBLL(kitTo kiTo, ref string errMensaje)
        {
            bool result = true;
            if (!kiDAL.eliminarKitDAL(kiTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminaKitCompletoBLL(kitTo kiTo, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                //elimina kit detalle
                if (!eliminarKitDetalleCompletoBLL(kiTo, ref errMensaje))
                    return result = false;
                //elimina kit Cabecera
                if (!eliminarKitBLL(kiTo, ref errMensaje))
                    return result = false;

                ts.Complete();
                return result;
            }
        }
        public bool eliminarKitDetalleCompletoBLL(kitTo kiTo, ref string errMensaje)
        {
            kitDetalleBLL dkiBLL = new kitDetalleBLL();
            kitDetalleTo dkiTo = new kitDetalleTo();
            bool result = true;
            dkiTo.COD_KIT = kiTo.COD_KIT;
            if (!dkiBLL.eliminarKitDetalleCompletoBLL(dkiTo, ref errMensaje))
                return result = false;

            return result;

        }
    }
}
