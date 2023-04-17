using DAL;
using Entidades;
using System.Data;

namespace BLL
{
    public class resumenPlanillaDevolucionBLL
    {
        resumenPlanillaDevolucionDAL rpdDAL = new resumenPlanillaDevolucionDAL();

        public DataTable obtenerResumenPlanillaDevolucionBLL()
        {
            return rpdDAL.obtenerResumenPlanillaDevolucionDAL();
        }
        public bool insertarResumenPlanillaDevolucionBLL(resumenPlanillaDevolucionTo rpdTo, ref string errMensaje)
        {
            bool result = true;
            if (!rpdDAL.insertarResumenPlanillaDevolucionDAL(rpdTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificarResumenPlanillaDevolucionBLL(resumenPlanillaDevolucionTo rpdTo, ref string errMensaje)
        {
            bool result = true;
            if (!rpdDAL.modificarResumenPlanillaDevolucionDAL(rpdTo, ref errMensaje))
                return result = false;
            return result;
        }
    }
}
