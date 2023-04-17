using DAL;
using Entidades;
using System;
using System.Data;
namespace BLL
{
    public class comisionesDetalleBLL
    {
        comisionesDetalleDAL codDAL = new comisionesDetalleDAL();

        public DataTable obtenerComisionesDetalleBLL(comisionesDetalleTo codTo)
        {
            return codDAL.obtenerComisionesDetalleDAL(codTo);
        }
        public bool insertarComisionesDetalleBLL(comisionesDetalleTo codTo, ref string errMensaje)
        {
            bool result = true;
            if (!codDAL.insertarComisionesDetalleDAL(codTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificarComisionesDetalleBLL(comisionesDetalleTo codTo, ref string errMensaje)
        {
            bool result = true;
            if (!codDAL.modificarComisionesDetalleDAL(codTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminarComisionesDetalleBLL(comisionesDetalleTo codTo, ref string errMensaje)
        {
            bool result = true;
            if (!codDAL.eliminarComisionesDetalleDAL(codTo, ref errMensaje))
                return result = false;
            return result;
        }
        public DataTable mostrarMaestroDetalleBLL(comisionesDetalleTo codTo)
        {
            return codDAL.mostrarMaestroDetalleDAL(codTo);
        }
        public DataTable obtenerComisionesDetalleDistintosBLL()
        {
            return codDAL.obtenerComisionesDetalleDistintosDAL();
        }
        public DataTable obtener_Detalle_Comisiones_x_PersonaBLL(comisionesDetalleTo codTo)
        {
            return codDAL.obtener_Detalle_Comisiones_x_PersonaDAL(codTo);
        }
    }
}
