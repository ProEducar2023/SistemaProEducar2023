using DAL;
using Entidades;
using System.Data;

namespace BLL
{
    public class planillaDirectaVariosDetalleBLL
    {
        planillaDirectaVariosDetalleDAL pdvdDAL = new planillaDirectaVariosDetalleDAL();
        planillaDirectaVariosDetalleTo pdvdTo = new planillaDirectaVariosDetalleTo();

        public DataTable obtener_T_Planilla_Directa_Varios_Detalle_BLL(planillaDirectaVariosDetalleTo pdvdTo)
        {
            return pdvdDAL.obtener_T_Planilla_Directa_Varios_Detalle_DAL(pdvdTo);
        }
        public DataTable obtener_T_Dev_Planilla_Directa_Varios_Detalle_BLL(planillaDirectaVariosDetalleTo pdvdTo)
        {
            return pdvdDAL.obtener_T_Dev_Planilla_Directa_Varios_Detalle_DAL(pdvdTo);
        }
        public bool insertar_T_PLANILLA_DIRECTA_VARIOS_BLL(planillaDirectaVariosDetalleTo pdvdTo, ref string errMensaje)
        {
            bool result = true;
            if (!pdvdDAL.insertar_T_Planilla_Directa_Varios_Detalle_DAL(pdvdTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool insertar_T_DEV_PLANILLA_DIRECTA_VARIOS_BLL(planillaDirectaVariosDetalleTo pdvdTo, ref string errMensaje)
        {
            bool result = true;
            if (!pdvdDAL.insertar_T_DEV_Planilla_Directa_Varios_Detalle_DAL(pdvdTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminar_T_PLANILLA_DIRECTA_VARIOS_BLL(planillaDirectaVariosDetalleTo pdvdTo, ref string errMensaje)
        {
            bool result = true;
            if (!pdvdDAL.eliminar_T_PLANILLA_DIRECTA_VARIOS_DAL(pdvdTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminar_T_DEV_PLANILLA_DIRECTA_VARIOS_BLL(planillaDirectaVariosDetalleTo pdvdTo, ref string errMensaje)
        {
            bool result = true;
            if (!pdvdDAL.eliminar_T_DEV_PLANILLA_DIRECTA_VARIOS_DAL(pdvdTo, ref errMensaje))
                return result = false;
            return result;
        }
    }
}
