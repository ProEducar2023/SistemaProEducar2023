using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;

namespace BLL
{
    public class tipoPlanillaCreacionBLL
    {
        tipoPlanillaCreacionDAL pllaDAL = new tipoPlanillaCreacionDAL();
        tipoPlanillaCreacionTo pllaTo = new tipoPlanillaCreacionTo();

        public DataTable obtenerTipoPlanillaCreacionBLL()
        {
            return pllaDAL.obtenerTipoPlanillaCreacionDAL();
        }
        public DataTable obtenerTipoPlanillaCreacionxStGeneracionBLL(tipoPlanillaCreacionTo tpllaTo)
        {
            return pllaDAL.obtenerTipoPlanillaCreacionxStGeneracionDAL(tpllaTo);
        }
        public DataTable obtenerTipoPlanillaOperacionBLL(tipoPlanillaCreacionTo tpllaTo)
        {
            return pllaDAL.obtenerTipoPlanillaOperacionDAL(tpllaTo);
        }
        public DataTable obtenerTipoPlanillaCreacionGeneracionPllaBLL(tipoPlanillaCreacionTo tpllaTo)
        {
            return pllaDAL.obtenerTipoPlanillaCreacionGeneracionPllaDAL(tpllaTo);
        }
        public DataTable obtenerTipoPlanillaCreacionxTransferenciaBLL()
        {
            return pllaDAL.obtenerTipoPlanillaCreacionxTransferenciaDAL();
        }
        public bool insertarTipoPlanillaCreacionBLL(tipoPlanillaCreacionTo tpllaTo, ref string errMensaje)
        {
            bool result = true;
            if (!pllaDAL.insertarTipoPlanillaCreacionDAL(tpllaTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificarTipoPlanillaCreacionBLL(tipoPlanillaCreacionTo tpllaTo, ref string errMensaje)
        {
            bool result = true;
            if (!pllaDAL.modificarTipoPlanillaCreacionDAL(tpllaTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminarTipoPlanillaCreacionBLL(tipoPlanillaCreacionTo tpllaTo, ref string errMensaje)
        {
            bool result = true;
            if (!pllaDAL.eliminarTipoPlanillaCreacionDAL(tpllaTo, ref errMensaje))
                return result = false;
            return result;
        }

        public DataTable obtenerTipoPlanillaUbicacionBLL()
        {
            return pllaDAL.obtenerTipoPlanillaUbicacionDAL();
        }

        public List<tipoPlanillaCreacionTo> ListarTipoVentaComision()
        {
            return pllaDAL.ListarTipoVentaComision();
        }
    }
}
