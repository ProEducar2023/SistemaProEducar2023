using DAL;
using Entidades;
using System;
using System.Data;
using System.Transactions;

namespace BLL
{
    public class modalidadVentaBLL
    {
        modalidadVentaDAL mvDAL = new modalidadVentaDAL();
        public DataTable obtenerModalidadVentaBLL()
        {
            return mvDAL.obtenerModalidadVentaDAL();
        }
        public bool insertarModalidadVentaBLL(modalidadVentaTo mvTo, DataTable dt, ref string errMensaje)
        {
            bool result = true;
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow rw in dt.Rows)
                {
                    mvTo.COD_TIPO_VENTA = rw["codcc"].ToString();
                    if (!mvDAL.insertarModalidadVentaDAL(mvTo, ref errMensaje))
                        return result = false;
                }
            }
            else if (dt.Rows.Count == 0)
            {
                mvTo.COD_TIPO_VENTA = "00";
                if (!mvDAL.insertarModalidadVentaDAL(mvTo, ref errMensaje))
                    return result = false;
            }


            return result;
        }
        public bool modificarModalidadVentaBLL(modalidadVentaTo mvTo, DataTable dt, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                //elimina 
                if (!eliminarModalidadVentaBLL(mvTo, ref errMensaje))
                    return result = false;
                //adiciona 
                if (!insertarModalidadVentaBLL(mvTo, dt, ref errMensaje))
                    return result = false;
                //foreach(DataRow rw in dt.Rows)
                //{

                //    if (!mvDAL.modificarModalidadVentaDAL(mvTo, ref errMensaje))
                //        return result = false;
                //}
                ts.Complete();
                return result;
            }
        }
        public bool eliminarModalidadVentaBLL(modalidadVentaTo mvTo, ref string errMensaje)
        {
            bool result = true;
            if (!mvDAL.eliminarModalidadVentaDAL(mvTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool ValidarModalidadVentaBLL(modalidadVentaTo mvTo, ref string errMensaje)
        {
            bool result = true;
            if (mvDAL.ValidarModalidadVentaDAL(mvTo, ref errMensaje))
                return result = false;
            return result;
        }
        public DataTable obtenerTipoVentaporCodBLL(modalidadVentaTo mvTo)
        {
            return mvDAL.obtenerTipoVentaporCodDAL(mvTo);
        }
    }
}
