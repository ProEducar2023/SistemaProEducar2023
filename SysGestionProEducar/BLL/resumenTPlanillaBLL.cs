using DAL;
using Entidades;
namespace BLL
{
    public class resumenTPlanillaBLL
    {
        resumenTPlanillaDAL rtplDAL = new resumenTPlanillaDAL();

        public bool insertarResumenTPlanillaBLL(resumenTPlanillaTo rtplTo, ref string errMensaje)
        {
            bool result = true;
            if (!rtplDAL.insertarResumenTPlanillaDAL(rtplTo, ref errMensaje))
                return result = false;
            return result;
        }
    }
}
