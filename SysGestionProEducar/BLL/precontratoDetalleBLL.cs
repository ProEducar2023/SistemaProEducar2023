using DAL;
using Entidades;
using System.Data;
namespace BLL
{
    public class precontratoDetalleBLL
    {
        precontratoDetalleDAL pcdDAL = new precontratoDetalleDAL();

        public DataTable obtenerPreContratoDetalleBLL(precontratoDetalleTo pcdTo)
        {
            return pcdDAL.obtenerPreContratoDetalleDAL(pcdTo);
        }
        public bool insertarPreContradoDetalleBLL(precontratoDetalleTo pcdTo, ref string errMensaje)
        {
            bool result = true;
            if (!pcdDAL.insertarPreContratoDetalleDAL(pcdTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool actualizaPreContratoDetalleCantidadAtendBLL(precontratoDetalleTo pcdTo, ref string errMensaje)
        {
            bool result = true;
            if (!pcdDAL.actualizaPreContratoDetalleCantidadAtendDAL(pcdTo, ref errMensaje))
                return result = false;
            return result;
        }
        public DataTable obtenerPreContratoCabeceraparaCrearContratoDetalleBLL(precontratoDetalleTo pcdTo)
        {
            return pcdDAL.obtenerPreContratoCabeceraparaCrearContratoDetalleDAL(pcdTo);
        }
        public DataTable obtenerPreContratoDetalleparaDesaprobarContratoBLL(precontratoDetalleTo pcdTo)
        {
            return pcdDAL.obtenerPreContratoDetalleparaDesaprobarContratoDAL(pcdTo);
        }
    }
}
