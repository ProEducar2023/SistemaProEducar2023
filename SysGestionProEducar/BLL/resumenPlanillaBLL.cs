using DAL;
using Entidades;

namespace BLL
{
    public class resumenPlanillaBLL
    {
        resumenPlanillaDAL rplaDAL = new resumenPlanillaDAL();

        public bool insertarResumenPlanillaBLL(resumenPlanillaTo rplaTo, ref string errMensaje)
        {
            bool result = true;
            if (!rplaDAL.insertarResumenPlanillaDAL(rplaTo, ref errMensaje))
                return result = false;
            return result;
        }
    }
}
