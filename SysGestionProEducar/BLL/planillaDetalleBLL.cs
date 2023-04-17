using DAL;
using Entidades;
using System.Data;
namespace BLL
{
    public class planillaDetalleBLL
    {
        planillaDetalleDAL pldDAL = new planillaDetalleDAL();

        public DataTable obtener_I_Planilla_Detalle_BLL(planillaDetalleTo pldTo)
        {
            return pldDAL.obtener_I_Planilla_Detalle_DAL(pldTo);
        }
        public DataTable obtener_I_Planilla_Detalle_para_Aprobar_Recepcion_Planilla_BLL(planillaDetalleTo pldTo)
        {
            return pldDAL.obtener_I_Planilla_Detalle_para_Aprobar_Recepcion_Planilla_DAL(pldTo);
        }
        public DataTable obtener_I_Planilla_Detalle_para_Recepcion_BLL(planillaDetalleTo pldTo)
        {
            return pldDAL.obtener_I_Planilla_Detalle_para_Recepcion_DAL(pldTo);
        }
        public DataTable obtener_I_Planilla_Detalle_para_Recepcion_Consolidado_BLL(planillaDetalleTo pldTo)
        {
            return pldDAL.obtener_I_Planilla_Detalle_para_Recepcion_Consolidado_DAL(pldTo);
        }
        public DataTable obtener_I_Planilla_Detalle_para_Cancelacion_BLL(planillaDetalleTo pldTo)
        {
            return pldDAL.obtener_I_Planilla_Detalle_para_Cancelacion_DAL(pldTo);
        }
        public bool insertar_T_Planilla_Detalle_BLL(planillaDetalleTo pldTo, ref string errMensaje)
        {
            bool result = true;
            if (!pldDAL.insertar_T_Planilla_Detalle_DAL(pldTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminar_I_Planilla_Detalle_BLL(planillaCabeceraTo plcTo, ref string errMensaje)
        {
            bool result = true;
            if (!pldDAL.eliminar_I_Planilla_Detalle_DAL(plcTo, ref errMensaje))
                return result = false;
            return result;
        }
        public DataTable obtener_I_Planilla_Detalle_Envio_BLL(planillaDetalleTo pldTo)
        {
            return pldDAL.obtener_I_Planilla_Detalle_Envio_DAL(pldTo);
        }
        public bool Actualiza_Repciona_T_Planilla_Detalle_BLL(planillaDetalleTo pldTo, ref string errMensaje)
        {
            bool result = true;
            if (!pldDAL.Actualiza_Repciona_T_Planilla_Detalle_DAL(pldTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminar_T_Planilla_Detalle_Modificar_BLL(planillaDetalleTo pldTo, ref string errMensaje)
        {
            bool result = true;
            if (!pldDAL.eliminar_T_Planilla_Detalle_Modificar_BLL(pldTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool insertarPersonaIndebidaPlanillaBLL(planillaDetalleTo pldTo, ref string errMensaje)
        {
            bool result = true;
            if (!pldDAL.insertarPersonaIndebidaPlanillaDAL(pldTo, ref errMensaje))
                return result = false;
            return result;

        }

    }
}
