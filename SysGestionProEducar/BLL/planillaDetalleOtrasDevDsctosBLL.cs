using DAL;
using Entidades;
using System.Data;

namespace BLL
{
    public class planillaDetalleOtrasDevDsctosBLL
    {
        planillaDetalleOtrasDevDsctosDAL pldDAL = new planillaDetalleOtrasDevDsctosDAL();
        public DataTable obtenerPlanillaDetalleOtrasDevDsctosPendientesBLL()
        {
            return pldDAL.obtenerPlanillaDetalleOtrasDevDsctosPendientesDAL();
        }
        public DataTable obtenerPlanillaDetalleOtrasDevDsctosBLL(planillaDetalleOtrasDevDsctosTo pldTo)
        {
            return pldDAL.obtenerPlanillaDetalleOtrasDevDsctosDAL(pldTo);
        }
        public bool insertarPlanillaDetalleOtrasDevDsctosBLL(planillaDetalleOtrasDevDsctosTo pldTo, ref string errMensaje)
        {
            bool result = true;
            if (!pldDAL.insertarPlanillaDetalleOtrasDevDsctosDAL(pldTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificarPlanillaDetalleOtrasDevDsctosBLL(planillaDetalleOtrasDevDsctosTo pldTo, ref string errMensaje)
        {
            bool result = true;
            if (!pldDAL.modificarPlanillaDetalleOtrasDevDsctosDAL(pldTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminarPlanillaDetalleOtrasDevDsctosBLL(planillaDetalleOtrasDevDsctosTo pldTo, ref string errMensaje)
        {
            bool result = true;
            if (!pldDAL.eliminarPlanillaDetalleOtrasDevDsctosDAL(pldTo, ref errMensaje))
                return result = false;
            return result;
        }
        public DataTable obtenerPlanillaDetalleDstoDirectaBLL(planillaDetalleOtrasDevDsctosTo pldTo)
        {
            return pldDAL.obtenerPlanillaDetalleDstoDirectaDAL(pldTo);
        }
    }
}
