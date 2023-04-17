using DAL;
using Entidades;
using System.Data;
namespace BLL
{
    public class devTCtasCobrarBLL
    {
        devTCtasCobrarDAL dtcDAL = new devTCtasCobrarDAL();

        public DataTable obtenerDevTCtasCobrarBLL(devTCtasCobrarTo dtcTo)
        {
            return dtcDAL.obtenerDevTCtasCobrarDAL(dtcTo);
        }
        public bool insertarDevTCtasCobrarBLL(devTCtasCobrarTo dtcTo, ref string errMensaje)
        {
            bool result = true;
            if (!dtcDAL.insertarDevTCtasCobrarDAL(dtcTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificarDevTCtasCobrarBLL(devTCtasCobrarTo dtcTo, ref string errMensaje)
        {
            bool result = true;
            if (!dtcDAL.modificarDevTCtasCobrarDAL(dtcTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminarDevTCtasCobrarBLL(devTCtasCobrarTo dtcTo, ref string errMensaje)
        {
            bool result = true;
            if (!dtcDAL.eliminarDevTCtasCobrarDAL(dtcTo, ref errMensaje))
                return result = false;
            return result;
        }
        public DataTable obtenerDevTCtasCobrar_plla_cont_BLL(devTCtasCobrarTo dtcTo)
        {
            return dtcDAL.obtenerDevTCtasCobrar_plla_cont_DAL(dtcTo);
        }
        public DataTable obtenerDevTCtasCobrar_tipo_cont_BLL(devTCtasCobrarTo dtcTo)
        {
            return dtcDAL.obtenerDevTCtasCobrar_tipo_cont_DAL(dtcTo);
        }
        public DataTable obtenerContratoSuspendidoxApliDevDetalleBLL(devTCtasCobrarTo dtcTo)
        {
            return dtcDAL.obtenerContratoSuspendidoxApliDevDetalleDAL(dtcTo);
        }
        public DataTable obtenerContratoSuspendidoxApliDevBLL(devTCtasCobrarTo dtcTo)
        {
            return dtcDAL.obtenerContratoSuspendidoxApliDevDAL(dtcTo);
        }
    }
}
