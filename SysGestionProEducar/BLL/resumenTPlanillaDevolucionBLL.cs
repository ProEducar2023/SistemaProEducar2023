using DAL;
using Entidades;
using System.Data;

namespace BLL
{
    public class resumenTPlanillaDevolucionBLL
    {
        resumenTPlanillaDevolucionDAL rtpDAL = new resumenTPlanillaDevolucionDAL();

        public DataTable obtenerResumenTPlanillaDevolucionBLL()
        {
            return rtpDAL.obtenerResumenTPlanillaDevolucionDAL();
        }
        public bool insertarResumenTPlanillaDevolucionBLL(resumenTPlanillaDevolucionTo rtpTo, ref string errMensaje)
        {
            bool result = true;
            if (!rtpDAL.insertarResumenTPlanillaDevolucionDAL(rtpTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificarResumenTPlanillaDevolucionBLL(resumenTPlanillaDevolucionTo rtpTo, ref string errMensaje)
        {
            bool result = true;
            if (!rtpDAL.modificarResumenTPlanillaDevolucionDAL(rtpTo, ref errMensaje))
                return result = false;
            return result;
        }
    }
}
